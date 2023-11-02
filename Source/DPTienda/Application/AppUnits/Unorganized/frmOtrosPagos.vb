Imports System.IO
Imports Janus.Windows.GridEX
Imports EO.WebBrowser

Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoPromocionesAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoTarjetas
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU

Imports System.Web.Mail
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmOtrosPagos
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal SinSAP As Boolean = False)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Inicializar()

        '----------------------------------------------------------
        ' JNAVA (03.04.2016): Habilitar pagos sin SAP Retail
        '----------------------------------------------------------
        bolSinSAP = SinSAP

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuLimpiar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRealizarPago As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuLimpiar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRealizarPago1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cmbConceptoPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnLeerTarjeta As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebNumTarj As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents ebCodBanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebTipoTarjeta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents EBBanco As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents EBTarjeta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblLabel10 As System.Windows.Forms.Label
    Friend WithEvents ebTotalPagoCliente As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents gridFormaPago As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebImporteTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbPromocion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblPromocion As System.Windows.Forms.Label
    Friend WithEvents ebAutorizacion As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarFP As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnRealizarPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebPlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombrePlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents exDatosGenerales As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents EBPago As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbFormaPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents exFormasPago As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents exPagoEcommerce As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebNumOrden As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCVV2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblValidaOrden As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents exAbonosDPCard As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebNumDPCard As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebClienteDPC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSaldoDPC As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnLeerDPCard As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblValidaDPCard As System.Windows.Forms.Label
    Friend WithEvents cmbFechaLimite As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebPagoVencido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebPagoMinimo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTipoPago As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOtrosPagos))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout5 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout6 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout7 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup4 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.exFormasPago = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cmbFormaPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbPromocion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblPromocion = New System.Windows.Forms.Label()
        Me.ebAutorizacion = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnRealizarPago = New Janus.Windows.EditControls.UIButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ebCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ebImporteTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.gridFormaPago = New Janus.Windows.GridEX.GridEX()
        Me.ebTotalPagoCliente = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnLeerTarjeta = New Janus.Windows.EditControls.UIButton()
        Me.ebNumTarj = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.ebCodBanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebTipoTarjeta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.EBBanco = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.EBTarjeta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnAgregarFP = New Janus.Windows.EditControls.UIButton()
        Me.EBPago = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblLabel10 = New System.Windows.Forms.Label()
        Me.txtCVV2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.exDatosGenerales = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cmbTipoPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblTipoPago = New System.Windows.Forms.Label()
        Me.cmbConceptoPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ebPlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombrePlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.exAbonosDPCard = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cmbFechaLimite = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ebPagoVencido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ebPagoMinimo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnLeerDPCard = New Janus.Windows.EditControls.UIButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ebClienteDPC = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSaldoDPC = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebNumDPCard = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblValidaDPCard = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.exPagoEcommerce = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblValidaOrden = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebNumOrden = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebReferencia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuLimpiar1 = New Janus.Windows.UI.CommandBars.UICommand("menuLimpiar")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuRealizarPago1 = New Janus.Windows.UI.CommandBars.UICommand("menuRealizarPago")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuLimpiar = New Janus.Windows.UI.CommandBars.UICommand("menuLimpiar")
        Me.menuRealizarPago = New Janus.Windows.UI.CommandBars.UICommand("menuRealizarPago")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.exFormasPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exFormasPago.SuspendLayout()
        CType(Me.gridFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.exDatosGenerales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exDatosGenerales.SuspendLayout()
        CType(Me.exAbonosDPCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exAbonosDPCard.SuspendLayout()
        CType(Me.exPagoEcommerce, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exPagoEcommerce.SuspendLayout()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.exFormasPago)
        Me.ExplorerBar1.Controls.Add(Me.exDatosGenerales)
        Me.ExplorerBar1.Controls.Add(Me.exPagoEcommerce)
        Me.ExplorerBar1.Controls.Add(Me.exAbonosDPCard)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 28)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(746, 588)
        Me.ExplorerBar1.TabIndex = 3
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'exFormasPago
        '
        Me.exFormasPago.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.exFormasPago.Controls.Add(Me.cmbFormaPago)
        Me.exFormasPago.Controls.Add(Me.cmbPromocion)
        Me.exFormasPago.Controls.Add(Me.lblPromocion)
        Me.exFormasPago.Controls.Add(Me.ebAutorizacion)
        Me.exFormasPago.Controls.Add(Me.Label8)
        Me.exFormasPago.Controls.Add(Me.Label14)
        Me.exFormasPago.Controls.Add(Me.btnRealizarPago)
        Me.exFormasPago.Controls.Add(Me.Label12)
        Me.exFormasPago.Controls.Add(Me.ebCambio)
        Me.exFormasPago.Controls.Add(Me.Label10)
        Me.exFormasPago.Controls.Add(Me.ebImporteTotal)
        Me.exFormasPago.Controls.Add(Me.gridFormaPago)
        Me.exFormasPago.Controls.Add(Me.ebTotalPagoCliente)
        Me.exFormasPago.Controls.Add(Me.btnLeerTarjeta)
        Me.exFormasPago.Controls.Add(Me.ebNumTarj)
        Me.exFormasPago.Controls.Add(Me.ebCodBanco)
        Me.exFormasPago.Controls.Add(Me.ebTipoTarjeta)
        Me.exFormasPago.Controls.Add(Me.Label13)
        Me.exFormasPago.Controls.Add(Me.EBBanco)
        Me.exFormasPago.Controls.Add(Me.Label11)
        Me.exFormasPago.Controls.Add(Me.EBTarjeta)
        Me.exFormasPago.Controls.Add(Me.Label9)
        Me.exFormasPago.Controls.Add(Me.btnAgregarFP)
        Me.exFormasPago.Controls.Add(Me.EBPago)
        Me.exFormasPago.Controls.Add(Me.Label3)
        Me.exFormasPago.Controls.Add(Me.lblLabel10)
        Me.exFormasPago.Controls.Add(Me.txtCVV2)
        Me.exFormasPago.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.exFormasPago.Enabled = False
        Me.exFormasPago.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Formas de Pago"
        Me.exFormasPago.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.exFormasPago.Location = New System.Drawing.Point(0, 268)
        Me.exFormasPago.Name = "exFormasPago"
        Me.exFormasPago.Size = New System.Drawing.Size(746, 320)
        Me.exFormasPago.TabIndex = 0
        Me.exFormasPago.Text = "ExplorerBar1"
        Me.exFormasPago.Visible = False
        Me.exFormasPago.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbFormaPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbFormaPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        Me.cmbFormaPago.Cursor = System.Windows.Forms.Cursors.Default
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbFormaPago.DesignTimeLayout = GridEXLayout1
        Me.cmbFormaPago.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.Location = New System.Drawing.Point(144, 40)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(192, 23)
        Me.cmbFormaPago.TabIndex = 0
        Me.cmbFormaPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbFormaPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbPromocion
        '
        Me.cmbPromocion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbPromocion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbPromocion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.cmbPromocion.DesignTimeLayout = GridEXLayout2
        Me.cmbPromocion.Enabled = False
        Me.cmbPromocion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPromocion.Location = New System.Drawing.Point(320, 240)
        Me.cmbPromocion.Name = "cmbPromocion"
        Me.cmbPromocion.Size = New System.Drawing.Size(80, 23)
        Me.cmbPromocion.TabIndex = 6
        Me.cmbPromocion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbPromocion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPromocion
        '
        Me.lblPromocion.AccessibleDescription = "0"
        Me.lblPromocion.AutoSize = True
        Me.lblPromocion.BackColor = System.Drawing.Color.Transparent
        Me.lblPromocion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPromocion.Location = New System.Drawing.Point(240, 240)
        Me.lblPromocion.Name = "lblPromocion"
        Me.lblPromocion.Size = New System.Drawing.Size(80, 16)
        Me.lblPromocion.TabIndex = 246
        Me.lblPromocion.Text = "Promoción:"
        '
        'ebAutorizacion
        '
        Me.ebAutorizacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAutorizacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAutorizacion.Enabled = False
        Me.ebAutorizacion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAutorizacion.Location = New System.Drawing.Point(144, 240)
        Me.ebAutorizacion.MaxLength = 10
        Me.ebAutorizacion.Name = "ebAutorizacion"
        Me.ebAutorizacion.Numeric = True
        Me.ebAutorizacion.Size = New System.Drawing.Size(88, 23)
        Me.ebAutorizacion.TabIndex = 4
        Me.ebAutorizacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAutorizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = "0"
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 16)
        Me.Label8.TabIndex = 245
        Me.Label8.Text = "No. Autorización:"
        '
        'Label14
        '
        Me.Label14.AccessibleDescription = "0"
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 16)
        Me.Label14.TabIndex = 241
        Me.Label14.Text = "Forma de Pago:"
        '
        'btnRealizarPago
        '
        Me.btnRealizarPago.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRealizarPago.Icon = CType(resources.GetObject("btnRealizarPago.Icon"), System.Drawing.Icon)
        Me.btnRealizarPago.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnRealizarPago.Location = New System.Drawing.Point(424, 240)
        Me.btnRealizarPago.Name = "btnRealizarPago"
        Me.btnRealizarPago.Size = New System.Drawing.Size(304, 64)
        Me.btnRealizarPago.TabIndex = 7
        Me.btnRealizarPago.Text = "Realizar Pago"
        Me.btnRealizarPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label12
        '
        Me.Label12.AccessibleDescription = "0"
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(512, 168)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 14)
        Me.Label12.TabIndex = 239
        Me.Label12.Text = "Cambio:"
        '
        'ebCambio
        '
        Me.ebCambio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCambio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCambio.BackColor = System.Drawing.SystemColors.Info
        Me.ebCambio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCambio.ForeColor = System.Drawing.Color.Red
        Me.ebCambio.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebCambio.Location = New System.Drawing.Point(608, 168)
        Me.ebCambio.MaxLength = 8
        Me.ebCambio.Name = "ebCambio"
        Me.ebCambio.ReadOnly = True
        Me.ebCambio.Size = New System.Drawing.Size(120, 23)
        Me.ebCambio.TabIndex = 238
        Me.ebCambio.TabStop = False
        Me.ebCambio.Text = "$0.00"
        Me.ebCambio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCambio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.AccessibleDescription = "0"
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(424, 200)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 29)
        Me.Label10.TabIndex = 237
        Me.Label10.Text = "Total Pago:"
        '
        'ebImporteTotal
        '
        Me.ebImporteTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebImporteTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebImporteTotal.BackColor = System.Drawing.SystemColors.Info
        Me.ebImporteTotal.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebImporteTotal.ForeColor = System.Drawing.Color.Black
        Me.ebImporteTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebImporteTotal.Location = New System.Drawing.Point(576, 200)
        Me.ebImporteTotal.Name = "ebImporteTotal"
        Me.ebImporteTotal.ReadOnly = True
        Me.ebImporteTotal.Size = New System.Drawing.Size(152, 33)
        Me.ebImporteTotal.TabIndex = 236
        Me.ebImporteTotal.TabStop = False
        Me.ebImporteTotal.Text = "$0.00"
        Me.ebImporteTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebImporteTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gridFormaPago
        '
        Me.gridFormaPago.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.gridFormaPago.DesignTimeLayout = GridEXLayout3
        Me.gridFormaPago.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridFormaPago.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.gridFormaPago.GroupByBoxVisible = False
        Me.gridFormaPago.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gridFormaPago.Location = New System.Drawing.Point(408, 40)
        Me.gridFormaPago.Name = "gridFormaPago"
        Me.gridFormaPago.Size = New System.Drawing.Size(322, 88)
        Me.gridFormaPago.TabIndex = 235
        Me.gridFormaPago.TabStop = False
        Me.gridFormaPago.TotalRowFormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridFormaPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTotalPagoCliente
        '
        Me.ebTotalPagoCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalPagoCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalPagoCliente.BackColor = System.Drawing.SystemColors.Info
        Me.ebTotalPagoCliente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalPagoCliente.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebTotalPagoCliente.Location = New System.Drawing.Point(608, 136)
        Me.ebTotalPagoCliente.MaxLength = 8
        Me.ebTotalPagoCliente.Name = "ebTotalPagoCliente"
        Me.ebTotalPagoCliente.ReadOnly = True
        Me.ebTotalPagoCliente.Size = New System.Drawing.Size(120, 23)
        Me.ebTotalPagoCliente.TabIndex = 234
        Me.ebTotalPagoCliente.TabStop = False
        Me.ebTotalPagoCliente.Text = "$0.00"
        Me.ebTotalPagoCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotalPagoCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnLeerTarjeta
        '
        Me.btnLeerTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerTarjeta.Icon = CType(resources.GetObject("btnLeerTarjeta.Icon"), System.Drawing.Icon)
        Me.btnLeerTarjeta.Location = New System.Drawing.Point(360, 200)
        Me.btnLeerTarjeta.Name = "btnLeerTarjeta"
        Me.btnLeerTarjeta.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerTarjeta.TabIndex = 10
        Me.btnLeerTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNumTarj
        '
        Me.ebNumTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumTarj.Enabled = False
        Me.ebNumTarj.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumTarj.Location = New System.Drawing.Point(144, 200)
        Me.ebNumTarj.MaxLength = 200
        Me.ebNumTarj.Name = "ebNumTarj"
        Me.ebNumTarj.ReadOnly = True
        Me.ebNumTarj.Size = New System.Drawing.Size(216, 23)
        Me.ebNumTarj.TabIndex = 8
        Me.ebNumTarj.TabStop = False
        Me.ebNumTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodBanco
        '
        Me.ebCodBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodBanco.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        Me.ebCodBanco.ControlStyle.ControlColor = System.Drawing.SystemColors.Window
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.ebCodBanco.DesignTimeLayout = GridEXLayout4
        Me.ebCodBanco.Enabled = False
        Me.ebCodBanco.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodBanco.Location = New System.Drawing.Point(144, 160)
        Me.ebCodBanco.Name = "ebCodBanco"
        Me.ebCodBanco.Size = New System.Drawing.Size(72, 23)
        Me.ebCodBanco.TabIndex = 3
        Me.ebCodBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTipoTarjeta
        '
        Me.ebTipoTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTipoTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTipoTarjeta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        Me.ebTipoTarjeta.ControlStyle.ControlColor = System.Drawing.SystemColors.Window
        GridEXLayout5.LayoutString = resources.GetString("GridEXLayout5.LayoutString")
        Me.ebTipoTarjeta.DesignTimeLayout = GridEXLayout5
        Me.ebTipoTarjeta.Enabled = False
        Me.ebTipoTarjeta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTipoTarjeta.Location = New System.Drawing.Point(144, 120)
        Me.ebTipoTarjeta.Name = "ebTipoTarjeta"
        Me.ebTipoTarjeta.Size = New System.Drawing.Size(48, 23)
        Me.ebTipoTarjeta.TabIndex = 2
        Me.ebTipoTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTipoTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.AccessibleDescription = "0"
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 200)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 16)
        Me.Label13.TabIndex = 227
        Me.Label13.Text = "No. de Tarjeta:"
        '
        'EBBanco
        '
        Me.EBBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBBanco.BackColor = System.Drawing.SystemColors.Info
        Me.EBBanco.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.EBBanco.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBBanco.ForeColor = System.Drawing.Color.Black
        Me.EBBanco.Location = New System.Drawing.Point(216, 160)
        Me.EBBanco.Name = "EBBanco"
        Me.EBBanco.ReadOnly = True
        Me.EBBanco.Size = New System.Drawing.Size(184, 23)
        Me.EBBanco.TabIndex = 219
        Me.EBBanco.TabStop = False
        Me.EBBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = "0"
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 16)
        Me.Label11.TabIndex = 220
        Me.Label11.Text = "Terminal:"
        '
        'EBTarjeta
        '
        Me.EBTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBTarjeta.BackColor = System.Drawing.SystemColors.Info
        Me.EBTarjeta.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBTarjeta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.EBTarjeta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBTarjeta.ForeColor = System.Drawing.Color.Black
        Me.EBTarjeta.Location = New System.Drawing.Point(192, 120)
        Me.EBTarjeta.Name = "EBTarjeta"
        Me.EBTarjeta.ReadOnly = True
        Me.EBTarjeta.Size = New System.Drawing.Size(208, 23)
        Me.EBTarjeta.TabIndex = 216
        Me.EBTarjeta.TabStop = False
        Me.EBTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = "0"
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 16)
        Me.Label9.TabIndex = 218
        Me.Label9.Text = "Tipo de Tarjeta:"
        '
        'btnAgregarFP
        '
        Me.btnAgregarFP.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarFP.Icon = CType(resources.GetObject("btnAgregarFP.Icon"), System.Drawing.Icon)
        Me.btnAgregarFP.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnAgregarFP.Location = New System.Drawing.Point(144, 272)
        Me.btnAgregarFP.Name = "btnAgregarFP"
        Me.btnAgregarFP.Size = New System.Drawing.Size(256, 32)
        Me.btnAgregarFP.TabIndex = 5
        Me.btnAgregarFP.Text = "Agregar"
        Me.btnAgregarFP.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EBPago
        '
        Me.EBPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBPago.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBPago.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBPago.FormatString = "c"
        Me.EBPago.Location = New System.Drawing.Point(144, 80)
        Me.EBPago.Name = "EBPago"
        Me.EBPago.Size = New System.Drawing.Size(88, 23)
        Me.EBPago.TabIndex = 1
        Me.EBPago.Text = "$0.00"
        Me.EBPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.EBPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 211
        Me.Label3.Text = "Monto a Pagar:"
        '
        'lblLabel10
        '
        Me.lblLabel10.AccessibleDescription = "0"
        Me.lblLabel10.AutoSize = True
        Me.lblLabel10.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel10.Location = New System.Drawing.Point(480, 136)
        Me.lblLabel10.Name = "lblLabel10"
        Me.lblLabel10.Size = New System.Drawing.Size(93, 16)
        Me.lblLabel10.TabIndex = 233
        Me.lblLabel10.Text = "Pago Cliente:"
        '
        'txtCVV2
        '
        Me.txtCVV2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCVV2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCVV2.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Enabled = False
        Me.txtCVV2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Location = New System.Drawing.Point(144, 200)
        Me.txtCVV2.Name = "txtCVV2"
        Me.txtCVV2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCVV2.Size = New System.Drawing.Size(75, 22)
        Me.txtCVV2.TabIndex = 247
        Me.txtCVV2.Text = "123"
        Me.txtCVV2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCVV2.Visible = False
        Me.txtCVV2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'exDatosGenerales
        '
        Me.exDatosGenerales.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.exDatosGenerales.Controls.Add(Me.cmbTipoPago)
        Me.exDatosGenerales.Controls.Add(Me.lblTipoPago)
        Me.exDatosGenerales.Controls.Add(Me.cmbConceptoPago)
        Me.exDatosGenerales.Controls.Add(Me.Label6)
        Me.exDatosGenerales.Controls.Add(Me.cmbFecha)
        Me.exDatosGenerales.Controls.Add(Me.ebPlayer)
        Me.exDatosGenerales.Controls.Add(Me.ebNombrePlayer)
        Me.exDatosGenerales.Controls.Add(Me.Label5)
        Me.exDatosGenerales.Controls.Add(Me.Label4)
        Me.exDatosGenerales.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Datos Generales"
        Me.exDatosGenerales.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.exDatosGenerales.Location = New System.Drawing.Point(0, 0)
        Me.exDatosGenerales.Name = "exDatosGenerales"
        Me.exDatosGenerales.Size = New System.Drawing.Size(744, 112)
        Me.exDatosGenerales.TabIndex = 0
        Me.exDatosGenerales.Text = "ExplorerBar1"
        Me.exDatosGenerales.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cmbTipoPago
        '
        Me.cmbTipoPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbTipoPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbTipoPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        Me.cmbTipoPago.Cursor = System.Windows.Forms.Cursors.Default
        GridEXLayout6.LayoutString = resources.GetString("GridEXLayout6.LayoutString")
        Me.cmbTipoPago.DesignTimeLayout = GridEXLayout6
        Me.cmbTipoPago.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPago.Location = New System.Drawing.Point(144, 86)
        Me.cmbTipoPago.Name = "cmbTipoPago"
        Me.cmbTipoPago.Size = New System.Drawing.Size(184, 23)
        Me.cmbTipoPago.TabIndex = 218
        Me.cmbTipoPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbTipoPago.Visible = False
        Me.cmbTipoPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTipoPago
        '
        Me.lblTipoPago.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoPago.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoPago.Location = New System.Drawing.Point(16, 86)
        Me.lblTipoPago.Name = "lblTipoPago"
        Me.lblTipoPago.Size = New System.Drawing.Size(96, 16)
        Me.lblTipoPago.TabIndex = 217
        Me.lblTipoPago.Text = "Tipo de Pago:"
        Me.lblTipoPago.Visible = False
        '
        'cmbConceptoPago
        '
        Me.cmbConceptoPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbConceptoPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbConceptoPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        Me.cmbConceptoPago.Cursor = System.Windows.Forms.Cursors.Default
        GridEXLayout7.LayoutString = resources.GetString("GridEXLayout7.LayoutString")
        Me.cmbConceptoPago.DesignTimeLayout = GridEXLayout7
        Me.cmbConceptoPago.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbConceptoPago.Location = New System.Drawing.Point(144, 38)
        Me.cmbConceptoPago.Name = "cmbConceptoPago"
        Me.cmbConceptoPago.Size = New System.Drawing.Size(184, 23)
        Me.cmbConceptoPago.TabIndex = 0
        Me.cmbConceptoPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbConceptoPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 16)
        Me.Label6.TabIndex = 216
        Me.Label6.Text = "Concepto de Pago:"
        '
        'cmbFecha
        '
        Me.cmbFecha.BackColor = System.Drawing.SystemColors.Info
        '
        '
        '
        Me.cmbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFecha.Location = New System.Drawing.Point(608, 38)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.ReadOnly = True
        Me.cmbFecha.Size = New System.Drawing.Size(120, 22)
        Me.cmbFecha.TabIndex = 213
        Me.cmbFecha.TabStop = False
        Me.cmbFecha.TodayButtonText = "Hoy"
        Me.cmbFecha.Value = New Date(2019, 4, 16, 0, 0, 0, 0)
        Me.cmbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ebPlayer
        '
        Me.ebPlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayer.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayer.ButtonImage = CType(resources.GetObject("ebPlayer.ButtonImage"), System.Drawing.Image)
        Me.ebPlayer.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebPlayer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebPlayer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayer.Location = New System.Drawing.Point(144, 62)
        Me.ebPlayer.MaxLength = 10
        Me.ebPlayer.Name = "ebPlayer"
        Me.ebPlayer.Size = New System.Drawing.Size(96, 22)
        Me.ebPlayer.TabIndex = 1
        Me.ebPlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombrePlayer
        '
        Me.ebNombrePlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombrePlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombrePlayer.BackColor = System.Drawing.SystemColors.Info
        Me.ebNombrePlayer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNombrePlayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombrePlayer.Location = New System.Drawing.Point(248, 62)
        Me.ebNombrePlayer.Name = "ebNombrePlayer"
        Me.ebNombrePlayer.ReadOnly = True
        Me.ebNombrePlayer.Size = New System.Drawing.Size(480, 21)
        Me.ebNombrePlayer.TabIndex = 3
        Me.ebNombrePlayer.TabStop = False
        Me.ebNombrePlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombrePlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 210
        Me.Label5.Text = "Player:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(552, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 214
        Me.Label4.Text = "Fecha:"
        '
        'exAbonosDPCard
        '
        Me.exAbonosDPCard.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.exAbonosDPCard.Controls.Add(Me.cmbFechaLimite)
        Me.exAbonosDPCard.Controls.Add(Me.Label15)
        Me.exAbonosDPCard.Controls.Add(Me.ebPagoVencido)
        Me.exAbonosDPCard.Controls.Add(Me.Label20)
        Me.exAbonosDPCard.Controls.Add(Me.ebPagoMinimo)
        Me.exAbonosDPCard.Controls.Add(Me.Label19)
        Me.exAbonosDPCard.Controls.Add(Me.Label18)
        Me.exAbonosDPCard.Controls.Add(Me.btnLeerDPCard)
        Me.exAbonosDPCard.Controls.Add(Me.Label17)
        Me.exAbonosDPCard.Controls.Add(Me.ebClienteDPC)
        Me.exAbonosDPCard.Controls.Add(Me.ebSaldoDPC)
        Me.exAbonosDPCard.Controls.Add(Me.ebNumDPCard)
        Me.exAbonosDPCard.Controls.Add(Me.lblValidaDPCard)
        Me.exAbonosDPCard.Controls.Add(Me.Label16)
        Me.exAbonosDPCard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup4.Expandable = False
        ExplorerBarGroup4.Key = "Group1"
        ExplorerBarGroup4.Text = "Abono de DP Card"
        Me.exAbonosDPCard.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup4})
        Me.exAbonosDPCard.Location = New System.Drawing.Point(0, 104)
        Me.exAbonosDPCard.Name = "exAbonosDPCard"
        Me.exAbonosDPCard.Size = New System.Drawing.Size(744, 168)
        Me.exAbonosDPCard.TabIndex = 6
        Me.exAbonosDPCard.Visible = False
        Me.exAbonosDPCard.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cmbFechaLimite
        '
        Me.cmbFechaLimite.BackColor = System.Drawing.SystemColors.Info
        '
        '
        '
        Me.cmbFechaLimite.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFechaLimite.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFechaLimite.Location = New System.Drawing.Point(608, 88)
        Me.cmbFechaLimite.Name = "cmbFechaLimite"
        Me.cmbFechaLimite.ReadOnly = True
        Me.cmbFechaLimite.Size = New System.Drawing.Size(120, 22)
        Me.cmbFechaLimite.TabIndex = 228
        Me.cmbFechaLimite.TabStop = False
        Me.cmbFechaLimite.TodayButtonText = "Hoy"
        Me.cmbFechaLimite.Value = New Date(2019, 4, 16, 0, 0, 0, 0)
        Me.cmbFechaLimite.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(584, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(160, 16)
        Me.Label15.TabIndex = 229
        Me.Label15.Text = "Fecha Limite de Pago:"
        '
        'ebPagoVencido
        '
        Me.ebPagoVencido.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPagoVencido.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPagoVencido.BackColor = System.Drawing.SystemColors.Info
        Me.ebPagoVencido.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPagoVencido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPagoVencido.ForeColor = System.Drawing.Color.Red
        Me.ebPagoVencido.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebPagoVencido.Location = New System.Drawing.Point(144, 136)
        Me.ebPagoVencido.Name = "ebPagoVencido"
        Me.ebPagoVencido.ReadOnly = True
        Me.ebPagoVencido.Size = New System.Drawing.Size(120, 23)
        Me.ebPagoVencido.TabIndex = 226
        Me.ebPagoVencido.TabStop = False
        Me.ebPagoVencido.Text = "$0.00"
        Me.ebPagoVencido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebPagoVencido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(16, 136)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 16)
        Me.Label20.TabIndex = 227
        Me.Label20.Text = "Pago Vencido:"
        '
        'ebPagoMinimo
        '
        Me.ebPagoMinimo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPagoMinimo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPagoMinimo.BackColor = System.Drawing.SystemColors.Info
        Me.ebPagoMinimo.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPagoMinimo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPagoMinimo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebPagoMinimo.Location = New System.Drawing.Point(144, 112)
        Me.ebPagoMinimo.Name = "ebPagoMinimo"
        Me.ebPagoMinimo.ReadOnly = True
        Me.ebPagoMinimo.Size = New System.Drawing.Size(120, 23)
        Me.ebPagoMinimo.TabIndex = 224
        Me.ebPagoMinimo.TabStop = False
        Me.ebPagoMinimo.Text = "$0.00"
        Me.ebPagoMinimo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebPagoMinimo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(16, 112)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 16)
        Me.Label19.TabIndex = 225
        Me.Label19.Text = "Pago Minimo:"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 88)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 16)
        Me.Label18.TabIndex = 223
        Me.Label18.Text = "Saldo Actual:"
        '
        'btnLeerDPCard
        '
        Me.btnLeerDPCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerDPCard.Icon = CType(resources.GetObject("btnLeerDPCard.Icon"), System.Drawing.Icon)
        Me.btnLeerDPCard.Location = New System.Drawing.Point(336, 40)
        Me.btnLeerDPCard.Name = "btnLeerDPCard"
        Me.btnLeerDPCard.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerDPCard.TabIndex = 221
        Me.btnLeerDPCard.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 16)
        Me.Label17.TabIndex = 220
        Me.Label17.Text = "Tarjetahabiente:"
        '
        'ebClienteDPC
        '
        Me.ebClienteDPC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteDPC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteDPC.BackColor = System.Drawing.SystemColors.Info
        Me.ebClienteDPC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebClienteDPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteDPC.Location = New System.Drawing.Point(144, 64)
        Me.ebClienteDPC.Name = "ebClienteDPC"
        Me.ebClienteDPC.ReadOnly = True
        Me.ebClienteDPC.Size = New System.Drawing.Size(344, 21)
        Me.ebClienteDPC.TabIndex = 219
        Me.ebClienteDPC.TabStop = False
        Me.ebClienteDPC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteDPC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSaldoDPC
        '
        Me.ebSaldoDPC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoDPC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoDPC.BackColor = System.Drawing.SystemColors.Info
        Me.ebSaldoDPC.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSaldoDPC.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSaldoDPC.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSaldoDPC.Location = New System.Drawing.Point(144, 88)
        Me.ebSaldoDPC.Name = "ebSaldoDPC"
        Me.ebSaldoDPC.ReadOnly = True
        Me.ebSaldoDPC.Size = New System.Drawing.Size(120, 23)
        Me.ebSaldoDPC.TabIndex = 217
        Me.ebSaldoDPC.TabStop = False
        Me.ebSaldoDPC.Text = "$0.00"
        Me.ebSaldoDPC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoDPC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNumDPCard
        '
        Me.ebNumDPCard.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumDPCard.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumDPCard.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumDPCard.Location = New System.Drawing.Point(144, 40)
        Me.ebNumDPCard.Name = "ebNumDPCard"
        Me.ebNumDPCard.Size = New System.Drawing.Size(192, 22)
        Me.ebNumDPCard.TabIndex = 216
        Me.ebNumDPCard.TabStop = False
        Me.ebNumDPCard.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumDPCard.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblValidaDPCard
        '
        Me.lblValidaDPCard.AutoSize = True
        Me.lblValidaDPCard.BackColor = System.Drawing.Color.Transparent
        Me.lblValidaDPCard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidaDPCard.ForeColor = System.Drawing.Color.Red
        Me.lblValidaDPCard.Location = New System.Drawing.Point(392, 40)
        Me.lblValidaDPCard.Name = "lblValidaDPCard"
        Me.lblValidaDPCard.Size = New System.Drawing.Size(256, 16)
        Me.lblValidaDPCard.TabIndex = 215
        Me.lblValidaDPCard.Text = "Validando Tarjeta. Favor de Esperar ..."
        Me.lblValidaDPCard.Visible = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 16)
        Me.Label16.TabIndex = 213
        Me.Label16.Text = "No. de Tarjeta:"
        '
        'exPagoEcommerce
        '
        Me.exPagoEcommerce.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.exPagoEcommerce.Controls.Add(Me.lblValidaOrden)
        Me.exPagoEcommerce.Controls.Add(Me.Label2)
        Me.exPagoEcommerce.Controls.Add(Me.ebNumOrden)
        Me.exPagoEcommerce.Controls.Add(Me.ebReferencia)
        Me.exPagoEcommerce.Controls.Add(Me.Label1)
        Me.exPagoEcommerce.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Pago de Pedidos e-Commerce"
        Me.exPagoEcommerce.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.exPagoEcommerce.Location = New System.Drawing.Point(0, 104)
        Me.exPagoEcommerce.Name = "exPagoEcommerce"
        Me.exPagoEcommerce.Size = New System.Drawing.Size(744, 112)
        Me.exPagoEcommerce.TabIndex = 1
        Me.exPagoEcommerce.Text = "ExplorerBar1"
        Me.exPagoEcommerce.Visible = False
        Me.exPagoEcommerce.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblValidaOrden
        '
        Me.lblValidaOrden.AutoSize = True
        Me.lblValidaOrden.BackColor = System.Drawing.Color.Transparent
        Me.lblValidaOrden.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidaOrden.ForeColor = System.Drawing.Color.Red
        Me.lblValidaOrden.Location = New System.Drawing.Point(256, 40)
        Me.lblValidaOrden.Name = "lblValidaOrden"
        Me.lblValidaOrden.Size = New System.Drawing.Size(321, 16)
        Me.lblValidaOrden.TabIndex = 215
        Me.lblValidaOrden.Text = "Validando Número de Orden. Favor de Esperar ..."
        Me.lblValidaOrden.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 214
        Me.Label2.Text = "Referencia:"
        '
        'ebNumOrden
        '
        Me.ebNumOrden.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumOrden.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumOrden.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumOrden.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebNumOrden.Location = New System.Drawing.Point(144, 40)
        Me.ebNumOrden.Name = "ebNumOrden"
        Me.ebNumOrden.Size = New System.Drawing.Size(104, 23)
        Me.ebNumOrden.TabIndex = 0
        Me.ebNumOrden.Text = "0"
        Me.ebNumOrden.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumOrden.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebNumOrden.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebReferencia
        '
        Me.ebReferencia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebReferencia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebReferencia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebReferencia.Location = New System.Drawing.Point(144, 72)
        Me.ebReferencia.Name = "ebReferencia"
        Me.ebReferencia.Size = New System.Drawing.Size(192, 23)
        Me.ebReferencia.TabIndex = 1
        Me.ebReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 213
        Me.Label1.Text = "No. de Orden:"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuLimpiar, Me.menuRealizarPago, Me.menuSalir})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("d799eaac-4be9-47d5-90b4-771e51dfdc35")
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
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuLimpiar1, Me.Separator1, Me.menuRealizarPago1, Me.Separator2, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(262, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuLimpiar1
        '
        Me.menuLimpiar1.Key = "menuLimpiar"
        Me.menuLimpiar1.Name = "menuLimpiar1"
        Me.menuLimpiar1.Text = "Nuevo Pago"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuRealizarPago1
        '
        Me.menuRealizarPago1.Key = "menuRealizarPago"
        Me.menuRealizarPago1.Name = "menuRealizarPago1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'menuLimpiar
        '
        Me.menuLimpiar.Image = CType(resources.GetObject("menuLimpiar.Image"), System.Drawing.Image)
        Me.menuLimpiar.Key = "menuLimpiar"
        Me.menuLimpiar.Name = "menuLimpiar"
        Me.menuLimpiar.Text = "Limpiar"
        '
        'menuRealizarPago
        '
        Me.menuRealizarPago.Icon = CType(resources.GetObject("menuRealizarPago.Icon"), System.Drawing.Icon)
        Me.menuRealizarPago.Key = "menuRealizarPago"
        Me.menuRealizarPago.Name = "menuRealizarPago"
        Me.menuRealizarPago.Text = "Realizar Pago"
        '
        'menuSalir
        '
        Me.menuSalir.Icon = CType(resources.GetObject("menuSalir.Icon"), System.Drawing.Icon)
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
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
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(746, 28)
        '
        'frmOtrosPagos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(746, 616)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOtrosPagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Otros Pagos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.exFormasPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exFormasPago.ResumeLayout(False)
        Me.exFormasPago.PerformLayout()
        CType(Me.gridFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.exDatosGenerales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exDatosGenerales.ResumeLayout(False)
        Me.exDatosGenerales.PerformLayout()
        CType(Me.exAbonosDPCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exAbonosDPCard.ResumeLayout(False)
        Me.exAbonosDPCard.PerformLayout()
        CType(Me.exPagoEcommerce, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exPagoEcommerce.ResumeLayout(False)
        Me.exPagoEcommerce.PerformLayout()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim booleHub As Boolean = False
    Dim bolCargoEHub As Boolean = False
    Dim intPromo As Integer = 0

    Dim bExit As Boolean = False

    Dim strNoAfiliacion As String
    Dim strNombreM As String
    Dim strVencM As String
    Dim mPosEntryM As Integer = 0
    Dim strCriptogramaM As String = ""
    Dim strTarjetaBloq As String

    Dim dtConceptos As DataTable
    Public oSAPMgr As ProcesoSAPManager

    Dim oVendedoresMgr As CatalogoVendedoresManager
    Dim oVendedor As Vendedor

    'Objeto Factura
    Dim oFacturaMgr As FacturaManager

    '--Implementación del CatalogoFormasPago
    Dim oCatFormaPago As CatalogoFormasPagoManager

    'Catalogo Bancos
    Dim oCatalogoBancoMgr As CatalogoBancosManager
    Dim dsBanco As New DataSet

    'Catalogo Promociones
    Dim oCatalogoPromoMgr As CatalogoPromocionesManager
    Dim dtPromociones As New DataTable

    'Catalogo Tipo Tarjeta
    Dim oCatalogoTipoTarjetaMgr As CatalogoTipoTarjetasManager
    Dim dsTipoTarjeta As New DataSet

    'Tabla Temporal de Formas de Pago
    Public dsFormasPago As New DataSet
    Dim m_dtFormasPago As DataTable

    Dim NumRef As String = ""
    'Dim DatosDPC(8) As String
    Dim htDatosDPC As Hashtable
    Private deslizada As Boolean = False
    '-----------------------------------------------------------------------------------------
    'FLIZARRAGA 14/09/2017: Se agrega la lista de errores de la pinpad
    '-----------------------------------------------------------------------------------------
    Private ListaErroresBanamex As New List(Of String)() From {"02", "06", "08", "10", "11", "16", "17", "40", "79"}

    '----------------------------------------------------------------------------------------
    ' JNAVA (03.04.2016): Variable para habilitar pagos sin SAP Retail
    '----------------------------------------------------------------------------------------
    Dim bolSinSAP As Boolean = False

    '----------------------------------------------------------------------------------------
    ' DARCOS (23.04.2019): Variable para guardar respuesta de servicio Ecommerce
    '----------------------------------------------------------------------------------------
    Dim ResponseEcomm As Dictionary(Of String, Object) = Nothing

    '----------------------------------------------------------------------------------------
    ' DARCOS (06.05.2019): Variable para guardar respuesta de la API
    '----------------------------------------------------------------------------------------
    Dim ResponseWebApi As Dictionary(Of String, Object) = Nothing

#Region "Propiedades"

    Public Property dtFormasPago() As DataTable
        Get
            Return m_dtFormasPago
        End Get
        Set(ByVal Value As DataTable)
            m_dtFormasPago = Value
        End Set
    End Property

#End Region

#Region "Metodos y Funciones Generales"

    Private Sub Inicializar()

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        'Objeto Vendedores
        oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
        oVendedor = oVendedoresMgr.Create

        'Objeto Factura
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)

        '--Implementación CatalogoFormasPago
        oCatFormaPago = New CatalogoFormasPagoManager(oAppContext)

        'Catalogo Tipo Tarjetas
        oCatalogoTipoTarjetaMgr = New CatalogoTipoTarjetasManager(oAppContext)

        'Catalogo Bancos
        oCatalogoBancoMgr = New CatalogoBancosManager(oAppContext)

        'Catalogo Promociones
        oCatalogoPromoMgr = New CatalogoPromocionesManager(oAppContext, oConfigCierreFI)

    End Sub

    Private Sub Limpiar()

        'Datos Generales
        'Me.cmbConceptoPago.Value = ""
        Me.ebPlayer.Text = ""
        Me.ebNombrePlayer.Text = ""

        'Ecommerce
        Me.ebNumOrden.Text = 0
        Me.ebReferencia.Text = ""
        Me.exPagoEcommerce.Visible = False

        '-----------------------------------------------
        'JNAVA (08.01.2015): Abonos de Tarjetas KARUM
        '-----------------------------------------------
        Me.ebNumDPCard.Text = ""
        Me.ebClienteDPC.Text = ""
        Me.ebSaldoDPC.Text = 0
        Me.exAbonosDPCard.Visible = False
        Me.htDatosDPC = Nothing

        'Formas Pago
        Me.cmbFormaPago.Value = ""
        LimpiaCamposFormaPago()
        Me.ebTotalPagoCliente.Value = 0
        Me.ebCambio.Value = 0
        Me.ebImporteTotal.Value = 0
        Me.cmbFormaPago.DataSource = Nothing
        Me.cmbFormaPago.DropDownList.ClearStructure()
        dsBanco = Nothing
        dtPromociones = Nothing
        dsTipoTarjeta = Nothing
        Me.exFormasPago.Visible = False
        Me.exFormasPago.Enabled = False
        NumRef = ""
        Me.lblTipoPago.Visible = False
        Me.cmbTipoPago.Visible = False
        Me.ResponseEcomm = Nothing
        Me.ResponseWebApi = Nothing
    End Sub

    Private Sub LLenarTablaConceptos()

        Dim oRow As DataRow

        If dtConceptos Is Nothing Then
            dtConceptos = New DataTable("Conceptos")
            dtConceptos.Columns.Add("ID")
            dtConceptos.Columns.Add("CONCEPTO")
        Else
            dtConceptos.Rows.Clear()
        End If

        '------------------------------------------------------------------
        ' JNAVA (03.04.2016): Deshabilitamos pagos con Karum sin SAP Retail
        '------------------------------------------------------------------
        If bolSinSAP = False Then
            '--------------------------------------------------------------
            'JNAVA (07.01.2015): Agregamos el concepto correspondiente a EC
            '--------------------------------------------------------------\\10.200.3.20\Compartida\DPVAIO\NuevosCamposPLD
            If oConfigCierreFI.RecibirOtrosPagos Then
                oRow = Nothing
                oRow = dtConceptos.NewRow()
                oRow("ID") = "EC"
                oRow("CONCEPTO") = "Pedido de e-Commerce"
                dtConceptos.Rows.Add(oRow)
            End If
        End If

        '--------------------------------------------------------------
        'JNAVA (07.01.2015): Agregamos el concepto correspondiente a DC 
        '--------------------------------------------------------------
        If oConfigCierreFI.AplicaDPCard Then
            oRow = dtConceptos.NewRow()
            oRow("ID") = "DC"
            oRow("CONCEPTO") = "Abono a DP Card"
            dtConceptos.Rows.Add(oRow)
        End If

        dtConceptos.AcceptChanges()

    End Sub

    Private Sub LLenarComboConceptos()

        LLenarTablaConceptos()

        With Me.cmbConceptoPago

            .DropDownList.ClearStructure()

            .DataSource = dtConceptos
            .DropDownList.Columns.Add("ID")
            .DropDownList.Columns.Add("CONCEPTO")
            .DropDownList.Columns("ID").DataMember = "ID"
            .DropDownList.Columns("CONCEPTO").DataMember = "Concepto"
            .DropDownList.Columns("CONCEPTO").Width = 200
            .DropDownList.Columns("ID").Visible = False

            .DisplayMember = "CONCEPTO"
            .ValueMember = "ID"

            .DropDownList.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False

            .Refresh()

            .Focus()

        End With

    End Sub

    'Private Sub LoadSearchFormPlayer()

    '    Dim oOpenRecordDialogView As New OpenRecordDialog
    '    oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

    '    oOpenRecordDialogView.ShowDialog()

    '    If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then

    '        If oOpenRecordDialogView.pbNombre <> String.Empty Then

    '            ebPlayer.Text = oOpenRecordDialogView.pbCodigo
    '            ebNombrePlayer.Text = oOpenRecordDialogView.pbNombre

    '        Else

    '            ebPlayer.Text = oOpenRecordDialogView.Record.Item("CodVendedor")
    '            ebNombrePlayer.Text = oOpenRecordDialogView.Record.Item("Nombre")

    '        End If

    '    End If

    '    oOpenRecordDialogView.Dispose()

    '    oOpenRecordDialogView = Nothing

    'End Sub

    Private Sub LoadSearchFormPlayer()
        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

        oOpenRecordDialogView.ShowDialog()

        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then
            If oOpenRecordDialogView.Record Is Nothing Then
                Exit Sub
            End If
            oVendedor.ClearFields()
            oVendedoresMgr.LoadInto(oOpenRecordDialogView.Record.Item("CodVendedor"), oVendedor)
            If oOpenRecordDialogView.pbNombre <> String.Empty Then
                ebPlayer.Text = oOpenRecordDialogView.pbCodigo
                ebNombrePlayer.Text = oOpenRecordDialogView.pbNombre

            Else
                ebPlayer.Text = oOpenRecordDialogView.Record.Item("CodVendedor")
                ebNombrePlayer.Text = oOpenRecordDialogView.Record.Item("Nombre")
            End If

        End If

        oOpenRecordDialogView.Dispose()

        oOpenRecordDialogView = Nothing

    End Sub

    Private Sub MostrarPantallas()

        Limpiar()

        Select Case Me.cmbConceptoPago.Value
            Case "EC"
                Me.exPagoEcommerce.Visible = True
                Me.ebPlayer.Focus()

                'If oConfigCierreFI.VentaAsistida = True Then
                Me.lblTipoPago.Visible = True
                Me.cmbTipoPago.Visible = True
                Me.ebReferencia.Visible = False
                Me.Label2.Visible = False
                'End If

            Case "DC"
                '--------------------------------------------------------------
                'JNAVA (07.01.2015): Agregamos lo correspondiente a abonos DC
                '--------------------------------------------------------------
                Me.exAbonosDPCard.Visible = True
                Me.ebPlayer.Focus()
            Case Else

        End Select

        '--------------------------------------------------------------
        'JNAVA (19.01.2015): Adaptado para pantalla de DC
        '--------------------------------------------------------------
        CambiarTamañoPantallas(Me.cmbConceptoPago.Value)

        'Mostramos las Formas de Pago
        Me.exFormasPago.Visible = True

        '--Creamos dataset de formas de pago
        CreateDataFormaPago()

        Me.strNoAfiliacion = String.Empty
        Me.strTarjetaBloq = String.Empty

        '--Llenamos el Combo Formas de Pago
        FillFormaPago()

        '--Llenamos el Combo Caja
        FillBancos()

        '--Llenamos el Combo TipoTarjeta
        FillTipoTarjeta()

        'Creamos Estructura Combo Promociones
        Me.cmbPromocion.DropDownList.Columns.Add("CodPromo")
        Me.cmbPromocion.DropDownList.Columns.Add("Descripcion")
        Me.cmbPromocion.DropDownList.Columns("CodPromo").Visible = False

    End Sub

    '--------------------------------------------------------------
    'JNAVA (19.01.2015): Adaptando pantalla de DC
    '--------------------------------------------------------------
    Private Sub CambiarTamañoPantallas(ByVal Concepto As String)
        Select Case Concepto
            Case "EC" ' Ecommerce
                'Tamaño Pantalla Principal
                Me.Size = New Size(752, 592)

            Case "DC"
                'Tamaño Pantalla Principal
                Me.Size = New Size(752, 648)
        End Select
    End Sub

    '-------------------------------------------------------------------------------------
    'JNAVA (27.06.2015): Funcion para Validar datos de player
    '-------------------------------------------------------------------------------------
    Private Function ValidarPlayer() As Boolean
        Dim bResp As Boolean = True
        If Me.ebPlayer.Text = "" Or ebNombrePlayer.Text = "" Then
            MsgBox("Para continuar con el Pago, debe ingresar al Player. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Forma de Pago")
            bResp = False
            ebPlayer.Focus()
        End If
        Return bResp
    End Function

#End Region

#Region "Metodos y Funciones Formas de Pago"

    Private Sub LimpiaCamposFormaPago()

        EBPago.Value = ebImporteTotal.Value - ebTotalPagoCliente.Value

        'If Me.EBPago.Value <= 0 Then Me.EBPago.Enabled = False
        Me.btnAgregarFP.Enabled = True

        If Me.ebImporteTotal.Value > 0 AndAlso ebImporteTotal.Value <= Me.ebTotalPagoCliente.Value Then
            cmbFormaPago.Enabled = False
            Me.btnAgregarFP.Enabled = False
        End If

        If EBPago.Value <= 0 Then
            EBPago.Value = 0
            Me.EBPago.Enabled = False
        End If

        ebTipoTarjeta.Text = ""
        ebNumTarj.Text = ""
        ebCodBanco.Text = ""
        ebAutorizacion.Text = ""
        EBTarjeta.Text = ""
        EBBanco.Text = ""
        Me.cmbPromocion.Text = ""

        '--------------------------------------------------------------------------
        ' JNAVA (09.03.2015): Habilitamos Campos de las Formas de pago
        '--------------------------------------------------------------------------
        'Me.btnAgregarFP.Enabled = True
        'Me.cmbFormaPago.Enabled = True
        'Me.EBPago.Enabled = True
        'Me.ebImporteTotal.ReadOnly = True
        'If Me.cmbConceptoPago.Value = "DC" Then
        '    Me.ebImporteTotal.ReadOnly = False
        'Else
        '    Me.ebImporteTotal.ReadOnly = True
        'End If


    End Sub

    Private Sub FillFormaPago()
        Dim dtFormasPago As DataTable = oCatFormaPago.GetAll("P").Tables(0)

        'Quitamos la formas de pago no permitidas para las Ventas SH
        dtFormasPago = FiltrarFormasPago("VCJA", dtFormasPago) ' Vale de Caja
        dtFormasPago = FiltrarFormasPago("DPCA", dtFormasPago) ' DP Card
        dtFormasPago = FiltrarFormasPago("TACR", dtFormasPago) ' Tarjeta de Credito
        dtFormasPago = FiltrarFormasPago("DPPT", dtFormasPago) ' Tarjeta de Puntos
        cmbFormaPago.DataSource = dtFormasPago

        cmbFormaPago.DropDownList.Columns.Add("Cod.")
        cmbFormaPago.DropDownList.Columns.Add("Descripción")
        cmbFormaPago.DropDownList.Columns("Cod.").DataMember = "CodFormasPago"
        cmbFormaPago.DropDownList.Columns("Cod.").Width = 50
        cmbFormaPago.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        cmbFormaPago.DropDownList.Columns("Descripción").Width = 150
        cmbFormaPago.DisplayMember = "Descripcion"
        cmbFormaPago.ValueMember = "CodFormasPago"

        cmbFormaPago.Refresh()

        cmbFormaPago.Value = "EFEC"
    End Sub

    Private Sub FillFormaPagoEcomm()
        Dim pagoMgr As New CatalogoFormasPagoManager(oAppContext, oConfigCierreFI)
        Dim dtFormasPago As DataTable = pagoMgr.GetFormasPagosEcommerceByAlmacen()
        Me.cmbFormaPago.Value = ""
        Me.cmbFormaPago.DataSource = Nothing
        Me.cmbFormaPago.DropDownList.ClearStructure()
        cmbFormaPago.DataSource = dtFormasPago

        cmbFormaPago.DropDownList.Columns.Add("Cod.")
        cmbFormaPago.DropDownList.Columns.Add("Descripción")
        cmbFormaPago.DropDownList.Columns("Cod.").DataMember = "CodFormasPago"
        cmbFormaPago.DropDownList.Columns("Cod.").Width = 50
        cmbFormaPago.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        cmbFormaPago.DropDownList.Columns("Descripción").Width = 150
        cmbFormaPago.DisplayMember = "Descripcion"
        cmbFormaPago.ValueMember = "CodFormasPago"

        cmbFormaPago.Refresh()

        cmbFormaPago.Value = "DPVL"
    End Sub

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

    Private Sub HabilitaCamposFormaPago()

        If ebImporteTotal.Value > ebTotalPagoCliente.Value Then
            EBPago.Value = ebImporteTotal.Value - ebTotalPagoCliente.Value
        Else
            EBPago.Value = 0
        End If

        Select Case cmbFormaPago.Value

            Case "EFEC"    'Efectivo
                ebTipoTarjeta.Enabled = False
                ebCodBanco.Enabled = False
                ebNumTarj.Enabled = False
                ebAutorizacion.Enabled = False
                EBPago.Enabled = True
                Me.cmbPromocion.Enabled = False
                Me.btnLeerTarjeta.Enabled = False

            Case "TACR", "TADB" 'Tarjeta Crédito ó Débito
                ebTipoTarjeta.Value = "TE"
                ebTipoTarjeta.ReadOnly = False
                ebTipoTarjeta.Enabled = True
                ebCodBanco.Value = dsBanco.Tables(0).Rows(2).Item(0)
                'FillBancoPromociones(dsBanco.Tables(0).Rows(0)!IDEmisor)
                ebCodBanco.Enabled = True
                ebNumTarj.Enabled = True
                ebAutorizacion.Enabled = True
                EBPago.Enabled = True
                Me.cmbPromocion.Enabled = False
                Me.btnLeerTarjeta.Enabled = True

        End Select

    End Sub

    Private Function ValidaMontoPago() As Boolean

        '-----------------------------------------------------------------------------------------
        'JNAVA (03.06.2015): Si la operacion es Pago de DPCard Credit, no valida el monto.
        '-----------------------------------------------------------------------------------------
        If Me.cmbConceptoPago.Value = "DC" Then
            btnAgregarFP.Enabled = True
            Return False
        End If

        Select Case cmbFormaPago.Value

            Case "TACR"

                'EBPagoCom.Value = EBPago.Value * (oAppContext.ApplicationConfiguration.ComisionTarjetaCredito / 100)
                If (Me.EBPago.Value + Me.ebTotalPagoCliente.Value) > Me.ebImporteTotal.Value Then
                    MsgBox("Monto a pagar no puede ser mayor al Importe Total.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Facturación")
                    Return True
                Else

                End If

            Case "TADB"

                'EBPagoCom.Value = EBPago.Value * (oAppContext.ApplicationConfiguration.ComisionTarjetaDebito / 100)
                If (Me.EBPago.Value + Me.ebTotalPagoCliente.Value) > Me.ebImporteTotal.Value Then
                    MsgBox("Monto a pagar no puede ser mayor al Importe Total.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Facturación")
                    Return True
                Else

                End If
            Case "EFEC"
                btnAgregarFP.Enabled = True
        End Select

    End Function

    Private Function ValidaFormaPago() As Boolean

        'If cmbFormaPago.Value <> "" Then
        '    If cmbFormaPago.Value = "DPVL" Then
        '        If EsInstanciaNC = True And Not (owsDPValeInfo Is Nothing) Then
        '            If owsDPValeInfo.DPValeID <> 0 Then
        '                MsgBox("La Forma de Pago DPVale ya ha sido agregada. Seleccione una distinta.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturacion")
        '                cmbFormaPago.Value = "EFEC"
        '                Return True
        '            End If
        '        End If
        '        If intFolioDPVale > 0 Then
        '            MsgBox("La Forma de Pago DPVale ya ha sido agregada. Seleccione una distinta.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturacion")
        '            cmbFormaPago.Value = "EFEC"
        '            Return True
        '        End If
        '    End If
        '    If cmbFormaPago.Value = "FONA" And dsFormasPago.Tables(0).Rows.Count > 0 Then
        '        MsgBox("La Forma de Pago no es válida. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturacion")
        '        cmbFormaPago.Value = "EFEC"
        '        Return True
        '    End If
        '    'Prueba------------------------
        '    'If cmbFormaPago.Value = "TFON" And dsFormasPago.Tables(0).Rows.Count > 0 Then
        '    '    MsgBox("La Forma de Pago no es válida. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturacion")
        '    '    cmbFormaPago.Value = "EFEC"
        '    '    e.Cancel = True
        '    'End If
        '    '-------------------------------------------------------------------------------------------------------------------------------
        '    'Si la venta es de tarjeta fonacot no permitimos que elijan inicialmente ninguna forma de pago que no sea TFON o VCJA
        '    '-------------------------------------------------------------------------------------------------------------------------------
        '    If oFactura.CodTipoVenta.Trim = "K" AndAlso InStr("EFEC,TADB,TACR", cmbFormaPago.Value) > 0 AndAlso _
        '    dsFormasPago.Tables(0).Rows.Count = 0 Then
        '        MsgBox("No está permitido agregar esta forma de pago inicialmente en este tipo de venta.", MsgBoxStyle.Exclamation + _
        '               MsgBoxStyle.OKOnly, "  Facturacion")
        '        cmbFormaPago.Value = "TFON"
        '        e.Cancel = True
        '    End If
        '    'Prueba------------------------
        '    If cmbFormaPago.Value = "CRED" And dsFormasPago.Tables(0).Rows.Count > 0 Then
        '        MsgBox("La Forma de Pago no es válida. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturacion")
        '        e.Cancel = True
        '    End If
        '    If cmbFormaPago.Value = "VCJA" Then
        '        EBPago.Value = 0
        '    End If
        'End If

    End Function

    Private Sub FillBancos()

        dsBanco = oCatalogoBancoMgr.GetAll(False)
        Dim dtBanco As DataTable = dsBanco.Tables(0)
        dtBanco = FiltrarTerminal("T1", dtBanco)
        dtBanco = FiltrarTerminal("T2", dtBanco)
        ebCodBanco.DataSource = dtBanco
        ebCodBanco.DropDownList.Columns.Add("Cod. Banco")
        ebCodBanco.DropDownList.Columns.Add("Descripcion")
        ebCodBanco.DropDownList.Columns("Cod. Banco").DataMember = "CodBanco"
        ebCodBanco.DropDownList.Columns("Descripcion").DataMember = "Descripcion"
        ebCodBanco.DropDownList.Columns("Cod. Banco").Width = 50
        ebCodBanco.DropDownList.Columns("Descripcion").Width = 150
        ebCodBanco.DisplayMember = "CodBanco"
        ebCodBanco.ValueMember = "CodBanco"
        ebCodBanco.Refresh()

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

        If dtPromociones.Rows.Count > 0 Then
            Me.cmbPromocion.Value = dtPromociones.Rows(0)("Promocion")
        End If
    End Sub

    Private Sub FillTipoTarjeta()

        dsTipoTarjeta = oCatalogoTipoTarjetaMgr.GetAll(False)
        ebTipoTarjeta.DataSource = dsTipoTarjeta.Tables(0)
        ebTipoTarjeta.DropDownList.Columns.Add("Tipo")
        ebTipoTarjeta.DropDownList.Columns.Add("Descripcion")
        ebTipoTarjeta.DropDownList.Columns("Tipo").DataMember = "CodTipoTarjeta"
        ebTipoTarjeta.DropDownList.Columns("Descripcion").DataMember = "Descripcion"
        ebTipoTarjeta.DropDownList.Columns("Tipo").Width = 50
        ebTipoTarjeta.DropDownList.Columns("Descripcion").Width = 150
        ebTipoTarjeta.DisplayMember = "CodTipoTarjeta"
        ebTipoTarjeta.ValueMember = "CodTipoTarjeta"
        ebTipoTarjeta.Refresh()

    End Sub

    Private Function AutorizarCargoTarjeta() As Boolean

        Dim Band As Boolean = True
        Dim oApp As Process
        Dim oProcesos() As Process
        Dim pagoTarj As Decimal = 0

        If Me.ebTipoTarjeta.Value = "TE" Then

            If oAppSAPConfig.eHub = True Then

                If booleHub Then

                    Dim x As New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
                    Dim mSalida As String = ""
                    Dim mPOSEntry As String = ""       '22        
                    Dim mTrack2 As String = ""        '35        
                    Dim mRespose As String = ""        '61
                    'Dim mHRecordType As String = ""
                    Dim mHTerm As String = ""
                    Dim mHCajero As String = ""
                    Dim mHTienda As String = ""
                    Dim mHTicket As String = ""
                    Dim mHMeses As String = ""
                    Dim mHSkip As String = ""
                    Dim mHFijo As String = ""
                    Dim mAutorizacion As String = ""
                    Dim Mensaje As String = ""
                    Dim Mensaje46 As String = ""
                    Dim mRespcode As String = ""
                    Dim mDummy As String = ""
                    Dim mOperacion As String = ""
                    Dim mAfiliacion As String = ""
                    Dim mCVV2 As String = ""
                    Dim mRespuesta As String = ""
                    Dim mComentario As String = ""
                    Dim strNombre As String = ""
                    Dim strCriptograma As String = ""
                    Dim strCardSN As String = ""
                    Dim strEmisor As String = ""

                    pagoTarj = CDec(EBPago.Value)

                    'ebNumTarj.Text = Datos(0)
                    'strNombre = Datos(1)
                    'strCardSN = Datos(4)
                    'strCriptograma = Datos(5)

                    'Dim intPosition As Integer = 0
                    Dim strVencimiento As String = ""
                    Dim strPromocion As String = ""
                    Dim strNum As String = "" '(ebNumTarj.Text).Replace(";", "")
                    'intPosition = InStr(strNum, "=")
                    'strVencimiento = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)
                    'strNum = Mid(strNum, 1, intPosition - 1)
                    'mPOSEntry = Datos(3) & "1"


                    'If oFacturaMgr.EsTarjetaBloqueada(strNum) Then

                    '    MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '    Me.ebNumTarj.Text = strNum
                    '    Band = False
                    '    If mPOSEntry.Trim = "051" Then
                    '        Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                    '    End If
                    '    GoTo Final

                    If Me.EBPago.Value > oConfigCierreFI.MontoMaxTarjetas Then
                        oAppContext.Security.CloseImpersonatedSession()
                        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                            MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Me.ebNumTarj.Text = ""
                            Band = False
                            GoTo Final
                        Else
                            oAppContext.Security.CloseImpersonatedSession()
                        End If
                        'ElseIf oCatFormaPago.TarjetaUsadaHoy(strNum) OrElse BuscaTarjeta(strNum) = True Then
                        '    oAppContext.Security.CloseImpersonatedSession()
                        '    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                        '        If mPOSEntry.Trim = "051" Then
                        '            Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                        '        End If
                        '        MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '        Me.ebNumTarj.Text = strNum
                        '        Band = False
                        '        GoTo Final
                        '    Else
                        '        oAppContext.Security.CloseImpersonatedSession()
                        '    End If
                    End If

                    'INICIO Consulta de promociones
                    'Dim strProSkip, strProMeses As String
                    'mTrack2 = (ebNumTarj.Text).Replace(";", "")
                    'mTrack2 = (mTrack2).Replace("?", "")
                    mHTienda = oAppContext.ApplicationConfiguration.Almacen
                    mHTerm = oAppContext.ApplicationConfiguration.NoCaja
                    mHCajero = Me.ebPlayer.Text

                    'mSalida = x.PagoTarjeta(mHTienda, mHTerm, mHCajero, "000001", mPOSEntry, mTrack2, _
                    'CDbl(EBPago.Text), mHTicket, mComentario, mRespuesta, _
                    'strCardSN, "", mHMeses, mHSkip, mCVV2)

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
                    'Mensaje46 = "0100Normal              |06006 Meses Sin Intereses|120012 Meses Sin Intereses|"
                    'mRespcode = "00"
                    'If mRespcode = "00" And InStr(Mensaje46, "|") > 0 Then
                    '    'Mando llamar la pantalla para seleccionar la promocion del pago
                    '    Dim ofrm As New frmPromociones(Mensaje46)
                    '    If ofrm.ShowDialog() = DialogResult.OK Then
                    '        strProMeses = ofrm.Plazo
                    '        strProSkip = ofrm.Skip
                    '        strPromocion = ofrm.ebPromocion.Text
                    '        intPromo = CInt(strProMeses)
                    '    Else
                    '        Me.ebNumTarj.Text = ""
                    '        Me.txtCVV2.Text = ""
                    '        Me.txtCVV2.Focus()

                    '        Band = False
                    '        GoTo Final
                    '        'Exit Function
                    '    End If
                    'End If
                    'FIN Consulta de promociones

                    'Limpiamos las variables que pudieron ser afectadas en la consulta de promociones
                    Dim mFirma As String = ""
                    Dim mLote As String = ""
                    Dim mSubtechTermID As String = ""
                    Dim mTrace As String = ""


                    x = New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
                    mRespcode = ""
                    Mensaje = ""
                    Mensaje46 = ""

                    On Error Resume Next

                    'mHRecordType = 2
                    'mPOSEntry = Datos(3) & "1"
                    'mTrack2 = (ebNumTarj.Text).Replace(";", "")
                    'mTrack2 = (mTrack2).Replace("?", "")
                    'ebNumTarj.Text = strNum

                    'El ticket debe de variar, ver de donde se va a sacar el consecutivo
                    mHTicket = oAppSAPConfig.Ticket

                    mSalida = ""
                    mDummy = ""
                    mOperacion = "000000"
                    mHMeses = ""
                    mHSkip = ""
                    mCVV2 = ""

                    'Select Case CInt(mHRecordType)
                    '    Case 1 'mHCVV2 = "    " 'Consulta Planes
                    '        mCVV2 = "    "
                    '        mOperacion = "000001"
                    '    Case 2 : mOperacion = "000000" 'CreditAuth
                    '        mHMeses = strProMeses
                    '        mHSkip = strProSkip
                    '        'mHCVV2 = txtCVV2.Text
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

                    'mPOSEntry = ""
                    mTrack2 = ""
                    strCardSN = ""
                    oProcesos = Process.GetProcessesByName("eHubEMV")
                    If oProcesos.Length < 1 Then
                        Process.Start(Application.StartupPath & "\eHubEMV.exe")
                    End If
                    Console.WriteLine("Tienda: " & mHTienda)
                    Console.WriteLine("HTerm: " & mHTerm)
                    Console.WriteLine("Cajero: " & mHCajero)
                    Console.WriteLine("POSEntry: " & mPOSEntry)
                    Console.WriteLine("Track2: " & mTrack2)
                    Console.WriteLine("Pago: " & EBPago.Text)
                    Console.WriteLine("HTicket: " & mHTicket)
                    Console.WriteLine("Comentario: " & mComentario)
                    Console.WriteLine("Respuesta: " & mRespuesta)
                    Console.WriteLine("CardSN: " & strCardSN)
                    Console.WriteLine("mHMeses: " & mHMeses)
                    Console.WriteLine("mHSkip: " & mHSkip)
                    Console.WriteLine("mCVV2: " & mCVV2)
                    mSalida = x.PagoTarjeta(mHTienda, mHTerm, mHCajero, "000000", mPOSEntry, mTrack2, _
                                            CDbl(EBPago.Text), mHTicket, mComentario, mRespuesta, strCardSN, _
                                            "", mHMeses, mHSkip, mCVV2)
                    mHTicket = ""
                    mDummy = mSalida
                    Debug.Write(mSalida & vbCrLf & "".PadLeft(50, "_"))
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
                            mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
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

                    If mRespcode.Trim = "00" AndAlso mAutorizacion.Trim <> "" AndAlso mAfiliacion.Trim <> "" Then

                        Dim strTrack2() As String = mTrack2.Split("=")

                        Me.ebNumTarj.Text = strTrack2(0).Replace(";", "")
                        strNum = Me.ebNumTarj.Text.Trim
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

                        Mensaje = ""
                        Mensaje = oFacturaMgr.BancoAutorizador(Me.ebNumTarj.Text, intPromo).ToUpper

                        strEmisor = EBBanco.Text

                        If InStr(Mensaje, "BANAMEX") > 0 Then
                            ebCodBanco.Text = "T3"
                            ebCodBanco.Value = "T3"
                            EBBanco.Text = "BANAMEX"
                        ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
                            ebCodBanco.Text = "T1"
                            ebCodBanco.Value = "T1"
                            EBBanco.Text = "BANCOMER"
                        ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
                            ebCodBanco.Text = "T2"
                            ebCodBanco.Value = "T2"
                            EBBanco.Text = "SANTANDER"
                        End If

                        Me.ebTipoTarjeta.Value = "TE"

                        'Transaccion Exitosa
                        Me.ebAutorizacion.Text = mAutorizacion
                        Me.strNoAfiliacion = mAfiliacion

                        bolCargoEHub = True
                        MsgBox("Transacción Exitosa" & Microsoft.VisualBasic.vbCrLf & "Preparar Miniprinter", MsgBoxStyle.Information, "Dportenis PRO")

                        Dim bolReimpresion As Boolean = False
                        Dim oReportV As ReportViewerForm
Reimprimir:
                        Select Case ebCodBanco.Text

                            Case "T3"
Imprime_Banamex:
                                ''Original Banco
                                Dim oARReporte As New rptTicketBANAMEX(pagoTarj, strNum, strVencimiento, _
                                                                       mAutorizacion, strPromocion, "VENTA", _
                                                                       strNombre, Me.ebPlayer.Text, _
                                                                       mAfiliacion, strEmisor, "ORIGINAL BANCO", _
                                                                       mFirma, strCriptograma, True, mHTicket, mLote, _
                                                                       mTrace, mSubtechTermID)
                                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporte.Run()
                                oARReporte.Document.Print(False, False)

                                ''Copia Cliente
                                Dim oARReporteC As New rptTicketBANAMEX(pagoTarj, strNum, strVencimiento, _
                                                                        mAutorizacion, strPromocion, "VENTA", _
                                                                        strNombre, Me.ebPlayer.Text, _
                                                                        mAfiliacion, strEmisor, "COPIA CLIENTE", _
                                                                        mFirma, strCriptograma, True, mHTicket, mLote, _
                                                                       mTrace, mSubtechTermID)
                                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporteC.Run()
                                oARReporteC.Document.Print(False, False)

                                oReportV = New ReportViewerForm
                                oReportV.Report = oARReporte
                                oReportV.Show()

                                oReportV = New ReportViewerForm
                                oReportV.Report = oARReporteC
                                oReportV.Show()

                            Case "T1"

                                Dim oARReporte As New rptTicketBancomer(pagoTarj, strNum, strVencimiento, _
                                                                        mAutorizacion, strPromocion, "VENTA", _
                                                                        strNombre, Me.ebPlayer.Text, _
                                                                        mAfiliacion, EBBanco.Text, "ORIGINAL BANCO", _
                                                                        mPOSEntry, True, True, strCriptograma, _
                                                                        mFirma)
                                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporte.Run()
                                oARReporte.Document.Print(False, False)

                                'Copia Cliente
                                Dim oARReporteC As New rptTicketBancomer(pagoTarj, strNum, strVencimiento, _
                                                                        mAutorizacion, strPromocion, "VENTA", _
                                                                        strNombre, Me.ebPlayer.Text, _
                                                                        mAfiliacion, EBBanco.Text, "COPIA CLIENTE", _
                                                                        mPOSEntry, True, True, strCriptograma, _
                                                                        mFirma)
                                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporteC.Run()
                                oARReporteC.Document.Print(False, False)

                                oReportV = New ReportViewerForm
                                oReportV.Report = oARReporte
                                oReportV.Show()

                                oReportV = New ReportViewerForm
                                oReportV.Report = oARReporteC
                                oReportV.Show()

                            Case Else

                                GoTo Imprime_Banamex

                        End Select

                        If bolReimpresion = False Then
                            If MessageBox.Show("¿Desea reimprimir los vouchers?", "Dportenis Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                bolReimpresion = True
                                GoTo Reimprimir
                            End If
                        End If

                        Me.btnAgregarFP.Focus()
                        Me.btnAgregarFP.PerformClick()

                    ElseIf mRespcode = "06" Then

                        MessageBox.Show("El tiempo de espera para deslizar / insertar la tarjeta ha terminado." & vbCrLf & _
                                        "Por favor, Intente de nuevo.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Band = False
                        GoTo Final

                    ElseIf mRespcode.Trim = "95" Then

                        'Transaccion Cancelada
                        Band = False
                        Me.btnLeerTarjeta.Focus()
                        GoTo Final

                    Else
                        'Transaccion Rechazada

                        Band = False

                        If Trim(mRespcode) <> "00" Then
                            Dim Motivo As String = ""

                            Motivo = Mensaje46

                            Select Case mRespcode.Trim
                                'Case "01"
                                '    Motivo = "Promocion Invalida o Monto inferior al minimo permitido.".ToUpper
                                '    Mensaje46 = "Promocion invalida o monto inferior al minimo permitido.".ToUpper
                                'Case "05"
                                '    Motivo = "CVV2 Requerido".ToUpper
                                Case "04", "14", "41", "43", "142"
                                    oFacturaMgr.SaveTarjetaRechazada(Me.ebNumTarj.Text.Trim)
                                    Motivo = "La tarjeta ha sido rechazada.".ToUpper
                                Case "45"
                                    Motivo = "Promocion Invalida.".ToUpper
                                Case "46"
                                    Motivo = "Monto Inferior al mínimo permitido para las promociones."
                                Case "48"
                                    Motivo = "CVV2 Requerido".ToUpper
                                Case "49"
                                    Motivo = "CVV2 Incorrecto.".ToUpper
                                Case "91", "70"
                                    Motivo = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
                                    Mensaje46 = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
                            End Select

                            'MessageBox.Show("Transacción Rechazada." & vbCrLf & Motivo & vbCrLf & _
                            '       mSalida, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            If Motivo.Trim <> "" Then Motivo = vbCrLf & vbCrLf & Motivo
                            If Mensaje46.Trim <> "" Then Mensaje46 = vbCrLf & vbCrLf & Mensaje46
                            'MessageBox.Show("Transacción Rechazada.".ToUpper & Mensaje46.ToUpper _
                            ', "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                        Me.ebNumTarj.Text = ""
                        Me.txtCVV2.Text = ""
                        'Me.txtCVV2.Focus()
                        Me.btnLeerTarjeta.Focus()

                    End If

                End If
            Else
                GoTo Manual
            End If
        Else
Manual:
            Dim Ruta As String = "C:\LecturaTarjeta.txt"
            Dim strPosEntry As String = ""
            Dim Datos() As String

            pagoTarj = CDec(Me.EBPago.Value)

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
                Band = False
                'Me.ebNumTarj.Text = ""
                'Me.cmbPromocion.DataSource = Nothing
                'Me.cmbPromocion.Text = ""
                GoTo FinalManual
            End If


            Dim strTrack() As String

            ebNumTarj.Text = Datos(0)
            Me.mPosEntryM = CInt(Datos(3) & "1")
            Me.strCriptogramaM = Datos(5)
            Me.strNombreM = Datos(6)

            strPosEntry = CStr(mPosEntryM).Trim.PadLeft(3, "0")

            strTrack = ebNumTarj.Text.Split("=")
            ebNumTarj.Text = strTrack(0)
            strVencM = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)

            If oFacturaMgr.EsTarjetaBloqueada(ebNumTarj.Text.Trim) Then
                MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Me.cmbPromocion.DataSource = Nothing
                'Me.cmbPromocion.Text = ""
                'Me.ebAutorizacion.Text = ""
                Band = False
                'If strPosEntry.Trim = "051" Then
                '    Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                'End If
                GoTo FinalManual
            ElseIf Me.EBPago.Value > oConfigCierreFI.MontoMaxTarjetas Then
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                    MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'Me.cmbPromocion.DataSource = Nothing
                    'Me.cmbPromocion.Text = ""
                    Band = False
                    'If strPosEntry.Trim = "051" Then
                    '    Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                    'End If
                    GoTo FinalManual
                Else
                    oAppContext.Security.CloseImpersonatedSession()
                End If
            ElseIf oCatFormaPago.TarjetaUsadaHoy(Me.ebNumTarj.Text) OrElse BuscaTarjeta(Me.ebNumTarj.Text) = True Then
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                    MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'Me.cmbPromocion.DataSource = Nothing
                    'Me.cmbPromocion.Text = ""
                    Band = False
                    'If strPosEntry.Trim = "051" Then
                    '    Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                    'End If
                    GoTo FinalManual
                Else
                    oAppContext.Security.CloseImpersonatedSession()
                End If
            End If

            FillBancoPromociones(CInt(ebNumTarj.Text.Substring(0, 6)), pagoTarj) 'Me.EBPago.Value)
            Me.cmbPromocion.Text = ""
FinalManual:
            If Band = False Then
                Me.cmbPromocion.DataSource = Nothing
                Me.cmbPromocion.Text = ""
                Me.ebAutorizacion.Text = ""
                Me.ebNumTarj.Text = ""
            End If
            If strPosEntry.Trim = "051" Then
                Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
            End If
        End If
Final:
        Return Band

    End Function

    Private Function LeerArchivoTarjeta(ByVal Ruta As String) As String()

        Dim oStreamR As StreamReader
        Dim strContenido() As String

        oStreamR = New StreamReader(Ruta, System.Text.Encoding.ASCII)

        strContenido = oStreamR.ReadToEnd.Split("|")

        oStreamR.Close()

        Return strContenido

    End Function

    Private Function BuscaTarjeta(ByVal strNumTarj As String) As Boolean

        For Each oRow As DataRow In dsFormasPago.Tables(0).Rows

            If CStr(oRow!NumeroTarjeta).ToUpper = strNumTarj.ToUpper Then

                Return True

            End If

        Next

        Return False

    End Function

    Private Sub AgregaPagoEfectivo()

        Dim i As Integer
        Dim nReg As Integer = dsFormasPago.Tables(0).Rows.Count - 1
        If nReg >= 0 Then

            For i = 0 To nReg

                If dsFormasPago.Tables(0).Rows(i).Item("CodFormasPago") = "EFEC" Then

                    dsFormasPago.Tables(0).Rows(i).Item("MontoPago") = dsFormasPago.Tables(0).Rows(i).Item("MontoPago") + EBPago.Value

                    ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

                    '---------------------------------------------------------------
                    ' JNAVA (26.03.2015): Validamos que si es DPCA no haga esto
                    '---------------------------------------------------------------
                    If Me.cmbConceptoPago.Value <> "DC" Then
                        If ebTotalPagoCliente.Value > ebImporteTotal.Value Then
                            ebCambio.Value = ebTotalPagoCliente.Value - ebImporteTotal.Value
                        End If
                    End If

                    Exit Sub

                End If

            Next

        End If

        Dim drEfectivoRow As DataRow
        drEfectivoRow = dsFormasPago.Tables(0).NewRow

        With drEfectivoRow

            .Item("DPValeID") = 0
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = String.Empty
            .Item("CodTipoTarjeta") = String.Empty
            .Item("NumeroTarjeta") = String.Empty
            .Item("NumeroAutorizacion") = String.Empty
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = 0
            .Item("IngresoComision") = 0
            .Item("IvaComision") = 0
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = EBPago.Value

            dsFormasPago.Tables(0).Rows.Add(drEfectivoRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

            '---------------------------------------------------------------
            ' JNAVA (26.03.2015): Validamos que si es DPCA no haga esto
            '---------------------------------------------------------------
            If Me.cmbConceptoPago.Value <> "DC" Then
                If ebTotalPagoCliente.Value > ebImporteTotal.Value Then
                    ebCambio.Value = ebTotalPagoCliente.Value - ebImporteTotal.Value
                End If
            End If


        End With

        drEfectivoRow = Nothing

    End Sub

    Private Sub AgregaPagoTarjeta()

        Dim drTarjetaRow As DataRow
        drTarjetaRow = dsFormasPago.Tables(0).NewRow

        With drTarjetaRow

            'Se agrega el Ticket "mHTicket"
            If bolCargoEHub = True Then
                .Item("DPValeID") = oAppSAPConfig.Ticket - 1
                bolCargoEHub = False
            Else
                .Item("DPValeID") = 0
            End If
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = ebCodBanco.Value
            .Item("CodTipoTarjeta") = ebTipoTarjeta.Value
            .Item("NumeroTarjeta") = ebNumTarj.Text
            .Item("NumeroAutorizacion") = ebAutorizacion.Text
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = 0 'EBPagoCom.Value
            .Item("IngresoComision") = Decimal.Round(0 / (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            .Item("IvaComision") = .Item("ComisionBancaria") - .Item("IngresoComision")
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = EBPago.Value
            .Item("NoAfiliacion") = strNoAfiliacion
            .Item("Id_Num_Promo") = Me.intPromo

            dsFormasPago.Tables(0).Rows.Add(drTarjetaRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

        End With

        drTarjetaRow = Nothing

    End Sub

    Private Sub AgregaPagoDPValeEcomm()
        'Dim html As String = "&lt;table style=&quot;width: 50%; border-collapse: collapse; margin-left: auto; margin-right: auto;&quot; border=&quot;0&quot;&gt;\r\n&lt;tbody&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;COMERCIAL D'PORTENIS, S.A. DE C.V.&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Matriz:&amp;nbsp;Melchor Ocampo #1005 Centro&amp;nbsp;&amp;nbsp;Mazatl&amp;aacute;n, Sin.&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;SUCURSAL:&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Aquiles Serdan&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Aquiles Serdan s/n, Col. Centro&lt;/td&gt;\r\n&lt;/tr&gt;\r\n\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;07/05/2019 17:43:04&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot; width=&quot;165&quot;&gt;&lt;strong&gt;DPVALE&lt;/strong&gt; (0020793844)&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot; width=&quot;122&quot;&gt;&amp;nbsp; 12&amp;nbsp;&lt;strong&gt;QUINCENAS&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot; width=&quot;165&quot;&gt;&lt;strong&gt;ACREDITADO&lt;/strong&gt;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot; width=&quot;122&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;MARIA GUADALUPE FELIX ESPINOZA&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;(0070082212)&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;CANJEANTE&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;LETICIA LINN DELGADO (90092219)&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Monto Total: $2,999.00&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;FIRMA ________________________&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;PAGOS QUINCENALES DE $&lt;/strong&gt;&amp;nbsp;262&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;EMPIEZA A PAGAR EL:&lt;/strong&gt;&amp;nbsp;2019-05-31&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 20px;&quot;&gt;\r\n&lt;td style=&quot;height: 20px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&lt;!-- pagebreak --&gt;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;/tbody&gt;\r\n&lt;/table&gt;\r\n\r\n&lt;table style=&quot;width: 50%; border-collapse: collapse; margin-left: auto; margin-right: auto;&quot; border=&quot;0&quot;&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;   &lt;td style=&quot;width: 56.9364%; text-align: left;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Plaza: &lt;/strong&gt;MZT&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px; text-align: left;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Expedido en:&amp;nbsp;&lt;/strong&gt;Aquiles Serdan&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px; text-align: left;&quot; colspan=&quot;2&quot;&gt;Aquiles Serdan s/n, Col. CentEl subproceso '<Sin nombre>' (0x1a38) terminó con código 0 (0x0).ro&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;TICKET DE VENTA&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Caja: &lt;/strong&gt;1&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Fecha:&amp;nbsp;&lt;/strong&gt;07/05/2019&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; text-align: right; height: 15px;&quot;&gt;&lt;strong&gt;Hora:&amp;nbsp;&lt;/strong&gt;17:43:04&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; text-align: center; height: 15px;&quot; colspan=&quot;2&quot;&gt;**&amp;iexcl;AHORA ESTAS PROTEGIDO!**&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 122px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 122px;&quot; colspan=&quot;2&quot;&gt;Estas disfrutando del beneficio exclusivo que Ramirez Miramontes y Asociados S.A. de C.V. /SegurosAfirmeS.A.deC.V.,Afirme grupo Financiero brinda a sus clientes y hace de su conocimiento que sus datos personales recabados se trataran para todos los fines vinculados con la relaci&amp;oacute;n jur&amp;iacute;dica celebrada.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;No. Certificado:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;0300457808&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Asegurado:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;LETICIA LINN DELGADO &lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;RFC:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;LIDL820727NP2&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Sexo:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;Femenino&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 122px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 122px;&quot; colspan=&quot;2&quot;&gt;Por solo $250.00 quincenales con un total de $1096, tu suma asegurada por fallecimiento es de $50000 M.N. con vigencia del 2019-05-07 hasta 2019-11-15. Con edades de aceptaci&amp;oacute;n de 18 hasta 70 a&amp;ntilde;os de edad.No cubre fallecimiento por homicidio intencional ni por suicidio.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 33px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; text-align: center; height: 33px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Consentimiento-Certificado de Seguro de Vida&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;No. P&amp;oacute;liza:&amp;nbsp;&lt;/strong&gt;005-000035282-00&lt;strong&gt;&lt;br /&gt;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 69px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 69px;&quot; colspan=&quot;2&quot;&gt;Beneficiario Preferente: Comercial D&amp;acute;Portenis,S.A.deC.V. hasta el saldo adeudado al momento del fallecimiento y el remanente a favor del beneficiario.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 33px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 33px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Beneficiario: &lt;/strong&gt;aaa aaa aaa, Amigo (a) - 100%&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 158px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 158px;&quot; colspan=&quot;2&quot;&gt;Consulta tus condiciones y aviso integro en: &lt;a href=&quot;http://www.excelenciaseguros.com&quot;&gt;www.excelenciaseguros.com&lt;/a&gt;, para mayor informaci&amp;oacute;n sobre la renovaci&amp;oacute;n o cancelaci&amp;oacute;n de la p&amp;oacute;liza favor de comunicarse a los tel&amp;eacute;fonos 018000018989 y 01333826 1833, donde tambi&amp;eacute;n podr&amp;aacute; conocer la documentaci&amp;oacute;n necesaria para cobrar el seguro de vida y que hacer en caso de siniestro.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 158px;&quot;&gt;\r\n   &lt;td style=&quot;height: 158px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;Constar mi consentimiento para formar parte del grupo asegurado en la p&amp;oacute;liza de referencia, as&amp;iacute; como para que las condiciones generales de la p&amp;oacute;liza, y que entre otras cosas contiene los derechos y obligaciones a mi cargo, me sean entregadas atrav&amp;eacute;s de mi correo electr&amp;oacute;nico:________________ mismas que estar&amp;aacute;n disponibles en todo momento para su consulta en www.excelenciaseguros.com&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;&lt;/table&gt;\r\n"
        'Dim oOtrosPagos As OtrosPagos = New OtrosPagos()
        'oOtrosPagos.ImprimirTicketPagoApi(html)
        'oOtrosPagos.ImprimirTicketPagoApiPagare(html)

        Dim drDpvlRow As DataRow
        drDpvlRow = dsFormasPago.Tables(0).NewRow
        With drDpvlRow
            .Item("DPValeID") = 0
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = String.Empty
            .Item("CodTipoTarjeta") = String.Empty
            .Item("NumeroTarjeta") = String.Empty
            .Item("NumeroAutorizacion") = String.Empty
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = 0
            .Item("IngresoComision") = 0
            .Item("IvaComision") = 0
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = EBPago.Value

            dsFormasPago.Tables(0).Rows.Add(drDpvlRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

        End With

        drDpvlRow = Nothing

    End Sub

    Private Sub CreateDataFormaPago()

        If Not dsFormasPago Is Nothing Then
            dsFormasPago = Nothing
        End If

        dsFormasPago = New DataSet

        Dim dtFormaPago As New DataTable("FormasPago")

        Dim dCol As DataColumn
        Dim dRow As DataRow

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "CodFormasPago"
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "CodBanco"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "CodTipoTarjeta"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "NumeroTarjeta"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "NumeroAutorizacion"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "NotaCreditoID"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "ComisionBancaria"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "IngresoComision"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "IvaComision"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "DescripcionFormaPago"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "MontoPago"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "DPValeID"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "NoAfiliacion"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "Id_Num_Promo"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        If Not Me.dtFormasPago Is Nothing Then
            dtFormaPago = Me.dtFormasPago.Copy
        End If
        dsFormasPago.Tables.Add(dtFormaPago)

        gridFormaPago.DataSource = dsFormasPago.Tables(0)
        gridFormaPago.RetrieveStructure()
        gridFormaPago.RootTable.Columns(0).Visible = False
        gridFormaPago.RootTable.Columns(1).Visible = False
        gridFormaPago.RootTable.Columns(2).Visible = False
        gridFormaPago.RootTable.Columns(3).Visible = False
        gridFormaPago.RootTable.Columns(4).Visible = False
        gridFormaPago.RootTable.Columns(5).Visible = False
        gridFormaPago.RootTable.Columns(6).Visible = False
        gridFormaPago.RootTable.Columns(7).Visible = False
        gridFormaPago.RootTable.Columns(8).Visible = False
        gridFormaPago.RootTable.Columns(9).Width = 195
        gridFormaPago.RootTable.Columns(9).HeaderAlignment = TextAlignment.Center
        gridFormaPago.RootTable.Columns(9).Caption = "Forma de Pago"
        gridFormaPago.RootTable.Columns(10).Width = 100
        gridFormaPago.RootTable.Columns(10).HeaderAlignment = TextAlignment.Center
        gridFormaPago.RootTable.Columns(10).Caption = "Monto Total"
        gridFormaPago.RootTable.Columns(11).Visible = False
        gridFormaPago.RootTable.Columns(12).Visible = False
        gridFormaPago.RootTable.Columns(13).Visible = False

    End Sub

    Private Function ValidaPagoEnTarjeta() As Boolean

        If EBPago.Value <= 0 Then

            MsgBox("Ingrese Monto a Pagar.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Forma de Pago")
            EBPago.Focus()
            Return False

        End If

        If ebTipoTarjeta.Text = "" Then

            MsgBox("Ingrese Tipo de Tarjeta.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Forma de Pago")
            ebTipoTarjeta.Focus()
            Return False

        End If

        If ebCodBanco.Text = "" Then

            MsgBox("Ingrese Código de Banco.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Forma de Pago")
            ebCodBanco.Focus()
            Return False

        End If

        If ebNumTarj.Text = String.Empty Then

            MsgBox("Ingrese Número de Tarjeta.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Forma de Pago")
            ebNumTarj.Focus()
            Return False

        End If

        If ebAutorizacion.Text = String.Empty Then

            MsgBox("Ingrese Número de Autorización.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Forma de Pago")
            ebAutorizacion.Focus()
            Return False

        End If

        If Me.cmbPromocion.Text = String.Empty And Me.ebTipoTarjeta.Value = "TM" Then

            MsgBox("Seleccione la promoción utilizada.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Forma de Pago")
            Me.cmbPromocion.Focus()
            Return False

        End If

        Return True

    End Function

    Private Sub ActualizaCambioCliente()

        For Each Orow As DataRow In dsFormasPago.Tables(0).Rows
            If Orow!CodFormasPago = "EFEC" Then
                If (ebTotalPagoCliente.Value > ebImporteTotal.Value) And _
                    (ebTotalPagoCliente.Value - ebImporteTotal.Value) < Orow!MontoPago Then
                    ebCambio.Value = ebTotalPagoCliente.Value - ebImporteTotal.Value
                End If
            End If
        Next

    End Sub

    Private Sub ImprimirVoucherManual(ByVal mPosEntry As Integer)

        Dim bolReimpresion As Boolean = False
        Dim oReportView As New ReportViewerForm

Reimprimir:
        Select Case Me.ebCodBanco.Text.ToUpper

            Case "T3"
Imprime_Banamex:
                Dim oARReporte As New rptTicketBANAMEX(CDbl(EBPago.Text), Me.ebNumTarj.Text.Trim, strVencM, Me.ebAutorizacion.Text.Trim, _
                                                       Me.cmbPromocion.Text, "VENTA", strNombreM, Me.ebPlayer.Text, _
                                                       strNoAfiliacion, EBBanco.Text, "ORIGINAL BANCO", strNombreM, strCriptogramaM, _
                                                       False, "", "", "", "")
                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporte.Run()
                'oARReporte.Document.Print(False, False)

                ''Copia Cliente
                Dim oARReporteC As New rptTicketBANAMEX(CDbl(EBPago.Text), ebNumTarj.Text.Trim, strVencM, ebAutorizacion.Text, _
                                                        Me.cmbPromocion.Text, "VENTA", strNombreM, Me.ebPlayer.Text, _
                                                        strNoAfiliacion, EBBanco.Text, "COPIA CLIENTE", strNombreM, strCriptogramaM, _
                                                        False, "", "", "", "")
                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporteC.Run()
                'oARReporteC.Document.Print(False, False)

                oReportView.Report = oARReporte
                oReportView.Show()

                oReportView = New ReportViewerForm
                oReportView.Report = oARReporteC
                oReportView.Show()

            Case "T1"

                Dim oARReporte As New rptTicketBancomer(CDbl(EBPago.Text), Me.ebNumTarj.Text, strVencM, _
                                                        Me.ebAutorizacion.Text, Me.cmbPromocion.Text, "VENTA", _
                                                        strNombreM, Me.ebPlayer.Text, strNoAfiliacion, _
                                                        EBBanco.Text, "ORIGINAL BANCO", mPosEntry, True, False, _
                                                        strCriptogramaM, strNombreM)
                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporte.Run()
                oARReporte.Document.Print(False, False)

                'Copia Cliente
                Dim oARReporteC As New rptTicketBancomer(CDbl(EBPago.Text), ebNumTarj.Text, strVencM, _
                                                         Me.ebAutorizacion.Text, Me.cmbPromocion.Text, "VENTA", _
                                                         strNombreM, Me.ebPlayer.Text, strNoAfiliacion, _
                                                         EBBanco.Text, "COPIA CLIENTE", mPosEntry, True, False, _
                                                         strCriptogramaM, strNombreM)
                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporteC.Run()
                oARReporteC.Document.Print(False, False)

                'oReportView.Report = oARReporte
                'oReportView.Show()

                'oReportView = New ReportViewerForm
                'oReportView.Report = oARReporteC
                'oReportView.Show()

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


    Private Sub RealizarPago()

        If ebTotalPagoCliente.Value < ebImporteTotal.Value Then
            MsgBox("El Importe Total no ha sido cubierto. No se puede Realizar el Pago.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Forma de Pago")
        ElseIf Me.ebImporteTotal.Value <= 0 Then
            MsgBox("El Importe Total no pude ser cero. No se puede Realizar el Pago.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Forma de Pago")
        Else
            If Me.cmbConceptoPago.Value = "EC" And Me.cmbFormaPago.Value = "DPVL" And oConfigCierreFI.VentaAsistida = False Then
                Dim pagoMgr As New CatalogoFormasPagoManager(oAppContext, oConfigCierreFI)
                Dim config As ConfigEcomm = GetConfigEcomm() 'pagoMgr.GetConfigEcommerce()
                Dim pagoApiEcomm As frmPagoEcommApi = New frmPagoEcommApi(ResponseEcomm, config, Me.ebPlayer.Text, Me.ebNombrePlayer.Text, Me.ebNumOrden.Text)
                pagoApiEcomm.ShowDialog()
                Dim resp As Dictionary(Of String, Object) = pagoApiEcomm.Response
                If resp IsNot Nothing Then
                    PagoEcommApi(Me.cmbConceptoPago.Value, resp, config)
                End If
            Else
                '-------------------------------------------------------------------------------------
                'JNAVA (27.06.2015): Validamos que se haya ingresado el Player, si no, no continua
                '-------------------------------------------------------------------------------------
                If Not ValidarPlayer() Then
                    Exit Sub
                End If

                '--------------------------------------------------------------------------------------------
                'JNAVA (09.01.2015): Modificado para que se pueda realizar el pago de cualquier concepto
                '--------------------------------------------------------------------------------------------
                Pago(Me.cmbConceptoPago.Value)
            End If

        End If

    End Sub

    Private Function GetConfigEcomm() As ConfigEcomm
        Dim pagoMgr As New CatalogoFormasPagoManager(oAppContext, oConfigCierreFI)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim AlmacenMgr As New DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        Dim Almacen As DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
        Almacen = AlmacenMgr.Load(oSAPMgr.Read_Centros())
        Dim config As ConfigEcomm = pagoMgr.CreateConfig()
        config.Tienda = "sw" & oAppContext.ApplicationConfiguration.Almacen.PadLeft(5, "0") & oAppContext.ApplicationConfiguration.NoCaja.PadLeft(5, "0")
        config.Nombre = Almacen.Descripcion
        config.CalleNum = Almacen.DireccionNumExt
        config.Colonia = Almacen.DireccionColonia
        config.CP = Almacen.DireccionCP
        config.Telefono = Almacen.TelefonoNum
        config.Ciudad = Almacen.DireccionCiudad
        config.Estado = Almacen.DireccionEstado
        Return config
    End Function

    Private Sub PagoEcommApi(ByVal conceptopago As String, ByVal respuesta As Dictionary(Of String, Object), ByVal config As ConfigEcomm)
        '-------------------------------------------------------------------------------------------------------------------------------------
        'DARCOS (26.04.2019): creacion de pago
        '-------------------------------------------------------------------------------------------------------------------------------------
        If respuesta("Status") = 1 Then
            Dim oOtrosPagos As OtrosPagos
            oOtrosPagos = PrepararPagoEcomm(conceptopago, respuesta, config)
            If Not oOtrosPagos.Save() Then
                oAppContext.Security.CloseImpersonatedSession()
                MessageBox.Show("No se pudo guardar el Pago. Surgio un error", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Dim oRest As ProcesosEcommerce = New ProcesosEcommerce
            Dim oResponse As Dictionary(Of String, Object)
            oResponse = oRest.ActualizaEstatusOrden(Me.cmbTipoPago.Text, Me.ebNumOrden.Text, Me.ebNombrePlayer.Text, Me.ebPlayer.Text.TrimStart("0"), CStr(respuesta("No_tarjeta")), ResponseEcomm("total"), ResponseEcomm)
            If oResponse.ContainsKey("ErrorMessage") Then
                MessageBox.Show("El pago se realizó, pero no se actualizo correctamente. Favor de contactar a Soporte.", "Pagos Ecommerce", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                EscribeLog(oResponse("ErrorMessage")("Mensaje"), "Error al actualizar el pago de Ecommerce.")
            Else
                If oResponse("error") = 0 Then
                    MessageBox.Show("El pago de su pedido ha sido recibido satisfactoriamente.", "Otros Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("El pago se realizó, pero no se actualizo correctamente. Favor de contactar a Soporte.", "Pagos Ecommerce", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EscribeLog(oResponse("mensaje"), "Error al actualizar el pago de Ecommerce.")
                End If
            End If


            oOtrosPagos.ImprimirComprobantePagoEcomm(Me.ebNumOrden.Text, conceptopago, Me.cmbTipoPago.Value, CStr(respuesta("No_tarjeta")))
            Me.cmbConceptoPago.Value = ""
            Limpiar()

            oAppContext.Security.CloseImpersonatedSession()
        Else
            MsgBox(respuesta("Msg"), MsgBoxStyle.Exclamation, "Otros Pagos")
            CorreoErrorPagosECApi(config, Me.ebNumOrden.Text, respuesta("Msg"), respuesta("No_tarjeta"))
        End If
    End Sub

    Private Sub Pago(ByVal ConceptoPago As String)

        '--------------------------------------------------------------------------------------
        'JNAVA (09.01.2014): Modificado para que se pueda usar en todos los conceptos de pago
        '--------------------------------------------------------------------------------------
        oAppContext.Security.CloseImpersonatedSession()
        If ConceptoPago = "EC" Then
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.OtrosPagos", "DportenisPro.DPTienda.OtrosPagos.RecibirPagosEcommerce") Then
                Exit Sub
            End If
        ElseIf ConceptoPago = "DC" Then
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.OtrosPagos", "DportenisPro.DPTienda.OtrosPagos.RecibirPagosDPCard") Then
                Exit Sub
            End If
        End If

        '-------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (20.01.2015): Si tiene los permisos correctos, continuamos con la creacion del pago
        '-------------------------------------------------------------------------------------------------------------------------------------
        Dim oOtrosPagos As OtrosPagos

        '-------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (09.01.2014): Modificado para solo enviar el concepto de pago y asi obtener su detalle
        '-------------------------------------------------------------------------------------------------------------------------------------
        'Preparamos el Objeto oOtrosPagos con los datos corresponcientes y su detalle
        '-------------------------------------------------------------------------------------------------------------------------------------
        oOtrosPagos = PrepararPago(ConceptoPago)

        '----------------------------------------------------------------------------------------------------------------------------
        'JNAVA (22.01.2015): Revisamos si es pago de DP Card para hacer el pago en KARUM
        '----------------------------------------------------------------------------------------------------------------------------
        If ConceptoPago = "DC" Then
            If Not PagoDPCard(oOtrosPagos) Then
                oAppContext.Security.CloseImpersonatedSession()
                'Si por algun motivo no se realizo el pago de DP Card en KARUM, se sale
                MessageBox.Show("Hubo un error al realizar el Pago en el Centro de Credito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        '-------------------------------------------------------------------------------------------------------------------------------------
        'Grabamos primero PRO
        '-------------------------------------------------------------------------------------------------------------------------------------
        If Not oOtrosPagos.Save() Then
            oAppContext.Security.CloseImpersonatedSession()
            MessageBox.Show("No se pudo guardar el Pago. Surgio un error", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        '----------------------------------------------------------
        ' JNAVA (03.04.2016): Verificamos pagos sin SAP Retail
        '----------------------------------------------------------
        If bolSinSAP = False Then
            '-------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (09.01.2014): Modificado para guardar en SAP de todos los conceptos
            '----------------------------------------------------------------------------------------------------------------------------
            If Not oOtrosPagos.SavePagoSAP Then
                oAppContext.Security.CloseImpersonatedSession()
                oOtrosPagos.RollBack(oOtrosPagos.OtrosPagosID)
                Exit Sub
            End If
        End If

        '----------------------------------------------------------------------------------------------------------------------------
        'JNAVA (23.01.2015): Continuamos con Impresion dependiendo del Concepto
        '----------------------------------------------------------------------------------------------------------------------------
        If ConceptoPago = "EC" Then

            '----------------------------------------------------------------------------------------------------------------------------
            'JNAVA (12.01.2015): Creamos los DZ solo de los pagos de EC
            '----------------------------------------------------------------------------------------------------------------------------
            SaveCobranzaEC(oOtrosPagos.NumOrden, dsFormasPago.Tables(0).Copy)

            '----------------------------------------------------------------------------------------------------------------------------
            'Imprimimos el comprobante de Pago
            '----------------------------------------------------------------------------------------------------------------------------
            oOtrosPagos.ImprimirComprobantePago(oOtrosPagos.NumOrden, oOtrosPagos.Concepto, "", False, ebPlayer.Text)

        ElseIf ConceptoPago = "DC" Then
            '----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 13/07/2015: Se le pone el nombre del tarjeta habiente al voucher
            '----------------------------------------------------------------------------------------------------------------------------
            If ebClienteDPC.Text.Trim() = "" Then
                htDatosDPC("TarjetaHabiente") = InputBox("Escriba el nombre del Tarjetahabiente", "Dportenis PRO")
            Else
                htDatosDPC("TarjetaHabiente") = ebClienteDPC.Text.Trim()
            End If
            '----------------------------------------------------------------------------------------------------------------------------
            'JNAVA (24.01.2015): Imprimimos Vouchers del Pago de DP Card 
            '----------------------------------------------------------------------------------------------------------------------------
            oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "PGO") 'COPIA P/TIENDA
            oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "PGO", True) 'COPIA P/CLIENTE

            '----------------------------------------------------------------------------------------------------------------------------
            'JNAVA (24.02.2015): Imprimimos Comprobante del Pago de DP Card
            '----------------------------------------------------------------------------------------------------------------------------
            oOtrosPagos.ImprimirComprobantePago(CStr(oOtrosPagos.OtrosPagosID), oOtrosPagos.Concepto, CStr(htDatosDPC("TarjetaHabiente")), False, ebPlayer.Text)

        End If

        MessageBox.Show("Se realizo el Pago Exitosamente.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.cmbConceptoPago.Value = ""
        Limpiar()

        oAppContext.Security.CloseImpersonatedSession()

    End Sub

    Private Function PrepararPagoEcomm(ByVal Concepto As String, ByVal respuesta As Dictionary(Of String, Object), ByVal config As ConfigEcomm) As OtrosPagos

        Dim oOtrosPagos As New OtrosPagos
        Dim Cantidad As Integer = 0
        Dim lstOrdenDetail As List(Of Dictionary(Of String, Object))
        lstOrdenDetail = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(CType(ResponseEcomm("DatosOrden"), JArray).ToString())
        For Each detail As Dictionary(Of String, Object) In lstOrdenDetail
            Cantidad += CInt(detail("quantity"))
        Next
        Try
            oOtrosPagos.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
            oOtrosPagos.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
            oOtrosPagos.Concepto = Concepto

            oOtrosPagos.Referencia = Me.ebReferencia.Text
            oOtrosPagos.NumOrden = Me.ebNumOrden.Text

            oOtrosPagos.TotalPago = Me.ebImporteTotal.Value
            oOtrosPagos.Fecha = Date.Now
            oOtrosPagos.CodVendedor = Me.ebPlayer.Text
            oOtrosPagos.Usuario = oAppContext.Security.CurrentUser.SessionLoginName

            oOtrosPagos.Tipo = Me.cmbTipoPago.Value
            oOtrosPagos.Cantidad = Cantidad

            ReDim oOtrosPagos.OtrosPagosDetalles(dsFormasPago.Tables(0).Rows.Count - 1)
            Dim i As Integer = 0
            For Each oRow As DataRow In dsFormasPago.Tables(0).Rows

                Dim detalle As New OtrosPagosDetalle
                With detalle
                    .CodFormasPago = CStr(respuesta("FormaDePago"))
                    .CodBanco = CStr(oRow!CodBanco)
                    .CodTipoTarjeta = CStr(oRow!CodTipoTarjeta)
                    .NumeroTarjeta = CStr(respuesta("No_tarjeta"))
                    .Promocion = CInt(oRow!Id_Num_Promo)
                    .NumeroAutorizacion = CStr(respuesta("CA"))
                    .MontoPago = CDec(oRow!MontoPago)
                    .Fecha = Date.Today
                End With
                oOtrosPagos.OtrosPagosDetalles(i) = detalle
                i += 1
            Next

        Catch ex As Exception
            MessageBox.Show("No se pudo Preparar el Pago. Surgio un error", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "No se pudo Preparar el Pago")
        End Try

        Return oOtrosPagos

    End Function

    Private Function PrepararPago(ByVal Concepto As String) As OtrosPagos

        Dim oOtrosPagos As New OtrosPagos
        Dim Referencia As String = String.Empty
        Dim NumOrden As String = String.Empty

        Try
            oOtrosPagos.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
            oOtrosPagos.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
            oOtrosPagos.Concepto = Concepto

            '--------------------------------------------------------------------------------------
            'JNAVA (09.01.2014): Modificado para que se pueda usar en todos los conceptos de pago
            '--------------------------------------------------------------------------------------
            If Concepto = "EC" Then
                oOtrosPagos.Referencia = Me.ebReferencia.Text
                oOtrosPagos.NumOrden = Me.ebNumOrden.Text
            ElseIf Concepto = "DC" Then 'Concepto nuevo (TArjetas KARUM)
                oOtrosPagos.Referencia = 0
                oOtrosPagos.NumOrden = Me.ebNumDPCard.Text
            End If

            oOtrosPagos.TotalPago = Me.ebImporteTotal.Value
            'oOtrosPagos.Fecha = oSAPMgr.MSS_GET_SY_DATE_TIME()
            oOtrosPagos.Fecha = Date.Now
            oOtrosPagos.CodVendedor = Me.ebPlayer.Text
            oOtrosPagos.Usuario = oAppContext.Security.CurrentUser.SessionLoginName
            '-------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 17/08/2018: Se agrega el tipo de pago de la venta asistida
            '-------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.VentaAsistida = True AndAlso Concepto = "EC" Then
                oOtrosPagos.Tipo = Me.cmbTipoPago.Value
            Else
                oOtrosPagos.Tipo = "DPCard"
            End If

            ReDim oOtrosPagos.OtrosPagosDetalles(dsFormasPago.Tables(0).Rows.Count - 1)
            Dim i As Integer = 0
            For Each oRow As DataRow In dsFormasPago.Tables(0).Rows

                Dim detalle As New OtrosPagosDetalle
                With detalle
                    .CodFormasPago = CStr(oRow!CodFormasPago)
                    .CodBanco = CStr(oRow!CodBanco)
                    .CodTipoTarjeta = CStr(oRow!CodTipoTarjeta)
                    .NumeroTarjeta = CStr(oRow!NumeroTarjeta)
                    .Promocion = CInt(oRow!Id_Num_Promo)
                    .NumeroAutorizacion = CStr(oRow!NumeroAutorizacion)
                    .MontoPago = CDec(oRow!MontoPago)
                    .Fecha = Date.Today
                End With
                oOtrosPagos.OtrosPagosDetalles(i) = detalle
                i += 1
            Next

        Catch ex As Exception
            MessageBox.Show("No se pudo Preparar el Pago. Surgio un error", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "No se pudo Preparar el Pago")
        End Try

        Return oOtrosPagos

    End Function

    'Private Sub ImprimirComprobantePago(ByVal oOtrosPagos As OtrosPagos, Optional ByVal Cliente As String = "")

    '    Try

    '        Dim oARReporte
    '        Select Case oOtrosPagos.Concepto
    '            Case "EC"
    '                oARReporte = New rptOtrosPagos(oOtrosPagos.NumOrden, oOtrosPagos.Concepto)
    '            Case "DC"
    '                oARReporte = New rptComprobantePagoDPCard(oOtrosPagos.NumOrden, Cliente, oOtrosPagos.Concepto)
    '        End Select
    '        oARReporte.Document.Name = "Comprobante de Pago"

    '        'Dim oARReporte As New rptOtrosPagos(oOtrosPagos.NumOrden, oOtrosPagos.Concepto)
    '        'oARReporte.Document.Name = "Comprobante de Pago"

    '        If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

    '            oARReporte.PageSettings.PaperHeight = 7
    '            oARReporte.PageSettings.PaperWidth = 14
    '            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '            oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '            oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

    '        End If

    '        oARReporte.Run()

    '        'oReportViewer.Report = oARReporte
    '        'oReportViewer.Show()

    '        Try
    '            oARReporte.Document.Print(False, False)
    '            'Application.DoEvents()
    '            Threading.Thread.Sleep(1000)
    '            oARReporte.Document.Print(False, False)
    '            'Application.DoEvents()
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try

    '    Catch ex As Exception
    '        MessageBox.Show("Ocurrio un error al imprimir el Comprobante de Pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        EscribeLog(ex.ToString, "-Error al imprimir el Comprobante de Otros Pagos.-")
    '    End Try

    'End Sub

    'Private Function SavePago_SAP(ByVal oOtrosPagos As OtrosPagos, ByVal ConceptoPago As String) As Boolean
    '    '--------------------------------------------------------------------------------------
    '    'JNAVA (09.01.2014): Modificado para que se pueda usar en todos los conceptos de pago
    '    '--------------------------------------------------------------------------------------
    '    Dim bResp As Boolean = False

    '    Try

    '        If oOtrosPagos.OtrosPagosID <> 0 Then
    '            oOtrosPagos.Refresh(oOtrosPagos.Concepto)

    '            Dim oCabecera As New Hashtable
    '            Dim dtDetalle As DataTable
    '            Dim strMsg As String = String.Empty
    '            Dim bRespSAP As Boolean = False

    '            'Llenamos la Cabecera
    '            oCabecera("NoOrden") = oOtrosPagos.NumOrden
    '            oCabecera("Canal") = ConceptoPago 'EC o DC
    '            oCabecera("Pedido") = "" 'Vacios
    '            oCabecera("Referencia") = oOtrosPagos.Referencia
    '            oCabecera("Importe") = oOtrosPagos.TotalPago
    '            oCabecera("Status") = "P" 'Pagado
    '            oCabecera("Vendedor") = oOtrosPagos.CodVendedor
    '            oCabecera("Moneda") = "MXN"

    '            'Creamos la estructura de la Tabla Detalle
    '            dtDetalle = CrearTablaDetalleSAP()

    '            'Llenamos la Tabla con el Detalle del Pago
    '            dtDetalle = LlenarTablaDetalleSAP(dtDetalle, oOtrosPagos)

    '            'Guardamos en sap
    '            bRespSAP = oSAPMgr.ZPOL_REGISTRO_PAGO(oCabecera, dtDetalle, strMsg)

    '            If bRespSAP Then
    '                bResp = True
    '            Else
    '                MessageBox.Show(strMsg.Trim, "Error al registrar Pago EC en SAP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                EscribeLog(strMsg, "Ocurrio un error al Guardar el Pago de ECommerce en SAP.")
    '                bResp = False
    '            End If

    '        Else
    '            bResp = False
    '        End If

    '    Catch ex As Exception

    '        MessageBox.Show("Ocurrio un error al Guardar el Pago de ECommerce en SAP.", "Pago EC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        EscribeLog(ex.ToString, "Ocurrio un error al Guardar el Pago de ECommerce en SAP.")

    '    End Try

    '    Return bResp

    'End Function

    'Private Function SetFormaPago_SAP(ByVal FormaPago As String) As String

    '    Dim strReturn As String = String.Empty

    '    Select Case FormaPago
    '        Case "EFEC"
    '            strReturn = "Efectivo"

    '        Case "TACR"
    '            strReturn = "Tarjeta Credito Banco"

    '        Case "TADB"
    '            strReturn = "Tarjeta Debito Banco"

    '        Case Else
    '            strReturn = FormaPago

    '    End Select

    '    Return strReturn

    'End Function

    'Private Function CrearTablaDetalleSAP() As DataTable

    '    Dim oDetalleTemp As New DataTable("DetalleSAP")

    '    Dim dCol As DataColumn
    '    Dim dRow As DataRow

    '    dCol = New DataColumn
    '    dCol.DataType = System.Type.GetType("System.String")
    '    dCol.ColumnName = "NoOrden"
    '    oDetalleTemp.Columns.Add(dCol)

    '    dCol = New DataColumn
    '    dCol.DataType = System.Type.GetType("System.String")
    '    dCol.ColumnName = "FormaPago"
    '    oDetalleTemp.Columns.Add(dCol)

    '    dCol = New DataColumn
    '    dCol.DataType = System.Type.GetType("System.String")
    '    dCol.ColumnName = "Importe"
    '    oDetalleTemp.Columns.Add(dCol)

    '    dCol = New DataColumn
    '    dCol.DataType = System.Type.GetType("System.String")
    '    dCol.ColumnName = "NoAutorizacion"
    '    oDetalleTemp.Columns.Add(dCol)

    '    oDetalleTemp.AcceptChanges()

    '    Return oDetalleTemp

    'End Function

    'Private Function LlenarTablaDetalleSAP(ByVal dtDetalle As DataTable, ByVal oOtrosPagos As OtrosPagos) As DataTable

    '    For Each oDetalles As OtrosPagosDetalle In oOtrosPagos.OtrosPagosDetalles

    '        With oDetalles

    '            Dim oRow As DataRow = dtDetalle.NewRow()
    '            oRow("NoOrden") = oOtrosPagos.NumOrden
    '            oRow("FormaPago") = SetFormaPago_SAP(oDetalles.CodFormasPago)
    '            oRow("Importe") = oDetalles.MontoPago
    '            oRow("NoAutorizacion") = oDetalles.NumeroAutorizacion
    '            dtDetalle.Rows.Add(oRow)

    '        End With

    '    Next

    '    dtDetalle.AcceptChanges()

    '    Return dtDetalle

    'End Function

    'Private Sub MostrarCamposFormasPago(ByVal Concepto As String, ByVal Mostrar As Boolean)

    '    If Not Mostrar Then
    '        Exit Sub
    '    End If
    '    Select Case Concepto
    '        Case "DC"

    '            '--------------------------------------------------------------------------
    '            ' Mostramos las Formas de pago
    '            '--------------------------------------------------------------------------
    '            Me.exFormasPago.Enabled = True

    '            '--------------------------------------------------------------------------
    '            ' Al ser DP Card, deshabilitamo ciertos campos y habilitamos otros
    '            ' hasta que confirmen el monto del pago
    '            '--------------------------------------------------------------------------
    '            Me.btnAgregarFP.Enabled = False
    '            Me.btnRealizarPago.Enabled = False
    '            Me.cmbFormaPago.Enabled = False
    '            Me.EBPago.Enabled = False
    '            'Me.ebImporteTotal.ReadOnly = False
    '            Me.ebImporteTotal.Focus()

    '        Case "EC"
    '            Me.exFormasPago.Enabled = True
    '            Me.cmbFormaPago.Enabled = True
    '            Me.cmbFormaPago.Focus()

    '    End Select

    'End Sub


#End Region

#Region "Metodos y Funciones ECommerce"

    Private Sub ValidaReferencia()

        If ebReferencia.Text.Trim <> String.Empty Then
            If Me.ebNumOrden.Text.Trim <> "" AndAlso Me.ebReferencia.Text.Trim.ToUpper <> NumRef.Trim.ToUpper Then
                MessageBox.Show("La referencia indicada no coincide con la del número de ordén especificado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebReferencia.Focus()
            Else
                Me.exFormasPago.Enabled = True
                Me.cmbFormaPago.Enabled = True
                Me.cmbFormaPago.Focus()
            End If
        End If

    End Sub

    Private Sub ValidaNumOrdenRest()
        Dim numTienda As String = ""
        Dim pagoMgr As New CatalogoFormasPagoManager(oAppContext, oConfigCierreFI)

        If Me.ebNumOrden.Text.Trim = String.Empty OrElse Me.ebNumOrden.Text.Trim = "0" Then
            Exit Sub
        End If

        If Me.cmbTipoPago.Value Is Nothing Then
            MessageBox.Show("Elija un Tipo de Pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbTipoPago.Focus()
        Else
            numTienda = pagoMgr.GetNumTiendaTiposPagosEcommById(Me.cmbTipoPago.Value)
            Dim oRest As ProcesosEcommerce = New ProcesosEcommerce
            Dim oResponse As Dictionary(Of String, Object)
            oResponse = oRest.EstatusOrden(numTienda, Me.ebNumOrden.Text.Trim)
            If oResponse IsNot Nothing Then
                ResponseEcomm = oResponse
                If oResponse("error") = 1 Then
                    Me.exFormasPago.Enabled = True
                    Me.ebImporteTotal.Value = oResponse("total")
                    Me.EBPago.Value = oResponse("total")
                    Me.EBPago.Enabled = False
                    FillFormaPagoEcomm()

                Else
                    MessageBox.Show(oResponse("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.ebNumOrden.Focus()
                End If
            Else
                MessageBox.Show("Ocurrio un error al consultar el número de orden.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebNumOrden.Focus()
            End If
        End If

    End Sub

    Private Sub ValidaNumOrden()

        Dim oOtrosPagos As New OtrosPagos
        Dim Fecha As Date
        Dim Importe As Decimal, Status As String = ""

        If Me.ebNumOrden.Text.Trim <> String.Empty AndAlso Me.ebNumOrden.Value > 0 Then

            'Validamos el numero de orden con WS y obtenemos Importe y Vigencia
            If Not oOtrosPagos.ValidarNumeroOrdenWS(Me.ebNumOrden.Text, Fecha, Importe, Status, NumRef, cmbTipoPago.Value) Then
                MessageBox.Show("El Número de Orden del Pedido de ECommerce no es Valido. Favor de Verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebNumOrden.Value = 0
                Me.ebNumOrden.Focus()
                Exit Sub
            End If

            If Status.Trim <> "M" Then
                MessageBox.Show("El número de orden no tiene el status para aprobación de pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebNumOrden.Value = 0
                Me.ebNumOrden.Focus()
                Exit Sub
            End If

            'Validamos la vigencia del pedido
            If Fecha.AddDays(oConfigCierreFI.DiasRecibirPagosEC) < Date.Today Then
                MessageBox.Show("No se puede realizar el Pago del Pedido ECommerce. La vigencia del pedido ha expirado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebNumOrden.Value = 0
                Me.ebNumOrden.Focus()
                Exit Sub
            End If

            Me.ebImporteTotal.Value = Importe
            Me.ebReferencia.Focus()
        Else
            Me.ebNumOrden.Focus()
        End If

    End Sub

    Public Sub SaveCobranzaEC(ByVal NumOrden As String, ByVal FormasPago As DataTable)

        '--------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA 12/12/2014: Subimos cada uno de los pagos a la cuenta de ecommerce en SAP (Se crea el DZ)
        '--------------------------------------------------------------------------------------------------------------------------------------
        Dim oAbonosApartadosMgr As New AbonosApartadosManager(oAppContext)
        Dim montoPago As Decimal = 0
        Dim ClienteID As String = ""
        Dim codFormaPago As String = ""
        Dim codBanco As String = ""
        Dim strTipoPago As String = "", strTienda As String = "", strDivision As String = ""
        Dim NoAfiliacion As String = ""

        Try
            For Each row As DataRow In FormasPago.Rows
                codFormaPago = CStr(row("CodFormasPago"))
                If codFormaPago.Trim.ToUpper <> "DPVL" Then
                    montoPago = CDec(row!MontoPago)
                    ClienteID = oConfigCierreFI.ClienteEC
                    codBanco = CStr(row("CodBanco"))
                    NoAfiliacion = CStr(row("NoAfiliacion"))
                    If codFormaPago.Trim() <> "FACI" AndAlso codFormaPago.Trim.ToUpper <> "VCJA" Then
                        If codFormaPago.Trim() = "EFEC" Then
                            strTipoPago = "EFECTIVO"
                            strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, oSAPMgr.Read_Centros)
                        ElseIf codBanco.Trim() = "T1" Then
                            '"BANCOMER" 
                            strTipoPago = "TARJETA 1"
                            strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, oSAPMgr.Read_Centros)
                        ElseIf codBanco.Trim() = "T2" Then
                            '"SERFIN" Then
                            strTipoPago = "TARJETA 2"
                            strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, oSAPMgr.Read_Centros)
                        ElseIf codBanco.Trim() = "T3" Then
                            '"BANAMEX" Then
                            strTipoPago = "TARJETA 3"
                            strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, oSAPMgr.Read_Centros)
                        End If
                        'strDivision = oAbonosApartadosMgr.SelectDivision(strTipoPago, oSAPMgr.Read_Centros)
                        'If strDivision = "0000" Or strDivision = String.Empty Then
                        '    EscribeLog("La division no es correcta, corregir en TABLA ZPP_COBRANZAS en SAP, El campo GSBER es Incorrecto", "Error al subir un pago en " & codFormaPago & " de la Orden de EC" & NumOrden)
                        '    MessageBox.Show("La division no es correcta, corregir en TABLA ZPP_COBRANZAS en SAP", "El campo GSBER es Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Else
                        Dim strError As String = ""
                        oSAPMgr.Write_Anticipoapartado("Ped EC: " & NumOrden, montoPago, ClienteID, _
                                                            NumOrden, "EC", strTienda, strTipoPago, strDivision, _
                                                            oAppContext.ApplicationConfiguration.Almacen, NoAfiliacion, codFormaPago, strError)
                        If strError.Trim <> "" Then
                            CorreoErrorPagosEC(NumOrden, strError)
                            EscribeLog(strError, "Error al subir los pagos de EC Con Número de orden " & NumOrden)
                        End If
                        'End If
                    End If
                End If
            Next
        Catch ex As Exception
            CorreoErrorPagosEC(NumOrden, ex.Message)
            EscribeLog(ex.Message, "Error al subir los pagos de EC Con Número de orden " & NumOrden)
        End Try

    End Sub

    Private Sub CorreoErrorPagosEC(ByVal NumOrden As String, ByVal ErrorMessage As String)

        Dim mmMail As New MailMessage
        Dim objSmtpServer As SmtpMail
        Dim strHTML As String = ""

        strHTML = "<html><head><title></title></head><body><h2>Ocurrió un error al subir los pagos (creación de DZ) del Número de Orden " & NumOrden & " de Ecommerce.</h2><h3>Detalle del Error:</h3><blockquote><p>" & ErrorMessage & "</p></blockquote></body></html>"
        mmMail.From = oConfigCierreFI.CuentaCorreo

        Dim strTo As String = ""
        For i As Integer = 0 To oConfigCierreFI.CuentasCorreoEC.Length - 2
            strTo &= oConfigCierreFI.CuentasCorreoEC(i)
            If i < oConfigCierreFI.CuentasCorreoEC.Length - 2 Then
                strTo &= ";"
            End If
        Next

        mmMail.To = strTo
        mmMail.Subject = "¡Aviso de Error en creacion de DZ's de pagos de Ecommerce en DPPRO"
        mmMail.BodyFormat = MailFormat.Html
        mmMail.Body = strHTML
        objSmtpServer.SmtpServer = oConfigCierreFI.ServidorSMTP
        Try
            objSmtpServer.Send(mmMail)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Ocurrió un error al subir los pagos (creación de DZ) del Número de Orden " & NumOrden & "de Ecommerce.")
        End Try

    End Sub
    Private Sub CorreoErrorPagosECApi(ByVal config As ConfigEcomm, ByVal NumOrden As String, ByVal ErrorMessage As String, ByVal Vale As String)

        Dim mmMail As New MailMessage
        Dim objSmtpServer As SmtpMail
        Dim strHTML As String = ""

        strHTML = "<html><head><title></title></head><body><h2>Se notifica que se ha producido un error al realizar el cobro de la orden con número: " & NumOrden & " de Eccomemrce y número de vale:" & Vale & "</h2><h3>Detalle del Error:</h3><blockquote><p>" & ErrorMessage & "</p></blockquote><h3>Favor de revisar el problema lo antes posible con las áreas correspondientes de DpVale e Ecommerce y TI.</h3></body></html>"
        mmMail.From = oConfigCierreFI.CuentaCorreo

        Dim mails() As String
        mails = config.Correo.Split(",")
        Dim strTo As String = ""
        Dim primerMail As Boolean = False
        For Each ml As String In mails
            If primerMail Then
                strTo &= ";"
                primerMail = True
            End If
            strTo &= ml
        Next

        mmMail.To = strTo
        mmMail.Subject = "URGENTE: Error pago ecommerce con DPVL"
        mmMail.BodyFormat = MailFormat.Html
        mmMail.Body = strHTML
        objSmtpServer.SmtpServer = oConfigCierreFI.ServidorSMTP
        Try
            objSmtpServer.Send(mmMail)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Ocurrió un error en pago Ecommerce del Número de Orden " & NumOrden & "de Ecommerce.")
        End Try

    End Sub

#End Region

#Region "Metodos y FuncionesDPCard"

    '-----------------------------------------------------------------------------
    'JNAVA (09.01.2014): Validacion y obtencion de datos de DPCard
    '-----------------------------------------------------------------------------
    Private Sub ValidaDPCard()

        Dim bMostrarFP As Boolean = True
        If Not bExit Then
            Me.lblValidaDPCard.Visible = True
            Application.DoEvents()
            Try

                '----------------------------------------------------------------
                ' JNAVA (03.06.2015): COMENTAR AL TERMINAR CERTIFICACION
                '----------------------------------------------------------------
                'GoTo OK
                '----------------------------------------------------------------

                '-----------------------------------------------------------------------------
                ' Validamos el DP Card
                '-----------------------------------------------------------------------------
                If Me.ebNumDPCard.Text.Trim <> String.Empty Then
                    '------------------------------------------------------------------------------------
                    'FLIZARRAGA 16/05/2017: Validacion de Luhn para corroborar si la tarjeta es correcta
                    '------------------------------------------------------------------------------------
                    If ValidacionLuhn(Me.ebNumDPCard.Text.Trim()) Then
                        Dim FechaLimite As String
                        '-----------------------------------------------------------------------------
                        'FLIZARRAGA (20.01.2014): Validamos el DP Card con KARUM
                        '-----------------------------------------------------------------------------
                        Dim ws As New WSBroker("WS_KARUM", True)
                        Dim param As New Hashtable
                        param("NoTarjeta") = Me.ebNumDPCard.Text.Trim()
                        '----------------------------------------------------------
                        ' JNAVA (03.04.2016): Verificamos pagos sin SAP Retail
                        '----------------------------------------------------------
                        If bolSinSAP Then
                            param("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME().ToString("yyyyMMddHHmmss")
                        Else
                            param("Fecha") = DateTime.Now.ToString("yyyyMMddHHmmss")
                        End If
                        'param("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME().ToString("yyyyMMddHHmmss")
                        '----------------------------------------------------------
                        param("ConsecutivoPOS") = oConfigCierreFI.ConsecutivoPOS
                        param("IDPOS") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                        'param("IDTienda") = "D3" & oAppContext.ApplicationConfiguration.Almacen.PadLeft(5, "0")
                        param("IDTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                        '-----------------------------------------------------------------------------
                        'JNAVA (12.03.2015): Especificamos si fue deslizada o Digitada
                        '-----------------------------------------------------------------------------
                        If deslizada = True Then
                            param("Tipo") = "00"
                        Else
                            param("Tipo") = "01"
                        End If

                        Dim resultado As Hashtable = ws.AccountStatus(param)
                        If resultado.Count > 0 Then
                            If resultado.ContainsKey("Success") = True Then
                                If CBool(resultado("Success")) = True Then
                                    Me.ebSaldoDPC.Text = CDec(resultado("SaldoActual"))
                                    Me.ebPagoMinimo.Text = CDec(resultado("PagoMinimo"))
                                    Me.ebPagoVencido.Text = CDec(resultado("PagoVencido"))
                                    'Me.ebImporteTotal.Text = CDec(resultado("PagoTotal"))
                                    '----------------------------------------------------------------------------------------------
                                    'JNAVA (13.03.2015): Si la tarjeta fue digitada, ponemos solo el apellido que regresa KARUM
                                    '----------------------------------------------------------------------------------------------
                                    If Not deslizada Then
                                        Me.ebClienteDPC.Text = CStr(resultado("TarjetaHabiente"))
                                    End If
                                    FechaLimite = CStr(resultado("FechaLimitePago")).Substring(0, 4) & "/" & CStr(resultado("FechaLimitePago")).Substring(4, 2) & "/" & CStr(resultado("FechaLimitePago")).Substring(6, 2)
                                    Me.cmbFechaLimite.Value = CDate(FechaLimite)
                                Else
                                    bMostrarFP = False
                                    EscribeLog(CStr(resultado("Mensaje")), "Error en el Metodo Account Status del WebService Karum")
                                    MessageBox.Show(CStr(resultado("Mensaje")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If

                        Else
                            bMostrarFP = False
                            EscribeLog("No Hubo Respuesta de Metodo Account Status WebService Karum", "WebService Karum")
                            MessageBox.Show("No se pudo obtener informacion de la Credit Card", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                        ''PRUEBAS
                        'Me.ebSaldoDPC.Text = CDec(1000)
                        'Me.ebPagoMinimo.Text = CDec(100)
                        'Me.ebPagoVencido.Text = CDec(0)
                        'Me.ebImporteTotal.Text = CDec(100)
                        ''PRUEBAS

                        ''-----------------------------------------------------------------------------
                        ''JNAVA (09.03.2015): Mostramos las formas de pago 
                        ''-----------------------------------------------------------------------------
                        'MostrarCamposFormasPago(Me.cmbConceptoPago.Value, bMostrarFP)

                        'OK:
                        '------------------------------------------------------------------------------
                        ' JNAVA (07.04.2015): Mostramos las formas de pago 
                        '------------------------------------------------------------------------------
                        If bMostrarFP Then
                            Me.exFormasPago.Enabled = True
                            Me.cmbFormaPago.Enabled = True
                            Me.cmbFormaPago.Focus()
                        End If
                    End If
                End If

            Catch ex As Exception
                EscribeLog(ex.ToString, "Error al validar el DP Card")
                Throw ex
            Finally
                Me.lblValidaDPCard.Visible = False
                Application.DoEvents()
            End Try
        End If
    End Sub

    '-----------------------------------------------------------------------------
    'JNAVA (22.01.2014): Realizacion del pago de DPCard en KARUM
    '-----------------------------------------------------------------------------
    Private Function PagoDPCard(ByRef OtrosPagos As OtrosPagos) As Boolean

        Dim bResp As Boolean = True
        Try
            '------------------------------------------------------------------------------------------------
            'FLIZARRAGA 20/02/2015: Se Realiza el pago con Karum
            '------------------------------------------------------------------------------------------------
            Dim param As New Hashtable
            Dim resultado As Hashtable

            param("NoTarjeta") = Me.ebNumDPCard.Text.Trim()
            param("Monto") = CDec(Me.ebImporteTotal.Value)
            'param("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME().ToString("yyyyMMddHHmmss")
            param("Fecha") = DateTime.Now.ToString("yyyyMMddHHmmss")
            param("ConsecutivoPOS") = oConfigCierreFI.ConsecutivoPOS
            param("IDPOS") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
            'param("IDTienda") = "D3" & oAppContext.ApplicationConfiguration.Almacen.PadLeft(4, "0")
            param("IDTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
            param("Promocion") = "00"

            '-----------------------------------------------------------------------------
            'JNAVA (12.03.2015): Especificamos si fue deslizada o Digitada
            '-----------------------------------------------------------------------------
            If deslizada = True Then
                param("Tipo") = "00"
            Else
                param("Tipo") = "01"
            End If

            Dim ws As New WSBroker("WS_KARUM", True)
            resultado = ws.Payment(param)

            '-----------------------------------------------------------------------------
            ' JNAVA (20.02.2015): Validamos datos de KARUM (para ticket y registros)
            '-----------------------------------------------------------------------------
            '-----------------------------------------------------------------------------
            'FLIZARRAGA 26/02/2015: Agrego validación y mensajes de errores
            '-----------------------------------------------------------------------------
            If resultado.Count > 0 Then
                If resultado.ContainsKey("Success") = True Then
                    If CBool(resultado("Success")) = False Then
                        EscribeLog(CStr(resultado("Mensaje")), "Error al generar el pago en Karum")
                        MessageBox.Show(CStr(resultado("Mensaje")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bResp = False
                        GoTo Salir
                    End If
                End If
            Else
                EscribeLog("Respuesta Vacia por Parte del Metodo Payment Webservice Karum", "WebService Karum")
                MessageBox.Show("Error al generar el pago con CreditCard", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                bResp = False
                GoTo Salir
            End If

            '-----------------------------------------------------------------------------
            ' JNAVA (20.02.2015): Obtenemos datos de KARUM (para ticket y registros)
            '-----------------------------------------------------------------------------
            htDatosDPC = resultado

            '''PRUEBAS
            'htDatosDPC("Transaccion") = "1234"
            'htDatosDPC("Autorizacion") = Date.Now.ToString("ddMMyyyyHHmmss")
            '''PRUEBAS

            '-----------------------------------------------------------------------------
            ' JNAVA (08.04.2015): El número de la tienda debe ser el de KARUM
            '-----------------------------------------------------------------------------
            htDatosDPC("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
            htDatosDPC("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
            htDatosDPC("Tarjeta") = Me.ebNumDPCard.Text.Trim()
            htDatosDPC("TarjetaHabiente") = Me.ebClienteDPC.Text
            htDatosDPC("Monto") = CDec(Me.ebImporteTotal.Value)
            htDatosDPC("Vendedor") = oAppContext.Security.CurrentUser.Name 'Vendedor
            OtrosPagos.Referencia = Date.Now.ToString("ddMMyyyyHHmmss")

            '-----------------------------------------------------------------------------
            'JNAVA (12.03.2015): Especificamos si fue deslizada o Digitada
            '-----------------------------------------------------------------------------
            If deslizada = True Then
                htDatosDPC("Linea") = "DESLIZADA"
            Else
                htDatosDPC("Linea") = "DIGITADA"
            End If

            '-----------------------------------------------------------
            'FLIZARRAGA 30/10/2017: Consecutivo POS
            '-----------------------------------------------------------
            htDatosDPC("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")

Salir:
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al realizar el abono")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return bResp
    End Function

    ''-----------------------------------------------------------------------------
    ''JNAVA (22.01.2014): Impresion del Voucher del pago de DPCard en KARUM
    ''-----------------------------------------------------------------------------
    'Private Sub ImprimirVoucherDPCard()

    '    Try

    '        If Not htDatosDPC Is Nothing AndAlso htDatosDPC.Count > 0 Then
    '            '-----------------------------------------------------------------------------------
    '            'JNAVA (22.01.2015): Voucher para Tienda
    '            '-----------------------------------------------------------------------------------
    '            Dim oARReporte As New rptVoucherDPCard(htDatosDPC, "PGO")
    '            oARReporte.Document.Name = "Voucher DPCard"

    '            If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

    '                oARReporte.PageSettings.PaperHeight = 7
    '                oARReporte.PageSettings.PaperWidth = 14
    '                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
    '                oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
    '                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

    '            End If

    '            oARReporte.Run()

    '            'Dim oReportViewer As New ReportViewerForm
    '            'oReportViewer.Report = oARReporte
    '            'oReportViewer.Show()

    '            '-----------------------------------------------------------------------------------
    '            ' Imprimimos voucher para tienda
    '            '-----------------------------------------------------------------------------------
    '            Try
    '                oARReporte.Document.Print(False, False)
    '            Catch ex As Exception
    '                MsgBox(ex.ToString)
    '            End Try


    '            '-----------------------------------------------------------------------------------
    '            'JNAVA (23.01.2015): Voucher para Cliente
    '            '-----------------------------------------------------------------------------------
    '            Dim oARReporteCliente As New rptVoucherDPCard(htDatosDPC, "PGO", True)
    '            oARReporteCliente.Document.Name = "Voucher DPCard Cliente"

    '            If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

    '                oARReporteCliente.PageSettings.PaperHeight = 7
    '                oARReporteCliente.PageSettings.PaperWidth = 14
    '                oARReporteCliente.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
    '                oARReporteCliente.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
    '                oARReporteCliente.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

    '            End If

    '            oARReporteCliente.Run()

    '            'Dim oReportViewer As New ReportViewerForm
    '            'oReportViewer.Report = oARReporteCliente
    '            'oReportViewer.Show()

    '            '-----------------------------------------------------------------------------------
    '            ' Imprimimos voucher para cliente
    '            '-----------------------------------------------------------------------------------
    '            Try
    '                oARReporteCliente.Document.Print(False, False)
    '            Catch ex As Exception
    '                MsgBox(ex.ToString)
    '            End Try

    '        Else
    '            MessageBox.Show("No se han cargado los datos del DP Card. Favor de verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If


    '    Catch ex As Exception
    '        MessageBox.Show("Ocurrio un error al imprimir el Voucher de Pago de DP Card.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        EscribeLog(ex.ToString, "-Error al imprimir el Voucher de Pago de DP Card.-")
    '    End Try


    'End Sub

#End Region

#Region "Eventos"

    Private Sub frmOtrosPagos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmbFecha.Text = Format(Today, "dd - MMMM - yyyy")
        LLenarComboConceptos()
        If oConfigCierreFI.VentaAsistida = True Then
            LoadVentaAsistida()
        Else
            Me.lblTipoPago.Text = "Portal Web:"
            LoadTipoPagoEcomm()
        End If

    End Sub

    Private Sub ebPlayer_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebPlayer.ButtonClick
        LoadSearchFormPlayer()
    End Sub

    Private Sub ebPlayer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebPlayer.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then
            If IsNumeric(ebPlayer.Text.Trim()) Then
                LoadSearchFormPlayer()
                ebPlayer.Focus()
                ebPlayer.SelectAll()
            Else
                MessageBox.Show("Los códigos de vendedor debe ser númericos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub cmbTipoPago_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoPago.ValueChanged
        If Me.cmbConceptoPago.Value = "EC" Then
            Me.ebNumOrden.Focus()
        End If
    End Sub


    Private Sub ebPlayer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebPlayer.Validating

        If oConfigCierreFI.ShowManagerPC AndAlso ebPlayer.Text.Trim = "" Then

            Me.ebPlayer.Focus()
            Return

        End If

        If ebPlayer.Text.Trim <> "" Then

            ebPlayer.Text = ebPlayer.Text.PadLeft(8, "0")

            oVendedor.ClearFields()

            oVendedoresMgr.LoadInto(ebPlayer.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then
                ebNombrePlayer.Text = oVendedor.Nombre
                If Me.cmbConceptoPago.Value = "EC" Then
                    Me.cmbTipoPago.Focus()
                ElseIf Me.cmbConceptoPago.Value = "DC" Then
                    '--------------------------------------------------------------
                    'JNAVA (08.01.2015): Agregamos lo correspondiente a abonos DC
                    '--------------------------------------------------------------
                    Me.btnLeerDPCard.Focus()
                End If
            Else
NoExiste:
                MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación ")

                oVendedor.ClearFields()
                Me.ebNombrePlayer.Text = ""
                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub cmbConceptoPago_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbConceptoPago.ValueChanged
        If Me.cmbConceptoPago.Text.Trim <> "" Then
            MostrarPantallas()
        End If
    End Sub

    Private Sub UiCommandBar1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandBar1.CommandClick

        Select Case e.Command.Key

            Case "menuLimpiar"

                Me.cmbConceptoPago.Value = ""
                Limpiar()

            Case "menuRealizarPago"

                RealizarPago()

            Case "menuSalir"

                Me.Close()


        End Select

    End Sub

    Private Sub frmOtrosPagos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

        'If e.KeyCode = Keys.F1 Then
        'Dim html As String = "&lt;table style=&quot;width: 50%; border-collapse: collapse; margin-right: auto;&quot; border=&quot;0&quot;&gt;\r\n&lt;tbody&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;COMERCIAL D'PORTENIS, S.A. DE C.V.&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Matriz:&amp;nbsp;Melchor Ocampo #1005 Centro&amp;nbsp;&amp;nbsp;Mazatl&amp;aacute;n, Sin.&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;SUCURSAL:&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Aquiles Serdan&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Aquiles Serdan s/n, Col. Centro&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;09/05/2019 11:25:48&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot; width=&quot;165&quot;&gt;&lt;strong&gt;DPVALE&lt;/strong&gt; (0022207518)&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot; width=&quot;122&quot;&gt;&amp;nbsp; 4&amp;nbsp;&lt;strong&gt;QUINCENAS&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot; width=&quot;165&quot;&gt;&lt;strong&gt;ACREDITADO&lt;/strong&gt;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot; width=&quot;122&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;ANA CRISTINA SARABIA MARTINEZ&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;(0070085614)&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;CANJEANTE&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;FRANCISCO JAVIER ROJO GOLDEN (90265351)&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Monto Total: $577.60&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;FIRMA ________________________&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;PAGOS QUINCENALES DE $&lt;/strong&gt;&amp;nbsp;156&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;EMPIEZA A PAGAR EL:&lt;/strong&gt;&amp;nbsp;2019-05-31&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 20px;&quot;&gt;\r\n&lt;td style=&quot;height: 20px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&lt;!-- pagebreak --&gt;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;/tbody&gt;\r\n&lt;/table&gt;\r\n\r\n&lt;table style=&quot;width: 50%; border-collapse: collapse; margin-right: auto;&quot; border=&quot;0&quot;&gt;\r\n  &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n     &lt;td style=&quot;width: 56.9364%; text-align: left;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Plaza: &lt;/strong&gt;MZT&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px; text-align: left;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Expedido en:&amp;nbsp;&lt;/strong&gt;Aquiles Serdan&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px; text-align: left;&quot; colspan=&quot;2&quot;&gt;Aquiles Serdan s/n, Col. Centro&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;TICKET DE VENTA&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Caja: &lt;/strong&gt;1&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Fecha:&amp;nbsp;&lt;/strong&gt;09/05/2019&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; text-align: right; height: 15px;&quot;&gt;&lt;strong&gt;Hora:&amp;nbsp;&lt;/strong&gt;11:25:48&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; text-align: center; height: 15px;&quot; colspan=&quot;2&quot;&gt;**&amp;iexcl;AHORA ESTAS PROTEGIDO!**&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 122px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 122px;&quot; colspan=&quot;2&quot;&gt;Estas disfrutando del beneficio exclusivo que Ramirez Miramontes y Asociados S.A. de C.V. /SegurosAfirmeS.A.deC.V.,Afirme grupo Financiero brinda a sus clientes y hace de su conocimiento que sus datos personales recabados se trataran para todos los fines vinculados con la relaci&amp;oacute;n jur&amp;iacute;dica celebrada.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;No. Certificado:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;0300457808&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Asegurado:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;FRANCISCO JAVIER ROJO GOLDEN &lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;RFC:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;XAXX010101XXX&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Sexo:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;Femenino&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 122px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 122px;&quot; colspan=&quot;2&quot;&gt;Por solo $12.00 quincenales con un total de $48, tu suma asegurada por fallecimiento es de $50000 M.N. con vigencia del 2019-05-09 hasta 2019-07-15. Con edades de aceptaci&amp;oacute;n de 18 hasta 70 a&amp;ntilde;os de edad.No cubre fallecimiento por homicidio intencional ni por suicidio.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 33px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; text-align: center; height: 33px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Consentimiento-Certificado de Seguro de Vida&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;No. P&amp;oacute;liza:&amp;nbsp;&lt;/strong&gt;005-000035282-00&lt;strong&gt;&lt;br /&gt;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 69px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 69px;&quot; colspan=&quot;2&quot;&gt;Beneficiario Preferente: Comercial D&amp;acute;Portenis,S.A.deC.V. hasta el saldo adeudado al momento del fallecimiento y el remanente a favor del beneficiario.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 33px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 33px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Beneficiario: &lt;/strong&gt;prueba prueba prueba, Padre - 10%&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 158px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 158px;&quot; colspan=&quot;2&quot;&gt;Consulta tus condiciones y aviso integro en: &lt;a href=&quot;http://www.excelenciaseguros.com&quot;&gt;www.excelenciaseguros.com&lt;/a&gt;, para mayor informaci&amp;oacute;n sobre la renovaci&amp;oacute;n o cancelaci&amp;oacute;n de la p&amp;oacute;liza favor de comunicarse a los tel&amp;eacute;fonos 018000018989 y 01333826 1833, donde tambi&amp;eacute;n podr&amp;aacute; conocer la documentaci&amp;oacute;n necesaria para cobrar el seguro de vida y que hacer en caso de siniestro.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 158px;&quot;&gt;\r\n   &lt;td style=&quot;height: 158px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;Constar mi consentimiento para formar parte del grupo asegurado en la p&amp;oacute;liza de referencia, as&amp;iacute; como para que las condiciones generales de la p&amp;oacute;liza, y que entre otras cosas contiene los derechos y obligaciones a mi cargo, me sean entregadas atrav&amp;eacute;s de mi correo electr&amp;oacute;nico:________________ mismas que estar&amp;aacute;n disponibles en todo momento para su consulta en www.excelenciaseguros.com&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n&lt;/table&gt;\r\n"
        'Dim oOtrosPagos As OtrosPagos = New OtrosPagos()
        'oOtrosPagos.ImprimirTicketPagoApi(html)
        'oOtrosPagos.ImprimirTicketPagoApiPagare(html)
        'End If

    End Sub

    Private Sub cmbFormaPago_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.ValueChanged
        HabilitaCamposFormaPago()
    End Sub

    Private Sub cmbFormaPago_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbFormaPago.Validating
        'e.Cancel = ValidaFormaPago()
        EBPago.Value = IIf(ebImporteTotal.Value - ebTotalPagoCliente.Value >= 0, ebImporteTotal.Value - ebTotalPagoCliente.Value, 0)
    End Sub

    Private Sub ebReferencia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebReferencia.Validating
        ValidaReferencia()
    End Sub

    Private Sub EBPago_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBPago.ValueChanged
        If (Me.cmbFormaPago.Value = "TACR" OrElse Me.cmbFormaPago.Value = "TADB") AndAlso Me.ebTipoTarjeta.Text = "TM" Then
            Me.ebNumTarj.Text = ""
            Me.cmbPromocion.DataSource = Nothing
            Me.cmbPromocion.Text = ""
        End If
    End Sub

    Private Sub EBPago_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBPago.Validating
        e.Cancel = ValidaMontoPago()
    End Sub

    Private Sub btnLeerTarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerTarjeta.Click

        Me.btnLeerTarjeta.Enabled = False
        If oConfigCierreFI.PagosBanamex = True Then
            AddFormaPagoBanamex()
        Else
            AutorizarCargoTarjeta()
        End If
        Me.btnLeerTarjeta.Enabled = True

    End Sub

    Private Sub ebTipoTarjeta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTipoTarjeta.Validating

        booleHub = False

        If ebTipoTarjeta.Value <> "" Then

            Dim drView As DataRowView
            drView = ebTipoTarjeta.SelectedItem

            EBTarjeta.Text = drView.Item(1)

            If drView.Item(0) = "TE" Then
                If oAppSAPConfig.eHub = True Then
                    booleHub = True
                End If
                Me.txtCVV2.Enabled = True
                Me.cmbPromocion.Enabled = False
                Me.ebAutorizacion.ReadOnly = True
                Me.ebAutorizacion.BackColor = Color.Ivory
            Else
                Me.txtCVV2.Enabled = False
                Me.cmbPromocion.Enabled = True
                Me.ebAutorizacion.ReadOnly = False
                Me.ebAutorizacion.BackColor = Color.White
            End If

            drView = Nothing

        Else

            EBTarjeta.Text = ""

        End If

    End Sub

    Private Sub ebCodBanco_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodBanco.Validating

        If ebCodBanco.Value <> "" Then

            Dim drView As DataRowView
            drView = ebCodBanco.SelectedItem

            EBBanco.Text = drView.Item(1)

            If Not oAppSAPConfig.eHub = True Then

            End If
            If oConfigCierreFI.PagosBanamex = True Then
                GetPromocionesBanamex()
                cmbPromocion.Enabled = True
                ebNumTarj.Enabled = False
                btnLeerTarjeta.Enabled = False
                cmbPromocion.Focus()
            End If
            drView = Nothing

        Else

            EBBanco.Text = ""

        End If
    End Sub

    Private Sub btnAgregarFP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarFP.Click

        'Dim bolProcDPvale As Boolean = False

        'If ebTotalPagoCliente.Value >= ebImporteTotal.Value Then
        '    MsgBox("No se pueden agregar más pagos. El Importe Total ha sido cubierto. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Forma de Pago")
        '    Exit Sub
        'End If

        '-------------------------------------------------------------------------------------
        'JNAVA (27.06.2015): Validamos que se haya ingresado el Player, si no, no continua
        '-------------------------------------------------------------------------------------
        If Not ValidarPlayer() Then
            Exit Sub
        End If

        If EBPago.Value <= 0 Then
            MsgBox("Ingrese Monto a Pagar.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Forma de Pago")
            EBPago.Focus()
            Exit Sub
        End If

        Dim bResFonacot As Boolean

        Select Case cmbFormaPago.Value

            Case "EFEC"            'Efectivo

                AgregaPagoEfectivo()

            Case "TACR", "TADB"     'Tarjeta Crédito o Débito
                If oConfigCierreFI.PagosBanamex = True Then
                    If AddFormaPagoBanamex() = True Then
                        AgregaPagoTarjeta()
                    End If
                Else
                    If bolCargoEHub = False Then
                        Me.ebTipoTarjeta.Value = "TM"
                        Me.ebTipoTarjeta.Focus()
                        btnAgregarFP.Focus()
                    End If

                    If ValidaPagoEnTarjeta() Then
                        Dim Pago As Decimal = 0
                        If bolCargoEHub = False Then
                            Dim dvBanco As New DataView(dsBanco.Tables(0), "CodBanco = '" & Me.ebCodBanco.Value & "'", "CodBanco", DataViewRowState.CurrentRows)
                            Dim NumT As String = ""
                            Pago = Me.EBPago.Value
                            NumT = Me.ebNumTarj.Text
                            Me.strNoAfiliacion = oFacturaMgr.GetAfiliacion(Me.cmbPromocion.Value, dvBanco(0)!IDEmisor)
                            If Me.cmbPromocion.Value <> 1 Then
                                Me.cmbFormaPago.Value = "TACR"
                                Me.ebTipoTarjeta.Value = "TM"
                                Me.EBPago.Value = Pago
                                Me.ebNumTarj.Text = NumT
                            End If
                            Me.intPromo = Me.cmbPromocion.Value
                        Else
                            Pago = Me.EBPago.Value
                            If intPromo > 1 Then
                                Me.cmbFormaPago.Value = "TACR"
                                Me.EBPago.Value = Pago
                            End If
                        End If

                        AgregaPagoTarjeta()
                        'ebTotalComision.Value = ebTotalComision.Value + EBPagoCom.Value

                        If Me.ebTipoTarjeta.Value = "TM" AndAlso oConfigCierreFI.UsarTPV = False Then
                            ImprimirVoucherManual(mPosEntryM)
                        End If
                        mPosEntryM = 0
                        strNoAfiliacion = ""
                        intPromo = 0
                    Else
                        Exit Sub
                    End If
                End If
            Case "DPVL"
                AgregaPagoDPValeEcomm()
        End Select

        '-------------------------------------------------------------------------
        ' JNAVA (26.03.2015): Si es pago DPCA agregamos sumamos el importe total
        '-------------------------------------------------------------------------
        If Me.cmbConceptoPago.Value = "DC" Then
            Me.ebImporteTotal.Value = ebTotalPagoCliente.Value

        Else
            '--Actualizamos cambio
            ActualizaCambioCliente()
            '--
            If ebTotalPagoCliente.Value >= ebImporteTotal.Value Then
                MsgBox("El Importe Total ha sido cubierto. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Forma de Pago")
                Me.EBPago.Enabled = False
                Me.cmbFormaPago.Enabled = False

                If cmbFormaPago.Value = "TACR" OrElse cmbFormaPago.Value = "TADB" Then
                    If MessageBox.Show("Se realizará el pago" & vbCrLf & "¿Deseas continuar?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        RealizarPago()
                    End If
                End If
            End If
        End If

        LimpiaCamposFormaPago()

        cmbFormaPago.Focus()

    End Sub

    Private Sub btnRealizarPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRealizarPago.Click
        RealizarPago()
    End Sub

    Private Sub frmOtrosPagos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        bExit = True
    End Sub

    Private Sub ebNumOrden_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumOrden.Validating
        If Not bExit And oConfigCierreFI.VentaAsistida = False Then
            'Me.lblValidaOrden.Visible = True
            'Application.DoEvents()
            'Try
            'ValidaNumOrden()
            'Catch ex As Exception
            'EscribeLog(ex.ToString, "Error al validar el numero de orden")
            'Finally
            'Me.lblValidaOrden.Visible = False
            'Application.DoEvents()
            'End Try
            ValidaNumOrdenRest()
        End If
    End Sub

    Private Sub ebNumDPCard_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumDPCard.Validating
        '--------------------------------------------------------------
        'JNAVA (12.03.2015): Especificamos que fue deslizada
        '--------------------------------------------------------------
        deslizada = False

        '--------------------------------------------------------------
        'JNAVA (21.01.2015): Agregamos la validacion de DP Card 
        '--------------------------------------------------------------
        ValidaDPCard()
    End Sub

    Private Sub btnLeerDPCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerDPCard.Click

        '--------------------------------------------------------------
        'JNAVA (21.01.2015): Leectura de datos de tarjeta DP CArd
        '--------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 20/02/2017: Se valida si son pagos banamex para lecturarlos por su pinpad si no la de Bancomer
            '--------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.PagosBanamex = True Then
                Dim pinpad As New Pinpad.Pinpad()
                Dim bin As String = ""
                'Dim code As String = pinpad.LeerTarjeta("1.00".Replace(",", ""), "0.00", "0", "00")
                Dim code As String = pinpad.LeerTarjeta("1.00".Replace(",", ""), "0.00", "0", "00")
                If ListaErroresBanamex.Contains(code.Trim()) = False Then
                    Dim Name As String = pinpad.getAppLabel()
                    bin = pinpad.getCardNumber(code)
                    deslizada = True
                    Me.ebClienteDPC.Text = Name
                    Me.ebNumDPCard.Text = bin
                    '----------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 20/02/2017: Enviamos mensaje de transacción exitosa a la pinpad
                    '----------------------------------------------------------------------------------------------------------------
                    pinpad.Respuesta("0", "", "")
                    pinpad.ClosePort()
                    pinpad.sp.Dispose()
                    '--------------------------------------------------------------
                    'JNAVA (21.01.2015): Agregamos la validacion de DP Card 
                    '--------------------------------------------------------------
                    ValidaDPCard()
                Else
                    MessageBox.Show("Hubo un error al lecturar la tarjeta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '----------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 20/02/2017: Enviamos mensaje de transacción exitosa a la pinpad
                    '----------------------------------------------------------------------------------------------------------------
                    If code.Trim() = "10" Or code.Trim() = "40" Then
                        pinpad.Respuesta("0", "", "")
                    End If
                    pinpad.ClosePort()
                    pinpad.sp.Dispose()
                End If
            Else
                Dim oOtrosPagos As New OtrosPagos
                If oOtrosPagos.LeerDatosDPCard(Me.ebNumDPCard.Text, Me.ebClienteDPC.Text) Then
                    '--------------------------------------------------------------
                    'JNAVA (12.03.2015): Especificamos que fue deslizada
                    '--------------------------------------------------------------
                    deslizada = True

                    '--------------------------------------------------------------
                    'JNAVA (21.01.2015): Agregamos la validacion de DP Card 
                    '--------------------------------------------------------------
                    ValidaDPCard()

                End If
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo leer la Tarjeta DP Card. Surgio un error", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "No se pudo leer la Tarjeta DP Card")
        End Try

    End Sub

    Private Sub ebImporteTotal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebImporteTotal.Validating
        ''--------------------------------------------------------------------------------------------------------------------------
        ''JNAVA (09.03.2015): Agregamos la validacion de pago maximo DPCard
        ''--------------------------------------------------------------------------------------------------------------------------
        'If Me.ebImporteTotal.Value > Me.ebSaldoDPC.Value Then
        '    MessageBox.Show("El pago no puede exceder el Saldo Actual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Me.ebImporteTotal.Focus()
        'Else
        '--------------------------------------------------------------------
        ' Mostramos los campos para la seleccion del pago y las formas de pago
        '--------------------------------------------------------------------
        Me.cmbFormaPago.Enabled = True
        Me.btnRealizarPago.Enabled = True
        Me.EBPago.Enabled = True
        Me.cmbFormaPago.Focus()
        'End If
    End Sub

    Private Sub ebNumDPCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumDPCard.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                '--------------------------------------------------------------
                'JNAVA (12.03.2015): Especificamos que no fue deslizada
                '--------------------------------------------------------------
                deslizada = False

                ValidaDPCard()
            Catch ex As Exception
                MessageBox.Show("No se pudo leer la Tarjeta DP Card. Surgio un error", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                EscribeLog(ex.ToString, "No se pudo leer la Tarjeta DP Card")
            End Try

        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/05/2017: Validar que solo sean números
    '--------------------------------------------------------------------------------------------------------------------------

    Private Sub ebNumDPCard_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ebNumDPCard.KeyPress
        ValidarNumeros(e)
    End Sub

#End Region

#Region "Venta Asistida"
    Private Sub LoadVentaAsistida()
        Dim dtPagosEcommerce As DataTable
        Dim pagoMgr As New CatalogoFormasPagoManager(oAppContext)
        dtPagosEcommerce = pagoMgr.GetTiposPagosEcommerce()
        cmbTipoPago.DataSource = dtPagosEcommerce
        cmbTipoPago.DisplayMember = "PagoEcommerce"
        cmbTipoPago.ValueMember = "PagoEcommerce"

    End Sub
#End Region

#Region "Carga de Tipo de pago Ecommerce"
    Private Sub LoadTipoPagoEcomm()
        Dim dtPagosEcommerce As DataTable
        Dim pagoMgr As New CatalogoFormasPagoManager(oAppContext, oConfigCierreFI)
        dtPagosEcommerce = pagoMgr.GetTiposPagosEcommerceByAlmacen()
        'cmbTipoPago.DataSource = dtPagosEcommerce

        With Me.cmbTipoPago

            .DropDownList.ClearStructure()

            .DataSource = dtPagosEcommerce
            .DropDownList.Columns.Add("TiposPagosEcommId")
            .DropDownList.Columns.Add("Descripcion")
            .DropDownList.Columns("TiposPagosEcommId").DataMember = "TiposPagosEcommId"
            .DropDownList.Columns("Descripcion").DataMember = "Descripcion"
            .DropDownList.Columns("TiposPagosEcommId").Visible = False

            .DisplayMember = "Descripcion"
            .ValueMember = "TiposPagosEcommId"

            .DropDownList.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False

            .Refresh()

            .Focus()
        End With
    End Sub
#End Region

#Region "Pagos Banamex"

    Private Function ValidarPagoBanamex(ByRef mensaje As String) As Boolean
        Dim valido As Boolean = True
        If cmbPromocion.Value Is Nothing Then
            valido = False
            mensaje = "No has elegido la promoción"
        ElseIf CStr(cmbPromocion.Value).Trim() = "" Then
            valido = False
            mensaje = "No has elegido la promoción"
        ElseIf EBPago.Value Is Nothing AndAlso CDec(EBPago.Value) > 0 Then
            valido = False
            mensaje = "No has capturado el monto a pagar"
        End If
        Return valido
    End Function

    Private Function AddFormaPagoBanamex() As Boolean
        Dim valido As Boolean = False
        Dim mensaje As String = ""
        If ValidarPagoBanamex(mensaje) = True Then
            Dim pay As New uPaydll.upaydll()
            Dim response As String = pay.ventas(oConfigCierreFI.UserBanamex, oConfigCierreFI.PasswordBanamex, CDec(EBPago.Value), CInt(cmbPromocion.Value), 0, 0)
            If response.Trim() <> "" Then
                Dim lstResponse As Dictionary(Of String, Object) = GetResponse(response)
                '--------------------------------------------------------------------------------
                'FLIZARRAGA 18/01/2017: Se valida si paso la tarjeta
                '--------------------------------------------------------------------------------
                If CInt(lstResponse("trn_internal_respcode")) = -1 Then
                    ebAutorizacion.Text = CStr(lstResponse("trn_auth_code"))
                    valido = True
                    Me.intPromo = CInt(cmbPromocion.Value)
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
        Else
            MessageBox.Show(mensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

#Region "Reduccion de Facturación"

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

    Private Sub ebNumOrden_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ebNumOrden.KeyDown
        ''If (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab) And oConfigCierreFI.VentaAsistida = False Then
        'ValidaNumOrdenRest()
        'End If
    End Sub


End Class
