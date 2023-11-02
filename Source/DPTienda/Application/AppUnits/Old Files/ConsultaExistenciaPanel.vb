Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.ConsultaExistencias
Imports DportenisPro.DPTienda.ApplicationUnits.ConsultaExistencias.ConsultaExistenciasAbstract
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class ConsultaExistenciaPanel
    Inherits System.Windows.Forms.UserControl

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
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
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents NicePanel2 As PureComponents.NicePanel.NicePanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnActionExecute As System.Windows.Forms.Button
    Friend WithEvents UiComboBox1 As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Oferta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Descuento As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Uso As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Familia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Linea As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ArticuloID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Descripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Precio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Color As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents FotoArticulo As System.Windows.Forms.PictureBox
    Friend WithEvents ebAlter1 As System.Windows.Forms.TextBox
    Friend WithEvents ebAlter2 As System.Windows.Forms.TextBox
    Friend WithEvents ebAlter3 As System.Windows.Forms.TextBox
    Friend WithEvents ImAlter2 As System.Windows.Forms.PictureBox
    Friend WithEvents ImAlter1 As System.Windows.Forms.PictureBox
    Friend WithEvents ImAlter3 As System.Windows.Forms.PictureBox
    Friend WithEvents PrecioAlter1 As System.Windows.Forms.TextBox
    Friend WithEvents PrecioAlter2 As System.Windows.Forms.TextBox
    Friend WithEvents PrecioAlter3 As System.Windows.Forms.TextBox
    Friend WithEvents ColorAlter1 As System.Windows.Forms.TextBox
    Friend WithEvents DescripcionAlter1 As System.Windows.Forms.TextBox
    Friend WithEvents ColorAlter2 As System.Windows.Forms.TextBox
    Friend WithEvents DescripcionAlter2 As System.Windows.Forms.TextBox
    Friend WithEvents ColorAlter3 As System.Windows.Forms.TextBox
    Friend WithEvents DescripcionAlter3 As System.Windows.Forms.TextBox
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblOferta As System.Windows.Forms.Label
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents lblUso As System.Windows.Forms.Label
    Friend WithEvents lblFamilia As System.Windows.Forms.Label
    Friend WithEvents lblLinea As System.Windows.Forms.Label
    Friend WithEvents lblBusquedaPor As System.Windows.Forms.Label
    Friend WithEvents lblTablaDe As System.Windows.Forms.Label
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents Corrida As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents GridEX2 As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblNoExistenteA1 As System.Windows.Forms.Label
    Friend WithEvents lblFotoNoDisponibleA1 As System.Windows.Forms.Label
    Friend WithEvents lblFotoNoDisponibleA2 As System.Windows.Forms.Label
    Friend WithEvents lblNoExistenteA2 As System.Windows.Forms.Label
    Friend WithEvents lblFotoNoDisponibleA3 As System.Windows.Forms.Label
    Friend WithEvents lblNoExistenteA3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaExistenciaPanel))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage()
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle()
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle()
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.GridEX2 = New Janus.Windows.GridEX.GridEX()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblFotoNoDisponibleA3 = New System.Windows.Forms.Label()
        Me.lblNoExistenteA3 = New System.Windows.Forms.Label()
        Me.lblFotoNoDisponibleA2 = New System.Windows.Forms.Label()
        Me.lblNoExistenteA2 = New System.Windows.Forms.Label()
        Me.lblFotoNoDisponibleA1 = New System.Windows.Forms.Label()
        Me.lblNoExistenteA1 = New System.Windows.Forms.Label()
        Me.ebAlter1 = New System.Windows.Forms.TextBox()
        Me.DescripcionAlter1 = New System.Windows.Forms.TextBox()
        Me.ColorAlter1 = New System.Windows.Forms.TextBox()
        Me.ImAlter1 = New System.Windows.Forms.PictureBox()
        Me.PrecioAlter1 = New System.Windows.Forms.TextBox()
        Me.ebAlter2 = New System.Windows.Forms.TextBox()
        Me.ImAlter2 = New System.Windows.Forms.PictureBox()
        Me.DescripcionAlter2 = New System.Windows.Forms.TextBox()
        Me.PrecioAlter2 = New System.Windows.Forms.TextBox()
        Me.ColorAlter2 = New System.Windows.Forms.TextBox()
        Me.ImAlter3 = New System.Windows.Forms.PictureBox()
        Me.DescripcionAlter3 = New System.Windows.Forms.TextBox()
        Me.ebAlter3 = New System.Windows.Forms.TextBox()
        Me.ColorAlter3 = New System.Windows.Forms.TextBox()
        Me.PrecioAlter3 = New System.Windows.Forms.TextBox()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Corrida = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiComboBox1 = New Janus.Windows.EditControls.UIComboBox()
        Me.lblOferta = New System.Windows.Forms.Label()
        Me.Oferta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnActionExecute = New System.Windows.Forms.Button()
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
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.GridEX2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.ImAlter1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImAlter2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImAlter3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NicePanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.FotoArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox3)
        Me.UiGroupBox1.Controls.Add(Me.ExplorerBar2)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 384)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(792, 280)
        Me.UiGroupBox1.TabIndex = 0
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
        Me.UiGroupBox3.Size = New System.Drawing.Size(786, 125)
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
        Me.GridEX2.Location = New System.Drawing.Point(3, 8)
        Me.GridEX2.Name = "GridEX2"
        Me.GridEX2.Size = New System.Drawing.Size(780, 114)
        Me.GridEX2.TabIndex = 14
        Me.GridEX2.TabStop = False
        Me.GridEX2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.lblFotoNoDisponibleA3)
        Me.ExplorerBar2.Controls.Add(Me.lblNoExistenteA3)
        Me.ExplorerBar2.Controls.Add(Me.lblFotoNoDisponibleA2)
        Me.ExplorerBar2.Controls.Add(Me.lblNoExistenteA2)
        Me.ExplorerBar2.Controls.Add(Me.lblFotoNoDisponibleA1)
        Me.ExplorerBar2.Controls.Add(Me.lblNoExistenteA1)
        Me.ExplorerBar2.Controls.Add(Me.ebAlter1)
        Me.ExplorerBar2.Controls.Add(Me.DescripcionAlter1)
        Me.ExplorerBar2.Controls.Add(Me.ColorAlter1)
        Me.ExplorerBar2.Controls.Add(Me.ImAlter1)
        Me.ExplorerBar2.Controls.Add(Me.PrecioAlter1)
        Me.ExplorerBar2.Controls.Add(Me.ebAlter2)
        Me.ExplorerBar2.Controls.Add(Me.ImAlter2)
        Me.ExplorerBar2.Controls.Add(Me.DescripcionAlter2)
        Me.ExplorerBar2.Controls.Add(Me.PrecioAlter2)
        Me.ExplorerBar2.Controls.Add(Me.ColorAlter2)
        Me.ExplorerBar2.Controls.Add(Me.ImAlter3)
        Me.ExplorerBar2.Controls.Add(Me.DescripcionAlter3)
        Me.ExplorerBar2.Controls.Add(Me.ebAlter3)
        Me.ExplorerBar2.Controls.Add(Me.ColorAlter3)
        Me.ExplorerBar2.Controls.Add(Me.PrecioAlter3)
        Me.ExplorerBar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Artículos Alternativos"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar2.Location = New System.Drawing.Point(3, 133)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(786, 144)
        Me.ExplorerBar2.TabIndex = 0
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblFotoNoDisponibleA3
        '
        Me.lblFotoNoDisponibleA3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFotoNoDisponibleA3.Location = New System.Drawing.Point(528, 80)
        Me.lblFotoNoDisponibleA3.Name = "lblFotoNoDisponibleA3"
        Me.lblFotoNoDisponibleA3.Size = New System.Drawing.Size(104, 23)
        Me.lblFotoNoDisponibleA3.TabIndex = 104
        Me.lblFotoNoDisponibleA3.Text = "Foto no disponible"
        Me.lblFotoNoDisponibleA3.Visible = False
        '
        'lblNoExistenteA3
        '
        Me.lblNoExistenteA3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoExistenteA3.Location = New System.Drawing.Point(536, 64)
        Me.lblNoExistenteA3.Name = "lblNoExistenteA3"
        Me.lblNoExistenteA3.Size = New System.Drawing.Size(80, 23)
        Me.lblNoExistenteA3.TabIndex = 103
        Me.lblNoExistenteA3.Text = "No existente"
        Me.lblNoExistenteA3.Visible = False
        '
        'lblFotoNoDisponibleA2
        '
        Me.lblFotoNoDisponibleA2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFotoNoDisponibleA2.Location = New System.Drawing.Point(280, 80)
        Me.lblFotoNoDisponibleA2.Name = "lblFotoNoDisponibleA2"
        Me.lblFotoNoDisponibleA2.Size = New System.Drawing.Size(104, 23)
        Me.lblFotoNoDisponibleA2.TabIndex = 102
        Me.lblFotoNoDisponibleA2.Text = "Foto no disponible"
        Me.lblFotoNoDisponibleA2.Visible = False
        '
        'lblNoExistenteA2
        '
        Me.lblNoExistenteA2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoExistenteA2.Location = New System.Drawing.Point(288, 64)
        Me.lblNoExistenteA2.Name = "lblNoExistenteA2"
        Me.lblNoExistenteA2.Size = New System.Drawing.Size(80, 23)
        Me.lblNoExistenteA2.TabIndex = 101
        Me.lblNoExistenteA2.Text = "No existente"
        Me.lblNoExistenteA2.Visible = False
        '
        'lblFotoNoDisponibleA1
        '
        Me.lblFotoNoDisponibleA1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFotoNoDisponibleA1.Location = New System.Drawing.Point(32, 80)
        Me.lblFotoNoDisponibleA1.Name = "lblFotoNoDisponibleA1"
        Me.lblFotoNoDisponibleA1.Size = New System.Drawing.Size(104, 23)
        Me.lblFotoNoDisponibleA1.TabIndex = 100
        Me.lblFotoNoDisponibleA1.Text = "Foto no disponible"
        Me.lblFotoNoDisponibleA1.Visible = False
        '
        'lblNoExistenteA1
        '
        Me.lblNoExistenteA1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoExistenteA1.Location = New System.Drawing.Point(44, 64)
        Me.lblNoExistenteA1.Name = "lblNoExistenteA1"
        Me.lblNoExistenteA1.Size = New System.Drawing.Size(80, 23)
        Me.lblNoExistenteA1.TabIndex = 99
        Me.lblNoExistenteA1.Text = "No existente"
        Me.lblNoExistenteA1.Visible = False
        '
        'ebAlter1
        '
        Me.ebAlter1.BackColor = System.Drawing.Color.Ivory
        Me.ebAlter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebAlter1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAlter1.Location = New System.Drawing.Point(152, 40)
        Me.ebAlter1.Name = "ebAlter1"
        Me.ebAlter1.ReadOnly = True
        Me.ebAlter1.Size = New System.Drawing.Size(112, 21)
        Me.ebAlter1.TabIndex = 0
        Me.ebAlter1.TabStop = False
        '
        'DescripcionAlter1
        '
        Me.DescripcionAlter1.BackColor = System.Drawing.Color.Ivory
        Me.DescripcionAlter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DescripcionAlter1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescripcionAlter1.Location = New System.Drawing.Point(152, 64)
        Me.DescripcionAlter1.Name = "DescripcionAlter1"
        Me.DescripcionAlter1.ReadOnly = True
        Me.DescripcionAlter1.Size = New System.Drawing.Size(112, 21)
        Me.DescripcionAlter1.TabIndex = 1
        Me.DescripcionAlter1.TabStop = False
        '
        'ColorAlter1
        '
        Me.ColorAlter1.BackColor = System.Drawing.Color.Ivory
        Me.ColorAlter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ColorAlter1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorAlter1.Location = New System.Drawing.Point(152, 112)
        Me.ColorAlter1.Name = "ColorAlter1"
        Me.ColorAlter1.ReadOnly = True
        Me.ColorAlter1.Size = New System.Drawing.Size(112, 21)
        Me.ColorAlter1.TabIndex = 3
        Me.ColorAlter1.TabStop = False
        '
        'ImAlter1
        '
        Me.ImAlter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImAlter1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ImAlter1.Location = New System.Drawing.Point(24, 40)
        Me.ImAlter1.Name = "ImAlter1"
        Me.ImAlter1.Size = New System.Drawing.Size(120, 96)
        Me.ImAlter1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImAlter1.TabIndex = 96
        Me.ImAlter1.TabStop = False
        '
        'PrecioAlter1
        '
        Me.PrecioAlter1.BackColor = System.Drawing.Color.Ivory
        Me.PrecioAlter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrecioAlter1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioAlter1.Location = New System.Drawing.Point(152, 88)
        Me.PrecioAlter1.Name = "PrecioAlter1"
        Me.PrecioAlter1.ReadOnly = True
        Me.PrecioAlter1.Size = New System.Drawing.Size(112, 21)
        Me.PrecioAlter1.TabIndex = 2
        Me.PrecioAlter1.TabStop = False
        '
        'ebAlter2
        '
        Me.ebAlter2.BackColor = System.Drawing.Color.Ivory
        Me.ebAlter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebAlter2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAlter2.Location = New System.Drawing.Point(400, 40)
        Me.ebAlter2.Name = "ebAlter2"
        Me.ebAlter2.ReadOnly = True
        Me.ebAlter2.Size = New System.Drawing.Size(112, 21)
        Me.ebAlter2.TabIndex = 4
        Me.ebAlter2.TabStop = False
        '
        'ImAlter2
        '
        Me.ImAlter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImAlter2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ImAlter2.Location = New System.Drawing.Point(272, 40)
        Me.ImAlter2.Name = "ImAlter2"
        Me.ImAlter2.Size = New System.Drawing.Size(120, 96)
        Me.ImAlter2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImAlter2.TabIndex = 95
        Me.ImAlter2.TabStop = False
        '
        'DescripcionAlter2
        '
        Me.DescripcionAlter2.BackColor = System.Drawing.Color.Ivory
        Me.DescripcionAlter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DescripcionAlter2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescripcionAlter2.Location = New System.Drawing.Point(400, 64)
        Me.DescripcionAlter2.Name = "DescripcionAlter2"
        Me.DescripcionAlter2.ReadOnly = True
        Me.DescripcionAlter2.Size = New System.Drawing.Size(112, 21)
        Me.DescripcionAlter2.TabIndex = 5
        Me.DescripcionAlter2.TabStop = False
        '
        'PrecioAlter2
        '
        Me.PrecioAlter2.BackColor = System.Drawing.Color.Ivory
        Me.PrecioAlter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrecioAlter2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioAlter2.Location = New System.Drawing.Point(400, 88)
        Me.PrecioAlter2.Name = "PrecioAlter2"
        Me.PrecioAlter2.ReadOnly = True
        Me.PrecioAlter2.Size = New System.Drawing.Size(112, 21)
        Me.PrecioAlter2.TabIndex = 6
        Me.PrecioAlter2.TabStop = False
        '
        'ColorAlter2
        '
        Me.ColorAlter2.BackColor = System.Drawing.Color.Ivory
        Me.ColorAlter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ColorAlter2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorAlter2.Location = New System.Drawing.Point(400, 112)
        Me.ColorAlter2.Name = "ColorAlter2"
        Me.ColorAlter2.ReadOnly = True
        Me.ColorAlter2.Size = New System.Drawing.Size(112, 21)
        Me.ColorAlter2.TabIndex = 7
        Me.ColorAlter2.TabStop = False
        '
        'ImAlter3
        '
        Me.ImAlter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImAlter3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ImAlter3.Location = New System.Drawing.Point(520, 40)
        Me.ImAlter3.Name = "ImAlter3"
        Me.ImAlter3.Size = New System.Drawing.Size(120, 96)
        Me.ImAlter3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImAlter3.TabIndex = 98
        Me.ImAlter3.TabStop = False
        '
        'DescripcionAlter3
        '
        Me.DescripcionAlter3.BackColor = System.Drawing.Color.Ivory
        Me.DescripcionAlter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DescripcionAlter3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescripcionAlter3.Location = New System.Drawing.Point(648, 64)
        Me.DescripcionAlter3.Name = "DescripcionAlter3"
        Me.DescripcionAlter3.ReadOnly = True
        Me.DescripcionAlter3.Size = New System.Drawing.Size(112, 21)
        Me.DescripcionAlter3.TabIndex = 9
        Me.DescripcionAlter3.TabStop = False
        '
        'ebAlter3
        '
        Me.ebAlter3.BackColor = System.Drawing.Color.Ivory
        Me.ebAlter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebAlter3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAlter3.Location = New System.Drawing.Point(648, 40)
        Me.ebAlter3.Name = "ebAlter3"
        Me.ebAlter3.ReadOnly = True
        Me.ebAlter3.Size = New System.Drawing.Size(112, 21)
        Me.ebAlter3.TabIndex = 8
        Me.ebAlter3.TabStop = False
        '
        'ColorAlter3
        '
        Me.ColorAlter3.BackColor = System.Drawing.Color.Ivory
        Me.ColorAlter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ColorAlter3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorAlter3.Location = New System.Drawing.Point(648, 112)
        Me.ColorAlter3.Name = "ColorAlter3"
        Me.ColorAlter3.ReadOnly = True
        Me.ColorAlter3.Size = New System.Drawing.Size(112, 21)
        Me.ColorAlter3.TabIndex = 11
        Me.ColorAlter3.TabStop = False
        '
        'PrecioAlter3
        '
        Me.PrecioAlter3.BackColor = System.Drawing.Color.Ivory
        Me.PrecioAlter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrecioAlter3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioAlter3.Location = New System.Drawing.Point(648, 88)
        Me.PrecioAlter3.Name = "PrecioAlter3"
        Me.PrecioAlter3.ReadOnly = True
        Me.PrecioAlter3.Size = New System.Drawing.Size(112, 21)
        Me.PrecioAlter3.TabIndex = 10
        Me.PrecioAlter3.TabStop = False
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.Corrida)
        Me.ExplorerBar1.Controls.Add(Me.UiComboBox1)
        Me.ExplorerBar1.Controls.Add(Me.lblOferta)
        Me.ExplorerBar1.Controls.Add(Me.Oferta)
        Me.ExplorerBar1.Controls.Add(Me.btnActionExecute)
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
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(792, 384)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 328)
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
        Me.Corrida.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Corrida.Location = New System.Drawing.Point(144, 320)
        Me.Corrida.Name = "Corrida"
        Me.Corrida.ReadOnly = True
        Me.Corrida.Size = New System.Drawing.Size(144, 22)
        Me.Corrida.TabIndex = 63
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
        Me.UiComboBox1.Location = New System.Drawing.Point(144, 72)
        Me.UiComboBox1.Name = "UiComboBox1"
        Me.UiComboBox1.SelectedIndex = 0
        Me.UiComboBox1.Size = New System.Drawing.Size(152, 22)
        Me.UiComboBox1.TabIndex = 2
        Me.UiComboBox1.Text = "Local"
        Me.UiComboBox1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblOferta
        '
        Me.lblOferta.BackColor = System.Drawing.Color.Transparent
        Me.lblOferta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOferta.Location = New System.Drawing.Point(40, 208)
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
        Me.Oferta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Oferta.Location = New System.Drawing.Point(144, 200)
        Me.Oferta.Name = "Oferta"
        Me.Oferta.ReadOnly = True
        Me.Oferta.Size = New System.Drawing.Size(144, 22)
        Me.Oferta.TabIndex = 7
        Me.Oferta.TabStop = False
        Me.Oferta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Oferta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnActionExecute
        '
        Me.btnActionExecute.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnActionExecute.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActionExecute.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnActionExecute.Location = New System.Drawing.Point(304, 72)
        Me.btnActionExecute.Name = "btnActionExecute"
        Me.btnActionExecute.Size = New System.Drawing.Size(96, 24)
        Me.btnActionExecute.TabIndex = 3
        Me.btnActionExecute.Text = "Consultar"
        Me.btnActionExecute.UseVisualStyleBackColor = False
        '
        'lblDescuento
        '
        Me.lblDescuento.BackColor = System.Drawing.Color.Transparent
        Me.lblDescuento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.Location = New System.Drawing.Point(40, 232)
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
        Me.Descuento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descuento.Location = New System.Drawing.Point(144, 224)
        Me.Descuento.Name = "Descuento"
        Me.Descuento.ReadOnly = True
        Me.Descuento.Size = New System.Drawing.Size(144, 22)
        Me.Descuento.TabIndex = 8
        Me.Descuento.TabStop = False
        Me.Descuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Descuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(32, 104)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(368, 16)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "_________________________________________________"
        '
        'lblUso
        '
        Me.lblUso.BackColor = System.Drawing.Color.Transparent
        Me.lblUso.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUso.Location = New System.Drawing.Point(40, 304)
        Me.lblUso.Name = "lblUso"
        Me.lblUso.Size = New System.Drawing.Size(80, 24)
        Me.lblUso.TabIndex = 20
        Me.lblUso.Text = "Uso:"
        '
        'Uso
        '
        Me.Uso.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Uso.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Uso.BackColor = System.Drawing.Color.Ivory
        Me.Uso.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Uso.Location = New System.Drawing.Point(144, 296)
        Me.Uso.Name = "Uso"
        Me.Uso.ReadOnly = True
        Me.Uso.Size = New System.Drawing.Size(144, 22)
        Me.Uso.TabIndex = 11
        Me.Uso.TabStop = False
        Me.Uso.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Uso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFamilia
        '
        Me.lblFamilia.BackColor = System.Drawing.Color.Transparent
        Me.lblFamilia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFamilia.Location = New System.Drawing.Point(40, 280)
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
        Me.Familia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Familia.Location = New System.Drawing.Point(144, 272)
        Me.Familia.Name = "Familia"
        Me.Familia.ReadOnly = True
        Me.Familia.Size = New System.Drawing.Size(144, 22)
        Me.Familia.TabIndex = 10
        Me.Familia.TabStop = False
        Me.Familia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Familia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLinea
        '
        Me.lblLinea.BackColor = System.Drawing.Color.Transparent
        Me.lblLinea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLinea.Location = New System.Drawing.Point(40, 256)
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
        Me.Linea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Linea.Location = New System.Drawing.Point(144, 248)
        Me.Linea.Name = "Linea"
        Me.Linea.ReadOnly = True
        Me.Linea.Size = New System.Drawing.Size(144, 22)
        Me.Linea.TabIndex = 9
        Me.Linea.TabStop = False
        Me.Linea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Linea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblBusquedaPor
        '
        Me.lblBusquedaPor.BackColor = System.Drawing.Color.Transparent
        Me.lblBusquedaPor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusquedaPor.Location = New System.Drawing.Point(40, 80)
        Me.lblBusquedaPor.Name = "lblBusquedaPor"
        Me.lblBusquedaPor.Size = New System.Drawing.Size(96, 16)
        Me.lblBusquedaPor.TabIndex = 2
        Me.lblBusquedaPor.Text = "Busqueda por:"
        '
        'ArticuloID
        '
        Me.ArticuloID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ArticuloID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ArticuloID.ButtonImage = CType(resources.GetObject("ArticuloID.ButtonImage"), System.Drawing.Image)
        Me.ArticuloID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ArticuloID.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ArticuloID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArticuloID.ForeColor = System.Drawing.Color.Black
        Me.ArticuloID.Location = New System.Drawing.Point(144, 48)
        Me.ArticuloID.MaxLength = 20
        Me.ArticuloID.Name = "ArticuloID"
        Me.ArticuloID.Size = New System.Drawing.Size(256, 22)
        Me.ArticuloID.TabIndex = 1
        Me.ArticuloID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ArticuloID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(56, 360)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 24)
        Me.PictureBox3.TabIndex = 62
        Me.PictureBox3.TabStop = False
        '
        'lblTablaDe
        '
        Me.lblTablaDe.BackColor = System.Drawing.Color.Transparent
        Me.lblTablaDe.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTablaDe.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTablaDe.Location = New System.Drawing.Point(80, 360)
        Me.lblTablaDe.Name = "lblTablaDe"
        Me.lblTablaDe.Size = New System.Drawing.Size(144, 23)
        Me.lblTablaDe.TabIndex = 0
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
        Me.NicePanel2.FooterText = "Grupo Dportenis @ " & CStr(Date.Now.Year) '2005
        Me.NicePanel2.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Camera
        HeaderImage2.Image = Nothing
        Me.NicePanel2.HeaderImage = HeaderImage2
        Me.NicePanel2.HeaderText = "Fotografia del Articulo"
        Me.NicePanel2.IsExpanded = True
        Me.NicePanel2.Location = New System.Drawing.Point(440, 48)
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
        Me.NicePanel2.TabIndex = 0
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
        Me.Panel1.TabIndex = 0
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
        Me.FotoArticulo.TabIndex = 0
        Me.FotoArticulo.TabStop = False
        '
        'lblPrecio
        '
        Me.lblPrecio.BackColor = System.Drawing.Color.Transparent
        Me.lblPrecio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(40, 184)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(48, 24)
        Me.lblPrecio.TabIndex = 10
        Me.lblPrecio.Text = "Precio:"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(40, 56)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(56, 24)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Codigo:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(40, 136)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(96, 24)
        Me.lblDescripcion.TabIndex = 6
        Me.lblDescripcion.Text = "Descripcion:"
        '
        'lblColor
        '
        Me.lblColor.BackColor = System.Drawing.Color.Transparent
        Me.lblColor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.Location = New System.Drawing.Point(40, 160)
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
        Me.Descripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion.Location = New System.Drawing.Point(144, 128)
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Size = New System.Drawing.Size(256, 22)
        Me.Descripcion.TabIndex = 0
        Me.Descripcion.TabStop = False
        Me.Descripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Descripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Precio
        '
        Me.Precio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Precio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Precio.BackColor = System.Drawing.Color.Ivory
        Me.Precio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Precio.Location = New System.Drawing.Point(144, 176)
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        Me.Precio.Size = New System.Drawing.Size(144, 22)
        Me.Precio.TabIndex = 6
        Me.Precio.TabStop = False
        Me.Precio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Precio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Color
        '
        Me.Color.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Color.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Color.BackColor = System.Drawing.Color.Ivory
        Me.Color.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color.Location = New System.Drawing.Point(144, 152)
        Me.Color.Name = "Color"
        Me.Color.ReadOnly = True
        Me.Color.Size = New System.Drawing.Size(104, 22)
        Me.Color.TabIndex = 5
        Me.Color.TabStop = False
        Me.Color.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.Color.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ConsultaExistenciaPanel
        '
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Name = "ConsultaExistenciaPanel"
        Me.Size = New System.Drawing.Size(792, 664)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        CType(Me.GridEX2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ExplorerBar2.PerformLayout()
        CType(Me.ImAlter1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImAlter2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImAlter3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NicePanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.FotoArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Function LoadTablaLocal() As DataTable
        Dim tabla As New DataTable("Existencias2")
        tabla.Columns.Add("Almacén", Type.GetType("System.String"))
        tabla.Columns.Add("Número", Type.GetType("System.String"))
        tabla.Columns.Add("Libre", Type.GetType("System.String"))
        tabla.Columns.Add("Apartados", Type.GetType("System.String"))
        tabla.Columns.Add("Defectuosos", Type.GetType("System.String"))
        tabla.Columns.Add("Transito", Type.GetType("System.String"))
        Return tabla
    End Function

  






#Region "Métodos Privados"

    Private Sub Sm_TxtLimpiar()

        ArticuloID.Text = String.Empty
        Descripcion.Text = String.Empty
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


        'GridEX2.ClearStructure()


    End Sub



#End Region

    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ClickButton As New frmBusqueda
        ClickButton.Show()
    End Sub



    Private Sub UiButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CheckButton As New frmBusqueda
        CheckButton.Show()

    End Sub


    Private Sub UiButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CheckButton As New frmBusqueda
        CheckButton.Show()
    End Sub


    Private Sub EditBox1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArticuloID.ButtonClick

        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()


        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Sm_TxtLimpiar()

            ArticuloID.Text = oOpenRecordDlg.Record.Item("Código")

        End If

    End Sub


    Private Sub btnActionExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActionExecute.Click
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

        ''''''''


        If UiComboBox1.Text = "Local" Then

            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.REad_centros) 'oAppContext.ApplicationConfiguration.Almacen)
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


            If oResultado.HaveImage = True Then
                FotoArticulo.Image = Image.FromStream(oResultado.Foto)
            Else
                FotoArticulo.Image = Nothing
            End If



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
                .RetrieveStructure()

            End With




            If (ebAlter1.Text <> "") Then
                AlterFlag = "Alter1"
                oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA1.Visible = False
                If oResultado.HaveImageAlter = True Then
                    ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter1.Text = oResultado.Descripcion
                    ColorAlter1.Text = oResultado.Color
                    PrecioAlter1.Text = oResultado.Precio
                    Me.lblFotoNoDisponibleA1.Visible = False
                Else
                    ImAlter1.Image = Nothing
                    Me.lblFotoNoDisponibleA1.Visible = True
                End If
            Else
                Me.lblNoExistenteA1.Visible = True
            End If

            If (ebAlter2.Text <> "") Then
                AlterFlag = "Alter2"
                oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA2.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA2.Visible = False
                    ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter2.Text = oResultado.Descripcion
                    ColorAlter2.Text = oResultado.Color
                    PrecioAlter2.Text = oResultado.Precio
                Else
                    ImAlter2.Image = Nothing
                    Me.lblFotoNoDisponibleA2.Visible = True
                End If
            Else
                Me.lblNoExistenteA2.Visible = True
            End If

            If (ebAlter3.Text <> "") Then
                AlterFlag = "Alter3"
                oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA3.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA3.Visible = False
                    ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter3.Text = oResultado.Descripcion
                    ColorAlter3.Text = oResultado.Color
                    PrecioAlter3.Text = oResultado.Precio
                Else
                    ImAlter3.Image = Nothing
                    Me.lblFotoNoDisponibleA3.Visible = True
                End If
            Else
                Me.lblNoExistenteA3.Visible = True
            End If



        Else

            Dim dsDataSourcePlaza As New System.Data.DataSet
            'Dim ws As New wsInventarioDP.InventarioDP

            'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then
            '    ws.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            '    ws.strURL.TrimEnd("/")
            'End If

            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
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


            If oResultado.HaveImage = True Then
                FotoArticulo.Image = Image.FromStream(oResultado.Foto)
            Else
                FotoArticulo.Image = Nothing
            End If

            'dsDataSourcePlaza = ws.ConsultaExistenciaWeb(ArticuloID.Text, oAlmacen.PlazaID)

            Dim tabla As DataTable
            tabla = LoadTablaLocal()

            For Each registro As DataRow In dsDataSourcePlaza.Tables(0).Rows
                tabla.ImportRow(registro)
            Next
            dsDataSourcePlaza.Tables.Add(tabla.Copy)
            With GridEX2

                .SetDataBinding(dsDataSourcePlaza, "Existencias2")
                .RetrieveStructure()

            End With



            If (ebAlter1.Text <> "") Then
                AlterFlag = "Alter1"
                oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA1.Visible = False
                If oResultado.HaveImageAlter = True Then
                    ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter1.Text = oResultado.Descripcion
                    ColorAlter1.Text = oResultado.Color
                    PrecioAlter1.Text = oResultado.Precio
                    Me.lblFotoNoDisponibleA1.Visible = False
                Else
                    ImAlter1.Image = Nothing
                    Me.lblFotoNoDisponibleA1.Visible = True
                End If
            Else
                Me.lblNoExistenteA1.Visible = True
            End If

            If (ebAlter2.Text <> "") Then
                AlterFlag = "Alter2"
                oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA2.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA2.Visible = False
                    ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter2.Text = oResultado.Descripcion
                    ColorAlter2.Text = oResultado.Color
                    PrecioAlter2.Text = oResultado.Precio
                Else
                    ImAlter2.Image = Nothing
                    Me.lblFotoNoDisponibleA2.Visible = True
                End If
            Else
                Me.lblNoExistenteA2.Visible = True
            End If

            If (ebAlter3.Text <> "") Then
                AlterFlag = "Alter3"
                oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                Me.lblNoExistenteA3.Visible = False
                If oResultado.HaveImageAlter = True Then
                    Me.lblFotoNoDisponibleA3.Visible = False
                    ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                    DescripcionAlter3.Text = oResultado.Descripcion
                    ColorAlter3.Text = oResultado.Color
                    PrecioAlter3.Text = oResultado.Precio
                Else
                    ImAlter3.Image = Nothing
                    Me.lblFotoNoDisponibleA3.Visible = True
                End If
            Else
                Me.lblNoExistenteA3.Visible = True
            End If


        End If

        Cursor.Current = Cursors.Default
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
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.REad_centros) 'oAppContext.ApplicationConfiguration.Almacen)

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


                If oResultado.HaveImage = True Then
                    FotoArticulo.Image = Image.FromStream(oResultado.FotoAlter)
                Else
                    FotoArticulo.Image = Nothing
                End If

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
                        .RetrieveStructure()

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
                        .RetrieveStructure()

                    End With


                End If


                If (ebAlter1.Text <> "") Then
                    AlterFlag = "Alter1"
                    oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA1.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter1.Text = oResultado.Descripcion
                        ColorAlter1.Text = oResultado.Color
                        PrecioAlter1.Text = oResultado.Precio
                        Me.lblFotoNoDisponibleA1.Visible = False
                    Else
                        ImAlter1.Image = Nothing
                        Me.lblFotoNoDisponibleA1.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA1.Visible = True
                End If

                If (ebAlter2.Text <> "") Then
                    AlterFlag = "Alter2"
                    oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA2.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA2.Visible = False
                        ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter2.Text = oResultado.Descripcion
                        ColorAlter2.Text = oResultado.Color
                        PrecioAlter2.Text = oResultado.Precio
                    Else
                        ImAlter2.Image = Nothing
                        Me.lblFotoNoDisponibleA2.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA2.Visible = True
                End If

                If (ebAlter3.Text <> "") Then
                    AlterFlag = "Alter3"
                    oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA3.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA3.Visible = False
                        ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter3.Text = oResultado.Descripcion
                        ColorAlter3.Text = oResultado.Color
                        PrecioAlter3.Text = oResultado.Precio
                    Else
                        ImAlter3.Image = Nothing
                        Me.lblFotoNoDisponibleA3.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA3.Visible = True
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

            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) '.ApplicationConfiguration.Almacen)

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

                If oResultado.HaveImage = True Then
                    FotoArticulo.Image = Image.FromStream(oResultado.FotoAlter)
                Else
                    FotoArticulo.Image = Nothing
                End If

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
                        .RetrieveStructure()

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
                        .RetrieveStructure()

                    End With
                End If


                If (ebAlter1.Text <> "") Then
                    AlterFlag = "Alter1"
                    oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA1.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter1.Text = oResultado.Descripcion
                        ColorAlter1.Text = oResultado.Color
                        PrecioAlter1.Text = oResultado.Precio
                        Me.lblFotoNoDisponibleA1.Visible = False
                    Else
                        ImAlter1.Image = Nothing
                        Me.lblFotoNoDisponibleA1.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA1.Visible = True
                End If

                If (ebAlter2.Text <> "") Then
                    AlterFlag = "Alter2"
                    oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA2.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA2.Visible = False
                        ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter2.Text = oResultado.Descripcion
                        ColorAlter2.Text = oResultado.Color
                        PrecioAlter2.Text = oResultado.Precio
                    Else
                        ImAlter2.Image = Nothing
                        Me.lblFotoNoDisponibleA2.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA2.Visible = True
                End If

                If (ebAlter3.Text <> "") Then
                    AlterFlag = "Alter3"
                    oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA3.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA3.Visible = False
                        ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter3.Text = oResultado.Descripcion
                        ColorAlter3.Text = oResultado.Color
                        PrecioAlter3.Text = oResultado.Precio
                    Else
                        ImAlter3.Image = Nothing
                        Me.lblFotoNoDisponibleA3.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA3.Visible = True
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

            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

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

                If oResultado.HaveImage = True Then
                    FotoArticulo.Image = Image.FromStream(oResultado.FotoAlter)
                Else
                    FotoArticulo.Image = Nothing
                End If

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
                        .RetrieveStructure()

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
                        .RetrieveStructure()

                    End With
                End If

                If (ebAlter1.Text <> "") Then
                    AlterFlag = "Alter1"
                    oConsulta.FillGeneralData(ebAlter1.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA1.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        ImAlter1.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter1.Text = oResultado.Descripcion
                        ColorAlter1.Text = oResultado.Color
                        PrecioAlter1.Text = oResultado.Precio
                        Me.lblFotoNoDisponibleA1.Visible = False
                    Else
                        ImAlter1.Image = Nothing
                        Me.lblFotoNoDisponibleA1.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA1.Visible = True
                End If

                If (ebAlter2.Text <> "") Then
                    AlterFlag = "Alter2"
                    oConsulta.FillGeneralData(ebAlter2.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA2.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA2.Visible = False
                        ImAlter2.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter2.Text = oResultado.Descripcion
                        ColorAlter2.Text = oResultado.Color
                        PrecioAlter2.Text = oResultado.Precio
                    Else
                        ImAlter2.Image = Nothing
                        Me.lblFotoNoDisponibleA2.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA2.Visible = True
                End If

                If (ebAlter3.Text <> "") Then
                    AlterFlag = "Alter3"
                    oConsulta.FillGeneralData(ebAlter3.Text, AlterFlag, oResultado)
                    Me.lblNoExistenteA3.Visible = False
                    If oResultado.HaveImageAlter = True Then
                        Me.lblFotoNoDisponibleA3.Visible = False
                        ImAlter3.Image = Image.FromStream(oResultado.FotoAlter)
                        DescripcionAlter3.Text = oResultado.Descripcion
                        ColorAlter3.Text = oResultado.Color
                        PrecioAlter3.Text = oResultado.Precio
                    Else
                        ImAlter3.Image = Nothing
                        Me.lblFotoNoDisponibleA3.Visible = True
                    End If
                Else
                    Me.lblNoExistenteA3.Visible = True
                End If
            End If


        Else
            ImAlter3.Image = Nothing
            MsgBox("No selecciono un artículo.", MsgBoxStyle.Exclamation, "DPTienda")


        End If


    End Sub




    Private Sub ArticuloID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ArticuloID.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            Dim oOpenRecordDlg As New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()


            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Sm_TxtLimpiar()

                ArticuloID.Text = oOpenRecordDlg.Record.Item("Código")

            End If

        End If
    End Sub



    Private Sub ConsultaExistenciaPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ArticuloID.Focus()

    End Sub


    Private Sub btnActionExecute_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActionExecute.LostFocus
        ArticuloID.Focus()
    End Sub

    Private Sub ExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemClick

    End Sub
End Class
