Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago

Public Class EstadoCuentaGeneralReportForm
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnProcesar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebAsociadoInicio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebAsociadoFin As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadoCuentaGeneralReportForm))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ebAsociadoFin = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebAsociadoInicio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnProcesar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.GroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.btnProcesar)
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(320, 232)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ebAsociadoFin)
        Me.GroupBox1.Controls.Add(Me.ebAsociadoInicio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 120)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Rango "
        '
        'ebAsociadoFin
        '
        Me.ebAsociadoFin.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAsociadoFin.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAsociadoFin.BackColor = System.Drawing.Color.Ivory
        Me.ebAsociadoFin.ButtonImage = CType(resources.GetObject("ebAsociadoFin.ButtonImage"), System.Drawing.Image)
        Me.ebAsociadoFin.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebAsociadoFin.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAsociadoFin.Location = New System.Drawing.Point(130, 72)
        Me.ebAsociadoFin.Name = "ebAsociadoFin"
        Me.ebAsociadoFin.Size = New System.Drawing.Size(108, 22)
        Me.ebAsociadoFin.TabIndex = 3
        Me.ebAsociadoFin.Text = "0"
        Me.ebAsociadoFin.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebAsociadoFin.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebAsociadoFin.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAsociadoInicio
        '
        Me.ebAsociadoInicio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAsociadoInicio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAsociadoInicio.BackColor = System.Drawing.Color.Ivory
        Me.ebAsociadoInicio.ButtonImage = CType(resources.GetObject("ebAsociadoInicio.ButtonImage"), System.Drawing.Image)
        Me.ebAsociadoInicio.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebAsociadoInicio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAsociadoInicio.Location = New System.Drawing.Point(130, 32)
        Me.ebAsociadoInicio.Name = "ebAsociadoInicio"
        Me.ebAsociadoInicio.Size = New System.Drawing.Size(108, 22)
        Me.ebAsociadoInicio.TabIndex = 2
        Me.ebAsociadoInicio.Text = "0"
        Me.ebAsociadoInicio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebAsociadoInicio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebAsociadoInicio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Asociado Fin"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Asociado Inicio"
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.Location = New System.Drawing.Point(64, 152)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(168, 32)
        Me.btnProcesar.TabIndex = 1
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EstadoCuentaGeneralReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(306, 199)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "EstadoCuentaGeneralReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de Cuenta General"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

#Region "Objetos"

    'Dim wsEstadoCuenta As wsPagosCreditoDirecto.PagosCreditoDirecto
    Dim dsEstadoCuenta As DataSet

#End Region

#End Region

    Private Sub InitializeObjects()

        'wsEstadoCuenta = New wsPagosCreditoDirecto.PagosCreditoDirecto

        If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'wsEstadoCuenta.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            'wsEstadoCuenta.strUrl.TrimStart("/")

        End If

        dsEstadoCuenta = New DataSet

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        If ebAsociadoFin.Value < ebAsociadoInicio.Value Then

            MsgBox("Valor de Asociado Fin debe ser mayor o igual a Asociado Inicio", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Estado de Cuenta General")

            ebAsociadoFin.Focus()

            Exit Sub

        End If

        Me.Cursor = Cursors.WaitCursor

        ProcesaInfo()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ProcesaInfo()

        dsEstadoCuenta = Nothing
        dsEstadoCuenta = New DataSet

        Dim arEstadoCuenta As IAsyncResult

        'arEstadoCuenta = wsEstadoCuenta.BeginGetPagoCreditoDirectoAsociadosRange(ebAsociadoInicio.Value, ebAsociadoFin.Value, Nothing, Nothing)

        arEstadoCuenta.AsyncWaitHandle.WaitOne()

        'dsEstadoCuenta = wsEstadoCuenta.GetPagoCreditoDirectoAsociadosRange(ebAsociadoInicio.Value, ebAsociadoFin.Value)

        ' dsEstadoCuenta = wsEstadoCuenta.EndGetPagoCreditoDirectoAsociadosRange(arEstadoCuenta)

        If Not dsEstadoCuenta Is Nothing Then

            If dsEstadoCuenta.Tables(0).Rows.Count > 0 Then

                TransformDataToReport()

                PreviewReportEstadoCuenta()

            Else

                Me.Cursor = Cursors.Default

                MsgBox("El rango seleccionado no ha producido resultados. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Estado de Cuenta General")

                ebAsociadoInicio.Focus()

                Exit Sub

            End If

        Else

            Me.Cursor = Cursors.Default

            MsgBox("El rango seleccionado no ha producido resultados. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Estado de Cuenta General")

            ebAsociadoFin.Focus()

            Exit Sub

        End If

    End Sub

    Private Sub PreviewReportEstadoCuenta()

        Dim oAAReport As New EstadoCuentaGeneralReport(dsEstadoCuenta, oAppContext.ApplicationConfiguration.NoCaja, GetAlmacen())
        oAAReport.Document.Name = "Estado de Cuenta"
        Dim oReportViewer As New ReportViewerForm
        oReportViewer.Report = oAAReport

        Me.Cursor = Cursors.Default

        oReportViewer.Show()

    End Sub

    Private Sub TransformDataToReport()

        Dim dCol As New DataColumn
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "MontoFactura"
        dCol.DefaultValue = 0
        dsEstadoCuenta.Tables(0).Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "MontoAbonoReal"
        dCol.DefaultValue = 0
        dsEstadoCuenta.Tables(0).Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "ObsAbono"
        dCol.DefaultValue = " "
        dsEstadoCuenta.Tables(0).Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "SaldoFacturaReal"
        dCol.DefaultValue = 0
        dsEstadoCuenta.Tables(0).Columns.Add(dCol)

        Dim oRow As DataRow
        Dim intFolioFactura As Integer = 0
        Dim strAlmacen As String = String.Empty
        Dim strCaja As String = String.Empty
        For Each oRow In dsEstadoCuenta.Tables(0).Rows

            If oRow!FolioFactura <> intFolioFactura Or oRow!CodAlmacen <> strAlmacen Or oRow!CodCaja <> strCaja Then
                oRow!MontoFactura = oRow!PagoEstablecido
                oRow!SaldoFacturaReal = oRow!SaldoFactura
                strAlmacen = oRow!CodAlmacen
                strCaja = oRow!CodCaja
                intFolioFactura = oRow!FolioFactura
            End If

            If IsDBNull(oRow!MontoAbono) Then
                oRow!ObsAbono = " "
                oRow!MontoAbonoReal = 0
            Else

                If oRow!MontoAbono > 0 And oRow!StatusRegistro = False Then
                    oRow!ObsAbono = "Cancelado"
                    oRow!MontoAbonoReal = 0
                Else
                    If oRow!MontoAbono > 0 And oRow!StatusRegistro = True Then
                        oRow!MontoAbonoReal = oRow!MontoAbono
                    Else
                        oRow!MontoAbonoReal = 0
                    End If
                End If

            End If

        Next

    End Sub

    Private Sub EstadoCuentaGeneralReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")

            Case Keys.Escape

                Me.Finalize()

                Me.Close()

        End Select

    End Sub

    Private Sub EstadoCuentaGeneralReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitializeObjects()

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

    Private Sub ebAsociadoInicio_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebAsociadoInicio.ButtonClick

        SearchAsociadosCreditoDirecto(0)

    End Sub

    Private Sub ebAsociadoFin_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebAsociadoFin.ButtonClick

        SearchAsociadosCreditoDirecto(1)

    End Sub

    Private Sub SearchAsociadosCreditoDirecto(ByVal Tipo As Integer)

        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New CreditoDirectoEnTiendaOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            If Tipo = 0 Then

                ebAsociadoInicio.Value = oOpenRecordDlg.Record.Item("AsociadoID")

            Else

                ebAsociadoFin.Value = oOpenRecordDlg.Record.Item("AsociadoID")

            End If
            SendKeys.Send("{TAB}")

        End If

    End Sub

End Class
