Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda

Public Class ValesdeCajaReportForm

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
    Friend WithEvents uIGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblHasta As System.Windows.Forms.Label
    Friend WithEvents ccHasta As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblDesde As System.Windows.Forms.Label
    Friend WithEvents ccDesde As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents rdbValesUsados As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbValesDisponibles As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbValesDevDinero As Janus.Windows.EditControls.UIRadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValesdeCajaReportForm))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.uIGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rdbValesDevDinero = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbValesDisponibles = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbValesUsados = New Janus.Windows.EditControls.UIRadioButton()
        Me.lblHasta = New System.Windows.Forms.Label()
        Me.ccHasta = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblDesde = New System.Windows.Forms.Label()
        Me.ccDesde = New Janus.Windows.CalendarCombo.CalendarCombo()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uIGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.btnGenerar)
        Me.explorerBar1.Controls.Add(Me.btnExportar)
        Me.explorerBar1.Controls.Add(Me.uIGroupBox1)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Filtros"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(266, 272)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(16, 224)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(112, 32)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "Imprimir"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(136, 224)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(112, 32)
        Me.btnExportar.TabIndex = 2
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uIGroupBox1
        '
        Me.uIGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.uIGroupBox1.Controls.Add(Me.rdbValesDevDinero)
        Me.uIGroupBox1.Controls.Add(Me.rdbValesDisponibles)
        Me.uIGroupBox1.Controls.Add(Me.rdbValesUsados)
        Me.uIGroupBox1.Controls.Add(Me.lblHasta)
        Me.uIGroupBox1.Controls.Add(Me.ccHasta)
        Me.uIGroupBox1.Controls.Add(Me.lblDesde)
        Me.uIGroupBox1.Controls.Add(Me.ccDesde)
        Me.uIGroupBox1.Location = New System.Drawing.Point(16, 32)
        Me.uIGroupBox1.Name = "uIGroupBox1"
        Me.uIGroupBox1.Size = New System.Drawing.Size(232, 176)
        Me.uIGroupBox1.TabIndex = 0
        Me.uIGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'rdbValesDevDinero
        '
        Me.rdbValesDevDinero.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbValesDevDinero.Location = New System.Drawing.Point(8, 144)
        Me.rdbValesDevDinero.Name = "rdbValesDevDinero"
        Me.rdbValesDevDinero.Size = New System.Drawing.Size(216, 23)
        Me.rdbValesDevDinero.TabIndex = 18
        Me.rdbValesDevDinero.Text = "Vales por Devolucion de Dinero"
        Me.rdbValesDevDinero.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbValesDisponibles
        '
        Me.rdbValesDisponibles.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbValesDisponibles.Location = New System.Drawing.Point(8, 120)
        Me.rdbValesDisponibles.Name = "rdbValesDisponibles"
        Me.rdbValesDisponibles.Size = New System.Drawing.Size(200, 23)
        Me.rdbValesDisponibles.TabIndex = 17
        Me.rdbValesDisponibles.Text = "Vales de Caja Disponibles."
        Me.rdbValesDisponibles.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbValesUsados
        '
        Me.rdbValesUsados.Checked = True
        Me.rdbValesUsados.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbValesUsados.Location = New System.Drawing.Point(8, 96)
        Me.rdbValesUsados.Name = "rdbValesUsados"
        Me.rdbValesUsados.Size = New System.Drawing.Size(200, 23)
        Me.rdbValesUsados.TabIndex = 16
        Me.rdbValesUsados.TabStop = True
        Me.rdbValesUsados.Text = "Vales de Caja Utilizados."
        Me.rdbValesUsados.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblHasta
        '
        Me.lblHasta.BackColor = System.Drawing.Color.Transparent
        Me.lblHasta.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHasta.Location = New System.Drawing.Point(24, 67)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(48, 16)
        Me.lblHasta.TabIndex = 15
        Me.lblHasta.Text = "Hasta"
        '
        'ccHasta
        '
        '
        '
        '
        Me.ccHasta.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccHasta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ccHasta.Location = New System.Drawing.Point(72, 64)
        Me.ccHasta.Name = "ccHasta"
        Me.ccHasta.Size = New System.Drawing.Size(128, 22)
        Me.ccHasta.TabIndex = 1
        Me.ccHasta.TodayButtonText = "Hoy"
        Me.ccHasta.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'lblDesde
        '
        Me.lblDesde.BackColor = System.Drawing.Color.Transparent
        Me.lblDesde.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesde.Location = New System.Drawing.Point(24, 27)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(48, 16)
        Me.lblDesde.TabIndex = 14
        Me.lblDesde.Text = "Fecha"
        '
        'ccDesde
        '
        '
        '
        '
        Me.ccDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccDesde.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ccDesde.Location = New System.Drawing.Point(72, 24)
        Me.ccDesde.Name = "ccDesde"
        Me.ccDesde.Size = New System.Drawing.Size(128, 22)
        Me.ccDesde.TabIndex = 0
        Me.ccDesde.TodayButtonText = "Hoy"
        Me.ccDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ValesdeCajaReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(266, 272)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "ValesdeCajaReportForm"
        Me.Text = "  Reporte de Vales de Caja"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uIGroupBox1.ResumeLayout(False)
        Me.uIGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

    Dim Rango As String = String.Empty
    Dim Caja As String = String.Empty
    Dim Sucursal As String = String.Empty

    Dim strConnectionString As String = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString
    Dim dtValeCajaReport As New DataTable("ValesCaja")

    'Variable de verificación si es Instancia de Reporte de Costos de Venta en Detalle
    Dim bolCostosdeVenta As Boolean = False
    Dim dtCostosVentaReport As New DataTable("CostosdeVenta")

    'Variable de verificación si es Instancia de Reporte de Abonos Realizados CxC
    Dim bolAbonosCxC As Boolean = False
    Dim bolStatusAbonoCxC As Boolean = True
    Dim dtAbonosCxCReport As New DataTable("AbonosCxC")

    'Variable de verificación Reporte Vales de Caja Auditoria
    Dim bolRepoValesCajaAuditoria As Boolean = False

    'Variable de verificación Reporte Vales de Caja
    Dim bolRepoValesCaja As Boolean = False


#End Region

#Region "Form Methods"

    Private Sub ValesdeCajaReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ccDesde.Value = Date.Now
        ccHasta.Value = Date.Now

    End Sub

    Private Sub ccDesde_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ccDesde.Validating

        If ccDesde.Value > ccHasta.Value Then

            MsgBox("Fecha Inicial debe ser menor o igual a Fecha Final. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Vales de Caja")
            ccDesde.Value = Date.Now
            ccHasta.Value = Date.Now
            e.Cancel = True

        End If

    End Sub

    Private Sub ccHasta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ccHasta.Validating

        If ccHasta.Value < ccDesde.Value Then

            MsgBox("Fecha Final debe ser mayor o igual a Fecha Inicial. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Vales de Caja")
            ccHasta.Value = Date.Now
            e.Cancel = True

        End If

    End Sub

    Private Sub ValesdeCajaReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter
                SendKeys.Send("{TAB}")

            Case Keys.Escape
                Me.Finalize()
                Me.Close()

        End Select

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        If bolAbonosCxC Then

            ImprimeAbonosRealizadosCxC(0)

            Exit Sub

        End If

        If Not bolCostosdeVenta Then


            ImprimeExportaReporte(0)

        Else

            ImprimeExportaReporteCostosdeVenta(0)

        End If

    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        If bolAbonosCxC Then

            ImprimeAbonosRealizadosCxC(1)

            Exit Sub

        End If

        If Not bolCostosdeVenta Then

            ImprimeExportaReporte(1)

        Else

            ImprimeExportaReporteCostosdeVenta(1)

        End If

    End Sub

#End Region

#Region "Members Methods"

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

    Private Sub DefinitionTxRep()

        Rango = "De : " & Format(ccDesde.Value, "short date") & "   Al : " & Format(ccHasta.Value, "short date")
        Caja = "Caja # : " & oAppContext.ApplicationConfiguration.NoCaja
        Sucursal = "Sucursal : " & GetAlmacen()

    End Sub

#Region "Preview Report"

    Private Sub ImprimeExportaReporte(ByVal Tipo As Integer)        'Vales de Caja

        Me.Cursor = Cursors.WaitCursor

        If Me.rdbValesDisponibles.Checked AndAlso bolRepoValesCaja Then
            bolRepoValesCajaAuditoria = True
        ElseIf bolRepoValesCaja Then
            bolRepoValesCajaAuditoria = False
        End If

        If bolRepoValesCajaAuditoria Then
            dtValeCajaReport = SelectValeCajaReportSinUtilizar()
        Else

            dtValeCajaReport = SelectValeCajaReport()

        End If

        If dtValeCajaReport Is Nothing Then

            Me.Cursor = Cursors.Default
            MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Reporte de Notas de Crédito")

        Else

            If dtValeCajaReport.Rows.Count = 0 Then

                Me.Cursor = Cursors.Default
                MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Reporte de Notas de Crédito")

            Else

                If Tipo = 0 Then
                    Dim Titulo As String
                    If bolRepoValesCajaAuditoria Then
                        Titulo = "Reporte de Vales de Caja - Sin Utilizar"
                    ElseIf Me.rdbValesDevDinero.Checked Then
                        Titulo = "Reporte de Vales de Caja - Dev. de Efectivo"
                    ElseIf Me.rdbValesUsados.Checked Then
                        Titulo = "Reporte de Vales de Caja - Utilizados"
                    Else
                        Titulo = "Reporte de Vales de Caja"
                    End If


                    Dim oARReporte As New ValesdeCajaReport(ccDesde.Value, _
                                                            ccHasta.Value, _
                                                            GetAlmacen(), _
                                                            dtValeCajaReport, Titulo)
                    Dim oReportViewer As New ReportViewerForm


                    oARReporte.Document.Name = Titulo


                    oReportViewer.Report = oARReporte
                    oARReporte.Run()
                    Me.Cursor = Cursors.Default
                    oReportViewer.Show()

                Else

                ExportToExcel()

                End If


            End If

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ImprimeExportaReporteCostosdeVenta(ByVal Tipo As Integer)

        DefinitionTxRep()

        Me.Cursor = Cursors.WaitCursor

        dtCostosVentaReport = SelectCostosdeVentaReport()

        If dtCostosVentaReport Is Nothing Then

            Me.Cursor = Cursors.Default
            MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Costos de Venta")

        Else

            If dtCostosVentaReport.Rows.Count = 0 Then

                Me.Cursor = Cursors.Default
                MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Costos de Venta")

            Else

                If Tipo = 0 Then

                    Dim oARReporte As New CostosdeVentaDetalleReport(dtCostosVentaReport, Rango, Caja, Sucursal)

                    Dim oReportViewer As New ReportViewerForm
                    oARReporte.Document.Name = "Costos de Venta en Detalle"
                    oReportViewer.Report = oARReporte
                    Me.Cursor = Cursors.Default
                    oReportViewer.Show()

                Else

                    ExportToExcelCostosdeVenta()

                End If


            End If

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ImprimeAbonosRealizadosCxC(ByVal Tipo As Integer)

        DefinitionTxRep()

        Me.Cursor = Cursors.WaitCursor

        'dtAbonosCxCReport = SelectAbonosCxCReport()

        If dtAbonosCxCReport Is Nothing Then

            Me.Cursor = Cursors.Default
            MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Reporte de Abonos")

        Else

            If dtAbonosCxCReport.Rows.Count = 0 Then

                Me.Cursor = Cursors.Default
                MsgBox("No se cuenta con información en los rangos seleccionados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Reporte de Abonos")

            Else

                If Tipo = 0 Then

                    Dim oARReporte As New rptAbonosRealizadosCxC(dtAbonosCxCReport, Caja, Sucursal, Rango, bolStatusAbonoCxC)

                    Dim oReportViewer As New ReportViewerForm
                    If bolStatusAbonoCxC Then
                        oARReporte.Document.Name = "Reporte de Abonos - CxC"
                    Else
                        oARReporte.Document.Name = "Reporte de Abonos Cancelados - CxC"
                    End If
                    oReportViewer.Report = oARReporte
                    Me.Cursor = Cursors.Default
                    oReportViewer.Show()

                Else

                    Me.Cursor = Cursors.WaitCursor

                    ExportAbonosRealizadosCxC()

                    Me.Cursor = Cursors.Default

                End If

            End If


        End If

        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region "Export to Excel"

    Private Sub ExportToExcel()         'Vales de Caja

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
                MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Vales de Caja")
                Exit Sub
            End If
        Else
            xlapp = CreateObject("Excel.Application")
        End If

        wbxl = xlapp.Workbooks.Add
        wsxl = xlapp.Sheets(1)
        wsxl.Name = "Vales de Caja"

        '****************************************
        'HOJA DE CALCULO VALES DE CAJA
        '****************************************
        If bolRepoValesCajaAuditoria Then
            wsxl.Cells(1, 1).Value = "REPORTE DE VALES DE CAJA - SIN UTILIZAR"
        Else
            wsxl.Cells(1, 1).Value = "REPORTE DE VALES DE CAJA"
        End If
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:G1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:G1").BorderAround(, 2, 0, )
        wsxl.Range("A1:G1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 7).Value = "Fecha : " & Format(Date.Now, "short date")
        wsxl.Cells(2, 7).Font.Size = 10
        wsxl.Cells(2, 7).Font.Bold = True

        wsxl.Cells(3, 1).Value = "De : " & Format(ccDesde.Value, "dd/MM/yyyy") & " Al : " & Format(ccHasta.Value, "dd/MM/yyyy")
        wsxl.Cells(3, 1).Font.Size = 10
        wsxl.Cells(3, 1).Font.Bold = True
        wsxl.Range("A3:G3").Merge()
        wsxl.Cells(4, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(4, 1).Font.Size = 10
        wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Range("A4:G4").Merge()
        wsxl.Range("A3:G4").HorizontalAlignment = 3

        'Encabezado
        wsxl.Cells(6, 1).Value = "Origen"
        wsxl.Cells(6, 2).Value = "Folio"
        wsxl.Cells(6, 3).Value = "Sucursal"
        wsxl.Cells(6, 4).Value = "Caja"
        wsxl.Cells(6, 5).Value = "Fecha"
        wsxl.Cells(6, 6).Value = "Importe"
        wsxl.Cells(6, 7).Value = "Cliente"
        wsxl.Range("A6:G6").Font.Bold = True
        wsxl.Range("A6:G6").HorizontalAlignment = 3
        wsxl.Range("A6:G6").Font.Size = 8
        wsxl.Range("A6:G6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:G6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oRow In dtValeCajaReport.Rows
            intRow = intRow + 1
            wsxl.Cells(6 + intRow, 1).Value = "'" & oRow!Origen1 & " - " & oRow!Origen2
            wsxl.Cells(6 + intRow, 1).HorizontalAlignment = 4
            wsxl.Cells(6 + intRow, 2).Value = oRow!FolioVale
            wsxl.Cells(6 + intRow, 2).HorizontalAlignment = 4
            wsxl.Cells(6 + intRow, 3).Value = "'" & oAppContext.ApplicationConfiguration.Almacen
            wsxl.Cells(6 + intRow, 3).HorizontalAlignment = 3
            wsxl.Cells(6 + intRow, 4).Value = "'" & oRow!Caja
            wsxl.Cells(6 + intRow, 4).HorizontalAlignment = 3
            wsxl.Cells(6 + intRow, 5).Value = Format(oRow!Fecha, "short date")
            wsxl.Cells(6 + intRow, 5).HorizontalAlignment = 3
            wsxl.Cells(6 + intRow, 6).Value = oRow!Importe
            wsxl.Cells(6 + intRow, 6).HorizontalAlignment = 4
            wsxl.Cells(6 + intRow, 7).Value = oRow!Cliente
        Next

        wsxl.Cells(8 + intRow, 2).Value = "TOTALES :"
        wsxl.Cells(8 + intRow, 3).Value = dtValeCajaReport.Rows.Count
        wsxl.Cells(8 + intRow, 6).Value = "=SUMA(F7:F" & Trim(Str(6 + intRow)) & ")"
        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":G" & Trim(Str(8 + intRow))).BorderAround(, 2, 0, )
        wsxl.Range("F6:F" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":F" & Trim(Str(8 + intRow))).Font.Bold = True

        wsxl.Range("A6:A6").ColumnWidth = 12.86
        wsxl.Range("B6:B6").ColumnWidth = 10
        wsxl.Range("C6:C6").ColumnWidth = 8
        wsxl.Range("D6:D6").ColumnWidth = 6
        wsxl.Range("E6:E6").ColumnWidth = 10.5
        wsxl.Range("F6:F6").ColumnWidth = 14
        wsxl.Range("G6:G6").ColumnWidth = 35
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

    Private Sub ExportToExcelCostosdeVenta()

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
                MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Costos de Venta")
                Exit Sub
            End If
        Else
            xlapp = CreateObject("Excel.Application")
        End If

        wbxl = xlapp.Workbooks.Add
        wsxl = xlapp.Sheets(1)
        wsxl.Name = "Vales de Caja"

        '****************************************
        'HOJA DE CALCULO VALES DE CAJA
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE COSTOS DE VENTA EN DETALLE"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:K1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:K1").BorderAround(, 2, 0, )
        wsxl.Range("A1:K1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Value = "Fecha"
        wsxl.Cells(2, 2).Value = ": " & Format(Date.Now, "short date")
        wsxl.Cells(2, 2).Font.Size = 10
        wsxl.Cells(2, 2).Font.Bold = True

        wsxl.Cells(3, 1).Value = "Rango"
        wsxl.Cells(3, 2).Value = ": De " & Format(ccDesde.Value, "dd/MM/yyyy") & " Al " & Format(ccHasta.Value, "dd/MM/yyyy")
        wsxl.Cells(3, 2).Font.Size = 10
        wsxl.Cells(3, 2).Font.Bold = True

        wsxl.Cells(4, 1).Value = "Sucursal"
        wsxl.Cells(4, 2).Value = ": " & GetAlmacen()
        wsxl.Cells(4, 2).Font.Size = 10
        wsxl.Cells(4, 2).Font.Bold = True

        'Encabezado
        wsxl.Cells(6, 1).Value = "Folio"                'A'
        wsxl.Cells(6, 2).Value = "Código"               'B'
        wsxl.Cells(6, 3).Value = "Descripción"          'C'
        wsxl.Cells(6, 4).Value = "Cantidad"             'D'
        wsxl.Cells(6, 5).Value = "Talla"                'E'
        wsxl.Cells(6, 6).Value = "Importe"              'F'
        wsxl.Cells(6, 7).Value = "Total"                'G'
        wsxl.Cells(6, 8).Value = "Dscto."               'H'
        wsxl.Cells(6, 9).Value = "Cant. Dscto."         'I'
        wsxl.Cells(6, 10).Value = "Importe Neto"        'J'
        wsxl.Cells(6, 11).Value = "Costo"        'K'

        wsxl.Range("A6:K6").Font.Bold = True
        wsxl.Range("A6:K6").HorizontalAlignment = 3
        wsxl.Range("A6:K6").Font.Size = 8
        wsxl.Range("A6:K6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:K6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oRow In dtCostosVentaReport.Rows

            intRow = intRow + 1
            wsxl.Cells(6 + intRow, 1).Value = oRow!Folio
            wsxl.Cells(6 + intRow, 2).Value = oRow!Codigo
            wsxl.Cells(6 + intRow, 3).Value = oRow!Descripcion
            wsxl.Cells(6 + intRow, 4).Value = oRow!Cantidad
            wsxl.Cells(6 + intRow, 5).Value = oRow!Talla
            wsxl.Cells(6 + intRow, 6).Value = oRow!Importe
            wsxl.Cells(6 + intRow, 7).Value = oRow!Total
            wsxl.Cells(6 + intRow, 8).Value = Format(oRow!Descuento, "##0.00") & "%"
            wsxl.Cells(6 + intRow, 9).Value = oRow!CantidadDescuento
            wsxl.Cells(6 + intRow, 10).Value = oRow!CostoSNC
            wsxl.Cells(6 + intRow, 11).Value = oRow!CostoCNC

        Next

        wsxl.Cells(8 + intRow, 2).Value = "TOTALES :"
        wsxl.Cells(8 + intRow, 4).Value = "=SUMA(D7:D" & Trim(Str(6 + intRow)) & ")"
        wsxl.Cells(8 + intRow, 7).Value = "=SUMA(G7:G" & Trim(Str(6 + intRow)) & ")"
        wsxl.Cells(8 + intRow, 9).Value = "=SUMA(I7:I" & Trim(Str(6 + intRow)) & ")"
        wsxl.Cells(8 + intRow, 10).Value = "=SUMA(J7:J" & Trim(Str(6 + intRow)) & ")"
        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":K" & Trim(Str(8 + intRow))).BorderAround(, 2, 0, )
        wsxl.Range("I6:K" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        wsxl.Range("F6:G" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":K" & Trim(Str(8 + intRow))).Font.Bold = True

        wsxl.Range("A6:A6").ColumnWidth = 11
        wsxl.Range("B6:B6").ColumnWidth = 22.86
        wsxl.Range("C6:C6").ColumnWidth = 30.43
        wsxl.Range("D6:D6").ColumnWidth = 8
        wsxl.Range("E6:E6").ColumnWidth = 8
        wsxl.Range("F6:F6").ColumnWidth = 13
        wsxl.Range("G6:G6").ColumnWidth = 13
        wsxl.Range("H6:H6").ColumnWidth = 8
        wsxl.Range("I6:I6").ColumnWidth = 13
        wsxl.Range("J6:J6").ColumnWidth = 13
        wsxl.Range("K6:K6").ColumnWidth = 13
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

    Private Sub ExportAbonosRealizadosCxC()

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
                MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Costos de Venta")
                Exit Sub
            End If
        Else
            xlapp = CreateObject("Excel.Application")
        End If

        wbxl = xlapp.Workbooks.Add
        wsxl = xlapp.Sheets(1)
        wsxl.Name = "Vales de Caja"

        '****************************************
        'HOJA DE CALCULO ABONOS CxC
        '****************************************

        If bolStatusAbonoCxC Then
            wsxl.Cells(1, 1).Value = "REPORTE DE ABONOS A CUENTAS POR COBRAR"
        Else
            wsxl.Cells(1, 1).Value = "REPORTE DE ABONOS CANCELADOS A CUENTAS POR COBRAR"
        End If

        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:J1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:J1").BorderAround(, 2, 0, )
        wsxl.Range("A1:J1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Value = "Fecha"
        wsxl.Cells(2, 2).Value = ": " & Format(Date.Now, "short date")
        wsxl.Cells(2, 2).Font.Size = 10
        wsxl.Cells(2, 2).Font.Bold = True

        wsxl.Cells(2, 4).Value = "Caja #"
        wsxl.Cells(2, 5).Value = ": " & oAppContext.ApplicationConfiguration.NoCaja
        wsxl.Cells(2, 5).Font.Size = 10
        wsxl.Cells(2, 5).Font.Bold = True

        wsxl.Cells(3, 1).Value = "Sucursal"
        wsxl.Cells(3, 2).Value = ": " & GetAlmacen()
        wsxl.Cells(3, 2).Font.Size = 10
        wsxl.Cells(3, 2).Font.Bold = True

        wsxl.Cells(4, 1).Value = "Rango"
        wsxl.Cells(4, 2).Value = ": De " & Format(ccDesde.Value, "dd/MM/yyyy") & " Al " & Format(ccHasta.Value, "dd/MM/yyyy")
        wsxl.Cells(4, 2).Font.Size = 10
        wsxl.Cells(4, 2).Font.Bold = True


        'Encabezado
        wsxl.Cells(6, 1).Value = "Folio"            'A'
        wsxl.Cells(6, 2).Value = "Fecha"            'B'
        wsxl.Cells(6, 3).Value = "Factura"          'C'
        wsxl.Cells(6, 4).Value = "Fecha Fac."       'D'
        wsxl.Cells(6, 5).Value = "Cliente"          'E'
        wsxl.Cells(6, 6).Value = "F. Pago"          'F'
        wsxl.Cells(6, 7).Value = "Abono"            'G'
        wsxl.Cells(6, 8).Value = "Saldo"            'H'
        wsxl.Cells(6, 9).Value = "Usuario"          'I'
        wsxl.Cells(6, 10).Value = "Status"          'J'

        wsxl.Range("A6:J6").Font.Bold = True
        wsxl.Range("A6:J6").HorizontalAlignment = 3
        wsxl.Range("A6:J6").Font.Size = 8
        wsxl.Range("A6:J6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:J6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oRow In dtAbonosCxCReport.Rows

            intRow = intRow + 1
            wsxl.Cells(6 + intRow, 1).Value = oRow!AbonoID
            wsxl.Cells(6 + intRow, 2).Value = Format(oRow!Fecha, "Short Date")
            wsxl.cells(6 + intRow, 2).HorizontalAlignment = 3
            wsxl.Cells(6 + intRow, 3).Value = oRow!FolioFactura
            wsxl.Cells(6 + intRow, 4).Value = Format(oRow!FechaFactura, "Short Date")
            wsxl.cells(6 + intRow, 4).HorizontalAlignment = 3
            wsxl.Cells(6 + intRow, 5).Value = oRow!Cliente
            wsxl.Cells(6 + intRow, 6).Value = oRow!CodFormaPago
            wsxl.cells(6 + intRow, 6).HorizontalAlignment = 3
            wsxl.Cells(6 + intRow, 7).Value = oRow!Monto
            wsxl.Cells(6 + intRow, 8).Value = oRow!Saldo
            wsxl.Cells(6 + intRow, 9).Value = oRow!Usuario
            wsxl.Cells(6 + intRow, 10).Value = IIf(oRow!StatusRegistro, "A", "C")
            wsxl.cells(6 + intRow, 10).HorizontalAlignment = 3

        Next

        wsxl.Cells(8 + intRow, 2).Value = "TOTALES :"
        wsxl.Cells(8 + intRow, 7).Value = "=SUMA(G7:G" & Trim(Str(6 + intRow)) & ")"
        wsxl.Cells(8 + intRow, 8).Value = "=SUMA(H7:H" & Trim(Str(6 + intRow)) & ")"
        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":J" & Trim(Str(8 + intRow))).BorderAround(, 2, 0, )
        wsxl.Range("G6:H" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":J" & Trim(Str(8 + intRow))).Font.Bold = True

        wsxl.Range("A6:A6").ColumnWidth = 10
        wsxl.Range("B6:B6").ColumnWidth = 11
        wsxl.Range("C6:C6").ColumnWidth = 10
        wsxl.Range("D6:D6").ColumnWidth = 11
        wsxl.Range("E6:E6").ColumnWidth = 32
        wsxl.Range("F6:F6").ColumnWidth = 6
        wsxl.Range("G6:G6").ColumnWidth = 11
        wsxl.Range("H6:H6").ColumnWidth = 11
        wsxl.Range("I6:I6").ColumnWidth = 15
        wsxl.Range("J6:J6").ColumnWidth = 6
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

#End Region

#End Region

#Region "SQL Methods"

    Private Function SelectValeCajaReport() As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daValesCaja As SqlDataAdapter
        Dim dtValesCaja As New DataTable("ValesCaja")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            If Me.rdbValesDevDinero.Checked Then
                .CommandText = "[ValesdeCajaReporteSelDevDinero]"
            ElseIf Me.rdbValesUsados.Checked Then
                .CommandText = "[ValesdeCajaReporteSelUsados]"
            Else
                .CommandText = "[ValesdeCajaReporteSel]"
            End If

            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))

            .Parameters("@FechaInicial").Value = ccDesde.Value
            .Parameters("@FechaFinal").Value = ccHasta.Value

        End With

        daValesCaja = New SqlDataAdapter(sccmdSelect)

        Try

            daValesCaja.Fill(dtValesCaja)

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

        daValesCaja.Dispose()
        daValesCaja = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtValesCaja

    End Function

    Private Function SelectValeCajaReportSinUtilizar() As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daValesCaja As SqlDataAdapter
        Dim dtValesCaja As New DataTable("ValesCaja")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[ValesdeCajaReporteSinUtilizarSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))

            .Parameters("@FechaInicial").Value = ccDesde.Value
            .Parameters("@FechaFinal").Value = ccHasta.Value

        End With

        daValesCaja = New SqlDataAdapter(sccmdSelect)

        Try

            daValesCaja.Fill(dtValesCaja)

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

        daValesCaja.Dispose()
        daValesCaja = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtValesCaja

    End Function

    Private Function SelectCostosdeVentaReport() As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daCostosVenta As SqlDataAdapter
        Dim dtCostosVenta As New DataTable("CostosVenta")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[CostosdeVentasEnDetalleSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))

            .Parameters("@FechaInicial").Value = ccDesde.Value
            .Parameters("@FechaFinal").Value = ccHasta.Value

        End With

        daCostosVenta = New SqlDataAdapter(sccmdSelect)

        Try

            daCostosVenta.Fill(dtCostosVenta)

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

        daCostosVenta.Dispose()
        daCostosVenta = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtCostosVenta

    End Function

    'Private Function SelectAbonosCxCReport() As DataTable

    '    Dim oWSAbonos As New wsAbonoCreditoDirecto.AbonoCreditoDirectoX

    '    Dim dsAbonos As New DataSet

    '    If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

    '        oWSAbonos.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
    '        oWSAbonos.strURL.TrimStart("/")

    '    End If

    '    Return oWSAbonos.SelectAbonosCxC("002", ccDesde.Value, ccHasta.Value, oAppContext.ApplicationConfiguration.Almacen, bolStatusAbonoCxC).Tables(0)

    'End Function

#End Region

#Region "Show by Friend Modules"

    Public Sub ShowMeforCostosdeVenta()

        bolCostosdeVenta = True

        Me.Text = " Costos de Venta en Detalle"

        Me.Show()

    End Sub

    Public Sub ShowMeforAbonosCxC(ByVal StatusAbono As Boolean)

        bolAbonosCxC = True

        bolStatusAbonoCxC = StatusAbono

        If bolStatusAbonoCxC Then

            Me.Text = " Abonos Realizados - CxC"

        Else

            Me.Text = " Abonos Cancelados - CxC"

        End If

        Me.Show()

    End Sub

    Public Sub ShowMeforAuditoria()

        bolRepoValesCajaAuditoria = True

        Me.Text = "Vales de Caja (Sin utilizar)"

        Me.Show()

    End Sub

    Public Sub ShowMeforValeDeCaja()

        bolRepoValesCaja = True
        uIGroupBox1.Size = New Size(232, 176)

        Me.Size = New Size(272, 312)
        Me.btnGenerar.Location = New Point(16, 224)
        Me.btnExportar.Location = New Point(136, 224)

        Me.Text = " Reporte de Vale de Caja"

        Me.Show()

    End Sub
#End Region

   
End Class
