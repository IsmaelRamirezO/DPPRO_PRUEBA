<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTarjetaHabiente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTarjetaHabiente))
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPaterno = New System.Windows.Forms.Label()
        Me.txtPaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblMaterno = New System.Windows.Forms.Label()
        Me.txtMaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.SuspendLayout()
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(3, 11)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(62, 16)
        Me.lblNombre.TabIndex = 20
        Me.lblNombre.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(77, 9)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(200, 21)
        Me.txtNombre.TabIndex = 21
        Me.txtNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPaterno
        '
        Me.lblPaterno.AutoSize = True
        Me.lblPaterno.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaterno.Location = New System.Drawing.Point(3, 34)
        Me.lblPaterno.Name = "lblPaterno"
        Me.lblPaterno.Size = New System.Drawing.Size(65, 16)
        Me.lblPaterno.TabIndex = 22
        Me.lblPaterno.Text = "Paterno:"
        '
        'txtPaterno
        '
        Me.txtPaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPaterno.BackColor = System.Drawing.SystemColors.Info
        Me.txtPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaterno.Location = New System.Drawing.Point(77, 33)
        Me.txtPaterno.Name = "txtPaterno"
        Me.txtPaterno.Size = New System.Drawing.Size(200, 21)
        Me.txtPaterno.TabIndex = 23
        Me.txtPaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblMaterno
        '
        Me.lblMaterno.AutoSize = True
        Me.lblMaterno.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterno.Location = New System.Drawing.Point(3, 58)
        Me.lblMaterno.Name = "lblMaterno"
        Me.lblMaterno.Size = New System.Drawing.Size(68, 16)
        Me.lblMaterno.TabIndex = 24
        Me.lblMaterno.Text = "Materno:"
        '
        'txtMaterno
        '
        Me.txtMaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtMaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtMaterno.BackColor = System.Drawing.SystemColors.Info
        Me.txtMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaterno.Location = New System.Drawing.Point(77, 57)
        Me.txtMaterno.Name = "txtMaterno"
        Me.txtMaterno.Size = New System.Drawing.Size(200, 21)
        Me.txtMaterno.TabIndex = 25
        Me.txtMaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtMaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(201, 84)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 24)
        Me.btnCancelar.TabIndex = 27
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.Location = New System.Drawing.Point(121, 84)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 24)
        Me.btnAceptar.TabIndex = 26
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmTarjetaHabiente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(284, 115)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtMaterno)
        Me.Controls.Add(Me.lblMaterno)
        Me.Controls.Add(Me.txtPaterno)
        Me.Controls.Add(Me.lblPaterno)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblNombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTarjetaHabiente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tarjetahabientes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPaterno As System.Windows.Forms.Label
    Friend WithEvents txtPaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblMaterno As System.Windows.Forms.Label
    Friend WithEvents txtMaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
End Class
