Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoTarjetas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosDPVale
Imports Janus.Windows.GridEX
Imports DportenisPro.DPTienda.ApplicationUnits.PeriodoDetalleUI
Imports DportenisPro.DPTienda.ApplicationUnits.PeriodosUI


Public Class FrmAbonoDPVale
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

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
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents MnuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuArchivoEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuArchivo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents MnuArchivo3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents MnuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents uitnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents GridFormaPago As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents EBBanco As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EBIDBanco As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EBAutorizacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EBTipoTarj As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EBIDTipoTarj As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EBFormaPago As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EBPlazaCons As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EBAsociado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EBFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EBFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents CmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents EBIDAsociado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EBPagoMin As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EBPagoCom As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EBPago As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents EBNumTarj As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EBAbono As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents uitnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoFavor As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuArchivoEliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuArchivoEliminar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuUltimoMovimiento As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuUltimoMovimiento1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuOpciones As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuOpciones1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuUltimoMovimiento2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Ayuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Ayuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Ayuda2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EBReferencia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbBonificacion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtBonificacion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbMontoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAbonoDPVale))
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.MnuArchivo3 = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivo")
        Me.MnuOpciones1 = New Janus.Windows.UI.CommandBars.UICommand("MnuOpciones")
        Me.MnuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("MnuAyuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.MnuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivoNuevo")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivoGuardar")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuArchivoEliminar2 = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivoEliminar")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuUltimoMovimiento1 = New Janus.Windows.UI.CommandBars.UICommand("MnuUltimoMovimiento")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Ayuda2 = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.MnuArchivo = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivo")
        Me.MnuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivoNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivoGuardar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuArchivoEliminar1 = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivoEliminar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivoNuevo")
        Me.MnuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivoGuardar")
        Me.MnuArchivoEliminar = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivoEliminar")
        Me.MnuSalir = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuUltimoMovimiento = New Janus.Windows.UI.CommandBars.UICommand("MnuUltimoMovimiento")
        Me.MnuOpciones = New Janus.Windows.UI.CommandBars.UICommand("MnuOpciones")
        Me.MnuUltimoMovimiento2 = New Janus.Windows.UI.CommandBars.UICommand("MnuUltimoMovimiento")
        Me.MnuAyuda = New Janus.Windows.UI.CommandBars.UICommand("MnuAyuda")
        Me.Ayuda1 = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.Ayuda = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.EBReferencia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.EBPagoMin = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.EBIDAsociado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblSaldoFavor = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.uitnNuevo = New Janus.Windows.EditControls.UIButton()
        Me.EBNumTarj = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.EBPagoCom = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.EBPago = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.CmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.EBBanco = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.EBIDBanco = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EBAutorizacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.EBTipoTarj = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.EBIDTipoTarj = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.uitnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.EBFormaPago = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.nbMontoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbBonificacion = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtBonificacion = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.EBAbono = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GridFormaPago = New Janus.Windows.GridEX.GridEX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.EBPlazaCons = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EBAsociado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EBFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.EBFolio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.MnuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivo")
        Me.MnuArchivo2 = New Janus.Windows.UI.CommandBars.UICommand("MnuArchivo")
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        CType(Me.GridFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuArchivo, Me.MnuArchivoNuevo, Me.MnuArchivoGuardar, Me.MnuArchivoEliminar, Me.MnuSalir, Me.MnuUltimoMovimiento, Me.MnuOpciones, Me.MnuAyuda, Me.Ayuda})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("904d35f8-c8a3-4462-b871-b9b546d9609e")
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
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 246)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(504, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuArchivo3, Me.MnuOpciones1, Me.MnuAyuda1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(728, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'MnuArchivo3
        '
        Me.MnuArchivo3.Key = "MnuArchivo"
        Me.MnuArchivo3.Name = "MnuArchivo3"
        '
        'MnuOpciones1
        '
        Me.MnuOpciones1.Key = "MnuOpciones"
        Me.MnuOpciones1.Name = "MnuOpciones1"
        '
        'MnuAyuda1
        '
        Me.MnuAyuda1.Key = "MnuAyuda"
        Me.MnuAyuda1.Name = "MnuAyuda1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuArchivoNuevo2, Me.Separator3, Me.MnuArchivoGuardar2, Me.Separator5, Me.MnuArchivoEliminar2, Me.Separator6, Me.MnuUltimoMovimiento1, Me.Separator7, Me.Ayuda2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(426, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'MnuArchivoNuevo2
        '
        Me.MnuArchivoNuevo2.Key = "MnuArchivoNuevo"
        Me.MnuArchivoNuevo2.Name = "MnuArchivoNuevo2"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'MnuArchivoGuardar2
        '
        Me.MnuArchivoGuardar2.Key = "MnuArchivoGuardar"
        Me.MnuArchivoGuardar2.Name = "MnuArchivoGuardar2"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'MnuArchivoEliminar2
        '
        Me.MnuArchivoEliminar2.Key = "MnuArchivoEliminar"
        Me.MnuArchivoEliminar2.Name = "MnuArchivoEliminar2"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'MnuUltimoMovimiento1
        '
        Me.MnuUltimoMovimiento1.Key = "MnuUltimoMovimiento"
        Me.MnuUltimoMovimiento1.Name = "MnuUltimoMovimiento1"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'Ayuda2
        '
        Me.Ayuda2.Key = "Ayuda"
        Me.Ayuda2.Name = "Ayuda2"
        '
        'MnuArchivo
        '
        Me.MnuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuArchivoNuevo1, Me.Separator1, Me.MnuArchivoGuardar1, Me.Separator2, Me.MnuArchivoEliminar1, Me.Separator4, Me.MnuSalir1})
        Me.MnuArchivo.Key = "MnuArchivo"
        Me.MnuArchivo.Name = "MnuArchivo"
        Me.MnuArchivo.Text = "&Archivo"
        '
        'MnuArchivoNuevo1
        '
        Me.MnuArchivoNuevo1.Key = "MnuArchivoNuevo"
        Me.MnuArchivoNuevo1.Name = "MnuArchivoNuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'MnuArchivoGuardar1
        '
        Me.MnuArchivoGuardar1.Key = "MnuArchivoGuardar"
        Me.MnuArchivoGuardar1.Name = "MnuArchivoGuardar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'MnuArchivoEliminar1
        '
        Me.MnuArchivoEliminar1.Key = "MnuArchivoEliminar"
        Me.MnuArchivoEliminar1.Name = "MnuArchivoEliminar1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'MnuSalir1
        '
        Me.MnuSalir1.Key = "MnuSalir"
        Me.MnuSalir1.Name = "MnuSalir1"
        '
        'MnuArchivoNuevo
        '
        Me.MnuArchivoNuevo.Image = CType(resources.GetObject("MnuArchivoNuevo.Image"), System.Drawing.Image)
        Me.MnuArchivoNuevo.Key = "MnuArchivoNuevo"
        Me.MnuArchivoNuevo.Name = "MnuArchivoNuevo"
        Me.MnuArchivoNuevo.Text = "&Nuevo"
        '
        'MnuArchivoGuardar
        '
        Me.MnuArchivoGuardar.Image = CType(resources.GetObject("MnuArchivoGuardar.Image"), System.Drawing.Image)
        Me.MnuArchivoGuardar.Key = "MnuArchivoGuardar"
        Me.MnuArchivoGuardar.Name = "MnuArchivoGuardar"
        Me.MnuArchivoGuardar.Text = "&Guardar"
        '
        'MnuArchivoEliminar
        '
        Me.MnuArchivoEliminar.Image = CType(resources.GetObject("MnuArchivoEliminar.Image"), System.Drawing.Image)
        Me.MnuArchivoEliminar.Key = "MnuArchivoEliminar"
        Me.MnuArchivoEliminar.Name = "MnuArchivoEliminar"
        Me.MnuArchivoEliminar.Text = "&Eliminar"
        '
        'MnuSalir
        '
        Me.MnuSalir.Key = "MnuSalir"
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.Text = "&Salir"
        '
        'MnuUltimoMovimiento
        '
        Me.MnuUltimoMovimiento.Icon = CType(resources.GetObject("MnuUltimoMovimiento.Icon"), System.Drawing.Icon)
        Me.MnuUltimoMovimiento.Key = "MnuUltimoMovimiento"
        Me.MnuUltimoMovimiento.Name = "MnuUltimoMovimiento"
        Me.MnuUltimoMovimiento.Text = "Ultimo &Movimiento"
        '
        'MnuOpciones
        '
        Me.MnuOpciones.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuUltimoMovimiento2})
        Me.MnuOpciones.Key = "MnuOpciones"
        Me.MnuOpciones.Name = "MnuOpciones"
        Me.MnuOpciones.Text = "&Opciones"
        '
        'MnuUltimoMovimiento2
        '
        Me.MnuUltimoMovimiento2.Key = "MnuUltimoMovimiento"
        Me.MnuUltimoMovimiento2.Name = "MnuUltimoMovimiento2"
        '
        'MnuAyuda
        '
        Me.MnuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Ayuda1})
        Me.MnuAyuda.Key = "MnuAyuda"
        Me.MnuAyuda.Name = "MnuAyuda"
        Me.MnuAyuda.Text = "A&yuda"
        '
        'Ayuda1
        '
        Me.Ayuda1.Key = "Ayuda"
        Me.Ayuda1.Name = "Ayuda1"
        '
        'Ayuda
        '
        Me.Ayuda.Icon = CType(resources.GetObject("Ayuda.Icon"), System.Drawing.Icon)
        Me.Ayuda.Key = "Ayuda"
        Me.Ayuda.Name = "Ayuda"
        Me.Ayuda.Text = "Ay&uda"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 246)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(504, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 246)
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
        Me.TopRebar1.Size = New System.Drawing.Size(728, 50)
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.EBReferencia)
        Me.ExplorerBar1.Controls.Add(Me.EBPagoMin)
        Me.ExplorerBar1.Controls.Add(Me.EBIDAsociado)
        Me.ExplorerBar1.Controls.Add(Me.ExplorerBar2)
        Me.ExplorerBar1.Controls.Add(Me.ExplorerBar3)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.EBPlazaCons)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.EBAsociado)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.EBFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        Me.ExplorerBar1.Controls.Add(Me.EBFolio)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Abonos a DP Vale"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 48)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(730, 632)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'EBReferencia
        '
        Me.EBReferencia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBReferencia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBReferencia.BackColor = System.Drawing.Color.White
        Me.EBReferencia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBReferencia.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.EBReferencia.Location = New System.Drawing.Point(368, 96)
        Me.EBReferencia.MaxLength = 8
        Me.EBReferencia.Name = "EBReferencia"
        Me.EBReferencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EBReferencia.Size = New System.Drawing.Size(120, 22)
        Me.EBReferencia.TabIndex = 4
        Me.EBReferencia.Text = "0"
        Me.EBReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EBPagoMin
        '
        Me.EBPagoMin.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBPagoMin.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBPagoMin.BackColor = System.Drawing.Color.Ivory
        Me.EBPagoMin.Enabled = False
        Me.EBPagoMin.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBPagoMin.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBPagoMin.Location = New System.Drawing.Point(592, 96)
        Me.EBPagoMin.MaxLength = 8
        Me.EBPagoMin.Name = "EBPagoMin"
        Me.EBPagoMin.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EBPagoMin.Size = New System.Drawing.Size(120, 22)
        Me.EBPagoMin.TabIndex = 5
        Me.EBPagoMin.Text = "$0.00"
        Me.EBPagoMin.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBPagoMin.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EBIDAsociado
        '
        Me.EBIDAsociado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBIDAsociado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBIDAsociado.ButtonImage = CType(resources.GetObject("EBIDAsociado.ButtonImage"), System.Drawing.Image)
        Me.EBIDAsociado.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EBIDAsociado.DecimalDigits = 0
        Me.EBIDAsociado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBIDAsociado.Location = New System.Drawing.Point(96, 72)
        Me.EBIDAsociado.MaxLength = 4
        Me.EBIDAsociado.Name = "EBIDAsociado"
        Me.EBIDAsociado.Size = New System.Drawing.Size(80, 22)
        Me.EBIDAsociado.TabIndex = 2
        Me.EBIDAsociado.Text = "0"
        Me.EBIDAsociado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBIDAsociado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.lblSaldoFavor)
        Me.ExplorerBar2.Controls.Add(Me.Label14)
        Me.ExplorerBar2.Controls.Add(Me.uitnNuevo)
        Me.ExplorerBar2.Controls.Add(Me.EBNumTarj)
        Me.ExplorerBar2.Controls.Add(Me.Label13)
        Me.ExplorerBar2.Controls.Add(Me.EBPagoCom)
        Me.ExplorerBar2.Controls.Add(Me.EBPago)
        Me.ExplorerBar2.Controls.Add(Me.CmbFormaPago)
        Me.ExplorerBar2.Controls.Add(Me.Label12)
        Me.ExplorerBar2.Controls.Add(Me.EBBanco)
        Me.ExplorerBar2.Controls.Add(Me.Label11)
        Me.ExplorerBar2.Controls.Add(Me.EBIDBanco)
        Me.ExplorerBar2.Controls.Add(Me.EBAutorizacion)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Controls.Add(Me.EBTipoTarj)
        Me.ExplorerBar2.Controls.Add(Me.Label6)
        Me.ExplorerBar2.Controls.Add(Me.EBIDTipoTarj)
        Me.ExplorerBar2.Controls.Add(Me.Label8)
        Me.ExplorerBar2.Controls.Add(Me.uitnAgregar)
        Me.ExplorerBar2.Controls.Add(Me.EBFormaPago)
        Me.ExplorerBar2.Controls.Add(Me.Label9)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Captura de Forma de Pago"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar2.Location = New System.Drawing.Point(1, 128)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(399, 488)
        Me.ExplorerBar2.TabIndex = 17
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblSaldoFavor
        '
        Me.lblSaldoFavor.Location = New System.Drawing.Point(152, 68)
        Me.lblSaldoFavor.Name = "lblSaldoFavor"
        Me.lblSaldoFavor.Size = New System.Drawing.Size(120, 23)
        Me.lblSaldoFavor.TabIndex = 38
        Me.lblSaldoFavor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(8, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 23)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Saldo a Favor:"
        '
        'uitnNuevo
        '
        Me.uitnNuevo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uitnNuevo.Location = New System.Drawing.Point(56, 248)
        Me.uitnNuevo.Name = "uitnNuevo"
        Me.uitnNuevo.Size = New System.Drawing.Size(152, 23)
        Me.uitnNuevo.TabIndex = 36
        Me.uitnNuevo.Text = "Nuevo"
        Me.uitnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EBNumTarj
        '
        Me.EBNumTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBNumTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBNumTarj.BackColor = System.Drawing.Color.White
        Me.EBNumTarj.Enabled = False
        Me.EBNumTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBNumTarj.ForeColor = System.Drawing.Color.Black
        Me.EBNumTarj.Location = New System.Drawing.Point(152, 168)
        Me.EBNumTarj.MaxLength = 20
        Me.EBNumTarj.Name = "EBNumTarj"
        Me.EBNumTarj.Size = New System.Drawing.Size(240, 22)
        Me.EBNumTarj.TabIndex = 30
        Me.EBNumTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBNumTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.AccessibleDescription = "0"
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 168)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 14)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Número. de Tarjeta:"
        '
        'EBPagoCom
        '
        Me.EBPagoCom.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBPagoCom.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBPagoCom.BackColor = System.Drawing.Color.Ivory
        Me.EBPagoCom.Enabled = False
        Me.EBPagoCom.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBPagoCom.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBPagoCom.Location = New System.Drawing.Point(152, 216)
        Me.EBPagoCom.MaxLength = 8
        Me.EBPagoCom.Name = "EBPagoCom"
        Me.EBPagoCom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EBPagoCom.Size = New System.Drawing.Size(128, 22)
        Me.EBPagoCom.TabIndex = 34
        Me.EBPagoCom.Text = "$0.00"
        Me.EBPagoCom.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBPagoCom.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EBPago
        '
        Me.EBPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBPago.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBPago.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBPago.Location = New System.Drawing.Point(152, 96)
        Me.EBPago.MaxLength = 8
        Me.EBPago.Name = "EBPago"
        Me.EBPago.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EBPago.Size = New System.Drawing.Size(120, 22)
        Me.EBPago.TabIndex = 22
        Me.EBPago.Text = "$0.00"
        Me.EBPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'CmbFormaPago
        '
        Me.CmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbFormaPago.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbFormaPago.ForeColor = System.Drawing.Color.Black
        Me.CmbFormaPago.Items.AddRange(New Object() {"D", "E"})
        Me.CmbFormaPago.Location = New System.Drawing.Point(152, 40)
        Me.CmbFormaPago.MaxLength = 1
        Me.CmbFormaPago.Name = "CmbFormaPago"
        Me.CmbFormaPago.Size = New System.Drawing.Size(48, 22)
        Me.CmbFormaPago.Sorted = True
        Me.CmbFormaPago.TabIndex = 19
        '
        'Label12
        '
        Me.Label12.AccessibleDescription = "0"
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(138, 14)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Comisión por Tarjeta:"
        '
        'EBBanco
        '
        Me.EBBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBBanco.BackColor = System.Drawing.Color.Ivory
        Me.EBBanco.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBBanco.Enabled = False
        Me.EBBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBBanco.ForeColor = System.Drawing.Color.Black
        Me.EBBanco.Location = New System.Drawing.Point(232, 144)
        Me.EBBanco.Name = "EBBanco"
        Me.EBBanco.ReadOnly = True
        Me.EBBanco.Size = New System.Drawing.Size(160, 22)
        Me.EBBanco.TabIndex = 28
        Me.EBBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = "0"
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 144)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 14)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Banco:"
        '
        'EBIDBanco
        '
        Me.EBIDBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBIDBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBIDBanco.BackColor = System.Drawing.Color.White
        Me.EBIDBanco.ButtonImage = CType(resources.GetObject("EBIDBanco.ButtonImage"), System.Drawing.Image)
        Me.EBIDBanco.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EBIDBanco.Enabled = False
        Me.EBIDBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBIDBanco.ForeColor = System.Drawing.Color.Black
        Me.EBIDBanco.Location = New System.Drawing.Point(152, 144)
        Me.EBIDBanco.MaxLength = 4
        Me.EBIDBanco.Name = "EBIDBanco"
        Me.EBIDBanco.Size = New System.Drawing.Size(80, 22)
        Me.EBIDBanco.TabIndex = 27
        Me.EBIDBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBIDBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EBAutorizacion
        '
        Me.EBAutorizacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBAutorizacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBAutorizacion.BackColor = System.Drawing.Color.White
        Me.EBAutorizacion.Enabled = False
        Me.EBAutorizacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBAutorizacion.ForeColor = System.Drawing.Color.Black
        Me.EBAutorizacion.Location = New System.Drawing.Point(152, 192)
        Me.EBAutorizacion.MaxLength = 20
        Me.EBAutorizacion.Name = "EBAutorizacion"
        Me.EBAutorizacion.Size = New System.Drawing.Size(240, 22)
        Me.EBAutorizacion.TabIndex = 32
        Me.EBAutorizacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBAutorizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = "0"
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 14)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "No. Autorización:"
        '
        'EBTipoTarj
        '
        Me.EBTipoTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBTipoTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBTipoTarj.BackColor = System.Drawing.Color.Ivory
        Me.EBTipoTarj.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBTipoTarj.Enabled = False
        Me.EBTipoTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBTipoTarj.ForeColor = System.Drawing.Color.Black
        Me.EBTipoTarj.Location = New System.Drawing.Point(200, 120)
        Me.EBTipoTarj.Name = "EBTipoTarj"
        Me.EBTipoTarj.ReadOnly = True
        Me.EBTipoTarj.Size = New System.Drawing.Size(192, 22)
        Me.EBTipoTarj.TabIndex = 25
        Me.EBTipoTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBTipoTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = "0"
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 14)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Tipo de Tarjeta:"
        '
        'EBIDTipoTarj
        '
        Me.EBIDTipoTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBIDTipoTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBIDTipoTarj.BackColor = System.Drawing.Color.White
        Me.EBIDTipoTarj.ButtonImage = CType(resources.GetObject("EBIDTipoTarj.ButtonImage"), System.Drawing.Image)
        Me.EBIDTipoTarj.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EBIDTipoTarj.Enabled = False
        Me.EBIDTipoTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBIDTipoTarj.ForeColor = System.Drawing.Color.Black
        Me.EBIDTipoTarj.Location = New System.Drawing.Point(152, 120)
        Me.EBIDTipoTarj.MaxLength = 2
        Me.EBIDTipoTarj.Name = "EBIDTipoTarj"
        Me.EBIDTipoTarj.Size = New System.Drawing.Size(48, 22)
        Me.EBIDTipoTarj.TabIndex = 24
        Me.EBIDTipoTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBIDTipoTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = "0"
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 14)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Monto a Pagar:"
        '
        'uitnAgregar
        '
        Me.uitnAgregar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uitnAgregar.Location = New System.Drawing.Point(208, 248)
        Me.uitnAgregar.Name = "uitnAgregar"
        Me.uitnAgregar.Size = New System.Drawing.Size(152, 23)
        Me.uitnAgregar.TabIndex = 35
        Me.uitnAgregar.Text = "Agregar"
        Me.uitnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EBFormaPago
        '
        Me.EBFormaPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBFormaPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBFormaPago.BackColor = System.Drawing.Color.Ivory
        Me.EBFormaPago.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBFormaPago.Enabled = False
        Me.EBFormaPago.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBFormaPago.ForeColor = System.Drawing.Color.Black
        Me.EBFormaPago.Location = New System.Drawing.Point(200, 40)
        Me.EBFormaPago.Name = "EBFormaPago"
        Me.EBFormaPago.ReadOnly = True
        Me.EBFormaPago.Size = New System.Drawing.Size(192, 22)
        Me.EBFormaPago.TabIndex = 20
        Me.EBFormaPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBFormaPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = "0"
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 14)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Forma de Pago:"
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.Label16)
        Me.ExplorerBar3.Controls.Add(Me.nbMontoTotal)
        Me.ExplorerBar3.Controls.Add(Me.nbBonificacion)
        Me.ExplorerBar3.Controls.Add(Me.txtBonificacion)
        Me.ExplorerBar3.Controls.Add(Me.Label15)
        Me.ExplorerBar3.Controls.Add(Me.EBAbono)
        Me.ExplorerBar3.Controls.Add(Me.Label10)
        Me.ExplorerBar3.Controls.Add(Me.GridFormaPago)
        Me.ExplorerBar3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Detalle del Pago"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar3.Location = New System.Drawing.Point(400, 128)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(328, 488)
        Me.ExplorerBar3.TabIndex = 35
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label16
        '
        Me.Label16.AccessibleDescription = "0"
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(40, 248)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(151, 14)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "Monto total del abono:"
        '
        'nbMontoTotal
        '
        Me.nbMontoTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbMontoTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbMontoTotal.BackColor = System.Drawing.Color.Ivory
        Me.nbMontoTotal.Enabled = False
        Me.nbMontoTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbMontoTotal.ForeColor = System.Drawing.Color.Red
        Me.nbMontoTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbMontoTotal.Location = New System.Drawing.Point(200, 248)
        Me.nbMontoTotal.MaxLength = 8
        Me.nbMontoTotal.Name = "nbMontoTotal"
        Me.nbMontoTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.nbMontoTotal.Size = New System.Drawing.Size(112, 22)
        Me.nbMontoTotal.TabIndex = 43
        Me.nbMontoTotal.Text = "$0.00"
        Me.nbMontoTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nbMontoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbBonificacion
        '
        Me.nbBonificacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbBonificacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbBonificacion.BackColor = System.Drawing.Color.Ivory
        Me.nbBonificacion.Enabled = False
        Me.nbBonificacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbBonificacion.ForeColor = System.Drawing.Color.Red
        Me.nbBonificacion.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent
        Me.nbBonificacion.Location = New System.Drawing.Point(128, 272)
        Me.nbBonificacion.MaxLength = 8
        Me.nbBonificacion.Name = "nbBonificacion"
        Me.nbBonificacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.nbBonificacion.Size = New System.Drawing.Size(64, 22)
        Me.nbBonificacion.TabIndex = 42
        Me.nbBonificacion.Text = "0.00 %"
        Me.nbBonificacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nbBonificacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtBonificacion
        '
        Me.txtBonificacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtBonificacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtBonificacion.BackColor = System.Drawing.Color.Ivory
        Me.txtBonificacion.Enabled = False
        Me.txtBonificacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBonificacion.ForeColor = System.Drawing.Color.Red
        Me.txtBonificacion.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtBonificacion.Location = New System.Drawing.Point(200, 272)
        Me.txtBonificacion.MaxLength = 8
        Me.txtBonificacion.Name = "txtBonificacion"
        Me.txtBonificacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtBonificacion.Size = New System.Drawing.Size(112, 22)
        Me.txtBonificacion.TabIndex = 41
        Me.txtBonificacion.Text = "$0.00"
        Me.txtBonificacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtBonificacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.AccessibleDescription = "0"
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(44, 272)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 14)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Bonificación:"
        '
        'EBAbono
        '
        Me.EBAbono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBAbono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBAbono.BackColor = System.Drawing.Color.Ivory
        Me.EBAbono.Enabled = False
        Me.EBAbono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBAbono.ForeColor = System.Drawing.Color.Red
        Me.EBAbono.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBAbono.Location = New System.Drawing.Point(200, 224)
        Me.EBAbono.MaxLength = 8
        Me.EBAbono.Name = "EBAbono"
        Me.EBAbono.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EBAbono.Size = New System.Drawing.Size(112, 22)
        Me.EBAbono.TabIndex = 39
        Me.EBAbono.Text = "$0.00"
        Me.EBAbono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBAbono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.AccessibleDescription = "0"
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(40, 226)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 14)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Monto:"
        '
        'GridFormaPago
        '
        Me.GridFormaPago.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridFormaPago.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GridFormaPago.DesignTimeLayout = GridEXLayout1
        Me.GridFormaPago.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridFormaPago.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridFormaPago.GroupByBoxVisible = False
        Me.GridFormaPago.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GridFormaPago.Location = New System.Drawing.Point(16, 40)
        Me.GridFormaPago.Name = "GridFormaPago"
        Me.GridFormaPago.Size = New System.Drawing.Size(296, 176)
        Me.GridFormaPago.TabIndex = 37
        Me.GridFormaPago.TabStop = False
        Me.GridFormaPago.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridFormaPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.AccessibleDescription = "0"
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(296, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Referencia:"
        '
        'Label4
        '
        Me.Label4.AccessibleDescription = "0"
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Plaza y Consecutivo:"
        '
        'EBPlazaCons
        '
        Me.EBPlazaCons.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBPlazaCons.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBPlazaCons.BackColor = System.Drawing.Color.White
        Me.EBPlazaCons.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBPlazaCons.ForeColor = System.Drawing.Color.Black
        Me.EBPlazaCons.Location = New System.Drawing.Point(152, 96)
        Me.EBPlazaCons.MaxLength = 20
        Me.EBPlazaCons.Name = "EBPlazaCons"
        Me.EBPlazaCons.Size = New System.Drawing.Size(136, 22)
        Me.EBPlazaCons.TabIndex = 3
        Me.EBPlazaCons.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBPlazaCons.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = "0"
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(488, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 14)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Mínimo a pagar:"
        '
        'EBAsociado
        '
        Me.EBAsociado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBAsociado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBAsociado.BackColor = System.Drawing.Color.Ivory
        Me.EBAsociado.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBAsociado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.EBAsociado.Enabled = False
        Me.EBAsociado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBAsociado.ForeColor = System.Drawing.Color.Black
        Me.EBAsociado.Location = New System.Drawing.Point(176, 72)
        Me.EBAsociado.Name = "EBAsociado"
        Me.EBAsociado.ReadOnly = True
        Me.EBAsociado.Size = New System.Drawing.Size(536, 22)
        Me.EBAsociado.TabIndex = 8
        Me.EBAsociado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBAsociado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = "0"
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 14)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Asociado:"
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = "0"
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(512, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha:"
        '
        'EBFecha
        '
        Me.EBFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBFecha.BackColor = System.Drawing.Color.Ivory
        Me.EBFecha.Enabled = False
        Me.EBFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBFecha.ForeColor = System.Drawing.Color.Black
        Me.EBFecha.Location = New System.Drawing.Point(560, 48)
        Me.EBFecha.Name = "EBFecha"
        Me.EBFecha.Size = New System.Drawing.Size(152, 22)
        Me.EBFecha.TabIndex = 3
        Me.EBFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label18
        '
        Me.Label18.AccessibleDescription = "0"
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 23)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "No. Abono:"
        '
        'EBFolio
        '
        Me.EBFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBFolio.BackColor = System.Drawing.Color.Ivory
        Me.EBFolio.Enabled = False
        Me.EBFolio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBFolio.ForeColor = System.Drawing.Color.Red
        Me.EBFolio.Location = New System.Drawing.Point(96, 48)
        Me.EBFolio.MaxLength = 4
        Me.EBFolio.Name = "EBFolio"
        Me.EBFolio.Size = New System.Drawing.Size(80, 22)
        Me.EBFolio.TabIndex = 1
        Me.EBFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'MnuArchivo1
        '
        Me.MnuArchivo1.Key = "MnuArchivo"
        Me.MnuArchivo1.Name = "MnuArchivo1"
        '
        'MnuArchivo2
        '
        Me.MnuArchivo2.Key = "MnuArchivo"
        Me.MnuArchivo2.Name = "MnuArchivo2"
        '
        'FrmAbonoDPVale
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(728, 501)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmAbonoDPVale"
        Me.Text = "Abono d'portenis Vale"
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ExplorerBar2.PerformLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        Me.ExplorerBar3.PerformLayout()
        CType(Me.GridFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

    Private oAbonoDPVale As AbonoDPVale
    Private oAbonoDPValeMgr As AbonosDPValeManager
    Private dsDataSet As DataSet

    Private oClientesMgr As ClientesManager
    Private oCliente As Clientes

    Private oAsociadosMgr As AsociadosManager
    Private oAsociado As Asociado

    Private oCatalogoTipoTarjetasMgr As CatalogoTipoTarjetasManager
    Private oTipoTarjeta As TipoTarjeta

    Private oCatalogoBancosMgr As CatalogoBancosManager
    Private oBancos As Bancos

    Private oPorcComision As Decimal
    Private oIDCliente As Integer

    Private oPeriodoDetalle As PeriodoDetalle
    Private oPeriodoDetalleMgr As PeriodoDetalleManager

    Private oPeriodo As Periodos
    Private oPeriodoMgr As PeriodosManager



    Private SaldoFavor As Decimal
    Private ComisionBancaria As Decimal
#End Region

#Region "Inicializa Objetos"

    Private Sub InitializeObjects()

        oAbonoDPValeMgr = New AbonosDPValeManager(oAppContext)

        oClientesMgr = New ClientesManager(oAppContext)
        oCliente = oClientesMgr.Create
        oCliente.Clear()

        oAsociadosMgr = New AsociadosManager(oAppContext)
        oAsociado = oAsociadosMgr.Create
        oAsociado.Clear()

        oCatalogoTipoTarjetasMgr = New CatalogoTipoTarjetasManager(oAppContext)
        oCatalogoBancosMgr = New CatalogoBancosManager(oAppContext)

    End Sub

    Private Sub BuildFormasPagoDataset()

        dsDataSet = New DataSet("FormasPago")
        Dim dtFormasPago As New DataTable("FormasPago")

        Dim dcIDFormaPago As New DataColumn
        With dcIDFormaPago
            .ColumnName = "IDFormaPago"
            .Caption = "ID Forma de Pago"
            .DataType = GetType(System.String)
            .MaxLength = 1
            .DefaultValue = String.Empty
        End With

        Dim dcFormaPago As New DataColumn
        With dcFormaPago
            .ColumnName = "FormaPago"
            .Caption = "Forma de Pago"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcMonto As New DataColumn
        With dcMonto
            .ColumnName = "Monto"
            .Caption = "Monto"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
        End With

        Dim dcIDTipoTarjeta As New DataColumn
        With dcIDTipoTarjeta
            .ColumnName = "IDTipoTarjeta"
            .Caption = "ID Tipo de Tarjeta"
            .DataType = GetType(System.String)
            .MaxLength = 2
            .DefaultValue = String.Empty
        End With

        Dim dcTipoTarjeta As New DataColumn
        With dcTipoTarjeta
            .ColumnName = "TipoTarjeta"
            .Caption = "Tipo de Tarjeta"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcIDBanco As New DataColumn
        With dcIDBanco
            .ColumnName = "IDBanco"
            .Caption = "ID Banco"
            .DataType = GetType(System.String)
            .MaxLength = 4
            .DefaultValue = String.Empty
        End With

        Dim dcBanco As New DataColumn
        With dcBanco
            .ColumnName = "Banco"
            .Caption = "Banco"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcNumTarjeta As New DataColumn
        With dcNumTarjeta
            .ColumnName = "NumTarjeta"
            .Caption = "Num. de Tarjeta"
            .DataType = GetType(System.String)
            .MaxLength = 20
            .DefaultValue = String.Empty
        End With

        Dim dcNumAutorizacion As New DataColumn
        With dcNumAutorizacion
            .ColumnName = "NumAutorizacion"
            .Caption = "Num. de Autorizacion"
            .DataType = GetType(System.String)
            .MaxLength = 20
            .DefaultValue = String.Empty
        End With

        Dim dcComision As New DataColumn
        With dcComision
            .ColumnName = "Comision"
            .Caption = "Comision"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
        End With

        Dim dcTotal As New DataColumn
        With dcTotal
            .ColumnName = "Total"
            .Caption = "Total"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
        End With

        Dim dcUsuario As New DataColumn
        With dcUsuario
            .ColumnName = "Usuario"
            .Caption = "Usuario"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcFecha As New DataColumn
        With dcFecha
            .ColumnName = "Fecha"
            .Caption = "Fecha"
            .DataType = GetType(System.DateTime)
            .DefaultValue = Date.Today
        End With

        Dim dcStatusRegistro As New DataColumn
        With dcStatusRegistro
            .ColumnName = "StatusRegistro"
            .Caption = "StatusRegistro"
            .DataType = GetType(System.Boolean)
            .DefaultValue = True
        End With

        With dtFormasPago.Columns
            .Add(dcIDFormaPago)
            .Add(dcFormaPago)
            .Add(dcMonto)
            .Add(dcIDTipoTarjeta)
            .Add(dcTipoTarjeta)
            .Add(dcIDBanco)
            .Add(dcBanco)
            .Add(dcNumTarjeta)
            .Add(dcNumAutorizacion)
            .Add(dcComision)
            .Add(dcTotal)
            .Add(dcUsuario)
            .Add(dcFecha)
            .Add(dcStatusRegistro)
        End With

        dsDataSet.Tables.Add(dtFormasPago)

        GridFormaPago.SetDataBinding(dsDataSet, "FormasPago")
    End Sub
#End Region

#Region "Metedos de Limpieza"


    ''Sm_EliminarAbono2 ya no se usa
    Private Sub Sm_EliminarAbono2()

        If oAbonoDPVale.AsociadoID = 0 Then
            MessageBox.Show("El abono no puede ser cancelado", "DPTienda", MessageBoxButtons.OK)
            Exit Sub
        End If

        If (MessageBox.Show("Se encuentra seguro de Eliminar el Abono", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
            Exit Sub
        End If

        oAbonoDPVale.SaldoAnt = oAsociado.SaldoDPVale
        oAbonoDPVale.SaldNuevo = oAsociado.SaldoDPVale
        oAbonoDPVale.MontoPago = 0
        dsDataSet.Tables("FormasPago").Rows.Clear()
        dsDataSet.AcceptChanges()
        oAbonoDPVale.Detalle = dsDataSet
        oAbonoDPVale.SaldoDPVale = oAsociado.SaldoDPVale
        oAbonoDPVale.AsociadoID = oAsociado.AsociadoID
        EBAbono.Value = 0
        Me.txtBonificacion.Text = 0

        oAbonoDPVale.Save()

        MessageBox.Show("La información ha sido Eliminada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.UiCommandManager1.Commands.Item("MnuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("MnuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        LimpiaPantalla()
    End Sub

    Private Sub LimpiaPantalla()
        EBFolio.Text = String.Empty
        EBIDAsociado.Value = 0
        EBAsociado.Text = String.Empty
        EBPlazaCons.Text = String.Empty
        EBReferencia.Text = String.Empty
        EBPagoMin.Value = 0
        CmbFormaPago.Text = String.Empty
        EBFormaPago.Text = String.Empty
        EBPago.Value = 0
        EBIDTipoTarj.Text = String.Empty
        EBTipoTarj.Text = String.Empty
        EBIDBanco.Text = String.Empty
        EBBanco.Text = String.Empty
        EBNumTarj.Text = String.Empty
        EBAutorizacion.Text = String.Empty
        EBPagoCom.Value = 0
        oPorcComision = 0
        dsDataSet.Tables("FormasPago").Clear()
        dsDataSet.AcceptChanges()
        BuildFormasPagoDataset()
        EBAbono.Value = 0
        Me.txtBonificacion.Text = 0
        Me.EBReferencia.Enabled = True
        EBIDAsociado.Focus()
        Me.GridFormaPago.Enabled = True
        Me.ExplorerBar2.Enabled = True
        Me.nbMontoTotal.Value = 0
        Me.EBReferencia.Enabled = True

        CmbFormaPago.Items.Remove("E")
        CmbFormaPago.Items.Add("E")


        Me.UiCommandManager1.Commands.Item("MnuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("MnuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
    End Sub

    Private Sub LimpiaDatCaptFP()
        CmbFormaPago.Text = String.Empty
        EBFormaPago.Text = String.Empty
        EBPago.Text = 0
        EBIDTipoTarj.Text = String.Empty
        EBTipoTarj.Text = String.Empty
        EBIDBanco.Text = String.Empty
        EBBanco.Text = String.Empty
        EBNumTarj.Text = String.Empty
        EBAutorizacion.Text = String.Empty
        EBPagoCom.Text = 0
        oPorcComision = 0
        CmbFormaPago.Focus()
    End Sub

#End Region

#Region "Metodos de Busqueda"

    Private Sub UltimoMovimiento()
        If EBIDAsociado.Value > 0 Then

            oAsociado.Clear()
            'oAbonoDPVale = oAbonoDPValeMgr.GetUltimoAbono("001", EBIDAsociado.Value)
            If Not (oAbonoDPVale Is Nothing) Then
                If (oAbonoDPVale.StatusRegistro = True) Then

                    Me.EBFolio.Text = oAbonoDPVale.IDAbono
                    Me.EBIDAsociado.Text = oAbonoDPVale.AsociadoID
                    oAsociadosMgr.LoadInto(Me.EBIDAsociado.Text, oAsociado)
                    oIDCliente = oAsociado.ClienteID
                    If oAsociado.ClienteID <> 0 Then
                        oCliente.Clear()
                        oClientesMgr.LoadInto(oAsociado.ClienteID, oCliente)
                        If Not (oCliente.ClienteID = 0) Then
                            LimpiaPantalla()
                            Me.EBFolio.Text = oAbonoDPVale.IDAbono
                            EBIDAsociado.Text = oAsociado.AsociadoID
                            EBAsociado.Text = oCliente.Nombre & Space(1) & oCliente.ApellidoPaterno & Space(1) & oCliente.ApellidoMaterno
                            oAsociado.SaldoDPVale = oAbonoDPVale.SaldoAnt
                            Me.EBPagoMin.Text = oAbonoDPVale.PagoMin
                            Me.EBPlazaCons.Text = oAbonoDPVale.PlazaConsecutivo
                            Me.EBReferencia.Text = oAbonoDPVale.Referencia
                            Me.EBReferencia.Enabled = False
                        End If
                    End If
                    Me.dsDataSet = oAbonoDPVale.Detalle.Copy

                    For Each row As DataRow In dsDataSet.Tables("FormasPago").Rows
                        If row("FormaPago") = "E" Then
                            row("FormaPago") = "EFECTIVO"
                        ElseIf row("FormaPago") = "T" Then
                            row("FormaPago") = "TARJETA DE CRÉDITO"
                        ElseIf row("FormaPago") = "D" Then
                            row("FormaPago") = "TARJETA DE DÉBITO"
                        ElseIf row("FormaPago") = "B" Then
                            row("FormaPago") = "BONIFICACION"
                            Me.txtBonificacion.Value = row("Total")
                            Me.nbMontoTotal.Value = Me.EBPagoMin.Value - txtBonificacion.Value
                            Me.nbBonificacion.Value = (Me.EBPagoMin.Value - Me.nbMontoTotal.Value) / Me.EBPagoMin.Value
                            oAbonoDPVale.Bonificacion = Me.txtBonificacion.Value
                        Else
                            row("FormaPago") = "SALDO A FAVOR"
                        End If
                    Next

                    Me.EBAbono.Value = oAbonoDPVale.MontoPago - oAbonoDPVale.Bonificacion

                    Me.GridFormaPago.SetDataBinding(dsDataSet, "FormasPago")

                    Me.UiCommandManager1.Commands.Item("MnuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.False
                    Me.UiCommandManager1.Commands.Item("MnuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.True
                    Me.GridFormaPago.Enabled = False
                    Me.ExplorerBar2.Enabled = False
                Else
                    MessageBox.Show("El último abono ya fue cancelado.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("El último abono ya fue cancelado.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Capture el Identificador del Asociado.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Sm_BuscarAsociado(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        oIDCliente = 0
        If ((Vpa_bolOpenRecordDialog = True) Or (EBIDAsociado.Text = 0)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            oOpenRecordDlg.CurrentView = New AsociadosCreditoDPOpenRecordDialogView
            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                oAsociado.Clear()
                oAsociadosMgr.LoadInto(oOpenRecordDlg.Record.Item("AsociadoID"), oAsociado)

                EBIDAsociado.Text = oAsociado.AsociadoID
                oIDCliente = oAsociado.ClienteID
                If oAsociado.ClienteID <> 0 Then
                    oCliente.Clear()
                    oClientesMgr.LoadInto(oAsociado.ClienteID, oCliente)
                    If Not (oCliente.ClienteID = 0) Then
                        oAbonoDPVale = Nothing
                        LimpiaPantalla()
                        EBIDAsociado.Text = oAsociado.AsociadoID
                        EBAsociado.Text = oCliente.Nombre & Space(1) & oCliente.ApellidoPaterno & Space(1) & oCliente.ApellidoMaterno
                        Me.EBPlazaCons.Text = oCliente.CodPlaza & oAsociado.AsociadoID
                        'Me.EBPagoMin.Value = oAsociado.SaldoDPVale / 4
                        'oAsociado.ResetFlagNew()
                        Me.UiCommandManager1.Commands.Item("MnuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.True
                        Me.UiCommandManager1.Commands.Item("MnuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
                    Else
                        MessageBox.Show("El código capturado no se encuentra dado de alta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Else
            oAsociado.Clear()
            oAsociadosMgr.LoadInto(EBIDAsociado.Text, oAsociado)
            EBIDAsociado.Text = oAsociado.AsociadoID
            oIDCliente = oAsociado.ClienteID
            If oAsociado.ClienteID <> 0 Then
                oCliente.Clear()
                oClientesMgr.LoadInto(oAsociado.ClienteID, oCliente)
                If Not (oCliente.ClienteID = 0) Then
                    oAbonoDPVale = Nothing
                    LimpiaPantalla()
                    EBIDAsociado.Text = oAsociado.AsociadoID
                    EBAsociado.Text = oCliente.Nombre & Space(1) & oCliente.ApellidoPaterno & Space(1) & oCliente.ApellidoMaterno
                    Me.EBPlazaCons.Text = oCliente.CodPlaza & oAsociado.AsociadoID
                    'Me.EBPagoMin.Value = oAsociado.SaldoDPVale / 4
                    Me.UiCommandManager1.Commands.Item("MnuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.True
                    Me.UiCommandManager1.Commands.Item("MnuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
                    'oAsociado.ResetFlagNew()
                Else
                    MessageBox.Show("El código capturado no se encuentra dado de alta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub Sm_BuscarTT(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (EBIDTipoTarj.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            oOpenRecordDlg.CurrentView = New CatalogoTipoTarjetasOpenRecordDialogView
            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oTipoTarjeta = Nothing
                oTipoTarjeta = oCatalogoTipoTarjetasMgr.Load(oOpenRecordDlg.Record.Item("CodTipoTarjeta"))

                EBIDTipoTarj.Text = oTipoTarjeta.ID
                EBTipoTarj.Text = oTipoTarjeta.Descripcion

            End If

        Else

            On Error Resume Next

            oTipoTarjeta = Nothing
            oTipoTarjeta = oCatalogoTipoTarjetasMgr.Load(EBIDTipoTarj.Text.Trim)

            If oTipoTarjeta.IsDirty Then
                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                EBIDTipoTarj.Text = oTipoTarjeta.ID
                EBTipoTarj.Text = oTipoTarjeta.Descripcion
            End If

        End If

    End Sub

    Private Sub Sm_BuscarBanc(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (EBIDBanco.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            oOpenRecordDlg.CurrentView = New CatalogoBancosOpenRecordDialogView
            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next
                oBancos = Nothing
                oBancos = oCatalogoBancosMgr.Load(oOpenRecordDlg.Record.Item("CodBanco"))

                EBIDBanco.Text = oBancos.ID
                EBBanco.Text = oBancos.Descripcion

            End If

        Else

            On Error Resume Next

            oBancos = Nothing
            oBancos = oCatalogoBancosMgr.Load(EBIDBanco.Text.Trim)

            If oBancos.IsDirty Then
                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                EBIDBanco.Text = oBancos.ID
                EBBanco.Text = oBancos.Descripcion
            End If
        End If

    End Sub
#End Region

#Region "Métodos De Controles"

    Private Sub FrmAbonoDPVale_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeObjects()
        BuildFormasPagoDataset()
        Me.UiCommandManager1.Commands.Item("MnuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("MnuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.EBFecha.Text = Date.Today
        Me.CmbFormaPago.Text = "E"
        Me.EBFormaPago.Text = "EFECTIVO"
        Me.ExplorerBar3.Enabled = False
    End Sub

    Private Sub CmbFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFormaPago.SelectedIndexChanged
        FormadePago()
    End Sub

    Private Sub CmbFormaPago_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CmbFormaPago.Validating
        FormadePago()
    End Sub

    Private Sub FrmAbonoDPVale_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        oTipoTarjeta = Nothing
        oCatalogoTipoTarjetasMgr.dispose()
        oCatalogoTipoTarjetasMgr = Nothing

        oBancos = Nothing
        oCatalogoBancosMgr.Dispose()
        oCatalogoBancosMgr = Nothing

    End Sub

    Private Sub EBIDTipoTarj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EBIDTipoTarj.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then
            Sm_BuscarTT(True)
        ElseIf e.KeyCode = Keys.Enter Then
            Sm_BuscarTT()
        End If
    End Sub

    Private Sub EBIDBanco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EBIDBanco.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then
            Sm_BuscarBanc(True)
        ElseIf e.KeyCode = Keys.Enter Then
            Sm_BuscarBanc()
        End If
    End Sub

    Private Sub EBIDAsociado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EBIDAsociado.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then
            Sm_BuscarAsociado(True)
        ElseIf e.KeyCode = Keys.Enter Then
            Sm_BuscarAsociado()
        End If
    End Sub

    Private Sub EBIDAsociado_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBIDAsociado.ButtonClick
        Sm_BuscarAsociado(True)
    End Sub

    Private Sub EBIDBanco_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBIDBanco.ButtonClick
        Sm_BuscarBanc(True)
    End Sub

    Private Sub EBIDTipoTarj_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBIDTipoTarj.ButtonClick
        Sm_BuscarTT(True)
    End Sub

    Private Sub uitnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uitnAgregar.Click

        '<Validación>
        If (Fm_bolTxtValidarFP() = False) Then
            Exit Sub
        End If
        '</Validación>


        ComisionBancaria += EBPagoCom.Value
        Dim drRow As DataRow

        drRow = dsDataSet.Tables("FormasPago").NewRow

        drRow("IDFormaPago") = CmbFormaPago.Text
        drRow("FormaPago") = EBFormaPago.Text
        drRow("Monto") = EBPago.Value
        drRow("IDTipoTarjeta") = EBIDTipoTarj.Text
        drRow("TipoTarjeta") = EBTipoTarj.Text
        drRow("IDBanco") = EBIDBanco.Text
        drRow("Banco") = EBBanco.Text
        drRow("NumTarjeta") = EBNumTarj.Text
        drRow("NumAutorizacion") = EBAutorizacion.Text
        drRow("Comision") = EBPagoCom.Value
        drRow("Total") = EBPago.Value + EBPagoCom.Value



        drRow("Usuario") = oAppContext.Security.CurrentUser.Name
        drRow("Fecha") = Date.Today
        drRow("StatusRegistro") = True

        dsDataSet.Tables("FormasPago").Rows.Add(drRow)
        dsDataSet.AcceptChanges()

        If CmbFormaPago.Text = "S" Then
            oAsociado.SaldoDPVale -= EBPago.Value
        Else
            'Me.txtBonificacion.Text += EBPago.Value + EBPagoCom.Value
        End If


        If CmbFormaPago.Text = "E" Then
            CmbFormaPago.Items.Remove("E")
        End If

        EBAbono.Value = EBAbono.Value + (EBPago.Value + EBPagoCom.Value)

        LimpiaDatCaptFP()
        Me.ExplorerBar3.Enabled = True

    End Sub

    Private Sub EBPago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBPago.LostFocus
        EBPagoCom.Value = CDbl(EBPago.Value) * (CDbl(oPorcComision) / 100)
    End Sub

    Private Sub GridFormaPago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridFormaPago.Click
        Try
            Dim oCurrentRow As GridEXRow
            Dim odrDataRow As DataRowView

            oCurrentRow = GridFormaPago.GetRow()

            odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

            With odrDataRow
                CmbFormaPago.Text = .Item(0)
                EBFormaPago.Text = .Item(1)
                EBPago.Value = .Item(2)
                EBIDTipoTarj.Text = .Item(3)
                EBTipoTarj.Text = .Item(4)
                EBIDBanco.Text = .Item(5)
                EBBanco.Text = .Item(6)
                EBNumTarj.Text = .Item(7)
                EBAutorizacion.Text = .Item(8)
                EBPagoCom.Value = .Item(9)
            End With

            oCurrentRow = Nothing
            odrDataRow = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub uitnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uitnNuevo.Click
        LimpiaDatCaptFP()
    End Sub

    Private Sub GridFormaPago_RecordsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridFormaPago.RecordsDeleted

        If EBFormaPago.Text = "EFECTIVO" Then
            CmbFormaPago.Items.Add("E")
        End If

        If Me.CmbFormaPago.Text = "S" Then
            oAsociado.SaldoDPVale += Me.EBPago.Text
        Else
            'Me.txtBonificacion.Text -= EBPago.Value
        End If

        EBAbono.Value = EBAbono.Value - (EBPago.Value + EBPagoCom.Value)
        If Me.CmbFormaPago.Text = "T" Or Me.CmbFormaPago.Text = "D" Then
            ComisionBancaria -= EBPagoCom.Value
        End If

        If GridFormaPago.RowCount = 0 Then
            Me.ExplorerBar3.Enabled = False
        End If
        LimpiaDatCaptFP()
    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key
            Case "MnuArchivoNuevo"
                LimpiaPantalla()
            Case "MnuArchivoGuardar"
                Sm_GuardarAbono()
            Case "MnuArchivoEliminar"
                Sm_EliminarAbono()
            Case "MnuUltimoMovimiento"
                UltimoMovimiento()
            Case "MnuSalir"
                Me.Close()
        End Select
    End Sub

#End Region

#Region "Metodos de Almacenamiento"
    Private Sub Sm_EliminarAbono()
        If (MessageBox.Show("Se encuentra seguro de Cancelar el Abono", "DPTienda", MessageBoxButtons.OKCancel, _
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
            Exit Sub
        End If

        'oAbonoDPValeMgr.Delete(oAbonoDPVale)

        If oPeriodoDetalle Is Nothing Then
            oPeriodoDetalleMgr = New PeriodoDetalleManager(oAppContext)
            oPeriodoDetalle = oPeriodoDetalleMgr.Create
        End If

        oPeriodoDetalle.Liquidado = False
        oPeriodoDetalle.PagoMinimo = Me.EBPagoMin.Value
        'oPeriodoDetalle.Fecha = Now.Date
        oPeriodoDetalle.NumPeriodo = Me.EBReferencia.Value
        oPeriodoDetalle.Liquidar(Me.EBIDAsociado.Value)

        MessageBox.Show("La información ha sido Eliminada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LimpiaPantalla()
    End Sub

    Private Sub Sm_GuardarAbono()

        If (Fm_bolTxtValidar() = False) Then
            Exit Sub
        End If

        If (oAbonoDPVale Is Nothing) Then

            If (MessageBox.Show("Se encuentra seguro de Guardar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                Exit Sub
            End If

            If Me.txtBonificacion.Value > 0 Then
                Dim drRow As DataRow

                drRow = dsDataSet.Tables("FormasPago").NewRow

                drRow("IDFormaPago") = "B"
                drRow("FormaPago") = "Bonificacion"
                drRow("Monto") = Me.txtBonificacion.Value
                drRow("IDTipoTarjeta") = ""
                drRow("TipoTarjeta") = ""
                drRow("IDBanco") = ""
                drRow("Banco") = ""
                drRow("NumTarjeta") = ""
                drRow("NumAutorizacion") = ""
                drRow("Comision") = 0.0
                drRow("Total") = Me.txtBonificacion.Value
                drRow("Usuario") = oAppContext.Security.CurrentUser.Name
                drRow("Fecha") = Date.Today
                drRow("StatusRegistro") = True

                dsDataSet.Tables("FormasPago").Rows.Add(drRow)
                dsDataSet.AcceptChanges()

            End If

            oAbonoDPVale = Nothing
            oAbonoDPVale = oAbonoDPValeMgr.Create

            oAbonoDPVale.AsociadoID = EBIDAsociado.Text
            oAbonoDPVale.IDCliente = oIDCliente
            oAbonoDPVale.CodSegCred = "001"
            oAbonoDPVale.CodTipAbono = 1
            oAbonoDPVale.SaldoAnt = oAsociado.SaldoDPVale
            oAbonoDPVale.PagoMin = EBPagoMin.Value
            oAbonoDPVale.MontoPago = EBPagoMin.Value 'EBAbono.Value
            oAbonoDPVale.SaldNuevo = oAsociado.SaldoDPVale - EBPagoMin.Value '+ (ComisionBancaria - Me.EBPagoCom.Value)
            oAbonoDPVale.StatusRegistro = True
            oAbonoDPVale.SetUsuario(oAppContext.Security.CurrentUser.Name)
            oAbonoDPVale.SetCodAlmacen(oAppContext.ApplicationConfiguration.Almacen)
            oAbonoDPVale.SetCodCaja(oAppContext.ApplicationConfiguration.NoCaja)
            oAbonoDPVale.SaldoDPVale = oAsociado.SaldoDPVale - Me.txtBonificacion.Value
            oAbonoDPVale.AsociadoID = oAsociado.AsociadoID
            oAbonoDPVale.PlazaConsecutivo = Me.EBPlazaCons.Text
            oAbonoDPVale.Referencia = Me.EBReferencia.Text
            oAbonoDPVale.Bonificacion = Me.txtBonificacion.Value

            oAbonoDPVale.Detalle = dsDataSet


            oAbonoDPVale.Save()

            oPeriodoDetalle.Liquidado = True
            'oPeriodoDetalle.Fecha = Now.Date
            oPeriodoDetalle.Liquidar(Me.EBIDAsociado.Value)

            EBFolio.Text = oAbonoDPVale.IDAbono
            Sm_ActionPrintReporteAbonosApartados()

            MessageBox.Show("La información ha sido Guardada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.UiCommandManager1.Commands.Item("MnuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.UiCommandManager1.Commands.Item("MnuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.True
        End If
    End Sub
#End Region

#Region "Metodos de Validacion"

    Private Sub ActivaDatTC(ByVal Valor As Boolean)
        If Valor = False Then
            EBIDTipoTarj.Text = String.Empty
            EBTipoTarj.Text = String.Empty
            EBIDBanco.Text = String.Empty
            EBBanco.Text = String.Empty
            EBNumTarj.Text = String.Empty
            EBAutorizacion.Text = String.Empty
            EBPagoCom.Text = 0
        End If
        EBIDTipoTarj.Enabled = Valor
        EBIDBanco.Enabled = Valor
        EBNumTarj.Enabled = Valor
        EBAutorizacion.Enabled = Valor
    End Sub

    Private Sub FormadePago()
        Select Case CmbFormaPago.Text
            Case "T"
                Me.EBFormaPago.Text = "TARJETA DE CRÉDITO"
                oPorcComision = oAbonoDPValeMgr.ApplicationContext.ApplicationConfiguration.ComisionTarjetaCredito
                EBPagoCom.Value = CDbl(EBPago.Value) * (CDbl(oPorcComision) / 100)
                ActivaDatTC(True)
                Me.EBPago.Value = Me.nbMontoTotal.Value - Me.EBAbono.Value
            Case "D"
                'Me.EBFormaPago.Text = "TARJETA DE DÉBITO"
                Me.EBFormaPago.Text = "TARJETA BANCARIA"
                ActivaDatTC(True)
                oPorcComision = oAbonoDPValeMgr.ApplicationContext.ApplicationConfiguration.ComisionTarjetaDebito
                Me.EBIDTipoTarj.Text = "TE"
                Me.EBTipoTarj.Text = "TARJETA ELECTRÓNICA"
                Me.EBIDTipoTarj.Enabled = True
                Me.EBPago.Value = Me.nbMontoTotal.Value - Me.EBAbono.Value
                EBPagoCom.Value = CDbl(EBPago.Value) * (CDbl(oPorcComision) / 100)
                
            Case "E"
                Me.EBFormaPago.Text = "EFECTIVO"
                oPorcComision = 0
                ActivaDatTC(False)
                Me.EBPago.Value = Me.nbMontoTotal.Value - Me.EBAbono.Value
            Case "S"
                Me.EBFormaPago.Text = "SALDO A FAVOR"
                oPorcComision = 0
                ActivaDatTC(False)
                Me.EBPago.Value = Me.nbMontoTotal.Value - Me.EBAbono.Value
                Me.lblSaldoFavor.Text = Format(oAsociado.SaldoDPVale, "$###,###,###.#0")
        End Select
    End Sub

    Private Function Fm_bolTxtValidarFP() As Boolean
        If EBFormaPago.Text = String.Empty Then
            MsgBox("No ha seleccionado la forma de pago.", MsgBoxStyle.Exclamation, "DPTienda")
            CmbFormaPago.Focus()
            Exit Function
        End If
        If EBPago.Text = 0 Then
            MsgBox("No ha especificado el monto del pago.", MsgBoxStyle.Exclamation, "DPTienda")
            EBPago.Focus()
            Exit Function
        End If

        If (Me.EBAbono.Value + EBPago.Value) - ComisionBancaria > Me.nbMontoTotal.Value Then
            MsgBox("El abono no puede ser mayor a Monto total del abono", MsgBoxStyle.Exclamation, "DPTienda")
            Me.CmbFormaPago.Focus()
            Exit Function
        End If

        If (Me.EBAbono.Value + EBPago.Value) - ComisionBancaria > oAsociado.SaldoDPVale Then
            MsgBox("El abono no puede mayor que el Saldo del Asociado. Saldo Deportenis Vale = " & Format(oAsociado.SaldoDPVale, "$###,###,###.#0"), MsgBoxStyle.Exclamation, "DPTienda")
            EBPago.Focus()
            Exit Function
        End If

        If CmbFormaPago.Text = "T" Or CmbFormaPago.Text = "D" Then
            If EBTipoTarj.Text = String.Empty Then
                MsgBox("No ha especificado el tipo de tarjeta.", MsgBoxStyle.Exclamation, "DPTienda")
                EBIDTipoTarj.Focus()
                Exit Function
            End If
            If EBBanco.Text = String.Empty Then
                MsgBox("No ha especificado el banco de la tarjeta.", MsgBoxStyle.Exclamation, "DPTienda")
                EBIDBanco.Focus()
                Exit Function
            End If
            If EBNumTarj.Text = String.Empty Then
                MsgBox("No ha especificado el numero de tarjeta.", MsgBoxStyle.Exclamation, "DPTienda")
                EBNumTarj.Focus()
                Exit Function
            End If
            If EBAutorizacion.Text = String.Empty Then
                MsgBox("No ha especificado el numero de autorización.", MsgBoxStyle.Exclamation, "DPTienda")
                EBAutorizacion.Focus()
                Exit Function
            End If
        End If

        If (Me.EBAbono.Value + EBPago.Value) - ComisionBancaria = Me.nbMontoTotal.Value Then
            MessageBox.Show("Se cubrió el monto total del abono", "DPTienda", MessageBoxButtons.OK)
        End If

        Return True
    End Function

    Private Function Fm_bolTxtValidar() As Boolean


        If dsDataSet.Tables("FormasPago").Rows.Count = 0 Then
            MsgBox("No ha especificado la forma de pago.", MsgBoxStyle.Exclamation, "DPTienda")
            CmbFormaPago.Focus()
            Exit Function
        End If


        If (Me.EBAbono.Value - ComisionBancaria) < Me.nbMontoTotal.Value Then
            MsgBox("El abono no puede ser menor a monto total", MsgBoxStyle.Exclamation, "DPTienda")
            Me.CmbFormaPago.Focus()
            Exit Function
        End If

        If (Me.EBAbono.Value - ComisionBancaria) > oAsociado.SaldoDPVale Then
            MsgBox("El abono no puede ser mayor que el Saldo del Asociado. Saldo Deportenis Vale = " & Format(oAsociado.SaldoDPVale, "$###,###,###.#0"), MsgBoxStyle.Exclamation, "DPTienda")
            Me.CmbFormaPago.Focus()
            Exit Function
        End If



        If EBAsociado.Text = String.Empty Then
            MsgBox("No ha seleccionado al asociado.", MsgBoxStyle.Exclamation, "DPTienda")
            EBIDAsociado.Focus()
            Exit Function
        End If

        If Me.EBPlazaCons.Text = String.Empty Then
            MsgBox("No ha especificado plaza y consecutivo.", MsgBoxStyle.Exclamation, "DPTienda")
            EBPlazaCons.Focus()
            Exit Function
        End If

        If Me.EBReferencia.Text = String.Empty Then
            MsgBox("No ha especificado referencia.", MsgBoxStyle.Exclamation, "DPTienda")
            EBReferencia.Focus()
            Exit Function
        End If



        Return True
    End Function

    Private Sub FrmAbonoDPVale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub EBPago_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBPago.Validating
        Try

            If (CType(Me.lblSaldoFavor.Text, Integer) < CType(EBPago.Text, Integer)) And Me.CmbFormaPago.Text = "S" Then
                MessageBox.Show("El monto a pagar no puede ser mayor al saldo a favor", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                EBPago.Focus()
                Exit Sub
            ElseIf Me.CmbFormaPago.Text = "S" Then
                Me.lblSaldoFavor.Text = Format(CType(Me.lblSaldoFavor.Text, Double) - CType(EBPago.Text, Double), "$###,###,###.#0")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EBIDTipoTarj_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBIDTipoTarj.Validating
        Try
            If EBIDTipoTarj.Text = String.Empty Then
                MessageBox.Show("Seleccione tipo de tarjeta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                sender.focus()
            End If
        Catch ex As Exception
            MessageBox.Show("El tipo de tarjeta no es númerico", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub EBIDBanco_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBIDBanco.Validating
        Try
            If EBIDBanco.Text = String.Empty Then
                MessageBox.Show("Seleccione Banco", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                sender.focus()
            End If
        Catch ex As Exception
            MessageBox.Show("El código de banco no puede ser númerico", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub EBNumTarj_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBNumTarj.Validating
        Try
            If EBNumTarj.Text = String.Empty Then
                MessageBox.Show("El número de tarjeta no puede ser nulo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                sender.focus()
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub EBAutorizacion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBAutorizacion.Validating
        Try
            If EBAutorizacion.Text = String.Empty Then
                MessageBox.Show("El número de autorización no puede ser nulo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                sender.focus()
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub EBPagoMin_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBPagoMin.Validating
        Try
            If CType(EBPagoMin.Text, Integer) <= 0 Then
                MessageBox.Show("Capture el pago minimo del abono", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                sender.focus()
            End If

        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub
#End Region

#Region "Impresión"
    Private Sub Sm_ActionPrintReporteAbonosApartados()
        Dim oARReporte As New rptComprobanteAbonoDpVale(oAbonoDPVale, Me, oAsociado)

        'Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Comprobante Abono D'portenis Vale"
        oARReporte.Run()

        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

        Try
            oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region


    Private Sub EBReferencia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBReferencia.Validating
        If EBReferencia.Value > 0 Then
            oPeriodoDetalleMgr = New PeriodoDetalleManager(oAppContext)
            oPeriodoDetalle = oPeriodoDetalleMgr.Create

            oPeriodoDetalle = oPeriodoDetalleMgr.SelectByNumPeriodo(EBReferencia.Value, Me.EBIDAsociado.Value)

            If (Not oPeriodoDetalle Is Nothing) And (oPeriodoDetalle.NumPeriodo <> 0) Then

                If oPeriodoDetalle.StatusRegistro = True Then

                    If oPeriodoDetalle.Liquidado = False Then

                        Me.EBReferencia.Enabled = False

                        ''Buscamos los procentajes de descuento
                        oPeriodoMgr = New PeriodosManager(oAppContext)
                        oPeriodo = oPeriodoMgr.Load(oPeriodoDetalle.PeriodoID)

                        Me.EBPagoMin.Value = oPeriodoDetalle.PagoMinimo

                        If oPeriodoDetalle.FechaPago <= oPeriodoDetalle.Fecha Then
                            If DateDiff(DateInterval.Day, oPeriodoDetalle.FechaPago, oPeriodoDetalle.Fecha) = 0 Then

                                Me.nbMontoTotal.Value = Me.EBPagoMin.Value - (Me.EBPagoMin.Value - oAsociado.SaldoVencDPVale) * (oPeriodo.PorcLimPagoD1 / 100)
                                Me.txtBonificacion.Value = (Me.EBPagoMin.Value - oAsociado.SaldoVencDPVale) * (oPeriodo.PorcLimPagoD1 / 100)
                                Me.nbBonificacion.Value = oPeriodo.PorcLimPagoD1 / 100

                            ElseIf DateDiff(DateInterval.Day, oPeriodoDetalle.FechaPago, oPeriodoDetalle.Fecha) = 1 Then

                                Me.nbMontoTotal.Value = Me.EBPagoMin.Value - (Me.EBPagoMin.Value - oAsociado.SaldoVencDPVale) * (oPeriodo.PorcLimPagoD2 / 100)
                                Me.txtBonificacion.Value = (Me.EBPagoMin.Value - oAsociado.SaldoVencDPVale) * (oPeriodo.PorcLimPagoD2 / 100)
                                Me.nbBonificacion.Value = oPeriodo.PorcLimPagoD2 / 100

                            ElseIf DateDiff(DateInterval.Day, oPeriodoDetalle.FechaPago, oPeriodoDetalle.Fecha) = 2 Then

                                Me.nbMontoTotal.Value = Me.EBPagoMin.Value - (Me.EBPagoMin.Value - oAsociado.SaldoVencDPVale) * (oPeriodo.PorcLimPagoD3 / 100)
                                Me.txtBonificacion.Value = (Me.EBPagoMin.Value - oAsociado.SaldoVencDPVale) * (oPeriodo.PorcLimPagoD3 / 100)
                                Me.nbBonificacion.Value = oPeriodo.PorcLimPagoD3 / 100

                            ElseIf DateDiff(DateInterval.Day, oPeriodoDetalle.FechaPago, oPeriodoDetalle.Fecha) = 3 Then

                                Me.nbMontoTotal.Value = Me.EBPagoMin.Value - (Me.EBPagoMin.Value - oAsociado.SaldoVencDPVale) * (oPeriodo.PorcLimPagoD4 / 100)
                                Me.txtBonificacion.Value = (Me.EBPagoMin.Value - oAsociado.SaldoVencDPVale) * (oPeriodo.PorcLimPagoD4 / 100)
                                Me.nbBonificacion.Value = oPeriodo.PorcLimPagoD4 / 100

                            ElseIf DateDiff(DateInterval.Day, oPeriodoDetalle.FechaPago, oPeriodoDetalle.Fecha) = 4 Then

                                Me.nbMontoTotal.Value = Me.EBPagoMin.Value - (Me.EBPagoMin.Value - oAsociado.SaldoVencDPVale) * (oPeriodo.PorcLimPagoD5 / 100)
                                Me.txtBonificacion.Value = (Me.EBPagoMin.Value - oAsociado.SaldoVencDPVale) * (oPeriodo.PorcLimPagoD5 / 100)
                                Me.nbBonificacion.Value = oPeriodo.PorcLimPagoD5 / 100

                            Else
                                MessageBox.Show("El corte no puede ser pagado hoy", "DPTienda", MessageBoxButtons.OK)

                                Me.EBReferencia.Value = 0
                                Me.EBReferencia.Enabled = True
                                Me.EBPagoMin.Value = 0
                                Me.EBPlazaCons.Text = String.Empty
                                Me.EBPlazaCons.Focus()
                                Me.oPeriodo.Clear()
                                Me.oPeriodoDetalle.Clear()
                            End If
                        Else
                            MessageBox.Show("El corte no puede ser pagado hoy", "DPTienda", MessageBoxButtons.OK)

                            Me.EBReferencia.Value = 0
                            Me.EBReferencia.Enabled = True
                            Me.EBPagoMin.Value = 0
                            Me.EBPlazaCons.Text = String.Empty
                            Me.EBPlazaCons.Focus()
                            Me.oPeriodo.Clear()
                            Me.oPeriodoDetalle.Clear()
                            Me.EBReferencia.Focus()
                        End If

                    Else

                        MessageBox.Show("El corte ya fue liquidado ", "DPTienda", MessageBoxButtons.OK)
                        oPeriodoDetalle.Clear()
                        Me.EBReferencia.Focus()

                    End If

                Else
                    MessageBox.Show("Corte vencido ", "DPTienda", MessageBoxButtons.OK)
                    oPeriodoDetalle.Clear()
                    Me.EBReferencia.Focus()
                End If
            Else

                MessageBox.Show("No se encontraron registros para el numero de periodo proporcionado", "DPTienda", MessageBoxButtons.OK)
                oPeriodoDetalle.Clear()
                Me.EBReferencia.Focus()

            End If
        End If
            
    End Sub
End Class
