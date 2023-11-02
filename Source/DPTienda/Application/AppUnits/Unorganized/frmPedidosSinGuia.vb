Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports System.IO
Imports System.Net
Imports System.Collections.Generic

Public Class frmPedidosSinGuia
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal strModulo As String = "", Optional row As DataRow = Nothing, Optional ByVal row_cab As DataRow = Nothing, Optional ByVal View_det As DataView = Nothing)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Modulo = strModulo
        Me.row_pedido = row
        Me.row_cab = row_cab
        Me.view_Det = View_det
        Inicializar()
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
    Friend WithEvents grdPedidosEC As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnActualizar As Janus.Windows.EditControls.UIButton
    Friend WithEvents uICommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuRangos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRangos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents expPPal As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents expAsignaGuia As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents expRangos As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnGuardarRango As Janus.Windows.EditControls.UIButton
    Friend WithEvents nenGuiaFinal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nebGuiaInicial As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents cmbPaqueteriaRango As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbPaqueteriasGuia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebRFC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ebTel As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ebCP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ebEstado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ebCiudad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ebDomicilio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ebNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebGuia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chkLocal As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ebPedido As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFolioSAP As System.Windows.Forms.Label
    Friend WithEvents ebFolioSAP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents nebNumBultos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents menuRevisarFoliosPickUp As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRevisarFoliosPickUp1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents expReportePickUp As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents grdFoliosPickUp As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnSalirReporte As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbPaqueteriasPickUp As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents menuDescargarGuia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuDescargarGuia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents lblDportenis As System.Windows.Forms.Label
    Friend WithEvents lblDPStreet As System.Windows.Forms.Label
    Friend WithEvents grdDPStreet As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup4 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidosSinGuia))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup5 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout5 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout6 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.expPPal = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.expAsignaGuia = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.expRangos = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnGuardarRango = New Janus.Windows.EditControls.UIButton()
        Me.nenGuiaFinal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nebGuiaInicial = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.cmbPaqueteriaRango = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nebNumBultos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.ebFolioSAP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblFolioSAP = New System.Windows.Forms.Label()
        Me.ebPedido = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkLocal = New Janus.Windows.EditControls.UICheckBox()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebRFC = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ebTel = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ebCP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ebEstado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ebCiudad = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ebDomicilio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ebNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ebGuia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbPaqueteriasGuia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnActualizar = New Janus.Windows.EditControls.UIButton()
        Me.grdDPStreet = New Janus.Windows.GridEX.GridEX()
        Me.lblDPStreet = New System.Windows.Forms.Label()
        Me.grdPedidosEC = New Janus.Windows.GridEX.GridEX()
        Me.lblDportenis = New System.Windows.Forms.Label()
        Me.uICommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuRangos1 = New Janus.Windows.UI.CommandBars.UICommand("menuRangos")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuRevisarFoliosPickUp1 = New Janus.Windows.UI.CommandBars.UICommand("menuRevisarFoliosPickUp")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuDescargarGuia1 = New Janus.Windows.UI.CommandBars.UICommand("menuDescargarGuia")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuRangos = New Janus.Windows.UI.CommandBars.UICommand("menuRangos")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuRevisarFoliosPickUp = New Janus.Windows.UI.CommandBars.UICommand("menuRevisarFoliosPickUp")
        Me.menuDescargarGuia = New Janus.Windows.UI.CommandBars.UICommand("menuDescargarGuia")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.expReportePickUp = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.grdFoliosPickUp = New Janus.Windows.GridEX.GridEX()
        Me.btnSalirReporte = New Janus.Windows.EditControls.UIButton()
        Me.cmbPaqueteriasPickUp = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.expPPal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expPPal.SuspendLayout()
        CType(Me.expAsignaGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expAsignaGuia.SuspendLayout()
        CType(Me.expRangos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expRangos.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grdDPStreet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPedidosEC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uICommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.expReportePickUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expReportePickUp.SuspendLayout()
        CType(Me.grdFoliosPickUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'expPPal
        '
        Me.expPPal.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.expPPal.Controls.Add(Me.expAsignaGuia)
        Me.expPPal.Controls.Add(Me.btnActualizar)
        Me.expPPal.Controls.Add(Me.grdDPStreet)
        Me.expPPal.Controls.Add(Me.lblDPStreet)
        Me.expPPal.Controls.Add(Me.grdPedidosEC)
        Me.expPPal.Controls.Add(Me.lblDportenis)
        Me.expPPal.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup4.Expandable = False
        ExplorerBarGroup4.Key = "Group1"
        ExplorerBarGroup4.Text = "Pedidos Pendientes"
        ExplorerBarGroup4.Visible = False
        Me.expPPal.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup4})
        Me.expPPal.Location = New System.Drawing.Point(0, 28)
        Me.expPPal.Name = "expPPal"
        Me.expPPal.Size = New System.Drawing.Size(550, 444)
        Me.expPPal.TabIndex = 0
        Me.expPPal.Text = "ExplorerBar1"
        Me.expPPal.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'expAsignaGuia
        '
        Me.expAsignaGuia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.expAsignaGuia.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.expAsignaGuia.Controls.Add(Me.expRangos)
        Me.expAsignaGuia.Controls.Add(Me.nebNumBultos)
        Me.expAsignaGuia.Controls.Add(Me.lblLabel4)
        Me.expAsignaGuia.Controls.Add(Me.ebFolioSAP)
        Me.expAsignaGuia.Controls.Add(Me.lblFolioSAP)
        Me.expAsignaGuia.Controls.Add(Me.ebPedido)
        Me.expAsignaGuia.Controls.Add(Me.Label3)
        Me.expAsignaGuia.Controls.Add(Me.chkLocal)
        Me.expAsignaGuia.Controls.Add(Me.btnImprimir)
        Me.expAsignaGuia.Controls.Add(Me.ExplorerBar1)
        Me.expAsignaGuia.Controls.Add(Me.ebGuia)
        Me.expAsignaGuia.Controls.Add(Me.Label10)
        Me.expAsignaGuia.Controls.Add(Me.cmbPaqueteriasGuia)
        Me.expAsignaGuia.Controls.Add(Me.Label2)
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Asignación de Guía"
        Me.expAsignaGuia.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.expAsignaGuia.Location = New System.Drawing.Point(5, 0)
        Me.expAsignaGuia.Name = "expAsignaGuia"
        Me.expAsignaGuia.Size = New System.Drawing.Size(542, 467)
        Me.expAsignaGuia.TabIndex = 9
        Me.expAsignaGuia.Text = "ExplorerBar2"
        Me.expAsignaGuia.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'expRangos
        '
        Me.expRangos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.expRangos.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.Flat
        Me.expRangos.Controls.Add(Me.btnSalir)
        Me.expRangos.Controls.Add(Me.btnGuardarRango)
        Me.expRangos.Controls.Add(Me.nenGuiaFinal)
        Me.expRangos.Controls.Add(Me.Label1)
        Me.expRangos.Controls.Add(Me.nebGuiaInicial)
        Me.expRangos.Controls.Add(Me.lblLabel1)
        Me.expRangos.Controls.Add(Me.cmbPaqueteriaRango)
        Me.expRangos.Controls.Add(Me.Label6)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Asignar Rangos de Guías"
        Me.expRangos.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.expRangos.Location = New System.Drawing.Point(120, 35)
        Me.expRangos.Name = "expRangos"
        Me.expRangos.Size = New System.Drawing.Size(352, 174)
        Me.expRangos.TabIndex = 12
        Me.expRangos.Text = "ExplorerBar2"
        Me.expRangos.Visible = False
        Me.expRangos.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Icon = CType(resources.GetObject("btnSalir.Icon"), System.Drawing.Icon)
        Me.btnSalir.Location = New System.Drawing.Point(208, 123)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(128, 40)
        Me.btnSalir.TabIndex = 54
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnGuardarRango
        '
        Me.btnGuardarRango.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarRango.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarRango.Icon = CType(resources.GetObject("btnGuardarRango.Icon"), System.Drawing.Icon)
        Me.btnGuardarRango.Location = New System.Drawing.Point(8, 123)
        Me.btnGuardarRango.Name = "btnGuardarRango"
        Me.btnGuardarRango.Size = New System.Drawing.Size(128, 40)
        Me.btnGuardarRango.TabIndex = 53
        Me.btnGuardarRango.Text = "Guardar"
        Me.btnGuardarRango.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'nenGuiaFinal
        '
        Me.nenGuiaFinal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nenGuiaFinal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nenGuiaFinal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nenGuiaFinal.FormatString = "0000000000"
        Me.nenGuiaFinal.Location = New System.Drawing.Point(248, 88)
        Me.nenGuiaFinal.MaxLength = 30
        Me.nenGuiaFinal.Name = "nenGuiaFinal"
        Me.nenGuiaFinal.Size = New System.Drawing.Size(88, 22)
        Me.nenGuiaFinal.TabIndex = 52
        Me.nenGuiaFinal.Text = "0000000000"
        Me.nenGuiaFinal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nenGuiaFinal.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nenGuiaFinal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(200, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Final"
        '
        'nebGuiaInicial
        '
        Me.nebGuiaInicial.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebGuiaInicial.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebGuiaInicial.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebGuiaInicial.FormatString = "0000000000"
        Me.nebGuiaInicial.Location = New System.Drawing.Point(80, 88)
        Me.nebGuiaInicial.MaxLength = 30
        Me.nebGuiaInicial.Name = "nebGuiaInicial"
        Me.nebGuiaInicial.Size = New System.Drawing.Size(88, 22)
        Me.nebGuiaInicial.TabIndex = 51
        Me.nebGuiaInicial.Text = "0000000000"
        Me.nebGuiaInicial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebGuiaInicial.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebGuiaInicial.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(8, 88)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(87, 15)
        Me.lblLabel1.TabIndex = 11
        Me.lblLabel1.Text = "Inicial"
        '
        'cmbPaqueteriaRango
        '
        Me.cmbPaqueteriaRango.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbPaqueteriaRango.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbPaqueteriaRango.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbPaqueteriaRango.DesignTimeLayout = GridEXLayout1
        Me.cmbPaqueteriaRango.Location = New System.Drawing.Point(80, 56)
        Me.cmbPaqueteriaRango.Name = "cmbPaqueteriaRango"
        Me.cmbPaqueteriaRango.Size = New System.Drawing.Size(256, 20)
        Me.cmbPaqueteriaRango.TabIndex = 50
        Me.cmbPaqueteriaRango.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbPaqueteriaRango.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Paqueteria"
        '
        'nebNumBultos
        '
        Me.nebNumBultos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebNumBultos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebNumBultos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebNumBultos.Location = New System.Drawing.Point(88, 104)
        Me.nebNumBultos.MaxLength = 3
        Me.nebNumBultos.Name = "nebNumBultos"
        Me.nebNumBultos.Size = New System.Drawing.Size(48, 22)
        Me.nebNumBultos.TabIndex = 80
        Me.nebNumBultos.Text = "0"
        Me.nebNumBultos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebNumBultos.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebNumBultos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.Location = New System.Drawing.Point(8, 104)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(87, 15)
        Me.lblLabel4.TabIndex = 79
        Me.lblLabel4.Text = "Bultos"
        '
        'ebFolioSAP
        '
        Me.ebFolioSAP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioSAP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioSAP.BackColor = System.Drawing.SystemColors.Info
        Me.ebFolioSAP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioSAP.Location = New System.Drawing.Point(400, 72)
        Me.ebFolioSAP.Name = "ebFolioSAP"
        Me.ebFolioSAP.ReadOnly = True
        Me.ebFolioSAP.Size = New System.Drawing.Size(128, 22)
        Me.ebFolioSAP.TabIndex = 78
        Me.ebFolioSAP.TabStop = False
        Me.ebFolioSAP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolioSAP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFolioSAP
        '
        Me.lblFolioSAP.BackColor = System.Drawing.Color.Transparent
        Me.lblFolioSAP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioSAP.Location = New System.Drawing.Point(328, 72)
        Me.lblFolioSAP.Name = "lblFolioSAP"
        Me.lblFolioSAP.Size = New System.Drawing.Size(87, 15)
        Me.lblFolioSAP.TabIndex = 77
        Me.lblFolioSAP.Text = "Traspaso"
        '
        'ebPedido
        '
        Me.ebPedido.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPedido.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPedido.BackColor = System.Drawing.SystemColors.Info
        Me.ebPedido.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPedido.Location = New System.Drawing.Point(400, 40)
        Me.ebPedido.Name = "ebPedido"
        Me.ebPedido.ReadOnly = True
        Me.ebPedido.Size = New System.Drawing.Size(128, 22)
        Me.ebPedido.TabIndex = 76
        Me.ebPedido.TabStop = False
        Me.ebPedido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPedido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(328, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Pedido"
        '
        'chkLocal
        '
        Me.chkLocal.BackColor = System.Drawing.Color.Transparent
        Me.chkLocal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLocal.Location = New System.Drawing.Point(240, 72)
        Me.chkLocal.Name = "chkLocal"
        Me.chkLocal.Size = New System.Drawing.Size(64, 24)
        Me.chkLocal.TabIndex = 72
        Me.chkLocal.Text = "Local"
        Me.chkLocal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageSize = New System.Drawing.Size(25, 25)
        Me.btnImprimir.Location = New System.Drawing.Point(0, 393)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(232, 40)
        Me.btnImprimir.TabIndex = 71
        Me.btnImprimir.Text = "Guardar/Imprimir Guía"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ebRFC)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.ebTel)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.ebCP)
        Me.ExplorerBar1.Controls.Add(Me.Label14)
        Me.ExplorerBar1.Controls.Add(Me.ebEstado)
        Me.ExplorerBar1.Controls.Add(Me.Label15)
        Me.ExplorerBar1.Controls.Add(Me.ebCiudad)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.ebDomicilio)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.ebNombre)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Datos de Envío"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 122)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(685, 268)
        Me.ExplorerBar1.TabIndex = 69
        Me.ExplorerBar1.Text = "ExplorerBar2"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebRFC
        '
        Me.ebRFC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebRFC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebRFC.BackColor = System.Drawing.SystemColors.Info
        Me.ebRFC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebRFC.Location = New System.Drawing.Point(88, 232)
        Me.ebRFC.Name = "ebRFC"
        Me.ebRFC.ReadOnly = True
        Me.ebRFC.Size = New System.Drawing.Size(128, 22)
        Me.ebRFC.TabIndex = 66
        Me.ebRFC.TabStop = False
        Me.ebRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRFC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 232)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 15)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "RFC"
        '
        'ebTel
        '
        Me.ebTel.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTel.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTel.BackColor = System.Drawing.SystemColors.Info
        Me.ebTel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTel.Location = New System.Drawing.Point(88, 200)
        Me.ebTel.Name = "ebTel"
        Me.ebTel.ReadOnly = True
        Me.ebTel.Size = New System.Drawing.Size(128, 22)
        Me.ebTel.TabIndex = 64
        Me.ebTel.TabStop = False
        Me.ebTel.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTel.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 200)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 15)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "Telefono"
        '
        'ebCP
        '
        Me.ebCP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCP.BackColor = System.Drawing.SystemColors.Info
        Me.ebCP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCP.Location = New System.Drawing.Point(88, 168)
        Me.ebCP.Name = "ebCP"
        Me.ebCP.ReadOnly = True
        Me.ebCP.Size = New System.Drawing.Size(128, 22)
        Me.ebCP.TabIndex = 62
        Me.ebCP.TabStop = False
        Me.ebCP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 168)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 15)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "CP"
        '
        'ebEstado
        '
        Me.ebEstado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEstado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEstado.BackColor = System.Drawing.SystemColors.Info
        Me.ebEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEstado.Location = New System.Drawing.Point(88, 136)
        Me.ebEstado.Name = "ebEstado"
        Me.ebEstado.ReadOnly = True
        Me.ebEstado.Size = New System.Drawing.Size(128, 22)
        Me.ebEstado.TabIndex = 60
        Me.ebEstado.TabStop = False
        Me.ebEstado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 136)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 15)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Estado"
        '
        'ebCiudad
        '
        Me.ebCiudad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCiudad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCiudad.BackColor = System.Drawing.SystemColors.Info
        Me.ebCiudad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCiudad.Location = New System.Drawing.Point(88, 104)
        Me.ebCiudad.Name = "ebCiudad"
        Me.ebCiudad.ReadOnly = True
        Me.ebCiudad.Size = New System.Drawing.Size(128, 22)
        Me.ebCiudad.TabIndex = 58
        Me.ebCiudad.TabStop = False
        Me.ebCiudad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCiudad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 15)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Ciudad"
        '
        'ebDomicilio
        '
        Me.ebDomicilio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.BackColor = System.Drawing.SystemColors.Info
        Me.ebDomicilio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDomicilio.Location = New System.Drawing.Point(88, 72)
        Me.ebDomicilio.Name = "ebDomicilio"
        Me.ebDomicilio.ReadOnly = True
        Me.ebDomicilio.Size = New System.Drawing.Size(432, 22)
        Me.ebDomicilio.TabIndex = 56
        Me.ebDomicilio.TabStop = False
        Me.ebDomicilio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDomicilio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 15)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Domicilio"
        '
        'ebNombre
        '
        Me.ebNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombre.BackColor = System.Drawing.SystemColors.Info
        Me.ebNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombre.Location = New System.Drawing.Point(88, 40)
        Me.ebNombre.Name = "ebNombre"
        Me.ebNombre.ReadOnly = True
        Me.ebNombre.Size = New System.Drawing.Size(264, 22)
        Me.ebNombre.TabIndex = 54
        Me.ebNombre.TabStop = False
        Me.ebNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(8, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 15)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "Nombre"
        '
        'ebGuia
        '
        Me.ebGuia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebGuia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebGuia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebGuia.Location = New System.Drawing.Point(88, 72)
        Me.ebGuia.MaxLength = 30
        Me.ebGuia.Name = "ebGuia"
        Me.ebGuia.Size = New System.Drawing.Size(128, 22)
        Me.ebGuia.TabIndex = 68
        Me.ebGuia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebGuia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 15)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "Guía"
        '
        'cmbPaqueteriasGuia
        '
        Me.cmbPaqueteriasGuia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbPaqueteriasGuia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbPaqueteriasGuia.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.cmbPaqueteriasGuia.DesignTimeLayout = GridEXLayout2
        Me.cmbPaqueteriasGuia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPaqueteriasGuia.Location = New System.Drawing.Point(88, 40)
        Me.cmbPaqueteriasGuia.Name = "cmbPaqueteriasGuia"
        Me.cmbPaqueteriasGuia.Size = New System.Drawing.Size(208, 22)
        Me.cmbPaqueteriasGuia.TabIndex = 52
        Me.cmbPaqueteriasGuia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbPaqueteriasGuia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 15)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Paqueteria"
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnActualizar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnActualizar.Location = New System.Drawing.Point(8, 396)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(232, 40)
        Me.btnActualizar.TabIndex = 4
        Me.btnActualizar.Text = "Buscar Pedidos Pendientes"
        Me.btnActualizar.Visible = False
        Me.btnActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdDPStreet
        '
        Me.grdDPStreet.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdDPStreet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.grdDPStreet.DesignTimeLayout = GridEXLayout3
        Me.grdDPStreet.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdDPStreet.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdDPStreet.GroupByBoxVisible = False
        Me.grdDPStreet.Location = New System.Drawing.Point(8, 232)
        Me.grdDPStreet.Name = "grdDPStreet"
        Me.grdDPStreet.Size = New System.Drawing.Size(232, 134)
        Me.grdDPStreet.TabIndex = 54
        Me.grdDPStreet.Visible = False
        Me.grdDPStreet.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblDPStreet
        '
        Me.lblDPStreet.AutoSize = True
        Me.lblDPStreet.BackColor = System.Drawing.Color.Transparent
        Me.lblDPStreet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDPStreet.Location = New System.Drawing.Point(80, 200)
        Me.lblDPStreet.Name = "lblDPStreet"
        Me.lblDPStreet.Size = New System.Drawing.Size(63, 14)
        Me.lblDPStreet.TabIndex = 53
        Me.lblDPStreet.Text = "DPStreet"
        Me.lblDPStreet.Visible = False
        '
        'grdPedidosEC
        '
        Me.grdPedidosEC.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdPedidosEC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.grdPedidosEC.DesignTimeLayout = GridEXLayout4
        Me.grdPedidosEC.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdPedidosEC.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdPedidosEC.GroupByBoxVisible = False
        Me.grdPedidosEC.Location = New System.Drawing.Point(8, 56)
        Me.grdPedidosEC.Name = "grdPedidosEC"
        Me.grdPedidosEC.Size = New System.Drawing.Size(232, 134)
        Me.grdPedidosEC.TabIndex = 3
        Me.grdPedidosEC.Visible = False
        Me.grdPedidosEC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblDportenis
        '
        Me.lblDportenis.AutoSize = True
        Me.lblDportenis.BackColor = System.Drawing.Color.Transparent
        Me.lblDportenis.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDportenis.Location = New System.Drawing.Point(80, 32)
        Me.lblDportenis.Name = "lblDportenis"
        Me.lblDportenis.Size = New System.Drawing.Size(67, 14)
        Me.lblDportenis.TabIndex = 52
        Me.lblDportenis.Text = "Dportenis"
        Me.lblDportenis.Visible = False
        '
        'uICommandManager1
        '
        Me.uICommandManager1.BottomRebar = Me.BottomRebar1
        Me.uICommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.uICommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuRangos, Me.menuSalir, Me.menuRevisarFoliosPickUp, Me.menuDescargarGuia})
        Me.uICommandManager1.ContainerControl = Me
        '
        '
        '
        Me.uICommandManager1.EditContextMenu.Key = ""
        Me.uICommandManager1.Id = New System.Guid("7316321d-f7c2-4a47-9a5d-838cb765dc2f")
        Me.uICommandManager1.LeftRebar = Me.LeftRebar1
        Me.uICommandManager1.RightRebar = Me.RightRebar1
        Me.uICommandManager1.TopRebar = Me.TopRebar1
        Me.uICommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.uICommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.uICommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuRangos1, Me.Separator1, Me.menuRevisarFoliosPickUp1, Me.Separator2, Me.menuDescargarGuia1, Me.Separator3, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(538, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuRangos1
        '
        Me.menuRangos1.Key = "menuRangos"
        Me.menuRangos1.Name = "menuRangos1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuRevisarFoliosPickUp1
        '
        Me.menuRevisarFoliosPickUp1.Key = "menuRevisarFoliosPickUp"
        Me.menuRevisarFoliosPickUp1.Name = "menuRevisarFoliosPickUp1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuDescargarGuia1
        '
        Me.menuDescargarGuia1.Icon = CType(resources.GetObject("menuDescargarGuia1.Icon"), System.Drawing.Icon)
        Me.menuDescargarGuia1.Key = "menuDescargarGuia"
        Me.menuDescargarGuia1.Name = "menuDescargarGuia1"
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
        'menuRangos
        '
        Me.menuRangos.Icon = CType(resources.GetObject("menuRangos.Icon"), System.Drawing.Icon)
        Me.menuRangos.Key = "menuRangos"
        Me.menuRangos.Name = "menuRangos"
        Me.menuRangos.Text = "Agregar Rango de Guías"
        '
        'menuSalir
        '
        Me.menuSalir.Icon = CType(resources.GetObject("menuSalir.Icon"), System.Drawing.Icon)
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
        '
        'menuRevisarFoliosPickUp
        '
        Me.menuRevisarFoliosPickUp.Image = CType(resources.GetObject("menuRevisarFoliosPickUp.Image"), System.Drawing.Image)
        Me.menuRevisarFoliosPickUp.Key = "menuRevisarFoliosPickUp"
        Me.menuRevisarFoliosPickUp.Name = "menuRevisarFoliosPickUp"
        Me.menuRevisarFoliosPickUp.Text = "Revisar Folios de Recolección"
        '
        'menuDescargarGuia
        '
        Me.menuDescargarGuia.Key = "menuDescargarGuia"
        Me.menuDescargarGuia.Name = "menuDescargarGuia"
        Me.menuDescargarGuia.Text = "Descargar Guia DHL"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.uICommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.uICommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.uICommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(550, 28)
        '
        'expReportePickUp
        '
        Me.expReportePickUp.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.Flat
        Me.expReportePickUp.Controls.Add(Me.btnExportar)
        Me.expReportePickUp.Controls.Add(Me.grdFoliosPickUp)
        Me.expReportePickUp.Controls.Add(Me.btnSalirReporte)
        Me.expReportePickUp.Controls.Add(Me.cmbPaqueteriasPickUp)
        Me.expReportePickUp.Controls.Add(Me.Label7)
        ExplorerBarGroup5.Expandable = False
        ExplorerBarGroup5.Key = "Group1"
        ExplorerBarGroup5.Text = "Reporte de Recolección"
        Me.expReportePickUp.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup5})
        Me.expReportePickUp.Location = New System.Drawing.Point(480, 464)
        Me.expReportePickUp.Name = "expReportePickUp"
        Me.expReportePickUp.Size = New System.Drawing.Size(368, 472)
        Me.expReportePickUp.TabIndex = 71
        Me.expReportePickUp.Text = "ExplorerBar2"
        Me.expReportePickUp.Visible = False
        Me.expReportePickUp.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Icon = CType(resources.GetObject("btnExportar.Icon"), System.Drawing.Icon)
        Me.btnExportar.Location = New System.Drawing.Point(8, 408)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(168, 32)
        Me.btnExportar.TabIndex = 56
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'grdFoliosPickUp
        '
        Me.grdFoliosPickUp.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdFoliosPickUp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        GridEXLayout5.LayoutString = resources.GetString("GridEXLayout5.LayoutString")
        Me.grdFoliosPickUp.DesignTimeLayout = GridEXLayout5
        Me.grdFoliosPickUp.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdFoliosPickUp.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdFoliosPickUp.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdFoliosPickUp.GroupByBoxVisible = False
        Me.grdFoliosPickUp.Location = New System.Drawing.Point(8, 72)
        Me.grdFoliosPickUp.Name = "grdFoliosPickUp"
        Me.grdFoliosPickUp.Size = New System.Drawing.Size(352, 320)
        Me.grdFoliosPickUp.TabIndex = 55
        Me.grdFoliosPickUp.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnSalirReporte
        '
        Me.btnSalirReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSalirReporte.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalirReporte.Icon = CType(resources.GetObject("btnSalirReporte.Icon"), System.Drawing.Icon)
        Me.btnSalirReporte.Location = New System.Drawing.Point(192, 408)
        Me.btnSalirReporte.Name = "btnSalirReporte"
        Me.btnSalirReporte.Size = New System.Drawing.Size(168, 32)
        Me.btnSalirReporte.TabIndex = 54
        Me.btnSalirReporte.Text = "Cerrar"
        Me.btnSalirReporte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'cmbPaqueteriasPickUp
        '
        Me.cmbPaqueteriasPickUp.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbPaqueteriasPickUp.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbPaqueteriasPickUp.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout6.LayoutString = resources.GetString("GridEXLayout6.LayoutString")
        Me.cmbPaqueteriasPickUp.DesignTimeLayout = GridEXLayout6
        Me.cmbPaqueteriasPickUp.Location = New System.Drawing.Point(80, 40)
        Me.cmbPaqueteriasPickUp.Name = "cmbPaqueteriasPickUp"
        Me.cmbPaqueteriasPickUp.Size = New System.Drawing.Size(280, 20)
        Me.cmbPaqueteriasPickUp.TabIndex = 50
        Me.cmbPaqueteriasPickUp.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbPaqueteriasPickUp.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Paqueteria"
        '
        'frmPedidosSinGuia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(550, 472)
        Me.Controls.Add(Me.expReportePickUp)
        Me.Controls.Add(Me.expPPal)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPedidosSinGuia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos Sin Guía"
        CType(Me.expPPal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expPPal.ResumeLayout(False)
        Me.expPPal.PerformLayout()
        CType(Me.expAsignaGuia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expAsignaGuia.ResumeLayout(False)
        CType(Me.expRangos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expRangos.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.grdDPStreet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPedidosEC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uICommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.expReportePickUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expReportePickUp.ResumeLayout(False)
        CType(Me.grdFoliosPickUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dtPedidos As DataTable
    Dim oSapMgr As ProcesoSAPManager
    'Dim Centro As String = ""
    Dim oTSMgr As TraspasosSalidaManager
    Dim CentroDes As String = ""
    Dim dtPaqueterias As DataTable
    Dim dtRangos As DataTable
    Dim Modulo As String = ""
    Dim strCentroSAP As String = ""
    Dim dtCabeceraSH As DataTable
    Dim UserNameAplicated As String = ""
    Private dtPedidosDPortenis As DataTable
    Private dtPedidosDPStreet As DataTable
    Private Entrega As String = ""
    Private row_pedido As DataRow
    Private row_cab As DataRow
    Private view_Det As DataView
    Public Info_Guia As Hashtable

    Private Sub Inicializar()

        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        oTSMgr = New TraspasosSalidaManager(oAppContext, oConfigCierreFI)

        strCentroSAP = oSapMgr.Read_Centros

        If Modulo.Trim() = "" Then
            If oConfigCierreFI.AplicarSurtidoDPStreet = True Then
                lblDportenis.Visible = True
                lblDPStreet.Visible = True
                grdDPStreet.Visible = True
            Else
                grdPedidosEC.Size = New Size(232, 358)
                grdPedidosEC.Location = New Point(8, 32)
                lblDportenis.Visible = False
                lblDPStreet.Visible = False
                grdDPStreet.Visible = False
            End If
        Else
            grdPedidosEC.Size = New Size(232, 358)
            grdPedidosEC.Location = New Point(8, 32)
            lblDportenis.Visible = False
            lblDPStreet.Visible = False
            grdDPStreet.Visible = False
        End If

        'ObtenerPedidosPendientes()

        FillPaqueterias()
        MostrarDetalleEcommerce(Nothing)
    End Sub

    Private Sub FillPaqueterias()

        dtPaqueterias = oSapMgr.ZPAQUETERIAS_RETR

        With Me.cmbPaqueteriaRango
            .Clear()
            .DropDownList.Columns.Add("Descripción")
            .DataSource = dtPaqueterias
            '.DropDownList.Columns("Cod.").Width = 50
            .DropDownList.Columns("Descripción").DataMember = "Paqueteria"
            .DropDownList.Columns("Descripción").Width = 200
            .DisplayMember = "Paqueteria"
            .ValueMember = "Paqueteria"


            .Refresh()
        End With

        With Me.cmbPaqueteriasPickUp
            .Clear()
            .DropDownList.Columns.Add("Descripción")
            .DataSource = dtPaqueterias
            '.DropDownList.Columns("Cod.").Width = 50
            .DropDownList.Columns("Descripción").DataMember = "Paqueteria"
            .DropDownList.Columns("Descripción").Width = 200
            .DisplayMember = "Paqueteria"
            .ValueMember = "Paqueteria"


            .Refresh()
        End With

        With Me.cmbPaqueteriasGuia
            .Clear()
            .DropDownList.Columns.Add("Imprimir")
            .DropDownList.Columns.Add("Default")
            .DropDownList.Columns.Add("Descripción")
            .DataSource = dtPaqueterias
            .DropDownList.Columns("Imprimir").DataMember = "Imprimir"
            .DropDownList.Columns("Default").DataMember = "DEFAULT_FACTURA"
            '.DropDownList.Columns("Cod.").Width = 50
            .DropDownList.Columns("Descripción").DataMember = "Paqueteria"
            .DropDownList.Columns("Descripción").Width = 200
            .DisplayMember = "Paqueteria"
            .ValueMember = "Paqueteria"
            .DropDownList.Columns("Imprimir").Visible = False
            .DropDownList.Columns("Default").Visible = False

            .Refresh()
        End With

    End Sub

    Private Sub MostrarDetalle()
        Dim pedido As String = CStr(row_pedido("Folio_Pedido")).Trim().PadLeft(10, "0")
        'Dim Pedido As String = CStr(Me.grdPedidosEC.GetValue("Pedido")).Trim.PadLeft(10, "0")

        If Me.ebPedido.Text.Trim <> "" Then
            If Me.ebPedido.Text.Trim <> Pedido.Trim Then
                If Preguntar() = False Then Exit Sub
            Else
                Exit Sub
            End If
        End If

        Limpiar(True)

        Me.ebPedido.Text = pedido.Trim
        CentroDes = CStr(row_pedido("CEDES")).Trim()
        'CentroDes = CStr(Me.grdPedidosEC.GetRow.DataRow!PuestoExpedicion).Trim

        Dim dtDatosG As DataTable
        Dim dtDatosEnvio As DataTable
        Dim oRow As DataRow
        'RGERMAIN 03/05/2013: Ejecutamos la RFC segun el modulo de origen de acceso
        Select Case Modulo.Trim.ToUpper
            Case "PESH"
                '------------------------------------------------------------------
                ' JNAVA (29.12.2015): Adaptamos para ejecutar desde SAP Retail
                '------------------------------------------------------------------
                'Dim oRetail As New ProcesosRetail("/pos/ventas", "POST")
                dtDatosEnvio = oSapMgr.ZPOL_DATOS_ENVIO(Me.ebPedido.Text, dtDatosG)
                'dtDatosEnvio = oRetail.SapZpolDatosEnvio(Me.ebPedido.Text, oSapMgr.Read_Centros, dtDatosG)
                'dtDatosEnvio = oSapMgr.ZSH_DATOS_ENVIO(Me.ebPedido.Text, dtDatosG)
            Case Else
                '------------------------------------------------------------------
                ' JNAVA (29.12.2015): Adaptamos para ejecutar desde SAP Retail
                '------------------------------------------------------------------
                'Dim oRetail As New ProcesosRetail("/pos/ventas", "POST")
                dtDatosEnvio = oSapMgr.ZPOL_DATOS_ENVIO(Me.ebPedido.Text, dtDatosG)
                'dtDatosEnvio = oRetail.SapZpolDatosEnvio(Me.ebPedido.Text, oSapMgr.Read_Centros, dtDatosG)
                '------------------------------------------------------------------
        End Select

        If dtDatosEnvio.Rows.Count > 0 AndAlso dtDatosG.Rows.Count > 0 Then
            Dim oRowDE As DataRow = dtDatosEnvio.Rows(0), oRowDG As DataRow = dtDatosG.Rows(0)

            Me.expAsignaGuia.Enabled = True
            Me.btnActualizar.Enabled = False
            '----------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 03/05/2013: Si el tipo del pedido SH es C, es decir, envío para un cliente se cambia a tipo F para indicarle que es un
            'pedido facturado y funcione igual que el de EC y determinamos si es envio local o foraneo
            '----------------------------------------------------------------------------------------------------------------------------------
            If Modulo.Trim.ToUpper = "PESH" Then
                If oRowDG!Tipo = "C" Then oRowDG!Tipo = "F"
                If CStr(row_pedido("Status")).Trim() = "PE-F" Then
                    'If CStr(Me.grdPedidosEC.GetRow.DataRow!Status).Trim = "PE-F" Then
                    oRowDG!Local = "F"
                Else
                    oRowDG!Local = "L"
                End If
            End If

            If CStr(oRowDG!Tipo).Trim = "F" Then
                Me.lblFolioSAP.Text = "Factura"
                Me.ebFolioSAP.Text = CStr(oRowDG!FacturaSAP).Trim
                For Each oRow In dtPaqueterias.Rows
                    If CStr(oRow!Default_Factura).Trim = "X" Then
                        Me.cmbPaqueteriasGuia.Value = CStr(oRow!Paqueteria).Trim
                        Me.cmbPaqueteriasGuia.Enabled = False
                        Exit For
                    End If
                Next
            Else
                Me.lblFolioSAP.Text = "Traspaso"
                Select Case Modulo.Trim.ToUpper
                    Case "PESH"
                        Me.ebFolioSAP.Text = CStr(row_pedido("VBELN")).Trim()
                        'Me.ebFolioSAP.Text = CStr(Me.grdPedidosEC.GetValue("TrasladoSAP")).Trim
                    Case Else
                        Me.ebFolioSAP.Text = CStr(oRowDG!TrasladoSAP).Trim
                End Select
            End If
            Select Case CStr(oRowDG!Local).Trim.ToUpper
                Case "L"
                    Me.chkLocal.Checked = True
                    Me.chkLocal.Enabled = False
                    Me.cmbPaqueteriasGuia.Text = ""
                    Me.cmbPaqueteriasGuia.Enabled = False
                Case "F"
                    Me.chkLocal.Checked = False
                    Me.chkLocal.Enabled = False
                    If Me.cmbPaqueteriasGuia.Text.Trim = "" Then Me.cmbPaqueteriasGuia.Enabled = True
                    If oConfigCierreFI.GenerarGuiaDHLAutomatica AndAlso Me.cmbPaqueteriasGuia.Text.Trim.ToUpper = "DHL" Then
                        Me.ebGuia.ReadOnly = True
                    Else
                        Me.ebGuia.ReadOnly = False
                    End If
            End Select

            Me.ebNombre.Text = CStr(oRowDE!Nombre).Trim
            Me.ebDomicilio.Text = CStr(oRowDE!Domicilio).Trim
            Me.ebCiudad.Text = CStr(oRowDE!Ciudad).Trim
            Me.ebEstado.Text = CStr(oRowDE!Estado).Trim
            Me.ebCP.Text = CStr(oRowDE!CP).Trim
            Me.ebRFC.Text = CStr(oRowDE!RFC).Trim
            Me.ebTel.Text = CStr(oRowDE!Telefono).Trim
        End If

    End Sub

    Private Sub MostrarDetalleEcommerce(ByVal grid As Janus.Windows.GridEX.GridEX)
        Dim pedido As String = CStr(row_pedido("Folio_Pedido")).Trim().PadLeft(10, "0")
        'Dim Pedido As String = CStr(grid.GetValue("Pedido")).Trim.PadLeft(10, "0")

        If Me.ebPedido.Text.Trim <> "" Then
            If Me.ebPedido.Text.Trim <> Pedido.Trim Then
                If Preguntar() = False Then Exit Sub
            Else
                Exit Sub
            End If
        End If

        Limpiar(True)

        Me.ebPedido.Text = pedido.Trim
        CentroDes = CStr(row_pedido("CEDES")).Trim()
        'CentroDes = CStr(grid.GetRow.DataRow!PuestoExpedicion).Trim

        Dim dtDatosG As DataTable
        Dim dtDatosEnvio As DataTable
        Dim oRow As DataRow
        'RGERMAIN 03/05/2013: Ejecutamos la RFC segun el modulo de origen de acceso
        Select Case Modulo.Trim.ToUpper
            Case "PPSH"
                dtDatosEnvio = oSapMgr.ZSH_DATOS_ENVIO(Me.ebPedido.Text, dtDatosG)
            Case Else
                '------------------------------------------------------------------
                ' JNAVA (29.12.2015): Adaptamos para ejecutar desde SAP Retail
                '------------------------------------------------------------------
                'Dim oRetail As New ProcesosRetail("/pos/ventas", "POST")
                dtDatosEnvio = oSapMgr.ZPOL_DATOS_ENVIO(Me.ebPedido.Text, dtDatosG)
                'dtDatosEnvio = oRetail.SapZpolDatosEnvio(Me.ebPedido.Text, oSapMgr.Read_Centros, dtDatosG)
                '------------------------------------------------------------------
        End Select

        If dtDatosEnvio.Rows.Count > 0 AndAlso dtDatosG.Rows.Count > 0 Then
            Dim oRowDE As DataRow = dtDatosEnvio.Rows(0), oRowDG As DataRow = dtDatosG.Rows(0)

            Me.expAsignaGuia.Enabled = True
            Me.btnActualizar.Enabled = False
            '----------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 03/05/2013: Si el tipo del pedido SH es C, es decir, envío para un cliente se cambia a tipo F para indicarle que es un
            'pedido facturado y funcione igual que el de EC y determinamos si es envio local o foraneo
            '----------------------------------------------------------------------------------------------------------------------------------
            'If Modulo.Trim.ToUpper = "PESH" Then
            '    If oRowDG!Tipo = "C" Then oRowDG!Tipo = "F"
            '    If CStr(row_pedido("Status")).Trim() = "PE-F" Then
            '        oRowDG!Local = "F"
            '    Else
            '        oRowDG!Local = "L"
            '    End If
            'End If
            'If CStr(row_cab!TIPO_ENVIO).Trim() = "F" Then
            If CStr(oRowDG!Tipo).Trim = "F" Then
                Me.lblFolioSAP.Text = "Factura"
                Me.ebFolioSAP.Text = CStr(oRowDG!FacturaSAP).Trim
                For Each oRow In dtPaqueterias.Rows
                    If CStr(oRow!Default_Factura).Trim = "X" Then
                        Me.cmbPaqueteriasGuia.Value = CStr(oRow!Paqueteria).Trim
                        Me.cmbPaqueteriasGuia.Enabled = False
                        Exit For
                    End If
                Next
            Else
                Me.lblFolioSAP.Text = "Traspaso"
                Select Case Modulo.Trim.ToUpper
                    Case "PPSH"
                        Me.ebFolioSAP.Text = CStr(row_pedido("Folio_Pedido")).Trim()
                        'Me.ebFolioSAP.Text = CStr(Me.grdPedidosEC.GetValue("TrasladoSAP")).Trim
                    Case Else
                        Me.ebFolioSAP.Text = CStr(row_pedido("Folio_Pedido")).Trim()
                        cmbPaqueteriasGuia.Value = "DHL"
                        cmbPaqueteriasGuia.ReadOnly = True
                        'Me.ebFolioSAP.Text = CStr(oRowDG!TrasladoSAP).Trim
                End Select
            End If

            '-------------------------------------------------------------------------------------------------
            ' JNAVA (11.03.2016): Si es Pedido de Ecommerse por surtir, siempre se genera guia foranea
            '-------------------------------------------------------------------------------------------------
            If Modulo.Trim.ToUpper = "PP" Then
                Me.chkLocal.Checked = False
                Me.chkLocal.Enabled = False
                If Me.cmbPaqueteriasGuia.Text.Trim = "" Then Me.cmbPaqueteriasGuia.Enabled = True
                If oConfigCierreFI.GenerarGuiaDHLAutomatica AndAlso Me.cmbPaqueteriasGuia.Text.Trim.ToUpper = "DHL" Then
                    Me.ebGuia.ReadOnly = True
                Else
                    Me.ebGuia.ReadOnly = False
                End If
            Else
                '-------------------------------------------------------------------------------------------------
                ' JNAVA (11.03.2016): Si es Pedido de SH por surtir, revisa si es envio foraneo o local
                '-------------------------------------------------------------------------------------------------
                Select Case CStr(row_cab!TIPO_ENVIO)
                    'Select Case CStr(oRowDG!Local).Trim.ToUpper
                    Case "L"
                        Me.chkLocal.Checked = True
                        Me.chkLocal.Enabled = False
                        Me.cmbPaqueteriasGuia.Text = ""
                        Me.cmbPaqueteriasGuia.Enabled = False
                    Case "F"
                        Me.chkLocal.Checked = False
                        Me.chkLocal.Enabled = False
                        If Me.cmbPaqueteriasGuia.Text.Trim = "" Then Me.cmbPaqueteriasGuia.Enabled = True
                        If oConfigCierreFI.GenerarGuiaDHLAutomatica AndAlso Me.cmbPaqueteriasGuia.Text.Trim.ToUpper = "DHL" Then
                            Me.ebGuia.ReadOnly = True
                        Else
                            Me.ebGuia.ReadOnly = False
                        End If
                End Select
            End If

            Me.ebNombre.Text = CStr(oRowDE!Nombre).Trim
            Me.ebDomicilio.Text = CStr(oRowDE!Domicilio).Trim
            Me.ebCiudad.Text = CStr(oRowDE!Ciudad).Trim
            Me.ebEstado.Text = CStr(oRowDE!Estado).Trim
            Me.ebCP.Text = CStr(oRowDE!CP).Trim
            Me.ebRFC.Text = CStr(oRowDE!RFC).Trim
            Me.ebTel.Text = CStr(oRowDE!Telefono).Trim
        End If

    End Sub

    Private Sub ActualizaGrid()
        If Me.Modulo = "" Then
            If oConfigCierreFI.AplicarSurtidoDPStreet = True Then
                Me.dtPedidosDPortenis = dtPedidos.Clone()
                Me.dtPedidosDPStreet = dtPedidos.Clone()
                Dim version As String = ""
                For Each row As DataRow In dtPedidos.Rows
                    version = CStr(row("Version"))
                    If version.StartsWith("DPT") Then
                        dtPedidosDPortenis.ImportRow(row)
                    ElseIf version.StartsWith("DPS") Then
                        dtPedidosDPStreet.ImportRow(row)
                    End If
                Next
                Me.grdPedidosEC.DataSource = Nothing
                Me.grdPedidosEC.DataSource = dtPedidosDPortenis
                Me.grdPedidosEC.Refresh()

                Me.grdDPStreet.DataSource = Nothing
                Me.grdDPStreet.DataSource = dtPedidosDPStreet
                Me.grdDPStreet.Refresh()
            Else
                Me.grdPedidosEC.DataSource = Nothing
                Me.grdPedidosEC.DataSource = dtPedidos
                Me.grdPedidosEC.Refresh()
            End If
        Else
            Me.grdPedidosEC.DataSource = Nothing
            Me.grdPedidosEC.DataSource = dtPedidos
            Me.grdPedidosEC.Refresh()
        End If
    End Sub

    Private Sub ObtenerPedidosPendientes()

        Limpiar(False)

        Dim dtTemp As DataTable

        Select Case Modulo.Trim.ToUpper
            Case "PESH"
                Dim htStatus As New Hashtable(1)
                Dim dtPedidosDet As DataTable

                htStatus(1) = "PE-F" 'Pedidos Pendientes de Enviar Foraneos
                htStatus(2) = "PE-L" 'Pedidos Pendientes de Enviar Locales
                dtTemp = oSapMgr.ZSH_PEDIDOS_PENDIENTES(strCentroSAP, dtCabeceraSH, dtPedidosDet, htStatus)
                If Me.Entrega <> "" Then
                    Dim dview As New DataView(dtTemp, "VBELN='" & Me.Entrega & "'", "", DataViewRowState.CurrentRows)
                    dtTemp = dview.Table
                Else
                    AgruparPedidosSH(dtTemp)
                End If
                dtTemp.Columns("VBELN").ColumnName = "Folio_Pedido"
                dtTemp.Columns("CEDES").ColumnName = "PuestoExpedicion"
                dtTemp.Columns.Add("TrasladoSAP", GetType(String))
            Case Else
                dtTemp = oSapMgr.ZPOL_VALIDA_TRAS_ENV
        End Select

        If dtTemp.Rows.Count > 0 Then

            dtTemp.Columns.Add("Asignar", GetType(String))
            dtTemp.AcceptChanges()

            If Not dtPedidos Is Nothing Then dtPedidos.Clear()
            dtPedidos = dtTemp.Clone

            Dim dvCabSH As DataView
            For Each oRow As DataRow In dtTemp.Rows
                oRow!Asignar = "Asignar"

                If Modulo.Trim.ToUpper <> "PESH" Then
                    '---------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 02/05/2013: Solo realizamos esta validacion si son pedidos de EC
                    '---------------------------------------------------------------------------------------------------------------------------
                    If (CStr(oRow!Facturar).Trim = "X" AndAlso CStr(oRow!Folio_Factura).Trim <> "") OrElse (CStr(oRow!Facturar).Trim = "" AndAlso CStr(oRow!PuestoExpedicion).Trim <> "") Then
                        dtPedidos.ImportRow(oRow)
                    End If
                Else
                    '---------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 06/05/2013: Obtenemos el folio del traslado realizado de los pedidos SH
                    '---------------------------------------------------------------------------------------------------------------------------
                    dvCabSH = New DataView(dtCabeceraSH, "VBELN = '" & CStr(oRow!Folio_Pedido).Trim & "'", "", DataViewRowState.CurrentRows)
                    If dvCabSH.Count > 0 Then oRow!TrasladoSAP = dvCabSH(0)!Traslado
                    dtPedidos.ImportRow(oRow)
                End If
            Next

            ' For Each oRow As DataRow In dtPedidos.Rows
            'orow!Asignar = "Asignar"
            'Next

            ActualizaGrid()

        End If

        'Me.wbAsignarGuia.Quit()

    End Sub

    Private Sub AsignarGuia()
        'Me.wbAsignaGuia.Navigate("" & Me.grdPedidosEC.GetValue("Pedido") & "&id=" & Centro.Trim)
        'Me.wbAsignarGuia.Navigate("http://www.google.com.mx/search?hl=es&source=hp&q=" & Me.grdPedidosEC.GetValue("Pedido") & " " & Centro & "&meta=&aq=f&aqi=&aql=&oq=")
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        ObtenerPedidosPendientes()

        'Dim proceso As New System.Diagnostics.Process
        'With proceso
        '    .StartInfo.FileName = "http://www.google.com.mx"
        '    .Start()
        'End With
    End Sub

    Private Sub grdPedidosEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPedidosEC.Click
        If Me.Modulo = "PP" Or Me.Modulo = "PF" Then
            If oConfigCierreFI.AplicarSurtidoDPStreet = True Then
                If Me.grdPedidosEC.Col = 1 Then
                    MostrarDetalleEcommerce(sender)
                End If
            Else
                If Me.grdPedidosEC.Col = 1 Then
                    'AsingarGuia()
                    MostrarDetalle()
                End If
            End If
        Else
            If Me.grdPedidosEC.Col = 1 Then
                'AsingarGuia()
                MostrarDetalle()
            End If
        End If

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.expRangos.Visible = False
    End Sub

    Private Sub btnGuardarRango_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarRango.Click
        If Me.cmbPaqueteriaRango.Text = "" Then
            MessageBox.Show("Es necesario seleccionar una paquetería", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbPaqueteriaRango.Focus()
        ElseIf Me.nebGuiaInicial.Value <= 0 OrElse Me.nenGuiaFinal.Value <= 0 Then
            MessageBox.Show("Es necesario indicar la guía inicial y la guia final", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebGuiaInicial.Focus()
        ElseIf Me.nebGuiaInicial.Value > Me.nenGuiaFinal.Value Then
            MessageBox.Show("La guía final debe ser mayor a la guía inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebGuiaInicial.Focus()
        ElseIf ValidaRangosGuias(True) Then
            If oSapMgr.ZGUIAS_INSERTAR_RANGO(Me.cmbPaqueteriaRango.Text, Me.nebGuiaInicial.Value, Me.nenGuiaFinal.Value).Trim = "S" Then
                MessageBox.Show("El rango de guias se ha guardado correctamente.", "Rango de Guias", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarRangos()
                MostrarFormRango(False)
            End If
        End If
    End Sub

    Private Function ValidarGuia() As Boolean

        Dim bRes As Boolean = True

        If Me.chkLocal.Checked = False AndAlso Me.ebGuia.Text.Trim <> "" Then
            If IsNumeric(Me.ebGuia.Text.Trim) Then
                If oSapMgr.ZGUIAS_VALIDAR(Me.cmbPaqueteriasGuia.Text, Me.ebGuia.Text.Trim).Trim <> "S" Then
                    Me.ebGuia.Text = ""
                    bRes = False
                    Me.ebGuia.Focus()
                End If
            Else
                MessageBox.Show("Para este campo el valor indicado no corresponde, Verifique e intente de nuevo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                bRes = False
                Me.ebGuia.Focus()
            End If
        End If

        Return bRes

    End Function

    Private Sub Limpiar(ByVal bDetalle As Boolean)
        If bDetalle = False AndAlso Not dtPedidos Is Nothing Then
            dtPedidos.Clear()
            ActualizaGrid()
        End If
        CentroDes = ""
        Me.cmbPaqueteriasGuia.Value = ""
        Me.cmbPaqueteriasGuia.Text = ""
        Me.cmbPaqueteriaRango.Value = ""
        Me.cmbPaqueteriaRango.Text = ""
        Me.ebGuia.Text = ""
        Me.nebGuiaInicial.Value = 0
        Me.nenGuiaFinal.Value = 0
        Me.ebNombre.Text = ""
        Me.ebDomicilio.Text = ""
        Me.ebEstado.Text = ""
        Me.ebCiudad.Text = ""
        Me.ebTel.Text = ""
        Me.ebCP.Text = ""
        Me.ebRFC.Text = ""
        Me.chkLocal.Checked = False
        Me.chkLocal.Enabled = True
        Me.ebPedido.Text = ""
        Me.ebFolioSAP.Text = ""
        Me.cmbPaqueteriasGuia.Enabled = True
        Me.expAsignaGuia.Enabled = False
        Me.btnActualizar.Enabled = True
        Me.nebNumBultos.Value = 0
        'If Not dtCabeceraSH Is Nothing Then dtCabeceraSH.Clear()
        UserNameAplicated = ""
    End Sub

    'Private Function GenerarGuiaAutomaticaDHL() As Boolean

    '    Dim bRes As Boolean = False
    '    Dim oFrmMsg As New frmMessages

    '    Try
    '        'Dim wsDHL2 As New wsEstefany.DHLServicios
    '        Dim wsDHL As New wsDHL.DHLCompleteSOAP_HTTP_Service(oConfigCierreFI.ServerBroker, oConfigCierreFI.PuertoBroker)
    '        Dim oRequest As New wsDHL.SapZinfoPaqueteType
    '        Dim oResponse As wsDHL._ShipmentValidateResponse
    '        'Dim oResponse2 As String()
    '        '-----------------------------------------------------------------------------------------------------------------------------------------
    '        'Le asignamos las credenciales del proxy en caso de estar configurado
    '        '-----------------------------------------------------------------------------------------------------------------------------------------
    '        Dim pr As WebProxy
    '        If Not WebProxy.GetDefaultProxy.Address Is Nothing Then
    '            ' proxy settings 
    '            Dim cr As New NetworkCredential(oConfigCierreFI.UserProxy, oConfigCierreFI.PasswordProxy)
    '            pr = New WebProxy(WebProxy.GetDefaultProxy.Address.Host, WebProxy.GetDefaultProxy.Address.Port)

    '            pr.Credentials = cr
    '            'wsDHL2.Proxy = pr
    '            wsDHL.Proxy = pr
    '        End If

    '        'Me.ebPedido.Text = "9228002357"

    '        oFrmMsg.Text = "Generación Automática de Guías"
    '        oFrmMsg.lblMessage.Text = "Generando Guia de DHL"
    '        oFrmMsg.Show()
    '        Application.DoEvents()

    '        oRequest.IOficinaventas = "T" & oAppContext.ApplicationConfiguration.Almacen
    '        oRequest.IPaqueteria = "DHL"
    '        oRequest.IPedido = Me.ebPedido.Text
    '        oResponse = wsDHL.solicitarEnvio(oRequest)

    '        oFrmMsg.Close()

    '        'oResponse2 = wsDHL2.GenerarGuiaDHL(Me.ebPedido.Text, "T046", "DHL")

    '        If Not oResponse Is Nothing Then

    '            Dim ArchivoLocal As String = ""

    '            bRes = True

    '            Me.ebGuia.Text = oResponse.AirwayBillNumber.Trim

    '            ArchivoLocal = "C:\GuiasDHL\" & Format(Today, "ddMMyyyy") & "\" & Me.ebGuia.Text & ".pdf"

    '            '---------------------------------------------------------------------------------------------------------------------------------------
    '            'Esperamos un poco para dar tiempo a que se genere el archivo PDF de la Guia en el Servidor
    '            '---------------------------------------------------------------------------------------------------------------------------------------
    '            Threading.Thread.Sleep(5000)
    '            Application.DoEvents()

    '            Dim bFileFTP As Boolean = False
    '            '---------------------------------------------------------------------------------------------------------------------------------
    '            'RGERMAIN 28.05.2014: Se dejo configurable el usuario y password de la ruta ftp donde estan los archivos PDFs de DHL
    '            '---------------------------------------------------------------------------------------------------------------------------------
    '            'bFileFTP = DescargarArchivoPorFTP(oConfigCierreFI.ServerBroker, "linux", "dportenix1", oResponse.pdfFile, ArchivoLocal)
    '            bFileFTP = DescargarArchivoPorFTP(oConfigCierreFI.ServerBroker, oConfigCierreFI.UserFTPBroker, oConfigCierreFI.PasswordFTPBroker, oResponse.pdfFile, ArchivoLocal)
    '            '---------------------------------------------------------------------------------------------------------------------------------------
    '            'RGERMAIN 15.04.2014: Si no se copio a la primera, hacemos un reintento de copiar el archivo pdf de la ruta FTP
    '            '---------------------------------------------------------------------------------------------------------------------------------------
    '            If bFileFTP = False Then
    '                EscribeLog("Reintento", "Se realizo el reintento")
    '                Threading.Thread.Sleep(3000)
    '                Application.DoEvents()
    '                '---------------------------------------------------------------------------------------------------------------------------------
    '                'RGERMAIN 28.05.2014: Se dejo configurable el usuario y password de la ruta ftp donde estan los archivos PDFs de DHL
    '                '---------------------------------------------------------------------------------------------------------------------------------
    '                'bFileFTP = DescargarArchivoPorFTP(oConfigCierreFI.ServerBroker, "linux", "dportenix1", oResponse.pdfFile, ArchivoLocal)
    '                bFileFTP = DescargarArchivoPorFTP(oConfigCierreFI.ServerBroker, oConfigCierreFI.UserFTPBroker, oConfigCierreFI.PasswordFTPBroker, oResponse.pdfFile, ArchivoLocal)
    '            End If
    '            'DescargarGuiaPDF("http://localhost/", Me.ebGuia.Text.Trim, pr)
    '            If File.Exists(ArchivoLocal) Then Process.Start(ArchivoLocal)

    '            MessageBox.Show("Se ha generado la guía de DHL " & Me.ebGuia.Text & " correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            'ElseIf Not oResponse2 Is Nothing Then
    '            '    Dim strPickUp As String()
    '            '    Me.ebGuia.Text = oResponse2(0)
    '            '    Me.ebDomicilio.Text = oResponse2(1)
    '            '    DescargarGuiaPDF("http://localhost/", Me.ebGuia.Text.Trim, pr)
    '            '    strPickUp = wsDHL2.LlamarRecoleccion(Me.ebPedido.Text, "T046", "DHL")
    '            '    MessageBox.Show("Se ha generado la guía de DHL " & Me.ebGuia.Text & " correctamente." & vbCrLf & "Folio de Recoleccion: " & strPickUp(0), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Else
    '            MessageBox.Show("Ocurrió un error al generar la guía de DHL", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Me.btnImprimir.Focus()
    '        End If
    '    Catch ex As Exception
    '        If oFrmMsg.Visible Then oFrmMsg.Close()
    '        EscribeLog(ex.ToString, "Error al generar la Guia de DHL en automatico")
    '        MessageBox.Show("Ocurrió un error al generar la guía de DHL", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End Try

    '    Return bRes

    'End Function

    Private Function GenerarGuiaAutomaticaDHL() As Boolean

        '---------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (05.03.2016): Se adapto funcion completa por adecuacion de Retail
        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim bRes As Boolean = False
        Dim oFrmMsg As New frmMessages

        Try

            Dim wsDHL As New WSBroker("DHLCompleteSOAP_HTTP_Service")
            Dim oResponse As Hashtable
            Dim restService As New ProcesosRetail("/dhl", "POST")
            Dim resultRestDHL As New Dictionary(Of String, Object)
            oFrmMsg.Text = "Generación Automática de Guías"
            oFrmMsg.lblMessage.Text = "Generando Guia de DHL"
            oFrmMsg.Show()
            Application.DoEvents()
            resultRestDHL = restService.GenerarGuiaDHL("T" & oAppContext.ApplicationConfiguration.Almacen, "DHL", Me.ebPedido.Text)
            'oResponse = wsDHL.DHLCompleteSOAP("T" & oAppContext.ApplicationConfiguration.Almacen, Me.ebPedido.Text)

            oFrmMsg.Close()

            If resultRestDHL.Count > 0 Then

                Dim ArchivoLocal As String = ""

                bRes = True

                '---------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (05.03.2016): Validamos que realmente se genero la guia
                '---------------------------------------------------------------------------------------------------------------------------------------
                If Not resultRestDHL.ContainsKey("AirwayBillNumber") Then
                    MessageBox.Show("Ocurrió un error al generar la guía de DHL", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.btnImprimir.Focus()
                    bRes = False
                    Exit Try
                End If
                '---------------------------------------------------------------------------------------------------------------------------------------

                Me.ebGuia.Text = CStr(resultRestDHL("AirwayBillNumber")).Trim

                ArchivoLocal = "C:\GuiasDHL\" & Format(Today, "ddMMyyyy") & "\" & Me.ebGuia.Text & ".pdf"

                '---------------------------------------------------------------------------------------------------------------------------------------
                'Esperamos un poco para dar tiempo a que se genere el archivo PDF de la Guia en el Servidor
                '---------------------------------------------------------------------------------------------------------------------------------------
                'Threading.Thread.Sleep(5000)
                Application.DoEvents()

                Dim bFileFTP As Boolean = False
                '---------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 28.05.2014: Se dejo configurable el usuario y password de la ruta ftp donde estan los archivos PDFs de DHL
                '---------------------------------------------------------------------------------------------------------------------------------
                'bFileFTP = DescargarArchivoPorFTP(oConfigCierreFI.ServerBroker, "linux", "dportenix1", oResponse.pdfFile, ArchivoLocal)
                Dim RutaLocal As String = ""
                Dim Archivo() As String
                Archivo = ArchivoLocal.Split("\")
                If Archivo.Length > 0 Then
                    RutaLocal = Archivo(Archivo.Length - 1)
                    RutaLocal = ArchivoLocal.Substring(0, ArchivoLocal.Trim.Length - RutaLocal.Trim.Length)
                End If
                Dim pdfBytes() As Byte = Convert.FromBase64String(resultRestDHL("pdfByte")) ' CType(resultRestDHL("pdfByte"), Byte())
                If RutaLocal.Trim <> "" AndAlso Directory.Exists(RutaLocal) = False Then Directory.CreateDirectory(RutaLocal)
                File.WriteAllBytes(ArchivoLocal, pdfBytes)
                'bFileFTP = DescargarArchivoPorFTP(oConfigCierreFI.ServerBroker, oConfigCierreFI.UserFTPBroker, oConfigCierreFI.PasswordFTPBroker, resultRestDHL("pdf"), ArchivoLocal)
                ''---------------------------------------------------------------------------------------------------------------------------------------
                ''RGERMAIN 15.04.2014: Si no se copio a la primera, hacemos un reintento de copiar el archivo pdf de la ruta FTP
                ''---------------------------------------------------------------------------------------------------------------------------------------
                'If bFileFTP = False Then
                '    EscribeLog("Reintento", "Se realizo el reintento")
                '    'Threading.Thread.Sleep(3000)
                '    Application.DoEvents()
                '    '---------------------------------------------------------------------------------------------------------------------------------
                '    'RGERMAIN 28.05.2014: Se dejo configurable el usuario y password de la ruta ftp donde estan los archivos PDFs de DHL
                '    '---------------------------------------------------------------------------------------------------------------------------------
                '    'bFileFTP = DescargarArchivoPorFTP(oConfigCierreFI.ServerBroker, "linux", "dportenix1", oResponse.pdfFile, ArchivoLocal)
                '    bFileFTP = DescargarArchivoPorFTP(oConfigCierreFI.ServerBroker, oConfigCierreFI.UserFTPBroker, oConfigCierreFI.PasswordFTPBroker, resultRestDHL("pdf"), ArchivoLocal)
                'End If

                If File.Exists(ArchivoLocal) Then Process.Start(ArchivoLocal)

                MessageBox.Show("Se ha generado la guía de DHL " & Me.ebGuia.Text & " correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Ocurrió un error al generar la guía de DHL", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.btnImprimir.Focus()
            End If
        Catch ex As Exception
            If oFrmMsg.Visible Then oFrmMsg.Close()
            EscribeLog(ex.ToString, "Error al generar la Guia de DHL en automatico")
            MessageBox.Show("Ocurrió un error al generar la guía de DHL", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return bRes

    End Function

    Private Sub DescargarGuiaPDF(ByVal RutaWebPDF As String, ByVal Guia As String, ByVal proxy As WebProxy)

        Dim strGuiaPDF As String = ""

        Try
            RutaWebPDF &= Guia.Trim & ".pdf"

            Dim wr As HttpWebRequest = CType(HttpWebRequest.Create(RutaWebPDF), HttpWebRequest)
            Dim RutaLocalPDF As String = "C:\GuiasDHL\" & Format(Today, "ddMMyyyy")
            '-----------------------------------------------------------------------------------------------------------------------------------
            'Le pasamos las credenciales del proxy en caso de estar configurado
            '-----------------------------------------------------------------------------------------------------------------------------------
            If Not proxy Is Nothing Then wr.Proxy = proxy
            '-----------------------------------------------------------------------------------------------------------------------------------
            ' Send the HttpWebRequest and wait for response. 
            '-----------------------------------------------------------------------------------------------------------------------------------
            Dim ws As HttpWebResponse = CType(wr.GetResponse(), HttpWebResponse)
            Dim str As Stream = ws.GetResponseStream()
            Dim inBuf(30000000) As Byte
            Dim bytesToRead As Integer = CInt(inBuf.Length)
            Dim bytesRead As Integer = 0
            While bytesToRead > 0
                Dim n As Integer = str.Read(inBuf, bytesRead, bytesToRead)
                If n = 0 Then
                    Exit While
                End If
                bytesRead += n
                bytesToRead -= n
            End While
            If Directory.Exists(RutaLocalPDF) = False Then Directory.CreateDirectory(RutaLocalPDF)
            strGuiaPDF = RutaLocalPDF.TrimEnd("\") & "\" & Guia & ".pdf"
            Dim fstr As New FileStream(strGuiaPDF, FileMode.OpenOrCreate, FileAccess.Write)
            fstr.Write(inBuf, 0, bytesRead)
            str.Close()
            fstr.Close()
            'Abrimos el archivo PDF recien descargado para que lo imprima la tienda
            If File.Exists(strGuiaPDF) Then Process.Start(strGuiaPDF)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al descargar el archivo PDF de la Guia " & Guia.Trim & " de DHL")
        End Try

    End Sub

    Private Sub MostrarFoliosPickUp()

        If Me.cmbPaqueteriasPickUp.Text.Trim <> "" Then
            Me.grdFoliosPickUp.DataSource = oSapMgr.GetFoliosPickUp(Me.cmbPaqueteriasPickUp.Value, oConfigCierreFI)
            Me.grdFoliosPickUp.Refresh()
        End If

    End Sub

    Private Function ValidaCampos() As Boolean

        Dim bRes As Boolean = True

        If Me.chkLocal.Checked = False AndAlso Me.cmbPaqueteriasGuia.Text.Trim = "" Then
            MessageBox.Show("Es necesario seleccionar una paquetería", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbPaqueteriasGuia.Focus()
            bRes = False
        ElseIf Me.ebGuia.Text.Trim = "" AndAlso (Me.cmbPaqueteriasGuia.Text.Trim <> "DHL" OrElse oConfigCierreFI.GenerarGuiaDHLAutomatica = False) Then
            MessageBox.Show("Es necesario indicar la guia a imprimir", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebGuia.Focus()
            bRes = False
        ElseIf Me.ebFolioSAP.Text.Trim = "" Then
            MessageBox.Show("Es necesario indicar el Folio SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.grdPedidosEC.Focus()
            bRes = False
        ElseIf Me.nebNumBultos.Value <= 0 Then
            MessageBox.Show("Es necesario indicar el número de bultos a enviar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebNumBultos.Focus()
            bRes = False
        ElseIf EstaPedidoCancelado(Me.ebPedido.Text.Trim, Modulo) Then
            MessageBox.Show("El pedido ha sido cancelado en este momento, no es posible asignar la guía.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ObtenerPedidosPendientes()
            bRes = False
        ElseIf Me.chkLocal.Checked = False AndAlso ((oConfigCierreFI.GenerarGuiaDHLAutomatica = False OrElse Me.cmbPaqueteriasGuia.Text.Trim <> "DHL") AndAlso ValidarGuia() = False) Then
            bRes = False
        ElseIf Modulo.Trim.ToUpper = "PESH" Then
            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.SiHay.AsignarGuia") Then
                oAppContext.Security.CloseImpersonatedSession()
                bRes = False
            Else
                UserNameAplicated = oAppContext.Security.CurrentUser.Name
                oAppContext.Security.CloseImpersonatedSession()
            End If
        End If

        Return bRes

    End Function

    Private Sub ImprimirGuia()

        'If Me.chkLocal.Checked = False AndAlso Me.cmbPaqueteriasGuia.Text.Trim = "" Then
        '    MessageBox.Show("Es necesario seleccionar una paquetería", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Me.cmbPaqueteriasGuia.Focus()
        'ElseIf Me.ebGuia.Text.Trim = "" Then
        '    MessageBox.Show("Es necesario indicar la guia a imprimir", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Me.ebGuia.Focus()
        'ElseIf Me.ebFolioSAP.Text.Trim = "" Then
        '    MessageBox.Show("Es necesario indicar el Folio SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Me.grdPedidosEC.Focus()
        'ElseIf Me.nebNumBultos.Value <= 0 Then
        '    MessageBox.Show("Es necesario indicar el número de bultos a enviar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Me.nebNumBultos.Focus()
        'ElseIf EstaPedidoCancelado(Me.ebPedido.Text.Trim, "ASIGNAGUIA") Then
        '    MessageBox.Show("El pedido ha sido cancelado en este momento, no es posible asignar la guía.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    GoTo Final
        'ElseIf Me.chkLocal.Checked OrElse ValidarGuia() Then
        If ValidaCampos() Then

            Dim bGeneroGuia As Boolean = True
            '------------------------------------------------------------------------------------------------------------------------------------
            'Si es DHL y tenemos configurado el WS de generacion de guias automaticas, generamos la guia automaticamente
            '------------------------------------------------------------------------------------------------------------------------------------
            If Me.chkLocal.Checked = False AndAlso Me.cmbPaqueteriasGuia.Text.Trim.ToUpper = "DHL" AndAlso oConfigCierreFI.GenerarGuiaDHLAutomatica Then
                bGeneroGuia = GenerarGuiaAutomaticaDHL()
            End If
            '------------------------------------------------------------------------------------------------------------------------------------
            'Imprimimos la guia o el traspaso en caso de ser local
            '------------------------------------------------------------------------------------------------------------------------------------
            Dim oTS As TraspasoSalida

            If bGeneroGuia AndAlso EnviarImpresion(oTS) Then
                '--------------------------------------------------------------------------------------------------------------------------------
                'Guardamos la guia utilizada en caso de que se haya impreso bien
                '--------------------------------------------------------------------------------------------------------------------------------
                Dim strMsg As String = ""
                If Me.chkLocal.Checked Then
                    strMsg = "¿Se imprimió la guía correctamente?"
                ElseIf CStr(Me.cmbPaqueteriasGuia.DropDownList.GetValue("Imprimir")).Trim = "X" AndAlso oConfigCierreFI.GenerarGuiaDHLAutomatica = False Then
                    strMsg = "¿Se imprimió la guía correctamente?"
                End If
                If strMsg.Trim = "" OrElse MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If Me.chkLocal.Checked = False Then oSapMgr.ZGUIAS_UTILIZAR(Me.cmbPaqueteriasGuia.Text, Me.ebGuia.Text, False)
                    Dim strRes As String = ""
                    Select Case Modulo.Trim.ToUpper
                        Case "PPSH"
                            Dim htCabecera As New Hashtable()
                            htCabecera("Guia") = Me.ebGuia.Text.Trim
                            htCabecera("Responsable") = UserNameAplicated
                            htCabecera("Pedido") = Me.ebPedido.Text
                            Me.Info_Guia = htCabecera
                            Me.Info_Guia("Transportista") = cmbPaqueteriasGuia.Text.Trim()
                            Me.Info_Guia("Bultos") = CStr(nebNumBultos.Value)
                            Me.Dispose()
                            '------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 06/06/2013: Filtramos la cabecera de las solicitudes solo por el pedido que queremos asignar guia
                            '------------------------------------------------------------------------------------------------------------------
                            'dtCabeceraSH = CreateCabSHByPedido(view_Det)
                            'dtCabeceraSH = FiltrarCabSHByPedido(Me.ebPedido.Text, dtCabeceraSH)
                            'oSapMgr.ZSH_ACTUALIZAR_SOLICITUD("SURTIDO", htCabecera, row_cab, Nothing, Nothing, "", strRes)
                        Case Else
                            '------------------------------------------------------------------------------------------------------------------
                            ' JNAVA (14.03.2016): Seteamos datos de guia para poderlos enviar en el surtido
                            '------------------------------------------------------------------------------------------------------------------
                            Me.Info_Guia = New Hashtable
                            Me.Info_Guia.Add("Guia", Me.ebGuia.Text.Trim)
                            Me.Info_Guia.Add("Responsable", UserNameAplicated)
                            Me.Info_Guia.Add("Pedido", Me.ebPedido.Text)
                            Me.Info_Guia.Add("Transportista", cmbPaqueteriasGuia.Text.Trim())
                            Me.Info_Guia.Add("Bultos", CStr(nebNumBultos.Value))
                            '------------------------------------------------------------------------------------------------------------------

                            ' strRes = oSapMgr.ZPOL_GRABAR_ENVIO(Me.ebPedido.Text, Me.cmbPaqueteriasGuia.Text, Me.ebGuia.Text, Not Me.chkLocal.Checked).Trim()
                    End Select
                    '                    If strRes.Trim.ToUpper = "S" Then
                    '                        '-----------------------------------------------------------------------------------------------------------------------------------
                    '                        ' JNAVA (17.02.2016): se comenta por que ya no se usara pues la BAPI de ZBAPIMM02_PEDIDOTRAS incluye la funcionalidad
                    '                        '-----------------------------------------------------------------------------------------------------------------------------------
                    '                        '-------------------------------------------------------------------------------------------------------------------------
                    '                        'Actualizamos los bultos en SAP y en PRO al traslado
                    '                        '-------------------------------------------------------------------------------------------------------------------------
                    '                        'Try
                    '                        '    oSapMgr.SaveInfoPaqueteria(Me.ebFolioSAP.Text.Trim, Me.nebNumBultos.Value, "F02")
                    '                        '    If Not oTS Is Nothing Then oTSMgr.Save(oTS)
                    '                        'Catch ex As Exception
                    '                        '    EscribeLog(ex.ToString, "Error al actualizar los bultos en SAP y en PRO al asignar guia")
                    '                        'End Try

                    '                        MessageBox.Show("La guía " & Me.ebGuia.Text & " se ha utilizado correctamente para el pedido " & Me.ebPedido.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Final:
                    '                        '----------------------------------------------------------------------------------------------------------------------------------
                    '                        'RGERMAIN 30.10.2013: Agregamos este mensaje para que los players no se desesperan y vean que todavia no ha terminado el proceso
                    '                        '----------------------------------------------------------------------------------------------------------------------------------
                    '                        Dim oFrmMsg As New frmMessages

                    '                        oFrmMsg.Text = "Actualizacion de Pedidos"
                    '                        oFrmMsg.lblMessage.Text = "Actualizando Pedidos Pendientes... Favor de Esperar"
                    '                        oFrmMsg.Show()
                    '                        Application.DoEvents()

                    '                        ObtenerPedidosPendientes()

                    '                        oFrmMsg.Close()
                    '                    End If
                    '-----------------------------------------------------------------------------------------------------------------------------------
                    ' JNAVA (14.03.2016): se comenta por que ya no se usara la funcionalidad
                    '-----------------------------------------------------------------------------------------------------------------------------------
                    'bPedidosRefresh = True
                    '----------------------------------------------------------------------------------------------------------------------------
                    'Actualizamos el panel que muestra los pedidos pendientes del Ecommerce
                    '----------------------------------------------------------------------------------------------------------------------------
                    'If oConfigCierreFI.SurtirEcommerce Then RefreshPedidosEC()
                    '-----------------------------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 19/06/2013: Se actualiza el estatus de los pedidos en el panel del HomeDash del Si Hay
                    '-----------------------------------------------------------------------------------------------------------------------------------------
                    'If FacturacionSiHay > 0 Then RefreshPedidosSiHay()
                    '-----------------------------------------------------------------------------------------------------------------------------------

                    '-----------------------------------------------------------------------------------------------------------------------------------
                    ' JNAVA (14.03.2016): Cerramos la ventana apra continuar con el proceso automaticamente
                    '-----------------------------------------------------------------------------------------------------------------------------------
                    Me.Dispose()

                ElseIf Me.chkLocal.Checked = False Then
                    oSapMgr.ZGUIAS_UTILIZAR(Me.cmbPaqueteriasGuia.Text, Me.ebGuia.Text, True)
                    Me.ebGuia.Text = ""
                    MessageBox.Show("La guía " & Me.ebGuia.Text & " se ha cancelado, favor de utilizar otra guía.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ebGuia.Focus()
                End If
            End If
        End If

    End Sub

    Private Function FiltrarCabSHByPedido(ByVal FolioPedido As String, ByVal dtCabSH As DataTable) As DataTable
        Dim dtTemp As DataTable
        Dim oRow As DataRowView
        Dim dvCabSH As DataView

        dtTemp = dtCabSH.Clone
        dvCabSH = New DataView(dtCabSH, "VBELN = '" & FolioPedido.Trim & "'", "", DataViewRowState.CurrentRows)
        For Each oRow In dvCabSH
            dtTemp.ImportRow(oRow.Row)
        Next

        Return dtTemp

    End Function

    Private Function CreateCabSHByPedido(ByVal dtCabSH As DataView) As DataTable
        Dim dtTemp As DataTable = dtCabSH.Table.Clone
        For Each row As DataRowView In dtCabSH
            dtTemp.ImportRow(row.Row)
        Next
        dtTemp.AcceptChanges()
        Return dtTemp
    End Function

    Private Function EnviarImpresion(ByRef oTS As TraspasoSalida) As Boolean
        Dim bRes As Boolean = True

        'If Me.lblFolioSAP.Text.Trim.ToUpper = "TRASPASO" Then

        '    'Dim oTS As TraspasoSalida
        '    Dim AlmDes() As String

        '    oTS = oTSMgr.LoadByFolioSAP(Me.ebFolioSAP.Text)

        '    If Not oTS Is Nothing Then
        '        AlmDes = oSapMgr.Read_CentrosSAP(CentroDes)
        '        oTS.AlmacenDestinoID = AlmDes(0).Trim
        '        oTS.TotalBultos = Me.nebNumBultos.Value
        '        oTS.PedidoEC = Me.ebPedido.Text.Trim
        '        oTS.Modulo = IIf(Modulo.Trim.ToUpper = "PESH", "SH", "EC")
        '        PrintComprobanteTraspaso(oTS)
        '    Else
        '        MessageBox.Show("No se ha encontrado el traspaso para su impresion.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Return False
        '    End If

        'End If

        If Me.chkLocal.Checked = False AndAlso CStr(Me.cmbPaqueteriasGuia.DropDownList.GetValue("Imprimir")) = "X" AndAlso oConfigCierreFI.GenerarGuiaDHLAutomatica = False Then

            If Me.lblFolioSAP.Text.Trim.ToUpper = "TRASPASO" Then
                MessageBox.Show("Imprimiendo Traspaso..." & vbCrLf & vbCrLf & "Prepare la impresora con la guia y pulse aceptar cuando este lista para imprimir.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'Dim proceso As New System.Diagnostics.Process
            'With proceso
            '    .StartInfo.FileName = "http://192.168.3.96/guia/site/paginaImpre.php?v1=" & Me.ebNombre.Text.Trim & "&v2=" & Me.ebDomicilio.Text.Trim & "&v3=" & Me.ebEstado.Text.Trim & _
            '                          "&v4=" & Me.ebCiudad.Text.Trim & "&v5=" & Me.ebTel.Text.Trim & "&v6=" & Me.ebCP.Text.Trim
            '    .Start()
            'End With
            Dim rptGuiaDHL As New rptGuiaDHL(Me.ebNombre.Text, Me.ebDomicilio.Text, Me.ebCiudad.Text, Me.ebEstado.Text, Me.ebCP.Text, Me.ebTel.Text)
            Dim oView As New ReportViewerForm
            rptGuiaDHL.Document.Name = "Impresion de Guia DHL"
            rptGuiaDHL.PageSettings.Margins.Left = 0.1F
            rptGuiaDHL.Run()
            rptGuiaDHL.Document.Print(False, False)
            'oView.Report = rptGuiaDHL
            'oView.Show()

        End If

        Return bRes

    End Function

    Public Sub PrintComprobanteTraspaso(ByVal oTraspasoSalida As TraspasoSalida)

        If Not oTraspasoSalida Is Nothing Then

            Dim oARReporte As New rptReporteTraspasoDeSalida(oTraspasoSalida, "Pedidos Sin Guía")
            'Dim oReportViewer As New ReportViewerForm

            oARReporte.Document.Name = "Reporte de Traspaso de Salida"

            oARReporte.Run()

            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

            Try

                oARReporte.Document.Print(False, False)

            Catch ex As Exception

                EscribeLog(ex.ToString, "Error al imprimir traspaso al asignar guia")
                MsgBox(ex.ToString)

            End Try

        End If

    End Sub

    Private Sub MostrarFormRango(ByVal bMostrar As Boolean)
        LimpiarRangos()
        If bMostrar Then
            Me.expRangos.Left = "60"
            Me.expRangos.Top = "80"
            'Me.expPPal.Enabled = False
            EnableControl(False)
            Me.expRangos.Visible = True
            Me.expRangos.Enabled = True
            Me.cmbPaqueteriaRango.Focus()
        Else
            EnableControl(True)
            Me.expRangos.Visible = False
            Me.expPPal.Enabled = True
            Me.cmbPaqueteriasGuia.Focus()
        End If
    End Sub

    Private Sub EnableControl(ByVal value As Boolean)
        Me.cmbPaqueteriasGuia.Enabled = value
        Me.ebPedido.Enabled = value
        Me.ebFolioSAP.Enabled = value
        Me.ebGuia.Enabled = value
        Me.nebNumBultos.Enabled = value
        Me.ebNombre.Enabled = value
        Me.ebDomicilio.Enabled = value
        Me.ebCiudad.Enabled = value
        Me.ebEstado.Enabled = value
        Me.ebCP.Enabled = value
        Me.ebTel.Enabled = value
        Me.ebRFC.Enabled = value
        Me.btnImprimir.Enabled = value
    End Sub

    Private Sub MostrarFormPickUp(ByVal bMostrar As Boolean)
        LimpiarPickUp()
        If bMostrar Then
            Me.expReportePickUp.Left = "216"
            Me.expReportePickUp.Top = "0"
            Me.expPPal.Enabled = False
            Me.expReportePickUp.Visible = True
            Me.cmbPaqueteriasPickUp.Focus()
        Else
            Me.expReportePickUp.Visible = False
            Me.expPPal.Enabled = True
            Me.cmbPaqueteriasPickUp.Focus()
        End If
    End Sub

    Private Sub LimpiarRangos()
        Me.cmbPaqueteriaRango.Value = ""
        Me.cmbPaqueteriaRango.Text = ""
        Me.nebGuiaInicial.Value = 0
        Me.nenGuiaFinal.Value = 0
    End Sub

    Private Sub LimpiarPickUp()
        Me.cmbPaqueteriasPickUp.Value = ""
        Me.cmbPaqueteriasPickUp.Text = ""
        Me.grdFoliosPickUp.FilterMode = Janus.Windows.GridEX.FilterMode.None
        Me.grdFoliosPickUp.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdFoliosPickUp.DataSource = Nothing
    End Sub

    Private Sub uICommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles uICommandManager1.CommandClick
        Select Case e.Command.Key
            Case "menuRangos"
                MostrarFormRango(True)
            Case "menuRevisarFoliosPickUp"
                MostrarFormPickUp(True)
            Case "menuDescargarGuia"
                DescargarGuiaDHLFromFTP()
            Case "menuSalir"
                Me.Close()
        End Select
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            Me.btnImprimir.Enabled = False
            ImprimirGuia()
        Catch ex As Exception
        Finally
            Me.btnImprimir.Enabled = True
        End Try
    End Sub

    Private Sub ebGuia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebGuia.Validating
        If Me.cmbPaqueteriasGuia.Text.Trim <> "" Then
            ValidarGuia()
        End If
    End Sub

    Private Sub btnSalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        MostrarFormRango(False)
    End Sub

    Private Sub chkLocal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLocal.CheckedChanged
        If Me.chkLocal.Checked Then
            Me.ebGuia.Text = "LOCAL"
            Me.ebGuia.ReadOnly = True
        Else
            Me.ebGuia.Text = ""
            Me.ebGuia.ReadOnly = False
        End If
    End Sub

    Private Sub DescargarGuiaDHLFromFTP()
        Dim strPedido As String = ""
        Dim ArchivoLocal As String = "", strGuia As String = ""
        Dim dtTemp As DataTable, oRow As DataRow

        strPedido = InputBox("Numero de pedido", "Pedido")
        If strPedido.Trim <> "" Then
            Select Case Modulo.Trim.ToUpper
                Case "PESH"
                    Dim htStatus As New Hashtable(0)
                    Dim dtPedidosDet As DataTable, dtCabTemp As DataTable

                    htStatus(1) = "E" 'Pedidos Enviados
                    dtTemp = oSapMgr.ZSH_PEDIDOS_PENDIENTES(strCentroSAP, dtCabTemp, dtPedidosDet, htStatus, , strPedido.Trim)
                    dtTemp = dtCabTemp.Copy
                Case Else
                    dtTemp = oSapMgr.ZPOL_TBUSCAR_GUIA(strPedido)
            End Select

            If Not dtTemp Is Nothing AndAlso dtTemp.Rows.Count > 0 Then
                '----------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 11.07.2014: Se modifico para que buscara la guia en base a la sucursal que esta haciendo la descarga
                '----------------------------------------------------------------------------------------------------------------------------
                For Each oRow In dtTemp.Rows
                    If CStr(oRow!CESUM).Trim.ToUpper = strCentroSAP.Trim.ToUpper Then
                        strGuia = CStr(oRow!Guia).Trim
                        Exit For
                    End If
                Next
                'strGuia = dtTemp.Rows(0)!Guia
                If strGuia.Trim <> "" Then
                    ArchivoLocal = "C:\GuiasDHL\" & Format(Today, "ddMMyyyy") & "\" & strGuia.Trim & ".pdf"
                    '---------------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 28.05.2014: Se dejo configurable el usuario y password de la ruta ftp donde estan los archivos PDFs de DHL
                    '---------------------------------------------------------------------------------------------------------------------------------
                    'DescargarArchivoPorFTP(oConfigCierreFI.ServerBroker, "linux", "dportenix1", "/var/mqsi/dhl/TransformXMLtoPDF/PDFReports/" & strGuia & ".pdf", ArchivoLocal)
                    DescargarArchivoPorFTP(oConfigCierreFI.ServerBroker, oConfigCierreFI.UserFTPBroker, oConfigCierreFI.PasswordFTPBroker, oConfigCierreFI.RutaFTPDHL.TrimEnd("/") & "/" & strGuia & ".pdf", ArchivoLocal)

                    If File.Exists(ArchivoLocal) Then Process.Start(ArchivoLocal)
                Else
                    MessageBox.Show("El pedido indicado no pertenece a esta sucursal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("El pedido especificado no existe o no se le ha asignado guia.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Es necesario ingresar el numero de pedido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub frmPedidosSinGuia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Function Preguntar() As Boolean
        If Me.expAsignaGuia.Enabled Then
            If MessageBox.Show("No has guardado la guia del pedido seleccionado, ¿estas seguro de continuar sin guardar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub frmPedidosSinGuia_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'If Preguntar() = False Then
        '    e.Cancel = True
        'End If
    End Sub

    Private Function ValidaRangosGuias(ByVal bAlta As Boolean) As Boolean
        Dim bRes As Boolean = True

        If bAlta = False Then
            If Me.cmbPaqueteriasGuia.Text.Trim <> "" Then
                dtRangos = oSapMgr.ZGUIAS_RANGOS_RETR(Me.cmbPaqueteriasGuia.Text)

                If dtRangos.Rows.Count <= 0 Then
                    If MessageBox.Show("No hay un rango de guías asignado para la paquetería seleccionada." & vbCrLf & vbCrLf & "¿Desea agregar uno en este momento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        MostrarFormRango(True)
                    End If
                End If
            End If
        ElseIf Me.cmbPaqueteriaRango.Text.Trim <> "" Then
            dtRangos = oSapMgr.ZGUIAS_RANGOS_RETR(Me.cmbPaqueteriaRango.Text)

            For Each oRow As DataRow In dtRangos.Rows
                If (Me.nebGuiaInicial.Value >= CLng(oRow!R_Inicial) AndAlso Me.nebGuiaInicial.Value <= CLng(oRow!R_Final)) OrElse _
                (Me.nenGuiaFinal.Value >= CLng(oRow!R_Inicial) AndAlso Me.nenGuiaFinal.Value <= CLng(oRow!R_Final)) Then
                    bRes = False
                    Exit For
                End If
            Next

            If bRes = False Then
                MessageBox.Show("Ya existe un rango de guías que involucra los folios indicados.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.nebGuiaInicial.Focus()
            End If
        End If

        Return bRes

    End Function

    'Private Sub ExportarExcel(ByVal dtFolios As DataTable)

    '    Dim oExcel As Object
    '    Dim oBook As Object
    '    Dim oSheet As Object
    '    Dim oRow As DataRow
    '    Dim i As Integer = 2
    '    'Iniciar un nuevo libro en Excel
    '    oExcel = CreateObject("Excel.Application")

    '    oBook = oExcel.Workbooks.Add
    '    'Agregar datos a las celdas de la primera hoja en el libro nuevo
    '    oSheet = oBook.Worksheets(1)
    '    oSheet.Name = "Folios de Recoleccion"
    '    ' Agregamos Los datos que queremos agregar
    '    oSheet.Range("A1").Value = "Folio Recolección"
    '    oSheet.Range("B1").value = "Fecha"
    '    oSheet.Range("C1").value = "Paqueteria"

    '    For Each oRow In dtFolios.Rows
    '        oSheet.Range("A" & i).Value = CStr(oRow!Folio)
    '        oSheet.Range("B" & i).Value = Format(oRow!Fecha, "dd/MM/yyyy")
    '        oSheet.Range("C" & i).Value = Me.cmbPaqueteriasPickUp.Value
    '        i += 1
    '    Next

    '    'Guardaremos el documento en el escritorio con el nombre prueba
    '    oBook.SaveAs("C:\Prueba.xls")

    'End Sub

    Private Sub cmbPaqueteriasGuia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbPaqueteriasGuia.Validating
        ValidaRangosGuias(False)
    End Sub

    Private Sub btnSalirReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirReporte.Click
        MostrarFormPickUp(False)
    End Sub

    'Private Sub cmbPaqueteriasPickUp_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbPaqueteriasPickUp.Validating
    '    MostrarFoliosPickUp()
    'End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Try
            Dim oDialog As New SaveFileDialog

            oDialog.Filter = "Excel|*.xls"
            If oDialog.ShowDialog = DialogResult.OK Then
                Dim dtTemp As DataTable = CType(Me.grdFoliosPickUp.DataSource, DataTable).Copy
                dtTemp.Columns.Remove("PickUpID")
                DataTableToExcel(dtTemp, oDialog.FileName.Trim)
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al exportar a Excel")
        End Try
    End Sub

    Private Sub cmbPaqueteriasPickUp_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPaqueteriasPickUp.ValueChanged
        MostrarFoliosPickUp()
    End Sub

    Private Sub frmPedidosSinGuia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub grdDPStreet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDPStreet.Click
        If Me.grdDPStreet.Col = 1 Then
            MostrarDetalleEcommerce(sender)
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub lblDPStreet_Click(sender As System.Object, e As System.EventArgs) Handles lblDPStreet.Click

    End Sub

    Private Sub lblDportenis_Click(sender As System.Object, e As System.EventArgs) Handles lblDportenis.Click

    End Sub

    Private Sub grdPedidosEC_FormattingRow(sender As System.Object, e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdPedidosEC.FormattingRow

    End Sub
End Class
