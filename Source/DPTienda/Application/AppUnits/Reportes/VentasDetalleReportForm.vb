Imports DportenisPro.DPTienda.Reports.Ventas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class VentasDetalleReportForm
    Inherits DPTienda.GridReportBaseForm

    Dim oReport As New VentasReport
    Dim oReporter As New VentasDetalleReporter(oAppContext)

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
    Friend WithEvents ebCodigoCaja As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel3 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents cComboFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents CComboIni As Janus.Windows.CalendarCombo.CalendarCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VentasDetalleReportForm))
        Me.ebAlmacen = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodigoCaja = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel3 = New System.Windows.Forms.Label()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.cComboFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.CComboIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbParameters.SuspendLayout()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Location = New System.Drawing.Point(432, 70)
        Me.btnGenerateReport.TabIndex = 5
        '
        'geResults
        '
        Me.geResults.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.geResults.ControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.geResults.DesignTimeLayout = GridEXLayout1
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.geResults.GroupByBoxVisible = False
        Me.geResults.Size = New System.Drawing.Size(504, 133)
        Me.geResults.TabStop = False
        '
        'uigbParameters
        '
        Me.uigbParameters.Controls.Add(Me.CComboIni)
        Me.uigbParameters.Controls.Add(Me.cComboFin)
        Me.uigbParameters.Controls.Add(Me.lblLabel4)
        Me.uigbParameters.Controls.Add(Me.lblLabel3)
        Me.uigbParameters.Controls.Add(Me.lblLabel1)
        Me.uigbParameters.Controls.Add(Me.ebCodigoCaja)
        Me.uigbParameters.Controls.Add(Me.ebAlmacen)
        Me.uigbParameters.Location = New System.Drawing.Point(0, 50)
        Me.uigbParameters.Size = New System.Drawing.Size(512, 102)
        Me.uigbParameters.Controls.SetChildIndex(Me.btnGenerateReport, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebAlmacen, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebCodigoCaja, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lblLabel1, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lblLabel3, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lblLabel4, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.cComboFin, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.CComboIni, 0)
        '
        'uicmEnvironment
        '
        '
        '
        '
        Me.uicmEnvironment.EditContextMenu.Key = ""
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
        Me.ebAlmacen.Size = New System.Drawing.Size(112, 22)
        Me.ebAlmacen.TabIndex = 1
        Me.ebAlmacen.Text = "000"
        Me.ebAlmacen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigoCaja
        '
        Me.ebCodigoCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoCaja.ButtonImage = CType(resources.GetObject("ebCodigoCaja.ButtonImage"), System.Drawing.Image)
        Me.ebCodigoCaja.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigoCaja.Location = New System.Drawing.Point(328, 8)
        Me.ebCodigoCaja.MaxLength = 3
        Me.ebCodigoCaja.Name = "ebCodigoCaja"
        Me.ebCodigoCaja.Size = New System.Drawing.Size(112, 22)
        Me.ebCodigoCaja.TabIndex = 2
        Me.ebCodigoCaja.Text = "01"
        Me.ebCodigoCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Location = New System.Drawing.Point(9, 16)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(104, 17)
        Me.lblLabel1.TabIndex = 8
        Me.lblLabel1.Text = "Código Almacen:"
        '
        'lblLabel3
        '
        Me.lblLabel3.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel3.Location = New System.Drawing.Point(240, 16)
        Me.lblLabel3.Name = "lblLabel3"
        Me.lblLabel3.Size = New System.Drawing.Size(80, 16)
        Me.lblLabel3.TabIndex = 10
        Me.lblLabel3.Text = "Código Caja:"
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Location = New System.Drawing.Point(248, 48)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(80, 16)
        Me.lblLabel4.TabIndex = 11
        Me.lblLabel4.Text = "Fecha Final:"
        '
        'cComboFin
        '
        '
        '
        '
        Me.cComboFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard
        Me.cComboFin.Location = New System.Drawing.Point(328, 44)
        Me.cComboFin.Name = "cComboFin"
        Me.cComboFin.Size = New System.Drawing.Size(112, 21)
        Me.cComboFin.TabIndex = 4
        '
        'CComboIni
        '
        '
        '
        '
        Me.CComboIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard
        Me.CComboIni.Location = New System.Drawing.Point(120, 44)
        Me.CComboIni.Name = "CComboIni"
        Me.CComboIni.Size = New System.Drawing.Size(112, 21)
        Me.CComboIni.TabIndex = 3
        '
        'VentasDetalleReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(512, 293)
        Me.Name = "VentasDetalleReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ventas en Detalle"
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uigbParameters.ResumeLayout(False)
        Me.uigbParameters.PerformLayout()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub VentasDetalleReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oReporter.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        oReport.CurrentReporter = oReporter

        ebAlmacen.Text = oAppContext.ApplicationConfiguration.Almacen


    End Sub

    Protected Friend Overrides Sub ActionGenerate()

        oReporter.FechaIni = CComboIni.Text
        oReporter.FechaFin = cComboFin.Text
        oReporter.CodCaja = ebCodigoCaja.Text
        oReporter.Almacen = ebAlmacen.Text

        oReport.Generate()
        'If (oReport.Data Is Nothing) Then
        '    MsgBox("Los datos proporcionados no produjeron resultados.", MsgBoxStyle.Exclamation)
        '    geResults.SetDataBinding(oReport.Data, oReport.Data.Tables(0).TableName)
        '    ebAlmacen.Focus()
        '    Exit Sub

        'End If
        '------------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 19.07.2013: Se pidio que se mostraran los folios del DPPRO en el reporte, por eso se comento este bloque de codigo que los igualaba a
        'cero cuando eran facturas de fechas posteriores a la de la configuracion FechaAutoF
        '------------------------------------------------------------------------------------------------------------------------------------------------
        'Dim dvFechaAutoF As New DataView(oReport.Data.Tables(0), "Fecha >='" & oConfigCierreFI.FechaAutoF & "'", "Folio", DataViewRowState.CurrentRows)
        'For Each oView As DataRowView In dvFechaAutoF
        '    oView.Row.Item(0) = 0
        'Next
        'oReport.Data.Tables(0).AcceptChanges()

        geResults.SetDataBinding(oReport.Data, oReport.Data.Tables(0).TableName)
        ' geResults.RetrieveStructure()


    End Sub

    Protected Friend Overrides Sub ActionPreview()

        Dim oARReporte As New VentasDetalleReport
        Dim oReportViewer As New ReportViewerForm

        If (oReport.Data Is Nothing) Then
            MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
            Exit Sub
        End If

        oARReporte.DataSource = oReport.Data.Tables(0)
        oARReporte.Document.Name = "Reporte de Ventas en Detalle"
        oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

    End Sub


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

    Protected Friend Overrides Sub ActionExport()

        If (oReport.Data Is Nothing) Then
            MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
            Exit Sub
        End If

        'ExportaReportesVariosInventario()
        ExportReportesTotales()
    End Sub


    Private Sub ExportReportesTotales()

        Dim SaveDialog = New SaveFileDialog
        Dim strRuta As String = String.Empty

        Dim xlapp
        Dim wbxl
        Dim wsxl

        Dim intRow As Integer = 0

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
        wsxl.Name = "Reporte Vtas Detalle"

        '****************************************
        'HOJA DE CALCULO VENTAS TOTALES
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE VENTAS DETALLES"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:J1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:J1").BorderAround(, 2, 0, )
        wsxl.Range("A1:J1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 1).Value = "Fecha : " & Format(Date.Now, "Long Date")
        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True
        wsxl.Range("A2:J2").Merge()

        wsxl.Cells(3, 9).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(3, 9).Font.Size = 12
        wsxl.Cells(3, 9).Font.Bold = True
        wsxl.Range("A3:J3").Merge()
        wsxl.Range("A3:J3").HorizontalAlignment = 3

        'Encabezado
        wsxl.Cells(5, 1).Value = "Folio"
        wsxl.Cells(5, 2).Value = "Referencia"
        wsxl.Cells(5, 3).Value = "Artículo"
        wsxl.Cells(5, 4).Value = "Descripción"
        wsxl.Cells(5, 5).Value = "Cantidad"
        wsxl.Cells(5, 6).Value = "Talla"
        wsxl.Cells(5, 7).Value = "Importe"
        wsxl.Cells(5, 8).Value = "Total"
        wsxl.Cells(5, 9).Value = "Descuento"
        wsxl.Cells(5, 10).Value = "Cant. Descuento"

        wsxl.Range("A" & CStr(5 + intRow) & ":J" & CStr(5 + intRow)).Font.Bold = True
        wsxl.Range("A" & CStr(5 + intRow) & ":J" & CStr(5 + intRow)).HorizontalAlignment = 3
        wsxl.Range("A" & CStr(5 + intRow) & ":J" & CStr(5 + intRow)).Font.Size = 10
        wsxl.Range("A" & CStr(5 + intRow) & ":J" & CStr(5 + intRow)).Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A" & CStr(5 + intRow) & ":J" & CStr(5 + intRow)).BorderAround(, 2, 0, )

        intRow += 1
        Dim dat As Date = CComboIni.Value
        Dim dtReporte As DataTable = oReport.Data.Tables(0).Copy()

        For Each row As DataRow In dtReporte.Rows
            If (row!Folio <> "") Then

                wsxl.Cells(5 + intRow, 1).Value = CStr(row("Folio"))
                wsxl.Cells(5 + intRow, 2).Value = "'" & row("Referencia")
                wsxl.Cells(5 + intRow, 3).Value = "'" & CStr(row("ArticuloID"))
                wsxl.Cells(5 + intRow, 4).Value = CStr(row("Descripcion"))
                wsxl.Cells(5 + intRow, 5).Value = CStr(row("Cantidad"))
                wsxl.Cells(5 + intRow, 6).Value = CStr(row("Talla"))
                wsxl.Cells(5 + intRow, 7).Value = Math.Abs(row!Importe)
                wsxl.Cells(5 + intRow, 8).Value = Math.Abs(row!Total)
                wsxl.Cells(5 + intRow, 9).Value = row!Descuento
                wsxl.Cells(5 + intRow, 10).Value = Math.Abs(row!CantDescuento)
                intRow += 1
            End If
        Next
        'wsxl.Range("A5:M5").Columns.AutoFit()
        wsxl.Range("A6:L6").ColumnWidth = 15
        wsxl.Range("B6:D6").ColumnWidth = 25
        wsxl.PageSetup.FitToPagesWide = 1
        wsxl.PageSetup.FitToPagesTall = 1

        Me.Cursor = Cursors.Default

        'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
        SaveDialog.DefaultExt = "*.xls"
        SaveDialog.Filter = "Libro de Microsoft Office Excel (*.xls)|*.xls"
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

    Private Sub ebCodigoCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigoCaja.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Dim oOpenRecordDlg As New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New CatalogoCajaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()


            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                ebCodigoCaja.Text = oOpenRecordDlg.Record.Item("CodCaja")

            End If

        End If
    End Sub

    Private Sub ebCodigoCaja_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigoCaja.ButtonClick

        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New CatalogoCajaOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()


        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            ebCodigoCaja.Text = oOpenRecordDlg.Record.Item("CodCaja")

        End If

    End Sub

    Private Sub uigbParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uigbParameters.Click

    End Sub

    Private Sub btnButton1_Click1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim LayoutStream As System.IO.FileStream

        LayoutStream = New System.IO.FileStream("C:\VentasDetalle.gxl", System.IO.FileMode.OpenOrCreate)

        geResults.SaveLayoutFile(LayoutStream)

        LayoutStream.Close()
    End Sub

    Private Sub VentasDetalleReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub


    Private Sub btnGenerateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateReport.Click

    End Sub

    Private Sub uicmEnvironment_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles uicmEnvironment.CommandClick

    End Sub
End Class
