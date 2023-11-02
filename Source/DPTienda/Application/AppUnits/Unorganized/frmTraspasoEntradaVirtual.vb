Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmTraspasoEntradaVirtual
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
    Friend WithEvents explorador As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents MenuAndToolbar As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents MnuPrintTraspaso As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebNumBulto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtObservaciones As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents ebDestino As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblNoCaja As System.Windows.Forms.Label
    Friend WithEvents grdDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblFolioTraspaso As System.Windows.Forms.Label
    Friend WithEvents ebSucOrigenDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucOrigenCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents lblCodBarras As System.Windows.Forms.Label
    Friend WithEvents txtCodigoBarra As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnEntrada As Janus.Windows.EditControls.UIButton
    Friend WithEvents MnuCargarTraspaso As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCargarTraspaso1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuFoliosCajas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuFoliosCajas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuPrintTraspaso1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents lblFolioEntrada As System.Windows.Forms.Label
    Friend WithEvents txtFolioEntrada As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents MnuNuevoFolio As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuNuevoFolio1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuNuevaCaja As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuNuevaCaja1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraspasoEntradaVirtual))
        Me.explorador = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.txtFolioEntrada = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblFolioEntrada = New System.Windows.Forms.Label()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnEntrada = New Janus.Windows.EditControls.UIButton()
        Me.txtCodigoBarra = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCodBarras = New System.Windows.Forms.Label()
        Me.ebNumBulto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtObservaciones = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.ebDestino = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblNoCaja = New System.Windows.Forms.Label()
        Me.grdDetalle = New Janus.Windows.GridEX.GridEX()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblFolioTraspaso = New System.Windows.Forms.Label()
        Me.ebSucOrigenDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucOrigenCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.MenuAndToolbar = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.MnuNuevoFolio1 = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevoFolio")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuNuevaCaja1 = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevaCaja")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuCargarTraspaso1 = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarTraspaso")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuFoliosCajas1 = New Janus.Windows.UI.CommandBars.UICommand("MnuFoliosCajas")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuPrintTraspaso1 = New Janus.Windows.UI.CommandBars.UICommand("MnuPrintTraspaso")
        Me.MnuPrintTraspaso = New Janus.Windows.UI.CommandBars.UICommand("MnuPrintTraspaso")
        Me.MnuSalir = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuCargarTraspaso = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarTraspaso")
        Me.MnuFoliosCajas = New Janus.Windows.UI.CommandBars.UICommand("MnuFoliosCajas")
        Me.MnuNuevoFolio = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevoFolio")
        Me.MnuNuevaCaja = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevaCaja")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.explorador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorador.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MenuAndToolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorador
        '
        Me.explorador.Controls.Add(Me.txtFolioEntrada)
        Me.explorador.Controls.Add(Me.lblFolioEntrada)
        Me.explorador.Controls.Add(Me.btnSalir)
        Me.explorador.Controls.Add(Me.btnEntrada)
        Me.explorador.Controls.Add(Me.txtCodigoBarra)
        Me.explorador.Controls.Add(Me.lblCodBarras)
        Me.explorador.Controls.Add(Me.ebNumBulto)
        Me.explorador.Controls.Add(Me.txtObservaciones)
        Me.explorador.Controls.Add(Me.lblObservaciones)
        Me.explorador.Controls.Add(Me.ebDestino)
        Me.explorador.Controls.Add(Me.lblDestino)
        Me.explorador.Controls.Add(Me.ebFecha)
        Me.explorador.Controls.Add(Me.lblFecha)
        Me.explorador.Controls.Add(Me.lblNoCaja)
        Me.explorador.Controls.Add(Me.grdDetalle)
        Me.explorador.Controls.Add(Me.ebFolio)
        Me.explorador.Controls.Add(Me.lblFolioTraspaso)
        Me.explorador.Controls.Add(Me.ebSucOrigenDesc)
        Me.explorador.Controls.Add(Me.ebSucOrigenCod)
        Me.explorador.Controls.Add(Me.lblOrigen)
        Me.explorador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorador.Location = New System.Drawing.Point(0, 28)
        Me.explorador.Name = "explorador"
        Me.explorador.Size = New System.Drawing.Size(610, 444)
        Me.explorador.TabIndex = 0
        Me.explorador.Text = "ExplorerBar1"
        Me.explorador.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'txtFolioEntrada
        '
        Me.txtFolioEntrada.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtFolioEntrada.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtFolioEntrada.BackColor = System.Drawing.SystemColors.Info
        Me.txtFolioEntrada.Location = New System.Drawing.Point(152, 38)
        Me.txtFolioEntrada.Name = "txtFolioEntrada"
        Me.txtFolioEntrada.ReadOnly = True
        Me.txtFolioEntrada.Size = New System.Drawing.Size(112, 20)
        Me.txtFolioEntrada.TabIndex = 41
        Me.txtFolioEntrada.TabStop = False
        Me.txtFolioEntrada.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtFolioEntrada.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFolioEntrada
        '
        Me.lblFolioEntrada.AutoSize = True
        Me.lblFolioEntrada.BackColor = System.Drawing.Color.Transparent
        Me.lblFolioEntrada.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioEntrada.Location = New System.Drawing.Point(8, 40)
        Me.lblFolioEntrada.Name = "lblFolioEntrada"
        Me.lblFolioEntrada.Size = New System.Drawing.Size(145, 14)
        Me.lblFolioEntrada.TabIndex = 40
        Me.lblFolioEntrada.Text = "Folio Traspaso Entrada"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(488, 400)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(112, 32)
        Me.btnSalir.TabIndex = 39
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnEntrada
        '
        Me.btnEntrada.Location = New System.Drawing.Point(360, 400)
        Me.btnEntrada.Name = "btnEntrada"
        Me.btnEntrada.Size = New System.Drawing.Size(112, 32)
        Me.btnEntrada.TabIndex = 38
        Me.btnEntrada.Text = "Dar entrada"
        Me.btnEntrada.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtCodigoBarra
        '
        Me.txtCodigoBarra.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCodigoBarra.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCodigoBarra.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigoBarra.Location = New System.Drawing.Point(152, 12)
        Me.txtCodigoBarra.Name = "txtCodigoBarra"
        Me.txtCodigoBarra.Size = New System.Drawing.Size(288, 20)
        Me.txtCodigoBarra.TabIndex = 37
        Me.txtCodigoBarra.TabStop = False
        Me.txtCodigoBarra.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCodigoBarra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCodBarras
        '
        Me.lblCodBarras.AutoSize = True
        Me.lblCodBarras.BackColor = System.Drawing.Color.Transparent
        Me.lblCodBarras.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodBarras.Location = New System.Drawing.Point(8, 14)
        Me.lblCodBarras.Name = "lblCodBarras"
        Me.lblCodBarras.Size = New System.Drawing.Size(124, 14)
        Me.lblCodBarras.TabIndex = 36
        Me.lblCodBarras.Text = "Folio Codigo Barras"
        '
        'ebNumBulto
        '
        Me.ebNumBulto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumBulto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumBulto.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumBulto.Location = New System.Drawing.Point(472, 40)
        Me.ebNumBulto.Name = "ebNumBulto"
        Me.ebNumBulto.ReadOnly = True
        Me.ebNumBulto.Size = New System.Drawing.Size(112, 20)
        Me.ebNumBulto.TabIndex = 35
        Me.ebNumBulto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumBulto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtObservaciones
        '
        Me.txtObservaciones.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtObservaciones.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtObservaciones.Location = New System.Drawing.Point(105, 152)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(479, 56)
        Me.txtObservaciones.TabIndex = 34
        Me.txtObservaciones.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtObservaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.BackColor = System.Drawing.Color.Transparent
        Me.lblObservaciones.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservaciones.Location = New System.Drawing.Point(9, 152)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(94, 14)
        Me.lblObservaciones.TabIndex = 33
        Me.lblObservaciones.Text = "Observaciones"
        '
        'ebDestino
        '
        Me.ebDestino.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDestino.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDestino.Location = New System.Drawing.Point(65, 120)
        Me.ebDestino.Name = "ebDestino"
        Me.ebDestino.Size = New System.Drawing.Size(519, 20)
        Me.ebDestino.TabIndex = 32
        Me.ebDestino.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDestino.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.BackColor = System.Drawing.Color.Transparent
        Me.lblDestino.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDestino.Location = New System.Drawing.Point(9, 120)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(47, 14)
        Me.lblDestino.TabIndex = 31
        Me.lblDestino.Text = "Origen"
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.SystemColors.Info
        Me.ebFecha.Location = New System.Drawing.Point(472, 88)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(112, 20)
        Me.ebFecha.TabIndex = 29
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(392, 88)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(41, 14)
        Me.lblFecha.TabIndex = 30
        Me.lblFecha.Text = "Fecha"
        '
        'lblNoCaja
        '
        Me.lblNoCaja.AutoSize = True
        Me.lblNoCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblNoCaja.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCaja.Location = New System.Drawing.Point(392, 40)
        Me.lblNoCaja.Name = "lblNoCaja"
        Me.lblNoCaja.Size = New System.Drawing.Size(76, 14)
        Me.lblNoCaja.TabIndex = 28
        Me.lblNoCaja.Text = "No. de Caja"
        '
        'grdDetalle
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdDetalle.DesignTimeLayout = GridEXLayout1
        Me.grdDetalle.GroupByBoxVisible = False
        Me.grdDetalle.Location = New System.Drawing.Point(9, 224)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.Size = New System.Drawing.Size(591, 160)
        Me.grdDetalle.TabIndex = 22
        Me.grdDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.BackColor = System.Drawing.SystemColors.Info
        Me.ebFolio.Location = New System.Drawing.Point(152, 64)
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.ReadOnly = True
        Me.ebFolio.Size = New System.Drawing.Size(112, 20)
        Me.ebFolio.TabIndex = 26
        Me.ebFolio.TabStop = False
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFolioTraspaso
        '
        Me.lblFolioTraspaso.AutoSize = True
        Me.lblFolioTraspaso.BackColor = System.Drawing.Color.Transparent
        Me.lblFolioTraspaso.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioTraspaso.Location = New System.Drawing.Point(9, 64)
        Me.lblFolioTraspaso.Name = "lblFolioTraspaso"
        Me.lblFolioTraspaso.Size = New System.Drawing.Size(133, 14)
        Me.lblFolioTraspaso.TabIndex = 27
        Me.lblFolioTraspaso.Text = "Folio Traspaso Salida"
        '
        'ebSucOrigenDesc
        '
        Me.ebSucOrigenDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenDesc.BackColor = System.Drawing.SystemColors.Info
        Me.ebSucOrigenDesc.Location = New System.Drawing.Point(137, 88)
        Me.ebSucOrigenDesc.Name = "ebSucOrigenDesc"
        Me.ebSucOrigenDesc.ReadOnly = True
        Me.ebSucOrigenDesc.Size = New System.Drawing.Size(200, 20)
        Me.ebSucOrigenDesc.TabIndex = 25
        Me.ebSucOrigenDesc.TabStop = False
        Me.ebSucOrigenDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucOrigenDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucOrigenCod
        '
        Me.ebSucOrigenCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenCod.BackColor = System.Drawing.SystemColors.Info
        Me.ebSucOrigenCod.ButtonImage = CType(resources.GetObject("ebSucOrigenCod.ButtonImage"), System.Drawing.Image)
        Me.ebSucOrigenCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucOrigenCod.Location = New System.Drawing.Point(65, 88)
        Me.ebSucOrigenCod.Name = "ebSucOrigenCod"
        Me.ebSucOrigenCod.ReadOnly = True
        Me.ebSucOrigenCod.Size = New System.Drawing.Size(64, 22)
        Me.ebSucOrigenCod.TabIndex = 24
        Me.ebSucOrigenCod.TabStop = False
        Me.ebSucOrigenCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucOrigenCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.BackColor = System.Drawing.Color.Transparent
        Me.lblOrigen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrigen.Location = New System.Drawing.Point(9, 88)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(54, 14)
        Me.lblOrigen.TabIndex = 23
        Me.lblOrigen.Text = "Destino"
        '
        'MenuAndToolbar
        '
        Me.MenuAndToolbar.BottomRebar = Me.BottomRebar1
        Me.MenuAndToolbar.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.MenuAndToolbar.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuPrintTraspaso, Me.MnuSalir, Me.MnuCargarTraspaso, Me.MnuFoliosCajas, Me.MnuNuevoFolio, Me.MnuNuevaCaja})
        Me.MenuAndToolbar.ContainerControl = Me
        '
        '
        '
        Me.MenuAndToolbar.EditContextMenu.Key = ""
        Me.MenuAndToolbar.Id = New System.Guid("bfeedc6a-9310-4eed-b18e-1a0e03584476")
        Me.MenuAndToolbar.LeftRebar = Me.LeftRebar1
        Me.MenuAndToolbar.LockCommandBars = True
        Me.MenuAndToolbar.RightRebar = Me.RightRebar1
        Me.MenuAndToolbar.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MenuAndToolbar.TopRebar = Me.TopRebar1
        Me.MenuAndToolbar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.MenuAndToolbar
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.MenuAndToolbar
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuNuevoFolio1, Me.Separator4, Me.MnuNuevaCaja1, Me.Separator5, Me.MnuCargarTraspaso1, Me.Separator1, Me.MnuFoliosCajas1, Me.Separator2, Me.MnuPrintTraspaso1})
        Me.UiCommandBar1.Key = "tbTraspasos"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(579, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'MnuNuevoFolio1
        '
        Me.MnuNuevoFolio1.Image = CType(resources.GetObject("MnuNuevoFolio1.Image"), System.Drawing.Image)
        Me.MnuNuevoFolio1.Key = "MnuNuevoFolio"
        Me.MnuNuevoFolio1.Name = "MnuNuevoFolio1"
        Me.MnuNuevoFolio1.Text = "Nuevo Traspaso"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'MnuNuevaCaja1
        '
        Me.MnuNuevaCaja1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MnuNuevaCaja1.Image = CType(resources.GetObject("MnuNuevaCaja1.Image"), System.Drawing.Image)
        Me.MnuNuevaCaja1.Key = "MnuNuevaCaja"
        Me.MnuNuevaCaja1.Name = "MnuNuevaCaja1"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'MnuCargarTraspaso1
        '
        Me.MnuCargarTraspaso1.Image = CType(resources.GetObject("MnuCargarTraspaso1.Image"), System.Drawing.Image)
        Me.MnuCargarTraspaso1.Key = "MnuCargarTraspaso"
        Me.MnuCargarTraspaso1.Name = "MnuCargarTraspaso1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'MnuFoliosCajas1
        '
        Me.MnuFoliosCajas1.Image = CType(resources.GetObject("MnuFoliosCajas1.Image"), System.Drawing.Image)
        Me.MnuFoliosCajas1.Key = "MnuFoliosCajas"
        Me.MnuFoliosCajas1.Name = "MnuFoliosCajas1"
        Me.MnuFoliosCajas1.Text = "Cajas Traspaso Salida"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'MnuPrintTraspaso1
        '
        Me.MnuPrintTraspaso1.Image = CType(resources.GetObject("MnuPrintTraspaso1.Image"), System.Drawing.Image)
        Me.MnuPrintTraspaso1.Key = "MnuPrintTraspaso"
        Me.MnuPrintTraspaso1.Name = "MnuPrintTraspaso1"
        Me.MnuPrintTraspaso1.Text = "Imprimir"
        '
        'MnuPrintTraspaso
        '
        Me.MnuPrintTraspaso.Key = "MnuPrintTraspaso"
        Me.MnuPrintTraspaso.Name = "MnuPrintTraspaso"
        Me.MnuPrintTraspaso.Text = "Imprimir Traspaso"
        '
        'MnuSalir
        '
        Me.MnuSalir.Key = "MnuSalir"
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.Text = "&Salir"
        '
        'MnuCargarTraspaso
        '
        Me.MnuCargarTraspaso.Key = "MnuCargarTraspaso"
        Me.MnuCargarTraspaso.Name = "MnuCargarTraspaso"
        Me.MnuCargarTraspaso.Text = "Abrir Traspaso Entrada"
        '
        'MnuFoliosCajas
        '
        Me.MnuFoliosCajas.Key = "MnuFoliosCajas"
        Me.MnuFoliosCajas.Name = "MnuFoliosCajas"
        Me.MnuFoliosCajas.Text = "Cargar Cajas"
        '
        'MnuNuevoFolio
        '
        Me.MnuNuevoFolio.Key = "MnuNuevoFolio"
        Me.MnuNuevoFolio.Name = "MnuNuevoFolio"
        Me.MnuNuevoFolio.Text = "Nuevo"
        '
        'MnuNuevaCaja
        '
        Me.MnuNuevaCaja.Key = "MnuNuevaCaja"
        Me.MnuNuevaCaja.Name = "MnuNuevaCaja"
        Me.MnuNuevaCaja.Text = "Nueva Caja"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.MenuAndToolbar
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.MenuAndToolbar
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.MenuAndToolbar
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(610, 28)
        '
        'frmTraspasoEntradaVirtual
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(610, 472)
        Me.Controls.Add(Me.explorador)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmTraspasoEntradaVirtual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traspaso Entrada Virtual"
        CType(Me.explorador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorador.ResumeLayout(False)
        Me.explorador.PerformLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MenuAndToolbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private oAlmacenMgr As CatalogoAlmacenesManager
    Private oArticuloMgr As CatalogoArticuloManager
    Private oTraspasoSMgr As TraspasosSalidaManager
    Private oTraspasoEMgr As TraspasosEntradaManager
    Private oAlmacen As Almacen
    Private oArticulo As Articulo
    Private oTraspasoS As TraspasoSalida
    Private oTraspasoE As TraspasoEntrada
    Private dtDetalle As DataTable
    Private traspasoID As Integer = 0
    Private traspasoEntradaID As Integer = 0
    Private str As String = ""
#End Region

#Region "Metodos de Traspasos de Entrada"

    Private Sub Inicializar()

        oAlmacenMgr = New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        oArticuloMgr = New CatalogoArticuloManager(oAppContext)
        oTraspasoSMgr = New TraspasosSalidaManager(oAppContext, oConfigCierreFI)
        oTraspasoEMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        traspasoID = 0
        CreaEstructuraDetalle()

    End Sub

    Public Sub CreaEstructuraDetalle()

        dtDetalle = New DataTable("Detalle")

        With dtDetalle
            .Columns.Add("CajaID", GetType(Integer))
            .Columns.Add("Codigo", GetType(String))
            .Columns.Add("Descripcion", GetType(String))
            .Columns.Add("Talla", GetType(String))
            .Columns.Add("Cantidad", GetType(Int32))
            .Columns.Add("Costo", GetType(Decimal))
            .Columns.Add("Lecturado", GetType(Integer))
            .AcceptChanges()
        End With

    End Sub

    Private Sub ActualizaGrid()
        Me.grdDetalle.DataSource = Nothing
        Me.grdDetalle.DataSource = dtDetalle
        Me.grdDetalle.Refresh()
    End Sub

    Private Function ValidarUPC(ByVal codigo As String) As DataRow
        Dim row As DataRow = Nothing
        If IsNumeric(codigo) Then
            Dim dsUPC As New DataTable
            Dim oCatalogoUPCMgr As CatalogoUPCManager
            Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
            oCatalogoUPCMgr = New CatalogoUPCManager(oAppContext, oConfigCierreFI)

            'dsUPC = oCatalogoUPCMgr.Load2(codigo)
            dsUPC = oFacturaMgr.GetUPCData(codigo)
            If dsUPC.Rows.Count > 0 Then
                row = dsUPC.Rows(0)
            End If
        Else
            MessageBox.Show("No es un código UPC Valido", "DPortenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return row
    End Function

    Private Sub LoadSearchTraspasosFisicos(Optional ByVal strFolio As String = "", Optional ByVal bShow As Boolean = True)
        Dim caja As Integer = 0
        If bShow Then
            Dim oOpenRecordDlg As New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New OpenTraspasoSalidaVirtual
            If (oOpenRecordDlg.CurrentView Is Nothing) Then
                Exit Sub
            End If
            oOpenRecordDlg.ShowDialog()
            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
                strFolio = CStr(oOpenRecordDlg.Record.Item("FolioTraspaso")).PadLeft(10, "0")
                caja = CInt(oOpenRecordDlg.Record.Item("CajaID"))
            Else
                Exit Sub
            End If
        End If
        CargarTraspaso(CInt(strFolio))
        If oTraspasoS.TraspasoID > 0 Then
            With oTraspasoS
                traspasoID = .TraspasoID
                ebFolio.Text = .Folio.Trim.PadLeft(10, "0")
                ebSucOrigenCod.Text = .AlmacenOrigenID 'CStr(oOpenRecordDlg.Record.Item("Origen"))
                oAlmacen = oAlmacenMgr.Load(ebSucOrigenCod.Text.Trim.PadLeft(3, "0"))
                ebSucOrigenDesc.Text = oAlmacen.Descripcion.Trim()
                ebFecha.Text = .TraspasoCreadoEl 'CDate(oOpenRecordDlg.Record.Item("Fecha")).ToString()
                ebDestino.Text = .AlmacenDestinoID '(oOpenRecordDlg.Record.Item("Destino"))
                txtObservaciones.Text = .Observaciones 'CStr(oOpenRecordDlg.Record.Item("Observaciones"))
            End With
            Me.ebNumBulto.ReadOnly = False
            'UiCommandBar1.CommandManager.CommandBars.Item("CommandBar1").Commands("MnuNuevaCaja").Enabled = Janus.Windows.UI.InheritableBoolean.True
        End If
        If bShow Then
            ebNumBulto.Text = CStr(caja).PadLeft(4, "0")
            Me.CargarCaja(caja)
        End If
    End Sub

    Private Sub LoadSearchTraspasoEntrada(Optional ByVal strFolio As String = "", Optional ByVal bShow As Boolean = True)
        Dim caja As Integer = 0
        If bShow Then
            Dim oOpenRecordDlg As New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New OpenTraspasoEntradaVirtual
            If (oOpenRecordDlg.CurrentView Is Nothing) Then
                Exit Sub
            End If
            oOpenRecordDlg.ShowDialog()
            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
                strFolio = CStr(oOpenRecordDlg.Record.Item("FolioTraspaso")).PadLeft(10, "0")
                'caja = CInt(oOpenRecordDlg.Record.Item("CajaID"))
            Else
                Exit Sub
            End If
        End If
        CargarTraspasoEntrada(strFolio)
        ebNumBulto.Text = CStr(caja).PadLeft(4, "0")
        If oTraspasoE.TraspasoID <> 0 Then
            With oTraspasoE
                traspasoEntradaID = .TraspasoID
                txtFolioEntrada.Text = .Folio.PadLeft(10, "0")
                ebFolio.Text = .FolioSAP.PadLeft(10, "0")
                ebSucOrigenCod.Text = .AlmacenDestinoID
                oAlmacen = oAlmacenMgr.Load(ebSucOrigenCod.Text.Trim.PadLeft(3, "0"))
                ebSucOrigenDesc.Text = oAlmacen.Descripcion.Trim()
                ebFecha.Text = .TraspasoRecibidoEl
                ebDestino.Text = .AlmacenOrigenID
                txtObservaciones.Text = .Observaciones
            End With
            Me.ebNumBulto.ReadOnly = False
            MenuAndToolbar.CommandBars.Item("tbTraspasos").Commands("MnuNuevaCaja").Enabled = Janus.Windows.UI.InheritableBoolean.True
        End If
        'If bShow Then
        '    Me.CargarCajaEntrada(caja)
        'End If
    End Sub

    Private Sub CargarTraspaso(ByVal traspasoId As Integer)
        oTraspasoS = oTraspasoSMgr.SelectTFByFolio(traspasoId)
    End Sub

    Private Sub CargarTraspasoEntrada(ByVal Folio As Integer)
        oTraspasoE = oTraspasoEMgr.GetTraspasoEntradaSel(Folio.ToString())
    End Sub

    Private Sub CargarCaja(ByVal cajaId As Integer)
        If traspasoID <> 0 Then
            Me.dtDetalle.Rows.Clear()
            Dim rows() As DataRow = oTraspasoS.Detalle.Tables(1).Select("CajaID=" & CStr(cajaId))
            If rows.Length > 0 Then
                Dim fila As DataRow = Nothing
                For Each row As DataRow In rows
                    fila = Me.dtDetalle.NewRow()
                    fila("CajaID") = row("CajaID")
                    fila("Codigo") = row("Material")
                    fila("Descripcion") = row("Descripcion")
                    fila("Talla") = row("Talla")
                    fila("Cantidad") = row("Cantidad")
                    fila("Costo") = row("Costo")
                    fila("Lecturado") = row("Cantidad")
                    Me.dtDetalle.Rows.Add(fila)
                Next
                Me.dtDetalle.AcceptChanges()
                Me.ActualizaGrid()
                Me.grdDetalle.Focus()
            Else
                MessageBox.Show("Caja no existente en el Traspaso", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub CargarCajaEntrada(ByVal CajaID As Integer)
        If traspasoEntradaID <> 0 Then
            Me.dtDetalle.Rows.Clear()
            Dim traspasoS As TraspasoSalida = oTraspasoSMgr.SelectTFByFolio(CInt(Me.ebFolio.Text.Trim()))
            Dim rows() As DataRow = oTraspasoE.Detalle.Tables(1).Select("CajaID=" & CStr(CajaID))
            If rows.Length > 0 Then
                Dim fila As DataRow = Nothing, material As String = "", MovID As Integer = CInt(oTraspasoE.Detalle.Tables(0).Rows(0)("MovID"))
                Dim talla As String = "", filas() As DataRow = Nothing
                For Each row As DataRow In rows
                    material = CStr(row("Material"))
                    talla = CStr(row("Talla"))
                    fila = Me.dtDetalle.NewRow()
                    fila("CajaID") = row("CajaID")
                    fila("Codigo") = material
                    fila("Descripcion") = row("Descripcion")
                    fila("Talla") = talla
                    fila("Costo") = row("Costo")
                    fila("Lecturado") = row("Cantidad")
                    filas = traspasoS.Detalle.Tables(1).Select("MovID=" & CStr(MovID) & " AND Material='" & material & "' AND Talla='" & talla & "'")
                    If filas.Length > 0 Then
                        fila("Cantidad") = CInt(filas(0)("Cantidad"))
                    End If
                    Me.dtDetalle.Rows.Add(fila)
                Next
                Me.dtDetalle.AcceptChanges()
                Me.ActualizaGrid()
                Me.grdDetalle.Focus()
                Me.btnEntrada.Enabled = False
            Else
                MessageBox.Show("Caja no existente en el traspaso", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub CerrarCajaTraspasoEntrada()
        If Validar() Then
            If ValidarCantidadTraspaso() = True Then
                If traspasoEntradaID = 0 Then
                    oTraspasoE = New TraspasoEntrada(oTraspasoEMgr)
                    oTraspasoE.TraspasoID = traspasoEntradaID
                    oTraspasoE.AlmacenOrigenID = ebDestino.Text.Trim()
                    oTraspasoE.AlmacenDestinoID = ebSucOrigenCod.Text.Trim()
                    oTraspasoE.Folio = txtFolioEntrada.Text.Trim()
                    oTraspasoE.AutorizadoPorID = oAppContext.Security.CurrentUser.Name
                    oTraspasoE.NumConsecutivo = traspasoID
                    oTraspasoEMgr.InsertarTraspasoEntradaVirtual(oTraspasoE, Me.dtDetalle)
                    traspasoEntradaID = oTraspasoE.TraspasoID
                Else
                    oTraspasoE = New TraspasoEntrada(oTraspasoEMgr)
                    oTraspasoE.TraspasoID = traspasoEntradaID
                    oTraspasoE.AlmacenOrigenID = ebDestino.Text.Trim()
                    oTraspasoE.AlmacenDestinoID = ebSucOrigenCod.Text.Trim()
                    oTraspasoE.Folio = txtFolioEntrada.Text.Trim()
                    oTraspasoE.NumConsecutivo = traspasoID
                    oTraspasoEMgr.InsertarTraspasoEntradaVirtual(oTraspasoE, Me.dtDetalle)
                    traspasoEntradaID = oTraspasoE.TraspasoID
                End If
                NuevaCaja()
                MenuAndToolbar.CommandBars.Item("tbTraspasos").Commands("MnuNuevaCaja").Enabled = Janus.Windows.UI.InheritableBoolean.True
                MessageBox.Show("Se ha recibido la caja exitosamente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If       
        End If
    End Sub

    Private Function Validar() As Boolean
        If ebDestino.Text.Trim() = "" Then
            MessageBox.Show("No hay Almacen Origen", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If ebSucOrigenCod.Text.Trim() = "" Then
            MessageBox.Show("No hay Almacen Destino", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Function ValidarCantidadTraspaso() As Boolean
        Dim valido As Boolean = True
        Dim texto As String = "", cantidad As Integer = 0, lecturado As Integer = 0, material As String = "", talla As String = ""
        Dim diferencia As Integer = 0
        For Each row As DataRow In Me.dtDetalle.Rows
            material = CStr(row("Codigo"))
            talla = CStr(row("Talla"))
            cantidad = CInt(row("Cantidad"))
            lecturado = CInt(row("Lecturado"))
            If cantidad <> lecturado Then
                valido = False
                diferencia = cantidad - lecturado
                diferencia = diferencia * -1
                If diferencia < 0 Then
                    texto &= "El Código " & material & " con talla " & talla & " le faltan " & CStr(Math.Abs(diferencia)) & vbCrLf
                ElseIf diferencia > 0 Then
                    texto &= "El Código " & material & " con talla " & talla & " le sobran " & CStr(Math.Abs(diferencia)) & vbCrLf
                End If

            End If
        Next
        If valido = False Then
            texto &= "¿Deseas Realizar el traspaso?"
            If MessageBox.Show(texto, "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                valido = True
            End If
        End If
        Return valido
    End Function

    Private Sub Nuevo()
        traspasoEntradaID = 0
        traspasoID = 0
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0"))
        Me.ebFecha.Text = Today.ToString
        oTraspasoE = Nothing
        If Not oAlmacen Is Nothing Then
            Me.ebSucOrigenCod.Text = oAlmacen.ID
            Me.ebSucOrigenDesc.Text = oAlmacen.Descripcion.Trim
        End If
        Me.txtFolioEntrada.Text = CStr(oTraspasoEMgr.NextFolioTraspasoEntradaVirtual(ebSucOrigenCod.Text.Trim())).PadLeft(10, "0")
        Me.ebDestino.Text = ""
        Me.txtObservaciones.Text = ""
        btnEntrada.Enabled = True
        If Not dtDetalle Is Nothing Then dtDetalle.Clear()
        Me.ActualizaGrid()
        ebFecha.Text = DateTime.Now.ToString()
        ebFolio.Text = ""
        Me.btnEntrada.Enabled = True
        Me.ebNumBulto.Text = ""
        Me.txtCodigoBarra.Text = ""
        Me.ebNumBulto.ReadOnly = True
        MenuAndToolbar.CommandBars.Item("tbTraspasos").Commands("MnuNuevaCaja").Enabled = Janus.Windows.UI.InheritableBoolean.False
    End Sub

    Private Sub NuevaCaja()
        ebNumBulto.Text = ""
        txtCodigoBarra.Text = ""
        btnEntrada.Enabled = True
        If Not dtDetalle Is Nothing Then dtDetalle.Clear()
        ebDestino.Text = ""
        txtObservaciones.Text = ""
        btnEntrada.Enabled = True
    End Sub

    Private Function ExisteCajaTraspaso(ByVal folio As String, ByVal cajaId As Integer)
        Dim count As Integer = 0
        count = oTraspasoEMgr.ExisteCajaTraspasoEntrada(folio, cajaId)
        Return count
    End Function

    Private Sub PrintTraspasos()
        If traspasoEntradaID <> 0 Then
            Dim dtImpresion As DataTable = CrearEstructuraImpresion()
            Dim fila As DataRow = Nothing, diferencia As Integer = 0
            Dim cantidad As Integer = 0, lecturado As Integer = 0
            Dim traspasoE As TraspasoEntrada = oTraspasoEMgr.GetTraspasoEntradaSel(txtFolioEntrada.Text.Trim())
            Dim traspasoS As TraspasoSalida = oTraspasoSMgr.SelectTFByFolio(CInt(ebFolio.Text.Trim()))
            Dim rows() As DataRow = Nothing, material As String = "", talla As String = "", MovID As Integer = CInt(traspasoE.Detalle.Tables(0).Rows(0)("MovID"))
            For Each row As DataRow In traspasoE.Detalle.Tables(1).Rows
                fila = dtImpresion.NewRow()
                material = CStr(row("Material"))
                talla = CStr(row("Talla"))
                fila("Material") = material
                fila("Descripcion") = row("Descripcion")
                fila("Talla") = talla
                fila("Cantidad") = row("Cantidad")
                fila("Costo") = row("Costo")
                fila("CajaID") = row("CajaID")
                rows = traspasoS.Detalle.Tables(1).Select("MovID=" & CStr(MovID) & " AND Material='" & material & "' AND Talla='" & talla & "'")
                lecturado = CInt(row("Cantidad"))
                If rows.Length > 0 Then
                    cantidad = CInt(rows(0)("Cantidad"))
                End If
                diferencia = cantidad - lecturado
                fila("Diferencia") = diferencia * -1
                dtImpresion.Rows.Add(fila)
            Next
            dtImpresion.AcceptChanges()
            Dim dtReporte As New rptTraspasoEntradaVirtual(txtFolioEntrada.Text.Trim(), ebDestino.Text.Trim(), ebSucOrigenCod.Text.Trim())
            dtReporte.Document.Name = "Reporte Traspaso Entrada Virtual"
            dtReporte.DataSource = dtImpresion
            dtReporte.Run()
            Dim oReportViewer As New ReportViewerForm
            oReportViewer.Report = dtReporte
            oReportViewer.Show()

            'Imprimir(Directo)
            'dtReporte.Document.Print(False, False)
        Else
            MessageBox.Show("No hay traspaso Cargado", "Dportenis PRO", MessageBoxButtons.OK)
        End If
    End Sub

    Private Function CrearEstructuraImpresion() As DataTable
        Dim dtImpresion As New DataTable("Impresion")
        dtImpresion.Columns.Add("Material", GetType(String))
        dtImpresion.Columns.Add("Cantidad", GetType(Integer))
        dtImpresion.Columns.Add("Talla", GetType(String))
        dtImpresion.Columns.Add("Descripcion", GetType(String))
        dtImpresion.Columns.Add("Costo", GetType(Decimal))
        dtImpresion.Columns.Add("Diferencia", GetType(Integer))
        dtImpresion.Columns.Add("CajaID", GetType(Integer))
        dtImpresion.AcceptChanges()
        Return dtImpresion
    End Function

#End Region

#Region "Metodos Form"
    Private Sub txtCodigoBarra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoBarra.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsNumeric(txtCodigoBarra.Text.Trim()) AndAlso txtCodigoBarra.Text.Trim().Length > 10 Then
                    Dim strFolio As String = "", strCaja As String = ""
                    strFolio = txtCodigoBarra.Text.Trim().Substring(0, 10)
                    strCaja = txtCodigoBarra.Text.Trim().Substring(10)
                    If ExisteCajaTraspaso(CInt(strFolio), CInt(strCaja)) = 0 Then
                        Me.LoadSearchTraspasosFisicos(strFolio, False)
                        Me.CargarCaja(strCaja)
                        Me.ebNumBulto.Text = strCaja
                        MenuAndToolbar.CommandBars.Item("tbTraspasos").Commands("MnuNuevaCaja").Enabled = Janus.Windows.UI.InheritableBoolean.True
                    Else
                        MessageBox.Show("Ya se le dio entrada a la Caja", "DPortenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
        End Select
    End Sub

    Private Sub MenuAndToolbar_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles MenuAndToolbar.CommandClick
        Select Case e.Command.Key
            Case "MnuNuevoFolio"
                Nuevo()
            Case "MnuNuevaCaja"
                NuevaCaja()
            Case "MnuCargarTraspaso"
                LoadSearchTraspasoEntrada(, True)
            Case "MnuFoliosCajas"
                LoadSearchTraspasosFisicos(, True)
            Case "MnuPrintTraspaso"
                If traspasoEntradaID <> 0 AndAlso Not oTraspasoE Is Nothing Then
                    PrintTraspasos()
                Else
                    LoadSearchTraspasoEntrada(, True)
                    PrintTraspasos()
                End If
        End Select
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ebNumBulto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumBulto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.CargarCajaEntrada(CInt(ebNumBulto.Text.Trim()))
        End If
    End Sub

    Private Sub btnEntrada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntrada.Click
        CerrarCajaTraspasoEntrada()
    End Sub

    Private Sub frmTraspasoEntradaVirtual_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Nuevo()
    End Sub
#End Region

    
    Private Sub grdDetalle_UpdatingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grdDetalle.UpdatingCell
        If IsNumeric(e.Value) = True Then
            If CInt(e.Value) <= 0 Then
                MessageBox.Show("No se puede lecturar cantidades menores o iguales a cero", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Cancel = True
            End If
        Else
            MessageBox.Show("Solo aceptan números", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If
    End Sub
End Class
