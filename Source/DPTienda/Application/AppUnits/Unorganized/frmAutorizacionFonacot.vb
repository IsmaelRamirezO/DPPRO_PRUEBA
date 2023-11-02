Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports System.IO

Public Class frmAutorizacionFonacot

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
    Friend WithEvents explorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents txtMaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtPaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents lblLabel3 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel6 As System.Windows.Forms.Label
    Friend WithEvents lblLabel7 As System.Windows.Forms.Label
    Friend WithEvents lblLabel8 As System.Windows.Forms.Label
    Friend WithEvents lblLabel9 As System.Windows.Forms.Label
    Friend WithEvents lblLabel10 As System.Windows.Forms.Label
    Friend WithEvents lblLabel11 As System.Windows.Forms.Label
    Friend WithEvents nbFactor As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbPlazo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbCapital As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbIntereses As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbPagoMensual As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbComision As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbCalculoComision As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblLabel12 As System.Windows.Forms.Label
    Friend WithEvents nbCredito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents NebCapital As Janus.Windows.GridEX.EditControls.NumericEditBox
    Public WithEvents EdBxNumAuto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ExplorerBar4 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UCmbBxIdentificacion As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblCodCaja As System.Windows.Forms.Label
    Friend WithEvents ebNumIdentificacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EdBxExpPor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents CalendarCmbAñoExp As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents chkTE As Janus.Windows.EditControls.UICheckBox
    Public WithEvents ebCVV2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCVV2 As System.Windows.Forms.Label
    Public WithEvents ebNoTarjeta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNoTarjeta As System.Windows.Forms.Label
    Friend WithEvents btnLeerTarjeta As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutorizacionFonacot))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup4 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.explorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblLabel12 = New System.Windows.Forms.Label()
        Me.nbCalculoComision = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbComision = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbPagoMensual = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbIntereses = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbCredito = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbCapital = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbPlazo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbFactor = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblLabel11 = New System.Windows.Forms.Label()
        Me.lblLabel10 = New System.Windows.Forms.Label()
        Me.lblLabel9 = New System.Windows.Forms.Label()
        Me.lblLabel8 = New System.Windows.Forms.Label()
        Me.lblLabel7 = New System.Windows.Forms.Label()
        Me.lblLabel6 = New System.Windows.Forms.Label()
        Me.lblLabel5 = New System.Windows.Forms.Label()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.txtMaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtPaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.lblLabel3 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnLeerTarjeta = New Janus.Windows.EditControls.UIButton()
        Me.ebNoTarjeta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNoTarjeta = New System.Windows.Forms.Label()
        Me.ebCVV2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCVV2 = New System.Windows.Forms.Label()
        Me.chkTE = New Janus.Windows.EditControls.UICheckBox()
        Me.EdBxNumAuto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.NebCapital = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton2 = New Janus.Windows.EditControls.UIButton()
        Me.ExplorerBar4 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.CalendarCmbAñoExp = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EdBxExpPor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ebNumIdentificacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UCmbBxIdentificacion = New Janus.Windows.EditControls.UIComboBox()
        Me.lblCodCaja = New System.Windows.Forms.Label()
        CType(Me.explorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar2.SuspendLayout()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar4.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar2
        '
        Me.explorerBar2.Controls.Add(Me.lblLabel12)
        Me.explorerBar2.Controls.Add(Me.nbCalculoComision)
        Me.explorerBar2.Controls.Add(Me.nbComision)
        Me.explorerBar2.Controls.Add(Me.nbPagoMensual)
        Me.explorerBar2.Controls.Add(Me.nbIntereses)
        Me.explorerBar2.Controls.Add(Me.nbCredito)
        Me.explorerBar2.Controls.Add(Me.nbCapital)
        Me.explorerBar2.Controls.Add(Me.nbPlazo)
        Me.explorerBar2.Controls.Add(Me.nbFactor)
        Me.explorerBar2.Controls.Add(Me.lblLabel11)
        Me.explorerBar2.Controls.Add(Me.lblLabel10)
        Me.explorerBar2.Controls.Add(Me.lblLabel9)
        Me.explorerBar2.Controls.Add(Me.lblLabel8)
        Me.explorerBar2.Controls.Add(Me.lblLabel7)
        Me.explorerBar2.Controls.Add(Me.lblLabel6)
        Me.explorerBar2.Controls.Add(Me.lblLabel5)
        Me.explorerBar2.Controls.Add(Me.btnCancelar)
        Me.explorerBar2.Controls.Add(Me.btnAceptar)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Cálculo Fonacot"
        Me.explorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar2.Location = New System.Drawing.Point(0, 328)
        Me.explorerBar2.Name = "explorerBar2"
        Me.explorerBar2.Size = New System.Drawing.Size(385, 217)
        Me.explorerBar2.TabIndex = 3
        Me.explorerBar2.Text = "ExplorerBar1"
        Me.explorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblLabel12
        '
        Me.lblLabel12.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel12.Location = New System.Drawing.Point(208, 72)
        Me.lblLabel12.Name = "lblLabel12"
        Me.lblLabel12.Size = New System.Drawing.Size(56, 23)
        Me.lblLabel12.TabIndex = 18
        Me.lblLabel12.Text = "Meses"
        '
        'nbCalculoComision
        '
        Me.nbCalculoComision.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbCalculoComision.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbCalculoComision.BackColor = System.Drawing.SystemColors.Info
        Me.nbCalculoComision.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbCalculoComision.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbCalculoComision.Location = New System.Drawing.Point(208, 96)
        Me.nbCalculoComision.Name = "nbCalculoComision"
        Me.nbCalculoComision.ReadOnly = True
        Me.nbCalculoComision.Size = New System.Drawing.Size(112, 22)
        Me.nbCalculoComision.TabIndex = 12
        Me.nbCalculoComision.TabStop = False
        Me.nbCalculoComision.Text = "$0.00"
        Me.nbCalculoComision.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbCalculoComision.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbComision
        '
        Me.nbComision.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbComision.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbComision.DecimalDigits = 2
        Me.nbComision.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbComision.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent
        Me.nbComision.Location = New System.Drawing.Point(120, 96)
        Me.nbComision.MaxLength = 4
        Me.nbComision.Name = "nbComision"
        Me.nbComision.Size = New System.Drawing.Size(72, 22)
        Me.nbComision.TabIndex = 11
        Me.nbComision.Text = "3.45 %"
        Me.nbComision.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbComision.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbPagoMensual
        '
        Me.nbPagoMensual.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbPagoMensual.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbPagoMensual.BackColor = System.Drawing.SystemColors.Info
        Me.nbPagoMensual.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbPagoMensual.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbPagoMensual.Location = New System.Drawing.Point(120, 179)
        Me.nbPagoMensual.Name = "nbPagoMensual"
        Me.nbPagoMensual.ReadOnly = True
        Me.nbPagoMensual.Size = New System.Drawing.Size(104, 22)
        Me.nbPagoMensual.TabIndex = 15
        Me.nbPagoMensual.TabStop = False
        Me.nbPagoMensual.Text = "$0.00"
        Me.nbPagoMensual.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbPagoMensual.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbIntereses
        '
        Me.nbIntereses.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbIntereses.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbIntereses.BackColor = System.Drawing.SystemColors.Info
        Me.nbIntereses.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbIntereses.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbIntereses.Location = New System.Drawing.Point(120, 123)
        Me.nbIntereses.Name = "nbIntereses"
        Me.nbIntereses.ReadOnly = True
        Me.nbIntereses.Size = New System.Drawing.Size(104, 22)
        Me.nbIntereses.TabIndex = 13
        Me.nbIntereses.TabStop = False
        Me.nbIntereses.Text = "$0.00"
        Me.nbIntereses.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbIntereses.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbCredito
        '
        Me.nbCredito.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbCredito.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbCredito.BackColor = System.Drawing.SystemColors.Info
        Me.nbCredito.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbCredito.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbCredito.Location = New System.Drawing.Point(120, 151)
        Me.nbCredito.Name = "nbCredito"
        Me.nbCredito.ReadOnly = True
        Me.nbCredito.Size = New System.Drawing.Size(104, 22)
        Me.nbCredito.TabIndex = 14
        Me.nbCredito.TabStop = False
        Me.nbCredito.Text = "$0.00"
        Me.nbCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbCredito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbCapital
        '
        Me.nbCapital.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbCapital.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbCapital.BackColor = System.Drawing.SystemColors.Info
        Me.nbCapital.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbCapital.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbCapital.Location = New System.Drawing.Point(120, 40)
        Me.nbCapital.Name = "nbCapital"
        Me.nbCapital.ReadOnly = True
        Me.nbCapital.Size = New System.Drawing.Size(104, 22)
        Me.nbCapital.TabIndex = 8
        Me.nbCapital.TabStop = False
        Me.nbCapital.Text = "$0.00"
        Me.nbCapital.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbCapital.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbPlazo
        '
        Me.nbPlazo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbPlazo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbPlazo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbPlazo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nbPlazo.Location = New System.Drawing.Point(120, 68)
        Me.nbPlazo.MaxLength = 3
        Me.nbPlazo.Name = "nbPlazo"
        Me.nbPlazo.Size = New System.Drawing.Size(72, 22)
        Me.nbPlazo.TabIndex = 10
        Me.nbPlazo.Text = "0"
        Me.nbPlazo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbPlazo.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbPlazo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbFactor
        '
        Me.nbFactor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFactor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFactor.DecimalDigits = 7
        Me.nbFactor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbFactor.Location = New System.Drawing.Point(270, 40)
        Me.nbFactor.MaxLength = 10
        Me.nbFactor.Name = "nbFactor"
        Me.nbFactor.Size = New System.Drawing.Size(90, 22)
        Me.nbFactor.TabIndex = 9
        Me.nbFactor.Text = "0.0000000"
        Me.nbFactor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFactor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel11
        '
        Me.lblLabel11.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel11.Location = New System.Drawing.Point(16, 99)
        Me.lblLabel11.Name = "lblLabel11"
        Me.lblLabel11.Size = New System.Drawing.Size(56, 23)
        Me.lblLabel11.TabIndex = 9
        Me.lblLabel11.Text = "Comisión"
        '
        'lblLabel10
        '
        Me.lblLabel10.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel10.Location = New System.Drawing.Point(16, 183)
        Me.lblLabel10.Name = "lblLabel10"
        Me.lblLabel10.Size = New System.Drawing.Size(88, 23)
        Me.lblLabel10.TabIndex = 8
        Me.lblLabel10.Text = "Pago Mensual"
        '
        'lblLabel9
        '
        Me.lblLabel9.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel9.Location = New System.Drawing.Point(16, 129)
        Me.lblLabel9.Name = "lblLabel9"
        Me.lblLabel9.Size = New System.Drawing.Size(56, 23)
        Me.lblLabel9.TabIndex = 7
        Me.lblLabel9.Text = "Intereses"
        '
        'lblLabel8
        '
        Me.lblLabel8.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel8.Location = New System.Drawing.Point(16, 159)
        Me.lblLabel8.Name = "lblLabel8"
        Me.lblLabel8.Size = New System.Drawing.Size(56, 23)
        Me.lblLabel8.TabIndex = 6
        Me.lblLabel8.Text = "Crédito"
        '
        'lblLabel7
        '
        Me.lblLabel7.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel7.Location = New System.Drawing.Point(16, 43)
        Me.lblLabel7.Name = "lblLabel7"
        Me.lblLabel7.Size = New System.Drawing.Size(56, 23)
        Me.lblLabel7.TabIndex = 5
        Me.lblLabel7.Text = "Capital"
        '
        'lblLabel6
        '
        Me.lblLabel6.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel6.Location = New System.Drawing.Point(16, 72)
        Me.lblLabel6.Name = "lblLabel6"
        Me.lblLabel6.Size = New System.Drawing.Size(56, 23)
        Me.lblLabel6.TabIndex = 4
        Me.lblLabel6.Text = "Plazo"
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel5.Location = New System.Drawing.Point(232, 44)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(40, 23)
        Me.lblLabel5.TabIndex = 3
        Me.lblLabel5.Text = "Factor"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(240, 168)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 32)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(240, 128)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(120, 32)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.txtMaterno)
        Me.explorerBar1.Controls.Add(Me.txtPaterno)
        Me.explorerBar1.Controls.Add(Me.txtNombre)
        Me.explorerBar1.Controls.Add(Me.txtCodigo)
        Me.explorerBar1.Controls.Add(Me.lblLabel4)
        Me.explorerBar1.Controls.Add(Me.lblLabel3)
        Me.explorerBar1.Controls.Add(Me.lblLabel2)
        Me.explorerBar1.Controls.Add(Me.lblLabel1)
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Expanded = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Datos del Cliente"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(385, 176)
        Me.explorerBar1.TabIndex = 2
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'txtMaterno
        '
        Me.txtMaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtMaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtMaterno.BackColor = System.Drawing.SystemColors.Info
        Me.txtMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaterno.Location = New System.Drawing.Point(136, 120)
        Me.txtMaterno.Name = "txtMaterno"
        Me.txtMaterno.ReadOnly = True
        Me.txtMaterno.Size = New System.Drawing.Size(224, 22)
        Me.txtMaterno.TabIndex = 3
        Me.txtMaterno.TabStop = False
        Me.txtMaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtMaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtPaterno
        '
        Me.txtPaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPaterno.BackColor = System.Drawing.SystemColors.Info
        Me.txtPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaterno.Location = New System.Drawing.Point(136, 92)
        Me.txtPaterno.Name = "txtPaterno"
        Me.txtPaterno.ReadOnly = True
        Me.txtPaterno.Size = New System.Drawing.Size(224, 22)
        Me.txtPaterno.TabIndex = 2
        Me.txtPaterno.TabStop = False
        Me.txtPaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtNombre
        '
        Me.txtNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(136, 64)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(224, 22)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.TabStop = False
        Me.txtNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtCodigo
        '
        Me.txtCodigo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCodigo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(136, 36)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(144, 22)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.TabStop = False
        Me.txtCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.Location = New System.Drawing.Point(32, 124)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(112, 23)
        Me.lblLabel4.TabIndex = 5
        Me.lblLabel4.Text = "Apellido Materno"
        '
        'lblLabel3
        '
        Me.lblLabel3.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel3.Location = New System.Drawing.Point(32, 95)
        Me.lblLabel3.Name = "lblLabel3"
        Me.lblLabel3.Size = New System.Drawing.Size(112, 23)
        Me.lblLabel3.TabIndex = 4
        Me.lblLabel3.Text = "Apellido Paterno"
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.Location = New System.Drawing.Point(32, 67)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(64, 23)
        Me.lblLabel2.TabIndex = 3
        Me.lblLabel2.Text = "Nombre"
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(32, 37)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(64, 23)
        Me.lblLabel1.TabIndex = 2
        Me.lblLabel1.Text = "Código"
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.Controls.Add(Me.btnLeerTarjeta)
        Me.ExplorerBar3.Controls.Add(Me.ebNoTarjeta)
        Me.ExplorerBar3.Controls.Add(Me.lblNoTarjeta)
        Me.ExplorerBar3.Controls.Add(Me.ebCVV2)
        Me.ExplorerBar3.Controls.Add(Me.lblCVV2)
        Me.ExplorerBar3.Controls.Add(Me.chkTE)
        Me.ExplorerBar3.Controls.Add(Me.EdBxNumAuto)
        Me.ExplorerBar3.Controls.Add(Me.NebCapital)
        Me.ExplorerBar3.Controls.Add(Me.Label6)
        Me.ExplorerBar3.Controls.Add(Me.Label7)
        Me.ExplorerBar3.Controls.Add(Me.UiButton1)
        Me.ExplorerBar3.Controls.Add(Me.UiButton2)
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Expanded = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Pago con Tarjeta Fonacot"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar3.Location = New System.Drawing.Point(0, 175)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(385, 209)
        Me.ExplorerBar3.TabIndex = 20
        Me.ExplorerBar3.Text = "ExplorerBar1"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnLeerTarjeta
        '
        Me.btnLeerTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerTarjeta.Icon = CType(resources.GetObject("btnLeerTarjeta.Icon"), System.Drawing.Icon)
        Me.btnLeerTarjeta.Location = New System.Drawing.Point(312, 104)
        Me.btnLeerTarjeta.Name = "btnLeerTarjeta"
        Me.btnLeerTarjeta.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerTarjeta.TabIndex = 19
        Me.btnLeerTarjeta.Visible = False
        Me.btnLeerTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNoTarjeta
        '
        Me.ebNoTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNoTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNoTarjeta.BackColor = System.Drawing.SystemColors.Info
        Me.ebNoTarjeta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNoTarjeta.Location = New System.Drawing.Point(120, 104)
        Me.ebNoTarjeta.Name = "ebNoTarjeta"
        Me.ebNoTarjeta.ReadOnly = True
        Me.ebNoTarjeta.Size = New System.Drawing.Size(192, 22)
        Me.ebNoTarjeta.TabIndex = 15
        Me.ebNoTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebNoTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNoTarjeta
        '
        Me.lblNoTarjeta.BackColor = System.Drawing.Color.Transparent
        Me.lblNoTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoTarjeta.Location = New System.Drawing.Point(32, 104)
        Me.lblNoTarjeta.Name = "lblNoTarjeta"
        Me.lblNoTarjeta.Size = New System.Drawing.Size(80, 23)
        Me.lblNoTarjeta.TabIndex = 17
        Me.lblNoTarjeta.Text = "No. Tarjeta"
        '
        'ebCVV2
        '
        Me.ebCVV2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCVV2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCVV2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCVV2.Location = New System.Drawing.Point(120, 101)
        Me.ebCVV2.Name = "ebCVV2"
        Me.ebCVV2.Size = New System.Drawing.Size(144, 22)
        Me.ebCVV2.TabIndex = 14
        Me.ebCVV2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebCVV2.Visible = False
        Me.ebCVV2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCVV2
        '
        Me.lblCVV2.BackColor = System.Drawing.Color.Transparent
        Me.lblCVV2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCVV2.Location = New System.Drawing.Point(32, 101)
        Me.lblCVV2.Name = "lblCVV2"
        Me.lblCVV2.Size = New System.Drawing.Size(80, 23)
        Me.lblCVV2.TabIndex = 15
        Me.lblCVV2.Text = "CVV2"
        Me.lblCVV2.Visible = False
        '
        'chkTE
        '
        Me.chkTE.BackColor = System.Drawing.Color.Transparent
        Me.chkTE.Location = New System.Drawing.Point(232, 40)
        Me.chkTE.Name = "chkTE"
        Me.chkTE.Size = New System.Drawing.Size(112, 24)
        Me.chkTE.TabIndex = 18
        Me.chkTE.Text = "Pago Electrónico"
        Me.chkTE.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EdBxNumAuto
        '
        Me.EdBxNumAuto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EdBxNumAuto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EdBxNumAuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EdBxNumAuto.Location = New System.Drawing.Point(120, 72)
        Me.EdBxNumAuto.Name = "EdBxNumAuto"
        Me.EdBxNumAuto.Size = New System.Drawing.Size(144, 22)
        Me.EdBxNumAuto.TabIndex = 13
        Me.EdBxNumAuto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.EdBxNumAuto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'NebCapital
        '
        Me.NebCapital.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.NebCapital.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.NebCapital.BackColor = System.Drawing.SystemColors.Info
        Me.NebCapital.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NebCapital.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.NebCapital.Location = New System.Drawing.Point(120, 40)
        Me.NebCapital.Name = "NebCapital"
        Me.NebCapital.ReadOnly = True
        Me.NebCapital.Size = New System.Drawing.Size(104, 22)
        Me.NebCapital.TabIndex = 12
        Me.NebCapital.TabStop = False
        Me.NebCapital.Text = "$0.00"
        Me.NebCapital.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.NebCapital.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(33, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 23)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Capital"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 23)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "# Autorización"
        '
        'UiButton1
        '
        Me.UiButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton1.Location = New System.Drawing.Point(192, 168)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(120, 32)
        Me.UiButton1.TabIndex = 17
        Me.UiButton1.Text = "Cancelar"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton2
        '
        Me.UiButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton2.Location = New System.Drawing.Point(72, 168)
        Me.UiButton2.Name = "UiButton2"
        Me.UiButton2.Size = New System.Drawing.Size(120, 32)
        Me.UiButton2.TabIndex = 16
        Me.UiButton2.Text = "Aceptar"
        Me.UiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ExplorerBar4
        '
        Me.ExplorerBar4.Controls.Add(Me.CalendarCmbAñoExp)
        Me.ExplorerBar4.Controls.Add(Me.Label2)
        Me.ExplorerBar4.Controls.Add(Me.EdBxExpPor)
        Me.ExplorerBar4.Controls.Add(Me.Label1)
        Me.ExplorerBar4.Controls.Add(Me.Label3)
        Me.ExplorerBar4.Controls.Add(Me.ebNumIdentificacion)
        Me.ExplorerBar4.Controls.Add(Me.UCmbBxIdentificacion)
        Me.ExplorerBar4.Controls.Add(Me.lblCodCaja)
        ExplorerBarGroup4.Expandable = False
        ExplorerBarGroup4.Expanded = False
        ExplorerBarGroup4.Icon = CType(resources.GetObject("ExplorerBarGroup4.Icon"), System.Drawing.Icon)
        ExplorerBarGroup4.Key = "Group1"
        ExplorerBarGroup4.Text = "Datos del Identificación del Cliente"
        Me.ExplorerBar4.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup4})
        Me.ExplorerBar4.Location = New System.Drawing.Point(0, 176)
        Me.ExplorerBar4.Name = "ExplorerBar4"
        Me.ExplorerBar4.Size = New System.Drawing.Size(385, 152)
        Me.ExplorerBar4.TabIndex = 21
        Me.ExplorerBar4.Text = "ExplorerBar1"
        Me.ExplorerBar4.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'CalendarCmbAñoExp
        '
        Me.CalendarCmbAñoExp.CustomFormat = "yyyy"
        Me.CalendarCmbAñoExp.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom
        '
        '
        '
        Me.CalendarCmbAñoExp.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.CalendarCmbAñoExp.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.CalendarCmbAñoExp.Location = New System.Drawing.Point(128, 120)
        Me.CalendarCmbAñoExp.Name = "CalendarCmbAñoExp"
        Me.CalendarCmbAñoExp.Size = New System.Drawing.Size(64, 22)
        Me.CalendarCmbAñoExp.TabIndex = 7
        Me.CalendarCmbAñoExp.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(16, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Fecha Expedición:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EdBxExpPor
        '
        Me.EdBxExpPor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EdBxExpPor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EdBxExpPor.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EdBxExpPor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.EdBxExpPor.Location = New System.Drawing.Point(128, 91)
        Me.EdBxExpPor.MaxLength = 15
        Me.EdBxExpPor.Name = "EdBxExpPor"
        Me.EdBxExpPor.Size = New System.Drawing.Size(128, 22)
        Me.EdBxExpPor.TabIndex = 6
        Me.EdBxExpPor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EdBxExpPor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(16, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Identificacion:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(16, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Expedida Por:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebNumIdentificacion
        '
        Me.ebNumIdentificacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumIdentificacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumIdentificacion.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumIdentificacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ebNumIdentificacion.Location = New System.Drawing.Point(128, 62)
        Me.ebNumIdentificacion.MaxLength = 15
        Me.ebNumIdentificacion.Name = "ebNumIdentificacion"
        Me.ebNumIdentificacion.Size = New System.Drawing.Size(128, 22)
        Me.ebNumIdentificacion.TabIndex = 5
        Me.ebNumIdentificacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumIdentificacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UCmbBxIdentificacion
        '
        Me.UCmbBxIdentificacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "ELECTOR"
        UiComboBoxItem1.Value = "ELECTOR"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "PASAPORTE"
        UiComboBoxItem2.Value = "PASAPORTE"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "CARTILLA MILITAR"
        UiComboBoxItem3.Value = "CARTILLA MILITAR"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "LICENCIA"
        UiComboBoxItem4.Value = "LICENCIA"
        Me.UCmbBxIdentificacion.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4})
        Me.UCmbBxIdentificacion.Location = New System.Drawing.Point(128, 33)
        Me.UCmbBxIdentificacion.Name = "UCmbBxIdentificacion"
        Me.UCmbBxIdentificacion.SelectedIndex = 0
        Me.UCmbBxIdentificacion.Size = New System.Drawing.Size(184, 22)
        Me.UCmbBxIdentificacion.TabIndex = 4
        Me.UCmbBxIdentificacion.Text = "ELECTOR"
        Me.UCmbBxIdentificacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblCodCaja
        '
        Me.lblCodCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblCodCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCodCaja.Location = New System.Drawing.Point(16, 62)
        Me.lblCodCaja.Name = "lblCodCaja"
        Me.lblCodCaja.Size = New System.Drawing.Size(56, 16)
        Me.lblCodCaja.TabIndex = 28
        Me.lblCodCaja.Text = "Numero:"
        Me.lblCodCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAutorizacionFonacot
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(378, 544)
        Me.Controls.Add(Me.ExplorerBar4)
        Me.Controls.Add(Me.explorerBar1)
        Me.Controls.Add(Me.explorerBar2)
        Me.Controls.Add(Me.ExplorerBar3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutorizacionFonacot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Venta FONACOT"
        CType(Me.explorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar2.ResumeLayout(False)
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar4.ResumeLayout(False)
        Me.ExplorerBar4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim strTarjetaBloq As String
    Dim oCatFormaPago As CatalogoFormasPagoManager
    Dim oFacturaMgr As FacturaManager

    Private Sub nbComision_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nbComision.Validating

        CalculaFonacot()

    End Sub

    Private Sub nbFactor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nbFactor.Validating

        If nbFactor.Value > 1 Then
            MsgBox("Factor no puede ser mayor a 1. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " FONACOT")
            e.Cancel = True
        Else
            CalculaFonacot()
        End If

    End Sub

    Private Sub nbPlazo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nbPlazo.Validating

        CalculaFonacot()

    End Sub

    Private Sub CalculaFonacot()

        nbCalculoComision.Value = Decimal.Round(nbCapital.Value * nbComision.Value, 2)
        nbIntereses.Value = Decimal.Round((nbCapital.Value * nbFactor.Value) - nbCalculoComision.Value, 2)
        nbCredito.Value = Decimal.Round(nbCapital.Value + nbIntereses.Value + nbCalculoComision.Value, 2)
        If nbCredito.Value > 0 And nbPlazo.Value > 0 Then

            nbPagoMensual.Value = Decimal.Round(nbCredito.Value / nbPlazo.Value, 2)

        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If oConfigCierreFI.PrinterHP Then
            If Me.UCmbBxIdentificacion.Text <> String.Empty And ebNumIdentificacion.Text <> String.Empty And EdBxExpPor.Text <> String.Empty _
                And CDec(Me.nbFactor.Text) <> 0 And CDec(nbPlazo.Text) <> 0 Then
                Me.DialogResult = DialogResult.OK
            Else
                If Me.UCmbBxIdentificacion.Text = String.Empty Then
                    MessageBox.Show("Falta Tipo Identificación", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    UCmbBxIdentificacion.Focus()
                Else
                    If ebNumIdentificacion.Text = String.Empty Then
                        MessageBox.Show("Falta Numero de Identificación", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ebNumIdentificacion.Focus()
                    Else
                        If EdBxExpPor.Text = String.Empty Then
                            MessageBox.Show("Falta Expedida POR", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            EdBxExpPor.Focus()
                        Else
                            If CDec(Me.nbFactor.Text) = 0 Then
                                MessageBox.Show("Falta Factor", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                nbFactor.Focus()
                            Else
                                If CDec(Me.nbPlazo.Text) = 0 Then
                                    MessageBox.Show("Falta Plazo", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    nbPlazo.Focus()
                                Else

                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Else
            If CDec(Me.nbFactor.Text) <> 0 And CDec(nbPlazo.Text) <> 0 Then
                Me.DialogResult = DialogResult.OK
            Else
                If CDec(Me.nbFactor.Text) = 0 Then
                    MessageBox.Show("Falta Factor", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    nbFactor.Focus()
                Else
                    If CDec(Me.nbPlazo.Text) = 0 Then
                        MessageBox.Show("Falta Plazo", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        nbPlazo.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Me.DialogResult = DialogResult.Cancel

    End Sub

    Private Sub frmAutorizacionFonacot_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oClienteMgr As ClientesManager
        Dim oClienteFonacot As ClienteAlterno

        oCatFormaPago = New CatalogoFormasPagoManager(oAppContext)
        oClienteMgr = New ClientesManager(oAppContext)
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        oClienteFonacot = oClienteMgr.CreateAlterno
        oClienteFonacot.Clear()

        'Buscar que pedos por que no se que ondas

        oClienteMgr.Load(Me.CodCliente, oClienteFonacot, Me.TipoVenta)
        'oClienteMgr.Load(Me.CodCliente, oClienteFonacot, "F")

        With oClienteFonacot
            txtCodigo.Text = .CodigoAlterno
            txtNombre.Text = .Nombre
            txtPaterno.Text = .ApellidoPaterno
            txtMaterno.Text = .ApellidoMaterno
        End With

        oClienteFonacot = Nothing
        oClienteMgr = Nothing

        Me.nbCapital.Value = Me.MontoFonacot
        NebCapital.Value = Me.MontoFonacot
        Dim Result As DialogResult

        If Me.TipoVenta = "K" Then
            ExplorerBar3.Visible = True
            explorerBar2.Visible = False
            ExplorerBar4.Visible = False
            Me.Size = New Size(392, 416)
            ActualizarStatusCamposPE(False)
        Else
            If oConfigCierreFI.PrinterHP Then
                If Me.TipoVenta = "F" Then
                    explorerBar2.Visible = True
                    ExplorerBar4.Visible = True
                    ExplorerBar3.Visible = False
                    Me.Size = New Size(392, 576)
                End If
            Else
                If Me.TipoVenta = "F" Then
                    Me.Size = New Size(392, 424)
                    explorerBar2.Location = New Point(0, 176)
                    explorerBar2.Visible = True
                    ExplorerBar4.Visible = False
                    ExplorerBar3.Visible = False

                End If
            End If
        End If
    End Sub

    Private Sub frmAutorizacionFonacot_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")

            Case Keys.Escape

                Me.DialogResult = DialogResult.Cancel

        End Select

    End Sub

#Region "Properties"

    Private m_strCodCliente As String
    Private m_decMontoFonacot As Decimal
    Private m_strTipoVenta As String
    Private m_strCodVendedor As String

    Public Property MontoFonacot() As Decimal
        Get
            Return m_decMontoFonacot
        End Get
        Set(ByVal Value As Decimal)
            m_decMontoFonacot = Value
        End Set
    End Property

    Public Property CodCliente() As String
        Get
            Return m_strCodCliente
        End Get
        Set(ByVal Value As String)
            m_strCodCliente = Value
        End Set
    End Property

    Public Property TipoVenta() As String
        Get
            Return m_strTipoVenta
        End Get
        Set(ByVal Value As String)
            m_strTipoVenta = Value
        End Set
    End Property

    Public Property CodVendedor() As String
        Get
            Return m_strCodVendedor
        End Get
        Set(ByVal Value As String)
            m_strCodVendedor = Value
        End Set
    End Property


#End Region

#Region "Tarjeta Fonacot"

    Private Sub ActualizarStatusCamposPE(ByVal visible As Boolean)

        'Me.ebCVV2.Visible = visible
        Me.ebNoTarjeta.Visible = visible
        'Me.lblCVV2.Visible = visible
        Me.lblNoTarjeta.Visible = visible
        Me.btnLeerTarjeta.Visible = visible

        If visible = True Then
            Me.EdBxNumAuto.ReadOnly = True
            Me.EdBxNumAuto.Text = ""
            Me.EdBxNumAuto.BackColor = Color.Ivory
            'Me.ebCVV2.Focus()
            Me.btnLeerTarjeta.Focus()
        Else
            Me.EdBxNumAuto.ReadOnly = False
            Me.EdBxNumAuto.BackColor = Color.White
            Me.EdBxNumAuto.Focus()
        End If

    End Sub

    Private Sub UiButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton2.Click

        If Me.EdBxNumAuto.Text = "" Then

            EdBxNumAuto.Focus()
            MessageBox.Show("Falta Numero de Autorizacion", "Dptienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            Me.DialogResult = DialogResult.OK

        End If

    End Sub

    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

#End Region


    '    Private Sub ebNoTarjeta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNoTarjeta.KeyDown

    '        If e.KeyCode = Keys.Enter Then

    '            If ebNoTarjeta.Text.Length <= 16 Then
    '                Exit Sub
    '            ElseIf Trim(Me.ebCVV2.Text) = "" AndAlso Me.chkTE.Checked = True Then
    '                MsgBox("Es necesario capturar el CVV2", MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                Me.ebNoTarjeta.Text = ""
    '                Me.ebCVV2.Focus()
    '                Exit Sub
    '            End If

    '            If Me.chkTE.Checked = True Then
    '                If oAppSAPConfig.eHub = True Then
    '                    'If booleHub Then
    '                    Dim x As New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
    '                    Dim i As Long
    '                    Dim mSalida As String
    '                    Dim mAmount As Double           '4    
    '                    Dim mPOSEntry As String         '22        
    '                    Dim mTrack2 As String           '35        
    '                    Dim mRespose As String          '61

    '                    Dim mE2 As String
    '                    Dim mHRecordType As String
    '                    Dim mHTerm As String
    '                    Dim mHCajero As String
    '                    Dim mHTienda As String
    '                    Dim mHTicket As String
    '                    Dim mHTrack2 As String
    '                    Dim mHImporte As String
    '                    Dim mHMeses As String
    '                    Dim mHSkip As String
    '                    Dim mHCVV2 As String
    '                    Dim mHCargo As String
    '                    Dim mHCredito As String
    '                    Dim mHFijo As String
    '                    Dim mCard As String
    '                    Dim mAutorizacion As String
    '                    Dim Mensaje As String
    '                    Dim Mensaje46 As String
    '                    Dim mRespcode As String
    '                    Dim mFile As Integer

    '                    Dim mDummy As String
    '                    Dim mCarPun As String
    '                    Dim mCrePun As String
    '                    Dim mCarDin As String
    '                    Dim mCreDin As String
    '                    Dim mNumCia As String
    '                    Dim mNumPlan As String
    '                    Dim mOperacion As String
    '                    Dim mAfiliacion As String
    '                    Dim mCVV2 As String = Trim(Me.ebCVV2.Text)
    '                    Dim mRespuesta As String
    '                    Dim mComentario As String



    '                    'Ocultamos informacion de la tarjeta , para dejar unicamente el numero
    '                    Dim strTrack() As String = ebNoTarjeta.Text.Split(";")
    '                    Dim strNombre As String
    '                    Dim strSeparadorIni As String, strSeparadorFin As String

    '                    If InStr(strTrack(0), "¨") > 0 Then
    '                        strSeparadorFin = "¨"
    '                        If InStr(strTrack(0), "Ä") > 0 Then
    '                            strSeparadorIni = "Ä"
    '                        ElseIf InStr(strTrack(0), "Ë") > 0 Then
    '                            strSeparadorIni = "Ë"
    '                        ElseIf InStr(strTrack(0), "Ï") > 0 Then
    '                            strSeparadorIni = "Ï"
    '                        ElseIf InStr(strTrack(0), "Ö") > 0 Then
    '                            strSeparadorIni = "Ö"
    '                        ElseIf InStr(strTrack(0), "Ü") > 0 Then
    '                            strSeparadorIni = "Ü"
    '                        ElseIf InStr(strTrack(0), "Ÿ") > 0 Then
    '                            strSeparadorIni = "Ÿ"
    '                        Else
    '                            strSeparadorIni = "¨"
    '                        End If
    '                    Else
    '                        strSeparadorFin = "^"
    '                        If InStr(strTrack(0), "Â") > 0 Then
    '                            strSeparadorIni = "Â"
    '                        ElseIf InStr(strTrack(0), "Ê") > 0 Then
    '                            strSeparadorIni = "Ê"
    '                        ElseIf InStr(strTrack(0), "Î") > 0 Then
    '                            strSeparadorIni = "Î"
    '                        ElseIf InStr(strTrack(0), "Ô") > 0 Then
    '                            strSeparadorIni = "Ô"
    '                        ElseIf InStr(strTrack(0), "Û") > 0 Then
    '                            strSeparadorIni = "Û"
    '                        Else
    '                            strSeparadorIni = "^"
    '                        End If

    '                    End If
    '                    strNombre = GetName(strTrack(0), strSeparadorIni, strSeparadorFin)

    '                    If strNombre = "" Then
    '                        MessageBox.Show("No se puede continuar con la transacción. Es necesario que la tarjeta contenga el nombre del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        Me.ebCVV2.Text = ""
    '                        ebNoTarjeta.Text = ""
    '                        Me.ebCVV2.Focus()
    '                        Exit Sub
    '                    End If
    '                    'If InStr(strTrack(0), "¨") > 0 Then
    '                    '    strNombre = strTrack(0).Substring(18, strTrack(0).IndexOf("¨", 19) - 18)
    '                    '    strNombre = strNombre.Replace("¨", "").Trim
    '                    'Else
    '                    '    strNombre = strTrack(0).Substring(18, strTrack(0).IndexOf("^", 19) - 18)
    '                    '    strNombre = strNombre.Replace("^", "").Trim
    '                    'End If
    '                    ebNoTarjeta.Text = strTrack(1)

    '                    Dim intPosition As Integer = 0
    '                    Dim strVencimiento As String = String.Empty
    '                    Dim strPromocion As String = String.Empty
    '                    Dim strNum As String = (ebNoTarjeta.Text).Replace(";", "")
    '                    intPosition = InStr(strNum, "=")
    '                    strVencimiento = Mid(strNum, intPosition + 3, 2) & "/" & Mid(strNum, intPosition + 1, 2)
    '                    strNum = Mid(strNum, 1, intPosition - 1)

    '                    If strTarjetaBloq <> "" Then
    '                        Dim strTarjetasBloq As String() = strTarjetaBloq.Split("°")
    '                        For Each Str As String In strTarjetasBloq
    '                            If Str.ToUpper.Trim = strNum.ToUpper.Trim Then
    '                                MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                Me.ebNoTarjeta.Text = strNum
    '                                Exit Sub
    '                            End If
    '                        Next
    '                    ElseIf Me.NebCapital.Value > 5000 Then
    '                        oAppContext.Security.CloseImpersonatedSession()
    '                        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
    '                            MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                            Me.ebNoTarjeta.Text = strNum
    '                            Exit Sub
    '                        Else
    '                            oAppContext.Security.CloseImpersonatedSession()
    '                        End If
    '                    ElseIf oCatFormaPago.TarjetaUsadaHoy(strNum) Then
    '                        oAppContext.Security.CloseImpersonatedSession()
    '                        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
    '                            MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                            Me.ebNoTarjeta.Text = strNum
    '                            Exit Sub
    '                        Else
    '                            oAppContext.Security.CloseImpersonatedSession()
    '                        End If
    '                    End If

    '                    'INICIO Consulta de promociones
    '                    Dim strProSkip, strProMeses As String
    '                    mTrack2 = (ebNoTarjeta.Text).Replace(";", "")
    '                    mTrack2 = (mTrack2).Replace("?", "")

    '                    mSalida = x.PagoTarjeta(oAppContext.ApplicationConfiguration.Almacen, _
    '                    oAppContext.ApplicationConfiguration.NoCaja, Me.CodVendedor, _
    '                    "000001", 902, mTrack2, NebCapital.Value, mHTicket, mComentario, mRespuesta, _
    '                    mHMeses, mHSkip, mCVV2)

    '                    strProMeses = ""
    '                    strProSkip = ""

    '                    mDummy = mSalida
    '                    Do While Len(mDummy) > 0
    '                        mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
    '                        mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
    '                        If InStr(mRespose, "39==") > 0 Then
    '                            mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                        End If
    '                        If InStr(mRespose, "43==") > 0 Then
    '                            Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                            If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
    '                        End If
    '                        If InStr(mRespose, "46==") > 0 Then
    '                            Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                        End If

    '                    Loop
    '                    If mRespcode = "00" AndAlso InStr(Mensaje46, "|") > 0 Then
    '                        'Mando llamar la pantalla para seleccionar la promocion del pago
    '                        Dim ofrm As New frmPromociones(Mensaje46)
    '                        If ofrm.ShowDialog() = DialogResult.OK Then
    '                            strProMeses = ofrm.Plazo
    '                            strProSkip = ofrm.Skip
    '                            strPromocion = ofrm.ebPromocion.Text
    '                            'intPromo = CInt(strProMeses)
    '                        Else
    '                            Me.ebNoTarjeta.Text = ""
    '                            Me.ebCVV2.Text = ""
    '                            Me.ebCVV2.Focus()

    '                            Exit Sub
    '                        End If

    '                    End If
    '                    'FIN Consulta de promociones

    '                    'Limpiamos las variebles que pudieron ser afectadas en la consulta de promociones
    '                    x = New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
    '                    mRespcode = ""
    '                    Mensaje = ""
    '                    Mensaje46 = ""

    '                    On Error Resume Next
    '                    mHTienda = oAppContext.ApplicationConfiguration.Almacen
    '                    mHTerm = oAppContext.ApplicationConfiguration.NoCaja
    '                    mHCajero = Me.CodVendedor
    '                    mHRecordType = 2
    '                    mPOSEntry = "902"
    '                    mTrack2 = (ebNoTarjeta.Text).Replace(";", "")
    '                    mTrack2 = (mTrack2).Replace("?", "")
    '                    ebNoTarjeta.Text = strNum
    '                    mAmount = CDbl(NebCapital.Text)
    '                    'El ticket debe de variar, ver de donde se va a sacar el consecutivo
    '                    mHTicket = oAppSAPConfig.Ticket

    '                    If InStr(mTrack2, "=") > 0 Then
    '                        mCard = mTrack2.Substring(0, InStr(mTrack2, "=") - 1)
    '                    End If

    '                    mSalida = ""
    '                    mDummy = ""

    '                    Select Case CInt(mHRecordType)
    '                        Case 1 : mHCVV2 = "    " 'Consulta Planes
    '                            mCVV2 = "    "
    '                            mOperacion = "000001"
    '                        Case 2 : mOperacion = "000000" 'CreditAuth
    '                            mHMeses = strProMeses
    '                            mHSkip = strProSkip
    '                            mHCVV2 = ebCVV2.Text
    '                            mCVV2 = Trim(ebCVV2.Text)
    '                            'Case 3 : mOperacion = "000003" 'ConsCteFrec
    '                            'Case 4 : mOperacion = "000004" 'ActCteFrec
    '                            '    mCarPun = txtCargoPun.Text
    '                            '    mCrePun = txtAbonoPun.Text
    '                            '    mCarDin = txtCargoDin.Text
    '                            '    mCreDin = txtAbonoDin.Text
    '                            '    mAmount = mCarPun & "|" & mCrePun & "|" & mCarDin & "|" & mCreDin
    '                            'Case 5 : mOperacion = "000005" 'CatalogoCiaCelular
    '                            'Case 6 : mOperacion = "000006" 'PlanCelular
    '                            'Case 7 : mOperacion = "000007" 'VentaTACelular
    '                            '    mHMeses = txtSkip.Text
    '                            '    mHSkip = txtMeses.Text
    '                            'Case 8 : mOperacion = "000008" 'PeticionVenta
    '                            'Case 9 : mOperacion = "000009" 'ConsultaSaldo
    '                            'Case 10 : mOperacion = "000010" 'ActTarjetaRegalo
    '                            '    mHCargo = txtCargoDin.Text
    '                            '    mHCredito = txtAbonoDin.Text
    '                            '    If mHCredito > 0 Then
    '                            '        mAmount = mHCredito
    '                            '        mOperacion = "000110"
    '                            '    Else
    '                            '        mAmount = mHCargo
    '                            '    End If
    '                            'Case 11 : mOperacion = "000011" 'ConsultaBono
    '                    End Select
    '                    'txtOutput.Text = ""
    '                    mSalida = x.PagoTarjeta(mHTienda, mHTerm, mHCajero, mOperacion, mPOSEntry, mTrack2, mAmount, mHTicket, mComentario, mRespuesta, mHMeses, mHSkip, mCVV2)

    '                    mDummy = mSalida
    '                    Do While Len(mDummy) > 0
    '                        mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
    '                        mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
    '                        If InStr(mRespose, "38==") > 0 Then
    '                            mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
    '                        End If
    '                        If InStr(mRespose, "39==") > 0 Then
    '                            mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                        End If
    '                        If InStr(mRespose, "43==") > 0 Then
    '                            Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                            If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
    '                        End If
    '                        If InStr(mRespose, "46==") > 0 Then
    '                            Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                            Mensaje46 = Replace(Mensaje46, "|", vbCrLf)
    '                        End If
    '                        If InStr(mRespose, "48==") > 0 Then
    '                            mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim 'Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)).Substring(0, 10)
    '                        End If
    '                    Loop
    '                    If mOperacion = "000001" Then
    '                        If mAutorizacion > 1 Then
    '                            Mid$(mHFijo, 4, 1) = "1"
    '                        End If
    '                        While InStr(Mensaje46, vbCrLf) > 0
    '                            mDummy = Mensaje46.Substring(0, InStr(Mensaje46, vbCrLf) - 1)
    '                            Mensaje46 = Mensaje46.Substring(InStr(Mensaje46, vbCrLf) + 1, Len(Mensaje46) - InStr(Mensaje46, vbCrLf) - 1)
    '                        End While
    '                    Else
    '                        mDummy = mHFijo
    '                        If mOperacion = "000002" Then
    '                            mDummy = mDummy & mRespcode & mAutorizacion
    '                            mDummy = mDummy & Mensaje.Substring(0, 40)
    '                            If Len(Mensaje) < 40 Then
    '                                mDummy = mDummy & Space(40 - Len(Mensaje))
    '                            End If
    '                        End If
    '                        If mOperacion = "000002" Then
    '                            mDummy = mDummy & Mensaje46.Substring(0, 20)
    '                            If Len(Mensaje46) < 20 Then
    '                                mDummy = mDummy & Space(20 - Len(Mensaje46))
    '                            End If
    '                            mDummy = mDummy & mAfiliacion
    '                        Else
    '                            mDummy = mDummy & Mensaje46
    '                        End If

    '                    End If


    '                    If mRespcode = "00" AndAlso Trim(mAutorizacion) <> "" AndAlso Trim(mAfiliacion) <> "" Then

    '                        'If Mensaje46 Is Nothing Then
    '                        '    Mensaje46 = "00"
    '                        'End If

    '                        Mensaje = UCase(Mensaje)

    '                        'Transaccion Exitosa
    '                        Me.EdBxNumAuto.Text = mAutorizacion

    '                        MsgBox("Transacción Exitosa" & Microsoft.VisualBasic.vbCrLf & "Preparar Miniprinter", MsgBoxStyle.Information, "DPTienda")

    '                        ''''I. Actualizamos Ticket.
    '                        Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
    '                        Dim oSApReader As New SapConfigReader(strConfigurationFile)
    '                        oAppSAPConfig.Ticket = oAppSAPConfig.Ticket + 1
    '                        oSApReader.SaveSettings(oAppSAPConfig)
    '                        ''''F. Actualizamos Ticket.


    '                        ''Original Banco
    '                        Dim bolReimpresion As Boolean = False

    'Reimprimir:

    '                        Dim oARReporte As New rptTicketBancomer(CDbl(NebCapital.Text), strNum, strVencimiento, mAutorizacion, strPromocion, "VENTA", strNombre, Me.CodVendedor, _
    '                                                                mAfiliacion, "BANCOMER", "ORIGINAL BANCO", mPOSEntry, True, True)
    '                        oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
    '                        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                        oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                        oARReporte.Run()
    '                        oARReporte.Document.Print(False, False)

    '                        'Copia Cliente
    '                        Dim oARReporteC As New rptTicketBancomer(CDbl(NebCapital.Text), strNum, strVencimiento, mAutorizacion, strPromocion, "VENTA", strNombre, Me.CodVendedor, _
    '                                                               mAfiliacion, "BANCOMER", "COPIA CLIENTE")
    '                        oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
    '                        oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                        oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                        oARReporteC.Run()
    '                        oARReporteC.Document.Print(False, False)

    '                        If bolReimpresion = False Then
    '                            If MessageBox.Show("¿Desea reimpirmir los vouchers?", "Dportenis Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
    '                                bolReimpresion = True
    '                                GoTo Reimprimir
    '                            End If
    '                        End If

    '                        Me.UiButton2.Focus()
    '                        Me.UiButton2.PerformClick()

    '                    Else
    '                        'Transaccion Rechazada

    '                        If Trim(mRespcode) <> "00" Then

    '                            Dim Motivo As String = ""

    '                            Select Case mRespcode.Trim
    '                                Case "04", "14", "41", "43", "142"
    '                                    Me.strTarjetaBloq &= Me.ebNoTarjeta.Text & "°"
    '                                    Motivo = "La tarjeta ha sido rechazada.".ToUpper
    '                                Case "49"
    '                                    Motivo = "CVV2 Incorrecto.".ToUpper
    '                                Case "91"
    '                                    Motivo = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
    '                            End Select

    '                            MessageBox.Show("Transacción Rechazada." & vbCrLf & Motivo & vbCrLf & _
    '                                   mSalida, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '                        ElseIf Trim(mAutorizacion) = "" AndAlso Trim(mAfiliacion) = "" Then

    '                            MsgBox("Transacción Rechazada. No se regresaron el número de afiliación ni el número" & _
    '                                   " de autorización." & Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                                   MsgBoxStyle.Exclamation, "DPTienda")

    '                        ElseIf Trim(mAutorizacion) = "" Then

    '                            MsgBox("Transacción Rechazada. No se regresó el número de autorización." & _
    '                                   Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                                   MsgBoxStyle.Exclamation, "DPTienda")

    '                        ElseIf Trim(mAfiliacion) = "" Then

    '                            MsgBox("Transacción Rechazada. No se regresó el número de afiliación." & _
    '                                   Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                                   MsgBoxStyle.Exclamation, "DPTienda")

    '                        End If

    '                        Me.ebNoTarjeta.Text = ""
    '                        Me.ebCVV2.Text = ""
    '                        Me.ebCVV2.Focus()

    '                    End If


    '                    'mConsecutivo = mConsecutivo + 1
    '                    'txtOutput.Text = "Mensaje al Voucher" & vbCrLf & mDummy & vbCrLf
    '                    'txtOutput.Text = "Mensaje Recibido" & vbCrLf & mSalida & vbCrLf
    '                    'End If
    '                End If

    '            End If

    '        End If

    '    End Sub

    Private Sub GenerarArchivoMonto(ByVal Ruta As String, ByVal monto As String)

        Dim oStreamW As StreamWriter

        oStreamW = New StreamWriter(Ruta)

        oStreamW.Write(monto)

        oStreamW.Close()

    End Sub

    Private Function LeerArchivoTarjeta(ByVal Ruta As String) As String()

        Dim oStreamR As StreamReader
        Dim strContenido() As String

        oStreamR = New StreamReader(Ruta)

        strContenido = oStreamR.ReadToEnd.Split("°")

        oStreamR.Close()

        File.Delete(Ruta)

        Return strContenido

    End Function

    Private Sub AutorizaCargoTarjeta()

        Dim Ruta As String = "C:\LecturaTarjeta.txt"
        Dim oProcesos() As Process

        If Me.chkTE.Checked = True Then
            If oAppSAPConfig.eHub = True Then

                Dim x As DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
                Dim mSalida As String
                Dim mAmount As Double           '4    
                Dim mPOSEntry As String         '22        
                Dim mTrack2 As String           '35        
                Dim mRespose As String          '61
                Dim mHRecordType As String
                Dim mHTerm As String
                Dim mHCajero As String
                Dim mHTienda As String
                Dim mHTicket As String
                Dim mHMeses As String
                Dim mHSkip As String
                Dim mAutorizacion As String
                Dim Mensaje As String
                Dim Mensaje46 As String
                Dim mRespcode As String
                Dim mDummy As String
                Dim mOperacion As String
                Dim mAfiliacion As String
                Dim mCVV2 As String = Trim(Me.ebCVV2.Text)
                Dim mRespuesta As String
                Dim mComentario As String
                Dim strNombre As String
                Dim strCriptograma As String = ""

                'If strNombre.Trim = "" Then
                '    MessageBox.Show("No se puede continuar con la transacción. Es necesario que la tarjeta contenga el nombre del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Me.ebCVV2.Text = ""
                '    ebNoTarjeta.Text = ""
                '    Me.ebCVV2.Focus()
                '    Exit Sub
                'End If

                Dim strVencimiento As String = ""
                Dim strPromocion As String = ""
                Dim strNum As String = ""

                'If strTarjetaBloq <> "" Then
                '    Dim strTarjetasBloq As String() = strTarjetaBloq.Split("°")
                '    For Each Str As String In strTarjetasBloq
                '        If Str.ToUpper.Trim = strNum.ToUpper.Trim Then
                '            MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '            Me.ebNoTarjeta.Text = strNum
                '            Exit Sub
                '        End If
                '    Next
                'ElseIf Me.NebCapital.Value > 5000 Then
                If Me.NebCapital.Value > oConfigCierreFI.MontoMaxTarjetas Then
                    oAppContext.Security.CloseImpersonatedSession()
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                        MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Me.ebNoTarjeta.Text = strNum
                        Exit Sub
                    Else
                        oAppContext.Security.CloseImpersonatedSession()
                    End If
                    'ElseIf oCatFormaPago.TarjetaUsadaHoy(strNum) Then
                    '    oAppContext.Security.CloseImpersonatedSession()
                    '    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                    '        MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '        Me.ebNoTarjeta.Text = strNum
                    '        Exit Sub
                    '    Else
                    '        oAppContext.Security.CloseImpersonatedSession()
                    '    End If
                End If

                Dim strProSkip As String = "", strProMeses As String = ""
                Dim mFirma As String = ""
                Dim mLote As String = ""
                Dim mSubtechTermID As String = ""
                Dim mTrace As String = ""

                'Limpiamos las variebles que pudieron ser afectadas en la consulta de promociones
                x = New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
                mRespcode = ""
                Mensaje = ""
                Mensaje46 = ""

                On Error Resume Next
                mHTienda = oAppContext.ApplicationConfiguration.Almacen
                mHTerm = oAppContext.ApplicationConfiguration.NoCaja
                mHCajero = Me.CodVendedor
                mHRecordType = 2
                mAmount = CDbl(NebCapital.Text)
                'El ticket debe de variar, ver de donde se va a sacar el consecutivo
                mHTicket = oAppSAPConfig.Ticket

                mSalida = ""
                mDummy = ""

                Select Case CInt(mHRecordType)
                    Case 1 'Consulta Planes
                        mOperacion = "000001"
                    Case 2 'CreditAuth
                        mOperacion = "000000"
                        mHMeses = strProMeses
                        mHSkip = strProSkip
                End Select

                oProcesos = Process.GetProcessesByName("eHubEMV")
                If oProcesos.Length < 1 Then
                    Process.Start(Application.StartupPath & "\eHubEMV.exe")
                End If
                mSalida = x.PagoTarjeta(mHTienda, mHTerm, mHCajero, mOperacion, mPOSEntry, mTrack2, mAmount, mHTicket, mComentario, mRespuesta, "", "", mHMeses, mHSkip, mCVV2)

                mHTicket = ""
                mDummy = mSalida
                Do While Len(mDummy) > 0
                    mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
                    mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
                    If InStr(mRespose, "22==") > 0 Then
                        mPOSEntry = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
                    End If
                    If InStr(mRespose, "35==") > 0 Then
                        mTrack2 = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
                    End If
                    If InStr(mRespose, "38==") > 0 Then
                        mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
                    End If
                    If InStr(mRespose, "39==") > 0 Then
                        mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                    End If
                    If InStr(mRespose, "43==") > 0 Then
                        Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                        If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
                    End If
                    If InStr(mRespose, "46==") > 0 Then
                        Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                        Mensaje46 = Replace(Mensaje46, "|", vbCrLf)
                    End If
                    If InStr(mRespose, "48==") > 0 Then
                        mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim 'Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)).Substring(0, 10)
                    End If
                    If InStr(mRespose, "61==") > 0 Then
                        mFirma = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                    End If
                    If InStr(mRespose, "62==") > 0 Then
                        mSubtechTermID = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                    End If
                    If InStr(mRespose, "63==") > 0 Then
                        mLote = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                    End If
                    If InStr(mRespose, "64==") > 0 Then
                        mTrace = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                    End If
                    If InStr(mRespose, "65==") > 0 Then
                        mHTicket = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                    End If
                Loop

                ''''I. Actualizamos Ticket.
                Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
                Dim oSApReader As New SapConfigReader(strConfigurationFile)
                oAppSAPConfig.Ticket = oAppSAPConfig.Ticket + 1
                oSApReader.SaveSettings(oAppSAPConfig)
                ''''F. Actualizamos Ticket.

                If mRespcode = "00" AndAlso mAutorizacion.Trim <> "" AndAlso mAfiliacion.Trim <> "" Then

                    Dim strTrack2() As String = mTrack2.Split("=")

                    Me.ebNoTarjeta.Text = strTrack2(0).Replace(";", "")
                    strNum = Me.ebNoTarjeta.Text.Trim
                    strVencimiento = strTrack2(1).Substring(2, 2) & "/" & strTrack2(1).Substring(0, 2)
                    If mPOSEntry.Trim = "051" Then
                        Dim strMsgs() As String = Mensaje46.Split(",")
                        strCriptograma = strMsgs(strMsgs.Length - 1).Trim
                        If InStr(strCriptograma, "ARQC") <= 0 Then strCriptograma = ""
                    End If

                    Dim intPromo As Integer

                    If InStr(Mensaje46, "3 MESES") > 0 Then
                        strPromocion = "3 Meses Sin Intereses"
                        intPromo = 3
                    ElseIf InStr(Mensaje46, "6 MESES") > 0 Then
                        strPromocion = "6 Meses Sin Intereses"
                        intPromo = 6
                    ElseIf InStr(Mensaje46, "9 MESES") > 0 Then
                        strPromocion = "9 Meses Sin Intereses"
                        intPromo = 9
                    ElseIf InStr(Mensaje46, "12 MESES") > 0 Then
                        strPromocion = "12 Meses Sin Intereses"
                        intPromo = 12
                    Else
                        strPromocion = "Normal"
                        intPromo = 1
                    End If

                    Mensaje = ""
                    Mensaje = oFacturaMgr.BancoAutorizador(Me.ebNoTarjeta.Text, intPromo).ToUpper

                    Dim strBanco As String = ""

                    If InStr(Mensaje, "BANAMEX") > 0 Then
                        strBanco = "BANAMEX"
                    ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
                        strBanco = "BANCOMER"
                    ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
                        strBanco = "SANTANDER"
                    End If

                    'Transaccion Exitosa
                    Me.EdBxNumAuto.Text = mAutorizacion

                    MsgBox("Transacción Exitosa" & Microsoft.VisualBasic.vbCrLf & "Preparar Miniprinter", MsgBoxStyle.Information, "DPTienda")

                    Dim bolReimpresion As Boolean = False
                    Dim oReportView As ReportViewerForm
Reimprimir:
                    Select Case strBanco.ToUpper

                        Case "BANAMEX"
Imprime_Banamex:
                            ''Original Banco
                            Dim oARReporte As New rptTicketBANAMEX(CDbl(NebCapital.Text), strNum, strVencimiento, _
                                                                   mAutorizacion, strPromocion, "VENTA", _
                                                                   strNombre, Me.CodVendedor, _
                                                                   mAfiliacion, strBanco, "ORIGINAL BANCO", _
                                                                   mFirma, strCriptograma, True, mHTicket, mLote, _
                                                                   mTrace, mSubtechTermID)
                            oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                            oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                            oARReporte.Run()
                            oARReporte.Document.Print(False, False)

                            ''Copia Cliente
                            Dim oARReporteC As New rptTicketBANAMEX(CDbl(NebCapital.Text), strNum, strVencimiento, _
                                                                    mAutorizacion, strPromocion, "VENTA", _
                                                                    strNombre, Me.CodVendedor, _
                                                                    mAfiliacion, strBanco, "COPIA CLIENTE", _
                                                                    mFirma, strCriptograma, True, mHTicket, mLote, _
                                                                   mTrace, mSubtechTermID)
                            oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                            oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                            oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                            oARReporteC.Run()
                            oARReporteC.Document.Print(False, False)

                            oReportView = New ReportViewerForm
                            oReportView.Report = oarreporte
                            oReportView.Show()

                            oReportView = New ReportViewerForm
                            oReportView.Report = oarreportec
                            oReportView.Show()

                        Case "BANCOMER"

                            Dim oARReporte As New rptTicketBancomer(CDbl(NebCapital.Text), strNum, strVencimiento, _
                                                                    mAutorizacion, strPromocion, "VENTA", _
                                                                    strNombre, Me.CodVendedor, _
                                                                    mAfiliacion, strBanco, "ORIGINAL BANCO", _
                                                                    mPOSEntry, True, True, strCriptograma, _
                                                                    mFirma)
                            oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                            oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                            oARReporte.Run()
                            oARReporte.Document.Print(False, False)

                            'Copia Cliente
                            Dim oARReporteC As New rptTicketBancomer(CDbl(NebCapital.Text), strNum, strVencimiento, _
                                                                    mAutorizacion, strPromocion, "VENTA", _
                                                                    strNombre, Me.CodVendedor, _
                                                                    mAfiliacion, strBanco, "COPIA CLIENTE", _
                                                                    mPOSEntry, True, True, strCriptograma, _
                                                                    mFirma)
                            oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                            oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                            oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                            oARReporteC.Run()
                            oARReporteC.Document.Print(False, False)

                            oReportView = New ReportViewerForm
                            oReportView.Report = oarreporte
                            oReportView.Show()

                            oReportView = New ReportViewerForm
                            oReportView.Report = oarreportec
                            oReportView.Show()

                        Case Else

                            GoTo Imprime_Banamex

                    End Select

                    If bolReimpresion = False Then
                        If MessageBox.Show("¿Desea reimpirmir los vouchers?", "Dportenis Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            bolReimpresion = True
                            GoTo Reimprimir
                        End If
                    End If

                    Me.UiButton2.Focus()
                    Me.UiButton2.PerformClick()

                ElseIf mRespcode.Trim = "06" Then

                    MessageBox.Show("El tiempo de espera para deslizar / insertar la tarjeta ha terminado." & vbCrLf & _
                                    "Por favor, Intente de nuevo.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                ElseIf mRespcode.Trim = "95" Then

                    'Transaccion Cancelada
                    Me.btnLeerTarjeta.Focus()

                Else
                    'Transaccion Rechazada

                    If Trim(mRespcode) <> "00" Then

                        Dim Motivo As String = ""

                        Motivo = Mensaje46

                        Select Case mRespcode.Trim
                            Case "04", "14", "41", "43", "142"
                                oFacturaMgr.SaveTarjetaRechazada(Me.ebNoTarjeta.Text.Trim)
                                Motivo = "La tarjeta ha sido rechazada.".ToUpper
                            Case "45"
                                Motivo = "Promocion Invalida.".ToUpper
                            Case "46"
                                Motivo = "Monto Inferior al mínimo permitido para las promociones."
                            Case "48"
                                Motivo = "CVV2 Requerido".ToUpper
                            Case "49"
                                Motivo = "CVV2 Incorrecto.".ToUpper
                            Case "91", "70"
                                Motivo = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
                        End Select
                        'Select Case mRespcode.Trim
                        '    Case "04", "14", "41", "43", "142"
                        '        Me.strTarjetaBloq &= Me.ebNoTarjeta.Text & "°"
                        '        Motivo = "La tarjeta ha sido rechazada.".ToUpper
                        '    Case "49"
                        '        Motivo = "CVV2 Incorrecto.".ToUpper
                        '    Case "91"
                        '        Motivo = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
                        'End Select

                        If Motivo.Trim <> "" Then Motivo = vbCrLf & vbCrLf & Motivo

                        'MessageBox.Show("Transacción Rechazada." & vbCrLf & Motivo & vbCrLf & _
                        '       mSalida, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        MessageBox.Show("Transacción Rechazada.".ToUpper & Motivo.ToUpper _
                                        , "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    ElseIf Trim(mAutorizacion) = "" AndAlso Trim(mAfiliacion) = "" Then

                        MsgBox("Transacción Rechazada. No se regresaron el número de afiliación ni el número" & _
                               " de autorización." & Microsoft.VisualBasic.vbCrLf & mSalida, _
                               MsgBoxStyle.Exclamation, "DPTienda")

                    ElseIf Trim(mAutorizacion) = "" Then

                        MsgBox("Transacción Rechazada. No se regresó el número de autorización." & _
                               Microsoft.VisualBasic.vbCrLf & mSalida, _
                               MsgBoxStyle.Exclamation, "DPTienda")

                    ElseIf Trim(mAfiliacion) = "" Then

                        MsgBox("Transacción Rechazada. No se regresó el número de afiliación." & _
                               Microsoft.VisualBasic.vbCrLf & mSalida, _
                               MsgBoxStyle.Exclamation, "DPTienda")

                    End If

                    Me.ebNoTarjeta.Text = ""
                    Me.ebCVV2.Text = ""
                    Me.btnLeerTarjeta.Focus()

                End If

            End If

        End If

    End Sub

    Public Function GetName(ByVal strTrack As String, ByVal strSeparadorIni As String, ByVal strSeparadoFin As String)

        Dim strNombre As String
        Dim intIndexIni, intIndexFin As Integer

        intIndexIni = strTrack.IndexOf(strSeparadorIni)
        If intIndexIni > 0 Then
            intIndexFin = strTrack.LastIndexOf(strSeparadoFin)
            strNombre = strTrack.Substring(intIndexIni, intIndexFin - intIndexIni)
        End If
        If InStr(strTrack, "¨") > 0 Then
            strNombre = strNombre.Replace("¨", "").Trim
        Else
            strNombre = strNombre.Replace("^", "").Trim
        End If
        Return strNombre

    End Function

    Private Sub chkTE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTE.CheckedChanged

        ActualizarStatusCamposPE(Me.chkTE.Checked)

    End Sub

    Private Sub btnLeerTarjeta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLeerTarjeta.Click
        Me.btnLeerTarjeta.Enabled = False
        Me.AutorizaCargoTarjeta()
        Me.btnLeerTarjeta.Enabled = True
    End Sub
End Class
