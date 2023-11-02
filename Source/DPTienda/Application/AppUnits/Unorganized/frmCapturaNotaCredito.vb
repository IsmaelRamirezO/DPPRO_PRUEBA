
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralTalla
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC
Imports Janus.Windows.GridEX

Public Class frmCapturaNotaCredito
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        CrearTablaCambioTallas()

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
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents LblTallas As System.Windows.Forms.Label
    Friend WithEvents ebCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents uibtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents uibtnQuitar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebCosto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ebFacturaCod As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents CCmbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents uibtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridNotaCreditoDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ebCaja As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents prgProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ebTalla As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ebCodSAP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodSAP1 As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaNotaCredito))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.GridNotaCreditoDetalle = New Janus.Windows.GridEX.GridEX()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.uibtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.ebCodSAP1 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ebTalla = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.prgProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ebCaja = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ebFacturaCod = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.LblTallas = New System.Windows.Forms.Label()
        Me.ebCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.uibtnQuitar = New Janus.Windows.EditControls.UIButton()
        Me.uibtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.ebCosto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CCmbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ebCodSAP = New Janus.Windows.GridEX.EditControls.EditBox()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.GridNotaCreditoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.GridNotaCreditoDetalle)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Detalle Nota Crédito"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar2.Location = New System.Drawing.Point(328, 0)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(520, 368)
        Me.ExplorerBar2.TabIndex = 1
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'GridNotaCreditoDetalle
        '
        Me.GridNotaCreditoDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridNotaCreditoDetalle.BackColor = System.Drawing.Color.White
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GridNotaCreditoDetalle.DesignTimeLayout = GridEXLayout1
        Me.GridNotaCreditoDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridNotaCreditoDetalle.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.GridNotaCreditoDetalle.GroupByBoxVisible = False
        Me.GridNotaCreditoDetalle.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridNotaCreditoDetalle.Location = New System.Drawing.Point(8, 40)
        Me.GridNotaCreditoDetalle.Name = "GridNotaCreditoDetalle"
        Me.GridNotaCreditoDetalle.Size = New System.Drawing.Size(496, 264)
        Me.GridNotaCreditoDetalle.TabIndex = 0
        Me.GridNotaCreditoDetalle.TabStop = False
        Me.GridNotaCreditoDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ebCodSAP)
        Me.ExplorerBar1.Controls.Add(Me.ebCodSAP1)
        Me.ExplorerBar1.Controls.Add(Me.uibtnSalir)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.ebTalla)
        Me.ExplorerBar1.Controls.Add(Me.prgProgressBar1)
        Me.ExplorerBar1.Controls.Add(Me.ebCaja)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.ebFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.ebFacturaCod)
        Me.ExplorerBar1.Controls.Add(Me.LblTallas)
        Me.ExplorerBar1.Controls.Add(Me.ebCantidad)
        Me.ExplorerBar1.Controls.Add(Me.uibtnQuitar)
        Me.ExplorerBar1.Controls.Add(Me.uibtnAgregar)
        Me.ExplorerBar1.Controls.Add(Me.ebCosto)
        Me.ExplorerBar1.Controls.Add(Me.ebDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigo)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Captura de Notas Crédito"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(328, 368)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'uibtnSalir
        '
        Me.uibtnSalir.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnSalir.Location = New System.Drawing.Point(224, 312)
        Me.uibtnSalir.Name = "uibtnSalir"
        Me.uibtnSalir.Size = New System.Drawing.Size(96, 28)
        Me.uibtnSalir.TabIndex = 9
        Me.uibtnSalir.Text = "Salir"
        Me.uibtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebCodSAP1
        '
        Me.ebCodSAP1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodSAP1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodSAP1.ButtonImage = CType(resources.GetObject("ebCodSAP1.ButtonImage"), System.Drawing.Image)
        Me.ebCodSAP1.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodSAP1.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebCodSAP1.Location = New System.Drawing.Point(208, 120)
        Me.ebCodSAP1.MaxLength = 20
        Me.ebCodSAP1.Name = "ebCodSAP1"
        Me.ebCodSAP1.Size = New System.Drawing.Size(120, 23)
        Me.ebCodSAP1.TabIndex = 2
        Me.ebCodSAP1.Text = "0"
        Me.ebCodSAP1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodSAP1.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.ebCodSAP1.Visible = False
        Me.ebCodSAP1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Referencia:"
        '
        'ebTalla
        '
        Me.ebTalla.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTalla.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTalla.Location = New System.Drawing.Point(274, 40)
        Me.ebTalla.Name = "ebTalla"
        Me.ebTalla.Size = New System.Drawing.Size(56, 23)
        Me.ebTalla.TabIndex = 4
        Me.ebTalla.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTalla.Visible = False
        Me.ebTalla.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'prgProgressBar1
        '
        Me.prgProgressBar1.Location = New System.Drawing.Point(16, 296)
        Me.prgProgressBar1.Name = "prgProgressBar1"
        Me.prgProgressBar1.Size = New System.Drawing.Size(304, 3)
        Me.prgProgressBar1.TabIndex = 25
        '
        'ebCaja
        '
        Me.ebCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCaja.ButtonImage = CType(resources.GetObject("ebCaja.ButtonImage"), System.Drawing.Image)
        Me.ebCaja.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCaja.Location = New System.Drawing.Point(104, 39)
        Me.ebCaja.MaxLength = 2
        Me.ebCaja.Name = "ebCaja"
        Me.ebCaja.Size = New System.Drawing.Size(74, 23)
        Me.ebCaja.TabIndex = 0
        Me.ebCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 23)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Fecha:"
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.SystemColors.Info
        Me.ebFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecha.Location = New System.Drawing.Point(104, 120)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(98, 22)
        Me.ebFecha.TabIndex = 18
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 23)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Caja:"
        '
        'ebFacturaCod
        '
        Me.ebFacturaCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFacturaCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFacturaCod.ButtonImage = CType(resources.GetObject("ebFacturaCod.ButtonImage"), System.Drawing.Image)
        Me.ebFacturaCod.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebFacturaCod.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFacturaCod.Location = New System.Drawing.Point(104, 66)
        Me.ebFacturaCod.MaxLength = 6
        Me.ebFacturaCod.Name = "ebFacturaCod"
        Me.ebFacturaCod.Size = New System.Drawing.Size(120, 23)
        Me.ebFacturaCod.TabIndex = 1
        Me.ebFacturaCod.Text = "0"
        Me.ebFacturaCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFacturaCod.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFacturaCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'LblTallas
        '
        Me.LblTallas.BackColor = System.Drawing.Color.Transparent
        Me.LblTallas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTallas.Location = New System.Drawing.Point(14, 197)
        Me.LblTallas.Name = "LblTallas"
        Me.LblTallas.Size = New System.Drawing.Size(298, 16)
        Me.LblTallas.TabIndex = 15
        Me.LblTallas.Text = "Tallas:"
        '
        'ebCantidad
        '
        Me.ebCantidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCantidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCantidad.Location = New System.Drawing.Point(104, 221)
        Me.ebCantidad.MaxLength = 7
        Me.ebCantidad.Name = "ebCantidad"
        Me.ebCantidad.Size = New System.Drawing.Size(56, 23)
        Me.ebCantidad.TabIndex = 5
        Me.ebCantidad.Text = "0"
        Me.ebCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.ebCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uibtnQuitar
        '
        Me.uibtnQuitar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnQuitar.Location = New System.Drawing.Point(120, 312)
        Me.uibtnQuitar.Name = "uibtnQuitar"
        Me.uibtnQuitar.Size = New System.Drawing.Size(96, 28)
        Me.uibtnQuitar.TabIndex = 8
        Me.uibtnQuitar.Text = "Quitar"
        Me.uibtnQuitar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnAgregar
        '
        Me.uibtnAgregar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnAgregar.Location = New System.Drawing.Point(16, 312)
        Me.uibtnAgregar.Name = "uibtnAgregar"
        Me.uibtnAgregar.Size = New System.Drawing.Size(96, 28)
        Me.uibtnAgregar.TabIndex = 7
        Me.uibtnAgregar.Text = "Agregar"
        Me.uibtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebCosto
        '
        Me.ebCosto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCosto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCosto.BackColor = System.Drawing.Color.White
        Me.ebCosto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCosto.Location = New System.Drawing.Point(224, 221)
        Me.ebCosto.Name = "ebCosto"
        Me.ebCosto.Size = New System.Drawing.Size(88, 22)
        Me.ebCosto.TabIndex = 6
        Me.ebCosto.TabStop = False
        Me.ebCosto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCosto.Visible = False
        Me.ebCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDescripcion
        '
        Me.ebDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.BackColor = System.Drawing.SystemColors.Info
        Me.ebDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescripcion.Location = New System.Drawing.Point(104, 172)
        Me.ebDescripcion.Name = "ebDescripcion"
        Me.ebDescripcion.ReadOnly = True
        Me.ebDescripcion.Size = New System.Drawing.Size(216, 22)
        Me.ebDescripcion.TabIndex = 19
        Me.ebDescripcion.TabStop = False
        Me.ebDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigo
        '
        Me.ebCodigo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigo.ButtonImage = CType(resources.GetObject("ebCodigo.ButtonImage"), System.Drawing.Image)
        Me.ebCodigo.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigo.Location = New System.Drawing.Point(104, 146)
        Me.ebCodigo.MaxLength = 20
        Me.ebCodigo.Name = "ebCodigo"
        Me.ebCodigo.Size = New System.Drawing.Size(216, 22)
        Me.ebCodigo.TabIndex = 3
        Me.ebCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 23)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Factura PRO:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(168, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 23)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Costo:"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 23)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Cantidad:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(184, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 23)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Talla:"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 23)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Descripción:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 23)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Codigo:"
        '
        'CCmbFecha
        '
        '
        '
        '
        Me.CCmbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.CCmbFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CCmbFecha.Location = New System.Drawing.Point(87, 225)
        Me.CCmbFecha.Name = "CCmbFecha"
        Me.CCmbFecha.Size = New System.Drawing.Size(136, 22)
        Me.CCmbFecha.TabIndex = 22
        Me.CCmbFecha.Value = New Date(2005, 2, 19, 0, 0, 0, 0)
        Me.CCmbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'ebCodSAP
        '
        Me.ebCodSAP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodSAP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodSAP.ButtonImage = CType(resources.GetObject("ebCodSAP.ButtonImage"), System.Drawing.Image)
        Me.ebCodSAP.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodSAP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodSAP.Location = New System.Drawing.Point(104, 95)
        Me.ebCodSAP.MaxLength = 20
        Me.ebCodSAP.Name = "ebCodSAP"
        Me.ebCodSAP.Size = New System.Drawing.Size(120, 22)
        Me.ebCodSAP.TabIndex = 29
        Me.ebCodSAP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodSAP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmCapturaNotaCredito
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(842, 367)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaNotaCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura Notas Crédito"
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.GridNotaCreditoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Variables Miembros"

    Private oNotaCredito As NotaCredito

    Private oNotasCreditoMgr As NotasCreditoManager

    Private oArticulo As Articulo

    Private oCatalogoArticulosMgr As CatalogoArticuloManager

    Private oCaja As Caja

    Private oCatalogoCajasMgr As CatalogoCajaManager

    Private oFactura As Factura

    Private oFacturasMgr As FacturaManager

    Private odsCatalogoCorridas As DataSet

    Private oAjusteMGr As AjusteGeneralTallaManager

    Public strTablaTmp As String = "" '"NotaCreditoDetalleTmp" & oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & oAppContext.Security.CurrentUser.ID

#End Region


#Region "Propiedades [WriteOnly]"

    Private intNotaCreditoID As Integer


    Public WriteOnly Property NotaCreditoID() As Integer

        Set(ByVal Valor As Integer)

            intNotaCreditoID = Valor

        End Set

    End Property


    Private strClienteID As String

    Public Property ClienteID() As String
        Get
            Return strClienteID
        End Get

        Set(ByVal Valor As String)

            strClienteID = Valor

        End Set

    End Property



    Private strTipoVentaID As String

    Public WriteOnly Property TipoVentaID() As String

        Set(ByVal Valor As String)

            strTipoVentaID = Valor

        End Set

    End Property

    Private dtDetalleNC As DataTable

    Public Property DetalleNC() As DataTable
        Get
            Return dtDetalleNC
        End Get

        Set(ByVal Valor As DataTable)

            dtDetalleNC = Valor

        End Set

    End Property

    Private strAsociado As String

    Public Property Asociado() As String
        Get
            Return strAsociado
        End Get

        Set(ByVal Valor As String)

            strAsociado = Valor

        End Set

    End Property


    Private strFactura As String

    Public Property Factura() As String
        Get
            Return strFactura
        End Get

        Set(ByVal Valor As String)

            strFactura = Valor

        End Set

    End Property

    Private intFacturaID As Integer

    Public Property FacturaID() As Integer
        Get
            Return intFacturaID
        End Get

        Set(ByVal Valor As Integer)

            intFacturaID = Valor

        End Set

    End Property


    Private strDOCFI As String

    Public Property DOCFI() As String
        Get
            Return strDOCFI
        End Get

        Set(ByVal Valor As String)

            strDOCFI = Valor

        End Set

    End Property

    Private strDOCSD As String

    Public Property DOCSD() As String
        Get
            Return strDOCSD
        End Get

        Set(ByVal Valor As String)

            strDOCSD = Valor

        End Set

    End Property

    Private strE_RESULT As String

    Public Property E_RESULT() As String
        Get
            Return strE_RESULT
        End Get

        Set(ByVal Valor As String)

            strE_RESULT = Valor

        End Set

    End Property


    Private m_chrTipoVentaCredito As Char

    Public Property TipoVentaCredito() As Char
        Get
            Return m_chrTipoVentaCredito
        End Get
        Set(ByVal Value As Char)
            m_chrTipoVentaCredito = Value
        End Set
    End Property

    Private m_dtTallas As DataTable

    Public Property CambioTallas() As DataTable
        Get
            Return m_dtTallas
        End Get
        Set(ByVal Value As DataTable)
            m_dtTallas = Value
        End Set
    End Property

#End Region


#Region "Métodos Privados"

    Private Sub Sm_Inicializar()

        oNotasCreditoMgr = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

        oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)

        oCatalogoCajasMgr = New CatalogoCajaManager(oAppContext)

        oFacturasMgr = New FacturaManager(oAppContext)

        oAjusteMGr = New AjusteGeneralTallaManager(oAppContext)

        odsCatalogoCorridas = oNotasCreditoMgr.ExtraerCatalogoCorridas

        Sm_ActualizarGRID()

    End Sub

    Private Sub CrearTablaCambioTallas()

        Me.CambioTallas = New DataTable("CambioTallas")
        Me.CambioTallas.Columns.Add("CodArticulo")
        Me.CambioTallas.Columns.Add("TallaReal")
        Me.CambioTallas.Columns.Add("TallaFactura")
        Me.CambioTallas.Columns.Add("Descripcion")
        Me.CambioTallas.Columns.Add("FacturaSAP")
        Me.CambioTallas.Columns.Add("Cantidad")
        Me.CambioTallas.Columns.Add("FoliosAjustes")
        Me.CambioTallas.Columns.Add("PosGrid")

    End Sub


    Private Sub Sm_Finalizar()

        oNotaCredito = Nothing

        oNotasCreditoMgr = Nothing

        oArticulo = Nothing

        oCatalogoArticulosMgr = Nothing

        oCaja = Nothing

        oFacturasMgr = Nothing

        oFactura = Nothing

        oCatalogoCajasMgr = Nothing

    End Sub



    Private Function Fm_bolTxtValidar() As Boolean

        Dim CambioTalla As Boolean = False

        If (oCaja Is Nothing) Then

            MsgBox("No ha sido seleccionado una Caja.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCaja.Focus()

            Exit Function

        End If


        If (oFactura Is Nothing) Then

            MsgBox("No ha sido seleccionado una Factura.", MsgBoxStyle.Exclamation, "DPTienda")
            ebFacturaCod.Focus()

            Exit Function

        End If


        If (oFactura.StatusFactura = "CAN") Then

            MsgBox("La Factura se encuentra Cancelada.", MsgBoxStyle.Exclamation, "DPTienda")
            ebFacturaCod.Focus()

            Exit Function

        End If


        If (oNotasCreditoMgr.ValidarFactura(oFactura.FacturaID, oCaja.ID, strClienteID, oConfigCierreFI.UsarHuellas) = False) Then

            MsgBox("Algunos datos de la Factura no son correctos [Cliente, TipoVenta, Folio, Caja].", MsgBoxStyle.Exclamation, "DPTienda")
            ebFacturaCod.Focus()

            Exit Function

        End If


        'Validar que la Factura.TipoDevolucion se igual al seleccionado por el Usuario.

        If (oNotasCreditoMgr.ValidarFacturaTipoVenta(oFactura.FacturaID, strTipoVentaID, strTablaTmp) = False) Then

            MsgBox("El Tipo de Venta de la Factura no es correcto.", MsgBoxStyle.Exclamation, "DPTienda")
            ebFacturaCod.Focus()

            Exit Function

        End If


        'Validar que la Todos los Artículos pertenezcan a una sola Factura.

        If (strTipoVentaID = "V") Then

            If (oNotasCreditoMgr.ValidarFacturaDPVale(oFactura.FacturaID, strTablaTmp) = False) Then

                MsgBox("La Factura es distinta a la capturada previamente.", MsgBoxStyle.Exclamation, "DPTienda")
                ebFacturaCod.Focus()

                Exit Function

            End If

        End If


        If (oArticulo Is Nothing) Then

            MsgBox("No ha sido seleccionado un Artículo.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCodigo.Focus()

            Exit Function

        End If

        If (ebCantidad.Text <= 0) Then

            MsgBox("La Cantidad debe ser Mayor a Cero.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCantidad.Focus()

            Exit Function

        End If

        Dim drTempGrid() As DataRow
        Dim oRowCT As DataRow
        Dim TotalCant As Integer = 0

        oRowCT = ValidaArticuloAgregado(oArticulo.CodArticulo, Me.ebTalla.Text, "TallaReal")
        If oRowCT Is Nothing Then
            drTempGrid = oNotasCreditoMgr.ActualizarDataSet("[NotaCreditoDetalleTmpSel]", strTablaTmp).Tables(strTablaTmp).Select("FolioReferencia=" & oFactura.FolioFactura & " And CodArticulo ='" & oArticulo.CodArticulo & "' and Numero = '" & ebTalla.Text & "'")

            If drTempGrid.Length = 0 Then
                TotalCant += CInt(Me.ebCantidad.Text)
                drTempGrid = Nothing
            Else
                TotalCant = CType(drTempGrid(0)!Cantidad, Integer) + CInt(Me.ebCantidad.Text) - SumaCantCodFactura(oArticulo.CodArticulo, ebTalla.Text)
                drTempGrid = Nothing
            End If
            oRowCT = Nothing
        Else
            TotalCant = oRowCT!Cantidad + CInt(Me.ebCantidad.Text)
            oRowCT = Nothing
        End If
        'If (oNotasCreditoMgr.ValidarExistenciaArticulo(oArticulo.CodArticulo, CType(ebTalla.Text, Decimal), oFactura.FacturaID) = False) Then
        '---------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (02.09.2016): COMENTADO POR QUE SE DEBE VALIDAR LOS CAMBIOS DE TALLA POR REFERENCIA (PENDIENE MODIFICAR AJUSTES POR REFERENCIA Y NO FOLIO SAP)
        '---------------------------------------------------------------------------------------------------------------------------------------------------
        'If oAjusteMGr.ValidaExistenciasCambiosTalla(oFactura.FolioSAP, Trim(ebTalla.Text), oArticulo.CodArticulo, TotalCant) = True Then
        If (oNotasCreditoMgr.ValidarExistenciaArticulo(oArticulo.CodArticulo, ebTalla.Text, oFactura.FacturaID) = False) Then

            Dim TallaE As String

            TallaE = oNotasCreditoMgr.ValidarCambiosTalla(oFactura.FolioSAP, Trim(ebTalla.Text), oArticulo.CodArticulo, CInt(Me.ebCantidad.Text))

            If TallaE = "" Then

                MsgBox("El Artículo No Existe en la Factura " & oFactura.FolioSAP & ".", MsgBoxStyle.Exclamation, "DPTienda")
                ebTalla.Focus()

                Exit Function

            Else

                Dim strRes() As String
                Dim oRowArt As DataRow
                Dim PosInGrid As Integer

                strRes = TallaE.Split("°")
                TallaE = Trim(strRes(0))

                oRowArt = ValidaArticuloAgregado(oArticulo.CodArticulo, TallaE, "TallaFactura")

                If oRowArt Is Nothing Then

                    PosInGrid = ValidaArtInGrid(oArticulo.CodArticulo, TallaE)
                    'For Each oRow As DataRow In dsCambiosTalla.Tables(0).Rows

                    If (oNotasCreditoMgr.ValidarExistenciaArticulo(oArticulo.CodArticulo, TallaE, oFactura.FacturaID) = True) Then
Agrega:
                        Dim oRowTallas As DataRow = Me.CambioTallas.NewRow

                        oRowTallas("CodArticulo") = oArticulo.CodArticulo
                        oRowTallas("Descripcion") = oArticulo.Descripcion
                        oRowTallas("TallaReal") = Trim(ebTalla.Text)
                        oRowTallas("TallaFactura") = TallaE
                        oRowTallas("Cantidad") = Trim(Me.ebCantidad.Text)
                        oRowTallas("FacturaSAP") = oFactura.FolioSAP
                        oRowTallas("FoliosAjustes") = strRes(1) & "°" & strRes(2)
                        If oRowArt Is Nothing Then
                            If PosInGrid = -1 Then
                                If Me.GridNotaCreditoDetalle.RowCount = 0 Then
                                    oRowTallas("PosGrid") = 0
                                Else
                                    oRowTallas("PosGrid") = Me.GridNotaCreditoDetalle.RowCount
                                End If
                            Else
                                oRowTallas("PosGrid") = PosInGrid
                            End If
                        Else
                            oRowTallas("PosGrid") = oRowArt("PosGrid")
                        End If

                        Me.CambioTallas.Rows.Add(oRowTallas)

                        'Exit For

                    End If

                    'Next

                Else

                    If CInt(oRowArt("TallaReal")) <> CInt(Me.ebTalla.Text) Then

                        GoTo Agrega

                    End If

                    Dim strRevCant As String()

                    If CStr(oRowArt!FoliosAjustes) <> "" Then
                        strRevCant = CStr(oRowArt("FoliosAjustes")).Split("°")
                        oRowArt("FoliosAjustes") = strRevCant(0) & "_" & strRes(1) & "°" & strRevCant(1) & "_" & strRes(2)
                    Else
                        oRowArt("FoliosAjustes") = strRes(1) & "°" & strRes(2)
                    End If
                    oRowArt("Cantidad") = oRowArt("Cantidad") + CInt(Me.ebCantidad.Text)
                    Me.CambioTallas.AcceptChanges()

                End If

                ebTalla.Text = TallaE
                CambioTalla = True

            End If

            'Else

            '    MsgBox("No hay existencias suficientes para el codigo " & Me.ebCodigo.Text & " en la talla " & Me.ebTalla.Text & " en la factura " & oFactura.FolioSAP, MsgBoxStyle.Exclamation, "Dportenis Pro")
            '    Exit Function

        End If

        'Else

        '    'MsgBox("El Articulo No Existe en la Factura " & oFactura.FolioSAP & ".", MsgBoxStyle.Exclamation, "Dportenis Pro")
        '    Me.ebTalla.Focus()

        '    Exit Function

        'End If

        Dim drDataRow() As DataRow

        drDataRow = oNotasCreditoMgr.ActualizarDataSet("[NotaCreditoDetalleTmpSel]", strTablaTmp).Tables(strTablaTmp).Select("FolioReferencia=" & ebFacturaCod.Text & " And CodArticulo ='" & oArticulo.CodArticulo & "' and Numero = '" & ebTalla.Text & "'")

        Dim intTotalporArticulo As Integer

        If (drDataRow.Length = 0) Then

            intTotalporArticulo += ebCantidad.Text
            drDataRow = Nothing

        Else

            intTotalporArticulo = CType(drDataRow(0).Item("Cantidad"), Integer) + ebCantidad.Text
            drDataRow = Nothing

        End If

        'If (oNotasCreditoMgr.ValidarCantidad(intTotalporArticulo, oArticulo.CodArticulo, ebTalla.Text, oFactura.FacturaID) = False) Then

        '    MsgBox("El Artículo no cuenta con Existencias suficientes.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebCantidad.Focus()
        '    Sm_TxtLimpiar()

        '    Exit Function

        'End If

        If Not dtTemporal Is Nothing Then
            Dim oView As New DataView(dtTemporal, "CodArticulo = '" & oArticulo.CodArticulo & "' and Numero = '" & ebTalla.Text & "'", "CodArticulo", DataViewRowState.CurrentRows)

            If oView.Count > 0 Then
                '   intTotalporArticulo += oView(0)("Cantidad")
            End If
        End If

        If (oNotasCreditoMgr.ValidarCantidadDevueltaArticulo(oFactura, oArticulo.CodArticulo, ebTalla.Text, intTotalporArticulo) _
            = False AndAlso CambioTalla = False) Then

            MsgBox("El Artículo no cuenta con Existencias suficientes.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCantidad.Focus()

            Exit Function

        End If


        Return True

    End Function

    Private Function SumaCantCodFactura(ByVal CodArticulo As String, ByVal Talla As String) As Integer

        Dim Total As Integer = 0

        For Each oRow As DataRow In Me.CambioTallas.Rows

            If UCase(Trim(oRow!CodArticulo)) = UCase(Trim(CodArticulo)) _
            And UCase(Trim(oRow!TallaFactura)) = UCase(Trim(Talla)) Then

                Total += oRow!Cantidad

            End If

        Next

        Return Total

    End Function

    'TODO 'dTNuevo
    Dim dtTemporal As DataTable

    Private Sub Sm_ActualizarGRID()

        GridNotaCreditoDetalle.DataSource = Nothing
        dtTemporal = oNotasCreditoMgr.ActualizarDataSet("[NotaCreditoDetalleTmpSel]", strTablaTmp).Tables(strTablaTmp)
        GridNotaCreditoDetalle.DataSource = dtTemporal

    End Sub


    Private Sub Sm_TxtLimpiar()

        ebCodigo.Text = String.Empty

        ebDescripcion.Text = String.Empty

        ebTalla.Text = 0

        ebCantidad.Text = 0

        ebCosto.Text = String.Empty

        'lblDescuento.Text = "Descuento 0.00%"

        ebFacturaCod.Text = 0

        ebCodSAP1.Text = String.Empty

        ebFecha.Text = String.Empty

        ebCaja.Text = String.Empty

        ebCodigo.Focus()

    End Sub

    Private Function ValidaArticuloAgregado(ByVal Codigo As String, ByVal Talla As String, ByVal Campo As String) As DataRow

        For Each oRow As DataRow In Me.CambioTallas.Rows

            If UCase(Trim(oRow("CodArticulo"))) = UCase(Trim(Codigo)) AndAlso UCase(Trim(oRow(Campo))) = UCase(Trim(Talla)) Then

                Return oRow

            End If

        Next

        Return Nothing

    End Function

    Private Function ValidaArtInGrid(ByVal Codigo As String, ByVal Talla As String) As Integer

        Dim i As Integer = 0

        Do While i < Me.GridNotaCreditoDetalle.RowCount

            Dim oRowGrid As GridEXRow
            Dim oRow As DataRowView

            oRowGrid = GridNotaCreditoDetalle.GetRow(i)
            oRow = CType(oRowGrid.DataRow, DataRowView)
            If UCase(Trim(oRow!CodArticulo)) = UCase(Trim(Codigo)) AndAlso UCase(Trim(oRow!Numero)) = UCase(Trim(Talla)) Then

                Return i

            End If
            i += 1

        Loop

        Return -1

    End Function

    Private Sub Sm_BuscarArticulo(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        Dim odrFiltro() As DataRow

        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            'oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView
            'Dim codigo As String = ebFacturaCod.Text
            'If ebFacturaCod.Text = "" Or Integer.Parse(ebFacturaCod.Text) = 0 Then
            '    Dim dsCodigo As DataSet
            '    dsCodigo = Me.oNotasCreditoMgr.FolioProGet(ebCodSAP.Text)
            '    If dsCodigo.Tables(0).Rows.Count > 0 Then
            '        codigo = dsCodigo.Tables(0).Rows(0).Item("FolioFactura")
            '    End If

            'End If
            oOpenRecordDlg.CurrentView = New FacturaCorridaOpenRecordDialogView(oFactura.FolioFactura, ebCaja.Text)

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Dim strArticulo As String
                Dim strNumero As String

                strArticulo = oOpenRecordDlg.Record.Item("CodArticulo")
                strNumero = oOpenRecordDlg.Record.Item("Numero")
                On Error Resume Next

                oArticulo = Nothing
                oArticulo = oCatalogoArticulosMgr.Load(strArticulo)
                ebTalla.Text = strNumero

                ebCodigo.Text = oArticulo.CodArticulo
                ebDescripcion.Text = oArticulo.Descripcion

                'Articulo Tallas :
                odrFiltro = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & oArticulo.CodCorrida & "'")

                If odrFiltro(0).Item("NumInicio") = 0 Then
                    LblTallas.Text = "Tallas:          Del U  Al  XXL"
                Else
                    LblTallas.Text = "Tallas:          Del " & Format(odrFiltro(0).Item("NumInicio"), "##") & "  Al  " & Format(odrFiltro(0).Item("NumFin"), "##")
                End If

                ebCosto.Text = 0.0
                ebCantidad.Value = 1

            End If

        Else

            On Error Resume Next

            oArticulo = Nothing
            oArticulo = oCatalogoArticulosMgr.Load(ebCodigo.Text.Trim)

            If (oArticulo Is Nothing) Then

                MsgBox("El Artículo no ha sido encontrado.", MsgBoxStyle.Exclamation, "DPTienda")
                'Sm_TxtLimpiar()

                Exit Sub

            End If

            ebCodigo.Text = oArticulo.CodArticulo
            ebDescripcion.Text = oArticulo.Descripcion

            'Articulo Tallas :
            odrFiltro = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & oArticulo.CodCorrida & "'")

            If odrFiltro(0).Item("NumInicio") = 0 Then
                LblTallas.Text = "Tallas:          Del U  Al  XXL"
            Else
                LblTallas.Text = "Tallas:          Del " & Format(odrFiltro(0).Item("NumInicio"), "##") & "  Al  " & Format(odrFiltro(0).Item("NumFin"), "##")
            End If

        End If

        odrFiltro = Nothing

    End Sub



    Private Sub Sm_BuscarCaja(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)


        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoCajaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                oCaja = Nothing
                oCaja = oCatalogoCajasMgr.Load(oOpenRecordDlg.Record.Item("CodCaja"))

                ebCaja.Text = oCaja.ID

                'ebFacturaCod.Focus()

            End If

        Else

            oCaja = Nothing

            oCaja = oCatalogoCajasMgr.Load(ebCaja.Text.Trim)

            If (oCaja Is Nothing) Then

                MessageBox.Show("La Caja no ha sido encontrada.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ebCaja.Focus()

                Exit Sub

            End If

            ebCaja.Text = oCaja.ID

            'ebFacturaCod.Focus()

        End If

    End Sub

    Private Sub BloquearCampos(ByVal bBloq As Boolean)

        If bBloq Then
            Me.ebCodigo.Text = ""
            Me.ebDescripcion.Text = ""
            Me.ebTalla.Text = ""
            Me.ebCantidad.Value = 0
        End If
        Me.ebCodigo.ReadOnly = bBloq
        Me.ebTalla.ReadOnly = bBloq
        Me.ebCantidad.ReadOnly = bBloq

    End Sub

    Private Sub Sm_BuscarFactura(ByVal tipoFolio As String, Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        '<Validacón>

        BloquearCampos(False)

        If (oCaja Is Nothing) Then

            MsgBox("No ha sido seleccionada un Código de Caja.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If

        '<Validación>


        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            Dim oFacturaOpenRecordDialogView As New FacturaOpenRecordDialogView
            oFacturaOpenRecordDialogView.TipoVenta = strTipoVentaID

            oOpenRecordDlg.CurrentView = oFacturaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                oFactura = Nothing

                oFactura = oFacturasMgr.Create
                oFacturasMgr.LoadInto(oOpenRecordDlg.Record.Item("ID"), oFactura)
                strClienteID = oFactura.ClienteId
                If Not oFactura Is Nothing Then
                    If oFactura.CodCaja.Trim.ToUpper <> oAppContext.ApplicationConfiguration.NoCaja.Trim.ToUpper Then
                        MessageBox.Show("Esta factura solo es posible devolverla desde la caja " & oFactura.CodCaja, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        oFactura = oFacturasMgr.Create
                        BloquearCampos(True)
                        Exit Sub
                    End If
                End If

                With oFactura
                    If tipoFolio = "PRO" Then
                        ebFacturaCod.Text = .FolioFactura
                        ebCodSAP.Text = .Referencia
                    Else
                        ebCodSAP.Text = .Referencia
                        ebFacturaCod.Text = oFactura.FolioFactura
                    End If
                End With
                Me.ebCodigo.Focus()

                'oFactura = Nothing

                'oFactura = oFacturasMgr.Create
                'oFacturasMgr.LoadInto(oOpenRecordDlg.Record.Item("ID"), oFactura)

                'If E_RESULT = "Y" Then
                '    If Not Factura = oFactura.FolioSAP Then
                '        MsgBox("El Folio de la factura no coincide con la factura pendiente por grabar.", MsgBoxStyle.Information, Me.Text)
                '        ebFacturaCod.Text = "0"
                '        ebCodSAP.Text = "0"
                '        Exit Sub
                '    End If

                'End If

                'If Format(oFactura.Fecha, "dd/MM/yyyy") <> Format(Date.Now, "dd/MM/yyyy") Then

                '    If oFactura.Fecha.AddDays(30) < Today Then

                '        MessageBox.Show("No es posible hacer la devolucion de esta factura, el tiempo de vigencia ha expirado." & vbCrLf & _
                '        "Es necesario la autorizacion del auditor para continuar", "DPTienda", _
                '        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        oAppContext.Security.CloseImpersonatedSession()
                '        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria") = False Then
                '            If tipoFolio = "PRO" Then
                '                ebFacturaCod.Text = ""
                '                ebFacturaCod.Focus()
                '            Else
                '                ebCodSAP.Text = ""
                '                ebCodSAP.Focus()
                '            End If
                '        End If
                '        oAppContext.Security.CloseImpersonatedSession()

                '    Else

                '        Dim dvValidaFactura As New DataView(dtTemporal, "FolioReferencia = " & oFactura.FolioFactura, "FolioReferencia", DataViewRowState.CurrentRows)

                '        If dtTemporal.Rows.Count > 0 AndAlso dvValidaFactura.Count = 0 Then
                '            MessageBox.Show("Solo se permite una factura por nota de credito.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '            If tipoFolio = "PRO" Then
                '                ebFacturaCod.Focus()
                '            Else
                '                ebCodSAP.Focus()
                '            End If
                '        Else
                '            With oFactura
                '                If tipoFolio = "PRO" Then
                '                    ebFacturaCod.Text = .FolioFactura
                '                    ebCodSAP.Text = "0"
                '                Else
                '                    ebCodSAP.Text = .FolioSAP
                '                    ebFacturaCod.Text = "0"
                '                End If


                '                ebFecha.Text = .Fecha
                '                Me.FacturaID = .FacturaID

                '            End With
                '        End If

                '    End If

                'Else

                '    MessageBox.Show("No puede realizar notas de crédito de facturas del día, utilice la opción de Cancelar Factura", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    If tipoFolio = "PRO" Then
                '        ebFacturaCod.Focus()
                '    Else
                '        ebCodSAP.Focus()
                '    End If

                'End If

            End If

        Else

            On Error Resume Next

            oFactura = oFacturasMgr.Create
            If ebFacturaCod.Text = "" Or Integer.Parse(ebFacturaCod.Text) = 0 Then
                Dim dsCodigo As New DataSet
                dsCodigo = Me.oNotasCreditoMgr.FolioProGet(ebCodSAP.Text.PadLeft(10, "0"))
                If dsCodigo.Tables(0).Rows.Count > 0 Then
                    oFacturasMgr.Load(dsCodigo.Tables(0).Rows(0).Item("FolioFactura"), oCaja.ID, oFactura)
                End If
            Else
                oFacturasMgr.Load(ebFacturaCod.Text, oCaja.ID, oFactura)
            End If
            strClienteID = oFactura.ClienteId
            If E_RESULT = "Y" Then
                If Not Factura = oFactura.FolioSAP Then
                    MsgBox("El Folio de la factura no coincide con la factura pendiente por grabar.", MsgBoxStyle.Information, Me.Text)
                    ebFacturaCod.Text = "0"
                    ebCodSAP.Text = "0"
                    Exit Sub
                End If

            End If
            '<Validación>

            If (oFactura.FacturaID = 0) Then

                MessageBox.Show("El Num. de Caja y Folio Factura no coinciden.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'ebFacturaCod.Focus()

                Exit Sub

            ElseIf Not oFactura Is Nothing Then
                If oFactura.CodCaja.Trim.ToUpper <> oAppContext.ApplicationConfiguration.NoCaja.Trim.ToUpper Then
                    MessageBox.Show("Esta factura solo es posible devolverla desde la caja " & oFactura.CodCaja, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    oFactura = oFacturasMgr.Create
                    BloquearCampos(True)
                    Exit Sub
                End If
            End If

            '</Validación>            
            If Format(oFactura.Fecha, "dd/MM/yyyy") <> Format(Date.Now, "dd/MM/yyyy") Then

                If oFactura.Fecha.AddDays(30) < Today Then

                    MessageBox.Show("No es posible hacer la devolucion de esta factura, el tiempo de vigencia ha expirado." & vbCrLf & _
                    "Es necesario la autorizacion del auditor para continuar", "DPTienda", _
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    oAppContext.Security.CloseImpersonatedSession()
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.DevolverFactura") = False Then
                        'If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria") = False Then
                        If tipoFolio = "PRO" Then
                            ebFacturaCod.Text = ""
                            ebFacturaCod.Focus()
                        Else
                            ebCodSAP.Text = ""
                            ebCodSAP.Focus()
                        End If
                        Me.ebFecha.Text = ""
                        oFactura = Nothing
                        oAppContext.Security.CloseImpersonatedSession()
                    Else
                        oAppContext.Security.CloseImpersonatedSession()
                        GoTo Sigue
                    End If

                    'MessageBox.Show("No es posible hacer la devolucion de esta factura, el tiempo de vigencia ha expirado.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'If tipoFolio = "PRO" Then
                    '    ebFacturaCod.Focus()
                    'Else
                    '    ebCodSAP.Focus()
                    'End If

                Else
Sigue:
                    Dim dvValidaFactura As New DataView(dtTemporal, "FolioReferencia = " & oFactura.FolioFactura, "FolioReferencia", DataViewRowState.CurrentRows)

                    If dtTemporal.Rows.Count > 0 AndAlso dvValidaFactura.Count = 0 Then
                        MessageBox.Show("Solo se permite una factura por nota de credito.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If tipoFolio = "PRO" Then
                            ebFacturaCod.Text = ""
                            ebFacturaCod.Focus()
                        Else
                            ebCodSAP.Text = ""
                            ebCodSAP.Focus()
                        End If

                    Else
                        With oFactura
                            If tipoFolio = "PRO" Then
                                ebFacturaCod.Text = .FolioFactura
                                ebCodSAP.Text = .Referencia
                            Else
                                ebCodSAP.Text = .Referencia
                                ebFacturaCod.Text = .FolioFactura
                            End If


                            ebFecha.Text = .Fecha
                            Me.FacturaID = .FacturaID

                        End With
                    End If

                End If

            Else

                MessageBox.Show("No puede realizar notas de crédito de facturas del día, utilice la opción de Cancelar Factura", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If tipoFolio = "PRO" Then
                    ebFacturaCod.Focus()
                Else
                    ebCodSAP.Focus()
                End If

            End If

        End If


    End Sub



    Private Sub Sm_CapturarArticuloScanner(ByVal strCodArticulo As String)

        Dim strTalla As String

        If (Microsoft.VisualBasic.Len(strCodArticulo) < 2) Then

            MsgBox("La longitud del Código Artículo debe ser mayor a 1 Carater.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCodigo.Focus()

            Exit Sub

        End If


        'Código UPC :
        Dim upcMGR As New CatalogoUPCManager(oAppContext, oConfigCierreFI)
        If upcMGR.IsSkuOrMaterial(strCodArticulo) = "S" Then

            'End If
            'If (IsNumeric(strCodArticulo)) Then
            'Es un CodigoUPC
            Dim dsUPC As New DataTable

            dsUPC = oNotasCreditoMgr.GetUPCData(strCodArticulo.PadLeft(18, "0"))

            If dsUPC.Rows.Count > 0 Then

                ebCodigo.Text = dsUPC.Rows(0).Item("CodArticulo")
                ebTalla.Text = dsUPC.Rows(0).Item("Numero")
                ebCantidad.Text = 1

                Sm_BuscarArticulo()

                '<Validación>
                If (oArticulo Is Nothing) Then
                    ebCodigo.Focus()
                    Exit Sub
                End If
                '</Validación>

                Sm_ActualizarGRID()

                'ebFacturaCod.Text = 0
                'ebCaja.Text = 0
                ebCosto.Text = 0.0
                'ebFecha.Text = String.Empty
                ebCantidad.Focus()

                dsUPC.Dispose()
                dsUPC = Nothing

                Exit Sub

            Else

                MsgBox("Código UPC No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
                'e.Cancel = True
                'grdDetalle.Select(e.OldRange.r1, 0)
                dsUPC.Dispose()
                dsUPC = Nothing
                'grdDetalle.Focus()
                Exit Sub

            End If

        End If

        'dsUPC = Nothing


        'Código Scanner :

        strTalla = Microsoft.VisualBasic.Left(strCodArticulo.Trim, 2)

        If (IsNumeric(strTalla) = True) Then

            ebCodigo.Text = Microsoft.VisualBasic.Right(strCodArticulo, Microsoft.VisualBasic.Len(strCodArticulo) - 2)
            ebTalla.Text = CType(strTalla, Decimal) / 2
            ebCantidad.Text = 1

            Sm_BuscarArticulo()

            '<Validación>
            If (oArticulo Is Nothing) Then
                ebCodigo.Focus()
                Exit Sub
            End If
            '</Validación>

            Sm_ActualizarGRID()

            'ebFacturaCod.Text = 0
            'ebCaja.Text = 0
            ebCosto.Text = 0.0
            'ebFecha.Text = String.Empty
            ebCantidad.Focus()

        Else

            'Código Usuario :

            Sm_BuscarArticulo()

            If (oArticulo Is Nothing) Then
                Exit Sub
            End If

            ebCosto.Text = 0.0
            ebCantidad.Text = 0

            ebTalla.Focus()

        End If

    End Sub



    Private Function Fm_bolValidarExistenciaRegistros() As Boolean

        Dim dsRegistros As DataSet



        dsRegistros = oNotasCreditoMgr.ActualizarDataSet("[NotaCreditoDetalleTmpSel]", strTablaTmp)

        If (dsRegistros.Tables(strTablaTmp).Rows.Count = 0) Then

            MsgBox("No ha sido seleccionado un Artículo.", MsgBoxStyle.Exclamation, "DPTienda")
            dsRegistros.Dispose()
            dsRegistros = Nothing

            Exit Function

        End If

        dsRegistros.Dispose()
        dsRegistros = Nothing


        Return True

    End Function

#End Region


#Region "Métodos Privados [Eventos]"

    Private Sub frmCapturaNotaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()
        Me.ebCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
        Sm_BuscarCaja(False)

    End Sub



    Private Sub frmCapturaNotaCredito_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Sm_Finalizar()

    End Sub



    Private Sub frmCapturaNotaCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            SendKeys.Send("{TAB}")

        End If


        If (e.KeyCode = Keys.Escape) Then

            '<Validación>

            Dim dsRegistros As DataSet


            dsRegistros = oNotasCreditoMgr.ActualizarDataSet("[NotaCreditoDetalleTmpSel]", strTablaTmp)

            If (dsRegistros.Tables(strTablaTmp).Rows.Count = 0) Then

                dsRegistros.Dispose()
                dsRegistros = Nothing

                Me.Close()

                Exit Sub

            End If

            dsRegistros.Dispose()
            dsRegistros = Nothing

            '/<Validación>


            Me.DialogResult = DialogResult.OK
            Me.Close()

        End If

    End Sub



    Private Sub uitnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnAgregar.Click

        'validar que LA FACTURA NO ESTA CANCELADA SI ES DE CARGA INICIAL
        'Dim codigo As String = ebFacturaCod.Text
        'If codigo = "" Or Integer.Parse(codigo) = 0 Then
        '    If ebCodSAP.Text <> "" Then
        '        Dim dsCodigo As New DataSet
        '        dsCodigo = oNotasCreditoMgr.FolioProGet(ebCodSAP.Text.PadLeft(10, "0"))
        '        codigo = dsCodigo.Tables(0).Rows(0).Item("Folio")
        '    End If
        'End If

        '<Validación>
        If (Fm_bolTxtValidar() = False) Then
            Exit Sub
        End If
        '</Validación>

        'validar que este el articulo en catalogo de articulos y que sea en la Talla
        'If oNotasCreditoMgr.ValidarTallaArticulo(oArticulo.CodArticulo, ebTalla.Text) = 0 Then
        '    MsgBox("La talla del Articulo no Pertenece a esta Corrida o el Articulo es Codigo Anterior Corregir en [FacturaCorrida]", MsgBoxStyle.Critical, "Avisar Sistemas Dportenis")
        '    Exit Sub
        'End If

        If oNotasCreditoMgr.FacturaValidarNotaCreditoPasadasCanceladas(CInt(oFactura.FolioFactura)) = 0 Then
            MsgBox("La Factura ya esta cancelada si es factura de Carga Inicial Corregir en [FacturaFormasPago] campo MontoCancelado=0", MsgBoxStyle.Critical, "Avisar Sistemas Dportenis")
            Exit Sub
        End If

        oNotasCreditoMgr.AgregarArticulo(intNotaCreditoID, oArticulo, UCase(ebTalla.Text), ebCantidad.Text, oFactura, strTablaTmp)

        '</Unificar Asociados>
        If oFactura.CodTipoVenta = "A" Or oFactura.CodTipoVenta = "D" Then
            Me.TipoVentaCredito = oFactura.CodTipoVenta
        Else
            Me.TipoVentaCredito = String.Empty
        End If
        '<Unificar Asociados/>

        Sm_ActualizarGRID()

        ebCodigo.Text = String.Empty
        ebDescripcion.Text = String.Empty
        LblTallas.Text = "Tallas :"
        ebTalla.Text = 0
        ebCantidad.Value = 0
        ebCodigo.Focus()

    End Sub



    Private Sub uibtnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnQuitar.Click

        Dim oCurrentRow As GridEXRow

        Dim odrDataRow As DataRowView


        '<Validación>
        If (Fm_bolValidarExistenciaRegistros() = False) Then
            Exit Sub
        End If
        '/<Validación>


        oCurrentRow = GridNotaCreditoDetalle.GetRow()

        odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

        With odrDataRow

            oNotasCreditoMgr.EliminarArticulo(.Item("FolioReferencia"), .Item("CodArticulo"), .Item("Numero"), strTablaTmp)

        End With

        'Dim oRowArt As DataRow
        'Dim PosGrid As Integer

        For Each oRow As DataRow In Me.CambioTallas.Rows

            If CInt(oRow!PosGrid) = Me.GridNotaCreditoDetalle.Row Then

                '       oRowArt = BuscarRowGrid(odrDataRow.Item("CodArticulo"), odrDataRow.Item("Numero"))

                '      If Not oRowArt Is Nothing Then

                oNotasCreditoMgr.DesmarcarReversa_AjustarCantDevuelta(oRow!FoliosAjustes)

                '           End If

            End If

        Next

        EliminarRowsCambioTallas(Me.GridNotaCreditoDetalle.Row)
        AjustarPosGrid(Me.GridNotaCreditoDetalle.Row)

        oCurrentRow = Nothing
        odrDataRow = Nothing

        Sm_ActualizarGRID()

    End Sub

    Private Sub AjustarPosGrid(ByVal PosGrid As Integer)

        For Each oRow As DataRow In Me.CambioTallas.Rows

            If CInt(oRow!PosGrid) > PosGrid Then
                oRow!Posgrid = CInt(oRow!posgrid) - 1
            End If

        Next

        Me.CambioTallas.AcceptChanges()

    End Sub

    Private Sub EliminarRowsCambioTallas(ByVal PosGrid As Integer)

        Dim i As Integer = 0

        Do While i < Me.CambioTallas.Rows.Count
            Dim oRow As DataRow

            oRow = Me.CambioTallas.Rows(i)
            If CInt(oRow!PosGrid) = PosGrid Then

                Me.CambioTallas.Rows.Remove(oRow)
                i = 0

            Else

                i += 1

            End If

        Loop
        Me.CambioTallas.AcceptChanges()

    End Sub

    Private Function BuscarRowGrid(ByVal Codigo As String, ByVal Talla As String) As DataRow

        Dim i As Integer = 0

        For Each oRow As DataRow In Me.CambioTallas.Rows

            If UCase(Trim(oRow("CodArticulo"))) = UCase(Trim(Codigo)) AndAlso CDbl(oRow("TallaFactura")) = CDbl(Talla) Then

                Return Me.CambioTallas.Rows.Item(i)

            End If
            i += 1

        Next

        Return Nothing

    End Function


    Private Sub uibtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnSalir.Click

        'Validar que los articulos que agrego en el detalle, 
        'sean los mismos que el detalle que falta por guardar --- dttemporal vs DetalleNC

        If E_RESULT = "Y" Then
            'Comnparamos si traen el mismo numero de registros los DataTable´s
            If dtTemporal.Rows.Count = DetalleNC.Rows.Count Then
                Dim intContador As Integer
                Dim strNumero As String = ""
                intContador = 0
                'Validamos que sean los mismos registros con : Articulo, Talla y Cantidad
                For Each oRowNC As DataRow In DetalleNC.Rows

                    'Convertimos la talla del dataTable DetalleNC
                    If IsNumeric(oRowNC!J_3ASIZE) Then
                        'es un valor Numerico
                        If InStr(CStr(oRowNC!J_3ASIZE), ".5") = 0 Then
                            'La formato para que quede si es 26.0  --> 26
                            strNumero = Format(CDec(oRowNC!J_3ASIZE), "###0")
                        Else
                            'Se queda Igual es .5
                            strNumero = oRowNC!J_3ASIZE
                        End If
                    Else
                        'Es un Numero  XXL L M S
                        strNumero = oRowNC!J_3ASIZE
                    End If

                    For Each oRowTMP As DataRow In dtTemporal.Rows

                        If oRowNC.Item("MATNR") = oRowTMP.Item("CodArticulo") AndAlso strNumero = oRowTMP.Item("Numero") AndAlso oRowNC.Item("LFIMG") = oRowTMP.Item("Cantidad") Then

                            intContador += 1
                            Exit For

                        End If
                    Next

                Next

                If intContador <> DetalleNC.Rows.Count Then
                    If MsgBox("El detalle de los artículos es diferente en relación al guardado en SAP." & _
                                   Microsoft.VisualBasic.vbCrLf & Microsoft.VisualBasic.vbCrLf & _
                                   "¿Deseas cambiar el detalle capturado?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then

                        Exit Sub
                    Else

                        Me.DialogResult = DialogResult.Cancel
                        Exit Sub

                    End If
                End If

            Else
                If MsgBox("El detalle delos artículos es diferente en relación al guardado en SAP." & _
                Microsoft.VisualBasic.vbCrLf & Microsoft.VisualBasic.vbCrLf & _
                "¿Deseas cambiar el detalle capturado?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then

                    Exit Sub

                Else

                    Me.DialogResult = DialogResult.Cancel
                    Exit Sub

                End If

            End If



        End If

        Me.DialogResult = DialogResult.OK

    End Sub



    Private Sub ebCodigo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.ButtonClick

        Sm_BuscarArticulo(True)

        ebCantidad.Focus()

        ebCantidad.Text = 0

    End Sub



    Private Sub ebCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigo.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarArticulo(True)

            ebTalla.Focus()

            'Else

            '    If (e.KeyCode = Keys.Enter) Then

            '        If (Microsoft.VisualBasic.Len(ebCodigo.Text.Trim) > 0) Then

            '            Sm_CapturarArticuloScanner(ebCodigo.Text.Trim)

            '        End If

            '    End If

        End If

    End Sub



    Private Sub ebCodigo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodigo.Validating

        If (ebCodigo.Text.Trim <> String.Empty) Then
            oArticulo = oCatalogoArticulosMgr.Create
            oCatalogoArticulosMgr.LoadInto(Me.ebCodigo.Text.Trim, oArticulo)
            If EsCatalogo(Me.ebCodigo.Text) Then
                'If Mid(Me.ebCodigo.Text.Trim, 1, 6) = "DT-CAT" Then
                MsgBox("¡No se pueden hacer devoluciones de catalogos!", MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
                Me.ebDescripcion.Text = ""
                Me.ebTalla.Text = ""
                Me.ebCantidad.Text = ""
                Me.ebCodigo.Focus()
                Exit Sub
            End If

            Sm_CapturarArticuloScanner(ebCodigo.Text.Trim)

            If (oArticulo Is Nothing) Then

                e.Cancel = True

            End If

        End If

    End Sub



    Private Sub ebCodigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.GotFocus

        ebCodigo.Text = String.Empty

    End Sub




    Private Sub ebCaja_ButtonClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCaja.ButtonClick

        Sm_BuscarCaja(True)

    End Sub



    Private Sub ebCaja_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCaja.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarCaja(True)

        End If

    End Sub



    Private Sub ebCaja_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCaja.Validating

        If (ebCaja.Text <> String.Empty) Then

            Sm_BuscarCaja()

            If (oCaja Is Nothing) Then

                e.Cancel = True

            End If

        End If

    End Sub



    Private Sub ebFacturaCod_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFacturaCod.ButtonClick

        Sm_BuscarFactura("PRO", True)

    End Sub



    Private Sub ebFacturaCod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebFacturaCod.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarFactura(True)

        End If

    End Sub

    Private Sub ebFacturaCod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFacturaCod.Validating

        If (ebFacturaCod.Text <> 0) Then

            Sm_BuscarFactura("PRO")

            If (oFactura Is Nothing) Then

                e.Cancel = True

            End If

        End If


    End Sub

    Private Sub ebCodSAP_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodSAP1.ButtonClick, ebCodSAP.ButtonClick
        Me.Sm_BuscarFactura("SAP", True)
    End Sub

    Private Sub ebCodSAP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodSAP1.KeyDown, ebCodSAP.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarFactura("SAP", True)

        End If
    End Sub

    Private Sub ebCodSAP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodSAP1.Validating, ebCodSAP.Validating
        If (ebCodSAP.Text <> "") Then

            Sm_BuscarFactura("SAP")

            If (oFactura Is Nothing) Then

                e.Cancel = True

            End If

        End If
    End Sub

#End Region





    Private Sub ebFacturaCod_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFacturaCod.GotFocus
        'ebCodSAP.Text = "0"
    End Sub

    Private Sub ebCodSAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodSAP1.GotFocus
        'ebFacturaCod.Text = "0"
    End Sub

End Class
