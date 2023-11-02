<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodigosPostalesS2Credit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCodigosPostalesS2Credit))
        Me.gSepomex = New Janus.Windows.GridEX.GridEX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebEstado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCiudad = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.gSepomex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gSepomex
        '
        Me.gSepomex.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gSepomex.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gSepomex.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        Me.gSepomex.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gSepomex.DesignTimeLayout = GridEXLayout1
        Me.gSepomex.ErrorImageIndex = -1
        Me.gSepomex.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.gSepomex.GroupByBoxVisible = False
        Me.gSepomex.Location = New System.Drawing.Point(12, 68)
        Me.gSepomex.Name = "gSepomex"
        Me.gSepomex.Size = New System.Drawing.Size(238, 105)
        Me.gSepomex.TabIndex = 187
        Me.gSepomex.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 194
        Me.PictureBox1.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Icon = CType(resources.GetObject("btnAceptar.Icon"), System.Drawing.Icon)
        Me.btnAceptar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnAceptar.Location = New System.Drawing.Point(70, 243)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(122, 34)
        Me.btnAceptar.TabIndex = 190
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 14)
        Me.Label3.TabIndex = 193
        Me.Label3.Text = "Estado:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 14)
        Me.Label2.TabIndex = 192
        Me.Label2.Text = "Ciudad:"
        '
        'ebEstado
        '
        Me.ebEstado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEstado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEstado.BackColor = System.Drawing.SystemColors.Info
        Me.ebEstado.Location = New System.Drawing.Point(71, 205)
        Me.ebEstado.Name = "ebEstado"
        Me.ebEstado.ReadOnly = True
        Me.ebEstado.Size = New System.Drawing.Size(179, 20)
        Me.ebEstado.TabIndex = 189
        Me.ebEstado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCiudad
        '
        Me.ebCiudad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCiudad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCiudad.BackColor = System.Drawing.SystemColors.Info
        Me.ebCiudad.Location = New System.Drawing.Point(71, 179)
        Me.ebCiudad.Name = "ebCiudad"
        Me.ebCiudad.ReadOnly = True
        Me.ebCiudad.Size = New System.Drawing.Size(179, 20)
        Me.ebCiudad.TabIndex = 188
        Me.ebCiudad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCiudad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCP
        '
        Me.ebCP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCP.ButtonImage = CType(resources.GetObject("ebCP.ButtonImage"), System.Drawing.Image)
        Me.ebCP.Location = New System.Drawing.Point(113, 30)
        Me.ebCP.MaxLength = 5
        Me.ebCP.Name = "ebCP"
        Me.ebCP.Size = New System.Drawing.Size(137, 20)
        Me.ebCP.TabIndex = 186
        Me.ebCP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(68, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 14)
        Me.Label1.TabIndex = 191
        Me.Label1.Text = "C.P. :"
        '
        'frmCodigosPostalesS2Credit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(262, 289)
        Me.Controls.Add(Me.gSepomex)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ebEstado)
        Me.Controls.Add(Me.ebCiudad)
        Me.Controls.Add(Me.ebCP)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCodigosPostalesS2Credit"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Codigos Postales"
        CType(Me.gSepomex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gSepomex As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebEstado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCiudad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
