Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.DistribucionNC
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta
'Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU.wsAsociados
Imports Janus.Windows.GridEX
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralTalla
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports System.Collections.Generic

Public Class frmModCapNotCredito
    Inherits System.Windows.Forms.Form

#Region "Objetos S2Credit"
    Dim oS2Credit As New ProcesosS2Credit
#End Region

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oNotasCreditoMgr = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
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
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents EditBox5 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuArchivoModificar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents uibtnCapturaDetalle As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ebTotal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebIVA As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSubTotal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPlayerCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPlayerNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebClienteNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents uicmbTipoDevolucion As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebFolioReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMotivo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAplicada As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucOrigen As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblTallaFin As System.Windows.Forms.Label
    Friend WithEvents lblTallaInicio As System.Windows.Forms.Label
    Friend WithEvents uibtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebArticuloDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTotalArticulos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents menuArchivoBuscar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents uibtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents uibtnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents lblLabel5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents gridNotaCreditoDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebTipoVenta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebClienteCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuReimprimirNotaCredito1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuReimprimirNotaCredito As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir2 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModCapNotCredito))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoBuscar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoEliminar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuReimprimirNotaCredito1 = New Janus.Windows.UI.CommandBars.UICommand("MnuReimprimirNotaCredito")
        Me.menuSalir2 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoModificar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoEliminar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.menuArchivoAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.MnuReimprimirNotaCredito = New Janus.Windows.UI.CommandBars.UICommand("MnuReimprimirNotaCredito")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebClienteCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebTipoVenta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gridNotaCreditoDetalle = New Janus.Windows.GridEX.GridEX()
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebClienteNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFolioReferencia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.uibtnCapturaDetalle = New Janus.Windows.EditControls.UIButton()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ebPlayerCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.uicmbTipoDevolucion = New Janus.Windows.EditControls.UIComboBox()
        Me.ebMotivo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebAplicada = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucOrigen = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox5 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPlayerNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblLabel5 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.uibtnNuevo = New Janus.Windows.EditControls.UIButton()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblTallaFin = New System.Windows.Forms.Label()
        Me.lblTallaInicio = New System.Windows.Forms.Label()
        Me.uibtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.uibtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.ebTotal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebIVA = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSubTotal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebTotalArticulos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebArticuloDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.gridNotaCreditoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuSalir, Me.menuArchivoNuevo, Me.menuArchivoGuardar, Me.menuArchivoEliminar, Me.menuArchivoAbrir, Me.MnuReimprimirNotaCredito})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("d9905ec7-1f0c-4de5-beee-3827763bc718")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowQuickCustomizeMenu = False
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(776, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        Me.UiCommandBar1.Visible = False
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.Separator3, Me.menuArchivoGuardar2, Me.Separator4, Me.menuArchivoBuscar2, Me.Separator6, Me.menuArchivoEliminar2, Me.Separator8, Me.Separator9, Me.MnuReimprimirNotaCredito1, Me.menuSalir2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(371, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuArchivoGuardar2
        '
        Me.menuArchivoGuardar2.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar2.Name = "menuArchivoGuardar2"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuArchivoBuscar2
        '
        Me.menuArchivoBuscar2.Key = "menuArchivoAbrir"
        Me.menuArchivoBuscar2.Name = "menuArchivoBuscar2"
        Me.menuArchivoBuscar2.Text = "&Buscar"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuArchivoEliminar2
        '
        Me.menuArchivoEliminar2.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar2.Name = "menuArchivoEliminar2"
        Me.menuArchivoEliminar2.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'MnuReimprimirNotaCredito1
        '
        Me.MnuReimprimirNotaCredito1.Image = CType(resources.GetObject("MnuReimprimirNotaCredito1.Image"), System.Drawing.Image)
        Me.MnuReimprimirNotaCredito1.Key = "MnuReimprimirNotaCredito"
        Me.MnuReimprimirNotaCredito1.Name = "MnuReimprimirNotaCredito1"
        '
        'menuSalir2
        '
        Me.menuSalir2.Icon = CType(resources.GetObject("menuSalir2.Icon"), System.Drawing.Icon)
        Me.menuSalir2.Key = "menuSalir"
        Me.menuSalir2.Name = "menuSalir2"
        Me.menuSalir2.Text = "Salir"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.Separator1, Me.menuArchivoGuardar1, Me.Separator2, Me.menuArchivoModificar1, Me.Separator5, Me.menuArchivoEliminar1, Me.Separator7, Me.menuSalir1})
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
        'menuArchivoGuardar1
        '
        Me.menuArchivoGuardar1.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuArchivoModificar1
        '
        Me.menuArchivoModificar1.Key = "menuArchivoAbrir"
        Me.menuArchivoModificar1.Name = "menuArchivoModificar1"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuArchivoEliminar1
        '
        Me.menuArchivoEliminar1.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar1.Name = "menuArchivoEliminar1"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        Me.menuSalir1.Text = "Salir"
        '
        'menuSalir
        '
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
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
        'menuArchivoEliminar
        '
        Me.menuArchivoEliminar.Image = CType(resources.GetObject("menuArchivoEliminar.Image"), System.Drawing.Image)
        Me.menuArchivoEliminar.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Name = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Text = "&Eliminar"
        '
        'menuArchivoAbrir
        '
        Me.menuArchivoAbrir.Image = CType(resources.GetObject("menuArchivoAbrir.Image"), System.Drawing.Image)
        Me.menuArchivoAbrir.Key = "menuArchivoAbrir"
        Me.menuArchivoAbrir.Name = "menuArchivoAbrir"
        Me.menuArchivoAbrir.Text = "&Abrir"
        '
        'MnuReimprimirNotaCredito
        '
        Me.MnuReimprimirNotaCredito.Key = "MnuReimprimirNotaCredito"
        Me.MnuReimprimirNotaCredito.Name = "MnuReimprimirNotaCredito"
        Me.MnuReimprimirNotaCredito.Text = "Reimpresión"
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
        Me.TopRebar1.Size = New System.Drawing.Size(776, 50)
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ebClienteCod)
        Me.ExplorerBar1.Controls.Add(Me.ebTipoVenta)
        Me.ExplorerBar1.Controls.Add(Me.gridNotaCreditoDetalle)
        Me.ExplorerBar1.Controls.Add(Me.ebFecha)
        Me.ExplorerBar1.Controls.Add(Me.ebClienteNombre)
        Me.ExplorerBar1.Controls.Add(Me.ebFolioReferencia)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.uibtnCapturaDetalle)
        Me.ExplorerBar1.Controls.Add(Me.Label20)
        Me.ExplorerBar1.Controls.Add(Me.ebPlayerCod)
        Me.ExplorerBar1.Controls.Add(Me.uicmbTipoDevolucion)
        Me.ExplorerBar1.Controls.Add(Me.ebMotivo)
        Me.ExplorerBar1.Controls.Add(Me.ebAplicada)
        Me.ExplorerBar1.Controls.Add(Me.ebSucOrigen)
        Me.ExplorerBar1.Controls.Add(Me.EditBox5)
        Me.ExplorerBar1.Controls.Add(Me.ebPlayerNombre)
        Me.ExplorerBar1.Controls.Add(Me.ebFolio)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Modulo de Capturas de Notas de Credito"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(776, 360)
        Me.ExplorerBar1.TabIndex = 2
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebClienteCod
        '
        Me.ebClienteCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteCod.ButtonImage = CType(resources.GetObject("ebClienteCod.ButtonImage"), System.Drawing.Image)
        Me.ebClienteCod.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebClienteCod.Enabled = False
        Me.ebClienteCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteCod.Location = New System.Drawing.Point(128, 144)
        Me.ebClienteCod.MaxLength = 10
        Me.ebClienteCod.Name = "ebClienteCod"
        Me.ebClienteCod.Size = New System.Drawing.Size(136, 22)
        Me.ebClienteCod.TabIndex = 2
        Me.ebClienteCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTipoVenta
        '
        Me.ebTipoVenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.ebTipoVenta.DesignTimeLayout = GridEXLayout1
        Me.ebTipoVenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTipoVenta.Location = New System.Drawing.Point(128, 120)
        Me.ebTipoVenta.Name = "ebTipoVenta"
        Me.ebTipoVenta.Size = New System.Drawing.Size(160, 22)
        Me.ebTipoVenta.TabIndex = 1
        Me.ebTipoVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTipoVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gridNotaCreditoDetalle
        '
        Me.gridNotaCreditoDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.gridNotaCreditoDetalle.DesignTimeLayout = GridEXLayout2
        Me.gridNotaCreditoDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridNotaCreditoDetalle.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.gridNotaCreditoDetalle.GroupByBoxVisible = False
        Me.gridNotaCreditoDetalle.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.gridNotaCreditoDetalle.Location = New System.Drawing.Point(8, 184)
        Me.gridNotaCreditoDetalle.Name = "gridNotaCreditoDetalle"
        Me.gridNotaCreditoDetalle.Size = New System.Drawing.Size(762, 168)
        Me.gridNotaCreditoDetalle.TabIndex = 33
        Me.gridNotaCreditoDetalle.TabStop = False
        Me.gridNotaCreditoDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.SystemColors.Info
        Me.ebFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecha.Location = New System.Drawing.Point(128, 66)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(113, 22)
        Me.ebFecha.TabIndex = 32
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebClienteNombre
        '
        Me.ebClienteNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteNombre.BackColor = System.Drawing.SystemColors.Info
        Me.ebClienteNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteNombre.Location = New System.Drawing.Point(264, 144)
        Me.ebClienteNombre.Name = "ebClienteNombre"
        Me.ebClienteNombre.ReadOnly = True
        Me.ebClienteNombre.Size = New System.Drawing.Size(274, 22)
        Me.ebClienteNombre.TabIndex = 31
        Me.ebClienteNombre.TabStop = False
        Me.ebClienteNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolioReferencia
        '
        Me.ebFolioReferencia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioReferencia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioReferencia.BackColor = System.Drawing.SystemColors.Info
        Me.ebFolioReferencia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioReferencia.Location = New System.Drawing.Point(288, 40)
        Me.ebFolioReferencia.Name = "ebFolioReferencia"
        Me.ebFolioReferencia.ReadOnly = True
        Me.ebFolioReferencia.Size = New System.Drawing.Size(104, 22)
        Me.ebFolioReferencia.TabIndex = 30
        Me.ebFolioReferencia.TabStop = False
        Me.ebFolioReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolioReferencia.Visible = False
        Me.ebFolioReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(216, 42)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 23)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "Folio Ref:"
        Me.Label21.Visible = False
        '
        'uibtnCapturaDetalle
        '
        Me.uibtnCapturaDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnCapturaDetalle.Image = CType(resources.GetObject("uibtnCapturaDetalle.Image"), System.Drawing.Image)
        Me.uibtnCapturaDetalle.Location = New System.Drawing.Point(583, 148)
        Me.uibtnCapturaDetalle.Name = "uibtnCapturaDetalle"
        Me.uibtnCapturaDetalle.Size = New System.Drawing.Size(184, 30)
        Me.uibtnCapturaDetalle.TabIndex = 5
        Me.uibtnCapturaDetalle.Text = "Captura de Detalle"
        Me.uibtnCapturaDetalle.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(16, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(105, 23)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "Tipo de Venta:"
        '
        'ebPlayerCod
        '
        Me.ebPlayerCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerCod.ButtonImage = CType(resources.GetObject("ebPlayerCod.ButtonImage"), System.Drawing.Image)
        Me.ebPlayerCod.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebPlayerCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayerCod.Location = New System.Drawing.Point(128, 92)
        Me.ebPlayerCod.MaxLength = 12
        Me.ebPlayerCod.Name = "ebPlayerCod"
        Me.ebPlayerCod.Size = New System.Drawing.Size(88, 22)
        Me.ebPlayerCod.TabIndex = 0
        Me.ebPlayerCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uicmbTipoDevolucion
        '
        Me.uicmbTipoDevolucion.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.uicmbTipoDevolucion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "EST"
        UiComboBoxItem1.Value = "EST"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "DEF"
        UiComboBoxItem2.Value = "DEF"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "EQU"
        UiComboBoxItem3.Value = "EQU"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "NEB"
        UiComboBoxItem4.Value = "NEB"
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "RFF"
        UiComboBoxItem5.Value = "RFF"
        Me.uicmbTipoDevolucion.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5})
        Me.uicmbTipoDevolucion.Location = New System.Drawing.Point(544, 92)
        Me.uicmbTipoDevolucion.Name = "uicmbTipoDevolucion"
        Me.uicmbTipoDevolucion.Size = New System.Drawing.Size(56, 22)
        Me.uicmbTipoDevolucion.TabIndex = 3
        Me.uicmbTipoDevolucion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebMotivo
        '
        Me.ebMotivo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMotivo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebMotivo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMotivo.Location = New System.Drawing.Point(544, 120)
        Me.ebMotivo.MaxLength = 255
        Me.ebMotivo.Name = "ebMotivo"
        Me.ebMotivo.Size = New System.Drawing.Size(224, 22)
        Me.ebMotivo.TabIndex = 4
        Me.ebMotivo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAplicada
        '
        Me.ebAplicada.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAplicada.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAplicada.BackColor = System.Drawing.SystemColors.Info
        Me.ebAplicada.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAplicada.Location = New System.Drawing.Point(640, 40)
        Me.ebAplicada.Name = "ebAplicada"
        Me.ebAplicada.ReadOnly = True
        Me.ebAplicada.Size = New System.Drawing.Size(56, 22)
        Me.ebAplicada.TabIndex = 17
        Me.ebAplicada.TabStop = False
        Me.ebAplicada.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAplicada.Visible = False
        Me.ebAplicada.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucOrigen
        '
        Me.ebSucOrigen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucOrigen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucOrigen.BackColor = System.Drawing.SystemColors.Info
        Me.ebSucOrigen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucOrigen.Location = New System.Drawing.Point(544, 66)
        Me.ebSucOrigen.Name = "ebSucOrigen"
        Me.ebSucOrigen.ReadOnly = True
        Me.ebSucOrigen.Size = New System.Drawing.Size(56, 22)
        Me.ebSucOrigen.TabIndex = 16
        Me.ebSucOrigen.TabStop = False
        Me.ebSucOrigen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucOrigen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox5
        '
        Me.EditBox5.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox5.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox5.Location = New System.Drawing.Point(512, 40)
        Me.EditBox5.MaxLength = 1
        Me.EditBox5.Name = "EditBox5"
        Me.EditBox5.Size = New System.Drawing.Size(25, 22)
        Me.EditBox5.TabIndex = 15
        Me.EditBox5.TabStop = False
        Me.EditBox5.Text = "N"
        Me.EditBox5.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.EditBox5.Visible = False
        Me.EditBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPlayerNombre
        '
        Me.ebPlayerNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerNombre.BackColor = System.Drawing.SystemColors.Info
        Me.ebPlayerNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayerNombre.Location = New System.Drawing.Point(222, 92)
        Me.ebPlayerNombre.Name = "ebPlayerNombre"
        Me.ebPlayerNombre.ReadOnly = True
        Me.ebPlayerNombre.Size = New System.Drawing.Size(168, 22)
        Me.ebPlayerNombre.TabIndex = 13
        Me.ebPlayerNombre.TabStop = False
        Me.ebPlayerNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.BackColor = System.Drawing.SystemColors.Info
        Me.ebFolio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolio.ForeColor = System.Drawing.Color.Red
        Me.ebFolio.Location = New System.Drawing.Point(128, 40)
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.Size = New System.Drawing.Size(72, 22)
        Me.ebFolio.TabIndex = 11
        Me.ebFolio.TabStop = False
        Me.ebFolio.Text = "00001"
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(16, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Fecha:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(16, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Realizado:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(16, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Cliente:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(400, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 23)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Dev. de Dinero:"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(408, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Suc. Origen:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(560, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Aplicada:"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(408, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tipo de Devolucion:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(408, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Motivo:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(16, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Folio N.C:"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.lblLabel5)
        Me.ExplorerBar2.Controls.Add(Me.lblLabel2)
        Me.ExplorerBar2.Controls.Add(Me.lblLabel1)
        Me.ExplorerBar2.Controls.Add(Me.lblLabel4)
        Me.ExplorerBar2.Controls.Add(Me.uibtnNuevo)
        Me.ExplorerBar2.Controls.Add(Me.Label19)
        Me.ExplorerBar2.Controls.Add(Me.lblTallaFin)
        Me.ExplorerBar2.Controls.Add(Me.lblTallaInicio)
        Me.ExplorerBar2.Controls.Add(Me.uibtnEliminar)
        Me.ExplorerBar2.Controls.Add(Me.uibtnGuardar)
        Me.ExplorerBar2.Controls.Add(Me.ebTotal)
        Me.ExplorerBar2.Controls.Add(Me.ebIVA)
        Me.ExplorerBar2.Controls.Add(Me.ebSubTotal)
        Me.ExplorerBar2.Controls.Add(Me.ebTotalArticulos)
        Me.ExplorerBar2.Controls.Add(Me.ebArticuloDesc)
        Me.ExplorerBar2.Controls.Add(Me.Label2)
        Me.ExplorerBar2.Controls.Add(Me.Label12)
        Me.ExplorerBar2.Controls.Add(Me.Label14)
        Me.ExplorerBar2.Controls.Add(Me.Label15)
        Me.ExplorerBar2.Controls.Add(Me.Label16)
        Me.ExplorerBar2.Controls.Add(Me.Label18)
        Me.ExplorerBar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Descripcion:"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(3, 350)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(770, 170)
        Me.ExplorerBar2.TabIndex = 3
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel5.ForeColor = System.Drawing.Color.Black
        Me.lblLabel5.Location = New System.Drawing.Point(182, 137)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(164, 16)
        Me.lblLabel5.TabIndex = 76
        Me.lblLabel5.Text = "Guardar e Imprimir"
        Me.lblLabel5.Visible = False
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.ForeColor = System.Drawing.Color.Black
        Me.lblLabel2.Location = New System.Drawing.Point(38, 137)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(84, 16)
        Me.lblLabel2.TabIndex = 75
        Me.lblLabel2.Text = "Guardar"
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.ForeColor = System.Drawing.Color.Red
        Me.lblLabel1.Location = New System.Drawing.Point(158, 137)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel1.TabIndex = 74
        Me.lblLabel1.Text = "F9"
        Me.lblLabel1.Visible = False
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.ForeColor = System.Drawing.Color.Red
        Me.lblLabel4.Location = New System.Drawing.Point(14, 137)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel4.TabIndex = 73
        Me.lblLabel4.Text = "F2"
        '
        'uibtnNuevo
        '
        Me.uibtnNuevo.Location = New System.Drawing.Point(371, 129)
        Me.uibtnNuevo.Name = "uibtnNuevo"
        Me.uibtnNuevo.Size = New System.Drawing.Size(128, 28)
        Me.uibtnNuevo.TabIndex = 7
        Me.uibtnNuevo.Text = "&Nuevo"
        Me.uibtnNuevo.Visible = False
        Me.uibtnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(208, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(20, 13)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "al"
        '
        'lblTallaFin
        '
        Me.lblTallaFin.BackColor = System.Drawing.Color.Transparent
        Me.lblTallaFin.ForeColor = System.Drawing.Color.Red
        Me.lblTallaFin.Location = New System.Drawing.Point(240, 64)
        Me.lblTallaFin.Name = "lblTallaFin"
        Me.lblTallaFin.Size = New System.Drawing.Size(48, 13)
        Me.lblTallaFin.TabIndex = 25
        Me.lblTallaFin.Text = "00 "
        '
        'lblTallaInicio
        '
        Me.lblTallaInicio.BackColor = System.Drawing.Color.Transparent
        Me.lblTallaInicio.ForeColor = System.Drawing.Color.Red
        Me.lblTallaInicio.Location = New System.Drawing.Point(160, 64)
        Me.lblTallaInicio.Name = "lblTallaInicio"
        Me.lblTallaInicio.Size = New System.Drawing.Size(48, 23)
        Me.lblTallaInicio.TabIndex = 24
        Me.lblTallaInicio.Text = "00 "
        '
        'uibtnEliminar
        '
        Me.uibtnEliminar.Location = New System.Drawing.Point(643, 129)
        Me.uibtnEliminar.Name = "uibtnEliminar"
        Me.uibtnEliminar.Size = New System.Drawing.Size(123, 28)
        Me.uibtnEliminar.TabIndex = 9
        Me.uibtnEliminar.Text = "&Eliminar"
        Me.uibtnEliminar.Visible = False
        Me.uibtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnGuardar
        '
        Me.uibtnGuardar.Location = New System.Drawing.Point(507, 129)
        Me.uibtnGuardar.Name = "uibtnGuardar"
        Me.uibtnGuardar.Size = New System.Drawing.Size(128, 28)
        Me.uibtnGuardar.TabIndex = 8
        Me.uibtnGuardar.Text = "&Guardar"
        Me.uibtnGuardar.Visible = False
        Me.uibtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebTotal
        '
        Me.ebTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotal.BackColor = System.Drawing.SystemColors.Info
        Me.ebTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotal.Location = New System.Drawing.Point(608, 91)
        Me.ebTotal.Name = "ebTotal"
        Me.ebTotal.ReadOnly = True
        Me.ebTotal.Size = New System.Drawing.Size(152, 22)
        Me.ebTotal.TabIndex = 21
        Me.ebTotal.TabStop = False
        Me.ebTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebIVA
        '
        Me.ebIVA.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebIVA.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebIVA.BackColor = System.Drawing.SystemColors.Info
        Me.ebIVA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebIVA.Location = New System.Drawing.Point(608, 63)
        Me.ebIVA.Name = "ebIVA"
        Me.ebIVA.ReadOnly = True
        Me.ebIVA.Size = New System.Drawing.Size(152, 22)
        Me.ebIVA.TabIndex = 17
        Me.ebIVA.TabStop = False
        Me.ebIVA.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebIVA.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSubTotal
        '
        Me.ebSubTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSubTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSubTotal.BackColor = System.Drawing.SystemColors.Info
        Me.ebSubTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSubTotal.Location = New System.Drawing.Point(608, 36)
        Me.ebSubTotal.Name = "ebSubTotal"
        Me.ebSubTotal.ReadOnly = True
        Me.ebSubTotal.Size = New System.Drawing.Size(152, 22)
        Me.ebSubTotal.TabIndex = 16
        Me.ebSubTotal.TabStop = False
        Me.ebSubTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSubTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTotalArticulos
        '
        Me.ebTotalArticulos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalArticulos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalArticulos.BackColor = System.Drawing.SystemColors.Info
        Me.ebTotalArticulos.ButtonImage = CType(resources.GetObject("ebTotalArticulos.ButtonImage"), System.Drawing.Image)
        Me.ebTotalArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalArticulos.Location = New System.Drawing.Point(152, 88)
        Me.ebTotalArticulos.Name = "ebTotalArticulos"
        Me.ebTotalArticulos.ReadOnly = True
        Me.ebTotalArticulos.Size = New System.Drawing.Size(80, 21)
        Me.ebTotalArticulos.TabIndex = 14
        Me.ebTotalArticulos.TabStop = False
        Me.ebTotalArticulos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTotalArticulos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebArticuloDesc
        '
        Me.ebArticuloDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebArticuloDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebArticuloDesc.BackColor = System.Drawing.SystemColors.Info
        Me.ebArticuloDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebArticuloDesc.Location = New System.Drawing.Point(152, 36)
        Me.ebArticuloDesc.Name = "ebArticuloDesc"
        Me.ebArticuloDesc.ReadOnly = True
        Me.ebArticuloDesc.Size = New System.Drawing.Size(240, 21)
        Me.ebArticuloDesc.TabIndex = 11
        Me.ebArticuloDesc.TabStop = False
        Me.ebArticuloDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebArticuloDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(56, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 23)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Tallas del"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(56, 91)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Total de Art:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(512, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 23)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "SubTotal:"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(512, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 23)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "I.V.A.:"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(512, 97)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 23)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Total:"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(56, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 23)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Descripcion:"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.ExplorerBar2)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 50)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(776, 523)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'frmModCapNotCredito
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(776, 573)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmModCapNotCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modulo de Captura de Notas de Credito"
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
        CType(Me.gridNotaCreditoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propiedades"

    Private m_dtTallas As DataTable

    Public Property CambioTallas() As DataTable
        Get
            Return m_dtTallas
        End Get
        Set(ByVal Value As DataTable)
            m_dtTallas = Value
        End Set
    End Property

#End Region

#Region "Variables miembros"

    Public oNotaCredito As NotaCredito

    Private oNotaCreditoValida As NotaCredito

    Private oNotasCreditoMgr As NotasCreditoManager

    Public oCliente As ClienteAlterno

    Private oCatalogoClientesMgr As ClientesManager

    Private oPlayer As Vendedor

    Private oCatalogoPlayersMgr As CatalogoVendedoresManager

    Private oArticulo As Articulo

    Private oCatalogoArticulosMgr As CatalogoArticuloManager

    Private oSucOrigen As Almacen

    Private oCatalogoAlmacenesMgr As CatalogoAlmacenesManager

    Private dsNotaCreditoDetalle As DataSet

    Private dsCatalogoCorridas As DataSet

    Public strTablaTmp As String = "NotaCreditoDetalleTmp" & oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & oAppContext.Security.CurrentUser.ID

    Private bolSalir As Boolean

    Private AsociadoTipoVenta As String = String.Empty

    Private oAjuste As AjusteGeneralTallaInfo

    Private oAjusteMgr As New AjusteGeneralTallaManager(oAppContext)

    Private oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

    Private bolNCGuardada As Boolean = False

    Private intFacturaID As Integer

    Dim oFacturaMgr As FacturaManager

    Dim UserName As String = ""
    Dim UserLoginName As String = ""
    Private RestService As New ProcesosRetail("", "POST")

#End Region



#Region "Métodos Privados"

    Public Sub Sm_Inicializar()

        oNotasCreditoMgr = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

        oCatalogoClientesMgr = New ClientesManager(oAppContext)

        oCatalogoPlayersMgr = New CatalogoVendedoresManager(oAppContext)

        oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)

        oCatalogoAlmacenesMgr = New CatalogoAlmacenesManager(oAppContext)

        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)

        dsCatalogoCorridas = oNotasCreditoMgr.ExtraerCatalogoCorridas
        oCliente = Me.oCatalogoClientesMgr.CreateAlterno
        oCliente.Clear()

        oNotasCreditoMgr.CrearTablaTmp(strTablaTmp)

        ebFolio.Text = Format(oNotasCreditoMgr.Folios, "000000")

        ebFecha.Text = Format(Date.Today, "dd-MMM-yyyy")

        Sm_FillCmbTipoVenta()

        ebSucOrigen.Text = oAppContext.ApplicationConfiguration.Almacen

        ebPlayerCod.Focus()

        Sm_CrearTablaCambioTallas()

        Sm_Nuevo()

    End Sub

    Private Sub Sm_CrearTablaCambioTallas()

        Me.CambioTallas = New DataTable("CambioTallas")
        Me.CambioTallas.Columns.Add("CodArticulo")
        Me.CambioTallas.Columns.Add("TallaReal")
        Me.CambioTallas.Columns.Add("TallaFactura")
        Me.CambioTallas.Columns.Add("Descripcion")
        Me.CambioTallas.Columns.Add("FacturaSAP")
        Me.CambioTallas.Columns.Add("Cantidad")
        Me.CambioTallas.Columns.Add("FoliosAjustes")
        Me.CambioTallas.Columns.Add("PosGrid")

    End Sub

    Private Sub Sm_Finalizar()

        'On Error Resume Next

        oNotasCreditoMgr.EliminarTablaTmp(strTablaTmp)

        oNotaCredito = Nothing

        oNotaCreditoValida = Nothing

        oNotasCreditoMgr = Nothing

        'oCliente = Nothing

        oCatalogoClientesMgr = Nothing

        oPlayer = Nothing

        oCatalogoPlayersMgr = Nothing

        oArticulo = Nothing

        oCatalogoArticulosMgr = Nothing

        oSucOrigen = Nothing

        oCatalogoAlmacenesMgr = Nothing

        dsCatalogoCorridas.Dispose()

        dsCatalogoCorridas = Nothing

        If Not dsNotaCreditoDetalle Is Nothing Then dsNotaCreditoDetalle.Dispose()

        dsNotaCreditoDetalle = Nothing

    End Sub



    Private Sub Sm_FillCmbTipoVenta()
        Dim oTipoVentaMgr As New TiposVentaManager(oAppContext)

        Dim dsTipoVenta As DataSet = oTipoVentaMgr.Load()

        Dim dv As DataView
        If oAppContext.ApplicationConfiguration.Almacen = "053" Then
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 15.09.2014: Se modifica temporalmente porque Soporte le activo la opcion de ventas DIPs a la 53 sin avisar y es necesario
            'hacer NCs
            '------------------------------------------------------------------------------------------------------------------------------------
            'dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta = 'V' or CodTipoVenta = 'A' or CodTipoVenta = 'K' OR CodTipoVenta = 'F' OR CodTipoVenta = 'S' OR CodTipoVenta = 'P' OR CodTipoVenta = 'I'", "CodTipoventa desc", DataViewRowState.CurrentRows)
            'dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta = 'V' or CodTipoVenta = 'A' or CodTipoVenta = 'K' OR CodTipoVenta = 'F' OR CodTipoVenta = 'S' OR CodTipoVenta = 'P' OR CodTipoVenta = 'I' OR CodTipoVenta = 'D'", "CodTipoventa desc", DataViewRowState.CurrentRows)
            dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta = 'V' or CodTipoVenta = 'A' or CodTipoVenta = 'K' OR CodTipoVenta = 'F' OR CodTipoVenta = 'P' OR CodTipoVenta = 'I' OR CodTipoVenta = 'D'", "CodTipoventa desc", DataViewRowState.CurrentRows)
        Else
            dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta <> 'S'", "CodTipoventa desc", DataViewRowState.CurrentRows)
        End If

        ebTipoVenta.DataSource = dv
        'ebTipoVenta.DataMember = dsTipoVenta.Tables(0).TableName

        ebTipoVenta.DisplayMember = "Descripcion"
        ebTipoVenta.ValueMember = "CodTipoVenta"

        oTipoVentaMgr.Dispose()

    End Sub



    Private Sub Sm_TxtLimpiar()

        oNotaCredito = Nothing

        If Not oNotaCreditoValida Is Nothing Then
            If Not oNotaCreditoValida.NCE_RESULT = "Y" Then
                oNotaCreditoValida = Nothing
            End If
        End If


        'oCliente = Nothing
        oPlayer = Nothing

        ebPlayerCod.Text = String.Empty
        ebPlayerNombre.Text = String.Empty
        ebClienteCod.Text = String.Empty
        ebClienteNombre.Text = String.Empty
        ebFolioReferencia.Text = String.Empty
        ebSucOrigen.Text = String.Empty
        ebAplicada.Text = String.Empty
        uicmbTipoDevolucion.Text = String.Empty
        ebTipoVenta.Text = String.Empty
        ebMotivo.Text = String.Empty

        ebArticuloDesc.Text = String.Empty
        ebTotalArticulos.Text = String.Empty
        lblTallaInicio.Text = String.Empty
        lblTallaFin.Text = String.Empty

        ebSubTotal.Text = String.Empty
        ebIVA.Text = String.Empty
        ebTotal.Text = String.Empty


        'odsContratoDetalle = Nothing
        gridNotaCreditoDetalle.DataSource = Nothing

        'Se valida aki por si hay mas de una nota de credito pendiente.
        'Validamos si existen notas de credito que se guardaron en SAP pero en DP PRO no!
        'Dim strDatos As String
        'Dim strDatosA() As String
        'Dim dt As DataTable


        'strDatos = Me.oNotasCreditoMgr.GetDatosNCSAP("T" & oAppContext.ApplicationConfiguration.Almacen & _
        'oAppContext.ApplicationConfiguration.NoCaja & _
        'CStr(oNotasCreditoMgr.GetSelectNCByCaja(oAppContext.ApplicationConfiguration.NoCaja)) _
        ', dt)

        'strDatosA = strDatos.Split("/")

        'If strDatosA(4) = "Y" Then

        '    oNotaCreditoValida = Nothing
        '    oNotaCreditoValida = oNotasCreditoMgr.Create

        '    oNotaCreditoValida.NCAsociado = strDatosA(0).Trim
        '    oNotaCreditoValida.NCFactura = strDatosA(1).Trim
        '    oNotaCreditoValida.NCDOCFI = strDatosA(2).Trim
        '    oNotaCreditoValida.NCDOCSD = strDatosA(3).Trim
        '    oNotaCreditoValida.NCE_RESULT = strDatosA(4).Trim
        '    oNotaCreditoValida.NCDetalle = dt

        '    Dim oform As New frmNCMSG(strDatosA(1), strDatosA(0), dt)
        '    oform.ShowDialog()

        'End If

    End Sub



    Private Function Fm_bolTxtValidar() As Boolean

        Dim bRes As Boolean = True

        Dim dtNotaCreditoDetalle As DataTable

        dtNotaCreditoDetalle = CType(gridNotaCreditoDetalle.DataSource, DataTable)

        If (oPlayer Is Nothing) Then

            MsgBox("No ha sido seleccionado un Player.", MsgBoxStyle.Exclamation, "DPTienda")
            ebPlayerCod.Focus()

            bRes = False
        ElseIf (oCliente Is Nothing) Then

            MsgBox("No ha sido seleccionado un Cliente.", MsgBoxStyle.Exclamation, "DPTienda")
            ebClienteCod.Focus()

            bRes = False

        ElseIf (ebTipoVenta.Text = String.Empty) Then

            MsgBox("No ha sido seleccionado un Tipo de Venta.", MsgBoxStyle.Exclamation, "DPTienda")
            ebTipoVenta.Focus()

            bRes = False

        ElseIf (uicmbTipoDevolucion.Text = String.Empty) Then

            MsgBox("No ha sido seleccionado un Tipo de Devolución.", MsgBoxStyle.Exclamation, "DPTienda")
            uicmbTipoDevolucion.Focus()

            bRes = False

        ElseIf (ebMotivo.Text.Trim = String.Empty) Then

            MsgBox("No ha sido capturado el Motivo de la Devolución.", MsgBoxStyle.Exclamation, "DPTienda")
            ebMotivo.Focus()

            bRes = False

        ElseIf (dtNotaCreditoDetalle Is Nothing) Then

            MsgBox("El Detalle de la Nota Crédito no cuenta con Registros.", MsgBoxStyle.Exclamation, "DPTienda")
            uibtnCapturaDetalle.Focus()

            bRes = False

        ElseIf (dtNotaCreditoDetalle.Rows.Count = 0) Then

            MsgBox("El Detalle de la Nota Crédito no cuenta con Registros.", MsgBoxStyle.Exclamation, "DPTienda")
            dtNotaCreditoDetalle = Nothing
            uibtnCapturaDetalle.Focus()

            bRes = False

        Else

            oAppContext.Security.CloseImpersonatedSession()
            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.DevolverFactura") = True Then
                UserName = oAppContext.Security.CurrentUser.Name.Trim
                UserLoginName = oAppContext.Security.CurrentUser.SessionLoginName.Trim
            Else
                bRes = False
            End If
            oAppContext.Security.CloseImpersonatedSession()

        End If

        dtNotaCreditoDetalle = Nothing

        Return bRes

    End Function



    Private Sub Sm_BuscarClientes(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        '<Validación>

        'If Not (oNotaCredito Is Nothing) Then

        '    MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
        '    Exit Sub

        'End If

        '</Validación>


        If (Vpa_bolOpenRecordDialog = True) Then

            'Dim oOpenRecordDlg As New OpenRecordDialog
            Dim oOpenRecordDlg As New OpenRecordDialogClientes


            oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

            If (oOpenRecordDlg.CurrentView Is Nothing) Then
                Exit Sub
            End If


            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Try

                    Dim intClienteID As Integer

                    If oOpenRecordDlg.pbCodigo = String.Empty Then

                        'intClienteID = oOpenRecordDlg.Record.Item("Código")
                        intClienteID = oOpenRecordDlg.Record.Item("ClienteID")

                    Else

                        intClienteID = CType(oOpenRecordDlg.pbCodigo, Integer)

                    End If

                    oCliente = oCatalogoClientesMgr.CreateAlterno
                    'oCatalogoClientesMgr.LoadInto(oOpenRecordDlg.Record.Item("ClienteID"), oCliente)
                    oCatalogoClientesMgr.Load(intClienteID, oCliente, Me.ebTipoVenta.Value)

                    With oCliente

                        ebClienteCod.Text = .CodigoAlterno
                        ebClienteNombre.Text = .Nombre & " " & .ApellidoPaterno & " " & .ApellidoMaterno

                        ebTipoVenta.Focus()

                    End With

                Catch ex As Exception

                    Exit Sub

                End Try

            End If

        Else

            oCliente = oCatalogoClientesMgr.CreateAlterno
            oCatalogoClientesMgr.Load(ebClienteCod.Text, oCliente, Me.ebTipoVenta.Value)

            '<Validación>

            If (oCliente.CodigoAlterno = 0 OrElse oCliente.CodigoAlterno = String.Empty) Then
                'MessageBox.Show("El Registro no existe.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebClienteCod.Text = String.Empty
                ebClienteNombre.Text = String.Empty

                oCliente.Clear()

                ebClienteCod.Focus()
                Exit Sub

            End If

            '</Validación>

            With oCliente

                ebClienteCod.Text = .CodigoAlterno
                ebClienteNombre.Text = .Nombre & " " & .ApellidoPaterno & " " & .ApellidoMaterno

                ebTipoVenta.Focus()

            End With

        End If


        gridNotaCreditoDetalle.DataSource = Nothing

        oNotasCreditoMgr.CrearTablaTmp(strTablaTmp)

    End Sub



    Private Sub Sm_BuscarPlayers(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        '<Validación>

        'If Not (oNotaCredito Is Nothing) Then

        '    MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
        '    Exit Sub

        'End If

        '</Validación>


        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoVendedoresOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                oPlayer = Nothing
                oPlayer = oCatalogoPlayersMgr.Load(oOpenRecordDlg.Record.Item("CodVendedor"))

                ebPlayerCod.Text = oPlayer.ID
                ebPlayerNombre.Text = oPlayer.Nombre

                Me.ebTipoVenta.Focus()

            End If

        Else

            If (ebPlayerCod.Text.Trim = String.Empty) Then

                'MsgBox("Debe Capturar un Código de Player.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Sub

            End If

            oPlayer = Nothing
            oPlayer = oCatalogoPlayersMgr.Load(ebPlayerCod.Text.Trim)

            '<Validación>

            If (oPlayer Is Nothing) Then

                'MessageBox.Show("El Registro no existe.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebPlayerCod.Text = String.Empty
                ebPlayerNombre.Text = String.Empty

                ebPlayerCod.Focus()

                Exit Sub

            End If

            '</Validación>

            ebPlayerCod.Text = oPlayer.ID
            ebPlayerNombre.Text = oPlayer.Nombre

            Me.ebTipoVenta.Focus()

        End If

    End Sub



    Private Sub Sm_CapturaDetalle()


        '<Validación> 

        If Not (oNotaCredito Is Nothing) Then

            MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If


        If (oCliente Is Nothing) Then

            MsgBox("No ha sido seleccionado un Cliente.", MsgBoxStyle.Exclamation, "DPTienda")
            ebClienteCod.Focus()

            Exit Sub

        End If

        If (ebTipoVenta.Value = "A") And ((ebClienteCod.Text = "1") Or (ebClienteCod.Text = "0")) Then

            MsgBox("Código de Cliente Incorrecto. Verifique. ", MsgBoxStyle.Exclamation, "DPTienda")
            ebClienteCod.Focus()
            Exit Sub

        End If

        'If (ebTipoVenta.Value = "A") Then

        '    'Dim wsAsociado As New wsAsociados.CreditoAsociados

        '    'Dim oAsociado As New AsociadoInfo

        '    'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

        '    '    wsAsociado.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
        '    '                wsAsociado.strURL.TrimStart("/")
        '    'End If

        '    'oAsociado = wsAsociado.GetAsociadoByClienteID(oCliente.CodigoAlterno)

        '    'If (oAsociado.AsociadoID = 0) Then

        '    '    MsgBox("El Cliente no es un Asociado.", MsgBoxStyle.Exclamation, "DPTienda")
        '    '    ebClienteCod.Focus()

        '    '    oAsociado = Nothing

        '    '    Exit Sub

        '    'End If

        '    'oAsociado = Nothing

        'End If



        If (ebTipoVenta.Text = String.Empty) Then

            MsgBox("No ha sido seleccionado un Tipo de Venta.", MsgBoxStyle.Exclamation, "DPTienda")
            ebTipoVenta.Focus()

            Exit Sub

        End If

        '</Validación> 

        Dim ofrmCapturaNotaCredito As New frmCapturaNotaCredito

        With ofrmCapturaNotaCredito

            .NotaCreditoID = 0
            .ClienteID = oCliente.CodigoAlterno
            .TipoVentaID = ebTipoVenta.Value
            .strTablaTmp = strTablaTmp
            If Not oNotaCreditoValida Is Nothing Then
                .Asociado = oNotaCreditoValida.NCAsociado
                .Factura = oNotaCreditoValida.NCFactura
                .DOCFI = oNotaCreditoValida.NCDOCFI
                .DOCSD = oNotaCreditoValida.NCDOCSD
                .E_RESULT = oNotaCreditoValida.NCE_RESULT
                .DetalleNC = oNotaCreditoValida.NCDetalle
                .CambioTallas = Me.CambioTallas
            End If


        End With

        If Not Me.CambioTallas Is Nothing Then

            ofrmCapturaNotaCredito.CambioTallas = Me.CambioTallas

        End If

        ofrmCapturaNotaCredito.ShowDialog()

        oCliente.CodigoAlterno = ofrmCapturaNotaCredito.ClienteID
        '<Validación>
        Me.CambioTallas = ofrmCapturaNotaCredito.CambioTallas

        If ofrmCapturaNotaCredito.FacturaID <> 0 Then
            Me.intFacturaID = ofrmCapturaNotaCredito.FacturaID
        End If


        If (ofrmCapturaNotaCredito.DialogResult <> DialogResult.OK) Then

            AsociadoTipoVenta = String.Empty

            Exit Sub

        Else

            AsociadoTipoVenta = ofrmCapturaNotaCredito.TipoVentaCredito

        End If

        '</Validación>


        dsNotaCreditoDetalle = Nothing
        dsNotaCreditoDetalle = oNotasCreditoMgr.ActualizarDataSet("[NotaCreditoDetalleSelFromTemporal]", strTablaTmp)

        gridNotaCreditoDetalle.DataSource = dsNotaCreditoDetalle.Tables(0)

        If dsNotaCreditoDetalle Is Nothing OrElse dsNotaCreditoDetalle.Tables.Count = 0 OrElse dsNotaCreditoDetalle.Tables(0).Rows.Count = 0 Then
            ebPlayerCod.Enabled = True
            ebTipoVenta.Enabled = True
            ebClienteCod.Enabled = True
        Else
            ebPlayerCod.Enabled = False
            ebTipoVenta.Enabled = False
            ebClienteCod.Enabled = False
        End If

        Sm_CalcularTotales()

        ofrmCapturaNotaCredito.Dispose()
        ofrmCapturaNotaCredito = Nothing

        uibtnGuardar.Focus()

    End Sub


    Private Function Fm_intTotalArticulos(ByVal strStoredProcedure As String) As Integer

        Dim dtNotaCreditoDetalle As DataTable
        Dim drArticulo As DataRow
        Dim intCantidad As Integer


        'dtNotaCreditoDetalle = oNotasCreditoMgr.ActualizarDataSet("[NotaCreditoDetalleSelFromTemporal]", strTablaTmp).Tables(strTablaTmp)

        dtNotaCreditoDetalle = dsNotaCreditoDetalle.Tables(0)

        For Each drArticulo In dtNotaCreditoDetalle.Rows

            intCantidad += CType(drArticulo("Cantidad"), Integer)

        Next

        dtNotaCreditoDetalle = Nothing

        Return intCantidad

    End Function


    Public Sub Sm_ActionPrint()

        Dim oARReporte As New ReporteNotasCredito(Me, oNotaCredito.ClienteID)
        'Dim oReport As NotaCredito
        'Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte Notas de Credito"

        oARReporte.DataSource = oNotaCredito.Detalle.Tables(0)  'oReport.Detalle.Tables(0)
        oARReporte.Document.Name = "Reporte de Ventas en Detalle"
        oARReporte.Run()

        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

        Try

            oARReporte.Document.Print(False, False)

        Catch ex As Exception

            Throw New ApplicationException("Se produjó un error. Nota de Crédito no pudo ser impresa.", ex)

        End Try

    End Sub


    Private Sub Sm_CalcularTotales()

        Dim dtNotaCreditoDetalle As DataTable
        Dim drArticulo As DataRow
        Dim oFactura As Factura
        Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)


        Dim decTotal As Decimal

        dtNotaCreditoDetalle = dsNotaCreditoDetalle.Tables(0)

        For Each drArticulo In dtNotaCreditoDetalle.Rows

            decTotal += CType(drArticulo("Importe"), Decimal)

        Next

        dtNotaCreditoDetalle = Nothing

        ebTotal.Text = Format(decTotal, "Currency")

        oFactura = oFacturaMgr.Create()
        oFacturaMgr.LoadInto(Me.intFacturaID, oFactura)
        If oFactura.FacturaID > 0 Then
            ebSubTotal.Text = Format(decTotal / (1 + (oFactura.IVA * 100 / oFactura.SubTotal) / 100), "Standard")
        Else
            ebSubTotal.Text = Format(decTotal / (1 + oAppContext.ApplicationConfiguration.IVA), "Standard")
        End If

        ebIVA.Text = Format(ebTotal.Text - ebSubTotal.Text, "Standard")

    End Sub



    Private Sub Sm_MostrarInformacion()

        On Error Resume Next

        '<Player>

        oPlayer = Nothing
        oPlayer = oCatalogoPlayersMgr.Load(oNotaCredito.PlayerID)

        ebPlayerCod.Text = oPlayer.ID
        ebPlayerNombre.Text = oPlayer.Nombre

        '</Player>


        '<Sucursal Origen>

        oSucOrigen = Nothing
        oSucOrigen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros(oNotaCredito.AlmacenID)) 'oNotaCredito.AlmacenID)

        ebSucOrigen.Text = oNotaCredito.AlmacenID

        '</Sucursal Origen>


        '<Cliente>
        If oConfigCierreFI.UsarHuellas OrElse oCliente.CodigoAlterno <> "10000000".PadLeft(10, "0") Then
            oCliente = oCatalogoClientesMgr.CreateAlterno
            oCliente.Clear()
            'If oNotaCredito.TipoVentaID = "A" Then
            'oCatalogoClientesMgr.Load(oNotaCredito.ClienteID, oCliente, "I")
            'Else
            oCatalogoClientesMgr.Load(oNotaCredito.ClienteID, oCliente, oNotaCredito.TipoVentaID)
            'If oNotaCredito.TipoVentaID = "P" Then
            '    oCatalogoClientesMgr.LoadPG(oNotaCredito.ClienteID, oCliente)
            'Else
            '    oCatalogoClientesMgr.Load(oNotaCredito.ClienteID, oCliente, oNotaCredito.TipoVentaID)
            'End If
            'End If

            With oCliente
                ebClienteCod.Text = .CodigoAlterno
                ebClienteNombre.Text = .ApellidoPaterno & " " & .ApellidoMaterno & " " & .Nombre
            End With
        End If

        '</Cliente>
        With oNotaCredito

            ebFolio.Text = Format(.NotaCreditoFolio, "000000")

            ebFecha.Text = Format(.Fecha, "dd - MMM - yyyy")

            uicmbTipoDevolucion.Text = .TipoDevolucionID

            If .TipoVentaID = "A" Or .TipoVentaID = "C" Then
                'ebTipoVenta.Text = .TipoVentaID
                ebTipoVenta.Value = "A"
            Else
                ebTipoVenta.Value = .TipoVentaID
            End If

            ebMotivo.Text = .Observaciones

            ebAplicada.Text = .Aplicada

            ebTotal.Text = Format(.Importe, "Currency")

            ebIVA.Text = Format(.IVA, "Standard")

            ebSubTotal.Text = Format(.Importe - .IVA, "Standard")


            dsNotaCreditoDetalle = .Detalle
            gridNotaCreditoDetalle.DataSource = dsNotaCreditoDetalle.Tables(0)

            'GridContratoDetalle.RetrieveStructure()

            ebTotalArticulos.Text = Fm_intTotalArticulos("[NotasCreditoDetalleSel]") 'Falta Parametro

        End With

    End Sub

    Private Function Fm_ValidaDatosDPVale() As String
        Dim dtValores As New DataTable
        Dim oDPVale As cDPVale = New cDPVale
        Dim oRow As DataRow
        Dim oRowDist As DataRow
        Dim DPVale As String
        Dim oDPValeSAP As cDPValeSAP = New cDPValeSAP
        Dim sMessage As String = ""

        Try

            '-------------------------------------------------------------------------------------------------
            ' MLVARGAS (17.07.2018): Obtener el numero del vale del grid de nota de crédito
            '-------------------------------------------------------------------------------------------------
            Dim row As DataRow = dsNotaCreditoDetalle.Tables(0).Rows(0)
            DPVale = row.Item(2)

            oDPVale.INUMVA = (DPVale.Substring(DPVale.IndexOf("-") + 1))
            oDPVale.I_RUTA = "X"


            '-------------------------------------------------------------------------------------------------
            ' JNAVA (07.07.2016): Valida DPVale en S2Credit si esta activo como validador o esta en paralelo
            '-------------------------------------------------------------------------------------------------
            Dim FirmaDistrS2C As Image
            Dim NombreDistrS2C As String = String.Empty
            If oConfigCierreFI.AplicarS2Credit Then
                oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistrS2C, NombreDistrS2C)
            Else
                oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
            End If


            If Not oDPVale Is Nothing Then
                oDPValeSAP.EsCalzado = oDPVale.EsCalzado
                oDPValeSAP.PromocionValeElectronico = oDPVale.PromocionValeElectronico
                oDPValeSAP.InfoDPVALE = oDPVale.InfoDPVALE
                oDPValeSAP.IDDPVale = oDPVale.INUMVA
                oDPValeSAP.Plaza = oDPVale.EPLAZA
                oDPValeSAP.ValeElectronico = oDPVale.EsElectronico

                'rgermain 15.10.2016: Si es S2Credit el saldo disponible esta en la propiedad LimiteCreditoPrestamo
                If oConfigCierreFI.AplicarS2Credit Then
                    oDPValeSAP.LimiteCredito = oDPVale.LimiteCreditoPrestamo
                Else
                    oDPValeSAP.LimiteCredito = oDPVale.LimiteCredito
                End If

                oDPValeSAP.Congelado = oDPVale.Congelado

                Dim oCSAP As ClientesSAP
                oCSAP = GetClienteDPVale(CStr(oDPVale.InfoDPVALE.Rows(0)!CODCT).PadLeft(10, "0"))

                If Not oCSAP Is Nothing Then
                    '-------------------------------------------------------------------------------------------------
                    ' MLVARGAS (18.07.2018): Verificar el tope de crédito del cliente y que no se encuentre bloqueado
                    '-------------------------------------------------------------------------------------------------
                    If oS2Credit.SearchCustomersWithAmount(CStr(oDPVale.InfoDPVALE.Rows(0)!CODCT).PadLeft(10, "0"), Me.ebTotal.Text) = True Then
                        If oCSAP.Status <> 1 Then
                            sMessage = "El cliente esta bloqueado"
                            GoTo Termina
                        End If
                    Else
                        sMessage = "No se encontró el cliente"
                        GoTo Termina
                    End If

                End If

                If oDPVale.EEXIST = "S" Then
                    oRowDist = oDPVale.InfoDPVALE.Rows(0)
                    If oDPValeSAP.LimiteCredito <= 0 Then
                        sMessage = "El Acreditado no tiene saldo disponible"
                        GoTo Termina
                    End If
                    If oDPValeSAP.Congelado = "X" Then
                        sMessage = "El Distribuidor " & CStr(oRowDist.Item("KUNNR")).PadLeft(10, "0") & " esta congelado"
                        GoTo Termina
                    End If
                    If oDPVale.ESTATU <> "A" Then
                        If oDPVale.ESTATU = "E" Then
                            sMessage = "El DPVale está Expirado"
                            GoTo Termina
                        Else
                            If oDPVale.ESTATU = "C" Then
                                sMessage = "El DPVale está cancelado"
                                GoTo Termina
                            Else
                                If oDPVale.ESTATU <> "U" Then
                                    sMessage = "El DPVale no se encuentra disponible"
                                    GoTo Termina
                                End If
                            End If
                        End If
                    End If
                Else
                    sMessage = "El DPVale no existe"
                End If

            End If

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al validar el DPVale en generación de nota de crédito ")
        End Try
Termina:
        Return sMessage
    End Function



    Private Sub Sm_Nuevo()

        ebPlayerCod.Enabled = True
        ebTipoVenta.Enabled = True
        ebClienteCod.Enabled = True

        Me.ebClienteCod.Enabled = False
        ebFolio.Text = CStr(oNotasCreditoMgr.Folios).PadLeft(6, "0")

        bolNCGuardada = False
        Sm_TxtLimpiar()

        'ebFecha.Focus()

        ebSucOrigen.Text = oAppContext.ApplicationConfiguration.Almacen

        oNotasCreditoMgr.CrearTablaTmp(strTablaTmp)

        ebPlayerCod.Focus()

        Me.CambioTallas.Clear()

    End Sub


    


    Private Sub Sm_GuardarNotaCredito(Optional ByVal bolImprimir As Boolean = False)
        Dim bRevale As Boolean = True
        Dim bFacturar As Boolean = True
        Dim PagoCanje As Decimal

        If Not (oNotaCredito Is Nothing) Then

            MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If

        If (Fm_bolTxtValidar() = False) Then

            Exit Sub

        End If


        If (MessageBox.Show("Se encuentra seguro de Guardar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
            Exit Sub

        End If

        '----------------------------------------------------------------------------------------------
        ' MLVARGAS (25.07.2018): Si la venta es con DPVale se obtienen los montos de las formas de pago
        '----------------------------------------------------------------------------------------------
        If ebTipoVenta.Value = "V" Then

            Dim pagoDPVAle As Double = oFacturaMgr.GetMontoPago(Me.intFacturaID, True)
            Dim otrosPagos As Double = oFacturaMgr.GetMontoPago(Me.intFacturaID, False)
            PagoCanje = oNotasCreditoMgr.ExtraerMontoNoCancelado(Me.intFacturaID, "DPPT")
            Dim respuesta As String

            '------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 25/09/2018: Se valida si el total de la nota de crédito es mayor al canje, en caso de que lo sea
            '                       validara el pago dpvale
            '------------------------------------------------------------------------------------------------------------

            'If CDec(ebTotal.Text) > PagoCanje Then
            ' Si el importe del pago con DPVale es mayor a cero se procede a validar el vale
            If (pagoDPVAle > 0) Then
                ' Verificar el vale, en caso de no pasar alguna validación se pregunta si desea realizar el Revale
                respuesta = Fm_ValidaDatosDPVale()
                If respuesta.Length > 0 Then
                    If (MessageBox.Show("Se encontró el siguiente error: " & respuesta & " y no es posible facturar. ¿Desea continuar?", "DPTienda", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                        GoTo FinProceso

                    End If
                    bFacturar = False
                End If
            End If
            'End If
        End If

        oNotaCredito = Nothing
        oNotaCredito = oNotasCreditoMgr.Create

        Dim oFactura As Factura = oFacturaMgr.Create
        oFacturaMgr.LoadInto(Me.intFacturaID, oFactura)

        With oNotaCredito

            .FolioApartado = String.Empty
            .AlmacenID = oAppContext.ApplicationConfiguration.Almacen
            .CajaID = oAppContext.ApplicationConfiguration.NoCaja
            '.PlayerID = oPlayer.ID
            .PlayerID = oFactura.CodVendedor.Trim
            .ClienteID = IIf(ebTipoVenta.Value = "P", "10000000".PadLeft(10, "0"), oCliente.CodigoAlterno)
            .TipoDevolucionID = uicmbTipoDevolucion.Text
            If ebTipoVenta.Value = "P" Then .ClientePGID = oCliente.CodigoAlterno
            If ebTipoVenta.Value = "A" Then
                .TipoVentaID = AsociadoTipoVenta
            Else
                .TipoVentaID = ebTipoVenta.Value
            End If
            .Importe = ebTotal.Text
            .IVA = ebIVA.Text
            .Aplicada = "N"
            .DevDinero = "N"
            .Observaciones = ebMotivo.Text  'String.Empty
            .Usuario = UserLoginName 'oAppContext.Security.CurrentUser.Name
            .Fecha = Date.Today
            .StatusRegistro = True
            .FolioSAP = IIf(Not oFactura Is Nothing, oFactura.FolioSAP, "")
            'este llena la tabla temporal
            .Detalle = oNotasCreditoMgr.ActualizarDataSet("[NotaCreditoDetalleSelFromGRID]", strTablaTmp)

            '-----------------------------------------------------------------------------------------
            ' JNAVA (30.01.2017): Si la referencia viene vacia, la buscamos en base a la factura ID
            '-----------------------------------------------------------------------------------------
            Dim stReferencia As String
            If oFactura.Referencia Is Nothing OrElse oFactura.Referencia.Trim = String.Empty Then
                For Each oRow As DataRow In dsNotaCreditoDetalle.Tables(0).Rows
                    stReferencia = CStr(oRow!FolioSAP)
                    Exit For
                Next
                'stReferencia = oFacturaMgr.ObtenerReferenciaByFacturaID(Me.intFacturaID)
            Else
                stReferencia = oFactura.Referencia
            End If

            .Referencia = stReferencia
            '-----------------------------------------------------------------------------------------

        End With

        Dim intNotaCreditoID As Integer
        Dim frmesp As New FrmEsperar
        'Poner AQUI EL MENSAJE DE QUE SE ESTAN GRABANDO las Notas de Credito
        frmesp.Show()

        Application.DoEvents()
        If Not oNotaCreditoValida Is Nothing Then
            oNotaCredito.NCE_RESULT = oNotaCreditoValida.NCE_RESULT
            oNotaCredito.FIDOCUMENT = oNotaCreditoValida.NCDOCFI
            oNotaCredito.SALESDOCUMENT = oNotaCreditoValida.NCDOCSD
        End If

        '-------------------------------------------------------------------------------------------------
        'JNAVA (19.02.2015): Agregamos nuevo parametro para determinar si es NC de Factura de Si Hay
        '-------------------------------------------------------------------------------------------------
        'JNAVA (10.03.2015): Obtenemos el Pedido ID de la Factura
        '-------------------------------------------------------------------------------------------------
        Dim oFacturaTMP As Factura = oFacturaMgr.Create
        oFacturaMgr.Load(oFactura.FolioFactura, oFactura.CodCaja, oFacturaTMP)
        '-------------------------------------------------------------------------------------------------
        'JNAVA (10.03.2015): Obtenemos el Folio del Pedido de la Factura
        '-------------------------------------------------------------------------------------------------
        Dim oPedido As New Pedidos(oFacturaTMP.PedidoID)

        '---------------------------------------------------------------------------
        ' JNAVA (05.08.2016): Validamos las devoluciones 
        '---------------------------------------------------------------------------
        If oConfigCierreFI.AplicarS2Credit Then
            If ebTipoVenta.Value = "V" Then
                If Not ValidaDevolucionesS2Credit(oFacturaTMP, oPedido) Then
                    Exit Sub
                End If
            End If
        End If
        '---------------------------------------------------------------------------

        Dim strError As String = ""
        oNotaCredito.Save(oConfigCierreFI.UsarHuellas, oPedido.FolioSAP, strError)
        'MsgBox("FolioNotaCredito " & oNotaCredito.NotaCreditoFolio)
        '-------------------------------------------------------------------------------------------------
        ' JNAVA (20.07.2016): Generamos Devolución en S2Credit si esta activa configuracion
        '-------------------------------------------------------------------------------------------------
        If oConfigCierreFI.AplicarS2Credit Then
            If oNotaCredito.TipoVentaID = "V" Then
                GenerarDevolucionS2Credit(oFacturaTMP, oPedido)
            End If
        End If
        '-------------------------------------------------------------------------------------------------

        oPedido = Nothing
        oFacturaTMP = Nothing
        '-------------------------------------------------------------------------------------------------

        Application.DoEvents()

        frmesp.Close()
        '-----------------------------------------------------------------------------------------------------------------
        'Si no regresa folios SAP ya no esta permitido continuar con el guardado temporal 29/03/2012
        '-----------------------------------------------------------------------------------------------------------------
        If oNotaCredito.SALESDOCUMENT.Trim = "" Then
            MessageBox.Show("No fue posible realizar la Nota de Crédito en SAP." & vbCrLf & strError & vbCrLf & "Favor de llamar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '-----------------------------------------------------------------------------------------------------------------
        'Guardamos relacion cliente - devolucion en el servidor PG
        '-----------------------------------------------------------------------------------------------------------------
        'If oConfigCierreFI.UsarHuellas Then
        '    Try
        '        If oNotaCredito.SALESDOCUMENT.Trim <> "" AndAlso oFingerPMgr.SaveClienteDevolucion(oNotaCredito, oFactura.FolioSAP) Then
        oFacturaMgr.ActualizaStatusEnvioServerPG(oNotaCredito.SALESDOCUMENT, 3)
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End If
        '-----------------------------------------------------------------------------------------------------------------
        'Crear Ajuste Automatico
        '-----------------------------------------------------------------------------------------------------------------
        Try
            If oNotaCredito.FIDOCUMENT <> "" AndAlso oNotaCredito.SALESDOCUMENT <> "" Then
                If Me.CambioTallas.Rows.Count <> 0 Then
                    Sm_RealizarAjustes(oNotaCredito.ID)
                End If
            ElseIf Me.CambioTallas.Rows.Count <> 0 Then
                oAjusteMgr.SaveAjustesAutomaticosPendientes(Me.CambioTallas, oNotaCredito.ID)
                'MsgBox("No se realizaron los ajustes automáticos", MsgBoxStyle.Exclamation, "Dportenis Pro")
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "No se realizaron los ajustes automáticos")
            MsgBox("No se realizaron los ajustes automáticos", MsgBoxStyle.Exclamation, "Dportenis PRO")
        End Try
        '-----------------------------------------------------------------------------------------------------------------
        'Limpiamos los datos de la NC pendiente
        '-----------------------------------------------------------------------------------------------------------------
        oNotaCreditoValida = Nothing
        '-----------------------------------------------------------------------------------------------------------------
        'Despues de Grabar que imprima la NC
        '-----------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.MiniPrinter Then
            Try
                Dim oRpt As New ActRptNotaCredito(oNotaCredito, oConfigCierreFI.ImprimirCedula)
                oRpt.Document.Name = "Nota de Credito"
                oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oRpt.DataSource = oNotaCredito.Detalle.Tables(0) 'oFactura.Detalle
                oRpt.Run()
                oRpt.Document.Print(False, False)
            Catch ex As Exception
                EscribeLog(ex.ToString, "Error al imprimir la nota de credito")
            End Try
        Else
            'no se imprime nada
        End If
        'Dim folioValeCaja As String = oNotaCredito.SALESDOCUMENT
        intNotaCreditoID = oNotaCredito.ID
        oNotaCredito = Nothing
        oNotaCredito = oNotasCreditoMgr.Load(intNotaCreditoID)
        'oNotaCredito.SALESDOCUMENT = folioValeCaja
        Sm_MostrarInformacion()

        bolNCGuardada = True
        MessageBox.Show("La información ha sido Guardada " & vbCrLf & strError, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '-----------------------------------------------------------------------------------------------------------------
        'Generamos el Revale de Empleado en caso de existir un vale en la factura origen de la devolución
        '-----------------------------------------------------------------------------------------------------------------

        GenerarRevaleEmpleado(oFactura)
        '-----------------------------------------------------------------------------------------------------------------
        'Generamos el Recupon de Descuento en caso de existir uno en la factura origen de la devolucion
        '-----------------------------------------------------------------------------------------------------------------

        GenerarRecupon(oFactura, oFacturaMgr, oNotaCredito.Detalle.Tables(0))

        '-----------------------------------------------------------------------------------------------------------------
        'Ocurrio un error al validar el vale, se pregunta si desea generar el Revale
        '-----------------------------------------------------------------------------------------------------------------
        If Not bFacturar Then
            If (MessageBox.Show("¿Desea generar el Revale?", "DPTienda", MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                bRevale = False
            End If
        End If

        '-----------------------------------------------------------------------------------------------------------------
        'Generamos el Vale de Caja
        '-----------------------------------------------------------------------------------------------------------------
        If bRevale Then
            GenerarValeDeCaja(oFactura, True, bFacturar)
        End If

        '-----------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 21/04/2015: Validacion de DPCard Puntos
        '-----------------------------------------------------------------------------------------------------------------
        'DPCardPuntosDevolucion(oFactura, oNotaCredito.Detalle)
FinProceso:
        Me.Close()

    End Sub

    Public Sub GenerarValeDeCaja(ByVal oFactura As Factura, ByVal bShow As Boolean, ByVal bFacturar As Boolean)

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
            FrmDistribucionNotaCredito.Facturar = bFacturar
            FrmDistribucionNotaCredito.bShow = bShow
            If oFactura.NoDPCardPuntos.Trim() <> "" Then
                FrmDistribucionNotaCredito.Factura = oFactura
            End If

            If (AsociadoTipoVenta = "D") Then 'Dips Abono Credito Directo

                'Dim oFacturaMgr As New FacturaManager(oAppContext)
                'Dim oFactura As Factura
                oFactura = oFacturaMgr.Create

                '''Sacamos Formas de Pago para ver si tiene forma de Pago CRED (CREDITO)
                Dim dsFormasPago As DataSet
                Dim oFacturaFM As New FacturaFormaPago(oAppContext)
                For Each oRow As DataRow In dsNotaCreditoDetalle.Tables(0).Rows
                    oFacturaMgr.Load(oRow("FolioReferencia"), oRow("CodCaja"), oFactura)
                    dsFormasPago = oFacturaFM.Load(oFactura.FacturaID)
                    Exit For
                Next

                Dim dvFMCred As New DataView(dsFormasPago.Tables(0), "CodFormasPago='CRED'", "FacturaID", DataViewRowState.CurrentRows)

                If dvFMCred.Count = 0 Then
                    GoTo GenerarValeCDT
                End If
                '''Sacamos Formas de Pago para ver si tiene forma de Pago CRED (CREDITO)


                '''Variable para almacenar el monto del Vale de Caja
                Dim decValeCaja As Decimal

                oFactura = oFacturaMgr.Create

                oFacturaFM.Load(oFactura.FacturaID)
                For Each oRow As DataRow In dsNotaCreditoDetalle.Tables(0).Rows
                    oFacturaMgr.Load(oRow("FolioReferencia"), oRow("CodCaja"), oFactura)
                Next

                For Each oRow As DataRow In dsNotaCreditoDetalle.Tables(0).Rows
                    oFacturaMgr.Load(oRow("FolioReferencia"), oRow("CodCaja"), oFactura)
                    If oFactura.Saldo > 0 AndAlso oFactura.Saldo >= oRow("Importe") Then
                        oFactura.Saldo = oFactura.Saldo - oRow("Importe")
                        oFacturaMgr.UpdateSaldo(oFactura)
                    ElseIf oFactura.Saldo > 0 Then
                        decValeCaja += oRow("Importe") - oFactura.Saldo
                        oFactura.Saldo = 0
                        oFacturaMgr.UpdateSaldo(oFactura)
                    Else
                        oFactura.Saldo = oFactura.Saldo - oRow("Importe")
                        oFacturaMgr.UpdateSaldo(oFactura)
                        decValeCaja += oRow("Importe")
                    End If
                Next

                Dim oValeNuevo As ValeCaja
                Dim oValeCajaMgr As New ValeCajaManager(oAppContext)
                If decValeCaja > 0 Then
                    Dim oDistribucionNCMgr As New DistribucionNCManager(oAppContext)

                    'Generamos vale nuevo
                    oValeNuevo = oValeCajaMgr.Create

                    oValeNuevo.CodCliente = oFactura.ClienteId

                    oValeNuevo.DocumentoID = oNotaCredito.ID
                    oValeNuevo.DocumentoImporte = decValeCaja 'oNotaCredito.Importe
                    oValeNuevo.Fecha = Now
                    oValeNuevo.FolioDocumento = oNotaCredito.NotaCreditoFolio
                    oValeNuevo.Importe = decValeCaja
                    oValeNuevo.MontoUtilizado = 0
                    oValeNuevo.Nombre = ebClienteNombre.Text
                    oValeNuevo.StastusRegistro = True
                    oValeNuevo.TipoDocumento = "NC"
                    oValeNuevo.Usuario = oAppContext.Security.CurrentUser.SessionLoginName

                    oValeNuevo.DistribucionDetalle = oDistribucionNCMgr.LoadAnticipoCliente(intAnticipoClienteID, "NC").Detalle
                    oValeNuevo.DistribucionDetalle.Tables("AnticiposClientesDetalle").Rows(0)("MontoCanceladoCDT") = decValeCaja

                    Dim frmValeC As New FrmValeCaja
                    frmValeC.NotaCredito = oNotaCredito

                    ''Saco Facturas Pendientes
                    Dim dsFacturasPendientes As DataSet
                    dsFacturasPendientes = oFacturaMgr.SelectFacturasCDT(oNotaCredito.ClienteID, True)

                    If dsFacturasPendientes.Tables(0).Rows.Count > 0 Then 'Si tiene facturas pendientes no se imprime.
                        frmValeC.FacturasPorLiquidar = True
                        frmValeC.ValeCajaNuevo(oValeNuevo, 0, Me.oNotaCredito.Importe, True)
                    Else 'Y si no tiene si se impreme ¬¬. 
                        frmValeC.FacturasPorLiquidar = True
                        frmValeC.ValeCajaNuevo(oValeNuevo, 0, Me.oNotaCredito.Importe, True)
                    End If
                    ''Saco Facturas Pendientes


                    oValeNuevo.ValeCajaID = frmValeC.intValeCajaID 'Se saca el id del vale de caja generado
                    frmValeC.Dispose()
                    frmValeC = Nothing



                    'TODO: Aaragon Descomentar para la compensación.
                    'MessageBox.Show("El saldo de la Factura es menor a la Devolución, Se generó un Vale de Caja por.- " & Format(decValeCaja, "c"), "Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'If dsFacturasPendientes.Tables(0).Rows.Count > 0 Then
                    '    'TODO: Aaragon Facturas Pendientes.
                    '    Dim ofrmAbonoCeditoDirecto As New frmAbonoCreditoDirectoTienda
                    '    Dim oDistribucionNC As DistribucionNC
                    '    oDistribucionNC = oDistribucionNCMgr.LoadAnticipoCliente(intAnticipoClienteID, "NC")

                    '    Dim dsDevoluciones As New DataSet
                    '    dsDevoluciones = oDistribucionNC.Detalle.Clone()

                    '    For Each row As DataRow In oDistribucionNC.Detalle.Tables("AnticiposClientesDetalle").Rows
                    '        If row("MontoCanceladoCDT") > 0 Then
                    '            dsDevoluciones.Tables("AnticiposClientesDetalle").ImportRow(row)
                    '        End If
                    '    Next

                    '    If MsgBox(" ¿Desea aplicar abono automaticamente?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then

                    '        ofrmAbonoCeditoDirecto.ShowDev(oDistribucionNC.ClienteID, _
                    '                        decValeCaja, oValeNuevo.ValeCajaID, True)

                    '    Else
                    '        ofrmAbonoCeditoDirecto.ShowDev(oDistribucionNC.ClienteID, decValeCaja, oValeNuevo.ValeCajaID)
                    '    End If
                    'End If


                End If

            Else

GenerarValeCDT:

                FrmDistribucionNotaCredito.FacturasPorLiquidar = False
                FrmDistribucionNotaCredito.ShowDialog()

            End If

            FrmDistribucionNotaCredito.Dispose()
            FrmDistribucionNotaCredito = Nothing
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al generar el Vale de Caja")
        End Try

    End Sub

    Private Sub GenerarRevaleEmpleado(ByVal oFactura As Factura)
        Try
1:          Dim oReValeE As ValeEmpleado
2:          Dim oValeEmpOrig As ValeEmpleado
            Dim referencia As String = ""

3:          If Me.ebTipoVenta.Value = "E" Then
4:              If oFactura.PedidoID <> 0 Then
                    oValeEmpOrig = oFacturaMgr.GetValeEmpleadoByPedido(oFactura.PedidoID)
                    Dim pedido As New Pedidos(oFactura.PedidoID)
                    referencia = pedido.FolioSAP
                Else
                    oValeEmpOrig = oFacturaMgr.GetValeEmpleado(oFactura.FacturaID)
                    referencia = oFactura.Referencia
                End If
5:              If Not oValeEmpOrig Is Nothing Then
6:                  oValeEmpOrig = oSAPMgr.ZBAPI_VALIDA_VALE_EMPLEADO(oValeEmpOrig)
7:                  If oValeEmpOrig.EsRevale = False AndAlso oSAPMgr.ZBAPI_GENERA_REVALE_EMPLEADO(referencia, oReValeE).Trim = "" Then
8:                      oReValeE = oSAPMgr.ZBAPI_VALIDA_VALE_EMPLEADO(oReValeE)
9:                      If oConfigCierreFI.MiniPrinter Then
10:                         Dim oRpt As New rptRevaleEmpleado(oReValeE.Folio, oReValeE.Serie, oReValeE.Descuento)
11:                         oRpt.Document.Name = "ReVale de Descuento"
12:                         oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
13:                         oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
14:                         oRpt.Run()
15:                         oRpt.Document.Print(False, False)
                            'Dim oFrm As New ReportViewerForm
                            'oFrm.Report = oRpt
                            'oFrm.Show()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al generar el revale de Empleado. Linea " & Err.Erl)
        End Try
    End Sub

    Private Sub GenerarRecupon(ByVal oFactura As Factura, ByVal oFacturaMgr As FacturaManager, ByVal dtDetalleDev As DataTable)

        Dim oReCupon As CuponDescuento
        Dim strFolioCupon As String = ""
        Dim dsDetalle As DataSet
        Dim Descuento As Decimal = 0
        Dim Minimo As Decimal = 0
        Dim strNombre As String = ""
        Dim oFacturaDetMgr As New FacturaCorridaManager(oAppContext)

        strFolioCupon = oFacturaMgr.GetCuponDescuento(oFactura.FacturaID)
        If strFolioCupon.Trim <> "" Then

            dsDetalle = oFacturaDetMgr.Load(oFactura.FacturaID)
            GetDescuentoCodigos(Descuento, Minimo, dsDetalle.Tables(0), dtDetalleDev, oFactura.CodTipoVenta)
            RestService.Metodo = "/pos/cupones"
            Dim result As New Dictionary(Of String, Object)
            result = RestService.SapZcupDevYRecupon(oReCupon, oNotaCredito.SALESDOCUMENT.Trim(), strFolioCupon, Descuento, Minimo)
            If Descuento > 0 AndAlso CStr(result("SapZcupDevYRecupon")("E_RESULTADO")) = "1" Then
                oFacturaMgr.SaveReCuponDescuento(oReCupon.Folio, strFolioCupon, oNotaCredito.ID)
                If oConfigCierreFI.MiniPrinter Then
                    If CLng(Me.ebClienteCod.Text) <> 10000000 AndAlso CLng(Me.ebClienteCod.Text) <> 99999 Then strNombre = Me.ebClienteNombre.Text.Trim
                    Dim oRpt As New rptReCupon(oReCupon.Folio, oReCupon.Minimo, Descuento, oReCupon.FechaVigencia, strNombre)
                    oRpt.Document.Name = "ReCupon de Descuento"
                    oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oRpt.Run()
                    oRpt.Document.Print(False, False)
                    'Dim oFrm As New ReportViewerForm
                    'oFrm.Report = oRpt
                    'oFrm.Show()
                End If
            End If
            'If Descuento > 0 AndAlso oSAPMgr.ZBAPI_GENERA_RECUPON(oReCupon, oNotaCredito.SALESDOCUMENT.Trim, strFolioCupon, Descuento, Minimo).Trim = "1" Then
            '    oFacturaMgr.SaveReCuponDescuento(oReCupon.Folio, strFolioCupon, oNotaCredito.ID)
            '    If oConfigCierreFI.MiniPrinter Then
            '        If CLng(Me.ebClienteCod.Text) <> 1 AndAlso CLng(Me.ebClienteCod.Text) <> 99999 Then strNombre = Me.ebClienteNombre.Text.Trim
            '        Dim oRpt As New rptReCupon(oReCupon.Folio, oReCupon.Minimo, Descuento, oReCupon.FechaVigencia, strNombre)
            '        oRpt.Document.Name = "ReCupon de Descuento"
            '        oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
            '        oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
            '        oRpt.Run()
            '        oRpt.Document.Print(False, False)
            '        'Dim oFrm As New ReportViewerForm
            '        'oFrm.Report = oRpt
            '        'oFrm.Show()
            '    End If
            'End If
        End If

        oFacturaDetMgr = Nothing

    End Sub

    Private Sub GetDescuentoCodigos(ByRef Descuento As Decimal, ByRef Minimo As Decimal, ByVal dtDetFact As DataTable, ByVal dtDetDev As DataTable, ByVal CodTipoVenta As String)

        Dim oRowD As DataRow
        Dim oRowF As DataRow
        Dim vDescSis As Decimal = 0
        Dim vDescAdi As Decimal = 0

        For Each oRowD In dtDetDev.Rows
            For Each oRowF In dtDetFact.Rows
                If CStr(oRowD!CodArticulo).Trim.ToUpper = CStr(oRowF!CodArticulo).Trim.ToUpper _
                AndAlso CStr(oRowD!Numero).Trim.ToUpper = CStr(oRowF!Numero).Trim.ToUpper Then
                    vDescSis = CDec(oRowF!CantDescuentoSistema) / CInt(oRowF!Cantidad)
                    vDescAdi = (CDec(oRowF!PrecioOferta) - vDescSis) * (CDec(oRowF!Descuento) / 100)
                    Descuento += vDescAdi * CInt(oRowD!Cantidad)
                    If vDescAdi > 0 Then
                        Minimo += (CDec(oRowF!PrecioOferta) - vDescSis) * CInt(oRowD!Cantidad)
                    End If
                End If
            Next
        Next

        Descuento = Descuento * (1 + oAppContext.ApplicationConfiguration.IVA)
        Minimo = Minimo * (1 + oAppContext.ApplicationConfiguration.IVA)

    End Sub

    Public Sub Sm_RealizarAjustes(ByVal NotaCreditoID As Integer)

        Dim FacturaSAP As String

        oAjuste = oAjusteMgr.Create
        Me.oAjuste.FolioAjuste = oAjusteMgr.GetFolio
        Me.oAjuste.Almacen = oAppContext.ApplicationConfiguration.Almacen
        Me.oAjuste.Observaciones = "Ajuste Automático por Devolución"
        For Each oRow As DataRow In Me.CambioTallas.Rows

            Dim oNewRow As DataRow = oAjuste.Detalle.NewRow

            oNewRow("Codigo") = oRow("CodArticulo")
            oNewRow("Descripcion") = oRow("Descripcion")
            oNewRow("TallaS") = oRow("TallaFactura")
            oNewRow("TallaE") = oRow("TallaReal")
            oNewRow("Cantidad") = oRow("Cantidad")
            oNewRow("Reversa") = 1
            oNewRow("Tipo") = "AA"
            oNewRow("CantDevuelta") = oRow("Cantidad")
            FacturaSAP = oRow("FacturaSAP")

            Me.oAjuste.Detalle.Rows.Add(oNewRow)

        Next

        'Para que llene en todos los registros el folio SAP
        For Each oRow As DataRow In oAjuste.Detalle.Rows
            oAjuste.Codigo = oRow!codigo
            oAjuste.Cantidad = oRow!cantidad
            oAjuste.Talla_S = oRow!TallaS
            oAjuste.Talla_E = oRow!TallaE
            '------------------------------------
            oSAPMgr.Write_AJUSTETalla(oAjuste)
            '------------------------------------
            oRow!foliosap = oAjuste.FolioSAP
        Next
        'Para ver que se haya grabado por lo menos un ajuste en SAP
        oAjuste.TotalCodigos = 0
        For Each oRow As DataRow In oAjuste.Detalle.Rows
            If oRow!foliosap <> String.Empty Then
                oAjuste.TotalCodigos += 1
            End If
        Next
        '------------------------------------------------------
        If oAjuste.TotalCodigos <> 0 Then
            Dim oGrdRow As Janus.Windows.GridEX.GridEXRow
            Me.oAjuste.Usuario = oAppContext.ApplicationConfiguration.Usuario
            Me.oAjuste.FolioFacturaSAP = FacturaSAP.PadLeft(10, "0")
            Me.oAjusteMgr.Save(Me.oAjuste, NotaCreditoID)
            Me.oAjusteMgr.PutMovimiento(Me.oAjuste, "E")
            Me.oAjusteMgr.PutMovimiento(Me.oAjuste, "S")
        Else
            MessageBox.Show("Ningun Ajuste se Guardo en SAP", "Ajustes Talla", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Sm_AbrirNotaCredito()

        Dim oOpenRecordDlg As New OpenRecordDialog


        oOpenRecordDlg.CurrentView = New NotaCreditoOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            On Error Resume Next

            oNotaCredito = Nothing
            oNotaCredito = oNotasCreditoMgr.Load(oOpenRecordDlg.Record.Item("NotaCreditoID"))

            AddColumnoNotaCredito()

            For Each oRow As DataRow In oNotaCredito.Detalle.Tables(0).Rows
                Dim dsFSAP As DataSet = oNotasCreditoMgr.GetFolioSAP(oRow.Item("CodCaja"), oRow.Item("FolioReferencia"))
                If dsFSAP.Tables(0).Rows.Count > 0 Then
                    oRow.Item("FolioSAP") = dsFSAP.Tables(0).Rows(0).Item("FolioSAP")
                End If
                dsFSAP = Nothing
            Next

            oNotaCredito.Detalle.Tables(0).AcceptChanges()


            Sm_MostrarInformacion()

        End If

    End Sub

    Private Sub AddColumnoNotaCredito()
        Dim dcFolioSAP As New DataColumn
        With dcFolioSAP
            .ColumnName = "FolioSAP"
            .Caption = "Folio SAP"
            .DataType = GetType(String)
            .DefaultValue = ""
        End With
        oNotaCredito.Detalle.Tables(0).Columns.Add(dcFolioSAP)
        oNotaCredito.Detalle.Tables(0).AcceptChanges()

    End Sub

#End Region



#Region "Métodos Privados [Eventos]"


    Private Sub frmModCapNotCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()

        'If oConfigCierreFI.UsarHuellas = False Then

        '    Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Visible = Janus.Windows.UI.InheritableBoolean.False

        'Else

        '    Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False

        'End If

        ''Validamos si existen notas de credito que se guardaron en SAP pero en DP PRO no!
        'Dim strDatos As String
        'Dim strDatosA() As String
        'Dim dt As DataTable


        'strDatos = Me.oNotasCreditoMgr.GetDatosNCSAP("T" & oAppContext.ApplicationConfiguration.Almacen & _
        'oAppContext.ApplicationConfiguration.NoCaja & _
        'CStr(oNotasCreditoMgr.GetSelectNCByCaja(oAppContext.ApplicationConfiguration.NoCaja)) _
        ', dt)

        'strDatosA = strDatos.Split("/")

        'If strDatosA(4) = "Y" Then

        '    oNotaCreditoValida = Nothing
        '    oNotaCreditoValida = oNotasCreditoMgr.Create

        '    oNotaCreditoValida.NCAsociado = strDatosA(0).Trim
        '    oNotaCreditoValida.NCFactura = strDatosA(1).Trim
        '    oNotaCreditoValida.NCDOCFI = strDatosA(2).Trim
        '    oNotaCreditoValida.NCDOCSD = strDatosA(3).Trim
        '    oNotaCreditoValida.NCE_RESULT = strDatosA(4).Trim
        '    oNotaCreditoValida.NCDetalle = dt

        '    Dim oform As New frmNCMSG(strDatosA(1), strDatosA(0), dt)
        '    oform.ShowDialog()

        'End If


    End Sub



    Private Sub frmModCapNotCredito_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Sm_Finalizar()

    End Sub



    Private Sub frmModCapNotCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter    'Tabulador.

                SendKeys.Send("{TAB}")


            Case Keys.F2     'Grabar.
                'MsgBox("Guardar", MsgBoxStyle.Exclamation, "DPTienda")
                Sm_GuardarNotaCredito()

            Case Keys.F9     'Grabar e Imprimir.

                'Sm_GuardarNotaCredito(True)

                'Sm_ActionPrint()

            Case Keys.Escape

                bolSalir = True

                Me.Close()

        End Select



    End Sub


    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case (e.Command.Key)

            Case "menuArchivoNuevo"

                Sm_Nuevo()


            Case "menuArchivoGuardar"

                Sm_GuardarNotaCredito()


            Case "menuArchivoAbrir"

                Sm_AbrirNotaCredito()

            Case "MnuReimprimirNotaCredito"

                'ReimprimirNotaCredito()
                RePrintNotaCredito()

            Case "menuSalir"

                Me.Close()

        End Select

    End Sub


    Private Sub uibtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnNuevo.Click

        Sm_Nuevo()

    End Sub



    Private Sub uibtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnGuardar.Click

        Sm_GuardarNotaCredito()

        'Sm_ActionPrint()

    End Sub



    Private Sub ebClienteCod_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebClienteCod.ButtonClick

        If Me.ebTipoVenta.Text = String.Empty Then
            MessageBox.Show("Seleccione el tipo de cliente", "DPortenis Pro", MessageBoxButtons.OK)
            Exit Sub
        End If

        If oConfigCierreFI.UsarDescargaClientes Then
            LoadSearchForm()
        Else
            LoadSearchFormClientesSAP()
        End If

        'Sm_BuscarClientes(True)

    End Sub



    Private Sub ebClienteCod_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebClienteCod.KeyDown

        If bolSalir = True Then
            Exit Sub
        End If

        If Me.ebTipoVenta.Text = String.Empty Then
            MessageBox.Show("Seleccione el tipo de cliente", "DPortenis Pro", MessageBoxButtons.OK)
            Exit Sub
        End If

        If e.Alt And e.KeyCode = Keys.S Then

            If oConfigCierreFI.UsarDescargaClientes Then
                LoadSearchForm()
            Else
                LoadSearchFormClientesSAP()
            End If


            'ElseIf e.KeyCode = Keys.Enter Then

            'If (ebClienteCod.Text <> 1) Then

            '    Valida()

            '    If (oCliente.CodigoAlterno = String.Empty) Then

            '        MsgBox("El Cliente no es Valido.", MsgBoxStyle.Exclamation, "DPTienda")
            '        Me.ebClienteCod.Focus()

            '    End If

            '    Me.ebClienteCod.Text = oCliente.CodigoAlterno
            '    Me.ebClienteNombre.Text = oCliente.NombreCompleto

            'Else

            '    oCliente = oCatalogoClientesMgr.CreateAlterno
            '    oCliente.CodigoAlterno = 1
            '    oCliente.Nombre = "PUBLICO GENERAL"
            '    ebClienteCod.Text = oCliente.CodigoAlterno
            '    ebClienteNombre.Text = oCliente.Nombre

            'End If

        End If

    End Sub

    Private Sub ebClienteCod_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebClienteCod.Validating

        If (bolSalir = True) Then
            Return
        End If

        If (ebClienteCod.Text.Trim = String.Empty) OrElse CLng(Me.ebClienteCod.Text.Trim) = 0 Then
            'If (ebClienteCod.Text.Trim = String.Empty) Or (ebClienteCod.Text = 0) Then
            If ebTipoVenta.Value = "P" AndAlso oConfigCierreFI.UsarHuellas Then
                'ebClienteCod.Text = "0".PadLeft(10, "0")
                oCliente = oCatalogoClientesMgr.CreateAlterno
                oCliente.CodigoAlterno = 0
                oCliente.Nombre = "PUBLICO GENERAL"
                ebClienteCod.Text = oCliente.CodigoAlterno
                ebClienteNombre.Text = oCliente.Nombre
            Else
                ebClienteCod.Focus()
                Return
            End If
        End If

        If (ebClienteCod.Text > 0) Then

            If oConfigCierreFI.UsarHuellas OrElse (CLng(ebClienteCod.Text) <> 10000000) Then

                'Sm_BuscarClientes()
                Valida()
            Else

                If ebTipoVenta.DropDownList.GetValue("CodTipoVentA") <> "P" Then
                    MessageBox.Show("Tipo de cliente incorrecto", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                End If

                oCliente = oCatalogoClientesMgr.CreateAlterno
                oCliente.CodigoAlterno = 1
                oCliente.Nombre = "PUBLICO GENERAL"
                ebClienteCod.Text = oCliente.CodigoAlterno
                ebClienteNombre.Text = oCliente.Nombre

            End If

        ElseIf oConfigCierreFI.UsarHuellas = False OrElse ebTipoVenta.Value <> "P" Then

            MsgBox("No ha capturado un Cliente.", MsgBoxStyle.Exclamation, "DPTienda")
            e.Cancel = True

        End If

    End Sub

    Private Sub ebPlayerCod_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebPlayerCod.ButtonClick

        Sm_BuscarPlayers(True)

    End Sub



    Private Sub ebPlayerCod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebPlayerCod.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarPlayers(True)

        End If

    End Sub



    Private Sub ebPlayerCod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebPlayerCod.Validating

        If (bolSalir = True) Then

            Return

        End If


        If (ebPlayerCod.Text.Trim = String.Empty) Then

            'e.Cancel = True
            ebPlayerCod.Focus()
            Return

        End If


        If (ebPlayerCod.Text.Trim <> String.Empty) Then

            Sm_BuscarPlayers()

            If (oPlayer Is Nothing) Then

                MsgBox("El Player no es Valido.", MsgBoxStyle.Exclamation, "DPTienda")
                e.Cancel = True

            End If

        Else

            MsgBox("No ha capturado un Player.", MsgBoxStyle.Exclamation, "DPTienda")
            e.Cancel = True

        End If

    End Sub



    Private Sub uibtnCapturaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnCapturaDetalle.Click

        Sm_CapturaDetalle()
        SetupView()
    End Sub



    Private Sub ebTipoVenta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        gridNotaCreditoDetalle.DataSource = Nothing

        oNotasCreditoMgr.CrearTablaTmp(strTablaTmp)

    End Sub



    Private Sub ebTipoVenta_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

        If (bolSalir = True) Then

            Return

        End If


        If (ebTipoVenta.Text.Trim = String.Empty) Then

            ebTipoVenta.Focus()
            Return

        End If


        If (ebTipoVenta.Text.Trim = String.Empty) Then

            MsgBox("No se ha capturado un Tipo de Venta.", MsgBoxStyle.Exclamation, "DPTienda")
            e.Cancel = True

        End If

    End Sub



    Private Sub uicmbTipoDevolucion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles uicmbTipoDevolucion.Validating

        If (bolSalir = True) Then
            Return
        End If


        If (uicmbTipoDevolucion.Text.Trim = String.Empty) Then

            uicmbTipoDevolucion.Focus()
            Return

        End If


        If (uicmbTipoDevolucion.Text.Trim = String.Empty) Then

            MsgBox("No se ha capturado un Tipo de Devolución.", MsgBoxStyle.Exclamation, "DPTienda")
            e.Cancel = True

        End If

    End Sub



    Private Sub ebMotivo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebMotivo.Validating

        If (bolSalir = True) Then
            Return
        End If


        If (ebMotivo.Text.Trim = String.Empty) Then

            ebMotivo.Focus()
            Return

        End If


        If (ebMotivo.Text.Trim = String.Empty) Then

            MsgBox("No se ha capturado un Mótivo.", MsgBoxStyle.Exclamation, "DPTienda")
            e.Cancel = True

        End If

    End Sub

#End Region


#Region "Cliente Alterno"

    Private Sub LoadSearchFormClientesSAP()

        Dim oOpenRecordDlg As OpenFROMSAPRecordDialogClientes

        oOpenRecordDlg = New OpenFROMSAPRecordDialogClientes
        oOpenRecordDlg.TipoVenta = Me.ebTipoVenta.Value
        oOpenRecordDlg.CurrentView = New ClientesFromSAPOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If


        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Try

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    Me.ebClienteCod.Text = oOpenRecordDlg.Record.Item("KUNNR")
                    Me.ebClienteNombre.Text = oOpenRecordDlg.Record.Item("NAME1")

                Else

                    Me.ebClienteCod.Text = CType(oOpenRecordDlg.pbCodigo, String)
                    Me.ebClienteNombre.Text = CType(oOpenRecordDlg.pbNombre, String)

                End If
                GetCliente(Me.ebClienteCod.Text, Me.ebTipoVenta.Value)
                oCatalogoClientesMgr.Load(Me.ebClienteCod.Text, oCliente, Me.ebTipoVenta.Value)

            Catch ex As Exception

                Throw New ApplicationException("[LoadSearchForm]", ex)

            End Try

        End If

    End Sub

    Private Sub LoadSearchForm()

        Dim oOpenRecordDlg As OpenRecordDialogClientes

        Dim strTipoVenta As String = Me.ebTipoVenta.Value
        oCliente = Me.oCatalogoClientesMgr.CreateAlterno
        oCliente.TipoVenta = strTipoVenta
        oOpenRecordDlg = New OpenRecordDialogClientes
        oOpenRecordDlg.GrupoDeCuentas = oCliente.TipoVenta
        oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If


        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oCliente.Clear()

            Try

                Dim intClienteID As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    intClienteID = oOpenRecordDlg.Record.Item("CodigoAlterno")

                Else

                    intClienteID = CType(oOpenRecordDlg.pbCodigo, String)

                End If

                Me.oCatalogoClientesMgr.Load(intClienteID, oCliente, strTipoVenta)

                Me.ebClienteCod.Text = oCliente.CodigoAlterno
                Me.ebClienteNombre.Text = oCliente.NombreCompleto

            Catch ex As Exception

                Throw ex

            End Try

        End If

    End Sub

    Private Sub Valida()

        If (Me.ebClienteCod.Text <> String.Empty) Then
            Dim myID As String = Me.ebClienteCod.Text.Trim
            'Dim strTipoVenta As String = oCatalogoClientesMgr.GetTipoVenta(myID)
            Dim strTipoVenta As String = Me.ebTipoVenta.Value

            'If oConfigCierreFI.UsarDescargaClientes = False Then
            '    GetCliente(myID)
            'End If
            'oCliente.Clear()
            'Me.oCatalogoClientesMgr.Load(myID, oCliente, strTipoVenta)

            oCliente.Clear()
            If oConfigCierreFI.UsarHuellas AndAlso strTipoVenta.Trim = "P" Then
                GetClientePG(myID)
                oCatalogoClientesMgr.LoadPG(IIf(IsNumeric(myID), CInt(myID), 0), oCliente)
                oCliente.TipoVenta = strTipoVenta
            Else
                If oConfigCierreFI.UsarDescargaClientes = False Then GetCliente(myID, strTipoVenta)
                oCatalogoClientesMgr.Load(myID, oCliente, Me.ebTipoVenta.Value)
            End If

            If (oCliente.CodigoAlterno = String.Empty Or oCliente.CodigoAlterno = "0".PadLeft(10, "0")) Then
                Me.ebClienteNombre.Text = ""
                Me.ebClienteCod.Text = ""
                MsgBox("El Cliente no es Valido.", MsgBoxStyle.Exclamation, "DPTienda")
                ebClienteCod.Focus()
                'e.Cancel = True
                'ElseIf Me.ebTipoVenta.Value <> "E" Then ' AndAlso InStr(oFacturaMgr.ValidaTipoVentaCliente(oCliente.CodigoAlterno), Me.ebTipoVenta.Value) <= 0 Then
                '    MsgBox("El Cliente " & myID & " no pertenece al tipo de venta seleccionado.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Dportenis Pro")
                '    ebClienteNombre.Text = ""
                '    ebClienteCod.Text = ""
                '    ebClienteCod.Focus()
            Else
                Me.ebClienteCod.Text = oCliente.CodigoAlterno
                Me.ebClienteNombre.Text = oCliente.NombreCompleto
            End If

            'Else
            '    If ebClienteCod.Text <= 0 Then
            '        ebClienteCod.Text = oCliente.CodigoAlterno
            '    End If
        End If

    End Sub

#End Region

    Private Sub ebTipoVenta_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTipoVenta.Validating
        If bolSalir = True Then
            Exit Sub
        End If

        If Me.ebTipoVenta.Text = String.Empty Then
            Me.ebClienteCod.Enabled = False
            e.Cancel = True
            'ElseIf ebTipoVenta.DropDownList.GetValue("CodTipoVentA") = "P" OrElse ebTipoVenta.DropDownList.GetValue("CodTipoVentA") = "V" Then
        ElseIf ebTipoVenta.Value = "V" OrElse (ebTipoVenta.Value = "P") Then
            Me.ebClienteCod.Enabled = False
            Me.ebClienteCod.Text = "10000000".PadLeft(10, "0")
            Me.ebClienteNombre.Text = "PUBLICO EN GENERAL"

            oCliente = oCatalogoClientesMgr.CreateAlterno
            oCliente.CodigoAlterno = "10000000".PadLeft(10, "0").PadLeft(10, "0")
            oCliente.Nombre = "PUBLICO EN GENERAL"
        ElseIf ebTipoVenta.Value = "E" Then

            Me.ebClienteCod.Enabled = False
            Me.ebClienteCod.Text = "10000000".PadLeft(10, "0")
            'oCliente = oCatalogoClientesMgr.CreateAlterno
            'oCliente.CodigoAlterno = "10000000".PadLeft(10, "0").PadLeft(10, "0")
            'GetCliente(Me.ebClienteCod.Text, "D")
            'Valida()

            Me.ebClienteNombre.Text = oCliente.NombreCompleto.ToUpper
            Me.uicmbTipoDevolucion.Focus()

            'ElseIf ebTipoVenta.DropDownList.GetValue("CodTipoVenta") = "O" Then
            '    Me.ebClienteCod.Enabled = False
            '    Me.ebClienteCod.Text = "10000016".PadLeft(10, "0")
            '    Me.ebClienteNombre.Text = "FACILITO"
            '    'oCliente = oCatalogoClientesMgr.CreateAlterno
            '    'oCliente.CodigoAlterno = "10000016".PadLeft(10, "0").PadLeft(10, "0")
            '    Me.ebClienteNombre.Focus()
            'ElseIf ebTipoVenta.DropDownList.GetValue("CodTipoVenta") = "K" Then
            '    Me.ebClienteCod.Enabled = False
            '    Me.ebClienteCod.Text = "10000017".PadLeft(10, "0")
            '    Me.ebClienteNombre.Text = "TARJETA FONACOT"
            '    Me.ebClienteNombre.Focus()
            'ElseIf ebTipoVenta.DropDownList.GetValue("CodTipoVenta") = "A" Then
            '    Me.ebClienteCod.Enabled = False
            '    Me.ebClienteCod.Text = "10000015".PadLeft(10, "0")
            '    Me.ebClienteNombre.Text = "APARTADO"
            '    'oCliente = oCatalogoClientesMgr.CreateAlterno
            '    'oCliente.CodigoAlterno = "10000015".PadLeft(10, "0").PadLeft(10, "0")
            '    Me.ebClienteNombre.Focus()
        Else
            Me.ebClienteCod.Enabled = True
            Me.ebClienteCod.Text = String.Empty
            Me.ebClienteNombre.Text = String.Empty
            Me.ebClienteNombre.Focus()
        End If
    End Sub

    Public Sub SetupView()

        Dim oCurrentRow As GridEXRow

        Dim odrDataRow As DataRowView

        Dim odrFiltro() As DataRow

        Dim oArticulo As Articulo



        With gridNotaCreditoDetalle.Tables(0)

            .Columns("Fecha").FormatString = "dd - MMM - yyyy"

        End With

        If Not gridNotaCreditoDetalle.GetRow Is Nothing Then

            oCurrentRow = gridNotaCreditoDetalle.GetRow()

            odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

            oArticulo = Nothing
            oArticulo = oCatalogoArticulosMgr.Load(odrDataRow.Item("CodArticulo"))

            ebArticuloDesc.Text = oArticulo.Descripcion

            'If oArticulo.CodCorrida = "ACC" Or oArticulo.CodCorrida = "TEX" Then
            '    Me.lblTallaInicio.Text = "XS"
            '    Me.lblTallaFin.Text = "U"
            'Else
            '    odrFiltro = dsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & oArticulo.CodCorrida & "'")
            '    If InStr(1, CStr(odrFiltro(0).Item("NumInicio")), ".5", CompareMethod.Text) <> 0 Then
            '        lblTallaInicio.Text = odrFiltro(0).Item("NumInicio")
            '    Else
            '        lblTallaInicio.Text = CInt(odrFiltro(0).Item("NumInicio"))
            '    End If

            '    If InStr(1, CStr(odrFiltro(0).Item("NumFin")), ".5", CompareMethod.Text) <> 0 Then
            '        lblTallaFin.Text = odrFiltro(0).Item("NumFin")
            '    Else
            '        lblTallaFin.Text = CInt(odrFiltro(0).Item("NumFin"))
            '    End If
            'End If

            ebTotalArticulos.Text = Fm_intTotalArticulos("[NotaCreditoDetalleSelFromTemporal]")

            oCurrentRow = Nothing
            odrDataRow = Nothing
            odrFiltro = Nothing
        End If

    End Sub

    Private Sub gridNotaCreditoDetalle_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridNotaCreditoDetalle.SelectionChanged

        SetupView()

    End Sub

    Private Sub ebClienteCod_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteCod.LostFocus

        If bolSalir = False Then

            'If oConfigCierreFI.UsarHuellas = True AndAlso Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.True Then
            '    Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False
            'End If

        End If

    End Sub

    Private Sub ebClienteCod_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteCod.GotFocus

        If oConfigCierreFI.UsarHuellas = True AndAlso Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False Then
            Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.True
        End If

    End Sub

    Private Sub frmModCapNotCredito_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        bolSalir = True
        If bolNCGuardada = False AndAlso Not Me.CambioTallas Is Nothing Then

            For Each oRow As DataRow In Me.CambioTallas.Rows

                oNotasCreditoMgr.DesmarcarReversa_AjustarCantDevuelta(oRow!FoliosAjustes)

            Next

        End If

    End Sub

#Region "DPCard Puntos"

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/04/2015: Devolucion DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub DPCardPuntosDevolucion(ByVal factura As Factura, ByVal dsNotaCreditoDetalle As DataSet, Optional ByRef impDev As Decimal = 0)
        If oConfigCierreFI.DPCardPuntos = True Then
            '----------------------------------------------------------------------------------------------------
            ' JNAVA (24.05.2015): Si es devolucion por canje de puntos, no se ejecuta la transaccion de blue.
            '----------------------------------------------------------------------------------------------------
            'If factura.CodDPCardPunto = "CAN" Then
            '    Exit Sub
            'End If
            '----------------------------------------------------------------------------------------------------
            If factura.NoDPCardPuntos <> "" Then
                Dim fecha As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
                Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
                Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create
                Dim Provider As Integer
                Dim CardId As String = ""
                If factura.NoDPCardPuntos.Trim().Length = 16 Then
                    '06/04/2021 validamos que este activo el nuevo servicio de blue
                    If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                        Dim bin As Integer = CInt(factura.NoDPCardPuntos.Trim().Substring(0, 6))
                        If oFacturaMgr.IsDPCardPuntosKarum(bin) Then
                            Provider = Proveedor.KARUM
                        Else
                            Provider = Proveedor.BLUE
                        End If
                    Else
                        Provider = Proveedor.BLUE
                    End If

                    CardId = factura.NoDPCardPuntos
                Else
                    Provider = Proveedor.KARUM
                    CardId = factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
                    'factura.NoDPCardPuntos = factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
                End If
                'Dim bin As Integer = CInt(CStr(factura.NoDPCardPuntos).Substring(0, 6))
                'If oFacturaMgr.IsDPCardPuntosKarum(bin) Then
                '    Provider = Proveedor.KARUM
                'Else
                '    Provider = Proveedor.BLUE
                'End If
                oVendedor.ClearFields()
                oVendedoresMgr.LoadInto(ebPlayerCod.Text.Trim(), oVendedor)
                Dim formasPago As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.FacturaFormaPago(oAppContext)
                Dim dsFormasPago As DataSet
                If factura.PedidoID = 0 Then
                    dsFormasPago = formasPago.Load(factura.FacturaID)
                Else
                    dsFormasPago = formasPago.LoadByPedidoID(factura.PedidoID)
                End If
                Dim rows() As DataRow = dsFormasPago.Tables(0).Select("CodFormasPago='DPPT'")
                '----------------------------------------------------------------------------------------------------
                ' JNAVA (24.05.2015): Se comenta validacion de canje por que ya no aplica ejecutar la transaccion
                '----------------------------------------------------------------------------------------------------
                If factura.CodDPCardPunto = "BON" Then
                    'If Provider = Proveedor.BLUE AndAlso factura.CodDPCardPunto = "CAN" Then
                    If Provider = Proveedor.BLUE Then
                        Exit Sub
                    End If
                    Dim ws As New WSBroker("WS_BLUE", True)
                    Dim resultado As New Hashtable
                    Dim params As New Hashtable
                    params("CardId") = CardId
                    'params("CardId") = factura.NoDPCardPuntos
                    params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                    params("Amount") = CDec(ebSubTotal.Text.Trim())
                    params("TotalAmount") = CDec(ebSubTotal.Text.Trim())
                    params("ticketid") = factura.FolioSAP
                    '-----------------------------------------------------------------------------
                    'JNAVA (08.12.2015): Correccion de Almacen (storeID)
                    '-----------------------------------------------------------------------------
                    If Provider = Proveedor.BLUE Then
                        params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                    Else
                        params("StoreId") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                        params("tipo") = "01"
                    End If
                    'params("StoreId") = "004"
                    '-----------------------------------------------------------------------------
                    Select Case ebTipoVenta.Value
                        Case "V"
                            params("ReferenceId3") = "CFDPV"
                        Case "D"
                            params("ReferenceId3") = "DPC"
                        Case Else
                            params("ReferenceId3") = "CF"
                    End Select
                    If Provider = Proveedor.KARUM Then
                        If factura.CodDPCardPunto.Trim() = "BON" Then
                            params("ReferenceId3") = factura.CodDPCardPunto
                            params("ReferenceId4") = ebSubTotal.Text.Trim() & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
                        ElseIf factura.CodDPCardPunto.Trim() = "CAN" Then
                            params("ReferenceId3") = factura.CodDPCardPunto
                            Dim canje As Decimal = dsFormasPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago='DPPT'")
                            Dim count As Decimal = dsFormasPago.Tables(0).Rows.Count
                            If count > 1 Then
                                canje = CDec(ebSubTotal.Text.Trim()) - canje
                                params("ReferenceId4") = CStr(canje) & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
                            Else
                                params("ReferenceId4") = CStr(0) & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
                            End If
                        End If
                        'params("ReferenceId4") = ebSubTotal.Text.Trim() & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
                        params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                        params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    Else
                        params("ReferenceId4") = ""
                        params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                        params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
                    End If

                    params("SupervisorCode") = Me.ebPlayerCod.Text.Trim()
                    params("SupervisorName") = oVendedor.Nombre
                    params("SellerCode") = Me.ebPlayerCod.Text.Trim()
                    params("SellerName") = oVendedor.Nombre
                    Dim product As String = ""
                    Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                    Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                    Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                    Dim cantidad As Decimal = 0
                    For Each row As DataRow In dsNotaCreditoDetalle.Tables(0).Rows
                        total = 0
                        unitPrice = 0
                        cantidad = 0
                        articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                        cantidad = Math.Round(CDec(row("Cantidad")), 2)
                        total = row("Total")
                        descSistema = row("Descuento")
                        total = total - descSistema
                        descuento = row("Adicional")
                        descuento = total * (descuento / 100)
                        unitPrice = row("Importe") - (descSistema / cantidad) - (descuento / cantidad)
                        unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                        total = unitPrice * cantidad
                        If Provider = Proveedor.BLUE Then
                            product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                        Else
                            product &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
                        End If

                    Next
                    params("Products") = product.Remove(product.Length - 1, 1)
                    '-----------------------------------------------------------------------------------------------------------------------------------------
                    'JNAVA (17.09.2015): Se ejecuta la Transaccion ReturnByMoneyRegister que quita los puntos asignados a la tarjeta por la compra original
                    '-----------------------------------------------------------------------------------------------------------------------------------------
                    'resultado = ws.ReturnRegister(params)
                    resultado = ws.ReturnByMoneyRegister(params)
                    'If Provider = Proveedor.KARUM Then
                    '    ActualizarConsecutivoPuntosPOS()
                    'End If
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultID") = True Then
                            If CInt(resultado("ResultID")) >= 0 Then
                                PrintHashtable(resultado)
                                If Provider = Proveedor.BLUE Then
                                    Dim imp As Decimal = CDec(resultado("TotalPointsInCash"))
                                    If imp < 0 Then
                                        impDev = imp
                                    End If
                                Else
                                    If factura.CodDPCardPunto.Trim() = "CAN" Then
                                        resultado("TipoReporte") = "DEV"
                                        resultado("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                                        resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                                        resultado("CardId") = CardId
                                        resultado("CodVendedor") = Me.ebPlayerCod.Text.Trim()
                                        resultado("Monto") = CDec(params("Amount")) * -1
                                        resultado("tipo") = "01"

                                        '-----------------------------------------------------------
                                        'FLIZARRAGA 30/10/2017: Consecutivo POS
                                        '-----------------------------------------------------------
                                        resultado("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                                        'PrintTicketDevolucionPuntos(resultado)
                                    End If
                                End If
                            Else
                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 07/05/2014: Imprime el resultado del response
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintHashtable(ByVal result As Hashtable)
        For Each str As String In result.Keys
            Console.WriteLine(str & ": " & CStr(result(str)))
        Next
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 02/12/2016: Impresión de la devolución del Canje
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintTicketDevolucionPuntos(ByVal Datos As Hashtable)
        Dim rptActivaciondpCard As New rptDPCardPuntosKarum(Datos)
        With rptActivaciondpCard
            .Document.Name = "Devolucion DPCard Puntos"
            .PageSettings.PaperHeight = 7
            .PageSettings.PaperWidth = 14
            .PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
            .Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
            .Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
            .Run()
        End With
        Try
            rptActivaciondpCard.Document.Print(False, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "S2Credit"

    '----------------------------------------------------------------------------------------------------
    ' JNAVA (20.07.2016): Generamos devolucion del DPVale en S2Credit
    '----------------------------------------------------------------------------------------------------
    Private Function GenerarDevolucionS2Credit(ByVal oFactura As Factura, ByVal oPedido As Pedidos) As Boolean

        '----------------------------------------------------------------------------------------------------
        ' Objetos locales
        '----------------------------------------------------------------------------------------------------
        Dim oS2Credit As New ProcesosS2Credit
        Dim oDistribucionNCMgr As New DistribucionNCManager(oAppContext)

        '----------------------------------------------------------------------------------------------------
        ' Variables locales
        '----------------------------------------------------------------------------------------------------
        Dim bResult As Boolean = True
        Dim oDPVale As New cDPVale
        Dim MensajeDev As String = String.Empty

        '----------------------------------------------------------------------------------------------------
        ' Cargamos el ID del DPVale
        '----------------------------------------------------------------------------------------------------
        ' Dim strFacturaID As String = oNotaCredito.Detalle.Tables(0).Rows(0)("FacturaID") 'oDistribucionNCMgr.GetFacturaByNCID(oNotaCredito.ID)
        Dim strDpValeIDDP As String = CStr(oDistribucionNCMgr.GetDpValeIDDP(oFactura.FacturaID))


        '------------------------------------------------------------------------------------------------------------------------------
        ' MLVARGAS (10.12.2020): El valor anterior es el id de la forma de pago no el vale, se obtiene la referencia y de ahí el vale
        '------------------------------------------------------------------------------------------------------------------------------
        strDpValeIDDP = CStr(oDistribucionNCMgr.GetDpVale(oFactura.FacturaID))

        If strDpValeIDDP.Trim.Length > 0 Then
            If strDpValeIDDP.IndexOf("-") > 0 Then
                Dim vale As String = strDpValeIDDP.Substring(strDpValeIDDP.IndexOf("-") + 1)
                strDpValeIDDP = vale
            End If
        End If


        '----------------------------------------------------------------------------------------------------
        ' JNAVA (18.11.2016): Si es facturado en un pedido de sh, cargamos el ID del DPVale desde el pedido
        '----------------------------------------------------------------------------------------------------
        If strDpValeIDDP.Trim() = "" Then
            strDpValeIDDP = oPedido.DPValeID
        End If

        '----------------------------------------------------------------------------------------------------
        ' Validamos DPVale
        '----------------------------------------------------------------------------------------------------
        oDPVale.INUMVA = strDpValeIDDP
        oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)

        If oDPVale.EEXIST = "S" Then

            'Dim intFacturaID As Integer ' Factura DPPRO.
            Dim decDevDPVL As Decimal
            Dim decMontoNoCancelado As Decimal
            Dim PagoCanje As Decimal
            '----------------------------------------------------------------------------------------------------
            ' Validamos que la forma de pago Exista
            '----------------------------------------------------------------------------------------------------
            'intFacturaID = oNotaCredito.Detalle.Tables(0).Rows(0)("FacturaID")

            '------------------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS (10.12.2020): En los cambios de talla con DPVale la forma de pago es con vale de caja 
            '------------------------------------------------------------------------------------------------------------------------------
            'If (oNotasCreditoMgr.ValidarExistenciaFormaPago(oFactura.FacturaID, "DPVL") = True) Or
            '   (oNotasCreditoMgr.ValidarExistenciaFormaPago(oFactura.FacturaID, "VCJA") = True) Then

            'ASANCHEZ 09/06/2021 Modificación del proceso en devoluciones de ventas de cambio de talla (DPPRO)
            If (oNotasCreditoMgr.ValidarExistenciaFormaPago(oFactura.FacturaID, "DPVL") = True) Then
                '------------------------------------------------------------------------------------------------
                ''FLIZARRAGA 25/09/2018: Hacemos el calculo con el importe restante del canje
                '------------------------------------------------------------------------------------------------
                'PagoCanje = oNotasCreditoMgr.ExtraerMontoNoCancelado(oFactura.FacturaID, "DPPT")
                'ASANCHEZ 09/06/2021 se comento ya que el proceos cambio y se modifico por el proceso que esta abajo
                'decMontoNoCancelado = oNotasCreditoMgr.ExtraerMontoNoCancelado(oFactura.FacturaID, "DPVL")
                'If decMontoNoCancelado = 0 Then
                ' decMontoNoCancelado = oNotasCreditoMgr.ExtraerMontoNoCancelado(oFactura.FacturaID, "VCJA")
                'End If
                'ASANCHEZ 09/06/2021 Modificación del proceso en devoluciones de ventas de cambio de talla (DPPRO)
                decMontoNoCancelado = oNotasCreditoMgr.ExtraerMontoNoCancelado(oFactura.FacturaID, "DPVL")
                Dim restante As Decimal = oNotaCredito.Importe '- PagoCanje
                If decMontoNoCancelado = 0 Then
                    '----------------------------------------------------------------------------------------------------
                    ' Si la forma de pago ya fue consumida por otras devoluciones entonces no descontamos saldo del credito
                    '----------------------------------------------------------------------------------------------------
                    decDevDPVL = 0
                Else
                    If restante > decMontoNoCancelado Then
                        decDevDPVL = decMontoNoCancelado
                    Else
                        decDevDPVL = restante
                    End If
                End If
            Else
                '----------------------------------------------------------------------------------------------------
                ' Si no existe la forma de pago entonces no descontamos saldo del credito
                '----------------------------------------------------------------------------------------------------
                decDevDPVL = 0
            End If
            '--------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 25/09/2018: Validamos que el importe sea mayor a cero
            '--------------------------------------------------------------------------------------------------------

            If decDevDPVL > 0 Then
                '----------------------------------------------------------------------------------------
                ' JNAVA (20.07.2016): Hacemos la devolucion del Vale
                '----------------------------------------------------------------------------------------
                MensajeDev = oS2Credit.GeneraDevolucion(strDpValeIDDP, CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadLeft(10, "0"), decDevDPVL)

                If MensajeDev <> String.Empty Then

                    bResult = False
                    MessageBox.Show("Ocurrio un error al grabar la devolución del DPVale en S2Credit: " & vbCrLf & vbCrLf & MensajeDev & vbCrLf & vbCrLf & "Favor de comunicarse a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Else

            bResult = False
            MessageBox.Show("El DPortenis Vale no existe en S2Credit. Favor de verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If

        Return bResult

    End Function

    '----------------------------------------------------------------------------------------------------
    ' JNAVA (05.08.2016): Validamos las devoluciones del DPVale en S2Credit
    '----------------------------------------------------------------------------------------------------
    Private Function ValidaDevolucionesS2Credit(ByVal oFactura As Factura, ByVal oPedido As Pedidos) As Boolean

        '----------------------------------------------------------------------------------------------------
        ' Objetos locales
        '----------------------------------------------------------------------------------------------------
        Dim oS2Credit As New ProcesosS2Credit
        Dim bResult As Boolean = True
        Dim oDistribucionNCMgr As New DistribucionNCManager(oAppContext)

        '----------------------------------------------------------------------------------------------------
        ' Cargamos el ID del DPVale
        '----------------------------------------------------------------------------------------------------
        'Dim strFacturaID As String = oNotaCredito.Detalle.Tables(0).Rows(0)("FacturaID") 'oDistribucionNCMgr.GetFacturaByNCID(oNotaCredito.ID)
        Dim DPValeID As String = CStr(oDistribucionNCMgr.GetDpValeIDDP(oFactura.FacturaID))

        '----------------------------------------------------------------------------------------------------
        ' JNAVA (18.11.2016): Si es facturado en un pedido de sh, cargamos el ID del DPVale desde el pedido
        '----------------------------------------------------------------------------------------------------
        If DPValeID.Trim = "0" Then
            DPValeID = oPedido.DPValeID
        End If

        '----------------------------------------------------------------------------------------------------
        ' Validamos Devoluciones en DPVale
        '----------------------------------------------------------------------------------------------------
        Dim MensajeDev As String = oS2Credit.ValidaDevoluciones(DPValeID)
        If MensajeDev.Trim <> String.Empty Then
            If MessageBox.Show("La Factura ya cuenta con devoluciones aplicadas al DPVale " & DPValeID & " con los siguientes montos: " & vbCrLf & vbCrLf & MensajeDev & vbCrLf & _
                               vbCrLf & "¿Ésta información es correcta?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                MessageBox.Show("No se generó la Nota de Credito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                bResult = False
            End If
        End If

        Return bResult

    End Function

#End Region

#Region "Mejoras Lealtad 2"

    Private Sub ReimprimirNotaCredito()
        Dim oOpenRecordDlg As New OpenRecordDialog


        oOpenRecordDlg.CurrentView = New NotaCreditoOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
            oNotaCredito = Nothing
            oNotaCredito = oNotasCreditoMgr.Load(oOpenRecordDlg.Record.Item("NotaCreditoID"))
            If oConfigCierreFI.MiniPrinter Then
                Try
                    Dim oRpt As New ActRptNotaCredito(oNotaCredito, oConfigCierreFI.ImprimirCedula, True)
                    oRpt.Document.Name = "Nota de Credito"
                    oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oRpt.DataSource = oNotaCredito.Detalle.Tables(0) 'oFactura.Detalle
                    oRpt.Run()
                    oRpt.Document.Print(False, False)
                Catch ex As Exception
                    EscribeLog(ex.ToString, "Error al imprimir la nota de credito")
                End Try
            End If
        End If
    End Sub

    Private Sub RePrintNotaCredito()
        If Not oNotaCredito Is Nothing Then
            If oConfigCierreFI.MiniPrinter Then
                Try
                    Dim oRpt As New ActRptNotaCredito(oNotaCredito, oConfigCierreFI.ImprimirCedula, True)
                    oRpt.Document.Name = "Nota de Credito"
                    oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oRpt.DataSource = oNotaCredito.Detalle.Tables(0) 'oFactura.Detalle
                    oRpt.Run()
                    oRpt.Document.Print(False, False)
                Catch ex As Exception
                    EscribeLog(ex.ToString, "Error al imprimir la nota de credito")
                End Try
            End If
        Else
            MessageBox.Show("No hay nota de crédito seleccionada", "Notas de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

#End Region

   
End Class
