Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.Reports.Inventario
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports NPOI
Imports NPOI.HSSF.Util
Imports NPOI.HSSF.Record
Imports NPOI.HSSF.UserModel
Imports System.IO
Public Class frmReporteCostosInventarios
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        FillCatalogoMarcas()
        FillCatalogoLinea()
        FillCatalogoFamilia()
        'Obtenemos el Almacen en el cual se va a realizar el reporte
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig), strCentro As String = ""
        strCentro = oSAPMgr.Read_Centros
        almacen = mgrAlmacen.Load(strCentro)
        If Not almacen Is Nothing Then txtSucursal.Text = almacen.Descripcion
        oSAPMgr = Nothing
        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents grpGroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbFamilia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbLinea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents lblFamilia As System.Windows.Forms.Label
    Friend WithEvents lblLinea As System.Windows.Forms.Label
    Friend WithEvents gridCostoInventarios As Janus.Windows.GridEX.GridEX
    Friend WithEvents gruopReporte As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalCostos As System.Windows.Forms.Label
    Friend WithEvents lblTotalCostos As System.Windows.Forms.Label
    Friend WithEvents txtPiezas As System.Windows.Forms.Label
    Friend WithEvents lblTotalPiezas As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.Label
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteCostosInventarios))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.gruopReporte = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalCostos = New System.Windows.Forms.Label()
        Me.lblTotalCostos = New System.Windows.Forms.Label()
        Me.txtPiezas = New System.Windows.Forms.Label()
        Me.lblTotalPiezas = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.Label()
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.gridCostoInventarios = New Janus.Windows.GridEX.GridEX()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.btImprimir = New Janus.Windows.EditControls.UIButton()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.grpGroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbMarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.cmbFamilia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbLinea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblFamilia = New System.Windows.Forms.Label()
        Me.lblLinea = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.gruopReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gruopReporte.SuspendLayout()
        CType(Me.gridCostoInventarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.gruopReporte)
        Me.ExplorerBar1.Controls.Add(Me.gridCostoInventarios)
        Me.ExplorerBar1.Controls.Add(Me.btnExportar)
        Me.ExplorerBar1.Controls.Add(Me.btImprimir)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.grpGroupBox1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(778, 454)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'gruopReporte
        '
        Me.gruopReporte.BackColor = System.Drawing.Color.Transparent
        Me.gruopReporte.Controls.Add(Me.txtTotalCostos)
        Me.gruopReporte.Controls.Add(Me.lblTotalCostos)
        Me.gruopReporte.Controls.Add(Me.txtPiezas)
        Me.gruopReporte.Controls.Add(Me.lblTotalPiezas)
        Me.gruopReporte.Controls.Add(Me.txtSucursal)
        Me.gruopReporte.Controls.Add(Me.lblSucursal)
        Me.gruopReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gruopReporte.Location = New System.Drawing.Point(472, 8)
        Me.gruopReporte.Name = "gruopReporte"
        Me.gruopReporte.Size = New System.Drawing.Size(272, 128)
        Me.gruopReporte.TabIndex = 14
        Me.gruopReporte.Text = "Reporte"
        Me.gruopReporte.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'txtTotalCostos
        '
        Me.txtTotalCostos.BackColor = System.Drawing.Color.Transparent
        Me.txtTotalCostos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCostos.Location = New System.Drawing.Point(120, 84)
        Me.txtTotalCostos.Name = "txtTotalCostos"
        Me.txtTotalCostos.Size = New System.Drawing.Size(136, 16)
        Me.txtTotalCostos.TabIndex = 19
        '
        'lblTotalCostos
        '
        Me.lblTotalCostos.AutoSize = True
        Me.lblTotalCostos.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalCostos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCostos.Location = New System.Drawing.Point(16, 84)
        Me.lblTotalCostos.Name = "lblTotalCostos"
        Me.lblTotalCostos.Size = New System.Drawing.Size(91, 13)
        Me.lblTotalCostos.TabIndex = 18
        Me.lblTotalCostos.Text = "Total Costos:"
        '
        'txtPiezas
        '
        Me.txtPiezas.BackColor = System.Drawing.Color.Transparent
        Me.txtPiezas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPiezas.Location = New System.Drawing.Point(120, 52)
        Me.txtPiezas.Name = "txtPiezas"
        Me.txtPiezas.Size = New System.Drawing.Size(128, 16)
        Me.txtPiezas.TabIndex = 17
        '
        'lblTotalPiezas
        '
        Me.lblTotalPiezas.AutoSize = True
        Me.lblTotalPiezas.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalPiezas.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPiezas.Location = New System.Drawing.Point(16, 52)
        Me.lblTotalPiezas.Name = "lblTotalPiezas"
        Me.lblTotalPiezas.Size = New System.Drawing.Size(90, 13)
        Me.lblTotalPiezas.TabIndex = 16
        Me.lblTotalPiezas.Text = "Total Piezas:"
        '
        'txtSucursal
        '
        Me.txtSucursal.BackColor = System.Drawing.Color.Transparent
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSucursal.Location = New System.Drawing.Point(120, 20)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(128, 16)
        Me.txtSucursal.TabIndex = 15
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.BackColor = System.Drawing.Color.Transparent
        Me.lblSucursal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSucursal.Location = New System.Drawing.Point(16, 20)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(67, 13)
        Me.lblSucursal.TabIndex = 14
        Me.lblSucursal.Text = "Sucursal:"
        '
        'gridCostoInventarios
        '
        Me.gridCostoInventarios.AllowColumnDrag = False
        Me.gridCostoInventarios.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridCostoInventarios.DesignTimeLayout = GridEXLayout1
        Me.gridCostoInventarios.GroupByBoxVisible = False
        Me.gridCostoInventarios.Location = New System.Drawing.Point(16, 144)
        Me.gridCostoInventarios.Name = "gridCostoInventarios"
        Me.gridCostoInventarios.Size = New System.Drawing.Size(752, 298)
        Me.gridCostoInventarios.TabIndex = 7
        Me.gridCostoInventarios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnExportar
        '
        Me.btnExportar.BackColor = System.Drawing.SystemColors.Window
        Me.btnExportar.Enabled = False
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Empty
        Me.btnExportar.Location = New System.Drawing.Point(304, 104)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(144, 32)
        Me.btnExportar.TabIndex = 6
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btImprimir
        '
        Me.btImprimir.BackColor = System.Drawing.SystemColors.Window
        Me.btImprimir.Enabled = False
        Me.btImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btImprimir.Image = CType(resources.GetObject("btImprimir.Image"), System.Drawing.Image)
        Me.btImprimir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Empty
        Me.btImprimir.Location = New System.Drawing.Point(304, 56)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(144, 32)
        Me.btImprimir.TabIndex = 5
        Me.btImprimir.Text = "&Imprimir"
        Me.btImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Window
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(304, 8)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(144, 32)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grpGroupBox1
        '
        Me.grpGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.grpGroupBox1.Controls.Add(Me.cmbMarca)
        Me.grpGroupBox1.Controls.Add(Me.lblMarca)
        Me.grpGroupBox1.Controls.Add(Me.cmbFamilia)
        Me.grpGroupBox1.Controls.Add(Me.cmbLinea)
        Me.grpGroupBox1.Controls.Add(Me.lblFamilia)
        Me.grpGroupBox1.Controls.Add(Me.lblLinea)
        Me.grpGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpGroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.grpGroupBox1.Name = "grpGroupBox1"
        Me.grpGroupBox1.Size = New System.Drawing.Size(264, 128)
        Me.grpGroupBox1.TabIndex = 1
        Me.grpGroupBox1.TabStop = False
        Me.grpGroupBox1.Text = "Filtros"
        '
        'cmbMarca
        '
        Me.cmbMarca.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbMarca.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbMarca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.cmbMarca.DesignTimeLayout = GridEXLayout2
        Me.cmbMarca.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMarca.Location = New System.Drawing.Point(72, 24)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(168, 21)
        Me.cmbMarca.TabIndex = 1
        Me.cmbMarca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.BackColor = System.Drawing.Color.Transparent
        Me.lblMarca.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarca.Location = New System.Drawing.Point(16, 24)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(46, 13)
        Me.lblMarca.TabIndex = 37
        Me.lblMarca.Text = "Marca"
        Me.lblMarca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFamilia
        '
        Me.cmbFamilia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbFamilia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbFamilia.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.cmbFamilia.DesignTimeLayout = GridEXLayout3
        Me.cmbFamilia.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFamilia.Location = New System.Drawing.Point(72, 88)
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
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.cmbLinea.DesignTimeLayout = GridEXLayout4
        Me.cmbLinea.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLinea.Location = New System.Drawing.Point(72, 56)
        Me.cmbLinea.Name = "cmbLinea"
        Me.cmbLinea.Size = New System.Drawing.Size(168, 21)
        Me.cmbLinea.TabIndex = 3
        Me.cmbLinea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbLinea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFamilia
        '
        Me.lblFamilia.BackColor = System.Drawing.Color.Transparent
        Me.lblFamilia.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFamilia.Location = New System.Drawing.Point(16, 88)
        Me.lblFamilia.Name = "lblFamilia"
        Me.lblFamilia.Size = New System.Drawing.Size(64, 23)
        Me.lblFamilia.TabIndex = 34
        Me.lblFamilia.Text = "Familia"
        Me.lblFamilia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLinea
        '
        Me.lblLinea.BackColor = System.Drawing.Color.Transparent
        Me.lblLinea.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLinea.Location = New System.Drawing.Point(16, 56)
        Me.lblLinea.Name = "lblLinea"
        Me.lblLinea.Size = New System.Drawing.Size(48, 23)
        Me.lblLinea.TabIndex = 33
        Me.lblLinea.Text = "Línea"
        Me.lblLinea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmReporteCostosInventarios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(778, 454)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmReporteCostosInventarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Costo Total de Inventarios"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.gruopReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gruopReporte.ResumeLayout(False)
        Me.gruopReporte.PerformLayout()
        CType(Me.gridCostoInventarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGroupBox1.ResumeLayout(False)
        Me.grpGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private source As DataTable
    Dim mgrAlmacen As New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI, True)
    Dim almacen As Almacen
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

#Region "Event Methods"

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        GenerarReporte()
    End Sub

    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        Imprimir()
    End Sub


    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Exportar()
    End Sub

#End Region

#Region "Metodos"

    Private Function GenerarReporte()
        Dim oReporter As New InventarioReportesVarios
        oReporter.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        Dim almacen As String = oAppContext.ApplicationConfiguration.Almacen
        Dim marca As String = CStr(cmbMarca.Value)
        Dim CodLinea As String = CStr(cmbLinea.Value)
        Dim CodFamilia As String = CStr(cmbFamilia.Value)
        source = oReporter.GetReporteCostoInventario(almacen, marca, CodLinea, CodFamilia)
        txtPiezas.Text = CInt(IIf(source.Rows.Count > 0, source.Compute("SUM(Libre)", ""), 0))
        txtTotalCostos.Text = String.Format("{0:c}", source.Compute("SUM(Costo)", ""))
        gridCostoInventarios.DataSource = source
        gridCostoInventarios.Refresh()
        Enable()
    End Function

    Private Function Enable()
        If gridCostoInventarios.RowCount > 0 Then
            btImprimir.Enabled = True
            btnExportar.Enabled = True
        Else
            btImprimir.Enabled = False
            btnExportar.Enabled = False
        End If
    End Function

    Private Sub Imprimir()
        If Not source Is Nothing Then
            Dim reporte As New rptCostosInventarios(almacen.Descripcion, DateTime.Now)
            reporte.DataSource = source
            reporte.PageSettings.Margins.Left = 0.58
            reporte.PageSettings.Margins.Right = 0.03
            reporte.PageSettings.Margins.Top = 0.25
            reporte.PageSettings.Margins.Bottom = 0.25
            reporte.Run()
            Dim oRepView As New ReportViewerForm
            oRepView.Report = reporte
            oRepView.Show()
        Else
            MessageBox.Show("Necesita generar el reporte", "Dportenis PRO Auditoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Exportar()
        If Not source Is Nothing Then
            ExportarPoi()
            'Dim reporte As New rptCostosInventarios(almacen.Descripcion, DateTime.Now)
            'reporte.DataSource = source
            'reporte.PageSettings.Margins.Left = 0.18
            'reporte.PageSettings.Margins.Right = 0.03
            'reporte.PageSettings.Margins.Top = 0.25
            'reporte.PageSettings.Margins.Bottom = 0.25
            'reporte.Run()

            'Dim f As ExportForm = New ExportForm(reporte.Document)
            'f.ShowDialog(Me)
        Else
            MessageBox.Show("Necesita generar el reporte", "Dportenis PRO Auditoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub ExportarPoi()
        Dim SaveDialog = New SaveFileDialog
        SaveDialog.DefaultExt = "*.xls"
        SaveDialog.Filter = "(*.xls)|*.xls"
        If SaveDialog.ShowDialog = DialogResult.OK Then
            If IsOpenFile(SaveDialog.Filename) = False Then
                Dim book As New HSSFWorkbook
                Dim hoja As HSSFSheet = book.CreateSheet("Costos de Inventario")
                Dim row As HSSFRow, celda As HSSFCell, estilo As HSSFCellStyle, font As HSSFFont
                Dim paleta As HSSFPalette = book.GetCustomPalette()

                '****************************************
                'REPORTE COSTOS DE INVENTARIOS
                '****************************************
                row = hoja.CreateRow(0)
                celda = row.CreateCell(0)
                estilo = book.CreateCellStyle()
                estilo.Alignment = HSSFCellStyle.ALIGN_CENTER
                font = book.CreateFont()
                font.Boldweight = HSSFFont.BOLDWEIGHT_BOLD
                font.FontName = "Arial"
                font.FontHeightInPoints = 14
                estilo.SetFont(font)
                celda.CellStyle = estilo
                celda.SetCellValue("Reporte de Costos de Inventarios")
                For index As Integer = 1 To 6
                    row.CreateCell(index).CellStyle = estilo
                Next
                hoja.AddMergedRegion(New CellRangeAddress(0, 0, 0, 6))
                row = hoja.CreateRow(2)
                celda = row.CreateCell(0)
                estilo = book.CreateCellStyle()
                estilo.BorderBottom = HSSFCellStyle.BORDER_THIN
                estilo.BorderLeft = HSSFCellStyle.BORDER_THIN
                estilo.BorderRight = HSSFCellStyle.BORDER_THIN
                estilo.BorderTop = HSSFCellStyle.BORDER_THIN
                font = book.CreateFont()
                font.Boldweight = HSSFFont.BOLDWEIGHT_BOLD
                font.FontName = "Arial"
                font.FontHeightInPoints = 10
                estilo.SetFont(font)
                celda.CellStyle = estilo
                celda.SetCellValue("Sucursal:")
                celda = row.CreateCell(1)
                celda.CellStyle = estilo
                celda.SetCellValue(almacen.Descripcion)
                row = hoja.CreateRow(3)
                celda = row.CreateCell(0)
                celda.CellStyle = estilo
                celda.SetCellValue("Total Piezas:")
                celda = row.CreateCell(1)
                celda.CellStyle = estilo
                If source.Rows.Count > 0 Then
                    celda.SetCellValue(CInt(source.Compute("SUM(Libre)", "")).ToString())
                Else
                    celda.SetCellValue("0")
                End If
                row = hoja.CreateRow(4)
                celda = row.CreateCell(0)
                celda.CellStyle = estilo
                celda.SetCellValue("Total Costo:")
                celda = row.CreateCell(1)
                celda.CellStyle = estilo
                If source.Rows.Count > 0 Then
                    celda.SetCellValue(CStr(source.Compute("SUM(Costo)", "")))
                Else
                    celda.SetCellValue("0")
                End If
                row = hoja.CreateRow(6)
                estilo = book.CreateCellStyle()
                font = book.CreateFont()
                font.Boldweight = HSSFFont.BOLDWEIGHT_BOLD
                font.FontHeightInPoints = 8
                estilo.SetFont(font)
                estilo.Alignment = HSSFCellStyle.ALIGN_CENTER
                estilo.BorderBottom = HSSFCellStyle.BORDER_THIN
                estilo.BorderLeft = HSSFCellStyle.BORDER_THIN
                estilo.BorderRight = HSSFCellStyle.BORDER_THIN
                estilo.BorderTop = HSSFCellStyle.BORDER_THIN
                celda = row.CreateCell(0)
                celda.CellStyle = estilo
                celda.SetCellValue("Código")
                celda = row.CreateCell(1)
                celda.CellStyle = estilo
                celda.SetCellValue("Total Artículos")
                celda = row.CreateCell(2)
                celda.CellStyle = estilo
                celda.SetCellValue("Total Stock")
                Dim intRow As Integer = 7
                For Each fila As DataRow In source.Rows
                    row = hoja.CreateRow(intRow)
                    celda = row.CreateCell(0)
                    celda.SetCellValue(IIf(Not fila!CodArticulo Is DBNull.Value, fila!CodArticulo, ""))
                    celda = row.CreateCell(1)
                    estilo = book.CreateCellStyle()
                    estilo.DataFormat = HSSFDataFormat.GetBuiltinFormat("General")
                    celda.CellStyle = estilo
                    celda.SetCellValue(IIf(Not fila!Libre Is DBNull.Value, fila!Libre, 0))
                    celda = row.CreateCell(2)
                    estilo = book.CreateCellStyle()
                    estilo.DataFormat = HSSFDataFormat.GetBuiltinFormat("($#,##0.00);($#,##0.00)")
                    celda.CellStyle = estilo
                    celda.SetCellValue(IIf(Not fila!Costo Is DBNull.Value, fila!Costo, 0))
                    intRow += 1
                Next
                Dim width As Integer = hoja.GetColumnWidth(1)
                Dim file As New FileStream(SaveDialog.Filename, FileMode.Create)
                book.Write(file)
                file.Close()
                MessageBox.Show("El reporte de costos de inventario fue guardado en " & SaveDialog.Filename, "Dportenis PRO Reporte Costos de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No se puede sobreescribir un archivo en uso", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

#End Region

End Class


