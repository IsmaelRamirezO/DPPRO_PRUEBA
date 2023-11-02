Imports DportenisPro.DPTienda.Reports.Inventario

Public Class InventarioApartadoReportForm
    Inherits DPTienda.ReportBaseForm

    Dim oReport As New InventarioReport
    Dim oReporter As New InventarioApartadoReporter

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
    Friend WithEvents ebAlmacen As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventarioApartadoReportForm))
        Me.ebAlmacen = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbParameters.SuspendLayout()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateReport.Location = New System.Drawing.Point(224, 8)
        Me.btnGenerateReport.TabIndex = 1
        Me.btnGenerateReport.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'geResults
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.geResults.DesignTimeLayout = GridEXLayout1
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.geResults.Size = New System.Drawing.Size(504, 157)
        Me.geResults.TabStop = False
        '
        'uigbParameters
        '
        Me.uigbParameters.Controls.Add(Me.ebAlmacen)
        Me.uigbParameters.Controls.Add(Me.Label1)
        Me.uigbParameters.Location = New System.Drawing.Point(0, 50)
        Me.uigbParameters.Size = New System.Drawing.Size(512, 38)
        Me.uigbParameters.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        Me.uigbParameters.Controls.SetChildIndex(Me.Label1, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebAlmacen, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.btnGenerateReport, 0)
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
        Me.ebAlmacen.Location = New System.Drawing.Point(88, 8)
        Me.ebAlmacen.MaxLength = 3
        Me.ebAlmacen.Name = "ebAlmacen"
        Me.ebAlmacen.Size = New System.Drawing.Size(128, 24)
        Me.ebAlmacen.TabIndex = 0
        Me.ebAlmacen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Almacen:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InventarioApartadoReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(512, 253)
        Me.KeyPreview = True
        Me.Name = "InventarioApartadoReportForm"
        Me.Text = "Reporte de Apartados en Inventario"
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uigbParameters.ResumeLayout(False)
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InventarioApartadoReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oReporter.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        oReport.CurrentReporter = oReporter

        ebAlmacen.Text = oAppContext.ApplicationConfiguration.Almacen

    End Sub

    Protected Friend Overrides Sub ActionGenerate()

        oReporter.Almacen = ebAlmacen.Text

        oReport.Generate()

        If oReport.Data Is Nothing Then

            MsgBox("Los datos proporcionados no generaron registros.", MsgBoxStyle.Exclamation)

            geResults.DataSource = Nothing
            ebAlmacen.Focus()


            Exit Sub
        End If
        geResults.SetDataBinding(oReport.Data, oReport.Data.Tables(0).TableName)

    End Sub

    Protected Friend Overrides Sub ActionPreview()

        Dim oARReporte As New InventarioApartadoReport
        Dim oReportViewer As New ReportViewerForm

        If (oReport.Data Is Nothing) Then
            MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
            Exit Sub
        End If

        oARReporte.DataSource = oReport.Data.Tables(0)
        oARReporte.Document.Name = "Reporte de Inventario Artículos Apartados"
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





    Private Sub InventarioApartadoReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
