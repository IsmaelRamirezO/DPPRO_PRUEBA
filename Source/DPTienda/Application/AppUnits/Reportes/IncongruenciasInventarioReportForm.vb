Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class IncongruenciasInventarioReportForm
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
    Friend WithEvents grdIncongruencia As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblLabel5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents grpGroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblResultado As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IncongruenciasInventarioReportForm))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grpGroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.lblLabel5 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.grdIncongruencia = New Janus.Windows.GridEX.GridEX()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.grpGroupBox1.SuspendLayout()
        CType(Me.grdIncongruencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.grpGroupBox1)
        Me.explorerBar1.Controls.Add(Me.lblLabel5)
        Me.explorerBar1.Controls.Add(Me.lblLabel2)
        Me.explorerBar1.Controls.Add(Me.lblLabel1)
        Me.explorerBar1.Controls.Add(Me.lblLabel4)
        Me.explorerBar1.Controls.Add(Me.btnGenerar)
        Me.explorerBar1.Controls.Add(Me.grdIncongruencia)
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(576, 520)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grpGroupBox1
        '
        Me.grpGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.grpGroupBox1.Controls.Add(Me.lblResultado)
        Me.grpGroupBox1.Location = New System.Drawing.Point(304, 8)
        Me.grpGroupBox1.Name = "grpGroupBox1"
        Me.grpGroupBox1.Size = New System.Drawing.Size(232, 38)
        Me.grpGroupBox1.TabIndex = 107
        Me.grpGroupBox1.TabStop = False
        '
        'lblResultado
        '
        Me.lblResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResultado.Location = New System.Drawing.Point(9, 13)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(216, 16)
        Me.lblResultado.TabIndex = 0
        Me.lblResultado.Text = "0 Códigos"
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel5.ForeColor = System.Drawing.Color.Black
        Me.lblLabel5.Location = New System.Drawing.Point(184, 488)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(88, 16)
        Me.lblLabel5.TabIndex = 106
        Me.lblLabel5.Text = "&Imprimir"
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.ForeColor = System.Drawing.Color.Black
        Me.lblLabel2.Location = New System.Drawing.Point(40, 488)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(84, 16)
        Me.lblLabel2.TabIndex = 105
        Me.lblLabel2.Text = "&Exportar"
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.ForeColor = System.Drawing.Color.Red
        Me.lblLabel1.Location = New System.Drawing.Point(160, 488)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel1.TabIndex = 104
        Me.lblLabel1.Text = "F9"
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.ForeColor = System.Drawing.Color.Red
        Me.lblLabel4.Location = New System.Drawing.Point(16, 488)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel4.TabIndex = 103
        Me.lblLabel4.Text = "F5"
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Icon = CType(resources.GetObject("btnGenerar.Icon"), System.Drawing.Icon)
        Me.btnGenerar.Location = New System.Drawing.Point(16, 13)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(152, 32)
        Me.btnGenerar.TabIndex = 0
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdIncongruencia
        '
        Me.grdIncongruencia.AlternatingColors = True
        Me.grdIncongruencia.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.Ivory
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdIncongruencia.DesignTimeLayout = GridEXLayout1
        Me.grdIncongruencia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdIncongruencia.GroupByBoxVisible = False
        Me.grdIncongruencia.Location = New System.Drawing.Point(16, 56)
        Me.grdIncongruencia.Name = "grdIncongruencia"
        Me.grdIncongruencia.Size = New System.Drawing.Size(520, 422)
        Me.grdIncongruencia.TabIndex = 1
        Me.grdIncongruencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'IncongruenciasInventarioReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(552, 511)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "IncongruenciasInventarioReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Incongruencias en el Inventario"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.grpGroupBox1.ResumeLayout(False)
        CType(Me.grdIncongruencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

    Dim strConnectionString As String = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    Dim dtIncongruenciaInventario As New DataTable("IncongruenciaInventario")

    Dim bolF9Exit As Boolean = False

#End Region

#Region "SQL"

    Private Function SelectIncongruenciaInventario() As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daIncongruencia As SqlDataAdapter
        Dim dtIncongruenciaTemp As New DataTable("IncongruenciaInventario")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[IncongruenciasInventarioSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        End With

        daIncongruencia = New SqlDataAdapter(sccmdSelect)

        Try

            daIncongruencia.Fill(dtIncongruenciaTemp)

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

        daIncongruencia.Dispose()
        daIncongruencia = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtIncongruenciaTemp

    End Function

#End Region

#Region "Methods"

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        dtIncongruenciaInventario = SelectIncongruenciaInventario()

        If dtIncongruenciaInventario Is Nothing Then

            lblResultado.Text = "0 Códigos"

            MsgBox("No se generaron incongruencias. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Incongruencias de Inventario")

        Else

            If dtIncongruenciaInventario.Rows.Count = 0 Then

                lblResultado.Text = "0 Códigos"
                MsgBox("No se generaron incongruencias. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Incongruencias de Inventario")

            Else

                lblResultado.Text = dtIncongruenciaInventario.Rows.Count.ToString & " Códigos"

                grdIncongruencia.DataSource = dtIncongruenciaInventario
                grdIncongruencia.Refresh()

            End If

        End If

    End Sub

    Private Sub IncongruenciasInventarioReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.F5    'Exportar

                If Not dtIncongruenciaInventario Is Nothing And dtIncongruenciaInventario.Rows.Count > 0 Then

                    Me.Cursor = Cursors.WaitCursor

                    ExportaIncongruencia()

                    Me.Cursor = Cursors.Default

                Else

                    MsgBox("No existen Códigos Incongruentes. No se puede exportar. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Incongruencias de Inventario")

                End If

            Case Keys.F9    'Imprimir

                ImprimeIncongruencia()

            Case Keys.Escape

                If bolF9Exit Or dtIncongruenciaInventario Is Nothing Or dtIncongruenciaInventario.Rows.Count = 0 Then

                    Me.Close()

                End If

        End Select

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

    Private Sub ImprimeIncongruencia()

        If Not dtIncongruenciaInventario Is Nothing And dtIncongruenciaInventario.Rows.Count > 0 Then

            Me.Cursor = Cursors.WaitCursor

            Dim oARReporte As New IncongruenciasInventarioReport(dtIncongruenciaInventario, GetAlmacen)
            Dim oReportViewer As New ReportViewerForm
            oARReporte.Document.Name = "Incongruencias en el Inventario"
            oReportViewer.Report = oARReporte

            Me.Cursor = Cursors.Default

            bolF9Exit = True

            oReportViewer.Show()

        Else

            MsgBox("No existen Códigos Incongruentes. No se puede imprimir. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Incongruencias de Inventario")

        End If

    End Sub

    Private Sub ExportaIncongruencia()

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
        wsxl.Name = "Incongruencia de Inventario"

        '****************************************
        'HOJA DE CALCULO VALES DE CAJA
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE CODIGOS CON PROBLEMAS EN HISTORICO"
        wsxl.Cells(2, 1).Value = "E INVENTARIO"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12
        wsxl.Cells(2, 1).Font.Bold = True
        wsxl.Cells(2, 1).Font.Size = 12

        wsxl.Range("A1:D1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:D1").BorderAround(, 2, 0, )
        wsxl.Range("A1:D1").HorizontalAlignment = 3

        wsxl.Range("A2:D2").Merge()
        wsxl.Cells(2, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A2:D2").BorderAround(, 2, 0, )
        wsxl.Range("A2:D2").HorizontalAlignment = 3

        wsxl.Cells(3, 1).Value = "Fecha"
        wsxl.Cells(3, 2).Value = ": " & Format(Date.Now, "short date")
        wsxl.Cells(3, 2).Font.Bold = True
        wsxl.Cells(4, 1).Value = "Sucursal"
        wsxl.Cells(4, 2).Font.Bold = True
        wsxl.Cells(4, 2).Value = ": " & GetAlmacen()
        
        'Encabezado
        wsxl.Cells(6, 1).Value = "SUCURSAL"
        wsxl.Cells(6, 2).Value = "CODIGO"
        wsxl.Cells(6, 3).Value = "HISTORICO"
        wsxl.Cells(6, 4).Value = "INVENTARIO"
        wsxl.Range("A6:D6").Font.Bold = True
        wsxl.Range("A6:D6").HorizontalAlignment = 3
        wsxl.Range("A6:D6").Font.Size = 8
        wsxl.Range("A6:D6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:D6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oRow In dtIncongruenciaInventario.Rows
            intRow = intRow + 1
            wsxl.Cells(6 + intRow, 1).Value = "'" & oRow!Sucursal
            wsxl.Cells(6 + intRow, 1).HorizontalAlignment = 3
            wsxl.Cells(6 + intRow, 2).Value = oRow!Codigo
            wsxl.Cells(6 + intRow, 3).Value = oRow!Historico
            wsxl.Cells(6 + intRow, 4).Value = oRow!Inventario
        Next

        wsxl.Cells(8 + intRow, 2).Value = "TOTALES :"
        wsxl.Cells(8 + intRow, 3).Value = dtIncongruenciaInventario.Rows.Count
        wsxl.Range("A" & Trim(Str(8 + intRow)) & ":D" & Trim(Str(8 + intRow))).BorderAround(, 2, 0, )

        wsxl.Range("A6:A6").ColumnWidth = 15
        wsxl.Range("B6:B6").ColumnWidth = 35
        wsxl.Range("C6:C6").ColumnWidth = 15
        wsxl.Range("D6:D6").ColumnWidth = 15
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

End Class
