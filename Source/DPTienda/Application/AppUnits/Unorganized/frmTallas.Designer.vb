<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTallas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTallas))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.cmbTallas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblTalla = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.txtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(100, 64)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 24)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.Location = New System.Drawing.Point(19, 64)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 24)
        Me.btnAceptar.TabIndex = 17
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cmbTallas
        '
        Me.cmbTallas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbTallas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbTallas.BackColor = System.Drawing.SystemColors.Info
        Me.cmbTallas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbTallas.DesignTimeLayout = GridEXLayout1
        Me.cmbTallas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTallas.Location = New System.Drawing.Point(86, 6)
        Me.cmbTallas.Name = "cmbTallas"
        Me.cmbTallas.Size = New System.Drawing.Size(89, 22)
        Me.cmbTallas.TabIndex = 67
        Me.cmbTallas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbTallas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTalla
        '
        Me.lblTalla.AutoSize = True
        Me.lblTalla.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTalla.Location = New System.Drawing.Point(12, 9)
        Me.lblTalla.Name = "lblTalla"
        Me.lblTalla.Size = New System.Drawing.Size(42, 16)
        Me.lblTalla.TabIndex = 68
        Me.lblTalla.Text = "Talla:"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.Location = New System.Drawing.Point(12, 39)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(70, 16)
        Me.lblCantidad.TabIndex = 69
        Me.lblCantidad.Text = "Cantidad:"
        '
        'txtCantidad
        '
        Me.txtCantidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCantidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCantidad.BackColor = System.Drawing.SystemColors.Info
        Me.txtCantidad.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtCantidad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCantidad.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtCantidad.Location = New System.Drawing.Point(86, 36)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(89, 22)
        Me.txtCantidad.TabIndex = 70
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmTallas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(184, 97)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.lblTalla)
        Me.Controls.Add(Me.cmbTallas)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTallas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecciona Talla"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTalla As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Private WithEvents cmbTallas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Private WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Private WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Private WithEvents txtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
