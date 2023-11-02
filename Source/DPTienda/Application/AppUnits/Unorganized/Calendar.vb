Public Class Calendar
    Inherits System.Windows.Forms.UserControl

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
    Friend WithEvents Schedule1 As Janus.Windows.Schedule.Schedule
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Schedule1 = New Janus.Windows.Schedule.Schedule()
        CType(Me.Schedule1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Schedule1
        '
        Me.Schedule1.Date = New Date(2004, 12, 10, 0, 0, 0, 0)
        Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Schedule1.Location = New System.Drawing.Point(0, 0)
        Me.Schedule1.Name = "Schedule1"
        Me.Schedule1.Size = New System.Drawing.Size(600, 600)
        Me.Schedule1.TabIndex = 0
        Me.Schedule1.VerticalScrollPosition = 16
        Me.Schedule1.VisualStyle = Janus.Windows.Schedule.VisualStyle.Office2010
        '
        'Calendar
        '
        Me.Controls.Add(Me.Schedule1)
        Me.Name = "Calendar"
        Me.Size = New System.Drawing.Size(600, 600)
        CType(Me.Schedule1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Schedule1_AppointmentChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.Schedule.AppointmentChangeEventArgs) Handles Schedule1.AppointmentChanged

    End Sub
End Class
