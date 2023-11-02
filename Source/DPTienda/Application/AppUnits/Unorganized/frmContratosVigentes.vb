Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class frmContratosVigentes
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
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GrdTraspasos As Janus.Windows.GridEX.GridEX
    Friend WithEvents nbTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContratosVigentes))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.nbTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.ExplorerBar1.Controls.Add(Me.nbTotal)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.GrdTraspasos)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(738, 576)
        Me.ExplorerBar1.TabIndex = 3
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'nbTotal
        '
        Me.nbTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotal.BackColor = System.Drawing.Color.Ivory
        Me.nbTotal.Location = New System.Drawing.Point(632, 176)
        Me.nbTotal.Name = "nbTotal"
        Me.nbTotal.ReadOnly = True
        Me.nbTotal.Size = New System.Drawing.Size(88, 23)
        Me.nbTotal.TabIndex = 133
        Me.nbTotal.Text = "0"
        Me.nbTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotal.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(512, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Total Apartados"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(304, 184)
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
        Me.Label4.Location = New System.Drawing.Point(280, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 23)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "F5"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(40, 184)
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
        Me.Label21.Location = New System.Drawing.Point(24, 184)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 23)
        Me.Label21.TabIndex = 123
        Me.Label21.Text = "F9"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(184, 184)
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
        Me.Label13.Location = New System.Drawing.Point(160, 184)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 23)
        Me.Label13.TabIndex = 121
        Me.Label13.Text = "Esc"
        '
        'GrdTraspasos
        '
        Me.GrdTraspasos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GrdTraspasos.DesignTimeLayout = GridEXLayout1
        Me.GrdTraspasos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GrdTraspasos.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GrdTraspasos.GroupByBoxVisible = False
        Me.GrdTraspasos.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GrdTraspasos.Location = New System.Drawing.Point(16, 16)
        Me.GrdTraspasos.Name = "GrdTraspasos"
        Me.GrdTraspasos.Size = New System.Drawing.Size(704, 160)
        Me.GrdTraspasos.TabIndex = 4
        Me.GrdTraspasos.TableSpacing = 7
        Me.GrdTraspasos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmContratosVigentes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 210)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(736, 248)
        Me.MinimumSize = New System.Drawing.Size(736, 248)
        Me.Name = "frmContratosVigentes"
        Me.Text = "Contratos Vigentes"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.GrdTraspasos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private oContratosMgr As ContratoManager
    Private dsContratos As DataSet
    Private oClientesMgr As ClientesManager
    Private oClientes As Clientes

    Private Sub frmContratosVigentes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        oContratosMgr = New ContratoManager(oAppContext)
        oClientesMgr = New ClientesManager(oAppContext)

        sm_Abrir()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub sm_Abrir()

        Try
            dsContratos = oContratosMgr.ContratoVegentesSel

            If Not dsContratos Is Nothing Then


                Me.GrdTraspasos.DataSource = dsContratos
                Me.GrdTraspasos.DataMember = dsContratos.Tables(0).TableName

                Me.nbTotal.Value = dsContratos.Tables(0).Rows.Count

            Else

                MessageBox.Show("No se encontraron contratos vigentes", "DPTIenda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception

            Throw ex

        End Try



    End Sub

    Private Sub frmContratosVigentes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then

            Me.Close()

        ElseIf e.KeyCode = Keys.F9 Then

            Me.Cursor = Cursors.WaitCursor
            ActionPreview()
            Me.Cursor = Cursors.Default

        ElseIf e.KeyCode = Keys.F5 Then

            Me.Cursor = Cursors.WaitCursor
            ExportaApartadosDetalle()
            Me.Cursor = Cursors.Default



        End If

    End Sub

    Private Sub GrdTraspasos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdTraspasos.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub LlenarNombres()



        For Each row As DataRow In dsContratos.Tables(0).Rows
            oClientes = oClientesMgr.Create
            oClientesMgr.LoadInto(row("ClienteID"), oClientes)

            If Not oClientes.ClienteID = 0 Then

                row("Nombre") = oClientes.Nombre & " " & oClientes.ApellidoPaterno & " " & oClientes.ApellidoMaterno

            Else

                If row("ClienteID") = 1 Then

                    row("Nombre") = "PUBLICO EN GENERAL"

                End If

            End If
        Next


    End Sub

    Public Sub ActionPreview()
        Try
            If Not Me.dsContratos Is Nothing Then
                LlenarNombres()

                Dim dsReporte As New DataSet
                dsReporte = Me.dsContratos.Clone

                For Each row As DataRow In Me.dsContratos.Tables(0).Rows
                    Dim custDV As New DataView(dsReporte.Tables(0), "FolioApartado =" & row("FolioApartado"), "FolioApartado", DataViewRowState.CurrentRows)

                    If Not custDV.Count > 0 Then
                        dsReporte.Tables(0).ImportRow(row)
                    End If

                Next

                Dim oARReporte As New rptContratosVigentes(dsReporte)
                Dim oReportViewer As New ReportViewerForm



                oARReporte.Document.Name = "Contratos Vigentes"
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

    Private Sub ExpExcel()
        Try
            Me.Cursor = Cursors.WaitCursor
            If (Me.GrdTraspasos.RowCount) > 0 Then

                LlenarNombres()

                Dim oExcel
                Dim Fila, Columna, cont, iCol, XColumna As Integer
                Dim Path, variable As String
                Dim item As DataGridCell
                Dim columnas As DataGridCell
                oExcel = CreateObject("OWC.Spreadsheet")

                ''Encabezado

                oExcel.Cells(1, 1).Value = "Folio"
                oExcel.Columns(1).AutoFitColumns()

                oExcel.Cells(1, 2).Value = "Codigo"
                oExcel.Columns(1).AutoFitColumns()

                oExcel.Cells(1, 3).Value = "Talla"
                oExcel.Columns(1).AutoFitColumns()

                oExcel.Cells(1, 4).Value = "Cantidad"
                oExcel.Columns(1).AutoFitColumns()

                oExcel.Cells(1, 5).Value = "Fecha"
                oExcel.Columns(1).AutoFitColumns()

                oExcel.Cells(1, 6).Value = "Vendedor"
                oExcel.Columns(1).AutoFitColumns()

                oExcel.Cells(1, 7).Value = "ClienteID"
                oExcel.Columns(1).AutoFitColumns()

                oExcel.Cells(1, 8).Value = "Nombre"
                oExcel.Columns(1).AutoFitColumns()

                oExcel.Cells(1, 9).Value = "Importe"
                oExcel.Columns(1).AutoFitColumns()

                oExcel.Cells(1, 10).Value = "Saldo"
                oExcel.Columns(1).AutoFitColumns()

                oExcel.Cells(1, 11).Value = "Entregada"
                oExcel.Columns(1).AutoFitColumns()

                '' Fin Encabezado

                Dim i As Integer = 2

                For Each objRow As DataRow In Me.dsContratos.Tables(0).Rows


                    '' Asignar los valores de los registros a las celdas

                    oExcel.Cells(i, 1) = "'" & objRow.Item("FolioApartado")
                    oExcel.Cells(i, 2) = "'" & objRow.Item("CodArticulo")
                    oExcel.Cells(i, 3) = "'" & objRow.Item("Numero")
                    oExcel.Cells(i, 4) = "'" & objRow.Item("Cantidad")
                    oExcel.Cells(i, 5) = "'" & objRow.Item("Fecha")
                    oExcel.Cells(i, 6) = "'" & objRow.Item("CodVendedor")
                    oExcel.Cells(i, 7) = "'" & objRow.Item("ClienteID")
                    oExcel.Cells(i, 8) = "'" & objRow.Item("Nombre")
                    oExcel.Cells(i, 9) = "'" & objRow.Item("ITotal")
                    oExcel.Cells(i, 10) = "'" & objRow.Item("Saldo")
                    oExcel.Cells(i, 11) = "'" & objRow.Item("Entregada")

                    '' Avanzamos una fila

                    i += 1

                Next


                'Damos algo de formato a la primera línea de la hoja 
                cont = 1
                Do While cont <= 11
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

    Private Sub ExportaApartadosDetalle()

        Dim SaveDialog = New SaveFileDialog
        Dim strRuta As String = String.Empty
        Dim isExcelOpen As Boolean = False

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
        wsxl.Name = "APARTADOS VIGENTES"

        'wsxl.PageSetup.Orientation = 2
        '****************************************
        'HOJA DE CALCULO APARTADOS VIGENTES
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE APARTADOS VIGENTES"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:K1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:K1").BorderAround(, 2, 0, )
        wsxl.Range("A1:K1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 11).Value = Format(Date.Now, "short date")
        wsxl.Cells(2, 11).Font.Size = 10
        wsxl.Cells(2, 11).Font.Bold = True

        wsxl.Cells(4, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(4, 1).Font.Size = 10
        wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Range("A4:K4").Merge()
        wsxl.Range("A3:K4").HorizontalAlignment = 3

        ''Encabezado

        wsxl.Cells(6, 1).Value = "Folio"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 2).Value = "Codigo"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 3).Value = "Talla"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 4).Value = "Cantidad"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 5).Value = "Fecha"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 6).Value = "Vendedor"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 7).Value = "ClienteID"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 8).Value = "Nombre"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 9).Value = "Importe"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 10).Value = "Saldo"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 11).Value = "Entregada"
        wsxl.Columns(1).AutoFitColumns()


        '' Fin Encabezado

        wsxl.Range("A6:K6").Font.Bold = True
        wsxl.Range("A6:K6").HorizontalAlignment = 3
        wsxl.Range("A6:K6").Font.Size = 8
        wsxl.Range("A6:K6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:K6").BorderAround(, 2, 0, )

        intRow = 0

        Dim i As Integer = 1

        For Each objRow As DataRow In Me.dsContratos.Tables(0).Rows


            '' Asignar los valores de los registros a las celdas

            wsxl.Cells(i + 6, 1) = "'" & objRow.Item("FolioApartado")
            wsxl.Cells(i + 6, 2) = "'" & objRow.Item("CodArticulo")
            wsxl.Cells(i + 6, 3).Value = objRow.Item("Numero")
            wsxl.Cells(i + 6, 4).Value = objRow.Item("Cantidad")
            wsxl.Cells(i + 6, 5) = "'" & Format(objRow.Item("Fecha"), "dd/MM/yyyy")
            wsxl.Cells(i + 6, 6) = "'" & objRow.Item("CodVendedor")
            wsxl.Cells(i + 6, 7).Value = "'" & objRow.Item("ClienteID")
            wsxl.Cells(i + 6, 8) = "'" & objRow.Item("Nombre")
            wsxl.Cells(i + 6, 9).Value = Format(objRow.Item("ITotal"), "c")
            wsxl.Cells(i + 6, 10).Value = Format(objRow.Item("Saldo"), "c")
            wsxl.Cells(i + 6, 11) = "'" & objRow.Item("Entregada")

            '' Avanzamos una fila

            i += 1

        Next


        wsxl.Cells(8 + i, 2).Value = "TOTAL APARTADOS :"
        wsxl.Cells(8 + i, 3).Value = Me.dsContratos.Tables(0).Rows.Count

        For i = 1 To 13
            wsxl.Columns(i).AutoFitColumns()
        Next


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
