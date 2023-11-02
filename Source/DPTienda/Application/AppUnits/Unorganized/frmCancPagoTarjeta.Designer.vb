<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancPagoTarjeta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancPagoTarjeta))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebAfiliacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ebNumAut = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNumeroAutorizacion = New System.Windows.Forms.Label()
        Me.txtCVV2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebMontoPago = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebPlayerDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodVendedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPromocion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblPromocion = New System.Windows.Forms.Label()
        Me.btnCancelarPago = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebNumTarj = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.ebAfiliacion)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.ebNumAut)
        Me.ExplorerBar1.Controls.Add(Me.lblNumeroAutorizacion)
        Me.ExplorerBar1.Controls.Add(Me.txtCVV2)
        Me.ExplorerBar1.Controls.Add(Me.ebMontoPago)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.ebPlayerDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.ebCodVendedor)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.cmbPromocion)
        Me.ExplorerBar1.Controls.Add(Me.lblPromocion)
        Me.ExplorerBar1.Controls.Add(Me.btnCancelarPago)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.ebNumTarj)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(452, 160)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebAfiliacion
        '
        Me.ebAfiliacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAfiliacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAfiliacion.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebAfiliacion.Location = New System.Drawing.Point(330, 40)
        Me.ebAfiliacion.MaxLength = 20
        Me.ebAfiliacion.Name = "ebAfiliacion"
        Me.ebAfiliacion.Size = New System.Drawing.Size(108, 22)
        Me.ebAfiliacion.TabIndex = 226
        Me.ebAfiliacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAfiliacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(254, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 23)
        Me.Label4.TabIndex = 227
        Me.Label4.Text = "Afiliación:"
        '
        'ebNumAut
        '
        Me.ebNumAut.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumAut.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumAut.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebNumAut.Location = New System.Drawing.Point(124, 41)
        Me.ebNumAut.MaxLength = 20
        Me.ebNumAut.Name = "ebNumAut"
        Me.ebNumAut.Size = New System.Drawing.Size(108, 22)
        Me.ebNumAut.TabIndex = 2
        Me.ebNumAut.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumAut.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNumeroAutorizacion
        '
        Me.lblNumeroAutorizacion.BackColor = System.Drawing.Color.Transparent
        Me.lblNumeroAutorizacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroAutorizacion.Location = New System.Drawing.Point(14, 43)
        Me.lblNumeroAutorizacion.Name = "lblNumeroAutorizacion"
        Me.lblNumeroAutorizacion.Size = New System.Drawing.Size(104, 23)
        Me.lblNumeroAutorizacion.TabIndex = 225
        Me.lblNumeroAutorizacion.Text = "Autorización:"
        '
        'txtCVV2
        '
        Me.txtCVV2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCVV2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCVV2.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Location = New System.Drawing.Point(124, 44)
        Me.txtCVV2.Name = "txtCVV2"
        Me.txtCVV2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCVV2.Size = New System.Drawing.Size(75, 22)
        Me.txtCVV2.TabIndex = 2
        Me.txtCVV2.Text = "123"
        Me.txtCVV2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCVV2.Visible = False
        Me.txtCVV2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMontoPago
        '
        Me.ebMontoPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoPago.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMontoPago.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebMontoPago.Location = New System.Drawing.Point(124, 97)
        Me.ebMontoPago.MaxLength = 8
        Me.ebMontoPago.Name = "ebMontoPago"
        Me.ebMontoPago.Size = New System.Drawing.Size(108, 22)
        Me.ebMontoPago.TabIndex = 5
        Me.ebMontoPago.Text = "$0.00"
        Me.ebMontoPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMontoPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = "0"
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 16)
        Me.Label2.TabIndex = 220
        Me.Label2.Text = "Monto a Pagar:"
        '
        'ebPlayerDescripcion
        '
        Me.ebPlayerDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerDescripcion.BackColor = System.Drawing.SystemColors.Info
        Me.ebPlayerDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebPlayerDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayerDescripcion.Location = New System.Drawing.Point(238, 13)
        Me.ebPlayerDescripcion.Name = "ebPlayerDescripcion"
        Me.ebPlayerDescripcion.ReadOnly = True
        Me.ebPlayerDescripcion.Size = New System.Drawing.Size(200, 21)
        Me.ebPlayerDescripcion.TabIndex = 1
        Me.ebPlayerDescripcion.TabStop = False
        Me.ebPlayerDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
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
        Me.ebCodVendedor.Location = New System.Drawing.Point(124, 13)
        Me.ebCodVendedor.MaxLength = 8
        Me.ebCodVendedor.Name = "ebCodVendedor"
        Me.ebCodVendedor.Size = New System.Drawing.Size(108, 22)
        Me.ebCodVendedor.TabIndex = 0
        Me.ebCodVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(14, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 23)
        Me.Label7.TabIndex = 217
        Me.Label7.Text = "Num. Player:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(-116, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 213
        Me.Label5.Text = "Player:"
        '
        'cmbPromocion
        '
        Me.cmbPromocion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbPromocion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbPromocion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.cmbPromocion.DesignTimeLayout = GridEXLayout2
        Me.cmbPromocion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cmbPromocion.Location = New System.Drawing.Point(124, 126)
        Me.cmbPromocion.Name = "cmbPromocion"
        Me.cmbPromocion.Size = New System.Drawing.Size(108, 22)
        Me.cmbPromocion.TabIndex = 6
        Me.cmbPromocion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbPromocion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPromocion
        '
        Me.lblPromocion.AccessibleDescription = "0"
        Me.lblPromocion.AutoSize = True
        Me.lblPromocion.BackColor = System.Drawing.Color.Transparent
        Me.lblPromocion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPromocion.Location = New System.Drawing.Point(14, 126)
        Me.lblPromocion.Name = "lblPromocion"
        Me.lblPromocion.Size = New System.Drawing.Size(84, 16)
        Me.lblPromocion.TabIndex = 38
        Me.lblPromocion.Text = "Promoción :"
        '
        'btnCancelarPago
        '
        Me.btnCancelarPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarPago.Location = New System.Drawing.Point(238, 97)
        Me.btnCancelarPago.Name = "btnCancelarPago"
        Me.btnCancelarPago.Size = New System.Drawing.Size(200, 51)
        Me.btnCancelarPago.TabIndex = 7
        Me.btnCancelarPago.Text = "&Cancelar Pago"
        Me.btnCancelarPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Num. Tajeta:"
        '
        'ebNumTarj
        '
        Me.ebNumTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumTarj.Location = New System.Drawing.Point(124, 69)
        Me.ebNumTarj.MaxLength = 200
        Me.ebNumTarj.Name = "ebNumTarj"
        Me.ebNumTarj.ReadOnly = True
        Me.ebNumTarj.Size = New System.Drawing.Size(275, 22)
        Me.ebNumTarj.TabIndex = 3
        Me.ebNumTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmCancPagoTarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 160)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCancPagoTarjeta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelar Pago Tarjeta"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnCancelarPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ebNumTarj As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents cmbPromocion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblPromocion As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ebMontoPago As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebPlayerDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCVV2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNumAut As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNumeroAutorizacion As System.Windows.Forms.Label
    Friend WithEvents ebAfiliacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
