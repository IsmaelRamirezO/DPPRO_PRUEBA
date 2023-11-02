
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Imports DportenisPro.DPTienda.ApplicationUnits.ImpresionEtiquetasAU

Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCategorias

Imports Janus.Windows.GridEX

Imports System.Drawing.Printing

'Imports DirPrint

'Imports Utilerias

'Imports PrinterNET

Public Class FrmImpresionEtiquetas
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
    Friend WithEvents btBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbPrecioOferta As System.Windows.Forms.RadioButton
    Friend WithEvents rbPrecioNormal As System.Windows.Forms.RadioButton
    Friend WithEvents rbEspecifico As System.Windows.Forms.RadioButton
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents grDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbFamilia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbLinea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbMarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lbPrecioCorridaDescuento As System.Windows.Forms.Label
    Friend WithEvents lbCorridaFinal As System.Windows.Forms.Label
    Friend WithEvents lbCodArticulo As System.Windows.Forms.Label
    Friend WithEvents RdBtn53 As System.Windows.Forms.RadioButton
    Friend WithEvents RdBtnEtiquetasZebra As System.Windows.Forms.RadioButton
    Friend WithEvents grpVistaPrevia As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ebEmpezar As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents pbEtiqueta_2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_0 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_10 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_9 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_8 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_7 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_6 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_5 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_4 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_3 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_11 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_12 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_13 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_15 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiqueta_14 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEmpezarEn As System.Windows.Forms.Label
    Friend WithEvents grpTipoEtiqueta As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbDportenis As System.Windows.Forms.RadioButton
    Friend WithEvents rbFactory As System.Windows.Forms.RadioButton
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents cmbCategoria As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebTalla As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblTalla As System.Windows.Forms.Label
    Friend WithEvents nebCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents lblLinea As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents lblFamilia As System.Windows.Forms.Label
    Friend WithEvents grdFactory As Janus.Windows.GridEX.GridEX
    Friend WithEvents pbEtiquetaF_15 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_14 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_13 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_12 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_11 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_10 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_9 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_8 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_7 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_6 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_5 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_4 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_3 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbEtiquetaF_0 As System.Windows.Forms.PictureBox
    Friend WithEvents grpFactory As Janus.Windows.EditControls.UIGroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImpresionEtiquetas))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout5 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout6 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.nebCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTalla = New System.Windows.Forms.Label()
        Me.ebTalla = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.cmbCategoria = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.grpTipoEtiqueta = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbFactory = New System.Windows.Forms.RadioButton()
        Me.rbDportenis = New System.Windows.Forms.RadioButton()
        Me.ebEmpezar = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.lblEmpezarEn = New System.Windows.Forms.Label()
        Me.RdBtnEtiquetasZebra = New System.Windows.Forms.RadioButton()
        Me.RdBtn53 = New System.Windows.Forms.RadioButton()
        Me.lbCodArticulo = New System.Windows.Forms.Label()
        Me.lbCorridaFinal = New System.Windows.Forms.Label()
        Me.lbPrecioCorridaDescuento = New System.Windows.Forms.Label()
        Me.btBuscar = New Janus.Windows.EditControls.UIButton()
        Me.lblFamilia = New System.Windows.Forms.Label()
        Me.lblLinea = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbPrecioOferta = New System.Windows.Forms.RadioButton()
        Me.rbPrecioNormal = New System.Windows.Forms.RadioButton()
        Me.rbEspecifico = New System.Windows.Forms.RadioButton()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.ebCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.cbFamilia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbLinea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbMarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.grdFactory = New Janus.Windows.GridEX.GridEX()
        Me.grDetalle = New Janus.Windows.GridEX.GridEX()
        Me.grpVistaPrevia = New Janus.Windows.EditControls.UIGroupBox()
        Me.pbEtiqueta_15 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_14 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_13 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_12 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_11 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_10 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_9 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_8 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_7 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_6 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_5 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_4 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_3 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_2 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_1 = New System.Windows.Forms.PictureBox()
        Me.pbEtiqueta_0 = New System.Windows.Forms.PictureBox()
        Me.grpFactory = New Janus.Windows.EditControls.UIGroupBox()
        Me.pbEtiquetaF_15 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_14 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_13 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_12 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_11 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_10 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_9 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_8 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_7 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_6 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_5 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_4 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_3 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_2 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_1 = New System.Windows.Forms.PictureBox()
        Me.pbEtiquetaF_0 = New System.Windows.Forms.PictureBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grpTipoEtiqueta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTipoEtiqueta.SuspendLayout()
        CType(Me.grdFactory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpVistaPrevia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVistaPrevia.SuspendLayout()
        CType(Me.pbEtiqueta_15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiqueta_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpFactory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFactory.SuspendLayout()
        CType(Me.pbEtiquetaF_15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtiquetaF_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.lblCantidad)
        Me.ExplorerBar1.Controls.Add(Me.nebCantidad)
        Me.ExplorerBar1.Controls.Add(Me.lblTalla)
        Me.ExplorerBar1.Controls.Add(Me.ebTalla)
        Me.ExplorerBar1.Controls.Add(Me.lblCategoria)
        Me.ExplorerBar1.Controls.Add(Me.cmbCategoria)
        Me.ExplorerBar1.Controls.Add(Me.grpTipoEtiqueta)
        Me.ExplorerBar1.Controls.Add(Me.ebEmpezar)
        Me.ExplorerBar1.Controls.Add(Me.lblEmpezarEn)
        Me.ExplorerBar1.Controls.Add(Me.RdBtnEtiquetasZebra)
        Me.ExplorerBar1.Controls.Add(Me.RdBtn53)
        Me.ExplorerBar1.Controls.Add(Me.lbCodArticulo)
        Me.ExplorerBar1.Controls.Add(Me.lbCorridaFinal)
        Me.ExplorerBar1.Controls.Add(Me.lbPrecioCorridaDescuento)
        Me.ExplorerBar1.Controls.Add(Me.btBuscar)
        Me.ExplorerBar1.Controls.Add(Me.lblFamilia)
        Me.ExplorerBar1.Controls.Add(Me.lblLinea)
        Me.ExplorerBar1.Controls.Add(Me.lblMarca)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.rbPrecioOferta)
        Me.ExplorerBar1.Controls.Add(Me.rbPrecioNormal)
        Me.ExplorerBar1.Controls.Add(Me.rbEspecifico)
        Me.ExplorerBar1.Controls.Add(Me.btnImprimir)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigo)
        Me.ExplorerBar1.Controls.Add(Me.cbFamilia)
        Me.ExplorerBar1.Controls.Add(Me.cbLinea)
        Me.ExplorerBar1.Controls.Add(Me.cbMarca)
        Me.ExplorerBar1.Controls.Add(Me.grdFactory)
        Me.ExplorerBar1.Controls.Add(Me.grDetalle)
        Me.ExplorerBar1.Controls.Add(Me.grpVistaPrevia)
        Me.ExplorerBar1.Controls.Add(Me.grpFactory)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Impresión de Etiquetas"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(912, 494)
        Me.ExplorerBar1.TabIndex = 56
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblCantidad
        '
        Me.lblCantidad.BackColor = System.Drawing.Color.Transparent
        Me.lblCantidad.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.Location = New System.Drawing.Point(288, 152)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(80, 16)
        Me.lblCantidad.TabIndex = 134
        Me.lblCantidad.Text = "Cantidad :"
        '
        'nebCantidad
        '
        Me.nebCantidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebCantidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebCantidad.Location = New System.Drawing.Point(370, 144)
        Me.nebCantidad.Name = "nebCantidad"
        Me.nebCantidad.Size = New System.Drawing.Size(80, 23)
        Me.nebCantidad.TabIndex = 76
        Me.nebCantidad.Text = "0"
        Me.nebCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTalla
        '
        Me.lblTalla.BackColor = System.Drawing.Color.Transparent
        Me.lblTalla.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTalla.Location = New System.Drawing.Point(16, 184)
        Me.lblTalla.Name = "lblTalla"
        Me.lblTalla.Size = New System.Drawing.Size(64, 16)
        Me.lblTalla.TabIndex = 132
        Me.lblTalla.Text = "Talla :"
        '
        'ebTalla
        '
        Me.ebTalla.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTalla.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTalla.Location = New System.Drawing.Point(98, 176)
        Me.ebTalla.Name = "ebTalla"
        Me.ebTalla.Size = New System.Drawing.Size(75, 23)
        Me.ebTalla.TabIndex = 75
        Me.ebTalla.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTalla.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCategoria
        '
        Me.lblCategoria.BackColor = System.Drawing.Color.Transparent
        Me.lblCategoria.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.Location = New System.Drawing.Point(288, 216)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(80, 16)
        Me.lblCategoria.TabIndex = 130
        Me.lblCategoria.Text = "Categoria :"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbCategoria.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbCategoria.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbCategoria.DesignTimeLayout = GridEXLayout1
        Me.cmbCategoria.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoria.Location = New System.Drawing.Point(370, 208)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(168, 22)
        Me.cmbCategoria.TabIndex = 78
        Me.cmbCategoria.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbCategoria.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'grpTipoEtiqueta
        '
        Me.grpTipoEtiqueta.BackColor = System.Drawing.Color.Transparent
        Me.grpTipoEtiqueta.Controls.Add(Me.rbFactory)
        Me.grpTipoEtiqueta.Controls.Add(Me.rbDportenis)
        Me.grpTipoEtiqueta.Location = New System.Drawing.Point(16, 40)
        Me.grpTipoEtiqueta.Name = "grpTipoEtiqueta"
        Me.grpTipoEtiqueta.Size = New System.Drawing.Size(208, 48)
        Me.grpTipoEtiqueta.TabIndex = 128
        Me.grpTipoEtiqueta.Text = "Tipo de Etiqueta"
        Me.grpTipoEtiqueta.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'rbFactory
        '
        Me.rbFactory.BackColor = System.Drawing.Color.Transparent
        Me.rbFactory.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFactory.Location = New System.Drawing.Point(136, 22)
        Me.rbFactory.Name = "rbFactory"
        Me.rbFactory.Size = New System.Drawing.Size(136, 20)
        Me.rbFactory.TabIndex = 73
        Me.rbFactory.Text = "Factory"
        Me.rbFactory.UseVisualStyleBackColor = False
        '
        'rbDportenis
        '
        Me.rbDportenis.BackColor = System.Drawing.Color.Transparent
        Me.rbDportenis.Checked = True
        Me.rbDportenis.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDportenis.Location = New System.Drawing.Point(8, 22)
        Me.rbDportenis.Name = "rbDportenis"
        Me.rbDportenis.Size = New System.Drawing.Size(136, 20)
        Me.rbDportenis.TabIndex = 72
        Me.rbDportenis.TabStop = True
        Me.rbDportenis.Text = "Dportenis"
        Me.rbDportenis.UseVisualStyleBackColor = False
        '
        'ebEmpezar
        '
        Me.ebEmpezar.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEmpezar.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEmpezar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEmpezar.Location = New System.Drawing.Point(98, 208)
        Me.ebEmpezar.Maximum = 16
        Me.ebEmpezar.Minimum = 1
        Me.ebEmpezar.Name = "ebEmpezar"
        Me.ebEmpezar.Size = New System.Drawing.Size(75, 22)
        Me.ebEmpezar.TabIndex = 79
        Me.ebEmpezar.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebEmpezar.Value = 1
        Me.ebEmpezar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblEmpezarEn
        '
        Me.lblEmpezarEn.BackColor = System.Drawing.Color.Transparent
        Me.lblEmpezarEn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpezarEn.Location = New System.Drawing.Point(18, 216)
        Me.lblEmpezarEn.Name = "lblEmpezarEn"
        Me.lblEmpezarEn.Size = New System.Drawing.Size(82, 23)
        Me.lblEmpezarEn.TabIndex = 127
        Me.lblEmpezarEn.Text = "Empezar en"
        '
        'RdBtnEtiquetasZebra
        '
        Me.RdBtnEtiquetasZebra.BackColor = System.Drawing.Color.Transparent
        Me.RdBtnEtiquetasZebra.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdBtnEtiquetasZebra.Location = New System.Drawing.Point(570, 104)
        Me.RdBtnEtiquetasZebra.Name = "RdBtnEtiquetasZebra"
        Me.RdBtnEtiquetasZebra.Size = New System.Drawing.Size(120, 16)
        Me.RdBtnEtiquetasZebra.TabIndex = 89
        Me.RdBtnEtiquetasZebra.Text = "Etiquetas Zebra"
        Me.RdBtnEtiquetasZebra.UseVisualStyleBackColor = False
        '
        'RdBtn53
        '
        Me.RdBtn53.BackColor = System.Drawing.Color.Transparent
        Me.RdBtn53.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdBtn53.Location = New System.Drawing.Point(386, 104)
        Me.RdBtn53.Name = "RdBtn53"
        Me.RdBtn53.Size = New System.Drawing.Size(184, 16)
        Me.RdBtn53.TabIndex = 88
        Me.RdBtn53.Text = "Etiqueta Zebra Especifico"
        Me.RdBtn53.UseVisualStyleBackColor = False
        '
        'lbCodArticulo
        '
        Me.lbCodArticulo.BackColor = System.Drawing.Color.Transparent
        Me.lbCodArticulo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCodArticulo.Location = New System.Drawing.Point(552, 192)
        Me.lbCodArticulo.Name = "lbCodArticulo"
        Me.lbCodArticulo.Size = New System.Drawing.Size(123, 24)
        Me.lbCodArticulo.TabIndex = 87
        Me.lbCodArticulo.Text = "lbCodArticulo"
        Me.lbCodArticulo.Visible = False
        '
        'lbCorridaFinal
        '
        Me.lbCorridaFinal.BackColor = System.Drawing.Color.Transparent
        Me.lbCorridaFinal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorridaFinal.Location = New System.Drawing.Point(549, 168)
        Me.lbCorridaFinal.Name = "lbCorridaFinal"
        Me.lbCorridaFinal.Size = New System.Drawing.Size(123, 24)
        Me.lbCorridaFinal.TabIndex = 86
        Me.lbCorridaFinal.Text = "lbCorridaFinal"
        Me.lbCorridaFinal.Visible = False
        '
        'lbPrecioCorridaDescuento
        '
        Me.lbPrecioCorridaDescuento.BackColor = System.Drawing.Color.Transparent
        Me.lbPrecioCorridaDescuento.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPrecioCorridaDescuento.Location = New System.Drawing.Point(544, 144)
        Me.lbPrecioCorridaDescuento.Name = "lbPrecioCorridaDescuento"
        Me.lbPrecioCorridaDescuento.Size = New System.Drawing.Size(184, 24)
        Me.lbPrecioCorridaDescuento.TabIndex = 85
        Me.lbPrecioCorridaDescuento.Text = "lbPrecioCorridaDescuento"
        Me.lbPrecioCorridaDescuento.Visible = False
        '
        'btBuscar
        '
        Me.btBuscar.Image = CType(resources.GetObject("btBuscar.Image"), System.Drawing.Image)
        Me.btBuscar.Location = New System.Drawing.Point(16, 456)
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(160, 32)
        Me.btBuscar.TabIndex = 80
        Me.btBuscar.Text = "&Buscar"
        Me.btBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblFamilia
        '
        Me.lblFamilia.BackColor = System.Drawing.Color.Transparent
        Me.lblFamilia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFamilia.Location = New System.Drawing.Point(290, 184)
        Me.lblFamilia.Name = "lblFamilia"
        Me.lblFamilia.Size = New System.Drawing.Size(64, 16)
        Me.lblFamilia.TabIndex = 84
        Me.lblFamilia.Text = "Familia :"
        '
        'lblLinea
        '
        Me.lblLinea.BackColor = System.Drawing.Color.Transparent
        Me.lblLinea.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLinea.Location = New System.Drawing.Point(290, 152)
        Me.lblLinea.Name = "lblLinea"
        Me.lblLinea.Size = New System.Drawing.Size(64, 16)
        Me.lblLinea.TabIndex = 83
        Me.lblLinea.Text = "Linea :"
        '
        'lblMarca
        '
        Me.lblMarca.BackColor = System.Drawing.Color.Transparent
        Me.lblMarca.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarca.Location = New System.Drawing.Point(18, 184)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(64, 16)
        Me.lblMarca.TabIndex = 82
        Me.lblMarca.Text = "Marca :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Código :"
        '
        'rbPrecioOferta
        '
        Me.rbPrecioOferta.BackColor = System.Drawing.Color.Transparent
        Me.rbPrecioOferta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPrecioOferta.Location = New System.Drawing.Point(274, 104)
        Me.rbPrecioOferta.Name = "rbPrecioOferta"
        Me.rbPrecioOferta.Size = New System.Drawing.Size(112, 16)
        Me.rbPrecioOferta.TabIndex = 73
        Me.rbPrecioOferta.Text = "Precio Oferta"
        Me.rbPrecioOferta.UseVisualStyleBackColor = False
        '
        'rbPrecioNormal
        '
        Me.rbPrecioNormal.BackColor = System.Drawing.Color.Transparent
        Me.rbPrecioNormal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPrecioNormal.Location = New System.Drawing.Point(154, 104)
        Me.rbPrecioNormal.Name = "rbPrecioNormal"
        Me.rbPrecioNormal.Size = New System.Drawing.Size(120, 16)
        Me.rbPrecioNormal.TabIndex = 72
        Me.rbPrecioNormal.Text = "Precio Normal"
        Me.rbPrecioNormal.UseVisualStyleBackColor = False
        '
        'rbEspecifico
        '
        Me.rbEspecifico.BackColor = System.Drawing.Color.Transparent
        Me.rbEspecifico.Checked = True
        Me.rbEspecifico.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEspecifico.Location = New System.Drawing.Point(18, 104)
        Me.rbEspecifico.Name = "rbEspecifico"
        Me.rbEspecifico.Size = New System.Drawing.Size(136, 16)
        Me.rbEspecifico.TabIndex = 71
        Me.rbEspecifico.TabStop = True
        Me.rbEspecifico.Text = "Una en especifico"
        Me.rbEspecifico.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Icon = CType(resources.GetObject("btnImprimir.Icon"), System.Drawing.Icon)
        Me.btnImprimir.Location = New System.Drawing.Point(656, 456)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(248, 32)
        Me.btnImprimir.TabIndex = 80
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebCodigo
        '
        Me.ebCodigo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigo.ButtonImage = CType(resources.GetObject("ebCodigo.ButtonImage"), System.Drawing.Image)
        Me.ebCodigo.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigo.Location = New System.Drawing.Point(98, 144)
        Me.ebCodigo.MaxLength = 20
        Me.ebCodigo.Name = "ebCodigo"
        Me.ebCodigo.Size = New System.Drawing.Size(168, 22)
        Me.ebCodigo.TabIndex = 74
        Me.ebCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cbFamilia
        '
        Me.cbFamilia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cbFamilia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cbFamilia.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.cbFamilia.DesignTimeLayout = GridEXLayout2
        Me.cbFamilia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFamilia.Location = New System.Drawing.Point(370, 176)
        Me.cbFamilia.Name = "cbFamilia"
        Me.cbFamilia.Size = New System.Drawing.Size(168, 22)
        Me.cbFamilia.TabIndex = 77
        Me.cbFamilia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cbFamilia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cbLinea
        '
        Me.cbLinea.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cbLinea.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cbLinea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.cbLinea.DesignTimeLayout = GridEXLayout3
        Me.cbLinea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLinea.Location = New System.Drawing.Point(370, 144)
        Me.cbLinea.Name = "cbLinea"
        Me.cbLinea.Size = New System.Drawing.Size(168, 22)
        Me.cbLinea.TabIndex = 76
        Me.cbLinea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cbLinea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cbMarca
        '
        Me.cbMarca.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cbMarca.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cbMarca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.cbMarca.DesignTimeLayout = GridEXLayout4
        Me.cbMarca.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMarca.Location = New System.Drawing.Point(98, 176)
        Me.cbMarca.Name = "cbMarca"
        Me.cbMarca.Size = New System.Drawing.Size(168, 22)
        Me.cbMarca.TabIndex = 75
        Me.cbMarca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cbMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'grdFactory
        '
        GridEXLayout5.LayoutString = resources.GetString("GridEXLayout5.LayoutString")
        Me.grdFactory.DesignTimeLayout = GridEXLayout5
        Me.grdFactory.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdFactory.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdFactory.GroupByBoxVisible = False
        Me.grdFactory.Location = New System.Drawing.Point(16, 240)
        Me.grdFactory.Name = "grdFactory"
        Me.grdFactory.Size = New System.Drawing.Size(631, 208)
        Me.grdFactory.TabIndex = 135
        Me.grdFactory.TabStop = False
        Me.grdFactory.Visible = False
        Me.grdFactory.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'grDetalle
        '
        GridEXLayout6.LayoutString = resources.GetString("GridEXLayout6.LayoutString")
        Me.grDetalle.DesignTimeLayout = GridEXLayout6
        Me.grDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grDetalle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grDetalle.GroupByBoxVisible = False
        Me.grDetalle.Location = New System.Drawing.Point(17, 240)
        Me.grDetalle.Name = "grDetalle"
        Me.grDetalle.Size = New System.Drawing.Size(631, 208)
        Me.grDetalle.TabIndex = 81
        Me.grDetalle.TabStop = False
        Me.grDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'grpVistaPrevia
        '
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_15)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_14)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_13)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_12)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_11)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_10)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_9)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_8)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_7)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_6)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_5)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_4)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_3)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_2)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_1)
        Me.grpVistaPrevia.Controls.Add(Me.pbEtiqueta_0)
        Me.grpVistaPrevia.Location = New System.Drawing.Point(656, 104)
        Me.grpVistaPrevia.Name = "grpVistaPrevia"
        Me.grpVistaPrevia.Size = New System.Drawing.Size(248, 344)
        Me.grpVistaPrevia.TabIndex = 90
        Me.grpVistaPrevia.Text = "Vista Previa"
        Me.grpVistaPrevia.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'pbEtiqueta_15
        '
        Me.pbEtiqueta_15.Image = CType(resources.GetObject("pbEtiqueta_15.Image"), System.Drawing.Image)
        Me.pbEtiqueta_15.Location = New System.Drawing.Point(184, 264)
        Me.pbEtiqueta_15.Name = "pbEtiqueta_15"
        Me.pbEtiqueta_15.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_15.TabIndex = 15
        Me.pbEtiqueta_15.TabStop = False
        '
        'pbEtiqueta_14
        '
        Me.pbEtiqueta_14.Image = CType(resources.GetObject("pbEtiqueta_14.Image"), System.Drawing.Image)
        Me.pbEtiqueta_14.Location = New System.Drawing.Point(128, 264)
        Me.pbEtiqueta_14.Name = "pbEtiqueta_14"
        Me.pbEtiqueta_14.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_14.TabIndex = 14
        Me.pbEtiqueta_14.TabStop = False
        '
        'pbEtiqueta_13
        '
        Me.pbEtiqueta_13.Image = CType(resources.GetObject("pbEtiqueta_13.Image"), System.Drawing.Image)
        Me.pbEtiqueta_13.Location = New System.Drawing.Point(72, 264)
        Me.pbEtiqueta_13.Name = "pbEtiqueta_13"
        Me.pbEtiqueta_13.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_13.TabIndex = 13
        Me.pbEtiqueta_13.TabStop = False
        '
        'pbEtiqueta_12
        '
        Me.pbEtiqueta_12.Image = CType(resources.GetObject("pbEtiqueta_12.Image"), System.Drawing.Image)
        Me.pbEtiqueta_12.Location = New System.Drawing.Point(16, 264)
        Me.pbEtiqueta_12.Name = "pbEtiqueta_12"
        Me.pbEtiqueta_12.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_12.TabIndex = 12
        Me.pbEtiqueta_12.TabStop = False
        '
        'pbEtiqueta_11
        '
        Me.pbEtiqueta_11.Image = CType(resources.GetObject("pbEtiqueta_11.Image"), System.Drawing.Image)
        Me.pbEtiqueta_11.Location = New System.Drawing.Point(184, 184)
        Me.pbEtiqueta_11.Name = "pbEtiqueta_11"
        Me.pbEtiqueta_11.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_11.TabIndex = 11
        Me.pbEtiqueta_11.TabStop = False
        '
        'pbEtiqueta_10
        '
        Me.pbEtiqueta_10.Image = CType(resources.GetObject("pbEtiqueta_10.Image"), System.Drawing.Image)
        Me.pbEtiqueta_10.Location = New System.Drawing.Point(128, 184)
        Me.pbEtiqueta_10.Name = "pbEtiqueta_10"
        Me.pbEtiqueta_10.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_10.TabIndex = 10
        Me.pbEtiqueta_10.TabStop = False
        '
        'pbEtiqueta_9
        '
        Me.pbEtiqueta_9.Image = CType(resources.GetObject("pbEtiqueta_9.Image"), System.Drawing.Image)
        Me.pbEtiqueta_9.Location = New System.Drawing.Point(72, 184)
        Me.pbEtiqueta_9.Name = "pbEtiqueta_9"
        Me.pbEtiqueta_9.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_9.TabIndex = 9
        Me.pbEtiqueta_9.TabStop = False
        '
        'pbEtiqueta_8
        '
        Me.pbEtiqueta_8.Image = CType(resources.GetObject("pbEtiqueta_8.Image"), System.Drawing.Image)
        Me.pbEtiqueta_8.Location = New System.Drawing.Point(16, 184)
        Me.pbEtiqueta_8.Name = "pbEtiqueta_8"
        Me.pbEtiqueta_8.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_8.TabIndex = 8
        Me.pbEtiqueta_8.TabStop = False
        '
        'pbEtiqueta_7
        '
        Me.pbEtiqueta_7.Image = CType(resources.GetObject("pbEtiqueta_7.Image"), System.Drawing.Image)
        Me.pbEtiqueta_7.Location = New System.Drawing.Point(184, 104)
        Me.pbEtiqueta_7.Name = "pbEtiqueta_7"
        Me.pbEtiqueta_7.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_7.TabIndex = 7
        Me.pbEtiqueta_7.TabStop = False
        '
        'pbEtiqueta_6
        '
        Me.pbEtiqueta_6.Image = CType(resources.GetObject("pbEtiqueta_6.Image"), System.Drawing.Image)
        Me.pbEtiqueta_6.Location = New System.Drawing.Point(128, 104)
        Me.pbEtiqueta_6.Name = "pbEtiqueta_6"
        Me.pbEtiqueta_6.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_6.TabIndex = 6
        Me.pbEtiqueta_6.TabStop = False
        '
        'pbEtiqueta_5
        '
        Me.pbEtiqueta_5.Image = CType(resources.GetObject("pbEtiqueta_5.Image"), System.Drawing.Image)
        Me.pbEtiqueta_5.Location = New System.Drawing.Point(72, 104)
        Me.pbEtiqueta_5.Name = "pbEtiqueta_5"
        Me.pbEtiqueta_5.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_5.TabIndex = 5
        Me.pbEtiqueta_5.TabStop = False
        '
        'pbEtiqueta_4
        '
        Me.pbEtiqueta_4.Image = CType(resources.GetObject("pbEtiqueta_4.Image"), System.Drawing.Image)
        Me.pbEtiqueta_4.Location = New System.Drawing.Point(16, 104)
        Me.pbEtiqueta_4.Name = "pbEtiqueta_4"
        Me.pbEtiqueta_4.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_4.TabIndex = 4
        Me.pbEtiqueta_4.TabStop = False
        '
        'pbEtiqueta_3
        '
        Me.pbEtiqueta_3.Image = CType(resources.GetObject("pbEtiqueta_3.Image"), System.Drawing.Image)
        Me.pbEtiqueta_3.Location = New System.Drawing.Point(184, 24)
        Me.pbEtiqueta_3.Name = "pbEtiqueta_3"
        Me.pbEtiqueta_3.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_3.TabIndex = 3
        Me.pbEtiqueta_3.TabStop = False
        '
        'pbEtiqueta_2
        '
        Me.pbEtiqueta_2.Image = CType(resources.GetObject("pbEtiqueta_2.Image"), System.Drawing.Image)
        Me.pbEtiqueta_2.Location = New System.Drawing.Point(128, 24)
        Me.pbEtiqueta_2.Name = "pbEtiqueta_2"
        Me.pbEtiqueta_2.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_2.TabIndex = 2
        Me.pbEtiqueta_2.TabStop = False
        '
        'pbEtiqueta_1
        '
        Me.pbEtiqueta_1.Image = CType(resources.GetObject("pbEtiqueta_1.Image"), System.Drawing.Image)
        Me.pbEtiqueta_1.Location = New System.Drawing.Point(72, 24)
        Me.pbEtiqueta_1.Name = "pbEtiqueta_1"
        Me.pbEtiqueta_1.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_1.TabIndex = 1
        Me.pbEtiqueta_1.TabStop = False
        '
        'pbEtiqueta_0
        '
        Me.pbEtiqueta_0.Image = CType(resources.GetObject("pbEtiqueta_0.Image"), System.Drawing.Image)
        Me.pbEtiqueta_0.Location = New System.Drawing.Point(16, 24)
        Me.pbEtiqueta_0.Name = "pbEtiqueta_0"
        Me.pbEtiqueta_0.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiqueta_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiqueta_0.TabIndex = 0
        Me.pbEtiqueta_0.TabStop = False
        '
        'grpFactory
        '
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_15)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_14)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_13)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_12)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_11)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_10)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_9)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_8)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_7)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_6)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_5)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_4)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_3)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_2)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_1)
        Me.grpFactory.Controls.Add(Me.pbEtiquetaF_0)
        Me.grpFactory.Location = New System.Drawing.Point(656, 104)
        Me.grpFactory.Name = "grpFactory"
        Me.grpFactory.Size = New System.Drawing.Size(248, 344)
        Me.grpFactory.TabIndex = 136
        Me.grpFactory.Text = "Vista Previa"
        Me.grpFactory.Visible = False
        Me.grpFactory.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'pbEtiquetaF_15
        '
        Me.pbEtiquetaF_15.Image = CType(resources.GetObject("pbEtiquetaF_15.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_15.Location = New System.Drawing.Point(184, 264)
        Me.pbEtiquetaF_15.Name = "pbEtiquetaF_15"
        Me.pbEtiquetaF_15.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_15.TabIndex = 15
        Me.pbEtiquetaF_15.TabStop = False
        '
        'pbEtiquetaF_14
        '
        Me.pbEtiquetaF_14.Image = CType(resources.GetObject("pbEtiquetaF_14.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_14.Location = New System.Drawing.Point(128, 264)
        Me.pbEtiquetaF_14.Name = "pbEtiquetaF_14"
        Me.pbEtiquetaF_14.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_14.TabIndex = 14
        Me.pbEtiquetaF_14.TabStop = False
        '
        'pbEtiquetaF_13
        '
        Me.pbEtiquetaF_13.Image = CType(resources.GetObject("pbEtiquetaF_13.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_13.Location = New System.Drawing.Point(72, 264)
        Me.pbEtiquetaF_13.Name = "pbEtiquetaF_13"
        Me.pbEtiquetaF_13.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_13.TabIndex = 13
        Me.pbEtiquetaF_13.TabStop = False
        '
        'pbEtiquetaF_12
        '
        Me.pbEtiquetaF_12.Image = CType(resources.GetObject("pbEtiquetaF_12.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_12.Location = New System.Drawing.Point(16, 264)
        Me.pbEtiquetaF_12.Name = "pbEtiquetaF_12"
        Me.pbEtiquetaF_12.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_12.TabIndex = 12
        Me.pbEtiquetaF_12.TabStop = False
        '
        'pbEtiquetaF_11
        '
        Me.pbEtiquetaF_11.Image = CType(resources.GetObject("pbEtiquetaF_11.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_11.Location = New System.Drawing.Point(184, 184)
        Me.pbEtiquetaF_11.Name = "pbEtiquetaF_11"
        Me.pbEtiquetaF_11.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_11.TabIndex = 11
        Me.pbEtiquetaF_11.TabStop = False
        '
        'pbEtiquetaF_10
        '
        Me.pbEtiquetaF_10.Image = CType(resources.GetObject("pbEtiquetaF_10.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_10.Location = New System.Drawing.Point(128, 184)
        Me.pbEtiquetaF_10.Name = "pbEtiquetaF_10"
        Me.pbEtiquetaF_10.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_10.TabIndex = 10
        Me.pbEtiquetaF_10.TabStop = False
        '
        'pbEtiquetaF_9
        '
        Me.pbEtiquetaF_9.Image = CType(resources.GetObject("pbEtiquetaF_9.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_9.Location = New System.Drawing.Point(72, 184)
        Me.pbEtiquetaF_9.Name = "pbEtiquetaF_9"
        Me.pbEtiquetaF_9.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_9.TabIndex = 9
        Me.pbEtiquetaF_9.TabStop = False
        '
        'pbEtiquetaF_8
        '
        Me.pbEtiquetaF_8.Image = CType(resources.GetObject("pbEtiquetaF_8.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_8.Location = New System.Drawing.Point(16, 184)
        Me.pbEtiquetaF_8.Name = "pbEtiquetaF_8"
        Me.pbEtiquetaF_8.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_8.TabIndex = 8
        Me.pbEtiquetaF_8.TabStop = False
        '
        'pbEtiquetaF_7
        '
        Me.pbEtiquetaF_7.Image = CType(resources.GetObject("pbEtiquetaF_7.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_7.Location = New System.Drawing.Point(184, 104)
        Me.pbEtiquetaF_7.Name = "pbEtiquetaF_7"
        Me.pbEtiquetaF_7.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_7.TabIndex = 7
        Me.pbEtiquetaF_7.TabStop = False
        '
        'pbEtiquetaF_6
        '
        Me.pbEtiquetaF_6.Image = CType(resources.GetObject("pbEtiquetaF_6.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_6.Location = New System.Drawing.Point(128, 104)
        Me.pbEtiquetaF_6.Name = "pbEtiquetaF_6"
        Me.pbEtiquetaF_6.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_6.TabIndex = 6
        Me.pbEtiquetaF_6.TabStop = False
        '
        'pbEtiquetaF_5
        '
        Me.pbEtiquetaF_5.Image = CType(resources.GetObject("pbEtiquetaF_5.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_5.Location = New System.Drawing.Point(72, 104)
        Me.pbEtiquetaF_5.Name = "pbEtiquetaF_5"
        Me.pbEtiquetaF_5.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_5.TabIndex = 5
        Me.pbEtiquetaF_5.TabStop = False
        '
        'pbEtiquetaF_4
        '
        Me.pbEtiquetaF_4.Image = CType(resources.GetObject("pbEtiquetaF_4.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_4.Location = New System.Drawing.Point(16, 104)
        Me.pbEtiquetaF_4.Name = "pbEtiquetaF_4"
        Me.pbEtiquetaF_4.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_4.TabIndex = 4
        Me.pbEtiquetaF_4.TabStop = False
        '
        'pbEtiquetaF_3
        '
        Me.pbEtiquetaF_3.Image = CType(resources.GetObject("pbEtiquetaF_3.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_3.Location = New System.Drawing.Point(184, 24)
        Me.pbEtiquetaF_3.Name = "pbEtiquetaF_3"
        Me.pbEtiquetaF_3.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_3.TabIndex = 3
        Me.pbEtiquetaF_3.TabStop = False
        '
        'pbEtiquetaF_2
        '
        Me.pbEtiquetaF_2.Image = CType(resources.GetObject("pbEtiquetaF_2.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_2.Location = New System.Drawing.Point(128, 24)
        Me.pbEtiquetaF_2.Name = "pbEtiquetaF_2"
        Me.pbEtiquetaF_2.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_2.TabIndex = 2
        Me.pbEtiquetaF_2.TabStop = False
        '
        'pbEtiquetaF_1
        '
        Me.pbEtiquetaF_1.Image = CType(resources.GetObject("pbEtiquetaF_1.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_1.Location = New System.Drawing.Point(72, 24)
        Me.pbEtiquetaF_1.Name = "pbEtiquetaF_1"
        Me.pbEtiquetaF_1.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_1.TabIndex = 1
        Me.pbEtiquetaF_1.TabStop = False
        '
        'pbEtiquetaF_0
        '
        Me.pbEtiquetaF_0.Image = CType(resources.GetObject("pbEtiquetaF_0.Image"), System.Drawing.Image)
        Me.pbEtiquetaF_0.Location = New System.Drawing.Point(16, 24)
        Me.pbEtiquetaF_0.Name = "pbEtiquetaF_0"
        Me.pbEtiquetaF_0.Size = New System.Drawing.Size(48, 72)
        Me.pbEtiquetaF_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEtiquetaF_0.TabIndex = 0
        Me.pbEtiquetaF_0.TabStop = False
        '
        'FrmImpresionEtiquetas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(912, 494)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImpresionEtiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de Etiquetas"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.grpTipoEtiqueta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTipoEtiqueta.ResumeLayout(False)
        CType(Me.grdFactory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpVistaPrevia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVistaPrevia.ResumeLayout(False)
        CType(Me.pbEtiqueta_15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiqueta_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpFactory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFactory.ResumeLayout(False)
        CType(Me.pbEtiquetaF_15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtiquetaF_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



#Region "Variables Miembros"
    Dim posicion As Integer
    Dim precio As Double
    Dim precioOferta As Double
    Dim codArticulo As String
    Dim corridaFinal As String
    Dim contador As Integer
    Dim paginasTotales As Integer
    Dim c, a As Integer

    Private oImpresionEtiquetasMgr As ImpresionEtiquetaManager

    Private oArticulo As Articulo

    Private oCatalogoArticulosMgr As CatalogoArticuloManager

    Private oCatalogoMarcasMgr As CatalogoMarcasManager

    Private oCatalogoLineasMgr As CatalogoLineasManager

    Private oCatalogoFamiliasMgr As CatalogoFamiliasManager

    Dim dt As DataTable

    Dim dtCorridas As DataTable

    Dim dr As DataRow

    Dim strEtiquetas As String

    Private WithEvents pDocument As PrintDocument

    Dim intPosEtq As Integer = 0

    Dim pb As New ControlArray("pbEtiqueta")

    Dim pbFactory As New ControlArray("pbEtiquetaF")

    Dim oCatalogoCatMgr As CatalogoCategoriasManager

#End Region



#Region "Métodos Miembros"

    Sub Sm_Inicializar()

        If oAppContext.ApplicationConfiguration.Almacen <> "053" Then
            RdBtn53.Visible = False
            RdBtnEtiquetasZebra.Visible = False
        End If

        oImpresionEtiquetasMgr = New ImpresionEtiquetaManager(oAppContext)

        oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)

        oCatalogoMarcasMgr = New CatalogoMarcasManager(oAppContext)

        oCatalogoLineasMgr = New CatalogoLineasManager(oAppContext)

        oCatalogoFamiliasMgr = New CatalogoFamiliasManager(oAppContext)

        oCatalogoCatMgr = New CatalogoCategoriasManager(oAppContext)

        pDocument = New PrintDocument
        '-------------------------------------------------------------------------------------------------------------------------------------
        'Llenar Combos.
        '-------------------------------------------------------------------------------------------------------------------------------------
        Sm_FillcbMarca()

        Sm_FillcbLinea()

        Sm_FillcbFamilia()

        Sm_FillcbCategorias()
        '-------------------------------------------------------------------------------------------------------------------------------------
        'Asignamos los controles picturebox de las etiquetas a un array para usarlo en la actualización de la vista previa
        '-------------------------------------------------------------------------------------------------------------------------------------
        pb.AsignarControles(Me.Controls)
        pbFactory.AsignarControles(Me.Controls)
        SetImagePictureBox()
        '-------------------------------------------------------------------------------------------------------------------------------------
        'Mostramos la pantalla correspondiente según la configuración, es decir, para impresión en Laser o LX-300
        '-------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.ImprimirEtiquetasEnLaser = False Then
            Me.Width = 664
            Me.ebEmpezar.Visible = False
            Me.lblEmpezarEn.Visible = False
            Me.btnImprimir.Left = 424
            Me.btnImprimir.Width = 224
            Me.rbFactory.Visible = False
        Else
            Me.rbDportenis.Visible = oConfigCierreFI.EtiquetaPrecioDP
            Me.rbFactory.Visible = oConfigCierreFI.EtiquetaPrecioFactory

            If Me.rbDportenis.Visible = False Then
                Me.rbFactory.Checked = True
                Me.rbFactory.Left = 8
            End If
        End If

        ebCodigo.Focus()



    End Sub

    Sub Sm_Finalizar()

        oImpresionEtiquetasMgr = Nothing

        oArticulo = Nothing

        oCatalogoArticulosMgr = Nothing

        oCatalogoMarcasMgr = Nothing

        oCatalogoLineasMgr = Nothing

        oCatalogoFamiliasMgr = Nothing


        pDocument.Dispose()

        pDocument = Nothing

    End Sub



    Private Sub Sm_HabilitarCombos(ByVal bolValue As Boolean)

        cbMarca.Enabled = True
        cbFamilia.Enabled = True
        cbLinea.Enabled = True
        Me.ebCodigo.Enabled = True
        Me.cmbCategoria.Visible = True
        Me.lblCategoria.Visible = True
        Me.cbMarca.Visible = True
        Me.lblMarca.Visible = True
        Me.cbFamilia.Visible = True
        Me.lblFamilia.Visible = True
        Me.cbLinea.Visible = True
        Me.lblLinea.Visible = True

        If Me.rbFactory.Checked Then
            Me.cmbCategoria.Visible = bolValue
            Me.lblCategoria.Visible = bolValue
            Me.cbMarca.Visible = bolValue
            Me.lblMarca.Visible = bolValue
            Me.cbFamilia.Visible = bolValue
            Me.lblFamilia.Visible = bolValue
            Me.cbLinea.Visible = bolValue
            Me.lblLinea.Visible = bolValue
        Else
            Me.cmbCategoria.Visible = False
            Me.lblCategoria.Visible = False
            cbMarca.Enabled = bolValue
            cbFamilia.Enabled = bolValue
            cbLinea.Enabled = bolValue
            'Me.ebCodigo.Enabled = Not bolValue
            'If (bolValue = True) Then
            '    ebCodigo.Enabled = False
            'Else
            '    ebCodigo.Enabled = True
            'End If
        End If
        Me.ebCodigo.Enabled = Not bolValue

    End Sub



    Private Sub Sm_BuscarArticulo(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog2

            oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Dim cArticulo As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    cArticulo = oOpenRecordDlg.Record.Item("Código")

                Else
                    cArticulo = oOpenRecordDlg.pbCodigo

                End If

                oArticulo = Nothing
                'oArticulo = oCatalogoArticulosMgr.Load(oOpenRecordDlg.Record.Item("Código"))
                oArticulo = oCatalogoArticulosMgr.Load(cArticulo)

                ebCodigo.Text = oArticulo.CodArticulo

            End If

        Else

            oArticulo = Nothing
            oArticulo = oCatalogoArticulosMgr.Load(ebCodigo.Text.Trim)

            If (oArticulo Is Nothing) Then

                MsgBox("El Artículo no ha sido encontrado.", MsgBoxStyle.Exclamation, "DPTienda")
                ebCodigo.Focus()

                Exit Sub

            End If

            ebCodigo.Text = oArticulo.CodArticulo

        End If

    End Sub



    Private Function Fm_bolcbValidarBusqueda() As Boolean

        If (rbEspecifico.Checked = True) Then

            If (oArticulo Is Nothing) Then

                MsgBox("No ha sido seleccionado un Articulo.", MsgBoxStyle.Exclamation, "DPTienda")
                ebCodigo.Focus()

                Exit Function
            ElseIf Me.rbFactory.Checked AndAlso Me.ebTalla.Text.Trim = "" Then
                MessageBox.Show("Es necesario indicar la talla.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebTalla.Focus()
                Exit Function
            ElseIf Me.nebCantidad.Value <= 0 Then
                MessageBox.Show("Es necesario indicar la cantidad de etiquetas a imprimir.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.nebCantidad.Focus()
                Exit Function
            End If

        End If
        '-------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 11.11.2013: Solo valida los combos si es diseño dportenis, si es factory son opcionales
        '-------------------------------------------------------------------------------------------------------------------------------------------
        If (rbPrecioNormal.Checked = True OrElse rbPrecioOferta.Checked = True) AndAlso Me.rbFactory.Checked = False Then

            If (cbMarca.Value = String.Empty) Then

                MsgBox("El campo Marca es requerido.", MsgBoxStyle.Exclamation, "DPTienda")
                cbMarca.Focus()

                Exit Function

            End If


            If (cbLinea.Value = String.Empty) Then

                MsgBox("El campo Linea es requerido.", MsgBoxStyle.Exclamation, "DPTienda")
                cbLinea.Focus()

                Exit Function

            End If


            If (cbFamilia.Value = String.Empty) Then

                MsgBox("El campo Familia es requerido.", MsgBoxStyle.Exclamation, "DPTienda")
                cbFamilia.Focus()

                Exit Function

            End If

        End If


        Return True

    End Function



    Private Sub Sm_BuscarArticulos() 'Detalle Grid

        Dim dsImpresion As DataSet

        If (Fm_bolcbValidarBusqueda() = False) Then

            Exit Sub

        End If


        dt = Nothing
        dsImpresion = Nothing

        If Me.RdBtn53.Checked = True Then

            dt = oImpresionEtiquetasMgr.GetAll(True, oArticulo.CodArticulo).Tables("CatalogoArticulos")
        Else

            If Me.RdBtnEtiquetasZebra.Checked = True Then

                dt = oImpresionEtiquetasMgr.GetAll(True, , cbMarca.Value, cbFamilia.Value, cbLinea.Value, String.Empty).Tables("CatalogoArticulos")

            Else
                If Not (oArticulo Is Nothing) Then

                    If Me.rbFactory.Checked Then
                        dt = oImpresionEtiquetasMgr.GetAll(False, oArticulo.CodArticulo, , , , , , Me.ebTalla.Text.Trim).Tables("CatalogoArticulos")
                        'If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then dt.Rows(0)!Cantidad = Me.nebCantidad.Value
                        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then dt.Rows(0)!Cantidad = Me.nebCantidad.Value
                    Else
                        If IsCodArticuloInGrid(oArticulo.CodArticulo) = False Then
                            Dim dtEspecific As DataTable, dtEspecificCorrida As DataTable, fila As DataRow = Nothing
                            dsImpresion = oImpresionEtiquetasMgr.GetAll(False, oArticulo.CodArticulo)
                            dtEspecific = dsImpresion.Tables("CatalogoArticulos").Copy
                            dtEspecificCorrida = dsImpresion.Tables(1).Copy
                            If grDetalle.DataSource Is Nothing Then
                                dt = dtEspecific.Clone()
                                dtCorridas = dtEspecificCorrida.Clone()
                            Else
                                dt = CType(grDetalle.DataSource, DataTable)
                            End If
                            Dim cantidad As Integer = 0
                            For Each row As DataRow In dtEspecific.Rows
                                row("Cantidad") = CInt(nebCantidad.Value)
                                row.AcceptChanges()
                                dt.ImportRow(row)
                                dt.AcceptChanges()
                            Next
                            dt.AcceptChanges()
                            For Each row As DataRow In dtEspecificCorrida.Rows
                                dtCorridas.ImportRow(row)
                            Next
                            dtCorridas.AcceptChanges()

                            'dt = dsImpresion.Tables("CatalogoArticulos").Copy
                            'dtCorridas = dsImpresion.Tables(1).Copy
                            'dt = oImpresionEtiquetasMgr.GetAll(False, oArticulo.CodArticulo).Tables("CatalogoArticulos")
                        Else
                            MessageBox.Show("El Articulo ya fue agregado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If

                    End If


                Else

                    'Precio Normal o Precio Oferta :

                    Dim strTipoPrecio As String
                    Dim Tipo As Integer = 1

                    If Me.rbFactory.Checked Then
                        Tipo = 2
                        strTipoPrecio = ""
                    ElseIf (rbPrecioNormal.Checked = True) Then
                        strTipoPrecio = "N"
                    ElseIf (rbPrecioOferta.Checked = True) Then
                        strTipoPrecio = "O"
                    End If


                    dsImpresion = oImpresionEtiquetasMgr.GetAll(False, , IIf(cbMarca.Value Is Nothing, "", Me.cbMarca.Value), IIf(cbFamilia.Value Is Nothing, "", _
                                                       Me.cbFamilia.Value), IIf(cbLinea.Value Is Nothing, "", Me.cbLinea.Value), strTipoPrecio, _
                                                       IIf(Me.cmbCategoria.Value Is Nothing, "", Me.cmbCategoria.Value), , Tipo)
                    dt = dsImpresion.Tables("CatalogoArticulos").Copy
                    dtCorridas = dsImpresion.Tables(1).Copy

                End If

            End If
        End If


        If (dt.Rows.Count = 0) Then

            MsgBox("No se encontraron Registros.", MsgBoxStyle.Exclamation, "DPTienda")
            grDetalle.DataSource = Nothing
            grdFactory.DataSource = Nothing

            Exit Sub

        End If

        If Me.rbFactory.Checked Then
            grdFactory.DataSource = dt
        Else
            grDetalle.DataSource = dt
        End If

        If Me.rbDportenis.Checked Then Sm_SetUpView()

        Dim oFacturaMgr As New DportenisPro.DPTienda.ApplicationUnits.Facturas.FacturaManager(oAppContext)

        'Barrer la tabla para ponerle los precios con descuento
        If Me.RdBtn53.Checked = True Then
            Exit Sub
        End If

        If rbPrecioNormal.Checked = False OrElse Me.rbFactory.Checked Then
            Dim oRow As DataRow
            For Each oRow In dt.Rows
                '****************************Condiciones de Venta********************************
                Dim oCondicionVenta As New CondicionesVtaSAP
                oCondicionVenta.Jerarquia = oRow!Jerarquia
                oCondicionVenta.CondMat = oRow!CodMarca
                oCondicionVenta.Material = oRow!CodArticulo
                If Not oAppContext.ApplicationConfiguration.Almacen = "053" Then
Cambio_053:
                    oCondicionVenta.OficinaVtas = "T" & oAppContext.ApplicationConfiguration.Almacen
                    oCondicionVenta.ListPrec = "Z1"
                    oCondicionVenta.CondPrec = "01"
                Else
                    GoTo Cambio_053
                    'oCondicionVenta.OficinaVtas = "C053"
                    'oCondicionVenta.ListPrec = "C1"
                    'oCondicionVenta.CondPrec = "01"
                End If
                oFacturaMgr.GetCondicionVenta(oCondicionVenta)
                Dim dblDesc As Decimal = 0.0
                Dim dblPrecIva As Decimal = 0.0
                'Si no tiene precio con IVA se borra
                If oRow!Precio = 0 Then
                    oRow.Delete()
                Else
                    If oCondicionVenta.DescPorcentaje > 0 Then
                        'Porcentaje Descuento
                        dblPrecIva = (oRow!Precio)
                        dblDesc = dblPrecIva * (oCondicionVenta.DescPorcentaje / 100)
                        oRow!PrecioOferta = Format(dblPrecIva - dblDesc, "Standard")
                        oRow!PorcentajeOferta = oCondicionVenta.DescPorcentaje
                        'Este es para cuando sea consulta en especifico
                        'y tenga precio de descuento se vean las ofertas
                        If (rbEspecifico.Checked = True) Then
                            If Me.rbDportenis.Checked Then
                                grDetalle.Tables(0).Columns("PrecioOferta").Visible = True

                                grDetalle.Tables(0).Columns("PorcentajeOferta").Visible = True
                            End If

                            'MsgBox("Estos Artículos cuentan con Precio de Oferta, por favor coloque en la impresora " & vbCrLf _
                            '        & "las etiquetas correspondientes.", MsgBoxStyle.Information, "DPTienda")
                        End If

                    Else
                        If oCondicionVenta.Descmonto > 0 Then
                            'Monto descuento
                            oRow!PrecioOferta = Format(oRow!Precio - oCondicionVenta.Descmonto, "Standard")
                            oRow!PorcentajeOferta = Format(oCondicionVenta.Descmonto, "Standard")
                            'Este es para cuando sea consulta en especifico
                            'y tenga precio de descuento se vean las ofertas
                            If (rbEspecifico.Checked = True) Then
                                If Me.rbDportenis.Checked Then
                                    grDetalle.Tables(0).Columns("PrecioOferta").Visible = True

                                    grDetalle.Tables(0).Columns("PorcentajeOferta").Visible = True
                                End If

                                MsgBox("Estos Artículos cuentan con Precio de Oferta, por favor coloque en la impresora " & vbCrLf _
                                        & "las etiquetas correspondientes.", MsgBoxStyle.Information, "DPTienda")
                            End If
                        Else
                            If oRow!PrecioOferta = 0 And rbEspecifico.Checked = False Then
                                'Si no Tiene Descuento se borra                            
                                oRow.Delete()
                            End If
                        End If
                    End If
                End If
            Next
            dt.AcceptChanges()
        End If

        If Me.rbDportenis.Checked Then
            For Each oRowMaterial As DataRow In dt.Rows
                If IsNumeric(oRowMaterial("CorridaInicial")) AndAlso oRowMaterial("CorridaInicial") <> 0 Then
                    'ExistenciasTallaMaxMin
                    'Truena si no le ponemos ese IF
                    If Not oArticulo Is Nothing Then

                        If (oArticulo.CodCorrida = "I13" OrElse oArticulo.CodCorrida = "IES") Then
                            'Saco la corrida Minima 
                            Dim strCorridaMin As String = oCatalogoArticulosMgr.SelectCorridaMaxMinImp(oRowMaterial("CodArticulo"), "Min")

                            If strCorridaMin <> "0" Then
                                oRowMaterial("CorridaInicial") = strCorridaMin
                            Else
                                strCorridaMin = oCatalogoArticulosMgr.SelectCorridaMaxMinImp(oRowMaterial("CodArticulo"), "MinMenor")
                                oRowMaterial("CorridaInicial") = strCorridaMin
                            End If

                            'Saco la corrida Maxima
                            Dim strCorridaMax As String = oCatalogoArticulosMgr.SelectCorridaMaxMinImp(oRowMaterial("CodArticulo"), "Max")

                            If strCorridaMax <> "0" Then
                                oRowMaterial("CorridaFinal") = strCorridaMax
                            Else
                                strCorridaMax = oCatalogoArticulosMgr.SelectCorridaMaxMinImp(oRowMaterial("CodArticulo"), "MaxMayor")
                                oRowMaterial("CorridaFinal") = strCorridaMax
                            End If


                        Else
                            Dim strCorrida As String() = oCatalogoArticulosMgr.SelectCorridaMaxMin(oRowMaterial("CodArticulo"))
                            oRowMaterial("CorridaInicial") = strCorrida(0)
                            oRowMaterial("CorridaFinal") = strCorrida(1)
                        End If

                    End If
                End If

            Next
        End If
        If rbEspecifico.Checked Then
            nebCantidad.Value = 0
            ebCodigo.Text = ""
            oArticulo = Nothing
        End If
        dt.AcceptChanges()

    End Sub

    Private Function Fm_bolValidarImpresion() As Boolean

        If (dt Is Nothing) Then

            MsgBox("No se tiene Registros disponibles.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If

        If (dt.Rows.Count = 0) Then

            MsgBox("No se tiene Registros disponibles.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If

        Return True

    End Function



    Private Sub Sm_Imprimir()

        If (Fm_bolValidarImpresion() = False) Then
            Exit Sub
        End If

        If (Me.RdBtn53.Checked = True Or Me.RdBtnEtiquetasZebra.Checked = True) Then
            Sm_EtiquetasTienda53PRINT()
        End If

        If Me.rbDportenis.Checked Then
            If (rbPrecioNormal.Checked = True) Then
                If oConfigCierreFI.ImprimirEtiquetasEnLaser = False Then
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'Forma anterior de imprimir las etiquetas de los precios de forma individual con la LX-300
                    '--------------------------------------------------------------------------------------------------------------------------------
                    Sm_EtiquetasPrecioNormalPRINT()
                Else
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'Nueva forma de imprimir las etiquetas de precios en la impresora laserjet OkiData
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'Sm_EtiquetasPreciosLaserPrint(True)
                    If oConfigCierreFI.EtiquetasTallas Then
                        Sm_NewEtiquetasPreciosLaserPrint(True)
                    Else
                        Sm_EtiquetasPreciosLaserPrint(True)
                    End If

                End If
            End If
            If (rbPrecioOferta.Checked = True) Then
                If oConfigCierreFI.ImprimirEtiquetasEnLaser = False Then
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'Forma anterior de imprimir las etiquetas de los precios de forma individual con la Epson LX-300
                    '--------------------------------------------------------------------------------------------------------------------------------
                    Sm_EtiquetasPrecioOfertaPRINT()
                Else
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'Nueva forma de imprimir las etiquetas de precios en la impresora laserjet OkiData
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'Sm_EtiquetasPreciosLaserPrint(False)
                    If oConfigCierreFI.EtiquetasTallas Then
                        Sm_NewEtiquetasPreciosLaserPrint(False)
                    Else
                        Sm_EtiquetasPreciosLaserPrint(False)
                    End If
                End If
            End If
            If (rbEspecifico.Checked = True) Then
                If (grDetalle.Tables(0).Columns("PrecioOferta").Visible = True) Then
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'Articulo con Descuento.
                    '--------------------------------------------------------------------------------------------------------------------------------
                    If oConfigCierreFI.ImprimirEtiquetasEnLaser = False Then
                        '----------------------------------------------------------------------------------------------------------------------------
                        'Forma anterior de imprimir las etiquetas de los precios de forma individual con la LX-300
                        '----------------------------------------------------------------------------------------------------------------------------
                        Sm_EtiquetasPrecioOfertaPRINT()
                    Else
                        '----------------------------------------------------------------------------------------------------------------------------
                        'Nueva forma de imprimir las etiquetas de precios en la impresora laserjet OkiData
                        '----------------------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.EtiquetasTallas Then
                            Sm_NewEtiquetasPreciosLaserPrint(False)
                        Else
                            Sm_EtiquetasPreciosLaserPrint(False)
                        End If
                    End If
                Else
                    'Articulo sin Descuento.
                    If oConfigCierreFI.ImprimirEtiquetasEnLaser = False Then
                        'Sm_EtiquetasPrecioNormalPRINT()
                        '----------------------------------------------------------------------------------------------------------------------------
                        'Forma anterior de imprimir las etiquetas de los precios de forma individual con la LX-300
                        '----------------------------------------------------------------------------------------------------------------------------
                        Sm_EtiquetasEspecificoPRINT()
                    Else
                        '--------------------------------------------------------------------------------------------------------------------------------
                        'Nueva forma de imprimir las etiquetas de precios en la impresora laserjet OkiData
                        '--------------------------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.EtiquetasTallas Then
                            Sm_NewEtiquetasPreciosLaserPrint(True)
                        Else
                            Sm_EtiquetasPreciosLaserPrint(True)
                        End If
                    End If
                End If
            End If
        Else
            '--------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 07.11.2013: Imprimimos las nuevas etiquetas Factory
            '--------------------------------------------------------------------------------------------------------------------------------
            Sm_EtiquetasPreciosFactoryLaserPrint()
        End If
    End Sub


    Private Sub Sm_FillcbMarca()

        cbMarca.DataSource = oCatalogoMarcasMgr.GetAll(True).Tables("CatalogoMarcas")
        cbMarca.DropDownList.Columns.Add("Cod")
        cbMarca.DropDownList.Columns.Add("Descripción")

        cbMarca.DropDownList.Columns("Cod").DataMember = "CodMarca"
        cbMarca.DropDownList.Columns("Cod").Width = 50
        cbMarca.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        cbMarca.DropDownList.Columns("Descripción").Width = 150

        cbMarca.DisplayMember = "Descripcion"
        cbMarca.ValueMember = "CodMarca"

    End Sub


    Private Sub Sm_FillcbLinea()

        cbLinea.DataSource = oCatalogoLineasMgr.GetAll(True).Tables("CatalogoLineas")
        cbLinea.DropDownList.Columns.Add("Cod")
        cbLinea.DropDownList.Columns.Add("Descripción")

        cbLinea.DropDownList.Columns("Cod").DataMember = "CodLinea"
        cbLinea.DropDownList.Columns("Cod").Width = 50
        cbLinea.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        cbLinea.DropDownList.Columns("Descripción").Width = 150

        cbLinea.DisplayMember = "Descripcion"
        cbLinea.ValueMember = "CodLinea"

    End Sub


    Private Sub Sm_FillcbFamilia()

        cbFamilia.DataSource = oCatalogoFamiliasMgr.GetAll(True).Tables("CatalogoFamilias")
        cbFamilia.DropDownList.Columns.Add("Cod")
        cbFamilia.DropDownList.Columns.Add("Descripción")

        cbFamilia.DropDownList.Columns("Cod").DataMember = "CodFamilia"
        cbFamilia.DropDownList.Columns("Cod").Width = 50
        cbFamilia.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        cbFamilia.DropDownList.Columns("Descripción").Width = 150

        cbFamilia.DisplayMember = "Descripcion"
        cbFamilia.ValueMember = "CodFamilia"

    End Sub

    Private Sub Sm_FillcbCategorias()

        With Me.cmbCategoria
            .DataSource = oCatalogoCatMgr.GetAll(True).Tables("CatalogoCategorias")
            .DropDownList.Columns.Add("Cod")
            .DropDownList.Columns.Add("Descripción")

            .DropDownList.Columns("Cod").DataMember = "CodCategoria"
            .DropDownList.Columns("Cod").Width = 50
            .DropDownList.Columns("Descripción").DataMember = "Descripcion"
            .DropDownList.Columns("Descripción").Width = 150

            .DisplayMember = "Descripcion"
            .ValueMember = "CodCategoria"
        End With

    End Sub

    Private Sub Sm_SetUpView()

        With grDetalle.Tables(0)

            .Columns("PrecioOferta").Caption = "Precio Oferta"

            If Me.RdBtn53.Checked = True Or Me.RdBtnEtiquetasZebra.Checked = True Then
                .Columns("PorcentajeOferta").Visible = False
                .Columns("PrecioOferta").Caption = "Precio Socio"
                .Columns("Cantidad").Visible = False
            End If

            If (rbPrecioNormal.Checked = True) Then

                .Columns("PrecioOferta").Visible = False

                .Columns("PorcentajeOferta").Visible = False
                .Columns("Cantidad").Visible = False

            ElseIf (rbEspecifico.Checked = True) Then
                'Esto Funcionaba antes ahora ya no
                .Columns("Cantidad").Visible = True
                If (oArticulo.Descuento = 0) Then

                    'En Caso de no contar con Descuento.

                    .Columns("PrecioOferta").Visible = False

                    .Columns("PorcentajeOferta").Visible = False



                Else

                    'En Caso de contar con Descuento.


                    .Columns("PrecioOferta").Visible = True

                    .Columns("PorcentajeOferta").Visible = True

                    MsgBox("Estos Artículos cuentan con Precio de Oferta, por favor coloque en la impresora " & vbCrLf _
                            & "las etiquetas correspondientes.", MsgBoxStyle.Information, "DPTienda")

                End If

            ElseIf (rbPrecioOferta.Checked = True) Then
                .Columns("Cantidad").Visible = False
                .Columns("PrecioOferta").Visible = True

                .Columns("PorcentajeOferta").Visible = True

            End If

        End With

    End Sub

    Private Sub pd_PrintPagePrecioNormal_Especifico(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim printFont As New System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular)
        Dim x As Integer = 100
        Dim y, pagina As Integer
        y = posicion
        contador = 0
        ' Draw a picture.
        'ev.Graphics.DrawImage(Image.FromFile("C:\Win_Vista_Button.jpg"), ev.Graphics.VisibleClipBounds)

        For i As Integer = c To dt.Rows.Count
            ev.Graphics.DrawString("$" & Format(CType(dt.Rows(i - 1).Item("precio"), String), "Standard"), printFont, SystemBrushes.ControlText, x + 50, y)
            ev.Graphics.DrawString(Format(CType(dt.Rows(i - 1).Item("corridaInicial"), String)) & " A " & Format(CType(dt.Rows(i - 1).Item("corridaFinal"), String), "Standard"), printFont, SystemBrushes.ControlText, x + 50, y + 110)
            ev.Graphics.DrawString(CType(dt.Rows(i - 1).Item("codArticulo"), String), printFont, SystemBrushes.ControlText, x, y + 190)

            posicion = posicion + 275

            contador = contador + 1
            a += 1
            If contador = 4 Then
                pagina += 1
                If pagina <= paginasTotales Then
                    c = i + 1
                    posicion = 0
                    ev.HasMorePages = True
                    Exit For
                Else
                    ev.HasMorePages = False
                End If
            End If
            y = posicion
        Next
        ' Indicate that this is the last page to print.
        'ev.HasMorePages = True

    End Sub

    ' Specifies what happens when the PrintPage event is raised.
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim printFont As New System.Drawing.Font("Roman", 12, System.Drawing.FontStyle.Regular)
        Dim x As Integer = 100
        Dim y, pagina As Integer
        y = posicion
        contador = 0
        ' Draw a picture.
        'ev.Graphics.DrawImage(Image.FromFile("C:\Win_Vista_Button.jpg"), ev.Graphics.VisibleClipBounds)


        For i As Integer = c To dt.Rows.Count
            ev.Graphics.DrawString("$" & Format(CType(dt.Rows(i - 1).Item("precio"), String), "Standard"), printFont, SystemBrushes.ControlText, x + 50, y)
            ev.Graphics.DrawString("$" & Format(CType(dt.Rows(i - 1).Item("precioOferta"), String), "Standard"), printFont, SystemBrushes.ControlText, x + 50, y + 110)
            ev.Graphics.DrawString(CType(dt.Rows(i - 1).Item("codArticulo"), String), printFont, SystemBrushes.ControlText, x, y + 190)

            posicion = posicion + 275

            contador = contador + 1
            a += 1
            If contador = 4 Then
                pagina += 1
                If pagina <= paginasTotales Then
                    c = i + 1
                    posicion = 0
                    ev.HasMorePages = True
                    Exit For
                Else
                    ev.HasMorePages = False
                End If
            End If
            'If a = dt.Rows.Count Then
            '    ev.HasMorePages = False
            'End If
            y = posicion
        Next

        ' Indicate that this is the last page to print.
        'ev.HasMorePages = True


    End Sub

    Private Sub Sm_EtiquetasPreciosLaserPrint(ByVal bNormal As Boolean)

        Try
1:          Dim dtEtiqueta As New DataTable("Etiquetas"), empezar As Integer, cantidad As Integer = 0
            Dim oRow As DataRow, oNewRow As DataRow = Nothing
2:          dtEtiqueta.Columns.Add("Precio", GetType(System.Decimal))
3:          dtEtiqueta.Columns.Add("Medidas", GetType(System.String))
4:          dtEtiqueta.Columns.Add("CodArticulo", GetType(System.String))
            'For empezar = 1 To CInt(ebEmpezar.Value) - 1 Step 1
            '    oNewRow = dtEtiqueta.NewRow()
            '    oNewRow("Precio") = DBNull.Value
            '    oNewRow("Medidas") = DBNull.Value
            '    oNewRow("CodArticulo") = DBNull.Value
            '    dtEtiqueta.Rows.Add(oNewRow)
            'Next
            For Each oRow In dt.Rows
                If rbEspecifico.Checked Then
                    cantidad = CInt(oRow("Cantidad"))
                    For empezar = 1 To cantidad Step 1
                        oNewRow = dtEtiqueta.NewRow
                        oNewRow("Precio") = oRow("Precio")
                        If bNormal Then
                            oNewRow("Medidas") = oRow("CorridaInicial") & "  -  " & oRow("CorridaFinal")
                        Else
                            oNewRow("Medidas") = oRow("PrecioOferta")
                        End If
                        oNewRow("CodArticulo") = oRow("CodArticulo")
                        dtEtiqueta.Rows.Add(oNewRow)
                    Next
                Else
5:                  oNewRow = dtEtiqueta.NewRow
6:                  oNewRow("Precio") = oRow("Precio")
                    If bNormal Then
7:                      oNewRow("Medidas") = oRow("CorridaInicial") & "  -  " & oRow("CorridaFinal")
                    Else
8:                      oNewRow("Medidas") = oRow("PrecioOferta")
                    End If
9:                  oNewRow("CodArticulo") = oRow("CodArticulo")
10:                 dtEtiqueta.Rows.Add(oNewRow)
                End If
            Next
11:         dtEtiqueta.AcceptChanges()

12:         Dim dtTemp As DataTable = dtEtiqueta.Clone
13:         Dim i As Integer, idx As Integer = 0
14:         Dim Empieza As Integer = Me.ebEmpezar.Value
15:         Dim orptEtiqueta As rptEtiquetasPrecios
16:         Dim Limite As Integer = dtEtiqueta.Rows.Count

SigueImpresion:

17:         dtTemp.Clear()
18:         For i = 1 To 17 - Empieza
19:             If idx < Limite Then
20:                 dtTemp.ImportRow(dtEtiqueta.Rows(idx))
                Else
                    Exit For
                End If
21:             idx += 1
            Next

22:         orptEtiqueta = New rptEtiquetasPrecios(bNormal, dtTemp, Empieza)

23:         orptEtiqueta.Run()

24:         orptEtiqueta.Document.Print(False, False)

            'Dim oRepView As New ReportViewerForm
            'oRepView.Report = orptEtiqueta
            'oRepView.Show()

25:         If idx < Limite Then
                Empieza = 1
                GoTo SigueImpresion
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al imprimir las etiquetas de precios: Linea " & Err.Erl)
            Throw ex
        End Try

    End Sub





    Private Sub Sm_NewEtiquetasPreciosLaserPrint(ByVal bNormal As Boolean)
        Try
            Dim empezar As Integer, talla As String, corrida As String, lstCorrida As ArrayList, index As Integer
            Dim rows() As DataRow
            Dim dtCorrida As DataTable
            Dim dtEtiqueta As New DataTable("Etiquetas")
            Dim oRow As DataRow, fila As DataRow, rowCorrida As DataRow
            dtEtiqueta.Columns.Add("Precio", GetType(System.Decimal))
            dtEtiqueta.Columns.Add("CodigoQR", GetType(System.String))
            dtEtiqueta.Columns.Add("CodArticulo", GetType(System.String))
            dtEtiqueta.Columns.Add("PrecioOferta", GetType(System.String))
            dtEtiqueta.Columns.Add("Linea", GetType(System.String))
            dtEtiqueta.Columns.Add("CodFamilia", GetType(String))
            dtEtiqueta.Columns.Add("Familia", GetType(String))
            dtEtiqueta.Columns.Add("Cantidad", GetType(System.Int32))
            dtEtiqueta.Columns.Add("Corrida1", GetType(System.String))
            dtEtiqueta.Columns.Add("Corrida2", GetType(System.String))
            For empezar = 1 To CInt(ebEmpezar.Value) - 1 Step 1
                fila = dtEtiqueta.NewRow()
                fila("Precio") = DBNull.Value
                fila("PrecioOferta") = DBNull.Value
                fila("CodFamilia") = DBNull.Value
                fila("Familia") = DBNull.Value
                fila("CodigoQR") = DBNull.Value
                fila("CodArticulo") = DBNull.Value
                fila("Linea") = DBNull.Value
                fila("Cantidad") = DBNull.Value
                fila("Corrida1") = DBNull.Value
                fila("Corrida2") = DBNull.Value
                dtEtiqueta.Rows.Add(fila)
            Next
            If rbEspecifico.Checked Then
                Dim cantidad As Integer = 0, corridaArt As String = ""
                For Each oRow In dt.Rows
                    cantidad = CInt(oRow("Cantidad"))
                    rows = dtCorridas.Select("CodArticulo='" & CStr(oRow("CodArticulo")) & "'")
                    If rows.Length > 0 Then
                        corridaArt = GetCorrida(CStr(oRow("CodArticulo")), rows(0), CStr(oRow("Linea")))
                    End If
                    For index = 1 To cantidad Step 1
                        fila = dtEtiqueta.NewRow()
                        fila("Precio") = oRow("Precio")
                        fila("PrecioOferta") = oRow("PrecioOferta")
                        fila("CodigoQR") = "http://eshop.dportenis.com.mx/webapp/wcs/stores/servlet/SearchDisplay?storeId=10001&catalogId=10051&sType=SimpleSearch&resultCatEntryType=2&searchTerm=" & oRow("CodArticulo")
                        fila("CodArticulo") = oRow("CodArticulo")
                        fila("Linea") = oRow("Linea")
                        fila("CodFamilia") = oRow("CodFamilia")
                        fila("Familia") = oRow("Familia")
                        fila("Cantidad") = oRow("Cantidad")
                        rowCorrida = dtCorridas.Rows(0)
                        fila("Corrida1") = corridaArt
                        'If lstCorrida.Count > 0 Then
                        '    fila("Corrida1") = lstCorrida(0)
                        '    If lstCorrida.Count > 1 Then
                        '        fila("Corrida2") = lstCorrida(1)
                        '    End If
                        'End If
                        dtEtiqueta.Rows.Add(fila)
                    Next
                Next
                'For index = 1 To CInt(nebCantidad.Value)
                '    For Each oRow In dt.Rows
                '        fila = dtEtiqueta.NewRow()
                '        fila("Precio") = oRow("Precio")
                '        fila("PrecioOferta") = oRow("PrecioOferta")
                '        fila("CodigoQR") = "http://eshop.dportenis.com.mx/webapp/wcs/stores/servlet/SearchDisplay?storeId=10001&catalogId=10051&sType=SimpleSearch&resultCatEntryType=2&searchTerm=" & oRow("CodArticulo")
                '        fila("CodArticulo") = oRow("CodArticulo")
                '        fila("Linea") = oRow("Linea")
                '        fila("CodFamilia") = oRow("CodFamilia")
                '        fila("Familia") = oRow("Familia")
                '        fila("Cantidad") = oRow("Cantidad")
                '        rowCorrida = dtCorridas.Rows(0)
                '        fila("Corrida1") = GetCorrida(CStr(oRow("CodArticulo")), rowCorrida, CStr(oRow("Linea")))
                '        'If lstCorrida.Count > 0 Then
                '        '    fila("Corrida1") = lstCorrida(0)
                '        '    If lstCorrida.Count > 1 Then
                '        '        fila("Corrida2") = lstCorrida(1)
                '        '    End If
                '        'End If
                '        dtEtiqueta.Rows.Add(fila)
                '    Next
                'Next
            Else
                For Each oRow In dt.Rows
                    fila = dtEtiqueta.NewRow()
                    fila("Precio") = oRow("Precio")
                    fila("PrecioOferta") = oRow("PrecioOferta")
                    fila("CodigoQR") = "http://eshop.dportenis.com.mx/webapp/wcs/stores/servlet/SearchDisplay?storeId=10001&catalogId=10051&sType=SimpleSearch&resultCatEntryType=2&searchTerm=" & oRow("CodArticulo")
                    fila("CodArticulo") = oRow("CodArticulo")
                    fila("Linea") = oRow("Linea")
                    fila("Linea") = oRow("Linea")
                    fila("CodFamilia") = oRow("CodFamilia")
                    fila("Cantidad") = oRow("Cantidad")
                    rows = dtCorridas.Select("CodArticulo='" & CStr(oRow("CodArticulo")) & "'")
                    If rows.Length > 0 Then
                        fila("Corrida1") = GetCorrida(CStr(oRow("CodArticulo")), rows(0), CStr(oRow("Linea")))
                    End If
                    '    lstCorrida = GetCorrida(rows(0), CStr(oRow("Linea")))
                    '    If lstCorrida.Count > 0 Then
                    '        fila("Corrida1") = lstCorrida(0)
                    '        If lstCorrida.Count > 1 Then
                    '            fila("Corrida2") = lstCorrida(1)
                    '        End If
                    '    End If
                    '    dtEtiqueta.Rows.Add(fila)
                    'End If
                    dtEtiqueta.Rows.Add(fila)
                Next
            End If
            dtEtiqueta.AcceptChanges()
            Dim Empieza As Integer = Me.ebEmpezar.Value
            Dim orptEtiqueta As rptNewEtiquetasPrecios
            Dim Limite As Integer = dtEtiqueta.Rows.Count
            'Dim oRepView As New ReportViewerForm
            orptEtiqueta = New rptNewEtiquetasPrecios(bNormal, dtEtiqueta, Empieza)

            orptEtiqueta.Run()
            orptEtiqueta.Document.Print(False, False)
            'oRepView.Report = orptEtiqueta
            'oRepView.Show()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al imprimir las etiquetas de precios: Linea " & Err.Erl)
            Throw ex
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 28/03/2014: Se Obtienen las corridas de los articulos
    '--------------------------------------------------------------------------------------------------------------------

    Public Function GetCorrida(ByVal CodArticulo As String, ByVal row As DataRow, ByVal linea As String) As String
        Dim index As Integer, talla As String, corrida As String, indexCorrida As Integer = 0, colum As Integer = 0
        Dim tipoTalla As String = ""
        Dim lista As New ArrayList, resultado As String = ""
        Dim lstNumero As New ArrayList
        tipoTalla = CStr(row("Descripcion"))
        Dim lstLista As ArrayList = GetTallasExistencia(row, CodArticulo)
        For Each talla In lstLista
            If talla <> String.Empty Then
                If IsNumeric(talla) = True Then
                    If tipoTalla.ToUpper().IndexOf("NACIONAL") <> -1 Or tipoTalla.ToUpper().IndexOf("NIÑOS-JOVEN") <> -1 Then
                        lstNumero.Add(Format(CDec(talla), "#.0"))
                    ElseIf tipoTalla.ToUpper().IndexOf("IMPORTADO") <> -1 Then
                        Select Case linea.ToUpper()
                            Case "CABALLERO"
                                lstNumero.Add(Format((CDec(talla) - 2) + 20, "#.0"))
                            Case "DAMA"
                                lstNumero.Add(Format((CDec(talla) - 3) + 20, "#.0"))
                            Case "BOYS", "GIRLS"
                                lstNumero.Add(Format((CDec(talla) - 1) + 20, "#.0"))
                            Case "NIÑOS ESCOLAR", "NIÑOS PRE ESCOLAR"
                                If CDec(talla) < 11 Then
                                    lstNumero.Add(Format((CDec(talla) - 1) + 20, "#.0"))
                                Else
                                    lstNumero.Add(Format((CDec(talla) + 6), "#.0"))
                                End If
                            Case "BEBE"
                                lstNumero.Add(Format((CDec(talla) + 6), "#.0"))
                            Case "UNISEX"
                                lstNumero.Add(Format(CDec(talla), "#.0"))
                        End Select
                    End If
                Else
                    lstNumero.Add(talla)
                End If
                indexCorrida += 1
            End If
        Next
        'For index = 1 To 20
        '    talla = CStr(row("C" & CStr(index).PadLeft(2, "0")))
        '    If talla <> String.Empty Then
        '        If oImpresionEtiquetasMgr.GetExistenciaArticulo(CodArticulo, talla) > 0 Then
        '            If IsNumeric(talla) = True Then
        '                If tipoTalla.ToUpper().IndexOf("NACIONAL") <> -1 Or tipoTalla.ToUpper().IndexOf("NIÑOS-JOVEN") <> -1 Then
        '                    lstNumero.Add(Format(CDec(row("C" & CStr(index).PadLeft(2, "0"))), "#.0"))
        '                    'corrida &= "    " & Format(CDec(row("C" & CStr(index).PadLeft(2, "0"))), "#.0")
        '                    'Select Case linea.ToUpper()
        '                    '    Case "CABALLERO"
        '                    '        corrida &= "          " & Format((CDec(talla) - 20) + 2, "#.0") & vbCrLf
        '                    '    Case "DAMA"
        '                    '        corrida &= "          " & Format((CDec(talla) - 20) + 3, "#.0") & vbCrLf
        '                    '    Case "BOYS", "GIRLS"
        '                    '        If tipoTalla.ToUpper().IndexOf("NIÑOS-JOVEN") <> -1 Then
        '                    '            If CDec(talla) < 20 Then
        '                    '                corrida &= "          " & Format(CDec(talla) - 6, "#.0") & vbCrLf
        '                    '            Else
        '                    '                corrida &= "          " & Format((CDec(talla) - 20) + 1, "#.0") & vbCrLf
        '                    '            End If
        '                    '        Else
        '                    '            corrida &= "          " & Format((CDec(talla) - 20) + 1, "#.0") & vbCrLf
        '                    '        End If
        '                    '    Case "NIÑOS ESCOLAR", "NIÑOS PRE ESCOLAR"
        '                    '        If CDec(talla) < 20 Then
        '                    '            corrida &= "          " & Format(CDec(talla) - 6, "#.0") & "C" & vbCrLf
        '                    '        Else
        '                    '            corrida &= "          " & Format((CDec(talla) - 20) + 1, "#.0") & "Y" & vbCrLf
        '                    '        End If
        '                    '    Case "BEBE"
        '                    '        corrida &= "          " & Format(CDec(talla) - 6, "#.0") & "C" & vbCrLf
        '                    '    Case "UNISEX"
        '                    '        corrida &= "          " & Format(CDec(talla), "#.0") & vbCrLf
        '                    'End Select
        '                ElseIf tipoTalla.ToUpper().IndexOf("IMPORTADO") <> -1 Then
        '                    'corrida &= Format(CDec(row("C" & CStr(index).PadLeft(2, "0"))), "#.0")
        '                    Select Case linea.ToUpper()
        '                        Case "CABALLERO"
        '                            lstNumero.Add(Format((CDec(talla) - 2) + 20, "#.0"))
        '                            'corrida &= "    " & Format((CDec(talla) - 2) + 20, "#.0")
        '                            'corrida &= "          " & Format(CDec(talla), "#.0") & vbCrLf
        '                        Case "DAMA"
        '                            lstNumero.Add(Format((CDec(talla) - 3) + 20, "#.0"))
        '                            'corrida &= "    " & Format((CDec(talla) - 3) + 20, "#.0")
        '                            'corrida &= "          " & Format(CDec(talla), "#.0") & vbCrLf
        '                        Case "BOYS", "GIRLS"
        '                            lstNumero.Add(Format((CDec(talla) - 1) + 20, "#.0"))
        '                            'corrida &= "    " & Format((CDec(talla) - 1) + 20, "#.0")
        '                            'corrida &= "          " & Format(CDec(talla), "#.0") & vbCrLf
        '                        Case "NIÑOS ESCOLAR", "NIÑOS PRE ESCOLAR"
        '                            If CDec(talla) < 20 Then
        '                                lstNumero.Add(Format((CDec(talla) + 6), "#.0"))
        '                                'corrida &= "    " & Format((CDec(talla) + 6), "#.0")
        '                                'corrida &= "          " & Format(CDec(talla), "#.0") & "C" & vbCrLf
        '                            Else
        '                                lstNumero.Add(Format((CDec(talla) - 1) + 20, "#.0"))
        '                                'corrida &= "    " & Format((CDec(talla) - 1) + 20, "#.0")
        '                                'corrida &= "          " & Format(CDec(talla), "#.0") & "Y" & vbCrLf
        '                            End If
        '                        Case "BEBE"
        '                            lstNumero.Add(Format((CDec(talla) + 6), "#.0"))
        '                            'corrida &= "    " & Format((CDec(talla) + 6), "#.0")
        '                            'corrida &= "          " & Format(CDec(talla), "#.0") & "C" & vbCrLf
        '                        Case "UNISEX"
        '                            lstNumero.Add(Format(CDec(talla), "#.0"))
        '                            'corrida &= "    " & Format(CDec(talla), "#.0")
        '                            'corrida &= "          " & Format(CDec(talla), "#.0") & vbCrLf
        '                    End Select
        '                End If
        '            Else
        '                lstNumero.Add(CStr(row("C" & CStr(index).PadLeft(2, "0"))))
        '                'corrida &= "    " & CStr(row("C" & CStr(index).PadLeft(2, "0"))) & "          " & CStr(row("C" & CStr(index).PadLeft(2, "0"))) & vbCrLf
        '            End If
        '            indexCorrida += 1
        '        End If
        '    End If
        '    'If indexCorrida = 7 Then
        '    '    indexCorrida = 0
        '    '    lista.Add(corrida)
        '    '    corrida = ""
        '    'End If
        'Next
        If lstNumero.Count > 0 Then
            Dim arreglo As Array = lstNumero.ToArray(GetType(String))
            resultado = String.Join(",", arreglo)
        End If
        Return resultado
    End Function

    '-------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/06/2014: Obtiene la tallas que tienen existencia
    '-------------------------------------------------------------------------------------------------------------------

    Public Function GetTallasExistencia(ByVal row As DataRow, ByVal CodArticulo As String) As ArrayList
        Dim index As Integer = 1, tallas As String = "", talla As String = ""
        Dim lstTallas As New ArrayList
        For index = 1 To 20 Step 1
            talla = CStr(row("C" & CStr(index).PadLeft(2, "0")))
            If talla <> "" Then
                tallas &= "'" & talla & "',"
            End If
        Next
        If tallas.Length > 0 Then
            tallas = tallas.Remove(tallas.Length - 1, 1)
        End If
        Dim dtTallas As DataTable = oImpresionEtiquetasMgr.GetCorridaExistencia(CodArticulo, tallas)
        Dim esNumerico As Boolean = False, numero As String = ""
        For Each fila As DataRow In dtTallas.Rows
            numero = CStr(fila("Numero"))
            If IsNumeric(numero) Then
                esNumerico = True
                lstTallas.Add(CDec(numero))
            Else
                lstTallas.Add(CStr(fila("Numero")))
            End If
        Next
        If esNumerico Then
            lstTallas.Sort()
        End If
        Return lstTallas
    End Function

    Private Sub Sm_EtiquetasPreciosFactoryLaserPrint()

        Try
1:          Dim dtEtiqueta As New DataTable("Etiquetas")
            Dim oRow As DataRow
2:          dtEtiqueta.Columns.Add("Precio", GetType(System.Decimal))
3:          dtEtiqueta.Columns.Add("PrecioOferta", GetType(System.String))
4:          dtEtiqueta.Columns.Add("Talla", GetType(System.String))
30:         dtEtiqueta.Columns.Add("UPC", GetType(System.String))
31:         dtEtiqueta.Columns.Add("CodArticulo", GetType(System.String))
32:         dtEtiqueta.Columns.Add("Cantidad", GetType(System.Int32))

            For Each oRow In dt.Rows
5:              Dim oNewRow As DataRow = dtEtiqueta.NewRow
6:              oNewRow("Precio") = oRow("Precio")
8:              oNewRow("PrecioOferta") = oRow("PrecioOferta")
9:              oNewRow("CodArticulo") = oRow("CodArticulo")
                oNewRow("Talla") = oRow("Talla")
                oNewRow("UPC") = oRow("CodUPC")
                oNewRow("Cantidad") = oRow("Cantidad")
10:             dtEtiqueta.Rows.Add(oNewRow)
            Next
11:         dtEtiqueta.AcceptChanges()

12:         Dim dtTemp As DataTable = dtEtiqueta.Clone
13:         Dim i As Integer, Cont As Integer = 1, j As Integer
14:         Dim Empieza As Integer = Me.ebEmpezar.Value
15:         Dim orptEtiqueta As rptEtiquetasPreciosFactory
16:         Dim Limite As Integer = dtEtiqueta.Rows.Count, Cantidad As Integer = 0
            '----------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 11.11.2013: Imprimimos tantas etiquetas como cantidad tenga en existencia cada codigo en cada talla
            '----------------------------------------------------------------------------------------------------------------------------------------
            For i = 0 To Limite - 1
17:             Cantidad = dtEtiqueta.Rows(i)!Cantidad
                For j = 0 To Cantidad - 1
18:                 dtTemp.ImportRow(dtEtiqueta.Rows(i))
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 11.11.2013: Imprimimos cada 16 registros o si son menos de 16 pero ya es el ultimo registro
                    '--------------------------------------------------------------------------------------------------------------------------------
19:                 If Cont Mod 16 = 0 OrElse (j = Cantidad - 1 AndAlso i = Limite - 1) Then
20:                     orptEtiqueta = New rptEtiquetasPreciosFactory(dtTemp, Empieza)
21:                     orptEtiqueta.Run()

22:                     orptEtiqueta.Document.Print(False, False)

                        '23:                     Dim oRepView As New ReportViewerForm
                        '24:                     oRepView.Report = orptEtiqueta
                        '25:                     oRepView.Show()

26:                     dtTemp.Clear()
27:                     Cont = 0
28:                     Empieza = 1
                    End If
29:                 Cont += 1
                Next
            Next

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al imprimir las etiquetas de precios: Linea " & Err.Erl)
            MessageBox.Show("Ocurrió un error al imprimir las etiquetas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub Sm_EtiquetasPrecioOfertaPRINT()
        'Dim pd As New PrintDocument
        'Try
        '    posicion = 0
        '    contador = 0
        '    paginasTotales = dt.Rows.Count / 4
        '    paginasTotales = paginasTotales + IIf(dt.Rows.Count Mod 4 > 0, 1, 0)
        '    c = 1
        '    a = 0
        '    ' Assumes the default printer.

        '    AddHandler pd.PrintPage, AddressOf pd_PrintPage
        '    pd.Print()
        'Catch ex As Exception
        '    MessageBox.Show("An error occurred while printing", _
        '        ex.ToString())
        'End Try
        'pd = Nothing

        '''''''''Inicio Codigo Erick
        Dim dtEtiqueta As New DataTable("Etiquetas")
        dtEtiqueta.Columns.Add("Precio", GetType(System.Decimal))
        dtEtiqueta.Columns.Add("Medidas", GetType(System.String))
        dtEtiqueta.Columns.Add("CodArticulo", GetType(System.String))

        For Each oRow As DataRow In dt.Rows
            Dim oNewRow As DataRow = dtEtiqueta.NewRow
            oNewRow("Precio") = oRow("Precio")
            oNewRow("Medidas") = oRow("PrecioOferta")
            oNewRow("CodArticulo") = oRow("CodArticulo")
            dtEtiqueta.Rows.Add(oNewRow)
        Next
        dtEtiqueta.AcceptChanges()

        Dim orptEtiqueta As New rptEtiqueta
        orptEtiqueta.DataSource = dtEtiqueta
        'Opciones Hojas
        orptEtiqueta.PageSettings.DefaultPaperSize = False
        orptEtiqueta.PageSettings.DefaultPaperSource = False

        'orptEtiqueta.PageSettings.PaperSource = System.Drawing.Printing.PaperSourceKind.TractorFeed
        orptEtiqueta.PageSettings.Margins.Bottom = 0
        orptEtiqueta.PageSettings.Margins.Top = 0.04
        orptEtiqueta.PageSettings.Margins.Left = 1.06
        orptEtiqueta.PageSettings.Margins.Right = 0.5
        orptEtiqueta.PageSettings.PaperHeight = 2.75
        orptEtiqueta.PageSettings.PaperWidth = 3.875
        orptEtiqueta.Run()

        orptEtiqueta.Document.Print(False, False)

        'Dim oRepView As New ReportViewerForm
        'oRepView.Report = orptEtiqueta
        'oRepView.Show()
        '''''''''Fin Codigo Erick


        'intPosEtq += 0

        'Dim oPrinterNET As New ClsPrinter

        'Dim strLine As String

        'Dim intIndexEtiqueta As Integer

        'With oPrinterNET

        '    '.PORT = "LPT1"
        '    .PORT = "USB001"

        '    .OpenPORT()

        '    For Each dr In dt.Rows

        '        intPosEtq += 1

        '        strLine = Chr(27) + Chr(14) + Chr(27) + Chr(15) + Space(3) + "$" + _
        '                  Format(CType(dr!Precio, String), "Standard") + Chr(27) + Chr(18) + Chr(27) + Chr(20)
        '        .PrintPORT(strLine)

        '        If intPosEtq = 2 Then
        '            strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        '            intPosEtq = 0
        '        Else
        '            strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        '        End If

        '        .PrintPORT(strLine)

        '        strLine = Chr(27) + Chr(14) + Chr(27) + Chr(15) + Space(3) + "$" + _
        '                  Format(CType(dr!PrecioOferta, String), "Standard") + Chr(27) + Chr(33) + Chr(0)
        '        .PrintPORT(strLine)

        '        strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        '        .PrintPORT(strLine)

        '        strLine = Space(3) + CType(dr!CodArticulo, String) + Chr(27) + Chr(33) + Chr(1)
        '        .PrintPORT(strLine)

        '        'Alineamos impresora
        '        strLine = vbCrLf + vbCrLf + vbCrLf + vbCrLf + vbCrLf
        '        .PrintPORT(strLine)

        '    Next

        '    .ClosePORT()

        'End With

    End Sub

    Private Sub Sm_EtiquetasTienda53PRINT()

        For Each dr In dt.Rows

            Dim pd1 As New PrintDialog

            pd1.PrinterSettings = New System.Drawing.Printing.PrinterSettings

            pd1.PrinterSettings.PrinterName = "Zebra  Z4M Plus (300dpi)"

            Dim PrintStr As String = _
            "^XA^CFD^FS" & Chr(10) & _
            "^PON^FS" & Chr(10) & _
            "^FWN^FS" & Chr(10) & _
            "^LH020,30^FS" & Chr(10) & _
            "^FO0,0^A0,N,28,28^FD" & "Precio Pub. Gral.: " & Format(dr!Precio, "currency") & "^FS" & Chr(10) & _
            "^FO0,60^A0,N,28,28^FD" & "Precio Socio: " & Format((CDec(dr!PrecioOferta) * (1 + oAppContext.ApplicationConfiguration.IVA)), "currency") & "^FS" & Chr(10) & _
            "^FO0,120^A0,N,28,28^FD" & "Codigo: " & CType(dr!CodArticulo, String) & "^FS" & Chr(10) & _
            "^PQ1" & Chr(10) & _
            "^XZ"

            cRawPrinterHelper.SendStringToPrinter(pd1.PrinterSettings.PrinterName, PrintStr)

        Next


    End Sub

    Private Sub Sm_EtiquetasPrecioNormalPRINT()

        'Dim pd As New PrintDocument
        'Try
        '    posicion = 0
        '    contador = 0
        '    paginasTotales = dt.Rows.Count / 4
        '    paginasTotales = paginasTotales + IIf(dt.Rows.Count Mod 4 > 0, 1, 0)
        '    c = 1
        '    a = 0
        '    ' Assumes the default printer.  

        '    AddHandler pd.PrintPage, AddressOf pd_PrintPagePrecioNormal_Especifico
        '    pd.Print()
        'Catch ex As Exception
        '    MessageBox.Show("An error occurred while printing", _
        '        ex.ToString())
        'End Try
        'pd = Nothing
        '''''''''Inicio Codigo Erick
        Dim dtEtiqueta As New DataTable("Etiquetas")
        Dim oRow As DataRow
        dtEtiqueta.Columns.Add("Precio", GetType(System.Decimal))
        dtEtiqueta.Columns.Add("Medidas", GetType(System.String))
        dtEtiqueta.Columns.Add("CodArticulo", GetType(System.String))

        For Each oRow In dt.Rows
            Dim oNewRow As DataRow = dtEtiqueta.NewRow
            oNewRow("Precio") = oRow("Precio")
            oNewRow("Medidas") = oRow("CorridaInicial") & "  -  " & oRow("CorridaFinal")
            oNewRow("CodArticulo") = oRow("CodArticulo")
            dtEtiqueta.Rows.Add(oNewRow)
        Next
        dtEtiqueta.AcceptChanges()

        Dim orptEtiqueta As New rptEtiqueta
        orptEtiqueta.DataSource = dtEtiqueta
        'Opciones Hojas
        orptEtiqueta.PageSettings.DefaultPaperSize = False
        orptEtiqueta.PageSettings.DefaultPaperSource = False

        'orptEtiqueta.PageSettings.PaperSource = System.Drawing.Printing.PaperSourceKind.TractorFeed
        orptEtiqueta.PageSettings.Margins.Bottom = 0
        orptEtiqueta.PageSettings.Margins.Top = 0
        orptEtiqueta.PageSettings.Margins.Left = 1.0
        orptEtiqueta.PageSettings.Margins.Right = 0.5
        orptEtiqueta.PageSettings.PaperHeight = 2.75
        orptEtiqueta.PageSettings.PaperWidth = 3.875
        orptEtiqueta.Run()

        orptEtiqueta.Document.Print(False, False)

        'Dim oRepView As New ReportViewerForm
        'oRepView.Report = orptEtiqueta
        'oRepView.Show()

        '''''''''Fin Codigo Erick
        'intPosEtq += 0

        'Dim oPrinterNET As New ClsPrinter

        'Dim strLine As String

        'Dim intIndexEtiqueta As Integer

        'With oPrinterNET

        '    .PORT = "LPT1"
        '    '.PORT = "USB"

        '    .OpenPORT()

        '    For Each dr In dt.Rows

        '        intPosEtq += 1

        '        strLine = Chr(27) + Chr(14) + Chr(27) + Chr(15) + Space(3) + "$" + _
        '                  Format(CType(dr!Precio, String), "Standard") + Chr(27) + Chr(18) + Chr(27) + Chr(20)
        '        .PrintPORT(strLine)

        '        If intPosEtq = 2 Then
        '            strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        '            intPosEtq = 0
        '        Else
        '            strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        '        End If

        '        .PrintPORT(strLine)

        '        strLine = Chr(27) + Chr(33) + Chr(0) + Space(3) + CType(dr!CorridaInicial, String) & _
        '                  "  A  " & CType(dr!CorridaFinal, String)
        '        .PrintPORT(strLine)

        '        strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        '        .PrintPORT(strLine)

        '        strLine = Space(3) + CType(dr!CodArticulo, String) + Chr(27) + Chr(33) + Chr(1)
        '        .PrintPORT(strLine)

        '        'Alineamos impresora
        '        strLine = vbCrLf + vbCrLf + vbCrLf + vbCrLf + vbCrLf
        '        .PrintPORT(strLine)

        '    Next

        '    .ClosePORT()

        'End With

    End Sub

    Private Sub Sm_EtiquetasEspecificoPRINT()
        'Dim pd As New PrintDocument
        'Try
        '    ' Assumes the default printer.
        '    posicion = 0
        '    contador = 0
        '    paginasTotales = dt.Rows.Count / 4
        '    paginasTotales = paginasTotales + IIf(dt.Rows.Count Mod 4 > 0, 1, 0)
        '    c = 1
        '    a = 0

        '    AddHandler pd.PrintPage, AddressOf pd_PrintPagePrecioNormal_Especifico
        '    pd.Print()
        'Catch ex As Exception
        '    MessageBox.Show("An error occurred while printing", _
        '        ex.ToString())
        'End Try
        'pd = Nothing

        '''''''''Inicio Codigo Erick
        Dim dtEtiqueta As New DataTable("Etiquetas")
        dtEtiqueta.Columns.Add("Precio", GetType(System.Decimal))
        dtEtiqueta.Columns.Add("Medidas", GetType(System.String))
        dtEtiqueta.Columns.Add("CodArticulo", GetType(System.String))

        For Each oRow As DataRow In dt.Rows
            Dim oNewRow As DataRow = dtEtiqueta.NewRow
            oNewRow("Precio") = oRow("Precio")
            oNewRow("Medidas") = oRow("CorridaInicial") & "  -  " & oRow("CorridaFinal")
            oNewRow("CodArticulo") = oRow("CodArticulo")
            dtEtiqueta.Rows.Add(oNewRow)
        Next
        dtEtiqueta.AcceptChanges()

        Dim orptEtiqueta As New rptEtiqueta
        orptEtiqueta.DataSource = dtEtiqueta
        'Opciones Hojas
        orptEtiqueta.PageSettings.DefaultPaperSize = False
        orptEtiqueta.PageSettings.DefaultPaperSource = False

        'orptEtiqueta.PageSettings.PaperSource = System.Drawing.Printing.PaperSourceKind.TractorFeed
        orptEtiqueta.PageSettings.Margins.Bottom = 0
        orptEtiqueta.PageSettings.Margins.Top = 0
        orptEtiqueta.PageSettings.Margins.Left = 1.0
        orptEtiqueta.PageSettings.Margins.Right = 0.5
        orptEtiqueta.PageSettings.PaperHeight = 2.75
        orptEtiqueta.PageSettings.PaperWidth = 3.875
        orptEtiqueta.Run()

        orptEtiqueta.Document.Print(False, False)

        'Dim oRepView As New ReportViewerForm
        'oRepView.Report = orptEtiqueta
        'oRepView.Show()

        '''''''''Fin Codigo Erick
        'Dim oPrinterNET As New ClsPrinter

        'Dim strLine As String

        'Dim intIndexEtiqueta As Integer

        'With oPrinterNET

        '    .PORT = "LPT1"

        '    .OpenPORT()

        '    For Each dr In dt.Rows

        '        intPosEtq += 1

        '        strLine = Chr(27) + Chr(14) + Chr(27) + Chr(15) + Space(3) + "$" + _
        '                  Format(CType(dr!Precio, String), "Standard") + Chr(27) + Chr(18) + Chr(27) + Chr(20)

        '        .PrintPORT(strLine)

        '        If intPosEtq = 2 Then
        '            strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        '            intPosEtq = 0
        '        Else
        '            strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        '        End If

        '        .PrintPORT(strLine)

        '        strLine = Chr(27) + Chr(33) + Chr(0) + Space(3) + CType(dr!CorridaInicial, String) & _
        '                  "  A  " & CType(dr!CorridaFinal, String)
        '        .PrintPORT(strLine)

        '        strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        '        .PrintPORT(strLine)

        '        strLine = Space(3) + CType(dr!CodArticulo, String) + Chr(27) + Chr(33) + Chr(1)
        '        .PrintPORT(strLine)

        '    Next

        '    'Alineamos impresora
        '    strLine = vbCrLf + vbCrLf + vbCrLf + vbCrLf + vbCrLf
        '    .PrintPORT(strLine)

        '    .ClosePORT()

        'End With

    End Sub

    Private Sub ActualizarVistaPrevia()

        Dim Lim As Integer = Me.ebEmpezar.Value - 2
        Dim i As Integer = 0
        '-------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 08.11.2013: Actualizamos la vista previa segun el tipo de etiqueta este seleccionado
        '-------------------------------------------------------------------------------------------------------------------------------------
        If Me.rbFactory.Checked Then
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Mostramos todas las etiquetas
            '-------------------------------------------------------------------------------------------------------------------------------------
            For i = 0 To pbFactory.Count - 1
                pbFactory.Item("pbEtiquetaF_" & i).Visible = True
            Next
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Ocultamos las etiquetas necesarias según donde el usuario quiere empezar a imprimir
            '-------------------------------------------------------------------------------------------------------------------------------------
            If Lim >= 0 Then
                For i = 0 To Lim
                    pbFactory.Item("pbEtiquetaF_" & i).Visible = False
                Next
            End If
        Else
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Mostramos todas las etiquetas
            '-------------------------------------------------------------------------------------------------------------------------------------
            For i = 0 To pb.Count - 1
                pb.Item("pbEtiqueta_" & i).Visible = True
            Next
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Ocultamos las etiquetas necesarias según donde el usuario quiere empezar a imprimir
            '-------------------------------------------------------------------------------------------------------------------------------------
            If Lim >= 0 Then
                For i = 0 To Lim
                    pb.Item("pbEtiqueta_" & i).Visible = False
                Next
            End If
        End If

    End Sub

    Private Sub MostrarOpciones()

        If Me.rbFactory.Checked Then
            MostrarCamposFactory(Me.rbEspecifico.Checked)
            Me.rbPrecioNormal.Text = "Todas"
            Me.grpFactory.Visible = True
            Me.grdFactory.Visible = True
            Me.grpVistaPrevia.Visible = False
            Me.grDetalle.Visible = False
        Else
            MostrarCamposFactory(False)
            Me.rbPrecioNormal.Text = "Precio Normal"
            Me.grpFactory.Visible = False
            Me.grdFactory.Visible = False
            Me.grpVistaPrevia.Visible = True
            Me.grDetalle.Visible = True
            If Me.rbEspecifico.Checked Then
                Me.nebCantidad.Visible = True
                Me.lblCantidad.Visible = True
                Me.lblCantidad.Top = 216
                Me.nebCantidad.Top = 208
            End If
        End If

        If Me.rbFactory.Checked AndAlso Me.rbPrecioOferta.Checked Then rbEspecifico.Checked = True
        ActualizarVistaPrevia()

        Me.rbPrecioOferta.Visible = Not Me.rbFactory.Checked
        Me.rbPrecioOferta.Visible = Not Me.rbFactory.Checked

        Dim bHabilitar As Boolean

        If Me.rbEspecifico.Checked Then
            bHabilitar = False
        ElseIf Me.rbPrecioNormal.Checked OrElse Me.rbPrecioOferta.Checked Then
            bHabilitar = True
        End If

        Sm_HabilitarCombos(bHabilitar)

        oArticulo = Nothing

        dt = Nothing

        grDetalle.DataSource = Nothing

        If Me.rbEspecifico.Checked Then
            ebCodigo.Focus()
        ElseIf Me.rbPrecioNormal.Checked OrElse Me.rbPrecioOferta.Checked Then
            Me.cbMarca.Focus()
        End If

    End Sub

    Private Sub MostrarCamposFactory(ByVal bMostrar As Boolean)

        Me.lblTalla.Visible = bMostrar
        Me.lblCantidad.Visible = bMostrar
        Me.ebTalla.Visible = bMostrar
        Me.nebCantidad.Visible = bMostrar
        Me.lblCategoria.Visible = bMostrar
        Me.cmbCategoria.Visible = bMostrar

    End Sub

#End Region



#Region "Métodos Privados [Eventos]"

    Private Sub FrmImpresionEtiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()

    End Sub



    Private Sub FrmImpresionEtiquetas_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_Finalizar()

    End Sub



    Private Sub FrmImpresionEtiquetas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub RdBtn53_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdBtn53.Click

        Sm_HabilitarCombos(False)

        oArticulo = Nothing

        dt = Nothing

        grDetalle.DataSource = Nothing

        ebCodigo.Focus()

    End Sub


    Private Sub RdBtnEtiquetasZebra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdBtnEtiquetasZebra.Click

        Sm_HabilitarCombos(True)

        oArticulo = Nothing

        dt = Nothing

        grDetalle.DataSource = Nothing

        ebCodigo.Focus()

    End Sub


    Private Sub btBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscar.Click

        Sm_BuscarArticulos()

    End Sub



    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Me.btBuscar.Focus()
        Me.btnImprimir.Enabled = False

        'Dim oTest As New rptFactoryTest
        'Dim oView As New ReportViewerForm
        'oTest.Run()

        'oView.Report = oTest
        'oView.Show()
        Sm_Imprimir()

        Me.btnImprimir.Enabled = True

        'Sm_Print()

    End Sub



    Private Sub ebCodigo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.ButtonClick

        Sm_BuscarArticulo(True)

    End Sub



    Private Sub ebCodigo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodigo.Validating

        If (ebCodigo.Text.Trim <> String.Empty) Then

            Sm_BuscarArticulo()

        End If

    End Sub



    Private Sub ebCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigo.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarArticulo(True)

        End If

    End Sub

    Private Sub ebEmpezar_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebEmpezar.ValueChanged
        ActualizarVistaPrevia()
    End Sub

    Private Sub rbEspecifico_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbEspecifico.CheckedChanged, rbPrecioNormal.CheckedChanged, rbPrecioOferta.CheckedChanged, rbDportenis.CheckedChanged, rbFactory.CheckedChanged
        MostrarOpciones()
    End Sub

#End Region

#Region "Metodos Filtros y Descuentos"

    Public Sub SetCodArticulo(ByVal codigo As String)
        rbDportenis.Checked = True
        rbEspecifico.Checked = True
        ebCodigo.Text = codigo
        nebCantidad.Value = 1
        oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)
        Sm_BuscarArticulo()
    End Sub

#End Region

#Region "Etiquetas Tallas"
    '-------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2014: Verifica que imagen poner a las etiquetas en caso de ser las normales
    '-------------------------------------------------------------------------------------------------------------------

    Private Sub SetImagePictureBox()
        Dim pic As PictureBox = Nothing
        For i As Integer = 0 To pb.Count - 1
            pic = CType(pb.Item("pbEtiqueta_" & i), PictureBox)
            If oConfigCierreFI.EtiquetasTallas Then
                pic.Image = Image.FromFile(Application.StartupPath & "/NuevaEtiquetaDP.png")
            Else
                pic.Image = Image.FromFile(Application.StartupPath & "/EtiquetaPrecioNormal.jpg")
            End If
        Next
    End Sub
#End Region

#Region "Multicódigos en Etiquetas especificas"

    Private Function IsCodArticuloInGrid(ByVal CodArticulo As String) As Boolean
        If Not grDetalle.DataSource Is Nothing Then
            Dim dtGrid As DataTable = CType(grDetalle.DataSource, DataTable)
            For Each row As DataRow In dtGrid.Rows
                If CStr(row("CodArticulo")) = CodArticulo Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

#End Region

    Private Sub grDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                If rbEspecifico.Checked = True AndAlso rbDportenis.Checked = True Then
                    Dim row As GridEXRow = grDetalle.GetRow()
                    If Not row Is Nothing Then
                        If MessageBox.Show("¿Estas seguro de eliminar el artículo", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            CType(grDetalle.DataSource, DataTable).Rows.RemoveAt(grDetalle.Row)
                        End If

                    End If
                End If
        End Select
    End Sub

    Private Sub grDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grDetalle.KeyPress

    End Sub
End Class
