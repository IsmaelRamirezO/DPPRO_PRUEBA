Public Class FrmRptAbonosCDT
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
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblDesde As System.Windows.Forms.Label
    Friend WithEvents ccDesde As Janus.Windows.CalendarCombo.CalendarCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptAbonosCDT))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblDesde = New System.Windows.Forms.Label()
        Me.ccDesde = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.lblDesde)
        Me.explorerBar1.Controls.Add(Me.ccDesde)
        Me.explorerBar1.Controls.Add(Me.btnGenerar)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Reporte Abonos Credito Directo"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(312, 166)
        Me.explorerBar1.TabIndex = 1
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblDesde
        '
        Me.lblDesde.BackColor = System.Drawing.Color.Transparent
        Me.lblDesde.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesde.Location = New System.Drawing.Point(68, 48)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(48, 16)
        Me.lblDesde.TabIndex = 16
        Me.lblDesde.Text = "Fecha"
        '
        'ccDesde
        '
        '
        '
        '
        Me.ccDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccDesde.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ccDesde.Location = New System.Drawing.Point(116, 48)
        Me.ccDesde.Name = "ccDesde"
        Me.ccDesde.Size = New System.Drawing.Size(128, 22)
        Me.ccDesde.TabIndex = 15
        Me.ccDesde.TodayButtonText = "Hoy"
        Me.ccDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(100, 112)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(112, 32)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "Imprimir"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'FrmRptAbonosCDT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 166)
        Me.Controls.Add(Me.explorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmRptAbonosCDT"
        Me.Text = "Reporte de Abono Credito Directo"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.explorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim oReportViewer As New ReportViewerForm
        Dim rptAbonoCDT As New rptReporteAbonosCreditoDirecto(Format(Date.Now, "Short Date"), oAppContext.ApplicationConfiguration.Almacen)

        rptAbonoCDT.Document.Name = "Reporte Abono Credito Directo - " & Format(Date.Now, "Short Date")

        oReportViewer.Report = rptAbonoCDT
        rptAbonoCDT.Run()
        Me.Cursor = Cursors.Default
        oReportViewer.Show()
    End Sub
End Class
