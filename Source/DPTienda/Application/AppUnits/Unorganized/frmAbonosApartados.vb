Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoTarjetas



Public Class frmAbonosApartados

    Inherits System.Windows.Forms.Form
    Dim oPanelControl As Control
    

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
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoArticulos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTDescuento As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTVenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoArticulos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTDescuento1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTVenta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTAyuda2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebNumApartado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNumAbono As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDesCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDesVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSaldoNuevo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiBGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebNumCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNumVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ccFechaAbono As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents UiCFormaPago As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebAbono As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebTotalaPagar As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents UiCTipoTarjeta As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ebNumAut As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ebNumTarjeta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebCodBanco As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebSaldoActual As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCodCaja As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ccFechaApartado As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents uIProgressBar1 As Janus.Windows.EditControls.UIProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbonosApartados))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.uIProgressBar1 = New Janus.Windows.EditControls.UIProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ccFechaApartado = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ebCodCaja = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ebSaldoActual = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebCodBanco = New Janus.Windows.EditControls.UIComboBox()
        Me.ebNumTarjeta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ebNumAut = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.UiCTipoTarjeta = New Janus.Windows.EditControls.UIComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ebTotalaPagar = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ebAbono = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiCFormaPago = New Janus.Windows.EditControls.UIComboBox()
        Me.ebNumApartado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNumAbono = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDesCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDesVendedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSaldoNuevo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UiBGuardar = New Janus.Windows.EditControls.UIButton()
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
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoImprimir2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTAyuda2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTAyuda")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuCatalogo = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogo")
        Me.menuCatalogoArticulos1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoArticulos")
        Me.menuCatalogoTDescuento1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTDescuento")
        Me.menuCatalogoTVenta1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTVenta")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTAyuda")
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
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
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
        'UiGroupBox1
        '
        resources.ApplyResources(Me.UiGroupBox1, "UiGroupBox1")
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.ExplorerBar1)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'ExplorerBar1
        '
        resources.ApplyResources(Me.ExplorerBar1, "ExplorerBar1")
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.uIProgressBar1)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.ccFechaApartado)
        Me.ExplorerBar1.Controls.Add(Me.ebCodCaja)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.ebSaldoActual)
        Me.ExplorerBar1.Controls.Add(Me.ebCodBanco)
        Me.ExplorerBar1.Controls.Add(Me.ebNumTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.ebNumAut)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.UiCTipoTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.ebTotalaPagar)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.ebAbono)
        Me.ExplorerBar1.Controls.Add(Me.UiCFormaPago)
        Me.ExplorerBar1.Controls.Add(Me.ebNumApartado)
        Me.ExplorerBar1.Controls.Add(Me.ebNumAbono)
        Me.ExplorerBar1.Controls.Add(Me.ebDesCliente)
        Me.ExplorerBar1.Controls.Add(Me.ebDesVendedor)
        Me.ExplorerBar1.Controls.Add(Me.ebSaldoNuevo)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.UiBGuardar)
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
        resources.ApplyResources(ExplorerBarGroup1, "ExplorerBarGroup1")
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'uIProgressBar1
        '
        resources.ApplyResources(Me.uIProgressBar1, "uIProgressBar1")
        Me.uIProgressBar1.Name = "uIProgressBar1"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Name = "Label1"
        '
        'ccFechaApartado
        '
        resources.ApplyResources(Me.ccFechaApartado, "ccFechaApartado")
        Me.ccFechaApartado.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.ccFechaApartado.DropDownCalendar.AccessibleDescription = resources.GetString("ccFechaApartado.DropDownCalendar.AccessibleDescription")
        Me.ccFechaApartado.DropDownCalendar.AccessibleName = resources.GetString("ccFechaApartado.DropDownCalendar.AccessibleName")
        Me.ccFechaApartado.DropDownCalendar.Anchor = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ccFechaApartado.DropDownCalendar.BackgroundImage = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.BackgroundImage"), System.Drawing.Image)
        Me.ccFechaApartado.DropDownCalendar.BackgroundImageLayout = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.ccFechaApartado.DropDownCalendar.DayOfWeekAbbreviation = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.DayOfWeekAbbreviation"), Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)
        Me.ccFechaApartado.DropDownCalendar.Dock = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.Dock"), System.Windows.Forms.DockStyle)
        Me.ccFechaApartado.DropDownCalendar.FirstDayOfWeek = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.FirstDayOfWeek"), Janus.Windows.CalendarCombo.CalendarDayOfWeek)
        Me.ccFechaApartado.DropDownCalendar.Font = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.Font"), System.Drawing.Font)
        Me.ccFechaApartado.DropDownCalendar.HeaderFont = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.HeaderFont"), System.Drawing.Font)
        Me.ccFechaApartado.DropDownCalendar.HeaderFormat = resources.GetString("ccFechaApartado.DropDownCalendar.HeaderFormat")
        Me.ccFechaApartado.DropDownCalendar.ImeMode = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ccFechaApartado.DropDownCalendar.MaximumSize = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.MaximumSize"), System.Drawing.Size)
        Me.ccFechaApartado.DropDownCalendar.RightToLeft = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ccFechaApartado.DropDownCalendar.Visible = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.Visible"), Boolean)
        Me.ccFechaApartado.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccFechaApartado.DropDownCalendar.WeekNumbers = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.WeekNumbers"), Boolean)
        Me.ccFechaApartado.DropDownCalendar.WeekRule = CType(resources.GetObject("ccFechaApartado.DropDownCalendar.WeekRule"), System.Globalization.CalendarWeekRule)
        Me.ccFechaApartado.Name = "ccFechaApartado"
        Me.ccFechaApartado.ReadOnly = True
        Me.ccFechaApartado.TabStop = False
        Me.ccFechaApartado.Value = New Date(1, 2, 1, 0, 0, 0, 0)
        Me.ccFechaApartado.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ebCodCaja
        '
        resources.ApplyResources(Me.ebCodCaja, "ebCodCaja")
        Me.ebCodCaja.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebCodCaja.MaxLength = 8
        Me.ebCodCaja.Name = "ebCodCaja"
        Me.ebCodCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCodCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Name = "Label6"
        '
        'ebSaldoActual
        '
        resources.ApplyResources(Me.ebSaldoActual, "ebSaldoActual")
        Me.ebSaldoActual.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoActual.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSaldoActual.MaxLength = 8
        Me.ebSaldoActual.Name = "ebSaldoActual"
        Me.ebSaldoActual.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoActual.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodBanco
        '
        resources.ApplyResources(Me.ebCodBanco, "ebCodBanco")
        Me.ebCodBanco.BackColor = System.Drawing.Color.White
        Me.ebCodBanco.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebCodBanco.Name = "ebCodBanco"
        Me.ebCodBanco.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNumTarjeta
        '
        resources.ApplyResources(Me.ebNumTarjeta, "ebNumTarjeta")
        Me.ebNumTarjeta.BackColor = System.Drawing.Color.White
        Me.ebNumTarjeta.MaxLength = 20
        Me.ebNumTarjeta.Name = "ebNumTarjeta"
        Me.ebNumTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Name = "Label12"
        '
        'ebNumAut
        '
        resources.ApplyResources(Me.ebNumAut, "ebNumAut")
        Me.ebNumAut.BackColor = System.Drawing.Color.White
        Me.ebNumAut.MaxLength = 20
        Me.ebNumAut.Name = "ebNumAut"
        Me.ebNumAut.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumAut.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Name = "Label11"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Name = "Label10"
        '
        'UiCTipoTarjeta
        '
        resources.ApplyResources(Me.UiCTipoTarjeta, "UiCTipoTarjeta")
        Me.UiCTipoTarjeta.BackColor = System.Drawing.Color.White
        Me.UiCTipoTarjeta.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        resources.ApplyResources(UiComboBoxItem1, "UiComboBoxItem1")
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        resources.ApplyResources(UiComboBoxItem2, "UiComboBoxItem2")
        UiComboBoxItem2.IsSeparator = False
        Me.UiCTipoTarjeta.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2})
        Me.UiCTipoTarjeta.Name = "UiCTipoTarjeta"
        Me.UiCTipoTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Name = "Label7"
        '
        'ebTotalaPagar
        '
        resources.ApplyResources(Me.ebTotalaPagar, "ebTotalaPagar")
        Me.ebTotalaPagar.BackColor = System.Drawing.Color.Ivory
        Me.ebTotalaPagar.ForeColor = System.Drawing.Color.Black
        Me.ebTotalaPagar.Name = "ebTotalaPagar"
        Me.ebTotalaPagar.ReadOnly = True
        Me.ebTotalaPagar.TabStop = False
        Me.ebTotalaPagar.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTotalaPagar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Name = "Label3"
        '
        'ebAbono
        '
        resources.ApplyResources(Me.ebAbono, "ebAbono")
        Me.ebAbono.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebAbono.MaxLength = 8
        Me.ebAbono.Name = "ebAbono"
        Me.ebAbono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebAbono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiCFormaPago
        '
        resources.ApplyResources(Me.UiCFormaPago, "UiCFormaPago")
        Me.UiCFormaPago.BackColor = System.Drawing.Color.White
        Me.UiCFormaPago.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        resources.ApplyResources(UiComboBoxItem3, "UiComboBoxItem3")
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        resources.ApplyResources(UiComboBoxItem4, "UiComboBoxItem4")
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem5.FormatStyle.Alpha = 0
        resources.ApplyResources(UiComboBoxItem5, "UiComboBoxItem5")
        UiComboBoxItem5.IsSeparator = False
        Me.UiCFormaPago.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5})
        Me.UiCFormaPago.Name = "UiCFormaPago"
        Me.UiCFormaPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNumApartado
        '
        resources.ApplyResources(Me.ebNumApartado, "ebNumApartado")
        Me.ebNumApartado.BackColor = System.Drawing.Color.White
        Me.ebNumApartado.ButtonImage = CType(resources.GetObject("ebNumApartado.ButtonImage"), System.Drawing.Image)
        Me.ebNumApartado.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebNumApartado.MaxLength = 4
        Me.ebNumApartado.Name = "ebNumApartado"
        Me.ebNumApartado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumApartado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNumAbono
        '
        resources.ApplyResources(Me.ebNumAbono, "ebNumAbono")
        Me.ebNumAbono.BackColor = System.Drawing.Color.White
        Me.ebNumAbono.ButtonImage = CType(resources.GetObject("ebNumAbono.ButtonImage"), System.Drawing.Image)
        Me.ebNumAbono.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebNumAbono.MaxLength = 4
        Me.ebNumAbono.Name = "ebNumAbono"
        Me.ebNumAbono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumAbono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDesCliente
        '
        resources.ApplyResources(Me.ebDesCliente, "ebDesCliente")
        Me.ebDesCliente.BackColor = System.Drawing.Color.Ivory
        Me.ebDesCliente.Name = "ebDesCliente"
        Me.ebDesCliente.ReadOnly = True
        Me.ebDesCliente.TabStop = False
        Me.ebDesCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDesCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDesVendedor
        '
        resources.ApplyResources(Me.ebDesVendedor, "ebDesVendedor")
        Me.ebDesVendedor.BackColor = System.Drawing.Color.Ivory
        Me.ebDesVendedor.Name = "ebDesVendedor"
        Me.ebDesVendedor.ReadOnly = True
        Me.ebDesVendedor.TabStop = False
        Me.ebDesVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDesVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSaldoNuevo
        '
        resources.ApplyResources(Me.ebSaldoNuevo, "ebSaldoNuevo")
        Me.ebSaldoNuevo.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoNuevo.ForeColor = System.Drawing.Color.Red
        Me.ebSaldoNuevo.Name = "ebSaldoNuevo"
        Me.ebSaldoNuevo.ReadOnly = True
        Me.ebSaldoNuevo.TabStop = False
        Me.ebSaldoNuevo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSaldoNuevo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Name = "Label8"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Name = "Label5"
        '
        'UiBGuardar
        '
        resources.ApplyResources(Me.UiBGuardar, "UiBGuardar")
        Me.UiBGuardar.BackColor = System.Drawing.SystemColors.Window
        Me.UiBGuardar.Name = "UiBGuardar"
        Me.UiBGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Name = "Label19"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Name = "Label20"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Name = "Label17"
        '
        'ebNumCliente
        '
        resources.ApplyResources(Me.ebNumCliente, "ebNumCliente")
        Me.ebNumCliente.BackColor = System.Drawing.Color.Ivory
        Me.ebNumCliente.Name = "ebNumCliente"
        Me.ebNumCliente.ReadOnly = True
        Me.ebNumCliente.TabStop = False
        Me.ebNumCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Name = "Label15"
        '
        'ebNumVendedor
        '
        resources.ApplyResources(Me.ebNumVendedor, "ebNumVendedor")
        Me.ebNumVendedor.BackColor = System.Drawing.Color.Ivory
        Me.ebNumVendedor.Name = "ebNumVendedor"
        Me.ebNumVendedor.ReadOnly = True
        Me.ebNumVendedor.TabStop = False
        Me.ebNumVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Name = "Label14"
        '
        'ccFechaAbono
        '
        resources.ApplyResources(Me.ccFechaAbono, "ccFechaAbono")
        Me.ccFechaAbono.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ccFechaAbono.DropDownCalendar.AccessibleDescription = resources.GetString("ccFechaAbono.DropDownCalendar.AccessibleDescription")
        Me.ccFechaAbono.DropDownCalendar.AccessibleName = resources.GetString("ccFechaAbono.DropDownCalendar.AccessibleName")
        Me.ccFechaAbono.DropDownCalendar.Anchor = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ccFechaAbono.DropDownCalendar.BackgroundImage = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.BackgroundImage"), System.Drawing.Image)
        Me.ccFechaAbono.DropDownCalendar.BackgroundImageLayout = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.ccFechaAbono.DropDownCalendar.DayOfWeekAbbreviation = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.DayOfWeekAbbreviation"), Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)
        Me.ccFechaAbono.DropDownCalendar.Dock = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.Dock"), System.Windows.Forms.DockStyle)
        Me.ccFechaAbono.DropDownCalendar.FirstDayOfWeek = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.FirstDayOfWeek"), Janus.Windows.CalendarCombo.CalendarDayOfWeek)
        Me.ccFechaAbono.DropDownCalendar.Font = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.Font"), System.Drawing.Font)
        Me.ccFechaAbono.DropDownCalendar.HeaderFont = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.HeaderFont"), System.Drawing.Font)
        Me.ccFechaAbono.DropDownCalendar.HeaderFormat = resources.GetString("ccFechaAbono.DropDownCalendar.HeaderFormat")
        Me.ccFechaAbono.DropDownCalendar.ImeMode = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ccFechaAbono.DropDownCalendar.MaximumSize = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.MaximumSize"), System.Drawing.Size)
        Me.ccFechaAbono.DropDownCalendar.RightToLeft = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ccFechaAbono.DropDownCalendar.Visible = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.Visible"), Boolean)
        Me.ccFechaAbono.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccFechaAbono.DropDownCalendar.WeekNumbers = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.WeekNumbers"), Boolean)
        Me.ccFechaAbono.DropDownCalendar.WeekRule = CType(resources.GetObject("ccFechaAbono.DropDownCalendar.WeekRule"), System.Globalization.CalendarWeekRule)
        Me.ccFechaAbono.Name = "ccFechaAbono"
        Me.ccFechaAbono.ReadOnly = True
        Me.ccFechaAbono.Value = New Date(1, 2, 1, 0, 0, 0, 0)
        Me.ccFechaAbono.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Name = "Label2"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Name = "Label18"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Name = "Label4"
        '
        'UiCommandManager1
        '
        resources.ApplyResources(Me.UiCommandManager1, "UiCommandManager1")
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuCatalogo, Me.menuAyuda, Me.menuSalir, Me.menuArchivoNuevo, Me.menuAbrir, Me.menuArchivoGuardar, Me.menuArchivoImprimir, Me.menuCatalogoArticulos, Me.menuCatalogoTDescuento, Me.menuCatalogoTVenta, Me.menuAyudaTAyuda, Me.menuAyudaAcerca})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.ImageList = CType(resources.GetObject("UiCommandManager1.EditContextMenu.ImageList"), System.Windows.Forms.ImageList)
        Me.UiCommandManager1.EditContextMenu.Key = resources.GetString("UiCommandManager1.EditContextMenu.Key")
        Me.UiCommandManager1.EditContextMenu.LargeImageList = CType(resources.GetObject("UiCommandManager1.EditContextMenu.LargeImageList"), System.Windows.Forms.ImageList)
        Me.UiCommandManager1.Id = New System.Guid("c8af8fdc-fb84-42ff-8aca-a04e79f69109")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        Me.UiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        resources.ApplyResources(Me.BottomRebar1, "BottomRebar1")
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Name = "BottomRebar1"
        '
        'UiCommandBar1
        '
        resources.ApplyResources(Me.UiCommandBar1, "UiCommandBar1")
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1, Me.menuSalir1})
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        '
        'menuArchivo1
        '
        resources.ApplyResources(Me.menuArchivo1, "menuArchivo1")
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'menuAyuda1
        '
        resources.ApplyResources(Me.menuAyuda1, "menuAyuda1")
        Me.menuAyuda1.Name = "menuAyuda1"
        '
        'menuSalir1
        '
        resources.ApplyResources(Me.menuSalir1, "menuSalir1")
        Me.menuSalir1.Name = "menuSalir1"
        '
        'UiCommandBar2
        '
        resources.ApplyResources(Me.UiCommandBar2, "UiCommandBar2")
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.Separator3, Me.menuAbrir2, Me.Separator4, Me.menuArchivoGuardar2, Me.Separator5, Me.menuArchivoImprimir2, Me.Separator6, Me.menuAyudaTAyuda2})
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuArchivoNuevo2
        '
        resources.ApplyResources(Me.menuArchivoNuevo2, "menuArchivoNuevo2")
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        resources.ApplyResources(Me.Separator3, "Separator3")
        Me.Separator3.Name = "Separator3"
        '
        'menuAbrir2
        '
        resources.ApplyResources(Me.menuAbrir2, "menuAbrir2")
        Me.menuAbrir2.Name = "menuAbrir2"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        resources.ApplyResources(Me.Separator4, "Separator4")
        Me.Separator4.Name = "Separator4"
        '
        'menuArchivoGuardar2
        '
        Me.menuArchivoGuardar2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage
        resources.ApplyResources(Me.menuArchivoGuardar2, "menuArchivoGuardar2")
        Me.menuArchivoGuardar2.Name = "menuArchivoGuardar2"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        resources.ApplyResources(Me.Separator5, "Separator5")
        Me.Separator5.Name = "Separator5"
        '
        'menuArchivoImprimir2
        '
        Me.menuArchivoImprimir2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage
        resources.ApplyResources(Me.menuArchivoImprimir2, "menuArchivoImprimir2")
        Me.menuArchivoImprimir2.Name = "menuArchivoImprimir2"
        Me.menuArchivoImprimir2.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        resources.ApplyResources(Me.Separator6, "Separator6")
        Me.Separator6.Name = "Separator6"
        Me.Separator6.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuAyudaTAyuda2
        '
        resources.ApplyResources(Me.menuAyudaTAyuda2, "menuAyudaTAyuda2")
        Me.menuAyudaTAyuda2.Name = "menuAyudaTAyuda2"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.menuAbrir1, Me.Separator1, Me.menuArchivoGuardar1, Me.Separator2})
        resources.ApplyResources(Me.menuArchivo, "menuArchivo")
        Me.menuArchivo.Name = "menuArchivo"
        '
        'menuArchivoNuevo1
        '
        resources.ApplyResources(Me.menuArchivoNuevo1, "menuArchivoNuevo1")
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'menuAbrir1
        '
        resources.ApplyResources(Me.menuAbrir1, "menuAbrir1")
        Me.menuAbrir1.Name = "menuAbrir1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        resources.ApplyResources(Me.Separator1, "Separator1")
        Me.Separator1.Name = "Separator1"
        '
        'menuArchivoGuardar1
        '
        resources.ApplyResources(Me.menuArchivoGuardar1, "menuArchivoGuardar1")
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        resources.ApplyResources(Me.Separator2, "Separator2")
        Me.Separator2.Name = "Separator2"
        Me.Separator2.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuCatalogo
        '
        Me.menuCatalogo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuCatalogoArticulos1, Me.menuCatalogoTDescuento1, Me.menuCatalogoTVenta1})
        resources.ApplyResources(Me.menuCatalogo, "menuCatalogo")
        Me.menuCatalogo.Name = "menuCatalogo"
        '
        'menuCatalogoArticulos1
        '
        resources.ApplyResources(Me.menuCatalogoArticulos1, "menuCatalogoArticulos1")
        Me.menuCatalogoArticulos1.Name = "menuCatalogoArticulos1"
        '
        'menuCatalogoTDescuento1
        '
        resources.ApplyResources(Me.menuCatalogoTDescuento1, "menuCatalogoTDescuento1")
        Me.menuCatalogoTDescuento1.Name = "menuCatalogoTDescuento1"
        '
        'menuCatalogoTVenta1
        '
        resources.ApplyResources(Me.menuCatalogoTVenta1, "menuCatalogoTVenta1")
        Me.menuCatalogoTVenta1.Name = "menuCatalogoTVenta1"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTAyuda1})
        resources.ApplyResources(Me.menuAyuda, "menuAyuda")
        Me.menuAyuda.Name = "menuAyuda"
        '
        'menuAyudaTAyuda1
        '
        resources.ApplyResources(Me.menuAyudaTAyuda1, "menuAyudaTAyuda1")
        Me.menuAyudaTAyuda1.Name = "menuAyudaTAyuda1"
        '
        'menuSalir
        '
        resources.ApplyResources(Me.menuSalir, "menuSalir")
        Me.menuSalir.Name = "menuSalir"
        '
        'menuArchivoNuevo
        '
        resources.ApplyResources(Me.menuArchivoNuevo, "menuArchivoNuevo")
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        '
        'menuAbrir
        '
        resources.ApplyResources(Me.menuAbrir, "menuAbrir")
        Me.menuAbrir.Name = "menuAbrir"
        '
        'menuArchivoGuardar
        '
        resources.ApplyResources(Me.menuArchivoGuardar, "menuArchivoGuardar")
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        '
        'menuArchivoImprimir
        '
        resources.ApplyResources(Me.menuArchivoImprimir, "menuArchivoImprimir")
        Me.menuArchivoImprimir.Name = "menuArchivoImprimir"
        '
        'menuCatalogoArticulos
        '
        resources.ApplyResources(Me.menuCatalogoArticulos, "menuCatalogoArticulos")
        Me.menuCatalogoArticulos.Name = "menuCatalogoArticulos"
        '
        'menuCatalogoTDescuento
        '
        resources.ApplyResources(Me.menuCatalogoTDescuento, "menuCatalogoTDescuento")
        Me.menuCatalogoTDescuento.Name = "menuCatalogoTDescuento"
        '
        'menuCatalogoTVenta
        '
        resources.ApplyResources(Me.menuCatalogoTVenta, "menuCatalogoTVenta")
        Me.menuCatalogoTVenta.Name = "menuCatalogoTVenta"
        '
        'menuAyudaTAyuda
        '
        resources.ApplyResources(Me.menuAyudaTAyuda, "menuAyudaTAyuda")
        Me.menuAyudaTAyuda.Name = "menuAyudaTAyuda"
        '
        'menuAyudaAcerca
        '
        resources.ApplyResources(Me.menuAyudaAcerca, "menuAyudaAcerca")
        Me.menuAyudaAcerca.Name = "menuAyudaAcerca"
        '
        'LeftRebar1
        '
        resources.ApplyResources(Me.LeftRebar1, "LeftRebar1")
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Name = "LeftRebar1"
        '
        'RightRebar1
        '
        resources.ApplyResources(Me.RightRebar1, "RightRebar1")
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Name = "RightRebar1"
        '
        'TopRebar1
        '
        resources.ApplyResources(Me.TopRebar1, "TopRebar1")
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Name = "TopRebar1"
        '
        'frmAbonosApartados
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TopRebar1)
        Me.KeyPreview = True
        Me.Name = "frmAbonosApartados"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
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
    Private oCliente As Clientes

    Private oCatalogoVendedoresMgr As New CatalogoVendedoresManager(oAppContext)
    Private oVendedor As Vendedor

    Private oContratosMgr As New ContratoManager(oAppContext)
    Private oContratos As Contrato

    Private oCatalogoFormasPagoMgr As New CatalogoFormasPagoManager(oAppContext)
    Private oCatalogoFormasPago As FormaPago

    Dim dtFormasPago As DataTable
    Dim vImporteApartado As Decimal
    Dim vlComisionBancaria As Decimal
    Dim vlIngresoComision As Decimal
    Dim vlIvaComision As Decimal


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

        If (UiCFormaPago.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar la Forma de Pago", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            UiCFormaPago.Focus()
            Exit Function
        End If

        If UiCFormaPago.Text = "T" Or UiCFormaPago.Text = "D" Then

            If (UiCTipoTarjeta.Text.Trim = String.Empty) Then
                MessageBox.Show("Debe especificar el Tipo de Tarjeta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                UiCTipoTarjeta.Focus()
                Exit Function
            End If

            If (ebNumTarjeta.Text.Trim = String.Empty) Then
                MessageBox.Show("Debe especificar el Numero de Tarjeta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebNumTarjeta.Focus()
                Exit Function
            End If

            If (ebNumAut.Text.Trim = String.Empty) Then
                MessageBox.Show("Debe especificar el Numero de Autorización", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebNumAut.Focus()
                Exit Function
            End If

        End If

        If (ebAbono.Text.Trim = String.Empty Or ebAbono.Text.Trim = 0) Then
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

        Dim x As Integer

        CLearFields()
        DesBloquearFields()
        FieldsTarjetaNoVisible()

        ebNumAbono.Text = oAbonosApartadosMgr.Folios()
        ebNumAbono.Enabled = False
        Me.ebNumApartado.Focus()


        On Error Resume Next
        oAbonosApartados = Nothing
        Me.ebNumApartado.Focus()

    End Sub


    Private Sub Sm_Guardar()

        Dim vlPAbono As Decimal
        Dim vlPorcentajeAbono As Integer
        Dim vebAbono As Decimal
        Dim vebSaldoActual As Decimal

        If (oAbonosApartados Is Nothing) Then   'Opción Guardar.

            If (MessageBox.Show("¿ Desea Grabar el Abono ?", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                Exit Sub
            End If


            If (Fm_bolTxtValidar("Guardar") = False) Then
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
                    Exit Sub
                End If

            End If

            If vebAbono > vebSaldoActual Then
                MessageBox.Show("El Monto de Abono es mayor que el Saldo Actual", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                ebAbono.Focus()
                Exit Sub
            End If

            oAbonosApartados = oAbonosApartadosMgr.Create


            oAbonosApartados.ID = ebNumAbono.Text
            oAbonosApartados.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
            oAbonosApartados.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
            oAbonosApartados.ApartadoID = oContratos.ID
            oAbonosApartados.ClienteID = ebNumCliente.Text
            oAbonosApartados.FolioAbono = ebNumAbono.Text
            oAbonosApartados.CodVendedor = ebNumVendedor.Text
            oAbonosApartados.CodFormaPago = Me.UiCFormaPago.Text
            oAbonosApartados.TipoTarjeta = UiCTipoTarjeta.Text
            oAbonosApartados.CodBanco = ebCodBanco.Text
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
            ValidaNumAbono()


            MessageBox.Show("Su Abono ha sido Grabado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If (MessageBox.Show("¿ Imprimir ?", "DPTienda", MessageBoxButtons.OKCancel, _
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK) Then


                ActionPreview()

            End If

            If ebSaldoNuevo.Text = 0 Then

                Dim oResult As MsgBoxResult
                oResult = MsgBox("Listo para Facturarse. ¿ Desea Continuar ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, " Abonos Apartados")

                'Falta codigo que llama al formulario de la facturacion
                If oResult = MsgBoxResult.Yes Then

                    '---------------------------------------------------------------------
                    ' JNAVA (02.03.2017): Validamos si está activa la nueva facturacion
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
            oAbonosApartados.CodFormaPago = Me.UiCFormaPago.Text
            oAbonosApartados.TipoTarjeta = UiCTipoTarjeta.Text
            oAbonosApartados.CodBanco = ebCodBanco.Text
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
            UiCFormaPago.Text = oAbonosApartados.CodFormaPago
            UiCTipoTarjeta.Text = oAbonosApartados.TipoTarjeta
            ebCodBanco.Text = oAbonosApartados.CodBanco
            ebNumTarjeta.Text = oAbonosApartados.NumeroTarjeta
            ebNumAut.Text = oAbonosApartados.NumeroAutorizacion
            ebAbono.Text = Format(oAbonosApartados.Abono, "Currency")
            ebSaldoActual.Text = Format(oAbonosApartados.SaldoActual, "Currency")
            ebSaldoNuevo.Text = Format(oAbonosApartados.SaldoNuevo, "Currency")
            ebTotalaPagar.Text = Format((oAbonosApartados.Abono + oAbonosApartados.ComisionBancaria), "Currency")

            MessageBox.Show("La información ha sido Actualizada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        oAbonosApartados = Nothing
    End Sub

    Private Sub Sm_Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)


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
                UiCFormaPago.Text = oAbonosApartados.CodFormaPago
                UiCTipoTarjeta.Text = oAbonosApartados.TipoTarjeta
                ebCodBanco.Text = oAbonosApartados.CodBanco
                ebNumTarjeta.Text = oAbonosApartados.NumeroTarjeta
                ebNumAut.Text = oAbonosApartados.NumeroAutorizacion
                ebSaldoActual.Text = Format(oAbonosApartados.SaldoActual, "Currency")
                ebAbono.Value = oAbonosApartados.Abono
                ebSaldoNuevo.Text = Format(oAbonosApartados.SaldoNuevo, "Currency")
                ccFechaAbono.Value = oAbonosApartados.Fecha
                ebTotalaPagar.Text = Format((oAbonosApartados.Abono + oAbonosApartados.ComisionBancaria), "Currency")

                If ebNumCliente.Text <> String.Empty Then
                    'Obtener nombre del cliente
                    oCliente = oClienteMgr.Create
                    oClienteMgr.LoadInto(oOpenRecordDlg.Record.Item("ClienteID"), oCliente)
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

                If UiCFormaPago.Text = "T" Or UiCFormaPago.Text = "D" Then
                    FieldsTarjetaVisible()
                ElseIf UiCFormaPago.Text = "E" Then
                    FieldsTarjetaNoVisible()
                End If

                BloquearFields()
                ActionPreview()

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
                UiCFormaPago.Text = oAbonosApartados.CodFormaPago
                UiCTipoTarjeta.Text = oAbonosApartados.TipoTarjeta
                ebCodBanco.Text = oAbonosApartados.CodBanco
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

                        MsgBox("Este Apartado ya fue Liquidado. Verifique. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Apartados")
                        ClearFieldsApar()
                        Exit Sub

                    End If

                    ClearFieldsApar()

                    ebNumApartado.Text = oOpenRecordDlg.Record.Item("FolioApartado")
                    ebNumCliente.Text = oContratos.ClienteID
                    ebNumVendedor.Text = oContratos.PlayerID
                    ebSaldoActual.Text = Format(oContratos.Saldo, "Currency")
                    ccFechaApartado.Value = oContratos.Fecha
                    vImporteApartado = oContratos.ImporteTotal

                    If ebNumCliente.Text <> String.Empty Then
                        'Obtener nombre del cliente
                        oCliente = oClienteMgr.Create
                        oClienteMgr.LoadInto(oOpenRecordDlg.Record.Item("ClienteID"), oCliente)
                        ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                    End If

                    If ebNumVendedor.Text <> String.Empty Then
                        'obteber nombre de player
                        oVendedor = oCatalogoVendedoresMgr.Load(oOpenRecordDlg.Record.Item("CodVendedor"))
                        ebDesVendedor.Text = oVendedor.Nombre
                    End If
                    UiCFormaPago.Focus()

                ElseIf oContratos.Entregada = "S" Then

                    MsgBox("Este Apartado ya fue Entregado. Verifique. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Apartados")
                    ClearFieldsApar()
                    ebNumApartado.Focus()

                ElseIf oContratos.Entregada = "V" Then

                    MsgBox("Este Apartado esta Vencido. Verifique. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Apartados")
                    ClearFieldsApar()
                    ebNumApartado.Focus()

                End If

            Else

                ebNumApartado.Focus()

            End If

        Else

            On Error Resume Next


            oContratos = Nothing
            oContratos = oContratosMgr.LoadFolioCaja(Me.ebNumApartado.Text, _
            ebCodCaja.Text)

            If oContratos.Entregada = "N" Then

                If oContratos.Saldo <= 0 Then

                    MsgBox("Este Apartado ya fue Liquidado. Verifique. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Apartados")
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
                    oCliente = oClienteMgr.Create
                    oClienteMgr.LoadInto(oContratos.ClienteID, oCliente)
                    ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                End If

                If ebNumVendedor.Text <> String.Empty Then
                    'obteber nombre de player
                    oVendedor = oCatalogoVendedoresMgr.Load(oContratos.PlayerID)
                    ebDesVendedor.Text = oVendedor.Nombre
                End If
                UiCFormaPago.Focus()

            ElseIf oContratos.Entregada = "S" Then

                MsgBox("Este Apartado ya fue Entregado. Verifique. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Apartados")
                ClearFieldsApar()
                ebNumApartado.Focus()

            ElseIf oContratos.Entregada = "V" Then

                MsgBox("Este Apartado esta Vencido. Verifique. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Apartados")
                ClearFieldsApar()
                ebNumApartado.Focus()

            End If
        End If

    End Sub

    Private Sub Sm_BuscarCliente()

        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oCliente = oClienteMgr.Create

            oClienteMgr.LoadInto(oOpenRecordDlg.Record.Item("ClienteID"), oCliente)

            If oCliente.ClienteID = 0 Then

                MsgBox("Cliente no está registrado. Verifique. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Clientes")
                ebNumCliente.Focus()

            Else

                ebNumCliente.Text = oCliente.ClienteID
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
        UiCFormaPago.Text = String.Empty
        ebSaldoActual.Text = Format(0, "Currency")
        ebAbono.Text = Format(0, "Currency")
        ebSaldoNuevo.Text = Format(0, "Currency")
        'UiCTarjeta.Text = String.Empty
        UiCTipoTarjeta.Text = String.Empty
        ebCodBanco.Text = String.Empty
        ebNumTarjeta.Text = String.Empty
        ebTotalaPagar.Text = String.Empty
        ebNumAut.Text = String.Empty

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
        UiCFormaPago.Text = String.Empty
        ebSaldoActual.Text = Format(0, "Currency")
        ebAbono.Text = Format(0, "Currency")
        ebSaldoNuevo.Text = Format(0, "Currency")
        'UiCTarjeta.Text = String.Empty
        UiCTipoTarjeta.Text = String.Empty
        ebCodBanco.Text = String.Empty
        ebNumTarjeta.Text = String.Empty
        ebTotalaPagar.Text = String.Empty
        ebNumAut.Text = String.Empty

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
        UiCFormaPago.Enabled = False
        ebSaldoActual.Enabled = False
        ebAbono.Enabled = False
        ebSaldoNuevo.Enabled = False
        'UiCTarjeta.Enabled = False
        UiCTipoTarjeta.Enabled = False
        ebCodBanco.Enabled = False
        ebNumTarjeta.Enabled = False
        ebNumAut.Enabled = False
        ebTotalaPagar.Enabled = False

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
        UiCFormaPago.Enabled = True
        ebSaldoActual.Enabled = True
        ebAbono.Enabled = True
        ebSaldoNuevo.Enabled = True
        'UiCTarjeta.Enabled = True
        UiCTipoTarjeta.Enabled = True
        ebCodBanco.Enabled = True
        ebNumTarjeta.Enabled = True
        ebNumAut.Enabled = True
        ebTotalaPagar.Enabled = True

        ebNumAbono.Focus()
    End Sub

    Private Sub FieldsTarjetaVisible()

        'Label6.Visible = True
        'UiCTarjeta.Visible = True
        Label7.Visible = True
        UiCTipoTarjeta.Visible = True
        Label10.Visible = True
        ebCodBanco.Visible = True
        Label11.Visible = True
        ebNumAut.Visible = True
        Label12.Visible = True
        ebNumTarjeta.Visible = True
        Label3.Visible = True
        ebTotalaPagar.Visible = True

    End Sub

    Private Sub FieldsTarjetaNoVisible()

        'Label6.Visible = False
        'UiCTarjeta.Visible = False
        Label7.Visible = False
        UiCTipoTarjeta.Visible = False
        Label10.Visible = False
        ebCodBanco.Visible = False
        Label11.Visible = False
        ebNumAut.Visible = False
        Label12.Visible = False
        ebNumTarjeta.Visible = False
        Label3.Visible = False
        ebTotalaPagar.Visible = False

    End Sub


    Public Sub ActionPreview()

        'Dim oARReporte As New rptAbonoApartado(Me)
        Dim oReportViewer As New ReportViewerForm

        'If (oContrato Is Nothing) Then
        'MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
        'MsgBox("Debe Abrir un Contrato.", MsgBoxStyle.Exclamation, "DPTienda")
        'Exit Sub
        'End If

        'oARReporte.DataSource = oContrato.Detalle.Tables(0)
        'oARReporte.Document.Name = "Abono Apartado"
        'oARReporte.Run()

        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

        Try
            'oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
#End Region



#Region "Métodos Miembros [Eventos]"

    Private Sub AbonosApartadosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oAbonosApartadosMgr = New AbonosApartadosManager(oAppContext)

        CLearFields()
        ccFechaApartado.Value = Now.Date
        ccFechaAbono.Value = Now.Date

        'FillComboFormasPago()
        Me.UiCFormaPago.SelectedIndex = 0

        Dim oCBancosMgr As New CatalogoBancosManager(oAppContext)
        Dim dsBancos As DataSet
        dsBancos = oCBancosMgr.GetAll(False)

        Me.ebCodBanco.DataSource = dsBancos
        Me.ebCodBanco.DataMember = "CatalogoBancos"
        Me.ebCodBanco.DisplayMember = "CodBanco"

        Dim oCatalogoTipoTarjetasMgr As New CatalogoTipoTarjetasManager(oAppContext)
        Dim dsTarjetas As DataSet
        dsTarjetas = oCatalogoTipoTarjetasMgr.GetAll(False)

        Me.UiCTipoTarjeta.DataSource = dsTarjetas
        Me.UiCTipoTarjeta.DataMember = "CatalogoTipoTarjetas"
        Me.UiCTipoTarjeta.DisplayMember = "CodTipoTarjeta"


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

                Sm_Guardar()

            Case "menuAyudaTema"


            Case "menuSalir"

                oAbonosApartados = Nothing
                Me.Close()

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

    Private Sub UiBGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBGuardar.Click
        Sm_Guardar()
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
                MsgBox("Apartado " & Format(myID, "00000000") & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Apartados")
                ClearFieldsApar()
                ebNumApartado.Focus()
                Exit Sub
            End If

            If oContratos.ID = 0 Then
                MsgBox("Apartado " & Format(myID, "00000000") & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Apartados")
                ebNumApartado.Focus()
            Else
                If oContratos.Entregada = "N" Then
                    If oContratos.Saldo <= 0 Then
                        MsgBox("Este Apartado ya fue Liquidado. Verifique. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Apartados")
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
                        oCliente = oClienteMgr.Create
                        oClienteMgr.LoadInto(oContratos.ClienteID, oCliente)
                        ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                    End If
                    If ebNumVendedor.Text <> String.Empty Then
                        'obtener nombre de player
                        oVendedor = oCatalogoVendedoresMgr.Load(oContratos.PlayerID)
                        ebDesVendedor.Text = oVendedor.Nombre
                    End If

                    UiCFormaPago.Focus()

                ElseIf oContratos.Entregada = "S" Then

                    MsgBox("Este Apartado ya fue Entregado. Verifique. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Apartados")
                    ClearFieldsApar()
                    ebNumApartado.Focus()

                ElseIf oContratos.Entregada = "V" Then

                    MsgBox("Este Apartado esta Vencido. Verifique. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Apartados")
                    ClearFieldsApar()
                    ebNumApartado.Focus()

                End If
            End If

        Else

            MsgBox("El Numero de Apartado debe ser mayor a 0 .", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Apartados")
            ClearFieldsApar()
            ebNumApartado.Focus()

        End If
    End Sub

  

    Private Sub ebAbono_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebAbono.Validating

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

                If Me.UiCFormaPago.Text = "T" Or Me.UiCFormaPago.Text = "D" Then

                    If Me.UiCFormaPago.Text = "T" Then

                        ebCodBanco.Text = oAppContext.ApplicationConfiguration.BancoParaTarjetas
                        vlComision = oAppContext.ApplicationConfiguration.ComisionTarjetaCredito

                    ElseIf Me.UiCFormaPago.Text = "D" Then

                        ebCodBanco.Text = oAppContext.ApplicationConfiguration.BancoParaTarjetas
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
                MsgBox("Abono " & Format(myID, "00000000") & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Abonos")
                CLearFields()
                ebNumAbono.Focus()
                Exit Sub
            End If

            If oAbonosApartados.ID = 0 Then

                MsgBox("Abono " & Format(myID, "00000000") & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Abonos")

                DesBloquearFields()

                ebNumAbono.Focus()

            Else


                ebNumAbono.Text = oAbonosApartados.FolioAbono
                ebNumApartado.Text = oAbonosApartados.FolioApartado
                ebNumCliente.Text = oAbonosApartados.ClienteID
                ebNumVendedor.Text = oAbonosApartados.CodVendedor
                UiCFormaPago.Text = oAbonosApartados.CodFormaPago
                UiCTipoTarjeta.Text = oAbonosApartados.TipoTarjeta
                ebCodBanco.Text = oAbonosApartados.CodBanco
                ebNumTarjeta.Text = oAbonosApartados.NumeroTarjeta
                ebNumAut.Text = oAbonosApartados.NumeroAutorizacion
                ebSaldoActual.Text = Format(oAbonosApartados.SaldoActual, "Currency")
                ebAbono.Value = oAbonosApartados.Abono
                ebSaldoNuevo.Text = Format(oAbonosApartados.SaldoNuevo, "Currency")
                ccFechaAbono.Value = oAbonosApartados.Fecha
                ebTotalaPagar.Text = Format((oAbonosApartados.Abono + oAbonosApartados.ComisionBancaria), "Currency")

                If ebNumCliente.Text <> String.Empty Then
                    'Obtener nombre del cliente
                    oCliente = oClienteMgr.Create
                    oClienteMgr.LoadInto(oAbonosApartados.ClienteID, oCliente)
                    ebDesCliente.Text = oCliente.Nombre + " " + oCliente.ApellidoPaterno + " " + oCliente.ApellidoMaterno
                End If

                If ebNumVendedor.Text <> String.Empty Then
                    'obteber nombre de player
                    oVendedor = oCatalogoVendedoresMgr.Load(oAbonosApartados.CodVendedor)
                    ebDesVendedor.Text = oVendedor.Nombre
                End If

                If ccFechaApartado.Text <> String.Empty Then
                    'obtener fecha de apartado
                    oContratos = oContratosMgr.LoadFolioApartado(oAbonosApartados.FolioApartado)
                    ccFechaApartado.Value = oContratos.Fecha
                End If

                BloquearFields()

                If UiCFormaPago.Text = "T" Or UiCFormaPago.Text = "D" Then
                    FieldsTarjetaVisible()
                End If


            End If

        Else

            If ebNumAbono.Text <= 0 Then

                ebNumAbono.Text = oAbonosApartados.ID

            End If

        End If
    End Sub

    Private Sub UiCFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiCFormaPago.SelectedIndexChanged

        If UiCFormaPago.Text = "T" Or UiCFormaPago.Text = "D" Then

            FieldsTarjetaVisible()

            UiCTipoTarjeta.Text = String.Empty
            ebCodBanco.Text = String.Empty
            ebNumTarjeta.Text = String.Empty
            ebNumAut.Text = String.Empty

            oAppContext.ApplicationConfiguration.BancoParaTarjetas = "BNCR"
            ebCodBanco.Text = oAppContext.ApplicationConfiguration.BancoParaTarjetas

            If UiCFormaPago.Text = "D" Then
                Me.UiCTipoTarjeta.Text = "TE"
                Me.UiCTipoTarjeta.ReadOnly = True
            ElseIf Me.UiCFormaPago.Text = "T" Then
                Me.UiCTipoTarjeta.ReadOnly = False
            End If

        Else
            FieldsTarjetaNoVisible()
            ebAbono.Focus()
            'oAppContext.ApplicationConfiguration.BancoParaTarjetas = "BNCR"
            'ebCodBanco.Text = oAppContext.ApplicationConfiguration.BancoParaTarjetas
        End If

    End Sub


#End Region



    Private Sub frmAbonosApartados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Sm_ActionPrintReporteAbonosApartados()
        Sm_ActionPrintReporteAbonosCreditoDirecto()
    End Sub

    Private Sub Sm_ActionPrintReporteAbonosApartados()
        Dim oARReporte As New rptAbonosApartados(Now)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Abono Apartado"
        oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            oARReporte.Document.Print(True, True)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Sm_ActionPrintReporteAbonosCreditoDirecto()

        Dim oAbonoCreditoDirectoMgr As New AbonoCreditoDirectoManager(oAppContext)

        Dim dsAbonosCreditoDT As New DataSet

        'dsAbonosCreditoDT = oAbonoCreditoDirectoMgr.GetByDate(Now, oAppContext.ApplicationConfiguration.Almacen)

        If dsAbonosCreditoDT Is Nothing Or (dsAbonosCreditoDT.Tables(0).Rows.Count = 0) Then

            If Not dsAbonosCreditoDT Is Nothing Then

                dsAbonosCreditoDT.Dispose()
                dsAbonosCreditoDT = Nothing

                oAbonoCreditoDirectoMgr = Nothing

            End If

            Return

        End If

        Dim oARReporte As New frmAbonosCreditoDirecto(Now, dsAbonosCreditoDT)

        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Abono Credito Directo"

        oARReporte.Run()

        oReportViewer.Report = oARReporte

        oReportViewer.Show()

        Try

            oARReporte.Document.Print(True, True)

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

    End Sub

    Private Sub ebCodCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodCaja.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarApartado(True)

        ElseIf e.KeyCode = Keys.Enter Then

            Sm_BuscarApartado()

        End If
    End Sub

    Private Sub ebCodBanco_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodBanco.Validating
        Dim oForm As New frmFotosTerminal
        oForm.ShowDialog()


        If oForm.intResultForm = 1 Then
            ebCodBanco.Text = "T1"
            ebCodBanco.ValueMember = "T1"
            'EBBanco.Text = "BANCOMER"
        ElseIf oForm.intResultForm = 2 Then
            ebCodBanco.Text = "T2"
            ebCodBanco.ValueMember = "T2"
            'EBBanco.Text = "SANTANDER"
        ElseIf oForm.intResultForm = 3 Then
            ebCodBanco.Text = "T3"
            ebCodBanco.ValueMember = "T3"
            'EBBanco.Text = "BANAMEX"
        End If
        ebNumTarjeta.Focus()
    End Sub
End Class


