Imports System.Data
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class AnalisisInventarioAuditoria

    Inherits System.Windows.Forms.Form

    Dim dtAnalisis As New DataTable

    Dim strConnectionString As String = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

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
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents ebSucursal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbMes As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grdAnalisis As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnalisisInventarioAuditoria))
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem7 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem8 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem9 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem10 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem11 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem12 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.grdAnalisis = New Janus.Windows.GridEX.GridEX()
        Me.uIGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ebSucursal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.cbMes = New Janus.Windows.EditControls.UIComboBox()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grdAnalisis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uIGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Controls.Add(Me.Label8)
        Me.explorerBar1.Controls.Add(Me.btnGenerar)
        Me.explorerBar1.Controls.Add(Me.grdAnalisis)
        Me.explorerBar1.Controls.Add(Me.uIGroupBox1)
        Me.explorerBar1.Location = New System.Drawing.Point(-8, -8)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(912, 160)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(232, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Exportar"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(208, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 24)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "F5"
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(16, 88)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(136, 32)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdAnalisis
        '
        Me.grdAnalisis.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAnalisis.GroupByBoxVisible = False
        Me.grdAnalisis.Location = New System.Drawing.Point(320, 24)
        Me.grdAnalisis.Name = "grdAnalisis"
        Me.grdAnalisis.Size = New System.Drawing.Size(560, 96)
        Me.grdAnalisis.TabIndex = 2
        Me.grdAnalisis.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uIGroupBox1
        '
        Me.uIGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.uIGroupBox1.Controls.Add(Me.ebSucursal)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel2)
        Me.uIGroupBox1.Controls.Add(Me.lblLabel1)
        Me.uIGroupBox1.Controls.Add(Me.cbMes)
        Me.uIGroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.uIGroupBox1.Name = "uIGroupBox1"
        Me.uIGroupBox1.Size = New System.Drawing.Size(296, 64)
        Me.uIGroupBox1.TabIndex = 0
        Me.uIGroupBox1.Text = "Filtros"
        Me.uIGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'ebSucursal
        '
        Me.ebSucursal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucursal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucursal.BackColor = System.Drawing.Color.Ivory
        Me.ebSucursal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucursal.Location = New System.Drawing.Point(72, 24)
        Me.ebSucursal.Name = "ebSucursal"
        Me.ebSucursal.ReadOnly = True
        Me.ebSucursal.Size = New System.Drawing.Size(56, 22)
        Me.ebSucursal.TabIndex = 1
        Me.ebSucursal.TabStop = False
        Me.ebSucursal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebSucursal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel2
        '
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.Location = New System.Drawing.Point(136, 29)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(32, 16)
        Me.lblLabel2.TabIndex = 2
        Me.lblLabel2.Text = "Mes"
        '
        'lblLabel1
        '
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(8, 29)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(56, 16)
        Me.lblLabel1.TabIndex = 0
        Me.lblLabel1.Text = "Sucursal"
        '
        'cbMes
        '
        Me.cbMes.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbMes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "ENERO"
        UiComboBoxItem1.Value = CType(1, Short)
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "FEBRERO"
        UiComboBoxItem2.Value = CType(2, Short)
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "MARZO"
        UiComboBoxItem3.Value = CType(3, Short)
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "ABRIL"
        UiComboBoxItem4.Value = CType(4, Short)
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "MAYO"
        UiComboBoxItem5.Value = CType(5, Short)
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "JUNIO"
        UiComboBoxItem6.Value = CType(6, Short)
        UiComboBoxItem7.FormatStyle.Alpha = 0
        UiComboBoxItem7.IsSeparator = False
        UiComboBoxItem7.Text = "JULIO"
        UiComboBoxItem7.Value = CType(7, Short)
        UiComboBoxItem8.FormatStyle.Alpha = 0
        UiComboBoxItem8.IsSeparator = False
        UiComboBoxItem8.Text = "AGOSTO"
        UiComboBoxItem8.Value = CType(8, Short)
        UiComboBoxItem9.FormatStyle.Alpha = 0
        UiComboBoxItem9.IsSeparator = False
        UiComboBoxItem9.Text = "SEPTIEMBRE"
        UiComboBoxItem9.Value = CType(9, Short)
        UiComboBoxItem10.FormatStyle.Alpha = 0
        UiComboBoxItem10.IsSeparator = False
        UiComboBoxItem10.Text = "OCTUBRE"
        UiComboBoxItem10.Value = CType(10, Short)
        UiComboBoxItem11.FormatStyle.Alpha = 0
        UiComboBoxItem11.IsSeparator = False
        UiComboBoxItem11.Text = "NOVIEMBRE"
        UiComboBoxItem11.Value = CType(11, Short)
        UiComboBoxItem12.FormatStyle.Alpha = 0
        UiComboBoxItem12.IsSeparator = False
        UiComboBoxItem12.Text = "DICIEMBRE"
        UiComboBoxItem12.Value = CType(12, Short)
        Me.cbMes.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5, UiComboBoxItem6, UiComboBoxItem7, UiComboBoxItem8, UiComboBoxItem9, UiComboBoxItem10, UiComboBoxItem11, UiComboBoxItem12})
        Me.cbMes.Location = New System.Drawing.Point(168, 24)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(112, 22)
        Me.cbMes.TabIndex = 3
        Me.cbMes.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'AnalisisInventarioAuditoria
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(882, 119)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "AnalisisInventarioAuditoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auditoria de Inventario"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grdAnalisis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uIGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub AnalisisInventarioAuditoria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbMes.SelectedIndex = Month(Date.Now) - 1

        ebSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

    End Sub

#Region "SQL"

    Private Function SelectAnalisis() As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim da As SqlDataAdapter
        Dim dt As New DataTable("Analisis")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[AnalisisdeInventarioReporteAuditoriaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.Int, 4))

            .Parameters("@Almacen").Value = oAppContext.ApplicationConfiguration.Almacen
            .Parameters("@Mes").Value = cbMes.SelectedIndex + 1

        End With

        da = New SqlDataAdapter(sccmdSelect)

        Try

            da.Fill(dt)

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            Me.Cursor = Cursors.Default

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

        da.Dispose()
        da = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Me.Cursor = Cursors.Default

        Return dt

    End Function


#End Region

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        Me.Cursor = Cursors.WaitCursor

        dtAnalisis = SelectAnalisis()

        Me.Cursor = Cursors.Default

        If dtAnalisis Is Nothing Or dtAnalisis.Rows.Count = 0 Then

            grdAnalisis.DataSource = Nothing
            grdAnalisis.Refresh()
            MsgBox("No se produjeron resultados. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Analisis de Inventario")

        Else

            grdAnalisis.DataSource = dtAnalisis
            grdAnalisis.RetrieveStructure()

        End If

    End Sub

    Private Sub AnalisisInventarioAuditoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.F5

                If Not dtAnalisis Is Nothing And dtAnalisis.Rows.Count > 0 Then

                    Me.Cursor = Cursors.WaitCursor

                    ExportToExcel()

                    Me.Cursor = Cursors.Default

                Else

                    MsgBox("No existen datos que se puedan exportar. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Auditoria de Inventario")

                End If

            Case Keys.Enter

                SendKeys.Send("{TAB}")

            Case Keys.Escape

                Me.Close()

        End Select

    End Sub

    Private Sub ExportToExcel()

        Dim SaveDialog = New SaveFileDialog
        Dim strRuta As String = String.Empty

        Dim xlapp
        Dim wbxl
        Dim wsxl

        Dim intRow As Integer 'counter

        Dim oRow As DataRow
        Dim oCol As DataColumn

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
        wsxl.Name = "Auditoria de Inventarios"

        '****************************************
        'HOJA DE CALCULO VALES DE CAJA
        '****************************************
        wsxl.Cells(1, 1).Value = "AUDITORIA - ANALISIS DE INVENTARIOS"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 14

        wsxl.Cells(3, 1).Value = "SUCURSAL "
        wsxl.Cells(3, 2).Value = ": " & GetAlmacen()

        wsxl.Cells(3, 2).Font.Size = 12
        wsxl.Cells(3, 2).Font.Bold = True

        oRow = dtAnalisis.Rows(0)

        Dim countCol As Integer = 0

        For Each oCol In dtAnalisis.Columns

            countCol += 1

            wsxl.Cells(5, countCol).value = oCol.ColumnName
            wsxl.Cells(5, countCol).Font.Bold = True
            wsxl.Cells(5, countCol).Interior.Color = &HDFFFCC
            wsxl.Cells(6, countCol).value = IIf(IsDBNull(oRow.Item(countCol - 1)), 0, oRow.Item(countCol - 1))

        Next

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

End Class
