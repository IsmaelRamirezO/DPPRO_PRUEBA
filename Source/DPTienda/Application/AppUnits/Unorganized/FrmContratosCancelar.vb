
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.DistribucionNC
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CancelacionAbonoAU

Public Class FrmContratosCancelar
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents CommandManager As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArhivoImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArhivoImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebMotivo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ebTotalAbonos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ebPenalizacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ebTotal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ebMontoAnticipoCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMontoTarjetaCredito As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridContrato As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebAClientesPenalizado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents LblCDT As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbValeCaja As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbDevDinero As Janus.Windows.EditControls.UIRadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContratosCancelar))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.CommandManager = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyuda2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArhivoImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArhivoImprimir")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArhivoImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuArhivoImprimir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebMotivo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ebTotalAbonos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ebPenalizacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ebTotal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ebMontoAnticipoCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebMontoTarjetaCredito = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridContrato = New Janus.Windows.GridEX.GridEX()
        Me.ebAClientesPenalizado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.LblCDT = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbDevDinero = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbValeCaja = New Janus.Windows.EditControls.UIRadioButton()
        CType(Me.CommandManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.GridContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CommandManager
        '
        Me.CommandManager.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.CommandManager.BottomRebar = Me.BottomRebar1
        Me.CommandManager.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.CommandManager.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuArchivoNuevo, Me.menuArchivoSalir, Me.menuAyuda, Me.menuArchivoGuardar, Me.menuArhivoImprimir})
        Me.CommandManager.ContainerControl = Me
        '
        '
        '
        Me.CommandManager.EditContextMenu.Key = ""
        Me.CommandManager.Id = New System.Guid("2e3031dd-54bc-4232-94dc-8839dda08ad0")
        Me.CommandManager.LeftRebar = Me.LeftRebar1
        Me.CommandManager.RightRebar = Me.RightRebar1
        Me.CommandManager.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.CommandManager.TopRebar = Me.TopRebar1
        Me.CommandManager.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.CommandManager
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.CommandManager
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(688, 22)
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
        Me.UiCommandBar2.CommandManager = Me.CommandManager
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.menuArchivoGuardar2, Me.Separator2, Me.menuAyuda2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.Size = New System.Drawing.Size(218, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Image = CType(resources.GetObject("menuArchivoNuevo2.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        '
        'menuArchivoGuardar2
        '
        Me.menuArchivoGuardar2.Icon = CType(resources.GetObject("menuArchivoGuardar2.Icon"), System.Drawing.Icon)
        Me.menuArchivoGuardar2.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar2.Name = "menuArchivoGuardar2"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuAyuda2
        '
        Me.menuAyuda2.Image = CType(resources.GetObject("menuAyuda2.Image"), System.Drawing.Image)
        Me.menuAyuda2.Key = "menuAyuda"
        Me.menuAyuda2.Name = "menuAyuda2"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.menuArchivoGuardar1, Me.Separator1, Me.menuArhivoImprimir1, Me.Separator3, Me.menuArchivoSalir1})
        Me.menuArchivo.Image = CType(resources.GetObject("menuArchivo.Image"), System.Drawing.Image)
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Icon = CType(resources.GetObject("menuArchivoNuevo1.Icon"), System.Drawing.Icon)
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'menuArchivoGuardar1
        '
        Me.menuArchivoGuardar1.Icon = CType(resources.GetObject("menuArchivoGuardar1.Icon"), System.Drawing.Icon)
        Me.menuArchivoGuardar1.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuArhivoImprimir1
        '
        Me.menuArhivoImprimir1.Icon = CType(resources.GetObject("menuArhivoImprimir1.Icon"), System.Drawing.Icon)
        Me.menuArhivoImprimir1.Key = "menuArhivoImprimir"
        Me.menuArhivoImprimir1.Name = "menuArhivoImprimir1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuArchivoSalir1
        '
        Me.menuArchivoSalir1.Key = "menuArchivoSalir"
        Me.menuArchivoSalir1.Name = "menuArchivoSalir1"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "&Salir"
        '
        'menuAyuda
        '
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "&Ayuda"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "&Guardar"
        '
        'menuArhivoImprimir
        '
        Me.menuArhivoImprimir.Key = "menuArhivoImprimir"
        Me.menuArhivoImprimir.Name = "menuArhivoImprimir"
        Me.menuArhivoImprimir.Text = "&Imprimir"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.CommandManager
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.CommandManager
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.CommandManager
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(688, 50)
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolio.ButtonImage = CType(resources.GetObject("ebFolio.ButtonImage"), System.Drawing.Image)
        Me.ebFolio.ButtonImageIndex = 0
        Me.ebFolio.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebFolio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolio.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFolio.Location = New System.Drawing.Point(136, 48)
        Me.ebFolio.MaxLength = 7
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.Size = New System.Drawing.Size(96, 23)
        Me.ebFolio.TabIndex = 75
        Me.ebFolio.Text = "0"
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMotivo
        '
        Me.ebMotivo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMotivo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMotivo.BackColor = System.Drawing.Color.White
        Me.ebMotivo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMotivo.Location = New System.Drawing.Point(352, 48)
        Me.ebMotivo.MaxLength = 255
        Me.ebMotivo.Multiline = True
        Me.ebMotivo.Name = "ebMotivo"
        Me.ebMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ebMotivo.Size = New System.Drawing.Size(336, 72)
        Me.ebMotivo.TabIndex = 76
        Me.ebMotivo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(296, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 32)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Motivo :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebTotalAbonos
        '
        Me.ebTotalAbonos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalAbonos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalAbonos.BackColor = System.Drawing.SystemColors.Info
        Me.ebTotalAbonos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalAbonos.Location = New System.Drawing.Point(136, 120)
        Me.ebTotalAbonos.Name = "ebTotalAbonos"
        Me.ebTotalAbonos.ReadOnly = True
        Me.ebTotalAbonos.Size = New System.Drawing.Size(128, 22)
        Me.ebTotalAbonos.TabIndex = 91
        Me.ebTotalAbonos.TabStop = False
        Me.ebTotalAbonos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotalAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(24, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 23)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "Total Abonos :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebPenalizacion
        '
        Me.ebPenalizacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPenalizacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPenalizacion.BackColor = System.Drawing.SystemColors.Info
        Me.ebPenalizacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPenalizacion.Location = New System.Drawing.Point(136, 96)
        Me.ebPenalizacion.Name = "ebPenalizacion"
        Me.ebPenalizacion.ReadOnly = True
        Me.ebPenalizacion.Size = New System.Drawing.Size(128, 22)
        Me.ebPenalizacion.TabIndex = 89
        Me.ebPenalizacion.TabStop = False
        Me.ebPenalizacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebPenalizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(24, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 23)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Penalización :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebTotal
        '
        Me.ebTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotal.BackColor = System.Drawing.SystemColors.Info
        Me.ebTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotal.Location = New System.Drawing.Point(136, 73)
        Me.ebTotal.Name = "ebTotal"
        Me.ebTotal.ReadOnly = True
        Me.ebTotal.Size = New System.Drawing.Size(128, 22)
        Me.ebTotal.TabIndex = 87
        Me.ebTotal.TabStop = False
        Me.ebTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(24, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Cantidad Total :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebMontoAnticipoCliente
        '
        Me.ebMontoAnticipoCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoAnticipoCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoAnticipoCliente.BackColor = System.Drawing.SystemColors.Info
        Me.ebMontoAnticipoCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMontoAnticipoCliente.Location = New System.Drawing.Point(304, 328)
        Me.ebMontoAnticipoCliente.Name = "ebMontoAnticipoCliente"
        Me.ebMontoAnticipoCliente.ReadOnly = True
        Me.ebMontoAnticipoCliente.Size = New System.Drawing.Size(112, 22)
        Me.ebMontoAnticipoCliente.TabIndex = 84
        Me.ebMontoAnticipoCliente.TabStop = False
        Me.ebMontoAnticipoCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMontoAnticipoCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMontoTarjetaCredito
        '
        Me.ebMontoTarjetaCredito.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoTarjetaCredito.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoTarjetaCredito.BackColor = System.Drawing.SystemColors.Info
        Me.ebMontoTarjetaCredito.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMontoTarjetaCredito.Location = New System.Drawing.Point(104, 328)
        Me.ebMontoTarjetaCredito.Name = "ebMontoTarjetaCredito"
        Me.ebMontoTarjetaCredito.ReadOnly = True
        Me.ebMontoTarjetaCredito.Size = New System.Drawing.Size(104, 22)
        Me.ebMontoTarjetaCredito.TabIndex = 83
        Me.ebMontoTarjetaCredito.TabStop = False
        Me.ebMontoTarjetaCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMontoTarjetaCredito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(224, 328)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 23)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Vale Caja :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(16, 328)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "T. Crédito :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GridContrato
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GridContrato.DesignTimeLayout = GridEXLayout1
        Me.GridContrato.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridContrato.GroupByBoxVisible = False
        Me.GridContrato.Location = New System.Drawing.Point(15, 160)
        Me.GridContrato.Name = "GridContrato"
        Me.GridContrato.Size = New System.Drawing.Size(674, 160)
        Me.GridContrato.TabIndex = 79
        Me.GridContrato.TabStop = False
        Me.GridContrato.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAClientesPenalizado
        '
        Me.ebAClientesPenalizado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAClientesPenalizado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAClientesPenalizado.BackColor = System.Drawing.SystemColors.Info
        Me.ebAClientesPenalizado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAClientesPenalizado.Location = New System.Drawing.Point(576, 328)
        Me.ebAClientesPenalizado.Name = "ebAClientesPenalizado"
        Me.ebAClientesPenalizado.ReadOnly = True
        Me.ebAClientesPenalizado.Size = New System.Drawing.Size(110, 22)
        Me.ebAClientesPenalizado.TabIndex = 81
        Me.ebAClientesPenalizado.TabStop = False
        Me.ebAClientesPenalizado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebAClientesPenalizado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'LblCDT
        '
        Me.LblCDT.AutoSize = True
        Me.LblCDT.BackColor = System.Drawing.Color.Transparent
        Me.LblCDT.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblCDT.Location = New System.Drawing.Point(448, 328)
        Me.LblCDT.Name = "LblCDT"
        Me.LblCDT.Size = New System.Drawing.Size(121, 16)
        Me.LblCDT.TabIndex = 80
        Me.LblCDT.Text = "Importe a Favor :"
        Me.LblCDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(24, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 23)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "Número de Folio:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.ebFolio)
        Me.ExplorerBar1.Controls.Add(Me.ebMotivo)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.ebTotalAbonos)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.ebPenalizacion)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.ebTotal)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.ebMontoAnticipoCliente)
        Me.ExplorerBar1.Controls.Add(Me.ebMontoTarjetaCredito)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.GridContrato)
        Me.ExplorerBar1.Controls.Add(Me.ebAClientesPenalizado)
        Me.ExplorerBar1.Controls.Add(Me.LblCDT)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Cancelar Contratos"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(688, 782)
        Me.ExplorerBar1.TabIndex = 36
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.rbDevDinero)
        Me.UiGroupBox1.Controls.Add(Me.rbValeCaja)
        Me.UiGroupBox1.Location = New System.Drawing.Point(352, 120)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(336, 32)
        Me.UiGroupBox1.TabIndex = 93
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'rbDevDinero
        '
        Me.rbDevDinero.ForeColor = System.Drawing.Color.Red
        Me.rbDevDinero.Location = New System.Drawing.Point(152, 12)
        Me.rbDevDinero.Name = "rbDevDinero"
        Me.rbDevDinero.Size = New System.Drawing.Size(168, 16)
        Me.rbDevDinero.TabIndex = 1
        Me.rbDevDinero.Text = "Devolución de Dinero"
        '
        'rbValeCaja
        '
        Me.rbValeCaja.Checked = True
        Me.rbValeCaja.ForeColor = System.Drawing.Color.Red
        Me.rbValeCaja.Location = New System.Drawing.Point(8, 12)
        Me.rbValeCaja.Name = "rbValeCaja"
        Me.rbValeCaja.Size = New System.Drawing.Size(120, 16)
        Me.rbValeCaja.TabIndex = 0
        Me.rbValeCaja.TabStop = True
        Me.rbValeCaja.Text = "Vale de Caja"
        '
        'FrmContratosCancelar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(688, 410)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(704, 448)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(704, 448)
        Me.Name = "FrmContratosCancelar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelar Contratos para Nota de Crédito"
        CType(Me.CommandManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.GridContrato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Variables Miembros"

    Private oContratosMgr As ContratoManager

    Private oContrato As Contrato

    Dim oDistribucionNCMgr As DistribucionNCManager

    Dim oDistribucionNC As DistribucionNC

    Dim bolRegistroGuardado As Boolean

    Dim bolDatosOK As Boolean = True

#End Region



#Region "Métodos Privados"

    Private Sub Sm_Inicializar()

        oContratosMgr = New ContratoManager(oAppContext)

        oDistribucionNCMgr = New DistribucionNCManager(oAppContext)

    End Sub



    Private Sub Sm_Finalizar()

        oContratosMgr = Nothing

        oContrato = Nothing

        oDistribucionNCMgr = Nothing

        oDistribucionNC = Nothing

    End Sub



    Private Function Fm_bolValidarNoAutorizacionCancelacion() As Boolean

        Dim drAbono As DataRow


        For Each drAbono In oDistribucionNC.Detalle.Tables("AnticiposClientesDetalle").Rows

            'On Error GoTo SaltoLinea

            If (drAbono("NumeroTarjeta") <> String.Empty) And (drAbono("MontoCanceladoTarjeta") > 0) And (IsDBNull(drAbono("NumeroAutorizacionCancelacion"))) Then

                MsgBox("El Abono : " & drAbono("Referencia") & " no tiene el No. de Cancelación.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Function

            ElseIf (drAbono("NumeroTarjeta") <> String.Empty) And (drAbono("MontoCanceladoTarjeta") > 0) And (Trim(CType(drAbono("NumeroAutorizacionCancelacion"), String)) = String.Empty) Then

                MsgBox("El Abono : " & drAbono("Referencia") & " no tiene el No. de Cancelación.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Function

            End If

            'SaltoLinea:

        Next

        Return True

    End Function



    Private Function Fm_bolTxtValidar(ByRef UserCancela As String) As Boolean

        If (oContrato Is Nothing) Then

            MsgBox("No ha sido seleccionado un Contrato.", MsgBoxStyle.Exclamation, "DPTienda.")
            ebFolio.Focus()

            Exit Function

        End If

        If (oContrato.StatusRegistro = False) Then

            Sm_Nuevo()

            MsgBox("El Contrato se encuentra Cancelado.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If

        If (ebMotivo.Text.Trim = String.Empty) Then

            MsgBox("No ha sido especificado el Motivo de la Cancelación", MsgBoxStyle.Exclamation, "DPTienda")
            ebMotivo.Focus()

            Exit Function

        End If

        oAppContext.Security.CloseImpersonatedSession()
        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Apartados.CancelaContrato", "DportenisPro.DPTienda.Apartados.CancelaContrato.ParaNotaDeCredito") = True Then
            UserCancela = oAppContext.Security.CurrentUser.SessionLoginName.Trim
            oAppContext.Security.CloseImpersonatedSession()
        Else
            UserCancela = ""
            oAppContext.Security.CloseImpersonatedSession()
            Exit Function
        End If

        Return True

    End Function



    Private Sub Sm_TxtLimpiar()

        ebFolio.Text = 0

        ebTotal.Text = String.Empty

        ebMotivo.Text = String.Empty

        ebPenalizacion.Text = String.Empty

        ebTotalAbonos.Text = String.Empty

        ebMontoTarjetaCredito.Text = String.Empty

        ebMontoAnticipoCliente.Text = String.Empty

        ebAClientesPenalizado.Text = String.Empty

        GridContrato.DataSource = Nothing

    End Sub



    Private Sub Sm_MostrarInformacion()

        With oDistribucionNC

            ebFolio.Text = .Referencia

            ebTotal.Text = Format(.TotalAnticipoCliente, "Standard")

            ebPenalizacion.Text = Format(.Penalizacion, "Standard")

            ebTotalAbonos.Text = Format(.TotalAbonos, "Standard")

            ebMontoTarjetaCredito.Text = Format(.TotalTarjetaCredito, "Standard")

            'ebMontoAnticipoCliente.Text = Format(.SaldoAnticipoCliente, "Standard")

            ebMotivo.Text = .MotivoCancelacion


            'Abonos realizados en Efectivo o Tarjeta Debito :
            Dim decTotalAbonosAnticipoClientes As Decimal = oContratosMgr.CalcularTotalAbonosAnticipoClientes(oContrato.ID)  'oDistribucionNC.ID)
            '(intAnticipoID)

            'Ramiro Alcaraz Flores            

            If (.Penalizacion > decTotalAbonosAnticipoClientes) Then

                ebMontoAnticipoCliente.Text = Format(0, "Standard")

            Else

                ebMontoAnticipoCliente.Text = Format(Math.Abs(.SaldoAnticipoCliente - .Penalizacion), "Standard")

            End If

            ebAClientesPenalizado.Text = Format((.TotalTarjetaCredito + CDec(ebMontoAnticipoCliente.Text)), "Standard")

            GridContrato.DataSource = .Detalle.Tables("AnticiposClientesDetalle")

        End With

    End Sub



    Private Sub Sm_BuscarContrato(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        '<Validación>

        If Not (oDistribucionNC Is Nothing) Then

            If ((oDistribucionNC.MotivoCancelacion <> String.Empty)) Then

                MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Sub

            Else

                oContratosMgr.ContratoCancelarAnticiposClientesDel(oDistribucionNC.ID)

            End If

        End If

        '</Validación>


        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New ContratoOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                oContrato = Nothing
                oContrato = oContratosMgr.Load(oOpenRecordDlg.Record.Item("ApartadoID"))
                If Not oContrato Is Nothing Then

                    If oContrato.Fecha.AddDays(oAppContext.ApplicationConfiguration.DiasVencimientoApartados) < Today Then
                        MessageBox.Show("No es posible cancelar este contrato por que ya esta vencido." & vbCrLf & "Debe cancelarlo de forma definitiva.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        oContrato = Nothing
                        ebFolio.Text = String.Empty
                        ebFolio.Focus()
                    Else
                        ebFolio.Text = oContrato.FolioApartado
                        ebTotal.Text = oContrato.ImporteTotal

                        ebMotivo.Focus()
                    End If

                End If

            Else

                Exit Sub

            End If

        Else

            oContrato = Nothing
            oContrato = oContratosMgr.LoadFolioApartado(ebFolio.Text)

            '<Validación>

            If (oContrato Is Nothing) Then

                MessageBox.Show("El Contrato no se encuentra registrado.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                ebFolio.Text = String.Empty
                ebFolio.Focus()

            ElseIf oContrato.Fecha.AddDays(oAppContext.ApplicationConfiguration.DiasVencimientoApartados) < Today Then
                MessageBox.Show("No es posible cancelar este contrato por que ya esta vencido." & vbCrLf & "Debe cancelarlo de forma definitiva.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                oContrato = Nothing
                ebFolio.Text = String.Empty
                ebFolio.Focus()
            Else
                ebFolio.Text = oContrato.FolioApartado
                ebTotal.Text = oContrato.ImporteTotal
            End If
            '</Validación>

        End If


        'Dim intAnticipoID As Integer

        'intAnticipoID = oContratosMgr.DistibucionCancelarContrato(oContrato)

        'oDistribucionNC = Nothing
        'oDistribucionNC = oDistribucionNCMgr.LoadAnticipoCliente(intAnticipoID)

        'Sm_MostrarInformacion()

    End Sub



    Private Sub Sm_Nuevo()

        If (bolRegistroGuardado = False) And Not (oDistribucionNC Is Nothing) Then

            oContratosMgr.ContratoCancelarAnticiposClientesDel(oDistribucionNC.ID)

        End If


        bolRegistroGuardado = False

        oContrato = Nothing
        oDistribucionNC = Nothing

        Sm_TxtLimpiar()

        ebFolio.Focus()

    End Sub


    Public Sub Sm_ActionPrint(Optional ByVal Reimpresion As Boolean = False)

        Dim oCliente As ClienteAlterno
        Dim oCatalogoClientesMgr As ClientesManager

        oCatalogoClientesMgr = New ClientesManager(oAppContext)


        oCliente = oCatalogoClientesMgr.CreateAlterno
        oCatalogoClientesMgr.Load(oContrato.ClienteID, oCliente, "A")

        If (oContrato Is Nothing) Then
            MsgBox("Debe Abrir un Contrato.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If

        Dim oARReporte
        Dim oView As New ReportViewerForm

        oARReporte = New ReporteCancelacionContrato(oContrato, oCliente, oContrato.Detalle.Tables(0), Reimpresion)
        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
        oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

        'oARReporte.DataSource = oContrato.Detalle.Tables(0)
        oARReporte.Document.Name = "Reporte Cancelación de Apartado"
        oARReporte.Run()

        Try

            oARReporte.Document.Print(False, False)
            'oView.Report = oARReporte
            'oView.Show()

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

    End Sub



    Private Sub Sm_Guardar()


        Dim UserCancela As String = ""
        bolDatosOK = True

        If Not (oDistribucionNC Is Nothing) Then

            If ((oDistribucionNC.MotivoCancelacion <> String.Empty)) Then
                bolDatosOK = False
                MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Sub

            End If

        End If


        If (Fm_bolTxtValidar(UserCancela) = False) Then
            bolDatosOK = False
            Exit Sub

        End If


        If (Fm_bolValidarNoAutorizacionCancelacion() = False) Then
            bolDatosOK = False
            Exit Sub

        End If

        'Actualiza el numero de autorizacion de cancelacion
        'de la tabla AnticiposClientesDetalle en base al AnticipoDetalleID
        oContrato = oContratosMgr.Load(oContrato.ID)
        oDistribucionNCMgr.ContratoAnticipoClienteNoCancelacionUpd(oDistribucionNC.Detalle)


        'Actualiza el MotivoCancelacion de la tabla AnticiposClientes
        'en base al AnticipoID.
        oDistribucionNCMgr.ContratoMotivoCancelacionUpd(oDistribucionNC.ID, ebMotivo.Text)



        'oContratosMgr.ContratoCancelarAbonos(oContrato.ID)
        'Actualiza el campo de apartado de la tabla Existencia
        'de acuerdo a la cantidad cancelada en el contrato.
        oContratosMgr.ContratoCancelarUpdateInventario(oContrato.Detalle)


        'MsgBox("El Contrato ha sido Cancelado.", MsgBoxStyle.Information, "DPTienda")


        Dim intAnticipoID As Integer

        intAnticipoID = oDistribucionNC.ID

        oDistribucionNC = Nothing
        oDistribucionNC = oDistribucionNCMgr.LoadAnticipoCliente(intAnticipoID, "AP")

        Sm_MostrarInformacion()

        bolRegistroGuardado = True



        'Generar Vale de Caja :

        If (ebAClientesPenalizado.Text = 0) Then

            oContratosMgr.CancelarContrato(oContrato.ID, UserCancela)

            Sm_ActionPrint()
            MsgBox("El Contrato ha sido Cancelado.", MsgBoxStyle.Information, "DPTienda")
            Exit Sub

        End If

        '********************SAP     Ramiro Alcaraz Flores********************
        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim strDOCNUMFB01 As String
        Dim strArr(2) As String
        Dim oRow As DataRow : Dim intCount As Integer = 0
        Dim intNumReg As Integer = oDistribucionNC.Detalle.Tables("AnticiposClientesDetalle").Rows.Count
        Dim decPena As Decimal = Math.Round(oDistribucionNC.TotalAnticipoCliente * 0.1, 2)
        Dim decDev As Decimal

        Dim ds As New DataSet
        ds = oContratosMgr.AbonosApartadosSel(oContrato.ID)

        'Cancelamos en SAP
        Dim strDevEfec As String
        Dim division As String = ""
        If Me.rbValeCaja.Checked = True Then
            strDevEfec = "0"
        Else
            strDevEfec = "X"
        End If
        division = oContratosMgr.DivisionSel

        strDOCNUMFB01 = oSap.CancelarApartadoNC(ds, strDevEfec, decPena, division, oAppContext.ApplicationConfiguration.Almacen, oContrato.FolioApartado, oContrato.Referencia)


        For Each oRow In oDistribucionNC.Detalle.Tables("AnticiposClientesDetalle").Rows
            If strDOCNUMFB01 <> "" Then
                oDistribucionNCMgr.ActualizaDOCNUMFB01xFolioAbono(oRow!REFERENCIA, strDOCNUMFB01)
            Else
                'No se guardo en SAP
            End If
        Next

        '********************Cancelar En MM14********************
        Dim strDocFi As String

        'Guarda el contrato en sap 
        'strDocFi = oSap.Write_DesbloqueApartado(oContrato.ContratoSAP, oContrato.Detalle.Tables("ContratoDetalle"))

        'If strDocFi <> "" Then
        '    'tambien guarda en la tabla Apartado el DocFi de cancelacion que regresa sap
        '    oContratosMgr.SetDocFiCancelacion(oContrato.ID, strDocFi)
        'Else
        '    'no se graba en SAP 
        'End If

        '********************SAP********************

        Dim frmValeCaja As New frmValeCaja
        Dim oValeCaja As ValeCaja
        Dim oValeCajaMgr As New ValeCajaManager(oAppContext)
        Dim oCliente As ClienteAlterno
        Dim oCatalogoClientesMgr As New ClientesManager(oAppContext)

        oCliente = oCatalogoClientesMgr.CreateAlterno
        oCatalogoClientesMgr.Load(oContrato.ClienteID, oCliente, "I")


        oValeCaja = oValeCajaMgr.Create

        With oValeCaja

            '.ValeCajaID = 0

            .Fecha = Now  'oContrato.Fecha

            .Importe = ebAClientesPenalizado.Text

            .TipoDocumento = "CA"

            '.FolioDocumento = oContrato.FolioApartado
            .FolioDocumento = strDOCNUMFB01

            .DocumentoID = oContrato.ID

            .DocumentoImporte = oContrato.ImporteTotal

            .CodCliente = oContrato.ClienteID

            .Nombre = oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno

            .DevEfectivo = False


            .Motivo = String.Empty

            .StastusRegistro = True

            .DistribucionDetalle = oDistribucionNC.Detalle

        End With


        With frmValeCaja
            If rbValeCaja.Checked = True Then
                .ValeCajaOpt = True
            Else
                .DevEfectOpt = True
            End If

            .canModif = False

            .ValeCaja = oValeCaja
            .DistribucionContrato = oDistribucionNC
            .MontoAFavor = ebAClientesPenalizado.Text

            frmValeCaja.ShowDialog()

        End With


        frmValeCaja = Nothing
        oValeCaja = Nothing
        oValeCajaMgr = Nothing
        oCliente = Nothing
        oCatalogoClientesMgr = Nothing


        'NOTA : 
        '       Afectar el Status del Contrato

        'oContratosMgr.ContratoCancelarAbonos(oContrato.ID)

        oContratosMgr.CancelarContrato(oContrato.ID, UserCancela)

        Sm_ActionPrint()

        MsgBox("El Contrato ha sido Cancelado.", MsgBoxStyle.Information, "DPTienda")

    End Sub

#End Region



#Region "Métodos Privados [Eventos]"

    Private Sub FrmContratosCancelar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()

    End Sub



    Private Sub FrmContratosCancelar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If (bolRegistroGuardado = False) And Not (oDistribucionNC Is Nothing) Then

            oContratosMgr.ContratoCancelarAnticiposClientesDel(oDistribucionNC.ID)

        End If


        Sm_Finalizar()

    End Sub



    Private Sub CommandManager_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles CommandManager.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoNuevo"

                Sm_Nuevo()


            Case "menuArchivoGuardar"

                Sm_Guardar()
                If bolDatosOK Then
                    Sm_Nuevo()
                End If


            Case "menuArchivoSalir"

                Me.Close()

        End Select

    End Sub



    Private Sub FrmContratosCancelar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            SendKeys.Send("{TAB}")

        End If


        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarContrato(True)

        End If

    End Sub



    Private Sub ebFolio_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebFolio.ButtonClick

        Sm_BuscarContrato(True)

    End Sub



    Private Sub ebFolio_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolio.Validating

        If (ebFolio.Text.Trim = String.Empty) Then

            Exit Sub

        End If


        If (ebFolio.Text <> 0) Then

            Sm_BuscarContrato()

            If (oContrato Is Nothing) Then

                Exit Sub

            End If


            If (oContrato.StatusRegistro = False) Then

                MsgBox("El Contrato se encuentra Cancelado.", MsgBoxStyle.Exclamation, "DPTienda")

                Sm_TxtLimpiar()
                ebFolio.Focus()

                Exit Sub

            End If


            If (oContrato.Entregada = "S") Then
                MsgBox("El Contrato ya ha sido finalizado y entregado al cliente.", MsgBoxStyle.Exclamation, "DPTienda")
                Sm_TxtLimpiar()
                ebFolio.Focus()

                Exit Sub


            End If


            Dim intAnticipoID As Integer

            intAnticipoID = oContratosMgr.DistibucionCancelarContrato(oContrato)

            oDistribucionNC = Nothing
            oDistribucionNC = oDistribucionNCMgr.LoadAnticipoCliente(intAnticipoID, "AP")

            Sm_MostrarInformacion()

        End If

    End Sub



    Private Sub uibtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Sm_Nuevo()

    End Sub



    Private Sub uibtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Sm_Guardar()

        'If Not (oDistribucionNC Is Nothing) Then

        '    If ((oDistribucionNC.MotivoCancelacion <> String.Empty)) Then

        '        MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
        '        Exit Sub

        '    End If

        'End If


        'If (Fm_bolTxtValidar() = False) Then

        '    Exit Sub

        'End If


        'If (Fm_bolValidarNoAutorizacionCancelacion() = False) Then

        '    Exit Sub

        'End If


        'oDistribucionNCMgr.ContratoAnticipoClienteNoCancelacionUpd(oDistribucionNC.Detalle)

        'oDistribucionNCMgr.ContratoMotivoCancelacionUpd(oDistribucionNC.ID, ebMotivo.Text)

        'oContratosMgr.ContratoCancelarAbonos(oContrato.ID)

        'oContratosMgr.ContratoCancelarUpdateInventario(oContrato.Detalle)


        'MsgBox("El Contrato ha sido Cancelado.", MsgBoxStyle.Information, "DPTienda")


        'Dim intAnticipoID As Integer

        'intAnticipoID = oDistribucionNC.ID

        'oDistribucionNC = Nothing
        'oDistribucionNC = oDistribucionNCMgr.LoadAnticipoCliente(intAnticipoID)

        'Sm_MostrarInformacion()

        'bolRegistroGuardado = True

    End Sub

#End Region

  
End Class
