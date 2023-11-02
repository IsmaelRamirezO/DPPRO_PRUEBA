Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports Janus.Windows.GridEX
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class frmAbonosContratosCancelados
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nbTotalapartados As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
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
    Friend WithEvents GrdTraspasos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbCajas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbonosContratosCancelados))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cmbCajas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nbTotalapartados = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
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
        Me.GrdTraspasos = New Janus.Windows.GridEX.GridEX()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.GrdTraspasos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.cmbCajas)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.nbTotalapartados)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
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
        Me.ExplorerBar1.Controls.Add(Me.GrdTraspasos)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(528, 325)
        Me.ExplorerBar1.TabIndex = 6
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cmbCajas
        '
        Me.cmbCajas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbCajas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbCajas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbCajas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbCajas.DesignTimeLayout = GridEXLayout1
        Me.cmbCajas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCajas.Location = New System.Drawing.Point(72, 16)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.ReadOnly = True
        Me.cmbCajas.Size = New System.Drawing.Size(128, 22)
        Me.cmbCajas.TabIndex = 139
        Me.cmbCajas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbCajas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(16, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 23)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "Caja:"
        '
        'nbTotalapartados
        '
        Me.nbTotalapartados.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalapartados.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalapartados.BackColor = System.Drawing.Color.Ivory
        Me.nbTotalapartados.Location = New System.Drawing.Point(136, 264)
        Me.nbTotalapartados.Name = "nbTotalapartados"
        Me.nbTotalapartados.ReadOnly = True
        Me.nbTotalapartados.Size = New System.Drawing.Size(75, 23)
        Me.nbTotalapartados.TabIndex = 133
        Me.nbTotalapartados.TabStop = False
        Me.nbTotalapartados.Text = "0"
        Me.nbTotalapartados.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalapartados.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbTotalapartados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(16, 264)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 23)
        Me.Label5.TabIndex = 132
        Me.Label5.Text = "Total Abonos.:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(296, 296)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Exportar"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(272, 296)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 23)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "F5"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(208, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Desde"
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(408, 48)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ccbHasta
        '
        '
        '
        '
        Me.ccbHasta.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccbHasta.Location = New System.Drawing.Point(264, 48)
        Me.ccbHasta.Name = "ccbHasta"
        Me.ccbHasta.Size = New System.Drawing.Size(128, 23)
        Me.ccbHasta.TabIndex = 2
        Me.ccbHasta.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ccmbDesde
        '
        '
        '
        '
        Me.ccmbDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccmbDesde.Location = New System.Drawing.Point(72, 48)
        Me.ccmbDesde.Name = "ccmbDesde"
        Me.ccmbDesde.Size = New System.Drawing.Size(128, 23)
        Me.ccmbDesde.TabIndex = 1
        Me.ccmbDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(32, 296)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 23)
        Me.Label22.TabIndex = 124
        Me.Label22.Text = "Imprimir"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(16, 296)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 23)
        Me.Label21.TabIndex = 123
        Me.Label21.Text = "F9"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(176, 296)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 23)
        Me.Label16.TabIndex = 122
        Me.Label16.Text = "Salir"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(152, 296)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 23)
        Me.Label13.TabIndex = 121
        Me.Label13.Text = "Esc"
        '
        'GrdTraspasos
        '
        Me.GrdTraspasos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.GrdTraspasos.DesignTimeLayout = GridEXLayout2
        Me.GrdTraspasos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GrdTraspasos.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GrdTraspasos.GroupByBoxVisible = False
        Me.GrdTraspasos.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GrdTraspasos.Location = New System.Drawing.Point(16, 88)
        Me.GrdTraspasos.Name = "GrdTraspasos"
        Me.GrdTraspasos.Size = New System.Drawing.Size(504, 160)
        Me.GrdTraspasos.TabIndex = 4
        Me.GrdTraspasos.TableSpacing = 7
        Me.GrdTraspasos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmAbonosContratosCancelados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 325)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.Name = "frmAbonosContratosCancelados"
        Me.Text = "Reporte de Abonos Cancelados"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.GrdTraspasos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private dsTraspasos As DataSet
    Private oAbonosApartadosMgr As AbonosApartadosManager
    Private oCajasMgr As CatalogoCajaManager
    Private dsCajas As DataSet



    Public Sub ActionPreview()
        Try
            If Not Me.dsTraspasos Is Nothing Then

                Dim oARReporte As New rptAbonosCancelados(Me.dsTraspasos, Me.ccmbDesde.Value, Me.ccbHasta.Value, Me.cmbCajas.Value)
                Dim oReportViewer As New ReportViewerForm

                oARReporte.Document.Name = "Abonos Contratos"
                oARReporte.Run()

                oReportViewer.Report = oARReporte
                oReportViewer.Show()

                Try

                    'oARReporte.Document.Print(True, True)

                Catch ex As Exception

                    Throw ex

                End Try

            End If

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    Public Sub ExportExcel()
        Try
            Me.Cursor = Cursors.WaitCursor
            If (Me.GrdTraspasos.RowCount) > 0 Then
                Dim oExcel
                Dim Fila, Columna, cont, iCol, XColumna As Integer
                Dim Path, variable As String
                Dim item As DataGridCell
                Dim columnas As DataGridCell
                oExcel = CreateObject("OWC.Spreadsheet")

                Fila = 0
                Columna = 0

                While Columna < Me.GrdTraspasos.RootTable.Columns.Count
                    oExcel.Cells(1, Columna + 1).Value = Me.GrdTraspasos.RootTable.Columns(Columna).Caption
                    oExcel.Columns(Columna + 1).AutoFitColumns()
                    Columna = Columna + 1
                End While

                For Each oCurrentRow As GridEXRow In Me.GrdTraspasos.GetRows

                    Dim odrDataRow As DataRowView
                    odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

                    For Each column As DataColumn In odrDataRow.DataView.Table.Columns
                        Try

                            oExcel.Cells(oCurrentRow.Position + 2, Me.GrdTraspasos.RootTable.Columns(column.ColumnName).Position + 1).value = _
                               "'" & odrDataRow(column.ColumnName)

                        Catch ex As Exception
                            Try

                                oExcel.Cells(oCurrentRow.Position + 2, Me.GrdTraspasos.RootTable.Columns(column.ColumnName).Position + 1).value = _
                                 odrDataRow(column.ColumnName)

                            Catch ex2 As Exception

                                oExcel.Cells(oCurrentRow.Position + 2, Me.GrdTraspasos.RootTable.Columns(column.ColumnName).Position + 1).value = _
                                "'###Error###'"

                            End Try

                        End Try

                    Next
                Next

                'Damos algo de formato a la primera línea de la hoja 
                cont = 1
                Do While cont <= Columna
                    oExcel.Cells(1, cont).Font.Bold = True
                    oExcel.Cells(1, cont).Font.Size = 10
                    oExcel.Cells(1, cont).Font.Name = "Arial"
                    oExcel.Columns(cont).AutoFitColumns()
                    cont = cont + 1
                Loop

                'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
                Dim SaveDialog = New SaveFileDialog
                SaveDialog.DefaultExt = "*.xls"
                SaveDialog.Filter = "(*.xls)|*.xls"

                If SaveDialog.ShowDialog = DialogResult.OK Then
                    Try
                        oExcel.ActiveSheet.Export(SaveDialog.FileName, 0)
                        MessageBox.Show("Documento Guardado Como : " & SaveDialog.FileName, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("No se Puede Procesar, El Archivo puede que se encuentre abierto, Verifique")
                    End Try
                End If
            End If

            Me.Cursor = Cursors.Default

        Catch ex As System.NullReferenceException
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub frmReporteAbonos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        Me.ccmbDesde.MaxDate = ccbHasta.Value
        ccbHasta.MinDate = Me.ccmbDesde.Value

        oAbonosApartadosMgr = New AbonosApartadosManager(oAppContext)


        oCajasMgr = New CatalogoCajaManager(oAppContext)
        dsCajas = oCajasMgr.GetAll(False).Copy
        Dim oRow As DataRow = dsCajas.Tables(0).NewRow

        oRow("CodCaja") = "Td"
        oRow("Descripcion") = "Todas"
        Me.dsCajas.Tables(0).Rows.Add(oRow)

        With Me.cmbCajas

            .DataSource = dsCajas
            .DataMember = dsCajas.Tables(0).TableName
            .DropDownList.Columns.Add("CodCaja")
            .DropDownList.Columns.Add("Descripcion")
            '.DropDownList.Columns("CodCaja").Visible = False
            .DropDownList.Columns("CodCaja").DataMember = "CodCaja"
            .DropDownList.Columns("Descripcion").DataMember = "Descripcion"
            .DropDownList.Columns("Descripcion").Width = 170

            .DisplayMember = "Descripcion"
            .ValueMember = "CodCaja"

            .Refresh()

        End With

        cmbCajas.Value = oAppContext.ApplicationConfiguration.NoCaja

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub frmReporteAbonos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F9 Then
            Me.Cursor = Cursors.WaitCursor
            ActionPreview()
            Me.Cursor = Cursors.Default

        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        ElseIf e.KeyCode = Keys.F5 Then

            Me.Cursor = Cursors.WaitCursor
            ExportarAbonos()
            Me.Cursor = Cursors.Default

        ElseIf e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub GrdTraspasos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdTraspasos.KeyDown

        If e.KeyCode = Keys.Escape Then

            Me.Close()

        End If

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Me.Cursor = Cursors.WaitCursor

        If Not Me.cmbCajas.Text = String.Empty Then

            Me.dsTraspasos = oAbonosApartadosMgr.SelectByDateCancelados(Me.ccmbDesde.Value, Me.ccbHasta.Value, Me.cmbCajas.Value)

            If dsTraspasos.Tables(0).Rows.Count > 0 Then
                Me.dsTraspasos.AcceptChanges()
                Me.GrdTraspasos.DataSource = dsTraspasos
                Me.GrdTraspasos.DataMember = dsTraspasos.Tables(0).TableName
                Me.nbTotalapartados.Value = dsTraspasos.Tables(0).Rows.Count

                'MessageBox.Show("Listo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                Me.dsTraspasos.RejectChanges()

                MessageBox.Show("Los datos proporcionados no arrojaron resultados", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Else

            MessageBox.Show("Seleccione Caja", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub ExportarAbonos()

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
        wsxl.Name = "REPORTE DE ABONOS CANCELADOS"

        '****************************************
        'HOJA DE CALCULO APARTADOS EN TOTALES
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE ABONOS CANCELADOS DE LA CAJA No." & Me.cmbCajas.Value
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:I1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:I1").BorderAround(, 2, 0, )
        wsxl.Range("A1:I1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 9).Value = Format(Date.Now, "short date")
        wsxl.Cells(2, 9).Font.Size = 10
        wsxl.Cells(2, 9).Font.Bold = True

        wsxl.Cells(4, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(4, 1).Font.Size = 10
        wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Range("A4:I4").Merge()
        wsxl.Range("A3:I4").HorizontalAlignment = 3

        If Me.cmbCajas.Value = "Td" Then
            wsxl.Cells(2, 1).Value = "Caja #: Todas"
        Else
            wsxl.Cells(2, 1).Value = "Caja #: " & Me.cmbCajas.Value
        End If

        'Encabezado
        Dim Columna As Integer = 0
        While Columna < Me.GrdTraspasos.RootTable.Columns.Count
            wsxl.Cells(6, Columna + 1).Value = Me.GrdTraspasos.RootTable.Columns(Columna).Caption
            wsxl.Columns(Columna + 1).AutoFitColumns()
            Columna = Columna + 1
        End While

        wsxl.Range("A6:I6").Font.Bold = True
        wsxl.Range("A6:I6").HorizontalAlignment = 3
        wsxl.Range("A6:I6").Font.Size = 8
        wsxl.Range("A6:I6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:I6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oCurrentRow As GridEXRow In Me.GrdTraspasos.GetRows

            Dim odrDataRow As DataRowView
            odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

            For Each column As DataColumn In odrDataRow.DataView.Table.Columns

                wsxl.Cells(oCurrentRow.Position + 7, Me.GrdTraspasos.RootTable.Columns(column.ColumnName).Position + 1).value = _
                  odrDataRow(column.ColumnName)
            Next
            intRow += 1
        Next


        wsxl.Cells(8 + intRow, 2).Value = "TOTAL ABONOS:"
        wsxl.Cells(8 + intRow, 3).Value = Me.nbTotalapartados.Value
        wsxl.Range("F7:F" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        wsxl.Range("G7:G" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        wsxl.Cells(8 + intRow, 6).Value = "=SUMA(F7:F" & Trim(Str(7 + intRow)) & ")"
        wsxl.Cells(8 + intRow, 7).Value = "=SUMA(G7:G" & Trim(Str(7 + intRow)) & ")"

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

End Class
