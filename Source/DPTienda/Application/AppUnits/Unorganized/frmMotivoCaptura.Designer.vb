<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotivoCaptura
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMotivoCaptura))
        Me.explorer = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbMotivos = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnSiguiente = New Janus.Windows.EditControls.UIButton()
        CType(Me.explorer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorer.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorer
        '
        Me.explorer.Controls.Add(Me.Label9)
        Me.explorer.Controls.Add(Me.cmbMotivos)
        Me.explorer.Controls.Add(Me.btnSiguiente)
        Me.explorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorer.Location = New System.Drawing.Point(0, 0)
        Me.explorer.Name = "explorer"
        Me.explorer.Size = New System.Drawing.Size(312, 224)
        Me.explorer.TabIndex = 2
        Me.explorer.Text = "ExplorerBar1"
        Me.explorer.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = "0"
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(24, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 16)
        Me.Label9.TabIndex = 244
        Me.Label9.Text = "Motivo"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbMotivos
        '
        Me.cmbMotivos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbMotivos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbMotivos.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbMotivos.DesignTimeLayout = GridEXLayout1
        Me.cmbMotivos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMotivos.Location = New System.Drawing.Point(27, 46)
        Me.cmbMotivos.Name = "cmbMotivos"
        Me.cmbMotivos.Size = New System.Drawing.Size(252, 22)
        Me.cmbMotivos.TabIndex = 243
        Me.cmbMotivos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMotivos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(204, 173)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(75, 24)
        Me.btnSiguiente.TabIndex = 4
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmMotivoCaptura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 224)
        Me.ControlBox = False
        Me.Controls.Add(Me.explorer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMotivoCaptura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tarjetas tecleadas manualmente"
        CType(Me.explorer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorer.ResumeLayout(False)
        Me.explorer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents explorer As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbMotivos As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnSiguiente As Janus.Windows.EditControls.UIButton
End Class
