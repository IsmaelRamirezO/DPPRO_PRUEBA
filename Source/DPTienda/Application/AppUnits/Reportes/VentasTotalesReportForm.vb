Imports DportenisPro.DPTienda.Reports.Ventas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports System.Data.SqlClient
Imports DataDynamics.ActiveReports.Export.Xls

Public Class VentasTotalesReportForm
    Inherits DPTienda.GridReportBaseForm

    Dim oReport As New VentasReport
    Dim oReporter As New VentasTotalesReporter(oAppContext)
    Dim dsReporteImpre As New DataSet
    Friend WithEvents btnGeneraReporte As Janus.Windows.EditControls.UIButton
    Dim dsPreviewReport As New DataSet


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
    Friend WithEvents ebCodigoCaja As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel3 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents cComboFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents CComboIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebAlmacen As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbCajas As Janus.Windows.EditControls.UIComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VentasTotalesReportForm))
        Me.ebCodigoCaja = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel3 = New System.Windows.Forms.Label()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.cComboFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.CComboIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ebAlmacen = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.cbCajas = New Janus.Windows.EditControls.UIComboBox()
        Me.btnGeneraReporte = New Janus.Windows.EditControls.UIButton()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbParameters.SuspendLayout()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Location = New System.Drawing.Point(6984, 45)
        Me.btnGenerateReport.TabIndex = 4
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
        Me.geResults.Size = New System.Drawing.Size(784, 254)
        Me.geResults.TabStop = False
        Me.geResults.TreeLines = False
        '
        'uigbParameters
        '
        Me.uigbParameters.Controls.Add(Me.btnGeneraReporte)
        Me.uigbParameters.Controls.Add(Me.cbCajas)
        Me.uigbParameters.Controls.Add(Me.ebAlmacen)
        Me.uigbParameters.Controls.Add(Me.CComboIni)
        Me.uigbParameters.Controls.Add(Me.cComboFin)
        Me.uigbParameters.Controls.Add(Me.lblLabel4)
        Me.uigbParameters.Controls.Add(Me.lblLabel3)
        Me.uigbParameters.Controls.Add(Me.lblLabel2)
        Me.uigbParameters.Controls.Add(Me.lblLabel1)
        Me.uigbParameters.Controls.Add(Me.ebCodigoCaja)
        Me.uigbParameters.Location = New System.Drawing.Point(0, 50)
        Me.uigbParameters.Size = New System.Drawing.Size(792, 78)
        Me.uigbParameters.Controls.SetChildIndex(Me.btnGenerateReport, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebCodigoCaja, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lblLabel1, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lblLabel2, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lblLabel3, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.lblLabel4, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.cComboFin, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.CComboIni, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ebAlmacen, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.cbCajas, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.btnGeneraReporte, 0)
        '
        'uicmEnvironment
        '
        '
        '
        '
        Me.uicmEnvironment.EditContextMenu.Key = ""
        '
        'ebCodigoCaja
        '
        Me.ebCodigoCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoCaja.ButtonImage = CType(resources.GetObject("ebCodigoCaja.ButtonImage"), System.Drawing.Image)
        Me.ebCodigoCaja.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigoCaja.Location = New System.Drawing.Point(536, 8)
        Me.ebCodigoCaja.MaxLength = 3
        Me.ebCodigoCaja.Name = "ebCodigoCaja"
        Me.ebCodigoCaja.Size = New System.Drawing.Size(112, 22)
        Me.ebCodigoCaja.TabIndex = 1
        Me.ebCodigoCaja.Text = "01"
        Me.ebCodigoCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoCaja.Visible = False
        Me.ebCodigoCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Location = New System.Drawing.Point(8, 16)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(104, 17)
        Me.lblLabel1.TabIndex = 7
        Me.lblLabel1.Text = "Código Almacen:"
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Location = New System.Drawing.Point(29, 48)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(82, 16)
        Me.lblLabel2.TabIndex = 8
        Me.lblLabel2.Text = "Fecha Inicial:"
        '
        'lblLabel3
        '
        Me.lblLabel3.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel3.Location = New System.Drawing.Point(230, 16)
        Me.lblLabel3.Name = "lblLabel3"
        Me.lblLabel3.Size = New System.Drawing.Size(80, 16)
        Me.lblLabel3.TabIndex = 9
        Me.lblLabel3.Text = "Código Caja:"
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Location = New System.Drawing.Point(237, 48)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(80, 16)
        Me.lblLabel4.TabIndex = 10
        Me.lblLabel4.Text = "Fecha Final:"
        '
        'cComboFin
        '
        '
        '
        '
        Me.cComboFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cComboFin.Location = New System.Drawing.Point(320, 48)
        Me.cComboFin.Name = "cComboFin"
        Me.cComboFin.Size = New System.Drawing.Size(112, 21)
        Me.cComboFin.TabIndex = 3
        Me.cComboFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'CComboIni
        '
        '
        '
        '
        Me.CComboIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.CComboIni.Location = New System.Drawing.Point(112, 47)
        Me.CComboIni.Name = "CComboIni"
        Me.CComboIni.Size = New System.Drawing.Size(112, 21)
        Me.CComboIni.TabIndex = 2
        Me.CComboIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ebAlmacen
        '
        Me.ebAlmacen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAlmacen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAlmacen.ButtonImage = CType(resources.GetObject("ebAlmacen.ButtonImage"), System.Drawing.Image)
        Me.ebAlmacen.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebAlmacen.Location = New System.Drawing.Point(112, 8)
        Me.ebAlmacen.MaxLength = 3
        Me.ebAlmacen.Name = "ebAlmacen"
        Me.ebAlmacen.Size = New System.Drawing.Size(112, 22)
        Me.ebAlmacen.TabIndex = 0
        Me.ebAlmacen.Text = "01"
        Me.ebAlmacen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cbCajas
        '
        Me.cbCajas.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbCajas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCajas.Location = New System.Drawing.Point(320, 8)
        Me.cbCajas.Name = "cbCajas"
        Me.cbCajas.Size = New System.Drawing.Size(112, 22)
        Me.cbCajas.TabIndex = 11
        Me.cbCajas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnGeneraReporte
        '
        Me.btnGeneraReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGeneraReporte.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnGeneraReporte.Location = New System.Drawing.Point(628, 8)
        Me.btnGeneraReporte.Name = "btnGeneraReporte"
        Me.btnGeneraReporte.Size = New System.Drawing.Size(160, 40)
        Me.btnGeneraReporte.TabIndex = 12
        Me.btnGeneraReporte.Text = "&Generar"
        Me.btnGeneraReporte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'VentasTotalesReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(792, 390)
        Me.Name = "VentasTotalesReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ventas en Total"
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uigbParameters.ResumeLayout(False)
        Me.uigbParameters.PerformLayout()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InventarioNormalReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oReporter.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        oReport.CurrentReporter = oReporter

        ebAlmacen.Text = oAppContext.ApplicationConfiguration.Almacen
        FillCaja()

    End Sub

    Private Sub FillCaja()

        Dim oCajaMgr As New CatalogoCajaManager(oAppContext)
        Dim dtCaja As New DataTable("Cajas")
        Dim oRow As DataRow
        dtCaja = oCajaMgr.GetAll(True).Tables(0)
        For Each oRow In dtCaja.Rows
            cbCajas.Items.Add(oRow!CodCaja)
        Next
        cbCajas.Items.Add("Todas")
        oRow = Nothing
        dtCaja.Dispose()
        dtCaja = Nothing

        oCajaMgr = Nothing

        If oAppContext.ApplicationConfiguration.Almacen = "053" Then
            cbCajas.SelectedIndex = 0
        Else
            cbCajas.SelectedIndex = Me.cbCajas.Items.Count - 1
        End If

    End Sub

    'Protected Friend Overrides Sub ActionGenerate()
    '    oReporter.FechaIni = CComboIni.Text
    '    oReporter.FechaFin = cComboFin.Text
    '    If UCase(cbCajas.Text) = "TODAS" Then
    '        oReporter.CodCaja = "00" 'ebCodigoCaja.Text
    '    Else
    '        oReporter.CodCaja = cbCajas.Text 'ebCodigoCaja.Text
    '    End If

    '    oReporter.Almacen = ebAlmacen.Text

    '    dsReporteImpre = oReport.GenerateNew
    '    dsPreviewReport = oReport.GenerateNewPreview
    '    'oReport.Generate()                

    '    Dim dvFechaAutoF1 As New DataView(dsPreviewReport.Tables(0), "Fecha >='" & oConfigCierreFI.FechaAutoF & "'", "Folio", DataViewRowState.CurrentRows)
    '    For Each oView As DataRowView In dvFechaAutoF1
    '        oView.Row.Item(1) = 0
    '    Next
    '    dsPreviewReport.Tables(0).AcceptChanges()

    '    oReport.GenerateFolioSAP()

    '    Dim dvFechaAutoF As New DataView(oReport.Data.Tables(0), "Fecha >='" & oConfigCierreFI.FechaAutoF & "'", "Folio", DataViewRowState.CurrentRows)
    '    For Each oView As DataRowView In dvFechaAutoF
    '        oView.Row.Item(0) = 0
    '    Next
    '    oReport.Data.Tables(0).AcceptChanges()
    '    geResults.SetDataBinding(oReport.Data, oReport.Data.Tables(0).TableName)



    'End Sub

    Private Sub ActionGenerate()
        oReporter.FechaIni = CComboIni.Text
        oReporter.FechaFin = cComboFin.Text
        If UCase(cbCajas.Text) = "TODAS" Then
            oReporter.CodCaja = "00" 'ebCodigoCaja.Text
        Else
            oReporter.CodCaja = cbCajas.Text 'ebCodigoCaja.Text
        End If

        oReporter.Almacen = ebAlmacen.Text

        dsReporteImpre = oReport.GenerateNew
        dsPreviewReport = oReport.GenerateNewPreview

        'oReport.Generate()                

        ' COMENTADO MLVARGAS
        'Dim dvFechaAutoF1 As New DataView(dsPreviewReport.Tables(0), "Fecha >='" & oConfigCierreFI.FechaAutoF & "'", "Folio", DataViewRowState.CurrentRows)
        'For Each oView As DataRowView In dvFechaAutoF1
        '    oView.Row.Item(1) = 0
        'Next
        'dsPreviewReport.Tables(0).AcceptChanges()

        oReport.GenerateFolioSAP()

        Dim dvFechaAutoF As New DataView(oReport.Data.Tables(0), "Fecha >='" & oConfigCierreFI.FechaAutoF & "'", "Folio", DataViewRowState.CurrentRows)
        'For Each oView As DataRowView In dvFechaAutoF
        '    oView.Row.Item(0) = 0
        'Next
        oReport.Data.Tables(0).AcceptChanges()

        geResults.SetDataBinding(oReport.Data, oReport.Data.Tables(0).TableName)

       

    End Sub

    Protected Friend Overrides Sub ActionPreview()

        If (oReport.Data Is Nothing) Then
            MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
            Exit Sub
        End If
        'crearColumnaSAP()

        'For Each oRow As DataRow In oReport.Data.Tables(0).Rows

        'Next

        Dim oARReporte As New VentasTotales(dsPreviewReport, CComboIni.Text, cComboFin.Text)
        'Dim oARReporte As New VentasTotales(oReport.Data, CComboIni.Text, cComboFin.Text)

        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Ventas Totales"
        oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Sm_ActionPrintReportePedidosFacturados(CComboIni.Text, cComboFin.Text)

    End Sub

    Public Sub crearColumnaSAP()
        Dim dcFolioSAP As New DataColumn
        With dcFolioSAP
            .ColumnName = "Referencia"
            .DataType = GetType(String)
            .Caption = "Referencia"
            .DefaultValue = ""
        End With
        dsPreviewReport.Tables(0).Columns.Add(dcFolioSAP)
        dsPreviewReport.Tables(0).AcceptChanges()

    End Sub

    Protected Friend Overrides Sub ActionExport()

        If (oReport.Data Is Nothing) Then
            MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
            Exit Sub
        End If

        'ExportaReportesVariosInventario()
        ExportReportesTotales()
    End Sub

    Private Sub ExportaReportesVariosInventario()

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
        wsxl.Name = "Reporte Vtas Totales"

        '****************************************
        'HOJA DE CALCULO VENTAS TOTALES
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE VENTAS TOTALES"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:L1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:L1").BorderAround(, 2, 0, )
        wsxl.Range("A1:L1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 1).Value = "Fecha : " & Format(Date.Now, "Long Date")
        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True
        wsxl.Range("A2:L2").Merge()

        wsxl.Cells(3, 14).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(3, 14).Font.Size = 12
        wsxl.Cells(3, 14).Font.Bold = True
        wsxl.Range("A3:L3").Merge()
        wsxl.Range("A3:L3").HorizontalAlignment = 3

        'Encabezado
        wsxl.Cells(5, 1).Value = "Folio"
        wsxl.Cells(5, 2).Value = "Referencia"
        wsxl.Cells(5, 3).Value = "Fecha"
        wsxl.Cells(5, 4).Value = "Total Art."
        wsxl.Cells(5, 5).Value = "Importe"
        wsxl.Cells(5, 6).Value = "Descuentos"
        wsxl.Cells(5, 7).Value = "Formas de Pago"
        wsxl.Cells(5, 8).Value = "Pagos"
        wsxl.Cells(5, 9).Value = "Vendedor"
        wsxl.Cells(5, 10).Value = "Cliente"
        wsxl.Cells(5, 11).Value = "Tipo Vta"
        wsxl.Cells(5, 12).Value = "Status"

        wsxl.Range("A5:L5").Font.Bold = True
        wsxl.Range("A5:L5").HorizontalAlignment = 3
        wsxl.Range("A5:L5").Font.Size = 10
        wsxl.Range("A5:L5").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A5:L5").BorderAround(, 2, 0, )
        intRow = 0
        Dim dat As Date = CComboIni.Value

        For Each oRow In oReport.Data.Tables(0).Rows
            intRow = intRow + 1
            '-----------------Facturas-----------------------------------
            wsxl.Cells(5 + intRow, 1).Value = oRow!folio
            wsxl.Cells(5 + intRow, 2).Value = "'" & oRow!Referencia
            wsxl.Cells(5 + intRow, 3).Value = oRow!Fecha
            wsxl.Cells(5 + intRow, 4).Value = oRow!TotalArticulos
            wsxl.Cells(5 + intRow, 5).Value = Math.Abs(oRow!Importe)
            wsxl.Cells(5 + intRow, 6).Value = oRow!Descuento
            wsxl.Cells(5 + intRow, 7).Value = oRow!formapago01
            wsxl.Cells(5 + intRow, 8).Value = oRow!pago01
            wsxl.Cells(5 + intRow, 9).Value = "'" & oRow!vendedor
            wsxl.Cells(5 + intRow, 10).Value = "'" & oRow!cliente
            wsxl.Cells(5 + intRow, 11).Value = oRow!tipoventa
            wsxl.Cells(5 + intRow, 12).Value = oRow!status

            For i As Integer = 6 To 14
                If Not (oRow(i) Is DBNull.Value) Then
                    intRow = intRow + 1
                    wsxl.Cells(5 + intRow, 5).Value = 0
                    wsxl.Cells(5 + intRow, 6).Value = 0
                    wsxl.Cells(5 + intRow, 7).Value = oRow(i)
                    wsxl.Cells(5 + intRow, 8).Value = oRow(i + 10)
                End If
            Next

            'Para Crear otra linea Igual Cuando Haya Una Factura Cancelada en Rojo
            If oRow!Importe < 0 Then
                If oRow!FolioSAP <> "CREDITO" Then
                    intRow = intRow + 1
                    'Ponerlo de color rojo
                    wsxl.Range("A" & 5 + intRow & ":L" & 5 + intRow).Font.Color = RGB(255, 0, 0)
                    wsxl.Cells(5 + intRow, 1).Value = oRow!folio
                    wsxl.Cells(5 + intRow, 2).Value = "'" & oRow!Referencia
                    wsxl.Cells(5 + intRow, 3).Value = oRow!Fecha
                    wsxl.Cells(5 + intRow, 4).Value = oRow!TotalArticulos
                    wsxl.Cells(5 + intRow, 5).Value = oRow!Importe
                    wsxl.Cells(5 + intRow, 6).Value = oRow!Descuento
                    wsxl.Cells(5 + intRow, 7).Value = oRow!formapago01
                    wsxl.Cells(5 + intRow, 8).Value = oRow!pago01
                    wsxl.Cells(5 + intRow, 9).Value = "'" & oRow!vendedor
                    wsxl.Cells(5 + intRow, 10).Value = "'" & oRow!cliente
                    wsxl.Cells(5 + intRow, 11).Value = oRow!tipoventa
                    wsxl.Cells(5 + intRow, 12).Value = oRow!status
                    For i As Integer = 6 To 14
                        If Not (oRow(i) Is DBNull.Value) Then
                            intRow = intRow + 1
                            wsxl.Cells(5 + intRow, 5).Value = 0
                            wsxl.Cells(5 + intRow, 6).Value = 0
                            wsxl.Cells(5 + intRow, 7).Value = oRow(i)
                            wsxl.Cells(5 + intRow, 8).Value = oRow(i + 10)
                            'Ponerlo de color rojo
                            wsxl.Range("A" & 5 + intRow & ":L" & 5 + intRow).Font.Color = RGB(255, 0, 0)
                        End If
                    Next
                End If
            End If


        Next
        'wsxl.Range("A5:M5").Columns.AutoFit()
        wsxl.Range("A6:L6").ColumnWidth = 15
        wsxl.PageSetup.FitToPagesWide = 1
        wsxl.PageSetup.FitToPagesTall = 1

        Me.Cursor = Cursors.Default

        'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
        SaveDialog.DefaultExt = "*.xls"
        SaveDialog.Filter = "Libro de Microsoft Office Excel (*.xls)|*.xls"
        If SaveDialog.ShowDialog = DialogResult.OK Then
            wbxl.SaveAs(SaveDialog.FileName)
            MsgBox("Documento guardado en " & SaveDialog.FileName, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Repote Notas de Crédito")
        End If

        wbxl.Close()
        wsxl = Nothing
        xlapp.Quit()
        xlapp = Nothing

        KillExcel()

    End Sub

    Private Sub ExportReportesTotales()
        
        'Dim dialogo = New SaveFileDialog
        'dialogo.DefaultExt = "*.xls"
        'dialogo.Filter = "Libro de Microsoft Office Excel (*.xls)|*.xls"
        'If dialogo.ShowDialog = DialogResult.OK Then
        '    Dim reporte As New rptReporteVentasTotales(oReport.Data, CComboIni.Text, cComboFin.Text)
        '    reporte.Run()
        '    Dim export As New XlsExport()
        '    export.FileFormat = FileFormat.Xls97Plus
        '    export.Export(reporte.Document, dialogo.FileName)
        '    Dim oReportViewer As New ReportViewerForm



        '    oReportViewer.Report = reporte
        '    oReportViewer.Show()
        '    MsgBox("Documento guardado en " & dialogo.FileName, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Repote Notas de Crédito")
        'End If
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
        wsxl.Name = "Reporte Vtas Totales"

        '****************************************
        'HOJA DE CALCULO VENTAS TOTALES
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE VENTAS TOTALES"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:L1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:L1").BorderAround(, 2, 0, )
        wsxl.Range("A1:L1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 1).Value = "Fecha : " & Format(Date.Now, "Long Date")
        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True
        wsxl.Range("A2:L2").Merge()

        wsxl.Cells(3, 14).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(3, 14).Font.Size = 12
        wsxl.Cells(3, 14).Font.Bold = True
        wsxl.Range("A3:L3").Merge()
        wsxl.Range("A3:L3").HorizontalAlignment = 3

        ''Encabezado
        'wsxl.Cells(5, 1).Value = "Folio"
        'wsxl.Cells(5, 2).Value = "Referencia"
        'wsxl.Cells(5, 3).Value = "Fecha"
        'wsxl.Cells(5, 4).Value = "Total Art."
        'wsxl.Cells(5, 5).Value = "Importe"
        'wsxl.Cells(5, 6).Value = "Descuentos"
        'wsxl.Cells(5, 7).Value = "Formas de Pago"
        'wsxl.Cells(5, 8).Value = "Vendedor"
        'wsxl.Cells(5, 9).Value = "Cliente"
        'wsxl.Cells(5, 10).Value = "Tipo Vta"
        'wsxl.Cells(5, 11).Value = "Status"
        intRow = 0
        Dim dat As Date = CComboIni.Value
        Dim dtReporte As DataTable = oReport.Data.Tables(0).Copy()
        Dim dtView As New DataView(dtReporte, "", "TipoReporte,Folio", DataViewRowState.CurrentRows)
        Dim TipoReporte As String = ""
        Dim Folio As String = ""
        For Each row As DataRowView In dtView
            If TipoReporte <> CStr(row("TipoReporte")) Then
                intRow += 2
                TipoReporte = CStr(row("TipoReporte"))
                wsxl.Cells(5 + intRow, 1).Value = "TipoReporte"
                wsxl.Cells(5 + intRow, 2).Value = TipoReporte
                'Encabezado
                intRow += 1
                wsxl.Cells(5 + intRow, 1).Value = "Folio"
                wsxl.Cells(5 + intRow, 2).Value = "Referencia"
                wsxl.Cells(5 + intRow, 3).Value = "Fecha"
                wsxl.Cells(5 + intRow, 4).Value = "Total Art."
                wsxl.Cells(5 + intRow, 5).Value = "Importe"
                wsxl.Cells(5 + intRow, 6).Value = "Descuentos"
                wsxl.Cells(5 + intRow, 7).Value = "Formas de Pago"
                wsxl.Cells(5 + intRow, 8).Value = "Vendedor"
                wsxl.Cells(5 + intRow, 9).Value = "Cliente"
                wsxl.Cells(5 + intRow, 10).Value = "Tipo Vta"
                wsxl.Cells(5 + intRow, 11).Value = "Status"

                wsxl.Range("A" & CStr(5 + intRow) & ":L" & CStr(5 + intRow)).Font.Bold = True
                wsxl.Range("A" & CStr(5 + intRow) & ":L" & CStr(5 + intRow)).HorizontalAlignment = 3
                wsxl.Range("A" & CStr(5 + intRow) & ":L" & CStr(5 + intRow)).Font.Size = 10
                wsxl.Range("A" & CStr(5 + intRow) & ":L" & CStr(5 + intRow)).Interior.Color = RGB(255, 255, 192)
                wsxl.Range("A" & CStr(5 + intRow) & ":L" & CStr(5 + intRow)).BorderAround(, 2, 0, )
                intRow += 1
                If Folio <> CStr(row("Folio")) Then
                    wsxl.Cells(5 + intRow, 1).Value = "Folio Factura"
                    wsxl.Cells(5 + intRow, 2).Value = CStr(row("Folio"))
                    intRow += 1
                    wsxl.Cells(5 + intRow, 1).Value = CStr(row("Folio"))
                    wsxl.Cells(5 + intRow, 2).Value = "Ref:" & CStr(row("Referencia"))
                    wsxl.Cells(5 + intRow, 3).Value = CStr(row("Fecha"))
                    wsxl.Cells(5 + intRow, 4).Value = CStr(row("TotalArticulos"))
                    wsxl.Cells(5 + intRow, 5).Value = CStr(row("MontoPago"))
                    wsxl.Cells(5 + intRow, 6).Value = CStr(row("Descuento"))
                    wsxl.Cells(5 + intRow, 7).Value = CStr(row("CodFormasPago"))
                    wsxl.Cells(5 + intRow, 8).Value = CStr(row("Vendedor"))
                    wsxl.Cells(5 + intRow, 9).Value = CStr(row("Cliente"))
                    wsxl.Cells(5 + intRow, 10).Value = CStr(row("Tipovta"))
                    wsxl.Cells(5 + intRow, 11).Value = CStr(row("Status"))
                    Folio = CStr(row("Folio"))
                    intRow += 1
                Else
                    wsxl.Cells(5 + intRow, 1).Value = CStr(row("Folio"))
                    wsxl.Cells(5 + intRow, 2).Text = "Ref:" & CStr(row("Referencia"))
                    wsxl.Cells(5 + intRow, 3).Value = CStr(row("Fecha"))
                    wsxl.Cells(5 + intRow, 4).Value = CStr(row("TotalArticulos"))
                    wsxl.Cells(5 + intRow, 5).Value = CStr(row("MontoPago"))
                    wsxl.Cells(5 + intRow, 6).Value = CStr(row("Descuento"))
                    wsxl.Cells(5 + intRow, 7).Value = CStr(row("CodFormasPago"))
                    wsxl.Cells(5 + intRow, 8).Value = CStr(row("Vendedor"))
                    wsxl.Cells(5 + intRow, 9).Value = CStr(row("Cliente"))
                    wsxl.Cells(5 + intRow, 10).Value = CStr(row("Tipovta"))
                    wsxl.Cells(5 + intRow, 11).Value = CStr(row("Status"))
                    intRow += 1
                End If
            Else
                If Folio <> CStr(row("Folio")) Then
                    wsxl.Cells(5 + intRow, 1).Value = "Folio Factura"
                    wsxl.Cells(5 + intRow, 2).Value = CStr(row("Folio"))
                    intRow += 1
                    wsxl.Cells(5 + intRow, 1).Value = CStr(row("Folio"))
                    wsxl.Cells(5 + intRow, 2).Value = "Ref:" & CStr(row("Referencia"))
                    wsxl.Cells(5 + intRow, 3).Value = CStr(row("Fecha"))
                    wsxl.Cells(5 + intRow, 4).Value = CStr(row("TotalArticulos"))
                    wsxl.Cells(5 + intRow, 5).Value = CStr(row("MontoPago"))
                    wsxl.Cells(5 + intRow, 6).Value = CStr(row("Descuento"))
                    wsxl.Cells(5 + intRow, 7).Value = CStr(row("CodFormasPago"))
                    wsxl.Cells(5 + intRow, 8).Value = CStr(row("Vendedor"))
                    wsxl.Cells(5 + intRow, 9).Value = CStr(row("Cliente"))
                    wsxl.Cells(5 + intRow, 10).Value = CStr(row("Tipovta"))
                    wsxl.Cells(5 + intRow, 11).Value = CStr(row("Status"))
                    Folio = CStr(row("Folio"))
                    intRow += 1
                Else
                    wsxl.Cells(5 + intRow, 1).Value = CStr(row("Folio"))
                    wsxl.Cells(5 + intRow, 2).Value = "Ref:" & CStr(row("Referencia"))
                    wsxl.Cells(5 + intRow, 3).Value = CStr(row("Fecha"))
                    wsxl.Cells(5 + intRow, 4).Value = CStr(row("TotalArticulos"))
                    wsxl.Cells(5 + intRow, 5).Value = CStr(row("MontoPago"))
                    wsxl.Cells(5 + intRow, 6).Value = CStr(row("Descuento"))
                    wsxl.Cells(5 + intRow, 7).Value = CStr(row("CodFormasPago"))
                    wsxl.Cells(5 + intRow, 8).Value = CStr(row("Vendedor"))
                    wsxl.Cells(5 + intRow, 9).Value = CStr(row("Cliente"))
                    wsxl.Cells(5 + intRow, 10).Value = CStr(row("Tipovta"))
                    wsxl.Cells(5 + intRow, 11).Value = CStr(row("Status"))
                    intRow += 1
                End If
            End If
        Next
        'wsxl.Range("A5:M5").Columns.AutoFit()
        wsxl.Range("A6:L6").ColumnWidth = 15
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

    Private Sub btnButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim LayoutStream As System.IO.FileStream

        LayoutStream = New System.IO.FileStream("C:\VentasTotales.gxl", System.IO.FileMode.OpenOrCreate)

        geResults.SaveLayoutFile(LayoutStream)

        LayoutStream.Close()

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

    Private Sub VentasTotalesReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function SelectConcentrado(ByVal strCaja As String, ByVal ccDesde As Date, ByVal ccHasta As Date) As DataTable

        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())

        Dim daNotaCredito As SqlDataAdapter
        Dim dtConcentrado As New DataTable("Concentrado")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[NotasCreditoReporteConcentradoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Caja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sucursal", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@Caja").Value = strCaja
            .Parameters("@FechaInicial").Value = ccDesde
            .Parameters("@FechaFinal").Value = ccHasta
            .Parameters("@Sucursal").Value = oAppContext.ApplicationConfiguration.Almacen

        End With

        daNotaCredito = New SqlDataAdapter(sccmdSelect)

        Try

            daNotaCredito.Fill(dtConcentrado)

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

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de aplicación.", ex)

        End Try

        daNotaCredito.Dispose()
        daNotaCredito = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtConcentrado

    End Function

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

    Private Sub btnGeneraReporte_Click(sender As Object, e As System.EventArgs) Handles btnGeneraReporte.Click
        ActionGenerate()
    End Sub

    Private Sub Sm_ActionPrintReportePedidosFacturados(ByVal datFechaInicio As Date, ByVal datFechaFin As Date)
        Dim rptVentas As New ReporteVentasDataGateWay(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString(), oAppContext)
        Dim dsPedidos As DataSet = rptVentas.GetReportePedidosFacturados(oAppContext.ApplicationConfiguration.Almacen, datFechaInicio, datFechaFin)

        Dim oARReporte As New rptPedidosTotales(dsPedidos, oAppContext.ApplicationConfiguration.Almacen, datFechaInicio, datFechaFin)
        'Dim oARReporte As New ConcentradoREP(dlFecha, GetAlmacen())
        'Dim oARReporte As New VentasTotales(oReport.Data, CComboIni.Text, cComboFin.Text)

        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Ventas Totales de Pedidos Facturados"
        oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()
    End Sub

End Class


