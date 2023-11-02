Imports DportenisPro.DPTienda.ApplicationUnits.TomadeInventarioAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CambioTallaAU
Imports Janus.Windows.ExplorerBar
Imports Janus.Windows.GridEX

Public Class frmTomadeInventario
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ebTotalCodigos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblTotalCodigos As System.Windows.Forms.Label
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents ebResponsableDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAdministrativoDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAuditoria As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebResponsable As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAdministrativo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucursal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblAuditoria As System.Windows.Forms.Label
    Friend WithEvents lblResponsable As System.Windows.Forms.Label
    Friend WithEvents lblAdministrativo As System.Windows.Forms.Label
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents grdCabeza As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdTomaInventario As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTomadeInventario))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ebTotalCodigos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblTotalCodigos = New System.Windows.Forms.Label()
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.ebResponsableDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebAdministrativoDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebAuditoria = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebResponsable = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebAdministrativo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucursal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.grdCabeza = New Janus.Windows.GridEX.GridEX()
        Me.lblAuditoria = New System.Windows.Forms.Label()
        Me.lblResponsable = New System.Windows.Forms.Label()
        Me.lblAdministrativo = New System.Windows.Forms.Label()
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.grdTomaInventario = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grdCabeza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTomaInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Controls.Add(Me.Label8)
        Me.explorerBar1.Controls.Add(Me.Label4)
        Me.explorerBar1.Controls.Add(Me.Label5)
        Me.explorerBar1.Controls.Add(Me.Label2)
        Me.explorerBar1.Controls.Add(Me.Label3)
        Me.explorerBar1.Controls.Add(Me.Label6)
        Me.explorerBar1.Controls.Add(Me.Label7)
        Me.explorerBar1.Controls.Add(Me.ebTotalCodigos)
        Me.explorerBar1.Controls.Add(Me.lblTotalCodigos)
        Me.explorerBar1.Controls.Add(Me.ebFecha)
        Me.explorerBar1.Controls.Add(Me.lblFecha)
        Me.explorerBar1.Controls.Add(Me.ebResponsableDescripcion)
        Me.explorerBar1.Controls.Add(Me.ebAdministrativoDescripcion)
        Me.explorerBar1.Controls.Add(Me.ebAuditoria)
        Me.explorerBar1.Controls.Add(Me.ebResponsable)
        Me.explorerBar1.Controls.Add(Me.ebAdministrativo)
        Me.explorerBar1.Controls.Add(Me.ebSucursal)
        Me.explorerBar1.Controls.Add(Me.ebFolio)
        Me.explorerBar1.Controls.Add(Me.grdCabeza)
        Me.explorerBar1.Controls.Add(Me.lblAuditoria)
        Me.explorerBar1.Controls.Add(Me.lblResponsable)
        Me.explorerBar1.Controls.Add(Me.lblAdministrativo)
        Me.explorerBar1.Controls.Add(Me.lblSucursal)
        Me.explorerBar1.Controls.Add(Me.lblFolio)
        Me.explorerBar1.Controls.Add(Me.grdTomaInventario)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.StateStyles.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        ExplorerBarGroup1.StateStyles.FormatStyle.FontBold = Janus.Windows.ExplorerBar.TriState.[True]
        ExplorerBarGroup1.Text = "Toma de Inventario"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(880, 447)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(160, 424)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Nuevo"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(136, 424)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 24)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "F5"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(816, 424)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Salir"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(784, 424)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 24)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Esc"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(272, 424)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Guardar e Imprimir"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(40, 424)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Guardar"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(248, 424)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 24)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "F9"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(16, 424)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 24)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "F2"
        '
        'ebTotalCodigos
        '
        Me.ebTotalCodigos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalCodigos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalCodigos.BackColor = System.Drawing.Color.Ivory
        Me.ebTotalCodigos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebTotalCodigos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalCodigos.Location = New System.Drawing.Point(664, 100)
        Me.ebTotalCodigos.Name = "ebTotalCodigos"
        Me.ebTotalCodigos.ReadOnly = True
        Me.ebTotalCodigos.Size = New System.Drawing.Size(56, 22)
        Me.ebTotalCodigos.TabIndex = 9
        Me.ebTotalCodigos.TabStop = False
        Me.ebTotalCodigos.Text = "0"
        Me.ebTotalCodigos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebTotalCodigos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTotalCodigos
        '
        Me.lblTotalCodigos.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalCodigos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCodigos.Location = New System.Drawing.Point(456, 106)
        Me.lblTotalCodigos.Name = "lblTotalCodigos"
        Me.lblTotalCodigos.Size = New System.Drawing.Size(168, 16)
        Me.lblTotalCodigos.TabIndex = 17
        Me.lblTotalCodigos.Text = "Total de Códigos Auditados  :"
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.Color.Ivory
        Me.ebFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecha.Location = New System.Drawing.Point(272, 42)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(160, 22)
        Me.ebFecha.TabIndex = 1
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(216, 45)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(56, 16)
        Me.lblFecha.TabIndex = 12
        Me.lblFecha.Text = "Fecha   :"
        '
        'ebResponsableDescripcion
        '
        Me.ebResponsableDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsableDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsableDescripcion.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsableDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebResponsableDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebResponsableDescripcion.Location = New System.Drawing.Point(216, 71)
        Me.ebResponsableDescripcion.Name = "ebResponsableDescripcion"
        Me.ebResponsableDescripcion.ReadOnly = True
        Me.ebResponsableDescripcion.Size = New System.Drawing.Size(216, 22)
        Me.ebResponsableDescripcion.TabIndex = 5
        Me.ebResponsableDescripcion.TabStop = False
        Me.ebResponsableDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAdministrativoDescripcion
        '
        Me.ebAdministrativoDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAdministrativoDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAdministrativoDescripcion.BackColor = System.Drawing.Color.Ivory
        Me.ebAdministrativoDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebAdministrativoDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAdministrativoDescripcion.Location = New System.Drawing.Point(664, 71)
        Me.ebAdministrativoDescripcion.Name = "ebAdministrativoDescripcion"
        Me.ebAdministrativoDescripcion.ReadOnly = True
        Me.ebAdministrativoDescripcion.Size = New System.Drawing.Size(200, 22)
        Me.ebAdministrativoDescripcion.TabIndex = 7
        Me.ebAdministrativoDescripcion.TabStop = False
        Me.ebAdministrativoDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAdministrativoDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAuditoria
        '
        Me.ebAuditoria.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAuditoria.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAuditoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebAuditoria.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAuditoria.Location = New System.Drawing.Point(160, 100)
        Me.ebAuditoria.Name = "ebAuditoria"
        Me.ebAuditoria.Size = New System.Drawing.Size(272, 22)
        Me.ebAuditoria.TabIndex = 2
        Me.ebAuditoria.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAuditoria.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebResponsable
        '
        Me.ebResponsable.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsable.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebResponsable.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebResponsable.Location = New System.Drawing.Point(120, 71)
        Me.ebResponsable.Name = "ebResponsable"
        Me.ebResponsable.ReadOnly = True
        Me.ebResponsable.Size = New System.Drawing.Size(88, 22)
        Me.ebResponsable.TabIndex = 1
        Me.ebResponsable.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAdministrativo
        '
        Me.ebAdministrativo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAdministrativo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAdministrativo.BackColor = System.Drawing.Color.Ivory
        Me.ebAdministrativo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebAdministrativo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAdministrativo.Location = New System.Drawing.Point(552, 71)
        Me.ebAdministrativo.Name = "ebAdministrativo"
        Me.ebAdministrativo.ReadOnly = True
        Me.ebAdministrativo.Size = New System.Drawing.Size(104, 22)
        Me.ebAdministrativo.TabIndex = 6
        Me.ebAdministrativo.TabStop = False
        Me.ebAdministrativo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAdministrativo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucursal
        '
        Me.ebSucursal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucursal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucursal.BackColor = System.Drawing.Color.Ivory
        Me.ebSucursal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebSucursal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucursal.Location = New System.Drawing.Point(552, 42)
        Me.ebSucursal.Name = "ebSucursal"
        Me.ebSucursal.ReadOnly = True
        Me.ebSucursal.Size = New System.Drawing.Size(312, 22)
        Me.ebSucursal.TabIndex = 2
        Me.ebSucursal.TabStop = False
        Me.ebSucursal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucursal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolio.Location = New System.Drawing.Point(120, 42)
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.Size = New System.Drawing.Size(88, 22)
        Me.ebFolio.TabIndex = 0
        Me.ebFolio.Text = "0"
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'grdCabeza
        '
        Me.grdCabeza.AlternatingColors = True
        Me.grdCabeza.AutoEdit = True
        Me.grdCabeza.AutomaticSort = False
        Me.grdCabeza.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdCabeza.DesignTimeLayout = GridEXLayout1
        Me.grdCabeza.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdCabeza.Enabled = False
        Me.grdCabeza.FocusStyle = Janus.Windows.GridEX.FocusStyle.None
        Me.grdCabeza.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.grdCabeza.GroupByBoxVisible = False
        Me.grdCabeza.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdCabeza.Location = New System.Drawing.Point(13, 135)
        Me.grdCabeza.Name = "grdCabeza"
        Me.grdCabeza.ScrollBars = Janus.Windows.GridEX.ScrollBars.None
        Me.grdCabeza.SelectedFormatStyle.BackColor = System.Drawing.Color.White
        Me.grdCabeza.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black
        Me.grdCabeza.Size = New System.Drawing.Size(856, 25)
        Me.grdCabeza.TabIndex = 10
        Me.grdCabeza.TabStop = False
        Me.grdCabeza.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate
        Me.grdCabeza.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblAuditoria
        '
        Me.lblAuditoria.BackColor = System.Drawing.Color.Transparent
        Me.lblAuditoria.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuditoria.Location = New System.Drawing.Point(16, 103)
        Me.lblAuditoria.Name = "lblAuditoria"
        Me.lblAuditoria.Size = New System.Drawing.Size(160, 16)
        Me.lblAuditoria.TabIndex = 16
        Me.lblAuditoria.Text = "Auditoría de la Semana :"
        '
        'lblResponsable
        '
        Me.lblResponsable.BackColor = System.Drawing.Color.Transparent
        Me.lblResponsable.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResponsable.Location = New System.Drawing.Point(16, 73)
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Size = New System.Drawing.Size(96, 16)
        Me.lblResponsable.TabIndex = 14
        Me.lblResponsable.Text = "Responsable   :"
        '
        'lblAdministrativo
        '
        Me.lblAdministrativo.BackColor = System.Drawing.Color.Transparent
        Me.lblAdministrativo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdministrativo.Location = New System.Drawing.Point(456, 73)
        Me.lblAdministrativo.Name = "lblAdministrativo"
        Me.lblAdministrativo.Size = New System.Drawing.Size(96, 16)
        Me.lblAdministrativo.TabIndex = 15
        Me.lblAdministrativo.Text = "Administrativo :"
        '
        'lblSucursal
        '
        Me.lblSucursal.BackColor = System.Drawing.Color.Transparent
        Me.lblSucursal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSucursal.Location = New System.Drawing.Point(456, 45)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(96, 16)
        Me.lblSucursal.TabIndex = 13
        Me.lblSucursal.Text = "Sucursal            :"
        '
        'lblFolio
        '
        Me.lblFolio.BackColor = System.Drawing.Color.Transparent
        Me.lblFolio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.Location = New System.Drawing.Point(16, 46)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(96, 16)
        Me.lblFolio.TabIndex = 11
        Me.lblFolio.Text = "Folio                  :"
        '
        'grdTomaInventario
        '
        Me.grdTomaInventario.BackColor = System.Drawing.Color.Ivory
        Me.grdTomaInventario.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.grdTomaInventario.ColumnInfo = "9,0,0,0,0,95,Columns:0{Width:170;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:52;}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:55;AllowEditing:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "3" & _
    "{Width:55;}" & Global.Microsoft.VisualBasic.ChrW(9) & "4{Width:55;AllowEditing:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "5{Width:80;AllowEditing:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "6{Wi" & _
    "dth:117;}" & Global.Microsoft.VisualBasic.ChrW(9) & "7{Width:72;}" & Global.Microsoft.VisualBasic.ChrW(9) & "8{Width:176;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.grdTomaInventario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTomaInventario.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.grdTomaInventario.Location = New System.Drawing.Point(13, 159)
        Me.grdTomaInventario.Name = "grdTomaInventario"
        Me.grdTomaInventario.Rows.Count = 4
        Me.grdTomaInventario.Rows.DefaultSize = 19
        Me.grdTomaInventario.Rows.Fixed = 0
        Me.grdTomaInventario.Size = New System.Drawing.Size(857, 256)
        Me.grdTomaInventario.StyleInfo = resources.GetString("grdTomaInventario.StyleInfo")
        Me.grdTomaInventario.TabIndex = 3
        '
        'frmTomadeInventario
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(880, 447)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmTomadeInventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Toma de Inventario"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grdCabeza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTomaInventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

#Region "Globales"

    Dim isFormLoad As Boolean = False
    Dim isRowDeleted As Boolean = False
    Dim isNewDataLoad As Boolean = False

    Dim FolioActual As Integer

    Dim dtTallas As New DataTable
    Dim ColAnterior As Integer
    Dim RowAnterior As Integer

    Public AdministrativoID As String
    Public AdministrativoName As String

#End Region

#Region "Declarar Objetos"

    'Toma de Inventario
    Dim oTomaInventarioMgr As TomadeInventarioManager
    Dim oTomaInventarioInfo As TomadeInventarioInfo

    'Catalogo Articulos
    Dim oArticuloMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    'Cambio de Talla Manager para el el manejo de Tallas
    Dim oCTallaMgr As CambioTallaManager

#End Region

#Region "Inicializar"

    Private Sub InicializaObjetos()

        'Toma de Inventario
        oTomaInventarioMgr = New TomadeInventarioManager(oAppContext)
        oTomaInventarioInfo = oTomaInventarioMgr.Create

        'Catalogo de Articulos
        oArticuloMgr = New CatalogoArticuloManager(oAppContext)
        oArticulo = oArticuloMgr.Create

        'Cambio Talla Manager
        oCTallaMgr = New CambioTallaManager(oAppContext)

    End Sub

#End Region

#End Region

#Region "Methods"

#Region "Form"

    Private Sub frmTomadeInventario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ebAdministrativo.Text = Me.AdministrativoID
        ebAdministrativoDescripcion.Text = Me.AdministrativoName
        ebFecha.Text = Format(Date.Now, "dd/MM/yyyy") & " - " & Format(Date.Now, "hh:mm:ss")
        ebSucursal.Text = oAppContext.ApplicationConfiguration.Almacen & " " & GetAlmacen(oAppContext.ApplicationConfiguration.Almacen)
        InicializaObjetos()
        ebFolio.Value = oTomaInventarioMgr.GetFolio
        FolioActual = ebFolio.Value
        'Creamos Detalle
        CreateStructureDetail()
        ebTotalCodigos.Text = grdTomaInventario.Rows.Count
        isFormLoad = True

    End Sub

    Private Sub frmTomadeInventario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.F2
                'Guardar
                GuardarTomaInventario(0)

            Case Keys.F5
                Nuevo()

            Case Keys.F9
                'Guardar Imprimir
                GuardarTomaInventario(1)

            Case Keys.Escape
                Me.Finalize()
                Me.Close()

        End Select

    End Sub

#End Region

#Region "Controls"

    Private Sub grdTomaInventario_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles grdTomaInventario.BeforeRowColChange

        If isRowDeleted Then
            isRowDeleted = False
            Exit Sub
        End If

        If isFormLoad Then

            If e.OldRange.r1 = e.NewRange.r1 Then

                Select Case e.OldRange.c1

                    Case 0      'CODIGO
                        grdTomaInventario(e.OldRange.r1, 0) = Trim(UCase(grdTomaInventario(e.OldRange.r1, 0)))
                        If Not VerificaCodigo(grdTomaInventario(e.OldRange.r1, 0)) Then
                            grdTomaInventario.Focus()
                            grdTomaInventario(e.OldRange.r1, 1) = 0
                            grdTomaInventario.Select(e.OldRange.r1, 0)
                            e.Cancel = True
                        End If

                    Case 1      'TALLA
                        grdTomaInventario(e.OldRange.r1, 1) = UCase(grdTomaInventario(e.OldRange.r1, 1))
                        If VerificaTalla(grdTomaInventario(e.OldRange.r1, 0), grdTomaInventario(e.OldRange.r1, 1)) Then
                            grdTomaInventario(e.OldRange.r1, 2) = oTomaInventarioMgr.GetStockTotal(oAppContext.ApplicationConfiguration.Almacen, _
                                                                                                    grdTomaInventario(e.OldRange.r1, 0), _
                                                                                                    grdTomaInventario(e.OldRange.r1, 1))

                        Else
                            grdTomaInventario.Focus()
                            grdTomaInventario(e.OldRange.r1, 2) = 0
                            grdTomaInventario.Select(e.OldRange.r1, 1)
                            e.Cancel = True
                        End If

                    Case 3      'FISICO
                        grdTomaInventario(e.OldRange.r1, 4) = grdTomaInventario(e.OldRange.r1, 3) - grdTomaInventario(e.OldRange.r1, 2)
                        If grdTomaInventario(e.OldRange.r1, 4) < 0 Then
                            grdTomaInventario(e.OldRange.r1, 5) = "SALIDA"
                        Else
                            If grdTomaInventario(e.OldRange.r1, 4) > 0 Then
                                grdTomaInventario(e.OldRange.r1, 5) = "ENTRADA"
                            Else
                                grdTomaInventario(e.OldRange.r1, 5) = ""
                            End If
                        End If

                    Case 6      'MOVIMIENTO
                        grdTomaInventario(e.OldRange.r1, 6) = Trim(UCase(grdTomaInventario(e.OldRange.r1, 6)))

                    Case 8      'OBSERVACIONES
                        grdTomaInventario(e.OldRange.r1, 8) = Trim(UCase(grdTomaInventario(e.OldRange.r1, 8)))

                End Select

            Else

                'Cambiamos de Fila */ Validamos Fila Completa
                If Not EntireRowValidate(e.OldRange.r1) Then

                    MsgBox("Falta ingresar alguna información", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Toma de Inventario")

                    e.Cancel = True
                    grdTomaInventario.Focus()
                    grdTomaInventario.Select(e.OldRange.r1, e.OldRange.c1)

                End If

            End If

        End If

    End Sub

    Private Sub grdTomaInventario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdTomaInventario.KeyDown

        Select Case e.KeyCode

            Case e.Alt And Keys.S

                If grdTomaInventario.Col = 0 Then

                    grdTomaInventario(grdTomaInventario.Row, 0) = LoadSearchArticulo()

                End If

            Case Keys.Enter

                If grdTomaInventario.Col = 8 Then
                    SendKeys.Send("{LEFT}")
                End If

            Case Keys.Insert

                RowAdd()

            Case Keys.Delete

                RowDelete()

        End Select

    End Sub

    Private Sub grdTomaInventario_AfterRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles grdTomaInventario.AfterRowColChange

        If isFormLoad Then

            If grdTomaInventario(e.NewRange.r1, 0) <> String.Empty Then

                oArticulo.ClearFields()
                oArticuloMgr.LoadInto(grdTomaInventario(e.NewRange.r1, 0), oArticulo)

                dtTallas.Dispose()
                dtTallas = Nothing
                dtTallas = New DataTable("Tallas")

                dtTallas = oCTallaMgr.GetTallas(oArticulo.CodCorrida).Tables(0)

            End If

        End If

    End Sub

    Private Sub ebFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebFolio.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub ebResponsable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebResponsable.KeyDown

        Select Case e.KeyCode

            Case e.Alt And Keys.S

                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria", "DportenisPro.DPTienda.Auditoria.Auditoria.TomadeInventario") = True Then

                    ebResponsable.Text = oAppContext.Security.CurrentUser.SessionLoginName()
                    ebResponsableDescripcion.Text = oAppContext.Security.CurrentUser.Name()

                    oAppContext.Security.CloseImpersonatedSession()

                    ebFecha.Text = Format(Date.Now, "dd/MM/yyyy") & " - " & Format(Date.Now, "hh:mm:ss")

                Else

                    ebResponsable.Text = String.Empty
                    ebResponsableDescripcion.Text = String.Empty

                End If

            Case Keys.Enter

                SendKeys.Send("{TAB}")

        End Select

    End Sub

    Private Sub ebAuditoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebAuditoria.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub ebFolio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolio.Validating

        If ebFolio.Value = FolioActual Then

            grdTomaInventario.Enabled = True

        Else

            If ebFolio.Value > FolioActual Then

                MsgBox("Toma de Inventario NO Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Toma de Inventario")
                ebFolio.Value = oTomaInventarioMgr.GetFolio
                FolioActual = ebFolio.Value
                e.Cancel = True

            Else

                'Cargamos Toma de Inventario
                oTomaInventarioMgr.LoadInto(ebFolio.Value, oTomaInventarioInfo)
                If oTomaInventarioInfo.Folio = 0 Then
                    MsgBox("Toma de Inventario No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Toma de Inventario")
                    ebFolio.Value = oTomaInventarioMgr.GetFolio
                    FolioActual = ebFolio.Value
                    e.Cancel = True
                Else
                    isFormLoad = False
                    PutInfoToData()
                    FormatGrid()
                    isFormLoad = True
                    e.Cancel = True
                    Desactivar(False)
                End If

            End If

        End If

    End Sub

#End Region

#Region "Members"

    Private Sub PutDataToInfo()

        With oTomaInventarioInfo

            .Sucursal = oAppContext.ApplicationConfiguration.Almacen
            .Administrativo = ebAdministrativo.Text
            .FechaAuditoria = Date.Now
            .Responsable = ebResponsable.Text
            .Semana = ebAuditoria.Text
            .TotalCodigos = .Detalle.Rows.Count
            ebTotalCodigos.Text = .TotalCodigos
            .Usuario = Me.AdministrativoID

        End With

    End Sub

    Private Sub PutInfoToData()

        With oTomaInventarioInfo

            ebSucursal.Text = .Sucursal & " " & GetAlmacen(.Sucursal)
            ebAdministrativo.Text = .Administrativo
            ebAdministrativoDescripcion.Text = oTomaInventarioMgr.UserDescription(.Administrativo)
            ebFecha.Text = Format(.FechaAuditoria, "dd/MM/yyyy") & " - " & Format(.FechaAuditoria, "hh:mm:ss")
            ebResponsable.Text = .Responsable
            ebResponsableDescripcion.Text = oTomaInventarioMgr.UserDescription(.Responsable)
            ebAuditoria.Text = .Semana
            ebTotalCodigos.Text = .TotalCodigos
            grdTomaInventario.DataSource = Nothing
            grdTomaInventario.Refresh()
            grdTomaInventario.DataSource = .Detalle

        End With

    End Sub

    Private Sub GuardarTomaInventario(ByVal Tipo As Integer)

        If oTomaInventarioInfo.IsNew Then
            If ValidaData() Then
                Dim odlgResult As DialogResult
                odlgResult = MsgBox("¿La información de la Toma de Inventario es correcta?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, " Toma de inventario")
                If odlgResult = DialogResult.Yes Then
                    PutDataToInfo()
                    oTomaInventarioMgr.Save(oTomaInventarioInfo)
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        End If

        If Tipo = 1 Then    'Imprimir
            Imprimir()
        End If

        MsgBox("Reporte de Toma de Inventario guardado satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Toma de Inventario")
        Nuevo()

    End Sub

    Private Sub Imprimir()

        '</Observación>
        'El Reporte se encuentra en la Unidad de Aplicaciòn
        '<End/>
        Dim oARReporte As New rptTomadeInventario(oTomaInventarioInfo, _
                                                ebSucursal.Text, _
                                                ebAdministrativoDescripcion.Text, _
                                                ebResponsableDescripcion.Text)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Toma de Inventario"

        'oARReporte.Document.Print(False, False)
        oReportViewer.Report = oARReporte

        oReportViewer.Show()

    End Sub

    Private Function ValidaData() As Boolean

        If ebResponsable.Text = String.Empty Then
            MsgBox("Debe ingresar Responsable. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Toma de Inventario")
            ebResponsable.Focus()
            Return False
        End If

        If ebAuditoria.Text = String.Empty Then
            MsgBox("Debe ingresar a que semana pertenece la auditoria. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Toma de Inventario")
            ebAuditoria.Focus()
            Return False
        End If

        Dim oRow As DataRow
        Dim i As Integer = 0
        For Each oRow In oTomaInventarioInfo.Detalle.Rows
            oRow!Codigo = UCase(oRow!Codigo)
            If oRow!Codigo = String.Empty Then
                MsgBox("Ingrese Código/Talla o elimine registro. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Toma de Inventario")
                grdTomaInventario.Focus()
                grdTomaInventario.Select(i, 0)
                oRow = Nothing
                Return False
            Else
                If Not VerificaCodigo(oRow!Codigo) Then
                    grdTomaInventario.Focus()
                    grdTomaInventario.Select(i, 0)
                    Return False
                Else
                    If Not VerificaTalla(oRow!Codigo, oRow!talla) Then
                        grdTomaInventario.Focus()
                        grdTomaInventario.Select(i, 1)
                        Return False
                    Else
                        oRow!Sistema = oTomaInventarioMgr.GetStockTotal(oAppContext.ApplicationConfiguration.Almacen, oRow!Codigo, oRow!Talla)
                        oRow!Diferencia = oRow!Fisico - oRow!Sistema
                        If oRow!Diferencia < 0 Then
                            oRow!Tipo = "SALIDA"
                        Else
                            If oRow!Diferencia > 0 Then
                                oRow!Tipo = "ENTRADA"
                            Else
                                oRow!Tipo = ""
                            End If
                        End If
                    End If
                End If
            End If
            i = i + 1
        Next

        oRow = Nothing

        Return True

    End Function

    Private Sub RowAdd()

        If EntireRowValidate(grdTomaInventario.Row) Then

            If grdTomaInventario.Rows.Count >= oAppContext.ApplicationConfiguration.CodigosXAuditoria Then

                MsgBox("No puede agregar más códigos a la Toma de inventario", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Toma de inventario")
                grdTomaInventario.Focus()
                grdTomaInventario.Select(grdTomaInventario.Row, grdTomaInventario.Col)
                Exit Sub

            End If

            Dim oRow As DataRow
            oRow = oTomaInventarioInfo.Detalle.NewRow
            oTomaInventarioInfo.Detalle.Rows.Add(oRow)
            oTomaInventarioInfo.Detalle.AcceptChanges()
            oRow = Nothing

            ebTotalCodigos.Text = grdTomaInventario.Rows.Count

            Dim nRow As Integer = grdTomaInventario.Rows.Count - 1

            grdTomaInventario.Select(nRow, 0)

        Else

            grdTomaInventario.Focus()
            grdTomaInventario.Select(grdTomaInventario.Row, grdTomaInventario.Col)

        End If

    End Sub

    Private Sub RowDelete()

        If grdTomaInventario.Rows.Count > 0 Then

            If grdTomaInventario.Rows.Count = 1 Then
                grdTomaInventario(0, 0) = String.Empty
                grdTomaInventario(0, 1) = 0
                grdTomaInventario(0, 2) = 0
                grdTomaInventario(0, 3) = 0
                grdTomaInventario(0, 4) = 0
                grdTomaInventario(0, 5) = String.Empty
                grdTomaInventario(0, 6) = String.Empty
                grdTomaInventario(0, 7) = 0
                grdTomaInventario(0, 8) = String.Empty
            Else
                isRowDeleted = True
                oTomaInventarioInfo.Detalle.Rows(grdTomaInventario.Row).Delete()
                oTomaInventarioInfo.Detalle.AcceptChanges()
                ebTotalCodigos.Text = grdTomaInventario.Rows.Count
            End If

            grdTomaInventario.Select(0, 0)

        End If

    End Sub

    Private Function EntireRowValidate(ByVal intRow As Integer) As Boolean

        If Not VerificaCodigo(grdTomaInventario(intRow, 0)) Then
            Return False
        End If

        If VerificaTalla(grdTomaInventario(intRow, 0), grdTomaInventario(intRow, 1)) Then
            grdTomaInventario(intRow, 2) = oTomaInventarioMgr.GetStockTotal(oAppContext.ApplicationConfiguration.Almacen, _
                                                                                    grdTomaInventario(intRow, 0), _
                                                                                    grdTomaInventario(intRow, 1))
            'OK
        Else

            Return False

        End If

        If grdTomaInventario(intRow, 2) = 0 And grdTomaInventario(intRow, 3) = 0 Then
            Return False
        End If

        grdTomaInventario(intRow, 4) = grdTomaInventario(intRow, 3) - grdTomaInventario(intRow, 2)
        If grdTomaInventario(intRow, 4) < 0 Then
            grdTomaInventario(intRow, 5) = "SALIDA"
        Else
            If grdTomaInventario(intRow, 4) > 0 Then
                grdTomaInventario(intRow, 5) = "ENTRADA"
            Else
                grdTomaInventario(intRow, 5) = ""
            End If
        End If

        'Mayusculas
        grdTomaInventario(intRow, 0) = UCase(Trim(grdTomaInventario(intRow, 0)))
        grdTomaInventario(intRow, 6) = UCase(Trim(grdTomaInventario(intRow, 6)))
        grdTomaInventario(intRow, 8) = UCase(Trim(grdTomaInventario(intRow, 8)))

        Return True

    End Function

    Private Function GetAlmacen(ByVal strAlmacen As String) As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim AlmacenDescripcion As String = String.Empty
        oAlmacen = oAlmacenMgr.Create
        oAlmacenMgr.LoadInto(strAlmacen, oAlmacen)

        AlmacenDescripcion = oAlmacen.Descripcion

        oAlmacen = Nothing
        oAlmacenMgr = Nothing

        Return AlmacenDescripcion

    End Function

    Private Function VerificaCodigo(ByVal strArticulo As String) As Boolean

        Dim oResult As Boolean = False

        If strArticulo <> String.Empty Then

            oArticulo.ClearFields()
            oArticuloMgr.LoadInto(strArticulo, oArticulo)

            If oArticulo.Exist Then

                dtTallas.Dispose()
                dtTallas = Nothing
                dtTallas = New DataTable("Tallas")

                dtTallas = oCTallaMgr.GetTallas(oArticulo.CodCorrida).Tables(0)

                If dtTallas Is Nothing Then

                    MsgBox("Corrida del Artículo Incorrecta", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Toma de Inventario")
                    oResult = False

                Else

                    oResult = True

                End If

            Else

                MsgBox("El Código de Artículo No Existe", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Toma de Inventario")
                oResult = False

            End If

        End If

        Return oResult

    End Function

    Private Function VerificaTalla(ByVal strCodigo As String, ByVal decTalla As String) As Boolean

        If strCodigo <> String.Empty Then

            Dim oResult As Boolean = False

            If decTalla <> String.Empty Then

                If Not TallaEsdeArticulo(decTalla) Then

                    MsgBox("La talla no es válida para el código capturado.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Toma de Inventario")
                    oResult = False

                Else

                    oResult = True

                End If

            Else

                MsgBox("La talla no es válida para el código capturado.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Toma de Inventario")
                oResult = False

            End If

            Return oResult

        Else

            Return True

        End If

    End Function

    Private Function TallaEsdeArticulo(ByVal decTalla As String) As Boolean

        Dim dRow As DataRow
        Dim oResult As Boolean = False

        dRow = dtTallas.Rows(0)

        If dRow!C01 = decTalla Or _
            dRow!C02 = decTalla Or _
            dRow!C03 = decTalla Or _
            dRow!C04 = decTalla Or _
            dRow!C05 = decTalla Or _
            dRow!C06 = decTalla Or _
            dRow!C07 = decTalla Or _
            dRow!C08 = decTalla Or _
            dRow!C09 = decTalla Or _
            dRow!C10 = decTalla Or _
            dRow!C11 = decTalla Or _
            dRow!C12 = decTalla Or _
            dRow!C13 = decTalla Or _
            dRow!C14 = decTalla Or _
            dRow!C15 = decTalla Or _
            dRow!C16 = decTalla Or _
            dRow!C17 = decTalla Or _
            dRow!C18 = decTalla Or _
            dRow!C19 = decTalla Or _
            dRow!C20 = decTalla Then

            oResult = True

        Else

            oResult = False

        End If

        dRow = Nothing

        Return oResult

    End Function

    Private Sub CreateStructureDetail()

        Dim oCol As DataColumn
        Dim oRow As DataRow

        oTomaInventarioInfo.Detalle.Dispose()
        oTomaInventarioInfo.Detalle = Nothing

        oTomaInventarioInfo.Detalle = New DataTable("Detalle")

        With oTomaInventarioInfo.Detalle

            oCol = New DataColumn
            oCol.ColumnName = "Codigo"
            oCol.DataType = System.Type.GetType("System.String")
            oCol.DefaultValue = String.Empty
            .Columns.Add(oCol)

            oCol = Nothing
            oCol = New DataColumn
            oCol.ColumnName = "Talla"
            oCol.DataType = System.Type.GetType("System.String")
            oCol.DefaultValue = 0
            .Columns.Add(oCol)

            oCol = Nothing
            oCol = New DataColumn
            oCol.ColumnName = "Sistema"
            oCol.DataType = System.Type.GetType("System.Int32")
            oCol.DefaultValue = 0
            .Columns.Add(oCol)

            oCol = Nothing
            oCol = New DataColumn
            oCol.ColumnName = "Fisico"
            oCol.DataType = System.Type.GetType("System.Int32")
            oCol.DefaultValue = 0
            .Columns.Add(oCol)

            oCol = Nothing
            oCol = New DataColumn
            oCol.ColumnName = "Diferencia"
            oCol.DataType = System.Type.GetType("System.Int32")
            oCol.DefaultValue = 0
            .Columns.Add(oCol)

            oCol = Nothing
            oCol = New DataColumn
            oCol.ColumnName = "Tipo"
            oCol.DataType = System.Type.GetType("System.String")
            oCol.DefaultValue = String.Empty
            .Columns.Add(oCol)

            oCol = Nothing
            oCol = New DataColumn
            oCol.ColumnName = "Movimientos"
            oCol.DataType = System.Type.GetType("System.String")
            oCol.DefaultValue = String.Empty
            .Columns.Add(oCol)

            oCol = Nothing
            oCol = New DataColumn
            oCol.ColumnName = "FolioDetalle"
            oCol.DataType = System.Type.GetType("System.Int32")
            oCol.DefaultValue = 0
            .Columns.Add(oCol)

            oCol = Nothing
            oCol = New DataColumn
            oCol.ColumnName = "Observaciones"
            oCol.DataType = System.Type.GetType("System.String")
            oCol.DefaultValue = String.Empty
            .Columns.Add(oCol)

        End With

        grdTomaInventario.DataSource = oTomaInventarioInfo.Detalle
        grdTomaInventario.DataMember = "Detalle"

        grdTomaInventario.Refresh()

        oRow = oTomaInventarioInfo.Detalle.NewRow
        oTomaInventarioInfo.Detalle.Rows.Add(oRow)
        oTomaInventarioInfo.Detalle.AcceptChanges()
        oRow = Nothing

        FormatGrid()

    End Sub

    Private Sub FormatGrid()

        With grdTomaInventario

            .Cols(0).Width = 170
            .Cols(1).Width = 52
            .Cols(2).Width = 55
            .Cols(2).AllowEditing = False
            .Cols(3).Width = 55
            .Cols(4).Width = 55
            .Cols(4).AllowEditing = False
            .Cols(5).Width = 80
            .Cols(5).AllowEditing = False
            .Cols(6).Width = 117
            .Cols(7).Width = 72
            .Cols(8).Width = 176

        End With

    End Sub

    Private Sub Nuevo()

        isFormLoad = False

        grdTomaInventario.DataSource = Nothing
        grdTomaInventario.Refresh()

        ebAuditoria.Text = String.Empty
        ebTotalCodigos.Text = 0
        ebResponsable.Text = String.Empty
        ebResponsableDescripcion.Text = String.Empty
        ebFecha.Text = Format(Date.Now, "dd/MM/yyyy") & " - " & Format(Date.Now, "hh:mm:ss")
        ebSucursal.Text = oAppContext.ApplicationConfiguration.Almacen & " " & GetAlmacen(oAppContext.ApplicationConfiguration.Almacen)
        oTomaInventarioInfo.ClearFields()
        CreateStructureDetail()

        ebFolio.Value = oTomaInventarioMgr.GetFolio
        FolioActual = ebFolio.Value

        Desactivar(True)

        ebTotalCodigos.Text = grdTomaInventario.Rows.Count

        grdTomaInventario.Enabled = False

        ebFolio.Focus()

        isFormLoad = True

    End Sub

    Private Sub Desactivar(ByVal Active As Boolean)

        ebFolio.Enabled = Active
        ebResponsable.Enabled = Active
        ebAuditoria.Enabled = Active
        grdTomaInventario.Enabled = Active

    End Sub

    Private Function LoadSearchArticulo() As String

        Dim cArticulo As String
        Dim oOpenRecordDlg As New OpenRecordDialog2
        oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            If oOpenRecordDlg.pbCodigo = String.Empty Then

                cArticulo = oOpenRecordDlg.Record.Item("Código")

            Else

                cArticulo = oOpenRecordDlg.pbCodigo

            End If

        Else

            cArticulo = ""

        End If

        oOpenRecordDlg.Dispose()
        oOpenRecordDlg = Nothing

        Return cArticulo

    End Function

#End Region

#End Region

End Class

