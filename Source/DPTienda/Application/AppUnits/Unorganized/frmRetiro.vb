Imports DportenisPro.DPTienda.ApplicationUnits.Retiros
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU
Imports System.Data.SqlClient
Imports System.Data
Imports DportenisPro.DPTienda.Core.ApplicationContext
Imports DportenisPro.DPTienda.ApplicationUnits.CierreCaja
Imports DportenisPro.DPTienda.ApplicationUnits.InicioCaja
Imports DportenisPro.DPTienda.ApplicationUnits.InicioDia
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports Janus.Windows.UI
Imports DportenisPro.DPTienda.ApplicationUnits.ArqueoDeCajaAU

Public Class frmRetiro

    Inherits System.Windows.Forms.Form

#Region "  Variables Miembros"

    Private oRetirosMgr As RetirosManager

    Private oRetiros As Retiros

    Private Retiros As String = String.Empty

    Dim dtBancos As DataTable

    Dim oCierreCajaMgr As CierreCajaManager

    Dim oInicioDiaMgr As InicioDiaManager

    Dim oInicioCajaMgr As InicioCajaManager
    'Friend WithEvents EstadodeCuentaAsociado1 As DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.wsEstadoCuentaAsociado.EstadodeCuentaAsociado

    Dim oFacturaMgr As FacturaManager

#End Region


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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtCantidadRetiro As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtFicha As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtRetiroID As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDepositos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCancelar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCancelar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuEliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCancelar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuEliminar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents ebCodBanco As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRetiro))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebCodBanco = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtRetiroID = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtFicha = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cmbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReferencia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.txtDepositos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.txtCantidadRetiro = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuCancelar2 = New Janus.Windows.UI.CommandBars.UICommand("menuCancelar")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuEliminar2 = New Janus.Windows.UI.CommandBars.UICommand("menuEliminar")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuCancelar1 = New Janus.Windows.UI.CommandBars.UICommand("menuCancelar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuEliminar1 = New Janus.Windows.UI.CommandBars.UICommand("menuEliminar")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.menuCancelar = New Janus.Windows.UI.CommandBars.UICommand("menuCancelar")
        Me.menuEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuEliminar")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        'Me.EstadodeCuentaAsociado1 = New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.wsEstadoCuentaAsociado.EstadodeCuentaAsociado()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
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
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ebCodBanco)
        Me.ExplorerBar1.Controls.Add(Me.txtRetiroID)
        Me.ExplorerBar1.Controls.Add(Me.txtFicha)
        Me.ExplorerBar1.Controls.Add(Me.cmbFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.txtReferencia)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 120)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(648, 376)
        Me.ExplorerBar1.TabIndex = 2
        Me.ExplorerBar1.Text = "0"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebCodBanco
        '
        Me.ebCodBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodBanco.Location = New System.Drawing.Point(448, 56)
        Me.ebCodBanco.MaxLength = 40
        Me.ebCodBanco.Name = "ebCodBanco"
        Me.ebCodBanco.ReadOnly = True
        Me.ebCodBanco.Size = New System.Drawing.Size(184, 22)
        Me.ebCodBanco.TabIndex = 3
        Me.ebCodBanco.TabStop = False
        Me.ebCodBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtRetiroID
        '
        Me.txtRetiroID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtRetiroID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtRetiroID.ButtonImage = CType(resources.GetObject("txtRetiroID.ButtonImage"), System.Drawing.Image)
        Me.txtRetiroID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtRetiroID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetiroID.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtRetiroID.Location = New System.Drawing.Point(120, 48)
        Me.txtRetiroID.MaxLength = 4
        Me.txtRetiroID.Name = "txtRetiroID"
        Me.txtRetiroID.Size = New System.Drawing.Size(120, 22)
        Me.txtRetiroID.TabIndex = 0
        Me.txtRetiroID.Text = "0"
        Me.txtRetiroID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtRetiroID.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtRetiroID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtFicha
        '
        Me.txtFicha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtFicha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtFicha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFicha.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtFicha.Location = New System.Drawing.Point(120, 111)
        Me.txtFicha.MaxLength = 10
        Me.txtFicha.Name = "txtFicha"
        Me.txtFicha.Size = New System.Drawing.Size(120, 22)
        Me.txtFicha.TabIndex = 2
        Me.txtFicha.Text = "0"
        Me.txtFicha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtFicha.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtFicha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbFecha
        '
        '
        '
        '
        Me.cmbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFecha.Location = New System.Drawing.Point(120, 80)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.Size = New System.Drawing.Size(120, 22)
        Me.cmbFecha.TabIndex = 1
        Me.cmbFecha.TabStop = False
        Me.cmbFecha.Value = New Date(2005, 5, 26, 0, 0, 0, 0)
        Me.cmbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(16, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'txtReferencia
        '
        Me.txtReferencia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtReferencia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtReferencia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencia.Location = New System.Drawing.Point(448, 88)
        Me.txtReferencia.MaxLength = 40
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(184, 22)
        Me.txtReferencia.TabIndex = 4
        Me.txtReferencia.TabStop = False
        Me.txtReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(304, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 23)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Referencia Efectivo:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(304, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 23)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Codigo de Banco:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(16, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Numero Ficha:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(16, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Folio:"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.txtDepositos)
        Me.ExplorerBar2.Controls.Add(Me.Label4)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Retiros Realizados"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 48)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(648, 424)
        Me.ExplorerBar2.TabIndex = 1
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'txtDepositos
        '
        Me.txtDepositos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtDepositos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtDepositos.BackColor = System.Drawing.Color.Ivory
        Me.txtDepositos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepositos.ForeColor = System.Drawing.Color.Red
        Me.txtDepositos.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtDepositos.Location = New System.Drawing.Point(464, 40)
        Me.txtDepositos.Name = "txtDepositos"
        Me.txtDepositos.ReadOnly = True
        Me.txtDepositos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDepositos.Size = New System.Drawing.Size(168, 22)
        Me.txtDepositos.TabIndex = 0
        Me.txtDepositos.TabStop = False
        Me.txtDepositos.Text = "$0.00"
        Me.txtDepositos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtDepositos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(328, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 23)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total de Depositos:"
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.txtCantidadRetiro)
        Me.ExplorerBar3.Controls.Add(Me.Label22)
        Me.ExplorerBar3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Detalle del Retiro"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar3.Location = New System.Drawing.Point(0, 264)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(648, 200)
        Me.ExplorerBar3.TabIndex = 3
        Me.ExplorerBar3.Text = "ExplorerBar3"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'txtCantidadRetiro
        '
        Me.txtCantidadRetiro.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCantidadRetiro.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCantidadRetiro.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadRetiro.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtCantidadRetiro.Location = New System.Drawing.Point(136, 48)
        Me.txtCantidadRetiro.MaxLength = 12
        Me.txtCantidadRetiro.Name = "txtCantidadRetiro"
        Me.txtCantidadRetiro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCantidadRetiro.Size = New System.Drawing.Size(112, 22)
        Me.txtCantidadRetiro.TabIndex = 1
        Me.txtCantidadRetiro.Text = "$0.00"
        Me.txtCantidadRetiro.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCantidadRetiro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(16, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(128, 23)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Monto del Retiro:"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuNuevo, Me.menuAbrir, Me.menuGuardar, Me.menuCancelar, Me.menuEliminar, Me.menuSalir})
        Me.UiCommandManager1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("b755fd08-bd09-4874-96e2-e551cc70f991")
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(648, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo2, Me.Separator6, Me.menuAbrir2, Me.Separator7, Me.menuGuardar2, Me.Separator8, Me.menuCancelar2, Me.Separator9, Me.menuEliminar2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(365, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuNuevo2
        '
        Me.menuNuevo2.Key = "menuNuevo"
        Me.menuNuevo2.Name = "menuNuevo2"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuAbrir2
        '
        Me.menuAbrir2.Key = "menuAbrir"
        Me.menuAbrir2.Name = "menuAbrir2"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'menuGuardar2
        '
        Me.menuGuardar2.Key = "menuGuardar"
        Me.menuGuardar2.Name = "menuGuardar2"
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'menuCancelar2
        '
        Me.menuCancelar2.Key = "menuCancelar"
        Me.menuCancelar2.Name = "menuCancelar2"
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'menuEliminar2
        '
        Me.menuEliminar2.Key = "menuEliminar"
        Me.menuEliminar2.Name = "menuEliminar2"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo1, Me.Separator1, Me.menuAbrir1, Me.Separator2, Me.menuGuardar1, Me.Separator3, Me.menuCancelar1, Me.Separator4, Me.menuEliminar1, Me.Separator5, Me.menuSalir1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
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
        'menuAbrir1
        '
        Me.menuAbrir1.Key = "menuAbrir"
        Me.menuAbrir1.Name = "menuAbrir1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuGuardar1
        '
        Me.menuGuardar1.Key = "menuGuardar"
        Me.menuGuardar1.Name = "menuGuardar1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuCancelar1
        '
        Me.menuCancelar1.Key = "menuCancelar"
        Me.menuCancelar1.Name = "menuCancelar1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuEliminar1
        '
        Me.menuEliminar1.Key = "menuEliminar"
        Me.menuEliminar1.Name = "menuEliminar1"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'menuNuevo
        '
        Me.menuNuevo.Image = CType(resources.GetObject("menuNuevo.Image"), System.Drawing.Image)
        Me.menuNuevo.Key = "menuNuevo"
        Me.menuNuevo.Name = "menuNuevo"
        Me.menuNuevo.Text = "&Nuevo"
        '
        'menuAbrir
        '
        Me.menuAbrir.Image = CType(resources.GetObject("menuAbrir.Image"), System.Drawing.Image)
        Me.menuAbrir.Key = "menuAbrir"
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Text = "A&brir"
        '
        'menuGuardar
        '
        Me.menuGuardar.Image = CType(resources.GetObject("menuGuardar.Image"), System.Drawing.Image)
        Me.menuGuardar.Key = "menuGuardar"
        Me.menuGuardar.Name = "menuGuardar"
        Me.menuGuardar.Text = "&Guardar"
        '
        'menuCancelar
        '
        Me.menuCancelar.Image = CType(resources.GetObject("menuCancelar.Image"), System.Drawing.Image)
        Me.menuCancelar.Key = "menuCancelar"
        Me.menuCancelar.Name = "menuCancelar"
        Me.menuCancelar.Text = "&Cancelar"
        '
        'menuEliminar
        '
        Me.menuEliminar.Image = CType(resources.GetObject("menuEliminar.Image"), System.Drawing.Image)
        Me.menuEliminar.Key = "menuEliminar"
        Me.menuEliminar.Name = "menuEliminar"
        Me.menuEliminar.Text = "&Eliminar"
        '
        'menuSalir
        '
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "&Salir"
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
        Me.TopRebar1.Size = New System.Drawing.Size(648, 50)
        '
        'EstadodeCuentaAsociado1
        '
        'Me.EstadodeCuentaAsociado1.Credentials = Nothing
        'Me.EstadodeCuentaAsociado1.Url = "http://dpssvr/Credito/EstadodeCuentaAsociado.asmx"
        'Me.EstadodeCuentaAsociado1.UseDefaultCredentials = False
        '
        'frmRetiro
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(648, 341)
        Me.Controls.Add(Me.ExplorerBar3)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRetiro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modulos de Retiros"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
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


#Region "Inicializar"

    Private Sub InitializeObjects()

        oRetirosMgr = New RetirosManager(oAppContext)

        oRetiros = oRetirosMgr.Create

        ComboFillBanco()

        oCierreCajaMgr = New CierreCajaManager(oAppContext)

        oInicioDiaMgr = New InicioDiaManager(oAppContext)

        oInicioCajaMgr = New InicioCajaManager(oAppContext)

        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)

    End Sub

    Private Sub InitializeBinding()

        Try

            oRetiros.CodBanco = oAppContext.ApplicationConfiguration.ReferenciaEfectivo
            Me.ebCodBanco.DataBindings.Add("Text", oRetiros, "CodBanco")

        Catch ex As Exception

            '  MsgBox(ex.ToString)

        End Try


    End Sub


#End Region


#Region "  Metodos Miembros"



    Public Sub Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (txtRetiroID.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New RetirosOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oRetiros = Nothing
                oRetiros = oRetirosMgr.Load(oOpenRecordDlg.Record.Item("RetiroID"))

                txtRetiroID.Text = oRetiros.RetiroID
                cmbFecha.Text = oRetiros.RecordCreatedOn
                Me.ebCodBanco.Text = oRetiros.CodBanco
                txtReferencia.Text = oRetiros.Referencia
                txtFicha.Text = oRetiros.Ficha
                txtCantidadRetiro.Text = oRetiros.CantidadRetiro
                If oRetiros.RecordCreatedOn.Date <> DateTime.Now.Date Then
                    txtCantidadRetiro.Enabled = False
                End If
                '  btnGrabar.Enabled = True


            End If

        Else


            cmbFecha.Text = String.Empty
            ebCodBanco.Text = String.Empty
            txtReferencia.Text = String.Empty
            txtFicha.Text = String.Empty
            txtCantidadRetiro.Text = String.Empty


            On Error Resume Next

            oRetiros = Nothing

            oRetiros = oRetirosMgr.Load(txtRetiroID.Text.Trim)

            If Not (oRetiros Is Nothing) Then

                txtRetiroID.Text = oRetiros.RetiroID
                cmbFecha.Text = oRetiros.RecordCreatedOn
                Me.ebCodBanco.Text = oRetiros.CodBanco
                txtReferencia.Text = oRetiros.Referencia
                txtFicha.Text = oRetiros.Ficha
                txtCantidadRetiro.Text = oRetiros.CantidadRetiro


            Else

                oRetirosMgr.Create()
                cmbFecha.Text = String.Empty
                Me.ebCodBanco.Text = String.Empty
                txtReferencia.Text = String.Empty
                txtFicha.Text = String.Empty
                txtCantidadRetiro.Text = String.Empty


                oRetiros.RetiroID = txtRetiroID.Text

                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            txtRetiroID.Focus()

        End If

    End Sub

    Public Sub ComboFillBanco()

        'Dim oBancosMgr As New CatalogoBancosManager(oAppContext)

        'Dim dsBancos As DataSet = oBancosMgr.GetAll(True)

        ''cmbCodBanco.DataSource = dsBancos.Tables("CatalogoBancos")
        ''cmbCodBanco.ValueMember = "CodBanco"
        'cmbCodBanco.DisplayMember = "Descripcion"

    End Sub

    Public Function ValidarMonto() As Boolean
        Dim bResp As Boolean = True
        Dim oArqueoCaja As ArqueoDeCajaManager
        Dim oCierreCajasMgr As CierreCajaManager
        Dim retiros As Decimal = 0
        Dim efectivo As Decimal = 0

        oCierreCajasMgr = New CierreCajaManager(oAppContext)
        oArqueoCaja = New ArqueoDeCajaManager(oAppContext)
        retiros = oCierreCajasMgr.CalcularTotalRetiros(Now.Date)


        If Not oRetiros Is Nothing Then
            retiros = retiros - oRetiros.CantidadRetiro
        End If

        efectivo = oArqueoCaja.IngresosDia(Now.Date, oAppContext.ApplicationConfiguration.NoCaja, _
                oAppContext.ApplicationConfiguration.Almacen)

        If CDec(txtCantidadRetiro.Text) > (efectivo - retiros) Then
            bResp = False
        End If

        Return bResp
    End Function

    Public Sub Guardar()

        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' MLVARGAS 08/06/2022: Se valida que no se retire más dinero del que ingresó a la caja  - Se comenta por las notas manuales y ventas sin sistema
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'If ValidarMonto() = False Then
        '    MessageBox.Show("El monto a retirar supera la cantidad de efectivo existente en la caja, verifique sus datos", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If

        If (oRetiros.IsNew = True) Then   'Opción Guardar.
            If (MessageBox.Show("Se encuentra seguro de Guardar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                Exit Sub
            End If


            If (Fm_bolTxtValidar("Guardar") = False) Then
                Exit Sub
            End If
            oRetiros.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen

            oRetiros.CodCaja = oAppContext.ApplicationConfiguration.NoCaja

            oRetiros.RecordCreatedOn = New DateTime(Me.cmbFecha.Value.Year, Me.cmbFecha.Value.Month, Me.cmbFecha.Value.Day, Now.Hour, Now.Minute, Now.Second) 'Date.Now
            oRetiros.RecordEnabled = True
            oRetiros.RecordCreatedBy = oAppContext.Security.CurrentUser.Name
            oRetiros.Ficha = txtFicha.Text
            oRetiros.Referencia = txtReferencia.Text
            oRetiros.CantidadRetiro = CDec(txtCantidadRetiro.Text)
            oRetiros.CodBanco = Me.ebCodBanco.Text

            oRetiros.Save()

            txtRetiroID.Text = oRetiros.RetiroID

            MessageBox.Show("La información ha sido Guardada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MontoTotal()
            If oRetiros.RecordCreatedOn.Date <> DateTime.Now.Date Then
                cmbFecha.Enabled = False
            End If
            Me.UiCommandManager1.Commands.Item("MenuGuardar").Enabled = InheritableBoolean.True


        Else   'Opción Actualizar.


            If DateDiff(DateInterval.Day, Me.cmbFecha.Value, Now.Date) > 0 Then

                MessageBox.Show("No puede modificar retiros de fechas anteriores", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If

            If (MessageBox.Show("Se encuentra seguro de Actualizar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then

                Exit Sub

            End If


            '    'If (Fm_bolTxtValidar() = False) Then
            '    '    Exit Sub
            '    'End If

            Dim Vl_strCodRetiro As String

            Vl_strCodRetiro = oRetiros.RetiroID

            oRetiros.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen

            oRetiros.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
            oRetiros.RecordCreatedOn = Date.Now
            oRetiros.RecordEnabled = True
            oRetiros.RecordCreatedBy = oAppContext.Security.CurrentUser.Name
            oRetiros.Ficha = txtFicha.Text
            oRetiros.Referencia = txtReferencia.Text
            oRetiros.CantidadRetiro = CDec(txtCantidadRetiro.Text)
            oRetiros.CodBanco = Me.ebCodBanco.Text

            oRetiros.Save()

            MessageBox.Show("La información ha sido Actualizada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MontoTotal()

        End If

        Dim FrmNumRef As New FrmNumReferencia(oAppContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), Date.Now)
        FrmNumRef.ShowDialog()
        '---------------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 26/09/2014: Se realiza la impresión de las fichas de depósito.
        '---------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 14.09.2015: Se comento por solicitud de Wilfrido en especificacion funcional
        '---------------------------------------------------------------------------------------------------------------------------------------
        'If oConfigCierreFI.RecibirOtrosPagos = True Then
        '    Dim numref As New NumeroReferencia.cNumReferencia
        '    Dim numref10 As New AlgoritmosBBVA

        '    Dim RefTienda As String = FrmNumRef.LblNumRef.Text.Trim()
        '    Dim tienda As String = "01" & oAppContext.ApplicationConfiguration.Almacen.PadLeft(4, "0")
        '    Dim refEcommerce As String = "" 'numref.getNumReferencia(tienda, Format(Date.Now, "ddMMyyyy"))
        '    'refEcommerce = refEcommerce.Remove(10, 2)
        '    Dim oCierreCajasMgr As New CierreCajaManager(oAppContext)
        '    Dim PagoEcommerce As Decimal = oCierreCajasMgr.GetTotalPagosEcommerce(oAppContext.ApplicationConfiguration.Almacen, Date.Now, Date.Now)
        '    '------------------------------------------------------------------------------------------------------------------------------------
        '    'RGERMAIN 01.10.2014: Modificamos el algoritmo con el que se genera la referencia de Ecommerce, ahora utiliza el algoritmo 10 BBVA
        '    '------------------------------------------------------------------------------------------------------------------------------------
        '    refEcommerce = numref10.GetReferenciaAlg10(tienda, Today.AddDays(3), Decimal.Round(PagoEcommerce, 2))

        '    Dim deposito As New rptDeposito(RefTienda, CDec(Me.txtCantidadRetiro.Value), refEcommerce, PagoEcommerce)
        '    deposito.Document.Name = "Impresion de Fichas de Depósito"
        '    deposito.Run()
        '    deposito.Document.Print(False, False)
        'End If
    End Sub

    Public Sub MontoTotal()

        Dim oCierreCajaMgr As New CierreCajaManager(oAppContext)
        Me.txtDepositos.Value = oCierreCajaMgr.CalcularTotalRetiros(cmbFecha.Value.ToShortDateString)

    End Sub

    Private Function Fm_bolTxtValidar(Optional ByVal Vpa_strOpcion As String = "") As Boolean

        If (Vpa_strOpcion = "Guardar") Then

            txtRetiroID.Text = txtRetiroID.Text.Trim

            If (txtRetiroID.Text = String.Empty) Then

                MessageBox.Show("Debe especificar un número de Retiro ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                txtRetiroID.Focus()

                Exit Function

            End If

        End If

        If Me.ebCodBanco.Text = "" Then

            MessageBox.Show("Debe escojer un Banco", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            txtReferencia.Focus()

            Exit Function

        End If
        txtReferencia.Text = txtReferencia.Text.Trim

        If (txtReferencia.Text.Trim = String.Empty) Then

            MessageBox.Show("Debe especificar una Referencia", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            txtReferencia.Focus()

            Exit Function

        End If

        If (txtFicha.Text = 0) Then
            MessageBox.Show("Debe especificar una Ficha de Retiro", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFicha.Focus()

            Exit Function

        End If

        If (txtCantidadRetiro.Text = 0) Then
            MessageBox.Show("Debe especificar una Cantidad de Retiro", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCantidadRetiro.Focus()

            Exit Function

        End If
        '---------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 11/06/2013: Validamos que no este hecho el cierre de caja de el día que estan seleccionando
        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim oInicioCaja As InicioCaja

        oInicioCaja = oInicioCajaMgr.Create

        oInicioCaja.InicioDiaID = oInicioDiaMgr.Load(Me.cmbFecha.Value, oAppContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0"))
        oInicioCaja.InicioCajaID = oInicioCajaMgr.Load(oAppContext.ApplicationConfiguration.NoCaja.Trim.PadLeft(2, "0"), oInicioCaja.InicioDiaID)

        If oCierreCajaMgr.SelByInicioCajaID(oInicioCaja.InicioCajaID) Then
            MessageBox.Show("El cierre de caja de la fecha seleccionada ya fue realizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbFecha.Focus()
            Exit Function
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 11/06/2013: Validamos que haya algun ingreso en efectivo registrado en la fecha seleccionada
        '---------------------------------------------------------------------------------------------------------------------------------------
        If oFacturaMgr.GetVtasTotales(Me.cmbFecha.Value).Tables(0).Rows(0)!EFEC <= 0 Then
            MessageBox.Show("No hay ingresos registrados de la fecha seleccionada." & vbCrLf & "No es posible realizar el retiro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbFecha.Focus()
            Exit Function
        End If

        Return True

    End Function

#End Region


#Region " Metodos Miembros Eventos"


    Private Sub txtRetiroID_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Buscar(True)

    End Sub

    Private Sub frmRetiro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitializeObjects()

        InitializeBinding()

        Me.UiCommandManager1.Commands.Item("MenuGuardar").Enabled = InheritableBoolean.False

        MontoTotal()

        txtReferencia.Text = oAppContext.ApplicationConfiguration.ReferenciaEfectivo

        LimpiaPantalla()
        SendKeys.Send("{TAB}")

    End Sub




    Private Sub txtRetiroID_ButtonClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRetiroID.ButtonClick

        Buscar(True)

    End Sub


#End Region




    Private Sub frmRetiro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        End If
    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key
            Case "menuNuevo"

                LimpiaPantalla()

            Case "menuAbrir"

                Buscar(True)

            Case "menuGuardar"

                Guardar()

            Case "menuEliminar"

                Eliminar()

            Case "menuCancelar"

                Me.Close()

            Case "menuSalir"

                Me.Close()

        End Select
    End Sub

    Private Sub LimpiaPantalla()

        Me.UiCommandManager1.Commands.Item("MenuGuardar").Enabled = InheritableBoolean.True

        txtRetiroID.Text = ""
        txtRetiroID.ReadOnly = True
        cmbFecha.Text = Date.Today
        txtReferencia.Text = ""
        txtFicha.Text = ""
        txtCantidadRetiro.Text = ""
        txtCantidadRetiro.Enabled = True
        Me.ebCodBanco.Text = oAppContext.ApplicationConfiguration.ReferenciaEfectivo

        Dim oBanco As Bancos
        Dim oBancosMgr As New CatalogoBancosManager(oAppContext)

        oBanco = oBancosMgr.Create
        oBanco = oBancosMgr.Load(Me.ebCodBanco.Text)
        Me.txtReferencia.Text = oBanco.ReferEfectivo

        oRetiros = oRetirosMgr.Create
        oRetiros.CodBanco = Me.ebCodBanco.Text


        Me.txtRetiroID.Value = oRetirosMgr.SelectFolio() + 1
        Me.txtFicha.Text = "0"
        Me.txtFicha.Focus()



    End Sub

    Private Sub Eliminar()
        If (oRetiros Is Nothing) Then

            MessageBox.Show("No ha sido seleccionado un Folio para Borrar", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRetiroID.Focus()

            Exit Sub

        End If

        If DateDiff(DateInterval.Day, Me.cmbFecha.Value, Now.Date) > 0 Then

            MessageBox.Show("No puede modificar retiros de fechas anteriores", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        End If


        If (MessageBox.Show("Se encuentra seguro de Eliminar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
            Exit Sub
        End If


        oRetirosMgr.Delete(oRetiros.RetiroID)

        txtRetiroID.Text = ""
        cmbFecha.Text = Date.Today
        txtReferencia.Text = ""
        txtFicha.Text = ""
        txtCantidadRetiro.Text = ""

        oRetiros = Nothing

        MessageBox.Show("La información ha sido Eliminada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        MontoTotal()

    End Sub

End Class
