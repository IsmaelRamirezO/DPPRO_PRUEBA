Imports DportenisPro.DPTienda.Reports.Inventario

Public Class InventarioMovimientosArticuloReportForm
    Inherits DPTienda.GridReportBaseForm

    Dim oReport As New InventarioReport
    Dim oReporter As New InventarioMovimientoArticulosReporter
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
    Friend WithEvents uicbMes As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebAlmacen As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebArticuloID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCorDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCorridaFin As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCorridaIni As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSaldoFin As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbLabel2 As System.Windows.Forms.Label
    Friend WithEvents lbLabel1 As System.Windows.Forms.Label
    Friend WithEvents lbLabel3 As System.Windows.Forms.Label
    Friend WithEvents lbLabel4 As System.Windows.Forms.Label
    Friend WithEvents lbLabel5 As System.Windows.Forms.Label
    Friend WithEvents lbLabel6 As System.Windows.Forms.Label
    Friend WithEvents lbLabel7 As System.Windows.Forms.Label
    Friend WithEvents lbLabel8 As System.Windows.Forms.Label
    Friend WithEvents ebSaldoIni As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventarioMovimientosArticuloReportForm))
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
        Me.uicbMes = New Janus.Windows.EditControls.UIComboBox()
        Me.ebAlmacen = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lbLabel2 = New System.Windows.Forms.Label()
        Me.lbLabel1 = New System.Windows.Forms.Label()
        Me.ebArticuloID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCorDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCorridaFin = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCorridaIni = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSaldoFin = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lbLabel3 = New System.Windows.Forms.Label()
        Me.lbLabel4 = New System.Windows.Forms.Label()
        Me.lbLabel5 = New System.Windows.Forms.Label()
        Me.lbLabel6 = New System.Windows.Forms.Label()
        Me.lbLabel7 = New System.Windows.Forms.Label()
        Me.lbLabel8 = New System.Windows.Forms.Label()
        Me.ebSaldoIni = New Janus.Windows.GridEX.EditControls.EditBox()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbParameters.SuspendLayout()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateReport.Location = New System.Drawing.Point(296, 72)
        Me.btnGenerateReport.TabIndex = 8
        Me.btnGenerateReport.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'geResults
        '
        Me.geResults.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.geResults.ControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.ControlStyle.HoverBaseColor = System.Drawing.Color.AliceBlue
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.geResults.DesignTimeLayout = GridEXLayout1
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.geResults.GroupByBoxVisible = False
        Me.geResults.Size = New System.Drawing.Size(752, 133)
        Me.geResults.TabStop = False
        '
        'uigbParameters
        '
        Me.uigbParameters.Controls.Add(Me.ebSaldoIni)
        Me.uigbParameters.Controls.Add(Me.lbLabel8)
        Me.uigbParameters.Controls.Add(Me.lbLabel7)
        Me.uigbParameters.Controls.Add(Me.lbLabel6)
        Me.uigbParameters.Controls.Add(Me.lbLabel5)
        Me.uigbParameters.Controls.Add(Me.lbLabel4)
        Me.uigbParameters.Controls.Add(Me.lbLabel3)
        Me.uigbParameters.Controls.Add(Me.ebCorDescripcion)
        Me.uigbParameters.Controls.Add(Me.ebCorridaFin)
        Me.uigbParameters.Controls.Add(Me.ebCorridaIni)
        Me.uigbParameters.Controls.Add(Me.ebSaldoFin)
        Me.uigbParameters.Controls.Add(Me.ebArticuloID)
        Me.uigbParameters.Controls.Add(Me.uicbMes)
        Me.uigbParameters.Controls.Add(Me.ebAlmacen)
        Me.uigbParameters.Controls.Add(Me.lbLabel2)
        Me.uigbParameters.Controls.Add(Me.lbLabel1)
        Me.uigbParameters.Location = New System.Drawing.Point(0, 50)
        Me.uigbParameters.Size = New System.Drawing.Size(760, 190)
        Me.uigbParameters.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        Me.uigbParameters.Controls.SetChildIndex(Me.btnGenerateReport, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lbLabel1, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lbLabel2, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebAlmacen, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.uicbMes, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebArticuloID, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebSaldoFin, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebCorridaIni, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebCorridaFin, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebCorDescripcion, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lbLabel3, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lbLabel4, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lbLabel5, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lbLabel6, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lbLabel7, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lbLabel8, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebSaldoIni, 0)
        '
        'uicmEnvironment
        '
        '
        '
        '
        Me.uicmEnvironment.EditContextMenu.Key = ""
        Me.uicmEnvironment.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uicbMes
        '
        Me.uicbMes.AutoSize = False
        Me.uicbMes.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "Enero"
        UiComboBoxItem1.Value = "1"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "Febrero"
        UiComboBoxItem2.Value = "2"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "Marzo"
        UiComboBoxItem3.Value = "3"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "Abril"
        UiComboBoxItem4.Value = "4"
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "Mayo"
        UiComboBoxItem5.Value = "5"
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "Junio"
        UiComboBoxItem6.Value = "6"
        UiComboBoxItem7.FormatStyle.Alpha = 0
        UiComboBoxItem7.IsSeparator = False
        UiComboBoxItem7.Text = "Julio"
        UiComboBoxItem7.Value = "7"
        UiComboBoxItem8.FormatStyle.Alpha = 0
        UiComboBoxItem8.IsSeparator = False
        UiComboBoxItem8.Text = "Agosto"
        UiComboBoxItem8.Value = "8"
        UiComboBoxItem9.FormatStyle.Alpha = 0
        UiComboBoxItem9.IsSeparator = False
        UiComboBoxItem9.Text = "Septiembre"
        UiComboBoxItem9.Value = "9"
        UiComboBoxItem10.FormatStyle.Alpha = 0
        UiComboBoxItem10.IsSeparator = False
        UiComboBoxItem10.Text = "Octubre"
        UiComboBoxItem10.Value = "10"
        UiComboBoxItem11.FormatStyle.Alpha = 0
        UiComboBoxItem11.IsSeparator = False
        UiComboBoxItem11.Text = "Noviembre"
        UiComboBoxItem11.Value = "11"
        UiComboBoxItem12.FormatStyle.Alpha = 0
        UiComboBoxItem12.IsSeparator = False
        UiComboBoxItem12.Text = "Diciembre"
        UiComboBoxItem12.Value = "12"
        Me.uicbMes.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5, UiComboBoxItem6, UiComboBoxItem7, UiComboBoxItem8, UiComboBoxItem9, UiComboBoxItem10, UiComboBoxItem11, UiComboBoxItem12})
        Me.uicbMes.Location = New System.Drawing.Point(120, 40)
        Me.uicbMes.Name = "uicbMes"
        Me.uicbMes.Size = New System.Drawing.Size(104, 24)
        Me.uicbMes.TabIndex = 1
        Me.uicbMes.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebAlmacen
        '
        Me.ebAlmacen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAlmacen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAlmacen.ButtonImage = CType(resources.GetObject("ebAlmacen.ButtonImage"), System.Drawing.Image)
        Me.ebAlmacen.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebAlmacen.Location = New System.Drawing.Point(120, 8)
        Me.ebAlmacen.MaxLength = 3
        Me.ebAlmacen.Name = "ebAlmacen"
        Me.ebAlmacen.Size = New System.Drawing.Size(104, 24)
        Me.ebAlmacen.TabIndex = 0
        Me.ebAlmacen.Text = "000"
        Me.ebAlmacen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lbLabel2
        '
        Me.lbLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lbLabel2.Location = New System.Drawing.Point(16, 40)
        Me.lbLabel2.Name = "lbLabel2"
        Me.lbLabel2.Size = New System.Drawing.Size(72, 23)
        Me.lbLabel2.TabIndex = 12
        Me.lbLabel2.Text = "Mes:"
        Me.lbLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLabel1
        '
        Me.lbLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lbLabel1.Location = New System.Drawing.Point(16, 8)
        Me.lbLabel1.Name = "lbLabel1"
        Me.lbLabel1.Size = New System.Drawing.Size(72, 23)
        Me.lbLabel1.TabIndex = 11
        Me.lbLabel1.Text = "Almacen:"
        Me.lbLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebArticuloID
        '
        Me.ebArticuloID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebArticuloID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebArticuloID.ButtonImage = CType(resources.GetObject("ebArticuloID.ButtonImage"), System.Drawing.Image)
        Me.ebArticuloID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebArticuloID.Location = New System.Drawing.Point(120, 72)
        Me.ebArticuloID.MaxLength = 20
        Me.ebArticuloID.Name = "ebArticuloID"
        Me.ebArticuloID.Size = New System.Drawing.Size(168, 24)
        Me.ebArticuloID.TabIndex = 2
        Me.ebArticuloID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebArticuloID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCorDescripcion
        '
        Me.ebCorDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCorDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCorDescripcion.Location = New System.Drawing.Point(120, 132)
        Me.ebCorDescripcion.Name = "ebCorDescripcion"
        Me.ebCorDescripcion.ReadOnly = True
        Me.ebCorDescripcion.Size = New System.Drawing.Size(248, 21)
        Me.ebCorDescripcion.TabIndex = 4
        Me.ebCorDescripcion.TabStop = False
        Me.ebCorDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCorDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCorridaFin
        '
        Me.ebCorridaFin.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCorridaFin.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCorridaFin.Location = New System.Drawing.Point(293, 104)
        Me.ebCorridaFin.Name = "ebCorridaFin"
        Me.ebCorridaFin.ReadOnly = True
        Me.ebCorridaFin.Size = New System.Drawing.Size(75, 21)
        Me.ebCorridaFin.TabIndex = 9
        Me.ebCorridaFin.TabStop = False
        Me.ebCorridaFin.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCorridaFin.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCorridaIni
        '
        Me.ebCorridaIni.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCorridaIni.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCorridaIni.Location = New System.Drawing.Point(120, 104)
        Me.ebCorridaIni.Name = "ebCorridaIni"
        Me.ebCorridaIni.ReadOnly = True
        Me.ebCorridaIni.Size = New System.Drawing.Size(75, 21)
        Me.ebCorridaIni.TabIndex = 3
        Me.ebCorridaIni.TabStop = False
        Me.ebCorridaIni.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCorridaIni.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSaldoFin
        '
        Me.ebSaldoFin.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoFin.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoFin.Location = New System.Drawing.Point(293, 160)
        Me.ebSaldoFin.Name = "ebSaldoFin"
        Me.ebSaldoFin.ReadOnly = True
        Me.ebSaldoFin.Size = New System.Drawing.Size(75, 21)
        Me.ebSaldoFin.TabIndex = 10
        Me.ebSaldoFin.TabStop = False
        Me.ebSaldoFin.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSaldoFin.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lbLabel3
        '
        Me.lbLabel3.BackColor = System.Drawing.Color.Transparent
        Me.lbLabel3.Location = New System.Drawing.Point(16, 78)
        Me.lbLabel3.Name = "lbLabel3"
        Me.lbLabel3.Size = New System.Drawing.Size(64, 18)
        Me.lbLabel3.TabIndex = 13
        Me.lbLabel3.Text = "Artículo:"
        '
        'lbLabel4
        '
        Me.lbLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lbLabel4.Location = New System.Drawing.Point(16, 109)
        Me.lbLabel4.Name = "lbLabel4"
        Me.lbLabel4.Size = New System.Drawing.Size(96, 16)
        Me.lbLabel4.TabIndex = 14
        Me.lbLabel4.Text = "Corrida Inicial:"
        '
        'lbLabel5
        '
        Me.lbLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lbLabel5.Location = New System.Drawing.Point(200, 109)
        Me.lbLabel5.Name = "lbLabel5"
        Me.lbLabel5.Size = New System.Drawing.Size(88, 11)
        Me.lbLabel5.TabIndex = 6
        Me.lbLabel5.Text = "Corrida Final:"
        '
        'lbLabel6
        '
        Me.lbLabel6.BackColor = System.Drawing.Color.Transparent
        Me.lbLabel6.Location = New System.Drawing.Point(16, 136)
        Me.lbLabel6.Name = "lbLabel6"
        Me.lbLabel6.Size = New System.Drawing.Size(80, 16)
        Me.lbLabel6.TabIndex = 15
        Me.lbLabel6.Text = "Descripción:"
        '
        'lbLabel7
        '
        Me.lbLabel7.BackColor = System.Drawing.Color.Transparent
        Me.lbLabel7.Location = New System.Drawing.Point(16, 165)
        Me.lbLabel7.Name = "lbLabel7"
        Me.lbLabel7.Size = New System.Drawing.Size(80, 16)
        Me.lbLabel7.TabIndex = 16
        Me.lbLabel7.Text = "Saldo Inicial:"
        '
        'lbLabel8
        '
        Me.lbLabel8.BackColor = System.Drawing.Color.Transparent
        Me.lbLabel8.Location = New System.Drawing.Point(201, 166)
        Me.lbLabel8.Name = "lbLabel8"
        Me.lbLabel8.Size = New System.Drawing.Size(72, 16)
        Me.lbLabel8.TabIndex = 7
        Me.lbLabel8.Text = "Saldo Final:"
        '
        'ebSaldoIni
        '
        Me.ebSaldoIni.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoIni.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoIni.Location = New System.Drawing.Point(120, 160)
        Me.ebSaldoIni.Name = "ebSaldoIni"
        Me.ebSaldoIni.ReadOnly = True
        Me.ebSaldoIni.Size = New System.Drawing.Size(75, 21)
        Me.ebSaldoIni.TabIndex = 17
        Me.ebSaldoIni.TabStop = False
        Me.ebSaldoIni.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSaldoIni.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'InventarioMovimientosArticuloReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(760, 381)
        Me.Name = "InventarioMovimientosArticuloReportForm"
        Me.Text = "Reporte de Movimiento por Articulos"
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uigbParameters.ResumeLayout(False)
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Miembros"

    Private oIMArticulos As New InventarioMovimientoArticulosReporter
    Private oIMA As New InventarioMovimientoArticulosReporter

    Private oIMArticulosCorrida As New InventarioMovimientoArticulosReporter

    Private oIMACorrida As New InventarioMovimientoArticulosReporter


#End Region


    Private Sub InventarioMovimientosArticuloReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oReporter.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        oReport.CurrentReporter = oReporter

        ebAlmacen.Text = oAppContext.ApplicationConfiguration.Almacen
        uicbMes.SelectedValue = Date.Today.Month.ToString

    End Sub

    Protected Friend Overrides Sub ActionGenerate()

        oReporter.Almacen = ebAlmacen.Text
        oReporter.Mes = uicbMes.SelectedValue
        oReporter.Articulo = ebArticuloID.Text

        If (ebAlmacen.Text = String.Empty) Then

            MsgBox("Debe especificar un Código de Almacen", MsgBoxStyle.Exclamation)
            ebAlmacen.Focus()

            Exit Sub
        End If

        If (ebArticuloID.Text = String.Empty) Then

            MsgBox("Debe especificar un Código de Artículo", MsgBoxStyle.Exclamation)
            ebArticuloID.Focus()

            Exit Sub
        End If



        oReport.Generate()


        If oReport.Data Is Nothing Then

            MsgBox("Los datos proporcionados no generaron registros.", MsgBoxStyle.Exclamation)

            ebCorridaIni.Text = String.Empty
            ebCorridaFin.Text = String.Empty
            ebCorDescripcion.Text = String.Empty
            ebSaldoIni.Text = String.Empty
            ebSaldoFin.Text = String.Empty
            geResults.DataSource = Nothing

            ebAlmacen.Focus()

            Exit Sub

        End If

        geResults.SetDataBinding(oReport.Data, oReport.Data.Tables(0).TableName)
        'geResults.RetrieveStructure()

        oIMA = Nothing
        oIMA = oIMArticulos.Load(oReporter.Almacen, oReporter.Mes, oReporter.Articulo, oReporter.ConnectionString)

        'If oIMA Is Nothing Then

        '    MsgBox("No existe el Artículo en el almacen especificado", MsgBoxStyle.Exclamation)

        '    ebArticuloID.Focus()

        '    Exit Sub

        'End If

        ebSaldoIni.Text = oIMA.SaldoInicial
        ebSaldoFin.Text = oIMA.SaldoFinal

        oIMACorrida = Nothing
        oIMACorrida = oIMArticulosCorrida.LoadCorrida(oReporter.Articulo, oReporter.ConnectionString)

        ebCorridaIni.Text = oIMACorrida.CorridaIni
        ebCorridaFin.Text = oIMACorrida.CorridaFin
        ebCorDescripcion.Text = oIMACorrida.CorDescripcion

    End Sub
  


    Protected Friend Overrides Sub ActionPreview()

        Dim oARReporte As New InventarioMovimientoArticuloReport(Me)
        Dim oReportViewer As New ReportViewerForm

        If (oReport.Data Is Nothing) Then
            MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
            Exit Sub
        End If

        oARReporte.DataSource = oReport.Data.Tables(0)
        oARReporte.Document.Name = "Reporte de Inventario Movimientos por Artículo"
        oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

    End Sub

    Private Sub ebAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebAlmacen.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            Dim oOpenRecordDlg As New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New CatalogoAlmacenesOpenRecordDialogView


            oOpenRecordDlg.ShowDialog()


            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                ebAlmacen.Text = oOpenRecordDlg.Record.Item("CodAlmacen")

            End If

        End If
    End Sub

    Private Sub ebAlmacen_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebAlmacen.ButtonClick
        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New CatalogoAlmacenesOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()


        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            ebAlmacen.Text = oOpenRecordDlg.Record.Item("CodAlmacen")

        End If
    End Sub

    Private Sub ebAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebAlmacen.Click

    End Sub

    Private Sub ebSaldoIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebSaldoIni.Click

    End Sub

    Private Sub ebCorridaFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebCorridaFin.Click

    End Sub

    Private Sub ebSaldoFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebSaldoFin.Click

    End Sub

    Private Sub geResults_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles geResults.FormattingRow

    End Sub

    Private Sub ebArticuloID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebArticuloID.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            Dim oOpenRecordDlg As New OpenRecordDialog2
            oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

            oOpenRecordDlg.ShowDialog()


            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then



                ebArticuloID.Text = oOpenRecordDlg.Record.Item("Código")

            End If

        End If
    End Sub

    Private Sub ebArticuloID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebArticuloID.ButtonClick


        Dim oOpenRecordDlg As New OpenRecordDialog2
        oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

        oOpenRecordDlg.ShowDialog()


        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then



            ebArticuloID.Text = oOpenRecordDlg.Record.Item("Código")

        End If


    End Sub

    Private Sub InventarioMovimientosArticuloReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class
