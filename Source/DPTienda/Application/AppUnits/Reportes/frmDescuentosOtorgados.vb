Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports Janus.Windows.GridEX
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
'Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas


Public Class frmDescuentosOtorgados
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ccbHasta As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ccmbDesde As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GrdDescuentos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDescuentosOtorgados))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.ccbHasta = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ccmbDesde = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GrdDescuentos = New Janus.Windows.GridEX.GridEX()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.GrdDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.ccbHasta)
        Me.ExplorerBar1.Controls.Add(Me.ccmbDesde)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.GrdDescuentos)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(536, 301)
        Me.ExplorerBar1.TabIndex = 7
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(296, 264)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Exportar"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(272, 264)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 23)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "F5"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(208, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Desde"
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnGenerar.Location = New System.Drawing.Point(408, 24)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'ccbHasta
        '
        Me.ccbHasta.Anchor = System.Windows.Forms.AnchorStyles.Top
        '
        '
        '
        Me.ccbHasta.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccbHasta.Location = New System.Drawing.Point(264, 24)
        Me.ccbHasta.Name = "ccbHasta"
        Me.ccbHasta.Size = New System.Drawing.Size(128, 23)
        Me.ccbHasta.TabIndex = 2
        Me.ccbHasta.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'ccmbDesde
        '
        Me.ccmbDesde.Anchor = System.Windows.Forms.AnchorStyles.Top
        '
        '
        '
        Me.ccmbDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccmbDesde.Location = New System.Drawing.Point(72, 24)
        Me.ccmbDesde.Name = "ccmbDesde"
        Me.ccmbDesde.Size = New System.Drawing.Size(128, 23)
        Me.ccmbDesde.TabIndex = 1
        Me.ccmbDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(32, 264)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 23)
        Me.Label22.TabIndex = 124
        Me.Label22.Text = "Imprimir"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(16, 264)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 23)
        Me.Label21.TabIndex = 123
        Me.Label21.Text = "F9"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(176, 264)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 23)
        Me.Label16.TabIndex = 122
        Me.Label16.Text = "Salir"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(152, 264)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 23)
        Me.Label13.TabIndex = 121
        Me.Label13.Text = "Esc"
        '
        'GrdDescuentos
        '
        Me.GrdDescuentos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GrdDescuentos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.GrdDescuentos.DesignTimeLayout = GridEXLayout2
        Me.GrdDescuentos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GrdDescuentos.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GrdDescuentos.GroupByBoxVisible = False
        Me.GrdDescuentos.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GrdDescuentos.Location = New System.Drawing.Point(16, 64)
        Me.GrdDescuentos.Name = "GrdDescuentos"
        Me.GrdDescuentos.Size = New System.Drawing.Size(504, 184)
        Me.GrdDescuentos.TabIndex = 4
        Me.GrdDescuentos.TableSpacing = 7
        Me.GrdDescuentos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmDescuentosOtorgados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 301)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.Name = "frmDescuentosOtorgados"
        Me.Text = "Descuentos Otorgados"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.GrdDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private dsDescuentos As DataSet
    Private oFacturaMgr As FacturaManager

    Public Sub ActionPreview()
        Try
            If Not Me.dsDescuentos Is Nothing Then

                Dim oarreporte As New RptDescuentosOtorgados(Me.dsDescuentos, Me.ccmbDesde.Value, Me.ccbHasta.Value)
                Dim oReportViewer As New ReportViewerForm

                oARReporte.Document.Name = "Abonos Contratos"
                oARReporte.Run()

                oReportViewer.Report = oARReporte
                oReportViewer.Show()

                Try


                Catch ex As Exception

                    Throw ex

                End Try

            End If

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    Private Sub frmReporteAbonos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        ccmbDesde.Value = Date.Now
        ccbHasta.Value = Date.Now
        oFacturaMgr = New FacturaManager(oAppContext)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GrdDescuentos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdDescuentos.KeyDown

        If e.KeyCode = Keys.Escape Then

            Me.Close()

        End If

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Me.Cursor = Cursors.WaitCursor
        Me.dsDescuentos = oFacturaMgr.SelectByDateDescuentosOtorgados(Me.ccmbDesde.Value, Me.ccbHasta.Value)

        If dsDescuentos.Tables(0).Rows.Count > 0 Then

            Me.dsDescuentos.AcceptChanges()
            Me.GrdDescuentos.DataSource = dsDescuentos
            Me.GrdDescuentos.DataMember = dsDescuentos.Tables(0).TableName

        Else

            Me.dsDescuentos.RejectChanges()

            MessageBox.Show("Los datos proporcionados no arrojaron resultados", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub ExportarDescuentos()

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
        wsxl.Name = "REPORTE DE DESCUENTOS OTORGADOS"

        '****************************************
        'HOJA DE CALCULO APARTADOS EN TOTALES
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE DESCUENTOS OTORGADOS"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:M1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:M1").BorderAround(, 2, 0, )
        wsxl.Range("A1:M1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 1).Value = Format(Date.Now, "short date")
        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(4, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(4, 1).Font.Size = 10
        wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Range("A4:M4").Merge()
        wsxl.Range("A3:M4").HorizontalAlignment = 3

        'Encabezado
        Dim Columna As Integer = 0
        While Columna < Me.GrdDescuentos.RootTable.Columns.Count
            wsxl.Cells(6, Columna + 1).Value = Me.GrdDescuentos.RootTable.Columns(Columna).Caption
            wsxl.Columns(Columna + 1).AutoFitColumns()
            Columna = Columna + 1
        End While

        wsxl.Range("A6:M6").Font.Bold = True
        wsxl.Range("A6:M6").HorizontalAlignment = 3
        wsxl.Range("A6:M6").Font.Size = 8
        wsxl.Range("A6:M6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:M6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oCurrentRow As GridEXRow In Me.GrdDescuentos.GetRows

            Dim odrDataRow As DataRowView
            odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

            For Each column As DataColumn In odrDataRow.DataView.Table.Columns

                wsxl.Cells(oCurrentRow.Position + 7, Me.GrdDescuentos.RootTable.Columns(column.ColumnName).Position + 1).value = _
                  odrDataRow(column.ColumnName)
            Next
            intRow += 1
        Next

        wsxl.Range("D7:D" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        wsxl.Range("F7:F" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        wsxl.Range("G7:G" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        wsxl.Range("I7:I" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        wsxl.Range("J7:J" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        wsxl.Range("K7:K" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        wsxl.Cells(8 + intRow, 4).Value = "=SUMA(D7:D" & Trim(Str(7 + intRow)) & ")"
        wsxl.Cells(8 + intRow, 6).Value = "=SUMA(F7:F" & Trim(Str(7 + intRow)) & ")"
        wsxl.Cells(8 + intRow, 7).Value = "=SUMA(G7:G" & Trim(Str(7 + intRow)) & ")"
        wsxl.Cells(8 + intRow, 9).Value = "=SUMA(I7:I" & Trim(Str(7 + intRow)) & ")"
        wsxl.Cells(8 + intRow, 10).Value = "=SUMA(J7:J" & Trim(Str(7 + intRow)) & ")"
        wsxl.Cells(8 + intRow, 11).Value = "=SUMA(K7:K" & Trim(Str(7 + intRow)) & ")"

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

    Private Sub frmDescuentosOtorgados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F9 Then
            Me.Cursor = Cursors.WaitCursor
            ActionPreview()
            Me.Cursor = Cursors.Default
        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        ElseIf e.KeyCode = Keys.F5 Then

            Me.Cursor = Cursors.WaitCursor
            ExportarDescuentos()
            Me.Cursor = Cursors.Default

        ElseIf e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub
End Class
