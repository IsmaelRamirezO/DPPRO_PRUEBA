Public Class frmConExisA�os
    Inherits System.Windows.Forms.Form

#Region " C�digo generado por el Dise�ador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Dise�ador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicializaci�n despu�s de la llamada a InitializeComponent()

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

    'Requerido por el Dise�ador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Dise�ador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Dise�ador de Windows Forms. 
    'No lo modifique con el editor de c�digo.
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox4 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox5 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton2 As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConExisA�os))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiButton2 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.EditBox5 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox4 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox3 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.UiButton2)
        Me.ExplorerBar1.Controls.Add(Me.UiButton1)
        Me.ExplorerBar1.Controls.Add(Me.EditBox5)
        Me.ExplorerBar1.Controls.Add(Me.EditBox4)
        Me.ExplorerBar1.Controls.Add(Me.EditBox3)
        Me.ExplorerBar1.Controls.Add(Me.EditBox2)
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Consultas"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(360, 282)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiButton2
        '
        Me.UiButton2.Location = New System.Drawing.Point(200, 248)
        Me.UiButton2.Name = "UiButton2"
        Me.UiButton2.Size = New System.Drawing.Size(75, 23)
        Me.UiButton2.TabIndex = 12
        Me.UiButton2.Text = "UiButton2"
        Me.UiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton1
        '
        Me.UiButton1.Location = New System.Drawing.Point(104, 248)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(75, 23)
        Me.UiButton1.TabIndex = 11
        Me.UiButton1.Text = "UiButton1"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EditBox5
        '
        Me.EditBox5.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox5.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox5.Location = New System.Drawing.Point(120, 200)
        Me.EditBox5.Name = "EditBox5"
        Me.EditBox5.Size = New System.Drawing.Size(200, 22)
        Me.EditBox5.TabIndex = 10
        Me.EditBox5.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox4
        '
        Me.EditBox4.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox4.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox4.Location = New System.Drawing.Point(120, 176)
        Me.EditBox4.Name = "EditBox4"
        Me.EditBox4.Size = New System.Drawing.Size(200, 22)
        Me.EditBox4.TabIndex = 9
        Me.EditBox4.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox3
        '
        Me.EditBox3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox3.Location = New System.Drawing.Point(120, 120)
        Me.EditBox3.Name = "EditBox3"
        Me.EditBox3.Size = New System.Drawing.Size(200, 22)
        Me.EditBox3.TabIndex = 8
        Me.EditBox3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox2.Location = New System.Drawing.Point(120, 96)
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.Size = New System.Drawing.Size(200, 22)
        Me.EditBox2.TabIndex = 7
        Me.EditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox1.Location = New System.Drawing.Point(120, 56)
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.Size = New System.Drawing.Size(200, 22)
        Me.EditBox1.TabIndex = 6
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(32, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Saldo Final:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(32, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Saldo Inicial:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(32, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sucursal:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(32, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 32)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Corrida de Descripcion:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(32, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo:"
        '
        'frmConExisA�os
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(360, 282)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(376, 320)
        Me.MinimumSize = New System.Drawing.Size(376, 320)
        Me.Name = "frmConExisA�os"
        Me.Text = "Consulta General de Movimientos por Articulo de Dos A�os  "
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

   
    Private Sub frmConExisA�os_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
