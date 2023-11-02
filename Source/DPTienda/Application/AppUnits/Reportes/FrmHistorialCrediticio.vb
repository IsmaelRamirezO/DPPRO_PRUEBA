Public Class FrmHistorialCrediticio
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ccFechaDesde As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ccFechaHasta As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebAsociado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHistorialCrediticio))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ccFechaDesde = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ccFechaHasta = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ebAsociado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnExportar)
        Me.ExplorerBar1.Controls.Add(Me.GroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Location = New System.Drawing.Point(-24, -56)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(368, 336)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnExportar
        '
        Me.btnExportar.BackColor = System.Drawing.SystemColors.Window
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnExportar.Location = New System.Drawing.Point(216, 208)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(96, 23)
        Me.btnExportar.TabIndex = 32
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ccFechaDesde)
        Me.GroupBox1.Controls.Add(Me.ccFechaHasta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ebAsociado)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(40, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 136)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Rango "
        '
        'ccFechaDesde
        '
        Me.ccFechaDesde.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.ccFechaDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ccFechaDesde.Location = New System.Drawing.Point(96, 64)
        Me.ccFechaDesde.Name = "ccFechaDesde"
        Me.ccFechaDesde.Size = New System.Drawing.Size(112, 21)
        Me.ccFechaDesde.TabIndex = 6
        Me.ccFechaDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ccFechaHasta
        '
        Me.ccFechaHasta.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.ccFechaHasta.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ccFechaHasta.Location = New System.Drawing.Point(96, 96)
        Me.ccFechaHasta.Name = "ccFechaHasta"
        Me.ccFechaHasta.Size = New System.Drawing.Size(112, 21)
        Me.ccFechaHasta.TabIndex = 7
        Me.ccFechaHasta.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Desde:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Hasta:"
        '
        'ebAsociado
        '
        Me.ebAsociado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAsociado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAsociado.BackColor = System.Drawing.Color.Ivory
        Me.ebAsociado.ButtonImage = CType(resources.GetObject("ebAsociado.ButtonImage"), System.Drawing.Image)
        Me.ebAsociado.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebAsociado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAsociado.Location = New System.Drawing.Point(96, 24)
        Me.ebAsociado.Name = "ebAsociado"
        Me.ebAsociado.Size = New System.Drawing.Size(108, 22)
        Me.ebAsociado.TabIndex = 2
        Me.ebAsociado.Text = "0"
        Me.ebAsociado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebAsociado.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebAsociado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Asociado"
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Window
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnGenerar.Location = New System.Drawing.Point(112, 208)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(96, 23)
        Me.btnGenerar.TabIndex = 31
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'FrmHistorialCrediticio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 178)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(312, 216)
        Me.MinimumSize = New System.Drawing.Size(312, 216)
        Me.Name = "FrmHistorialCrediticio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Historial Crediticio"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ebAsociado_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebAsociado.ButtonClick
        SearchAsociadosCreditoDirecto()
    End Sub

    Private Sub SearchAsociadosCreditoDirecto()

        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New CreditoDirectoEnTiendaOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            ebAsociado.Value = oOpenRecordDlg.Record.Item("AsociadoID")
            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub FrmHistorialCrediticio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")

            Case Keys.Escape

                Me.Finalize()

                Me.Close()

        End Select

    End Sub

    Private Sub FrmHistorialCrediticio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ccFechaDesde.Value = Date.Now
        ccFechaHasta.Value = Date.Now
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        'Dim HstCredMgr As New CuentasXCobrar.CuentasXCobrar

        'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

        '    HstCredMgr.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
        '    HstCredMgr.strURL.TrimStart("/")

        'End If

        'Dim ds As DataSet

        'ds = HstCredMgr.SelectHistorialCrediticio(ebAsociado.Text, ccFechaDesde.Value, ccFechaHasta.Value)

        'Dim oARReporte As New HistorialCrediticio(ds, "Del " & Format(ccFechaDesde.Value, "dd/MM/yyyy") & " Al " & Format(ccFechaHasta.Value, "dd/MM/yyyy"))
        'Dim oReportViewer As New ReportViewerForm

        'oARReporte.Document.Name = "Historial Crediticio"
        'oARReporte.Run()

        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        ExportaHistCredXLS()
    End Sub

    Private Sub ExportaHistCredXLS()
        'Dim HstCredMgr As New CuentasXCobrar.CuentasXCobrar

        'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

        '    HstCredMgr.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
        '    HstCredMgr.strURL.TrimStart("/")

        'End If

        Dim ds As DataSet

        'ds = HstCredMgr.SelectHistorialCrediticio(ebAsociado.Text, ccFechaDesde.Value, ccFechaHasta.Value)

        If Not (ds.Tables(0).Rows.Count > 0) Then

            MsgBox("No existe información a Exportar. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Estado de Cuenta")
            Exit Sub

        End If

        Me.Cursor = Cursors.WaitCursor

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
        wsxl.Name = "Historial Crediticio"

        '****************************************
        'HOJA DE CALCULO
        '****************************************
        wsxl.Cells(1, 6).Value = "Fecha"
        wsxl.Range("F1").Font.Size = 8
        wsxl.Cells(1, 6).Value = Format(Date.Now, "short date")
        wsxl.Cells(1, 6).Font.Bold = True

        wsxl.Cells(2, 1).Value = "HISTORIAL CREDITICIO"
        wsxl.Cells(2, 1).Font.Bold = True
        wsxl.Cells(2, 1).Font.Size = 12
        wsxl.Range("A2:F2").Merge()
        wsxl.Range("A2:E2").HorizontalAlignment = 3

        wsxl.Cells(3, 1).Value = "Del " & Format(ccFechaDesde.Value, "dd/MM/yyyy") & " Al " & Format(ccFechaHasta.Value, "dd/MM/yyyy")
        wsxl.Cells(3, 1).Font.Size = 8
        wsxl.Cells(3, 1).Font.Bold = True
        wsxl.Range("A3:F3").Merge()
        wsxl.Range("A3:F3").HorizontalAlignment = 3

        wsxl.Cells(5, 1).Value = "Cliente:"
        wsxl.Cells(5, 1).Font.Bold = True

        'Encabezado
        wsxl.Cells(7, 1).Value = "STATUS"
        wsxl.Cells(7, 2).Value = "FACTURA"
        wsxl.Cells(7, 3).Value = "FECHA"
        wsxl.Cells(7, 4).Value = "CARGOS"
        wsxl.Cells(7, 5).Value = "ABONOS"
        wsxl.Cells(7, 6).Value = "SALDO"
        wsxl.Range("A7:F7").Font.Bold = True
        wsxl.Range("A7:F7").HorizontalAlignment = 3
        wsxl.Range("A7:F7").Font.Size = 8

        intRow = 7

        For Each oRow In ds.Tables(0).Rows
            intRow = intRow + 1
            wsxl.Cells(5, 2).Value = oRow!AsociadoID & Space(1) & oRow!Nombre
            wsxl.Cells(intRow, 1).Value = oRow!StatusFactura
            wsxl.Cells(intRow, 2).Value = oRow!FolioFactura
            wsxl.Cells(intRow, 3).Value = Format(oRow!FechaFactura, "dd/MM/yyyy")
            wsxl.Cells(intRow, 4).Value = FormatCurrency(oRow!Cargos, 2)
            wsxl.Cells(intRow, 5).Value = FormatCurrency(oRow!Abonos, 2)
            wsxl.Cells(intRow, 6).Value = FormatCurrency(oRow!Saldo, 2)
        Next

        intRow = intRow + 1
        wsxl.Cells(intRow, 4).Value = "=SUMAR.SI(A8:A" & Trim(Str(intRow - 1)) & "," & Chr(34) & "GRA" & Chr(34) & ",D8:D" & Trim(Str(intRow - 1)) & ")"
        wsxl.Cells(intRow, 5).Value = "=SUMAR.SI(A8:A" & Trim(Str(intRow - 1)) & "," & Chr(34) & "GRA" & Chr(34) & ",E8:E" & Trim(Str(intRow - 1)) & ")"
        wsxl.Cells(intRow, 6).Value = "=SUMAR.SI(A8:A" & Trim(Str(intRow - 1)) & "," & Chr(34) & "GRA" & Chr(34) & ",F8:F" & Trim(Str(intRow - 1)) & ")"
        wsxl.Range("D" & Trim(Str(intRow)) & ":F" & Trim(Str(intRow))).NumberFormat = "$ ###,###,##0.00"
        wsxl.Range("D" & Trim(Str(intRow)) & ":F" & Trim(Str(intRow))).BorderAround(, 2, 0, )

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

        Me.Cursor = Cursors.WaitCursor

        KillExcel()

        Me.Cursor = Cursors.Default

    End Sub

End Class
