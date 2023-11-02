Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.InicioDia
Imports DportenisPro.DPTienda.ApplicationUnits.InicioCaja
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneral

Public Class frmInicioCaja
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents prgpgbar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ebFechaInicioCaja As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebCodCaja As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents npFolios As PureComponents.NicePanel.NicePanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ebFondoCaja As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFolioAbono As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFolioApartado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFolioFactura As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnIniciarCaja As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNotaVenta As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage()
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle()
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle()
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicioCaja))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.npFolios = New PureComponents.NicePanel.NicePanel()
        Me.txtNotaVenta = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ebFondoCaja = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ebFolioAbono = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ebFolioApartado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFolioFactura = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebCodCaja = New Janus.Windows.EditControls.UIComboBox()
        Me.prgpgbar1 = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnIniciarCaja = New Janus.Windows.EditControls.UIButton()
        Me.ebFechaInicioCaja = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.npFolios.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.npFolios)
        Me.ExplorerBar1.Controls.Add(Me.ebCodCaja)
        Me.ExplorerBar1.Controls.Add(Me.prgpgbar1)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.btnIniciarCaja)
        Me.ExplorerBar1.Controls.Add(Me.ebFechaInicioCaja)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(346, 339)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'npFolios
        '
        Me.npFolios.BackColor = System.Drawing.Color.Transparent
        Me.npFolios.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 50
        Me.npFolios.ContainerImage = ContainerImage1
        Me.npFolios.ContextMenuButton = False
        Me.npFolios.Controls.Add(Me.txtNotaVenta)
        Me.npFolios.Controls.Add(Me.Label6)
        Me.npFolios.Controls.Add(Me.ebFondoCaja)
        Me.npFolios.Controls.Add(Me.Label7)
        Me.npFolios.Controls.Add(Me.ebFolioAbono)
        Me.npFolios.Controls.Add(Me.Label5)
        Me.npFolios.Controls.Add(Me.ebFolioApartado)
        Me.npFolios.Controls.Add(Me.ebFolioFactura)
        Me.npFolios.Controls.Add(Me.Label3)
        Me.npFolios.Controls.Add(Me.Label2)
        Me.npFolios.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.npFolios.FooterImage = HeaderImage1
        Me.npFolios.FooterText = "PureComponents NicePanel for .NET WinForms V1.0."
        Me.npFolios.FooterVisible = False
        Me.npFolios.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Block
        HeaderImage2.Image = Nothing
        Me.npFolios.HeaderImage = HeaderImage2
        Me.npFolios.HeaderText = "Folios / Fondo"
        Me.npFolios.IsExpanded = True
        Me.npFolios.Location = New System.Drawing.Point(26, 104)
        Me.npFolios.Name = "npFolios"
        Me.npFolios.OriginalFooterVisible = False
        Me.npFolios.OriginalHeight = 208
        Me.npFolios.Size = New System.Drawing.Size(296, 176)
        ContainerStyle1.BackColor = System.Drawing.Color.Transparent
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(252, Byte), Integer))
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        ContainerStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle1.ForeColor = System.Drawing.Color.Black
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Rounded
        PanelStyle1.ContainerStyle = ContainerStyle1
        PanelHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(127, Byte), Integer))
        PanelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(215, Byte), Integer))
        PanelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle1.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        PanelHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(237, Byte), Integer))
        PanelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small
        PanelStyle1.FooterStyle = PanelHeaderStyle1
        PanelHeaderStyle2.BackColor = System.Drawing.Color.Transparent
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle2.FadeColor = System.Drawing.Color.Transparent
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.Flat
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.npFolios.Style = PanelStyle1
        Me.npFolios.TabIndex = 2
        Me.npFolios.TabStop = False
        '
        'txtNotaVenta
        '
        Me.txtNotaVenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNotaVenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNotaVenta.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtNotaVenta.Location = New System.Drawing.Point(184, 72)
        Me.txtNotaVenta.Name = "txtNotaVenta"
        Me.txtNotaVenta.Size = New System.Drawing.Size(88, 22)
        Me.txtNotaVenta.TabIndex = 2
        Me.txtNotaVenta.Text = "0"
        Me.txtNotaVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtNotaVenta.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(40, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 23)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Folio Nota Venta:"
        '
        'ebFondoCaja
        '
        Me.ebFondoCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFondoCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFondoCaja.DecimalDigits = 2
        Me.ebFondoCaja.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebFondoCaja.Location = New System.Drawing.Point(183, 136)
        Me.ebFondoCaja.MaxLength = 6
        Me.ebFondoCaja.Name = "ebFondoCaja"
        Me.ebFondoCaja.Size = New System.Drawing.Size(89, 22)
        Me.ebFondoCaja.TabIndex = 4
        Me.ebFondoCaja.Text = "$0.00"
        Me.ebFondoCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFondoCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(40, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 24)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Fondo:"
        '
        'ebFolioAbono
        '
        Me.ebFolioAbono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioAbono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioAbono.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFolioAbono.Location = New System.Drawing.Point(183, 104)
        Me.ebFolioAbono.MaxLength = 6
        Me.ebFolioAbono.Name = "ebFolioAbono"
        Me.ebFolioAbono.ReadOnly = True
        Me.ebFolioAbono.Size = New System.Drawing.Size(89, 22)
        Me.ebFolioAbono.TabIndex = 3
        Me.ebFolioAbono.Text = "0"
        Me.ebFolioAbono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioAbono.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.ebFolioAbono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(40, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 23)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Folio Abono:"
        '
        'ebFolioApartado
        '
        Me.ebFolioApartado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioApartado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioApartado.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFolioApartado.Location = New System.Drawing.Point(183, 40)
        Me.ebFolioApartado.MaxLength = 6
        Me.ebFolioApartado.Name = "ebFolioApartado"
        Me.ebFolioApartado.ReadOnly = True
        Me.ebFolioApartado.Size = New System.Drawing.Size(89, 22)
        Me.ebFolioApartado.TabIndex = 1
        Me.ebFolioApartado.Text = "0"
        Me.ebFolioApartado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioApartado.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.ebFolioApartado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolioFactura
        '
        Me.ebFolioFactura.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioFactura.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioFactura.Enabled = False
        Me.ebFolioFactura.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFolioFactura.Location = New System.Drawing.Point(183, 184)
        Me.ebFolioFactura.MaxLength = 6
        Me.ebFolioFactura.Name = "ebFolioFactura"
        Me.ebFolioFactura.Size = New System.Drawing.Size(89, 22)
        Me.ebFolioFactura.TabIndex = 0
        Me.ebFolioFactura.Text = "0"
        Me.ebFolioFactura.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioFactura.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.ebFolioFactura.Visible = False
        Me.ebFolioFactura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(40, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Folio Apartado:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(40, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Folio Factura:"
        Me.Label2.Visible = False
        '
        'ebCodCaja
        '
        Me.ebCodCaja.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebCodCaja.Location = New System.Drawing.Point(248, 48)
        Me.ebCodCaja.Name = "ebCodCaja"
        Me.ebCodCaja.ReadOnly = True
        Me.ebCodCaja.Size = New System.Drawing.Size(72, 23)
        Me.ebCodCaja.TabIndex = 1
        Me.ebCodCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'prgpgbar1
        '
        Me.prgpgbar1.Location = New System.Drawing.Point(16, 88)
        Me.prgpgbar1.Name = "prgpgbar1"
        Me.prgpgbar1.Size = New System.Drawing.Size(312, 3)
        Me.prgpgbar1.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(208, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Caja:"
        '
        'btnIniciarCaja
        '
        Me.btnIniciarCaja.Icon = CType(resources.GetObject("btnIniciarCaja.Icon"), System.Drawing.Icon)
        Me.btnIniciarCaja.Location = New System.Drawing.Point(88, 288)
        Me.btnIniciarCaja.Name = "btnIniciarCaja"
        Me.btnIniciarCaja.Size = New System.Drawing.Size(160, 32)
        Me.btnIniciarCaja.TabIndex = 3
        Me.btnIniciarCaja.Text = "Iniciar Caja"
        Me.btnIniciarCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFechaInicioCaja
        '
        '
        '
        '
        Me.ebFechaInicioCaja.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaInicioCaja.Location = New System.Drawing.Point(72, 48)
        Me.ebFechaInicioCaja.Name = "ebFechaInicioCaja"
        Me.ebFechaInicioCaja.Size = New System.Drawing.Size(128, 23)
        Me.ebFechaInicioCaja.TabIndex = 0
        Me.ebFechaInicioCaja.TodayButtonText = "Hoy"
        Me.ebFechaInicioCaja.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(24, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha:"
        '
        'frmInicioCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(346, 339)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(0, 264)
        Me.Name = "frmInicioCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Iniciar Caja"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.npFolios.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Environment Var"

    'Objeto InicioCaja
    Dim oInicioCajaMgr As InicioCajaManager
    Dim oInicioCaja As InicioCaja

    'Objeto InicioDia
    Dim oInicioDiaMgr As InicioDiaManager
    Dim oInicioDia As InicioDia

    'Objeto CatalogoCajas
    Dim CatalogoCajasMgr As CatalogoCajaManager
    Dim CatalogoCajasDataGate As CatalogoCajaDataGateway
    Dim CatalogoCaja As Caja
    Dim oAjusteMgr As AjusteGeneralManager


#End Region

#Region "Initialize Modules"

    Private Sub InitializeObjects()

        'Inicializamos Objeto Caja
        oInicioCajaMgr = New InicioCajaManager(oAppContext)
        oInicioCaja = oInicioCajaMgr.Create

        'Inicializamos Objeto Dia
        oInicioDiaMgr = New InicioDiaManager(oAppContext)
        oInicioDia = oInicioDiaMgr.Create

        oAjusteMgr = New AjusteGeneralManager(oAppContext)


    End Sub

    Private Sub InitializeBinding()

        ebFechaInicioCaja.DataBindings.Add(New Binding("Value", oInicioCaja, "FechaInicio"))
        ebCodCaja.DataBindings.Add(New Binding("Text", oInicioCaja, "CodCaja"))
        'ebFolioFactura.DataBindings.Add(New Binding("Value", oInicioCaja, "FolioFactura"))
        'ebFolioApartado.DataBindings.Add(New Binding("Value", oInicioCaja, "FolioApartado"))
        ''ebFolioNotadeCredito.DataBindings.Add(New Binding("Value", oInicioCaja, "FolioNotaCredito"))
        'ebFolioAbono.DataBindings.Add(New Binding("Value", oInicioCaja, "FolioAbono"))
        'ebFondoCaja.DataBindings.Add(New Binding("Value", oInicioCaja, "Fondo"))

    End Sub

#End Region

#Region "Methods"

    Private Sub frmInicioCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitializeObjects()

        InitializeBinding()

        GetCajaToCombo()

        Me.ebCodCaja.SelectedValue = oAppContext.ApplicationConfiguration.NoCaja
        CatalogoCajasMgr = New CatalogoCajaManager(oAppContext)
        CatalogoCajasDataGate = New CatalogoCajaDataGateway(CatalogoCajasMgr)
        CatalogoCaja = CatalogoCajasDataGate.SelectByID(ebCodCaja.Text)

        oInicioCaja.CodCaja = Me.ebCodCaja.Text
        Me.ebFolioApartado.Text = CStr(CatalogoCaja.FolioApartado)
        Me.ebFolioAbono.Text = CStr(CatalogoCaja.FolioAbono)
        Me.ebFolioFactura.Text = CatalogoCaja.FolioFactura
        'MsgBox(CatalogoCaja.FolioFactura.ToString)
        oInicioCaja.InicioDiaID = oInicioDiaMgr.Load(ebFechaInicioCaja.Value, oInicioCaja.CodAlmacen)

    End Sub

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

                ebCodCaja.Items.Add(dsCaja.Tables(0).Rows(i).Item("CodCaja"))

            Next i

            dsCaja = Nothing

        End If

        oCaja = Nothing
        oCajaMgr = Nothing

    End Sub

#End Region

    Private Sub ebFechaInicioCaja_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFechaInicioCaja.Validating

        oInicioCaja.InicioDiaID = oInicioDiaMgr.Load(ebFechaInicioCaja.Value, oInicioCaja.CodAlmacen)

    End Sub

    Private Function GetLocalIpAddress() As String
        Dim strHostName As String

        Dim ipList As String = String.Empty

        Dim strIPAddress As String

        strHostName = System.Net.Dns.GetHostName()
        For Each ip As System.Net.IPAddress In System.Net.Dns.GetHostByName(strHostName).AddressList()
            ipList &= ip.ToString() & " "
        Next
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()

        Return ipList
    End Function

    Private Sub btnIniciarCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniciarCaja.Click

        Dim strMensaje As String
        Dim strMensajeX As String

        If oInicioCaja.InicioDiaID = 0 Then

            MsgBox("No se ha iniciado día " & Format(ebFechaInicioCaja.Value, "dd/MM/yyyy") & "", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Inicio de Caja")

            ebFechaInicioCaja.Focus()

        Else

            'Valida FolioNotaVenta LZARATE
            strMensajeX = String.Empty
            strMensajeX = ValidaFolioNotaVentaManual()
            If Not (strMensajeX = String.Empty) Then
                MsgBox(strMensajeX, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Iniciar Caja")
                btnIniciarCaja.DialogResult = DialogResult.None
                btnIniciarCaja.Focus()

            Else

                strMensaje = ValidaFoliosFondo()
                If Not (strMensaje = String.Empty) Then

                    MsgBox(strMensaje, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Iniciar Caja")
                    btnIniciarCaja.DialogResult = DialogResult.None
                    btnIniciarCaja.Focus()

                Else


                    Dim myID As Integer

                    myID = oInicioCajaMgr.Load(ebCodCaja.Text, oInicioCaja.InicioDiaID)

                    If myID > 0 Then

                        MsgBox("La Caja " & ebCodCaja.Text & " para el Dia " & Format(ebFechaInicioCaja.Value, "dd/MM/yyyy") & " ya fue iniciada. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Inicio de Caja")

                    Else
                        oInicioCaja.FolioAbono = Me.ebFolioAbono.Text
                        oInicioCaja.FolioApartado = Me.ebFolioApartado.Text
                        oInicioCaja.FolioFactura = Me.ebFolioFactura.Text
                        oInicioCaja.Fecha = Me.ebFechaInicioCaja.Value
                        oInicioCaja.CodCaja = Me.ebCodCaja.Text
                        oInicioCaja.Fondo = Me.ebFondoCaja.Text
                        oInicioCaja.FolioNotaVentaManual = Me.txtNotaVenta.Value

                        '----------------------------------------------------------------------------------------------------------------------------------------
                        ' Actualizar la IP de la computadora en base de datos
                        '----------------------------------------------------------------------------------------------------------------------------------------
                        Dim oCajaMgr As CatalogoCajaManager
                        oCajaMgr = New CatalogoCajaManager(oAppContext)
                        oCajaMgr.UpdateIP(oAppContext.ApplicationConfiguration.NoCaja, GetLocalIpAddress())


                        oInicioCajaMgr.Save(oInicioCaja)

                        MsgBox("Inicio de Caja " & oInicioCaja.CodCaja & " para el Dia " & Format(ebFechaInicioCaja.Value, "dd/MM/yyyy") & " se realizó satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Inicio de Caja")
                        Me.DialogResult = DialogResult.OK
                        Me.Close()

                    End If

                End If

            End If
        End If
    End Sub

    Private Sub ebCodCaja_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodCaja.Validating

        If ebCodCaja.Text = String.Empty Then

            MsgBox("Ingrese Código de Caja. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Iniciar Caja")

            e.Cancel = True

        Else

            CatalogoCaja = CatalogoCajasDataGate.SelectByID(ebCodCaja.Text)
            'MsgBox(CatalogoCaja.FolioFactura.ToString)
            Me.ebFolioApartado.Text = CStr(CatalogoCaja.FolioApartado)
            Me.ebFolioAbono.Text = CStr(CatalogoCaja.FolioAbono)
            Me.ebFolioFactura.Text = CatalogoCaja.FolioFactura
        End If

    End Sub
    Private Function ValidaFolioNotaVentaManual() As String
        Dim mMensaje As String = String.Empty
        Dim FolioFromTabla As Integer = 0
        Dim FolioFromForm As Integer = 0

        FolioFromTabla = oAjusteMgr.LoadLimiteInferiorInicioCaja()
        FolioFromForm = Me.txtNotaVenta.Value

        'Validaciones
      
        If FolioFromTabla <> FolioFromForm Then
            mMensaje = mMensaje + "Folio Nota de Venta." & vbCrLf & "El Folio de Nota de Venta Manual a ingresar es el: " & FolioFromTabla
        End If

        If Not (mMensaje = String.Empty) Then

            mMensaje = " Los siguientes datos son incorrectos o faltan : " & vbCrLf & vbCrLf & mMensaje

        End If

        Return mMensaje
    End Function
    Private Function ValidaFoliosFondo() As String

        Dim mMensaje As String = String.Empty

        'If ebFolioFactura.Text.Equals("0") Or ebFolioFactura.Text = String.Empty Or ebFolioFactura.Value <> CatalogoCaja.FolioFactura Then

        '    mMensaje = mMensaje + "Folio de Factura " & vbCrLf

        'End If

        'If ebFolioApartado.Text.Equals("0") Or ebFolioApartado.Text = String.Empty Or ebFolioApartado.Value <> CatalogoCaja.FolioApartado Then

        '    mMensaje = mMensaje + "Folio de Apartado " & vbCrLf

        'End If

        'If ebFolioAbono.Value = 0 Or ebFolioAbono.Text = String.Empty Or ebFolioAbono.Value <> CatalogoCaja.FolioAbono Then

        '    mMensaje = mMensaje + "Folio de Abono " & vbCrLf

        'End If

        'If ebFolioNotadeCredito.Value = 0 Or ebFolioNotadeCredito.Value <> CatalogoCaja.FolioNotaCredito Then

        'mMensaje = mMensaje + "Folio de Nota de Crédito " & vbCrLf

        'End If

        If ebFondoCaja.Value = 0 Then

            mMensaje = mMensaje + "Fondo de Caja " & vbCrLf

        End If

        If Not (mMensaje = String.Empty) Then

            mMensaje = " Los siguientes datos son incorrectos o faltan : " & vbCrLf & vbCrLf & mMensaje

        End If

        Return mMensaje

    End Function

    'Private Sub ebFolioFactura_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioFactura.Validating
    '
    '       If ebFolioFactura.Value <> CatalogoCaja.FolioFactura Then
    '          e.Cancel = True
    '         MessageBox.Show("El Folio es Incorrecto", "DPTienda", MessageBoxButtons.OK)
    '
    '       End If
    '
    '   End Sub

    '    Private Sub ebFolioAbono_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioAbono.Validating
    '
    '       If ebFolioAbono.Value <> CatalogoCaja.FolioAbono Then
    '          e.Cancel = True
    '         MessageBox.Show("El Folio es Incorrecto", "DPTienda", MessageBoxButtons.OK)
    '
    '       End If
    '
    '   End Sub

    'Private Sub ebFolioApartado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioApartado.Validating
    '
    '       If ebFolioApartado.Value <> CatalogoCaja.FolioApartado Then
    '          e.Cancel = True
    '         MessageBox.Show("El Folio es Incorrecto", "DPTienda", MessageBoxButtons.OK)
    '
    '       End If
    '
    '   End Sub

    'Private Sub ebFolioNotadeCredito_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioNotadeCredito.Validating
    '
    '       If ebFolioNotadeCredito.Value <> CatalogoCaja.FolioNotaCredito Then
    '          e.Cancel = True
    '         MessageBox.Show("El Folio es Incorrecto", "DPTienda", MessageBoxButtons.OK)
    '
    '       End If
    '
    '   End Sub

    Private Sub ebFondoCaja_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFondoCaja.Validating

        If ebFondoCaja.Value < 0 Then

            ebFondoCaja.Value = 0
        Else
            Me.ebFolioApartado.Text = CStr(CatalogoCaja.FolioApartado)
            Me.ebFolioAbono.Text = CStr(CatalogoCaja.FolioAbono)
            Me.ebFolioFactura.Text = CatalogoCaja.FolioFactura

        End If

    End Sub


    Private Sub frmInicioCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


End Class