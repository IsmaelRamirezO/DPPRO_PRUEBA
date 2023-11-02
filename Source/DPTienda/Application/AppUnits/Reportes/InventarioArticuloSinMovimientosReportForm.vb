Imports DportenisPro.DPTienda.Reports.Inventario

Public Class InventarioArticuloSinMovimientosReportForm
    Inherits DPTienda.ReportBaseForm

    Dim oReport As New InventarioReport
    Dim oReporter As New InventarioArticulosSinMovimientosReporter


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
    Friend WithEvents ebAlmacen As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents ebDias As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventarioArticuloSinMovimientosReportForm))
        Me.ebAlmacen = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.ebDias = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbParameters.SuspendLayout()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.TabIndex = 2
        Me.btnGenerateReport.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'geResults
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.geResults.DesignTimeLayout = GridEXLayout1
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.ExpandableGroups = Janus.Windows.GridEX.InheritableBoolean.[Default]
        Me.geResults.GroupRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.geResults.GroupTotalRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.geResults.GroupTotalRowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque
        Me.geResults.GroupTotalRowFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.geResults.GroupTotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.geResults.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.geResults.Size = New System.Drawing.Size(504, 131)
        Me.geResults.TabStop = False
        Me.geResults.ThemedAreas = CType((Janus.Windows.GridEX.ThemedArea.ScrollBars Or Janus.Windows.GridEX.ThemedArea.Gridlines), Janus.Windows.GridEX.ThemedArea)
        '
        'uigbParameters
        '
        Me.uigbParameters.Controls.Add(Me.ebDias)
        Me.uigbParameters.Controls.Add(Me.lblLabel2)
        Me.uigbParameters.Controls.Add(Me.lblLabel1)
        Me.uigbParameters.Controls.Add(Me.ebAlmacen)
        Me.uigbParameters.Location = New System.Drawing.Point(0, 50)
        Me.uigbParameters.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        Me.uigbParameters.Controls.SetChildIndex(Me.btnGenerateReport, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebAlmacen, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lblLabel1, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lblLabel2, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebDias, 0)
        '
        'uicmEnvironment
        '
        '
        '
        '
        Me.uicmEnvironment.EditContextMenu.Key = ""
        Me.uicmEnvironment.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebAlmacen
        '
        Me.ebAlmacen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAlmacen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAlmacen.ButtonImage = CType(resources.GetObject("ebAlmacen.ButtonImage"), System.Drawing.Image)
        Me.ebAlmacen.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebAlmacen.Location = New System.Drawing.Point(136, 8)
        Me.ebAlmacen.MaxLength = 3
        Me.ebAlmacen.Name = "ebAlmacen"
        Me.ebAlmacen.Size = New System.Drawing.Size(128, 24)
        Me.ebAlmacen.TabIndex = 0
        Me.ebAlmacen.Text = "000"
        Me.ebAlmacen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Location = New System.Drawing.Point(16, 8)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(72, 23)
        Me.lblLabel1.TabIndex = 3
        Me.lblLabel1.Text = "Almacen:"
        Me.lblLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Location = New System.Drawing.Point(16, 40)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(108, 23)
        Me.lblLabel2.TabIndex = 4
        Me.lblLabel2.Text = "Número de Dias:"
        Me.lblLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebDias
        '
        Me.ebDias.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDias.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDias.Location = New System.Drawing.Point(136, 40)
        Me.ebDias.MaxLength = 3
        Me.ebDias.Name = "ebDias"
        Me.ebDias.Size = New System.Drawing.Size(75, 21)
        Me.ebDias.TabIndex = 1
        Me.ebDias.Text = "1"
        Me.ebDias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDias.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebDias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'InventarioArticuloSinMovimientosReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(512, 253)
        Me.Name = "InventarioArticuloSinMovimientosReportForm"
        Me.Text = "Reporte Inventario de Articulo Sin Movimientos"
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uigbParameters.ResumeLayout(False)
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub InventarioNormalReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oReporter.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        oReport.CurrentReporter = oReporter

        ebAlmacen.Text = oAppContext.ApplicationConfiguration.Almacen


    End Sub

    Protected Friend Overrides Sub ActionGenerate()

        oReporter.Almacen = ebAlmacen.Text
        oReporter.Dias() = ebdias.Text

        oReport.Generate()

        If oReport.Data Is Nothing Then
            MessageBox.Show("La consulta no Arrojo Resultados", "Sin Resulatdos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            geResults.SetDataBinding(oReport.Data, oReport.Data.Tables(0).TableName)
        End If


    End Sub

    Protected Friend Overrides Sub ActionPreview()

        Dim oARReporte As New InventarioArticuloSinMovimientosReport
        Dim oReportViewer As New ReportViewerForm

        If (oReport.Data Is Nothing) Then
            MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
            Exit Sub
        End If

        oARReporte.DataSource = oReport.Data.Tables(0)
        oARReporte.Document.Name = "Reporte de Inventario Negativo"
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




End Class


