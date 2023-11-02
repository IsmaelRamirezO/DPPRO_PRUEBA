Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes


Public Class EstadoCuentaContratoReportForm
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
    Friend WithEvents uIGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ebTalla As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigoDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolioContrato As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblLabel8 As System.Windows.Forms.Label
    Friend WithEvents lblLabel7 As System.Windows.Forms.Label
    Friend WithEvents lblLabel6 As System.Windows.Forms.Label
    Friend WithEvents lblLabel5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents lblLabel3 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents ebNombrePlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombreCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents uIGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents grdAbonos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbCajas As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadoCuentaContratoReportForm))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.uIGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grdAbonos = New Janus.Windows.GridEX.GridEX()
        Me.uIGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbCajas = New Janus.Windows.EditControls.UIComboBox()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.ebSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebTalla = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombrePlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombreCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodigoDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFolioContrato = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblLabel8 = New System.Windows.Forms.Label()
        Me.lblLabel7 = New System.Windows.Forms.Label()
        Me.lblLabel6 = New System.Windows.Forms.Label()
        Me.lblLabel5 = New System.Windows.Forms.Label()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.lblLabel3 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.uIGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uIGroupBox2.SuspendLayout()
        CType(Me.grdAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uIGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.uIGroupBox2)
        Me.explorerBar1.Controls.Add(Me.uIGroupBox1)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(693, 508)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'uIGroupBox2
        '
        Me.uIGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.uIGroupBox2.Controls.Add(Me.Label3)
        Me.uIGroupBox2.Controls.Add(Me.Label7)
        Me.uIGroupBox2.Controls.Add(Me.Label4)
        Me.uIGroupBox2.Controls.Add(Me.Label5)
        Me.uIGroupBox2.Controls.Add(Me.Label2)
        Me.uIGroupBox2.Controls.Add(Me.Label6)
        Me.uIGroupBox2.Controls.Add(Me.grdAbonos)
        Me.uIGroupBox2.Location = New System.Drawing.Point(6, 249)
        Me.uIGroupBox2.Name = "uIGroupBox2"
        Me.uIGroupBox2.Size = New System.Drawing.Size(680, 256)
        Me.uIGroupBox2.TabIndex = 2
        Me.uIGroupBox2.Text = "Listado Detallado de Abonos"
        Me.uIGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(40, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 16)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Nueva Consulta"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(16, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 24)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "F5"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(624, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Salir"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(592, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 24)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Esc"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(216, 232)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Imprimir"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(192, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 24)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "F9"
        '
        'grdAbonos
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdAbonos.DesignTimeLayout = GridEXLayout1
        Me.grdAbonos.Enabled = False
        Me.grdAbonos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAbonos.GroupByBoxVisible = False
        Me.grdAbonos.Location = New System.Drawing.Point(8, 24)
        Me.grdAbonos.Name = "grdAbonos"
        Me.grdAbonos.Size = New System.Drawing.Size(664, 200)
        Me.grdAbonos.TabIndex = 0
        Me.grdAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uIGroupBox1
        '
        Me.uIGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.uIGroupBox1.Controls.Add(Me.cbCajas)
        Me.uIGroupBox1.Controls.Add(Me.lblCaja)
        Me.uIGroupBox1.Controls.Add(Me.ebSaldo)
        Me.uIGroupBox1.Controls.Add(Me.ebImporte)
        Me.uIGroupBox1.Controls.Add(Me.ebTalla)
        Me.uIGroupBox1.Controls.Add(Me.ebFecha)
        Me.uIGroupBox1.Controls.Add(Me.ebNombrePlayer)
        Me.uIGroupBox1.Controls.Add(Me.ebNombreCliente)
        Me.uIGroupBox1.Controls.Add(Me.ebPlayer)
        Me.uIGroupBox1.Controls.Add(Me.ebCliente)
        Me.uIGroupBox1.Controls.Add(Me.ebCodigoDescripcion)
        Me.uIGroupBox1.Controls.Add(Me.ebCodigo)
        Me.uIGroupBox1.Controls.Add(Me.ebFolioContrato)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel8)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel7)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel6)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel5)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel4)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel3)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel2)
        Me.uIGroupBox1.Controls.Add(Me.Label1)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel1)
        Me.uIGroupBox1.Location = New System.Drawing.Point(6, 37)
        Me.uIGroupBox1.Name = "uIGroupBox1"
        Me.uIGroupBox1.Size = New System.Drawing.Size(680, 206)
        Me.uIGroupBox1.TabIndex = 1
        Me.uIGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'cbCajas
        '
        Me.cbCajas.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbCajas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCajas.Location = New System.Drawing.Point(110, 24)
        Me.cbCajas.Name = "cbCajas"
        Me.cbCajas.ReadOnly = True
        Me.cbCajas.Size = New System.Drawing.Size(56, 22)
        Me.cbCajas.TabIndex = 0
        Me.cbCajas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblCaja
        '
        Me.lblCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaja.Location = New System.Drawing.Point(8, 24)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(48, 16)
        Me.lblCaja.TabIndex = 31
        Me.lblCaja.Text = "Caja"
        '
        'ebSaldo
        '
        Me.ebSaldo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldo.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSaldo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSaldo.Location = New System.Drawing.Point(570, 109)
        Me.ebSaldo.Name = "ebSaldo"
        Me.ebSaldo.ReadOnly = True
        Me.ebSaldo.Size = New System.Drawing.Size(104, 22)
        Me.ebSaldo.TabIndex = 10
        Me.ebSaldo.TabStop = False
        Me.ebSaldo.Text = "$0.00"
        Me.ebSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebImporte
        '
        Me.ebImporte.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebImporte.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebImporte.BackColor = System.Drawing.Color.Ivory
        Me.ebImporte.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebImporte.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebImporte.Location = New System.Drawing.Point(570, 81)
        Me.ebImporte.Name = "ebImporte"
        Me.ebImporte.ReadOnly = True
        Me.ebImporte.Size = New System.Drawing.Size(104, 22)
        Me.ebImporte.TabIndex = 9
        Me.ebImporte.TabStop = False
        Me.ebImporte.Text = "$0.00"
        Me.ebImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebImporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTalla
        '
        Me.ebTalla.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTalla.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTalla.BackColor = System.Drawing.Color.Ivory
        Me.ebTalla.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTalla.Location = New System.Drawing.Point(398, 80)
        Me.ebTalla.Name = "ebTalla"
        Me.ebTalla.ReadOnly = True
        Me.ebTalla.Size = New System.Drawing.Size(96, 22)
        Me.ebTalla.TabIndex = 8
        Me.ebTalla.TabStop = False
        Me.ebTalla.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebTalla.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.Color.Ivory
        Me.ebFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecha.Location = New System.Drawing.Point(569, 24)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(106, 22)
        Me.ebFecha.TabIndex = 7
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombrePlayer
        '
        Me.ebNombrePlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombrePlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombrePlayer.BackColor = System.Drawing.Color.Ivory
        Me.ebNombrePlayer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombrePlayer.Location = New System.Drawing.Point(214, 164)
        Me.ebNombrePlayer.Name = "ebNombrePlayer"
        Me.ebNombrePlayer.ReadOnly = True
        Me.ebNombrePlayer.Size = New System.Drawing.Size(280, 22)
        Me.ebNombrePlayer.TabIndex = 6
        Me.ebNombrePlayer.TabStop = False
        Me.ebNombrePlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombrePlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombreCliente
        '
        Me.ebNombreCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombreCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombreCliente.BackColor = System.Drawing.Color.Ivory
        Me.ebNombreCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombreCliente.Location = New System.Drawing.Point(214, 136)
        Me.ebNombreCliente.Name = "ebNombreCliente"
        Me.ebNombreCliente.ReadOnly = True
        Me.ebNombreCliente.Size = New System.Drawing.Size(280, 22)
        Me.ebNombreCliente.TabIndex = 5
        Me.ebNombreCliente.TabStop = False
        Me.ebNombreCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombreCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPlayer
        '
        Me.ebPlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayer.BackColor = System.Drawing.Color.Ivory
        Me.ebPlayer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayer.Location = New System.Drawing.Point(110, 164)
        Me.ebPlayer.MaxLength = 3
        Me.ebPlayer.Name = "ebPlayer"
        Me.ebPlayer.ReadOnly = True
        Me.ebPlayer.Size = New System.Drawing.Size(98, 22)
        Me.ebPlayer.TabIndex = 4
        Me.ebPlayer.TabStop = False
        Me.ebPlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCliente
        '
        Me.ebCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCliente.BackColor = System.Drawing.Color.Ivory
        Me.ebCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCliente.Location = New System.Drawing.Point(110, 136)
        Me.ebCliente.MaxLength = 10
        Me.ebCliente.Name = "ebCliente"
        Me.ebCliente.ReadOnly = True
        Me.ebCliente.Size = New System.Drawing.Size(98, 22)
        Me.ebCliente.TabIndex = 3
        Me.ebCliente.TabStop = False
        Me.ebCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigoDescripcion
        '
        Me.ebCodigoDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoDescripcion.BackColor = System.Drawing.Color.Ivory
        Me.ebCodigoDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigoDescripcion.Location = New System.Drawing.Point(110, 108)
        Me.ebCodigoDescripcion.Name = "ebCodigoDescripcion"
        Me.ebCodigoDescripcion.ReadOnly = True
        Me.ebCodigoDescripcion.Size = New System.Drawing.Size(384, 22)
        Me.ebCodigoDescripcion.TabIndex = 2
        Me.ebCodigoDescripcion.TabStop = False
        Me.ebCodigoDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigo
        '
        Me.ebCodigo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigo.BackColor = System.Drawing.Color.Ivory
        Me.ebCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigo.Location = New System.Drawing.Point(110, 80)
        Me.ebCodigo.Name = "ebCodigo"
        Me.ebCodigo.ReadOnly = True
        Me.ebCodigo.Size = New System.Drawing.Size(224, 22)
        Me.ebCodigo.TabIndex = 1
        Me.ebCodigo.TabStop = False
        Me.ebCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolioContrato
        '
        Me.ebFolioContrato.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioContrato.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioContrato.ButtonImage = CType(resources.GetObject("ebFolioContrato.ButtonImage"), System.Drawing.Image)
        Me.ebFolioContrato.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebFolioContrato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioContrato.Location = New System.Drawing.Point(110, 52)
        Me.ebFolioContrato.Name = "ebFolioContrato"
        Me.ebFolioContrato.Size = New System.Drawing.Size(96, 22)
        Me.ebFolioContrato.TabIndex = 1
        Me.ebFolioContrato.Text = "0"
        Me.ebFolioContrato.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioContrato.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFolioContrato.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel8
        '
        Me.lblLabel8.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel8.Location = New System.Drawing.Point(508, 81)
        Me.lblLabel8.Name = "lblLabel8"
        Me.lblLabel8.Size = New System.Drawing.Size(56, 23)
        Me.lblLabel8.TabIndex = 29
        Me.lblLabel8.Text = "Importe"
        '
        'lblLabel7
        '
        Me.lblLabel7.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel7.Location = New System.Drawing.Point(350, 84)
        Me.lblLabel7.Name = "lblLabel7"
        Me.lblLabel7.Size = New System.Drawing.Size(56, 23)
        Me.lblLabel7.TabIndex = 28
        Me.lblLabel7.Text = "Talla"
        '
        'lblLabel6
        '
        Me.lblLabel6.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel6.Location = New System.Drawing.Point(508, 24)
        Me.lblLabel6.Name = "lblLabel6"
        Me.lblLabel6.Size = New System.Drawing.Size(56, 23)
        Me.lblLabel6.TabIndex = 27
        Me.lblLabel6.Text = "Fecha"
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel5.Location = New System.Drawing.Point(8, 164)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(100, 23)
        Me.lblLabel5.TabIndex = 26
        Me.lblLabel5.Text = "Player"
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.Location = New System.Drawing.Point(8, 136)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(88, 23)
        Me.lblLabel4.TabIndex = 25
        Me.lblLabel4.Text = "Cliente"
        '
        'lblLabel3
        '
        Me.lblLabel3.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel3.Location = New System.Drawing.Point(8, 108)
        Me.lblLabel3.Name = "lblLabel3"
        Me.lblLabel3.Size = New System.Drawing.Size(100, 23)
        Me.lblLabel3.TabIndex = 24
        Me.lblLabel3.Text = "Descripción"
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.Location = New System.Drawing.Point(508, 109)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(56, 23)
        Me.lblLabel2.TabIndex = 23
        Me.lblLabel2.Text = "Saldo"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Código"
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(8, 52)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(96, 23)
        Me.lblLabel1.TabIndex = 21
        Me.lblLabel1.Text = "No. de Contrato"
        '
        'EstadoCuentaContratoReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(693, 508)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "EstadoCuentaContratoReportForm"
        Me.Text = "Estado de Cuenta por Contrato"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.uIGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uIGroupBox2.ResumeLayout(False)
        CType(Me.grdAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uIGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

    Dim strConnectionString As String = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    Dim dtContrato As New DataTable("Contrato")
    Dim dtAbonos As New DataTable("Abonos")

#End Region

#Region "Objetos"

    Dim oCVendedoresMgr As CatalogoVendedoresManager
    Dim oCVEndedorInfo As Vendedor

    Dim oClientesMgr As ClientesManager
    Dim oCliente As ClienteAlterno

    Private Sub InicializaObjetos()

        oCVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
        oCVEndedorInfo = oCVendedoresMgr.Create

        oClientesMgr = New ClientesManager(oAppContext)
        oCliente = oClientesMgr.CreateAlterno

    End Sub

#End Region

#Region "Methods Form"

    Private Sub EstadoCuentaContratoReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InicializaObjetos()

        FillCaja()

    End Sub

    Private Sub grdAbonos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdAbonos.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape

                Me.Finalize()
                Me.Close()

        End Select

    End Sub

    Private Sub EstadoCuentaContratoReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")

            Case Keys.F5

                ClearScreen()

            Case Keys.F9
                If (Not dtAbonos Is Nothing) And (dtAbonos.Rows.Count > 0) Then
                    Imprimir()
                End If

            Case Keys.Escape

                Me.Finalize()
                Me.Close()

        End Select

    End Sub

    Private Sub ebFolioContrato_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioContrato.Validating

        Dim oRow As DataRow

        If ebFolioContrato.Value <> 0 Then

            dtContrato = SelectContrato(ebFolioContrato.Value, cbCajas.Text)

            If Not dtContrato Is Nothing Then

                If dtContrato.Rows.Count > 0 Then

                    oRow = dtContrato.Rows(0)

                    'Mostramos Datos
                    MuestraDatos(oRow)
                    cbCajas.Enabled = False
                    ebFolioContrato.Enabled = False

                Else

                    MsgBox("Este Contrato de Apartado no se encuenta registrado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Estado de Cuenta por Contrato")
                    e.Cancel = True

                End If

            Else

                MsgBox("Este Contrato de Apartado no se encuenta registrado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Estado de Cuenta por Contrato")
                e.Cancel = True

            End If

        End If

    End Sub

#End Region

#Region "Members"

    Private Sub MuestraAbonos(ByVal intApartadoID As Integer)

        dtAbonos = SelectAbono(intApartadoID)
        grdAbonos.DataSource = Nothing
        grdAbonos.DataMember = Nothing
        grdAbonos.Refresh()
        grdAbonos.DataSource = dtAbonos
        grdAbonos.DataMember = "Abonos"
        grdAbonos.Refresh()

    End Sub

    Private Sub MuestraDatos(ByVal dRow As DataRow)

        With dRow

            ebFecha.Text = Format(!Fecha, "dd/MM/yyyy")
            ebCodigo.Text = !CodArticulo
            ebTalla.Text = !Numero
            ebCodigoDescripcion.Text = !Descripcion
            ebCliente.Text = !ClienteID
            ebPlayer.Text = !CodVendedor
            ebImporte.Value = !Importe
            ebSaldo.Value = !Saldo

            MuestraAbonos(!ApartadoID)

        End With

        oCVEndedorInfo.ClearFields()
        oCVendedoresMgr.LoadInto(ebPlayer.Text, oCVEndedorInfo)
        ebNombrePlayer.Text = oCVEndedorInfo.Nombre

        oCliente.Clear()
        oClientesMgr.Load(ebCliente.Text, oCliente, "I")
        ebNombreCliente.Text = Trim(oCliente.Nombre) & " " & Trim(oCliente.ApellidoPaterno) & " " & Trim(oCliente.ApellidoMaterno)

        If dRow!StatusRegistro = 0 Then
            MsgBox(" !Contrato Cancelado! ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Estado de Cuenta por Contrato")
            Exit Sub
        End If

        If UCase(dRow!Entregada) = "S" Then
            MsgBox("El Contrato ya ha sido entregado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Estado de Cuenta por Contrato")
            Exit Sub
        End If

    End Sub

    Private Sub FillCaja()

        Dim oCajaMgr As New CatalogoCajaManager(oAppContext)
        Dim dtCaja As New DataTable("Cajas")
        Dim oRow As DataRow
        dtCaja = oCajaMgr.GetAll(True).Tables(0)
        For Each oRow In dtCaja.Rows
            cbCajas.Items.Add(oRow!CodCaja)
        Next
        oRow = Nothing
        dtCaja.Dispose()
        dtCaja = Nothing

        oCajaMgr = Nothing

        cbCajas.SelectedIndex = 0
        cbCajas.Text = oAppContext.ApplicationConfiguration.NoCaja

    End Sub

    Private Function GetAlmacen() As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen

        oAlmacen = oAlmacenMgr.Create

        oAlmacenMgr.LoadInto(oAppContext.ApplicationConfiguration.Almacen, oAlmacen)

        Return oAppContext.ApplicationConfiguration.Almacen & " " & oAlmacen.Descripcion

    End Function

    Private Sub Imprimir()

        Dim oARReporte As New EstadodeCuentapoContratoReport( _
                                                                GetAlmacen(), _
                                                                ebCliente.Text, _
                                                                ebNombreCliente.Text, _
                                                                CDate(ebFecha.Text), _
                                                                ebImporte.Value, _
                                                                ebSaldo.Value, _
                                                                dtAbonos)

        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte Detallado de Abonos"

        'oARReporte.Document.Print(False, False)
        oReportViewer.Report = oARReporte

        oReportViewer.Show()

    End Sub

    Private Sub ClearScreen()

        cbCajas.Enabled = True
        ebFolioContrato.Enabled = True
        cbCajas.SelectedIndex = 0
        ebFecha.Text = String.Empty
        ebCodigo.Text = String.Empty
        ebTalla.Text = 0
        ebCodigoDescripcion.Text = String.Empty
        ebCliente.Text = String.Empty
        ebPlayer.Text = String.Empty
        ebImporte.Value = 0
        ebSaldo.Value = 0
        ebNombrePlayer.Text = String.Empty
        ebNombreCliente.Text = String.Empty
        grdAbonos.DataSource = Nothing
        grdAbonos.DataMember = Nothing
        grdAbonos.Refresh()
        cbCajas.SelectedIndex = 0
        ebFolioContrato.Value = 0
        ebFolioContrato.Focus()

    End Sub

#End Region

#Region "SQL Methods"

    Private Function SelectContrato(ByVal intFolio As Integer, ByVal strCaja As String) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daContrato As SqlDataAdapter
        Dim dtContratoTemp As New DataTable("Contrato")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[EstadoCuentaContratoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioContrato", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Caja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@FolioContrato").Value = intFolio
            .Parameters("@Caja").Value = strCaja

        End With

        daContrato = New SqlDataAdapter(sccmdSelect)

        Try

            daContrato.Fill(dtContratoTemp)

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de aplicación.", ex)

        End Try

        daContrato.Dispose()
        daContrato = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtContratoTemp

    End Function

    Private Function SelectAbono(ByVal intApartadoID As Integer) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daAbonos As SqlDataAdapter
        Dim dtAbonosTemp As New DataTable("Abonos")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[EstadoCuentaContratoAbonosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))


            .Parameters("@ApartadoID").Value = intApartadoID
            .Parameters("@CodCaja").Value = oAppContext.ApplicationConfiguration.NoCaja

        End With

        daAbonos = New SqlDataAdapter(sccmdSelect)

        Try

            daAbonos.Fill(dtAbonosTemp)

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de aplicación.", ex)

        End Try

        daAbonos.Dispose()
        daAbonos = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtAbonosTemp

    End Function

#End Region


    Private Sub ebFolioContrato_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFolioContrato.ButtonClick

        Sm_AbrirContrato()

    End Sub

    Private Sub Sm_AbrirContrato()

        Dim oOpenRecordDlg As New OpenRecordDialog
        Dim oRow As DataRow

        oOpenRecordDlg.CurrentView = New ContratoOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            cbCajas.Text = oOpenRecordDlg.Record.Item("CodCaja")
            ebFolioContrato.Value = oOpenRecordDlg.Record.Item("FolioApartado")

            dtContrato = SelectContrato(oOpenRecordDlg.Record.Item("FolioApartado"), _
                                        oOpenRecordDlg.Record.Item("CodCaja"))

            If Not dtContrato Is Nothing Then

                If dtContrato.Rows.Count > 0 Then

                    oRow = dtContrato.Rows(0)

                    'Mostramos Datos
                    MuestraDatos(oRow)
                    cbCajas.Enabled = False
                    ebFolioContrato.Enabled = False

                Else

                    MsgBox("Este Contrato de Apartado no se encuenta registrado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Estado de Cuenta por Contrato")
                    Exit Sub
                End If

            Else

                MsgBox("Este Contrato de Apartado no se encuenta registrado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Estado de Cuenta por Contrato")
                Exit Sub

            End If

        End If

    End Sub

End Class
