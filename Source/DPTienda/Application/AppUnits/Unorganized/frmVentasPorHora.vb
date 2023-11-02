Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.AnalisDeVentas

Public Class frmVentasPorHora
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
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoReporte As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ccmbFechaAl As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ccmbFechaDel As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dgVentas As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbCajas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ccmbHoraAl As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ccmbHoraDel As Janus.Windows.CalendarCombo.CalendarCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentasPorHora))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ccmbHoraAl = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ccmbHoraDel = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoReporte = New Janus.Windows.EditControls.UIComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.ccmbFechaAl = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ccmbFechaDel = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgVentas = New Janus.Windows.GridEX.GridEX()
        Me.cmbCajas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.dgVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.lblMensaje)
        Me.ExplorerBar2.Controls.Add(Me.Label2)
        Me.ExplorerBar2.Controls.Add(Me.Label3)
        Me.ExplorerBar2.Controls.Add(Me.ccmbHoraAl)
        Me.ExplorerBar2.Controls.Add(Me.ccmbHoraDel)
        Me.ExplorerBar2.Controls.Add(Me.Label19)
        Me.ExplorerBar2.Controls.Add(Me.cmbTipoReporte)
        Me.ExplorerBar2.Controls.Add(Me.Label5)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Controls.Add(Me.Label8)
        Me.ExplorerBar2.Controls.Add(Me.Label9)
        Me.ExplorerBar2.Controls.Add(Me.Label10)
        Me.ExplorerBar2.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar2.Controls.Add(Me.ccmbFechaAl)
        Me.ExplorerBar2.Controls.Add(Me.ccmbFechaDel)
        Me.ExplorerBar2.Controls.Add(Me.Label11)
        Me.ExplorerBar2.Controls.Add(Me.Label12)
        Me.ExplorerBar2.Controls.Add(Me.Label14)
        Me.ExplorerBar2.Controls.Add(Me.Label15)
        Me.ExplorerBar2.Controls.Add(Me.dgVentas)
        Me.ExplorerBar2.Controls.Add(Me.cmbCajas)
        Me.ExplorerBar2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Ventas por Hora"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(720, 397)
        Me.ExplorerBar2.TabIndex = 140
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblMensaje
        '
        Me.lblMensaje.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMensaje.BackColor = System.Drawing.Color.Transparent
        Me.lblMensaje.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.Location = New System.Drawing.Point(8, 168)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(704, 176)
        Me.lblMensaje.TabIndex = 4
        Me.lblMensaje.Text = "De 33 artículos en 23 facturas el promedio por factura es 1.43 Artículos."
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensaje.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(153, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "Hora Desde"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(393, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 23)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Hasta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ccmbHoraAl
        '
        Me.ccmbHoraAl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ccmbHoraAl.CustomFormat = "HH:mm:ss"
        Me.ccmbHoraAl.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom
        '
        '
        '
        Me.ccmbHoraAl.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.ccmbHoraAl.Location = New System.Drawing.Point(441, 107)
        Me.ccmbHoraAl.Name = "ccmbHoraAl"
        Me.ccmbHoraAl.ShowDropDown = False
        Me.ccmbHoraAl.Size = New System.Drawing.Size(112, 23)
        Me.ccmbHoraAl.TabIndex = 5
        Me.ccmbHoraAl.Value = New Date(2005, 7, 4, 0, 0, 0, 0)
        Me.ccmbHoraAl.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'ccmbHoraDel
        '
        Me.ccmbHoraDel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ccmbHoraDel.CustomFormat = "HH:mm:ss"
        Me.ccmbHoraDel.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom
        '
        '
        '
        Me.ccmbHoraDel.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.ccmbHoraDel.Location = New System.Drawing.Point(257, 107)
        Me.ccmbHoraDel.Name = "ccmbHoraDel"
        Me.ccmbHoraDel.ShowDropDown = False
        Me.ccmbHoraDel.Size = New System.Drawing.Size(128, 23)
        Me.ccmbHoraDel.TabIndex = 4
        Me.ccmbHoraDel.Value = New Date(2005, 7, 4, 0, 0, 0, 0)
        Me.ccmbHoraDel.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(153, 139)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 23)
        Me.Label19.TabIndex = 145
        Me.Label19.Text = "Reporte"
        '
        'cmbTipoReporte
        '
        Me.cmbTipoReporte.Anchor = System.Windows.Forms.AnchorStyles.Top
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "Ventas Totales"
        UiComboBoxItem1.Value = "VT"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "Ventas Detalle"
        UiComboBoxItem2.Value = "VD"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "Promedio por Hora"
        UiComboBoxItem3.Value = "PH"
        Me.cmbTipoReporte.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3})
        Me.cmbTipoReporte.Location = New System.Drawing.Point(257, 139)
        Me.cmbTipoReporte.Name = "cmbTipoReporte"
        Me.cmbTipoReporte.Size = New System.Drawing.Size(176, 23)
        Me.cmbTipoReporte.TabIndex = 6
        Me.cmbTipoReporte.TextAlignment = Janus.Windows.EditControls.TextAlignment.Far
        Me.cmbTipoReporte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(153, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 23)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Caja:"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(456, 376)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 23)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Exportar"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(432, 376)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 23)
        Me.Label8.TabIndex = 130
        Me.Label8.Text = "F5"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(393, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 23)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "Hasta"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(153, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 23)
        Me.Label10.TabIndex = 128
        Me.Label10.Text = "Fecha Desde"
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnGenerar.Location = New System.Drawing.Point(441, 139)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(112, 23)
        Me.btnGenerar.TabIndex = 7
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ccmbFechaAl
        '
        Me.ccmbFechaAl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ccmbFechaAl.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        '
        '
        '
        Me.ccmbFechaAl.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.ccmbFechaAl.Location = New System.Drawing.Point(441, 75)
        Me.ccmbFechaAl.Name = "ccmbFechaAl"
        Me.ccmbFechaAl.ShowDropDown = False
        Me.ccmbFechaAl.Size = New System.Drawing.Size(112, 23)
        Me.ccmbFechaAl.TabIndex = 3
        Me.ccmbFechaAl.Value = New Date(2005, 7, 4, 0, 0, 0, 0)
        Me.ccmbFechaAl.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'ccmbFechaDel
        '
        Me.ccmbFechaDel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ccmbFechaDel.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        '
        '
        '
        Me.ccmbFechaDel.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.ccmbFechaDel.Location = New System.Drawing.Point(257, 75)
        Me.ccmbFechaDel.Name = "ccmbFechaDel"
        Me.ccmbFechaDel.ShowDropDown = False
        Me.ccmbFechaDel.Size = New System.Drawing.Size(128, 23)
        Me.ccmbFechaDel.TabIndex = 2
        Me.ccmbFechaDel.Value = New Date(2005, 7, 4, 0, 0, 0, 0)
        Me.ccmbFechaDel.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(192, 376)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 23)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Imprimir"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(176, 376)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 23)
        Me.Label12.TabIndex = 123
        Me.Label12.Text = "F9"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(336, 376)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 23)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Salir"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(312, 376)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 23)
        Me.Label15.TabIndex = 121
        Me.Label15.Text = "Esc"
        '
        'dgVentas
        '
        Me.dgVentas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgVentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.dgVentas.DesignTimeLayout = GridEXLayout1
        Me.dgVentas.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.dgVentas.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dgVentas.GroupByBoxVisible = False
        Me.dgVentas.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgVentas.Location = New System.Drawing.Point(8, 168)
        Me.dgVentas.Name = "dgVentas"
        Me.dgVentas.Size = New System.Drawing.Size(704, 176)
        Me.dgVentas.TabIndex = 8
        Me.dgVentas.TableSpacing = 7
        Me.dgVentas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbCajas
        '
        Me.cmbCajas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbCajas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbCajas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbCajas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbCajas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.cmbCajas.DesignTimeLayout = GridEXLayout2
        Me.cmbCajas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCajas.Location = New System.Drawing.Point(257, 43)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(128, 22)
        Me.cmbCajas.TabIndex = 1
        Me.cmbCajas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbCajas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ExplorerBar2)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(720, 397)
        Me.ExplorerBar1.TabIndex = 3
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'frmVentasPorHora
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 397)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.Name = "frmVentasPorHora"
        Me.Text = "Ventas por Hora"
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ExplorerBar2.PerformLayout()
        CType(Me.dgVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Globales"
    Private oCajasMgr As CatalogoCajaManager
    Private dsCajas As DataSet
    Private oAnalisisVentasMgr As AnalisisDeVentasMgr
    Private dsVentasPromedio As DataSet
#End Region

    Private Sub frmVentasPorHora_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor

        oAnalisisVentasMgr = New AnalisisDeVentasMgr(oAppContext)

        oCajasMgr = New CatalogoCajaManager(oAppContext)
        dsCajas = oCajasMgr.GetAll(False).Copy
        Dim oRow As DataRow = dsCajas.Tables(0).NewRow

        oRow("CodCaja") = "Td"
        oRow("Descripcion") = "Todas"
        Me.dsCajas.Tables(0).Rows.Add(oRow)



        With Me.cmbCajas

            .DataSource = dsCajas
            .DataMember = dsCajas.Tables(0).TableName
            .DropDownList.Columns.Add("CodCaja")
            .DropDownList.Columns.Add("Descripcion")
            .DropDownList.Columns("CodCaja").DataMember = "CodCaja"
            .DropDownList.Columns("Descripcion").DataMember = "Descripcion"
            .DropDownList.Columns("Descripcion").Width = 170

            .DisplayMember = "Descripcion"
            .ValueMember = "CodCaja"

            .Refresh()

        End With

        ccmbFechaDel.Value = Date.Now
        ccmbFechaAl.Value = Date.Now

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try

            Me.lblMensaje.Visible = False
            If Me.cmbCajas.Text = String.Empty Then

                MessageBox.Show("Seleccione Caja", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbCajas.Focus()
                Exit Sub

            ElseIf Me.cmbTipoReporte.Text = String.Empty Then

                MessageBox.Show("Seleccione Tipo Reporte", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbTipoReporte.Focus()
                Exit Sub

            End If

            Dim FechaDel As DateTime
            Dim FechaAl As DateTime

            FechaDel = Format(ccmbFechaDel.Value, "dd/MM/yyyy") & " " & Me.ccmbHoraDel.Value.ToShortTimeString
            FechaAl = Format(ccmbFechaAl.Value, "dd/MM/yyyy") & " " & Me.ccmbHoraAl.Value.ToShortTimeString

            If cmbTipoReporte.SelectedValue = "PH" Then

                dsVentasPromedio = oAnalisisVentasMgr.VentasPromedioPorHora(FechaDel, FechaAl, Me.cmbCajas.Value)

                'Dim dvFechaAutoF As New DataView(dsVentasPromedio.Tables(0), "Fecha >='" & oConfigCierreFI.FechaAutoF & "'", "Folio", DataViewRowState.CurrentRows)
                'For Each oView As DataRowView In dvFechaAutoF
                '    oView.Row.Item(0) = 0
                'Next
                'dsVentasPromedio.Tables(0).AcceptChanges()

                If dsVentasPromedio.Tables(0).Rows.Count > 0 Then

                    Dim intArticulos As Integer
                    Dim intFacturas As Integer

                    intArticulos = dsVentasPromedio.Tables(0).Compute("sum(Cantidad)", "Cantidad>0")
                    intFacturas = dsVentasPromedio.Tables(0).Rows.Count

                    lblMensaje.Text = "De " & intArticulos & " Artículos en " & intFacturas & " Facturas el promedio por Factura es de " & Format((intArticulos / intFacturas), "###,###,###.#0#") & " Artículos"
                    lblMensaje.Visible = True
                Else

                    MessageBox.Show("No se registraron ventas en las horas capturadas", "DPTienda", MessageBoxButtons.OK)
                    lblMensaje.Visible = False

                End If

            ElseIf cmbTipoReporte.SelectedValue = "VT" Then

                dsVentasPromedio = oAnalisisVentasMgr.VentasTotalesPorHora(FechaDel, FechaAl, Me.cmbCajas.Value)

                Dim dvFechaAutoF As New DataView(dsVentasPromedio.Tables(0), "Fecha >='" & oConfigCierreFI.FechaAutoF & "'", "Folio", DataViewRowState.CurrentRows)
                'For Each oView As DataRowView In dvFechaAutoF
                '    oView.Row.Item(1) = 0
                'Next
                dsVentasPromedio.Tables(0).AcceptChanges()

                If dsVentasPromedio.Tables(0).Rows.Count > 0 Then

                    dgVentas.RootTable.Columns.Clear()

                    FormatToVentasTotales()

                    dgVentas.DataSource = dsVentasPromedio.Tables(0)
                    dgVentas.DataMember = dsVentasPromedio.Tables(0).TableName

                Else

                    MessageBox.Show("No se registraron ventas en las horas capturadas", "DPTienda", MessageBoxButtons.OK)


                End If

            ElseIf cmbTipoReporte.SelectedValue = "VD" Then

                dsVentasPromedio = oAnalisisVentasMgr.VentasDetallePorHora(FechaDel, FechaAl, Me.cmbCajas.Value)

                AddColumnoNotaCredito()

                For Each dr As DataRow In dsVentasPromedio.Tables(0).Rows
                    Dim dsFSAP As DataSet = oAnalisisVentasMgr.GetFolioSAP(dr.Item("CodCaja"), dr.Item("Folio"))
                    If dsFSAP.Tables(0).Rows.Count > 0 Then
                        dr.Item("Referencia") = dsFSAP.Tables(0).Rows(0).Item("Referencia")
                    End If
                Next
                dsVentasPromedio.Tables(0).AcceptChanges()

                Dim dvFechaAutoF As New DataView(dsVentasPromedio.Tables(0), "Fecha >='" & oConfigCierreFI.FechaAutoF & "'", "Folio", DataViewRowState.CurrentRows)
                'For Each oView As DataRowView In dvFechaAutoF
                '    oView.Row.Item(0) = 0
                'Next
                dsVentasPromedio.Tables(0).AcceptChanges()

                If dsVentasPromedio.Tables(0).Rows.Count > 0 Then

                    dgVentas.RootTable.Columns.Clear()

                    FormatToVentasDetalle()

                    dgVentas.DataSource = dsVentasPromedio.Tables(0)
                    dgVentas.DataMember = dsVentasPromedio.Tables(0).TableName

                Else

                    MessageBox.Show("No se registraron ventas en las horas capturadas", "DPTienda", MessageBoxButtons.OK)

                End If

            Else

                    MessageBox.Show("Seleccione tipo de reporte correcto", "DPTienda", MessageBoxButtons.OK)
                    Me.cmbTipoReporte.Focus()

            End If

        Catch ex As Exception

            Throw ex

        End Try

    End Sub
    Private Sub AddColumnoNotaCredito()
        Dim dcFolioSAP As New DataColumn
        With dcFolioSAP
            .ColumnName = "Referencia"
            .Caption = "Referencia"
            .DataType = GetType(String)
            .DefaultValue = ""
        End With
        dsVentasPromedio.Tables(0).Columns.Add(dcFolioSAP)
        dsVentasPromedio.Tables(0).AcceptChanges()

    End Sub


    Public Sub FormatToVentasTotales()
        Me.dgVentas.RootTable.Columns.Add("Folio", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("Folio").Caption = "Factura"

        Me.dgVentas.RootTable.Columns.Add("Referencia", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("Referencia").Caption = "Referencia"

        Me.dgVentas.RootTable.Columns.Add("Cantidad", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("Cantidad").FormatString = "######"

        Me.dgVentas.RootTable.Columns.Add("Total", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("Total").FormatString = "c"

        Me.dgVentas.RootTable.Columns.Add("DescTotal", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("DescTotal").FormatString = "c"
        Me.dgVentas.RootTable.Columns("DescTotal").Caption = "Descuento"

        Me.dgVentas.RootTable.Columns.Add("CodFormasPago", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("CodFormasPago").Caption = "Formas de Pago"

        Me.dgVentas.RootTable.Columns.Add("MontoPago", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("MontoPago").FormatString = "c"
        Me.dgVentas.RootTable.Columns("MontoPago").Caption = "Monto"

        Me.dgVentas.RootTable.Columns.Add("CodVendedor", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("CodVendedor").Caption = "Cod. Vendedor"

        Me.dgVentas.RootTable.Columns.Add("ClienteID", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)

        Me.dgVentas.RootTable.Columns.Add("CodTipoVenta", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("CodTipoventa").Caption = "Cod. Tipo Venta"

        Me.dgVentas.RootTable.Columns.Add("DPValeID", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)

        Me.dgVentas.RootTable.Columns.Add("NotaCreditoID", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("NotaCreditoID").Caption = "Nota de Credito"

        Me.dgVentas.RootTable.Columns.Add("Status", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)

    End Sub

    Public Sub FormatToVentasDetalle()

        Me.dgVentas.RootTable.Columns.Add("Folio", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        'Me.dgVentas.RootTable.Columns("Folio").FormatString = "#######"
        Me.dgVentas.RootTable.Columns("Folio").Caption = "Factura"

        Me.dgVentas.RootTable.Columns.Add("Referencia", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        'Me.dgVentas.RootTable.Columns("FolioSAP").FormatString = "##########"
        Me.dgVentas.RootTable.Columns("Referencia").Caption = "Referencia"


        Me.dgVentas.RootTable.Columns.Add("CodArticulo", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("CodArticulo").Caption = "Cod. Articulo"

        Me.dgVentas.RootTable.Columns.Add("Descripcion", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("Descripcion").Caption = "Descripción"

        Me.dgVentas.RootTable.Columns.Add("Cantidad", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("Cantidad").FormatString = "###,###"

        Me.dgVentas.RootTable.Columns.Add("Numero", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("Numero").FormatString = "###,###"
        Me.dgVentas.RootTable.Columns("Numero").Caption = "Talla"

        Me.dgVentas.RootTable.Columns.Add("PrecioUnit", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("PrecioUnit").FormatString = "c"
        Me.dgVentas.RootTable.Columns("PrecioUnit").Caption = "Importe"

        Me.dgVentas.RootTable.Columns.Add("Importe", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("Importe").FormatString = "c"
        Me.dgVentas.RootTable.Columns("Importe").Caption = "Total"


        Me.dgVentas.RootTable.Columns.Add("PDescuento", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("PDescuento").FormatString = "p"
        Me.dgVentas.RootTable.Columns("PDescuento").Caption = "% Descuento"

        Me.dgVentas.RootTable.Columns.Add("Descuento", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.NoEdit)
        Me.dgVentas.RootTable.Columns("Descuento").FormatString = "c"
    End Sub

    Private Sub frmVentasPorHora_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F9 Then
            Me.Cursor = Cursors.WaitCursor

            If Me.cmbTipoReporte.SelectedValue = "VT" Then

                ActionPreviewTotales()

            ElseIf Me.cmbTipoReporte.SelectedValue = "VD" Then

                ActionPreviewDetalle()

            Else

                MessageBox.Show("El reporte seleccionado no se puede imprimir", "DPTienda", MessageBoxButtons.OK)

            End If


            Me.Cursor = Cursors.Default

        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        ElseIf e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub ActionPreviewTotales()
        Try

            If Not Me.dsVentasPromedio Is Nothing Then

                Dim oARReporte As New rptVentasTotalesporHora(cmbCajas.Value, Format(ccmbFechaDel.Value, "dd/MM/yyyy"), Format(ccmbFechaAl.Value, "dd/MM/yyyy"), _
                ccmbHoraDel.Value, ccmbHoraAl.Value, dsVentasPromedio)

                Dim oReportViewer As New ReportViewerForm

                oARReporte.Document.Name = "Ventas en Totales por Hora"
                oARReporte.Run()

                oReportViewer.Report = oARReporte
                oReportViewer.Show()

                Try

                    oARReporte.Document.Print(True, True)

                Catch ex As Exception

                    Throw ex

                End Try

            End If

        Catch ex As Exception

            Throw ex

        End Try

    End Sub


    Private Sub ActionPreviewDetalle()
        Try

            If Not dsVentasPromedio Is Nothing Then

                Dim oARReporte As New rptVentasDetalleporHora(cmbCajas.Value, Format(ccmbFechaDel.Value, "dd/MM/yyyy"), Format(ccmbFechaAl.Value, "dd/MM/yyyy"), _
                ccmbHoraDel.Value, ccmbHoraAl.Value, dsVentasPromedio)

                Dim oReportViewer As New ReportViewerForm

                oARReporte.Document.Name = "Ventas Detalle por Hora"
                oARReporte.Run()
                oARReporte.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
                oReportViewer.Report = oARReporte
                oReportViewer.Show()

                Try

                    oARReporte.Document.Print(True, True)

                Catch ex As Exception

                    Throw ex

                End Try

            End If

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

End Class
