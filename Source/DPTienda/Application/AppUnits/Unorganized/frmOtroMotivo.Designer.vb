<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOtroMotivo
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
        Me.explorer = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        CType(Me.explorer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorer.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorer
        '
        Me.explorer.Controls.Add(Me.lblSaldo)
        Me.explorer.Controls.Add(Me.txtMotivo)
        Me.explorer.Controls.Add(Me.btnAceptar)
        Me.explorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorer.Location = New System.Drawing.Point(0, 0)
        Me.explorer.Name = "explorer"
        Me.explorer.Size = New System.Drawing.Size(283, 156)
        Me.explorer.TabIndex = 3
        Me.explorer.Text = "ExplorerBar1"
        Me.explorer.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblSaldo
        '
        Me.lblSaldo.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(12, 18)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(96, 16)
        Me.lblSaldo.TabIndex = 254
        Me.lblSaldo.Text = "Otro motivo:"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(12, 37)
        Me.txtMotivo.MaxLength = 150
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(259, 77)
        Me.txtMotivo.TabIndex = 246
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(196, 120)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 24)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmOtroMotivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 156)
        Me.Controls.Add(Me.explorer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOtroMotivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Motivo"
        CType(Me.explorer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorer.ResumeLayout(False)
        Me.explorer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents explorer As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
End Class
