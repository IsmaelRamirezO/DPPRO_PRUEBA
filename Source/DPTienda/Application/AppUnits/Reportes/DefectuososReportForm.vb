Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.Reports.Inventario
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU


Public Class DefectuososReportForm

    Inherits System.Windows.Forms.Form

    Dim strTituloReport As String = String.Empty

    Dim oReport As New InventarioReport
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Protected Friend WithEvents geResults As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Dim oReporter As New InventarioDefectuosos

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DefectuososReportForm))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.btImprimir = New Janus.Windows.EditControls.UIButton()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.geResults = New Janus.Windows.GridEX.GridEX()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BackgroundFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ExplorerBar1.BackgroundFormatStyle.BackColorGradient = System.Drawing.SystemColors.Control
        Me.ExplorerBar1.Controls.Add(Me.geResults)
        Me.ExplorerBar1.Controls.Add(Me.btnExportar)
        Me.ExplorerBar1.Controls.Add(Me.btImprimir)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.ItemsStateStyles.FormatStyle.BackgroundGradientMode = Janus.Windows.ExplorerBar.BackgroundGradientMode.DiagonalBackwards
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(439, 413)
        Me.ExplorerBar1.SpecialGroupsStateStyles.FormatStyle.BackgroundGradientMode = Janus.Windows.ExplorerBar.BackgroundGradientMode.Vertical
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        Me.ExplorerBar1.VisualStyleAreas.BackgroundStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(12, 24)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(107, 32)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btImprimir
        '
        Me.btImprimir.Enabled = False
        Me.btImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btImprimir.Image = CType(resources.GetObject("btImprimir.Image"), System.Drawing.Image)
        Me.btImprimir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Empty
        Me.btImprimir.Location = New System.Drawing.Point(166, 24)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(107, 32)
        Me.btImprimir.TabIndex = 2
        Me.btImprimir.Text = "&Imprimir"
        Me.btImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Empty
        Me.btnExportar.Location = New System.Drawing.Point(320, 24)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(107, 32)
        Me.btnExportar.TabIndex = 3
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'geResults
        '
        Me.geResults.AllowColumnDrag = False
        Me.geResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.geResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.geResults.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken
        Me.geResults.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        Me.geResults.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.geResults.DesignTimeLayout = GridEXLayout1
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.geResults.GroupByBoxVisible = False
        Me.geResults.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.geResults.Location = New System.Drawing.Point(12, 62)
        Me.geResults.Name = "geResults"
        Me.geResults.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.geResults.ShowEmptyFields = False
        Me.geResults.Size = New System.Drawing.Size(415, 339)
        Me.geResults.TabIndex = 6
        Me.geResults.TabStop = False
        Me.geResults.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'DefectuososReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(439, 413)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "DefectuososReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Reporte de Artículos Marcados como Defectuosos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Methods"

#Region "Form Methods"

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        ActionGenerate()

    End Sub

    Private Sub DefectuososReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter
                SendKeys.Send("{TAB}")

            Case Keys.Escape
                Me.Finalize()
                Me.Close()

        End Select

    End Sub

    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click

        If oReport.Data Is Nothing Then

            MsgBox("No se han seleccionado registros.", MsgBoxStyle.Exclamation)

            geResults.DataSource = Nothing

            Exit Sub

        End If

        ActionPreview()

    End Sub

#End Region

#Region "Action"

    Private Sub ActionGenerate()

        With oReporter

            .ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
            .Almacen = oAppContext.ApplicationConfiguration.Almacen

        End With

        oReport.CurrentReporter = oReporter

        oReport.Generate()

        If oReport.Data Is Nothing Then

            MsgBox("Los datos proporcionados no generaron registros.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Reporte de Inventarios")
            geResults.DataSource = Nothing
            btnExportar.Enabled = False
            btImprimir.Enabled = False
            Exit Sub

        End If

        btnExportar.Enabled = True
        btImprimir.Enabled = True
        geResults.SetDataBinding(oReport.Data, oReport.Data.Tables(0).TableName)

    End Sub

    Private Sub ActionPreview()

        Try

            If (oReport.Data Is Nothing) Then
                MsgBox("Necesita ejecutar el reporte antes de verlo preliminarmente.")
                Exit Sub
            End If

            Dim oARReporte As New DefectuososReport(oReporter, GetAlmacen())
            Dim oReportViewer As New ReportViewerForm

            oARReporte.PageSettings.Margins.Left = 0.5

            oARReporte.Run()
            oReportViewer.Report = oARReporte
            oReportViewer.Show()

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    Private Function GetAlmacen() As String
        '----------------------------------------------------------------------
        ' JNAVA (15.03.2016): Modificacion para mostrar datos de almacen
        '----------------------------------------------------------------------
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen = oAlmacenMgr.Create
        Dim strAlmacen As String = oAppContext.ApplicationConfiguration.Almacen
        Dim AlmacenDescripcion As String = String.Empty
        'oAlmacenMgr.LoadInto(strAlmacen, oAlmacen)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.Read_Centros)

        AlmacenDescripcion = strAlmacen & " " & oAlmacen.Descripcion

        oAlmacen = Nothing
        oAlmacenMgr = Nothing

        Return AlmacenDescripcion

    End Function

    Private Sub ExportaReporteDefectuosos()
        '------------------------------------------------------------------------------
        ' JNAVA (15.03.2016): Modificado para generar reporte correctamente
        '------------------------------------------------------------------------------
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
        wsxl.Name = "Defectuosos"

        '****************************************
        'HOJA DE CALCULO AUDITORIA RETIROS
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE ARTICULOS MARCADOS COMO DEFECTUOSOS"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:B1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:B1").BorderAround(, 2, 0, )
        wsxl.Range("A1:B1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 1).Value = "Fecha : " & Format(Date.Now, "Long Date")
        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(3, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(3, 1).Font.Size = 10
        wsxl.Cells(3, 1).Font.Bold = True
        wsxl.Range("A3:B3").Merge()
        wsxl.Range("A3:B3").HorizontalAlignment = 3

        'Encabezado
        wsxl.Cells(5, 1).Value = "Código / Descripción"
        'wsxl.Cells(5, 2).Value = "Color"
        wsxl.Cells(5, 2).Value = "Total"
        'wsxl.Cells(5, 3).Value = "Tallas / Existencias"

        wsxl.Range("A5:B5").Font.Bold = True
        wsxl.Range("A5:B5").HorizontalAlignment = 3
        wsxl.Range("A5:B5").Font.Size = 8
        wsxl.Range("A5:B5").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A5:B5").BorderAround(, 2, 0, )

        'wsxl.Range("C5:V5").Merge()

        intRow = 0

        For Each oRow In oReport.Data.Tables(0).Rows
            intRow = intRow + 1
            wsxl.Cells(5 + intRow, 1).Value = oRow!Codigo
            'wsxl.Cells(5 + intRow, 2).Value = oRow!Color
            wsxl.Cells(5 + intRow, 2).Value = oRow!TotalA
            'wsxl.Cells(5 + intRow, 3).Value = oRow!Talla01
            'wsxl.Cells(5 + intRow, 4).Value = oRow!Talla02
            'wsxl.Cells(5 + intRow, 5).Value = oRow!Talla03
            'wsxl.Cells(5 + intRow, 6).Value = oRow!Talla04
            'wsxl.Cells(5 + intRow, 7).Value = oRow!Talla05
            'wsxl.Cells(5 + intRow, 8).Value = oRow!Talla06
            'wsxl.Cells(5 + intRow, 9).Value = oRow!Talla07
            'wsxl.Cells(5 + intRow, 10).Value = oRow!Talla08
            'wsxl.Cells(5 + intRow, 11).Value = oRow!Talla09
            'wsxl.Cells(5 + intRow, 12).Value = oRow!Talla010
            'wsxl.Cells(5 + intRow, 13).Value = oRow!Talla011
            'wsxl.Cells(5 + intRow, 14).Value = oRow!Talla012
            'wsxl.Cells(5 + intRow, 15).Value = oRow!Talla013
            'wsxl.Cells(5 + intRow, 16).Value = oRow!Talla014
            'wsxl.Cells(5 + intRow, 17).Value = oRow!Talla015
            'wsxl.Cells(5 + intRow, 18).Value = oRow!Talla016
            'wsxl.Cells(5 + intRow, 19).Value = oRow!Talla017
            'wsxl.Cells(5 + intRow, 20).Value = oRow!Talla018
            'wsxl.Cells(5 + intRow, 21).Value = oRow!Talla019
            'wsxl.Cells(5 + intRow, 22).Value = oRow!Talla020
            If wsxl.Cells(5 + intRow, 1).Value <> "TOTAL DE PARES" Then
                'wsxl.Range("C" & Trim(Str(5 + intRow)) & ":B" & Trim(Str(5 + intRow))).Interior.Color = RGB(153, 204, 255)
            End If

            intRow = intRow + 1
            wsxl.Cells(5 + intRow, 1).Value = oRow!Descripcion
            'wsxl.Cells(5 + intRow, 3).Value = oRow!Total01
            'wsxl.Cells(5 + intRow, 4).Value = oRow!Total02
            'wsxl.Cells(5 + intRow, 5).Value = oRow!Total03
            'wsxl.Cells(5 + intRow, 6).Value = oRow!Total04
            'wsxl.Cells(5 + intRow, 7).Value = oRow!Total05
            'wsxl.Cells(5 + intRow, 8).Value = oRow!Total06
            'wsxl.Cells(5 + intRow, 9).Value = oRow!Total07
            'wsxl.Cells(5 + intRow, 10).Value = oRow!Total08
            'wsxl.Cells(5 + intRow, 11).Value = oRow!Total09
            'wsxl.Cells(5 + intRow, 12).Value = oRow!Total10
            'wsxl.Cells(5 + intRow, 13).Value = oRow!Total11
            'wsxl.Cells(5 + intRow, 14).Value = oRow!Total12
            'wsxl.Cells(5 + intRow, 15).Value = oRow!Total13
            'wsxl.Cells(5 + intRow, 16).Value = oRow!Total14
            'wsxl.Cells(5 + intRow, 17).Value = oRow!Total15
            'wsxl.Cells(5 + intRow, 18).Value = oRow!Total16
            'wsxl.Cells(5 + intRow, 19).Value = oRow!Total17
            'wsxl.Cells(5 + intRow, 20).Value = oRow!Total18
            'wsxl.Cells(5 + intRow, 21).Value = oRow!Total19
            'wsxl.Cells(5 + intRow, 22).Value = oRow!Total20
        Next

        wsxl.Range("A" & Trim(Str(4 + intRow)) & ":B" & Trim(Str(5 + intRow))).Font.Bold = True
        'wsxl.Range("C" & Trim(Str(4 + intRow)) & ":V" & Trim(Str(5 + intRow))).BackColor = RGB(255, 255, 255)

        wsxl.Range("A6:A6").ColumnWidth = 42.86
        wsxl.Range("B6:B6").ColumnWidth = 18.2
        'wsxl.Range("C6:C6").ColumnWidth = 11
        'wsxl.Range("C6:V6").ColumnWidth = 5.6
        wsxl.PageSetup.FitToPagesWide = 1
        wsxl.PageSetup.FitToPagesTall = 1

        Me.Cursor = Cursors.Default

        'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
        SaveDialog.DefaultExt = "*.xls"
        SaveDialog.Filter = "(*.xls)|*.xls"
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

#End Region

#End Region

    Private Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        ExportaReporteDefectuosos()


    End Sub

End Class
