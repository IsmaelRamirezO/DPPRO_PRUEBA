Imports System.Data
Imports system.Data.SqlClient

Imports system.Diagnostics.Process

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes


Public Class AuditoriaRetirosReportForm

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AuditoriaRetirosReportForm))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
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
        Me.grpGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.btnGenerar)
        Me.explorerBar1.Controls.Add(Me.btnExportar)
        Me.explorerBar1.Controls.Add(Me.grpGroupBox1)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Filtros"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(274, 223)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(17, 179)
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
        Me.btnExportar.Location = New System.Drawing.Point(145, 179)
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
        Me.grpGroupBox1.Location = New System.Drawing.Point(12, 32)
        Me.grpGroupBox1.Name = "grpGroupBox1"
        Me.grpGroupBox1.Size = New System.Drawing.Size(252, 136)
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
        'AuditoriaRetirosReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(274, 223)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "AuditoriaRetirosReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Auditoría de Retiros"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
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

    Private Sub AuditoriaRetirosReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillCaja()
        ccDesde.Value = Date.Now
        ccHasta.Value = Date.Now

    End Sub

    Private Sub AuditoriaRetirosReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()

            Case Keys.Enter
                SendKeys.Send("{TAB}")

        End Select

    End Sub

    Private Sub ccDesde_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ccDesde.Validating

        If ccDesde.Value > ccHasta.Value Then

            MsgBox("Fecha Inicial debe ser menor o igual a Fecha Final. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Auditoria de Retiros")
            ccDesde.Value = Date.Now
            ccHasta.Value = Date.Now
            e.Cancel = True

        End If

    End Sub

    Private Sub ccHasta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ccHasta.Validating

        If ccHasta.Value < ccDesde.Value Then

            MsgBox("Fecha Final debe ser mayor o igual a Fecha Inicial. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Auditoria de Retiros")
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

        ImprimeAuditoriaRetiros(nCaja, 0)

    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        Dim nCaja As String

        If UCase(cbCajas.Text) = "TODAS" Then
            nCaja = "00"
        Else
            nCaja = cbCajas.Text
        End If

        ImprimeAuditoriaRetiros(nCaja, 1)

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

        cbCajas.SelectedIndex = 0

    End Sub

    Private Sub ImprimeAuditoriaRetiros(ByVal nCaja As String, ByVal Tipo As Integer)

        Me.Cursor = Cursors.WaitCursor

        Dim dtRetiros As New DataTable("Retiros")
        dtRetiros = SelectRetiros(nCaja)

        If dtRetiros Is Nothing Then

            Me.Cursor = Cursors.Default
            MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Reporte de Notas de Crédito")

        Else

            If Tipo = 0 Then

                If dtRetiros.Rows.Count = 0 Then

                    Me.Cursor = Cursors.Default
                    MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Reporte de Notas de Crédito")

                Else

                    Dim oARReporte As New AuditoriaRetirosReport(nCaja, GetAlmacen(), ccDesde.Value, ccHasta.Value, dtRetiros)
                    Dim oReportViewer As New ReportViewerForm
                    oARReporte.Document.Name = "Auditoria a Retiros"
                    ''oARReporte.Document.Print(False, False)
                    oReportViewer.Report = oARReporte
                    Me.Cursor = Cursors.Default
                    oReportViewer.Show()

                End If

            Else

                ExportaAuditoriaRetiros(nCaja, dtRetiros)

            End If

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ExportaAuditoriaRetiros(ByVal nCaja As String, ByVal dtReport As DataTable)

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
        'HOJA DE CALCULO AUDITORIA RETIROS
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE RETIROS DE LA CAJA No." & nCaja
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:F1").Merge()
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

        wsxl.Cells(2, 6).Value = Format(Date.Now, "short date")
        wsxl.Cells(2, 6).Font.Size = 10
        wsxl.Cells(2, 6).Font.Bold = True

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
        wsxl.Cells(6, 1).Value = "Fecha"
        wsxl.Cells(6, 2).Value = "Ficha"
        wsxl.Cells(6, 3).Value = "Folio"
        wsxl.Cells(6, 4).Value = "Cantidad"
        wsxl.Cells(6, 5).Value = "Usuario"
        wsxl.Cells(6, 6).Value = "Hora"
        wsxl.Range("A6:F6").Font.Bold = True
        wsxl.Range("A6:F6").HorizontalAlignment = 3
        wsxl.Range("A6:F6").Font.Size = 8
        wsxl.Range("A6:F6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:F6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oRow In dtReport.Rows
            intRow = intRow + 1
            wsxl.Cells(6 + intRow, 1).Value = "'" & Format(oRow!Fecha, "short date")
            wsxl.Cells(6 + intRow, 1).HorizontalAlignment = 3

            wsxl.Cells(6 + intRow, 2).Value = "'" & oRow!Ficha
            wsxl.Cells(6 + intRow, 2).HorizontalAlignment = 4

            wsxl.Cells(6 + intRow, 3).Value = oRow!Folio
            wsxl.Cells(6 + intRow, 4).Value = oRow!Cantidad
            wsxl.Cells(6 + intRow, 5).Value = oRow!Usuario
            wsxl.Cells(6 + intRow, 6).Value = Format(oRow!Fecha, "hh:mm:ss")
            wsxl.Cells(6 + intRow, 6).HorizontalAlignment = 3
        Next

        wsxl.Cells(8 + intRow, 2).Value = "TOTAL RETIROS :"
        wsxl.Cells(8 + intRow, 3).Value = dtReport.Rows.Count
        wsxl.Cells(8 + intRow, 4).Value = "=SUMA(D7:D" & Trim(Str(6 + intRow)) & ")"
        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":F" & Trim(Str(8 + intRow))).BorderAround(, 2, 0, )
        wsxl.Range("D6:D" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":F" & Trim(Str(8 + intRow))).Font.Bold = True

        wsxl.Range("A6:A6").ColumnWidth = 13
        wsxl.Range("B6:B6").ColumnWidth = 20
        wsxl.Range("C6:C6").ColumnWidth = 10
        wsxl.Range("D6:D6").ColumnWidth = 17
        wsxl.Range("E6:E6").ColumnWidth = 13
        wsxl.Range("F6:F6").ColumnWidth = 13
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

#End Region

#Region "SQL Methods"

    Private Function SelectRetiros(ByVal strCaja As String) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daAuditoria As SqlDataAdapter
        Dim dtRetiros As New DataTable("Retiros")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[AuditoriaRetirosSel]"
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

        daAuditoria = New SqlDataAdapter(sccmdSelect)

        Try

            daAuditoria.Fill(dtRetiros)

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

        daAuditoria.Dispose()
        daAuditoria = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtRetiros

    End Function

#End Region

#End Region

End Class

