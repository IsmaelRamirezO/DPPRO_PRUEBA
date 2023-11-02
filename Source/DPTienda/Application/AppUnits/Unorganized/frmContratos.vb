
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoDescuento
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Imports Janus.Windows.GridEX
Imports System.Collections.Generic

Public Class frmContratos
    Inherits System.Windows.Forms.Form


#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVer As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoArticulos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTDescuento As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTVenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarVer As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoArticulos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTDescuento1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTVenta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarVer1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents uibtnCapturaDetalle As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridContratoDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebSubTotal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebIVA As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDescuentoTotal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebImporteTotal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebArticuloTalla As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebArticuloExistencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebArticuloDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebStatus As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNumPlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents uibtnDatosCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents uibtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents uibtnAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents uibtnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebNombreCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombrePlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTAyuda2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDescuento As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ebCodCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigoArt As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents menuBuscarHuella1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents exbGuardarCliente As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents pbAvance As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents lblLabel14 As System.Windows.Forms.Label
    Friend WithEvents menuSalir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContratos))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.uibtnNuevo = New Janus.Windows.EditControls.UIButton()
        Me.uibtnAbrir = New Janus.Windows.EditControls.UIButton()
        Me.uibtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.ebSubTotal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebIVA = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDescuentoTotal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebImporteTotal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ebCodigoArt = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel5 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.ebArticuloTalla = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebArticuloExistencia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebArticuloDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.GridContratoDetalle = New Janus.Windows.GridEX.GridEX()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.exbGuardarCliente = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.pbAvance = New Janus.Windows.EditControls.UIProgressBar()
        Me.lblLabel14 = New System.Windows.Forms.Label()
        Me.ebCodCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.cmbTipoDescuento = New Janus.Windows.EditControls.UIComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ebNumPlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.uibtnCapturaDetalle = New Janus.Windows.EditControls.UIButton()
        Me.uibtnDatosCliente = New Janus.Windows.EditControls.UIButton()
        Me.ebNombreCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombrePlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebStatus = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoImprimir2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTAyuda2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTAyuda")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir2 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuCatalogo = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogo")
        Me.menuCatalogoArticulos1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoArticulos")
        Me.menuCatalogoTDescuento1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTDescuento")
        Me.menuCatalogoTVenta1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTVenta")
        Me.menuVer = New Janus.Windows.UI.CommandBars.UICommand("menuVer")
        Me.menuBarVer1 = New Janus.Windows.UI.CommandBars.UICommand("menuBarVer")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTAyuda")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaAcerca1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.menuCatalogoArticulos = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoArticulos")
        Me.menuCatalogoTDescuento = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTDescuento")
        Me.menuCatalogoTVenta = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTVenta")
        Me.menuAyudaTAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTAyuda")
        Me.menuAyudaAcerca = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuBarNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuBarNuevo")
        Me.menuBarAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuBarAbrir")
        Me.menuBarGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuBarGuardar")
        Me.menuBarImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuBarImprimir")
        Me.menuBarAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuBarAyuda")
        Me.menuBarVer = New Janus.Windows.UI.CommandBars.UICommand("menuBarVer")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.GridContratoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.exbGuardarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exbGuardarCliente.SuspendLayout()
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
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.ExplorerBar3)
        Me.UiGroupBox1.Controls.Add(Me.ExplorerBar2)
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox1.Controls.Add(Me.ExplorerBar1)
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 50)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(752, 548)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.uibtnNuevo)
        Me.ExplorerBar3.Controls.Add(Me.uibtnAbrir)
        Me.ExplorerBar3.Controls.Add(Me.uibtnGuardar)
        Me.ExplorerBar3.Controls.Add(Me.ebSubTotal)
        Me.ExplorerBar3.Controls.Add(Me.ebIVA)
        Me.ExplorerBar3.Controls.Add(Me.ebDescuentoTotal)
        Me.ExplorerBar3.Controls.Add(Me.ebImporteTotal)
        Me.ExplorerBar3.Controls.Add(Me.Label13)
        Me.ExplorerBar3.Controls.Add(Me.Label12)
        Me.ExplorerBar3.Controls.Add(Me.Label11)
        Me.ExplorerBar3.Controls.Add(Me.Label10)
        Me.ExplorerBar3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Importe"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar3.Location = New System.Drawing.Point(359, 328)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(392, 200)
        Me.ExplorerBar3.TabIndex = 3
        Me.ExplorerBar3.TabStop = False
        Me.ExplorerBar3.Text = "ExplorerBar3"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'uibtnNuevo
        '
        Me.uibtnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.uibtnNuevo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnNuevo.Location = New System.Drawing.Point(55, 162)
        Me.uibtnNuevo.Name = "uibtnNuevo"
        Me.uibtnNuevo.Size = New System.Drawing.Size(96, 28)
        Me.uibtnNuevo.TabIndex = 6
        Me.uibtnNuevo.Text = "&Nuevo"
        Me.uibtnNuevo.Visible = False
        Me.uibtnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnAbrir
        '
        Me.uibtnAbrir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.uibtnAbrir.Location = New System.Drawing.Point(159, 162)
        Me.uibtnAbrir.Name = "uibtnAbrir"
        Me.uibtnAbrir.Size = New System.Drawing.Size(96, 28)
        Me.uibtnAbrir.TabIndex = 7
        Me.uibtnAbrir.Text = "A&brir"
        Me.uibtnAbrir.Visible = False
        Me.uibtnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnGuardar
        '
        Me.uibtnGuardar.Location = New System.Drawing.Point(263, 162)
        Me.uibtnGuardar.Name = "uibtnGuardar"
        Me.uibtnGuardar.Size = New System.Drawing.Size(96, 28)
        Me.uibtnGuardar.TabIndex = 8
        Me.uibtnGuardar.Text = "&Guardar"
        Me.uibtnGuardar.Visible = False
        Me.uibtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebSubTotal
        '
        Me.ebSubTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSubTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSubTotal.BackColor = System.Drawing.Color.Ivory
        Me.ebSubTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSubTotal.Location = New System.Drawing.Point(240, 68)
        Me.ebSubTotal.Name = "ebSubTotal"
        Me.ebSubTotal.ReadOnly = True
        Me.ebSubTotal.Size = New System.Drawing.Size(120, 22)
        Me.ebSubTotal.TabIndex = 8
        Me.ebSubTotal.TabStop = False
        Me.ebSubTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSubTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebIVA
        '
        Me.ebIVA.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebIVA.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebIVA.BackColor = System.Drawing.Color.Ivory
        Me.ebIVA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebIVA.Location = New System.Drawing.Point(240, 97)
        Me.ebIVA.Name = "ebIVA"
        Me.ebIVA.ReadOnly = True
        Me.ebIVA.Size = New System.Drawing.Size(120, 22)
        Me.ebIVA.TabIndex = 7
        Me.ebIVA.TabStop = False
        Me.ebIVA.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebIVA.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDescuentoTotal
        '
        Me.ebDescuentoTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescuentoTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescuentoTotal.BackColor = System.Drawing.Color.Ivory
        Me.ebDescuentoTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescuentoTotal.Location = New System.Drawing.Point(240, 39)
        Me.ebDescuentoTotal.Name = "ebDescuentoTotal"
        Me.ebDescuentoTotal.ReadOnly = True
        Me.ebDescuentoTotal.Size = New System.Drawing.Size(120, 22)
        Me.ebDescuentoTotal.TabIndex = 6
        Me.ebDescuentoTotal.TabStop = False
        Me.ebDescuentoTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebDescuentoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebImporteTotal
        '
        Me.ebImporteTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebImporteTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebImporteTotal.BackColor = System.Drawing.Color.Ivory
        Me.ebImporteTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebImporteTotal.ForeColor = System.Drawing.Color.Red
        Me.ebImporteTotal.Location = New System.Drawing.Point(240, 126)
        Me.ebImporteTotal.Name = "ebImporteTotal"
        Me.ebImporteTotal.ReadOnly = True
        Me.ebImporteTotal.Size = New System.Drawing.Size(120, 22)
        Me.ebImporteTotal.TabIndex = 5
        Me.ebImporteTotal.TabStop = False
        Me.ebImporteTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebImporteTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(72, 130)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 16)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Importe Total:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(72, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 16)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Descuento Total:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(72, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 16)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "I.V.A.:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(72, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 14)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Subtotal:"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.Label8)
        Me.ExplorerBar2.Controls.Add(Me.ebCodigoArt)
        Me.ExplorerBar2.Controls.Add(Me.lblLabel5)
        Me.ExplorerBar2.Controls.Add(Me.lblLabel2)
        Me.ExplorerBar2.Controls.Add(Me.lblLabel1)
        Me.ExplorerBar2.Controls.Add(Me.lblLabel4)
        Me.ExplorerBar2.Controls.Add(Me.ebArticuloTalla)
        Me.ExplorerBar2.Controls.Add(Me.ebArticuloExistencia)
        Me.ExplorerBar2.Controls.Add(Me.ebArticuloDesc)
        Me.ExplorerBar2.Controls.Add(Me.Label9)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Controls.Add(Me.Label5)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Detalles:"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 328)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(360, 200)
        Me.ExplorerBar2.TabIndex = 2
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(32, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "Codigo:"
        '
        'ebCodigoArt
        '
        Me.ebCodigoArt.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoArt.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoArt.BackColor = System.Drawing.SystemColors.Info
        Me.ebCodigoArt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebCodigoArt.Location = New System.Drawing.Point(128, 40)
        Me.ebCodigoArt.Name = "ebCodigoArt"
        Me.ebCodigoArt.ReadOnly = True
        Me.ebCodigoArt.Size = New System.Drawing.Size(136, 22)
        Me.ebCodigoArt.TabIndex = 73
        Me.ebCodigoArt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoArt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel5.ForeColor = System.Drawing.Color.Black
        Me.lblLabel5.Location = New System.Drawing.Point(182, 170)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(164, 16)
        Me.lblLabel5.TabIndex = 72
        Me.lblLabel5.Text = "Guardar e Imprimir"
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.ForeColor = System.Drawing.Color.Black
        Me.lblLabel2.Location = New System.Drawing.Point(64, 170)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(84, 16)
        Me.lblLabel2.TabIndex = 71
        Me.lblLabel2.Text = "Guardar"
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.ForeColor = System.Drawing.Color.Red
        Me.lblLabel1.Location = New System.Drawing.Point(158, 170)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel1.TabIndex = 70
        Me.lblLabel1.Text = "F9"
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.ForeColor = System.Drawing.Color.Red
        Me.lblLabel4.Location = New System.Drawing.Point(40, 170)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel4.TabIndex = 69
        Me.lblLabel4.Text = "F2"
        '
        'ebArticuloTalla
        '
        Me.ebArticuloTalla.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebArticuloTalla.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebArticuloTalla.BackColor = System.Drawing.SystemColors.Info
        Me.ebArticuloTalla.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebArticuloTalla.Location = New System.Drawing.Point(128, 128)
        Me.ebArticuloTalla.Name = "ebArticuloTalla"
        Me.ebArticuloTalla.ReadOnly = True
        Me.ebArticuloTalla.Size = New System.Drawing.Size(136, 22)
        Me.ebArticuloTalla.TabIndex = 7
        Me.ebArticuloTalla.TabStop = False
        Me.ebArticuloTalla.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebArticuloTalla.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebArticuloExistencia
        '
        Me.ebArticuloExistencia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebArticuloExistencia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebArticuloExistencia.BackColor = System.Drawing.SystemColors.Info
        Me.ebArticuloExistencia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebArticuloExistencia.Location = New System.Drawing.Point(128, 70)
        Me.ebArticuloExistencia.Name = "ebArticuloExistencia"
        Me.ebArticuloExistencia.ReadOnly = True
        Me.ebArticuloExistencia.Size = New System.Drawing.Size(56, 22)
        Me.ebArticuloExistencia.TabIndex = 6
        Me.ebArticuloExistencia.TabStop = False
        Me.ebArticuloExistencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebArticuloExistencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebArticuloDesc
        '
        Me.ebArticuloDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebArticuloDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebArticuloDesc.BackColor = System.Drawing.SystemColors.Info
        Me.ebArticuloDesc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebArticuloDesc.Location = New System.Drawing.Point(128, 99)
        Me.ebArticuloDesc.Name = "ebArticuloDesc"
        Me.ebArticuloDesc.ReadOnly = True
        Me.ebArticuloDesc.Size = New System.Drawing.Size(200, 22)
        Me.ebArticuloDesc.TabIndex = 5
        Me.ebArticuloDesc.TabStop = False
        Me.ebArticuloDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebArticuloDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = "0"
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(32, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Tallas:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(32, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Existencias:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(32, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Descripcion:"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox2.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel
        Me.UiGroupBox2.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.Controls.Add(Me.GridContratoDetalle)
        Me.UiGroupBox2.Location = New System.Drawing.Point(0, 157)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(752, 171)
        Me.UiGroupBox2.TabIndex = 1
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'GridContratoDetalle
        '
        Me.GridContratoDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GridContratoDetalle.DesignTimeLayout = GridEXLayout1
        Me.GridContratoDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridContratoDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridContratoDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridContratoDetalle.GroupByBoxVisible = False
        Me.GridContratoDetalle.Location = New System.Drawing.Point(3, 8)
        Me.GridContratoDetalle.Name = "GridContratoDetalle"
        Me.GridContratoDetalle.Size = New System.Drawing.Size(746, 160)
        Me.GridContratoDetalle.TabIndex = 5
        Me.GridContratoDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.exbGuardarCliente)
        Me.ExplorerBar1.Controls.Add(Me.ebCodCliente)
        Me.ExplorerBar1.Controls.Add(Me.cmbTipoDescuento)
        Me.ExplorerBar1.Controls.Add(Me.Label14)
        Me.ExplorerBar1.Controls.Add(Me.ebNumPlayer)
        Me.ExplorerBar1.Controls.Add(Me.ebFecha)
        Me.ExplorerBar1.Controls.Add(Me.uibtnCapturaDetalle)
        Me.ExplorerBar1.Controls.Add(Me.uibtnDatosCliente)
        Me.ExplorerBar1.Controls.Add(Me.ebNombreCliente)
        Me.ExplorerBar1.Controls.Add(Me.ebNombrePlayer)
        Me.ExplorerBar1.Controls.Add(Me.ebStatus)
        Me.ExplorerBar1.Controls.Add(Me.ebFolio)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar1.Location = New System.Drawing.Point(3, 8)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(746, 288)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'exbGuardarCliente
        '
        Me.exbGuardarCliente.Controls.Add(Me.pbAvance)
        Me.exbGuardarCliente.Controls.Add(Me.lblLabel14)
        Me.exbGuardarCliente.Location = New System.Drawing.Point(742, 13)
        Me.exbGuardarCliente.Name = "exbGuardarCliente"
        Me.exbGuardarCliente.Size = New System.Drawing.Size(328, 96)
        Me.exbGuardarCliente.TabIndex = 196
        Me.exbGuardarCliente.Text = "ExplorerBar2"
        Me.exbGuardarCliente.Visible = False
        Me.exbGuardarCliente.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'pbAvance
        '
        Me.pbAvance.Location = New System.Drawing.Point(8, 40)
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.ShowPercentage = True
        Me.pbAvance.Size = New System.Drawing.Size(312, 32)
        Me.pbAvance.TabIndex = 2
        Me.pbAvance.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblLabel14
        '
        Me.lblLabel14.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel14.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel14.Location = New System.Drawing.Point(8, 8)
        Me.lblLabel14.Name = "lblLabel14"
        Me.lblLabel14.Size = New System.Drawing.Size(200, 40)
        Me.lblLabel14.TabIndex = 1
        Me.lblLabel14.Text = "Guardando Cliente ..."
        '
        'ebCodCliente
        '
        Me.ebCodCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodCliente.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebCodCliente.ButtonImage = CType(resources.GetObject("ebCodCliente.ButtonImage"), System.Drawing.Image)
        Me.ebCodCliente.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodCliente.Location = New System.Drawing.Point(110, 94)
        Me.ebCodCliente.MaxLength = 10
        Me.ebCodCliente.Name = "ebCodCliente"
        Me.ebCodCliente.Size = New System.Drawing.Size(136, 22)
        Me.ebCodCliente.TabIndex = 0
        Me.ebCodCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbTipoDescuento
        '
        Me.cmbTipoDescuento.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "DMA  -  Descuento del Manager"
        UiComboBoxItem1.Value = "DMA"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "DPO  -  Promociones y Ofertas"
        UiComboBoxItem2.Value = "DPO"
        Me.cmbTipoDescuento.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2})
        Me.cmbTipoDescuento.Location = New System.Drawing.Point(125, 150)
        Me.cmbTipoDescuento.Name = "cmbTipoDescuento"
        Me.cmbTipoDescuento.Size = New System.Drawing.Size(72, 23)
        Me.cmbTipoDescuento.TabIndex = 2
        Me.cmbTipoDescuento.Visible = False
        Me.cmbTipoDescuento.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(19, 156)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 23)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Tipo Descto :"
        Me.Label14.Visible = False
        '
        'ebNumPlayer
        '
        Me.ebNumPlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumPlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumPlayer.ButtonImage = CType(resources.GetObject("ebNumPlayer.ButtonImage"), System.Drawing.Image)
        Me.ebNumPlayer.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebNumPlayer.Location = New System.Drawing.Point(110, 121)
        Me.ebNumPlayer.MaxLength = 8
        Me.ebNumPlayer.Name = "ebNumPlayer"
        Me.ebNumPlayer.Size = New System.Drawing.Size(136, 23)
        Me.ebNumPlayer.TabIndex = 1
        Me.ebNumPlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumPlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.SystemColors.Info
        Me.ebFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecha.Location = New System.Drawing.Point(110, 66)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(120, 22)
        Me.ebFecha.TabIndex = 22
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uibtnCapturaDetalle
        '
        Me.uibtnCapturaDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.uibtnCapturaDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnCapturaDetalle.Image = CType(resources.GetObject("uibtnCapturaDetalle.Image"), System.Drawing.Image)
        Me.uibtnCapturaDetalle.Location = New System.Drawing.Point(601, 119)
        Me.uibtnCapturaDetalle.Name = "uibtnCapturaDetalle"
        Me.uibtnCapturaDetalle.Size = New System.Drawing.Size(136, 24)
        Me.uibtnCapturaDetalle.TabIndex = 4
        Me.uibtnCapturaDetalle.Text = "Captura de Detalle"
        Me.uibtnCapturaDetalle.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnDatosCliente
        '
        Me.uibtnDatosCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.uibtnDatosCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnDatosCliente.Location = New System.Drawing.Point(601, 91)
        Me.uibtnDatosCliente.Name = "uibtnDatosCliente"
        Me.uibtnDatosCliente.Size = New System.Drawing.Size(136, 24)
        Me.uibtnDatosCliente.TabIndex = 3
        Me.uibtnDatosCliente.TabStop = False
        Me.uibtnDatosCliente.Text = "Alta del Cliente"
        Me.uibtnDatosCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNombreCliente
        '
        Me.ebNombreCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombreCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombreCliente.BackColor = System.Drawing.SystemColors.Info
        Me.ebNombreCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombreCliente.Location = New System.Drawing.Point(252, 93)
        Me.ebNombreCliente.Name = "ebNombreCliente"
        Me.ebNombreCliente.ReadOnly = True
        Me.ebNombreCliente.Size = New System.Drawing.Size(343, 22)
        Me.ebNombreCliente.TabIndex = 16
        Me.ebNombreCliente.TabStop = False
        Me.ebNombreCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombreCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombrePlayer
        '
        Me.ebNombrePlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombrePlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombrePlayer.BackColor = System.Drawing.SystemColors.Info
        Me.ebNombrePlayer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombrePlayer.Location = New System.Drawing.Point(252, 121)
        Me.ebNombrePlayer.Name = "ebNombrePlayer"
        Me.ebNombrePlayer.ReadOnly = True
        Me.ebNombrePlayer.Size = New System.Drawing.Size(343, 22)
        Me.ebNombrePlayer.TabIndex = 15
        Me.ebNombrePlayer.TabStop = False
        Me.ebNombrePlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombrePlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebStatus
        '
        Me.ebStatus.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebStatus.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebStatus.BackColor = System.Drawing.SystemColors.Info
        Me.ebStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebStatus.Location = New System.Drawing.Point(508, 66)
        Me.ebStatus.Name = "ebStatus"
        Me.ebStatus.ReadOnly = True
        Me.ebStatus.Size = New System.Drawing.Size(87, 22)
        Me.ebStatus.TabIndex = 12
        Me.ebStatus.TabStop = False
        Me.ebStatus.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebStatus.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.BackColor = System.Drawing.SystemColors.Info
        Me.ebFolio.ButtonImage = CType(resources.GetObject("ebFolio.ButtonImage"), System.Drawing.Image)
        Me.ebFolio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolio.ForeColor = System.Drawing.Color.Red
        Me.ebFolio.Location = New System.Drawing.Point(110, 39)
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.ReadOnly = True
        Me.ebFolio.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ebFolio.Size = New System.Drawing.Size(80, 22)
        Me.ebFolio.TabIndex = 5
        Me.ebFolio.TabStop = False
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(9, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Num. Player:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(9, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cliente:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(9, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(9, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Folio Contrato:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(436, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 23)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Status:"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuCatalogo, Me.menuVer, Me.menuAyuda, Me.menuSalir, Me.menuArchivoNuevo, Me.menuAbrir, Me.menuArchivoGuardar, Me.menuArchivoImprimir, Me.menuCatalogoArticulos, Me.menuCatalogoTDescuento, Me.menuCatalogoTVenta, Me.menuAyudaTAyuda, Me.menuAyudaAcerca, Me.menuBarNuevo, Me.menuBarAbrir, Me.menuBarGuardar, Me.menuBarImprimir, Me.menuBarAyuda, Me.menuBarVer})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("c8af8fdc-fb84-42ff-8aca-a04e79f69109")
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(752, 22)
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
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.Separator4, Me.menuArchivoGuardar2, Me.Separator6, Me.menuAbrir2, Me.Separator7, Me.menuArchivoImprimir2, Me.Separator8, Me.Separator9, Me.menuAyudaTAyuda2, Me.Separator10, Me.menuSalir2})
        Me.UiCommandBar2.FloatingSize = New System.Drawing.Size(385, 32)
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(342, 28)
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
        'menuAbrir2
        '
        Me.menuAbrir2.Key = "menuAbrir"
        Me.menuAbrir2.Name = "menuAbrir2"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'menuArchivoImprimir2
        '
        Me.menuArchivoImprimir2.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir2.Name = "menuArchivoImprimir2"
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
        'menuAyudaTAyuda2
        '
        Me.menuAyudaTAyuda2.Key = "menuAyudaTAyuda"
        Me.menuAyudaTAyuda2.Name = "menuAyudaTAyuda2"
        Me.menuAyudaTAyuda2.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'menuSalir2
        '
        Me.menuSalir2.Icon = CType(resources.GetObject("menuSalir2.Icon"), System.Drawing.Icon)
        Me.menuSalir2.Key = "menuSalir"
        Me.menuSalir2.Name = "menuSalir2"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.menuAbrir1, Me.Separator1, Me.menuArchivoGuardar1, Me.Separator2, Me.menuArchivoImprimir1, Me.Separator5, Me.menuSalir1})
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
        'menuArchivoImprimir1
        '
        Me.menuArchivoImprimir1.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir1.Name = "menuArchivoImprimir1"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuSalir1
        '
        Me.menuSalir1.Image = CType(resources.GetObject("menuSalir1.Image"), System.Drawing.Image)
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        Me.menuSalir1.Text = "Salir"
        '
        'menuCatalogo
        '
        Me.menuCatalogo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuCatalogoArticulos1, Me.menuCatalogoTDescuento1, Me.menuCatalogoTVenta1})
        Me.menuCatalogo.Key = "menuCatalogo"
        Me.menuCatalogo.Name = "menuCatalogo"
        Me.menuCatalogo.Text = "&Catalogo"
        '
        'menuCatalogoArticulos1
        '
        Me.menuCatalogoArticulos1.Key = "menuCatalogoArticulos"
        Me.menuCatalogoArticulos1.Name = "menuCatalogoArticulos1"
        '
        'menuCatalogoTDescuento1
        '
        Me.menuCatalogoTDescuento1.Key = "menuCatalogoTDescuento"
        Me.menuCatalogoTDescuento1.Name = "menuCatalogoTDescuento1"
        '
        'menuCatalogoTVenta1
        '
        Me.menuCatalogoTVenta1.Key = "menuCatalogoTVenta"
        Me.menuCatalogoTVenta1.Name = "menuCatalogoTVenta1"
        '
        'menuVer
        '
        Me.menuVer.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuBarVer1})
        Me.menuVer.Key = "menuVer"
        Me.menuVer.Name = "menuVer"
        Me.menuVer.Text = "&Ver"
        '
        'menuBarVer1
        '
        Me.menuBarVer1.Key = "menuBarVer"
        Me.menuBarVer1.Name = "menuBarVer1"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTAyuda1, Me.Separator3, Me.menuAyudaAcerca1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ay&uda"
        '
        'menuAyudaTAyuda1
        '
        Me.menuAyudaTAyuda1.Key = "menuAyudaTAyuda"
        Me.menuAyudaTAyuda1.Name = "menuAyudaTAyuda1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuAyudaAcerca1
        '
        Me.menuAyudaAcerca1.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca1.Name = "menuAyudaAcerca1"
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
        'menuAbrir
        '
        Me.menuAbrir.Image = CType(resources.GetObject("menuAbrir.Image"), System.Drawing.Image)
        Me.menuAbrir.Key = "menuAbrir"
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Text = "A&brir"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Image = CType(resources.GetObject("menuArchivoGuardar.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "&Guardar"
        '
        'menuArchivoImprimir
        '
        Me.menuArchivoImprimir.Image = CType(resources.GetObject("menuArchivoImprimir.Image"), System.Drawing.Image)
        Me.menuArchivoImprimir.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Name = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Text = "&Imprimir"
        '
        'menuCatalogoArticulos
        '
        Me.menuCatalogoArticulos.Key = "menuCatalogoArticulos"
        Me.menuCatalogoArticulos.Name = "menuCatalogoArticulos"
        Me.menuCatalogoArticulos.Text = "A&rticulos"
        '
        'menuCatalogoTDescuento
        '
        Me.menuCatalogoTDescuento.Key = "menuCatalogoTDescuento"
        Me.menuCatalogoTDescuento.Name = "menuCatalogoTDescuento"
        Me.menuCatalogoTDescuento.Text = "Tipo de &Descuento"
        '
        'menuCatalogoTVenta
        '
        Me.menuCatalogoTVenta.Key = "menuCatalogoTVenta"
        Me.menuCatalogoTVenta.Name = "menuCatalogoTVenta"
        Me.menuCatalogoTVenta.Text = "Tipo de &Venta"
        '
        'menuAyudaTAyuda
        '
        Me.menuAyudaTAyuda.Image = CType(resources.GetObject("menuAyudaTAyuda.Image"), System.Drawing.Image)
        Me.menuAyudaTAyuda.Key = "menuAyudaTAyuda"
        Me.menuAyudaTAyuda.Name = "menuAyudaTAyuda"
        Me.menuAyudaTAyuda.Text = "Ayuda"
        '
        'menuAyudaAcerca
        '
        Me.menuAyudaAcerca.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Name = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Text = "Acerca de..."
        '
        'menuBarNuevo
        '
        Me.menuBarNuevo.Key = "menuBarNuevo"
        Me.menuBarNuevo.Name = "menuBarNuevo"
        Me.menuBarNuevo.Text = "Nuevo"
        '
        'menuBarAbrir
        '
        Me.menuBarAbrir.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image
        Me.menuBarAbrir.Key = "menuBarAbrir"
        Me.menuBarAbrir.Name = "menuBarAbrir"
        Me.menuBarAbrir.Text = "Abrir"
        '
        'menuBarGuardar
        '
        Me.menuBarGuardar.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image
        Me.menuBarGuardar.Key = "menuBarGuardar"
        Me.menuBarGuardar.Name = "menuBarGuardar"
        Me.menuBarGuardar.Text = "Guardar"
        '
        'menuBarImprimir
        '
        Me.menuBarImprimir.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image
        Me.menuBarImprimir.Key = "menuBarImprimir"
        Me.menuBarImprimir.Name = "menuBarImprimir"
        Me.menuBarImprimir.Text = "Imprimir"
        '
        'menuBarAyuda
        '
        Me.menuBarAyuda.Key = "menuBarAyuda"
        Me.menuBarAyuda.Name = "menuBarAyuda"
        Me.menuBarAyuda.Text = "Ayuda"
        '
        'menuBarVer
        '
        Me.menuBarVer.Key = "menuBarVer"
        Me.menuBarVer.Name = "menuBarVer"
        Me.menuBarVer.Text = "Barra de Menu"
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
        Me.TopRebar1.Size = New System.Drawing.Size(752, 50)
        '
        'frmContratos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(752, 574)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmContratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Forma de Contratos"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        Me.ExplorerBar3.PerformLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ExplorerBar2.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.GridContratoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.exbGuardarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exbGuardarCliente.ResumeLayout(False)
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

#Region "Variables Miembros"

    Public oContrato As Contrato

    Private oContratoMgr As ContratoManager

    Private odsContratoDetalle As DataSet

    Private oCatalogoArticulosMgr As CatalogoArticuloManager

    Private oArticulo As Articulo

    Private oCatalogoPlayersMgr As CatalogoVendedoresManager

    Private oPlayer As Vendedor

    Private oCatalogoClientesMgr As ClientesManager

    'Ramiro
    'Private oCliente As Clientes
    Private oCliente As ClienteAlterno

    Private oCatalogoTipoDescuentosMgr As CatalogoTipoDescuentosManager

    Private oTipoDescuento As TipoDescuento

    Private odsCatalogoCorridas As DataSet


    Private strTablaTmp As String = "ContratoDetalleTmp" & oAppContext.ApplicationConfiguration.NoCaja

    Private bolSalir As Boolean

    Private oFirmasMgr As FirmaManager

    Private oSAPMgr As ProcesoSAPManager

    Private oFacturaMgr As FacturaManager
    Private SerialId As String

#End Region

#Region "Métodos Privados"

    Private Sub Sm_TxtLimpiar()

        oContrato = Nothing

        oCliente = Nothing

        oPlayer = Nothing

        ebFecha.Text = String.Empty

        ebStatus.Text = String.Empty

        ebNumPlayer.Text = String.Empty

        ebNombrePlayer.Text = String.Empty

        ebCodCliente.Text = String.Empty

        ebNombreCliente.Text = String.Empty

        cmbTipoDescuento.Text = String.Empty

        ebArticuloExistencia.Text = String.Empty

        ebArticuloDesc.Text = String.Empty
        'Ramiro
        'ebArticuloDescuento.Text = String.Empty

        ebArticuloTalla.Text = String.Empty

        ebSubTotal.Text = String.Empty

        ebIVA.Text = String.Empty

        ebDescuentoTotal.Text = String.Empty

        ebImporteTotal.Text = String.Empty


        odsContratoDetalle = Nothing
        GridContratoDetalle.DataSource = Nothing

        oContratoMgr.CrearTablaTmp()
        SerialId = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()

    End Sub

    Private Sub ProcesoBusquedaClienteCRM()

        If Not oCliente Is Nothing Then oCliente.Clear()
        'Mostrar el cuadro de busqueda manual del cliente
        If oConfigCierreFI.UsarDescargaClientes Then
            Sm_BuscarClientes(True)
        Else
            LoadSearchFormClientesSAP(True)
        End If

        If oCliente Is Nothing OrElse oCliente.CodigoAlterno.Trim = "" OrElse CDbl(oCliente.CodigoAlterno) <= 0 Then ebCodCliente_Validating(Nothing, Nothing)

        If oCliente Is Nothing OrElse oCliente.CodigoAlterno.Trim = "" OrElse CDbl(oCliente.CodigoAlterno) <= 0 Then
            If MessageBox.Show("¿Deseas dar de alta al cliente en este momento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                AltaDeClientes()
            Else
                Me.ebCodCliente.Focus()
            End If
        End If

    End Sub

    Private Sub LoadSearchFormClientesSAP(ByVal Mostrar As Boolean)

        If Mostrar Then

            Dim oOpenRecordDlg As OpenFROMSAPRecordDialogClientes

            oOpenRecordDlg = New OpenFROMSAPRecordDialogClientes
            oOpenRecordDlg.TipoVenta = "A"
            oOpenRecordDlg.CurrentView = New ClientesFromSAPOpenRecordDialogView

            If (oOpenRecordDlg.CurrentView Is Nothing) Then
                Exit Sub
            End If

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Try

                    If oOpenRecordDlg.pbCodigo = String.Empty Then

                        Me.ebCodCliente.Text = oOpenRecordDlg.Record.Item("KUNNR")
                        Me.ebNombreCliente.Text = oOpenRecordDlg.Record.Item("NAME1")

                    Else

                        Me.ebCodCliente.Text = CType(oOpenRecordDlg.pbCodigo, String)
                        Me.ebNombreCliente.Text = CType(oOpenRecordDlg.pbNombre, String)

                    End If

                    Me.ebNumPlayer.Focus()

                Catch ex As Exception

                    Throw New ApplicationException("[LoadSearchForm]", ex)

                End Try

            End If

        End If

    End Sub

    Private Sub ValidaCliente()

        Try
1:          If Me.ebCodCliente.Text <> "" AndAlso CLng(Me.ebCodCliente.Text.Trim) > 0 Then


                '------------------------------------------------
                ' JNAVA (11.02.2016): Adaptado para Retail
                '------------------------------------------------
2:              If oConfigCierreFI.UsarDescargaClientes = False Then GetCliente(Me.ebCodCliente.Text, "A")
3:              oCliente = oCatalogoClientesMgr.CreateAlterno
4:              oCatalogoClientesMgr.Load(Me.ebCodCliente.Text, oCliente, "A")

5:              If oCliente Is Nothing OrElse oCliente.CodigoAlterno.Trim = "" OrElse CDbl(oCliente.CodigoAlterno.Trim) <= 0 Then

                    'MessageBox.Show("El Cliente no fue encontrado.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
6:                  ebCodCliente.Text = "0"
7:                  ebNombreCliente.Text = String.Empty
                    'oCliente = Nothing

8:                  'If oConfigCierreFI.HuellaOpcional = True Then
9:                  If MessageBox.Show("¿Desea darlo de alta?", "DPTienda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
10:                     AltaDeClientes()
                    End If
                    'End If

11:                 ebCodCliente.Focus()

                    '-----------------------------------------------------------------------------------------------------------------------------
                    ' JNAVA (11.02.2016): Adaptacion para retail
                    '-----------------------------------------------------------------------------------------------------------------------------
12:             ElseIf oCliente.TipoVenta = "D" Or oCliente.TipoVenta = "DP" Then 'ElseIf InStr(oFacturaMgr.ValidaTipoVentaCliente(oCliente.CodigoAlterno), "A") <= 0 Then
13:                 MsgBox("El Cliente " & oCliente.CodigoAlterno & " no pertenece al tipo de venta apartado.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Dportenis Pro")
14:                 Me.ebNombreCliente.Text = ""
15:                 ebCodCliente.Text = "0"
16:                 ebCodCliente.Focus()
                Else
17:                 ebCodCliente.Text = oCliente.CodigoAlterno
18:                 ebNombreCliente.Text = oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
19:                 oCliente.TipoVenta = "A"
                    '---------------------------------------------------------------------------------------------------------------------------------------------
                    'Validamos los datos del Cliente
                    '---------------------------------------------------------------------------------------------------------------------------------------------
20:                 If ValidaDatosObligatoriosCliente(oCliente) = False Then
                        'If MessageBox.Show("El cliente no tiene todos los datos personales registrados." & vbCrLf & vbCrLf & "¿Deseas complementarlos en este momento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        '    AltaDeClientes(oCliente.CodigoAlterno, oCliente.TipoVenta, True)
                        'End If
21:                     MessageBox.Show("El cliente no tiene todos los datos personales registrados." & vbCrLf & vbCrLf & "Es necesario complementarlos para continuar con la venta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
22:                     AltaDeClientes(oCliente.CodigoAlterno, oCliente.TipoVenta)
                    End If
                End If
            Else
                Me.ebCodCliente.Text = String.Empty                
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al validar el cliente. Linea " & Err.Erl)
            Throw New ApplicationException("Error al validar el cliente. " & Err.Erl)
        End Try

    End Sub

    Private Sub AltaDeClientes(Optional ByVal ClienteID As String = "", Optional ByVal TipoCliente As String = "", Optional ByVal Complemento As Boolean = False)
        Dim ofrmClientes As New frmClientesSAP
        ofrmClientes.TipoVenta = "C"
        ofrmClientes.ClienteID = ClienteID
        ofrmClientes.TipoCliente = TipoCliente
        ofrmClientes.Player = Me.ebNumPlayer.Text

        ofrmClientes.ShowMeforFactura()

        If ofrmClientes.DialogResult = DialogResult.OK Then 'OrElse oCliente Is Nothing Then

            oCliente = ofrmClientes.oCliente

            With oCliente

                ebCodCliente.Text = ofrmClientes.ClienteID

                ebNombreCliente.Text = ofrmClientes.NombreApellidos

                'ebNombreCliente.Text = ebNombreCliente.Text.Trim

                'uibtnDatosCliente.Focus()
                ebNumPlayer.Focus()

            End With

        ElseIf Complemento = False Then
            'Ramiro Alcaraz Flores
            'If oCliente Is Nothing Or oCliente.CodigoCliente = 0 Then

            'MessageBox.Show("No se dio alta al cliente.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Me.ebCodCliente.Text = "0"
            Me.ebNombreCliente.Text = ""
            If Not oCliente Is Nothing Then oCliente.Clear()

        End If


    End Sub

    Private Function Fm_bolTxtValidar() As Boolean

        'If (ebFolio.Text = String.Empty) Then

        '    MsgBox("Para Guardar un Contrato vaya a la Opción Nuevo.", MsgBoxStyle.Exclamation, "DPTienda")
        '    uibtnNuevo.Focus()

        '    Exit Function

        'End If

        Try
            If (oCliente Is Nothing) OrElse ebNombreCliente.Text.Trim = "" Then '  oCliente.CodigoAlterno.Trim = "" OrElse CLng(oCliente.CodigoAlterno) <= 0 Then

                MsgBox("No ha sido seleccionado un Cliente.", MsgBoxStyle.Exclamation, "DPTienda")
                ebCodCliente.Focus()

                Exit Function

            End If


2:          If (oPlayer Is Nothing) Then

                MsgBox("No ha sido seleccionado un Player.", MsgBoxStyle.Exclamation, "DPTienda")
                ebNumPlayer.Focus()

                Exit Function

            End If


3:          Dim dtContratoDetalle As DataTable

4:          dtContratoDetalle = CType(GridContratoDetalle.DataSource, DataTable)

5:          If (dtContratoDetalle Is Nothing) Then

                MsgBox("El Detalle del Apartado no cuenta con Registros.", MsgBoxStyle.Exclamation, "DPTienda")
                uibtnCapturaDetalle.Focus()

                Exit Function

            End If


6:          If (dtContratoDetalle.Rows.Count = 0) Then

                MsgBox("El Detalle del Apartado no cuenta con Registros.", MsgBoxStyle.Exclamation, "DPTienda")
                dtContratoDetalle = Nothing
                uibtnCapturaDetalle.Focus()

                Exit Function

            End If

7:          dtContratoDetalle = Nothing


            'Verificar si en el Detalle se aplicaron descuentos.

8:          If (Fm_bolValidarAplicDescuento() = True) Then

                'If (cmbTipoDescuento.Text.Trim = String.Empty) Then

                '    MsgBox("Debe seleccionar un Tipo de Descuento", MsgBoxStyle.Exclamation, "DPTienda")
                '    Exit Function

                '    'Else

                '    '    If oFirmasMgr.ValidaDescuento(Me.cmbTipoDescuento.SelectedItem.Value, oSAPMgr.Read_Centros) = False Then

                '    '        MsgBox("El tipo de descuento seleccionado no está permitido para esta tienda" & vbCrLf & "Debe elegir otro tipo de descuento.", MsgBoxStyle.Exclamation, "Dportenis Pro")
                '    '        Exit Function

                '    '    End If

                'End If

            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al validar campos del formulario. Linea " & Err.Erl)
            Throw New ApplicationException("Error al validar campos. Linea " & Err.Erl)
        End Try

        Return True

    End Function



    Private Sub Sm_MostrarInformacion()

        On Error Resume Next

        '<Player>

        oPlayer = Nothing
        oPlayer = oCatalogoPlayersMgr.Load(oContrato.PlayerID)

        ebNumPlayer.Text = oPlayer.ID
        ebNombrePlayer.Text = oPlayer.Nombre

        '</Player>


        '<Cliente>

        'oCliente = oCatalogoClientesMgr.CreateAlterno
        'oCliente.CodigoAlterno()
        'oCatalogoClientesMgr.Load(oCliente.CodigoAlterno, oCliente, "A")

        oCatalogoClientesMgr.Load(oContrato.ClienteID, oCliente, "A")

        With oCliente

            ebCodCliente.Text = .CodigoAlterno
            ebNombreCliente.Text = .Nombre & " " & .ApellidoPaterno & " " & .ApellidoMaterno
        End With

        '</Cliente>


        With oContrato

            ebFolio.Text = Format(.FolioApartado, "000000")

            ebFecha.Text = Format(.Fecha, "dd - MMM - yyyy")

            cmbTipoDescuento.Text = oContrato.TipoDescuentoID

            If (.StatusRegistro = True) Then
                ebStatus.Text = "Activo"
            Else
                ebStatus.Text = "Cancelado"
            End If


            ebImporteTotal.Text = Format(.ImporteTotal, "Currency")

            ebDescuentoTotal.Text = Format(.DescuentoTotal, "Standard")

            ebIVA.Text = Format(.IVA, "Standard")

            ebSubTotal.Text = Format(.ImporteTotal - .IVA, "Standard")


            odsContratoDetalle = .Detalle
            GridContratoDetalle.DataSource = odsContratoDetalle.Tables(0)

        End With

    End Sub


    'Public Sub ActionPreview()
    Public Sub Sm_ActionPrint(ByVal strDocFi As String, Optional ByVal Reimpresion As Boolean = False)
        'desbloquear ramiro temporal
        'Dim oReportViewer As New ReportViewerForm

        If (oContrato Is Nothing) Then
            MsgBox("Debe Abrir un Contrato.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If

        Dim oARReporte
        Dim oView As New ReportViewerForm

        If oConfigCierreFI.MiniPrinter Then

            

            oARReporte = New ReporteApartadoMiniPrinter(Me, oCliente, strDocFi, oContrato.Detalle.Tables(0), Reimpresion)
            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
            oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

        Else

            oARReporte = New ReporteApartado(Me, oCliente, strDocFi, Reimpresion)

        End If



        'oARReporte.DataSource = oContrato.Detalle.Tables(0)
        oARReporte.Document.Name = "Reporte Contrato de Apartado"
        oARReporte.Run()

        Try

            oARReporte.Document.Print(False, False)
            'oView.Report = oARReporte
            'oView.Show()

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

    End Sub



    Private Sub Sm_BuscarClientes(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        '<Validación>

        'If Not (oContrato Is Nothing) Then

        '    MsgBox("El Status del Contrato no permite realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
        '    Exit Sub

        'End If

        '</Validación>


        If (Vpa_bolOpenRecordDialog = True) Then

            'Dim oOpenRecordDlg As New OpenRecordDialog
            Dim oOpenRecordDlg As New OpenRecordDialogClientes
            oOpenRecordDlg.GrupoDeCuentas = "I"
            'oOpenRecordDlg.GrupoDeCuentas = oCliente.TipoVenta
            oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

            If (oOpenRecordDlg.CurrentView Is Nothing) Then
                Exit Sub
            End If


            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Try

                    Dim strClienteID As String

                    If oOpenRecordDlg.pbCodigo = String.Empty Then

                        strClienteID = oOpenRecordDlg.Record.Item("CodigoAlterno")

                    Else

                        strClienteID = oOpenRecordDlg.pbCodigo

                    End If

                    oCliente = oCatalogoClientesMgr.CreateAlterno
                    oCatalogoClientesMgr.Load(strClienteID, oCliente, "I")

                    With oCliente
                        ebCodCliente.Text = .CodigoAlterno
                        ebNombreCliente.Text = .Nombre & " " & .ApellidoPaterno & " " & .ApellidoMaterno
                    End With

                Catch ex As Exception

                    Exit Sub

                End Try

            End If

        Else
            oCliente = oCatalogoClientesMgr.CreateAlterno

            oCatalogoClientesMgr.Load(Me.ebCodCliente.Text, oCliente, "A")

            If (oCliente.CodigoCliente = 0) Then
                MessageBox.Show("El Registro no existe.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebCodCliente.Text = String.Empty
                ebNombreCliente.Text = String.Empty

                oCliente = Nothing

                If MessageBox.Show("¿Desea darlo de alta?", "DPTienda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then

                    Dim ofrmClientes As New frmClientesSAP

                    ofrmClientes.ShowMeforFactura()

                    oCliente = ofrmClientes.oCliente

                    If oCliente Is Nothing Then
                        'Ramiro Alcaraz Flores
                        'If oCliente Is Nothing Or oCliente.CodigoCliente = 0 Then

                        MessageBox.Show("No se dio alta al cliente.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Else

                        With oCliente

                            ebCodCliente.Text = .CodigoAlterno

                            ebNombreCliente.Text = .Nombre & " " & .ApellidoPaterno & " " & .ApellidoMaterno

                            ebNombreCliente.Text = ebNombreCliente.Text.Trim

                            'uibtnDatosCliente.Focus()

                        End With

                    End If

                End If

                ebCodCliente.Focus()

                Exit Sub

            End If

            '</Validación>

            With oCliente

                ebCodCliente.Text = .CodigoAlterno
                ebNombreCliente.Text = .Nombre & " " & .ApellidoPaterno & " " & .ApellidoMaterno

                'uibtnDatosCliente.Focus()

            End With

        End If

    End Sub



    Private Sub Sm_BuscarPlayers(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        '<Validación>

        'If Not (oContrato Is Nothing) Then

        '    MsgBox("El Status del Contrato no permite realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
        '    Exit Sub

        'End If

        '</Validación>


        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoVendedoresOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oPlayer = Nothing
                oPlayer = oCatalogoPlayersMgr.Load(oOpenRecordDlg.Record.Item("CodVendedor"))

                ebNumPlayer.Text = oPlayer.ID
                ebNombrePlayer.Text = oPlayer.Nombre

                'ebCodCliente.Focus()

            End If

        Else

            On Error Resume Next

            oPlayer = Nothing
            oPlayer = oCatalogoPlayersMgr.Load(ebNumPlayer.Text.Trim.PadLeft(8, "0"))

            '<Validación>

            If (oPlayer Is Nothing) Then
                'MessageBox.Show("El Registro no existe.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebNumPlayer.Text = String.Empty
                ebNombrePlayer.Text = String.Empty

                ebNumPlayer.Focus()
                Exit Sub

            End If

            '</Validación>

            ebNumPlayer.Text = oPlayer.ID
            ebNombrePlayer.Text = oPlayer.Nombre

            'ebCodCliente.Focus()

        End If

    End Sub



    Private Sub Sm_BuscarTipoDescuento(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoTipoDescuentosOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oTipoDescuento = Nothing
                oTipoDescuento = oCatalogoTipoDescuentosMgr.Load(oOpenRecordDlg.Record.Item("CodTipoDescuento"))

            End If

        End If

    End Sub



    Public Sub SetupView()

        Dim oCurrentRow As GridEXRow

        Dim odrDataRow As DataRowView

        Dim odrFiltro() As DataRow

        Dim oArticulo As Articulo



        oCurrentRow = GridContratoDetalle.GetRow()

        odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

        oArticulo = Nothing
        oArticulo = oCatalogoArticulosMgr.Load(odrDataRow.Item("CodArticulo"))

        Me.ebCodigoArt.Text = oArticulo.CodArticulo

        ebArticuloExistencia.Text = oContratoMgr.ExtraerCantLibreArticulo(oArticulo.CodArticulo, odrDataRow("Numero"))

        ebArticuloDesc.Text = oArticulo.Descripcion

        'If oArticulo.CodCorrida = "ACC" Or oArticulo.CodCorrida = "TEX" Then
        '    ebArticuloTalla.Text = "Del XS  Al  U"
        'Else
        '    odrFiltro = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & oArticulo.CodCorrida & "'")
        '    ebArticuloTalla.Text = "Del " & odrFiltro(0).Item("NumInicio") & "  Al  " & odrFiltro(0).Item("NumFin")
        'End If
        oCurrentRow = Nothing
        odrDataRow = Nothing
        odrFiltro = Nothing

    End Sub



    Private Sub Sm_CalcularTotales()

        Dim dtContratoDetalle As DataTable
        Dim drArticulo As DataRow
        Dim decTotal As Decimal
        Dim decDescuentoMonto As Decimal


        dtContratoDetalle = oContratoMgr.ActualizarDataSet("[ContratoDetalleSel]", strTablaTmp).Tables(strTablaTmp)

        For Each drArticulo In dtContratoDetalle.Rows

            decTotal += CType(drArticulo("ImporteOferta"), Decimal)
            decDescuentoMonto += CType(drArticulo("DescuentoMonto"), Decimal)

        Next

        ebImporteTotal.Text = Format(decTotal * (1 + oAppContext.ApplicationConfiguration.IVA), "Currency")

        ebDescuentoTotal.Text = Format(decDescuentoMonto, "Standard")  'Format(CType(ebImporteTotal.Text, Decimal) * (decDescuento / 100), "Standard")

        ebIVA.Text = Format((decTotal * oAppContext.ApplicationConfiguration.IVA), "Standard")

        ebSubTotal.Text = Format((CType(ebImporteTotal.Text, Decimal) - CType(ebIVA.Text, Decimal)), "Standard")

        'ebSubTotal.Text = Format((decTotal / (1 + oAppContext.ApplicationConfiguration.IVA)), "Standard")
        'ebIVA.Text = Format(decTotal - ebSubTotal.Text, "Standard")

    End Sub



    Private Function Fm_bolValidarAplicDescuento() As Boolean

        Dim dtContratoDetalle As DataTable

        Dim drArticulo As DataRow

        Dim decTotalDescuento As Decimal


        dtContratoDetalle = odsContratoDetalle.Tables(0)

        For Each drArticulo In dtContratoDetalle.Rows

            decTotalDescuento += drArticulo("Descuento")

        Next

        If (decTotalDescuento = 0) Then
            Exit Function
        End If


        Return True

    End Function



    Private Sub Sm_Nuevo()

        Sm_TxtLimpiar()


        ebFolio.Text = Format(oContratoMgr.Folios, "000000")

        ebFecha.Text = Format(Date.Today, "dd - MMM - yyyy")

        ebCodCliente.Focus()

    End Sub

    'Private Sub CreaEstructuraNegados(ByRef dtNegados As DataTable)

    '    dtNegados = New DataTable("Negados")

    '    With dtNegados
    '        .Columns.Add(New DataColumn("Codigo", GetType(String)))
    '        .Columns.Add(New DataColumn("Talla", GetType(String)))
    '        .Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
    '        .Columns.Add(New DataColumn("Negados", GetType(Integer)))
    '        .Columns.Add(New DataColumn("Motivo", GetType(String)))
    '        .Columns.Add(New DataColumn("MotivoDesc", GetType(String)))
    '        .Columns.Add(New DataColumn("PedidoEC", GetType(String)))
    '        .AcceptChanges()
    '    End With

    'End Sub

    '    Private Function NegarMaterialesPedidosEC(ByVal dtMateriales As DataTable) As DataTable

    '        Dim oRow As DataRow
    '        Dim dtPed As DataTable
    '        Dim dtPedDet As DataTable
    '        'Dim dtTrasModif As DataTable
    '        Dim oFacturaTemp As Factura
    '        Dim dtNegados As DataTable
    '        Dim oNewRow As DataRow
    '        Dim Talla As String = ""

    '        dtPed = oSAPMgr.ZPOL_TRASLPEN(oSAPMgr.Read_Centros, dtPedDet) ', dtTrasModif)

    '        If dtPed.Rows.Count > 0 AndAlso dtPedDet.Rows.Count > 0 Then
    '            Dim dvPedidoDet As DataView

    '            CreaEstructuraNegados(dtNegados)

    '            For Each oRow In dtMateriales.Rows
    '                For Each oRowP As DataRow In dtPed.Rows
    '                    If CStr(oRowP!Status).Trim.ToUpper = "P" Then
    '                        dvPedidoDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowP!Folio_Pedido).Trim & "'", "", DataViewRowState.CurrentRows)
    '                        For Each oRowPD As DataRowView In dvPedidoDet
    '                            If CInt(oRowPD!Cant_Pendiente) <= 0 Then GoTo SiguienteMaterial
    '                            If IsNumeric(oRow!Numero) Then
    '                                Talla = Format(CDec(oRow!Numero), "#.0")
    '                            Else
    '                                Talla = CStr(oRow!Numero).Trim
    '                            End If
    '                            If CStr(oRowPD!Material).Trim.ToUpper = CStr(oRow!CodArticulo).Trim.ToUpper AndAlso CStr(oRowPD!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
    '                                If IsNumeric(Talla) AndAlso InStr(Talla.Trim, ".0") > 0 Then
    '                                    Talla = CInt(oRow!Numero)
    '                                Else
    '                                    Talla = CStr(oRow!Numero).Trim
    '                                End If
    '                                oFacturaTemp = oFacturaMgr.Create()
    '                                oFacturaMgr.GetExistenciaArticulo(CStr(oRow!CodArticulo).Trim, oAppContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)
    '                                If oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad < CInt(oRowPD!Cant_Pendiente) Then
    '                                    oNewRow = dtNegados.NewRow
    '                                    With oNewRow
    '                                        !Codigo = CStr(oRowPD!Material).Trim
    '                                        !Talla = CStr(oRowPD!Talla).Trim
    '                                        !Cantidad = 0
    '                                        !Negados = CInt(oRowPD!Cant_Pendiente) - (oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad)
    '                                        !Motivo = "00011"
    '                                        !MotivoDesc = "Apartado"
    '                                        !PedidoEC = CStr(oRowP!Folio_Pedido).Trim
    '                                    End With
    '                                    dtNegados.Rows.Add(oNewRow)
    '                                End If
    '                                oFacturaTemp = Nothing
    '                                GoTo Siguiente
    '                            End If
    'SiguienteMaterial:
    '                        Next
    '                    End If
    '                Next
    'Siguiente:
    '            Next
    '        End If

    '        Return dtNegados

    '    End Function

    'Private Function ValidarMaterialesDefectuososEC(ByVal dtMateriales As DataTable, ByRef dtDefecEC As DataTable, ByRef UserName As String) As Boolean

    '    Dim oRowM As DataRow
    '    Dim dtDefEC As DataTable
    '    Dim dtTemp As DataTable
    '    Dim oFacturaTemp As Factura
    '    Dim oNewRow As DataRow
    '    Dim Talla As String = ""
    '    Dim Max As Integer = 0, Min As Integer = 0
    '    Dim bRes As Boolean = True

    '    dtDefEC = oSAPMgr.ZPOL_GET_DEFT_CENTRO()

    '    If Not dtDefEC Is Nothing AndAlso dtDefEC.Rows.Count > 0 Then

    '        dtTemp = dtDefEC.Clone
    '        dtTemp.Columns.Add("Minimo", GetType(Integer))
    '        dtTemp.Columns.Add("Maximo", GetType(Integer))
    '        dtTemp.Columns.Add("Motivo", GetType(String))
    '        dtTemp.AcceptChanges()

    '        For Each oRowM In dtMateriales.Rows
    '            For Each oRowDE As DataRow In dtDefEC.Rows
    '                If IsNumeric(oRowM!Numero) Then
    '                    Talla = Format(CDec(oRowM!Numero), "#.0")
    '                Else
    '                    Talla = CStr(oRowM!Numero).Trim
    '                End If
    '                If CStr(oRowDE!Material).Trim.ToUpper = CStr(oRowM!CodArticulo).Trim.ToUpper AndAlso CStr(oRowDE!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
    '                    If IsNumeric(Talla) AndAlso InStr(Talla.Trim, ".0") > 0 Then
    '                        Talla = CInt(oRowM!Numero)
    '                    Else
    '                        Talla = CStr(oRowM!Numero).Trim
    '                    End If
    '                    oFacturaTemp = oFacturaMgr.Create()
    '                    oFacturaMgr.GetExistenciaArticulo(CStr(oRowM!CodArticulo).Trim, oAppContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)
    '                    Max = 0 : Min = 0
    '                    If (oFacturaTemp.FacturaArticuloExistencia - oRowDE!Cantidad) >= oRowM!Cantidad Then
    '                        Min = 0
    '                    Else
    '                        Min = oRowM!Cantidad - (oFacturaTemp.FacturaArticuloExistencia - oRowDE!Cantidad)
    '                    End If
    '                    Max = IIf(oRowDE!Cantidad < oRowM!Cantidad, oRowDE!Cantidad, oRowM!Cantidad)
    '                    oNewRow = dtTemp.NewRow
    '                    With oNewRow
    '                        !Material = CStr(oRowDE!Material).Trim
    '                        !Talla = CStr(oRowDE!Talla).Trim
    '                        !Cantidad = Min
    '                        !Minimo = Min
    '                        !Maximo = Max
    '                        !Motivo = "Apartado con folio "
    '                    End With
    '                    dtTemp.Rows.Add(oNewRow)
    '                    oFacturaTemp = Nothing
    '                    Exit For
    '                End If
    '            Next
    '        Next

    '        If dtTemp.Rows.Count > 0 Then
    '            If UserName.Trim = "" Then
    '                If MessageBox.Show("Existen codigos marcados como de baja calidad que podrian ir en el detalle de esta operación." & vbCrLf & "Es necesario especificarlos." & _
    '                vbCrLf & vbCrLf & "¿Desea continuar con este proceso?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
    '                    bRes = False
    '                End If
    '            End If
    '            If bRes = True Then
    '                Dim oFrmDE As New frmDesmarcarDefectuososEC
    '                oFrmDE.dtSource = dtTemp
    '                oFrmDE.UserDesmarca = UserName.Trim
    '                If oFrmDE.ShowDialog() = DialogResult.OK Then
    '                    dtDefecEC = oFrmDE.dtDefectuososEC.Copy
    '                    UserName = oFrmDE.UserDesmarca.Trim
    '                Else
    '                    MessageBox.Show("Es necesario especificar las piezas marcadas como baja calidad que van en el apartado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    bRes = False
    '                End If
    '            Else
    '                bRes = False
    '            End If
    '        End If
    '    End If

    '    Return bRes

    'End Function

    Private Sub ValidarCambioStatusPedido(ByVal dtNegados As DataTable, ByVal Responsable As String)

        Dim dtPed As DataTable
        Dim dtPedDet As DataTable
        'Dim dtTrasModif As DataTable
        Dim oRowN As DataRow, oRowP As DataRow
        Dim Pedidos As String = ""
        Dim dvPedDet As DataView

        dtPed = oSAPMgr.ZPOL_TRASLPEN(oSAPMgr.Read_Centros, dtPedDet) ', dtTrasModif)

        For Each oRowN In dtNegados.Rows
            If InStr(Pedidos.Trim.ToUpper, CStr(oRowN!PedidoEC).Trim.ToUpper) <= 0 Then
                Pedidos &= CStr(oRowN!PedidoEC).Trim.ToUpper & ","
                dvPedDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowN!PedidoEC).Trim & "' And (Cant_Pendiente > 0 Or Cant_Entregado > 0)", "", DataViewRowState.CurrentRows)
                If dvPedDet.Count <= 0 Then
                    oSAPMgr.ZPOL_ACTTRASL(CStr(oRowN!PedidoEC).Trim, "", "N", "", Responsable.Trim, Nothing, "")
                End If
            End If
        Next

    End Sub

    Private Function ProductosEnAclaracion(ByVal dtProductos As DataTable) As DataTable
        Dim strCentro As String = String.Empty
        Dim oParametros As New Dictionary(Of String, Object)
        Dim dtResult As DataTable

        strCentro = oSAPMgr.Read_Centros


        'Obtener la información para ejecutar la RFC
        With oParametros

            ' ------------------------------------------------------------------
            ' Llenamos datos de los productos
            '------------------------------------------------------------------
            Dim oArticulos As New List(Of Dictionary(Of String, Object))

            For Each oRow As DataRow In dtProductos.Rows

                Dim oArt As New Dictionary(Of String, Object)

                With oArt
                    .Add("WERKS", strCentro)
                    .Add("MATNR", oRow("CodArticulo"))

                End With
                oArticulos.Add(oArt)
            Next

            '------------------------------------------------------------------
            ' Metemos los datos de los articulos para serializarlo a JSON
            '------------------------------------------------------------------
            .Add("SapPiCenmat", oArticulos)
        End With


        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRetail As New ProcesosRetail("/pos_api/s1", "POST")
        dtResult = oRetail.SapZFmProducAclaracion(oParametros)

        Return dtResult

    End Function


    Private Function ValidaContrato() As Boolean
        Dim bRes As Boolean = True

        Try
            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Apartados.Contrato") Then
                oAppContext.Security.CloseImpersonatedSession()
                bRes = False
            Else
                oAppContext.Security.CloseImpersonatedSession()
            End If

        Catch ex As Exception

            bRes = False
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return bRes

    End Function




    Private Sub Sm_GuardarContrato(Optional ByVal bolImprimir As Boolean = False)

        If Not (oContrato Is Nothing) Then

            MsgBox("El Status del Contrato no permite realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If


        If (MessageBox.Show("Se encuentra seguro de Guardar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
            Exit Sub

        End If


        If (Fm_bolTxtValidar() = False) Then

            Exit Sub

        End If

        If ValidaContrato() = False Then
            Exit Sub
        End If

        '----------------------------------------------------------------------------------------------------------------------------------------
        'Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle del apartado
        '----------------------------------------------------------------------------------------------------------------------------------------
        Dim dtNegados As DataTable
        Dim UserNameNiega As String = ""
        Dim dtDefectuososEC As DataTable 'Tabla con los codigos baja calidad EC que el player selecciono que van en la venta
        Dim UserNameDesmarca As String = ""
        Dim dtDefecECSAP As DataTable 'Tabla con los codigos baja calidad EC marcados en SAP
        '-----------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 07/05/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
        Dim dtMateriales As DataTable = GetDataTableFormatNegadosSH(odsContratoDetalle.Tables(0))
        If ValidarMaterialesNegadosSH(dtMateriales, dtNegadosSH, "PF,P,RP") = False Then
            ShowFormNegadosSH(dtNegadosSH)
            Exit Sub
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------
        'Validamos si los codigos del traspaso estan marcados como defectuosos para Ecommerce
        '-----------------------------------------------------------------------------------------------------------------------------------
        Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(odsContratoDetalle.Tables(0), dtMateriales)
        If ValidarMaterialesDefectuososEC(dtArticuloLibre, dtDefectuososEC, UserNameDesmarca, "AP", dtDefecECSAP) = False Then
            Exit Sub
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------
        'Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle del traspaso
        '-----------------------------------------------------------------------------------------------------------------------------------
        If ValidarMaterialesParaNegarEC(dtNegados, dtArticuloLibre, dtDefectuososEC, dtDefecECSAP, UserNameDesmarca, "AP") = False Then
            Exit Sub
        End If




        Dim dtAclaracion As DataTable
        dtAclaracion = ProductosEnAclaracion(dtArticuloLibre)

        '-----------------------------------------------------------------------------------------------------------------------------
        ' MLVARGAS 06/06/2022: Revisamos si hay productos en reserva
        '-----------------------------------------------------------------------------------------------------------------------------
        'If ValidarProductosEnAclaracion(dtAclaracion, dtArticuloLibre) = False Then
        '    Exit Sub
        'End If


        If ValidarProductosEnAclaracionLocal(dtArticuloLibre) = False Then
            Exit Sub
        End If

        ' MLVARGAS Comentado mientras se resuelve
        'If ValidarProductosEnNecesidad(dtAclaracion, dtArticuloLibre) = False Then
        '    Exit Sub
        'End If



        'Dim dtNegados As DataTable
        'Dim UserNameNiega As String = ""
        'dtNegados = NegarMaterialesPedidosEC(odsContratoDetalle.Tables(0))
        'If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
        '    If MessageBox.Show("Hay codigos en el detalle del apartado que se negaran a algun pedido solicitado por Ecommerce" & vbCrLf & _
        '    "Sera necesario identificarse para continuar" & vbCrLf & vbCrLf & "¿Desea continuar con el apartado?", Me.Text, MessageBoxButtons.YesNo, _
        '    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
        '        oAppContext.Security.CloseImpersonatedSession()
        '        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida") = False Then
        '            MessageBox.Show("Es necesario identificarse para continuar", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Exit Sub
        '        Else
        '            UserNameNiega = oAppContext.Security.CurrentUser.Name
        '            oAppContext.Security.CloseImpersonatedSession()
        '        End If
        '    Else
        '        Exit Sub
        '    End If
        'End If
        ''--------------------------------------------------------------------------------------------------------------------------------------------------
        ''Validamos si los codigos del apartado estan marcados como defectuosos para Ecommerce
        ''--------------------------------------------------------------------------------------------------------------------------------------------------
        'Dim dtDefectuososEC As DataTable
        'Dim UserNameDesmarca As String = UserNameNiega
        ''TODO: Ray modif table
        'If ValidarMaterialesDefectuososEC(odsContratoDetalle.Tables(0), dtDefectuososEC, UserNameDesmarca, "AP", Nothing) = False Then
        '    Exit Sub
        'End If


        'Verificar si en el Detalle se aplicaron descuentos.

        'If (Fm_bolValidarAplicDescuento() = True) Then

        '    'Inperzonalizar, validar Usuario Manager.
        '    oAppContext.Security.StartImpersonatedSession()
        '    if (oappcontext.Security.   ) then
        '    End If

        '    oAppContext.Security.CloseImpersonatedSession()

        'oContrato.TipoDescuentoID = cmbTipoDescuento.Text

        'End If

        oContrato = Nothing
        oContrato = oContratoMgr.Create
        With oContrato

            .ID = 0
            .FolioApartado = 0
            .CodCaja = oAppContext.ApplicationConfiguration.NoCaja
            .PlayerID = oPlayer.ID
            .ClienteID = ebCodCliente.Text.Trim().PadLeft(10, "0")
            .ImporteTotal = ebImporteTotal.Text
            .Saldo = ebImporteTotal.Text
            .DescuentoTotal = ebDescuentoTotal.Text
            .IVA = ebIVA.Text
            .ComentarioDesc = String.Empty
            .Usuario = oAppContext.Security.CurrentUser.SessionLoginName
            .StatusRegistro = True
            .Entregada = "N"
            .SerialId = SerialId
            If (Fm_bolValidarAplicDescuento() = True) Then

                oContrato.TipoDescuentoID = "" 'cmbTipoDescuento.Text

            End If

            .Detalle = odsContratoDetalle

        End With


        Dim intContratoID As Integer
        Dim dtContDet As New DataTable
        Dim strDocFI As String
        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim strContrato As String

        'Guardo el datatable
        dtContDet = oContrato.Detalle.Tables("ContratoDetalleTmp" & oAppContext.ApplicationConfiguration.NoCaja)
        oContrato.Referencia = oAppContext.ApplicationConfiguration.Almacen.PadLeft(3, "0") & oAppContext.ApplicationConfiguration.NoCaja.Remove(0, 1) & Format(DateTime.Now, "yyMMddHHmmss")

        'Aqui Guarda el Deportenis Pro
        oContrato.Save()
        Dim facturamgr As New FacturaManager(oAppContext, oConfigCierreFI)
        If oContrato.ID > 0 Then
            facturamgr.SaveSerial(oContrato.SerialId, "S", ebCodCliente.Text.Trim(), 0, oContrato.ID)
        Else
            facturamgr.SaveSerial(oContrato.SerialId, "E", ebCodCliente.Text.Trim(), 0, 0)
        End If
        'fORMATEA "0000000000"
        strContrato = CStr(oContrato.FolioApartado).PadLeft(10, "0")
        '------------------------------------------------------------------------------------------------------------------------------------------------
        'Guardamos en tabla temporalmente los codigos de baja calidad que van en el apartado
        '------------------------------------------------------------------------------------------------------------------------------------------------
        If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
            For Each oRow As DataRow In dtDefectuososEC.Rows
                oFacturaMgr.SaveCodigoBajaCalidad(CStr(oRow!Material), CStr(oRow!Talla), CInt(oRow!Cantidad), CStr(oRow!Motivo), oContrato.FolioApartado, oContrato.CodCaja, "CA")
            Next
        End If
        '------------------------------------------------------------------------------------------------------------------------------------------------
        'Guarda el contrato en sap 
        '------------------------------------------------------------------------------------------------------------------------------------------------
        'Dim oRetail As New ProcesosRetail("/pos/apartados", "POST")
        'strDocFI = oSap.Write_RegistroApartado(strContrato, dtContDet)

        Dim response As New Dictionary(Of String, Object)
        Dim FolioSAP As String = String.Empty

        response = SaveContratoRetail()
        If response.ContainsKey("FolioSAP") Then
            folioSAP = CStr(response("FolioSAP"))
            ' oFactura.FolioFISAP = CStr(response("DocFi"))
            'oFactura.REVALE = CStr(response("FolioRevale"))
        End If



        ' MLVARGAS (24/05/2022) Negar y desmarcar defectuosos

        '---------------------------------------------------------------------------------------------------------------------------
        'Si se guardó correctamente la factura en SAP continuamos con el proceso de los pedidos del EC
        '---------------------------------------------------------------------------------------------------------------------------

        '-----------------------------------------------------------------------------------------------------------------------
        'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario si esta activado el proceso de surtido para
        'EC en la config
        '-----------------------------------------------------------------------------------------------------------------------
        Try
            If FolioSAP.Trim <> "" Then
                If oConfigCierreFI.SurtirEcommerce Then
                    If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                        oSAPMgr.ZPOL_TRASL_NEGAR(FolioSAP, "AP", UserNameNiega, dtNegados)
                        ValidarCambioStatusPedido(dtNegados, UserNameNiega)
                    End If
                End If
            End If
            
            '-----------------------------------------------------------------------------------------------------------------------
            'Se desmarcan los codigos marcados como defectuosos para Ecommerce que van en el apartado
            '-----------------------------------------------------------------------------------------------------------------------
            If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                If oSAPMgr.ZPOL_DEFECTUOSOS_INS(String.Empty, "DD", UserNameDesmarca, dtDefectuososEC).Trim = "Y" Then
                    oFacturaMgr.BorrarCodigosBajaCalidad(oContrato.FolioApartado, oContrato.CodCaja, "CA")
                End If
            End If

            '-----------------------------------------------------------------------------------------------------------------------
            'Se desmarcan los códigos de baja calidad en la base de datos local
            '-----------------------------------------------------------------------------------------------------------------------
            If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                oFacturaMgr.DesmarcaBajaCalidad(dtDefectuososEC)
            End If


        Catch ex As Exception
            EscribeLog(ex.Message, "Error al guardar defectusos y codigos de baja calidad")
            MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        ' End If


        'strDocFI = oRetail.ZBapimm13RegistroApartado(strContrato, dtContDet)

        'If strDocFI.Trim <> "" Then
        '    '------------------------------------------------------------------------------------------------------------------------------------------------
        '    'tambien guarda en la tabla Apartado el DocFi que regresa sap
        '    '------------------------------------------------------------------------------------------------------------------------------------------------
        '    oContratoMgr.SetDocFi(oContrato.ID, strDocFI, strContrato)
        '    '--------------------------------------------------------------------------------------------------------------------------
        '    'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario
        '    '--------------------------------------------------------------------------------------------------------------------------
        '    If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
        '        oSAPMgr.ZPOL_TRASL_NEGAR(strDocFI, "AP", UserNameNiega, dtNegados)
        '        ValidarCambioStatusPedido(dtNegados, UserNameNiega)
        '    End If
        '    '    '--------------------------------------------------------------------------------------------------------------------------
        '    '    'Se desmarcan los codigos marcados como defectuosos para ecommerce que van en la factura
        '    '    '--------------------------------------------------------------------------------------------------------------------------
        '    If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
        '        If oSAPMgr.ZPOL_DEFECTUOSOS_INS(strDocFI, "DD", UserNameDesmarca, dtDefectuososEC).Trim = "Y" Then
        '            oFacturaMgr.BorrarCodigosBajaCalidad(oContrato.FolioApartado, oContrato.CodCaja, "CA")
        '        End If
        '    End If

        'Else
        '    'Si no se graba en SAP 

        'End If

        intContratoID = oContrato.ID

        oContrato = Nothing
        oContrato = oContratoMgr.Load(intContratoID)

        Sm_MostrarInformacion()


        If (bolImprimir = True) Then
            '-----------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 15.11.2013: Imprimimos 1 vez mas el contrato de apartado si esta activa la config de miniprinter termica
            '-----------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.MiniprinterTermica Then Sm_ActionPrint(strDocFI)

            Sm_ActionPrint(strDocFI)

        End If


        MessageBox.Show("La información ha sido Guardada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim oFrmAbonoContrato As New frmAbonosContratos(oContrato.FolioApartado, "AN")

        oFrmAbonoContrato.ShowDialog()
        Me.Close()

    End Sub

    Private Function SaveContratoRetail() As Dictionary(Of String, Object)
        Dim response As New Dictionary(Of String, Object)

        Try
            Dim oProcesarVenta As New Dictionary(Of String, Object)
            With oProcesarVenta
                .Add("I_FECHA_CREACION", Format(oContrato.Fecha, "yyyy-MM-dd"))
                .Add("I_SOLICITANTE", "")
                .Add("I_REQUIERE_FACTURA", "")
                .Add("I_COSTO_ENVIO", 0)
                .Add("I_REFERENCIA", oContrato.Referencia)
                .Add("I_OFICINAVENTAS", "T" & oAppContext.ApplicationConfiguration.Almacen)
                .Add("I_MOT_PEDIDO", "ZAP")
                .Add("I_CLASEDOC", "")
                .Add("I_CANAL", "10")
                .Add("I_CEBE", "")
                .Add("I_CENTRO", "")
                .Add("I_GPOVENDEDOR", "")
                .Add("I_ORGVENTAS", "")
                .Add("I_SECTOR", "")
                .Add("I_VERSION_ID", "")
                .Add("I_REP_VENTAS", ebNumPlayer.Text.Trim())
                .Add("I_FOLIO", "")
                .Add("I_HORA", "")
                .Add("I_USUARIO", "")
                .Add("I_PLAZA", "")
                .Add("I_MONTO_TOTAL", 0)
                .Add("I_SERIALID", oContrato.SerialId)
                ' ------------------------------------------------------------------
                ' Llenamos datos de las Formas de Pago 
                '------------------------------------------------------------------


                ' ------------------------------------------------------------------
                ' Llenamos datos de las Productos 
                '-------------------------------------------------------------------

                Dim oProductos As New List(Of Dictionary(Of String, Object))
                For Each row As DataRow In oContrato.Detalle.Tables("ContratoDetalleTmp" & oAppContext.ApplicationConfiguration.NoCaja).Rows
                    Dim codigo As New Dictionary(Of String, Object)
                    codigo("POSNR") = ""
                    codigo("ORDERITEM_ID") = ""
                    codigo("MATNR") = CStr(row("CodArticulo"))
                    codigo("CANTIDAD") = CInt(row("Cantidad"))
                    codigo("DESCUENTO") = 0
                    codigo("CLASE_CONDICION") = ""
                    codigo("ID_PROMOCION") = ""
                    codigo("ALMACEN") = ""
                    codigo("MOT_RECHAZO") = ""
                    oProductos.Add(codigo)
                Next

                ''------------------------------------------------------------------
                '' Metemos los datos al detalle del objeto para serializarlo a JSON
                ''------------------------------------------------------------------
                .Add("T_PRODUCTOS", oProductos)

            End With
            Dim oRetail As New ProcesosRetail("/pos/ventas", "POST")
            oRetail.Parametros.Add("SerialID", oContrato.SerialId)
            response = oRetail.SapZsdProcesoventa(oProcesarVenta)
            oFacturaMgr.SaveSerial(oContrato.SerialId, "S", ebCodCliente.Text.Trim(), 0, oContrato.ID)
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al generar el apartado en SAP")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return response
    End Function


    Private Sub Sm_AbrirContrato()

        Dim oOpenRecordDlg As New OpenRecordDialog


        oOpenRecordDlg.CurrentView = New ContratoOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            On Error Resume Next

            oContrato = Nothing
            oContrato = oContratoMgr.Load(oOpenRecordDlg.Record.Item("ApartadoID"))

            Sm_MostrarInformacion()

        End If

    End Sub



    Private Sub Sm_CapturaDetalle()

        Dim ofrmCapturaContratos As New frmCapturaContratos


        If Not (oContrato Is Nothing) Then

            MsgBox("El Status del Contrato no permite realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        Else
            ofrmCapturaContratos.ContratoID = 0
        End If


        ofrmCapturaContratos.ShowDialog()

        '<Validación>

        If (ofrmCapturaContratos.DialogResult <> DialogResult.OK) Then

            Exit Sub

        End If

        '</Validación>


        odsContratoDetalle = Nothing
        odsContratoDetalle = oContratoMgr.ActualizarDataSet("[ContratoDetalleSelFromTemporal]", strTablaTmp)

        GridContratoDetalle.DataSource = odsContratoDetalle.Tables(0)

        'GridContratoDetalle.RetrieveStructure()

        Sm_CalcularTotales()

        ofrmCapturaContratos.Dispose()
        ofrmCapturaContratos = Nothing

        uibtnGuardar.Focus()

    End Sub

#End Region

#Region "Métodos Privados [Eventos]"

    Private Sub frmContrato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oContratoMgr = New ContratoManager(oAppContext)

        oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)

        oCatalogoClientesMgr = New ClientesManager(oAppContext)

        oCatalogoPlayersMgr = New CatalogoVendedoresManager(oAppContext)

        oCatalogoTipoDescuentosMgr = New CatalogoTipoDescuentosManager(oAppContext)

        odsCatalogoCorridas = oContratoMgr.ExtraerCatalogoCorridas

        oFirmasMgr = New FirmaManager(oAppContext, oConfigCierreFI)

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        'SendKeys.Send("{Tab}")

        oContratoMgr.CrearTablaTmp()

        Sm_Nuevo()

        uibtnNuevo.Focus()
        'Me.ebCodCliente.Text = 10000015
        'Me.ebCodCliente.Enabled = False
        'uibtnDatosCliente.Enabled = False
        'ebNombreCliente.Text = "APARTADO"

        'If oConfigCierreFI.UsarHuellas = False Then
        '    Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Visible = Janus.Windows.UI.InheritableBoolean.False
        'Else
        '    Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False
        '    If oConfigCierreFI.HuellaOpcional = False Then Me.ebCodCliente.ReadOnly = True
        'End If


    End Sub

    Private Sub frmContratos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        On Error Resume Next

        oContratoMgr = Nothing

        oCatalogoArticulosMgr = Nothing

        oCatalogoClientesMgr = Nothing

        oCatalogoPlayersMgr = Nothing

        oCatalogoTipoDescuentosMgr = Nothing

        odsCatalogoCorridas.Dispose()

        odsCatalogoCorridas = Nothing

        bolSalir = True

    End Sub



    Private Sub frmContratos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter    'Tabulador.

                SendKeys.Send("{TAB}")


            Case Keys.F2     'Grabar.

                Sm_GuardarContrato()


            Case Keys.F9     'Grabar e Imprimir.

                Sm_GuardarContrato(True)

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

                Sm_GuardarContrato()


            Case "menuAbrir"

                Sm_AbrirContrato()


            Case "menuArchivoCerrar"

                Me.Close()

            Case "menuArchivoImprimir"

                Sm_ActionPrint("", True)

            Case "menuSalir"

                bolSalir = True

                Me.Close()

        End Select

    End Sub



    Private Sub uibtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnNuevo.Click

        Sm_Nuevo()

    End Sub



    Private Sub uibtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnGuardar.Click

        Sm_GuardarContrato()

    End Sub



    Private Sub uibtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnAbrir.Click

        Sm_AbrirContrato()

    End Sub




    Private Sub uibtnCapturaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnCapturaDetalle.Click

        Sm_CapturaDetalle()

    End Sub


    Private Sub DatosdeCliente(Optional ByVal ClienteID As String = "", Optional ByVal TipoCliente As String = "")

        Dim ofrmClientesSAP As frmClientesSAP


        If (oCliente Is Nothing) Then

            MsgBox("No ha sido seleccionado un Cliente.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If

        ofrmClientesSAP = New frmClientesSAP

        With ofrmClientesSAP
            .ModuloContrato = True
            .ClienteID = oCliente.CodigoAlterno
            .TipoVenta = "I"
            .TipoCliente = TipoCliente
            .Player = Me.ebNumPlayer.Text
        End With

        ofrmClientesSAP.ShowDialog()

        ofrmClientesSAP.Dispose()

        ofrmClientesSAP = Nothing

    End Sub

    Private Sub uibtnDatosCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnDatosCliente.Click

        AltaDeClientes()

    End Sub

    Private Sub GridContratoDetalle_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridContratoDetalle.SelectionChanged

        SetupView()

    End Sub

    Private Sub ebNumPlayer_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebNumPlayer.ButtonClick

        Sm_BuscarPlayers(True)

    End Sub



    Private Sub ebNumPlayer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumPlayer.KeyDown

        'If (e.KeyCode = Keys.Enter) Then

        '    Sm_BuscarPlayers()

        'ElseIf e.Alt And e.KeyCode = Keys.S Then

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarPlayers(True)

        End If

    End Sub




    Private Sub ebNumPlayer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumPlayer.Validating

        If (bolSalir = True) Then
            Return
        End If

        If (ebNumPlayer.Text.Trim = String.Empty) Then

            ebNumPlayer.Focus()
            Return

        End If

        If (ebNumPlayer.Text.Trim <> String.Empty) Then

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



    Private Sub ebCodCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodCliente.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            If oConfigCierreFI.HuellaOpcional = True Then
                If oConfigCierreFI.UsarDescargaClientes Then
                    Sm_BuscarClientes(True)
                Else
                    LoadSearchFormClientesSAP(True)
                End If
            Else
                ProcesoBusquedaClienteCRM()
            End If

        End If

    End Sub

    Private Sub GuardadoAutomatico(ByVal strClienteID As String, ByVal CodTipoVenta As String)
        Me.pbAvance.Value = 0
        Me.pbAvance.Minimum = 0
        Me.pbAvance.Maximum = 2
        Me.exbGuardarCliente.Left = 212
        Me.exbGuardarCliente.Top = 88
        Me.exbGuardarCliente.Visible = True
        Application.DoEvents()
        Me.pbAvance.Value = 1
        AltaDeClientes(strClienteID, CodTipoVenta)
        Me.pbAvance.Value = 2
        Me.exbGuardarCliente.Visible = False
    End Sub

    Private Sub AltadeCliente()
        'Desbloquear ramiro
        'Dim frmClientes As New CatalogoClientesForm

        'frmClientes.ShowMeforFactura()

        'If frmClientes.DialogResult = DialogResult.OK Then

        '    ebCodCliente.Value = frmClientes.ClienteID
        '    ebNombreCliente.Text = frmClientes.NombreApellidos
        '    ebCodCliente.Focus()

        'Else

        '    ebCodCliente.Value = 0
        '    ebCodCliente.Focus()

        'End If

        'frmClientes.Dispose()
        'frmClientes = Nothing

    End Sub

    Private Sub cmbTipoDescuento_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbTipoDescuento.Validating


        'If (bolSalir = True) Then
        '    Return
        'End If

        If (cmbTipoDescuento.Text.Trim = String.Empty) Then

            cmbTipoDescuento.Focus()
            Return

        End If

        'If (cmbTipoDescuento.Text.Trim = String.Empty) Then

        '    MsgBox("El Tipo de Descuento no es Valido.", MsgBoxStyle.Exclamation, "DPTienda")
        '    e.Cancel = True

        'End If

    End Sub



    Private Sub ebCodCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodCliente.ButtonClick

        If oConfigCierreFI.HuellaOpcional = True Then
            If oConfigCierreFI.UsarDescargaClientes Then
                Sm_BuscarClientes(True)
            Else
                LoadSearchFormClientesSAP(True)
            End If
        Else
            ProcesoBusquedaClienteCRM()
        End If

    End Sub

    Private Sub ebCodCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodCliente.GotFocus

        'If oConfigCierreFI.UsarHuellas = True AndAlso Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False Then

        '    Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.True

        'End If

    End Sub

    Private Sub ebCodCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodCliente.LostFocus

        'If bolSalir = False Then

        '    If oConfigCierreFI.UsarHuellas = True AndAlso Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.True Then

        '        Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False

        '    End If

        'End If

    End Sub

    Private Sub ebCodCliente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodCliente.Validating

        If Me.ebCodCliente.Text.Trim <> "" Then
            ValidaCliente()
        End If

    End Sub

#End Region

#Region "Facturacion SiHay"

    Private Function GetDataTableFormatNegadosSH(ByVal traspaso As DataTable) As DataTable
        Dim dtArticulos As New DataTable
        dtArticulos.Columns.Add("Codigo", GetType(String))
        dtArticulos.Columns.Add("Talla", GetType(String))
        dtArticulos.Columns.Add("Cantidad", GetType(Integer))
        For Each oRow As DataRow In traspaso.Rows
            Dim row As DataRow = dtArticulos.NewRow()
            row("Codigo") = CStr(oRow!CodArticulo)
            row("Talla") = CStr(oRow!Numero)
            row("Cantidad") = CInt(oRow!Cantidad)
            dtArticulos.Rows.Add(row)
        Next
        Return dtArticulos
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 08/05/2013: Envia el detalle con las cantidades libres Negadas
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function GetDetalleCantidadesLibres(ByVal dtDetalles As DataTable, ByVal dtMaterialesLibres As DataTable) As DataTable
        Dim dtArticulosLibres As DataTable = dtDetalles.Copy()
        dtArticulosLibres.Columns.Add("Libres", GetType(Integer))
        If Not dtMaterialesLibres Is Nothing Then
            For Each row As DataRow In dtArticulosLibres.Rows
                Dim codigo As String = CStr(row!CodArticulo)
                Dim talla As String = CStr(row!Numero)
                Dim cantidad As Integer = CInt(row!Cantidad)
                Dim suma As Decimal = dtMaterialesLibres.Compute("SUM(Libres)", "Codigo='" & codigo & "' AND Talla='" & talla & "'")
                row("Libres") = suma
            Next
            dtArticulosLibres.AcceptChanges()
        End If
        Return dtArticulosLibres
    End Function

#End Region

End Class
