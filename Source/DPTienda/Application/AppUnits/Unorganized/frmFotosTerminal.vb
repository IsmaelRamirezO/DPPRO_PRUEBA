Public Class frmFotosTerminal
    Inherits System.Windows.Forms.Form
    Public intResultForm As Integer
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnFormaPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbBancomer As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbSantander As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbBanamex As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblBancomer As System.Windows.Forms.Label
    Friend WithEvents lblSantander As System.Windows.Forms.Label
    Friend WithEvents lblBanamex As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFotosTerminal))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.rbBanamex = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbSantander = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbBancomer = New Janus.Windows.EditControls.UIRadioButton()
        Me.btnFormaPago = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBancomer = New System.Windows.Forms.Label()
        Me.lblSantander = New System.Windows.Forms.Label()
        Me.lblBanamex = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.PictureBox3)
        Me.ExplorerBar1.Controls.Add(Me.PictureBox2)
        Me.ExplorerBar1.Controls.Add(Me.PictureBox1)
        Me.ExplorerBar1.Controls.Add(Me.rbBanamex)
        Me.ExplorerBar1.Controls.Add(Me.rbSantander)
        Me.ExplorerBar1.Controls.Add(Me.rbBancomer)
        Me.ExplorerBar1.Controls.Add(Me.btnFormaPago)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.lblBancomer)
        Me.ExplorerBar1.Controls.Add(Me.lblSantander)
        Me.ExplorerBar1.Controls.Add(Me.lblBanamex)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.ContainerHeight = 100
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(560, 333)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(400, 64)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(96, 176)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 154
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(228, 64)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(96, 176)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 153
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(56, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(96, 176)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 152
        Me.PictureBox1.TabStop = False
        '
        'rbBanamex
        '
        Me.rbBanamex.BackColor = System.Drawing.Color.Transparent
        Me.rbBanamex.ForeColor = System.Drawing.Color.Black
        Me.rbBanamex.Location = New System.Drawing.Point(408, 248)
        Me.rbBanamex.Name = "rbBanamex"
        Me.rbBanamex.Size = New System.Drawing.Size(88, 23)
        Me.rbBanamex.TabIndex = 151
        Me.rbBanamex.Tag = ""
        Me.rbBanamex.Text = "BANAMEX"
        Me.rbBanamex.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbSantander
        '
        Me.rbSantander.BackColor = System.Drawing.Color.Transparent
        Me.rbSantander.Location = New System.Drawing.Point(232, 248)
        Me.rbSantander.Name = "rbSantander"
        Me.rbSantander.Size = New System.Drawing.Size(96, 24)
        Me.rbSantander.TabIndex = 150
        Me.rbSantander.Text = "SANTANDER SERFIN"
        Me.rbSantander.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbBancomer
        '
        Me.rbBancomer.BackColor = System.Drawing.Color.Transparent
        Me.rbBancomer.Location = New System.Drawing.Point(64, 248)
        Me.rbBancomer.Name = "rbBancomer"
        Me.rbBancomer.Size = New System.Drawing.Size(88, 23)
        Me.rbBancomer.TabIndex = 149
        Me.rbBancomer.Text = "BANCOMER"
        Me.rbBancomer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnFormaPago
        '
        Me.btnFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFormaPago.Location = New System.Drawing.Point(212, 280)
        Me.btnFormaPago.Name = "btnFormaPago"
        Me.btnFormaPago.Size = New System.Drawing.Size(128, 32)
        Me.btnFormaPago.TabIndex = 12
        Me.btnFormaPago.Text = "&Aceptar"
        Me.btnFormaPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(28, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(504, 23)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "SELECCIONE LA TERMINAL EN LA QUE DESLIZO  LA TARJETA."
        '
        'lblBancomer
        '
        Me.lblBancomer.Location = New System.Drawing.Point(52, 60)
        Me.lblBancomer.Name = "lblBancomer"
        Me.lblBancomer.Size = New System.Drawing.Size(104, 183)
        Me.lblBancomer.TabIndex = 155
        '
        'lblSantander
        '
        Me.lblSantander.Location = New System.Drawing.Point(224, 60)
        Me.lblSantander.Name = "lblSantander"
        Me.lblSantander.Size = New System.Drawing.Size(104, 183)
        Me.lblSantander.TabIndex = 156
        '
        'lblBanamex
        '
        Me.lblBanamex.BackColor = System.Drawing.Color.White
        Me.lblBanamex.Location = New System.Drawing.Point(396, 60)
        Me.lblBanamex.Name = "lblBanamex"
        Me.lblBanamex.Size = New System.Drawing.Size(104, 183)
        Me.lblBanamex.TabIndex = 157
        '
        'frmFotosTerminal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(560, 333)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFotosTerminal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione la Terminal"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnFormaPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormaPago.Click
        If rbBancomer.Checked = False And rbSantander.Checked = False And rbBanamex.Checked = False Then
            MsgBox("¡Debe seleccionar una opcion!", MsgBoxStyle.Information, "DPTIENDA")
            Exit Sub
        End If
        If rbBancomer.Checked = True Then
            intResultForm = 1
        ElseIf rbSantander.Checked = True Then
            intResultForm = 2
        Else
            intResultForm = 3
        End If

        Me.DialogResult = DialogResult.OK

    End Sub

    Private Sub frmFotosTerminal_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If rbBancomer.Checked = False And rbSantander.Checked = False And rbBanamex.Checked = False Then
            MsgBox("¡Debe seleccionar una opcion!", MsgBoxStyle.Information, "DPTIENDA")
            e.Cancel = True
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        rbBancomer.Checked = True
        Me.lblBancomer.BackColor = System.Drawing.Color.Red
        Me.lblSantander.BackColor = System.Drawing.Color.White
        Me.lblBanamex.BackColor = System.Drawing.Color.White
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        rbSantander.Checked = True
        Me.lblBancomer.BackColor = System.Drawing.Color.White
        Me.lblSantander.BackColor = System.Drawing.Color.Red
        Me.lblBanamex.BackColor = System.Drawing.Color.White
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        rbBanamex.Checked = True
        Me.lblBancomer.BackColor = System.Drawing.Color.White
        Me.lblSantander.BackColor = System.Drawing.Color.White
        Me.lblBanamex.BackColor = System.Drawing.Color.Red
    End Sub

    Private Sub rbBancomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBancomer.CheckedChanged
        Me.lblBancomer.BackColor = System.Drawing.Color.Red
        Me.lblSantander.BackColor = System.Drawing.Color.White
        Me.lblBanamex.BackColor = System.Drawing.Color.White
    End Sub

    Private Sub rbSantander_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSantander.CheckedChanged
        Me.lblBancomer.BackColor = System.Drawing.Color.White
        Me.lblSantander.BackColor = System.Drawing.Color.Red
        Me.lblBanamex.BackColor = System.Drawing.Color.White
    End Sub

    Private Sub rbBanamex_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBanamex.CheckedChanged
        Me.lblBancomer.BackColor = System.Drawing.Color.White
        Me.lblSantander.BackColor = System.Drawing.Color.White
        Me.lblBanamex.BackColor = System.Drawing.Color.Red
    End Sub
End Class
