Imports DportenisPro.DPTienda.Reports.Inventario
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class InventarioNormalReportForm
    Inherits DPTienda.ReportBaseForm

    Dim oReport As New InventarioReport
    Dim oReporter As New InventarioNormalReporter

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebAlmacen As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents uicbMes As Janus.Windows.EditControls.UIComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventarioNormalReportForm))
        Dim UiComboBoxItem13 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem14 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem15 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem16 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem17 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem18 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem19 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem20 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem21 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem22 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem23 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem24 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebAlmacen = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.uicbMes = New Janus.Windows.EditControls.UIComboBox()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbParameters.SuspendLayout()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateReport.Location = New System.Drawing.Point(272, 40)
        Me.btnGenerateReport.TabIndex = 4
        Me.btnGenerateReport.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'geResults
        '
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.geResults.DesignTimeLayout = GridEXLayout2
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.geResults.Size = New System.Drawing.Size(504, 125)
        Me.geResults.TabStop = False
        '
        'uigbParameters
        '
        Me.uigbParameters.Controls.Add(Me.uicbMes)
        Me.uigbParameters.Controls.Add(Me.ebAlmacen)
        Me.uigbParameters.Controls.Add(Me.Label2)
        Me.uigbParameters.Controls.Add(Me.Label1)
        Me.uigbParameters.Location = New System.Drawing.Point(0, 50)
        Me.uigbParameters.Size = New System.Drawing.Size(512, 70)
        Me.uigbParameters.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        Me.uigbParameters.Controls.SetChildIndex(Me.Label1, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.Label2, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebAlmacen, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.uicbMes, 0)
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
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Almacen:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mes:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.ebAlmacen.TabIndex = 1
        Me.ebAlmacen.Text = "000"
        Me.ebAlmacen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uicbMes
        '
        Me.uicbMes.AutoSize = False
        Me.uicbMes.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        UiComboBoxItem13.FormatStyle.Alpha = 0
        UiComboBoxItem13.IsSeparator = False
        UiComboBoxItem13.Text = "Enero"
        UiComboBoxItem13.Value = "1"
        UiComboBoxItem14.FormatStyle.Alpha = 0
        UiComboBoxItem14.IsSeparator = False
        UiComboBoxItem14.Text = "Febrero"
        UiComboBoxItem14.Value = "2"
        UiComboBoxItem15.FormatStyle.Alpha = 0
        UiComboBoxItem15.IsSeparator = False
        UiComboBoxItem15.Text = "Marzo"
        UiComboBoxItem15.Value = "3"
        UiComboBoxItem16.FormatStyle.Alpha = 0
        UiComboBoxItem16.IsSeparator = False
        UiComboBoxItem16.Text = "Abril"
        UiComboBoxItem16.Value = "4"
        UiComboBoxItem17.FormatStyle.Alpha = 0
        UiComboBoxItem17.IsSeparator = False
        UiComboBoxItem17.Text = "Mayo"
        UiComboBoxItem17.Value = "5"
        UiComboBoxItem18.FormatStyle.Alpha = 0
        UiComboBoxItem18.IsSeparator = False
        UiComboBoxItem18.Text = "Junio"
        UiComboBoxItem18.Value = "6"
        UiComboBoxItem19.FormatStyle.Alpha = 0
        UiComboBoxItem19.IsSeparator = False
        UiComboBoxItem19.Text = "Julio"
        UiComboBoxItem19.Value = "7"
        UiComboBoxItem20.FormatStyle.Alpha = 0
        UiComboBoxItem20.IsSeparator = False
        UiComboBoxItem20.Text = "Agosto"
        UiComboBoxItem20.Value = "8"
        UiComboBoxItem21.FormatStyle.Alpha = 0
        UiComboBoxItem21.IsSeparator = False
        UiComboBoxItem21.Text = "Septiembre"
        UiComboBoxItem21.Value = "9"
        UiComboBoxItem22.FormatStyle.Alpha = 0
        UiComboBoxItem22.IsSeparator = False
        UiComboBoxItem22.Text = "Octubre"
        UiComboBoxItem22.Value = "10"
        UiComboBoxItem23.FormatStyle.Alpha = 0
        UiComboBoxItem23.IsSeparator = False
        UiComboBoxItem23.Text = "Noviembre"
        UiComboBoxItem23.Value = "11"
        UiComboBoxItem24.FormatStyle.Alpha = 0
        UiComboBoxItem24.IsSeparator = False
        UiComboBoxItem24.Text = "Diciembre"
        UiComboBoxItem24.Value = "12"
        Me.uicbMes.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem13, UiComboBoxItem14, UiComboBoxItem15, UiComboBoxItem16, UiComboBoxItem17, UiComboBoxItem18, UiComboBoxItem19, UiComboBoxItem20, UiComboBoxItem21, UiComboBoxItem22, UiComboBoxItem23, UiComboBoxItem24})
        Me.uicbMes.Location = New System.Drawing.Point(88, 40)
        Me.uicbMes.Name = "uicbMes"
        Me.uicbMes.Size = New System.Drawing.Size(176, 24)
        Me.uicbMes.TabIndex = 3
        Me.uicbMes.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'InventarioNormalReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(512, 253)
        Me.KeyPreview = True
        Me.Name = "InventarioNormalReportForm"
        Me.Text = "Reporte de Inventario"
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
        uicbMes.SelectedValue = Date.Today.Month.ToString

    End Sub

    Protected Friend Overrides Sub ActionGenerate()

        oReporter.Almacen = ebAlmacen.Text
        oReporter.Mes = uicbMes.SelectedValue

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

        'Dim oARReporte As New InventarioNormalReport
        'Dim oReportViewer As New ReportViewerForm

        'If (oReport.Data Is Nothing) Then
        '    MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
        '    Exit Sub
        'End If

        'oARReporte.DataSource = oReport.Data.Tables(0)
        'oARReporte.Document.Name = "Reporte de Inventario"
        'oARReporte.Run()

        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

        If (oReport.Data Is Nothing) Then
            MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
            Exit Sub
        End If

        Dim oARReporte As New rptReportedeInventariosPorCodigo(oReport.Data, GetAlmacen(), uicbMes.Text)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Inventario"
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

    Private Sub InventarioNormalReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")

        End Select
    End Sub

    Private Function GetAlmacen() As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim strAlmacen As String = ebAlmacen.Text
        Dim AlmacenDescripcion As String = String.Empty
        oAlmacen = oAlmacenMgr.Create
        oAlmacenMgr.LoadInto(strAlmacen, oAlmacen)

        AlmacenDescripcion = strAlmacen & " " & oAlmacen.Descripcion

        oAlmacen = Nothing
        oAlmacenMgr = Nothing

        Return AlmacenDescripcion

    End Function

End Class
