Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class ReportesGlobalesInventarioReportForm

    Inherits System.Windows.Forms.Form

    Dim strConnectionString As String = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString
    Dim dtGlobal As New DataTable("Global")

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
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel3 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents cbTipoReporte As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebCodMarca As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodLinea As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodFamilia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMarca As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebLinea As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFamilia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbMes As Janus.Windows.EditControls.UIComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem7 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem8 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem9 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem10 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem11 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem12 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportesGlobalesInventarioReportForm))
        Dim UiComboBoxItem13 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem14 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem15 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbMes = New Janus.Windows.EditControls.UIComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.uIGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbTipoReporte = New Janus.Windows.EditControls.UIComboBox()
        Me.ebFamilia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebLinea = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebMarca = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodFamilia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodLinea = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodMarca = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.lblLabel3 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uIGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.UiGroupBox2)
        Me.explorerBar1.Controls.Add(Me.btnImprimir)
        Me.explorerBar1.Controls.Add(Me.btnExportar)
        Me.explorerBar1.Controls.Add(Me.uIGroupBox1)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Filtros"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(352, 312)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.TabStop = False
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.Controls.Add(Me.cbMes)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Location = New System.Drawing.Point(16, 27)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(312, 48)
        Me.UiGroupBox2.TabIndex = 0
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'cbMes
        '
        Me.cbMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cbMes.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbMes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "ENERO"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "FEBRERO"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "MARZO"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "ABRIL"
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "MAYO"
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "JUNIO"
        UiComboBoxItem7.FormatStyle.Alpha = 0
        UiComboBoxItem7.IsSeparator = False
        UiComboBoxItem7.Text = "JULIO"
        UiComboBoxItem8.FormatStyle.Alpha = 0
        UiComboBoxItem8.IsSeparator = False
        UiComboBoxItem8.Text = "AGOSTO"
        UiComboBoxItem9.FormatStyle.Alpha = 0
        UiComboBoxItem9.IsSeparator = False
        UiComboBoxItem9.Text = "SEPTIEMBRE"
        UiComboBoxItem10.FormatStyle.Alpha = 0
        UiComboBoxItem10.IsSeparator = False
        UiComboBoxItem10.Text = "OCTUBRE"
        UiComboBoxItem11.FormatStyle.Alpha = 0
        UiComboBoxItem11.IsSeparator = False
        UiComboBoxItem11.Text = "NOVIEMBRE"
        UiComboBoxItem12.FormatStyle.Alpha = 0
        UiComboBoxItem12.IsSeparator = False
        UiComboBoxItem12.Text = "DICIEMBRE"
        Me.cbMes.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5, UiComboBoxItem6, UiComboBoxItem7, UiComboBoxItem8, UiComboBoxItem9, UiComboBoxItem10, UiComboBoxItem11, UiComboBoxItem12})
        Me.cbMes.Location = New System.Drawing.Point(96, 16)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(200, 22)
        Me.cbMes.TabIndex = 0
        Me.cbMes.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(56, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mes :"
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(32, 256)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(128, 32)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(184, 256)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(128, 32)
        Me.btnExportar.TabIndex = 3
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uIGroupBox1
        '
        Me.uIGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.uIGroupBox1.Controls.Add(Me.cbTipoReporte)
        Me.uIGroupBox1.Controls.Add(Me.ebFamilia)
        Me.uIGroupBox1.Controls.Add(Me.ebLinea)
        Me.uIGroupBox1.Controls.Add(Me.ebMarca)
        Me.uIGroupBox1.Controls.Add(Me.ebCodFamilia)
        Me.uIGroupBox1.Controls.Add(Me.ebCodLinea)
        Me.uIGroupBox1.Controls.Add(Me.ebCodMarca)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel4)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel3)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel2)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel1)
        Me.uIGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uIGroupBox1.Location = New System.Drawing.Point(16, 80)
        Me.uIGroupBox1.Name = "uIGroupBox1"
        Me.uIGroupBox1.Size = New System.Drawing.Size(312, 160)
        Me.uIGroupBox1.TabIndex = 1
        Me.uIGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'cbTipoReporte
        '
        Me.cbTipoReporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cbTipoReporte.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoReporte.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem13.FormatStyle.Alpha = 0
        UiComboBoxItem13.IsSeparator = False
        UiComboBoxItem13.Text = "LINEA / FAMILIA"
        UiComboBoxItem14.FormatStyle.Alpha = 0
        UiComboBoxItem14.IsSeparator = False
        UiComboBoxItem14.Text = "MARCA / LINEA / FAMILIA"
        UiComboBoxItem15.FormatStyle.Alpha = 0
        UiComboBoxItem15.IsSeparator = False
        UiComboBoxItem15.Text = "TODAS"
        Me.cbTipoReporte.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem13, UiComboBoxItem14, UiComboBoxItem15})
        Me.cbTipoReporte.Location = New System.Drawing.Point(96, 24)
        Me.cbTipoReporte.Name = "cbTipoReporte"
        Me.cbTipoReporte.Size = New System.Drawing.Size(200, 22)
        Me.cbTipoReporte.TabIndex = 0
        Me.cbTipoReporte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFamilia
        '
        Me.ebFamilia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFamilia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFamilia.BackColor = System.Drawing.Color.Ivory
        Me.ebFamilia.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFamilia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebFamilia.Enabled = False
        Me.ebFamilia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFamilia.Location = New System.Drawing.Point(120, 120)
        Me.ebFamilia.Name = "ebFamilia"
        Me.ebFamilia.Size = New System.Drawing.Size(176, 22)
        Me.ebFamilia.TabIndex = 13
        Me.ebFamilia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFamilia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebLinea
        '
        Me.ebLinea.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebLinea.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebLinea.BackColor = System.Drawing.Color.Ivory
        Me.ebLinea.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebLinea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebLinea.Enabled = False
        Me.ebLinea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebLinea.Location = New System.Drawing.Point(120, 88)
        Me.ebLinea.Name = "ebLinea"
        Me.ebLinea.Size = New System.Drawing.Size(176, 22)
        Me.ebLinea.TabIndex = 12
        Me.ebLinea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebLinea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMarca
        '
        Me.ebMarca.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMarca.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMarca.BackColor = System.Drawing.Color.Ivory
        Me.ebMarca.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebMarca.Enabled = False
        Me.ebMarca.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMarca.Location = New System.Drawing.Point(120, 56)
        Me.ebMarca.Name = "ebMarca"
        Me.ebMarca.Size = New System.Drawing.Size(176, 22)
        Me.ebMarca.TabIndex = 11
        Me.ebMarca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodFamilia
        '
        Me.ebCodFamilia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodFamilia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodFamilia.ButtonImage = CType(resources.GetObject("ebCodFamilia.ButtonImage"), System.Drawing.Image)
        Me.ebCodFamilia.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodFamilia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodFamilia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodFamilia.Location = New System.Drawing.Point(56, 120)
        Me.ebCodFamilia.MaxLength = 3
        Me.ebCodFamilia.Name = "ebCodFamilia"
        Me.ebCodFamilia.Size = New System.Drawing.Size(56, 22)
        Me.ebCodFamilia.TabIndex = 3
        Me.ebCodFamilia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodFamilia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodLinea
        '
        Me.ebCodLinea.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodLinea.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodLinea.ButtonImage = CType(resources.GetObject("ebCodLinea.ButtonImage"), System.Drawing.Image)
        Me.ebCodLinea.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodLinea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodLinea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodLinea.Location = New System.Drawing.Point(56, 88)
        Me.ebCodLinea.MaxLength = 3
        Me.ebCodLinea.Name = "ebCodLinea"
        Me.ebCodLinea.Size = New System.Drawing.Size(56, 22)
        Me.ebCodLinea.TabIndex = 2
        Me.ebCodLinea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodLinea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodMarca
        '
        Me.ebCodMarca.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodMarca.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodMarca.ButtonFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodMarca.ButtonImage = CType(resources.GetObject("ebCodMarca.ButtonImage"), System.Drawing.Image)
        Me.ebCodMarca.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodMarca.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodMarca.Location = New System.Drawing.Point(56, 56)
        Me.ebCodMarca.MaxLength = 3
        Me.ebCodMarca.Name = "ebCodMarca"
        Me.ebCodMarca.Size = New System.Drawing.Size(56, 22)
        Me.ebCodMarca.TabIndex = 1
        Me.ebCodMarca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel4
        '
        Me.lblLabel4.Location = New System.Drawing.Point(16, 123)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(48, 16)
        Me.lblLabel4.TabIndex = 6
        Me.lblLabel4.Text = "Familia"
        '
        'lblLabel3
        '
        Me.lblLabel3.Location = New System.Drawing.Point(16, 91)
        Me.lblLabel3.Name = "lblLabel3"
        Me.lblLabel3.Size = New System.Drawing.Size(48, 16)
        Me.lblLabel3.TabIndex = 5
        Me.lblLabel3.Text = "Linea"
        '
        'lblLabel2
        '
        Me.lblLabel2.Location = New System.Drawing.Point(16, 59)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(48, 16)
        Me.lblLabel2.TabIndex = 4
        Me.lblLabel2.Text = "Marca"
        '
        'lblLabel1
        '
        Me.lblLabel1.Location = New System.Drawing.Point(16, 27)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(104, 16)
        Me.lblLabel1.TabIndex = 3
        Me.lblLabel1.Text = "Tipo Reporte :"
        '
        'ReportesGlobalesInventarioReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(346, 302)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ReportesGlobalesInventarioReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Reportes Globales de Inventario"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uIGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Objetos"

#Region "Variables"

    'Catalogo Marcas
    Dim oMarcaMgr As CatalogoMarcasManager
    Dim oMarca As Marca

    'Catalogo Lineas
    Dim oLineasMgr As CatalogoLineasManager
    Dim oLinea As Linea

    'Catalogo Familias
    Dim oFamiliaMgr As CatalogoFamiliasManager
    Dim oFamilia As Familias

    Dim intTipoReporteTemp As Integer = 0

#End Region

#Region "Inicializar"

    Private Sub Inicializar()

        'Catalogo Marcas
        oMarcaMgr = New CatalogoMarcasManager(oAppContext)
        oMarca = oMarcaMgr.Create

        'Catalogo Lineas
        oLineasMgr = New CatalogoLineasManager(oAppContext)
        oLinea = oLineasMgr.Create

        'Catalogo Familias
        oFamiliaMgr = New CatalogoFamiliasManager(oAppContext)
        oFamilia = oFamiliaMgr.Create

    End Sub

#End Region

#End Region

#Region "Methods"

#Region "Form Methods"

    Private Sub ReportesGlobalesInventarioReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")

            Case e.Alt And Keys.S

                If (Me.ActiveControl.Name = "ebCodMarca") Then
                    Buscar_Marca()
                End If
                If (Me.ActiveControl.Name = "ebCodLinea") Then
                    Buscar_Linea()
                End If
                If (Me.ActiveControl.Name = "ebCodFamilia") Then
                    Buscar_Familia()
                End If

            Case Keys.Escape

                Me.Finalize()
                Me.Close()

        End Select

    End Sub

    Private Sub ReportesGlobalesInventarioReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Inicializar()
        'ASANCHEZ 09/06/2021 inicializamos las descargas, Descargar existencias al ingresar a la opción de Reporte Global de Inventario 
        Dim ofrmLoad As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
        oAppSAPConfig.DercargaManual = True
        Try
            ofrmLoad.ShowDev("Inventarios")
        Catch exc As Exception
            MsgBox(exc)
            oAppSAPConfig.DercargaManual = False
        End Try

        cbMes.SelectedIndex = Month(Date.Now) - 1
        cbTipoReporte.SelectedIndex = 0

    End Sub

    Private Sub ebCodMarca_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodMarca.ButtonClick

        Buscar_Marca()

    End Sub

    Private Sub ebCodLinea_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodLinea.ButtonClick

        Buscar_Linea()

    End Sub

    Private Sub ebCodFamilia_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodFamilia.ButtonClick

        Buscar_Familia()

    End Sub

    Private Sub ebCodMarca_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodMarca.Validating

        If ebCodMarca.Text <> String.Empty Then

            'Buscamos Marca
            oMarca = Nothing
            oMarca = oMarcaMgr.Load(ebCodMarca.Text.Trim)

            If oMarca Is Nothing Then
                MsgBox("Código de Marca No Existe", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Reportes Globales")
                ebMarca.Text = String.Empty
                e.Cancel = True
            Else
                ebMarca.Text = oMarca.Descripcion
            End If

        Else

            ebMarca.Text = String.Empty

        End If

    End Sub

    Private Sub ebCodLinea_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodLinea.Validating

        If ebCodLinea.Text <> String.Empty Then

            'Buscamos Linea
            oLinea = Nothing
            oLinea = oLineasMgr.Load(ebCodLinea.Text.Trim)

            If oLinea Is Nothing Then
                MsgBox("Código de Línea No Existe", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Reportes Globales")
                ebLinea.Text = String.Empty
                e.Cancel = True
            Else
                ebLinea.Text = oLinea.Descripcion
            End If

        Else

            ebLinea.Text = String.Empty

        End If

    End Sub

    Private Sub ebCodFamilia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodFamilia.Validating

        If ebCodFamilia.Text <> String.Empty Then

            'Buscamos Familia
            oFamilia = Nothing
            oFamilia = oFamiliaMgr.Load(ebCodFamilia.Text.Trim)

            If oFamilia Is Nothing Then
                MsgBox("Código de Familia No Existe", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Reportes Globales")
                ebFamilia.Text = String.Empty
                e.Cancel = True
            Else
                ebFamilia.Text = oFamilia.Descripcion
            End If

        Else

            ebCodFamilia.Text = String.Empty

        End If

    End Sub

    Private Sub cbTipoReporte_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipoReporte.SelectedIndexChanged

        If cbTipoReporte.SelectedIndex = 0 Then
            ebCodMarca.Text = String.Empty
            ebMarca.Text = String.Empty
            ebCodMarca.Enabled = False
            ebCodFamilia.Enabled = True
            ebCodLinea.Enabled = True
            intTipoReporteTemp = 0
        ElseIf cbTipoReporte.SelectedIndex = 1 Then
            ebCodFamilia.Text = String.Empty
            ebFamilia.Text = String.Empty
            ebCodLinea.Text = String.Empty
            ebLinea.Text = String.Empty
            ebCodMarca.Text = String.Empty
            ebMarca.Text = String.Empty
            ebCodFamilia.Enabled = True
            ebCodLinea.Enabled = True
            ebCodMarca.Enabled = True
            intTipoReporteTemp = 1
        Else
            ebCodFamilia.Text = String.Empty
            ebFamilia.Text = String.Empty
            ebCodLinea.Text = String.Empty
            ebLinea.Text = String.Empty
            ebCodMarca.Text = String.Empty
            ebMarca.Text = String.Empty
            ebCodMarca.Enabled = False
            ebCodFamilia.Enabled = False
            ebCodLinea.Enabled = False
            intTipoReporteTemp = 2
        End If

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        dtGlobal = SelectGlobal(NumeroMes, intTipoReporteTemp)

        Imprimir()

    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        Me.Cursor = Cursors.WaitCursor

        dtGlobal = SelectGlobal(NumeroMes, intTipoReporteTemp)

        Me.Cursor = Cursors.Default

        Exportar()

    End Sub

#End Region

#Region "Members Methods"

    Private Function GetAlmacen() As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim strAlmacen As String = oAppContext.ApplicationConfiguration.Almacen
        Dim AlmacenDescripcion As String = String.Empty
        oAlmacen = oAlmacenMgr.Create
        oAlmacenMgr.LoadInto(strAlmacen, oAlmacen)

        AlmacenDescripcion = strAlmacen & " " & oAlmacen.Descripcion

        oAlmacen = Nothing
        oAlmacenMgr = Nothing

        Return AlmacenDescripcion

    End Function

    Private Sub Imprimir()

        Dim oARReporte As New ReportesGlobalesInventarioReport(cbMes.Text, ebMarca.Text, ebLinea.Text, ebFamilia.Text, dtGlobal, GetAlmacen)
        Dim oReportViewer As New ReportViewerForm
        oARReporte.Document.Name = "Reportes Globales de Inventario"
        ''oARReporte.Document.Print(False, False)
        oReportViewer.Report = oARReporte
        Me.Cursor = Cursors.Default
        oReportViewer.Show()

    End Sub

    Private Sub Buscar_Marca()

        Dim oOpenRecordDlg As New OpenRecordDialog

        oOpenRecordDlg.CurrentView = New CatalogoMarcasRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
            ebCodMarca.Text = oOpenRecordDlg.Record.Item("CodMarca")
            ebMarca.Text = oOpenRecordDlg.Record.Item("Descripcion")
            SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub Buscar_Linea()

        Dim oOpenRecordDlg As New OpenRecordDialog

        oOpenRecordDlg.CurrentView = New CatalogoLineaOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
            ebCodLinea.Text = oOpenRecordDlg.Record.Item("CodLinea")
            ebLinea.Text = oOpenRecordDlg.Record.Item("Descripcion")
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Buscar_Familia()

        Dim oOpenRecordDlg As New OpenRecordDialog

        oOpenRecordDlg.CurrentView = New CatalogoFamiliasOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
            ebCodFamilia.Text = oOpenRecordDlg.Record.Item("CodFamilia")
            ebFamilia.Text = oOpenRecordDlg.Record.Item("Descripcion")
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Exportar()

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
        wsxl.Name = "Auditoria de Retiros"

        '****************************************
        'HOJA DE CALCULO REPORTES GLOBALES
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE AUDITORIA DEL MES DE : " & cbMes.Text
        If UCase(cbTipoReporte.Text.Trim) = "TODAS" Then
            wsxl.Cells(2, 1).Value = "TODAS LAS MARCAS, LINEAS, FAMILIAS"
        Else
            If ebCodMarca.Text = String.Empty Then
                wsxl.Cells(2, 1).Value = "POR FAMILIA : " & ebFamilia.Text & " LINEA : " & ebLinea.Text
            Else
                wsxl.Cells(2, 1).Value = "POR MARCA : " & ebMarca.Text & " FAMILIA : " & ebFamilia.Text & " LINEA : " & ebLinea.Text
            End If
        End If
        wsxl.Range("A1:D1").Merge()
        wsxl.Range("A2:D2").Merge()
        wsxl.Range("A1:D2").Font.Bold = True
        wsxl.Range("A1:D1").Font.Size = 12
        wsxl.Range("A1:D2").Interior.Color = &HDFFFCC
        wsxl.Range("A1:D2").BorderAround(, 2, 0, )
        wsxl.Range("A1:D2").HorizontalAlignment = 3

        wsxl.Cells(3, 4).Value = Format(Date.Now, "short date")
        wsxl.Cells(3, 4).Font.Size = 10
        wsxl.Cells(3, 4).Font.Bold = True

        wsxl.Cells(4, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(4, 1).Font.Size = 10
        wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Range("A4:D4").Merge()
        wsxl.Range("A4:D4").HorizontalAlignment = 3

        'Encabezado
        wsxl.Cells(6, 1).Value = "CODIGO"
        wsxl.Cells(6, 2).Value = "NOMBRE"
        wsxl.Cells(6, 3).Value = "CANTIDAD"
        wsxl.Cells(6, 4).Value = "COSTO"
        wsxl.Range("A6:D6").Font.Bold = True
        wsxl.Range("A6:D6").HorizontalAlignment = 3
        wsxl.Range("A6:D6").Font.Size = 8
        wsxl.Range("A6:D6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:D6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oRow In dtGlobal.Rows
            intRow = intRow + 1
            wsxl.Cells(6 + intRow, 1).Value = oRow!Codigo
            wsxl.Cells(6 + intRow, 1).HorizontalAlignment = 3
            wsxl.Cells(6 + intRow, 2).Value = oRow!Nombre
            wsxl.Cells(6 + intRow, 3).Value = oRow!Cantidad
            wsxl.Cells(6 + intRow, 4).Value = oRow!Costo
        Next

        wsxl.Cells(8 + intRow, 2).Value = "TOTALES :"
        wsxl.Cells(8 + intRow, 3).Value = "=SUMA(C7:C" & Trim(Str(6 + intRow)) & ")"
        wsxl.Cells(8 + intRow, 4).Value = "=SUMA(D7:D" & Trim(Str(6 + intRow)) & ")"
        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":D" & Trim(Str(8 + intRow))).BorderAround(, 2, 0, )
        wsxl.Range("C6:C" & Trim(Str(8 + intRow))).NumberFormat = "###,###,##0"
        wsxl.Range("D6:D" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":D" & Trim(Str(8 + intRow))).Font.Bold = True

        wsxl.Range("A6:A6").ColumnWidth = 10
        wsxl.Range("B6:B6").ColumnWidth = 30
        wsxl.Range("C6:C6").ColumnWidth = 15
        wsxl.Range("D6:D6").ColumnWidth = 15
        wsxl.PageSetup.FitToPagesWide = 1
        wsxl.PageSetup.FitToPagesTall = 1

        Me.Cursor = Cursors.Default

        'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
        SaveDialog.DefaultExt = "*.xls"
        SaveDialog.Filter = "(*.xls)|*.xls"
        If SaveDialog.ShowDialog = DialogResult.OK Then
            wbxl.SaveAs(SaveDialog.FileName)
            MsgBox("Documento guardado en " & SaveDialog.FileName, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Repote Notas de Crédito")
        End If

        wbxl.Close()
        wsxl = Nothing
        xlapp.Quit()
        xlapp = Nothing

        KillExcel()

    End Sub

    Private Function NumeroMes() As Integer

        Dim intMes As Integer

        Select Case cbMes.Text
            Case "ENERO"
                intMes = 1
            Case "FEBRERO"
                intMes = 2
            Case "MARZO"
                intMes = 3
            Case "ABRIL"
                intMes = 4
            Case "MAYO"
                intMes = 5
            Case "JUNIO"
                intMes = 6
            Case "JULIO"
                intMes = 7
            Case "AGOSTO"
                intMes = 8
            Case "SEPTIEMBRE"
                intMes = 9
            Case "OCTUBRE"
                intMes = 10
            Case "NOVIEMBRE"
                intMes = 11
            Case "DICIEMBRE"
                intMes = 12
        End Select

        Return intMes

    End Function

#End Region

#Region "SQL Methods"

    Private Function SelectGlobal(ByVal intMes As Integer, ByVal intTipoReporte As Integer) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daGlobal As SqlDataAdapter
        Dim dtGlobal As New DataTable("Global")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[ReportesGlobalesInventarioSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sucursal", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoReporte", System.Data.SqlDbType.Int, 4))

            .Parameters("@Mes").Value = intMes
            .Parameters("@CodMarca").Value = ebCodMarca.Text.Trim
            .Parameters("@CodLinea").Value = ebCodLinea.Text.Trim
            .Parameters("@CodFamilia").Value = ebCodFamilia.Text.Trim
            .Parameters("@Sucursal").Value = oAppContext.ApplicationConfiguration.Almacen
            .Parameters("@TipoReporte").Value = intTipoReporte

        End With

        daGlobal = New SqlDataAdapter(sccmdSelect)

        Try

            daGlobal.Fill(dtGlobal)

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

            Me.Cursor = Cursors.Default

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de aplicación.", ex)

        End Try

        daGlobal.Dispose()
        daGlobal = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtGlobal

    End Function

#End Region

#End Region


End Class
