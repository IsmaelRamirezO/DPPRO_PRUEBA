<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicioDispersion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServicioDispersion))
        Me.cmbServicio = New Janus.Windows.EditControls.UIComboBox()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.txtCuenta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblClabe = New System.Windows.Forms.Label()
        Me.txtClabe = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNumTarjeta = New System.Windows.Forms.Label()
        Me.lblCompania = New System.Windows.Forms.Label()
        Me.cmbCompania = New Janus.Windows.EditControls.UIComboBox()
        Me.lblCelular = New System.Windows.Forms.Label()
        Me.btnDispersar = New Janus.Windows.EditControls.UIButton()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.chkTransfer = New Janus.Windows.EditControls.UICheckBox()
        Me.cmbBanco = New Janus.Windows.EditControls.UIComboBox()
        Me.lblTranfer = New System.Windows.Forms.Label()
        Me.txtNombreCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.txtNoTarjeta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNumeroTarjeta = New System.Windows.Forms.Label()
        Me.txtNumTarjeta = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtCelular = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.SuspendLayout()
        '
        'cmbServicio
        '
        Me.cmbServicio.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cmbServicio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbServicio.Location = New System.Drawing.Point(144, 70)
        Me.cmbServicio.Name = "cmbServicio"
        Me.cmbServicio.SelectInDataSource = True
        Me.cmbServicio.Size = New System.Drawing.Size(174, 22)
        Me.cmbServicio.TabIndex = 3
        Me.cmbServicio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblServicio
        '
        Me.lblServicio.AutoSize = True
        Me.lblServicio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServicio.Location = New System.Drawing.Point(12, 74)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(64, 16)
        Me.lblServicio.TabIndex = 25
        Me.lblServicio.Text = "Servicio:"
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanco.Location = New System.Drawing.Point(12, 102)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(52, 16)
        Me.lblBanco.TabIndex = 27
        Me.lblBanco.Text = "Banco:"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuenta.Location = New System.Drawing.Point(12, 129)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(59, 16)
        Me.lblCuenta.TabIndex = 29
        Me.lblCuenta.Text = "Cuenta:"
        '
        'txtCuenta
        '
        Me.txtCuenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCuenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCuenta.BackColor = System.Drawing.Color.White
        Me.txtCuenta.Location = New System.Drawing.Point(144, 129)
        Me.txtCuenta.MaxLength = 20
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(174, 20)
        Me.txtCuenta.TabIndex = 5
        Me.txtCuenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCuenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblClabe
        '
        Me.lblClabe.AutoSize = True
        Me.lblClabe.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClabe.Location = New System.Drawing.Point(12, 154)
        Me.lblClabe.Name = "lblClabe"
        Me.lblClabe.Size = New System.Drawing.Size(53, 16)
        Me.lblClabe.TabIndex = 31
        Me.lblClabe.Text = "CLABE:"
        '
        'txtClabe
        '
        Me.txtClabe.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtClabe.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtClabe.BackColor = System.Drawing.Color.White
        Me.txtClabe.Location = New System.Drawing.Point(144, 154)
        Me.txtClabe.MaxLength = 20
        Me.txtClabe.Name = "txtClabe"
        Me.txtClabe.Size = New System.Drawing.Size(174, 20)
        Me.txtClabe.TabIndex = 6
        Me.txtClabe.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtClabe.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNumTarjeta
        '
        Me.lblNumTarjeta.AutoSize = True
        Me.lblNumTarjeta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumTarjeta.Location = New System.Drawing.Point(12, 178)
        Me.lblNumTarjeta.Name = "lblNumTarjeta"
        Me.lblNumTarjeta.Size = New System.Drawing.Size(95, 16)
        Me.lblNumTarjeta.TabIndex = 33
        Me.lblNumTarjeta.Text = "Num. Tarjeta:"
        '
        'lblCompania
        '
        Me.lblCompania.AutoSize = True
        Me.lblCompania.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompania.Location = New System.Drawing.Point(12, 207)
        Me.lblCompania.Name = "lblCompania"
        Me.lblCompania.Size = New System.Drawing.Size(75, 16)
        Me.lblCompania.TabIndex = 35
        Me.lblCompania.Text = "Compañia:"
        '
        'cmbCompania
        '
        Me.cmbCompania.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cmbCompania.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCompania.Location = New System.Drawing.Point(144, 207)
        Me.cmbCompania.Name = "cmbCompania"
        Me.cmbCompania.ReadOnly = True
        Me.cmbCompania.Size = New System.Drawing.Size(174, 22)
        Me.cmbCompania.TabIndex = 8
        Me.cmbCompania.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblCelular
        '
        Me.lblCelular.AutoSize = True
        Me.lblCelular.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelular.Location = New System.Drawing.Point(12, 237)
        Me.lblCelular.Name = "lblCelular"
        Me.lblCelular.Size = New System.Drawing.Size(57, 16)
        Me.lblCelular.TabIndex = 37
        Me.lblCelular.Text = "Celular:"
        '
        'btnDispersar
        '
        Me.btnDispersar.Location = New System.Drawing.Point(144, 286)
        Me.btnDispersar.Name = "btnDispersar"
        Me.btnDispersar.Size = New System.Drawing.Size(86, 25)
        Me.btnDispersar.TabIndex = 11
        Me.btnDispersar.Text = "&Dispersar"
        Me.btnDispersar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(232, 286)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(86, 25)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'chkTransfer
        '
        Me.chkTransfer.BackColor = System.Drawing.Color.Transparent
        Me.chkTransfer.Location = New System.Drawing.Point(144, 264)
        Me.chkTransfer.Name = "chkTransfer"
        Me.chkTransfer.Size = New System.Drawing.Size(64, 16)
        Me.chkTransfer.TabIndex = 10
        Me.chkTransfer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cmbBanco
        '
        Me.cmbBanco.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cmbBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBanco.Location = New System.Drawing.Point(144, 98)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(174, 22)
        Me.cmbBanco.TabIndex = 4
        Me.cmbBanco.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblTranfer
        '
        Me.lblTranfer.AutoSize = True
        Me.lblTranfer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTranfer.Location = New System.Drawing.Point(14, 262)
        Me.lblTranfer.Name = "lblTranfer"
        Me.lblTranfer.Size = New System.Drawing.Size(68, 16)
        Me.lblTranfer.TabIndex = 259
        Me.lblTranfer.Text = "Transfer:"
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNombreCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNombreCliente.BackColor = System.Drawing.Color.White
        Me.txtNombreCliente.Enabled = False
        Me.txtNombreCliente.Location = New System.Drawing.Point(144, 46)
        Me.txtNombreCliente.MaxLength = 20
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.Size = New System.Drawing.Size(174, 20)
        Me.txtNombreCliente.TabIndex = 2
        Me.txtNombreCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNombreCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.Location = New System.Drawing.Point(12, 46)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(130, 16)
        Me.lblNombreCliente.TabIndex = 263
        Me.lblNombreCliente.Text = "Nombre de Cliente:"
        '
        'txtNoTarjeta
        '
        Me.txtNoTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNoTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNoTarjeta.BackColor = System.Drawing.Color.White
        Me.txtNoTarjeta.Enabled = False
        Me.txtNoTarjeta.Location = New System.Drawing.Point(144, 21)
        Me.txtNoTarjeta.MaxLength = 20
        Me.txtNoTarjeta.Name = "txtNoTarjeta"
        Me.txtNoTarjeta.Size = New System.Drawing.Size(174, 20)
        Me.txtNoTarjeta.TabIndex = 1
        Me.txtNoTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNoTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNumeroTarjeta
        '
        Me.lblNumeroTarjeta.AutoSize = True
        Me.lblNumeroTarjeta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroTarjeta.Location = New System.Drawing.Point(12, 21)
        Me.lblNumeroTarjeta.Name = "lblNumeroTarjeta"
        Me.lblNumeroTarjeta.Size = New System.Drawing.Size(132, 16)
        Me.lblNumeroTarjeta.TabIndex = 262
        Me.lblNumeroTarjeta.Text = "Número de tarjeta:"
        '
        'txtNumTarjeta
        '
        Me.txtNumTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNumTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNumTarjeta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumTarjeta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumTarjeta.Location = New System.Drawing.Point(144, 180)
        Me.txtNumTarjeta.MaxLength = 16
        Me.txtNumTarjeta.Name = "txtNumTarjeta"
        Me.txtNumTarjeta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNumTarjeta.Size = New System.Drawing.Size(174, 22)
        Me.txtNumTarjeta.TabIndex = 7
        Me.txtNumTarjeta.Text = "DESLIZE TARJETA ..."
        Me.txtNumTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNumTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtCelular
        '
        Me.txtCelular.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCelular.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCelular.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelular.Location = New System.Drawing.Point(144, 235)
        Me.txtCelular.Mask = "!(###) 000-0000"
        Me.txtCelular.MaxLength = 16
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCelular.Size = New System.Drawing.Size(174, 22)
        Me.txtCelular.TabIndex = 264
        Me.txtCelular.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCelular.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmServicioDispersion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(336, 323)
        Me.Controls.Add(Me.txtCelular)
        Me.Controls.Add(Me.txtNumTarjeta)
        Me.Controls.Add(Me.txtNombreCliente)
        Me.Controls.Add(Me.lblNombreCliente)
        Me.Controls.Add(Me.txtNoTarjeta)
        Me.Controls.Add(Me.lblNumeroTarjeta)
        Me.Controls.Add(Me.lblTranfer)
        Me.Controls.Add(Me.chkTransfer)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnDispersar)
        Me.Controls.Add(Me.lblCelular)
        Me.Controls.Add(Me.cmbCompania)
        Me.Controls.Add(Me.lblCompania)
        Me.Controls.Add(Me.lblNumTarjeta)
        Me.Controls.Add(Me.txtClabe)
        Me.Controls.Add(Me.lblClabe)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.lblCuenta)
        Me.Controls.Add(Me.cmbBanco)
        Me.Controls.Add(Me.lblBanco)
        Me.Controls.Add(Me.cmbServicio)
        Me.Controls.Add(Me.lblServicio)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicioDispersion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dispersar prestamo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbServicio As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblServicio As System.Windows.Forms.Label
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblClabe As System.Windows.Forms.Label
    Friend WithEvents txtClabe As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNumTarjeta As System.Windows.Forms.Label
    Friend WithEvents lblCompania As System.Windows.Forms.Label
    Friend WithEvents cmbCompania As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblCelular As System.Windows.Forms.Label
    Friend WithEvents btnDispersar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkTransfer As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents cmbBanco As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblTranfer As System.Windows.Forms.Label
    Friend WithEvents txtNombreCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents txtNoTarjeta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNumeroTarjeta As System.Windows.Forms.Label
    Friend WithEvents txtNumTarjeta As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtCelular As Janus.Windows.GridEX.EditControls.MaskedEditBox
End Class
