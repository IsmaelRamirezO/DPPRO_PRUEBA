Public Class FrmNumReferenciaX
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
    Friend WithEvents UiBtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumRef As System.Windows.Forms.TextBox
    Friend WithEvents MthCldar As System.Windows.Forms.MonthCalendar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNumReferenciaX))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiBtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.MthCldar = New System.Windows.Forms.MonthCalendar()
        Me.txtNumRef = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.txtNumRef)
        Me.ExplorerBar1.Controls.Add(Me.UiBtnSalir)
        Me.ExplorerBar1.Controls.Add(Me.MthCldar)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Selecciona Dia"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(368, 392)
        Me.ExplorerBar1.TabIndex = 2
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiBtnSalir
        '
        Me.UiBtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.UiBtnSalir.Icon = CType(resources.GetObject("UiBtnSalir.Icon"), System.Drawing.Icon)
        Me.UiBtnSalir.Location = New System.Drawing.Point(131, 349)
        Me.UiBtnSalir.Name = "UiBtnSalir"
        Me.UiBtnSalir.Size = New System.Drawing.Size(104, 32)
        Me.UiBtnSalir.TabIndex = 9
        Me.UiBtnSalir.Text = "&Salir"
        Me.UiBtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'MthCldar
        '
        Me.MthCldar.Location = New System.Drawing.Point(78, 48)
        Me.MthCldar.MaxSelectionCount = 1
        Me.MthCldar.Name = "MthCldar"
        Me.MthCldar.TabIndex = 8
        '
        'txtNumRef
        '
        Me.txtNumRef.BackColor = System.Drawing.Color.White
        Me.txtNumRef.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumRef.ForeColor = System.Drawing.Color.Red
        Me.txtNumRef.Location = New System.Drawing.Point(78, 265)
        Me.txtNumRef.Multiline = True
        Me.txtNumRef.Name = "txtNumRef"
        Me.txtNumRef.ReadOnly = True
        Me.txtNumRef.Size = New System.Drawing.Size(227, 78)
        Me.txtNumRef.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(118, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Numero de Referencia"
        '
        'FrmNumReferenciaX
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.UiBtnSalir
        Me.ClientSize = New System.Drawing.Size(360, 386)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(376, 424)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(376, 424)
        Me.Name = "FrmNumReferenciaX"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Numero de Referencia Bancaria"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub UiBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBtnSalir.Click
        Me.Close()
    End Sub

    Private Sub MthCldar_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MthCldar.DateSelected
        '----------------Numero de Referencia---------------
        Dim numref As New NumeroReferencia.cNumReferencia
        txtNumRef.Text = numref.getNumReferencia(oAppContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(MthCldar.SelectionStart, "ddMMyyyy")))
        '------------------------------------------------------
    End Sub
End Class
