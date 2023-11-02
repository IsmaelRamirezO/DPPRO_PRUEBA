Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralTalla
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmAjustesTalla
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
    Friend WithEvents ebTipoVenta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ebCodCaja As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents ebFolioSAP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjustesTalla))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ebAjustes = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebFolioSAP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ebCodCaja = New Janus.Windows.EditControls.UIComboBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.ebTipoVenta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
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
        Me.ebAjustes.Controls.Add(Me.ebFolioSAP)
        Me.ebAjustes.Controls.Add(Me.Label20)
        Me.ebAjustes.Controls.Add(Me.ebCodCaja)
        Me.ebAjustes.Controls.Add(Me.lblLabel1)
        Me.ebAjustes.Controls.Add(Me.ebTipoVenta)
        Me.ebAjustes.Controls.Add(Me.Label23)
        Me.ebAjustes.Controls.Add(Me.Label2)
        Me.ebAjustes.Controls.Add(Me.Label19)
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
        Me.ebAjustes.Location = New System.Drawing.Point(0, 0)
        Me.ebAjustes.Name = "ebAjustes"
        Me.ebAjustes.Size = New System.Drawing.Size(752, 512)
        Me.ebAjustes.TabIndex = 0
        Me.ebAjustes.Text = "ExplorerBar1"
        Me.ebAjustes.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebFolioSAP
        '
        Me.ebFolioSAP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioSAP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioSAP.ButtonImage = CType(resources.GetObject("ebFolioSAP.ButtonImage"), System.Drawing.Image)
        Me.ebFolioSAP.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebFolioSAP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ebFolioSAP.Location = New System.Drawing.Point(520, 80)
        Me.ebFolioSAP.MaxLength = 20
        Me.ebFolioSAP.Name = "ebFolioSAP"
        Me.ebFolioSAP.Size = New System.Drawing.Size(120, 22)
        Me.ebFolioSAP.TabIndex = 4
        Me.ebFolioSAP.Text = "0"
        Me.ebFolioSAP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioSAP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(440, 80)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(128, 23)
        Me.Label20.TabIndex = 36
        Me.Label20.Text = "Factura SAP"
        '
        'ebCodCaja
        '
        Me.ebCodCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodCaja.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebCodCaja.Location = New System.Drawing.Point(88, 80)
        Me.ebCodCaja.Name = "ebCodCaja"
        Me.ebCodCaja.Size = New System.Drawing.Size(72, 20)
        Me.ebCodCaja.TabIndex = 2
        Me.ebCodCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(8, 80)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(100, 23)
        Me.lblLabel1.TabIndex = 34
        Me.lblLabel1.Text = "No. Caja"
        '
        'ebTipoVenta
        '
        Me.ebTipoVenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.ebTipoVenta.DesignTimeLayout = GridEXLayout1
        Me.ebTipoVenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTipoVenta.Location = New System.Drawing.Point(264, 80)
        Me.ebTipoVenta.Name = "ebTipoVenta"
        Me.ebTipoVenta.Size = New System.Drawing.Size(160, 22)
        Me.ebTipoVenta.TabIndex = 3
        Me.ebTipoVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTipoVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(168, 80)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(105, 23)
        Me.Label23.TabIndex = 28
        Me.Label23.Text = "Tipo de Venta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(688, 424)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Imprimir"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(672, 424)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(20, 13)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "F5"
        '
        'ebResponsable
        '
        Me.ebResponsable.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsable.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsable.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsable.Enabled = False
        Me.ebResponsable.Location = New System.Drawing.Point(88, 112)
        Me.ebResponsable.MaxLength = 10
        Me.ebResponsable.Name = "ebResponsable"
        Me.ebResponsable.Size = New System.Drawing.Size(72, 20)
        Me.ebResponsable.TabIndex = 5
        Me.ebResponsable.TabStop = False
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
        Me.ebNombreResponsable.Location = New System.Drawing.Point(168, 112)
        Me.ebNombreResponsable.MaxLength = 10
        Me.ebNombreResponsable.Name = "ebNombreResponsable"
        Me.ebNombreResponsable.Size = New System.Drawing.Size(376, 20)
        Me.ebNombreResponsable.TabIndex = 6
        Me.ebNombreResponsable.TabStop = False
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
        Me.UiGroupBox1.Size = New System.Drawing.Size(632, 48)
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
        Me.CalendarCombo1.Location = New System.Drawing.Point(536, 16)
        Me.CalendarCombo1.Name = "CalendarCombo1"
        Me.CalendarCombo1.ShowDropDown = False
        Me.CalendarCombo1.Size = New System.Drawing.Size(88, 20)
        Me.CalendarCombo1.TabIndex = 10
        Me.CalendarCombo1.TabStop = False
        Me.CalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(448, 13)
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
        Me.Label18.Location = New System.Drawing.Point(544, 424)
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
        Me.Label17.Location = New System.Drawing.Point(528, 424)
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
        Me.Label16.Location = New System.Drawing.Point(624, 424)
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
        Me.Label15.Location = New System.Drawing.Point(600, 424)
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
        Me.Label14.Location = New System.Drawing.Point(160, 424)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Borrar"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(120, 424)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "SUPR"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(408, 424)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Guardar/Imprimir"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(392, 424)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "F9"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(344, 424)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Grabar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(328, 424)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "F2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(251, 424)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Seleccionar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(208, 424)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Alt + S"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(112, 368)
        Me.txtObservaciones.MaxLength = 255
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(536, 40)
        Me.txtObservaciones.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 368)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Observaciones"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 336)
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
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.grdProductos.DesignTimeLayout = GridEXLayout2
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
        Me.grdProductos.Location = New System.Drawing.Point(8, 144)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdProductos.Size = New System.Drawing.Size(736, 184)
        Me.grdProductos.TabIndex = 7
        Me.grdProductos.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate
        Me.grdProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 112)
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
        Me.nbTotalArticulos.Location = New System.Drawing.Point(112, 336)
        Me.nbTotalArticulos.Name = "nbTotalArticulos"
        Me.nbTotalArticulos.Size = New System.Drawing.Size(96, 20)
        Me.nbTotalArticulos.TabIndex = 8
        Me.nbTotalArticulos.TabStop = False
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
        Me.Label21.Location = New System.Drawing.Point(8, 424)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(47, 13)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "INSERT"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(56, 424)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 13)
        Me.Label22.TabIndex = 9
        Me.Label22.Text = "Agregar"
        '
        'frmAjustesTalla
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(744, 446)
        Me.Controls.Add(Me.ebAjustes)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(760, 500)
        Me.MinimumSize = New System.Drawing.Size(760, 440)
        Me.Name = "frmAjustesTalla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajustes de Talla"
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
    Dim oAjusteMgr As AjusteGeneralTallaManager
    Dim oAjuste As AjusteGeneralTallaInfo

    Dim dsCatalogoArticulos As DataSet
    Dim oCatalogoArticulosMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    Dim dsTallas As DataSet
    Dim oFacturaMgr As FacturaManager
    Dim oFacturaCorridaMgr As FacturaCorridaManager
    Dim oFactura As Factura


    Dim bolLoadForm As Boolean
    Dim intRecordActual As Integer

    ''MgrSAP
    Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

#End Region

#Region "Propiedades"
    Private m_blReajuste As Boolean = False

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

    Private Sub frmAjustesTalla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.InicializarObjetos()
    End Sub

    Private Sub grdProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        Select Case e.KeyCode
            Case Keys.Insert
                AgregarCodigo()
            Case Keys.Delete
                Me.bolLoadForm = False
                Dim intRecord As Integer = Me.grdProductos.Row
                Me.oAjuste.Detalle.Rows.RemoveAt(intRecord)
                Me.oAjuste.Detalle.AcceptChanges()
                Me.bolLoadForm = True
            Case e.Alt And Keys.S

                If grdProductos.Col = 0 AndAlso (IsDBNull(grdProductos.GetValue(0)) OrElse CStr(grdProductos.GetValue(0)) = String.Empty) Then
                    Dim strCodArticulo As String = LoadSearchArticulo()
                    If Not strCodArticulo = String.Empty Then
                        grdProductos.SetValue(0, strCodArticulo)
                    End If


                End If

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
        Dim oAjustesOpenRecordDialogView As New AjusteTallaOpenRecordDialogView
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

    Private Sub frmAjustesTalla_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        bolLoadForm = False
    End Sub

    Private Sub grdProductos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.GotFocus
        If Me.oAjuste.Detalle.Rows.Count = 0 Then
            AgregarCodigo()
        End If
    End Sub

    Private Sub frmAjustesTalla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                If Me.grdProductos.Enabled Then
                    Guardar(False)
                Else
                    MessageBox.Show("No se permite modificar ajustes", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case Keys.F4
                'Nuevo
                InicializarObjetos()

            Case Keys.F9
                If Me.grdProductos.Enabled Then
                    Guardar(True)
                Else
                    MessageBox.Show("No se permite modificar ajustes", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case Keys.Escape
                bolLoadForm = True
                Me.Close()
            Case Keys.F5
                If Not Me.grdProductos.Enabled Then
                    ActionPrintAjuste()
                End If

            Case Keys.Enter

                SendKeys.Send("{TAB}")

        End Select
    End Sub

#End Region

#Region "Procedimientos Programador"

    Private Sub InicializarObjetos()
        bolLoadForm = False
        Reajuste = False
        oAjusteMgr = New AjusteGeneralTallaManager(oAppContext)
        oAjuste = oAjusteMgr.Create()
        oFacturaMgr = New FacturaManager(oAppContext)
        oFacturaCorridaMgr = New FacturaCorridaManager(oAppContext)

        '''Obtenemos el Responsable del Movimiento. (El que se logea)
        Me.ebResponsable.Text = UCase(oAppContext.Security.CurrentUser.SessionLoginName)
        Me.ebNombreResponsable.Text = UCase(oAppContext.Security.CurrentUser.Name)
        Me.nbFolio.Value = Me.oAjusteMgr.GetFolio()

        ''''Asignamos DataSource a Grid
        oAjuste.Detalle.Columns("Cantidad").DefaultValue = 0
        oAjuste.Detalle.Columns("TallaS").DefaultValue = String.Empty
        oAjuste.Detalle.Columns("TallaE").DefaultValue = String.Empty
        oAjuste.Detalle.Columns("FolioSAP").DefaultValue = String.Empty
        oAjuste.Detalle.Columns("Codigo").DefaultValue = String.Empty
        oAjuste.Detalle.Columns("Reversa").DefaultValue = 0
        oAjuste.Detalle.Columns("Tipo").DefaultValue = "CT"
        oAjuste.Detalle.Columns("CantDevuelta").DefaultValue = 0

        oAjuste.Detalle.AcceptChanges()
        Me.grdProductos.DataSource = oAjuste.Detalle
        AddHandler oAjuste.Detalle.ColumnChanging, New DataColumnChangeEventHandler(AddressOf Column_Changing)

        '''Llenamos Catalogo Articulos.
        Me.oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)
        dsCatalogoArticulos = Me.oCatalogoArticulosMgr.GetAll(False)
        Me.dsCatalogoArticulos.Tables(0).Columns("Código").ColumnName = "Codigo"
        Me.grdProductos.DropDowns(0).SetDataBinding(Me.dsCatalogoArticulos, Me.dsCatalogoArticulos.Tables(0).TableName)

        '''Llenamos el combo tipo de venta
        Sm_FillCmbTipoVenta()

        '''Llenamos el combo de Cajas
        FillCaja()

        Me.txtObservaciones.Text = String.Empty
        Me.ebFolioSAP.Text = ""
        Me.ebFolioSAP.Text.PadLeft(10, "0")
        Me.nbTotalArticulos.Value = 0
        Me.ebTipoVenta.Text = ""
        Me.ebCodCaja.Text = ""

        Me.grdProductos.Enabled = True
        Me.txtObservaciones.Enabled = True
        Me.nbFolio.Focus()
        bolLoadForm = True
    End Sub

    Private Sub AbrirAjuste()
        Try
            oAjusteMgr.LoadInto(Me.nbFolio.Value, Me.oAjuste)
            oAjuste.Detalle.AcceptChanges()
            Me.grdProductos.DataSource = oAjuste.Detalle
            AddHandler oAjuste.Detalle.ColumnChanging, New DataColumnChangeEventHandler(AddressOf Column_Changing)

            If Me.oAjuste.FolioAjuste = 0 Then
                MessageBox.Show("El folio no existe", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.InicializarObjetos()
                Me.ebCodCaja.Focus()
            Else
                Me.ebResponsable.Text = Me.oAjuste.Usuario
                Me.txtObservaciones.Text = Me.oAjuste.Observaciones
                Me.nbTotalArticulos.Value = Me.oAjuste.TotalCodigos
                Me.nbFolio.Value = Me.oAjuste.FolioAjuste

                Me.grdProductos.Enabled = False
                Me.txtObservaciones.Enabled = False

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
                    Case UCase("TallaS")
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue = String.Empty Then
                            MessageBox.Show("Capture la Talla", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                        If Not FindTalla(e.ProposedValue) Then
                            MessageBox.Show("La talla no pertecene al Articulo.- " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            If IsDBNull(e.Row("TallaS")) OrElse e.Row("TallaS") = String.Empty Then
                                e.ProposedValue = ""
                            Else
                                e.ProposedValue = e.Row("TallaS")
                            End If
                        Else
                            If BuscaCodigoEnAjuste(e.Row("Codigo"), e.ProposedValue, e.Row("TallaE"), Me.grdProductos.Row) > 0 Then
                                MessageBox.Show("El Aticulo ya se encuentra con esa Talla " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.grdProductos.Focus()
                                e.ProposedValue = e.Row("TallaS")
                            End If
                        End If
                        Me.grdProductos.Focus()
                    Case UCase("Cantidad")
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue = 0 Then
                            MessageBox.Show("Capture Cantidad al articulo.- " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.grdProductos.Focus()
                            Exit Sub
                        End If
                    Case UCase("TallaE")
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue = String.Empty Then
                            MessageBox.Show("Capture la Talla", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                        If Not FindTalla(e.ProposedValue) Then
                            MessageBox.Show("La talla no pertecene al Articulo.- " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            If IsDBNull(e.Row("TallaE")) OrElse e.Row("TallaE") = String.Empty Then
                                e.ProposedValue = ""
                            Else
                                e.ProposedValue = e.Row("TallaE")
                            End If
                            Me.grdProductos.Focus()
                        Else
                            If (e.Row("TallaS") = e.ProposedValue) Then
                                e.ProposedValue = ""
                                MessageBox.Show("La talla nueva debe de ser diferente", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.grdProductos.Focus()
                            Else
                                If BuscaCodigoEnAjuste(e.Row("Codigo"), e.Row("TallaS"), e.ProposedValue, Me.grdProductos.Row) > 0 Then
                                    MessageBox.Show("El Aticulo ya se encuentra con esa Talla " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.grdProductos.Focus()
                                    e.ProposedValue = e.Row("TallaE")
                                End If
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

    Private Function BuscaCodigoEnAjuste(ByVal strCodigo As String, ByVal strTallaS As String, ByVal strTallaE As String, ByVal nRowG As Integer) As Integer

        Dim oRow As DataRow
        Dim nRow As Integer = 0

        For Each oRow In Me.oAjuste.Detalle.Rows

            nRow = nRow + 1

            If (nRow - 1) <> nRowG AndAlso oRow("Codigo") = strCodigo AndAlso oRow("TallaS") = strTallaS AndAlso oRow("TallaE") = strTallaE Then

                Return nRow

            End If

        Next

        Return 0

    End Function

    Private Sub AgregarCodigo()
        Me.bolLoadForm = False
        Dim oNewRow As DataRow = Me.oAjuste.Detalle.NewRow
        oAjuste.Detalle.Rows.Add(oNewRow)
        oAjuste.Detalle.AcceptChanges()
        Me.grdProductos.Row = oAjuste.Detalle.Rows.Count - 1
        Me.grdProductos.Col = 0
        Me.bolLoadForm = True
    End Sub

    Public Sub Guardar(Optional ByVal Print As Boolean = True)
        '********************************************************************
        If Reajuste Then
            MessageBox.Show("Tienes que Hacer un Nuevo Ajuste", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '********************************************************************
        If oAjuste.Detalle.Rows.Count <= 0 Then
            MessageBox.Show("No hay Articulos a Ajustar", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ValidaAllRecord() Then

        ElseIf Me.txtObservaciones.Text.Trim = String.Empty Then
            MessageBox.Show("Capture observaciones", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtObservaciones.Focus()
        ElseIf Me.ebFolioSAP.Text = "" OrElse CDbl(Me.ebFolioSAP.Text) = 0 Then
            MessageBox.Show("Es necesario capturar el folio de la factura", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebFolioSAP.Focus()
        ElseIf ValidaCodigosFactura() = False Then

        ElseIf ValidaExistenciasCambiosTalla() = False Then

        Else

            Dim dtNegados As DataTable
            Dim UserNameNiega As String = ""
            Dim dtDefectuososEC As DataTable 'Tabla con los codigos baja calidad EC que el player selecciono que van en la venta
            Dim UserNameDesmarca As String = ""
            Dim dtDefecECSAP As DataTable 'Tabla con los codigos baja calidad EC marcados en SAP

            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 07/05/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
            '-----------------------------------------------------------------------------------------------------------------------------
            Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
            Dim dtMateriales As DataTable = GetDataTableFormatNegadosSH(oAjuste.Detalle)
            If ValidarMaterialesNegadosSH(dtMateriales, dtNegadosSH, "PF,P,RP") = False Then
                ShowFormNegadosSH(dtNegadosSH)
                Exit Sub
            End If

            '-----------------------------------------------------------------------------------------------------------------------------------
            'Validamos si los codigos del traspaso estan marcados como defectuosos para Ecommerce
            '-----------------------------------------------------------------------------------------------------------------------------------
            Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(oAjuste.Detalle, dtMateriales)
            If ValidarMaterialesDefectuososEC(dtArticuloLibre, dtDefectuososEC, UserNameDesmarca, "TS", dtDefecECSAP) = False Then
                Exit Sub
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------
            'Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle del traspaso
            '-----------------------------------------------------------------------------------------------------------------------------------
            If ValidarMaterialesParaNegarEC(dtNegados, dtArticuloLibre, dtDefectuososEC, dtDefecECSAP, UserNameDesmarca, "TS") = False Then
                Exit Sub
            End If

            Me.oAjuste.FolioAjuste = Me.nbFolio.Value
            Me.oAjuste.Almacen = oAppContext.ApplicationConfiguration.Almacen
            Me.oAjuste.Observaciones = Me.txtObservaciones.Text

            'Para que llene en todos los registros el folio SAP
            For Each oRow As DataRow In oAjuste.Detalle.Rows
                oAjuste.Codigo = oRow!codigo
                oAjuste.Cantidad = oRow!cantidad
                oAjuste.Talla_S = oRow!TallaS
                oAjuste.Talla_E = oRow!TallaE
                '------------------------------------
                oSap.Write_AJUSTETalla(oAjuste)
                '------------------------------------
                oRow!foliosap = oAjuste.FolioSAP
            Next
            'Para ver que se haya grabado por lo menos un ajuste en SAP
            oAjuste.TotalCodigos = 0
            For Each oRow As DataRow In oAjuste.Detalle.Rows
                If oRow!foliosap <> String.Empty Then
                    oAjuste.TotalCodigos += 1
                End If
            Next
            '------------------------------------------------------
            '--------------------------------------------------------------------------------------------------------------------------
            'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario
            '--------------------------------------------------------------------------------------------------------------------------
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            If oConfigCierreFI.SurtirEcommerce Then
                If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                    oSAPMgr.ZPOL_TRASL_NEGAR(ebFolioSAP.Text, "CT", UserNameNiega, dtNegados)
                    ValidarCambioStatusPedidoTS(dtNegados, UserNameNiega)
                End If
            End If
            '--------------------------------------------------------------------------------------------------------------------------
            'Se desmarcan los codigos marcados como defectuosos para ecommerce que van en el cambio de talla
            '--------------------------------------------------------------------------------------------------------------------------
            If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                oSAPMgr.ZPOL_DEFECTUOSOS_INS(ebFolioSAP.Text, "DD", UserNameDesmarca, dtDefectuososEC)
            End If


            If oAjuste.TotalCodigos <> 0 Then
                Me.oAjuste.Usuario = Me.ebResponsable.Text
                Me.oAjuste.Observaciones = Me.txtObservaciones.Text
                Me.oAjuste.FolioFacturaSAP = Trim(Me.ebFolioSAP.Text).PadLeft(10, "0")
                Me.oAjusteMgr.Save(Me.oAjuste)
                Me.nbFolio.Value = Me.oAjuste.FolioAjuste
                Me.oAjusteMgr.PutMovimiento(Me.oAjuste, "E")
                Me.oAjusteMgr.PutMovimiento(Me.oAjuste, "S")
                MessageBox.Show("Ajuste guardado con Folio: " & Me.oAjuste.FolioAjuste, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reajuste = True
                If Print Then
                    ActionPrintAjuste()
                End If
            Else
                MessageBox.Show("Ningun Ajuste se Guardo en SAP", "Ajustes Talla", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Function ValidaExistenciasCambiosTalla() As Boolean

        For Each oRow As DataRow In oAjuste.Detalle.Rows

            If oAjusteMgr.ValidaExistenciasCambiosTalla(Trim(Me.ebFolioSAP.Text), oRow("TallaE"), oRow("Codigo"), oRow("Cantidad")) = False Then

                Return False

            End If

        Next

        Return True

    End Function

    Public Sub ActionPrintAjuste()

        Dim iRep As AjusteTallaRpt
        Dim iView As ReportViewerForm

        iRep = New AjusteTallaRpt
        iView = New ReportViewerForm
        iRep.DataSource = oAjuste.Detalle

        iRep.Titulo = "REPORTE DE AJUSTES DE TALLA"
        iRep.Folio = oAjuste.FolioAjuste
        iRep.Fecha = oAjuste.FechaAjuste
        iRep.Usuario = oAjuste.Usuario

        '''Asigno Almacen.
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        oAlmacen = oAlmacenMgr.Create
        oAlmacen = oAlmacenMgr.Load(Me.oAjuste.Almacen)
        iRep.CodigoAlmacen = oAjuste.Almacen
        iRep.NombreAlmacen = oAlmacen.Descripcion
        '''Asigno Almacen.

        iRep.Observaciones = oAjuste.Observaciones
        iRep.Run()
        iView.Report = iRep
        iView.ShowDialog()
    End Sub


    Private Function ValidaAllRecord() As Boolean
        If bolLoadForm = False Then
            Exit Function
        End If
        Dim i As Integer = 0
        For Each oRow As DataRow In Me.oAjuste.Detalle.Rows

            ActualizaDatosArticulo(oRow, oRow!Codigo)
            If IsDBNull(oRow!TallaS) OrElse oRow!TallaS = String.Empty Then
                MessageBox.Show("Capture Talla para el articulo " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.grdProductos.Select()
                Me.grdProductos.Focus()
                Me.grdProductos.Row = i
                Me.grdProductos.Col = 2
                Return True
                Exit For
            Else
                If IsDBNull(oRow!TallaE) OrElse oRow!TallaE = String.Empty Then
                    MessageBox.Show("Capture Talla para el articulo " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.grdProductos.Select()
                    Me.grdProductos.Focus()
                    Me.grdProductos.Row = i
                    Me.grdProductos.Col = 3
                    Return True
                    Exit For
                Else
                    If Not FindTalla(oRow!TallaS) Then
                        MessageBox.Show("La talla no pertecene al Articulo.- " & oRow("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.grdProductos.Select()
                        Me.grdProductos.Focus()
                        Me.grdProductos.Row = i
                        Me.grdProductos.Col = 2
                        Return True
                        Exit For
                    Else
                        If BuscaCodigoEnAjuste(oRow("Codigo"), oRow!TallaS, oRow!TallaE, i) > 0 Then
                            MessageBox.Show("La talla ya fue asignada al Articulo.-  " & oRow("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.grdProductos.Select()
                            Me.grdProductos.Focus()
                            Me.grdProductos.Row = i
                            Me.grdProductos.Col = 2
                            Return True
                            Exit For
                        Else
                            If Not FindTalla(oRow!TallaE) Then
                                MessageBox.Show("La talla no pertecene al Articulo.- " & oRow("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.grdProductos.Select()
                                Me.grdProductos.Focus()
                                Me.grdProductos.Row = i
                                Me.grdProductos.Col = 3
                                Return True
                                Exit For
                            Else
                                If oRow!TallaE = oRow!TallaS Then
                                    MessageBox.Show("Las Tallas deben ser diferentes .- " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.grdProductos.Select()
                                    Me.grdProductos.Focus()
                                    Me.grdProductos.Row = i
                                    Me.grdProductos.Col = 3
                                    Return True
                                    Exit For
                                Else
                                    If IsDBNull(oRow!Cantidad) OrElse oRow!Cantidad = 0 Then
                                        MessageBox.Show("Capture Cantidad para el Articulo.- " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Me.grdProductos.Select()
                                        Me.grdProductos.Focus()
                                        Me.grdProductos.Row = i
                                        Me.grdProductos.Col = 4
                                        Return True
                                        Exit For
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            i += 1
        Next
        Return False
    End Function

#End Region

    Private Sub Sm_FillCmbTipoVenta()

        Dim oTipoVentaMgr As New TiposVentaManager(oAppContext)

        Dim dsTipoVenta As DataSet = oTipoVentaMgr.Load()

        Dim dv As DataView
        If oAppContext.ApplicationConfiguration.Almacen = "053" Then
            'dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta = 'V' or CodTipoVenta = 'A' or CodTipoVenta = 'K' OR CodTipoVenta = 'F' OR CodTipoVenta = 'S' OR CodTipoVenta = 'P' OR CodTipoVenta = 'I'", "CodTipoventa desc", DataViewRowState.CurrentRows)
            '--------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 16/10/2014: Se elimino de los codigos tipo venta los socios y se agregaron los DIPS
            '--------------------------------------------------------------------------------------------------------------

            dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta = 'V' or CodTipoVenta = 'A' or CodTipoVenta = 'K' OR CodTipoVenta = 'F' OR CodTipoVenta = 'D' OR CodTipoVenta = 'P' OR CodTipoVenta = 'I'", "CodTipoventa desc", DataViewRowState.CurrentRows)
        Else
            dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta <> 'S'", "CodTipoventa desc", DataViewRowState.CurrentRows)
        End If

        ebTipoVenta.DataSource = dv
        'ebTipoVenta.DataMember = dsTipoVenta.Tables(0).TableName

        ebTipoVenta.DisplayMember = "Descripcion"
        ebTipoVenta.ValueMember = "CodTipoVenta"

        oTipoVentaMgr.Dispose()

    End Sub

    Private Sub FillCaja()

        'Objeto Caja
        Dim oCajaMgr As CatalogoCajaManager
        oCajaMgr = New CatalogoCajaManager(oAppContext)

        Dim dsCaja As New DataSet
        Dim nReg As Integer, i As Integer

        dsCaja = oCajaMgr.GetAll(True)

        nReg = dsCaja.Tables(0).Rows.Count

        If nReg > 0 Then

            For i = 0 To nReg - 1

                ebCodCaja.Items.Add(dsCaja.Tables(0).Rows(i).Item("CodCaja"))

            Next i

            dsCaja = Nothing

            ebCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja

        End If

        oCajaMgr.Dispose()
        oCajaMgr = Nothing

    End Sub

    Private Sub ebFacturaCod_ButtonClick1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Sm_BuscarFactura("PRO", True)

    End Sub

    Private Function ValidaCodigosFactura() As Boolean

        For Each oRow As DataRow In oAjuste.Detalle.Rows
            For Each oRowDF As DataRow In oFactura.Detalle.Tables(0).Rows
                If Trim(UCase(oRow.Item("Codigo"))) = Trim(UCase(oRowDF.Item("CodArticulo"))) Then
                    GoTo Sigue
                End If
            Next
            MsgBox("El articulo " & oRow.Item("Codigo") & " no pertenece a la factura " & Me.ebFolioSAP.Text, MsgBoxStyle.Exclamation, "Dportenis PRO")
            Return False
Sigue:
        Next

        Return True
    End Function

    Private Sub ebFolioSAP_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFolioSAP.ButtonClick

        Sm_BuscarFactura("FolioSAP", True)

    End Sub

    Private Sub Sm_BuscarFactura(ByVal TipoFolio As String, Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        '<Validacón>

        If (Me.ebCodCaja.Text = String.Empty) Then

            MsgBox("No ha sido seleccionad un código de caja.", MsgBoxStyle.Exclamation, "DPortenis Pro")
            Exit Sub

        ElseIf Trim(Me.ebTipoVenta.Text) = "" Then

            MsgBox("No ha sido seleccionado un tipo de venta", MsgBoxStyle.Exclamation, "DPortenis Pro")
            Exit Sub

        End If

        '<Validación>


        If (Vpa_bolOpenRecordDialog = True) Then


            'Dim oCancelarFacturaMgr As CancelaFacturaManager
            'oCancelarFacturaMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

            Dim oOpenRecordDlg As New OpenRecordDialog

            Dim oFacturaOpenRecordDialogView As New FacturaOpenRecordDialogView
            oFacturaOpenRecordDialogView.TipoVenta = Me.ebTipoVenta.Value
            oOpenRecordDlg.CurrentView = oFacturaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()
            'me quede en probar el abrir de los folios de las facturas
            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                If TipoFolio = "FolioPro" Then
                    'Me.ebFolioFactura.Value = oOpenRecordDlg.Record.Item("FolioFactura")
                Else
                    Me.ebFolioSAP.Text = oOpenRecordDlg.Record.Item("FolioSAP")
                End If

            End If

        End If

        If ebFolioSAP.Text <> "0" And ebFolioSAP.Text <> "" Then

            'If oFacturaMgr Is Nothing Then

            'oFacturaMgr = New FacturaManager(oAppContext)

            'End If
            oFactura = oFacturaMgr.Create
            oFactura.ClearFields()

            'If ebFolioFactura.Value > 0 Then
            'oFacturaMgr.Load(ebFolioFactura.Value, ebCodCaja.Text, oFactura)
            'Else
            Dim dsFolioCaja As DataSet
            dsFolioCaja = New DataSet

            dsFolioCaja = oFacturaMgr.SelectFolioCaja(ebFolioSAP.Text)
            If dsFolioCaja.Tables(0).Rows.Count > 0 Then
                oFacturaMgr.Load(dsFolioCaja.Tables(0).Rows(0)("FolioFactura"), dsFolioCaja.Tables(0).Rows(0)("CodCaja"), oFactura)
                ebCodCaja.Text = dsFolioCaja.Tables(0).Rows(0)("CodCaja")
            Else
                GoTo No_Existe
            End If
            'End If

            If oFactura.FacturaID > 0 Then

                If ValidaFactura() Then

                    'Cargamos los Articulos del Detalle
                    oFactura.Detalle = oFacturaCorridaMgr.Load(oFactura.FacturaID)

                    SendKeys.Send("{TAB}")

                Else

                    Me.ebFolioSAP.Text = ""
                    Me.ebFolioSAP.Text.PadLeft(10, "0")
                    Me.ebFolioSAP.Focus()

                End If

            Else
No_Existe:
                MsgBox("Folio de Factura NO EXISTE.  ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "DPortenis Pro")

                'btnAceptar.Enabled = False
                Me.ebFolioSAP.Focus()

            End If

        Else

            'btnAceptar.Enabled = False
            ebFolioSAP.Text = ""
            ebFolioSAP.Text.PadLeft(10, "0")

        End If

    End Sub

    Private Function ValidaFactura() As Boolean

        If oFactura.StatusFactura = "CAN" Then

            MsgBox("Factura " & ebFolioSAP.Text.PadLeft(10, "0") & " está CANCELADA. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "DPortenis Pro")
            Return False

        End If

        Return True

    End Function

    Private Sub ebFolioSAP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebFolioSAP.KeyDown

        If e.Alt AndAlso e.KeyCode = Keys.S Then
            Sm_BuscarFactura("FolioSAP", True)
            'Me.ebFolioSAP.Focus()
        End If

    End Sub

    Private Sub ebFolioSAP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioSAP.Validating
        Sm_BuscarFactura("FolioSAP", False)
    End Sub

#Region "Facturacion SiHay"

    Private Function GetDataTableFormatNegadosSH(ByVal traspaso As DataTable) As DataTable
        Dim dtArticulos As New DataTable
        dtArticulos.Columns.Add("Codigo", GetType(String))
        dtArticulos.Columns.Add("Talla", GetType(String))
        dtArticulos.Columns.Add("Cantidad", GetType(Integer))
        For Each oRow As DataRow In traspaso.Rows
            Dim row As DataRow = dtArticulos.NewRow()
            row("Codigo") = CStr(oRow!Codigo)
            row("Talla") = CStr(oRow!TallaS)
            row("Cantidad") = CInt(oRow!Cantidad)
            dtArticulos.Rows.Add(row)
        Next
        Return dtArticulos
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 08/05/2013: Envia el detalle con las cantidades libres Negadas
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function GetDetalleCantidadesLibres(ByVal dtDetalles As DataTable, ByVal dtMaterialesLibres As DataTable) As DataTable
        Dim dtArticulosLibres As DataTable = dtDetalles.Copy()
        dtArticulosLibres.Columns.Add("Libres", GetType(Integer))
        dtArticulosLibres.Columns("Codigo").ColumnName = "CodArticulo"
        dtArticulosLibres.Columns("TallaS").ColumnName = "Talla"
        If Not dtMaterialesLibres Is Nothing Then
            For Each row As DataRow In dtArticulosLibres.Rows
                Dim codigo As String = CStr(row!CodArticulo)
                Dim talla As String = CStr(row!Talla)
                Dim cantidad As Integer = CInt(row!Cantidad)
                Dim suma As Decimal = dtMaterialesLibres.Compute("SUM(Libres)", "Codigo='" & codigo & "' AND Talla='" & talla & "'")
                row("Libres") = suma
            Next
            dtArticulosLibres.AcceptChanges()
        End If
        Return dtArticulosLibres
    End Function

#End Region

End Class
