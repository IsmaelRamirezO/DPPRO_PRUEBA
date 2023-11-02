Imports System.Data
Imports system.Data.SqlClient

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes


Public Class NotasdeCreditoReportForm
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
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents grpGroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblHasta As System.Windows.Forms.Label
    Friend WithEvents ccHasta As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbCajas As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblDesde As System.Windows.Forms.Label
    Friend WithEvents ccDesde As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents grpGroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents rbConcentrado As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotasdeCreditoReportForm))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grpGroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbDetallado = New System.Windows.Forms.RadioButton()
        Me.rbConcentrado = New System.Windows.Forms.RadioButton()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.grpGroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblHasta = New System.Windows.Forms.Label()
        Me.ccHasta = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbCajas = New Janus.Windows.EditControls.UIComboBox()
        Me.lblDesde = New System.Windows.Forms.Label()
        Me.ccDesde = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblCaja = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.grpGroupBox2.SuspendLayout()
        Me.grpGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.grpGroupBox2)
        Me.explorerBar1.Controls.Add(Me.btnGenerar)
        Me.explorerBar1.Controls.Add(Me.btnExportar)
        Me.explorerBar1.Controls.Add(Me.grpGroupBox1)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Filtros"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(-8, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(296, 328)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grpGroupBox2
        '
        Me.grpGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.grpGroupBox2.Controls.Add(Me.rbDetallado)
        Me.grpGroupBox2.Controls.Add(Me.rbConcentrado)
        Me.grpGroupBox2.Location = New System.Drawing.Point(24, 176)
        Me.grpGroupBox2.Name = "grpGroupBox2"
        Me.grpGroupBox2.Size = New System.Drawing.Size(240, 56)
        Me.grpGroupBox2.TabIndex = 1
        Me.grpGroupBox2.TabStop = False
        '
        'rbDetallado
        '
        Me.rbDetallado.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDetallado.Location = New System.Drawing.Point(136, 20)
        Me.rbDetallado.Name = "rbDetallado"
        Me.rbDetallado.Size = New System.Drawing.Size(88, 24)
        Me.rbDetallado.TabIndex = 1
        Me.rbDetallado.Text = "Detallado"
        '
        'rbConcentrado
        '
        Me.rbConcentrado.Checked = True
        Me.rbConcentrado.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConcentrado.Location = New System.Drawing.Point(16, 20)
        Me.rbConcentrado.Name = "rbConcentrado"
        Me.rbConcentrado.Size = New System.Drawing.Size(104, 24)
        Me.rbConcentrado.TabIndex = 0
        Me.rbConcentrado.TabStop = True
        Me.rbConcentrado.Text = "Concentrado"
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(24, 264)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(112, 32)
        Me.btnGenerar.TabIndex = 2
        Me.btnGenerar.Text = "Imprimir"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(152, 264)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(112, 32)
        Me.btnExportar.TabIndex = 3
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grpGroupBox1
        '
        Me.grpGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.grpGroupBox1.Controls.Add(Me.lblHasta)
        Me.grpGroupBox1.Controls.Add(Me.ccHasta)
        Me.grpGroupBox1.Controls.Add(Me.cbCajas)
        Me.grpGroupBox1.Controls.Add(Me.lblDesde)
        Me.grpGroupBox1.Controls.Add(Me.ccDesde)
        Me.grpGroupBox1.Controls.Add(Me.lblCaja)
        Me.grpGroupBox1.Location = New System.Drawing.Point(24, 32)
        Me.grpGroupBox1.Name = "grpGroupBox1"
        Me.grpGroupBox1.Size = New System.Drawing.Size(240, 136)
        Me.grpGroupBox1.TabIndex = 0
        Me.grpGroupBox1.TabStop = False
        '
        'lblHasta
        '
        Me.lblHasta.BackColor = System.Drawing.Color.Transparent
        Me.lblHasta.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHasta.Location = New System.Drawing.Point(32, 90)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(48, 16)
        Me.lblHasta.TabIndex = 11
        Me.lblHasta.Text = "Hasta"
        '
        'ccHasta
        '
        '
        '
        '
        Me.ccHasta.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccHasta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ccHasta.Location = New System.Drawing.Point(80, 88)
        Me.ccHasta.Name = "ccHasta"
        Me.ccHasta.Size = New System.Drawing.Size(128, 22)
        Me.ccHasta.TabIndex = 2
        Me.ccHasta.TodayButtonText = "Hoy"
        Me.ccHasta.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'cbCajas
        '
        Me.cbCajas.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbCajas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCajas.Location = New System.Drawing.Point(80, 24)
        Me.cbCajas.Name = "cbCajas"
        Me.cbCajas.Size = New System.Drawing.Size(64, 22)
        Me.cbCajas.TabIndex = 0
        Me.cbCajas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblDesde
        '
        Me.lblDesde.BackColor = System.Drawing.Color.Transparent
        Me.lblDesde.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesde.Location = New System.Drawing.Point(32, 59)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(48, 16)
        Me.lblDesde.TabIndex = 9
        Me.lblDesde.Text = "Desde"
        '
        'ccDesde
        '
        '
        '
        '
        Me.ccDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccDesde.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ccDesde.Location = New System.Drawing.Point(80, 56)
        Me.ccDesde.Name = "ccDesde"
        Me.ccDesde.Size = New System.Drawing.Size(128, 22)
        Me.ccDesde.TabIndex = 1
        Me.ccDesde.TodayButtonText = "Hoy"
        Me.ccDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'lblCaja
        '
        Me.lblCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblCaja.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaja.Location = New System.Drawing.Point(32, 27)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(48, 16)
        Me.lblCaja.TabIndex = 7
        Me.lblCaja.Text = "Caja"
        '
        'NotasdeCreditoReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(274, 311)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "NotasdeCreditoReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Notas de Crédito"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.grpGroupBox2.ResumeLayout(False)
        Me.grpGroupBox1.ResumeLayout(False)
        Me.grpGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

    Dim strConnectionString As String = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

#End Region

#Region "Methods"

#Region "Form Methods"

    Private Sub NotasdeCreditoReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillCaja()
        ccDesde.Value = Date.Now
        ccHasta.Value = Date.Now

    End Sub

    Private Sub NotasdeCreditoReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()

            Case Keys.Enter
                SendKeys.Send("{TAB}")

        End Select

    End Sub

    Private Sub ccDesde_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ccDesde.Validating

        If ccDesde.Value > ccHasta.Value Then

            MsgBox("Fecha Inicial debe ser menor o igual a Fecha Final. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Notas de Crédito")
            ccDesde.Value = Date.Now
            ccHasta.Value = Date.Now
            e.Cancel = True

        End If

    End Sub

    Private Sub ccHasta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ccHasta.Validating

        If ccHasta.Value < ccDesde.Value Then

            MsgBox("Fecha Final debe ser mayor o igual a Fecha Inicial. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Notas de Crédito")
            ccHasta.Value = Date.Now
            e.Cancel = True

        End If

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim nCaja As String
        If UCase(cbCajas.Text) = "TODAS" Then
            nCaja = "00"
        Else
            nCaja = cbCajas.Text
        End If

        If rbConcentrado.Checked Then
            'Imprimimos Concentrado
            ImprimeConcentrado(nCaja, 0)
        Else
            'Imprimimos Detallado
            ImprimeDetallado(nCaja, 0)
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        Dim nCaja As String
        If UCase(cbCajas.Text) = "TODAS" Then
            nCaja = "00"
        Else
            nCaja = cbCajas.Text
        End If

        If rbConcentrado.Checked Then
            'Imprimimos Concentrado
            ImprimeConcentrado(nCaja, 1)
        Else
            'Imprimimos Detallado
            ImprimeDetallado(nCaja, 1)
        End If

    End Sub

#End Region

#Region "Members Methods"

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
            'Me.cbCajas.Enabled = False
        End If

    End Sub

    Private Sub ImprimeConcentrado(ByVal nCaja As String, ByVal Tipo As Integer)

        Me.Cursor = Cursors.WaitCursor

        Dim dtConcentrado As New DataTable("Concentrado")
        dtConcentrado = SelectConcentrado(nCaja)
        If dtConcentrado Is Nothing Then
            MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Reporte de Notas de Crédito")
        Else
            If dtConcentrado.Rows.Count = 0 Then
                MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Reporte de Notas de Crédito")
            Else
                If Tipo = 0 Then
                    Dim oARReporte As New NotasdeCreditoConcentradoReport(nCaja, ccDesde.Value, ccHasta.Value, GetAlmacen(), dtConcentrado)
                    Dim oReportViewer As New ReportViewerForm
                    oARReporte.Document.Name = "Reporte de Notas de Crédito Concentrado"
                    'oARReporte.Document.Print(False, False)
                    oReportViewer.Report = oARReporte
                    Me.Cursor = Cursors.Default
                    oReportViewer.Show()
                Else
                    ReporteExcelConcentrado(nCaja, dtConcentrado)
                End If
            End If
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ImprimeDetallado(ByVal nCaja As String, ByVal Tipo As Integer)

        Me.Cursor = Cursors.WaitCursor

        Dim dtDetallado As New DataTable("Detallado")
        dtDetallado = SelectDetallado(nCaja)
        If dtDetallado Is Nothing Then
            MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Reporte de Notas de Crédito")
        Else
            If dtDetallado.Rows.Count = 0 Then
                MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Reporte de Notas de Crédito")
            Else
                If Tipo = 0 Then
                    Dim oarreporte As New NotasdeCreditoDetalladoReport(nCaja, ccDesde.Value, ccHasta.Value, GetAlmacen(), dtDetallado)
                    Dim oReportViewer As New ReportViewerForm
                    oarreporte.Document.Name = "Reporte de Notas de Crédito Detallado"
                    'oARReporte.Document.Print(False, False)
                    oReportViewer.Report = oarreporte
                    Me.Cursor = Cursors.Default
                    oReportViewer.Show()
                Else
                    ReporteExcelDetallado(nCaja, dtDetallado)
                End If

            End If
        End If

        Me.Cursor = Cursors.Default


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

    Private Sub ReporteExcelConcentrado(ByVal nCaja As String, ByVal dtReport As DataTable)

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
                MsgBox("Necesita Microsoft Excel para utilizar esta opción", vbCritical, " Reporte de Notas de Crédito")
                Exit Sub
            End If
        Else
            xlapp = CreateObject("Excel.Application")
        End If

        wbxl = xlapp.Workbooks.Add
        wsxl = xlapp.Sheets(1)
        wsxl.Name = "Notas de Crédito"

        '****************************************
        'HOJA DE CALCULO REPORTE CONCENTRADO
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE NOTAS DE CREDITO TOTALES"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:G1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:F1").BorderAround(, 2, 0, )
        wsxl.Range("A1:F1").HorizontalAlignment = 3

        If nCaja = "00" Then
            wsxl.Cells(2, 1).Value = "Caja #: Todas" & cbCajas.Text
        Else
            wsxl.Cells(2, 1).Value = "Caja #: " & nCaja
        End If
        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 7).Value = Format(Date.Now, "short date")
        wsxl.Cells(2, 7).Font.Size = 10
        wsxl.Cells(2, 7).Font.Bold = True

        wsxl.Cells(3, 1).Value = "De : " & Format(ccDesde.Value, "dd/MM/yyyy") & " Al : " & Format(ccHasta.Value, "dd/MM/yyyy")
        wsxl.Cells(3, 1).Font.Size = 10
        wsxl.Cells(3, 1).Font.Bold = True
        wsxl.Range("A3:F3").Merge()
        wsxl.Cells(4, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(4, 1).Font.Size = 10
        wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Range("A4:F4").Merge()
        wsxl.Range("A3:F4").HorizontalAlignment = 3

        'Encabezado
        wsxl.Cells(6, 1).Value = "Folio"
        wsxl.Cells(6, 2).Value = "Folio SAP"
        wsxl.Cells(6, 3).Value = "Caja"
        wsxl.Cells(6, 4).Value = "Fecha"
        wsxl.Cells(6, 5).Value = "Importe"
        wsxl.Cells(6, 6).Value = "Cliente"
        wsxl.Cells(6, 7).Value = "Revisó"
        wsxl.Range("A6:G6").Font.Bold = True
        wsxl.Range("A6:G6").HorizontalAlignment = 3
        wsxl.Range("A6:G6").Font.Size = 8
        wsxl.Range("A6:G6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:G6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oRow In dtReport.Rows
            intRow = intRow + 1
            wsxl.Cells(6 + intRow, 1).Value = "'" & oRow!FolioNotaCredito
            wsxl.Cells(6 + intRow, 1).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 2).Value = "'" & oRow!SalesDocument
            wsxl.Cells(6 + intRow, 2).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 3).Value = "'" & oRow!Codcaja
            wsxl.Cells(6 + intRow, 3).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 4).Value = "'" & Format(oRow!Fecha, "short date")
            wsxl.Cells(6 + intRow, 4).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 5).Value = oRow!Importe
            wsxl.Cells(6 + intRow, 6).Value = oRow!ClienteID

            wsxl.Cells(6 + intRow, 7).Value = "'" & oRow!CodVendedor
            wsxl.Cells(6 + intRow, 7).HorizontalAlignment = 3
        Next

        wsxl.Cells(8 + intRow, 2).Value = "TOTALES  :"
        wsxl.Cells(8 + intRow, 5).Value = "=SUMA(E7:E" & Trim(Str(6 + intRow)) & ")"
        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":G" & Trim(Str(8 + intRow))).BorderAround(, 2, 0, )
        wsxl.Range("E6:E" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        wsxl.Cells(8 + intRow, 2).Font.Bold = True
        wsxl.Cells(8 + intRow, 4).Font.Bold = True
        wsxl.Range("A6:G6").ColumnWidth = 13
        wsxl.PageSetup.FitToPagesWide = 1
        wsxl.PageSetup.FitToPagesTall = 1

        Me.Cursor = Cursors.Default

        'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
        SaveDialog.DefaultExt = "*.xls"
        SaveDialog.Filter = "(*.xls)|*.xls"
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

    Private Sub ReporteExcelDetallado(ByVal nCaja As String, ByVal dtReport As DataTable)

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
                MsgBox("Necesita Microsoft Excel para utilizar esta opción", vbCritical, " Reporte de Notas de Crédito")
                Exit Sub
            End If
        Else
            xlapp = CreateObject("Excel.Application")
        End If

        wbxl = xlapp.Workbooks.Add
        wsxl = xlapp.Sheets(1)
        wsxl.Name = "Notas de Crédito"

        '****************************************
        'HOJA DE CALCULO REPORTE CONCENTRADO
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE NOTAS DE CREDITO DETALLADO"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:J1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:J1").BorderAround(, 2, 0, )
        wsxl.Range("A1:J1").HorizontalAlignment = 3

        If nCaja = "00" Then
            wsxl.Cells(2, 1).Value = "Caja #: Todas" & cbCajas.Text
        Else
            wsxl.Cells(2, 1).Value = "Caja #: " & nCaja
        End If
        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 9).Value = Format(Date.Now, "short date")
        wsxl.Cells(2, 9).Font.Size = 10
        wsxl.Cells(2, 9).Font.Bold = True

        wsxl.Cells(3, 1).Value = "De : " & Format(ccDesde.Value, "dd/MM/yyyy") & " Al : " & Format(ccHasta.Value, "dd/MM/yyyy")
        wsxl.Cells(3, 1).Font.Size = 10
        wsxl.Cells(3, 1).Font.Bold = True
        wsxl.Range("A3:J3").Merge()
        wsxl.Cells(4, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(4, 1).Font.Size = 10
        wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Range("A4:J4").Merge()
        wsxl.Range("A3:J4").HorizontalAlignment = 3

        'Encabezado
        wsxl.Cells(6, 1).Value = "Folio"
        wsxl.Cells(6, 2).Value = "Folio SAP"
        wsxl.Cells(6, 3).Value = "Sucursal"
        wsxl.Cells(6, 4).Value = "Código"
        wsxl.Cells(6, 5).Value = "Cantidad"
        wsxl.Cells(6, 6).Value = "Talla"
        wsxl.Cells(6, 7).Value = "Importe"
        wsxl.Cells(6, 8).Value = "T. Devol."
        wsxl.Cells(6, 9).Value = "Factura"
        wsxl.Cells(7, 9).Value = "Fecha"
        wsxl.Cells(7, 10).Value = "Folio"

        wsxl.Range("A6:J7").Font.Bold = True
        'wsxl.Range("I6:J6").Merge()
        wsxl.Range("A6:J7").HorizontalAlignment = 3
        wsxl.Range("A6:J7").Font.Size = 8
        wsxl.Range("A6:J7").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:J7").BorderAround(, 2, 0, )

        intRow = 1

        For Each oRow In dtReport.Rows
            intRow = intRow + 1
            wsxl.Cells(6 + intRow, 1).Value = "'" & oRow!FolioNotaCredito
            wsxl.Cells(6 + intRow, 1).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 2).Value = "'" & oRow!SalesDocument
            wsxl.Cells(6 + intRow, 2).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 3).Value = "'" & oRow!CodAlmacen
            wsxl.Cells(6 + intRow, 3).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 4).Value = "'" & oRow!CodArticulo
            wsxl.Cells(6 + intRow, 5).Value = oRow!Cantidad
            wsxl.Cells(6 + intRow, 6).Value = oRow!Numero
            wsxl.Cells(6 + intRow, 7).Value = oRow!Importe

            wsxl.Cells(6 + intRow, 8).Value = "'" & oRow!CodTipoDevolucion
            wsxl.Cells(6 + intRow, 8).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 9).Value = "'" & Format(oRow!FechaFactura, "short date")
            wsxl.Cells(6 + intRow, 9).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 10).Value = "'" & oRow!FolioReferencia
            wsxl.Cells(6 + intRow, 10).HorizontalAlignment = 3

        Next

        wsxl.Cells(8 + intRow, 4).Value = "TOTALES  :"
        wsxl.Cells(8 + intRow, 7).Value = "=SUMA(G8:G" & Trim(Str(6 + intRow)) & ")"
        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":J" & Trim(Str(8 + intRow))).BorderAround(, 2, 0, )
        wsxl.Range("G6:J" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        wsxl.Cells(8 + intRow, 5).Font.Bold = True
        wsxl.Cells(8 + intRow, 7).Font.Bold = True
        wsxl.Range("A6:A6").ColumnWidth = 8
        wsxl.Range("B6:B6").ColumnWidth = 10
        wsxl.Range("C6:C6").ColumnWidth = 7.14
        wsxl.Range("D6:D6").ColumnWidth = 20.71
        wsxl.Range("E6:E6").ColumnWidth = 7.71
        wsxl.Range("F6:F6").ColumnWidth = 5.71
        wsxl.Range("G6:G6").ColumnWidth = 11.29
        wsxl.Range("H6:H6").ColumnWidth = 6.86
        wsxl.Range("I6:I6").ColumnWidth = 10.29
        wsxl.Range("J6:J6").ColumnWidth = 9.14
        wsxl.PageSetup.FitToPagesWide = 1
        wsxl.PageSetup.FitToPagesTall = 1

        wsxl.PageSetup.LeftMargin = 0

        Me.Cursor = Cursors.Default

        'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
        SaveDialog.DefaultExt = "*.xls"
        SaveDialog.Filter = "(*.xls)|*.xls"
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

#End Region

#Region "SQL Methods"

    Private Function SelectConcentrado(ByVal strCaja As String) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

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
            .Parameters("@FechaInicial").Value = ccDesde.Value
            .Parameters("@FechaFinal").Value = ccHasta.Value
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

    Private Function SelectDetallado(ByVal strCaja As String) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daNotaCredito As SqlDataAdapter
        Dim dtDetallado As New DataTable("Detallado")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[NotasCreditoReporteDetalladoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Caja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sucursal", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@Caja").Value = strCaja
            .Parameters("@FechaInicial").Value = ccDesde.Value.Date
            .Parameters("@FechaFinal").Value = ccHasta.Value.Date
            .Parameters("@Sucursal").Value = oAppContext.ApplicationConfiguration.Almacen

        End With

        daNotaCredito = New SqlDataAdapter(sccmdSelect)

        Try

            daNotaCredito.Fill(dtDetallado)

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

        Return dtDetallado

    End Function

#End Region

#End Region

End Class

