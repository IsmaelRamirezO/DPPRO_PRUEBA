Public Class frmRetiros
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents EditBox3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents EditBox4 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox5 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EditBox6 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents EditBox7 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents EditBox8 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents EditBox9 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents EditBox10 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents EditBox11 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents EditBox12 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents EditBox13 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents EditBox14 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents EditBox15 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents EditBox16 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents EditBox17 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents EditBox19 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents EditBox20 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents EditBox21 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents EditBox18 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox22 As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRetiros))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.EditBox22 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EditBox4 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox5 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.EditBox3 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.EditBox18 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.EditBox21 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.EditBox20 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.EditBox19 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.EditBox17 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.EditBox16 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.EditBox15 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.EditBox14 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.EditBox13 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.EditBox12 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.EditBox11 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.EditBox10 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.EditBox9 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.EditBox8 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.EditBox7 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.EditBox6 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.EditBox22)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.EditBox4)
        Me.ExplorerBar1.Controls.Add(Me.EditBox5)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.EditBox2)
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 80)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(712, 376)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "0"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'EditBox22
        '
        Me.EditBox22.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox22.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox22.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox22.Location = New System.Drawing.Point(144, 72)
        Me.EditBox22.Name = "EditBox22"
        Me.EditBox22.Size = New System.Drawing.Size(136, 23)
        Me.EditBox22.TabIndex = 12
        Me.EditBox22.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox22.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(40, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Fecha:"
        '
        'EditBox4
        '
        Me.EditBox4.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox4.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox4.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox4.Location = New System.Drawing.Point(488, 72)
        Me.EditBox4.Name = "EditBox4"
        Me.EditBox4.Size = New System.Drawing.Size(184, 23)
        Me.EditBox4.TabIndex = 10
        Me.EditBox4.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox5
        '
        Me.EditBox5.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox5.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox5.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox5.Location = New System.Drawing.Point(488, 48)
        Me.EditBox5.Name = "EditBox5"
        Me.EditBox5.Size = New System.Drawing.Size(64, 23)
        Me.EditBox5.TabIndex = 9
        Me.EditBox5.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(344, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Referencia Efectivo:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(344, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 23)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Codigo de Banco:"
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox2.Location = New System.Drawing.Point(144, 104)
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.Size = New System.Drawing.Size(416, 23)
        Me.EditBox2.TabIndex = 6
        Me.EditBox2.Text = "690-181204-192"
        Me.EditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox1.Location = New System.Drawing.Point(144, 48)
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.Size = New System.Drawing.Size(184, 23)
        Me.EditBox1.TabIndex = 5
        Me.EditBox1.Text = "22332"
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(40, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Numero Ficha:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(40, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Folio:"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.EditBox3)
        Me.ExplorerBar2.Controls.Add(Me.Label4)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Retiros Realizados"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(712, 424)
        Me.ExplorerBar2.TabIndex = 1
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'EditBox3
        '
        Me.EditBox3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox3.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox3.ForeColor = System.Drawing.Color.Red
        Me.EditBox3.Location = New System.Drawing.Point(504, 40)
        Me.EditBox3.Name = "EditBox3"
        Me.EditBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EditBox3.Size = New System.Drawing.Size(168, 23)
        Me.EditBox3.TabIndex = 3
        Me.EditBox3.Text = "12,000"
        Me.EditBox3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(368, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 23)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Total de Depositos:"
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.EditBox18)
        Me.ExplorerBar3.Controls.Add(Me.UiButton1)
        Me.ExplorerBar3.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar3.Controls.Add(Me.EditBox21)
        Me.ExplorerBar3.Controls.Add(Me.Label22)
        Me.ExplorerBar3.Controls.Add(Me.EditBox20)
        Me.ExplorerBar3.Controls.Add(Me.Label21)
        Me.ExplorerBar3.Controls.Add(Me.EditBox19)
        Me.ExplorerBar3.Controls.Add(Me.Label20)
        Me.ExplorerBar3.Controls.Add(Me.EditBox17)
        Me.ExplorerBar3.Controls.Add(Me.Label18)
        Me.ExplorerBar3.Controls.Add(Me.EditBox16)
        Me.ExplorerBar3.Controls.Add(Me.Label17)
        Me.ExplorerBar3.Controls.Add(Me.EditBox15)
        Me.ExplorerBar3.Controls.Add(Me.Label16)
        Me.ExplorerBar3.Controls.Add(Me.EditBox14)
        Me.ExplorerBar3.Controls.Add(Me.Label15)
        Me.ExplorerBar3.Controls.Add(Me.EditBox13)
        Me.ExplorerBar3.Controls.Add(Me.Label14)
        Me.ExplorerBar3.Controls.Add(Me.EditBox12)
        Me.ExplorerBar3.Controls.Add(Me.Label13)
        Me.ExplorerBar3.Controls.Add(Me.EditBox11)
        Me.ExplorerBar3.Controls.Add(Me.Label12)
        Me.ExplorerBar3.Controls.Add(Me.EditBox10)
        Me.ExplorerBar3.Controls.Add(Me.Label11)
        Me.ExplorerBar3.Controls.Add(Me.EditBox9)
        Me.ExplorerBar3.Controls.Add(Me.Label10)
        Me.ExplorerBar3.Controls.Add(Me.EditBox8)
        Me.ExplorerBar3.Controls.Add(Me.Label9)
        Me.ExplorerBar3.Controls.Add(Me.EditBox7)
        Me.ExplorerBar3.Controls.Add(Me.Label8)
        Me.ExplorerBar3.Controls.Add(Me.EditBox6)
        Me.ExplorerBar3.Controls.Add(Me.Label7)
        Me.ExplorerBar3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Detalle del Retiro"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar3.Location = New System.Drawing.Point(0, 224)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(712, 296)
        Me.ExplorerBar3.TabIndex = 2
        Me.ExplorerBar3.Text = "ExplorerBar3"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'EditBox18
        '
        Me.EditBox18.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox18.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox18.ButtonImage = CType(resources.GetObject("EditBox18.ButtonImage"), System.Drawing.Image)
        Me.EditBox18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox18.Location = New System.Drawing.Point(208, 232)
        Me.EditBox18.Name = "EditBox18"
        Me.EditBox18.Size = New System.Drawing.Size(176, 22)
        Me.EditBox18.TabIndex = 40
        Me.EditBox18.Text = "Javier Reyes"
        Me.EditBox18.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox18.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiButton1
        '
        Me.UiButton1.Location = New System.Drawing.Point(392, 256)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(248, 23)
        Me.UiButton1.TabIndex = 39
        Me.UiButton1.Text = "Grabar"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.ForeColor = System.Drawing.SystemColors.InactiveBorder
        Me.UiGroupBox1.Location = New System.Drawing.Point(32, 208)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(616, 8)
        Me.UiGroupBox1.TabIndex = 38
        '
        'EditBox21
        '
        Me.EditBox21.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox21.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox21.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox21.Location = New System.Drawing.Point(520, 232)
        Me.EditBox21.Name = "EditBox21"
        Me.EditBox21.Size = New System.Drawing.Size(120, 22)
        Me.EditBox21.TabIndex = 37
        Me.EditBox21.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox21.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(400, 232)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(128, 23)
        Me.Label22.TabIndex = 36
        Me.Label22.Text = "Monto del Retiro:"
        '
        'EditBox20
        '
        Me.EditBox20.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox20.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox20.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox20.Location = New System.Drawing.Point(144, 256)
        Me.EditBox20.Name = "EditBox20"
        Me.EditBox20.Size = New System.Drawing.Size(240, 23)
        Me.EditBox20.TabIndex = 35
        Me.EditBox20.Text = "Supervisor X"
        Me.EditBox20.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox20.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(40, 256)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 23)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = "Revisò:"
        '
        'EditBox19
        '
        Me.EditBox19.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox19.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox19.ButtonImage = CType(resources.GetObject("EditBox19.ButtonImage"), System.Drawing.Image)
        Me.EditBox19.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EditBox19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox19.Location = New System.Drawing.Point(144, 232)
        Me.EditBox19.Name = "EditBox19"
        Me.EditBox19.Size = New System.Drawing.Size(64, 22)
        Me.EditBox19.TabIndex = 33
        Me.EditBox19.Text = "001"
        Me.EditBox19.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox19.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(40, 232)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(112, 23)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "Responsable:"
        '
        'EditBox17
        '
        Me.EditBox17.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox17.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox17.Location = New System.Drawing.Point(504, 104)
        Me.EditBox17.Name = "EditBox17"
        Me.EditBox17.Size = New System.Drawing.Size(80, 23)
        Me.EditBox17.TabIndex = 29
        Me.EditBox17.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox17.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(440, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 23)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "$0.10"
        '
        'EditBox16
        '
        Me.EditBox16.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox16.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox16.Location = New System.Drawing.Point(504, 72)
        Me.EditBox16.Name = "EditBox16"
        Me.EditBox16.Size = New System.Drawing.Size(80, 23)
        Me.EditBox16.TabIndex = 27
        Me.EditBox16.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox16.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(440, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 23)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "$0.20"
        '
        'EditBox15
        '
        Me.EditBox15.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox15.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox15.Location = New System.Drawing.Point(504, 40)
        Me.EditBox15.Name = "EditBox15"
        Me.EditBox15.Size = New System.Drawing.Size(80, 23)
        Me.EditBox15.TabIndex = 25
        Me.EditBox15.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox15.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(440, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 23)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "$0.50"
        '
        'EditBox14
        '
        Me.EditBox14.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox14.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox14.Location = New System.Drawing.Point(328, 136)
        Me.EditBox14.Name = "EditBox14"
        Me.EditBox14.Size = New System.Drawing.Size(80, 23)
        Me.EditBox14.TabIndex = 23
        Me.EditBox14.Text = "50"
        Me.EditBox14.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox14.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(264, 136)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 23)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "$1"
        '
        'EditBox13
        '
        Me.EditBox13.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox13.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox13.Location = New System.Drawing.Point(328, 104)
        Me.EditBox13.Name = "EditBox13"
        Me.EditBox13.Size = New System.Drawing.Size(80, 23)
        Me.EditBox13.TabIndex = 21
        Me.EditBox13.Text = "19"
        Me.EditBox13.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox13.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(264, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(112, 23)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "$2"
        '
        'EditBox12
        '
        Me.EditBox12.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox12.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox12.Location = New System.Drawing.Point(328, 72)
        Me.EditBox12.Name = "EditBox12"
        Me.EditBox12.Size = New System.Drawing.Size(80, 23)
        Me.EditBox12.TabIndex = 19
        Me.EditBox12.Text = "65"
        Me.EditBox12.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox12.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(264, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 23)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "$5"
        '
        'EditBox11
        '
        Me.EditBox11.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox11.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox11.Location = New System.Drawing.Point(328, 40)
        Me.EditBox11.Name = "EditBox11"
        Me.EditBox11.Size = New System.Drawing.Size(80, 23)
        Me.EditBox11.TabIndex = 17
        Me.EditBox11.Text = "50"
        Me.EditBox11.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox11.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(264, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 23)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "$10"
        '
        'EditBox10
        '
        Me.EditBox10.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox10.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox10.Location = New System.Drawing.Point(144, 168)
        Me.EditBox10.Name = "EditBox10"
        Me.EditBox10.Size = New System.Drawing.Size(80, 23)
        Me.EditBox10.TabIndex = 15
        Me.EditBox10.Text = "21"
        Me.EditBox10.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox10.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(80, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 23)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "$20"
        '
        'EditBox9
        '
        Me.EditBox9.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox9.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox9.Location = New System.Drawing.Point(144, 136)
        Me.EditBox9.Name = "EditBox9"
        Me.EditBox9.Size = New System.Drawing.Size(80, 23)
        Me.EditBox9.TabIndex = 13
        Me.EditBox9.Text = "1"
        Me.EditBox9.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox9.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(80, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 23)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "$50"
        '
        'EditBox8
        '
        Me.EditBox8.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox8.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox8.Location = New System.Drawing.Point(144, 104)
        Me.EditBox8.Name = "EditBox8"
        Me.EditBox8.Size = New System.Drawing.Size(80, 23)
        Me.EditBox8.TabIndex = 11
        Me.EditBox8.Text = "23"
        Me.EditBox8.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox8.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(80, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 23)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "$100"
        '
        'EditBox7
        '
        Me.EditBox7.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox7.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox7.Location = New System.Drawing.Point(144, 72)
        Me.EditBox7.Name = "EditBox7"
        Me.EditBox7.Size = New System.Drawing.Size(80, 23)
        Me.EditBox7.TabIndex = 9
        Me.EditBox7.Text = "6"
        Me.EditBox7.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox7.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(80, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 23)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "$200"
        '
        'EditBox6
        '
        Me.EditBox6.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox6.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox6.Location = New System.Drawing.Point(144, 40)
        Me.EditBox6.Name = "EditBox6"
        Me.EditBox6.Size = New System.Drawing.Size(80, 23)
        Me.EditBox6.TabIndex = 7
        Me.EditBox6.Text = "9"
        Me.EditBox6.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox6.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(80, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 23)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "$500"
        '
        'frmRetiros
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(704, 514)
        Me.Controls.Add(Me.ExplorerBar3)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(720, 552)
        Me.MinimumSize = New System.Drawing.Size(720, 552)
        Me.Name = "frmRetiros"
        Me.Text = "Modulos de Retiros"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show("Iniciando Dia")

    End Sub

    Private Sub ExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemClick

    End Sub

    Private Sub ExplorerBar3_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar3.ItemClick

    End Sub
End Class
