Public Class frmConsultaAlterna
    Inherits System.Windows.Forms.UserControl

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents EditBox11 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox12 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox13 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox14 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox15 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents EditBox6 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox7 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox8 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox9 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox10 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents EditBox5 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox4 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaAlterna))
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.EditBox11 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox12 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox13 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox14 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox15 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.EditBox6 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox7 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox8 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox9 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox10 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.EditBox5 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox4 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox3 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.EditBox11)
        Me.UiGroupBox1.Controls.Add(Me.EditBox12)
        Me.UiGroupBox1.Controls.Add(Me.EditBox13)
        Me.UiGroupBox1.Controls.Add(Me.EditBox14)
        Me.UiGroupBox1.Controls.Add(Me.EditBox15)
        Me.UiGroupBox1.Controls.Add(Me.PictureBox3)
        Me.UiGroupBox1.Controls.Add(Me.EditBox6)
        Me.UiGroupBox1.Controls.Add(Me.EditBox7)
        Me.UiGroupBox1.Controls.Add(Me.EditBox8)
        Me.UiGroupBox1.Controls.Add(Me.EditBox9)
        Me.UiGroupBox1.Controls.Add(Me.EditBox10)
        Me.UiGroupBox1.Controls.Add(Me.PictureBox2)
        Me.UiGroupBox1.Controls.Add(Me.EditBox5)
        Me.UiGroupBox1.Controls.Add(Me.EditBox4)
        Me.UiGroupBox1.Controls.Add(Me.EditBox3)
        Me.UiGroupBox1.Controls.Add(Me.EditBox2)
        Me.UiGroupBox1.Controls.Add(Me.EditBox1)
        Me.UiGroupBox1.Controls.Add(Me.PictureBox1)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(784, 136)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'EditBox11
        '
        Me.EditBox11.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox11.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox11.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D
        Me.EditBox11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox11.Location = New System.Drawing.Point(640, 104)
        Me.EditBox11.Name = "EditBox11"
        Me.EditBox11.Size = New System.Drawing.Size(112, 21)
        Me.EditBox11.TabIndex = 35
        Me.EditBox11.Text = "Regreso a Clases"
        Me.EditBox11.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox11.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox12
        '
        Me.EditBox12.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox12.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox12.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D
        Me.EditBox12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox12.Location = New System.Drawing.Point(640, 80)
        Me.EditBox12.Name = "EditBox12"
        Me.EditBox12.Size = New System.Drawing.Size(80, 21)
        Me.EditBox12.TabIndex = 34
        Me.EditBox12.Text = "250.00"
        Me.EditBox12.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox12.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox13
        '
        Me.EditBox13.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox13.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox13.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D
        Me.EditBox13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox13.Location = New System.Drawing.Point(640, 56)
        Me.EditBox13.Name = "EditBox13"
        Me.EditBox13.Size = New System.Drawing.Size(112, 21)
        Me.EditBox13.TabIndex = 33
        Me.EditBox13.Text = "Blanco"
        Me.EditBox13.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox13.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox14
        '
        Me.EditBox14.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox14.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox14.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D
        Me.EditBox14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox14.Location = New System.Drawing.Point(640, 32)
        Me.EditBox14.Name = "EditBox14"
        Me.EditBox14.Size = New System.Drawing.Size(112, 21)
        Me.EditBox14.TabIndex = 32
        Me.EditBox14.Text = "Acido Blanco"
        Me.EditBox14.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox14.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox15
        '
        Me.EditBox15.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox15.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox15.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D
        Me.EditBox15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox15.Location = New System.Drawing.Point(640, 8)
        Me.EditBox15.Name = "EditBox15"
        Me.EditBox15.Size = New System.Drawing.Size(112, 21)
        Me.EditBox15.TabIndex = 31
        Me.EditBox15.Text = "AC-1001BCO-16"
        Me.EditBox15.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox15.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(512, 8)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(120, 112)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 30
        Me.PictureBox3.TabStop = False
        '
        'EditBox6
        '
        Me.EditBox6.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox6.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox6.Location = New System.Drawing.Point(392, 104)
        Me.EditBox6.Name = "EditBox6"
        Me.EditBox6.Size = New System.Drawing.Size(112, 21)
        Me.EditBox6.TabIndex = 29
        Me.EditBox6.Text = "Regreso a Clases"
        Me.EditBox6.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox6.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox7
        '
        Me.EditBox7.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox7.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox7.Location = New System.Drawing.Point(392, 80)
        Me.EditBox7.Name = "EditBox7"
        Me.EditBox7.Size = New System.Drawing.Size(80, 21)
        Me.EditBox7.TabIndex = 28
        Me.EditBox7.Text = "250.00"
        Me.EditBox7.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox7.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox8
        '
        Me.EditBox8.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox8.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox8.Location = New System.Drawing.Point(392, 56)
        Me.EditBox8.Name = "EditBox8"
        Me.EditBox8.Size = New System.Drawing.Size(112, 21)
        Me.EditBox8.TabIndex = 27
        Me.EditBox8.Text = "Blanco"
        Me.EditBox8.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox8.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox9
        '
        Me.EditBox9.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox9.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox9.Location = New System.Drawing.Point(392, 32)
        Me.EditBox9.Name = "EditBox9"
        Me.EditBox9.Size = New System.Drawing.Size(112, 21)
        Me.EditBox9.TabIndex = 26
        Me.EditBox9.Text = "Acido Blanco"
        Me.EditBox9.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox9.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox10
        '
        Me.EditBox10.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox10.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox10.Location = New System.Drawing.Point(392, 8)
        Me.EditBox10.Name = "EditBox10"
        Me.EditBox10.Size = New System.Drawing.Size(112, 21)
        Me.EditBox10.TabIndex = 25
        Me.EditBox10.Text = "AC-1001BCO-14"
        Me.EditBox10.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox10.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(264, 8)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(120, 112)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 24
        Me.PictureBox2.TabStop = False
        '
        'EditBox5
        '
        Me.EditBox5.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox5.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox5.Location = New System.Drawing.Point(144, 104)
        Me.EditBox5.Name = "EditBox5"
        Me.EditBox5.Size = New System.Drawing.Size(104, 21)
        Me.EditBox5.TabIndex = 23
        Me.EditBox5.Text = "Regreso a Clases"
        Me.EditBox5.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox4
        '
        Me.EditBox4.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox4.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox4.Location = New System.Drawing.Point(144, 80)
        Me.EditBox4.Name = "EditBox4"
        Me.EditBox4.Size = New System.Drawing.Size(72, 21)
        Me.EditBox4.TabIndex = 22
        Me.EditBox4.Text = "250.00"
        Me.EditBox4.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox3
        '
        Me.EditBox3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox3.Location = New System.Drawing.Point(144, 56)
        Me.EditBox3.Name = "EditBox3"
        Me.EditBox3.Size = New System.Drawing.Size(104, 21)
        Me.EditBox3.TabIndex = 21
        Me.EditBox3.Text = "Blanco"
        Me.EditBox3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox2.Location = New System.Drawing.Point(144, 32)
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.Size = New System.Drawing.Size(104, 21)
        Me.EditBox2.TabIndex = 20
        Me.EditBox2.Text = "Acido Blanco"
        Me.EditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox1.Location = New System.Drawing.Point(144, 8)
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.Size = New System.Drawing.Size(104, 21)
        Me.EditBox1.TabIndex = 19
        Me.EditBox1.Text = "AC-1000BCO-16"
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(120, 112)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'frmConsultaAlterna
        '
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Name = "frmConsultaAlterna"
        Me.Size = New System.Drawing.Size(784, 136)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub EditBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub EditBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub EditBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub EditBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub EditBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub frmConsultaAlterna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        MessageBox.Show("Muestra articulo en el dash principal de consultas")
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        MessageBox.Show("Muestra articulo en el dash principal de consultas")
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        MessageBox.Show("Muestra articulo en el dash principal de consultas")
    End Sub
End Class
