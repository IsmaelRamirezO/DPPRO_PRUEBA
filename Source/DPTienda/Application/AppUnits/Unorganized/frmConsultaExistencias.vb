Imports System.IO
Imports Microsoft.VisualBasic
Imports DportenisPro.DPTienda.ApplicationUnits.ConsultaExistencias
Imports DportenisPro.DPTienda.ApplicationUnits.ConsultaExistencias.ConsultaExistenciasAbstract
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Defectuosos
Imports Janus.Windows.GridEX
Imports System.Collections.Generic

Public Class frmConsultaExistencias
    Inherits System.Windows.Forms.Form

    Public ModOrigen As String = ""
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents Proveedor As Janus.Windows.GridEX.EditControls.EditBox
    Dim oSapMgr As ProcesoSAPManager
    Dim strUrl As String = String.Empty
    Friend WithEvents chkLocal As System.Windows.Forms.CheckBox
    Dim strCiudad As String = String.Empty

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
    End Sub

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents GridEX2 As Janus.Windows.GridEX.GridEX
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Corrida As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiComboBox1 As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblOferta As System.Windows.Forms.Label
    Friend WithEvents Oferta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents Descuento As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblUso As System.Windows.Forms.Label
    Friend WithEvents Uso As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblFamilia As System.Windows.Forms.Label
    Friend WithEvents Familia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLinea As System.Windows.Forms.Label
    Friend WithEvents Linea As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblBusquedaPor As System.Windows.Forms.Label
    Friend WithEvents ArticuloID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTablaDe As System.Windows.Forms.Label
    Friend WithEvents NicePanel2 As PureComponents.NicePanel.NicePanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FotoArticulo As System.Windows.Forms.PictureBox
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents Descripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Precio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Color As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblFotoNoDisponibleA3 As System.Windows.Forms.Label
    Friend WithEvents lblNoExistenteA3 As System.Windows.Forms.Label
    Friend WithEvents lblFotoNoDisponibleA2 As System.Windows.Forms.Label
    Friend WithEvents lblNoExistenteA2 As System.Windows.Forms.Label
    Friend WithEvents lblFotoNoDisponibleA1 As System.Windows.Forms.Label
    Friend WithEvents lblNoExistenteA1 As System.Windows.Forms.Label
    Friend WithEvents ebAlter1 As System.Windows.Forms.TextBox
    Friend WithEvents DescripcionAlter1 As System.Windows.Forms.TextBox
    Friend WithEvents ColorAlter1 As System.Windows.Forms.TextBox
    Friend WithEvents ImAlter1 As System.Windows.Forms.PictureBox
    Friend WithEvents PrecioAlter1 As System.Windows.Forms.TextBox
    Friend WithEvents ebAlter2 As System.Windows.Forms.TextBox
    Friend WithEvents ImAlter2 As System.Windows.Forms.PictureBox
    Friend WithEvents DescripcionAlter2 As System.Windows.Forms.TextBox
    Friend WithEvents PrecioAlter2 As System.Windows.Forms.TextBox
    Friend WithEvents ColorAlter2 As System.Windows.Forms.TextBox
    Friend WithEvents ImAlter3 As System.Windows.Forms.PictureBox
    Friend WithEvents DescripcionAlter3 As System.Windows.Forms.TextBox
    Friend WithEvents ebAlter3 As System.Windows.Forms.TextBox
    Friend WithEvents ColorAlter3 As System.Windows.Forms.TextBox
    Friend WithEvents PrecioAlter3 As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents For1 As System.Windows.Forms.PictureBox
    Friend WithEvents For2 As System.Windows.Forms.PictureBox
    Friend WithEvents For3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnAccionBusqueda As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaExistencias))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage()
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle()
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle()
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.GridEX2 = New Janus.Windows.GridEX.GridEX()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.chkLocal = New System.Windows.Forms.CheckBox()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.Proveedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnAccionBusqueda = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Corrida = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiComboBox1 = New Janus.Windows.EditControls.UIComboBox()
        Me.lblOferta = New System.Windows.Forms.Label()
        Me.Oferta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.Descuento = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblUso = New System.Windows.Forms.Label()
        Me.Uso = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblFamilia = New System.Windows.Forms.Label()
        Me.Familia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLinea = New System.Windows.Forms.Label()
        Me.Linea = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblBusquedaPor = New System.Windows.Forms.Label()
        Me.ArticuloID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblTablaDe = New System.Windows.Forms.Label()
        Me.NicePanel2 = New PureComponents.NicePanel.NicePanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FotoArticulo = New System.Windows.Forms.PictureBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.Descripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Precio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Color = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.DescripcionAlter1 = New System.Windows.Forms.TextBox()
        Me.ebAlter1 = New System.Windows.Forms.TextBox()
        Me.ColorAlter1 = New System.Windows.Forms.TextBox()
        Me.PrecioAlter1 = New System.Windows.Forms.TextBox()
        Me.ebAlter2 = New System.Windows.Forms.TextBox()
        Me.DescripcionAlter2 = New System.Windows.Forms.TextBox()
        Me.PrecioAlter2 = New System.Windows.Forms.TextBox()
        Me.ColorAlter2 = New System.Windows.Forms.TextBox()
        Me.DescripcionAlter3 = New System.Windows.Forms.TextBox()
        Me.ebAlter3 = New System.Windows.Forms.TextBox()
        Me.ColorAlter3 = New System.Windows.Forms.TextBox()
        Me.PrecioAlter3 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.For3 = New System.Windows.Forms.PictureBox()
        Me.For2 = New System.Windows.Forms.PictureBox()
        Me.For1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFotoNoDisponibleA3 = New System.Windows.Forms.Label()
        Me.lblNoExistenteA3 = New System.Windows.Forms.Label()
        Me.lblFotoNoDisponibleA2 = New System.Windows.Forms.Label()
        Me.lblNoExistenteA2 = New System.Windows.Forms.Label()
        Me.lblFotoNoDisponibleA1 = New System.Windows.Forms.Label()
        Me.lblNoExistenteA1 = New System.Windows.Forms.Label()
        Me.ImAlter1 = New System.Windows.Forms.PictureBox()
        Me.ImAlter2 = New System.Windows.Forms.PictureBox()
        Me.ImAlter3 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.GridEX2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NicePanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.FotoArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage2.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.For3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.For2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.For1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImAlter1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImAlter2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImAlter3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiTab1
        '
        Me.UiTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiTab1.FirstTabOffset = 3
        Me.UiTab1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiTab1.Location = New System.Drawing.Point(0, 0)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(784, 670)
        Me.UiTab1.TabIndex = 100
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1, Me.UiTabPage2})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.UiGroupBox1)
        Me.UiTabPage1.Controls.Add(Me.ExplorerBar1)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 24)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(782, 645)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "Consulta de Articulos"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox3)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 392)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(782, 253)
        Me.UiGroupBox1.TabIndex = 2
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox3.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox3.Controls.Add(Me.GridEX2)
        Me.UiGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox3.Location = New System.Drawing.Point(3, 8)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(776, 242)
        Me.UiGroupBox3.TabIndex = 69
        '
        'GridEX2
        '
        Me.GridEX2.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEX2.BorderStyle = Janus.Windows.GridEX.BorderStyle.None
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GridEX2.DesignTimeLayout = GridEXLayout1
        Me.GridEX2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridEX2.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridEX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GridEX2.GroupByBoxVisible = False
        Me.GridEX2.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always
        Me.GridEX2.Location = New System.Drawing.Point(3, 8)
        Me.GridEX2.Name = "GridEX2"
        Me.GridEX2.Size = New System.Drawing.Size(770, 231)
        Me.GridEX2.TabIndex = 3
        Me.GridEX2.TabStop = False
        Me.GridEX2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.chkLocal)
        Me.ExplorerBar1.Controls.Add(Me.lblProveedor)
        Me.ExplorerBar1.Controls.Add(Me.Proveedor)
        Me.ExplorerBar1.Controls.Add(Me.btnAccionBusqueda)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.Corrida)
        Me.ExplorerBar1.Controls.Add(Me.UiComboBox1)
        Me.ExplorerBar1.Controls.Add(Me.lblOferta)
        Me.ExplorerBar1.Controls.Add(Me.Oferta)
        Me.ExplorerBar1.Controls.Add(Me.lblDescuento)
        Me.ExplorerBar1.Controls.Add(Me.Descuento)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.lblUso)
        Me.ExplorerBar1.Controls.Add(Me.Uso)
        Me.ExplorerBar1.Controls.Add(Me.lblFamilia)
        Me.ExplorerBar1.Controls.Add(Me.Familia)
        Me.ExplorerBar1.Controls.Add(Me.lblLinea)
        Me.ExplorerBar1.Controls.Add(Me.Linea)
        Me.ExplorerBar1.Controls.Add(Me.lblBusquedaPor)
        Me.ExplorerBar1.Controls.Add(Me.ArticuloID)
        Me.ExplorerBar1.Controls.Add(Me.PictureBox3)
        Me.ExplorerBar1.Controls.Add(Me.lblTablaDe)
        Me.ExplorerBar1.Controls.Add(Me.NicePanel2)
        Me.ExplorerBar1.Controls.Add(Me.lblPrecio)
        Me.ExplorerBar1.Controls.Add(Me.lblCodigo)
        Me.ExplorerBar1.Controls.Add(Me.lblDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.lblColor)
        Me.ExplorerBar1.Controls.Add(Me.Descripcion)
        Me.ExplorerBar1.Controls.Add(Me.Precio)
        Me.ExplorerBar1.Controls.Add(Me.Color)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(782, 392)
        Me.ExplorerBar1.TabIndex = 1001
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'chkLocal
        '
        Me.chkLocal.BackColor = System.Drawing.Color.Transparent
        Me.chkLocal.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLocal.Location = New System.Drawing.Point(43, 97)
        Me.chkLocal.Name = "chkLocal"
        Me.chkLocal.Size = New System.Drawing.Size(137, 24)
        Me.chkLocal.TabIndex = 1013
        Me.chkLocal.Text = "BD Local"
        Me.chkLocal.UseVisualStyleBackColor = False
        '
        'lblProveedor
        '
        Me.lblProveedor.BackColor = System.Drawing.Color.Transparent
        Me.lblProveedor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProveedor.Location = New System.Drawing.Point(40, 160)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(106, 24)
        Me.lblProveedor.TabIndex = 1011
        Me.lblProveedor.Text = "Cod.Proveedor:"
        '
        'Proveedor
        '
        Me.Proveedor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Proveedor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Proveedor.BackColor = System.Drawing.Color.Ivory
        Me.Proveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Proveedor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Proveedor.Location = New System.Drawing.Point(150, 155)
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        Me.Proveedor.Size = New System.Drawing.Size(104, 22)
        Me.Proveedor.TabIndex = 1010
        Me.Proveedor.TabStop = False
        Me.Proveedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Proveedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnAccionBusqueda
        '
        Me.btnAccionBusqueda.Location = New System.Drawing.Point(304, 67)
        Me.btnAccionBusqueda.Name = "btnAccionBusqueda"
        Me.btnAccionBusqueda.Size = New System.Drawing.Size(96, 23)
        Me.btnAccionBusqueda.TabIndex = 2
        Me.btnAccionBusqueda.Text = "Consultar"
        Me.btnAccionBusqueda.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 326)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 24)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Corrida:"
        '
        'Corrida
        '
        Me.Corrida.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Corrida.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Corrida.BackColor = System.Drawing.Color.Ivory
        Me.Corrida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Corrida.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Corrida.Location = New System.Drawing.Point(150, 324)
        Me.Corrida.Name = "Corrida"
        Me.Corrida.ReadOnly = True
        Me.Corrida.Size = New System.Drawing.Size(232, 22)
        Me.Corrida.TabIndex = 10
        Me.Corrida.TabStop = False
        Me.Corrida.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Corrida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiComboBox1
        '
        Me.UiComboBox1.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "Local"
        UiComboBoxItem1.Value = "Local"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "Exterior"
        UiComboBoxItem2.Value = "Exterior"
        Me.UiComboBox1.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2})
        Me.UiComboBox1.Location = New System.Drawing.Point(144, 67)
        Me.UiComboBox1.Name = "UiComboBox1"
        Me.UiComboBox1.SelectedIndex = 0
        Me.UiComboBox1.Size = New System.Drawing.Size(152, 22)
        Me.UiComboBox1.TabIndex = 1
        Me.UiComboBox1.Text = "Local"
        Me.UiComboBox1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblOferta
        '
        Me.lblOferta.BackColor = System.Drawing.Color.Transparent
        Me.lblOferta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOferta.Location = New System.Drawing.Point(40, 230)
        Me.lblOferta.Name = "lblOferta"
        Me.lblOferta.Size = New System.Drawing.Size(80, 24)
        Me.lblOferta.TabIndex = 12
        Me.lblOferta.Text = "Oferta:"
        '
        'Oferta
        '
        Me.Oferta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Oferta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Oferta.BackColor = System.Drawing.Color.Ivory
        Me.Oferta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Oferta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Oferta.Location = New System.Drawing.Point(150, 228)
        Me.Oferta.Name = "Oferta"
        Me.Oferta.ReadOnly = True
        Me.Oferta.Size = New System.Drawing.Size(144, 22)
        Me.Oferta.TabIndex = 6
        Me.Oferta.TabStop = False
        Me.Oferta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Oferta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblDescuento
        '
        Me.lblDescuento.BackColor = System.Drawing.Color.Transparent
        Me.lblDescuento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.Location = New System.Drawing.Point(40, 254)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(80, 24)
        Me.lblDescuento.TabIndex = 14
        Me.lblDescuento.Text = "Descuento:"
        '
        'Descuento
        '
        Me.Descuento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Descuento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Descuento.BackColor = System.Drawing.Color.Ivory
        Me.Descuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Descuento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descuento.Location = New System.Drawing.Point(150, 252)
        Me.Descuento.Name = "Descuento"
        Me.Descuento.ReadOnly = True
        Me.Descuento.Size = New System.Drawing.Size(144, 22)
        Me.Descuento.TabIndex = 7
        Me.Descuento.TabStop = False
        Me.Descuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Descuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(40, 109)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(374, 21)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "_________________________________________________"
        '
        'lblUso
        '
        Me.lblUso.BackColor = System.Drawing.Color.Transparent
        Me.lblUso.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUso.Location = New System.Drawing.Point(40, 323)
        Me.lblUso.Name = "lblUso"
        Me.lblUso.Size = New System.Drawing.Size(80, 24)
        Me.lblUso.TabIndex = 20
        Me.lblUso.Text = "Uso:"
        Me.lblUso.Visible = False
        '
        'Uso
        '
        Me.Uso.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Uso.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Uso.BackColor = System.Drawing.Color.Ivory
        Me.Uso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Uso.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Uso.Location = New System.Drawing.Point(150, 324)
        Me.Uso.Name = "Uso"
        Me.Uso.ReadOnly = True
        Me.Uso.Size = New System.Drawing.Size(232, 22)
        Me.Uso.TabIndex = 11
        Me.Uso.TabStop = False
        Me.Uso.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Uso.Visible = False
        Me.Uso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFamilia
        '
        Me.lblFamilia.BackColor = System.Drawing.Color.Transparent
        Me.lblFamilia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFamilia.Location = New System.Drawing.Point(40, 302)
        Me.lblFamilia.Name = "lblFamilia"
        Me.lblFamilia.Size = New System.Drawing.Size(80, 24)
        Me.lblFamilia.TabIndex = 18
        Me.lblFamilia.Text = "Familia:"
        '
        'Familia
        '
        Me.Familia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Familia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Familia.BackColor = System.Drawing.Color.Ivory
        Me.Familia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Familia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Familia.Location = New System.Drawing.Point(150, 300)
        Me.Familia.Name = "Familia"
        Me.Familia.ReadOnly = True
        Me.Familia.Size = New System.Drawing.Size(232, 22)
        Me.Familia.TabIndex = 9
        Me.Familia.TabStop = False
        Me.Familia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Familia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLinea
        '
        Me.lblLinea.BackColor = System.Drawing.Color.Transparent
        Me.lblLinea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLinea.Location = New System.Drawing.Point(40, 278)
        Me.lblLinea.Name = "lblLinea"
        Me.lblLinea.Size = New System.Drawing.Size(80, 24)
        Me.lblLinea.TabIndex = 16
        Me.lblLinea.Text = "Linea:"
        '
        'Linea
        '
        Me.Linea.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Linea.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Linea.BackColor = System.Drawing.Color.Ivory
        Me.Linea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Linea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Linea.Location = New System.Drawing.Point(150, 276)
        Me.Linea.Name = "Linea"
        Me.Linea.ReadOnly = True
        Me.Linea.Size = New System.Drawing.Size(232, 22)
        Me.Linea.TabIndex = 8
        Me.Linea.TabStop = False
        Me.Linea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Linea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblBusquedaPor
        '
        Me.lblBusquedaPor.BackColor = System.Drawing.Color.Transparent
        Me.lblBusquedaPor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusquedaPor.Location = New System.Drawing.Point(40, 75)
        Me.lblBusquedaPor.Name = "lblBusquedaPor"
        Me.lblBusquedaPor.Size = New System.Drawing.Size(96, 16)
        Me.lblBusquedaPor.TabIndex = 1003
        Me.lblBusquedaPor.Text = "Busqueda por:"
        '
        'ArticuloID
        '
        Me.ArticuloID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ArticuloID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ArticuloID.ButtonImage = CType(resources.GetObject("ArticuloID.ButtonImage"), System.Drawing.Image)
        Me.ArticuloID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ArticuloID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ArticuloID.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ArticuloID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArticuloID.ForeColor = System.Drawing.Color.Black
        Me.ArticuloID.Location = New System.Drawing.Point(144, 43)
        Me.ArticuloID.MaxLength = 20
        Me.ArticuloID.Name = "ArticuloID"
        Me.ArticuloID.Size = New System.Drawing.Size(256, 22)
        Me.ArticuloID.TabIndex = 0
        Me.ArticuloID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ArticuloID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(56, 360)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 62
        Me.PictureBox3.TabStop = False
        '
        'lblTablaDe
        '
        Me.lblTablaDe.BackColor = System.Drawing.Color.Transparent
        Me.lblTablaDe.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTablaDe.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTablaDe.Location = New System.Drawing.Point(80, 368)
        Me.lblTablaDe.Name = "lblTablaDe"
        Me.lblTablaDe.Size = New System.Drawing.Size(144, 23)
        Me.lblTablaDe.TabIndex = 1004
        Me.lblTablaDe.Text = "Tabla de Existencias"
        '
        'NicePanel2
        '
        Me.NicePanel2.BackColor = System.Drawing.Color.Transparent
        Me.NicePanel2.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 50
        Me.NicePanel2.ContainerImage = ContainerImage1
        Me.NicePanel2.ContextMenuButton = False
        Me.NicePanel2.Controls.Add(Me.Panel1)
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.NicePanel2.FooterImage = HeaderImage1
        Me.NicePanel2.FooterText = "PureComponents NicePanel for .NET WinForms V1.0."
        Me.NicePanel2.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Camera
        HeaderImage2.Image = Nothing
        Me.NicePanel2.HeaderImage = HeaderImage2
        Me.NicePanel2.HeaderText = "Fotografia del Articulo"
        Me.NicePanel2.IsExpanded = True
        Me.NicePanel2.Location = New System.Drawing.Point(440, 41)
        Me.NicePanel2.Name = "NicePanel2"
        Me.NicePanel2.OriginalFooterVisible = True
        Me.NicePanel2.OriginalHeight = 240
        Me.NicePanel2.Size = New System.Drawing.Size(328, 312)
        ContainerStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Dot
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(252, Byte), Integer))
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.Flat
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        ContainerStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle1.ForeColor = System.Drawing.Color.Black
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Squared
        PanelStyle1.ContainerStyle = ContainerStyle1
        PanelHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(127, Byte), Integer))
        PanelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(215, Byte), Integer))
        PanelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle1.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PanelHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(237, Byte), Integer))
        PanelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small
        PanelStyle1.FooterStyle = PanelHeaderStyle1
        PanelHeaderStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(215, Byte), Integer))
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle2.FadeColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(127, Byte), Integer))
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(251, Byte), Integer))
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.NicePanel2.Style = PanelStyle1
        Me.NicePanel2.TabIndex = 1005
        Me.NicePanel2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.FotoArticulo)
        Me.Panel1.Location = New System.Drawing.Point(1, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(326, 270)
        Me.Panel1.TabIndex = 1006
        Me.Panel1.Tag = "NicePanelAutoScroll"
        Me.Panel1.Text = "NicePanelAutoScroll"
        '
        'FotoArticulo
        '
        Me.FotoArticulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FotoArticulo.Location = New System.Drawing.Point(0, 0)
        Me.FotoArticulo.Name = "FotoArticulo"
        Me.FotoArticulo.Size = New System.Drawing.Size(326, 270)
        Me.FotoArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.FotoArticulo.TabIndex = 1007
        Me.FotoArticulo.TabStop = False
        '
        'lblPrecio
        '
        Me.lblPrecio.BackColor = System.Drawing.Color.Transparent
        Me.lblPrecio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(40, 206)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(48, 24)
        Me.lblPrecio.TabIndex = 10
        Me.lblPrecio.Text = "Precio:"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(40, 51)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(56, 24)
        Me.lblCodigo.TabIndex = 1008
        Me.lblCodigo.Text = "Codigo:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(40, 134)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(96, 24)
        Me.lblDescripcion.TabIndex = 6
        Me.lblDescripcion.Text = "Descripcion:"
        '
        'lblColor
        '
        Me.lblColor.BackColor = System.Drawing.Color.Transparent
        Me.lblColor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.Location = New System.Drawing.Point(40, 182)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(48, 24)
        Me.lblColor.TabIndex = 8
        Me.lblColor.Text = "Color:"
        '
        'Descripcion
        '
        Me.Descripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Descripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Descripcion.BackColor = System.Drawing.Color.Ivory
        Me.Descripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Descripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion.Location = New System.Drawing.Point(150, 131)
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Size = New System.Drawing.Size(256, 22)
        Me.Descripcion.TabIndex = 3
        Me.Descripcion.TabStop = False
        Me.Descripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Descripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Precio
        '
        Me.Precio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Precio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Precio.BackColor = System.Drawing.Color.Ivory
        Me.Precio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Precio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Precio.Location = New System.Drawing.Point(150, 204)
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        Me.Precio.Size = New System.Drawing.Size(144, 22)
        Me.Precio.TabIndex = 5
        Me.Precio.TabStop = False
        Me.Precio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Precio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Color
        '
        Me.Color.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Color.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Color.BackColor = System.Drawing.Color.Ivory
        Me.Color.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Color.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color.Location = New System.Drawing.Point(150, 180)
        Me.Color.Name = "Color"
        Me.Color.ReadOnly = True
        Me.Color.Size = New System.Drawing.Size(104, 22)
        Me.Color.TabIndex = 4
        Me.Color.TabStop = False
        Me.Color.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Color.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiTabPage2
        '
        Me.UiTabPage2.Controls.Add(Me.ExplorerBar2)
        Me.UiTabPage2.Location = New System.Drawing.Point(1, 25)
        Me.UiTabPage2.Name = "UiTabPage2"
        Me.UiTabPage2.Size = New System.Drawing.Size(782, 644)
        Me.UiTabPage2.TabStop = True
        Me.UiTabPage2.TabVisible = False
        Me.UiTabPage2.Text = "Articulos Alternativos"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.DescripcionAlter1)
        Me.ExplorerBar2.Controls.Add(Me.ebAlter1)
        Me.ExplorerBar2.Controls.Add(Me.ColorAlter1)
        Me.ExplorerBar2.Controls.Add(Me.PrecioAlter1)
        Me.ExplorerBar2.Controls.Add(Me.ebAlter2)
        Me.ExplorerBar2.Controls.Add(Me.DescripcionAlter2)
        Me.ExplorerBar2.Controls.Add(Me.PrecioAlter2)
        Me.ExplorerBar2.Controls.Add(Me.ColorAlter2)
        Me.ExplorerBar2.Controls.Add(Me.DescripcionAlter3)
        Me.ExplorerBar2.Controls.Add(Me.ebAlter3)
        Me.ExplorerBar2.Controls.Add(Me.ColorAlter3)
        Me.ExplorerBar2.Controls.Add(Me.PrecioAlter3)
        Me.ExplorerBar2.Controls.Add(Me.Label8)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Controls.Add(Me.Label6)
        Me.ExplorerBar2.Controls.Add(Me.Label5)
        Me.ExplorerBar2.Controls.Add(Me.For3)
        Me.ExplorerBar2.Controls.Add(Me.For2)
        Me.ExplorerBar2.Controls.Add(Me.For1)
        Me.ExplorerBar2.Controls.Add(Me.PictureBox4)
        Me.ExplorerBar2.Controls.Add(Me.Label4)
        Me.ExplorerBar2.Controls.Add(Me.PictureBox2)
        Me.ExplorerBar2.Controls.Add(Me.Label3)
        Me.ExplorerBar2.Controls.Add(Me.PictureBox1)
        Me.ExplorerBar2.Controls.Add(Me.Label2)
        Me.ExplorerBar2.Controls.Add(Me.lblFotoNoDisponibleA3)
        Me.ExplorerBar2.Controls.Add(Me.lblNoExistenteA3)
        Me.ExplorerBar2.Controls.Add(Me.lblFotoNoDisponibleA2)
        Me.ExplorerBar2.Controls.Add(Me.lblNoExistenteA2)
        Me.ExplorerBar2.Controls.Add(Me.lblFotoNoDisponibleA1)
        Me.ExplorerBar2.Controls.Add(Me.lblNoExistenteA1)
        Me.ExplorerBar2.Controls.Add(Me.ImAlter1)
        Me.ExplorerBar2.Controls.Add(Me.ImAlter2)
        Me.ExplorerBar2.Controls.Add(Me.ImAlter3)
        Me.ExplorerBar2.Controls.Add(Me.Label10)
        Me.ExplorerBar2.Controls.Add(Me.Label9)
        Me.ExplorerBar2.Controls.Add(Me.Label11)
        Me.ExplorerBar2.Controls.Add(Me.Label13)
        Me.ExplorerBar2.Controls.Add(Me.Label14)
        Me.ExplorerBar2.Controls.Add(Me.Label15)
        Me.ExplorerBar2.Controls.Add(Me.Label16)
        Me.ExplorerBar2.Controls.Add(Me.Label17)
        Me.ExplorerBar2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Artículos Alternativos"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(782, 644)
        Me.ExplorerBar2.TabIndex = 3
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'DescripcionAlter1
        '
        Me.DescripcionAlter1.BackColor = System.Drawing.Color.Ivory
        Me.DescripcionAlter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DescripcionAlter1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescripcionAlter1.Location = New System.Drawing.Point(416, 136)
        Me.DescripcionAlter1.Name = "DescripcionAlter1"
        Me.DescripcionAlter1.ReadOnly = True
        Me.DescripcionAlter1.Size = New System.Drawing.Size(304, 22)
        Me.DescripcionAlter1.TabIndex = 1
        Me.DescripcionAlter1.TabStop = False
        '
        'ebAlter1
        '
        Me.ebAlter1.BackColor = System.Drawing.Color.Ivory
        Me.ebAlter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebAlter1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAlter1.Location = New System.Drawing.Point(416, 112)
        Me.ebAlter1.Name = "ebAlter1"
        Me.ebAlter1.ReadOnly = True
        Me.ebAlter1.Size = New System.Drawing.Size(184, 22)
        Me.ebAlter1.TabIndex = 1009
        Me.ebAlter1.TabStop = False
        '
        'ColorAlter1
        '
        Me.ColorAlter1.BackColor = System.Drawing.Color.Ivory
        Me.ColorAlter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ColorAlter1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorAlter1.Location = New System.Drawing.Point(416, 160)
        Me.ColorAlter1.Name = "ColorAlter1"
        Me.ColorAlter1.ReadOnly = True
        Me.ColorAlter1.Size = New System.Drawing.Size(152, 22)
        Me.ColorAlter1.TabIndex = 3
        Me.ColorAlter1.TabStop = False
        '
        'PrecioAlter1
        '
        Me.PrecioAlter1.BackColor = System.Drawing.Color.Ivory
        Me.PrecioAlter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrecioAlter1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioAlter1.Location = New System.Drawing.Point(416, 184)
        Me.PrecioAlter1.Name = "PrecioAlter1"
        Me.PrecioAlter1.ReadOnly = True
        Me.PrecioAlter1.Size = New System.Drawing.Size(96, 22)
        Me.PrecioAlter1.TabIndex = 2
        Me.PrecioAlter1.TabStop = False
        '
        'ebAlter2
        '
        Me.ebAlter2.BackColor = System.Drawing.Color.Ivory
        Me.ebAlter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebAlter2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAlter2.Location = New System.Drawing.Point(416, 304)
        Me.ebAlter2.Name = "ebAlter2"
        Me.ebAlter2.ReadOnly = True
        Me.ebAlter2.Size = New System.Drawing.Size(184, 22)
        Me.ebAlter2.TabIndex = 4
        Me.ebAlter2.TabStop = False
        '
        'DescripcionAlter2
        '
        Me.DescripcionAlter2.BackColor = System.Drawing.Color.Ivory
        Me.DescripcionAlter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DescripcionAlter2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescripcionAlter2.Location = New System.Drawing.Point(416, 328)
        Me.DescripcionAlter2.Name = "DescripcionAlter2"
        Me.DescripcionAlter2.ReadOnly = True
        Me.DescripcionAlter2.Size = New System.Drawing.Size(304, 22)
        Me.DescripcionAlter2.TabIndex = 5
        Me.DescripcionAlter2.TabStop = False
        '
        'PrecioAlter2
        '
        Me.PrecioAlter2.BackColor = System.Drawing.Color.Ivory
        Me.PrecioAlter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrecioAlter2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioAlter2.Location = New System.Drawing.Point(416, 376)
        Me.PrecioAlter2.Name = "PrecioAlter2"
        Me.PrecioAlter2.ReadOnly = True
        Me.PrecioAlter2.Size = New System.Drawing.Size(96, 22)
        Me.PrecioAlter2.TabIndex = 6
        Me.PrecioAlter2.TabStop = False
        '
        'ColorAlter2
        '
        Me.ColorAlter2.BackColor = System.Drawing.Color.Ivory
        Me.ColorAlter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ColorAlter2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorAlter2.Location = New System.Drawing.Point(416, 352)
        Me.ColorAlter2.Name = "ColorAlter2"
        Me.ColorAlter2.ReadOnly = True
        Me.ColorAlter2.Size = New System.Drawing.Size(152, 22)
        Me.ColorAlter2.TabIndex = 7
        Me.ColorAlter2.TabStop = False
        '
        'DescripcionAlter3
        '
        Me.DescripcionAlter3.BackColor = System.Drawing.Color.Ivory
        Me.DescripcionAlter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DescripcionAlter3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescripcionAlter3.Location = New System.Drawing.Point(416, 520)
        Me.DescripcionAlter3.Name = "DescripcionAlter3"
        Me.DescripcionAlter3.ReadOnly = True
        Me.DescripcionAlter3.Size = New System.Drawing.Size(304, 22)
        Me.DescripcionAlter3.TabIndex = 9
        Me.DescripcionAlter3.TabStop = False
        '
        'ebAlter3
        '
        Me.ebAlter3.BackColor = System.Drawing.Color.Ivory
        Me.ebAlter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebAlter3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAlter3.Location = New System.Drawing.Point(416, 496)
        Me.ebAlter3.Name = "ebAlter3"
        Me.ebAlter3.ReadOnly = True
        Me.ebAlter3.Size = New System.Drawing.Size(184, 22)
        Me.ebAlter3.TabIndex = 8
        Me.ebAlter3.TabStop = False
        '
        'ColorAlter3
        '
        Me.ColorAlter3.BackColor = System.Drawing.Color.Ivory
        Me.ColorAlter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ColorAlter3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorAlter3.Location = New System.Drawing.Point(416, 544)
        Me.ColorAlter3.Name = "ColorAlter3"
        Me.ColorAlter3.ReadOnly = True
        Me.ColorAlter3.Size = New System.Drawing.Size(152, 22)
        Me.ColorAlter3.TabIndex = 11
        Me.ColorAlter3.TabStop = False
        '
        'PrecioAlter3
        '
        Me.PrecioAlter3.BackColor = System.Drawing.Color.Ivory
        Me.PrecioAlter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrecioAlter3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioAlter3.Location = New System.Drawing.Point(416, 568)
        Me.PrecioAlter3.Name = "PrecioAlter3"
        Me.PrecioAlter3.ReadOnly = True
        Me.PrecioAlter3.Size = New System.Drawing.Size(96, 22)
        Me.PrecioAlter3.TabIndex = 10
        Me.PrecioAlter3.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(336, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "Descripcion:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(336, 504)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 23)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "Codigo:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(336, 311)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 23)
        Me.Label6.TabIndex = 115
        Me.Label6.Text = "Codigo:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(336, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 23)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "Codigo:"
        '
        'For3
        '
        Me.For3.BackColor = System.Drawing.Color.White
        Me.For3.Image = CType(resources.GetObject("For3.Image"), System.Drawing.Image)
        Me.For3.Location = New System.Drawing.Point(152, 504)
        Me.For3.Name = "For3"
        Me.For3.Size = New System.Drawing.Size(48, 50)
        Me.For3.TabIndex = 113
        Me.For3.TabStop = False
        '
        'For2
        '
        Me.For2.BackColor = System.Drawing.Color.White
        Me.For2.Image = CType(resources.GetObject("For2.Image"), System.Drawing.Image)
        Me.For2.Location = New System.Drawing.Point(152, 312)
        Me.For2.Name = "For2"
        Me.For2.Size = New System.Drawing.Size(48, 50)
        Me.For2.TabIndex = 112
        Me.For2.TabStop = False
        '
        'For1
        '
        Me.For1.BackColor = System.Drawing.Color.White
        Me.For1.Image = CType(resources.GetObject("For1.Image"), System.Drawing.Image)
        Me.For1.Location = New System.Drawing.Point(152, 120)
        Me.For1.Name = "For1"
        Me.For1.Size = New System.Drawing.Size(48, 50)
        Me.For1.TabIndex = 111
        Me.For1.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(312, 464)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 110
        Me.PictureBox4.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(336, 472)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 23)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Datos Articulo #3"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(312, 272)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 108
        Me.PictureBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(336, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 23)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Datos Articulo #2"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(312, 80)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 106
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(336, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 23)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Datos Articulo #1"
        '
        'lblFotoNoDisponibleA3
        '
        Me.lblFotoNoDisponibleA3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFotoNoDisponibleA3.Location = New System.Drawing.Point(120, 584)
        Me.lblFotoNoDisponibleA3.Name = "lblFotoNoDisponibleA3"
        Me.lblFotoNoDisponibleA3.Size = New System.Drawing.Size(128, 16)
        Me.lblFotoNoDisponibleA3.TabIndex = 104
        Me.lblFotoNoDisponibleA3.Text = "Foto no disponible"
        '
        'lblNoExistenteA3
        '
        Me.lblNoExistenteA3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoExistenteA3.Location = New System.Drawing.Point(136, 568)
        Me.lblNoExistenteA3.Name = "lblNoExistenteA3"
        Me.lblNoExistenteA3.Size = New System.Drawing.Size(96, 16)
        Me.lblNoExistenteA3.TabIndex = 103
        Me.lblNoExistenteA3.Text = "No existente"
        Me.lblNoExistenteA3.Visible = False
        '
        'lblFotoNoDisponibleA2
        '
        Me.lblFotoNoDisponibleA2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFotoNoDisponibleA2.Location = New System.Drawing.Point(120, 400)
        Me.lblFotoNoDisponibleA2.Name = "lblFotoNoDisponibleA2"
        Me.lblFotoNoDisponibleA2.Size = New System.Drawing.Size(120, 16)
        Me.lblFotoNoDisponibleA2.TabIndex = 102
        Me.lblFotoNoDisponibleA2.Text = "Foto no disponible"
        '
        'lblNoExistenteA2
        '
        Me.lblNoExistenteA2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoExistenteA2.Location = New System.Drawing.Point(136, 384)
        Me.lblNoExistenteA2.Name = "lblNoExistenteA2"
        Me.lblNoExistenteA2.Size = New System.Drawing.Size(96, 16)
        Me.lblNoExistenteA2.TabIndex = 101
        Me.lblNoExistenteA2.Text = "No existente"
        Me.lblNoExistenteA2.Visible = False
        '
        'lblFotoNoDisponibleA1
        '
        Me.lblFotoNoDisponibleA1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFotoNoDisponibleA1.Location = New System.Drawing.Point(120, 208)
        Me.lblFotoNoDisponibleA1.Name = "lblFotoNoDisponibleA1"
        Me.lblFotoNoDisponibleA1.Size = New System.Drawing.Size(120, 23)
        Me.lblFotoNoDisponibleA1.TabIndex = 100
        Me.lblFotoNoDisponibleA1.Text = "Foto no disponible"
        '
        'lblNoExistenteA1
        '
        Me.lblNoExistenteA1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoExistenteA1.Location = New System.Drawing.Point(136, 192)
        Me.lblNoExistenteA1.Name = "lblNoExistenteA1"
        Me.lblNoExistenteA1.Size = New System.Drawing.Size(96, 23)
        Me.lblNoExistenteA1.TabIndex = 99
        Me.lblNoExistenteA1.Text = "No existente"
        Me.lblNoExistenteA1.Visible = False
        '
        'ImAlter1
        '
        Me.ImAlter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImAlter1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ImAlter1.Location = New System.Drawing.Point(56, 64)
        Me.ImAlter1.Name = "ImAlter1"
        Me.ImAlter1.Size = New System.Drawing.Size(232, 184)
        Me.ImAlter1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImAlter1.TabIndex = 96
        Me.ImAlter1.TabStop = False
        '
        'ImAlter2
        '
        Me.ImAlter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImAlter2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ImAlter2.Location = New System.Drawing.Point(56, 256)
        Me.ImAlter2.Name = "ImAlter2"
        Me.ImAlter2.Size = New System.Drawing.Size(232, 184)
        Me.ImAlter2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImAlter2.TabIndex = 95
        Me.ImAlter2.TabStop = False
        '
        'ImAlter3
        '
        Me.ImAlter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImAlter3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ImAlter3.Location = New System.Drawing.Point(56, 448)
        Me.ImAlter3.Name = "ImAlter3"
        Me.ImAlter3.Size = New System.Drawing.Size(232, 184)
        Me.ImAlter3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImAlter3.TabIndex = 98
        Me.ImAlter3.TabStop = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(336, 528)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 23)
        Me.Label10.TabIndex = 119
        Me.Label10.Text = "Descripcion:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(336, 336)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 23)
        Me.Label9.TabIndex = 118
        Me.Label9.Text = "Descripcion:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(336, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 23)
        Me.Label11.TabIndex = 120
        Me.Label11.Text = "Color:"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(336, 360)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 23)
        Me.Label13.TabIndex = 121
        Me.Label13.Text = "Color:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(336, 552)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 23)
        Me.Label14.TabIndex = 122
        Me.Label14.Text = "Color:"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(336, 192)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 23)
        Me.Label15.TabIndex = 123
        Me.Label15.Text = "Precio:"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(336, 384)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 23)
        Me.Label16.TabIndex = 124
        Me.Label16.Text = "Precio:"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(336, 576)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 23)
        Me.Label17.TabIndex = 125
        Me.Label17.Text = "Precio:"
        '
        'frmConsultaExistencias
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 670)
        Me.Controls.Add(Me.UiTab1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmConsultaExistencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultas de Existencias"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        CType(Me.GridEX2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NicePanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.FotoArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage2.ResumeLayout(False)
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ExplorerBar2.PerformLayout()
        CType(Me.For3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.For2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.For1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImAlter1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImAlter2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImAlter3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Function LoadTablaLocal() As DataTable
        Dim tabla As New DataTable("Existencias2")
        tabla.Columns.Add("Almacén", Type.GetType("System.String"))
        tabla.Columns.Add("Descripción", Type.GetType("System.String"))
        tabla.Columns.Add("Número", Type.GetType("System.String"))
        tabla.Columns.Add("Libre", Type.GetType("System.Int32"))
        tabla.Columns.Add("Bloqueados", Type.GetType("System.Int32"))
        tabla.Columns.Add("Apartados", Type.GetType("System.Int32"))
        tabla.Columns.Add("Defectuosos", Type.GetType("System.Int32"))
        tabla.Columns.Add("Transito", Type.GetType("System.Int32"))
        tabla.Columns.Add("Consignacion", Type.GetType("System.Int32"))
        tabla.Columns.Add("CodArticulo", Type.GetType("System.String"))
        tabla.Columns.Add("Reserva", Type.GetType("System.Int32"))
        tabla.Columns.Add("Calidad", Type.GetType("System.Int32"))
        Return tabla
    End Function


#Region "Métodos Privados"

    Private Sub Sm_TxtLimpiar()

        ArticuloID.Text = String.Empty
        Descripcion.Text = String.Empty
        Proveedor.Text = String.Empty
        Color.Text = String.Empty
        Precio.Text = String.Empty
        Oferta.Text = String.Empty
        Descuento.Text = String.Empty
        Linea.Text = String.Empty
        Familia.Text = String.Empty
        Uso.Text = String.Empty
        FotoArticulo.Image = Nothing
        ImAlter1.Image = Nothing
        ImAlter2.Image = Nothing
        ImAlter3.Image = Nothing
        DescripcionAlter1.Text = String.Empty
        ColorAlter1.Text = String.Empty
        PrecioAlter1.Text = String.Empty
        DescripcionAlter2.Text = String.Empty
        ColorAlter2.Text = String.Empty
        PrecioAlter2.Text = String.Empty
        DescripcionAlter3.Text = String.Empty
        ColorAlter3.Text = String.Empty
        PrecioAlter3.Text = String.Empty
        ebAlter1.Text = String.Empty
        ebAlter2.Text = String.Empty
        ebAlter3.Text = String.Empty
        Me.Corrida.Text = String.Empty
        strUrl = String.Empty
        Me.ArticuloID.Focus()
        GridEX2.DataSource = Nothing
        'GridEX2.ClearStructure()


    End Sub



#End Region

    Private Sub btnActionExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oCatalogoArticulosMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
        Dim oArticulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        Dim oConsulta As ConsultaExistenciasAbstract
        Dim oResultado As ResultadoConsultaExistencias
        Dim AlterFlag As String
        Dim Result As New ApplicationUnits.ConsultaExistencias.ResultadoConsultaExistencias

        '<Validación>

        If (ArticuloID.Text.Trim = String.Empty) Then

            MsgBox("No ha sido seleccionado un Artículo", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If


        '</Validación>

        Cursor.Current = Cursors.WaitCursor

        ''''''''
        Dim oCatalogoUPCMgr As CatalogoUPCManager
        Dim oUPC As UPC
        oCatalogoUPCMgr = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
        On Error Resume Next

        oUPC = Nothing
        oUPC = oCatalogoUPCMgr.Load(ArticuloID.Text.Trim)
        If oUPC.IsDirty Then

        Else
            ArticuloID.Text = oUPC.CodArticulo
        End If

        If UiComboBox1.Text = "Local" Then

            oAlmacen = oCatalogoAlmacenesMgr.Load(oSapMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
            oConsulta = New ConsultaExistenciasLocal(oAppContext, oAppContext.ApplicationConfiguration.Almacen)

            oResultado = Nothing
            oResultado = oConsulta.Execute(ArticuloID.Text, oAlmacen.ID)

            If (oResultado Is Nothing) Then
                MsgBox("El Articulo No existe", MsgBoxStyle.Exclamation, "DPTienda")
                Sm_TxtLimpiar()
                Exit Sub
            End If

            ArticuloID.Text = oResultado.ArticuloID
            Descripcion.Text = oResultado.Descripcion
            Color.Text = oResultado.Color
            Precio.Text = Format(oResultado.Precio, "$###,##0.00##")
            Oferta.Text = Format(oResultado.Promocion, "$###,##0.00##")
            Descuento.Text = oResultado.Descuento & "%"
            Linea.Text = oResultado.Linea
            Familia.Text = oResultado.Familia
            Uso.Text = oResultado.Uso
            ebAlter1.Text = oResultado.CodAlt1
            ebAlter2.Text = oResultado.CodAlt2
            ebAlter3.Text = oResultado.CodAlt3
            Corrida.Text = oResultado.CodCorrida

            '-------------------------------------------------------------------------------------------
            ' MLVARGAS (02/09/2021) Comentado, método anterior para colocar imagen
            '--------------------------------------------------------------------------------------------
            'If oResultado.HaveImage = True Then
            '    FotoArticulo.Image = Image.FromStream(oResultado.Foto)
            'Else
            '    FotoArticulo.Image = Nothing
            'End If



            Dim dsDataSource As DataSet
            oConsulta.FillDetailData(oResultado.ArticuloID, oAlmacen.ID, oResultado)
            dsDataSource = oResultado.Existencias
            dsDataSource.Tables("Existencias").Columns("Numero").ColumnName = "Número"

            Dim tabla As DataTable
            tabla = LoadTablaLocal()

            For Each registro As DataRow In dsDataSource.Tables(0).Rows
                tabla.ImportRow(registro)
            Next

            dsDataSource.Tables.Add(tabla.Copy)

            With GridEX2
                '.DataBindings.Clear()
                .SetDataBinding(dsDataSource, "Existencias2")
                '.RetrieveStructure()
                .Refresh()

            End With

            If (ebAlter1.Text <> "") Then
                AlterFlag = "Alter1"
                oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA1.Visible = False
                Me.For1.Visible = False
                If oResultado.HaveImageAlter = True Then
                    ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter1.Text = oResultado.Descripcion
                    ColorAlter1.Text = oResultado.Color
                    PrecioAlter1.Text = oResultado.Precio
                    Me.lblFotoNoDisponibleA1.Visible = False
                    Me.For1.Visible = False
                Else
                    ImAlter1.Image = Nothing
                    Me.lblFotoNoDisponibleA1.Visible = True
                    Me.For1.Visible = True
                End If
            Else
                Me.lblNoExistenteA1.Visible = True
                Me.For1.Visible = True
            End If

            If (ebAlter2.Text <> "") Then
                AlterFlag = "Alter2"
                oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA2.Visible = False
                Me.For2.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA2.Visible = False
                    ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter2.Text = oResultado.Descripcion
                    ColorAlter2.Text = oResultado.Color
                    PrecioAlter2.Text = oResultado.Precio
                    Me.For2.Visible = False
                Else
                    ImAlter2.Image = Nothing
                    Me.lblFotoNoDisponibleA2.Visible = True
                    Me.For2.Visible = True
                End If
            Else
                Me.lblNoExistenteA2.Visible = True
                Me.For2.Visible = True
            End If

            If (ebAlter3.Text <> "") Then
                AlterFlag = "Alter3"
                oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA3.Visible = False
                Me.For3.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA3.Visible = False
                    ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter3.Text = oResultado.Descripcion
                    ColorAlter3.Text = oResultado.Color
                    PrecioAlter3.Text = oResultado.Precio
                    Me.For3.Visible = False
                Else
                    ImAlter3.Image = Nothing
                    Me.lblFotoNoDisponibleA3.Visible = True
                    Me.For3.Visible = True
                End If
            Else
                Me.lblNoExistenteA3.Visible = True
                Me.For3.Visible = True
            End If



        Else

            Dim dsDataSourcePlaza As New System.Data.DataSet
            'Dim ws As New wsInventarioDP.InventarioDP

            'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then
            '    ws.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            '    ws.strURL.TrimEnd("/")
            'End If

            oAlmacen = oCatalogoAlmacenesMgr.Load(oSapMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
            oConsulta = New ConsultaExistenciasLocal(oAppContext, oAlmacen.PlazaID)

            oResultado = oConsulta.Execute(ArticuloID.Text, oAlmacen.ID)

            If (oResultado Is Nothing) Then
                MsgBox("El Articulo No existe", MsgBoxStyle.Exclamation, "DPTienda")
                Sm_TxtLimpiar()
                Exit Sub
            End If

            ArticuloID.Text = oResultado.ArticuloID
            Descripcion.Text = oResultado.Descripcion
            Color.Text = oResultado.Color
            Precio.Text = Format(oResultado.Precio, "$###,##0.00##")
            Oferta.Text = Format(oResultado.Promocion, "$###,##0.00##")
            Descuento.Text = oResultado.Descuento & "%"
            Linea.Text = oResultado.Linea
            Familia.Text = oResultado.Familia
            Uso.Text = oResultado.Uso
            ebAlter1.Text = oResultado.CodAlt1
            ebAlter2.Text = oResultado.CodAlt2
            ebAlter3.Text = oResultado.CodAlt3
            Corrida.Text = oResultado.CodCorrida

            '-------------------------------------------------------------------------------------------
            ' MLVARGAS (02/09/2021) Comentado, método anterior para colocar imagen
            '--------------------------------------------------------------------------------------------
            'If oResultado.HaveImage = True Then
            '    FotoArticulo.Image = Image.FromStream(oResultado.Foto)
            'Else
            '    FotoArticulo.Image = Nothing
            'End If

            'dsDataSourcePlaza = ws.ConsultaExistenciaWeb(ArticuloID.Text, oAlmacen.PlazaID)

            Dim tabla As DataTable
            tabla = LoadTablaLocal()

            For Each registro As DataRow In dsDataSourcePlaza.Tables(0).Rows
                tabla.ImportRow(registro)
            Next
            dsDataSourcePlaza.Tables.Add(tabla.Copy)
            With GridEX2

                .SetDataBinding(dsDataSourcePlaza, "Existencias2")
                '.RetrieveStructure()
                .Refresh()

            End With



            If (ebAlter1.Text <> "") Then
                AlterFlag = "Alter1"
                oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA1.Visible = False
                Me.For1.Visible = False
                If oResultado.HaveImageAlter = True Then
                    ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter1.Text = oResultado.Descripcion
                    ColorAlter1.Text = oResultado.Color
                    PrecioAlter1.Text = oResultado.Precio
                    Me.lblFotoNoDisponibleA1.Visible = False
                    Me.For1.Visible = False
                Else
                    ImAlter1.Image = Nothing
                    Me.lblFotoNoDisponibleA1.Visible = True
                    Me.For1.Visible = True
                End If
            Else
                Me.lblNoExistenteA1.Visible = True
                Me.For1.Visible = True
            End If

            If (ebAlter2.Text <> "") Then
                AlterFlag = "Alter2"
                oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA2.Visible = False
                Me.For2.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA2.Visible = False
                    ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter2.Text = oResultado.Descripcion
                    ColorAlter2.Text = oResultado.Color
                    PrecioAlter2.Text = oResultado.Precio
                    Me.For2.Visible = False
                Else
                    ImAlter2.Image = Nothing
                    Me.lblFotoNoDisponibleA2.Visible = True
                    Me.For2.Visible = True
                End If
            Else
                Me.lblNoExistenteA2.Visible = True
                Me.For2.Visible = True
            End If

            If (ebAlter3.Text <> "") Then
                AlterFlag = "Alter3"
                oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA3.Visible = False
                Me.For3.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA3.Visible = False
                    ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter3.Text = oResultado.Descripcion
                    ColorAlter3.Text = oResultado.Color
                    PrecioAlter3.Text = oResultado.Precio
                    Me.For3.Visible = False
                Else
                    ImAlter3.Image = Nothing
                    Me.lblFotoNoDisponibleA3.Visible = True
                    Me.For3.Visible = True
                End If
            Else
                Me.lblNoExistenteA3.Visible = True
                Me.For3.Visible = True
            End If


        End If

        Cursor.Current = Cursors.Default
        ArticuloID.Focus()

    End Sub



    Private Sub ArticuloID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ArticuloID.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Dim oOpenRecordDlg As New OpenRecordDialog2
            oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

            oOpenRecordDlg.ShowDialog()


            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Sm_TxtLimpiar()

                'ArticuloID.Text = oOpenRecordDlg.Record.Item("Código")

                Dim cArticulo As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    cArticulo = oOpenRecordDlg.Record.Item("Código")

                Else
                    cArticulo = oOpenRecordDlg.pbCodigo

                End If

                ArticuloID.Text = cArticulo

            End If

        Else

            If e.KeyCode = Keys.Enter Then

                If Trim(ArticuloID.Text) <> String.Empty Then

                    ArticuloID.Text = LoadCodigo(ArticuloID.Text)

                    If ArticuloID.Text = String.Empty Then

                        ArticuloID.Focus()

                    End If

                End If

            End If

        End If

    End Sub

    Private Function LoadCodigo(ByVal strCodigo As String) As String

        Dim strResult As String = String.Empty
        Dim oUPCMgr As CatalogoUPCManager = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
        Dim oUPC As UPC

        If oUPCMgr.IsSkuOrMaterial(strCodigo.PadLeft(18, "0")) = "S" Then
            'Buscamos Codigo UPC
            oUPC = oUPCMgr.Create

            oUPC = oUPCMgr.Load(strCodigo.PadLeft(18, "0"))

            If oUPC.CodArticulo <> String.Empty Then

                strResult = oUPC.CodArticulo

                btnAccionBusqueda.PerformClick()

            Else
                MsgBox("Código UPC No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Consulta Existencias")
                strResult = String.Empty
                Sm_TxtLimpiar()

            End If

            oUPCMgr.dispose()
            oUPCMgr = Nothing
            oUPC = Nothing
        Else
            'Verificamos si tiene talla
            'If IsNumeric(Microsoft.VisualBasic.Left(Trim(strCodigo), 2)) Then
            '    strResult = Microsoft.VisualBasic.Right((strCodigo.Trim), Len(Trim(strCodigo)) - 2)
            'Else

            Dim oArticulo As Articulo
            Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
            oArticulo = oArticuloMgr.Create
            oArticulo.ClearFields()

            oArticuloMgr.LoadInto(strCodigo, oArticulo)
            If oArticulo.CodArticulo <> String.Empty Then
                strCodigo = oArticulo.CodArticulo
                'btnAccionBusqueda.PerformClick()
            Else
                oArticulo.ClearFields()
                oArticuloMgr.LoadInto(strCodigo, oArticulo)
                If oArticulo.CodArticulo <> String.Empty Then
                    strCodigo = oArticulo.CodArticulo
                End If
            End If
            strResult = strCodigo
        End If
        'End If
        Return strResult

    End Function

    Private Sub frmConsultaExistencias_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If ModOrigen.Trim.ToUpper = "SH" Then
            chkLocal.Visible = False
            Me.Text = "Consulta de Existencias Si Hay"
        Else
            chkLocal.Visible = True
            Me.Text = "Consulta de Existencias"
        End If

        LoadBusqueda()
        SendKeys.Send("{TAB}")
    End Sub

    Private Function LoadBusqueda()
        'If FacturacionSiHay <> -1 Then
        If ModOrigen.Trim.ToUpper = "SH" Then
            Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)

            Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen, strCentro As String = ""

            strCentro = oSapMgr.Read_Centros
            oAlmacen = oCatalogoAlmacenesMgr.Load(strCentro.Trim)
            Dim busqueda As New DataTable("CatalogoAlmacenes")
            busqueda.Columns.Add("CodAlmacen", GetType(String))
            busqueda.Columns.Add("Descripcion", GetType(String))
            busqueda.AcceptChanges()
            Dim row As DataRow = Nothing
            row = busqueda.NewRow()
            row("CodAlmacen") = oAlmacen.ID
            row("Descripcion") = "Local"
            busqueda.Rows.Add(row)
            row = busqueda.NewRow()
            row("CodAlmacen") = "All"
            row("Descripcion") = "Todas las sucursales"
            busqueda.Rows.Add(row)
            Me.UiComboBox1.DataSource = busqueda
            Me.UiComboBox1.ValueMember = "CodAlmacen"
            Me.UiComboBox1.DisplayMember = "Descripcion"
            Me.UiComboBox1.Items.Sort()
            Me.UiComboBox1.SelectedValue = oAlmacen.ID
            'Dim almacen As New GridEXGroup(Me.GridEX2.RootTable.Columns(0))
            'almacen.HeaderCaption = "Sucursal"
            'almacen.SortOrder = SortOrder.Ascending
            'Me.GridEX2.RootTable.Groups.Add(almacen)
            'Dim libre As New GridEXGroupHeaderTotal
            'libre.AggregateFunction = AggregateFunction.Sum
            'libre.TotalFormatMode = FormatMode.UseStringFormat
            'libre.TotalFormatString = "Libre: {0:g}"
            'libre.Column = Me.GridEX2.RootTable.Columns("Column2")
            'Me.GridEX2.RootTable.GroupHeaderTotals.Add(libre)
            'Dim apartado As New GridEXGroupHeaderTotal
            'apartado.AggregateFunction = AggregateFunction.Sum
            'apartado.TotalFormatMode = FormatMode.UseStringFormat
            'apartado.TotalFormatString = "Apartado: {0:g}"
            'apartado.Column = Me.GridEX2.RootTable.Columns("column3")  '5
            'Me.GridEX2.RootTable.GroupHeaderTotals.Add(apartado)
            'Dim defectuoso As New GridEXGroupHeaderTotal
            'defectuoso.TotalFormatMode = FormatMode.UseStringFormat
            'defectuoso.TotalFormatString = "Defectuoso: {0:g}"
            'defectuoso.AggregateFunction = AggregateFunction.Sum
            'defectuoso.Column = Me.GridEX2.RootTable.Columns("column4") '4
            'Me.GridEX2.RootTable.GroupHeaderTotals.Add(defectuoso)
            'Dim transito As New GridEXGroupHeaderTotal
            'transito.AggregateFunction = AggregateFunction.Sum
            'transito.Column = Me.GridEX2.RootTable.Columns("column5") '7
            'transito.TotalFormatMode = FormatMode.UseStringFormat
            'transito.TotalFormatString = "Transito: {0:g}"
            'Me.GridEX2.RootTable.GroupHeaderTotals.Add(transito)
            Me.UiComboBox1.SelectedValue = "Local"
        Else
            Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
            Dim dsAlmacenes As DataSet
            dsAlmacenes = oCatalogoAlmacenesMgr.GetAll(False)

            Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
            oAlmacen = oCatalogoAlmacenesMgr.Load(oSapMgr.Read_Centros) '"2" & oAppContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0"))

            Dim value As String

            For Each row As DataRow In dsAlmacenes.Tables("CatalogoAlmacenes").Rows
                If row.Item("CodAlmacen") = oAlmacen.ID Then
                    row.Item("Descripcion") = "Local"
                    'value = row.Item("CodPlaza")
                    value = row.Item("CodAlmacen")
                    strCiudad = row.Item("Ciudad")
                    Exit For
                End If
            Next

            '----------------------------------------------------------------------------
            ' MLVARGAS (24/09/2021) Agregar opción de Mi Ciudad en el combo de consulta
            '----------------------------------------------------------------------------
            Dim oRow As DataRow = Nothing
            oRow = dsAlmacenes.Tables("CatalogoAlmacenes").NewRow()
            oRow("CodAlmacen") = "MiCd"
            oRow("Descripcion") = "Mi Ciudad"
            dsAlmacenes.Tables("CatalogoAlmacenes").Rows.Add(oRow)


            Me.UiComboBox1.DataSource = dsAlmacenes
            Me.UiComboBox1.DataMember = "CatalogoAlmacenes"
            Me.UiComboBox1.DisplayMember = "Descripcion"
            'Me.UiComboBox1.ValueMember = "CodPlaza"
            Me.UiComboBox1.ValueMember = "CodAlmacen"
            Me.UiComboBox1.Items.Sort()
            Me.UiComboBox1.SelectedValue = value
        End If
        NicePanel2.FooterText = "Grupo Dportenis @  " & CStr(Date.Now.Year) '2005
        If oConfigCierreFI.BloqueaBajaCalidad = False Then
            GridEX2.RootTable.Columns("Bloqueados").Visible = False
        End If
        Me.chkLocal.Enabled = True
        Me.chkLocal.Checked = False
    End Function


    Private Sub btnActionExecute_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ArticuloID.Focus()

    End Sub

    Private Sub ImAlter1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImAlter1.Click
        Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
        Dim oResultado As New ResultadoConsultaExistencias
        Dim oConsulta As ConsultaExistenciasAbstract
        oConsulta = New ConsultaExistenciasLocal(oAppContext, oAppContext.ApplicationConfiguration.Almacen)
        Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
        Dim AlterFlag As String
        'Dim ws As New wsInventarioDP.InventarioDP

        'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then
        '    ws.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
        '    ws.strURL.TrimEnd("/")
        'End If

        Dim dsDataSourcePlaza As New System.Data.DataSet

        If (ebAlter1.Text <> "") Then

            AlterFlag = "Alter1"
            oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
            ImAlter1.Image = Nothing
            ImAlter2.Image = Nothing
            ImAlter3.Image = Nothing
            DescripcionAlter1.Text = String.Empty
            ColorAlter1.Text = String.Empty
            PrecioAlter1.Text = String.Empty
            DescripcionAlter2.Text = String.Empty
            ColorAlter2.Text = String.Empty
            PrecioAlter2.Text = String.Empty
            DescripcionAlter3.Text = String.Empty
            ColorAlter3.Text = String.Empty
            PrecioAlter3.Text = String.Empty
            oAlmacen = oCatalogoAlmacenesMgr.Load(oSapMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

            If oResultado.HaveImageAlter = True Then

                ArticuloID.Text = oResultado.ArticuloID
                Descripcion.Text = oResultado.Descripcion
                Color.Text = oResultado.Color
                Precio.Text = oResultado.Precio
                Oferta.Text = oResultado.Promocion
                Descuento.Text = oResultado.Descuento
                Linea.Text = oResultado.Linea
                Familia.Text = oResultado.Familia
                Uso.Text = oResultado.Uso
                ebAlter1.Text = oResultado.CodAlt1
                ebAlter2.Text = oResultado.CodAlt2
                ebAlter3.Text = oResultado.CodAlt3

                '-------------------------------------------------------------------------------------------
                ' MLVARGAS (02/09/2021) Comentado, método anterior para colocar imagen
                '--------------------------------------------------------------------------------------------
                'If oResultado.HaveImage = True Then
                '    FotoArticulo.Image = Image.FromStream(oResultado.FotoAlter)
                'Else
                '    FotoArticulo.Image = Nothing
                'End If

                If UiComboBox1.Text = "Local" Then

                    Dim dsDataSource As DataSet
                    oConsulta.FillDetailData(oResultado.ArticuloID, oAlmacen.ID, oResultado)
                    dsDataSource = oResultado.Existencias
                    dsDataSource.Tables("Existencias").Columns("Numero").ColumnName = "Número"

                    Dim tabla As DataTable
                    tabla = LoadTablaLocal()

                    For Each registro As DataRow In dsDataSource.Tables(0).Rows
                        tabla.ImportRow(registro)
                    Next

                    dsDataSource.Tables.Add(tabla.Copy)

                    With GridEX2

                        .SetDataBinding(dsDataSource, "Existencias2")
                        '.RetrieveStructure()
                        .Refresh()

                    End With
                Else

                    'dsDataSourcePlaza = ws.ConsultaExistenciaWeb(ArticuloID.Text, oAlmacen.PlazaID)

                    Dim tabla As DataTable
                    tabla = LoadTablaLocal()

                    For Each registro As DataRow In dsDataSourcePlaza.Tables(0).Rows
                        tabla.ImportRow(registro)
                    Next
                    dsDataSourcePlaza.Tables.Add(tabla.Copy)

                    With GridEX2

                        .SetDataBinding(dsDataSourcePlaza, "Existencias2")
                        '.RetrieveStructure()
                        .Refresh()

                    End With


                End If


                If (ebAlter1.Text <> "") Then
                    AlterFlag = "Alter1"
                    oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA1.Visible = False
                    Me.For1.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter1.Text = oResultado.Descripcion
                        ColorAlter1.Text = oResultado.Color
                        PrecioAlter1.Text = oResultado.Precio
                        Me.lblFotoNoDisponibleA1.Visible = False
                        Me.For1.Visible = False
                    Else
                        ImAlter1.Image = Nothing
                        Me.lblFotoNoDisponibleA1.Visible = True
                        Me.For1.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA1.Visible = True
                    Me.For1.Visible = True
                End If

                If (ebAlter2.Text <> "") Then
                    AlterFlag = "Alter2"
                    oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA2.Visible = False
                    Me.For2.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA2.Visible = False
                        ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter2.Text = oResultado.Descripcion
                        ColorAlter2.Text = oResultado.Color
                        PrecioAlter2.Text = oResultado.Precio
                        Me.For2.Visible = False
                    Else
                        ImAlter2.Image = Nothing
                        Me.For2.Visible = True
                        Me.lblFotoNoDisponibleA2.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA2.Visible = True
                    Me.For2.Visible = True
                End If

                If (ebAlter3.Text <> "") Then
                    AlterFlag = "Alter3"
                    oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA3.Visible = False
                    Me.For3.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA3.Visible = False
                        ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter3.Text = oResultado.Descripcion
                        ColorAlter3.Text = oResultado.Color
                        PrecioAlter3.Text = oResultado.Precio
                        Me.For3.Visible = False
                    Else
                        ImAlter3.Image = Nothing
                        Me.lblFotoNoDisponibleA3.Visible = True
                        Me.For3.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA3.Visible = True
                    Me.For3.Visible = True
                End If

            Else
                ImAlter1.Image = Nothing
                MsgBox("No selecciono un artículo.", MsgBoxStyle.Exclamation, "DPTienda")

            End If
        End If



    End Sub

    Private Sub ImAlter2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImAlter2.Click
        Dim oResultado As New ResultadoConsultaExistencias
        Dim oConsulta As ConsultaExistenciasAbstract
        Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
        oConsulta = New ConsultaExistenciasLocal(oAppContext, oAppContext.ApplicationConfiguration.Almacen)
        Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
        Dim AlterFlag As String
        'Dim ws As New wsInventarioDP.InventarioDP

        'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then
        '    ws.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
        '    ws.strURL.TrimEnd("/")
        'End If

        Dim dsDataSourcePlaza As New System.Data.DataSet

        If (ebAlter2.Text <> "") Then

            AlterFlag = "Alter2"
            oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
            ImAlter1.Image = Nothing
            ImAlter2.Image = Nothing
            ImAlter3.Image = Nothing
            PrecioAlter1.Text = String.Empty
            PrecioAlter2.Text = String.Empty
            PrecioAlter3.Text = String.Empty
            DescripcionAlter1.Text = String.Empty
            ColorAlter1.Text = String.Empty
            PrecioAlter1.Text = String.Empty
            DescripcionAlter2.Text = String.Empty
            ColorAlter2.Text = String.Empty
            PrecioAlter2.Text = String.Empty
            DescripcionAlter3.Text = String.Empty
            ColorAlter3.Text = String.Empty
            PrecioAlter3.Text = String.Empty


            oAlmacen = oCatalogoAlmacenesMgr.Load(oSapMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

            If oResultado.HaveImageAlter = True Then

                ArticuloID.Text = oResultado.ArticuloID
                Descripcion.Text = oResultado.Descripcion
                Color.Text = oResultado.Color
                Precio.Text = oResultado.Precio
                Oferta.Text = oResultado.Promocion
                Descuento.Text = oResultado.Descuento
                Linea.Text = oResultado.Linea
                Familia.Text = oResultado.Familia
                Uso.Text = oResultado.Uso
                ebAlter1.Text = oResultado.CodAlt1
                ebAlter2.Text = oResultado.CodAlt2
                ebAlter3.Text = oResultado.CodAlt3

                '-------------------------------------------------------------------------------------------
                ' MLVARGAS (02/09/2021) Comentado, método anterior para colocar imagen
                '--------------------------------------------------------------------------------------------
                'If oResultado.HaveImage = True Then
                '    FotoArticulo.Image = Image.FromStream(oResultado.FotoAlter)
                'Else
                '    FotoArticulo.Image = Nothing
                'End If

                If UiComboBox1.Text = "Local" Then

                    Dim dsDataSource As DataSet
                    oConsulta.FillDetailData(oResultado.ArticuloID, oAlmacen.ID, oResultado)
                    dsDataSource = oResultado.Existencias
                    dsDataSource.Tables("Existencias").Columns("Numero").ColumnName = "Número"

                    Dim tabla As DataTable
                    tabla = LoadTablaLocal()

                    For Each registro As DataRow In dsDataSource.Tables(0).Rows
                        tabla.ImportRow(registro)
                    Next

                    dsDataSource.Tables.Add(tabla.Copy)

                    With GridEX2

                        .SetDataBinding(dsDataSource, "Existencias2")
                        '.RetrieveStructure()
                        .Refresh()

                    End With

                Else

                    'dsDataSourcePlaza = ws.ConsultaExistenciaWeb(ArticuloID.Text, oAlmacen.PlazaID)

                    Dim tabla As DataTable
                    tabla = LoadTablaLocal()

                    For Each registro As DataRow In dsDataSourcePlaza.Tables(0).Rows
                        tabla.ImportRow(registro)
                    Next
                    dsDataSourcePlaza.Tables.Add(tabla.Copy)

                    With GridEX2

                        .SetDataBinding(dsDataSourcePlaza, "Existencias2")
                        '.RetrieveStructure()
                        .Refresh()

                    End With
                End If


                If (ebAlter1.Text <> "") Then
                    AlterFlag = "Alter1"
                    oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA1.Visible = False
                    Me.For1.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter1.Text = oResultado.Descripcion
                        ColorAlter1.Text = oResultado.Color
                        PrecioAlter1.Text = oResultado.Precio
                        Me.lblFotoNoDisponibleA1.Visible = False
                        Me.For1.Visible = False
                    Else
                        ImAlter1.Image = Nothing
                        Me.lblFotoNoDisponibleA1.Visible = True
                        Me.For1.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA1.Visible = True
                    Me.For1.Visible = True
                End If

                If (ebAlter2.Text <> "") Then
                    AlterFlag = "Alter2"
                    oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA2.Visible = False
                    Me.For2.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA2.Visible = False
                        ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter2.Text = oResultado.Descripcion
                        ColorAlter2.Text = oResultado.Color
                        PrecioAlter2.Text = oResultado.Precio
                        Me.For2.Visible = False
                    Else
                        ImAlter2.Image = Nothing
                        Me.lblFotoNoDisponibleA2.Visible = True
                        Me.For2.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA2.Visible = True
                    Me.For2.Visible = True
                End If

                If (ebAlter3.Text <> "") Then
                    AlterFlag = "Alter3"
                    oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA3.Visible = False
                    Me.For3.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA3.Visible = False
                        ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter3.Text = oResultado.Descripcion
                        ColorAlter3.Text = oResultado.Color
                        PrecioAlter3.Text = oResultado.Precio
                        Me.For3.Visible = False
                    Else
                        ImAlter3.Image = Nothing
                        Me.lblFotoNoDisponibleA3.Visible = True
                        Me.For3.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA3.Visible = True
                    Me.For3.Visible = True
                End If

            Else
                ImAlter2.Image = Nothing
                MsgBox("No selecciono un artículo.", MsgBoxStyle.Exclamation, "DPTienda")
            End If
        End If


    End Sub

    Private Sub ImAlter3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImAlter3.Click
        Dim oResultado As New ResultadoConsultaExistencias
        Dim oConsulta As ConsultaExistenciasAbstract
        oConsulta = New ConsultaExistenciasLocal(oAppContext, oAppContext.ApplicationConfiguration.Almacen)
        Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
        Dim AlterFlag As String
        Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
        'Dim ws As New wsInventarioDP.InventarioDP

        'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then
        '    ws.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
        '    ws.strURL.TrimEnd("/")
        'End If

        Dim dsDataSourcePlaza As New System.Data.DataSet

        If (ebAlter3.Text <> "") Then

            AlterFlag = "Alter3"
            oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
            ImAlter1.Image = Nothing
            ImAlter2.Image = Nothing
            ImAlter3.Image = Nothing
            PrecioAlter1.Text = String.Empty
            PrecioAlter2.Text = String.Empty
            PrecioAlter3.Text = String.Empty
            DescripcionAlter1.Text = String.Empty
            ColorAlter1.Text = String.Empty
            PrecioAlter1.Text = String.Empty
            DescripcionAlter2.Text = String.Empty
            ColorAlter2.Text = String.Empty
            PrecioAlter2.Text = String.Empty
            DescripcionAlter3.Text = String.Empty
            ColorAlter3.Text = String.Empty
            PrecioAlter3.Text = String.Empty

            oAlmacen = oCatalogoAlmacenesMgr.Load(oSapMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

            If oResultado.HaveImageAlter = True Then

                ArticuloID.Text = oResultado.ArticuloID
                Descripcion.Text = oResultado.Descripcion
                Color.Text = oResultado.Color
                Precio.Text = oResultado.Precio
                Oferta.Text = oResultado.Promocion
                Descuento.Text = oResultado.Descuento
                Linea.Text = oResultado.Linea
                Familia.Text = oResultado.Familia
                Uso.Text = oResultado.Uso
                ebAlter1.Text = oResultado.CodAlt1
                ebAlter2.Text = oResultado.CodAlt2
                ebAlter3.Text = oResultado.CodAlt3

                '-------------------------------------------------------------------------------------------
                ' MLVARGAS (02/09/2021) Comentado, método anterior para colocar imagen
                '--------------------------------------------------------------------------------------------
                'If oResultado.HaveImage = True Then
                '    FotoArticulo.Image = Image.FromStream(oResultado.FotoAlter)
                'Else
                '    FotoArticulo.Image = Nothing
                'End If

                If UiComboBox1.Text = "Local" Then


                    Dim dsDataSource As DataSet
                    oConsulta.FillDetailData(oResultado.ArticuloID, oAlmacen.ID, oResultado)
                    dsDataSource = oResultado.Existencias
                    dsDataSource.Tables("Existencias").Columns("Numero").ColumnName = "Número"

                    Dim tabla As DataTable
                    tabla = LoadTablaLocal()

                    For Each registro As DataRow In dsDataSource.Tables(0).Rows
                        tabla.ImportRow(registro)
                    Next

                    dsDataSource.Tables.Add(tabla.Copy)

                    With GridEX2

                        .SetDataBinding(dsDataSource, "Existencias2")
                        '.RetrieveStructure()
                        .Refresh()

                    End With

                Else



                    'dsDataSourcePlaza = ws.ConsultaExistenciaWeb(ArticuloID.Text, oAlmacen.PlazaID)

                    Dim tabla As DataTable
                    tabla = LoadTablaLocal()

                    For Each registro As DataRow In dsDataSourcePlaza.Tables(0).Rows
                        tabla.ImportRow(registro)
                    Next
                    dsDataSourcePlaza.Tables.Add(tabla.Copy)

                    With GridEX2

                        .SetDataBinding(dsDataSourcePlaza, "Existencias2")
                        '.RetrieveStructure()
                        .Refresh()

                    End With
                End If

                If (ebAlter1.Text <> "") Then
                    AlterFlag = "Alter1"
                    oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA1.Visible = False
                    Me.For1.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter1.Text = oResultado.Descripcion
                        ColorAlter1.Text = oResultado.Color
                        PrecioAlter1.Text = oResultado.Precio
                        Me.lblFotoNoDisponibleA1.Visible = False
                        Me.For1.Visible = False
                    Else
                        ImAlter1.Image = Nothing
                        Me.lblFotoNoDisponibleA1.Visible = True
                        Me.For1.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA1.Visible = True
                    Me.For1.Visible = True
                End If

                If (ebAlter2.Text <> "") Then
                    AlterFlag = "Alter2"
                    oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA2.Visible = False
                    Me.For2.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA2.Visible = False
                        ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter2.Text = oResultado.Descripcion
                        ColorAlter2.Text = oResultado.Color
                        PrecioAlter2.Text = oResultado.Precio
                        Me.For2.Visible = False
                    Else
                        ImAlter2.Image = Nothing
                        Me.lblFotoNoDisponibleA2.Visible = True
                        Me.For2.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA2.Visible = True
                    Me.For2.Visible = True
                End If

                If (ebAlter3.Text <> "") Then
                    AlterFlag = "Alter3"
                    oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA3.Visible = False
                    Me.For3.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA3.Visible = False
                        ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter3.Text = oResultado.Descripcion
                        ColorAlter3.Text = oResultado.Color
                        PrecioAlter3.Text = oResultado.Precio
                        Me.For3.Visible = False
                    Else
                        ImAlter3.Image = Nothing
                        Me.lblFotoNoDisponibleA3.Visible = True
                        Me.For3.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA3.Visible = True
                    Me.For3.Visible = True
                End If
            End If


        Else
            ImAlter3.Image = Nothing
            MsgBox("No selecciono un artículo.", MsgBoxStyle.Exclamation, "DPTienda")


        End If


    End Sub

    Private Sub ArticuloID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ArticuloID.ButtonClick
        Dim oOpenRecordDlg As New OpenRecordDialog2
        oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

        oOpenRecordDlg.ShowDialog()


        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Sm_TxtLimpiar()

            ArticuloID.Text = oOpenRecordDlg.Record.Item("Código")
        End If

    End Sub


    Private Function CargarFamiliaArticulos(ByVal ArticuloID As String, ByRef list As List(Of String)) As List(Of String)
        Dim oCatalogoArticulosMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim dtProductos As DataTable
        Dim articulo As String
        Dim oList As New List(Of String)

        dtProductos = oCatalogoArticulosMgr.LoadIntoByCodPadre(ArticuloID.Substring(0, ArticuloID.Length - 3))
        If Not dtProductos Is Nothing Then
            For Each oRow As DataRow In dtProductos.Rows
                'If oRow!CodArticulo <> ArticuloID Then
                articulo = oRow!CodArticulo
                list.Add(articulo)
                oList.Add(articulo.Substring(8))
            Next
        End If
        Return oList

    End Function


    Private Sub btnAccionBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccionBusqueda.Click
        Dim oCatalogoArticulosMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
        Dim oFacturaMgr As New DportenisPro.DPTienda.ApplicationUnits.Facturas.FacturaManager(oAppContext)
        Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
        Dim oArticulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        Dim oConsulta As ConsultaExistenciasAbstract
        Dim oResultado As ResultadoConsultaExistencias
        Dim AlterFlag As String
        Dim Result As New ApplicationUnits.ConsultaExistencias.ResultadoConsultaExistencias
        Dim centro As String = String.Empty
        Dim ciudad As String = String.Empty
        Dim codColor As String = String.Empty
        Dim dtTallas As New DataTable

        '<Validación>

        FotoArticulo.Image = Nothing
        If (ArticuloID.Text.Trim = String.Empty) Then

            MsgBox("No ha sido seleccionado un Artículo", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        Else
            'If ArticuloID.Text.IndexOf("*") >= 0 Then
            '    ArticuloID.Text = ArticuloID.Text.Substring(ArticuloID.Text.IndexOf("*") + 1)
            'End If

            ArticuloID.Text.PadLeft(18, "0")
        End If


        Dim list As New List(Of String)
        list.Add(ArticuloID.Text)


        Dim oList As List(Of String)

        '-------------------------------------------------------------------------------------------------------------------
        'MLVARGAS 07/04/2022: Buscar los códigos de los productos de la familia
        '-------------------------------------------------------------------------------------------------------------------
        If UiComboBox1.Text = "Local" Then
            oList = CargarFamiliaArticulos(ArticuloID.Text, list)
        End If


        '-------------------------------------------------------------------------------------------------------------------
        'MLVARGAS 12/04/2022: Obtener las tallas del servicio de SAPCAR 
        '-------------------------------------------------------------------------------------------------------------------
        'dtTallas = ConsultaTallaArticulos(oList)  'Tallas de Netezza queda pendiente

        If (oSapMgr.SAPApplicationConfig.SiHay Or oSapMgr.SAPApplicationConfig.Inventario) AndAlso chkLocal.Checked = False Then
            dtTallas = ConsultaExistenciasSAPCAR("General", list, "", "", False)
        End If


        '</Validación>

        GridEX2.DataSource = Nothing
        Cursor.Current = Cursors.WaitCursor

        Dim oCatalogoUPCMgr As CatalogoUPCManager
        Dim oUPC As UPC
        oCatalogoUPCMgr = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
        On Error Resume Next

        oUPC = Nothing
        oUPC = oCatalogoUPCMgr.Load(ArticuloID.Text.Trim)
        If oUPC.IsDirty Then

        Else
            ArticuloID.Text = oUPC.CodArticulo
        End If

        '-------------------------------------------------------------------------------------------------------------------
        'MLVARGAS 01/09/2021: Obtener el codigo de color del artículo seleccionado
        '-------------------------------------------------------------------------------------------------------------------
        If oSapMgr.SAPApplicationConfig.SiHay = False AndAlso ModOrigen.Trim.ToUpper = "SH" Or
           oSapMgr.SAPApplicationConfig.Inventario = False AndAlso ModOrigen.Trim.ToUpper <> "SH" Or
           UiComboBox1.Text = "Local" Then
            codColor = oCatalogoArticulosMgr.SelectCodColor(ArticuloID.Text.Trim)
            If codColor <> "NA" Then
                'Buscar la imagen del producto
                Dim generico As String = ArticuloID.Text.Substring(8, 7)
                Dim strPath As String = oConfigCierreFI.ImagenesExistencia & generico & "-" & codColor & ".jpg"
                ObtenerImagen(strPath)
            End If
        End If

        '-------------------------------------------------------------------------------------------------------------------
        'MLVARGAS 26/08/2021: Si se esta activa la consulta por SAP CAR, la consulta Local se realizará con dicho servicio
        '-------------------------------------------------------------------------------------------------------------------
        Dim bLocal As Boolean = False
        If UiComboBox1.Text = "Local" Then
            bLocal = True

            ' Se va a consultar al servicio de SAP
            If chkLocal.Checked = False AndAlso chkLocal.Visible Then
                bLocal = False
            End If

            'Servicio Local de Si Hay, se revisa con el servicio de SAP CAR
            If oSapMgr.SAPApplicationConfig.SiHay AndAlso ModOrigen.Trim.ToUpper = "SH" AndAlso chkLocal.Checked = False Then
                bLocal = False
            End If

            'Servicio Local Consulta de Existencia, se realiza con el servicio de SAP CAR
            If oSapMgr.SAPApplicationConfig.Inventario AndAlso ModOrigen.Trim.ToUpper <> "SH" AndAlso chkLocal.Checked = False Then
                bLocal = False
            End If
        End If



        If bLocal Then  'Consula a base de datos local sin importar la configuración de SAPCAR

            Dim strCentro As String = ""
            strCentro = oSapMgr.Read_Centros
            oAlmacen = oCatalogoAlmacenesMgr.Load(strCentro.Trim)
            oConsulta = New ConsultaExistenciasLocal(oAppContext, oAppContext.ApplicationConfiguration.Almacen)

            oResultado = Nothing
            oResultado = oConsulta.Execute(ArticuloID.Text, oAlmacen.ID, True, True)

            If (oResultado Is Nothing) Then
                MsgBox("El Articulo No existe", MsgBoxStyle.Exclamation, "DPTienda")
                Sm_TxtLimpiar()

                'BUSCAR EN LA BASE DE DATOS DE SEPARACIONES
                Exit Sub
            End If

            ArticuloID.Text = oResultado.ArticuloID
            Descripcion.Text = oResultado.Descripcion
            Proveedor.Text = oResultado.CodArtProv
            Color.Text = oCatalogoAlmacenesMgr.SeleccionaColor(Mid(oResultado.ArticuloID, 11, 1)) 'oResultado.Color
            Precio.Text = "$" & Format(oResultado.Precio, "Standard")
            Oferta.Text = Format(oResultado.Promocion, "$###,##0.00##")
            Descuento.Text = oResultado.Descuento & "%"
            Linea.Text = oResultado.Linea
            Familia.Text = oResultado.Familia
            Uso.Text = oResultado.Uso
            ebAlter1.Text = oResultado.CodAlt1
            ebAlter2.Text = oResultado.CodAlt2
            ebAlter3.Text = oResultado.CodAlt3
            Corrida.Text = oResultado.CodCorrida

            '-------------------------------------------------------------------------------------------
            ' MLVARGAS (02/09/2021) Comentado, método anterior para colocar imagen
            '--------------------------------------------------------------------------------------------
            'If File.Exists(Application.StartupPath & "\Fotos\" & oResultado.ArticuloID & ".JPG") Then
            '    FotoArticulo.Image = Image.FromFile(Application.StartupPath & "\Fotos\" & oResultado.ArticuloID & ".JPG")
            'Else
            '    '----------------------------------------------------------------------------------------------------------------
            '    'FLIZARRAGA 16/12/2014: Se descarga desde el sitio web en caso de que no se encuentre en el equipo local
            '    '----------------------------------------------------------------------------------------------------------------
            '    'FotoArticulo.Image = DownloadImageFromWeb(oResultado.ArticuloID)
            '    'FotoArticulo.Image = Nothing
            'End If
            '****************************Condiciones de Venta********************************
            Dim oCondicionVenta As New CondicionesVtaSAP
            oCondicionVenta.Jerarquia = oResultado.Jeraquia
            oCondicionVenta.CondMat = oResultado.CodMarca
            oCondicionVenta.Material = oResultado.ArticuloID
            If Not oAppContext.ApplicationConfiguration.Almacen = "053" Then
Cambio_053:
                oCondicionVenta.OficinaVtas = "T" & oAppContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0") 'oAppSAPConfig.OficinaVenta
                oCondicionVenta.ListPrec = "Z1"
                oCondicionVenta.CondPrec = "01"
            Else
                GoTo Cambio_053
                'oCondicionVenta.OficinaVtas = "C053"
                'oCondicionVenta.ListPrec = "C1"
                'oCondicionVenta.CondPrec = "01"
            End If
            oFacturaMgr.GetCondicionVenta(oCondicionVenta)
            Dim dblDesc As Double = 0
            Dim dblPrecIva As Double = 0

            If oCondicionVenta.DescPorcentaje > 0 Then
                'Porcentaje
                dblPrecIva = (oResultado.Precio)
                dblDesc = dblPrecIva * (oCondicionVenta.DescPorcentaje / 100)
                Oferta.Text = "$" & Format(dblPrecIva - dblDesc, "Standard")
                Descuento.Text = Math.Round(oCondicionVenta.DescPorcentaje, 2) & "%"
            Else
                If oCondicionVenta.Descmonto > 0 Then
                    'Monto descuento
                    Oferta.Text = "$" & Format(oResultado.Precio - oCondicionVenta.Descmonto, "Standard")
                    Descuento.Text = "$" & Format(Math.Round(oCondicionVenta.Descmonto, 2), "Standard")
                End If
            End If
            '****************************Condiciones de Venta********************************
            Dim dsDataSource As DataSet
            oConsulta.FillDetailData(oResultado.ArticuloID, oAlmacen.ID, oResultado, True)
            dsDataSource = oResultado.Existencias
            dsDataSource.Tables("Existencias").Columns("Numero").ColumnName = "Número"
            dsDataSource.Tables("Existencias").Columns.Add("Descripción")
            dsDataSource.Tables("Existencias").Columns.Add("Reserva")
            dsDataSource.Tables("Existencias").Columns.Add("Calidad")

            Dim tabla As DataTable, dtTransitoSAP As New DataTable, dtView As DataView, Talla As String = "", oRowV As DataRowView
            Dim defecMgr As New DefectuososManager(oAppContext, oAppSAPConfig)
            Dim dtBloqueados As DataTable = Nothing
            Dim dtBloqView As DataView
            tabla = LoadTablaLocal()

            'Consultamos las piezas en transito de este articulo en SAP

            'dtTransitoSAP = oSapMgr.Read_TraspasosPendientes(Today, Today, "", "S", "", oResultado.ArticuloID)


            dtView = New DataView(dtTransitoSAP, "", "", DataViewRowState.CurrentRows)

            '-------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 16/06/2015: Solo se Mostraran los bloqueados por ecommerce y si hay, si esta en la configuración.
            '-------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.BloqueaBajaCalidad = True Then
                dtBloqueados = defecMgr.GetBloqueadosECSiHay(oResultado.ArticuloID)
                dtBloqView = New DataView(dtBloqueados, "", "", DataViewRowState.CurrentRows)
                dsDataSource.Tables(0).Columns.Add("Bloqueados", GetType(Integer))
            End If
            Dim size As String = ""
            Dim desc As String = ""
            For Each registro As DataRow In dsDataSource.Tables(0).Rows
                Talla = CStr(registro!Número).Trim
                size = Talla
                desc = getDescription(strCentro)
                registro!Descripción = desc
                registro!Reserva = 0  '"NA"
                registro!Calidad = 0
                If IsNumeric(Talla) AndAlso InStr(Talla, ".5") <= 0 Then Talla = Talla & ".0"
                'dtView.RowFilter = "MATNR = '" & Me.ArticuloID.Text.Trim & "' And J_3ASIZE = '" & Talla.Trim & "'"
                'If dtView.Count > 0 Then
                '    For Each oRowV In dtView
                '        registro!Transito += oRowV!MENGE
                '    Next
                'End If
                If oConfigCierreFI.BloqueaBajaCalidad = True Then
                    dtBloqView.RowFilter = "CodArticulo='" & Me.ArticuloID.Text.Trim() & "' AND Talla='" & size.Trim() & "'"
                    If dtBloqView.Count > 0 Then
                        Dim bloqueo As Integer = 0, defectuoso As Integer
                        For Each oRowV In dtBloqView
                            bloqueo = CInt(registro("Bloqueados"))
                            defectuoso = CInt(registro("Defectuosos"))
                            bloqueo += CInt(oRowV!Bloqueados)
                            registro("Bloqueados") = bloqueo
                            registro("Defectuosos") = defectuoso - bloqueo
                        Next
                    End If
                End If
                tabla.ImportRow(registro)
            Next

            dsDataSource.Tables.Add(tabla.Copy)

            GridEX2.RootTable.Columns(5).Visible = False
            GridEX2.RootTable.Columns(11).Visible = False

            With GridEX2
                '.DataBindings.Clear()
                .SetDataBinding(dsDataSource, "Existencias2")
                '.RetrieveStructure()
                .Refresh()

            End With

            If (ebAlter1.Text <> "") Then
                AlterFlag = "Alter1"
                oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA1.Visible = False
                Me.For1.Visible = False
                If oResultado.HaveImageAlter = True Then
                    ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter1.Text = oResultado.Descripcion
                    ColorAlter1.Text = oResultado.Color
                    PrecioAlter1.Text = oResultado.Precio
                    Me.lblFotoNoDisponibleA1.Visible = False
                    Me.For1.Visible = False
                Else
                    ImAlter1.Image = Nothing
                    Me.lblFotoNoDisponibleA1.Visible = True
                    Me.For1.Visible = True
                End If
            Else
                Me.lblNoExistenteA1.Visible = True
                Me.For1.Visible = True
            End If

            If (ebAlter2.Text <> "") Then
                AlterFlag = "Alter2"
                oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA2.Visible = False
                Me.For2.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA2.Visible = False
                    ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter2.Text = oResultado.Descripcion
                    ColorAlter2.Text = oResultado.Color
                    PrecioAlter2.Text = oResultado.Precio
                    Me.For2.Visible = False
                Else
                    ImAlter2.Image = Nothing
                    Me.lblFotoNoDisponibleA2.Visible = True
                    Me.For2.Visible = True
                End If
            Else
                Me.lblNoExistenteA2.Visible = True
                Me.For2.Visible = True
            End If

            If (ebAlter3.Text <> "") Then
                AlterFlag = "Alter3"
                oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA3.Visible = False
                Me.For3.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA3.Visible = False
                    ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter3.Text = oResultado.Descripcion
                    ColorAlter3.Text = oResultado.Color
                    PrecioAlter3.Text = oResultado.Precio
                    Me.For3.Visible = False
                Else
                    ImAlter3.Image = Nothing
                    Me.lblFotoNoDisponibleA3.Visible = True
                    Me.For3.Visible = True
                End If
            Else
                Me.lblNoExistenteA3.Visible = True
                Me.For3.Visible = True
            End If
        Else  'NO SELECCIONO CONSULTA LOCAL
            '-------------------------------------------------------------------------
            ' Se selecciona consultar en otra tienda
            '-------------------------------------------------------------------------

            oAlmacen = oCatalogoAlmacenesMgr.Load(oSapMgr.Read_Centros) ' oAppContext.ApplicationConfiguration.Almacen)
            oConsulta = New ConsultaExistenciasLocal(oAppContext, oAppContext.ApplicationConfiguration.Almacen)

            oResultado = Nothing
            oResultado = oConsulta.Execute(ArticuloID.Text, oAlmacen.ID, True, True)


            ' Resultados de la consulta
            If (oResultado Is Nothing) Then
                MsgBox("El Articulo No existe", MsgBoxStyle.Exclamation, "DPTienda")
                Sm_TxtLimpiar()
                Exit Sub
            End If

            ArticuloID.Text = oResultado.ArticuloID
            Descripcion.Text = oResultado.Descripcion
            Proveedor.Text = oResultado.CodArtProv
            Color.Text = oCatalogoAlmacenesMgr.SeleccionaColor(Mid(oResultado.ArticuloID, 11, 1)) 'oResultado.Color
            Precio.Text = "$" & Format(oResultado.Precio, "Standard")
            Oferta.Text = Format(oResultado.Promocion, "$###,##0.00##")
            Descuento.Text = oResultado.Descuento & "%"
            Linea.Text = oResultado.Linea
            Familia.Text = oResultado.Familia
            Uso.Text = oResultado.Uso
            ebAlter1.Text = oResultado.CodAlt1
            ebAlter2.Text = oResultado.CodAlt2
            ebAlter3.Text = oResultado.CodAlt3
            Corrida.Text = oResultado.CodCorrida

            '-------------------------------------------------------------------------------------------
            ' MLVARGAS (02/09/2021) Comentado, método anterior para colocar imagen
            '--------------------------------------------------------------------------------------------
            'If File.Exists(Application.StartupPath & "\Fotos\" & oResultado.ArticuloID & ".JPG") Then
            '    FotoArticulo.Image = Image.FromFile(Application.StartupPath & "\Fotos\" & oResultado.ArticuloID & ".JPG")
            'Else
            '    FotoArticulo.Image = Nothing
            'End If
            '****************************Condiciones de Venta********************************
            Dim oCondicionVenta As New CondicionesVtaSAP
            oCondicionVenta.Jerarquia = oResultado.Jeraquia
            oCondicionVenta.CondMat = oResultado.CodMarca
            oCondicionVenta.Material = oResultado.ArticuloID
            If Not oAppContext.ApplicationConfiguration.Almacen = "053" Then
Cambio_053_2:
                oCondicionVenta.OficinaVtas = "T" & oAppContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0") 'oAppSAPConfig.OficinaVenta
                oCondicionVenta.ListPrec = "Z1"
                oCondicionVenta.CondPrec = "01"
            Else
                GoTo Cambio_053_2
                'oCondicionVenta.OficinaVtas = "C053"
                'oCondicionVenta.ListPrec = "C1"
                'oCondicionVenta.CondPrec = "01"
            End If
            oFacturaMgr.GetCondicionVenta(oCondicionVenta)
            Dim dblDesc As Double = 0
            Dim dblPrecIva As Double = 0

            If oCondicionVenta.DescPorcentaje > 0 Then
                'Porcentaje
                dblPrecIva = (oResultado.Precio)
                dblDesc = dblPrecIva * (oCondicionVenta.DescPorcentaje / 100)
                Oferta.Text = "$" & Format(dblPrecIva - dblDesc, "Standard")
                Descuento.Text = Math.Round(oCondicionVenta.DescPorcentaje, 2) & "%"
            Else
                If oCondicionVenta.Descmonto > 0 Then
                    'Monto descuento
                    Oferta.Text = "$" & Format(oResultado.Precio - oCondicionVenta.Descmonto, "Standard")
                    Descuento.Text = "$" & Format(Math.Round(oCondicionVenta.Descmonto, 2), "Standard")
                End If
            End If
            '****************************Condiciones de Venta********************************

            '************Emanuel Vega DPORTENIS S.A.*********18/12/2005**************
            '------------------------------------------------------------------------------------------------------------------------
            'Validacion si es busqueda por esquema SiHay
            '------------------------------------------------------------------------------------------------------------------------

            Dim defecMgr As New DefectuososManager(oAppContext, oAppSAPConfig)
            Dim dtBloqueados As DataTable = Nothing
            Dim dtBloqView As DataView

            '-------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 16/06/2015: Solo se Mostraran los bloqueados por ecommerce y si hay, si esta en la configuración.
            '-------------------------------------------------------------------------------------------------------------------
            If Not oSapMgr.SAPApplicationConfig.SiHay Then
                If oConfigCierreFI.BloqueaBajaCalidad = True Then
                    dtBloqueados = defecMgr.GetBloqueadosECSiHay(oResultado.ArticuloID)
                    dtBloqView = New DataView(dtBloqueados, "", "", DataViewRowState.CurrentRows)
                End If
            End If

            ' CONSULTA APLICACIÓN SIHAY
            If ModOrigen.Trim.ToUpper = "SH" Then
                '-------------------------------------------------------------------------------------------------------------------
                'MLVARGAS 13/08/2021: Si se encuentra activo el check de Si Hay de SAP CAR se realiza la consulta con dicho servicio
                '-------------------------------------------------------------------------------------------------------------------
                If oSapMgr.SAPApplicationConfig.SiHay Then
                    Dim dtArt As DataTable
                    Dim strCentro As String = String.Empty
                    If UiComboBox1.Text = "Local" Then
                        strCentro = oSapMgr.Read_Centros
                        ' strCentro = 2132
                    End If

                    Dim source As DataTable = CreateDataTableSiHay()

                    '-------------------------------------------------------------------------------------------------------------------------
                    'MLVARGAS 13/04/2022: Si la búsqueda es local se utilizara el servicio de SAPCAR Igual a la consulta de inventario normal
                    '-------------------------------------------------------------------------------------------------------------------------

                    If UiComboBox1.Text = "Local" Then
                        dtArt = ConsultaExistenciasSAPCAR("General", list, strCentro, String.Empty)
                    Else
                        dtArt = ConsultaExistenciasSAPCAR("SI_HAY", list, strCentro, String.Empty)
                    End If


                    If Not dtArt Is Nothing Then
                        Dim count As Integer = dtArt.Rows.Count
                        Dim talla As String = ""
                        Dim desc As String = ""
                        For Each row As DataRow In dtArt.Rows
                            Dim fila As DataRow = source.NewRow
                            talla = CStr(row("número"))
                            fila("CodArticulo") = CStr(row!codArticulo)
                            fila("Descripción") = getDescription(row!Almacén)
                            fila("Almacén") = CStr(row!Almacén)
                            fila("Número") = CStr(row!Número)
                            fila("Libre") = CInt(row!Libre)
                            fila("Prioridad") = CInt(row!Almacén)
                            fila("Consignacion") = CInt(row!Consignacion)
                            fila("Apartados") = CInt(row!Apartados)
                            fila("Transito") = CInt(row!Transito)
                            fila("Defectuosos") = CInt(row!Defectuosos)
                            fila("Reserva") = CInt(row!Reserva)
                            fila("Calidad") = CInt(row!Calidad)
                            ' MLVARGAS (04/08/2022) : Si la cantidad en baja calidad es mayor a la cantidad libre, se pone la cantidad de baja calidad igual a la cantidad libre
                            If CInt(row!Calidad) > CInt(row!STK_LIBRE_UTILIZACION) Then
                                fila("Calidad") = CInt(row!STK_LIBRE_UTILIZACION)
                            End If
                            source.Rows.Add(fila)
                        Next
                        source.AcceptChanges()

                    End If


                    ' Agregar articulos faltantes si es local

                    If UiComboBox1.Text = "Local" Then
                        'AgregaArticulosSiHay(source, dtTallas)
                        Dim ArticuloID As String = Me.ArticuloID.Text
                        Dim dtProductos As DataTable = oCatalogoArticulosMgr.LoadIntoByCodPadre(ArticuloID.Substring(0, ArticuloID.Length - 3))
                        Dim dtView As DataView
                        Dim dtViewTalla As DataView

                        If Not dtProductos Is Nothing Then
                            For Each oRow As DataRow In dtProductos.Rows

                                dtView = New DataView(source, "", "", DataViewRowState.CurrentRows)
                                dtView.RowFilter = "CodArticulo = '" & oRow!CodArticulo & "'"
                                If dtView.Count = 0 Then
                                    'Agregar el artículo al listado

                                    Dim codigo As String = oRow!CodArticulo

                                    dtViewTalla = New DataView(dtTallas, "", "", DataViewRowState.CurrentRows)
                                    dtViewTalla.RowFilter = "codArticulo = '" & oRow!CodArticulo & "'"

                                    If dtViewTalla.Count > 0 Then
                                        Dim renDatos As DataRow = source.NewRow
                                        Dim oRowView As DataRowView = dtViewTalla.Item(0)

                                        renDatos!Almacén = strCentro
                                        renDatos!CodArticulo = oRow!CodArticulo
                                        renDatos!Descripción = getDescription(strCentro)
                                        renDatos!Número = oRowView!Número
                                        renDatos!Libre = 0
                                        renDatos!Prioridad = strCentro
                                        renDatos!Consignacion = 0
                                        renDatos!Apartados = 0
                                        renDatos!Transito = 0
                                        renDatos!Defectuosos = 0
                                        renDatos!Reserva = 0
                                        renDatos!Calidad = 0
                                        renDatos!Bloqueados = 0

                                        source.Rows.Add(renDatos)
                                        source.AcceptChanges()
                                    End If
                                End If
                            Next
                        End If
                    End If


                    Dim view As New DataView(source)
                    view.Sort = "Prioridad"
                    With GridEX2
                        .DataSource = Nothing
                        .DataSource = view
                        .Refresh()
                    End With
                Else  'SI HAY SIN SAPCAR
                    ' Servicio de consulta de existencias a SAP ECC
                    Dim dsDataSource As DataSet
                    Dim dtArticulos As DataTable = GetDataTableArticulo(ArticuloID.Text.Trim())
                    dsDataSource = oSapMgr.ZSH_DISPONIBILIDAD(dtArticulos)
                    If Not dsDataSource Is Nothing Then
                        Dim count As Integer = dsDataSource.Tables("T_DISPONIBLES").Rows.Count
                        Dim source As DataTable = CreateDataTableSiHay()
                        Dim Talla As String = ""
                        For Each row As DataRow In dsDataSource.Tables("T_DISPONIBLES").Rows
                            Dim fila As DataRow = source.NewRow()
                            Talla = CStr(row("Numero"))
                            fila("CodArticulo") = ArticuloID.Text.Trim()
                            fila("Almacén") = CStr(row!WERKS)
                            fila("Descripción") = getDescription(row!WERKS)
                            fila("Número") = CStr(row!TALLA)
                            fila("Libre") = CInt(row!CANTIDAD)
                            fila("Prioridad") = CInt(row!PRIORIDAD)
                            fila("Apartados") = CInt(row!APARTADOS)
                            fila("Transito") = CInt(row!TRANSITO)
                            fila("Defectuosos") = CInt(row!DEFECTUOSOS)
                            fila("Consignacion") = 0
                            fila("Reserva") = 0 '"NA"
                            fila("Calidad") = 0
                            If oConfigCierreFI.BloqueaBajaCalidad = True Then
                                dtBloqView.RowFilter = "CodArticulo='" & Me.ArticuloID.Text.Trim() & "'" ' AND Talla='" & Talla.Trim() & "'"
                                If dtBloqView.Count > 0 Then
                                    Dim bloqueo As Integer = 0
                                    For Each oRowV As DataRow In dtBloqView
                                        bloqueo = CInt(row("Bloqueados"))
                                        bloqueo += CInt(oRowV!Bloqueados)
                                        row("Bloqueados") = bloqueo
                                    Next
                                End If
                            End If
                            source.Rows.Add(fila)
                        Next
                        Dim view As New DataView(source)
                        view.Sort = "Prioridad"


                        With GridEX2
                            .DataSource = Nothing
                            .DataSource = view
                            .Refresh()
                        End With
                    End If
                End If

            Else  'MODULO DE ORIGEN INVENTARIO
                'Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim dsDataSourceExistenciasSAP As DataTable

                If UiComboBox1.Text = "TODOS" Then
                    If oSapMgr.SAPApplicationConfig.Inventario Then
                        dsDataSourceExistenciasSAP = ConsultaExistenciasSAPCAR("General", list, String.Empty, String.Empty)
                    Else
                        dsDataSourceExistenciasSAP = oSapMgr.Read_ExistenciasSAP(ArticuloID.Text, "", "S")
                    End If

                Else
                    If oSapMgr.SAPApplicationConfig.Inventario Then
                        ' CONSULTAR EL INVENTARIO A SAP CAR 

                        If UiComboBox1.Text = "Local" Then
                            centro = oSapMgr.Read_Centros
                        Else
                            If UiComboBox1.Text = "Mi Ciudad" Then
                                centro = String.Empty
                                ciudad = strCiudad
                            Else
                                centro = oCatalogoAlmacenesMgr.Loadtienda(UiComboBox1.Text)
                            End If
                        End If

                        dsDataSourceExistenciasSAP = ConsultaExistenciasSAPCAR("General", list, centro, ciudad)


                    Else
                        ' CONSUTAR EL INVERTARIO A SAP (PROCESO NORMAL)
                        Dim opc As String = "N"
                        If UiComboBox1.Text = "Mi Ciudad" Then
                            opc = "S"
                        End If

                        Dim tienda As String = oCatalogoAlmacenesMgr.Loadtienda(UiComboBox1.Text)
                        If tienda = String.Empty Then tienda = oSapMgr.Read_Centros

                        If UiComboBox1.Text = "Mi Ciudad" Then
                            dsDataSourceExistenciasSAP = oSapMgr.Read_ExistenciasSAP(ArticuloID.Text, tienda, "S")
                        Else
                            dsDataSourceExistenciasSAP = oSapMgr.Read_ExistenciasSAP(ArticuloID.Text, tienda, "N")
                        End If
                        '       dsDataSourceExistenciasSAP = oSapMgr.Read_ExistenciasSAP(ArticuloID.Text, tienda, opc)

                        '-----------------------------------------------------------------------------------------------------------
                        ' MLVARGAS (24.09.2021) Si se seleccionó "Mi Ciudad" hay que filtrar los datos de la respuesta
                        '-----------------------------------------------------------------------------------------------------------
                        If opc = "S" Then
                            Dim dsCentros As DataSet = oCatalogoAlmacenesMgr.LoadCiudad(strCiudad)
                            Dim strTiendas As String = String.Empty
                            If dsCentros.Tables("CatalogoAlmacenes").Rows.Count > 0 Then
                                For Each row As DataRow In dsCentros.Tables("CatalogoAlmacenes").Rows
                                    strTiendas += "'" & row("CodAlmacen") & "',"

                                Next
                                strTiendas = "(" & strTiendas.Substring(0, strTiendas.Length - 1) & ")"
                                Dim dtView As DataView
                                dtView = New DataView(dsDataSourceExistenciasSAP, "", "", DataViewRowState.CurrentRows)
                                dtView.RowFilter = "Almacén in " & strTiendas & ""

                                Dim dTable As DataTable
                                dTable = dtView.ToTable
                                dsDataSourceExistenciasSAP.Clear()
                                dsDataSourceExistenciasSAP = dTable.Copy

                            End If
                        End If
                    End If
                End If
                '**********Validamos que solo el centro Z001 se muestre*****************************

                Dim dtTemp As DataTable

                If Not dsDataSourceExistenciasSAP Is Nothing AndAlso dsDataSourceExistenciasSAP.Rows.Count > 0 Then
                    dsDataSourceExistenciasSAP.Columns.Add("Descripción", GetType(String))

                    If oConfigCierreFI.BloqueaBajaCalidad = True Then
                        dsDataSourceExistenciasSAP.Columns.Add("Bloqueados", GetType(Integer))
                    End If

                    dtTemp = dsDataSourceExistenciasSAP.Clone

                    Dim Talla As String = ""
                    Dim desc As String = String.Empty
                    For Each oRowV As DataRow In dsDataSourceExistenciasSAP.Rows
                        Talla = CStr(oRowV("Número"))
                        If centro.Length > 0 Then
                            desc = getDescription(centro)
                        ElseIf UiComboBox1.Text <> "Mi Ciudad" Then
                            desc = getDescription(oCatalogoAlmacenesMgr.Loadtienda(UiComboBox1.Text))
                        End If

                        If UiComboBox1.Text = "TODOS" Or UiComboBox1.Text = "Mi Ciudad" Or UiComboBox1.Text = "Local" Then
                            desc = getDescription(oRowV!Almacén)
                        End If

                        oRowV("Descripción") = desc

                        If CStr(oRowV!Almacén).Trim.ToUpper.Substring(0, 1) <> "Z" OrElse CStr(oRowV!Almacén).Trim.ToUpper = "Z001" Then
                            If oConfigCierreFI.BloqueaBajaCalidad = True Then
                                dtBloqView.RowFilter = "CodArticulo='" & Me.ArticuloID.Text.Trim() & "' AND Talla='" & Talla.Trim() & "'"
                                If dtBloqView.Count > 0 Then
                                    Dim bloqueo As Integer = 0
                                    For Each fila As DataRow In dtBloqView
                                        bloqueo = CInt(oRowV("Bloqueados"))
                                        bloqueo += CInt(fila!Bloqueados)
                                        oRowV("Bloqueados") = bloqueo
                                    Next
                                End If
                            End If
                            'dtTemp.ImportRow(oRowV)
                        End If
                        dtTemp.ImportRow(oRowV)
                    Next
                    dtTemp.AcceptChanges()

                End If
                '-----------------------------------------------------------------------------------------------------------------------
                ' MLVARGAS (11/04/2022) Si esta activo SAPCAR y la consulta es local se agregan los productos faltantes de la familia
                '-----------------------------------------------------------------------------------------------------------------------

                If dtTemp Is Nothing Then

                    dtTemp = dtTallas.Clone
                    dtTemp.Columns(5).ColumnName = "Almacén"
                    dtTemp.Columns(11).ColumnName = "codArticulo"
                    dtTemp.Columns(17).ColumnName = "Número"
                    dtTemp.Columns(24).ColumnName = "Apartados"
                    dtTemp.Columns(25).ColumnName = "Defectuosos"
                    dtTemp.Columns(26).ColumnName = "Transito"
                    dtTemp.Columns(27).ColumnName = "Consignacion"
                    dtTemp.Columns(29).ColumnName = "Calidad"
                    dtTemp.Columns(30).ColumnName = "Reserva"
                    dtTemp.Columns(31).ColumnName = "Libre"
                    dtTemp.Columns.Add("Descripción", GetType(String))
                    dtTemp.Columns.Add("Bloqueados", GetType(Integer))
                    dtTemp.AcceptChanges()

                End If


                If UiComboBox1.Text = "Local" Then

                    If oSapMgr.SAPApplicationConfig.Inventario Then

                        Dim dtView As DataView
                        Dim dtViewTalla As DataView
                        Dim ArticuloId As String = Me.ArticuloID.Text
                        Dim desc As String = String.Empty

                        If centro.Length > 0 Then
                            desc = getDescription(centro)
                        End If


                        Dim dtProductos As DataTable = oCatalogoArticulosMgr.LoadIntoByCodPadre(ArticuloId.Substring(0, ArticuloId.Length - 3))
                        If Not dtProductos Is Nothing Then
                            For Each oRow As DataRow In dtProductos.Rows

                                dtView = New DataView(dtTemp, "", "", DataViewRowState.CurrentRows)
                                dtView.RowFilter = "CodArticulo = '" & oRow!CodArticulo & "'"
                                If dtView.Count = 0 Then

                                    dtViewTalla = New DataView(dtTallas, "", "", DataViewRowState.CurrentRows)
                                    dtViewTalla.RowFilter = "codArticulo = '" & oRow!CodArticulo & "'"

                                    If dtViewTalla.Count > 0 Then

                                        'Agregar el artículo al listado
                                        Dim oRowView As DataRowView = dtViewTalla.Item(0)
                                        Dim renDatos As DataRow = dtTemp.NewRow

                                        'For i As Integer = 0 To dtTemp.Columns.Count - 1
                                        '    renDatos.Item(i) = dtTemp.Rows(0).Item(i)
                                        'Next

                                        renDatos!Almacén = centro
                                        renDatos!CodArticulo = oRow!CodArticulo
                                        renDatos!Descripcion = oRow!Descripcion
                                        renDatos!Descripción = desc
                                        renDatos!Número = oRowView!Número
                                        renDatos!Apartados = 0
                                        renDatos!Defectuosos = 0
                                        renDatos!Transito = 0
                                        renDatos!Consignacion = 0
                                        renDatos!Calidad = 0
                                        renDatos!Reserva = 0
                                        renDatos!Libre = 0
                                        dtTemp.Rows.Add(renDatos)
                                        dtTemp.AcceptChanges()

                                    End If

                                End If
                            Next

                        End If
                    End If
                    'End If


                    dsDataSourceExistenciasSAP.Clear()
                    dsDataSourceExistenciasSAP = dtTemp.Copy


                End If

                '-------------------------------------------------------------------------------------------
                ' MLVARGAS (08/09/2021) Acomodar los datos para que los tome como numéricos y pueda sumar
                '-------------------------------------------------------------------------------------------
                Dim dsDataSource As New DataSet
                Dim tabla As DataTable = GetTable(dsDataSourceExistenciasSAP)
                dsDataSource.Tables.Add(tabla.Copy)

                With GridEX2
                    .SetDataBinding(dsDataSource, "Existencias2")
                    .Refresh()
                End With


            End If
            'Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            'Dim dsDataSourceExistenciasSAP As DataTable

            'If UiComboBox1.Text = "TODOS" Then
            '    dsDataSourceExistenciasSAP = oSap.Read_ExistenciasSAP(ArticuloID.Text, "", "S")
            'Else
            '    dsDataSourceExistenciasSAP = oSap.Read_ExistenciasSAP(ArticuloID.Text, oCatalogoAlmacenesMgr.Loadtienda(UiComboBox1.Text), "N")
            'End If
            ''**********Validamos que solo el centro Z001 se muestre*****************************
            'If Not dsDataSourceExistenciasSAP Is Nothing AndAlso dsDataSourceExistenciasSAP.Rows.Count > 0 Then
            '    Dim dtTemp As DataTable = dsDataSourceExistenciasSAP.Clone

            '    For Each oRowV As DataRow In dsDataSourceExistenciasSAP.Rows
            '        If CStr(oRowV!Almacén).Trim.ToUpper.Substring(0, 1) <> "Z" OrElse CStr(oRowV!Almacén).Trim.ToUpper = "Z001" Then
            '            dtTemp.ImportRow(oRowV)
            '        End If
            '    Next
            '    dtTemp.AcceptChanges()
            '    dsDataSourceExistenciasSAP.Clear()
            '    dsDataSourceExistenciasSAP = dtTemp.Copy
            'End If

            ''DGexistencias.DataSource = dsDataSourceExistenciasSAP
            'With GridEX2
            '    .DataSource = Nothing
            '    .DataSource = dsDataSourceExistenciasSAP
            '    .Refresh()
            'End With

            If (ebAlter1.Text <> "") Then
                AlterFlag = "Alter1"
                oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA1.Visible = False
                Me.For1.Visible = False
                If oResultado.HaveImageAlter = True Then
                    ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter1.Text = oResultado.Descripcion
                    ColorAlter1.Text = oResultado.Color
                    PrecioAlter1.Text = oResultado.Precio
                    Me.lblFotoNoDisponibleA1.Visible = False
                    Me.For1.Visible = False
                Else : ImAlter1.Image = Nothing
                    Me.lblFotoNoDisponibleA1.Visible = True
                    Me.For1.Visible = True
                End If
            Else
                Me.lblNoExistenteA1.Visible = True
                Me.For1.Visible = True
            End If

            If (ebAlter2.Text <> "") Then
                AlterFlag = "Alter2"
                oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA2.Visible = False
                Me.For2.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA2.Visible = False
                    ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter2.Text = oResultado.Descripcion
                    ColorAlter2.Text = oResultado.Color
                    PrecioAlter2.Text = oResultado.Precio
                    Me.For2.Visible = False
                Else
                    ImAlter2.Image = Nothing
                    Me.lblFotoNoDisponibleA2.Visible = True
                    Me.For2.Visible = True
                End If
            Else
                Me.lblNoExistenteA2.Visible = True
                Me.For2.Visible = True
            End If

            If (ebAlter3.Text <> "") Then
                AlterFlag = "Alter3"
                oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA3.Visible = False
                Me.For3.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA3.Visible = False
                    ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter3.Text = oResultado.Descripcion
                    ColorAlter3.Text = oResultado.Color
                    PrecioAlter3.Text = oResultado.Precio
                    Me.For3.Visible = False
                Else
                    ImAlter3.Image = Nothing
                    Me.lblFotoNoDisponibleA3.Visible = True
                    Me.For3.Visible = True
                End If
            Else
                Me.lblNoExistenteA3.Visible = True
                Me.For3.Visible = True
            End If


        End If

        Cursor.Current = Cursors.Default
        ArticuloID.Focus()
    End Sub


    Private Sub AgregaArticulosSiHay(ByRef source As DataTable, ByVal dtTallas As DataTable)
        Dim oCatalogoArticulosMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim dtView As DataView
        Dim dtViewTalla As DataView
        Dim ArticuloId As String = Me.ArticuloID.Text
        Dim strCentro As String
        Dim i As Integer = 0

        strCentro = oSapMgr.Read_Centros
        ' strCentro = 2132



        Dim dtProductos As DataTable = oCatalogoArticulosMgr.LoadIntoByCodPadre(ArticuloId.Substring(0, ArticuloId.Length - 3))
        If Not dtProductos Is Nothing Then
            For Each oRow As DataRow In dtProductos.Rows

                dtView = New DataView(source, "", "", DataViewRowState.CurrentRows)
                dtView.RowFilter = "CodArticulo = '" & oRow!CodArticulo & "'"
                If dtView.Count = 0 Then
                    'Agregar el artículo al listado

                    Dim codigo As String = oRow!CodArticulo

                    dtViewTalla = New DataView(dtTallas, "", "", DataViewRowState.CurrentRows)
                    dtViewTalla.RowFilter = "codArticulo = '" & oRow!CodArticulo & "'"

                    If dtViewTalla.Count > 0 Then
                        Dim renDatos As DataRow = source.NewRow
                        Dim oRowView As DataRowView = dtViewTalla.Item(0)

                        renDatos!Almacén = strCentro
                        renDatos!CodArticulo = oRow!CodArticulo
                        renDatos!Descripción = getDescription(strCentro)
                        renDatos!Número = oRowView!Número
                        renDatos!Libre = 0
                        renDatos!Prioridad = strCentro
                        renDatos!Consignacion = 0
                        renDatos!Apartados = 0
                        renDatos!Transito = 0
                        renDatos!Defectuosos = 0
                        renDatos!Reserva = 0
                        renDatos!Calidad = 0
                        renDatos!Bloqueados = 0

                        source.Rows.Add(renDatos)
                        source.AcceptChanges()
                        i += 1
                    End If
                End If
            Next
            MsgBox("Articulos agregados en cero: " & i & " total: " & source.Rows.Count, MsgBoxStyle.Exclamation, "MLVARGAS")
        End If

    End Sub



    Private Sub frmConsultaExistencias_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub ArticuloID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ArticuloID.Validating

        If Trim(ArticuloID.Text) <> String.Empty Then

            ArticuloID.Text = LoadCodigo(ArticuloID.Text)

            If ArticuloID.Text = String.Empty Then

                ArticuloID.Focus()

            End If

        End If

    End Sub
    Private Sub UiComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UiComboBox1.SelectedIndexChanged
        'If FacturacionSiHay <> -1 Then
        If ModOrigen.Trim.ToUpper = "SH" AndAlso Not UiComboBox1.SelectedItem Is Nothing Then
            If CStr(UiComboBox1.SelectedItem.Text) = "Local" Then
                GridEX2.RootTable.Columns(3).Visible = True
                GridEX2.RootTable.Columns(4).Visible = True
                GridEX2.RootTable.Columns(5).Visible = True
                GridEX2.DataSource = Nothing
                
            Else
                'GridEX2.RootTable.Columns(3).Visible = False
                ' GridEX2.RootTable.Columns(4).Visible = False
                GridEX2.RootTable.Columns(5).Visible = False
                GridEX2.DataSource = Nothing
               
            End If
        End If

        If Not UiComboBox1.SelectedItem Is Nothing Then
            If CStr(UiComboBox1.SelectedItem.Text) = "Local" Then
                chkLocal.Checked = False
                chkLocal.Enabled = True
            Else
                chkLocal.Checked = False
                chkLocal.Enabled = False
            End If
        End If


        GridEX2.RootTable.Columns(5).Visible = False
        GridEX2.RootTable.Columns(11).Visible = False

        If Not oSapMgr Is Nothing Then
            If oSapMgr.SAPApplicationConfig.SiHay AndAlso ModOrigen.Trim.ToUpper = "SH" Then
                GridEX2.RootTable.Columns(5).Visible = True
                GridEX2.RootTable.Columns(11).Visible = True
            End If

            If oSapMgr.SAPApplicationConfig.Inventario AndAlso ModOrigen.Trim.ToUpper <> "SH" Then
                GridEX2.RootTable.Columns(5).Visible = True
                GridEX2.RootTable.Columns(11).Visible = True
            End If
        End If


    End Sub
#Region "Facturacion SiHay"

    Private Function GetDataTableArticulo(ByVal CodArticulo As String) As DataTable
        Dim dtArticulos As New DataTable("Articulos")
        dtArticulos.Columns.Add("CodArticulo", GetType(String))
        dtArticulos.Columns.Add("Numero", GetType(String))
        dtArticulos.Columns.Add("Cantidad", GetType(Integer))
        dtArticulos.AcceptChanges()
        Dim row As DataRow = dtArticulos.NewRow()
        row("CodArticulo") = CodArticulo
        row("Numero") = ""
        row("Cantidad") = 0
        dtArticulos.Rows.Add(row)
        Return dtArticulos
    End Function

    Private Sub ObtenerImagen(ByVal urlImage As String)
        Dim strUrlImage As String = String.Empty

        '-----------------------------------------------------
        If String.IsNullOrEmpty(urlImage) = True Then
            Throw New ArgumentException("La ubicación de la imagen es una cadena vacia o nula", "Imagen")
        End If

        Try

            '------------------------------------------------------------------------------------------
            ' Si el nombre de la imagen lleva el texto
            ' [file:///]  QUITARLO porque genera errores 
            If urlImage.IndexOf("file:///", 0) = 0 Then
                urlImage = urlImage.Substring(8)
            End If
            '--------------------------------------------------------

            '------------------------------------------------------------------------------------------
            ' MLVARGAS (22.09.2021) Ver si es necesario reemplazar texto de la URL de la imagen
            '------------------------------------------------------------------------------------------
            strUrlImage = urlImage
            If oSapMgr.SAPApplicationConfig.BuscarCAR.Length > 0 Then
                If urlImage.IndexOf(oSapMgr.SAPApplicationConfig.BuscarCAR) >= 0 Then
                    strUrlImage = urlImage.Replace(oSapMgr.SAPApplicationConfig.BuscarCAR, oSapMgr.SAPApplicationConfig.ReemplazarCAR)
                End If
            End If

            FotoArticulo.ImageLocation = strUrlImage
            ' carga la imagen de forma síncrona
            FotoArticulo.Load()

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al tratar de cargar la imagen: " & strUrlImage)
            'Throw ex            
        End Try
    End Sub

    Private Function CreateDataTableSiHay() As DataTable
        Dim table As New DataTable
        table.Columns.Add("CodArticulo", GetType(String))
        table.Columns.Add("Descripción", GetType(String))
        table.Columns.Add("Almacén", GetType(String))
        table.Columns.Add("Número", GetType(String))
        table.Columns.Add("Libre", GetType(Integer))
        table.Columns.Add("Prioridad", GetType(Integer))
        table.Columns.Add("Consignacion", GetType(Integer))
        table.Columns.Add("Apartados", GetType(Integer))
        table.Columns.Add("Transito", GetType(Integer))
        table.Columns.Add("Defectuosos", GetType(Integer))
        table.Columns.Add("Reserva", GetType(Integer))
        table.Columns.Add("Calidad", GetType(Integer))
        If oConfigCierreFI.BloqueaBajaCalidad = True Then
            table.Columns.Add("Bloqueados", GetType(Integer))
            'Dim idColumn As GridEXColumn = GridEX2.RootTable.Columns("Bloqueados")
            'idColumn.Visible = True
        End If
        table.AcceptChanges()
        Return table
    End Function
#End Region

    Private Function ConcatenarMateriales(ByVal oList As List(Of String)) As String
        Dim materiales As String = String.Empty

        If oList.Count > 1 Then
            For i As Integer = 0 To oList.Count - 1
                materiales += oList.Item(i) + ","
            Next i
            materiales = "(" & materiales.Substring(0, materiales.Length - 1) & ")"
        Else
            materiales = oList.Item(0)
        End If

        Return materiales
    End Function

    Private Sub GetImage(ByVal dtResult As DataTable)

        For Each row As DataRow In dtResult.Rows
            strUrl = row.Item("URL")
            If strUrl.Length > 0 Then
                Exit For
            End If
        Next row

        If strUrl.Length > 0 Then
            ObtenerImagen(strUrl)
        End If
    End Sub

    Private Function ConsultaTallaArticulos(ByVal list As List(Of String)) As DataTable
        Dim dtDatos As DataTable
        Dim dictionary As New Dictionary(Of String, Object)

        dictionary.Add("request", "buscartalla")
        dictionary.Add("materiales", list)
        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRetail As ProcesosRetail
        oRetail = New ProcesosRetail("http://portalqas.grupodp.com.mx/newportal/modulos/blank_rest_data_master", "POST")

        dtDatos = oRetail.GetTallas(dictionary)

        Return dtDatos

    End Function


    Private Function ConsultaExistenciasSAPCAR(ByVal tipo As String, ByVal articulos As List(Of String), ByVal centro As String, ByVal ciudad As String, Optional showImage As Boolean = True) As DataTable
        Dim dtDatos As DataTable
        Dim htParams As Hashtable = New Hashtable

        htParams.Add("ClienteSAP", oSapMgr.SAPApplicationConfig.ClienteCAR)
        htParams.Add("Material", ConcatenarMateriales(articulos))
        If centro.Length > 0 Then
            htParams.Add("Centro", centro)
        End If
        If ciudad.Length > 0 Then
            htParams.Add("Ciudad", ciudad)
        End If
        If tipo = "SI_HAY" Then
            htParams.Add("IDCanal", oSapMgr.SAPApplicationConfig.IdCanalCAR)
            htParams.Add("Version", oSapMgr.SAPApplicationConfig.VersionCAR)
        End If

        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRetail As ProcesosRetail

        If tipo = "General" Then
            oRetail = New ProcesosRetail("/sap/opu/odata/sap/ZVIEW_STOCK_POS_SRV/POSStkSet", "GET")
        Else
            oRetail = New ProcesosRetail("/sap/opu/odata/sap/ZVIEW_STOCK_POS_SRV/VersionStkSet", "GET")
        End If

        dtDatos = oRetail.SapCarInventario(htParams)

        'Modificar el nombre de las columnas para poder asignarlas al grid existente
        If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
            dtDatos.Columns(5).ColumnName = "Almacén"
            dtDatos.Columns(11).ColumnName = "codArticulo"
            dtDatos.Columns(17).ColumnName = "Número"
            dtDatos.Columns(24).ColumnName = "Apartados"
            dtDatos.Columns(25).ColumnName = "Defectuosos"
            dtDatos.Columns(26).ColumnName = "Transito"
            dtDatos.Columns(27).ColumnName = "Consignacion"
            dtDatos.Columns(29).ColumnName = "Calidad"
            dtDatos.Columns(30).ColumnName = "Reserva"
            dtDatos.Columns(31).ColumnName = "Libre"   'COLUMNA  STK_DISPONIBLE  
            dtDatos.AcceptChanges()
            If showImage AndAlso UiComboBox1.Text <> "Local" Then
                GetImage(dtDatos)
            End If

        End If

        Return dtDatos
    End Function

    Private Function getDescription(strCentro As String) As String
        Dim oAlmacen As ApplicationUnits.CatalogoAlmacenes.Almacen
        Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
        Dim descripcion As String = String.Empty

        oAlmacen = oCatalogoAlmacenesMgr.Load(strCentro)
        descripcion = oAlmacen.Descripcion

        Return descripcion
    End Function

    Private Function GetTable(ByVal dsDataSourceExistenciasSAP As DataTable) As DataTable
        Dim tabla As DataTable
        tabla = LoadTablaLocal()
        Dim dr As DataRow

        For Each registro As DataRow In dsDataSourceExistenciasSAP.Rows
            dr = tabla.NewRow()
            dr("Almacén") = registro!Almacén
            dr("Descripción") = registro!Descripción
            dr("Número") = registro!Número
            If (registro!Libre).ToString.Length > 0 Then
                dr("Libre") = CInt(registro!Libre)
            Else
                dr("Libre") = CInt(0.0)
            End If

            If dsDataSourceExistenciasSAP.Columns.Contains("Bloqueados") Then
                If (registro!Bloqueados).ToString.Length > 0 Then
                    dr("Bloqueados") = registro!Bloqueados
                Else
                    dr("Bloqueados") = CInt(0.0)
                End If
            End If

            If (registro!Apartados).ToString.Length > 0 Then
                dr("Apartados") = CInt(registro!Apartados)
            Else
                dr("Apartados") = CInt(0.0)
            End If

            If (registro!Defectuosos).ToString.Length > 0 Then
                dr("Defectuosos") = CInt(registro!Defectuosos)
            Else
                dr("Defectuosos") = CInt(0.0)
            End If
            If (registro!Transito).ToString.Length > 0 Then
                dr("Transito") = CInt(registro!Transito)
            Else
                dr("Transito") = CInt(0.0)
            End If
            If dsDataSourceExistenciasSAP.Columns.Contains("Consignacion") Then
                If (registro!Consignacion).ToString.Length > 0 Then
                    dr("Consignacion") = CInt(registro!Consignacion)
                Else
                    dr("Consignacion") = CInt(0.0)
                End If
            End If

            dr("CodArticulo") = registro!CodArticulo
            If dsDataSourceExistenciasSAP.Columns.Contains("Reserva") Then
                If (registro!Reserva).ToString.Length > 0 Then
                    dr("Reserva") = CInt(registro!Reserva)
                Else
                    dr("Reserva") = CInt(0.0)
                End If
            End If

            If dsDataSourceExistenciasSAP.Columns.Contains("Calidad") Then
                If (registro!Calidad).ToString.Length > 0 Then
                    dr("Calidad") = CInt(registro!Calidad)

                    If (registro!STK_LIBRE_UTILIZACION).ToString.Length > 0 Then
                        If CInt(registro!Calidad) > CInt(registro!STK_LIBRE_UTILIZACION) Then
                            dr("Calidad") = CInt(registro!STK_LIBRE_UTILIZACION)
                        End If
                    End If

                Else
                    dr("Calidad") = CInt(0.0)
                End If
            End If

            tabla.Rows.Add(dr)
        Next
        Return tabla
    End Function



End Class
