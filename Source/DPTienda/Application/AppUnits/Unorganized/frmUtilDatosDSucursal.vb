Public Class frmUtilDatosDSucursal
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox4 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox5 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox6 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox7 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox8 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox10 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox11 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox12 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox13 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox14 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox16 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox17 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox19 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox20 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox21 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox22 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox23 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton3 As Janus.Windows.EditControls.UIButton
    Friend WithEvents EditBox9 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents uigbContent As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUtilDatosDSucursal))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.EditBox9 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiButton3 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton2 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.EditBox14 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox16 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox17 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox19 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox20 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox21 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox22 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox23 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox13 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox12 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox11 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox10 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox8 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox7 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox6 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox5 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox4 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox3 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
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
        Me.uigbContent = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.uigbContent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.EditBox9)
        Me.ExplorerBar1.Controls.Add(Me.UiButton3)
        Me.ExplorerBar1.Controls.Add(Me.UiButton2)
        Me.ExplorerBar1.Controls.Add(Me.UiButton1)
        Me.ExplorerBar1.Controls.Add(Me.EditBox14)
        Me.ExplorerBar1.Controls.Add(Me.EditBox16)
        Me.ExplorerBar1.Controls.Add(Me.EditBox17)
        Me.ExplorerBar1.Controls.Add(Me.EditBox19)
        Me.ExplorerBar1.Controls.Add(Me.EditBox20)
        Me.ExplorerBar1.Controls.Add(Me.EditBox21)
        Me.ExplorerBar1.Controls.Add(Me.EditBox22)
        Me.ExplorerBar1.Controls.Add(Me.EditBox23)
        Me.ExplorerBar1.Controls.Add(Me.EditBox13)
        Me.ExplorerBar1.Controls.Add(Me.EditBox12)
        Me.ExplorerBar1.Controls.Add(Me.EditBox11)
        Me.ExplorerBar1.Controls.Add(Me.EditBox10)
        Me.ExplorerBar1.Controls.Add(Me.EditBox8)
        Me.ExplorerBar1.Controls.Add(Me.EditBox7)
        Me.ExplorerBar1.Controls.Add(Me.EditBox6)
        Me.ExplorerBar1.Controls.Add(Me.EditBox5)
        Me.ExplorerBar1.Controls.Add(Me.EditBox4)
        Me.ExplorerBar1.Controls.Add(Me.EditBox3)
        Me.ExplorerBar1.Controls.Add(Me.EditBox2)
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label15)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        Me.ExplorerBar1.Controls.Add(Me.Label19)
        Me.ExplorerBar1.Controls.Add(Me.Label20)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Controls.Add(Me.Label23)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
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
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(8, 168)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(696, 272)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'EditBox9
        '
        Me.EditBox9.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox9.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox9.Location = New System.Drawing.Point(200, 272)
        Me.EditBox9.Name = "EditBox9"
        Me.EditBox9.Size = New System.Drawing.Size(136, 23)
        Me.EditBox9.TabIndex = 51
        Me.EditBox9.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox9.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiButton3
        '
        Me.UiButton3.Location = New System.Drawing.Point(392, 440)
        Me.UiButton3.Name = "UiButton3"
        Me.UiButton3.Size = New System.Drawing.Size(80, 24)
        Me.UiButton3.TabIndex = 50
        Me.UiButton3.Text = "Cancelar"
        '
        'UiButton2
        '
        Me.UiButton2.Location = New System.Drawing.Point(296, 440)
        Me.UiButton2.Name = "UiButton2"
        Me.UiButton2.Size = New System.Drawing.Size(80, 24)
        Me.UiButton2.TabIndex = 49
        Me.UiButton2.Text = "Buscar"
        '
        'UiButton1
        '
        Me.UiButton1.Location = New System.Drawing.Point(200, 440)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(80, 24)
        Me.UiButton1.TabIndex = 48
        Me.UiButton1.Text = "Guardar"
        '
        'EditBox14
        '
        Me.EditBox14.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox14.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox14.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox14.Location = New System.Drawing.Point(496, 384)
        Me.EditBox14.Name = "EditBox14"
        Me.EditBox14.Size = New System.Drawing.Size(152, 23)
        Me.EditBox14.TabIndex = 45
        Me.EditBox14.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox14.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox16
        '
        Me.EditBox16.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox16.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox16.Location = New System.Drawing.Point(496, 320)
        Me.EditBox16.Name = "EditBox16"
        Me.EditBox16.Size = New System.Drawing.Size(152, 23)
        Me.EditBox16.TabIndex = 43
        Me.EditBox16.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox16.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox17
        '
        Me.EditBox17.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox17.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox17.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox17.Location = New System.Drawing.Point(496, 296)
        Me.EditBox17.Name = "EditBox17"
        Me.EditBox17.Size = New System.Drawing.Size(152, 23)
        Me.EditBox17.TabIndex = 42
        Me.EditBox17.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox17.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox19
        '
        Me.EditBox19.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox19.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox19.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox19.Location = New System.Drawing.Point(496, 232)
        Me.EditBox19.Name = "EditBox19"
        Me.EditBox19.Size = New System.Drawing.Size(152, 23)
        Me.EditBox19.TabIndex = 40
        Me.EditBox19.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox19.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox20
        '
        Me.EditBox20.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox20.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox20.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox20.Location = New System.Drawing.Point(496, 208)
        Me.EditBox20.Name = "EditBox20"
        Me.EditBox20.Size = New System.Drawing.Size(152, 23)
        Me.EditBox20.TabIndex = 39
        Me.EditBox20.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox20.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox21
        '
        Me.EditBox21.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox21.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox21.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox21.Location = New System.Drawing.Point(496, 184)
        Me.EditBox21.Name = "EditBox21"
        Me.EditBox21.Size = New System.Drawing.Size(152, 23)
        Me.EditBox21.TabIndex = 38
        Me.EditBox21.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox21.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox22
        '
        Me.EditBox22.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox22.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox22.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox22.Location = New System.Drawing.Point(496, 160)
        Me.EditBox22.Name = "EditBox22"
        Me.EditBox22.Size = New System.Drawing.Size(152, 23)
        Me.EditBox22.TabIndex = 37
        Me.EditBox22.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox22.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox23
        '
        Me.EditBox23.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox23.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox23.Location = New System.Drawing.Point(496, 120)
        Me.EditBox23.Name = "EditBox23"
        Me.EditBox23.Size = New System.Drawing.Size(64, 23)
        Me.EditBox23.TabIndex = 36
        Me.EditBox23.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox23.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox13
        '
        Me.EditBox13.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox13.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox13.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox13.Location = New System.Drawing.Point(200, 384)
        Me.EditBox13.Name = "EditBox13"
        Me.EditBox13.Size = New System.Drawing.Size(112, 23)
        Me.EditBox13.TabIndex = 35
        Me.EditBox13.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox13.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox12
        '
        Me.EditBox12.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox12.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox12.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox12.Location = New System.Drawing.Point(200, 360)
        Me.EditBox12.Name = "EditBox12"
        Me.EditBox12.Size = New System.Drawing.Size(112, 23)
        Me.EditBox12.TabIndex = 34
        Me.EditBox12.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox12.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox11
        '
        Me.EditBox11.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox11.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox11.Location = New System.Drawing.Point(200, 320)
        Me.EditBox11.Name = "EditBox11"
        Me.EditBox11.Size = New System.Drawing.Size(112, 23)
        Me.EditBox11.TabIndex = 33
        Me.EditBox11.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox11.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox10
        '
        Me.EditBox10.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox10.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox10.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox10.Location = New System.Drawing.Point(200, 296)
        Me.EditBox10.Name = "EditBox10"
        Me.EditBox10.Size = New System.Drawing.Size(136, 23)
        Me.EditBox10.TabIndex = 32
        Me.EditBox10.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox10.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox8
        '
        Me.EditBox8.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox8.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox8.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox8.Location = New System.Drawing.Point(200, 232)
        Me.EditBox8.Name = "EditBox8"
        Me.EditBox8.Size = New System.Drawing.Size(152, 23)
        Me.EditBox8.TabIndex = 30
        Me.EditBox8.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox8.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox7
        '
        Me.EditBox7.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox7.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox7.Location = New System.Drawing.Point(200, 208)
        Me.EditBox7.Name = "EditBox7"
        Me.EditBox7.Size = New System.Drawing.Size(152, 23)
        Me.EditBox7.TabIndex = 29
        Me.EditBox7.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox7.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox6
        '
        Me.EditBox6.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox6.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox6.Location = New System.Drawing.Point(200, 184)
        Me.EditBox6.Name = "EditBox6"
        Me.EditBox6.Size = New System.Drawing.Size(152, 23)
        Me.EditBox6.TabIndex = 28
        Me.EditBox6.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox6.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox5
        '
        Me.EditBox5.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox5.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditBox5.Location = New System.Drawing.Point(200, 160)
        Me.EditBox5.Name = "EditBox5"
        Me.EditBox5.Size = New System.Drawing.Size(152, 23)
        Me.EditBox5.TabIndex = 27
        Me.EditBox5.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox4
        '
        Me.EditBox4.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox4.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox4.Location = New System.Drawing.Point(128, 120)
        Me.EditBox4.Name = "EditBox4"
        Me.EditBox4.Size = New System.Drawing.Size(224, 23)
        Me.EditBox4.TabIndex = 26
        Me.EditBox4.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox3
        '
        Me.EditBox3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox3.Location = New System.Drawing.Point(128, 96)
        Me.EditBox3.Name = "EditBox3"
        Me.EditBox3.Size = New System.Drawing.Size(224, 23)
        Me.EditBox3.TabIndex = 25
        Me.EditBox3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.Location = New System.Drawing.Point(128, 72)
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.Size = New System.Drawing.Size(224, 23)
        Me.EditBox2.TabIndex = 24
        Me.EditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.Location = New System.Drawing.Point(128, 48)
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.Size = New System.Drawing.Size(112, 23)
        Me.EditBox1.TabIndex = 23
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(360, 368)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 64)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Configurar Tipo de Venta para esta Sucursal:"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(360, 320)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(128, 16)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "Fondo de Caja:"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(360, 296)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(152, 40)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Banco de Tarjetas:"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(360, 240)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(152, 64)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Ruta de Trasmite:"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(360, 216)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(152, 64)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "Ruta de Reportes:"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(360, 192)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(160, 64)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "Ruta de Temporales:"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(360, 168)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(144, 64)
        Me.Label22.TabIndex = 15
        Me.Label22.Text = "Ruta de Envio:"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(360, 128)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(144, 64)
        Me.Label23.TabIndex = 14
        Me.Label23.Text = "Cajon de Dinero:"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(56, 392)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(176, 64)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Descuento Max DIP's:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(56, 368)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(160, 64)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Descuento Maximo:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(56, 328)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 64)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Caja Chica:"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(56, 304)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(160, 64)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Banca a Depositar:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(56, 280)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 64)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Tipo de Deposito:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(56, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 64)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Ruta de Rep. Inv.: "
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 64)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Ruta de Recepcion:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(56, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 64)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Ruta de Respaldo:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(56, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 64)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Ruta de Bases:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(56, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 64)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Puerto:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(56, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 64)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Ciudad:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(56, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 64)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 64)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sucursal:"
        '
        'uigbContent
        '
        Me.uigbContent.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarBackground
        Me.uigbContent.Controls.Add(Me.Label14)
        Me.uigbContent.Controls.Add(Me.Label16)
        Me.uigbContent.Controls.Add(Me.Label24)
        Me.uigbContent.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.uigbContent.Location = New System.Drawing.Point(8, 8)
        Me.uigbContent.Name = "uigbContent"
        Me.uigbContent.Size = New System.Drawing.Size(680, 152)
        Me.uigbContent.TabIndex = 1
        Me.uigbContent.Text = "UiGroupBox1"
        Me.uigbContent.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(8, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 23)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Label14"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(8, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 23)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Label16"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(8, 72)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 23)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Label24"
        '
        'frmUtilDatosDSucursal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(688, 466)
        Me.Controls.Add(Me.uigbContent)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(704, 504)
        Me.MinimumSize = New System.Drawing.Size(704, 504)
        Me.Name = "frmUtilDatosDSucursal"
        Me.Text = "Datos de Sucursal"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.uigbContent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uigbContent.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmUtilDatosDSucursal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
