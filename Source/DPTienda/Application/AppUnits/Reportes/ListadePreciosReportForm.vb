Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class ListadePreciosReportForm

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
    Friend WithEvents gbOpciones As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cbOpciones As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents gdInfo As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadePreciosReportForm))
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem7 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.gdInfo = New Janus.Windows.GridEX.GridEX()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.gbOpciones = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.cbOpciones = New Janus.Windows.EditControls.UIComboBox()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.gdInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.gdInfo)
        Me.explorerBar1.Controls.Add(Me.btnExportar)
        Me.explorerBar1.Controls.Add(Me.btnImprimir)
        Me.explorerBar1.Controls.Add(Me.btnGenerar)
        Me.explorerBar1.Controls.Add(Me.gbOpciones)
        Me.explorerBar1.Location = New System.Drawing.Point(-8, -8)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(872, 504)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'gdInfo
        '
        Me.gdInfo.AlternatingColors = True
        Me.gdInfo.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.White
        Me.gdInfo.AlternatingRowFormatStyle.BackColorGradient = System.Drawing.Color.AliceBlue
        Me.gdInfo.AlternatingRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gdInfo.DesignTimeLayout = GridEXLayout1
        Me.gdInfo.GroupByBoxVisible = False
        Me.gdInfo.Location = New System.Drawing.Point(16, 88)
        Me.gdInfo.Name = "gdInfo"
        Me.gdInfo.Size = New System.Drawing.Size(712, 376)
        Me.gdInfo.TabIndex = 5
        Me.gdInfo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(600, 34)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(112, 32)
        Me.btnExportar.TabIndex = 4
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnImprimir
        '
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(472, 34)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(112, 32)
        Me.btnImprimir.TabIndex = 3
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(344, 34)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(112, 32)
        Me.btnGenerar.TabIndex = 2
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'gbOpciones
        '
        Me.gbOpciones.BackColor = System.Drawing.Color.Transparent
        Me.gbOpciones.Controls.Add(Me.lblLabel1)
        Me.gbOpciones.Controls.Add(Me.cbOpciones)
        Me.gbOpciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOpciones.Location = New System.Drawing.Point(16, 16)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(712, 64)
        Me.gbOpciones.TabIndex = 1
        Me.gbOpciones.Text = " Opciones "
        Me.gbOpciones.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'lblLabel1
        '
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(16, 28)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(88, 16)
        Me.lblLabel1.TabIndex = 7
        Me.lblLabel1.Text = "Tipo Reporte :"
        '
        'cbOpciones
        '
        Me.cbOpciones.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "Precios Sin IVA"
        UiComboBoxItem1.Value = CType(0, Short)
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "Precios Con IVA"
        UiComboBoxItem2.Value = CType(1, Short)
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "ORO"
        UiComboBoxItem3.Value = CType(2, Short)
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "ORO 2"
        UiComboBoxItem4.Value = CType(3, Short)
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "ORO 3"
        UiComboBoxItem5.Value = CType(4, Short)
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "PLATA"
        UiComboBoxItem6.Value = CType(5, Short)
        UiComboBoxItem7.FormatStyle.Alpha = 0
        UiComboBoxItem7.IsSeparator = False
        UiComboBoxItem7.Text = "DIP's"
        UiComboBoxItem7.Value = CType(6, Short)
        Me.cbOpciones.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5, UiComboBoxItem6, UiComboBoxItem7})
        Me.cbOpciones.Location = New System.Drawing.Point(112, 25)
        Me.cbOpciones.Name = "cbOpciones"
        Me.cbOpciones.Size = New System.Drawing.Size(168, 21)
        Me.cbOpciones.TabIndex = 6
        Me.cbOpciones.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ListadePreciosReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(730, 463)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ListadePreciosReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Lista de Precios"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.gdInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dtInfo As DataTable
    Dim strConnectionString As String = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    Private Sub ListadePreciosReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbOpciones.SelectedIndex = 0

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        dtInfo = GeneraInfo(cbOpciones.SelectedItem.Value)

        If dtInfo Is Nothing Then

            MsgBox("La operación no produjo resultados.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Lista de Precios")

        Else

            If dtInfo.Rows.Count > 0 Then
                btnExportar.Enabled = True
                btnImprimir.Enabled = True
            Else
                btnExportar.Enabled = False
                btnImprimir.Enabled = False
            End If

            ShowInfo()

        End If

    End Sub

    Private Function GeneraInfo(ByVal tipoRep As Integer) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daInfo As SqlDataAdapter
        Dim dtInfoTemp As New DataTable("Precios")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[ListadePreciosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoReporte", System.Data.SqlDbType.Int, 4))

            .Parameters("@TipoReporte").Value = tipoRep

        End With

        daInfo = New SqlDataAdapter(sccmdSelect)

        Try

            daInfo.Fill(dtInfoTemp)

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

        daInfo.Dispose()
        daInfo = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtInfoTemp

    End Function

    Private Sub ShowInfo()

        gdInfo.DataSource = dtInfo
        gdInfo.RetrieveStructure()

        'FormateaGrid()

        FormatGeneral()

    End Sub

    'Private Sub FormateaGrid()

    '    Select Case cbOpciones.SelectedItem.Value

    '        Case 0

    '            FormatGeneral()

    '        Case Else

    '            FormatOtros()

    '    End Select

    'End Sub

    'Private Sub FormatOtros()

    '    With gdInfo.RootTable.Columns

    '        If cbOpciones.SelectedItem.Value = 1 Or cbOpciones.SelectedItem.Value = 2 Then
    '            .Item(3).Visible = False
    '        Else
    '            .Item(3).Visible = True
    '        End If

    '        .Item(0).Width = 150
    '        .Item(1).Width = 90
    '        .Item(2).Width = 90
    '        .Item(3).Width = 60
    '        .Item(4).Width = 200
    '        .Item(5).Width = 100

    '        .Item(0).Caption = "Código"
    '        .Item(1).Caption = "Precio Normal"
    '        .Item(2).Caption = "Precio Oferta"
    '        .Item(3).Caption = "% Desc."
    '        .Item(4).Caption = "Descripción"
    '        .Item(5).Caption = "Fecha Oferta"

    '        .Item(0).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
    '        .Item(1).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
    '        .Item(2).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
    '        .Item(3).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
    '        .Item(4).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
    '        .Item(5).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True

    '        .Item(0).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
    '        .Item(1).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
    '        .Item(2).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
    '        .Item(3).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
    '        .Item(4).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
    '        .Item(5).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center

    '        .Item(1).TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
    '        .Item(2).TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
    '        .Item(3).TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
    '        .Item(5).TextAlignment = Janus.Windows.GridEX.TextAlignment.Center

    '    End With

    'End Sub

    Private Sub FormatGeneral()

        With gdInfo.RootTable.Columns

            .Item(0).Width = 130
            .Item(1).Width = 150
            .Item(2).Width = 50
            .Item(3).Width = 50
            .Item(4).Width = 50
            .Item(5).Width = 72
            .Item(6).Width = 72
            .Item(7).Width = 90

            .Item(0).Caption = "Código"
            .Item(1).Caption = "Descripción"
            .Item(2).Caption = "Linea"
            .Item(3).Caption = "Familia"
            .Item(4).Caption = "Uso"
            .Item(5).Caption = "Corr.Inicial"
            .Item(6).Caption = "Corr.Final"
            .Item(7).Caption = "Precio"

            .Item(0).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
            .Item(1).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
            .Item(2).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
            .Item(3).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
            .Item(4).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
            .Item(5).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
            .Item(6).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True
            .Item(7).HeaderStyle.FontBold = Janus.Windows.GridEX.TriState.True

            .Item(0).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Item(1).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Item(2).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Item(3).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Item(4).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Item(5).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Item(6).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Item(7).HeaderStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center

            .Item(2).TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Item(3).TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Item(4).TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Item(5).TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Item(6).TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        End With

    End Sub

    Private Sub cbOpciones_SelectedItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbOpciones.SelectedItemChanged

        btnExportar.Enabled = False
        btnImprimir.Enabled = False

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        'If cbOpciones.SelectedItem.Value = 0 Then

        PreviewGeneral()

        'Else

        '    PreviewDescuentos()

        'End If

    End Sub

    Private Sub PreviewGeneral()

        Me.Cursor = Cursors.WaitCursor
        Dim oLstReport As New ListadePreciosGeneralReport(dtInfo, GetAlmacen(), GetTitulo())
        Dim oReportViewer As New ReportViewerForm
        oLstReport.Document.Name = "Lista de Precios General"
        oReportViewer.Report = oLstReport
        Me.Cursor = Cursors.Default
        oReportViewer.Show()

    End Sub

    'Private Sub PreviewDescuentos()

    '    Me.Cursor = Cursors.WaitCursor
    '    Dim oLstReport As New ListadePreciosReport(dtInfo, cbOpciones.SelectedItem.Value, GetAlmacen())
    '    Dim oReportViewer As New ReportViewerForm
    '    oLstReport.Document.Name = "Articulos con Oferta"
    '    oReportViewer.Report = oLstReport
    '    Me.Cursor = Cursors.Default
    '    oReportViewer.Show()

    'End Sub

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

    Private Function GetTitulo() As String

        Select Case cbOpciones.SelectedItem.Value
            Case 0
                Return "LISTA DE PRECIOS - SIN IVA"
            Case 1
                Return "LISTA DE PRECIOS - CON IVA"
            Case 2
                Return "LISTA DE PRECIOS - ORO"
            Case 3
                Return "LISTA DE PRECIOS - ORO 2"
            Case 4
                Return "LISTA DE PRECIOS - ORO 3"
            Case 5
                Return "LISTA DE PRECIOS - PLATA"
            Case 6
                Return "LISTA DE PRECIOS - DIP'S"
        End Select

    End Function

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        'If cbOpciones.SelectedItem.Value = 0 Then

        ExportListaPreciosGeneral()

        'Else

        '    ExportListaPrecios()

        'End If

    End Sub

    'Private Sub ExportListaPrecios()

    '    Me.Cursor = Cursors.WaitCursor

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
    '            MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Costos de Venta")
    '            Exit Sub
    '        End If
    '    Else
    '        xlapp = CreateObject("Excel.Application")
    '    End If

    '    wbxl = xlapp.Workbooks.Add
    '    wsxl = xlapp.Sheets(1)
    '    wsxl.Name = "Descuentos"

    '    '****************************************
    '    'HOJA DE CALCULO VALES DE CAJA
    '    '****************************************
    '    Select Case cbOpciones.SelectedItem.Value
    '        Case 1
    '            wsxl.Cells(1, 1).Value = "REPORTE DE ARTICULOS CON 20% DE DESCUENTO"
    '        Case 2
    '            wsxl.Cells(1, 1).Value = "REPORTE DE ARTICULOS CON 40% DE DESCUENTO"
    '        Case 3
    '            wsxl.Cells(1, 1).Value = "REPORTE DE ARTICULOS CON DESCUENTO DIFERENTE AL 20 Y 40%"
    '    End Select
    '    wsxl.Cells(1, 1).Font.Bold = True
    '    wsxl.Cells(1, 1).Font.Size = 12

    '    wsxl.Range("A1:F1").Merge()
    '    wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
    '    wsxl.Range("A1:F1").BorderAround(, 2, 0, )
    '    wsxl.Range("A1:F1").HorizontalAlignment = 3

    '    wsxl.Cells(3, 1).Value = "Fecha"
    '    wsxl.Cells(3, 2).Value = ": " & Format(Date.Now, "short date")
    '    wsxl.Cells(3, 2).Font.Size = 10
    '    wsxl.Cells(3, 2).Font.Bold = True

    '    wsxl.Cells(4, 1).Value = "Sucursal"
    '    wsxl.Cells(4, 2).Value = ": " & GetAlmacen()
    '    wsxl.Cells(4, 2).Font.Size = 10
    '    wsxl.Cells(4, 2).Font.Bold = True

    '    'Encabezado
    '    wsxl.Cells(6, 1).Value = "Código"               'A'
    '    wsxl.Cells(6, 2).Value = "Precio Normal"        'B'
    '    wsxl.Cells(6, 3).Value = "Precio Oferta"        'C'
    '    wsxl.Cells(6, 4).Value = "% Desc."              'D'
    '    wsxl.Cells(6, 5).Value = "Descripción"          'E'
    '    wsxl.Cells(6, 6).Value = "Fecha de Oferta"      'F'

    '    wsxl.Range("A6:F6").Font.Bold = True
    '    wsxl.Range("A6:F6").HorizontalAlignment = 3
    '    wsxl.Range("A6:F6").Font.Size = 8
    '    wsxl.Range("A6:F6").Interior.Color = RGB(255, 255, 192)
    '    wsxl.Range("A6:F6").BorderAround(, 2, 0, )

    '    intRow = 0

    '    For Each oRow In dtInfo.Rows

    '        intRow = intRow + 1
    '        wsxl.Cells(6 + intRow, 1).Value = oRow!CodArticulo
    '        wsxl.Cells(6 + intRow, 2).Value = oRow!PrecioNormal
    '        wsxl.Cells(6 + intRow, 3).Value = oRow!PrecioOferta
    '        wsxl.Cells(6 + intRow, 4).Value = oRow!Descuento
    '        wsxl.Cells(6 + intRow, 5).Value = oRow!Descripcion
    '        wsxl.Cells(6 + intRow, 6).Value = oRow!FUO
    '    Next

    '    wsxl.Range("A6:A6").ColumnWidth = 21
    '    wsxl.Range("B6:B6").ColumnWidth = 13
    '    wsxl.Range("C6:C6").ColumnWidth = 13
    '    wsxl.Range("D6:D6").ColumnWidth = 8
    '    wsxl.Range("E6:E6").ColumnWidth = 39
    '    wsxl.Range("F6:F6").ColumnWidth = 13
    '    wsxl.PageSetup.FitToPagesWide = 1
    '    wsxl.PageSetup.FitToPagesTall = 1

    '    wsxl.Range("B6:C" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

    '    If cbOpciones.SelectedItem.Value <> 3 Then
    '        wsxl.Range("D6:D" & Trim(Str(8 + intRow))).EntireColumn.Delete()
    '    End If

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

    '    Me.Cursor = Cursors.Default

    'End Sub

    Private Sub ExportListaPreciosGeneral()

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
                MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Costos de Venta")
                Exit Sub
            End If
        Else
            xlapp = CreateObject("Excel.Application")
        End If

        wbxl = xlapp.Workbooks.Add
        wsxl = xlapp.Sheets(1)
        wsxl.Name = "Descuentos"

        '****************************************
        'HOJA DE CALCULO VALES DE CAJA
        '****************************************
        wsxl.Cells(1, 1).Value = GetTitulo()
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:H1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:H1").BorderAround(, 2, 0, )
        wsxl.Range("A1:H1").HorizontalAlignment = 3

        wsxl.Cells(3, 1).Value = "Fecha"
        wsxl.Cells(3, 2).Value = ": " & Format(Date.Now, "dd/MM/yyyy")
        wsxl.Cells(3, 2).Font.Size = 10
        wsxl.Cells(3, 2).Font.Bold = True

        wsxl.Cells(4, 1).Value = "Sucursal"
        wsxl.Cells(4, 2).Value = ": " & GetAlmacen()
        wsxl.Cells(4, 2).Font.Size = 10
        wsxl.Cells(4, 2).Font.Bold = True

        'Encabezado
        wsxl.Cells(6, 1).Value = "Código"       'A'
        wsxl.Cells(6, 2).Value = "Descripción"  'B'
        wsxl.Cells(6, 3).Value = "Lin."         'C'
        wsxl.Cells(6, 4).Value = "Fam."         'D'
        wsxl.Cells(6, 5).Value = "Uso"          'E'
        wsxl.Cells(6, 6).Value = "C.Ini."       'F'
        wsxl.Cells(6, 7).Value = "C.Fin."       'G'
        wsxl.Cells(6, 8).Value = "Precio"       'H'
        'wsxl.Cells(6, 9).Value = "Oferta"       'I'
        'wsxl.Cells(6, 10).Value = "% Oferta"    'J'

        wsxl.Range("A6:H6").Font.Bold = True
        wsxl.Range("A6:H6").HorizontalAlignment = 3
        wsxl.Range("A6:H6").Font.Size = 8
        wsxl.Range("A6:H6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:H6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oRow In dtInfo.Rows

            intRow = intRow + 1
            wsxl.Cells(6 + intRow, 1).Value = oRow!CodArticulo
            wsxl.Cells(6 + intRow, 2).Value = oRow!Descripcion
            wsxl.Cells(6 + intRow, 3).Value = oRow!CodLinea
            wsxl.Cells(6 + intRow, 4).Value = oRow!CodFamilia
            wsxl.Cells(6 + intRow, 5).Value = oRow!CodUso
            wsxl.Cells(6 + intRow, 6).Value = oRow!NumInicio
            wsxl.Cells(6 + intRow, 7).Value = oRow!NumFin
            wsxl.Cells(6 + intRow, 8).Value = oRow!Precio
            'wsxl.Cells(6 + intRow, 9).Value = oRow!EsOferta
            'wsxl.Cells(6 + intRow, 10).Value = oRow!Porcentaje
        Next

        wsxl.Range("A6:A6").ColumnWidth = 21
        wsxl.Range("B6:B6").ColumnWidth = 30
        wsxl.Range("C6:C6").ColumnWidth = 5
        wsxl.Range("D6:D6").ColumnWidth = 5
        wsxl.Range("E6:E6").ColumnWidth = 5
        wsxl.Range("F6:F6").ColumnWidth = 6
        wsxl.Range("G6:G6").ColumnWidth = 6
        wsxl.Range("H6:H6").ColumnWidth = 13
        'wsxl.Range("I6:I6").ColumnWidth = 5.5
        'wsxl.Range("J6:J6").ColumnWidth = 6.71
        wsxl.PageSetup.FitToPagesWide = 1
        wsxl.PageSetup.FitToPagesTall = 1

        wsxl.Range("H6:H" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

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

        Me.Cursor = Cursors.Default

    End Sub

End Class
