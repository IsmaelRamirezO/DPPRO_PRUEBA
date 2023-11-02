Public Class frmModDatosFact
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
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox7 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox8 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox9 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CalendarCombo1 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents EditBox3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox4 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox5 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents CalendarCombo2 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents EditBox10 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox11 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents EditBox12 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox13 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox14 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox15 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox16 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox17 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox18 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox19 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox26 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox20 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox21 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox6 As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModDatosFact))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.EditBox17 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox16 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox15 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox14 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox13 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox12 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.CalendarCombo1 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.EditBox7 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox8 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox9 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.EditBox6 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiButton2 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.CalendarCombo2 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.EditBox10 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox11 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox3 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox4 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox5 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.EditBox26 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox18 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox19 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox21 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox20 = New Janus.Windows.GridEX.EditControls.EditBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.EditBox17)
        Me.ExplorerBar1.Controls.Add(Me.EditBox16)
        Me.ExplorerBar1.Controls.Add(Me.EditBox15)
        Me.ExplorerBar1.Controls.Add(Me.EditBox14)
        Me.ExplorerBar1.Controls.Add(Me.EditBox13)
        Me.ExplorerBar1.Controls.Add(Me.EditBox12)
        Me.ExplorerBar1.Controls.Add(Me.CalendarCombo1)
        Me.ExplorerBar1.Controls.Add(Me.EditBox7)
        Me.ExplorerBar1.Controls.Add(Me.EditBox8)
        Me.ExplorerBar1.Controls.Add(Me.EditBox9)
        Me.ExplorerBar1.Controls.Add(Me.EditBox2)
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos de la Factura a Modificar"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(704, 888)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'EditBox17
        '
        Me.EditBox17.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox17.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox17.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox17.Location = New System.Drawing.Point(176, 176)
        Me.EditBox17.Name = "EditBox17"
        Me.EditBox17.Size = New System.Drawing.Size(136, 22)
        Me.EditBox17.TabIndex = 31
        Me.EditBox17.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox17.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox16
        '
        Me.EditBox16.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox16.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox16.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox16.Location = New System.Drawing.Point(176, 152)
        Me.EditBox16.Name = "EditBox16"
        Me.EditBox16.Size = New System.Drawing.Size(136, 22)
        Me.EditBox16.TabIndex = 30
        Me.EditBox16.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox16.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox15
        '
        Me.EditBox15.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox15.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox15.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox15.Location = New System.Drawing.Point(176, 128)
        Me.EditBox15.Name = "EditBox15"
        Me.EditBox15.Size = New System.Drawing.Size(136, 22)
        Me.EditBox15.TabIndex = 29
        Me.EditBox15.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox15.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox14
        '
        Me.EditBox14.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox14.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox14.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox14.Location = New System.Drawing.Point(464, 104)
        Me.EditBox14.Name = "EditBox14"
        Me.EditBox14.Size = New System.Drawing.Size(192, 22)
        Me.EditBox14.TabIndex = 28
        Me.EditBox14.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox14.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox13
        '
        Me.EditBox13.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox13.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox13.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox13.Location = New System.Drawing.Point(464, 80)
        Me.EditBox13.Name = "EditBox13"
        Me.EditBox13.Size = New System.Drawing.Size(192, 22)
        Me.EditBox13.TabIndex = 27
        Me.EditBox13.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox13.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox12
        '
        Me.EditBox12.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox12.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox12.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox12.Location = New System.Drawing.Point(464, 56)
        Me.EditBox12.Name = "EditBox12"
        Me.EditBox12.Size = New System.Drawing.Size(192, 22)
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
        Me.CalendarCombo1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalendarCombo1.Location = New System.Drawing.Point(176, 104)
        Me.CalendarCombo1.Name = "CalendarCombo1"
        Me.CalendarCombo1.Size = New System.Drawing.Size(136, 22)
        Me.CalendarCombo1.TabIndex = 25
        Me.CalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'EditBox7
        '
        Me.EditBox7.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox7.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox7.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox7.Location = New System.Drawing.Point(464, 176)
        Me.EditBox7.Name = "EditBox7"
        Me.EditBox7.ReadOnly = True
        Me.EditBox7.Size = New System.Drawing.Size(192, 22)
        Me.EditBox7.TabIndex = 24
        Me.EditBox7.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox7.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox8
        '
        Me.EditBox8.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox8.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox8.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox8.Location = New System.Drawing.Point(464, 152)
        Me.EditBox8.Name = "EditBox8"
        Me.EditBox8.Size = New System.Drawing.Size(192, 22)
        Me.EditBox8.TabIndex = 23
        Me.EditBox8.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox8.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox9
        '
        Me.EditBox9.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox9.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox9.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox9.Location = New System.Drawing.Point(464, 128)
        Me.EditBox9.Name = "EditBox9"
        Me.EditBox9.ReadOnly = True
        Me.EditBox9.Size = New System.Drawing.Size(192, 22)
        Me.EditBox9.TabIndex = 22
        Me.EditBox9.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox9.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox2.Location = New System.Drawing.Point(176, 80)
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.Size = New System.Drawing.Size(136, 22)
        Me.EditBox2.TabIndex = 14
        Me.EditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox1.Location = New System.Drawing.Point(176, 56)
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.Size = New System.Drawing.Size(136, 22)
        Me.EditBox1.TabIndex = 13
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(48, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Factura:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(48, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 23)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Fecha:"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(48, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 23)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Tipo de Venta:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(48, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 23)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Forma de Pago 1:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 23)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Forma de Pago 2:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(336, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Player:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(336, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Banco:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(336, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Pago 1:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(336, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Pago 2:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(336, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Folio Not. Credito:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(336, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo de Tarjeta:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Caja:"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.EditBox6)
        Me.ExplorerBar2.Controls.Add(Me.UiButton2)
        Me.ExplorerBar2.Controls.Add(Me.UiButton1)
        Me.ExplorerBar2.Controls.Add(Me.CalendarCombo2)
        Me.ExplorerBar2.Controls.Add(Me.EditBox10)
        Me.ExplorerBar2.Controls.Add(Me.EditBox11)
        Me.ExplorerBar2.Controls.Add(Me.EditBox3)
        Me.ExplorerBar2.Controls.Add(Me.EditBox4)
        Me.ExplorerBar2.Controls.Add(Me.EditBox5)
        Me.ExplorerBar2.Controls.Add(Me.Label13)
        Me.ExplorerBar2.Controls.Add(Me.Label14)
        Me.ExplorerBar2.Controls.Add(Me.Label15)
        Me.ExplorerBar2.Controls.Add(Me.Label16)
        Me.ExplorerBar2.Controls.Add(Me.Label17)
        Me.ExplorerBar2.Controls.Add(Me.Label18)
        Me.ExplorerBar2.Controls.Add(Me.Label19)
        Me.ExplorerBar2.Controls.Add(Me.Label20)
        Me.ExplorerBar2.Controls.Add(Me.Label21)
        Me.ExplorerBar2.Controls.Add(Me.Label22)
        Me.ExplorerBar2.Controls.Add(Me.Label23)
        Me.ExplorerBar2.Controls.Add(Me.Label24)
        Me.ExplorerBar2.Controls.Add(Me.EditBox26)
        Me.ExplorerBar2.Controls.Add(Me.EditBox18)
        Me.ExplorerBar2.Controls.Add(Me.EditBox19)
        Me.ExplorerBar2.Controls.Add(Me.EditBox21)
        Me.ExplorerBar2.Controls.Add(Me.EditBox20)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Nueva Forma de Pago"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 232)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(704, 256)
        Me.ExplorerBar2.TabIndex = 1
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'EditBox6
        '
        Me.EditBox6.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox6.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox6.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox6.Location = New System.Drawing.Point(464, 56)
        Me.EditBox6.Name = "EditBox6"
        Me.EditBox6.Size = New System.Drawing.Size(192, 22)
        Me.EditBox6.TabIndex = 51
        Me.EditBox6.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox6.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiButton2
        '
        Me.UiButton2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton2.Location = New System.Drawing.Point(352, 224)
        Me.UiButton2.Name = "UiButton2"
        Me.UiButton2.Size = New System.Drawing.Size(75, 23)
        Me.UiButton2.TabIndex = 50
        Me.UiButton2.Text = "Cancelar"
        Me.UiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton1
        '
        Me.UiButton1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton1.Location = New System.Drawing.Point(256, 224)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(75, 23)
        Me.UiButton1.TabIndex = 49
        Me.UiButton1.Text = "Guardar"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'CalendarCombo2
        '
        '
        '
        '
        Me.CalendarCombo2.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.CalendarCombo2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalendarCombo2.Location = New System.Drawing.Point(184, 104)
        Me.CalendarCombo2.Name = "CalendarCombo2"
        Me.CalendarCombo2.Size = New System.Drawing.Size(136, 22)
        Me.CalendarCombo2.TabIndex = 45
        Me.CalendarCombo2.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'EditBox10
        '
        Me.EditBox10.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox10.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox10.Location = New System.Drawing.Point(184, 80)
        Me.EditBox10.Name = "EditBox10"
        Me.EditBox10.Size = New System.Drawing.Size(136, 22)
        Me.EditBox10.TabIndex = 44
        Me.EditBox10.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox10.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox11
        '
        Me.EditBox11.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox11.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox11.Location = New System.Drawing.Point(184, 56)
        Me.EditBox11.Name = "EditBox11"
        Me.EditBox11.Size = New System.Drawing.Size(136, 22)
        Me.EditBox11.TabIndex = 43
        Me.EditBox11.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox11.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox3
        '
        Me.EditBox3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox3.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox3.Location = New System.Drawing.Point(464, 176)
        Me.EditBox3.Name = "EditBox3"
        Me.EditBox3.Size = New System.Drawing.Size(192, 22)
        Me.EditBox3.TabIndex = 40
        Me.EditBox3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox4
        '
        Me.EditBox4.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox4.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox4.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox4.Location = New System.Drawing.Point(464, 152)
        Me.EditBox4.Name = "EditBox4"
        Me.EditBox4.Size = New System.Drawing.Size(192, 22)
        Me.EditBox4.TabIndex = 39
        Me.EditBox4.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox5
        '
        Me.EditBox5.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox5.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox5.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox5.Location = New System.Drawing.Point(464, 128)
        Me.EditBox5.Name = "EditBox5"
        Me.EditBox5.Size = New System.Drawing.Size(192, 22)
        Me.EditBox5.TabIndex = 38
        Me.EditBox5.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(48, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 23)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Factura:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(48, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 23)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Fecha:"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(48, 128)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 23)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Tipo de Venta:"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(48, 152)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(136, 23)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Forma de Pago 1:"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(48, 176)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 23)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Forma de Pago 2:"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(336, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 23)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "Player:"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(336, 88)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 23)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "Banco:"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(336, 160)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 23)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "Pago 1:"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(336, 184)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 23)
        Me.Label21.TabIndex = 28
        Me.Label21.Text = "Pago 2:"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(336, 136)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(136, 23)
        Me.Label22.TabIndex = 27
        Me.Label22.Text = "Folio Not. Credito:"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(336, 112)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(120, 23)
        Me.Label23.TabIndex = 26
        Me.Label23.Text = "Tipo de Tarjeta:"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(48, 56)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 23)
        Me.Label24.TabIndex = 25
        Me.Label24.Text = "Caja:"
        '
        'EditBox26
        '
        Me.EditBox26.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox26.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox26.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox26.Location = New System.Drawing.Point(184, 128)
        Me.EditBox26.Name = "EditBox26"
        Me.EditBox26.Size = New System.Drawing.Size(136, 22)
        Me.EditBox26.TabIndex = 33
        Me.EditBox26.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox26.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox18
        '
        Me.EditBox18.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox18.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox18.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox18.Location = New System.Drawing.Point(184, 176)
        Me.EditBox18.Name = "EditBox18"
        Me.EditBox18.Size = New System.Drawing.Size(136, 22)
        Me.EditBox18.TabIndex = 35
        Me.EditBox18.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox18.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox19
        '
        Me.EditBox19.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox19.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox19.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox19.Location = New System.Drawing.Point(184, 152)
        Me.EditBox19.Name = "EditBox19"
        Me.EditBox19.Size = New System.Drawing.Size(136, 22)
        Me.EditBox19.TabIndex = 34
        Me.EditBox19.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox19.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox21
        '
        Me.EditBox21.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox21.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox21.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox21.Location = New System.Drawing.Point(464, 80)
        Me.EditBox21.Name = "EditBox21"
        Me.EditBox21.Size = New System.Drawing.Size(192, 22)
        Me.EditBox21.TabIndex = 32
        Me.EditBox21.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox21.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox20
        '
        Me.EditBox20.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox20.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox20.BackColor = System.Drawing.SystemColors.Info
        Me.EditBox20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox20.Location = New System.Drawing.Point(464, 104)
        Me.EditBox20.Name = "EditBox20"
        Me.EditBox20.ReadOnly = True
        Me.EditBox20.Size = New System.Drawing.Size(192, 22)
        Me.EditBox20.TabIndex = 33
        Me.EditBox20.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox20.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmModDatosFact
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(696, 482)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(712, 520)
        Me.MinimumSize = New System.Drawing.Size(712, 520)
        Me.Name = "frmModDatosFact"
        Me.Text = "Datos de Factura a Cambiar"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ExplorerBar2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ExplorerBar2_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar2.ItemClick

    End Sub

    Private Sub frmModDatosFact_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
