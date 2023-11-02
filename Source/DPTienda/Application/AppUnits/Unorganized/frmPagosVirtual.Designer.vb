<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagosVirtual
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
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnAbonoDPCard = New Janus.Windows.EditControls.UIButton()
        Me.btnPagoDPCard = New Janus.Windows.EditControls.UIButton()
        Me.btnCancelarPagosTarjetas = New Janus.Windows.EditControls.UIButton()
        Me.btnPagosTarjetas = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnAbonoDPCard)
        Me.ExplorerBar1.Controls.Add(Me.btnPagoDPCard)
        Me.ExplorerBar1.Controls.Add(Me.btnCancelarPagosTarjetas)
        Me.ExplorerBar1.Controls.Add(Me.btnPagosTarjetas)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(222, 162)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnAbonoDPCard
        '
        Me.btnAbonoDPCard.Location = New System.Drawing.Point(12, 118)
        Me.btnAbonoDPCard.Name = "btnAbonoDPCard"
        Me.btnAbonoDPCard.Size = New System.Drawing.Size(198, 32)
        Me.btnAbonoDPCard.TabIndex = 17
        Me.btnAbonoDPCard.Text = "&Abono DPCard Credit"
        Me.btnAbonoDPCard.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnPagoDPCard
        '
        Me.btnPagoDPCard.Location = New System.Drawing.Point(12, 80)
        Me.btnPagoDPCard.Name = "btnPagoDPCard"
        Me.btnPagoDPCard.Size = New System.Drawing.Size(198, 32)
        Me.btnPagoDPCard.TabIndex = 16
        Me.btnPagoDPCard.Text = "Pago DPCard Credit"
        Me.btnPagoDPCard.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnCancelarPagosTarjetas
        '
        Me.btnCancelarPagosTarjetas.Location = New System.Drawing.Point(12, 43)
        Me.btnCancelarPagosTarjetas.Name = "btnCancelarPagosTarjetas"
        Me.btnCancelarPagosTarjetas.Size = New System.Drawing.Size(198, 32)
        Me.btnCancelarPagosTarjetas.TabIndex = 15
        Me.btnCancelarPagosTarjetas.Text = "&Cancelar Pagos Tarjetas"
        Me.btnCancelarPagosTarjetas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnPagosTarjetas
        '
        Me.btnPagosTarjetas.Location = New System.Drawing.Point(12, 6)
        Me.btnPagosTarjetas.Name = "btnPagosTarjetas"
        Me.btnPagosTarjetas.Size = New System.Drawing.Size(198, 32)
        Me.btnPagosTarjetas.TabIndex = 14
        Me.btnPagosTarjetas.Text = "&Pagos con Tarjetas"
        Me.btnPagosTarjetas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmPagosVirtual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(222, 162)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmPagosVirtual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagos Virtuales"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnAbonoDPCard As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPagoDPCard As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelarPagosTarjetas As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPagosTarjetas As Janus.Windows.EditControls.UIButton
End Class
