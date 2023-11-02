Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.Net
Imports System.IO

Public Class HomeDash
    Inherits System.Windows.Forms.UserControl

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
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
    Friend WithEvents picPictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbBottom As System.Windows.Forms.PictureBox
    Friend WithEvents timer1 As System.Timers.Timer
    Friend WithEvents timer2 As System.Timers.Timer
    Friend WithEvents UiPanelManager1 As Janus.Windows.UI.Dock.UIPanelManager
    Friend WithEvents panelFondo As Janus.Windows.UI.Dock.UIPanel
    Friend WithEvents panelFondoContainer As Janus.Windows.UI.Dock.UIPanelInnerContainer
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents pbFondo As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlPedidosSH As Janus.Windows.UI.Dock.UIPanel
    Friend WithEvents pnlPedidosSHContainer As Janus.Windows.UI.Dock.UIPanelInnerContainer
    Friend WithEvents pnlPedidosEC As Janus.Windows.UI.Dock.UIPanel
    Friend WithEvents pnlPedidosECContainer As Janus.Windows.UI.Dock.UIPanelInnerContainer
    Friend WithEvents pnlInicio As Janus.Windows.UI.Dock.UIPanel
    Friend WithEvents pnlInicioContainer As Janus.Windows.UI.Dock.UIPanelInnerContainer
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents explorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTraspasosP As System.Windows.Forms.Label
    Friend WithEvents lblContratoV As System.Windows.Forms.Label
    Friend WithEvents expManagerPC As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnMenosVendidos As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnMasVendidos As Janus.Windows.EditControls.UIButton
    Friend WithEvents expEcommerce As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblPedidosCancel As System.Windows.Forms.Label
    Friend WithEvents lblPedidosCancelNum As System.Windows.Forms.Label
    Friend WithEvents lblPedidosGuias As System.Windows.Forms.Label
    Friend WithEvents lblPedidosGuiasNum As System.Windows.Forms.Label
    Friend WithEvents lblPedidosFacturar As System.Windows.Forms.Label
    Friend WithEvents lblPedidosFacturarNum As System.Windows.Forms.Label
    Friend WithEvents lblPedidosSurtir As System.Windows.Forms.Label
    Friend WithEvents lblPedidosSurtirNum As System.Windows.Forms.Label
    Friend WithEvents lblOcultar As System.Windows.Forms.LinkLabel
    Friend WithEvents pbPedidosCancelados As System.Windows.Forms.PictureBox
    Friend WithEvents pbGuiasPendientes As System.Windows.Forms.PictureBox
    Friend WithEvents pbPedidosFacturar As System.Windows.Forms.PictureBox
    Friend WithEvents pbPedidosPendientes As System.Windows.Forms.PictureBox
    Friend WithEvents expPedidosSiHay As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents imgInsurtibleSiHay As System.Windows.Forms.PictureBox
    Friend WithEvents lblPedidosInsurtibles As System.Windows.Forms.Label
    Friend WithEvents lblInsurtibleNumSiHay As System.Windows.Forms.Label
    Friend WithEvents imgRecibirSiHay As System.Windows.Forms.PictureBox
    Friend WithEvents lblPedidosPorRecibir As System.Windows.Forms.Label
    Friend WithEvents lblRecibirNumSiHay As System.Windows.Forms.Label
    Friend WithEvents lblCancSiHay As System.Windows.Forms.Label
    Friend WithEvents lblCancNumSiHay As System.Windows.Forms.Label
    Friend WithEvents lblGuiaSiHay As System.Windows.Forms.Label
    Friend WithEvents lblGuiaNumSiHay As System.Windows.Forms.Label
    Friend WithEvents lblPedidoFacturarSiHay As System.Windows.Forms.Label
    Friend WithEvents lblFacturarNumSiHay As System.Windows.Forms.Label
    Friend WithEvents lblPedidoSurtidoSiHay As System.Windows.Forms.Label
    Friend WithEvents lblPedidoNumSurSiHay As System.Windows.Forms.Label
    Friend WithEvents lblOcultarSiHay As System.Windows.Forms.LinkLabel
    Friend WithEvents imgCancSiHay As System.Windows.Forms.PictureBox
    Friend WithEvents imgGuiaSiHay As System.Windows.Forms.PictureBox
    Friend WithEvents imgFacturarSinHay As System.Windows.Forms.PictureBox
    Friend WithEvents imgSurtirSiHay As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAvisos As Janus.Windows.UI.Dock.UIPanelGroup
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtMetaDiaria As System.Windows.Forms.Label
    Friend WithEvents txtAPV As System.Windows.Forms.Label
    Friend WithEvents lblMetaDiaria As System.Windows.Forms.Label
    Friend WithEvents lblAPV As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtCantidadRestante As System.Windows.Forms.Label
    Friend WithEvents txtVentasXPromedio As System.Windows.Forms.Label
    Friend WithEvents lblCantidadRestante As System.Windows.Forms.Label
    Friend WithEvents lblVentasPromedio As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtCteXAtender As System.Windows.Forms.Label
    Friend WithEvents lblMarkerTienda As System.Windows.Forms.Label
    Friend WithEvents lblClientesXAtender As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVentasDia As System.Windows.Forms.Label
    Friend WithEvents lblVentasDia As System.Windows.Forms.Label
    Friend WithEvents GridMetasPlayers As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdPromoVigentes As Janus.Windows.GridEX.GridEX
    Friend WithEvents Timer3 As System.Timers.Timer
    Friend WithEvents expPromoVigentes As Janus.Windows.ExplorerBar.ExplorerBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HomeDash))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.picPictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pbBottom = New System.Windows.Forms.PictureBox()
        Me.timer1 = New System.Timers.Timer()
        Me.timer2 = New System.Timers.Timer()
        Me.UiPanelManager1 = New Janus.Windows.UI.Dock.UIPanelManager(Me.components)
        Me.pnlAvisos = New Janus.Windows.UI.Dock.UIPanelGroup()
        Me.pnlInicio = New Janus.Windows.UI.Dock.UIPanel()
        Me.pnlInicioContainer = New Janus.Windows.UI.Dock.UIPanelInnerContainer()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.expPromoVigentes = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grdPromoVigentes = New Janus.Windows.GridEX.GridEX()
        Me.expManagerPC = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnMenosVendidos = New Janus.Windows.EditControls.UIButton()
        Me.btnMasVendidos = New Janus.Windows.EditControls.UIButton()
        Me.explorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTraspasosP = New System.Windows.Forms.Label()
        Me.lblContratoV = New System.Windows.Forms.Label()
        Me.pnlPedidosEC = New Janus.Windows.UI.Dock.UIPanel()
        Me.pnlPedidosECContainer = New Janus.Windows.UI.Dock.UIPanelInnerContainer()
        Me.expEcommerce = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblPedidosCancel = New System.Windows.Forms.Label()
        Me.lblPedidosGuias = New System.Windows.Forms.Label()
        Me.lblPedidosFacturar = New System.Windows.Forms.Label()
        Me.lblPedidosSurtir = New System.Windows.Forms.Label()
        Me.lblPedidosCancelNum = New System.Windows.Forms.Label()
        Me.lblPedidosGuiasNum = New System.Windows.Forms.Label()
        Me.lblPedidosFacturarNum = New System.Windows.Forms.Label()
        Me.lblPedidosSurtirNum = New System.Windows.Forms.Label()
        Me.lblOcultar = New System.Windows.Forms.LinkLabel()
        Me.pbPedidosCancelados = New System.Windows.Forms.PictureBox()
        Me.pbGuiasPendientes = New System.Windows.Forms.PictureBox()
        Me.pbPedidosFacturar = New System.Windows.Forms.PictureBox()
        Me.pbPedidosPendientes = New System.Windows.Forms.PictureBox()
        Me.pnlPedidosSH = New Janus.Windows.UI.Dock.UIPanel()
        Me.pnlPedidosSHContainer = New Janus.Windows.UI.Dock.UIPanelInnerContainer()
        Me.expPedidosSiHay = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.imgRecibirSiHay = New System.Windows.Forms.PictureBox()
        Me.lblRecibirNumSiHay = New System.Windows.Forms.Label()
        Me.lblGuiaSiHay = New System.Windows.Forms.Label()
        Me.lblPedidosPorRecibir = New System.Windows.Forms.Label()
        Me.lblPedidosInsurtibles = New System.Windows.Forms.Label()
        Me.lblCancSiHay = New System.Windows.Forms.Label()
        Me.lblPedidoFacturarSiHay = New System.Windows.Forms.Label()
        Me.lblPedidoSurtidoSiHay = New System.Windows.Forms.Label()
        Me.imgInsurtibleSiHay = New System.Windows.Forms.PictureBox()
        Me.lblInsurtibleNumSiHay = New System.Windows.Forms.Label()
        Me.lblCancNumSiHay = New System.Windows.Forms.Label()
        Me.lblGuiaNumSiHay = New System.Windows.Forms.Label()
        Me.lblFacturarNumSiHay = New System.Windows.Forms.Label()
        Me.lblPedidoNumSurSiHay = New System.Windows.Forms.Label()
        Me.lblOcultarSiHay = New System.Windows.Forms.LinkLabel()
        Me.imgCancSiHay = New System.Windows.Forms.PictureBox()
        Me.imgGuiaSiHay = New System.Windows.Forms.PictureBox()
        Me.imgFacturarSinHay = New System.Windows.Forms.PictureBox()
        Me.imgSurtirSiHay = New System.Windows.Forms.PictureBox()
        Me.panelFondo = New Janus.Windows.UI.Dock.UIPanel()
        Me.panelFondoContainer = New Janus.Windows.UI.Dock.UIPanelInnerContainer()
        Me.GridMetasPlayers = New Janus.Windows.GridEX.GridEX()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtMetaDiaria = New System.Windows.Forms.Label()
        Me.txtAPV = New System.Windows.Forms.Label()
        Me.lblMetaDiaria = New System.Windows.Forms.Label()
        Me.lblAPV = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtCantidadRestante = New System.Windows.Forms.Label()
        Me.txtVentasXPromedio = New System.Windows.Forms.Label()
        Me.lblCantidadRestante = New System.Windows.Forms.Label()
        Me.lblVentasPromedio = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVentasDia = New System.Windows.Forms.Label()
        Me.txtCteXAtender = New System.Windows.Forms.Label()
        Me.lblMarkerTienda = New System.Windows.Forms.Label()
        Me.lblVentasDia = New System.Windows.Forms.Label()
        Me.lblClientesXAtender = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.pbFondo = New System.Windows.Forms.PictureBox()
        Me.Timer3 = New System.Timers.Timer()
        CType(Me.picPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.timer2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiPanelManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlAvisos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAvisos.SuspendLayout()
        CType(Me.pnlInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInicio.SuspendLayout()
        Me.pnlInicioContainer.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.expPromoVigentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expPromoVigentes.SuspendLayout()
        CType(Me.grdPromoVigentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.expManagerPC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expManagerPC.SuspendLayout()
        CType(Me.explorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar2.SuspendLayout()
        CType(Me.pnlPedidosEC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPedidosEC.SuspendLayout()
        Me.pnlPedidosECContainer.SuspendLayout()
        CType(Me.expEcommerce, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expEcommerce.SuspendLayout()
        CType(Me.pbPedidosCancelados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbGuiasPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPedidosFacturar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPedidosPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPedidosSH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPedidosSH.SuspendLayout()
        Me.pnlPedidosSHContainer.SuspendLayout()
        CType(Me.expPedidosSiHay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expPedidosSiHay.SuspendLayout()
        CType(Me.imgRecibirSiHay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgInsurtibleSiHay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCancSiHay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgGuiaSiHay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFacturarSinHay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgSurtirSiHay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelFondo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelFondo.SuspendLayout()
        Me.panelFondoContainer.SuspendLayout()
        CType(Me.GridMetasPlayers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pbFondo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Timer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picPictureBox1
        '
        Me.picPictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPictureBox1.Image = CType(resources.GetObject("picPictureBox1.Image"), System.Drawing.Image)
        Me.picPictureBox1.Location = New System.Drawing.Point(192, 0)
        Me.picPictureBox1.Name = "picPictureBox1"
        Me.picPictureBox1.Size = New System.Drawing.Size(920, 8)
        Me.picPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picPictureBox1.TabIndex = 0
        Me.picPictureBox1.TabStop = False
        Me.picPictureBox1.Visible = False
        '
        'pbBottom
        '
        Me.pbBottom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbBottom.Image = CType(resources.GetObject("pbBottom.Image"), System.Drawing.Image)
        Me.pbBottom.Location = New System.Drawing.Point(248, 368)
        Me.pbBottom.Name = "pbBottom"
        Me.pbBottom.Size = New System.Drawing.Size(440, 40)
        Me.pbBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBottom.TabIndex = 55
        Me.pbBottom.TabStop = False
        Me.pbBottom.Visible = False
        '
        'timer1
        '
        Me.timer1.Interval = 5000.0R
        Me.timer1.SynchronizingObject = Me
        '
        'timer2
        '
        Me.timer2.Interval = 500.0R
        Me.timer2.SynchronizingObject = Me
        '
        'UiPanelManager1
        '
        Me.UiPanelManager1.AllowPanelResize = False
        Me.UiPanelManager1.ContainerControl = Me
        Me.UiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark
        Me.UiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.UiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.UiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        Me.pnlAvisos.Id = New System.Guid("703bc665-4b21-4199-b3a4-81a1e7e9ffe8")
        Me.pnlAvisos.StaticGroup = True
        Me.pnlInicio.Id = New System.Guid("ef1dcc84-5c72-4bd9-8b9f-293f3772d10f")
        Me.pnlAvisos.Panels.Add(Me.pnlInicio)
        Me.pnlPedidosEC.Id = New System.Guid("b1e71996-f5d1-437e-b587-7c12927677c4")
        Me.pnlAvisos.Panels.Add(Me.pnlPedidosEC)
        Me.pnlPedidosSH.Id = New System.Guid("f67632b6-a259-40dd-a8fb-4c8419a5fe75")
        Me.pnlAvisos.Panels.Add(Me.pnlPedidosSH)
        Me.UiPanelManager1.Panels.Add(Me.pnlAvisos)
        Me.panelFondo.Id = New System.Guid("d77f940c-89f7-407c-9727-4bb3e08467c5")
        Me.UiPanelManager1.Panels.Add(Me.panelFondo)
        '
        'Design Time Panel Info:
        '
        Me.UiPanelManager1.BeginPanelInfo()
        Me.UiPanelManager1.AddDockPanelInfo(New System.Guid("d77f940c-89f7-407c-9727-4bb3e08467c5"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, New System.Drawing.Size(837, 410), True)
        Me.UiPanelManager1.AddDockPanelInfo(New System.Guid("703bc665-4b21-4199-b3a4-81a1e7e9ffe8"), Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator, Janus.Windows.UI.Dock.PanelDockStyle.Left, True, New System.Drawing.Size(269, 410), True)
        Me.UiPanelManager1.AddDockPanelInfo(New System.Guid("ef1dcc84-5c72-4bd9-8b9f-293f3772d10f"), New System.Guid("703bc665-4b21-4199-b3a4-81a1e7e9ffe8"), -1, True)
        Me.UiPanelManager1.AddDockPanelInfo(New System.Guid("b1e71996-f5d1-437e-b587-7c12927677c4"), New System.Guid("703bc665-4b21-4199-b3a4-81a1e7e9ffe8"), -1, True)
        Me.UiPanelManager1.AddDockPanelInfo(New System.Guid("f67632b6-a259-40dd-a8fb-4c8419a5fe75"), New System.Guid("703bc665-4b21-4199-b3a4-81a1e7e9ffe8"), -1, True)
        Me.UiPanelManager1.AddFloatingPanelInfo(New System.Guid("b1e71996-f5d1-437e-b587-7c12927677c4"), New System.Drawing.Point(-1, -1), New System.Drawing.Size(-1, -1), False)
        Me.UiPanelManager1.AddFloatingPanelInfo(New System.Guid("d77f940c-89f7-407c-9727-4bb3e08467c5"), New System.Drawing.Point(-1, -1), New System.Drawing.Size(-1, -1), False)
        Me.UiPanelManager1.AddFloatingPanelInfo(New System.Guid("703bc665-4b21-4199-b3a4-81a1e7e9ffe8"), Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator, True, New System.Drawing.Point(-1, -1), New System.Drawing.Size(-1, -1), False)
        Me.UiPanelManager1.AddFloatingPanelInfo(New System.Guid("ef1dcc84-5c72-4bd9-8b9f-293f3772d10f"), New System.Drawing.Point(-1, -1), New System.Drawing.Size(-1, -1), False)
        Me.UiPanelManager1.AddFloatingPanelInfo(New System.Guid("f67632b6-a259-40dd-a8fb-4c8419a5fe75"), New System.Drawing.Point(-1, -1), New System.Drawing.Size(-1, -1), False)
        Me.UiPanelManager1.EndPanelInfo()
        '
        'pnlAvisos
        '
        Me.pnlAvisos.AllowPanelDrag = Janus.Windows.UI.InheritableBoolean.[False]
        Me.pnlAvisos.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.[False]
        Me.pnlAvisos.CaptionDisplayMode = Janus.Windows.UI.Dock.PanelCaptionDisplayMode.Text
        Me.pnlAvisos.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None
        Me.pnlAvisos.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        Me.pnlAvisos.CaptionFormatStyle.ForeColor = System.Drawing.Color.Yellow
        Me.pnlAvisos.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.[False]
        Me.pnlAvisos.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator
        Me.pnlAvisos.Location = New System.Drawing.Point(3, 3)
        Me.pnlAvisos.Name = "pnlAvisos"
        Me.pnlAvisos.SelectedPanel = Me.pnlPedidosEC
        Me.pnlAvisos.ShowOutlookNavigatorConfigureMenu = False
        Me.pnlAvisos.Size = New System.Drawing.Size(269, 410)
        Me.pnlAvisos.TabIndex = 4
        Me.pnlAvisos.TabStateStyles.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.pnlAvisos.Text = "Avisos"
        Me.pnlAvisos.TextAlignment = Janus.Windows.UI.Dock.PanelTextAlignment.Center
        '
        'pnlInicio
        '
        Me.pnlInicio.InnerContainer = Me.pnlInicioContainer
        Me.pnlInicio.Location = New System.Drawing.Point(0, 0)
        Me.pnlInicio.Name = "pnlInicio"
        Me.pnlInicio.Size = New System.Drawing.Size(265, 274)
        Me.pnlInicio.TabIndex = 4
        Me.pnlInicio.Text = "Inicio"
        Me.pnlInicio.TextAlignment = Janus.Windows.UI.Dock.PanelTextAlignment.Center
        '
        'pnlInicioContainer
        '
        Me.pnlInicioContainer.Controls.Add(Me.ExplorerBar1)
        Me.pnlInicioContainer.Location = New System.Drawing.Point(1, 24)
        Me.pnlInicioContainer.Name = "pnlInicioContainer"
        Me.pnlInicioContainer.Size = New System.Drawing.Size(263, 250)
        Me.pnlInicioContainer.TabIndex = 0
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.expPromoVigentes)
        Me.ExplorerBar1.Controls.Add(Me.expManagerPC)
        Me.ExplorerBar1.Controls.Add(Me.explorerBar2)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(263, 250)
        Me.ExplorerBar1.TabIndex = 86
        Me.ExplorerBar1.Text = "ExplorerBar3"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'expPromoVigentes
        '
        Me.expPromoVigentes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.expPromoVigentes.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.expPromoVigentes.Controls.Add(Me.grdPromoVigentes)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Promociones Vigentes"
        Me.expPromoVigentes.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.expPromoVigentes.Location = New System.Drawing.Point(-1, 56)
        Me.expPromoVigentes.Name = "expPromoVigentes"
        Me.expPromoVigentes.Size = New System.Drawing.Size(265, 152)
        Me.expPromoVigentes.TabIndex = 87
        Me.expPromoVigentes.Text = "ExplorerBar2"
        Me.expPromoVigentes.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grdPromoVigentes
        '
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.grdPromoVigentes.DesignTimeLayout = GridEXLayout2
        Me.grdPromoVigentes.GroupByBoxVisible = False
        Me.grdPromoVigentes.Location = New System.Drawing.Point(8, 32)
        Me.grdPromoVigentes.Name = "grdPromoVigentes"
        Me.grdPromoVigentes.Size = New System.Drawing.Size(248, 112)
        Me.grdPromoVigentes.TabIndex = 1
        Me.grdPromoVigentes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'expManagerPC
        '
        Me.expManagerPC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.expManagerPC.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.expManagerPC.Controls.Add(Me.btnMenosVendidos)
        Me.expManagerPC.Controls.Add(Me.btnMasVendidos)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Manager Panel Control"
        Me.expManagerPC.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.expManagerPC.Location = New System.Drawing.Point(0, 208)
        Me.expManagerPC.Name = "expManagerPC"
        Me.expManagerPC.Size = New System.Drawing.Size(265, 112)
        Me.expManagerPC.TabIndex = 86
        Me.expManagerPC.Text = "ExplorerBar2"
        Me.expManagerPC.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnMenosVendidos
        '
        Me.btnMenosVendidos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenosVendidos.Location = New System.Drawing.Point(8, 64)
        Me.btnMenosVendidos.Name = "btnMenosVendidos"
        Me.btnMenosVendidos.Size = New System.Drawing.Size(200, 24)
        Me.btnMenosVendidos.StateStyles.FormatStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMenosVendidos.TabIndex = 72
        Me.btnMenosVendidos.Text = "F3: Los 10 Menos Vendidos"
        Me.btnMenosVendidos.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.btnMenosVendidos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'btnMasVendidos
        '
        Me.btnMasVendidos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMasVendidos.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Empty
        Me.btnMasVendidos.ImageSize = New System.Drawing.Size(64, 64)
        Me.btnMasVendidos.Location = New System.Drawing.Point(8, 32)
        Me.btnMasVendidos.Name = "btnMasVendidos"
        Me.btnMasVendidos.Size = New System.Drawing.Size(200, 24)
        Me.btnMasVendidos.StateStyles.FormatStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMasVendidos.TabIndex = 71
        Me.btnMasVendidos.Text = "F2: Los 10 Mas Vendidos"
        Me.btnMasVendidos.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.btnMasVendidos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'explorerBar2
        '
        Me.explorerBar2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.explorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar2.Controls.Add(Me.lblLabel2)
        Me.explorerBar2.Controls.Add(Me.Label3)
        Me.explorerBar2.Controls.Add(Me.lblTraspasosP)
        Me.explorerBar2.Controls.Add(Me.lblContratoV)
        Me.explorerBar2.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar2.Name = "explorerBar2"
        Me.explorerBar2.Size = New System.Drawing.Size(264, 56)
        Me.explorerBar2.TabIndex = 82
        Me.explorerBar2.Text = "ExplorerBar2"
        Me.explorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabel2.Location = New System.Drawing.Point(8, 8)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(176, 16)
        Me.lblLabel2.TabIndex = 57
        Me.lblLabel2.Text = "TRASPASOS SIN GRABAR"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 16)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "CONTRATOS VENCIDOS"
        '
        'lblTraspasosP
        '
        Me.lblTraspasosP.BackColor = System.Drawing.Color.Transparent
        Me.lblTraspasosP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTraspasosP.ForeColor = System.Drawing.Color.Black
        Me.lblTraspasosP.Location = New System.Drawing.Point(128, 8)
        Me.lblTraspasosP.Name = "lblTraspasosP"
        Me.lblTraspasosP.Size = New System.Drawing.Size(80, 24)
        Me.lblTraspasosP.TabIndex = 58
        Me.lblTraspasosP.Text = "0"
        Me.lblTraspasosP.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblContratoV
        '
        Me.lblContratoV.BackColor = System.Drawing.Color.Transparent
        Me.lblContratoV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContratoV.ForeColor = System.Drawing.Color.Black
        Me.lblContratoV.Location = New System.Drawing.Point(128, 32)
        Me.lblContratoV.Name = "lblContratoV"
        Me.lblContratoV.Size = New System.Drawing.Size(80, 24)
        Me.lblContratoV.TabIndex = 60
        Me.lblContratoV.Text = "0"
        Me.lblContratoV.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pnlPedidosEC
        '
        Me.pnlPedidosEC.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.[False]
        Me.pnlPedidosEC.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.[False]
        Me.pnlPedidosEC.InnerContainer = Me.pnlPedidosECContainer
        Me.pnlPedidosEC.Location = New System.Drawing.Point(0, 0)
        Me.pnlPedidosEC.Name = "pnlPedidosEC"
        Me.pnlPedidosEC.Size = New System.Drawing.Size(265, 274)
        Me.pnlPedidosEC.TabIndex = 4
        Me.pnlPedidosEC.Text = "Pedidos Pendientes EC"
        Me.pnlPedidosEC.TextAlignment = Janus.Windows.UI.Dock.PanelTextAlignment.Center
        '
        'pnlPedidosECContainer
        '
        Me.pnlPedidosECContainer.Controls.Add(Me.expEcommerce)
        Me.pnlPedidosECContainer.Location = New System.Drawing.Point(1, 24)
        Me.pnlPedidosECContainer.Name = "pnlPedidosECContainer"
        Me.pnlPedidosECContainer.Size = New System.Drawing.Size(263, 250)
        Me.pnlPedidosECContainer.TabIndex = 0
        '
        'expEcommerce
        '
        Me.expEcommerce.Controls.Add(Me.lblPedidosCancel)
        Me.expEcommerce.Controls.Add(Me.lblPedidosGuias)
        Me.expEcommerce.Controls.Add(Me.lblPedidosFacturar)
        Me.expEcommerce.Controls.Add(Me.lblPedidosSurtir)
        Me.expEcommerce.Controls.Add(Me.lblPedidosCancelNum)
        Me.expEcommerce.Controls.Add(Me.lblPedidosGuiasNum)
        Me.expEcommerce.Controls.Add(Me.lblPedidosFacturarNum)
        Me.expEcommerce.Controls.Add(Me.lblPedidosSurtirNum)
        Me.expEcommerce.Controls.Add(Me.lblOcultar)
        Me.expEcommerce.Controls.Add(Me.pbPedidosCancelados)
        Me.expEcommerce.Controls.Add(Me.pbGuiasPendientes)
        Me.expEcommerce.Controls.Add(Me.pbPedidosFacturar)
        Me.expEcommerce.Controls.Add(Me.pbPedidosPendientes)
        Me.expEcommerce.Dock = System.Windows.Forms.DockStyle.Fill
        Me.expEcommerce.Location = New System.Drawing.Point(0, 0)
        Me.expEcommerce.Name = "expEcommerce"
        Me.expEcommerce.Size = New System.Drawing.Size(263, 250)
        Me.expEcommerce.TabIndex = 83
        Me.expEcommerce.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblPedidosCancel
        '
        Me.lblPedidosCancel.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidosCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidosCancel.Location = New System.Drawing.Point(8, 112)
        Me.lblPedidosCancel.Name = "lblPedidosCancel"
        Me.lblPedidosCancel.Size = New System.Drawing.Size(176, 16)
        Me.lblPedidosCancel.TabIndex = 106
        Me.lblPedidosCancel.Text = "PEDIDOS CANCELADOS"
        Me.lblPedidosCancel.Visible = False
        '
        'lblPedidosGuias
        '
        Me.lblPedidosGuias.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidosGuias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosGuias.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidosGuias.Location = New System.Drawing.Point(8, 80)
        Me.lblPedidosGuias.Name = "lblPedidosGuias"
        Me.lblPedidosGuias.Size = New System.Drawing.Size(176, 16)
        Me.lblPedidosGuias.TabIndex = 104
        Me.lblPedidosGuias.Text = "PEDIDOS SIN GUIA"
        Me.lblPedidosGuias.Visible = False
        '
        'lblPedidosFacturar
        '
        Me.lblPedidosFacturar.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidosFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosFacturar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidosFacturar.Location = New System.Drawing.Point(8, 48)
        Me.lblPedidosFacturar.Name = "lblPedidosFacturar"
        Me.lblPedidosFacturar.Size = New System.Drawing.Size(176, 16)
        Me.lblPedidosFacturar.TabIndex = 102
        Me.lblPedidosFacturar.Text = "PEDIDOS POR FACTURAR"
        Me.lblPedidosFacturar.Visible = False
        '
        'lblPedidosSurtir
        '
        Me.lblPedidosSurtir.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidosSurtir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosSurtir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidosSurtir.Location = New System.Drawing.Point(8, 16)
        Me.lblPedidosSurtir.Name = "lblPedidosSurtir"
        Me.lblPedidosSurtir.Size = New System.Drawing.Size(176, 16)
        Me.lblPedidosSurtir.TabIndex = 100
        Me.lblPedidosSurtir.Text = "PEDIDOS POR ENVIAR"
        '
        'lblPedidosCancelNum
        '
        Me.lblPedidosCancelNum.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidosCancelNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosCancelNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidosCancelNum.Location = New System.Drawing.Point(124, 112)
        Me.lblPedidosCancelNum.Name = "lblPedidosCancelNum"
        Me.lblPedidosCancelNum.Size = New System.Drawing.Size(80, 24)
        Me.lblPedidosCancelNum.TabIndex = 107
        Me.lblPedidosCancelNum.Text = "0"
        Me.lblPedidosCancelNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblPedidosCancelNum.Visible = False
        '
        'lblPedidosGuiasNum
        '
        Me.lblPedidosGuiasNum.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidosGuiasNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosGuiasNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidosGuiasNum.Location = New System.Drawing.Point(124, 80)
        Me.lblPedidosGuiasNum.Name = "lblPedidosGuiasNum"
        Me.lblPedidosGuiasNum.Size = New System.Drawing.Size(80, 24)
        Me.lblPedidosGuiasNum.TabIndex = 105
        Me.lblPedidosGuiasNum.Text = "0"
        Me.lblPedidosGuiasNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblPedidosGuiasNum.Visible = False
        '
        'lblPedidosFacturarNum
        '
        Me.lblPedidosFacturarNum.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidosFacturarNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosFacturarNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidosFacturarNum.Location = New System.Drawing.Point(124, 48)
        Me.lblPedidosFacturarNum.Name = "lblPedidosFacturarNum"
        Me.lblPedidosFacturarNum.Size = New System.Drawing.Size(80, 24)
        Me.lblPedidosFacturarNum.TabIndex = 103
        Me.lblPedidosFacturarNum.Text = "0"
        Me.lblPedidosFacturarNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblPedidosFacturarNum.Visible = False
        '
        'lblPedidosSurtirNum
        '
        Me.lblPedidosSurtirNum.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidosSurtirNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosSurtirNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidosSurtirNum.Location = New System.Drawing.Point(124, 16)
        Me.lblPedidosSurtirNum.Name = "lblPedidosSurtirNum"
        Me.lblPedidosSurtirNum.Size = New System.Drawing.Size(80, 24)
        Me.lblPedidosSurtirNum.TabIndex = 101
        Me.lblPedidosSurtirNum.Text = "0"
        Me.lblPedidosSurtirNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblOcultar
        '
        Me.lblOcultar.AutoSize = True
        Me.lblOcultar.BackColor = System.Drawing.Color.Transparent
        Me.lblOcultar.Location = New System.Drawing.Point(96, 136)
        Me.lblOcultar.Name = "lblOcultar"
        Me.lblOcultar.Size = New System.Drawing.Size(41, 13)
        Me.lblOcultar.TabIndex = 92
        Me.lblOcultar.TabStop = True
        Me.lblOcultar.Text = "Ocultar"
        Me.lblOcultar.Visible = False
        '
        'pbPedidosCancelados
        '
        Me.pbPedidosCancelados.BackColor = System.Drawing.Color.Transparent
        Me.pbPedidosCancelados.Image = CType(resources.GetObject("pbPedidosCancelados.Image"), System.Drawing.Image)
        Me.pbPedidosCancelados.Location = New System.Drawing.Point(204, 104)
        Me.pbPedidosCancelados.Name = "pbPedidosCancelados"
        Me.pbPedidosCancelados.Size = New System.Drawing.Size(32, 24)
        Me.pbPedidosCancelados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPedidosCancelados.TabIndex = 99
        Me.pbPedidosCancelados.TabStop = False
        Me.pbPedidosCancelados.Visible = False
        '
        'pbGuiasPendientes
        '
        Me.pbGuiasPendientes.BackColor = System.Drawing.Color.Transparent
        Me.pbGuiasPendientes.Image = CType(resources.GetObject("pbGuiasPendientes.Image"), System.Drawing.Image)
        Me.pbGuiasPendientes.Location = New System.Drawing.Point(204, 72)
        Me.pbGuiasPendientes.Name = "pbGuiasPendientes"
        Me.pbGuiasPendientes.Size = New System.Drawing.Size(32, 24)
        Me.pbGuiasPendientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbGuiasPendientes.TabIndex = 98
        Me.pbGuiasPendientes.TabStop = False
        Me.pbGuiasPendientes.Visible = False
        '
        'pbPedidosFacturar
        '
        Me.pbPedidosFacturar.BackColor = System.Drawing.Color.Transparent
        Me.pbPedidosFacturar.Image = CType(resources.GetObject("pbPedidosFacturar.Image"), System.Drawing.Image)
        Me.pbPedidosFacturar.Location = New System.Drawing.Point(204, 40)
        Me.pbPedidosFacturar.Name = "pbPedidosFacturar"
        Me.pbPedidosFacturar.Size = New System.Drawing.Size(32, 24)
        Me.pbPedidosFacturar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPedidosFacturar.TabIndex = 97
        Me.pbPedidosFacturar.TabStop = False
        Me.pbPedidosFacturar.Visible = False
        '
        'pbPedidosPendientes
        '
        Me.pbPedidosPendientes.BackColor = System.Drawing.Color.Transparent
        Me.pbPedidosPendientes.Image = CType(resources.GetObject("pbPedidosPendientes.Image"), System.Drawing.Image)
        Me.pbPedidosPendientes.Location = New System.Drawing.Point(204, 8)
        Me.pbPedidosPendientes.Name = "pbPedidosPendientes"
        Me.pbPedidosPendientes.Size = New System.Drawing.Size(32, 24)
        Me.pbPedidosPendientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPedidosPendientes.TabIndex = 96
        Me.pbPedidosPendientes.TabStop = False
        Me.pbPedidosPendientes.Visible = False
        '
        'pnlPedidosSH
        '
        Me.pnlPedidosSH.InnerContainer = Me.pnlPedidosSHContainer
        Me.pnlPedidosSH.Location = New System.Drawing.Point(0, 0)
        Me.pnlPedidosSH.Name = "pnlPedidosSH"
        Me.pnlPedidosSH.Size = New System.Drawing.Size(265, 274)
        Me.pnlPedidosSH.TabIndex = 4
        Me.pnlPedidosSH.Text = "Pedidos Pendientes SH"
        Me.pnlPedidosSH.TextAlignment = Janus.Windows.UI.Dock.PanelTextAlignment.Center
        '
        'pnlPedidosSHContainer
        '
        Me.pnlPedidosSHContainer.Controls.Add(Me.expPedidosSiHay)
        Me.pnlPedidosSHContainer.Location = New System.Drawing.Point(1, 24)
        Me.pnlPedidosSHContainer.Name = "pnlPedidosSHContainer"
        Me.pnlPedidosSHContainer.Size = New System.Drawing.Size(263, 250)
        Me.pnlPedidosSHContainer.TabIndex = 0
        '
        'expPedidosSiHay
        '
        Me.expPedidosSiHay.Controls.Add(Me.imgRecibirSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.lblRecibirNumSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.lblGuiaSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.lblPedidosPorRecibir)
        Me.expPedidosSiHay.Controls.Add(Me.lblPedidosInsurtibles)
        Me.expPedidosSiHay.Controls.Add(Me.lblCancSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.lblPedidoFacturarSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.lblPedidoSurtidoSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.imgInsurtibleSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.lblInsurtibleNumSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.lblCancNumSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.lblGuiaNumSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.lblFacturarNumSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.lblPedidoNumSurSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.lblOcultarSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.imgCancSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.imgGuiaSiHay)
        Me.expPedidosSiHay.Controls.Add(Me.imgFacturarSinHay)
        Me.expPedidosSiHay.Controls.Add(Me.imgSurtirSiHay)
        Me.expPedidosSiHay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.expPedidosSiHay.Location = New System.Drawing.Point(0, 0)
        Me.expPedidosSiHay.Name = "expPedidosSiHay"
        Me.expPedidosSiHay.Size = New System.Drawing.Size(263, 250)
        Me.expPedidosSiHay.TabIndex = 84
        Me.expPedidosSiHay.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'imgRecibirSiHay
        '
        Me.imgRecibirSiHay.BackColor = System.Drawing.Color.Transparent
        Me.imgRecibirSiHay.Image = CType(resources.GetObject("imgRecibirSiHay.Image"), System.Drawing.Image)
        Me.imgRecibirSiHay.Location = New System.Drawing.Point(208, 42)
        Me.imgRecibirSiHay.Name = "imgRecibirSiHay"
        Me.imgRecibirSiHay.Size = New System.Drawing.Size(24, 24)
        Me.imgRecibirSiHay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgRecibirSiHay.TabIndex = 110
        Me.imgRecibirSiHay.TabStop = False
        Me.imgRecibirSiHay.Visible = False
        '
        'lblRecibirNumSiHay
        '
        Me.lblRecibirNumSiHay.BackColor = System.Drawing.Color.Transparent
        Me.lblRecibirNumSiHay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecibirNumSiHay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRecibirNumSiHay.Location = New System.Drawing.Point(168, 45)
        Me.lblRecibirNumSiHay.Name = "lblRecibirNumSiHay"
        Me.lblRecibirNumSiHay.Size = New System.Drawing.Size(32, 24)
        Me.lblRecibirNumSiHay.TabIndex = 109
        Me.lblRecibirNumSiHay.Text = "0"
        Me.lblRecibirNumSiHay.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblRecibirNumSiHay.Visible = False
        '
        'lblGuiaSiHay
        '
        Me.lblGuiaSiHay.BackColor = System.Drawing.Color.Transparent
        Me.lblGuiaSiHay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuiaSiHay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGuiaSiHay.Location = New System.Drawing.Point(4, 168)
        Me.lblGuiaSiHay.Name = "lblGuiaSiHay"
        Me.lblGuiaSiHay.Size = New System.Drawing.Size(176, 16)
        Me.lblGuiaSiHay.TabIndex = 104
        Me.lblGuiaSiHay.Text = "PEDIDOS SIN GUIA"
        Me.lblGuiaSiHay.Visible = False
        '
        'lblPedidosPorRecibir
        '
        Me.lblPedidosPorRecibir.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidosPorRecibir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosPorRecibir.Location = New System.Drawing.Point(2, 48)
        Me.lblPedidosPorRecibir.Name = "lblPedidosPorRecibir"
        Me.lblPedidosPorRecibir.Size = New System.Drawing.Size(160, 16)
        Me.lblPedidosPorRecibir.TabIndex = 108
        Me.lblPedidosPorRecibir.Text = "PEDIDOS POR RECIBIR"
        Me.lblPedidosPorRecibir.Visible = False
        '
        'lblPedidosInsurtibles
        '
        Me.lblPedidosInsurtibles.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidosInsurtibles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosInsurtibles.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidosInsurtibles.Location = New System.Drawing.Point(0, 103)
        Me.lblPedidosInsurtibles.Name = "lblPedidosInsurtibles"
        Me.lblPedidosInsurtibles.Size = New System.Drawing.Size(176, 16)
        Me.lblPedidosInsurtibles.TabIndex = 111
        Me.lblPedidosInsurtibles.Text = "PEDIDOS INSURTIBLES"
        Me.lblPedidosInsurtibles.Visible = False
        '
        'lblCancSiHay
        '
        Me.lblCancSiHay.BackColor = System.Drawing.Color.Transparent
        Me.lblCancSiHay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancSiHay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCancSiHay.Location = New System.Drawing.Point(0, 144)
        Me.lblCancSiHay.Name = "lblCancSiHay"
        Me.lblCancSiHay.Size = New System.Drawing.Size(176, 16)
        Me.lblCancSiHay.TabIndex = 106
        Me.lblCancSiHay.Text = "PEDIDOS CANCELADOS"
        Me.lblCancSiHay.Visible = False
        '
        'lblPedidoFacturarSiHay
        '
        Me.lblPedidoFacturarSiHay.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidoFacturarSiHay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoFacturarSiHay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidoFacturarSiHay.Location = New System.Drawing.Point(0, 76)
        Me.lblPedidoFacturarSiHay.Name = "lblPedidoFacturarSiHay"
        Me.lblPedidoFacturarSiHay.Size = New System.Drawing.Size(176, 16)
        Me.lblPedidoFacturarSiHay.TabIndex = 102
        Me.lblPedidoFacturarSiHay.Text = "PEDIDOS POR FACTURAR"
        Me.lblPedidoFacturarSiHay.Visible = False
        '
        'lblPedidoSurtidoSiHay
        '
        Me.lblPedidoSurtidoSiHay.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidoSurtidoSiHay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoSurtidoSiHay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidoSurtidoSiHay.Location = New System.Drawing.Point(0, 16)
        Me.lblPedidoSurtidoSiHay.Name = "lblPedidoSurtidoSiHay"
        Me.lblPedidoSurtidoSiHay.Size = New System.Drawing.Size(176, 16)
        Me.lblPedidoSurtidoSiHay.TabIndex = 100
        Me.lblPedidoSurtidoSiHay.Text = "PEDIDOS POR SURTIR"
        Me.lblPedidoSurtidoSiHay.Visible = False
        '
        'imgInsurtibleSiHay
        '
        Me.imgInsurtibleSiHay.BackColor = System.Drawing.Color.Transparent
        Me.imgInsurtibleSiHay.Image = CType(resources.GetObject("imgInsurtibleSiHay.Image"), System.Drawing.Image)
        Me.imgInsurtibleSiHay.Location = New System.Drawing.Point(208, 99)
        Me.imgInsurtibleSiHay.Name = "imgInsurtibleSiHay"
        Me.imgInsurtibleSiHay.Size = New System.Drawing.Size(24, 24)
        Me.imgInsurtibleSiHay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgInsurtibleSiHay.TabIndex = 113
        Me.imgInsurtibleSiHay.TabStop = False
        Me.imgInsurtibleSiHay.Visible = False
        '
        'lblInsurtibleNumSiHay
        '
        Me.lblInsurtibleNumSiHay.BackColor = System.Drawing.Color.Transparent
        Me.lblInsurtibleNumSiHay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsurtibleNumSiHay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInsurtibleNumSiHay.Location = New System.Drawing.Point(152, 103)
        Me.lblInsurtibleNumSiHay.Name = "lblInsurtibleNumSiHay"
        Me.lblInsurtibleNumSiHay.Size = New System.Drawing.Size(48, 24)
        Me.lblInsurtibleNumSiHay.TabIndex = 112
        Me.lblInsurtibleNumSiHay.Text = "0"
        Me.lblInsurtibleNumSiHay.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblInsurtibleNumSiHay.Visible = False
        '
        'lblCancNumSiHay
        '
        Me.lblCancNumSiHay.BackColor = System.Drawing.Color.Transparent
        Me.lblCancNumSiHay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancNumSiHay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCancNumSiHay.Location = New System.Drawing.Point(168, 144)
        Me.lblCancNumSiHay.Name = "lblCancNumSiHay"
        Me.lblCancNumSiHay.Size = New System.Drawing.Size(32, 24)
        Me.lblCancNumSiHay.TabIndex = 107
        Me.lblCancNumSiHay.Text = "0"
        Me.lblCancNumSiHay.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblCancNumSiHay.Visible = False
        '
        'lblGuiaNumSiHay
        '
        Me.lblGuiaNumSiHay.BackColor = System.Drawing.Color.Transparent
        Me.lblGuiaNumSiHay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuiaNumSiHay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGuiaNumSiHay.Location = New System.Drawing.Point(160, 168)
        Me.lblGuiaNumSiHay.Name = "lblGuiaNumSiHay"
        Me.lblGuiaNumSiHay.Size = New System.Drawing.Size(40, 24)
        Me.lblGuiaNumSiHay.TabIndex = 105
        Me.lblGuiaNumSiHay.Text = "0"
        Me.lblGuiaNumSiHay.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblGuiaNumSiHay.Visible = False
        '
        'lblFacturarNumSiHay
        '
        Me.lblFacturarNumSiHay.BackColor = System.Drawing.Color.Transparent
        Me.lblFacturarNumSiHay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacturarNumSiHay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFacturarNumSiHay.Location = New System.Drawing.Point(168, 76)
        Me.lblFacturarNumSiHay.Name = "lblFacturarNumSiHay"
        Me.lblFacturarNumSiHay.Size = New System.Drawing.Size(32, 24)
        Me.lblFacturarNumSiHay.TabIndex = 103
        Me.lblFacturarNumSiHay.Text = "0"
        Me.lblFacturarNumSiHay.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblFacturarNumSiHay.Visible = False
        '
        'lblPedidoNumSurSiHay
        '
        Me.lblPedidoNumSurSiHay.BackColor = System.Drawing.Color.Transparent
        Me.lblPedidoNumSurSiHay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoNumSurSiHay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPedidoNumSurSiHay.Location = New System.Drawing.Point(160, 16)
        Me.lblPedidoNumSurSiHay.Name = "lblPedidoNumSurSiHay"
        Me.lblPedidoNumSurSiHay.Size = New System.Drawing.Size(40, 24)
        Me.lblPedidoNumSurSiHay.TabIndex = 101
        Me.lblPedidoNumSurSiHay.Text = "0"
        Me.lblPedidoNumSurSiHay.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblPedidoNumSurSiHay.Visible = False
        '
        'lblOcultarSiHay
        '
        Me.lblOcultarSiHay.AutoSize = True
        Me.lblOcultarSiHay.BackColor = System.Drawing.Color.Transparent
        Me.lblOcultarSiHay.Location = New System.Drawing.Point(96, 208)
        Me.lblOcultarSiHay.Name = "lblOcultarSiHay"
        Me.lblOcultarSiHay.Size = New System.Drawing.Size(41, 13)
        Me.lblOcultarSiHay.TabIndex = 92
        Me.lblOcultarSiHay.TabStop = True
        Me.lblOcultarSiHay.Text = "Ocultar"
        Me.lblOcultarSiHay.Visible = False
        '
        'imgCancSiHay
        '
        Me.imgCancSiHay.BackColor = System.Drawing.Color.Transparent
        Me.imgCancSiHay.Image = CType(resources.GetObject("imgCancSiHay.Image"), System.Drawing.Image)
        Me.imgCancSiHay.Location = New System.Drawing.Point(208, 140)
        Me.imgCancSiHay.Name = "imgCancSiHay"
        Me.imgCancSiHay.Size = New System.Drawing.Size(24, 24)
        Me.imgCancSiHay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCancSiHay.TabIndex = 99
        Me.imgCancSiHay.TabStop = False
        Me.imgCancSiHay.Visible = False
        '
        'imgGuiaSiHay
        '
        Me.imgGuiaSiHay.BackColor = System.Drawing.Color.Transparent
        Me.imgGuiaSiHay.Image = CType(resources.GetObject("imgGuiaSiHay.Image"), System.Drawing.Image)
        Me.imgGuiaSiHay.Location = New System.Drawing.Point(208, 168)
        Me.imgGuiaSiHay.Name = "imgGuiaSiHay"
        Me.imgGuiaSiHay.Size = New System.Drawing.Size(24, 24)
        Me.imgGuiaSiHay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgGuiaSiHay.TabIndex = 98
        Me.imgGuiaSiHay.TabStop = False
        Me.imgGuiaSiHay.Visible = False
        '
        'imgFacturarSinHay
        '
        Me.imgFacturarSinHay.BackColor = System.Drawing.Color.Transparent
        Me.imgFacturarSinHay.Image = CType(resources.GetObject("imgFacturarSinHay.Image"), System.Drawing.Image)
        Me.imgFacturarSinHay.Location = New System.Drawing.Point(208, 72)
        Me.imgFacturarSinHay.Name = "imgFacturarSinHay"
        Me.imgFacturarSinHay.Size = New System.Drawing.Size(24, 24)
        Me.imgFacturarSinHay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgFacturarSinHay.TabIndex = 97
        Me.imgFacturarSinHay.TabStop = False
        Me.imgFacturarSinHay.Visible = False
        '
        'imgSurtirSiHay
        '
        Me.imgSurtirSiHay.BackColor = System.Drawing.Color.Transparent
        Me.imgSurtirSiHay.Image = CType(resources.GetObject("imgSurtirSiHay.Image"), System.Drawing.Image)
        Me.imgSurtirSiHay.Location = New System.Drawing.Point(208, 12)
        Me.imgSurtirSiHay.Name = "imgSurtirSiHay"
        Me.imgSurtirSiHay.Size = New System.Drawing.Size(24, 24)
        Me.imgSurtirSiHay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgSurtirSiHay.TabIndex = 96
        Me.imgSurtirSiHay.TabStop = False
        Me.imgSurtirSiHay.Visible = False
        '
        'panelFondo
        '
        Me.panelFondo.CaptionVisible = Janus.Windows.UI.InheritableBoolean.[False]
        Me.panelFondo.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.[False]
        Me.panelFondo.InnerContainer = Me.panelFondoContainer
        Me.panelFondo.Location = New System.Drawing.Point(272, 3)
        Me.panelFondo.Name = "panelFondo"
        Me.panelFondo.Size = New System.Drawing.Size(837, 410)
        Me.panelFondo.TabIndex = 4
        '
        'panelFondoContainer
        '
        Me.panelFondoContainer.BackColor = System.Drawing.Color.White
        Me.panelFondoContainer.Controls.Add(Me.GridMetasPlayers)
        Me.panelFondoContainer.Controls.Add(Me.Panel4)
        Me.panelFondoContainer.Controls.Add(Me.Label1)
        Me.panelFondoContainer.Controls.Add(Me.Label24)
        Me.panelFondoContainer.Controls.Add(Me.pbFondo)
        Me.panelFondoContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelFondoContainer.Location = New System.Drawing.Point(1, 1)
        Me.panelFondoContainer.Name = "panelFondoContainer"
        Me.panelFondoContainer.Size = New System.Drawing.Size(835, 408)
        Me.panelFondoContainer.TabIndex = 0
        '
        'GridMetasPlayers
        '
        Me.GridMetasPlayers.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMetasPlayers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMetasPlayers.BackColor = System.Drawing.Color.Black
        Me.GridMetasPlayers.BackgroundImageDrawMode = Janus.Windows.GridEX.BackgroundImageDrawMode.Tile
        Me.GridMetasPlayers.BorderStyle = Janus.Windows.GridEX.BorderStyle.None
        Me.GridMetasPlayers.DataMember = Nothing
        Me.GridMetasPlayers.DefaultAlphaLevel = 0
        Me.GridMetasPlayers.DefaultBackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.UseAlpha
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GridMetasPlayers.DesignTimeLayout = GridEXLayout1
        Me.GridMetasPlayers.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridMetasPlayers.FlatBorderColor = System.Drawing.SystemColors.ControlDark
        Me.GridMetasPlayers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GridMetasPlayers.GridLines = Janus.Windows.GridEX.GridLines.None
        Me.GridMetasPlayers.GroupByBoxVisible = False
        Me.GridMetasPlayers.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Empty
        Me.GridMetasPlayers.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridMetasPlayers.HeaderFormatStyle.ForeColor = System.Drawing.Color.Yellow
        Me.GridMetasPlayers.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.GridMetasPlayers.Location = New System.Drawing.Point(0, 248)
        Me.GridMetasPlayers.Name = "GridMetasPlayers"
        Me.GridMetasPlayers.Size = New System.Drawing.Size(836, 160)
        Me.GridMetasPlayers.TabIndex = 106
        Me.GridMetasPlayers.TabStop = False
        Me.GridMetasPlayers.ThemedAreas = CType((((((Janus.Windows.GridEX.ThemedArea.ScrollBars Or Janus.Windows.GridEX.ThemedArea.EditControls) _
                    Or Janus.Windows.GridEX.ThemedArea.GroupByBox) _
                    Or Janus.Windows.GridEX.ThemedArea.TreeGliphs) _
                    Or Janus.Windows.GridEX.ThemedArea.GroupRows) _
                    Or Janus.Windows.GridEX.ThemedArea.ControlBorder), Janus.Windows.GridEX.ThemedArea)
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(835, 248)
        Me.Panel4.TabIndex = 105
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.txtMetaDiaria)
        Me.Panel1.Controls.Add(Me.txtAPV)
        Me.Panel1.Controls.Add(Me.lblMetaDiaria)
        Me.Panel1.Controls.Add(Me.lblAPV)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 248)
        Me.Panel1.TabIndex = 106
        '
        'txtMetaDiaria
        '
        Me.txtMetaDiaria.BackColor = System.Drawing.Color.Transparent
        Me.txtMetaDiaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMetaDiaria.ForeColor = System.Drawing.Color.Red
        Me.txtMetaDiaria.Location = New System.Drawing.Point(32, 176)
        Me.txtMetaDiaria.Name = "txtMetaDiaria"
        Me.txtMetaDiaria.Size = New System.Drawing.Size(160, 27)
        Me.txtMetaDiaria.TabIndex = 104
        Me.txtMetaDiaria.Text = "0.00"
        Me.txtMetaDiaria.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtAPV
        '
        Me.txtAPV.BackColor = System.Drawing.Color.Transparent
        Me.txtAPV.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAPV.ForeColor = System.Drawing.Color.Yellow
        Me.txtAPV.Location = New System.Drawing.Point(32, 88)
        Me.txtAPV.Name = "txtAPV"
        Me.txtAPV.Size = New System.Drawing.Size(160, 27)
        Me.txtAPV.TabIndex = 103
        Me.txtAPV.Text = "0.00"
        Me.txtAPV.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMetaDiaria
        '
        Me.lblMetaDiaria.AutoSize = True
        Me.lblMetaDiaria.BackColor = System.Drawing.Color.Transparent
        Me.lblMetaDiaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMetaDiaria.ForeColor = System.Drawing.Color.White
        Me.lblMetaDiaria.Location = New System.Drawing.Point(40, 136)
        Me.lblMetaDiaria.Name = "lblMetaDiaria"
        Me.lblMetaDiaria.Size = New System.Drawing.Size(145, 25)
        Me.lblMetaDiaria.TabIndex = 102
        Me.lblMetaDiaria.Text = "Meta del Día"
        '
        'lblAPV
        '
        Me.lblAPV.AutoSize = True
        Me.lblAPV.BackColor = System.Drawing.Color.Transparent
        Me.lblAPV.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAPV.ForeColor = System.Drawing.Color.White
        Me.lblAPV.Location = New System.Drawing.Point(80, 48)
        Me.lblAPV.Name = "lblAPV"
        Me.lblAPV.Size = New System.Drawing.Size(57, 25)
        Me.lblAPV.TabIndex = 101
        Me.lblAPV.Text = "APV"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Controls.Add(Me.txtCantidadRestante)
        Me.Panel3.Controls.Add(Me.txtVentasXPromedio)
        Me.Panel3.Controls.Add(Me.lblCantidadRestante)
        Me.Panel3.Controls.Add(Me.lblVentasPromedio)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(587, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(248, 248)
        Me.Panel3.TabIndex = 107
        '
        'txtCantidadRestante
        '
        Me.txtCantidadRestante.BackColor = System.Drawing.Color.Transparent
        Me.txtCantidadRestante.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadRestante.ForeColor = System.Drawing.Color.Red
        Me.txtCantidadRestante.Location = New System.Drawing.Point(32, 176)
        Me.txtCantidadRestante.Name = "txtCantidadRestante"
        Me.txtCantidadRestante.Size = New System.Drawing.Size(160, 27)
        Me.txtCantidadRestante.TabIndex = 106
        Me.txtCantidadRestante.Text = "0.00"
        Me.txtCantidadRestante.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtVentasXPromedio
        '
        Me.txtVentasXPromedio.BackColor = System.Drawing.Color.Transparent
        Me.txtVentasXPromedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentasXPromedio.ForeColor = System.Drawing.Color.Yellow
        Me.txtVentasXPromedio.Location = New System.Drawing.Point(32, 88)
        Me.txtVentasXPromedio.Name = "txtVentasXPromedio"
        Me.txtVentasXPromedio.Size = New System.Drawing.Size(160, 27)
        Me.txtVentasXPromedio.TabIndex = 105
        Me.txtVentasXPromedio.Text = "0.00"
        Me.txtVentasXPromedio.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCantidadRestante
        '
        Me.lblCantidadRestante.AutoSize = True
        Me.lblCantidadRestante.BackColor = System.Drawing.Color.Transparent
        Me.lblCantidadRestante.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadRestante.ForeColor = System.Drawing.Color.White
        Me.lblCantidadRestante.Location = New System.Drawing.Point(64, 136)
        Me.lblCantidadRestante.Name = "lblCantidadRestante"
        Me.lblCantidadRestante.Size = New System.Drawing.Size(113, 25)
        Me.lblCantidadRestante.TabIndex = 104
        Me.lblCantidadRestante.Text = "Nos Falta"
        '
        'lblVentasPromedio
        '
        Me.lblVentasPromedio.AutoSize = True
        Me.lblVentasPromedio.BackColor = System.Drawing.Color.Transparent
        Me.lblVentasPromedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentasPromedio.ForeColor = System.Drawing.Color.White
        Me.lblVentasPromedio.Location = New System.Drawing.Point(16, 48)
        Me.lblVentasPromedio.Name = "lblVentasPromedio"
        Me.lblVentasPromedio.Size = New System.Drawing.Size(191, 25)
        Me.lblVentasPromedio.TabIndex = 103
        Me.lblVentasPromedio.Text = "Ventas Promedio"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtVentasDia)
        Me.Panel2.Controls.Add(Me.txtCteXAtender)
        Me.Panel2.Controls.Add(Me.lblMarkerTienda)
        Me.Panel2.Controls.Add(Me.lblVentasDia)
        Me.Panel2.Controls.Add(Me.lblClientesXAtender)
        Me.Panel2.Location = New System.Drawing.Point(226, -24)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(312, 328)
        Me.Panel2.TabIndex = 105
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gold
        Me.Label2.Location = New System.Drawing.Point(72, 240)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 25)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Marker Player"
        '
        'txtVentasDia
        '
        Me.txtVentasDia.BackColor = System.Drawing.Color.Transparent
        Me.txtVentasDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentasDia.ForeColor = System.Drawing.Color.Red
        Me.txtVentasDia.Location = New System.Drawing.Point(72, 200)
        Me.txtVentasDia.Name = "txtVentasDia"
        Me.txtVentasDia.Size = New System.Drawing.Size(160, 27)
        Me.txtVentasDia.TabIndex = 107
        Me.txtVentasDia.Text = "0.00"
        Me.txtVentasDia.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCteXAtender
        '
        Me.txtCteXAtender.BackColor = System.Drawing.Color.Transparent
        Me.txtCteXAtender.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCteXAtender.ForeColor = System.Drawing.Color.Red
        Me.txtCteXAtender.Location = New System.Drawing.Point(72, 112)
        Me.txtCteXAtender.Name = "txtCteXAtender"
        Me.txtCteXAtender.Size = New System.Drawing.Size(160, 27)
        Me.txtCteXAtender.TabIndex = 106
        Me.txtCteXAtender.Text = "0.00"
        Me.txtCteXAtender.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMarkerTienda
        '
        Me.lblMarkerTienda.AutoSize = True
        Me.lblMarkerTienda.BackColor = System.Drawing.Color.Transparent
        Me.lblMarkerTienda.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarkerTienda.ForeColor = System.Drawing.Color.Gold
        Me.lblMarkerTienda.Location = New System.Drawing.Point(76, 30)
        Me.lblMarkerTienda.Name = "lblMarkerTienda"
        Me.lblMarkerTienda.Size = New System.Drawing.Size(164, 25)
        Me.lblMarkerTienda.TabIndex = 104
        Me.lblMarkerTienda.Text = "Marker Tienda"
        '
        'lblVentasDia
        '
        Me.lblVentasDia.AutoSize = True
        Me.lblVentasDia.BackColor = System.Drawing.Color.Transparent
        Me.lblVentasDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentasDia.ForeColor = System.Drawing.Color.White
        Me.lblVentasDia.Location = New System.Drawing.Point(104, 160)
        Me.lblVentasDia.Name = "lblVentasDia"
        Me.lblVentasDia.Size = New System.Drawing.Size(112, 25)
        Me.lblVentasDia.TabIndex = 103
        Me.lblVentasDia.Text = "Llevamos"
        '
        'lblClientesXAtender
        '
        Me.lblClientesXAtender.AutoSize = True
        Me.lblClientesXAtender.BackColor = System.Drawing.Color.Transparent
        Me.lblClientesXAtender.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientesXAtender.ForeColor = System.Drawing.Color.White
        Me.lblClientesXAtender.Location = New System.Drawing.Point(48, 72)
        Me.lblClientesXAtender.Name = "lblClientesXAtender"
        Me.lblClientesXAtender.Size = New System.Drawing.Size(228, 25)
        Me.lblClientesXAtender.TabIndex = 102
        Me.lblClientesXAtender.Text = "Clientes por Atender"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(224, 328)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(496, 24)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "MARTES, 23 DE AGOSTO DE 2005"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Label1.Visible = False
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(749, 280)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(368, 24)
        Me.Label24.TabIndex = 80
        Me.Label24.Text = "MARTES, 23 DE AGOSTO DE 2005"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Label24.Visible = False
        '
        'pbFondo
        '
        Me.pbFondo.Location = New System.Drawing.Point(680, 32)
        Me.pbFondo.Name = "pbFondo"
        Me.pbFondo.Size = New System.Drawing.Size(160, 128)
        Me.pbFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbFondo.TabIndex = 81
        Me.pbFondo.TabStop = False
        Me.pbFondo.Visible = False
        '
        'Timer3
        '
        Me.Timer3.Interval = 500.0R
        Me.Timer3.SynchronizingObject = Me
        '
        'HomeDash
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pbBottom)
        Me.Controls.Add(Me.picPictureBox1)
        Me.Controls.Add(Me.panelFondo)
        Me.Controls.Add(Me.pnlAvisos)
        Me.Name = "HomeDash"
        Me.Size = New System.Drawing.Size(1112, 416)
        CType(Me.picPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBottom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.timer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.timer2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiPanelManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlAvisos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAvisos.ResumeLayout(False)
        CType(Me.pnlInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInicio.ResumeLayout(False)
        Me.pnlInicioContainer.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.expPromoVigentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expPromoVigentes.ResumeLayout(False)
        CType(Me.grdPromoVigentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.expManagerPC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expManagerPC.ResumeLayout(False)
        CType(Me.explorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar2.ResumeLayout(False)
        CType(Me.pnlPedidosEC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPedidosEC.ResumeLayout(False)
        Me.pnlPedidosECContainer.ResumeLayout(False)
        CType(Me.expEcommerce, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expEcommerce.ResumeLayout(False)
        Me.expEcommerce.PerformLayout()
        CType(Me.pbPedidosCancelados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbGuiasPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPedidosFacturar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPedidosPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPedidosSH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPedidosSH.ResumeLayout(False)
        Me.pnlPedidosSHContainer.ResumeLayout(False)
        CType(Me.expPedidosSiHay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expPedidosSiHay.ResumeLayout(False)
        Me.expPedidosSiHay.PerformLayout()
        CType(Me.imgRecibirSiHay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgInsurtibleSiHay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCancSiHay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgGuiaSiHay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFacturarSinHay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgSurtirSiHay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelFondo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelFondo.ResumeLayout(False)
        Me.panelFondoContainer.ResumeLayout(False)
        CType(Me.GridMetasPlayers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbFondo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Timer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oSAPMgr As ProcesoSAPManager
    '------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/04/2014: Variables de Metas diarias
    '------------------------------------------------------------------------------------------------------------
    Private dtMetasPlayer As DataTable
    Private metadia As MetasDia
    Private webService As WSBroker

    'Dim Pedidos As Integer, Facturas As Integer, Guias As Integer, Cancelados As Integer = 0

    Private Sub HomeDash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '--------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 19/05/2014: Validación para mostrar ScoreBoard
        '--------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.ScoreBoard Then
            pbFondo.Visible = False
            Panel4.Visible = True
            GridMetasPlayers.Visible = True
            InitializeMetas()
        Else
            pbFondo.Visible = True
            Panel4.Visible = False
            GridMetasPlayers.Visible = False
            GetImageFromInternet()
        End If

        Label1.Text = UCase(Now.ToLongDateString)

        'lblTraspasosP.Text = sm_TraspasosPendientes()

        lblTraspasosP.Text = "0"

        lblContratoV.Text = sm_ContratosVencidos()

        'LblMandante.Text = oAppSAPConfig.Client & " " & oAppSAPConfig.GroupName.ToUpper

        'Me.LblBD.Text = oAppContext.ApplicationConfiguration.DataStorageConfiguration.Database.ToUpper

        'Me.LblServer.Text = oAppContext.ApplicationConfiguration.DataStorageConfiguration.Server.ToUpper

        'Me.LblWebservice.Text = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/"

        If oConfigCierreFI.ShowManagerPC = False Then Me.expManagerPC.Visible = False

        'ActualizarPedidosEC()

        'timer1.Interval = (oConfigCierreFI.TiempoRevisaPedidos * 60) * 1000
        'timer2.Interval = 60000
        'timer1.Interval = 500

        '-------------------------------------------------------------------------------------------------------------
        'RGERMAIN 16/05/2013: Revisamos si participa en el Si Hay
        '-------------------------------------------------------------------------------------------------------------
        ParticipaEnSH()

        If oConfigCierreFI.SurtirEcommerce OrElse FacturacionSiHay > 0 Then Me.timer1.Start()

        If oConfigCierreFI.SurtirEcommerce = False Then
            '    timer1.Start()
            'Else
            'Me.grpEcommerce.Visible = False
            'Me.btnPedidosPendientes.Visible = False
            Me.pnlAvisos.Panels.Remove(Me.pnlPedidosEC)
            'Me.expManagerPC.Left = 0
            'Me.expManagerPC.Top = 64
        End If
        '------------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN: Validamos la promociones vigentes en el cross selling que estan activas si esta activa la config
        '------------------------------------------------------------------------------------------------------------------------------------------------

        If oConfigCierreFI.AplicaCrossSelling Then
            Dim dtPromosVig As DataTable, fecha As String = ""

            '--------------------------------------------------------------------------------------
            ' JNAVA (28.12.2015): Adaptacion para SAP RETAIL
            '--------------------------------------------------------------------------------------
            'oSAPMgr.ZCS_PROMO_VIGENTES(Today, dtPromosVig)
            Dim oRetail As New ProcesosRetail("/pos/cs", "POST")
            oRetail.SapZcsPromoVigentes(Today, "T" & oAppContext.ApplicationConfiguration.Almacen, dtPromosVig).Copy()
            '--------------------------------------------------------------------------------------
            For Each orow As DataRow In dtPromosVig.Rows
                fecha = CStr(orow!fin_Validez).Trim
                fecha = fecha.Substring(8, 2) & "/" & fecha.Substring(5, 2) & "/" & fecha.Substring(0, 4)
                orow!fin_validez = fecha.Trim
                orow!ID = CLng(orow!ID)
            Next

            Me.grdPromoVigentes.DataSource = dtPromosVig
        Else
            Me.expPromoVigentes.Visible = False
        End If

        '-------------------------------------------------------------
        ' JNAVA (04.09.2017): Liberar RAM usada por el PRO (Basura)
        '-------------------------------------------------------------
        If oConfigCierreFI.FreeRAM Then
            Timer3.Stop()
            Timer3.Interval = (oConfigCierreFI.TimeFreeRAM * 60) * 1000
            Timer3.Start()
        End If
        '-------------------------------------------------------------


    End Sub

    'Private Sub ActualizarPedidosEC()

    '    'timer1.Stop()
    '    'timer2.Stop()

    '    'GetPedidosPendientesEC() 'Pedidos, Facturas, Guias)
    '    RefreshPedidosEC()

    '    Me.lblPedidosPendientes.Text = gPedidos
    '    Me.lblPedidosFacturar.Text = gFacturas
    '    Me.lblGuiasPendientes.Text = gGuias
    '    Me.lblPedidosCancelados.Text = gCancelados

    '    'Application.DoEvents()

    '    Me.pbPedidosPendientes.Visible = False
    '    Me.pbPedidosFacturar.Visible = False
    '    Me.pbGuiasPendientes.Visible = False
    '    Me.pbPedidosCancelados.Visible = False

    '    'Me.pbPedidosPendientes.Enabled = IIf(Pedidos > 0, True, False)
    '    'Me.pbPedidosFacturar.Enabled = IIf(Facturas > 0, True, False)
    '    'Me.pbGuiasPendientes.Enabled = IIf(Guias > 0, True, False)
    '    'Me.pbPedidosCancelados.Enabled = IIf(Cancelados > 0, True, False)

    '    'If timer2.Enabled = False Then timer2.Enabled = True

    '    'If Pedidos > 0 OrElse Facturas > 0 OrElse Guias > 0 Then
    '    '    timer2.Enabled = True
    '    'Else
    '    '    timer2.Enabled = False
    '    'End If
    '    'timer1.Interval = (oConfigCierreFI.TiempoRevisaPedidos * 60) * 1000
    '    'timer1.Enabled = True
    '    'timer1.Start()
    '    'timer2.Start()

    'End Sub

    'Private Sub GetPedidosPendientes() 'ByRef Pedidos As Integer, ByRef Facturas As Integer, ByRef Guias As Integer)

    '    Dim strCentro As String = oSAPMgr.Read_Centros
    '    Dim dtPedidosDet As DataTable
    '    Dim dtPedidos As DataTable = oSAPMgr.ZPOL_TRASLPEN(strCentro, dtPedidosDet)
    '    Dim oRow As DataRow

    '    Pedidos = 0
    '    Facturas = 0
    '    Guias = 0
    '    Cancelados = 0

    '    '--------------------------------------------------------------------------------------------------------------------------------------
    '    'Consultamos los pedidos pendientes por surtir y facturar solicitados por Ecommerce
    '    '--------------------------------------------------------------------------------------------------------------------------------------
    '    If Not dtPedidos Is Nothing AndAlso dtPedidos.Rows.Count > 0 Then
    '        For Each oRow In dtPedidos.Rows
    '            If CStr(oRow!Status) = "P" Then
    '                Pedidos += 1
    '            ElseIf CStr(oRow!Facturar).Trim = "X" Then
    '                Facturas += 1
    '            End If
    '        Next
    '    End If
    '    '--------------------------------------------------------------------------------------------------------------------------------------
    '    'Consultamos los pedidos pendientes por enviar solicitados por Ecommerce
    '    '--------------------------------------------------------------------------------------------------------------------------------------
    '    dtPedidos = oSAPMgr.ZPOL_VALIDA_TRAS_ENV(strCentro)

    '    If Not dtPedidos Is Nothing AndAlso dtPedidos.Rows.Count > 0 Then
    '        For Each oRow In dtPedidos.Rows
    '            If (CStr(oRow!Facturar).Trim = "X" AndAlso CStr(oRow!Folio_Factura).Trim <> "") OrElse (CStr(oRow!Facturar).Trim = "" AndAlso CStr(oRow!PuestoExpedicion).Trim <> "") Then
    '                Guias += 1
    '            End If
    '        Next
    '        'Guias = dtPedidos.Rows.Count
    '    End If
    '    '--------------------------------------------------------------------------------------------------------------------------------------
    '    'Consultamos los pedidos cancelados solicitados por Ecommerce
    '    '--------------------------------------------------------------------------------------------------------------------------------------
    '    dtPedidos = Nothing
    '    dtPedidos = oSAPMgr.ZPOL_PEDIDOSCANCELADOS(dtPedidosDet, strCentro)

    '    If Not dtPedidos Is Nothing Then 'AndAlso dtPedidos.Rows.Count > 0 Then
    '        Cancelados = dtPedidos.Rows.Count
    '    End If

    'End Sub

    Private Function sm_TraspasosPendientes() As Integer

        Dim result As Integer = 0

        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        Dim dt As DataTable = oSap.Read_TraspasosEspera(Date.Today.AddDays(-1), Date.Today, "", "S", oConfigCierreFI.RecibirParcialmente) 'Para que salgan todos

        If Not dt Is Nothing Then
            If (dt.Rows.Count = 0) Then
                result = 0
            Else
                result = dt.Rows.Count
            End If
        End If

        Return result

    End Function

    Private Function sm_ContratosVencidos() As Integer

        Dim dsContratosVencidos As New DataSet
        Dim oContratoMgr As New ContratoManager(oAppContext)

        Dim result As Integer = 0

        dsContratosVencidos = oContratoMgr.ContratosVencidosSel

        If Not dsContratosVencidos Is Nothing Then

            result = dsContratosVencidos.Tables(0).Rows.Count

        Else

            result = 0

        End If

        oContratoMgr = Nothing

        Return result

    End Function

    Private Function GetNamePath(ByVal imagen As String) As String
        Dim index As Integer = imagen.LastIndexOf("/")
        Dim name As String = ""
        If index <> -1 Then
            name = imagen.Substring(index + 1)
        End If
        Return name
    End Function

    Private Function GetImageFromInternet()
        Try
            Dim strFileName As String = GetNamePath(oConfigCierreFI.ImagenFondoURL)
            Dim strRutaLocal As String = Application.StartupPath.TrimEnd("\")
            Dim strDefault As String = strRutaLocal & "\Default.jpg"

            If Not oSAPMgr.IsDownloadBackground(oConfigCierreFI, oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja) Then
                Dim wr As HttpWebRequest = CType(HttpWebRequest.Create(oConfigCierreFI.ImagenFondoURL), HttpWebRequest)
                '-----------------------------------------------------------------------------------------------------------------------------------
                'Le asignamos las credenciales del proxy en caso de estar configurado
                '-----------------------------------------------------------------------------------------------------------------------------------
                If Not WebProxy.GetDefaultProxy.Address Is Nothing Then
                    Dim cr As New NetworkCredential(oConfigCierreFI.UserProxy, oConfigCierreFI.PasswordProxy)
                    Dim proxy As New WebProxy(WebProxy.GetDefaultProxy.Address.Host, WebProxy.GetDefaultProxy.Address.Port)
                    proxy.Credentials = cr
                    wr.Proxy = proxy
                End If
                '--------------------------------------------------------------------------------------------------------------------------------
                'Intentamos acceder al archivo en la ruta de internet configurada
                '--------------------------------------------------------------------------------------------------------------------------------
                Try
                    Dim ws As HttpWebResponse = CType(wr.GetResponse, HttpWebResponse)
                    Dim str As Stream = ws.GetResponseStream()
                    Dim inBuf(5000000) As Byte
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
                    '-----------------------------------------------------------------------------------------------------------------------------
                    'CREATE A MEMORY STREAM USING THE BYTES
                    '-----------------------------------------------------------------------------------------------------------------------------
                    Dim ImageStream As New IO.MemoryStream(inBuf)
                    '----------------------------------------------------------------------------------------------------------------------------------
                    'CREATE A BITMAP FROM THE MEMORY STREAM
                    '----------------------------------------------------------------------------------------------------------------------------------
                    Me.pbFondo.Image = New System.Drawing.Bitmap(ImageStream)
                    Me.pbFondo.Dock = DockStyle.Fill
                    Me.pbFondo.Visible = True
                    'If strFileName <> "" Then
                    'Me.pbFondo.Image.Save(strRutaLocal & "\" & strFileName)
                    'Else
                    '    Me.pbFondo.Image.Save(strDefault)
                    'End If
                    oSAPMgr.SaveDownloadBackground(oConfigCierreFI, oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja)
                    'AS U SEE, NO FILE NEEDS TO BE WRITTEN TO THE HARD DRIVE, ITS ALL DONE IN MEMORY
                Catch ex As Exception
                    '---------------------------------------------------------------------------------------------------------------------------
                    'Si obtenemos algun error y no es posible realizar la descarga entonces intentamos cargar la imagen por default
                    '---------------------------------------------------------------------------------------------------------------------------
                    EscribeLog(ex.ToString, "Error al descargar la imagen de fondo")
                    If File.Exists(strDefault) Then GoTo DefaultImg
                End Try

            Else
                If strFileName <> "" Then
                    If File.Exists(strRutaLocal & "\" & strFileName) Then
                        Me.pbFondo.Image = Image.FromFile(strRutaLocal & "\" & strFileName)
                        Me.pbFondo.Dock = DockStyle.Fill
                        Me.pbFondo.Visible = True
                    Else
                        GoTo DefaultImg
                    End If
                Else
DefaultImg:
                    Me.pbFondo.Image = Image.FromFile(strDefault)
                    Me.pbFondo.Dock = DockStyle.Fill
                    Me.pbFondo.Visible = True
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al descargar la imagen de fondo")
        End Try

    End Function

    Private Sub timer2_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timer2.Elapsed

        If oConfigCierreFI.SurtirEcommerce Then
            'Me.lblPedidosGuiasNum.Text = gGuias
            'If gGuias > 0 Then
            '    If Me.pbGuiasPendientes.Visible = False Then
            '        Me.pbGuiasPendientes.Visible = True
            '    Else
            '        Me.pbGuiasPendientes.Visible = False
            '    End If
            '    Me.lblPedidosGuias.ForeColor = Color.Red
            '    Me.lblPedidosGuiasNum.ForeColor = Color.Red
            'Else
            '    Me.lblPedidosGuias.ForeColor = SystemColors.ControlText
            '    Me.lblPedidosGuiasNum.ForeColor = SystemColors.ControlText
            '    Me.pbGuiasPendientes.Visible = False
            'End If
            '----------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (11.03.2016): Comentado por que ya no se usara por adecuacionesa  retail
            '----------------------------------------------------------------------------------------------------------------------------------
            'Me.lblPedidosFacturarNum.Text = gFacturas
            'If gFacturas > 0 Then
            '    If Me.pbPedidosFacturar.Visible = False Then
            '        Me.pbPedidosFacturar.Visible = True
            '    Else
            '        Me.pbPedidosFacturar.Visible = False
            '    End If
            '    Me.lblPedidosFacturar.ForeColor = Color.Red
            '    Me.lblPedidosFacturarNum.ForeColor = Color.Red
            'Else
            '    Me.lblPedidosFacturar.ForeColor = SystemColors.ControlText
            '    Me.lblPedidosFacturarNum.ForeColor = SystemColors.ControlText
            '    Me.pbPedidosFacturar.Visible = False
            'End If

            Me.lblPedidosSurtirNum.Text = gPedidos
            If gPedidos > 0 Then
                If Me.pbPedidosPendientes.Visible = False Then
                    Me.pbPedidosPendientes.Visible = True
                Else
                    Me.pbPedidosPendientes.Visible = False
                End If
                Me.lblPedidosSurtir.ForeColor = Color.Red
                Me.lblPedidosSurtirNum.ForeColor = Color.Red
            Else
                Me.lblPedidosSurtir.ForeColor = SystemColors.ControlText
                Me.lblPedidosSurtirNum.ForeColor = SystemColors.ControlText
                Me.pbPedidosPendientes.Visible = False
            End If

            '----------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (11.03.2016): Comentado por que ya no se usara por adecuacionesa  retail
            '----------------------------------------------------------------------------------------------------------------------------------
            'Me.lblPedidosCancelNum.Text = gCancelados
            'If gCancelados > 0 Then
            '    If Me.pbPedidosCancelados.Visible = False Then
            '        Me.pbPedidosCancelados.Visible = True
            '    Else
            '        Me.pbPedidosCancelados.Visible = False
            '    End If
            '    Me.lblPedidosCancel.ForeColor = Color.Red
            '    Me.lblPedidosCancelNum.ForeColor = Color.Red
            'Else
            '    Me.lblPedidosCancel.ForeColor = SystemColors.ControlText
            '    Me.lblPedidosCancelNum.ForeColor = SystemColors.ControlText
            '    Me.pbPedidosCancelados.Visible = False
            'End If

            If gCancelados > 0 OrElse gPedidos > 0 OrElse gFacturas > 0 OrElse gGuias > 0 Then
                '----------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 16/05/2013: Adecuamos los avisos del EC al nuevo panel
                '----------------------------------------------------------------------------------------------------------------------------------
                If Me.pnlPedidosEC.TabStateStyles.FormatStyle.ForeColor.ToString = Color.Red.ToString Then
                    Me.pnlPedidosEC.TabStateStyles.FormatStyle.ForeColor = SystemColors.ControlText
                Else
                    Me.pnlPedidosEC.TabStateStyles.FormatStyle.ForeColor = Color.Red
                End If
            Else
                Me.pnlPedidosEC.TabStateStyles.FormatStyle.ForeColor = SystemColors.ControlText
            End If
        End If

        If FacturacionSiHay > 0 Then
            '----------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 11/04/2013: Se muestran los pendientes por surtir, facturar, dar guia, recibir,cancelar e insurtibles de los pedidos
            '----------------------------------------------------------------------------------------------------------------------------------
            lblPedidoNumSurSiHay.Text = CStr(surtirSihay)
            Select Case FacturacionSiHay
                Case 2, 3
                    lblPedidoSurtidoSiHay.Visible = True
                    lblPedidoNumSurSiHay.Visible = True
                    If surtirSihay > 0 Then
                        If Me.imgSurtirSiHay.Visible = False Then
                            Me.imgSurtirSiHay.Visible = True
                        Else
                            Me.imgSurtirSiHay.Visible = False
                        End If
                        lblPedidoSurtidoSiHay.ForeColor = Color.Red
                        lblPedidoNumSurSiHay.ForeColor = Color.Red
                    Else
                        lblPedidoSurtidoSiHay.ForeColor = SystemColors.ControlText
                        lblPedidoNumSurSiHay.ForeColor = SystemColors.ControlText
                        Me.imgSurtirSiHay.Visible = False
                    End If
            End Select

            'lblGuiaNumSiHay.Text = CStr(sinGuiaSiHay)
            'Select Case FacturacionSiHay
            '    Case 2, 3
            '        lblGuiaNumSiHay.Visible = True
            '        lblGuiaSiHay.Visible = True
            '        If sinGuiaSiHay > 0 Then
            '            If Me.imgGuiaSiHay.Visible = False Then
            '                Me.imgGuiaSiHay.Visible = True
            '            Else
            '                Me.imgGuiaSiHay.Visible = False
            '            End If
            '            lblGuiaNumSiHay.ForeColor = Color.Red
            '            lblGuiaSiHay.ForeColor = Color.Red
            '        Else
            '            lblGuiaNumSiHay.ForeColor = SystemColors.ControlText
            '            lblGuiaSiHay.ForeColor = SystemColors.ControlText
            '            Me.imgGuiaSiHay.Visible = False
            '        End If
            'End Select

            lblRecibirNumSiHay.Text = CStr(recibirSiHay)

            Select Case FacturacionSiHay
                Case 1, 3
                    lblRecibirNumSiHay.Visible = True
                    lblPedidosPorRecibir.Visible = True
                    If recibirSiHay > 0 Then
                        If Me.imgRecibirSiHay.Visible = False Then
                            Me.imgRecibirSiHay.Visible = True
                        Else
                            Me.imgRecibirSiHay.Visible = False
                        End If
                        Me.lblRecibirNumSiHay.ForeColor = Color.Red
                        Me.lblPedidosPorRecibir.ForeColor = Color.Red
                    Else
                        Me.lblRecibirNumSiHay.ForeColor = SystemColors.ControlText
                        Me.lblPedidosPorRecibir.ForeColor = SystemColors.ControlText
                        Me.imgRecibirSiHay.Visible = False
                    End If
            End Select

            lblFacturarNumSiHay.Text = CStr(facturarSiHay)
            Select Case FacturacionSiHay
                Case 1, 3
                    lblFacturarNumSiHay.Visible = True
                    lblPedidoFacturarSiHay.Visible = True
                    If facturarSiHay > 0 Then
                        If Me.imgFacturarSinHay.Visible = False Then
                            Me.imgFacturarSinHay.Visible = True
                        Else
                            Me.imgFacturarSinHay.Visible = False
                        End If
                        lblFacturarNumSiHay.ForeColor = Color.Red
                        lblPedidoFacturarSiHay.ForeColor = Color.Red
                    Else
                        lblFacturarNumSiHay.ForeColor = SystemColors.ControlText
                        lblPedidoFacturarSiHay.ForeColor = SystemColors.ControlText
                        Me.imgFacturarSinHay.Visible = False
                    End If
            End Select

            'lblCancNumSiHay.Text = CStr(canceladoSiHay)
            'Select Case FacturacionSiHay
            '    Case 2, 3
            '        lblCancSiHay.Visible = True
            '        lblCancNumSiHay.Visible = True
            '        If canceladoSiHay > 0 Then
            '            If imgCancSiHay.Visible = False Then
            '                imgCancSiHay.Visible = True
            '            Else
            '                imgCancSiHay.Visible = False
            '            End If
            '            lblCancNumSiHay.ForeColor = Color.Red
            '            lblCancSiHay.ForeColor = Color.Red
            '        Else
            '            lblCancNumSiHay.ForeColor = SystemColors.ControlText
            '            lblCancSiHay.ForeColor = SystemColors.ControlText
            '            imgCancSiHay.Visible = False
            '        End If
            'End Select

            lblInsurtibleNumSiHay.Text = CStr(insurtiblesSiHay)

            Select Case FacturacionSiHay
                Case 1, 3
                    lblPedidosInsurtibles.Visible = True
                    lblInsurtibleNumSiHay.Visible = True
                    If insurtiblesSiHay > 0 Then
                        If imgInsurtibleSiHay.Visible = False Then
                            imgInsurtibleSiHay.Visible = True
                        Else
                            imgInsurtibleSiHay.Visible = False
                        End If
                        lblPedidosInsurtibles.ForeColor = Color.Red
                        lblInsurtibleNumSiHay.ForeColor = Color.Red
                    Else
                        lblPedidosInsurtibles.ForeColor = SystemColors.ControlText
                        lblInsurtibleNumSiHay.ForeColor = SystemColors.ControlText
                        imgInsurtibleSiHay.Visible = False
                    End If
            End Select

            Select Case FacturacionSiHay
                Case 1
                    If recibirSiHay > 0 OrElse insurtiblesSiHay > 0 OrElse facturarSiHay > 0 Then
                        If Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor.ToString = Color.Red.ToString Then
                            Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor = SystemColors.ControlText
                        Else
                            Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor = Color.Red
                        End If
                    Else
                        Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor = SystemColors.ControlText
                    End If
                Case 2
                    If surtirSihay > 0 OrElse sinGuiaSiHay > 0 OrElse canceladoSiHay > 0 Then
                        If Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor.ToString = Color.Red.ToString Then
                            Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor = SystemColors.ControlText
                        Else
                            Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor = Color.Red
                        End If
                    Else
                        Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor = SystemColors.ControlText
                    End If
                Case 3
                    If surtirSihay > 0 OrElse sinGuiaSiHay > 0 OrElse canceladoSiHay > 0 OrElse recibirSiHay > 0 OrElse facturarSiHay > 0 OrElse insurtiblesSiHay > 0 Then
                        If Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor.ToString = Color.Red.ToString Then
                            Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor = SystemColors.ControlText
                        Else
                            Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor = Color.Red
                        End If
                    Else
                        Me.pnlPedidosSH.TabStateStyles.FormatStyle.ForeColor = SystemColors.ControlText
                    End If
            End Select
        End If

        Me.pnlAvisos.Refresh()

    End Sub

    Private Sub Label8_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPedidosSurtir.DoubleClick, lblPedidosSurtirNum.DoubleClick
        If CInt(Me.lblPedidosSurtirNum.Text) > 0 Then
            Dim oFrmPedEC As New frmTraspasoAutoEcommerce
            oFrmPedEC.Modulo = "PP"
            oFrmPedEC.ShowDialog()
        End If
    End Sub

    Private Sub Label4_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPedidosFacturar.DoubleClick, lblPedidosFacturarNum.DoubleClick
        '----------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (11.03.2016): Comentado por que ya no se usara por adecuacionesa  retail
        '----------------------------------------------------------------------------------------------------------------------------------
        'If CInt(Me.lblPedidosFacturarNum.Text) > 0 Then
        '    Dim oFrmPedEC As New frmTraspasoAutoEcommerce
        '    oFrmPedEC.Modulo = "PF"
        '    oFrmPedEC.ShowDialog()
        'End If
    End Sub

    Private Sub timer1_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timer1.Elapsed

        timer1.Stop()
        timer2.Stop()
        'timer2.Stop()
        'timer1.Enabled = False

        'ActualizarPedidosEC()
        If oConfigCierreFI.SurtirEcommerce Then RefreshPedidosEC()

        'Actualizar Pedidos SiHay
        If FacturacionSiHay > 0 Then RefreshPedidosSiHay()

        'bPedidosRefresh = True

        timer1.Interval = (oConfigCierreFI.TiempoRevisaPedidos * 60) * 1000
        ''timer1.Enabled = True
        timer1.Start()
        timer2.Start()

        'aumenta()

    End Sub

    Private Sub Label9_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPedidosGuias.DoubleClick, lblPedidosGuiasNum.DoubleClick
        If CInt(Me.lblPedidosGuiasNum.Text) > 0 Then
            Dim oFrmGuias As New frmPedidosSinGuia
            oFrmGuias.ShowDialog()
        End If
    End Sub

    Private Sub lblPedidosCancelados_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPedidosCancel.DoubleClick, lblPedidosCancelNum.DoubleClick
        '----------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (11.03.2016): Comentado por que ya no se usara por adecuacionesa  retail
        '----------------------------------------------------------------------------------------------------------------------------------
        'If CInt(Me.lblPedidosCancelNum.Text.Trim) > 0 Then
        '    Dim oFrmPedCan As New frmPedidosCancelados
        '    With oFrmPedCan
        '        .Proceso = "CancelacionEccommerce"
        '        .Text = "Pedidos Cancelados Ecommerce"
        '        .ShowDialog()
        '    End With
        'End If
    End Sub

    Private Sub btnMasVendidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasVendidos.Click
        ManagerPanelControl("TOP10")
    End Sub

    Private Sub btnMenosVendidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenosVendidos.Click
        ManagerPanelControl("LAST10")
    End Sub

    'Private Sub lblPedidoSurtidoSiHay_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPedidoSurtidoSiHay.DoubleClick, lblPedidoNumSurSiHay.DoubleClick
    '    If CInt(Me.lblPedidoNumSurSiHay.Text) > 0 Then
    '        Dim oFrmPedEC As New frmTraspasoAutoEcommerce
    '        oFrmPedEC.Modulo = "PPS"
    '        oFrmPedEC.ShowDialog()
    '    End If
    'End Sub

    'Private Sub btnPedidosSiHay_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.expEcommerce.Visible = False
    '    Dim altura As Integer = panelFondoContainer.Height
    '    Dim ancho As Integer = panelFondoContainer.Width
    '    Me.expPedidosSiHay.Visible = True
    '    Me.expPedidosSiHay.Left = (ancho / 2) - (Me.expPedidosSiHay.Width / 2)
    '    Me.expPedidosSiHay.Top = (altura / 2) - (Me.expPedidosSiHay.Height / 2)
    'End Sub

    'Private Sub btnPedidosPendientes_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.expPedidosSiHay.Visible = False
    '    Dim altura As Integer = panelFondoContainer.Height
    '    Dim ancho As Integer = panelFondoContainer.Width
    '    Me.expEcommerce.Visible = True
    '    Me.expEcommerce.Left = (ancho / 2) - (Me.expEcommerce.Width / 2)
    '    Me.expEcommerce.Top = (altura / 2) - (Me.expEcommerce.Height / 2)
    'End Sub

    'Private Sub lblOcultar_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    Me.expEcommerce.Visible = False
    'End Sub

    'Private Sub lblOcultarSiHay_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    Me.expPedidosSiHay.Visible = False
    'End Sub
#Region "APIs"

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As System.IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Private Shared Function ShowWindow(ByVal hWnd As System.IntPtr, ByVal nCmdShow As Integer) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Public Shared Function SetForegroundWindow(ByVal hWnd As System.IntPtr) As Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("winspool.drv")> _
    Public Shared Function OpenPrinter(ByVal pPrinterName As String, ByVal phPrinter As Long, ByVal pDefault As Object) As Long
    End Function

    <System.Runtime.InteropServices.DllImport("winspool.drv")> _
    Public Shared Function ClosePrinter(ByVal hPrinter As Long) As Long
    End Function

#End Region

#Region "Facturacion SiHay"

    Private Sub lblPedidoSurtidoSiHay_DoubleClick1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPedidoSurtidoSiHay.DoubleClick, lblPedidoNumSurSiHay.DoubleClick
        SurtirForm()
    End Sub

    'Private Sub lblPedidoNumSurSiHay_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SurtirForm()
    'End Sub

    Private Sub lblGuiaSiHay_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGuiaSiHay.DoubleClick, lblGuiaNumSiHay.DoubleClick
        GuiaForm()
    End Sub

    'Private Sub lblGuiaNumSiHay_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    GuiaForm()
    'End Sub

    Private Sub lblPedidosPorRecibir_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPedidosPorRecibir.DoubleClick, lblRecibirNumSiHay.DoubleClick
        RecibirForm()
    End Sub

    'Private Sub lblRecibirNumSiHay_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    RecibirForm()
    'End Sub

    Private Sub lblPedidosInsurtibles_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPedidosInsurtibles.DoubleClick, lblInsurtibleNumSiHay.DoubleClick
        InsurtibleForm()
    End Sub

    'Private Sub lblInsurtibleNumSiHay_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    InsurtibleForm()
    'End Sub

    Private Sub lblPedidoFacturarSiHay_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPedidoFacturarSiHay.DoubleClick, lblFacturarNumSiHay.DoubleClick
        FacturarForm()
    End Sub

    Private Function RecibirForm()
        If CInt(lblRecibirNumSiHay.Text.Trim()) > 0 Then
            Dim nHwnI As System.IntPtr
            nHwnI = FindWindow(vbNullString, "Recibir Traslados Para Pedidos ""Si Hay""")
            If Val(nHwnI.ToString) <> 0 Then
                ShowWindow(nHwnI, 9)
                SetForegroundWindow(nHwnI)
            Else
                Dim menuClickB As New frmTraspasoAutoEcommerce
                menuClickB.Modulo = "PRSH"
                menuClickB.Show()
            End If
            'Dim menuClickB As New frmTraspasoAutoEcommerce
            'menuClickB.Modulo = "PRSH"
            'menuClickB.Show()
        End If
    End Function

    Private Function InsurtibleForm()
        If CInt(lblInsurtibleNumSiHay.Text.Trim()) > 0 Then
            oAppContext.Security.CloseImpersonatedSession()
            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.SiHay.PedidosInsurtibles") = True Then
                '-------------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 29/04/2013: Verificamos que el usuario tenga permisos para realizar la Devolucion de Efectivo. Si cuenta con el permiso
                '                  aparecera el Check Devolucion de Efectivo, si no, no se mostrata dicha opcion.
                '-------------------------------------------------------------------------------------------------------------------------------------
                Dim menuclickb As New frmPedidosInsurtiblesSH
                If oAppContext.Security.IsCurrentUserFeatureOperationAuthorized("DportenisPro.DPTienda.SiHay.PedidosInsurtibles", _
                    "DportenisPro.DPTienda.SiHay.PedidosInsurtibles.DevolucionEfectivo", False) = False Then
                    menuclickb.bVerDevEfec = False
                Else
                    menuclickb.bVerDevEfec = True
                End If
                menuclickb.Show()
            End If
            oAppContext.Security.CloseImpersonatedSession()
        End If
    End Function

    Private Function GuiaForm()
        If CInt(lblGuiaNumSiHay.Text.Trim()) > 0 Then
            Dim nHwnI As System.IntPtr
            nHwnI = FindWindow(vbNullString, "Pedidos Sin Guía")
            If Val(nHwnI.ToString) <> 0 Then
                ShowWindow(nHwnI, 9)
                SetForegroundWindow(nHwnI)
            Else
                Dim menuClickB As New frmPedidosSinGuia("PESH")
                menuClickB.Show()
            End If
            'Dim menuClickB As New frmPedidosSinGuia("PESH")
            'menuClickB.Show()
        End If
    End Function

    Private Function SurtirForm()
        If CInt(lblPedidoNumSurSiHay.Text.Trim) > 0 Then
            Dim nHwnI As System.IntPtr
            nHwnI = FindWindow(vbNullString, "Petición de Surtido Para ""Si Hay""")
            If Val(nHwnI.ToString) <> 0 Then
                ShowWindow(nHwnI, 9)
                SetForegroundWindow(nHwnI)
            Else
                Dim menuClickB As New frmTraspasoAutoEcommerce
                menuClickB.Modulo = "PPSH"
                menuClickB.Show()
            End If
            'Dim menuClickB As New frmTraspasoAutoEcommerce
            'menuClickB.Modulo = "PPSH"
            'menuClickB.Show()
        End If
    End Function

    Private Sub FacturarForm()
        If CInt(Me.lblFacturarNumSiHay.Text.Trim) > 0 Then
            Dim nHwnI As System.IntPtr
            nHwnI = FindWindow(vbNullString, "Facturar Pedidos Si Hay")

            If Val(nHwnI.ToString) <> 0 Then
                ShowWindow(nHwnI, 9)
                SetForegroundWindow(nHwnI)
            Else
                Dim menuClickB As New frmTraspasoAutoEcommerce
                menuClickB.Modulo = "PFSH"
                menuClickB.Show()
            End If
            'Dim menuClickB As New frmTraspasoAutoEcommerce
            'menuClickB.Modulo = "PFSH"
            'menuClickB.Show()
        End If
    End Sub

    Private Sub ParticipaEnSH()
        '----------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 25/04/2013: Revisamos si esta tienda participa en el proyecto "Si Hay" o no
        '----------------------------------------------------------------------------------------------------------------------------------
        Dim procesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig), strError As String = ""
        Dim permisos As Hashtable = procesoMgr.ZSH_PARTICIPANTES("T" & oAppContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0"), strError)
        If strError.Trim <> "" Then
            EscribeLog(strError.Trim, "Error al ejecutar la RFC ZSH_PARTICIPANTES en SAP")
            Exit Sub
        End If
        If CStr(permisos("Solicitar")).ToUpper() = "X" Then
            ImporteMinimoSH = CDec(permisos("IMPMIN"))
            PorcMasDescSH = CDec(permisos("MAXDESC"))
            FacturacionSiHay = 1
            If CStr(permisos("Suministrar")).ToUpper() = "X" Then
                FacturacionSiHay = 3
            End If
        ElseIf CStr(permisos("Suministrar")).ToUpper() = "X" Then
            ImporteMinimoSH = CDec(permisos("IMPMIN"))
            PorcMasDescSH = CDec(permisos("MAXDESC"))
            FacturacionSiHay = 2
        End If

        Select Case FacturacionSiHay
            Case -1 'No participa
                Me.pnlAvisos.Panels.Remove(Me.pnlPedidosSH)
            Case 1 'Solo solicitante
                lblPedidoFacturarSiHay.Visible = True
                lblFacturarNumSiHay.Visible = True
                imgFacturarSinHay.Visible = True
                lblPedidoSurtidoSiHay.Visible = False
                lblPedidoNumSurSiHay.Visible = False
                imgSurtirSiHay.Visible = False
                lblGuiaSiHay.Visible = False
                lblGuiaNumSiHay.Visible = False
                imgGuiaSiHay.Visible = False
                lblCancSiHay.Visible = False
                lblCancNumSiHay.Visible = False
                imgCancSiHay.Visible = False
                Me.lblPedidosPorRecibir.Top = 16
                Me.lblRecibirNumSiHay.Top = 16
                Me.imgRecibirSiHay.Top = 12
                Me.lblPedidoFacturarSiHay.Top = 48
                Me.lblFacturarNumSiHay.Top = 48
                Me.imgFacturarSinHay.Top = 44
                Me.lblPedidosInsurtibles.Top = 80
                Me.lblInsurtibleNumSiHay.Top = 80
                Me.imgInsurtibleSiHay.Top = 76
            Case 2 'Solo suministradora
                lblPedidoFacturarSiHay.Visible = False
                lblFacturarNumSiHay.Visible = False
                imgFacturarSinHay.Visible = False
                lblPedidoSurtidoSiHay.Visible = True
                lblPedidoNumSurSiHay.Visible = True
                imgSurtirSiHay.Visible = True
                lblGuiaSiHay.Visible = False
                lblGuiaNumSiHay.Visible = False
                imgGuiaSiHay.Visible = False
                lblCancSiHay.Visible = False
                lblCancNumSiHay.Visible = False
                imgCancSiHay.Visible = False
                Me.lblCancSiHay.Top = 80
                Me.lblCancNumSiHay.Top = 80
                Me.imgCancSiHay.Top = 76
            Case 3 'Solicitante y Suministradora
                lblPedidoFacturarSiHay.Visible = True
                lblFacturarNumSiHay.Visible = True
                imgFacturarSinHay.Visible = True
                lblPedidoSurtidoSiHay.Visible = True
                lblPedidoNumSurSiHay.Visible = True
                imgSurtirSiHay.Visible = True
                lblGuiaSiHay.Visible = False
                lblGuiaNumSiHay.Visible = False
                imgGuiaSiHay.Visible = False
                lblCancSiHay.Visible = False
                lblCancNumSiHay.Visible = False
                imgCancSiHay.Visible = False
        End Select

    End Sub

    Private Sub lblCancSiHay_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCancSiHay.DoubleClick
        PedidosCancelados()
    End Sub

    Private Sub lblCancNumSiHay_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCancNumSiHay.DoubleClick
        PedidosCancelados()
    End Sub

    Private Function PedidosCancelados()
        If CInt(lblCancNumSiHay.Text.Trim()) > 0 Then
            Dim nHwnI As System.IntPtr
            nHwnI = FindWindow(vbNullString, "ReIngresar al Inventario de Pedidos Cancelados")
            If Val(nHwnI.ToString) <> 0 Then
                ShowWindow(nHwnI, 9)
                SetForegroundWindow(nHwnI)
            Else
                Dim oFrm As New frmPedidosCancelados
                With oFrm
                    .Proceso = "CancelacionPedidos"
                    .Text = "ReIngresar al Inventario de Pedidos Cancelados"
                    .ShowDialog()
                End With
            End If
            'Dim oFrm As New frmPedidosCancelados
            'With oFrm
            '    .Proceso = "CancelacionPedidos"
            '    .Text = "ReIngresar al Inventario de Pedidos Cancelados"
            '    .ShowDialog()
            'End With
        End If
    End Function

#End Region

#Region "MetasDiarias"

    Public Sub ShowAndUpdateScoreBoard()
        GetMetasDiariasPlayers()
    End Sub

    Private Sub InitializeMetas()
        Try
            Me.dtMetasPlayer = New DataTable("MetaPlayer")
            Me.dtMetasPlayer.Columns.Add("CodPlayer", GetType(String))
            Me.dtMetasPlayer.Columns.Add("Nombre", GetType(String))
            Me.dtMetasPlayer.Columns.Add("MetaDia", GetType(Decimal))
            Me.dtMetasPlayer.Columns.Add("APV", GetType(Decimal))
            Me.dtMetasPlayer.Columns.Add("Venta", GetType(Decimal))
            Me.dtMetasPlayer.Columns.Add("PorVender", GetType(Decimal))
            Me.dtMetasPlayer.Columns.Add("PorAtender", GetType(Decimal))
            Me.dtMetasPlayer.AcceptChanges()
            Dim proceso As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
1:          Dim fecha As DateTime = proceso.MSS_GET_SY_DATE_TIME()
2:          Dim fechaInicio As DateTime, fechaFin As DateTime, UltimoDia As DateTime
3:          Dim lstMeses As ArrayList = GetListaMeses()
4:          If fecha.Day < 16 Then
5:              fechaInicio = New DateTime(fecha.Year, fecha.Month, 1)
6:              fechaFin = New DateTime(fecha.Year, fecha.Month, 15)
            Else
7:              fechaInicio = New DateTime(fecha.Year, fecha.Month, 16)
                UltimoDia = New DateTime(fecha.AddMonths(1).Year, fecha.AddMonths(1).Month, 1)
                UltimoDia = UltimoDia.AddDays(-1)
8:              If lstMeses.Contains(fecha.Month) Then
9:                  fechaFin = New DateTime(fecha.Year, fecha.Month, 31)
                Else
10:                 fechaFin = New DateTime(fecha.Year, fecha.Month, UltimoDia.Day)
                End If
            End If
11:         Me.webService = New WSBroker("METAS_MS")
12:         Dim dtResponse As DataTable = Me.webService.GetMetasDiasPlayer("T" & oAppContext.ApplicationConfiguration.Almacen, fechaInicio, fechaFin)
13:         If Not dtResponse Is Nothing Then
14:             Dim codPlayer As String = "", fila As DataRow = Nothing
15:             If dtResponse.Rows.Count > 0 Then
16:                 Dim lstPlayers As New ArrayList
17:                 For Each row As DataRow In dtResponse.Rows
18:                     codPlayer = CStr(row("CodEmpleado"))
19:                     If lstPlayers.Contains(codPlayer) = False Then
20:                         lstPlayers.Add(codPlayer)
21:                         fila = Me.dtMetasPlayer.NewRow()
22:                         fila("CodPlayer") = codPlayer
23:                         fila("Nombre") = CStr(row("NombreEmpleado"))
24:                         fila("MetaDia") = 0
25:                         fila("APV") = 0
26:                         fila("Venta") = 0
27:                         fila("PorVender") = 0
28:                         fila("PorAtender") = 0
29:                         Me.dtMetasPlayer.Rows.Add(fila)
                        End If
                    Next
                    'For Each str As String In lstPlayers
                    '    fila = Me.dtMetasPlayer.NewRow()
                    '    fila("CodPlayer") = str
                    '    fila("MetaDia") = 0
                    '    fila("APV") = 0
                    '    fila("Venta") = 0
                    '    fila("PorVender") = 0
                    '    fila("PorAtender") = 0
                    '    Me.dtMetasPlayer.Rows.Add(fila)
                    'Next
31:                 Me.dtMetasPlayer.AcceptChanges()
32:                 Me.GridMetasPlayers.DataSource = Me.dtMetasPlayer
                    'Me.gridEX2.DataSource = Me.dtMetasPlayer
                End If
                'fecha = New DateTime(2012, 4, 1)
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al inicializar las metas. Linea " & Err.Erl)
        End Try
    End Sub

    Private Function GetMetasDiariasPlayers()
        Dim proceso As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim fechaMeta As DateTime = proceso.MSS_GET_SY_DATE_TIME()
        'fechaMeta = New DateTime(2012, 4, 1)
        Dim fechaInicio As DateTime, fechaFin As DateTime, UltimoDia As DateTime
        Dim lstMeses As ArrayList = GetListaMeses()
        If fechaMeta.Day < 16 Then
            fechaInicio = New DateTime(fechaMeta.Year, fechaMeta.Month, 1)
            fechaFin = New DateTime(fechaMeta.Year, fechaMeta.Month, 15)
        Else
            fechaInicio = New DateTime(fechaMeta.Year, fechaMeta.Month, 16)
            UltimoDia = New DateTime(fechaMeta.AddMonths(1).Year, fechaMeta.AddMonths(1).Month, 1)
            UltimoDia = UltimoDia.AddDays(-1)
            If lstMeses.Contains(fechaMeta.Month) Then
                fechaFin = New DateTime(fechaMeta.Year, fechaMeta.Month, 31)
            Else
                fechaFin = New DateTime(fechaMeta.Year, fechaMeta.Month, UltimoDia.Day)
            End If
        End If
        Me.metadia = MetasDia.GetMetaTiendaDia(fechaMeta.Date)
        If Not Me.metadia Is Nothing Then
            Me.txtMetaDiaria.Text = String.Format("{0:C}", metadia.MetaDia)
        End If
        Dim codPlayer As String = "", total As Decimal = 0, apv As Decimal = 0, piezas As Decimal = 0, numFac As Integer = 0
        Dim porVender As Decimal = 0, porAtender As Decimal = 0, ventaPromedio As Decimal = 0, cantRest As Decimal = 0
        Dim lstMetasPlayers As ArrayList = MetaDiaPlayer.GetMetasDiasPlayers(fechaInicio, fechaFin)
        Dim dtResult As DataTable = MetaDiaPlayer.GetMetasVentas(oAppContext.ApplicationConfiguration.Almacen, fechaMeta, fechaMeta)
        If dtResult.Rows.Count > 0 Then
            total = dtResult.Compute("SUM(Total)", "")
            piezas = dtResult.Compute("SUM(Cantidad)", "")
            numFac = dtResult.Rows.Count
            If total > 0 Then
                apv = piezas / numFac
                ventaPromedio = total / numFac
                If Not metadia Is Nothing Then
                    cantRest = IIf(metadia.MetaDia - total < 0, 0, metadia.MetaDia - total)
                    txtMetaDiaria.Text = String.Format("{0:C}", metadia.MetaDia)
                Else
                    cantRest = 0
                End If

                'porVender = metadia.MetaDia - total
                porAtender = cantRest / ventaPromedio
                txtAPV.Text = String.Format("{0:N}", apv)
                txtCteXAtender.Text = String.Format("{0:N}", porAtender)
                txtVentasXPromedio.Text = String.Format("{0:C}", ventaPromedio)
                txtCantidadRestante.Text = String.Format("{0:C}", cantRest)
                txtVentasDia.Text = String.Format("{0:C}", total)
            End If
        End If
        If lstMetasPlayers.Count > 0 Then
            Dim fila As DataRow = Nothing
            Dim metaPlayer As MetaDiaPlayer = Nothing
            For Each row As DataRow In Me.dtMetasPlayer.Rows
                apv = 0
                cantRest = 0
                total = 0
                porVender = 0
                porAtender = 0
                codPlayer = CStr(row("CodPlayer"))
                metaPlayer = MetaDiaPlayer.GetMetaByPlayer(codPlayer, fechaMeta)
                If Not metaPlayer Is Nothing Then
                    row("MetaDia") = metaPlayer.MetaDia
                Else
                    row("Metadia") = 0
                End If
                If dtResult.Rows.Count > 0 Then
                    If dtResult.Select("CodVendedor='" & codPlayer & "'").Length > 0 Then
                        piezas = dtResult.Compute("SUM(Cantidad)", "CodVendedor='" & codPlayer & "'")
                        total = dtResult.Compute("SUM(Total)", "CodVendedor='" & codPlayer & "'")
                        numFac = dtResult.Compute("COUNT(CodVendedor)", "CodVendedor='" & codPlayer & "'")
                        If total > 0 Then
                            apv = piezas / numFac
                            ventaPromedio = total / numFac
                            cantRest = IIf(metaPlayer.MetaDia - total < 0, 0, metaPlayer.MetaDia - total)
                            'porVender = metaPlayer.MetaDia - total
                            porAtender = cantRest / ventaPromedio
                        End If
                    End If
                End If
                row("APV") = Decimal.Round(apv, 0)
                row("Venta") = total
                row("PorVender") = Decimal.Round(cantRest, 0)
                row("PorAtender") = Decimal.Round(porAtender, 0)
                row.AcceptChanges()
            Next
        End If
        Me.dtMetasPlayer.AcceptChanges()
        'If lstMetasPlayers.Count > 0 And dtResult.Rows.Count > 0 Then
        '    Dim fila As DataRow = Nothing
        '    Dim metaPlayer As MetaDiaPlayer = Nothing
        '    For Each row As DataRow In Me.dtMetasPlayer.Rows
        '        apv = 0
        '        cantRest = 0
        '        porVender = 0
        '        porAtender = 0
        '        codPlayer = CStr(row("CodPlayer"))
        '        metaPlayer = MetaDiaPlayer.GetMetaByPlayer(codPlayer, fechaMeta)
        '        If dtResult.Select("CodVendedor='" & codPlayer & "'").Length > 0 Then
        '            If Not metaPlayer Is Nothing Then
        '                row("MetaDia") = metaPlayer.MetaDia
        '                piezas = dtResult.Compute("SUM(Cantidad)", "CodVendedor='" & codPlayer & "'")
        '                total = dtResult.Compute("SUM(Total)", "CodVendedor='" & codPlayer & "'")
        '                numFac = dtResult.Compute("COUNT(CodVendedor)", "CodVendedor='" & codPlayer & "'")
        '                If total > 0 Then
        '                    apv = piezas / numFac
        '                    ventaPromedio = total / numFac
        '                    cantRest = IIf(metaPlayer.MetaDia - total < 0, 0, metaPlayer.MetaDia - total)
        '                    'porVender = metaPlayer.MetaDia - total
        '                    porAtender = cantRest / ventaPromedio
        '                End If
        '            Else
        '                row("MetaDia") = 0
        '            End If
        '            row("APV") = apv
        '            row("Venta") = total
        '            row("PorVender") = cantRest
        '            row("PorAtender") = porAtender
        '            row.AcceptChanges()
        '        Else
        '            If Not metaPlayer Is Nothing Then
        '                row("MetaDia") = metaPlayer.MetaDia
        '            End If
        '        End If
        '    Next
        '    Me.dtMetasPlayer.AcceptChanges()
        'End If
    End Function
#End Region

#Region "Liberar RAM"

    '-------------------------------------------------------------
    ' JNAVA (04.09.2017): Liberar RAM usada por el PRO (Basura)
    '-------------------------------------------------------------
    Private Sub Timer3_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer3.Elapsed
        If oConfigCierreFI.FreeRAM Then
            FreeMemory.FlushMemory()
        End If
    End Sub

#End Region

End Class
