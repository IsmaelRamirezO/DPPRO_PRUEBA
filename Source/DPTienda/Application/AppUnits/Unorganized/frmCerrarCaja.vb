
Imports DportenisPro.DPTienda.ApplicationUnits.CierreCaja
Imports DportenisPro.DPTienda.ApplicationUnits.ArqueoDeCajaAU


Public Class frmCerrarCaja
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ebCaja As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents uibtnCerrarCaja As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ebFacturaFolioInicial As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFacturaFolioFinal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebMontoFacturado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents chkGuardarCajaDiferencia As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents prgProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents uIGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ebMontoAbonos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblFacturasA As System.Windows.Forms.Label
    Friend WithEvents lblFacturasC As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents nebMontoPedidosSH As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebAbonosCreditoDirecto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ebAbonosApartados As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ebNotasdeCredito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ebRetiros As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ebValeCaja As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ebFacilito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ebDpVale As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ebFonacot As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ebEfectivo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ebTarjetaElectronica As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ebTarjetaManual As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ebFondoCaja As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ebDPCardCredit As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCerrarCaja))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblFacturasC = New System.Windows.Forms.Label()
        Me.lblFacturasA = New System.Windows.Forms.Label()
        Me.prgProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.chkGuardarCajaDiferencia = New Janus.Windows.EditControls.UICheckBox()
        Me.ebMontoFacturado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ebCaja = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.uibtnCerrarCaja = New Janus.Windows.EditControls.UIButton()
        Me.ebFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.uIGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ebDPCardCredit = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ebValeCaja = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ebFacilito = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ebDpVale = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ebFonacot = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ebEfectivo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ebTarjetaElectronica = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ebTarjetaManual = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ebFondoCaja = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ebAbonosCreditoDirecto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ebAbonosApartados = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ebMontoAbonos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nebMontoPedidosSH = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ebNotasdeCredito = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ebFacturaFolioInicial = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFacturaFolioFinal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebRetiros = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uIGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.lblFacturasC)
        Me.ExplorerBar1.Controls.Add(Me.lblFacturasA)
        Me.ExplorerBar1.Controls.Add(Me.prgProgressBar1)
        Me.ExplorerBar1.Controls.Add(Me.chkGuardarCajaDiferencia)
        Me.ExplorerBar1.Controls.Add(Me.ebMontoFacturado)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.ebCaja)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.uibtnCerrarCaja)
        Me.ExplorerBar1.Controls.Add(Me.ebFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.uIGroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.Label14)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(-1, -1)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(722, 481)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblFacturasC
        '
        Me.lblFacturasC.BackColor = System.Drawing.Color.Transparent
        Me.lblFacturasC.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacturasC.ForeColor = System.Drawing.Color.Red
        Me.lblFacturasC.Location = New System.Drawing.Point(592, 360)
        Me.lblFacturasC.Name = "lblFacturasC"
        Me.lblFacturasC.Size = New System.Drawing.Size(88, 23)
        Me.lblFacturasC.TabIndex = 59
        Me.lblFacturasC.Text = "0"
        Me.lblFacturasC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFacturasA
        '
        Me.lblFacturasA.BackColor = System.Drawing.Color.Transparent
        Me.lblFacturasA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacturasA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblFacturasA.Location = New System.Drawing.Point(592, 336)
        Me.lblFacturasA.Name = "lblFacturasA"
        Me.lblFacturasA.Size = New System.Drawing.Size(88, 23)
        Me.lblFacturasA.TabIndex = 58
        Me.lblFacturasA.Text = "0"
        Me.lblFacturasA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'prgProgressBar1
        '
        Me.prgProgressBar1.Location = New System.Drawing.Point(40, 80)
        Me.prgProgressBar1.Name = "prgProgressBar1"
        Me.prgProgressBar1.Size = New System.Drawing.Size(656, 3)
        Me.prgProgressBar1.TabIndex = 46
        '
        'chkGuardarCajaDiferencia
        '
        Me.chkGuardarCajaDiferencia.BackColor = System.Drawing.Color.Transparent
        Me.chkGuardarCajaDiferencia.Location = New System.Drawing.Point(32, 400)
        Me.chkGuardarCajaDiferencia.Name = "chkGuardarCajaDiferencia"
        Me.chkGuardarCajaDiferencia.Size = New System.Drawing.Size(184, 16)
        Me.chkGuardarCajaDiferencia.TabIndex = 9
        Me.chkGuardarCajaDiferencia.Text = "Guardar con diferencias"
        Me.chkGuardarCajaDiferencia.Visible = False
        Me.chkGuardarCajaDiferencia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebMontoFacturado
        '
        Me.ebMontoFacturado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoFacturado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoFacturado.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebMontoFacturado.Location = New System.Drawing.Point(504, 296)
        Me.ebMontoFacturado.MaxLength = 9
        Me.ebMontoFacturado.Name = "ebMontoFacturado"
        Me.ebMontoFacturado.ReadOnly = True
        Me.ebMontoFacturado.Size = New System.Drawing.Size(188, 23)
        Me.ebMontoFacturado.TabIndex = 5
        Me.ebMontoFacturado.Text = "$0.00"
        Me.ebMontoFacturado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMontoFacturado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(368, 296)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 23)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Total Facturado:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebCaja
        '
        Me.ebCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCaja.BackColor = System.Drawing.Color.Ivory
        Me.ebCaja.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCaja.Location = New System.Drawing.Point(504, 41)
        Me.ebCaja.Name = "ebCaja"
        Me.ebCaja.ReadOnly = True
        Me.ebCaja.Size = New System.Drawing.Size(188, 22)
        Me.ebCaja.TabIndex = 34
        Me.ebCaja.TabStop = False
        Me.ebCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(368, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 23)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Caja:"
        '
        'uibtnCerrarCaja
        '
        Me.uibtnCerrarCaja.BackColor = System.Drawing.SystemColors.Window
        Me.uibtnCerrarCaja.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnCerrarCaja.Image = CType(resources.GetObject("uibtnCerrarCaja.Image"), System.Drawing.Image)
        Me.uibtnCerrarCaja.Location = New System.Drawing.Point(264, 400)
        Me.uibtnCerrarCaja.Name = "uibtnCerrarCaja"
        Me.uibtnCerrarCaja.Size = New System.Drawing.Size(224, 33)
        Me.uibtnCerrarCaja.TabIndex = 9
        Me.uibtnCerrarCaja.Text = "&Cerrar Caja"
        Me.uibtnCerrarCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFecha
        '
        '
        '
        '
        Me.ebFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecha.Location = New System.Drawing.Point(168, 41)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.Size = New System.Drawing.Size(188, 22)
        Me.ebFecha.TabIndex = 0
        Me.ebFecha.Value = New Date(2005, 7, 12, 0, 0, 0, 0)
        Me.ebFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Fecha:"
        '
        'uIGroupBox1
        '
        Me.uIGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.uIGroupBox1.Controls.Add(Me.ebDPCardCredit)
        Me.uIGroupBox1.Controls.Add(Me.Label24)
        Me.uIGroupBox1.Controls.Add(Me.ebValeCaja)
        Me.uIGroupBox1.Controls.Add(Me.Label19)
        Me.uIGroupBox1.Controls.Add(Me.ebFacilito)
        Me.uIGroupBox1.Controls.Add(Me.Label16)
        Me.uIGroupBox1.Controls.Add(Me.ebDpVale)
        Me.uIGroupBox1.Controls.Add(Me.Label17)
        Me.uIGroupBox1.Controls.Add(Me.ebFonacot)
        Me.uIGroupBox1.Controls.Add(Me.Label18)
        Me.uIGroupBox1.Controls.Add(Me.ebEfectivo)
        Me.uIGroupBox1.Controls.Add(Me.Label15)
        Me.uIGroupBox1.Controls.Add(Me.ebTarjetaElectronica)
        Me.uIGroupBox1.Controls.Add(Me.Label7)
        Me.uIGroupBox1.Controls.Add(Me.ebTarjetaManual)
        Me.uIGroupBox1.Controls.Add(Me.Label8)
        Me.uIGroupBox1.Controls.Add(Me.ebFondoCaja)
        Me.uIGroupBox1.Controls.Add(Me.Label6)
        Me.uIGroupBox1.Controls.Add(Me.ebAbonosCreditoDirecto)
        Me.uIGroupBox1.Controls.Add(Me.Label11)
        Me.uIGroupBox1.Controls.Add(Me.ebAbonosApartados)
        Me.uIGroupBox1.Controls.Add(Me.Label10)
        Me.uIGroupBox1.Controls.Add(Me.Label12)
        Me.uIGroupBox1.Controls.Add(Me.ebMontoAbonos)
        Me.uIGroupBox1.Controls.Add(Me.nebMontoPedidosSH)
        Me.uIGroupBox1.Controls.Add(Me.Label23)
        Me.uIGroupBox1.Controls.Add(Me.ebNotasdeCredito)
        Me.uIGroupBox1.Controls.Add(Me.Label22)
        Me.uIGroupBox1.Controls.Add(Me.Label21)
        Me.uIGroupBox1.Controls.Add(Me.Label20)
        Me.uIGroupBox1.Controls.Add(Me.ProgressBar1)
        Me.uIGroupBox1.Controls.Add(Me.Label3)
        Me.uIGroupBox1.Controls.Add(Me.ebFacturaFolioInicial)
        Me.uIGroupBox1.Controls.Add(Me.ebFacturaFolioFinal)
        Me.uIGroupBox1.Controls.Add(Me.ebRetiros)
        Me.uIGroupBox1.Controls.Add(Me.Label5)
        Me.uIGroupBox1.Controls.Add(Me.Label2)
        Me.uIGroupBox1.Location = New System.Drawing.Point(8, 25)
        Me.uIGroupBox1.Name = "uIGroupBox1"
        Me.uIGroupBox1.Size = New System.Drawing.Size(704, 415)
        Me.uIGroupBox1.TabIndex = 47
        '
        'ebDPCardCredit
        '
        Me.ebDPCardCredit.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDPCardCredit.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDPCardCredit.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebDPCardCredit.Location = New System.Drawing.Point(160, 208)
        Me.ebDPCardCredit.MaxLength = 9
        Me.ebDPCardCredit.Name = "ebDPCardCredit"
        Me.ebDPCardCredit.ReadOnly = True
        Me.ebDPCardCredit.Size = New System.Drawing.Size(188, 23)
        Me.ebDPCardCredit.TabIndex = 74
        Me.ebDPCardCredit.Text = "$0.00"
        Me.ebDPCardCredit.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDPCardCredit.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(24, 208)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(144, 23)
        Me.Label24.TabIndex = 75
        Me.Label24.Text = "DP Card Credit"
        '
        'ebValeCaja
        '
        Me.ebValeCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebValeCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebValeCaja.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebValeCaja.Location = New System.Drawing.Point(494, 168)
        Me.ebValeCaja.MaxLength = 9
        Me.ebValeCaja.Name = "ebValeCaja"
        Me.ebValeCaja.ReadOnly = True
        Me.ebValeCaja.Size = New System.Drawing.Size(188, 23)
        Me.ebValeCaja.TabIndex = 72
        Me.ebValeCaja.Text = "$0.00"
        Me.ebValeCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebValeCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(358, 168)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(136, 23)
        Me.Label19.TabIndex = 73
        Me.Label19.Text = "VALE DE CAJA:"
        '
        'ebFacilito
        '
        Me.ebFacilito.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFacilito.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFacilito.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebFacilito.Location = New System.Drawing.Point(494, 136)
        Me.ebFacilito.MaxLength = 9
        Me.ebFacilito.Name = "ebFacilito"
        Me.ebFacilito.ReadOnly = True
        Me.ebFacilito.Size = New System.Drawing.Size(188, 23)
        Me.ebFacilito.TabIndex = 70
        Me.ebFacilito.Text = "$0.00"
        Me.ebFacilito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFacilito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(358, 136)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(136, 23)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "FACILITO:"
        '
        'ebDpVale
        '
        Me.ebDpVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDpVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDpVale.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebDpVale.Location = New System.Drawing.Point(494, 72)
        Me.ebDpVale.MaxLength = 9
        Me.ebDpVale.Name = "ebDpVale"
        Me.ebDpVale.ReadOnly = True
        Me.ebDpVale.Size = New System.Drawing.Size(188, 23)
        Me.ebDpVale.TabIndex = 66
        Me.ebDpVale.Text = "$0.00"
        Me.ebDpVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDpVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(358, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(144, 23)
        Me.Label17.TabIndex = 68
        Me.Label17.Text = "DPVALE:"
        '
        'ebFonacot
        '
        Me.ebFonacot.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFonacot.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFonacot.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebFonacot.Location = New System.Drawing.Point(494, 104)
        Me.ebFonacot.MaxLength = 9
        Me.ebFonacot.Name = "ebFonacot"
        Me.ebFonacot.ReadOnly = True
        Me.ebFonacot.Size = New System.Drawing.Size(188, 23)
        Me.ebFonacot.TabIndex = 67
        Me.ebFonacot.Text = "$0.00"
        Me.ebFonacot.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFonacot.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(358, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(136, 23)
        Me.Label18.TabIndex = 69
        Me.Label18.Text = "FONACOT:"
        '
        'ebEfectivo
        '
        Me.ebEfectivo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEfectivo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEfectivo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebEfectivo.Location = New System.Drawing.Point(158, 136)
        Me.ebEfectivo.MaxLength = 9
        Me.ebEfectivo.Name = "ebEfectivo"
        Me.ebEfectivo.ReadOnly = True
        Me.ebEfectivo.Size = New System.Drawing.Size(188, 23)
        Me.ebEfectivo.TabIndex = 64
        Me.ebEfectivo.Text = "$0.00"
        Me.ebEfectivo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEfectivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(22, 136)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(136, 23)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "Efectivo:"
        '
        'ebTarjetaElectronica
        '
        Me.ebTarjetaElectronica.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTarjetaElectronica.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTarjetaElectronica.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebTarjetaElectronica.Location = New System.Drawing.Point(158, 72)
        Me.ebTarjetaElectronica.MaxLength = 9
        Me.ebTarjetaElectronica.Name = "ebTarjetaElectronica"
        Me.ebTarjetaElectronica.ReadOnly = True
        Me.ebTarjetaElectronica.Size = New System.Drawing.Size(188, 23)
        Me.ebTarjetaElectronica.TabIndex = 58
        Me.ebTarjetaElectronica.Text = "$0.00"
        Me.ebTarjetaElectronica.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTarjetaElectronica.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(144, 23)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Tarjeta Electrónica:"
        '
        'ebTarjetaManual
        '
        Me.ebTarjetaManual.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTarjetaManual.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTarjetaManual.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebTarjetaManual.Location = New System.Drawing.Point(158, 104)
        Me.ebTarjetaManual.MaxLength = 9
        Me.ebTarjetaManual.Name = "ebTarjetaManual"
        Me.ebTarjetaManual.ReadOnly = True
        Me.ebTarjetaManual.Size = New System.Drawing.Size(188, 23)
        Me.ebTarjetaManual.TabIndex = 59
        Me.ebTarjetaManual.Text = "$0.00"
        Me.ebTarjetaManual.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTarjetaManual.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 23)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Tarjeta Manual:"
        '
        'ebFondoCaja
        '
        Me.ebFondoCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFondoCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFondoCaja.BackColor = System.Drawing.Color.Ivory
        Me.ebFondoCaja.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFondoCaja.Location = New System.Drawing.Point(494, 208)
        Me.ebFondoCaja.Name = "ebFondoCaja"
        Me.ebFondoCaja.ReadOnly = True
        Me.ebFondoCaja.Size = New System.Drawing.Size(188, 22)
        Me.ebFondoCaja.TabIndex = 61
        Me.ebFondoCaja.TabStop = False
        Me.ebFondoCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFondoCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(358, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Fondo Caja:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebAbonosCreditoDirecto
        '
        Me.ebAbonosCreditoDirecto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAbonosCreditoDirecto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAbonosCreditoDirecto.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebAbonosCreditoDirecto.Location = New System.Drawing.Point(160, 336)
        Me.ebAbonosCreditoDirecto.MaxLength = 9
        Me.ebAbonosCreditoDirecto.Name = "ebAbonosCreditoDirecto"
        Me.ebAbonosCreditoDirecto.ReadOnly = True
        Me.ebAbonosCreditoDirecto.Size = New System.Drawing.Size(188, 23)
        Me.ebAbonosCreditoDirecto.TabIndex = 55
        Me.ebAbonosCreditoDirecto.Text = "$0.00"
        Me.ebAbonosCreditoDirecto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAbonosCreditoDirecto.Visible = False
        Me.ebAbonosCreditoDirecto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(24, 336)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 23)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "Abonos C. Directo:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Visible = False
        '
        'ebAbonosApartados
        '
        Me.ebAbonosApartados.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAbonosApartados.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAbonosApartados.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebAbonosApartados.Location = New System.Drawing.Point(160, 240)
        Me.ebAbonosApartados.MaxLength = 9
        Me.ebAbonosApartados.Name = "ebAbonosApartados"
        Me.ebAbonosApartados.ReadOnly = True
        Me.ebAbonosApartados.Size = New System.Drawing.Size(188, 23)
        Me.ebAbonosApartados.TabIndex = 54
        Me.ebAbonosApartados.Text = "$0.00"
        Me.ebAbonosApartados.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAbonosApartados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 240)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 23)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Abonos Apartados:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(24, 272)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 23)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Total Abonos:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebMontoAbonos
        '
        Me.ebMontoAbonos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoAbonos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoAbonos.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebMontoAbonos.Location = New System.Drawing.Point(160, 272)
        Me.ebMontoAbonos.MaxLength = 9
        Me.ebMontoAbonos.Name = "ebMontoAbonos"
        Me.ebMontoAbonos.ReadOnly = True
        Me.ebMontoAbonos.Size = New System.Drawing.Size(188, 23)
        Me.ebMontoAbonos.TabIndex = 42
        Me.ebMontoAbonos.Text = "$0.00"
        Me.ebMontoAbonos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMontoAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nebMontoPedidosSH
        '
        Me.nebMontoPedidosSH.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebMontoPedidosSH.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebMontoPedidosSH.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nebMontoPedidosSH.Location = New System.Drawing.Point(160, 304)
        Me.nebMontoPedidosSH.MaxLength = 9
        Me.nebMontoPedidosSH.Name = "nebMontoPedidosSH"
        Me.nebMontoPedidosSH.ReadOnly = True
        Me.nebMontoPedidosSH.Size = New System.Drawing.Size(188, 23)
        Me.nebMontoPedidosSH.TabIndex = 52
        Me.nebMontoPedidosSH.Text = "$0.00"
        Me.nebMontoPedidosSH.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nebMontoPedidosSH.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(24, 304)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(132, 23)
        Me.Label23.TabIndex = 53
        Me.Label23.Text = "Total Pedidos SH"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebNotasdeCredito
        '
        Me.ebNotasdeCredito.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNotasdeCredito.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNotasdeCredito.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNotasdeCredito.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNotasdeCredito.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebNotasdeCredito.Location = New System.Drawing.Point(160, 168)
        Me.ebNotasdeCredito.MaxLength = 9
        Me.ebNotasdeCredito.Name = "ebNotasdeCredito"
        Me.ebNotasdeCredito.ReadOnly = True
        Me.ebNotasdeCredito.Size = New System.Drawing.Size(188, 23)
        Me.ebNotasdeCredito.TabIndex = 50
        Me.ebNotasdeCredito.Text = "$0.00"
        Me.ebNotasdeCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNotasdeCredito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(24, 168)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(136, 23)
        Me.Label22.TabIndex = 51
        Me.Label22.Text = "Notas de Crédito:"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(360, 336)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(208, 23)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Total de Facturas Canceladas:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(360, 307)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(192, 23)
        Me.Label20.TabIndex = 48
        Me.Label20.Text = "Total de Facturas Activas:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(24, 200)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(656, 3)
        Me.ProgressBar1.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(360, 416)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Folio Final Factura:"
        Me.Label3.Visible = False
        '
        'ebFacturaFolioInicial
        '
        Me.ebFacturaFolioInicial.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFacturaFolioInicial.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFacturaFolioInicial.Location = New System.Drawing.Point(160, 416)
        Me.ebFacturaFolioInicial.MaxLength = 6
        Me.ebFacturaFolioInicial.Name = "ebFacturaFolioInicial"
        Me.ebFacturaFolioInicial.Size = New System.Drawing.Size(188, 23)
        Me.ebFacturaFolioInicial.TabIndex = 1
        Me.ebFacturaFolioInicial.Text = "0"
        Me.ebFacturaFolioInicial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFacturaFolioInicial.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFacturaFolioInicial.Visible = False
        Me.ebFacturaFolioInicial.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFacturaFolioFinal
        '
        Me.ebFacturaFolioFinal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFacturaFolioFinal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFacturaFolioFinal.Location = New System.Drawing.Point(496, 416)
        Me.ebFacturaFolioFinal.MaxLength = 6
        Me.ebFacturaFolioFinal.Name = "ebFacturaFolioFinal"
        Me.ebFacturaFolioFinal.Size = New System.Drawing.Size(188, 23)
        Me.ebFacturaFolioFinal.TabIndex = 2
        Me.ebFacturaFolioFinal.Text = "0"
        Me.ebFacturaFolioFinal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFacturaFolioFinal.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFacturaFolioFinal.Visible = False
        Me.ebFacturaFolioFinal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebRetiros
        '
        Me.ebRetiros.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebRetiros.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebRetiros.BackColor = System.Drawing.Color.Ivory
        Me.ebRetiros.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebRetiros.Location = New System.Drawing.Point(496, 240)
        Me.ebRetiros.Name = "ebRetiros"
        Me.ebRetiros.ReadOnly = True
        Me.ebRetiros.Size = New System.Drawing.Size(188, 22)
        Me.ebRetiros.TabIndex = 36
        Me.ebRetiros.TabStop = False
        Me.ebRetiros.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRetiros.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(360, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 23)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Retiros:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 416)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 23)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Folio Inicial Factura:"
        Me.Label2.Visible = False
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.BackColor = System.Drawing.Color.Ivory
        Me.EditBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox1.Location = New System.Drawing.Point(176, 240)
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.ReadOnly = True
        Me.EditBox1.Size = New System.Drawing.Size(188, 22)
        Me.EditBox1.TabIndex = 38
        Me.EditBox1.TabStop = False
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(376, 240)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 23)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Total Facturado:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(40, 240)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 23)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Fondo Caja:"
        '
        'frmCerrarCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(722, 447)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(0, 304)
        Me.Name = "frmCerrarCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cerrar Caja:"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uIGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Miembros"

    Private oCierreCaja As Caja

    Private oCierreCajasMgr As CierreCajaManager

    Private oArqueoCaja As ArqueoDeCajaManager

    Private oUserSession As String = String.Empty

#End Region

#Region "Métodos Privados"

    Private Sub Sm_Inicializar()

        oCierreCajasMgr = New CierreCajaManager(oAppContext)

        Sm_TxtLimpiar()

        ebFecha.Value = Now.Date

        ebCaja.Text = oAppContext.ApplicationConfiguration.NoCaja



        'Validar que se haya realizado el Inicio de Caja :

        If (oCierreCajasMgr.ValidarInicioCaja(ebFecha.Value) = False) Then

            MsgBox("No no ha realizado el Inicio de Caja.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If


        'Validar que no se haya realizado el Cierre de Caja :

        If (oCierreCajasMgr.ValidarCierreCaja(ebFecha.Value) = False) Then

            MsgBox("El Cierre de Caja ya fue realizado.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If
        ebFecha.Value = Date.Now

        ebRetiros.Text = Format(oCierreCajasMgr.CalcularTotalRetiros(ebFecha.Value), "Standard")

        ebFondoCaja.Text = Format(oCierreCajasMgr.CalcularTotalFondoCaja(ebFecha.Value), "Standard")

    End Sub

    Private Sub Sm_Finalizar()

        oCierreCaja = Nothing

        oCierreCajasMgr = Nothing

    End Sub

    Private Function Fm_bolTxtValidar() As Boolean

        If Not (oCierreCaja Is Nothing) Then

            MsgBox("El Cierre de Caja ya fue realizado.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If

        If (oCierreCajasMgr.ValidarInicioCaja(ebFecha.Value) = False) Then

            MsgBox("No puede Cerrar Caja ya que no ha realizado el Inicio de Caja.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If

        'Validar que no se haya realizado el Cierre de Caja :

        If (oCierreCajasMgr.ValidarCierreCaja(ebFecha.Value) = False) Then

            MsgBox("El Cierre de Caja ya fue realizado.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If

        'If oCierreCajasMgr.FacturasDelDia(ebFecha.Value) Then

            'If (ebFacturaFolioInicial.Text = 0) Then

            '    MsgBox("El campo Factura Folio Inicial es requerido.", MsgBoxStyle.Exclamation, "DPTienda")
            '    ebFacturaFolioInicial.Focus()

            '    Exit Function

            'ElseIf (oCierreCajasMgr.ValidarFacturaFolioInicial(ebFacturaFolioInicial.Text, ebFecha.Value) = False) Then

            '    MsgBox("Su Factura Inicial no corresponde a la Fecha asignada, " & vbCrLf & _
            '    "Favor de revisar sus facturas y capture de nuevo.", MsgBoxStyle.Exclamation, "DPTienda")

            '    ebFacturaFolioInicial.Focus()

            '    Exit Function

            'End If

            'If (ebFacturaFolioFinal.Text = 0) Then

            '    MsgBox("El campo Factura Folio Final es requerido.", MsgBoxStyle.Exclamation, "DPTienda")
            '    ebFacturaFolioFinal.Focus()

            '    Exit Function

            'ElseIf (oCierreCajasMgr.ValidarFacturaFolioFinal(ebFacturaFolioFinal.Text, ebFecha.Value) = False) Then

            '    MsgBox("Su Última Factura no corresponde a la Fecha asignada, " & vbCrLf & _
            '           "Favor de revisar sus facturas y capture de nuevo.", MsgBoxStyle.Exclamation, "DPTienda")

            '    ebFacturaFolioFinal.Focus()

            '    Exit Function

            'End If

            'Else

            'If Not (ebFacturaFolioInicial.Text = 0) Then

            '    MsgBox("El campo Factura Folio Inicial tiene que ser igual a 0.", MsgBoxStyle.Exclamation, "DPTienda")
            '    ebFacturaFolioInicial.Focus()

            '    Exit Function

            'ElseIf Not (ebFacturaFolioFinal.Text = 0) Then


            '    MsgBox("El campo Factura Folio Final tiene que ser igual a 0.", MsgBoxStyle.Exclamation, "DPTienda")
            '    ebFacturaFolioFinal.Focus()

            '    Exit Function

            'End If

            'End If

            'Validar que Todos los Folios de la Facturas se encuentren guardados.
            Dim intFolioNoGuardado As Integer

            'If ebFacturaFolioInicial.Value > 0 Or ebFacturaFolioFinal.Value > 0 Then

            '    If (oCierreCajasMgr.ValidarFoliosFacturas(ebFacturaFolioInicial.Text, ebFacturaFolioFinal.Text, intFolioNoGuardado) = True) Then

            '        MsgBox("La Factura con el Folio : " & intFolioNoGuardado & " No ha sido Guardada.", MsgBoxStyle.Exclamation, "DPTienda")
            '        Exit Function

            '    End If

            'End If

        'If (oCierreCajasMgr.ValidarMontoTarjetaElectronica(ebTarjetaElectronica.Text, ebFecha.Value) = False) Then

        '    MsgBox("El Monto de Tarjeta Electronica no concuerda con el registrado en el Sistema.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebTarjetaElectronica.Focus()

        '    Exit Function

        'End If

        'If (oCierreCajasMgr.ValidarMontoTarjetaManual(ebTarjetaManual.Text, ebFecha.Value) = False) Then

        '    MsgBox("El Monto de Tarjeta Manual no concuerda con el registrado en el Sistema.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebTarjetaManual.Focus()

        '    Exit Function

        'End If

        'If (oCierreCajasMgr.ValidarMontoFacturado(ebMontoFacturado.Text, ebFecha.Value) = False) Then

        '    MsgBox("El Monto Facturado no concuerda con el registrado en el Sistema.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebMontoFacturado.Focus()

        '    Exit Function

        'End If

        'If (oCierreCajasMgr.ValidarMontoAbonosApartados(ebAbonosApartados.Text, ebFecha.Value) = False) Then

        '    MsgBox("El Monto Abonos Apartados no concuerda con el registrado en el Sistema.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebAbonosApartados.Focus()

        '    Exit Function

        'End If

        'If (oCierreCajasMgr.ValidarMontoCreditoDirecto(ebAbonosCreditoDirecto.Text, ebFecha.Value) = False) Then

        '    MsgBox("El Monto Abonos Crédito Directo no concuerda con el registrado en el Sistema.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebAbonosCreditoDirecto.Focus()

        '    Exit Function

        'End If

            Return True

    End Function


    Private Function Fm_bolTxtValidarMontoCajaDiferencias() As Boolean

        If Not (oCierreCaja Is Nothing) Then

            MsgBox("El Cierre de Caja ya fue realizado.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If



        If (oCierreCajasMgr.ValidarInicioCaja(ebFecha.Value) = False) Then

            MsgBox("No puede Cerrar Caja ya que no ha realizado el Inicio de Caja.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If



        'Validar que no se haya realizado el Cierre de Caja :

        If (oCierreCajasMgr.ValidarCierreCaja(ebFecha.Value) = False) Then

            MsgBox("El Cierre de Caja ya fue realizado.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If



        'If oCierreCajasMgr.FacturasDelDia(ebFecha.Value) Then


        'If (ebFacturaFolioInicial.Text = 0) Then

        '    MsgBox("El campo Factura Folio Inicial es requerido.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebFacturaFolioInicial.Focus()

        '    Exit Function

        'ElseIf (oCierreCajasMgr.ValidarFacturaFolioInicial(ebFacturaFolioInicial.Text, ebFecha.Value) = False) Then

        '    MsgBox("Su Factura Inicial no corresponde a la Fecha asignada, " & vbCrLf & _
        '    "Favor de revisar sus facturas y capture de nuevo.", MsgBoxStyle.Exclamation, "DPTienda")

        '    ebFacturaFolioInicial.Focus()

        '    Exit Function

        'End If


        'If (ebFacturaFolioFinal.Text = 0) Then

        '    MsgBox("El campo Factura Folio Final es requerido.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebFacturaFolioFinal.Focus()

        '    Exit Function

        'ElseIf (oCierreCajasMgr.ValidarFacturaFolioFinal(ebFacturaFolioFinal.Text, ebFecha.Value) = False) Then

        '    MsgBox("Su Última Factura no corresponde a la Fecha asignada, " & vbCrLf & _
        '           "Favor de revisar sus facturas y capture de nuevo.", MsgBoxStyle.Exclamation, "DPTienda")

        '    ebFacturaFolioFinal.Focus()

        '    Exit Function

        'End If

        'Else

        'If Not (ebFacturaFolioInicial.Text = 0) Then

        '    MsgBox("El campo Factura Folio Inicial tiene que ser igual a 0.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebFacturaFolioInicial.Focus()

        '    Exit Function

        'ElseIf Not (ebFacturaFolioFinal.Text = 0) Then


        '    MsgBox("El campo Factura Folio Final tiene que ser igual a 0.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebFacturaFolioFinal.Focus()

        '    Exit Function

        'End If


        'End If


        'If (oCierreCajasMgr.ValidarMontoFacturado(ebMontoFacturado.Text, ebFecha.Value) = False) Then

        '    MsgBox("El Monto Facturado no concuerda con el registrado en el Sistema.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebMontoFacturado.Focus()

        '    Exit Function

        'End If


        Return True

    End Function



    Private Sub Sm_MostrarInformacion()

        With oCierreCaja

            ebFecha.Value = .FechaCierre

            ebCaja.Text = .CodCaja

            ebFacturaFolioInicial.Text = .FolioFacturaInicial

            ebFacturaFolioFinal.Text = .FolioFacturaFinal

            ebRetiros.Text = .Retiros

            ebFondoCaja.Text = .Fondo

            ebTarjetaElectronica.Text = .TarjetaElectronica

            ebTarjetaManual.Text = .TarjetaManual

            ebMontoFacturado.Text = .Facturacion

            ebAbonosApartados.Text = .AbonosApartados

            ebAbonosCreditoDirecto.Text = .AbonosCreditoDirecto

            ebDPCardCredit.Text = .DPCardCredit
        End With

    End Sub



    Private Sub Sm_TxtLimpiar()

        'ebFecha.Value = Date.Now

        ebCaja.Text = oAppContext.ApplicationConfiguration.Almacen

        ebFacturaFolioInicial.Text = 0

        ebFacturaFolioFinal.Text = 0

        ebRetiros.Text = Format(0, "Standard")

        ebFondoCaja.Text = Format(0, "Standard")

        ebTarjetaElectronica.Text = Format(0, "Standard")

        ebTarjetaManual.Text = Format(0, "Standard")

        ebMontoFacturado.Text = Format(0, "Standard")

        ebAbonosApartados.Text = Format(0, "Standard")

        ebAbonosCreditoDirecto.Text = Format(0, "Standard")

        ebEfectivo.Text = Format(0, "Standard")

        ebMontoAbonos.Text = Format(0, "Standard")

        Me.ebDpVale.Text = Format(0, "Standard")

        Me.ebFonacot.Text = Format(0, "Standard")

        Me.ebFacilito.Text = Format(0, "Standard")

        Me.ebValeCaja.Text = Format(0, "Standard")

        Me.lblFacturasA.Text = Format(0, "Standard")

        Me.lblFacturasC.Text = Format(0, "Standard")

        '--------------------------------------------------------
        ' JNAVA (23.03.2015): DPCARD CREDIT
        '--------------------------------------------------------
        Me.ebDPCardCredit.Text = Format(0, "Standard")


    End Sub



    Private Function Fm_decSumaMontosCierreCaja() As Decimal

        Return CType(ebRetiros.Text, Decimal) + CType(ebFondoCaja.Text, Decimal) + CType(ebTarjetaElectronica.Text, Decimal) + CType(ebTarjetaManual.Text, Decimal) + _
               CType(ebMontoFacturado.Text, Decimal) + CType(ebAbonosApartados.Text, Decimal) + CType(ebAbonosCreditoDirecto.Text, Decimal)

    End Function



    Private Sub Sm_Guardar()

        If (chkGuardarCajaDiferencia.Checked = True) Then

            If (Fm_bolTxtValidarMontoCajaDiferencias() = False) Then

                Exit Sub

            End If

        Else

            If (Fm_bolTxtValidar() = False) Then

                Exit Sub

            End If

        End If


        'CAMPO RETIROS, QUE ES IGUAL AL EFECTIVO DEL DIA
        'oArqueoCaja = New ArqueoDeCajaManager(oAppContext)

        'Dim efectivo As Decimal = oArqueoCaja.IngresosDia(Me.ebFecha.Value, oAppContext.ApplicationConfiguration.NoCaja, _
        'oAppContext.ApplicationConfiguration.Almacen)


        If CDec(Me.ebRetiros.Text) <> CDec(ebEfectivo.Text) Then

            If MessageBox.Show("Existen diferencias entre Retiros y Efectivo, ¿Desea Continuar?", "DPTienda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

        End If


        oCierreCaja = Nothing
        oCierreCaja = oCierreCajasMgr.Create

        With oCierreCaja

            '.CierreCajaID  = 
            '.InicioCajaID  = 0
            .CodCaja = oAppContext.ApplicationConfiguration.NoCaja
            '.FolioFacturaInicial = 0
            '.FolioFacturaFinal = 0
            .Retiros = ebRetiros.Text
            .TarjetaManual = ebTarjetaManual.Text
            .TarjetaElectronica = ebTarjetaElectronica.Text
            .Facturacion = ebMontoFacturado.Text
            .Fondo = ebFondoCaja.Text
            .AbonosApartados = ebAbonosApartados.Text
            .AbonosCreditoDirecto = ebAbonosCreditoDirecto.Text
            .Sobrante = Math.Abs(Math.Min((CDec(ebEfectivo.Text) - CDec(Me.ebRetiros.Text)), 0))
            .Faltante = Math.Abs(Math.Max((CDec(ebEfectivo.Text) - CDec(Me.ebRetiros.Text)), 0))
            .FechaCierre = Format(ebFecha.Value, "Short Date")
            .Usuario = UCase(oUserSession)
            '.Fecha = 
            .StatusRegistro = True

        End With


        Dim intCierreCajaID As Integer

        oCierreCajasMgr.Save(oCierreCaja, Fm_decSumaMontosCierreCaja)

        'intCierreCajaID = oCierreCaja.CierreCajaID
        'oCierreCaja = Nothing
        'oCierreCaja = oCierreCajasMgr.Load(intCierreCajaID)

        'Sm_MostrarInformacion()


        MsgBox("Cierre de Caja Guardado", MsgBoxStyle.Information, "DPTienda")
        Me.DialogResult = DialogResult.OK

    End Sub

#End Region

#Region "Métodos Privados [Eventos]"
    Public Sub CargaAutomatica()
        oCierreCajasMgr = New CierreCajaManager(oAppContext)

        'OJO' EL CAMPO RETIROS DEBE DE SER IGAUL AL EFECTIVO DEL DIA
        oArqueoCaja = New ArqueoDeCajaManager(oAppContext)
        Dim efectivo As Decimal = oArqueoCaja.IngresosDia(Me.ebFecha.Value, oAppContext.ApplicationConfiguration.NoCaja, _
                oAppContext.ApplicationConfiguration.Almacen)
        'ASIGNO EL TOTAL DE EFECTIVO AL CAMPO EBEFECTIVO 'EFECTIVO
        ebEfectivo.Value = efectivo
        If (Date.Today = Me.ebFecha.Value) Then
            'RGERMAIN 05/07/2013: Obtenemos el monto total de los pedidos SH realizados en la fecha seleccionada
            Me.nebMontoPedidosSH.Value = oCierreCajasMgr.MontoPedidosSHGET(Me.ebFecha.Value) - oArqueoCaja.DevolucionesDia(Me.ebFecha.Value, oAppContext.ApplicationConfiguration.NoCaja, _
                    oAppContext.ApplicationConfiguration.Almacen)
        Else
            'RGERMAIN 05/07/2013: Obtenemos el monto total de los pedidos SH realizados en la fecha seleccionada
            Me.nebMontoPedidosSH.Value = oCierreCajasMgr.MontoPedidosSHGET(Me.ebFecha.Value)
        End If
        
        'ASIGNO EL TOTAL DEL MONTO FACTURADO ''TOTAL FACTURADO
        ebMontoFacturado.Text = oCierreCajasMgr.MontoFacturadoGET(ebFecha.Value)

        'ASIGNO EL TOTAL DE TARJETAS ELECTRONICAS ''TARJETA ELECTRONICA
        ebTarjetaElectronica.Text = oCierreCajasMgr.TarjetaElectronicaGET(ebFecha.Value)

        'ASIGNO EL TOTAL DE TARJETAS MANUALES ''TARJETA MANUAL
        ebTarjetaManual.Text = oCierreCajasMgr.TarjetaManualGET(ebFecha.Value)

        'ASIGNO EL TOTAL DE ABONOS APARTADOS ''ABONOS APARTADOS
        ebAbonosApartados.Text = oCierreCajasMgr.AbonosApartadosGET(ebFecha.Value)

        'ASIGNO EL TOTAL DE ABONOS C.DIRECTO ''ABONOS C.DIRECTO
        ebAbonosCreditoDirecto.Text = oCierreCajasMgr.CreditoDirectoGET(ebFecha.Value)

        'ASIGNO EL TOTAL DE ABONOS ''TOTAL ABONOS
        ebMontoAbonos.Text = CDec(ebAbonosApartados.Text) + CDec(ebAbonosCreditoDirecto.Text)

        'ASIGNO EL TOTAL DE DPVALE 
        ebDpVale.Text = oCierreCajasMgr.FormasPagoGET(ebFecha.Value, "CierreDeCajaDpValeMontoGET")

        'ASIGNO EL TOTAL DE FONACOT 
        ebFonacot.Text = oCierreCajasMgr.FormasPagoGET(ebFecha.Value, "CierreDeCajaFonacotMontoGET")

        'ASIGNO EL TOTAL DE FACILITO
        ebFacilito.Text = oCierreCajasMgr.FormasPagoGET(ebFecha.Value, "CierreDeCajaFacilitoMontoGET")

        'ASIGNO EL TOTAL DE VALE DE CAJA
        ebValeCaja.Text = oCierreCajasMgr.FormasPagoGET(ebFecha.Value, "CierreDeCajaValeCajaMontoGET")

        '-------------------------------------------------------------------------------------------------
        'JNAVA (20.03.2015): ASIGNO EL TOTAL DE DP CARD CREDIT
        '-------------------------------------------------------------------------------------------------
        ebDPCardCredit.Text = oCierreCajasMgr.FormasPagoGET(ebFecha.Value, "CierreDeCajaDPCardMontoGET")

        'ASIGNO EL TOTAL DE FACTURAS ACTIVAS
        Dim dsFacturasA As New DataSet
        Dim dsFacturasC As New DataSet
        Dim dsNC As New DataSet
        dsFacturasA = oCierreCajasMgr.TotalFacturasAGet(ebFecha.Value)
        If Not IsDBNull(dsFacturasA.Tables(0).Rows(0).Item("Total")) Then
            lblFacturasA.Text = dsFacturasA.Tables(0).Rows(0).Item("Total")
        Else
            lblFacturasA.Text = "0"
        End If


        'ASIGNO EL TOTAL DE FACTURAS CANCELADAS
        dsFacturasC = oCierreCajasMgr.TotalFacturasCGet(ebFecha.Value)
        If Not IsDBNull(dsFacturasC.Tables(0).Rows(0).Item("Total")) Then
            lblFacturasC.Text = dsFacturasC.Tables(0).Rows(0).Item("Total")
        Else
            lblFacturasC.Text = "0"
        End If


        'ASIGNO EL TOTAL DE NOTAS DE CREDITO
        dsNC = oCierreCajasMgr.NotasCreditoGET(ebFecha.Value)
        If Not IsDBNull(dsNC.Tables(0).Rows(0).Item("TotalNC")) Then
            Me.ebNotasdeCredito.Text = dsNC.Tables(0).Rows(0).Item("TotalNC")
        Else
            Me.ebNotasdeCredito.Text = "$0.00"
        End If


        dsFacturasA = Nothing
        dsFacturasC = Nothing
        dsNC = Nothing
    End Sub
    Private Sub frmCerrarCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()
        CargaAutomatica()
        Me.uibtnCerrarCaja.Focus()
    End Sub

    Private Sub frmCerrarCaja_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Sm_Finalizar()
    End Sub

    Private Sub frmCerrarCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub



    Private Sub uibtnCerrarCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnCerrarCaja.Click
        If MsgBox("¿Estas seguro que los datos son correctos?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            oAppContext.Security.CloseImpersonatedSession()
            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CerrarCaja") Then
                Sm_Guardar()

                Dim FrmNumRef As New FrmNumReferencia(oAppContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), Date.Now)
                FrmNumRef.ShowDialog()
            End If
            oAppContext.Security.CloseImpersonatedSession()

        End If
    End Sub



    Private Sub ebFecha_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFecha.Validating

        oCierreCaja = Nothing
        oCierreCaja = oCierreCajasMgr.LoadByFechaCierre(ebFecha.Value)

        If Not (oCierreCaja Is Nothing) Then

            Sm_MostrarInformacion()

        Else

            'If (oCierreCajasMgr.ValidarFecha(ebFecha.Value) = True) Then

            Sm_TxtLimpiar()
            Me.CargaAutomatica()
            ebCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
            ebRetiros.Text = Format(oCierreCajasMgr.CalcularTotalRetiros(ebFecha.Value), "Standard")
            ebFondoCaja.Text = Format(oCierreCajasMgr.CalcularTotalFondoCaja(ebFecha.Value), "Standard")

            Exit Sub

            'Else

            'Sm_TxtLimpiar()

            'End If

        End If

    End Sub

    Public Sub ShowMe(ByVal strUserSession As String)

        oUserSession = strUserSession
        oAppContext.Security.CloseImpersonatedSession()
        Me.ShowDialog()

    End Sub

#End Region

    Private Sub ebFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFecha.ValueChanged
        ebTarjetaElectronica.Focus()
    End Sub
End Class