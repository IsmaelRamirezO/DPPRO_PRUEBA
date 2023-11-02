Public Class frmSeguimientoTraspaso
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
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents CalendarCombo1 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents CalendarCombo2 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents MultiColumnCombo1 As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiButton2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton3 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton4 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton5 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton6 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton7 As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeguimientoTraspaso))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiButton7 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton6 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton5 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton4 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton3 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton2 = New Janus.Windows.EditControls.UIButton()
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.MultiColumnCombo1 = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.CalendarCombo2 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.CalendarCombo1 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.UiButton7)
        Me.ExplorerBar1.Controls.Add(Me.UiButton6)
        Me.ExplorerBar1.Controls.Add(Me.UiButton5)
        Me.ExplorerBar1.Controls.Add(Me.UiButton4)
        Me.ExplorerBar1.Controls.Add(Me.UiButton3)
        Me.ExplorerBar1.Controls.Add(Me.UiButton2)
        Me.ExplorerBar1.Controls.Add(Me.GridEX1)
        Me.ExplorerBar1.Controls.Add(Me.UiButton1)
        Me.ExplorerBar1.Controls.Add(Me.MultiColumnCombo1)
        Me.ExplorerBar1.Controls.Add(Me.CalendarCombo2)
        Me.ExplorerBar1.Controls.Add(Me.CalendarCombo1)
        Me.ExplorerBar1.Controls.Add(Me.EditBox2)
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Rangos"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(888, 496)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiButton7
        '
        Me.UiButton7.Image = CType(resources.GetObject("UiButton7.Image"), System.Drawing.Image)
        Me.UiButton7.Location = New System.Drawing.Point(752, 456)
        Me.UiButton7.Name = "UiButton7"
        Me.UiButton7.Size = New System.Drawing.Size(112, 23)
        Me.UiButton7.TabIndex = 17
        Me.UiButton7.Text = "Salir"
        Me.UiButton7.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton6
        '
        Me.UiButton6.Image = CType(resources.GetObject("UiButton6.Image"), System.Drawing.Image)
        Me.UiButton6.Location = New System.Drawing.Point(608, 456)
        Me.UiButton6.Name = "UiButton6"
        Me.UiButton6.Size = New System.Drawing.Size(112, 23)
        Me.UiButton6.TabIndex = 16
        Me.UiButton6.Text = "Imprimir"
        Me.UiButton6.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton5
        '
        Me.UiButton5.Image = CType(resources.GetObject("UiButton5.Image"), System.Drawing.Image)
        Me.UiButton5.Location = New System.Drawing.Point(464, 456)
        Me.UiButton5.Name = "UiButton5"
        Me.UiButton5.Size = New System.Drawing.Size(112, 23)
        Me.UiButton5.TabIndex = 15
        Me.UiButton5.Text = "Ver Traspaso"
        Me.UiButton5.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton4
        '
        Me.UiButton4.Image = CType(resources.GetObject("UiButton4.Image"), System.Drawing.Image)
        Me.UiButton4.Location = New System.Drawing.Point(312, 456)
        Me.UiButton4.Name = "UiButton4"
        Me.UiButton4.Size = New System.Drawing.Size(112, 23)
        Me.UiButton4.TabIndex = 14
        Me.UiButton4.Text = "Cambio Status"
        Me.UiButton4.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton3
        '
        Me.UiButton3.Image = CType(resources.GetObject("UiButton3.Image"), System.Drawing.Image)
        Me.UiButton3.Location = New System.Drawing.Point(168, 456)
        Me.UiButton3.Name = "UiButton3"
        Me.UiButton3.Size = New System.Drawing.Size(112, 23)
        Me.UiButton3.TabIndex = 13
        Me.UiButton3.Text = "Totales"
        Me.UiButton3.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton2
        '
        Me.UiButton2.Image = CType(resources.GetObject("UiButton2.Image"), System.Drawing.Image)
        Me.UiButton2.Location = New System.Drawing.Point(24, 456)
        Me.UiButton2.Name = "UiButton2"
        Me.UiButton2.Size = New System.Drawing.Size(112, 23)
        Me.UiButton2.TabIndex = 12
        Me.UiButton2.Text = "Total Actual"
        Me.UiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'GridEX1
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GridEX1.DesignTimeLayout = GridEXLayout1
        Me.GridEX1.GroupByBoxVisible = False
        Me.GridEX1.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridEX1.Location = New System.Drawing.Point(16, 80)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.Size = New System.Drawing.Size(856, 360)
        Me.GridEX1.TabIndex = 11
        Me.GridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiButton1
        '
        Me.UiButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton1.Image = CType(resources.GetObject("UiButton1.Image"), System.Drawing.Image)
        Me.UiButton1.Location = New System.Drawing.Point(784, 40)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(88, 23)
        Me.UiButton1.TabIndex = 10
        Me.UiButton1.Text = "Actualizar"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'MultiColumnCombo1
        '
        Me.MultiColumnCombo1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.MultiColumnCombo1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.MultiColumnCombo1.DesignTimeLayout = GridEXLayout2
        Me.MultiColumnCombo1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MultiColumnCombo1.Location = New System.Drawing.Point(664, 40)
        Me.MultiColumnCombo1.Name = "MultiColumnCombo1"
        Me.MultiColumnCombo1.Size = New System.Drawing.Size(112, 22)
        Me.MultiColumnCombo1.TabIndex = 9
        Me.MultiColumnCombo1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.MultiColumnCombo1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'CalendarCombo2
        '
        '
        '
        '
        Me.CalendarCombo2.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.CalendarCombo2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalendarCombo2.Location = New System.Drawing.Point(552, 40)
        Me.CalendarCombo2.Name = "CalendarCombo2"
        Me.CalendarCombo2.Size = New System.Drawing.Size(112, 22)
        Me.CalendarCombo2.TabIndex = 8
        Me.CalendarCombo2.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'CalendarCombo1
        '
        '
        '
        '
        Me.CalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.CalendarCombo1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalendarCombo1.Location = New System.Drawing.Point(360, 40)
        Me.CalendarCombo1.Name = "CalendarCombo1"
        Me.CalendarCombo1.Size = New System.Drawing.Size(112, 22)
        Me.CalendarCombo1.TabIndex = 7
        Me.CalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.ButtonImage = CType(resources.GetObject("EditBox2.ButtonImage"), System.Drawing.Image)
        Me.EditBox2.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EditBox2.Location = New System.Drawing.Point(200, 40)
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.Size = New System.Drawing.Size(75, 23)
        Me.EditBox2.TabIndex = 6
        Me.EditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.ButtonImage = CType(resources.GetObject("EditBox1.ButtonImage"), System.Drawing.Image)
        Me.EditBox1.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EditBox1.Location = New System.Drawing.Point(64, 40)
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.Size = New System.Drawing.Size(75, 23)
        Me.EditBox1.TabIndex = 5
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(480, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Fecha Final"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(280, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fecha Inicio"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(144, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Destino"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Origen"
        '
        'frmSeguimientoTraspaso
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(880, 490)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(896, 528)
        Me.MinimumSize = New System.Drawing.Size(896, 528)
        Me.Name = "frmSeguimientoTraspaso"
        Me.Text = "Seguimiento de Traspasos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemClick

    End Sub

    Private Sub frmSeguimientoTraspaso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
