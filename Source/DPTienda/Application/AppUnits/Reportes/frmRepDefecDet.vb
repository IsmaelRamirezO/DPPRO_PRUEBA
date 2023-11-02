Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class frmRepDefecDet
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
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents dtFechaIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents dtFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepDefecDet))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.dtFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.dtFechaIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.UiGroupBox2)
        Me.explorerBar1.Controls.Add(Me.btnImprimir)
        Me.explorerBar1.Controls.Add(Me.btnExportar)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Filtros"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(424, 166)
        Me.explorerBar1.TabIndex = 1
        Me.explorerBar1.TabStop = False
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.Controls.Add(Me.dtFechaFin)
        Me.UiGroupBox2.Controls.Add(Me.dtFechaIni)
        Me.UiGroupBox2.Controls.Add(Me.lblLabel2)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Location = New System.Drawing.Point(16, 36)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(384, 48)
        Me.UiGroupBox2.TabIndex = 0
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'dtFechaFin
        '
        '
        '
        '
        Me.dtFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.dtFechaFin.Location = New System.Drawing.Point(248, 16)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.Size = New System.Drawing.Size(104, 20)
        Me.dtFechaFin.TabIndex = 7
        Me.dtFechaFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'dtFechaIni
        '
        '
        '
        '
        Me.dtFechaIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.dtFechaIni.Location = New System.Drawing.Point(48, 16)
        Me.dtFechaIni.Name = "dtFechaIni"
        Me.dtFechaIni.Size = New System.Drawing.Size(104, 20)
        Me.dtFechaIni.TabIndex = 6
        Me.dtFechaIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'lblLabel2
        '
        Me.lblLabel2.Location = New System.Drawing.Point(200, 20)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(40, 16)
        Me.lblLabel2.TabIndex = 5
        Me.lblLabel2.Text = "Hasta :"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "De :"
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(144, 112)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(128, 32)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(288, 112)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(128, 32)
        Me.btnExportar.TabIndex = 3
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.Visible = False
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmRepDefecDet
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 166)
        Me.Controls.Add(Me.explorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepDefecDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Defectuosos a Detalle"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim strConnectionString As String = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString
    Dim dtGlobal As New DataTable("Global")

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        dtGlobal = SelectGlobal(dtFechaIni.Value, dtFechaFin.Value)
        If dtGlobal.Rows.Count > 0 Then
            Imprimir()
        Else
            MsgBox("¡No se encontraron registros!", MsgBoxStyle.Information, Me.Text)
        End If

    End Sub

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

    Private Sub Imprimir()

        Dim oARReporte As New frmRepDefecDetAR(Me.dtFechaIni.Value, Me.dtFechaFin.Value, dtGlobal, GetAlmacen)
        Dim oReportViewer As New ReportViewerForm
        oARReporte.Document.Name = "Reportes de Articulos Defectuosos a Detalle"
        ''oARReporte.Document.Print(False, False)
        oReportViewer.Report = oARReporte
        Me.Cursor = Cursors.Default
        oReportViewer.Show()

    End Sub

    'Private Sub Exportar()

    '    Dim SaveDialog = New SaveFileDialog
    '    Dim strRuta As String = String.Empty

    '    Dim xlapp
    '    Dim wbxl
    '    Dim wsxl

    '    Dim intRow As Integer 'counter

    '    Dim oRow As DataRow

    '    On Error Resume Next

    '    xlapp = GetObject(, "Excel.Application")

    '    If xlapp Is Nothing Then
    '        xlapp = CreateObject("Excel.Application")
    '        If xlapp Is Nothing Then
    '            MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Auditoría de Retiros")
    '            Exit Sub
    '        End If
    '    Else
    '        xlapp = CreateObject("Excel.Application")
    '    End If

    '    wbxl = xlapp.Workbooks.Add
    '    wsxl = xlapp.Sheets(1)
    '    wsxl.Name = "Auditoria de Retiros"

    '    '****************************************
    '    'HOJA DE CALCULO REPORTES GLOBALES
    '    '****************************************
    '    wsxl.Cells(1, 1).Value = "REPORTE DE AUDITORIA DEL MES DE : " & cbMes.Text
    '    If UCase(cbTipoReporte.Text.Trim) = "TODAS" Then
    '        wsxl.Cells(2, 1).Value = "TODAS LAS MARCAS, LINEAS, FAMILIAS"
    '    Else
    '        If ebCodMarca.Text = String.Empty Then
    '            wsxl.Cells(2, 1).Value = "POR FAMILIA : " & ebFamilia.Text & " LINEA : " & ebLinea.Text
    '        Else
    '            wsxl.Cells(2, 1).Value = "POR MARCA : " & ebMarca.Text & " FAMILIA : " & ebFamilia.Text & " LINEA : " & ebLinea.Text
    '        End If
    '    End If
    '    wsxl.Range("A1:D1").Merge()
    '    wsxl.Range("A2:D2").Merge()
    '    wsxl.Range("A1:D2").Font.Bold = True
    '    wsxl.Range("A1:D1").Font.Size = 12
    '    wsxl.Range("A1:D2").Interior.Color = &HDFFFCC
    '    wsxl.Range("A1:D2").BorderAround(, 2, 0, )
    '    wsxl.Range("A1:D2").HorizontalAlignment = 3

    '    wsxl.Cells(3, 4).Value = Format(Date.Now, "short date")
    '    wsxl.Cells(3, 4).Font.Size = 10
    '    wsxl.Cells(3, 4).Font.Bold = True

    '    wsxl.Cells(4, 1).Value = "SUCURSAL : " & GetAlmacen()
    '    wsxl.Cells(4, 1).Font.Size = 10
    '    wsxl.Cells(4, 1).Font.Bold = True
    '    wsxl.Range("A4:D4").Merge()
    '    wsxl.Range("A4:D4").HorizontalAlignment = 3

    '    'Encabezado
    '    wsxl.Cells(6, 1).Value = "CODIGO"
    '    wsxl.Cells(6, 2).Value = "NOMBRE"
    '    wsxl.Cells(6, 3).Value = "CANTIDAD"
    '    wsxl.Cells(6, 4).Value = "COSTO"
    '    wsxl.Range("A6:D6").Font.Bold = True
    '    wsxl.Range("A6:D6").HorizontalAlignment = 3
    '    wsxl.Range("A6:D6").Font.Size = 8
    '    wsxl.Range("A6:D6").Interior.Color = RGB(255, 255, 192)
    '    wsxl.Range("A6:D6").BorderAround(, 2, 0, )

    '    intRow = 0

    '    For Each oRow In dtGlobal.Rows
    '        intRow = intRow + 1
    '        wsxl.Cells(6 + intRow, 1).Value = oRow!Codigo
    '        wsxl.Cells(6 + intRow, 1).HorizontalAlignment = 3
    '        wsxl.Cells(6 + intRow, 2).Value = oRow!Nombre
    '        wsxl.Cells(6 + intRow, 3).Value = oRow!Cantidad
    '        wsxl.Cells(6 + intRow, 4).Value = oRow!Costo
    '    Next

    '    wsxl.Cells(8 + intRow, 2).Value = "TOTALES :"
    '    wsxl.Cells(8 + intRow, 3).Value = "=SUMA(C7:C" & Trim(Str(6 + intRow)) & ")"
    '    wsxl.Cells(8 + intRow, 4).Value = "=SUMA(D7:D" & Trim(Str(6 + intRow)) & ")"
    '    wsxl.Range("A" & Trim(Str(8 + intRow)) & ":D" & Trim(Str(8 + intRow))).BorderAround(, 2, 0, )
    '    wsxl.Range("C6:C" & Trim(Str(8 + intRow))).NumberFormat = "###,###,##0"
    '    wsxl.Range("D6:D" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

    '    wsxl.Range("A" & Trim(Str(8 + intRow)) & ":D" & Trim(Str(8 + intRow))).Font.Bold = True

    '    wsxl.Range("A6:A6").ColumnWidth = 10
    '    wsxl.Range("B6:B6").ColumnWidth = 30
    '    wsxl.Range("C6:C6").ColumnWidth = 15
    '    wsxl.Range("D6:D6").ColumnWidth = 15
    '    wsxl.PageSetup.FitToPagesWide = 1
    '    wsxl.PageSetup.FitToPagesTall = 1

    '    Me.Cursor = Cursors.Default

    '    'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
    '    SaveDialog.DefaultExt = "*.xls"
    '    SaveDialog.Filter = "(*.xls)|*.xls"
    '    If SaveDialog.ShowDialog = DialogResult.OK Then
    '        wbxl.SaveAs(SaveDialog.FileName)
    '        MsgBox("Documento guardado en " & SaveDialog.FileName, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Repote Notas de Crédito")
    '    End If

    '    wbxl.Close()
    '    wsxl = Nothing
    '    xlapp.Quit()
    '    xlapp = Nothing

    '    KillExcel()

    'End Sub

#End Region

#Region "SQL Methods"

    Private Function SelectGlobal(ByVal dtFechaIni As DateTime, ByVal dtfechaFin As DateTime) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daGlobal As SqlDataAdapter
        Dim dtGlobal As New DataTable("Global")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[DefectuososSelRepDet]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))


            .Parameters("@FechaIni").Value = dtFechaIni.ToShortDateString
            .Parameters("@FechaFin").Value = dtfechaFin.ToShortDateString


        End With

        daGlobal = New SqlDataAdapter(sccmdSelect)

        Try

            daGlobal.Fill(dtGlobal)

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

            Me.Cursor = Cursors.Default

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de aplicación.", ex)

        End Try

        daGlobal.Dispose()
        daGlobal = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtGlobal

    End Function

#End Region

End Class
