Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas

Public Class frmAnalisisDeVentas
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
    Friend WithEvents cmbMarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbFamilia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbLinea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbTipoDeVenta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rdbFamilias As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbComparativo As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbVentasPorDia As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbUso As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbSucursal As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbLinea As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbMarcas As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbPlayer As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbCodigo As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbMarcaLineaFamilia As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbFamiliaMarca As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbLineaFam As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ccFechaDesde As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ccFechaHasta As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UiCmbBoxOrdenarPor As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents rbMetasPlayer As Janus.Windows.EditControls.UIRadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout5 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnalisisDeVentas))
        Dim GridEXLayout6 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout7 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout8 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.cmbMarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbFamilia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbLinea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbTipoDeVenta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbMetasPlayer = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbFamilias = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbComparativo = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbVentasPorDia = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbUso = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbSucursal = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbLinea = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbMarcas = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbPlayer = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbCodigo = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbMarcaLineaFamilia = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbFamiliaMarca = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbLineaFam = New Janus.Windows.EditControls.UIRadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiCmbBoxOrdenarPor = New Janus.Windows.EditControls.UIComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ccFechaDesde = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ccFechaHasta = New Janus.Windows.CalendarCombo.CalendarCombo()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbMarca
        '
        Me.cmbMarca.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbMarca.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbMarca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout5.LayoutString = resources.GetString("GridEXLayout5.LayoutString")
        Me.cmbMarca.DesignTimeLayout = GridEXLayout5
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMarca.Location = New System.Drawing.Point(64, 328)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(224, 22)
        Me.cmbMarca.TabIndex = 29
        Me.cmbMarca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMarca.Visible = False
        Me.cmbMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbFamilia
        '
        Me.cmbFamilia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbFamilia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbFamilia.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout6.LayoutString = resources.GetString("GridEXLayout6.LayoutString")
        Me.cmbFamilia.DesignTimeLayout = GridEXLayout6
        Me.cmbFamilia.Enabled = False
        Me.cmbFamilia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFamilia.Location = New System.Drawing.Point(64, 296)
        Me.cmbFamilia.Name = "cmbFamilia"
        Me.cmbFamilia.Size = New System.Drawing.Size(224, 22)
        Me.cmbFamilia.TabIndex = 28
        Me.cmbFamilia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbFamilia.Visible = False
        Me.cmbFamilia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbLinea
        '
        Me.cmbLinea.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbLinea.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbLinea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout7.LayoutString = resources.GetString("GridEXLayout7.LayoutString")
        Me.cmbLinea.DesignTimeLayout = GridEXLayout7
        Me.cmbLinea.Enabled = False
        Me.cmbLinea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLinea.Location = New System.Drawing.Point(64, 264)
        Me.cmbLinea.Name = "cmbLinea"
        Me.cmbLinea.Size = New System.Drawing.Size(224, 22)
        Me.cmbLinea.TabIndex = 27
        Me.cmbLinea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbLinea.Visible = False
        Me.cmbLinea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbTipoDeVenta
        '
        Me.cmbTipoDeVenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbTipoDeVenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbTipoDeVenta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout8.LayoutString = resources.GetString("GridEXLayout8.LayoutString")
        Me.cmbTipoDeVenta.DesignTimeLayout = GridEXLayout8
        Me.cmbTipoDeVenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDeVenta.Location = New System.Drawing.Point(96, 16)
        Me.cmbTipoDeVenta.Name = "cmbTipoDeVenta"
        Me.cmbTipoDeVenta.Size = New System.Drawing.Size(208, 22)
        Me.cmbTipoDeVenta.TabIndex = 1
        Me.cmbTipoDeVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbTipoDeVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnGenerar.Icon = CType(resources.GetObject("btnGenerar.Icon"), System.Drawing.Icon)
        Me.btnGenerar.Location = New System.Drawing.Point(16, 232)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(136, 32)
        Me.btnGenerar.TabIndex = 30
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(16, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Marca"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(16, 296)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Familia"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(16, 264)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Línea"
        Me.Label5.Visible = False
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.rbMetasPlayer)
        Me.UiGroupBox1.Controls.Add(Me.rdbFamilias)
        Me.UiGroupBox1.Controls.Add(Me.rdbComparativo)
        Me.UiGroupBox1.Controls.Add(Me.rdbVentasPorDia)
        Me.UiGroupBox1.Controls.Add(Me.rdbUso)
        Me.UiGroupBox1.Controls.Add(Me.rdbSucursal)
        Me.UiGroupBox1.Controls.Add(Me.rdbLinea)
        Me.UiGroupBox1.Controls.Add(Me.rdbMarcas)
        Me.UiGroupBox1.Controls.Add(Me.rdbPlayer)
        Me.UiGroupBox1.Controls.Add(Me.rdbCodigo)
        Me.UiGroupBox1.Controls.Add(Me.rdbMarcaLineaFamilia)
        Me.UiGroupBox1.Controls.Add(Me.rdbFamiliaMarca)
        Me.UiGroupBox1.Controls.Add(Me.rdbLineaFam)
        Me.UiGroupBox1.Location = New System.Drawing.Point(16, 104)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(368, 112)
        Me.UiGroupBox1.TabIndex = 11
        '
        'rbMetasPlayer
        '
        Me.rbMetasPlayer.Location = New System.Drawing.Point(256, 80)
        Me.rbMetasPlayer.Name = "rbMetasPlayer"
        Me.rbMetasPlayer.Size = New System.Drawing.Size(104, 23)
        Me.rbMetasPlayer.TabIndex = 12
        Me.rbMetasPlayer.Text = "Metas Player"
        Me.rbMetasPlayer.Visible = False
        Me.rbMetasPlayer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbFamilias
        '
        Me.rdbFamilias.Location = New System.Drawing.Point(136, 48)
        Me.rdbFamilias.Name = "rdbFamilias"
        Me.rdbFamilias.Size = New System.Drawing.Size(104, 23)
        Me.rdbFamilias.TabIndex = 7
        Me.rdbFamilias.Text = "Familias"
        Me.rdbFamilias.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbComparativo
        '
        Me.rdbComparativo.Enabled = False
        Me.rdbComparativo.Location = New System.Drawing.Point(408, 80)
        Me.rdbComparativo.Name = "rdbComparativo"
        Me.rdbComparativo.Size = New System.Drawing.Size(104, 23)
        Me.rdbComparativo.TabIndex = 11
        Me.rdbComparativo.Text = "Comparativo"
        Me.rdbComparativo.Visible = False
        '
        'rdbVentasPorDia
        '
        Me.rdbVentasPorDia.Location = New System.Drawing.Point(256, 16)
        Me.rdbVentasPorDia.Name = "rdbVentasPorDia"
        Me.rdbVentasPorDia.Size = New System.Drawing.Size(104, 23)
        Me.rdbVentasPorDia.TabIndex = 10
        Me.rdbVentasPorDia.Text = "Ventas por Día"
        Me.rdbVentasPorDia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbUso
        '
        Me.rdbUso.Location = New System.Drawing.Point(256, 48)
        Me.rdbUso.Name = "rdbUso"
        Me.rdbUso.Size = New System.Drawing.Size(104, 23)
        Me.rdbUso.TabIndex = 9
        Me.rdbUso.Text = "Categoria"
        Me.rdbUso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbSucursal
        '
        Me.rdbSucursal.Location = New System.Drawing.Point(136, 80)
        Me.rdbSucursal.Name = "rdbSucursal"
        Me.rdbSucursal.Size = New System.Drawing.Size(104, 23)
        Me.rdbSucursal.TabIndex = 8
        Me.rdbSucursal.Text = "Sucursal"
        Me.rdbSucursal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbLinea
        '
        Me.rdbLinea.Location = New System.Drawing.Point(136, 16)
        Me.rdbLinea.Name = "rdbLinea"
        Me.rdbLinea.Size = New System.Drawing.Size(104, 23)
        Me.rdbLinea.TabIndex = 6
        Me.rdbLinea.Text = "Linea"
        Me.rdbLinea.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbMarcas
        '
        Me.rdbMarcas.Location = New System.Drawing.Point(16, 80)
        Me.rdbMarcas.Name = "rdbMarcas"
        Me.rdbMarcas.Size = New System.Drawing.Size(104, 23)
        Me.rdbMarcas.TabIndex = 5
        Me.rdbMarcas.Text = "Marcas"
        Me.rdbMarcas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbPlayer
        '
        Me.rdbPlayer.Checked = True
        Me.rdbPlayer.Location = New System.Drawing.Point(16, 48)
        Me.rdbPlayer.Name = "rdbPlayer"
        Me.rdbPlayer.Size = New System.Drawing.Size(104, 23)
        Me.rdbPlayer.TabIndex = 4
        Me.rdbPlayer.TabStop = True
        Me.rdbPlayer.Text = "Player"
        Me.rdbPlayer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbCodigo
        '
        Me.rdbCodigo.Location = New System.Drawing.Point(16, 16)
        Me.rdbCodigo.Name = "rdbCodigo"
        Me.rdbCodigo.Size = New System.Drawing.Size(104, 23)
        Me.rdbCodigo.TabIndex = 3
        Me.rdbCodigo.Text = "Código"
        Me.rdbCodigo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbMarcaLineaFamilia
        '
        Me.rdbMarcaLineaFamilia.Enabled = False
        Me.rdbMarcaLineaFamilia.Location = New System.Drawing.Point(16, 80)
        Me.rdbMarcaLineaFamilia.Name = "rdbMarcaLineaFamilia"
        Me.rdbMarcaLineaFamilia.Size = New System.Drawing.Size(136, 23)
        Me.rdbMarcaLineaFamilia.TabIndex = 2
        Me.rdbMarcaLineaFamilia.Text = "Marca/Linea/Familia"
        Me.rdbMarcaLineaFamilia.Visible = False
        '
        'rdbFamiliaMarca
        '
        Me.rdbFamiliaMarca.Enabled = False
        Me.rdbFamiliaMarca.Location = New System.Drawing.Point(16, 48)
        Me.rdbFamiliaMarca.Name = "rdbFamiliaMarca"
        Me.rdbFamiliaMarca.Size = New System.Drawing.Size(104, 23)
        Me.rdbFamiliaMarca.TabIndex = 1
        Me.rdbFamiliaMarca.Text = "Familia/Marca"
        Me.rdbFamiliaMarca.Visible = False
        '
        'rdbLineaFam
        '
        Me.rdbLineaFam.Enabled = False
        Me.rdbLineaFam.Location = New System.Drawing.Point(16, 16)
        Me.rdbLineaFam.Name = "rdbLineaFam"
        Me.rdbLineaFam.Size = New System.Drawing.Size(88, 23)
        Me.rdbLineaFam.TabIndex = 0
        Me.rdbLineaFam.Text = "Linea/Familia"
        Me.rdbLineaFam.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(16, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Tipo de Venta:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(16, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Desde:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(224, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Hasta:"
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExplorerBar1.BackgroundFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ExplorerBar1.BackgroundFormatStyle.BackColorGradient = System.Drawing.SystemColors.Control
        Me.ExplorerBar1.Controls.Add(Me.UiCmbBoxOrdenarPor)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.ccFechaDesde)
        Me.ExplorerBar1.Controls.Add(Me.ccFechaHasta)
        Me.ExplorerBar1.Controls.Add(Me.cmbMarca)
        Me.ExplorerBar1.Controls.Add(Me.cmbFamilia)
        Me.ExplorerBar1.Controls.Add(Me.cmbLinea)
        Me.ExplorerBar1.Controls.Add(Me.cmbTipoDeVenta)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Location = New System.Drawing.Point(-1, -1)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(433, 288)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiCmbBoxOrdenarPor
        '
        Me.UiCmbBoxOrdenarPor.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.UiCmbBoxOrdenarPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "Código"
        UiComboBoxItem4.Value = "Codigo"
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "Importe"
        UiComboBoxItem5.Value = "Importe"
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "Piezas"
        UiComboBoxItem6.Value = "Piezas"
        Me.UiCmbBoxOrdenarPor.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem4, UiComboBoxItem5, UiComboBoxItem6})
        Me.UiCmbBoxOrdenarPor.Location = New System.Drawing.Point(96, 48)
        Me.UiCmbBoxOrdenarPor.Name = "UiCmbBoxOrdenarPor"
        Me.UiCmbBoxOrdenarPor.Size = New System.Drawing.Size(112, 20)
        Me.UiCmbBoxOrdenarPor.TabIndex = 3
        Me.UiCmbBoxOrdenarPor.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Ordenar Por:"
        '
        'ccFechaDesde
        '
        '
        '
        '
        Me.ccFechaDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccFechaDesde.Location = New System.Drawing.Point(96, 80)
        Me.ccFechaDesde.Name = "ccFechaDesde"
        Me.ccFechaDesde.Size = New System.Drawing.Size(112, 20)
        Me.ccFechaDesde.TabIndex = 5
        Me.ccFechaDesde.Value = New Date(2008, 9, 9, 0, 0, 0, 0)
        Me.ccFechaDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ccFechaHasta
        '
        '
        '
        '
        Me.ccFechaHasta.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccFechaHasta.Location = New System.Drawing.Point(272, 80)
        Me.ccFechaHasta.Name = "ccFechaHasta"
        Me.ccFechaHasta.Size = New System.Drawing.Size(112, 20)
        Me.ccFechaHasta.TabIndex = 7
        Me.ccFechaHasta.Value = New Date(2008, 9, 9, 0, 0, 0, 0)
        Me.ccFechaHasta.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'frmAnalisisDeVentas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(402, 272)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmAnalisisDeVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Analisis de Ventas"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Variables"

    Dim dsTiposVentas As New DataSet          'Dataset para cargar los tipos de venta

#End Region


    Private Sub ccFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ccFechaHasta.MinDate = ccFechaDesde.Value
        ccFechaHasta.Value = ccFechaDesde.Value

    End Sub

#Region "Llenado de Combos"


    Private Sub FillTipoVenta()

        Dim oTipoVentaMgr As New TiposVentaManager(oAppContext)

        dsTiposVentas = oTipoVentaMgr.Load()

        oTipoVentaMgr.Dispose()

        'Dim dsTiposVentas As DataSet
        'dsTiposVentas = TiposVenta.GetList.Clone

        Dim newRow As DataRow
        newRow = dsTiposVentas.Tables(0).NewRow


        newRow("CodTipoVenta") = "T"
        newRow("Descripcion") = "Todas"
        dsTiposVentas.Tables(0).Rows.Add(newRow)

        newRow = dsTiposVentas.Tables(0).NewRow
        newRow("CodTipoVenta") = "TC"
        newRow("Descripcion") = "Todas Credito"
        dsTiposVentas.Tables(0).Rows.Add(newRow)

        'newRow = dsTiposVentas.Tables(0).NewRow
        'newRow("ID") = "A"
        'newRow("Description") = "Asociados"
        'dsTiposVentas.Tables(0).Rows.Add(newRow)

        'newRow = dsTiposVentas.Tables(0).NewRow
        'newRow("ID") = "D"
        'newRow("Description") = "Asociados Crédito"
        'dsTiposVentas.Tables(0).Rows.Add(newRow)

        'newRow = dsTiposVentas.Tables(0).NewRow
        'newRow("ID") = "F"
        'newRow("Description") = "Crédito Fonacot"
        'dsTiposVentas.Tables(0).Rows.Add(newRow)

        'newRow = dsTiposVentas.Tables(0).NewRow
        'newRow("ID") = "O"
        'newRow("Description") = "Crédito Facilito"
        'dsTiposVentas.Tables(0).Rows.Add(newRow)


        'newRow = dsTiposVentas.Tables(0).NewRow
        'newRow("ID") = "V"
        'newRow("Description") = "Dportenis Vale"
        'dsTiposVentas.Tables(0).Rows.Add(newRow)

        dsTiposVentas.AcceptChanges()

        Dim dv As New DataView(dsTiposVentas.Tables(0), "CodTipoVenta <> 'M'", "CodTipoventa asc", DataViewRowState.CurrentRows)
        'CodTipoVenta <> 'P' and 
        cmbTipoDeVenta.DataSource = dv 'dsTiposVentas.Tables(0)
        cmbTipoDeVenta.DropDownList.Columns.Add("Cod.")
        cmbTipoDeVenta.DropDownList.Columns.Add("Descripción")

        cmbTipoDeVenta.DropDownList.Columns("Cod.").DataMember = "CodTipoVenta"
        cmbTipoDeVenta.DropDownList.Columns("Cod.").Width = 50
        cmbTipoDeVenta.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        cmbTipoDeVenta.DropDownList.Columns("Descripción").Width = 150

        cmbTipoDeVenta.DisplayMember = "Descripcion"
        cmbTipoDeVenta.ValueMember = "CodTipoVenta"


    End Sub

    Private Sub FillCatalogoLinea()

        Dim dsCatalogoLinea As DataSet

        Dim oCatalogoLineasMgr As New CatalogoLineasManager(oAppContext)
        dsCatalogoLinea = oCatalogoLineasMgr.GetAll(True).Copy

        Me.cmbLinea.DataSource = dsCatalogoLinea.Tables("CatalogoLineas")
        Me.cmbLinea.DropDownList.Columns.Add("Cod.")
        Me.cmbLinea.DropDownList.Columns.Add("Descripción")

        Me.cmbLinea.DropDownList.Columns("Cod.").DataMember = "CodLinea"
        Me.cmbLinea.DropDownList.Columns("Cod.").Width = 50
        Me.cmbLinea.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        Me.cmbLinea.DropDownList.Columns("Descripción").Width = 150

        Me.cmbLinea.DisplayMember = "Descripcion"
        Me.cmbLinea.ValueMember = "CodLinea"
    End Sub

    Private Sub FillCatalogoFamilia()

        Dim dsCatalogoFamilia As DataSet

        Dim oCatalogoFamiliasMgr As New CatalogoFamiliasManager(oAppContext)
        dsCatalogoFamilia = oCatalogoFamiliasMgr.GetAll(True).Copy

        Me.cmbFamilia.DataSource = dsCatalogoFamilia.Tables("CatalogoFamilias")
        Me.cmbFamilia.DropDownList.Columns.Add("Cod.")
        Me.cmbFamilia.DropDownList.Columns.Add("Descripción")

        Me.cmbFamilia.DropDownList.Columns("Cod.").DataMember = "CodFamilia"
        Me.cmbFamilia.DropDownList.Columns("Cod.").Width = 50
        Me.cmbFamilia.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        Me.cmbFamilia.DropDownList.Columns("Descripción").Width = 150

        Me.cmbFamilia.DisplayMember = "Descripcion"
        Me.cmbFamilia.ValueMember = "CodFamilia"

    End Sub

    Private Sub FillCatalogoMarcas()

        Dim dsCatalogoMarcas As DataSet

        Dim oCatalogoMarcasMgr As New CatalogoMarcasManager(oAppContext)
        dsCatalogoMarcas = oCatalogoMarcasMgr.GetAll(True).Copy

        Me.cmbMarca.DataSource = dsCatalogoMarcas.Tables("CatalogoMarcas")
        Me.cmbMarca.DropDownList.Columns.Add("Cod.")
        Me.cmbMarca.DropDownList.Columns.Add("Descripción")

        Me.cmbMarca.DropDownList.Columns("Cod.").DataMember = "CodMarca"
        Me.cmbMarca.DropDownList.Columns("Cod.").Width = 50
        Me.cmbMarca.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        Me.cmbMarca.DropDownList.Columns("Descripción").Width = 150

        Me.cmbMarca.DisplayMember = "Descripcion"
        Me.cmbMarca.ValueMember = "CodMarca"
    End Sub

#End Region

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        Dim TipoVenta As String

        If cmbTipoDeVenta.Value = "" Then

            MessageBox.Show("Seleccione un tipo de venta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbTipoDeVenta.Focus()
            Exit Sub

        Else

            TipoVenta = cmbTipoDeVenta.Value

        End If


        If rdbPlayer.Checked Then

            PrintReport(TipoVenta)

        End If

        If Me.rdbLineaFam.Checked Or Me.rdbCodigo.Checked Then

            If Me.rdbLineaFam.Checked Then
                If (Me.cmbLinea.Value Is Nothing) Then

                    MessageBox.Show("Seleccione linea", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cmbLinea.Focus()
                    Exit Sub

                ElseIf (Me.cmbFamilia.Value Is Nothing) Then

                    MessageBox.Show("Seleccione un tipo de familia", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cmbFamilia.Focus()
                    Exit Sub

                End If

                PrintReportCodigo(TipoVenta, "LineaFam")

            Else

                PrintReportCodigo(TipoVenta, "Codigo")

            End If
        End If


        If rdbFamiliaMarca.Checked Then


            If (Me.cmbFamilia.Value Is Nothing) Then

                MessageBox.Show("Seleccione un tipo de familia", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbFamilia.Focus()
                Exit Sub

            End If

            PrintReportFamiliaMarca(TipoVenta)

        End If

        If Me.rdbMarcaLineaFamilia.Checked Then

            If Me.cmbMarca.Value Is Nothing Then

                MessageBox.Show("Seleccione marca", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbMarca.Focus()
                Exit Sub

            ElseIf (Me.cmbLinea.Value Is Nothing) Then

                MessageBox.Show("Seleccione linea", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbLinea.Focus()
                Exit Sub

            ElseIf (Me.cmbFamilia.Value Is Nothing) Then

                MessageBox.Show("Seleccione un tipo de familia", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbFamilia.Focus()
                Exit Sub

            End If

            PrintReportCodigo(TipoVenta, "MarcaLineaFamilia")

        End If

        If rdbMarcas.Checked Then

            PrintReportMarcas(TipoVenta)

        End If

        If rdbLinea.Checked Then

            PrintReportLineas(TipoVenta)

        End If

        If rdbFamilias.Checked Then

            PrintReportFamilias(TipoVenta)

        End If

        If rdbSucursal.Checked Then

            PrintReportSucursal(TipoVenta)

        End If

        If rdbUso.Checked Then

            PrintReportUsos(TipoVenta)

        End If

        If rdbVentasPorDia.Checked Then

            PrintReportDias(TipoVenta)

        End If

        If rdbComparativo.Checked Then

            PrintReportComparativo(TipoVenta)

        End If

        If rbMetasPlayer.Checked Then
            If cmbTipoDeVenta.Value = "T" Then 'AndAlso CStr(UiCmbBoxOrdenarPor.SelectedValue).ToUpper() = "IMPORTE" Then
                UiCmbBoxOrdenarPor.Text = "IMPORTE"
                PrintReportMetaPlayer(ccFechaDesde.Value, ccFechaHasta.Value)
            Else
                MessageBox.Show("Este reporte solo es por todas las ventas y ordenado por Importe", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If

    End Sub


#Region "Procedimientos de Impresion"

    Private Sub PrintReportMetaPlayer(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime)
        Dim reporte As New rptMetasPlayers(fechaInicio, fechaFin)
        Dim oReportViewer As New ReportViewerForm
        reporte.Document.Name = "Reporte Meta Players"
        reporte.Run()
        oReportViewer.Report = reporte
        oReportViewer.Show()
    End Sub

    Public Sub PrintReportComparativo(ByVal TipoVenta As String)

        Dim oARReporte As New rptVentasComparativo(TipoVenta, Me.ccFechaDesde.Value, Me.ccFechaHasta.Value, UiCmbBoxOrdenarPor.Text)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Analisis Comparativo"

        'oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            oARReporte.Document.Print(True, True)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub PrintReportDias(ByVal TipoVenta As String)

        Dim oARReporte As New rptVentasDias(TipoVenta, Me.ccFechaDesde.Value, Me.ccFechaHasta.Value, UiCmbBoxOrdenarPor.Text)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Analisis Dias"
        'oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            'oARReporte.Document.Print(True, True)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Public Sub PrintReportUsos(ByVal TipoVenta As String)

        Dim oARReporte As New rptVentasUsos(TipoVenta, ccFechaDesde.Value, ccFechaHasta.Value, UiCmbBoxOrdenarPor.Text)
        Dim oReportViewer As New ReportViewerForm


        oARReporte.Document.Name = "Ventas Uso"
        'oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            'oARReporte.Document.Print(True, True)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub PrintReportSucursal(ByVal TipoVenta As String)

        Dim oARReporte As New rptVentasSucursal(TipoVenta, ccFechaDesde.Value, ccFechaHasta.Value, UiCmbBoxOrdenarPor.Text)
        Dim oReportViewer As New ReportViewerForm


        oARReporte.Document.Name = "Ventas Sucursal"
        'oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            'oARReporte.Document.Print(True, True)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Public Sub PrintReportFamilias(ByVal TipoVenta As String)

        Dim oARReporte As New rptVentasFamilias(TipoVenta, ccFechaDesde.Value, ccFechaHasta.Value, UiCmbBoxOrdenarPor.Text)
        Dim oReportViewer As New ReportViewerForm


        oARReporte.Document.Name = "Ventas Familia"
        'oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            'oARReporte.Document.Print(True, True)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub PrintReportLineas(ByVal TipoVenta As String)

        Dim oARReporte As New rptVentasLineas(TipoVenta, ccFechaDesde.Value, ccFechaHasta.Value, UiCmbBoxOrdenarPor.Text)
        Dim oReportViewer As New ReportViewerForm


        oARReporte.Document.Name = "Ventas Linea"
        'oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            'oARReporte.Document.Print(True, True)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub PrintReportMarcas(ByVal TipoVenta As String)

        Dim oARReporte As New rptVentasMarcas(TipoVenta, ccFechaDesde.Value, ccFechaHasta.Value, UiCmbBoxOrdenarPor.Text)
        Dim oReportViewer As New ReportViewerForm


        oARReporte.Document.Name = "Ventas Marca"
        'oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            'oARReporte.Document.Print(True, True)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub PrintReportFamiliaMarca(ByVal TipoVenta As String)

        Dim oARReporte As New rptFamiliaMarca(TipoVenta, Me.cmbFamilia.Value, Me.ccFechaDesde.Value, Me.ccFechaHasta.Value, UiCmbBoxOrdenarPor.Text)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Ventas Familia/Marca"
        'oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            oARReporte.Document.Print(True, True)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub PrintReportCodigo(ByVal TipoVenta As String, ByVal TipoReporte As String)

        Dim oARReporte As New rptVentasCodigo(TipoReporte, TipoVenta, Me.cmbMarca.Value, Me.cmbLinea.Value, Me.cmbFamilia.Value, Me.ccFechaDesde.Value, Me.ccFechaHasta.Value, UiCmbBoxOrdenarPor.Text)
        Dim oReportViewer As New ReportViewerForm

        If TipoReporte.Equals("LineaFam") Then
            oARReporte.Document.Name = "Ventas Linea/Familia"

        ElseIf TipoReporte.Equals("MarcaLineaFamilia") Then

            oARReporte.Document.Name = "Ventas Marca/Linea/Familia"

        Else

            oARReporte.Document.Name = "Ventas Codigo"

        End If
        'oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            'oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub PrintReport(ByVal TipoVenta As String)

        Dim oARReporte As New rptVentasPlayerDPVale(TipoVenta, ccFechaDesde.Value, ccFechaHasta.Value, UiCmbBoxOrdenarPor.Text)
        Dim oReportViewer As New ReportViewerForm


        oARReporte.Document.Name = "Ventas Player"
        'oARReporte.Run()

        oReportViewer.Report = oARReporte
        oARReporte.Run()
        oReportViewer.Show()

        Try
            'oARReporte.Document.Print(True, True)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

#End Region


#Region "Control de Combos"

    Private Sub rdbLineaFam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbLineaFam.CheckedChanged
        If rdbLineaFam.Checked Then
            Me.cmbFamilia.Enabled = True
            Me.cmbLinea.Enabled = True
        Else
            Me.cmbFamilia.Enabled = False
            Me.cmbLinea.Enabled = False
        End If
    End Sub

    Private Sub rdbFamiliaMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbFamiliaMarca.CheckedChanged
        If Me.rdbFamiliaMarca.Checked Then

            Me.cmbFamilia.Enabled = True

        Else
            Me.cmbFamilia.Enabled = False

        End If

    End Sub

    Private Sub rdbMarcaLineaFamilia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMarcaLineaFamilia.CheckedChanged

        If rdbMarcaLineaFamilia.Checked Then

            Me.cmbFamilia.Enabled = True
            Me.cmbLinea.Enabled = True
            Me.cmbMarca.Enabled = True

        Else

            Me.cmbFamilia.Enabled = False
            Me.cmbLinea.Enabled = False
            Me.cmbMarca.Enabled = False

        End If

    End Sub

#End Region


    Private Sub frmAnalisisDeVentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub frmAnalisisDeVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ccFechaDesde.Value = Date.Now
        ccFechaHasta.Value = Date.Now

        FillTipoVenta()
        FillCatalogoLinea()
        FillCatalogoMarcas()
        FillCatalogoFamilia()

    End Sub
End Class
