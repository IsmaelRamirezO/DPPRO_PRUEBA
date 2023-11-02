Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmTraspasoInvFisico
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
    Friend WithEvents grdDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnCerrarCaja As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebSucOrigenDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucOrigenCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ebDestino As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents uICommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimirTraspaso As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimirEtiqueta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimirTraspaso1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimirEtiqueta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents MnuNuevaCaja As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuNuevaCaja1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebNumBulto As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraspasoInvFisico))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebNumBulto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtObservaciones = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.ebDestino = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ebSucOrigenDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucOrigenCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdDetalle = New Janus.Windows.GridEX.GridEX()
        Me.btnCerrarCaja = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.uICommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimirTraspaso1 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimirTraspaso")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuNuevaCaja1 = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevaCaja")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimirEtiqueta1 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimirEtiqueta")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuImprimirTraspaso = New Janus.Windows.UI.CommandBars.UICommand("menuImprimirTraspaso")
        Me.menuImprimirEtiqueta = New Janus.Windows.UI.CommandBars.UICommand("menuImprimirEtiqueta")
        Me.MnuNuevaCaja = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevaCaja")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.explorerBar1.Controls.Add(Me.ebNumBulto)
        Me.explorerBar1.Controls.Add(Me.txtObservaciones)
        Me.explorerBar1.Controls.Add(Me.lblObservaciones)
        Me.explorerBar1.Controls.Add(Me.ebDestino)
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Controls.Add(Me.ebFecha)
        Me.explorerBar1.Controls.Add(Me.Label5)
        Me.explorerBar1.Controls.Add(Me.Label8)
        Me.explorerBar1.Controls.Add(Me.ebFolio)
        Me.explorerBar1.Controls.Add(Me.Label4)
        Me.explorerBar1.Controls.Add(Me.ebSucOrigenDesc)
        Me.explorerBar1.Controls.Add(Me.ebSucOrigenCod)
        Me.explorerBar1.Controls.Add(Me.Label2)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 28)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(570, 380)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebNumBulto
        '
        Me.ebNumBulto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumBulto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumBulto.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumBulto.Location = New System.Drawing.Point(432, 8)
        Me.ebNumBulto.Name = "ebNumBulto"
        Me.ebNumBulto.ReadOnly = True
        Me.ebNumBulto.Size = New System.Drawing.Size(112, 20)
        Me.ebNumBulto.TabIndex = 21
        Me.ebNumBulto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumBulto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtObservaciones
        '
        Me.txtObservaciones.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtObservaciones.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtObservaciones.Location = New System.Drawing.Point(104, 104)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(440, 56)
        Me.txtObservaciones.TabIndex = 20
        Me.txtObservaciones.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtObservaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.BackColor = System.Drawing.Color.Transparent
        Me.lblObservaciones.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservaciones.Location = New System.Drawing.Point(8, 104)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(94, 14)
        Me.lblObservaciones.TabIndex = 19
        Me.lblObservaciones.Text = "Observaciones"
        '
        'ebDestino
        '
        Me.ebDestino.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDestino.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDestino.Location = New System.Drawing.Point(64, 72)
        Me.ebDestino.Name = "ebDestino"
        Me.ebDestino.Size = New System.Drawing.Size(480, 20)
        Me.ebDestino.TabIndex = 18
        Me.ebDestino.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDestino.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 14)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Destino"
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.SystemColors.Info
        Me.ebFecha.Location = New System.Drawing.Point(432, 40)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(112, 20)
        Me.ebFecha.TabIndex = 15
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(344, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 14)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Fecha"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(344, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "No. de Caja"
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.BackColor = System.Drawing.SystemColors.Info
        Me.ebFolio.Location = New System.Drawing.Point(64, 8)
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.ReadOnly = True
        Me.ebFolio.Size = New System.Drawing.Size(112, 20)
        Me.ebFolio.TabIndex = 11
        Me.ebFolio.TabStop = False
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 14)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Folio"
        '
        'ebSucOrigenDesc
        '
        Me.ebSucOrigenDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenDesc.BackColor = System.Drawing.SystemColors.Info
        Me.ebSucOrigenDesc.Location = New System.Drawing.Point(136, 40)
        Me.ebSucOrigenDesc.Name = "ebSucOrigenDesc"
        Me.ebSucOrigenDesc.ReadOnly = True
        Me.ebSucOrigenDesc.Size = New System.Drawing.Size(200, 20)
        Me.ebSucOrigenDesc.TabIndex = 6
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
        Me.ebSucOrigenCod.Location = New System.Drawing.Point(64, 40)
        Me.ebSucOrigenCod.Name = "ebSucOrigenCod"
        Me.ebSucOrigenCod.ReadOnly = True
        Me.ebSucOrigenCod.Size = New System.Drawing.Size(64, 22)
        Me.ebSucOrigenCod.TabIndex = 5
        Me.ebSucOrigenCod.TabStop = False
        Me.ebSucOrigenCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucOrigenCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Origen"
        '
        'grdDetalle
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdDetalle.DesignTimeLayout = GridEXLayout1
        Me.grdDetalle.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None
        Me.grdDetalle.GroupByBoxVisible = False
        Me.grdDetalle.Location = New System.Drawing.Point(8, 200)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.Size = New System.Drawing.Size(552, 160)
        Me.grdDetalle.TabIndex = 1
        Me.grdDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnCerrarCaja
        '
        Me.btnCerrarCaja.Location = New System.Drawing.Point(8, 368)
        Me.btnCerrarCaja.Name = "btnCerrarCaja"
        Me.btnCerrarCaja.Size = New System.Drawing.Size(112, 23)
        Me.btnCerrarCaja.TabIndex = 2
        Me.btnCerrarCaja.Text = "Cerrar Caja"
        Me.btnCerrarCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(448, 368)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(112, 23)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uICommandManager1
        '
        Me.uICommandManager1.BottomRebar = Me.BottomRebar1
        Me.uICommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.uICommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo, Me.menuSalir, Me.menuAbrir, Me.menuImprimirTraspaso, Me.menuImprimirEtiqueta, Me.MnuNuevaCaja})
        Me.uICommandManager1.ContainerControl = Me
        '
        '
        '
        Me.uICommandManager1.EditContextMenu.Key = ""
        Me.uICommandManager1.Id = New System.Guid("4f8e1785-66c5-469d-aa45-542600467f88")
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo1, Me.Separator1, Me.menuAbrir1, Me.Separator2, Me.menuImprimirTraspaso1, Me.Separator3, Me.MnuNuevaCaja1, Me.Separator5, Me.menuImprimirEtiqueta1, Me.Separator4, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(570, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuNuevo1
        '
        Me.menuNuevo1.Icon = CType(resources.GetObject("menuNuevo1.Icon"), System.Drawing.Icon)
        Me.menuNuevo1.Key = "menuNuevo"
        Me.menuNuevo1.Name = "menuNuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuAbrir1
        '
        Me.menuAbrir1.Icon = CType(resources.GetObject("menuAbrir1.Icon"), System.Drawing.Icon)
        Me.menuAbrir1.Key = "menuAbrir"
        Me.menuAbrir1.Name = "menuAbrir1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuImprimirTraspaso1
        '
        Me.menuImprimirTraspaso1.Icon = CType(resources.GetObject("menuImprimirTraspaso1.Icon"), System.Drawing.Icon)
        Me.menuImprimirTraspaso1.Key = "menuImprimirTraspaso"
        Me.menuImprimirTraspaso1.Name = "menuImprimirTraspaso1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'MnuNuevaCaja1
        '
        Me.MnuNuevaCaja1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MnuNuevaCaja1.Icon = CType(resources.GetObject("MnuNuevaCaja1.Icon"), System.Drawing.Icon)
        Me.MnuNuevaCaja1.Key = "MnuNuevaCaja"
        Me.MnuNuevaCaja1.Name = "MnuNuevaCaja1"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuImprimirEtiqueta1
        '
        Me.menuImprimirEtiqueta1.Image = CType(resources.GetObject("menuImprimirEtiqueta1.Image"), System.Drawing.Image)
        Me.menuImprimirEtiqueta1.Key = "menuImprimirEtiqueta"
        Me.menuImprimirEtiqueta1.Name = "menuImprimirEtiqueta1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuSalir1
        '
        Me.menuSalir1.Icon = CType(resources.GetObject("menuSalir1.Icon"), System.Drawing.Icon)
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'menuNuevo
        '
        Me.menuNuevo.Key = "menuNuevo"
        Me.menuNuevo.Name = "menuNuevo"
        Me.menuNuevo.Text = "Nuevo Traspaso"
        '
        'menuSalir
        '
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
        '
        'menuAbrir
        '
        Me.menuAbrir.Key = "menuAbrir"
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Text = "Abrir Traspaso"
        '
        'menuImprimirTraspaso
        '
        Me.menuImprimirTraspaso.Key = "menuImprimirTraspaso"
        Me.menuImprimirTraspaso.Name = "menuImprimirTraspaso"
        Me.menuImprimirTraspaso.Text = "Imprimir Traspaso"
        '
        'menuImprimirEtiqueta
        '
        Me.menuImprimirEtiqueta.Key = "menuImprimirEtiqueta"
        Me.menuImprimirEtiqueta.Name = "menuImprimirEtiqueta"
        Me.menuImprimirEtiqueta.Text = "Imprimir Etiqueta"
        '
        'MnuNuevaCaja
        '
        Me.MnuNuevaCaja.Key = "MnuNuevaCaja"
        Me.MnuNuevaCaja.Name = "MnuNuevaCaja"
        Me.MnuNuevaCaja.Text = "Nueva Caja"
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
        Me.TopRebar1.Size = New System.Drawing.Size(570, 28)
        '
        'frmTraspasoInvFisico
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(570, 408)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnCerrarCaja)
        Me.Controls.Add(Me.grdDetalle)
        Me.Controls.Add(Me.explorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmTraspasoInvFisico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traspaso Virtual de Inventario"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.explorerBar1.PerformLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
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

    Dim oAlmacenMgr As CatalogoAlmacenesManager
    Dim oArticuloMgr As CatalogoArticuloManager
    Dim oTraspasoSMgr As TraspasosSalidaManager
    Dim oAlmacen As Almacen
    Dim oArticulo As Articulo
    Dim oTraspasoS As TraspasoSalida
    Dim str As String = ""
    Dim dtDetalle As DataTable
    Private traspasoID As Integer = 0

    Private Sub Inicializar()

        oAlmacenMgr = New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        oArticuloMgr = New CatalogoArticuloManager(oAppContext)
        oTraspasoSMgr = New TraspasosSalidaManager(oAppContext, oConfigCierreFI)
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
            .AcceptChanges()
        End With

    End Sub

    Private Sub ActualizaGrid()
        Me.grdDetalle.DataSource = Nothing
        Me.grdDetalle.DataSource = dtDetalle
        Me.grdDetalle.Refresh()
    End Sub

    Private Sub InsertarFila()
        Dim oRow As DataRow = dtDetalle.NewRow
        With oRow
            !CajaID = CInt(ebNumBulto.Text.Trim())
            !Codigo = ""
            !Talla = ""
            !Descripcion = ""
            !Cantidad = 0
            !Costo = 0
        End With

        dtDetalle.Rows.Add(oRow)
        ActualizaGrid()
        Me.grdDetalle.Col = 0
        Me.grdDetalle.Row = dtDetalle.Rows.Count - 1
    End Sub

    Private Sub BorrarFila(ByVal oRow As DataRowView)
        If Me.grdDetalle.RowCount > 0 Then
            Me.dtDetalle.Rows.Remove(oRow.Row)
            ActualizaGrid()
        End If
    End Sub

    Private Sub BuscarArticulo(ByVal strCodigo As String, ByVal Row As Integer)

        oArticulo = oArticuloMgr.Load(strCodigo.Trim)
        If Not oArticulo Is Nothing Then
            With Me.grdDetalle.GetRow(Row).DataRow
                !CajaID = CInt(ebNumBulto.Text.Trim())
                !Codigo = oArticulo.CodArticulo.Trim
                !Descripcion = oArticulo.Descripcion.Trim
                !Costo = oArticulo.CostoProm
            End With
        End If
        grdDetalle.Refresh()
        SendKeys.Send("{TAB}")
        grdDetalle.Col = 2
    End Sub

    Private Sub InsertarCodigo(ByVal codigo As String, ByVal numero As String)
        oArticulo = oArticuloMgr.Load(codigo)
        If Not oArticulo Is Nothing Then
            If ValidarExistencia(codigo, numero, 1) = True Then
                Dim row As DataRow = dtDetalle.NewRow()
                row("CajaID") = CInt(Me.ebNumBulto.Text.Trim())
                row("Codigo") = oArticulo.CodArticulo.Trim()
                row("Talla") = numero
                row("Descripcion") = oArticulo.Descripcion.Trim()
                row("Cantidad") = 1
                row("Costo") = oArticulo.CostoProm
                dtDetalle.Rows.Add(row)
                dtDetalle.AcceptChanges()
            Else
                MessageBox.Show("No hay en existencia el Articulo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
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

    Private Function FillTallasArticulo(ByVal vCodCorrida As String, ByVal talla As String) As Boolean
        Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim dsTallas As DataSet = Nothing, index As Integer = 1
        Dim valido As Boolean = False
        dsTallas = oFacturaMgr.GetTallasArticulo(vCodCorrida)
        If dsTallas Is Nothing Then
            MsgBox("Corrida del Artículo NO EXISTE.  ", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "  Facturación")
        Else
            For index = 1 To 20 Step 1
                If dsTallas.Tables(0).Rows(0).Item("C" & Format(index, "00")) = talla Then
                    valido = True
                End If
            Next
        End If
        Return valido
    End Function

    Private Function ValidarExistencia(ByVal CodArticulo As String, ByVal talla As String, ByVal cantidad As Integer) As Boolean
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim oFactura As Factura = FacturaMgr.Create()
        Dim valido As Boolean = False
        'If IsNumeric(talla) Then
        '    talla = Format(CDec(talla), "#.0")
        'Else
        '    talla = talla.Trim()
        'End If
        oFactura.FacturaArticuloExistencia = 0
        FacturaMgr.GetExistenciaArticulo(CodArticulo, oAppContext.ApplicationConfiguration.Almacen, talla, oFactura)
        If CDec(cantidad) <= oFactura.FacturaArticuloExistencia Then
            valido = True
        End If
        Return valido
    End Function

    Private Sub Nuevo()
        traspasoID = 0
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0"))
        Me.ebFecha.Text = Today.ToString
        oTraspasoS = Nothing
        If Not oAlmacen Is Nothing Then
            Me.ebSucOrigenCod.Text = oAlmacen.ID
            Me.ebSucOrigenDesc.Text = oAlmacen.Descripcion.Trim
        End If
        Me.ebFolio.Text = CStr(oTraspasoSMgr.SelectTFNextFolio()).PadLeft(10, "0")
        Me.ebNumBulto.Text = CStr(oTraspasoSMgr.SelectTFNextCaja(traspasoID)).PadLeft(4, "0")
        Me.ebNumBulto.ReadOnly = True
        Me.ebDestino.Text = ""
        Me.txtObservaciones.Text = ""
        btnCerrarCaja.Enabled = True
        If Not dtDetalle Is Nothing Then dtDetalle.Clear()
        Me.ActualizaGrid()
        UiCommandBar1.CommandManager.CommandBars.Item("CommandBar1").Commands("MnuNuevaCaja").Enabled = Janus.Windows.UI.InheritableBoolean.False
    End Sub

    Private Function ValidaCampos() As Boolean

        Dim bRes As Boolean = False

        If Me.ebDestino.Text.Trim = "" Then
            MessageBox.Show("Es necesario especificar el destino.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebDestino.Focus()
        ElseIf Me.dtDetalle Is Nothing OrElse Me.dtDetalle.Rows.Count <= 0 Then
            MessageBox.Show("Es necesario lecturar al menos un material para enviar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.grdDetalle.Focus()
        Else
            bRes = True
        End If

        Return bRes

    End Function

    Private Sub LoadSearchTraspasosFisicos(Optional ByVal strFolio As String = "", Optional ByVal bShow As Boolean = True)

        If bShow Then
            Dim oOpenRecordDlg As New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New TraspasoFisicoSalida
            If (oOpenRecordDlg.CurrentView Is Nothing) Then
                Exit Sub
            End If
            oOpenRecordDlg.ShowDialog()
            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
                'traspasoID = CInt(oOpenRecordDlg.Record.Item("MovID"))
                'oTraspasoS = New TraspasoSalida(oTraspasoSMgr)
                'oTraspasoS.TraspasoID = traspasoID
                'oTraspasoS.Folio = CStr(oOpenRecordDlg.Record.Item("FolioTraspaso"))
                'oTraspasoS.AlmacenOrigenID = CStr(oOpenRecordDlg.Record.Item("Origen"))
                'oTraspasoS.AlmacenDestinoID = CStr(oOpenRecordDlg.Record.Item("Destino"))
                'oTraspasoS.Observaciones = CStr(oOpenRecordDlg.Record.Item("Observaciones"))
                strFolio = CStr(oOpenRecordDlg.Record.Item("FolioTraspaso")).PadLeft(10, "0")
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
            NuevaCaja()
            Me.ebNumBulto.ReadOnly = False
            UiCommandBar1.CommandManager.CommandBars.Item("CommandBar1").Commands("MnuNuevaCaja").Enabled = Janus.Windows.UI.InheritableBoolean.True
        End If

    End Sub

    Private Sub CerrarCaja()
        If ValidaCampos() Then
            If traspasoID = 0 Then
                Dim detail As New DataSet
                oTraspasoS = New TraspasoSalida(oTraspasoSMgr)
                oTraspasoS.TraspasoID = 0
                oTraspasoS.Folio = ebFolio.Text.Trim()
                oTraspasoS.AlmacenOrigenID = ebSucOrigenCod.Text.Trim()
                oTraspasoS.AlmacenDestinoID = ebDestino.Text.Trim()
                oTraspasoS.AutorizadoPorID = oAppContext.Security.CurrentUser.Name
                oTraspasoS.Observaciones = txtObservaciones.Text.Trim()
                oTraspasoSMgr.InsertTF(oTraspasoS, dtDetalle)
                traspasoID = oTraspasoS.TraspasoID
            Else
                oTraspasoS.TraspasoID = traspasoID
                oTraspasoS.AlmacenDestinoID = ebDestino.Text.Trim()
                oTraspasoS.Observaciones = txtObservaciones.Text.Trim()
                oTraspasoSMgr.InsertTF(oTraspasoS, dtDetalle)
            End If

            'Se imprime Etiqueta correspondiente a la caja cerrada
            ImprimirEtiqueta(ebFolio.Text.Trim, ebSucOrigenCod.Text.Trim, ebNumBulto.Text.Trim, Date.Now, dtDetalle)

            'Se carga una nueva caja
            NuevaCaja()
            Me.ebNumBulto.ReadOnly = False
            UiCommandBar1.CommandManager.CommandBars.Item("CommandBar1").Commands("MnuNuevaCaja").Enabled = Janus.Windows.UI.InheritableBoolean.True

            MessageBox.Show("Se ha cerrado la caja exitosamente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub NuevaCaja()
        Me.ebNumBulto.Text = CStr(oTraspasoSMgr.SelectTFNextCaja(traspasoID)).PadLeft(4, "0")
        Me.dtDetalle.Rows.Clear()
        btnCerrarCaja.Enabled = True
    End Sub

    Private Sub CargarTraspaso(ByVal traspasoId As Integer)
        oTraspasoS = oTraspasoSMgr.SelectTFByFolio(traspasoId)
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
                    Me.dtDetalle.Rows.Add(fila)
                Next
                Me.dtDetalle.AcceptChanges()
                btnCerrarCaja.Enabled = False
                Me.grdDetalle.Focus()
            Else
                MessageBox.Show("Caja no existente en el Traspaso", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub ImprimirEtiqueta(ByVal FTraslado As String, ByVal SucOri As String, ByVal NCaja As Integer, _
                ByVal FechaTraslado As DateTime, ByVal Detalle As DataTable)

        Dim oEtiquetaTIF As New rptEtiquetaTraspasoInvFisico(FTraslado, SucOri, NCaja, FechaTraslado)
        oEtiquetaTIF.Document.Name = "Etiqueta Traspaso Inventario Fisico"
        oEtiquetaTIF.Document.Printer.PrinterSettings.PrinterName = oConfigCierreFI.ImpresoraETIF
        oEtiquetaTIF.DataSource = Detalle
        oEtiquetaTIF.Run()

        'Dim oReportViewer As New ReportViewerForm
        'oReportViewer.Report = oEtiquetaTIF
        'oReportViewer.Show()

        'Imprimir Directo :
        oEtiquetaTIF.Document.Print(False, False)
    End Sub

    Private Sub ImprimirTraspaso(ByVal FTraslado As String, ByVal Origen As String, ByVal Destino As String, ByVal Detalle As DataTable)

        Dim oReporteTIF As New rptTraspasoInvFisico(FTraslado, Origen, Destino)
        oReporteTIF.Document.Name = "Reporte Traspaso Inventario Fisico"
        oReporteTIF.DataSource = Detalle
        oReporteTIF.Run()

        'Dim oReportViewer As New ReportViewerForm
        'oReportViewer.Report = oReporteTIF
        'oReportViewer.Show()

        'Imprimir(Directo)
        oReporteTIF.Document.Print(False, False)
    End Sub

    Private Function LoadSearchTraspasosFisicosAll() As Boolean
        Dim bReturn As Boolean = True
        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New TraspasoFisicoSalida
        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            bReturn = False
        End If
        oOpenRecordDlg.ShowDialog()
        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
            traspasoID = CInt(oOpenRecordDlg.Record.Item("MovID"))
            oTraspasoS = New TraspasoSalida(oTraspasoSMgr)
            oTraspasoS = oTraspasoSMgr.SelectTFByFolio(CStr(oOpenRecordDlg.Record.Item("FolioTraspaso")))
        Else
            bReturn = False
        End If
        Return bReturn
    End Function

    Private Function ExistInGrid(ByVal CodArticulo As String, ByVal talla As String) As DataRow
        Dim row As DataRow = Nothing
        For Each fila As DataRow In Me.dtDetalle.Rows
            If CStr(fila!Codigo) = CodArticulo AndAlso CStr(fila("Talla")) = talla Then
                row = fila
            End If
        Next
        Return row
    End Function

    Private Sub frmTraspasoInvFisico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim intLargo As Integer = 0

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Else
                If Me.ActiveControl Is Me.grdDetalle And Not e.KeyCode = Keys.Enter Then 'And Me.grdDetalle.RootTable.Columns(0).EditType = Janus.Windows.GridEX.EditType.NoEdit Then
                    If e.KeyCode = 189 Then
                        str = str & "-"
                    Else
                        str = str & Chr(e.KeyCode)
                    End If

                    'MsgBox(e.KeyCode)
                    'ALLOW
                ElseIf Me.ActiveControl Is Me.grdDetalle Then 'And Me.grdDetalle.RootTable.Columns(0).EditType = Janus.Windows.GridEX.EditType.NoEdit And Me.grdDetalle.Col = 0 Then
                    str = str.Trim
                    str = str.Replace("", "")
                    intLargo = str.Length - 1
                    str = str.PadLeft(18, "0")

                    If str <> "" AndAlso str.Length > 0 AndAlso str <> "000000000000000000" Then
                        str = str.PadLeft(18, "0")
                        str = Mid(str, str.Length - 17)
                        If IsNumeric(str) Then
                            str = Mid(str, str.Length - 17)
                        Else
                            If str.Length > intLargo Then
                                str = Mid(str, str.Length - intLargo)
                            Else
                                str = Mid(str, str.Length - 11)
                            End If
                        End If
                        Dim row As DataRow = ValidarUPC(str)
                        If Not row Is Nothing Then
                            Dim rowGrid As DataRow = ExistInGrid(CStr(row("CodArticulo")), CStr(row("Numero")))
                            If rowGrid Is Nothing Then
                                InsertarCodigo(CStr(row("CodArticulo")), CStr(row("Numero")))
                                ActualizaGrid()
                                'grdDetalle.Col = 0
                                If Me.dtDetalle.Rows.Count > 0 Then
                                    grdDetalle.Row = Me.dtDetalle.Rows.Count - 1
                                End If
                            Else
                                rowGrid("Cantidad") = CDec(rowGrid("Cantidad")) + 1
                                rowGrid.AcceptChanges()
                                Me.dtDetalle.AcceptChanges()
                            End If
                        Else
                            MessageBox.Show("Código UPC no existente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        'grdDetalle.GetRow.DataRow!Codigo = str
                        str = ""
                    Else
                        str = ""
                    End If

                End If
        End Select

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub grdDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.Insert
                Me.InsertarFila()
            Case Keys.Delete
                If Not grdDetalle.GetRow() Is Nothing Then
                    Me.BorrarFila(Me.grdDetalle.GetRow.DataRow)
                End If
            Case Keys.Enter
                If grdDetalle.Col = 0 Or grdDetalle.Col = 2 Or grdDetalle.Col = 3 Then
                    SendKeys.Send("{TAB}")
                End If
        End Select
    End Sub

    Private Sub frmTraspasoInvFisico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Nuevo()
    End Sub

    Private Sub uICommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles uICommandManager1.CommandClick
        Select Case e.Command.Key
            Case "menuNuevo"
                Nuevo()
            Case "menuAbrir"
                LoadSearchTraspasosFisicos()
            Case "MnuNuevaCaja"
                NuevaCaja()
            Case "menuImprimirEtiqueta"
                If dtDetalle.Rows.Count <> 0 AndAlso Not oTraspasoS Is Nothing Then
                    ImprimirEtiqueta(ebFolio.Text.Trim, ebSucOrigenCod.Text.Trim, ebNumBulto.Text.Trim, oTraspasoS.TraspasoCreadoEl, dtDetalle)
                Else
                    MessageBox.Show("No se ha cargado ningún traspaso. Favor de Verificar.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Case "menuImprimirTraspaso"
                If dtDetalle.Rows.Count <> 0 AndAlso Not oTraspasoS Is Nothing Then
                    ImprimirTraspaso(oTraspasoS.Folio, (oTraspasoS.AlmacenOrigenID & " - " & oAlmacen.Descripcion), oTraspasoS.AlmacenDestinoID, oTraspasoS.Detalle.Tables(1))
                Else
                    If LoadSearchTraspasosFisicosAll() Then
                        oAlmacen = oAlmacenMgr.Load(oTraspasoS.AlmacenOrigenID)
                        ImprimirTraspaso(oTraspasoS.Folio, (oTraspasoS.AlmacenOrigenID & " - " & oAlmacen.Descripcion), oTraspasoS.AlmacenDestinoID, oTraspasoS.Detalle.Tables(1))
                    Else
                        MessageBox.Show("No se cargó ningún traspaso.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            Case "menuSalir"
                Me.Dispose()
        End Select
    End Sub

    Private Sub btnCerrarCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarCaja.Click
        CerrarCaja()
    End Sub

    Private Sub grdDetalle_UpdatingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grdDetalle.UpdatingCell
        If Not grdDetalle.GetRow() Is Nothing Then
            Select Case e.Column.Index
                Case 0
                    Me.BuscarArticulo(e.Value, Me.grdDetalle.Row)
                Case 1
                    If IsDBNull(Me.grdDetalle.GetRow.DataRow!Codigo) = False AndAlso CStr(Me.grdDetalle.GetRow.DataRow!Codigo) <> "" Then
                        Me.BuscarArticulo(Me.grdDetalle.GetRow.DataRow!Codigo, Me.grdDetalle.Row)
                        SendKeys.Send("{TAB}")
                        grdDetalle.Col = 2
                    End If
                Case 2
                    If IsDBNull(Me.grdDetalle.GetRow.DataRow!Codigo) = False AndAlso CStr(Me.grdDetalle.GetRow.DataRow!Codigo) <> "" Then
                        Me.BuscarArticulo(Me.grdDetalle.GetRow.DataRow!Codigo, Me.grdDetalle.Row)
                        If FillTallasArticulo(oArticulo.CodCorrida, e.Value) = True Then
                            SendKeys.Send("{TAB}")
                            grdDetalle.Col = 3
                        Else
                            MessageBox.Show("No existe esa talla para ese Articulo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            e.Cancel = True
                        End If
                    End If
                Case 3
                    If IsDBNull(Me.grdDetalle.GetRow.DataRow!Codigo) = False AndAlso CStr(Me.grdDetalle.GetRow.DataRow!Codigo) <> "" Then
                        Dim talla As String = CStr(Me.grdDetalle.GetRow.DataRow!Talla)
                        Dim codigo As String = CStr(Me.grdDetalle.GetRow.DataRow!Codigo)
                        Me.BuscarArticulo(codigo, Me.grdDetalle.Row)
                        SendKeys.Send("{TAB}")
                        If ValidarExistencia(codigo, talla, e.Value) = False Then
                            MessageBox.Show("No hay esa cantidad de Articulos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            e.Cancel = True
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub ebNumBulto_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumBulto.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ebNumBulto.Text.Trim() <> "" Then
                If IsNumeric(ebNumBulto.Text.Trim()) = True Then
                    CargarCaja(CInt(ebNumBulto.Text.Trim()))
                Else
                    MessageBox.Show("No se aceptan folios alfanumericos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        End If
    End Sub

    Private Sub ebNumBulto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumBulto.Validating, ebFolio.Validating
        If Me.ebFolio.Text.Trim <> "" Then Me.ebFolio.Text = Me.ebFolio.Text.PadLeft(10, "0")
        If Me.ebNumBulto.Text.Trim <> "" Then Me.ebNumBulto.Text = Me.ebNumBulto.Text.PadLeft(4, "0")
    End Sub



    Dim strFolioBarCode As String = ""

    Private Sub ebFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebFolio.KeyDown

        strFolioBarCode &= Chr(e.KeyCode)

        Select Case e.KeyCode
            Case Keys.Enter
                If IsNumeric(strFolioBarCode.Trim) AndAlso strFolioBarCode.Trim.Length > 10 Then
                    Dim strFolio As String = "", strCaja As String = ""
                    strFolio = strFolioBarCode.Trim.Substring(0, 10)
                    strCaja = strFolioBarCode.Trim.Substring(10)
                    Me.LoadSearchTraspasosFisicos(strFolio, False)
                    Me.CargarCaja(strCaja)
                End If
                strFolioBarCode = ""
        End Select

    End Sub


End Class
