Public Class PruebaPoliza
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ccFechaDesde As Janus.Windows.CalendarCombo.CalendarCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ccFechaDesde = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(88, 168)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'ccFechaDesde
        '
        Me.ccFechaDesde.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        '
        '
        '
        Me.ccFechaDesde.DropDownCalendar.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ccFechaDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccFechaDesde.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ccFechaDesde.Location = New System.Drawing.Point(72, 104)
        Me.ccFechaDesde.MaxDate = New Date(2100, 2, 1, 0, 0, 0, 0)
        Me.ccFechaDesde.Name = "ccFechaDesde"
        Me.ccFechaDesde.Size = New System.Drawing.Size(136, 22)
        Me.ccFechaDesde.TabIndex = 25
        Me.ccFechaDesde.Value = New Date(2005, 4, 22, 0, 0, 0, 0)
        Me.ccFechaDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'PruebaPoliza
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.ccFechaDesde)
        Me.Controls.Add(Me.Button1)
        Me.Name = "PruebaPoliza"
        Me.Text = "PruebaPoliza"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    

        PrintReportPoliza("01", ccFechaDesde.Value)

    End Sub

    Public Sub PrintReportPoliza(ByVal TipoVenta As String, ByVal Fecha As Date)

        Dim oARReporte As New rptPoliza(TipoVenta, Fecha)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Poliza"

        oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            oARReporte.Document.Print(True, True)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class
