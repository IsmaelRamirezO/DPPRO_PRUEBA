<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTPV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTPV))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.btnLeerTarjeta = New Janus.Windows.EditControls.UIButton()
        Me.ebNumTarj = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.EBPago = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebCodVendedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.ebCodBanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.EBBanco = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ebAutorizacion = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebPlayerDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.SuspendLayout()
        '
        'btnLeerTarjeta
        '
        Me.btnLeerTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerTarjeta.Icon = CType(resources.GetObject("btnLeerTarjeta.Icon"), System.Drawing.Icon)
        Me.btnLeerTarjeta.Location = New System.Drawing.Point(350, 95)
        Me.btnLeerTarjeta.Name = "btnLeerTarjeta"
        Me.btnLeerTarjeta.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerTarjeta.TabIndex = 3
        Me.btnLeerTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNumTarj
        '
        Me.ebNumTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumTarj.Enabled = False
        Me.ebNumTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumTarj.Location = New System.Drawing.Point(142, 94)
        Me.ebNumTarj.MaxLength = 200
        Me.ebNumTarj.Name = "ebNumTarj"
        Me.ebNumTarj.ReadOnly = True
        Me.ebNumTarj.Size = New System.Drawing.Size(208, 22)
        Me.ebNumTarj.TabIndex = 15
        Me.ebNumTarj.TabStop = False
        Me.ebNumTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.AccessibleDescription = "0"
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 96)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(99, 16)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "No. de Tarjeta"
        '
        'EBPago
        '
        Me.EBPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBPago.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBPago.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBPago.Location = New System.Drawing.Point(142, 9)
        Me.EBPago.MaxLength = 8
        Me.EBPago.Name = "EBPago"
        Me.EBPago.Size = New System.Drawing.Size(112, 22)
        Me.EBPago.TabIndex = 0
        Me.EBPago.Text = "$0.00"
        Me.EBPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.EBPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = "0"
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Monto a Pagar"
        '
        'ebCodVendedor
        '
        Me.ebCodVendedor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodVendedor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodVendedor.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodVendedor.ButtonImage = CType(resources.GetObject("ebCodVendedor.ButtonImage"), System.Drawing.Image)
        Me.ebCodVendedor.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodVendedor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodVendedor.Location = New System.Drawing.Point(142, 37)
        Me.ebCodVendedor.MaxLength = 8
        Me.ebCodVendedor.Name = "ebCodVendedor"
        Me.ebCodVendedor.Size = New System.Drawing.Size(112, 22)
        Me.ebCodVendedor.TabIndex = 1
        Me.ebCodVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(6, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 23)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Player"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(104, 169)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(286, 32)
        Me.btnSalir.TabIndex = 83
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebCodBanco
        '
        Me.ebCodBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodBanco.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        Me.ebCodBanco.ControlStyle.ControlColor = System.Drawing.SystemColors.Window
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.ebCodBanco.DesignTimeLayout = GridEXLayout1
        Me.ebCodBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodBanco.Location = New System.Drawing.Point(142, 66)
        Me.ebCodBanco.Name = "ebCodBanco"
        Me.ebCodBanco.Size = New System.Drawing.Size(72, 22)
        Me.ebCodBanco.TabIndex = 2
        Me.ebCodBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EBBanco
        '
        Me.EBBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBBanco.BackColor = System.Drawing.SystemColors.Info
        Me.EBBanco.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.EBBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBBanco.ForeColor = System.Drawing.Color.Black
        Me.EBBanco.Location = New System.Drawing.Point(222, 66)
        Me.EBBanco.Name = "EBBanco"
        Me.EBBanco.ReadOnly = True
        Me.EBBanco.Size = New System.Drawing.Size(168, 22)
        Me.EBBanco.TabIndex = 85
        Me.EBBanco.TabStop = False
        Me.EBBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = "0"
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 16)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "Terminal"
        '
        'ebAutorizacion
        '
        Me.ebAutorizacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAutorizacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAutorizacion.BackColor = System.Drawing.SystemColors.Info
        Me.ebAutorizacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAutorizacion.Location = New System.Drawing.Point(142, 123)
        Me.ebAutorizacion.MaxLength = 10
        Me.ebAutorizacion.Name = "ebAutorizacion"
        Me.ebAutorizacion.Numeric = True
        Me.ebAutorizacion.ReadOnly = True
        Me.ebAutorizacion.Size = New System.Drawing.Size(208, 22)
        Me.ebAutorizacion.TabIndex = 87
        Me.ebAutorizacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAutorizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = "0"
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 16)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "No. Autorización"
        '
        'ebPlayerDescripcion
        '
        Me.ebPlayerDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerDescripcion.BackColor = System.Drawing.SystemColors.Info
        Me.ebPlayerDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebPlayerDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayerDescripcion.Location = New System.Drawing.Point(260, 37)
        Me.ebPlayerDescripcion.Name = "ebPlayerDescripcion"
        Me.ebPlayerDescripcion.ReadOnly = True
        Me.ebPlayerDescripcion.Size = New System.Drawing.Size(273, 21)
        Me.ebPlayerDescripcion.TabIndex = 89
        Me.ebPlayerDescripcion.TabStop = False
        Me.ebPlayerDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmTPV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 207)
        Me.ControlBox = False
        Me.Controls.Add(Me.ebPlayerDescripcion)
        Me.Controls.Add(Me.ebAutorizacion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ebCodBanco)
        Me.Controls.Add(Me.EBBanco)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.ebCodVendedor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.EBPago)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnLeerTarjeta)
        Me.Controls.Add(Me.ebNumTarj)
        Me.Controls.Add(Me.Label13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmTPV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TPV Virtual"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLeerTarjeta As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebNumTarj As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents EBPago As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebCodVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebCodBanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents EBBanco As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ebAutorizacion As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ebPlayerDescripcion As Janus.Windows.GridEX.EditControls.EditBox
End Class
