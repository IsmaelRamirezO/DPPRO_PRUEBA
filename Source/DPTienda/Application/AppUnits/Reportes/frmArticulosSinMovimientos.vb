Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.Reports.Inventario


Public Class frmArticulosSinMovimientos
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMarcas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents nbDiasSinMovimiento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbFamilias As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbLineas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Protected Friend WithEvents geResults As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArticulosSinMovimientos))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.geResults = New Janus.Windows.GridEX.GridEX()
        Me.cmbLineas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbFamilias = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbMarcas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nbDiasSinMovimiento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.geResults)
        Me.ExplorerBar1.Controls.Add(Me.cmbLineas)
        Me.ExplorerBar1.Controls.Add(Me.cmbFamilias)
        Me.ExplorerBar1.Controls.Add(Me.cmbMarcas)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.nbDiasSinMovimiento)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(768, 429)
        Me.ExplorerBar1.TabIndex = 6
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(396, 400)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 23)
        Me.Label7.TabIndex = 139
        Me.Label7.Text = "Nuevo"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(372, 400)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 23)
        Me.Label8.TabIndex = 138
        Me.Label8.Text = "F4"
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Window
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Empty
        Me.btnGenerar.Location = New System.Drawing.Point(280, 88)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(96, 32)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
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
        Me.geResults.Location = New System.Drawing.Point(0, 160)
        Me.geResults.Name = "geResults"
        Me.geResults.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.geResults.ShowEmptyFields = False
        Me.geResults.Size = New System.Drawing.Size(768, 232)
        Me.geResults.TabIndex = 5
        Me.geResults.TabStop = False
        Me.geResults.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbLineas
        '
        Me.cmbLineas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbLineas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbLineas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbLineas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.cmbLineas.DesignTimeLayout = GridEXLayout2
        Me.cmbLineas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLineas.Location = New System.Drawing.Point(130, 96)
        Me.cmbLineas.Name = "cmbLineas"
        Me.cmbLineas.Size = New System.Drawing.Size(128, 22)
        Me.cmbLineas.TabIndex = 2
        Me.cmbLineas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbLineas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbFamilias
        '
        Me.cmbFamilias.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbFamilias.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbFamilias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbFamilias.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.cmbFamilias.DesignTimeLayout = GridEXLayout3
        Me.cmbFamilias.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFamilias.Location = New System.Drawing.Point(130, 128)
        Me.cmbFamilias.Name = "cmbFamilias"
        Me.cmbFamilias.Size = New System.Drawing.Size(128, 22)
        Me.cmbFamilias.TabIndex = 3
        Me.cmbFamilias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbFamilias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbMarcas
        '
        Me.cmbMarcas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbMarcas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbMarcas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbMarcas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.cmbMarcas.DesignTimeLayout = GridEXLayout4
        Me.cmbMarcas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMarcas.Location = New System.Drawing.Point(130, 64)
        Me.cmbMarcas.Name = "cmbMarcas"
        Me.cmbMarcas.Size = New System.Drawing.Size(128, 22)
        Me.cmbMarcas.TabIndex = 1
        Me.cmbMarcas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMarcas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(74, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 23)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "Línea.:"
        '
        'nbDiasSinMovimiento
        '
        Me.nbDiasSinMovimiento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbDiasSinMovimiento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbDiasSinMovimiento.BackColor = System.Drawing.Color.White
        Me.nbDiasSinMovimiento.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbDiasSinMovimiento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbDiasSinMovimiento.Location = New System.Drawing.Point(184, 32)
        Me.nbDiasSinMovimiento.Name = "nbDiasSinMovimiento"
        Me.nbDiasSinMovimiento.Size = New System.Drawing.Size(75, 23)
        Me.nbDiasSinMovimiento.TabIndex = 0
        Me.nbDiasSinMovimiento.Text = "0"
        Me.nbDiasSinMovimiento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbDiasSinMovimiento.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbDiasSinMovimiento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 23)
        Me.Label5.TabIndex = 132
        Me.Label5.Text = "Días sin Movimiento.:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(284, 400)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Exportar"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(260, 400)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 23)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "F5"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(66, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Familia.:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 23)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Marca.:"
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(172, 400)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 23)
        Me.Label22.TabIndex = 124
        Me.Label22.Text = "Imprimir"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(156, 400)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 23)
        Me.Label21.TabIndex = 123
        Me.Label21.Text = "F9"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(492, 400)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 23)
        Me.Label16.TabIndex = 122
        Me.Label16.Text = "Salir"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(468, 400)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 23)
        Me.Label13.TabIndex = 121
        Me.Label13.Text = "Esc"
        '
        'frmArticulosSinMovimientos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(768, 429)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(488, 392)
        Me.Name = "frmArticulosSinMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Articulos Sin Movimientos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Gloables"
    Dim dsArticulos As DataSet

    Dim oCatalogoMarcasMgr As CatalogoMarcasManager
    Dim dsMarcas As New DataSet

    Dim oCatalogoLineasMgr As CatalogoLineasManager
    Dim dsLineas As New DataSet

    Dim oCatalogoFamiliasMgr As CatalogoFamiliasManager
    Dim dsFamilias As New DataSet

    Dim oReport As InventarioReport
    Dim oReporter As ArticulosSinMovimientos

#End Region

#Region "Procedimientos para llenar Combos"

    Private Sub FillMarcas()
        oCatalogoMarcasMgr = New CatalogoMarcasManager(oAppContext)
        dsMarcas = oCatalogoMarcasMgr.GetAll(True)

        With Me.cmbMarcas
            .DataSource = dsMarcas
            .DataMember = dsMarcas.Tables(0).TableName
            .DropDownList.Columns.Add("CodMarca")
            .DropDownList.Columns.Add("Descripción")
            '.DropDownList.Columns("CodCaja").Visible = False
            .DropDownList.Columns("CodMarca").DataMember = "CodMarca"
            .DropDownList.Columns("Descripción").DataMember = "Descripcion"
            .DropDownList.Columns("Descripción").Width = 50

            .DisplayMember = "Descripcion"
            .ValueMember = "CodMarca"

            .Refresh()

        End With
    End Sub

    Private Sub FillLineas()
        oCatalogoLineasMgr = New CatalogoLineasManager(oAppContext)
        dsLineas = oCatalogoLineasMgr.GetAll(True)

        With Me.cmbLineas
            .DataSource = dsLineas
            .DataMember = dsLineas.Tables(0).TableName
            .DropDownList.Columns.Add("CodLinea")
            .DropDownList.Columns.Add("Descripción")
            '.DropDownList.Columns("CodCaja").Visible = False
            .DropDownList.Columns("CodLinea").DataMember = "CodLinea"
            .DropDownList.Columns("Descripción").DataMember = "Descripcion"
            .DropDownList.Columns("Descripción").Width = 50

            .DisplayMember = "Descripcion"
            .ValueMember = "CodLinea"

            .Refresh()

        End With
    End Sub

    Private Sub FillFamilias()
        oCatalogoFamiliasMgr = New CatalogoFamiliasManager(oAppContext)
        dsFamilias = oCatalogoFamiliasMgr.GetAll(True)

        With Me.cmbFamilias
            .DataSource = dsFamilias
            .DataMember = dsFamilias.Tables(0).TableName
            .DropDownList.Columns.Add("CodFamilia")
            .DropDownList.Columns.Add("Descripción")
            '.DropDownList.Columns("CodCaja").Visible = False
            .DropDownList.Columns("CodFamilia").DataMember = "CodFamilia"
            .DropDownList.Columns("Descripción").DataMember = "Descripcion"
            .DropDownList.Columns("Descripción").Width = 50

            .DisplayMember = "Descripcion"
            .ValueMember = "CodFamilia"

            .Refresh()

        End With
    End Sub
#End Region

#Region "Eventos Form."

    Private Sub frmArticulosSinMovimientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillMarcas()
        FillLineas()
        FillFamilias()

        oReport = New InventarioReport
        oReporter = New ArticulosSinMovimientos
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        Me.Cursor = Cursors.WaitCursor

        If Me.cmbMarcas.Text = String.Empty Then

            If Me.cmbLineas.Text = String.Empty Then

                MessageBox.Show("Seleccione una linea", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbLineas.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub

            ElseIf Me.cmbFamilias.Text = String.Empty Then

                MessageBox.Show("Seleccione una familia", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbFamilias.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub

            End If

        Else

            If (Me.cmbLineas.Text <> String.Empty) And (Me.cmbFamilias.Text = String.Empty) Then

                MessageBox.Show("Seleccione Familia", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbFamilias.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            ElseIf (Me.cmbFamilias.Text = String.Empty) Then

                MessageBox.Show("Seleccione Familia", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbFamilias.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub

            End If

        End If


        ActionGenerate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmArticulosSinMovimientos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F9 Then

            Me.Cursor = Cursors.WaitCursor
            ActionPreview()
            Me.Cursor = Cursors.Default

        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        ElseIf e.KeyCode = Keys.F5 Then
            Me.Cursor = Cursors.WaitCursor
            ExportaArtículos()
            Me.Cursor = Cursors.Default
            'MsgBox("En construcción")

        ElseIf e.KeyCode = Keys.F4 Then
            Me.Cursor = Cursors.WaitCursor
            Me.cmbMarcas.Text = String.Empty
            Me.cmbLineas.Text = String.Empty
            Me.cmbFamilias.Text = String.Empty
            oReport = New InventarioReport
            oReporter = New ArticulosSinMovimientos
            Me.Cursor = Cursors.Default

        End If
    End Sub

    Private Sub geResults_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles geResults.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "Procedimientos Privados"

    Private Sub ActionGenerate()

        oReporter.Dias = Me.nbDiasSinMovimiento.Value

        If Not Me.cmbMarcas.Value Is Nothing Then
            oReporter.CodMarca = Me.cmbMarcas.Value
        Else
            oReporter.CodMarca = String.Empty
        End If

        If Not Me.cmbLineas.Value Is Nothing Then
            oReporter.CodLinea = Me.cmbLineas.Value
        Else
            oReporter.CodLinea = String.Empty
        End If

        If Not Me.cmbFamilias.Value Is Nothing Then
            oReporter.CodFamilia = Me.cmbFamilias.Value
        Else
            oReporter.CodFamilia = String.Empty
        End If

        oReporter.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen

        oReporter.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        oReport.CurrentReporter = oReporter

        oReport.Generate()

        If oReport.Data Is Nothing Then

            MsgBox("Los datos proporcionados no generaron registros.", MsgBoxStyle.Exclamation)

            geResults.DataSource = Nothing
            Me.nbDiasSinMovimiento.Focus()


            Exit Sub
        End If

        geResults.SetDataBinding(oReporter.FormatToGrid(), oReporter.FormatToGrid.Tables(0).TableName)

    End Sub

    Private Sub ActionPreview()

        Try

            If (oReport.Data Is Nothing) Then
                MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
                Exit Sub
            End If

            Dim oARReporte As New rptArticulosSinMovimientos(Me.oReporter)
            Dim oReportViewer As New ReportViewerForm

            oARReporte.Run()
            oReportViewer.Report = oARReporte
            oReportViewer.Show()

        Catch ex As Exception

            Throw ex

        End Try
        

    End Sub

#End Region

#Region "Exportación"

    Private Sub ExportaArtículos()

        Dim SaveDialog = New SaveFileDialog
        Dim strRuta As String = String.Empty
        Dim isExcelOpen As Boolean = False

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
        wsxl.Name = "Reporte de Artículos sin Movimientos"

        wsxl.PageSetup.Orientation = 2
        '****************************************
        'HOJA DE CALCULO "REPORTE DE ARTICULOS SIN MOVIMIENTOS"
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE ARTICULOS SIN MOVIMIENTOS"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:E1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:E1").BorderAround(, 2, 0, )
        wsxl.Range("A1:E1").HorizontalAlignment = 3

        wsxl.Cells(2, 5).Value = Format(Date.Now, "short date")
        wsxl.Cells(2, 5).Font.Size = 10
        wsxl.Cells(2, 5).Font.Bold = True

        wsxl.Cells(3, 1).Value = "Dias sin Movimientos: " & Me.nbDiasSinMovimiento.Value
        wsxl.Cells(3, 1).Font.Size = 10
        wsxl.Cells(3, 1).Font.Bold = True

        wsxl.Range("A3:E3").Merge()
        wsxl.Cells(4, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(4, 1).Font.Size = 10
        wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Range("A4:E4").Merge()
        wsxl.Range("A3:E4").HorizontalAlignment = 3

        '''''Filtros

        If Not oReporter.CodMarca = "" Then
            Dim oMarcas As Marca
            Dim oMarcasMgr As New CatalogoMarcasManager(oAppContext)
            oMarcas = oMarcasMgr.Create
            oMarcas = oMarcasMgr.Load(oReporter.CodMarca)
            wsxl.Cells(5, 1).Value = "Marca.:" & oReporter.CodMarca & " " & oMarcas.Descripcion
            wsxl.Cells(5, 1).Font.Size = 10
            wsxl.Cells(5, 1).Font.Bold = True
        End If

        If Not oReporter.CodLinea = "" Then
            Dim oLineas As Linea
            Dim olineasMgr As New CatalogoLineasManager(oAppContext)
            oLineas = olineasMgr.Create
            oLineas = olineasMgr.Load(oReporter.CodLinea)
            wsxl.Cells(5, 1).Value &= "     Linea.:" & oReporter.CodLinea & " " & oLineas.Descripcion
            wsxl.Cells(5, 1).Font.Size = 10
            wsxl.Cells(5, 1).Font.Bold = True
        End If

        If Not oReporter.CodFamilia = "" Then
            Dim oFamilias As Familias
            Dim oFamiliasMgr As New CatalogoFamiliasManager(oAppContext)
            oFamilias = oFamiliasMgr.Create
            oFamilias = oFamiliasMgr.Load(oReporter.CodFamilia)
            wsxl.Cells(5, 1).Value &= "     Familia.:" & oReporter.CodFamilia & " " & oFamilias.Descripcion
            wsxl.Cells(5, 1).Font.Size = 10
            wsxl.Cells(5, 1).Font.Bold = True
        End If
        wsxl.Range("A5:E5").Merge()
        '''''Filtros

        'Encabezado

        wsxl.Cells(6, 1).Value = "Código"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 2).Value = "Color"
        wsxl.Columns(2).AutoFitColumns()

        wsxl.Cells(6, 3).Value = "Total Código"
        wsxl.Columns(3).AutoFitColumns()

        wsxl.Cells(6, 4).Value = "Tallas"
        wsxl.Columns(4).AutoFitColumns()


        '' Fin Encabezado

        wsxl.Range("A6:D6").Font.Bold = True
        wsxl.Range("A6:D6").HorizontalAlignment = 3
        wsxl.Range("A6:D6").Font.Size = 8
        wsxl.Range("A6:D6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:D6").BorderAround(, 2, 0, )

        intRow = 0

        Dim i As Integer = 2

        Dim dsArticulos As New DataSet
        dsArticulos = oReporter.FormatToReport
        For Each objRow As DataRow In dsArticulos.Tables(0).Rows


            '' Asignar los valores de los registros a las celdas

            wsxl.Cells(6 + i - 1, 1).Value = "'" & objRow.Item("Articulo")
            wsxl.Cells(6 + i, 1).Value = "'" & objRow.Item("Descripcion")
            wsxl.Cells(6 + i - 1, 2).value = "'" & objRow.Item("Color")
            wsxl.Cells(6 + i - 1, 3) = "'" & objRow.Item("Total")
            wsxl.Cells(6 + i - 1, 4).Value = "'" & objRow.Item("Tallas")
            wsxl.Cells(6 + i, 4) = "'" & objRow.Item("TotalNum")
            '' Avanzamos dos filas

            i += 2

        Next

        wsxl.Cells(8 + i, 2).Value = "TOTAL Articulos"
        wsxl.Cells(8 + i, 3).Value = "'" & dsArticulos.Tables(0).Compute("sum(Total)", "Total>0")

        For i = 1 To 4
            wsxl.Columns(i).AutoFitColumns()
        Next


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

#End Region

End Class
