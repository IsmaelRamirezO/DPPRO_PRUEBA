<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBeneficiarioS2Credit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBeneficiarioS2Credit))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ebApellidoPaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebApellidoMaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombres = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbParentesco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ebApellidoPaterno
        '
        Me.ebApellidoPaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebApellidoPaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebApellidoPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebApellidoPaterno.Location = New System.Drawing.Point(141, 117)
        Me.ebApellidoPaterno.Name = "ebApellidoPaterno"
        Me.ebApellidoPaterno.Size = New System.Drawing.Size(234, 20)
        Me.ebApellidoPaterno.TabIndex = 1
        Me.ebApellidoPaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebApellidoPaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebApellidoMaterno
        '
        Me.ebApellidoMaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebApellidoMaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebApellidoMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebApellidoMaterno.Location = New System.Drawing.Point(141, 143)
        Me.ebApellidoMaterno.Name = "ebApellidoMaterno"
        Me.ebApellidoMaterno.Size = New System.Drawing.Size(234, 20)
        Me.ebApellidoMaterno.TabIndex = 2
        Me.ebApellidoMaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebApellidoMaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombres
        '
        Me.ebNombres.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombres.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNombres.Location = New System.Drawing.Point(141, 91)
        Me.ebNombres.Name = "ebNombres"
        Me.ebNombres.Size = New System.Drawing.Size(234, 20)
        Me.ebNombres.TabIndex = 0
        Me.ebNombres.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombres.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nombre(s):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(12, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 14)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Apellido Paterno:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(12, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Apellido Materno:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(12, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Parentesco:"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Icon = CType(resources.GetObject("btnGuardar.Icon"), System.Drawing.Icon)
        Me.btnGuardar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnGuardar.Location = New System.Drawing.Point(12, 195)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(363, 47)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar Beneficiario"
        Me.btnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(70, 70)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 195
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(88, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(287, 70)
        Me.Label5.TabIndex = 196
        Me.Label5.Text = "Favor de capturar los datos del Beneficiario:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbParentesco
        '
        Me.cmbParentesco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbParentesco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbParentesco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbParentesco.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbParentesco.DesignTimeLayout = GridEXLayout1
        Me.cmbParentesco.Location = New System.Drawing.Point(141, 169)
        Me.cmbParentesco.Name = "cmbParentesco"
        Me.cmbParentesco.Size = New System.Drawing.Size(104, 20)
        Me.cmbParentesco.TabIndex = 3
        Me.cmbParentesco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbParentesco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(251, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 14)
        Me.Label6.TabIndex = 200
        Me.Label6.Text = "Porcentaje:"
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.EditBox1.Location = New System.Drawing.Point(334, 169)
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.ReadOnly = True
        Me.EditBox1.Size = New System.Drawing.Size(41, 20)
        Me.EditBox1.TabIndex = 199
        Me.EditBox1.Text = "100%"
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmBeneficiarioS2Credit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(387, 254)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.EditBox1)
        Me.Controls.Add(Me.cmbParentesco)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ebApellidoMaterno)
        Me.Controls.Add(Me.ebApellidoPaterno)
        Me.Controls.Add(Me.ebNombres)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBeneficiarioS2Credit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Beneficiario"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ebApellidoPaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebApellidoMaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombres As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cmbParentesco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
End Class
