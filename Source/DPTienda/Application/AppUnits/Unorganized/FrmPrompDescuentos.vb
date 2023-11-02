Imports DportenisPro.DPTienda.ApplicationUnits.InicioDia
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUsos
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DportenisPro.DPTienda.Reports.Inventario
Imports System.IO
Imports Janus.Windows.GridEX
Imports Microsoft.Office.Interop


Public Class FrmPrompDescuentos
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        InitializeReporte()

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
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents groupFiltros As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents lblLinea As System.Windows.Forms.Label
    Friend WithEvents lblFamilia As System.Windows.Forms.Label
    Friend WithEvents lblUso As System.Windows.Forms.Label
    Friend WithEvents groupDescuento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents UCmbBxDescuento As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents UBtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents UBtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cbImagen As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents imgArticulo As System.Windows.Forms.PictureBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents lblOferta As System.Windows.Forms.Label
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents txtPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtOferta As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Protected Friend WithEvents geResults As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnImprimirEtiquetas As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbMarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbLinea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbFamilia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbUso As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrompDescuentos))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout5 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.geResults = New Janus.Windows.GridEX.GridEX()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnImprimirEtiquetas = New Janus.Windows.EditControls.UIButton()
        Me.txtDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtOferta = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPrecio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.lblOferta = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.imgArticulo = New System.Windows.Forms.PictureBox()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.UiButton2 = New Janus.Windows.EditControls.UIButton()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.groupDescuento = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbImagen = New Janus.Windows.EditControls.UICheckBox()
        Me.UBtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.UBtnOk = New Janus.Windows.EditControls.UIButton()
        Me.UCmbBxDescuento = New Janus.Windows.EditControls.UIComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.groupFiltros = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbUso = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbFamilia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbLinea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblUso = New System.Windows.Forms.Label()
        Me.lblFamilia = New System.Windows.Forms.Label()
        Me.lblLinea = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.cmbMarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.imgArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.groupDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupDescuento.SuspendLayout()
        CType(Me.groupFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.Controls.Add(Me.geResults)
        Me.ExplorerBar2.Controls.Add(Me.ExplorerBar1)
        Me.ExplorerBar2.Controls.Add(Me.btnExportar)
        Me.ExplorerBar2.Controls.Add(Me.btnImprimir)
        Me.ExplorerBar2.Controls.Add(Me.UiButton2)
        Me.ExplorerBar2.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar2.Controls.Add(Me.groupDescuento)
        Me.ExplorerBar2.Controls.Add(Me.groupFiltros)
        Me.ExplorerBar2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(856, 550)
        Me.ExplorerBar2.TabIndex = 2
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'geResults
        '
        Me.geResults.AllowColumnDrag = False
        Me.geResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.geResults.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken
        Me.geResults.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        Me.geResults.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.geResults.DesignTimeLayout = GridEXLayout1
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.geResults.GroupByBoxVisible = False
        Me.geResults.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.geResults.Location = New System.Drawing.Point(8, 200)
        Me.geResults.Name = "geResults"
        Me.geResults.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.geResults.ShowEmptyFields = False
        Me.geResults.Size = New System.Drawing.Size(832, 334)
        Me.geResults.TabIndex = 20
        Me.geResults.TabStop = False
        Me.geResults.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnImprimirEtiquetas)
        Me.ExplorerBar1.Controls.Add(Me.txtDescuento)
        Me.ExplorerBar1.Controls.Add(Me.txtOferta)
        Me.ExplorerBar1.Controls.Add(Me.txtPrecio)
        Me.ExplorerBar1.Controls.Add(Me.lblDescuento)
        Me.ExplorerBar1.Controls.Add(Me.lblOferta)
        Me.ExplorerBar1.Controls.Add(Me.lblPrecio)
        Me.ExplorerBar1.Controls.Add(Me.lblNombre)
        Me.ExplorerBar1.Controls.Add(Me.lblCodigo)
        Me.ExplorerBar1.Controls.Add(Me.imgArticulo)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Fotografia del Artículo"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(512, 14)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(328, 170)
        Me.ExplorerBar1.TabIndex = 19
        Me.ExplorerBar1.Text = "Fotografia del Articulo"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnImprimirEtiquetas
        '
        Me.btnImprimirEtiquetas.Location = New System.Drawing.Point(160, 142)
        Me.btnImprimirEtiquetas.Name = "btnImprimirEtiquetas"
        Me.btnImprimirEtiquetas.Size = New System.Drawing.Size(112, 24)
        Me.btnImprimirEtiquetas.TabIndex = 10
        Me.btnImprimirEtiquetas.Text = "Imprimir Etiquetas"
        Me.btnImprimirEtiquetas.Visible = False
        Me.btnImprimirEtiquetas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtDescuento
        '
        Me.txtDescuento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtDescuento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtDescuento.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtDescuento.Location = New System.Drawing.Point(232, 74)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(88, 20)
        Me.txtDescuento.TabIndex = 9
        Me.txtDescuento.Text = "$0.00"
        Me.txtDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtOferta
        '
        Me.txtOferta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtOferta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtOferta.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtOferta.Location = New System.Drawing.Point(232, 52)
        Me.txtOferta.Name = "txtOferta"
        Me.txtOferta.Size = New System.Drawing.Size(88, 20)
        Me.txtOferta.TabIndex = 8
        Me.txtOferta.Text = "$0.00"
        Me.txtOferta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtOferta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtPrecio
        '
        Me.txtPrecio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPrecio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPrecio.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtPrecio.Location = New System.Drawing.Point(232, 30)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(88, 20)
        Me.txtPrecio.TabIndex = 7
        Me.txtPrecio.Text = "$0.00"
        Me.txtPrecio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblDescuento
        '
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.BackColor = System.Drawing.Color.Transparent
        Me.lblDescuento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.Location = New System.Drawing.Point(144, 78)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(82, 16)
        Me.lblDescuento.TabIndex = 6
        Me.lblDescuento.Text = "Descuento:"
        '
        'lblOferta
        '
        Me.lblOferta.AutoSize = True
        Me.lblOferta.BackColor = System.Drawing.Color.Transparent
        Me.lblOferta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOferta.Location = New System.Drawing.Point(144, 56)
        Me.lblOferta.Name = "lblOferta"
        Me.lblOferta.Size = New System.Drawing.Size(55, 16)
        Me.lblOferta.TabIndex = 5
        Me.lblOferta.Text = "Oferta:"
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.BackColor = System.Drawing.Color.Transparent
        Me.lblPrecio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(144, 32)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(53, 16)
        Me.lblPrecio.TabIndex = 4
        Me.lblPrecio.Text = "Precio:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(24, 120)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(57, 16)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.Text = "Nombre"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(24, 100)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(51, 16)
        Me.lblCodigo.TabIndex = 2
        Me.lblCodigo.Text = "Codigo"
        '
        'imgArticulo
        '
        Me.imgArticulo.Location = New System.Drawing.Point(16, 32)
        Me.imgArticulo.Name = "imgArticulo"
        Me.imgArticulo.Size = New System.Drawing.Size(120, 64)
        Me.imgArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgArticulo.TabIndex = 1
        Me.imgArticulo.TabStop = False
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(208, 152)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(80, 40)
        Me.btnExportar.TabIndex = 18
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(112, 152)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(88, 40)
        Me.btnImprimir.TabIndex = 17
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton2
        '
        Me.UiButton2.Location = New System.Drawing.Point(-200, 120)
        Me.UiButton2.Name = "UiButton2"
        Me.UiButton2.Size = New System.Drawing.Size(84, 23)
        Me.UiButton2.TabIndex = 16
        Me.UiButton2.Text = "UiButton2"
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(16, 152)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(88, 40)
        Me.btnGenerar.TabIndex = 15
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'groupDescuento
        '
        Me.groupDescuento.BackColor = System.Drawing.Color.Transparent
        Me.groupDescuento.Controls.Add(Me.cbImagen)
        Me.groupDescuento.Controls.Add(Me.UBtnCancelar)
        Me.groupDescuento.Controls.Add(Me.UBtnOk)
        Me.groupDescuento.Controls.Add(Me.UCmbBxDescuento)
        Me.groupDescuento.Controls.Add(Me.Label1)
        Me.groupDescuento.Location = New System.Drawing.Point(248, 8)
        Me.groupDescuento.Name = "groupDescuento"
        Me.groupDescuento.Size = New System.Drawing.Size(256, 128)
        Me.groupDescuento.TabIndex = 14
        Me.groupDescuento.Text = "Seleccionar Descuentos"
        Me.groupDescuento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cbImagen
        '
        Me.cbImagen.BackColor = System.Drawing.Color.Transparent
        Me.cbImagen.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImagen.Location = New System.Drawing.Point(88, 56)
        Me.cbImagen.Name = "cbImagen"
        Me.cbImagen.Size = New System.Drawing.Size(104, 16)
        Me.cbImagen.TabIndex = 16
        Me.cbImagen.Text = "Con Imagen"
        Me.cbImagen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UBtnCancelar
        '
        Me.UBtnCancelar.BackColor = System.Drawing.SystemColors.Window
        Me.UBtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.UBtnCancelar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UBtnCancelar.Location = New System.Drawing.Point(96, 88)
        Me.UBtnCancelar.Name = "UBtnCancelar"
        Me.UBtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.UBtnCancelar.TabIndex = 15
        Me.UBtnCancelar.Text = "Cancelar"
        Me.UBtnCancelar.Visible = False
        Me.UBtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UBtnOk
        '
        Me.UBtnOk.BackColor = System.Drawing.SystemColors.Window
        Me.UBtnOk.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UBtnOk.Location = New System.Drawing.Point(16, 88)
        Me.UBtnOk.Name = "UBtnOk"
        Me.UBtnOk.Size = New System.Drawing.Size(75, 23)
        Me.UBtnOk.TabIndex = 14
        Me.UBtnOk.Text = "Aceptar"
        Me.UBtnOk.Visible = False
        Me.UBtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UCmbBxDescuento
        '
        Me.UCmbBxDescuento.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.UCmbBxDescuento.DropListFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UCmbBxDescuento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "10% - 20%"
        UiComboBoxItem1.Value = 1
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "20% - 30%"
        UiComboBoxItem2.Value = 2
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "30% - 40%"
        UiComboBoxItem3.Value = 3
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "40% - 50%"
        UiComboBoxItem4.Value = 4
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "50% - 90%"
        UiComboBoxItem5.Value = 5
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "TODOS"
        UiComboBoxItem6.Value = 6
        Me.UCmbBxDescuento.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5, UiComboBoxItem6})
        Me.UCmbBxDescuento.Location = New System.Drawing.Point(88, 24)
        Me.UCmbBxDescuento.Name = "UCmbBxDescuento"
        Me.UCmbBxDescuento.Size = New System.Drawing.Size(104, 23)
        Me.UCmbBxDescuento.TabIndex = 13
        Me.UCmbBxDescuento.Text = "0% - 10%"
        Me.UCmbBxDescuento.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Descuento"
        '
        'groupFiltros
        '
        Me.groupFiltros.BackColor = System.Drawing.Color.Transparent
        Me.groupFiltros.Controls.Add(Me.cmbUso)
        Me.groupFiltros.Controls.Add(Me.cmbFamilia)
        Me.groupFiltros.Controls.Add(Me.cmbLinea)
        Me.groupFiltros.Controls.Add(Me.lblUso)
        Me.groupFiltros.Controls.Add(Me.lblFamilia)
        Me.groupFiltros.Controls.Add(Me.lblLinea)
        Me.groupFiltros.Controls.Add(Me.lblMarca)
        Me.groupFiltros.Controls.Add(Me.cmbMarca)
        Me.groupFiltros.Location = New System.Drawing.Point(16, 8)
        Me.groupFiltros.Name = "groupFiltros"
        Me.groupFiltros.Size = New System.Drawing.Size(216, 128)
        Me.groupFiltros.TabIndex = 3
        Me.groupFiltros.Text = "Filtros"
        Me.groupFiltros.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cmbUso
        '
        Me.cmbUso.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbUso.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.cmbUso.DesignTimeLayout = GridEXLayout2
        Me.cmbUso.Location = New System.Drawing.Point(72, 96)
        Me.cmbUso.Name = "cmbUso"
        Me.cmbUso.Size = New System.Drawing.Size(128, 20)
        Me.cmbUso.TabIndex = 24
        Me.cmbUso.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbUso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbFamilia
        '
        Me.cmbFamilia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbFamilia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.cmbFamilia.DesignTimeLayout = GridEXLayout3
        Me.cmbFamilia.Location = New System.Drawing.Point(72, 72)
        Me.cmbFamilia.Name = "cmbFamilia"
        Me.cmbFamilia.Size = New System.Drawing.Size(128, 20)
        Me.cmbFamilia.TabIndex = 23
        Me.cmbFamilia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbFamilia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbLinea
        '
        Me.cmbLinea.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbLinea.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.cmbLinea.DesignTimeLayout = GridEXLayout4
        Me.cmbLinea.Location = New System.Drawing.Point(72, 48)
        Me.cmbLinea.Name = "cmbLinea"
        Me.cmbLinea.Size = New System.Drawing.Size(128, 20)
        Me.cmbLinea.TabIndex = 22
        Me.cmbLinea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbLinea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblUso
        '
        Me.lblUso.AutoSize = True
        Me.lblUso.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUso.Location = New System.Drawing.Point(8, 96)
        Me.lblUso.Name = "lblUso"
        Me.lblUso.Size = New System.Drawing.Size(38, 16)
        Me.lblUso.TabIndex = 3
        Me.lblUso.Text = "USO:"
        '
        'lblFamilia
        '
        Me.lblFamilia.AutoSize = True
        Me.lblFamilia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFamilia.Location = New System.Drawing.Point(8, 72)
        Me.lblFamilia.Name = "lblFamilia"
        Me.lblFamilia.Size = New System.Drawing.Size(67, 16)
        Me.lblFamilia.TabIndex = 2
        Me.lblFamilia.Text = "FAMILIA:"
        '
        'lblLinea
        '
        Me.lblLinea.AutoSize = True
        Me.lblLinea.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLinea.Location = New System.Drawing.Point(8, 48)
        Me.lblLinea.Name = "lblLinea"
        Me.lblLinea.Size = New System.Drawing.Size(50, 16)
        Me.lblLinea.TabIndex = 1
        Me.lblLinea.Text = "LINEA:"
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarca.Location = New System.Drawing.Point(8, 24)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(61, 16)
        Me.lblMarca.TabIndex = 0
        Me.lblMarca.Text = "MARCA:"
        '
        'cmbMarca
        '
        Me.cmbMarca.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbMarca.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        GridEXLayout5.LayoutString = resources.GetString("GridEXLayout5.LayoutString")
        Me.cmbMarca.DesignTimeLayout = GridEXLayout5
        Me.cmbMarca.Location = New System.Drawing.Point(72, 24)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(128, 20)
        Me.cmbMarca.TabIndex = 21
        Me.cmbMarca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'FrmPrompDescuentos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(856, 550)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmPrompDescuentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Articulo con Descuentos"
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.imgArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.groupDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupDescuento.ResumeLayout(False)
        Me.groupDescuento.PerformLayout()
        CType(Me.groupFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupFiltros.ResumeLayout(False)
        Me.groupFiltros.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oInicioDiaMgr As InicioDiaManager

#Region "Variables de Filtros descuentos"
    Private dtMarca As DataTable
    Private dtLinea As DataTable
    Private dtFamilia As DataTable
    Private dtUso As DataTable
    Private dtReporte As DataTable
#End Region

    Private Sub UBtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = DialogResult.OK
        Dim banImagen As Boolean = False
        Dim ini As Integer
        Dim fin As Integer
        Select Case UCmbBxDescuento.SelectedValue
            'Case 1 '"0% - 10%"
            '    ini = 0
            '    fin = 10
            Case 1 '"10% - 20%"
                ini = 10
                fin = 20
            Case 2 '"20% - 30%"
                ini = 20
                fin = 30
            Case 3 '"30% - 40%"
                ini = 30
                fin = 40
            Case 4 '"40% - 50%"
                ini = 40
                fin = 50
            Case 5 '"50% - 90%"
                ini = 50
                fin = 90
            Case Else
                ini = 0
                fin = 100
        End Select

        banImagen = cbImagen.Checked
        oInicioDiaMgr = New InicioDiaManager(oAppContext, oAppSAPConfig)

        Dim ds As DataSet

        ds = oInicioDiaMgr.ObetenerPreciosyDescuentos(True, ini, fin) 'Verdadero por que lo ocupo en Grupos

        If ds.Tables(0).Rows.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim oReportViewer As New ReportViewerForm
            oReportViewer.BanImagen = banImagen
            Dim rptDesc As New rptDescuentosSAPGroup(ds.Tables(0), oAppContext.ApplicationConfiguration.Almacen)
            rptDesc.banImagen = banImagen
            rptDesc.Document.Name = "Reporte Descuentos Agrupados- " & Format(Date.Now, "Short Date")

            oReportViewer.Report = rptDesc

            rptDesc.Run()

            Me.Cursor = Cursors.Default

            oReportViewer.Show()

        Else

            Exit Sub
        End If
        'oInicioDiaMgr.BanderaDesc = 2
        'Me.Hide()

    End Sub

    Private Sub UBtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'oInicioDiaMgr.BanderaDesc = 3
        'Me.Hide()
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub FrmPrompDescuentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UCmbBxDescuento.Text = "10% - 20%"
        CargarMarcas()
        CargarLineas()
        CargarFamilia()
        CargarUsos()
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Generar()
    End Sub

#Region "Metodos Filtros Descuentos"

    Private Sub Generar()
        Dim reporte As New ReporteInventarioDataGateway(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim traspaso As New TraspasosSalidaManager(oAppContext, oConfigCierreFI)
        Dim corrida As DataTable = traspaso.ExtraerCatalogoCorridas().Tables(0)
        Dim ini As Integer
        Dim fin As Integer
        Select Case UCmbBxDescuento.SelectedValue
            'Case 1 '"0% - 10%"
            '    ini = 0
            '    fin = 10
            Case 1 '"10% - 20%"
                ini = 10
                fin = 20
            Case 2 '"20% - 30%"
                ini = 20
                fin = 30
            Case 3 '"30% - 40%"
                ini = 30
                fin = 40
            Case 4 '"40% - 50%"
                ini = 40
                fin = 50
            Case 5 '"50% - 90%"
                ini = 50
                fin = 90
            Case Else
                ini = 0
                fin = 100
        End Select
        Me.dtReporte.Rows.Clear()
        Dim dtResult As DataTable = reporte.GetReporteInventarios(ini, fin, cmbMarca.Value, cmbLinea.Value, cmbFamilia.Value, cmbUso.Value)
        Dim row As DataRow = Nothing, fila As DataRow = Nothing
        Dim codArticulo As String = "", codAnterior As String = "", codCorrida As String = ""
        Dim rows() As DataRow, index As Integer = 1, cont As Integer = 1, rowCorrida As DataRow = Nothing
        Dim imgBytes As Image, reader As MemoryStream
        Dim bytes() As Byte, stream As FileStream, buffer As BufferedStream
        For Each row In dtResult.Rows
            codCorrida = CStr(row("CodCorrida"))
            codArticulo = CStr(row("CodArticulo"))
            rows = dtReporte.Select("CodArticulo='" & codArticulo & "'")
            If rows.Length = 0 Then
                index = 1
                cont = 1
                fila = dtReporte.NewRow()
                fila("CodArticulo") = codArticulo
                fila("Descripcion") = CStr(row("Descripcion"))
                fila("PrecioNormal") = CDec(row("PrecioNormal"))
                fila("PrecioOferta") = CDec(row("PrecioOferta"))
                fila("Descuento") = CDec(row("Descuento"))
                fila("NombreLinea") = CStr(row("NombreLinea"))
                fila("CodLinea") = CStr(row("CodLinea"))
                fila("TotalA") = dtResult.Compute("Sum(Libre)", "CodArticulo='" & codArticulo & "'")
                'fila("Total" & CStr(index).PadLeft(2, "0")) = row("Libre")
                If cbImagen.Checked = True Then
                    If File.Exists(Application.StartupPath & "\Fotos\" & codArticulo & ".JPG") Then
                        stream = New FileStream(Application.StartupPath & "\Fotos\" & codArticulo & ".JPG", FileMode.Open)
                        buffer = New BufferedStream(stream)
                        ReDim bytes(stream.Length)
                        buffer.Read(bytes, 0, stream.Length)
                        fila("Imagen") = bytes
                    Else
                        imgBytes = DownloadImageFromWeb(codArticulo)
                        reader = New MemoryStream
                        imgBytes.Save(reader, System.Drawing.Imaging.ImageFormat.Jpeg)
                        fila("Imagen") = reader.ToArray()
                        'fila("Imagen") = DBNull.Value
                    End If
                Else
                    fila("Imagen") = DBNull.Value
                End If
                rowCorrida = corrida.Select("CodCorrida='" & codCorrida & "'")(0)
                For cont = 1 To 20 Step 1
                    fila("Talla" & Format(cont, "00")) = rowCorrida("C" & Format(cont, "00"))
                    If CStr(fila("Talla" & Format(cont, "00"))) = CStr(row("Numero")) Then
                        fila("Total" & Format(cont, "00")) = row("Libre")
                    End If
                Next
                dtReporte.Rows.Add(fila)
            Else
                For cont = 1 To 20 Step 1
                    If CStr(fila("Talla" & Format(cont, "00"))) = CStr(row("Numero")) Then
                        fila("Total" & Format(cont, "00")) = row("Libre")
                    End If
                Next
                'rows(0)("Total" & CStr(index).PadLeft(2, "0")) = CDec(row("Libre"))
                rows(0).AcceptChanges()
            End If
            index += 1
        Next
        Me.dtReporte.AcceptChanges()
        Me.geResults.DataSource = dtReporte
    End Sub

    Private Sub CargarMarcas()
        Dim oRow As DataRow
        Dim oCatalogoMarcasMgr As New CatalogoMarcasManager(oAppContext)
        dtMarca = oCatalogoMarcasMgr.GetAll(True).Tables(0)
        oRow = dtMarca.NewRow
        oRow!CodMarca = ""
        oRow!Descripcion = "TODAS"
        dtMarca.Rows.Add(oRow)
        oRow = Nothing

        Me.cmbMarca.DataSource = dtMarca
        Me.cmbMarca.DropDownList.Columns.Add("Cod.")
        Me.cmbMarca.DropDownList.Columns.Add("Descripción")

        Me.cmbMarca.DropDownList.Columns("Cod.").DataMember = "CodMarca"
        Me.cmbMarca.DropDownList.Columns("Cod.").Width = 50
        Me.cmbMarca.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        Me.cmbMarca.DropDownList.Columns("Descripción").Width = 150

        Me.cmbMarca.DisplayMember = "Descripcion"
        Me.cmbMarca.ValueMember = "CodMarca"

        Me.cmbMarca.Value = ""
    End Sub

    Private Sub CargarLineas()
        Dim dsCatalogoLinea As DataSet
        Dim oRow As DataRow

        Dim oCatalogoLineasMgr As New CatalogoLineasManager(oAppContext)
        dsCatalogoLinea = oCatalogoLineasMgr.GetAll(True).Copy
        oRow = dsCatalogoLinea.Tables(0).NewRow
        oRow!CodLinea = ""
        oRow!Descripcion = "TODAS"
        dsCatalogoLinea.Tables(0).Rows.Add(oRow)
        oRow = Nothing

        Me.cmbLinea.DataSource = dsCatalogoLinea.Tables("CatalogoLineas")
        Me.cmbLinea.DropDownList.Columns.Add("Cod.")
        Me.cmbLinea.DropDownList.Columns.Add("Descripción")

        Me.cmbLinea.DropDownList.Columns("Cod.").DataMember = "CodLinea"
        Me.cmbLinea.DropDownList.Columns("Cod.").Width = 50
        Me.cmbLinea.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        Me.cmbLinea.DropDownList.Columns("Descripción").Width = 150

        Me.cmbLinea.DisplayMember = "Descripcion"
        Me.cmbLinea.ValueMember = "CodLinea"

        Me.cmbLinea.Value = ""
    End Sub

    Private Sub CargarFamilia()
        Dim dsCatalogoFamilia As DataSet
        Dim oRow As DataRow

        Dim oCatalogoFamiliasMgr As New CatalogoFamiliasManager(oAppContext)
        dsCatalogoFamilia = oCatalogoFamiliasMgr.GetAll(True).Copy

        oRow = dsCatalogoFamilia.Tables(0).NewRow
        oRow!CodFamilia = ""
        oRow!Descripcion = "TODAS"
        dsCatalogoFamilia.Tables(0).Rows.Add(oRow)
        oRow = Nothing

        Me.cmbFamilia.DataSource = dsCatalogoFamilia.Tables("CatalogoFamilias")
        Me.cmbFamilia.DropDownList.Columns.Add("Cod.")
        Me.cmbFamilia.DropDownList.Columns.Add("Descripción")

        Me.cmbFamilia.DropDownList.Columns("Cod.").DataMember = "CodFamilia"
        Me.cmbFamilia.DropDownList.Columns("Cod.").Width = 50
        Me.cmbFamilia.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        Me.cmbFamilia.DropDownList.Columns("Descripción").Width = 150

        Me.cmbFamilia.DisplayMember = "Descripcion"
        Me.cmbFamilia.ValueMember = "CodFamilia"

        Me.cmbFamilia.Value = ""
    End Sub

    Private Sub CargarUsos()
        Dim row As DataRow = Nothing
        Dim uso As New UsosCatalogManager(oAppContext)
        dtUso = uso.GetAll(True).Tables(0)

        row = dtUso.NewRow()
        row!CodUso = ""
        row!Descripcion = "TODOS"
        dtUso.Rows.Add(row)

        Me.cmbUso.DataSource = dtUso
        Me.cmbUso.DropDownList.Columns.Add("Cod.")
        Me.cmbUso.DropDownList.Columns.Add("Descripción")

        Me.cmbUso.DropDownList.Columns("Cod.").DataMember = "CodUso"
        Me.cmbUso.DropDownList.Columns("Cod.").Width = 50
        Me.cmbUso.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        Me.cmbUso.DropDownList.Columns("Descripción").Width = 150

        Me.cmbUso.DisplayMember = "Descripcion"
        Me.cmbUso.ValueMember = "CodUso"

        Me.cmbUso.Value = ""
    End Sub

    Private Sub InitializeReporte()
        Me.dtReporte = New DataTable("InventarioDescuento")
        Me.dtReporte.Columns.Add("CodArticulo", GetType(String))
        Me.dtReporte.Columns.Add("Descripcion", GetType(String))
        Me.dtReporte.Columns.Add("TotalA", GetType(Decimal))
        Me.dtReporte.Columns.Add("Talla01", GetType(String))
        Me.dtReporte.Columns.Add("Talla02", GetType(String))
        Me.dtReporte.Columns.Add("Talla03", GetType(String))
        Me.dtReporte.Columns.Add("Talla04", GetType(String))
        Me.dtReporte.Columns.Add("Talla05", GetType(String))
        Me.dtReporte.Columns.Add("Talla06", GetType(String))
        Me.dtReporte.Columns.Add("Talla07", GetType(String))
        Me.dtReporte.Columns.Add("Talla08", GetType(String))
        Me.dtReporte.Columns.Add("Talla09", GetType(String))
        Me.dtReporte.Columns.Add("Talla10", GetType(String))
        Me.dtReporte.Columns.Add("Talla11", GetType(String))
        Me.dtReporte.Columns.Add("Talla12", GetType(String))
        Me.dtReporte.Columns.Add("Talla13", GetType(String))
        Me.dtReporte.Columns.Add("Talla14", GetType(String))
        Me.dtReporte.Columns.Add("Talla15", GetType(String))
        Me.dtReporte.Columns.Add("Talla16", GetType(String))
        Me.dtReporte.Columns.Add("Talla17", GetType(String))
        Me.dtReporte.Columns.Add("Talla18", GetType(String))
        Me.dtReporte.Columns.Add("Talla19", GetType(String))
        Me.dtReporte.Columns.Add("Talla20", GetType(String))
        Me.dtReporte.Columns.Add("Total01", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total02", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total03", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total04", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total05", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total06", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total07", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total08", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total09", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total10", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total11", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total12", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total13", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total14", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total15", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total16", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total17", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total18", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total19", GetType(Decimal))
        Me.dtReporte.Columns.Add("Total20", GetType(Decimal))
        Me.dtReporte.Columns.Add("Imagen", GetType(Byte()))
        Me.dtReporte.Columns.Add("PrecioNormal", GetType(Decimal))
        Me.dtReporte.Columns.Add("PrecioOferta", GetType(Decimal))
        Me.dtReporte.Columns.Add("Descuento", GetType(Decimal))
        Me.dtReporte.Columns.Add("NombreLinea", GetType(String))
        Me.dtReporte.Columns.Add("CodLinea", GetType(String))

        Me.dtReporte.AcceptChanges()
        lblCodigo.Text = ""
        lblNombre.Text = ""
    End Sub

    Private Sub Exportar(ByVal imgban As Boolean)
        If Me.dtReporte.Rows.Count > 0 Then
            Dim save As New SaveFileDialog
            save.Title = "¿Donde desea guardar el archivo?"
            save.Filter = "(*.xls)|*.xls"
            save.DefaultExt = "*.xls"
            If save.ShowDialog() = DialogResult.OK Then
                Dim xlapp As Excel.Application
                Dim wbxl As Excel.Workbook
                Dim wsxl As Excel.Worksheet

                Dim intRow As Integer 'counter
                Me.Cursor = Cursors.WaitCursor
                Dim oRow As DataRow
                xlapp = New Excel.Application
                xlapp = GetObject(, "Excel.Application")

                If xlapp Is Nothing Then
                    xlapp = CreateObject("Excel.Application")
                    If xlapp Is Nothing Then
                        MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, "Dportenis PRO")
                        Exit Sub
                    End If
                Else
                    xlapp = CreateObject("Excel.Application")
                End If
                Dim cont As Integer = 4, posY As Integer = 54.25
                wbxl = xlapp.Workbooks.Add
                wsxl = xlapp.Sheets(1)
                wsxl.Name = "ReporteDescuentos"
                wsxl.Cells(1, 1).Value = "Reporte de Descuentos en Sucursal: " & oAppContext.ApplicationConfiguration.Almacen
                wsxl.Cells(1, 1).Font.Bold = True
                wsxl.Cells(1, 1).Font.Size = 14
                wsxl.Range("A1:G1").Merge()
                wsxl.Range("A1:G1").HorizontalAlignment = 3
                wsxl.Cells(2, 1).Value = "Fecha: " & DateTime.Now.ToLongDateString()
                wsxl.Cells(2, 1).Font.Bold = True
                wsxl.Cells(2, 1).Font.Size = 14
                wsxl.Range("A2:G2").Merge()
                wsxl.Range("A2:G2").HorizontalAlignment = 3
                wsxl.Range("A1:G2").BorderAround(, Excel.XlBorderWeight.xlThin, 0, )
                wsxl.Cells(3, 1).Value = "Código"
                wsxl.Cells(3, 1).BorderAround(, Excel.XlBorderWeight.xlThin, 0, )
                wsxl.Cells(3, 1).Font.Bold = True
                wsxl.Cells(3, 1).Font.Size = 10
                wsxl.Cells(3, 2).Value = "Descripcion"
                wsxl.Cells(3, 2).BorderAround(, Excel.XlBorderWeight.xlThin, 0, )
                wsxl.Cells(3, 2).Font.Bold = True
                wsxl.Cells(3, 2).Font.Size = 10
                wsxl.Cells(3, 3).Value = "Precio Normal"
                wsxl.Cells(3, 3).BorderAround(, Excel.XlBorderWeight.xlThin, 0, )
                wsxl.Cells(3, 3).Font.Bold = True
                wsxl.Cells(3, 3).Font.Size = 10
                wsxl.Cells(3, 4).Value = "Descuento"
                wsxl.Cells(3, 4).BorderAround(, Excel.XlBorderWeight.xlThin, 0, )
                wsxl.Cells(3, 4).Font.Bold = True
                wsxl.Cells(3, 4).Font.Size = 10
                wsxl.Cells(3, 5).Value = "Precio Oferta"
                wsxl.Cells(3, 5).BorderAround(, Excel.XlBorderWeight.xlThin, 0, )
                wsxl.Cells(3, 5).Font.Bold = True
                wsxl.Cells(3, 5).Font.Size = 10
                wsxl.Cells(3, 6).Value = "Existencia"
                wsxl.Cells(3, 6).BorderAround(, Excel.XlBorderWeight.xlThin, 0, )
                wsxl.Cells(3, 6).Font.Bold = True
                wsxl.Cells(3, 6).Font.Size = 10
                wsxl.Cells(3, 7).Value = "Imagen"
                wsxl.Cells(3, 7).BorderAround(, Excel.XlBorderWeight.xlThin, 0, )
                wsxl.Cells(3, 7).Font.Bold = True
                wsxl.Cells(3, 7).Font.Size = 10
                Dim dataview As New DataView(Me.dtReporte)
                Dim codLinea As String = "", codLineaAnt As String = "", linea As String = ""
                Dim codArticulo As String = "", descripcion As String = "", precio As Decimal = 0, descuento As Decimal = 0, precioOferta As Decimal = 0
                Dim exist As Integer = 0
                Dim cell
                Dim alto As Double = 0
                dataview.Sort = "CodLinea ASC"
                For Each row As DataRowView In dataview
                    codLinea = CStr(row("CodLinea"))
                    If codLinea <> codLineaAnt Then
                        linea = CStr(row("NombreLinea"))
                        wsxl.Cells(cont, 1).Value = linea
                        wsxl.Cells(cont, 1).Font.Bold = True
                        wsxl.Range("A" & CStr(cont) & ":G" & CStr(cont)).Merge()
                        wsxl.Range("A" & CStr(cont) & ":B" & CStr(cont)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        cont += 1
                        codLineaAnt = codLinea
                        alto = wsxl.Range("G" & CStr(cont) & ":G" & CStr(cont)).RowHeight
                        posY += alto
                    End If
                    codArticulo = CStr(row("CodArticulo"))
                    wsxl.Cells(cont, 1).Value = CStr(row("CodArticulo"))
                    wsxl.Cells(cont, 2).Value = CStr(row("Descripcion"))
                    wsxl.Cells(cont, 3).Value = CDec(row("PrecioNormal"))
                    wsxl.Cells(cont, 4).Value = CDec(row("Descuento"))
                    wsxl.Cells(cont, 5).Value = CDec(row("PrecioOferta"))
                    wsxl.Cells(cont, 6).Value = CDec(row("TotalA"))
                    If imgban = True Then
                        If File.Exists(Application.StartupPath & "\Fotos\" & codArticulo & ".JPG") Then
                            wsxl.Range("G" & CStr(cont) & ":G" & CStr(cont)).RowHeight = 70
                            wsxl.Shapes.AddPicture(Application.StartupPath & "\Fotos\" & codArticulo & ".JPG", Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoTrue, 365, posY, 90, 40)
                            posY += 70
                            'insertarImagenCelda(wsxl, Application.StartupPath & "\Fotos\" & codArticulo & ".JPG", cont, 7)
                            'wsxl.Cells(cont, 7).Select()
                            'xlapp.ActiveSheet.pictures.Insert(Application.StartupPath & "\Fotos\" & codArticulo & ".JPG")
                        Else
                            alto = wsxl.Range("G" & CStr(cont) & ":G" & CStr(cont)).RowHeight
                            posY += alto
                        End If
                    End If
                    cont += 1
                Next

                wsxl.Range("A4:A4").ColumnWidth = 18
                wsxl.Range("B4:B4").ColumnWidth = 27.2
                wsxl.Range("C4:C4").ColumnWidth = 11
                wsxl.Range("D4:D4").ColumnWidth = 11
                wsxl.Range("E4:E4").ColumnWidth = 11
                wsxl.Range("F4:F4").ColumnWidth = 11
                wsxl.Range("G4:G4").ColumnWidth = 20
                Me.Cursor = Cursors.Default
                wbxl.SaveAs(save.FileName)
                wbxl.Close()
                wsxl = Nothing
                xlapp.Quit()
                xlapp = Nothing
                KillExcel()
                MessageBox.Show("El archivo se exporto en la siguiente ruta: " & save.FileName, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Sub insertarImagenCelda(ByVal objExcelWks As Excel.Worksheet, ByVal rutaImagen As String, ByVal row As Integer, ByVal col As Integer)
        Dim imagen = objExcelWks.Pictures.Insert(rutaImagen)
        Dim cell = objExcelWks.Cells(row, col)
        'Centro en ancho
        Dim ancho As Double = cell.Offset(0, 1).Left - cell.Left
        imagen.Left = cell.Left + ancho / 2 - imagen.Width / 2
        If imagen.Left < 1 Then imagen.Left = 1
        'Centro en alto
        Dim alto As Double = cell.Offset(1, 0).Top - cell.Top
        imagen.Top = cell.Top + alto / 2 - imagen.Height / 2
        If imagen.Top < 1 Then imagen.Top = 1

        imagen = Nothing
        cell = Nothing
    End Sub
#End Region

#Region "Eventos Form Filtros Descuentos"
    Private Sub geResults_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles geResults.Click
        Dim gridRow As GridEXRow = Nothing, row As DataRow, CodArticulo As String = "", bytes() As Byte
        Dim ms As MemoryStream = Nothing, descripcion As String = "", precio As Decimal = 0, precioOferta As Decimal = 0, descuento As Decimal = 0
        gridRow = geResults.GetRow()
        If Not gridRow Is Nothing Then
            row = CType(gridRow.DataRow, DataRowView).Row
            CodArticulo = CStr(row("CodArticulo"))
            descripcion = CStr(row("Descripcion"))
            precio = CDec(row("PrecioNormal"))
            precioOferta = CDec(row("PrecioOferta"))
            descuento = CDec(row("Descuento"))
            lblCodigo.Text = CodArticulo
            lblNombre.Text = descripcion
            txtPrecio.Value = precio
            txtOferta.Value = precioOferta
            txtDescuento.Value = descuento
            If IsDBNull(row("Imagen")) = False Then
                bytes = CType(row("Imagen"), Byte())
                ms = New MemoryStream(bytes)
                imgArticulo.Image = Image.FromStream(ms)
            Else
                imgArticulo.Image = Nothing
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Me.dtReporte.Rows.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim oReportViewer As New ReportViewerForm
            oReportViewer.BanImagen = cbImagen.Checked
            Dim rptDesc As New rptDescuentosSAPGroup(Me.dtReporte, oAppContext.ApplicationConfiguration.Almacen)
            rptDesc.banImagen = cbImagen.Checked
            rptDesc.Document.Name = "Reporte Descuentos Agrupados- " & Format(Date.Now, "Short Date")

            oReportViewer.Report = rptDesc

            rptDesc.Run()

            Me.Cursor = Cursors.Default

            oReportViewer.Show()
        Else
            MessageBox.Show("No hay articulos generados en la consulta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub geResults_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles geResults.DoubleClick
        Dim gridRow As GridEXRow = Nothing
        gridRow = Me.geResults.GetRow()
        If Not gridRow Is Nothing Then
            Dim row As DataRow = CType(gridRow.DataRow, DataRowView).Row
            Dim codArticulo As String = "", descripcion As String = "", precio As Decimal = 0, descuento As Decimal = 0, precioOferta As Decimal = 0
            Dim img As Image
            If IsDBNull(row("Imagen")) = False Then
                Dim ms As MemoryStream = Nothing, bytes() As Byte
                bytes = CType(row("Imagen"), Byte())
                ms = New MemoryStream(bytes)
                img = Image.FromStream(ms)
            Else
                img = Nothing
            End If
            codArticulo = CStr(row("CodArticulo"))
            descripcion = CStr(row("Descripcion"))
            precio = CDec(row("PrecioNormal"))
            descuento = CDec(row("Descuento"))
            precioOferta = CDec(row("PrecioOferta"))
            Dim frmArticulo As New frmArticuloFiltroDescuento
            frmArticulo.imgArticulo.Image = img
            frmArticulo.lblCodArticulo.Text = codArticulo
            frmArticulo.lblDescripcion.Text = descripcion
            frmArticulo.lblPrecioNormal.Text = String.Format("{0:C}", precio)
            frmArticulo.lblDescuento.Text = Decimal.Round(descuento, 2).ToString() & " %"
            frmArticulo.lblPrecioOferta.Text = String.Format("{0:C}", precioOferta)
            frmArticulo.ShowDialog()
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Exportar(cbImagen.Checked)
    End Sub

    Private Sub btnImprimirEtiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirEtiquetas.Click
        If lblCodigo.Text.Trim() <> "" Then
            Dim frmEtiqueta As New FrmImpresionEtiquetas
            frmEtiqueta.SetCodArticulo(lblCodigo.Text)
            frmEtiqueta.Show()
        End If
    End Sub

#End Region





End Class
