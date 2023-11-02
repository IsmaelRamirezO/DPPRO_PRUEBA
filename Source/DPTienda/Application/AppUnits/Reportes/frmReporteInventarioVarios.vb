Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.Reports.Inventario


Public Class frmReporteInventarioVarios

    Inherits System.Windows.Forms.Form

    Dim strTituloReport As String = String.Empty

    Dim oReport As New InventarioReport
    Dim oReporter As New InventarioReportesVarios

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
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Protected Friend WithEvents geResults As Janus.Windows.GridEX.GridEX
    Friend WithEvents btImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents grpGroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ccMes As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbFamilia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbLinea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbOrigen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkDIP As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteInventarioVarios))
        Dim GridEXLayout7 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout8 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim UiComboBoxItem13 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem14 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem15 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem16 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem17 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem18 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem19 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem20 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem21 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem22 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem23 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem24 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim GridEXLayout9 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout10 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout6 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.grpGroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkDIP = New Janus.Windows.EditControls.UICheckBox()
        Me.cmbOrigen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ccMes = New Janus.Windows.EditControls.UIComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFamilia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbLinea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btImprimir = New Janus.Windows.EditControls.UIButton()
        Me.geResults = New Janus.Windows.GridEX.GridEX()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.grpGroupBox1.SuspendLayout()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExplorerBar1.BackgroundFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ExplorerBar1.BackgroundFormatStyle.BackColorGradient = System.Drawing.SystemColors.Control
        Me.ExplorerBar1.Controls.Add(Me.btnExportar)
        Me.ExplorerBar1.Controls.Add(Me.grpGroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.btImprimir)
        Me.ExplorerBar1.Controls.Add(Me.geResults)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.ItemsStateStyles.FormatStyle.BackgroundGradientMode = Janus.Windows.ExplorerBar.BackgroundGradientMode.DiagonalBackwards
        Me.ExplorerBar1.Location = New System.Drawing.Point(-8, -8)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(1016, 584)
        Me.ExplorerBar1.SpecialGroupsStateStyles.FormatStyle.BackgroundGradientMode = Janus.Windows.ExplorerBar.BackgroundGradientMode.Vertical
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        Me.ExplorerBar1.VisualStyleAreas.BackgroundStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnExportar
        '
        Me.btnExportar.BackColor = System.Drawing.SystemColors.Window
        Me.btnExportar.Enabled = False
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Empty
        Me.btnExportar.Location = New System.Drawing.Point(304, 120)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(144, 32)
        Me.btnExportar.TabIndex = 3
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grpGroupBox1
        '
        Me.grpGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.grpGroupBox1.Controls.Add(Me.chkDIP)
        Me.grpGroupBox1.Controls.Add(Me.cmbOrigen)
        Me.grpGroupBox1.Controls.Add(Me.Label3)
        Me.grpGroupBox1.Controls.Add(Me.cmbMarca)
        Me.grpGroupBox1.Controls.Add(Me.Label2)
        Me.grpGroupBox1.Controls.Add(Me.ccMes)
        Me.grpGroupBox1.Controls.Add(Me.Label1)
        Me.grpGroupBox1.Controls.Add(Me.cmbFamilia)
        Me.grpGroupBox1.Controls.Add(Me.cmbLinea)
        Me.grpGroupBox1.Controls.Add(Me.Label6)
        Me.grpGroupBox1.Controls.Add(Me.Label5)
        Me.grpGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpGroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.grpGroupBox1.Name = "grpGroupBox1"
        Me.grpGroupBox1.Size = New System.Drawing.Size(264, 192)
        Me.grpGroupBox1.TabIndex = 0
        Me.grpGroupBox1.TabStop = False
        Me.grpGroupBox1.Text = "Filtros"
        '
        'chkDIP
        '
        Me.chkDIP.Location = New System.Drawing.Point(16, 168)
        Me.chkDIP.Name = "chkDIP"
        Me.chkDIP.Size = New System.Drawing.Size(224, 16)
        Me.chkDIP.TabIndex = 5
        Me.chkDIP.Text = "Solo Producto de Catálogo"
        Me.chkDIP.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'cmbOrigen
        '
        Me.cmbOrigen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbOrigen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbOrigen.ButtonEnabled = False
        Me.cmbOrigen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout7.LayoutString = resources.GetString("GridEXLayout7.LayoutString")
        Me.cmbOrigen.DesignTimeLayout = GridEXLayout7
        Me.cmbOrigen.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigen.Location = New System.Drawing.Point(72, 76)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.ReadOnly = True
        Me.cmbOrigen.Size = New System.Drawing.Size(168, 21)
        Me.cmbOrigen.TabIndex = 2
        Me.cmbOrigen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbOrigen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 23)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Origen"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMarca
        '
        Me.cmbMarca.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbMarca.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbMarca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout8.LayoutString = resources.GetString("GridEXLayout8.LayoutString")
        Me.cmbMarca.DesignTimeLayout = GridEXLayout8
        Me.cmbMarca.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMarca.Location = New System.Drawing.Point(72, 47)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(168, 21)
        Me.cmbMarca.TabIndex = 1
        Me.cmbMarca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Marca"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ccMes
        '
        Me.ccMes.AutoSize = False
        Me.ccMes.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ccMes.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem13.FormatStyle.Alpha = 0
        UiComboBoxItem13.IsSeparator = False
        UiComboBoxItem13.Text = "ENERO"
        UiComboBoxItem13.Value = "1"
        UiComboBoxItem14.FormatStyle.Alpha = 0
        UiComboBoxItem14.IsSeparator = False
        UiComboBoxItem14.Text = "FEBRERO"
        UiComboBoxItem14.Value = "2"
        UiComboBoxItem15.FormatStyle.Alpha = 0
        UiComboBoxItem15.IsSeparator = False
        UiComboBoxItem15.Text = "MARZO"
        UiComboBoxItem15.Value = "3"
        UiComboBoxItem16.FormatStyle.Alpha = 0
        UiComboBoxItem16.IsSeparator = False
        UiComboBoxItem16.Text = "ABRIL"
        UiComboBoxItem16.Value = "4"
        UiComboBoxItem17.FormatStyle.Alpha = 0
        UiComboBoxItem17.IsSeparator = False
        UiComboBoxItem17.Text = "MAYO"
        UiComboBoxItem17.Value = "5"
        UiComboBoxItem18.FormatStyle.Alpha = 0
        UiComboBoxItem18.IsSeparator = False
        UiComboBoxItem18.Text = "JUNIO"
        UiComboBoxItem18.Value = "6"
        UiComboBoxItem19.FormatStyle.Alpha = 0
        UiComboBoxItem19.IsSeparator = False
        UiComboBoxItem19.Text = "JULIO"
        UiComboBoxItem19.Value = "7"
        UiComboBoxItem20.FormatStyle.Alpha = 0
        UiComboBoxItem20.IsSeparator = False
        UiComboBoxItem20.Text = "AGOSTO"
        UiComboBoxItem20.Value = "8"
        UiComboBoxItem21.FormatStyle.Alpha = 0
        UiComboBoxItem21.IsSeparator = False
        UiComboBoxItem21.Text = "SEPTIEMBRE"
        UiComboBoxItem21.Value = "9"
        UiComboBoxItem22.FormatStyle.Alpha = 0
        UiComboBoxItem22.IsSeparator = False
        UiComboBoxItem22.Text = "OCTUBRE"
        UiComboBoxItem22.Value = "10"
        UiComboBoxItem23.FormatStyle.Alpha = 0
        UiComboBoxItem23.IsSeparator = False
        UiComboBoxItem23.Text = "NOVIEMBRE"
        UiComboBoxItem23.Value = "11"
        UiComboBoxItem24.FormatStyle.Alpha = 0
        UiComboBoxItem24.IsSeparator = False
        UiComboBoxItem24.Text = "DICIEMBRE"
        UiComboBoxItem24.Value = "12"
        Me.ccMes.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem13, UiComboBoxItem14, UiComboBoxItem15, UiComboBoxItem16, UiComboBoxItem17, UiComboBoxItem18, UiComboBoxItem19, UiComboBoxItem20, UiComboBoxItem21, UiComboBoxItem22, UiComboBoxItem23, UiComboBoxItem24})
        Me.ccMes.Location = New System.Drawing.Point(72, 19)
        Me.ccMes.Name = "ccMes"
        Me.ccMes.Size = New System.Drawing.Size(168, 22)
        Me.ccMes.TabIndex = 0
        Me.ccMes.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 12)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Mes"
        '
        'cmbFamilia
        '
        Me.cmbFamilia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbFamilia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbFamilia.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout9.LayoutString = resources.GetString("GridEXLayout9.LayoutString")
        Me.cmbFamilia.DesignTimeLayout = GridEXLayout9
        Me.cmbFamilia.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFamilia.Location = New System.Drawing.Point(72, 133)
        Me.cmbFamilia.Name = "cmbFamilia"
        Me.cmbFamilia.Size = New System.Drawing.Size(168, 21)
        Me.cmbFamilia.TabIndex = 4
        Me.cmbFamilia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbFamilia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbLinea
        '
        Me.cmbLinea.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbLinea.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbLinea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout10.LayoutString = resources.GetString("GridEXLayout10.LayoutString")
        Me.cmbLinea.DesignTimeLayout = GridEXLayout10
        Me.cmbLinea.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLinea.Location = New System.Drawing.Point(72, 105)
        Me.cmbLinea.Name = "cmbLinea"
        Me.cmbLinea.Size = New System.Drawing.Size(168, 21)
        Me.cmbLinea.TabIndex = 3
        Me.cmbLinea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbLinea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 23)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Familia"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 23)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Línea"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btImprimir
        '
        Me.btImprimir.BackColor = System.Drawing.SystemColors.Window
        Me.btImprimir.Enabled = False
        Me.btImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btImprimir.Image = CType(resources.GetObject("btImprimir.Image"), System.Drawing.Image)
        Me.btImprimir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Empty
        Me.btImprimir.Location = New System.Drawing.Point(304, 72)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(144, 32)
        Me.btImprimir.TabIndex = 2
        Me.btImprimir.Text = "&Imprimir"
        Me.btImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'geResults
        '
        Me.geResults.AllowColumnDrag = False
        Me.geResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.geResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.geResults.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken
        Me.geResults.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        Me.geResults.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout6.LayoutString = resources.GetString("GridEXLayout6.LayoutString")
        Me.geResults.DesignTimeLayout = GridEXLayout6
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.geResults.GroupByBoxVisible = False
        Me.geResults.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.geResults.Location = New System.Drawing.Point(16, 214)
        Me.geResults.Name = "geResults"
        Me.geResults.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.geResults.ShowEmptyFields = False
        Me.geResults.Size = New System.Drawing.Size(856, 322)
        Me.geResults.TabIndex = 4
        Me.geResults.TabStop = False
        Me.geResults.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Window
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(304, 24)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(144, 32)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmReporteInventarioVarios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(872, 533)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmReporteInventarioVarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Reportes de Inventario"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.grpGroupBox1.ResumeLayout(False)
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Methods"

#Region "Form Methods"

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        ActionGenerate()

    End Sub

    Private Sub frmReporteInventarioVarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillCatalogoMarcas()
        FillOrigen()
        FillCatalogoLinea()
        FillCatalogoFamilia()
        Me.ccMes.SelectedIndex = Now.Month - 1

    End Sub

    Private Sub frmReporteInventarioVarios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter
                SendKeys.Send("{TAB}")

            Case Keys.Escape
                Me.Finalize()
                Me.Close()

        End Select

    End Sub

    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click

        If oReport.Data Is Nothing Then

            MsgBox("No se han seleccionado registros.", MsgBoxStyle.Exclamation)

            geResults.DataSource = Nothing
            ccMes.Focus()

            Exit Sub

        End If

        ActionPreview()

    End Sub

    Private Sub ccMes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ccMes.Validating

        If ccMes.SelectedIndex + 1 > Now.Month Then

            MsgBox("Mes debe ser menor o igual al actual. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Reportes de Inventario")
            ccMes.SelectedIndex = Now.Month - 1

            e.Cancel = True

        End If

    End Sub

#End Region

#Region "Llenar Combos"

    Private Sub FillCatalogoMarcas()

        Dim dsCatalogoMarcas As DataSet
        Dim oRow As DataRow

        Dim oCatalogoMarcasMgr As New CatalogoMarcasManager(oAppContext)
        dsCatalogoMarcas = oCatalogoMarcasMgr.GetAll(True).Copy
        oRow = dsCatalogoMarcas.Tables(0).NewRow
        oRow!CodMarca = ""
        oRow!Descripcion = "TODAS"
        dsCatalogoMarcas.Tables(0).Rows.Add(oRow)
        oRow = Nothing

        Me.cmbMarca.DataSource = dsCatalogoMarcas.Tables(0)
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

    Private Sub FillOrigen()

        Dim dtOrigen As New DataTable("Origen")
        Dim dCol As DataColumn
        Dim oRow As DataRow

        'Creamos Columnas
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "CodOrigen"
        dCol.Caption = "Cod."
        dCol.MaxLength = 10
        dtOrigen.Columns.Add(dCol)

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "Descripcion"
        dCol.Caption = "Descripción"
        dCol.MaxLength = 30
        dtOrigen.Columns.Add(dCol)

        'Creamos Datos
        oRow = dtOrigen.NewRow
        oRow!CodOrigen = "N"
        oRow!Descripcion = "NACIONAL"
        dtOrigen.Rows.Add(oRow)
        oRow = dtOrigen.NewRow
        oRow!CodOrigen = "I"
        oRow!Descripcion = "IMPORTADO"
        dtOrigen.Rows.Add(oRow)
        oRow = dtOrigen.NewRow
        oRow!CodOrigen = ""
        oRow!Descripcion = "TODAS"
        dtOrigen.Rows.Add(oRow)

        Me.cmbOrigen.DataSource = dtOrigen
        Me.cmbOrigen.DropDownList.Columns.Add("Cod.")
        Me.cmbOrigen.DropDownList.Columns.Add("Descripción")

        Me.cmbOrigen.DropDownList.Columns("Cod.").DataMember = "CodOrigen"
        Me.cmbOrigen.DropDownList.Columns("Cod.").Width = 50
        Me.cmbOrigen.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        Me.cmbOrigen.DropDownList.Columns("Descripción").Width = 150

        Me.cmbOrigen.DisplayMember = "Descripcion"
        Me.cmbOrigen.ValueMember = "CodOrigen"

        Me.cmbOrigen.Value = "N"

    End Sub

    Private Sub FillCatalogoLinea()

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

    Private Sub FillCatalogoFamilia()

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

#End Region

#Region "Action"

    Private Sub ActionGenerate()

        GeneraTipoFiltro()

        oReport.CurrentReporter = oReporter

        oReport.Generate()
        oReport.GenerateToReport()


        If oReport.Data Is Nothing Then

            MsgBox("Los datos proporcionados no generaron registros.", MsgBoxStyle.Information+MSGBOXSTYLE.OKOnly," Reporte de Inventarios")
            geResults.DataSource = Nothing
            btnexportar.Enabled = False
            btimprimir.Enabled = False
            ccMes.Focus()
            Exit Sub

        End If

        btnexportar.Enabled = true
        btimprimir.Enabled = true
        geResults.SetDataBinding(oReport.Data, oReport.Data.Tables(0).TableName)

    End Sub

    Private Sub GeneraTipoFiltro()

        With oReporter

            .CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
            .Mes = Me.ccMes.SelectedValue
            .CodMarca = Me.cmbMarca.Value
            .CodOrigen = IIf(Me.cmbOrigen.Value = "N", 0, IIf(Me.cmbOrigen.Value = "I", 1, 2))
            .CodLinea = Me.cmbLinea.Value
            .CodFamilia = Me.cmbFamilia.Value
            .Dip = IIf(chkDIP.Checked = True, 1, 0)
            .ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()

            If (.CodMarca = String.Empty And .CodOrigen = 2 And .CodLinea = String.Empty And .CodFamilia = String.Empty) Then
                'Todos los casos
                strTituloReport = String.Empty
                .TipoFiltro = 0
            End If

            If (.CodMarca <> String.Empty And .CodOrigen = 2 And .CodLinea = String.Empty And .CodFamilia = String.Empty) Then
                'Marca
                strTituloReport = cmbMarca.Text
                .TipoFiltro = 1
            End If

            If (.CodMarca <> String.Empty And .CodOrigen <> 2 And .CodLinea = String.Empty And .CodFamilia = String.Empty) Then
                'Marca y Origen
                strTituloReport = cmbMarca.Text & " / " & cmbOrigen.Text
                .TipoFiltro = 2
            End If

            If (.CodMarca <> String.Empty And .CodOrigen <> 2 And .CodLinea <> String.Empty And .CodFamilia = String.Empty) Then
                'Marca y Origen y Linea
                strTituloReport = cmbMarca.Text & " / " & cmbOrigen.Text & " / " & cmbLinea.Text
                .TipoFiltro = 3
            End If

            If (.CodMarca <> String.Empty And .CodOrigen <> 2 And .CodLinea <> String.Empty And .CodFamilia <> String.Empty) Then
                'Marca y Origen y Linea y Familia
                strTituloReport = cmbMarca.Text & " / " & cmbOrigen.Text & " / " & cmbLinea.Text & " / " & cmbFamilia.Text
                .TipoFiltro = 4
            End If

            If (.CodMarca <> String.Empty And .CodOrigen <> 2 And .CodLinea = String.Empty And .CodFamilia <> String.Empty) Then
                'Marca y Origen y Familia
                strTituloReport = cmbMarca.Text & " / " & cmbOrigen.Text & " / " & cmbFamilia.Text
                .TipoFiltro = 5
            End If

            If (.CodMarca <> String.Empty And .CodOrigen = 2 And .CodLinea <> String.Empty And .CodFamilia = String.Empty) Then
                'Marca y Linea
                strTituloReport = cmbMarca.Text & " / " & cmbLinea.Text
                .TipoFiltro = 6
            End If

            If (.CodMarca <> String.Empty And .CodOrigen = 2 And .CodLinea <> String.Empty And .CodFamilia <> String.Empty) Then
                'Marca y Linea y Familia
                strTituloReport = cmbMarca.Text & " / " & cmbLinea.Text & " / " & cmbFamilia.Text
                .TipoFiltro = 7
            End If

            If (.CodMarca <> String.Empty And .CodOrigen = 2 And .CodLinea = String.Empty And .CodFamilia <> String.Empty) Then
                'Marca y Familia
                strTituloReport = cmbMarca.Text & " / " & cmbFamilia.Text
                .TipoFiltro = 8
            End If

            If (.CodMarca = String.Empty And .CodOrigen <> 2 And .CodLinea = String.Empty And .CodFamilia = String.Empty) Then
                'Origen
                strTituloReport = cmbOrigen.Text
                .TipoFiltro = 9
            End If

            If (.CodMarca = String.Empty And .CodOrigen <> 2 And .CodLinea <> String.Empty And .CodFamilia = String.Empty) Then
                'Origen y Linea
                strTituloReport = cmbOrigen.Text & " / " & cmbLinea.Text
                .TipoFiltro = 10
            End If

            If (.CodMarca = String.Empty And .CodOrigen <> 2 And .CodLinea <> String.Empty And .CodFamilia <> String.Empty) Then
                'Origen y Linea y Familia
                strTituloReport = cmbOrigen.Text & " / " & cmbLinea.Text & " / " & cmbFamilia.Text
                .TipoFiltro = 11
            End If

            If (.CodMarca = String.Empty And .CodOrigen <> 2 And .CodLinea = String.Empty And .CodFamilia <> String.Empty) Then
                'Origen y Familia
                strTituloReport = cmbOrigen.Text & " / " & cmbFamilia.Text
                .TipoFiltro = 12
            End If

            If (.CodMarca = String.Empty And .CodOrigen = 2 And .CodLinea <> String.Empty And .CodFamilia = String.Empty) Then
                'Linea
                strTituloReport = cmbLinea.Text
                .TipoFiltro = 13
            End If

            If (.CodMarca = String.Empty And .CodOrigen = 2 And .CodLinea <> String.Empty And .CodFamilia <> String.Empty) Then
                'Linea y Familia
                strTituloReport = cmbLinea.Text & " / " & cmbFamilia.Text
                .TipoFiltro = 14
            End If

            If (.CodMarca = String.Empty And .CodOrigen = 2 And .CodLinea = String.Empty And .CodFamilia <> String.Empty) Then
                'Familia
                strTituloReport = cmbFamilia.Text
                .TipoFiltro = 15
            End If

        End With

    End Sub

    Private Sub ActionPreview()

        Try

            If (oReport.Data Is Nothing) Then
                MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
                Exit Sub
            End If

            'Dim oARReporte As New rptReporteDeInventariosVarios(oReporter, strTituloReport, GetAlmacen(), ccMes.Text)
            Dim oARReporte As New rptInventarioNuevo(Me.oReport, ccMes.Text, strTituloReport)
            Dim oReportViewer As New ReportViewerForm

            oARReporte.Run()
            oReportViewer.Report = oARReporte
            oReportViewer.Show()

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    Private Function GetAlmacen() As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim strAlmacen As String = oAppContext.ApplicationConfiguration.Almacen
        Dim AlmacenDescripcion As String = String.Empty
        oAlmacen = oAlmacenMgr.Create
        oAlmacenMgr.LoadInto(strAlmacen, oAlmacen)

        AlmacenDescripcion = strAlmacen & " " & oAlmacen.Descripcion

        oAlmacen = Nothing
        oAlmacenMgr = Nothing

        Return AlmacenDescripcion

    End Function

    Private Sub ExportaReportesVariosInventario()

        Dim SaveDialog = New SaveFileDialog
        Dim strRuta As String = String.Empty

        Dim xlapp
        Dim wbxl
        Dim wsxl

        Dim intRow As Integer 'counter

        Dim oRow As DataRow

        On Error Resume Next

        xlapp = GetObject(, "Excel.Application")

        If xlapp Is Nothing Then
            xlapp = CreateObject("Excel.Application")
            If xlapp Is Nothing Then
                MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Auditoría de Retiros")
                Exit Sub
            End If
        Else
            xlapp = CreateObject("Excel.Application")
        End If

        wbxl = xlapp.Workbooks.Add
        wsxl = xlapp.Sheets(1)
        wsxl.Name = "Inventario"

        '****************************************
        'HOJA DE CALCULO AUDITORIA RETIROS
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE EXISTENCIAS : " & strTituloReport
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:X1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:X1").BorderAround(, 2, 0, )
        wsxl.Range("A1:X1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 1).Value = "Fecha : " & Format(Date.Now, "Long Date")
        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 18).Value = "M E S : "
        wsxl.Cells(2, 20).Value = ccMes.Text
        wsxl.Cells(2, 20).Font.Size = 12
        wsxl.Cells(2, 20).Font.Bold = True

        wsxl.Cells(3, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(3, 1).Font.Size = 10
        wsxl.Cells(3, 1).Font.Bold = True
        wsxl.Range("A3:X3").Merge()
        wsxl.Range("A3:X3").HorizontalAlignment = 3

        'Encabezado
        wsxl.Cells(5, 1).Value = "Código / Descripción"
        'wsxl.Range("A5:B5").Merge()
        wsxl.Cells(5, 2).Value = "Codigo Anterior"
        wsxl.Cells(5, 3).Value = "Total"
        wsxl.Cells(5, 4).Value = "Tallas / Existencias"

        wsxl.Cells(5, 24).Value = "Precio Stock"

        wsxl.Range("A5:X5").Font.Bold = True
        wsxl.Range("A5:X5").HorizontalAlignment = 3
        wsxl.Range("A5:X5").Font.Size = 8
        wsxl.Range("A5:X5").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A5:X5").BorderAround(, 2, 0, )

        wsxl.Range("D5:W5").Merge()

        intRow = 0

        For Each oRow In oReport.Data.Tables(0).Rows
            intRow = intRow + 1
            wsxl.Cells(5 + intRow, 1).Value = oRow!Codigo
            wsxl.Cells(5 + intRow, 2).Value = oRow!CodigoAnterior
            wsxl.Cells(5 + intRow, 3).Value = oRow!TotalA
            wsxl.Cells(5 + intRow, 4).Value = oRow!Talla01
            wsxl.Cells(5 + intRow, 5).Value = oRow!Talla02
            wsxl.Cells(5 + intRow, 6).Value = oRow!Talla03
            wsxl.Cells(5 + intRow, 7).Value = oRow!Talla04
            wsxl.Cells(5 + intRow, 8).Value = oRow!Talla05
            wsxl.Cells(5 + intRow, 9).Value = oRow!Talla06
            wsxl.Cells(5 + intRow, 10).Value = oRow!Talla07
            wsxl.Cells(5 + intRow, 11).Value = oRow!Talla08
            wsxl.Cells(5 + intRow, 12).Value = oRow!Talla09
            wsxl.Cells(5 + intRow, 13).Value = oRow!Talla010
            wsxl.Cells(5 + intRow, 14).Value = oRow!Talla011
            wsxl.Cells(5 + intRow, 15).Value = oRow!Talla012
            wsxl.Cells(5 + intRow, 16).Value = oRow!Talla013
            wsxl.Cells(5 + intRow, 17).Value = oRow!Talla014
            wsxl.Cells(5 + intRow, 18).Value = oRow!Talla015
            wsxl.Cells(5 + intRow, 19).Value = oRow!Talla016
            wsxl.Cells(5 + intRow, 20).Value = oRow!Talla017
            wsxl.Cells(5 + intRow, 21).Value = oRow!Talla018
            wsxl.Cells(5 + intRow, 22).Value = oRow!Talla019
            wsxl.Cells(5 + intRow, 23).Value = oRow!Talla020
            wsxl.Cells(5 + intRow, 24).Value = Format(oRow!PrecioStock, "c")
            If wsxl.Cells(5 + intRow, 1).Value <> "TOTAL DE PARES" Then
                wsxl.Range("D" & Trim(Str(5 + intRow)) & ":W" & Trim(Str(5 + intRow))).Interior.Color = RGB(153, 204, 255)
            End If

            intRow = intRow + 1
            wsxl.Cells(5 + intRow, 1).Value = oRow!Descripcion
            wsxl.Cells(5 + intRow, 4).Value = oRow!Total01
            wsxl.Cells(5 + intRow, 5).Value = oRow!Total02
            wsxl.Cells(5 + intRow, 6).Value = oRow!Total03
            wsxl.Cells(5 + intRow, 7).Value = oRow!Total04
            wsxl.Cells(5 + intRow, 8).Value = oRow!Total05
            wsxl.Cells(5 + intRow, 9).Value = oRow!Total06
            wsxl.Cells(5 + intRow, 10).Value = oRow!Total07
            wsxl.Cells(5 + intRow, 11).Value = oRow!Total08
            wsxl.Cells(5 + intRow, 12).Value = oRow!Total09
            wsxl.Cells(5 + intRow, 13).Value = oRow!Total10
            wsxl.Cells(5 + intRow, 14).Value = oRow!Total11
            wsxl.Cells(5 + intRow, 15).Value = oRow!Total12
            wsxl.Cells(5 + intRow, 16).Value = oRow!Total13
            wsxl.Cells(5 + intRow, 17).Value = oRow!Total14
            wsxl.Cells(5 + intRow, 18).Value = oRow!Total15
            wsxl.Cells(5 + intRow, 19).Value = oRow!Total16
            wsxl.Cells(5 + intRow, 20).Value = oRow!Total17
            wsxl.Cells(5 + intRow, 21).Value = oRow!Total18
            wsxl.Cells(5 + intRow, 22).Value = oRow!Total19
            wsxl.Cells(5 + intRow, 23).Value = oRow!Total20
        Next

        wsxl.Range("A" & Trim(Str(4 + intRow)) & ":C" & Trim(Str(5 + intRow))).Font.Bold = True
        wsxl.Range("D" & Trim(Str(4 + intRow)) & ":W" & Trim(Str(5 + intRow))).BackColor = RGB(255, 255, 255)

        wsxl.Range("A6:A6").ColumnWidth = 27.2
        wsxl.Range("B6:B6").ColumnWidth = 18.2
        wsxl.Range("C6:C6").ColumnWidth = 11
        wsxl.Range("D6:W6").ColumnWidth = 5.6
        wsxl.Range("X6:X6").ColumnWidth = 11
        wsxl.PageSetup.FitToPagesWide = 1
        wsxl.PageSetup.FitToPagesTall = 1

        Me.Cursor = Cursors.Default

        'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
        SaveDialog.DefaultExt = "*.xls"
        SaveDialog.Filter = "(*.xls)|*.xls"
        If SaveDialog.ShowDialog = DialogResult.OK Then
            wbxl.SaveAs(SaveDialog.FileName)
            MsgBox("Documento guardado en " & SaveDialog.FileName, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Repote Notas de Crédito")
        End If

        wbxl.Close()
        wsxl = Nothing
        xlapp.Quit()
        xlapp = Nothing

        KillExcel()

    End Sub

#End Region

#End Region

    Private Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        ExportaReportesVariosInventario()


    End Sub

End Class
