Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoTarjetas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoPromocionesAU
Imports System.IO
Imports System.Collections.Generic


Public Class frmAbonosContratos

    Inherits System.Windows.Forms.Form

    Dim booleHub As Boolean = False
    Dim strTarjBloq As String
    Dim intPromo As Integer = 0
    Dim mPosEntryM As Integer = 0
    Dim strCriptogramaM As String = ""
    Dim TipoMov As String = ""

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(Optional ByVal FolioContrato As Integer = 0, Optional ByVal TipoMovimiento As String = "AN")
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        TipoMov = TipoMovimiento
        intFolioContrato = FolioContrato
        strTipoMovieminto = TipoMovimiento

        If TipoMovimiento = "AN" Then
            ebNumApartado.Enabled = False
        Else
            ebNumApartado.Enabled = True
        End If

        'If Not FolioContrato = String.Empty Then

        '    Sm_Nuevo()

        '    Me.ebNumApartado.Text = FolioContrato
        '    Me.ebCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
        '    Sm_BuscarApartado()

        'End If

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
    Friend WithEvents ccFechaApartado As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ebSaldoActual As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebNumTarjeta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents LblNoTarjeta As System.Windows.Forms.Label
    Friend WithEvents ebNumAut As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents UiCTipoTarjeta As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ebTotalaPagar As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ebAbono As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebNumApartado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNumAbono As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDesCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDesVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSaldoNuevo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ebNumCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ebNumVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ccFechaAbono As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoArticulo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTDescuento As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTVenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ebCodCaja As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents uIProgressBar1 As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents cmbFormaPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents CmbBancos As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtCVV2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPromocion As System.Windows.Forms.Label
    Friend WithEvents cmbPromocion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnLeerTarjeta As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbonosContratos))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebNumAut = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnLeerTarjeta = New Janus.Windows.EditControls.UIButton()
        Me.cmbPromocion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblPromocion = New System.Windows.Forms.Label()
        Me.txtCVV2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbBancos = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbFormaPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.uIProgressBar1 = New Janus.Windows.EditControls.UIProgressBar()
        Me.ebCodCaja = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ccFechaApartado = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ebSaldoActual = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebNumTarjeta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.LblNoTarjeta = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.UiCTipoTarjeta = New Janus.Windows.EditControls.UIComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ebTotalaPagar = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ebAbono = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebNumApartado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNumAbono = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDesCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDesVendedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSaldoNuevo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ebNumCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ebNumVendedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ccFechaAbono = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaAcerca2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuCatalogo = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogo")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaAcerca1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.menuCatalogoArticulo = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoArticulo")
        Me.menuCatalogoTDescuento = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTDescuento")
        Me.menuCatalogoTVenta = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTVenta")
        Me.menuAyudaTAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTAyuda")
        Me.menuAyudaAcerca = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
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
        Me.ExplorerBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ebNumAut)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Controls.Add(Me.btnLeerTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.cmbPromocion)
        Me.ExplorerBar1.Controls.Add(Me.lblPromocion)
        Me.ExplorerBar1.Controls.Add(Me.txtCVV2)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.CmbBancos)
        Me.ExplorerBar1.Controls.Add(Me.cmbFormaPago)
        Me.ExplorerBar1.Controls.Add(Me.uIProgressBar1)
        Me.ExplorerBar1.Controls.Add(Me.ebCodCaja)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.ccFechaApartado)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.ebSaldoActual)
        Me.ExplorerBar1.Controls.Add(Me.ebNumTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.LblNoTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.UiCTipoTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.ebTotalaPagar)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.ebAbono)
        Me.ExplorerBar1.Controls.Add(Me.ebNumApartado)
        Me.ExplorerBar1.Controls.Add(Me.ebNumAbono)
        Me.ExplorerBar1.Controls.Add(Me.ebDesCliente)
        Me.ExplorerBar1.Controls.Add(Me.ebDesVendedor)
        Me.ExplorerBar1.Controls.Add(Me.ebSaldoNuevo)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label19)
        Me.ExplorerBar1.Controls.Add(Me.Label20)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.ebNumCliente)
        Me.ExplorerBar1.Controls.Add(Me.Label15)
        Me.ExplorerBar1.Controls.Add(Me.ebNumVendedor)
        Me.ExplorerBar1.Controls.Add(Me.Label14)
        Me.ExplorerBar1.Controls.Add(Me.ccFechaAbono)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Abono o Anticipo"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 48)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(650, 585)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebNumAut
        '
        Me.ebNumAut.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumAut.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumAut.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebNumAut.Location = New System.Drawing.Point(432, 240)
        Me.ebNumAut.MaxLength = 20
        Me.ebNumAut.Name = "ebNumAut"
        Me.ebNumAut.Size = New System.Drawing.Size(120, 22)
        Me.ebNumAut.TabIndex = 12
        Me.ebNumAut.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumAut.Visible = False
        Me.ebNumAut.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = "0"
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(368, 240)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 23)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "No. Aut:"
        Me.Label11.Visible = False
        '
        'btnLeerTarjeta
        '
        Me.btnLeerTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerTarjeta.Icon = CType(resources.GetObject("btnLeerTarjeta.Icon"), System.Drawing.Icon)
        Me.btnLeerTarjeta.Location = New System.Drawing.Point(360, 265)
        Me.btnLeerTarjeta.Name = "btnLeerTarjeta"
        Me.btnLeerTarjeta.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerTarjeta.TabIndex = 14
        Me.btnLeerTarjeta.Visible = False
        Me.btnLeerTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cmbPromocion
        '
        Me.cmbPromocion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbPromocion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbPromocion.DesignTimeLayout = GridEXLayout1
        Me.cmbPromocion.Enabled = False
        Me.cmbPromocion.Location = New System.Drawing.Point(152, 296)
        Me.cmbPromocion.Name = "cmbPromocion"
        Me.cmbPromocion.Size = New System.Drawing.Size(208, 23)
        Me.cmbPromocion.TabIndex = 15
        Me.cmbPromocion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbPromocion.Visible = False
        Me.cmbPromocion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPromocion
        '
        Me.lblPromocion.AccessibleDescription = "0"
        Me.lblPromocion.BackColor = System.Drawing.Color.Transparent
        Me.lblPromocion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblPromocion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPromocion.Location = New System.Drawing.Point(32, 296)
        Me.lblPromocion.Name = "lblPromocion"
        Me.lblPromocion.Size = New System.Drawing.Size(104, 23)
        Me.lblPromocion.TabIndex = 127
        Me.lblPromocion.Text = "Promoción:"
        Me.lblPromocion.Visible = False
        '
        'txtCVV2
        '
        Me.txtCVV2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCVV2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCVV2.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Enabled = False
        Me.txtCVV2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Location = New System.Drawing.Point(480, 240)
        Me.txtCVV2.Name = "txtCVV2"
        Me.txtCVV2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCVV2.Size = New System.Drawing.Size(72, 22)
        Me.txtCVV2.TabIndex = 12
        Me.txtCVV2.Text = "123"
        Me.txtCVV2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCVV2.Visible = False
        Me.txtCVV2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = "0"
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(400, 240)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 16)
        Me.Label9.TabIndex = 126
        Me.Label9.Text = "CVV2:"
        Me.Label9.Visible = False
        '
        'CmbBancos
        '
        Me.CmbBancos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.CmbBancos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.CmbBancos.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.CmbBancos.DesignTimeLayout = GridEXLayout2
        Me.CmbBancos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBancos.Location = New System.Drawing.Point(296, 237)
        Me.CmbBancos.Name = "CmbBancos"
        Me.CmbBancos.Size = New System.Drawing.Size(64, 22)
        Me.CmbBancos.TabIndex = 11
        Me.CmbBancos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.CmbBancos.Visible = False
        Me.CmbBancos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbFormaPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbFormaPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.cmbFormaPago.DesignTimeLayout = GridEXLayout3
        Me.cmbFormaPago.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.Location = New System.Drawing.Point(400, 209)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(152, 22)
        Me.cmbFormaPago.TabIndex = 9
        Me.cmbFormaPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbFormaPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uIProgressBar1
        '
        Me.uIProgressBar1.Location = New System.Drawing.Point(24, 328)
        Me.uIProgressBar1.Name = "uIProgressBar1"
        Me.uIProgressBar1.Size = New System.Drawing.Size(544, 3)
        Me.uIProgressBar1.TabIndex = 121
        '
        'ebCodCaja
        '
        Me.ebCodCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodCaja.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebCodCaja.Location = New System.Drawing.Point(152, 69)
        Me.ebCodCaja.MaxLength = 2
        Me.ebCodCaja.Name = "ebCodCaja"
        Me.ebCodCaja.Size = New System.Drawing.Size(112, 22)
        Me.ebCodCaja.TabIndex = 1
        Me.ebCodCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(432, 472)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(120, 23)
        Me.Label22.TabIndex = 120
        Me.Label22.Text = "Graba/Imprimir"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(403, 472)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(29, 23)
        Me.Label21.TabIndex = 119
        Me.Label21.Text = "F9"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(64, 472)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 23)
        Me.Label16.TabIndex = 118
        Me.Label16.Text = "Grabar"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(35, 472)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 23)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "F2"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(32, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Fecha Contrato:"
        '
        'ccFechaApartado
        '
        Me.ccFechaApartado.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.ccFechaApartado.DropDownCalendar.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ccFechaApartado.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccFechaApartado.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ccFechaApartado.Location = New System.Drawing.Point(152, 125)
        Me.ccFechaApartado.Name = "ccFechaApartado"
        Me.ccFechaApartado.ReadOnly = True
        Me.ccFechaApartado.Size = New System.Drawing.Size(128, 22)
        Me.ccFechaApartado.TabIndex = 3
        Me.ccFechaApartado.TabStop = False
        Me.ccFechaApartado.Value = New Date(1, 2, 1, 0, 0, 0, 0)
        Me.ccFechaApartado.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = "0"
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(32, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "No. Caja:"
        '
        'ebSaldoActual
        '
        Me.ebSaldoActual.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoActual.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoActual.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoActual.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebSaldoActual.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSaldoActual.Location = New System.Drawing.Point(152, 336)
        Me.ebSaldoActual.MaxLength = 8
        Me.ebSaldoActual.Name = "ebSaldoActual"
        Me.ebSaldoActual.ReadOnly = True
        Me.ebSaldoActual.Size = New System.Drawing.Size(224, 22)
        Me.ebSaldoActual.TabIndex = 15
        Me.ebSaldoActual.TabStop = False
        Me.ebSaldoActual.Text = "$0.00"
        Me.ebSaldoActual.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoActual.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNumTarjeta
        '
        Me.ebNumTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumTarjeta.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumTarjeta.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebNumTarjeta.Location = New System.Drawing.Point(152, 265)
        Me.ebNumTarjeta.MaxLength = 0
        Me.ebNumTarjeta.Name = "ebNumTarjeta"
        Me.ebNumTarjeta.ReadOnly = True
        Me.ebNumTarjeta.Size = New System.Drawing.Size(208, 22)
        Me.ebNumTarjeta.TabIndex = 13
        Me.ebNumTarjeta.TabStop = False
        Me.ebNumTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumTarjeta.Visible = False
        Me.ebNumTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'LblNoTarjeta
        '
        Me.LblNoTarjeta.AccessibleDescription = "0"
        Me.LblNoTarjeta.BackColor = System.Drawing.Color.Transparent
        Me.LblNoTarjeta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblNoTarjeta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblNoTarjeta.Location = New System.Drawing.Point(32, 265)
        Me.LblNoTarjeta.Name = "LblNoTarjeta"
        Me.LblNoTarjeta.Size = New System.Drawing.Size(104, 23)
        Me.LblNoTarjeta.TabIndex = 19
        Me.LblNoTarjeta.Text = "No. Tarjeta:"
        Me.LblNoTarjeta.Visible = False
        '
        'Label10
        '
        Me.Label10.AccessibleDescription = "0"
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(216, 237)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "Cod Banco:"
        Me.Label10.Visible = False
        '
        'UiCTipoTarjeta
        '
        Me.UiCTipoTarjeta.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.UiCTipoTarjeta.DropListFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UiCTipoTarjeta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UiCTipoTarjeta.Location = New System.Drawing.Point(152, 237)
        Me.UiCTipoTarjeta.Name = "UiCTipoTarjeta"
        Me.UiCTipoTarjeta.Size = New System.Drawing.Size(48, 22)
        Me.UiCTipoTarjeta.TabIndex = 10
        Me.UiCTipoTarjeta.Visible = False
        Me.UiCTipoTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = "0"
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(32, 237)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Tipo Tarjeta:"
        Me.Label7.Visible = False
        '
        'ebTotalaPagar
        '
        Me.ebTotalaPagar.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalaPagar.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalaPagar.BackColor = System.Drawing.Color.Ivory
        Me.ebTotalaPagar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ebTotalaPagar.ForeColor = System.Drawing.Color.Black
        Me.ebTotalaPagar.Location = New System.Drawing.Point(240, 432)
        Me.ebTotalaPagar.Name = "ebTotalaPagar"
        Me.ebTotalaPagar.ReadOnly = True
        Me.ebTotalaPagar.Size = New System.Drawing.Size(136, 22)
        Me.ebTotalaPagar.TabIndex = 18
        Me.ebTotalaPagar.TabStop = False
        Me.ebTotalaPagar.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTotalaPagar.Visible = False
        Me.ebTotalaPagar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = "0"
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(32, 432)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Total a Pagar + Comision:"
        Me.Label3.Visible = False
        '
        'ebAbono
        '
        Me.ebAbono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAbono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAbono.BackColor = System.Drawing.Color.Ivory
        Me.ebAbono.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.ebAbono.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebAbono.Location = New System.Drawing.Point(152, 368)
        Me.ebAbono.MaxLength = 8
        Me.ebAbono.Name = "ebAbono"
        Me.ebAbono.Size = New System.Drawing.Size(224, 23)
        Me.ebAbono.TabIndex = 16
        Me.ebAbono.TabStop = False
        Me.ebAbono.Text = "$0.00"
        Me.ebAbono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebAbono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNumApartado
        '
        Me.ebNumApartado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumApartado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumApartado.ButtonImage = CType(resources.GetObject("ebNumApartado.ButtonImage"), System.Drawing.Image)
        Me.ebNumApartado.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebNumApartado.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebNumApartado.Location = New System.Drawing.Point(152, 97)
        Me.ebNumApartado.MaxLength = 10
        Me.ebNumApartado.Name = "ebNumApartado"
        Me.ebNumApartado.Size = New System.Drawing.Size(112, 22)
        Me.ebNumApartado.TabIndex = 2
        Me.ebNumApartado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumApartado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNumAbono
        '
        Me.ebNumAbono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumAbono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumAbono.ButtonImage = CType(resources.GetObject("ebNumAbono.ButtonImage"), System.Drawing.Image)
        Me.ebNumAbono.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebNumAbono.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebNumAbono.Location = New System.Drawing.Point(152, 41)
        Me.ebNumAbono.MaxLength = 4
        Me.ebNumAbono.Name = "ebNumAbono"
        Me.ebNumAbono.Size = New System.Drawing.Size(112, 22)
        Me.ebNumAbono.TabIndex = 0
        Me.ebNumAbono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumAbono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDesCliente
        '
        Me.ebDesCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDesCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDesCliente.BackColor = System.Drawing.Color.Ivory
        Me.ebDesCliente.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebDesCliente.Location = New System.Drawing.Point(264, 153)
        Me.ebDesCliente.Name = "ebDesCliente"
        Me.ebDesCliente.ReadOnly = True
        Me.ebDesCliente.Size = New System.Drawing.Size(288, 22)
        Me.ebDesCliente.TabIndex = 5
        Me.ebDesCliente.TabStop = False
        Me.ebDesCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDesCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDesVendedor
        '
        Me.ebDesVendedor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDesVendedor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDesVendedor.BackColor = System.Drawing.Color.Ivory
        Me.ebDesVendedor.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebDesVendedor.Location = New System.Drawing.Point(264, 181)
        Me.ebDesVendedor.Name = "ebDesVendedor"
        Me.ebDesVendedor.ReadOnly = True
        Me.ebDesVendedor.Size = New System.Drawing.Size(288, 22)
        Me.ebDesVendedor.TabIndex = 7
        Me.ebDesVendedor.TabStop = False
        Me.ebDesVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDesVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSaldoNuevo
        '
        Me.ebSaldoNuevo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoNuevo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoNuevo.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoNuevo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ebSaldoNuevo.ForeColor = System.Drawing.Color.Red
        Me.ebSaldoNuevo.Location = New System.Drawing.Point(240, 400)
        Me.ebSaldoNuevo.Name = "ebSaldoNuevo"
        Me.ebSaldoNuevo.ReadOnly = True
        Me.ebSaldoNuevo.Size = New System.Drawing.Size(136, 22)
        Me.ebSaldoNuevo.TabIndex = 17
        Me.ebSaldoNuevo.TabStop = False
        Me.ebSaldoNuevo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSaldoNuevo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = "0"
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(32, 400)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(200, 16)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Saldo Despues de Abono:"
        '
        'Label5
        '
        Me.Label5.AccessibleDescription = "0"
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(32, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 23)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "No. Contrato:"
        '
        'Label19
        '
        Me.Label19.AccessibleDescription = "0"
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(32, 368)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 17)
        Me.Label19.TabIndex = 24
        Me.Label19.Text = "Abono:"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(32, 336)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 23)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Saldo Actual:"
        '
        'Label17
        '
        Me.Label17.AccessibleDescription = "0"
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(288, 209)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 16)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Forma de Pago:"
        '
        'ebNumCliente
        '
        Me.ebNumCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumCliente.BackColor = System.Drawing.Color.Ivory
        Me.ebNumCliente.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebNumCliente.Location = New System.Drawing.Point(152, 153)
        Me.ebNumCliente.Name = "ebNumCliente"
        Me.ebNumCliente.ReadOnly = True
        Me.ebNumCliente.Size = New System.Drawing.Size(104, 22)
        Me.ebNumCliente.TabIndex = 4
        Me.ebNumCliente.TabStop = False
        Me.ebNumCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.AccessibleDescription = "0"
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(32, 157)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 23)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Cliente:"
        '
        'ebNumVendedor
        '
        Me.ebNumVendedor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumVendedor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumVendedor.BackColor = System.Drawing.Color.Ivory
        Me.ebNumVendedor.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebNumVendedor.Location = New System.Drawing.Point(152, 181)
        Me.ebNumVendedor.Name = "ebNumVendedor"
        Me.ebNumVendedor.ReadOnly = True
        Me.ebNumVendedor.Size = New System.Drawing.Size(104, 22)
        Me.ebNumVendedor.TabIndex = 6
        Me.ebNumVendedor.TabStop = False
        Me.ebNumVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(32, 184)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 23)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Player:"
        '
        'ccFechaAbono
        '
        Me.ccFechaAbono.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.ccFechaAbono.DropDownCalendar.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ccFechaAbono.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccFechaAbono.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ccFechaAbono.Location = New System.Drawing.Point(152, 209)
        Me.ccFechaAbono.Name = "ccFechaAbono"
        Me.ccFechaAbono.ReadOnly = True
        Me.ccFechaAbono.Size = New System.Drawing.Size(128, 22)
        Me.ccFechaAbono.TabIndex = 8
        Me.ccFechaAbono.TabStop = False
        Me.ccFechaAbono.Value = New Date(1, 2, 1, 0, 0, 0, 0)
        Me.ccFechaAbono.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(32, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 23)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Fecha de Abono:"
        '
        'Label18
        '
        Me.Label18.AccessibleDescription = "0"
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(32, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 23)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "No. Abono:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(32, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 23)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Prom. Desc:"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuCatalogo, Me.menuAyuda, Me.menuSalir, Me.menuArchivoNuevo, Me.menuAbrir, Me.menuArchivoGuardar, Me.menuArchivoImprimir, Me.menuCatalogoArticulo, Me.menuCatalogoTDescuento, Me.menuCatalogoTVenta, Me.menuAyudaTAyuda, Me.menuAyudaAcerca})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("6444d20e-a2d5-47da-893a-4e220a56c093")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
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
        Me.UiCommandBar1.FloatingSize = New System.Drawing.Size(129, 30)
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(578, 22)
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
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.Separator4, Me.menuAbrir2, Me.Separator5, Me.menuArchivoGuardar2, Me.Separator6, Me.menuAyudaAcerca2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.Size = New System.Drawing.Size(304, 28)
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
        'menuAyudaAcerca2
        '
        Me.menuAyudaAcerca2.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca2.Name = "menuAyudaAcerca2"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir1, Me.Separator1, Me.menuArchivoNuevo1, Me.Separator2, Me.menuArchivoGuardar1, Me.Separator3, Me.menuSalir1})
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
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
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
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'menuCatalogo
        '
        Me.menuCatalogo.Key = "menuCatalogo"
        Me.menuCatalogo.Name = "menuCatalogo"
        Me.menuCatalogo.Text = "Catalogo"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaAcerca1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ay&uda"
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
        Me.menuSalir.Text = "&Salir"
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
        Me.menuArchivoImprimir.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Name = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Text = "Imprimir"
        '
        'menuCatalogoArticulo
        '
        Me.menuCatalogoArticulo.Key = "menuCatalogoArticulo"
        Me.menuCatalogoArticulo.Name = "menuCatalogoArticulo"
        Me.menuCatalogoArticulo.Text = "CatalogoArticulo"
        '
        'menuCatalogoTDescuento
        '
        Me.menuCatalogoTDescuento.Key = "menuCatalogoTDescuento"
        Me.menuCatalogoTDescuento.Name = "menuCatalogoTDescuento"
        Me.menuCatalogoTDescuento.Text = "CatalogoTDescuento"
        '
        'menuCatalogoTVenta
        '
        Me.menuCatalogoTVenta.Key = "menuCatalogoTVenta"
        Me.menuCatalogoTVenta.Name = "menuCatalogoTVenta"
        Me.menuCatalogoTVenta.Text = "CatalogoTVenta"
        '
        'menuAyudaTAyuda
        '
        Me.menuAyudaTAyuda.Key = "menuAyudaTAyuda"
        Me.menuAyudaTAyuda.Name = "menuAyudaTAyuda"
        Me.menuAyudaTAyuda.Text = "AyudaTAyuda"
        '
        'menuAyudaAcerca
        '
        Me.menuAyudaAcerca.Image = CType(resources.GetObject("menuAyudaAcerca.Image"), System.Drawing.Image)
        Me.menuAyudaAcerca.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Name = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Text = "A&cerca de"
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
        Me.TopRebar1.Size = New System.Drawing.Size(578, 50)
        '
        'frmAbonosContratos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(578, 544)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmAbonosContratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Abonos ó Anticipos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
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



    Private oAbonosApartadosMgr As AbonosApartadosManager
    Private oAbonosApartados As AbonosApartados

    Private oClienteMgr As New ClientesManager(oAppContext)
    Private oCliente As ClienteAlterno

    Private oCatalogoVendedoresMgr As New CatalogoVendedoresManager(oAppContext)
    Private oVendedor As Vendedor

    Private oContratosMgr As New ContratoManager(oAppContext)
    Public oContratos As Contrato

    Private oCatalogoFormasPagoMgr As New CatalogoFormasPagoManager(oAppContext)
    Private oCatalogoFormasPago As FormaPago

    Private oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)

    Private oCatalogoPromoMgr As New CatalogoPromocionesManager(oAppContext, oConfigCierreFI)

    Private oCatalogoBancosMgr As New CatalogoBancosManager(oAppContext)

    Dim dtFormasPago As DataTable
    Dim dtPromociones As New DataTable
    Dim vImporteApartado As Decimal
    Dim vlComisionBancaria As Decimal
    Dim vlIngresoComision As Decimal
    Dim vlIvaComision As Decimal

    Dim bandImprimir As Boolean = True

    Dim bolGuardar As Boolean = True

    Private intFolioContrato As Integer
    Private strTipoMovieminto As String

    Private eHub As Boolean = False
    Private AbonoGuardado As Boolean = False

    Dim strAfiliacion As String = ""
    Dim strNombreBanco As String = ""
    Dim strVencM As String = ""
    Dim strNombreM As String = ""
    Dim dtPgoTarjeta As DataTable



#End Region


#Region "Métodos Miembros"

    Private Function Fm_bolTxtValidar(Optional ByVal Vpa_strOpcion As String = "") As Boolean

        If (Vpa_strOpcion = "Guardar") Then

            ebNumAbono.Text = ebNumAbono.Text.Trim

            If (ebNumAbono.Text = String.Empty) Then
                MessageBox.Show("Debe especificar un Folio de Abono", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebNumAbono.Focus()
                Exit Function
            End If

            If (ebNumAbono.Text.Trim = 0) Then
                MessageBox.Show("Debe especificar un Folio de Abono", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebNumAbono.Focus()
                Exit Function
            End If


        End If

        If (ebNumApartado.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar un Folio de Apartado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ebNumApartado.Focus()
            Exit Function
        End If

        If (ebNumCliente.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar el Codigo de Cliente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ebNumCliente.Focus()
            Exit Function
        End If

        If (ebDesCliente.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar el Nombre de Cliente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ebDesCliente.Focus()
            Exit Function
        End If

        If (ebNumVendedor.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar el Codigo de Player", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ebNumVendedor.Focus()
            Exit Function
        End If

        If (ebDesVendedor.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar el Nombre de Player", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ebDesVendedor.Focus()
            Exit Function
        End If


        'If (UiCFormaPago.Text.Trim = String.Empty) Then
        If (cmbFormaPago.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar la Forma de Pago", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbFormaPago.Focus()
            Exit Function
        End If

        If cmbFormaPago.Value = "TACR" Or cmbFormaPago.Value = "TADB" Then

            If (UiCTipoTarjeta.Text.Trim = String.Empty) Then
                MessageBox.Show("Debe especificar el Tipo de Tarjeta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                UiCTipoTarjeta.Focus()
                Exit Function
            End If
            '---------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 27/01/2017: Validara el número de tarjeta solo cuando sea el servicio Bancomer
            '---------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.PagosBanamex = False Then
                If (ebNumTarjeta.Text.Trim = String.Empty OrElse ebNumTarjeta.Text = "Deslize Tarjeta ...") Then
                    MessageBox.Show("Debe especificar el Numero de Tarjeta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ebNumTarjeta.Focus()
                    Exit Function
                End If
            End If

            If (Me.UiCTipoTarjeta.Text = "TM") Then
                If (ebNumAut.Text.Trim = String.Empty) Then
                    MessageBox.Show("Debe especificar el Numero de Autorización", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ebNumAut.Focus()
                    Exit Function
                End If
            End If

            If Me.UiCTipoTarjeta.Text = "TM" And Me.cmbPromocion.Text = "" Then
                MessageBox.Show("Es necesario seleccionar una promoción.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.cmbPromocion.Focus()
                Exit Function
            End If
        End If

        If (ebAbono.Text.Trim = String.Empty Or ebAbono.Value <= 0) Then
            MessageBox.Show("Debe especificar el Monto del Abono", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ebAbono.Focus()
            Exit Function
        End If

        If (ebSaldoActual.Text.Trim = String.Empty Or ebSaldoActual.Text.Trim = 0) Then
            MessageBox.Show("Debe especificar el Saldo Actual", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ebSaldoActual.Focus()
            Exit Function
        End If

        If (ebSaldoNuevo.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar el Saldo Nuevo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ebSaldoNuevo.Focus()
            Exit Function
        End If

        If (ccFechaAbono.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar la Fecha de Abono", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ccFechaAbono.Focus()
            Exit Function
        End If

        If (ccFechaApartado.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar la Fecha de Contrato", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ccFechaApartado.Focus()
            Exit Function
        End If

        Return True

    End Function


    Private Sub Sm_Nuevo()


        If TipoMov = "AN" Then
            Exit Sub
        End If

        Dim x As Integer

        CLearFields()
        DesBloquearFields()
        FieldsTarjetaNoVisible()

        ebNumAbono.Text = oAbonosApartadosMgr.Folios()
        ebNumAbono.Enabled = False
        Me.ebNumApartado.Focus()
        'eHub = False
        AbonoGuardado = False

        On Error Resume Next
        oAbonosApartados = Nothing
        Me.ebNumApartado.Focus()
        bolGuardar = True

    End Sub

    Private Function ValidaAbono() As Boolean
        Dim bRes As Boolean = True

        Try
            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Apartados.AgregarAbono") Then
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


    Private Sub Sm_Guardar()
        Dim vlPAbono As Decimal
        Dim vlPorcentajeAbono As Integer
        Dim vebAbono As Decimal
        Dim vebSaldoActual As Decimal

      
        AbonoValidating()

        If (oAbonosApartados Is Nothing) Then   'Opción Guardar.

            If (Fm_bolTxtValidar("Guardar") = False) Then
                Exit Sub
            End If

            If (MessageBox.Show("¿ Desea Grabar el Abono ?", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                Exit Sub
            End If


            '-----------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 16/01/2017: Configuración para Pagos Banamex
            '-----------------------------------------------------------------------------------------------------------------------

            If oConfigCierreFI.PagosBanamex = True Then
                Dim CodFormaPago As String = CStr(cmbFormaPago.Value)
                Select Case CodFormaPago
                    Case "TACR", "TADB"
                        If AddFormaPagoBanamex() = False Then
                            Exit Sub
                        End If
                End Select
            End If
         



            If Me.eHub = False Then
                Me.UiCTipoTarjeta.Text = "TM"
                Me.UiCTipoTarjeta.Focus()
                Me.ebAbono.Focus()
            End If


            If Not ValidaAbono() Then
                Exit Sub
            End If


            'Validación para el primer abono que sea mayor del % configurado
            vebAbono = (ebAbono.Text)
            vebSaldoActual = (ebSaldoActual.Text)

            If vImporteApartado = vebSaldoActual Then

                vlPAbono = (vebSaldoActual * (oAppContext.ApplicationConfiguration.MinPrimerAbono / 100))
                If vebAbono < vlPAbono Then

                    MessageBox.Show("El Monto del Primer Abono debe ser igual o mayor al " & oAppContext.ApplicationConfiguration.MinPrimerAbono & " % ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    Me.ebAbono.Value = CDbl(Me.ebSaldoActual.Text) * (oAppContext.ApplicationConfiguration.MinPrimerAbono / 100)
                    ebAbono.Focus()
                    AbonoValidating()
                    Exit Sub
                End If

            End If

            If vebAbono > vebSaldoActual Then
                MessageBox.Show("El Monto de Abono es mayor que el Saldo Actual", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                ebAbono.Focus()
                Exit Sub
            End If

            oAbonosApartados = oAbonosApartadosMgr.Create
            '***********************Declaraciones SAP******************************
            Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim strDocFi As String
            Dim strTienda As String
            Dim strTipoPago As String
            Dim strFolioAbono As String
            Dim strDivision As String = ""

            If cmbFormaPago.Value = "EFEC" Then
                strTipoPago = "EFECTIVO"
                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, oSap.Read_Centros)

            ElseIf CmbBancos.Value = "T1" Then
                '"BANCOMER" 
                strTipoPago = "TARJETA 1"
                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, oSap.Read_Centros)
            ElseIf CmbBancos.Value = "T2" Then
                '"SERFIN" Then
                strTipoPago = "TARJETA 2"
                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, oSap.Read_Centros)
            ElseIf CmbBancos.Value = "T3" Then
                '"BANAMEX" Then
                strTipoPago = "TARJETA 3"
                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, oSap.Read_Centros)
            End If

            If Me.cmbFormaPago.Value = "TADB" OrElse Me.cmbFormaPago.Value = "TACR" Then
                Dim dvBancos As New DataView(oCatalogoBancosMgr.GetAll(False).Tables(0), "CodBanco = '" & Me.CmbBancos.Value & "'", "CodBanco", DataViewRowState.CurrentRows)
                strNombreBanco = dvBancos(0)!Descripcion
            End If

            'strDivision = oAbonosApartadosMgr.SelectDivision(strTipoPago, oSap.Read_Centros)

            'If strDivision = "0000" Or strDivision = String.Empty Then
            '    MessageBox.Show("La division no es correcta, corregir en TABLA ZPP_COBRANZAS en SAP", "El campo GSBER es Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            '*********************************************************************

            oAbonosApartados.ID = ebNumAbono.Text
            oAbonosApartados.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
            oAbonosApartados.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
            oAbonosApartados.ApartadoID = oContratos.ID
            oAbonosApartados.ClienteID = ebNumCliente.Text
            oAbonosApartados.FolioAbono = ebNumAbono.Text
            oAbonosApartados.CodVendedor = ebNumVendedor.Text
            oAbonosApartados.CodFormaPago = cmbFormaPago.Value ' validar
            oAbonosApartados.TipoTarjeta = UiCTipoTarjeta.Text
            'Ramiro Alcaraz Flores
            oAbonosApartados.CodBanco = CmbBancos.Value 'ebCodBanco.Text


            If Not dtPgoTarjeta Is Nothing AndAlso dtPgoTarjeta.Rows.Count > 0 Then
                oAbonosApartados.NumeroTarjeta = dtPgoTarjeta.Rows(0).Item("NumeroTarjeta")
                oAbonosApartados.DPValeID = dtPgoTarjeta.Rows(0).Item("DPValeID")
                '  MessageBox.Show("Pasando parametros: tajeta - " & dtPgoTarjeta.Rows(0).Item("NumeroTarjeta") & " DPValeID - " & dtPgoTarjeta.Rows(0).Item("DPValeID"), "PRUEBAS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                oAbonosApartados.NumeroTarjeta = ebNumTarjeta.Text
                oAbonosApartados.DPValeID = String.Empty
            End If

            oAbonosApartados.NumeroAutorizacion = ebNumAut.Text
            oAbonosApartados.ComisionBancaria = vlComisionBancaria
            oAbonosApartados.IngresoComision = vlIngresoComision
            oAbonosApartados.IvaComision = vlIvaComision
            oAbonosApartados.Abono = ebAbono.Text
            oAbonosApartados.SaldoActual = ebSaldoActual.Text
            oAbonosApartados.SaldoNuevo = ebSaldoNuevo.Text
            oAbonosApartados.Usuario = oAppContext.Security.CurrentUser.Name
            oAbonosApartados.ClaCobr = strTipoPago
            oAbonosApartados.Fecha = Date.Now
            oAbonosApartados.Status = True
            oAbonosApartados.TipoMov = strTipoMovieminto
            If Me.cmbFormaPago.Value = "TACR" OrElse Me.cmbFormaPago.Value = "TADB" Then
                If Me.UiCTipoTarjeta.Text = "TE" Then
                    oAbonosApartados.Ticket = oAppSAPConfig.Ticket - 1
                Else
                    Dim dvBanco As New DataView(oCatalogoBancosMgr.GetAll(False).Tables(0), "CodBanco = '" & Me.CmbBancos.Value & "'", "CodBanco", DataViewRowState.CurrentRows)
                    strAfiliacion = oFacturaMgr.GetAfiliacion(Me.cmbPromocion.Value, dvBanco(0)!IDEmisor)
                    intPromo = Me.cmbPromocion.Value
                End If
                oAbonosApartados.Promocion = intPromo
                oAbonosApartados.NumAfiliacion = strAfiliacion
            Else
                oAbonosApartados.NumAfiliacion = ""
            End If

            '************************SAP*************************************************
            '''Antes de Guardar en Dportenis PRO '''Desbloquear en SAP si es el de Liquidacion
            'If ebSaldoNuevo.Text = 0 Then
            '    Dim oCierreDiaMgr As CierreDiaManager
            '    oCierreDiaMgr = New CierreDiaManager(oAppContext)
            '    '********************Desbloqueo de Articulos En MM14********************
            '    strDocFi = String.Empty
            '    strDocFi = oSap.Write_DesbloqueApartado(Me.ebNumApartado.Text, oCierreDiaMgr.ReadSQLApartadosDetallesLiquids(CInt(ebNumApartado.Text)))
            '    If strDocFi = "" Then
            '        Dim msg As String
            '        msg = "Los Articulos no se Desbloqueron en SAP Favor de Hacer el Abono Otra Vez "
            '        MessageBox.Show(msg, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Sm_Nuevo()
            '        Exit Sub
            '    End If
            'End If

            '************************SAP*************************************************
            'Se valida para que se haga el Abono a fuerzas
            strFolioAbono = CStr(oAbonosApartados.FolioAbono).PadLeft(10, "0")

            'Mandar a la bapi tipo Pago
            strDocFi = String.Empty

            strDocFi = oSap.Write_Anticipoapartado(oContratos.Referencia, oAbonosApartados.Abono, oAbonosApartados.ClienteID, _
                                                    Me.ebNumApartado.Text, strTipoMovieminto, strTienda, strTipoPago, strDivision, _
                                                    oAppContext.ApplicationConfiguration.Almacen, strAfiliacion)

            'si esta vacio y es diferente a N guarda el DOCFI
            If strDocFi <> "" And strDocFi <> "N" Then
                'se guardo correctamente
            Else
                'no se grabo en sap
                'si no es la liquidacion
                If ebSaldoNuevo.Text <> 0 Then
                    MsgBox("No se Realizo el Abono en SAP Favor de hacer el Abono otra Vez", MsgBoxStyle.Information, "Error al Hacer Abono en SAP")
                    Sm_Nuevo()
                    Exit Sub
                Else
                    'es el abono para liquidar
                    'se guarda no se guardo en SAP pero se hace todo despues 
                    'al cierre del dia se arregla el abono
                End If

            End If

            oAbonosApartados.Save()

            ValidaNumAbono() ' Validar si se realizo el Abono en DportenisPRO

            If strDocFi <> "" And strDocFi <> "N" Then

                oAbonosApartadosMgr.ActualizaDocFI(oAbonosApartados.FolioAbono, strDocFi)

            End If


            TipoMov = "AB"
            AbonoGuardado = True
            MessageBox.Show("Su Abono ha sido Grabado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'If Me.cmbFormaPago.Value = "TACR" OrElse Me.cmbFormaPago.Value = "TADB" Then
            '    If Me.UiCTipoTarjeta.Text = "TM" AndAlso oConfigCierreFI.UsarTPV = False Then
            '        ImprimirVoucherManual(mPosEntryM, strCriptogramaM)
            '    End If
            'End If

            Me.eHub = False
            intPromo = 0
            strAfiliacion = ""

            If bandImprimir Then
                '-----------------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 15.11.2013: Imprimimos 1 vez mas el abono del apartado si esta activa la config de miniprinter termica
                '-----------------------------------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.MiniprinterTermica Then ActionPreview()

                ActionPreview()

            End If

            If ebSaldoNuevo.Text = 0 Then

                Dim oResult As MsgBoxResult
                oResult = MsgBox("Listo para Facturarse. ¿ Desea Continuar ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, " Abonos Apartados")

                'Falta codigo que llama al formulario de la facturacion
                If oResult = MsgBoxResult.Yes Then

                    '---------------------------------------------------------------------
                    ' JNAVA (24.03.2017): Validamos si está activa la nueva facturacion
                    '---------------------------------------------------------------------
                    If oConfigCierreFI.FacturacionNueva Then
                        'Aqui abrimos la factura con la pantalla nueva
                        Dim frmFactura As New frmFacturacionNueva
                        frmFactura.ShowApartado(oContratos)
                        frmFactura.Dispose()
                        frmFactura = Nothing
                    Else
                        'Aqui abrimos la factura
                        Dim frmFactura As New frmFacturacion
                        frmFactura.ShowApartado(oContratos)
                        frmFactura.Dispose()
                        frmFactura = Nothing
                    End If

                End If

            End If

            BloquearFields()
            Me.Close()

        Else   'Opción Actualizar.


            MessageBox.Show("Los datos no pueden ser modificados", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub

            If (MessageBox.Show("Se encuentra seguro de Actualizar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                Exit Sub
            End If


            If (Fm_bolTxtValidar() = False) Then
                Exit Sub
            End If

            Dim Vl_intNumAbono As Integer

            Vl_intNumAbono = oAbonosApartados.ID

            oAbonosApartados.ID = ebNumAbono.Text
            oAbonosApartados.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
            oAbonosApartados.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
            oAbonosApartados.ApartadoID = ebNumApartado.Text
            oAbonosApartados.ClienteID = ebNumCliente.Text
            oAbonosApartados.CodVendedor = ebNumVendedor.Text
            oAbonosApartados.CodFormaPago = Me.cmbFormaPago.Value
            oAbonosApartados.TipoTarjeta = UiCTipoTarjeta.Text
            'Ramiro Alcaraz Flores
            oAbonosApartados.CodBanco = CmbBancos.Value 'ebCodBanco.Text
            oAbonosApartados.NumeroTarjeta = ebNumTarjeta.Text
            oAbonosApartados.NumeroAutorizacion = ebNumAut.Text
            oAbonosApartados.ComisionBancaria = vlComisionBancaria
            oAbonosApartados.IngresoComision = vlIngresoComision
            oAbonosApartados.IvaComision = vlIvaComision
            oAbonosApartados.Abono = ebAbono.Text
            oAbonosApartados.SaldoActual = ebSaldoActual.Text
            oAbonosApartados.SaldoNuevo = ebSaldoNuevo.Text
            oAbonosApartados.Usuario = oAppContext.Security.CurrentUser.Name
            oAbonosApartados.Fecha = Date.Now
            oAbonosApartados.Status = True

            oAbonosApartados.Save()

            On Error Resume Next

            oAbonosApartados = Nothing
            oAbonosApartados = oAbonosApartadosMgr.Load(Vl_intNumAbono)

            ebNumApartado.Text = oAbonosApartados.ApartadoID
            ebNumCliente.Text = oAbonosApartados.ClienteID
            ebNumVendedor.Text = oAbonosApartados.CodVendedor
            cmbFormaPago.Value = oAbonosApartados.CodFormaPago 'ver si no truena
            UiCTipoTarjeta.Text = oAbonosApartados.TipoTarjeta
            'Ramiro Alcaraz Flores
            CmbBancos.Value = oAbonosApartados.CodBanco
            'ebCodBanco.Text = oAbonosApartados.CodBanco
            ebNumTarjeta.Text = oAbonosApartados.NumeroTarjeta
            ebNumAut.Text = oAbonosApartados.NumeroAutorizacion
            ebAbono.Text = Format(oAbonosApartados.Abono, "Currency")
            ebSaldoActual.Text = Format(oAbonosApartados.SaldoActual, "Currency")
            ebSaldoNuevo.Text = Format(oAbonosApartados.SaldoNuevo, "Currency")
            ebTotalaPagar.Text = Format((oAbonosApartados.Abono + oAbonosApartados.ComisionBancaria), "Currency")

            MessageBox.Show("La información ha sido Actualizada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        oAbonosApartados = Nothing

        bolGuardar = False

    End Sub


    Private Sub Sm_Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)


        If TipoMov = "AN" Then
            Exit Sub
        End If


        If ((Vpa_bolOpenRecordDialog = True) Or (ebNumAbono.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New AbonosApartadosOpenRecordDialogView
            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oAbonosApartados = Nothing
                oAbonosApartados = oAbonosApartadosMgr.Load(oOpenRecordDlg.Record.Item("FolioAbono"))

                ebNumAbono.Text = oAbonosApartados.FolioAbono
                ebNumApartado.Text = oAbonosApartados.FolioApartado
                ebNumCliente.Text = oAbonosApartados.ClienteID
                ebNumVendedor.Text = oAbonosApartados.CodVendedor
                Me.cmbFormaPago.Value = oAbonosApartados.CodFormaPago 'ver si no truena
                UiCTipoTarjeta.Text = oAbonosApartados.TipoTarjeta


                Me.ebCodCaja.Text = oAbonosApartados.CodCaja
                'Ramiro Alcaraz Flores
                Me.CmbBancos.Value = oAbonosApartados.CodBanco
                'ebCodBanco.Text = oAbonosApartados.CodBanco
                ebNumTarjeta.Text = oAbonosApartados.NumeroTarjeta
                ebNumAut.Text = oAbonosApartados.NumeroAutorizacion
                ebSaldoActual.Text = Format(oAbonosApartados.SaldoActual, "Currency")
                ebAbono.Value = oAbonosApartados.Abono
                ebSaldoNuevo.Text = Format(oAbonosApartados.SaldoNuevo, "Currency")
                ccFechaAbono.Value = oAbonosApartados.Fecha
                ebTotalaPagar.Text = Format((oAbonosApartados.Abono + oAbonosApartados.ComisionBancaria), "Currency")

                If ebNumCliente.Text <> String.Empty Then
                    'Obtener nombre del cliente
                    oCliente = oClienteMgr.CreateAlterno
                    oClienteMgr.Load(oOpenRecordDlg.Record.Item("ClienteID"), oCliente, "I")
                    ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                End If

                If ebNumVendedor.Text <> String.Empty Then
                    'obteber nombre de player
                    oVendedor = oCatalogoVendedoresMgr.Load(oOpenRecordDlg.Record.Item("CodVendedor"))
                    ebDesVendedor.Text = oVendedor.Nombre
                End If

                If ccFechaApartado.Text <> String.Empty Then
                    'obtener fecha de apartado
                    oContratos = oContratosMgr.LoadFolioApartado(oAbonosApartados.FolioApartado)
                    ccFechaApartado.Value = oContratos.Fecha
                End If

                If cmbFormaPago.Value = "TACR" Or cmbFormaPago.Value = "TADB" Then
                    FieldsTarjetaVisible()
                ElseIf cmbFormaPago.Value = "EFEC" Then
                    FieldsTarjetaNoVisible()
                End If

                BloquearFields()
                ActionPreview(True)

            End If

        Else

            CLearFields()

            On Error Resume Next
            oAbonosApartados = Nothing

            oAbonosApartados = oAbonosApartadosMgr.Load(ebNumAbono.Text.Trim)

            If Not (oAbonosApartados Is Nothing) Then

                ebNumAbono.Text = oAbonosApartados.FolioAbono
                ebNumApartado.Text = oAbonosApartados.ApartadoID
                ebNumCliente.Text = oAbonosApartados.ClienteID
                ebNumVendedor.Text = oAbonosApartados.CodVendedor
                cmbFormaPago.Value = oAbonosApartados.CodFormaPago
                UiCTipoTarjeta.Text = oAbonosApartados.TipoTarjeta
                Me.ebCodCaja.Text = oAbonosApartados.CodCaja
                'Ramiro Alcaraz Flores
                Me.CmbBancos.Value = oAbonosApartados.CodBanco
                'ebCodBanco.Text = oAbonosApartados.CodBanco
                ebNumTarjeta.Text = oAbonosApartados.NumeroTarjeta
                ebNumAut.Text = oAbonosApartados.NumeroAutorizacion
                ebSaldoActual.Text = Format(oAbonosApartados.SaldoActual, "Currency")
                ebAbono.Value = oAbonosApartados.Abono
                ebSaldoNuevo.Text = Format(oAbonosApartados.SaldoNuevo, "Currency")
                ccFechaAbono.Value = oAbonosApartados.Fecha
                ebTotalaPagar.Text = Format((oAbonosApartados.Abono + oAbonosApartados.ComisionBancaria), "Currency")


            Else

                oAbonosApartadosMgr.Create()
                CLearFields()
                oAbonosApartados.ID = ebNumAbono.Text

            End If

        End If

    End Sub


    Private Sub Sm_BuscarApartado(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)


        If ((Vpa_bolOpenRecordDialog = True) Or (ebNumApartado.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New ContratoOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next


                oContratos = Nothing
                oContratos = oContratosMgr.LoadFolioCaja(oOpenRecordDlg.Record.Item("FolioApartado"), _
                oOpenRecordDlg.Record.Item("CodCaja"))

                If oContratos.Entregada = "N" Then

                    If oContratos.Saldo <= 0 Then

                        MsgBox("Este Apartado ya fue Liquidado. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Apartados")
                        ClearFieldsApar()
                        Exit Sub

                    ElseIf oContratos.Fecha.AddDays(oAppContext.ApplicationConfiguration.DiasVencimientoApartados) < Today Then

                        'MessageBox.Show("Este Apartado ya esta vencido, un auditor debe cancelarlo de forma definitiva.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        MessageBox.Show("Este Apartado ya esta vencido, es necesario la clave del auditor para continuar.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        oAppContext.Security.CloseImpersonatedSession()
                        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria") = False Then
                            ClearFieldsApar()
                            Exit Sub
                        End If
                        oAppContext.Security.CloseImpersonatedSession()

                    End If

                    ClearFieldsApar()

                    ebNumApartado.Text = oOpenRecordDlg.Record.Item("FolioApartado")
                    ebNumCliente.Text = oContratos.ClienteID
                    ebNumVendedor.Text = oContratos.PlayerID
                    ebSaldoActual.Text = Format(oContratos.Saldo, "Currency")
                    ccFechaApartado.Value = oContratos.Fecha
                    vImporteApartado = oContratos.ImporteTotal
                    ebCodCaja.Text = oContratos.CodCaja
                    'ebCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja


                    If ebNumCliente.Text <> String.Empty Then
                        'Obtener nombre del cliente
                        oCliente = oClienteMgr.CreateAlterno
                        oClienteMgr.Load(oOpenRecordDlg.Record.Item("ClienteID"), oCliente, "I")
                        ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                    End If

                    If ebNumVendedor.Text <> String.Empty Then
                        'obteber nombre de player
                        oVendedor = oCatalogoVendedoresMgr.Load(oOpenRecordDlg.Record.Item("CodVendedor"))
                        ebDesVendedor.Text = oVendedor.Nombre
                    End If
                    cmbFormaPago.Focus()

                ElseIf oContratos.Entregada = "S" Then

                    MsgBox("Este Apartado ya fue Entregado. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Apartados")
                    ClearFieldsApar()
                    ebNumApartado.Focus()

                ElseIf oContratos.Entregada = "V" Then

                    MsgBox("Este Apartado esta Vencido. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Apartados")
                    ClearFieldsApar()
                    ebNumApartado.Focus()

                ElseIf oContratos.Entregada = "C" Then

                    ebNumApartado.Text = oContratos.FolioApartado
                    ebNumCliente.Text = oContratos.ClienteID
                    ebNumVendedor.Text = oContratos.PlayerID
                    ebSaldoActual.Text = Format(oContratos.Saldo, "Currency")
                    ccFechaApartado.Value = oContratos.Fecha
                    vImporteApartado = oContratos.ImporteTotal
                    ebCodCaja.Text = oContratos.CodCaja
                    'ebCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja

                    If ebNumCliente.Text <> String.Empty Then
                        'Obtener nombre del cliente
                        oCliente = oClienteMgr.CreateAlterno
                        oClienteMgr.Load(oOpenRecordDlg.Record.Item("ClienteID"), oCliente, "I")
                        ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                    End If

                    If ebNumVendedor.Text <> String.Empty Then
                        'obteber nombre de player
                        oVendedor = oCatalogoVendedoresMgr.Load(oOpenRecordDlg.Record.Item("CodVendedor"))
                        ebDesVendedor.Text = oVendedor.Nombre
                    End If

                    MsgBox("Este Apartado ya fue cancelado. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Apartados")
                    Sm_Nuevo()
                    'ebNumApartado.Focus()
                    'bolGuardar = False
                    'BloquearFields()

                End If

            Else

                ebNumApartado.Focus()

            End If

        Else

            On Error Resume Next


            oContratos = Nothing
            oContratos = oContratosMgr.LoadFolioCaja(Me.ebNumApartado.Text, _
            ebCodCaja.Text)

            If oContratos.ID = 0 Then

                MessageBox.Show("El contrato no existe para la caja tecleada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If

            If oContratos.Entregada = "N" Then

                If oContratos.Saldo <= 0 Then

                    MsgBox("Este Apartado ya fue Liquidado. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Apartados")
                    ClearFieldsApar()
                    Exit Sub

                ElseIf oContratos.Fecha.AddDays(oAppContext.ApplicationConfiguration.DiasVencimientoApartados) < Today Then

                    MessageBox.Show("Este Apartado ya esta vencido, un auditor debe cancelarlo de forma definitiva.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ClearFieldsApar()
                    Exit Sub

                End If

                ClearFieldsApar()

                ebNumApartado.Text = oContratos.FolioApartado
                ebNumCliente.Text = oContratos.ClienteID
                ebNumVendedor.Text = oContratos.PlayerID
                ebSaldoActual.Text = Format(oContratos.Saldo, "Currency")
                ccFechaApartado.Value = oContratos.Fecha
                vImporteApartado = oContratos.ImporteTotal
                'ebCodCaja.Text = oContratos.CodCaja
                ebCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja

                If ebNumCliente.Text <> String.Empty Then
                    'Obtener nombre del cliente
                    oCliente = oClienteMgr.CreateAlterno
                    oClienteMgr.Load(oContratos.ClienteID, oCliente, "I")
                    ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                End If

                If ebNumVendedor.Text <> String.Empty Then
                    'obteber nombre de player
                    oVendedor = oCatalogoVendedoresMgr.Load(oContratos.PlayerID)
                    ebDesVendedor.Text = oVendedor.Nombre
                End If
                cmbFormaPago.Focus()

            ElseIf oContratos.Entregada = "S" Then

                MsgBox("Este Apartado ya fue Entregado. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Apartados")
                ClearFieldsApar()
                ebNumApartado.Focus()

            ElseIf oContratos.Entregada = "V" Then

                MsgBox("Este Apartado esta Vencido. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Apartados")
                ClearFieldsApar()
                ebNumApartado.Focus()

            ElseIf oContratos.Entregada = "C" Then

                ebNumApartado.Text = oContratos.FolioApartado
                ebNumCliente.Text = oContratos.ClienteID
                ebNumVendedor.Text = oContratos.PlayerID
                ebSaldoActual.Text = Format(oContratos.Saldo, "Currency")
                ccFechaApartado.Value = oContratos.Fecha
                vImporteApartado = oContratos.ImporteTotal
                ebCodCaja.Text = oContratos.CodCaja
                'ebCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja


                If ebNumCliente.Text <> String.Empty Then
                    'Obtener nombre del cliente
                    oCliente = oClienteMgr.CreateAlterno
                    oClienteMgr.Load(oContratos.ClienteID, oCliente, "I")
                    ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                End If

                If ebNumVendedor.Text <> String.Empty Then
                    'obteber nombre de player
                    oVendedor = oCatalogoVendedoresMgr.Load(oContratos.PlayerID)
                    ebDesVendedor.Text = oVendedor.Nombre
                End If
                cmbFormaPago.Focus()


                MsgBox("Este Apartado ya fue cancelado. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Apartados")
                ebNumApartado.Focus()
                bolGuardar = False
                BloquearFields()


            End If




        End If

    End Sub


    Private Sub Sm_BuscarCliente()

        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oCliente = oClienteMgr.CreateAlterno

            oClienteMgr.LoadInto(oOpenRecordDlg.Record.Item("ClienteID"), oCliente)

            If oCliente.CodigoAlterno = 0 Then

                MsgBox("Cliente no está registrado. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Clientes")
                ebNumCliente.Focus()

            Else

                ebNumCliente.Text = oCliente.CodigoAlterno
                ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                ebNumVendedor.Focus()

            End If

        End If

    End Sub


    Private Sub Sm_BuscarVendedor(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (ebNumVendedor.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            oOpenRecordDlg.CurrentView = New CatalogoVendedoresOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oVendedor = Nothing
                oVendedor = oCatalogoVendedoresMgr.Load(oOpenRecordDlg.Record.Item("CodVendedor"))

                ebNumVendedor.Text = oVendedor.ID
                ebDesVendedor.Text = oVendedor.Nombre

            End If

        Else

            On Error Resume Next

            oVendedor = Nothing
            oVendedor = oCatalogoVendedoresMgr.Load(ebNumVendedor.Text.Trim)

            ebNumVendedor.Text = oVendedor.ID
            ebDesVendedor.Text = oVendedor.Nombre

        End If

    End Sub


    Private Sub CLearFields()
        ebNumAbono.Text = String.Empty
        ebNumApartado.Text = String.Empty
        ccFechaApartado.Text = Now.Date
        ebNumCliente.Text = String.Empty
        ebDesCliente.Text = String.Empty
        ebNumVendedor.Text = String.Empty
        ebDesVendedor.Text = String.Empty
        ccFechaAbono.Text = Now.Date
        cmbFormaPago.Value = String.Empty
        ebSaldoActual.Text = Format(0, "Currency")
        ebAbono.Text = Format(0, "Currency")
        ebSaldoNuevo.Text = Format(0, "Currency")
        'UiCTarjeta.Text = String.Empty
        UiCTipoTarjeta.Text = String.Empty
        'ramiro alcaraz
        Me.CmbBancos.Value = String.Empty
        'ebCodBanco.Text = String.Empty
        ebNumTarjeta.Text = String.Empty
        Me.txtCVV2.Text = String.Empty
        ebTotalaPagar.Text = String.Empty
        ebNumAut.Text = String.Empty
        Me.ebCodCaja.Text = String.Empty
        Me.cmbPromocion.Text = ""
        Me.strTarjBloq = ""

        ebNumAbono.Focus()
    End Sub


    Private Sub ClearFieldsApar()

        ebNumApartado.Text = String.Empty
        ccFechaApartado.Text = Now.Date
        ebNumCliente.Text = String.Empty
        ebDesCliente.Text = String.Empty
        ebNumVendedor.Text = String.Empty
        ebDesVendedor.Text = String.Empty
        ccFechaAbono.Text = Now.Date
        cmbFormaPago.Value = String.Empty
        ebSaldoActual.Text = Format(0, "Currency")
        ebAbono.Text = Format(0, "Currency")
        ebSaldoNuevo.Text = Format(0, "Currency")
        'UiCTarjeta.Text = String.Empty
        UiCTipoTarjeta.Text = String.Empty
        'ramiro alcaraz
        Me.CmbBancos.Value = String.Empty
        'ebCodBanco.Text = String.Empty
        ebNumTarjeta.Text = String.Empty
        ebTotalaPagar.Text = String.Empty
        ebNumAut.Text = String.Empty
        Me.ebCodCaja.Text = String.Empty

        ebNumApartado.Focus()
    End Sub


    Private Sub BloquearFields()

        ebNumApartado.Enabled = False
        ccFechaApartado.Enabled = False
        ebNumCliente.Enabled = False
        ebDesCliente.Enabled = False
        ebNumVendedor.Enabled = False
        ebDesVendedor.Enabled = False
        ccFechaAbono.Enabled = False
        cmbFormaPago.Enabled = False
        ebSaldoActual.Enabled = False
        ebAbono.Enabled = False
        ebSaldoNuevo.Enabled = False
        'UiCTarjeta.Enabled = False
        UiCTipoTarjeta.Enabled = False
        'ramiro alcaraz
        Me.CmbBancos.Enabled = False
        'ebCodBanco.Enabled = False
        ebNumTarjeta.Enabled = False
        ebNumAut.Enabled = False
        ebTotalaPagar.Enabled = False
        Me.cmbPromocion.Enabled = False
        Me.txtCVV2.Enabled = False
        Me.btnLeerTarjeta.Enabled = False

        ebNumAbono.Focus()
    End Sub


    Private Sub DesBloquearFields()

        ebNumApartado.Enabled = True
        ccFechaApartado.Enabled = True
        ebNumCliente.Enabled = True
        ebDesCliente.Enabled = True
        ebNumVendedor.Enabled = True
        ebDesVendedor.Enabled = True
        ccFechaAbono.Enabled = True
        cmbFormaPago.Enabled = True
        ebSaldoActual.Enabled = True
        ebAbono.Enabled = True
        ebSaldoNuevo.Enabled = True
        'UiCTarjeta.Enabled = True
        UiCTipoTarjeta.Enabled = True
        'ramiro alcaraz flores
        Me.CmbBancos.Enabled = True
        'ebCodBanco.Enabled = True
        ebNumTarjeta.Enabled = True
        ebNumAut.Enabled = True
        ebTotalaPagar.Enabled = True
        Me.txtCVV2.Enabled = True
        Me.btnLeerTarjeta.Enabled = True

        ebNumAbono.Focus()
    End Sub


    Private Sub FieldsTarjetaVisible()

        'Label6.Visible = True
        'UiCTarjeta.Visible = True
        Label7.Visible = True
        UiCTipoTarjeta.Visible = True
        Label10.Visible = True
        Me.CmbBancos.Visible = True
        'ebCodBanco.Visible = True
        Label11.Visible = True
        ebNumAut.Visible = True
        LblNoTarjeta.Visible = False
        ebNumTarjeta.Visible = False
        Label3.Visible = True
        ebTotalaPagar.Visible = True
        Me.lblPromocion.Visible = True
        Me.cmbPromocion.Visible = True

        'Descomentar para liberar ehub
        Me.txtCVV2.Visible = True
        Me.Label9.Visible = True
        Me.btnLeerTarjeta.Visible = False

        'UiCTerminal.Visible = True
        'Label9.Visible = True

    End Sub


    Private Sub FieldsTarjetaNoVisible()

        'Label6.Visible = False
        'UiCTarjeta.Visible = False
        Label7.Visible = False
        UiCTipoTarjeta.Visible = False
        Label10.Visible = False
        Me.CmbBancos.Visible = False
        'ebCodBanco.Visible = False
        Label11.Visible = False
        ebNumAut.Visible = False
        LblNoTarjeta.Visible = False
        ebNumTarjeta.Visible = False
        Label3.Visible = False
        ebTotalaPagar.Visible = False
        Me.Label9.Visible = False
        Me.txtCVV2.Visible = False
        Me.lblPromocion.Visible = False
        Me.cmbPromocion.Visible = False
        Me.btnLeerTarjeta.Visible = False
        'UiCTerminal.Visible = False
        'Label9.Visible = False

    End Sub


    Public Sub ActionPreview(Optional ByVal Reimpresion As Boolean = False)
        Dim oARReporte

        If oConfigCierreFI.MiniPrinter Then

            oARReporte = New rptAbonoApartadoMiniPrinter(Me, Reimpresion)
            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName

        Else

            oARReporte = New rptAbonoApartado(Me)

        End If

        oARReporte.Document.Name = "Abono Apartado"
        oARReporte.Run()

        Try
            oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub


    Private Sub FillFormaPago()
        'Para saber que es facturacion general
        '------------------------------------------------------------------------------
        ' JNAVA (07.03.2016): Se Modifico para poder eliminar la forma de pago de DPTT
        '------------------------------------------------------------------------------
        Dim dtFP As DataTable = oCatalogoFormasPagoMgr.GetAll("I", True).Tables(0)
        dtFP = FiltrarFormasPago("DPPT", dtFP)
        dtFP = FiltrarFormasPago("DPCA", dtFP)

        cmbFormaPago.DataSource = dtFP
        '------------------------------------------------------------------------------
        cmbFormaPago.DropDownList.Columns.Add("Cod.")
        cmbFormaPago.DropDownList.Columns.Add("Descripción")
        cmbFormaPago.DropDownList.Columns("Cod.").DataMember = "CodFormasPago"
        cmbFormaPago.DropDownList.Columns("Cod.").Width = 50
        cmbFormaPago.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        cmbFormaPago.DropDownList.Columns("Descripción").Width = 150
        cmbFormaPago.DisplayMember = "Descripcion"
        cmbFormaPago.ValueMember = "CodFormasPago"
        cmbFormaPago.Refresh()

    End Sub

    Private Sub FillTerminal()

        Dim oCBancosMgr As New CatalogoBancosManager(oAppContext)
        'Para saber que es facturacion general
        Dim dtBanco As DataTable = oCBancosMgr.GetAll(False).Tables(0)
        dtBanco = FiltrarTerminal("T1", dtBanco)
        dtBanco = FiltrarTerminal("T2", dtBanco)
        CmbBancos.DataSource = dtBanco
        CmbBancos.DropDownList.Columns.Add("Cod.")
        CmbBancos.DropDownList.Columns.Add("Descripción")
        CmbBancos.DropDownList.Columns("Cod.").DataMember = "CodBanco"
        CmbBancos.DropDownList.Columns("Cod.").Width = 50
        CmbBancos.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        CmbBancos.DropDownList.Columns("Descripción").Width = 150
        CmbBancos.DisplayMember = "CodBanco"
        CmbBancos.ValueMember = "CodBanco"
        CmbBancos.Refresh()

    End Sub

#End Region



#Region "Métodos Miembros [Eventos]"


   

    Private Sub AbonosApartadosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oAbonosApartadosMgr = New AbonosApartadosManager(oAppContext)

        'If (oContratos Is Nothing) Then

        CLearFields()

        Me.ebNumApartado.Focus()

        'FillComboFormasPago()

        'End If

        'Creamos estructura de las promociones
        Me.cmbPromocion.DropDownList.Columns.Add("CodPromo")
        Me.cmbPromocion.DropDownList.Columns.Add("Descripcion")
        Me.cmbPromocion.DropDownList.Columns("Descripcion").Width = 250
        Me.cmbPromocion.DropDownList.Columns("CodPromo").Visible = False

        ccFechaApartado.Value = Now.Date

        ccFechaAbono.Value = Now.Date

        'cmbFormaPago.SelectedIndex = 0

        'Dim oCBancosMgr As New CatalogoBancosManager(oAppContext)
        'Dim dsBancos As DataSet
        'dsBancos = oCBancosMgr.GetAll(False)

        'Me.ebCodBanco.DataSource = dsBancos
        'Me.ebCodBanco.DataMember = "CatalogoBancos"
        'Me.ebCodBanco.DisplayMember = "CodBanco"

        Dim oCatalogoTipoTarjetasMgr As New CatalogoTipoTarjetasManager(oAppContext)
        Dim dsTarjetas As DataSet
        dsTarjetas = oCatalogoTipoTarjetasMgr.GetAll(False)


        Me.UiCTipoTarjeta.DataSource = dsTarjetas
        Me.UiCTipoTarjeta.DataMember = "CatalogoTipoTarjetas"
        Me.UiCTipoTarjeta.DisplayMember = "CodTipoTarjeta"
        Me.UiCTipoTarjeta.SelectedIndex = 0


        ebNumAbono.Text = oAbonosApartadosMgr.Folios()

        If (intFolioContrato > 0) Then

            Sm_Nuevo()

            Me.ebNumApartado.Text = intFolioContrato

            Me.ebCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja

            Sm_BuscarApartado()
            SendKeys.Send("{TAB}")
            SendKeys.Send("{TAB}")
            SendKeys.Send("{TAB}")


            If vImporteApartado = ebSaldoActual.Value Then
                Dim vlPAbono As Decimal = (ebSaldoActual.Value * (oAppContext.ApplicationConfiguration.MinPrimerAbono / 100))
                Dim importe As Integer = 0

                If vlPAbono - Int(vlPAbono) > 0 Then
                    importe = Int(vlPAbono) + 1
                Else
                    importe = vlPAbono
                End If

                ebAbono.Text = importe
                AbonoValidating()
            End If
        Else

            ebCodCaja.Focus()

        End If
        'Llenas el combo de las tipos de venta
        FillFormaPago()

        'Llenas el combo de las tipos de venta
        FillTerminal()

        'Me.ebCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
        Me.ebNumAbono.Enabled = False

    End Sub


    Private Sub CatalogoBancosForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        oAbonosApartados = Nothing

        oAbonosApartadosMgr.Dispose()
        oAbonosApartadosMgr = Nothing

    End Sub

    'Menú and ToolsBar :
    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoNuevo"

                Sm_Nuevo()

            Case "menuAbrir"

                Sm_Buscar(True)

            Case "menuArchivoGuardar"

                If bolGuardar Then

                    bandImprimir = True
                    Sm_Guardar()


                Else

                    MsgBox("El abono ya fue guardado. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Abonos Contratos")

                End If

            Case "menuAyudaTema"


            Case "menuSalir"
                If TipoMov = "AB" Then
                    oAbonosApartados = Nothing
                    Me.Close()
                End If
                

        End Select

    End Sub

    'Botón Buscar :
    Private Sub ebNumAbono_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Sm_Buscar(True)

    End Sub

    Private Sub ebNumAbono_ButtonClick1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebNumAbono.ButtonClick

        Sm_Buscar(True)

    End Sub

    Private Sub ebNumApartado_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebNumApartado.ButtonClick

        Sm_BuscarApartado(True)

    End Sub

    Private Sub ebNumCliente_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebNumCliente.ButtonClick

        Sm_BuscarCliente()

    End Sub



    Private Sub ebNumVendedor_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebNumVendedor.ButtonClick
        Sm_BuscarVendedor(True)
    End Sub



    Private Sub ebSaldoActual_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        ebSaldoActual.Text = Format(ebSaldoActual.Text, "Currency")
    End Sub

    Private Sub ebSaldoNuevo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebSaldoNuevo.Validating
        ebSaldoNuevo.Text = Format(ebSaldoNuevo.Text, "Currency")
    End Sub

    Private Sub ebNumAbono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumAbono.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            Sm_Buscar(True)

        ElseIf e.KeyCode = Keys.Enter Then

            ValidaNumAbono()

        End If

    End Sub

    Private Sub ValidaNumApartado()

        If (ebNumApartado.Text.Trim = String.Empty) Then
            Exit Sub
        End If
        If (ebNumApartado.Text > 0) Then

            Dim myID As Integer = ebNumApartado.Text
            oContratos = oContratosMgr.LoadFolioApartado(myID)

            If oContratos Is Nothing Then
                MsgBox("Apartado " & Format(myID, "00000000") & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Apartados")
                ClearFieldsApar()
                ebNumApartado.Focus()
                Exit Sub
            End If

            If oContratos.ID = 0 Then
                MsgBox("Apartado " & Format(myID, "00000000") & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Apartados")
                ebNumApartado.Focus()
            Else
                If oContratos.Entregada = "N" Then
                    If oContratos.Saldo <= 0 Then
                        MsgBox("Este Apartado ya fue Liquidado. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Apartados")
                        ClearFieldsApar()
                        Exit Sub

                    End If
                    ClearFieldsApar()
                    ebNumApartado.Text = oContratos.FolioApartado
                    ebNumCliente.Text = oContratos.ClienteID
                    ebNumVendedor.Text = oContratos.PlayerID
                    ebSaldoActual.Text = Format(oContratos.Saldo, "Currency")
                    ccFechaApartado.Value = oContratos.Fecha
                    vImporteApartado = oContratos.ImporteTotal

                    If ebNumCliente.Text <> String.Empty Then
                        'Obtener nombre del cliente
                        oCliente = oClienteMgr.CreateAlterno
                        oClienteMgr.LoadInto(oContratos.ClienteID, oCliente)
                        ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                    End If
                    If ebNumVendedor.Text <> String.Empty Then
                        'obtener nombre de player
                        oVendedor = oCatalogoVendedoresMgr.Load(oContratos.PlayerID)
                        ebDesVendedor.Text = oVendedor.Nombre
                    End If

                    cmbFormaPago.Focus()

                ElseIf oContratos.Entregada = "S" Then

                    MsgBox("Este Apartado ya fue Entregado. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Apartados")
                    ClearFieldsApar()
                    ebNumApartado.Focus()

                ElseIf oContratos.Entregada = "V" Then

                    MsgBox("Este Apartado esta Vencido. Verifique. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Apartados")
                    ClearFieldsApar()
                    ebNumApartado.Focus()

                End If
            End If

        Else

            MsgBox("El Numero de Apartado debe ser mayor a 0 .", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Apartados")
            ClearFieldsApar()
            ebNumApartado.Focus()

        End If
    End Sub



    Private Sub ebAbono_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebAbono.Validating

        AbonoValidating()

    End Sub

    Private Sub AbonoValidating()
        If ebAbono.Text <> String.Empty Then

            If ebAbono.Value <= Me.ebSaldoActual.Value Then

                Dim vebAbono As Decimal
                Dim vebSaldoActual As Decimal
                Dim vlComision As Decimal


                ebAbono.Text = Format(ebAbono.Text, "Currency")

                vebAbono = (ebAbono.Text)
                vebSaldoActual = (ebSaldoActual.Text)

                ebSaldoNuevo.Text = (ebSaldoActual.Text - ebAbono.Text)
                ebSaldoNuevo.Text = Format(ebSaldoNuevo.Text, "Currency")

                If cmbFormaPago.Value = "TACR" OrElse cmbFormaPago.Value = "TADB" Then

                    If cmbFormaPago.Value = "TACR" Then

                        'ebCodBanco.Text = oAppContext.ApplicationConfiguration.BancoParaTarjetas
                        'Me.CmbBancos.Value = oAppContext.ApplicationConfiguration.BancoParaTarjetas
                        vlComision = oAppContext.ApplicationConfiguration.ComisionTarjetaCredito

                    ElseIf cmbFormaPago.Value = "TADB" Then

                        'ebCodBanco.Text = oAppContext.ApplicationConfiguration.BancoParaTarjetas
                        'Me.CmbBancos.Value = oAppContext.ApplicationConfiguration.BancoParaTarjetas

                        vlComision = oAppContext.ApplicationConfiguration.ComisionTarjetaDebito

                    End If

                    vlComisionBancaria = Format((ebAbono.Text * (vlComision / 100)), "Currency")
                    vlIngresoComision = Format((vlComisionBancaria / (1 + oAppContext.ApplicationConfiguration.IVA)), "Currency")
                    vlIvaComision = Format((vlComisionBancaria - vlIngresoComision), "Currency")
                    ebTotalaPagar.Text = Format((ebAbono.Text + vlComisionBancaria), "Currency")



                End If

            Else

                MessageBox.Show("No puede abonar mas de su saldo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ebAbono.Focus()
                Me.ebAbono.SelectAll()
            End If

        End If

    End Sub


    Private Sub ValidaNumAbono()

        If (ebNumAbono.Text.Trim = String.Empty Or ebNumAbono.Enabled = False) Then
            Exit Sub
        End If
        oAbonosApartados = Nothing
        If (ebNumAbono.Text > 0 And oAbonosApartados Is Nothing) Then

            Dim myID As Integer = ebNumAbono.Text

            oAbonosApartados = oAbonosApartadosMgr.Load(myID)

            If oAbonosApartados Is Nothing Then
                MsgBox("Abono " & Format(myID, "00000000") & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Abonos")
                CLearFields()
                ebNumAbono.Focus()
                Exit Sub
            End If

            If oAbonosApartados.ID = 0 Then

                MsgBox("Abono " & Format(myID, "00000000") & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Abonos")

                DesBloquearFields()

                ebNumAbono.Focus()

            Else


                ebNumAbono.Text = oAbonosApartados.FolioAbono
                ebNumApartado.Text = oAbonosApartados.FolioApartado
                ebNumCliente.Text = oAbonosApartados.ClienteID
                ebNumVendedor.Text = oAbonosApartados.CodVendedor
                cmbFormaPago.Value = oAbonosApartados.CodFormaPago
                UiCTipoTarjeta.Text = oAbonosApartados.TipoTarjeta
                'Ramiro Alcaraz Flores
                Me.CmbBancos.Value = oAbonosApartados.CodBanco
                'ebCodBanco.Text = oAbonosApartados.CodBanco
                '   ebNumTarjeta.Text = oAbonosApartados.NumeroTarjeta
                ebNumAut.Text = oAbonosApartados.NumeroAutorizacion
                ebSaldoActual.Text = Format(oAbonosApartados.SaldoActual, "Currency")
                ebAbono.Value = oAbonosApartados.Abono
                ebSaldoNuevo.Text = Format(oAbonosApartados.SaldoNuevo, "Currency")
                ccFechaAbono.Value = oAbonosApartados.Fecha
                ebTotalaPagar.Text = Format((oAbonosApartados.Abono + oAbonosApartados.ComisionBancaria), "Currency")

                If ebNumCliente.Text <> String.Empty Then
                    'Obtener nombre del cliente
                    oCliente = oClienteMgr.CreateAlterno
                    oClienteMgr.Load(oAbonosApartados.ClienteID, oCliente, "I")
                    ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                End If

                If ebNumVendedor.Text <> String.Empty Then
                    'obteber nombre de player
                    oVendedor = oCatalogoVendedoresMgr.Load(oAbonosApartados.CodVendedor)
                    ebDesVendedor.Text = oVendedor.Nombre
                End If

                If ccFechaApartado.Text <> String.Empty Then
                    'obtener fecha de apartado
                    oContratos = oContratosMgr.Create
                    oContratos = oContratosMgr.LoadFolioApartado(oAbonosApartados.FolioApartado)
                    ccFechaApartado.Value = oContratos.Fecha
                End If

                BloquearFields()

                If cmbFormaPago.Value = "TACR" Or cmbFormaPago.Value = "TADB" Then
                    FieldsTarjetaVisible()
                End If


            End If

        Else

            If ebNumAbono.Text <= 0 Then

                ebNumAbono.Text = oAbonosApartados.ID

            End If

        End If
    End Sub


    Private Sub cmbFormaPago_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.ValueChanged

        If cmbFormaPago.Value = "TACR" Or cmbFormaPago.Value = "TADB" Then

            FieldsTarjetaVisible()
            Me.UiCTipoTarjeta.SelectedIndex = 0
            Me.CmbBancos.Value = String.Empty
            'ebCodBanco.Text = String.Empty

            'descomentar ehub 
            'ebNumTarjeta.Text = "Deslize Tarjeta ..."

            ebNumAut.Text = String.Empty

            oAppContext.ApplicationConfiguration.BancoParaTarjetas = "T3"
            Me.CmbBancos.Value = oAppContext.ApplicationConfiguration.BancoParaTarjetas
            'ebCodBanco.Text = oAppContext.ApplicationConfiguration.BancoParaTarjetas



            If cmbFormaPago.Value = "TADB" Then
                Me.UiCTipoTarjeta.Text = "TE"
                Me.UiCTipoTarjeta.ReadOnly = False
            ElseIf cmbFormaPago.Value = "TACR" Then
                Me.UiCTipoTarjeta.ReadOnly = False
            End If


            ebAbono.Focus()

        Else
            If cmbFormaPago.Value = "EFEC" Then
                FieldsTarjetaNoVisible()
                ebAbono.Focus()
                'oAppContext.ApplicationConfiguration.BancoParaTarjetas = "BNCR"
                'ebCodBanco.Text = oAppContext.ApplicationConfiguration.BancoParaTarjetas
            Else
                If cmbFormaPago.Value = "VCJA" Then
                    MessageBox.Show("No esta permitido", "No valido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbFormaPago.Value = "EFEC"
                End If
            End If
        End If
    End Sub


#End Region



    Private Sub frmAbonosApartados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.F2 Then

            If bolGuardar Then

                bandImprimir = False
                Sm_Guardar()
              

            Else

                MsgBox("El abono ya fue guardado. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Abonos Contratos")

            End If

        ElseIf e.KeyCode = Keys.F9 Then

            If bolGuardar Then

                bandImprimir = True
                Sm_Guardar()
              

            Else

                MsgBox("El abono ya fue guardado. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Abonos Contratos")

            End If


        ElseIf e.KeyCode = Keys.Escape Then

            If TipoMov = "AB" Then
                Me.Close()
            End If
        End If

    End Sub


    Private Sub ebCodCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodCaja.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarApartado(True)

        ElseIf e.KeyCode = Keys.Enter Then

            Sm_BuscarApartado()

        End If
    End Sub


    Private Sub ebNumApartado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumApartado.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarApartado(True)

        ElseIf e.KeyCode = Keys.Enter Then

            Sm_BuscarApartado()

        End If

    End Sub


    Private Sub CmbBancos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CmbBancos.Validating

        If Me.UiCTipoTarjeta.Text = "TM" Then

            'Dim oForm As New frmFotosTerminal
            'oForm.ShowDialog()

            'If oForm.intResultForm = 1 Then
            '    CmbBancos.Text = "T1"
            '    CmbBancos.Value = "T1"
            '    'EBBanco.Text = "BANCOMER"
            'ElseIf oForm.intResultForm = 2 Then
            '    CmbBancos.Text = "T2"
            '    CmbBancos.Value = "T2"
            '    'EBBanco.Text = "SANTANDER"
            'ElseIf oForm.intResultForm = 3 Then
            '    CmbBancos.Text = "T3"
            '    CmbBancos.Value = "T3"
            '    'EBBanco.Text = "BANAMEX"
            'End If

            Dim dvBancos As New DataView(oCatalogoBancosMgr.GetAll(False).Tables(0), "CodBanco = '" & Me.CmbBancos.Value & "'", "CodBanco", DataViewRowState.CurrentRows)
            strNombreBanco = dvBancos(0)!Descripcion
            'FillBancoPromociones(dvBancos(0)!IDEmisor)
        Else
            If oConfigCierreFI.PagosBanamex = True Then
                GetPromocionesBanamex()
                cmbPromocion.Enabled = True
                ebNumTarjeta.Enabled = False
                'btnLeerTarjeta.Enabled = False
                cmbPromocion.Focus()
            End If
        End If

        If Me.txtCVV2.Enabled = True Then
            Me.txtCVV2.Focus()
        End If

    End Sub

    '    Private Sub ebNumTarjeta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumTarjeta.KeyDown
    '        If e.KeyCode = Keys.Enter Then

    '            If Me.UiCTipoTarjeta.Text = "TE" Then

    '                If ebNumTarjeta.Text.Length <= 16 Then
    '                    Exit Sub
    '                ElseIf Trim(Me.txtCVV2.Text) = "" Then
    '                    MsgBox("Es necesario capturar el CVV2", MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                    Me.ebNumTarjeta.Text = ""
    '                    Me.txtCVV2.Focus()
    '                    Exit Sub
    '                End If

    '                If oAppSAPConfig.eHub = True Then
    '                    If booleHub Then
    '                        Dim x As New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
    '                        Dim i As Long
    '                        Dim mSalida As String
    '                        Dim mAmount As Double           '4    
    '                        Dim mPOSEntry As String         '22        
    '                        Dim mTrack2 As String           '35        
    '                        Dim mRespose As String          '61

    '                        Dim mE2 As String
    '                        Dim mHRecordType As String
    '                        Dim mHTerm As String
    '                        Dim mHCajero As String
    '                        Dim mHTienda As String
    '                        Dim mHTicket As String
    '                        Dim mHTrack2 As String
    '                        Dim mHImporte As String
    '                        Dim mHMeses As String
    '                        Dim mHSkip As String
    '                        Dim mHCVV2 As String
    '                        Dim mHCargo As String
    '                        Dim mHCredito As String
    '                        Dim mHFijo As String
    '                        Dim mCard As String
    '                        Dim mAutorizacion As String
    '                        Dim Mensaje As String
    '                        Dim Mensaje46 As String
    '                        Dim mRespcode As String
    '                        Dim mFile As Integer

    '                        Dim mDummy As String
    '                        Dim mCarPun As String
    '                        Dim mCrePun As String
    '                        Dim mCarDin As String
    '                        Dim mCreDin As String
    '                        Dim mNumCia As String
    '                        Dim mNumPlan As String
    '                        Dim mOperacion As String
    '                        Dim mAfiliacion As String
    '                        Dim mCVV2 As String = Trim(Me.txtCVV2.Text)
    '                        Dim mRespuesta As String
    '                        Dim mComentario As String



    '                        'Ocultamos informacion de la tarjeta , para dejar unicamente el numero
    '                        Dim strTrack() As String = ebNumTarjeta.Text.ToUpper.Split(";")
    '                        Dim strNombre As String

    '                        strNombre = GetName(strTrack(0))
    '                        'If InStr(strTrack(0), "¨") > 0 Then
    '                        '    strNombre = strTrack(0).Substring(18, strTrack(0).IndexOf("¨", 19) - 18)
    '                        '    strNombre = strNombre.Replace("¨", "").Trim
    '                        'Else
    '                        '    strNombre = strTrack(0).Substring(18, strTrack(0).IndexOf("^", 19) - 18)
    '                        '    strNombre = strNombre.Replace("^", "").Trim
    '                        'End If
    '                        ebNumTarjeta.Text = strTrack(1)

    '                        Dim intPosition As Integer = 0
    '                        Dim strVencimiento As String = String.Empty
    '                        Dim strPromocion As String = String.Empty
    '                        Dim strNum As String = (ebNumTarjeta.Text).Replace(";", "")
    '                        intPosition = InStr(strNum, "=")
    '                        strVencimiento = Mid(strNum, intPosition + 3, 2) & "/" & Mid(strNum, intPosition + 1, 2)
    '                        strNum = Mid(strNum, 1, intPosition - 1)

    '                        'If strTarjBloq <> "" Then
    '                        If oFacturaMgr.EsTarjetaBloqueada(strnum.Trim) Then
    '                            'Dim strTarjetasBloq As String() = strTarjBloq.Split("°")
    '                            'For Each Str As String In strTarjetasBloq
    '                            'If Str.ToUpper.Trim = strNum.ToUpper.Trim Then
    '                            MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                            Me.ebNumTarjeta.Text = strNum
    '                            Exit Sub
    '                            'End If
    '                            'Next
    '                            'ElseIf Me.ebAbono.Value > 5000 Then
    '                        ElseIf Me.ebAbono.Value > oConfigCierreFI.MontoMaxTarjetas Then
    '                            oAppContext.Security.CloseImpersonatedSession()
    '                            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
    '                                MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                Me.ebNumTarjeta.Text = strNum
    '                                Exit Sub
    '                            Else
    '                                oAppContext.Security.CloseImpersonatedSession()
    '                            End If
    '                        ElseIf oCatalogoFormasPagoMgr.TarjetaUsadaHoy(strNum) Then
    '                            oAppContext.Security.CloseImpersonatedSession()
    '                            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
    '                                MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                Me.ebNumTarjeta.Text = strNum
    '                                Exit Sub
    '                            Else
    '                                oAppContext.Security.CloseImpersonatedSession()
    '                            End If
    '                        End If

    '                        'INICIO Consulta de promociones
    '                        Dim strProSkip, strProMeses As String
    '                        mTrack2 = (ebNumTarjeta.Text).Replace(";", "")
    '                        mTrack2 = (mTrack2).Replace("?", "")

    '                        mSalida = x.PagoTarjeta(oAppContext.ApplicationConfiguration.Almacen, _
    '                        oAppContext.ApplicationConfiguration.NoCaja, CInt(Me.ebNumVendedor.Text), _
    '                        "000001", 902, mTrack2, CDbl(ebAbono.Text), mHTicket, mComentario, mRespuesta, _
    '                        mHMeses, mHSkip, mCVV2)

    '                        strProMeses = ""
    '                        strProSkip = ""

    '                        mDummy = mSalida
    '                        Do While Len(mDummy) > 0
    '                            mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
    '                            mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
    '                            If InStr(mRespose, "39==") > 0 Then
    '                                mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                            End If
    '                            If InStr(mRespose, "43==") > 0 Then
    '                                Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                                If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
    '                            End If
    '                            If InStr(mRespose, "46==") > 0 Then
    '                                Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                            End If

    '                        Loop
    '                        If mRespcode = "00" And InStr(Mensaje46, "|") > 0 Then
    '                            'Mando llamar la pantalla para seleccionar la promocion del pago
    '                            Dim ofrm As New frmPromociones(Mensaje46)
    '                            If ofrm.ShowDialog() = DialogResult.OK Then
    '                                strProMeses = ofrm.Plazo
    '                                strProSkip = ofrm.Skip
    '                                strPromocion = ofrm.ebPromocion.Text
    '                                intPromo = CInt(strProMeses)
    '                            Else
    '                                Me.ebNumTarjeta.Text = ""
    '                                Me.txtCVV2.Text = ""
    '                                Me.txtCVV2.Focus()

    '                                Exit Sub
    '                            End If

    '                        End If
    '                        'FIN Consulta de promociones

    '                        'Limpiamos las variebles que pudieron ser afectadas en la consulta de promociones
    '                        x = New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
    '                        mRespcode = ""
    '                        Mensaje = ""
    '                        Mensaje46 = ""

    '                        On Error Resume Next
    '                        mHTienda = oAppContext.ApplicationConfiguration.Almacen
    '                        mHTerm = oAppContext.ApplicationConfiguration.NoCaja
    '                        mHCajero = CInt(Me.ebNumVendedor.Text)
    '                        mHRecordType = 2
    '                        mPOSEntry = "902"
    '                        mTrack2 = (ebNumTarjeta.Text).Replace(";", "")
    '                        mTrack2 = (mTrack2).Replace("?", "")
    '                        ebNumTarjeta.Text = strNum
    '                        mAmount = CDbl(ebAbono.Text)
    '                        'El ticket debe de variar, ver de donde se va a sacar el consecutivo
    '                        mHTicket = oAppSAPConfig.Ticket

    '                        If InStr(mTrack2, "=") > 0 Then
    '                            mCard = mTrack2.Substring(0, InStr(mTrack2, "=") - 1)
    '                        End If

    '                        mSalida = ""
    '                        mDummy = ""

    '                        Select Case CInt(mHRecordType)
    '                            Case 1 : mHCVV2 = "    " 'Consulta Planes
    '                                mCVV2 = "    "
    '                                mOperacion = "000001"
    '                            Case 2 : mOperacion = "000000" 'CreditAuth
    '                                mHMeses = strProMeses
    '                                mHSkip = strProSkip
    '                                mHCVV2 = txtCVV2.Text
    '                                mCVV2 = Trim(txtCVV2.Text)
    '                                'Case 3 : mOperacion = "000003" 'ConsCteFrec
    '                                'Case 4 : mOperacion = "000004" 'ActCteFrec
    '                                '    mCarPun = txtCargoPun.Text
    '                                '    mCrePun = txtAbonoPun.Text
    '                                '    mCarDin = txtCargoDin.Text
    '                                '    mCreDin = txtAbonoDin.Text
    '                                '    mAmount = mCarPun & "|" & mCrePun & "|" & mCarDin & "|" & mCreDin
    '                                'Case 5 : mOperacion = "000005" 'CatalogoCiaCelular
    '                                'Case 6 : mOperacion = "000006" 'PlanCelular
    '                                'Case 7 : mOperacion = "000007" 'VentaTACelular
    '                                '    mHMeses = txtSkip.Text
    '                                '    mHSkip = txtMeses.Text
    '                                'Case 8 : mOperacion = "000008" 'PeticionVenta
    '                                'Case 9 : mOperacion = "000009" 'ConsultaSaldo
    '                                'Case 10 : mOperacion = "000010" 'ActTarjetaRegalo
    '                                '    mHCargo = txtCargoDin.Text
    '                                '    mHCredito = txtAbonoDin.Text
    '                                '    If mHCredito > 0 Then
    '                                '        mAmount = mHCredito
    '                                '        mOperacion = "000110"
    '                                '    Else
    '                                '        mAmount = mHCargo
    '                                '    End If
    '                                'Case 11 : mOperacion = "000011" 'ConsultaBono
    '                        End Select
    '                        'txtOutput.Text = ""
    '                        mSalida = x.PagoTarjeta(mHTienda, mHTerm, mHCajero, mOperacion, mPOSEntry, mTrack2, mAmount, mHTicket, mComentario, mRespuesta, mHMeses, mHSkip, mCVV2)

    '                        mDummy = mSalida
    '                        Do While Len(mDummy) > 0
    '                            mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
    '                            mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
    '                            If InStr(mRespose, "38==") > 0 Then
    '                                mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
    '                            End If
    '                            If InStr(mRespose, "39==") > 0 Then
    '                                mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                            End If
    '                            If InStr(mRespose, "43==") > 0 Then
    '                                Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                                If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
    '                            End If
    '                            If InStr(mRespose, "46==") > 0 Then
    '                                Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                                Mensaje46 = Replace(Mensaje46, "|", vbCrLf)
    '                            End If
    '                            If InStr(mRespose, "48==") > 0 Then
    '                                mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim 'Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)).Substring(0, 10)
    '                            End If
    '                        Loop
    '                        If mOperacion = "000001" Then
    '                            If mAutorizacion > 1 Then
    '                                Mid$(mHFijo, 4, 1) = "1"
    '                            End If
    '                            While InStr(Mensaje46, vbCrLf) > 0
    '                                mDummy = Mensaje46.Substring(0, InStr(Mensaje46, vbCrLf) - 1)
    '                                Mensaje46 = Mensaje46.Substring(InStr(Mensaje46, vbCrLf) + 1, Len(Mensaje46) - InStr(Mensaje46, vbCrLf) - 1)
    '                            End While
    '                        Else
    '                            mDummy = mHFijo
    '                            If mOperacion = "000002" Then
    '                                mDummy = mDummy & mRespcode & mAutorizacion
    '                                mDummy = mDummy & Mensaje.Substring(0, 40)
    '                                If Len(Mensaje) < 40 Then
    '                                    mDummy = mDummy & Space(40 - Len(Mensaje))
    '                                End If
    '                            End If
    '                            If mOperacion = "000002" Then
    '                                mDummy = mDummy & Mensaje46.Substring(0, 20)
    '                                If Len(Mensaje46) < 20 Then
    '                                    mDummy = mDummy & Space(20 - Len(Mensaje46))
    '                                End If
    '                                mDummy = mDummy & mAfiliacion
    '                            Else
    '                                mDummy = mDummy & Mensaje46
    '                            End If

    '                        End If



    '                        If mRespcode = "00" AndAlso Trim(mAutorizacion) <> "" AndAlso Trim(mAfiliacion) <> "" Then

    '                            'If Mensaje46 Is Nothing Then
    '                            '    Mensaje46 = "00"
    '                            'End If
    '                            Dim strBanco As String

    '                            'Mensaje = UCase(Mensaje)
    '                            Mensaje = oFacturaMgr.BancoAutorizador(Me.ebNumTarjeta.Text, intPromo).ToUpper

    '                            If InStr(Mensaje, "BANAMEX") > 0 Then
    '                                CmbBancos.Text = "T3"
    '                                CmbBancos.Value = "T3"
    '                                strBanco = "BANAMEX"
    '                            ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
    '                                CmbBancos.Text = "T1"
    '                                CmbBancos.Value = "T1"
    '                                strBanco = "BANCOMER"
    '                            ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
    '                                CmbBancos.Text = "T2"
    '                                CmbBancos.Value = "T2"
    '                                strBanco = "SANTANDER"
    '                            End If

    '                            'Select Case Mensaje46.Substring(2, Mensaje46.Length - 2)
    '                            '    Case "BANAMEX"
    '                            '        ebCodBanco.Text = "T3"
    '                            '        ebCodBanco.Value = "T3"
    '                            '        EBBanco.Text = "BANAMEX"
    '                            '    Case "BANCOMER"
    '                            '        ebCodBanco.Text = "T1"
    '                            '        ebCodBanco.Value = "T1"
    '                            '        EBBanco.Text = "BANCOMER"
    '                            '    Case "SANTANDER"
    '                            '        ebCodBanco.Text = "T2"
    '                            '        ebCodBanco.Value = "T2"
    '                            '        EBBanco.Text = "SANTANDER"
    '                            'End Select



    '                            'Transaccion Exitosa
    '                            strAfiliacion = mAfiliacion
    '                            Me.ebNumAut.Text = mAutorizacion
    '                            Me.eHub = True
    '                            MsgBox("Transacción Exitosa" & Microsoft.VisualBasic.vbCrLf & "Preparar Miniprinter", MsgBoxStyle.Information, "DPTienda")

    '                            ''''I. Actualizamos Ticket.
    '                            Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
    '                            Dim oSApReader As New SapConfigReader(strConfigurationFile)
    '                            oAppSAPConfig.Ticket = oAppSAPConfig.Ticket + 1
    '                            oSApReader.SaveSettings(oAppSAPConfig)
    '                            ''''F. Actualizamos Ticket.

    '                            Dim bolReimpresion As Boolean = False

    'Reimprimir:
    '                            Select Case CmbBancos.Text

    '                                Case "T3"
    'Imprime_Banamex:
    '                                    ''Original Banco
    '                                    Dim oARReporte As New rptTicketBANAMEX(CDbl(ebAbono.Text), strNum, strVencimiento, mAutorizacion, strPromocion, "VENTA", strNombre, CInt(Me.ebNumVendedor.Text), _
    '                                                                           mAfiliacion, strBanco, "ORIGINAL BANCO")
    '                                    oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
    '                                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                                    oARReporte.Run()
    '                                    oARReporte.Document.Print(False, False)

    '                                    ''Copia Cliente
    '                                    Dim oARReporteC As New rptTicketBANAMEX(CDbl(ebAbono.Text), strNum, strVencimiento, mAutorizacion, strPromocion, "VENTA", strNombre, CInt(Me.ebNumVendedor.Text), _
    '                                                                           mAfiliacion, strBanco, "COPIA CLIENTE")
    '                                    oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
    '                                    oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                                    oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                                    oARReporteC.Run()
    '                                    oARReporteC.Document.Print(False, False)

    '                                Case "T1"

    '                                    Dim oARReporte As New rptTicketBancomer(CDbl(ebAbono.Text), strNum, strVencimiento, mAutorizacion, strPromocion, "VENTA", strNombre, CInt(Me.ebNumVendedor.Text), _
    '                                                                           mAfiliacion, strBanco, "ORIGINAL BANCO", mPOSEntry, True, True)
    '                                    oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
    '                                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                                    oARReporte.Run()
    '                                    oARReporte.Document.Print(False, False)

    '                                    'Copia Cliente
    '                                    Dim oARReporteC As New rptTicketBancomer(CDbl(ebAbono.Text), strNum, strVencimiento, mAutorizacion, strPromocion, "VENTA", strNombre, CInt(Me.ebNumVendedor.Text), _
    '                                                                           mAfiliacion, strBanco, "COPIA CLIENTE", mPOSEntry, True, True)
    '                                    oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
    '                                    oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                                    oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                                    oARReporteC.Run()
    '                                    oARReporteC.Document.Print(False, False)

    '                                Case Else

    '                                    GoTo Imprime_Banamex

    '                            End Select

    '                            If bolReimpresion = False Then
    '                                If MsgBox("¿Desea reimprimir los tickets?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Dportenis PRO") = MsgBoxResult.Yes Then
    '                                    bolReimpresion = True
    '                                    GoTo Reimprimir
    '                                End If
    '                            End If

    '                        Else
    '                            'Transaccion Rechazada

    '                            If Trim(mRespcode) <> "00" Then

    '                                Dim Motivo As String = ""

    '                                Select Case mRespcode.Trim
    '                                    Case "04", "14", "41", "43", "142"
    '                                        'Me.strTarjBloq &= Me.ebNumTarjeta.Text & "°"
    '                                        oFacturaMgr.SaveTarjetaRechazada(Me.ebNumTarjeta.Text.Trim)
    '                                        Motivo = "La tarjeta ha sido rechazada.".ToUpper
    '                                    Case "49"
    '                                        Motivo = "CVV2 Incorrecto.".ToUpper
    '                                    Case "91"
    '                                        Motivo = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
    '                                End Select

    '                                MsgBox("Transacción Rechazada." & vbCrLf & Motivo & vbCrLf & _
    '                                         mSalida, MsgBoxStyle.Exclamation, "DPTienda")

    '                            ElseIf Trim(mAutorizacion) = "" AndAlso Trim(mAfiliacion) = "" Then

    '                                MsgBox("Transacción Rechazada. No se regresaron el número de afiliación ni el número" & _
    '                                   " de autorización." & Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                                   MsgBoxStyle.Exclamation, "DPTienda")

    '                            ElseIf Trim(mAutorizacion) = "" Then

    '                                MsgBox("Transacción Rechazada. No se regresó el número de autorización." & _
    '                                   Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                                   MsgBoxStyle.Exclamation, "DPTienda")

    '                            ElseIf Trim(mAfiliacion) = "" Then

    '                                MsgBox("Transacción Rechazada. No se regresó el número de afiliación." & _
    '                                   Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                                   MsgBoxStyle.Exclamation, "DPTienda")

    '                            End If

    '                            Me.ebNumTarjeta.Text = ""
    '                            Me.txtCVV2.Text = ""
    '                            Me.txtCVV2.Focus()

    '                        End If


    '                        'mConsecutivo = mConsecutivo + 1
    '                        'txtOutput.Text = "Mensaje al Voucher" & vbCrLf & mDummy & vbCrLf
    '                        'txtOutput.Text = "Mensaje Recibido" & vbCrLf & mSalida & vbCrLf
    '                    End If

    '            Else

    '                GoTo Manual

    '            End If

    '        Else
    'Manual:
    '            Dim strNum() As String
    '            strNum = Me.ebNumTarjeta.Text.ToUpper.Split(";")

    '            strNombreM = GetName(strnum(0))
    '            Me.ebNumTarjeta.Text = strnum(1)
    '            Array.Clear(strnum, 0, 2)
    '            strNum = Me.ebNumTarjeta.Text.Split("=")
    '            Me.ebNumTarjeta.Text = strnum(0)
    '            strVencM = strnum(1).Substring(2, 2) & "/" & strnum(1).Substring(0, 2)

    '                'If strTarjBloq <> "" Then
    '                If oFacturaMgr.EsTarjetaBloqueada(Me.ebNumTarjeta.Text.Trim) Then
    '                    'Dim strTarjetasBloq As String() = strTarjBloq.Split("°")
    '                    'For Each Str As String In strTarjetasBloq
    '                    'If Str.ToUpper.Trim = ebNumTarjeta.Text.ToUpper.Trim Then
    '                    MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    Me.cmbPromocion.DataSource = Nothing
    '                    Me.cmbPromocion.Text = ""
    '                    Exit Sub
    '                    'End If
    '                    'Next
    '                    'ElseIf Me.ebAbono.Value > 5000 Then
    '                ElseIf Me.ebAbono.Value > oConfigCierreFI.MontoMaxTarjetas Then
    '                    oAppContext.Security.CloseImpersonatedSession()
    '                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
    '                        MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        Me.cmbPromocion.DataSource = Nothing
    '                        Me.cmbPromocion.Text = ""
    '                        Exit Sub
    '                    Else
    '                        oAppContext.Security.CloseImpersonatedSession()
    '                    End If
    '                ElseIf oCatalogoFormasPagoMgr.TarjetaUsadaHoy(Me.ebNumTarjeta.Text) Then
    '                    oAppContext.Security.CloseImpersonatedSession()
    '                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
    '                        MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        Me.cmbPromocion.DataSource = Nothing
    '                        Me.cmbPromocion.Text = ""
    '                        Exit Sub
    '                    Else
    '                        oAppContext.Security.CloseImpersonatedSession()
    '                    End If
    '                End If

    '                FillBancoPromociones(CInt(Me.ebNumTarjeta.Text.Substring(0, 6)), Me.ebAbono.Value)
    '                Me.cmbPromocion.Text = ""

    '            End If

    '        End If

    '    End Sub

    Private Sub GenerarArchivoMonto(ByVal Ruta As String, ByVal monto As String)

        Dim oStreamW As StreamWriter

        oStreamW = New StreamWriter(Ruta)

        oStreamW.Write(monto)

        oStreamW.Close()

    End Sub

    Private Function LeerArchivoTarjeta(ByVal Ruta As String) As String()

        Dim oStreamR As StreamReader
        Dim strContenido() As String

        oStreamR = New StreamReader(Ruta)

        strContenido = oStreamR.ReadToEnd.Split("|")

        oStreamR.Close()

        File.Delete(Ruta)

        Return strContenido

    End Function

    Private Sub AutorizarCargoTarjeta()

        Dim Ruta As String = "C:\LecturaTarjeta.txt"
        Dim oProcesos() As Process

        If Me.UiCTipoTarjeta.Text = "TE" Then

            If oAppSAPConfig.eHub = True Then
                If booleHub Then
                    Dim x As New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
                    Dim i As Long
                    Dim mSalida As String
                    Dim mAmount As Double           '4    
                    Dim mPOSEntry As String         '22        
                    Dim mTrack2 As String           '35        
                    Dim mRespose As String          '61

                    Dim mE2 As String
                    Dim mHRecordType As String
                    Dim mHTerm As String
                    Dim mHCajero As String
                    Dim mHTienda As String
                    Dim mHTicket As String
                    Dim mHTrack2 As String
                    Dim mHImporte As String
                    Dim mHMeses As String
                    Dim mHSkip As String
                    Dim mHCVV2 As String
                    Dim mHCargo As String
                    Dim mHCredito As String
                    Dim mHFijo As String
                    Dim mCard As String
                    Dim mAutorizacion As String
                    Dim Mensaje As String
                    Dim Mensaje46 As String
                    Dim mRespcode As String
                    Dim mFile As Integer

                    Dim mDummy As String
                    Dim mCarPun As String
                    Dim mCrePun As String
                    Dim mCarDin As String
                    Dim mCreDin As String
                    Dim mNumCia As String
                    Dim mNumPlan As String
                    Dim mOperacion As String
                    Dim mAfiliacion As String
                    Dim mCVV2 As String = Trim(Me.txtCVV2.Text)
                    Dim mRespuesta As String
                    Dim mComentario As String
                    Dim strNombre As String
                    Dim strCriptograma As String = ""
                    Dim strDatosEMV As String = ""

                    'strNombre = Datos(1)
                    'ebNumTarjeta.Text = Datos(0)
                    'strCriptograma = Datos(6)
                    'strDatosEMV = Datos(5)

                    'Dim intPosition As Integer = 0
                    Dim strVencimiento As String = ""
                    Dim strPromocion As String = ""
                    Dim strNum As String = "" '(ebNumTarjeta.Text).Replace(";", "")
                    'intPosition = InStr(strNum, "=")
                    'strVencimiento = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)
                    'strNum = Mid(strNum, 1, intPosition - 1)
                    'mPOSEntry = Datos(3)

                    'If oFacturaMgr.EsTarjetaBloqueada(strnum.Trim) Then
                    '    MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '    Me.ebNumTarjeta.Text = strNum
                    '    Exit Sub
                    'Else
                    If Me.ebAbono.Value > oConfigCierreFI.MontoMaxTarjetas Then
                        oAppContext.Security.CloseImpersonatedSession()
                        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                            MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Me.ebNumTarjeta.Text = strNum
                            Exit Sub
                        Else
                            oAppContext.Security.CloseImpersonatedSession()
                        End If
                        'ElseIf oCatalogoFormasPagoMgr.TarjetaUsadaHoy(strNum) Then
                        '    oAppContext.Security.CloseImpersonatedSession()
                        '    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                        '        MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '        Me.ebNumTarjeta.Text = strNum
                        '        Exit Sub
                        '    Else
                        '        oAppContext.Security.CloseImpersonatedSession()
                        '    End If
                    End If

                    'INICIO Consulta de promociones
                    Dim strProSkip As String = "", strProMeses As String = ""
                    'mTrack2 = (ebNumTarjeta.Text).Replace(";", "")
                    'mTrack2 = (mTrack2).Replace("?", "")

                    'mSalida = x.PagoTarjeta(oAppContext.ApplicationConfiguration.Almacen, _
                    'oAppContext.ApplicationConfiguration.NoCaja, CInt(Me.ebNumVendedor.Text), _
                    '"000001", 902, mTrack2, CDbl(ebAbono.Text), mHTicket, mComentario, mRespuesta, _
                    'mHMeses, mHSkip, mCVV2)

                    'strProMeses = ""
                    'strProSkip = ""

                    'mDummy = mSalida
                    'Do While Len(mDummy) > 0
                    '    mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
                    '    mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
                    '    If InStr(mRespose, "39==") > 0 Then
                    '        mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                    '    End If
                    '    If InStr(mRespose, "43==") > 0 Then
                    '        Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                    '        If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
                    '    End If
                    '    If InStr(mRespose, "46==") > 0 Then
                    '        Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                    '    End If

                    'Loop
                    'If mRespcode = "00" And InStr(Mensaje46, "|") > 0 Then
                    '    'Mando llamar la pantalla para seleccionar la promocion del pago
                    '    Dim ofrm As New frmPromociones(Mensaje46)
                    '    If ofrm.ShowDialog() = DialogResult.OK Then
                    '        strProMeses = ofrm.Plazo
                    '        strProSkip = ofrm.Skip
                    '        strPromocion = ofrm.ebPromocion.Text
                    '        intPromo = CInt(strProMeses)
                    '    Else
                    '        Me.ebNumTarjeta.Text = ""
                    '        Me.txtCVV2.Text = ""
                    '        Me.txtCVV2.Focus()

                    '        Exit Sub
                    '    End If

                    'End If
                    'FIN Consulta de promociones

                    'Limpiamos las variables que pudieron ser afectadas en la consulta de promociones
                    x = New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
                    mRespcode = ""
                    Mensaje = ""
                    Mensaje46 = ""

                    On Error Resume Next
                    mHTienda = oAppContext.ApplicationConfiguration.Almacen
                    mHTerm = oAppContext.ApplicationConfiguration.NoCaja
                    'mHCajero = CInt(Me.ebNumVendedor.Text)
                    'Se modificó para que aceptara codigos de vendedor alfanumericos
                    mHCajero = Me.ebNumVendedor.Text
                    mHRecordType = 2
                    'mPOSEntry = Datos(3) & "1"
                    'mTrack2 = (ebNumTarjeta.Text).Replace(";", "")
                    'mTrack2 = (mTrack2).Replace("?", "")
                    'ebNumTarjeta.Text = strNum
                    mAmount = CDbl(ebAbono.Text)
                    'El ticket debe de variar, ver de donde se va a sacar el consecutivo
                    mHTicket = oAppSAPConfig.Ticket

                    'If InStr(mTrack2, "=") > 0 Then
                    '    mCard = mTrack2.Substring(0, InStr(mTrack2, "=") - 1)
                    'End If

                    mSalida = ""
                    mDummy = ""
                    mOperacion = "000000"
                    mHSkip = ""
                    mTrack2 = ""

                    'Select Case CInt(mHRecordType)
                    '    Case 1 : mHCVV2 = "    " 'Consulta Planes
                    '        mCVV2 = "    "
                    '        mOperacion = "000001"
                    '    Case 2 : mOperacion = "000000" 'CreditAuth
                    '        mHMeses = strProMeses
                    '        mHSkip = strProSkip
                    '        mHCVV2 = txtCVV2.Text
                    '        mCVV2 = Trim(txtCVV2.Text)
                    '        'Case 3 : mOperacion = "000003" 'ConsCteFrec
                    '        'Case 4 : mOperacion = "000004" 'ActCteFrec
                    '        '    mCarPun = txtCargoPun.Text
                    '        '    mCrePun = txtAbonoPun.Text
                    '        '    mCarDin = txtCargoDin.Text
                    '        '    mCreDin = txtAbonoDin.Text
                    '        '    mAmount = mCarPun & "|" & mCrePun & "|" & mCarDin & "|" & mCreDin
                    '        'Case 5 : mOperacion = "000005" 'CatalogoCiaCelular
                    '        'Case 6 : mOperacion = "000006" 'PlanCelular
                    '        'Case 7 : mOperacion = "000007" 'VentaTACelular
                    '        '    mHMeses = txtSkip.Text
                    '        '    mHSkip = txtMeses.Text
                    '        'Case 8 : mOperacion = "000008" 'PeticionVenta
                    '        'Case 9 : mOperacion = "000009" 'ConsultaSaldo
                    '        'Case 10 : mOperacion = "000010" 'ActTarjetaRegalo
                    '        '    mHCargo = txtCargoDin.Text
                    '        '    mHCredito = txtAbonoDin.Text
                    '        '    If mHCredito > 0 Then
                    '        '        mAmount = mHCredito
                    '        '        mOperacion = "000110"
                    '        '    Else
                    '        '        mAmount = mHCargo
                    '        '    End If
                    '        'Case 11 : mOperacion = "000011" 'ConsultaBono
                    'End Select
                    'txtOutput.Text = ""
                    oProcesos = Process.GetProcessesByName("eHubEMV")
                    If oProcesos.Length < 1 Then
                        Process.Start(Application.StartupPath & "\eHubEMV.exe")
                    End If
                    mSalida = x.PagoTarjeta(mHTienda, mHTerm, mHCajero, mOperacion, mPOSEntry, mTrack2, mAmount, _
                                            mHTicket, mComentario, mRespuesta, "", "", mHMeses, mHSkip, "")

                    Dim mFirma As String = ""
                    Dim mLote As String = ""
                    Dim mSubtechTermID As String = ""
                    Dim mTrace As String = ""

                    mHTicket = ""
                    mDummy = mSalida
                    Do While Len(mDummy) > 0
                        mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
                        mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
                        If InStr(mRespose, "22==") > 0 Then
                            mPOSEntry = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
                        End If
                        If InStr(mRespose, "35==") > 0 Then
                            mTrack2 = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
                        End If
                        If InStr(mRespose, "38==") > 0 Then
                            mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
                        End If
                        If InStr(mRespose, "39==") > 0 Then
                            mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                        End If
                        If InStr(mRespose, "43==") > 0 Then
                            Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                            If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
                        End If
                        If InStr(mRespose, "46==") > 0 Then
                            Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                            Mensaje46 = Replace(Mensaje46, "|", vbCrLf)
                        End If
                        If InStr(mRespose, "48==") > 0 Then
                            mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim 'Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)).Substring(0, 10)
                        End If
                        If InStr(mRespose, "61==") > 0 Then
                            mFirma = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "62==") > 0 Then
                            mSubtechTermID = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "63==") > 0 Then
                            mLote = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "64==") > 0 Then
                            mTrace = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "65==") > 0 Then
                            mHTicket = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                    Loop

                    ''''I. Actualizamos Ticket.
                    Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
                    Dim oSApReader As New SapConfigReader(strConfigurationFile)
                    oAppSAPConfig.Ticket = oAppSAPConfig.Ticket + 1
                    oSApReader.SaveSettings(oAppSAPConfig)
                    ''''F. Actualizamos Ticket.

                    If mRespcode = "00" AndAlso mAutorizacion.Trim <> "" AndAlso mAfiliacion.Trim <> "" Then

                        Dim strTrack2() As String = mTrack2.Split("=")

                        Me.ebNumTarjeta.Text = strTrack2(0).Replace(";", "")
                        strNum = Me.ebNumTarjeta.Text.Trim
                        strVencimiento = strTrack2(1).Substring(2, 2) & "/" & strTrack2(1).Substring(0, 2)
                        If mPOSEntry.Trim = "051" Then
                            Dim strMsgs() As String = Mensaje46.Split(",")
                            strCriptograma = strMsgs(strMsgs.Length - 1).Trim
                            If InStr(strCriptograma, "ARQC") <= 0 Then strCriptograma = ""
                        End If

                        If InStr(Mensaje46, "3 MESES") > 0 Then
                            strPromocion = "3 Meses Sin Intereses"
                            intPromo = 3
                        ElseIf InStr(Mensaje46, "6 MESES") > 0 Then
                            strPromocion = "6 Meses Sin Intereses"
                            intPromo = 6
                        ElseIf InStr(Mensaje46, "9 MESES") > 0 Then
                            strPromocion = "9 Meses Sin Intereses"
                            intPromo = 9
                        ElseIf InStr(Mensaje46, "12 MESES") > 0 Then
                            strPromocion = "12 Meses Sin Intereses"
                            intPromo = 12
                        ElseIf InStr(Mensaje46, "18 MESES") > 0 Then
                            strPromocion = "18 Meses Sin Intereses"
                            intPromo = 18
                        Else
                            strPromocion = "Normal"
                            intPromo = 1
                        End If

                        Dim strBanco As String = ""
                        Dim strEmisor As String = ""

                        Mensaje = ""
                        Mensaje = oFacturaMgr.BancoAutorizador(Me.ebNumTarjeta.Text, intPromo).ToUpper

                        Select Case CmbBancos.Text
                            Case "T1"
                                strEmisor = "BANCOMER"
                            Case "T2"
                                strEmisor = "SANTANDER"
                            Case "T3"
                                strEmisor = "BANAMEX"
                        End Select

                        If InStr(Mensaje, "BANAMEX") > 0 Then
                            CmbBancos.Text = "T3"
                            CmbBancos.Value = "T3"
                            strBanco = "BANAMEX"
                        ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
                            CmbBancos.Text = "T1"
                            CmbBancos.Value = "T1"
                            strBanco = "BANCOMER"
                        ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
                            CmbBancos.Text = "T2"
                            CmbBancos.Value = "T2"
                            strBanco = "SANTANDER"
                        End If

                        'Transaccion Exitosa
                        Me.UiCTipoTarjeta.Text = "TE"
                        Me.ebNumAut.Text = mAutorizacion
                        Me.strAfiliacion = mAfiliacion
                        Me.eHub = True
                        MsgBox("Transacción Exitosa" & Microsoft.VisualBasic.vbCrLf & "Preparar Miniprinter", MsgBoxStyle.Information, "DPTienda")

                        Dim bolReimpresion As Boolean = False
                        Dim oReportView As ReportViewerForm
Reimprimir:
                        Select Case CmbBancos.Text

                            Case "T3"
Imprime_Banamex:
                                ''Original Banco
                                Dim oARReporte As New rptTicketBANAMEX(CDbl(ebAbono.Text), strNum, strVencimiento, _
                                                                       mAutorizacion, strPromocion, "VENTA", _
                                                                       strNombre, Me.ebNumVendedor.Text, _
                                                                       mAfiliacion, strEmisor, "ORIGINAL BANCO", _
                                                                       mFirma, strCriptograma, True, mHTicket, mLote, _
                                                                       mTrace, mSubtechTermID)
                                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporte.Run()
                                oARReporte.Document.Print(False, False)

                                ''Copia Cliente
                                Dim oARReporteC As New rptTicketBANAMEX(CDbl(ebAbono.Text), strNum, strVencimiento, _
                                                                        mAutorizacion, strPromocion, "VENTA", _
                                                                        strNombre, Me.ebNumVendedor.Text, _
                                                                        mAfiliacion, strEmisor, "COPIA CLIENTE", _
                                                                        mFirma, strCriptograma, True, mHTicket, mLote, _
                                                                       mTrace, mSubtechTermID)
                                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporteC.Run()
                                oARReporteC.Document.Print(False, False)

                                oReportView = New ReportViewerForm
                                oReportView.Report = oARReporte
                                oReportView.Show()

                                oReportView = New ReportViewerForm
                                oReportView.Report = oARReporteC
                                oReportView.Show()

                            Case "T1"

                                Dim oARReporte As New rptTicketBancomer(CDbl(ebAbono.Text), strNum, strVencimiento, _
                                                                        mAutorizacion, strPromocion, "VENTA", _
                                                                        strNombre, Me.ebNumVendedor.Text, _
                                                                        mAfiliacion, strBanco, "ORIGINAL BANCO", _
                                                                        mPOSEntry, True, True, strCriptograma, mFirma)
                                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporte.Run()
                                oARReporte.Document.Print(False, False)

                                'Copia Cliente
                                Dim oARReporteC As New rptTicketBancomer(CDbl(ebAbono.Text), strNum, strVencimiento, _
                                                                         mAutorizacion, strPromocion, "VENTA", _
                                                                         strNombre, Me.ebNumVendedor.Text, _
                                                                         mAfiliacion, strBanco, "COPIA CLIENTE", _
                                                                         mPOSEntry, True, True, strCriptograma, mFirma)
                                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporteC.Run()
                                oARReporteC.Document.Print(False, False)

                                oReportView = New ReportViewerForm
                                oReportView.Report = oARReporte
                                oReportView.Show()

                                oReportView = New ReportViewerForm
                                oReportView.Report = oARReporteC
                                oReportView.Show()

                            Case Else

                                GoTo Imprime_Banamex

                        End Select

                        If bolReimpresion = False Then
                            If MsgBox("¿Desea reimprimir los tickets?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Dportenis PRO") = MsgBoxResult.Yes Then
                                bolReimpresion = True
                                GoTo Reimprimir
                            End If
                        End If

                    ElseIf mRespcode = "06" Then

                        MessageBox.Show("El tiempo de espera para deslizar / insertar la tarjeta ha terminado." & vbCrLf & _
                                        "Por favor, Intente de nuevo.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    ElseIf mRespcode.Trim = "95" Then

                        'Transaccion Cancelada
                        Me.btnLeerTarjeta.Focus()

                    Else
                        'Transaccion Rechazada

                        If Trim(mRespcode) <> "00" Then

                            Dim Motivo As String = Mensaje46

                            Select Case mRespcode.Trim
                                Case "04", "14", "41", "43", "142"
                                    'Me.strTarjBloq &= Me.ebNumTarjeta.Text & "°"
                                    oFacturaMgr.SaveTarjetaRechazada(Me.ebNumTarjeta.Text.Trim)
                                    Motivo = "La tarjeta ha sido rechazada.".ToUpper
                                Case "45"
                                    Motivo = "Promocion Invalida.".ToUpper
                                Case "46"
                                    Motivo = "Monto Inferior al mínimo permitido para las promociones."
                                Case "48"
                                    Motivo = "CVV2 Requerido.".ToUpper
                                Case "49"
                                    Motivo = "CVV2 Incorrecto.".ToUpper
                                Case "91", "70"
                                    Motivo = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
                            End Select

                            If Motivo.Trim <> "" Then Motivo = vbCrLf & vbCrLf & Motivo
                            'MsgBox("Transacción Rechazada." & vbCrLf & Motivo & vbCrLf & _
                            '         mSalida, MsgBoxStyle.Exclamation, "DPTienda")
                            MessageBox.Show("Transacción Rechazada.".ToUpper & Motivo.ToUpper _
                            , "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        ElseIf Trim(mAutorizacion) = "" AndAlso Trim(mAfiliacion) = "" Then

                            MsgBox("Transacción Rechazada. No se regresaron el número de afiliación ni el número" & _
                               " de autorización." & Microsoft.VisualBasic.vbCrLf & mSalida, _
                               MsgBoxStyle.Exclamation, "DPTienda")

                        ElseIf Trim(mAutorizacion) = "" Then

                            MsgBox("Transacción Rechazada. No se regresó el número de autorización." & _
                               Microsoft.VisualBasic.vbCrLf & mSalida, _
                               MsgBoxStyle.Exclamation, "DPTienda")

                        ElseIf Trim(mAfiliacion) = "" Then

                            MsgBox("Transacción Rechazada. No se regresó el número de afiliación." & _
                               Microsoft.VisualBasic.vbCrLf & mSalida, _
                               MsgBoxStyle.Exclamation, "DPTienda")

                        End If

                        Me.ebNumTarjeta.Text = ""
                        Me.txtCVV2.Text = ""
                        Me.txtCVV2.Focus()

                    End If

                End If

            Else

                GoTo Manual

            End If

        Else
Manual:
            Dim strNum() As String
            Dim Datos() As String
            Dim strPosEntry As String = ""
            Dim oApp As Process
            Dim bolError As Boolean = False

            oProcesos = Process.GetProcessesByName("eHubEMV")
            For Each oApp In oProcesos
                oApp.CloseMainWindow()
                oApp.WaitForExit()
            Next

            Shell(Application.StartupPath & "\PinPadNurit293.exe /A", AppWinStyle.NormalFocus, True)

            If File.Exists(Ruta) Then
                Datos = LeerArchivoTarjeta(Ruta)
                File.Delete(Ruta)
            Else
                Me.ebNumTarjeta.Text = ""
                Me.cmbPromocion.DataSource = Nothing
                Me.cmbPromocion.Text = ""
                Exit Sub
            End If

            Me.ebNumTarjeta.Text = Datos(0)
            Me.mPosEntryM = CInt(Datos(3) & "1")
            Me.strCriptogramaM = Datos(5)
            Me.strNombreM = Datos(6)

            strNum = Me.ebNumTarjeta.Text.Split("=")
            Me.ebNumTarjeta.Text = strNum(0)
            strVencM = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)

            strPosEntry = CStr(mPosEntryM).Trim.PadLeft(3, "0")

            If oFacturaMgr.EsTarjetaBloqueada(Me.ebNumTarjeta.Text.Trim) Then
                MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                bolError = True
                'Me.cmbPromocion.DataSource = Nothing
                'Me.cmbPromocion.Text = ""
                'If strPosEntry.Trim = "051" Then
                '    Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                'End If
                GoTo FinalM
            ElseIf Me.ebAbono.Value > oConfigCierreFI.MontoMaxTarjetas Then
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                    MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    bolError = True
                    GoTo FinalM
                Else
                    oAppContext.Security.CloseImpersonatedSession()
                End If
            ElseIf oCatalogoFormasPagoMgr.TarjetaUsadaHoy(Me.ebNumTarjeta.Text) Then
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                    MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'Me.cmbPromocion.DataSource = Nothing
                    'Me.cmbPromocion.Text = ""
                    'If strPosEntry.Trim = "051" Then
                    '    Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                    'End If
                    'Exit Sub
                    bolError = True
                    GoTo FinalM
                Else
                    oAppContext.Security.CloseImpersonatedSession()
                End If
            End If

            FillBancoPromociones(CInt(Me.ebNumTarjeta.Text.Substring(0, 6)), Me.ebAbono.Value)
            Me.cmbPromocion.Text = ""
FinalM:
            If bolError Then
                Me.cmbPromocion.DataSource = Nothing
                Me.cmbPromocion.Text = ""
                Me.ebNumTarjeta.Text = ""
            End If
            If strPosEntry.Trim = "051" Then
                Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
            End If
        End If

    End Sub

    Private Sub UiCTipoTarjeta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UiCTipoTarjeta.Validating

        booleHub = False

        If Me.UiCTipoTarjeta.Text <> "" Then

            'Dim drView As DataRowView
            'drView = Me.UiCTipoTarjeta.SelectedItem

            'EBTarjeta.Text = drView.Item(1)

            If Me.UiCTipoTarjeta.Text = "TE" Then
                If oAppSAPConfig.eHub = True Then
                    booleHub = True
                End If
                Me.txtCVV2.Enabled = True
                Me.cmbPromocion.Enabled = False
                Me.cmbPromocion.DataSource = Nothing
                Me.cmbPromocion.Text = ""
                Me.ebNumAut.ReadOnly = True
                Me.ebNumAut.BackColor = Color.Ivory
            Else
                Me.txtCVV2.Enabled = False
                Me.cmbPromocion.Enabled = True
                Me.ebNumAut.ReadOnly = False
                Me.ebNumAut.BackColor = Color.White
            End If

            'drView = Nothing

            'Else

            '   EBTarjeta.Text = ""

        End If

    End Sub

    'Private Sub ebNumTarjeta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebNumTarjeta.LostFocus

    '    If Me.ebNumTarjeta.Text = "" Then

    '        Me.ebNumTarjeta.Text = "Deslize Tarjeta ..."

    '    End If

    'End Sub

    'Private Sub ebNumTarjeta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebNumTarjeta.GotFocus

    '    If Me.ebNumTarjeta.Text = "Deslize Tarjeta ..." Then

    '        Me.ebNumTarjeta.Text = ""

    '    End If

    'End Sub

    Private Sub ebAbono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebAbono.KeyDown

        If e.KeyCode = Keys.Enter AndAlso (Me.cmbFormaPago.Value = "TACR" OrElse Me.cmbFormaPago.Value = "TADB") Then
            ebSaldoActual.Focus()
        End If

    End Sub

    Private Sub frmAbonosContratos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If eHub = True AndAlso AbonoGuardado = False Then
            MsgBox("Es necesario guardar el abono", MsgBoxStyle.Exclamation, "Dportenis Pro")
            e.Cancel = True
        End If

    End Sub

    Private Sub FillBancoPromociones(ByVal Bin As Integer, ByVal Importe As Decimal)

        dtPromociones = oCatalogoPromoMgr.GetAllByBin(Bin, Importe)
        Me.cmbPromocion.DataSource = dtPromociones
        'Me.cmbPromocion.DropDownList.Columns.Add("CodPromo")
        'Me.cmbPromocion.DropDownList.Columns.Add("Descripcion")
        Me.cmbPromocion.DropDownList.Columns("CodPromo").DataMember = "Promocion"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").DataMember = "Descripcion"
        'Me.cmbPromocion.DropDownList.Columns("CodPromo").Width = 50
        Me.cmbPromocion.DropDownList.Columns("Descripcion").Width = 150
        Me.cmbPromocion.DisplayMember = "Descripcion"
        Me.cmbPromocion.ValueMember = "Promocion"
        Me.cmbPromocion.DropDownList.Columns("CodPromo").Visible = False
        Me.cmbPromocion.Refresh()

    End Sub

    Private Sub ImprimirVoucherManual(ByVal mPosEntry As Integer, ByVal strCripto As String)

        Dim bolReimpresion As Boolean = False
        Dim oReportV As New ReportViewerForm

Reimprimir:
        Select Case Me.CmbBancos.Text.ToUpper

            Case "T3"
Imprime_Banamex:
                Dim oARReporte As New rptTicketBANAMEX(CDbl(ebAbono.Text), Me.ebNumTarjeta.Text.Trim, strVencM, Me.ebNumAut.Text.Trim, _
                                                       Me.cmbPromocion.Text, "VENTA", strNombreM, ebNumVendedor.Text, _
                                                       strAfiliacion, strNombreBanco, "ORIGINAL BANCO", strNombreM, strCripto, False, "", "", "", "")
                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporte.Run()
                oARReporte.Document.Print(False, False)

                ''Copia Cliente
                Dim oARReporteC As New rptTicketBANAMEX(CDbl(ebAbono.Text), ebNumTarjeta.Text.Trim, strVencM, ebNumAut.Text, _
                                                        Me.cmbPromocion.Text, "VENTA", strNombreM, ebNumVendedor.Text, _
                                                        strAfiliacion, strNombreBanco, "COPIA CLIENTE", strNombreM, strCripto, False, "", "", "", "")
                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporteC.Run()
                oARReporteC.Document.Print(False, False)

                'oReportV.Report = oarreporte
                'oReportV.Show()

                'oReportV = New ReportViewerForm
                'oReportV.Report = oarreportec
                'oReportV.Show()

            Case "T1"

                Dim oARReporte As New rptTicketBancomer(CDbl(ebAbono.Text), Me.ebNumTarjeta.Text.Trim, strVencM, _
                                                        Me.ebNumAut.Text.Trim, Me.cmbPromocion.Text, "VENTA", _
                                                        strNombreM, ebNumVendedor.Text, strAfiliacion, _
                                                        strNombreBanco, "ORIGINAL BANCO", mPosEntry, True, False, _
                                                        strCripto, strNombreM)
                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporte.Run()
                oARReporte.Document.Print(False, False)

                'Copia Cliente
                Dim oARReporteC As New rptTicketBancomer(CDbl(ebAbono.Text), ebNumTarjeta.Text.Trim, strVencM, _
                                                         ebNumAut.Text, Me.cmbPromocion.Text, "VENTA", strNombreM, _
                                                         ebNumVendedor.Text, strAfiliacion, strNombreBanco, _
                                                         "COPIA CLIENTE", mPosEntry, True, False, strCripto, _
                                                         strNombreM)
                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporteC.Run()
                oARReporteC.Document.Print(False, False)

                'oReportV.Report = oarreporte
                'oReportV.Show()

                'oReportV = New ReportViewerForm
                'oReportV.Report = oarreportec
                'oReportV.Show()

            Case Else

                GoTo Imprime_Banamex

        End Select

        If bolReimpresion = False Then
            If MessageBox.Show("¿Desea reimpirmir los vouchers?", "Dportenis Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                bolReimpresion = True
                GoTo Reimprimir
            End If
        End If

    End Sub

    Private Sub ebAbono_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebAbono.ValueChanged
        If (Me.cmbFormaPago.Value = "TACR" OrElse Me.cmbFormaPago.Value = "TADB") AndAlso Me.UiCTipoTarjeta.Text = "TM" Then
            'Me.ebNumTarjeta.Text = "Deslize Tarjeta ..."
            Me.cmbPromocion.Text = ""
            Me.cmbPromocion.DataSource = Nothing
        End If
    End Sub

    Private Sub btnLeerTarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerTarjeta.Click
        '--------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 18.07.2014: Validamos que no dejen en cero el importe del abono antes de intentar hacer el cargo con tarjeta
        '--------------------------------------------------------------------------------------------------------------------------------------
        If Me.ebAbono.Value > 0 Then
            Me.btnLeerTarjeta.Enabled = False
            Me.AutorizarCargoTarjeta()
            Me.btnLeerTarjeta.Enabled = True
        Else
            MessageBox.Show("El importe del Abono no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebAbono.Focus()
        End If
    End Sub

#Region "Adecuaciones REtail"

    Private Function FiltrarFormasPago(ByVal strFormasPago As String, ByVal dtFP As DataTable) As DataTable
        Dim dtTemp As DataTable = dtFP.Clone
        Dim oRow As DataRow

        For Each oRow In dtFP.Rows
            If InStr(strFormasPago.Trim.ToUpper, CStr(oRow!CodFormasPago).Trim.ToUpper) <= 0 Then
                dtTemp.ImportRow(oRow)
            End If
        Next

        Return dtTemp

    End Function

#End Region

#Region "Pagos Banamex"

    Private Function ValidarPagoBanamex(ByRef mensaje As String) As Boolean
        Dim valido As Boolean = True
        If cmbPromocion.Value Is Nothing AndAlso CStr(cmbPromocion.Value).Trim() <> "" Then
            valido = False
            mensaje = "No has elegido la promoción"
        ElseIf ebAbono.Value Is Nothing AndAlso CDec(ebAbono.Value) > 0 Then
            valido = False
            mensaje = "No has capturado el monto a pagar"
        End If
        Return valido
    End Function

    Private Sub CreaEstructuraTarjetas(ByRef dtTarjetas As DataTable)

        dtTarjetas = New DataTable("Tarjetas")

        With dtTarjetas
            .Columns.Add(New DataColumn("DPValeID", GetType(String)))
            .Columns.Add(New DataColumn("NumeroTarjeta", GetType(String)))
            .AcceptChanges()
        End With

    End Sub

    Private Function ValoresPagoBanamex(ByVal datos As Dictionary(Of String, Object)) As Boolean
        Dim bResp As Boolean = True

        CreaEstructuraTarjetas(dtPgoTarjeta)

        Dim fila As DataRow = dtPgoTarjeta.NewRow
        fila("DPValeID") = CStr(datos("trn_id"))
        fila("NumeroTarjeta") = CStr(datos("trn_card_number"))
        dtPgoTarjeta.Rows.Add(fila)

        ' MessageBox.Show("DPValeID: " & CStr(datos("trn_id")) & " Tarjeta: " & CStr(datos("trn_card_number")), "PRUEBAS", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Return bResp
    End Function



    Private Function AddFormaPagoBanamex() As Boolean
        Dim valido As Boolean = False
        Dim pay As New uPaydll.upaydll()
        Dim response As String = pay.ventas(oConfigCierreFI.UserBanamex, oConfigCierreFI.PasswordBanamex, CDec(ebAbono.Value), CInt(cmbPromocion.Value), 0, 0)
        If response.Trim() <> "" Then
            Dim lstResponse As Dictionary(Of String, Object) = GetResponse(response)
            '--------------------------------------------------------------------------------
            'FLIZARRAGA 18/01/2017: Se valida si paso la tarjeta
            '--------------------------------------------------------------------------------
            If CInt(lstResponse("trn_internal_respcode")) = -1 Then
                ebNumAut.Text = CStr(lstResponse("trn_auth_code"))
                valido = True
                ValoresPagoBanamex(lstResponse)
                '------------------------------------------------------------------------
                'FLIZARRAGA 18/01/2017: Se imprimen los vouchers
                '------------------------------------------------------------------------
                'PrintVoucherBanamex(lstResponse, False)
                'PrintVoucherBanamex(lstResponse, True)
                MessageBox.Show("Su pago fue realizado exitosamente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                valido = False
                MessageBox.Show(CStr(lstResponse("trn_msg_host")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            valido = False
        End If
        Return valido
    End Function

    Private Function GetResponse(ByVal response As String) As Dictionary(Of String, Object)
        Dim resultado As New Dictionary(Of String, Object)
        If response.Trim() <> "" Then
            Dim responses() As String = response.Split("|")
            Dim values() As String
            For Each answer As String In responses
                values = answer.Split("=")
                If values(0).Trim() <> "" Then
                    resultado(CStr(values(0)).Trim()) = values(1)
                End If
            Next
        End If
        Return resultado
    End Function

    Private Sub PrintVoucherBanamex(ByVal Datos As Dictionary(Of String, Object), ByVal EsCopia As Boolean)
        Dim oARReporte As New rptVoucherBanamex(Datos, EsCopia)
        oARReporte.Document.Name = "Voucher Banamex"

        If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

            oARReporte.PageSettings.PaperHeight = 7
            oARReporte.PageSettings.PaperWidth = 14
            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
            oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
            oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

        End If

        oARReporte.Run()

        'Dim oReportViewer As New ReportViewerForm
        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

        '-----------------------------------------------------------------------------------
        ' Imprimimos voucher 
        '-----------------------------------------------------------------------------------
        Try
            oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    '-----------------------------------------------------------------------------
    'FLIZARRAGA 17/01/2017: Obtiene las promociones de Banamex
    '-----------------------------------------------------------------------------

    Private Sub GetPromocionesBanamex()
        dtPromociones = oFacturaMgr.GetPromocionesBanamex()

        Me.cmbPromocion.DataSource = dtPromociones
        Me.cmbPromocion.DropDownList.Columns("CodPromo").DataMember = "Id_Num_Promo"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").DataMember = "Desc_Promo"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").Width = 150

        Me.cmbPromocion.DisplayMember = "Desc_Promo"
        Me.cmbPromocion.ValueMember = "Id_Num_Promo"
        Me.cmbPromocion.DropDownList.Columns("CodPromo").Visible = False
        Me.cmbPromocion.Refresh()
    End Sub

#End Region

#Region "Reducción Facturación"

    Private Function FiltrarTerminal(ByVal Terminal As String, ByVal dtFP As DataTable) As DataTable
        Dim dtTemp As DataTable = dtFP.Clone
        Dim oRow As DataRow

        For Each oRow In dtFP.Rows
            If InStr(Terminal.Trim().ToUpper(), CStr(oRow!CodBanco).Trim().ToUpper()) <= 0 Then
                dtTemp.ImportRow(oRow)
            End If
        Next

        Return dtTemp
    End Function

#End Region

    Private Sub frmAbonosContratos_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If TipoMov <> "AB" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ebAbono_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ebAbono.KeyPress
        If e.KeyChar = "-" Then
            e.KeyChar = ""
        End If
    End Sub
End Class
