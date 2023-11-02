Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.Reports.Inventario

Imports System.Data.SqlClient
Imports System.IO

Public Class FrmMasVendidos
    Inherits System.Windows.Forms.Form
    Dim oProSAPMgr As ProcesoSAPManager
    Dim oReporter As New InventarioReportesVarios



#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oReporter.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
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
    Friend WithEvents ebFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ebFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NEBxCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMasVendidos))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.NEBxCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.ebFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.NEBxCantidad)
        Me.ExplorerBar1.Controls.Add(Me.ebFechaFin)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.ebFechaInicio)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(336, 240)
        Me.ExplorerBar1.TabIndex = 11
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'NEBxCantidad
        '
        Me.NEBxCantidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.NEBxCantidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.NEBxCantidad.Location = New System.Drawing.Point(156, 48)
        Me.NEBxCantidad.Name = "NEBxCantidad"
        Me.NEBxCantidad.Size = New System.Drawing.Size(80, 23)
        Me.NEBxCantidad.TabIndex = 0
        Me.NEBxCantidad.Text = "0"
        Me.NEBxCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NEBxCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.NEBxCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFechaFin
        '
        '
        '
        '
        Me.ebFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaFin.Location = New System.Drawing.Point(156, 128)
        Me.ebFechaFin.Name = "ebFechaFin"
        Me.ebFechaFin.Size = New System.Drawing.Size(128, 23)
        Me.ebFechaFin.TabIndex = 2
        Me.ebFechaFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(52, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Fecha Final:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(52, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "# Articulos"
        '
        'btnGenerar
        '
        Me.btnGenerar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGenerar.Icon = CType(resources.GetObject("btnGenerar.Icon"), System.Drawing.Icon)
        Me.btnGenerar.Location = New System.Drawing.Point(92, 184)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(160, 32)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "Generar Reporte"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFechaInicio
        '
        '
        '
        '
        Me.ebFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaInicio.Location = New System.Drawing.Point(156, 88)
        Me.ebFechaInicio.Name = "ebFechaInicio"
        Me.ebFechaInicio.Size = New System.Drawing.Size(128, 23)
        Me.ebFechaInicio.TabIndex = 1
        Me.ebFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(52, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha Inicial:"
        '
        'FrmMasVendidos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 18)
        Me.ClientSize = New System.Drawing.Size(328, 234)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(344, 272)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(344, 272)
        Me.Name = "FrmMasVendidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Articulos Mas Vendidos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If Me.NEBxCantidad.Text > 0 Then
            Dim dt As New DataTable
            dt = FormatDataSet(oReporter.MasVendidos(Me.NEBxCantidad.Text, Me.ebFechaInicio.Value, Me.ebFechaFin.Value), Me.ebFechaInicio.Value, Me.ebFechaFin.Value).Tables(0)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("La Consulta no arrojo resultados", "Dptienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' Columna: Cantidad Etiquetas
            Dim dcCantidadSAP As DataColumn
            dcCantidadSAP = New DataColumn
            With dcCantidadSAP
                .DataType = System.Type.GetType("System.Int32")
                .Caption = "Etiquetas"
                .ColumnName = "Etiquetas"
                .DefaultValue = 0
            End With
            dt.Columns.Add(dcCantidadSAP)


            Dim dvres As New DataView(dt)

            dvres.Sort = "Familia,Linea"

            Dim iRep As ActRptMasVendidos
            Dim iView As ReportViewerForm
            iRep = New ActRptMasVendidos(Me.NEBxCantidad.Text, Me.ebFechaInicio.Value, Me.ebFechaFin.Value)
            iView = New ReportViewerForm
            iRep.Document.Name = "Reporte de Articulos Mas Vendidos"
            iRep.DataSource = dvres
            iRep.Run()
            iView.Report = iRep
            iView.Show()
        Else
            MessageBox.Show("Cantidad no Valida", "Información Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.NEBxCantidad.Focus()
        End If
    End Sub

 
    Private Function FormatDataSet(ByVal Source As DataSet, ByVal datFechaIni As DateTime, ByVal datFechaFin As DateTime) As DataSet
        Try

            If Source.Tables(0).Rows.Count = 0 Then
                Return Source
                Exit Function
            End If

            Dim dsTarget As New DataSet("ReporteInventario")
            Dim dtMainTable As New DataTable("ReporteInventario")

            'Columna: Codigo
            Dim dcCodigo As DataColumn = New DataColumn
            With dcCodigo
                .DataType = System.Type.GetType("System.String")
                .Caption = "Codigo"
                .ColumnName = "CodArticulo"
            End With
            dtMainTable.Columns.Add(dcCodigo)

            'Columna: Descripcion
            Dim dcDescripcion As DataColumn = New DataColumn
            With dcDescripcion
                .DataType = System.Type.GetType("System.String")
                .Caption = "Descripcion"
                .ColumnName = "Descripcion"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcDescripcion)

            'Columna: Familia
            Dim dcFamilia As DataColumn = New DataColumn
            With dcFamilia
                .DataType = System.Type.GetType("System.String")
                .Caption = "Familia"
                .ColumnName = "Familia"
            End With
            dtMainTable.Columns.Add(dcFamilia)

            'Columna: Codigo
            Dim dcLinea As DataColumn = New DataColumn
            With dcLinea
                .DataType = System.Type.GetType("System.String")
                .Caption = "Linea"
                .ColumnName = "Linea"
            End With
            dtMainTable.Columns.Add(dcLinea)

            'Columna: Talla
            Dim dcTalla As DataColumn
            Dim intTalla As Integer
            For intTalla = 1 To 20
                dcTalla = New DataColumn
                With dcTalla
                    .DataType = System.Type.GetType("System.String")
                    .Caption = "T" & intTalla.ToString("00")
                    .ColumnName = "T" & intTalla.ToString("00")
                End With
                dtMainTable.Columns.Add(dcTalla)
            Next

            'Columna: Cantidad Vendida
            Dim dcVendidos As DataColumn
            Dim intVendidos As Integer
            For intVendidos = 1 To 20
                dcVendidos = New DataColumn
                With dcVendidos
                    .DataType = System.Type.GetType("System.String")
                    .Caption = "V" & intVendidos.ToString("00")
                    .ColumnName = "V" & intVendidos.ToString("00")
                End With
                dtMainTable.Columns.Add(dcVendidos)
            Next

            'Columna: Cantidad Existencias
            Dim dcCantidad As DataColumn
            Dim intCantidad As Integer
            For intCantidad = 1 To 20
                dcCantidad = New DataColumn
                With dcCantidad
                    .DataType = System.Type.GetType("System.String")
                    .Caption = "C" & intCantidad.ToString("00")
                    .ColumnName = "C" & intCantidad.ToString("00")
                End With
                dtMainTable.Columns.Add(dcCantidad)
            Next

            'Columna: Cantidad SAP
            Dim dcCantidadSAP As DataColumn
            Dim intCantidadSAP As Integer
            For intCantidadSAP = 1 To 20
                dcCantidadSAP = New DataColumn
                With dcCantidadSAP
                    .DataType = System.Type.GetType("System.String")
                    .Caption = "S" & intCantidadSAP.ToString("00")
                    .ColumnName = "S" & intCantidadSAP.ToString("00")
                End With
                dtMainTable.Columns.Add(dcCantidadSAP)
            Next

            'Para que se agreguen todos los campos a la Tabla
            dsTarget.Tables.Add(dtMainTable)

            '<TraspasarInformacion>

            Dim oSourceRow As DataRow
            Dim oTargetSource As DataRow

            Dim strCodigo As String
            Dim intColTalla As Integer
            Dim TotalArt As Decimal
            Dim TotalResult As Decimal
            Dim TotalResultArt As Decimal
            Dim TotalMonto As Decimal

            For Each oSourceRow In Source.Tables(0).Rows

                If (Not oTargetSource Is Nothing) Then
                    dtMainTable.Rows.Add(oTargetSource)
                End If

                oTargetSource = dtMainTable.NewRow()
                oTargetSource("CodArticulo") = oSourceRow.Item(0).ToString
                oTargetSource("Descripcion") = UCase(CStr(oSourceRow("Descripcion")))
                oTargetSource("Familia") = UCase(CStr(oSourceRow("Familia")))
                oTargetSource("Linea") = UCase(CStr(oSourceRow("Linea")))

                Dim dtCorri As New DataTable
                Dim dtDP As New DataTable
                Dim dtSAP As New DataTable
                dtCorri = oReporter.Corrida(oSourceRow("codCorrida")).Tables(0)
                dtDP = oReporter.ArticuloFactCorrida(oSourceRow.Item(0).ToString).Tables(0)

                oProSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                dtSAP = oProSAPMgr.ZBAPI_CONSULTA_ALLSTOCK(oSourceRow.Item(0).ToString)

                Dim strtalla As String = String.Empty
                Dim strcant As String = String.Empty
                Dim band As Boolean = False
                'Aqui barro la Corrida de los articulos
                For Each erow As DataRow In dtCorri.Rows
                    For i As Integer = 1 To 20
                        If erow(i - 1) = String.Empty Then
                            Exit For
                        End If
                        'Aqui pongo la existencia de los articulos en DP
                        For Each xrow As DataRow In dtDP.Rows
                            If erow(i - 1) = xrow(0) Then
                                oTargetSource("T" & i.ToString("00")) = xrow(0)
                                oTargetSource("C" & i.ToString("00")) = CInt(xrow(1)).ToString
                                band = True
                                Exit For
                            End If
                        Next
                        If Not band Then
                            oTargetSource("T" & i.ToString("00")) = erow(i - 1)
                            oTargetSource("C" & i.ToString("00")) = "0"
                        End If
                        band = False
                        'Aqui pongo la existencia del Z001
                        oTargetSource("S" & i.ToString("00")) = "0"
                        For Each srow As DataRow In dtSAP.Rows
                            If FormatTalla(erow(i - 1)) = srow("J_3ASIZE") Then
                                'oTargetSource("S" & i.ToString("00")) = CInt(srow("CLABS"))
                                oTargetSource("S" & i.ToString("00")) = CInt(srow("LABST"))
                                Exit For
                            End If
                        Next

                        'Aqui pongo la cantidad de Articulos Vendidos
                        oTargetSource("V" & i.ToString("00")) = CInt(oReporter.ArticulosVendidos(oSourceRow.Item(0).ToString, erow(i - 1), datFechaIni, datFechaFin))


                    Next
                    Exit For
                Next

            Next
            dtMainTable.Rows.Add(oTargetSource)
            dtMainTable.AcceptChanges()
            Return dsTarget

        Catch ex As Exception
            MsgBox(ex.Message & ex.Source)
        End Try

    End Function

    Friend Function FormatTalla(ByVal strNumber As String) As String
        If IsNumeric(strNumber) Then
            If InStr(strNumber, ".5", CompareMethod.Text) = 0 Then
                strNumber = strNumber & ".0"
            End If
        End If
        Return strNumber
    End Function

    Private Sub FrmMasVendidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ebFechaFin.Value = Date.Now
        Me.ebFechaInicio.Value = Date.Now
    End Sub
End Class
