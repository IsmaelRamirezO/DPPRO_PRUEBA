
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTransportista
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoMonedaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports Janus.Windows.GridEX
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports System.Collections.Generic
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada

'Imports PrinterNET

Public Class frmInvAuditoria
    Inherits System.Windows.Forms.Form

    Private m_datdtMotivosGral As DataTable


#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        'dtMotivos
        m_datdtMotivosGral = Nothing
        m_datdtMotivosGral = New DataTable

        CreateDtMotivos()
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
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
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
    Friend WithEvents menuArchivoAplicar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ebSucOrigenDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucDestinoDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucOrigenCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebResponsable As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTransportistaDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTransportistaCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents GridTraspasoCorrida As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNumGuia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFechaRecepcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents uibtnCapturaDetalle As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebTotal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebStatus As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNumBulto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebMonedaCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMonedaDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents menuArchivoCerrar3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuHerramientas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents lblLabel5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents menuArchivoPendientes As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoPendientes1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoPendientes2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoReenviarTraspaso As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EdBxFolioSAP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ebFolioObs As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents LblFolio As System.Windows.Forms.Label
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebSucDestinoCod2 As Janus.Windows.GridEX.EditControls.EditBox
    Public WithEvents ebObservaciones As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents nebFolioConcen As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LblTCF As System.Windows.Forms.Label
    Friend WithEvents ebTraspasoCF As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucDestinoCod As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup4 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvAuditoria))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup6 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup5 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebTraspasoCF = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.LblTCF = New System.Windows.Forms.Label()
        Me.nebFolioConcen = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ebSucDestinoCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EdBxFolioSAP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ebMonedaDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebMonedaCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebResponsable = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ebTransportistaDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucOrigenDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucDestinoDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebTransportistaCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucOrigenCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucDestinoCod2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridTraspasoCorrida = New Janus.Windows.GridEX.GridEX()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuHerramientas1 = New Janus.Windows.UI.CommandBars.UICommand("menuHerramientas")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuArchivoCerrar3 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoCerrar")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoPendientes2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoPendientes")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.menuArchivoPendientes1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoPendientes")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
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
        Me.menuArchivoPendientes = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoPendientes")
        Me.menuArchivoReenviarTraspaso = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoReenviarTraspaso")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebNumBulto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFechaRecepcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNumGuia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebReferencia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ExplorerBar4 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebObservaciones = New Janus.Windows.EditControls.UIComboBox()
        Me.LblFolio = New System.Windows.Forms.Label()
        Me.ebFolioObs = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblLabel5 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.uibtnCapturaDetalle = New Janus.Windows.EditControls.UIButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ebTotal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ebStatus = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.GridTraspasoCorrida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ebTraspasoCF)
        Me.ExplorerBar1.Controls.Add(Me.LblTCF)
        Me.ExplorerBar1.Controls.Add(Me.nebFolioConcen)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        Me.ExplorerBar1.Controls.Add(Me.ebSucDestinoCod)
        Me.ExplorerBar1.Controls.Add(Me.EdBxFolioSAP)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.ebMonedaDesc)
        Me.ExplorerBar1.Controls.Add(Me.ebMonedaCod)
        Me.ExplorerBar1.Controls.Add(Me.ebFecha)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsable)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.ebFolio)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.ebTransportistaDesc)
        Me.ExplorerBar1.Controls.Add(Me.ebSucOrigenDesc)
        Me.ExplorerBar1.Controls.Add(Me.ebSucDestinoDesc)
        Me.ExplorerBar1.Controls.Add(Me.ebTransportistaCod)
        Me.ExplorerBar1.Controls.Add(Me.ebSucOrigenCod)
        Me.ExplorerBar1.Controls.Add(Me.ebSucDestinoCod2)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup4.Expandable = False
        ExplorerBarGroup4.Image = CType(resources.GetObject("ExplorerBarGroup4.Image"), System.Drawing.Image)
        ExplorerBarGroup4.Key = "Group1"
        ExplorerBarGroup4.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup4})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 48)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(592, 177)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebTraspasoCF
        '
        Me.ebTraspasoCF.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTraspasoCF.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTraspasoCF.BackColor = System.Drawing.Color.White
        Me.ebTraspasoCF.Location = New System.Drawing.Point(102, 151)
        Me.ebTraspasoCF.MaxLength = 10
        Me.ebTraspasoCF.Name = "ebTraspasoCF"
        Me.ebTraspasoCF.Size = New System.Drawing.Size(112, 23)
        Me.ebTraspasoCF.TabIndex = 34
        Me.ebTraspasoCF.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTraspasoCF.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'LblTCF
        '
        Me.LblTCF.BackColor = System.Drawing.Color.Transparent
        Me.LblTCF.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTCF.Location = New System.Drawing.Point(14, 148)
        Me.LblTCF.Name = "LblTCF"
        Me.LblTCF.Size = New System.Drawing.Size(88, 32)
        Me.LblTCF.TabIndex = 33
        Me.LblTCF.Text = "Traspaso con faltante:"
        '
        'nebFolioConcen
        '
        Me.nebFolioConcen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebFolioConcen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebFolioConcen.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebFolioConcen.Location = New System.Drawing.Point(466, 124)
        Me.nebFolioConcen.Name = "nebFolioConcen"
        Me.nebFolioConcen.Size = New System.Drawing.Size(120, 23)
        Me.nebFolioConcen.TabIndex = 31
        Me.nebFolioConcen.Text = "0"
        Me.nebFolioConcen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebFolioConcen.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebFolioConcen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(377, 122)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 31)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "Folio de Concentración"
        '
        'ebSucDestinoCod
        '
        Me.ebSucDestinoCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoCod.BackColor = System.Drawing.Color.Ivory
        Me.ebSucDestinoCod.ButtonImage = CType(resources.GetObject("ebSucDestinoCod.ButtonImage"), System.Drawing.Image)
        Me.ebSucDestinoCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucDestinoCod.Location = New System.Drawing.Point(103, 43)
        Me.ebSucDestinoCod.Name = "ebSucDestinoCod"
        Me.ebSucDestinoCod.ReadOnly = True
        Me.ebSucDestinoCod.Size = New System.Drawing.Size(64, 22)
        Me.ebSucDestinoCod.TabIndex = 20
        Me.ebSucDestinoCod.TabStop = False
        Me.ebSucDestinoCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucDestinoCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EdBxFolioSAP
        '
        Me.EdBxFolioSAP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EdBxFolioSAP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EdBxFolioSAP.BackColor = System.Drawing.Color.Ivory
        Me.EdBxFolioSAP.Location = New System.Drawing.Point(466, 96)
        Me.EdBxFolioSAP.Name = "EdBxFolioSAP"
        Me.EdBxFolioSAP.ReadOnly = True
        Me.EdBxFolioSAP.Size = New System.Drawing.Size(120, 23)
        Me.EdBxFolioSAP.TabIndex = 18
        Me.EdBxFolioSAP.TabStop = False
        Me.EdBxFolioSAP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EdBxFolioSAP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(377, 99)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 14)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Folio SAP:"
        '
        'ebMonedaDesc
        '
        Me.ebMonedaDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMonedaDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMonedaDesc.BackColor = System.Drawing.Color.Ivory
        Me.ebMonedaDesc.Location = New System.Drawing.Point(506, 8)
        Me.ebMonedaDesc.Name = "ebMonedaDesc"
        Me.ebMonedaDesc.ReadOnly = True
        Me.ebMonedaDesc.Size = New System.Drawing.Size(64, 23)
        Me.ebMonedaDesc.TabIndex = 17
        Me.ebMonedaDesc.TabStop = False
        Me.ebMonedaDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMonedaDesc.Visible = False
        Me.ebMonedaDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMonedaCod
        '
        Me.ebMonedaCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMonedaCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMonedaCod.BackColor = System.Drawing.Color.White
        Me.ebMonedaCod.ButtonImage = CType(resources.GetObject("ebMonedaCod.ButtonImage"), System.Drawing.Image)
        Me.ebMonedaCod.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebMonedaCod.Enabled = False
        Me.ebMonedaCod.Location = New System.Drawing.Point(458, 8)
        Me.ebMonedaCod.MaxLength = 2
        Me.ebMonedaCod.Name = "ebMonedaCod"
        Me.ebMonedaCod.Size = New System.Drawing.Size(46, 23)
        Me.ebMonedaCod.TabIndex = 2
        Me.ebMonedaCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMonedaCod.Visible = False
        Me.ebMonedaCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.Color.Ivory
        Me.ebFecha.Location = New System.Drawing.Point(466, 69)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(120, 23)
        Me.ebFecha.TabIndex = 8
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebResponsable
        '
        Me.ebResponsable.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsable.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsable.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsable.Location = New System.Drawing.Point(102, 123)
        Me.ebResponsable.Name = "ebResponsable"
        Me.ebResponsable.ReadOnly = True
        Me.ebResponsable.Size = New System.Drawing.Size(269, 23)
        Me.ebResponsable.TabIndex = 6
        Me.ebResponsable.TabStop = False
        Me.ebResponsable.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(15, 126)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 23)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Responsable:"
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.BackColor = System.Drawing.Color.Ivory
        Me.ebFolio.Location = New System.Drawing.Point(466, 43)
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.ReadOnly = True
        Me.ebFolio.Size = New System.Drawing.Size(120, 23)
        Me.ebFolio.TabIndex = 7
        Me.ebFolio.TabStop = False
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(400, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 23)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Moneda:"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(377, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(377, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 14)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Folio:"
        '
        'ebTransportistaDesc
        '
        Me.ebTransportistaDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTransportistaDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTransportistaDesc.BackColor = System.Drawing.Color.Ivory
        Me.ebTransportistaDesc.Location = New System.Drawing.Point(170, 96)
        Me.ebTransportistaDesc.Name = "ebTransportistaDesc"
        Me.ebTransportistaDesc.ReadOnly = True
        Me.ebTransportistaDesc.Size = New System.Drawing.Size(200, 23)
        Me.ebTransportistaDesc.TabIndex = 5
        Me.ebTransportistaDesc.TabStop = False
        Me.ebTransportistaDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTransportistaDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucOrigenDesc
        '
        Me.ebSucOrigenDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenDesc.BackColor = System.Drawing.Color.Ivory
        Me.ebSucOrigenDesc.Location = New System.Drawing.Point(170, 69)
        Me.ebSucOrigenDesc.Name = "ebSucOrigenDesc"
        Me.ebSucOrigenDesc.ReadOnly = True
        Me.ebSucOrigenDesc.Size = New System.Drawing.Size(200, 23)
        Me.ebSucOrigenDesc.TabIndex = 3
        Me.ebSucOrigenDesc.TabStop = False
        Me.ebSucOrigenDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucOrigenDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucDestinoDesc
        '
        Me.ebSucDestinoDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoDesc.BackColor = System.Drawing.Color.Ivory
        Me.ebSucDestinoDesc.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucDestinoDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucDestinoDesc.Location = New System.Drawing.Point(170, 43)
        Me.ebSucDestinoDesc.Name = "ebSucDestinoDesc"
        Me.ebSucDestinoDesc.ReadOnly = True
        Me.ebSucDestinoDesc.Size = New System.Drawing.Size(200, 23)
        Me.ebSucDestinoDesc.TabIndex = 1
        Me.ebSucDestinoDesc.TabStop = False
        Me.ebSucDestinoDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucDestinoDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTransportistaCod
        '
        Me.ebTransportistaCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTransportistaCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTransportistaCod.ButtonImage = CType(resources.GetObject("ebTransportistaCod.ButtonImage"), System.Drawing.Image)
        Me.ebTransportistaCod.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebTransportistaCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTransportistaCod.Location = New System.Drawing.Point(103, 96)
        Me.ebTransportistaCod.MaxLength = 3
        Me.ebTransportistaCod.Name = "ebTransportistaCod"
        Me.ebTransportistaCod.Size = New System.Drawing.Size(64, 22)
        Me.ebTransportistaCod.TabIndex = 1
        Me.ebTransportistaCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTransportistaCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucOrigenCod
        '
        Me.ebSucOrigenCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucOrigenCod.BackColor = System.Drawing.Color.Ivory
        Me.ebSucOrigenCod.ButtonImage = CType(resources.GetObject("ebSucOrigenCod.ButtonImage"), System.Drawing.Image)
        Me.ebSucOrigenCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucOrigenCod.Location = New System.Drawing.Point(103, 69)
        Me.ebSucOrigenCod.Name = "ebSucOrigenCod"
        Me.ebSucOrigenCod.ReadOnly = True
        Me.ebSucOrigenCod.Size = New System.Drawing.Size(64, 22)
        Me.ebSucOrigenCod.TabIndex = 2
        Me.ebSucOrigenCod.TabStop = False
        Me.ebSucOrigenCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucOrigenCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucDestinoCod2
        '
        Me.ebSucDestinoCod2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoCod2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoCod2.ButtonImage = CType(resources.GetObject("ebSucDestinoCod2.ButtonImage"), System.Drawing.Image)
        Me.ebSucDestinoCod2.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebSucDestinoCod2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucDestinoCod2.Location = New System.Drawing.Point(320, 16)
        Me.ebSucDestinoCod2.MaxLength = 3
        Me.ebSucDestinoCod2.Name = "ebSucDestinoCod2"
        Me.ebSucDestinoCod2.Size = New System.Drawing.Size(64, 22)
        Me.ebSucDestinoCod2.TabIndex = 0
        Me.ebSucDestinoCod2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucDestinoCod2.Visible = False
        Me.ebSucDestinoCod2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Trasportista:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Origen:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Destino:"
        '
        'GridTraspasoCorrida
        '
        Me.GridTraspasoCorrida.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridTraspasoCorrida.BorderStyle = Janus.Windows.GridEX.BorderStyle.None
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.GridTraspasoCorrida.DesignTimeLayout = GridEXLayout2
        Me.GridTraspasoCorrida.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridTraspasoCorrida.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridTraspasoCorrida.GroupByBoxVisible = False
        Me.GridTraspasoCorrida.Location = New System.Drawing.Point(0, 229)
        Me.GridTraspasoCorrida.Name = "GridTraspasoCorrida"
        Me.GridTraspasoCorrida.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridTraspasoCorrida.Size = New System.Drawing.Size(840, 224)
        Me.GridTraspasoCorrida.TabIndex = 1
        Me.GridTraspasoCorrida.TabStop = False
        Me.GridTraspasoCorrida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuHerramientas, Me.menuAyuda, Me.menuArchivoNuevo, Me.menuArchivoAbrir, Me.menuArchivoCerrar, Me.menuArchivoGuardar, Me.menuArchivoEliminar, Me.menuArchivoImprimir, Me.menuAyudaTema, Me.menuArchivoAplicar, Me.menuArchivoPendientes, Me.menuArchivoReenviarTraspaso})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("c104218c-d8bb-4e4e-888f-0e0d12523cd2")
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
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuHerramientas1, Me.menuAyuda1, Me.menuArchivoCerrar3})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(832, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
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
        'menuArchivoCerrar3
        '
        Me.menuArchivoCerrar3.Key = "menuArchivoCerrar"
        Me.menuArchivoCerrar3.Name = "menuArchivoCerrar3"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.Separator1, Me.menuArchivoAbrir1, Me.Separator9, Me.menuArchivoPendientes2, Me.Separator10, Me.menuArchivoGuardar1, Me.Separator3, Me.menuArchivoImprimir1, Me.Separator4, Me.menuAyudaTema1})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(360, 28)
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
        'menuArchivoPendientes2
        '
        Me.menuArchivoPendientes2.Key = "menuArchivoPendientes"
        Me.menuArchivoPendientes2.Name = "menuArchivoPendientes2"
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'menuArchivoGuardar1
        '
        Me.menuArchivoGuardar1.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
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
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        Me.menuAyudaTema1.Text = "Ayuda"
        Me.menuAyudaTema1.ToolTipText = "Ay&uda"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.menuArchivoAbrir2, Me.menuArchivoPendientes1, Me.Separator5, Me.menuArchivoGuardar2, Me.Separator6, Me.menuArchivoImprimir2, Me.Separator7})
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
        'menuArchivoPendientes1
        '
        Me.menuArchivoPendientes1.Key = "menuArchivoPendientes"
        Me.menuArchivoPendientes1.Name = "menuArchivoPendientes1"
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
        Me.menuArchivoCerrar.Image = CType(resources.GetObject("menuArchivoCerrar.Image"), System.Drawing.Image)
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
        'menuArchivoPendientes
        '
        Me.menuArchivoPendientes.Image = CType(resources.GetObject("menuArchivoPendientes.Image"), System.Drawing.Image)
        Me.menuArchivoPendientes.Key = "menuArchivoPendientes"
        Me.menuArchivoPendientes.Name = "menuArchivoPendientes"
        Me.menuArchivoPendientes.Text = "Pendientes"
        Me.menuArchivoPendientes.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuArchivoReenviarTraspaso
        '
        Me.menuArchivoReenviarTraspaso.Image = CType(resources.GetObject("menuArchivoReenviarTraspaso.Image"), System.Drawing.Image)
        Me.menuArchivoReenviarTraspaso.Key = "menuArchivoReenviarTraspaso"
        Me.menuArchivoReenviarTraspaso.Name = "menuArchivoReenviarTraspaso"
        Me.menuArchivoReenviarTraspaso.Text = "Reenviar Traspaso"
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
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(832, 50)
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.ebNumBulto)
        Me.ExplorerBar2.Controls.Add(Me.ebFechaRecepcion)
        Me.ExplorerBar2.Controls.Add(Me.ebNumGuia)
        Me.ExplorerBar2.Controls.Add(Me.ebReferencia)
        Me.ExplorerBar2.Controls.Add(Me.Label10)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Controls.Add(Me.Label8)
        Me.ExplorerBar2.Controls.Add(Me.Label9)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup6.Expandable = False
        ExplorerBarGroup6.Image = CType(resources.GetObject("ExplorerBarGroup6.Image"), System.Drawing.Image)
        ExplorerBarGroup6.Key = "Group1"
        ExplorerBarGroup6.Text = "Recepción"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup6})
        Me.ExplorerBar2.Location = New System.Drawing.Point(592, 48)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(248, 392)
        Me.ExplorerBar2.TabIndex = 3
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebNumBulto
        '
        Me.ebNumBulto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumBulto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumBulto.Location = New System.Drawing.Point(126, 66)
        Me.ebNumBulto.MaxLength = 3
        Me.ebNumBulto.Name = "ebNumBulto"
        Me.ebNumBulto.Size = New System.Drawing.Size(112, 23)
        Me.ebNumBulto.TabIndex = 2
        Me.ebNumBulto.Text = "0"
        Me.ebNumBulto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumBulto.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebNumBulto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFechaRecepcion
        '
        Me.ebFechaRecepcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFechaRecepcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFechaRecepcion.BackColor = System.Drawing.Color.Ivory
        Me.ebFechaRecepcion.Location = New System.Drawing.Point(126, 120)
        Me.ebFechaRecepcion.Name = "ebFechaRecepcion"
        Me.ebFechaRecepcion.ReadOnly = True
        Me.ebFechaRecepcion.Size = New System.Drawing.Size(112, 23)
        Me.ebFechaRecepcion.TabIndex = 13
        Me.ebFechaRecepcion.TabStop = False
        Me.ebFechaRecepcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFechaRecepcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNumGuia
        '
        Me.ebNumGuia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumGuia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumGuia.BackColor = System.Drawing.Color.White
        Me.ebNumGuia.Location = New System.Drawing.Point(126, 93)
        Me.ebNumGuia.MaxLength = 15
        Me.ebNumGuia.Name = "ebNumGuia"
        Me.ebNumGuia.Size = New System.Drawing.Size(112, 23)
        Me.ebNumGuia.TabIndex = 3
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
        Me.ebReferencia.Location = New System.Drawing.Point(126, 39)
        Me.ebReferencia.Name = "ebReferencia"
        Me.ebReferencia.ReadOnly = True
        Me.ebReferencia.Size = New System.Drawing.Size(112, 23)
        Me.ebReferencia.TabIndex = 10
        Me.ebReferencia.TabStop = False
        Me.ebReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 121)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 23)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Fecha:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 23)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "# de Guia:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 23)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "# de Bulto:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 23)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Referencia:"
        '
        'ExplorerBar4
        '
        Me.ExplorerBar4.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar4.Controls.Add(Me.ebObservaciones)
        Me.ExplorerBar4.Controls.Add(Me.LblFolio)
        Me.ExplorerBar4.Controls.Add(Me.ebFolioObs)
        Me.ExplorerBar4.Controls.Add(Me.Label17)
        Me.ExplorerBar4.Controls.Add(Me.lblLabel5)
        Me.ExplorerBar4.Controls.Add(Me.lblLabel2)
        Me.ExplorerBar4.Controls.Add(Me.lblLabel1)
        Me.ExplorerBar4.Controls.Add(Me.lblLabel4)
        Me.ExplorerBar4.Controls.Add(Me.uibtnCapturaDetalle)
        Me.ExplorerBar4.Controls.Add(Me.Label11)
        Me.ExplorerBar4.Controls.Add(Me.ebTotal)
        Me.ExplorerBar4.Controls.Add(Me.Label19)
        Me.ExplorerBar4.Controls.Add(Me.PictureBox2)
        Me.ExplorerBar4.Controls.Add(Me.Label16)
        Me.ExplorerBar4.Controls.Add(Me.ebStatus)
        Me.ExplorerBar4.Controls.Add(Me.Label15)
        Me.ExplorerBar4.Controls.Add(Me.PictureBox1)
        Me.ExplorerBar4.Controls.Add(Me.Label14)
        Me.ExplorerBar4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup5.Expandable = False
        ExplorerBarGroup5.Image = CType(resources.GetObject("ExplorerBarGroup5.Image"), System.Drawing.Image)
        ExplorerBarGroup5.Key = "Group1"
        ExplorerBarGroup5.Text = "Datos Totales"
        Me.ExplorerBar4.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup5})
        Me.ExplorerBar4.Location = New System.Drawing.Point(0, 457)
        Me.ExplorerBar4.Name = "ExplorerBar4"
        Me.ExplorerBar4.Size = New System.Drawing.Size(840, 155)
        Me.ExplorerBar4.TabIndex = 5
        Me.ExplorerBar4.TabStop = False
        Me.ExplorerBar4.Text = "ExplorerBar4"
        Me.ExplorerBar4.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebObservaciones
        '
        Me.ebObservaciones.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebObservaciones.Location = New System.Drawing.Point(304, 78)
        Me.ebObservaciones.Name = "ebObservaciones"
        Me.ebObservaciones.Size = New System.Drawing.Size(216, 23)
        Me.ebObservaciones.TabIndex = 84
        Me.ebObservaciones.Text = "1"
        Me.ebObservaciones.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'LblFolio
        '
        Me.LblFolio.AutoSize = True
        Me.LblFolio.BackColor = System.Drawing.Color.Transparent
        Me.LblFolio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFolio.Location = New System.Drawing.Point(529, 83)
        Me.LblFolio.Name = "LblFolio"
        Me.LblFolio.Size = New System.Drawing.Size(120, 14)
        Me.LblFolio.TabIndex = 82
        Me.LblFolio.Text = "Folio Autorizacion:"
        Me.LblFolio.Visible = False
        '
        'ebFolioObs
        '
        Me.ebFolioObs.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioObs.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioObs.BackColor = System.Drawing.Color.White
        Me.ebFolioObs.Location = New System.Drawing.Point(656, 80)
        Me.ebFolioObs.MaxLength = 9
        Me.ebFolioObs.Name = "ebFolioObs"
        Me.ebFolioObs.Size = New System.Drawing.Size(104, 23)
        Me.ebFolioObs.TabIndex = 1
        Me.ebFolioObs.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolioObs.Visible = False
        Me.ebFolioObs.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(200, 84)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 14)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "Observaciones:"
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel5.ForeColor = System.Drawing.Color.Black
        Me.lblLabel5.Location = New System.Drawing.Point(176, 134)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(164, 16)
        Me.lblLabel5.TabIndex = 80
        Me.lblLabel5.Text = "Guardar e Imprimir"
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.ForeColor = System.Drawing.Color.Black
        Me.lblLabel2.Location = New System.Drawing.Point(32, 134)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(84, 16)
        Me.lblLabel2.TabIndex = 79
        Me.lblLabel2.Text = "Guardar"
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.ForeColor = System.Drawing.Color.Red
        Me.lblLabel1.Location = New System.Drawing.Point(152, 134)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel1.TabIndex = 78
        Me.lblLabel1.Text = "F9"
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.ForeColor = System.Drawing.Color.Red
        Me.lblLabel4.Location = New System.Drawing.Point(8, 134)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel4.TabIndex = 77
        Me.lblLabel4.Text = "F2"
        '
        'uibtnCapturaDetalle
        '
        Me.uibtnCapturaDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnCapturaDetalle.Image = CType(resources.GetObject("uibtnCapturaDetalle.Image"), System.Drawing.Image)
        Me.uibtnCapturaDetalle.Location = New System.Drawing.Point(24, 80)
        Me.uibtnCapturaDetalle.Name = "uibtnCapturaDetalle"
        Me.uibtnCapturaDetalle.Size = New System.Drawing.Size(152, 32)
        Me.uibtnCapturaDetalle.TabIndex = 0
        Me.uibtnCapturaDetalle.Text = "Captura de Detalle"
        Me.uibtnCapturaDetalle.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(24, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 23)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Captura Datos"
        '
        'ebTotal
        '
        Me.ebTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotal.BackColor = System.Drawing.Color.Ivory
        Me.ebTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotal.Location = New System.Drawing.Point(733, 40)
        Me.ebTotal.Name = "ebTotal"
        Me.ebTotal.ReadOnly = True
        Me.ebTotal.Size = New System.Drawing.Size(96, 22)
        Me.ebTotal.TabIndex = 18
        Me.ebTotal.TabStop = False
        Me.ebTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(693, 40)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "Total:"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(336, 40)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 27
        Me.PictureBox2.TabStop = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Location = New System.Drawing.Point(352, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 16)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Totales:"
        '
        'ebStatus
        '
        Me.ebStatus.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebStatus.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebStatus.BackColor = System.Drawing.Color.Ivory
        Me.ebStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebStatus.Location = New System.Drawing.Point(624, 40)
        Me.ebStatus.Name = "ebStatus"
        Me.ebStatus.ReadOnly = True
        Me.ebStatus.Size = New System.Drawing.Size(56, 22)
        Me.ebStatus.TabIndex = 15
        Me.ebStatus.TabStop = False
        Me.ebStatus.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebStatus.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(568, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 14)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Status:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(192, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 24)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(208, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 23)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Status"
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'frmInvAuditoria
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(832, 612)
        Me.Controls.Add(Me.GridTraspasoCorrida)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.ExplorerBar4)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(848, 650)
        Me.MinimumSize = New System.Drawing.Size(848, 650)
        Me.Name = "frmInvAuditoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traspaso de Salida por Reclamación Reporte de error"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.GridTraspasoCorrida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar4.ResumeLayout(False)
        Me.ExplorerBar4.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Variables Miembros"

    'Dim oPrinterNET As New ClsPrinter

    Private oTraspasoSalida As TraspasoSalida

    Private oTraspasoSalidaMgr As TraspasosSalidaManager

    Private oAlmacenDestino As Almacen

    Private oCatalogoAlmacenMgr As CatalogoAlmacenesManager

    Private oCatalogoTransportistasMgr As CatalogoTransportistaManager

    Private oTransportista As Transportista

    Private oCatalogoTipoMonedaMgr As CatalogoTipoMonedaManager

    Private oTipoMoneda As TipoMoneda

    Private odsCatalogoCorridas As DataSet

    'Ramiro Alcaraz Flores
    Private odtArticulosTras As New DataTable("Art")


    Private odsTraspasoCorrida As DataSet

    Private bolSalir As Boolean

    Private strResponsableID As String

    '------------------------------------------------------------------------------
    ' CVALLADOLID 20/10/2016: Modificación a la Transacción ZCONCENTRACIONES y RFC
    '------------------------------------------------------------------------------
    Private Const ALMACEN_DESTINO = "R000"

    Dim dtFoliosConcen As DataTable

#End Region


#Region "Métodos Privados"


    Private Sub Sm_TxtLimpiar()

        Dim AlmacenOrigen As Almacen


        On Error Resume Next


        'Limpiar Objetos : 

        oAlmacenDestino = Nothing
        oTransportista = Nothing
        oTipoMoneda = Nothing
        Dim oSapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        AlmacenOrigen = Nothing
        AlmacenOrigen = oCatalogoAlmacenMgr.Load(oSapMgr.Read_Centros())

        ebSucOrigenCod.Text = AlmacenOrigen.ID
        ebSucOrigenDesc.Text = AlmacenOrigen.Descripcion

        AlmacenOrigen = Nothing

        'ebSucDestinoCod.Text = String.Empty
        'ebSucDestinoDesc.Text = String.Empty
        ebTransportistaCod.Text = String.Empty
        ebTransportistaDesc.Text = String.Empty
        ebFolio.Text = String.Empty
        ebFecha.Text = String.Empty
        ebMonedaCod.Text = String.Empty
        ebMonedaDesc.Text = String.Empty
        ebReferencia.Text = String.Empty
        ebNumBulto.Text = String.Empty
        ebNumGuia.Text = String.Empty
        'ebResponsable.Text = String.Empty
        ebFechaRecepcion.Text = String.Empty
        ebStatus.Text = String.Empty
        EdBxFolioSAP.Text = String.Empty
        'ebSubTotal.Text = String.Empty
        'ebCargos.Text = String.Empty
        ebTotal.Text = String.Empty
        ebObservaciones.Text = String.Empty
        ebFolioObs.Text = String.Empty
        LblFolio.Visible = False
        ebFolioObs.Visible = False
        EdBxFolioSAP.Text = String.Empty
        ebTraspasoCF.Text = String.Empty

        odsTraspasoCorrida = Nothing
        GridTraspasoCorrida.DataSource = Nothing


        '--------------------------------------------------
        ' CVALLADOLID 20/10/2016: Folio de concentración
        '--------------------------------------------------
        Me.nebFolioConcen.Value = 0
        Me.nebFolioConcen.Enabled = True


        On Error Resume Next

        With GridTraspasoCorrida.Tables("TraspasoCorrida")

            .Columns("C01").Width = 30
            .Columns("C01").Caption = "C01"
            .Columns("C01").Visible = True

            .Columns("C02").Width = 30
            .Columns("C02").Caption = "C02"
            .Columns("C02").Visible = True

            .Columns("C03").Width = 30
            .Columns("C03").Caption = "C03"
            .Columns("C03").Visible = True

            .Columns("C04").Width = 30
            .Columns("C04").Caption = "C04"
            .Columns("C04").Visible = True

            .Columns("C05").Width = 30
            .Columns("C05").Caption = "C05"
            .Columns("C05").Visible = True

            .Columns("C06").Width = 30
            .Columns("C06").Caption = "C06"
            .Columns("C06").Visible = True

            .Columns("C07").Width = 30
            .Columns("C07").Caption = "C07"
            .Columns("C07").Visible = True

            .Columns("C08").Width = 30
            .Columns("C08").Caption = "C08"
            .Columns("C08").Visible = True

            .Columns("C09").Width = 30
            .Columns("C09").Caption = "C09"
            .Columns("C09").Visible = True

            .Columns("C10").Width = 30
            .Columns("C10").Caption = "C10"
            .Columns("C10").Visible = True

            .Columns("C11").Width = 30
            .Columns("C11").Caption = "C11"
            .Columns("C11").Visible = True

            .Columns("C12").Width = 30
            .Columns("C12").Caption = "C12"
            .Columns("C12").Visible = True

            .Columns("C13").Width = 30
            .Columns("C13").Caption = "C13"
            .Columns("C13").Visible = True

            .Columns("C14").Width = 30
            .Columns("C14").Caption = "C14"
            .Columns("C14").Visible = True

            .Columns("C15").Width = 30
            .Columns("C15").Caption = "C15"
            .Columns("C15").Visible = True

            .Columns("C16").Width = 30
            .Columns("C16").Caption = "C16"
            .Columns("C16").Visible = True

            .Columns("C17").Width = 30
            .Columns("C17").Caption = "C17"
            .Columns("C17").Visible = True

            .Columns("C18").Width = 30
            .Columns("C18").Caption = "C18"
            .Columns("C18").Visible = True

            .Columns("C19").Width = 30
            .Columns("C19").Caption = "C19"
            .Columns("C19").Visible = True

            .Columns("C20").Width = 30
            .Columns("C20").Caption = "C20"
            .Columns("C20").Visible = True

        End With
        Dim CatalogoTipoArticulo As New CatalogoArticuloManager(oAppContext)
        Dim dtDefectuoso As DataTable = CatalogoTipoArticulo.GetMotivosDefectuosos()
        ebObservaciones.DataSource = dtDefectuoso
        ebObservaciones.DisplayMember = "MotivoDefectuoso"
        ebObservaciones.ValueMember = "CodMotivoDefectuoso"
        ebObservaciones.Refresh()
        ebObservaciones.ReadOnly = False
        ebObservaciones.SelectedIndex = 0
        'ebObservaciones.Refresh()
        'ebObservaciones.SelectedIndex = 0
    End Sub



    Private Function Fm_bolTxtValidar() As Boolean

        'If (oAlmacenDestino Is Nothing) Then

        '    MsgBox("No ha sido seleccionado un Almácen Destino.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebSucDestinoCod.Focus()

        '    Exit Function
        'End If


        'If (oAlmacenDestino.ID = oAppContext.ApplicationConfiguration.Almacen) Then

        '    MsgBox("El Almácen Destino no es valido", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebSucDestinoCod.Focus()

        '    Exit Function

        'End If


        If (ebSucOrigenCod.Text = String.Empty) Or (ebResponsable.Text = String.Empty) Then
            MsgBox("Para Guardar un Traspaso vaya a la Opción Nuevo.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function
        End If


        If (ebSucOrigenCod.Text = ebSucDestinoCod.Text) Then
            MsgBox("El Almácen de Origen y Destino no pueden ser el mismo.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function
        End If


        If (oTransportista Is Nothing) Then
            MsgBox("No ha sido seleccionado un Transportista.", MsgBoxStyle.Exclamation, "DPTienda")
            ebTransportistaCod.Focus()
            Exit Function
        End If


        If (oTipoMoneda Is Nothing) Then
            MsgBox("No ha sido seleccionado un Tipo de Moneda.", MsgBoxStyle.Exclamation, "DPTienda")
            ebMonedaCod.Focus()
            Exit Function

        End If


        '--------------------------------------------------
        ' CVALLADOLID 20/10/2016: Folio de concentración
        '--------------------------------------------------
        If Me.nebFolioConcen.Value <= 0 Then
            MsgBox("Es necesario seleccionar el folio de la concentración solicitada.", MsgBoxStyle.Exclamation, "DPTienda")
            Me.nebFolioConcen.Focus()
            Exit Function
        End If

        ' Validar también que se encuentre dentro de los folios válidos
        If Not ValidaFolioConcen(nebFolioConcen.Value) Then
            MsgBox("El folio de concentración no esta activo.", MsgBoxStyle.Exclamation, "DPTienda")
            Me.nebFolioConcen.Focus()
            Exit Function
        End If


        If (IsNumeric(ebNumBulto.Text) = False) Then
            MsgBox("El Num. de Bultos no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
            ebNumBulto.Text = 0
            ebNumBulto.Focus()
            Exit Function
        ElseIf (ebNumBulto.Text <= 0) Then
            MsgBox("El Num. de Bultos no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
            ebNumBulto.Text = 0
            ebNumBulto.Focus()
            Exit Function
        End If


        If (ebNumGuia.Text.Trim = String.Empty) Then
            MsgBox("El Num. de Guia no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
            ebNumGuia.Focus()
            Exit Function
        End If


        If (ebObservaciones.Text.Trim = String.Empty) Then
            MsgBox("El Campo Observaciones es requerido.", MsgBoxStyle.Exclamation, "DPTienda")
            ebObservaciones.Focus()
            Exit Function
        End If

        If (Me.ebFolioObs.Text.Trim = String.Empty And Me.ebFolioObs.Visible) Then
            MsgBox("El Folio de Autorización no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
            ebFolioObs.Focus()
            Exit Function
        End If


        Dim dtTraspasoCorrida As DataTable

        dtTraspasoCorrida = CType(GridTraspasoCorrida.DataSource, DataTable)


        If (dtTraspasoCorrida Is Nothing) Then
            MsgBox("El Detalle del Traspaso no cuenta con Registros.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function
        End If


        If (dtTraspasoCorrida.Rows.Count = 0) Then
            MsgBox("El Detalle del Traspaso no cuenta con Registros.", MsgBoxStyle.Exclamation, "DPTienda")
            dtTraspasoCorrida = Nothing

            Exit Function
        End If

        dtTraspasoCorrida = Nothing



        Return True

    End Function



    Private Sub Sm_MostrarTraspasoInformacion()

        Dim oAlmacenLocal As Almacen


        With oTraspasoSalida

            '<Almacenes>

            'oAlmacenDestino = Nothing
            'oAlmacenDestino = oCatalogoAlmacenMgr.Load(.AlmacenDestinoID)

            'ebSucDestinoCod.Text = oAlmacenDestino.ID
            'ebSucDestinoDesc.Text = oAlmacenDestino.Descripcion

            On Error Resume Next

            oAlmacenLocal = Nothing
            oAlmacenLocal = oCatalogoAlmacenMgr.Load(.AlmacenOrigenID)

            ebSucOrigenCod.Text = oAlmacenLocal.ID
            ebSucOrigenDesc.Text = oAlmacenLocal.Descripcion

            '</Almacenes>


            '<Transportista>

            oTransportista = Nothing
            oTransportista = oCatalogoTransportistasMgr.Load(.TransportistaID)

            ebTransportistaCod.Text = oTransportista.ID
            ebTransportistaDesc.Text = oTransportista.Nombre

            '</Transportista>


            '<Tipo Moneda>

            oTipoMoneda = Nothing
            oTipoMoneda = oCatalogoTipoMonedaMgr.Load(.MonedaID)

            ebMonedaCod.Text = oTipoMoneda.ID
            ebMonedaDesc.Text = oTipoMoneda.Descripcion

            'ebMonedaCod.Text = .MonedaID

            '</Tipo Moneda>


            ebFolio.Text = .Folio    '.TraspasoID
            EdBxFolioSAP.Text = .FolioSAP
            ebFecha.Text = Format(.TraspasoCreadoEl, "Short Date")
            ebReferencia.Text = .Referencia
            ebNumBulto.Text = .TotalBultos
            ebNumGuia.Text = .Guia
            ebStatus.Text = .Status
            'ebSubTotal.Text = Format(.SubTotal, "Standard")
            'ebCargos.Text = Format(.SubTotal * oAppContext.ApplicationConfiguration.IVA, "Standard")

            'ebTotal.Text = Format(CType(ebSubTotal.Text, Decimal) + CType(ebCargos.Text, Decimal), "Currency")
            ebTotal.Text = Format(.SubTotal, "Currency")
            ebResponsable.Text = .AutorizadoPorID

            If (oTraspasoSalida.Status = "REC") Then
                ebFechaRecepcion.Text = Format(.TraspasoRecibidoEl, "Short Date")
            Else
                ebFechaRecepcion.Text = String.Empty
            End If

            'If .Observaciones.IndexOf("Impar") <> -1 Or .Observaciones.IndexOf("Dev. Error Trasp.") <> -1 Then
            '    Me.ebFolioObs.Visible = True
            '    Me.LblFolio.Visible = True
            '    If .Observaciones.IndexOf("Impar") <> -1 Then
            '        Me.ebObservaciones.Text = Mid(.Observaciones, 1, 5)
            '        Me.ebFolioObs.Text = Mid(.Observaciones, 6, .Observaciones.Length - 5)
            '    Else
            '        Me.ebObservaciones.Text = Mid(.Observaciones, 1, 17)
            '        Me.ebFolioObs.Text = Mid(.Observaciones, 18, .Observaciones.Length - 17)
            '    End If
            'Else
            ebObservaciones.Text = .Observaciones
            'End If



            'GridTraspasoCorrida.DataSource = .Detalle.Tables("TraspasoCorrida")
            odsTraspasoCorrida = .Detalle
            GridTraspasoCorrida.DataSource = odsTraspasoCorrida.Tables("TraspasoCorrida")
            'GridTraspasoCorrida.RetrieveStructure()

            ebTransportistaCod.Focus()

        End With

        'oAlmacen = Nothing
        'oCatalogoAlmacenMgr = Nothing

        'oTransportista = Nothing
        'oCatalogoTransportistaMgr = Nothing

    End Sub



    Private Sub Sm_CalcularTotales()

        Dim dtTraspasoCorrida As DataTable
        Dim drArticulo As DataRow
        Dim decSubTotal As Decimal

        dtTraspasoCorrida = CType(GridTraspasoCorrida.DataSource, DataTable)

        For Each drArticulo In dtTraspasoCorrida.Rows
            decSubTotal += CType(drArticulo("CostoTotal"), Decimal)
        Next

        'ebSubTotal.Text = Format(decSubTotal, "Standard")
        'ebCargos.Text = Format(decSubTotal * oAppContext.ApplicationConfiguration.IVA, "Standard")
        'ebTotal.Text = Format(decSubTotal + CType(ebCargos.Text, Decimal), "Currency")

        'ebTotal.Text = Format(CType(drArticulo("CostoTotal"), Decimal), "Standard")
        ebTotal.Text = Format(decSubTotal, "Standard")

    End Sub



    Public Sub SetupView()

        Dim odrFiltro() As DataRow

        Dim oCurrentRow As GridEXRow

        Dim odrDataRow As DataRowView



        On Error Resume Next

        oCurrentRow = GridTraspasoCorrida.GetRow()

        odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

        odrFiltro = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & odrDataRow.Item("CodCorrida") & "'")


        With GridTraspasoCorrida.Tables(0)

            .Columns("CodArticulo").Width = 100
            .Columns("CodArticulo").Caption = "Código"
            .Columns("CodArticulo").Visible = True

            .Columns("CodCorrida").Width = 45
            .Columns("CodCorrida").Caption = "Corrida"
            .Columns("CodCorrida").Visible = True

            .Columns("CostoUnit").Width = 60
            .Columns("CostoUnit").Caption = "CostoUnit"
            .Columns("CostoUnit").Visible = True
            .Columns("CostoUnit").FormatString = "###,###,###.##"

            .Columns("TraspasoID").Visible = False
            .Columns("CodUnidad").Visible = False
            .Columns("CodAlmacen").Visible = False

            .Columns("Folio").Visible = False

            .Columns("Descripcion").Caption = "Descripción"
            .Columns("Descripcion").Visible = True

            .Columns("Cantidad").Width = 50
            .Columns("Cantidad").Caption = "Cantidad"
            .Columns("Cantidad").Visible = True

            .Columns("CostoTotal").Width = 60
            .Columns("CostoTotal").Caption = "CostoTotal"
            .Columns("CostoTotal").Visible = True
            .Columns("CostoTotal").FormatString = "###,###,###.##"

            .Columns("C01").Width = 30
            .Columns("C01").Caption = odrFiltro(0).Item("C01")
            .Columns("C01").Visible = True

            .Columns("C02").Width = 30
            .Columns("C02").Caption = odrFiltro(0).Item("C02")
            .Columns("C02").Visible = True

            .Columns("C03").Width = 30
            .Columns("C03").Caption = odrFiltro(0).Item("C03")
            .Columns("C03").Visible = True

            .Columns("C04").Width = 30
            .Columns("C04").Caption = odrFiltro(0).Item("C04")
            .Columns("C04").Visible = True

            .Columns("C05").Width = 30
            .Columns("C05").Caption = odrFiltro(0).Item("C05")
            .Columns("C05").Visible = True

            .Columns("C06").Width = 30
            .Columns("C06").Caption = odrFiltro(0).Item("C06")
            .Columns("C06").Visible = True

            .Columns("C07").Width = 30
            .Columns("C07").Caption = odrFiltro(0).Item("C07")
            .Columns("C07").Visible = True

            .Columns("C08").Width = 30
            .Columns("C08").Caption = odrFiltro(0).Item("C08")
            .Columns("C08").Visible = True

            .Columns("C09").Width = 30
            .Columns("C09").Caption = odrFiltro(0).Item("C09")
            .Columns("C09").Visible = True

            .Columns("C10").Width = 30
            .Columns("C10").Caption = odrFiltro(0).Item("C10")
            .Columns("C10").Visible = True

            .Columns("C11").Width = 30
            .Columns("C11").Caption = odrFiltro(0).Item("C11")
            .Columns("C11").Visible = True

            .Columns("C12").Width = 30
            .Columns("C12").Caption = odrFiltro(0).Item("C12")
            .Columns("C12").Visible = True

            .Columns("C13").Width = 30
            .Columns("C13").Caption = odrFiltro(0).Item("C13")
            .Columns("C13").Visible = True

            .Columns("C14").Width = 30
            .Columns("C14").Caption = odrFiltro(0).Item("C14")
            .Columns("C14").Visible = True

            .Columns("C15").Width = 30
            .Columns("C15").Caption = odrFiltro(0).Item("C15")
            .Columns("C15").Visible = True

            .Columns("C16").Width = 30
            .Columns("C16").Caption = odrFiltro(0).Item("C16")
            .Columns("C16").Visible = True

            .Columns("C17").Width = 30
            .Columns("C17").Caption = odrFiltro(0).Item("C17")
            .Columns("C17").Visible = True

            .Columns("C18").Width = 30
            .Columns("C18").Caption = odrFiltro(0).Item("C18")
            .Columns("C18").Visible = True

            .Columns("C19").Width = 30
            .Columns("C19").Caption = odrFiltro(0).Item("C19")
            .Columns("C19").Visible = True

            .Columns("C20").Width = 30
            .Columns("C20").Caption = odrFiltro(0).Item("C20")
            .Columns("C20").Visible = True



            On Error Resume Next

            .Columns("NumInicio").Visible = False
            .Columns("NumFin").Visible = False
            .Columns("Salto").Visible = False
            .Columns("Tope").Visible = False


        End With

        oCurrentRow = Nothing
        odrDataRow = Nothing
        odrFiltro = Nothing

    End Sub



    Private Sub Sm_MostrarArticulosDefectuosos()

        With oTraspasoSalidaMgr

            'Crear y Llenar Tabla Temporal.
            .CrearTablaTmp()

            'Extraer Articulos Defectuosos.
            odsTraspasoCorrida = Nothing
            odsTraspasoCorrida = .SelectAllDefectuosos

            'Crear Tabla Temporal.
            Dim drRow As DataRow
            Dim oArticulo As Articulo
            Dim oCatalogoArticulosMgr As New CatalogoArticuloManager(oAppContext)
            For Each drRow In odsTraspasoCorrida.Tables(0).Rows
                oArticulo = Nothing
                oArticulo = oCatalogoArticulosMgr.Load(drRow!CodArticulo)
                oTraspasoSalidaMgr.AgregarArticulo(oArticulo, drRow!Talla, drRow!Cantidad, (oArticulo.CostoProm * drRow!Cantidad), 0)
            Next

            oArticulo = Nothing
            oCatalogoArticulosMgr = Nothing

            'Mostrar Detalle [Grid]. 
            odsTraspasoCorrida = Nothing
            odsTraspasoCorrida = oTraspasoSalidaMgr.GenerarTraspasoCorrida("[RefCruzTraspaso]")
            GridTraspasoCorrida.DataSource = odsTraspasoCorrida.Tables(0)

            Sm_CalcularTotales()

        End With

    End Sub



    Private Sub Sm_Nuevo()

        Sm_TxtLimpiar()

        oTraspasoSalidaMgr.CrearTablaTmp()

        oTraspasoSalida = Nothing

        ebMonedaCod.Text = "01"

        Sm_BuscarMoneda(False)

        ebTransportistaCod.Focus()

        '------------------------------------------------------------------------------
        ' CVALLADOLID 20/10/2016: Modificación a la Transacción ZCONCENTRACIONES y RFC
        '------------------------------------------------------------------------------
        GetFoliosConcentraciones()

    End Sub

    Private Function ProductosEnAclaracion(ByVal dtProductos As DataTable) As DataTable
        Dim strCentro As String = String.Empty
        Dim oParametros As New Dictionary(Of String, Object)
        Dim dtResult As DataTable
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        strCentro = oSAPMgr.Read_Centros


        'Obtener la información para ejecutar la RFC
        With oParametros
            ' ------------------------------------------------------------------
            ' Llenamos datos de los productos
            '------------------------------------------------------------------
            Dim oArticulos As New List(Of Dictionary(Of String, Object))

            For Each oRow As DataRow In dtProductos.Rows

                Dim oArt As New Dictionary(Of String, Object)

                With oArt
                    .Add("WERKS", strCentro)
                    .Add("MATNR", oRow("CodArticulo"))

                End With
                oArticulos.Add(oArt)
            Next

            '------------------------------------------------------------------
            ' Metemos los datos de los articulos para serializarlo a JSON
            '------------------------------------------------------------------
            .Add("SapPiCenmat", oArticulos)
        End With


        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRetail As New ProcesosRetail("/pos_api/s1", "POST")
        dtResult = oRetail.SapZFmProducAclaracion(oParametros)

        Return dtResult

    End Function

    Public Function ObtenerProductoAclaracion(ByVal dtProductos As DataTable) As DataTable
        Dim dtArticulos As DataTable = GetProductosAclaracion()
        Dim oFacturaMgr As FacturaManager
        Dim dtResult As DataTable

        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)

        For Each oRow As DataRow In dtProductos.Rows
            dtResult = oFacturaMgr.GetArtAclaracion(oRow("CodArticulo"))
            If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
                dtArticulos.ImportRow(dtResult.Rows(0))
            End If
        Next

        Return dtArticulos
    End Function

    Public Function ValidarAclaracionLocal(ByVal dtArticuloLibre As DataTable) As Boolean
        Dim dtAclaracion As DataTable
        Dim bRes As Boolean = True
        Dim dtProductos As DataTable = CreateMaterialEnAclaracion()


        If dtArticuloLibre.Columns.Contains("Codigo") Then
            dtArticuloLibre.Columns("Codigo").ColumnName = "CodArticulo"
        End If


        dtAclaracion = ObtenerProductoAclaracion(dtArticuloLibre)

        If Not dtAclaracion Is Nothing AndAlso dtAclaracion.Rows.Count > 0 Then
            For Each oRow As DataRow In dtArticuloLibre.Rows
                ' Obtener el total de artículos en aclaración
                Dim reserva = Convert.ToInt32(dtAclaracion.Compute("SUM(Cantidad)", "CodArticulo = '" & oRow!CodArticulo & "'"))
                Dim libres As Integer = oRow!Libres
                Dim cantidad = oRow!Cantidad  'Cantidad de artículos solicitados
                If reserva > 0 Then
                    If cantidad > reserva Then
                        ' El artículo supera la cantidad en reserva
                        Dim fila As DataRow = dtProductos.NewRow()
                        fila("CodArticulo") = oRow!CodArticulo
                        fila("Libres") = libres
                        fila("Solicitados") = cantidad
                        fila("EnReserva") = reserva
                        dtProductos.Rows.Add(fila)
                    End If
                Else
                    ' El artículo solicitado no se encuentra en reserva
                    Dim fila As DataRow = dtProductos.NewRow()
                    fila("CodArticulo") = oRow!CodArticulo
                    fila("Libres") = libres
                    fila("Solicitados") = cantidad
                    fila("EnReserva") = reserva
                    dtProductos.Rows.Add(fila)
                End If

            Next
        Else
            For Each oRow As DataRow In dtArticuloLibre.Rows
                Dim reserva As Integer = 0
                Dim libres As Integer = oRow!Libres
                Dim cantidad = oRow!Cantidad

                Dim fila As DataRow = dtProductos.NewRow()
                fila("CodArticulo") = oRow!CodArticulo
                fila("Libres") = libres
                fila("Solicitados") = cantidad
                fila("EnReserva") = reserva
                dtProductos.Rows.Add(fila)
            Next
        End If

        If Not dtProductos Is Nothing AndAlso dtProductos.Rows.Count > 0 Then
            ShowFormMessage(dtProductos, "Los siguientes artículos no se encuentran en Aclaración", GetAtributosMaterialEnAclaracion())
            bRes = False
        End If



        Return bRes
    End Function



    Public Function ValidarAclaracion(ByVal dtAclaracion As DataTable, ByVal dtArticuloLibre As DataTable) As Boolean
        Dim bRes As Boolean = True
        Dim dtProductos As DataTable = CreateMaterialEnAclaracion()


        If Not dtAclaracion Is Nothing AndAlso dtAclaracion.Rows.Count > 0 Then

            For Each oRow As DataRow In dtArticuloLibre.Rows
                ' Obtener el total de artículos en aclaración
                Dim reserva = Convert.ToInt32(dtAclaracion.Compute("SUM(Cantidad)", "MATNR = '" & oRow!CodArticulo & "' And TIPO_RESERVA = 'Aclaracion'"))
                Dim libres As Integer = oRow!Libres
                Dim cantidad = oRow!Cantidad  'Cantidad de artículos solicitados
                If reserva > 0 Then
                    If cantidad > reserva Then
                        ' El artículo supera la cantidad en reserva
                        Dim fila As DataRow = dtProductos.NewRow()
                        fila("CodArticulo") = oRow!CodArticulo
                        fila("Libres") = libres
                        fila("Solicitados") = cantidad
                        fila("EnReserva") = reserva
                        dtProductos.Rows.Add(fila)
                    End If
                Else
                    ' El artículo solicitado no se encuentra en reserva
                    Dim fila As DataRow = dtProductos.NewRow()
                    fila("CodArticulo") = oRow!CodArticulo
                    fila("Libres") = libres
                    fila("Solicitados") = cantidad
                    fila("EnReserva") = reserva
                    dtProductos.Rows.Add(fila)
                End If

            Next
        Else
            For Each oRow As DataRow In dtArticuloLibre.Rows
                Dim reserva As Integer = 0
                Dim libres As Integer = oRow!Libres
                Dim cantidad = oRow!Cantidad

                Dim fila As DataRow = dtProductos.NewRow()
                fila("CodArticulo") = oRow!CodArticulo
                fila("Libres") = libres
                fila("Solicitados") = cantidad
                fila("EnReserva") = reserva
                dtProductos.Rows.Add(fila)

            Next

        End If


        If Not dtProductos Is Nothing AndAlso dtProductos.Rows.Count > 0 Then
            ShowFormMessage(dtProductos, "Artículos negados por que NO se encuentran en Aclaración y/o superan la cantidad registrada", GetAtributosMaterialEnAclaracion())
            bRes = False
        End If

        Return bRes
    End Function


    Private Function ValidaProductos() As Boolean
        Dim dtResult As DataTable
        Dim oTraspasoEntradaMgr As TraspasosEntradaManager
        Dim dvArticulos As DataView
        Dim dtTemp As DataTable
        Dim oNewRow As DataRow
        Dim bRes As Boolean = True

        dtTemp = New DataTable
        dtTemp.Clear()
        dtTemp.Columns.Add("CodArticulo", GetType(String))
        dtTemp.Columns.Add("Descripcion", GetType(String))
        dtTemp.AcceptChanges()



        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)

        dtResult = oTraspasoEntradaMgr.SelectArticulosAclaracionByFolio(ebTraspasoCF.Text.Trim)

        If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
            For Each oRow As DataRow In odtArticulosTras.Rows
                dvArticulos = New DataView(dtResult, "CodArticulo = '" & CStr(oRow!CodArticulo) & "'", "", DataViewRowState.CurrentRows)

                If dvArticulos.Count = 0 Then
                    oNewRow = dtTemp.NewRow
                    With oNewRow
                        !CodArticulo = CStr(oRow!CodArticulo).Trim
                        !Descripcion = CStr(oRow!Descripcion).Trim
                    End With
                    dtTemp.Rows.Add(oNewRow)
                End If
            Next
        Else
            MsgBox("No se encontró el o los materiales en el folio de producto proporcionado.", MsgBoxStyle.Exclamation, "DPTienda")
            bRes = False
        End If

        If dtTemp.Rows.Count > 0 Then
            ShowFormMessage(dtTemp, "Artículos no encontrados en el folio del traspaso proporcionado", GetAtributosMaterialesNoEncontrados())
            bRes = False
        End If
        Return bRes

    End Function


    Private Sub Sm_GuardarTraspaso(Optional ByVal bolImprimir As Boolean = False)


        If Not (oTraspasoSalida Is Nothing) Then

            MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
            Return

        End If

        If ebTraspasoCF.Text.Trim = "" Then
            MsgBox("Debe especificar el folio del traspaso para poder continuar.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If

        If Me.ebTraspasoCF.Text <> "" Then
            Dim folio As String = Me.ebTraspasoCF.Text
            Me.ebTraspasoCF.Text = folio.PadLeft(10, "0")
        End If

        If odtArticulosTras Is Nothing Or odtArticulosTras.Rows.Count = 0 Then
            MsgBox("Debe seleccionar el o los productos del traspaso para poder continuar.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If


        If ValidaProductos() = False Then
            Exit Sub
        End If

       


        If (oTraspasoSalida Is Nothing) Then   'Opción Guardar.

            If (MessageBox.Show("Se encuentra seguro de Guardar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                Exit Sub
            End If

            If (Fm_bolTxtValidar() = False) Then
                Exit Sub
            End If


            If ValidarProductos(odsTraspasoCorrida.Tables(0)) = False Then
                Exit Sub
            End If



            Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)

            Dim dtNegados As DataTable
            Dim UserNameNiega As String = ""
            Dim dtDefectuososEC As DataTable 'Tabla con los codigos baja calidad EC que el player selecciono que van en la venta
            Dim UserNameDesmarca As String = ""
            Dim dtDefecECSAP As DataTable 'Tabla con los codigos baja calidad EC marcados en SAP

            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 07/05/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
            '-----------------------------------------------------------------------------------------------------------------------------
            Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
            Dim dtMateriales As DataTable = GetDataTableFormatNegadosSH(odtArticulosTras)
            If ValidarMaterialesNegadosSH(dtMateriales, dtNegadosSH, "PF,P,RP") = False Then
                ShowFormNegadosSH(dtNegadosSH)
                Exit Sub
            End If

            '-----------------------------------------------------------------------------------------------------------------------------------
            'Validamos si los codigos del traspaso estan marcados como defectuosos para Ecommerce
            '---------------- -------------------------------------------------------------------------------------------------------------------
            Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(odtArticulosTras, dtMateriales)
            If ValidarMaterialesDefectuososEC(dtArticuloLibre, dtDefectuososEC, UserNameDesmarca, "TS", dtDefecECSAP) = False Then
                Exit Sub
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------
            'Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle del traspaso
            '-----------------------------------------------------------------------------------------------------------------------------------
            If ValidarMaterialesParaNegarEC(dtNegados, dtArticuloLibre, dtDefectuososEC, dtDefecECSAP, UserNameDesmarca, "TS") = False Then
                Exit Sub
            End If


            'Dim dtAclaracion As DataTable
            ' dtAclaracion = ProductosEnAclaracion(dtArticuloLibre)

            '-----------------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS 07/06/2022: Revisamos si hay productos en reserva
            '-----------------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS Comentado mientras se resuelve
            'If ValidarProductosEnNecesidad(dtAclaracion, dtArticuloLibre) = False Then
            '    Exit Sub
            'End If

            '-----------------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS 15/06/2022: Solo se puede dar salida a productos en Aclaración, sin superar la cantidad
            '-----------------------------------------------------------------------------------------------------------------------------


            'If ValidarAclaracion(dtAclaracion, dtArticuloLibre) = False Then
            '    Exit Sub
            'End If

            If ValidarAclaracionLocal(dtArticuloLibre) = False Then
                Exit Sub
            End If


            '************ Ramiro Alcaraz Flores **********************
            Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim hGuia As New Hashtable()
            hGuia("Guia") = ebNumGuia.Text.Trim()
            hGuia("Bultos") = ebNumBulto.Value
            If oTransportista.ID.Trim() = "006" Then
                hGuia("Transportista") = "CLIENTE"
            Else
                hGuia("Transportista") = oTransportista.Nombre
            End If
            hGuia("AlmacenOrigen") = "M001"
            hGuia("MotivoDevolucion") = ""
            Dim dtMat As DataTable = odtArticulosTras.Copy()
            dtMat.Columns.Add("MotivoDefectuoso", GetType(String))
            dtMat.Columns.Add("ClaveConfirm", GetType(String))
            For Each row As DataRow In dtMat.Rows
                row("MotivoDefectuoso") = ""
                row("ClaveConfirm") = "0004"
                row.AcceptChanges()
            Next
            dtMat.AcceptChanges()
            EdBxFolioSAP.Text = oSap.pedido_trasladomm02(dtMat, "1000", "R000", hGuia)

            If EdBxFolioSAP.Text = String.Empty Then
                'No se grabo en sap
                'MsgBox("No se Realizo el PEDIDO DE TRAPASO en Sap", MsgBoxStyle.Critical, "Error SAP")
                Exit Sub
            Else
                'Dim strNumTras As String = String.Empty

                'strNumTras = oSap.trasladomm02(EdBxFolioSAP.Text, Me.ebObservaciones.Text & " " & ebFolioObs.Text, "999")

                'If strNumTras = String.Empty Then
                '    'no se grabo en sap
                '    MsgBox("No se Realizo el TRASPASO en Sap", MsgBoxStyle.Critical, "Error SAP")
                '    Exit Sub
                'End If
            End If


            '--------------------------------------------------------------------------------------------------------------------------
            ' CVALLADOLID 20/10/2016: Folio de concentración
            '                         Actualizamos el status de la concentracion en SAP a Enviado
            '--------------------------------------------------------------------------------------------------------------------------
            oSap.ZSET_CONCENT_STATUS(Me.nebFolioConcen.Value, "B")

            If oConfigCierreFI.SurtirEcommerce Then
                '--------------------------------------------------------------------------------------------------------------------------
                'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario
                '--------------------------------------------------------------------------------------------------------------------------
                If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                    oSap.ZPOL_TRASL_NEGAR(EdBxFolioSAP.Text, "TS", UserNameNiega, dtNegados)
                    ValidarCambioStatusPedidoTS(dtNegados, UserNameNiega)
                End If
            End If
            '--------------------------------------------------------------------------------------------------------------------------
            'Se desmarcan los codigos marcados como defectuosos para ecommerce que van en la factura
            '--------------------------------------------------------------------------------------------------------------------------
            If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                oSap.ZPOL_DEFECTUOSOS_INS(EdBxFolioSAP.Text, "DD", UserNameDesmarca, dtDefectuososEC)
            End If

            '-----------------------------------------------------------------------------------------------------------------------
            'Se desmarcan los códigos de baja calidad en la base de datos local
            '-----------------------------------------------------------------------------------------------------------------------
            If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                oFacturaMgr.DesmarcaBajaCalidad(dtDefectuososEC)
            End If

            '***************GUIA BULTOS PAQUETERIA*************************
            'Guia       F01
            'Bultos     F02
            'Paqueteria F03
            '-----------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (17.02.2016): se comenta por que ya no se usara pues la BAPI de ZBAPIMM02_PEDIDOTRAS incluye la funcionalidad
            '-----------------------------------------------------------------------------------------------------------------------------------
            'oSap.SaveInfoPaqueteria(EdBxFolioSAP.Text, Me.ebNumBulto.Text, "F02")
            'oSap.SaveInfoPaqueteria(EdBxFolioSAP.Text, Me.ebTransportistaDesc.Text, "F03")
            '*****************************************************

            oTraspasoSalida = Nothing
            oTraspasoSalida = oTraspasoSalidaMgr.Create

            'oTraspasoSalida.Observaciones = String.Empty
            oTraspasoSalida.Observaciones = ebObservaciones.Text & " " & ebFolioObs.Text

            oTraspasoSalida.TraspasoRecibidoEl = Date.Now.Date '' "01/01/1900"
            oTraspasoSalida.Guia = ebNumGuia.Text
            oTraspasoSalida.TotalBultos = ebNumBulto.Text
            oTraspasoSalida.AutorizadoPorID = strResponsableID
            'oTraspasoSalida.Cargos = ebCargos.Text
            oTraspasoSalida.Cargos = 0
            'oTraspasoSalida.SubTotal = ebSubTotal.Text
            oTraspasoSalida.SubTotal = ebTotal.Text
            oTraspasoSalida.MonedaID = oTipoMoneda.ID   'String.Empty
            oTraspasoSalida.TraspasoCreadoEl = Date.Now.Date '"01/01/1900"
            oTraspasoSalida.TransportistaID = oTransportista.ID
            oTraspasoSalida.Status = "GRA"

            oTraspasoSalida.AlmacenDestinoID = "999"

            oTraspasoSalida.AlmacenOrigenID = oAppContext.ApplicationConfiguration.Almacen
            oTraspasoSalida.Referencia = String.Empty
            oTraspasoSalida.TraspasoID = 0
            oTraspasoSalida.Folio = String.Empty
            oTraspasoSalida.FolioSAP = EdBxFolioSAP.Text
            oTraspasoSalida.Entrega = EdBxFolioSAP.Text
            oTraspasoSalida.Detalle = odsTraspasoCorrida
            oTraspasoSalida.Modulo = "RR" 'Reclamacion Reporte de Error
            '-----------------------------------------------------------------------------------------------
            'MLVARGAS (03/09/2021) Agregar dato de traspaso con faltante
            '-----------------------------------------------------------------------------------------------
            oTraspasoSalida.TraspasoConFaltante = ebTraspasoCF.Text
            oTraspasoSalida.Save()
            ebFolio.Text = oTraspasoSalida.TraspasoID

            '-----------------------------------------------------------------------------------------------
            ' MLVARGAS (10.09.2021): Verificar si hay productos que desmarcar en SAP
            '-----------------------------------------------------------------------------------------------
            If ebTraspasoCF.Text.Trim.Length > 0 Then
                DesmarcarCodigosSAP(odsTraspasoCorrida.Tables(0))
            End If

            oTraspasoSalida = Nothing
            oTraspasoSalida = oTraspasoSalidaMgr.Load(ebFolio.Text)

            Sm_MostrarTraspasoInformacion()

            Sm_AplicarTraspaso()

            'Imprimir Traspaso
            If (bolImprimir = True) Then
                PrintComprobanteTraspaso()
                'ImprimeLPT1()
            End If

            MessageBox.Show("La información ha sido Guardada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Sm_TxtLimpiar()

            'Sm_AplicarTraspaso()

        Else   'Opción Actualizar.

            '<Validación>
            If (oTraspasoSalida.Status <> "GRA") Then
                MsgBox("El Status del Traspaso no permite realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Sub
            End If
            '</Validación>


            If (MessageBox.Show("Se encuentra seguro de Actualizar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                Exit Sub
            End If


            If (Fm_bolTxtValidar() = False) Then
                Exit Sub
            End If


            oTraspasoSalida.Observaciones = String.Empty
            oTraspasoSalida.TraspasoRecibidoEl = Date.Now.Date '"01/01/1900"
            oTraspasoSalida.Guia = ebNumGuia.Text
            oTraspasoSalida.TotalBultos = ebNumBulto.Text
            'oTraspasoSalida.AutorizadoPorID = oAppContext.Security.CurrentUser.Name  'ebResponsable.Text
            oTraspasoSalida.AutorizadoPorID = strResponsableID
            'oTraspasoSalida.Cargos = ebCargos.Text
            oTraspasoSalida.Cargos = 0
            'oTraspasoSalida.SubTotal = ebSubTotal.Text
            oTraspasoSalida.SubTotal = ebTotal.Text
            oTraspasoSalida.MonedaID = oTipoMoneda.ID  'String.Empty
            oTraspasoSalida.TraspasoCreadoEl = Date.Now.Date '"01/01/1900"
            oTraspasoSalida.TransportistaID = oTransportista.ID
            oTraspasoSalida.Status = "GRA"
            oTraspasoSalida.AlmacenDestinoID = "999"
            oTraspasoSalida.AlmacenOrigenID = oAppContext.ApplicationConfiguration.Almacen
            oTraspasoSalida.Referencia = String.Empty
            oTraspasoSalida.TraspasoConFaltante = ebTraspasoCF.Text
            'oTraspasoSalida.TraspasoID 
            'oTraspasoSalida.Folio = String.Empty

            oTraspasoSalida.Detalle = odsTraspasoCorrida

            oTraspasoSalida.Save()

            On Error Resume Next

            Dim intTraspasoID As Integer = oTraspasoSalida.TraspasoID

            oTraspasoSalida = Nothing
            oTraspasoSalida = oTraspasoSalidaMgr.Load(intTraspasoID) '(Vl_intCodTraspaso)

            Sm_MostrarTraspasoInformacion()

            MessageBox.Show("La información ha sido Actualizada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If (bolImprimir = True) Then
                PrintComprobanteTraspaso()
                'ImprimeLPT1()
            End If

            Sm_TxtLimpiar()

        End If

    End Sub


    Private Sub Sm_AbrirTraspasoPendientes()

        Dim ofrmTraspasoBusqueda As New frmTraspasoBusqueda


        ofrmTraspasoBusqueda.TipoTraspaso = True
        ofrmTraspasoBusqueda.ShowDialog()

        If (ofrmTraspasoBusqueda.DialogResult = DialogResult.OK) Then

            On Error Resume Next

            oTraspasoSalida = Nothing
            oTraspasoSalida = oTraspasoSalidaMgr.Load(ofrmTraspasoBusqueda.Record.Item("TraspasoID"))

            '<Validación>
            If (oTraspasoSalida Is Nothing) Then
                Sm_TxtLimpiar()
                Exit Sub
            End If
            '</Validación>

            Sm_MostrarTraspasoInformacion()

        End If

        ofrmTraspasoBusqueda.Dispose()
        ofrmTraspasoBusqueda = Nothing

    End Sub



    Private Sub Sm_AbrirTraspaso()

        Dim oOpenRecordDlg As New OpenRecordDialog


        oOpenRecordDlg.CurrentView = New TraspasoSalidaOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            On Error Resume Next

            oTraspasoSalida = Nothing
            oTraspasoSalida = oTraspasoSalidaMgr.Load(oOpenRecordDlg.Record.Item("TraspasoID"))

            Sm_MostrarTraspasoInformacion()

        End If

    End Sub



    Private Sub Sm_AplicarTraspaso()

        '<Validación>

        If (oTraspasoSalida Is Nothing) Then
            MsgBox("No ha sido seleccionado un Traspaso", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If


        If (oTraspasoSalida.Status <> "GRA") Then

            MsgBox("El Traspaso ya fue Aplicado.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If

        '</Validación>


        Cursor.Current = Cursors.WaitCursor

        'Actualizar Traspaso [General].

        oTraspasoSalida.TraspasoRecibidoEl = "01/01/1900"
        oTraspasoSalida.Status = "TRA"

        If (oTraspasoSalidaMgr.AplicarEntrada(oTraspasoSalida) = True) Then

            Cursor.Current = Cursors.Default

            Dim intTraspasoID As Integer = oTraspasoSalida.TraspasoID

            oTraspasoSalida = Nothing
            oTraspasoSalida = oTraspasoSalidaMgr.Load(intTraspasoID)

            Sm_MostrarTraspasoInformacion()

            'Gurado los motivos de captura manual
            Try
                If Not Me.dtMotivosGral Is Nothing Then
                    For Each orow As DataRow In dtMotivosGral.Rows
                        oTraspasoSalidaMgr.SaveMotivo(oTraspasoSalida.TraspasoID, orow("Tienda"), orow("Articulo"), orow("Talla"), orow("IdMotivo"), "TS")
                    Next
                End If
            Catch ex As Exception

            End Try

            MsgBox("El Traspaso ha sido Aplicado satisfactoriamente.", MsgBoxStyle.Information, "DPTienda.")



        Else

            Cursor.Current = Cursors.Default
            MsgBox("El Traspaso no pudó ser Aplicado.", MsgBoxStyle.Critical, "DPTienda.")

        End If

    End Sub



    'Private Sub Sm_EliminarTraspaso()

    '    'If (oTraspasoSalida Is Nothing) Then
    '    '    MessageBox.Show("No ha sido seleccionado un Traspaso de Salida.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    '    Exit Sub
    '    'End If


    '    'If (oTraspasoSalida.Status <> "GRA") Then
    '    '    MsgBox("El Status del Traspaso no permite Eliminarlo.", MsgBoxStyle.Exclamation, "DPTienda")
    '    '    Exit Sub
    '    'End If


    '    'If (MessageBox.Show("Se encuentra seguro de Eliminar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
    '    '                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
    '    '    Exit Sub
    '    'End If


    '    'oTraspasoSalidaMgr.Delete(oTraspasoSalida.TraspasoID)

    '    'Sm_TxtLimpiar()

    '    'ebSucOrigenCod.Text = String.Empty
    '    'ebSucOrigenDesc.Text = String.Empty
    '    'ebResponsable.Text = String.Empty
    '    'ebNumBulto.Text = String.Empty

    '    'oTraspasoSalida = Nothing

    '    'MessageBox.Show("La información ha sido Eliminada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    'ebSucDestinoCod.Focus()

    'End Sub



    'Private Sub Sm_ReenviarTraspaso()

    '    'If (oTraspasoSalida Is Nothing) Then

    '    '    MsgBox("No ha seleccionado un Traspaso.", MsgBoxStyle.Exclamation, "DPTienda")
    '    '    Exit Sub

    '    'End If


    '    'oTraspasoSalidaMgr.CreatTraspasoSalidaDBF(oTraspasoSalida, True)

    'End Sub



    Private Sub Sm_BuscarAlmacenDestino(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then 'Or (ebSucDestinoCod.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoAlmacenesOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oAlmacenDestino = Nothing
                oAlmacenDestino = oCatalogoAlmacenMgr.Load(oOpenRecordDlg.Record.Item("CodAlmacen"))

                ebSucDestinoCod.Text = oAlmacenDestino.ID
                ebSucDestinoDesc.Text = oAlmacenDestino.Descripcion

                'ebTransportistaCod.Focus()

            End If

        Else

            On Error Resume Next

            oAlmacenDestino = Nothing
            oAlmacenDestino = oCatalogoAlmacenMgr.Load(ebSucDestinoCod.Text.Trim)

            '<Validación>

            If (oAlmacenDestino Is Nothing) Then

                'MessageBox.Show("El Registro no existe.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebSucDestinoCod.Text = String.Empty
                ebSucDestinoDesc.Text = String.Empty

                ebSucDestinoCod.Focus()

                Exit Sub

            End If

            '</Validación>

            ebSucDestinoCod.Text = oAlmacenDestino.ID
            ebSucDestinoDesc.Text = oAlmacenDestino.Descripcion

            'ebTransportistaCod.Focus()

        End If

    End Sub



    Private Sub Sm_BuscarTransportista(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then 'Or (ebTransportistaCod.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoTransportistaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oTransportista = Nothing
                oTransportista = oCatalogoTransportistasMgr.Load(oOpenRecordDlg.Record.Item("CodTransportista"))

                ebTransportistaCod.Text = oTransportista.ID
                ebTransportistaDesc.Text = oTransportista.Nombre

                'ebMonedaCod.Focus()

            End If

        Else

            On Error Resume Next

            oTransportista = Nothing
            oTransportista = oCatalogoTransportistasMgr.Load(ebTransportistaCod.Text.Trim)

            '<Validación>

            If (oTransportista Is Nothing) Then

                'MessageBox.Show("El Registro no existe.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebTransportistaCod.Text = String.Empty
                ebTransportistaDesc.Text = String.Empty

                ebTransportistaCod.Focus()

                Exit Sub

            End If

            '</Validación>

            ebTransportistaCod.Text = oTransportista.ID
            ebTransportistaDesc.Text = oTransportista.Nombre

            'ebMonedaCod.Focus()

        End If

    End Sub



    Private Sub Sm_BuscarMoneda(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then 'Or (ebTransportistaCod.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoTipoMonedaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oTipoMoneda = Nothing
                oTipoMoneda = oCatalogoTipoMonedaMgr.Load(oOpenRecordDlg.Record.Item("CodMoneda"))

                ebMonedaCod.Text = oTipoMoneda.ID
                ebMonedaDesc.Text = oTipoMoneda.Descripcion

                'ebNumBulto.Focus()

            End If

        Else

            On Error Resume Next

            oTipoMoneda = Nothing
            oTipoMoneda = oCatalogoTipoMonedaMgr.Load(ebMonedaCod.Text.Trim)

            '<Validación>

            If (oTipoMoneda Is Nothing) Then

                'MessageBox.Show("El Registro no existe.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebMonedaCod.Text = String.Empty
                ebMonedaDesc.Text = String.Empty

                ebMonedaCod.Focus()

                Exit Sub

            End If

            '</Validación>

            ebMonedaCod.Text = oTipoMoneda.ID
            ebMonedaDesc.Text = oTipoMoneda.Descripcion

            'ebNumBulto.Focus()

        End If

    End Sub
    Private Sub CreateDtMotivos()

        Dim dCol As DataColumn
        Dim dRow As DataRow

        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "FolioFactura"
        dCol.Caption = "FolioFactura"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 10
        m_datdtMotivosGral.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "Tienda"
        dCol.Caption = "Tienda"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 3
        m_datdtMotivosGral.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "Articulo"
        dCol.Caption = "Articulo"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 30
        m_datdtMotivosGral.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "Talla"
        dCol.Caption = "Talla"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 10
        m_datdtMotivosGral.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(Integer)
        dCol.ColumnName = "IdMotivo"
        dCol.Caption = "IdMotivo"
        dCol.DefaultValue = 0
        dCol.AllowDBNull = False
        m_datdtMotivosGral.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(Date)
        dCol.ColumnName = "Fecha"
        dCol.Caption = "Fecha"
        dCol.DefaultValue = Now.Date.ToShortDateString
        dCol.AllowDBNull = False
        m_datdtMotivosGral.Columns.Add(dCol)

        m_datdtMotivosGral.AcceptChanges()

    End Sub


    Private Sub Sm_CapturaDetalle()

        'Dim ofrmCapturaTraspasos As New frmCapturaTraspasos
        Dim ofrmCapturaTraspasos As New frmInvAuditoriaCaptura(ebSucDestinoCod.Text)

        ofrmCapturaTraspasos.dtMotivosDet = Me.dtMotivosGral.Copy

        '1.- Crear Tabla Temporal [y en caso de haber seleccionado un TraspasoSalida Agregar su Detalle en Tabla Temporal.]

        If Not (oTraspasoSalida Is Nothing) Then

            '<Validación>
            If (oTraspasoSalida.Status <> "GRA") Then
                MsgBox("El Status del Traspaso no permite realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Sub
            End If
            '</Validación>

            With oTraspasoSalidaMgr

                .CrearTablaTmp()

                'Utilizar la propiedad TraspasoSalida.Detalle[DataSet], para llenar la Tabla Temporal.
                .GenerarTraspasoDetalleTemporal(odsTraspasoCorrida)


            End With
            'Guarda los datos de la tabla

            ofrmCapturaTraspasos.TraspasoID = oTraspasoSalida.TraspasoID

        Else

            ofrmCapturaTraspasos.TraspasoID = 0

            If Not (odsTraspasoCorrida Is Nothing) Then

                If (odsTraspasoCorrida.Tables(0).Rows.Count > 0) Then

                    'Crear y Llenar Tabla Temporal.

                    With oTraspasoSalidaMgr

                        .CrearTablaTmp()

                        'Utilizar la propiedad TraspasoSalida.Detalle[DataSet], para llenar la Tabla Temporal.
                        .GenerarTraspasoDetalleTemporal(odsTraspasoCorrida)

                    End With
                    'Guarda los datos de la tabla


                End If

            End If

        End If


        '2.- Mostar Form CapturaTraspasos [Su Resultado es la Creación de una Tabla Temporal].

        ofrmCapturaTraspasos.ShowDialog()

        '<Validación>
        If (ofrmCapturaTraspasos.DialogResult <> DialogResult.OK) Then
            Exit Sub
        End If
        '</Validación>

        dtMotivosGral = ofrmCapturaTraspasos.dtMotivosDet.Copy

        'Guarda los datos de la tabla RAMIRO ALCARAZ FLORES
        odtArticulosTras = oTraspasoSalidaMgr.FillTablaParaSAP

        '3.- Actualizar Grid [Traspaso Corrida] 


        odsTraspasoCorrida = Nothing
        odsTraspasoCorrida = oTraspasoSalidaMgr.GenerarTraspasoCorrida("[RefCruzTraspaso]")
        GridTraspasoCorrida.DataSource = odsTraspasoCorrida.Tables(0)

        Sm_CalcularTotales()

        ofrmCapturaTraspasos.Dispose()
        ofrmCapturaTraspasos = Nothing


        ebObservaciones.Focus()

    End Sub

    '------------------------------------------------------------------------------
    ' CVALLADOLID 25/10/2016: Modificación a la Transacción ZCONCENTRACIONES y RFC
    '------------------------------------------------------------------------------
    Private Function GetFoliosConcentraciones(Optional ByVal bValidar As Boolean = True) As Boolean
        Dim bRes As Boolean = True
        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        If bValidar Then
            dtFoliosConcen = oSap.ZGET_CONCENTRACIONES("T" & oAppContext.ApplicationConfiguration.Almacen, ALMACEN_DESTINO)

            If dtFoliosConcen.Rows.Count > 0 Then
                'Do nothing
            Else
                MessageBox.Show("No existe una solicitud de traspaso de salida para tu tienda.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                bRes = False
            End If
        End If

        Return bRes
    End Function

    Private Function ValidaFolioConcen(ByVal Folio As Long) As Boolean
        Dim FolioValido As Boolean = False

        If Folio > 0 Then
            Dim oRow As DataRow

            For Each oRow In dtFoliosConcen.Rows
                If Folio.ToString.Trim.ToUpper = CStr(oRow!Folio).Trim.ToUpper Then
                    FolioValido = True
                    Exit For
                End If
            Next
        End If

        Return FolioValido
    End Function


#End Region


#Region "Propiedades"
    Public Property dtMotivosGral() As DataTable
        Get
            Return m_datdtMotivosGral
        End Get
        Set(ByVal Value As DataTable)
            m_datdtMotivosGral = Value
        End Set
    End Property
#End Region

#Region "Métodos Privados [Eventos]"

    'Private Sub frmInvTraspasosDSalida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '    oTraspasoSalidaMgr = New TraspasosSalidaManager(oAppContext)

    '    oCatalogoAlmacenMgr = New CatalogoAlmacenesManager(oAppContext)

    '    oCatalogoTransportistasMgr = New CatalogoTransportistaManager(oAppContext)

    '    oCatalogoTipoMonedaMgr = New CatalogoTipoMonedaManager(oAppContext)

    '    odsCatalogoCorridas = oTraspasoSalidaMgr.ExtraerCatalogoCorridas

    '    oTraspasoSalidaMgr.CrearTablaTmp()

    '    Sm_Nuevo()

    '    '***
    '    Me.ebSucDestinoCod.Text = "1000"
    '    Me.ebSucDestinoDesc.Text = "Almacen General - C. DIST."


    '    'ebObservaciones.Text = String.Empty
    '    'ebObservaciones.Items.Clear()
    '    'ebObservaciones.Items.Add("Faltante de Invent.", "1")
    '    'ebObservaciones.Items.Add("Vale de Empleado", "2")
    '    'ebObservaciones.Items.Add("Falt. Paqueteria", "3")
    '    'ebObservaciones.SelectedIndex = 0

    '    ebResponsable.Text = oAppContext.Security.CurrentUser.Name
    '    strResponsableID = oAppContext.Security.CurrentUser.SessionLoginName
    '    '***

    'End Sub



    'Private Sub frmInvTraspasosDSalida_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

    '    On Error Resume Next

    '    'Eliminar Tabla Temporal.
    '    oTraspasoSalidaMgr.EliminarTablaTmp()

    '    oTraspasoSalida = Nothing

    '    oTraspasoSalidaMgr = Nothing

    '    oAlmacenDestino = Nothing

    '    oCatalogoAlmacenMgr = Nothing

    '    oTipoMoneda = Nothing

    '    oCatalogoTipoMonedaMgr = Nothing

    '    odsCatalogoCorridas.Dispose()
    '    odsCatalogoCorridas = Nothing

    '    odsTraspasoCorrida.Dispose()
    '    odsTraspasoCorrida = Nothing


    'End Sub



    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case (e.Command.Key)

            Case "menuArchivoNuevo"

                Sm_Nuevo()

            Case "menuArchivoGuardar"

                Sm_GuardarTraspaso()

            Case "menuArchivoAbrir"

                Sm_AbrirTraspaso()

            Case "menuArchivoPendientes"

                'Sm_AbrirTraspasoPendientes()

            Case "menuArchivoAplicar"

                'Sm_AplicarTraspaso()

            Case "menuArchivoEliminar"

                'Sm_EliminarTraspaso()

            Case "menuArchivoReenviarTraspaso"

                'Sm_ReenviarTraspaso()

            Case "menuArchivoCerrar"

                bolSalir = True
                Me.Finalize()
                Me.Close()

            Case "menuArchivoImprimir"


                PrintComprobanteTraspaso()

                'ImprimeLPT1()


        End Select

    End Sub

    Public Sub PrintComprobanteTraspaso()

        If Not oTraspasoSalida Is Nothing Then

            Dim oARReporte As New rptReporteTraspasoDeSalida(oTraspasoSalida, "Por Carta de Reclamación")
            'Dim oReportViewer As New ReportViewerForm

            oARReporte.Document.Name = "Reporte de Traspaso de Salida"

            oARReporte.Run()

            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

            Try

                oARReporte.Document.Print(False, False)

            Catch ex As Exception

                MsgBox(ex.ToString)

            End Try

        End If

    End Sub


    Private Sub uibtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Sm_AbrirTraspaso()

    End Sub



    Private Sub uibtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Sm_GuardarTraspaso()

    End Sub



    Private Sub uibtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Sm_EliminarTraspaso()

    End Sub



    Private Sub uibtnCapturaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnCapturaDetalle.Click

        Sm_CapturaDetalle()

    End Sub



    Private Sub ebSucDestinoCod_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebSucDestinoCod2.ButtonClick

        Sm_BuscarAlmacenDestino(True)
        'If ebSucDestinoCod.Text = "077" Or ebSucDestinoCod.Text = "000" Then
        If ebSucDestinoCod.Text = "000" Then
            ebSucDestinoCod.Text = ""
            ebSucDestinoDesc.Text = ""
            MessageBox.Show("No se Pueden Hacer traspasos de Tiendas al Centro de Distribución", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub ebSucDestinoCod_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebSucDestinoCod2.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            'Sm_BuscarAlmacenDestino()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarAlmacenDestino(True)
            'If ebSucDestinoCod.Text = "077" Or ebSucDestinoCod.Text = "000" Then
            If ebSucDestinoCod.Text = "000" Then
                ebSucDestinoCod.Text = ""
                ebSucDestinoDesc.Text = ""
                MessageBox.Show("No se Pueden Hacer traspasos de Tiendas al Centro de Distribución", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub ebSucDestinoCod_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebSucDestinoCod2.Validating

        If (bolSalir = True) Then
            Return
        End If


        If (ebSucDestinoCod.Text.Trim = String.Empty) Then

            ebSucDestinoCod.Focus()
            Return

        End If


        If (ebSucDestinoCod.Text.Trim <> String.Empty) Then

            Sm_BuscarAlmacenDestino()

            If (oAlmacenDestino Is Nothing) Then

                MsgBox("El Almácen Destino no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
                e.Cancel = True

            Else

                If (oAlmacenDestino.ID = oAppContext.ApplicationConfiguration.Almacen) Then

                    MsgBox("El Almácen Destino no es valido.", MsgBoxStyle.Exclamation, "DPTienda")

                    ebSucDestinoCod.Text = String.Empty
                    ebSucDestinoDesc.Text = String.Empty

                    e.Cancel = True

                End If

            End If

            'Validamos permiso para realizar el traspaso
            'Select Case ebSucDestinoCod.Text

            '    Case "000", "090", "091", "092", "093", "094", "095", "096", "097", "098", "099"

            '        'oAppContext.Security.CloseImpersonatedSession()
            '        'If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida", "DportenisPro.DPTienda.Inventarios.TraspasosSalida.Almacen" & ebSucDestinoCod.Text) Then
            '        '    ebResponsable.Text = String.Empty
            '        '    strResponsableID = String.Empty
            '        '    e.Cancel = True
            '        'Else
            '        '    ebResponsable.Text = oAppContext.Security.CurrentUser.Name
            '        '    strResponsableID = oAppContext.Security.CurrentUser.SessionLoginName

            'Verificar si es el Almacen 099.
            'If (ebSucDestinoCod.Text = "099") Then
            '    'Mostrar Articulos Defectuosos de Existencias.
            '    Sm_MostrarArticulosDefectuosos()
            'End If

            '        'End If
            '        'oAppContext.Security.CloseImpersonatedSession()

            '    Case Else

            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida", "DportenisPro.DPTienda.Inventarios.TraspasosSalida.Tiendas") Then
                ebResponsable.Text = String.Empty
                strResponsableID = String.Empty
                e.Cancel = True
                ebObservaciones.Text = String.Empty
            Else
                ebObservaciones.Text = String.Empty
                ebResponsable.Text = oAppContext.Security.CurrentUser.Name
                strResponsableID = oAppContext.Security.CurrentUser.SessionLoginName
                If oAppContext.Security.CurrentUser.SessionRole = 6 Or oAppContext.Security.CurrentUser.SessionRole = 7 Then
                    'ebObservaciones.Items.Clear()
                    ''ebObservaciones.Items.Add("Patrocinio", "1")
                    ''ebObservaciones.Items.Add("Mermas", "2")
                    ''ebObservaciones.Items.Add("Donativos", "3")
                    'ebObservaciones.Items.Add("Vale de Empleado", "2")
                    'ebObservaciones.Items.Add("Faltante de Inventario", "1")
                    'ebObservaciones.Items.Add("Falt. de Paquetería", "3")
                    'ebObservaciones.Items.Add("Concentración de Producto", "7")
                    'ebObservaciones.Items.Add("Dev. Error Trasp.", "8")
                    'ebObservaciones.Items.Add("Traspaso Local", "9")
                    'ebObservaciones.Items.Add("Traspaso Foráneo", "10")
                    'ebObservaciones.Items.Add("Impar", "11")
                    'ebObservaciones.Items.Add("Siniestro", "12")
                    'ebObservaciones.Items.Add("Devol. Proveedor", "13")
                Else
                    'ebObservaciones.Items.Clear()
                    'ebObservaciones.Items.Add("Vale de Empleado", "2")
                    'ebObservaciones.Items.Add("Faltante de Inventario", "1")
                    'ebObservaciones.Items.Add("Falt. de Paquetería", "3")
                    'ebObservaciones.Items.Add("Concentración de Producto", "7")
                    'ebObservaciones.Items.Add("Dev. Error Trasp.", "8")
                    'ebObservaciones.Items.Add("Traspaso Local", "9")
                    'ebObservaciones.Items.Add("Traspaso Foráneo", "10")
                    'ebObservaciones.Items.Add("Impar", "11")
                    'ebObservaciones.Items.Add("Devol. Proveedor", "13")
                End If
            End If
            oAppContext.Security.CloseImpersonatedSession()

            'End Select
            'If ebSucDestinoCod.Text = "077" Or ebSucDestinoCod.Text = "000" Then
            If ebSucDestinoCod.Text = "000" Then
                ebSucDestinoCod.Text = ""
                ebSucDestinoDesc.Text = ""
                MessageBox.Show("No se Pueden Hacer traspasos de Tiendas al Centro de Distribución", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else

            MsgBox("El Almácen Destino no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
            e.Cancel = True

        End If

    End Sub



    Private Sub ebTransportistaCod_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebTransportistaCod.ButtonClick

        Sm_BuscarTransportista(True)

    End Sub



    Private Sub ebTransportistaCod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebTransportistaCod.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            'Sm_BuscarTransportista()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarTransportista(True)

        End If

    End Sub



    Private Sub ebTransportistaCod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTransportistaCod.Validating

        If (bolSalir = True) Then
            Return
        End If


        If (ebTransportistaCod.Text.Trim = String.Empty) Then

            ebTransportistaCod.Focus()
            Return

        End If


        If (ebTransportistaCod.Text.Trim <> String.Empty) Then

            Sm_BuscarTransportista()

            If (oTransportista Is Nothing) Then

                MsgBox("El Transportista no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
                e.Cancel = True

            End If

        Else

            MsgBox("El Transportista no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
            e.Cancel = True

        End If

    End Sub



    Private Sub ebMonedaCod_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebMonedaCod.ButtonClick

        Sm_BuscarMoneda(True)

    End Sub



    Private Sub ebMonedaCod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebMonedaCod.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            'Sm_BuscarMoneda()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarMoneda(True)

        End If

    End Sub



    Private Sub ebMonedaCod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebMonedaCod.Validating

        If (bolSalir = True) Then
            Return
        End If


        If (ebMonedaCod.Text.Trim <> String.Empty) Then

            Sm_BuscarMoneda()

            If (oTipoMoneda Is Nothing) Then

                MsgBox("La Moneda no es valida.", MsgBoxStyle.Exclamation, "DPTienda")
                e.Cancel = True

            End If

        Else

            MsgBox("La Moneda no es valida.", MsgBoxStyle.Exclamation, "DPTienda")
            e.Cancel = True

        End If

    End Sub



    Private Sub GridTraspasoCorrida_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridTraspasoCorrida.SelectionChanged

        'SetupView()

    End Sub



    'Private Sub frmInvTraspasosDSalida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown


    '    Select Case e.KeyCode

    '        Case Keys.Enter

    '            SendKeys.Send("{TAB}")


    '        Case Keys.Escape

    '            bolSalir = True
    '            Me.Finalize()
    '            Me.Close()


    '        Case Keys.F2

    '            Sm_GuardarTraspaso()


    '        Case Keys.F9

    '            Sm_GuardarTraspaso(True)

    '    End Select

    'End Sub



    Private Sub ebNumBulto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumBulto.Validating

        If (bolSalir = True) Then
            Return
        End If


        If (ebNumBulto.Text.Trim = String.Empty) Or (ebNumBulto.Text = 0) Then

            ebNumBulto.Focus()
            Return

        End If


        If (ebNumBulto.Text <= 0) Then

            MsgBox("El # de Bultos no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
            e.Cancel = True

        End If

    End Sub



    Private Sub ebNumGuia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumGuia.Validating

        If (bolSalir = True) Then
            Return
        End If


        If (ebNumGuia.Text.Trim = String.Empty) Then

            ebNumGuia.Focus()
            Return

        End If


        If (ebNumGuia.Text.Trim = String.Empty) Then

            MsgBox("El # de Guia no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
            e.Cancel = True

        End If

    End Sub



    Private Sub ebObservaciones_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioObs.Validating

        If (bolSalir = True) Then
            Return
        End If


        If (ebObservaciones.Text.Trim = String.Empty) Then

            ebObservaciones.Focus()
            Return

        End If


        If (ebObservaciones.Text.Trim = String.Empty) Then

            MsgBox("El Campo Observaciones no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
            e.Cancel = True

        End If

    End Sub


#End Region


#Region "PrintPort"

    Private Sub ImprimeLPT1()

        Dim oTraspasoSalidaMgr As New TraspasosSalidaManager(oAppContext)
        Dim odsCatalogoCorridas As DataSet
        Dim odsDatosEmpresa As DataSet
        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oLetras As New Letras
        Dim dtTemp As New DataTable

        '---
        Dim rfcOrig As String

        Dim Origen As String
        Dim OrigenDir As String
        Dim OrigenCiu As String
        Dim Destino As String
        Dim DestinoDir As String
        Dim DestinoCiu As String

        Dim trFolio As String
        Dim trFecha As String
        Dim trBultos As String
        Dim trExpedida As String
        Dim trLetras As String
        Dim trObservaciones As String
        '---
        odsDatosEmpresa = oTraspasoSalidaMgr.ExtraerDatosEmpresa

        rfcOrig = CStr(odsDatosEmpresa.Tables(0).Rows(0).Item("RegFed")).PadRight(30, " ")

        odsDatosEmpresa = Nothing

        oAlmacen = oCatalogoAlmacenMgr.Load(oTraspasoSalida.AlmacenOrigenID)
        Origen = "Suc. " & oTraspasoSalida.AlmacenOrigenID & Space(1) & oAlmacen.Descripcion
        OrigenDir = oAlmacen.DireccionCalle & " # " & oAlmacen.DireccionNumExt & " Int. " & oAlmacen.DireccionNumInt & Space(1) & oAlmacen.DireccionColonia & " CP. " & oAlmacen.DireccionCP
        OrigenCiu = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        trExpedida = (oAlmacen.DireccionCiudad).PadRight(30, " ")

        oAlmacen = oCatalogoAlmacenMgr.Load(oTraspasoSalida.AlmacenDestinoID)
        Destino = "Suc. " & oTraspasoSalida.AlmacenDestinoID & Space(1) & oAlmacen.Descripcion
        DestinoCiu = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        DestinoDir = oAlmacen.DireccionCalle & " # " & oAlmacen.DireccionNumExt & " Int. " & oAlmacen.DireccionNumInt & Space(1) & oAlmacen.DireccionColonia & " CP. " & oAlmacen.DireccionCP

        oAlmacen = Nothing

        trFolio = "# Trasp:" & oTraspasoSalida.Folio & "  # Trasp SAP:" & oTraspasoSalida.FolioSAP
        trFecha = "Fecha de Expedicion :" & Format(Now.Date, "dd/MM/yyyy")
        trBultos = "No. de Bultos : " & CStr(oTraspasoSalida.TotalBultos)

        trLetras = UCase(oLetras.Letras(Decimal.Round(oTraspasoSalida.SubTotal + oTraspasoSalida.Cargos, 2))) & "/100 M.N."

        trObservaciones = oTraspasoSalida.Observaciones

        odsCatalogoCorridas = oTraspasoSalidaMgr.ExtraerCatalogoCorridas

        'Crear Tabla Temporal :
        CreatTableTmp(dtTemp)

        Dim drRow As DataRow
        Dim intNum As Integer
        Dim oCatalogoArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim oArticulo As Articulo

        For Each drRow In oTraspasoSalida.Detalle.Tables("TraspasoCorrida").Rows

            intNum = 0

            Dim drNewRow As DataRow
            Dim intTotalArticulos As Integer = 0
            Dim odrFiltro() As DataRow

            odrFiltro = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & drRow("CodCorrida") & "'")

            drNewRow = dtTemp.NewRow

            With drNewRow

                !CodArticulo = drRow!CodArticulo
                !Descripcion = drRow!Descripcion
                oArticulo = oCatalogoArticuloMgr.Load(drRow!CodArticulo)
                '!Color = oArticulo.Color1
                !Corrida = drRow!CodCorrida
                If (drRow!C01 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C01)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C01"))
                    intTotalArticulos += drRow!C01
                End If
                If (drRow!C02 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C02)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C02"))
                    intTotalArticulos += drRow!C02
                End If
                If (drRow!C03 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C03)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C03"))
                    intTotalArticulos += drRow!C03
                End If
                If (drRow!C04 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C04)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C04"))
                    intTotalArticulos += drRow!C04
                End If
                If (drRow!C05 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C05)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C05"))
                    intTotalArticulos += drRow!C05
                End If
                If (drRow!C06 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C06)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C06"))
                    intTotalArticulos += drRow!C06
                End If
                If (drRow!C07 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C07)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C07"))
                    intTotalArticulos += drRow!C07
                End If
                If (drRow!C08 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C08)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C08"))
                    intTotalArticulos += drRow!C08
                End If
                If (drRow!C09 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C09)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C09"))
                    intTotalArticulos += drRow!C09
                End If
                If (drRow!C10 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C10)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C10"))
                    intTotalArticulos += drRow!C10
                End If
                If (drRow!C11 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C11)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C11"))
                    intTotalArticulos += drRow!C11
                End If
                If (drRow!C12 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C12)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C12"))
                    intTotalArticulos += drRow!C12
                End If
                If (drRow!C13 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C13)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C13"))
                    intTotalArticulos += drRow!C13
                End If
                If (drRow!C14 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C14)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C14"))
                    intTotalArticulos += drRow!C14
                End If
                If (drRow!C15 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C15)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C15"))
                    intTotalArticulos += drRow!C15
                End If
                If (drRow!C16 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C16)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C16"))
                    intTotalArticulos += drRow!C16
                End If
                If (drRow!C17 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C17)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C17"))
                    intTotalArticulos += drRow!C17
                End If
                If (drRow!C18 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C18)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C18"))
                    intTotalArticulos += drRow!C18
                End If
                If (drRow!C19 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C19)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C19"))
                    intTotalArticulos += drRow!C19
                End If
                If (drRow!C20 > 0) Then
                    intNum += 1
                    .Item("C" & intNum) = CStr(drRow!C20)
                    .Item("T" & intNum) = CStr(odrFiltro(0).Item("C20"))
                    intTotalArticulos += drRow!C20
                End If
                !Total = intTotalArticulos
                !CostUnit = drRow!CostoTotal / intTotalArticulos
                !CostTotal = drRow!CostoTotal
            End With
            dtTemp.Rows.Add(drNewRow)
            odrFiltro = Nothing
        Next


        'Seteamos Array Generales
        Dim Generales(12) As String
        Generales(0) = Origen
        Generales(1) = Destino
        Generales(2) = trFolio
        Generales(3) = OrigenDir
        Generales(4) = DestinoDir
        Generales(5) = trFecha
        Generales(6) = OrigenCiu
        Generales(7) = DestinoCiu
        Generales(8) = trExpedida
        Generales(9) = rfcOrig
        Generales(10) = rfcOrig
        Generales(11) = trBultos

        '(Generales, dtTemp, trLetras, trObservaciones)

    End Sub

    Public Sub CreatTableTmp(ByRef Data As DataTable)

        Dim dcCodArticulo As New DataColumn
        With dcCodArticulo
            .ColumnName = "CodArticulo"
            .DataType = GetType(String)
            .DefaultValue = String.Empty
        End With

        Dim dcDescripcion As New DataColumn
        With dcDescripcion
            .ColumnName = "Descripcion"
            .DataType = GetType(String)
            .DefaultValue = String.Empty
        End With

        Dim dcColor As New DataColumn
        With dcColor
            .ColumnName = "Color"
            .DataType = GetType(String)
            .DefaultValue = String.Empty
        End With

        Dim dcCorrida As New DataColumn
        With dcCorrida
            .ColumnName = "Corrida"
            .DataType = GetType(String)
            .DefaultValue = String.Empty
        End With

        Dim dcC1 As New DataColumn
        With dcC1
            .ColumnName = "C1"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT1 As New DataColumn
        With dcT1
            .ColumnName = "T1"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC2 As New DataColumn
        With dcC2
            .ColumnName = "C2"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT2 As New DataColumn
        With dcT2
            .ColumnName = "T2"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC3 As New DataColumn
        With dcC3
            .ColumnName = "C3"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT3 As New DataColumn
        With dcT3
            .ColumnName = "T3"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC4 As New DataColumn
        With dcC4
            .ColumnName = "C4"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT4 As New DataColumn
        With dcT4
            .ColumnName = "T4"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC5 As New DataColumn
        With dcC5
            .ColumnName = "C5"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT5 As New DataColumn
        With dcT5
            .ColumnName = "T5"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC6 As New DataColumn
        With dcC6
            .ColumnName = "C6"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT6 As New DataColumn
        With dcT6
            .ColumnName = "T6"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC7 As New DataColumn
        With dcC7
            .ColumnName = "C7"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT7 As New DataColumn
        With dcT7
            .ColumnName = "T7"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC8 As New DataColumn
        With dcC8
            .ColumnName = "C8"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT8 As New DataColumn
        With dcT8
            .ColumnName = "T8"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC9 As New DataColumn
        With dcC9
            .ColumnName = "C9"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT9 As New DataColumn
        With dcT9
            .ColumnName = "T9"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC10 As New DataColumn
        With dcC10
            .ColumnName = "C10"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT10 As New DataColumn
        With dcT10
            .ColumnName = "T10"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC11 As New DataColumn
        With dcC11
            .ColumnName = "C11"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT11 As New DataColumn
        With dcT11
            .ColumnName = "T11"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC12 As New DataColumn
        With dcC12
            .ColumnName = "C12"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT12 As New DataColumn
        With dcT12
            .ColumnName = "T12"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC13 As New DataColumn
        With dcC13
            .ColumnName = "C13"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT13 As New DataColumn
        With dcT13
            .ColumnName = "T13"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC14 As New DataColumn
        With dcC14
            .ColumnName = "C14"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT14 As New DataColumn
        With dcT14
            .ColumnName = "T14"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC15 As New DataColumn
        With dcC15
            .ColumnName = "C15"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT15 As New DataColumn
        With dcT15
            .ColumnName = "T15"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC16 As New DataColumn
        With dcC16
            .ColumnName = "C16"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT16 As New DataColumn
        With dcT16
            .ColumnName = "T16"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC17 As New DataColumn
        With dcC17
            .ColumnName = "C17"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT17 As New DataColumn
        With dcT17
            .ColumnName = "T17"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC18 As New DataColumn
        With dcC18
            .ColumnName = "C18"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT18 As New DataColumn
        With dcT18
            .ColumnName = "T18"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC19 As New DataColumn
        With dcC19
            .ColumnName = "C19"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT19 As New DataColumn
        With dcT19
            .ColumnName = "T19"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcC20 As New DataColumn
        With dcC20
            .ColumnName = "C20"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcT20 As New DataColumn
        With dcT20
            .ColumnName = "T20"
            .DataType = GetType(String)
            .DefaultValue = " "
        End With

        Dim dcTotal As New DataColumn
        With dcTotal
            .ColumnName = "Total"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcCostUnit As New DataColumn
        With dcCostUnit
            .ColumnName = "CostUnit"
            .DataType = GetType(Double)
            .DefaultValue = 0
        End With

        Dim dcCostTotal As New DataColumn
        With dcCostTotal
            .ColumnName = "CostTotal"
            .DataType = GetType(Double)
            .DefaultValue = 0
        End With

        With Data.Columns

            .Add(dcCodArticulo)
            .Add(dcDescripcion)
            .Add(dcColor)
            .Add(dcCorrida)
            .Add(dcC1)
            .Add(dcT1)
            .Add(dcC2)
            .Add(dcT2)
            .Add(dcC3)
            .Add(dcT3)
            .Add(dcC4)
            .Add(dcT4)
            .Add(dcC5)
            .Add(dcT5)
            .Add(dcC6)
            .Add(dcT6)
            .Add(dcC7)
            .Add(dcT7)
            .Add(dcC8)
            .Add(dcT8)
            .Add(dcC9)
            .Add(dcT9)
            .Add(dcC10)
            .Add(dcT10)
            .Add(dcC11)
            .Add(dcT11)
            .Add(dcC12)
            .Add(dcT12)
            .Add(dcC13)
            .Add(dcT13)
            .Add(dcC14)
            .Add(dcT14)
            .Add(dcC15)
            .Add(dcT15)
            .Add(dcC16)
            .Add(dcT16)
            .Add(dcC17)
            .Add(dcT17)
            .Add(dcC18)
            .Add(dcT18)
            .Add(dcC19)
            .Add(dcT19)
            .Add(dcC20)
            .Add(dcT20)
            .Add(dcTotal)
            .Add(dcCostUnit)
            .Add(dcCostTotal)
        End With

    End Sub

    'Private Sub PrintPort(ByVal DataGen() As String, ByVal Data As DataTable, ByVal Letras As String, ByVal Observa As String)

    '    Dim strLine As String
    '    Dim TCantidad As Integer = 0
    '    Dim TCostoG As Decimal = 0
    '    Dim CountCod As Integer = 0
    '    Dim NPage As Integer = 1

    '    With oPrinterNET

    '        .PORT = "LPT1"

    '        .OpenPORT()

    '        '--Imprimimos Encabezado
    '        Encabezado(DataGen, NPage)
    '        For Each dr As DataRow In Data.Rows

    '            strLine = Chr(15) & Trim(dr!CodArticulo).PadRight("20", " ") & CStr(dr!T1).PadRight("5", " ") & CStr(dr!T2).PadRight("5", " ") & CStr(dr!T3).PadRight("5", " ") & CStr(dr!T4).PadRight("5", " ") & CStr(dr!T5).PadRight("5", " ") & CStr(dr!T6).PadRight("5", " ") & CStr(dr!T7).PadRight("5", " ") & CStr(dr!T8).PadRight("5", " ") & CStr(dr!T9).PadRight("5", " ") & CStr(dr!T10).PadRight("5", " ") & CStr(dr!T11).PadRight("5", " ") & CStr(dr!T12).PadRight("5", " ") & CStr(dr!T13).PadRight("5", " ") & CStr(dr!T14).PadRight("5", " ") & CStr(dr!T15).PadRight("5", " ") & CStr(dr!T16).PadRight("5", " ") & CStr(dr!T17).PadRight("5", " ") & CStr(dr!T18).PadRight("5", " ") & CStr(dr!T19).PadRight("5", " ") '& CStr(dr!T20).PadRight("5", " ")
    '            strLine = strLine & CStr(dr!Total).PadLeft(4, " ") & Format(dr!CostUnit, "###0.00").PadLeft(8, " ") & Format(dr!CostTotal, "#####0.00").PadLeft(10, " ")
    '            .PrintPORT(strLine & vbCrLf)
    '            strLine = Mid(dr!Descripcion, 1, 19).PadRight(20, " ") & CStr(dr!c1).PadRight("5", " ") & CStr(dr!c2).PadRight("5", " ") & CStr(dr!c3).PadRight("5", " ") & CStr(dr!c4).PadRight("5", " ") & CStr(dr!c5).PadRight("5", " ") & CStr(dr!c6).PadRight("5", " ") & CStr(dr!c7).PadRight("5", " ") & CStr(dr!c8).PadRight("5", " ") & CStr(dr!c9).PadRight("5", " ") & CStr(dr!c10).PadRight("5", " ") & CStr(dr!c11).PadRight("5", " ") & CStr(dr!c12).PadRight("5", " ") & CStr(dr!c13).PadRight("5", " ") & CStr(dr!c14).PadRight("5", " ") & CStr(dr!c15).PadRight("5", " ") & CStr(dr!c16).PadRight("5", " ") & CStr(dr!c17).PadRight("5", " ") & CStr(dr!c18).PadRight("5", " ") & CStr(dr!c19).PadRight("5", " ") & CStr(dr!c20).PadRight("5", " ")
    '            .PrintPORT(strLine & vbCrLf)

    '            CountCod += 1

    '            TCantidad += dr!Total
    '            TCostoG += dr!CostTotal

    '            If CountCod = 25 Then
    '                strLine = "".PadRight(137, "-") + Chr(12)
    '                .PrintPORT(strLine)
    '                NPage += 1
    '                Encabezado(DataGen, NPage)
    '                CountCod = 0
    '            End If

    '        Next

    '        If CountCod > 22 Then
    '            strLine = "".PadRight(137, "-") + Chr(12)
    '            .PrintPORT(strLine)
    '            NPage += 1
    '            Encabezado(DataGen, NPage)
    '        Else
    '            strLine = "".PadRight(137, "-")
    '            .PrintPORT(strLine & vbCrLf)
    '        End If

    '        strLine = Mid(Letras, 1, 70).PadRight(110, " ") & CStr(TCantidad).PadLeft(9, " ") & Format(TCostoG, "c").PadLeft(18, " ")
    '        .PrintPORT(strLine & vbCrLf)
    '        strLine = "Observaciones: " & Trim(Observa)
    '        .PrintPORT(strLine & vbCrLf)

    '        strLine = "".PadRight(137, "-")
    '        .PrintPORT(strLine & vbCrLf)
    '        strLine = "Este comprobante se expide para transportar mencancia entre  locales propios; conforme a lo  descrito en la  resolucion miscelanea fiscal"
    '        .PrintPORT(strLine & vbCrLf)
    '        strLine = "que rige al presente ejercicio fiscal. Asimismo,  mediante  este traspaso, se transporta mercancia importada  que NO ES VENTA DE PRIMERA,"
    '        .PrintPORT(strLine & vbCrLf)
    '        strLine = "esto conforme al Art.29-A del Codigo Fiscal de la Federacion, FRACCION VII." & Chr(18) + Chr(12)
    '        .PrintPORT(strLine & vbCrLf)

    '        .ClosePORT()

    '    End With


    'End Sub

    'Private Sub Encabezado(ByVal DataGen() As String, ByVal Numpag As Integer)

    '    Dim strLineGen As String

    '    With oPrinterNET
    '        strLineGen = Chr(18) + Chr(27) + Chr(80) + Space(30) & Chr(27) + Chr(69) + Chr(27) + Chr(45) + Chr(1) & "TRASPASO DE SALIDA" & Chr(27) + Chr(45) + Chr(0)
    '        .PrintPORT(strLineGen & vbCrLf)

    '        strLineGen = Chr(15) + ("Pag. :" & CStr(Numpag).Trim).PadLeft(125, " ")
    '        .PrintPORT(strLineGen & vbCrLf)

    '        strLineGen = "ORIGEN".PadRight(48, " ") + "DESTINO".PadRight(45, " ") + Chr(27) + Chr(70)
    '        .PrintPORT(strLineGen & vbCrLf)
    '        strLineGen = DataGen(0).PadRight(48, " ") + DataGen(1).PadRight(48, " ") + Chr(27) + Chr(69) + DataGen(2) + Chr(27) + Chr(70)
    '        .PrintPORT(strLineGen & vbCrLf)
    '        strLineGen = DataGen(3).PadRight(48, " ") + DataGen(4).PadRight(48, " ") + DataGen(5)
    '        .PrintPORT(strLineGen & vbCrLf)
    '        strLineGen = DataGen(6).PadRight(48, " ") + DataGen(7).PadRight(48, " ") + "Expedida en :" & Trim(DataGen(8))
    '        .PrintPORT(strLineGen & vbCrLf)
    '        strLineGen = DataGen(9).PadRight(48, " ") & DataGen(10).PadRight(48, " ") & DataGen(11)
    '        .PrintPORT(strLineGen & vbCrLf)
    '        strLineGen = "".PadRight(137, "-")
    '        .PrintPORT(strLineGen & vbCrLf)
    '        strLineGen = "Codigo/Descrip" + Space(10) + "Corridas" + Space(80) + " Cant. " + " Costo " + "   Total"
    '        .PrintPORT(strLineGen & vbCrLf)
    '        strLineGen = "".PadRight(137, "-")
    '        .PrintPORT(strLineGen & vbCrLf)
    '    End With

    'End Sub

#End Region

    Private Sub ebObservaciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.ebObservaciones.SelectedValue() = 8 Or Me.ebObservaciones.SelectedValue() = 11 Then
            Me.LblFolio.Visible = True
            Me.ebFolioObs.Visible = True
            Me.ebFolioObs.Focus()
        Else
            Me.LblFolio.Visible = False
            Me.ebFolioObs.Visible = False
            Me.ebFolioObs.Text = String.Empty
        End If

    End Sub

#Region "Facturacion SiHay"

    Private Function GetDataTableFormatNegadosSH(ByVal traspaso As DataTable) As DataTable
        Dim dtArticulos As New DataTable
        dtArticulos.Columns.Add("Codigo", GetType(String))
        dtArticulos.Columns.Add("Talla", GetType(String))
        dtArticulos.Columns.Add("Cantidad", GetType(Integer))
        For Each oRow As DataRow In traspaso.Rows
            Dim row As DataRow = dtArticulos.NewRow()
            row("Codigo") = CStr(oRow!CodArticulo)
            row("Talla") = CStr(oRow!Talla)
            row("Cantidad") = CInt(oRow!Cantidad)
            dtArticulos.Rows.Add(row)
        Next
        Return dtArticulos
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 08/05/2013: Envia el detalle con las cantidades libres Negadas
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function GetDetalleCantidadesLibres(ByVal dtDetalles As DataTable, ByVal dtMaterialesLibres As DataTable) As DataTable
        Dim dtArticulosLibres As DataTable = dtDetalles.Copy()
        dtArticulosLibres.Columns.Add("Libres", GetType(Integer))
        If Not dtMaterialesLibres Is Nothing Then
            For Each row As DataRow In dtArticulosLibres.Rows
                Dim codigo As String = CStr(row!CodArticulo)
                Dim talla As String = CStr(row!Talla)
                Dim cantidad As Integer = CInt(row!Cantidad)
                Dim suma As Decimal = dtMaterialesLibres.Compute("SUM(Libres)", "Codigo='" & codigo & "' AND Talla='" & talla & "'")
                row("Libres") = suma
            Next
            dtArticulosLibres.AcceptChanges()
        End If
        Return dtArticulosLibres
    End Function

#End Region
    Private Function GetTablaProducts() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("ID_PR_AC", GetType(String)))
        dt.Columns.Add(New DataColumn("Codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("Talla", GetType(String)))
        dt.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Lecturado", GetType(Integer)))

        Return dt
    End Function


    Private Function SaveZFMComAclaracion(strFolio As String, dtview As DataView, tipo As String) As DataTable
        Dim oParametros As New Dictionary(Of String, Object)
        Dim response As DataTable
        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        With oParametros
            Dim strCentro As String = oSap.Read_Centros
            Dim oLstProductos As New List(Of Dictionary(Of String, Object))
            For Each oRow As DataRowView In dtview
                '------------------------------------------------------------------
                ' Seteamos datos del detalle
                '------------------------------------------------------------------
                Dim oProducto As New Dictionary(Of String, Object)
                With oProducto
                    .Add("ID_PR_AC", CStr(oRow!ID_PR_AC))
                    .Add("CENTRO", strCentro)
                    .Add("MATERIAL", CStr(oRow!Codigo))
                    .Add("IDMOTIVO", "01")
                    .Add("TALLA", CStr(oRow!Talla))
                    .Add("ALMACEN", "M001")
                    .Add("MOTIVODES", "Traspaso Incompleto")
                    .Add("CANTIDAD", CInt(oRow("cantidad")))
                    .Add("TRASPASO", strFolio)
                    .Add("TIPOM", tipo)

                End With
                oLstProductos.Add(oProducto)
            Next
            '------------------------------------------------------------------
            ' Metemos los datos al detalle del objeto para serializarlo a JSON
            '------------------------------------------------------------------
            .Add("SapPtInputData", oLstProductos)

        End With


        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRetail As New ProcesosRetail("/pos_api/s1", "POST")
        response = oRetail.SapZfmcomAclaracion(oParametros)


        Return response

    End Function


    Public Function ProductosNoLecturados() As DataTable
        Dim dtNoLecturados As New DataTable("NoLecturados")
        dtNoLecturados.Columns.Add("CodArticulo", GetType(String))
        dtNoLecturados.Columns.Add("Descripcion", GetType(String))
        dtNoLecturados.AcceptChanges()
        Return dtNoLecturados
    End Function

    Private Function ValidarProductos(ByVal dtArticulos As DataTable) As Boolean
        Dim oCatalogoArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim bReturn As Boolean = True
        Dim dtResult As DataTable
        Dim dtNoLecturados As DataTable = ProductosNoLecturados()


        For Each row As DataRow In dtArticulos.Rows
            dtResult = oCatalogoArticuloMgr.GetArticulosNoLeturados(row!CodArticulo, Me.ebTraspasoCF.Text)
            If dtResult.Rows.Count = 0 Then
                Dim fila As DataRow = dtNoLecturados.NewRow()
                fila("CodArticulo") = row!CodArticulo
                fila("Descripcion") = row!Descripcion
                dtNoLecturados.Rows.Add(fila)
            End If
        Next

        If Not dtNoLecturados Is Nothing AndAlso dtNoLecturados.Rows.Count > 0 Then
            ShowFormMessage(dtNoLecturados, "Información incompleta en artículos no lecturados, favor de contactar a soporte.", GetAtributosMaterialesNoEncontrados())
            bReturn = False
        End If

        Return bReturn
    End Function


    Private Sub DesmarcarCodigosSAP(dtArticulos As DataTable)
        Dim oCatalogoArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim dtResult As DataTable
        Dim dtDatos As DataTable = GetTablaProducts()
        Dim dr As DataRow
        Dim oTraspasoEntradaMgr As TraspasosEntradaManager
        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)


        'Obtener la información para ejecutar la RFC
        For Each row As DataRow In dtArticulos.Rows
            dtResult = oCatalogoArticuloMgr.GetArticulosNoLeturados(row!CodArticulo, Me.ebTraspasoCF.Text)
            If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
                Dim oRow As DataRow = dtResult.Rows(0)
                If (oRow!ID_PR_AC).ToString.Length > 0 Then
                    dr = dtDatos.NewRow()
                    dr("ID_PR_AC") = oRow!ID_PR_AC
                    dr("Codigo") = row!CodArticulo
                    dr("Talla") = oRow!Talla
                    dr("Cantidad") = row!Cantidad
                    dr("Lecturado") = 0
                    dtDatos.Rows.Add(dr)
                End If

                '-----------------------------------------------------------------------------------------------------------------------------
                ' MLVARGAS 12/07/2022: Actualizar la cantidad y cantidad aclarada en la tabla de "ArticulosAclaracion"
                '-----------------------------------------------------------------------------------------------------------------------------
                oTraspasoEntradaMgr.UpdateArtAclaracion(Me.ebTraspasoCF.Text.Trim, row!CodArticulo, row!Cantidad)
            End If
        Next row

        Dim view As New DataView(dtDatos)
        Dim dtRFC As DataTable
        If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
            'dtResult = oSap.ZFMCOM_ACLARACION(Me.ebTraspasoCF.Text, view, "E")
            dtResult = SaveZFMComAclaracion(Me.ebTraspasoCF.Text, view, "E")
        End If
    End Sub

    Private Sub frmInvAuditoria_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        oTraspasoSalidaMgr = New TraspasosSalidaManager(oAppContext)

        oCatalogoAlmacenMgr = New CatalogoAlmacenesManager(oAppContext)

        oCatalogoTransportistasMgr = New CatalogoTransportistaManager(oAppContext)

        oCatalogoTipoMonedaMgr = New CatalogoTipoMonedaManager(oAppContext)

        odsCatalogoCorridas = oTraspasoSalidaMgr.ExtraerCatalogoCorridas

        oTraspasoSalidaMgr.CrearTablaTmp()

        Sm_Nuevo()

        '***
        Me.ebSucDestinoCod.Text = "1000"
        Me.ebSucDestinoDesc.Text = "Almacen General - C. DIST."


        ebResponsable.Text = oAppContext.Security.CurrentUser.Name
        strResponsableID = oAppContext.Security.CurrentUser.SessionLoginName
        '***
    End Sub

    Private Sub frmInvAuditoria_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")


            Case Keys.Escape

                bolSalir = True
                Me.Finalize()
                Me.Close()


            Case Keys.F2

                Sm_GuardarTraspaso()


            Case Keys.F9

                Sm_GuardarTraspaso(True)

        End Select

    End Sub
End Class
