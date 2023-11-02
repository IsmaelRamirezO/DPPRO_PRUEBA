<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagoDpCard
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
        Dim GridEXLayout6 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout5 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagoDpCard))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.btnLeerTarjeta = New Janus.Windows.EditControls.UIButton()
        Me.ebNumTarj = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.lblNumTarjeta = New System.Windows.Forms.Label()
        Me.cmbPromocion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblPromocion = New System.Windows.Forms.Label()
        Me.btnGenerarPago = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.lblTipoVenta = New System.Windows.Forms.Label()
        Me.cmbTipoVenta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTipoPago = New System.Windows.Forms.Label()
        Me.cmbTipoPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebPlayerDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodVendedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNumAutorizacion = New System.Windows.Forms.Label()
        Me.ebNumAutorizacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnNuevo = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnNuevo)
        Me.ExplorerBar1.Controls.Add(Me.ebNumAutorizacion)
        Me.ExplorerBar1.Controls.Add(Me.lblNumAutorizacion)
        Me.ExplorerBar1.Controls.Add(Me.ebPlayerDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.ebCodVendedor)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.cmbTipoPago)
        Me.ExplorerBar1.Controls.Add(Me.lblTipoPago)
        Me.ExplorerBar1.Controls.Add(Me.ebImporte)
        Me.ExplorerBar1.Controls.Add(Me.cmbTipoVenta)
        Me.ExplorerBar1.Controls.Add(Me.lblTipoVenta)
        Me.ExplorerBar1.Controls.Add(Me.btnSalir)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerarPago)
        Me.ExplorerBar1.Controls.Add(Me.cmbPromocion)
        Me.ExplorerBar1.Controls.Add(Me.lblPromocion)
        Me.ExplorerBar1.Controls.Add(Me.lblNumTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.btnLeerTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.ebNumTarj)
        Me.ExplorerBar1.Controls.Add(Me.lblImporte)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(483, 287)
        Me.ExplorerBar1.TabIndex = 2
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblImporte
        '
        Me.lblImporte.BackColor = System.Drawing.Color.Transparent
        Me.lblImporte.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblImporte.Location = New System.Drawing.Point(8, 93)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(127, 23)
        Me.lblImporte.TabIndex = 88
        Me.lblImporte.Text = "Importe a Pagar :"
        Me.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLeerTarjeta
        '
        Me.btnLeerTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerTarjeta.Icon = CType(resources.GetObject("btnLeerTarjeta.Icon"), System.Drawing.Icon)
        Me.btnLeerTarjeta.Location = New System.Drawing.Point(373, 119)
        Me.btnLeerTarjeta.Name = "btnLeerTarjeta"
        Me.btnLeerTarjeta.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerTarjeta.TabIndex = 91
        Me.btnLeerTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNumTarj
        '
        Me.ebNumTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumTarj.Location = New System.Drawing.Point(141, 119)
        Me.ebNumTarj.MaxLength = 200
        Me.ebNumTarj.Name = "ebNumTarj"
        Me.ebNumTarj.Size = New System.Drawing.Size(232, 22)
        Me.ebNumTarj.TabIndex = 90
        Me.ebNumTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNumTarjeta
        '
        Me.lblNumTarjeta.BackColor = System.Drawing.Color.Transparent
        Me.lblNumTarjeta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblNumTarjeta.Location = New System.Drawing.Point(8, 117)
        Me.lblNumTarjeta.Name = "lblNumTarjeta"
        Me.lblNumTarjeta.Size = New System.Drawing.Size(127, 23)
        Me.lblNumTarjeta.TabIndex = 92
        Me.lblNumTarjeta.Text = "Tarjeta :"
        Me.lblNumTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPromocion
        '
        Me.cmbPromocion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbPromocion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbPromocion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout6.LayoutString = resources.GetString("GridEXLayout6.LayoutString")
        Me.cmbPromocion.DesignTimeLayout = GridEXLayout6
        Me.cmbPromocion.Enabled = False
        Me.cmbPromocion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cmbPromocion.Location = New System.Drawing.Point(141, 145)
        Me.cmbPromocion.Name = "cmbPromocion"
        Me.cmbPromocion.Size = New System.Drawing.Size(72, 22)
        Me.cmbPromocion.TabIndex = 93
        Me.cmbPromocion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbPromocion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPromocion
        '
        Me.lblPromocion.AccessibleDescription = "0"
        Me.lblPromocion.AutoSize = True
        Me.lblPromocion.BackColor = System.Drawing.Color.Transparent
        Me.lblPromocion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPromocion.Location = New System.Drawing.Point(8, 147)
        Me.lblPromocion.Name = "lblPromocion"
        Me.lblPromocion.Size = New System.Drawing.Size(84, 16)
        Me.lblPromocion.TabIndex = 94
        Me.lblPromocion.Text = "Promoción :"
        '
        'btnGenerarPago
        '
        Me.btnGenerarPago.Location = New System.Drawing.Point(242, 226)
        Me.btnGenerarPago.Name = "btnGenerarPago"
        Me.btnGenerarPago.Size = New System.Drawing.Size(113, 32)
        Me.btnGenerarPago.TabIndex = 95
        Me.btnGenerarPago.Text = "&Generar Pago"
        Me.btnGenerarPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(358, 226)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(113, 32)
        Me.btnSalir.TabIndex = 96
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblTipoVenta
        '
        Me.lblTipoVenta.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoVenta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblTipoVenta.Location = New System.Drawing.Point(8, 35)
        Me.lblTipoVenta.Name = "lblTipoVenta"
        Me.lblTipoVenta.Size = New System.Drawing.Size(127, 23)
        Me.lblTipoVenta.TabIndex = 97
        Me.lblTipoVenta.Text = "Tipo Venta :"
        Me.lblTipoVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoVenta
        '
        Me.cmbTipoVenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbTipoVenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbTipoVenta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout5.LayoutString = resources.GetString("GridEXLayout5.LayoutString")
        Me.cmbTipoVenta.DesignTimeLayout = GridEXLayout5
        Me.cmbTipoVenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cmbTipoVenta.Location = New System.Drawing.Point(141, 35)
        Me.cmbTipoVenta.Name = "cmbTipoVenta"
        Me.cmbTipoVenta.Size = New System.Drawing.Size(128, 22)
        Me.cmbTipoVenta.TabIndex = 98
        Me.cmbTipoVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbTipoVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebImporte
        '
        Me.ebImporte.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebImporte.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebImporte.ControlStyle.ControlColor = System.Drawing.SystemColors.Window
        Me.ebImporte.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebImporte.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebImporte.Location = New System.Drawing.Point(141, 95)
        Me.ebImporte.MaxLength = 10
        Me.ebImporte.Name = "ebImporte"
        Me.ebImporte.Size = New System.Drawing.Size(112, 22)
        Me.ebImporte.TabIndex = 99
        Me.ebImporte.Text = "0"
        Me.ebImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebImporte.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.ebImporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTipoPago
        '
        Me.lblTipoPago.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoPago.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblTipoPago.Location = New System.Drawing.Point(9, 65)
        Me.lblTipoPago.Name = "lblTipoPago"
        Me.lblTipoPago.Size = New System.Drawing.Size(127, 23)
        Me.lblTipoPago.TabIndex = 100
        Me.lblTipoPago.Text = "Tipo Pago :"
        Me.lblTipoPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoPago
        '
        Me.cmbTipoPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbTipoPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbTipoPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.cmbTipoPago.DesignTimeLayout = GridEXLayout4
        Me.cmbTipoPago.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cmbTipoPago.Location = New System.Drawing.Point(141, 65)
        Me.cmbTipoPago.Name = "cmbTipoPago"
        Me.cmbTipoPago.Size = New System.Drawing.Size(128, 22)
        Me.cmbTipoPago.TabIndex = 101
        Me.cmbTipoPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbTipoPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPlayerDescripcion
        '
        Me.ebPlayerDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerDescripcion.BackColor = System.Drawing.SystemColors.Info
        Me.ebPlayerDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebPlayerDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayerDescripcion.Location = New System.Drawing.Point(274, 5)
        Me.ebPlayerDescripcion.Name = "ebPlayerDescripcion"
        Me.ebPlayerDescripcion.ReadOnly = True
        Me.ebPlayerDescripcion.Size = New System.Drawing.Size(197, 21)
        Me.ebPlayerDescripcion.TabIndex = 104
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
        Me.ebCodVendedor.Location = New System.Drawing.Point(141, 5)
        Me.ebCodVendedor.MaxLength = 8
        Me.ebCodVendedor.Name = "ebCodVendedor"
        Me.ebCodVendedor.Size = New System.Drawing.Size(127, 22)
        Me.ebCodVendedor.TabIndex = 102
        Me.ebCodVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(9, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 23)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "Player"
        '
        'lblNumAutorizacion
        '
        Me.lblNumAutorizacion.BackColor = System.Drawing.Color.Transparent
        Me.lblNumAutorizacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumAutorizacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNumAutorizacion.Location = New System.Drawing.Point(9, 174)
        Me.lblNumAutorizacion.Name = "lblNumAutorizacion"
        Me.lblNumAutorizacion.Size = New System.Drawing.Size(126, 23)
        Me.lblNumAutorizacion.TabIndex = 105
        Me.lblNumAutorizacion.Text = "No. Autorizacion"
        '
        'ebNumAutorizacion
        '
        Me.ebNumAutorizacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumAutorizacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumAutorizacion.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumAutorizacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNumAutorizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumAutorizacion.Location = New System.Drawing.Point(141, 173)
        Me.ebNumAutorizacion.Name = "ebNumAutorizacion"
        Me.ebNumAutorizacion.ReadOnly = True
        Me.ebNumAutorizacion.Size = New System.Drawing.Size(197, 21)
        Me.ebNumAutorizacion.TabIndex = 106
        Me.ebNumAutorizacion.TabStop = False
        Me.ebNumAutorizacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumAutorizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(124, 226)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(113, 32)
        Me.btnNuevo.TabIndex = 107
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmPagoDpCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 287)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmPagoDpCard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagos DPCard"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblImporte As System.Windows.Forms.Label
    Friend WithEvents btnLeerTarjeta As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebNumTarj As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents lblNumTarjeta As System.Windows.Forms.Label
    Friend WithEvents cmbPromocion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblPromocion As System.Windows.Forms.Label
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnGenerarPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbTipoVenta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblTipoVenta As System.Windows.Forms.Label
    Friend WithEvents ebImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTipoPago As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebPlayerDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblNumAutorizacion As System.Windows.Forms.Label
    Friend WithEvents ebNumAutorizacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnNuevo As Janus.Windows.EditControls.UIButton
End Class
