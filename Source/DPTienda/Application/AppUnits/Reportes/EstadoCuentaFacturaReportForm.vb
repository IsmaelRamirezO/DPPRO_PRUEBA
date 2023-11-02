Imports System
Imports System.IO
Imports System.Threading
Imports System.Data.SqlClient


Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
'Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda



Public Class EstadoCuentaFacturaReportForm
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
    Friend WithEvents ebImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebClienteNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblAbonos As System.Windows.Forms.Label
    Friend WithEvents lblSaldoActual As System.Windows.Forms.Label
    Friend WithEvents lblLimiteCredito As System.Windows.Forms.Label
    Friend WithEvents lblImporte As System.Windows.Forms.Label
    Friend WithEvents lblFechaLimite As System.Windows.Forms.Label
    Friend WithEvents lblClienteNombre As System.Windows.Forms.Label
    Friend WithEvents lblClienteID As System.Windows.Forms.Label
    Friend WithEvents lblFolioFactura As System.Windows.Forms.Label
    Friend WithEvents ebLimiteCredito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFechaLimite As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSaldoActual As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebAbonos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebDiasPlazo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents ebSucursal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents ebcaja As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grdDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebFolioFacturaN As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAsociadoID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ebFolioFacturaDp As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadoCuentaFacturaReportForm))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grdDatos = New Janus.Windows.GridEX.GridEX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.uIGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ebFolioFacturaDp = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ebFechaLimite = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebAsociadoID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFolioFacturaN = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.ebSucursal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.ebcaja = New Janus.Windows.EditControls.UIComboBox()
        Me.ebLimiteCredito = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebSaldoActual = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebAbonos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebClienteNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDiasPlazo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblAbonos = New System.Windows.Forms.Label()
        Me.lblSaldoActual = New System.Windows.Forms.Label()
        Me.lblLimiteCredito = New System.Windows.Forms.Label()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.lblClienteID = New System.Windows.Forms.Label()
        Me.lblFolioFactura = New System.Windows.Forms.Label()
        Me.lblFechaLimite = New System.Windows.Forms.Label()
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
        Me.grdDatos.AllowColumnDrag = False
        Me.grdDatos.AlternatingColors = True
        Me.grdDatos.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.Ivory
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdDatos.DesignTimeLayout = GridEXLayout1
        Me.grdDatos.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDatos.GroupByBoxVisible = False
        Me.grdDatos.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grdDatos.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[False]
        Me.grdDatos.Location = New System.Drawing.Point(16, 184)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Size = New System.Drawing.Size(736, 296)
        Me.grdDatos.TabIndex = 9
        Me.grdDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        Me.grdDatos.VisualStyleAreas.HeadersStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(160, 490)
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
        Me.Label8.Location = New System.Drawing.Point(136, 490)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 24)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "F5"
        '
        'uIGroupBox1
        '
        Me.uIGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.uIGroupBox1.Controls.Add(Me.ebFolioFacturaDp)
        Me.uIGroupBox1.Controls.Add(Me.Label9)
        Me.uIGroupBox1.Controls.Add(Me.ebFechaLimite)
        Me.uIGroupBox1.Controls.Add(Me.ebAsociadoID)
        Me.uIGroupBox1.Controls.Add(Me.ebFolioFacturaN)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel2)
        Me.uIGroupBox1.Controls.Add(Me.ebSucursal)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel1)
        Me.uIGroupBox1.Controls.Add(Me.ebcaja)
        Me.uIGroupBox1.Controls.Add(Me.ebLimiteCredito)
        Me.uIGroupBox1.Controls.Add(Me.ebSaldoActual)
        Me.uIGroupBox1.Controls.Add(Me.ebAbonos)
        Me.uIGroupBox1.Controls.Add(Me.ebImporte)
        Me.uIGroupBox1.Controls.Add(Me.ebClienteNombre)
        Me.uIGroupBox1.Controls.Add(Me.ebDiasPlazo)
        Me.uIGroupBox1.Controls.Add(Me.lblAbonos)
        Me.uIGroupBox1.Controls.Add(Me.lblSaldoActual)
        Me.uIGroupBox1.Controls.Add(Me.lblLimiteCredito)
        Me.uIGroupBox1.Controls.Add(Me.lblImporte)
        Me.uIGroupBox1.Controls.Add(Me.lblClienteNombre)
        Me.uIGroupBox1.Controls.Add(Me.lblClienteID)
        Me.uIGroupBox1.Controls.Add(Me.lblFolioFactura)
        Me.uIGroupBox1.Controls.Add(Me.lblFechaLimite)
        Me.uIGroupBox1.Location = New System.Drawing.Point(16, 24)
        Me.uIGroupBox1.Name = "uIGroupBox1"
        Me.uIGroupBox1.Size = New System.Drawing.Size(736, 152)
        Me.uIGroupBox1.TabIndex = 0
        Me.uIGroupBox1.Text = " Datos Generales "
        Me.uIGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'ebFolioFacturaDp
        '
        Me.ebFolioFacturaDp.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioFacturaDp.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioFacturaDp.Location = New System.Drawing.Point(80, 53)
        Me.ebFolioFacturaDp.Name = "ebFolioFacturaDp"
        Me.ebFolioFacturaDp.Size = New System.Drawing.Size(104, 20)
        Me.ebFolioFacturaDp.TabIndex = 0
        Me.ebFolioFacturaDp.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolioFacturaDp.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Folio Factura"
        '
        'ebFechaLimite
        '
        Me.ebFechaLimite.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFechaLimite.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFechaLimite.BackColor = System.Drawing.Color.Ivory
        Me.ebFechaLimite.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFechaLimite.Location = New System.Drawing.Point(416, 23)
        Me.ebFechaLimite.Name = "ebFechaLimite"
        Me.ebFechaLimite.ReadOnly = True
        Me.ebFechaLimite.Size = New System.Drawing.Size(88, 22)
        Me.ebFechaLimite.TabIndex = 12
        Me.ebFechaLimite.TabStop = False
        Me.ebFechaLimite.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebFechaLimite.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAsociadoID
        '
        Me.ebAsociadoID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAsociadoID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAsociadoID.BackColor = System.Drawing.Color.Ivory
        Me.ebAsociadoID.Location = New System.Drawing.Point(80, 82)
        Me.ebAsociadoID.Name = "ebAsociadoID"
        Me.ebAsociadoID.ReadOnly = True
        Me.ebAsociadoID.Size = New System.Drawing.Size(104, 20)
        Me.ebAsociadoID.TabIndex = 2
        Me.ebAsociadoID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAsociadoID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolioFacturaN
        '
        Me.ebFolioFacturaN.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioFacturaN.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioFacturaN.BackColor = System.Drawing.Color.White
        Me.ebFolioFacturaN.Location = New System.Drawing.Point(400, 53)
        Me.ebFolioFacturaN.Name = "ebFolioFacturaN"
        Me.ebFolioFacturaN.Size = New System.Drawing.Size(104, 20)
        Me.ebFolioFacturaN.TabIndex = 1
        Me.ebFolioFacturaN.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolioFacturaN.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel2
        '
        Me.lblLabel2.AutoSize = True
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.Location = New System.Drawing.Point(168, 28)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(29, 14)
        Me.lblLabel2.TabIndex = 37
        Me.lblLabel2.Text = "Caja"
        '
        'ebSucursal
        '
        Me.ebSucursal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucursal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucursal.BackColor = System.Drawing.Color.Ivory
        Me.ebSucursal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucursal.Location = New System.Drawing.Point(80, 24)
        Me.ebSucursal.Name = "ebSucursal"
        Me.ebSucursal.ReadOnly = True
        Me.ebSucursal.Size = New System.Drawing.Size(80, 22)
        Me.ebSucursal.TabIndex = 10
        Me.ebSucursal.TabStop = False
        Me.ebSucursal.Text = "000"
        Me.ebSucursal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebSucursal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.AutoSize = True
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(8, 28)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(51, 14)
        Me.lblLabel1.TabIndex = 35
        Me.lblLabel1.Text = "Sucursal"
        '
        'ebcaja
        '
        Me.ebcaja.BackColor = System.Drawing.Color.Ivory
        Me.ebcaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebcaja.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebcaja.DropListFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebcaja.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebcaja.Location = New System.Drawing.Point(208, 23)
        Me.ebcaja.Name = "ebcaja"
        Me.ebcaja.ReadOnly = True
        Me.ebcaja.Size = New System.Drawing.Size(80, 22)
        Me.ebcaja.TabIndex = 11
        Me.ebcaja.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.ebcaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
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
        Me.ebLimiteCredito.TabIndex = 6
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
        Me.ebSaldoActual.Location = New System.Drawing.Point(608, 82)
        Me.ebSaldoActual.Name = "ebSaldoActual"
        Me.ebSaldoActual.ReadOnly = True
        Me.ebSaldoActual.Size = New System.Drawing.Size(112, 22)
        Me.ebSaldoActual.TabIndex = 7
        Me.ebSaldoActual.TabStop = False
        Me.ebSaldoActual.Text = "$0.00"
        Me.ebSaldoActual.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoActual.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAbonos
        '
        Me.ebAbonos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAbonos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAbonos.BackColor = System.Drawing.Color.Ivory
        Me.ebAbonos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAbonos.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebAbonos.Location = New System.Drawing.Point(608, 112)
        Me.ebAbonos.Name = "ebAbonos"
        Me.ebAbonos.ReadOnly = True
        Me.ebAbonos.Size = New System.Drawing.Size(112, 22)
        Me.ebAbonos.TabIndex = 8
        Me.ebAbonos.TabStop = False
        Me.ebAbonos.Text = "$0.00"
        Me.ebAbonos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebImporte
        '
        Me.ebImporte.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebImporte.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebImporte.BackColor = System.Drawing.Color.Ivory
        Me.ebImporte.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebImporte.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebImporte.Location = New System.Drawing.Point(392, 112)
        Me.ebImporte.Name = "ebImporte"
        Me.ebImporte.ReadOnly = True
        Me.ebImporte.Size = New System.Drawing.Size(112, 22)
        Me.ebImporte.TabIndex = 5
        Me.ebImporte.TabStop = False
        Me.ebImporte.Text = "$0.00"
        Me.ebImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebImporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebClienteNombre
        '
        Me.ebClienteNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteNombre.BackColor = System.Drawing.Color.Ivory
        Me.ebClienteNombre.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebClienteNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteNombre.Location = New System.Drawing.Point(192, 82)
        Me.ebClienteNombre.Name = "ebClienteNombre"
        Me.ebClienteNombre.ReadOnly = True
        Me.ebClienteNombre.Size = New System.Drawing.Size(312, 22)
        Me.ebClienteNombre.TabIndex = 3
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
        Me.ebDiasPlazo.Location = New System.Drawing.Point(80, 112)
        Me.ebDiasPlazo.Name = "ebDiasPlazo"
        Me.ebDiasPlazo.ReadOnly = True
        Me.ebDiasPlazo.Size = New System.Drawing.Size(80, 22)
        Me.ebDiasPlazo.TabIndex = 4
        Me.ebDiasPlazo.TabStop = False
        Me.ebDiasPlazo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebDiasPlazo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblAbonos
        '
        Me.lblAbonos.AutoSize = True
        Me.lblAbonos.BackColor = System.Drawing.Color.Transparent
        Me.lblAbonos.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbonos.Location = New System.Drawing.Point(512, 116)
        Me.lblAbonos.Name = "lblAbonos"
        Me.lblAbonos.Size = New System.Drawing.Size(48, 14)
        Me.lblAbonos.TabIndex = 33
        Me.lblAbonos.Text = "Abonos"
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.AutoSize = True
        Me.lblSaldoActual.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldoActual.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoActual.Location = New System.Drawing.Point(512, 86)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(74, 14)
        Me.lblSaldoActual.TabIndex = 32
        Me.lblSaldoActual.Text = "Saldo Actual"
        '
        'lblLimiteCredito
        '
        Me.lblLimiteCredito.AutoSize = True
        Me.lblLimiteCredito.BackColor = System.Drawing.Color.Transparent
        Me.lblLimiteCredito.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLimiteCredito.Location = New System.Drawing.Point(512, 57)
        Me.lblLimiteCredito.Name = "lblLimiteCredito"
        Me.lblLimiteCredito.Size = New System.Drawing.Size(100, 14)
        Me.lblLimiteCredito.TabIndex = 31
        Me.lblLimiteCredito.Text = "Límite de Crédito"
        '
        'lblImporte
        '
        Me.lblImporte.BackColor = System.Drawing.Color.Transparent
        Me.lblImporte.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporte.Location = New System.Drawing.Point(328, 116)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(56, 16)
        Me.lblImporte.TabIndex = 30
        Me.lblImporte.Text = "Importe"
        '
        'lblClienteNombre
        '
        Me.lblClienteNombre.AutoSize = True
        Me.lblClienteNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblClienteNombre.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClienteNombre.Location = New System.Drawing.Point(9, 116)
        Me.lblClienteNombre.Name = "lblClienteNombre"
        Me.lblClienteNombre.Size = New System.Drawing.Size(34, 14)
        Me.lblClienteNombre.TabIndex = 28
        Me.lblClienteNombre.Text = "Plazo"
        '
        'lblClienteID
        '
        Me.lblClienteID.AutoSize = True
        Me.lblClienteID.BackColor = System.Drawing.Color.Transparent
        Me.lblClienteID.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClienteID.Location = New System.Drawing.Point(9, 86)
        Me.lblClienteID.Name = "lblClienteID"
        Me.lblClienteID.Size = New System.Drawing.Size(55, 14)
        Me.lblClienteID.TabIndex = 27
        Me.lblClienteID.Text = "Asociado"
        '
        'lblFolioFactura
        '
        Me.lblFolioFactura.AutoSize = True
        Me.lblFolioFactura.BackColor = System.Drawing.Color.Transparent
        Me.lblFolioFactura.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioFactura.Location = New System.Drawing.Point(296, 57)
        Me.lblFolioFactura.Name = "lblFolioFactura"
        Me.lblFolioFactura.Size = New System.Drawing.Size(101, 14)
        Me.lblFolioFactura.TabIndex = 26
        Me.lblFolioFactura.Text = "Folio Factura SAP"
        '
        'lblFechaLimite
        '
        Me.lblFechaLimite.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaLimite.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaLimite.Location = New System.Drawing.Point(296, 28)
        Me.lblFechaLimite.Name = "lblFechaLimite"
        Me.lblFechaLimite.Size = New System.Drawing.Size(119, 16)
        Me.lblFechaLimite.TabIndex = 29
        Me.lblFechaLimite.Text = "Fecha Límite de Pago"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(40, 490)
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
        Me.Label7.Location = New System.Drawing.Point(16, 490)
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
        Me.Label4.Location = New System.Drawing.Point(704, 490)
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
        Me.Label5.Location = New System.Drawing.Point(672, 490)
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
        Me.Label2.Location = New System.Drawing.Point(280, 490)
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
        Me.Label6.Location = New System.Drawing.Point(256, 490)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 24)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "F9"
        '
        'EstadoCuentaFacturaReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(754, 495)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "EstadoCuentaFacturaReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de Cuenta por Factura"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uIGroupBox1.ResumeLayout(False)
        Me.uIGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

#Region "Objetos"

    'Dim oAbonoCreditoDirectoMgr As AbonoCreditoDirectoManager

    'Factura
    Dim oFacturaMgr As FacturaManager
    Dim oFactura As Factura

    'Clientes
    Dim oClienteMgr As ClientesManager
    Dim oCliente As ClienteAlterno

    'Asociados
    Dim oAsociadoMgr As AsociadosManager
    Dim oAsociado As Asociado

    'Web Service Abono Credito Directo
    'Dim wsPagosCreditoDirecto As wsPagosCreditoDirecto.PagosCreditoDirecto
    Dim dsPagoCreditoDirecto As DataSet
    Dim dtFacturas As DataTable

    'Banderas
    Dim boolFromEdoCuenta As Boolean


#End Region

#Region "Miembros"

#End Region

#End Region

    Private Sub InitializeObjects()

        'oAbonoCreditoDirectoMgr = New AbonoCreditoDirectoManager(oAppContext)

        'Factura
        oFacturaMgr = New FacturaManager(oAppContext)
        oFactura = oFacturaMgr.Create
        oFactura.ClearFields()

        'Clientes
        oClienteMgr = New ClientesManager(oAppContext)
        oCliente = oClienteMgr.CreateAlterno
        oCliente.Clear()

        'Asociados
        oAsociadoMgr = New AsociadosManager(oAppContext)
        oAsociado = oAsociadoMgr.Create
        oAsociado.Clear()

    End Sub

    Private Sub EstadoCuentaFacturaReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitializeObjects()

        ebSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

        GetCajaToCombo()

        If Me.boolFromEdoCuenta Then
            DatosFacturaCorrecto(True)
        End If

    End Sub

    Private Sub EstadoCuentaFacturaReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")

            Case Keys.F5
                'Exportar
                ExportaEstadoCuentaFacturaXLS()

            Case Keys.F2
                'Nuevo
                NuevaConsulta()

            Case Keys.F9
                'Imprimir
                ImprimirEstadoDeCuentaFactura()

            Case Keys.Escape
                Me.Close()

        End Select

    End Sub

    Private Sub ImprimirEstadoDeCuentaFactura()

        Me.Cursor = Cursors.WaitCursor

        Dim oARReporte As New EstadoCuentaFacturaReport(dsPagoCreditoDirecto, ebClienteNombre.Text, ebLimiteCredito.Value, Me.ebSaldoActual.Value, Me.ebAbonos.Value)

        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Estado de Cuenta por Factura"

        oReportViewer.Report = oARReporte

        Me.Cursor = Cursors.Default

        oReportViewer.Show()

    End Sub

    Private Function DatosFacturaCorrecto(ByVal opc As Boolean) As Boolean
        Dim strfolioSAP As String

        If opc Then
            'strfolioSAP = oAbonoCreditoDirectoMgr.GetSelectFolioFacturaSDSAP(Me.ebFolioFacturaDp.Text)
            Me.ebFolioFacturaN.Text = strfolioSAP
        Else
            strfolioSAP = Me.ebFolioFacturaN.Text
            'Me.ebFolioFacturaDp.Text = oAbonoCreditoDirectoMgr.GetSelectFolioFacturaDPBySDSAP(strfolioSAP)
        End If

        If strfolioSAP = String.Empty OrElse Me.ebFolioFacturaDp.Text = String.Empty Then
            MsgBox("Folio de Factura No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Estado de Cuenta")
            Return False
        End If

        'Buscamos Factura

        '--------------------------SAP Validar Credito Cliente--------------------------
        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        'dtFacturas = oSap.Read_ZBAPI_CONSULTAFACTURAS(strfolioSAP)
        '''Edo Cuenta Erick
        dtFacturas = oFacturaMgr.SelectFacturaEdoCuentaCDT(ebFolioFacturaDp.Text).Tables("Facturas").Copy
        '''Edo Cuenta Erick

        If dtFacturas Is Nothing Then
            MsgBox("Folio de Factura No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Estado de Cuenta")
            Return False
        Else
            Dim ds As New DataSet
            ds.Tables.Add(dtFacturas)
            dsPagoCreditoDirecto = ds.Copy

            If dtFacturas.Rows.Count > 0 Then
                Dim oRow As DataRow
                oRow = dtFacturas.Rows(0)

                'Cliente
                oCliente.Clear()
                oClienteMgr.Load(oRow("Cliente"), oCliente, "D")
                'Me.ebImporte.Text = oRow("Importe")
                Me.ebImporte.Text = oRow("ComprasCargos")

                If oCliente.CodigoCliente <> 0 Then
                    ebAsociadoID.Text = oCliente.CodigoAlterno
                    ebClienteNombre.Text = oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
                End If

                'If Not opc Then
                '    Me.ebFolioFacturaDp.Text = oAbonoCreditoDirectoMgr.GetSelectFolioFacturaDPBySDSAP(oCliente.CodigoAlterno, strfolioSAP)
                'End If

                Dim Credito As New CreditoAsociadoSAP
                Credito = oSap.GetCreditoAsociadoSAP(oCliente.CodigoAlterno)

                Me.ebLimiteCredito.Text = Credito.LimiteCredito
                'Me.ebFechaLimite.Text = oRow("FechaVenci")
                Me.ebFechaLimite.Text = DateAdd(DateInterval.Day, 30, oRow("Fecha"))

                If Not IsDBNull(dtFacturas.Compute("SUM(PagosAbonos)", "")) Then
                    Me.ebAbonos.Text = dtFacturas.Compute("SUM(PagosAbonos)", "")
                Else
                    Me.ebAbonos.Text = "0.0"
                End If

                Me.ebSaldoActual.Text = CDec(Me.ebImporte.Text) - CDec(Me.ebAbonos.Text)

                'dtFacturas.Compute("SUM(ComprasCargos)", "")
                'Cargamos el Detalle de la factura Abonos
                grdDatos.DataSource = dtFacturas
                grdDatos.Refresh()

            End If
            End If

        Return True

        '--------------------------SAP--------------------------

        ''oFactura.ClearFields()
        ''oFacturaMgr.Load(ebFolioFacturaN.Text, ebcaja.Text, oFactura)

        ''If oFactura.FacturaID = 0 Then  'No Existe

        ''    MsgBox("Folio de Factura No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Estado de Cuenta")
        ''    Return False

        ''Else

        ''    If (UCase(oFactura.CodTipoVenta) <> "C") Then

        ''        MsgBox("La Factura no está registrada como Cuenta por Cobrar. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Estado de Cuenta")
        ''        Return False

        ''    End If

        ''    'Asociado
        ''    oAsociado.Clear()
        ''    oAsociadoMgr.LoadIntoByClienteID(oFactura.ClienteId, oAsociado)

        ''    If Not oAsociado.AsociadoID = 0 Then

        ''        ebAsociadoID.Value = oAsociado.AsociadoID

        ''        ebLimiteCredito.Value = oAsociado.LimiteCreditoDirectoTienda

        ''        dsPagoCreditoDirecto = Nothing

        ''        Dim arFacturaAbonos As IAsyncResult

        ''        arFacturaAbonos = wsPagosCreditoDirecto.BeginGetPagoCreditoDirectoFactura(oAsociado.AsociadoID, ebSucursal.Text, ebcaja.Text, oFactura.FolioFactura, Nothing, Nothing)

        ''        arFacturaAbonos.AsyncWaitHandle.WaitOne()

        ''        dsPagoCreditoDirecto = wsPagosCreditoDirecto.EndGetPagoCreditoDirectoFactura(arFacturaAbonos)

        ''        If dsPagoCreditoDirecto Is Nothing Then   'No Existe Factura

        ''            MsgBox("La Factura no contiene información en el sistema de Crédito. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Estado de Cuenta")
        ''            Return False

        ''        Else

        ''            Dim oRow As DataRow
        ''            oRow = dsPagoCreditoDirecto.Tables(0).Rows(0)

        ''            ebImporte.Value = oRow!PagoEstablecido
        ''            ebFechaLimite.Text = Format(oRow!FechaLimitePago, "Short Date")
        ''            ebSaldoActual.Value = oRow!Saldo
        ''            ebAbonos.Value = oRow!PagoEstablecido - oRow!Saldo
        ''            ebDiasPlazo.Text = CStr(DateDiff(DateInterval.Day, CDate(Format(oRow!FechaFactura, "short date")), oRow!FechaLimitePago)) & " dias"

        ''            'Cliente
        ''            oCliente.Clear()
        ''            oClienteMgr.LoadInto(oFactura.ClienteId, oCliente)

        ''            If Not oCliente.CodigoCliente = 0 Then
        ''                ebClienteNombre.Text = oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
        ''            End If

        ''            'Cargamos el Detalle de la factura Abonos
        ''            grdDatos.SetDataBinding(dsPagoCreditoDirecto, "Abonos")
        ''            grdDatos.Refresh()

        ''            If (oFactura.StatusFactura = "CAN") Then

        ''                MsgBox("Esta Factura fue Cancelada. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Estado de Cuenta")
        ''                Return False

        ''            End If

        ''            If oRow!Saldo <= 0 Then

        ''                MsgBox("Esta Factura ya ha sido liquidada. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Estado de Cuenta")
        ''                Return False

        ''            End If

        ''        End If

        ''    End If

        ''    Return True

        ''End If

    End Function

    Private Sub GetCajaToCombo()

        'Objeto Caja
        Dim oCajaMgr As CatalogoCajaManager
        Dim oCaja As Caja

        'Creamos Caja
        oCajaMgr = New CatalogoCajaManager(oAppContext)
        oCaja = oCajaMgr.Create

        Dim dsCaja As New DataSet
        Dim nReg As Integer, i As Integer

        dsCaja = oCajaMgr.GetAll(False)

        nReg = dsCaja.Tables(0).Rows.Count

        If nReg > 0 Then

            For i = 0 To nReg - 1

                ebcaja.Items.Add(dsCaja.Tables(0).Rows(i).Item("CodCaja"))

            Next i

            dsCaja = Nothing

        End If

        oCaja = Nothing
        oCajaMgr.Dispose()
        oCajaMgr = Nothing

        ebcaja.Text = oAppContext.ApplicationConfiguration.NoCaja

    End Sub

    Private Sub NuevaConsulta()

        ebFolioFacturaN.Text = String.Empty
        ebFolioFacturaDp.Text = String.Empty
        ebFechaLimite.Text = String.Empty
        ebLimiteCredito.Value = 0
        ebAbonos.Value = 0
        ebSaldoActual.Value = 0
        ebAsociadoID.Text = String.Empty
        ebClienteNombre.Text = String.Empty
        ebDiasPlazo.Text = String.Empty
        ebImporte.Value = 0

        grdDatos.SetDataBinding(Nothing, Nothing)
        grdDatos.Refresh()

        'ebFolioFacturaDp.Focus()

    End Sub

    Private Sub ExportaEstadoCuentaFacturaXLS()

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
        wsxl = xlapp.Sheets(1)
        wsxl.Name = "Estado de Cuenta por Documento"

        '****************************************
        'HOJA DE CALCULO AUDITORIA RETIROS
        '****************************************
        wsxl.Cells(1, 1).Value = "ESTADO DE CUENTA POR DOCUMENTO"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12
        wsxl.Range("A1:F1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:F1").BorderAround(, 2, 0, )
        wsxl.Range("A1:F1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Value = "Folio Factura "
        wsxl.Cells(2, 2).Value = ebFolioFacturaN.Text

        wsxl.Cells(2, 2).Font.Bold = True

        wsxl.Cells(2, 3).Value = "Plazo"
        wsxl.Cells(2, 4).Value = ebDiasPlazo.Text
        wsxl.Cells(2, 4).Font.Bold = True

        wsxl.Cells(2, 5).Value = "Fecha Límite"
        wsxl.Cells(2, 6).Value = ebFechaLimite.Text
        wsxl.Cells(2, 6).Font.Bold = True

        wsxl.Cells(3, 1).Value = "Asociado"
        wsxl.Cells(3, 2).Value = ebAsociadoID.Text & "  " & ebClienteNombre.Text
        wsxl.Cells(3, 2).Font.Bold = True

        wsxl.Cells(3, 5).Value = "Límite Crédito"
        wsxl.Cells(3, 6).Value = ebLimiteCredito.Text
        wsxl.Cells(3, 6).Font.Bold = True

        wsxl.Cells(4, 1).Value = "Importe"
        wsxl.Cells(4, 2).Value = ebImporte.Text
        wsxl.Cells(4, 2).Font.Bold = True

        wsxl.Cells(4, 5).Value = "Abonos"
        wsxl.Cells(4, 6).Value = ebAbonos.Text
        wsxl.Cells(4, 6).Font.Bold = True

        wsxl.Cells(5, 5).Value = "Saldo"
        wsxl.Cells(5, 6).Value = ebSaldoActual.Text
        wsxl.Cells(5, 6).Font.Bold = True

        'Encabezado
        wsxl.Cells(6, 1).Value = "Fecha"
        wsxl.Cells(6, 2).Value = "Sucursal"
        wsxl.Cells(6, 3).Value = "Folio"
        wsxl.Cells(6, 4).Value = "Detalles"
        wsxl.Cells(6, 5).Value = "Compras"
        wsxl.Cells(6, 6).Value = "Abonos"
        wsxl.Range("A6:F6").Font.Bold = True
        wsxl.Range("A6:F6").HorizontalAlignment = 3
        wsxl.Range("A6:F6").Font.Size = 8
        wsxl.Range("A6:F6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:F6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oRow In dsPagoCreditoDirecto.Tables(0).Rows
            intRow = intRow + 1
            wsxl.Cells(6 + intRow, 1).Value = "'" & Format(oRow!Fecha, "short date")
            wsxl.Cells(6 + intRow, 1).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 2).Value = "'" & oRow!Sucursal
            wsxl.Cells(6 + intRow, 2).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 3).Value = "'" & oRow!Folio
            wsxl.Cells(6 + intRow, 3).HorizontalAlignment = 4

            wsxl.Cells(6 + intRow, 4).Value = oRow!Detalle
            wsxl.Cells(6 + intRow, 4).Font.Size = 9
            wsxl.Cells(6 + intRow, 5).Value = oRow!ComprasCargos
            wsxl.Cells(6 + intRow, 6).Value = oRow!PagosAbonos
        Next

        'wsxl.Range("A" & Trim(Str(8 + intRow)) & ":F" & Trim(Str(8 + intRow))).BorderAround(, 3, 0, )
        wsxl.Range("E6:F" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        wsxl.Range("A6:A6").ColumnWidth = 13
        wsxl.Range("B6:B6").ColumnWidth = 10
        wsxl.Range("C6:C6").ColumnWidth = 10
        wsxl.Range("D6:D6").ColumnWidth = 33.6
        wsxl.Range("E6:E6").ColumnWidth = 15
        wsxl.Range("F6:F6").ColumnWidth = 15
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

    Private Sub ebFolioFacturaN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioFacturaN.Validating

        If ebFolioFacturaN.Text <> String.Empty Then

            If Not DatosFacturaCorrecto(False) Then

                NuevaConsulta()
                'e.Cancel = True

            End If

        Else

            ebFolioFacturaN.Text = String.Empty
            'e.Cancel = True

        End If
    End Sub

    Private Sub ebFolioFacturaDp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioFacturaDp.Validating
        If ebFolioFacturaDp.Text <> String.Empty Then

            If Not DatosFacturaCorrecto(True) Then

                NuevaConsulta()
                'e.Cancel = True

            End If

        Else

            ebFolioFacturaDp.Text = String.Empty
            'e.Cancel = True

        End If
    End Sub

    Public Sub ShowDev(ByVal strFolioFacturaDP As String)
        boolFromEdoCuenta = True
        ebFolioFacturaDp.Text = strFolioFacturaDP
        Me.ShowDialog()
    End Sub

End Class
