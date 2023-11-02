Imports System.Web.Mail
Imports System.Web.Util
Imports System.Net
Imports System.io
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
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores

'AJE
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralNuevo
Imports Janus.Windows.GridEX

Public Class frmRecepcionMercanciaTiendas
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebNoBulto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblNoBulto As System.Windows.Forms.Label
    Friend WithEvents ebMoneda As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebNumBultosRecibidos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFechaRecepcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNumGuia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNumBultos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar4 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebTotalLecturado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ebTotalPiezas As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ebStatus As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents GrdTraspasoCorrida As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebResponsableDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ebTransportistaDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucDestinoDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucOrigenDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTransportistaCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucDestinoCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucOrigenCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAplicar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAplicar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents MnuCargarOrdenCompra As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCargarOrdenCompra1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuOpenTraspasoEntrada As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuOpenTraspasoEntrada1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuResguardo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuResguardo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecepcionMercanciaTiendas))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup4 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
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
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebNumBultosRecibidos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFechaRecepcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNumGuia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNumBultos = New Janus.Windows.GridEX.EditControls.EditBox()
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
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.GrdTraspasoCorrida = New Janus.Windows.GridEX.GridEX()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuOpenTraspasoEntrada1 = New Janus.Windows.UI.CommandBars.UICommand("MnuOpenTraspasoEntrada")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuCargarOrdenCompra1 = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarOrdenCompra")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAplicar1 = New Janus.Windows.UI.CommandBars.UICommand("menuAplicar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuResguardo1 = New Janus.Windows.UI.CommandBars.UICommand("menuResguardo")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.menuAplicar = New Janus.Windows.UI.CommandBars.UICommand("menuAplicar")
        Me.menuImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.MnuCargarOrdenCompra = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarOrdenCompra")
        Me.MnuOpenTraspasoEntrada = New Janus.Windows.UI.CommandBars.UICommand("MnuOpenTraspasoEntrada")
        Me.menuResguardo = New Janus.Windows.UI.CommandBars.UICommand("menuResguardo")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar4.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        CType(Me.GrdTraspasoCorrida, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ExplorerBar1.Size = New System.Drawing.Size(592, 554)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebNoBulto
        '
        Me.ebNoBulto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNoBulto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNoBulto.Location = New System.Drawing.Point(456, 104)
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
        Me.ebFolio.Location = New System.Drawing.Point(456, 40)
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
        Me.lblNoBulto.Location = New System.Drawing.Point(400, 104)
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
        Me.ebMoneda.Location = New System.Drawing.Point(456, 104)
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
        Me.ebFecha.Location = New System.Drawing.Point(456, 72)
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
        Me.ebResponsableDesc.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebResponsableDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebResponsableDesc.Location = New System.Drawing.Point(120, 136)
        Me.ebResponsableDesc.Name = "ebResponsableDesc"
        Me.ebResponsableDesc.ReadOnly = True
        Me.ebResponsableDesc.Size = New System.Drawing.Size(272, 23)
        Me.ebResponsableDesc.TabIndex = 105
        Me.ebResponsableDesc.TabStop = False
        Me.ebResponsableDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(24, 136)
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
        Me.Label6.Location = New System.Drawing.Point(398, 104)
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
        Me.Label5.Location = New System.Drawing.Point(398, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 23)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(398, 40)
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
        Me.ebTransportistaDesc.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTransportistaDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTransportistaDesc.Location = New System.Drawing.Point(120, 104)
        Me.ebTransportistaDesc.Name = "ebTransportistaDesc"
        Me.ebTransportistaDesc.ReadOnly = True
        Me.ebTransportistaDesc.Size = New System.Drawing.Size(272, 23)
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
        Me.ebSucDestinoDesc.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucDestinoDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucDestinoDesc.Location = New System.Drawing.Point(192, 72)
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
        Me.ebSucOrigenDesc.Location = New System.Drawing.Point(192, 40)
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
        Me.ebTransportistaCod.Location = New System.Drawing.Point(120, 104)
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
        Me.ebSucDestinoCod.Location = New System.Drawing.Point(120, 72)
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
        Me.ebSucOrigenCod.Location = New System.Drawing.Point(120, 40)
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
        Me.Label3.Location = New System.Drawing.Point(24, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Transportista:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Destino:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Origen:"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.ebNumBultosRecibidos)
        Me.ExplorerBar2.Controls.Add(Me.ebFechaRecepcion)
        Me.ExplorerBar2.Controls.Add(Me.ebNumGuia)
        Me.ExplorerBar2.Controls.Add(Me.ebNumBultos)
        Me.ExplorerBar2.Controls.Add(Me.ebReferencia)
        Me.ExplorerBar2.Controls.Add(Me.Label10)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Controls.Add(Me.Label8)
        Me.ExplorerBar2.Controls.Add(Me.Label9)
        Me.ExplorerBar2.Dock = System.Windows.Forms.DockStyle.Right
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Recepción"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(592, 28)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(248, 554)
        Me.ExplorerBar2.TabIndex = 4
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebNumBultosRecibidos
        '
        Me.ebNumBultosRecibidos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumBultosRecibidos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumBultosRecibidos.Location = New System.Drawing.Point(104, 72)
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
        Me.ebFechaRecepcion.Location = New System.Drawing.Point(104, 136)
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
        Me.ebNumGuia.Location = New System.Drawing.Point(104, 104)
        Me.ebNumGuia.Name = "ebNumGuia"
        Me.ebNumGuia.ReadOnly = True
        Me.ebNumGuia.Size = New System.Drawing.Size(112, 23)
        Me.ebNumGuia.TabIndex = 2
        Me.ebNumGuia.TabStop = False
        Me.ebNumGuia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumGuia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNumBultos
        '
        Me.ebNumBultos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumBultos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumBultos.BackColor = System.Drawing.Color.Ivory
        Me.ebNumBultos.Location = New System.Drawing.Point(104, 72)
        Me.ebNumBultos.Name = "ebNumBultos"
        Me.ebNumBultos.ReadOnly = True
        Me.ebNumBultos.Size = New System.Drawing.Size(112, 23)
        Me.ebNumBultos.TabIndex = 1
        Me.ebNumBultos.TabStop = False
        Me.ebNumBultos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumBultos.Visible = False
        Me.ebNumBultos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebReferencia
        '
        Me.ebReferencia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebReferencia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebReferencia.BackColor = System.Drawing.Color.Ivory
        Me.ebReferencia.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebReferencia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebReferencia.Location = New System.Drawing.Point(104, 40)
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
        Me.Label10.Location = New System.Drawing.Point(16, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 23)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Fecha:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 23)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "# de Guia:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "# de Bultos:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 40)
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
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Datos Totales"
        Me.ExplorerBar4.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar4.Location = New System.Drawing.Point(0, 504)
        Me.ExplorerBar4.Name = "ExplorerBar4"
        Me.ExplorerBar4.Size = New System.Drawing.Size(840, 80)
        Me.ExplorerBar4.TabIndex = 6
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
        'ExplorerBar3
        '
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.GrdTraspasoCorrida)
        Me.ExplorerBar3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        ExplorerBarGroup4.Expandable = False
        ExplorerBarGroup4.Expanded = False
        ExplorerBarGroup4.Image = CType(resources.GetObject("ExplorerBarGroup4.Image"), System.Drawing.Image)
        ExplorerBarGroup4.Key = "Group1"
        ExplorerBarGroup4.Text = "Detalle de la Orden de Compra"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup4})
        Me.ExplorerBar3.Location = New System.Drawing.Point(0, 192)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(840, 320)
        Me.ExplorerBar3.TabIndex = 7
        Me.ExplorerBar3.Text = "ExplorerBar3"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'GrdTraspasoCorrida
        '
        Me.GrdTraspasoCorrida.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GrdTraspasoCorrida.DesignTimeLayout = GridEXLayout1
        Me.GrdTraspasoCorrida.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GrdTraspasoCorrida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GrdTraspasoCorrida.GroupByBoxVisible = False
        Me.GrdTraspasoCorrida.Location = New System.Drawing.Point(12, 36)
        Me.GrdTraspasoCorrida.Name = "GrdTraspasoCorrida"
        Me.GrdTraspasoCorrida.Size = New System.Drawing.Size(816, 268)
        Me.GrdTraspasoCorrida.TabIndex = 8
        Me.GrdTraspasoCorrida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo, Me.menuAplicar, Me.menuImprimir, Me.menuSalir, Me.MnuCargarOrdenCompra, Me.MnuOpenTraspasoEntrada, Me.menuResguardo})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("870352ce-2141-447d-9d32-09695743d289")
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo1, Me.Separator1, Me.MnuOpenTraspasoEntrada1, Me.Separator5, Me.MnuCargarOrdenCompra1, Me.Separator4, Me.menuAplicar1, Me.Separator2, Me.menuResguardo1, Me.Separator6, Me.menuImprimir1, Me.Separator3, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(497, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuNuevo1
        '
        Me.menuNuevo1.Key = "menuNuevo"
        Me.menuNuevo1.Name = "menuNuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'MnuOpenTraspasoEntrada1
        '
        Me.MnuOpenTraspasoEntrada1.Image = CType(resources.GetObject("MnuOpenTraspasoEntrada1.Image"), System.Drawing.Image)
        Me.MnuOpenTraspasoEntrada1.Key = "MnuOpenTraspasoEntrada"
        Me.MnuOpenTraspasoEntrada1.Name = "MnuOpenTraspasoEntrada1"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'MnuCargarOrdenCompra1
        '
        Me.MnuCargarOrdenCompra1.Image = CType(resources.GetObject("MnuCargarOrdenCompra1.Image"), System.Drawing.Image)
        Me.MnuCargarOrdenCompra1.Key = "MnuCargarOrdenCompra"
        Me.MnuCargarOrdenCompra1.Name = "MnuCargarOrdenCompra1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuAplicar1
        '
        Me.menuAplicar1.Key = "menuAplicar"
        Me.menuAplicar1.Name = "menuAplicar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuResguardo1
        '
        Me.menuResguardo1.Icon = CType(resources.GetObject("menuResguardo1.Icon"), System.Drawing.Icon)
        Me.menuResguardo1.Key = "menuResguardo"
        Me.menuResguardo1.Name = "menuResguardo1"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuImprimir1
        '
        Me.menuImprimir1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuImprimir1.Key = "menuImprimir"
        Me.menuImprimir1.Name = "menuImprimir1"
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
        'menuNuevo
        '
        Me.menuNuevo.Icon = CType(resources.GetObject("menuNuevo.Icon"), System.Drawing.Icon)
        Me.menuNuevo.Key = "menuNuevo"
        Me.menuNuevo.Name = "menuNuevo"
        Me.menuNuevo.Text = "Nuevo"
        '
        'menuAplicar
        '
        Me.menuAplicar.Image = CType(resources.GetObject("menuAplicar.Image"), System.Drawing.Image)
        Me.menuAplicar.Key = "menuAplicar"
        Me.menuAplicar.Name = "menuAplicar"
        Me.menuAplicar.Text = "Aplicar"
        '
        'menuImprimir
        '
        Me.menuImprimir.Image = CType(resources.GetObject("menuImprimir.Image"), System.Drawing.Image)
        Me.menuImprimir.Key = "menuImprimir"
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Text = "Imprimir"
        '
        'menuSalir
        '
        Me.menuSalir.Icon = CType(resources.GetObject("menuSalir.Icon"), System.Drawing.Icon)
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
        '
        'MnuCargarOrdenCompra
        '
        Me.MnuCargarOrdenCompra.Key = "MnuCargarOrdenCompra"
        Me.MnuCargarOrdenCompra.Name = "MnuCargarOrdenCompra"
        Me.MnuCargarOrdenCompra.Text = "Orden"
        '
        'MnuOpenTraspasoEntrada
        '
        Me.MnuOpenTraspasoEntrada.Key = "MnuOpenTraspasoEntrada"
        Me.MnuOpenTraspasoEntrada.Name = "MnuOpenTraspasoEntrada"
        Me.MnuOpenTraspasoEntrada.Text = "Abrir"
        '
        'menuResguardo
        '
        Me.menuResguardo.Key = "menuResguardo"
        Me.menuResguardo.Name = "menuResguardo"
        Me.menuResguardo.Text = "Resguardo"
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
        Me.TopRebar1.Size = New System.Drawing.Size(840, 28)
        '
        'frmRecepcionMercanciaTiendas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(840, 582)
        Me.Controls.Add(Me.ExplorerBar4)
        Me.Controls.Add(Me.ExplorerBar3)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRecepcionMercanciaTiendas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recepción de Mercancía en Tiendas de Proveedores"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar4.ResumeLayout(False)
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        CType(Me.GrdTraspasoCorrida, System.ComponentModel.ISupportInitialize).EndInit()
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

#Region "Declaracion de Variables"

    'Variables
    Private dsMaterialTalla As DataSet
    Private strline As String = ""
    Private boolManual As Boolean = False
    Private m_strFirmaConfig As SaveConfigArchivos
    Private strFolioTraspaso As String = ""
    Private dtTraspasoOriginalSAP As DataTable

    'Objetos
    Private oFrmMessage As frmMessages
    Private oAjusteMgr As AjusteGeneralManager
    Private oAjusteAJE As AjusteGeneralInfo
    Private oSapMgr As ProcesoSAPManager
    Private oTraspasoSMgr As TraspasosSalidaManager
    Private oArticulosMgr As CatalogoArticuloManager

    'Variables Miembros
    Private oTraspasoEntrada As TraspasoEntrada
    Private oTraspasoEntradaMgr As TraspasosEntradaManager

    Private odsCatalogoCorridas As DataSet
    Private dtTraspaso As New DataTable("TraspasoCorrida")
    Private UserSessionAplicated As String = String.Empty
    Private UserNameAplicated As String = String.Empty
    Private oCatalogoTransportistasMgr As CatalogoTransportistaManager
    Private oTransportista As Transportista

    Private CatalogoAlmacenMgr As CatalogoAlmacenesManager
    Private almacen As almacen

    Private ProcesoSapMgr As ProcesoSAPManager
    Private VendedorMgr As CatalogoVendedoresManager
    Private oVendedor As Vendedor


#End Region

#Region "Metodos"

    Private Sub Inicializar()

        'Objetos
        oAppContext.Security.CloseImpersonatedSession()
        Me.oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        Me.oTraspasoEntrada = New TraspasoEntrada(oTraspasoEntradaMgr)
        Me.oTraspasoSMgr = New TraspasosSalidaManager(oAppContext, oConfigCierreFI)
        Me.oArticulosMgr = New CatalogoArticuloManager(oAppContext)
        Me.odsCatalogoCorridas = oTraspasoEntradaMgr.ExtraerCatalogoCorridas
        Me.oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Me.oCatalogoTransportistasMgr = New CatalogoTransportistaManager(oAppContext)
        Me.CatalogoAlmacenMgr = New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        Me.ProcesoSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Me.VendedorMgr = New CatalogoVendedoresManager(oAppContext)
        Me.oVendedor = Me.VendedorMgr.Create()
        Me.VendedorMgr.LoadInto(oAppContext.Security.CurrentUser.ID, oVendedor)

        'AJE
        Me.oAjusteMgr = New AjusteGeneralManager(oAppContext, oConfigCierreFI)
        Me.oAjusteAJE = oAjusteMgr.Create("E")
        Me.oAjusteAJE.TipoAjuste = "E"
        Me.oAjusteAJE.Detalle.Columns("Cantidad").DefaultValue = 0
        Me.oAjusteAJE.Detalle.Columns("Talla").DefaultValue = String.Empty
        Me.oAjusteAJE.Detalle.Columns("FolioSAP").DefaultValue = String.Empty
        Me.oAjusteAJE.Detalle.Columns("Codigo").DefaultValue = String.Empty
        Me.oAjusteAJE.Detalle.Columns("descripcion").DefaultValue = String.Empty
        Me.oAjusteAJE.Detalle.Columns("importe").DefaultValue = 0
        Me.oAjusteAJE.Detalle.Columns("Total").Expression = "Cantidad * Importe"
        Me.oAjusteAJE.Detalle.AcceptChanges()

        Me.oTransportista = oCatalogoTransportistasMgr.Create()
        Me.oTransportista = oCatalogoTransportistasMgr.Load("006")

        Me.almacen = CatalogoAlmacenMgr.Create()
        CatalogoAlmacenMgr.LoadInto(oAppContext.ApplicationConfiguration.Almacen, almacen)

        Me.ebTransportistaCod.Text = Me.oTransportista.ID
        Me.ebTransportistaDesc.Text = Me.oTransportista.Nombre

        Me.ebSucOrigenCod.Text = "Z000"
        Me.ebSucOrigenDesc.Text = "Centro distribución"
        Me.ebSucDestinoCod.Text = oSapMgr.Read_Centros()
        Me.ebSucDestinoDesc.Text = almacen.Descripcion

        Me.ebFecha.Text = ProcesoSapMgr.MSS_GET_SY_DATE_TIME().ToString("dd/MM/yyyy")
        Me.ebResponsableDesc.Text = oAppContext.Security.CurrentUser.Name

    End Sub

    Private Sub Limpiar()

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
        ebNumBultos.Text = String.Empty
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
        Me.ebFolio.Focus()

        If oConfigCierreFI.RecibirParcialmente = False Then
            Me.ebFolio.ReadOnly = True
            Me.ebNoBulto.Visible = False
            Me.lblNoBulto.Visible = False
            Me.ebNumBultosRecibidos.Visible = False
        Else
            Me.ebFolio.ReadOnly = False
            Me.ebNoBulto.Visible = True
            Me.lblNoBulto.Visible = True
            Me.Label8.Visible = True
            Me.ebNumBultosRecibidos.Visible = True
        End If

        oTraspasoEntrada = Nothing
        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        oTraspasoEntrada = New TraspasoEntrada(oTraspasoEntradaMgr)
        odsCatalogoCorridas = oTraspasoEntradaMgr.ExtraerCatalogoCorridas

        Me.ebTransportistaCod.Text = Me.oTransportista.ID
        Me.ebTransportistaDesc.Text = Me.oTransportista.Nombre

        Me.ebSucOrigenCod.Text = "Z000"
        Me.ebSucOrigenDesc.Text = "Centro distribución"
        Me.ebSucDestinoCod.Text = oSapMgr.Read_Centros()
        Me.ebSucDestinoDesc.Text = almacen.Descripcion
        Me.VendedorMgr = New CatalogoVendedoresManager(oAppContext)
        Me.oVendedor = Me.VendedorMgr.Create()
        Me.VendedorMgr.LoadInto(oAppContext.Security.CurrentUser.ID, oVendedor)
        Me.ebResponsableDesc.Text = oAppContext.Security.CurrentUser.Name

        Me.ebFecha.Text = ProcesoSapMgr.MSS_GET_SY_DATE_TIME().ToString("dd/MM/yyyy")


        Me.UiCommandBar1.Commands("menuImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.False

    End Sub

    Private Sub CargarOrdenCompra()
        Dim orden As String = InputBox("Ingresa la orden de compra", "Dportenis PRO")
        If orden <> "" Then
            dtTraspaso = oSapMgr.ZMM_ORDENCOMPRA_DETALLE(orden)
            If dtTraspaso.Rows.Count > 0 Then
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 28/07/2015: Asignamos valores al traspaso de entrada
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                dtTraspaso.Columns.Add("Lecturado", GetType(Integer))
                For Each row As DataRow In dtTraspaso.Rows
                    row("Lecturado") = 0
                    row.AcceptChanges()
                Next
                dtTraspaso.AcceptChanges()
                oTraspasoEntrada = Nothing
                oTraspasoEntrada = New TraspasoEntrada(oTraspasoEntradaMgr)
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                oTraspasoEntrada.Detalle = New DataSet
                GrdTraspasoCorrida.DataSource = dtTraspaso
                oTraspasoEntrada.Status = "TRA"
                GrdTraspasoCorrida.Focus()
                MostrarTraspasoInformacion()
                Dim dtDetalle As DataTable = CrearDetalleTraspasoEntrada(dtTraspaso)
                oTraspasoEntrada.Detalle.Tables.Add(dtDetalle)
            Else
                MessageBox.Show("El traspaso no existe o no está pendiente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Limpiar()
            End If

        End If
    End Sub

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
            ArticuloMgr.LoadInto(CStr(row("MATNR")), articulo)
            fila = dtDetalle.NewRow()
            fila("Codigo") = CStr(row("MATNR"))
            fila("TALLA") = CStr(row("J_3ASIZE"))
            fila("Cantidad") = CInt(row("QUANTITY"))
            fila("Bulto") = CInt(Me.ebNoBulto.Value)
            fila("Descripcion") = articulo.Descripcion
            dtDetalle.Rows.Add(fila)
        Next
        dtDetalle.AcceptChanges()
        Return dtDetalle
    End Function

    '------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 28/07/2015: Muestra la información del traspaso
    '------------------------------------------------------------------------------------------------------------------------------
    Private Sub MostrarTraspasoInformacion()
        Try

            With oTraspasoEntrada

                Dim oRow As DataRow

                oRow = dtTraspaso.Rows(0)

                .Folio = oRow("EBELN")
                .FolioSAP = oRow("EBELN")
                Dim strFecha As String = CStr(oRow("AEDAT"))
                Dim fecha As DateTime = New DateTime(strFecha.Substring(0, 4), strFecha.Substring(4, 2), strFecha.Substring(6, 2))
                .TraspasoCreadoEl = fecha
                .TraspasoRecibidoEl = Format(fecha, "Short Date")

                Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim strCentroOrig(2) As String
                Dim strCentroDest(2) As String

                Me.ebSucOrigenCod.Text = "Z000"
                Me.ebSucOrigenDesc.Text = "Centro distribución"

                .AlmacenOrigenID = "Z000"
                CatalogoAlmacenMgr.LoadInto(oAppContext.ApplicationConfiguration.Almacen, almacen)
                ebSucDestinoCod.Text = oSap.Read_Centros()     'Codigo
                ebSucDestinoDesc.Text = almacen.Descripcion   'Nombre

                .AlmacenDestinoID = ebSucDestinoCod.Text

                ebFolio.Text = oRow("EBELN") '.Folio    '.TraspasoID
                ebFecha.Text = Format(fecha, "Short Date")  ' Format(.TraspasoCreadoEl, "Short Date")

                ebStatus.Text = .Status

                ebResponsableDesc.Text = oAppContext.Security.CurrentUser.Name
                .AutorizadoPorID = oAppContext.Security.CurrentUser.SessionLoginName

                ebFechaRecepcion.Text = Format(Date.Now, "Short Date")

                ebTotalPiezas.Text = Microsoft.VisualBasic.Fix(dtTraspaso.Compute("SUM(Quantity)", "Quantity > 0"))

                'ebTotalLecturado.Text = "0"
                Me.ebTotalLecturado.Text = Me.ebTotalPiezas.Text
                'If oConfigCierreFI.RecibirParcialmente Then
                '    Me.ebTotalLecturado.Text = Me.ebTotalPiezas.Text
                'End If
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Guia - Total Bultos - Paqueteria - Transportista
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                Me.ebNumGuia.Text = "1"
                'Me.ebNumGuia.Text = oSap.ReadInfoPaqueteria(ebFolio.Text, "F01")

                .Guia = Me.ebNumGuia.Text
                Me.ebNumBultos.Text = "1"
                ebNoBulto.Text = "1"
                ebNumBultosRecibidos.Text = "1"
                Me.ebTransportistaDesc.Text = oTransportista.Nombre
                'Me.ebTransportistaDesc.Text = oSap.ReadInfoPaqueteria(ebFolio.Text, "F03")
                .TransportistaID = Me.ebTransportistaDesc.Text
                .TotalBultos = "1"
                Me.ebFolio.Enabled = False
                Me.GrdTraspasoCorrida.AllowEdit = InheritableBoolean.False
                Me.ebNumBultosRecibidos.Focus()

            End With

        Catch ex As Exception

            Throw New ApplicationException("[Sm_MostrarTraspasoInformacion]", ex)

        End Try

    End Sub

    Private Sub AplicarTraspasos()
        If ValidaCamposTraspaso(dtTraspaso) = False Then
            Exit Sub
        End If
        Dim dtSobrante As DataTable = Nothing, dtFaltante As DataTable = Nothing
        dtSobrante = ValidaSobrantes(dtTraspaso)
        dtFaltante = ValidaFaltantes(dtTraspaso)

        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 28/07/2015: Aplicamos traspaso en SAP
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Cursor.Current = Cursors.WaitCursor
        Dim DocYear As String = "", err As String = ""
        ebReferencia.Text = ProcesoSapMgr.ZMM_ENTREGA_TIENDA(Me.ebFolio.Text.Trim(), ebSucOrigenCod.Text.Trim(), ebSucDestinoCod.Text, dtTraspaso, DocYear, err)
        If err <> "" Then
            MessageBox.Show(err, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        oTraspasoEntrada.Referencia = Me.ebReferencia.Text.Trim
        oTraspasoEntrada.AutorizadoPorID = UserSessionAplicated
        Cursor.Current = Cursors.Default

        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 28/07/2015: Aplico el Traspaso de entrada en las bases locales
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoEntrada.TraspasoRecibidoEl = Now.ToShortDateString
        If (oTraspasoEntradaMgr.AplicarEntrada(oTraspasoEntrada, UserSessionAplicated, UserNameAplicated) = True) Then
            With oTraspasoEntrada
                ebFechaRecepcion.Text = Format(.TraspasoRecibidoEl, "Short Date")
                ebReferencia.Text = .Referencia
                .Status = "GRA"
                ebStatus.Text = .Status
                ebResponsableDesc.Text = .AutorizadoPorID
            End With
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 28/07/2015: Guardamos el traspaso en el Servidor si esta activada la config
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Try
                oTraspasoEntradaMgr.AplicarTraspasoEntradaInServer(oTraspasoEntrada, UserSessionAplicated, UserNameAplicated)
                PrintComprobanteTraspaso()
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 29/07/2015: Guardamos los resguardos sobrantes y faltantes en caso de que haya
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If dtSobrante.Rows.Count > 0 Then
                    oTraspasoEntradaMgr.InsertarResguardo(ebSucOrigenCod.Text.Trim(), ebSucDestinoCod.Text.Trim(), dtSobrante)
                End If
                If dtFaltante.Rows.Count > 0 Then
                    oTraspasoEntradaMgr.InsertarResguardo(ebSucOrigenCod.Text.Trim(), ebSucDestinoCod.Text.Trim(), dtFaltante)
                End If
            Catch ex As Exception
                EscribeLog(ex.ToString, "Error al guardar traspaso de entrada en el servidor.")
            End Try
            MsgBox("El Traspaso ha sido Aplicado satisfactoriamente.", MsgBoxStyle.Information, "DPTienda.")
            Limpiar()
        Else
            Cursor.Current = Cursors.Default
            MsgBox("El Traspaso no pudo ser Aplicado.", MsgBoxStyle.Exclamation, "DPTienda.")
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
        ElseIf Me.ebNumBultosRecibidos.Text.Trim = "" OrElse Me.ebNumBultosRecibidos.Value <= 0 Then
            MessageBox.Show("Es necesario especificar el numero de bultos recibidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebNumBultosRecibidos.Focus()
            bRes = False
        ElseIf Me.ebNumBultos.Text.Trim = "" OrElse CInt(Me.ebNumBultos.Text) <= 0 Then
            MessageBox.Show("Es necesario indicarle el numero de bultos enviados al traspaso en SAP.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False

        ElseIf ValidaLecturados(Me.dtTraspaso) = False Then
            bRes = False
            MessageBox.Show("Todas las cantidades lecturadas deben ser mayores a cero", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        Else
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

    Private Function ValidaLecturados(ByVal dtTraspaso As DataTable) As Boolean
        Dim valido As Boolean = False
        For Each row As DataRow In dtTraspaso.Rows
            If row.IsNull("Lecturado") = False Then
                If CInt(row("Lecturado")) > 0 Then
                    valido = True
                End If
            Else
                valido = False
                Exit For
            End If
        Next
        Return valido
    End Function

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
            oArticulo = oArticulosMgr.Load(CStr(odrArticulo("MATNR")))
            If oArticulo Is Nothing Then

                frmDescargas.bPorCodigo = True
                frmDescargas.bMostrarMensaje = False

                dtCod.Clear()
                AgregarCodigo(CStr(odrArticulo("MATNR")).Trim, dtCod)
                frmDescargas.dtMateriales = dtCod

                frmDescargas.ShowDev("Articulos")

                oArticulo = Nothing
                oArticulo = oArticulosMgr.Load(CStr(odrArticulo("MATNR")))
                If Not oArticulo Is Nothing Then
                    frmDescargas.ShowDev("Descuentos")
                    frmDescargas.ShowDev("Inventarios")
                Else
                    strMateriales = CStr(odrArticulo("MATNR")) & vbCrLf
                End If

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

    Private Function ValidaSobrantes(ByVal dtTraspaso As DataTable) As DataTable
        Dim dtSobrante As DataTable = dtTraspaso.Clone()
        dtSobrante.Columns.Add("Tipo", GetType(String))
        dtSobrante.Columns.Add("FechaAlta", GetType(DateTime))
        Dim dtMateriales As DataTable = dtTraspaso.Copy()
        dtMateriales.Columns.Add("Tipo", GetType(String))
        dtMateriales.Columns.Add("FechaAlta", GetType(DateTime))
        Dim fechaAlta As DateTime = ProcesoSapMgr.MSS_GET_SY_DATE_TIME()
        Dim lecturado As Integer, cantidad As Integer
        For Each row As DataRow In dtMateriales.Rows
            cantidad = CInt(row("QUANTITY"))
            lecturado = CInt(row("Lecturado"))
            If lecturado > cantidad Then
                row("QUANTITY") = lecturado - cantidad
                row("Tipo") = "S"
                row("FechaAlta") = fechaAlta
                dtSobrante.ImportRow(row)
            End If
        Next
        Return dtSobrante
    End Function

    Private Function ValidaFaltantes(ByVal dtTraspaso As DataTable) As DataTable
        Dim dtFaltante As DataTable = dtTraspaso.Clone()
        dtFaltante.Columns.Add("Tipo", GetType(String))
        dtFaltante.Columns.Add("FechaAlta", GetType(DateTime))
        Dim dtMateriales As DataTable = dtTraspaso.Copy()
        dtMateriales.Columns.Add("Tipo", GetType(String))
        dtMateriales.Columns.Add("FechaAlta", GetType(DateTime))
        Dim fechaAlta As DateTime = ProcesoSapMgr.MSS_GET_SY_DATE_TIME()
        Dim lecturado As Integer, cantidad As Integer
        For Each row As DataRow In dtMateriales.Rows
            cantidad = CInt(row("QUANTITY"))
            lecturado = CInt(row("Lecturado"))
            If lecturado < cantidad Then
                row("QUANTITY") = cantidad - lecturado
                row("Tipo") = "F"
                row("FechaAlta") = fechaAlta
                dtFaltante.ImportRow(row)
            End If
        Next
        Return dtFaltante
    End Function

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

    Private Sub AbrirTraspaso()

        Dim oOpenRecordDlg As New OpenRecordDialog


        oOpenRecordDlg.CurrentView = New TraspasoEntradaOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oTraspasoEntrada = Nothing
            oTraspasoEntrada = oTraspasoEntradaMgr.Load(oOpenRecordDlg.Record.Item("idTraspaso"))

            Me.Sm_MostrarTraspasoInformacionFromGrabado()
            Me.UiCommandBar1.Commands("menuImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.True
        End If


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
                    If InStr("Z001,Z000", strCentroOrigen.Trim.ToUpper) > 0 Then
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
                ebNumBultos.Text = .TotalBultos
                ebNumBultosRecibidos.Value = .TotalBultos
                ebTransportistaDesc.Text = .TransportistaID
                dtTraspaso = EstructuraTraspaso(.Detalle.Tables(0))
                ebTotalPiezas.Text = Microsoft.VisualBasic.Fix(dtTraspaso.Compute("SUM(QUANTITY)", "QUANTITY > 0"))
                Me.GrdTraspasoCorrida.DataSource = dtTraspaso
                'Me.GrdTraspasoCorrida.RetrieveStructure()
                Me.ebReferencia.Text = Me.dtTraspaso.Rows(0).Item("EBELN")
                Me.ebNumBultosRecibidos.ReadOnly = True
                Me.ebNumBultosRecibidos.BackColor = Color.Ivory

            End With

        Catch ex As Exception

            Throw New ApplicationException("[Sm_MostrarTraspasoInformacionFromGrabado] ", ex)

        End Try

    End Sub

    Private Function EstructuraTraspaso(ByVal traspaso As DataTable) As DataTable
        Dim dtTraspasar As New DataTable
        Dim fila As DataRow = Nothing
        dtTraspasar.Columns.Add("EBELN", GetType(String))
        dtTraspasar.Columns.Add("EBELP", GetType(String))
        dtTraspasar.Columns.Add("ERNAM", GetType(String))
        dtTraspasar.Columns.Add("ETENR", GetType(String))
        dtTraspasar.Columns.Add("MATNR", GetType(String))
        dtTraspasar.Columns.Add("J_3ASIZE", GetType(String))
        dtTraspasar.Columns.Add("QUANTITY", GetType(Integer))
        dtTraspasar.Columns.Add("Lecturado", GetType(Integer))
        Dim autoriza As String = ""
        For Each row As DataRow In traspaso.Rows
            fila = dtTraspasar.NewRow()
            fila("EBELN") = CStr(row("FolioSAPMB01"))
            fila("MATNR") = CStr(row("Codigo"))
            fila("J_3ASIZE") = CStr(row("talla"))
            fila("QUANTITY") = CInt(row("Cantidad"))
            fila("Lecturado") = CInt(row("Cantidad"))
            autoriza = CStr(row("Autoriza"))
            fila("ERNAM") = autoriza
            dtTraspasar.Rows.Add(fila)
        Next
        Return dtTraspasar
    End Function

    '------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA 04/08/2015: Muestra la información de materiales en resguardo
    '------------------------------------------------------------------------------------------------------------------------------
    Private Sub MostrarResguardo()

        Dim oFrmResguardo As New frmResguardoEMT
        oFrmResguardo.ShowDialog()
        oFrmResguardo.Dispose()

    End Sub

#End Region

#Region "Eventos"

    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key
            Case "menuNuevo"
                Limpiar()
            Case "MnuOpenTraspasoEntrada"
                AbrirTraspaso()
            Case "MnuCargarOrdenCompra"
                CargarOrdenCompra()
            Case "menuAplicar"
                AplicarTraspasos()
            Case "menuResguardo"
                MostrarResguardo()
            Case "menuImprimir"
                PrintComprobanteTraspaso()
            Case "menuSalir"
                Me.Dispose()
        End Select
    End Sub

    Private Sub GrdTraspasoCorrida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdTraspasoCorrida.KeyDown
        Dim strCodArticulo, strNumero, strDescripcion As String
        If e.KeyCode = Keys.Enter And GrdTraspasoCorrida.Col <> 11 Then
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
            strNumero = FormatTalla(strNumero)
            Dim oDataView As New DataView(dtTraspaso, "MATNR ='" & strCodArticulo & "' and " & _
                    "J_3ASIZE='" & strNumero & "' ", "MATNR", DataViewRowState.CurrentRows)

            If oDataView.Count > 0 Then
                For Each oDataRowViewF As DataRowView In oDataView
                    'If oDataRowViewF.Row.Item("Lecturado") < oDataRowViewF.Row.Item("Cantidad") Then
                    oDataRowViewF.Row.Item("Lecturado") += 1
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
                    .Item("MATNR") = strCodArticulo
                    '.Item("Descripcion") = strDescripcion
                    .Item("J_3ASIZE") = strNumero
                    .Item("QUANTITY") = 0
                    .Item("Lecturado") = 1
                    '.Item("Agregado") = 1
                    '.Item("Origen") = Me.ebSucOrigenCod.Text
                    '.Item("Destino") = Me.ebSucDestinoCod.Text
                    .Item("AEDAT") = Date.Today.ToShortDateString
                End With
                dtTraspaso.Rows.Add(oRow)
                dtTraspaso.AcceptChanges()

                Me.ebTotalLecturado.Text = CStr(dtTraspaso.Compute("SUM(Lecturado)", "Lecturado > 0"))

                'MsgBox("El código UPC no se encontró en el detalle del traslado.", MsgBoxStyle.Information, Me.Text)
                Me.GrdTraspasoCorrida.Refresh()
                Me.GrdTraspasoCorrida.Select()

            End If
        ElseIf GrdTraspasoCorrida.Col <> 11 Then
            If e.KeyCode = 189 Then
                strline = strline & "-"
            Else
                strline = strline & Chr(e.KeyCode)
            End If
        End If
    End Sub

    Private Function FormatTalla(ByVal strNumber As String) As String
        If IsNumeric(strNumber) Then
            If InStr(strNumber, ".5", CompareMethod.Text) = 0 Then
                strNumber = strNumber & ".0"
            End If
        End If
        Return strNumber
    End Function

#End Region

    
    Private Sub frmRecepcionMercanciaTiendas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
