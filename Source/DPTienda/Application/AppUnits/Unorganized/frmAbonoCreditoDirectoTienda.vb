Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosDPVale
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Imports Janus.Windows.GridEX

Public Class frmAbonoCreditoDirectoTienda
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents EBAsociado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EBFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents EBFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents MenuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivoAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchiviGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivoSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents MenuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchiviGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents EBLimiteCredito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EBSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EBDisponible As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents dgFacturas As Janus.Windows.GridEX.GridEX
    Friend WithEvents MenuArchivoAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Ayuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Ayuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Ayuda2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivoAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents txtTotalBonificacion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalAbono As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents MenuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivoEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivoEliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivoEliminar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UltimoMovimiento2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UltimoMovimiento1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuOpciones As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UltimoMovimiento3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EBIDAsociado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents MenuArchivoExportar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivoExportar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuOpciones1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuArchivoExportar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator11 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbonoCreditoDirectoTienda))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.EBIDAsociado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.EBDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.EBSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.EBLimiteCredito = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalBonificacion = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotalAbono = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dgFacturas = New Janus.Windows.GridEX.GridEX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EBAsociado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EBFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.EBFolio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.MenuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoNuevo")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MenuArchivoAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoAbrir")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MenuArchiviGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoGuardar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MenuArchivoExportar1 = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoExportar")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MenuArchivoEliminar1 = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoEliminar")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.UltimoMovimiento1 = New Janus.Windows.UI.CommandBars.UICommand("UltimoMovimiento")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Ayuda2 = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.MenuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoSalir")
        Me.MenuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoNuevo")
        Me.MenuArchivoAbrir = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoAbrir")
        Me.MenuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoGuardar")
        Me.MenuArchivo = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivo")
        Me.MenuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MenuArchiviGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoGuardar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MenuArchivoExportar2 = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoExportar")
        Me.Separator11 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MenuArchivoEliminar2 = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoEliminar")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MenuArchivoSalir1 = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoSalir")
        Me.MenuArchivoAyuda = New Janus.Windows.UI.CommandBars.UICommand("MenuAyuda")
        Me.Ayuda1 = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.Ayuda = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.MenuArchivoEliminar = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoEliminar")
        Me.UltimoMovimiento2 = New Janus.Windows.UI.CommandBars.UICommand("UltimoMovimiento")
        Me.MenuOpciones = New Janus.Windows.UI.CommandBars.UICommand("MenuOpciones")
        Me.UltimoMovimiento3 = New Janus.Windows.UI.CommandBars.UICommand("UltimoMovimiento")
        Me.MenuArchivoExportar = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivoExportar")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.MenuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("MenuArchivo")
        Me.MenuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("MenuAyuda")
        Me.MenuOpciones1 = New Janus.Windows.UI.CommandBars.UICommand("MenuOpciones")
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.dgFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExplorerBar1.Controls.Add(Me.EBIDAsociado)
        Me.ExplorerBar1.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar1.Controls.Add(Me.EBDisponible)
        Me.ExplorerBar1.Controls.Add(Me.EBSaldo)
        Me.ExplorerBar1.Controls.Add(Me.EBLimiteCredito)
        Me.ExplorerBar1.Controls.Add(Me.txtTotalBonificacion)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.txtTotalAbono)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.dgFacturas)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.EBAsociado)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.EBFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        Me.ExplorerBar1.Controls.Add(Me.EBFolio)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Abono a Credito Directo en Tienda"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 56)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(642, 696)
        Me.ExplorerBar1.TabIndex = 2
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'EBIDAsociado
        '
        Me.EBIDAsociado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBIDAsociado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBIDAsociado.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!)
        Me.EBIDAsociado.ButtonImage = CType(resources.GetObject("EBIDAsociado.ButtonImage"), System.Drawing.Image)
        Me.EBIDAsociado.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EBIDAsociado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBIDAsociado.Location = New System.Drawing.Point(94, 80)
        Me.EBIDAsociado.MaxLength = 10
        Me.EBIDAsociado.Name = "EBIDAsociado"
        Me.EBIDAsociado.Size = New System.Drawing.Size(120, 22)
        Me.EBIDAsociado.TabIndex = 51
        Me.EBIDAsociado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBIDAsociado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(32, 344)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(208, 32)
        Me.btnAceptar.TabIndex = 50
        Me.btnAceptar.Text = "Capturar Formas de Pago"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EBDisponible
        '
        Me.EBDisponible.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBDisponible.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBDisponible.BackColor = System.Drawing.Color.Ivory
        Me.EBDisponible.Enabled = False
        Me.EBDisponible.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBDisponible.ForeColor = System.Drawing.Color.Red
        Me.EBDisponible.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBDisponible.Location = New System.Drawing.Point(539, 112)
        Me.EBDisponible.MaxLength = 8
        Me.EBDisponible.Name = "EBDisponible"
        Me.EBDisponible.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EBDisponible.Size = New System.Drawing.Size(96, 22)
        Me.EBDisponible.TabIndex = 49
        Me.EBDisponible.Text = "$0.00"
        Me.EBDisponible.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBDisponible.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EBSaldo
        '
        Me.EBSaldo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBSaldo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBSaldo.BackColor = System.Drawing.Color.Ivory
        Me.EBSaldo.Enabled = False
        Me.EBSaldo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBSaldo.ForeColor = System.Drawing.Color.Red
        Me.EBSaldo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBSaldo.Location = New System.Drawing.Point(323, 112)
        Me.EBSaldo.MaxLength = 8
        Me.EBSaldo.Name = "EBSaldo"
        Me.EBSaldo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EBSaldo.Size = New System.Drawing.Size(96, 22)
        Me.EBSaldo.TabIndex = 48
        Me.EBSaldo.Text = "$0.00"
        Me.EBSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBSaldo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EBLimiteCredito
        '
        Me.EBLimiteCredito.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBLimiteCredito.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBLimiteCredito.BackColor = System.Drawing.Color.Ivory
        Me.EBLimiteCredito.Enabled = False
        Me.EBLimiteCredito.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBLimiteCredito.ForeColor = System.Drawing.Color.Red
        Me.EBLimiteCredito.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBLimiteCredito.Location = New System.Drawing.Point(134, 112)
        Me.EBLimiteCredito.MaxLength = 8
        Me.EBLimiteCredito.Name = "EBLimiteCredito"
        Me.EBLimiteCredito.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EBLimiteCredito.Size = New System.Drawing.Size(96, 22)
        Me.EBLimiteCredito.TabIndex = 47
        Me.EBLimiteCredito.Text = "$0.00"
        Me.EBLimiteCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBLimiteCredito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtTotalBonificacion
        '
        Me.txtTotalBonificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalBonificacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTotalBonificacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTotalBonificacion.BackColor = System.Drawing.Color.Ivory
        Me.txtTotalBonificacion.Enabled = False
        Me.txtTotalBonificacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBonificacion.ForeColor = System.Drawing.Color.Red
        Me.txtTotalBonificacion.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtTotalBonificacion.Location = New System.Drawing.Point(517, 352)
        Me.txtTotalBonificacion.MaxLength = 8
        Me.txtTotalBonificacion.Name = "txtTotalBonificacion"
        Me.txtTotalBonificacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalBonificacion.Size = New System.Drawing.Size(96, 22)
        Me.txtTotalBonificacion.TabIndex = 46
        Me.txtTotalBonificacion.Text = "$0.00"
        Me.txtTotalBonificacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtTotalBonificacion.Visible = False
        Me.txtTotalBonificacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.AccessibleDescription = "0"
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(373, 352)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(132, 14)
        Me.Label17.TabIndex = 45
        Me.Label17.Text = "Total Bonificaciones:"
        Me.Label17.Visible = False
        '
        'txtTotalAbono
        '
        Me.txtTotalAbono.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAbono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTotalAbono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTotalAbono.BackColor = System.Drawing.Color.Ivory
        Me.txtTotalAbono.Enabled = False
        Me.txtTotalAbono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAbono.ForeColor = System.Drawing.Color.Red
        Me.txtTotalAbono.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtTotalAbono.Location = New System.Drawing.Point(517, 319)
        Me.txtTotalAbono.MaxLength = 8
        Me.txtTotalAbono.Name = "txtTotalAbono"
        Me.txtTotalAbono.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalAbono.Size = New System.Drawing.Size(96, 22)
        Me.txtTotalAbono.TabIndex = 44
        Me.txtTotalAbono.Text = "$0.00"
        Me.txtTotalAbono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtTotalAbono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.AccessibleDescription = "0"
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(397, 321)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 14)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Total Abono"
        '
        'dgFacturas
        '
        Me.dgFacturas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgFacturas.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.dgFacturas.DesignTimeLayout = GridEXLayout1
        Me.dgFacturas.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.dgFacturas.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dgFacturas.GroupByBoxVisible = False
        Me.dgFacturas.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dgFacturas.Location = New System.Drawing.Point(9, 152)
        Me.dgFacturas.Name = "dgFacturas"
        Me.dgFacturas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgFacturas.Size = New System.Drawing.Size(626, 152)
        Me.dgFacturas.TabIndex = 42
        Me.dgFacturas.TabStop = False
        Me.dgFacturas.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgFacturas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.AccessibleDescription = "0"
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(267, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Saldo :"
        '
        'Label4
        '
        Me.Label4.AccessibleDescription = "0"
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Limite de Credito :"
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = "0"
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(459, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Disponible :"
        '
        'EBAsociado
        '
        Me.EBAsociado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBAsociado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBAsociado.BackColor = System.Drawing.Color.Ivory
        Me.EBAsociado.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBAsociado.Enabled = False
        Me.EBAsociado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBAsociado.ForeColor = System.Drawing.Color.Black
        Me.EBAsociado.Location = New System.Drawing.Point(228, 80)
        Me.EBAsociado.Name = "EBAsociado"
        Me.EBAsociado.ReadOnly = True
        Me.EBAsociado.Size = New System.Drawing.Size(408, 22)
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
        Me.Label2.Location = New System.Drawing.Point(14, 84)
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
        Me.Label1.Location = New System.Drawing.Point(436, 49)
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
        Me.EBFecha.Location = New System.Drawing.Point(484, 48)
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
        Me.Label18.Location = New System.Drawing.Point(14, 50)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 23)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "No. Abono:"
        Me.Label18.Visible = False
        '
        'EBFolio
        '
        Me.EBFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBFolio.BackColor = System.Drawing.Color.Ivory
        Me.EBFolio.Enabled = False
        Me.EBFolio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBFolio.ForeColor = System.Drawing.Color.Red
        Me.EBFolio.Location = New System.Drawing.Point(94, 48)
        Me.EBFolio.MaxLength = 4
        Me.EBFolio.Name = "EBFolio"
        Me.EBFolio.Size = New System.Drawing.Size(290, 22)
        Me.EBFolio.TabIndex = 5
        Me.EBFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBFolio.Visible = False
        Me.EBFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MenuArchivo1, Me.MenuAyuda1, Me.MenuOpciones1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(642, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2, Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MenuArchivoSalir, Me.MenuArchivoNuevo, Me.MenuArchivoAbrir, Me.MenuArchivoGuardar, Me.MenuArchivo, Me.MenuArchivoAyuda, Me.Ayuda, Me.MenuArchivoEliminar, Me.UltimoMovimiento2, Me.MenuOpciones, Me.MenuArchivoExportar})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("904d35f8-c8a3-4462-b871-b9b546d9609e")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.ShowQuickCustomizeMenu = False
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        Me.UiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 753)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(728, 0)
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MenuArchivoNuevo2, Me.Separator3, Me.MenuArchivoAbrir1, Me.Separator5, Me.MenuArchiviGuardar2, Me.Separator4, Me.MenuArchivoExportar1, Me.Separator10, Me.MenuArchivoEliminar1, Me.Separator7, Me.UltimoMovimiento1, Me.Separator9, Me.Separator6, Me.Ayuda2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(393, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'MenuArchivoNuevo2
        '
        Me.MenuArchivoNuevo2.Key = "MenuArchivoNuevo"
        Me.MenuArchivoNuevo2.Name = "MenuArchivoNuevo2"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'MenuArchivoAbrir1
        '
        Me.MenuArchivoAbrir1.Key = "MenuArchivoAbrir"
        Me.MenuArchivoAbrir1.Name = "MenuArchivoAbrir1"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'MenuArchiviGuardar2
        '
        Me.MenuArchiviGuardar2.Image = CType(resources.GetObject("MenuArchiviGuardar2.Image"), System.Drawing.Image)
        Me.MenuArchiviGuardar2.Key = "MenuArchivoGuardar"
        Me.MenuArchiviGuardar2.Name = "MenuArchiviGuardar2"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'MenuArchivoExportar1
        '
        Me.MenuArchivoExportar1.Key = "MenuArchivoExportar"
        Me.MenuArchivoExportar1.Name = "MenuArchivoExportar1"
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'MenuArchivoEliminar1
        '
        Me.MenuArchivoEliminar1.Key = "MenuArchivoEliminar"
        Me.MenuArchivoEliminar1.Name = "MenuArchivoEliminar1"
        Me.MenuArchivoEliminar1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'UltimoMovimiento1
        '
        Me.UltimoMovimiento1.Key = "UltimoMovimiento"
        Me.UltimoMovimiento1.Name = "UltimoMovimiento1"
        Me.UltimoMovimiento1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'Ayuda2
        '
        Me.Ayuda2.Key = "Ayuda"
        Me.Ayuda2.Name = "Ayuda2"
        '
        'MenuArchivoSalir
        '
        Me.MenuArchivoSalir.Key = "MenuArchivoSalir"
        Me.MenuArchivoSalir.Name = "MenuArchivoSalir"
        Me.MenuArchivoSalir.Text = "&Salir"
        '
        'MenuArchivoNuevo
        '
        Me.MenuArchivoNuevo.Icon = CType(resources.GetObject("MenuArchivoNuevo.Icon"), System.Drawing.Icon)
        Me.MenuArchivoNuevo.Key = "MenuArchivoNuevo"
        Me.MenuArchivoNuevo.Name = "MenuArchivoNuevo"
        Me.MenuArchivoNuevo.Text = "&Nuevo"
        '
        'MenuArchivoAbrir
        '
        Me.MenuArchivoAbrir.Icon = CType(resources.GetObject("MenuArchivoAbrir.Icon"), System.Drawing.Icon)
        Me.MenuArchivoAbrir.Key = "MenuArchivoAbrir"
        Me.MenuArchivoAbrir.Name = "MenuArchivoAbrir"
        Me.MenuArchivoAbrir.Text = "Abrir"
        '
        'MenuArchivoGuardar
        '
        Me.MenuArchivoGuardar.Image = CType(resources.GetObject("MenuArchivoGuardar.Image"), System.Drawing.Image)
        Me.MenuArchivoGuardar.Key = "MenuArchivoGuardar"
        Me.MenuArchivoGuardar.Name = "MenuArchivoGuardar"
        Me.MenuArchivoGuardar.Text = "&Guardar"
        '
        'MenuArchivo
        '
        Me.MenuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MenuArchivoNuevo1, Me.Separator1, Me.MenuArchiviGuardar1, Me.Separator2, Me.MenuArchivoExportar2, Me.Separator11, Me.MenuArchivoEliminar2, Me.Separator8, Me.MenuArchivoSalir1})
        Me.MenuArchivo.Key = "MenuArchivo"
        Me.MenuArchivo.Name = "MenuArchivo"
        Me.MenuArchivo.Text = "&Archivo"
        '
        'MenuArchivoNuevo1
        '
        Me.MenuArchivoNuevo1.Key = "MenuArchivoNuevo"
        Me.MenuArchivoNuevo1.Name = "MenuArchivoNuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'MenuArchiviGuardar1
        '
        Me.MenuArchiviGuardar1.Key = "MenuArchivoGuardar"
        Me.MenuArchiviGuardar1.Name = "MenuArchiviGuardar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'MenuArchivoExportar2
        '
        Me.MenuArchivoExportar2.Key = "MenuArchivoExportar"
        Me.MenuArchivoExportar2.Name = "MenuArchivoExportar2"
        '
        'Separator11
        '
        Me.Separator11.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator11.Key = "Separator"
        Me.Separator11.Name = "Separator11"
        '
        'MenuArchivoEliminar2
        '
        Me.MenuArchivoEliminar2.Key = "MenuArchivoEliminar"
        Me.MenuArchivoEliminar2.Name = "MenuArchivoEliminar2"
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'MenuArchivoSalir1
        '
        Me.MenuArchivoSalir1.Key = "MenuArchivoSalir"
        Me.MenuArchivoSalir1.Name = "MenuArchivoSalir1"
        '
        'MenuArchivoAyuda
        '
        Me.MenuArchivoAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Ayuda1})
        Me.MenuArchivoAyuda.Key = "MenuAyuda"
        Me.MenuArchivoAyuda.Name = "MenuArchivoAyuda"
        Me.MenuArchivoAyuda.Text = "A&yuda"
        '
        'Ayuda1
        '
        Me.Ayuda1.Key = "Ayuda"
        Me.Ayuda1.Name = "Ayuda1"
        '
        'Ayuda
        '
        Me.Ayuda.Image = CType(resources.GetObject("Ayuda.Image"), System.Drawing.Image)
        Me.Ayuda.Key = "Ayuda"
        Me.Ayuda.Name = "Ayuda"
        Me.Ayuda.Text = "Ay&uda"
        '
        'MenuArchivoEliminar
        '
        Me.MenuArchivoEliminar.Icon = CType(resources.GetObject("MenuArchivoEliminar.Icon"), System.Drawing.Icon)
        Me.MenuArchivoEliminar.Key = "MenuArchivoEliminar"
        Me.MenuArchivoEliminar.Name = "MenuArchivoEliminar"
        Me.MenuArchivoEliminar.Text = "&Eliminar"
        Me.MenuArchivoEliminar.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'UltimoMovimiento2
        '
        Me.UltimoMovimiento2.Icon = CType(resources.GetObject("UltimoMovimiento2.Icon"), System.Drawing.Icon)
        Me.UltimoMovimiento2.Key = "UltimoMovimiento"
        Me.UltimoMovimiento2.Name = "UltimoMovimiento2"
        Me.UltimoMovimiento2.Text = "Ultimo &Movimiento"
        Me.UltimoMovimiento2.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'MenuOpciones
        '
        Me.MenuOpciones.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.UltimoMovimiento3})
        Me.MenuOpciones.Key = "MenuOpciones"
        Me.MenuOpciones.Name = "MenuOpciones"
        Me.MenuOpciones.Text = "&Opciones"
        '
        'UltimoMovimiento3
        '
        Me.UltimoMovimiento3.Key = "UltimoMovimiento"
        Me.UltimoMovimiento3.Name = "UltimoMovimiento3"
        '
        'MenuArchivoExportar
        '
        Me.MenuArchivoExportar.Icon = CType(resources.GetObject("MenuArchivoExportar.Icon"), System.Drawing.Icon)
        Me.MenuArchivoExportar.Key = "MenuArchivoExportar"
        Me.MenuArchivoExportar.Name = "MenuArchivoExportar"
        Me.MenuArchivoExportar.Text = "Exportar Excel"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 50)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 703)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(728, 50)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 703)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2, Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(642, 50)
        '
        'MenuArchivo1
        '
        Me.MenuArchivo1.Key = "MenuArchivo"
        Me.MenuArchivo1.Name = "MenuArchivo1"
        '
        'MenuAyuda1
        '
        Me.MenuAyuda1.Key = "MenuAyuda"
        Me.MenuAyuda1.Name = "MenuAyuda1"
        '
        'MenuOpciones1
        '
        Me.MenuOpciones1.Key = "MenuOpciones"
        Me.MenuOpciones1.Name = "MenuOpciones1"
        '
        'frmAbonoCreditoDirectoTienda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(642, 479)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmAbonoCreditoDirectoTienda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.dgFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

    Private oAbonoCreditoDirectoMgr As AbonoCreditoDirectoManager
    Private oAbonoCreditoDirectoDG As AbonoCreditoDirectoDataGateway
    Private oAbonoCreditoDirecto As AbonoCreditoDirecto

    Public dsDataSet, dsDevoluciones As DataSet

    Private oAsociadosMgr As AsociadosManager
    Private oAsociado As Asociado

    Private oPorcComision As Decimal
    Private oIDCliente As Integer

    Private SaldoFavor As Decimal
    '*****

    Private oAbonoDPVale As AbonoDPVale
    Private oAbonoDPValeMgr As AbonosDPValeManager

    Private oClientes As ClienteAlterno
    Private oClientesMgr As ClientesManager

    Private MontoPago As Double
    Private Bandera As Boolean = False  'Controlar  CurrentCellChanged
    Private BanderaDev As Boolean = False

    Private oValeCaja As ValeCaja
    Private oValecajaMgr As ValeCajaManager
    Private dsValeCaja As DataSet
    Private IDValeCajaDev As Integer = 0

    Private bandConsulta As Boolean = True

    Private FlagExitSecure As Boolean = False

    Private MostrarMensaje As Boolean

    Private oFacturaMgr As FacturaManager

    Dim bolSalir As Boolean = False

#End Region

#Region "Metodos de Busqueda"

    Private Sub Sm_BuscarAsociado(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then

            LimpiaPantalla()

            Dim oOpenRecordDlg As New OpenRecordDialogClientes
            oOpenRecordDlg.GrupoDeCuentas = "D"
            oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

            If (oOpenRecordDlg.CurrentView Is Nothing) Then
                Exit Sub
            End If


            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Try

                    Dim strClienteID As String

                    If oOpenRecordDlg.pbCodigo = String.Empty Then

                        strClienteID = oOpenRecordDlg.Record.Item("CodigoAlterno")

                    Else

                        strClienteID = oOpenRecordDlg.pbCodigo

                    End If

                    oClientes = oClientesMgr.CreateAlterno
                    oClientesMgr.Load(strClienteID, oClientes, "D")

                    With oClientes
                        EBIDAsociado.Text = .CodigoAlterno
                        EBAsociado.Text = .Nombre & " " & .ApellidoPaterno & " " & .ApellidoMaterno
                    End With

                    'Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                    'oAbonoCreditoDirecto.NewFacturas = FI06(oClientes.CodigoAlterno)
                    '**********************************
                    oAbonoCreditoDirecto.ClienteID = oClientes.CodigoAlterno
                    oAbonoCreditoDirecto.AsociadoID = oClientes.CodigoAlterno


                    Dim oFacturaMgr As New FacturaManager(oAppContext)
                    oAbonoCreditoDirecto.NewFacturas = oFacturaMgr.SelectFacturasCDT(oClientes.CodigoAlterno, True).Tables("Facturas")

                    If oAbonoCreditoDirecto.NewFacturas.Rows.Count = 0 Then
                        MsgBox("El Asociado no Tiene Facturas Activas", MsgBoxStyle.Critical, "Sin Facturas")
                        Exit Sub
                    End If

                    Dim odrArticulo As DataRow
                    Dim strFacturas As String
                    Dim blBand As Boolean = True
               
                    '**********************************
                    oAbonoCreditoDirecto.ANombre = oClientes.Nombre
                    oAbonoCreditoDirecto.AApellidoMaterno = oClientes.ApellidoMaterno
                    oAbonoCreditoDirecto.AApellidoPaterno = oClientes.ApellidoPaterno
                    oAbonoCreditoDirecto.Saldo = oAbonoCreditoDirecto.NewFacturas.Compute("Sum(Saldo)", "")
                    '********************************
                    'Temporal

                    '--Cargamos Datos de Credito del Asociado
                    Dim oLimiteCreditoSAP As CreditoAsociadoSAP
                    oLimiteCreditoSAP = New CreditoAsociadoSAP
                    Dim oSAPmgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                    oLimiteCreditoSAP = oSAPmgr.GetCreditoAsociadoSAP(oClientes.CodigoAlterno.PadLeft(10, "0"))
                    oSAPmgr = Nothing

                    Me.EBLimiteCredito.Text = oLimiteCreditoSAP.LimiteCredito
                    Me.EBSaldo.Text = oAbonoCreditoDirecto.Saldo
                    Me.EBDisponible.Text = CType(Me.EBLimiteCredito.Text, Double) - CType(Me.EBSaldo.Text, Double)
                    '--Cargamos Datos de Credito del Asociado

                    Bandera = False
                    bandConsulta = True
                    'Mandar la tabla al grid
                    Me.dgFacturas.DataSource = oAbonoCreditoDirecto.NewFacturas

                    Me.UiCommandManager1.Commands.Item("MenuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.True
                    Me.UiCommandManager1.Commands.Item("MenuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
                    Me.dgFacturas.Enabled = True

                Catch ex As Exception

                    Exit Sub

                End Try

            End If

        Else
            Dim strAsociado As String = Me.EBIDAsociado.Text.Trim
            LimpiaPantalla()
            EBIDAsociado.Text = strAsociado

            ''Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            'Las facturas ahora se tomaran de PTVenta
            'oAbonoCreditoDirecto.NewFacturas = FI06(strAsociado)
            ''************************
            'If oAbonoCreditoDirecto.NewFacturas Is Nothing Then
            '    Throw New ApplicationException("No regresó datos la BAPI ZBAPI_EXTFACTABONOS")
            'End If

            oClientes = oClientesMgr.CreateAlterno
            oClientesMgr.Load(strAsociado, oClientes, "D")
            If oClientes.CodigoAlterno Is Nothing Then
                MsgBox("El Asociado no Existe", MsgBoxStyle.Critical, "No existe")
                LimpiaPantalla()
                Exit Sub
            End If

            EBIDAsociado.Text = oClientes.CodigoAlterno
            EBAsociado.Text = oClientes.Nombre & Space(1) & oClientes.ApellidoPaterno & Space(1) & oClientes.ApellidoMaterno

            '*******************************************************************
            oAbonoCreditoDirecto.ClienteID = oClientes.CodigoAlterno
            oAbonoCreditoDirecto.AsociadoID = oClientes.CodigoAlterno
            oAbonoCreditoDirecto.ANombre = oClientes.Nombre
            oAbonoCreditoDirecto.AApellidoMaterno = oClientes.ApellidoMaterno
            oAbonoCreditoDirecto.AApellidoPaterno = oClientes.ApellidoPaterno
            '*******************************************************************
            Dim oFacturaMgr As New FacturaManager(oAppContext)
            oAbonoCreditoDirecto.NewFacturas = oFacturaMgr.SelectFacturasCDT(oClientes.CodigoAlterno, True).Tables("Facturas")

            If oAbonoCreditoDirecto.NewFacturas.Rows.Count = 0 Then
                MsgBox("El Asociado no Tiene Facturas Activas", MsgBoxStyle.Critical, "Sin Facturas")
                LimpiaPantalla()
                Exit Sub
            End If


            Dim odrArticulo As DataRow
            Dim strFacturas As String
            Dim blBand As Boolean
          
            '*********************************************************
            oAbonoCreditoDirecto.Saldo = oAbonoCreditoDirecto.NewFacturas.Compute("Sum(Saldo)", "")
            oAbonoCreditoDirecto.AsociadoID = oClientes.CodigoAlterno
            oAbonoCreditoDirecto.ClienteID = oClientes.CodigoAlterno
            '**********************************************************

            '--Cargamos Datos de Credito del Asociado
            Dim oLimiteCreditoSAP As CreditoAsociadoSAP
            oLimiteCreditoSAP = New CreditoAsociadoSAP
            Dim oSAPmgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oLimiteCreditoSAP = oSAPmgr.GetCreditoAsociadoSAP(oClientes.CodigoAlterno.PadLeft(10, "0"))
            oSAPmgr = Nothing

            Me.EBLimiteCredito.Text = oLimiteCreditoSAP.LimiteCredito
            Me.EBSaldo.Text = oAbonoCreditoDirecto.Saldo
            Me.EBDisponible.Text = CType(Me.EBLimiteCredito.Text, Double) - CType(Me.EBSaldo.Text, Double)
            '--Cargamos Datos de Credito del Asociado

            Bandera = False

            Me.dgFacturas.DataSource = oAbonoCreditoDirecto.NewFacturas

            Me.UiCommandManager1.Commands.Item("MenuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.True
            Me.UiCommandManager1.Commands.Item("MenuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.dgFacturas.Enabled = True
            bandConsulta = True
        End If
    End Sub

    Private Sub UltimoMovimiento()
        'ver si se va a poder usar esta

        'If EBIDAsociado.Text > 0 Then
        '    oAsociado.Clear()
        '    oAbonoDPVale = Me.oAbonoDPValeMgr.GetUltimoAbono("002", EBIDAsociado.Text)
        '    If Not (oAbonoDPVale Is Nothing) Then
        '        If (oAbonoDPVale.StatusRegistro = True) Then
        '            Me.EBFolio.Text = oAbonoDPVale.IDAbono
        '            Me.EBIDAsociado.Text = oAbonoDPVale.AsociadoID

        '            oAbonoCreditoDirecto = oAbonoCreditoDirectoMgr.SelectCreditoDirectoByID(oAbonoDPVale.AsociadoID)
        '            If oAbonoCreditoDirecto.AsociadoID <> 0 Then
        '                LimpiarTodo()
        '                Me.EBFolio.Text = oAbonoDPVale.IDAbono
        '                EBIDAsociado.Text = oAbonoCreditoDirecto.AsociadoID
        '                EBAsociado.Text = oAbonoCreditoDirecto.ANombre & Space(1) & oAbonoCreditoDirecto.AApellidoPaterno & Space(1) & oAbonoCreditoDirecto.AApellidoMaterno
        '                Me.EBLimiteCredito.Text = oAbonoCreditoDirecto.LimiteCredito
        '                Me.EBSaldo.Text = oAbonoCreditoDirecto.Saldo
        '                Me.EBDisponible.Text = CType(Me.EBLimiteCredito.Text, Double) - CType(Me.EBSaldo.Text, Double)

        '                oAbonoCreditoDirecto.FormasDePago = oAbonoDPVale.Detalle.Copy
        '                oAbonoCreditoDirecto.Facturas.Tables("Facturas").Columns.Add("Abono", System.Type.GetType("System.Double"))
        '                oAbonoCreditoDirecto.Facturas.Tables("Facturas").Columns("Abono").DefaultValue = 0.0

        '                oAbonoCreditoDirecto.Facturas.Tables("Facturas").Columns.Add("Bonificacion", System.Type.GetType("System.Double"))
        '                oAbonoCreditoDirecto.Facturas.Tables("Facturas").Columns("Bonificacion").DefaultValue = 0.0


        '                Dim dsAbonosFacturas As New DataSet
        '                ''No está regresando nada
        '                dsAbonosFacturas = oAbonoCreditoDirectoMgr.SelectAbonosFacturas(oAbonoDPVale.IDAbono, _
        '                oAbonoDPVale.CodAlmacen, oAbonoDPVale.CodCaja, oAbonoDPVale.Fecha).Copy

        '                For Each row As DataRow In oAbonoCreditoDirecto.Facturas.Tables("Facturas").Rows
        '                    If CStr(row("RelacionAbonos")).IndexOf(Me.EBFolio.Text) >= 0 Then
        '                        For Each row2 As DataRow In dsAbonosFacturas.Tables("AbonosCreditoDirecto").Rows
        '                            If row2("FolioFactura") = row("FolioFactura") Then
        '                                row("Abono") = row2("Monto")
        '                                row("Bonificacion") = row("DescuentoProntoPago")
        '                            End If
        '                        Next
        '                    End If
        '                Next

        '                Bandera = True
        '                Me.dgFacturas.SetDataBinding(oAbonoCreditoDirecto.Facturas, "Facturas")
        '                Me.dgFacturas.Enabled = False

        '                dsValeCaja = oValecajaMgr.GetByFolioDocumento(Me.oAbonoDPVale.IDAbono, "AB").Copy

        '                bandConsulta = False
        '            End If

        '            Me.UiCommandManager1.Commands.Item("MenuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        '            Me.UiCommandManager1.Commands.Item("MenuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.True

        '        Else
        '            MessageBox.Show("El último abono ya fue cancelado.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If
        '    Else
        '        MessageBox.Show("El Asociado no cuenta con abonos.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Else
        '    MessageBox.Show("Capture el Identificador del Asociado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If

    End Sub

#End Region

#Region "Metodos de Controles"


    Private Sub EBIDAsociado_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBIDAsociado.ButtonClick
        Sm_BuscarAsociado(True)
    End Sub

    Private Sub frmAbonoCreditoDirectoTienda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If BanderaDev = False Then
            InitializeObjects()
        End If

        If oConfigCierreFI.UsarHuellas = False Then

            Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Visible = Janus.Windows.UI.InheritableBoolean.False

        Else

            Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False

        End If

    End Sub

    Private Sub dgFacturas_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgFacturas.CurrentCellChanged
        ''''Lo comentado en este codigo se usó cuando existian las bonoficaciones.

        If Not Bandera Then

            Dim oCurrentRow As GridEXRow

            Dim odrDataRow As DataRowView
            Dim abono As Double
            Dim saldo As Double
            Try

                oCurrentRow = dgFacturas.GetRow()
                odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

                abono = CType(odrDataRow.Item("Abono"), Double)
                saldo = CType(odrDataRow.Item("Saldo"), Double)

                If abono >= 0 Then

                    If abono > saldo Then
                        If BanderaDev Then
                            odrDataRow.Item("Abono") = saldo
                            abono = saldo
                        Else
                            odrDataRow.Item("Abono") = "0.00"
                        End If
                    End If

                Else
                    If Not BanderaDev Then
                        odrDataRow.Item("Abono") = "0.00"
                    End If
                End If

                Me.txtTotalAbono.Text = oAbonoCreditoDirecto.NewFacturas.Compute("Sum(Abono)", "Abono > 0.00")

            Catch ex2 As System.NullReferenceException

            Catch ex As Exception

                If Not BanderaDev Then
                    odrDataRow.Item("Abono") = "0.00"
                End If

            End Try

        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Para que no lo abra si no tiene facturas el cliente
        If (oAbonoCreditoDirecto.NewFacturas.Rows.Count) > 0 Then
            Dim cantidad As Double = Me.txtTotalAbono.Value - Me.txtTotalBonificacion.Value
            Dim frmPagos As New frmFormaPagoACDT(cantidad, _
                                                    oAbonoCreditoDirectoMgr, _
                                                    oAsociado, _
                                                    oAbonoCreditoDirecto, _
                                                    dsValeCaja, _
                                                    bandConsulta, IDValeCajaDev)
            frmPagos.ShowDialog()
            oAbonoCreditoDirecto.FormasDePago = frmPagos.dsDataSet.Copy
            MontoPago = frmPagos.txtEfectivo.Value
            'oValeCaja = frmPagos.oValeCaja
            dsValeCaja = frmPagos.dsValeCaja.Copy
            frmPagos.Dispose()
            frmPagos = Nothing
        End If
    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key

            Case "MenuArchivoNuevo"

                LimpiaPantalla()

            Case "MenuArchivoGuardar"

                MostrarMensaje = True

                Sm_GuardarAbono()

                If BanderaDev Then
                    Me.Close()
                End If

            Case "MenuArchivoEliminar"

                Sm_EliminarAbono()

            Case "MenuArchivoSalir"

                Me.Close()

            Case "UltimoMovimiento"

                UltimoMovimiento()

            Case "MenuArchivoAbrir"

                Sm_BuscarAsociado(True)

            Case "MenuArchivoExportar"

                If oAbonoCreditoDirecto.NewFacturas.Rows.Count > 0 Then
                    ExportExcelObj()
                End If

        End Select

    End Sub

    Private Sub EBIDAsociado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EBIDAsociado.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarAsociado(True)

        ElseIf e.KeyCode = Keys.Enter Then

            If EBIDAsociado.Text <> String.Empty Then
                Sm_BuscarAsociado()
            End If

        End If

    End Sub

    Private Sub ExportExcelObj()

        Dim SaveDialog = New SaveFileDialog
        Dim strRuta As String = String.Empty

        Dim m_Excel
        Dim objLibroExcel
        Dim objHojaExcel

        On Error Resume Next

        m_Excel = GetObject(, "Excel.Application")

        If m_Excel Is Nothing Then
            m_Excel = CreateObject("Excel.Application")
            If m_Excel Is Nothing Then
                MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Auditoría de Retiros")
                Exit Sub
            End If
        Else
            m_Excel = CreateObject("Excel.Application")
        End If

        objLibroExcel = m_Excel.Workbooks.Add
        objHojaExcel = m_Excel.Sheets(1)
        objHojaExcel.Name = "EdoCtaDips"

        '****************************************
        'HOJA DE CALCULO VENTAS TOTALES
        '****************************************

        objHojaExcel.Range("A1:H1").Merge()
        objHojaExcel.Range("A1:H1").Value = "Estado de Cuenta " & Me.EBIDAsociado.Text & " " & Me.EBAsociado.Text
        objHojaExcel.Range("A1:H1").Font.Bold = True
        objHojaExcel.Range("A1:H1").Font.Size = 15
        objHojaExcel.Range("A1:H1").HorizontalAlignment = 3

        objHojaExcel.Range("A2:A2").Value = "Fecha Factura"
        objHojaExcel.Range("A2:A2").Font.Size = 13
        objHojaExcel.Range("B2:B2").Value = "Factura DP"
        objHojaExcel.Range("B2:B2").Font.Size = 13
        objHojaExcel.Range("C2:C2").Value = "Fecha Limite Pago"
        objHojaExcel.Range("C2:C2").Font.Size = 13
        objHojaExcel.Range("D2:D2").Value = "Pago Establecido"
        objHojaExcel.Range("D2:D2").Font.Size = 13
        objHojaExcel.Range("E2:E2").Value = "Abonos"
        objHojaExcel.Range("E2:E2").Font.Size = 13
        objHojaExcel.Range("F2:F2").Value = "Saldo"
        objHojaExcel.Range("F2:F2").Font.Size = 13
        objHojaExcel.Range("G2:G2").Value = "Factura SAP"
        objHojaExcel.Range("G2:G2").Font.Size = 13
        objHojaExcel.Range("H2:H2").Value = "Factura FI"
        objHojaExcel.Range("H2:H2").Font.Size = 13
        Dim oFacturaMgr As New FacturaManager(oAppContext)
        Dim dt As New DataTable
        dt = oFacturaMgr.SelectFacturasCDT(Me.EBIDAsociado.Text, False).Tables("Facturas")

        Dim intRow As Integer = 2
        For Each oRow As DataRow In dt.Rows
            intRow += 1
            objHojaExcel.Cells(intRow, 1) = oRow!FechaFactura
            objHojaExcel.Cells(intRow, 1).HorizontalAlignment = -4108
            objHojaExcel.Cells(intRow, 2) = oRow!DPFactura
            objHojaExcel.Cells(intRow, 2).HorizontalAlignment = -4131
            objHojaExcel.Cells(intRow, 3) = oRow!FechaLimitePago
            objHojaExcel.Cells(intRow, 3).HorizontalAlignment = -4108
            objHojaExcel.Cells(intRow, 4) = oRow!PagoEstablecido
            objHojaExcel.Cells(intRow, 4).HorizontalAlignment = -4152
            objHojaExcel.Cells(intRow, 5) = oRow!Abonos
            objHojaExcel.Cells(intRow, 5).HorizontalAlignment = -4152
            objHojaExcel.Cells(intRow, 6) = oRow!Saldo
            objHojaExcel.Cells(intRow, 6).HorizontalAlignment = -4152
            objHojaExcel.Cells(intRow, 7) = "'" & oRow!FolioFactura
            objHojaExcel.Cells(intRow, 7).HorizontalAlignment = -4131
            objHojaExcel.Cells(intRow, 8) = oRow!DocFi
            objHojaExcel.Cells(intRow, 8).HorizontalAlignment = -4131
        Next

        objHojaExcel.Range("A2:H2").Columns.AutoFit()
        objHojaExcel.Range("A2:H2").AutoFormat(11, Alignment:=False)

        objHojaExcel.PageSetup.FitToPagesWide = 1
        objHojaExcel.PageSetup.FitToPagesTall = 1

        Me.Cursor = Cursors.Default

        'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
        SaveDialog.DefaultExt = "*.xls"
        SaveDialog.Filter = "Libro de Microsoft Office Excel (*.xls)|*.xls"
        If SaveDialog.ShowDialog = DialogResult.OK Then
            objHojaExcel.SaveAs(SaveDialog.FileName)
            MsgBox("Documento guardado en " & SaveDialog.FileName, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Repote Notas de Crédito")
        End If

        objHojaExcel.Close()

        objHojaExcel = Nothing
        m_Excel.Quit()
        m_Excel = Nothing

        KillExcel()

    End Sub

    ''Este procedimiento se utiliza cuando se manda llamar la ventana desde NC-Dips con VC
    Public Sub ShowDev(ByVal IDAsociado As String, ByVal decValeCaja As Decimal, ByVal ValeCajaId As Integer, Optional ByVal Automatico As Boolean = False)
        InitializeObjects()
        BanderaDev = True
        IDValeCajaDev = ValeCajaId
        Me.EBIDAsociado.Text = IDAsociado
        Me.EBIDAsociado.Focus()
        Me.Sm_BuscarAsociado()

        Dim vlCantidad As Double = 0
        Dim vlCantUtil As Double = 0

        'Distribuye automaticamente el abono 
        vlCantidad = vlCantidad + decValeCaja

        For Each row2 As DataRow In oAbonoCreditoDirecto.NewFacturas.Rows
            If (row2("Saldo") < vlCantidad) Then
                row2("Abono") = row2("Saldo")
                vlCantUtil = vlCantUtil + row2("Saldo")
                vlCantidad = vlCantidad - row2("Saldo")
            Else
                row2("Abono") = vlCantidad
                vlCantUtil = vlCantUtil + vlCantidad
                Exit For
            End If
        Next

        txtTotalAbono.Value = vlCantUtil

        Dim cantidad As Double = Me.txtTotalAbono.Value - Me.txtTotalBonificacion.Value

        Dim frmPagos As New frmFormaPagoACDT(cantidad, _
                                                oAbonoCreditoDirectoMgr, _
                                                oAsociado, _
                                                oAbonoCreditoDirecto, _
                                                dsValeCaja, _
                                                bandConsulta, IDValeCajaDev)
        frmPagos.ShowDev()
        oAbonoCreditoDirecto.FormasDePago = frmPagos.dsDataSet.Copy
        MontoPago = frmPagos.txtEfectivo.Value
        dsValeCaja = frmPagos.dsValeCaja.Copy
        frmPagos.Dispose()
        frmPagos = Nothing

        If Automatico = True Then
            MsgBox("Se mandara a imprimir el Abono, preparar Impresora.", MsgBoxStyle.Information, Me.Text)
            MostrarMensaje = False
            Sm_GuardarAbono()
            Me.Close()
        Else
            Me.ShowDialog()
        End If



    End Sub

    Private Sub frmAbonoCreditoDirectoTienda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmAbonoCreditoDirectoTienda_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        bolSalir = True

        If BanderaDev Then

            If Not FlagExitSecure Then

                MsgBox("El abono no ha sido guardado. Favor de guardarlo para poder continuar.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Abonos CDT")
                e.Cancel = True

            End If

        End If

    End Sub

#End Region

#Region "Metodos de Almacenamiento"

    Private Sub Sm_GuardarAbono()
        Try
            If (Fm_bolTxtValidar() = False) Then
                Exit Sub
            End If

            If (oAbonoDPVale Is Nothing) Then   'Opción Guardar.

                If Me.txtTotalAbono.Value = 0.0 Then
                    MessageBox.Show("El total del abono tiene que ser mayor a cero", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If MostrarMensaje = True Then
                    If (MessageBox.Show("Se encuentra seguro de Guardar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                        Exit Sub
                    End If
                End If


                oAbonoDPVale = Nothing
                oAbonoDPVale = oAbonoDPValeMgr.Create
                oAbonoDPVale.AsociadoID = oAbonoCreditoDirecto.AsociadoID
                oAbonoDPVale.IDCliente = oAbonoCreditoDirecto.ClienteID
                oAbonoDPVale.CodSegCred = "002"
                oAbonoDPVale.CodTipAbono = 2
                oAbonoDPVale.SaldoAnt = oAbonoCreditoDirecto.Saldo
                oAbonoDPVale.PagoMin = 0
                oAbonoDPVale.MontoPago = MontoPago
                oAbonoDPVale.SaldNuevo = oAbonoCreditoDirecto.Saldo - MontoPago
                oAbonoDPVale.StatusRegistro = True
                oAbonoDPVale.SetUsuario(oAppContext.Security.CurrentUser.Name)
                oAbonoDPVale.SetCodAlmacen(oAppContext.ApplicationConfiguration.Almacen)
                oAbonoDPVale.SetCodCaja(oAppContext.ApplicationConfiguration.NoCaja)
                oAbonoDPVale.SaldoDPVale = oAbonoCreditoDirecto.Saldo - Me.txtTotalAbono.Value
                oAbonoDPVale.Detalle = oAbonoCreditoDirecto.FormasDePago.Copy

                '******************************SAP Ramiro Alcaraz Flores*********************************
                Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim odrArticulo As DataRow
                Dim strcentro As String = oSap.Read_Centros
                Dim strClabcobr As String
                Dim strBancoTienda(2) As String
                Dim StrResultado(2) As String
                Dim strVCJA As String = String.Empty

                'Ordena descendente para saber que tipo de pago voy a mandar a sap
                strClabcobr = GetFormaPago()

                If strClabcobr = "VCJA" Then
                    strVCJA = "Vale Caja"
                    strClabcobr = "EFECTIVO"
                Else
                    strVCJA = " "
                End If
                strBancoTienda = oAbonoCreditoDirectoMgr.GetSelectNombreBanco(strClabcobr, strcentro)

                '----------------Numero de Referencia---------------
                Dim strNumRef As String = String.Empty
                Dim numref As New NumeroReferencia.cNumReferencia
                strNumRef = numref.getNumReferencia(oAppContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(Date.Now.Date, "ddMMyyyy")))
                '------------------------------------------------------

                Dim strFactDpPro As String = String.Empty

                For Each odrArticulo In oAbonoCreditoDirecto.NewFacturas.Rows
                    If odrArticulo("Abono") <> 0 Then

                        If odrArticulo("DPFactura") <> 0 Then
                            strFactDpPro = odrArticulo("DPFactura")
                        Else
                            'Busco en la La Tabla Factura
                            strFactDpPro = oAbonoCreditoDirectoMgr.GetSelectFolioFacturaDPBySDSAP(oAbonoCreditoDirecto.AsociadoID, odrArticulo("FolioFactura"))
                        End If

                        StrResultado = oSap.Write_ZBAPIFI06_REG_ABONO_PAGO_VENTA(strBancoTienda(0), oAbonoCreditoDirecto.AsociadoID, _
                                                            odrArticulo("Abono"), odrArticulo("FolioFactura"), strClabcobr, strBancoTienda(1), strFactDpPro, strVCJA, strNumRef)

                        oAbonoCreditoDirecto.DocnumFB05 = StrResultado(0)
                        oAbonoCreditoDirecto.DocnumFB01 = StrResultado(1)
                        If StrResultado(0) <> String.Empty And StrResultado(1) <> String.Empty Then
                            'Se graba de todas Formas OK
                            GuardarAbonosCDT(strBancoTienda(0), oAbonoCreditoDirecto.AsociadoID, odrArticulo("Abono"), odrArticulo("FolioFactura"), strClabcobr, strBancoTienda(1), strFactDpPro, StrResultado(1), StrResultado(0))
                        Else
                            'No se Grabo en SAP
                            GuardarAbonosCDT(strBancoTienda(0), oAbonoCreditoDirecto.AsociadoID, odrArticulo("Abono"), odrArticulo("FolioFactura"), strClabcobr, strBancoTienda(1), strFactDpPro, StrResultado(1), StrResultado(0))
                        End If

                    End If
                Next

                'Grabar en Catalogo de caja el Monto de todo los Abonos
                oAbonoCreditoDirectoMgr.UpdateCatalogoCajasAbonoCDT(CDbl(Me.txtTotalAbono.Text), "S")
                '******************************SAP Ramiro Alcaraz Flores*********************************

                EBFolio.Text = oAbonoCreditoDirecto.DocnumFB01 & " " & EBFolio.Text = oAbonoCreditoDirecto.DocnumFB05
                EBFecha.Text = Format(Date.Now, "Short Date")
                'Se guardo y se puede Salir
                FlagExitSecure = True

                'Actualizo Vale de Caja
                For Each row As DataRow In dsValeCaja.Tables("ValesCajas").Rows
                    Dim oValeNuevo As ValeCaja
                    oValeNuevo = oValecajaMgr.Create
                    If StrResultado(1) = String.Empty Then
                        StrResultado(1) = oAbonoDPVale.IDCliente
                    End If
                    If row("Importe") > row("MontoUtilizado") Then

                        'Generamos vale nuevo
                        oValeNuevo.CodCliente = oAbonoDPVale.IDCliente
                        'oValeNuevo.DocumentoID = oAbonoDPVale.IDAbono 'Que Mando??????
                        oValeNuevo.DocumentoID = CInt(StrResultado(1))
                        oValeNuevo.DocumentoImporte = oAbonoDPVale.MontoPago
                        oValeNuevo.Fecha = Now
                        'oValeNuevo.FolioDocumento = oAbonoDPVale.IDAbono 'Que Mando??????
                        oValeNuevo.FolioDocumento = CInt(StrResultado(1))
                        oValeNuevo.Importe = row("Importe") - row("MontoUtilizado")
                        oValeNuevo.MontoUtilizado = 0
                        oValeNuevo.Nombre = Me.EBAsociado.Text
                        oValeNuevo.StastusRegistro = True
                        oValeNuevo.TipoDocumento = "AB"
                        oValeNuevo.Usuario = oAppContext.Security.CurrentUser.SessionLoginName
                        Dim frmValeC As New FrmValeCaja
                        frmValeC.ValeCajaNuevo(oValeNuevo, row("ValeCajaID"), row("MontoUtilizado"))
                        oValeNuevo.ValeCajaID = frmValeC.intValeCajaID 'Se saca el id del vale de caja generado
                        frmValeC.Dispose()
                        frmValeC = Nothing
                    End If
                    oValeCaja = oValecajaMgr.Create
                    oValeCaja.ResetFlagNew()
                    oValeCaja.CodCliente = oAbonoDPVale.IDCliente
                    oValeCaja.ValeCajaID = row("ValeCajaID")
                    oValeCaja.Importe = row("Importe")
                    oValeCaja.MontoUtilizado = row("MontoUtilizado")
                    oValeCaja.Nombre = row("Nombre")
                    oValeCaja.TipoDocumento = "AB"
                    'oValeCaja.FolioDocumento = oAbonoDPVale.IDAbono 'Que Mando??????
                    'oValeCaja.DocumentoID = oAbonoDPVale.IDAbono 'Que Mando??????
                    oValeCaja.FolioDocumento = CInt(StrResultado(1))
                    oValeCaja.DocumentoID = CInt(StrResultado(1))
                    oValeCaja.ValeGenerado = oValeNuevo.ValeCajaID
                    oValeCaja.StastusRegistro = row("StatusRegistro")
                    oValeCaja.Save()
                    oValeCaja = Nothing
                Next

                Me.dgFacturas.Enabled = False
                '--------------------------------------
                Dim ds As New DataSet
                ds.Tables.Add(oAbonoCreditoDirecto.NewFacturas.Copy)
                oAbonoCreditoDirecto.Facturas = ds.Copy
                '--------------------------------------
                'Insertar en la nueva tabla de AbonosCDTDetalles Formas de Pago
                GuardarAbonosCdtDetalle(oAbonoCreditoDirecto.AsociadoID)
                'ToReport 
                InsertToReport(oAbonoCreditoDirecto.AsociadoID)

                ReportPrintPreview()

                MessageBox.Show("La información ha sido Guardada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.UiCommandManager1.Commands.Item("MenuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.False
                Me.UiCommandManager1.Commands.Item("MenuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
                '*****************Para Limpiar que no salgan ya****************
                If Not (oAbonoDPVale Is Nothing) Then
                    oAbonoDPVale = Nothing
                End If

                If Not (dsValeCaja Is Nothing) Then
                    dsValeCaja = Nothing
                End If

                If Not (oAbonoCreditoDirecto.FormasDePago Is Nothing) Then
                    oAbonoCreditoDirecto.FormasDePago = Nothing
                End If
                '***************************************************************

            End If
        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    Private Sub Sm_EliminarAbono()

        'If (MessageBox.Show("Se encuentra seguro de Cancelar el Abono", "DPTienda", MessageBoxButtons.OKCancel, _
        '                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
        '    Exit Sub
        'End If

        'oAbonoCreditoDirectoMgr.Delete(oAbonoCreditoDirecto, oAbonoDPVale)

        '''Eliminacion de Cambios en Vales de Caja
        'For Each row As DataRow In dsValeCaja.Tables("ValesCajas").Rows
        '    If row("MontoUtilizado") = 0 Then
        '        oValecajaMgr.Delete(row("ValeCajaID"), "AB")
        '    ElseIf row("MontoUtilizado") > 0 Then
        '        oValecajaMgr.UpdateMontoToCero(row("ValeCajaID"), "AB")
        '    End If
        'Next


        'MessageBox.Show("Abono Cancelado", "DPTienda", MessageBoxButtons.OK)
        'oAbonoCreditoDirecto.Facturas.Tables("Facturas").Rows.Clear()
        'InitializeObjects()
        'LimpiarTodo()
        'oAbonoDPVale = Nothing
        'Me.UiCommandManager1.Commands.Item("MenuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        'Me.UiCommandManager1.Commands.Item("MenuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False

    End Sub

    Private Sub ImprimirBonificaciones()
        Dim oARReporte As New rptNotaCreditoBonificacion(Me)
        Dim oReportViewer As New ReportViewerForm

        Dim dsBonificaciones As DataSet

        dsBonificaciones = oAbonoCreditoDirecto.Facturas.Clone
        dsBonificaciones.Tables("Facturas").Columns("PagoEstablecido").DataType = System.Type.GetType("System.String")
        dsBonificaciones.Tables("Facturas").Columns("Bonificacion").DataType = System.Type.GetType("System.String")
        Dim i As Integer = 0
        For Each row As DataRow In oAbonoCreditoDirecto.Facturas.Tables("Facturas").Rows
            If row("Bonificacion") > 0.0 Then
                dsBonificaciones.Tables("Facturas").ImportRow(row)
                dsBonificaciones.Tables("Facturas").Rows(i).Item("PagoEstablecido") = Format(row("PagoEstablecido"), "$###,###,###.#0")
                dsBonificaciones.Tables("Facturas").Rows(i).Item("Bonificacion") = Format(row("Bonificacion"), "$###,###,###.#0")
                i += 1
            End If
        Next

        oARReporte.DataSource = dsBonificaciones
        oARReporte.Document.Name = "Abono Credito Directo en Tienda"
        oARReporte.Run()

        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

        Try
            oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ReportPrintPreview()

        Dim oARReporte

        If oConfigCierreFI.MiniPrinter Then

            oARReporte = New rptComprobanteAbonoCreditoDirectoMiniPrinter(oAbonoCreditoDirecto, oAbonoDPVale, Me.EBAsociado.Text)
            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName

        Else

            oARReporte = New rptComprobanteAbonoCreditoDirecto(oAbonoCreditoDirecto, oAbonoDPVale, Me.EBAsociado.Text)

        End If


        oARReporte.Document.Name = "Abono Credito Directo en Tienda"
        oARReporte.Run()


        Try
            oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#End Region

#Region "Metodos de Validacion"


    Private Sub LimpiaPantalla()

        EBFolio.Text = String.Empty
        EBIDAsociado.Text = 0
        EBAsociado.Text = String.Empty
        oPorcComision = 0
        LimpiarTodo()
        EBIDAsociado.Focus()
        Me.UiCommandManager1.Commands.Item("MenuArchivoGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("MenuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.dgFacturas.Enabled = True

        If Not (oAbonoCreditoDirecto.Facturas Is Nothing) Then
            oAbonoCreditoDirecto.Facturas.Reset()
        End If

        If Not (oAbonoCreditoDirecto.NewFacturas Is Nothing) Then
            oAbonoCreditoDirecto.NewFacturas.Reset()
        End If

        If Not (oAbonoDPVale Is Nothing) Then
            oAbonoDPVale = Nothing
        End If


        If Not (dsValeCaja Is Nothing) Then
            dsValeCaja = Nothing
        End If

        If Not (oAbonoCreditoDirecto.FormasDePago Is Nothing) Then
            oAbonoCreditoDirecto.FormasDePago = Nothing
        End If

    End Sub


    Private Function Fm_bolTxtValidar() As Boolean
        If Me.txtTotalAbono.Value <> MontoPago Then
            Me.btnAceptar.PerformClick()
            Return False
        End If
        Return True
    End Function


    Private Sub LimpiarTodo()
        Me.EBFolio.Text = String.Empty
        Me.EBIDAsociado.Text = String.Empty
        Me.EBAsociado.Text = String.Empty
        Me.EBLimiteCredito.Text = 0
        Me.EBSaldo.Text = 0
        Me.EBDisponible.Text = 0
        Me.txtTotalAbono.Text = 0
        Me.txtTotalBonificacion.Text = 0
        Me.EBIDAsociado.Focus()
        Me.EBFecha.Text = String.Empty
        Me.Bandera = False
        ''BanderaDev = False
    End Sub


    Private Sub InitializeObjects()

        oAsociadosMgr = New AsociadosManager(oAppContext)
        oAsociado = oAsociadosMgr.Create
        oAsociado.Clear()

        oAbonoCreditoDirectoMgr = New AbonoCreditoDirectoManager(oAppContext)
        oAbonoCreditoDirectoDG = New AbonoCreditoDirectoDataGateway(oAbonoCreditoDirectoMgr)
        oAbonoCreditoDirecto = oAbonoCreditoDirectoMgr.Create

        Me.dsDataSet = New DataSet("Facturas")

        oAbonoDPValeMgr = New AbonosDPValeManager(oAppContext)
        oValecajaMgr = New ValeCajaManager(oAppContext)

        oClientesMgr = New ClientesManager(oAppContext)

        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
    End Sub


#End Region

#Region "Comentados"

    ''Esta funcion se utiliza en las bonificaciones
    'Public Function getBonificacion(ByVal FolioFactura As Integer, ByVal TipoOferta As String, ByVal CodCaja As String) As Double
    '    Dim nArticulos As Integer
    '    Dim Bonificacion As Double
    '    Dim DescuentoDip, DescuentoNoDip As Decimal
    '    Dim artDevueltos As Integer = 0

    '    Dim dsFacturaDetalle As DataSet
    '    Dim oFacturaCorridaMgr As New FacturaCorridaManager(oAppContext)
    '    dsFacturaDetalle = oFacturaCorridaMgr.LoadDetalle(FolioFactura, CodCaja).Copy

    '    For Each row As DataRow In dsFacturaDetalle.Tables("FacturaDetalle").Rows

    '        If Not (row("Devoluciones") Is System.DBNull.Value) Then
    '            artDevueltos += row("Devoluciones")
    '        End If


    '    Next

    '    nArticulos = dsFacturaDetalle.Tables("FacturaDetalle").Compute("sum(Cantidad)", "Cantidad>0") - artDevueltos

    '    If TipoOferta.Equals("TreintaDias") Then
    '        If nArticulos < 3 Then

    '            DescuentoDip = oAbonoCreditoDirectoMgr.ApplicationContext. _
    '            ApplicationConfiguration.BonificaionTreintaDiasUnoDIP()

    '            DescuentoNoDip = oAbonoCreditoDirectoMgr.ApplicationContext. _
    '            ApplicationConfiguration.BonificaionTreintaDiasUnoNoDIP()

    '        Else

    '            DescuentoDip = oAbonoCreditoDirectoMgr.ApplicationContext. _
    '            ApplicationConfiguration.BonificaionTreintaDiasDosDIP()

    '            DescuentoNoDip = oAbonoCreditoDirectoMgr.ApplicationContext. _
    '            ApplicationConfiguration.BonificaionTreintaDiasDosNoDIP()

    '        End If
    '    ElseIf TipoOferta.Equals("60Dias") Then
    '        If nArticulos < 3 Then

    '            DescuentoDip = oAbonoCreditoDirectoMgr.ApplicationContext. _
    '            ApplicationConfiguration.BonificaionCuarenteDiasUnoDIP()

    '            DescuentoNoDip = oAbonoCreditoDirectoMgr.ApplicationContext. _
    '            ApplicationConfiguration.BonificaionCuarenteDiasUnoNoDIP()

    '        Else

    '            DescuentoDip = oAbonoCreditoDirectoMgr.ApplicationContext. _
    '            ApplicationConfiguration.BonificaionCuarenteDiasDosDIP()

    '            DescuentoNoDip = oAbonoCreditoDirectoMgr.ApplicationContext. _
    '            ApplicationConfiguration.BonificaionCuarenteDiasDosNoDIP()

    '        End If
    '    End If


    '    For Each row As DataRow In dsFacturaDetalle.Tables("FacturaDetalle").Rows
    '        Dim Descuento As Decimal
    '        Descuento = (row("PrecioUnit") - row("PrecioOferta")) * row("Cantidad")
    '        Dim Dev As Double = row("Devoluciones") * row("PrecioOferta")
    '        If row("DIP") = True Then

    '            If Descuento > 0 Then
    '                If (row("Total") * DescuentoDip) > Descuento Then
    '                    Bonificacion += ((row("Total") - Dev) * DescuentoDip) - Descuento
    '                End If
    '            Else
    '                Bonificacion += ((row("Total") - Dev) * DescuentoDip)
    '            End If
    '        Else
    '            If Descuento > 0 Then
    '                If (row("Total") * DescuentoNoDip) > Descuento Then
    '                    Bonificacion += ((row("Total") - Dev) * DescuentoNoDip) - Descuento
    '                End If
    '            Else
    '                Bonificacion += (row("Total") - Dev) * DescuentoNoDip
    '            End If
    '        End If
    '    Next

    '    Return Bonificacion

    'End Function

#End Region

#Region "Guardar Localmente los AbonosCDT"


    Private Function FI06(ByVal strAsociado As String) As DataTable

        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        Return oSap.Read_ZBAPI_EXTFACTABONOS(strAsociado)

    End Function

    Private Sub GuardarAbonosCdtDetalle(ByVal strAsociado As String)
        'Insertar en la nueva tabla de AbonosCDT
        Dim odrArticulo As DataRow
        'Guardar todas las formas de pago
        For Each odrArticulo In oAbonoCreditoDirecto.FormasDePago.Tables(0).Rows
            oAbonoCreditoDirectoMgr.InsertAbonoCDTDetalles(strAsociado, odrArticulo("IDFormaPago"), odrArticulo("IDBanco"), odrArticulo("Monto"), odrArticulo("IDTIPOTARJETA"), odrArticulo("NumTarjeta"), odrArticulo("NumAutorizacion"), odrArticulo("VALECAJAID"))
        Next

    End Sub


    Private Sub GuardarAbonosCDT(ByVal strTienda As String, ByVal strCliente As String, ByVal dblImporte As Double, _
                                 ByVal strFacturaFI As String, ByVal strClaCobr As String, ByVal strBanco As String, _
                                ByVal strFactDpPro As String, ByVal strDocnumFB01 As String, ByVal strDocnumFB05 As String)

        oAbonoCreditoDirectoMgr.InsertAbonoCDT(strTienda, strCliente, dblImporte, strFacturaFI, strClaCobr, strBanco, strFactDpPro, strDocnumFB01, strDocnumFB05)
    End Sub

    Private Function GetFormaPago() As String
        Dim firstView As DataView = New DataView(oAbonoCreditoDirecto.FormasDePago.Tables(0))
        firstView.Sort = "Monto DESC"

        If firstView(0)("IDFormaPago") = "EFEC" Then
            Return "EFECTIVO"
        Else
            If firstView(0)("IDFormaPago") = "TACR" Or firstView(0)("IDFormaPago") = "TADB" Then
                If firstView(0)("IDBanco") = "T1" Then
                    Return "TARJETA 1"
                Else
                    If firstView(0)("IDBanco") = "T2" Then
                        Return "TARJETA 2"
                    Else
                        If firstView(0)("IDBanco") = "T3" Then
                            Return "TARJETA 3"
                        End If
                    End If
                End If
            Else
                If firstView(0)("IDFormaPago") = "VCJA" Then
                    Return "VCJA"
                End If
            End If
        End If

        Return String.Empty
    End Function

    Private Sub InsertToReport(ByVal strAsociado As String)
        Dim intAbonoId As Integer

        '''Abono General
        intAbonoId = oAbonoCreditoDirectoMgr.InsertAbonoCDTGeneral(strAsociado, Me.txtTotalAbono.Value, Me.EBAsociado.Text.Trim)
        '''Facturas
        Dim intFactDpPro As String
        For Each odrArticulo As DataRow In oAbonoCreditoDirecto.NewFacturas.Rows
            If odrArticulo("Abono") <> 0 Then

                If odrArticulo("DPFactura") <> 0 Then
                    intFactDpPro = odrArticulo("DPFactura")
                Else
                    'Busco en la La Tabla Factura
                    intFactDpPro = oAbonoCreditoDirectoMgr.GetSelectFolioFacturaDPBySDSAP(oAbonoCreditoDirecto.AsociadoID, odrArticulo("FolioFactura"))
                End If

                intFactDpPro = IIf(intFactDpPro = "", 0, intFactDpPro)

                oAbonoCreditoDirectoMgr.InsertAbonoCDT(intAbonoId, intFactDpPro, odrArticulo("FolioFactura"), odrArticulo("Saldo"), odrArticulo("Abono"))


                ''''Actualizo Saldo de Factura
                Dim oFacturaMgr As New FacturaManager(oAppContext)
                Dim oFactura As Factura
                oFactura = oFacturaMgr.Create
                oFactura.FacturaID = odrArticulo("FacturaID")
                oFactura.Saldo = odrArticulo("Saldo") - odrArticulo("Abono")
                oFacturaMgr.UpdateSaldo(oFactura)
                ''''Actualizo Saldo de Factura

            End If
        Next
        '''Formas Pago
        For Each odrArticulo As DataRow In oAbonoCreditoDirecto.FormasDePago.Tables(0).Rows
            oAbonoCreditoDirectoMgr.InsertAbonoCDTDetalles(intAbonoId, odrArticulo("IDFormaPago"), odrArticulo("Monto"))
        Next

    End Sub

#End Region

    Private Sub EBIDAsociado_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBIDAsociado.GotFocus

        If oConfigCierreFI.UsarHuellas = True AndAlso Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False Then

            Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.True

        End If

    End Sub

    Private Sub EBIDAsociado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBIDAsociado.LostFocus

        If bolSalir = False Then

            If oConfigCierreFI.UsarHuellas = True AndAlso Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.True Then

                Me.UiCommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False

            End If

        End If

    End Sub

End Class
