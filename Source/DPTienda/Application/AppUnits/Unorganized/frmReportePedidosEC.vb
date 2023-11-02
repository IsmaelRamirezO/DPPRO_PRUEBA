Public Class frmReportePedidosEC
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
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbFechaIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cmbFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cmbStatus As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportePedidosEC))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cmbStatus = New Janus.Windows.EditControls.UIComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMostrar = New Janus.Windows.EditControls.UIButton()
        Me.cmbFechaIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecha = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.cmbStatus)
        Me.explorerBar1.Controls.Add(Me.Label2)
        Me.explorerBar1.Controls.Add(Me.cmbFechaFin)
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Controls.Add(Me.btnMostrar)
        Me.explorerBar1.Controls.Add(Me.cmbFechaIni)
        Me.explorerBar1.Controls.Add(Me.lblFecha)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(334, 92)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cmbStatus
        '
        Me.cmbStatus.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "Pendiente"
        UiComboBoxItem1.Value = "P"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "Negado"
        UiComboBoxItem2.Value = "N"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "Facturado"
        UiComboBoxItem3.Value = "F"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "Parcialmente Facturado"
        UiComboBoxItem4.Value = "PF"
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "Cancelado"
        UiComboBoxItem5.Value = "C"
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "Todos"
        UiComboBoxItem6.Value = "TP"
        Me.cmbStatus.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5, UiComboBoxItem6})
        Me.cmbStatus.Location = New System.Drawing.Point(56, 12)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(266, 20)
        Me.cmbStatus.TabIndex = 28
        Me.cmbStatus.Text = "Todos"
        Me.cmbStatus.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(9, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Status"
        '
        'cmbFechaFin
        '
        '
        '
        '
        Me.cmbFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFechaFin.Location = New System.Drawing.Point(56, 64)
        Me.cmbFechaFin.Name = "cmbFechaFin"
        Me.cmbFechaFin.Size = New System.Drawing.Size(106, 20)
        Me.cmbFechaFin.TabIndex = 3
        Me.cmbFechaFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(9, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Hasta"
        '
        'btnMostrar
        '
        Me.btnMostrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrar.Icon = CType(resources.GetObject("btnMostrar.Icon"), System.Drawing.Icon)
        Me.btnMostrar.ImageSize = New System.Drawing.Size(36, 36)
        Me.btnMostrar.Location = New System.Drawing.Point(168, 38)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(154, 46)
        Me.btnMostrar.TabIndex = 4
        Me.btnMostrar.Text = "Generar Reporte"
        Me.btnMostrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cmbFechaIni
        '
        '
        '
        '
        Me.cmbFechaIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFechaIni.Location = New System.Drawing.Point(56, 38)
        Me.cmbFechaIni.Name = "cmbFechaIni"
        Me.cmbFechaIni.Size = New System.Drawing.Size(106, 20)
        Me.cmbFechaIni.TabIndex = 2
        Me.cmbFechaIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Location = New System.Drawing.Point(9, 42)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(38, 13)
        Me.lblFecha.TabIndex = 23
        Me.lblFecha.Text = "Desde"
        '
        'frmReportePedidosEC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(334, 92)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmReportePedidosEC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Pedidos de Ecommerce"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.explorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If Me.cmbFechaIni.Value > Me.cmbFechaFin.Value Then
            MessageBox.Show("La fecha final debe ser mayor a la inicial.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbFechaIni.Focus()
        Else
            Dim oAReport As New rptPedidosTotalesEC(Me.cmbFechaIni.Value, Me.cmbFechaFin.Value, Me.cmbStatus.SelectedValue)
            Dim oReportViewer As New ReportViewerForm
            oAReport.Document.Name = "Reporte de Pedidos de Ecommerce"
            oAReport.Run()
            oReportViewer.Report = oAReport
            oReportViewer.Show()
            Try
                'oAReport.Document.Print(False, False)
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error al generar el Reporte de Pedidos de Ecommerce.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                EscribeLog(ex.ToString, "Error al generar el Reporte de Pedidos de Ecommerce.")
            End Try
        End If
    End Sub

    Private Sub FillStatusEC()

        Dim dtDefectuoso As DataTable
        Me.cmbStatus.DataSource = dtDefectuoso
        Me.cmbStatus.DisplayMember = "Descripcion"
        Me.cmbStatus.ValueMember = "Status"
        Me.cmbStatus.Refresh()
        Me.cmbStatus.SelectedValue = "TP"

    End Sub

    Private Sub frmReportePedidosEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class
