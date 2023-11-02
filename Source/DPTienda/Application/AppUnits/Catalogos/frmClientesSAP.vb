Imports System.Data
Imports System.Windows.Forms
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta
Imports System.Text
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Web.Mail
Imports System.Collections.Generic

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Linq.JArray


Public Class frmClientesSAP
    Inherits System.Windows.Forms.Form

    Private m_intCodigoClienteDPVALE As Integer
    Dim res As UInt32

    Dim EsClienteRetail As Boolean
    Dim EsClienteAFS As Boolean

    '-----------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/09/2018: Valida si es para activar el approval
    '-----------------------------------------------------------------------------------------------------
    Private m_EsClienteApproval As Boolean
    Private m_ActivacionPuntos As Boolean

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()


        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        InitializeObjects()
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
    Friend WithEvents ebApellidoMaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ebTipoVenta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebClienteID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ebRFC As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ebCodAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebCiudad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebEstadoCivil As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblLabel25 As System.Windows.Forms.Label
    Friend WithEvents ebTelefono As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ebColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebApellidoPaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSexo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ebDomicilio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ebEmail As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkStatus As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebRecordCreateBy As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ebRecordCreateOn As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents pbActivo As System.Windows.Forms.PictureBox
    Friend WithEvents pbInactivo As System.Windows.Forms.PictureBox
    Friend WithEvents menuBarTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimirTarjeta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimirTarjeta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ebCodVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPlayerDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents cmbFechaNac As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebCP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel14 As System.Windows.Forms.Label
    Friend WithEvents pbAvance As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents exbGuardarCliente As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebNumExt As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ebNumInt As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkEmpresa As Janus.Windows.EditControls.UICheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientesSAP))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.chkEmpresa = New Janus.Windows.EditControls.UICheckBox()
        Me.ebNumInt = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ebNumExt = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.exbGuardarCliente = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.pbAvance = New Janus.Windows.EditControls.UIProgressBar()
        Me.lblLabel14 = New System.Windows.Forms.Label()
        Me.ebCP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.cmbFechaNac = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ebPlayerDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodVendedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pbActivo = New System.Windows.Forms.PictureBox()
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebRecordCreateBy = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ebRecordCreateOn = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ebApellidoMaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ebTipoVenta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebClienteID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ebRFC = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.ebCodAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebCiudad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebEstadoCivil = New Janus.Windows.EditControls.UIComboBox()
        Me.lblLabel25 = New System.Windows.Forms.Label()
        Me.ebTelefono = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ebColonia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebApellidoPaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSexo = New Janus.Windows.EditControls.UIComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ebDomicilio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ebEmail = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkStatus = New Janus.Windows.EditControls.UICheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pbInactivo = New System.Windows.Forms.PictureBox()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoSalir2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoEliminar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimirTarjeta1 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimirTarjeta")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTema2 = New Janus.Windows.UI.CommandBars.UICommand("menuBarTema")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoEliminar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuBarTema")
        Me.menuBarTema = New Janus.Windows.UI.CommandBars.UICommand("menuBarTema")
        Me.menuImprimirTarjeta = New Janus.Windows.UI.CommandBars.UICommand("menuImprimirTarjeta")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.exbGuardarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exbGuardarCliente.SuspendLayout()
        CType(Me.pbActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        CType(Me.pbInactivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.chkEmpresa)
        Me.ExplorerBar1.Controls.Add(Me.ebNumInt)
        Me.ExplorerBar1.Controls.Add(Me.Label15)
        Me.ExplorerBar1.Controls.Add(Me.ebNumExt)
        Me.ExplorerBar1.Controls.Add(Me.Label14)
        Me.ExplorerBar1.Controls.Add(Me.exbGuardarCliente)
        Me.ExplorerBar1.Controls.Add(Me.ebCP)
        Me.ExplorerBar1.Controls.Add(Me.cmbFechaNac)
        Me.ExplorerBar1.Controls.Add(Me.ebPlayerDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.ebCodVendedor)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.pbActivo)
        Me.ExplorerBar1.Controls.Add(Me.ExplorerBar3)
        Me.ExplorerBar1.Controls.Add(Me.ebApellidoMaterno)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.ebTipoVenta)
        Me.ExplorerBar1.Controls.Add(Me.ebClienteID)
        Me.ExplorerBar1.Controls.Add(Me.Label26)
        Me.ExplorerBar1.Controls.Add(Me.ebRFC)
        Me.ExplorerBar1.Controls.Add(Me.Label25)
        Me.ExplorerBar1.Controls.Add(Me.lblStatus)
        Me.ExplorerBar1.Controls.Add(Me.ebCodAlmacen)
        Me.ExplorerBar1.Controls.Add(Me.ebCiudad)
        Me.ExplorerBar1.Controls.Add(Me.ebEstado)
        Me.ExplorerBar1.Controls.Add(Me.ebEstadoCivil)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel25)
        Me.ExplorerBar1.Controls.Add(Me.ebTelefono)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label20)
        Me.ExplorerBar1.Controls.Add(Me.Label19)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        Me.ExplorerBar1.Controls.Add(Me.ebColonia)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.ebApellidoPaterno)
        Me.ExplorerBar1.Controls.Add(Me.ebSexo)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.ebDomicilio)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.ebEmail)
        Me.ExplorerBar1.Controls.Add(Me.ebNombre)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.chkStatus)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Controls.Add(Me.pbInactivo)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup2.ContainerHeight = 100
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Datos Generales Clientes"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(578, 470)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'chkEmpresa
        '
        Me.chkEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.chkEmpresa.Enabled = False
        Me.chkEmpresa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmpresa.Location = New System.Drawing.Point(416, 89)
        Me.chkEmpresa.Name = "chkEmpresa"
        Me.chkEmpresa.Size = New System.Drawing.Size(144, 24)
        Me.chkEmpresa.TabIndex = 198
        Me.chkEmpresa.Text = "Es Empresa"
        Me.chkEmpresa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNumInt
        '
        Me.ebNumInt.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumInt.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumInt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNumInt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumInt.Location = New System.Drawing.Point(384, 185)
        Me.ebNumInt.MaxLength = 50
        Me.ebNumInt.Name = "ebNumInt"
        Me.ebNumInt.Size = New System.Drawing.Size(112, 22)
        Me.ebNumInt.TabIndex = 8
        Me.ebNumInt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumInt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(264, 185)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 23)
        Me.Label15.TabIndex = 197
        Me.Label15.Text = "Número Interior:"
        '
        'ebNumExt
        '
        Me.ebNumExt.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumExt.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumExt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNumExt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumExt.Location = New System.Drawing.Point(136, 185)
        Me.ebNumExt.MaxLength = 50
        Me.ebNumExt.Name = "ebNumExt"
        Me.ebNumExt.Size = New System.Drawing.Size(112, 22)
        Me.ebNumExt.TabIndex = 7
        Me.ebNumExt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumExt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 185)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 23)
        Me.Label14.TabIndex = 195
        Me.Label14.Text = "Número Exterior:"
        '
        'exbGuardarCliente
        '
        Me.exbGuardarCliente.Controls.Add(Me.pbAvance)
        Me.exbGuardarCliente.Controls.Add(Me.lblLabel14)
        Me.exbGuardarCliente.Location = New System.Drawing.Point(552, 192)
        Me.exbGuardarCliente.Name = "exbGuardarCliente"
        Me.exbGuardarCliente.Size = New System.Drawing.Size(328, 96)
        Me.exbGuardarCliente.TabIndex = 193
        Me.exbGuardarCliente.Text = "ExplorerBar2"
        Me.exbGuardarCliente.Visible = False
        Me.exbGuardarCliente.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'pbAvance
        '
        Me.pbAvance.Location = New System.Drawing.Point(8, 40)
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.ShowPercentage = True
        Me.pbAvance.Size = New System.Drawing.Size(312, 32)
        Me.pbAvance.TabIndex = 2
        Me.pbAvance.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblLabel14
        '
        Me.lblLabel14.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel14.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel14.Location = New System.Drawing.Point(8, 8)
        Me.lblLabel14.Name = "lblLabel14"
        Me.lblLabel14.Size = New System.Drawing.Size(200, 40)
        Me.lblLabel14.TabIndex = 1
        Me.lblLabel14.Text = "Guardando Cliente ..."
        '
        'ebCP
        '
        Me.ebCP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCP.ButtonImage = CType(resources.GetObject("ebCP.ButtonImage"), System.Drawing.Image)
        Me.ebCP.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCP.Location = New System.Drawing.Point(400, 233)
        Me.ebCP.MaxLength = 5
        Me.ebCP.Name = "ebCP"
        Me.ebCP.Size = New System.Drawing.Size(96, 22)
        Me.ebCP.TabIndex = 12
        Me.ebCP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbFechaNac
        '
        '
        '
        '
        Me.cmbFechaNac.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFechaNac.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFechaNac.Location = New System.Drawing.Point(384, 308)
        Me.cmbFechaNac.Name = "cmbFechaNac"
        Me.cmbFechaNac.Size = New System.Drawing.Size(112, 23)
        Me.cmbFechaNac.TabIndex = 17
        Me.cmbFechaNac.TodayButtonText = "Hoy"
        Me.cmbFechaNac.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ebPlayerDescripcion
        '
        Me.ebPlayerDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerDescripcion.BackColor = System.Drawing.SystemColors.Info
        Me.ebPlayerDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebPlayerDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayerDescripcion.Location = New System.Drawing.Point(243, 399)
        Me.ebPlayerDescripcion.MaxLength = 30
        Me.ebPlayerDescripcion.Name = "ebPlayerDescripcion"
        Me.ebPlayerDescripcion.ReadOnly = True
        Me.ebPlayerDescripcion.Size = New System.Drawing.Size(184, 22)
        Me.ebPlayerDescripcion.TabIndex = 28
        Me.ebPlayerDescripcion.TabStop = False
        Me.ebPlayerDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerDescripcion.Visible = False
        Me.ebPlayerDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodVendedor
        '
        Me.ebCodVendedor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodVendedor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodVendedor.ButtonImage = CType(resources.GetObject("ebCodVendedor.ButtonImage"), System.Drawing.Image)
        Me.ebCodVendedor.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodVendedor.Location = New System.Drawing.Point(163, 399)
        Me.ebCodVendedor.Name = "ebCodVendedor"
        Me.ebCodVendedor.Size = New System.Drawing.Size(72, 22)
        Me.ebCodVendedor.TabIndex = 2
        Me.ebCodVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodVendedor.Visible = False
        Me.ebCodVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(43, 399)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 23)
        Me.Label13.TabIndex = 190
        Me.Label13.Text = "Cod Vendedor"
        Me.Label13.Visible = False
        '
        'pbActivo
        '
        Me.pbActivo.BackColor = System.Drawing.Color.Transparent
        Me.pbActivo.Image = CType(resources.GetObject("pbActivo.Image"), System.Drawing.Image)
        Me.pbActivo.Location = New System.Drawing.Point(536, 56)
        Me.pbActivo.Name = "pbActivo"
        Me.pbActivo.Size = New System.Drawing.Size(24, 24)
        Me.pbActivo.TabIndex = 188
        Me.pbActivo.TabStop = False
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.ebRecordCreateBy)
        Me.ExplorerBar3.Controls.Add(Me.Label5)
        Me.ExplorerBar3.Controls.Add(Me.ebRecordCreateOn)
        Me.ExplorerBar3.Controls.Add(Me.Label22)
        Me.ExplorerBar3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Registro"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar3.Location = New System.Drawing.Point(0, 408)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(674, 216)
        Me.ExplorerBar3.TabIndex = 185
        Me.ExplorerBar3.TabStop = False
        Me.ExplorerBar3.Text = "ExplorerBar3"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebRecordCreateBy
        '
        Me.ebRecordCreateBy.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebRecordCreateBy.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebRecordCreateBy.BackColor = System.Drawing.Color.Ivory
        Me.ebRecordCreateBy.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebRecordCreateBy.Location = New System.Drawing.Point(173, 37)
        Me.ebRecordCreateBy.Name = "ebRecordCreateBy"
        Me.ebRecordCreateBy.ReadOnly = True
        Me.ebRecordCreateBy.Size = New System.Drawing.Size(144, 22)
        Me.ebRecordCreateBy.TabIndex = 2
        Me.ebRecordCreateBy.TabStop = False
        Me.ebRecordCreateBy.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRecordCreateBy.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(58, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 23)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Usuario:"
        '
        'ebRecordCreateOn
        '
        Me.ebRecordCreateOn.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebRecordCreateOn.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebRecordCreateOn.BackColor = System.Drawing.Color.Ivory
        Me.ebRecordCreateOn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebRecordCreateOn.Location = New System.Drawing.Point(442, 37)
        Me.ebRecordCreateOn.Name = "ebRecordCreateOn"
        Me.ebRecordCreateOn.ReadOnly = True
        Me.ebRecordCreateOn.Size = New System.Drawing.Size(96, 22)
        Me.ebRecordCreateOn.TabIndex = 3
        Me.ebRecordCreateOn.TabStop = False
        Me.ebRecordCreateOn.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebRecordCreateOn.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(330, 39)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 23)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Fecha Registro:"
        '
        'ebApellidoMaterno
        '
        Me.ebApellidoMaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebApellidoMaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebApellidoMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebApellidoMaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebApellidoMaterno.Location = New System.Drawing.Point(136, 137)
        Me.ebApellidoMaterno.MaxLength = 30
        Me.ebApellidoMaterno.Name = "ebApellidoMaterno"
        Me.ebApellidoMaterno.Size = New System.Drawing.Size(264, 22)
        Me.ebApellidoMaterno.TabIndex = 5
        Me.ebApellidoMaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebApellidoMaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 137)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 23)
        Me.Label12.TabIndex = 183
        Me.Label12.Text = "Apellido Materno:"
        '
        'ebTipoVenta
        '
        Me.ebTipoVenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.ebTipoVenta.DesignTimeLayout = GridEXLayout1
        Me.ebTipoVenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTipoVenta.Location = New System.Drawing.Point(136, 40)
        Me.ebTipoVenta.Name = "ebTipoVenta"
        Me.ebTipoVenta.Size = New System.Drawing.Size(176, 22)
        Me.ebTipoVenta.TabIndex = 0
        Me.ebTipoVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTipoVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebClienteID
        '
        Me.ebClienteID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteID.ButtonImage = CType(resources.GetObject("ebClienteID.ButtonImage"), System.Drawing.Image)
        Me.ebClienteID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebClienteID.Location = New System.Drawing.Point(136, 64)
        Me.ebClienteID.MaxLength = 10
        Me.ebClienteID.Name = "ebClienteID"
        Me.ebClienteID.Size = New System.Drawing.Size(176, 22)
        Me.ebClienteID.TabIndex = 1
        Me.ebClienteID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebClienteID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(16, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(104, 23)
        Me.Label26.TabIndex = 181
        Me.Label26.Text = "Tipo Cliente:"
        '
        'ebRFC
        '
        Me.ebRFC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebRFC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebRFC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebRFC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebRFC.Location = New System.Drawing.Point(136, 353)
        Me.ebRFC.Name = "ebRFC"
        Me.ebRFC.Size = New System.Drawing.Size(136, 22)
        Me.ebRFC.TabIndex = 19
        Me.ebRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRFC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(16, 353)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(80, 23)
        Me.Label25.TabIndex = 180
        Me.Label25.Text = "RFC:"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(456, 64)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(72, 23)
        Me.lblStatus.TabIndex = 146
        Me.lblStatus.Text = "ACTIVO"
        '
        'ebCodAlmacen
        '
        Me.ebCodAlmacen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodAlmacen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.ebCodAlmacen.DesignTimeLayout = GridEXLayout2
        Me.ebCodAlmacen.Enabled = False
        Me.ebCodAlmacen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodAlmacen.Location = New System.Drawing.Point(136, 329)
        Me.ebCodAlmacen.Name = "ebCodAlmacen"
        Me.ebCodAlmacen.ReadOnly = True
        Me.ebCodAlmacen.Size = New System.Drawing.Size(136, 22)
        Me.ebCodAlmacen.TabIndex = 18
        Me.ebCodAlmacen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCiudad
        '
        Me.ebCiudad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCiudad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCiudad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.ebCiudad.DesignTimeLayout = GridEXLayout3
        Me.ebCiudad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCiudad.Location = New System.Drawing.Point(136, 257)
        Me.ebCiudad.Name = "ebCiudad"
        Me.ebCiudad.Size = New System.Drawing.Size(192, 22)
        Me.ebCiudad.TabIndex = 11
        Me.ebCiudad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCiudad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebEstado
        '
        Me.ebEstado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEstado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.ebEstado.DesignTimeLayout = GridEXLayout4
        Me.ebEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEstado.Location = New System.Drawing.Point(136, 233)
        Me.ebEstado.Name = "ebEstado"
        Me.ebEstado.Size = New System.Drawing.Size(192, 22)
        Me.ebEstado.TabIndex = 10
        Me.ebEstado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebEstadoCivil
        '
        Me.ebEstadoCivil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebEstadoCivil.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebEstadoCivil.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "SOLTERO(A)"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "CASADO(A)"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "VIUDO(A)"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "DIVORCIADO(A)"
        Me.ebEstadoCivil.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4})
        Me.ebEstadoCivil.Location = New System.Drawing.Point(136, 305)
        Me.ebEstadoCivil.Name = "ebEstadoCivil"
        Me.ebEstadoCivil.Size = New System.Drawing.Size(136, 22)
        Me.ebEstadoCivil.TabIndex = 16
        Me.ebEstadoCivil.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblLabel25
        '
        Me.lblLabel25.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel25.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel25.Location = New System.Drawing.Point(16, 305)
        Me.lblLabel25.Name = "lblLabel25"
        Me.lblLabel25.Size = New System.Drawing.Size(112, 23)
        Me.lblLabel25.TabIndex = 178
        Me.lblLabel25.Text = "Estado Civil :"
        '
        'ebTelefono
        '
        Me.ebTelefono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTelefono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebTelefono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTelefono.Location = New System.Drawing.Point(400, 257)
        Me.ebTelefono.Mask = "!(###) 000-0000"
        Me.ebTelefono.Name = "ebTelefono"
        Me.ebTelefono.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ebTelefono.Size = New System.Drawing.Size(96, 22)
        Me.ebTelefono.TabIndex = 13
        Me.ebTelefono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTelefono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(334, 262)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(66, 16)
        Me.Label21.TabIndex = 177
        Me.Label21.Text = "Telefono:"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(338, 239)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 23)
        Me.Label20.TabIndex = 176
        Me.Label20.Text = "C.P. :"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(16, 233)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 23)
        Me.Label19.TabIndex = 175
        Me.Label19.Text = "Estado:"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 257)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(120, 23)
        Me.Label18.TabIndex = 174
        Me.Label18.Text = "Ciudad:"
        '
        'ebColonia
        '
        Me.ebColonia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebColonia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebColonia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebColonia.Location = New System.Drawing.Point(136, 209)
        Me.ebColonia.MaxLength = 50
        Me.ebColonia.Name = "ebColonia"
        Me.ebColonia.Size = New System.Drawing.Size(360, 22)
        Me.ebColonia.TabIndex = 9
        Me.ebColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 209)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 23)
        Me.Label17.TabIndex = 173
        Me.Label17.Text = "Colonia:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 23)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "Apellido Paterno:"
        '
        'ebApellidoPaterno
        '
        Me.ebApellidoPaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebApellidoPaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebApellidoPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebApellidoPaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebApellidoPaterno.Location = New System.Drawing.Point(136, 113)
        Me.ebApellidoPaterno.MaxLength = 30
        Me.ebApellidoPaterno.Name = "ebApellidoPaterno"
        Me.ebApellidoPaterno.Size = New System.Drawing.Size(264, 22)
        Me.ebApellidoPaterno.TabIndex = 4
        Me.ebApellidoPaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebApellidoPaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSexo
        '
        Me.ebSexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebSexo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebSexo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "M"
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "F"
        Me.ebSexo.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem5, UiComboBoxItem6})
        Me.ebSexo.Location = New System.Drawing.Point(432, 281)
        Me.ebSexo.Name = "ebSexo"
        Me.ebSexo.Size = New System.Drawing.Size(64, 22)
        Me.ebSexo.TabIndex = 15
        Me.ebSexo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 329)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 23)
        Me.Label10.TabIndex = 169
        Me.Label10.Text = "Tienda:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(272, 314)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 23)
        Me.Label9.TabIndex = 168
        Me.Label9.Text = "Fecha de Nacim.:"
        '
        'ebDomicilio
        '
        Me.ebDomicilio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDomicilio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDomicilio.Location = New System.Drawing.Point(136, 161)
        Me.ebDomicilio.MaxLength = 50
        Me.ebDomicilio.Name = "ebDomicilio"
        Me.ebDomicilio.Size = New System.Drawing.Size(360, 22)
        Me.ebDomicilio.TabIndex = 6
        Me.ebDomicilio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDomicilio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 23)
        Me.Label8.TabIndex = 165
        Me.Label8.Text = "Calle:"
        '
        'ebEmail
        '
        Me.ebEmail.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEmail.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.ebEmail.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEmail.Location = New System.Drawing.Point(136, 281)
        Me.ebEmail.MaxLength = 50
        Me.ebEmail.Name = "ebEmail"
        Me.ebEmail.Size = New System.Drawing.Size(240, 22)
        Me.ebEmail.TabIndex = 14
        Me.ebEmail.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEmail.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombre
        '
        Me.ebNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombre.Location = New System.Drawing.Point(136, 89)
        Me.ebNombre.MaxLength = 30
        Me.ebNombre.Name = "ebNombre"
        Me.ebNombre.Size = New System.Drawing.Size(264, 22)
        Me.ebNombre.TabIndex = 3
        Me.ebNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 281)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 157
        Me.Label7.Text = "E-mail:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(386, 286)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 23)
        Me.Label6.TabIndex = 154
        Me.Label6.Text = "Sexo:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 23)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "Codigo:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "Nombre:"
        '
        'chkStatus
        '
        Me.chkStatus.BackColor = System.Drawing.Color.Transparent
        Me.chkStatus.Location = New System.Drawing.Point(432, 399)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(72, 16)
        Me.chkStatus.TabIndex = 179
        Me.chkStatus.TabStop = False
        Me.chkStatus.Text = "Status"
        Me.chkStatus.Visible = False
        Me.chkStatus.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 172
        Me.Label3.Text = "Apellido Paterno:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 136)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 23)
        Me.Label11.TabIndex = 170
        Me.Label11.Text = "Apellido Paterno:"
        '
        'pbInactivo
        '
        Me.pbInactivo.BackColor = System.Drawing.Color.Transparent
        Me.pbInactivo.Image = CType(resources.GetObject("pbInactivo.Image"), System.Drawing.Image)
        Me.pbInactivo.Location = New System.Drawing.Point(536, 56)
        Me.pbInactivo.Name = "pbInactivo"
        Me.pbInactivo.Size = New System.Drawing.Size(24, 24)
        Me.pbInactivo.TabIndex = 189
        Me.pbInactivo.TabStop = False
        Me.pbInactivo.Visible = False
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuArchivoNuevo, Me.menuArchivoSalir, Me.menuArchivoGuardar, Me.menuArchivoEliminar, Me.menuAyuda, Me.menuBarTema, Me.menuImprimirTarjeta})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("17f7cab3-14ba-48ec-842c-0de6c09c929f")
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.Separator1, Me.menuAyuda1, Me.Separator8, Me.menuArchivoSalir2})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(578, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        Me.UiCommandBar1.Visible = False
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuAyuda1
        '
        Me.menuAyuda1.Key = "menuAyuda"
        Me.menuAyuda1.Name = "menuAyuda1"
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'menuArchivoSalir2
        '
        Me.menuArchivoSalir2.Key = "menuArchivoSalir"
        Me.menuArchivoSalir2.Name = "menuArchivoSalir2"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.Separator5, Me.menuArchivoGuardar2, Me.Separator6, Me.menuArchivoEliminar2, Me.Separator7, Me.menuImprimirTarjeta1, Me.Separator3, Me.Separator9, Me.menuAyudaTema2, Me.Separator10, Me.menuArchivoSalir1})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(206, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
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
        'menuArchivoEliminar2
        '
        Me.menuArchivoEliminar2.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar2.Name = "menuArchivoEliminar2"
        Me.menuArchivoEliminar2.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'menuImprimirTarjeta1
        '
        Me.menuImprimirTarjeta1.Key = "menuImprimirTarjeta"
        Me.menuImprimirTarjeta1.Name = "menuImprimirTarjeta1"
        Me.menuImprimirTarjeta1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'menuAyudaTema2
        '
        Me.menuAyudaTema2.Key = "menuBarTema"
        Me.menuAyudaTema2.Name = "menuAyudaTema2"
        Me.menuAyudaTema2.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'menuArchivoSalir1
        '
        Me.menuArchivoSalir1.Icon = CType(resources.GetObject("menuArchivoSalir1.Icon"), System.Drawing.Icon)
        Me.menuArchivoSalir1.Key = "menuArchivoSalir"
        Me.menuArchivoSalir1.Name = "menuArchivoSalir1"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.Separator2, Me.menuArchivoGuardar1, Me.Separator4, Me.menuArchivoEliminar1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuArchivoGuardar1
        '
        Me.menuArchivoGuardar1.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuArchivoEliminar1
        '
        Me.menuArchivoEliminar1.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar1.Name = "menuArchivoEliminar1"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Image = CType(resources.GetObject("menuArchivoNuevo.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "Salir"
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
        Me.menuArchivoEliminar.Text = "&Eliminar"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "A&yuda"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.Key = "menuBarTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        '
        'menuBarTema
        '
        Me.menuBarTema.Image = CType(resources.GetObject("menuBarTema.Image"), System.Drawing.Image)
        Me.menuBarTema.Key = "menuBarTema"
        Me.menuBarTema.Name = "menuBarTema"
        Me.menuBarTema.Text = "&Temas de Ayuda"
        '
        'menuImprimirTarjeta
        '
        Me.menuImprimirTarjeta.Image = CType(resources.GetObject("menuImprimirTarjeta.Image"), System.Drawing.Image)
        Me.menuImprimirTarjeta.Key = "menuImprimirTarjeta"
        Me.menuImprimirTarjeta.Name = "menuImprimirTarjeta"
        Me.menuImprimirTarjeta.Text = "&Imprimir Tarjeta"
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
        Me.TopRebar1.Size = New System.Drawing.Size(578, 50)
        '
        'frmClientesSAP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(578, 520)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(584, 520)
        Me.Name = "frmClientesSAP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogo Clientes"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.exbGuardarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exbGuardarCliente.ResumeLayout(False)
        CType(Me.pbActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        CType(Me.pbInactivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private m_strTipoVenta As String

#Region "Environment Var"

    Dim vClienteID As Integer = 0
    Dim esInstanciaAsociado As Boolean = False
    Dim esInstanciaFactura As Boolean = False

    Public pubClienteID As Integer = 0
    Public PubNombreCliente As String = String.Empty

    'Objeto Cliente
    Dim oClienteMgr As ClientesManager
    Public oCliente As ClienteAlterno

    'Objetos DataTable
    Dim dtEstados As DataTable
    Private dtMunicipio As DataTable
    Private dtAlmacen As DataTable
    Dim dtPlazas As DataTable

    Private rango1, rango2, rango1DF, rango2DF As Integer
    Private dsCodigos As New DataSet
    Private dsCodigosDF As New DataSet
    Private bandNuevo As Boolean = False 'True.- Mover foco
    Private bandera As Boolean = True
    Dim dsTipoVenta As New DataSet           'Dataset para cargar los tipos de venta
    Dim oTipoVentaMgr As TiposVentaManager

    ''Bandera Final...
    Dim bolClickMenu As Boolean = False

    'Objeto Player
    Dim oVendedoresMgr As CatalogoVendedoresManager
    Dim oVendedor As Vendedor

    Dim oSAPMgr As ProcesoSAPManager

    Dim bClickBuscar As Boolean = False
    Private strTipoVenta As String = ""

#End Region

#Region "Variables S2Credit"

    '----------------------------------------------------------
    ' JNAVA (16.03.2016): Objetos para S2Credit
    '----------------------------------------------------------
    'Public oInfoClienteS2C As Dictionary(Of String, Object) 'InfoClienteS2Credit
    Dim oClienteResS2C As List(Of Dictionary(Of String, Object)) 'ResultadoClienteS2Credit
    'Dim IDEstado As String = String.Empty
    Dim oS2Credit As New ProcesosS2Credit

#End Region

#Region "Initialize"

    Private Sub InitializeObjects()
        'Finger
        'Dim Version As New NBioAPI.Type.VERSION

        oClienteMgr = New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        oCliente = oClienteMgr.CreateAlterno
        'Clear Fields
        oCliente.Clear()
        'oCliente.TipoVenta = Me.TipoVenta

        'Objeto Vendedores
        oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
        oVendedor = oVendedoresMgr.Create

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        'Finger
        'm_NBioAPi.GetVersion(Version)

    End Sub

    Private Sub InitializeBinding()

        'Datos Generales Cliente
        ebClienteID.DataBindings.Add(New Binding("Text", oCliente, "CodigoAlterno"))
        ebNombre.DataBindings.Add(New Binding("Text", oCliente, "Nombre"))
        Me.ebApellidoPaterno.DataBindings.Add(New Binding("Text", oCliente, "ApellidoPaterno"))
        Me.ebApellidoMaterno.DataBindings.Add(New Binding("Text", oCliente, "ApellidoMaterno"))
        ebSexo.DataBindings.Add(New Binding("Text", oCliente, "Sexo"))
        ebEstadoCivil.DataBindings.Add(New Binding("Text", oCliente, "EstadoCivil"))
        ebDomicilio.DataBindings.Add(New Binding("Text", oCliente, "Direccion"))
        ebEstado.DataBindings.Add(New Binding("Value", oCliente, "Estado"))
        ebCiudad.DataBindings.Add(New Binding("Text", oCliente, "Ciudad"))
        ebColonia.DataBindings.Add(New Binding("Text", oCliente, "Colonia"))
        ebCP.DataBindings.Add(New Binding("Text", oCliente, "CP"))
        ebTelefono.DataBindings.Add(New Binding("Text", oCliente, "Telefono"))
        'ebFechaNac.DataBindings.Add(New Binding("Value", oCliente, "FechaNacimiento"))
        cmbFechaNac.DataBindings.Add(New Binding("Value", oCliente, "FechaNacimiento"))
        ebEmail.DataBindings.Add(New Binding("Text", oCliente, "Email"))
        ebCodAlmacen.DataBindings.Add(New Binding("Text", oCliente, "CodAlmacen"))
        chkStatus.DataBindings.Add(New Binding("Checked", oCliente, "RecordEnabled"))
        Me.ebRFC.DataBindings.Add(New Binding("Text", oCliente, "RFC"))
        'Me.ebTipoVenta.DataBindings.Add(New Binding("Value", oCliente, "TipoVenta"))
        Me.ebNumExt.DataBindings.Add(New Binding("Text", oCliente, "NumExt"))
        Me.ebNumInt.DataBindings.Add(New Binding("Text", oCliente, "NumInt"))
        'Me.chkFacturar.DataBindings.Add(New Binding("Checked", oCliente, "Fiscal"))
    End Sub

#End Region

#Region "Properties"

    'Uso : 
    '       Se utilizan paran indicar que se llama desde el Módulo Contratos, y generar 
    '       una consulta de un Cliente especifico.


    Private bolModuloContrato As Boolean
    Private intClienteID As String = ""
    Private m_strNombreApellidos As String

    Private bolFactDIpsUpdate As Boolean
    Private StrPlayer As String
    Public TipoCliente As String = ""

    Public EsDPVale As Boolean = False

    Public WriteOnly Property FactDIpsUpdate() As Boolean

        Set(ByVal Value As Boolean)

            bolFactDIpsUpdate = Value

        End Set

    End Property


    Public WriteOnly Property Player() As String

        Set(ByVal Value As String)

            StrPlayer = Value

        End Set

    End Property

    Public WriteOnly Property ModuloContrato() As Boolean

        Set(ByVal Value As Boolean)

            bolModuloContrato = Value

        End Set

    End Property

    Public Property ClienteID() As String
        Get

            Return intClienteID

        End Get

        Set(ByVal Value As String)

            intClienteID = Value

        End Set

    End Property

    Public Property NombreApellidos() As String
        Get

            Return m_strNombreApellidos

        End Get

        Set(ByVal Value As String)

            m_strNombreApellidos = Value

        End Set

    End Property

    Public Property TipoVenta() As String
        Get
            Return m_strTipoVenta
        End Get
        Set(ByVal Value As String)
            m_strTipoVenta = Value
        End Set
    End Property

    Public Property CodigoClienteDPVALE() As Integer
        Get
            Return m_intCodigoClienteDPVALE
        End Get
        Set(ByVal Value As Integer)
            m_intCodigoClienteDPVALE = Value
        End Set
    End Property

    Public Property EsClienteApproval As Boolean
        Get
            Return m_EsClienteApproval
        End Get
        Set(value As Boolean)
            m_EsClienteApproval = value
        End Set
    End Property

    Public Property ActivacionPuntos As Boolean
        Get
            Return m_ActivacionPuntos
        End Get
        Set(value As Boolean)
            m_ActivacionPuntos = value
        End Set
    End Property

#End Region

#Region "General Methods"

    Private Sub BindingDatosCliente()
        With oCliente
            .TipoVenta = ebTipoVenta.DropDownList.GetValue(4)
            .Nombre = Me.ebNombre.Text
            .ApellidoPaterno = Me.ebApellidoPaterno.Text
            .ApellidoMaterno = Me.ebApellidoMaterno.Text
            .Direccion = Me.ebDomicilio.Text
            .Colonia = Me.ebColonia.Text
            .Estado = Me.ebEstado.Value
            .Ciudad = Me.ebCiudad.Value
            .CP = Me.ebCP.Text
            .Sexo = Me.ebSexo.Text
            .FechaNacimiento = Me.cmbFechaNac.Value
            .RFC = Me.ebRFC.Text
            .Telefono = Me.ebTelefono.Text
            .EMail = Me.ebEmail.Text
            .EstadoCivil = Me.ebEmail.Text
        End With
    End Sub

    Private Function ValidaDatos(ByVal RegClienteDPCardApprova As Boolean) As Boolean

        'BindingDatosCliente()
        Me.ebRecordCreateBy.Focus()

        'Dim bRegExp As Boolean = False

        'If oConfigCierreFI.RegistroExpressPG AndAlso Me.ebTipoVenta.Value = "P" Then bRegExp = True

        'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)
        'If strRes.Trim = "0" Then
        '    MessageBox.Show("El codigo del vendedor no existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    oVendedor.ClearFields()
        '    Me.ebCodVendedor.Focus()
        '    Return False
        'ElseIf strRes.Trim = "2" Then
        '    MessageBox.Show("El Vendedor " & oVendedor.ID & " no está asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    oVendedor.ClearFields()
        '    Me.ebCodVendedor.Focus()
        '    Return False
        'End If

        With oCliente
            If Me.ebTipoVenta.Value = "" Then
                MessageBox.Show("Capture el Tipo de Cliente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebTipoVenta.Focus()
                Return False
            ElseIf .Nombre.Trim = "" Then
                MessageBox.Show("Capture el Nombre del Cliente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebNombre.Focus()
                Return False
            ElseIf Me.chkEmpresa.Checked = False AndAlso .ApellidoPaterno.Trim = "" Then
                MessageBox.Show("Capture Apellido Paterno", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebApellidoPaterno.Focus()
                Return False
            ElseIf Me.chkEmpresa.Checked = False AndAlso .ApellidoMaterno.Trim = "" Then
                MessageBox.Show("Capture Apellido Materno", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebApellidoMaterno.Focus()
                Return False
            ElseIf .Direccion.Trim = "" Then 'AndAlso bRegExp = False Then
                MessageBox.Show("Capture el Domicilio", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebDomicilio.Focus()
                Return False
            ElseIf .NumExt.Trim = "" Then 'AndAlso bRegExp = False Then
                MessageBox.Show("Capture el Número Exterior", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebNumExt.Focus()
                Return False
            ElseIf .Colonia.Trim = "" Then 'AndAlso bRegExp = False Then
                MessageBox.Show("Captura la Colonia", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebColonia.Focus()
                Return False
            ElseIf .Estado.Trim = "" Then 'AndAlso bRegExp = False Then
                MessageBox.Show("Seleccione Estado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebEstado.Focus()
                Return False
            ElseIf Not oConfigCierreFI.AplicaDPCard AndAlso .Ciudad.Trim = "" Then ' JNAVA (08.11.2016): Si está activo Scredit que no valide ciudad
                MessageBox.Show("Seleccione Ciudad", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebCiudad.Focus()
                Return False
            ElseIf .CP.Trim = "" Then 'AndAlso bRegExp = False Then
                MessageBox.Show("Capture el Código Postal", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebCP.Focus()
                Return False
                'ElseIf Me.chkEmpresa.Checked = False AndAlso oCliente.Sexo.Trim = "" Then
            ElseIf Me.chkEmpresa.Checked = False AndAlso (oCliente.Sexo.Trim = "" OrElse Me.ebSexo.Text.Trim = "") Then 'AndAlso bRegExp = False Then
                MessageBox.Show("Seleccione Sexo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebSexo.Focus()
                Return False
                'ElseIf Me.ebEstadoCivil.Text.Trim = String.Empty Then
                '    MessageBox.Show("Seleccione Estado Civil", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Me.ebEstadoCivil.Focus()
                '    Return False
                'ElseIf Me.msFechaNac.Text.Trim = String.Empty Then
            ElseIf CStr(.FechaNacimiento).Trim = "" Then
                MessageBox.Show("Capture Fecha de Nacimiento ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.cmbFechaNac.Focus()
                Return False
            ElseIf IsDate(.FechaNacimiento) = False OrElse (.EsEmpresa = False AndAlso .FechaNacimiento > Today.AddYears(-7)) OrElse .FechaNacimiento > Today Then
                MsgBox("Valor de Fecha Incorrecta. Verifique. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Clientes")
                cmbFechaNac.Focus()
                Return False
                'ElseIf Me.ebPlayerDescripcion.Text.Trim = String.Empty Then
                '    MessageBox.Show("Capture Vendedor ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Me.ebCodVendedor.Focus()
                '    Return False
                '    'ElseIf Me.chkFacturar.Checked Then

                '------------------------------------------------------------------------------------------
                ' JNAVA (14.02.2017): Validaciones de la RFC
                '------------------------------------------------------------------------------------------
            ElseIf Not ValidaRFC(.RFC.Trim) Then
                Me.ebRFC.Focus()
                Return False
                '------------------------------------------------------------------------------------------
            ElseIf .RFC.Trim = "" Then
                ' MessageBox.Show("Es necesario especificar el RFC ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If CStr(ebTipoVenta.Value) <> "D" Then
                    If MessageBox.Show("¿Estas seguro de grabar el cliente sin RFC?", Me.Text.Trim, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Me.ebRFC.Focus()
                        Return False
                    End If
                Else
                    MessageBox.Show("No se puede grabar clientes DIPS sin RFC", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.ebRFC.Focus()
                    Return False
                End If

                'End If
            ElseIf oConfigCierreFI.UsarHuellas AndAlso .EMail.Trim = "" Then
                Dim oFrmRazones As New frmRazonesRechazo
                oFrmRazones.ModuloOrigen = "CL"
                oFrmRazones.lblLabel1.Text = "Seleccione una razón por la que no capturó el email del cliente"
                If oFrmRazones.ShowDialog = DialogResult.OK Then
                    oCliente.RazonNoEmail = oFrmRazones.cmbRazones.Text
                    oCliente.RazonRechazoID = oFrmRazones.cmbRazones.Value
                Else
                    oCliente.RazonNoEmail = ""
                    oCliente.RazonRechazoID = 0
                    MessageBox.Show("Es necesario elegir una razón por la cual no capturó el Email.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If

                '-----------------------------------------------------------------------------------------
                ' JNAVA (08.08.2016): Agregamos validacion de Numero de Telefono si esta activo S2Credit
                '-----------------------------------------------------------------------------------------
            ElseIf .EMail.Trim = "" AndAlso Me.TipoVenta <> "C" Then
                MessageBox.Show("Capture el Email del Cliente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebNombre.Focus()
                Return False
            ElseIf .EMail.Trim() <> "" And Me.TipoVenta <> "C" Then
                If Regex.IsMatch(.EMail.Trim(), "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$") = False Then
                    MessageBox.Show("Correo Invalido", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.ebEmail.Focus()
                    Return False
                Else
                    Dim lstMail() As String = .EMail.Split("@")
                    If lstMail.Length = 2 Then
                        If lstMail(0).Length < 3 Then
                            MessageBox.Show("El nombre de usuario del correo debe ser igual o mayor a 3 caracteres", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Me.ebEmail.Focus()
                            Return False
                        ElseIf IsNumeric(lstMail(0)) Then
                            MessageBox.Show("El nombre de usuario del correo no debe ser númerico", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Me.ebEmail.Focus()
                            Return False
                        End If
                    End If
                End If
            ElseIf oConfigCierreFI.AplicarS2Credit AndAlso .Telefono.Trim = String.Empty Then
                MessageBox.Show("Capture Teléfono.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebCP.Focus()
                Return False
            End If

            'Inicio Jemo
            If RegClienteDPCardApprova = True Then
                If Me.ebTelefono.Text = "" Then
                    MessageBox.Show("Capture el Numero de Telefono del Cliente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.ebTelefono.Focus()
                    Return False
                End If
            End If
            'Fin Jemo
            '----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 21/06/2018: Valida si el cliente es menor de edad
            '----------------------------------------------------------------------------------------------------------------------------
            If Me.TipoVenta = "C" Then
                Dim FechaAValidar As DateTime = DateTime.Now.AddYears(-18)
                If cmbFechaNac.Value > FechaAValidar Then
                    MessageBox.Show("El cliente es menor de edad", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cmbFechaNac.Focus()
                    Return False
                End If
            End If

        End With
        strTipoVenta = oCliente.TipoVenta
        Return True

    End Function

    'Private Function ValidaDatos() As Boolean

    '    With oCliente
    '        If .TipoVenta.Trim = "" Then
    '            If ebTipoVenta.Text.Trim <> "" Then
    '                .TipoVenta = Me.ebTipoVenta.Value
    '            Else
    '                MessageBox.Show("Capture el Tipo de Cliente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Me.ebTipoVenta.Focus()
    '                Return False
    '            End If
    '        ElseIf .Nombre.Trim = "" Then
    '            If ebNombre.Text.Trim <> "" Then
    '                .Nombre = Me.ebNombre.Text.Trim
    '            Else
    '                MessageBox.Show("Capture el Nombre del Cliente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Me.ebNombre.Focus()
    '                Return False
    '            End If
    '        ElseIf .ApellidoPaterno.Trim = "" Then
    '            If Me.ebApellidoPaterno.Text.Trim <> "" Then
    '                .ApellidoPaterno = Me.ebApellidoPaterno.Text.Trim
    '            Else
    '                MessageBox.Show("Capture Apellido Paterno", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Me.ebApellidoPaterno.Focus()
    '                Return False
    '            End If
    '        ElseIf .ApellidoMaterno.Trim = "" Then
    '            If Me.ebApellidoMaterno.Text.Trim <> "" Then
    '                .ApellidoMaterno = Me.ebApellidoMaterno.Text.Trim
    '            Else
    '                MessageBox.Show("Capture Apellido Materno", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Me.ebApellidoMaterno.Focus()
    '                Return False
    '            End If
    '        ElseIf .Direccion.Trim = "" Then
    '            If Me.ebDomicilio.Text.Trim <> "" Then
    '                .Direccion = Me.ebDomicilio.Text.Trim
    '            Else
    '                MessageBox.Show("Capture el Domicilio", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Me.ebDomicilio.Focus()
    '                Return False
    '            End If
    '        ElseIf .Colonia.Trim = "" Then
    '            If Me.ebColonia.Text.Trim <> "" Then
    '                .Colonia = Me.ebColonia.Text.Trim
    '            Else
    '                MessageBox.Show("Captura la Colonia", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Me.ebColonia.Focus()
    '                Return False
    '            End If
    '        ElseIf .Estado.Trim = "" Then
    '            If CStr(Me.ebEstado.Value).Trim <> "" Then
    '                .Estado = Me.ebEstado.Value
    '            Else
    '                MessageBox.Show("Seleccione Estado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Me.ebEstado.Focus()
    '                Return False
    '            End If
    '        ElseIf .Ciudad.Trim = "" Then
    '            If CStr(Me.ebCiudad.Value) <> "" Then
    '                .Ciudad = Me.ebCiudad.Value
    '            Else
    '                MessageBox.Show("Seleccione Ciudad", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Me.ebCiudad.Focus()
    '                Return False
    '            End If
    '        ElseIf .CP.Trim = "" Then
    '            If Me.ebCP.Text.Trim <> "" Then
    '                .CP = Me.ebCP.Text.Trim
    '            Else
    '                MessageBox.Show("Capture el Código Postal", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Me.ebCP.Focus()
    '                Return False
    '            End If
    '        ElseIf .Sexo.Trim = "" Then
    '            If Me.ebSexo.Text.Trim <> "" Then
    '                .Sexo = Me.ebSexo.Text.Trim
    '            Else
    '                MessageBox.Show("Seleccione Sexo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Me.ebSexo.Focus()
    '                Return False
    '            End If
    '            'ElseIf Me.ebEstadoCivil.Text.Trim = String.Empty Then
    '            '    MessageBox.Show("Seleccione Estado Civil", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            '    Me.ebEstadoCivil.Focus()
    '            '    Return False
    '            'ElseIf Me.msFechaNac.Text.Trim = String.Empty Then
    '        ElseIf CStr(.FechaNacimiento).Trim = "" Then
    '            If Me.cmbFechaNac.Text.Trim <> "" Then
    '                .FechaNacimiento = Me.cmbFechaNac.Value
    '            Else
    '                MessageBox.Show("Capture Fecha de Nacimiento ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Me.cmbFechaNac.Focus()
    '                Return False
    '            End If
    '            'ElseIf IsDate(cmbFechaNac.Text.Trim) = False OrElse cmbFechaNac.Value > Today.AddYears(-7) Then
    '        ElseIf IsDate(.FechaNacimiento) = False OrElse .FechaNacimiento > Today.AddYears(-7) Then
    '            MsgBox("Valor de Fecha Incorrecta. Verifique. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, " Clientes")
    '            cmbFechaNac.Focus()
    '            Return False
    '        ElseIf Me.ebPlayerDescripcion.Text.Trim = String.Empty Then
    '            MessageBox.Show("Capture Vendedor ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Me.ebCodVendedor.Focus()
    '            Return False
    '            'ElseIf Me.chkFacturar.Checked Then
    '        ElseIf Me.ebRFC.Text.Trim = String.Empty Then
    '            MessageBox.Show("Es necesario especificar el RFC ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Me.ebRFC.Focus()
    '            Return False
    '            'End If
    '        End If
    '    End With

    '    Return True

    'End Function

    Private Sub EnviarCorreoValidacion(ByVal Email As String, ByVal Nombre As String, ByVal id As Integer, ByVal oClienteTemp As ClienteAlterno)

        Dim mmMail As New MailMessage
        Dim objSmtpServer As SmtpMail
        Dim strHTML As String = ""
        Dim strLinkVerifica As String = ""
        Dim strRutaImgs As String = ""

        strHTML = "Hola <b>" & Nombre.Trim & ":</b><br><br>" & _
                  "<b>¡Gracias por registrarse en Dportenis!...</b><br><br>" & _
                  "Si desea formar parte de nuestro grupo distinguido de clientes, " & _
                  "confirme que su cuenta de email " & Email.Trim & " esta activa, así le podamos enviar información de:<br><br><b>" & _
                  "* Productos nuevos, <br>" & _
                  "* Lanzamientos, <br>" & _
                  "* Ofertas y <br>" & _
                  "* Promociones exclusivas <br><br></b>" & _
                  "Por favor, haga clic en el siguiente enlace o cópielo y póngalo en la barra de URL de su navegador:<br><br>" & _
                  "http://201.147.208.251/clientes/validate.php?id=" & id & "&string=" & fn_md5(Email) & "<br><br>" & _
                  "Nos complacerá enormemente, que elija formar parte de nuestro grupo distinguido de clientes, gracias de nuevo.<br><br>" & _
                  "Saludos cordiales... "
        '"https://www.grupodp.com.mx/clientes/validate.php?id=" & id & "&string=" & fn_md5(Email) & "<br><br>" & _

        'strLinkVerifica = "http://201.147.208.251/clientes/validate.php?id=" & id & "&string=" & fn_md5(Email)
        strLinkVerifica = oConfigCierreFI.DireccionValidaEmail.Trim & "?id=" & id & "&string=" & fn_md5(Email)
        If oClienteTemp.TipoVenta.Trim = "P" AndAlso ValidaDatosObligatoriosCliente(oClienteTemp) = False Then
            strLinkVerifica &= "&idpg=" & fn_md5(oCliente.CodigoAlterno.Trim)
        Else
            strLinkVerifica &= "&idpg=" & fn_md5("0")
        End If
        'strRutaImgs = "http://dpstreet.com.mx/~noticias/dpimagenes/"
        strRutaImgs = oConfigCierreFI.DireccionImagenesEmail.Trim

        If oCliente.TipoVenta.Trim.ToUpper <> "V" Then
            strHTML = "<html><head></head><body style=""margin-left:10px;margin-top:20px;margin-right:10px;margin-bottom:10px;background-color:#f1f1f1;""><table width=""646"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0""><tbody><tr><td valign=""top""><table width=""34"" border=""0"" cellspacing=""0"" cellpadding=""0""><tbody><tr><td height=""204"">&nbsp;</td></tr><tr><td><img src=""" & strRutaImgs & "lateral-1.jpg"" width=""34"" height=""189"" alt=""Verifica tu email""></td></tr></tbody></table></td><td><div id=""box"" style=""width:562px;background-color:#FFF;border-width:1px;border-style:solid;border-color:#CCC;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-top:28px;padding-bottom:28px;padding-right:28px;padding-left:28px;""><table width=""562"" border=""0"" cellspacing=""0"" cellpadding=""0""><tbody><tr><td><table width=""562"" border=""0"" cellspacing=""0"" cellpadding=""0""><tbody><tr><td width=""522"" height=""108"" align=""left"" valign=""top""><a href=""http://www.dportenis.com.mx/"" style=""text-decoration:none;color:#52b2ca;font-weight:bold;""><img src=""" & strRutaImgs & "logo.jpg"" alt=""Dportenis la tienda mas grande de tenis"" border=""0""></a><h3 style=""color:#475770 !important;font-family:Arial, Helvetica, sans-serif;font-size:25px;font-weight:lighter;line-height:14px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;font-style:normal;padding-top: 10px;padding-bottom:6px;"">Programa de clientes frecuentes</h3></td><td width=""40"" align=""left"" valign=""top"">&nbsp;</td></tr></tbody></table></td></tr><tr><td><hr></td></tr><tr><td>&nbsp;</td></tr><tr><td><h1 style=""color:#333 !important;font-family:Arial, Helvetica, sans-serif;font-size:21px;font-weight:bold;line-height:27px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:18px;""><a name=""news01"" id=""news01"" style=""text-decoration:none;color:#52b2ca;font-weight:bold;""></a>Estas a un paso de finalizar tu registro</h1><h2 style=""color:#333 !important;font-family:Arial, Helvetica, sans-serif;font-size:13px;font-weight:bold;line-height:21px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:18px;"">Porfavor da click en la siguiente liga para verificar tu direccion de email: <br> <a href=""" & strLinkVerifica & """> VERIFICAR DIRECCION DE EMAIL</a></h2><h1 style=""color:#333 !important;font-family:Arial, Helvetica, sans-serif;font-size:11px;line-height:21px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:7px;"">Recuerda que con el registro de tu huella digital gozas de los siguientes beneficios:</h1><p style=""font-family:Arial, Helvetica, sans-serif;font-size:11px;font-weight:normal;color:#333;line-height:19px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:10px;"">- Pertenecer a nuestro club de clientes frecuentes<br>- Promociones y descuentos exclusivos para ti<br>- Informacion sobre los productos mas nuevos y eventos que realizamos en tu ciudad</p><p style=""font-family:Arial, Helvetica, sans-serif;font-size:11px;font-weight:normal;color:#333;line-height:19px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:10px;"">Si tienes una duda o comentario no dudes en contactarnos al <strong>01 800 0028 774</strong></p><p style=""font-family:Arial, Helvetica, sans-serif;font-size:11px;font-weight:normal;color:#333;line-height:19px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:10px;""><table style=""width:450px; text-align:left; margin-left:auto; margin-right:auto;""><tbody><tr><td><a style=""color:#333; text-decoration:none;"" href=""http://www.twitter.com/dportenis""><img src=""" & strRutaImgs & "twitter.png"" style=""border:0""></a></td><td><span style=""color:#333; font-size:12px;"">Siguenos en</span><br><span style=""font-size:18px;""><a style=""color:#333; text-decoration:none;"" href=""http://www.twitter.com/dportenis"">@dportenis</a></span></td><td><a style=""color:#333; text-decoration:none;"" href=""http://www.facebook.com/dportenis""><img src=""" & strRutaImgs & "facebook.png"" style=""border:0;""></a></td><td><span style=""color:#333; font-size:12px;"">Hazte fan</span><br><span style=""font-size:18px;""><a style=""color:#333; text-decoration:none;"" href=""http://www.facebook.com/dportenis"">facebook.com/dportenis</a></span></td></tr></tbody></table></p></td></tr><tr><td><hr></td></tr></tbody></table></div></td></tr><tr><td valign=""top"">&nbsp;</td><td align=""center""> <br><h4 style=""color:#333 !important;font-family:Arial, Helvetica, sans-serif;font-size:10px;font-weight:normal;line-height:14px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:10px;"">Este correo electronico a llegado a usted, ya que nos ha proporcionado para el programa de clientes frecuentes su direccion de correo electronico y otros datos personales en alguna de nuestras tiendas Dportenis.</h4><h4 style=""color:#333 !important;font-family:Arial, Helvetica, sans-serif;font-size:10px;font-weight:normal;line-height:14px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:10px;"">© 2011 Grupo Dportenis </h4></td></tr></tbody></table></body></html>"
        Else
            strHTML = "<html><head></head><body style=""margin-left:10px;margin-top:20px;margin-right:10px;margin-bottom:10px;background-color:#f1f1f1;""><table width=""646"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0""><tbody><tr><td valign=""top""><table width=""34"" border=""0"" cellspacing=""0"" cellpadding=""0""><tbody><tr><td height=""204"">&nbsp;</td></tr><tr><td><img src=""" & strRutaImgs & "lateral-1.jpg"" width=""34"" height=""189"" alt=""Verifica tu email""></td></tr></tbody></table></td><td><div id=""box"" style=""width:562px;background-color:#FFF;border-width:1px;border-style:solid;border-color:#CCC;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-top:28px;padding-bottom:28px;padding-right:28px;padding-left:28px;""><table width=""562"" border=""0"" cellspacing=""0"" cellpadding=""0""><tbody><tr><td><table width=""562"" border=""0"" cellspacing=""0"" cellpadding=""0""><tbody><tr><td width=""522"" height=""108"" align=""left"" valign=""top""><a href=""http://www.dportenis.com.mx/"" style=""text-decoration:none;color:#52b2ca;font-weight:bold;""><img src=""" & strRutaImgs & "logo.jpg"" alt=""Dportenis la tienda mas grande de tenis"" border=""0""></a><h3 style=""color:#475770 !important;font-family:Arial, Helvetica, sans-serif;font-size:25px;font-weight:lighter;line-height:14px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;font-style:normal;padding-top: 10px;padding-bottom:6px;"">Programa de clientes frecuentes</h3></td><td width=""40"" align=""left"" valign=""top"">&nbsp;</td></tr></tbody></table></td></tr><tr><td><hr></td></tr><tr><td>&nbsp;</td></tr><tr><td><h1 style=""color:#333 !important;font-family:Arial, Helvetica, sans-serif;font-size:21px;font-weight:bold;line-height:27px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:18px;""><a name=""news01"" id=""news01"" style=""text-decoration:none;color:#52b2ca;font-weight:bold;""></a>Estas a un paso de finalizar tu registro</h1><h2 style=""color:#333 !important;font-family:Arial, Helvetica, sans-serif;font-size:13px;font-weight:bold;line-height:21px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:18px;"">Porfavor da click en la siguiente liga para verificar tu direccion de email: <br> <a href=""" & strLinkVerifica & """> VERIFICAR DIRECCION DE EMAIL</a></h2><h1 style=""color:#333 !important;font-family:Arial, Helvetica, sans-serif;font-size:11px;line-height:21px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:7px;"">Recuerda que con el registro de tu huella digital gozas de los siguientes beneficios:</h1><p style=""font-family:Arial, Helvetica, sans-serif;font-size:11px;font-weight:normal;color:#333;line-height:19px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:10px;"">- Rapidez en tus compras, por que ya no necesitas presentar tu credencial de elector<br>- Seguridad al momento de hacer valido tu DpVale, solamente tu con tu huella digital podreas hacer valido tu vale<br>- Promociones exclusivas para ti que eres nuestro cliente frecuente</p><p style=""font-family:Arial, Helvetica, sans-serif;font-size:11px;font-weight:normal;color:#333;line-height:19px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:10px;"">Si tienes una duda o comentario no dudes en contactarnos al <strong>01 800 0028 774</strong></p><p style=""font-family:Arial, Helvetica, sans-serif;font-size:11px;font-weight:normal;color:#333;line-height:19px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:10px;""><table style=""width:450px; text-align:left; margin-left:auto; margin-right:auto;""><tbody><tr><td><a style=""color:#333; text-decoration:none;"" href=""http://www.twitter.com/dportenis""><img src=""" & strRutaImgs & "twitter.png"" style=""border:0""></a></td><td><span style=""color:#333; font-size:12px;"">Siguenos en</span><br><span style=""font-size:18px;""><a style=""color:#333; text-decoration:none;"" href=""http://www.twitter.com/dportenis"">@dportenis</a></span></td><td><a style=""color:#333; text-decoration:none;"" href=""http://www.facebook.com/dportenis""> <img src=""" & strRutaImgs & "facebook.png"" style=""border:0;""></a></td><td><span style=""color:#333; font-size:12px;"">Hazte fan</span><br><span style=""font-size:18px;""><a style=""color:#333; text-decoration:none;"" href=""http://www.facebook.com/dportenis"">facebook.com/dportenis</a></span></td></tr></tbody></table></p></td></tr><tr><td><hr></td></tr></tbody></table></div></td></tr><tr><td valign=""top"">&nbsp;</td><td align=""center""> <br><h4 style=""color:#333 !important;font-family:Arial, Helvetica, sans-serif;font-size:10px;font-weight:normal;line-height:14px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:10px;"">Este correo electronico a llegado a usted, ya que nos ha proporcionado para el programa de clientes frecuentes su direccion de correo electronico y otros datos personales en alguna de nuestras tiendas Dportenis.</h4><h4 style=""color:#333 !important;font-family:Arial, Helvetica, sans-serif;font-size:10px;font-weight:normal;line-height:14px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;padding-bottom:10px;"">© 2011 Grupo Dportenis </h4></td></tr></tbody></table></body></html>"
        End If

        mmMail.From = oConfigCierreFI.CorreoActivacion
        mmMail.To = Email.Trim
        mmMail.Subject = "¡Confirma tu registro en D'portenis y obtén grandes promociones!"
        'mmMail.Body = "Hola " & Nombre.Trim & ", " & vbCrLf & vbCrLf & "Gracias por registrarse en Comercial Dportenis. Su cuenta fue creada y debe ser activada." & vbCrLf & _
        '              "Para activarla haga clic en el siguiente enlace o cópielo y póngalo en la barra de url de su navegador:" & vbCrLf & _
        '              "http://192.168.3.80/Sitio/Correos/validate.php?id=" & id & "&string=" & fn_md5(Email)
        mmMail.BodyFormat = MailFormat.Html
        mmMail.Body = strHTML
        'Dim oAttachment As MailAttachment = New MailAttachment(strruta)
        'mmMail.Attachments.Add(oAttachment)
        objSmtpServer.SmtpServer = oConfigCierreFI.ServidorSMTP
        Try
            objSmtpServer.Send(mmMail)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Ocurrio un error al enviar el email de validacion de correo del cliente: " & oClienteTemp.CodigoAlterno.Trim)
        End Try

    End Sub

    Private Function fn_md5(ByVal strCadena As String) As String

        Dim md5Hasher As MD5 = MD5.Create()
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strCadena))
        Dim sBuilder As New StringBuilder
        Dim i As Integer

        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        Return sBuilder.ToString()

    End Function

    Private Sub SaveCliente(ByRef bRes As Boolean)

        Try

            If (bolModuloContrato = True) Then

                MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
                bRes = False
                Exit Sub

            End If
            Dim ws As New WSMATRICES("WS_MATRICES")
            If (ebTipoVenta.Value = "D") Then
                If (ws.Valida_Rfc(ebRFC.Text.Trim.Replace("-", ""))) Then
                    MsgBox("El cliente ya existe", MsgBoxStyle.Information, "Corrobore sus datos")
                    bRes = False
                    Exit Sub
                End If
            End If
            'If Not ValidaDatos() Then
            '    Exit Sub
            'End If


            '------------------------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (26.07.2016): Si no esta activo el S2credit validamo RFC en SAP
            '------------------------------------------------------------------------------------------------------------------------------------------------
            Dim CatalogoTipoMgr As New CatalogoTipoVentaManager(oAppContext)
            If Not oConfigCierreFI.AplicarS2Credit Then
                '------------------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (05.04.2016): Validamos si se capturo RFC o no para no buscar al cliente
                '------------------------------------------------------------------------------------------------------------------------------------------------
                'Revisamos si el cliente ya esta registrado anteriormente con el mismo RFC y lo modificamos para no duplicar registros
                '------------------------------------------------------------------------------------------------------------------------------------------------
                'Dim CatalogoTipoMgr As New CatalogoTipoVentaManager(oAppContext)
                If oCliente.RFC.Trim <> "" Then 'If Me.ebTipoVenta.Value <> "P" Then
                    Dim strClienteID As String = ""
                    strClienteID = BuscarClienteByRFC(oCliente.RFC.Trim, 0, Me.ebTipoVenta.Value, True)
                    If strClienteID.Trim <> "" Then
                        oCliente.CodigoAlterno = strClienteID.PadLeft(10, "0")
                    End If
                End If
            End If

            ''------------------------------------------------------------------------------------------------------------------------------------------------
            ''Pedimos primero la huella digital antes de continuar con el guardado de los datos del cliente excepto si es guardado automatico
            ''------------------------------------------------------------------------------------------------------------------------------------------------
            'If oFingerP Is Nothing AndAlso RegistraHuellaDigital(False) = False Then
            '    'MessageBox.Show("Es necesario registrar la huella digital del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    bRes = False
            '    Exit Sub
            'End If
            '------------------------------------------------------------------------------------------------------------------------------------------------
            'Proceso guardado del cliente en SAP y SQL
            '------------------------------------------------------------------------------------------------------------------------------------------------
            If oCliente.CodigoAlterno.Trim() = String.Empty OrElse oCliente.CodigoAlterno.Trim().PadLeft(10, "0") = "0000000000" Then

                'oCliente.FechaNacimiento = Me.ebFechaNac.Value
                oCliente.FechaNacimiento = Me.cmbFechaNac.Value
                oCliente.Sexo = Me.ebSexo.Text
                oCliente.CodPlayer = Me.ebCodVendedor.Text
                If Me.ebTipoVenta.Value = "D" Then
                    oCliente.I_SORTL = "CATALOGO"
                Else
                    oCliente.I_SORTL = Me.ebTipoVenta.Text
                End If
                oCliente.TipoVenta = Me.ebTipoVenta.Value 'CatalogoTipoMgr.GetTipoCliente(oCliente.TipoVenta)
                'If Me.ebTipoVenta.Value <> "P" Then oCliente.Direccion &= " No. " & oCliente.NumExt
                'Grabar en Dp y en SAP
                If oClienteMgr.Save(oCliente, EsDPVale, EsClienteRetail) = False Then
                    bRes = False
                    Exit Sub
                End If

                ebRecordCreateBy.Text = oCliente.RecordCreatedBy
                ebRecordCreateOn.Text = Format(oCliente.RecordCreatedOn, "dd/MM/yyyy")

                MsgBox("Cliente se guardó satisfactoriamente. Codigo de Cliente :" & oCliente.CodigoAlterno, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Guardar Cliente")

                If esInstanciaFactura Then

                    pubClienteID = oCliente.CodigoAlterno
                    PubNombreCliente = oCliente.Nombre.Trim & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno

                End If

                DesactivaNoModificables()

                bandera = True

            Else

                'Dim CodTipoVenta As String = ""
                'oCliente.FechaNacimiento = Me.ebFechaNac.Value
                oCliente.FechaNacimiento = Me.cmbFechaNac.Value
                oCliente.Sexo = Me.ebSexo.Text
                oCliente.CodPlayer = Me.ebCodVendedor.Text
                oCliente.RecordCreatedBy = oAppContext.Security.CurrentUser.Name
                oCliente.RecordCreatedOn = Date.Today
                oCliente.ResetFlagNew()
                'CodTipoVenta = oClienteMgr.GetTipoVenta(Me.ebClienteID.Text).Trim
                'Me.ebTipoVenta.Value = IIf(CodTipoVenta.Length > 1, CodTipoVenta.Substring(0, 1), CodTipoVenta)
                If Me.ebTipoVenta.Value = "D" Then
                    oCliente.I_SORTL = "CATALOGO"
                Else
                    oCliente.I_SORTL = Me.ebTipoVenta.Text
                End If
                'oCliente.TipoVenta = Me.ebTipoVenta.DropDownList.GetValue(4)
                oCliente.TipoVenta = CatalogoTipoMgr.GetTipoCliente(Me.ebTipoVenta.Value)
                'If Me.ebTipoVenta.Value <> "P" Then oCliente.Direccion &= " No. " & oCliente.NumExt
                If oClienteMgr.Save(oCliente, EsDPVale, EsClienteRetail) = False Then
                    bRes = False
                    Exit Sub
                End If

                MsgBox("Cliente " & oCliente.CodigoAlterno & " se guardó satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Guardar Cliente")

                ebRecordCreateBy.Text = oCliente.RecordCreatedBy
                ebRecordCreateOn.Text = Format(oCliente.RecordCreatedOn, "dd/MM/yyyy")

                DesactivaNoModificables()
                bandera = True

            End If
            ''-----------------------------------------------------------------------------------------------------------------------------------------------
            ''Relacionamos la huella digital con el ID del cliente recien obtenido al guardar los datos
            ''-----------------------------------------------------------------------------------------------------------------------------------------------
            'RegistraHuellaDigital(True)
            '-----------------------------------------------------------------------------------------------------------------------------------------------
            'Verificamos si ya registro el correo anteriormente y si no se registra y se guarda para su validacion
            '-----------------------------------------------------------------------------------------------------------------------------------------------
            Dim strError As String = ""
            If oConfigCierreFI.UsarHuellas AndAlso Me.ebEmail.Text.Trim <> "" AndAlso oClienteMgr.ExisteCorreoCliente(oCliente.EMail, strError) = False Then
                If strError.Trim <> "" Then EscribeLog(strError, "Error al consultar el mail del cliente: " & oCliente.EMail)
                Dim intID As Integer = 0
                strError = ""
                intID = oClienteMgr.SaveEmailCliente(oCliente.CodigoAlterno, oCliente.EMail, strError)
                If strError.Trim <> "" Then EscribeLog(strError, "Error al guardar email del cliente: " & oCliente.EMail)
                If intID > 0 Then
                    EnviarCorreoValidacion(oCliente.EMail, oCliente.Nombre, intID, oCliente)
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al guardar cliente.")
            Throw ex
        End Try

    End Sub



    '    Private Function RegistraHuellaDigital(ByVal bGuardar As Boolean) As Boolean

    '        Dim bRes As Boolean = True

    '        If oConfigCierreFI.UsarHuellas = True AndAlso Me.chkEmpresa.Checked = False Then
    '            '-----------------------------------------------------------------------------------------------------------------------------------------------
    '            'Proceso de guardado de huella digital
    '            '-----------------------------------------------------------------------------------------------------------------------------------------------
    '            If oFingerP Is Nothing Then
    '                oFingerP = oFingerPMGr.LoadByClienteID(Me.ebClienteID.Text)
    '                If oFingerP.IsNew = True Then
    'Preguntar:
    '                    If MessageBox.Show("¿El cliente ya registró la huella anteriormente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '                        MessageBox.Show("Por favor, solicita la huella del cliente para verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        If BuscarHuellaDigital("Guardar") = False Then
    '                            GoTo Preguntar
    '                        End If
    '                    Else
    '                        oFingerP = Nothing
    '                    End If
    '                End If
    '            End If
    '            'If strValor = "SI" Then
    '            'If oConfigCierreFI.HuellaOpcional = True Then
    '            If oFingerP Is Nothing AndAlso oConfigCierreFI.HuellaOpcional Then
    '                If MessageBox.Show("¿Desea registrar la huella digital?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
    '                    GoTo Final
    '                End If
    '            ElseIf Not oFingerP Is Nothing AndAlso oFingerP.IsNew = False Then
    '                'If MessageBox.Show("El cliente " & Me.ebClienteID.Text & " ya tiene registrada la huella." & vbCrLf & vbCrLf & "¿Desea modificarla?", Me.Text, _
    '                '   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
    '                GoTo Final
    '                'Else
    '                '    oFingerP = Nothing
    '                'End If
    '            End If
    '            'End If
    '            Dim strError As String = ""
    '            'oFingerPMGr.GuardarHuella(Me.ebClienteID.Text, IIf(Me.ebTipoVenta.Value <> "P", True, False), oCliente.TipoVenta, ContarDatosCapturados, strError, bGuardar, oFingerP)
    '            If strError.Trim <> "" Then
    '                EscribeLog(strError, "Error al guardar huella digital.")
    '                bRes = False
    '            End If
    '            If oConfigCierreFI.HuellaOpcional = False AndAlso oFingerP Is Nothing Then
    '                MessageBox.Show("Es necesario registrar la huella digital para continuar con el guardado de los datos del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                bRes = False
    '            End If
    '        End If
    'Final:
    '        Return bRes

    '    End Function

    Private Sub HabilitaCamposDPVale(ByVal bHabilita As Boolean)

        If bHabilita = False Then
            If Me.ebNombre.Text.Trim <> "" Then Me.ebNombre.Enabled = False
            If Me.ebApellidoMaterno.Text.Trim <> "" Then Me.ebApellidoMaterno.Enabled = False
            If Me.ebApellidoPaterno.Text.Trim <> "" Then Me.ebApellidoPaterno.Enabled = False
            If Me.ebDomicilio.Text.Trim <> "" Then Me.ebDomicilio.Enabled = False
            If Me.ebColonia.Text.Trim <> "" Then Me.ebColonia.Enabled = False
            If Me.ebEstado.Text.Trim <> "" Then Me.ebEstado.Enabled = False
            If Me.ebCiudad.Text.Trim <> "" Then Me.ebCiudad.Enabled = False
            If Me.ebCP.Text.Trim <> "" Then Me.ebCP.Enabled = False
            'If Me.ebTelefono.Text.Trim <> "" Then Me.ebTelefono.Enabled = False
            If Me.ebRFC.Text.Trim <> "" Then Me.ebRFC.Enabled = False
            If Me.ebNumExt.Text.Trim <> "" Then Me.ebNumExt.Enabled = False
            Me.ebNumInt.Enabled = False
        Else
            Me.ebNombre.Enabled = True
            Me.ebApellidoMaterno.Enabled = True
            Me.ebApellidoPaterno.Enabled = True
            Me.ebDomicilio.Enabled = True
            Me.ebColonia.Enabled = True
            Me.ebEstado.Enabled = True
            Me.ebCiudad.Enabled = True
            Me.ebCP.Enabled = True
            'Me.ebTelefono.Enabled = True
            Me.ebRFC.Enabled = True
            Me.ebNumExt.Enabled = True
            Me.ebNumInt.Enabled = True
        End If

        If bHabilita = False Then MessageBox.Show("No es posible modificar algunos datos debido" & vbCrLf & "a que el cliente actualmente adeuda un DPVale.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        '-------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (25.07.2016): Si el Clietne es de DPVale y esta activo el S2Credit, deshabilitamos los campos autorrellenables por sepomex
        '-------------------------------------------------------------------------------------------------------------------------------------
        DeshabilitarCamposS2Credit()

    End Sub

    Public Sub Valida()

        HabilitaCamposDPVale(True)

        If ebClienteID.Text.Trim <> String.Empty AndAlso IsNumeric(Me.ebClienteID.Text.Trim) AndAlso CInt(Me.ebClienteID.Text.Trim) > 0 Then

            If Me.ebTipoVenta.Text.Trim = "" Then
                'If bClickBuscar = False Then
                MessageBox.Show("Es necesario especificar el tipo de cliente a buscar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Else
                'bClickBuscar = False
                'End If
                Me.ebTipoVenta.Focus()
                Exit Sub
            End If
            'Dim CodTipoVenta As String = ""
            'CodTipoVenta = oClienteMgr.GetTipoVenta(Me.ebClienteID.Text).Trim
            'If CodTipoVenta.Length > 1 Then
            '    Me.ebTipoVenta.Value = CodTipoVenta.Substring(0, 1)
            'Else
            '    Me.ebTipoVenta.Value = CodTipoVenta
            'End If
            'Me.ebTipoVenta.Value = IIf(CodTipoVenta.Length > 1, CodTipoVenta.Substring(0, 1), CodTipoVenta)
            'Me.ebTipoVenta.Value = oClienteMgr.GetTipoVenta(Trim(Me.ebClienteID.Text).ToUpper)
            Dim strTipoVenta As String = Me.ebTipoVenta.Value

            Dim myID As String = ebClienteID.Text.Trim

            ValidaCliente(myID, strTipoVenta)

            If oCliente Is Nothing OrElse oCliente.CodigoAlterno.PadLeft(10, "0") = "0000000000" Then
                MsgBox("Cliente " & myID & " no está registrado. No Existe.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Clientes")
                ActivaNoModificables()
                ebClienteID.Focus()
            Else
                ebRecordCreateBy.Text = oCliente.RecordCreatedBy
                ebRecordCreateOn.Text = Format(oCliente.RecordCreatedOn, "dd/MM/yyyy")
                oCliente.ResetFlagNew()
                'Me.ebTipoVenta.Value = oClienteMgr.GetTipoVenta(Trim(Me.ebClienteID.Text).ToUpper)
                'Dim CodTipoVenta As String = ""
                'CodTipoVenta = oClienteMgr.GetTipoVenta(Me.ebClienteID.Text).Trim
                'oCliente.TipoVenta = IIf(CodTipoVenta.Length > 1, CodTipoVenta.Substring(0, 1), CodTipoVenta)

                Me.chkEmpresa.Checked = IIf(oCliente.Sexo.Trim.ToUpper = "E", True, False)

                ' oCliente.TipoVenta = oClienteMgr.GetTipoVenta(Trim(Me.ebClienteID.Text).ToUpper)
                DesactivaNoModificables()
                'Me.ebTipoVenta.Value = strTipoVenta
                'Me.msFechaNac.Text = Format(oCliente.FechaNacimiento, "dd/MM/yyyy")
                Me.cmbFechaNac.Value = oCliente.FechaNacimiento

                '-----------------------------------------
                ' JNAVA (26.02.2016): Ya no se usa
                '-----------------------------------------
                'oVendedor.ClearFields()
                'oVendedoresMgr.LoadInto(oCliente.CodPlayer, oVendedor)

                'If oCliente.CodPlayer <> String.Empty'oVendedor.ID <> String.Empty Then
                '    Me.ebCodVendedor.Text = oVendedor.ID
                '    ebPlayerDescripcion.Text = oVendedor.Nombre
                'Else
                '    Me.ebCodVendedor.Text = oCliente.CodPlayer
                'End If

                Me.ebEstado.Text = oCliente.Estado
                Dim oRow As DataRow
                For Each oRow In dtEstados.Rows
                    If CStr(Me.ebEstado.Value).Trim = CStr(oRow!CodEstado).Trim Then
                        Me.ebEstado.DropDownList.SetValue("EstadoID", oRow!EstadoID)
                    End If
                Next
                Dim strCiudadTemp As String = oCliente.Ciudad
                Dim strCPTemp As String = oCliente.CP
                Me.ebEstado_Validating(Nothing, Nothing)
                oCliente.Ciudad = strCiudadTemp
                oCliente.CP = strCPTemp
                Me.ebCiudad.Text = oCliente.Ciudad
                Me.ebCP.Text = oCliente.CP
                Me.ebCiudad_Validating(Nothing, Nothing)

                '------------------------------------------------------------------------------------------------
                ' JNAVA (02.03.2016): Se Modifico por que ya no se valida por rangos ni por tipo de venta
                '------------------------------------------------------------------------------------------------
                'If CLng(oCliente.CodigoAlterno) >= 70000000 AndAlso CLng(oCliente.CodigoAlterno) <= 89999999 Then
                '    Me.UiCommandBar2.Commands("menuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.False
                '    MessageBox.Show("Para actualizar los datos del distribuidor comunicarse a oficina de DPVale correspondiente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Else
                'Me.UiCommandBar2.Commands("menuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.True
                'If Me.ebTipoVenta.Value = "V" Then
                Dim bAdeuda As Boolean = False

                '------------------------------------------------------------------------------------
                ' JNAVA (01.08.2016):  Valida si el clietne esta congelado o adeuda un vale
                '------------------------------------------------------------------------------------
                If oConfigCierreFI.AplicarS2Credit Then
                    oS2Credit.ValidaCliente(Me.ebClienteID.Text, bAdeuda)
                Else
                    oSAPMgr.Valida_Clientes(Me.ebClienteID.Text, True, bAdeuda)
                End If
                '------------------------------------------------------------------------------------

                If bAdeuda Then HabilitaCamposDPVale(False)
                'End If
                'End If
                '------------------------------------------------------------------------------------------------

                bandera = True
            End If
            'Else
            '    If ebClienteID.Text <= 0 Then
            '        ebClienteID.Text = oCliente.CodigoAlterno
            '    End If
        End If

        'If bClickBuscar Then bClickBuscar = False

    End Sub

    'Public Sub Valida()

    '    HabilitaCamposDPVale(True)

    '    If ebClienteID.Text.Trim <> String.Empty AndAlso IsNumeric(Me.ebClienteID.Text.Trim) AndAlso CLng(Me.ebClienteID.Text.Trim) > 0 Then

    '        If Me.ebTipoVenta.Text.Trim = "" Then
    '            'If bClickBuscar = False Then
    '            MessageBox.Show("Es necesario especificar el tipo de cliente a buscar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            'Else
    '            'bClickBuscar = False
    '            'End If
    '            Me.ebTipoVenta.Focus()
    '            Exit Sub
    '        End If
    '        'Dim CodTipoVenta As String = ""
    '        'CodTipoVenta = Me.ebTipoVenta.Text 'oClienteMgr.GetTipoVenta(Me.ebClienteID.Text).Trim
    '        'If CodTipoVenta.Trim.Length > 1 Then
    '        '    Me.ebTipoVenta.Value = CodTipoVenta.Trim.Substring(0, 1)
    '        'Else
    '        '    Me.ebTipoVenta.Value = CodTipoVenta
    '        'End If
    '        'Me.ebTipoVenta.Value = IIf(CodTipoVenta.Length > 1, CodTipoVenta.Substring(0, 1), CodTipoVenta)
    '        'Me.ebTipoVenta.Value = oClienteMgr.GetTipoVenta(Trim(Me.ebClienteID.Text).ToUpper)
    '        Dim strTipoVenta As String = Me.ebTipoVenta.Value

    '        ' Dim myID As String = ebClienteID.Text.Trim

    '        ValidaCliente(ebClienteID.Text.Trim, strTipoVenta)

    '        If oCliente Is Nothing OrElse oCliente.CodigoCliente <= 0 Then
    '            MsgBox("Cliente " & ebClienteID.Text.Trim & " no está registrado. No Existe.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Clientes")
    '            ActivaNoModificables()
    '            Sm_Nuevo()
    '            'ebClienteID.Focus()
    '        Else
    '            ebRecordCreateBy.Text = oCliente.RecordCreatedBy
    '            ebRecordCreateOn.Text = Format(oCliente.RecordCreatedOn, "dd/MM/yyyy")
    '            oCliente.ResetFlagNew()
    '            'Me.ebTipoVenta.Value = oClienteMgr.GetTipoVenta(Trim(Me.ebClienteID.Text).ToUpper)
    '            'Dim CodTipoVenta As String = ""
    '            'CodTipoVenta = Me.ebTipoVenta.Text 'oClienteMgr.GetTipoVenta(Me.ebClienteID.Text).Trim
    '            ''oCliente.TipoVenta = IIf(CodTipoVenta.Length > 1, CodTipoVenta.Substring(0, 1), CodTipoVenta)
    '            'If CodTipoVenta.Trim.Length > 1 Then
    '            '    oCliente.TipoVenta = CodTipoVenta.Substring(0, 1)
    '            'Else
    '            '    oCliente.TipoVenta = CodTipoVenta.Trim
    '            'End If

    '            Me.chkEmpresa.Checked = IIf(oCliente.Sexo.Trim.ToUpper = "E", True, False)

    '            ' oCliente.TipoVenta = oClienteMgr.GetTipoVenta(Trim(Me.ebClienteID.Text).ToUpper)
    '            DesactivaNoModificables()
    '            'Me.ebTipoVenta.Value = strTipoVenta
    '            'Me.msFechaNac.Text = Format(oCliente.FechaNacimiento, "dd/MM/yyyy")
    '            Me.cmbFechaNac.Value = oCliente.FechaNacimiento

    '            'oVendedor.ClearFields()
    '            'oVendedoresMgr.LoadInto(oCliente.CodPlayer, oVendedor)

    '            'If oVendedor.ID <> String.Empty Then
    '            'Me.ebCodVendedor.Text = oVendedor.ID
    '            'ebPlayerDescripcion.Text = oVendedor.Nombre
    '            'Else
    '            'Me.ebCodVendedor.Text = oCliente.CodPlayer
    '            'End If

    '            Dim oRow As DataRow
    '            For Each oRow In dtEstados.Rows
    '                If CStr(oCliente.Estado).Trim = CStr(oRow!CodEstado).Trim Then
    '                    Me.ebEstado.DropDownList.SetValue("EstadoID", oRow!EstadoID)
    '                End If
    '            Next
    '            Me.ebEstado.Value = oCliente.Estado.Trim
    '            Dim strCiudadTemp As String = oCliente.Ciudad
    '            Dim strCPTemp As String = oCliente.CP
    '            Me.ebEstado_Validating(Nothing, Nothing)
    '            oCliente.Ciudad = strCiudadTemp
    '            oCliente.CP = strCPTemp
    '            Me.ebCiudad.Text = oCliente.Ciudad
    '            Me.ebCP.Text = oCliente.CP
    '            Me.ebCiudad_Validating(Nothing, Nothing)

    '            With oCliente
    '                Me.ebNombre.Text = .Nombre
    '                Me.ebApellidoMaterno.Text = .ApellidoMaterno
    '                Me.ebApellidoPaterno.Text = .ApellidoPaterno
    '                Me.ebDomicilio.Text = .Direccion
    '                Me.ebColonia.Text = .Colonia
    '                'Me.ebEstado.Value = .Estado
    '                'Me.ebCiudad.Text = .Ciudad
    '                'Me.ebCP.Text = .CP
    '                Me.ebTelefono.Text = .Telefono
    '                Me.ebEmail.Text = .EMail
    '                Me.ebSexo.Text = .Sexo
    '                Me.ebEstadoCivil.Text = .EstadoCivil
    '                Me.cmbFechaNac.Value = .FechaNacimiento
    '                Me.ebRFC.Text = .RFC
    '                Me.ebNumInt.Text = .NumInt
    '                Me.ebNumExt.Text = .NumExt
    '            End With

    '            'Verificamos si el cliente adeuda un vale para preguntar si realmente necesita modificar los datos
    '            If Me.ebTipoVenta.Value = "V" Then
    '                Dim bAdeuda As Boolean = False
    '                oSAPMgr.Valida_Clientes(Me.ebClienteID.Text, True, bAdeuda)
    '                If bAdeuda AndAlso MessageBox.Show("Este cliente actualmente adeuda un DPVale" & vbCrLf & _
    '                "¿Estas seguro de modificar sus datos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
    '                    HabilitaCamposDPVale(False)
    '                End If
    '            End If

    '            bandera = True
    '        End If
    '        'Else
    '        '    If ebClienteID.Text <= 0 Then
    '        '        ebClienteID.Text = oCliente.CodigoAlterno
    '        '    End If
    '    End If

    '    'If bClickBuscar Then bClickBuscar = False

    'End Sub

    Private Sub ValidaCliente(ByVal ClienteID As String, ByVal strTipoVenta As String)
        oCliente.Clear()
        If strTipoVenta Is Nothing Then strTipoVenta = ""
        If strTipoVenta.Trim <> "" Then
            Dim oClienteSAP As ClientesSAP
            If oConfigCierreFI.UsarDescargaClientes = False Then
                If EsDPVale Then
                    '--------------------------------------------------------------------------------------
                    ' JNAVA (22.04.2016): Si no encuentra cliente en Retail, lo buscamos en AFS
                    '--------------------------------------------------------------------------------------
                    EsClienteRetail = False

                    '--------------------------------------------------------------------------------------------
                    ' Validamos si existe cliente en AFS para actualizarlo o crearlo
                    '--------------------------------------------------------------------------------------------
                    oClienteSAP = GetClienteDPVale(ClienteID)

                    If oClienteSAP.Clienteid Is Nothing Then
                        EsClienteAFS = False
                    Else
                        EsClienteAFS = True
                    End If
                    '--------------------------------------------------------------------------------------
                Else
                    oClienteSAP = GetCliente(ClienteID, strTipoVenta)
                    '--------------------------------------------------------------------------------------
                    ' JNAVA (21.04.2016): Si no encuentra cliente en Retail, lo buscamos en AFS
                    '--------------------------------------------------------------------------------------
                    EsClienteAFS = False
                    If oClienteSAP.Clienteid Is Nothing Then
                        EsClienteRetail = False
                        'oClienteSAP = GetClienteDPVale(ClienteID)
                        'If oClienteSAP.Clienteid Is Nothing Then
                        '    EsClienteAFS = False
                        'Else
                        '    EsClienteAFS = True
                        'End If
                    Else
                        EsClienteRetail = True
                    End If
                    '--------------------------------------------------------------------------------------
                End If
               
            End If

            '--------------------------------------------------------------------------------------
            ' JNAVA (21.04.2016): Si no encuentra cliente en Retail ni en AFS, no lo busca en SQL
            '--------------------------------------------------------------------------------------
            If EsClienteRetail OrElse EsClienteAFS Then
                oClienteMgr.Load(ClienteID, oCliente, strTipoVenta)
            End If

            'ElseIf oConfigCierreFI.ValidaDatosDPVL Then ' oConfigCierreFI.UsarHuellas OrElse
            '    'Dim strValor As String = oFingerPMGr.GetCongif("GuardarServer").Trim

            '    'If strValor.Trim = "" Then strValor = "SI"

            '    'If strValor.Trim = "SI" Then
            '    GetClientePG(ClienteID)
            '    'End If
            '    oClienteMgr.LoadPG(IIf(IsNumeric(ClienteID), CInt(ClienteID), 0), oCliente)
            '    oCliente.TipoVenta = strTipoVenta
        End If
    End Sub

    Private Sub EliminarCliente()

        If (bolModuloContrato = True) Then

            MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If

        If oCliente.CodigoAlterno = "" OrElse oCliente.CodigoAlterno = "0" Then

            MsgBox("Ingrese Código de Cliente a eliminar. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Eliminar Cliente")

        Else

            Dim oMsgResult As MsgBoxResult

            oMsgResult = MsgBox("¿Esta seguro que desea eliminar al cliente? ", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "  Eliminar Cliente")

            If oMsgResult = MsgBoxResult.Yes Then

                Dim myID As String = oCliente.CodigoAlterno

                oClienteMgr.Delete(oCliente.CodigoAlterno)

                MsgBox("Se eliminó el Cliente :" & Format(oCliente.CodigoAlterno, "00000000"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Eliminar Cliente")

                ebRecordCreateBy.Text = ""
                ebRecordCreateOn.Text = ""

                oCliente.Clear()
                bandera = True

            Else

                ebClienteID.Focus()

            End If

        End If

    End Sub

    Private Sub FillComboEstados()

        dtEstados = oClienteMgr.GetAllStates(False)

        With ebEstado

            .DataSource = dtEstados
            .DropDownList.Columns.Add("Estado")
            .DropDownList.Columns.Add("CodEstado")
            .DropDownList.Columns.Add("EstadoID")
            .DropDownList.Columns("CodEstado").Visible = False
            .DropDownList.Columns("EstadoID").Visible = False
            .DropDownList.Columns("CodEstado").DataMember = "CodEstado"
            .DropDownList.Columns("Estado").DataMember = "Descripcion"
            .DropDownList.Columns("EstadoID").DataMember = "EstadoID"
            .DropDownList.Columns("Estado").Width = 170

            .DisplayMember = "Descripcion"
            .ValueMember = "CodEstado"

            .Refresh()

        End With


    End Sub

    Private Sub FillGeneralData()

        dtAlmacen = oClienteMgr.GetAllAlmacenes(False)
        dtMunicipio = oClienteMgr.GetAllMunicipio(False)

    End Sub

    Private Sub FilldtComboCiudades(ByVal Abrevia As String)

        Dim dvCiudades As DataView = New DataView(dtMunicipio)
        dvCiudades.RowFilter = "CodEstado like '" & Abrevia & "'"

        With ebCiudad

            .DropDownList.ClearStructure()

            .DataSource = dvCiudades
            .DropDownList.Columns.Add("CodMunicipio")
            .DropDownList.Columns.Add("Ciudad")
            .DropDownList.Columns("CodMunicipio").Visible = False
            .DropDownList.Columns("CodMunicipio").DataMember = "CodMunicipio"
            .DropDownList.Columns("Ciudad").DataMember = "NombreMunicipio"
            .DropDownList.Columns("Ciudad").Width = 170

            .DisplayMember = "NombreMunicipio"
            .ValueMember = "CodMunicipio"

            .Refresh()

        End With

        'If oCliente.Ciudad <> String.Empty Then
        '    ebCiudad.Text = oCliente.Ciudad
        'Else
        Dim strEstadoTemp As String = Me.ebEstado.Value
        If dvCiudades.Count > 0 Then
            'ebCiudad.Text = dvCiudades(0)!NombreMunicipio
            'ebCiudad.Value = Nothing
            If Me.ebEstado.Value <> oCliente.Estado Then
                oCliente.Ciudad = ""
                oCliente.CP = ""
            End If
        End If
        oCliente.Estado = strEstadoTemp

        'End If

    End Sub

    Private Function BuscaEstado(ByVal strEstado As String, Optional ByRef IDEstado As String = "") As String

        Dim i As Integer

        For i = 0 To (dtEstados.Rows.Count - 1)

            If dtEstados.Rows(i).Item("Descripcion") = strEstado Then

                '------------------------------------------------------------------------
                ' JNAVA (26.05.2016): Se obtiene le ID del Estado para calcular la Curp
                '------------------------------------------------------------------------
                IDEstado = dtEstados.Rows(i).Item("EstadoID")
                '------------------------------------------------------------------------
                Return dtEstados.Rows(i).Item("CodEstado")

            End If

        Next

        Return -1

    End Function

    Private Function BuscaMunicipio(ByVal strMunicipio As String, ByVal CodEstado As String) As Integer

        Dim i As Integer

        For i = 0 To (dtMunicipio.Rows.Count - 1)

            If dtMunicipio.Rows(i).Item("NombreMunicipio") = strMunicipio And dtMunicipio.Rows(i).Item("CodEstado") = CodEstado Then

                Return dtMunicipio.Rows(i).Item("CodMunicipio")

            End If

        Next

        Return -1

    End Function

    Private Sub FillComboAlmacen()

        With ebCodAlmacen

            .DropDownList.ClearStructure()

            .DataSource = dtAlmacen
            .DropDownList.Columns.Add("Código")
            .DropDownList.Columns.Add("Descripcion")
            '.DropDownList.Columns("CodAlmacen").Visible = False
            .DropDownList.Columns("Código").DataMember = "CodAlmacen"
            .DropDownList.Columns("Descripcion").DataMember = "Descripcion"
            .DropDownList.Columns("Descripcion").Width = 150
            .DropDownList.Columns("Código").Width = 50

            .DisplayMember = "CodAlmacen"
            .ValueMember = "CodAlmacen"

            .Refresh()

        End With

    End Sub

    Private Sub LoadSearchFormClientesSAP()

        If Me.ebTipoVenta.Text.Trim = "" Then
            MessageBox.Show("Es necesario especificar el tipo de cliente a buscar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'bClickBuscar = True
            Me.ebTipoVenta.Focus()
            Exit Sub
        End If

        oCliente.TipoVenta = Me.ebTipoVenta.Value

        Dim oOpenRecordDlg As OpenFROMSAPRecordDialogClientes
        Dim strTipoVenta As String = oCliente.TipoVenta

        oOpenRecordDlg = New OpenFROMSAPRecordDialogClientes
        oOpenRecordDlg.TipoVenta = Me.ebTipoVenta.Value
        oOpenRecordDlg.CurrentView = New ClientesFromSAPOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Try

                oCliente.Clear()
                If oOpenRecordDlg.pbCodigo = String.Empty Then
                    Me.ebClienteID.Text = oOpenRecordDlg.Record.Item("KUNNR")
                Else
                    Me.ebClienteID.Text = CType(oOpenRecordDlg.pbCodigo, String)
                End If
                Me.ebTipoVenta.Value = strTipoVenta
                Me.ebNombre.Focus()

                'If Me.ebTipoVenta.Value <> "P" Then
                '    If oConfigCierreFI.UsarDescargaClientes = False Then GetCliente(Me.ebClienteID.Text)

                '    strTipoVenta = oClienteMgr.GetTipoVenta(Trim(Me.ebClienteID.Text).PadLeft(10, "0"))
                '    If strTipoVenta Is Nothing Then strTipoVenta = ""
                '    oClienteMgr.Load(Me.ebClienteID.Text, oCliente, strTipoVenta)
                'Else
                '    oCliente = oClienteMgr.LoadPG(CInt(Me.ebClienteID.Text.Trim))
                'End If

                'With oCliente

                '    DesactivaNoModificables()

                '    ebRecordCreateBy.Text = .RecordCreatedBy
                '    ebRecordCreateOn.Text = Format(oCliente.RecordCreatedOn, "dd/MM/yyyy")
                '    chkFacturar.Focus()
                '    Me.ebTipoVenta.Value = strTipoVenta
                '    Me.msFechaNac.Text = Format(oCliente.FechaNacimiento, "dd/MM/yyyy")
                '    'If .RFCMoral <> String.Empty Then
                '    'Me.ebRFC.Text = .RFCMoral
                '    'Else
                '    Me.ebRFC.Text = .RFC
                '    'End If
                '    bandera = True

                '    oVendedor.ClearFields()
                '    oVendedoresMgr.LoadInto(.CodPlayer, oVendedor)

                '    If oVendedor.ID <> String.Empty Then
                '        Me.ebCodVendedor.Text = oVendedor.ID
                '        ebPlayerDescripcion.Text = oVendedor.Nombre
                '    Else
                '        Me.ebCodVendedor.Text = .CodPlayer
                '    End If

                'End With

            Catch ex As Exception
                Throw New ApplicationException("[LoadSearchForm]", ex)
            End Try

        End If

    End Sub

    Private Sub LoadSearchForm()

        'Dim oOpenRecordDlg As New OpenRecordDialog
        'oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

        'If Me.ebTipoVenta.Text.Trim = "" Then
        '    MessageBox.Show("Es necesario especificar el tipo de cliente a buscar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Me.ebTipoVenta.Focus()
        '    Exit Sub
        'End If

        Dim oOpenRecordDlg As OpenRecordDialogClientes

        Dim strTipoVenta As String = oCliente.TipoVenta
        oOpenRecordDlg = New OpenRecordDialogClientes
        oOpenRecordDlg.GrupoDeCuentas = oCliente.TipoVenta
        oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If


        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oCliente.Clear()

            Try
                Dim intClienteID As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    intClienteID = oOpenRecordDlg.Record.Item("CodigoAlterno")

                Else

                    intClienteID = CType(oOpenRecordDlg.pbCodigo, String)

                End If

                strTipoVenta = oClienteMgr.GetTipoVenta(Trim(intClienteID).PadLeft(10, "0"))
                If strTipoVenta Is Nothing Then strTipoVenta = ""
                strTipoVenta = IIf(strTipoVenta.Trim.Length > 1, strTipoVenta.Substring(0, 1), strTipoVenta)
                oClienteMgr.Load(intClienteID, oCliente, strTipoVenta)

                With oCliente

                    DesactivaNoModificables()

                    ebRecordCreateBy.Text = .RecordCreatedBy
                    ebRecordCreateOn.Text = Format(oCliente.RecordCreatedOn, "dd/MM/yyyy")
                    'chkFacturar.Focus()
                    Me.ebTipoVenta.Value = Me.oCliente.TipoVenta
                    'Me.msFechaNac.Text = Format(oCliente.FechaNacimiento, "dd/MM/yyyy")
                    Me.cmbFechaNac.Value = oCliente.FechaNacimiento
                    'If .RFCMoral <> String.Empty Then
                    'Me.ebRFC.Text = .RFCMoral
                    'Else
                    Me.ebRFC.Text = .RFC.Trim
                    'End If
                    bandera = True

                    oVendedor.ClearFields()
                    oVendedoresMgr.LoadInto(.CodPlayer, oVendedor)

                    If oVendedor.ID <> String.Empty Then
                        Me.ebCodVendedor.Text = oVendedor.ID
                        ebPlayerDescripcion.Text = oVendedor.Nombre
                    Else
                        Me.ebCodVendedor.Text = .CodPlayer
                    End If

                End With

            Catch ex As Exception

                Throw ex

            End Try

        End If

    End Sub

    Private Sub DesactivaNoModificables()

        Me.ebClienteID.Enabled = False
    End Sub

    Private Sub ActivaNoModificables()

        ebClienteID.Focus()
        Me.ebClienteID.Enabled = True

    End Sub
    '------------------------------------------------------------------------------------------
    ' JNAVA (29.02.2016): Se cambian los tipos de cliente solo dips y todos los demas
    '------------------------------------------------------------------------------------------
    Private Sub FillTipoCliente()

        ' Creamos tabla
        Dim dtCliente As New DataTable
        dtCliente.Columns.Add("CodTipoVenta")
        dtCliente.Columns.Add("Descripcion")

        ' Agregamos registros de tipos de clientes
        Dim oCliente As DataRow = dtCliente.NewRow()
        oCliente("CodTipoVenta") = "C"
        oCliente("Descripcion") = "CLIENTE DP"
        dtCliente.Rows.Add(oCliente)

        oCliente = dtCliente.NewRow()
        oCliente("CodTipoVenta") = "D"
        oCliente("Descripcion") = "DIP'S"
        dtCliente.Rows.Add(oCliente)

        ' Mostramos en el grid
        ebTipoVenta.DataSource = dtCliente
        ebTipoVenta.DisplayMember = "Descripcion"
        ebTipoVenta.ValueMember = "CodTipoVenta"

        '-------------------------------------------------------------------------
        ' JNAVA (26.05.2016): Si es Vale seteamos por default el Cliente DP
        '-------------------------------------------------------------------------
        If EsDPVale Then
            ebTipoVenta.Value = "C"
            ebTipoVenta.ReadOnly = True
        End If

    End Sub

    'Private Sub FillTipoVenta()

    '    Dim oTipoVentaMgr As New TiposVentaManager(oAppContext)

    '    dsTipoVenta = oTipoVentaMgr.Load()
    '    Dim dv As DataView
    '    If oAppContext.ApplicationConfiguration.Almacen = "053" Then
    '        'If oConfigCierreFI.UsarHuellas = False Then
    '        'dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta <> 'E' AND CodTipoVenta = 'K' OR CodTipoVenta = 'F' OR CodTipoVenta = 'S' OR CodTipoVenta = 'I' OR CodTipoVenta='A'", "CodTipoventa desc", DataViewRowState.CurrentRows)
    '        dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta <> 'E' AND CodTipoVenta = 'K' OR CodTipoVenta = 'F' OR CodTipoVenta = 'D' OR CodTipoVenta = 'I' OR CodTipoVenta='A'", "CodTipoventa desc", DataViewRowState.CurrentRows)
    '        'Else
    '        '    'dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta <> 'E' AND CodTipoVenta = 'P' OR CodTipoVenta = 'K' OR CodTipoVenta = 'F' OR CodTipoVenta = 'S' OR CodTipoVenta = 'I' OR CodTipoVenta='A'", "CodTipoventa desc", DataViewRowState.CurrentRows)
    '        '    dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta <> 'E' AND CodTipoVenta = 'P' OR CodTipoVenta = 'K' OR CodTipoVenta = 'F' OR CodTipoVenta = 'D' OR CodTipoVenta = 'I' OR CodTipoVenta='A'", "CodTipoventa desc", DataViewRowState.CurrentRows)
    '        'End If
    '        Me.UiCommandManager1.Commands.Item("menuImprimirTarjeta").Enabled = Janus.Windows.UI.InheritableBoolean.True
    '    Else
    '        If oConfigCierreFI.UsarHuellas = False AndAlso oConfigCierreFI.ValidaDatosDPVL = False Then
    '            dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta <> 'P' and CodTipoVenta <> 'M' and CodTipoVenta <> 'S' and CodTipoVenta <> 'E'", "CodTipoventa desc", DataViewRowState.CurrentRows)
    '        Else
    '            dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta <> 'M' and CodTipoVenta <> 'S' and CodTipoVenta <> 'E'", "CodTipoventa desc", DataViewRowState.CurrentRows)
    '        End If
    '        Me.UiCommandManager1.Commands.Item("menuImprimirTarjeta").Enabled = Janus.Windows.UI.InheritableBoolean.False
    '    End If

    '    ebTipoVenta.DataSource = dv

    '    ebTipoVenta.DisplayMember = "Descripcion"
    '    ebTipoVenta.ValueMember = "CodTipoVenta"

    '    oTipoVentaMgr.Dispose()

    'End Sub

    Private Sub Sm_Nuevo()

        Me.bolClickMenu = True
        If (bolModuloContrato = True) Then

            MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If

        chkStatus.Checked = True
        Me.chkEmpresa.Checked = False

        oCliente.Clear()
        'msFechaNac.Text = String.Empty
        Me.cmbFechaNac.Value = Today
        Me.ebCodVendedor.Text = String.Empty
        Me.ebPlayerDescripcion.Text = String.Empty
        Me.exbGuardarCliente.Visible = False

        Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) '.ApplicationConfiguration.Almacen)

        FillComboAlmacen()
        Me.ebCodAlmacen.Value = oAppContext.ApplicationConfiguration.Almacen

        oCliente.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
        'oCliente.CodPlaza = oAlmacen.PlazaID

        ebRecordCreateBy.Text = ""
        ebRecordCreateOn.Text = ""
        ActivaNoModificables()
        HabilitaCamposDPVale(True)
        Me.ebTipoVenta.Focus()

        bandera = True
        Me.bolClickMenu = False
        Me.EsClienteApproval = False

    End Sub

    Private Function ValidarEmail(ByVal sMail As String) As Boolean
        ' retorna true o false   
        Return Regex.IsMatch(sMail, _
                "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
    End Function

    Private Function ValidaEmail(ByVal strEmail As String) As Boolean

        Return Regex.IsMatch(strEmail.Trim, "^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" & _
                 "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")

    End Function

    '    Private Function BuscarHuellaDigital(Optional ByVal strOrigen As String = "") As Boolean

    '        Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False
    '        Application.DoEvents()

    '        Dim strCodTipoVentaAnt As String = Me.ebTipoVenta.Value
    '        Dim bResult As Boolean
    '        Dim dtClientesID As DataTable = oFingerPMGr.BuscarHuella
    '        Dim oRow As DataRow
    '        Dim CodTipoVentaSel As String = ""
    '        Dim strClienteID As String = ""

    '        If dtClientesID.Rows.Count > 0 Then
    '            'dtClientesID.Columns.Add(New DataColumn("TipoCliente", Type.GetType("System.String")))
    '            dtClientesID.Columns.Add(New DataColumn("CodTipoVenta", Type.GetType("System.String")))
    '            dtClientesID.AcceptChanges()

    '            'Dim dtView As New DataView(dsTipoVenta.Tables(0))
    '            Dim CodTipoVenta As String = ""

    '            For Each oRow In dtClientesID.Rows
    '                CodTipoVenta = CStr(oClienteMgr.GetTipoVenta(oRow!ClienteID)).Trim
    '                'dtView.RowFilter = "CodTipoVenta = '" & CodTipoVenta & "'"
    '                'oRow!TipoCliente = dtView(0)!Descripcion
    '                oRow!CodTipoVenta = IIf(CodTipoVenta.Trim.Length > 1, CodTipoVenta.Substring(0, 1), CodTipoVenta)
    '                'CodTipoVentaSel = CodTipoVenta
    '                If InStr(CodTipoVenta.Trim.ToUpper, CStr(Me.ebTipoVenta.Value).Trim.ToUpper) > 0 AndAlso CStr(Me.ebTipoVenta.Value).Trim <> "" Then
    '                    strClienteID = oRow!ClienteID
    '                    CodTipoVentaSel = IIf(Me.ebTipoVenta.Value <> "", Me.ebTipoVenta.Value, IIf(CodTipoVenta.Trim.Length > 1, CodTipoVenta.Substring(0, 1), CodTipoVenta))
    '                    Exit For
    '                ElseIf InStr(CodTipoVenta.Trim.ToUpper, "I") > 0 Then
    '                    strClienteID = oRow!ClienteID
    '                    CodTipoVentaSel = "I"
    '                End If
    '            Next
    '            dtClientesID.AcceptChanges()

    '            If strClienteID.Trim = "" Then
    '                strClienteID = dtClientesID.Rows(0)!ClienteID
    '                CodTipoVentaSel = dtClientesID.Rows(0)!CodTipoVenta
    '            End If

    '            oFingerP = oFingerPMGr.LoadByClienteID(strClienteID)

    '            If strOrigen <> "Guardar" Then
    '                Me.ebClienteID.Text = strClienteID
    '                If strCodTipoVentaAnt.Trim = "" Then Me.ebTipoVenta.Value = CodTipoVentaSel
    '            Else
    '                oFingerP.SetFlagNew()
    '            End If
    '            'Dim oFrmCodigos As New frmCandidatosFingerPrint
    '            'oFrmCodigos.dtCodigosCliente = dtClientesID
    '            'If oFrmCodigos.ShowDialog = DialogResult.OK Then
    '            'Me.ebClienteID.Text = oFrmCodigos.strClienteID

    '            'Else
    '            'Me.ebClienteID.Text = ""
    '            'End If
    '            bResult = True
    '        End If

    '        If strOrigen <> "Guardar" Then
    '            If Me.ebClienteID.Text.Trim <> "" AndAlso CLng(Me.ebClienteID.Text) > 0 AndAlso bResult = True Then
    '                Dim strClienteIDTemp As String = Me.ebClienteID.Text.Trim
    'BuscarCliente:
    '                Valida()
    '                If strCodTipoVentaAnt <> "" Then
    '                    Me.ebTipoVenta.Value = strCodTipoVentaAnt
    '                    Me.ebTipoVenta_Validating(Nothing, Nothing)
    '                End If

    '                If Me.ebClienteID.Text.Trim = "" OrElse CLng(Me.ebClienteID.Text) <= 0 Then
    '                    strClienteID = BuscarClienteByRFC(oCliente.RFC, strClienteIDTemp, Me.ebTipoVenta.Value)
    '                    If strClienteID.Trim <> "" Then
    '                        Me.ebClienteID.Text = strClienteID.Trim
    '                        GoTo BuscarCliente
    '                    End If
    '                    If ValidaDatos() Then
    '                        GuardadoAutomatico()
    '                    Else
    '                        MessageBox.Show("El cliente no esta registrado para este tipo de venta." & vbCrLf & "Favor de completar todos los datos del cliente y guardar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    End If
    '                End If
    '            Else
    '                Sm_Nuevo()
    '            End If
    '        End If

    '        Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.True

    '        Return bResult

    '    End Function

    '------------------------------------------------------------------------------------------
    ' JNAVA (14.02.2017): Validaciones de la RFC
    '------------------------------------------------------------------------------------------
    Private Function ValidaRFC(ByVal RFC As String) As Boolean
        Dim bResult As Boolean = True
        Dim strPatron As String = String.Empty

        If RFC.Contains("-") Then
            RFC = RFC.Replace("-", String.Empty)
        End If
        If oCliente.Sexo.Trim() = "E" Then
            If RFC.Trim().Length <> 12 Then
                MessageBox.Show("El RFC empresarial debe contar con 12 caracteres", "DPPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Else
            If RFC.Trim().Length <> 13 Then
                MessageBox.Show("El RFC de personas fisicas debe contar con 13 caracteres", "DPPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If
        '------------------------------------------------------------------------------------------
        ' Quitamos espacios en blanco
        '------------------------------------------------------------------------------------------
        'RFC = RFC.Replace(" ", String.Empty)

        '------------------------------------------------------------------------------------------
        ' Validamos si es empresa para determinar el formato de la RFC
        '------------------------------------------------------------------------------------------
        strPatron = "^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z\d]{3})?$"
        'If Me.chkEmpresa.Checked Then
        '    
        'Else
        '    strPatron = "^([A-Z\s\s+]{4})\d{6}([A-Z\w]{3})$"
        'End If

        '------------------------------------------------------------------------------------------
        ' Validaciones de la RFC
        '------------------------------------------------------------------------------------------
        If Not Regex.IsMatch(RFC, strPatron) Then
            MessageBox.Show("RFC Invalida. Favor de verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bResult = False
        End If

        ''-------------------------------------------------------------------------------------------
        '' Validamos que la rfc en empresas tenga los caracteres correctos (12 o más digitos)
        ''-------------------------------------------------------------------------------------------
        'If Me.ebRFC.UnmaskedText.Trim.Length < 12 AndAlso Me.chkEmpresa.Checked = True Then
        '    MessageBox.Show("RFC invalido. La longitud es incorrecta.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    bResult = False
        'End If

        ''-------------------------------------------------------------------------------------------
        '' Validamos que la rfc tenga los caracteres correctos (13 o más digitos)
        ''-------------------------------------------------------------------------------------------
        'If Me.ebRFC.UnmaskedText.Trim.Length < 13 AndAlso Me.chkEmpresa.Checked = False Then
        '    MessageBox.Show("RFC invalido. La longitud es incorrecta.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    bResult = False
        'End If

        Return bResult

    End Function

#End Region

#Region "Fiscal Data Methods"

    'Private Sub ebCodAlmacen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodAlmacen.LostFocus
    '    Me.ebClienteID.Focus()
    'End Sub

    Private Sub ebClienteID_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If EsDPVale Then
            LoadSearchFormDPVale()
        Else
            LoadSearchForm()
        End If


    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged

        If chkStatus.Checked Then

            lblStatus.Text = "ACTIVO"
            pbActivo.Visible = True
            pbInactivo.Visible = False
            UiCommandManager1.Commands.Item("menuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.True

        Else

            lblStatus.Text = "INACTIVO"
            pbActivo.Visible = False
            pbInactivo.Visible = True
            UiCommandManager1.Commands.Item("menuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False

        End If

    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoSalir"
                Me.bolClickMenu = True
                Me.Close()

            Case "menuArchivoGuardar"

                GuardarCliente()

            Case "menuArchivoEliminar"

                EliminarCliente()
                Me.ebTipoVenta.Focus()

            Case "menuArchivoNuevo"
                'Me.bolClickMenu = True
                'If (bolModuloContrato = True) Then

                '    MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
                '    Exit Sub

                'End If

                'chkStatus.Checked = True

                'oCliente.Clear()
                'msFechaNac.Text = String.Empty
                'Me.ebCodVendedor.Text = String.Empty
                'Me.ebPlayerDescripcion.Text = String.Empty

                'Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
                'Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
                'oAlmacen = oCatalogoAlmacenesMgr.Load(oAppContext.ApplicationConfiguration.Almacen)

                'FillComboAlmacen()
                'Me.ebCodAlmacen.Value = oAppContext.ApplicationConfiguration.Almacen

                'oCliente.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
                'oCliente.CodPlaza = oAlmacen.PlazaID

                'ebRecordCreateBy.Text = ""
                'ebRecordCreateOn.Text = ""
                'ActivaNoModificables()
                'Me.ebTipoVenta.Focus()


                'bandera = True
                'Me.bolClickMenu = False

                Sm_Nuevo()

            Case "menuCatalogoCiudad"

                Dim oCatalogoB As New CatalogoCiudadesForm
                oCatalogoB.Show()


            Case "menuCatalogoColonia"

                Dim oCatalogoB As New frmColonias
                oCatalogoB.Show()

            Case "menuCatalogoEstado"

                Dim oCatalogoB As New frmEstado
                oCatalogoB.Show()

            Case "menuCatalogoTCliente"

                Dim oCatalogoB As New frmTipoCliente
                oCatalogoB.Show()

            Case "menuImprimirTarjeta"

                If Me.oCliente.CodigoAlterno = String.Empty OrElse Me.oCliente.CodigoAlterno = "0".PadLeft(10, "0") Then
                    MessageBox.Show("Aun no registra al cliente", "DPTienda", MessageBoxButtons.OK)
                    Me.ebNombre.Focus()
                    Exit Sub
                End If

                Dim ofrmImprimir As New DPPhoto.frmImpresionTarjetas
                Dim oDPSocio As New DPPhoto.DPSocio
                With Me.oCliente
                    oDPSocio.ApellidoMaterno = .ApellidoMaterno
                    oDPSocio.ApellidoPaterno = .ApellidoPaterno
                    oDPSocio.CodigoSocio = .CodigoAlterno
                    oDPSocio.MiembroDesde = .RecordCreatedOn
                    oDPSocio.Nombre = .Nombre
                End With
                ofrmImprimir.DPSocio = oDPSocio
                ofrmImprimir.ShowDialog()

        End Select

    End Sub

    Private Sub GuardarCliente()

        Dim bRes As Boolean = True
        Dim RegClienteDPCardApprova As Boolean = False

        Try

            '-----------------------------------------------------------------------------------------------
            'Inicio JEMO (20/10/2016) guardar datos de cliente  para tarjeta dpcard'
            '-----------------------------------------------------------------------------------------------
            If oConfigCierreFI.DPCardPuntos AndAlso oConfigCierreFI.RegistroApprova Then 'JNAVA (15.03.2017): Agregamos configuracion de Registro de Approva
                If MessageBox.Show("¿Quiere realizar el registro de crédito para tarjeta DPCard Puntos?", "DPTienda", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    RegClienteDPCardApprova = True
                    Me.EsClienteApproval = True
                Else
                    RegClienteDPCardApprova = False
                End If
            End If
            'Fin JEMO-----------------------------------------------------'

            If ValidaDatos(RegClienteDPCardApprova) Then

                oCliente.GenerateRFC = False 'para cuando le den grabar no genere el RFC
                'If InStr(1, Me.ebRFC.Text, "-", CompareMethod.Text) = 4 Then
                oCliente.RFCMoral = Me.ebRFC.UnmaskedText.Replace(" ", String.Empty)
                oCliente.RFC = Me.ebRFC.UnmaskedText.Replace(" ", String.Empty)

                'Else
                'oCliente.RFCMoral = String.Empty
                'End If

                If esInstanciaFactura Then
                    Me.ebTipoVenta.Value = Me.TipoVenta
                    Me.oCliente.TipoVenta = Me.TipoVenta
                End If

                'Tipo de lista de precios se saca se de la Tabla CatalogoTipoVenta
                oCliente.TipoListaPrecios = ebTipoVenta.DropDownList.GetValue("ListaPrecios")

                '-----------------------------------------------------'
                'Inicio JEMO (201/10/2016) guardar datos de cliente  para tarjeta dpcard'
                '-----------------------------------------------------'
                If RegClienteDPCardApprova Then
                    ClienteDPCardApprova()
                End If
                'Fin JEMO-----------------------------------------------------'

                SaveCliente(bRes)

                ''-----------------------------------------------------
                '' JNAVA (11.04.2016): guarda cliente en S2Credit
                ''-----------------------------------------------------
                'If Me.ebTipoVenta.Value <> "D" Then
                '    SaveClienteS2Credit()
                'End If
                ''-----------------------------------------------------

                Me.ebClienteID.Text = oCliente.CodigoAlterno

                If (esInstanciaAsociado OrElse esInstanciaFactura) AndAlso bRes Then

                    Me.ClienteID = oCliente.CodigoAlterno
                    Me.NombreApellidos = Trim(oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno)
                    Me.CodigoClienteDPVALE = oCliente.CodigoClienteDPVALE

                    Me.DialogResult = DialogResult.OK
                ElseIf ActivacionPuntos Then
                    Me.ClienteID = oCliente.CodigoAlterno
                    Me.NombreApellidos = Trim(oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno)
                    Me.CodigoClienteDPVALE = oCliente.CodigoClienteDPVALE

                    Me.DialogResult = DialogResult.OK
                    bRes = False
                End If

                'If oConfigCierreFI.UsarHuellas = True Then
                '    oFingerPMGr.GuardarHuella(Me.ebClienteID.Text)
                'End If

                'oCliente.GenerateRFC = True

                If bRes Then
                    Sm_Nuevo()
                End If

                Me.ebTipoVenta.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CatalogoClientesForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        ElseIf (e.KeyCode = Keys.Escape) Then

            Me.bolClickMenu = True
            Me.Close()

        End If

    End Sub

    Private Sub ebClienteID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebClienteID.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            If EsDPVale Then

                LoadSearchFormDPVale()

            Else

                If oConfigCierreFI.UsarDescargaClientes Then
                    LoadSearchForm()
                Else
                    LoadSearchFormClientesSAP()
                End If

            End If

        End If

    End Sub

    Private Sub ebClienteID_ButtonClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteID.ButtonClick

        If EsDPVale Then

            'If oConfigCierreFI.UsarDescargaClientes Then
            LoadSearchFormDPVale()
            'Else
            '    LoadSearchFormClientesSAP()
            'End If
        Else

            If oConfigCierreFI.UsarDescargaClientes Then
                LoadSearchForm()
            Else
                LoadSearchFormClientesSAP()
            End If
        End If


    End Sub


#End Region

#Region "Validating"

    Private Sub msFechaNac_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbFechaNac.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        'If (msFechaNac.Text.Trim = String.Empty) Then

        '    e.Cancel = True
        '    Return

        'End If


        If cmbFechaNac.Text.Trim <> String.Empty Then

            If IsDate(cmbFechaNac.Text.Trim) AndAlso (Me.chkEmpresa.Checked OrElse (Me.chkEmpresa.Checked = False AndAlso cmbFechaNac.Value <= Today.AddYears(-7))) _
            AndAlso cmbFechaNac.Value <= Today Then

                oCliente.FechaNacimiento = cmbFechaNac.Value 'CDate(msFechaNac.Text & " 01:00:00")

            Else

                MsgBox("Valor de Fecha Incorrecta. Verifique. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Clientes")
                'cmbFechaNac.Text = String.Empty
                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub ebCiudad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCiudad.Validating
        If Me.bolClickMenu = True Then
            Exit Sub
        End If


        'If (ebCiudad.Text.Trim = String.Empty) Then

        '    e.Cancel = True
        '    Return

        'End If


        Dim vValueTemp As Integer


        If ebCiudad.Text.Trim <> "" Then

            vValueTemp = BuscaMunicipio(ebCiudad.Text, Me.ebEstado.Value)

            If vValueTemp < 0 Then

                MsgBox("Ciudad no se encuentra registrada. No Existe.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Clientes")

                'e.Cancel = True

            Else

                ebCiudad.Value = vValueTemp


                dsCodigos = oClienteMgr.GetRange(Me.ebEstado.Value, Me.ebCiudad.Value).Copy

                rango1 = CType(dsCodigos.Tables("codigos").Rows(0).Item(0), Integer)
                rango2 = CType(dsCodigos.Tables("codigos").Rows(0).Item(1), Integer)


            End If

        End If

        'ctrlError(sender, e)
    End Sub

    Private Sub ebSexo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebSexo.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        'If (ebSexo.Text.Trim = String.Empty) Then

        '    MessageBox.Show("Seleccione sexo.", "DPortenis Pro", MessageBoxButtons.OK)
        '    e.Cancel = True
        '    Return

        'End If

    End Sub

    Private Sub ebEstado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebEstado.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        'If (ebEstado.Text.Trim = String.Empty) Then

        '    ebEstado.Focus()
        '    Return

        'End If


        Dim vValueTemp As Integer

        If ebEstado.Text.Trim <> "" Then

            If ebEstado.Value Is Nothing Then

                vValueTemp = BuscaEstado(ebEstado.Text)

                If vValueTemp < 0 Then

                    MsgBox("Estado no se encuentra registrado. No Existe. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Clientes")

                    e.Cancel = True

                Else

                    ebEstado.Value = vValueTemp

                    FilldtComboCiudades(vValueTemp)

                End If

            Else

                FilldtComboCiudades(ebEstado.Value)

            End If

        Else

            ebCiudad.DropDownList.ClearStructure()

        End If

        'ctrlError(sender, e)
    End Sub

    Private Sub ebCP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCP.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        'If (ebCP.Text.Trim = String.Empty) Then

        '    ebCP.Focus()
        '    Return

        'End If

        If ebCP.Text.Trim <> "" AndAlso Not (ebCiudad.Value Is Nothing) AndAlso Not (ebEstado.Value Is Nothing) Then

            If (ebCiudad.Value < 0) OrElse (ebEstado.Value = String.Empty) Then

                MsgBox("Seleccione un Estado/Ciudad válidos.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Clientes")
                ebCP.Text = ""
                e.Cancel = True

            Else

                'If Not (oClienteMgr.GetZipCode(ebEstado.Value, ebCiudad.Value, ebCP.Text)) Then
                If (CType(ebCP.Text, Integer) < rango1) Or (CType(ebCP.Text, Integer) > rango2) Then
                    MessageBox.Show("Código postal no corresponde a la ciudad. Código entre " & rango1 & " y " & rango2, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    'Me.ErrorProvider1.SetError(ebCP, "Entre " & rango1 & " y " & rango2)

                    e.Cancel = True
                Else
                    'Me.ErrorProvider1.SetError(ebCP, "")
                End If

            End If

            'ElseIf ebCP.Text.Equals("") Then

            '    'Me.ErrorProvider1.SetError(ebCP, "Código Postal Requerido")
            '    e.Cancel = True

        Else
            '----------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (22.07.2016): Validamos si esta activo el S2credi y es DPVAle, mostrar pantalla de Codigos Postales de S2Credit
            '----------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.AplicarS2Credit AndAlso EsDPVale Then
                BuscarCodigoPostalS2Credit(Me.ebCP.Text)
                Exit Sub
            End If

        End If

    End Sub

    Private Sub ebApellidos_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebApellidoPaterno.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        'If (Me.ebApellidoPaterno.Text.Trim = String.Empty) Then
        '    MessageBox.Show("Teclee el Apellido Paterno.", "DPortenis Pro", MessageBoxButtons.OK)
        '    e.Cancel = True
        '    Return

        'End If

    End Sub

    Private Sub ebDomicilio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebDomicilio.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        ebDomicilio.Text = Regex.Replace(ebDomicilio.Text, "[^0-9A-Za-z]", " ", RegexOptions.None)

        'If (ebDomicilio.Text.Trim = String.Empty) Then
        '    MessageBox.Show("Teclee Domicilio.", "DPortenis Pro", MessageBoxButtons.OK)
        '    e.Cancel = True
        '    Return

        'End If

    End Sub

    Private Sub ebColonia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebColonia.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        'If (ebColonia.Text.Trim = String.Empty) Then
        '    MessageBox.Show("Seleccione colonia.", "DPortenis Pro", MessageBoxButtons.OK)
        '    e.Cancel = True
        '    Return

        'End If

    End Sub

    Private Sub ebNombre_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNombre.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        'If (ebNombre.Text.Trim = String.Empty) Then
        '    MessageBox.Show("Teclee el Nombre.", "DPortenis Pro", MessageBoxButtons.OK)
        '    e.Cancel = True
        '    Return

        'End If

    End Sub

    Private Sub ebTelefono_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTelefono.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        'If (ebTelefono.Text.Trim = String.Empty) Then
        '    MessageBox.Show("Teclee el Télefono.", "DPortenis Pro", MessageBoxButtons.OK)
        '    e.Cancel = True
        '    Return

        'End If
    End Sub

    Private Sub ebEstadoCivil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebEstadoCivil.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        'If (ebEstadoCivil.Text.Trim = String.Empty) Then
        '    MessageBox.Show("Seleccione estado civil.", "DPortenis Pro", MessageBoxButtons.OK)
        '    ebEstadoCivil.Focus()
        '    Return

        'End If

    End Sub

    Private Sub ebCodAlmacen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodAlmacen.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        'If (ebCodAlmacen.Text.Trim = String.Empty) Then
        '    MessageBox.Show("Falta Almacen.", "DPortenis Pro", MessageBoxButtons.OK)
        '    ebCodAlmacen.Focus()
        '    Return

        'End If

    End Sub

    Private Sub ebApellidoMaterno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebApellidoMaterno.Validating

        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        'If (Me.ebApellidoMaterno.Text.Trim = String.Empty) Then
        '    MessageBox.Show("Teclee el Apellido Materno.", "DPortenis Pro", MessageBoxButtons.OK)
        '    e.Cancel = True

        'End If
    End Sub

    Private Sub frmClientesSAP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bolClickMenu = True
        Me.Refresh()

        'Inicializamos objeto
        InitializeObjects()

        ''Llenamos Catalogo de Ventas
        'FillTipoVenta()

        'Llenamos Catalogo de Clientes
        FillTipoCliente()

        'Inicializamos vinculos
        InitializeBinding()

        'Llenamos el combo de estados
        FillComboEstados()

        FillGeneralData()

        Me.ebEstado.Text = ""
        If (bolModuloContrato = True) Then

            oCliente.Clear()

            oClienteMgr.Load(intClienteID, oCliente, Me.TipoVenta)

            'Me.msFechaNac.Text = Format(oCliente.FechaNacimiento, "dd/MM/yyyy")
            Me.cmbFechaNac.Value = oCliente.FechaNacimiento

            DesactivaNoModificables()

            Me.ebTipoVenta.Value = Me.TipoVenta
        End If

        If (bolFactDIpsUpdate = True) Then

            oCliente.Clear()

            oClienteMgr.Load(intClienteID, oCliente, Me.TipoVenta)

            DesactivaNoModificables()

            Me.ebTipoVenta.Value = Me.TipoVenta

            If StrPlayer <> String.Empty Then oVendedoresMgr.Load(StrPlayer)

        End If

        Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
        Dim strCentroSAP As String = oSAPMgr.Read_Centros
        oAlmacen = oCatalogoAlmacenesMgr.Load(strCentroSAP) '"2" & oAppContext.ApplicationConfiguration.Almacen)

        FillComboAlmacen()
        Me.ebCodAlmacen.Value = oAppContext.ApplicationConfiguration.Almacen

        oCliente.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
        oCliente.CodPlaza = oAlmacen.PlazaID

        'SendKeys.Send("{TAB}")

        If esInstanciaAsociado Then
            bolClickMenu = False
            LoadDataForAsociado()
        Else
            ebClienteID.Focus()
        End If

        If esInstanciaFactura Then
            bolClickMenu = False
            ProcesoFromFactura()
        End If
        bolClickMenu = False

        '-------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (21.07.2016): Si el Clietne es de DPVale y esta activo el S2Credit, deshabilitamos los campos autorrellenables por sepomex
        '-------------------------------------------------------------------------------------------------------------------------------------
        DeshabilitarCamposS2Credit()

    End Sub

    Private Sub ProcesoFromFactura()
        If oConfigCierreFI.ValidaDatosDPVL Then
            Dim strClienteID As String = ""
BuscarCliente:
            If intClienteID.Trim = "" Then intClienteID = "0"
            If strClienteID.Trim <> "" Then
                ValidaCliente(strClienteID, Me.TipoVenta)
                If CLng(oCliente.CodigoAlterno) > 0 Then
                    Me.ClienteID = oCliente.CodigoAlterno
                    Me.NombreApellidos = CStr(oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno).Trim
                    Me.CodigoClienteDPVALE = oCliente.CodigoClienteDPVALE
                    Me.DialogResult = DialogResult.OK
                    Exit Sub
                End If
            ElseIf intClienteID.Trim <> "" AndAlso CInt(intClienteID) > 0 Then
                ValidaCliente(intClienteID, Me.TipoCliente)
            End If
            If CLng(oCliente.CodigoAlterno) > 0 Then
                strClienteID = BuscarClienteByRFC(oCliente.RFC, intClienteID, Me.TipoVenta)
                If strClienteID.Trim <> "" Then GoTo BuscarCliente
            End If
            'oCliente.Clear()
            'oClienteMgr.Load(intClienteID, oCliente, Me.TipoCliente)
        ElseIf oConfigCierreFI.UsarHuellas AndAlso Me.intClienteID.Trim <> "" Then
            Me.ebClienteID.Text = Me.intClienteID
            Me.ebTipoVenta.Value = Me.TipoCliente
            Valida()
        End If
        LoadDataForFactura()
        If CInt(oCliente.CodigoAlterno) > 0 Then
            'oCliente.CodigoAlterno = "0".PadLeft(10, "0")
            'oCliente.CodigoCliente = 0
            oCliente.SetFlagNew()
            If StrPlayer <> String.Empty Then
                Me.ebCodVendedor.Text = StrPlayer
            Else
                Me.ebCodVendedor.Text = oCliente.CodPlayer
            End If
            oCliente.CodPlayer = ""
            Me.ebCodVendedor_Validating(Nothing, Nothing)
            '---------------------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS (03.10.2019): Se comenta, no muestra la forma para capturar los datos y se queda colgado despues de grabar el cliente
            '---------------------------------------------------------------------------------------------------------------------------------            
            'If ValidaDatos(False) Then
            '    GuardadoAutomatico()
            'End If
        End If
    End Sub

    Private Function BuscarClienteByRFC(ByVal RFC As String, ByVal ClienteID As String, ByVal TipoVenta As String, Optional ByVal SoloBuscar As Boolean = False) As String

        RFC = RFC.Trim.Replace("-", "")

        'Dim dtTemp As DataTable = oSAPMgr.ZBAPI_GET_CLIENTE_BY_RFC(RFC)
        Dim oRetail As New ProcesosRetail("/pos/clientes", "POST")
        Dim dtTemp As DataTable = oRetail.ZbapiGetClienteByrfc(RFC)
        Dim oRow As DataRow
        Dim strError As String = ""
        Dim dtCliente As DataTable
        Dim bRes As Boolean = False
        Dim strClienteID As String = ""
        Dim strCodTipoVenta As String = ""
        Dim oNewRow As DataRow

        dtCliente = dtTemp.Copy

        'dtTemp = oClienteMgr.GetClienteByRFC(RFC)

        For Each oRow In dtTemp.Rows
            oNewRow = dtCliente.NewRow
            oNewRow!Kunnr = CStr(oRow!KUNNR.Trim.PadLeft(10, "0"))
            dtCliente.Rows.Add(oNewRow)
        Next
        dtCliente.AcceptChanges()

        If dtCliente.Rows.Count > 0 Then
            For Each oRow In dtCliente.Rows
                strClienteID = oRow!Kunnr
                strCodTipoVenta = oClienteMgr.GetTipoVenta(strClienteID)
                If CInt(strClienteID) <> CInt(ClienteID) AndAlso InStr(strCodTipoVenta.Trim, TipoVenta.Trim) > 0 Then
                    strError = ""
                    'If SoloBuscar = False Then
                    '    oFingerP.SetFlagNew()
                    '    oFingerPMGr.GuardarHuella(CStr(strClienteID).Trim.PadLeft(10, "0"), IIf(strCodTipoVenta <> "P", True, False), TipoVenta, ContarDatosCapturados, strError, True, oFingerP)
                    'End If
                    'If strError.Trim <> "" Then
                    '    EscribeLog(strError, "Error al guardar huella digital.")
                    'Else
                    '    bRes = True
                    'End If
                    Exit For
                End If
            Next
        End If

        If bRes = False Then strClienteID = ""

        Return strClienteID

    End Function

    Private Function ContarDatosCapturados() As Integer

        Dim intCont As Integer = 0

        With oCliente
            If .Nombre.Trim <> "" Then intCont += 1
            If .ApellidoPaterno.Trim <> "" Then intCont += 1
            If .ApellidoMaterno.Trim <> "" Then intCont += 1
            If .Direccion.Trim <> "" Then intCont += 1
            If .Colonia.Trim <> "" Then intCont += 1
            If .Estado.Trim <> "" Then intCont += 1
            If .Ciudad.Trim <> "" Then intCont += 1
            If .CP.Trim <> "" Then intCont += 1
            If .Telefono.Trim <> "" Then intCont += 1
            If .EMail.Trim <> "" Then intCont += 1
            If .Sexo.Trim <> "" Then intCont += 1
            If .EstadoCivil.Trim <> "" Then intCont += 1
            If .FechaNacimiento.ToShortDateString.Trim <> "" Then intCont += 1
            If .RFC.Trim <> "" Then intCont += 1
        End With

        Return intCont

    End Function

    Private Sub GuardadoAutomatico()
        Me.pbAvance.Value = 0
        Me.pbAvance.Minimum = 0
        Me.pbAvance.Maximum = 2
        Me.exbGuardarCliente.Left = 120
        Me.exbGuardarCliente.Top = 160
        Me.exbGuardarCliente.Visible = True
        Application.DoEvents()
        Me.pbAvance.Value = 1
        GuardarCliente()
        Me.pbAvance.Value = 2
        Me.exbGuardarCliente.Visible = False
    End Sub

    Private Sub ebTipoVenta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTipoVenta.Validating
        If Me.bolClickMenu = True Then
            Exit Sub
        End If

        '------------------------------------------------------------------------------------
        ' JNAVA (13.07.2016): Si no se ha seleccionado el tipo de venta, que se salga
        '------------------------------------------------------------------------------------
        If Me.ebTipoVenta.Value Is Nothing Then
            Exit Sub
        End If
        '------------------------------------------------------------------------------------

        If oCliente.CodigoAlterno.Trim <> "" AndAlso CInt(oCliente.CodigoAlterno.Trim) > 0 Then
            oCliente.TipoVenta = Me.ebTipoVenta.Value
            If InStr(oClienteMgr.GetTipoVenta(oCliente.CodigoAlterno.Trim).Trim, CStr(Me.ebTipoVenta.Value).Trim) <= 0 Then
                oCliente.CodigoAlterno = "0".PadLeft(10, "0")
                oCliente.CodigoCliente = 0
                oCliente.SetFlagNew()
            End If
        End If

        If Me.ebTipoVenta.Value = "C" Then
            Me.chkEmpresa.Enabled = True
        Else
            oCliente.TipoVenta = Me.ebTipoVenta.Value
            Me.chkEmpresa.Checked = False
            Me.chkEmpresa.Enabled = False
        End If

    End Sub

    Private Sub ebRFC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebRFC.Validating
        If Me.bolClickMenu = True Then
            Exit Sub
        End If


        'If Me.ebRFC.Text = String.Empty Then
        '    MessageBox.Show("Teclee el RFC.", "DPortenis Pro", MessageBoxButtons.OK)
        '    e.Cancel = True
        'End If

    End Sub

#End Region

#Region "Methods Asociados"

    Public Sub ShowMeforAsociado(ByVal ClienteID As Integer)

        vClienteID = ClienteID

        esInstanciaAsociado = True

        Me.ShowDialog()

    End Sub

    Private Sub LoadDataForAsociado()

        UiCommandBar1.Enabled = False
        UiCommandBar2.Commands("menuArchivoNuevo").Enabled = Janus.Windows.UI.InheritableBoolean.False
        UiCommandBar2.Commands("menuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        UiCommandBar2.Commands("menuBarTema").Enabled = Janus.Windows.UI.InheritableBoolean.False
        'oClienteMgr.LoadInto(vClienteID, oCliente)
        'msFechaNac.Text = Format(oCliente.FechaNacimiento, "dd/MM/yyyy")
        ebClienteID.Enabled = False

    End Sub

    Public Sub ShowMeforFactura() 'ByVal CodTipoVenta As String, Optional ByVal ClienteID As String = "")

        esInstanciaFactura = True
        'If ClienteID.Trim <> "" Then
        '    Me.ebClienteID.Text = ClienteID
        '    Valida()
        'End If
        'Me.ebTipoVenta.Value = CodTipoVenta
        Me.ShowDialog()

    End Sub

    Private Sub LoadDataForFactura()

        UiCommandBar1.Enabled = False
        UiCommandBar2.Commands("menuArchivoNuevo").Enabled = Janus.Windows.UI.InheritableBoolean.False
        UiCommandBar2.Commands("menuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        UiCommandBar2.Commands("menuBarTema").Enabled = Janus.Windows.UI.InheritableBoolean.False
        'UiCommandBar2.Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.ebTipoVenta.Value = Me.TipoVenta
        oCliente.TipoVenta = Me.TipoVenta
        Me.ebTipoVenta.Enabled = False
        Me.ebClienteID.Enabled = False
        If Me.ebTipoVenta.Value = "C" Then Me.chkEmpresa.Enabled = True

    End Sub

#End Region

    Private Sub ebTipoVenta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebTipoVenta.ValueChanged
        oCliente.GrupoCliente = ebTipoVenta.DropDownList.GetValue("CodSAP")
        oCliente.TipoListaPrecios = ebTipoVenta.DropDownList.GetValue("ListaPrecios")
        'oCliente.TipoVenta = ebTipoVenta.DropDownList.GetValue("TipoCliente")
        'strTipoVenta = oCliente.TipoVenta
        ' MsgBox(ebTipoVenta.DropDownList.GetValue("CodSAP"))
    End Sub

    Private Sub ebCodVendedor_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodVendedor.ButtonClick
        LoadSearchFormPlayer()
    End Sub

    Private Sub LoadSearchFormPlayer()

        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

        oOpenRecordDialogView.ShowDialog()

        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then

            If oOpenRecordDialogView.pbNombre <> String.Empty Then

                Me.ebCodVendedor.Text = oOpenRecordDialogView.pbCodigo
                oCliente.CodPlayer = oOpenRecordDialogView.pbCodigo
                ebPlayerDescripcion.Text = oOpenRecordDialogView.pbNombre

            Else

                Me.ebCodVendedor.Text = oOpenRecordDialogView.Record.Item("CodVendedor")
                oCliente.CodPlayer = oOpenRecordDialogView.Record.Item("CodVendedor")
                ebPlayerDescripcion.Text = oOpenRecordDialogView.Record.Item("Nombre")

            End If


        End If

        oOpenRecordDialogView.Dispose()

        oOpenRecordDialogView = Nothing

    End Sub

    Private Sub LoadSearchFormCPs()

        If ebCiudad.Value Is Nothing OrElse ebEstado.Value Is Nothing Then
            MsgBox("Seleccione un Estado/Ciudad válidos.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Clientes")
            ebCP.Text = ""
            Me.ebEstado.Focus()
        ElseIf (ebCiudad.Value <= 0) OrElse (ebEstado.Value = String.Empty) Then
            MsgBox("Seleccione un Estado/Ciudad válidos.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Clientes")
            ebCP.Text = ""
            Me.ebEstado.Focus()
        Else
            Dim oOpenRecordDialogView As New OpenRecordDialog
            oOpenRecordDialogView.CurrentView = New CatalogoCodigosPostales(ebEstado.DropDownList.GetValue("EstadoID"), ebCiudad.Value, ebColonia.Text.Trim)

            oOpenRecordDialogView.ShowDialog()

            If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then

                If oOpenRecordDialogView.pbNombre <> String.Empty Then
                    Me.ebCP.Text = oOpenRecordDialogView.pbCodigo
                    oCliente.CP = oOpenRecordDialogView.pbCodigo
                Else

                    Me.ebCP.Text = oOpenRecordDialogView.Record.Item("CP")
                    oCliente.CP = oOpenRecordDialogView.Record.Item("CP")
                End If

            End If

            oOpenRecordDialogView.Dispose()

            oOpenRecordDialogView = Nothing
        End If

    End Sub

    Private Sub ebCodVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodVendedor.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchFormPlayer()
            'ebCodVendedor.Focus()
            'ebCodVendedor.SelectAll()

        End If

        'If e.KeyCode = Keys.Enter Then

        '    SendKeys.Send("{TAB}")

        'End If
    End Sub

    Private Sub ebCodVendedor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodVendedor.Validating
        'If (ebCodVendedor.Text.Trim = String.Empty) Then

        '    ebCodVendedor.Focus()
        '    Return

        'End If

        If ebCodVendedor.Text.Trim <> "" Then 'AndAlso ebCodVendedor.Text <> oCliente.CodPlayer Then

            oVendedor.ClearFields()

            oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then
                '------------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 18.02.2016: Ya no se necesita validar si el vendedor esta asignado a alguna oficina de venta
                '------------------------------------------------------------------------------------------------------------------------------------
                'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)
                'If strRes.Trim = "0" Then
                '    GoTo NoExiste
                'ElseIf strRes.Trim = "2" Then
                '    MessageBox.Show("El Vendedor " & oVendedor.ID & " no está asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    oVendedor.ClearFields()
                '    Me.ebPlayerDescripcion.Text = ""
                '    e.Cancel = True
                'Else
                oCliente.CodPlayer = oVendedor.ID
                Me.ebCodVendedor.Text = oCliente.CodPlayer
                ebPlayerDescripcion.Text = oVendedor.Nombre
                'End If
            Else
NoExiste:
                MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)

                ebCodVendedor.Text = oCliente.CodPlayer
                oVendedor.ClearFields()
                Me.ebPlayerDescripcion.Text = ""
                e.Cancel = True

            End If

        End If

    End Sub

    '    Private Sub btnGuardarHuella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarHuella.Click 'Finger

    '        Dim NewFIR As NBioAPI.Type.HFIR
    '        'Dim FilePath As String = "C:\Pruebas\BDFinger\BDFingerPrint.ISDB"
    '        Dim FilePath As String = "\\192.168.1.14\Vtas\FingersPrint\DBFinger\"
    '        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, _
    '                                              oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)

    '        Try

    '            If Not oMontarURed.Conecta() Then

    '                MsgBox("Es necesario configurar correctamente las rutas de archivos", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                oMontarURed = Nothing
    '                GoTo Fin

    '            End If

    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX

    '            res = m_NBioAPi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If res.ToString <> "0" Then

    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin

    '            End If

    '            oFingerP = oFingerPMGr.Load(Trim(Me.ebClienteID.Text).PadLeft(10, "0"))

    '            If oFingerP.IsNew = False Then

    '                If MsgBox("El cliente " & Trim(Me.ebClienteID.Text) & " ya tiene la huella registrada" & _
    '                          vbLf & "¿Desea registrarla de nuevo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
    '                          "Dportenis PRO") = MsgBoxResult.No Then

    '                    Exit Sub

    '                End If

    '            End If

    '            m_NBioAPi.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO)

    '            res = m_NBioAPi.Enroll(NewFIR, Nothing)

    '            m_NBioAPi.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO)

    '            If res.ToString <> "0" Then

    '                'MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")

    '                'If res.ToString = "513" Then

    '                'MsgBox("Cancel")

    '                'End If

    '                GoTo Fin

    '            End If

    '            Dim fpinfo As NBioAPI.IndexSearch.FP_INFO()

    '            res = m_IndexSearch.AddFIR(NewFIR, Convert.ToUInt32(Me.ebClienteID.Text), fpinfo)

    '            If res.ToString = "0" Then

    '                'oFingerP = oFingerPMGr.Create
    '                If Directory.Exists(FilePath) = False Then

    '                    MkDir(FilePath)

    '                End If

    '                FilePath = FilePath & Trim(Me.ebClienteID.Text) & ".ISDB"

    '                If File.Exists(FilePath) = True Then

    '                    'm_IndexSearch.LoadDBFromFile(FilePath)
    '                    Kill(FilePath)

    '                End If

    '                res = m_IndexSearch.SaveDBToFile(FilePath)

    '                If res.ToString = "0" Then

    '                    oFingerP.IDCliente = Trim(Me.ebClienteID.Text).PadLeft(10, "0")
    '                    oFingerP.FingerID = CInt(fpinfo(0).FingerID.ToString)
    '                    oFingerP.SampleNum = CInt(fpinfo(0).SampleNumber.ToString)
    '                    oFingerP.Template = FilePath

    '                    oFingerPMGr.Save(oFingerP)

    '                Else

    '                    MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")

    '                End If

    '            Else

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")

    '            End If


    '        Catch ex As Exception

    '            MsgBox(ex)

    '        End Try
    'Fin:

    '        m_IndexSearch.ClearDB()
    '        oMontarURed.Desconecta()
    '        oMontarURed.Desconecta()

    '    End Sub


    '    Private Sub btnBuscarHuella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarHuella.Click 'Finger

    '        Dim capFIR As NBioAPI.Type.HFIR
    '        Dim dsRutas As New DataSet
    '        Dim i As Integer
    '        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, _
    '                                       oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)
    '        'Dim FilePath As String = "C:\Pruebas\BDFinger\BDFingerPrint.ISDB"

    '        Try

    '            If Not oMontarURed.Conecta() Then

    '                MsgBox("Es necesario configurar correctamente las rutas de archivos", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                oMontarURed = Nothing
    '                GoTo Fin

    '            End If

    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX

    '            res = m_NBioAPi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If res.ToString <> "0" Then

    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin

    '            End If

    '            dsRutas = oFingerPMGr.LoadRutas

    '            i = 0
    '            res = Convert.ToUInt32("0")

    '            For Each oRow As DataRow In dsRutas.Tables("Rutas").Rows

    '                If File.Exists(dsRutas.Tables("Rutas").Rows(i).Item(0)) = True Then

    '                    res = m_IndexSearch.LoadDBFromFile(dsRutas.Tables("Rutas").Rows(i).Item(0))

    '                End If

    '                If res.ToString <> "0" Then

    '                    MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                    GoTo Fin

    '                End If

    '                i += 1

    '            Next

    '            'If File.Exists(FilePath) = True Then

    '            'res = m_IndexSearch.LoadDBFromFile(FilePath)

    '            'If res.ToString <> "0" Then

    '            '    MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '            '    GoTo fin

    '            'End If

    '            Dim cbInfo0 As NBioAPI.IndexSearch.CALLBACK_INFO_0

    '            m_NBioAPi.OpenDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)

    '            res = m_NBioAPi.Capture(capFIR)

    '            m_NBioAPi.CloseDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)


    '            cbInfo0 = New NBioAPI.IndexSearch.CALLBACK_INFO_0

    '            Dim fpInfo As NBioAPI.IndexSearch.FP_INFO

    '            res = m_IndexSearch.IdentifyData(capFIR, Convert.ToUInt32(NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL), fpInfo, cbInfo0)

    '            If res.ToString = "0" Then

    '                Me.ebClienteID.Text = fpInfo.ID.ToString.PadLeft(10, "0")

    '                Me.ebTipoVenta.Value = oClienteMgr.GetTipoVenta(Trim(Me.ebClienteID.Text).ToUpper)
    '                Valida()
    '                ebClienteID.Focus()
    '                ebClienteID.SelectAll()

    '            Else

    '                Select Case res.ToString

    '                    Case "1286"
    '                        MsgBox("La huella no ha sido registrada", MsgBoxStyle.Exclamation, "Dportenis PRO")

    '                End Select

    '                'MsgBox(m_NBioAPi.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")

    '            End If

    '            'Else

    '            'MsgBox("No hay huellas digitales registradas", MsgBoxStyle.Exclamation, "Dportenis PRO")

    '            'End If

    '        Catch ex As Exception


    '        End Try
    'Fin:
    '        m_IndexSearch.ClearDB()
    '        oMontarURed.Desconecta()
    '        oMontarURed.Desconecta()

    '    End Sub

    '    Private Sub btnBuscarHuella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarHuella.Click 'Finger

    '        Dim capFIR As NBioAPI.Type.HFIR
    '        Dim dsRutas As New DataSet
    '        Dim Result As Boolean = False
    '        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, _
    '                                       oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)
    '        Dim txtSavedFIR As New NBioAPI.Type.FIR_TEXTENCODE
    '        Dim txtCapFIR As NBioAPI.Type.FIR_TEXTENCODE
    '        Dim bolDescarga As Boolean = False

    '        Try

    '            If Not oMontarURed.Conecta() Then

    '                MsgBox("Es necesario configurar correctamente las rutas de archivos", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin

    '            End If

    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX
    '            res = m_NBioAPi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If res.ToString <> "0" Then

    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin

    '            End If

    '            m_NBioAPi.OpenDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)

    '            res = m_NBioAPi.Capture(capFIR)

    '            m_NBioAPi.CloseDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)

    '            If res.ToString <> "0" AndAlso res.ToString <> "513" Then

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin

    '            ElseIf res.ToString = "513" Then

    '                GoTo Fin

    '            Else

    '                m_NBioAPi.OpenDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)

    '                m_NBioAPi.GetTextFIRFromHandle(capFIR, txtCapFIR, True)

    '                m_NBioAPi.CloseDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)

    '            End If

    'Reintentar:
    '            Dim cbInfo0 As New NBioAPI.IndexSearch.CALLBACK_INFO_0

    '            Dim fpInfo As NBioAPI.IndexSearch.FP_INFO

    '            res = m_IndexSearch.IdentifyData(capFIR, Convert.ToUInt32(NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL), fpInfo, cbinfo0)

    '            If res.ToString = "0" Then

    '                Me.ebClienteID.Text = fpInfo.ID.ToString.PadLeft(10, "0")

    '                Valida()
    '                ebClienteID.Focus()
    '                ebClienteID.SelectAll()

    '            ElseIf res.ToString = "1286" Then

    '                If bolDescarga = True Then
    '                    MsgBox("La huella no ha sido registrada", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                    Sm_Nuevo()
    '                Else
    '                    bolDescarga = True
    '                    Sm_DescargarHuellas()
    '                    GoTo Reintentar
    '                End If

    '            End If

    '            'dsRutas = oFingerPMGr.LoadFP

    '            'For Each oRow As DataRow In dsRutas.Tables("Rutas").Rows

    '            '    txtSavedFIR.TextFIR = oRow!Template

    '            '    m_NBioAPi.OpenDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)

    '            '    res = m_NBioAPi.VerifyMatch(txtCapFIR, txtSavedFIR, Result, Nothing)

    '            '    m_NBioAPi.CloseDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)

    '            '    If res.ToString <> "0" Then

    '            '        MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '            '        GoTo Fin

    '            '    Else

    '            '        If Result = True Then

    '            '            Me.ebClienteID.Text = oFingerPMGr.GetIDClient(oRow!ID_User).PadLeft(10, "0")

    '            '            Valida()
    '            '            ebClienteID.Focus()
    '            '            ebClienteID.SelectAll()

    '            '            GoTo Fin

    '            '        End If

    '            '    End If

    '            'Next

    '            'If Result = False Then

    '            '    MsgBox("La huella no ha sido registrada", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '            '    Sm_Nuevo()

    '            'End If

    '        Catch ex As Exception

    '            Throw New ApplicationException("Ocurrió un error al buscar al cliente mediante la huella digital", ex)

    '        End Try
    'Fin:
    '        oMontarURed.Desconecta()
    '        oMontarURed = Nothing

    '    End Sub

    '#Region "FingerPrint"

    '    Private Sub Sm_BuscarHuella() 'Finger

    '        Dim capFIR As NBioAPI.Type.HFIR
    '        Dim dsRutas As New DataSet
    '        Dim Result As Boolean = False
    '        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, _
    '                                       oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)
    '        Dim txtSavedFIR As New NBioAPI.Type.FIR_TEXTENCODE
    '        Dim txtCapFIR As NBioAPI.Type.FIR_TEXTENCODE
    '        Dim bolDescarga As Boolean = False

    '        Try

    '            If Not oMontarURed.Conecta() Then

    '                MsgBox("Es necesario configurar correctamente las rutas de archivos", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin

    '            End If

    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX
    '            res = m_NBioAPi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If res.ToString <> "0" Then

    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin

    '            End If

    '            m_NBioAPi.OpenDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)

    '            res = m_NBioAPi.Capture(capFIR)

    '            m_NBioAPi.CloseDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)

    '            If res.ToString <> "0" AndAlso res.ToString <> "513" Then

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin

    '            ElseIf res.ToString = "513" Then

    '                GoTo Fin

    '            Else

    '                m_NBioAPi.OpenDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)

    '                m_NBioAPi.GetTextFIRFromHandle(capFIR, txtCapFIR, True)

    '                m_NBioAPi.CloseDevice(m_NBioAPi.Type.DEVICE_ID.AUTO)

    '            End If

    'Reintentar:
    '            Dim cbInfo0 As New NBioAPI.IndexSearch.CALLBACK_INFO_0

    '            Dim fpInfo As NBioAPI.IndexSearch.FP_INFO

    '            res = m_IndexSearch.IdentifyData(capFIR, Convert.ToUInt32(NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL), fpInfo, cbInfo0)

    '            If res.ToString = "0" Then

    '                Me.ebClienteID.Text = fpInfo.ID.ToString.PadLeft(10, "0")

    '                Valida()
    '                ebClienteID.Focus()
    '                ebClienteID.SelectAll()

    '            ElseIf res.ToString = "1286" Then

    '                If bolDescarga = True Then
    '                    MsgBox("La huella no ha sido registrada", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                    Sm_Nuevo()
    '                Else
    '                    bolDescarga = True
    '                    Sm_DescargarHuellas()
    '                    GoTo Reintentar
    '                End If

    '            End If

    '        Catch ex As Exception

    '            Throw New ApplicationException("Ocurrió un error al buscar al cliente mediante la huella digital", ex)

    '        End Try
    'Fin:
    '        oMontarURed.Desconecta()
    '        oMontarURed = Nothing

    '    End Sub

    '    Private Sub Sm_DescargarHuellas()

    '        Dim txtSavedFIR As New NBioAPI.Type.FIR_TEXTENCODE
    '        Dim dsHuellas As New DataSet
    '        Dim Path As String = "C:\BDFingerPrint"
    '        Dim FilePath As String = Path & "\BDFP.ISDB"
    '        Dim fpinfo As NBioAPI.IndexSearch.FP_INFO()

    '        m_IndexSearch.ClearDB()

    '        If Not Directory.Exists(Path) Then
    '            MkDir(Path)
    '        End If
    '        If Not File.Exists(FilePath) Then
    '            dsHuellas = oFingerPMGr.LoadFP
    '        Else
    '            dsHuellas = oFingerPMGr.LoadTodayFP
    '            m_IndexSearch.LoadDBFromFile(FilePath)
    '        End If

    '        For Each oRow As DataRow In dsHuellas.Tables(0).Rows

    '            txtSavedFIR.TextFIR = oRow!Template

    '            m_IndexSearch.RemoveUser(Convert.ToUInt32(oFingerPMGr.GetIDClient(oRow!ID_User)))
    '            res = m_IndexSearch.AddFIR(txtSavedFIR, Convert.ToUInt32(oFingerPMGr.GetIDClient(oRow!ID_User)), fpinfo)

    '            If res.ToString <> "0" AndAlso res.ToString <> "1287" Then

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                Exit Sub

    '            End If

    '        Next

    '        If File.Exists(FilePath) Then

    '            Kill(FilePath)

    '        End If

    '        m_IndexSearch.SaveDBToFile(FilePath)

    '    End Sub

    '#End Region

    '    Private Sub btnGuardarHuella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarHuella.Click 'Finger

    '        Dim NewFIR As NBioAPI.Type.HFIR
    '        Dim txtFIR As NBioAPI.Type.FIR_TEXTENCODE
    '        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, _
    '                                              oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)
    '        Dim FilePath As String = "C:\BDFingerPrint\BDFP.ISDB"

    '        Try

    '            If Not oMontarURed.Conecta() Then

    '                MsgBox("Es necesario configurar correctamente las rutas de archivos", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin

    '            End If

    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX

    '            res = m_NBioAPi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If res.ToString <> "0" Then

    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin

    '            End If

    '            oFingerP = oFingerPMGr.Load(Trim(Me.ebClienteID.Text).PadLeft(10, "0"))

    '            If oFingerP.IsNew = False Then

    '                If MsgBox("El cliente " & Trim(Me.ebClienteID.Text) & " ya tiene la huella registrada" & _
    '                          vbLf & "¿Desea registrarla de nuevo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
    '                          "Dportenis PRO") = MsgBoxResult.No Then

    '                    GoTo fin

    '                End If

    '            End If

    '            m_NBioAPi.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO)

    '            res = m_NBioAPi.Enroll(NewFIR, Nothing)

    '            m_NBioAPi.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO)

    '            If res.ToString <> "0" AndAlso res.ToString <> "513" Then

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin

    '            ElseIf res.ToString = "513" Then

    '                GoTo Fin

    '            Else

    '                Dim fpInfo() As NBioAPI.IndexSearch.FP_INFO
    '                m_NBioAPi.GetTextFIRFromHandle(NewFIR, txtFIR, True)

    '                If Not oFingerP.IsNew Then
    '                    m_IndexSearch.RemoveUser(Convert.ToUInt32(Me.ebClienteID.Text))
    '                End If

    '                m_IndexSearch.AddFIR(txtFIR, Convert.ToUInt32(Me.ebClienteID.Text), fpInfo)
    '                If File.Exists(FilePath) Then
    '                    Kill(FilePath)
    '                End If
    '                m_IndexSearch.SaveDBToFile(FilePath)

    '                oFingerP.IDCliente = Trim(Me.ebClienteID.Text).PadLeft(10, "0")
    '                oFingerP.FingerID = fpInfo(0).FingerID
    '                oFingerP.SampleNum = fpInfo(0).SampleNumber
    '                oFingerP.Template = txtFIR.TextFIR

    '                oFingerPMGr.Save(oFingerP)

    '            End If

    '        Catch ex As Exception

    '            Throw New ApplicationException("No se pudo guardar la huella digital.", ex)

    '        End Try
    'Fin:
    '        oMontarURed.Desconecta()
    '        oMontarURed = Nothing

    '    End Sub

    '    Private Sub Sm_GuardarHuella() 'Finger

    '        Dim NewFIR As NBioAPI.Type.HFIR
    '        Dim txtFIR As NBioAPI.Type.FIR_TEXTENCODE
    '        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, _
    '                                              oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)
    '        Dim FilePath As String = "C:\BDFingerPrint\BDFP.ISDB"

    '        Try

    '            If Not oMontarURed.Conecta() Then

    '                MsgBox("Es necesario configurar correctamente las rutas de archivos", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin

    '            End If

    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX

    '            res = m_NBioAPi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If res.ToString <> "0" Then

    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin

    '            End If

    '            oFingerP = oFingerPMGr.Load(Trim(Me.ebClienteID.Text).PadLeft(10, "0"))

    '            If oFingerP.IsNew = False Then

    '                If MsgBox("El cliente " & Trim(Me.ebClienteID.Text) & " ya tiene la huella registrada" & _
    '                          vbLf & "¿Desea registrarla de nuevo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
    '                          "Dportenis PRO") = MsgBoxResult.No Then

    '                    GoTo fin

    '                End If

    '            End If
    'GuardarHuella:
    '            m_NBioAPi.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO)

    '            res = m_NBioAPi.Enroll(NewFIR, Nothing)

    '            m_NBioAPi.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO)

    '            If res.ToString <> "0" AndAlso res.ToString <> "513" Then

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin

    '            ElseIf res.ToString = "513" Then

    '                MsgBox("Es necesario guardar la huella digital", MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                GoTo GuardarHuella
    '                'GoTo Fin

    '            Else

    '                Dim fpInfo() As NBioAPI.IndexSearch.FP_INFO
    '                m_NBioAPi.GetTextFIRFromHandle(NewFIR, txtFIR, True)

    '                If Not oFingerP.IsNew Then
    '                    m_IndexSearch.RemoveUser(Convert.ToUInt32(Me.ebClienteID.Text))
    '                End If

    '                m_IndexSearch.AddFIR(txtFIR, Convert.ToUInt32(Me.ebClienteID.Text), fpInfo)
    '                If File.Exists(FilePath) Then
    '                    Kill(FilePath)
    '                End If
    '                m_IndexSearch.SaveDBToFile(FilePath)

    '                oFingerP.IDCliente = Trim(Me.ebClienteID.Text).PadLeft(10, "0")
    '                oFingerP.FingerID = fpInfo(0).FingerID
    '                oFingerP.SampleNum = fpInfo(0).SampleNumber
    '                oFingerP.Template = txtFIR.TextFIR

    '                oFingerPMGr.Save(oFingerP)

    '            End If

    '        Catch ex As Exception

    '            Throw New ApplicationException("No se pudo guardar la huella digital.", ex)

    '        End Try
    'Fin:
    '        oMontarURed.Desconecta()
    '        oMontarURed = Nothing

    '    End Sub

    Private Sub ebClienteID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebClienteID.Validating
        Valida()
    End Sub

    Private Sub ebEmail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebEmail.Validating
        If Me.ebEmail.Text.Trim <> "" Then
            If ValidaEmail(Me.ebEmail.Text.Trim) = False Then
                MessageBox.Show("El Correo es invalido, favor de verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'e.Cancel = True
            End If
        End If
    End Sub

    Private Sub ebCP_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCP.ButtonClick
        '----------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (22.07.2016): Validamos si esta activo el S2credi y es DPVAle, mostrar pantalla de Codigos Postales de S2Credit
        '----------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.AplicarS2Credit AndAlso EsDPVale Then
            BuscarCodigoPostalS2Credit(Me.ebCP.Text)
        Else
            LoadSearchFormCPs()
        End If
    End Sub

    Private Sub ebCP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCP.KeyDown
        If e.Alt AndAlso e.KeyCode = Keys.S Then
            '----------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (22.07.2016): Validamos si esta activo el S2credi y es DPVAle, mostrar pantalla de Codigos Postales de S2Credit
            '----------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.AplicarS2Credit AndAlso EsDPVale Then
                BuscarCodigoPostalS2Credit(Me.ebCP.Text)
            Else
                LoadSearchFormCPs()
            End If
        End If
    End Sub

    Private Sub chkEmpresa_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEmpresa.CheckedChanged
        If Not oCliente Is Nothing Then
            If chkEmpresa.Checked Then
                oCliente.ApellidoMaterno = ""
                '--------------------------------------------------------------------------
                ' JNAVA (10.02.2017): habilitamos los apellidos y quitamos el texto
                '--------------------------------------------------------------------------
                'oCliente.ApellidoPaterno = ""
                Me.Label2.Text = ""
                Me.Label12.Text = ""
                Me.ebApellidoMaterno.Enabled = False
                'Me.ebApellidoPaterno.Enabled = False
                '--------------------------------------------------------------------------
                oCliente.Sexo = "E"
                oCliente.EstadoCivil = ""
                Me.ebSexo.Enabled = False
                Me.ebEstadoCivil.Enabled = False
                'oCliente.Nombre = IIf(oCliente.Nombre.Trim <> "", oCliente.Nombre.Trim.Substring(1, 35), "")
                Me.ebNombre.MaxLength = 0
                oCliente.EsEmpresa = True
            Else
                '--------------------------------------------------------------------------
                ' JNAVA (10.02.2017): habilitamos los apellidos y quitamos el texto
                '--------------------------------------------------------------------------
                Me.Label12.Text = "Apellido Paterno:"
                Me.Label2.Text = "Apellido Materno:"
                '--------------------------------------------------------------------------
                Me.ebApellidoMaterno.Enabled = True
                Me.ebApellidoPaterno.Enabled = True
                oCliente.Sexo = ""
                Me.ebSexo.Enabled = True
                Me.ebEstadoCivil.Enabled = True
                oCliente.EsEmpresa = False
                'Me.ebNombre.MaxLength = 0
            End If
            Me.ebNombre.Focus()
        End If
    End Sub

    Private Sub ebApellidoMaterno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebApellidoMaterno.KeyDown, ebApellidoPaterno.KeyDown, ebNombre.KeyDown, cmbFechaNac.KeyDown
        ' oCliente.GenerateRFC = True
    End Sub

    Private Sub ebCP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ebCP.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'Private Sub ebEstado_ValueChanged(sender As Object, e As System.EventArgs) Handles ebEstado.ValueChanged
    '    '----------------------------------------------------------------------------------------------------
    '    ' JNAVA (22.07.2016): Si es S2Credit se carga la ciudad en base al Estado seleccionado
    '    '----------------------------------------------------------------------------------------------------
    '    If oConfigCierreFI.AplicarS2Credit AndAlso EsDPVale Then
    '        FilldtComboCiudades(ebEstado.Value)
    '    End If
    'End Sub

    Private Sub ebColonia_Click(sender As System.Object, e As System.EventArgs) Handles ebColonia.Click
        BuscarCodigoPostalS2Credit(Me.ebCP.Text)
    End Sub

#Region "S2Credit"

    '----------------------------------------------------------------------------------------------------
    ' JNAVA (21.07.2016): Funcion para deshabilitar campos que en S2Credit son Autorrellenables
    '----------------------------------------------------------------------------------------------------
    Private Sub DeshabilitarCamposS2Credit()

        If oConfigCierreFI.AplicarS2Credit AndAlso Me.EsDPVale Then

            Me.ebColonia.ReadOnly = True
            Me.ebEstado.Enabled = False
            Me.ebCiudad.Enabled = False

            '-------------------------------------------------------------------------------------------------------------------
            ' JNAVA (10.01.2017): Cambiamos el texto de ciudad a Municipio pues la ciudad se muestra en los codigos postales
            '-------------------------------------------------------------------------------------------------------------------
            Me.Label18.Text = "Municipio:"
            '-------------------------------------------------------------------------------------------------------------------

        End If

    End Sub

    '----------------------------------------------------------------------------------------------------
    ' JNAVA (21.07.2016): Funcion para consultar y seleccionar el Codigo postal (Sepomex)
    '----------------------------------------------------------------------------------------------------
    Private Sub BuscarCodigoPostalS2Credit(ByVal CodigoPostal As String)

        '----------------------------------------------------------------------------------------------------
        ' Validamos si esta activa la configuracion y si es cliente de DPVale
        '----------------------------------------------------------------------------------------------------
        If oConfigCierreFI.AplicarS2Credit AndAlso Me.EsDPVale Then

            '----------------------------------------------------------------------------------------------------
            ' Mostramos Panel para seleccionar el codigo postal de sepomex
            '----------------------------------------------------------------------------------------------------
            Dim frmCP As New frmCodigosPostalesS2Credit(Me.ebCP.Text)
            frmCP.ShowDialog()

            '----------------------------------------------------------------------------------------------------
            ' Obtenemos datos de sepomex seleccionados
            '----------------------------------------------------------------------------------------------------
            Dim oDatosSepomex As New Dictionary(Of String, Object)
            oDatosSepomex = frmCP.oDatosSepomex

            If Not oDatosSepomex Is Nothing Then

                '----------------------------------------------------------------------------------------------------
                ' JNAVA (25.07.2016): Obtenemos y seteamos la informacion para validar
                '----------------------------------------------------------------------------------------------------
                oCliente.Estado = BuscaEstado(oDatosSepomex("Estado").ToString)
                oCliente.Ciudad = oDatosSepomex("Ciudad").ToString
                oCliente.CP = oDatosSepomex("CodigoPostal").ToString
                oCliente.Colonia = oDatosSepomex("Colonia").ToString

                '----------------------------------------------------------------------------------------------------
                ' JNAVA (25.07.2016): Validamos la informacion obtenida y la mostramos
                '----------------------------------------------------------------------------------------------------
                Me.ebEstado.Text = oCliente.Estado
                Dim oRow As DataRow
                For Each oRow In dtEstados.Rows
                    If CStr(Me.ebEstado.Value).Trim = CStr(oRow!CodEstado).Trim Then
                        Me.ebEstado.DropDownList.SetValue("EstadoID", oRow!EstadoID)
                    End If
                Next
                Dim strCiudadTemp As String = oCliente.Ciudad
                Dim strCPTemp As String = oCliente.CP
                Me.ebEstado_Validating(Nothing, Nothing)
                oCliente.Ciudad = strCiudadTemp
                oCliente.CP = strCPTemp
                Me.ebCiudad.Text = oCliente.Ciudad
                Me.ebCP.Text = oCliente.CP
                '----------------------------------------------------------------------------------------------------------------------------------------------------
                'rgermain 15.10.2016: No validamos la ciudad ni el codigo postal cuando es un cliente de DPvale porque S2Credit ya lo hace
                '----------------------------------------------------------------------------------------------------------------------------------------------------
                'Me.ebCiudad_Validating(Nothing, Nothing)
                rango1 = 1
                rango2 = 99999
                '----------------------------------------------------------------------------------------------------------------------------------------------------
                ' Colonia
                Me.ebColonia.Text = oCliente.Colonia


            End If

            frmCP.Dispose()

        End If

    End Sub

    ''-----------------------------------------------------
    '' JNAVA (11.04.2016):  Valida/Busca cliente en S2Credit
    ''-----------------------------------------------------
    'Private Sub BuscaClienteS2Credit(ByVal NombreCliente As String)
    '    Dim oS2Credit As New ProcesosS2Credit
    '    If oConfigCierreFI.AplicarS2Credit Then
    '        Try
    '            Me.oClienteResS2C = Nothing
    '            Me.oClienteResS2C = oS2Credit.SearchCustomers(NombreCliente)
    '        Catch ex As Exception
    '            'Throw ex
    '        End Try
    '    End If
    'End Sub

#End Region

#Region "DPVale AFS"

    Private Sub LoadSearchFormDPVale()

        Dim oOpenRecordDlg As OpenFROMSAPRecordDialogClientesDPVale
        oOpenRecordDlg = New OpenFROMSAPRecordDialogClientesDPVale
        oOpenRecordDlg.TipoVenta = "V"
        oOpenRecordDlg.CurrentView = New ClientesFromSAPOpenRecordDialogViewDPVale

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Try

                oCliente.Clear()
                If oOpenRecordDlg.pbCodigo = String.Empty Then
                    Me.ebClienteID.Text = oOpenRecordDlg.Record.Item("KUNNR")
                Else
                    Me.ebClienteID.Text = CType(oOpenRecordDlg.pbCodigo, String)
                End If
                Me.ebNombre.Focus()

            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

#End Region

#Region "DPCard Puntos"

    '--------------------------------------------------------------------------------------'
    'Inicio JEMO (20/10/2016)'
    '--------------------------------------------------------------------------------------'
    ''' <summary>
    ''' ' Metodo para guardar datos de cliente en dpcard
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClienteDPCardApprova()
        Dim url As String = ""
        'url = url + "http://172.16.61.68/Approva2/Login.aspx?"
        url = url + oConfigCierreFI.UrlRegistroDPCard
        url = url + "AP=" + ebApellidoPaterno.Text
        url = url + "&AM=" + ebApellidoMaterno.Text
        url = url + "&NOMBRE=" + ebNombre.Text
        url = url + "&NAC=" + cmbFechaNac.Text
        url = url + "&CALLE=" + ebDomicilio.Text
        url = url + "&NUM=" + ebNumExt.Text
        url = url + "&EXT=" + ebNumInt.Text
        url = url + "&COL=" + ebColonia.Text
        url = url + "&CP=" + ebCP.Text
        url = url + "&CEL=" + ebTelefono.UnmaskedText
        url = url + "&CITY=" + ebCiudad.Text
        url = url + "&MUN=" + ebCiudad.Text
        url = url + "&EMAIL=" + ebEmail.Text
        url = url + "&ESTADO=" + ebEstado.Text

        Try
            Dim urlo As Uri = New Uri(url)
            System.Diagnostics.Process.Start(urlo.ToString())
        Catch ex As Exception

        End Try

    End Sub
    'Fin JEMO (20/10/2016) --------------------------------------------------------------------

#End Region

End Class
