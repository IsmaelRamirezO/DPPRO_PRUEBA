Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTransportista
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.Defectuosos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores

Public Class frmTraspasoAutoEcommerce
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblFolioTras As System.Windows.Forms.Label
    Friend WithEvents ebFolioTraspasoSAP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnConfirmarTraspaso As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarTraspasos As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebPedidoEC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodAlmacenDestino As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ebAlmacenDestino As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents grdDetallePedido As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdPedidosEC As Janus.Windows.GridEX.GridEX
    Friend WithEvents expNegados As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents grdNegados As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnConfirmarNegados As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents grpPedidos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents grpDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents grpTraspasos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnFacturar As Janus.Windows.EditControls.UIButton
    Friend WithEvents nebFolioTraspaso As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grdTraspasos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents AsignarGuia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents AsignarGuia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ReimprimirNotaVenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ReimprimirNotaVenta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents uICommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents menuDescargarGuia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents lblPedidosDportenis As System.Windows.Forms.Label
    Friend WithEvents lblPedidosDPStreet As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblCodVendedor As System.Windows.Forms.Label
    Friend WithEvents ebPlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombrePlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents grdDPStreet As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraspasoAutoEcommerce))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout5 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grpTraspasos = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnFacturar = New Janus.Windows.EditControls.UIButton()
        Me.nebFolioTraspaso = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grdTraspasos = New Janus.Windows.GridEX.GridEX()
        Me.grpDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.expNegados = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnConfirmarNegados = New Janus.Windows.EditControls.UIButton()
        Me.grdNegados = New Janus.Windows.GridEX.GridEX()
        Me.ebAlmacenDestino = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodAlmacenDestino = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ebPedidoEC = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnConfirmarTraspaso = New Janus.Windows.EditControls.UIButton()
        Me.grdDetallePedido = New Janus.Windows.GridEX.GridEX()
        Me.ebFolioTraspasoSAP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblFolioTras = New System.Windows.Forms.Label()
        Me.ebNombrePlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCodVendedor = New System.Windows.Forms.Label()
        Me.grpPedidos = New Janus.Windows.EditControls.UIGroupBox()
        Me.grdDPStreet = New Janus.Windows.GridEX.GridEX()
        Me.lblPedidosDPStreet = New System.Windows.Forms.Label()
        Me.lblPedidosDportenis = New System.Windows.Forms.Label()
        Me.btnBuscarTraspasos = New Janus.Windows.EditControls.UIButton()
        Me.grdPedidosEC = New Janus.Windows.GridEX.GridEX()
        Me.uICommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.AsignarGuia1 = New Janus.Windows.UI.CommandBars.UICommand("menuAsignarGuia")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.ReimprimirNotaVenta1 = New Janus.Windows.UI.CommandBars.UICommand("menuReimprimir")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.AsignarGuia = New Janus.Windows.UI.CommandBars.UICommand("menuAsignarGuia")
        Me.ReimprimirNotaVenta = New Janus.Windows.UI.CommandBars.UICommand("menuReimprimir")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuDescargarGuia = New Janus.Windows.UI.CommandBars.UICommand("menuDescargarGuia")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grpTraspasos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTraspasos.SuspendLayout()
        CType(Me.grdTraspasos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetalle.SuspendLayout()
        CType(Me.expNegados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expNegados.SuspendLayout()
        CType(Me.grdNegados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPedidos.SuspendLayout()
        CType(Me.grdDPStreet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPedidosEC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uICommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.grpTraspasos)
        Me.explorerBar1.Controls.Add(Me.grpDetalle)
        Me.explorerBar1.Controls.Add(Me.grpPedidos)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 28)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(874, 378)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grpTraspasos
        '
        Me.grpTraspasos.BackColor = System.Drawing.Color.Transparent
        Me.grpTraspasos.Controls.Add(Me.btnFacturar)
        Me.grpTraspasos.Controls.Add(Me.nebFolioTraspaso)
        Me.grpTraspasos.Controls.Add(Me.btnAgregar)
        Me.grpTraspasos.Controls.Add(Me.Label5)
        Me.grpTraspasos.Controls.Add(Me.grdTraspasos)
        Me.grpTraspasos.Enabled = False
        Me.grpTraspasos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTraspasos.Location = New System.Drawing.Point(696, 8)
        Me.grpTraspasos.Name = "grpTraspasos"
        Me.grpTraspasos.Size = New System.Drawing.Size(168, 408)
        Me.grpTraspasos.TabIndex = 17
        Me.grpTraspasos.Text = "Facturar Pedido"
        Me.grpTraspasos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'btnFacturar
        '
        Me.btnFacturar.Icon = CType(resources.GetObject("btnFacturar.Icon"), System.Drawing.Icon)
        Me.btnFacturar.Location = New System.Drawing.Point(8, 325)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Size = New System.Drawing.Size(152, 40)
        Me.btnFacturar.TabIndex = 7
        Me.btnFacturar.Text = "Facturar"
        Me.btnFacturar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'nebFolioTraspaso
        '
        Me.nebFolioTraspaso.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebFolioTraspaso.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebFolioTraspaso.FormatString = "0000000000"
        Me.nebFolioTraspaso.Location = New System.Drawing.Point(8, 48)
        Me.nebFolioTraspaso.MaxLength = 10
        Me.nebFolioTraspaso.Name = "nebFolioTraspaso"
        Me.nebFolioTraspaso.Size = New System.Drawing.Size(112, 23)
        Me.nebFolioTraspaso.TabIndex = 6
        Me.nebFolioTraspaso.Text = "0000000000"
        Me.nebFolioTraspaso.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebFolioTraspaso.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebFolioTraspaso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnAgregar
        '
        Me.btnAgregar.Icon = CType(resources.GetObject("btnAgregar.Icon"), System.Drawing.Icon)
        Me.btnAgregar.Location = New System.Drawing.Point(120, 48)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(40, 24)
        Me.btnAgregar.TabIndex = 5
        Me.btnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 24)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Folio Traspaso"
        '
        'grdTraspasos
        '
        Me.grdTraspasos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdTraspasos.DesignTimeLayout = GridEXLayout1
        Me.grdTraspasos.GroupByBoxVisible = False
        Me.grdTraspasos.Location = New System.Drawing.Point(8, 80)
        Me.grdTraspasos.Name = "grdTraspasos"
        Me.grdTraspasos.Size = New System.Drawing.Size(152, 239)
        Me.grdTraspasos.TabIndex = 2
        Me.grdTraspasos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'grpDetalle
        '
        Me.grpDetalle.BackColor = System.Drawing.Color.Transparent
        Me.grpDetalle.Controls.Add(Me.lblDescripcion)
        Me.grpDetalle.Controls.Add(Me.lblCodigo)
        Me.grpDetalle.Controls.Add(Me.expNegados)
        Me.grpDetalle.Controls.Add(Me.ebAlmacenDestino)
        Me.grpDetalle.Controls.Add(Me.ebCodAlmacenDestino)
        Me.grpDetalle.Controls.Add(Me.Label4)
        Me.grpDetalle.Controls.Add(Me.ebPedidoEC)
        Me.grpDetalle.Controls.Add(Me.Label2)
        Me.grpDetalle.Controls.Add(Me.btnConfirmarTraspaso)
        Me.grpDetalle.Controls.Add(Me.grdDetallePedido)
        Me.grpDetalle.Controls.Add(Me.ebFolioTraspasoSAP)
        Me.grpDetalle.Controls.Add(Me.lblFolioTras)
        Me.grpDetalle.Controls.Add(Me.ebNombrePlayer)
        Me.grpDetalle.Controls.Add(Me.ebPlayer)
        Me.grpDetalle.Controls.Add(Me.lblCodVendedor)
        Me.grpDetalle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDetalle.Location = New System.Drawing.Point(184, 8)
        Me.grpDetalle.Name = "grpDetalle"
        Me.grpDetalle.Size = New System.Drawing.Size(504, 448)
        Me.grpDetalle.TabIndex = 4
        Me.grpDetalle.Text = "Detalle Pedido"
        Me.grpDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(117, 307)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(72, 13)
        Me.lblDescripcion.TabIndex = 19
        Me.lblDescripcion.Text = "Descripción"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(13, 307)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(48, 13)
        Me.lblCodigo.TabIndex = 18
        Me.lblCodigo.Text = "CodProv"
        '
        'expNegados
        '
        Me.expNegados.Controls.Add(Me.btnCancelar)
        Me.expNegados.Controls.Add(Me.btnConfirmarNegados)
        Me.expNegados.Controls.Add(Me.grdNegados)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Selecciona un motivo de negación del producto"
        Me.expNegados.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.expNegados.Location = New System.Drawing.Point(8, 371)
        Me.expNegados.Name = "expNegados"
        Me.expNegados.Size = New System.Drawing.Size(488, 352)
        Me.expNegados.TabIndex = 17
        Me.expNegados.Text = "ExplorerBar2"
        Me.expNegados.Visible = False
        Me.expNegados.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.Icon = CType(resources.GetObject("btnCancelar.Icon"), System.Drawing.Icon)
        Me.btnCancelar.Location = New System.Drawing.Point(288, 296)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(192, 40)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnConfirmarNegados
        '
        Me.btnConfirmarNegados.Icon = CType(resources.GetObject("btnConfirmarNegados.Icon"), System.Drawing.Icon)
        Me.btnConfirmarNegados.Location = New System.Drawing.Point(8, 296)
        Me.btnConfirmarNegados.Name = "btnConfirmarNegados"
        Me.btnConfirmarNegados.Size = New System.Drawing.Size(192, 40)
        Me.btnConfirmarNegados.TabIndex = 5
        Me.btnConfirmarNegados.Text = "Confirmar Negados"
        Me.btnConfirmarNegados.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdNegados
        '
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.grdNegados.DesignTimeLayout = GridEXLayout2
        Me.grdNegados.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdNegados.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.grdNegados.GroupByBoxVisible = False
        Me.grdNegados.Location = New System.Drawing.Point(8, 32)
        Me.grdNegados.Name = "grdNegados"
        Me.grdNegados.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdNegados.Size = New System.Drawing.Size(472, 240)
        Me.grdNegados.TabIndex = 3
        Me.grdNegados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAlmacenDestino
        '
        Me.ebAlmacenDestino.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAlmacenDestino.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAlmacenDestino.BackColor = System.Drawing.SystemColors.Info
        Me.ebAlmacenDestino.Location = New System.Drawing.Point(184, 43)
        Me.ebAlmacenDestino.Name = "ebAlmacenDestino"
        Me.ebAlmacenDestino.ReadOnly = True
        Me.ebAlmacenDestino.Size = New System.Drawing.Size(312, 23)
        Me.ebAlmacenDestino.TabIndex = 15
        Me.ebAlmacenDestino.TabStop = False
        Me.ebAlmacenDestino.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlmacenDestino.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodAlmacenDestino
        '
        Me.ebCodAlmacenDestino.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodAlmacenDestino.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodAlmacenDestino.BackColor = System.Drawing.SystemColors.Info
        Me.ebCodAlmacenDestino.Location = New System.Drawing.Point(120, 43)
        Me.ebCodAlmacenDestino.Name = "ebCodAlmacenDestino"
        Me.ebCodAlmacenDestino.ReadOnly = True
        Me.ebCodAlmacenDestino.Size = New System.Drawing.Size(64, 23)
        Me.ebCodAlmacenDestino.TabIndex = 14
        Me.ebCodAlmacenDestino.TabStop = False
        Me.ebCodAlmacenDestino.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebCodAlmacenDestino.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 24)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Destino"
        '
        'ebPedidoEC
        '
        Me.ebPedidoEC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPedidoEC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPedidoEC.BackColor = System.Drawing.SystemColors.Info
        Me.ebPedidoEC.Location = New System.Drawing.Point(120, 16)
        Me.ebPedidoEC.Name = "ebPedidoEC"
        Me.ebPedidoEC.ReadOnly = True
        Me.ebPedidoEC.Size = New System.Drawing.Size(128, 23)
        Me.ebPedidoEC.TabIndex = 12
        Me.ebPedidoEC.TabStop = False
        Me.ebPedidoEC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebPedidoEC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 24)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Pedido SAP"
        '
        'btnConfirmarTraspaso
        '
        Me.btnConfirmarTraspaso.Icon = CType(resources.GetObject("btnConfirmarTraspaso.Icon"), System.Drawing.Icon)
        Me.btnConfirmarTraspaso.Location = New System.Drawing.Point(8, 325)
        Me.btnConfirmarTraspaso.Name = "btnConfirmarTraspaso"
        Me.btnConfirmarTraspaso.Size = New System.Drawing.Size(216, 40)
        Me.btnConfirmarTraspaso.TabIndex = 3
        Me.btnConfirmarTraspaso.Text = "Realizar Traspaso"
        Me.btnConfirmarTraspaso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdDetallePedido
        '
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.grdDetallePedido.DesignTimeLayout = GridEXLayout3
        Me.grdDetallePedido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetallePedido.GroupByBoxVisible = False
        Me.grdDetallePedido.Location = New System.Drawing.Point(8, 96)
        Me.grdDetallePedido.Name = "grdDetallePedido"
        Me.grdDetallePedido.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdDetallePedido.Size = New System.Drawing.Size(488, 208)
        Me.grdDetallePedido.TabIndex = 2
        Me.grdDetallePedido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolioTraspasoSAP
        '
        Me.ebFolioTraspasoSAP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioTraspasoSAP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioTraspasoSAP.BackColor = System.Drawing.SystemColors.Info
        Me.ebFolioTraspasoSAP.Location = New System.Drawing.Point(368, 16)
        Me.ebFolioTraspasoSAP.Name = "ebFolioTraspasoSAP"
        Me.ebFolioTraspasoSAP.ReadOnly = True
        Me.ebFolioTraspasoSAP.Size = New System.Drawing.Size(128, 23)
        Me.ebFolioTraspasoSAP.TabIndex = 1
        Me.ebFolioTraspasoSAP.TabStop = False
        Me.ebFolioTraspasoSAP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebFolioTraspasoSAP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFolioTras
        '
        Me.lblFolioTras.Location = New System.Drawing.Point(264, 19)
        Me.lblFolioTras.Name = "lblFolioTras"
        Me.lblFolioTras.Size = New System.Drawing.Size(104, 24)
        Me.lblFolioTras.TabIndex = 0
        Me.lblFolioTras.Text = "Folio Traspaso"
        '
        'ebNombrePlayer
        '
        Me.ebNombrePlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombrePlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombrePlayer.BackColor = System.Drawing.SystemColors.Info
        Me.ebNombrePlayer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNombrePlayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombrePlayer.Location = New System.Drawing.Point(217, 68)
        Me.ebNombrePlayer.Name = "ebNombrePlayer"
        Me.ebNombrePlayer.ReadOnly = True
        Me.ebNombrePlayer.Size = New System.Drawing.Size(279, 21)
        Me.ebNombrePlayer.TabIndex = 22
        Me.ebNombrePlayer.TabStop = False
        Me.ebNombrePlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombrePlayer.Visible = False
        Me.ebNombrePlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
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
        Me.ebPlayer.Location = New System.Drawing.Point(120, 68)
        Me.ebPlayer.MaxLength = 10
        Me.ebPlayer.Name = "ebPlayer"
        Me.ebPlayer.Size = New System.Drawing.Size(96, 22)
        Me.ebPlayer.TabIndex = 21
        Me.ebPlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayer.Visible = False
        Me.ebPlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCodVendedor
        '
        Me.lblCodVendedor.Location = New System.Drawing.Point(6, 66)
        Me.lblCodVendedor.Name = "lblCodVendedor"
        Me.lblCodVendedor.Size = New System.Drawing.Size(104, 24)
        Me.lblCodVendedor.TabIndex = 20
        Me.lblCodVendedor.Text = "Player"
        Me.lblCodVendedor.Visible = False
        '
        'grpPedidos
        '
        Me.grpPedidos.BackColor = System.Drawing.Color.Transparent
        Me.grpPedidos.Controls.Add(Me.grdDPStreet)
        Me.grpPedidos.Controls.Add(Me.lblPedidosDPStreet)
        Me.grpPedidos.Controls.Add(Me.lblPedidosDportenis)
        Me.grpPedidos.Controls.Add(Me.btnBuscarTraspasos)
        Me.grpPedidos.Controls.Add(Me.grdPedidosEC)
        Me.grpPedidos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPedidos.Location = New System.Drawing.Point(8, 8)
        Me.grpPedidos.Name = "grpPedidos"
        Me.grpPedidos.Size = New System.Drawing.Size(168, 416)
        Me.grpPedidos.TabIndex = 3
        Me.grpPedidos.Text = "Pedidos Pendientes"
        Me.grpPedidos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'grdDPStreet
        '
        Me.grdDPStreet.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdDPStreet.AlternatingColors = True
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.grdDPStreet.DesignTimeLayout = GridEXLayout4
        Me.grdDPStreet.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdDPStreet.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdDPStreet.GroupByBoxVisible = False
        Me.grdDPStreet.Location = New System.Drawing.Point(8, 192)
        Me.grdDPStreet.Name = "grdDPStreet"
        Me.grdDPStreet.Size = New System.Drawing.Size(152, 128)
        Me.grdDPStreet.TabIndex = 14
        Me.grdDPStreet.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPedidosDPStreet
        '
        Me.lblPedidosDPStreet.Location = New System.Drawing.Point(16, 168)
        Me.lblPedidosDPStreet.Name = "lblPedidosDPStreet"
        Me.lblPedidosDPStreet.Size = New System.Drawing.Size(144, 24)
        Me.lblPedidosDPStreet.TabIndex = 13
        Me.lblPedidosDPStreet.Text = "Pedidos DPStreet"
        Me.lblPedidosDPStreet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPedidosDportenis
        '
        Me.lblPedidosDportenis.Location = New System.Drawing.Point(16, 16)
        Me.lblPedidosDportenis.Name = "lblPedidosDportenis"
        Me.lblPedidosDportenis.Size = New System.Drawing.Size(144, 24)
        Me.lblPedidosDportenis.TabIndex = 12
        Me.lblPedidosDportenis.Text = "Pedidos Dportenis"
        Me.lblPedidosDportenis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBuscarTraspasos
        '
        Me.btnBuscarTraspasos.Image = CType(resources.GetObject("btnBuscarTraspasos.Image"), System.Drawing.Image)
        Me.btnBuscarTraspasos.Location = New System.Drawing.Point(8, 325)
        Me.btnBuscarTraspasos.Name = "btnBuscarTraspasos"
        Me.btnBuscarTraspasos.Size = New System.Drawing.Size(152, 40)
        Me.btnBuscarTraspasos.TabIndex = 5
        Me.btnBuscarTraspasos.Text = "Buscar Pedidos Pendientes"
        Me.btnBuscarTraspasos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdPedidosEC
        '
        Me.grdPedidosEC.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdPedidosEC.AlternatingColors = True
        GridEXLayout5.LayoutString = resources.GetString("GridEXLayout5.LayoutString")
        Me.grdPedidosEC.DesignTimeLayout = GridEXLayout5
        Me.grdPedidosEC.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdPedidosEC.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdPedidosEC.GroupByBoxVisible = False
        Me.grdPedidosEC.Location = New System.Drawing.Point(8, 40)
        Me.grdPedidosEC.Name = "grdPedidosEC"
        Me.grdPedidosEC.Size = New System.Drawing.Size(152, 128)
        Me.grdPedidosEC.TabIndex = 2
        Me.grdPedidosEC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uICommandManager1
        '
        Me.uICommandManager1.BottomRebar = Me.BottomRebar1
        Me.uICommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.uICommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.AsignarGuia, Me.ReimprimirNotaVenta, Me.menuSalir, Me.menuDescargarGuia})
        Me.uICommandManager1.ContainerControl = Me
        '
        '
        '
        Me.uICommandManager1.EditContextMenu.Key = ""
        Me.uICommandManager1.Id = New System.Guid("d939aa19-d209-4e60-a652-0af13fd49d82")
        Me.uICommandManager1.LeftRebar = Me.LeftRebar1
        Me.uICommandManager1.LockCommandBars = True
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.AsignarGuia1, Me.Separator1, Me.ReimprimirNotaVenta1, Me.Separator2, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(323, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'AsignarGuia1
        '
        Me.AsignarGuia1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.AsignarGuia1.Icon = CType(resources.GetObject("AsignarGuia1.Icon"), System.Drawing.Icon)
        Me.AsignarGuia1.Key = "menuAsignarGuia"
        Me.AsignarGuia1.Name = "AsignarGuia1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'ReimprimirNotaVenta1
        '
        Me.ReimprimirNotaVenta1.Image = CType(resources.GetObject("ReimprimirNotaVenta1.Image"), System.Drawing.Image)
        Me.ReimprimirNotaVenta1.Key = "menuReimprimir"
        Me.ReimprimirNotaVenta1.Name = "ReimprimirNotaVenta1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuSalir1
        '
        Me.menuSalir1.Icon = CType(resources.GetObject("menuSalir1.Icon"), System.Drawing.Icon)
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'AsignarGuia
        '
        Me.AsignarGuia.Key = "menuAsignarGuia"
        Me.AsignarGuia.Name = "AsignarGuia"
        Me.AsignarGuia.Text = "Asignar Guías"
        '
        'ReimprimirNotaVenta
        '
        Me.ReimprimirNotaVenta.Key = "menuReimprimir"
        Me.ReimprimirNotaVenta.Name = "ReimprimirNotaVenta"
        Me.ReimprimirNotaVenta.Text = "Reimpirmir Nota de Venta"
        '
        'menuSalir
        '
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
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
        Me.TopRebar1.Size = New System.Drawing.Size(874, 28)
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        '
        'frmTraspasoAutoEcommerce
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(874, 406)
        Me.Controls.Add(Me.explorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmTraspasoAutoEcommerce"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Petición de Surtido Para Ecommerce"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grpTraspasos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTraspasos.ResumeLayout(False)
        CType(Me.grdTraspasos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetalle.ResumeLayout(False)
        Me.grpDetalle.PerformLayout()
        CType(Me.expNegados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expNegados.ResumeLayout(False)
        CType(Me.grdNegados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallePedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPedidos.ResumeLayout(False)
        CType(Me.grdDPStreet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPedidosEC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uICommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dtTraspasos As DataTable
    Dim dtPedidos As DataTable
    Dim dtCabeceraSH As DataTable 'RGERMAIN 17/04/2013: Cabecera de solicitudes de los pedidos Si Hay
    Dim dtPedidosDet As DataTable
    Dim dtTrasModif As New DataTable
    Dim dtDetalle As DataTable
    Dim dtNegados As DataTable
    Dim dtConfirmados As DataTable
    Dim dtConcentracion As DataTable
    Dim dtMotivosNegados As DataTable
    Dim oTraspasoSMgr As TraspasosSalidaManager
    Dim oArticulosMgr As CatalogoArticuloManager
    Dim oSAPMgr As ProcesoSAPManager
    Dim oCatalogoTransportistasMgr As CatalogoTransportistaManager
    Dim oAlmacenMgr As CatalogoAlmacenesManager
    Dim oAlmacen As Almacen
    Dim UserSessionAplicated As String = ""
    Dim UserNameAplicated As String = ""
    Dim bFacturar As Boolean = False
    Dim bConcen As Boolean = False
    Dim CentroConcentrador As String = ""
    Dim Status As String = ""
    Dim oFacturaMgr As FacturaManager
    Public Modulo As String = ""
    Dim strCentroSAP As String = "" 'Mi Centro en SAP
    Private dtPedidosDPortenis As DataTable
    Private dtPedidosDPStreet As DataTable
    Private VersionEcommerce As String = ""
    '-------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 01/09/2015: Traspaso de entrada para su registro
    '-------------------------------------------------------------------------------------------------------------------------
    Private oTraspasoEntradaMgr As TraspasosEntradaManager
    Private oTraspasoEntrada As TraspasoEntrada
    Private row As DataRow = Nothing
    Private row_cab As DataRow = Nothing
    Private view_det As DataView = Nothing
    Private guias As Hashtable
    Private CtoSuministrador As String = ""

    Private AsignarGuiaEC As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (29.03.2016): ID de Solicitud de Pedido de EC
    '-------------------------------------------------------------------------------------------------------------------------
    Private SolicitudID As String = String.Empty

    Private Sub Inicializar()

        'FillMotivosNegados()

        dtPedidos = New DataTable("PedidosPendientes")

        dtTraspasos = New DataTable("Traspasos")
        dtTraspasos.Columns.Add(New DataColumn("FolioTraspaso", GetType(String)))
        dtTraspasos.AcceptChanges()

        oTraspasoSMgr = New TraspasosSalidaManager(oAppContext, oConfigCierreFI)

        oArticulosMgr = New CatalogoArticuloManager(oAppContext)

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        oCatalogoTransportistasMgr = New CatalogoTransportistaManager(oAppContext)

        oAlmacenMgr = New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)

        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)

        FillMotivosValueList()

        CreaEstructuraDetalle()

        strCentroSAP = oSAPMgr.Read_Centros

    End Sub

    Private Sub ModificarPantalla()
        Select Case Modulo.Trim.ToUpper
            Case "PP"
                '------------------------------------------------------------------
                ' JNAVA (18.02.2015): Adecuaciones por retail
                '------------------------------------------------------------------
                Me.Text = "Envio de Pedido para Ecommerce" '"Petición de Surtido Para Ecommerce"
                '------------------------------------------------------------------
                Me.Width = 704
                ebPlayer.Visible = True
                ebNombrePlayer.Visible = True
                lblCodVendedor.Visible = True
                If oConfigCierreFI.AplicarSurtidoDPStreet = True Then
                    Me.grpTraspasos.Visible = False
                    Me.lblPedidosDportenis.Visible = True
                    Me.lblPedidosDPStreet.Visible = True
                    Me.grdDPStreet.Visible = True
                Else
                    Me.grdPedidosEC.Size = New Size(152, 288)
                    Me.grdPedidosEC.Location = New Point(8, 24)
                    Me.lblPedidosDportenis.Visible = False
                    Me.lblPedidosDPStreet.Visible = False
                    Me.grdDPStreet.Visible = False
                End If
                '------------------------------------------------------------------
                ' JNAVA (18.02.2015): Adecuaciones por retail
                '------------------------------------------------------------------
                Me.lblFolioTras.Text = "Folio Entrega"
                Me.btnConfirmarTraspaso.Text = "Enviar Pedido"
                Me.UiCommandBar1.Commands("menuAsignarGuia").Visible = Janus.Windows.UI.InheritableBoolean.False
            Case ("PF") 'YA NO SE USARA!
                Me.Text = "Facturar Pedidos de Ecommerce"
                Me.Width = "368"
                Me.grpTraspasos.Left = 184
                Me.grpDetalle.Visible = False
                If oConfigCierreFI.AplicarSurtidoDPStreet = True Then
                    Me.lblPedidosDportenis.Visible = True
                    Me.lblPedidosDPStreet.Visible = True
                    Me.grdDPStreet.Visible = True
                Else
                    Me.grdPedidosEC.Size = New Size(152, 288)
                    Me.grdPedidosEC.Location = New Point(8, 24)
                    Me.lblPedidosDportenis.Visible = False
                    Me.lblPedidosDPStreet.Visible = False
                    Me.grdDPStreet.Visible = False
                End If
            Case "PPSH"
                Me.Text = "Petición de Surtido Para ""Si Hay"""
                Me.Width = 704
                Me.grpTraspasos.Visible = False
                Me.grdPedidosEC.Size = New Size(152, 288)
                Me.grdPedidosEC.Location = New Point(8, 24)
                Me.lblPedidosDportenis.Visible = False
                Me.lblPedidosDPStreet.Visible = False
                Me.grdDPStreet.Visible = False
                Me.UiCommandBar1.Commands("menuReimprimir").Visible = Janus.Windows.UI.InheritableBoolean.False
                ebPlayer.Visible = False
                ebNombrePlayer.Visible = False
                lblCodVendedor.Visible = False
            Case "PRSH"
                Me.Text = "Recibir Traslados Para Pedidos ""Si Hay"""
                Me.Width = "368"
                Me.grpTraspasos.Left = 184
                Me.grpDetalle.Visible = False
                Me.grdPedidosEC.Size = New Size(152, 288)
                Me.grdPedidosEC.Location = New Point(8, 24)
                Me.lblPedidosDportenis.Visible = False
                Me.lblPedidosDPStreet.Visible = False
                Me.grdDPStreet.Visible = False
                Me.btnFacturar.Text = "Recibir Productos"
                Me.grpTraspasos.Text = "Recibir Producto"
                If oConfigCierreFI.RegistrosTraspasoSiHay = True Then
                    oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
                End If
                Me.UiCommandBar1.Commands("menuReimprimir").Visible = Janus.Windows.UI.InheritableBoolean.False
                Me.UiCommandBar1.Commands("menuAsignarGuia").Visible = Janus.Windows.UI.InheritableBoolean.False
                ebPlayer.Visible = False
                ebNombrePlayer.Visible = False
                lblCodVendedor.Visible = False
            Case "PFSH"
                Me.Text = "Facturar Pedidos Si Hay"
                Me.Width = "368"
                Me.grpTraspasos.Left = 184
                Me.grpDetalle.Visible = False
                Me.grdPedidosEC.Size = New Size(152, 288)
                Me.grdPedidosEC.Location = New Point(8, 24)
                Me.lblPedidosDportenis.Visible = False
                Me.lblPedidosDPStreet.Visible = False
                Me.grdDPStreet.Visible = False
                ebPlayer.Visible = False
                ebNombrePlayer.Visible = False
                lblCodVendedor.Visible = False
                Me.UiCommandBar1.Commands("menuAsignarGuia").Visible = Janus.Windows.UI.InheritableBoolean.False
        End Select
    End Sub

    Private Sub BuscarPedidosPendientes(Optional ByVal bMsg As Boolean = False)

        Limpiar(False)
        '-------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 16/04/2013: Ejecutamos la RFC dependiendo del modulo origen de acceso
        '-------------------------------------------------------------------------------------------------------------------------------------
        Dim htStatus As Hashtable
        Select Case Modulo.Trim.ToUpper
            Case "PPSH"

                htStatus = New Hashtable(3)

                htStatus(1) = "P" 'Pedidos Pendientes
                htStatus(2) = "RP" 'Resolicitudes Pendientes
                htStatus(3) = "PE-F" 'Pendientes de Envio Foraneo
                htStatus(4) = "PE-L" 'Pendientes de Envio Local
                dtPedidos = oSAPMgr.ZSH_PEDIDOS_PENDIENTES(strCentroSAP, dtCabeceraSH, dtPedidosDet, htStatus)
            Case "PRSH"
                htStatus = New Hashtable(0)

                htStatus(1) = "PR" 'Pedidos Pendientes de Recibir
                dtPedidos = oSAPMgr.ZSH_PEDIDOS_PENDIENTES(strCentroSAP, dtCabeceraSH, dtPedidosDet, htStatus)
            Case "PFSH"
                htStatus = New Hashtable(0)

                htStatus(1) = "PF" 'Pedidos Pendientes de Facturar
                dtPedidos = oSAPMgr.ZSH_PEDIDOS_PENDIENTES(strCentroSAP, dtCabeceraSH, dtPedidosDet, htStatus)
            Case "PP", "PF"
                dtPedidos = oSAPMgr.ZPOL_TRASLPEN(strCentroSAP, dtPedidosDet, dtTrasModif)
        End Select

        Dim oCol As New DataColumn("Modificado")
        oCol.DataType = GetType(Integer)
        oCol.DefaultValue = 0
        dtPedidos.Columns.Add(oCol)
        dtPedidos.AcceptChanges()

        If Not dtPedidos Is Nothing AndAlso dtPedidos.Rows.Count > 0 Then
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 16/04/2013: Si son pedidos del Ecommerce entonces filtramos los pedidos según el módulo del que se accesó a esta pantalla 
            '(Pedientes Surtir o Pendientes Facturar) de lo contrario no es necesario porque los pedidos SH ya vienen filtrados desde SAP
            '------------------------------------------------------------------------------------------------------------------------------------
            If InStr("PRSH,PFSH,", Modulo.Trim.ToUpper & ",") <= 0 Then SepararPedidos(dtPedidos, dtCabeceraSH)
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 12/06/2013: En caso de ser pedidos SH se agrupan para que solo muestre un folio de pedido aunque tenga varias solicitudes
            '------------------------------------------------------------------------------------------------------------------------------------
            Select Case Modulo.Trim.ToUpper
                Case "PPSH", "PRSH", "PFSH"
                    AgruparPedidosSH(dtPedidos)
            End Select
            '------------------------------------------------------------------------------------------------------------------------------------
            'Marcamos los pedidos que ya habian sido tratados pero se modificaron solicitando mas piezas a la tienda
            '------------------------------------------------------------------------------------------------------------------------------------
            RevisarTraspasosModificados()
            '------------------------------------------------------------------------------------------------------------------------------------
            'Actualizamos el grid con los pedidos pendientes
            '------------------------------------------------------------------------------------------------------------------------------------
            ActualizaGridPedidosPendientes()

            Me.grdDetallePedido.Focus()
        ElseIf bMsg Then
            Select Case Modulo.Trim.ToUpper
                Case "PP", "PPSH"
                    MessageBox.Show("No se encontraron pedidos pendientes por surtir.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Case "PF"
                    MessageBox.Show("No se encontraron pedidos pendientes por facturar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Case "PRSH"
                    MessageBox.Show("No se encontraron pedidos con producto pendiente por recepcionar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Select
        End If

    End Sub

    'Private Sub AgruparPedidosSH(ByRef dtPed As DataTable)

    '    Dim dtTemp As DataTable = dtPed.Clone
    '    Dim oRow As DataRow, strPedidos As String = ""

    '    For Each oRow In dtPed.Rows
    '        If InStr(strPedidos.Trim, CStr(oRow!VBELN).Trim) <= 0 Then
    '            strPedidos &= CStr(oRow!VBELN).Trim & ","
    '            dtTemp.ImportRow(oRow)
    '        End If
    '    Next

    '    dtPed = dtTemp.Copy

    'End Sub

    Private Sub SepararPedidos(ByRef dtPed As DataTable, Optional ByVal dtCabSH As DataTable = Nothing)

        Dim oRowV As DataRowView
        Dim dtTemp As DataTable
        Dim dvPed As DataView
        Dim strFilter As String = ""
        '-----------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 18/04/2013: Filtramos segun el modulo de acceso origen
        '-----------------------------------------------------------------------------------------------------------------------------------
        Select Case Modulo.Trim.ToUpper
            Case "PP" 'Pedidos Pendientes por Surtir
                strFilter = "Status = 'P' And Facturar = ''"
                dtTemp = dtPed.Copy
            Case "PF" 'Pedidos Pendientes por Facturar
                strFilter = "Status <> 'P' And Facturar = 'X'"
                dtTemp = dtPed.Copy
            Case "PPSH" 'Pedidos Pendientes por Surtir Si Hay
                strFilter = "Status_Sum = 'P' Or Status_Sum = 'RP'"
                dtTemp = dtCabSH.Copy
        End Select

        'dtTemp = dtPed.Copy

        dvPed = New DataView(dtTemp, strFilter.Trim, "", DataViewRowState.CurrentRows)

        dtPed.Clear()
        For Each oRowV In dvPed
            dtPed.ImportRow(oRowV.Row)
        Next
        dtPed.AcceptChanges()

    End Sub

    Private Function ValidaCampos() As Boolean

        Dim bRes As Boolean = True

        If Me.ebPedidoEC.Text.Trim = "" Then
            MessageBox.Show("Debe seleccionar un pedido pendiente por surtir.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.grdPedidosEC.Focus()
            bRes = False
        ElseIf Me.dtDetalle Is Nothing OrElse Me.dtDetalle.Rows.Count <= 0 Then
            MessageBox.Show("No hay códigos por surtir.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.grdPedidosEC.Focus()
            bRes = False
        ElseIf ValidaDetalle(dtDetalle) = False Then
            Me.grdDetallePedido.Focus()
            bRes = False
        ElseIf guias Is Nothing AndAlso AsignarGuiaEC Then ' JMNA (18.02.2016): Se agrego validacion para adecuaciones de Pedidos de EC en retail
            MessageBox.Show("No se añadio guía", "Dportenis Retail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.grdDetallePedido.Focus()
            bRes = False   'comentado MLVARGAS PARA PODER PROBAR QUITAR
        ElseIf guias Is Nothing AndAlso Modulo = "PPSH" AndAlso AsignarGuiaEC = False AndAlso TodosSonNegados() = False Then
            MessageBox.Show("No se añadio guía", "Dportenis Retail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.grdDetallePedido.Focus()
            bRes = False
        End If

        Return bRes

    End Function

    Private Function TodosSonNegados() As Boolean
        Dim valido As Boolean = False
        Dim todosnegado As Integer = 0
        For Each oRow As DataRow In dtDetalle.Rows
            If (oRow!Negados - oRow!Cantidad) = 0 Then
                todosnegado += 1
            End If
        Next
        If dtDetalle.Rows.Count = todosnegado Then
            valido = True
        Else
            valido = False
        End If
        Return valido
    End Function

    Private Function ValidaDetalle(ByVal dtTemp As DataTable) As Boolean

        Dim strMateriales As String = ""
        Dim oRow As DataRow
        Dim oArticulo As Articulo
        Dim bRes As Boolean = True

        For Each oRow In dtTemp.Rows
            oArticulo = Nothing
            oArticulo = oArticulosMgr.Load(CStr(oRow!Codigo))
            If oArticulo Is Nothing Then
                strMateriales = CStr(oRow!Codigo) & vbCrLf
            End If
        Next

        If strMateriales.Trim <> "" Then
            strMateriales = "Los siguientes artículos no se encuentran en su catalogo favor de hacer la descarga:" & vbCrLf & strMateriales
            MessageBox.Show(strMateriales, "Valida Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
        End If

        Return bRes

    End Function

    Private Sub FiltrarConfirmadosYNegados(ByRef dtConfirm As DataTable, ByRef dtNeg As DataTable)

        Dim oRow As DataRow
        Dim oNewRow As DataRow

        If Not dtDetalle Is Nothing AndAlso dtDetalle.Rows.Count > 0 Then
            dtConfirm = dtDetalle.Clone
            dtNeg = dtDetalle.Clone
            dtConfirm.Columns.Add("Confirmados", GetType(Integer))
            dtConfirm.AcceptChanges()
            dtNeg.Columns.Add("TotalNegados", GetType(Integer))
            dtNeg.Columns.Add("Agregado", GetType(Boolean))
            dtNeg.Columns.Add("Motivo", GetType(String))
            dtNeg.AcceptChanges()
            For Each oRow In dtDetalle.Rows
                If oRow!Negados > 0 Then dtNeg.ImportRow(oRow)
                If oRow!Cantidad - oRow!Negados > 0 Then dtConfirm.ImportRow(oRow)
            Next
            For Each oRow In dtNeg.Rows
                oRow!TotalNegados = oRow!Negados
                oRow!Agregado = False
                oRow!Motivo = ""
            Next
            For Each oRow In dtConfirmados.Rows
                oRow!Confirmados = oRow!Cantidad - oRow!Negados
            Next
            dtConfirm.AcceptChanges()
            dtNeg.AcceptChanges()
        End If

    End Sub

    Private Sub SeleccionarMotivosNegados()

        '-----------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (17.03.2016): Se pide usuario y contraseña para ver si tiene permisos o no
        '-----------------------------------------------------------------------------------------------------------------------------------------
        oAppContext.Security.CloseImpersonatedSession()
        If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida") Then
            oAppContext.Security.CloseImpersonatedSession()
            Exit Sub
        Else
            UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
            UserNameAplicated = oAppContext.Security.CurrentUser.Name
            oAppContext.Security.CloseImpersonatedSession()
        End If

        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Separamos los codigos negados y los confirmados
        '-----------------------------------------------------------------------------------------------------------------------------------------
        FiltrarConfirmadosYNegados(dtConfirmados, dtNegados)
        If oConfigCierreFI.BloqueaBajaCalidad = True Then
            If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                If MessageBox.Show("Los artículos negados seran bloqueados, no podra ser usado para las operaciones de Ventas y Traspasos de Salidas." & vbCrLf & "¿Desea Continuar?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                End If
            End If
        End If

        '-----------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (18.02.2016): Validamos la cantidad de confirmados para EC para saber si se asigna guia o no
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If Me.Modulo = "PP" Then
            Dim CantCon As Integer = 0
            If ebPlayer.Text.Trim() = "" Then
                MessageBox.Show("No se ha capturado el vendedor", "Dportenis Retail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.grdDetallePedido.Focus()
                Exit Sub
            End If
        '-----------------------------------------------------------------------------------------------------------------------------------------
        ' Obtenemos el total de Confirmados
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If Not dtConfirmados Is Nothing AndAlso dtConfirmados.Rows.Count > 0 Then
            For Each oRow As DataRow In dtConfirmados.Rows
                CantCon += oRow!Confirmados
            Next
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------------
        ' Si al menos se confirmo un articulo, se asigna guia. Si no, no se asigna nada
        '-----------------------------------------------------------------------------------------------------------------------------------------
            If CantCon > 0 Then
                AsignarGuiaEC = True
                AsignarNumGuia()
            Else
                guias = Nothing
                AsignarGuiaEC = False
            End If            
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------------

        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Validamos que no falte ningun dato
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If ValidaCampos() Then

            '-------------------------------------------------------------------------------------------------------------------------------------
            'Mostramos el grid para elegir los motivos de negacion
            '-------------------------------------------------------------------------------------------------------------------------------------
            If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                ActualizaGridNegados()
                Me.expNegados.Left = 8
                Me.expNegados.Top = 24
                Me.expNegados.Visible = True
            Else
                'oAppContext.Security.CloseImpersonatedSession()
                'If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida") Then
                '    oAppContext.Security.CloseImpersonatedSession()
                'Else
                '    UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
                '    UserNameAplicated = oAppContext.Security.CurrentUser.Name
                '    oAppContext.Security.CloseImpersonatedSession()

                '-----------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (18.02.2016): Si es Pedido de EC, se realiza el nuevo proceso
                '-----------------------------------------------------------------------------------------------------------------------------------------
                If Me.Modulo = "PP" Then
                    EnviarPedidoEC()
                Else
                    GenerarTraspaso()
                End If

                'End If
            End If
        End If

    End Sub

    Private Sub ConfirmarNegados()

        Dim oRow As DataRow
        Dim bRes As Boolean = True
        Dim bCant As Boolean = True

        For Each oRow In dtNegados.Rows
            If CStr(oRow!Motivo).Trim = "" Then
                bRes = False
                Exit For
            ElseIf CInt(oRow!Negados) = 0 Then
                bCant = False
                Exit For
            End If
        Next

        If bCant = False Then
            MessageBox.Show("Es necesario indicar la cantidad de piezas negadas de todos los productos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.grdNegados.Focus()
        ElseIf bRes = False Then
            MessageBox.Show("Es necesario seleccionar el motivo por el cual esta negando el producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.grdNegados.Focus()
        ElseIf ValidaDetalleNegados(dtNegados) = True Then
            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida") Then
                oAppContext.Security.CloseImpersonatedSession()
            Else
                UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
                UserNameAplicated = oAppContext.Security.CurrentUser.Name
                oAppContext.Security.CloseImpersonatedSession()
                Dim negados As DataTable = dtNegados.Copy()

                '-----------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (29.03.2016): Si es Pedido de EC, se realiza el nuevo proceso
                '-----------------------------------------------------------------------------------------------------------------------------------------
                If Me.Modulo = "PP" Then
                    EnviarPedidoEC()
                Else
                    GenerarTraspaso()
                End If

                '---------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 12/06/2015: Se bloqueara articulos de Baja Calidad en SAP en caso de que este habilitada la configuración
                '---------------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.BloqueaBajaCalidad = True Then
                    SaveDefectuosos(negados)
                End If
            End If
            'oAppContext.Security.CloseImpersonatedSession()
        End If

    End Sub

    Private Sub GenerarTraspaso()
        Dim htStatus As Hashtable
        '----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 19/04/2013: Antes de continuar a generar el traspaso para surtir el pedido, revisamos si el pedido no ha sido cancelado en 
        'este momento segun el modulo desde donde se accesó
        '----------------------------------------------------------------------------------------------------------------------------------------
        If EstaPedidoCancelado(Me.ebPedidoEC.Text.Trim, Modulo.Trim.ToUpper) Then
            MessageBox.Show("El pedido ha sido cancelado en este momento, no es posible continuar con el surtido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            GoTo Final
        End If
        '----------------------------------------------------------------------------------------------------------------------------------------
        'Asignamos el motivo de negacion a las piezas negadas por la sucursal
        '----------------------------------------------------------------------------------------------------------------------------------------
        SetMotivoNegDesc(dtNegados)
        '----------------------------------------------------------------------------------------------------------------------------------------
        'Desbloqueamos los codigos en SAP para realizar el traslado
        '----------------------------------------------------------------------------------------------------------------------------------------
        'oSAPMgr.ZBAPIMM14_DESBLOQUEOART(Me.ebPedidoEC.Text, dtConfirmados)
        '----------------------------------------------------------------------------------------------------------------------------------------
        'Aplicamos el traspaso de salida con las piezas confirmadas
        '----------------------------------------------------------------------------------------------------------------------------------------
        If Not dtConfirmados Is Nothing AndAlso dtConfirmados.Rows.Count > 0 Then
            If ValidarExistencia(dtConfirmados).Trim = "" Then
                If GenerarTraspasoSalida(dtConfirmados, Me.ebPedidoEC.Text.Trim, Me.ebCodAlmacenDestino.Text, UserSessionAplicated, "") = False Then
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        End If
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Actualizamos el status en la tabla de traspasos pendientes por surtir en SAP y agregamos los codigos confirmados en caso de existir
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim bModificado As Boolean = False
        Dim strMsg As String = ""
        If oConfigCierreFI.AplicarSurtidoDPStreet = True Then
            If Me.VersionEcommerce.Trim() = "DPT" Then
                bModificado = CBool(Me.grdPedidosEC.GetRow.DataRow!Modificado)
            ElseIf Me.VersionEcommerce.Trim() = "DPS" Then
                bModificado = CBool(Me.grdDPStreet.GetRow().DataRow!Modificado)
            Else
                bModificado = CBool(Me.grdPedidosEC.GetRow.DataRow!Modificado)
            End If
        Else
            bModificado = CBool(Me.grdPedidosEC.GetRow.DataRow!Modificado)
        End If



        If dtConfirmados.Rows.Count > 0 AndAlso dtNegados.Rows.Count > 0 Then
            Status = "PS"
            If bModificado Then
                strMsg = "Para esta nueva solicitud, los artículos indicados se agregaron correctamente"
            Else
                strMsg = "El pedido se ha surtido correctamente"
            End If
        ElseIf dtConfirmados.Rows.Count > 0 Then
            Status = "S"
            If bModificado Then
                strMsg = "Para esta nueva solicitud, los artículos indicados se agregaron correctamente"
            Else
                strMsg = "El pedido se ha surtido correctamente"
            End If
        ElseIf dtNegados.Rows.Count > 0 Then
            Status = "N"
            If bModificado Then
                strMsg = "Para esta nueva solicitud, los artículos indicados se han negado correctamente"
            Else
                strMsg = "El pedido se ha Negado correctamente."
            End If
        End If
        '---------------------------------------------------------------------------------------------------------------------------------
        'Obtenemos el status del repedido, revisando las piezas confirmadas en el detalle
        '---------------------------------------------------------------------------------------------------------------------------------
        If bModificado Then
            Status = ""
            Status = GetStatusRePedido()
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 28/05/2013: Ahora marcamos primero todos los faltantes como de baja calidad para que Ecommerce no los vea en el inventario de la 
        'tienda y en caso de los pedidos SH para que cuando haga la nueva solicitud de lo negado ya no tome este centro en cuenta para dicha
        'solicitud
        '-----------------------------------------------------------------------------------------------------------------------------------------
        MarcarBajaCalidadEC(dtNegados)
        '---------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 24/04/2013: Actualizamos el pedido en SAP segun del tipo que sea Ecommerce o Si Hay
        '---------------------------------------------------------------------------------------------------------------------------------
        Select Case Modulo.Trim.ToUpper
            Case "PP"
                '---------------------------------------------------------------------------------------------------------------------------------
                'Actualizamos el status del pedido en SAP
                '---------------------------------------------------------------------------------------------------------------------------------
                oSAPMgr.ZPOL_ACTTRASL(Me.ebPedidoEC.Text, Me.ebFolioTraspasoSAP.Text, Status, "", UserNameAplicated, dtConfirmados, SolicitudID)
                '---------------------------------------------------------------------------------------------------------------------------------
                'Guardamos los materiales negados en SAP
                '---------------------------------------------------------------------------------------------------------------------------------
                oSAPMgr.ZPOL_TRASL_NEGAR("", "", UserNameAplicated, dtNegados)
            Case "PPSH"
                Dim htCabecera As New Hashtable(3)
                htCabecera("Responsable") = oAppContext.Security.CurrentUser.Name
                htCabecera("Traslado") = Me.ebFolioTraspasoSAP.Text
                htCabecera("Pedido") = Me.ebPedidoEC.Text
                htCabecera("CentroSAP") = strCentroSAP.Trim
                If TodosSonNegados() = True Then
                    htCabecera("Guia") = ""
                Else
                    htCabecera("Guia") = CStr(guias("Guia"))
                End If

                '---------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 05/06/2013: Se filtra las solicitudes por el pedido que se surtirá
                '---------------------------------------------------------------------------------------------------------------------------------
                dtCabeceraSH = FiltrarCabSHByPedido(Me.ebPedidoEC.Text, dtCabeceraSH)
                '---------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 24/04/2013: Modificamos el estatus del pedido SH en SAP
                '---------------------------------------------------------------------------------------------------------------------------------
                oSAPMgr.ZSH_ACTUALIZAR_SOLICITUD("SURTIDO", htCabecera, dtCabeceraSH, dtConfirmados, dtNegados)
                Me.guias = Nothing
        End Select
        '---------------------------------------------------------------------------------------------------------------------------------
        'Marcamos todos los faltantes como de baja calidad para que Ecommerce no los vea en el inventario de la tienda
        '---------------------------------------------------------------------------------------------------------------------------------
        'MarcarBajaCalidadEC(dtNegados)
        '---------------------------------------------------------------------------------------------------------------------------------
        'Si se tiene que facturar desde la tienda entra en el IF
        '---------------------------------------------------------------------------------------------------------------------------------
        Dim FacturaSAP As String = ""
        If bFacturar AndAlso Status.Trim <> "N" Then FacturaSAP = EmitirFactura(Status, False)

        'If Status.Trim.ToUpper <> "N" Then
        '    Dim strMsg As String = ""

        '    If bModificado = False Then strMsg = "El pedido se ha surtido correctamente"
        '    If Me.ebFolioTraspasoSAP.Text.Trim <> "" Then strMsg &= " con el traspaso " & Me.ebFolioTraspasoSAP.Text
        '    If FacturaSAP.Trim <> "" Then strMsg &= " y facturado con el folio " & FacturaSAP.Trim

        '    MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    MessageBox.Show("El pedido se ha Negado correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        '-------------------------------------------------------------------------------------------------------------------------------------
        'Enviamos el mensaje correcto según el tipo de pedido
        '-------------------------------------------------------------------------------------------------------------------------------------
        If Me.ebFolioTraspasoSAP.Text.Trim <> "" AndAlso CLng(Me.ebFolioTraspasoSAP.Text.Trim) > 0 Then strMsg &= " con el traspaso " & Me.ebFolioTraspasoSAP.Text
        If FacturaSAP.Trim <> "" Then strMsg &= " y facturado con el folio " & FacturaSAP.Trim

        MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        If bConcen AndAlso Me.ebFolioTraspasoSAP.Text.Trim <> "" Then
            Me.grpDetalle.Enabled = False
            Me.grpTraspasos.Enabled = True
            Me.nebFolioTraspaso.Focus()
        Else
Final:
            BuscarPedidosPendientes()
        End If

        'bPedidosRefresh = True
        '----------------------------------------------------------------------------------------------------------------------------------------------
        'RGGERMAIN 21.11.2013: Refrescamos solo el panel del proceso que se este ejecutando en este momento para no pegarle al performace
        '----------------------------------------------------------------------------------------------------------------------------------------------
        Select Case Modulo.Trim.ToUpper
            Case "PP"
                '-----------------------------------------------------------------------------------------------------------------------------------------
                'Actualizamos el panel que muestra los pedidos pendientes del Ecommerce
                '-----------------------------------------------------------------------------------------------------------------------------------------
                RefreshPedidosEC()
            Case "PPSH"
                '-----------------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 19/06/2013: Se actualiza el estatus de los pedidos en el panel del HomeDash del Si Hay
                '-----------------------------------------------------------------------------------------------------------------------------------------
                RefreshPedidosSiHay()
        End Select

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

    Private Function GetStatusRePedido() As String

        Dim Status As String = ""
        Dim oRow As DataRow
        Dim bConfirm As Boolean = False, bNeg As Boolean = False

        For Each oRow In dtDetalle.Rows
            If oRow!Entregados > 0 Then bConfirm = True
            If (oRow!Solicitados - oRow!Cantidad) - oRow!Entregados > 0 Then bNeg = True
            If bConfirm AndAlso bNeg Then Exit For
        Next

        If (bConfirm AndAlso bNeg) OrElse (dtNegados.Rows.Count > 0 AndAlso dtConfirmados.Rows.Count > 0) OrElse _
        (bConfirm AndAlso dtNegados.Rows.Count > 0) OrElse (bNeg AndAlso dtConfirmados.Rows.Count > 0) Then
            Status = "PS"
        ElseIf bNeg = False AndAlso dtNegados.Rows.Count <= 0 Then
            Status = "S"
        ElseIf bConfirm = False AndAlso dtConfirmados.Rows.Count <= 0 Then
            Status = "N"
        End If

        Return Status.Trim

    End Function

    Private Sub MarcarBajaCalidadEC(ByVal dtSource As DataTable)

        If dtSource.Rows.Count > 0 Then
            Dim oCol As DataColumn
            Dim dtFaltantes As DataTable = dtSource.Copy

            'UserNameAplicated = oAppContext.Security.CurrentUser.Name
            '---------------------------------------------------------------------------------------------------------------------
            'Le cambiamos el nombre a la columna del material y a la de Negados ya que en realidad esa es la cantidad de piezas
            'negadas y no la que está actualmente en Cantidad
            '---------------------------------------------------------------------------------------------------------------------
            dtFaltantes.Columns("Codigo").ColumnName = "Material"
            dtFaltantes.Columns("Cantidad").ColumnName = "Cantidad2"
            dtFaltantes.Columns("Negados").ColumnName = "Cantidad"
            '---------------------------------------------------------------------------------------------------------------------
            'Agregamos la columna con el ID del desmarcado
            '---------------------------------------------------------------------------------------------------------------------
            oCol = New DataColumn
            oCol.ColumnName = "DesmarcadoID"
            oCol.DataType = GetType(String)
            oCol.DefaultValue = ""
            dtFaltantes.Columns.Add(oCol)
            ''---------------------------------------------------------------------------------------------------------------------
            ''Obtenemos el motivo de marcado de SAP
            ''---------------------------------------------------------------------------------------------------------------------
            'Dim dtMotivoMar As DataTable
            'Dim MotivoMarcado As String = ""
            'Dim MarcadoID As String = ""
            'dtMotivoMar = oSapMgr.ZPOL_GET_MOTIVOS("FT")
            'If dtMotivoMar.Rows.Count > 0 Then
            '    MotivoMarcado = dtMotivoMar.Rows(0)!Motivo
            '    MarcadoID = dtMotivoMar.Rows(0)!ID
            'End If
            '---------------------------------------------------------------------------------------------------------------------
            'Agregamos la columna con el ID del marcado
            '---------------------------------------------------------------------------------------------------------------------
            'oCol = New DataColumn
            'oCol.ColumnName = "MarcadoID"
            'oCol.DataType = GetType(String)
            'oCol.DefaultValue = MarcadoID
            'dtFaltantes.Columns.Add(oCol)
            'dtFaltantes.AcceptChanges()

            dtFaltantes.Columns("Motivo").ColumnName = "MarcadoID"
            '---------------------------------------------------------------------------------------------------------------------
            'Agregamos la columna con el motivo del marcado
            '---------------------------------------------------------------------------------------------------------------------
            'oCol = New DataColumn
            'oCol.ColumnName = "Motivo"
            'oCol.DataType = GetType(String)
            'oCol.DefaultValue = MotivoMarcado.Trim
            'dtFaltantes.Columns.Add(oCol)

            dtFaltantes.Columns("MotivoDesc").ColumnName = "Motivo"
            '---------------------------------------------------------------------------------------------------------------------
            'Grabamos el marcado como de baja calidad en SAP
            '---------------------------------------------------------------------------------------------------------------------
            oSAPMgr.ZPOL_DEFECTUOSOS_INS("", "MD", UserNameAplicated, dtFaltantes)
        End If

    End Sub

    Private Function ValidaFactura() As Boolean
        Dim bRes As Boolean = True

        '----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 29/04/2013: Si es un pedido de EC validamos que si es concentracion haya recibido todos los traspasos en caso de ser la tienda 
        'concentradora en caso de ser un pedido SH no es necesario ya que se puede ir aplicando cada traspaso conforme lleguen
        '----------------------------------------------------------------------------------------------------------------------------------------
        Try
1:          If bConcen AndAlso Modulo.Trim.ToUpper = "PF" Then bRes = ValidarConcentracion()

2:          If bRes AndAlso UserNameAplicated.Trim = "" Then
3:              oAppContext.Security.CloseImpersonatedSession()
4:              If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida") Then
5:                  oAppContext.Security.CloseImpersonatedSession()
6:                  bRes = False
                Else
7:                  UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
8:                  UserNameAplicated = oAppContext.Security.CurrentUser.Name
9:                  oAppContext.Security.CloseImpersonatedSession()
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al validar la factura: Linea " & Err.Erl)
            bRes = False
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return bRes

    End Function

    Private Function EmitirFactura(ByVal Status As String, ByVal bMsg As Boolean) As String

        Dim FacturaEC As String = ""
        Dim oRow As DataRow
        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        Try
            '-----------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 29/04/2013: Revisamos que el pedido no se haya cancelado en este momento antes de realizar la factura o dar entrada al
            'producto segun del modulo desde donde se acceso
            '-----------------------------------------------------------------------------------------------------------------------------------------
            If EstaPedidoCancelado(Me.ebPedidoEC.Text.Trim, Modulo) Then
                MessageBox.Show("El pedido ha sido cancelado en este momento, no es posible continuar con la factura.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                GoTo Final
            End If

1:          If ValidaFactura() Then
2:              If bConcen = False AndAlso bMsg = False Then
3:                  oRow = dtTraspasos.NewRow
4:                  oRow!FolioTraspaso = Me.ebFolioTraspasoSAP.Text.Trim.PadLeft(10, "0")
5:                  dtTraspasos.Rows.Add(oRow)
6:                  dtTraspasos.AcceptChanges()
                End If
                '---------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 30/04/2013: En caso de un pedido EC realizamos la factura por los codigos confirmados, en caso de un pedido SH
                'le damos entrada al inventario a los traslados o facturamos los productos confirmados segun el modulo origen de acceso
                '---------------------------------------------------------------------------------------------------------------------------------
                Select Case Modulo.Trim.ToUpper
                    Case "PF" 'PENDIENTE DE FACTURAR (ECOMMERCE)
7:                      FacturaEC = oSAPMgr.ZPOL_TRASLADO_A_FACTURA(Me.ebPedidoEC.Text, dtTraspasos)

8:                      If FacturaEC.Trim <> "" Then
                            '---------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 30/04/2013: Actualizamos el folio de factura generado en SAP para los pedidos EC
                            '---------------------------------------------------------------------------------------------------------------------
9:                          If Not dtConfirmados Is Nothing Then
10:                             dtConfirmados.Clear()
                            Else
11:                             dtConfirmados = New DataTable
                            End If
12:                         Select Case Status.Trim
                                Case "PS"
13:                                 Status = "PF"
                                Case "S"
14:                                 Status = "F"
                            End Select
15:                         oSAPMgr.ZPOL_ACTTRASL(Me.ebPedidoEC.Text, Me.ebFolioTraspasoSAP.Text, Status, FacturaEC, UserNameAplicated, dtConfirmados, SolicitudID)

16:                         If bMsg Then MessageBox.Show("La factura se realizo correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '---------------------------------------------------------------------------------------------------------------------
                            'Imprimimos la nota de venta
                            '---------------------------------------------------------------------------------------------------------------------
17:                         ImprimirFacturaEC(FacturaEC)

18:                         If MessageBox.Show("¿Deseas reimprimir la nota de venta?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
19:                             ImprimirFacturaEC(FacturaEC)
                            End If
                        End If
                    Case "PRSH" 'PENDIENTE DE RECIBIR DE SI HAY
                        Dim strTrasError As String = ""
                        Dim strTrasOK As String = ""
                        Dim strMsg As String = ""
                        '----------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 30/04/2013: Ingresamos los traslados al inventario de la tienda
                        '----------------------------------------------------------------------------------------------------------------------
                        Dim folioTraspaso As String = ""
                        For Each oRow In dtTraspasos.Rows
                            Try
                                Dim strMensaje As String = ""
                                folioTraspaso = oRow!FolioTraspaso
                                Dim dtMat As New DataTable
                                FacturaEC = oSAPMgr.ZFM_COMMX001_DPRO(folioTraspaso, dtMat, strMensaje, oConfigCierreFI.RecibirParcialmente)
                                'FacturaEC = oSAPMgr.Write_TrasladoEntradaSAPMM02(oRow!FolioTraspaso)
                                If FacturaEC.Trim = "" Then
                                    strTrasError &= oRow!FolioTraspaso & vbNewLine
                                Else
                                    strTrasOK &= oRow!FolioTraspaso & vbNewLine
                                End If
                            Catch ex As Exception
                                strTrasError &= oRow!FolioTraspaso & vbNewLine
                            End Try
                        Next

                        Dim htCabecera As New Hashtable(1)
                        htCabecera("Responsable") = UserNameAplicated
                        htCabecera("Pedido") = Me.ebPedidoEC.Text
                        '---------------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 05/06/2013: Se filtra las solicitudes por el pedido que se surtirá
                        '---------------------------------------------------------------------------------------------------------------------------------
                        dtCabeceraSH = FiltrarCabSH(dtTraspasos, dtCabeceraSH)
                        '------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 30/04/2013: Modificamos el estatus del pedido SH en SAP
                        '------------------------------------------------------------------------------------------------------------------------
                        oSAPMgr.ZSH_ACTUALIZAR_SOLICITUD("RECEPCION", htCabecera, dtCabeceraSH, dtConfirmados, dtNegados)
                        '------------------------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 02/09/2015: Se registra el traspaso de entrada siempre y cuando este activada la configuración
                        '------------------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.RegistrosTraspasoSiHay = True Then
                            Dim dtTraspasoEntrada As DataTable = CrearDetalleTraspasoEntrada(dtDetalle)
                            oTraspasoEntrada = New TraspasoEntrada(oTraspasoEntradaMgr)
                            oTraspasoEntrada.Detalle = New DataSet
                            oTraspasoEntrada.Detalle.Tables.Add(dtTraspasoEntrada)
                            oTraspasoEntrada.Referencia = FacturaEC
                            oTraspasoEntrada.AlmacenDestinoID = oAppContext.ApplicationConfiguration.Almacen
                            oTraspasoEntrada.AlmacenOrigenID = CtoSuministrador
                            oTraspasoEntrada.FolioSAP = folioTraspaso
                            oTraspasoEntrada.AutorizadoPorID = UserSessionAplicated
                            oTraspasoEntrada.TraspasoRecibidoEl = oSAPMgr.MSS_GET_SY_DATE_TIME().ToShortDateString()
                            oTraspasoEntrada.TraspasoCreadoEl = oSAPMgr.MSS_GET_SY_DATE_TIME().ToShortDateString()
                            If (oTraspasoEntradaMgr.AplicarEntrada(oTraspasoEntrada, UserSessionAplicated, UserNameAplicated) = True) Then
                                oTraspasoEntrada.Status = "GRA"
                                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                'FLIZARRAGA 02/09/2015: Guardamos el traspaso en el Servidor si esta activada la configuracion
                                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                Try
                                    oTraspasoEntradaMgr.AplicarTraspasoEntradaInServer(oTraspasoEntrada, UserSessionAplicated, UserNameAplicated)
                                Catch ex As Exception
                                    EscribeLog(ex.ToString, "Error al guardar traspaso de entrada en el servidor.")
                                End Try
                            End If
                        End If
                        strMsg = "Los traslados se han ingresado correctamente."
                        'If strTrasOK.Trim <> "" Then strMsg = ""
                        'If strTrasError.Trim <> "" Then strMsg = ""
                        MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case "PFSH" 'PENDIENTE DE FACTURAR DE SI HAY

                        'Dim ofrmPago As New frmPago
                        'Dim oCuponDesc As CuponDescuento
                        'Dim oPedido As New Pedidos(Me.ebPedidoEC.Text, 2)
                        Dim ofrmFSH As New frmFacturacionSinExistencia
                        Dim dtMateriales As DataTable ', oNewRow As DataRow, oRowSH As DataRow
                        'Dim dtFormasPago As New DataTable
                        '-------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 16/05/2013: Facturamos todos los traslados ingresados
                        '-------------------------------------------------------------------------------------------------------------------------
                        'ofrmPago.oFactura = oFacturaMgr.Create
                        ofrmFSH.LoadFactura()
                        '-------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 24/05/2013: Filtramos los IDs de la cabecera de los pedidos dejando solo los ids de los traslados que ingresaron
                        '-------------------------------------------------------------------------------------------------------------------------
                        dtCabeceraSH = FiltrarCabSH(dtTraspasos, dtCabeceraSH)
                        '-------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 30/05/2013: Realizamos la factura en SAP con los traslados ingresados
                        '-------------------------------------------------------------------------------------------------------------------------
                        Dim strResult As String = ""
                        Dim htCupon As Hashtable
                        Dim dview As New DataView(dtPedidos, "Folio_Pedido='" & Me.ebPedidoEC.Text.Trim() & "'", "", DataViewRowState.CurrentRows)

                        '-------------------------------------------------------------------------------------------------------------------------
                        'MLVARGAS 24/06/2022: Validar que existe el Pedido en la base de datos local
                        '-------------------------------------------------------------------------------------------------------------------------
                        If Not dview Is Nothing Then
                            Dim referencia As String = CStr(dview(0)!REFERENCIA)
                            Dim oPedido As New Pedidos(referencia, 3)
                            If oPedido.PedidoID = 0 Then
                                MessageBox.Show("No se encuentra información para facturar el pedido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                GoTo Final
                            End If
                        End If


                        dtMateriales = oSAPMgr.ZSH_FACTURAR_IDS(Me.ebPedidoEC.Text, UserNameAplicated, dtCabeceraSH, ofrmFSH.oFactura.FolioSAP, ofrmFSH.oFactura.FolioFISAP, htCupon, strResult)

                        If strResult.Trim = "Y" Then
                            '---------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 17/05/2013: Aqui si se tiene que guardar la factura en la base de SQL igual que una venta normal, ya que sera
                            'posible cancelarla o realizar una nota de credito
                            '---------------------------------------------------------------------------------------------------------------------

                            '---------------------------------------------------------------------------------------------------------------------
                            ' JNAVA (18.11.2016): Validamos si está activo S2Credit para no actualizar estatus de vale en AFS
                            '---------------------------------------------------------------------------------------------------------------------
                            If Not oConfigCierreFI.AplicarS2Credit Then
                                Dim referencia As String = CStr(dview(0)!REFERENCIA)
                                Dim oPedido As New Pedidos(referencia, 3)
                                If oPedido.CodTipoVenta = "V" Then
                                    Dim mensaje As String = ""
                                    Dim ref() As String = oPedido.Referencia.Split("-")
                                    If ref.Length > 1 Then
                                        Dim respuesta As String = ""
                                        respuesta = oSAPMgr.ActualizaStatusDPValeAFS(ref(1), mensaje)
                                        If respuesta.Trim() = "N" Then
                                            MessageBox.Show("No se pudo actualizar el status del vale: " & mensaje & vbCrLf & "Verifique el vale: " & ref(1) & " con el personal encargado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        End If
                                    End If
                                End If
                            End If

                            GuardarFacturaEnDPPRO(ofrmFSH, dtMateriales, dview(0)!REFERENCIA)
                            '---------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 13/06/2013: Imprimimos el cupon de descuento en caso de ser la ultima factura del pedido
                            '---------------------------------------------------------------------------------------------------------------------
                            ImprimirCuponDescuento(htCupon)
                            MessageBox.Show("El pedido se ha facturado correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                End Select
Final:
                '---------------------------------------------------------------------------------------------------------------------------------
                'Actualizamos la informacion una vez realizada la factura
                '---------------------------------------------------------------------------------------------------------------------------------
20:             BuscarPedidosPendientes()
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al emitir la factura: Linea " & Err.Erl)
            FacturaEC = ""
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 21/11/2013: Se actualiza el estatus de los pedidos en el panel del HomeDash del Si Hay o Ecommerce dependiendo del origen
        '-----------------------------------------------------------------------------------------------------------------------------------------
        Select Case Modulo.Trim.ToUpper
            Case "PRSH", "PFSH" 'Pedido Si Hay
                RefreshPedidosSiHay()
            Case "PF"
                RefreshPedidosEC() 'Pedidos Ecommerce
        End Select

        Return FacturaEC

    End Function

    Private Function CrearDetalleTraspasoEntrada(ByVal dtTraspaso As DataTable) As DataTable
        Dim dtDetalle As New DataTable
        dtDetalle.Columns.Add("Codigo", GetType(String))
        dtDetalle.Columns.Add("Cantidad", GetType(Integer))
        dtDetalle.Columns.Add("TALLA", GetType(String))
        dtDetalle.Columns.Add("Descripcion", GetType(String))
        dtDetalle.Columns.Add("Bulto", GetType(Integer))
        Dim fila As DataRow = Nothing
        Dim ArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim articulo As articulo = ArticuloMgr.Create()
        For Each row As DataRow In dtTraspaso.Rows
            articulo.ClearFields()
            ArticuloMgr.LoadInto(CStr(row("Codigo")), articulo)
            fila = dtDetalle.NewRow()
            fila("Codigo") = CStr(row("Codigo"))
            fila("TALLA") = CStr(row("Talla"))
            fila("Cantidad") = CInt(row("Solicitados"))
            fila("Bulto") = 1
            fila("Descripcion") = articulo.Descripcion
            dtDetalle.Rows.Add(fila)
        Next
        dtDetalle.AcceptChanges()
        Return dtDetalle
    End Function

    Private Sub ImprimirCuponDescuento(ByVal Cupon As Hashtable)
        Dim strNombre As String = ""
        Dim FechaVig As String = ""
        Dim oCupon As New CuponDescuento

        'Si el Cupon viene vacio, nos salimos para evitar excepciones
        If Cupon Is Nothing Then Exit Sub
        If CStr(Cupon.Item("FOLIO")).Trim = "" Then Exit Sub

        'Llenamos el objeto oCupon
        With oCupon
            .Descripcion = Cupon.Item("DESCRIPCION")
            .Descuento = Cupon.Item("DESCUENTO")
            'Formateamos la Fecha
            FechaVig = Cupon.Item("FIN")
            .FechaVigencia = CDate(FechaVig.Substring(6, 2) & "/" & FechaVig.Substring(4, 2) & "/" & FechaVig.Substring(0, 4))
            'Formateamos la Fecha
            .Folio = Cupon.Item("FOLIO")
            .LimiteDescuento = Cupon.Item("LIMITE_DESCTO")
            .Maximo = Cupon.Item("MAXIMO")
            .Minimo = Cupon.Item("MINIMO")
            .TipoDescuento = Cupon.Item("TIPO_DESCTO")
        End With

        'imprimimos de ser necesario
        Try
            If oCupon.Folio.Trim <> "" Then
                If oConfigCierreFI.MiniPrinter Then
                    'If CLng(CodCliente) <> 1 AndAlso CLng(CodCliente) <> 99999 Then strNombre = ClienteNombre.Trim
                    Dim oRpt As New rptReCupon(oCupon.Folio, oCupon.Minimo, oCupon.Descuento, oCupon.FechaVigencia, strNombre, oCupon.TipoDescuento, "CD", oCupon.LimiteDescuento)
                    oRpt.Document.Name = "Cupon de Descuento"
                    oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oRpt.Run()

                    Dim RepView As New ReportViewerForm
                    'RepView.Report = oRpt
                    'RepView.Show()

                    oRpt.Document.Print(False, False)
                End If
            End If

            oCupon = Nothing

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el cupon de descuento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            EscribeLog(ex.ToString, "-Error al actualizar status del pedido en SAP-")
        End Try

    End Sub

    Private Sub GuardarFacturaEnDPPRO(ByRef ofrmFSH As frmFacturacionSinExistencia, ByVal dtMatFacturados As DataTable, ByVal referencia As String)
        Dim ofrmPago As New frmPago
        Dim oCuponDesc As CuponDescuento
        Dim oPedido As New Pedidos(referencia, 3)
        Dim oNewRow As DataRow, oRowSH As DataRow, oRow As DataRow
        Dim dtFormasPago As New DataTable

        With ofrmFSH.oFactura
            'Pasamos los valores del pedido al objeto de factura que se guardara en SQL
            .ClienteId = oPedido.ClienteID
            .ClientPGID = oPedido.ClientePGID
            .CodAlmacen = oPedido.CodAlmacen
            '-----------------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 23.04.2015: Se modifico por la caja configurada en lugar de la caja donde se realizo el pedido porque causaba que se 
            '                     cambiaran los folios DPPRO cuando el pedido se hacia en una caja y la factura se hacia en otra, al final 
            '                     cambiaba erroneamente el folio en la tabla CatalogoCajas
            '-----------------------------------------------------------------------------------------------------------------------------------------------          
            .CodCaja = oAppContext.ApplicationConfiguration.NoCaja.Trim
            .CodTipoVenta = oPedido.CodTipoVenta
            .CodVendedor = oPedido.CodVendedor
            '-------------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 10.07.2013: Guardamos la factura con la fecha de SAP
            '-------------------------------------------------------------------------------------------------------------------------------------------
            .Fecha = oSAPMgr.MSS_GET_SY_DATE_TIME
            .Impresa = False
            .PedidoID = oPedido.PedidoID
            .SerialId = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
            If .CodTipoVenta = "V" Then
                .Referencia = oPedido.Referencia '& CStr(oDpvaleSAP.IDDPVale)
            Else
                .Referencia = oPedido.Referencia 'oAppContext.ApplicationConfiguration.Almacen.PadLeft(3, "0") & oAppContext.ApplicationConfiguration.NoCaja.Remove(0, 1) & Format(DateTime.Now, "yyyyMMddHHmmss")
            End If
            '.Referencia= oAppContext.ApplicationConfiguration.Almacen &
            .Usuario = UserNameAplicated
            'Llenamos el detalle de lo que se esta facturando
            .Detalle = ofrmFSH.dsDetalle.Clone

            If Not dtMatFacturados Is Nothing Then
                For Each oRow In dtMatFacturados.Rows
                    oRowSH = GetRowPedidoSH(oRow, oPedido.ArticulosNoFacturados)
                    oNewRow = ofrmFSH.dsDetalle.Tables(0).NewRow
                    With oNewRow
                        !Codigo = CStr(oRow!Material).Trim
                        If IsNumeric(CStr(oRow!Talla).Trim) AndAlso InStr(CStr(oRow!Talla).Trim, ".5") <= 0 Then
                            !Talla = CInt(oRow!Talla)
                        Else
                            !Talla = CStr(oRow!Talla)
                        End If
                        !Cantidad = oRow!Cantidad
                        !Importe = oRowSH!PrecioUnitario
                        !Total = !Cantidad * !Importe
                        !Descuento = (oRowSH!CantDescuentoSistema / oRowSH!Cantidad) * !Cantidad
                        !Adicional = oRowSH!Adicional
                        !Condicion = oRowSH!Condicion
                    End With
                    ofrmFSH.dsDetalle.Tables(0).Rows.Add(oNewRow)
                Next
            End If
        End With
        '-------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 30/05/2013: Calculamos los totales en base al detalle que acabamos de llenar para la factura
        '-------------------------------------------------------------------------------------------------------------------------------------------
        ofrmFSH.ActualizaCalculos()
        '-------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 30/05/2013: Le pasamos los valores al formulario de pago para realizar el guardado de la factura en SQL
        '-------------------------------------------------------------------------------------------------------------------------------------------
        ofrmPago.oFactura = ofrmFSH.oFactura
        ofrmPago.DataSetSiHay = ofrmFSH.dsDetalle.Copy
        ofrmPago.DataSetSiHay.Tables(0).TableName = "ArticulosConExistencia"
        ofrmPago.DataSetSiHay.Tables(0).Columns("Codigo").ColumnName = "CodArticulo"
        ofrmPago.DataSetSiHay.Tables(0).Columns("Talla").ColumnName = "Numero"
        ofrmPago.DataSetSiHay.Tables(0).Columns("Importe").ColumnName = "PrecioUnitario"
        ofrmPago.DataSetSiHay.Tables(0).Columns("Descuento").ColumnName = "CantDescuentoSistema"
        ofrmPago.dsFormasPago.Tables.Add(dtFormasPago)
        ofrmPago.boolLaImprimo = False
        oPedido.Impresa = False
        ofrmPago.SaveFacturaSH(ofrmFSH.oFactura, oPedido)
        '----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 30/05/2013: Imprimimos la factura recien creada y los productos faltantes por entregar
        '----------------------------------------------------------------------------------------------------------------------------------------
        Dim DPValeID As String = "", strQuin As String = "0"
        If oPedido.CodTipoVenta.Trim.ToUpper = "V" Then
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 05.11.2014: Cargamos los datos del DPVale para imprimir en el ticket en caso de ser una factura de un pedido de DPVale
            '---------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (20.02.2017):  Seteamos los datos del ciente y distribuidor en oFrmPago
            '---------------------------------------------------------------------------------------------------------------------------------
            ObtenerInfoDPVale(oPedido.PedidoID, ofrmFSH.oFactura.FolioSAP, DPValeID, strQuin, ofrmPago.vNombreAsociado, ofrmPago.vNombreClienteAsociado)
            '---------------------------------------------------------------------------------------------------------------------------------
            ofrmPago.StrFolioDPVale = DPValeID.Trim()
        End If
        ofrmPago.ActionPreview(ofrmPago.oFactura.FacturaID, "Facturacion", True, "", strQuin, False, False, True)
        ofrmPago.ActionPreview(ofrmPago.oFactura.FacturaID, "Facturacion", True, "", strQuin, False, True, True)
        ofrmPago.ActionPreviewFacturacionSH(oPedido.PedidoID, True, "Facturacion", True, "PENDIENTE", strQuin, False, True)
        '-------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 30/05/2013: Si se usó un cupon de descuento en el pedido SH, lo relacionamos a esta factura por alguna posible nota de credito
        '-------------------------------------------------------------------------------------------------------------------------------------------
        If oPedido.CuponDevuelto.Trim <> "" Then
            oFacturaMgr.SaveCuponDescuento(oPedido.CuponDevuelto, ofrmPago.oFactura.FacturaID)
        End If
    End Sub

    Private Sub ObtenerInfoDPVale(ByVal PedidoID As Integer, ByVal FolioSAP As String, ByRef DPValeID As String, ByRef strQuin As String, Optional ByRef strDistribuidor As String = "", Optional ByRef strCliente As String = "")
        Dim oDPValeTemp As cDPVale
        Dim FechaCobro As Date

        DPValeID = oFacturaMgr.GetDPVALEID(0, PedidoID)
        '------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 13.05.2015: Se modifico la forma de obtener el numero de quincenas original del DPVale usado en el pedido SH
        '------------------------------------------------------------------------------------------------------------------------------------
        If DPValeID.Trim() <> "" Then
            oDPValeTemp = New cDPVale
            '---------------------------------------------------------------------------------------------------
            'FLIZARRAGA 27/09/2017: Se valida si es vale electronico
            '---------------------------------------------------------------------------------------------------
            If IsNumeric(DPValeID.Trim()) Then
                oDPValeTemp.INUMVA = DPValeID.PadLeft(10, "0")
            Else
                oDPValeTemp.INUMVA = DPValeID.Trim()
            End If

            oDPValeTemp.I_RUTA = "X"

            '----------------------------------------------------------------------------------------
            ' JNAVA (18.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
            '----------------------------------------------------------------------------------------
            'oDPValeTemp = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPValeTemp)

            '----------------------------------------------------------------------------------------
            ' JNAVA (18.07.2016): Objetos para S2Credit
            '----------------------------------------------------------------------------------------
            Dim oS2Credit As New ProcesosS2Credit

            '----------------------------------------------------------------------------------------
            ' JNAVA (18.07.2016): Valida DPVale
            '----------------------------------------------------------------------------------------
            Dim FirmaDistribuidor As Image = Nothing
            Dim NombreDistribuidor As String = String.Empty
            If oConfigCierreFI.AplicarS2Credit Then
                oDPValeTemp = oS2Credit.ValidaDPVale(oDPValeTemp, FirmaDistribuidor, NombreDistribuidor)
            Else
                oDPValeTemp = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPValeTemp)
            End If
            '----------------------------------------------------------------------------------------

            If oDPValeTemp.ESTATU.Trim.ToUpper = "U" AndAlso oDPValeTemp.InfoDPVALE.Rows.Count > 0 Then
                strQuin = oDPValeTemp.InfoDPVALE.Rows(0)!NUMDE
                '----------------------------------------------------------------------------------------
                ' JNAVA (20.02.2017):  Obtenemos Nombre del Cliente y Distribuidor de DPVale
                '----------------------------------------------------------------------------------------
                Dim oClienteSAP As New ClientesSAP
                oClienteSAP = GetClienteDPVale(CStr(oDPValeTemp.InfoDPVALE.Rows(0).Item("CODCT")).PadLeft(10, "0"))
                strDistribuidor = NombreDistribuidor & " (" & CStr(oDPValeTemp.InfoDPVALE.Rows(0).Item("KUNNR")).PadLeft(10, "0") & ")"
                strCliente = oClienteSAP.Nombre & " " & oClienteSAP.Apellidos & " (" & CStr(oDPValeTemp.InfoDPVALE.Rows(0).Item("CODCT")).PadLeft(10, "0") & ")"
                '----------------------------------------------------------------------------------------
            Else
                EscribeLog("No se encontro la informacion del DPVale " & DPValeID & " en SAP", "No se encontro info del DPVale en SAP")
            End If
        Else
            EscribeLog("No se encontro el ID del DPVale en las formas de pago de esta factura: " & FolioSAP, "Error al obtener ID del DPVale")
        End If

    End Sub

    Private Function FiltrarCabSH(ByVal dtTras As DataTable, ByVal dtCabSH As DataTable) As DataTable
        Dim dtTemp As DataTable
        Dim oRow As DataRow, oNewRow As DataRow
        Dim oView As DataView, oRowV As DataRowView

        dtTemp = dtCabSH.Clone
        For Each oRow In dtTras.Rows
            oView = New DataView(dtCabSH, "Entrega = '" & CStr(oRow!FolioTraspaso).Trim & "'", "", DataViewRowState.CurrentRows)
            For Each oRowV In oView
                dtTemp.ImportRow(oRowV.Row)
            Next
            'oNewRow = dtCabSH.Select("Traslado = '" & CStr(oRow!FolioTraspaso).Trim & "'")(0)
            'dtTemp.ImportRow(oNewRow)
        Next

        Return dtTemp

    End Function

    Private Function GetRowPedidoSH(ByVal oRowM As DataRow, ByVal dtTemp As DataTable) As DataRow
        Dim idx As Integer = -1, i As Integer = 0
        Dim oRow As DataRow
        Dim strTalla As String = ""

        For Each oRow In dtTemp.Rows
            strTalla = CStr(oRow!Numero).Trim
            If IsNumeric(strTalla) Then strTalla = Format(CDec(strTalla), "#.0")
            If CStr(oRow!CodArticulo).Trim = CStr(oRowM!Material).Trim Then 'AndAlso strTalla = CStr(oRowM!Talla).Trim Then
                idx = i
                Exit For
            End If
            i += 1
        Next

        If idx >= 0 Then
            oRow = dtTemp.Rows(idx)
        Else
            oRow = Nothing
        End If

        Return oRow

    End Function

    Private Sub ImprimirPedidoSH(ByVal FolioSAP As String)

        Dim oFacturaTemp As Factura

        oFacturaTemp = oFacturaMgr.Create
        oFacturaMgr.LoadInto(FolioSAP.Trim, oFacturaTemp)

        If oFacturaTemp.FacturaID > 0 Then
            Dim ofrmPago As New frmPago

            ofrmPago.oFactura = oFacturaTemp
            Dim DPValeID As Long = 0, strQuin As String = "0"
            If oFacturaTemp.CodTipoVenta.Trim.ToUpper = "V" Then
                '---------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 13.05.2015: Cargamos los datos del DPVale para imprimir en el ticket en caso de ser una factura de un pedido de DPVale
                '---------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (20.02.2017):  Seteamos los datos del ciente y distribuidor en oFrmPago
                '---------------------------------------------------------------------------------------------------------------------------------
                ObtenerInfoDPVale(oFacturaTemp.PedidoID, oFacturaTemp.FolioSAP, DPValeID, strQuin, ofrmPago.vNombreAsociado, ofrmPago.vNombreClienteAsociado)
                '---------------------------------------------------------------------------------------------------------------------------------
                ofrmPago.intFolioDPVale = DPValeID

            End If
            ofrmPago.ActionPreview(oFacturaTemp.FacturaID, "Facturacion", True, "", strQuin, True, False, True)
            If oFacturaTemp.PedidoID > 0 Then
                Dim oPedido As New Pedidos(oFacturaTemp.PedidoID)
                If oPedido.PedidoID > 0 Then
                    ofrmPago.ActionPreviewFacturacionSH(oPedido.PedidoID, False, "Facturacion", True, "PENDIENTE", strQuin, True, True)
                End If
            End If
        Else
            MessageBox.Show("La nota de venta indicada no existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub ImprimirFacturaEC(ByVal FacturaEC As String, Optional ByVal ReImpresion As Boolean = False)


        '----------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (21.06.2016): Validamos si es Reimpresion
        '----------------------------------------------------------------------------------------------------------------------------------
        If Not ReImpresion Then
            '----------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (21.06.2016): VALIDAMOS QUE SI NO HAY CONFIRMADOS NO IMPRIMA FACTURA (NO HAY FOLIO)
            '----------------------------------------------------------------------------------------------------------------------------------
            If Me.dtConfirmados Is Nothing OrElse Me.dtConfirmados.Rows.Count <= 0 Then
                Exit Sub
            End If
            '----------------------------------------------------------------------------------------------------------------------------------
        End If


        Try
1:          Dim orptDataInfo As New rptFacturaInfo
2:          Dim pdtGeneral As DataTable
3:          Dim oRowC As DataRow, oRowF As DataRow, oRowDes As DataRow
4:          Dim dtCliente As DataTable, dtFactura As DataTable, dtImportes As DataTable, dtFacturaDet As DataTable, CodVend As String = ""
5:          Dim decIVA As Decimal = 0, FolioCupon As String = ""
            Dim strMsg As String = ""

            Dim decDescTotal As Decimal = Decimal.Zero

            '----------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 17/05/2013: Se ejectua la RFC para obtener los datos de la factura segun el modulo origen de acceso
            '----------------------------------------------------------------------------------------------------------------------------------
            strMsg = "El folio de nota de venta indicado no existe o no pertenece a una venta de "
            Select Case Modulo.Trim.ToUpper
                Case "PF", "PP" 'Ecommerce
                    strMsg &= "Ecommerce"
6:                  dtFacturaDet = oSAPMgr.ZSD_DATOS_FACTURA_GRAL(FacturaEC, dtCliente, dtFactura, decDescTotal, CodVend, FolioCupon) 'dtImportes, CodVend, FolioCupon)
                    Me.VersionEcommerce = oSAPMgr.ZPOL_VERSION_D_FACTURA(FacturaEC)
                    If Me.VersionEcommerce <> "" Then
                        Me.VersionEcommerce = Me.VersionEcommerce.Substring(0, 3)
                    End If
                Case "PFSH", "PRSH" 'Si Hay
                    strMsg &= "Si Hay"
                    'FALTA ESTA RFC PARA SACAR LOS DATOS DE LA FACTURA SH EN SAP
            End Select

7:          If dtFacturaDet.Rows.Count <= 0 OrElse dtCliente.Rows.Count <= 0 OrElse dtFactura.Rows.Count <= 0 Then 'OrElse dtImportes.Rows.Count <= 0 Then
8:              MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
9:              Select Case dtCliente.Rows.Count
                    Case 1
10:                     oRowC = dtCliente.Rows(0)
                    Case 2
11:                     oRowC = dtCliente.Rows(0)
12:                     oRowDes = dtCliente.Rows(1)
                End Select
13:             If dtFactura.Rows.Count > 0 Then oRowF = dtFactura.Rows(0)
14:             If dtFacturaDet.Rows.Count > 0 Then
                    With dtFacturaDet
15:                     .Columns("MATNR").ColumnName = "CodArticulo"
16:                     .Columns("ARKTX").ColumnName = "Descripcion"
17:                     '.Columns("J_3ASIZE").ColumnName = "Numero"
18:                     .Columns("LFIMG").ColumnName = "Cantidad"
19:                     .Columns("KZWI1").ColumnName = "PrecioOferta"
                        '----------------------------------------------------------
                        ' JNAVA (09.01.2016): Agregamos los demas descuentos
                        '----------------------------------------------------------
                        .Columns("KZWI2").ColumnName = "Descuento2"
                        .Columns("KZWI3").ColumnName = "Descuento3"
                        '----------------------------------------------------------
20:                     .Columns("KZWI4").ColumnName = "Descuento"
21:                     .Columns("NETWR").ColumnName = "Total"
22:                     .AcceptChanges()
                    End With
                End If

23:             pdtGeneral = DatosGeneralesImpresion(FacturaEC, oRowC, oRowF, decDescTotal, CodVend, decIVA)

24:             Dim oARReporte As New rptFacturacionEC(dtFacturaDet, pdtGeneral, oRowDes, "FACTURA", oConfigCierreFI.ImprimirCedula, decIVA, FolioCupon, , , Me.VersionEcommerce)
25:             oARReporte.Document.Name = "Reporte Facturacion Ecommerce"
26:             oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
27:             oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

28:             Dim oARViewer As New ReportViewerForm

                oARReporte.Document.Print(False, False)

29:             'oARViewer.Report = oARReporte
30:             'oARViewer.Show()

            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al imprimir la factura: Linea " & Err.Erl)
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Function CalcularDescTotal(ByVal decImportes As Decimal) As Decimal 'dtImportes As DataTable) As Decimal

        '--------------------------------------------------------------------------------------
        ' JNAVA (22.03.2016): Modificado por adecuaciones a retail
        '--------------------------------------------------------------------------------------
        Dim oRow As DataRow
        Dim DescTotal As Decimal = 0

        Try

            '1:          For Each oRow In dtImportes.Rows
            '2:              If CDec(oRow!COND_PRICE) < 0 Then
            '3:                  DescTotal += CDec(oRow!COND_PRICE) * -1
            '                End If
            '            Next
1:          If decImportes < 0 Then
2:              DescTotal = decImportes * -1
            Else
3:              DescTotal = decImportes
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al imprimir la factura: Linea " & Err.Erl)
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return DescTotal

    End Function

    Private Function DatosGeneralesImpresion(ByVal FolioSAP As String, ByVal oRowC As DataRow, ByVal oRowF As DataRow, ByVal decImportes As Decimal, ByVal CodVendedor As String, _
                                             ByRef PorcIVA As Decimal) As DataTable

        Dim dtTemp As New DataTable

        Try
1:          Dim piImp As RepAjustesESEng.cImpresionFactura
2:          Dim prTmp As DataRow
3:          Dim oImpresion As New cImprimirFactura

4:          piImp = New RepAjustesESEng.cImpresionFactura
5:          piImp.CrearDG(dtTemp)

6:          dtTemp.Columns.Add("FolioSAP", GetType(String))
7:          dtTemp.AcceptChanges()

8:          prTmp = dtTemp.NewRow()
9:          prTmp.Item("FolioFactura") = ""
10:         prTmp.Item("FolioSAP") = FolioSAP.Trim.PadLeft(10, "0")
11:         prTmp.Item("CodCaja") = oAppContext.ApplicationConfiguration.NoCaja
12:         prTmp.Item("Fecha") = Format$(oRowF!Fecha, "dd/MM/yy") '& " " & Format$(CDate(oRowF!ERDAT), "hh:mm:ss")
13:         prTmp.Item("NombreCliente") = CStr(oRowC!NAME1).Trim & " " & CStr(oRowC!NAME2).Trim & " " & CStr(oRowC!NAME3).Trim
14:         Dim Colonia As String = ""
15:         If InStr(CStr(oRowC!CITY2).Trim.ToUpper, "COL") > 0 Then
16:             Colonia = oRowC!CITY2
            Else
17:             Colonia = "Col. " & oRowC!CITY2
            End If
18:         prTmp.Item("Domicilio") = CStr(oRowC!STREET) & " " & CStr(oRowC!HOUSE_NUM1).Trim & vbCrLf & Colonia.Trim & " - CP: " & CStr(oRowC!POST_CODE1).Trim
19:         prTmp.Item("Ciudad") = CStr(oRowC!CITY1).Trim
20:         prTmp.Item("RFC") = CStr(oRowC!NAME4).Trim
21:         prTmp.Item("Telefono") = ""
22:         prTmp.Item("Subtotal") = 0
23:         prTmp.Item("Iva") = 0
            'If CStr(oRowC!POST_CODE1).Trim = "" Then
24:         prTmp.Item("Estado") = CStr(oRowC!REGION).Trim
            'Else
            '    prTmp.Item("Estado") = oRowC!Estado & " " & oRowC!CP
            'End If
            'If CStr(oRowC!POST_CODE1).Trim = "" Then prTmp.Item("Estado") &= " " & CStr(oRowC!POST_CODE1).Trim
            'ElseIf oFactura.ClienteId = 99999 Then
            'prTmp.Item("NombreCliente") = "EMPLEADO"
            'prTmp.Item("Ciudad") = oAlmacen.DireccionCiudad
            'prTmp.Item("Estado") = oAlmacen.DireccionEstado
            'prTmp.Item("Domicilio") = ""
            'prTmp.Item("RFC") = ""
            'prTmp.Item("Telefono") = ""
            'prTmp.Item("Subtotal") = 0
            'prTmp.Item("Iva") = 0
            'Else
            'prTmp.Item("NombreCliente") = "PÚBLICO GENERAL"
            'prTmp.Item("Ciudad") = oAlmacen.DireccionCiudad
            'prTmp.Item("Estado") = oAlmacen.DireccionEstado
            'prTmp.Item("Domicilio") = ""
            'prTmp.Item("RFC") = ""
            'prTmp.Item("Telefono") = ""
            'prTmp.Item("Subtotal") = 0
            'prTmp.Item("Iva") = 0
            'End If
25:         prTmp.Item("FormaPago") = "Pago hecho en una sola exhibición"
26:         prTmp.Item("TipoVenta") = "VENTAS ONLINE"
27:         prTmp.Item("AutorizacionFacilito") = " "
28:         prTmp.Item("LeyendaPago") = " "
29:         PorcIVA = CInt((CDec(oRowF!IVA) * 100) / CDec(oRowF!Total)) / 100
            '--------------------------------------------------------------------------------------
            ' JNAVA (22.03.2016): Modificado por adecuaciones a retail
            '--------------------------------------------------------------------------------------
30:         prTmp.Item("Descuento") = CalcularDescTotal(decImportes) * (1 + PorcIVA) '(dtImportes) * (1 + PorcIVA)
31:         prTmp.Item("Total") = CDec(oRowF!Total) + CDec(oRowF!IVA)
32:         prTmp.Item("CantidadTexto") = UCase(oImpresion.Letras(Decimal.Round(CDec(oRowF!Total) + CDec(oRowF!IVA), 2)))
33:         prTmp.Item("CodVendedor") = CodVendedor.Trim
34:         dtTemp.Rows.Add(prTmp)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al obtener los datos de la factura: Linea " & Err.Erl)
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return dtTemp

    End Function

    Private Sub ActualizaGridTraspasos()
        Me.grdTraspasos.DataSource = Nothing
        Me.grdTraspasos.DataSource = dtTraspasos
        Me.grdTraspasos.Refresh()
    End Sub

    Private Sub AgregaTraspaso()

        Try
            If Me.nebFolioTraspaso.Value > 0 Then

                If ValidarFolioTraspaso(Me.nebFolioTraspaso.Text) Then
                    Dim oRow As DataRow = dtTraspasos.NewRow

                    oRow!FolioTraspaso = CStr(Me.nebFolioTraspaso.Value).Trim.PadLeft(10, "0")

                    dtTraspasos.Rows.Add(oRow)
                    dtTraspasos.AcceptChanges()

                    ActualizaGridTraspasos()

                    Me.nebFolioTraspaso.Value = 0
                    Me.nebFolioTraspaso.Focus()
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al agregar un folio de traspaso: Linea " & Err.Erl)
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub AgregaNegado()

        Try
1:          Dim TotalCant As Integer = 0

2:          TotalCant = ValidaCantidadNegados()

3:          If TotalCant < Me.grdNegados.GetRow.DataRow!TotalNegados Then
4:              Me.grdNegados.GetRow.DataRow!Negados = Me.grdNegados.GetValue("Negados")

5:              Dim oNewRow As DataRow = dtNegados.NewRow

6:              With oNewRow
7:                  !Codigo = Me.grdNegados.GetValue("Codigo") 'oRow!Codigo
8:                  '!Descripcion = oRow!Descripcion
9:                  !Talla = Me.grdNegados.GetValue("Talla") 'oRow!Talla
10:                 !Negados = Me.grdNegados.GetRow.DataRow!TotalNegados - TotalCant 'oRow!TotalNegados - oRow!Negados
11:                 !Motivo = ""
12:                 !PedidoEC = Me.grdNegados.GetRow.DataRow!PedidoEC 'oRow!PedidoEC
                    '!AlmacenO = oRow!AlmacenO
13:                 !TotalNegados = Me.grdNegados.GetRow.DataRow!TotalNegados 'oRow!TotalNegados
14:                 !Agregado = True
                End With
15:             dtNegados.Rows.Add(oNewRow)
16:             dtNegados.AcceptChanges()

17:             ActualizaGridNegados()
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al agregar un registro de negados: Linea " & Err.Erl)
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub SetMotivoNegDesc(ByRef dtTemp As DataTable)

        Try
1:          Dim dvMotivo As DataView
2:          Dim oRow As DataRow

3:          dtTemp.Columns.Add("MotivoDesc", GetType(String))
4:          dtTemp.Columns("MotivoDesc").DefaultValue = ""
5:          dtTemp.AcceptChanges()

            For Each oRow In dtTemp.Rows
6:              dvMotivo = New DataView(dtMotivosNegados, "ID = '" & CStr(oRow!Motivo) & "'", "", DataViewRowState.CurrentRows)
7:              oRow!MotivoDesc = dvMotivo(0)!Motivo
            Next
8:          dtTemp.AcceptChanges()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al poner descripcion de negacion: Linea " & Err.Erl)
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Function ValidaCantidadNegados(Optional ByVal bEnUso As Boolean = True, Optional ByVal Codigo As String = "", Optional ByVal Talla As String = "") As Integer
        'Dim dvGrupo As New DataView(dtNegados, "Codigo = '" & CStr(oRow!Codigo).Trim & "' And Talla = '" & CStr(oRow!Talla).Trim & "'", "", DataViewRowState.CurrentRows)
        Dim Cantidad As Integer = 0

        Try
1:          Dim oRow As Janus.Windows.GridEX.GridEXRow
2:          Dim oCRow As Janus.Windows.GridEX.GridEXRow = Me.grdNegados.GetRow
3:          Dim i As Integer = 0, idx As Integer = Me.grdNegados.Row

4:          If bEnUso Then
5:              For Each oRow In Me.grdNegados.GetRows
6:                  If i <> idx AndAlso CStr(oRow.DataRow!Codigo).Trim = CStr(oCRow.DataRow!Codigo) AndAlso CStr(oRow.DataRow!Talla).Trim = CStr(oCRow.DataRow!Talla).Trim Then
7:                      Cantidad += oRow.DataRow!Negados
8:                  End If
9:                  i += 1
                Next

                'Return Cantidad + Me.grdNegados.GetValue("Negados")
10:             Cantidad += Me.grdNegados.GetValue("Negados")
            Else
11:             For Each oDRow As DataRow In dtNegados.Rows
12:                 If CStr(oDRow!Codigo).Trim = Codigo.Trim AndAlso CStr(oDRow!Talla).Trim = Talla.Trim Then
13:                     Cantidad += oDRow!Negados
                    End If
                Next

                'Return Cantidad
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al validar la cantidad de negados: Linea " & Err.Erl)
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return Cantidad

    End Function

    'Private Sub ValidaNegado()
    '    Dim oRowV As DataRowView = CType(Me.grdNegados.GetRow().DataRow, DataRowView)
    '    Dim dvGrupo As New DataView(dtNegados, "Codigo = '" & CStr(oRowV!Codigo).Trim & "' And Talla = '" & CStr(oRowV!Talla).Trim & "'", "", DataViewRowState.CurrentRows)
    '    Dim oRow As DataRowView
    '    Dim cant As Integer = 0
    '    Dim Codigos As String = ""

    '    'If Me.grdNegados.Col = 3 Then

    '    'validamos las cantidades ke no pasen del total negados
    '    'For Each oRowN As DataRow In dtNegados.Rows
    '    '    If InStr(Codigos, CStr(oRowN!Codigo).Trim & CStr(oRowN!Talla).Trim) <= 0 Then
    '    '        Codigos &= CStr(oRowN!Codigo).Trim & CStr(oRowN!Talla).Trim & ","
    '    '        dvGrupo = New DataView(dtNegados, "Codigo = '" & CStr(oRowN!Codigo).Trim & "' And Talla = '" & CStr(oRowN!Talla).Trim & "'", "", DataViewRowState.CurrentRows)

    '    '        For Each oRow In dvGrupo
    '    '            cant += oRow!Negados
    '    '        Next
    '    '        If cant > oRowN!TotalNegados Then
    '    '            oRowN!Negados = oRowN!TotalNegados - cant
    '    '            For Each oRow In dvGrupo
    '    '                If oRow!Negados = 0 Then oRow.Delete()
    '    '            Next
    '    '            dtNegados.AcceptChanges()
    '    '            ActualizaGridNegados()
    '    '        ElseIf cant < oRowV!TotalNegados Then
    '    '            AgregaNegado(oRowN)
    '    '        End If
    '    '    End If
    '    'Next

    '    'ElseIf Me.grdNegados.Col = 4 Then
    '    If Me.grdNegados.Col = 4 Then
    '        'Borramos duplicados y sumamos en caso de elegir el mismo motivo
    '        Dim i As Integer = 0
    '        Dim idx As Integer = -1
    '        For Each oRow In dvGrupo
    '            cant += oRow!Negados
    '            If CStr(oRowV!Motivo).Trim <> "" AndAlso CStr(oRowV!Motivo).Trim.ToUpper = CStr(oRow!Motivo).Trim.ToUpper Then
    '                idx = i
    '            End If
    '            i += 1
    '        Next
    '        If idx >= 0 Then
    '            If cant > oRowV!TotalNegados Then
    '                dtNegados.Rows(idx)!Negados = oRowV!TotalNegados
    '                oRowV.Delete()
    '                dtNegados.AcceptChanges()
    '                ActualizaGridNegados()
    '            Else
    '                dtNegados.Rows(idx)!Negados += oRowV!Negados
    '            End If
    '        End If

    '    End If

    'End Sub

    Private Function ValidaDetalleNegados(ByRef dtOrig As DataTable) As Boolean

        Dim bRes As Boolean = True

        Try
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Validamos que las cantidades sean exactamente igual al total de negados
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
1:          Dim oRow As DataRow
2:          Dim Codigos As String = ""
3:          Dim cant As Integer = 0
4:          Dim CodigosMen As String = ""
5:          Dim CodigosMay As String = ""

6:          Codigos = ""
7:          For Each oRow In dtOrig.Rows
8:              If InStr(Codigos, CStr(oRow!Codigo & oRow!Talla).Trim) <= 0 Then
9:                  Codigos &= CStr(oRow!Codigo & oRow!Talla).Trim & ","
10:                 cant = ValidaCantidadNegados(False, oRow!Codigo, oRow!Talla)
11:                 If cant > oRow!TotalNegados Then
12:                     CodigosMay &= oRow!Codigo & "  " & oRow!Talla & vbCrLf
13:                 ElseIf cant < oRow!TotalNegados Then
14:                     CodigosMen &= oRow!Codigo & "  " & oRow!Talla & vbCrLf
                    End If
                End If
            Next

15:         If CodigosMay.Trim <> "" OrElse CodigosMen.Trim <> "" Then
16:             Dim strMsg As String = ""
17:             If Codigos.Trim <> "" Then strMsg = "Los siguientes codigos tienen una cantidad mayor al total de negados " & vbCrLf & vbCrLf & Codigos.Trim
18:             If CodigosMen.Trim <> "" Then strMsg &= "Los siguientes codigos tienen una cantidad menor al total de negados " & vbCrLf & vbCrLf & CodigosMen.Trim
19:             MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
20:             bRes = False
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al validar el detalle de los negados: Linea " & Err.Erl)
            bRes = False
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return bRes

    End Function

    Private Function ValidarConcentracion() As Boolean

        Dim bRes As Boolean = True

        Try
1:          Dim oRow As DataRowView
2:          Dim strAlm() As String
3:          Dim strAlmacenes As String = ""
4:          Dim dvConcen As New DataView(dtConcentracion, "PuestoExpedicion = '" & CentroConcentrador.Trim & "'", "", DataViewRowState.CurrentRows)
5:          Dim CantFal As Integer = 0, bEnc As Boolean = False

            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Validamos que se hayan enviado todos los traspasos de la concentracion
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
6:          For Each oRow In dvConcen
7:              If CStr(oRow!Status).Trim.ToUpper <> "N" AndAlso (CStr(oRow!Folio_Traslado).Trim.ToUpper = "" OrElse (CStr(oRow!Guia).Trim = "" AndAlso _
                CStr(oRow!CESUM).Trim <> CentroConcentrador.Trim)) Then
9:                  bRes = False

10:                 strAlm = oSAPMgr.Read_CentrosSAP(CStr(oRow!CESUM).Trim)
11:                 strAlmacenes &= strAlm(0).Trim & ":  " & strAlm(1).Trim & vbCrLf
                End If
12:             If CStr(oRow!Status).Trim.ToUpper <> "N" Then
13:                 bEnc = False
14:                 For Each oRowT As DataRow In dtTraspasos.Rows
15:                     If CStr(oRowT!FolioTraspaso).Trim.ToUpper = CStr(oRow!Folio_Traslado).Trim.ToUpper Then
16:                         bEnc = True
                            Exit For
                        End If
                    Next
17:                 If bEnc = False Then CantFal += 1
                End If
            Next

18:         If bRes = False AndAlso strAlmacenes.Trim <> "" Then
19:             MessageBox.Show("El pedido no está completo, falta el traspaso de las siguientes tiendas" & vbCrLf & vbCrLf & strAlmacenes, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
20:             Me.nebFolioTraspaso.Focus()
21:         ElseIf CantFal > 0 Then
22:             MessageBox.Show("Falta agregar " & CantFal & " folio(s) de traslado que pertenecen a esta concentración.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
23:             bRes = False
24:             Me.nebFolioTraspaso.Focus()
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al validar la concentracion: Linea " & Err.Erl)
            bRes = False
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return bRes

    End Function

    Private Function ValidarFolioTraspaso(ByVal Folio As Long) As Boolean
        Dim bRes As Boolean = True

        Try
            Dim oRow As DataRowView
            Dim dvConcen As DataView ' New DataView(dtConcentracion, "PuestoExpedicion = '" & CentroConcentrador.Trim & "'", "", DataViewRowState.CurrentRows)
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 25/04/2013: Filtramos las solicitudes para mi centro segun el modulo origen de acceso EC o SH
            '------------------------------------------------------------------------------------------------------------------------------------
            Select Case Modulo.Trim.ToUpper
                Case "PP", "PF"
                    dvConcen = New DataView(dtConcentracion, "PuestoExpedicion = '" & CentroConcentrador.Trim & "'", "", DataViewRowState.CurrentRows)
                Case "PPSH", "PRSH", "PFSH"
                    Dim dtTemp As DataTable = dtCabeceraSH.Copy
                    dtTemp.Columns("ENTREGA").ColumnName = "Folio_Traslado"
                    dvConcen = New DataView(dtTemp, "VBELN = '" & Me.ebPedidoEC.Text.Trim & "'", "", DataViewRowState.CurrentRows)
            End Select
            '------------------------------------------------------------------------------------------------------------------------------------
            'Revisamos que el traspaso no este ya agregado a la lista
            '------------------------------------------------------------------------------------------------------------------------------------
            For Each oRowT As DataRow In dtTraspasos.Rows
                If CStr(oRowT!FolioTraspaso).Trim <> "" AndAlso CLng(oRowT!FolioTraspaso) = Folio Then
                    bRes = False
                    Exit For
                End If
            Next

            If bRes = False Then
                MessageBox.Show("El Folio ingresado ya está agregado a la lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.nebFolioTraspaso.Value = 0
                Me.nebFolioTraspaso.Focus()
            End If
            '-------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 25/04/2013: Revisamos que el traspaso indicado pertenezca a la concentracion del pedido en la que participa esta tienda en
            'caso de ser un pedido EC, si es un pedido SH entonces revisamos que el traslado pertenezca a una de las solicitudes que esta tienda
            'realizó para este pedido
            '-------------------------------------------------------------------------------------------------------------------------------------
            If bRes Then
                If bConcen Then
                    bRes = False
                    Dim i As Integer = 0
                    For Each oRow In dvConcen
                        If CStr(oRow!Folio_Traslado).Trim <> "" AndAlso CLng(oRow!Folio_Traslado) = Folio Then
                            bRes = True
                            Exit For
                        End If
                        i += 1
                    Next

                    If bRes = False Then
                        Select Case Modulo.Trim.ToUpper
                            Case "PP", "PF"
                                MessageBox.Show("El folio de traspaso indicado no pertenece a la concentración para el pedido " & Me.ebPedidoEC.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Case "PPSH", "PRSH", "PFSH"
                                MessageBox.Show("El folio de traspaso indicado no pertenece a las solicitudes para el pedido " & Me.ebPedidoEC.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End Select
                        Me.nebFolioTraspaso.Value = 0
                        Me.nebFolioTraspaso.Focus()
                    ElseIf CStr(Folio).Trim.ToUpper <> Me.ebFolioTraspasoSAP.Text.Trim.ToUpper Then
                        '-------------------------------------------------------------------------------------------------------------------------
                        'Revisamos que el traspaso ya haya sido enviado fisicamente por la tienda
                        '-------------------------------------------------------------------------------------------------------------------------
                        If CStr(dvConcen(i)!Guia).Trim = "" Then
                            MessageBox.Show("Verifique el traspaso indicado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            bRes = False
                            Me.nebFolioTraspaso.Focus()
                        End If
                    End If
                ElseIf CLng(Me.ebFolioTraspasoSAP.Text.Trim) <> Folio Then
                    MessageBox.Show("El folio de traspaso indicado no pertenece al pedido " & Me.ebPedidoEC.Text.Trim, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    bRes = False
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al validar el folio de traspaso: Linea " & Err.Erl)
            bRes = False
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return bRes

    End Function

    Private Function ValidarExistencia(ByVal dtTemp As DataTable) As String

        Dim strMsg As String = ""
        Try
1:          Dim oRow As DataRow
2:          Dim oFacturaTemp As Factura
3:          Dim Talla As String

4:          oFacturaTemp = oFacturaMgr.Create
5:          For Each oRow In dtTemp.Rows
6:              If IsNumeric(oRow!Talla) AndAlso InStr(CStr(oRow!Talla).Trim, ".0") > 0 Then
                    'Talla = Format(CDec(oRow!Talla), "#.0")
7:                  Talla = CInt(oRow!Talla)
                Else
8:                  Talla = CStr(oRow!Talla).Trim
                End If
9:              oFacturaTemp.FacturaArticuloExistencia = 0
10:             oFacturaMgr.GetExistenciaArticulo(CStr(oRow!Codigo), oAppContext.ApplicationConfiguration.Almacen, Talla, oFacturaTemp)
11:             If oFacturaTemp.FacturaArticuloExistencia < CInt(oRow!Confirmados) Then
12:                 strMsg &= CStr(oRow!Codigo).Trim & " en talla " & CStr(oRow!Talla).Trim & vbCrLf
                End If
            Next

13:         If strMsg.Trim <> "" Then
14:             MessageBox.Show("Los siguientes codigos no tienen existencia suficiente para realizar el traspaso." & vbCrLf & vbCrLf & strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al validar el folio de traspaso: Linea " & Err.Erl)
            strMsg = "Ocurrio un error al validar la existencia"
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return strMsg

    End Function

    Private Function GenerarTraspasoSalida(ByVal dtConfirmados As DataTable, ByVal FolioPedidoEC As String, ByVal strCodAlmacenDes As String, _
                                  ByVal strResponsableID As String, ByVal strTransportistaID As String, Optional ByVal EntregaEC As String = "") As Boolean

        Dim bRes As Boolean = True

        Try

1:          Dim oTraspasoSalida As TraspasoSalida
2:          Dim dsTraspasoCorrida As New DataSet
3:          Dim dtDetalleSAP As DataTable
4:          Dim CDes As String = ""
            Dim bModificado As Boolean = False

            Dim strError As String = ""
            Dim strObservaciones As String = ""

            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Creamos el detalle del traspaso de salida para la base local
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
5:          dsTraspasoCorrida = CrearDetalleTraspasoSalida(dtConfirmados)

            '------------------------------------------------------------------------------------------------------------------------------
            'Creamos el detalle del traspaso de salida para SAP
            '------------------------------------------------------------------------------------------------------------------------------
6:          dtDetalleSAP = oTraspasoSMgr.FillTablaParaSAP

            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (08.07.2016): Validamos si viene la Entrega de Ecommerce, solo guarga el traspaso en el DPPRO
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If EntregaEC.Trim = "" Then

                '------------------------------------------------------------------------------------------------------------------------------
                'Revisamos si el traspaso ya existe y ha sido modificado, es decir es una resolicitud del mismo pedido
                '------------------------------------------------------------------------------------------------------------------------------
                '------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 10/02/2015: Validar si aplica el surtido DPStreet
                '------------------------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.AplicarSurtidoDPStreet = True Then
                    If Me.VersionEcommerce.Trim() = "DPT" Then
57:                     bModificado = CBool(Me.grdPedidosEC.GetRow.DataRow!Modificado)
                    ElseIf Me.VersionEcommerce.Trim() = "DPS" Then
                        bModificado = CBool(Me.grdDPStreet.GetRow().DataRow!Modificado)
                    Else
                        bModificado = CBool(Me.grdPedidosEC.GetRow.DataRow!Modificado)
                    End If
                Else
                    bModificado = CBool(Me.grdPedidosEC.GetRow.DataRow!Modificado)
                End If

                '------------------------------------------------------------------------------------------------------------------------------
                'Si es una resolicitud, revisamos que no se haya negado anteriormente, si es el caso entonces se crea desde cero el traspaso
                '------------------------------------------------------------------------------------------------------------------------------
58:             If bModificado AndAlso (Me.ebFolioTraspasoSAP.Text.Trim = "" OrElse CLng(Me.ebFolioTraspasoSAP.Text.Trim) <= 0) Then bModificado = False
                '------------------------------------------------------------------------------------------------------------------------------
                'En caso de que no exista, creamos el traslado de salida hacia el centro destino de lo contrario solo agregamos los materiales
                'que se añadieron para surtir en el traslado
                '------------------------------------------------------------------------------------------------------------------------------
                'Dim strError As String = ""
                If bModificado = False Then
                    Me.guias("MotivoDevolucion") = ""
                    Me.guias("AlmacenOrigen") = "M001"
                    If Me.guias.ContainsKey("Guia") Then
                        If CStr(Me.guias("Guia")).Trim() = "LOCAL" Then
                            Me.guias("Transportista") = "CLIENTE"
                        End If
                    End If
                    Dim dtMat As DataTable = dtDetalleSAP.Copy()
                    dtMat.Columns.Add("MotivoDefectuoso", GetType(String))
                    dtMat.Columns.Add("ClaveConfirm", GetType(String))
                    For Each row As DataRow In dtMat.Rows
                        row("MotivoDefectuoso") = ""
                        row("ClaveConfirm") = "0004"
                        row.AcceptChanges()
                    Next
                    dtMat.AcceptChanges()
7:                  ebFolioTraspasoSAP.Text = oSAPMgr.pedido_trasladomm02(dtMat, Me.ebCodAlmacenDestino.Text, "M001", Me.guias)
                Else
59:                 strError = oSAPMgr.ZMM_TRASLADO_ME22N(Me.ebFolioTraspasoSAP.Text, dtDetalleSAP).Trim
60:                 If strError.Trim <> "" Then EscribeLog(strError.Trim, "Error al agregar mas posiciones al traslado " & Me.ebFolioTraspasoSAP.Text)
                End If
8:
9:              If ebFolioTraspasoSAP.Text.Trim = "" Then
                    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'No se grabo en SAP
                    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
10:                 bRes = False
11:                 EscribeLog("Error al realizar el pedido de traspaso en sap para surtir el pedido " & FolioPedidoEC.Trim, "Error al realizar pedido de traslado")
12:                 MsgBox("No se Realizo el PEDIDO DE TRAPASO en SAP", MsgBoxStyle.Exclamation, "Error SAP")
                    GoTo Final
                Else
                    '---------------------------------------------------------------------------------------------------------------------------------
                    'Aplicamos movimiento 351 en SAP
                    '---------------------------------------------------------------------------------------------------------------------------------
13:                 Dim strNumTras As String = ""
14:                 Dim strCodAlm() As String
                    '---------------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 02/05/2013: Especificamos las observaciones segun el modulo origen de acceso
                    '---------------------------------------------------------------------------------------------------------------------------------
                    Select Case Modulo.Trim.ToUpper
                        Case "PP", "PF" 'Pedido pendiente por surtir EC
15:                         strObservaciones = "Traspaso para Ecommerce"
                        Case "PPSH", "PRSH" 'Pedidos pendientes por surtir SH
                            strObservaciones = "Traspaso SH"
                    End Select

16:                 strCodAlm = oSAPMgr.Read_CentrosSAP(Me.ebCodAlmacenDestino.Text)

17:                 CDes = strCodAlm(0).Trim
                    '---------------------------------------------------------------------------------------------------------------------------------
                    'En caso de haber creado el traspaso por primera vez, aplicamos el 351 a todo el traspaso
                    'En caso de ser modificación aplicamos el 351 parcialmente solo a los codigos agregados
                    '---------------------------------------------------------------------------------------------------------------------------------
                    If bModificado = True Then
18:                     'strNumTras = oSAPMgr.trasladomm02(ebFolioTraspasoSAP.Text.Trim, strObservaciones.Trim, CDes.Trim)
                        strError = ""
                        strError = oSAPMgr.ZMM_351_PIEZAS_RESTANTES(Me.ebFolioTraspasoSAP.Text.Trim)
                    End If

                    '19:             If (strNumTras.Trim = "" AndAlso bModificado = False) OrElse (bModificado) Then ' AndAlso strError.Trim <> "") Then
                    '                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------
                    '                    'no se grabo en sap
                    '                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------
                    '20:                 bRes = False
                    '                    If bModificado = False Then strError = "No se realizó el movimiento 351 en SAP del traslado de salida " & ebFolioTraspasoSAP.Text.Trim
                    '21:                 EscribeLog(strError, "Error al aplicar 351 a traspaso de salida")
                    '22:                 MsgBox("No se Realizo el TRASPASO en SAP", MsgBoxStyle.Exclamation, "Error SAP")
                    '                    'Exit Sub
                    '                End If
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'Revisamos que haya aplicado el 351 completo en SAP
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------
                    '23:             If oSAPMgr.ZMM_VALIDA_TRASLADO_AL_100(Me.ebFolioTraspasoSAP.Text).Rows.Count > 0 Then
                    '24:                 If bModificado = False Then oSAPMgr.ZMM_BORRAR_TRASLADO_Y_352(Me.ebFolioTraspasoSAP.Text, IIf(strNumTras.Trim = "", False, True))
                    '25:                 bRes = False
                    '26:                 MessageBox.Show("Se encontraron diferencias al aplicar el movimiento 351 en SAP." & vbCrLf & "Favor de realizar la descarga de existencias e intentar de nuevo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '27:                 GoTo Final
                    '                End If
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'GRABAMOS GUIA BULTOS PAQUETERIA si es creado por primera vez
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Guia       F01
                'Bultos     F02
                'Paqueteria F03
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
                '-----------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (17.02.2016): se comenta por que ya no se usara pues la BAPI de ZBAPIMM02_PEDIDOTRAS incluye la funcionalidad
                '-----------------------------------------------------------------------------------------------------------------------------------
                '            If bModificado = False Then
                '28:             oSAPMgr.SaveInfoPaqueteria(ebFolioTraspasoSAP.Text.Trim, FolioPedidoEC.Trim, "F01")
                '                '29:             oSAPMgr.SaveInfoPaqueteria(ebFolioTraspasoSAP.Text.Trim, Me.ebNumBultos.Text.Trim, "F02")
                '                '30:             oSAPMgr.SaveInfoPaqueteria(ebFolioTraspasoSAP.Text.Trim, Me.ebTransportistaDesc.Text, "F03")
                '            End If

            End If

            '--------------------------------------------------------------------------------------------------------------------------------
            'Si es un traspaso modificado cargamos el ya existente si no es asi lo creamos y guardamos en la base local de SQL
            '--------------------------------------------------------------------------------------------------------------------------------
            oTraspasoSalida = Nothing

            If bModificado Then
29:             oTraspasoSalida = oTraspasoSMgr.SelectByEntrega(Me.ebFolioTraspasoSAP.Text.Trim)

                oTraspasoSalida.Detalle = Nothing
30:             oTraspasoSalida.Detalle = dsTraspasoCorrida

31:             oTraspasoSMgr.SaveCorrida(oTraspasoSalida)
            Else

32:             oTraspasoSalida = oTraspasoSMgr.Create

33:             oTraspasoSalida.Observaciones = strObservaciones.Trim

34:             oTraspasoSalida.TraspasoRecibidoEl = Date.Now.Date
35:             oTraspasoSalida.Guia = FolioPedidoEC.Trim
36:             oTraspasoSalida.TotalBultos = 0
37:             oTraspasoSalida.AutorizadoPorID = strResponsableID
38:             oTraspasoSalida.Cargos = 0
39:             oTraspasoSalida.SubTotal = 0
40:             oTraspasoSalida.MonedaID = ""
41:             oTraspasoSalida.TraspasoCreadoEl = Date.Now.Date
42:             oTraspasoSalida.TransportistaID = strTransportistaID.Trim
43:             oTraspasoSalida.Status = "GRA"
44:             oTraspasoSalida.AlmacenDestinoID = oSAPMgr.Read_Centros(CDes.Trim)
45:             oTraspasoSalida.AlmacenOrigenID = oAppContext.ApplicationConfiguration.Almacen
46:             oTraspasoSalida.Referencia = ""
47:             oTraspasoSalida.TraspasoID = 0
48:             oTraspasoSalida.Folio = ""
                oTraspasoSalida.Entrega = ebFolioTraspasoSAP.Text.Trim()
49:             oTraspasoSalida.FolioSAP = ebFolioTraspasoSAP.Text.Trim()
                oTraspasoSalida.PedidoEC = ebPedidoEC.Text.Trim()
                'oTraspasoSalida.TEOrigen = Me.ebFolio.Text.Trim

50:             oTraspasoSalida.Detalle = dsTraspasoCorrida
                oTraspasoSalida.Modulo = Modulo

                oTraspasoSalida.Save()

            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Guardamos el traspaso de salida en el servidor
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '            Try
            '52:             oTraspasoSMgr.SaveInServer(oTraspasoSalida, dtDetalleSAP)
            '            Catch ex As Exception
            '53:             EscribeLog(ex.ToString, "Error al guardar el traspaso de salida " & oTraspasoSalida.TraspasoID & " en el server.")
            '            End Try
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Actualizamos la informacion en la base local y afectamos el inventario
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If bModificado Then oTraspasoSalida.Status = "GRA"

54:         Sm_AplicarTraspasoSalida(oTraspasoSalida)
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Imprimir Traspaso
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
55:         oTraspasoSalida.Detalle.Tables(0).TableName = "TraspasoCorrida"
            PrintComprobanteTraspasoSalida(oTraspasoSalida)
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
56:         oTraspasoSalida = Nothing

            'MsgBox("El Traspaso de Salida ha sido Aplicado satisfactoriamente.", MsgBoxStyle.Information, "DPTienda.")
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al generar el traspaso de salida: Linea " & Err.Erl)
            bRes = False
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
Final:
        Return bRes

    End Function

    Private Sub GenerarEstructuraBajaCalidad(ByRef dtDefectuososEC As DataTable, ByVal dtNeg As DataTable, ByVal Modulo As String)

        dtDefectuososEC = New DataTable("DefectuososEC")

        With dtDefectuososEC
            .Columns.Add("Material", GetType(String))
            .Columns.Add("Talla", GetType(String))
            .Columns.Add("Cantidad", GetType(Integer))
            .Columns.Add("Motivo", GetType(String))
            .Columns.Add("DesmarcadoID", GetType(String))
            .Columns.Add("MarcadoID", GetType(String))
            .AcceptChanges()
        End With

        Dim oNewRow As DataRow
        Dim MotivoDesmarcado As String = ""
        Dim DesID As String = "", MarID As String = ""
        Dim dtMotivosDes As DataTable
        '--------------------------------------------------------------------------------------------------------------------
        'Obtenemos el id de motivo de desmarcado y de marcado de SAP
        '--------------------------------------------------------------------------------------------------------------------
        dtMotivosDes = oSAPMgr.ZPOL_GET_MOTIVOS(Modulo.Trim)
        If dtMotivosDes.Rows.Count > 0 Then
            MotivoDesmarcado = dtMotivosDes.Rows(0)!Motivo
            DesID = dtMotivosDes.Rows(0)!ID
        End If
        dtMotivosDes = oSAPMgr.ZPOL_GET_MOTIVOS("FT")
        If dtMotivosDes.Rows.Count > 0 Then
            MarID = dtMotivosDes.Rows(0)!ID
        End If
        '--------------------------------------------------------------------------------------------------------------------
        'Llenamos la tabla de los defectuosos de Ecommerce
        '--------------------------------------------------------------------------------------------------------------------
        Dim oRow As DataRow

        For Each oRow In dtNeg.Rows
            oNewRow = dtDefectuososEC.NewRow
            With oNewRow
                !Material = CStr(oRow!CodArticulo).Trim
                !Talla = CStr(oRow!Talla).Trim
                !Cantidad = oRow!Cantidad
                !Motivo = MotivoDesmarcado.Trim
                !DesmarcadoID = DesID.Trim
                !MarcadoID = MarID.Trim
            End With
            dtDefectuososEC.Rows.Add(oNewRow)
        Next
        dtDefectuososEC.AcceptChanges()

    End Sub

    Public Sub PrintComprobanteTraspasoSalida(ByVal oTraspasoSalidaTemp As TraspasoSalida)

        Try
1:          If Not oTraspasoSalidaTemp Is Nothing Then

2:              Dim oARReporte As New rptReporteTraspasoDeSalida(oTraspasoSalidaTemp, "Petición de Surtido para Ecommerce")
                'Dim oReportViewer As New ReportViewerForm

3:              oARReporte.Document.Name = "Reporte de Traspaso de Salida"

4:              oARReporte.Run()

                'oReportViewer.Report = oARReporte
                'oReportViewer.Show()

                Try
5:                  oARReporte.Document.Print(False, False)
                Catch ex As Exception
6:                  EscribeLog(ex.ToString, "Error al imprimir el traspaso de salida con folio: " & oTraspasoSalidaTemp.TraspasoID)
                End Try
            Else
                EscribeLog("Imprimir Traspaso", "No se pudo imprimir el traspaso, objeto vacio ")
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al imprimir el traspaso de salida: Linea " & Err.Erl)
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub Sm_AplicarTraspasoSalida(ByVal oTraspasoSalidaTemp As TraspasoSalida)
        Try
            '------------------------------------------------------------------------------------------------------------------------------------
            'Validación
            '------------------------------------------------------------------------------------------------------------------------------------
1:          If (oTraspasoSalidaTemp Is Nothing) Then
2:              EscribeLog("No hay un traspaso de salida seleccionado oTraspasoSalidaTemp Is Nothing", "Error al aplicar traspaso de salida")
3:              MsgBox("No ha sido seleccionado un Traspaso", MsgBoxStyle.Exclamation, "DPTienda")
4:              Exit Sub
5:          ElseIf oTraspasoSalidaTemp.Status.Trim.ToUpper <> "GRA" Then
6:              EscribeLog("El traspaso ya habia sido aplicado anteriormente. Status <> GRA", "Error al aplicar traspaso de salida " & oTraspasoSalidaTemp.TraspasoID)
7:              MsgBox("El Traspaso ya fue Aplicado.", MsgBoxStyle.Exclamation, "DPTienda")
8:              Exit Sub
            End If
            '------------------------------------------------------------------------------------------------------------------------------------
            'Actualizar Traspaso [General].
            '------------------------------------------------------------------------------------------------------------------------------------
9:          oTraspasoSalidaTemp.TraspasoRecibidoEl = "01/01/1900"
10:         oTraspasoSalidaTemp.Status = "TRA"

11:         If (oTraspasoSMgr.AplicarEntrada(oTraspasoSalidaTemp) = True) Then

                'oTraspasoSalidaTemp = Nothing

                'MsgBox("El Traspaso ha sido Aplicado satisfactoriamente.", MsgBoxStyle.Information, "DPTienda.")
            Else
12:             EscribeLog("No se pudo aplicar el traspaso de salida con folio: " & oTraspasoSalidaTemp.TraspasoID, "Error al aplicar traspaso salida automatico EC")
13:             MsgBox("El Traspaso de Salida no se Aplicó.", MsgBoxStyle.Exclamation, "DPTienda.")
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al aplicar el traspaso de salida: Linea " & Err.Erl)
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Function ValidaCodigosEnCatalogo(ByVal dtTemp As DataTable) As Boolean
        Dim strMateriales As String = ""
        Dim odrArticulo As DataRow
        Dim oArticulo As Articulo
        Dim bRes As Boolean = True

        For Each odrArticulo In dtTemp.Rows
            oArticulo = Nothing
            oArticulo = oArticulosMgr.Load(CStr(odrArticulo("Codigo")))
            If oArticulo Is Nothing Then
                strMateriales = CStr(odrArticulo("Codigo")) & vbCrLf
            End If
        Next

        If strMateriales.Trim <> "" Then
            strMateriales = "Los siguientes artículos no se encuentran en su catalogo favor de hacer la descarga:" & _
                             vbCrLf & strMateriales
            MessageBox.Show(strMateriales, "Valida Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
        End If

        Return bRes

    End Function

    Public Function CrearDetalleTraspasoSalida(ByVal dtConfirmados As DataTable) As DataSet

        Dim oRow As DataRow
        Dim oArticuloTemp As Articulo
        Dim cant As Integer = 0
        Dim dsTraspasoSalidaDetalle As DataSet
        Dim Talla As String = ""

        oTraspasoSMgr.CrearTablaTmp()

        For Each oRow In dtConfirmados.Rows
            oArticuloTemp = Nothing
            cant = 0
            oArticuloTemp = oArticulosMgr.Load(CStr(oRow!Codigo))
            If Not oArticuloTemp Is Nothing Then
                cant = CInt(oRow!Confirmados)
                If IsNumeric(oRow!Talla) Then
                    If InStr(CStr(oRow!Talla), ".5") <= 0 Then
                        Talla = CInt(oRow!Talla)
                    Else
                        Talla = CStr(oRow!Talla).Trim
                    End If
                Else
                    Talla = CStr(oRow!Talla).Trim
                End If
                oTraspasoSMgr.AgregarArticulo(oArticuloTemp, Talla, cant, oArticuloTemp.CostoProm * cant, 0)
            End If
        Next

        dsTraspasoSalidaDetalle = Nothing
        dsTraspasoSalidaDetalle = oTraspasoSMgr.GenerarTraspasoCorrida("[RefCruzTraspaso]")

        oArticuloTemp = Nothing

        Return dsTraspasoSalidaDetalle

    End Function

    Private Sub HabilitaPanelFactura(ByVal bRes As Boolean)
        Me.grpTraspasos.Enabled = bRes 'True
        Me.grpDetalle.Enabled = Not bRes 'False
        If Me.grpTraspasos.Enabled Then Me.nebFolioTraspaso.Focus()
    End Sub

    Private Sub MostrarDetallePedido()

        Limpiar(True)

        Dim strAlm() As String
        'row = CType(Me.grdPedidosEC.GetRow().DataRow, DataRowView).Row
        'Dim view As New DataView(dtCabeceraSH, "VBELN='" & CStr(row!Folio_pedido) & "'", "", DataViewRowState.CurrentRows)
        'If view.Count > 0 Then
        '    row_cab = view(0).Row
        '    Dim viewDet As New DataView(dtPedidosDet, "VBELN='" & CStr(row!Folio_pedido) & "'", "", DataViewRowState.CurrentRows)
        '    view_det = viewDet
        'End If
        Me.ebPedidoEC.Text = CStr(CType(Me.grdPedidosEC.GetRow().DataRow, DataRowView)!Folio_Pedido).Trim.PadLeft(10, "0")
        Dim cesum As String = ""

        If Me.ebPedidoEC.Text.Trim <> "" AndAlso CLng(Me.ebPedidoEC.Text.Trim) > 0 Then
            FiltraDetalle(Me.ebPedidoEC.Text.Trim)
            ActualizaGridDetalle()

            Dim dvPedido As DataView 'New DataView(dtPedidos, "Folio_Pedido = '" & Me.ebPedidoEC.Text.Trim & "'", "", DataViewRowState.CurrentRows)
            '---------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 17/04/2013: Filtramos el pedido segun el modulo origen de acceso
            '---------------------------------------------------------------------------------------------------------------------------------
            Select Case Modulo.Trim.ToUpper
                Case "PP", "PF"
                    '-------------------------------------------------------------------------------------------------------
                    ' JNAVA (11.03.2016): Seleccionamos el traslado creado anteriormente en caso de haber resolicitudes
                    '-------------------------------------------------------------------------------------------------------
                    'dvPedido = New DataView(dtPedidos, "Folio_Pedido = '" & Me.ebPedidoEC.Text.Trim & "'", "", DataViewRowState.CurrentRows)
                    row = CType(Me.grdPedidosEC.GetRow().DataRow, DataRowView).Row
                    dvPedido = New DataView(dtPedidos, "Folio_Pedido='" & CStr(row!Folio_pedido) & "'", "", DataViewRowState.CurrentRows)
                    If dvPedido.Count > 0 Then
                        row_cab = dvPedido(0).Row
                        Dim viewDet As New DataView(dtPedidosDet, "Folio_Pedido='" & CStr(row!Folio_pedido) & "'", "", DataViewRowState.CurrentRows)
                        view_det = viewDet
                    End If

                    Me.ebFolioTraspasoSAP.Text = dvPedido(0)!Folio_Traslado
                    Status = dvPedido(0)!Status
                    '-------------------------------------------------------------------------------------------------------
                    ' JNAVA (29.03.2016): Obtenemos el ID de la Solicitud
                    '-------------------------------------------------------------------------------------------------------
                    SolicitudID = dvPedido(0)!ID_SOLICITUD
                    '-------------------------------------------------------------------------------------------------------
                    'bFacturar = IIf(CStr(dvPedido(0)!Facturar).Trim = "X", True, False)
                Case "PPSH", "PRSH", "PFSH"
                    'dvPedido = New DataView(dtCabeceraSH, "VBELN = '" & Me.ebPedidoEC.Text.Trim & "' AND (Status_Sum = 'PE-L' OR Status_Sum = 'PE-F')", "", DataViewRowState.CurrentRows)

                    '-------------------------------------------------------------------------------------------------------
                    ' JNAVA (11.03.2016): Seleccionamos el traslado creado anteriormente en caso de haber resolicitudes
                    '-------------------------------------------------------------------------------------------------------
                    row = CType(Me.grdPedidosEC.GetRow().DataRow, DataRowView).Row
                    dvPedido = New DataView(dtCabeceraSH, "VBELN='" & CStr(row!Folio_pedido) & "'", "", DataViewRowState.CurrentRows)
                    If dvPedido.Count > 0 Then
                        row_cab = dvPedido(0).Row
                        Dim viewDet As New DataView(dtPedidosDet, "VBELN='" & CStr(row!Folio_pedido) & "'", "", DataViewRowState.CurrentRows)
                        view_det = viewDet
                    End If

                    '--------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 19/04/2013: Seleccionamos el traslado creado anteriormente en caso de haber resolicitudes
                    '--------------------------------------------------------------------------------------------------------------------------
                    Me.ebFolioTraspasoSAP.Text = ""
                    If dvPedido.Count > 0 Then Me.ebFolioTraspasoSAP.Text = dvPedido(0)!Folio_Entrega 'dvPedido(0)!Traslado
                    'For Each oRowV As DataRowView In dvPedido
                    '    If InStr("PE-F,PE-L", CStr(oRowV!Status_Sum).Trim.ToUpper) >= 0 Then
                    '        Me.ebFolioTraspasoSAP.Text = CStr(oRowV!Traslado).Trim
                    '        Exit For
                    '    End If
                    'Next
                    dvPedido.RowFilter = "VBELN = '" & Me.ebPedidoEC.Text.Trim & "'"
                    Status = dvPedido(0)!Status_Sum
                    bFacturar = IIf(Modulo.Trim.ToUpper <> "PPSH", True, False)
            End Select

            Me.ebCodAlmacenDestino.Text = dvPedido(0)!CEDES
            cesum = dvPedido(0)!CESUM
            CtoSuministrador = dvPedido(0)!CESUM
            If bFacturar Then
                '-------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 18/04/2013: Si es un pedido del Ecommerce validamos si la tienda va a facturar una concentración o solo su traslado
                'Si es un pedido SH entoces ya sabemos que es una concentracion
                '-------------------------------------------------------------------------------------------------------------------------------
                Select Case Modulo.Trim.ToUpper
                    Case "PF"
                        EsConcentracion()
                        If Status.Trim.ToUpper <> "P" Then
                            HabilitaPanelFactura(True)
                            'Agregamos el traspaso realizado anteriormente por esta tienda
                            Me.nebFolioTraspaso.Value = CLng(Me.ebFolioTraspasoSAP.Text.Trim)
                            AgregaTraspaso()
                            'Si no es una concentracion deshabilitamos la opción de agregar mas traspasos
                            Me.nebFolioTraspaso.Enabled = bConcen
                            Me.btnAgregar.Enabled = bConcen
                        Else
                            HabilitaPanelFactura(False)
                        End If
                    Case "PRSH", "PFSH"
                        bConcen = True
                        CentroConcentrador = oSAPMgr.Read_Centros()

                        HabilitaPanelFactura(True)

                        'Si no es una concentracion deshabilitamos la opción de agregar mas traspasos
                        Me.nebFolioTraspaso.Enabled = bConcen
                        Me.btnAgregar.Enabled = bConcen
                        If oConfigCierreFI.RegistrosTraspasoSiHay = True Then
                            oTraspasoEntrada = Nothing
                            oTraspasoEntrada = New TraspasoEntrada(oTraspasoEntradaMgr)
                            oTraspasoEntrada.AlmacenDestinoID = Me.ebCodAlmacenDestino.Text.Remove(0, 1)
                            oTraspasoEntrada.AlmacenOrigenID = cesum.Remove(0, 1)
                            oTraspasoEntrada.TransportistaID = "MIS"
                            oTraspasoEntrada.TotalBultos = 1
                            Dim fechaEntrada As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME().ToShortDateString()
                            oTraspasoEntrada.TraspasoCreadoEl = fechaEntrada
                            oTraspasoEntrada.TraspasoRecibidoEl = fechaEntrada
                            oTraspasoEntrada.Detalle = New DataSet
                        End If
                End Select
            End If
            strAlm = oSAPMgr.Read_CentrosSAP(Me.ebCodAlmacenDestino.Text)
            oAlmacen = oAlmacenMgr.Load(strAlm(2))
            If Not oAlmacen Is Nothing Then
                Me.ebAlmacenDestino.Text = oAlmacen.Descripcion
            Else
                Me.ebAlmacenDestino.Text = ""
            End If
        End If
        uICommandManager1.CommandBars("CommandBar1").Commands("menuAsignarGuia").Enabled = Janus.Windows.UI.InheritableBoolean.True
    End Sub

    Private Sub MostrarDetallePedidoEcommerce(ByVal grid As Janus.Windows.GridEX.GridEX)

        Limpiar(True)

        Dim strAlm() As String

        Me.ebPedidoEC.Text = CStr(CType(grid.GetRow().DataRow, DataRowView)!Folio_Pedido).Trim.PadLeft(10, "0")
        Me.VersionEcommerce = CStr(CType(grid.GetRow().DataRow, DataRowView)!Version).Substring(0, 3)
        row = CType(grid.GetRow().DataRow, DataRowView).Row
        Dim cesum As String = ""
        'Dim view As New DataView(dtCabeceraSH, "VBELN='" & CStr(row!Folio_pedido) & "'", "", DataViewRowState.CurrentRows)
        'If view.Count > 0 Then
        '    row_cab = view(0).Row
        '    Dim viewDet As New DataView(dtPedidosDet, "VBELN='" & CStr(row!Folio_pedido) & "'", "", DataViewRowState.CurrentRows)
        '    view_det = viewDet
        'End If
        If Me.ebPedidoEC.Text.Trim <> "" AndAlso CLng(Me.ebPedidoEC.Text.Trim) > 0 Then
            FiltraDetalle(Me.ebPedidoEC.Text.Trim)
            ActualizaGridDetalle()

            Dim dvPedido As DataView 'New DataView(dtPedidos, "Folio_Pedido = '" & Me.ebPedidoEC.Text.Trim & "'", "", DataViewRowState.CurrentRows)
            '---------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 17/04/2013: Filtramos el pedido segun el modulo origen de acceso
            '---------------------------------------------------------------------------------------------------------------------------------
            Select Case Modulo.Trim.ToUpper
                Case "PP", "PF"
                    dvPedido = New DataView(dtPedidos, "Folio_Pedido = '" & Me.ebPedidoEC.Text.Trim & "'", "", DataViewRowState.CurrentRows)
                    Me.ebFolioTraspasoSAP.Text = dvPedido(0)!Folio_Traslado
                    Status = dvPedido(0)!Status
                    '-------------------------------------------------------------------------------------------------------
                    ' JNAVA (29.06.2016): Obtenemos el ID de la Solicitud
                    '-------------------------------------------------------------------------------------------------------
                    SolicitudID = dvPedido(0)!ID_SOLICITUD
                    '-------------------------------------------------------------------------------------------------------
                    bFacturar = IIf(CStr(dvPedido(0)!Facturar).Trim = "X", True, False)
                Case "PPSH", "PRSH", "PFSH"
                    dvPedido = New DataView(dtCabeceraSH, "VBELN = '" & Me.ebPedidoEC.Text.Trim & "' AND (Status_Sum = 'PE-L' OR Status_Sum = 'PE-F')", "", DataViewRowState.CurrentRows)
                    '--------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 19/04/2013: Seleccionamos el traslado creado anteriormente en caso de haber resolicitudes
                    '--------------------------------------------------------------------------------------------------------------------------
                    Me.ebFolioTraspasoSAP.Text = ""
                    If dvPedido.Count > 0 Then Me.ebFolioTraspasoSAP.Text = dvPedido(0)!Traslado
                    'For Each oRowV As DataRowView In dvPedido
                    '    If InStr("PE-F,PE-L", CStr(oRowV!Status_Sum).Trim.ToUpper) >= 0 Then
                    '        Me.ebFolioTraspasoSAP.Text = CStr(oRowV!Traslado).Trim
                    '        Exit For
                    '    End If
                    'Next
                    dvPedido.RowFilter = "VBELN = '" & Me.ebPedidoEC.Text.Trim & "'"
                    Status = dvPedido(0)!Status_Sum
                    bFacturar = IIf(Modulo.Trim.ToUpper <> "PPSH", True, False)
            End Select

            Me.ebCodAlmacenDestino.Text = dvPedido(0)!CEDES
            Me.ebCodAlmacenDestino.Text = dvPedido(0)!CEDES
            cesum = dvPedido(0)!CESUM
            CtoSuministrador = dvPedido(0)!CESUM
            If bFacturar Then
                '-------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 18/04/2013: Si es un pedido del Ecommerce validamos si la tienda va a facturar una concentración o solo su traslado
                'Si es un pedido SH entoces ya sabemos que es una concentracion
                '-------------------------------------------------------------------------------------------------------------------------------
                Select Case Modulo.Trim.ToUpper
                    Case "PF"
                        EsConcentracion()
                        If Status.Trim.ToUpper <> "P" Then
                            HabilitaPanelFactura(True)
                            'Agregamos el traspaso realizado anteriormente por esta tienda
                            Me.nebFolioTraspaso.Value = CLng(Me.ebFolioTraspasoSAP.Text.Trim)
                            AgregaTraspaso()
                            'Si no es una concentracion deshabilitamos la opción de agregar mas traspasos
                            Me.nebFolioTraspaso.Enabled = bConcen
                            Me.btnAgregar.Enabled = bConcen
                        Else
                            HabilitaPanelFactura(False)
                        End If
                    Case "PRSH", "PFSH"
                        bConcen = True
                        CentroConcentrador = oSAPMgr.Read_Centros()

                        HabilitaPanelFactura(True)

                        'Si no es una concentracion deshabilitamos la opción de agregar mas traspasos
                        Me.nebFolioTraspaso.Enabled = bConcen
                        Me.btnAgregar.Enabled = bConcen
                End Select
            End If
            strAlm = oSAPMgr.Read_CentrosSAP(Me.ebCodAlmacenDestino.Text)
            oAlmacen = oAlmacenMgr.Load(strAlm(0))
            If Not oAlmacen Is Nothing Then
                Me.ebAlmacenDestino.Text = oAlmacen.Descripcion
            Else
                Me.ebAlmacenDestino.Text = ""
            End If
        End If
        'uICommandManager1.Commands("CommandBar1").Commands("menuAsignarGuia").Enabled = Janus.Windows.UI.InheritableBoolean.True
    End Sub

    Private Sub EsConcentracion()

        Dim oRow As DataRow
        Dim Centro As String = oSAPMgr.Read_Centros()

        bConcen = False

        dtConcentracion = oSAPMgr.ZPOL_CHK_CONCENTRA(Me.ebPedidoEC.Text)

        If Not dtConcentracion Is Nothing AndAlso dtConcentracion.Rows.Count > 0 Then
            For Each oRow In dtConcentracion.Rows
                If CStr(oRow!PuestoExpedicion).Trim.ToUpper <> CStr(oRow!CESUM).Trim.ToUpper Then
                    If CStr(oRow!PuestoExpedicion).Trim.ToUpper = Centro.Trim.ToUpper Then
                        bConcen = True
                        CentroConcentrador = CStr(oRow!PuestoExpedicion).Trim
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub CreaEstructuraDetalle()

        Me.dtDetalle = New DataTable("Detalle")

        With Me.dtDetalle
            '.Columns.Add(New DataColumn("FolioTraspaso", GetType(String)))
            .Columns.Add(New DataColumn("Codigo", GetType(String)))
            .Columns.Add("CodProveedor", GetType(String))
            .Columns.Add("Talla", GetType(String))
            '.Columns.Add(New DataColumn("Descripcion", GetType(String)))
            .Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
            .Columns.Add(New DataColumn("Negados", GetType(Integer)))
            '.Columns.Add(New DataColumn("Motivo", GetType(String)))
            .Columns.Add(New DataColumn("PedidoEC", GetType(String)))
            .Columns.Add(New DataColumn("Entregados", GetType(Integer)))
            .Columns.Add(New DataColumn("Solicitados", GetType(Integer)))
            '.Columns.Add(New DataColumn("Reparto", GetType(String)))
            '.Columns.Add(New DataColumn("Posicion", GetType(String)))
            '.Columns.Add(New DataColumn("Facturar", GetType(Boolean)))
            '-------------------------------------------------------------
            'JNAVA (12.06.2016): Agregamos ID de la Solicitud al detalle
            '-------------------------------------------------------------
            .Columns.Add(New DataColumn("ID_Solicitud", GetType(String)))
            '-------------------------------------------------------------
            .AcceptChanges()
        End With

    End Sub

    Private Sub FiltraDetalle(ByVal PedidoEC As String)

        Dim oRow As DataRowView
        Dim oNewRow As DataRow
        'Dim oView As New DataView(dtPedidosDet, "Folio_Pedido = '" & PedidoEC.Trim & "'", "", DataViewRowState.CurrentRows)
        Dim oView As DataView 'New DataView(dtPedidosDet, "Folio_Pedido = '" & PedidoEC.Trim & "' And Cant_Pendiente > 0", "", DataViewRowState.CurrentRows)
        '-------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 03/07/2013: Se filtra segun el modulo origen de acceso y los datos obtenidos desde SAP, para los Pedidos SH filtramos por
        'los status de P = Pendientes de surtir y RP = Resolicitud pendiente en caso de ser el modulo de surtido, los demas ya vienen
        'filtrados desde SAP
        '-------------------------------------------------------------------------------------------------------------------------------------
        Select Case Modulo.Trim.ToUpper
            Case "PP", "PF"
                oView = New DataView(dtPedidosDet, "Folio_Pedido = '" & PedidoEC.Trim & "' And Cant_Pendiente > 0", "", DataViewRowState.CurrentRows)
            Case "PPSH"
                oView = New DataView(dtCabeceraSH, "VBELN = '" & PedidoEC.Trim & "' And (Status_Sum = 'P' OR Status_Sum = 'RP')", "", DataViewRowState.CurrentRows)

                Dim oViewDet As DataView
                Dim oRowD As DataRowView
                Dim dtTemp As DataTable = dtPedidosDet.Clone
                For Each oRow In oView
                    oViewDet = New DataView(dtPedidosDet, "VBELN = '" & PedidoEC.Trim & "' And ID_Solicitud = '" & CStr(oRow!ID_Solicitud) & "'", "", DataViewRowState.CurrentRows)
                    For Each oRowD In oViewDet
                        dtTemp.ImportRow(oRowD.Row)
                    Next
                Next
                oView = New DataView(dtTemp, "VBELN = '" & PedidoEC.Trim & "'", "", DataViewRowState.CurrentRows)
            Case "PRSH", "PFSH"
                oView = New DataView(dtPedidosDet, "VBELN = '" & PedidoEC.Trim & "'", "", DataViewRowState.CurrentRows)
        End Select
        If oView.Count > 0 Then
            Dim articulo As Articulo = oArticulosMgr.Create()
            For Each oRow In oView
                '-------------------------------------------------------------
                'JNAVA (02.02.2017): Se comenta para corregir error en SH
                '-------------------------------------------------------------
                'oArticulosMgr.LoadInto(oRow!Material, articulo)
                'Dim talla As String = oArticulosMgr.GetTallaByCodigo(oRow!Material)
                '-------------------------------------------------------------
                oNewRow = dtDetalle.NewRow
                With oNewRow
                    Select Case Modulo.Trim.ToUpper
                        Case "PP", "PF"
                            '-------------------------------------------------------------
                            'JNAVA (02.02.2017): Se comenta para corregir error en SH
                            '-------------------------------------------------------------
                            oArticulosMgr.LoadInto(oRow!Material, articulo)
                            '-------------------------------------------------------------
                            !Codigo = oRow!Material
                            !CodProveedor = articulo.CodArtProv
                            '-------------------------------------------------------------
                            'JNAVA (02.02.2017): Obtenemos info del material
                            '-------------------------------------------------------------
                            !Talla = oArticulosMgr.GetTallaByCodigo(oRow!Material) 'talla
                            '-------------------------------------------------------------
                            !Cantidad = oRow!Cant_Pendiente
                            !Negados = 0
                            !PedidoEC = oRow!Folio_Pedido
                            !Entregados = oRow!Cant_Entregado
                            !Solicitados = oRow!Cantidad
                            '-------------------------------------------------------------
                            'JNAVA (12.06.2016): Agregamos ID de la Solicitud al detalle
                            '-------------------------------------------------------------
                            !ID_Solicitud = oRow!ID_Solicitud
                            '-------------------------------------------------------------
                        Case "PPSH", "PRSH", "PFSH"
                            '-------------------------------------------------------------
                            'JNAVA (02.02.2017): Obtenemos info del material
                            '-------------------------------------------------------------
                            oArticulosMgr.LoadInto(oRow!Matnr, articulo)
                            '-------------------------------------------------------------
                            !Codigo = oRow!Matnr
                            !CodProveedor = articulo.CodArtProv
                            '-------------------------------------------------------------
                            'JNAVA (02.02.2017): Obtenemos la Talla
                            '-------------------------------------------------------------
                            !Talla = oArticulosMgr.GetTallaByCodigo(oRow!Matnr) 'talla
                            '-------------------------------------------------------------
                            !Cantidad = oRow!Pendiente
                            !Negados = 0
                            !PedidoEC = oRow!Vbeln
                            !Entregados = oRow!Surtido
                            !Solicitados = oRow!Cantidad
                    End Select
                End With
                dtDetalle.Rows.Add(oNewRow)
            Next
            dtDetalle.AcceptChanges()
        End If

    End Sub

    Private Sub Limpiar(ByVal bDet As Boolean)

        If bDet = False Then
            If Not dtPedidos Is Nothing Then dtPedidos.Clear()
            If Not dtPedidosDet Is Nothing Then dtPedidosDet.Clear()
            ActualizaGridPedidosPendientes()
        End If

        If Not dtDetalle Is Nothing Then Me.dtDetalle.Clear()
        If Not dtNegados Is Nothing Then dtNegados.Clear()
        If Not dtConfirmados Is Nothing Then dtConfirmados.Clear()
        If Not dtTraspasos Is Nothing Then dtTraspasos.Clear()
        If Not dtConcentracion Is Nothing Then dtConcentracion.Clear()
        '---------------------------------------------------
        oTraspasoEntrada = Nothing

        Me.ebFolioTraspasoSAP.Text = ""
        Me.ebPedidoEC.Text = ""
        Me.ebAlmacenDestino.Text = ""
        Me.ebCodAlmacenDestino.Text = ""
        Me.nebFolioTraspaso.Value = 0
        Me.expNegados.Visible = False
        HabilitaPanelFactura(False)

        ActualizaGridDetalle()
        ActualizaGridNegados()
        ActualizaGridTraspasos()

        CentroConcentrador = ""
        UserSessionAplicated = ""
        UserNameAplicated = ""
        bFacturar = False
        bConcen = False
        Status = ""

        '----------------------------------------------------------------
        ' JNAVA (08.2017): Limpiamos descripcion de codigo seleccionado
        '----------------------------------------------------------------
        Me.lblCodigo.Text = String.Empty
        Me.lblDescripcion.Text = String.Empty
        '----------------------------------------------------------------

    End Sub

    'Private Sub FillMotivosNegados()

    '    Dim oRow As DataRow

    '    dtMotivosNegados = New DataTable("MotivosNegados")

    '    With dtMotivosNegados
    '        .Columns.Add(New DataColumn("MotivoID", GetType(Integer)))
    '        .Columns.Add(New DataColumn("Motivo", GetType(String)))
    '        .AcceptChanges()

    '        oRow = .NewRow

    '        oRow!MotivoID = 1
    '        oRow!Motivo = "Venta"
    '        .Rows.Add(oRow)

    '        oRow = .NewRow

    '        oRow!MotivoID = 2
    '        oRow!Motivo = "Porque quiero"
    '        .Rows.Add(oRow)

    '        .AcceptChanges()
    '    End With

    'End Sub

    Private Sub ActualizaGridDetalle()
        Me.grdDetallePedido.DataSource = Nothing
        Me.grdDetallePedido.DataSource = Me.dtDetalle
        Me.grdDetallePedido.Refresh()
    End Sub

    Private Sub ActualizaGridPedidosPendientes()
        If Modulo.Trim() = "PP" Or Modulo.Trim() = "PF" Then
            If oConfigCierreFI.AplicarSurtidoDPStreet Then
                dtPedidosDPortenis = dtPedidos.Clone()
                dtPedidosDPStreet = dtPedidos.Clone()
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
                Me.grdPedidosEC.DataSource = dtPedidos 'FiltraPedidosDiferentes(dtPedidos)
                Me.grdPedidosEC.Refresh()
            End If
        Else
            Me.grdPedidosEC.DataSource = Nothing
            Me.grdPedidosEC.DataSource = dtPedidos 'FiltraPedidosDiferentes(dtPedidos)
            Me.grdPedidosEC.Refresh()
        End If
    End Sub

    Private Sub RevisarTraspasosModificados()

        'Dim dvModif As New DataView(dtTrasModif, "", "", DataViewRowState.CurrentRows)
        Dim dvModif As DataView
        Dim oRow As DataRow
        Dim oRowV As DataRowView
        '----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 16/04/2013: Segun el modulo de acceso se filtran los pedidos con resolicitud de acuerdo a la informacion que se obtiene de SAP
        '----------------------------------------------------------------------------------------------------------------------------------------
        Select Case Modulo.Trim.ToUpper
            Case "PPSH", "PRSH", "PFSH"
                'Modificamos el nombre de la columna para que coincida con el grid
                dtPedidos.Columns("VBELN").ColumnName = "Folio_Pedido"
                dvModif = New DataView(dtPedidos, "Status = 'RP'", "", DataViewRowState.CurrentRows)

                For Each oRowV In dvModif
                    oRowV!Modificado = 1
                Next
            Case "PP", "PF"
                dvModif = New DataView(dtTrasModif, "", "", DataViewRowState.CurrentRows)

                For Each oRow In dtPedidos.Rows
                    If CStr(oRow!Folio_Traslado).Trim <> "" Then
                        dvModif.RowFilter = "Traslado = '" & CStr(oRow!Folio_Traslado).Trim & "'"
                        If dvModif.Count > 0 Then
                            oRow!Modificado = 1
                        End If
                    End If
                Next
        End Select

        dtPedidos.AcceptChanges()

    End Sub

    Private Sub ActualizaGridNegados()
        Me.grdNegados.DataSource = Nothing
        Me.grdNegados.DataSource = Me.dtNegados
        Me.grdNegados.Refresh()
    End Sub

    Private Function FiltraPedidosDiferentes(ByVal dtTemp As DataTable) As DataTable

        Dim dtRes As DataTable
        Dim oRow As DataRow
        Dim strFolios As String = ""

        If Not dtTemp Is Nothing AndAlso dtTemp.Rows.Count > 0 Then
            dtRes = dtTemp.Clone
            For Each oRow In dtTemp.Rows
                If InStr(strFolios.Trim, CStr(oRow!PEDIDO).Trim) <= 0 Then
                    strFolios &= CStr(oRow!PEDIDO).Trim & ","
                    dtRes.ImportRow(oRow)
                End If
            Next
            dtRes.AcceptChanges()
        End If

        Return dtRes

    End Function

    Private Sub FillMotivosValueList()
        '----------------------------------------------------------------------------------------------------------------------------------------
        'Obtenemos los motivos por los que podran negar los productos solicitados
        '----------------------------------------------------------------------------------------------------------------------------------------
        dtMotivosNegados = oSAPMgr.ZPOL_GET_MOTIVOS("MD")
        '----------------------------------------------------------------------------------------------------------------------------------------
        If Not dtMotivosNegados Is Nothing AndAlso dtMotivosNegados.Rows.Count > 0 Then
            '----------------------------------------------------------------------------------------------------------------------------------------
            'Get the Motivos column
            '----------------------------------------------------------------------------------------------------------------------------------------
            With Me.grdNegados.RootTable.Columns("Motivo")
                '------------------------------------------------------------------------------------------------------------------------------------
                'Set HasValueList property equal to true in order to be able to use the ValueList property
                '------------------------------------------------------------------------------------------------------------------------------------
                .HasValueList = True
                '------------------------------------------------------------------------------------------------------------------------------------
                'Fill the ValueList
                '------------------------------------------------------------------------------------------------------------------------------------
                .ValueList.PopulateValueList(dtMotivosNegados.DefaultView, "ID", "Motivo")
                '------------------------------------------------------------------------------------------------------------------------------------
                'An alternative way to fill the value list is using the Add method as follows:
                '------------------------------------------------------------------------------------------------------------------------------------
                'Dim View As System.Data.DataView = Ds.Tables("Categories").DefaultView
                'Dim row As System.Data.DataRowView
                'For Each row In View
                '    ValueList.Add(New Janus.Windows.GridEX.GridEXValueListItem(row("CategoryID"), CType(row("CategoryName"), String)))
                'Next
                '------------------------------------------------------------------------------------------------------------------------------------
                'Setting other column related properties
                '
                'When using a value list you could use DropDownList and Combo EditType 
                'in the column and the values for the dropdown list will be the values
                'in the ValueList collection
                '------------------------------------------------------------------------------------------------------------------------------------
                .EditType = Janus.Windows.GridEX.EditType.DropDownList
                '------------------------------------------------------------------------------------------------------------------------------------
                'To be able to sort using the replaced value and not the value in the
                'CategoryID field change the CompareTarget property to Text instead of value
                '------------------------------------------------------------------------------------------------------------------------------------
                .CompareTarget = Janus.Windows.GridEX.ColumnCompareTarget.Text
                '------------------------------------------------------------------------------------------------------------------------------------
                'Likewise, to group by the replaced text do:
                '------------------------------------------------------------------------------------------------------------------------------------
                .DefaultGroupInterval = Janus.Windows.GridEX.GroupInterval.Text
            End With
        End If

    End Sub

    Private Sub frmTraspasoAutoEcommerce_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Not Me.dtDetalle Is Nothing AndAlso Me.dtDetalle.Rows.Count > 0 Then
            Dim strMsg As String = ""

            Select Case Modulo.Trim.ToUpper
                Case "PP", "PPSH"
                    strMsg = "confirmar el traspaso"
                Case "PF", "PFSH"
                    strMsg = "facturar el pedido"
                Case "PRSH"
                    strMsg = "recibir el producto"
            End Select
            If MessageBox.Show("¿Estas seguro de salir sin " & strMsg & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub grdTraspasosEcommerce_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPedidosEC.DoubleClick
        If Modulo.Trim() = "PP" Or Modulo.Trim() = "PF" Then
            If oConfigCierreFI.AplicarSurtidoDPStreet = True Then
                If Not dtPedidosDPortenis Is Nothing AndAlso dtPedidosDPortenis.Rows.Count > 0 Then
                    MostrarDetallePedidoEcommerce(sender)
                End If
            Else
                If Not dtPedidos Is Nothing AndAlso dtPedidos.Rows.Count > 0 Then
                    MostrarDetallePedido()
                End If
            End If
        Else
            If Not dtPedidos Is Nothing AndAlso dtPedidos.Rows.Count > 0 Then
                MostrarDetallePedido()
            End If
        End If

    End Sub

    Private Sub btnBuscarTraspasos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarTraspasos.Click
        BuscarPedidosPendientes(True)
    End Sub

    Private Sub btnConfirmarTraspaso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmarTraspaso.Click
        SeleccionarMotivosNegados()
    End Sub

    Private Sub frmTraspasoAutoEcommerce_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.expNegados.Visible = False
    End Sub

    Private Sub btnConfirmarNegados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmarNegados.Click
        ConfirmarNegados()
    End Sub

    Private Sub grdNegados_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdNegados.CellValueChanged

        Dim oCRow As Janus.Windows.GridEX.GridEXRow = Me.grdNegados.GetRow
        Dim cant As Integer = 0
        Dim oRow As Janus.Windows.GridEX.GridEXRow
        Dim i As Integer = 0, idx As Integer = Me.grdNegados.Row, CurrentCant As String = Me.grdNegados.GetValue("Negados")

        If Me.grdNegados.Col = 2 AndAlso CStr(CurrentCant).Trim <> "" Then

            If IsNumeric(CurrentCant) Then

                If CInt(CurrentCant) <= 0 Then Me.grdNegados.SetValue("Negados", 1)

                Me.grdNegados.GetRow.DataRow!Negados = CurrentCant

                For Each oRow In Me.grdNegados.GetRows
                    If i <> idx AndAlso CStr(oRow.DataRow!Codigo).Trim = CStr(oCRow.DataRow!Codigo).Trim AndAlso CStr(oRow.DataRow!Talla).Trim = CStr(oCRow.DataRow!Talla).Trim Then
                        cant += oRow.DataRow!Negados
                    End If
                    i += 1
                Next

                If cant + CurrentCant > oCRow.DataRow!TotalNegados Then
                    Me.grdNegados.SetValue("Negados", oCRow.DataRow!TotalNegados - cant)
                ElseIf cant + CurrentCant < oCRow.DataRow!TotalNegados Then
                    AgregaNegado()
                End If
            Else
                oCRow.GridEX.SetValue("Negados", 0)
            End If
        ElseIf Me.grdNegados.Col = 3 AndAlso CStr(oCRow.GridEX.GetValue("Motivo")).Trim <> "" Then

            Me.grdNegados.GetRow.DataRow!Motivo = Me.grdNegados.GetValue("Motivo")

            For Each oRow In Me.grdNegados.GetRows
                If i <> idx AndAlso CStr(oRow.DataRow!Codigo).Trim = CStr(oCRow.DataRow!Codigo).Trim AndAlso CStr(oRow.DataRow!Talla).Trim = CStr(oCRow.DataRow!Talla).Trim _
                AndAlso CStr(oRow.Cells("Motivo").Value).Trim = CStr(oCRow.GridEX.GetValue("Motivo")).Trim Then
                    oRow.DataRow!Negados += oCRow.GridEX.GetValue("Negados")
                    cant = ValidaCantidadNegados()
                    If cant >= oRow.DataRow!TotalNegados Then
                        'oRow.DataRow!Negados = oRow.DataRow!TotalNegados - (cant - Me.grdNegados.GetValue("Negados"))
                        'dtNegados.Rows.RemoveAt(idx)
                        EliminarNegado(dtNegados, idx)
                        'dtNegados.AcceptChanges()
                        ActualizaGridNegados()
                    Else
                        oCRow.GridEX.SetValue("Motivo", "")
                        oCRow.GridEX.SetValue("Negados", 0)
                    End If
                    Exit For
                End If
                i += 1
            Next

        End If

    End Sub

    Private Sub EliminarNegado(ByRef dtOrig As DataTable, ByVal idx As Integer)
        Dim oRow As DataRow
        Dim dtTemp As DataTable = dtOrig.Clone
        Dim i As Integer = 0

        For Each oRow In dtOrig.Rows
            If i <> idx Then dtTemp.ImportRow(oRow)
            i += 1
        Next
        dtTemp.AcceptChanges()

        dtOrig = dtTemp.Copy

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        AgregaTraspaso()
    End Sub

    Private Sub btnFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFacturar.Click
        If Not dtTraspasos Is Nothing AndAlso dtTraspasos.Rows.Count > 0 Then
            EmitirFactura(Status, True)
        Else
            MessageBox.Show("Es necesario ingresar los folios de los traspasos recibidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub grdDetallePedido_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdDetallePedido.CellValueChanged
        If Me.grdDetallePedido.Col = 3 AndAlso CStr(Me.grdDetallePedido.GetValue("Negados")).Trim <> "" Then
            If Me.grdDetallePedido.GetValue("Cantidad") <= 0 Then
                Me.grdDetallePedido.SetValue("Negados", 0)
            ElseIf Me.grdDetallePedido.GetValue("Negados") < 0 Then
                Me.grdDetallePedido.SetValue("Negados", 0)
            ElseIf Me.grdDetallePedido.GetValue("Negados") > Me.grdDetallePedido.GetValue("Cantidad") Then
                Me.grdDetallePedido.SetValue("Negados", Me.grdDetallePedido.GetValue("Cantidad"))
            End If
        End If
    End Sub

    Private Sub uICommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles uICommandManager1.CommandClick

        Select Case e.Command.Key.ToUpper
            Case "menuAsignarGuia".ToUpper
                '----------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (18.02.2016): Llamamos el formulario para asignar guia dependiendo del modulo origen de acceso
                '----------------------------------------------------------------------------------------------------------------------------
                AsignarNumGuia()
                '----------------------------------------------------------------------------------------------------------------------------
            Case "menuReimprimir".ToUpper
                '------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 28/05/2013: Enviamos el mensaje segun el modulo origen de acceso
                '------------------------------------------------------------------------------------------------------------------------------
                'Dim strMsg As String = "", strTitle As String = ""
                'Select Case Modulo.Trim.ToUpper
                '    Case "PFSH"
                '        strMsg = "Escriba el folio del pedido a imprimir"
                '        strTitle = "Impresion de Pedido"
                '    Case Else
                '        strMsg = "Escriba el folio de nota de venta a imprimir"
                '        strTitle = "Impresion de Nota de Venta"
                'End Select
                Dim FacturaEC As String = InputBox("Escriba el folio de nota de venta a imprimir", "Impresion de Nota de Venta")
                If FacturaEC.Trim <> "" Then
                    '--------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 27/05/2013: Usamos la función según el módulo de origen de acceso
                    '--------------------------------------------------------------------------------------------------------------------------
                    Select Case Modulo.Trim.ToUpper
                        Case "PFSH"
                            ImprimirPedidoSH(FacturaEC)
                        Case Else
                            ImprimirFacturaEC(FacturaEC, True)
                    End Select
                Else
                    '--------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 27/05/2013: Usamos la función según el módulo de origen de acceso
                    '--------------------------------------------------------------------------------------------------------------------------
                    'Select Case Modulo.Trim
                    '    Case "PFSH"
                    '        MessageBox.Show("Es necesario indicar el folio del Pedido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '    Case Else
                    MessageBox.Show("Es necesario indicar el folio de Nota de Venta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'End Select
                End If

            Case "menuSalir".ToUpper
                Me.Close()
        End Select

    End Sub

    Private Sub nebFolioTraspaso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nebFolioTraspaso.KeyDown
        If e.KeyCode = Keys.Enter Then
            AgregaTraspaso()
        End If
    End Sub

    Private Sub frmTraspasoAutoEcommerce_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ModificarPantalla()
        Me.btnBuscarTraspasos.PerformClick()

    End Sub

    Private Sub grdDPStreet_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDPStreet.DoubleClick
        If Not dtPedidosDPStreet Is Nothing AndAlso dtPedidosDPStreet.Rows.Count > 0 Then
            MostrarDetallePedidoEcommerce(sender)
        End If
    End Sub

    Private Sub grdDetallePedido_SelectionChanged(sender As Object, e As System.EventArgs) Handles grdDetallePedido.SelectionChanged
        '----------------------------------------------------------------
        ' JNAVA (08.2017): mostramos descripcion de codigo seleccionado
        '----------------------------------------------------------------
        VerCodigoDescripcion()
        '----------------------------------------------------------------
    End Sub

#Region "DPCard Puntos"

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 28/04/2015: Valida si tiene puntos a bonificar o canjear
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub DPCardPuntos(ByVal frmFactura As frmFacturacionSinExistencia, ByVal dtMateriales As DataTable)
        If oConfigCierreFI.DPCardPuntos Then
            Dim pedido As New Pedidos(Me.ebPedidoEC.Text.Trim(), 2)
            If pedido.NoDPCardPuntos <> "" Then
                If pedido.CodDPCardPunto = "BON" Then
                    Dim ws As New WSBroker("WS_BLUE", True)
                    Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                    Dim oVendedorMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
                    Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedorMgr.Create
                    Dim formasPago As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.FacturaFormaPago(oAppContext)
                    Dim dsFormasPago As DataSet
                    dsFormasPago = formasPago.LoadByPedidoID(pedido.PedidoID)
                    Dim params As New Hashtable
                    Dim resultado As Hashtable
                    Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
                    params("CardId") = pedido.NoDPCardPuntos
                    params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                    params("Amount") = frmFactura.oFactura.SubTotal
                    params("TotalAmount") = frmFactura.oFactura.SubTotal
                    params("TicketId") = pedido.FolioSAP
                    params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                    Dim pagos As String = "", codFormaPago As String = ""
                    For Each row As DataRow In dsFormasPago.Tables(0).Rows
                        codFormaPago = CStr(row("CodFormasPago"))
                        If codFormaPago = "DPVL" Then
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "-" & CStr(row("DPValeID")) & "|"
                        Else
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "|"
                        End If
                    Next
                    params("ReferenceId3") = pagos.Remove(pagos.Length - 1, 1)
                    params("ReferenceId4") = ""
                    params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
                    params("SupervisorCode") = pedido.CodVendedor
                    params("SupervisorName") = oVendedor.Nombre
                    params("SellerCode") = pedido.CodVendedor
                    params("SellerName") = oVendedor.Nombre
                    Dim product As String = ""
                    Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                    Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                    Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                    Dim cantidad As Decimal = 0
                    For Each row As DataRow In dtMateriales.Rows
                        total = 0
                        descSistema = 0
                        descuento = 0
                        unitPrice = 0
                        cantidad = 0
                        articulo = ArticuloMgr.Load(CStr(row("Codigo")))
                        cantidad = Math.Round(CDec(row("Cantidad")), 2)
                        total = Math.Round(CDec(row("Total")), 2)
                        descSistema = Math.Round(CDec(row("Descuento")), 2)
                        total = total - descSistema
                        descuento = Math.Round(CDec(row("Adicional")), 2)
                        descuento = total * (descuento / 100)
                        total -= descuento
                        unitPrice = total / cantidad
                        product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    Next
                    params("Products") = product.Remove(product.Length - 1, 1)
                    params("NoAssigned1") = ""
                    params("NoAssigned2") = ""
                    resultado = ws.Collect(params)
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultID") = True Then
                            If resultado("ResultID") >= 0 Then
                                resultado("CardId") = pedido.NoDPCardPuntos
                                resultado("CodVendedor") = oVendedor.ID
                                resultado("TipoReporte") = "BON"
                                Dim dato As New Hashtable
                                dato("NoTarjeta") = pedido.NoDPCardPuntos
                                dato("CodDPCardPunto") = "BON"
                                oFacturaMgr.ActualizaNoDPCardPuntos(frmFactura.oFactura.FacturaID, dato)
                                PrintTicketDPCardPuntos(resultado)
                            Else
                                If CInt(resultado("ResultID")) = -27 Then
                                    Dim supervisor As String = InputBox("El nombre del supervisor que autoriza:", "Dportenis PRO")
                                    params("ReferenceId4") = supervisor
                                    resultado = ws.Collect(params)
                                    If resultado.Count > 0 Then
                                        If resultado.ContainsKey("ResultId") = True Then
                                            If CInt(resultado("ResultId")) > 0 Then
                                                resultado("CardId") = pedido.NoDPCardPuntos
                                                resultado("CodVendedor") = oVendedor.ID
                                                resultado("TipoReporte") = "BON"
                                                Dim dato As New Hashtable
                                                dato("NoTarjeta") = pedido.NoDPCardPuntos
                                                dato("CodDPCardPunto") = "BON"
                                                oFacturaMgr.ActualizaNoDPCardPuntos(frmFactura.oFactura.FacturaID, dato)
                                                PrintTicketDPCardPuntos(resultado)
                                            Else
                                                MessageBox.Show(CStr(resultado("Descripcion")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            End If
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
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 15/04/2015: Impresión de la activación de tarjeta DPCard Puntos de Blue Engine.
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintTicketDPCardPuntos(ByVal datos As Hashtable)
        Dim rptActivaciondpCard As New rptDPCardPuntos(datos)
        With rptActivaciondpCard
            .Document.Name = "Activacion DPCard Puntos"
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

#Region "Bloqueo de Articulos de Baja Calidad"
    Private Sub SaveDefectuosos(ByVal dtNegados As DataTable)
        'Creamos Defectuoso
        Dim oDefectuosoMgr As New DefectuososManager(oAppContext, oAppSAPConfig)
        Dim oDefectuoso As Defectuoso

        'Creamos Articulo
        Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim oArticulo As Articulo = oArticuloMgr.Create()

        'Creamos Vendedor
        Dim oVendedoresMgr As New CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As Vendedor = oVendedoresMgr.Create
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim err As String = ""
        Dim defectuosoID As Integer

        Dim codigo As String = "", talla As String = ""
        For Each row As DataRow In dtNegados.Rows
            oArticulo.ClearFields()
            codigo = CStr(row("Codigo"))
            oArticuloMgr.LoadInto(codigo, oArticulo)
            oDefectuoso = oDefectuosoMgr.Create()
            oDefectuoso.ClearFields()
            oDefectuoso.CodArticulo = oArticulo.CodArticulo
            talla = CStr(row("Talla"))
            talla = FormatTalla(talla)
            oDefectuoso.Numero = talla
            oDefectuoso.CostoUnit = oArticulo.PrecioVenta
            oDefectuoso.Cantidad = CDec(row("Cantidad"))
            oDefectuoso.DefectoNota = CStr(row("Motivo"))
            oDefectuoso.Usuario = oAppContext.Security.CurrentUser.ID
            oDefectuoso.UsuarioMov = oAppContext.Security.CurrentUser.ID
            oDefectuoso.Autorizo = oAppContext.Security.CurrentUser.ID
            oDefectuoso.FacturaID = 0
            oDefectuoso.FolioFactura = 0
            oDefectuoso.FolioSAP = "0"
            oDefectuoso.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
            oDefectuoso.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
            oDefectuoso.Fecha = process.MSS_GET_SY_DATE_TIME()
            Select Case Modulo.Trim.ToUpper
                Case "PP"
                    oDefectuoso.BloqueadoEcommerce = True
                    oDefectuoso.BloqueadoSiHay = False
                Case "PPSH"
                    oDefectuoso.BloqueadoSiHay = True
                    oDefectuoso.BloqueadoEcommerce = False
            End Select
            defectuosoID = oDefectuosoMgr.Save(oDefectuoso)
            If defectuosoID = 0 Then
                err &= "El código " & codigo & " con talla " & CStr(row("Talla")) & vbCrLf
            Else
                With oDefectuoso.Movimiento

                    .CodTipoMov = 0
                    .TipoMovimiento = ""
                    .StatusMov = "A"
                    .CodAlmacenMov = oDefectuoso.CodAlmacen
                    .Destino = oDefectuoso.CodAlmacen
                    .Folio = defectuosoID
                    .CodArticuloMov = oArticulo.CodArticulo
                    .Descripcion = oArticulo.Descripcion
                    .NumeroMov = 0
                    .Total = 0
                    .Apartados = 0
                    .Defectuosos = 0
                    .Promocion = 0
                    .VtasEspeciales = 0
                    .Consignacion = 0
                    .Transito = 0
                    .CodLinea = oArticulo.Codlinea
                    .CodMarca = oArticulo.CodMarca
                    .CodFamilia = oArticulo.CodFamilia
                    .CodUnidad = oArticulo.CodUnidadVta
                    .CodUso = oArticulo.CodUso
                    .CodCategoria = oArticulo.CodCategoria
                    .UsuarioMov = oDefectuoso.Usuario
                    .CostoUnit = oArticulo.PrecioVenta
                    .PrecioUnit = oArticulo.PrecioVenta
                    .FolioControl = ""
                    .CodCajaMov = oDefectuoso.CodCaja
                End With
                oDefectuosoMgr.SaveMoveInOut(0, "O", oDefectuoso.Numero, oDefectuoso)
            End If
        Next
        If err.Trim() <> "" Then
            MessageBox.Show(err, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/06/2015: Da el formato de talla a los articulos quitandole el 0 extra que le agrega
    '---------------------------------------------------------------------------------------------------------------------------
    Friend Function FormatTalla(ByVal strNumber As String) As String
        If IsNumeric(strNumber) Then
            If InStr(strNumber, ".5", CompareMethod.Text) = 0 Then
                strNumber = strNumber.Replace(".0", "")
            End If
        End If
        Return strNumber
    End Function

#End Region

#Region "Adecuaciones RETAIL"

    '----------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (18.02.2016): Se creo funcion para ejecutar en varias partes
    '----------------------------------------------------------------------------------------------------------------------------
    Private Sub AsignarNumGuia()
        '----------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 06/05/2013: Llamamos el formulario para asignar guia dependiendo del modulo origen de acceso
        '----------------------------------------------------------------------------------------------------------------------------
        Dim oFrm As frmPedidosSinGuia
        Select Case Modulo.Trim.ToUpper
            Case "PPSH", "PRSH" 'Pedidos Si Hay
                oFrm = New frmPedidosSinGuia(Modulo, row, row_cab, view_det)
            Case Else 'Pedidos Eccomerce
                oFrm = New frmPedidosSinGuia(Modulo, row, row_cab, view_det)
        End Select
        oFrm.ShowDialog()
        Me.guias = oFrm.Info_Guia
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (18.02.2016): Se creo funcion para ejecutar el nuevo proceso de envio de Pedidos de EC
    '----------------------------------------------------------------------------------------------------------------------------
    Private Sub EnviarPedidoEC()

        Dim htStatus As Hashtable
        Dim htSurtido As Hashtable
        Dim strMensaje As String = String.Empty
        Dim strEntregaPedido As String = String.Empty

        '----------------------------------------------------------------------------------------------------------------------------------------
        'Asignamos el motivo de negacion a las piezas negadas por la sucursal
        '----------------------------------------------------------------------------------------------------------------------------------------
        SetMotivoNegDesc(dtNegados)

        '----------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (12.03.2016): Surtimos la entrega de EC con las piezas confirmadas
        '----------------------------------------------------------------------------------------------------------------------------------------
        If Not dtConfirmados Is Nothing AndAlso dtConfirmados.Rows.Count > 0 Then
            If ValidarExistencia(dtConfirmados).Trim = "" Then
                htSurtido = oSAPMgr.ZPOL_SURTIDO_ENTREGA(Me.ebPedidoEC.Text, CStr(Me.guias("Guia")), CStr(Me.guias("Transportista")), Me.dtConfirmados, strMensaje)
                If strMensaje <> String.Empty Then
                    MessageBox.Show("Ocurrio un error al Surtir el Pedido de Ecommerce en SAP.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EscribeLog(strMensaje, "Error al Surtir el Pedido de Ecommerce en SAP")
                    htSurtido = Nothing
                    Exit Sub
                End If

                '----------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (17.03.2016): Obtenemos la entrega
                '----------------------------------------------------------------------------------------------------------------------------------------
                strEntregaPedido = htSurtido("E_ENTREGA")
                '----------------------------------------------------------------------------------------------------------------------------------------

                '----------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (08.07.2016): Aplicamos el traspaso de salida con las piezas confirmadas
                '----------------------------------------------------------------------------------------------------------------------------------------
                Me.ebFolioTraspasoSAP.Text = strEntregaPedido
                If Not dtConfirmados Is Nothing AndAlso dtConfirmados.Rows.Count > 0 Then
                    If GenerarTraspasoSalida(dtConfirmados, Me.ebPedidoEC.Text.Trim, Me.ebCodAlmacenDestino.Text, UserSessionAplicated, "", strEntregaPedido) = False Then
                        Exit Sub
                    End If
                End If

            Else
                Exit Sub
            End If

        End If

        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Actualizamos el status en la tabla de traspasos pendientes por surtir en SAP y agregamos los codigos confirmados en caso de existir
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim bModificado As Boolean = False
        Dim strMsg As String = ""
        If oConfigCierreFI.AplicarSurtidoDPStreet = True Then
            If Me.VersionEcommerce.Trim() = "DPT" Then
                bModificado = CBool(Me.grdPedidosEC.GetRow.DataRow!Modificado)
            ElseIf Me.VersionEcommerce.Trim() = "DPS" Then
                bModificado = CBool(Me.grdDPStreet.GetRow().DataRow!Modificado)
            Else
                bModificado = CBool(Me.grdPedidosEC.GetRow.DataRow!Modificado)
            End If
        Else
            bModificado = CBool(Me.grdPedidosEC.GetRow.DataRow!Modificado)
        End If

        If dtConfirmados.Rows.Count > 0 AndAlso dtNegados.Rows.Count > 0 Then
            Status = "PF"
            If bModificado Then
                strMsg = "Para esta nueva solicitud, los artículos indicados se agregaron correctamente"
            Else
                strMsg = "El pedido se ha surtido correctamente"
            End If
        ElseIf dtConfirmados.Rows.Count > 0 Then
            Status = "F"
            If bModificado Then
                strMsg = "Para esta nueva solicitud, los artículos indicados se agregaron correctamente"
            Else
                strMsg = "El pedido se ha surtido correctamente"
            End If
        ElseIf dtNegados.Rows.Count > 0 Then
            Status = "N"
            If bModificado Then
                strMsg = "Para esta nueva solicitud, los artículos indicados se han negado correctamente"
            Else
                strMsg = "El pedido se ha Negado correctamente."
            End If
        End If

        '---------------------------------------------------------------------------------------------------------------------------------
        ' Obtenemos el status del repedido, revisando las piezas confirmadas en el detalle
        '---------------------------------------------------------------------------------------------------------------------------------
        If bModificado Then
            Status = ""
            Status = GetStatusRePedido()
        End If

        '-----------------------------------------------------------------------------------------------------------------------------------------
        ' Ahora marcamos primero todos los faltantes como de baja calidad para que Ecommerce no los vea en el inventario de la tienda 
        ' y en caso de los pedidos SH para que cuando haga la nueva solicitud de lo negado ya no tome este centro en cuenta para dicha
        ' solicitud
        '-----------------------------------------------------------------------------------------------------------------------------------------
        MarcarBajaCalidadEC(dtNegados)

        '---------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (29.06.2016): Actualizamos el pedido en SAP de Ecommerce
        '---------------------------------------------------------------------------------------------------------------------------------
        oSAPMgr.ZPOL_ACTTRASL(Me.ebPedidoEC.Text, Me.ebFolioTraspasoSAP.Text, Status, strEntregaPedido, ebPlayer.Text.Trim(), dtConfirmados, SolicitudID)

        '----------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (29.06.2016): Validamos que al menos haya un producto confirmado
        '----------------------------------------------------------------------------------------------------------------------------------------
        If Not Me.dtConfirmados Is Nothing AndAlso Me.dtConfirmados.Rows.Count > 0 Then

            '----------------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (17.03.2016): Grabamos Envio de EC 
            '----------------------------------------------------------------------------------------------------------------------------------------
            GrabarEnvioEC(Me.ebPedidoEC.Text, CStr(Me.guias("Transportista")), CStr(Me.guias("Guia")), strEntregaPedido, SolicitudID)

        End If

        '---------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (22.06.2016): Validamos si hay negados para guardar los materiales en SAP
        '---------------------------------------------------------------------------------------------------------------------------------
        If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
            '---------------------------------------------------------------------------------------------------------------------------------
            'Guardamos los materiales negados en SAP
            '---------------------------------------------------------------------------------------------------------------------------------
            oSAPMgr.ZPOL_TRASL_NEGAR("", "", UserNameAplicated, dtNegados)
        End If

        '---------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (17.03.2016): Se Imprime la Nota de venta en base a la Entrega
        '---------------------------------------------------------------------------------------------------------------------------------
        ImprimirFacturaEC(strEntregaPedido)

        '----------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (09.01.2017): Validamos si se puede Reimprimir
        '----------------------------------------------------------------------------------------------------------------------------------
        If Not Me.dtConfirmados Is Nothing AndAlso Me.dtConfirmados.Rows.Count > 0 Then
            If MessageBox.Show("¿Deseas reimprimir la nota de venta?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                ImprimirFacturaEC(strEntregaPedido)
            End If
        End If
        '----------------------------------------------------------------------------------------------------------------------------------

        '-------------------------------------------------------------------------------------------------------------------------------------
        'Enviamos el mensaje correcto según el tipo de pedido
        '-------------------------------------------------------------------------------------------------------------------------------------
        'If Me.ebFolioTraspasoSAP.Text.Trim <> "" AndAlso CLng(Me.ebFolioTraspasoSAP.Text.Trim) > 0 Then strMsg &= " con el traspaso " & Me.ebFolioTraspasoSAP.Text
        'If FacturaSAP.Trim <> "" Then strMsg &= " y facturado con el folio " & FacturaSAP.Trim

        MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Buscamos pedidos pendientes
        '-----------------------------------------------------------------------------------------------------------------------------------------
        BuscarPedidosPendientes()

        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Actualizamos el panel que muestra los pedidos pendientes del Ecommerce
        '-----------------------------------------------------------------------------------------------------------------------------------------
        RefreshPedidosEC()

    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (17.03.2016): Funcion para Grabar envio de Ecommerce
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Sub GrabarEnvioEC(ByVal Pedido As String, ByVal Paqueteria As String, ByVal Guia As String, ByVal Entrega As String, ByVal SolicitudID As String)
        Dim strRes As String = String.Empty

        strRes = oSAPMgr.ZPOL_GRABAR_ENVIO(Pedido, Paqueteria, Guia, False, Entrega, SolicitudID).Trim()

        If strRes.Trim.ToUpper = "S" Then

            MessageBox.Show("La guía " & Guia & " se ha utilizado correctamente para el pedido " & Pedido, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            '----------------------------------------------------------------------------------------------------------------------------------
            ' Agregamos este mensaje para que los players no se desesperan y vean que todavia no ha terminado el proceso
            '----------------------------------------------------------------------------------------------------------------------------------
            Dim oFrmMsg As New frmMessages
            oFrmMsg.Text = "Actualizacion de Pedidos"
            oFrmMsg.lblMessage.Text = "Actualizando Pedidos Pendientes... Favor de Esperar"
            oFrmMsg.Show()
            Application.DoEvents()

            oFrmMsg.Close()
        End If
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (07.02.2017): Funcion para Grabar envio de Ecommerce
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Sub VerCodigoDescripcion()
        If Not Me.dtDetalle Is Nothing AndAlso Me.dtDetalle.Rows.Count > 0 Then
            Dim oRow As DataRow
            oRow = Me.dtDetalle.Rows(grdDetallePedido.Row)
            If Not oRow Is Nothing Then
                Dim oArticulo As Articulo = oArticulosMgr.Create()
                oArticulosMgr.LoadInto(CStr(oRow!Codigo), oArticulo)
                Me.lblCodigo.Text = oArticulo.CodArtProv
                Me.lblDescripcion.Text = oArticulo.Descripcion
                oArticulo = Nothing
            Else
                Me.lblCodigo.Text = String.Empty
                Me.lblDescripcion.Text = String.Empty
            End If
        Else
            Me.lblCodigo.Text = String.Empty
            Me.lblDescripcion.Text = String.Empty
        End If
    End Sub

#End Region

#Region "Colaborador Ecommerce"

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 10/07/2017: Se muestra una lista de los todos los vendedores
    '------------------------------------------------------------------------------------------------------------------------------------

    Private Sub LoadSearchFormPlayer()

        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

        oOpenRecordDialogView.ShowDialog()

        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then

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

    Private Sub ebPlayer_ButtonClick(sender As System.Object, e As System.EventArgs) Handles ebPlayer.ButtonClick
        LoadSearchFormPlayer()
    End Sub

    Private Sub ebPlayer_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ebPlayer.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchFormPlayer()
            ebPlayer.Focus()
            ebPlayer.SelectAll()

        End If
    End Sub

    Private Sub ebPlayer_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ebPlayer.Validating
        Dim oVendedoresMgr As New CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As Vendedor = oVendedoresMgr.Create()
        If ebPlayer.Text.Trim <> "" Then

            ebPlayer.Text = ebPlayer.Text.PadLeft(8, "0")

            oVendedor.ClearFields()

            oVendedoresMgr.LoadInto(ebPlayer.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then

                ebNombrePlayer.Text = oVendedor.Nombre
                UserNameAplicated = oVendedor.ID
            Else
                MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación ")
                oVendedor.ClearFields()
                Me.ebNombrePlayer.Text = ""
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub grdPedidosEC_FormattingRow(sender As System.Object, e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdPedidosEC.FormattingRow

    End Sub
End Class
