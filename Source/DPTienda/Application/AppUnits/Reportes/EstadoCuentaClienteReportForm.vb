Imports System
Imports System.IO
Imports System.Threading

'Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU


Public Class EstadoCuentaClienteReportForm
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents uIGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ebClienteNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblAbonos As System.Windows.Forms.Label
    Friend WithEvents lblSaldoActual As System.Windows.Forms.Label
    Friend WithEvents lblLimiteCredito As System.Windows.Forms.Label
    Friend WithEvents lblClienteNombre As System.Windows.Forms.Label
    Friend WithEvents lblClienteID As System.Windows.Forms.Label
    Friend WithEvents ebLimiteCredito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebSaldoActual As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebDiasPlazo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents ebSucursal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grdDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ebAbonos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCompras As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EBIDAsociado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cmGrid As System.Windows.Forms.ContextMenu
    Friend WithEvents miVerDetalle As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadoCuentaClienteReportForm))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grdDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmGrid = New System.Windows.Forms.ContextMenu()
        Me.miVerDetalle = New System.Windows.Forms.MenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.uIGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.EBIDAsociado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebAbonos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ebSucursal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.ebLimiteCredito = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebSaldoActual = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebCompras = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebClienteNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDiasPlazo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblAbonos = New System.Windows.Forms.Label()
        Me.lblSaldoActual = New System.Windows.Forms.Label()
        Me.lblLimiteCredito = New System.Windows.Forms.Label()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.lblClienteID = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uIGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.grdDatos)
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Controls.Add(Me.Label8)
        Me.explorerBar1.Controls.Add(Me.uIGroupBox1)
        Me.explorerBar1.Controls.Add(Me.Label3)
        Me.explorerBar1.Controls.Add(Me.Label7)
        Me.explorerBar1.Controls.Add(Me.Label4)
        Me.explorerBar1.Controls.Add(Me.Label5)
        Me.explorerBar1.Controls.Add(Me.Label2)
        Me.explorerBar1.Controls.Add(Me.Label6)
        Me.explorerBar1.Location = New System.Drawing.Point(-8, -16)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(768, 536)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grdDatos
        '
        Me.grdDatos.AlternatingColors = True
        Me.grdDatos.ContextMenu = Me.cmGrid
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdDatos.DesignTimeLayout = GridEXLayout1
        Me.grdDatos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdDatos.Font = New System.Drawing.Font("Tahoma", 8.5!)
        Me.grdDatos.GroupByBoxVisible = False
        Me.grdDatos.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grdDatos.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[False]
        Me.grdDatos.Location = New System.Drawing.Point(16, 152)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Size = New System.Drawing.Size(736, 304)
        Me.grdDatos.TabIndex = 1
        Me.grdDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        Me.grdDatos.VisualStyleAreas.HeadersStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmGrid
        '
        Me.cmGrid.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miVerDetalle})
        '
        'miVerDetalle
        '
        Me.miVerDetalle.DefaultItem = True
        Me.miVerDetalle.Index = 0
        Me.miVerDetalle.Text = "Ver Detalle"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(160, 464)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Exportar"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(136, 464)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 24)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "F5"
        '
        'uIGroupBox1
        '
        Me.uIGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.uIGroupBox1.Controls.Add(Me.EBIDAsociado)
        Me.uIGroupBox1.Controls.Add(Me.ebAbonos)
        Me.uIGroupBox1.Controls.Add(Me.Label9)
        Me.uIGroupBox1.Controls.Add(Me.ebSucursal)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel1)
        Me.uIGroupBox1.Controls.Add(Me.ebLimiteCredito)
        Me.uIGroupBox1.Controls.Add(Me.ebSaldoActual)
        Me.uIGroupBox1.Controls.Add(Me.ebCompras)
        Me.uIGroupBox1.Controls.Add(Me.ebClienteNombre)
        Me.uIGroupBox1.Controls.Add(Me.ebDiasPlazo)
        Me.uIGroupBox1.Controls.Add(Me.lblAbonos)
        Me.uIGroupBox1.Controls.Add(Me.lblSaldoActual)
        Me.uIGroupBox1.Controls.Add(Me.lblLimiteCredito)
        Me.uIGroupBox1.Controls.Add(Me.lblClienteNombre)
        Me.uIGroupBox1.Controls.Add(Me.lblClienteID)
        Me.uIGroupBox1.Location = New System.Drawing.Point(16, 24)
        Me.uIGroupBox1.Name = "uIGroupBox1"
        Me.uIGroupBox1.Size = New System.Drawing.Size(736, 120)
        Me.uIGroupBox1.TabIndex = 0
        Me.uIGroupBox1.Text = " Datos Generales "
        Me.uIGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'EBIDAsociado
        '
        Me.EBIDAsociado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBIDAsociado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBIDAsociado.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBIDAsociado.ButtonImage = CType(resources.GetObject("EBIDAsociado.ButtonImage"), System.Drawing.Image)
        Me.EBIDAsociado.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EBIDAsociado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBIDAsociado.Location = New System.Drawing.Point(72, 53)
        Me.EBIDAsociado.MaxLength = 10
        Me.EBIDAsociado.Name = "EBIDAsociado"
        Me.EBIDAsociado.Size = New System.Drawing.Size(120, 22)
        Me.EBIDAsociado.TabIndex = 52
        Me.EBIDAsociado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBIDAsociado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAbonos
        '
        Me.ebAbonos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAbonos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAbonos.BackColor = System.Drawing.Color.Ivory
        Me.ebAbonos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAbonos.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebAbonos.Location = New System.Drawing.Point(400, 83)
        Me.ebAbonos.Name = "ebAbonos"
        Me.ebAbonos.ReadOnly = True
        Me.ebAbonos.Size = New System.Drawing.Size(104, 22)
        Me.ebAbonos.TabIndex = 9
        Me.ebAbonos.TabStop = False
        Me.ebAbonos.Text = "$0.00"
        Me.ebAbonos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(344, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Abonos"
        '
        'ebSucursal
        '
        Me.ebSucursal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucursal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucursal.BackColor = System.Drawing.Color.Ivory
        Me.ebSucursal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucursal.Location = New System.Drawing.Point(72, 24)
        Me.ebSucursal.Name = "ebSucursal"
        Me.ebSucursal.ReadOnly = True
        Me.ebSucursal.Size = New System.Drawing.Size(88, 22)
        Me.ebSucursal.TabIndex = 0
        Me.ebSucursal.TabStop = False
        Me.ebSucursal.Text = "000"
        Me.ebSucursal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebSucursal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(8, 28)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(56, 16)
        Me.lblLabel1.TabIndex = 35
        Me.lblLabel1.Text = "Sucursal"
        '
        'ebLimiteCredito
        '
        Me.ebLimiteCredito.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebLimiteCredito.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebLimiteCredito.BackColor = System.Drawing.Color.Ivory
        Me.ebLimiteCredito.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebLimiteCredito.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebLimiteCredito.Location = New System.Drawing.Point(608, 53)
        Me.ebLimiteCredito.Name = "ebLimiteCredito"
        Me.ebLimiteCredito.ReadOnly = True
        Me.ebLimiteCredito.Size = New System.Drawing.Size(112, 22)
        Me.ebLimiteCredito.TabIndex = 4
        Me.ebLimiteCredito.TabStop = False
        Me.ebLimiteCredito.Text = "$0.00"
        Me.ebLimiteCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebLimiteCredito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSaldoActual
        '
        Me.ebSaldoActual.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoActual.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoActual.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoActual.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSaldoActual.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSaldoActual.Location = New System.Drawing.Point(608, 83)
        Me.ebSaldoActual.Name = "ebSaldoActual"
        Me.ebSaldoActual.ReadOnly = True
        Me.ebSaldoActual.Size = New System.Drawing.Size(112, 22)
        Me.ebSaldoActual.TabIndex = 11
        Me.ebSaldoActual.TabStop = False
        Me.ebSaldoActual.Text = "$0.00"
        Me.ebSaldoActual.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoActual.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCompras
        '
        Me.ebCompras.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCompras.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCompras.BackColor = System.Drawing.Color.Ivory
        Me.ebCompras.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCompras.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebCompras.Location = New System.Drawing.Point(221, 83)
        Me.ebCompras.Name = "ebCompras"
        Me.ebCompras.ReadOnly = True
        Me.ebCompras.Size = New System.Drawing.Size(104, 22)
        Me.ebCompras.TabIndex = 7
        Me.ebCompras.TabStop = False
        Me.ebCompras.Text = "$0.00"
        Me.ebCompras.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCompras.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebClienteNombre
        '
        Me.ebClienteNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteNombre.BackColor = System.Drawing.Color.Ivory
        Me.ebClienteNombre.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebClienteNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteNombre.Location = New System.Drawing.Point(200, 53)
        Me.ebClienteNombre.Name = "ebClienteNombre"
        Me.ebClienteNombre.ReadOnly = True
        Me.ebClienteNombre.Size = New System.Drawing.Size(304, 22)
        Me.ebClienteNombre.TabIndex = 2
        Me.ebClienteNombre.TabStop = False
        Me.ebClienteNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDiasPlazo
        '
        Me.ebDiasPlazo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDiasPlazo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDiasPlazo.BackColor = System.Drawing.Color.Ivory
        Me.ebDiasPlazo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDiasPlazo.Location = New System.Drawing.Point(72, 83)
        Me.ebDiasPlazo.Name = "ebDiasPlazo"
        Me.ebDiasPlazo.ReadOnly = True
        Me.ebDiasPlazo.Size = New System.Drawing.Size(88, 22)
        Me.ebDiasPlazo.TabIndex = 5
        Me.ebDiasPlazo.TabStop = False
        Me.ebDiasPlazo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebDiasPlazo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblAbonos
        '
        Me.lblAbonos.BackColor = System.Drawing.Color.Transparent
        Me.lblAbonos.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbonos.Location = New System.Drawing.Point(168, 85)
        Me.lblAbonos.Name = "lblAbonos"
        Me.lblAbonos.Size = New System.Drawing.Size(56, 16)
        Me.lblAbonos.TabIndex = 6
        Me.lblAbonos.Text = "Compras"
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldoActual.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoActual.Location = New System.Drawing.Point(521, 85)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(72, 16)
        Me.lblSaldoActual.TabIndex = 10
        Me.lblSaldoActual.Text = "Saldo Actual"
        '
        'lblLimiteCredito
        '
        Me.lblLimiteCredito.BackColor = System.Drawing.Color.Transparent
        Me.lblLimiteCredito.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLimiteCredito.Location = New System.Drawing.Point(520, 57)
        Me.lblLimiteCredito.Name = "lblLimiteCredito"
        Me.lblLimiteCredito.Size = New System.Drawing.Size(96, 16)
        Me.lblLimiteCredito.TabIndex = 3
        Me.lblLimiteCredito.Text = "Límite de Crédito"
        '
        'lblClienteNombre
        '
        Me.lblClienteNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblClienteNombre.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClienteNombre.Location = New System.Drawing.Point(9, 85)
        Me.lblClienteNombre.Name = "lblClienteNombre"
        Me.lblClienteNombre.Size = New System.Drawing.Size(55, 16)
        Me.lblClienteNombre.TabIndex = 28
        Me.lblClienteNombre.Text = "Plazo"
        '
        'lblClienteID
        '
        Me.lblClienteID.BackColor = System.Drawing.Color.Transparent
        Me.lblClienteID.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClienteID.Location = New System.Drawing.Point(9, 57)
        Me.lblClienteID.Name = "lblClienteID"
        Me.lblClienteID.Size = New System.Drawing.Size(55, 16)
        Me.lblClienteID.TabIndex = 27
        Me.lblClienteID.Text = "Asociado"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(40, 464)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Nuevo"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(16, 464)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 24)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "F2"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(704, 464)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Salir"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(672, 464)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 24)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Esc"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(280, 464)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Imprimir"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(256, 464)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 24)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "F9"
        '
        'EstadoCuentaClienteReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(754, 471)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "EstadoCuentaClienteReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de Cuenta por Cliente"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uIGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

    Dim boolClosing As Boolean

#Region "Objetos"


    'Dim oAbonoCreditoDirectoMgr As AbonoCreditoDirectoManager

    'Clientes
    Dim oClienteMgr As ClientesManager
    Dim oCliente As ClienteAlterno

    Dim dsInfoRequest As DataSet

    Dim dtEstadoCuenta As New DataTable

#End Region

#End Region

#Region "Methods"

#Region "Members"

    Private Sub InitializeObjects()

        'Clientes
        oClienteMgr = New ClientesManager(oAppContext)
        oCliente = oClienteMgr.CreateAlterno
        oCliente.Clear()

    End Sub

    Private Sub ImprimirEstadoDeCuentaCliente()

        If Not (dtEstadoCuenta.Rows.Count > 0) Then

            MsgBox("No existe información a Imprimir. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Estado de Cuenta")
            Exit Sub

        End If

        Me.Cursor = Cursors.WaitCursor

        Dim oARReporte As New EstadoCuentaClienteReport(dsInfoRequest, _
                                                        ebClienteNombre.Text, _
                                                        ebLimiteCredito.Value, _
                                                        ebCompras.Value, _
                                                        ebAbonos.Value, oCliente.CodigoAlterno)

        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Estado de Cuenta por Cliente"

        oReportViewer.Report = oARReporte

        Me.Cursor = Cursors.Default

        oReportViewer.Show()

    End Sub

    Private Sub NuevaConsulta()

        ebLimiteCredito.Value = 0
        ebCompras.Value = 0
        ebAbonos.Value = 0
        ebSaldoActual.Value = 0
        EBIDAsociado.Text = ""
        ebClienteNombre.Text = String.Empty
        ebDiasPlazo.Text = String.Empty

        grdDatos.SetDataBinding(Nothing, Nothing)
        grdDatos.Refresh()

    End Sub

    Private Sub ExportaEstadoCuentaClienteXLS()

        If Not (dtEstadoCuenta.Rows.Count > 0) Then

            MsgBox("No existe información a Exportar. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Estado de Cuenta")
            Exit Sub

        End If

        Me.Cursor = Cursors.WaitCursor

        Dim SaveDialog = New SaveFileDialog
        Dim strRuta As String = String.Empty

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
        'Borrar las otras Hojas
        wsxl = xlapp.Sheets(1)
        wsxl.delete()
        wsxl = xlapp.Sheets(1)
        wsxl.delete()
        '---------------------------
        wsxl = xlapp.Sheets(1)
        wsxl.Name = "Estado de Cuenta por Cliente"

        '****************************************
        'HOJA DE CALCULO AUDITORIA RETIROS
        '****************************************
        wsxl.Cells(1, 1).Value = "ESTADO DE CUENTA POR CLIENTE"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12
        wsxl.Range("A1:G1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:G1").BorderAround(, 2, 0, )
        wsxl.Range("A1:G1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Value = "Asociado"
        wsxl.Cells(2, 2).Value = Me.EBIDAsociado.Text & "  " & ebClienteNombre.Text
        wsxl.Cells(2, 2).Font.Bold = True

        wsxl.Cells(2, 6).Value = "Fecha"
        wsxl.Cells(2, 7).Value = Format(Date.Now, "short date")
        wsxl.Cells(2, 7).Font.Bold = True

        wsxl.Cells(3, 1).Value = "Plazo"
        wsxl.Cells(3, 2).Value = ebDiasPlazo.Text
        wsxl.Cells(3, 2).Font.Bold = True

        wsxl.Cells(4, 1).Value = "Límite Crédito"
        wsxl.Cells(4, 2).Value = ebLimiteCredito.Text
        wsxl.Cells(4, 2).Font.Bold = True

        wsxl.Cells(3, 6).Value = "Compras"
        wsxl.Cells(3, 7).Value = ebCompras.Text
        wsxl.Cells(3, 7).Font.Bold = True

        wsxl.Cells(4, 6).Value = "Abonos"
        wsxl.Cells(4, 7).Value = ebAbonos.Text
        wsxl.Cells(4, 7).Font.Bold = True

        wsxl.Cells(5, 6).Value = "Saldo Actual"
        wsxl.Cells(5, 7).Value = ebSaldoActual.Text
        wsxl.Cells(5, 7).Font.Bold = True

        'Encabezado
        wsxl.Cells(6, 1).Value = "Fecha"
        wsxl.Cells(6, 2).Value = "Sucursal"
        wsxl.Cells(6, 3).Value = "Folio"
        wsxl.Cells(6, 4).Value = "Detalles"
        wsxl.Cells(6, 5).Value = "Compras"
        wsxl.Cells(6, 6).Value = "Abonos"
        wsxl.Cells(6, 7).Value = "Folio Factura SAP"
        wsxl.Range("A6:G6").Font.Bold = True
        wsxl.Range("A6:G6").HorizontalAlignment = 3
        wsxl.Range("A6:G6").Font.Size = 8
        wsxl.Range("A6:G6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:G6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oRow In dtEstadoCuenta.Rows
            intRow = intRow + 1
            wsxl.Cells(6 + intRow, 1).Value = "'" & Format(oRow!Fecha, "short date")
            wsxl.Cells(6 + intRow, 1).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 2).Value = "'" & oRow!Sucursal
            wsxl.Cells(6 + intRow, 2).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 3).Value = "'" & oRow!FolioDP
            wsxl.Cells(6 + intRow, 3).HorizontalAlignment = 4

            wsxl.Cells(6 + intRow, 4).Value = "'" & oRow!Detalle
            wsxl.Cells(6 + intRow, 4).Font.Size = 9
            wsxl.Cells(6 + intRow, 5).Value = oRow!ComprasCargos
            wsxl.Cells(6 + intRow, 6).Value = oRow!PagosAbonos
            wsxl.Cells(6 + intRow, 7).Value = "'" & oRow!Folio
        Next

        'wsxl.Range("A" & Trim(Str(8 + intRow)) & ":F" & Trim(Str(8 + intRow))).BorderAround(, 3, 0, )
        wsxl.Range("E6:F" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        wsxl.Range("A6:A6").ColumnWidth = 13
        wsxl.Range("B6:B6").ColumnWidth = 10
        wsxl.Range("C6:C6").ColumnWidth = 10
        wsxl.Range("D6:D6").ColumnWidth = 33.6
        wsxl.Range("E6:E6").ColumnWidth = 15
        wsxl.Range("F6:F6").ColumnWidth = 15
        wsxl.Range("G6:G6").ColumnWidth = 15
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

        Me.Cursor = Cursors.WaitCursor

        KillExcel()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub SearchAsociadosCreditoDirecto()

        NuevaConsulta()

        Dim oOpenRecordDlg As New OpenRecordDialogClientes
        oOpenRecordDlg.GrupoDeCuentas = "D"
        oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If


        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then


            Dim strClienteID As String

            If oOpenRecordDlg.pbCodigo = String.Empty Then

                Me.EBIDAsociado.Text = oOpenRecordDlg.Record.Item("CodigoAlterno")
                SendKeys.Send("{TAB}")
            Else

                Me.EBIDAsociado.Text = oOpenRecordDlg.pbCodigo
                SendKeys.Send("{TAB}")

            End If

        End If

        'Dim oOpenRecordDlg As New OpenRecordDialog
        'oOpenRecordDlg.CurrentView = New CreditoDirectoEnTiendaOpenRecordDialogView

        'oOpenRecordDlg.ShowDialog()

        'If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

        '    Me.EBIDAsociado.Text = oOpenRecordDlg.Record.Item("ClienteID")
        '    SendKeys.Send("{TAB}")

        'End If

    End Sub

#End Region

#Region "Form Methods"

    Private Sub EstadoCuentaClienteReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitializeObjects()

        ebSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

    End Sub

    Private Sub EstadoCuentaClienteReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")

            Case Keys.F5
                'Exportar
                ExportaEstadoCuentaClienteXLS()

            Case Keys.F2
                'Nuevo
                NuevaConsulta()

            Case Keys.F9
                'Imprimir
                ImprimirEstadoDeCuentaCliente()

            Case Keys.Escape
                boolClosing = True
                Me.Finalize()
                Me.Close()

        End Select

    End Sub

    Private Sub EBIDAsociado_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBIDAsociado.ButtonClick

        SearchAsociadosCreditoDirecto()

    End Sub


    Private Sub EBIDAsociado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBIDAsociado.Validating

        If EBIDAsociado.Text <> "" OrElse boolClosing = False Then
            '--------------------------SAP Validar Credito Cliente--------------------------
            Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim Credito As New CreditoAsociadoSAP
            Credito = oSap.GetCreditoAsociadoSAP(EBIDAsociado.Text)
            '--------------------------SAP--------------------------

            If Credito.CodigoAsociadoSAP = String.Empty Then
                MsgBox("Asociado No esta dado de Alta. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Estado de Cuenta")
                NuevaConsulta()
                Exit Sub
            End If

            If Credito.Bloqueado = "S" Then
                MsgBox("Asociado Tiene Bloqueado el Credito. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Estado de Cuenta")
            End If

            'Cargamos Cliente
            oCliente.Clear()
            oClienteMgr.Load(EBIDAsociado.Text, oCliente, "D")

            If oCliente.CodigoCliente <> 0 Then
                ebClienteNombre.Text = Trim(oCliente.Nombre) & " " & Trim(oCliente.ApellidoPaterno) & " " & Trim(oCliente.ApellidoMaterno)
            End If

            ebLimiteCredito.Value = Credito.LimiteCredito


            ''--------------------------SAP Sacar Estado Cuenta--------------------------
            'dtEstadoCuenta = oSap.Read_ZBAPI_EDOCUENTAXCLIENTE(oCliente.CodigoAlterno)
            ''--------------------------SAP--------------------------

            '''Edo Cuenta Erick
            Dim oFacturaMgr As New FacturaManager(oAppContext)
            dtEstadoCuenta = oFacturaMgr.SelectFacturasEdoCuentaCDTAll(oCliente.CodigoAlterno).Tables("Facturas").Copy
            '''Edo Cuenta Erick

            Dim dvFechaAutoF As New DataView(dtEstadoCuenta, "Fecha >='" & oConfigCierreFI.FechaAutoF & "'", "Folio", DataViewRowState.CurrentRows)
            For Each oView As DataRowView In dvFechaAutoF
                oView.Row.Item(3) = 0
            Next
            dtEstadoCuenta.AcceptChanges()

            ' oAbonoCreditoDirectoMgr = New AbonoCreditoDirectoManager(oAppContext)

            If dtEstadoCuenta Is Nothing OrElse dtEstadoCuenta.Rows.Count = 0 Then
                MsgBox("No se cuenta con información crediticia del Asociado")
                e.Cancel = True
                Exit Sub
            Else
                'ebDiasPlazo.Text = CStr(wsCreditoDirectoInfo.Plazo) & " días"

                grdDatos.DataSource = dtEstadoCuenta
                grdDatos.Refresh()

                ebCompras.Value = dtEstadoCuenta.Compute("SUM(ComprasCargos)", "")
                ebAbonos.Value = dtEstadoCuenta.Compute("SUM(PagosAbonos)", "")
                ebSaldoActual.Value = ebCompras.Value - ebAbonos.Value

            End If

            Dim odrFactura As DataRow
            Dim strFactura As String

            'If dtEstadoCuenta.Rows.Count = 0 Then
            '    MsgBox("El Asociado no Tiene Facturas Activas", MsgBoxStyle.Critical, "Sin Facturas")
            '    Exit Sub
            'End If

            'For Each odrFactura In dtEstadoCuenta.Rows
            '    If odrFactura("Folio") <> "" And odrFactura("FolioDp") = "" Then
            '        If odrFactura("Folio") <> "" Then
            '            strFactura = oAbonoCreditoDirectoMgr.GetSelectFolioFacturaDPBySDSAP(oCliente.CodigoAlterno, odrFactura("Folio"))
            '        End If
            '        If strFactura = String.Empty Then
            '            odrFactura("FolioDp") = "N/D"
            '        Else
            '            odrFactura("FolioDp") = strFactura
            '        End If
            '    Else
            '        If odrFactura("FolioDp") = String.Empty Then
            '            odrFactura("FolioDp") = "N/D"
            '        End If
            '    End If
            'Next

            Dim ds As New DataSet
            ds.Tables.Add(dtEstadoCuenta)
            dsInfoRequest = ds.Copy
        Else

            e.Cancel = True

        End If

    End Sub

#End Region

#End Region

    Private Sub EstadoCuentaClienteReportForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        boolClosing = True
    End Sub

  
    Private Sub miVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miVerDetalle.Click
        Dim intRowPos As Integer, strFolioPro As String
        Dim oEstadoCuentaFacturaReportForm As New EstadoCuentaFacturaReportForm

        If Me.grdDatos.GetValue("FolioDP") = 0 Then
            Dim oFacturaMGR As New FacturaManager(oAppContext)
            Dim dsFolioPRO As DataSet = oFacturaMGR.SelectFolioCaja(Me.grdDatos.GetValue("Folio"))
            If dsFolioPRO.Tables(0).Rows.Count > 0 Then
                strFolioPro = dsFolioPRO.Tables(0).Rows(0).Item("FolioFactura")
            Else
                Exit Sub
            End If
        End If
        oEstadoCuentaFacturaReportForm.ShowDev(strFolioPro)


        oEstadoCuentaFacturaReportForm.Dispose()
    End Sub

    
End Class
