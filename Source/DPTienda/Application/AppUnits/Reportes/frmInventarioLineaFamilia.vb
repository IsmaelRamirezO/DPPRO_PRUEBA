Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias
Imports DportenisPro.DPTienda.Reports.Inventario


Public Class frmInventarioLineaFamilia
    Inherits System.Windows.Forms.Form

    Dim oReport As New InventarioReport
    Dim oReporter As New InventarioLineaFamilia

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
    Friend WithEvents cmbFamilia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbLinea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ccMes As Janus.Windows.EditControls.UIComboBox
    Protected Friend WithEvents geResults As Janus.Windows.GridEX.GridEX
    Friend WithEvents btImprimir As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventarioLineaFamilia))
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem7 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem8 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem9 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem10 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem11 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem12 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btImprimir = New Janus.Windows.EditControls.UIButton()
        Me.ccMes = New Janus.Windows.EditControls.UIComboBox()
        Me.geResults = New Janus.Windows.GridEX.GridEX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFamilia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbLinea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
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
        Me.ExplorerBar1.Controls.Add(Me.btImprimir)
        Me.ExplorerBar1.Controls.Add(Me.ccMes)
        Me.ExplorerBar1.Controls.Add(Me.geResults)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.cmbFamilia)
        Me.ExplorerBar1.Controls.Add(Me.cmbLinea)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Location = New System.Drawing.Point(-8, -8)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(656, 361)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btImprimir
        '
        Me.btImprimir.BackColor = System.Drawing.SystemColors.Window
        Me.btImprimir.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btImprimir.Image = CType(resources.GetObject("btImprimir.Image"), System.Drawing.Image)
        Me.btImprimir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Empty
        Me.btImprimir.Location = New System.Drawing.Point(272, 72)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(96, 32)
        Me.btImprimir.TabIndex = 4
        Me.btImprimir.Text = "&Imprimir"
        Me.btImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ccMes
        '
        Me.ccMes.AutoSize = False
        Me.ccMes.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "Enero"
        UiComboBoxItem1.Value = "1"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "Febrero"
        UiComboBoxItem2.Value = "2"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "Marzo"
        UiComboBoxItem3.Value = "3"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "Abril"
        UiComboBoxItem4.Value = "4"
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "Mayo"
        UiComboBoxItem5.Value = "5"
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "Junio"
        UiComboBoxItem6.Value = "6"
        UiComboBoxItem7.FormatStyle.Alpha = 0
        UiComboBoxItem7.IsSeparator = False
        UiComboBoxItem7.Text = "Julio"
        UiComboBoxItem7.Value = "7"
        UiComboBoxItem8.FormatStyle.Alpha = 0
        UiComboBoxItem8.IsSeparator = False
        UiComboBoxItem8.Text = "Agosto"
        UiComboBoxItem8.Value = "8"
        UiComboBoxItem9.FormatStyle.Alpha = 0
        UiComboBoxItem9.IsSeparator = False
        UiComboBoxItem9.Text = "Septiembre"
        UiComboBoxItem9.Value = "9"
        UiComboBoxItem10.FormatStyle.Alpha = 0
        UiComboBoxItem10.IsSeparator = False
        UiComboBoxItem10.Text = "Octubre"
        UiComboBoxItem10.Value = "10"
        UiComboBoxItem11.FormatStyle.Alpha = 0
        UiComboBoxItem11.IsSeparator = False
        UiComboBoxItem11.Text = "Noviembre"
        UiComboBoxItem11.Value = "11"
        UiComboBoxItem12.FormatStyle.Alpha = 0
        UiComboBoxItem12.IsSeparator = False
        UiComboBoxItem12.Text = "Diciembre"
        UiComboBoxItem12.Value = "12"
        Me.ccMes.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5, UiComboBoxItem6, UiComboBoxItem7, UiComboBoxItem8, UiComboBoxItem9, UiComboBoxItem10, UiComboBoxItem11, UiComboBoxItem12})
        Me.ccMes.Location = New System.Drawing.Point(80, 24)
        Me.ccMes.Name = "ccMes"
        Me.ccMes.Size = New System.Drawing.Size(168, 24)
        Me.ccMes.TabIndex = 0
        Me.ccMes.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'geResults
        '
        Me.geResults.AllowColumnDrag = False
        Me.geResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.geResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.geResults.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        Me.geResults.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.geResults.DesignTimeLayout = GridEXLayout1
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.geResults.GroupByBoxVisible = False
        Me.geResults.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.geResults.Location = New System.Drawing.Point(8, 160)
        Me.geResults.Name = "geResults"
        Me.geResults.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.geResults.ShowEmptyFields = False
        Me.geResults.Size = New System.Drawing.Size(512, 161)
        Me.geResults.TabIndex = 5
        Me.geResults.TabStop = False
        Me.geResults.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 12)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Mes"
        '
        'cmbFamilia
        '
        Me.cmbFamilia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbFamilia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbFamilia.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.cmbFamilia.DesignTimeLayout = GridEXLayout2
        Me.cmbFamilia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFamilia.Location = New System.Drawing.Point(80, 88)
        Me.cmbFamilia.Name = "cmbFamilia"
        Me.cmbFamilia.Size = New System.Drawing.Size(168, 22)
        Me.cmbFamilia.TabIndex = 2
        Me.cmbFamilia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbFamilia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbLinea
        '
        Me.cmbLinea.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbLinea.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbLinea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.cmbLinea.DesignTimeLayout = GridEXLayout3
        Me.cmbLinea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLinea.Location = New System.Drawing.Point(80, 56)
        Me.cmbLinea.Name = "cmbLinea"
        Me.cmbLinea.Size = New System.Drawing.Size(168, 22)
        Me.cmbLinea.TabIndex = 1
        Me.cmbLinea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbLinea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Window
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Empty
        Me.btnGenerar.Location = New System.Drawing.Point(272, 32)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(96, 32)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 23)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Familia"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 23)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Línea"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmInventarioLineaFamilia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(512, 310)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.Name = "frmInventarioLineaFamilia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Inventario Linea Familia"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Llenar Combos"

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

#End Region

    Private Sub ActionGenerate()

        oReporter.Mes = Me.ccMes.SelectedValue
        oReporter.CodLinea = Me.cmbLinea.Value
        oReporter.CodFamilia = Me.cmbFamilia.Value

        oReporter.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        oReport.CurrentReporter = oReporter

        oReport.Generate()

        If oReport.Data Is Nothing Then

            MsgBox("Los datos proporcionados no generaron registros.", MsgBoxStyle.Exclamation)

            geResults.DataSource = Nothing
            ccMes.Focus()


            Exit Sub
        End If

        geResults.SetDataBinding(oReport.Data, oReport.Data.Tables(0).TableName)

        'ActionPreview()

    End Sub

    Private Sub ActionPreview()

        Dim oARReporte As New rptInventarioExistenciasLineaFamilia(Me.ccMes.SelectedValue, Me.cmbLinea.Value, Me.cmbFamilia.Value, Me.ccMes.Text)
        Dim oReportViewer As New ReportViewerForm

        'If (oReport.Data Is Nothing) Then
        '    MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
        '    Exit Sub
        'End If

        'oARReporte.DataSource = oReport.Data.Tables(0)
        'oARReporte.Document.Name = "Reporte de Inventario"
        oARReporte.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
        oARReporte.Run()
        oARReporte.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
        oReportViewer.Report = oARReporte
        oReportViewer.Show()

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        If Me.cmbLinea.Value = Nothing Then

            MessageBox.Show("Seleccione una linea", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbLinea.Focus()

            Exit Sub

        ElseIf Me.cmbFamilia.Value = Nothing Then

            MessageBox.Show("Seleccione una familia", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbFamilia.Focus()

            Exit Sub

        End If

        ActionGenerate()

    End Sub

    Private Sub frmInventarioLineaFamilia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCatalogoLinea()
        FillCatalogoFamilia()
        Me.ccMes.SelectedIndex = Now.Month
    End Sub

    Private Sub frmInventarioLineaFamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

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

End Class
