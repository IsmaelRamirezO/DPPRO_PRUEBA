Public Class FrmMarcarArchDefectuosos
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox4 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox5 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox6 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox7 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox8 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox9 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox10 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox11 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents CalendarCombo1 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox12 As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMarcarArchDefectuosos))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox12 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.CalendarCombo1 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.UiButton2 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.EditBox11 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox10 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox9 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox8 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox7 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox6 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox5 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox4 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox3 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
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
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.EditBox12)
        Me.ExplorerBar1.Controls.Add(Me.CalendarCombo1)
        Me.ExplorerBar1.Controls.Add(Me.UiButton2)
        Me.ExplorerBar1.Controls.Add(Me.UiButton1)
        Me.ExplorerBar1.Controls.Add(Me.EditBox11)
        Me.ExplorerBar1.Controls.Add(Me.EditBox10)
        Me.ExplorerBar1.Controls.Add(Me.EditBox9)
        Me.ExplorerBar1.Controls.Add(Me.EditBox8)
        Me.ExplorerBar1.Controls.Add(Me.EditBox7)
        Me.ExplorerBar1.Controls.Add(Me.EditBox6)
        Me.ExplorerBar1.Controls.Add(Me.EditBox5)
        Me.ExplorerBar1.Controls.Add(Me.EditBox4)
        Me.ExplorerBar1.Controls.Add(Me.EditBox3)
        Me.ExplorerBar1.Controls.Add(Me.EditBox2)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Captura de Datos del Archivo Defectuoso"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(648, 312)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.BackColor = System.Drawing.Color.Ivory
        Me.EditBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox1.Location = New System.Drawing.Point(168, 232)
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.ReadOnly = True
        Me.EditBox1.Size = New System.Drawing.Size(392, 22)
        Me.EditBox1.TabIndex = 27
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox12
        '
        Me.EditBox12.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox12.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox12.BackColor = System.Drawing.Color.Ivory
        Me.EditBox12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox12.Location = New System.Drawing.Point(168, 208)
        Me.EditBox12.Name = "EditBox12"
        Me.EditBox12.ReadOnly = True
        Me.EditBox12.Size = New System.Drawing.Size(392, 22)
        Me.EditBox12.TabIndex = 26
        Me.EditBox12.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox12.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'CalendarCombo1
        '
        '
        '
        '
        Me.CalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.CalendarCombo1.Location = New System.Drawing.Point(472, 80)
        Me.CalendarCombo1.Name = "CalendarCombo1"
        Me.CalendarCombo1.Size = New System.Drawing.Size(128, 23)
        Me.CalendarCombo1.TabIndex = 25
        Me.CalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'UiButton2
        '
        Me.UiButton2.Location = New System.Drawing.Point(328, 272)
        Me.UiButton2.Name = "UiButton2"
        Me.UiButton2.Size = New System.Drawing.Size(75, 23)
        Me.UiButton2.TabIndex = 24
        Me.UiButton2.Text = "Cancelar"
        Me.UiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton1
        '
        Me.UiButton1.Location = New System.Drawing.Point(248, 272)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(75, 23)
        Me.UiButton1.TabIndex = 23
        Me.UiButton1.Text = "Aceptar"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EditBox11
        '
        Me.EditBox11.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox11.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox11.ButtonImage = CType(resources.GetObject("EditBox11.ButtonImage"), System.Drawing.Image)
        Me.EditBox11.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EditBox11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox11.Location = New System.Drawing.Point(112, 232)
        Me.EditBox11.Name = "EditBox11"
        Me.EditBox11.Size = New System.Drawing.Size(56, 22)
        Me.EditBox11.TabIndex = 22
        Me.EditBox11.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox11.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox10
        '
        Me.EditBox10.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox10.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox10.ButtonImage = CType(resources.GetObject("EditBox10.ButtonImage"), System.Drawing.Image)
        Me.EditBox10.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EditBox10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox10.Location = New System.Drawing.Point(112, 208)
        Me.EditBox10.Name = "EditBox10"
        Me.EditBox10.Size = New System.Drawing.Size(56, 22)
        Me.EditBox10.TabIndex = 21
        Me.EditBox10.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox10.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox9
        '
        Me.EditBox9.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox9.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox9.Location = New System.Drawing.Point(112, 168)
        Me.EditBox9.Name = "EditBox9"
        Me.EditBox9.Size = New System.Drawing.Size(448, 22)
        Me.EditBox9.TabIndex = 20
        Me.EditBox9.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox9.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox8
        '
        Me.EditBox8.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox8.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox8.Location = New System.Drawing.Point(112, 128)
        Me.EditBox8.Name = "EditBox8"
        Me.EditBox8.Size = New System.Drawing.Size(48, 22)
        Me.EditBox8.TabIndex = 19
        Me.EditBox8.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox8.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox7
        '
        Me.EditBox7.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox7.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox7.Location = New System.Drawing.Point(112, 104)
        Me.EditBox7.Name = "EditBox7"
        Me.EditBox7.Size = New System.Drawing.Size(75, 22)
        Me.EditBox7.TabIndex = 18
        Me.EditBox7.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox7.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox6
        '
        Me.EditBox6.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox6.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox6.Location = New System.Drawing.Point(112, 80)
        Me.EditBox6.Name = "EditBox6"
        Me.EditBox6.Size = New System.Drawing.Size(272, 22)
        Me.EditBox6.TabIndex = 17
        Me.EditBox6.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox6.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox5
        '
        Me.EditBox5.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox5.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox5.Location = New System.Drawing.Point(112, 48)
        Me.EditBox5.Name = "EditBox5"
        Me.EditBox5.Size = New System.Drawing.Size(75, 22)
        Me.EditBox5.TabIndex = 16
        Me.EditBox5.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox4
        '
        Me.EditBox4.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox4.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox4.Location = New System.Drawing.Point(304, 128)
        Me.EditBox4.Name = "EditBox4"
        Me.EditBox4.Size = New System.Drawing.Size(72, 22)
        Me.EditBox4.TabIndex = 15
        Me.EditBox4.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox3
        '
        Me.EditBox3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox3.Location = New System.Drawing.Point(304, 104)
        Me.EditBox3.Name = "EditBox3"
        Me.EditBox3.Size = New System.Drawing.Size(72, 22)
        Me.EditBox3.TabIndex = 14
        Me.EditBox3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox2.Location = New System.Drawing.Point(472, 104)
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.Size = New System.Drawing.Size(48, 22)
        Me.EditBox2.TabIndex = 13
        Me.EditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(400, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Cantidad:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(416, 88)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 23)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Fecha:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(208, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(152, 23)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Folio Factura:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(264, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Talla:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(40, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Autorizo:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(48, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Elaboro:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(48, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Defecto:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(48, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "No. Caja:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(56, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Codigo:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(48, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sucursal:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(72, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Folio:"
        '
        'FrmMarcarArchDefectuosos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(640, 306)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(656, 344)
        Me.MinimumSize = New System.Drawing.Size(656, 344)
        Me.Name = "FrmMarcarArchDefectuosos"
        Me.Text = "Marcar Archivos Defectuosos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmMarcarArchDefectuosos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
