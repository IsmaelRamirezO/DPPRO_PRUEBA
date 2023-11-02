Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneral
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmAjustesES
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents grdProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents ebAjustes As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CalendarCombo1 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebNombreResponsable As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebResponsable As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents nbTotalArticulos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjustesES))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ebAjustes = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebResponsable = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombreResponsable = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.nbFolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.CalendarCombo1 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grdProductos = New Janus.Windows.GridEX.GridEX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nbTotalArticulos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        CType(Me.ebAjustes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ebAjustes.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ebAjustes
        '
        Me.ebAjustes.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ebAjustes.Controls.Add(Me.ebResponsable)
        Me.ebAjustes.Controls.Add(Me.ebNombreResponsable)
        Me.ebAjustes.Controls.Add(Me.UiGroupBox1)
        Me.ebAjustes.Controls.Add(Me.Label18)
        Me.ebAjustes.Controls.Add(Me.Label17)
        Me.ebAjustes.Controls.Add(Me.Label16)
        Me.ebAjustes.Controls.Add(Me.Label15)
        Me.ebAjustes.Controls.Add(Me.Label14)
        Me.ebAjustes.Controls.Add(Me.Label13)
        Me.ebAjustes.Controls.Add(Me.Label12)
        Me.ebAjustes.Controls.Add(Me.Label11)
        Me.ebAjustes.Controls.Add(Me.Label10)
        Me.ebAjustes.Controls.Add(Me.Label9)
        Me.ebAjustes.Controls.Add(Me.Label8)
        Me.ebAjustes.Controls.Add(Me.Label7)
        Me.ebAjustes.Controls.Add(Me.txtObservaciones)
        Me.ebAjustes.Controls.Add(Me.Label6)
        Me.ebAjustes.Controls.Add(Me.Label5)
        Me.ebAjustes.Controls.Add(Me.grdProductos)
        Me.ebAjustes.Controls.Add(Me.Label3)
        Me.ebAjustes.Controls.Add(Me.nbTotalArticulos)
        Me.ebAjustes.Controls.Add(Me.Label21)
        Me.ebAjustes.Controls.Add(Me.Label22)
        Me.ebAjustes.Controls.Add(Me.Label2)
        Me.ebAjustes.Controls.Add(Me.Label19)
        Me.ebAjustes.Location = New System.Drawing.Point(0, 0)
        Me.ebAjustes.Name = "ebAjustes"
        Me.ebAjustes.Size = New System.Drawing.Size(752, 512)
        Me.ebAjustes.TabIndex = 0
        Me.ebAjustes.Text = "ExplorerBar1"
        Me.ebAjustes.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebResponsable
        '
        Me.ebResponsable.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsable.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsable.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsable.Enabled = False
        Me.ebResponsable.Location = New System.Drawing.Point(88, 72)
        Me.ebResponsable.MaxLength = 10
        Me.ebResponsable.Name = "ebResponsable"
        Me.ebResponsable.Size = New System.Drawing.Size(72, 20)
        Me.ebResponsable.TabIndex = 1
        Me.ebResponsable.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebResponsable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombreResponsable
        '
        Me.ebNombreResponsable.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombreResponsable.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombreResponsable.BackColor = System.Drawing.Color.Ivory
        Me.ebNombreResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNombreResponsable.Enabled = False
        Me.ebNombreResponsable.Location = New System.Drawing.Point(168, 72)
        Me.ebNombreResponsable.MaxLength = 10
        Me.ebNombreResponsable.Name = "ebNombreResponsable"
        Me.ebNombreResponsable.Size = New System.Drawing.Size(376, 20)
        Me.ebNombreResponsable.TabIndex = 2
        Me.ebNombreResponsable.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombreResponsable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.nbFolio)
        Me.UiGroupBox1.Controls.Add(Me.CalendarCombo1)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(640, 48)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'nbFolio
        '
        Me.nbFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFolio.ButtonImage = CType(resources.GetObject("nbFolio.ButtonImage"), System.Drawing.Image)
        Me.nbFolio.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.nbFolio.Location = New System.Drawing.Point(64, 16)
        Me.nbFolio.Name = "nbFolio"
        Me.nbFolio.Size = New System.Drawing.Size(104, 22)
        Me.nbFolio.TabIndex = 1
        Me.nbFolio.Text = "0"
        Me.nbFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFolio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'CalendarCombo1
        '
        Me.CalendarCombo1.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.CalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.CalendarCombo1.Enabled = False
        Me.CalendarCombo1.Location = New System.Drawing.Point(528, 16)
        Me.CalendarCombo1.Name = "CalendarCombo1"
        Me.CalendarCombo1.ShowDropDown = False
        Me.CalendarCombo1.Size = New System.Drawing.Size(104, 20)
        Me.CalendarCombo1.TabIndex = 5
        Me.CalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(440, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Fecha Ajuste.-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio.-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(560, 384)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 13)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Nuevo"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(544, 384)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(21, 13)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "F4"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(632, 384)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 13)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Salir"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(608, 384)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "ESC"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(160, 384)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Borrar"
        Me.Label14.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(120, 384)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "SUPR"
        Me.Label13.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(432, 384)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Guardar/Imprimir"
        Me.Label12.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(416, 384)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "F9"
        Me.Label11.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(360, 384)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Grabar"
        Me.Label10.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(336, 384)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "F2"
        Me.Label9.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(256, 384)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Seleccionar"
        Me.Label8.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(208, 384)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Alt + S"
        Me.Label7.Visible = False
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(112, 328)
        Me.txtObservaciones.MaxLength = 255
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.Size = New System.Drawing.Size(536, 40)
        Me.txtObservaciones.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 328)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 19)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Observaciones"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 296)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total de Artículos"
        '
        'grdProductos
        '
        Me.grdProductos.AllowColumnDrag = False
        Me.grdProductos.AlternatingColors = True
        Me.grdProductos.AutomaticSort = False
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdProductos.DesignTimeLayout = GridEXLayout1
        Me.grdProductos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdProductos.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.grdProductos.ExpandableCards = False
        Me.grdProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdProductos.GroupByBoxVisible = False
        Me.grdProductos.HeaderFormatStyle.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.grdProductos.HeaderFormatStyle.BackColorGradient = System.Drawing.SystemColors.ControlLight
        Me.grdProductos.HeaderFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical
        Me.grdProductos.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grdProductos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdProductos.Location = New System.Drawing.Point(8, 104)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdProductos.Size = New System.Drawing.Size(736, 184)
        Me.grdProductos.TabIndex = 3
        Me.grdProductos.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate
        Me.grdProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Responsable"
        '
        'nbTotalArticulos
        '
        Me.nbTotalArticulos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalArticulos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalArticulos.BackColor = System.Drawing.Color.Ivory
        Me.nbTotalArticulos.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nbTotalArticulos.Location = New System.Drawing.Point(112, 296)
        Me.nbTotalArticulos.Name = "nbTotalArticulos"
        Me.nbTotalArticulos.ReadOnly = True
        Me.nbTotalArticulos.Size = New System.Drawing.Size(96, 20)
        Me.nbTotalArticulos.TabIndex = 5
        Me.nbTotalArticulos.Text = "0"
        Me.nbTotalArticulos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalArticulos.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbTotalArticulos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(8, 384)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(47, 13)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "INSERT"
        Me.Label21.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(56, 384)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 13)
        Me.Label22.TabIndex = 9
        Me.Label22.Text = "Agregar"
        Me.Label22.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(688, 384)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Imprimir"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(672, 384)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(20, 13)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "F5"
        '
        'frmAjustesES
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(744, 402)
        Me.Controls.Add(Me.ebAjustes)
        Me.HelpButton = True
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(760, 440)
        Me.MinimumSize = New System.Drawing.Size(760, 440)
        Me.Name = "frmAjustesES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajustes de"
        CType(Me.ebAjustes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ebAjustes.ResumeLayout(False)
        Me.ebAjustes.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Globales"
    Dim oAjusteMgr As AjusteGeneralManager
    Dim oAjuste As AjusteGeneralInfo

    Dim dsCatalogoArticulos As DataSet
    Dim oCatalogoArticulosMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    Dim dsTallas As DataSet
    Dim oFacturaMgr As FacturaManager


    Dim bolLoadForm As Boolean
    Dim intRecordActual As Integer

    ''MgrSAP
    Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

#End Region

#Region "Propiedades"
    Private m_strTipoAjuste As String
    Private m_blReajuste As Boolean = False

    Public Property TipoAjuste() As String
        Get
            Return m_strTipoAjuste
        End Get
        Set(ByVal Value As String)
            m_strTipoAjuste = Value
        End Set
    End Property

    Public Property Reajuste() As String
        Get
            Return m_blReajuste
        End Get
        Set(ByVal Value As String)
            m_blReajuste = Value
        End Set
    End Property

#End Region

#Region "Eventos Controles"

    Private Sub frmAjustesES_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.TipoAjuste = String.Empty Then
            MessageBox.Show("", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Else

            Me.InicializarObjetos()
            If Me.TipoAjuste = "E" Then
                Me.Text &= " Entrada"
            Else
                Me.Text &= " Salida"
            End If

        End If
    End Sub

    Private Sub grdProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        Select Case e.KeyCode
            '-----------------------------------------------------------------------------
            ' JNAVA (03.10.2016): Se comento por que solo es un modulo de consulta
            '-----------------------------------------------------------------------------
            'Case Keys.Insert
            '    AgregarCodigo()
            'Case Keys.Delete
            '    Me.bolLoadForm = False
            '    Dim intRecord As Integer = Me.grdProductos.Row
            '    Me.oAjuste.Detalle.Rows.RemoveAt(intRecord)
            '    Me.oAjuste.Detalle.AcceptChanges()
            '    Me.bolLoadForm = True
            'Case e.Alt And Keys.S

            '    If grdProductos.Col = 0 AndAlso (IsDBNull(grdProductos.GetValue(0)) OrElse CStr(grdProductos.GetValue(0)) = String.Empty) Then
            '        Dim strCodArticulo As String = LoadSearchArticulo()
            '        If Not strCodArticulo = String.Empty Then
            '            grdProductos.SetValue(0, strCodArticulo)
            '        End If


            '    End If

        End Select
    End Sub

    Private Sub grdProductos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.CurrentCellChanged
        If Me.bolLoadForm = True Then
            If Not Me.intRecordActual = Me.grdProductos.Row AndAlso (Not (IsDBNull(Me.grdProductos.GetValue("Codigo")) OrElse Me.grdProductos.GetValue("Codigo") = String.Empty)) Then
                Me.intRecordActual = Me.grdProductos.Row
                oArticulo = oCatalogoArticulosMgr.Create()
                oArticulo.ClearFields()
                oCatalogoArticulosMgr.LoadInto(Me.grdProductos.GetValue("Codigo"), oArticulo)
                FillTallasArticulo(oArticulo.CodCorrida)
                Me.nbTotalArticulos.Value = oAjuste.Detalle.Compute("sum(Cantidad)", "Cantidad>0")
            Else
                Me.nbTotalArticulos.Value = oAjuste.Detalle.Compute("sum(Cantidad)", "Cantidad>0")
                Me.intRecordActual = Me.grdProductos.Row
            End If
        End If
    End Sub

    Private Sub nbFolio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nbFolio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.nbFolio.Value > 0 Then
                AbrirAjuste()
            Else
                Me.InicializarObjetos()
            End If
        End If
    End Sub

    Private Sub nbFolio_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbFolio.ButtonClick

        Dim oOpenRecordDlg As New OpenRecordDialog
        Dim oAjustesOpenRecordDialogView As New AjustesOpenRecordDialogView
        oAjustesOpenRecordDialogView.TipoAjuste = Me.TipoAjuste
        oOpenRecordDlg.CurrentView = oAjustesOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Try

                Dim strFolio As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then
                    strFolio = oOpenRecordDlg.Record.Item("Folio")
                Else
                    strFolio = oOpenRecordDlg.pbCodigo
                End If
                Me.nbFolio.Value = strFolio
                Me.AbrirAjuste()

            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

    Private Sub grdProductos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdProductos.Validating
        e.Cancel = ValidaAllRecord()
    End Sub

    Private Sub frmAjustesES_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        bolLoadForm = False
    End Sub

    Private Sub grdProductos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.GotFocus
        '-----------------------------------------------------------------------------
        ' JNAVA (03.10.2016): Se comento por que solo es un modulo de consulta
        '-----------------------------------------------------------------------------
        'If Me.oAjuste.Detalle.Rows.Count = 0 Then
        '    AgregarCodigo()
        'End If
    End Sub

    Private Sub frmAjustesES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            '-----------------------------------------------------------------------------
            ' JNAVA (03.10.2016): Se comento por que solo es un modulo de consulta
            '-----------------------------------------------------------------------------
            'Case Keys.F2
            'If Me.grdProductos.Enabled Then
            '    'Guardar(False)
            '    MessageBox.Show("No se permite hacer ajustes", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    MessageBox.Show("No se permite modificar ajustes", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            Case Keys.F4
                'Nuevo()
                'MessageBox.Show("No se permite hacer ajustes", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                InicializarObjetos()

                'Case Keys.F9
                'If Me.grdProductos.Enabled Then
                '    'Guardar(True)
                '    MessageBox.Show("No se permite hacer ajustes", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Else
                '    MessageBox.Show("No se permite modificar ajustes", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
            Case Keys.Escape
                bolLoadForm = True
                Me.Close()
            Case Keys.F5
                If Not Me.grdProductos.Enabled Then ActionPrintAjuste()
        End Select
    End Sub

#End Region

#Region "Procedimientos Programador"

    Private Sub InicializarObjetos()
        bolLoadForm = False
        Reajuste = False
        oAjusteMgr = New AjusteGeneralManager(oAppContext)
        oAjuste = oAjusteMgr.Create(Me.TipoAjuste)
        oFacturaMgr = New FacturaManager(oAppContext)

        '''Obtenemos el Responsable del Movimiento. (El que se logea)
        Me.ebResponsable.Text = UCase(oAppContext.Security.CurrentUser.SessionLoginName)
        Me.ebNombreResponsable.Text = UCase(oAppContext.Security.CurrentUser.Name)
        Me.nbFolio.Value = Me.oAjusteMgr.GetFolio(Me.TipoAjuste)

        '''Asignamos DataSource a Grid
        oAjuste.Detalle.Columns("Cantidad").DefaultValue = 0
        oAjuste.Detalle.Columns("Talla").DefaultValue = String.Empty
        oAjuste.Detalle.Columns("FolioSAP").DefaultValue = String.Empty
        oAjuste.Detalle.Columns("Codigo").DefaultValue = String.Empty
        oAjuste.Detalle.Columns("Total").Expression = "Cantidad * Importe"

        oAjuste.Detalle.AcceptChanges()
        Me.grdProductos.DataSource = oAjuste.Detalle
        AddHandler oAjuste.Detalle.ColumnChanging, New DataColumnChangeEventHandler(AddressOf Column_Changing)

        '''Llenamos Catalogo Articulos.
        Me.oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)
        dsCatalogoArticulos = Me.oCatalogoArticulosMgr.GetAll(False)
        Me.dsCatalogoArticulos.Tables(0).Columns("Código").ColumnName = "Codigo"
        Me.grdProductos.DropDowns(0).SetDataBinding(Me.dsCatalogoArticulos, Me.dsCatalogoArticulos.Tables(0).TableName)

        Me.txtObservaciones.Text = String.Empty
        Me.nbTotalArticulos.Value = 0
        'Me.ebFolioSAP.Text = String.Empty

        'Me.grdProductos.Enabled = True
        'Me.txtObservaciones.Enabled = True
        Me.nbFolio.Focus()
        bolLoadForm = True
    End Sub

    Private Sub AbrirAjuste()
        Try
            oAjusteMgr.LoadInto(Me.nbFolio.Value, Me.oAjuste)
            oAjuste.Detalle.Columns("Total").Expression = "Cantidad * Importe"
            oAjuste.Detalle.AcceptChanges()
            Me.grdProductos.DataSource = oAjuste.Detalle
            AddHandler oAjuste.Detalle.ColumnChanging, New DataColumnChangeEventHandler(AddressOf Column_Changing)

            If Me.oAjuste.FolioAjuste = 0 Then
                MessageBox.Show("El folio no existe", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.InicializarObjetos()
                Me.grdProductos.Focus()
            Else
                Me.ebResponsable.Text = Me.oAjuste.Usuario
                Me.txtObservaciones.Text = Me.oAjuste.Observaciones
                'Me.ebFolioSAP.Text = Me.oAjuste.FolioSAP
                Me.nbTotalArticulos.Value = Me.oAjuste.TotalCodigos
                Me.nbFolio.Value = Me.oAjuste.FolioAjuste

                'Me.grdProductos.Enabled = False
                'Me.txtObservaciones.Enabled = False

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub Column_Changing(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
        Try
            If bolLoadForm Then
                Select Case UCase(e.Column.ColumnName)

                    Case UCase("Codigo")
                        ActualizaDatosArticulo(e.Row, e.ProposedValue)
                        Me.grdProductos.Focus()
                    Case UCase("Talla")
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue = String.Empty Then
                            MessageBox.Show("Capture la Talla", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                        If Not FindTalla(e.ProposedValue) Then
                            MessageBox.Show("La talla no pertecene al Articulo.- " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            If IsDBNull(e.Row("Talla")) OrElse e.Row("Talla") = String.Empty Then
                                e.ProposedValue = ""
                            Else
                                e.ProposedValue = e.Row("Talla")
                            End If
                            Me.grdProductos.Focus()
                        Else
                            If BuscaCodigoEnAjuste(e.Row("Codigo"), e.ProposedValue, Me.grdProductos.Row) > 0 Then
                                MessageBox.Show("El Aticulo ya se encuentra con esa Talla " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.grdProductos.Focus()
                                e.ProposedValue = e.Row("Talla")
                            End If
                        End If
                    Case UCase("Cantidad")
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue = 0 Then
                            MessageBox.Show("Capture Cantidad", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                        'Para validar la existencia cuando sea un ajuste de salida
                        If Me.TipoAjuste <> "E" Then
                            Dim arts As Decimal = oAjusteMgr.Existencias(e.Row("Codigo"), e.Row("Talla"))
                            If e.ProposedValue > arts Then
                                MessageBox.Show("No tiene existencias el Articulo.- " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                e.ProposedValue = arts
                                Exit Sub
                            End If
                        End If
                End Select
            End If


        Catch ex As Exception
            MessageBox.Show("Error :" & ex.ToString)
        End Try


    End Sub

    Private Sub ActualizaDatosArticulo(ByVal oRow As DataRow, ByVal CodigoArticulo As String)
        If CodigoArticulo <> String.Empty Then
            oArticulo = oCatalogoArticulosMgr.Create()
            oArticulo.ClearFields()
            oCatalogoArticulosMgr.LoadInto(CodigoArticulo, oArticulo)
            oRow("Descripcion") = oArticulo.Descripcion
            oRow("Importe") = oArticulo.CostoProm
            FillTallasArticulo(oArticulo.CodCorrida)
        End If
    End Sub

    Private Sub FillTallasArticulo(ByVal vCodCorrida As String)

        dsTallas = Nothing

        dsTallas = oFacturaMgr.GetTallasArticulo(vCodCorrida)

        If dsTallas Is Nothing Then

            MsgBox("Corrida del Artículo NO EXISTE.  ", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "  Facturación")

        End If

    End Sub

    Private Function FindTalla(ByVal strTalla As String) As Boolean

        Dim iCol As Integer
        Dim campoTalla As String

        If Not (dsTallas Is Nothing) Then

            For iCol = 0 To 19

                campoTalla = "C" & Format(iCol + 1, "00")

                If dsTallas.Tables(0).Rows(0).Item(campoTalla) = strTalla Then

                    Return True

                End If

            Next

        End If

        Return False

    End Function

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

    Private Function BuscaCodigoEnAjuste(ByVal strCodigo As String, ByVal strTalla As String, ByVal nRowG As Integer) As Integer

        Dim oRow As DataRow
        Dim nRow As Integer = 0

        For Each oRow In Me.oAjuste.Detalle.Rows

            nRow = nRow + 1

            If (nRow - 1) <> nRowG AndAlso oRow("Codigo") = strCodigo AndAlso oRow("Talla") = strTalla Then

                Return nRow

            End If

        Next

        Return 0

    End Function

    Private Sub AgregarCodigo()
        'If Me.oAjuste.Detalle.Rows.Count < 7 Then
        Me.bolLoadForm = False
        Dim oNewRow As DataRow = Me.oAjuste.Detalle.NewRow
        oAjuste.Detalle.Rows.Add(oNewRow)
        oAjuste.Detalle.AcceptChanges()
        Me.grdProductos.Row = oAjuste.Detalle.Rows.Count - 1
        Me.grdProductos.Col = 0
        Me.bolLoadForm = True
        'Else
        '    MessageBox.Show("Solo se puede tratar 7 Partidas por Ajuste", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Public Sub Guardar(Optional ByVal Print As Boolean = True)
        ''********************************************************************
        'If Reajuste Then
        '    MessageBox.Show("Tienes que Hacer un Nuevo Ajuste", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'Dim totAjus As Integer = 0
        'If TipoAjuste = "E" Then
        '    totAjus = 7
        'Else
        '    If TipoAjuste = "S" Then
        '        totAjus = 1
        '    End If
        'End If
        ''********************************************************************

        'If ValidaAllRecord() Then

        'ElseIf Me.txtObservaciones.Text.Trim = String.Empty Then
        '    MessageBox.Show("Capture observaciones", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.txtObservaciones.Focus()
        'Else

        '    Me.oAjuste.FolioAjuste = Me.nbFolio.Value
        '    Me.oAjuste.Almacen = oAppContext.ApplicationConfiguration.Almacen
        '    'son menos o igual a totAjus
        '    If oAjuste.Detalle.Rows.Count <= totAjus Then
        '        oSap.Write_AJUSTE(oAjuste)
        '        'Para que llene en todos los registros el folio SAP
        '        For Each oRow As DataRow In oAjuste.Detalle.Rows
        '            If oAjuste.FolioSAP Is Nothing Then
        '                oRow!foliosap = ""
        '            Else
        '                oRow!foliosap = oAjuste.FolioSAP
        '            End If
        '        Next
        '    Else
        '        'A dividir
        '        Dim dtArticulos As New DataTable
        '        dtArticulos.Columns.Add("Codigo", System.Type.GetType("System.String"))
        '        dtArticulos.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
        '        dtArticulos.Columns.Add("Talla", System.Type.GetType("System.String"))

        '        Dim ren As Integer = 0 : Dim pos As Integer = 0

        '        For Each oRow As DataRow In oAjuste.Detalle.Rows
        '            Dim rrow As DataRow = dtArticulos.NewRow
        '            rrow("Codigo") = oRow!codigo
        '            rrow("Cantidad") = oRow!cantidad
        '            rrow("Talla") = oRow!Talla
        '            dtArticulos.Rows.Add(rrow)
        '            dtArticulos.AcceptChanges()
        '            ren += 1 : pos += 1
        '            'Marcar los Registros con este folio
        '            oRow!foliosap = "X"
        '            If ren = totAjus Or oAjuste.Detalle.Rows.Count = pos Then
        '                oSap.Write_AJUSTE(oAjuste, dtArticulos)
        '                '--------------------Vaciar BD 
        '                dtArticulos = Nothing : dtArticulos = New DataTable
        '                dtArticulos.Columns.Add("Codigo", System.Type.GetType("System.String"))
        '                dtArticulos.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
        '                dtArticulos.Columns.Add("Talla", System.Type.GetType("System.String"))
        '                '---------------------
        '                'Ponerles el FOlio SAP
        '                For Each tmpRow As DataRow In oAjuste.Detalle.Rows
        '                    If oAjuste.FolioSAP Is Nothing Then
        '                        If tmpRow!foliosap = "X" Then tmpRow!foliosap = ""
        '                    Else
        '                        If tmpRow!foliosap = "X" Then tmpRow!foliosap = oAjuste.FolioSAP
        '                    End If
        '                Next
        '                ren = 0
        '                '----------------------------------------------------------------------
        '            End If

        '        Next
        '    End If

        '    'Me.ebFolioSAP.Text = oAjuste.FolioSAP
        '    Me.oAjuste.Usuario = Me.ebResponsable.Text
        '    Me.oAjuste.Observaciones = Me.txtObservaciones.Text
        '    'Me.oAjuste.FolioSAP = "1"

        '    Me.oAjuste.CostoTotal = oAjuste.Detalle.Compute("sum(Total)", "Total>0")
        '    Me.oAjuste.TipoAjuste = Me.TipoAjuste
        '    Me.oAjuste.TotalCodigos = Me.nbTotalArticulos.Value
        '    Me.oAjusteMgr.Save(Me.oAjuste)
        '    Me.nbFolio.Value = Me.oAjuste.FolioAjuste
        '    Me.oAjusteMgr.PutMovimiento(Me.oAjuste)
        '    MessageBox.Show("Ajuste guardado con Folio: " & Me.oAjuste.FolioAjuste, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Reajuste = True
        '    If Print Then
        '        ActionPrintAjuste()
        '    End If

        'End If


    End Sub

    Public Sub ActionPrintAjuste()

        Dim iRep As AjustesESFrm
        Dim iView As ReportViewerForm

        iRep = New AjustesESFrm
        iView = New ReportViewerForm
        iRep.DataSource = FormatGridToReport()

        If Me.TipoAjuste = "E" Then
            iRep.Titulo = "REPORTE DE AJUSTES DE ENTRADA"
        Else
            iRep.Titulo = "REPORTE DE AJUSTES DE SALIDA"
        End If

        iRep.Folio = oAjuste.FolioAjuste
        iRep.Fecha = oAjuste.FechaAjuste
        iRep.Usuario = oAjuste.Usuario

        '''Asigno Almacen.
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        oAlmacen = oAlmacenMgr.Create
        oAlmacen = oAlmacenMgr.Load(oSap.Read_Centros(Me.oAjuste.Almacen))
        iRep.CodigoAlmacen = oAjuste.Almacen
        iRep.NombreAlmacen = oAlmacen.Descripcion
        '''Asigno Almacen.

        iRep.Observaciones = oAjuste.Observaciones
        iRep.Run()
        iView.Report = iRep
        iView.ShowDialog()
    End Sub

    Public Function FormatGridToReport() As DataTable
        Dim dtReport As New DataTable("Articulos")

        Dim oCol As DataColumn

        oCol = New DataColumn
        With oCol
            .ColumnName = "Codigo"
            .DataType = GetType(System.String)
        End With
        dtReport.Columns.Add(oCol)

        oCol = New DataColumn
        With oCol
            .ColumnName = "Descripcion"
            .DataType = GetType(System.String)
        End With
        dtReport.Columns.Add(oCol)

        Dim i As Integer
        For i = 1 To 10
            oCol = New DataColumn
            With oCol
                .ColumnName = "T" & i
                .DataType = GetType(System.String)
            End With
            dtReport.Columns.Add(oCol)
        Next

        For i = 1 To 10
            oCol = New DataColumn
            With oCol
                .ColumnName = "C" & i
                .DataType = GetType(System.String)
            End With
            dtReport.Columns.Add(oCol)
        Next

        oCol = New DataColumn
        With oCol
            .ColumnName = "Total"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With
        dtReport.Columns.Add(oCol)

        oCol = New DataColumn
        With oCol
            .ColumnName = "Importe"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
        End With
        dtReport.Columns.Add(oCol)

        oCol = New DataColumn
        With oCol
            .ColumnName = "FolioSAP"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With
        dtReport.Columns.Add(oCol)

        For Each oNewRow As DataRow In Me.oAjuste.Detalle.Rows
            Dim dvExiste As New DataView(dtReport, "Codigo like'" & oNewRow("Codigo") & "'", "Codigo", DataViewRowState.CurrentRows)
            If dvExiste.Count = 0 Then

                Dim dvAjusteDetalle As New DataView(Me.oAjuste.Detalle, "Codigo like'" & oNewRow("Codigo") & "'", "Codigo,Talla", DataViewRowState.CurrentRows)

                Dim oAddRow As DataRow = dtReport.NewRow
                oAddRow!Codigo = oNewRow!Codigo
                oAddRow!Descripcion = oNewRow!Descripcion
                oAddRow!FolioSAP = oNewRow!FolioSAP


                Dim IndexView As Integer

                For IndexView = 0 To dvAjusteDetalle.Count - 1
                    oAddRow("T" & IndexView + 1) = dvAjusteDetalle(IndexView)!Talla
                    oAddRow("C" & IndexView + 1) = dvAjusteDetalle(IndexView)!Cantidad
                    oAddRow("Total") += dvAjusteDetalle(IndexView)!Cantidad 'Piezas
                    'oAddRow("Importe") += oNewRow("Total") ' Costo Total
                    'Correcion estaba sumando mal el importe cuando el codigo trae mas de 1 talla
                    oAddRow("Importe") += dvAjusteDetalle(IndexView)!Total
                Next
                dtReport.Rows.Add(oAddRow)
                dtReport.AcceptChanges()

            End If
        Next

        Return dtReport

    End Function

    Private Function ValidaAllRecord() As Boolean
        If bolLoadForm = False Then
            Exit Function
        End If
        Dim i As Integer = 0
        For Each oRow As DataRow In Me.oAjuste.Detalle.Rows

            ActualizaDatosArticulo(oRow, oRow!Codigo)

            If IsDBNull(oRow!Cantidad) OrElse oRow!Talla = String.Empty Then
                MessageBox.Show("Capture Talla para el articulo " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.grdProductos.Select()
                Me.grdProductos.Focus()
                Me.grdProductos.Row = i
                Me.grdProductos.Col = 2
                ValidaAllRecord = True
                Exit For
            Else
                If Not FindTalla(oRow!Talla) Then
                    MessageBox.Show("La talla no pertecene al Articulo.- " & oRow("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.grdProductos.Select()
                    Me.grdProductos.Focus()
                    Me.grdProductos.Row = i
                    Me.grdProductos.Col = 2
                    Exit For
                Else
                    If BuscaCodigoEnAjuste(oRow("Codigo"), oRow!Talla, i) > 0 Then
                        MessageBox.Show("La talla ya fue asignada al Articulo.-  " & oRow("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.grdProductos.Select()
                        Me.grdProductos.Focus()
                        Me.grdProductos.Row = i
                        Me.grdProductos.Col = 2
                        Exit For
                    Else
                        If IsDBNull(oRow!Cantidad) OrElse oRow!Cantidad = 0 Then
                            MessageBox.Show("Capture Cantidad para el Articulo.- " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.grdProductos.Select()
                            Me.grdProductos.Focus()
                            Me.grdProductos.Row = i
                            Me.grdProductos.Col = 3
                            ValidaAllRecord = True
                            Exit For
                        Else
                            'Para validar la existencia cuando sea un ajuste de salida
                            If Me.TipoAjuste <> "E" Then
                                Dim arts As Integer = oAjusteMgr.Existencias(oRow("Codigo"), oRow!Talla)
                                If oRow!Cantidad > arts Then
                                    MessageBox.Show("No tiene existencias el Articulo.- " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.grdProductos.Select()
                                    Me.grdProductos.Focus()
                                    Me.grdProductos.Row = i
                                    Me.grdProductos.Col = 3
                                    ValidaAllRecord = True
                                    oRow!Cantidad = arts
                                    Exit For
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            i += 1
        Next
        ValidaAllRecord = False
    End Function


#End Region

        'Private Sub grdProductos_CurrentCellChanging(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.CurrentCellChangingEventArgs) Handles grdProductos.CurrentCellChanging

        '    Try
        '        If bolLoadForm Then
        '            Dim strValor As String = Me.grdProductos.GetValue(e.Column.Key)
        '            Select Case UCase(Me.grdProductos.CurrentColumn.Key)

        '                Case UCase("Codigo")
        '                    ActualizaDatosArticulo(Me.oAjuste.Detalle.Rows(Me.grdProductos.Row), strValor)
        '                    Me.grdProductos.Focus()
        '                Case UCase("Talla")
        '                    If IsDBNull(strValor) OrElse strValor = String.Empty Then
        '                        MessageBox.Show("Capture la Talla", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                        e.Cancel = True
        '                        Exit Sub
        '                    End If
        '                    If Not FindTalla(strValor) Then
        '                        MessageBox.Show("La talla no pertecene al Articulo.- " & Me.grdProductos.GetValue(0), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                        If IsDBNull(strValor) OrElse strValor = String.Empty Then
        '                            e.Cancel = True
        '                        Else
        '                            e.Cancel = True
        '                        End If
        '                        Me.grdProductos.Focus()
        '                    Else
        '                        If BuscaCodigoEnAjuste(Me.grdProductos.GetValue(0), strValor, Me.grdProductos.Row) > 0 Then
        '                            MessageBox.Show("El Aticulo ya se encuentra con esa Talla " & Me.grdProductos.GetValue(0), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                            Me.grdProductos.Focus()
        '                            e.Cancel = True
        '                        End If
        '                    End If
        '                Case UCase("Cantidad")
        '                    If IsDBNull(strValor) OrElse strValor = 0 Then
        '                        MessageBox.Show("Capture Cantidad", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                        e.Cancel = True
        '                        Exit Sub
        '                    End If
        '            End Select
        '        End If


        '    Catch ex As Exception
        '        MessageBox.Show("Error :" & ex.ToString)
        '    End Try


        'End Sub
End Class
