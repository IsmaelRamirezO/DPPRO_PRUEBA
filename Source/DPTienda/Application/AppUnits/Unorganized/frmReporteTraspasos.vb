Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class frmReporteTraspasos
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        CreateDataTablePendiente()
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
    Friend WithEvents nbTotalapartados As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
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
    Friend WithEvents rdbTraspasoSalida As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbTraspasoEntrada As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbTraspasoGrabar As Janus.Windows.EditControls.UIRadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteTraspasos))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbTraspasoGrabar = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbTraspasoSalida = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbTraspasoEntrada = New Janus.Windows.EditControls.UIRadioButton()
        Me.nbTotalapartados = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.ccbHasta = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ccmbDesde = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GrdTraspasos = New Janus.Windows.GridEX.GridEX()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.GrdTraspasos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.nbTotalapartados)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.ccbHasta)
        Me.ExplorerBar1.Controls.Add(Me.ccmbDesde)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.GrdTraspasos)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos del Reporte"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(824, 358)
        Me.ExplorerBar1.TabIndex = 4
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(384, 320)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 23)
        Me.Label21.TabIndex = 123
        Me.Label21.Text = "F9"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.cbTraspasoGrabar)
        Me.UiGroupBox1.Controls.Add(Me.rdbTraspasoSalida)
        Me.UiGroupBox1.Controls.Add(Me.rdbTraspasoEntrada)
        Me.UiGroupBox1.Location = New System.Drawing.Point(16, 32)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(224, 96)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'cbTraspasoGrabar
        '
        Me.cbTraspasoGrabar.BackColor = System.Drawing.Color.Transparent
        Me.cbTraspasoGrabar.Location = New System.Drawing.Point(16, 40)
        Me.cbTraspasoGrabar.Name = "cbTraspasoGrabar"
        Me.cbTraspasoGrabar.Size = New System.Drawing.Size(200, 23)
        Me.cbTraspasoGrabar.TabIndex = 2
        Me.cbTraspasoGrabar.Text = "Traspasos Sin Grabar"
        Me.cbTraspasoGrabar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbTraspasoSalida
        '
        Me.rdbTraspasoSalida.BackColor = System.Drawing.Color.Transparent
        Me.rdbTraspasoSalida.Location = New System.Drawing.Point(16, 64)
        Me.rdbTraspasoSalida.Name = "rdbTraspasoSalida"
        Me.rdbTraspasoSalida.Size = New System.Drawing.Size(160, 23)
        Me.rdbTraspasoSalida.TabIndex = 0
        Me.rdbTraspasoSalida.Text = "Traspasos de Salida"
        Me.rdbTraspasoSalida.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbTraspasoEntrada
        '
        Me.rdbTraspasoEntrada.BackColor = System.Drawing.Color.Transparent
        Me.rdbTraspasoEntrada.Checked = True
        Me.rdbTraspasoEntrada.Location = New System.Drawing.Point(16, 16)
        Me.rdbTraspasoEntrada.Name = "rdbTraspasoEntrada"
        Me.rdbTraspasoEntrada.Size = New System.Drawing.Size(168, 23)
        Me.rdbTraspasoEntrada.TabIndex = 1
        Me.rdbTraspasoEntrada.TabStop = True
        Me.rdbTraspasoEntrada.Text = "Traspasos de Entrada"
        Me.rdbTraspasoEntrada.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'nbTotalapartados
        '
        Me.nbTotalapartados.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalapartados.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalapartados.BackColor = System.Drawing.Color.Ivory
        Me.nbTotalapartados.Location = New System.Drawing.Point(136, 312)
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
        Me.Label5.Location = New System.Drawing.Point(16, 320)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 23)
        Me.Label5.TabIndex = 132
        Me.Label5.Text = "Total Traspasos:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(248, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(248, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 23)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Desde:"
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(440, 40)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(120, 56)
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
        Me.ccbHasta.Location = New System.Drawing.Point(304, 72)
        Me.ccbHasta.Name = "ccbHasta"
        Me.ccbHasta.Size = New System.Drawing.Size(128, 23)
        Me.ccbHasta.TabIndex = 2
        Me.ccbHasta.Value = New Date(2005, 7, 6, 0, 0, 0, 0)
        Me.ccbHasta.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ccmbDesde
        '
        '
        '
        '
        Me.ccmbDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccmbDesde.Location = New System.Drawing.Point(304, 40)
        Me.ccmbDesde.Name = "ccmbDesde"
        Me.ccmbDesde.Size = New System.Drawing.Size(128, 23)
        Me.ccmbDesde.TabIndex = 1
        Me.ccmbDesde.Value = New Date(2005, 7, 6, 0, 0, 0, 0)
        Me.ccmbDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(408, 320)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 23)
        Me.Label22.TabIndex = 124
        Me.Label22.Text = "Imprimir"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(504, 320)
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
        Me.Label13.Location = New System.Drawing.Point(480, 320)
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
        Me.GrdTraspasos.Location = New System.Drawing.Point(16, 136)
        Me.GrdTraspasos.Name = "GrdTraspasos"
        Me.GrdTraspasos.Size = New System.Drawing.Size(792, 160)
        Me.GrdTraspasos.TabIndex = 4
        Me.GrdTraspasos.TableSpacing = 7
        Me.GrdTraspasos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmReporteTraspasos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(824, 358)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmReporteTraspasos"
        Me.Text = "Reporte Traspasos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.GrdTraspasos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private oTraspasosEntradaMgr As TraspasosEntradaManager
    Private dsTraspasos As DataSet
    Private pendientes As DataTable
    Private oTraspasosSalidaMgr As TraspasosSalidaManager

    Private Sub CreateDataTablePendiente()
        pendientes = New DataTable("Pendientes")
        pendientes.Columns.Add("FolioSAP", GetType(String))
        pendientes.Columns.Add("FechaTraspaso", GetType(DateTime))
        pendientes.Columns.Add("Origen", GetType(String))
        pendientes.Columns.Add("Destino", GetType(String))
        pendientes.Columns.Add("Piezas", GetType(Decimal))
        pendientes.Columns.Add("Costo", GetType(Decimal))
        pendientes.Columns.Add("UsuarioDPPRO", GetType(String))
        pendientes.Columns.Add("Guia", GetType(String))
        pendientes.Columns.Add("Motivo", GetType(String))
        pendientes.AcceptChanges()
    End Sub

    Private Sub frmReporteTraspasos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor

        ccmbDesde.Value = Date.Now
        ccbHasta.Value = Date.Now

        oTraspasosEntradaMgr = New TraspasosEntradaManager(oAppContext)
        oTraspasosSalidaMgr = New TraspasosSalidaManager(oAppContext)

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        btnGenerar.Enabled = False
        If Me.rdbTraspasoEntrada.Checked Then

            Me.Cursor = Cursors.WaitCursor

            'Me.GrdTraspasos.RootTable.Columns("Referencia").Caption = "Referencia"
            'Me.GrdTraspasos.RootTable.Columns("Referencia").DataMember = "Referencia"
            'Me.GrdTraspasos.RootTable.Columns("Origen").Caption = "Origen"
            'Me.GrdTraspasos.RootTable.Columns("Origen").DataMember = "Almacen"

            Me.dsTraspasos = oTraspasosEntradaMgr.SelectAllByDate(Me.ccmbDesde.Value, Me.ccbHasta.Value)

            If dsTraspasos.Tables(0).Rows.Count > 0 Then
                Me.dsTraspasos.AcceptChanges()
                Me.GrdTraspasos.DataSource = dsTraspasos
                Me.GrdTraspasos.DataMember = dsTraspasos.Tables(0).TableName
                'Dim count(dsTraspasos.Tables(0).Rows.Count) As Integer

                'Dim i As Integer = 0
                'For Each row As DataRow In dsTraspasos.Tables(0).Rows

                '    If Array.IndexOf(count, CInt(row("Referencia"))) < 0 Then
                '        count(i) = row("Referencia")
                '        i += 1
                '    End If

                'Next

                'Me.nbTotalapartados.Value = i
                Me.nbTotalapartados.Value = dsTraspasos.Tables(0).Rows.Count

                'MessageBox.Show("Listo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                Me.dsTraspasos.RejectChanges()
                MessageBox.Show("Los datos proporcionados no arrojaron resultados", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            Me.Cursor = Cursors.Default

        ElseIf Me.rdbTraspasoSalida.Checked Then


            Me.Cursor = Cursors.WaitCursor

            'Me.GrdTraspasos.RootTable.Columns("Referencia").Caption = "Folio"
            'Me.GrdTraspasos.RootTable.Columns("Referencia").DataMember = "Folio"
            'Me.GrdTraspasos.RootTable.Columns("Origen").Caption = "Destino"
            'Me.GrdTraspasos.RootTable.Columns("Origen").DataMember = "Origen"

            Me.dsTraspasos = oTraspasosSalidaMgr.SelectAllByDate(Me.ccmbDesde.Value, Me.ccbHasta.Value)

            If dsTraspasos.Tables(0).Rows.Count > 0 Then
                Me.dsTraspasos.AcceptChanges()
                Me.GrdTraspasos.DataSource = dsTraspasos
                Me.GrdTraspasos.DataMember = dsTraspasos.Tables(0).TableName
                'Dim count(dsTraspasos.Tables(0).Rows.Count) As Integer

                'Dim i As Integer = 0
                'For Each row As DataRow In dsTraspasos.Tables(0).Rows

                '    If Array.IndexOf(count, CInt(row("Folio"))) < 0 Then
                '        count(i) = row("Folio")
                '        i += 1
                '    End If

                'Next

                'Me.nbTotalapartados.Value = i
                Me.nbTotalapartados.Value = dsTraspasos.Tables(0).Rows.Count

                'MessageBox.Show("Listo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                Me.dsTraspasos.RejectChanges()
                MessageBox.Show("Los datos proporcionados no arrojaron resultados", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            Me.Cursor = Cursors.Default
        ElseIf cbTraspasoGrabar.Checked Then
            Dim procesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim table As DataTable = procesoMgr.Read_TraspasosPendientes(Me.ccmbDesde.Value, Me.ccbHasta.Value, "", "S")
            Dim dvPendientes As New DataView(pendientes, "", "", DataViewRowState.CurrentRows)
            Dim fila As DataRow
            Dim fecha As String

            '------------------------------------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (16.02.2016): Adecuaciones por retail
            '------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim strGuia As String
            
            If table.Rows.Count > 0 Then
                pendientes.Rows.Clear()
                For Each row As DataRow In table.Rows
                    dvPendientes.RowFilter = "FolioSAP = '" & CStr(row!EBELN).Trim & "'"
                    If dvPendientes.Count = 0 Then
                        fila = pendientes.NewRow()
                        fila("FolioSAP") = CStr(row!EBELN)
                        fecha = CStr(row!AEDAT)
                        'fila("FechaTraspaso") = New DateTime(CStr(row!AEDAT).Substring(0, 4), CStr(row!AEDAT).Substring(4, 2), CStr(row!AEDAT).Substring(6, 2))
                        fila("FechaTraspaso") = CStr(row!AEDAT).Trim
                        fila("Origen") = CStr(row!RESWK)
                        fila("Destino") = CStr(row!WERKS)
                        'fila("Piezas") = CDec(row!MENGE)
                        fila("Piezas") = CDec(table.Compute("SUM(MENGE)", "EBELN = '" & row!EBELN & "'"))
                        'fila("Costo") = CDec(row!WRBTR)
                        fila("Costo") = CDec(table.Compute("SUM(WRBTR)", "EBELN = '" & row!EBELN & "'"))
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------
                        ' JNAVA (16.02.2016): Adecuaciones por retail
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------
                        procesoMgr.ReadInfoPaqueteria(CStr(row!EBELN), strGuia, "", 0)
                        fila("Guia") = strGuia 'procesoMgr.ReadInfoPaqueteria(CStr(row!EBELN), "F01")
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------
                        'rgermain 20.10.2016: Adecuacion motivo de traspaso
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------
                        Select Case CStr(row!RESWK).Trim.ToUpper
                            Case "M003", "M004", "M005"
                                fila("Motivo") = "Resurtido"
                            Case "M002"
                                fila("Motivo") = "Proveedor"
                            Case "1000"
                                fila("Motivo") = "Almacen"
                            Case Else
                                fila("Motivo") = "Entre Tiendas"
                        End Select
                        pendientes.Rows.Add(fila)
                    End If
                Next
                Me.GrdTraspasos.DataSource = Nothing
                Me.GrdTraspasos.DataSource = pendientes
                Me.nbTotalapartados.Value = pendientes.Rows.Count
            Else
                MessageBox.Show("Los datos proporcionados no arrojaron resultados", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        btnGenerar.Enabled = True

    End Sub

    Public Sub ActionPreviewReporte(ByVal titulo As String)
        Try
            If Not Me.dsTraspasos Is Nothing Then
                Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim oAlmacen As Almacen
                Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
                oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
                Dim reporte As New rptTraspasosEntradasInventarios(ccmbDesde.Value, ccbHasta.Value, oAlmacen.ID & " " & oAlmacen.Descripcion, titulo)
                reporte.Document.Name = titulo
                reporte.DataSource = Me.dsTraspasos.Tables(0)
                reporte.Run()
                Dim oReportViewer As New ReportViewerForm
                oReportViewer.Report = reporte
                oReportViewer.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActionPreviewReportePendientes(ByVal titulo As String)
        Try
            If Not Me.pendientes Is Nothing Then
                Dim oAlmacen As Almacen
                Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
                Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
                Dim reporte As New rptTraspasosEntradasInventarios(ccmbDesde.Value, ccbHasta.Value, oAlmacen.ID & " " & oAlmacen.Descripcion, titulo)
                reporte.Document.Name = titulo
                reporte.DataSource = Me.pendientes
                reporte.Run()
                Dim oReportViewer As New ReportViewerForm
                oReportViewer.Report = reporte
                oReportViewer.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ActionPreview()
        Try
            If Not Me.dsTraspasos Is Nothing Then

                Dim oARReporte As New rptTraspasosDeEntrada(Me.dsTraspasos, Me.ccmbDesde.Value, Me.ccbHasta.Value)
                Dim oReportViewer As New ReportViewerForm

                oARReporte.Document.Name = "Traspasos de Entrada"
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
    Public Sub ActionPreviewSalida()
        Try
            If Not Me.dsTraspasos Is Nothing Then

                Dim oARReporte As New rptTraspasosDeSalida(Me.dsTraspasos, Me.ccmbDesde.Value, Me.ccbHasta.Value)
                Dim oReportViewer As New ReportViewerForm

                oARReporte.Document.Name = "Traspasos de Salida"
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

    Private Sub frmReporteTraspasos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F9 Then

            If Me.rdbTraspasoEntrada.Checked Then
                Me.Cursor = Cursors.WaitCursor
                'ActionPreview()
                ActionPreviewReporte("Reporte de Traspasos de Entrada")
                Me.Cursor = Cursors.Default
            ElseIf Me.rdbTraspasoSalida.Checked Then
                Me.Cursor = Cursors.WaitCursor
                ActionPreviewReporte("Reporte de Traspasos de Salidas")
                'ActionPreviewSalida()
                Me.Cursor = Cursors.Default
            Else
                Me.Cursor = Cursors.WaitCursor
                ActionPreviewReportePendientes("Reporte de Traspasos Pendientes por Grabar")
                Me.Cursor = Cursors.Default
            End If


        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        ElseIf e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub GrdTraspasos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdTraspasos.KeyDown

        If e.KeyCode = Keys.Escape Then

            Me.Close()

        ElseIf e.KeyCode = Keys.Tab Then

            Me.ccmbDesde.Focus()
        End If


    End Sub

    Private Sub rdbTraspasoEntrada_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbTraspasoEntrada.CheckedChanged
        If rdbTraspasoEntrada.Checked = True Then
            ccmbDesde.Enabled = True
            ccbHasta.Enabled = True
        Else
            ccmbDesde.Enabled = False
            ccbHasta.Enabled = False
        End If
    End Sub

    Private Sub rdbTraspasoSalida_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbTraspasoSalida.CheckedChanged
        If rdbTraspasoSalida.Checked = True Then
            ccmbDesde.Enabled = True
            ccbHasta.Enabled = True
        Else
            ccmbDesde.Enabled = False
            ccbHasta.Enabled = False
        End If
    End Sub

    Private Sub cbTraspasoGrabar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTraspasoGrabar.CheckedChanged
        If cbTraspasoGrabar.Checked = True Then
            ccmbDesde.Enabled = False
            ccbHasta.Enabled = False
        Else
            ccmbDesde.Enabled = True
            ccbHasta.Enabled = True
        End If
    End Sub

End Class
