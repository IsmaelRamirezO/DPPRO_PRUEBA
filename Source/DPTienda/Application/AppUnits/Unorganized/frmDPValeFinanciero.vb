Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoEstados
Imports DportenisPro.DPTienda.ApplicationUnits.DPValeFinanciero
Imports System.IO

Public Class DPValeFinanciero
    Inherits System.Windows.Forms.Form
    Dim oFirmaMgr As FirmaManager
    Dim oSAPMgr As ProcesoSAPManager
    Dim oDPVale As cDPVale
    Dim Tarjeta As String
    Dim oCliente As ClienteAlterno
    Dim oClienteMgr As ClientesManager
    Dim oDPVF As DPVFinanciero
    Dim oDPVFMgr As DPValeFinancieroManager
    Dim bolSalir As Boolean = False
    Dim oFacturaMgr As FacturaManager

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
    Friend WithEvents lblNoDPVale As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNoDistribuidor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNoCliente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNombreDist As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtNombreCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cmbMonto As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents pctFirma As System.Windows.Forms.PictureBox
    Friend WithEvents chkFirma As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chkCredencial As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtIntereses As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtNoDPVale As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtNoCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNoTarjeta As System.Windows.Forms.Label
    Friend WithEvents txtNoTarjeta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiStatusBar1 As Janus.Windows.UI.StatusBar.UIStatusBar
    Friend WithEvents txtIFE As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblIFE As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim UiStatusBarPanel1 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DPValeFinanciero))
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblIFE = New System.Windows.Forms.Label()
        Me.txtIFE = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiStatusBar1 = New Janus.Windows.UI.StatusBar.UIStatusBar()
        Me.txtNoTarjeta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNoTarjeta = New System.Windows.Forms.Label()
        Me.txtNoCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtNoDPVale = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtIntereses = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.chkCredencial = New Janus.Windows.EditControls.UICheckBox()
        Me.chkFirma = New Janus.Windows.EditControls.UICheckBox()
        Me.pctFirma = New System.Windows.Forms.PictureBox()
        Me.cmbMonto = New Janus.Windows.EditControls.UIComboBox()
        Me.txtFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombreCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtNombreDist = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNoCliente = New System.Windows.Forms.Label()
        Me.txtNoDistribuidor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNoDPVale = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.pctFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.lblIFE)
        Me.ExplorerBar1.Controls.Add(Me.txtIFE)
        Me.ExplorerBar1.Controls.Add(Me.UiStatusBar1)
        Me.ExplorerBar1.Controls.Add(Me.txtNoTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.lblNoTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.txtNoCliente)
        Me.ExplorerBar1.Controls.Add(Me.txtNoDPVale)
        Me.ExplorerBar1.Controls.Add(Me.txtIntereses)
        Me.ExplorerBar1.Controls.Add(Me.btnImprimir)
        Me.ExplorerBar1.Controls.Add(Me.chkCredencial)
        Me.ExplorerBar1.Controls.Add(Me.chkFirma)
        Me.ExplorerBar1.Controls.Add(Me.pctFirma)
        Me.ExplorerBar1.Controls.Add(Me.cmbMonto)
        Me.ExplorerBar1.Controls.Add(Me.txtFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.txtNombreCliente)
        Me.ExplorerBar1.Controls.Add(Me.txtNombreDist)
        Me.ExplorerBar1.Controls.Add(Me.lblNoCliente)
        Me.ExplorerBar1.Controls.Add(Me.txtNoDistribuidor)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.lblNoDPVale)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(560, 303)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblIFE
        '
        Me.lblIFE.BackColor = System.Drawing.Color.Transparent
        Me.lblIFE.Location = New System.Drawing.Point(24, 160)
        Me.lblIFE.Name = "lblIFE"
        Me.lblIFE.Size = New System.Drawing.Size(72, 16)
        Me.lblIFE.TabIndex = 21
        Me.lblIFE.Text = "Numero IFE:"
        '
        'txtIFE
        '
        Me.txtIFE.AcceptsTab = True
        Me.txtIFE.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtIFE.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtIFE.Location = New System.Drawing.Point(128, 160)
        Me.txtIFE.MaxLength = 13
        Me.txtIFE.Name = "txtIFE"
        Me.txtIFE.Size = New System.Drawing.Size(128, 20)
        Me.txtIFE.TabIndex = 4
        Me.txtIFE.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtIFE.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiStatusBar1
        '
        Me.UiStatusBar1.Location = New System.Drawing.Point(0, 271)
        Me.UiStatusBar1.Name = "UiStatusBar1"
        UiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        UiStatusBarPanel1.BorderColor = System.Drawing.Color.Transparent
        UiStatusBarPanel1.FormatStyle.BackColor = System.Drawing.Color.Transparent
        UiStatusBarPanel1.FormatStyle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        UiStatusBarPanel1.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        UiStatusBarPanel1.FormatStyle.ForeColor = System.Drawing.Color.Red
        UiStatusBarPanel1.Key = ""
        UiStatusBarPanel1.ProgressBarValue = 0
        UiStatusBarPanel1.Text = "    No se aceptan cancelaciones ni devoluciones."
        UiStatusBarPanel1.Width = 269
        Me.UiStatusBar1.Panels.AddRange(New Janus.Windows.UI.StatusBar.UIStatusBarPanel() {UiStatusBarPanel1})
        Me.UiStatusBar1.PanelsBorderColor = System.Drawing.SystemColors.ControlDark
        Me.UiStatusBar1.Size = New System.Drawing.Size(560, 32)
        Me.UiStatusBar1.TabIndex = 19
        Me.UiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtNoTarjeta
        '
        Me.txtNoTarjeta.AcceptsTab = True
        Me.txtNoTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNoTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNoTarjeta.Location = New System.Drawing.Point(128, 136)
        Me.txtNoTarjeta.MaxLength = 0
        Me.txtNoTarjeta.Name = "txtNoTarjeta"
        Me.txtNoTarjeta.Size = New System.Drawing.Size(128, 20)
        Me.txtNoTarjeta.TabIndex = 3
        Me.txtNoTarjeta.Text = "Deslize Tarjeta ..."
        Me.txtNoTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNoTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNoTarjeta
        '
        Me.lblNoTarjeta.BackColor = System.Drawing.Color.Transparent
        Me.lblNoTarjeta.Location = New System.Drawing.Point(24, 136)
        Me.lblNoTarjeta.Name = "lblNoTarjeta"
        Me.lblNoTarjeta.Size = New System.Drawing.Size(72, 16)
        Me.lblNoTarjeta.TabIndex = 9
        Me.lblNoTarjeta.Text = "# Tarjeta:"
        '
        'txtNoCliente
        '
        Me.txtNoCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNoCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNoCliente.ButtonImage = CType(resources.GetObject("txtNoCliente.ButtonImage"), System.Drawing.Image)
        Me.txtNoCliente.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtNoCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCliente.Location = New System.Drawing.Point(128, 88)
        Me.txtNoCliente.MaxLength = 10
        Me.txtNoCliente.Name = "txtNoCliente"
        Me.txtNoCliente.Size = New System.Drawing.Size(128, 22)
        Me.txtNoCliente.TabIndex = 2
        Me.txtNoCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNoCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtNoDPVale
        '
        Me.txtNoDPVale.AcceptsTab = True
        Me.txtNoDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNoDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNoDPVale.Location = New System.Drawing.Point(128, 16)
        Me.txtNoDPVale.MaxLength = 10
        Me.txtNoDPVale.Name = "txtNoDPVale"
        Me.txtNoDPVale.ReadOnly = True
        Me.txtNoDPVale.Size = New System.Drawing.Size(128, 20)
        Me.txtNoDPVale.TabIndex = 1
        Me.txtNoDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNoDPVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtIntereses
        '
        Me.txtIntereses.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtIntereses.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtIntereses.BackColor = System.Drawing.SystemColors.Info
        Me.txtIntereses.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtIntereses.Location = New System.Drawing.Point(128, 208)
        Me.txtIntereses.Name = "txtIntereses"
        Me.txtIntereses.ReadOnly = True
        Me.txtIntereses.Size = New System.Drawing.Size(128, 20)
        Me.txtIntereses.TabIndex = 14
        Me.txtIntereses.TabStop = False
        Me.txtIntereses.Text = "$0.00"
        Me.txtIntereses.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtIntereses.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(432, 232)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(112, 23)
        Me.btnImprimir.TabIndex = 8
        Me.btnImprimir.Text = "Imprimir Pagaré"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'chkCredencial
        '
        Me.chkCredencial.BackColor = System.Drawing.Color.Transparent
        Me.chkCredencial.Location = New System.Drawing.Point(272, 160)
        Me.chkCredencial.Name = "chkCredencial"
        Me.chkCredencial.Size = New System.Drawing.Size(192, 23)
        Me.chkCredencial.TabIndex = 7
        Me.chkCredencial.Text = "¿Se Presentó Credencial Oficial?"
        Me.chkCredencial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'chkFirma
        '
        Me.chkFirma.BackColor = System.Drawing.Color.Transparent
        Me.chkFirma.Location = New System.Drawing.Point(272, 136)
        Me.chkFirma.Name = "chkFirma"
        Me.chkFirma.Size = New System.Drawing.Size(192, 23)
        Me.chkFirma.TabIndex = 6
        Me.chkFirma.Text = "¿La Firma del DPVale Coincide?"
        Me.chkFirma.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'pctFirma
        '
        Me.pctFirma.Location = New System.Drawing.Point(272, 16)
        Me.pctFirma.Name = "pctFirma"
        Me.pctFirma.Size = New System.Drawing.Size(280, 96)
        Me.pctFirma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctFirma.TabIndex = 16
        Me.pctFirma.TabStop = False
        '
        'cmbMonto
        '
        Me.cmbMonto.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "$1000"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "$1500"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "$2000"
        Me.cmbMonto.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3})
        Me.cmbMonto.Location = New System.Drawing.Point(128, 184)
        Me.cmbMonto.Name = "cmbMonto"
        Me.cmbMonto.Size = New System.Drawing.Size(128, 20)
        Me.cmbMonto.TabIndex = 5
        Me.cmbMonto.Text = "Seleccionar Monto"
        Me.cmbMonto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtFecha
        '
        Me.txtFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtFecha.BackColor = System.Drawing.SystemColors.Info
        Me.txtFecha.Location = New System.Drawing.Point(128, 232)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(128, 20)
        Me.txtFecha.TabIndex = 16
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(24, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(24, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Intereses"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(24, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Monto del Prestamo"
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNombreCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNombreCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreCliente.Location = New System.Drawing.Point(24, 112)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(232, 20)
        Me.txtNombreCliente.TabIndex = 8
        Me.txtNombreCliente.TabStop = False
        Me.txtNombreCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNombreCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtNombreDist
        '
        Me.txtNombreDist.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNombreDist.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNombreDist.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreDist.Location = New System.Drawing.Point(24, 64)
        Me.txtNombreDist.Name = "txtNombreDist"
        Me.txtNombreDist.ReadOnly = True
        Me.txtNombreDist.Size = New System.Drawing.Size(232, 20)
        Me.txtNombreDist.TabIndex = 5
        Me.txtNombreDist.TabStop = False
        Me.txtNombreDist.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNombreDist.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNoCliente
        '
        Me.lblNoCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblNoCliente.Location = New System.Drawing.Point(24, 88)
        Me.lblNoCliente.Name = "lblNoCliente"
        Me.lblNoCliente.Size = New System.Drawing.Size(96, 16)
        Me.lblNoCliente.TabIndex = 6
        Me.lblNoCliente.Text = "Cliente del Dist."
        '
        'txtNoDistribuidor
        '
        Me.txtNoDistribuidor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNoDistribuidor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNoDistribuidor.BackColor = System.Drawing.SystemColors.Info
        Me.txtNoDistribuidor.Location = New System.Drawing.Point(128, 40)
        Me.txtNoDistribuidor.Name = "txtNoDistribuidor"
        Me.txtNoDistribuidor.ReadOnly = True
        Me.txtNoDistribuidor.Size = New System.Drawing.Size(128, 20)
        Me.txtNoDistribuidor.TabIndex = 4
        Me.txtNoDistribuidor.TabStop = False
        Me.txtNoDistribuidor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtNoDistribuidor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(24, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Distribuidor"
        '
        'lblNoDPVale
        '
        Me.lblNoDPVale.BackColor = System.Drawing.Color.Transparent
        Me.lblNoDPVale.Location = New System.Drawing.Point(24, 16)
        Me.lblNoDPVale.Name = "lblNoDPVale"
        Me.lblNoDPVale.Size = New System.Drawing.Size(96, 16)
        Me.lblNoDPVale.TabIndex = 0
        Me.lblNoDPVale.Text = "# DPortenis Vale"
        '
        'DPValeFinanciero
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(560, 303)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "DPValeFinanciero"
        Me.Text = "DPVale Financiero"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.pctFirma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Fields"

    Dim m_intNoDPVale As Integer
    Dim m_intNoDist As Integer
    Dim m_strNombreDist As String
    Dim m_intNoCliente As Integer
    Dim m_strNombreCliente As String
    Dim m_dblMonto As Double
    Dim m_dblIntereses As Double
    Dim m_dtFecha As Date
    Dim m_bolFirma As Boolean
    Dim m_bolCredencial As Boolean

    Public Property NoDPVale() As Integer
        Get
            Return m_intNoDPVale
        End Get
        Set(ByVal Value As Integer)
            m_intNoDPVale = Value
        End Set
    End Property

    Public Property NoDistribuidor() As Integer
        Get
            Return m_intNoDist
        End Get
        Set(ByVal Value As Integer)
            m_intNoDist = Value
        End Set
    End Property

    Public Property NombreDistribuidor() As String
        Get
            Return m_strNombreDist
        End Get
        Set(ByVal Value As String)
            m_strNombreDist = Value
        End Set
    End Property

    Public Property NoCliente() As Integer
        Get
            Return m_intNoCliente
        End Get
        Set(ByVal Value As Integer)
            m_intNoCliente = Value
        End Set
    End Property

    Public Property NombreCliente() As String
        Get
            Return m_strNombreCliente
        End Get
        Set(ByVal Value As String)
            m_strNombreCliente = Value
        End Set
    End Property

    Public Property Monto() As Double
        Get
            Return m_dblMonto
        End Get
        Set(ByVal Value As Double)
            m_dblMonto = Value
        End Set
    End Property

    Public Property Intereses() As Double
        Get
            Return m_dblIntereses
        End Get
        Set(ByVal Value As Double)
            m_dblIntereses = Value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return m_dtFecha
        End Get
        Set(ByVal Value As Date)
            m_dtFecha = Value
        End Set
    End Property

    Public Property FirmaCoincide() As Boolean
        Get
            Return m_bolFirma
        End Get
        Set(ByVal Value As Boolean)
            m_bolFirma = Value
        End Set
    End Property

    Public Property Credencial() As Boolean
        Get
            Return m_bolCredencial
        End Get
        Set(ByVal Value As Boolean)
            m_bolCredencial = Value
        End Set
    End Property

#End Region

#Region "Control Events"

    Private Sub DPValeFinanciero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtFecha.Text = Date.Today
        Tarjeta = String.Empty
        oClienteMgr = New ClientesManager(oAppContext, oAppSAPConfig)
        oDPVFMgr = New DPValeFinancieroManager(oAppContext, oConfigCierreFI)
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        'Me.cmbMonto.Items.Add("$1")
        'Me.cmbMonto.Items.Add("$100")

    End Sub

    Private Sub cmbMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMonto.KeyPress, chkCredencial.KeyPress, chkFirma.KeyPress, txtIFE.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtNoDPVale_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoDPVale.LostFocus
        Me.txtNoDPVale.Text = Me.txtNoDPVale.Text.PadLeft(10, "0")
    End Sub

    Private Sub cmbMonto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonto.SelectedIndexChanged

        Dim Intereses As Double

        If Mid(Trim(Me.cmbMonto.Text), 1, 1) = "$" Then

            oDPVale = New cDPVale
            oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

            Intereses = CDbl(Me.cmbMonto.Text) * 0.6
            Try
                If Me.txtNoDPVale.Text <> String.Empty Then
                    oDPVale.INUMVA = Trim(Me.txtNoDPVale.Text.PadLeft(10, "0"))
                    oDPVale.I_RUTA = "X"
                    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                    If oDPVale.EEXIST = "S" Then
                        If oDPVale.ESTATU = "A" Then
                            If oDPVale.LimiteCreditoPrestamo < CDbl(Me.cmbMonto.Text) + Intereses Then
                                MsgBox("El límite de crédito del asociado es menor al monto del prestamo deseado", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                                oDPVale = Nothing
                                oSAPMgr = Nothing
                                Me.cmbMonto.Text = "Seleccionar Monto"
                                Exit Sub
                            End If
                        End If
                    Else
                        oDPVale = Nothing
                        oSAPMgr = Nothing
                        'Exit Sub
                    End If
                End If
            Catch ex As Exception
                oDPVale = Nothing
                oSAPMgr = Nothing
                'Exit Sub
            End Try

            Me.txtIntereses.Value = Intereses
        End If

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Try
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim dtVal As New DataTable

            If ValidaCampos() = True Then

                dtVal = oSAPMgr.ZBAPI_PRESTAMO_FINANCIERO(Trim(Me.txtNoCliente.Text), CDbl(Me.cmbMonto.Text), _
                                                          CDbl(Me.txtIntereses.Text), oAppSAPConfig.Plaza, _
                                                          Trim(Me.txtNoDPVale.Text), "8", Trim(Me.txtNoTarjeta.Text), _
                                                          Trim(Me.txtIFE.Text))

                Select Case dtVal.Rows(0).Item("Result")

                    Case "Y"
                        'Imprimes el ticket.
                        Dim bolReimprimir As Boolean = False
Reimprimir:
                        Dim oARReport As New rptDPValeFinanciero(Me.txtNoCliente.Text, Me.txtNoDistribuidor.Text, _
                                             Me.txtNoDPVale.Text, Me.txtNombreCliente.Text, Me.txtNombreDist.Text, _
                                             CStr((CDbl(Me.cmbMonto.Text) + CDbl(Me.txtIntereses.Text)) / 8), _
                                             oAppSAPConfig.Plaza, "8", dtVal.Rows(0).Item("numfact"), _
                                             dtVal.Rows(0).Item("numdoccontprestamo"), Trim(Me.txtIFE.Text))
                        Dim oARReportCopy As New rptDPValeFinancieroCopia(Me.txtNoCliente.Text, Me.txtNoDistribuidor.Text, _
                                             dtVal.Rows(0).Item("NumDocContPrestamo"), Me.txtNoDPVale.Text, dtVal.Rows(0).Item("numfact"), _
                                             Me.txtNombreCliente.Text, Me.txtNombreDist.Text, CStr((CDbl(Me.cmbMonto.Text) + CDbl(Me.txtIntereses.Text)) / 8), _
                                             oAppSAPConfig.Plaza, "8", Trim(Me.txtIFE.Text))

                        'Dim oARReport As New rptDPValeFinanciero(Me.txtNoCliente.Text, Me.txtNoDistribuidor.Text, _
                        '                     Me.txtNoDPVale.Text, Me.txtNombreCliente.Text, Me.txtNombreDist.Text, _
                        '                     CStr((CDbl(Me.cmbMonto.Text) + CDbl(Me.txtIntereses.Text)) / 8), _
                        '                     oAppSAPConfig.Plaza, "8", "1301000732", _
                        '                     "3000000727", Trim(Me.txtIFE.Text))
                        'Dim oARReportCopy As New rptDPValeFinancieroCopia(Me.txtNoCliente.Text, Me.txtNoDistribuidor.Text, _
                        '                     "3000000727", Me.txtNoDPVale.Text, "1301000732", _
                        '                     Me.txtNombreCliente.Text, Me.txtNombreDist.Text, CStr((CDbl(Me.cmbMonto.Text) + CDbl(Me.txtIntereses.Text)) / 8), _
                        '                     oAppSAPConfig.Plaza, "8", Trim(Me.txtIFE.Text))

                        oARReport.Document.Name = "Pagare DPVale Financiero"
                        oARReport.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        oARReport.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                        'oARReport.PageSettings.PaperKind = Printing.PaperKind.Custom
                        'oARReport.PrintWidth = 2.55F
                        oARReport.PageSettings.Margins.Left = 0.3F
                        'oARReport.PageSettings.PaperHeight = 15.0F
                        oARReport.Run()
                        oARReport.Document.Print(False, False)

                        oARReportCopy.Document.Name = "Pagare DPVale Financiero Copia"
                        oARReportCopy.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        oARReportCopy.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                        oARReportCopy.PageSettings.Margins.Left = 0.3F
                        oARReportCopy.Run()
                        oARReportCopy.Document.Print(False, False)

                        If bolReimprimir = False Then
                            'Generamos Archivos
                            GenerarArchivos(oConfigCierreFI.Ruta & "\ArchivosDPVF", True, , , dtVal.Rows(0).Item("numfact"))
                            GenerarArchivos(oConfigCierreFI.Ruta & "\bkArchivosDPVF", False)
                            If MessageBox.Show("¿Deseas reimprimir el pagaré?", "Dportenis Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                bolReimprimir = True
                                GoTo Reimprimir
                            End If
                        End If

                        MsgBox("El movimiento se ha realizado con éxito", MsgBoxStyle.Information, "DPVale Financiero")
                        ClearFields()
                        Me.txtNoDPVale.Focus()

                        Me.oDPVale = Nothing

                    Case "D"
                            MsgBox(dtVal.Rows(0).Item("mensaje"), MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                            'oDPVale = Nothing
                            oSAPMgr = Nothing
                            'Completar Mensaje con T_Return.

                    Case "C"
                            MsgBox(dtVal.Rows(0).Item("mensaje"), MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                            'oDPVale = Nothing
                            oSAPMgr = Nothing
                            'Completar Mensaje con T_Return.

                    Case "B" 'ok
                            MsgBox("El vale capturado ya ha sido utilizado", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                            'oDPVale = Nothing
                            oSAPMgr = Nothing
                    Case "A" 'ok
                            MsgBox("El vale capturado no existe", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                            'oDPVale = Nothing
                            oSAPMgr = Nothing

                End Select

            End If

        Catch ex As Exception
            Throw ex
            'oDPVale = Nothing
            'oSAPMgr = Nothing

        End Try

    End Sub

    Private Sub txtNoCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoCliente.ButtonClick

        LoadSearchForm()

    End Sub

    Private Sub txtNoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoCliente.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchForm()

        End If

    End Sub

    Private Sub txtNoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoCliente.LostFocus

        Me.txtNoCliente.Text = Me.txtNoCliente.Text.PadLeft(10, "0")

    End Sub

    Private Sub txtNoTarjeta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoTarjeta.KeyDown

        Try

            If e.KeyCode = Keys.Enter Then

                Dim strTrack() As String = Me.txtNoTarjeta.Text.Split(";")
                Dim strNoTarjeta() As String = strTrack(1).Split("=")
                Me.txtNoTarjeta.Text = strNoTarjeta(0)
                SendKeys.Send("{TAB}")
                'Else

                '    Me.txtNoTarjeta.Text = ""
                '    Me.txtNoTarjeta.Text = "Pasar Tarjeta"

            End If

        Catch ex As Exception

            'Me.txtNoTarjeta.Text = "Deslize Tarjeta ..."
            If Me.txtNoTarjeta.Text <> "" Then
                SendKeys.Send("{TAB}")
            Else
                Me.txtNoTarjeta.Focus()
            End If

        End Try

    End Sub

    Private Sub txtNoTarjeta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoTarjeta.GotFocus

        If Me.txtNoTarjeta.Text = "Deslize Tarjeta ..." Then

            Me.txtNoTarjeta.Text = String.Empty

        End If

    End Sub

    Private Sub txtNoTarjeta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoTarjeta.LostFocus

        If Me.txtNoTarjeta.Text = String.Empty Then

            Me.txtNoTarjeta.Text = "Deslize Tarjeta ..."

        End If

    End Sub

#End Region

#Region "Methods"

    Private Sub GetCliente(ByVal strCodCliente As String, ByVal TipoCliente As String)

        Dim dtClientesSap As DataTable
        Dim oClienteSAP As New ClientesSAP

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        dtClientesSap = oSAPMgr.ZBAPI_GET_CLIENTE(strCodCliente, TipoCliente)

        If dtClientesSap.Rows.Count > 0 Then

            'Me.pbProceso.Value = 0

            'Me.pbProceso.Maximum = dtClientesSAP.Rows.Count

            Dim oRow As DataRow
            Dim intCount As Integer = 0
            Dim strApepApemNom() As String
            Dim strNombre As String
            Dim strApellidos As String

            For Each oRow In dtClientesSap.Rows

                'Me.pbProceso.Value += 1
                'Separamos el Nombre de los Apellidos 
                '
                strApepApemNom = Split(oRow!NAME1, "_")
                Select Case strApepApemNom.Length
                    Case 6
                        strNombre = Trim(strApepApemNom(4)) & " " & strApepApemNom(5)
                        strApellidos = strApepApemNom(0) & " " & strApepApemNom(1) & "_" & strApepApemNom(2) & " " & strApepApemNom(3)
                    Case 5
                        strNombre = Trim(strApepApemNom(3)) & " " & strApepApemNom(4)
                        strApellidos = strApepApemNom(0) & " " & strApepApemNom(1) & "_" & strApepApemNom(2)
                    Case 4
                        strNombre = Trim(strApepApemNom(2)) & " " & strApepApemNom(3)
                        strApellidos = strApepApemNom(0) & "_" & strApepApemNom(1)
                    Case 3
                        strNombre = Trim(strApepApemNom(2))
                        strApellidos = strApepApemNom(0) & "_" & strApepApemNom(1)
                    Case 2
                        strNombre = strApepApemNom(1)
                        strApellidos = Trim(strApepApemNom(0))
                    Case 1
                        strNombre = ""
                        strApellidos = Trim(strApepApemNom(0))
                    Case Else
                        strNombre = ""
                        strApellidos = ""
                End Select
                '''Insertamos los valor del cliente a la Clase
                With oClienteSAP
                    .Clienteid = oRow!KUNNR
                    .Nombre = strNombre
                    .Apellidos = strApellidos
                    .Sexo = oRow!DEAR1
                    .Estadocivil = oRow!DATLT
                    .Domicilio = oRow!STRAS
                    .Estado = oRow!REGIO
                    .Ciudad = oRow!ORT01
                    .Colonia = oRow!ORT02
                    .Cp = oRow!PSTLZ
                    .Telefono = oRow!TELF1

                    If oRow!UPDAT = "00000000" Then
                        .Fechanac = Now.Date.ToShortDateString
                    Else
                        .Fechanac = Mid(oRow!UPDAT, 7, 2) & "/" & Mid(oRow!UPDAT, 5, 2) & "/" & Mid(oRow!UPDAT, 1, 4)
                    End If


                    .Email = oRow!KNURL
                    .Codalmacen = oRow!VWERK
                    .CodPlaza = oRow!VKBUR
                    .Usuario = oRow!TELBX

                    If oRow!ERDAT = "00000000" Then
                        .Fecha = Now.Date.ToShortDateString
                    Else
                        .Fecha = Mid(oRow!ERDAT, 7, 2) & "/" & Mid(oRow!ERDAT, 5, 2) & "/" & Mid(oRow!ERDAT, 1, 4)
                    End If


                    .Statusregistro = True
                    .RFC = oRow!STCD1
                    .ClaveAnterior = oRow!ALTKN
                    .TipoVenta = getTipoventa(oRow!BZIRK)
                    .Player = oRow!VKGRP
                End With
                oSAPMgr.Write_Clientes(oClienteSAP)
                'Me.pbProceso.Refresh()
            Next

        End If

    End Sub

    Private Function getTipoventa(ByVal strtipovta As String) As String
        Select Case strtipovta
            Case "TFON" : Return "K"
            Case "FONA" : Return "F"
            Case "FACI" : Return "O"
            Case Else : Return strtipovta
        End Select
    End Function

    Private Sub LoadFirma()
        Dim oByteFirma As Byte()

        oFirmaMgr = New FirmaManager(oAppContext, oConfigCierreFI)
        oByteFirma = Me.oFirmaMgr.GetImagenFirmaAsociado(Trim(Me.txtNoDistribuidor.Text))

        If Not oByteFirma Is Nothing And Not IsDBNull(oByteFirma) Then

            Dim oFirmaAsociado() As Byte = CType(oByteFirma, Byte())
            Dim msFotoAsociado As New MemoryStream(oFirmaAsociado)

            If Not pctFirma.Image Is Nothing Then
                Me.pctFirma.Image.Dispose()
            End If

            Me.pctFirma.Image = Image.FromStream(msFotoAsociado)
        Else
            Me.pctFirma.Image = Nothing
        End If

    End Sub

    Public Sub ClearFields()

        Me.txtNoDistribuidor.Text = String.Empty
        Me.txtNombreDist.Text = String.Empty
        Me.txtNoCliente.Text = String.Empty
        Me.txtNombreCliente.Text = String.Empty
        Me.cmbMonto.Text = "Seleccionar Monto"
        Me.txtIntereses.Value = 0
        Me.pctFirma.Image = Nothing
        Me.chkCredencial.Checked = False
        Me.chkFirma.Checked = False
        Me.txtNoTarjeta.Text = "Deslize Tarjeta ..."
        Me.txtIFE.Text = String.Empty
        oCliente = Nothing
        'oClienteMgr = Nothing
        oClienteMgr = New ClientesManager(oAppContext, oAppSAPConfig)
        oSAPMgr = Nothing
        oDPVale = Nothing
        oDPVF = Nothing
        'oDPVFMgr = Nothing
        oDPVFMgr = New DPValeFinancieroManager(oAppContext, oConfigCierreFI)

    End Sub

    Private Function ValidaCampos() As Boolean

        'MessageBox.Show("No olvides anotar el folio de la credencial de elector", "Credencial de Elector", MessageBoxButtons.OK, MessageBoxIcon.Information)

        oCliente = oClienteMgr.CreateAlterno()
        oClienteMgr.Load(Trim(Me.txtNoCliente.Text), oCliente)

        ValidaCampos = True

        If Me.txtNoDPVale.Text = String.Empty Then
            MsgBox("Es necesario capturar el Número Dportenis Vale", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            Me.txtNoDPVale.Focus()
            ValidaCampos = False
            Exit Function
        End If

        If Me.txtNoDistribuidor.Text = String.Empty Then
            MsgBox("Es necesario especificar un Número Dportenis Vale válido", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            Me.txtNoDPVale.Focus()
            ValidaCampos = False
            Exit Function
        End If

        If Me.txtNoCliente.Text = String.Empty Then
            MsgBox("Es necesario especificar el número del cliente", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            Me.txtNoCliente.Focus()
            ValidaCampos = False
            Exit Function
        End If

        If Me.txtNombreCliente.Text = String.Empty Then
            MsgBox("Es necesario especificar un número de cliente válido", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            Me.txtNoCliente.Focus()
            ValidaCampos = False
            Exit Function
        End If

        If Mid(Trim(Me.cmbMonto.Text), 1, 1) <> "$" Then
            MsgBox("Es necesario especificar el monto del prestamo", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            Me.cmbMonto.Focus()
            ValidaCampos = False
            Exit Function
        End If

        If Me.txtIFE.Text = String.Empty Then
            MsgBox("Es necesario capturar el número del IFE", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            Me.txtIFE.Focus()
            ValidaCampos = False
            Exit Function
        End If

        If Me.txtNoTarjeta.Text = String.Empty Or Me.txtNoTarjeta.Text = "Deslize Tarjeta ..." Then
            MsgBox("Es necesario deslizar la tarjeta DPago", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            Me.txtNoTarjeta.Focus()
            ValidaCampos = False
            Exit Function
        End If

        If Trim(Tarjeta) <> String.Empty Then

            Tarjeta = Tarjeta.Trim
            If Trim(Me.txtNoTarjeta.Text) <> Trim(Tarjeta) Then

                If MsgBox("El Número de Tarjeta no coincide, ¿Desea registrar esta nueva tarjeta?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Dportenis Vale Financiero") = MsgBoxResult.Yes Then
                    Tarjeta = String.Empty
                Else
                    MsgBox("Es necesario que la tarjeta coincida o registrar una nueva", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                    Me.txtNoTarjeta.Focus()
                    ValidaCampos = False
                    Exit Function
                End If

            End If

        End If

        If oSAPMgr.ZBAPI_VALIDATARJETA(Me.txtNoTarjeta.Text) = False Then

            MsgBox("La tarjeta deslizada no es válida.", MsgBoxStyle.Exclamation, "DPVale Financiero")
            Me.txtNoTarjeta.Focus()
            ValidaCampos = False
            Exit Function

        End If

        If Me.chkFirma.Checked = False Then
            MsgBox("Es necesario que la firma del DPVale coincida", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            ValidaCampos = False
            Exit Function
        End If

        If Me.chkCredencial.Checked = False Then
            MsgBox("Es necesario presentar la credencial oficial", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            ValidaCampos = False
            Exit Function
        End If

        '''Validamos que pueda generar prestamos.
        Dim strSec As String
        Dim SecFile As String
        strSec = ""
        If strSec = "" Then
            SecFile = CStr(oDPVFMgr.GetLastSec(1) + 1).PadLeft(4, "0")
        Else
            SecFile = strSec
        End If

        If Val(SecFile) > 99 Then
            MsgBox("Ha llegado al máximo de prestamos diario", MsgBoxStyle.Exclamation, "Dportenis Vale financiero")
            ValidaCampos = False
            Exit Function
        End If

        strSec = ""
        If strSec = "" Then
            SecFile = CStr(oDPVFMgr.GetLastSec(2) + 1).PadLeft(4, "0")
        Else
            SecFile = strSec
        End If

        '''Validamos que pueda registrar tarjetas.
        If Tarjeta <> String.Empty AndAlso Val(SecFile) > 9999 Then
            MsgBox("Ha llegado al límite de registros de tarjetas diarias", MsgBoxStyle.Exclamation, "Dportenis Vale financiero")
            ValidaCampos = False
            Exit Function
        End If

        '''Validamos que pueda entrar a la unidad de Red.

        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, _
                                                              oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)



        If oMontarURed.Conecta() Then
            oMontarURed.Desconecta()
            'oMontarURed.Desconecta()
        Else
            MsgBox("Es necesario configurar correctamente las rutas de archivos", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            ValidaCampos = False
            oMontarURed = Nothing
            Exit Function
        End If
        ''''If oCliente.FechaNacimiento.Copa > 0 Then
        '''If (Year(Date.Today) - Year(oCliente.FechaNacimiento) < 10) Then
        '''    MsgBox("La fecha de nacimiento del cliente debe ser de por lo menos hace 10 años", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
        '''    Me.txtNoCliente.Focus()
        '''    ValidaCampos = False
        '''    oCliente = Nothing
        '''End If
        ''''Else
        ''''MsgBox("La fecha de nacimiento del cliente debe ser valida", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
        ''''Me.txtNoCliente.Focus()
        ''''ValidaCampos = False
        ''''oCliente = Nothing
        ''''End If

    End Function

    Private Sub Clear()

        m_intNoDPVale = 0
        m_intNoDist = 0
        m_strNombreDist = String.Empty
        m_intNoCliente = 0
        m_strNombreCliente = String.Empty
        m_dblMonto = 0
        m_dblIntereses = 0
        m_dtFecha = Date.Today
        m_bolFirma = False
        m_bolCredencial = False

    End Sub

    Private Sub LoadSearchForm()

        Dim oOpenRecordDlg As OpenFROMSAPRecordDialogClientes

        oOpenRecordDlg = New OpenFROMSAPRecordDialogClientes
        oOpenRecordDlg.TipoVenta = "V"
        oOpenRecordDlg.CurrentView = New ClientesFromSAPOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If


        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Try
                'Dim intClienteID As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    Me.txtNoCliente.Text = oOpenRecordDlg.Record.Item("KUNNR")
                    Me.txtNombreCliente.Text = oOpenRecordDlg.Record.Item("NAME1")

                Else

                    Me.txtNoCliente.Text = CType(oOpenRecordDlg.pbCodigo, String)
                    Me.txtNombreCliente.Text = CType(oOpenRecordDlg.pbNombre, String)

                End If

                'SendKeys.Send("{TAB}")

            Catch ex As Exception

                Throw New ApplicationException("[LoadSearchForm]", ex)

            End Try

        End If

    End Sub

    Public Sub GenerarArchivos(ByVal Ruta As String, ByVal bolGuardar As Boolean, Optional ByVal Tipo As Integer = 0, _
                               Optional ByVal strSec As String = "", Optional ByVal NumFact As String = "")

        Dim StreamW As StreamWriter

        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, _
                                                                    oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)
        Try

            If oMontarURed.Conecta() Then
                'oMontarURed.Desconecta()
            Else
                MsgBox("Es necesario configurar correctamente las rutas de archivos", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                oMontarURed = Nothing
                Exit Sub
            End If

            Dim FilePath As String
            Dim NoIDCliente As String, FechaPago As String
            Dim SecFile As String, NameEmpresa As String
            Dim DescFile As String, ImporteCargo As String
            Dim NoCuenta As String, NoTotalAbonos As String
            Dim MetodoPago As String, TipoPago As String
            Dim ImporteAbono As String, TipoCuentaAbono As String
            Dim NoCuentaAbono As String, RefPago As String
            Dim Beneficiario As String, Ref1 As String
            Dim Ref2 As String, Ref3 As String, Ref4 As String
            Dim ClvBanco As String, Plazo As String, RFC As String, IVA As String
            Dim ContArchivos() As String, Importe As String, Path As String, Import() As String

            'If oCliente Is Nothing Then
            '    oCliente = oClienteMgr.CreateAlterno()
            '    oClienteMgr.Load(Trim(Me.txtNoCliente.Text), oCliente)
            'End If
            'If oCliente.CodigoCliente = 0 Then
                
            GetCliente(Me.txtNoCliente.Text.Trim, "VL")
            oClienteMgr.Load(Trim(Me.txtNoCliente.Text), oCliente)

            'End If

            '------------Generamos el archivo de Layout D---------------------------------------------------------

            FechaPago = Mid(Me.txtFecha.Text, 9, 2) & Mid(Me.txtFecha.Text, 4, 2) & Mid(Me.txtFecha.Text, 1, 2)
            'Path = "C:\Pruebas\LayoutD\" & FechaPago & "\"
            Path = Format(Date.Today, "yyMMdd") 'Mid(Date.Today.ToString, 9, 2) & Mid(Date.Today.ToString, 4, 2) & Mid(Date.Today.ToString, 1, 2)
            Path = Ruta & "\LayoutD\" & Path & "\"
            FilePath = Path & Me.txtNoTarjeta.Text & ".txt"

            If Not Directory.Exists(Path) = True Then
                MkDir(Path)
            End If

            If File.Exists(FilePath) = True AndAlso Tipo <> 2 Then
                Kill(FilePath)
            End If

            'ContArchivos = System.IO.Directory.GetFiles(Mid(FilePath, 1, FilePath.Length - (Me.txtNoTarjeta.Text.Length + 4)))
            'SecFile = CStr(ContArchivos.Length + 1).PadLeft(4, "0")
            If strSec = "" Then
                SecFile = CStr(oDPVFMgr.GetLastSec(1) + 1).PadLeft(4, "0")
            Else
                SecFile = strSec
            End If

            If Val(SecFile) > 99 Then
                MsgBox("Ha llegado al máximo de prestamos diario", MsgBoxStyle.Exclamation, "Dportenis Vale financiero")
                Exit Sub
            End If


            '--------------------------------Registro Tipo 1------------------------------------------------------
            NoIDCliente = "21795638".PadLeft(12, "0")
            NameEmpresa = "Comercial Dportenis".PadRight(36, " ")
            DescFile = "DPVale Financiero".PadRight(20, " ")

            '--------------------------------Registro Tipo 2------------------------------------------------------
            Importe = CStr(CDbl(Me.cmbMonto.Text))
            Import = Importe.Split(".")
            If Import.Length > 1 Then
                If Import(1).Length < 2 Then
                    Import(1) = Import(1).PadRight(2, "0")
                End If
                ImporteCargo = Import(0) & Import(1)
            Else
                ImporteCargo = Importe.PadRight(Importe.Length + 2, "0")
            End If
            ImporteCargo = ImporteCargo.PadLeft(18, "0")
            NoCuenta = "1147635563".PadLeft(20, "0")
            NoTotalAbonos = "1".PadLeft(6, "0")

            '--------------------------------Registro Tipo 3------------------------------------------------------
            MetodoPago = "001"
            TipoPago = "58"
            ImporteAbono = ImporteCargo
            TipoCuentaAbono = "03"
            NoCuentaAbono = Trim(Me.txtNoTarjeta.Text).PadLeft(20, "0")
            RefPago = "Pago Banamex".PadRight(16, " ")

            'ContArchivos.Clear(ContArchivos, 0, ContArchivos.Length)
            If oCliente.ApellidoMaterno.Trim = "" OrElse oCliente.ApellidoPaterno.Trim = "" Then
                Dim NombreCompleto() As String

                oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                NombreCompleto = oSAPMgr.ZBAPI_NOMBRE_CLIENTE(Me.txtNoCliente.Text.Trim).Trim.Split("_")
                If NombreCompleto.Length < 3 Then
                    Beneficiario = NombreCompleto(1) & "," & NombreCompleto(0) & "/ "
                Else
                    Beneficiario = NombreCompleto(2) & "," & NombreCompleto(0) & "/" & NombreCompleto(1)
                End If
            Else
                Beneficiario = oCliente.Nombre & "," & oCliente.ApellidoPaterno & "/" & oCliente.ApellidoMaterno
            End If
            Beneficiario = Beneficiario.PadRight(55, " ").Replace("Ñ", "N")
            If Beneficiario.Length > 55 Then
                Beneficiario = Beneficiario.Substring(1, 55)
            End If
            Ref1 = "Referencia 1".PadRight(35, " ")
            Ref2 = "Referencia 2".PadRight(35, " ")
            Ref3 = "Referencia 3".PadRight(35, " ")
            Ref4 = "Referencia 4".PadRight(35, " ")
            ClvBanco = "0000"
            Plazo = "00"
            RFC = "".PadLeft(14, " ")
            IVA = "".PadLeft(8, " ")

            If Tipo = 2 Then
                GoTo Tipo2
            End If

            StreamW = New StreamWriter(FilePath)

            StreamW.WriteLine("1" & NoIDCliente & FechaPago & SecFile & NameEmpresa & DescFile & "15D01")
            StreamW.WriteLine("21001" & ImporteCargo & "01" & NoCuenta & NoTotalAbonos)
            StreamW.WriteLine("30" & MetodoPago & TipoPago & "001" & ImporteAbono & TipoCuentaAbono & _
                              NoCuentaAbono & RefPago & Beneficiario & Ref1 & Ref2 & Ref3 & Ref4 & ClvBanco & _
                              Plazo & RFC & IVA & "".PadRight(80, " ") & "".PadRight(50, " "))
            StreamW.WriteLine("4001" & NoTotalAbonos & ImporteCargo & NoTotalAbonos & ImporteCargo)

            StreamW.Close()

            If bolGuardar = True Then

                GuardarDatosArchivo(CInt(Me.txtNoCliente.Text), CInt(SecFile), Me.txtNoTarjeta.Text.Trim, Trim(Me.txtNoDPVale.Text) _
                                    , Date.Today, CDec(Me.cmbMonto.Text), CDec(Me.txtIntereses.Text), 1, NumFact, _
                                    CInt(Me.txtNoDistribuidor.Text))

            End If

            If Tarjeta <> String.Empty Or Tipo = 1 Then
                Exit Sub
            End If

            '-------------Generamos el archivo Layout de Tarjetas--------------------------------------------

Tipo2:
            Dim TotalAltas As String, Filler As String, UnidadTrabajo As String
            Dim FechaNac As String, Calle_Num As String, Colonia As String
            Dim CodPostal As String, Poblacion As String, Estado As String
            Dim NoTarjeta As String, FormaPago As String, AsigPago As String

            'Path = "C:\Pruebas\LayoutTarjetas\" & FechaPago & "\"
            Path = Mid(Date.Today.ToString, 9, 2) & Mid(Date.Today.ToString, 4, 2) & Mid(Date.Today.ToString, 1, 2)
            Path = Ruta & "\LayoutTarjetas\" & Path & "\"
            FilePath = Path & Me.txtNoTarjeta.Text & "Tarjetas.txt"

            If Not Directory.Exists(Path) Then
                MkDir(Path)
            End If

            If File.Exists(FilePath) Then
                Kill(FilePath)
            End If

            ' ContArchivos.Clear(ContArchivos, 0, ContArchivos.Length)
            'ContArchivos = System.IO.Directory.GetFiles(Path)
            'SecFile = CStr(ContArchivos.Length + 1).PadLeft(4, "0")
            If strSec = "" Then
                SecFile = CStr(oDPVFMgr.GetLastSec(2) + 1).PadLeft(4, "0")
            Else
                SecFile = strSec
            End If

            If Val(SecFile) > 9999 Then
                MsgBox("Ha llegado al límite de registros de tarjetas diarias", MsgBoxStyle.Exclamation, "Dportenis Vale financiero")
                Exit Sub
            End If

            '--------------------------------Registro Tipo 1------------------------------------------------------

            TotalAltas = "1".PadLeft(6, "0")
            FechaPago = Mid(Me.txtFecha.Text, 7, 4) & Mid(Me.txtFecha.Text, 4, 2) & Mid(Me.txtFecha.Text, 1, 2)
            Filler = "".PadRight(460, " ")
            UnidadTrabajo = "1".PadLeft(16, "0")

            '--------------------------------Registro Tipo 2------------------------------------------------------

            oCliente.FechaNacimiento = oCliente.FechaNacimiento.AddYears(-20)
            FechaNac = CStr(oCliente.FechaNacimiento).ToString
            FechaNac = Mid(FechaNac, 7, 4) & Mid(FechaNac, 4, 2) & Mid(FechaNac, 1, 2)

            Calle_Num = oCliente.Direccion
            Colonia = oCliente.Colonia
            Calle_Num = ValidaSimbolos(Calle_Num).PadRight(36, " ")
            Colonia = ValidaSimbolos(Colonia).PadRight(24, " ")
            If Calle_Num.Trim = "" Then
                Calle_Num = "Melchor Ocampo 1005".PadRight(36, " ")
            ElseIf Calle_Num.Length > 36 Then
                Calle_Num = Calle_Num.Substring(1, 36)
            End If
            If Colonia.Trim = "" Then
                Colonia = "Centro".PadRight(24, " ")
            ElseIf Colonia.Length > 24 Then
                Colonia = Colonia.Substring(1, 24)
            End If
            Calle_Num = Calle_Num.Replace("Ñ", "N")
            Colonia = Colonia.Replace("Ñ", "N")
            If Colonia.Trim = "Centro" Then
                CodPostal = "082000"
            Else
                CodPostal = oCliente.CP.PadLeft(6, "0")
            End If
            Poblacion = oCliente.Ciudad.PadRight(20, " ")
            If Poblacion.Trim.Length > 20 Then
                Poblacion = Poblacion.Substring(1, 20)
            End If
            Estado = ObtenerCodEstado(oCliente.Estado)
            Estado = CStr(Estado).PadLeft(2, "0")
            NoTarjeta = Trim(Me.txtNoTarjeta.Text)
            FormaPago = "2"
            AsigPago = "0"

            StreamW = New StreamWriter(FilePath)

            StreamW.WriteLine("1" & NoIDCliente & FechaPago & SecFile & TotalAltas & Filler)

            Filler = "".PadRight(297, " ")

            StreamW.WriteLine("211" & UnidadTrabajo & "01" & Beneficiario & FechaNac & Calle_Num & Colonia & _
                              CodPostal & Poblacion & Estado & NoTarjeta & FormaPago & AsigPago & "0001" & Filler)

            StreamW.Close()

            If bolGuardar = True Then

                GuardarDatosArchivo(CInt(Me.txtNoCliente.Text), CInt(SecFile), NoTarjeta, Trim(Me.txtNoDPVale.Text) _
                                    , Date.Today, CDec(Me.cmbMonto.Text), CDec(Me.txtIntereses.Text), 2, NumFact, _
                                    CInt(Me.txtNoDistribuidor.Text))

            End If

        Catch ex As Exception


            StreamW.Close()

            'oCliente = Nothing
            'oClienteMgr = Nothing
            'MsgBox(ex.Message)

            oMontarURed.Desconecta()
            'oMontarURed.Desconecta()

            Throw New ApplicationException("Error al generar el archivo.", ex)

        Finally
            oMontarURed.Desconecta()
            'oMontarURed.Desconecta()
            oSAPMgr = Nothing
        End Try

    End Sub

    Private Function ValidaSimbolos(ByVal strDir As String) As String

        Dim strNoSimbolos As String

        strNoSimbolos = strDir
        strNoSimbolos = strNoSimbolos.Replace(".", "")
        strNoSimbolos = strNoSimbolos.Replace("/", "")
        strNoSimbolos = strNoSimbolos.Replace(",", "")
        strNoSimbolos = strNoSimbolos.Replace("#", "")
        strNoSimbolos = strNoSimbolos.Replace("-", " ")
        strNoSimbolos = strNoSimbolos.Replace("°", " ")

        Return strNoSimbolos

    End Function

    Private Sub GuardarDatosArchivo(ByVal IDCliente As Integer, ByVal SecFile As Integer, ByVal NoCuenta As String, _
                                  ByVal NoDPvale As String, ByVal Fecha As Date, ByVal Importe As Decimal, _
                                  ByVal Intereses As Decimal, ByVal Tipo As Integer, ByVal NumFact As String, _
                                  ByVal IDAsoc As Integer)


        oDPVF = oDPVFMgr.Create()

        oDPVF.IDCliente = IDCliente
        oDPVF.SecuencialFile = SecFile
        oDPVF.NoCuentaAbono = NoCuenta
        oDPVF.NoDPVale = NoDPvale
        oDPVF.Fecha = Fecha
        oDPVF.Importe = Importe
        oDPVF.Intereses = Intereses
        oDPVF.Tipo = Tipo
        oDPVF.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
        oDPVF.NumFactura = NumFact
        oDPVF.Asociado = IDAsoc

        oDPVFMgr.Save(oDPVF)

        oDPVF = Nothing

    End Sub

    Private Function ObtenerCodEstado(ByVal AbrevEstado As String) As Integer

        Select Case AbrevEstado

            Case "AGS"
                ObtenerCodEstado = 2
            Case "BC"
                ObtenerCodEstado = 3
            Case "BCS"
                ObtenerCodEstado = 4
            Case "CHI"
                ObtenerCodEstado = 9
            Case "CHS"
                ObtenerCodEstado = 8
            Case "CMP"
                ObtenerCodEstado = 5
            Case "COA"
                ObtenerCodEstado = 6
            Case "COL"
                ObtenerCodEstado = 7
            Case "DF"
                ObtenerCodEstado = 1
            Case "DGO"
                ObtenerCodEstado = 10
            Case "GRO"
                ObtenerCodEstado = 12
            Case "GTO"
                ObtenerCodEstado = 11
            Case "HGO"
                ObtenerCodEstado = 13
            Case "JAL"
                ObtenerCodEstado = 14
            Case "MCH"
                ObtenerCodEstado = 16
            Case "MEX"
                ObtenerCodEstado = 15
            Case "MOR"
                ObtenerCodEstado = 17
            Case "NAY"
                ObtenerCodEstado = 18
            Case "NL"
                ObtenerCodEstado = 19
            Case "OAX"
                ObtenerCodEstado = 20
            Case "PUE"
                ObtenerCodEstado = 21
            Case "QR"
                ObtenerCodEstado = 23
            Case "QRO"
                ObtenerCodEstado = 22
            Case "SIN"
                ObtenerCodEstado = 25
            Case "SLP"
                ObtenerCodEstado = 24
            Case "SON"
                ObtenerCodEstado = 26
            Case "TAB"
                ObtenerCodEstado = 27
            Case "TLX"
                ObtenerCodEstado = 29
            Case "TMS"
                ObtenerCodEstado = 28
            Case "VER"
                ObtenerCodEstado = 30
            Case "YUC"
                ObtenerCodEstado = 31
            Case "ZAC"
                ObtenerCodEstado = 32

        End Select

    End Function

#End Region

    Dim str As String = ""

    Private Sub DPValeFinanciero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If Me.ActiveControl Is Me.txtNoDPVale And Not e.KeyCode = Keys.Enter And Me.txtNoDPVale.ReadOnly = True Then
            str = str & Chr(e.KeyCode)
            'MsgBox(e.KeyCode)
        ElseIf Me.ActiveControl Is Me.txtNoDPVale And Me.txtNoDPVale.ReadOnly = True Then
            str = str.PadLeft(10, "0")
            If str <> "" And str.Length > 9 Then
                str = Mid(str, str.Length - 9)
                Me.txtNoDPVale.Text = str
                str = ""
            Else
                str = ""
            End If
        End If

    End Sub

    Private Sub txtNoDPVale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoDPVale.KeyDown
        Dim oRow As DataRow

        oDPVale = New cDPVale
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        Try
            If e.KeyCode = Keys.Enter Then
                oDPVale.INUMVA = Trim(Me.txtNoDPVale.Text.PadLeft(10, "0"))
                oDPVale.I_RUTA = "X"
                oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                If oDPVale.EEXIST = "S" Then

                    oRow = oDPVale.InfoDPVALE.Rows(0)

                    If oDPVale.ESTATU = "A" Then

                        Me.txtNoDistribuidor.Text = CStr(oRow.Item("KUNNR")).PadLeft(10, "0")
                        Me.txtNombreDist.Text = oSAPMgr.ZBAPI_NOMBRE_CLIENTE(Me.txtNoDistribuidor.Text)

                        If oDPVale.FlagPrestamo <> "X" Then

                            MsgBox("El Distribuidor " & Trim(Me.txtNoDistribuidor.Text) & " no tiene los privilegios necesarios para realizar prestamos", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                            Me.oDPVale = Nothing
                            Me.oSAPMgr = Nothing
                            ClearFields()
                            Me.txtNoDPVale.Focus()

                        Else

                            'Me.txtNoDistribuidor.Text = CStr(oRow.Item("KUNNR")).PadLeft(10, "0")
                            'Me.txtNoCliente.Text = CStr(oRow.Item("CODCT")).PadLeft(10, "0")

                            'Me.txtNombreDist.Text = oSAPMgr.ZBAPI_NOMBRE_CLIENTE(Me.txtNoDistribuidor.Text)
                            'Me.txtNombreCliente.Text = oSAPMgr.ZBAPI_NOMBRE_CLIENTE(Me.txtNoCliente.Text)

                            LoadFirma()

                            SendKeys.Send("{tab}")

                        End If

                    Else
                        If oRow.Item("STATU") = "C" Then
                            MsgBox("El vale capturado está cancelado", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                        Else
                            MsgBox("El vale capturado ya ha sido utilizado", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                        End If
                        Me.oDPVale = Nothing
                        Me.oSAPMgr = Nothing
                        ClearFields()
                        Me.txtNoDPVale.Focus()
                    End If
                Else
                    MsgBox("El vale capturado no existe", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                    Me.oDPVale = Nothing
                    Me.oSAPMgr = Nothing
                    ClearFields()
                    Me.txtNoDPVale.Focus()
                End If
            End If
        Catch ex As Exception
            Me.oDPVale = Nothing
            Me.oSAPMgr = Nothing
        End Try
    End Sub

    Private Sub txtIFE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIFE.Validating

        If Trim(Me.txtIFE.Text).Length <> 13 Then

            MsgBox("La longitud del número debe ser igual a 13 caracteres", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            Me.txtIFE.Focus()

        End If

    End Sub

    Private Sub txtNoCliente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNoCliente.Validating

        If Me.txtNoCliente.Text <> "" AndAlso CDbl(Me.txtNoCliente.Text) > 0 Then

            ValidaCliente()

        End If

    End Sub

    Private Sub ValidaCliente()

        Dim strMsg As String

        Try

            oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

            'If Trim(CStr(Me.txtNoCliente.Text).PadLeft(10, "0")) = Trim(CStr(Me.txtNoDistribuidor.Text).PadLeft(10, "0")) Then

            '    MsgBox("El distribuidor no puede autoprestarse dinero", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            '    Me.txtNombreCliente.Text = String.Empty
            '    oSAPMgr = Nothing
            '    Me.txtNoCliente.Focus()
            '    'Exit Sub

            'Else

            Me.txtNombreCliente.Text = oSAPMgr.ZBAPI_NOMBRE_CLIENTE(Trim(Me.txtNoCliente.Text))

            If Me.txtNombreCliente.Text = String.Empty Then

                MsgBox("El cliente capturado no existe", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                oSAPMgr = Nothing
                Me.txtNoCliente.Focus()
                'Exit Sub
            Else

                strMsg = oSAPMgr.Valida_Clientes(Me.txtNoCliente.Text)

                Dim strAdeuda As String
                strAdeuda = ""
                Select Case Mid(Trim(strMsg), 1, 4)
                    Case "DPVF"
                        strMsg = Mid(Trim(strMsg), 6)
                        strAdeuda = "X"
                    Case "TARJ"
                        strMsg = Mid(Trim(strMsg), 6)
                        Tarjeta = strMsg
                        strMsg = String.Empty
                End Select

                If strMsg <> String.Empty Then
                    If strAdeuda = "X" Then
                        MsgBox(strMsg, MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                    Else
                        MsgBox(strMsg & vbCrLf & "Comunicate ahora con las oficinas DPVale", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                    End If

                    Me.txtNombreCliente.Text = String.Empty
                    oSAPMgr = Nothing
                    Me.txtNoCliente.Focus()
                    'Exit Sub
                Else

                    If Tarjeta <> String.Empty Then

                        MsgBox("El cliente " & Trim(Me.txtNoCliente.Text) & " ya cuenta con tarjeta DPago, favor de deslizarla", _
                         MsgBoxStyle.Information, "Dportenis Vale Financiero")

                    Else

                        MsgBox("El cliente " & Trim(Me.txtNoCliente.Text) & " no cuenta con tarjeta DPago" & vbCrLf & _
                         "Favor de proporcionarle una y deslizarla", MsgBoxStyle.Information, "Dportenis Vale Financiero")

                    End If

                    SendKeys.Send("{tab}")

                End If

            End If

            ' End If

        Catch ex As Exception

            oSAPMgr = Nothing

        End Try

    End Sub

    Private Sub DPValeFinanciero_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        bolSalir = True
    End Sub
End Class
