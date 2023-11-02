Imports System.Web.Mail
Imports System.Web.Util
Imports System.Net
Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTransportista
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DataDynamics.ActiveReports.Export.Pdf

'AJE
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralNuevo
Imports Janus.Windows.GridEX
Imports System.Collections.Generic

Public Class FrmInvTraspasoDEntrada
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal oFirma As SaveConfigArchivos)
        MyBase.New()
        FirmaConfig = oFirma
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ExplorerBar4 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuHerramientas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuHerramientas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoCerrar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAplicar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAplicar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAplicar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ebResponsableDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTransportistaDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucDestinoDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucOrigenDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTransportistaCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucDestinoCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucOrigenCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNumGuia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMoneda As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFechaRecepcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebStatus As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents menuArchivoCerrar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrirPendientes As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrirPendientes1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrirPendientes2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrirPendientes3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrirPendientes4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebTotalPiezas As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents GrdTraspasoCorrida As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebTotalLecturado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents menuArchivoCerrar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblNoBulto As System.Windows.Forms.Label
    Friend WithEvents ebNoBulto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents menuArchivoCargaLectora As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoCargaLectora1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebNumBultosRecibidos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInvTraspasoDEntrada))
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.ebNoBulto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblNoBulto = New System.Windows.Forms.Label()
        Me.ebMoneda = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebResponsableDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ebTransportistaDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucDestinoDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucOrigenDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebTransportistaCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucDestinoCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucOrigenCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoAbrirPendientes4 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrirPendientes")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoCargaLectora1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoCargaLectora")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivoAplicar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAplicar")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoCerrar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoCerrar")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.menuArchivoAbrirPendientes3 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrirPendientes")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoAplicar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAplicar")
        Me.menuArchivoEliminar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoImprimir2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuHerramientas = New Janus.Windows.UI.CommandBars.UICommand("menuHerramientas")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.menuArchivoCerrar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoCerrar")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.menuArchivoImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivoAplicar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAplicar")
        Me.menuArchivoAbrirPendientes = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrirPendientes")
        Me.menuArchivoCargaLectora = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoCargaLectora")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuHerramientas1 = New Janus.Windows.UI.CommandBars.UICommand("menuHerramientas")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuArchivoCerrar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoCerrar")
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebNumBultosRecibidos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFechaRecepcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNumGuia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebReferencia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ExplorerBar4 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebTotalLecturado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ebTotalPiezas = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ebStatus = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.menuArchivoAbrirPendientes1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrirPendientes")
        Me.menuArchivoAbrirPendientes2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrirPendientes")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.GrdTraspasoCorrida = New Janus.Windows.GridEX.GridEX()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar4.SuspendLayout()
        CType(Me.GrdTraspasoCorrida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.btnAgregar)
        Me.ExplorerBar1.Controls.Add(Me.ebNoBulto)
        Me.ExplorerBar1.Controls.Add(Me.ebFolio)
        Me.ExplorerBar1.Controls.Add(Me.lblNoBulto)
        Me.ExplorerBar1.Controls.Add(Me.ebMoneda)
        Me.ExplorerBar1.Controls.Add(Me.ebFecha)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsableDesc)
        Me.ExplorerBar1.Controls.Add(Me.Label20)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.ebTransportistaDesc)
        Me.ExplorerBar1.Controls.Add(Me.ebSucDestinoDesc)
        Me.ExplorerBar1.Controls.Add(Me.ebSucOrigenDesc)
        Me.ExplorerBar1.Controls.Add(Me.ebTransportistaCod)
        Me.ExplorerBar1.Controls.Add(Me.ebSucDestinoCod)
        Me.ExplorerBar1.Controls.Add(Me.ebSucOrigenCod)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 28)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(592, 529)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnAgregar
        '
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Location = New System.Drawing.Point(400, 136)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(168, 24)
        Me.btnAgregar.TabIndex = 112
        Me.btnAgregar.Text = "Agregar Bulto"
        Me.btnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNoBulto
        '
        Me.ebNoBulto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNoBulto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNoBulto.Location = New System.Drawing.Point(456, 108)
        Me.ebNoBulto.Name = "ebNoBulto"
        Me.ebNoBulto.ReadOnly = True
        Me.ebNoBulto.Size = New System.Drawing.Size(112, 23)
        Me.ebNoBulto.TabIndex = 111
        Me.ebNoBulto.Text = "0"
        Me.ebNoBulto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebNoBulto.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebNoBulto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.FormatString = "0000000000"
        Me.ebFolio.Location = New System.Drawing.Point(456, 48)
        Me.ebFolio.MaxLength = 10
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.ReadOnly = True
        Me.ebFolio.Size = New System.Drawing.Size(112, 23)
        Me.ebFolio.TabIndex = 108
        Me.ebFolio.Text = "0000000000"
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebFolio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNoBulto
        '
        Me.lblNoBulto.BackColor = System.Drawing.Color.Transparent
        Me.lblNoBulto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoBulto.Location = New System.Drawing.Point(400, 112)
        Me.lblNoBulto.Name = "lblNoBulto"
        Me.lblNoBulto.Size = New System.Drawing.Size(66, 17)
        Me.lblNoBulto.TabIndex = 107
        Me.lblNoBulto.Text = "Bulto:"
        '
        'ebMoneda
        '
        Me.ebMoneda.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMoneda.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMoneda.BackColor = System.Drawing.Color.Ivory
        Me.ebMoneda.Enabled = False
        Me.ebMoneda.Location = New System.Drawing.Point(456, 108)
        Me.ebMoneda.Name = "ebMoneda"
        Me.ebMoneda.ReadOnly = True
        Me.ebMoneda.Size = New System.Drawing.Size(112, 23)
        Me.ebMoneda.TabIndex = 9
        Me.ebMoneda.TabStop = False
        Me.ebMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMoneda.Visible = False
        Me.ebMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.Color.Ivory
        Me.ebFecha.Location = New System.Drawing.Point(456, 78)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(112, 23)
        Me.ebFecha.TabIndex = 8
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebResponsableDesc
        '
        Me.ebResponsableDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsableDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsableDesc.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsableDesc.Location = New System.Drawing.Point(120, 137)
        Me.ebResponsableDesc.Name = "ebResponsableDesc"
        Me.ebResponsableDesc.ReadOnly = True
        Me.ebResponsableDesc.Size = New System.Drawing.Size(269, 23)
        Me.ebResponsableDesc.TabIndex = 105
        Me.ebResponsableDesc.TabStop = False
        Me.ebResponsableDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(16, 141)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 23)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "Responsable:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(398, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Moneda:"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(398, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 23)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(398, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Folio:"
        '
        'ebTransportistaDesc
        '
        Me.ebTransportistaDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTransportistaDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTransportistaDesc.BackColor = System.Drawing.Color.Ivory
        Me.ebTransportistaDesc.Location = New System.Drawing.Point(120, 108)
        Me.ebTransportistaDesc.Name = "ebTransportistaDesc"
        Me.ebTransportistaDesc.ReadOnly = True
        Me.ebTransportistaDesc.Size = New System.Drawing.Size(269, 23)
        Me.ebTransportistaDesc.TabIndex = 104
        Me.ebTransportistaDesc.TabStop = False
        Me.ebTransportistaDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTransportistaDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucDestinoDesc
        '
        Me.ebSucDestinoDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoDesc.BackColor = System.Drawing.Color.Ivory
        Me.ebSucDestinoDesc.Location = New System.Drawing.Point(189, 78)
        Me.ebSucDestinoDesc.Name = "ebSucDestinoDesc"
        Me.ebSucDestinoDesc.ReadOnly = True
        Me.ebSucDestinoDesc.Size = New System.Drawing.Size(200, 23)
        Me.ebSucDestinoDesc.TabIndex = 102
        Me.ebSucDestinoDesc.TabStop = False
        Me.ebSucDestinoDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucDestinoDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucOrigenDesc
        '
        Me.ebSucOrigenDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenDesc.BackColor = System.Drawing.Color.Ivory
        Me.ebSucOrigenDesc.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucOrigenDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucOrigenDesc.Location = New System.Drawing.Point(189, 48)
        Me.ebSucOrigenDesc.Name = "ebSucOrigenDesc"
        Me.ebSucOrigenDesc.ReadOnly = True
        Me.ebSucOrigenDesc.Size = New System.Drawing.Size(200, 23)
        Me.ebSucOrigenDesc.TabIndex = 100
        Me.ebSucOrigenDesc.TabStop = False
        Me.ebSucOrigenDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucOrigenDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTransportistaCod
        '
        Me.ebTransportistaCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTransportistaCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTransportistaCod.BackColor = System.Drawing.Color.Ivory
        Me.ebTransportistaCod.ButtonImage = CType(resources.GetObject("ebTransportistaCod.ButtonImage"), System.Drawing.Image)
        Me.ebTransportistaCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTransportistaCod.Location = New System.Drawing.Point(120, 108)
        Me.ebTransportistaCod.Name = "ebTransportistaCod"
        Me.ebTransportistaCod.ReadOnly = True
        Me.ebTransportistaCod.Size = New System.Drawing.Size(64, 22)
        Me.ebTransportistaCod.TabIndex = 103
        Me.ebTransportistaCod.TabStop = False
        Me.ebTransportistaCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTransportistaCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucDestinoCod
        '
        Me.ebSucDestinoCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoCod.BackColor = System.Drawing.Color.Ivory
        Me.ebSucDestinoCod.ButtonImage = CType(resources.GetObject("ebSucDestinoCod.ButtonImage"), System.Drawing.Image)
        Me.ebSucDestinoCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucDestinoCod.Location = New System.Drawing.Point(120, 78)
        Me.ebSucDestinoCod.Name = "ebSucDestinoCod"
        Me.ebSucDestinoCod.ReadOnly = True
        Me.ebSucDestinoCod.Size = New System.Drawing.Size(64, 22)
        Me.ebSucDestinoCod.TabIndex = 101
        Me.ebSucDestinoCod.TabStop = False
        Me.ebSucDestinoCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucDestinoCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucOrigenCod
        '
        Me.ebSucOrigenCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenCod.BackColor = System.Drawing.Color.Ivory
        Me.ebSucOrigenCod.ButtonImage = CType(resources.GetObject("ebSucOrigenCod.ButtonImage"), System.Drawing.Image)
        Me.ebSucOrigenCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucOrigenCod.Location = New System.Drawing.Point(120, 48)
        Me.ebSucOrigenCod.Name = "ebSucOrigenCod"
        Me.ebSucOrigenCod.ReadOnly = True
        Me.ebSucOrigenCod.Size = New System.Drawing.Size(64, 22)
        Me.ebSucOrigenCod.TabIndex = 99
        Me.ebSucOrigenCod.TabStop = False
        Me.ebSucOrigenCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucOrigenCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Transportista:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Destino:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Origen:"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuHerramientas, Me.menuAyuda, Me.menuArchivoNuevo, Me.menuArchivoAbrir, Me.menuArchivoCerrar, Me.menuArchivoGuardar, Me.menuArchivoEliminar, Me.menuArchivoImprimir, Me.menuAyudaTema, Me.menuArchivoAplicar, Me.menuArchivoAbrirPendientes, Me.menuArchivoCargaLectora})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("c104218c-d8bb-4e4e-888f-0e0d12523cd2")
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
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.Separator1, Me.menuArchivoAbrir1, Me.Separator9, Me.menuArchivoAbrirPendientes4, Me.Separator2, Me.menuArchivoImprimir1, Me.Separator4, Me.menuArchivoCargaLectora1, Me.Separator3, Me.menuAyudaTema1, Me.menuArchivoAplicar1, Me.Separator10, Me.menuArchivoCerrar1})
        Me.UiCommandBar2.FloatingLocation = New System.Drawing.Point(198, 193)
        Me.UiCommandBar2.FloatingSize = New System.Drawing.Size(408, 22)
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 0
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(568, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuArchivoAbrir1
        '
        Me.menuArchivoAbrir1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage
        Me.menuArchivoAbrir1.Key = "menuArchivoAbrir"
        Me.menuArchivoAbrir1.Name = "menuArchivoAbrir1"
        Me.menuArchivoAbrir1.ToolTipText = "Abrir"
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'menuArchivoAbrirPendientes4
        '
        Me.menuArchivoAbrirPendientes4.Key = "menuArchivoAbrirPendientes"
        Me.menuArchivoAbrirPendientes4.Name = "menuArchivoAbrirPendientes4"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuArchivoImprimir1
        '
        Me.menuArchivoImprimir1.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir1.Name = "menuArchivoImprimir1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuArchivoCargaLectora1
        '
        Me.menuArchivoCargaLectora1.Enabled = Janus.Windows.UI.InheritableBoolean.[True]
        Me.menuArchivoCargaLectora1.Key = "menuArchivoCargaLectora"
        Me.menuArchivoCargaLectora1.Name = "menuArchivoCargaLectora1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage
        Me.menuAyudaTema1.Image = CType(resources.GetObject("menuAyudaTema1.Image"), System.Drawing.Image)
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        Me.menuAyudaTema1.Text = "Ay&uda"
        Me.menuAyudaTema1.ToolTipText = "Temas de Ayuda"
        Me.menuAyudaTema1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuArchivoAplicar1
        '
        Me.menuArchivoAplicar1.Key = "menuArchivoAplicar"
        Me.menuArchivoAplicar1.Name = "menuArchivoAplicar1"
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'menuArchivoCerrar1
        '
        Me.menuArchivoCerrar1.Icon = CType(resources.GetObject("menuArchivoCerrar1.Icon"), System.Drawing.Icon)
        Me.menuArchivoCerrar1.Key = "menuArchivoCerrar"
        Me.menuArchivoCerrar1.Name = "menuArchivoCerrar1"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.menuArchivoAbrir2, Me.menuArchivoAbrirPendientes3, Me.Separator5, Me.menuArchivoGuardar2, Me.menuArchivoAplicar2, Me.menuArchivoEliminar2, Me.Separator6, Me.menuArchivoImprimir2, Me.Separator7})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        '
        'menuArchivoAbrir2
        '
        Me.menuArchivoAbrir2.Key = "menuArchivoAbrir"
        Me.menuArchivoAbrir2.Name = "menuArchivoAbrir2"
        '
        'menuArchivoAbrirPendientes3
        '
        Me.menuArchivoAbrirPendientes3.Key = "menuArchivoAbrirPendientes"
        Me.menuArchivoAbrirPendientes3.Name = "menuArchivoAbrirPendientes3"
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
        'menuArchivoAplicar2
        '
        Me.menuArchivoAplicar2.Key = "menuArchivoAplicar"
        Me.menuArchivoAplicar2.Name = "menuArchivoAplicar2"
        '
        'menuArchivoEliminar2
        '
        Me.menuArchivoEliminar2.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar2.Name = "menuArchivoEliminar2"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuArchivoImprimir2
        '
        Me.menuArchivoImprimir2.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir2.Name = "menuArchivoImprimir2"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'menuHerramientas
        '
        Me.menuHerramientas.Key = "menuHerramientas"
        Me.menuHerramientas.Name = "menuHerramientas"
        Me.menuHerramientas.Text = "&Herramientas"
        '
        'menuAyuda
        '
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ay&uda"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Image = CType(resources.GetObject("menuArchivoNuevo.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'menuArchivoAbrir
        '
        Me.menuArchivoAbrir.Image = CType(resources.GetObject("menuArchivoAbrir.Image"), System.Drawing.Image)
        Me.menuArchivoAbrir.Key = "menuArchivoAbrir"
        Me.menuArchivoAbrir.Name = "menuArchivoAbrir"
        Me.menuArchivoAbrir.Text = "A&brir"
        '
        'menuArchivoCerrar
        '
        Me.menuArchivoCerrar.Icon = CType(resources.GetObject("menuArchivoCerrar.Icon"), System.Drawing.Icon)
        Me.menuArchivoCerrar.Key = "menuArchivoCerrar"
        Me.menuArchivoCerrar.Name = "menuArchivoCerrar"
        Me.menuArchivoCerrar.Text = "Salir"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Image = CType(resources.GetObject("menuArchivoGuardar.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "&Guardar"
        '
        'menuArchivoEliminar
        '
        Me.menuArchivoEliminar.Image = CType(resources.GetObject("menuArchivoEliminar.Image"), System.Drawing.Image)
        Me.menuArchivoEliminar.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Name = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Text = "E&liminar"
        '
        'menuArchivoImprimir
        '
        Me.menuArchivoImprimir.Image = CType(resources.GetObject("menuArchivoImprimir.Image"), System.Drawing.Image)
        Me.menuArchivoImprimir.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Name = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Text = "&Imprimir"
        '
        'menuAyudaTema
        '
        Me.menuAyudaTema.Image = CType(resources.GetObject("menuAyudaTema.Image"), System.Drawing.Image)
        Me.menuAyudaTema.Key = "menuAyudaTema"
        Me.menuAyudaTema.Name = "menuAyudaTema"
        Me.menuAyudaTema.Text = "&Temas de Ayuda"
        '
        'menuArchivoAplicar
        '
        Me.menuArchivoAplicar.Image = CType(resources.GetObject("menuArchivoAplicar.Image"), System.Drawing.Image)
        Me.menuArchivoAplicar.Key = "menuArchivoAplicar"
        Me.menuArchivoAplicar.Name = "menuArchivoAplicar"
        Me.menuArchivoAplicar.Text = "A&plicar"
        '
        'menuArchivoAbrirPendientes
        '
        Me.menuArchivoAbrirPendientes.Image = CType(resources.GetObject("menuArchivoAbrirPendientes.Image"), System.Drawing.Image)
        Me.menuArchivoAbrirPendientes.Key = "menuArchivoAbrirPendientes"
        Me.menuArchivoAbrirPendientes.Name = "menuArchivoAbrirPendientes"
        Me.menuArchivoAbrirPendientes.Text = "Pendientes"
        '
        'menuArchivoCargaLectora
        '
        Me.menuArchivoCargaLectora.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuArchivoCargaLectora.Image = CType(resources.GetObject("menuArchivoCargaLectora.Image"), System.Drawing.Image)
        Me.menuArchivoCargaLectora.Key = "menuArchivoCargaLectora"
        Me.menuArchivoCargaLectora.Name = "menuArchivoCargaLectora"
        Me.menuArchivoCargaLectora.Text = "Carga desde Lectora"
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
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(832, 28)
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'menuHerramientas1
        '
        Me.menuHerramientas1.Key = "menuHerramientas"
        Me.menuHerramientas1.Name = "menuHerramientas1"
        '
        'menuAyuda1
        '
        Me.menuAyuda1.Key = "menuAyuda"
        Me.menuAyuda1.Name = "menuAyuda1"
        '
        'menuArchivoCerrar2
        '
        Me.menuArchivoCerrar2.Key = "menuArchivoCerrar"
        Me.menuArchivoCerrar2.Name = "menuArchivoCerrar2"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.ebNumBultosRecibidos)
        Me.ExplorerBar2.Controls.Add(Me.ebFechaRecepcion)
        Me.ExplorerBar2.Controls.Add(Me.ebNumGuia)
        Me.ExplorerBar2.Controls.Add(Me.ebReferencia)
        Me.ExplorerBar2.Controls.Add(Me.Label10)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Controls.Add(Me.Label8)
        Me.ExplorerBar2.Controls.Add(Me.Label9)
        Me.ExplorerBar2.Dock = System.Windows.Forms.DockStyle.Right
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Recepción"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar2.Location = New System.Drawing.Point(584, 28)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(248, 529)
        Me.ExplorerBar2.TabIndex = 3
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebNumBultosRecibidos
        '
        Me.ebNumBultosRecibidos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumBultosRecibidos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumBultosRecibidos.Location = New System.Drawing.Point(104, 77)
        Me.ebNumBultosRecibidos.Name = "ebNumBultosRecibidos"
        Me.ebNumBultosRecibidos.Size = New System.Drawing.Size(112, 23)
        Me.ebNumBultosRecibidos.TabIndex = 110
        Me.ebNumBultosRecibidos.Text = "0"
        Me.ebNumBultosRecibidos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebNumBultosRecibidos.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebNumBultosRecibidos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFechaRecepcion
        '
        Me.ebFechaRecepcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFechaRecepcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFechaRecepcion.BackColor = System.Drawing.Color.Ivory
        Me.ebFechaRecepcion.Location = New System.Drawing.Point(104, 135)
        Me.ebFechaRecepcion.Name = "ebFechaRecepcion"
        Me.ebFechaRecepcion.ReadOnly = True
        Me.ebFechaRecepcion.Size = New System.Drawing.Size(112, 23)
        Me.ebFechaRecepcion.TabIndex = 3
        Me.ebFechaRecepcion.TabStop = False
        Me.ebFechaRecepcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFechaRecepcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNumGuia
        '
        Me.ebNumGuia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumGuia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumGuia.BackColor = System.Drawing.Color.Ivory
        Me.ebNumGuia.Location = New System.Drawing.Point(104, 106)
        Me.ebNumGuia.Name = "ebNumGuia"
        Me.ebNumGuia.ReadOnly = True
        Me.ebNumGuia.Size = New System.Drawing.Size(112, 23)
        Me.ebNumGuia.TabIndex = 2
        Me.ebNumGuia.TabStop = False
        Me.ebNumGuia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumGuia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebReferencia
        '
        Me.ebReferencia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebReferencia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebReferencia.BackColor = System.Drawing.Color.Ivory
        Me.ebReferencia.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebReferencia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebReferencia.Location = New System.Drawing.Point(104, 48)
        Me.ebReferencia.Name = "ebReferencia"
        Me.ebReferencia.ReadOnly = True
        Me.ebReferencia.Size = New System.Drawing.Size(112, 23)
        Me.ebReferencia.TabIndex = 0
        Me.ebReferencia.TabStop = False
        Me.ebReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 139)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 23)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Fecha:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 23)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "# de Guia:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "# de Bultos:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 23)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Referencia:"
        '
        'ExplorerBar4
        '
        Me.ExplorerBar4.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar4.Controls.Add(Me.ebTotalLecturado)
        Me.ExplorerBar4.Controls.Add(Me.Label11)
        Me.ExplorerBar4.Controls.Add(Me.ebTotalPiezas)
        Me.ExplorerBar4.Controls.Add(Me.Label17)
        Me.ExplorerBar4.Controls.Add(Me.ebStatus)
        Me.ExplorerBar4.Controls.Add(Me.Label15)
        Me.ExplorerBar4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Datos Totales"
        Me.ExplorerBar4.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar4.Location = New System.Drawing.Point(0, 477)
        Me.ExplorerBar4.Name = "ExplorerBar4"
        Me.ExplorerBar4.Size = New System.Drawing.Size(840, 96)
        Me.ExplorerBar4.TabIndex = 5
        Me.ExplorerBar4.TabStop = False
        Me.ExplorerBar4.Text = "ExplorerBar4"
        Me.ExplorerBar4.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebTotalLecturado
        '
        Me.ebTotalLecturado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalLecturado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalLecturado.BackColor = System.Drawing.Color.Ivory
        Me.ebTotalLecturado.ButtonImage = CType(resources.GetObject("ebTotalLecturado.ButtonImage"), System.Drawing.Image)
        Me.ebTotalLecturado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalLecturado.Location = New System.Drawing.Point(744, 40)
        Me.ebTotalLecturado.Name = "ebTotalLecturado"
        Me.ebTotalLecturado.ReadOnly = True
        Me.ebTotalLecturado.Size = New System.Drawing.Size(56, 22)
        Me.ebTotalLecturado.TabIndex = 29
        Me.ebTotalLecturado.TabStop = False
        Me.ebTotalLecturado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotalLecturado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(632, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 16)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Total Lecturado:"
        '
        'ebTotalPiezas
        '
        Me.ebTotalPiezas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalPiezas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalPiezas.BackColor = System.Drawing.Color.Ivory
        Me.ebTotalPiezas.ButtonImage = CType(resources.GetObject("ebTotalPiezas.ButtonImage"), System.Drawing.Image)
        Me.ebTotalPiezas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalPiezas.Location = New System.Drawing.Point(544, 40)
        Me.ebTotalPiezas.Name = "ebTotalPiezas"
        Me.ebTotalPiezas.ReadOnly = True
        Me.ebTotalPiezas.Size = New System.Drawing.Size(56, 22)
        Me.ebTotalPiezas.TabIndex = 5
        Me.ebTotalPiezas.TabStop = False
        Me.ebTotalPiezas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotalPiezas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(464, 45)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 23)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "Total Pzas:"
        '
        'ebStatus
        '
        Me.ebStatus.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebStatus.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebStatus.BackColor = System.Drawing.Color.Ivory
        Me.ebStatus.ButtonImage = CType(resources.GetObject("ebStatus.ButtonImage"), System.Drawing.Image)
        Me.ebStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebStatus.Location = New System.Drawing.Point(392, 40)
        Me.ebStatus.Name = "ebStatus"
        Me.ebStatus.ReadOnly = True
        Me.ebStatus.Size = New System.Drawing.Size(43, 22)
        Me.ebStatus.TabIndex = 4
        Me.ebStatus.TabStop = False
        Me.ebStatus.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebStatus.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(336, 44)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 23)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Status:"
        '
        'menuArchivoAbrirPendientes1
        '
        Me.menuArchivoAbrirPendientes1.Key = "menuArchivoAbrirPendientes"
        Me.menuArchivoAbrirPendientes1.Name = "menuArchivoAbrirPendientes1"
        '
        'menuArchivoAbrirPendientes2
        '
        Me.menuArchivoAbrirPendientes2.Key = "menuArchivoAbrirPendientes"
        Me.menuArchivoAbrirPendientes2.Name = "menuArchivoAbrirPendientes2"
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'GrdTraspasoCorrida
        '
        Me.GrdTraspasoCorrida.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GrdTraspasoCorrida.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GrdTraspasoCorrida.DesignTimeLayout = GridEXLayout1
        Me.GrdTraspasoCorrida.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GrdTraspasoCorrida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdTraspasoCorrida.GroupByBoxVisible = False
        Me.GrdTraspasoCorrida.Location = New System.Drawing.Point(8, 192)
        Me.GrdTraspasoCorrida.Name = "GrdTraspasoCorrida"
        Me.GrdTraspasoCorrida.Size = New System.Drawing.Size(816, 280)
        Me.GrdTraspasoCorrida.TabIndex = 7
        Me.GrdTraspasoCorrida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'FrmInvTraspasoDEntrada
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(832, 557)
        Me.Controls.Add(Me.GrdTraspasoCorrida)
        Me.Controls.Add(Me.ExplorerBar4)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmInvTraspasoDEntrada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traspaso de Entrada a Detalle"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar4.ResumeLayout(False)
        CType(Me.GrdTraspasoCorrida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dsMaterialTalla As DataSet
    Dim strline As String = ""
    'Motivos de captura manual
    Dim boolManual As Boolean = False
    Private m_strFirmaConfig As SaveConfigArchivos
    Dim strFolioTraspaso As String = ""
    Dim oFrmMessage As frmMessages
    Dim dtTraspasoOriginalSAP As DataTable

    '---------------------------------------------------------------------------------------
    'JNAVA 16.06.2014: Tabla para datos de carga desde lectora
    '---------------------------------------------------------------------------------------
    Dim dtRegistrosLayout As DataTable
    Dim bEsCargaLectora As Boolean = False
    Dim bValidacionCarga As Boolean = False
    Dim strRutaLayout As String = "", bEsConsignacion As Boolean = False
    Private oTraspasoEntradaMgr As TraspasosEntradaManager


#Region "Propiedades"
    Public Property FirmaConfig() As SaveConfigArchivos
        Get
            Return m_strFirmaConfig
        End Get
        Set(ByVal Value As SaveConfigArchivos)
            m_strFirmaConfig = Value
        End Set
    End Property
#End Region

#Region "Varibales  objetos"

    'Declaracion
    'AJE
    Dim oAjusteMgr As AjusteGeneralManager
    Dim oAjusteAJE As AjusteGeneralInfo
    Dim oSapMgr As ProcesoSAPManager
    Dim oTraspasoSMgr As TraspasosSalidaManager
    Dim oArticulosMgr As CatalogoArticuloManager

#End Region

#Region "Variables Miembros"

    Private oTraspasoEntrada As TraspasoEntrada

    'Private oTraspasoEntradaMgr As TraspasosEntradaManager

    'Private odsDataSet As DataSet
    Private odsCatalogoCorridas As DataSet

    Private dtTraspaso As New DataTable("TraspasoCorrida")

    Private UserSessionAplicated As String = String.Empty
    Private UserNameAplicated As String = String.Empty

    Private oCatalogoTransportistasMgr As CatalogoTransportistaManager

    Private oTransportista As Transportista


#End Region

#Region "Métodos y Funciones"

    Private Sub GuardarAJESAP()
        oAjusteAJE.TipoAjuste = "E"
        Me.oAjusteAJE.FolioAjuste = oAjusteMgr.GetFolio("E")
        Me.oAjusteAJE.Almacen = oAppContext.ApplicationConfiguration.Almacen

        'Agregamos el campo FolioSap al datatable
        Dim dcFolioSAP As New DataColumn
        With dcFolioSAP
            .ColumnName = "FolioSap"
            .DataType = GetType(String)
            .DefaultValue = ""
            .Caption = "Folio SAP"
        End With
        dtTraspaso.Columns.Add(dcFolioSAP)
        dtTraspaso.AcceptChanges()
        '''Agregamos el campo FolioSap al datatable


        'Aplicamos un ajuste en SAP por cada Articulo 
        For Each oRow As DataRow In oAjusteAJE.Detalle.Rows

            oSapMgr.Write_AJUSTESOB(oAjusteAJE, Me.ebFolio.Text, oRow.Item("Codigo"), oRow.Item("Cantidad"), oRow.Item("Talla"))

            'Para que llene el folio SAP del ajuste
            If oAjusteAJE.FolioSAP Is Nothing Then
                oRow!foliosap = ""
            Else
                oRow!foliosap = oAjusteAJE.FolioSAP
            End If
            oRow!folio = oAjusteAJE.FolioAjuste

            'Actualizo el folioSAP del ajuste de entrada en el datatable al codigo de articulo y talla correspondiente
            Dim dvAjuste As New DataView(dtTraspaso, "Codigo = '" & oRow.Item("Codigo") & "' And Talla = '" & oRow.Item("Talla") & "'", "Codigo", DataViewRowState.CurrentRows)
            If dvAjuste.Count > 0 Then
                For Each oRowDT As DataRowView In dvAjuste
                    If oAjusteAJE.FolioSAP Is Nothing Then
                        oRowDT!foliosap = ""
                    Else
                        oRowDT!foliosap = oAjusteAJE.FolioSAP
                    End If
                Next
                dtTraspaso.AcceptChanges()
            End If

        Next

    End Sub

    Private Sub GuardarFoliosSAp(ByVal strTipoAjuste As String)
        If strTipoAjuste = "E" Then
            If oAjusteAJE.Detalle.Rows.Count > 0 Then

                For Each erow As DataRow In oAjusteAJE.Detalle.Rows

                    oAjusteMgr.UpdateESNuevoDettalleFolioSAP(erow("folio"), erow("foliosap"), "E")

                Next

            End If
        End If
    End Sub

    Private Sub GuardarDP(ByVal strTipoAjuste As String)

        If strTipoAjuste = "E" Then
            'Guardar en DP Ajustes de Entrada
            Me.oAjusteAJE.Observaciones = "Ajuste por Sobrante en Traspaso de Entrada con folio: " & Me.ebFolio.Text
            Me.oAjusteAJE.FolioSAP = "1"
            'Me.oAjusteAJE.CostoTotal = oAjusteAJE.Detalle.Compute("sum(Total)", "Total>0")
            Me.oAjusteAJE.CostoTotal = 0
            Me.oAjusteAJE.TipoAjuste = "E"
            Me.oAjusteAJE.TotalCodigos = Me.oAjusteAJE.Detalle.Rows.Count
            Me.oAjusteAJE.FechaAjuste = Date.Today.ToShortDateString
            Me.oAjusteMgr.Save(Me.oAjusteAJE)

        End If

    End Sub

    Private Sub GuardarInServer(ByVal strTipoAjuste As String)

        If strTipoAjuste = "E" Then
            'Guardar en Ajustes de Entrada del Server
            Me.oAjusteAJE.Observaciones = "Ajuste por Sobrante en Traspaso de Entrada con folio: " & Me.ebFolio.Text
            Me.oAjusteAJE.FolioSAP = "1"
            Me.oAjusteAJE.CostoTotal = 0
            Me.oAjusteAJE.TipoAjuste = "E"
            Me.oAjusteAJE.TotalCodigos = Me.oAjusteAJE.Detalle.Rows.Count
            Me.oAjusteAJE.FechaAjuste = Date.Today.ToShortDateString
            Me.oAjusteMgr.SaveInServer(Me.oAjusteAJE)

        End If

    End Sub

    Private Sub Sm_TxtLimpiar()

        ebSucOrigenCod.Text = String.Empty
        ebSucOrigenDesc.Text = String.Empty
        ebSucDestinoCod.Text = String.Empty
        ebSucDestinoDesc.Text = String.Empty
        ebTransportistaCod.Text = String.Empty
        ebTransportistaDesc.Text = String.Empty
        ebFolio.Value = 0
        ebFecha.Text = String.Empty
        ebMoneda.Text = String.Empty
        ebReferencia.Text = String.Empty
        '------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA(15.02.2016): Comentado por adecuaciones a retail
        '------------------------------------------------------------------------------------------------------------------------------------------------------------
        'ebNumBultos.Text = String.Empty
        ebNumGuia.Text = String.Empty
        ebResponsableDesc.Text = String.Empty
        ebFechaRecepcion.Text = String.Empty
        ebStatus.Text = String.Empty
        ebTotalPiezas.Text = String.Empty
        Me.ebTotalLecturado.Text = ""
        Me.ebNumBultosRecibidos.Value = 0
        Me.ebNoBulto.Value = 0
        GrdTraspasoCorrida.DataSource = Nothing
        Me.ebNumBultosRecibidos.BackColor = Color.White
        Me.ebNumBultosRecibidos.ReadOnly = False
        Me.ebFolio.Enabled = True
        Me.GrdTraspasoCorrida.AllowEdit = InheritableBoolean.False
        If Not dtTraspaso Is Nothing Then dtTraspaso.Clear()
        If Not dtTraspasoOriginalSAP Is Nothing Then dtTraspasoOriginalSAP.Clear()
        Me.btnAgregar.Enabled = False
        Me.ebFolio.Focus()

        '--------------------------------------------------------------------------------
        'JNAVA 19.062014: Mostramos los controles segun la configuración
        '--------------------------------------------------------------------------------
        If oConfigCierreFI.RecibirParcialmente = False Then
            Me.ebFolio.ReadOnly = True
            Me.ebNoBulto.Visible = False
            Me.lblNoBulto.Visible = False
            Me.ebNumBultosRecibidos.Visible = False
            Me.btnAgregar.Visible = False
            Me.ebNoBulto.ReadOnly = False
        Else
            Me.ebFolio.ReadOnly = False
            Me.ebNoBulto.Visible = True
            Me.lblNoBulto.Visible = True
            Me.Label8.Visible = True
            Me.ebNumBultosRecibidos.Visible = True
            Me.btnAgregar.Visible = True
            Me.ebNoBulto.ReadOnly = True
        End If
        '--------------------------------------------------------------------------------

        On Error Resume Next

    End Sub

    Private Function GetAlmacen() As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim strAlmacen As String = oSapMgr.Read_Centros 'oAppContext.ApplicationConfiguration.Almacen
        Dim AlmacenDescripcion As String = String.Empty
        oAlmacen = oAlmacenMgr.Create
        oAlmacenMgr.LoadInto(strAlmacen, oAlmacen)

        AlmacenDescripcion = strAlmacen & " " & oAlmacen.Descripcion

        oAlmacen = Nothing
        oAlmacenMgr = Nothing

        Return AlmacenDescripcion

    End Function

    Public Sub SetupView()

        'Dim odrFiltro() As DataRow

        'Dim oCurrentRow As GridEXRow

        'Dim odrDataRow As DataRowView

        'oCurrentRow = GrdTraspasoCorrida.GetRow()

        'odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

        With GrdTraspasoCorrida.Tables(0)

            For intCol As Integer = 0 To .Columns.Count - 1
                .Columns(intCol).Visible = False
            Next

            .Columns("Codigo").Width = 150
            .Columns("Codigo").Caption = "Código"
            .Columns("Codigo").Visible = True

            .Columns("Descripcion").Width = 400
            .Columns("Descripcion").Caption = "Descripción"
            .Columns("Descripcion").Visible = True

            '.Columns("Talla").Width = 60
            '.Columns("Talla").Caption = "Talla"
            '.Columns("Talla").Visible = True

            .Columns("Cantidad").Width = 80
            .Columns("Cantidad").Caption = "Cantidad"
            .Columns("Cantidad").FormatString = "#,##0"
            .Columns("Cantidad").Visible = True
            'Version 2.1.3
            .Columns("Lecturado").Width = 100
            .Columns("Lecturado").Caption = "Cant. Lecturada"
            .Columns("Lecturado").FormatString = "#,##0"
            .Columns("Lecturado").Visible = True

        End With

        'oCurrentRow = Nothing
        'odrDataRow = Nothing
        'odrFiltro = Nothing

    End Sub

    Private Sub Sm_MostrarTraspasoInformacion()
        Try

            With oTraspasoEntrada

                Dim oRow As DataRow

                oRow = dtTraspaso.Rows(0)

                .Folio = oRow("Referencia")
                .FolioSAP = oRow("Referencia")

                '-----------------------------------------------------------------------------
                ' JNAVA (13.02.2015): convertimos la fecha a formato correcto
                '-----------------------------------------------------------------------------
                Dim strFecha As String = ""
                strFecha = oRow("fecha").ToString
                'strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)

                .TraspasoCreadoEl = strFecha 'oRow("fecha")
                .TraspasoRecibidoEl = strFecha 'Format(oRow("fecha"), "Short Date")
                '-----------------------------------------------------------------------------

                Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim strCentroOrig(2) As String
                Dim strCentroDest(2) As String

                strCentroOrig = oSap.Read_CentrosSAP(oRow("Origen"))

                '-----------------------------------------------------------------------------
                ' JNAVA (13.02.2015): cambiamos centro de z001 y z000 a 1000
                '-----------------------------------------------------------------------------
                If oConfigCierreFI.RecibirParcialmente Then
                    If InStr("1001,1000", CStr(oRow!Origen).Trim.ToUpper) > 0 Then 'If InStr("Z001,Z000", CStr(oRow!Origen).Trim.ToUpper) > 0 Then
                        Me.ebSucOrigenCod.Text = CStr(oRow!Origen).Trim.ToUpper
                    Else
                        ebSucOrigenCod.Text = strCentroOrig(0)      'Codigo
                    End If
                Else
                    ebSucOrigenCod.Text = strCentroOrig(0)      'Codigo
                End If
                '-----------------------------------------------------------------------------
                ebSucOrigenDesc.Text = strCentroOrig(1)     'Nomrbre

                .AlmacenOrigenID = strCentroOrig(0)

                strCentroDest = oSap.Read_CentrosSAP(oRow("Destino"))

                ebSucDestinoCod.Text = strCentroDest(0)     'Codigo
                ebSucDestinoDesc.Text = strCentroDest(1)    'Nombre

                .AlmacenDestinoID = strCentroDest(0)

                ebFolio.Text = oRow("Referencia") '.Folio    '.TraspasoID

                '-----------------------------------------------------------------------------
                ' JNAVA (13.02.2015): convertimos la fecha a formato correcto
                '-----------------------------------------------------------------------------
                ebFecha.Text = strFecha 'Format(oRow("fecha"), "Short Date")  ' Format(.TraspasoCreadoEl, "Short Date")
                '-----------------------------------------------------------------------------

                ebStatus.Text = .Status

                ebResponsableDesc.Text = oAppContext.Security.CurrentUser.Name
                .AutorizadoPorID = oAppContext.Security.CurrentUser.SessionLoginName

                ebFechaRecepcion.Text = Format(Date.Now, "Short Date")

                'Formato Grid.
                SetupView()

                '----------------------------------------------------
                ' JNAVA (15.02.2016): Adecuacion para retail
                '----------------------------------------------------
                Dim CantidadSum As Integer = 0
                For Each oRowS As DataRow In dtTraspaso.Rows
                    CantidadSum += CInt(oRowS!Cantidad)
                Next

                'ebTotalPiezas.Text = Microsoft.VisualBasic.Fix(dtTraspaso.Compute("SUM(Cantidad)", "Cantidad > 0")
                ebTotalPiezas.Text = CantidadSum

                'ebTotalLecturado.Text = "0"
                If oConfigCierreFI.RecibirParcialmente Then
                    Me.ebTotalLecturado.Text = Me.ebTotalPiezas.Text
                End If

                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Guia - Total Bultos - Paqueteria - Transportista
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (16.02.2016): Adecuaciones por retail
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim strGuia, strTransportista As String
                Dim iBultos As Integer = 0
                oSap.ReadInfoPaqueteria(ebFolio.Text, strGuia, strTransportista, iBultos)
                Me.ebNumGuia.Text = strGuia 'oSap.ReadInfoPaqueteria(ebFolio.Text, "F01")
                .Guia = Me.ebNumGuia.Text
                '------------------------------------------------------------------------------------------------------------------------------------------------------------

                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA(15.02.2016): Comentado por adecuaciones a retail
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Me.ebNumBultos.Text = oSap.ReadInfoPaqueteria(ebFolio.Text, "F02")
                'If Me.ebNoBulto.Value > 0 AndAlso Me.ebNumBultos.Text.Trim <> "" AndAlso CInt(Me.ebNumBultos.Text) > 0 Then
                '    Me.ebNumBultosRecibidos.Text = Me.ebNumBultos.Text.Trim
                '    Me.ebNumBultosRecibidos.ReadOnly = True
                '    Me.ebNumBultosRecibidos.BackColor = Color.Ivory
                'ElseIf Me.ebNumBultos.Text.Trim = "" Then
                '    Me.ebNumBultos.Text = "0"
                'End If

                'If Me.ebNumBultos.Text.Trim = String.Empty Then
                '    .TotalBultos = 0
                'Else
                '    .TotalBultos = CInt(Me.ebNumBultos.Text)
                'End If

                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (16.02.2016): Adecuaciones por retail
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                Me.ebTransportistaDesc.Text = strTransportista 'oSap.ReadInfoPaqueteria(ebFolio.Text, "F03")
                .TransportistaID = Me.ebTransportistaDesc.Text
                '------------------------------------------------------------------------------------------------------------------------------------------------------------

                Me.ebFolio.Enabled = False
                Me.GrdTraspasoCorrida.AllowEdit = InheritableBoolean.False
                Me.ebNumBultosRecibidos.Focus()

            End With

        Catch ex As Exception

            Throw New ApplicationException("[Sm_MostrarTraspasoInformacion]", ex)

        End Try

    End Sub

    Private Sub Sm_MostrarTraspasoInformacionFromGrabado()
        Try

            With oTraspasoEntrada
                'Agregamos campo lecturado para que no truene.
                oTraspasoEntrada.Detalle.Tables(0).Columns.Add("Lecturado")

                For Each oRow As DataRow In oTraspasoEntrada.Detalle.Tables(0).Rows
                    oRow("Lecturado") = oRow("Cantidad")
                Next

                oTraspasoEntrada.Detalle.Tables(0).AcceptChanges()

                Me.ebFolio.Enabled = False

                'Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                'Dim strCentroOrig(2) As String
                'Dim strCentroDest(2) As String
                'strCentroOrig = oSap.Read_CentrosSAP(.AlmacenOrigenID)
                If oConfigCierreFI.RecibirParcialmente Then
                    Dim strCentroOrigen As String = ""
                    strCentroOrigen = oSapMgr.Read_Centros(.AlmacenOrigenID)
                    If InStr("1001,1000", strCentroOrigen.Trim.ToUpper) > 0 Then
                        Me.ebSucOrigenCod.Text = strCentroOrigen.Trim.ToUpper
                    Else
                        ebSucOrigenCod.Text = .AlmacenOrigenID
                    End If
                Else
                    ebSucOrigenCod.Text = .AlmacenOrigenID
                End If

                'strCentroDest = oSap.Read_CentrosSAP(.AlmacenDestinoID)
                ebSucDestinoCod.Text = .AlmacenDestinoID
                ebFolio.Text = .FolioSAP
                ebFecha.Text = Format(.TraspasoCreadoEl, "Short Date")
                ebStatus.Text = .Status
                ebResponsableDesc.Text = .AutorizadoPorID
                ebFechaRecepcion.Text = Format(.TraspasoRecibidoEl, "Short Date")
                ebNumGuia.Text = .Guia

                ''-------------------------------------------------------------------------------------------------------------
                '' JNAVA (19.04.2016): Modificacion apra que muestre la descripcion del centro origen y destino
                ''-------------------------------------------------------------------------------------------------------------
                'Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
                'Dim oAlmacen As Almacen

                'oAlmacen = oAlmacenesMgr.Load(oSapMgr.Read_Centros(.AlmacenOrigenID))
                'If Not oAlmacen Is Nothing Then
                '    ebSucOrigenDesc.Text = oAlmacen.Descripcion
                'End If

                'oAlmacen = Nothing
                'oAlmacen = oAlmacenesMgr.Load(oSapMgr.Read_Centros(.AlmacenDestinoID))
                'If Not oAlmacen Is Nothing Then
                '    ebSucDestinoDesc.Text = oAlmacen.Descripcion
                'End If
                ''-------------------------------------------------------------------------------------------------------------

                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA(15.02.2016): Comentado por adecuaciones a retail
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                'ebNumBultos.Text = .TotalBultos
                ebNumBultosRecibidos.Value = .TotalBultos
                ebTransportistaDesc.Text = .TransportistaID

                ''------------------------------------------------------------------------------------------------------------------------------------------------------------
                '' JNAVA(15.02.2016): Comentado por adecuaciones a retail
                ''------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Dim total As Integer
                'For Each oRow As DataRow In .Detalle.Tables(0).Rows
                '    If CInt(oRow!Lecturado) > 0 Then
                '        total += CInt(oRow!Lecturado)
                '    End If
                'Next
                'ebTotalPiezas.Text = total
                ''------------------------------------------------------------------------------------------------------------------------------------------------------------
                ebTotalPiezas.Text = Microsoft.VisualBasic.Fix(.Detalle.Tables(0).Compute("SUM(Cantidad)", "Cantidad > 0"))
                Me.GrdTraspasoCorrida.DataSource = .Detalle.Tables(0)
                Me.GrdTraspasoCorrida.RetrieveStructure()
                Me.ebReferencia.Text = .Detalle.Tables(0).Rows(0).Item("FolioSAPMB01")
                Me.ebNumBultosRecibidos.ReadOnly = True
                Me.ebNumBultosRecibidos.BackColor = Color.Ivory
                'Formato Grid.
                SetupView()

            End With

        Catch ex As Exception

            Throw New ApplicationException("[Sm_MostrarTraspasoInformacionFromGrabado] ", ex)

        End Try

    End Sub

    Private Sub Sm_Nuevo()

        Sm_TxtLimpiar()

        oTraspasoEntrada = Nothing

        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)

        oTraspasoEntrada = New TraspasoEntrada(oTraspasoEntradaMgr)

        odsCatalogoCorridas = oTraspasoEntradaMgr.ExtraerCatalogoCorridas

        bEsConsignacion = False

    End Sub

    Private Sub Sm_AbrirTraspasoPendientes()
        Try
            Dim ofrmTraspasoBusqueda As New frmTraspasoBusqueda

            ofrmTraspasoBusqueda.TipoTraspaso = False

            ofrmTraspasoBusqueda.ShowDialog()

            If (ofrmTraspasoBusqueda.DialogResult = DialogResult.OK) Then

                Sm_Nuevo()

                Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                If ofrmTraspasoBusqueda.TipoBusqueda = False Then
                    'dtTraspaso = oSap.Read_TraspasosEspera(ofrmTraspasoBusqueda.CCmbFromDate.Value, ofrmTraspasoBusqueda.CCmbToDate.Value, ofrmTraspasoBusqueda.Record.Item("Referencia"), "N")
                    Me.ebFolio.Text = ofrmTraspasoBusqueda.Record.Item("Referencia")
                Else
                    'dtTraspaso = oSap.Read_TraspasosEspera(ofrmTraspasoBusqueda.CCmbFromDate.Value, ofrmTraspasoBusqueda.CCmbToDate.Value, ofrmTraspasoBusqueda.txtFolioTraspaso.Text, "N")
                    Me.ebFolio.Text = ofrmTraspasoBusqueda.txtFolioTraspaso.Text
                End If

                If Me.ebNoBulto.Visible Then
                    Me.ebNoBulto.Focus()
                Else
                    Me.GrdTraspasoCorrida.Focus()
                End If

                'ValidaTraspaso()

                '    '--------------------------------------------
                '    Dim ds As New DataSet
                '    ds.Tables.Add(dtTraspaso)
                '    oTraspasoEntrada.Detalle = New DataSet
                '    oTraspasoEntrada.Detalle = ds.Copy
                '    '--------------------------------------
                '    'Version 2.1.3
                '    Dim dcLecturado As New DataColumn
                '    With dcLecturado
                '        .ColumnName = "Lecturado"
                '        .Caption = "Cant. Lecturada"
                '        .DataType = GetType(Integer)
                '        .DefaultValue = 0

                '    End With
                '    dtTraspaso.Columns.Add(dcLecturado)

                '    Dim dcAgregado As New DataColumn
                '    With dcAgregado
                '        .ColumnName = "Agregado"
                '        .Caption = "Agregado"
                '        .DataType = GetType(Integer)
                '        .DefaultValue = 0
                '    End With

                '    dtTraspaso.Columns.Add(dcAgregado)
                '    dtTraspaso.AcceptChanges()
                '    ''''''''''



                '    GrdTraspasoCorrida.DataSource = dtTraspaso 'oTraspasoEntrada.Detalle.Tables(0)

                '    GrdTraspasoCorrida.RetrieveStructure()

                '    'oTraspasoEntrada.Status = ofrmTraspasoBusqueda.Record.Item("Status")
                '    oTraspasoEntrada.Status = "TRA"

                '    Sm_MostrarTraspasoInformacion()

                '    Me.GrdTraspasoCorrida.Focus()
            End If

            ofrmTraspasoBusqueda.Dispose()
            ofrmTraspasoBusqueda = Nothing

        Catch ex As Exception
            Throw New ApplicationException("[Sm_AbrirTraspasoPendientes]", ex)
        End Try


    End Sub

    Private Sub ValidaTraspaso()

        Try
            If Me.ebFolio.Text.Trim = "" OrElse Me.ebFolio.Value <= 0 Then
                Exit Try
            End If

            Dim strCentroOrigen As String = ""

            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Mostramos mensaje de Espera
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            oFrmMessage = New frmMessages
            With oFrmMessage
                .lblMessage.Text = "Validando Traspaso" & vbCrLf & "Favor de Esperar..."
                .Text = "Validando Traspaso ..."
                .Show()
            End With
            Application.DoEvents()
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Validamos Traspaso en SAP
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim dtTraspasoTemp As DataTable
            Dim bRes As Boolean = True
            dtTraspasoTemp = oSap.Read_TraspasosEspera(Today.ToShortDateString, Today.ToShortDateString, Me.ebFolio.Text.Trim.PadLeft(10, "0"), "N", oConfigCierreFI.RecibirParcialmente, bRes)

            dtTraspasoOriginalSAP = dtTraspasoTemp.Copy

            oFrmMessage.Close()
            Application.DoEvents()

            If bRes = False Then
                Sm_Nuevo()
                Exit Try
            ElseIf dtTraspasoTemp.Rows.Count <= 0 Then
                MessageBox.Show("El traspaso no existe o no está pendiente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Sm_Nuevo()
                Exit Try
            ElseIf oConfigCierreFI.RecibirParcialmente Then
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Validamos si el centro origen es el CDist que tenga que indicar el bulto que estan recibiendo
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                strCentroOrigen = dtTraspasoTemp.Rows(0).Item("Origen")
                ''---------------------------------------------------------------------------------------------------------------------------------------------------------
                ''rgermain 15.03.2016: Validamos si el traspaso trae producto a consignacion
                ''---------------------------------------------------------------------------------------------------------------------------------------------------------
                'bEsConsignacion = dtTraspasoTemp.Rows(0).Item("Consignacion")

                'Adaptacion para retail. Ahora se revisa que el centro origen sea el 1000
                Select Case strCentroOrigen.Trim.ToUpper
                    Case "1000", "1001" 'Case "Z000", "Z001"
                        If Me.ebNoBulto.Value <= 0 Then
                            Me.ebNoBulto.ReadOnly = False
                            Me.btnAgregar.Enabled = True
                            Me.ebNoBulto.Focus()
                            Exit Try
                            'Else
                            'Me.ebNoBulto.ReadOnly = True
                        End If
                    Case Else
                        Me.ebNoBulto.ReadOnly = True
                        Me.btnAgregar.Enabled = False
                End Select
            End If

            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            'rgermain 15.03.2016: Validamos si el traspaso trae producto a consignacion
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            bEsConsignacion = dtTraspasoTemp.Rows(0).Item("Consignacion")

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Validamos que no se haya aplicado ese bulto anteriormente si esta activada la configuracion para recibir por bulto
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim Bulto As Integer = 0

            If oConfigCierreFI.RecibirParcialmente Then

                Bulto = Me.ebNoBulto.Value

                If Bulto > 0 Then
                    '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'Validamos el bulto
                    '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If Not dtTraspaso Is Nothing AndAlso dtTraspaso.Rows.Count > 0 Then
                        Dim dvBulto As New DataView(dtTraspaso, "Bulto = " & Me.ebNoBulto.Value, "", DataViewRowState.CurrentRows)
                        If dvBulto.Count > 0 Then
                            MessageBox.Show("El bulto indicado ya esta agregado al traspaso de entrada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Me.ebNoBulto.Focus()
                            Exit Try
                        End If
                    End If
                    oFrmMessage = New frmMessages
                    With oFrmMessage
                        .lblMessage.Text = "Validando Bulto" & vbCrLf & "Favor de Esperar..."
                        .Text = "Validando Bulto ..."
                        .Show()
                    End With
                    Application.DoEvents()
                    '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If oTraspasoEntradaMgr.ValidarBultoAplicado(Me.ebFolio.Text.Trim.PadLeft(10, "0"), Bulto) OrElse _
                    oTraspasoEntradaMgr.ValidarBultoAplicadoServer(Me.ebFolio.Text.Trim.PadLeft(10, "0"), Bulto) Then
                        MessageBox.Show("El bulto " & Bulto & " del traspaso indicado ya fue aplicado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'Sm_Nuevo()
                        Me.ebNoBulto.Value = 0
                        Me.ebNoBulto.Focus()
                        oFrmMessage.Close()
                        Application.DoEvents()
                        Exit Try
                    End If
                End If
            End If
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Agregamos la columna Bulto al detalle para separar por bultos
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim dcBulto As New DataColumn
            With dcBulto
                .ColumnName = "Bulto"
                .Caption = "Bulto"
                .DataType = GetType(Integer)
                .DefaultValue = 1
            End With
            dtTraspasoTemp.Columns.Add(dcBulto)
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Separamos por bulto el detalle si esta activada la config
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.RecibirParcialmente Then
                Dim dtTraspasoBultos As DataTable
                Dim Tratado As Boolean = True

                If Bulto > 0 Then
                    dtTraspasoBultos = oTraspasoEntradaMgr.GetDetalleByBultos(Me.ebFolio.Text.Trim.PadLeft(10, "0"), Bulto, Tratado)

                    oFrmMessage.Close()
                    Application.DoEvents()

                    If dtTraspasoBultos.Rows.Count > 0 Then
                        dtTraspasoTemp = FiltrarTraspasoPorBulto(dtTraspasoTemp, dtTraspasoBultos)
                    ElseIf Tratado = True AndAlso InStr("1001,1000", strCentroOrigen.Trim.ToUpper) > 0 Then
                        MessageBox.Show("El bulto indicado no pertenece al traspaso especificado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Me.ebNoBulto.ReadOnly = False
                        Me.ebNoBulto.Focus()
                        Exit Try
                    End If
                End If
            End If
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Agregamos columnas para hacer las operaciones convenientes en caso de diferencias
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim dcLecturado As New DataColumn
            With dcLecturado
                .ColumnName = "Lecturado"
                .Caption = "Cant. Lecturada"
                .DataType = GetType(Integer)
                .DefaultValue = 0
            End With
            dtTraspasoTemp.Columns.Add(dcLecturado)

            Dim dcAgregado As New DataColumn
            With dcAgregado
                .ColumnName = "Agregado"
                .Caption = "Agregado"
                .DataType = GetType(Integer)
                .DefaultValue = 0
            End With
            dtTraspasoTemp.Columns.Add(dcAgregado)

            '---------------------------------------------------------------------------------------------------
            'FLIZARRAGA 10/05/2018: Se agrega el campo Serie
            '---------------------------------------------------------------------------------------------------
            dtTraspasoTemp.Columns.Add("Serie", GetType(String))

            For Each row As DataRow In dtTraspasoTemp.Rows
                row("Serie") = ""
                row.AcceptChanges()
            Next

            dtTraspasoTemp.AcceptChanges()
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Sumamos el bulto al traspaso de entrada
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            AgregarBultosTraslado(dtTraspasoTemp)
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Asignamos valores al traspaso de entrada
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            oTraspasoEntrada = Nothing
            oTraspasoEntrada = New TraspasoEntrada(oTraspasoEntradaMgr)
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            oTraspasoEntrada.Detalle = New DataSet
            oTraspasoEntrada.Detalle.Tables.Add(dtTraspaso)
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            UnificarCodigos(dtTraspaso)
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Igualamos las cantidades para que modifiquen solo en caso de que fisicamente reciban con diferecias
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.RecibirParcialmente Then
                IgualarCantidadesTraspaso(dtTraspaso)
            End If

            GrdTraspasoCorrida.DataSource = dtTraspaso 'oTraspasoEntrada.Detalle.Tables(0)

            GrdTraspasoCorrida.RetrieveStructure()

            'oTraspasoEntrada.Status = ofrmTraspasoBusqueda.Record.Item("Status")
            oTraspasoEntrada.Status = "TRA"

            Sm_MostrarTraspasoInformacion()

            Me.GrdTraspasoCorrida.Focus()

        Catch ex As Exception
            Throw ex 'New ApplicationException("[ValidaTraspaso]", ex)
        End Try

        Me.ebFolio.ReadOnly = True

    End Sub

    Private Sub UnificarCodigos(ByRef dtTemp As DataTable)

        Dim dtTemp2 As DataTable = dtTemp.Clone
        Dim oRow As DataRow
        Dim oRow2 As DataRow
        Dim bEnc As Boolean = False
        Dim i As Integer = -1

        '------------------------------------------------------------------------------------------
        ' JNAVA (07.03.2016): se mueve columna EBELP al final 
        '------------------------------------------------------------------------------------------
        Dim LastIndex As Integer = dtTemp2.Columns.Count - 1
        If dtTemp2.Columns.IndexOf("EBELP") < LastIndex Then
            dtTemp2.Columns("EBELP").SetOrdinal(LastIndex)
        End If
        If dtTemp2.Columns.IndexOf("Consignacion") < LastIndex Then
            dtTemp2.Columns("Consignacion").SetOrdinal(LastIndex)
        End If
        '------------------------------------------------------------------------------------------

        For Each oRow In dtTemp.Rows
            i = -1
            bEnc = False
            For Each oRow2 In dtTemp2.Rows
                i += 1
                If CStr(oRow!Codigo).Trim.ToUpper = CStr(oRow2!Codigo).Trim.ToUpper AndAlso CStr(oRow!Talla).Trim.ToUpper = CStr(oRow2!Talla).Trim.ToUpper Then
                    bEnc = True
                    Exit For
                End If
            Next
            If bEnc = False Then
                dtTemp2.ImportRow(oRow)
            Else
                dtTemp2.Rows(i)!Cantidad += oRow!Cantidad
            End If

        Next
        dtTemp2.AcceptChanges()

        dtTemp = dtTemp2.Copy

    End Sub

    Private Sub AgregarBultosTraslado(ByVal dtTemp As DataTable)

        If dtTraspaso Is Nothing OrElse dtTraspaso.Rows.Count = 0 Then
            dtTraspaso = dtTemp.Copy
        Else
            Dim oRow As DataRow
            Dim dtTempLocal As DataTable = dtTraspaso.Copy

            dtTraspaso.Dispose()
            dtTraspaso = Nothing

            dtTraspaso = dtTempLocal.Copy

            For Each oRow In dtTemp.Rows
                dtTraspaso.ImportRow(oRow)
            Next
        End If
        dtTraspaso.AcceptChanges()

    End Sub

    Private Function FiltrarTraspasoPorBulto(ByVal dtOriginal As DataTable, ByVal dtFiltrada As DataTable) As DataTable

        Dim dtFiltradaByBulto As DataTable
        Dim oRow As DataRow
        Dim oRowF As DataRow
        Dim oNewRow As DataRow
        Dim Talla As String = ""

        dtFiltradaByBulto = dtOriginal.Clone

        For Each oRow In dtOriginal.Rows
            For Each oRowF In dtFiltrada.Rows
                If InStr(CStr(oRowF!Talla), ".5", CompareMethod.Text) <= 0 And InStr(CStr(oRowF!Talla), ".0", CompareMethod.Text) <> 0 And IsNumeric(CStr(oRowF!Talla)) Then
                    Talla = CStr(CInt(oRowF!Talla))
                Else
                    Talla = CStr(oRowF!Talla)
                End If
                If CStr(oRow!Codigo).Trim.ToUpper = CStr(oRowF!MATNR).Trim.ToUpper AndAlso CStr(oRow!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
                    oRow!Cantidad = oRowF!Cantidad
                    oRow!Bulto = oRowF!NBulto
                    dtFiltradaByBulto.ImportRow(oRow)
                End If
            Next
        Next
        dtFiltradaByBulto.AcceptChanges()

        Return dtFiltradaByBulto

    End Function

    Private Sub IgualarCantidadesTraspaso(ByRef dtTemp As DataTable)

        Dim oRow As DataRow

        For Each oRow In dtTemp.Rows
            oRow!Lecturado = oRow!Cantidad
        Next
        dtTemp.AcceptChanges()

    End Sub

    Private Sub Sm_AbrirTraspaso()

        Dim oOpenRecordDlg As New OpenRecordDialog


        oOpenRecordDlg.CurrentView = New TraspasoEntradaOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oTraspasoEntrada = Nothing
            oTraspasoEntrada = oTraspasoEntradaMgr.Load(oOpenRecordDlg.Record.Item("idTraspaso"))

            Me.Sm_MostrarTraspasoInformacionFromGrabado()

        End If


    End Sub

    Private Function ValidaCamposTraspaso(ByVal dtTemp As DataTable) As Boolean

        Dim bRes As Boolean = True

        If (oTraspasoEntrada Is Nothing) Then
            MsgBox("No ha sido seleccionado un Traspaso", MsgBoxStyle.Exclamation, "DPTienda")
            bRes = False
        ElseIf (oTraspasoEntrada.Status <> "TRA") Then
            MsgBox("El Traspaso No puede ser Aplicado debido a su Status.", MsgBoxStyle.Exclamation, "DPTienda")
            bRes = False
        ElseIf oConfigCierreFI.RecibirParcialmente AndAlso (Me.ebNumBultosRecibidos.Text.Trim = "" OrElse Me.ebNumBultosRecibidos.Value <= 0) Then
            MessageBox.Show("Es necesario especificar el numero de bultos recibidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebNumBultosRecibidos.Focus()
            bRes = False
            '------------------------------------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA(15.02.2016): Comentado por adecuaciones a retail
            '------------------------------------------------------------------------------------------------------------------------------------------------------------
            'ElseIf oConfigCierreFI.RecibirParcialmente AndAlso (Me.ebNumBultos.Text.Trim = "" OrElse CInt(Me.ebNumBultos.Text) <= 0) Then
            '    MessageBox.Show("Es necesario indicarle el numero de bultos enviados al traspaso en SAP.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    bRes = False
            'ElseIf oConfigCierreFI.RecibirParcialmente AndAlso (Me.ebNumBultosRecibidos.Value > CInt(Me.ebNumBultos.Text) AndAlso ValidaSobrantes(dtTemp, "") = False) Then
            '    MessageBox.Show("Favor de verificar sus bultos, se encontraron diferencias.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Me.ebNumBultosRecibidos.Focus()
            '    bRes = False
            'ElseIf oConfigCierreFI.RecibirParcialmente AndAlso (Me.ebNumBultosRecibidos.Value < CInt(Me.ebNumBultos.Text) AndAlso ValidaFaltantes(dtTemp, "") = False) Then
            '    MessageBox.Show("Favor de verificar sus bultos, se encontraron diferencias.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Me.ebNumBultosRecibidos.Focus()
            '    bRes = False
        ElseIf ValidaCodigosEnCatalogo(dtTemp) = False Then
            bRes = False
        ElseIf oConfigCierreFI.RecibirParcialmente Then
            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosEntrada") Then
                bRes = False
                oAppContext.Security.CloseImpersonatedSession()
            Else
                UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
                UserNameAplicated = oAppContext.Security.CurrentUser.Name
            End If
            oAppContext.Security.CloseImpersonatedSession()
        End If

        Return bRes

    End Function

    Private Sub CreaEstructuraTablaDescarga(ByRef dtTemp As DataTable)

        dtTemp = New DataTable("Materiales")
        dtTemp.Columns.Add("Material", Type.GetType("System.String"))
        dtTemp.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtTemp.AcceptChanges()

    End Sub

    Private Sub AgregarCodigo(ByVal strCodigo As String, ByRef dtTemp As DataTable)

        Dim oRow As DataRow = dtTemp.NewRow
        oRow!Material = strCodigo.Trim.ToUpper
        oRow!Descripcion = ""
        dtTemp.Rows.Add(oRow)
        dtTemp.AcceptChanges()

    End Sub

    Private Function ValidaCodigosEnCatalogo(ByVal dtTemp As DataTable) As Boolean
        Dim strMateriales As String = ""
        Dim odrArticulo As DataRow
        Dim oArticulo As Articulo
        Dim bRes As Boolean = True
        Dim dtCod As DataTable
        Dim frmDescargas As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

        frmDescargas.Timer1.Enabled = False

        CreaEstructuraTablaDescarga(dtCod)

        For Each odrArticulo In dtTemp.Rows
            oArticulo = Nothing
            oArticulo = oArticulosMgr.Load(CStr(odrArticulo("Codigo")))
            ' If oArticulo Is Nothing Then

            frmDescargas.bPorCodigo = True
            frmDescargas.bMostrarMensaje = False

            dtCod.Clear()
            AgregarCodigo(CStr(odrArticulo("Codigo")).Trim, dtCod)
            frmDescargas.dtMateriales = dtCod

            frmDescargas.ShowDev("Articulos")

            oArticulo = Nothing
            oArticulo = oArticulosMgr.Load(CStr(odrArticulo("Codigo")))
            If Not oArticulo Is Nothing Then
                frmDescargas.ShowDev("Descuentos")
                frmDescargas.ShowDev("Inventarios")
            Else
                strMateriales = CStr(odrArticulo("Codigo")) & vbCrLf
            End If

            ' End If
        Next

        If strMateriales.Trim <> "" Then
            strMateriales = "Los siguientes artículos no se encuentran en su catalogo favor de hacer la descarga:" & _
                             vbCrLf & strMateriales
            MessageBox.Show(strMateriales, "Valida Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
        End If

        Return bRes

    End Function

    Private Function ValidaSobrantes(ByVal dtTemp As DataTable, ByRef strMSG As String) As Boolean
        Dim oRowSobrantesMSG As DataRowView
        Dim bRes As Boolean = False
        Dim espacio1 As Integer

        Dim dvSobrantesMSG As New DataView(dtTemp, "Lecturado > Cantidad", "Codigo", DataViewRowState.CurrentRows)

        If dvSobrantesMSG.Count > 0 Then

            bRes = True

            'If strMSG.Trim <> "" Then strMSG &= vbCrLf
            For Each oRowSobrantesMSG In dvSobrantesMSG
                espacio1 = CStr(oRowSobrantesMSG.Item("Talla")).Length
                strMSG += oRowSobrantesMSG.Item("Codigo") & "    " & oRowSobrantesMSG.Item("Talla") _
                & Space(8 - espacio1) & CStr(oRowSobrantesMSG.Item("Lecturado") - oRowSobrantesMSG.Item("Cantidad")) & "  sobrante(s)/"
            Next
        Else
            '--------------------------------------------------------------------
            ' JNAVA (17.05.2018): Validamos faltantes cuando tienen serie y cuando no
            '--------------------------------------------------------------------
            Dim CantidadR As Integer = 0
            Dim LecturadoR As Integer = 0
            Dim odvCodigo As DataView
            Dim UltimoCodigo As String = String.Empty

            For Each oRowDV As DataRow In dtTemp.Rows

                If oRowDV.Item("Codigo").ToString <> UltimoCodigo Then
                    odvCodigo = New DataView(dtTemp, "Codigo = '" & oRowDV.Item("Codigo") & "'", "Codigo", DataViewRowState.CurrentRows)

                    UltimoCodigo = oRowDV.Item("Codigo").ToString

                    CantidadR = 0
                    LecturadoR = 0

                    If odvCodigo.Count > 1 Then
                        For Each oRowDVC As DataRowView In odvCodigo
                            If Not IsDBNull(oRowDVC("Serie")) Then
                                If Not IsDBNull(oRowDVC("Referencia")) Then
                                    CantidadR = CInt(oRowDVC("Cantidad").ToString)
                                End If
                                LecturadoR += CInt(oRowDVC("Lecturado").ToString)
                            End If
                        Next

                        espacio1 = CStr(oRowDV.Item("Talla")).Length
                        strMSG &= oRowDV.Item("Codigo") & "    " & oRowDV.Item("Talla") _
                        & Space(8 - espacio1) & CStr(LecturadoR - CantidadR) & "  sobrante(s)/"

                    Else
                        CantidadR = CInt(oRowDV("Cantidad").ToString)
                        LecturadoR = CInt(oRowDV("Lecturado").ToString)

                        espacio1 = CStr(oRowDV.Item("Talla")).Length
                        strMSG &= oRowDV.Item("Codigo") & "    " & oRowDV.Item("Talla") _
                        & Space(8 - espacio1) & CStr(oRowDV.Item("Lecturado") - oRowDV.Item("Cantidad")) & "  sobrante(s)/"
                    End If
                End If

            Next
            If Not (LecturadoR > CantidadR) Then
                strMSG = String.Empty
            End If
            '--------------------------------------------------------------------
        End If

        Return bRes

    End Function

    Private Function ValidaFaltantes(ByVal dtTemp As DataTable, ByRef strMSG As String) As Boolean
        Dim oRowFaltantes As DataRowView
        Dim bRes As Boolean = False
        Dim espacio As Integer

        Dim dvFaltantes As New DataView(dtTemp, "Lecturado < Cantidad", "Codigo", DataViewRowState.CurrentRows)

        bRes = True

        '--------------------------------------------------------------------
        ' JNAVA (17.05.2018): Validamos faltantes cuando tienen serie y cuando no
        '--------------------------------------------------------------------
        If dvFaltantes.Count > 0 Then
            Dim CantidadR As Integer = 0
            Dim LecturadoR As Integer = 0
            Dim odvCodigo As DataView
            Dim UltimoCodigo As String = String.Empty

            For Each oRowDV As DataRowView In dvFaltantes

                If oRowDV.Item("Codigo").ToString <> UltimoCodigo Then
                    odvCodigo = New DataView(dtTemp, "Codigo = '" & oRowDV.Item("Codigo") & "'", "Codigo", DataViewRowState.CurrentRows)

                    UltimoCodigo = oRowDV.Item("Codigo").ToString

                    CantidadR = 0
                    LecturadoR = 0

                    If odvCodigo.Count > 1 Then
                        For Each oRowDVC As DataRowView In odvCodigo
                            If Not IsDBNull(oRowDVC("Serie")) Then
                                If Not IsDBNull(oRowDVC("Referencia")) Then
                                    CantidadR = CInt(oRowDVC("Cantidad").ToString)
                                End If
                                LecturadoR += CInt(oRowDVC("Lecturado").ToString)
                            End If
                        Next

                        espacio = CStr(oRowDV.Item("Talla")).Length
                        strMSG &= oRowDV.Item("Codigo") & "    " & oRowDV.Item("Talla") _
                        & Space(8 - espacio) & CStr(CantidadR - LecturadoR) & "  faltante(s)/"

                    Else
                        CantidadR = CInt(oRowDV("Cantidad").ToString)
                        LecturadoR = CInt(oRowDV("Lecturado").ToString)

                        espacio = CStr(oRowDV.Item("Talla")).Length
                        strMSG &= oRowDV.Item("Codigo") & "    " & oRowDV.Item("Talla") _
                        & Space(8 - espacio) & CStr(oRowDV.Item("Cantidad") - oRowDV.Item("Lecturado")) & "  faltante(s)/"
                    End If
                End If

            Next
            If Not (LecturadoR < CantidadR) Then
                strMSG = String.Empty
            End If
            '--------------------------------------------------------------------

            ''If strMSG.Trim <> "" Then strMSG &= vbCrLf
            'For Each oRowFaltantes In dvFaltantes
            '    espacio = CStr(oRowFaltantes.Item("Talla")).Length
            '    strMSG &= oRowFaltantes.Item("Codigo") & "    " & oRowFaltantes.Item("Talla") _
            '    & Space(8 - espacio) & CStr(oRowFaltantes.Item("Cantidad") - oRowFaltantes.Item("Lecturado")) & "  faltante(s)/"
            'Next

        End If

        Return bRes

    End Function

    Private Sub RealizaAjustesEntrada(ByVal dtTemp As DataTable)

        Dim dvSobrantes As New DataView(dtTemp, "Lecturado > Cantidad", "Codigo", DataViewRowState.CurrentRows)
        Dim oRowSobrantes As DataRowView
        Dim oRow As DataRow

        If dvSobrantes.Count > 0 Then
            'Asigno los datos de los articulos al detalle del oAjusteAJE
            For Each oRowSobrantes In dvSobrantes
                oRow = oAjusteAJE.Detalle.NewRow
                oRow!Codigo = oRowSobrantes.Item("Codigo")
                oRow!Talla = oRowSobrantes.Item("Talla")
                oRow!Cantidad = oRowSobrantes.Item("Lecturado") - oRowSobrantes.Item("Cantidad")
                oAjusteAJE.Detalle.Rows.Add(oRow)
            Next
            oAjusteAJE.Detalle.AcceptChanges()
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            'Guardamos el ajuste en SAP
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            GuardarAJESAP()
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            'Guardamos en las Bases Locales
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            GuardarDP("E")
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            'Guardamos en el servidor el Ajuste de Entrada
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.RecibirParcialmente Then
                GuardarInServer("E")
            End If
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            'Guardamos el movimiento de inventario
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            Me.oAjusteAJE.TipoAjuste = "E"
            Me.oAjusteMgr.PutMovimiento(Me.oAjusteAJE)

        End If

    End Sub

    Private Sub EnviarCorreoAuditoriaSobrantes(ByVal dtTemp As DataTable)
        Dim dvCorreo As New DataView(dtTemp, "Lecturado > Cantidad", "Codigo", DataViewRowState.CurrentRows)
        If dvCorreo.Count > 0 Then
            'Genero el archivo TXT 
            Dim strruta As String = ""
            Dim strArchivo As String = ""
            If ebFolio.Text.Trim <> "" Then
                strruta = "C:\TE\" & ebFolio.Text & "_Sobrantes.txt"
                strArchivo = ebFolio.Text.Trim & "_Sobrantes.txt"
            Else
                strruta = "C:\TE\" & oAppContext.ApplicationConfiguration.Almacen & " " & Date.Today.ToShortDateString & ".txt"
                strArchivo = oAppContext.ApplicationConfiguration.Almacen & " " & Date.Today.ToShortDateString & ".txt"
            End If

            If Not Directory.Exists("C:\TE") Then
                Directory.CreateDirectory("C:\TE")
            End If

            Dim txtWriter As New System.IO.StreamWriter(strruta, False)
            'Pongo el encabezado
            txtWriter.WriteLine("FOLIO TRASLADO:" & ebFolio.Text & "     FECHA:" & Date.Today.ToShortDateString)
            txtWriter.WriteLine(Chr(13))
            txtWriter.WriteLine("ORIGEN:" & Me.ebSucOrigenCod.Text & " " & Me.ebSucOrigenDesc.Text)
            txtWriter.WriteLine(Chr(13))
            txtWriter.WriteLine("DESTINO:" & Me.ebSucDestinoCod.Text & " " & Me.ebSucDestinoDesc.Text)
            txtWriter.WriteLine(Chr(13))
            txtWriter.WriteLine(Chr(13))
            If oConfigCierreFI.AjusteAutomatico = False Then
                txtWriter.WriteLine("FOLIO AJUSTE   ARTICULO            CANTIDAD  DESCRIPCION")
            Else
                txtWriter.WriteLine("ARTICULO            CANTIDAD  DESCRIPCION")
            End If

            'Pongo los articulos en el archivo txt
            Dim oRowCorreo As DataRowView
            For Each oRowCorreo In dvCorreo
                If oConfigCierreFI.AjusteAutomatico = False Then
                    txtWriter.WriteLine(CStr(oRowCorreo.Item("FolioSAP")).PadRight(15, "") & CStr(oRowCorreo.Item("Codigo")).PadRight(20, "") & CStr(oRowCorreo.Item("Lecturado") - oRowCorreo.Item("Cantidad")).PadRight(10, "") & oRowCorreo.Item("Descripcion"))
                Else
                    txtWriter.WriteLine(CStr(oRowCorreo.Item("Codigo")).PadRight(20, "") & CStr(oRowCorreo.Item("Lecturado") - oRowCorreo.Item("Cantidad")).PadRight(10, "") & oRowCorreo.Item("Descripcion"))
                End If
            Next

            txtWriter.Close()
            txtWriter = Nothing
            'Mando el correo
            Dim objSmtpServer As SmtpMail
            Dim SmtpClient As New System.Net.Mail.SmtpClient
            Dim Credencial As New NetworkCredential(oConfigCierreFI.CuentaCorreo, oConfigCierreFI.PasswordCorreo)
            Dim message As New System.Net.Mail.MailMessage()
            Dim Mail As New System.Net.Mail.MailAddress(oConfigCierreFI.CuentaCorreo)
            Dim Body As String = "", strTo As String = ""

            SmtpClient.Host = oConfigCierreFI.ServidorSMTP
            SmtpClient.Port = oConfigCierreFI.PuertoSMTP
            SmtpClient.UseDefaultCredentials = False
            SmtpClient.Credentials = Credencial
            SmtpClient.EnableSsl = True

            message.From = Mail
            message.Subject = "Sobrantes en Traspaso de Entrada: " & ebFolio.Text
            message.IsBodyHtml = False
            message.BodyEncoding = System.Text.Encoding.UTF8
            message.Body = "En al archivo adjunto vienen los articulos que generaron sobrantes en Traspaso de Entrada:" & ebFolio.Text
            For i As Integer = 0 To FirmaConfig.CuentasCorreoAuditoria.Length - 2
                strTo &= FirmaConfig.CuentasCorreoAuditoria(i)
                If i < FirmaConfig.CuentasCorreoAuditoria.Length - 2 Then
                    message.To.Add(strTo)
                End If
            Next
            Dim MailAttachment As New System.Net.Mail.Attachment(strruta)
            message.Attachments.Add(MailAttachment)
            Try
                SmtpClient.Send(message)
                If File.Exists(strruta) Then
                    File.Delete(strruta)
                End If
            Catch ex As Exception
                MessageBox.Show("No se pudo enviar correo de Sobrantes en Traspaso de Entrada." & Microsoft.VisualBasic.vbCrLf & "Favor de enviarlo manualmente a " & strTo & Microsoft.VisualBasic.vbCrLf & Microsoft.VisualBasic.vbCrLf & "La ruta es C:\TE\" & Microsoft.VisualBasic.vbCrLf & "Archivo:" & strArchivo, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                EscribeLog(ex.Message, "No se pudo enviar correo de sobrantes en traspaso de entrada")
            End Try
        End If
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/09/2015: Envia correos de faltantes a auditoria
    '-----------------------------------------------------------------------------------------------------------------------------
    Private Sub EnviarCorreoAuditoriaFaltantes(ByVal dtTemp As DataTable)
        Dim dvCorreo As New DataView(dtTemp, "Lecturado < Cantidad", "Codigo", DataViewRowState.CurrentRows)
        If dvCorreo.Count > 0 Then
            'Genero el archivo TXT 
            Dim strruta As String = ""
            Dim strArchivo As String = ""
            If ebFolio.Text.Trim <> "" Then
                strruta = "C:\TE\" & ebFolio.Text & "_Faltantes.txt"
                strArchivo = ebFolio.Text.Trim & "_Faltantes.txt"
            Else
                strruta = "C:\TE\" & oAppContext.ApplicationConfiguration.Almacen & " " & Date.Today.ToShortDateString & ".txt"
                strArchivo = oAppContext.ApplicationConfiguration.Almacen & " " & Date.Today.ToShortDateString & ".txt"
            End If

            If Not Directory.Exists("C:\TE") Then
                Directory.CreateDirectory("C:\TE")
            End If

            Dim txtWriter As New System.IO.StreamWriter(strruta, False)
            'Pongo el encabezado
            txtWriter.WriteLine("FOLIO TRASLADO:" & ebFolio.Text & "     FECHA:" & Date.Today.ToShortDateString)
            txtWriter.WriteLine(Chr(13))
            txtWriter.WriteLine("ORIGEN:" & Me.ebSucOrigenCod.Text & " " & Me.ebSucOrigenDesc.Text)
            txtWriter.WriteLine(Chr(13))
            txtWriter.WriteLine("DESTINO:" & Me.ebSucDestinoCod.Text & " " & Me.ebSucDestinoDesc.Text)
            txtWriter.WriteLine(Chr(13))
            txtWriter.WriteLine(Chr(13))
            If oConfigCierreFI.AjusteAutomatico = False Then
                txtWriter.WriteLine("FOLIO AJUSTE   ARTICULO            CANTIDAD  DESCRIPCION")
            Else
                txtWriter.WriteLine("ARTICULO            CANTIDAD  DESCRIPCION")
            End If

            'Pongo los articulos en el archivo txt
            Dim oRowCorreo As DataRowView
            For Each oRowCorreo In dvCorreo
                If oConfigCierreFI.AjusteAutomatico = False Then
                    txtWriter.WriteLine(CStr(oRowCorreo.Item("FolioSAP")).PadRight(15, "") & CStr(oRowCorreo.Item("Codigo")).PadRight(20, "") & CStr(oRowCorreo.Item("Lecturado") - oRowCorreo.Item("Cantidad")).PadRight(10, "") & oRowCorreo.Item("Descripcion"))
                Else
                    txtWriter.WriteLine(CStr(oRowCorreo.Item("Codigo")).PadRight(20, "") & CStr(oRowCorreo.Item("Lecturado") - oRowCorreo.Item("Cantidad")).PadRight(10, "") & oRowCorreo.Item("Descripcion"))
                End If
            Next

            txtWriter.Close()
            txtWriter = Nothing

            'Mando el correo
            Dim objSmtpServer As SmtpMail
            Dim SmtpClient As New System.Net.Mail.SmtpClient
            Dim Credencial As New NetworkCredential(oConfigCierreFI.CuentaCorreo, oConfigCierreFI.PasswordCorreo)
            Dim message As New System.Net.Mail.MailMessage()
            Dim Mail As New System.Net.Mail.MailAddress(oConfigCierreFI.CuentaCorreo)
            Dim strTo As String = ""

            SmtpClient.Host = oConfigCierreFI.ServidorSMTP
            SmtpClient.Port = oConfigCierreFI.PuertoSMTP
            SmtpClient.UseDefaultCredentials = False
            SmtpClient.Credentials = Credencial
            SmtpClient.EnableSsl = True

            message.From = Mail
            message.IsBodyHtml = False
            message.BodyEncoding = System.Text.Encoding.UTF8
            message.Body = "Faltantes en Traspaso de Entrada: " & ebFolio.Text
            message.Body = "En al archivo adjunto vienen los articulos que generaron faltantes en Traspaso de Entrada:" & ebFolio.Text
            For i As Integer = 0 To FirmaConfig.CuentasCorreoAuditoria.Length - 2
                strTo &= FirmaConfig.CuentasCorreoAuditoria(i)
                If i < FirmaConfig.CuentasCorreoAuditoria.Length - 2 Then
                    message.To.Add(strTo)
                End If
            Next
            Dim MailAttachment As New System.Net.Mail.Attachment(strruta)
            message.Attachments.Add(MailAttachment)
            Try
                SmtpClient.Send(message)
                If File.Exists(strruta) Then
                    File.Delete(strruta)
                End If
            Catch ex As Exception
                MessageBox.Show("No se pudo enviar correo de Faltantes en Traspaso de Entrada." & Microsoft.VisualBasic.vbCrLf & "Favor de enviarlo manualmente a " & strTo & Microsoft.VisualBasic.vbCrLf & Microsoft.VisualBasic.vbCrLf & "La ruta es C:\TE\" & Microsoft.VisualBasic.vbCrLf & "Archivo:" & strArchivo, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                EscribeLog(ex.Message, "No se pudo enviar correo de Faltantes en Traspaso de Entrada.")
            End Try
        End If
    End Sub

    Private Sub EnviarCorreoAuditoriaFaltantes(ByVal dtTemp As DataTable, ByVal CentroDesSAP As String, ByVal bPaqueteria As Boolean)
        If dtTemp.Rows.Count > 0 Then
            'Genero el archivo TXT 
            Dim strruta As String = ""
            Dim strArchivo As String = ""
            If ebFolio.Text.Trim <> "" Then
                strruta = "C:\TE\" & ebFolio.Text & ".txt"
                strArchivo = ebFolio.Text.Trim & ".txt"
            Else
                strruta = "C:\TE\" & oAppContext.ApplicationConfiguration.Almacen & " " & Date.Today.ToShortDateString & ".txt"
                strArchivo = oAppContext.ApplicationConfiguration.Almacen & " " & Date.Today.ToShortDateString & ".txt"
            End If

            If Not Directory.Exists("C:\TE") Then
                Directory.CreateDirectory("C:\TE")
            End If

            Dim txtWriter As New System.IO.StreamWriter(strruta, False)
            'Pongo el encabezado
            txtWriter.WriteLine("FOLIO TRASLADO: " & ebFolio.Text & "     FECHA: " & Date.Today.ToShortDateString)
            txtWriter.WriteLine(Chr(13))
            txtWriter.WriteLine("ORIGEN: " & Me.ebSucOrigenCod.Text & " " & Me.ebSucOrigenDesc.Text)
            txtWriter.WriteLine(Chr(13))
            txtWriter.WriteLine("DESTINO: " & Me.ebSucDestinoCod.Text & " " & Me.ebSucDestinoDesc.Text)
            txtWriter.WriteLine(Chr(13))
            txtWriter.WriteLine(Chr(13))
            txtWriter.WriteLine("ARTICULO            CANTIDAD  DESCRIPCION")

            'Pongo los articulos en el archivo txt
            Dim oRowCorreo As DataRow
            For Each oRowCorreo In dtTemp.Rows
                txtWriter.WriteLine(CStr(oRowCorreo.Item("Codigo")).PadRight(20, "") & _
                                    CStr(oRowCorreo.Item("Cantidad")).PadRight(10, "") & Math.Round(CDec(oRowCorreo.Item("Costo")), 2))
            Next

            txtWriter.Close()
            txtWriter = Nothing

            'Mando el correo
            Dim objSmtpServer As SmtpMail
            Dim SmtpClient As New System.Net.Mail.SmtpClient
            Dim Credencial As New NetworkCredential(oConfigCierreFI.CuentaCorreo, oConfigCierreFI.PasswordCorreo)
            Dim message As New System.Net.Mail.MailMessage()
            Dim Mail As New System.Net.Mail.MailAddress(oConfigCierreFI.CuentaCorreo)
            Dim MailAttachment As System.Net.Mail.Attachment
            Dim str As String = ""
            Dim strTo As String = ""
            Dim RutaPDF As String = ""

            SmtpClient.Host = oConfigCierreFI.ServidorSMTP
            SmtpClient.Port = oConfigCierreFI.PuertoSMTP
            SmtpClient.UseDefaultCredentials = False
            SmtpClient.Credentials = Credencial
            SmtpClient.EnableSsl = True

            message.From = Mail
            message.IsBodyHtml = False
            message.BodyEncoding = System.Text.Encoding.UTF8
            '---------------------------------------------------------------------------------------------------------------------------
            'Adjuntamos los correos de los auditores como destinatarios
            '---------------------------------------------------------------------------------------------------------------------------
            For Each str In oConfigCierreFI.CuentasCorreoAuditoria
                If Not str Is Nothing AndAlso str.Trim <> "" Then
                    message.To.Add(str)
                End If
            Next
            '---------------------------------------------------------------------------------------------------------------------------
            'En caso de reclamacion a paqueteria se mandan adjuntos el traspaso de entrada y la carta de reclamacion
            '---------------------------------------------------------------------------------------------------------------------------
            If bPaqueteria Then
                '---------------------------------------------------------------------------------------------------------------------------
                'Generamos el archivo del traspaso de entrada en PDF y lo adjuntamos
                '---------------------------------------------------------------------------------------------------------------------------
                RutaPDF = ExportaTraspasoPDF()
                If RutaPDF.Trim <> "" Then
                    MailAttachment = New System.Net.Mail.Attachment(RutaPDF)
                    message.Attachments.Add(MailAttachment)
                End If
                '---------------------------------------------------------------------------------------------------------------------------
                'Buscamos los archivos que se adjuntaran
                '---------------------------------------------------------------------------------------------------------------------------
                Dim strRutas As String = AdjuntarArchivosXFaltantes()
                '---------------------------------------------------------------------------------------------------------------------------
                'Adjuntamos los archivos encontrados
                '---------------------------------------------------------------------------------------------------------------------------
                Dim strFiles() As String

                If strRutas.Trim <> "" Then
                    strFiles = strRutas.Trim.Split("|")
                    For Each str In strFiles
                        If Not str Is Nothing AndAlso str.Trim <> "" Then
                            MailAttachment = New System.Net.Mail.Attachment(str)
                            message.Attachments.Add(MailAttachment)
                        End If
                    Next
                End If
                '---------------------------------------------------------------------------------------------------------------------------
                'Si es al CDIST al que se le devolveran los faltantes o existe una reclamación a la paqueteria se le envia el correo a los 
                'configurados por errores del CDIST también
                '---------------------------------------------------------------------------------------------------------------------------
                If InStr("1000,1001", CentroDesSAP.Trim.ToUpper) > 0 OrElse bPaqueteria Then
                    For Each str In oConfigCierreFI.CuentasCorreoErroresCDist
                        If Not str Is Nothing AndAlso str.Trim <> "" Then
                            message.To.Add(str)
                        End If
                    Next
                End If
                '---------------------------------------------------------------------------------------------------------------------------
                'Si es una tienda a la que se le devolveran los faltantes se le envia el correo también
                '---------------------------------------------------------------------------------------------------------------------------
                If CentroDesSAP.Trim.ToUpper.Substring(0, 1) <> "Z" Then
                    '---------------------------------------------------------------------------------------------------------------------------
                    ' JNAVA (11.02.2016): Adaptacion por retail
                    '---------------------------------------------------------------------------------------------------------------------------
                    'Dim dtCliente As DataTable
                    'dtCliente = oSapMgr.ZBAPI_GET_CLIENTE(CentroDesSAP.Trim.Substring(1, 3).PadLeft(10, "0"), "")
                    'If dtCliente.Rows.Count > 0 Then
                    '    str = CStr(dtCliente.Rows(0)!KNURL).Trim
                    '    If str.Trim <> "" Then strTo &= str & ";"
                    'End If
                    Dim Correo As String
                    Correo = oSapMgr.ZSD_OBTENER_CORREO_OFI_VENTA(CentroDesSAP.Trim.Substring(1, 3).PadLeft(10, "0"))
                    str = Correo.Trim
                    If str.Trim <> "" Then message.To.Add(str)
                    '---------------------------------------------------------------------------------------------------------------------------
                End If
                message.Subject = "Traspaso de Salida pendiente por faltantes en Traspaso de Entrada: " & ebFolio.Text
                message.Body = "En al archivo adjunto vienen los articulos que generaron faltantes en Traspaso de Entrada: " & ebFolio.Text
                MailAttachment = New System.Net.Mail.Attachment(strruta)
                message.Attachments.Add(MailAttachment)
                Try
                    SmtpClient.Send(message)
                    If File.Exists(strruta) Then
                        File.Delete(strruta)
                    End If
                    If bPaqueteria Then
                        If File.Exists(RutaPDF) Then File.Delete(RutaPDF)
                    End If
                Catch ex As Exception
                    EscribeLog(ex.ToString, "Error al enviar correo de faltantes: Linea " & Err.Erl)
                    MessageBox.Show("No se pudo enviar correo de Faltantes en Traspaso de Entrada." & Microsoft.VisualBasic.vbCrLf & "Favor de enviarlo manualmente a : " & str & " y  tu Auditor de Plaza." & Microsoft.VisualBasic.vbCrLf & Microsoft.VisualBasic.vbCrLf & "La ruta es C:\" & Microsoft.VisualBasic.vbCrLf & "Archivo:" & strArchivo, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If
        End If
    End Sub

    Private Sub ActualizaExistencias(ByVal dtArticulos As DataTable)
        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim dtResultado As DataTable
        Dim valorTalla As String = String.Empty
        Dim decimales As String = String.Empty

        dtResultado = oSap.ExistenciasUpdate(dtArticulos)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            For Each oRow As DataRow In dtResultado.Rows
                Dim talla As String = oRow!J_3ASIZE & " "
                valorTalla = oRow!J_3ASIZE

                If talla.Trim <> "" Then
                    If talla.IndexOf(".") > 0 Then
                        decimales = talla.Substring(talla.IndexOf(".") + 1, 1)
                        If CInt(decimales) = 0 Then
                            valorTalla = talla.Substring(0, talla.IndexOf("."))
                        Else
                            valorTalla = talla
                        End If
                    End If
                End If

                oSap.UpdateExistenciaSAP(oRow!MATNR, oRow!LABST, oRow!APARTADO, oRow!DEFECTUOSO, valorTalla)
            Next
        End If

    End Sub

    Private Sub GuardarDiferencias(ByRef dtTemp As DataTable)
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Columna para calcular diferencia
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim dcRestante As New DataColumn
        With dcRestante
            .ColumnName = "Restante"
            .DataType = GetType(Integer)
            .Expression = "Cantidad - Lecturado"
        End With
        dtTemp.Columns.Add(dcRestante)
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Columna para el tipo de resultado
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim dcTipo As New DataColumn
        With dcTipo
            .ColumnName = "Tipo"
            .DataType = GetType(String)
            .DefaultValue = ""
        End With
        dtTemp.Columns.Add(dcTipo)
        dtTemp.AcceptChanges()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'DataView para asignar el tipo al registro de los faltantes
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim dvDetalleFal As New DataView(dtTemp, "Restante > 0", "Codigo", DataViewRowState.CurrentRows)
        If dvDetalleFal.Count > 0 Then
            For Each oRowFal As DataRowView In dvDetalleFal
                oRowFal.Item("Tipo") = "FALTANTE"
            Next
            dtTemp.AcceptChanges()
        End If
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'DataView para asignar el tipo al registro de los sobrantes
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim dvDetalleSob As New DataView(dtTemp, "Restante < 0", "Codigo", DataViewRowState.CurrentRows)
        If dvDetalleSob.Count > 0 Then
            For Each oRowSob As DataRowView In dvDetalleSob
                oRowSob.Item("Tipo") = "SOBRANTE"
            Next
            dtTemp.AcceptChanges()
        End If

        Dim dvDetalle As New DataView(dtTraspaso, "Restante <> 0", "Tipo, Codigo", DataViewRowState.CurrentRows)
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Valido si hubo diferencias
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        If dvDetalle.Count > 0 Then
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Si hubo diferencias las guardo en las tablas locales
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            oTraspasoEntradaMgr.SaveArtNoLecturados(Me.ebSucOrigenCod.Text, Me.ebSucOrigenDesc.Text, Me.ebSucDestinoCod.Text, _
                            Me.ebSucDestinoDesc.Text, Me.ebFolio.Text, Me.UserSessionAplicated.Trim, "TE", dvDetalle)




            '---------------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS (11.07.2022): Grabar a la base local los artículos en Aclaración
            '---------------------------------------------------------------------------------------------------------------------------
            Dim dtArtAclaracion As DataTable
            dtArtAclaracion = dvDetalle.ToTable
            oTraspasoEntradaMgr.SaveArtEnAclaracion(dtArtAclaracion, Me.ebFolio.Text)

            '---------------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS (03.09.2021): Grabar a SAP la información de faltantes, se utiliza la rutina que va a SAP por el BUS
            '---------------------------------------------------------------------------------------------------------------------------
            Dim dtResult As DataTable
            'dtResult = oSapMgr.ZFMCOM_ACLARACION(Me.ebFolio.Text, dvDetalle, "I") Rutina directa a la RFC de SAP
            dtResult = SaveZFMComAclaracion(Me.ebFolio.Text, dvDetalle, "I")
            If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
                Dim strMsg As String = oTraspasoEntradaMgr.UpdateFolioArtNoLecturados(Me.ebFolio.Text, dtResult)
                If strMsg.Length > 0 Then
                    MsgBox("Ocurrio un error al actualizar los faltantes en SAP " & vbCrLf & strMsg, MsgBoxStyle.Exclamation, "DPTienda.")
                End If
            End If


            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Si hubo diferencias las guardo en el server si esta activada la config
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.RecibirParcialmente Then
                Try
                    oTraspasoEntradaMgr.SaveArtNoLecturadosInServer(Me.ebSucOrigenCod.Text, Me.ebSucOrigenDesc.Text, Me.ebSucDestinoCod.Text, _
                                               Me.ebSucDestinoDesc.Text, Me.ebFolio.Text, Me.UserSessionAplicated.Trim, "TE", dvDetalle)

                Catch ex As Exception
                    EscribeLog(ex.ToString, "Error al guardar las diferencias en server en el traspaso de entrada " & Me.ebFolio.Text.Trim)
                End Try
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Se imprime el reporte
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.ValidacionFS = False Then

                Try
                    MsgBox("Prepare su impresora, y ponga hojas", MsgBoxStyle.Information, "Traspaso de Entrada")
                    Dim oARReporte As New rptArtNoLecturados(Me.GetAlmacen(), "TRASPASO DE ENTRADA", _
                                                             Me.ebSucOrigenCod.Text, Me.ebSucOrigenDesc.Text, Me.ebSucDestinoCod.Text, _
                                                             Me.ebSucDestinoDesc.Text, Me.ebFolio.Text, Me.UserSessionAplicated.Trim)
                    'Dim oReportViewer As New ReportViewerForm

                    oARReporte.Document.Name = "Articulos No Lecturados"
                    oARReporte.DataSource = dvDetalle
                    oARReporte.Run()

                    'oReportViewer.Report = oARReporte
                    'oReportViewer.Show()

                    Try
                        oARReporte.Document.Print(False, False)
                    Catch ex As Exception
                        MsgBox(ex.ToString & " Error al intentar imprimir")
                    End Try

                Catch ex As ApplicationException
                    MsgBox(ex.ToString)
                End Try
            End If
        End If

    End Sub

    Private Sub Sm_AplicarTraspaso2()

        '<Validación>

        'If (oTraspasoEntrada Is Nothing) Then
        '    MsgBox("No ha sido seleccionado un Traspaso", MsgBoxStyle.Exclamation, "DPTienda")
        '    Exit Sub
        'End If


        'If (oTraspasoEntrada.Status <> "TRA") Then
        '    MsgBox("El Traspaso No puede ser Aplicado debido a su Status.", MsgBoxStyle.Exclamation, "DPTienda")
        '    Exit Sub
        'End If

        If ValidaCamposTraspaso(oTraspasoEntrada.Detalle.Tables(0)) = False Then
            Exit Sub
        End If

        'If ebTotalPiezas.Text <> ebTotalLecturado.Text Then
        '    If MsgBox("Los artículos no se han lecturado completamente. ¿Desea continuar?", MsgBoxStyle.YesNo, "DPTienda") = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'End If

        '</Validación>
        'I. EARAGON 
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Validamos que el Catalogo de Materiales tenga todos los los que vienen en el traspaso.
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '09/02/2007
        'Dim strMateriales As String
        'strMateriales = String.Empty
        'For Each odrArticulo As DataRow In oTraspasoEntrada.Detalle.Tables(0).Rows
        '    Dim oCatalogoArticuloMgr As New CatalogoArticuloManager(oAppContext)
        '    Dim oArticulo As Articulo

        '    oArticulo = Nothing
        '    oArticulo = oCatalogoArticuloMgr.Load(CType(odrArticulo("Codigo"), String))
        '    If oArticulo Is Nothing Then
        '        strMateriales = CStr(odrArticulo("Codigo")) & Microsoft.VisualBasic.vbCrLf
        '    End If
        'Next

        'If strMateriales.Trim <> String.Empty Then
        '    strMateriales = "Los siguientes artículos no se encuentran en su catalogo favor de hacer la descarga:" & _
        '    Microsoft.VisualBasic.vbCrLf & strMateriales
        '    MessageBox.Show(strMateriales, "Valida Materiales", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        'F. EARAGON 

        'Mensaje de advertencia
        Dim strMSG As String = ""
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Sobrantes
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ValidaSobrantes(dtTraspaso, strMSG)
        'Dim dvSobrantesMSG As New DataView(dtTraspaso, "Lecturado > Cantidad", "Codigo", DataViewRowState.CurrentRows)
        'If dvSobrantesMSG.Count > 0 Then
        '    Dim espacio1 As Integer
        '    For Each oRowSobrantesMSG As DataRowView In dvSobrantesMSG
        '        espacio1 = CStr(oRowSobrantesMSG.Item("Talla")).Length
        '        strMSG += oRowSobrantesMSG.Item("Codigo") & "    " & oRowSobrantesMSG.Item("Talla") _
        '        & Space(8 - espacio1) & CStr(oRowSobrantesMSG.Item("Lecturado") - oRowSobrantesMSG.Item("Cantidad")) & "  sobrante(s)/"
        '    Next
        'End If
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Faltantes
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ValidaFaltantes(dtTraspaso, strMSG)
        'Dim dvSobrantesF As New DataView(dtTraspaso, "Lecturado < Cantidad", "Codigo", DataViewRowState.CurrentRows)
        'If dvSobrantesF.Count > 0 Then
        '    If Not strMSG = "" Then
        '        strMSG += Microsoft.VisualBasic.vbCrLf
        '    End If
        '    Dim espacio As Integer
        '    For Each oRowSobrantesF As DataRowView In dvSobrantesF
        '        espacio = CStr(oRowSobrantesF.Item("Talla")).Length
        '        strMSG += oRowSobrantesF.Item("Codigo") & "    " & oRowSobrantesF.Item("Talla") _
        '        & Space(8 - espacio) & CStr(oRowSobrantesF.Item("Cantidad") - oRowSobrantesF.Item("Lecturado")) & "  faltante(s)/"
        '    Next
        'End If
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Mensaje de advertencia
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        If strMSG.Trim <> "" AndAlso oConfigCierreFI.ValidacionFS = False Then
            'If oConfigCierreFI.ValidacionFS = False Then
            Dim oForm As New frmTEMSG(strMSG)
            oForm.ShowDialog()
            If oForm.DialogResult = DialogResult.Cancel Then
                Exit Sub
            End If
            'End If
        End If

        Cursor.Current = Cursors.WaitCursor
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (13.02.2016): Se comento pro que la BAPI ZBAPIMM02_PEDIDOTRAS realiza la funcionalidad (Retail)
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ''---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ''Aplicamos traspaso en SAP
        ''---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'ebReferencia.Text = oSapMgr.Write_TrasladoEntradaSAPMM02(oTraspasoEntrada.Folio)
        'If ebReferencia.Text = "" Then
        '    MsgBox("El Traspaso de Entrada No se Aplico en SAP", MsgBoxStyle.Critical, "DPTienda")
        '    Exit Sub
        'End If
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Aqui se hacen los ajustes de entrada en caso de haber sobrantes
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        RealizaAjustesEntrada(dtTraspaso)
        'Dim dvSobrantes As New DataView(dtTraspaso, "Lecturado > Cantidad", "Codigo", DataViewRowState.CurrentRows)
        'If dvSobrantes.Count > 0 Then
        '    'Asigno los datos de los articulos al detalle del oAjusteAJE
        '    For Each oRowSobrantes As DataRowView In dvSobrantes
        '        Dim oRow As DataRow = oAjusteAJE.Detalle.NewRow
        '        oRow!Codigo = oRowSobrantes.Item("Codigo")
        '        oRow!Talla = oRowSobrantes.Item("Talla")
        '        oRow!Cantidad = oRowSobrantes.Item("Lecturado") - oRowSobrantes.Item("Cantidad")
        '        oAjusteAJE.Detalle.Rows.Add(oRow)
        '    Next
        '    oAjusteAJE.Detalle.AcceptChanges()

        '    GuardarAJESAP()
        '    GuardarDP("E")
        '    'GuardarFoliosSAp("E")
        '    Me.oAjusteAJE.TipoAjuste = "E"
        '    Me.oAjusteMgr.PutMovimiento(Me.oAjusteAJE)
        '    'Me.oAjusteMgr.UpdateESNuevoEstado(Me.nbFolioAUT.Value, "GRA")
        'End If

        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Mando un correo a Manuel Camacho y Karla Guillen con los datos de los sobrantes
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        EnviarCorreoAuditoriaSobrantes(dtTraspaso)
        'Dim dvCorreo As New DataView(dtTraspaso, "Lecturado > Cantidad", "Codigo", DataViewRowState.CurrentRows)
        'If dvCorreo.Count > 0 Then
        '    'Genero el archivo TXT 
        '    Dim strruta As String = ""
        '    Dim strArchivo As String = ""
        '    If ebFolio.Text <> "" Then
        '        strruta = "C:\" & ebFolio.Text & ".txt"
        '        strArchivo = ebFolio.Text & ".txt"
        '    Else
        '        strruta = "C:\" & oAppContext.ApplicationConfiguration.Almacen & " " & Date.Today.ToShortDateString & ".txt"
        '        strArchivo = oAppContext.ApplicationConfiguration.Almacen & " " & Date.Today.ToShortDateString & ".txt"
        '    End If

        '    Dim txtWriter As New System.IO.StreamWriter(strruta, False)
        '    'txtWriter.WriteLine(Chr(13))
        '    'Pongo el encabezado
        '    txtWriter.WriteLine("FOLIO TRASLADO:" & ebFolio.Text & "     FECHA:" & Date.Today.ToShortDateString)
        '    txtWriter.WriteLine(Chr(13))
        '    txtWriter.WriteLine("ORIGEN:" & Me.ebSucOrigenCod.Text & " " & Me.ebSucOrigenDesc.Text)
        '    txtWriter.WriteLine(Chr(13))
        '    txtWriter.WriteLine("DESTINO:" & Me.ebSucDestinoCod.Text & " " & Me.ebSucDestinoDesc.Text)
        '    txtWriter.WriteLine(Chr(13))
        '    txtWriter.WriteLine(Chr(13))
        '    txtWriter.WriteLine("FOLIO AJUSTE   ARTICULO            TALLA     CANTIDAD  DESCRIPCION")

        '    'Pongo los articulos en el archivo txt
        '    For Each oRowCorreo As DataRowView In dvCorreo
        '        txtWriter.WriteLine(CStr(oRowCorreo.Item("FolioSAP")).PadRight(15, "") & CStr(oRowCorreo.Item("Codigo")).PadRight(20, "") & CStr(oRowCorreo.Item("Talla")).PadRight(10, "") & CStr(oRowCorreo.Item("Lecturado") - oRowCorreo.Item("Cantidad")).PadRight(10, "") & oRowCorreo.Item("Descripcion"))
        '    Next

        '    txtWriter.Close()
        '    txtWriter = Nothing

        '    'Mando el correo
        '    Dim mmMail As New MailMessage
        '    Dim objSmtpServer As SmtpMail
        '    Dim strTo As String = ""

        '    For i As Integer = 0 To FirmaConfig.CuentasCorreoAuditoria.Length - 2
        '        strTo &= FirmaConfig.CuentasCorreoAuditoria(i)
        '        If i < FirmaConfig.CuentasCorreoAuditoria.Length - 2 Then
        '            strTo &= ";"
        '        End If
        '    Next
        '    mmMail.From = FirmaConfig.CuentaCorreo
        '    mmMail.To = strTo
        '    'mmMail.To = "mcamacho@dportenis.com.mx;kguillen@dportenis.com.mx"
        '    'mmMail.To = "beny.rios@dportenis.com.mx"
        '    mmMail.Subject = "Sobrantes en Traspaso de Entrada:" & ebFolio.Text
        '    mmMail.Body = "En al archivo adjunto vienen los articulos que generaron sobrantes en Traspaso de Entrada:" & ebFolio.Text
        '    Dim oAttachment As MailAttachment = New MailAttachment(strruta)
        '    mmMail.Attachments.Add(oAttachment)
        '    objSmtpServer.SmtpServer = FirmaConfig.ServidorSMTP
        '    Try
        '        objSmtpServer.Send(mmMail)
        '        If File.Exists(strruta) Then
        '            File.Delete(strruta)
        '        End If
        '        'MessageBox.Show("ok", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Catch ex As Exception
        '        MessageBox.Show("No se pudo enviar correo de Sobrantes en Traspaso de Entrada." & Microsoft.VisualBasic.vbCrLf & "Favor de enviarlo manualmente a Karla Guillen y Manuel Camacho." & Microsoft.VisualBasic.vbCrLf & Microsoft.VisualBasic.vbCrLf & "La ruta es C:\" & Microsoft.VisualBasic.vbCrLf & "Archivo:" & strArchivo, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End Try

        'End If
        '---------------------------------------------------------------------------------------------------------------------------------------------------------
        'Aplico el Traspaso de entrada en las bases locales
        '---------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoEntrada.TraspasoRecibidoEl = Now.ToShortDateString
        If (oTraspasoEntradaMgr.AplicarEntrada(oTraspasoEntrada, UserSessionAplicated, UserNameAplicated, False, bEsConsignacion) = True) Then

            With oTraspasoEntrada
                ebFechaRecepcion.Text = Format(.TraspasoRecibidoEl, "Short Date")
                ebReferencia.Text = .Referencia
                ebStatus.Text = .Status
                ebResponsableDesc.Text = .AutorizadoPorID
            End With
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            'Guardo los motivos de captura manual
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            Try
                If Not oTraspasoEntrada.dtMotivos Is Nothing Then
                    For Each orow As DataRow In oTraspasoEntrada.dtMotivos.Rows
                        oTraspasoEntradaMgr.SaveMotivo(oTraspasoEntrada.Folio, orow("Tienda"), orow("Articulo"), orow("Talla"), orow("IdMotivo"), "TE")
                    Next
                End If
            Catch ex As Exception
            End Try
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            'Guardar los articulos no lecturados y generar reporte
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            GuardarDiferencias(dtTraspaso)
            'If ebTotalPiezas.Text <> ebTotalLecturado.Text Then
            'Columna para calcular la resta
            'Dim dcRestante As New DataColumn
            'With dcRestante
            '    .ColumnName = "Restante"
            '    .DataType = GetType(Integer)
            '    .Expression = "Cantidad - Lecturado"
            'End With
            'dtTraspaso.Columns.Add(dcRestante)

            ''Columna para el tipo de resultado
            'Dim dcTipo As New DataColumn
            'With dcTipo
            '    .ColumnName = "Tipo"
            '    .DataType = GetType(String)
            '    .DefaultValue = ""
            'End With
            'dtTraspaso.Columns.Add(dcTipo)
            'dtTraspaso.AcceptChanges()

            ''DataView para asignar el tipo al registro de los faltantes
            'Dim dvDetalleFal As New DataView(dtTraspaso, "Restante > 0", "Codigo", DataViewRowState.CurrentRows)

            'If dvDetalleFal.Count > 0 Then
            '    For Each oRowFal As DataRowView In dvDetalleFal
            '        oRowFal.Item("Tipo") = "FALTANTE"
            '    Next
            '    dtTraspaso.AcceptChanges()
            'End If

            ''DataView para asignar el tipo al registro de los sobrantes
            'Dim dvDetalleSob As New DataView(dtTraspaso, "Restante < 0", "Codigo", DataViewRowState.CurrentRows)
            'If dvDetalleSob.Count > 0 Then
            '    For Each oRowSob As DataRowView In dvDetalleSob
            '        oRowSob.Item("Tipo") = "SOBRANTE"
            '    Next
            '    dtTraspaso.AcceptChanges()
            'End If


            'Dim dvDetalle As New DataView(dtTraspaso, "Restante <> 0", "Tipo, Codigo", DataViewRowState.CurrentRows)

            ''Valido si hubo diferencias
            'If dvDetalle.Count > 0 Then

            '    'Si hubo diferencias las guardo en las tablas locales
            '    oTraspasoEntradaMgr.SaveArtNoLecturados(Me.ebSucOrigenCod.Text, Me.ebSucOrigenDesc.Text, Me.ebSucDestinoCod.Text, _
            '                    Me.ebSucDestinoDesc.Text, Me.ebFolio.Text, Me.ebResponsableDesc.Text, "TE", dvDetalle)


            '    'Se imprime el reporte
            '    If oConfigCierreFI.ValidacionFS = False Then

            '        Try
            '            MsgBox("Prepare su impresora, y ponga hojas", MsgBoxStyle.Information, "Traspaso de Entrada")
            '            Dim oARReporte As New rptArtNoLecturados(Me.GetAlmacen(), "TRASPASO DE ENTRADA", _
            '             Me.ebSucOrigenCod.Text, Me.ebSucOrigenDesc.Text, Me.ebSucDestinoCod.Text, _
            '            Me.ebSucDestinoDesc.Text, Me.ebFolio.Text, Me.ebResponsableDesc.Text)
            '            'Dim oReportViewer As New ReportViewerForm

            '            oARReporte.Document.Name = "Articulos No Lecturados"
            '            oARReporte.DataSource = dvDetalle
            '            oARReporte.Run()

            '            'oReportViewer.Report = oARReporte
            '            'oReportViewer.Show()

            '            Try
            '                oARReporte.Document.Print(False, False)

            '            Catch ex As Exception
            '                MsgBox(ex.ToString & " Error al intentar imprimir")
            '            End Try

            '        Catch ex As ApplicationException

            '            MsgBox(ex.ToString)

            '        End Try

            '    End If

            'End If


            'End If ' este

            Cursor.Current = Cursors.Default

            MsgBox("El Traspaso ha sido Aplicado satisfactoriamente.", MsgBoxStyle.Information, "DPTienda.")

        Else

            Cursor.Current = Cursors.Default
            MsgBox("El Traspaso no pudo ser Aplicado.", MsgBoxStyle.Exclamation, "DPTienda.")

        End If

    End Sub

    Private Sub Sm_AplicarTraspaso()

        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA 18.06.2014: Revisamos si se aplicara un Traspaso de Entrada cargado desde la lectora
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.TraspasoEntradaLectora Then
            If bEsCargaLectora Then
                oConfigCierreFI.RecibirParcialmente = False
            Else 'Si no Recargamos la configuracion para traernos la configuracion correcta
                DesencriptarCML(Application.StartupPath & "\configCierre.cml")
                'CorrigeXML(Application.StartupPath & "\configCierre.cml")
                LoadConfigCierreFI()
                EncriptarCML(Application.StartupPath & "\configCierre.cml")
            End If
        End If
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        If ValidaCamposTraspaso(dtTraspaso) = False Then
            Exit Sub
        End If

        Dim strMSG As String = ""
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Sobrantes
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ValidaSobrantes(dtTraspaso, strMSG)
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Faltantes
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ValidaFaltantes(dtTraspaso, strMSG)
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Mensaje de advertencia
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        If strMSG.Trim <> "" AndAlso oConfigCierreFI.ValidacionFS = False Then
            Dim oForm As New frmTEMSG(strMSG)
            oForm.ShowDialog()
            If oForm.DialogResult = DialogResult.Cancel Then
                Exit Sub
            End If
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Aplicamos traspaso en SAP
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Cursor.Current = Cursors.WaitCursor

        ''----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '' JNAVA (15.04.2016): Obtenemos las tallas de los materiales
        ''----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoEntrada.Detalle = GetTallasTraspaso(oTraspasoEntrada.Detalle)
        ''----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (15.02.2015): Se cambio a funcion nueva donde crea todos los pasos del pedido y traslado, etc
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'If oConfigCierreFI.RecibirParcialmente = False Then
        'ebReferencia.Text = oSapMgr.Write_TrasladoEntradaSAPMM02(oTraspasoEntrada.Folio)
        'Else
        'ebReferencia.Text = oSapMgr.Write_TrasladoEntradaParcialSAPMM02(oTraspasoEntrada.Folio, oTraspasoEntrada.Detalle.Tables(0)) ' dtTraspaso)
        'End If
        Dim strMensaje As String = ""
        Dim mlbnr As String = ""
        ebReferencia.Text = oSapMgr.ZFM_COMMX001_DPRO(oTraspasoEntrada.Folio, dtTraspaso, strMensaje, oConfigCierreFI.RecibirParcialmente, mlbnr)

        If ebReferencia.Text.Trim = "" Then
            MsgBox("Ocurrio un error al Aplicar el Traspaso de Entrada en SAP. " & vbCrLf & vbCrLf & strMensaje, MsgBoxStyle.Exclamation, "DPTienda")
            EscribeLog(strMensaje, "El Traspaso de Entrada No se Aplico en SAP")
            Sm_Nuevo()
            Exit Sub
        End If
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        oTraspasoEntrada.Referencia = Me.ebReferencia.Text.Trim
        Cursor.Current = Cursors.Default
        Dim RowSerie() As DataRow = dtTraspaso.Select("Serie<>''")
        If RowSerie.Length > 0 Then
            Dim response As New Dictionary(Of String, Object)
            response = oSapMgr.ZMMOC03(mlbnr)
            If CBool(response("Success")) Then
                Dim dtZequi As DataTable = CType(response("ZEQUI"), DataTable)
                Dim lstZequi As New List(Of Zequi)
                GuardarZequi(dtZequi, lstZequi)
            End If
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Aqui se hacen los ajustes de entrada en caso de haber sobrantes
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.AjusteAutomatico = False Then
            RealizaAjustesEntrada(dtTraspaso)
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Mando un correo a Manuel Camacho y Karla Guillen con los datos de los sobrantes
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        EnviarCorreoAuditoriaSobrantes(dtTraspaso)
        If oConfigCierreFI.AjusteAutomatico Then
            EnviarCorreoAuditoriaFaltantes(dtTraspaso)
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Aplico el Traspaso de entrada en las bases locales
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoEntrada.TraspasoRecibidoEl = Now.ToShortDateString
        If (oTraspasoEntradaMgr.AplicarEntrada(oTraspasoEntrada, UserSessionAplicated, UserNameAplicated, False, bEsConsignacion) = True) Then

            With oTraspasoEntrada
                ebFechaRecepcion.Text = Format(.TraspasoRecibidoEl, "Short Date")
                ebReferencia.Text = .Referencia
                .Status = "GRA"
                ebStatus.Text = .Status
                ebResponsableDesc.Text = .AutorizadoPorID
            End With
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Guardamos el traspaso en el Servidor si esta activada la config
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.RecibirParcialmente Then
                Try
                    oTraspasoEntradaMgr.AplicarTraspasoEntradaInServer(oTraspasoEntrada, UserSessionAplicated, UserNameAplicated)
                Catch ex As Exception
                    EscribeLog(ex.ToString, "Error al guardar traspaso de entrada en el servidor.")
                End Try
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Guardamos los motivos de captura manual
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Try
                If Not oTraspasoEntrada.dtMotivos Is Nothing Then
                    For Each orow As DataRow In oTraspasoEntrada.dtMotivos.Rows
                        oTraspasoEntradaMgr.SaveMotivo(oTraspasoEntrada.Folio, orow("Tienda"), orow("Articulo"), orow("Talla"), orow("IdMotivo"), "TE")
                    Next
                End If
            Catch ex As Exception
                EscribeLog(ex.ToString, "Error al guardar los motivos de captura manual en Traspaso de Entrada")
            End Try

            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Actualizar existenciase
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ActualizaExistencias(dtTraspaso)

            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Guardar los articulos no lecturados y generar reporte
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            GuardarDiferencias(dtTraspaso)
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            MsgBox("El Traspaso ha sido Aplicado satisfactoriamente.", MsgBoxStyle.Information, "DPTienda.")
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Realizamos el traslado de salida en caso de haber faltantes si esta activada la config
            'Guardamos el traspaso de salida como pendiente de autorizar en caso de haber faltantes
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.RecibirParcialmente Then
                RealizarTraspasoSalida(dtTraspaso, oTraspasoEntrada)
            End If

            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA 18.06.2014: Revisamos si hay Traspasos de Entrada pendientes de cargar desde la lectora
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.TraspasoEntradaLectora Then
                If bEsCargaLectora Then

                    '---------------------------------------------------------------------------------------
                    'JNAVA 18.06.2014: Renombramos y RespaldamosArchivo en la Lectora
                    '---------------------------------------------------------------------------------------
                    RespaldoArchivoLectora(strRutaLayout, oConfigCierreFI.NombreArchivoLectoraTE)

                    '---------------------------------------------------------------------------------------
                    'JNAVA 18.06.2014: Generamos Archivo con Pendientes de ser necesario
                    '---------------------------------------------------------------------------------------
                    If GenerarArchivoNuevo(strRutaLayout, Me.ebFolio.Text) Then
                        If MessageBox.Show("Hay Traspasos de Entrada pendientes de cargar desde la lectora. ¿Desea cargarlos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            Sm_Nuevo()
                            CargaDesdeLectora()
                        Else
                            bEsCargaLectora = False
                        End If
                    Else
                        bEsCargaLectora = False
                    End If
                Else
                    bEsCargaLectora = False
                End If
            End If
          
            If MsgBox("¿Desea imprimir este traspaso?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Imprimir Traspaso de Entrada") = MsgBoxResult.Ok Then
                PrintComprobanteTraspaso()
            End If

            Sm_Nuevo()
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Else

            Cursor.Current = Cursors.Default
            MsgBox("El Traspaso no pudo ser Aplicado.", MsgBoxStyle.Exclamation, "DPTienda.")

        End If

    End Sub

    Private Sub RealizarTraspasoSalidaAnterior(ByVal dtTemp As DataTable, ByVal oTraspasoEntradaTemp As TraspasoEntrada)

        Dim dvFaltantes As New DataView(dtTemp, "Lecturado < Cantidad", "Codigo", DataViewRowState.CurrentRows)
        Dim dtFaltantes As DataTable
        Dim oRowV As DataRowView
        Dim bCambioModelo As Boolean = False

        If dvFaltantes.Count > 0 Then

            bCambioModelo = ValidarPosibleCambioModelo(dtTemp)
PreguntarDeNuevo:
            If MessageBox.Show("Aplicó un traspaso de entrada con faltantes" & vbCrLf & vbCrLf & "¿Desea emitir una carta reclamación a la paqueteria?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Mostrar la pantalla para emitir la carta reclamacion y una vez emitida generar el traspaso de salida al centro Z003 almacen A001
                '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim ofrmReclamacion As New frmReclamacionPaqueteria

                With ofrmReclamacion
                    .strCodSucOrigen = oTraspasoEntradaTemp.AlmacenOrigenID
                    .strFolioTraspaso = oTraspasoEntradaTemp.FolioSAP
                    .strGuia = Me.ebNumGuia.Text.Trim
                    '------------------------------------------------------------------------------------------------------------------------------------------------------------
                    ' JNAVA(15.02.2016): se adecuo por cambios a retail
                    '------------------------------------------------------------------------------------------------------------------------------------------------------------
                    .strNoBultos = Me.ebNumBultosRecibidos.Text.Trim 'Me.ebNumBultos.Text.Trim
                    .strPiezasFaltantes = CStr(SumarPiezasFaltantes(dvFaltantes))
                    .strTransportista = Me.ebTransportistaDesc.Text.Trim
                    .dvFaltantes = dvFaltantes
                    .dtTraspasoSAP = dtTraspasoOriginalSAP.Copy
                End With

                If ofrmReclamacion.ShowDialog = DialogResult.OK Then
                    '----------------------------------------------------------------------------------------------------------------------------
                    'Una vez emitida la carta reclamacion se guarda como pendiente el traspaso de salida al centro Z003 Almacen A001 (Auditoria)
                    'Para autorización del Auditor de Plaza
                    '----------------------------------------------------------------------------------------------------------------------------
                    With oTraspasoEntradaTemp
                        'GenerarTraspasoSalida("Z003", "A001", dvFaltantes, .FolioSAP.Trim, "994", .AutorizadoPorID, .MonedaID, .TransportistaID, True)
                        GuardarTSPendXFaltantes("1003", "1001", dvFaltantes, .FolioSAP.Trim, "994", .AutorizadoPorID, .MonedaID, .TransportistaID, True)
                    End With
                Else
                    GoTo DevolucionOrigen
                End If
            ElseIf MessageBox.Show("¿Estas seguro que no deseas emitir una carta reclamación a la paquetería?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                GoTo PreguntarDeNuevo
            Else
DevolucionOrigen:
                If bCambioModelo = False AndAlso MessageBox.Show("¿Desea devolver los faltantes al centro origen?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Pedir de nuevo la firma del manager o asistente y una vez logueado guardamos como pendiente el traspaso de salida por los
                    'faltantes al centro y almacen origen del traslado
                    '-------------------------------------------------------------------------------------------------------------------------
                    Dim CentroDes As String = ""
                    Dim AlmacenDes As String = ""

                    CentroDes = oSapMgr.Read_Centros(oTraspasoEntradaTemp.AlmacenOrigenID)
                    oAppContext.Security.CloseImpersonatedSession()
                    If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosEntrada") Then
                        oAppContext.Security.CloseImpersonatedSession()
                    Else
                        UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
                        UserNameAplicated = oAppContext.Security.CurrentUser.Name
                        oAppContext.Security.CloseImpersonatedSession()
                        With oTraspasoEntradaTemp
                            'GenerarTraspasoSalida(CentroDes.Trim, "A001", dvFaltantes, .FolioSAP, .AlmacenOrigenID, UserSessionAplicated, .MonedaID, .TransportistaID, False)
                            GuardarTSPendXFaltantes(CentroDes.Trim, "A001", dvFaltantes, .FolioSAP, .AlmacenOrigenID, UserSessionAplicated, _
                                                    .MonedaID, .TransportistaID, False)
                        End With
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub RealizarTraspasoSalida(ByVal dtTemp As DataTable, ByVal oTraspasoEntradaTemp As TraspasoEntrada)

        Dim dvFaltantes As New DataView(dtTemp, "Lecturado < Cantidad", "Codigo", DataViewRowState.CurrentRows)
        Dim dtFaltantes As DataTable
        Dim oRowV As DataRowView
        Dim bCambioModelo As Boolean = False

        If dvFaltantes.Count > 0 Then

            bCambioModelo = ValidarPosibleCambioModelo(dtTemp)

            Dim frmMotivos As frmMotivosFactura
            Dim dtMotivos As New DataTable("Motivos")
            Dim oRow As DataRow
            Dim Tipo As Integer = 0

            dtMotivos.Columns.Add("Descripcion", GetType(String))
            dtMotivos.Columns.Add("IdMotivos", GetType(Integer))
            oRow = dtMotivos.NewRow
            oRow!IdMotivos = 1
            oRow!Descripcion = "Por reclamación a paquetería"
            dtMotivos.Rows.Add(oRow)
            oRow = dtMotivos.NewRow
            oRow!IdMotivos = 2
            oRow!Descripcion = "No llegó del centro origen"
            dtMotivos.Rows.Add(oRow)
            dtMotivos.AcceptChanges()

            frmMotivos = New frmMotivosFactura
            frmMotivos.Tipo = "Faltantes"
            frmMotivos.Motivos = dtMotivos
            MessageBox.Show("Aplicaste un traspaso de entrada con faltantes." & vbCrLf & "Es necesario seleccionar el motivo.", Me.Text, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
PreguntarDeNuevo:
            If frmMotivos.ShowDialog = DialogResult.OK Then
                Tipo = frmMotivos.ebMotivo.Value
                Select Case Tipo
                    Case 1

                        '----------------------------------------------------------------------------------------------------------------------
                        'Mostrar la pantalla para emitir la carta reclamacion y una vez emitida generar el traspaso de salida al centro Z003 
                        'Almacen(A001)
                        '-----------------------------------------------------------------------------------------------------------------------
                        Dim ofrmReclamacion As New frmReclamacionPaqueteria

                        With ofrmReclamacion
                            .strCodSucOrigen = oTraspasoEntradaTemp.AlmacenOrigenID
                            .strFolioTraspaso = oTraspasoEntradaTemp.FolioSAP
                            .strGuia = Me.ebNumGuia.Text.Trim
                            '------------------------------------------------------------------------------------------------------------------------------------------------------------
                            ' JNAVA(15.02.2016): Comentado por adecuaciones a retail
                            '------------------------------------------------------------------------------------------------------------------------------------------------------------
                            .strNoBultos = Me.ebNumBultosRecibidos.Text.Trim 'Me.ebNumBultos.Text.Trim
                            .strPiezasFaltantes = CStr(SumarPiezasFaltantes(dvFaltantes))
                            .strTransportista = Me.ebTransportistaDesc.Text.Trim
                            .dvFaltantes = dvFaltantes
                            .dtTraspasoSAP = dtTraspasoOriginalSAP.Copy
                        End With

                        If ofrmReclamacion.ShowDialog = DialogResult.OK Then
                            '----------------------------------------------------------------------------------------------------------------------------
                            'Una vez emitida la carta reclamacion se guarda como pendiente el traspaso de salida al centro Z003 Almacen A001 (Auditoria)
                            'Para autorización del Auditor de Plaza
                            '----------------------------------------------------------------------------------------------------------------------------
                            With oTraspasoEntradaTemp
                                'GenerarTraspasoSalida("Z003", "A001", dvFaltantes, .FolioSAP.Trim, "994", .AutorizadoPorID, .MonedaID, .TransportistaID, True)
                                GuardarTSPendXFaltantes("1003", "1001", dvFaltantes, .FolioSAP.Trim, "994", .AutorizadoPorID, .MonedaID, .TransportistaID, True)
                            End With
                        Else
                            GoTo PreguntarDeNuevo
                        End If

                    Case 2

                        If bCambioModelo = False Then
                            '--------------------------------------------------------------------------------------------------------------------
                            'Pedir de nuevo la firma del manager o asistente y una vez logueado guardamos como pendiente el traspaso de salida 
                            'por los faltantes al centro y almacen origen del traslado
                            '--------------------------------------------------------------------------------------------------------------------
                            Dim CentroDes As String = ""
                            Dim AlmacenDes As String = ""

                            CentroDes = oSapMgr.Read_Centros(oTraspasoEntradaTemp.AlmacenOrigenID)
                            'oAppContext.Security.CloseImpersonatedSession()
                            'If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosEntrada") Then
                            '    oAppContext.Security.CloseImpersonatedSession()
                            'Else
                            UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
                            UserNameAplicated = oAppContext.Security.CurrentUser.Name
                            'oAppContext.Security.CloseImpersonatedSession()
                            With oTraspasoEntradaTemp
                                'GenerarTraspasoSalida(CentroDes.Trim, "A001", dvFaltantes, .FolioSAP, .AlmacenOrigenID, UserSessionAplicated, .MonedaID, .TransportistaID, False)
                                GuardarTSPendXFaltantes(CentroDes.Trim, "A001", dvFaltantes, .FolioSAP, .AlmacenOrigenID, UserSessionAplicated, _
                                                        .MonedaID, .TransportistaID, False)
                            End With
                            'End If
                        End If

                End Select
            Else
                GoTo PreguntarDeNuevo
            End If

        End If

    End Sub

    Private Function SumarPiezasFaltantes(ByVal dvFal As DataView) As Integer

        Dim oRow As DataRowView
        Dim Total As Integer = 0

        For Each oRow In dvFal
            Total += CInt(oRow!Cantidad - oRow!Lecturado)
        Next

        Return Total

    End Function

    Private Function ValidarPosibleCambioModelo(ByVal dtTemp As DataTable) As Boolean

        Dim dvAgregados As New DataView(dtTemp, "Agregado > 0", "", DataViewRowState.CurrentRows)
        Dim bRes As Boolean = False

        '------------------------------------------------------------------------------------------------------------------------------------------------
        'Si hay faltantes y hay codigos agregados que no estan en el traspaso de entrada en SAP es posible un cambio de modelo
        '------------------------------------------------------------------------------------------------------------------------------------------------
        If dvAgregados.Count > 0 Then
            bRes = True
        End If

        Return bRes

    End Function

    Private Sub GenerarTraspasoSalida(ByVal Centro As String, ByVal Almacen As String, ByVal dvFaltantes As DataView, ByVal FolioTESAP As String, ByVal strCodAlmacenDes As String, _
                                  ByVal strResponsableID As String, ByVal strMonedaID As String, ByVal strTransportistaID As String, ByVal bPaqueteria As Boolean)

        Dim oTraspasoSalida As TraspasoSalida
        Dim dsTraspasoCorrida As New DataSet
        Dim dtDetalleSAP As DataTable
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Creamos el detalle del traspaso de salida para la base local
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        dsTraspasoCorrida = CrearDetalleTraspasoSalida(dvFaltantes)
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Creamos el detalle del traspaso de salida para SAP
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        dtDetalleSAP = oTraspasoSMgr.FillTablaParaSAP
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Generamos el pedido de Traslado en SAP
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim FolioPedidoTraspasoSAP As String = ""
        Dim strObservaciones As String = ""

        FolioPedidoTraspasoSAP = oSapMgr.pedido_trasladomm02(dtDetalleSAP, Centro.Trim, Almacen.Trim)

        If FolioPedidoTraspasoSAP.Trim = "" Then
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'No se grabo en sap
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            EscribeLog("Error al realizar el pedido de traspaso en sap por los faltantes del traspaso de entrada " & FolioTESAP.Trim, "Error al realizar pedido de traslado")
            MsgBox("No se Realizo el PEDIDO DE TRAPASO en SAP", MsgBoxStyle.Exclamation, "Error SAP")
            Exit Sub
        Else
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Aplicamos movimiento 351 en SAP
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim strNumTras As String = ""

            If bPaqueteria Then
                strObservaciones = "TO: " & FolioTESAP.Trim & " R Paqueteria"
            Else
                strObservaciones = "TO: " & FolioTESAP.Trim & ", Faltantes"
            End If
            strNumTras = oSapMgr.trasladomm02(FolioPedidoTraspasoSAP.Trim, strObservaciones.Trim, strCodAlmacenDes.Trim)

            If strNumTras = "" Then
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'no se grabo en sap
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
                EscribeLog("No se realizo el movimiento 351 en SAP del traslado de salida " & FolioPedidoTraspasoSAP.Trim, "Error al aplicar 351 a traspaso de salida")
                MsgBox("No se Realizo el TRASPASO en SAP", MsgBoxStyle.Exclamation, "Error SAP")
                Exit Sub
            End If
            If bPaqueteria Then
                strObservaciones = "Traslado generado por faltantes, reclamación paqueteria, folio origen: " & FolioTESAP.Trim
            Else
                strObservaciones = "Traslado generado por faltantes en traspaso de entrada con folio: " & FolioTESAP.Trim
            End If
        End If
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'GUIA BULTOS PAQUETERIA
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Guia       F01
        'Bultos     F02
        'Paqueteria F03
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '-----------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (17.02.2016): se comenta por que ya no se usara pues la BAPI de ZBAPIMM02_PEDIDOTRAS incluye la funcionalidad
        '-----------------------------------------------------------------------------------------------------------------------------------
        'oSapMgr.SaveInfoPaqueteria(FolioPedidoTraspasoSAP.Trim, Me.ebNumBultos.Text.Trim, "F02")
        'oSapMgr.SaveInfoPaqueteria(FolioPedidoTraspasoSAP.Trim, Me.ebNumGuia.Text, "F01")
        'oSapMgr.SaveInfoPaqueteria(FolioPedidoTraspasoSAP.Trim, Me.ebNumBultosRecibidos.Text.Trim, "F02")
        'oSapMgr.SaveInfoPaqueteria(FolioPedidoTraspasoSAP.Trim, Me.ebTransportistaDesc.Text, "F03")
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Guardar traspaso de salida en la base local
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoSalida = Nothing
        oTraspasoSalida = oTraspasoSMgr.Create

        oTraspasoSalida.Observaciones = strObservaciones.Trim

        oTraspasoSalida.TraspasoRecibidoEl = Date.Now.Date
        oTraspasoSalida.Guia = ebNumGuia.Text.Trim
        '------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA(15.02.2016): se cambio por adecuaciones a retail
        '------------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoSalida.TotalBultos = ebNumBultosRecibidos.Text.Trim 'ebNumBultos.Text.Trim
        oTraspasoSalida.AutorizadoPorID = strResponsableID
        oTraspasoSalida.Cargos = 0
        oTraspasoSalida.SubTotal = 0
        oTraspasoSalida.MonedaID = strMonedaID.Trim
        oTraspasoSalida.TraspasoCreadoEl = Date.Now.Date
        oTraspasoSalida.TransportistaID = strTransportistaID.Trim
        oTraspasoSalida.Status = "GRA"
        oTraspasoSalida.AlmacenDestinoID = strCodAlmacenDes.Trim
        oTraspasoSalida.AlmacenOrigenID = oAppContext.ApplicationConfiguration.Almacen
        oTraspasoSalida.Referencia = ""
        oTraspasoSalida.TraspasoID = 0
        oTraspasoSalida.Folio = ""
        oTraspasoSalida.FolioSAP = FolioPedidoTraspasoSAP.Trim
        oTraspasoSalida.TEOrigen = Me.ebFolio.Text.Trim

        oTraspasoSalida.Detalle = dsTraspasoCorrida

        oTraspasoSalida.Save()
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Guardamos el traspaso de salida en el servidor
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Try
            oTraspasoSMgr.SaveInServer(oTraspasoSalida, dtDetalleSAP)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al guardar el traspaso de salida " & oTraspasoSalida.TraspasoID & " en el server.")
        End Try
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Actualizamos la informacion en la base local y afectamos el inventario
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Sm_AplicarTraspasoSalida(oTraspasoSalida)
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Imprimir Traspaso
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoSalida.Detalle.Tables(0).TableName = "TraspasoCorrida"
        PrintComprobanteTraspasoSalida(oTraspasoSalida)
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoSalida = Nothing

        MsgBox("El Traspaso de Salida ha sido Aplicado satisfactoriamente.", MsgBoxStyle.Information, "DPTienda.")

    End Sub

    Private Sub GuardarTSPendXFaltantes(ByVal Centro As String, ByVal Almacen As String, ByVal dvFaltantes As DataView, ByVal FolioTESAP As String, ByVal strCodAlmacenDes As String, _
                                  ByVal strResponsableID As String, ByVal strMonedaID As String, ByVal strTransportistaID As String, ByVal bPaqueteria As Boolean)

        Dim oTraspasoSalida As TraspasoSalida
        'Dim dsTraspasoCorrida As New DataSet
        'Dim dtDetalleSAP As DataTable
        Dim dtDetalleTSPend As DataTable
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Creamos el detalle del traspaso de salida para la base local
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        dtDetalleTSPend = CrearDetalleTSPendiente(dvFaltantes)
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Creamos el detalle del traspaso de salida para SAP
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'dtDetalleSAP = oTraspasoSMgr.FillTablaParaSAP
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Generamos el pedido de Traslado en SAP
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Dim FolioPedidoTraspasoSAP As String = ""
        Dim strObservaciones As String = ""

        ' FolioPedidoTraspasoSAP = oSap.pedido_trasladomm02(dtDetalleSAP, Centro.Trim, Almacen.Trim)

        'If FolioPedidoTraspasoSAP.Trim = "" Then
        '    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '    'No se grabo en sap
        '    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '    EscribeLog("Error al realizar el pedido de traspaso en sap por los faltantes del traspaso de entrada " & FolioTESAP.Trim, "Error al realizar pedido de traslado")
        '    MsgBox("No se Realizo el PEDIDO DE TRAPASO en SAP", MsgBoxStyle.Exclamation, "Error SAP")
        '    Exit Sub
        'Else
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Aplicamos movimiento 351 en SAP
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Dim strNumTras As String = ""

        'If bPaqueteria Then
        '    strObservaciones = "TO: " & FolioTESAP.Trim & " R Paqueteria"
        'Else
        '    strObservaciones = "TO: " & FolioTESAP.Trim & ", Faltantes"
        'End If
        'strNumTras = oSap.trasladomm02(FolioPedidoTraspasoSAP.Trim, strObservaciones.Trim, strCodAlmacenDes.Trim)

        'If strNumTras = "" Then
        '    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '    'no se grabo en sap
        '    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '    EscribeLog("No se realizo el movimiento 351 en SAP del traslado de salida " & FolioPedidoTraspasoSAP.Trim, "Error al aplicar 351 a traspaso de salida")
        '    MsgBox("No se Realizo el TRASPASO en SAP", MsgBoxStyle.Exclamation, "Error SAP")
        '    Exit Sub
        'End If
        If bPaqueteria Then
            strObservaciones = "Traslado generado por faltantes, reclamación paqueteria, folio origen: " & FolioTESAP.Trim
        Else
            strObservaciones = "Traslado generado por faltantes en traspaso de entrada con folio: " & FolioTESAP.Trim
        End If
        'End If
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'GUIA BULTOS PAQUETERIA
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Guia       F01
        'Bultos     F02
        'Paqueteria F03
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'oSap.SaveInfoPaqueteria(FolioPedidoTraspasoSAP.Trim, Me.ebNumGuia.Text, "F01")
        'oSap.SaveInfoPaqueteria(FolioPedidoTraspasoSAP.Trim, Me.ebNumBultos.Text.Trim, "F02")
        'oSap.SaveInfoPaqueteria(FolioPedidoTraspasoSAP.Trim, Me.ebTransportistaDesc.Text, "F03")
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Guardar traspaso de salida en la base local
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoSalida = Nothing
        oTraspasoSalida = oTraspasoSMgr.Create

        oTraspasoSalida.Observaciones = IIf(bPaqueteria, "1", "0") 'strObservaciones.Trim

        oTraspasoSalida.TraspasoRecibidoEl = Date.Now.Date
        oTraspasoSalida.Guia = ebNumGuia.Text.Trim
        '------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA(15.02.2016): se cambio por adecuaciones a retail
        '------------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoSalida.TotalBultos = ebNumBultosRecibidos.Text.Trim 'ebNumBultos.Text.Trim
        oTraspasoSalida.AutorizadoPorID = strResponsableID
        oTraspasoSalida.Cargos = 0
        oTraspasoSalida.SubTotal = 0
        oTraspasoSalida.MonedaID = strMonedaID.Trim
        oTraspasoSalida.TraspasoCreadoEl = Date.Now.Date
        oTraspasoSalida.TransportistaID = strTransportistaID.Trim
        oTraspasoSalida.Status = "GRA"
        oTraspasoSalida.AlmacenDestinoID = strCodAlmacenDes.Trim
        oTraspasoSalida.AlmacenOrigenID = oAppContext.ApplicationConfiguration.Almacen
        oTraspasoSalida.Referencia = ""
        oTraspasoSalida.TraspasoID = 0
        oTraspasoSalida.Folio = ""
        oTraspasoSalida.FolioSAP = "" 'FolioPedidoTraspasoSAP.Trim
        oTraspasoSalida.TEOrigen = Me.ebFolio.Text.Trim

        oTraspasoSMgr.SaveTraspasoPendiente(oTraspasoSalida, dtDetalleTSPend)

        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Mando un correo a los correos configurados de auditoria para avisar que hay un traspaso pendiente por autorizar
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        EnviarCorreoAuditoriaFaltantes(dtDetalleTSPend, Centro, bPaqueteria)

        'oTraspasoSalida.Detalle = dsTraspasoCorrida

        'oTraspasoSalida.Save()
        '---------------------------------------------------------------------------------------------------------------------------------
        'Marcamos todos los faltantes como de baja calidad para que Ecommerce no los vea en el inventario de la tienda
        '---------------------------------------------------------------------------------------------------------------------------------
        MarcarBajaCalidadEC(dtDetalleTSPend)
        'Try
        '    oTraspasoSMgr.SaveInServer(oTraspasoSalida, dtDetalleSAP)
        'Catch ex As Exception
        '    EscribeLog(ex.ToString, "Error al guardar el traspaso de salida " & oTraspasoSalida.TraspasoID & " en el server.")
        'End Try
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Actualizamos la informacion en la base local y afectamos el inventario
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Sm_AplicarTraspasoSalida(oTraspasoSalida)
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Imprimir Traspaso
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'oTraspasoSalida.Detalle.Tables(0).TableName = "TraspasoCorrida"
        'PrintComprobanteTraspasoSalida(oTraspasoSalida)
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoSalida = Nothing

        MsgBox("El Traspaso de Salida se ha guardado como pendiente para ser autorizado por el auditor de plaza.", MsgBoxStyle.Information, "DPTienda")

    End Sub

    Private Sub MarcarBajaCalidadEC(ByVal dtSource As DataTable)

        Dim oCol As DataColumn
        Dim dtFaltantes As DataTable = dtSource.Copy

        UserNameAplicated = oAppContext.Security.CurrentUser.Name
        '---------------------------------------------------------------------------------------------------------------------
        'Le cambiamos el nombre a la columna del material
        '---------------------------------------------------------------------------------------------------------------------
        dtFaltantes.Columns("Codigo").ColumnName = "Material"
        '---------------------------------------------------------------------------------------------------------------------
        'Agregamos la columna con el ID del desmarcado
        '---------------------------------------------------------------------------------------------------------------------
        oCol = New DataColumn
        oCol.ColumnName = "DesmarcadoID"
        oCol.DataType = GetType(String)
        oCol.DefaultValue = ""
        dtFaltantes.Columns.Add(oCol)
        '---------------------------------------------------------------------------------------------------------------------
        'Obtenemos el motivo de marcado de SAP
        '---------------------------------------------------------------------------------------------------------------------
        Dim dtMotivoMar As DataTable
        Dim MotivoMarcado As String = ""
        Dim MarcadoID As String = ""
        dtMotivoMar = oSapMgr.ZPOL_GET_MOTIVOS("FT")
        If dtMotivoMar.Rows.Count > 0 Then
            MotivoMarcado = dtMotivoMar.Rows(0)!Motivo
            MarcadoID = dtMotivoMar.Rows(0)!ID
        End If
        '---------------------------------------------------------------------------------------------------------------------
        'Agregamos la columna con el ID del marcado
        '---------------------------------------------------------------------------------------------------------------------
        oCol = New DataColumn
        oCol.ColumnName = "MarcadoID"
        oCol.DataType = GetType(String)
        oCol.DefaultValue = MarcadoID
        dtFaltantes.Columns.Add(oCol)
        dtFaltantes.AcceptChanges()
        '---------------------------------------------------------------------------------------------------------------------
        'Agregamos la columna con el motivo del marcado
        '---------------------------------------------------------------------------------------------------------------------
        oCol = New DataColumn
        oCol.ColumnName = "Motivo"
        oCol.DataType = GetType(String)
        oCol.DefaultValue = MotivoMarcado.Trim
        dtFaltantes.Columns.Add(oCol)
        '---------------------------------------------------------------------------------------------------------------------
        'Grabamos el marcado como de baja calidad en SAP
        '---------------------------------------------------------------------------------------------------------------------
        oSapMgr.ZPOL_DEFECTUOSOS_INS(Me.ebFolio.Text, "MD", UserNameAplicated, dtFaltantes)

    End Sub

    Public Function CrearDetalleTraspasoSalida(ByVal dvFaltantes As DataView) As DataSet

        Dim oRow As DataRowView
        Dim oArticuloTemp As Articulo
        Dim cant As Integer = 0
        Dim dsTraspasoSalidaDetalle As DataSet

        oTraspasoSMgr.CrearTablaTmp()

        For Each oRow In dvFaltantes
            oArticuloTemp = Nothing
            cant = 0
            oArticuloTemp = oArticulosMgr.Load(CStr(oRow!Codigo))
            If Not oArticuloTemp Is Nothing Then
                cant = CInt(oRow!Cantidad - oRow!Lecturado)
                oTraspasoSMgr.AgregarArticulo(oArticuloTemp, oRow!Talla, cant, oArticuloTemp.CostoProm * cant, 0)
            End If
        Next

        dsTraspasoSalidaDetalle = Nothing
        dsTraspasoSalidaDetalle = oTraspasoSMgr.GenerarTraspasoCorrida("[RefCruzTraspaso]")

        oArticuloTemp = Nothing

        Return dsTraspasoSalidaDetalle

    End Function

    Public Function CrearDetalleTSPendiente(ByVal dvFaltantes As DataView) As DataTable

        Dim oRow As DataRow
        Dim oArticuloTemp As Articulo
        Dim cant As Integer = 0
        Dim dtTemp As DataTable = dvFaltantes.Table.Clone
        Dim oRowV As DataRowView

        'Dim dsTraspasoSalidaDetalle As DataSet

        'oTraspasoSMgr.CrearTablaTmp()
        For Each oRowV In dvFaltantes
            dtTemp.ImportRow(oRowV.Row)
        Next

        dtTemp.Columns.Add("Costo", GetType(Decimal))
        dtTemp.AcceptChanges()

        For Each oRow In dtTemp.Rows
            oArticuloTemp = Nothing
            cant = 0
            oArticuloTemp = oArticulosMgr.Load(CStr(oRow!Codigo))
            If Not oArticuloTemp Is Nothing Then
                cant = CInt(oRow!Cantidad - oRow!Lecturado)
                'oTraspasoSMgr.AgregarArticulo(oArticuloTemp, oRow!Talla, cant, oArticuloTemp.CostoProm * cant, 0)
                oRow!Cantidad = cant
                oRow!Costo = oArticuloTemp.CostoProm * cant
            End If
        Next

        'dsTraspasoSalidaDetalle = Nothing
        'dsTraspasoSalidaDetalle = oTraspasoSMgr.GenerarTraspasoCorrida("[RefCruzTraspaso]")

        oArticuloTemp = Nothing

        'Return dsTraspasoSalidaDetalle
        Return dtTemp

    End Function

    Public Sub PrintComprobanteTraspasoSalida(ByVal oTraspasoSalidaTemp As TraspasoSalida)

        If Not oTraspasoSalidaTemp Is Nothing Then

            Dim oARReporte As New rptReporteTraspasoDeSalida(oTraspasoSalidaTemp, "Entradas")
            'Dim oReportViewer As New ReportViewerForm

            oARReporte.Document.Name = "Reporte de Traspaso de Salida"

            oARReporte.Run()

            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

            Try
                oARReporte.Document.Print(False, False)
            Catch ex As Exception
                EscribeLog(ex.ToString, "Error al imprimir el traspaso de salida con folio: " & oTraspasoSalidaTemp.TraspasoID)
            End Try

        End If

    End Sub

    Private Sub Sm_AplicarTraspasoSalida(ByVal oTraspasoSalidaTemp As TraspasoSalida)
        '------------------------------------------------------------------------------------------------------------------------------------
        'Validación
        '------------------------------------------------------------------------------------------------------------------------------------
        If (oTraspasoSalidaTemp Is Nothing) Then
            EscribeLog("No hay un traspaso de salida selecciona oTraspasoSalidaTemp Is Nothing", "Error al aplicar traspaso de salida")
            MsgBox("No ha sido seleccionado un Traspaso", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        ElseIf oTraspasoSalidaTemp.Status.Trim.ToUpper <> "GRA" Then
            EscribeLog("El traspaso ya habia sido aplicado anteriormente. Status <> GRA", "Error al aplicar traspaso de salida " & oTraspasoSalidaTemp.TraspasoID)
            MsgBox("El Traspaso ya fue Aplicado.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If
        '------------------------------------------------------------------------------------------------------------------------------------
        'Actualizar Traspaso [General].
        '------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoSalidaTemp.TraspasoRecibidoEl = "01/01/1900"
        oTraspasoSalidaTemp.Status = "TRA"

        If (oTraspasoSMgr.AplicarEntrada(oTraspasoSalidaTemp) = True) Then

            'oTraspasoSalidaTemp = Nothing

            'MsgBox("El Traspaso ha sido Aplicado satisfactoriamente.", MsgBoxStyle.Information, "DPTienda.")
        Else
            EscribeLog("No se pudo aplicar el traspaso de salida con folio: " & oTraspasoSalidaTemp.TraspasoID, "Error al aplicar traspaso salida automatico")
            MsgBox("El Traspaso de Salida no se Aplicó.", MsgBoxStyle.Exclamation, "DPTienda.")
        End If

    End Sub

    Public Sub PrintComprobanteTraspaso()
        Dim iTraspEntrada As RepAjustesESEng.cTraspasoEntrada
        Dim iRepEntrada As rptReporteTraspasoDeEntrada
        Dim pdtDetalles As DataTable

        iTraspEntrada = New RepAjustesESEng.cTraspasoEntrada
        iRepEntrada = New rptReporteTraspasoDeEntrada
        pdtDetalles = New DataTable

        iTraspEntrada.CreaDetalle(pdtDetalles, 12)
        iTraspEntrada.ObtDetalle(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString(), ebFolio.Text, oAppContext.ApplicationConfiguration.Almacen, pdtDetalles, 12)
        'iRepEntrada.DataSource = pdtDetalles

        iRepEntrada.DataSource = FormatDataSet(oTraspasoEntrada.Detalle).Tables("ReporteInventario")
        'iRepEntrada.Folio = ebReferencia.Text
        iRepEntrada.Folio = Me.ebFolio.Text
        iRepEntrada.Fecha = CDate(ebFecha.Text)
        iRepEntrada.Origen = ebSucOrigenCod.Text
        iRepEntrada.Destino = ebSucDestinoCod.Text
        'iRepEntrada.ValorDeclarado = "$$" & ebTotal.Text
        iRepEntrada.Guia = ebNumGuia.Text
        iRepEntrada.Observaciones = oTraspasoEntrada.Observaciones
        iRepEntrada.Document.Name = "Traspaso de Entrada"
        iRepEntrada.Run()

        Try
            iRepEntrada.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Function AdjuntarArchivosXFaltantes() As String

        Dim strRutas As String = ""
        Dim Ruta As String = "C:\CartasReclamacion\"
        'Dim strFile As String = ""
        Dim Archivos() As String

        'strFile = Ruta & Me.ebFolio.Text.Trim & ".pdf"
        'If File.Exists(strFile) Then strRutas = strFile

        Ruta = "C:\CartasReclamacion\" & Format(Today, "ddMMyyyy")

        If Directory.Exists(Ruta) Then
            Archivos = Directory.GetFiles(Ruta)

            Dim strF As String = ""

            For Each strF In Archivos
                If Not strF Is Nothing AndAlso strF.Trim <> "" Then
                    If InStr(strF.Trim.ToUpper, Me.ebFolio.Text.Trim.ToUpper) > 0 Then
                        If strRutas.Trim <> "" Then strRutas &= "|"
                        strRutas &= strF.Trim
                    End If
                End If
            Next
        End If

        Return strRutas

    End Function

    Public Function ExportaTraspasoPDF() As String
        Dim iTraspEntrada As RepAjustesESEng.cTraspasoEntrada
        Dim iRepEntrada As rptReporteTraspasoDeEntrada
        Dim pdtDetalles As DataTable
        Dim oPDF As PdfExport
        Dim Ruta As String = "C:\CartasReclamacion\"

        iTraspEntrada = New RepAjustesESEng.cTraspasoEntrada
        iRepEntrada = New rptReporteTraspasoDeEntrada
        pdtDetalles = New DataTable

        iTraspEntrada.CreaDetalle(pdtDetalles, 12)
        iTraspEntrada.ObtDetalle(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString(), ebFolio.Text, oAppContext.ApplicationConfiguration.Almacen, pdtDetalles, 12)
        'iRepEntrada.DataSource = pdtDetalles

        iRepEntrada.DataSource = FormatDataSet(oTraspasoEntrada.Detalle).Tables("ReporteInventario")
        'iRepEntrada.Folio = ebReferencia.Text
        iRepEntrada.Folio = Me.ebFolio.Text
        iRepEntrada.Fecha = CDate(ebFecha.Text)
        iRepEntrada.Origen = ebSucOrigenCod.Text
        iRepEntrada.Destino = ebSucDestinoCod.Text
        'iRepEntrada.ValorDeclarado = "$$" & ebTotal.Text
        iRepEntrada.Guia = ebNumGuia.Text
        iRepEntrada.Observaciones = oTraspasoEntrada.Observaciones
        iRepEntrada.Document.Name = "Traspaso de Entrada"
        iRepEntrada.Run()

        Try
            'iRepEntrada.Document.Print(False, False)
            If Directory.Exists(Ruta) = False Then
                Directory.CreateDirectory(Ruta)
            End If
            oPDF = New PdfExport
            oPDF.Export(iRepEntrada.Document, Ruta & Me.ebFolio.Text.Trim & ".pdf")
        Catch ex As Exception
            'MsgBox(ex.ToString)
            EscribeLog(ex.ToString, "Error al exportar traspaso de entreda: " & Me.ebFolio.Text & " a PDF. Linea" & Err.Erl)
        End Try

        Return Ruta & Me.ebFolio.Text.Trim & ".pdf"

    End Function

    Public Function FormatDataSet(ByVal Source As DataSet) As DataSet
        Try
            Dim dsTarget As New DataSet("ReporteInventario")
            Dim dtMainTable As New DataTable("ReporteInventario")

            'Columna: Codigo
            Dim dcCodigo As DataColumn = New DataColumn
            With dcCodigo
                .DataType = System.Type.GetType("System.String")
                .Caption = "Codigo"
                .ColumnName = "Codigo"
            End With
            dtMainTable.Columns.Add(dcCodigo)

            'Columna: Descripcion
            Dim dcDescripcion As DataColumn = New DataColumn
            With dcDescripcion
                .DataType = System.Type.GetType("System.String")
                .Caption = "Descripcion"
                .ColumnName = "Descripcion"

            End With
            dtMainTable.Columns.Add(dcDescripcion)

            'Columna: Total Artículos
            Dim dcTotalA As DataColumn = New DataColumn
            With dcTotalA
                .DataType = System.Type.GetType("System.Int32")
                .Caption = "Total Artículos"
                .ColumnName = "TotalA"

            End With
            dtMainTable.Columns.Add(dcTotalA)

            'Columna: Tallas
            Dim dcTalla As DataColumn
            Dim intTalla As Integer
            For intTalla = 1 To 20
                dcTalla = New DataColumn
                With dcTalla
                    .DataType = System.Type.GetType("System.String")
                    .Caption = "T" & intTalla.ToString("00")
                    .ColumnName = "T" & intTalla.ToString("00")
                End With
                dtMainTable.Columns.Add(dcTalla)

            Next

            'Columna: Totales
            Dim dcTotal As DataColumn
            Dim intTotal As Integer
            For intTotal = 1 To 20
                dcTotal = New DataColumn
                With dcTotal
                    .DataType = System.Type.GetType("System.Int32")
                    .Caption = "C" & intTotal.ToString("00")
                    .ColumnName = "C" & intTotal.ToString("00")
                End With
                dtMainTable.Columns.Add(dcTotal)
            Next

            'Para que se agreguen todos los campos a la Tabla
            dsTarget.Tables.Add(dtMainTable)

            '<TraspasarInformacion>

            Dim oSourceRow As DataRow
            Dim oTargetSource As DataRow

            Dim strCodigo As String
            Dim intColTalla As Integer
            Dim TotalArt As Decimal
            Dim TotalResult As Decimal
            Dim TotalResultArt As Decimal
            Dim TotalMonto As Decimal

            For Each oSourceRow In Source.Tables(0).Rows

                If (strCodigo <> oSourceRow.Item(0).ToString) Then

                    If (Not oTargetSource Is Nothing) Then

                        dtMainTable.Rows.Add(oTargetSource)
                        oTargetSource("TotalA") = TotalResult
                        TotalResult = 0

                    End If

                    strCodigo = oSourceRow.Item(1).ToString
                    oTargetSource = dtMainTable.NewRow()

                    oTargetSource("Codigo") = UCase(strCodigo)
                    oTargetSource("Descripcion") = oSourceRow.Item(2).ToString
                    oTargetSource("Descripcion") = UCase(CStr(oSourceRow("Descripcion")))
                    intColTalla = 1

                End If

                oTargetSource("T" & intColTalla.ToString("00")) = oSourceRow("Talla")
                oTargetSource("C" & intColTalla.ToString("00")) = oSourceRow("Cantidad")



                intColTalla += 1
                TotalArt = CType(oSourceRow("Cantidad"), Integer)
                TotalResult += TotalArt
                TotalResultArt += TotalArt

            Next
            oTargetSource("TotalA") = TotalResult
            dtMainTable.Rows.Add(oTargetSource)

            'oTargetSource = dtMainTable.NewRow()
            'oTargetSource("TotalA") = TotalResultArt
            'oTargetSource("Codigo") = "TOTAL DE PARES"
            'dtMainTable.Rows.Add(oTargetSource)

            dtMainTable.AcceptChanges()

            '</TraspasarInformacion>

            Return dsTarget
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "Metodos y funciones para la Carga desde Lectora"

    '---------------------------------------------------------------------------------------
    'JNAVA 16.06.2014: Metodo Principal para la Carga desde la Lectora
    '---------------------------------------------------------------------------------------
    Private Sub CargaDesdeLectora()

        strRutaLayout = ""

        If Not dtTraspaso Is Nothing AndAlso dtTraspaso.Rows.Count > 0 AndAlso Me.ebStatus.Text.Trim.ToUpper <> "GRA" Then
            If MessageBox.Show("¿Estas seguro que deseas continuar con la Carga sin aplicar el Traspaso actual?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Cursor.Current = Cursors.WaitCursor

        Sm_Nuevo()

        If BuscaLectora(strRutaLayout, oConfigCierreFI.NombreLectoraTE, oConfigCierreFI.NombreArchivoLectoraTE) Then
            If strRutaLayout.Trim <> "" Then

                'Cargamos archivo donde se encuentran los datos del o los traspasos a cargar
                If CargaArchivoLayout(strRutaLayout) Then
                    Dim strTraspasoCarga As String = ""
                    Dim dtTraspasoSelDetalle As DataTable
                    Dim hCodigosInorados As New Hashtable

                    '---------------------------------------------------------------------------------------
                    'JNAVA 17.06.2014: Validamos los datos del traspaso cargado
                    '---------------------------------------------------------------------------------------
                    strTraspasoCarga = BuscarTraspasosCargados()

                    '---------------------------------------------------------------------------------------
                    'JNAVA 17.06.2014: Si se cancelo la carga, ya no continua
                    '---------------------------------------------------------------------------------------
                    If strTraspasoCarga.Trim = "" Then
                        'MessageBox.Show("No se cargo ningún Traspaso de Entrada desde la Lectora.", "Carga desde Lectora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        GoTo Terminar
                    End If

                    '---------------------------------------------------------------------------------------
                    'JNAVA 18.06.2014: Obtenemos datos del traspaso seleccionado y organizamos
                    '---------------------------------------------------------------------------------------
                    dtTraspasoSelDetalle = PrepararCodigosTraspaso(strTraspasoCarga)

                    If dtTraspasoSelDetalle.Rows.Count <= 0 Then
                        MessageBox.Show("No se lecturarón Códigos para el Traspaso seleccionado ó los Códigos son incorrectos." & vbCrLf & "Favor de verificar.", "Carga desde Lectora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        GoTo Terminar
                    End If

                    '---------------------------------------------------------------------------------------
                    'JNAVA 19.06.2014: Validamos los datos de traspaso seleccionado para cargarlo y
                    '                  comparamos con SAP
                    '---------------------------------------------------------------------------------------
                    ValidaTraspasoCargado(strTraspasoCarga, dtTraspasoSelDetalle)

                    '---------------------------------------------------------------------------------------
                    'JNAVA 20.06.2014: Mostramos los Codigos UPC cargados que no fueron validos
                    '---------------------------------------------------------------------------------------
                    MostrarCodigosIgnorados(dtTraspasoSelDetalle)

                    '---------------------------------------------------------------------------------------
                    'JNAVA 18.06.2014: Cambiamos Variable Global para decir que se cargo desde la Lectora
                    '---------------------------------------------------------------------------------------
                    bEsCargaLectora = True

                    'MessageBox.Show("El Traspaso selecionado se cargo correctamente.", "Carga desde Lectora", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            Else
                MessageBox.Show("No se encontro el archivo de carga en la lectora. Favor de verificar.", "Carga desde Lectora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se encontro la Lectora o no ha sido conectada. Favor de verificar.", "Carga desde Lectora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

Terminar:

        Cursor.Current = Cursors.Default

    End Sub

    '---------------------------------------------------------------------------------------
    'JNAVA 16.06.2014: Función que verifica si esta disponible la Lectora
    '---------------------------------------------------------------------------------------
    Private Function BuscaLectora(ByRef RutaLayout As String, ByVal NombreLectora As String, ByVal NombreArchivo As String) As Boolean
        Dim bResult As Boolean = False
        Dim fso As New Scripting.FileSystemObject

        Dim NombreUnidad As String = ""
        Dim LetraUnidad As String = ""

        Try
            For Each unidad As Scripting.Drive In fso.Drives
                If unidad.DriveType = 3 Then
                    NombreUnidad = unidad.ShareName()
                ElseIf unidad.IsReady Then
                    NombreUnidad = unidad.VolumeName
                End If
                If NombreUnidad = NombreLectora Then
                    LetraUnidad = unidad.DriveLetter
                    bResult = True
                    Exit For
                End If
            Next

            If bResult Then
                Dim Ruta As String
                Dim Temp As New DirectoryInfo(LetraUnidad & ":")
                Ruta = BuscaArchivoLayout(Temp, NombreArchivo)
                RutaLayout = Ruta
            End If

            fso = Nothing
            Return bResult

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '---------------------------------------------------------------------------------------
    'JNAVA 16.06.2014: Función que verifica si esta disponible el archivo de carga en la Lectora
    '---------------------------------------------------------------------------------------
    Private Function BuscaArchivoLayout(ByVal SearchDir As DirectoryInfo, ByVal searchFileName As String) As String
        Static Dim FoundPath As String = ""
        Try
            If FoundPath = "" Then
                Dim temp As String = ""
                If SearchDir.GetFiles(searchFileName).Length > 0 Then
                    FoundPath = SearchDir.FullName & "\" & searchFileName
                    Return SearchDir.FullName & "\" & searchFileName
                End If
                Dim Directories() As DirectoryInfo = SearchDir.GetDirectories("*")
                For Each newDir As DirectoryInfo In Directories
                    temp = BuscaArchivoLayout(newDir, searchFileName)
                Next
                Return temp
            Else
                Return FoundPath
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '---------------------------------------------------------------------------------------
    'JNAVA 16.06.2014: Función que verifica si esta disponible el archivo de carga en la Lectora
    '---------------------------------------------------------------------------------------
    Private Function CargaArchivoLayout(ByVal BuscaLayout As String) As Boolean

        Dim bRes As Boolean = True
        Dim strLine As String = ""
        Dim i As Integer = 1

        Dim TraspasoActual As String = ""
        Dim BultoActual As String = ""

        Try
            'Creamos la tabla
            CrearTablaLayout()

            'Leemos Datos de archivo
            Dim oSR As New StreamReader(BuscaLayout)
            strLine = oSR.ReadLine

            Do While Not strLine Is Nothing
                If Not strLine.Trim = "" Then

                    'Validamos si es folio de traspaso o si es codigo. Si es traspaso, obtenemos su caja y Traspaso actual
                    If Not GetDatosTraspaso(strLine, TraspasoActual, BultoActual) Then

                        'Revisamos que el primer registro sea un traspaso, si no, no carga nada y manda mensaje
                        If TraspasoActual.Trim = "" Then
                            oSR.Close()
                            MessageBox.Show("Formato del archivo de carga incorrecto. Favor de verificar.", "Carga desde Lectora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            bRes = False
                            Exit Function
                        End If

                        'Si es codigo agregamos los datos
                        Dim dr As DataRow = dtRegistrosLayout.NewRow
                        dr("NUM_REGISTRO") = i
                        dr("TRASPASO") = TraspasoActual
                        dr("BULTO") = BultoActual
                        dr("UPC") = strLine.Trim.PadLeft(18, "0")
                        dr("CODIGO") = ""
                        dr("TALLA") = ""
                        dr("CANTIDAD") = 0
                        dr("PERTENECE") = False
                        dtRegistrosLayout.Rows.Add(dr)
                        dtRegistrosLayout.AcceptChanges()
                    End If
                End If
                strLine = oSR.ReadLine
                i += 1
            Loop

            oSR.Close()
            oSR = Nothing

            Return bRes

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '---------------------------------------------------------------------------------------
    'JNAVA 16.06.2014: Metodo que crea la tabla en la que se cargaran los datos obtenidos
    '---------------------------------------------------------------------------------------
    Private Sub CrearTablaLayout()
        dtRegistrosLayout = Nothing
        dtRegistrosLayout = New DataTable("RegistrosLayout")
        dtRegistrosLayout.Columns.Add("NUM_REGISTRO", System.Type.GetType("System.Int32")) '0
        dtRegistrosLayout.Columns.Add("TRASPASO") '1
        dtRegistrosLayout.Columns.Add("BULTO") '2
        dtRegistrosLayout.Columns.Add("UPC") '3
        dtRegistrosLayout.Columns.Add("CODIGO") '4
        dtRegistrosLayout.Columns.Add("TALLA") '5
        dtRegistrosLayout.Columns.Add("CANTIDAD") '6
        dtRegistrosLayout.Columns.Add("PERTENECE") '7
        dtRegistrosLayout.AcceptChanges()
    End Sub

    '---------------------------------------------------------------------------------------
    'JNAVA 16.06.2014: Función que determina si el dato cargado es Traspaso o Codigo
    '---------------------------------------------------------------------------------------
    Private Function GetDatosTraspaso(ByVal LineaArchivo As String, ByRef FolioTraspaso As String, ByRef BultoActual As String) As Boolean
        Dim bResult As Boolean = True

        If LineaArchivo.Trim.Length = 11 Or LineaArchivo.Trim.Length = 12 Then
            'Determinamos si es un folio de traspaso valido y pendiente
            If Not isTraspasoPendienteSAP(LineaArchivo.Trim.Substring(0, 10)) Then
                bResult = False
                Exit Function
            End If

            FolioTraspaso = LineaArchivo.Trim.Substring(0, 10)
            If LineaArchivo.Trim.Length = 11 Then
                BultoActual = LineaArchivo.Trim.Substring(10, 1)
            ElseIf LineaArchivo.Trim.Length = 12 Then
                BultoActual = LineaArchivo.Trim.Substring(10, 2)
            End If
        Else
            bResult = False
        End If

        Return bResult
    End Function

    '---------------------------------------------------------------------------------------
    'JNAVA 17.06.2014: Función que valida los datos cargados
    '---------------------------------------------------------------------------------------
    Private Function BuscarTraspasosCargados() As String
        Dim hTraspasos As Hashtable
        Dim strTraspasoSel As String = ""

        'Verificamos cuantos traspasos se cargaron desde el Layout (solo se cargan los pendientes)
        hTraspasos = GetTraspasosCargados()

        'Si ningun traspaso cargado esta pendiente, se sale de la funcion.
        If hTraspasos.Count <= 0 Then
            MessageBox.Show("Él o los Traspasos cargados no estan pendientes para darles entrada." & vbCrLf & "Favor de verificar.", "Carga desde Lectora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            strTraspasoSel = ""
            Exit Function
        End If

        'Validar si son mas traspasos de un traspaso pendientes
        If hTraspasos.Count > 1 Then

            'Si son mas de uno, preguntar cual quiere aplicar
            Dim index As Integer = 0
            Dim strMensaje As String = ""
            Dim ofrmTraspasoSel As New frmMensajeSeleccionTraspaso
            Dim bCancel As Boolean = False

            'Mostramos traspasos encontrados
            With ofrmTraspasoSel
                .lblMsg.Text = "Se encontró más de un Traspaso. Favor de seleccionar el que deseé cargar."
                .Text = "Carga desde lectora"
                .hLista = hTraspasos
                .isTraspaso = True
                .ShowDialog()
            End With

            index = ofrmTraspasoSel.index
            bCancel = ofrmTraspasoSel.bCancel
            ofrmTraspasoSel.Dispose()

            'Si cancelo la carga, se sale de la funcion.
            If bCancel Then
                strTraspasoSel = ""
                Exit Function
            End If

            'Si continuo, carga el traspaso seleccionado.
            strTraspasoSel = hTraspasos(index)
        Else 'Si solo es un traspaso, cargamos ese
            strTraspasoSel = hTraspasos(0)
        End If

        Return strTraspasoSel

    End Function

    '---------------------------------------------------------------------------------------
    'JNAVA 17.06.2014: Función que verifica los o el Traspaso cargado
    '---------------------------------------------------------------------------------------
    Private Function GetTraspasosCargados() As Hashtable
        Dim hFoliosTraspaso As New Hashtable
        Dim i As Integer = 0
        For Each oRow As DataRow In dtRegistrosLayout.Rows
            If Not hFoliosTraspaso.ContainsValue(oRow!TRASPASO) Then
                hFoliosTraspaso.Add(i, oRow!TRASPASO)
                i += 1
            End If
        Next
        Return hFoliosTraspaso
    End Function

    '---------------------------------------------------------------------------------------
    'JNAVA 17.06.2014: Revisamos si los Traspasos estan Pendientes de darle Entrada
    '---------------------------------------------------------------------------------------
    Private Function GetTraspasosPendientesSAP(ByVal hTraspaso As Hashtable) As Hashtable

        'Validamos Traspaso en SAP
        Dim dtReturn As DataTable
        Dim hTraspasosPendientes As New Hashtable

        Dim i As Integer

        Try
            i = 0
            For Each strTraspaso As String In hTraspaso.Values
                If isTraspasoPendienteSAP(strTraspaso) Then
                    hTraspasosPendientes.Add(i, strTraspaso.Trim.PadLeft(10, "0"))
                    i += 1
                End If
            Next

            Return hTraspasosPendientes

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '---------------------------------------------------------------------------------------
    'JNAVA 20.06.2014: Revisamos si es traspaso pendiente
    '---------------------------------------------------------------------------------------
    Private Function isTraspasoPendienteSAP(ByVal FolioTraspaso As String) As Boolean

        Dim dtTraspasoTemp As DataTable
        Dim bRes As Boolean = True
        Dim bReturn As Boolean = False

        Try
            Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            dtTraspasoTemp = oSap.Read_TraspasosEspera(Today.ToShortDateString, Today.ToShortDateString, FolioTraspaso.Trim.PadLeft(10, "0"), "N", False, bRes)
            If bRes Then
                If dtTraspasoTemp.Rows.Count > 0 Then
                    bReturn = True
                End If
            End If

            Return bReturn

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '---------------------------------------------------------------------------------------
    'JNAVA 18.06.2014: Filtro por Traspaso y Suma de cantidades por codigo
    '---------------------------------------------------------------------------------------
    Private Function PrepararCodigosTraspaso(ByVal FolioTraspaso As String) As DataTable

        Dim dtResult As DataTable = dtRegistrosLayout.Clone
        Dim dtTraspasoSel As DataTable = dtRegistrosLayout.Clone
        Dim dvTraspasoSel As DataView
        Dim dvCodigosCant As DataView

        Try
            'Seleccionamos los datos del traspaso seleccionado
            dvTraspasoSel = New DataView(dtRegistrosLayout, "TRASPASO ='" & FolioTraspaso.Trim & "'", "", DataViewRowState.CurrentRows)
            If dvTraspasoSel.Count > 0 Then
                For Each oRowV As DataRowView In dvTraspasoSel
                    dtTraspasoSel.ImportRow(oRowV.Row)
                Next
                dtTraspasoSel.AcceptChanges()

Cantidad:       'Obtenemos cuantos registros hay para el codigo actual tomando en cuenta el traspaso y el bulto
                For Each oRowV As DataRow In dtTraspasoSel.Rows
                    dvCodigosCant = New DataView(dtTraspasoSel, "TRASPASO ='" & oRowV!TRASPASO & _
                                                 "' AND UPC ='" & oRowV!UPC & "'", "", DataViewRowState.CurrentRows)
                    '                            "' AND BULTO =" & oRowV!BULTO & _

                    If dvCodigosCant.Count > 0 Then

                        oRowV!CANTIDAD = dvCodigosCant.Count 'Ponemos la cantidad de codigos
                        dtResult.ImportRow(oRowV) 'Importamos registro a la tabla de resultado

                        'Eliminamos todos los codigos de la tabla a consultar para evitar duplicados
                        For Each oRowVD As DataRowView In dvCodigosCant
                            dtTraspasoSel.Rows.Remove(oRowVD.Row)
                        Next
                        dtTraspasoSel.AcceptChanges()

                        If dtTraspasoSel.Rows.Count > 0 Then
                            GoTo Cantidad
                        Else
                            Exit For
                        End If

                    End If
                Next
                dtResult.AcceptChanges()

                '-------------------------------------------------------------------------------------------------------
                'JNAVA 19.06.2014: Obtenemos el Codigo del Articulo y la Talla en base al UPC y lo cambiamos en la tabla
                '-------------------------------------------------------------------------------------------------------
                Dim strCodArticulo As String = ""
                Dim strTalla As String = ""
                Dim i As Integer = 0

                For Each oRowR As DataRow In dtResult.Rows
                    If ObtenerCodigoTallaByUPC(CStr(oRowR!UPC).Trim, strCodArticulo, strTalla) Then
                        oRowR!CODIGO = strCodArticulo.Trim 'Ponemos el Codigo Articulo
                        oRowR!TALLA = strTalla 'Ponemos la Talla
                    End If
                Next
                dtResult.AcceptChanges()
                '-------------------------------------------------------------------------------------------------------

            End If

            dtTraspasoSel = Nothing
            dvTraspasoSel = Nothing
            dvCodigosCant = Nothing

            Return dtResult

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '---------------------------------------------------------------------------------------
    'JNAVA 18.06.2014: Renombramos Archivo en la Lectora
    '---------------------------------------------------------------------------------------
    Private Sub RespaldoArchivoLectora(ByVal RutaArchivo As String, ByVal NombreArchivoOriginal As String)
        'Dim strNombreArchivoOriginal As String = ""
        Dim strNombreArchivoNuevo As String = ""
        Dim strExtArchivo As String = ""
        Dim strRuta As String = ""

        Dim SplitRuta() As String
        Dim SplitNombre() As String

        Try

Reintentar:
            'Revisar si sigue conectada la lectora
            If Not BuscaLectora("", oConfigCierreFI.NombreLectoraTE, oConfigCierreFI.NombreArchivoLectoraTE) Then
                MessageBox.Show("No se encontró la Lectora. Favor de conectarla de nuevo para continuar.", "Carga desde Lectora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                GoTo Reintentar
            End If

            'Nombre Original y ruta nueva del archivo
            SplitRuta = RutaArchivo.Split("\")
            strRuta = SplitRuta.GetValue(0) & "\" & SplitRuta.GetValue(1) & "\Respaldo"
            'NombreArchivoOriginal = SplitRuta.GetValue(2)

            'Nombre del archivo ya respaldado
            SplitNombre = NombreArchivoOriginal.Split(".")
            strNombreArchivoNuevo = SplitNombre.GetValue(0) & " " & Format(Date.Now, "dd-MM-yyy") & " " & Format(Date.Now, "hh.mm.ss tt")
            strExtArchivo = SplitNombre.GetValue(1)

            'Buscar carpeta de respaldo en Lectora
            If Not Directory.Exists(strRuta) Then
                Directory.CreateDirectory(strRuta) 'si no existe crearlo y continuar
            End If

            'Movemos el archivo a la Carpeta de respaldo en lectora 
            File.Move(RutaArchivo, strRuta & "\" & NombreArchivoOriginal)

            'Renombrar el archivo en Lectora
            FileSystem.Rename(strRuta & "\" & NombreArchivoOriginal, strRuta & "\" & strNombreArchivoNuevo & "." & strExtArchivo)

            'Revisamos si existe la carpeta C:\Respaldo de Traspasos de Entradas desde Lectora\
            Dim RutaC As String = "C:\Respaldo de Traspasos de Entradas desde Lectora\"
            If Not Directory.Exists(RutaC) Then
                Directory.CreateDirectory(RutaC) 'si no existe la creamos continuar
            End If

            'Copiamos el archivo a  C:\Respaldo de Traspasos de Entradas desde Lectora\
            FileCopy(strRuta & "\" & strNombreArchivoNuevo & "." & strExtArchivo, RutaC & strNombreArchivoNuevo & "." & strExtArchivo)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    '---------------------------------------------------------------------------------------
    'JNAVA 18.06.2014: Generamos Archivo Nuevo en la Lectora
    '---------------------------------------------------------------------------------------
    Private Function GenerarArchivoNuevo(ByVal RutaArchivoCarga As String, ByVal TraspasoCargado As String) As Boolean
        Dim bResp As Boolean = False
        Dim dvTraspasoPen As DataView

        Dim strTraspasoActual As String = ""
        Dim strBultoActual As String = ""

        Try

            'Obtenemos traspasos pendientes en base al traspaso cargado
            dvTraspasoPen = New DataView(dtRegistrosLayout, "TRASPASO <>'" & TraspasoCargado.Trim & "'", "TRASPASO ASC, BULTO ASC", DataViewRowState.CurrentRows)

            If dvTraspasoPen.Count > 0 Then

                'Si hay pendientes, meterlos a un archivo nuevo con el nombre por default
                Dim oWriter As StreamWriter

Reintentar:
                'Revisar si sigue conectada la lectora antes de comenzar a escribir en el archivo
                If Not BuscaLectora("", oConfigCierreFI.NombreLectoraTE, oConfigCierreFI.NombreArchivoLectoraTE) Then
                    MessageBox.Show("No se encontró la Lectora. Favor de conectarla de nuevo para continuar.", "Carga desde Lectora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    GoTo Reintentar
                End If

                oWriter = New StreamWriter(RutaArchivoCarga, False, System.Text.Encoding.ASCII)

                For Each oRowV As DataRowView In dvTraspasoPen
                    If strTraspasoActual = oRowV!TRASPASO AndAlso strBultoActual = oRowV!BULTO Then
                        oWriter.WriteLine(oRowV!UPC)
                    Else
                        strTraspasoActual = oRowV!TRASPASO
                        strBultoActual = oRowV!BULTO
                        oWriter.WriteLine(strTraspasoActual & strBultoActual)
                        oWriter.WriteLine(oRowV!UPC)
                    End If
                Next

                oWriter.Close()
                oWriter = Nothing

                bResp = True
            End If

            'Si no hay pendientes, no hacemos nada

            Return bResp
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '---------------------------------------------------------------------------------------
    'JNAVA 19.06.2014: Validacion de traspaso seleccionado para cargarlo
    '---------------------------------------------------------------------------------------
    Private Sub ValidaTraspasoCargado(ByVal FolioTraspasoCarga As String, ByVal DetalleTraspaso As DataTable)

        Try
            If FolioTraspasoCarga.Trim = "" Then
                Exit Try
            End If

            Dim strCentroOrigen As String = ""
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Mostramos mensaje de Espera
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            oFrmMessage = New frmMessages
            With oFrmMessage
                .lblMessage.Text = "Validando Traspaso Cargado" & vbCrLf & "Favor de Esperar..."
                .Text = "Carga desde Lectora"
                .Show()
            End With
            Application.DoEvents()

            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Validamos Traspaso en SAP
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim dtTraspasoTemp As DataTable
            Dim bRes As Boolean = True
            dtTraspasoTemp = oSap.Read_TraspasosEspera(Today.ToShortDateString, Today.ToShortDateString, FolioTraspasoCarga.Trim.PadLeft(10, "0"), "N", False, bRes)

            dtTraspasoOriginalSAP = dtTraspasoTemp.Copy
            Application.DoEvents()

            If bRes = False Then
                Sm_Nuevo()
                Exit Try
            ElseIf dtTraspasoTemp.Rows.Count <= 0 Then
                MessageBox.Show("El traspaso no existe o no está pendiente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Sm_Nuevo()
                Exit Try
            End If

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Obtenemos el centro de origen
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            strCentroOrigen = dtTraspasoTemp.Rows(0).Item("Origen")
            Dim Bulto As Integer = 0

            ''------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ''Agregamos la columna Bulto al detalle para separar por bultos
            ''------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim dcBulto As New DataColumn
            With dcBulto
                .ColumnName = "Bulto"
                .Caption = "Bulto"
                .DataType = GetType(Integer)
                .DefaultValue = 1
            End With
            dtTraspasoTemp.Columns.Add(dcBulto)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Agregamos columnas para hacer las operaciones convenientes en caso de diferencias
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim dcLecturado As New DataColumn
            With dcLecturado
                .ColumnName = "Lecturado"
                .Caption = "Cant. Lecturada"
                .DataType = GetType(Integer)
                .DefaultValue = 0
            End With
            dtTraspasoTemp.Columns.Add(dcLecturado)

            Dim dcAgregado As New DataColumn
            With dcAgregado
                .ColumnName = "Agregado"
                .Caption = "Agregado"
                .DataType = GetType(Integer)
                .DefaultValue = 0
            End With
            dtTraspasoTemp.Columns.Add(dcAgregado)

            dtTraspasoTemp.AcceptChanges()
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Sumamos el bulto al traspaso de entrada
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            AgregarBultosTraslado(dtTraspasoTemp)
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Asignamos valores al traspaso de entrada
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            oTraspasoEntrada = Nothing
            oTraspasoEntrada = New TraspasoEntrada(oTraspasoEntradaMgr)
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            oTraspasoEntrada.Detalle = New DataSet
            oTraspasoEntrada.Detalle.Tables.Add(dtTraspaso)
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            UnificarCodigos(dtTraspaso)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Igualamos las cantidades para que modifiquen solo en caso de que fisicamente reciban con diferecias
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------
            ColocaCantidadesCargaTraspaso(dtTraspaso, DetalleTraspaso)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA 27.06.2014: Agregamos Codigos que no pertenecen al Traspaso (Sobrantes)
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------
            AgregarCodigoSobrantesTraspaso(DetalleTraspaso)

            oFrmMessage.Close()
            Application.DoEvents()

            GrdTraspasoCorrida.DataSource = dtTraspaso 'oTraspasoEntrada.Detalle.Tables(0)
            GrdTraspasoCorrida.RetrieveStructure()

            oTraspasoEntrada.Status = "TRA"

            '-----------------------------------------------------------------------------------------------------------------------------------------------------------
            'Mostramos la información del traspaso cargado desde la lectora.
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------
            bValidacionCarga = True
            MostrarTraspasoInformacionCargada()

            Me.GrdTraspasoCorrida.Focus()

        Catch ex As Exception
            Throw ex
        Finally
            bValidacionCarga = False
        End Try

        Me.ebFolio.ReadOnly = True

    End Sub

    '---------------------------------------------------------------------------------------
    'JNAVA 19.06.2014: Buscamos Codigo y Talla a partir del Codigo UPC
    '---------------------------------------------------------------------------------------
    Private Function ObtenerCodigoTallaByUPC(ByVal CodigoUPC As String, ByRef CodigoArticulo As String, ByRef Talla As String) As Boolean

        Dim bResult As Boolean = False
        Dim oUPCMgr As CatalogoUPCManager = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
        Dim oUPC As UPC
        oUPC = oUPCMgr.Create
        oUPC = oUPCMgr.Load(CodigoUPC)

        If oUPC.CodArticulo <> String.Empty Then
            CodigoArticulo = oUPC.CodArticulo
            Talla = oUPC.Numero
            'strDescripcion = oUPC.Descripcion
            bResult = True
        End If

        Return bResult
    End Function

    '--------------------------------------------------------------------------------------------
    'JNAVA 19.06.2014: Colocamos cantidades al TraspasoSAP de traspaso seleccionado para cargarlo
    '--------------------------------------------------------------------------------------------
    Private Sub ColocaCantidadesCargaTraspaso(ByVal TraspasoSAP As DataTable, ByVal TraspasoCarga As DataTable)

        Dim oRowSAP As DataRow
        Dim oRowC As DataRow
        Dim PerteneceTraspaso As Boolean = False

        For Each oRowC In TraspasoCarga.Rows
            For Each oRowSAP In TraspasoSAP.Rows
                If oRowC!CODIGO = oRowSAP!Codigo And oRowC!TALLA = oRowSAP!Talla Then
                    oRowSAP!Lecturado += oRowC!Cantidad
                    oRowC!PERTENECE = True
                End If
            Next
        Next

        TraspasoSAP.AcceptChanges()
        TraspasoCarga.AcceptChanges()

    End Sub

    '--------------------------------------------------------------------------------------------
    'JNAVA 19.06.2014: Mostramos la información del traspaso cargado
    '--------------------------------------------------------------------------------------------
    Private Sub MostrarTraspasoInformacionCargada()
        Try

            With oTraspasoEntrada

                Dim oRow As DataRow

                oRow = dtTraspaso.Rows(0)

                .Folio = oRow("Referencia")
                .FolioSAP = oRow("Referencia")

                .TraspasoCreadoEl = oRow("fecha")
                .TraspasoRecibidoEl = Format(oRow("fecha"), "Short Date")

                Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim strCentroOrig(2) As String
                Dim strCentroDest(2) As String

                strCentroOrig = oSap.Read_CentrosSAP(oRow("Origen"))

                ebSucOrigenCod.Text = strCentroOrig(0)      'Codigo
                ebSucOrigenDesc.Text = strCentroOrig(1)     'Nomrbre

                .AlmacenOrigenID = strCentroOrig(0)

                strCentroDest = oSap.Read_CentrosSAP(oRow("Destino"))

                ebSucDestinoCod.Text = strCentroDest(0)     'Codigo
                ebSucDestinoDesc.Text = strCentroDest(1)    'Nombre

                .AlmacenDestinoID = strCentroDest(0)

                ebFolio.Text = oRow("Referencia") '.Folio    '.TraspasoID

                ebFecha.Text = Format(oRow("fecha"), "Short Date")  ' Format(.TraspasoCreadoEl, "Short Date")

                ebStatus.Text = .Status

                ebResponsableDesc.Text = oAppContext.Security.CurrentUser.Name
                .AutorizadoPorID = oAppContext.Security.CurrentUser.SessionLoginName

                ebFechaRecepcion.Text = Format(Date.Now, "Short Date")

                'Formato Grid.
                SetupView()

                ebTotalPiezas.Text = Microsoft.VisualBasic.Fix(dtTraspaso.Compute("SUM(Cantidad)", "Cantidad > 0"))
                ebTotalLecturado.Text = Microsoft.VisualBasic.Fix(dtTraspaso.Compute("SUM(Lecturado)", "Lecturado > 0"))

                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Guia - Total Bultos - Paqueteria - Transportista
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (16.02.2016): Adecuaciones por retail
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim strGuia, strTransportista As String
                Dim iBultos As Integer = 0
                oSap.ReadInfoPaqueteria(ebFolio.Text, strGuia, strTransportista, iBultos)
                Me.ebNumGuia.Text = strGuia 'oSap.ReadInfoPaqueteria(ebFolio.Text, "F01")

                .Guia = Me.ebNumGuia.Text
                '------------------------------------------------------------------------------------------------------------------------------------------------------------

                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA(15.02.2016): se comento por adecuaciones a retail
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Me.ebNumBultos.Text = oSap.ReadInfoPaqueteria(ebFolio.Text, "F02")
                'If Me.ebNoBulto.Value > 0 AndAlso Me.ebNumBultos.Text.Trim <> "" AndAlso CInt(Me.ebNumBultos.Text) > 0 Then
                '    Me.ebNumBultosRecibidos.Text = Me.ebNumBultos.Text.Trim
                '    Me.ebNumBultosRecibidos.ReadOnly = True
                '    Me.ebNumBultosRecibidos.BackColor = Color.Ivory
                'ElseIf Me.ebNumBultos.Text.Trim = "" Then
                '    Me.ebNumBultos.Text = "0"
                'End If

                'If Me.ebNumBultos.Text.Trim = String.Empty Then
                '    .TotalBultos = 0
                'Else
                '    .TotalBultos = CInt(Me.ebNumBultos.Text)
                'End If

                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (16.02.2016): Adecuaciones por retail
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                Me.ebTransportistaDesc.Text = strTransportista 'oSap.ReadInfoPaqueteria(ebFolio.Text, "F03")
                .TransportistaID = Me.ebTransportistaDesc.Text
                '------------------------------------------------------------------------------------------------------------------------------------------------------------

                Me.ebFolio.Enabled = False
                Me.GrdTraspasoCorrida.AllowEdit = InheritableBoolean.False

                'Cambiamos propiedades de controles para cuando son traspasos de entrada por traspaso y no por bultos
                Me.ebFolio.ReadOnly = True
                Me.ebNoBulto.Visible = False
                Me.lblNoBulto.Visible = False
                Me.Label8.Visible = False
                Me.ebNumBultosRecibidos.Visible = False
                Me.btnAgregar.Visible = False

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    '---------------------------------------------------------------------------------------
    'JNAVA 20.06.2014: Mostramos los Codigos UPC cargados que no fueron validos
    '---------------------------------------------------------------------------------------
    Private Sub MostrarCodigosIgnorados(ByVal TraspasoCarga As DataTable)
        Dim dvIgnorados As DataView
        dvIgnorados = New DataView(TraspasoCarga, "PERTENECE = FALSE", "", DataViewRowState.CurrentRows)
        If dvIgnorados.Count > 0 Then
            Dim hIgnorados As New Hashtable
            Dim i As Integer = 0
            For Each oRowV As DataRowView In dvIgnorados
                hIgnorados.Add(i, oRowV!UPC)
                i += 1
            Next

            'Mostrar Codigos UPC Ignorados
            Dim ofrmTraspasoSel As New frmMensajeSeleccionTraspaso
            Dim bCancel As Boolean = False

            'Mostramos traspasos encontrados
            With ofrmTraspasoSel
                .lblMsg.Text = "Los siguientes Códigos UPC no fueron validos o no pertenecian al Traspaso Cargado."
                .Text = "Carga desde lectora"
                .hLista = hIgnorados
                .isTraspaso = False
                .ShowDialog()
            End With
            ofrmTraspasoSel.Dispose()

        End If
    End Sub

    Private Sub AgregarCodigoSobrantesTraspaso(ByVal TraspasoCarga As DataTable)

        Try
            Dim dvSobrantes As DataView
            dvSobrantes = New DataView(TraspasoCarga, "PERTENECE = FALSE AND CODIGO <> '' AND TALLA <> ''", "", DataViewRowState.CurrentRows)

            If dvSobrantes.Count > 0 Then
                For Each oRowV As DataRowView In dvSobrantes
                    'Agregamos los registros encontrados en el Grid
                    Dim oRow As DataRow
                    oRow = dtTraspaso.NewRow
                    oRow("Codigo") = oRowV!CODIGO
                    oRow("Descripcion") = Me.oTraspasoEntradaMgr.SelectDescripcion(oRowV!CODIGO)
                    oRow("Talla") = oRowV!TALLA
                    oRow("Cantidad") = 0
                    oRow("Lecturado") = oRowV!CANTIDAD
                    oRow("Agregado") = 1
                    dtTraspaso.Rows.Add(oRow)

                    'Le decimos que si pertenece para que no lo muestre en los invalidos
                    oRowV!PERTENECE = True
                Next
            End If

            dtTraspaso.AcceptChanges()
            GrdTraspasoCorrida.Refresh()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

    '-------------------------------------------------------------------------------------------------
    ' JNAVA (15.04.2016): Funcion para obtener las tallas de los materiales de lso traspasos
    '-------------------------------------------------------------------------------------------------
    Private Function GetTallasTraspaso(ByVal Traspaso As DataSet) As DataSet
        Dim dtTraspaso As DataTable = Traspaso.Tables(0).Copy
        Dim Materiales As New DataTable
        Dim Tallas As DataTable
        Dim Talla As String

        Materiales.Columns.Add("Material")
        Materiales.Columns.Add("Talla")
        For Each oRow As DataRow In dtTraspaso.Rows
            Dim Material As DataRow = Materiales.NewRow()
            Material("Material") = oRow!Codigo
            Material("Talla") = ""
            Materiales.Rows.Add(Material)
        Next
        Materiales.AcceptChanges()

        Materiales = oSapMgr.ZMF_TALLA_COLOR(Materiales)
        For Each oRowTras As DataRow In dtTraspaso.Rows
            For Each oRowT As DataRow In Materiales.Rows
                If CStr(oRowTras!Codigo).Trim = CStr(oRowT!MATNR).Trim Then
                    '---------------------------------------------------------------------------------------------------------
                    ' JNAVA (25.04.2016): Validamos si es Numerico y si es Decimal o Entero para guardarlo correctamente
                    '---------------------------------------------------------------------------------------------------------
                    Talla = ""
                    If IsNumeric(oRowT!Tallas) Then
                        If CInt(oRowT!Tallas) = oRowT!Tallas Then
                            Talla = CInt(oRowT!Tallas).ToString
                        Else
                            Talla = CDec(oRowT!Tallas).ToString
                        End If
                    End If
                    '---------------------------------------------------------------------------------------------------------
                    oRowTras!Talla = Talla
                    Talla = ""
                End If
            Next
        Next

        Traspaso.Tables.Clear()
        Traspaso.Tables.Add(dtTraspaso)
        Traspaso.AcceptChanges()

        Return Traspaso

    End Function

#End Region

#Region "Métodos Privados"

    Private Sub FrmInvTraspasoDEntrada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Validamos Usuario que Aplicara Traspaso de Entrada
        oAppContext.Security.CloseImpersonatedSession()
        If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosEntrada") Then
            oAppContext.Security.CloseImpersonatedSession()
            Me.Finalize()
            Me.Close()
        Else
            UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
            UserNameAplicated = oAppContext.Security.CurrentUser.Name
        End If
        oAppContext.Security.CloseImpersonatedSession()

        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)

        oTraspasoEntrada = New TraspasoEntrada(oTraspasoEntradaMgr)

        oTraspasoSMgr = New TraspasosSalidaManager(oAppContext, oConfigCierreFI)

        oArticulosMgr = New CatalogoArticuloManager(oAppContext)

        odsCatalogoCorridas = oTraspasoEntradaMgr.ExtraerCatalogoCorridas

        If oConfigCierreFI.PedidoCompra = False Then
            GrdTraspasoCorrida.RootTable.Columns("Serie").Visible = False
        End If
        '        
        'Obtener Traspasos DBF
        'oTraspasoEntradaMgr.TraspasoEntradaDBF()

        'Iniciliazacion
        'AJE
        oAjusteMgr = New AjusteGeneralManager(oAppContext, oConfigCierreFI)
        Me.oAjusteAJE = oAjusteMgr.Create("E")
        oAjusteAJE.TipoAjuste = "E"
        oAjusteAJE.Detalle.Columns("Cantidad").DefaultValue = 0
        oAjusteAJE.Detalle.Columns("Talla").DefaultValue = String.Empty
        oAjusteAJE.Detalle.Columns("FolioSAP").DefaultValue = String.Empty
        oAjusteAJE.Detalle.Columns("Codigo").DefaultValue = String.Empty
        oAjusteAJE.Detalle.Columns("descripcion").DefaultValue = String.Empty
        oAjusteAJE.Detalle.Columns("importe").DefaultValue = 0
        oAjusteAJE.Detalle.Columns("Total").Expression = "Cantidad * Importe"
        oAjusteAJE.Detalle.AcceptChanges()

        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        If oConfigCierreFI.RecibirParcialmente = False Then
            Me.ebFolio.ReadOnly = True
            Me.ebNoBulto.Visible = False
            Me.lblNoBulto.Visible = False
            Me.ebNumBultosRecibidos.Visible = False
            Me.btnAgregar.Visible = False
            Me.Label8.Visible = False
        End If

        '---------------------------------------------------------------------------------------
        'JNAVA 13.06.2014: Configuracion de traspaso de entrada desde lectora
        '---------------------------------------------------------------------------------------
        If oConfigCierreFI.TraspasoEntradaLectora = True Then
            Me.UiCommandBar2.Commands("menuArchivoCargaLectora").Visible = Janus.Windows.UI.InheritableBoolean.True
        Else
            Me.UiCommandBar2.Commands("menuArchivoCargaLectora").Visible = Janus.Windows.UI.InheritableBoolean.False
        End If

    End Sub

    Private Sub FrmInvTraspasoDEntrada_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        On Error Resume Next

        oTraspasoEntrada = Nothing

        oTraspasoEntradaMgr = Nothing

        odsCatalogoCorridas.Dispose()
        odsCatalogoCorridas = Nothing

    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case (e.Command.Key)

            Case "menuArchivoNuevo"

                Sm_Nuevo()


            Case "menuArchivoAbrir"

                Sm_AbrirTraspaso() ' La Quite por que ocupo investigar que hacia


            Case "menuArchivoAbrirPendientes"

                Sm_AbrirTraspasoPendientes()


            Case "menuArchivoAplicar"

                Sm_AplicarTraspaso()

            Case "menuArchivoCerrar"

                Me.Close()

            Case "menuArchivoImprimir"

                If MsgBox("¿Desea imprimir este traspaso?", MsgBoxStyle.Question + MsgBoxStyle.OKCancel, "Imprimir Traspaso de Entrada") = MsgBoxResult.OK Then
                    PrintComprobanteTraspaso()
                End If

            Case "menuArchivoCargaLectora"

                CargaDesdeLectora()

        End Select

    End Sub

    Private Sub GrdTraspasoCorrida_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        SetupView()

    End Sub

    Private Sub uibtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Sm_AbrirTraspaso()

    End Sub

    Private Sub uibtnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Sm_AplicarTraspaso()

    End Sub

    Private Sub uibtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub FrmInvTraspasoDEntrada_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub GrdTraspasoCorrida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdTraspasoCorrida.KeyDown
        'Version 2.1.3

        If e.KeyCode = Keys.Insert Then
            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CapturaManualDeMaterial") = True Then
                Dim oForm As New frmTENewArticulo
                oForm.ShowDialog()

                If oForm.DialogResult = DialogResult.OK Then
                    Dim dRow As DataRow
                    dRow = dtTraspaso.NewRow
                    dRow("Codigo") = oForm.strArticulo
                    dRow("Descripcion") = Me.oTraspasoEntradaMgr.SelectDescripcion(oForm.strArticulo)
                    dRow("Talla") = oForm.strTalla
                    dRow("Cantidad") = 0
                    dRow("Lecturado") = 1
                    dRow("Agregado") = 1
                    dtTraspaso.Rows.Add(dRow)
                    dtTraspaso.AcceptChanges()
                    GrdTraspasoCorrida.Refresh()

                    'Llamo la pantalla para capturar el motivo de la captura manual
                    Dim oForma As New frmMotivosFactura
                    oForma.Motivos = oTraspasoEntrada.dtMotivos
                    oForma.Tienda = oAppContext.ApplicationConfiguration.Almacen
                    oForma.Articulo = oForm.strArticulo
                    oForma.Talla = oForm.strTalla
                    oForma.ShowDialog()
                End If
            End If
            oAppContext.Security.CloseImpersonatedSession()
        End If ' FIN DELINSERT


        If e.KeyCode = Keys.Delete Then
            Dim oCurrentRow As GridEXRow
            Dim odrDataRow As DataRowView
            oCurrentRow = GrdTraspasoCorrida.GetRow()
            odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

            If dtTraspaso.Rows.Count = 1 Then
                If CType(odrDataRow.Item("Agregado"), Integer) = 1 Then
                    If CType(odrDataRow.Item("Codigo"), String) <> "" Then
                        Dim oDataView As New DataView(dtTraspaso, "Codigo = '" & CType(odrDataRow.Item("Codigo"), String) & "' and Talla = '" & CType(odrDataRow.Item("Talla"), String) & "'", "Codigo,Talla", DataViewRowState.CurrentRows)
                        If oDataView.Count > 0 Then
                            oDataView.Delete(0)
                            dtTraspaso.AcceptChanges()
                        End If
                    End If
                Else
                    MsgBox("¡No se puede eliminar articulo!", MsgBoxStyle.Information, Me.Text)
                    Me.GrdTraspasoCorrida.Select()
                End If
            Else
                If CType(odrDataRow.Item("Agregado"), Integer) = 1 Then
                    If CType(odrDataRow.Item("Codigo"), String) <> "" Then
                        Dim oDataView As New DataView(dtTraspaso, "Codigo = '" & CType(odrDataRow.Item("Codigo"), String) & "' and Talla = '" & CType(odrDataRow.Item("Talla"), String) & "'", "Codigo,Talla", DataViewRowState.CurrentRows)
                        If oDataView.Count > 0 Then
                            oDataView.Delete(0)
                            dtTraspaso.AcceptChanges()
                        End If
                    End If
                    odrDataRow.Row.Delete()
                    'dtTraspaso.Rows(nRow).Delete()
                    dtTraspaso.AcceptChanges()
                Else
                    MsgBox("¡No se puede eliminar articulo!", MsgBoxStyle.Information, Me.Text)
                    Me.GrdTraspasoCorrida.Select()
                End If
            End If
            GrdTraspasoCorrida.Refresh()
            oCurrentRow = Nothing
            odrDataRow = Nothing
        End If ' FIN DEL DELETE


        Dim strCodArticulo, strNumero, strDescripcion As String
        'strline = strline.Trim
        'If e.KeyCode = Keys.Enter AndAlso strline.Trim <> "" AndAlso Not boolManual Then
        If e.KeyCode = Keys.Enter AndAlso strline.Trim <> "" AndAlso _
        (boolManual = False OrElse (boolManual AndAlso ((oConfigCierreFI.RecibirParcialmente = False AndAlso Me.GrdTraspasoCorrida.Col <> 9) _
        OrElse (oConfigCierreFI.RecibirParcialmente AndAlso Me.GrdTraspasoCorrida.Col <> 11)))) Then

            strline = strline.Trim
            strline = strline.Replace("", "")
            'Buscar Codigo de articulo en catalogo UPC
            strline = strline.PadLeft(18, "0")
            strline = Mid(strline, strline.Length - 17)

            If IsNumeric(strline) Then
                If strline = "000000000000000000" Then Exit Sub

                dsMaterialTalla = New DataSet
                dsMaterialTalla = Me.oTraspasoEntradaMgr.SelectMaterialTalla(strline)

                If dsMaterialTalla.Tables(0).Rows.Count > 0 Then
                    strCodArticulo = dsMaterialTalla.Tables(0).Rows(0).Item("CodArticulo")
                    strNumero = dsMaterialTalla.Tables(0).Rows(0).Item("Numero")
                    strDescripcion = dsMaterialTalla.Tables(0).Rows(0).Item("Descripcion")
                Else
                    'Buscamos Codigo UPC
                    Dim oUPCMgr As CatalogoUPCManager = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
                    Dim oUPC As UPC
                    oUPC = oUPCMgr.Create
                    oUPC = oUPCMgr.Load(strline)

                    If oUPC.CodArticulo <> String.Empty Then
                        strCodArticulo = oUPC.CodArticulo
                        strNumero = oUPC.Numero
                        strDescripcion = oUPC.Descripcion
                    Else
                        MsgBox("El Código UPC no Existe.", MsgBoxStyle.Information, Me.Text)
                        strline = ""
                        Exit Sub
                    End If
                End If

            Else
                '////////////////// CODIGOS VIEJOS \\\\\\\\\\\\\\\\\\\

                Dim vCodArticulo As String
                Dim vNumStringArticulo As String
                Dim vNumeroArticulo As String

                vCodArticulo = UCase(strline)
                vNumStringArticulo = Mid(vCodArticulo, 1, 2)
                If IsNumeric(vNumStringArticulo) Then
                    vCodArticulo = UCase(Mid(vCodArticulo, 3, Len(vCodArticulo) - 2))
                    If vNumStringArticulo <> "00" Then
                        vNumeroArticulo = CDec(vNumStringArticulo) / 2
                    Else
                        vNumeroArticulo = "00"
                    End If
                    Dim oArticulo As Articulo
                    Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
                    oArticulo = oArticuloMgr.Create
                    oArticulo.ClearFields()
                    oArticuloMgr.LoadInto(vCodArticulo, oArticulo, True)
                    If oArticulo.CodArticulo <> String.Empty Then
                        vCodArticulo = oArticulo.CodArticulo
                    Else
                        oArticulo.ClearFields()
                        oArticuloMgr.LoadInto(vCodArticulo, oArticulo)
                        If oArticulo.CodArticulo <> String.Empty Then
                            vCodArticulo = oArticulo.CodArticulo
                        Else
                            MsgBox("El Código UPC no Existe.", MsgBoxStyle.Information, Me.Text)
                            strline = ""
                            Exit Sub
                        End If
                    End If

                    'vCodArticulo " Codigo de articulo.
                    'vNumeroArticulo " Numero de Material.
                    strCodArticulo = vCodArticulo
                    strNumero = vNumeroArticulo
                    strDescripcion = oArticulo.Descripcion
                Else
                    MsgBox("El Código UPC no Existe.", MsgBoxStyle.Information, Me.Text)
                    strline = ""
                    Exit Sub

                End If 'fin del IsNumeric(vNumStringArticulo)

                '/////////////////// CODIGOS VIEJOS \\\\\\\\\\\\\\\\\\\\ 

            End If ' Fin del IsNumeric(strLine)

            strline = ""
            'Agregamos la cantidad al grid dependiendo del material
            'Dim oDataView As New DataView(dtTraspaso, "Codigo ='" & strCodArticulo & "' and " & _
            '        "Talla='" & strNumero & "' ", "codigo", DataViewRowState.CurrentRows)
            Dim oDataView As New DataView(dtTraspaso, "Codigo ='" & strCodArticulo & "' ", "codigo", DataViewRowState.CurrentRows)
            Dim dtZequi As DataTable = oTraspasoEntradaMgr.GetZequiByOption(1, strCodArticulo)
            If dtZequi.Rows.Count > 1 Then
                Dim Serie As String = ""
                Serie = InputBox("Captura Número de Serie", "Dportenis PRO")
                If Serie.Trim() <> "" Then
                    Dim Zequi As Zequi = Nothing
                    Zequi = oTraspasoEntradaMgr.GetZequi(strCodArticulo, Serie)
                    If Not Zequi Is Nothing Then
                        Dim rows() As DataRow = dtTraspaso.Select("Codigo ='" & strCodArticulo & "' ")
                        If rows.Length = 1 AndAlso CStr(rows(0)!Serie).Trim() = "" Then
                            rows(0)("Serie") = Serie
                            rows(0)("lecturado") += 1
                            rows(0).AcceptChanges()
                        Else
                            Dim fila As DataRow = dtTraspaso.NewRow()
                            fila("Codigo") = CStr(rows(0)!Codigo)
                            fila("Serie") = Serie
                            fila("Descripcion") = strDescripcion
                            fila("Talla") = strNumero
                            fila("Cantidad") = CInt(rows(0)("Cantidad"))
                            fila("Lecturado") = 1
                            fila("Origen") = Me.ebSucOrigenCod.Text
                            fila("Destino") = Me.ebSucDestinoCod.Text
                            fila("Fecha") = Date.Today.ToShortDateString
                            dtTraspaso.Rows.Add(fila)
                        End If
                        dtTraspaso.AcceptChanges()
                    End If
                Else
                    MessageBox.Show("No se pudo agregar el artículo debido a que se cancelo la captura de número de serie", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Else
                If oDataView.Count > 0 Then
                    For Each oDataRowViewF As DataRowView In oDataView
                        'If oDataRowViewF.Row.Item("Lecturado") < oDataRowViewF.Row.Item("Cantidad") Then
                        oDataRowViewF.Row.Item("lecturado") += 1
                        'Else
                        '   MsgBox("La lectura del material " & strCodArticulo & " , Talla: " & strNumero & Microsoft.VisualBasic.vbCrLf & " se completo.", MsgBoxStyle.Information, Me.Text)
                        '  Me.GrdTraspasoCorrida.Select()
                        'End If
                    Next
                    dtTraspaso.AcceptChanges()

                    Me.ebTotalLecturado.Text = CStr(dtTraspaso.Compute("SUM(Lecturado)", "Lecturado > 0"))

                Else
                    'A peticion de Manuel Camacho si no existe el codigo upc en el Grid, que lo agregue
                    Dim oRow As DataRow = dtTraspaso.NewRow
                    With oRow
                        .Item("Codigo") = strCodArticulo
                        .Item("Descripcion") = strDescripcion
                        .Item("Talla") = strNumero
                        .Item("Cantidad") = 0
                        .Item("Lecturado") = 1
                        .Item("Agregado") = 1
                        .Item("Origen") = Me.ebSucOrigenCod.Text
                        .Item("Destino") = Me.ebSucDestinoCod.Text
                        .Item("Fecha") = Date.Today.ToShortDateString
                    End With
                    dtTraspaso.Rows.Add(oRow)
                    dtTraspaso.AcceptChanges()

                    Me.ebTotalLecturado.Text = CStr(dtTraspaso.Compute("SUM(Lecturado)", "Lecturado > 0"))

                    'MsgBox("El código UPC no se encontró en el detalle del traslado.", MsgBoxStyle.Information, Me.Text)
                    Me.GrdTraspasoCorrida.Refresh()
                    Me.GrdTraspasoCorrida.Select()

                End If
            End If
        Else
            If e.KeyCode = 189 Then
                strline = strline & "-"
            Else
                strline = strline & Chr(e.KeyCode)
            End If
        End If

        Select Case e.KeyCode
            Case Keys.F2
                'If GrdTraspasoCorrida.Col = 9 Then
                If (oConfigCierreFI.RecibirParcialmente AndAlso GrdTraspasoCorrida.Col = 11) OrElse (oConfigCierreFI.RecibirParcialmente = False AndAlso GrdTraspasoCorrida.Col = 9) Then

                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CapturaManualDeMaterial") = True Then
                        'ALLOW
                        boolManual = True
                        Me.GrdTraspasoCorrida.AllowEdit = InheritableBoolean.True
                        If oConfigCierreFI.RecibirParcialmente Then
                            Me.GrdTraspasoCorrida.RootTable.Columns.Item(11).EditType = EditType.TextBox
                        Else
                            Me.GrdTraspasoCorrida.RootTable.Columns.Item(9).EditType = EditType.TextBox
                        End If
                        Me.GrdTraspasoCorrida.RootTable.Columns.Item(1).EditType = EditType.NoEdit
                        Me.GrdTraspasoCorrida.RootTable.Columns.Item(2).EditType = EditType.NoEdit
                        Me.GrdTraspasoCorrida.RootTable.Columns.Item(3).EditType = EditType.NoEdit
                        Me.GrdTraspasoCorrida.RootTable.Columns.Item(6).EditType = EditType.NoEdit
                    Else
                        'ALLOW
                        If oConfigCierreFI.RecibirParcialmente Then
                            Me.GrdTraspasoCorrida.RootTable.Columns.Item(11).EditType = EditType.NoEdit
                        Else
                            Me.GrdTraspasoCorrida.RootTable.Columns.Item(9).EditType = EditType.NoEdit
                        End If
                        Me.GrdTraspasoCorrida.AllowEdit = InheritableBoolean.False
                        boolManual = False
                    End If
                    oAppContext.Security.CloseImpersonatedSession()

                End If
        End Select

    End Sub

    Private Sub GrdTraspasoCorrida_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdTraspasoCorrida.CurrentCellChanged

        'GrdTraspasoCorrida.Col()

        Dim oCurrentRow As GridEXRow
        Dim odrDataRow As DataRowView
        Dim Cantidad As Integer
        Dim lecturado As Integer
        Dim Articulo, Talla As String

        oCurrentRow = GrdTraspasoCorrida.GetRow()
        odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

        Cantidad = CType(odrDataRow.Item("Cantidad"), Integer)
        lecturado = CType(odrDataRow.Item("Lecturado"), Integer)
        Articulo = CType(odrDataRow.Item("Codigo"), String)
        Talla = CType(odrDataRow.Item("Talla"), String)

        'If lecturado > Cantidad Then
        '    odrDataRow.Item("Lecturado") = Cantidad
        '    lecturado = Cantidad

        'End If
        If dtTraspaso.Rows.Count > 0 Then
            Me.ebTotalLecturado.Text = IIf(IsDBNull(dtTraspaso.Compute("SUM(Lecturado)", "Lecturado > 0")), 0, dtTraspaso.Compute("SUM(Lecturado)", "Lecturado > 0"))
        End If

        If oConfigCierreFI.RecibirParcialmente = False Then
            If boolManual = True Then
                If odrDataRow.Item("Lecturado") > 0 Then
                    '------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'Mando llamar la pantalla de motivos de captura manual
                    '------------------------------------------------------------------------------------------------------------------------------------------------------------
                    Dim oForm As New frmMotivosFactura
                    oForm.Motivos = oTraspasoEntrada.dtMotivos

                    oForm.Tienda = oAppContext.ApplicationConfiguration.Almacen
                    oForm.Articulo = Articulo
                    oForm.Talla = Talla

                    oForm.ShowDialog()
                End If
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Regreso el Grid a su estado original -- No editable
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                boolManual = False
                Me.GrdTraspasoCorrida.AllowEdit = InheritableBoolean.False
                Me.GrdTraspasoCorrida.RootTable.Columns.Item("Lecturado").EditType = EditType.NoEdit
            End If
        End If

    End Sub

    Private Sub ebFolio_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolio.Validating
        If Not bValidacionCarga Then 'Si no se valido en la carga desde la lectora, valida el traspaso
            ValidaTraspaso()
        End If
    End Sub

    Private Sub ebFolio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebFolio.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Me.ebFolio.ReadOnly = True Then
                If strFolioTraspaso.Trim.Length > 10 Then
                    Me.ebNoBulto.Value = IIf(IsNumeric(strFolioTraspaso.Trim.Substring(Me.strFolioTraspaso.Length - 1, 1)), strFolioTraspaso.Trim.Substring(Me.strFolioTraspaso.Length - 1, 1), 0)
                    strFolioTraspaso = strFolioTraspaso.Trim.Substring(0, 10)
                End If
                Me.ebFolio.Text = strFolioTraspaso.Trim
                strFolioTraspaso = ""
            End If
            Me.ebNoBulto.Focus()
        ElseIf e.Alt AndAlso e.KeyCode = Keys.T Then
            Me.ebFolio.ReadOnly = False
        Else
            strFolioTraspaso &= Chr(e.KeyCode)
        End If

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If oConfigCierreFI.RecibirParcialmente AndAlso Me.ebNoBulto.Value > 0 Then
            ValidaTraspaso()
        End If
    End Sub

    Private Sub FrmInvTraspasoDEntrada_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not dtTraspaso Is Nothing AndAlso dtTraspaso.Rows.Count > 0 AndAlso Me.ebStatus.Text.Trim.ToUpper <> "GRA" Then
            If MessageBox.Show("¿Estas seguro que deseas salir sin aplicar el traspaso?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "Consignacion"

    Private Function GuardarZequi(ByVal dtZequi As DataTable, ByVal lstZequi As List(Of Zequi)) As Boolean
        Dim TraspasoEntradaMgr As New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        Dim valido As Boolean = False
        Dim zequi As Zequi = Nothing
        Try
            For Each row As DataRow In dtZequi.Rows
                zequi = New Zequi(TraspasoEntradaMgr)
                zequi.CodArticulo = CStr(row("MATNR"))
                zequi.Serie = CStr(row("SERNR"))
                zequi.NoPedido = CStr(row("EBELN"))
                zequi.CentroOrigen = CStr(row("WERKS"))
                zequi.CentroDestino = CStr(row("WERKSD"))
                zequi.Proveedor = CStr(row("LIFNR"))
                zequi.DocMaterial = CStr(row("MBLNR"))
                zequi.ClaseMovimiento = CStr(row("BWART"))
                zequi.SOBKZ = CStr(row("SOBKZ"))
                zequi.SHKZG = CStr(row("SHKZG"))
                zequi.BEWTP = CStr(row("BEWTP"))
                lstZequi.Add(zequi)
            Next
            TraspasoEntradaMgr.SaveZequi(lstZequi)
            valido = True
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al guardar los artículos de Consignación")
        End Try
        Return valido
    End Function

#End Region


    Private Function SaveZFMComAclaracion(strFolio As String, dtview As DataView, tipo As String) As DataTable
        Dim oParametros As New Dictionary(Of String, Object)
        Dim response As DataTable
        Dim items As Integer = 0

        With oParametros                
            Dim strCentro As String = oSapMgr.Read_Centros
            Dim oLstProductos As New List(Of Dictionary(Of String, Object))
            For Each oRow As DataRowView In dtview
                If CInt(oRow("cantidad")) - CInt(oRow("lecturado")) > 0 Then
                    '------------------------------------------------------------------
                    ' Seteamos datos del detalle
                    '------------------------------------------------------------------
                    Dim oProducto As New Dictionary(Of String, Object)
                    With oProducto
                        .Add("ID_PR_AC", String.Empty)
                        .Add("CENTRO", strCentro)
                        .Add("MATERIAL", CStr(oRow!Codigo))
                        .Add("IDMOTIVO", "01")
                        .Add("TALLA", CStr(oRow!Talla))
                        .Add("ALMACEN", "M001")
                        .Add("MOTIVODES", "Traspaso Incompleto")
                        .Add("CANTIDAD", CInt(oRow("cantidad")) - CInt(oRow("lecturado")))
                        .Add("TRASPASO", strFolio)
                        .Add("TIPOM", tipo)

                    End With
                    oLstProductos.Add(oProducto)
                    items += 1
                End If
            Next
            '------------------------------------------------------------------
            ' Metemos los datos al detalle del objeto para serializarlo a JSON
            '------------------------------------------------------------------
            .Add("SapPtInputData", oLstProductos)
            
        End With


        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        If items > 0 Then
            Dim oRetail As New ProcesosRetail("/pos_api/s1", "POST")
            response = oRetail.SapZfmcomAclaracion(oParametros)
        End If
       
        Return response

    End Function

    Private Sub UiCommandBar2_CommandClick(sender As System.Object, e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandBar2.CommandClick

    End Sub
End Class
