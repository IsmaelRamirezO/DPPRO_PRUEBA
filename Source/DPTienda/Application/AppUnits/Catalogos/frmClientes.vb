Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports ImageGear.Windows
Imports ImageGear.Windows.Forms
Imports ImageGear.Recognition
Imports ImageGear.Recognition.Forms
Imports ImageGear.Core
Imports ImageGear.Formats
Imports ImageGear.Processing
Imports ImageGear.Display
Imports ImageGear.ART
Imports ImageGear.TWAIN
Imports System.IO



'LIBRERIAS PARA SCANIFE
'Imports DportenisPro.DPTienda.ApplicationUnits.TwainGUI.vb.TwainLib
'Imports DportenisPro.DPTienda.ApplicationUnits.TwainGUI.vb.TwainGui
'Imports DportenisPro.DPTienda.ApplicationUnits.TwainGUI.vb.GdiPlusLib
'Imports DportenisPro.DPTienda.ApplicationUnits.TwainGUI.vb


Public Class frmClientes
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal p_dtdatos As DataTable, ByVal p_dtdatos2 As DataTable, ByVal p_dtdatos3 As DataTable, ByVal p_codalmacen As String)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        dtdatos = p_dtdatos
        dtdatos2 = p_dtdatos2
        dtdatos3 = p_dtdatos3
        codalmacen = p_codalmacen


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
    Friend WithEvents ebApellidoMaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents msFechaNac As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents ebCP As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents ebTelefono As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ebColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebApellidoPaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSexo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ebDomicilio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ebEmail As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnFormaPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebCodAlmacen As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCiudad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ebEstado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UiButton3 As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebClaveElector As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblClaveElector As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientes))
        Me.ebApellidoMaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.msFechaNac = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.ebCP = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.ebTelefono = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ebColonia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebApellidoPaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSexo = New Janus.Windows.EditControls.UIComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ebDomicilio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ebEmail = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebClaveElector = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblClaveElector = New System.Windows.Forms.Label()
        Me.UiButton3 = New Janus.Windows.EditControls.UIButton()
        Me.ebEstado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ebCiudad = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ebCodAlmacen = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.btnFormaPago = New Janus.Windows.EditControls.UIButton()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ebApellidoMaterno
        '
        Me.ebApellidoMaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebApellidoMaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebApellidoMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebApellidoMaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebApellidoMaterno.Location = New System.Drawing.Point(133, 88)
        Me.ebApellidoMaterno.MaxLength = 30
        Me.ebApellidoMaterno.Name = "ebApellidoMaterno"
        Me.ebApellidoMaterno.Size = New System.Drawing.Size(264, 22)
        Me.ebApellidoMaterno.TabIndex = 2
        Me.ebApellidoMaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebApellidoMaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 23)
        Me.Label12.TabIndex = 183
        Me.Label12.Text = "Apellido Materno:"
        '
        'msFechaNac
        '
        Me.msFechaNac.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.msFechaNac.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.msFechaNac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.msFechaNac.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msFechaNac.Location = New System.Drawing.Point(133, 184)
        Me.msFechaNac.Mask = "00/00/0000"
        Me.msFechaNac.MaxLength = 10
        Me.msFechaNac.Name = "msFechaNac"
        Me.msFechaNac.Size = New System.Drawing.Size(96, 23)
        Me.msFechaNac.TabIndex = 8
        Me.msFechaNac.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.msFechaNac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCP
        '
        Me.ebCP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCP.Location = New System.Drawing.Point(471, 136)
        Me.ebCP.MaxLength = 5
        Me.ebCP.Name = "ebCP"
        Me.ebCP.Numeric = True
        Me.ebCP.PromptChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.ebCP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ebCP.Size = New System.Drawing.Size(96, 22)
        Me.ebCP.TabIndex = 6
        Me.ebCP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTelefono
        '
        Me.ebTelefono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTelefono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebTelefono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTelefono.Location = New System.Drawing.Point(134, 209)
        Me.ebTelefono.Mask = "!(###) 000-0000"
        Me.ebTelefono.Name = "ebTelefono"
        Me.ebTelefono.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ebTelefono.Size = New System.Drawing.Size(96, 22)
        Me.ebTelefono.TabIndex = 10
        Me.ebTelefono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTelefono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(18, 212)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 16)
        Me.Label21.TabIndex = 177
        Me.Label21.Text = "Telefono:"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(408, 139)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 23)
        Me.Label20.TabIndex = 176
        Me.Label20.Text = "C.P. :"
        '
        'ebColonia
        '
        Me.ebColonia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebColonia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebColonia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebColonia.Location = New System.Drawing.Point(133, 136)
        Me.ebColonia.MaxLength = 50
        Me.ebColonia.Name = "ebColonia"
        Me.ebColonia.Size = New System.Drawing.Size(264, 22)
        Me.ebColonia.TabIndex = 4
        Me.ebColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(18, 136)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 23)
        Me.Label17.TabIndex = 173
        Me.Label17.Text = "Colonia:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "Apellido Paterno:"
        '
        'ebApellidoPaterno
        '
        Me.ebApellidoPaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebApellidoPaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebApellidoPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebApellidoPaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebApellidoPaterno.Location = New System.Drawing.Point(133, 64)
        Me.ebApellidoPaterno.MaxLength = 30
        Me.ebApellidoPaterno.Name = "ebApellidoPaterno"
        Me.ebApellidoPaterno.Size = New System.Drawing.Size(264, 22)
        Me.ebApellidoPaterno.TabIndex = 1
        Me.ebApellidoPaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebApellidoPaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSexo
        '
        Me.ebSexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebSexo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebSexo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "M"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "F"
        Me.ebSexo.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2})
        Me.ebSexo.Location = New System.Drawing.Point(333, 184)
        Me.ebSexo.Name = "ebSexo"
        Me.ebSexo.Size = New System.Drawing.Size(64, 22)
        Me.ebSexo.TabIndex = 9
        Me.ebSexo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 187)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 23)
        Me.Label9.TabIndex = 168
        Me.Label9.Text = "Fecha de Nacim.:"
        '
        'ebDomicilio
        '
        Me.ebDomicilio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDomicilio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDomicilio.Location = New System.Drawing.Point(133, 112)
        Me.ebDomicilio.MaxLength = 50
        Me.ebDomicilio.Name = "ebDomicilio"
        Me.ebDomicilio.Size = New System.Drawing.Size(264, 22)
        Me.ebDomicilio.TabIndex = 3
        Me.ebDomicilio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDomicilio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 23)
        Me.Label8.TabIndex = 165
        Me.Label8.Text = "Domicilio:"
        '
        'ebEmail
        '
        Me.ebEmail.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEmail.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebEmail.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEmail.Location = New System.Drawing.Point(134, 233)
        Me.ebEmail.MaxLength = 50
        Me.ebEmail.Name = "ebEmail"
        Me.ebEmail.Size = New System.Drawing.Size(264, 22)
        Me.ebEmail.TabIndex = 11
        Me.ebEmail.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEmail.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombre
        '
        Me.ebNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombre.Location = New System.Drawing.Point(133, 40)
        Me.ebNombre.MaxLength = 30
        Me.ebNombre.Name = "ebNombre"
        Me.ebNombre.Size = New System.Drawing.Size(264, 22)
        Me.ebNombre.TabIndex = 0
        Me.ebNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 236)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 157
        Me.Label7.Text = "E-mail:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(285, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 23)
        Me.Label6.TabIndex = 154
        Me.Label6.Text = "Sexo:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "Nombre:"
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.ebClaveElector)
        Me.ExplorerBar1.Controls.Add(Me.lblClaveElector)
        Me.ExplorerBar1.Controls.Add(Me.UiButton3)
        Me.ExplorerBar1.Controls.Add(Me.ebEstado)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.ebCiudad)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.ebCodAlmacen)
        Me.ExplorerBar1.Controls.Add(Me.UiButton1)
        Me.ExplorerBar1.Controls.Add(Me.btnFormaPago)
        Me.ExplorerBar1.Controls.Add(Me.ebApellidoMaterno)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.msFechaNac)
        Me.ExplorerBar1.Controls.Add(Me.ebCP)
        Me.ExplorerBar1.Controls.Add(Me.ebTelefono)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label20)
        Me.ExplorerBar1.Controls.Add(Me.ebColonia)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.ebApellidoPaterno)
        Me.ExplorerBar1.Controls.Add(Me.ebSexo)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.ebDomicilio)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.ebEmail)
        Me.ExplorerBar1.Controls.Add(Me.ebNombre)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.ContainerHeight = 100
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales Clientes"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(592, 398)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebClaveElector
        '
        Me.ebClaveElector.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClaveElector.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClaveElector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebClaveElector.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClaveElector.Location = New System.Drawing.Point(134, 257)
        Me.ebClaveElector.MaxLength = 20
        Me.ebClaveElector.Name = "ebClaveElector"
        Me.ebClaveElector.Size = New System.Drawing.Size(264, 22)
        Me.ebClaveElector.TabIndex = 12
        Me.ebClaveElector.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClaveElector.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblClaveElector
        '
        Me.lblClaveElector.BackColor = System.Drawing.Color.Transparent
        Me.lblClaveElector.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaveElector.Location = New System.Drawing.Point(18, 255)
        Me.lblClaveElector.Name = "lblClaveElector"
        Me.lblClaveElector.Size = New System.Drawing.Size(94, 23)
        Me.lblClaveElector.TabIndex = 192
        Me.lblClaveElector.Text = "Clave Elector:"
        Me.lblClaveElector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UiButton3
        '
        Me.UiButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton3.Location = New System.Drawing.Point(90, 336)
        Me.UiButton3.Name = "UiButton3"
        Me.UiButton3.Size = New System.Drawing.Size(130, 32)
        Me.UiButton3.TabIndex = 14
        Me.UiButton3.Text = "&Obtener datos"
        Me.UiButton3.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebEstado
        '
        Me.ebEstado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEstado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEstado.Location = New System.Drawing.Point(471, 160)
        Me.ebEstado.MaxLength = 50
        Me.ebEstado.Name = "ebEstado"
        Me.ebEstado.Size = New System.Drawing.Size(96, 22)
        Me.ebEstado.TabIndex = 7
        Me.ebEstado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(408, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 23)
        Me.Label5.TabIndex = 190
        Me.Label5.Text = "Estado:"
        '
        'ebCiudad
        '
        Me.ebCiudad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCiudad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCiudad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCiudad.Location = New System.Drawing.Point(133, 160)
        Me.ebCiudad.MaxLength = 50
        Me.ebCiudad.Name = "ebCiudad"
        Me.ebCiudad.Size = New System.Drawing.Size(264, 22)
        Me.ebCiudad.TabIndex = 5
        Me.ebCiudad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCiudad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 23)
        Me.Label4.TabIndex = 188
        Me.Label4.Text = "Ciudad:"
        '
        'ebCodAlmacen
        '
        Me.ebCodAlmacen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodAlmacen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodAlmacen.BackColor = System.Drawing.SystemColors.Info
        Me.ebCodAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodAlmacen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodAlmacen.Location = New System.Drawing.Point(134, 281)
        Me.ebCodAlmacen.MaxLength = 30
        Me.ebCodAlmacen.Name = "ebCodAlmacen"
        Me.ebCodAlmacen.ReadOnly = True
        Me.ebCodAlmacen.Size = New System.Drawing.Size(264, 22)
        Me.ebCodAlmacen.TabIndex = 13
        Me.ebCodAlmacen.TabStop = False
        Me.ebCodAlmacen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiButton1
        '
        Me.UiButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton1.Location = New System.Drawing.Point(380, 336)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(130, 32)
        Me.UiButton1.TabIndex = 16
        Me.UiButton1.Text = "&Salir"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnFormaPago
        '
        Me.btnFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFormaPago.Location = New System.Drawing.Point(235, 336)
        Me.btnFormaPago.Name = "btnFormaPago"
        Me.btnFormaPago.Size = New System.Drawing.Size(130, 32)
        Me.btnFormaPago.TabIndex = 15
        Me.btnFormaPago.Text = "&Guardar"
        Me.btnFormaPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 277)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 23)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Plaza:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmClientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 398)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmClientes"
        Me.Text = "Alta de Clientes"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oCliente As ClientesSAP
    Dim oAlmacenDes As Almacen
    Dim oCatalogoAlmacenMgr As CatalogoAlmacenesManager
    Dim oProcesosSAPMgr As ProcesoSAPManager
    Dim strResult As String
    'Dim oscanife As SCANIFE    <-- ANTERIOR INSTANCIA DE CLASE PARA ESCANEO Y OCR
    Dim dtdatos, dtdatos2, dtdatos3 As DataTable
    Dim codalmacen As String
    Dim claveelector As String

    'VARIABLES PARA IMAGEGEAR
    Private ml As ImageGear.Recognition.ImGearRecImage
    Public igRecognition As ImGearRecognition = Nothing
    Private igpage, igpage2 As ImGearPage
    Public igrecpage As ImGearRecPage
    Private z As ImGearRecZone
    Dim nombre, dir, nac As String()
    Dim igtwain As ImageGear.TWAIN.ImGearTWAIN
    Dim RDFilename, v As String

    Private Sub frmClientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'oscanife = New SCANIFE(Me.Handle)
        oCatalogoAlmacenMgr = New CatalogoAlmacenesManager(oAppContext)
        oAlmacenDes = oCatalogoAlmacenMgr.Load(oAppContext.ApplicationConfiguration.Almacen)
        Me.ebCodAlmacen.Text = oAlmacenDes.ID & "  " & oAlmacenDes.Descripcion
        
        ImageGear.Core.ImGearLicense.SetSolutionName("Comercial Dportenis SA de CV")

        Dim hex As String = "0x9A61F6AB"
        Dim myInt As UInt32 = Convert.ToUInt32(hex, 16)

        Dim hex2 As String = "0xAB1A5AB6"
        Dim myInt2 As UInt32 = Convert.ToUInt32(hex2, 16)

        Dim hex3 As String = "0x605B1F1B"
        Dim myInt3 As UInt32 = Convert.ToUInt32(hex3, 16)

        Dim hex4 As String = "0x08B85A98"
        Dim myInt4 As UInt32 = Convert.ToUInt32(hex4, 16)

        ImageGear.Core.ImGearLicense.SetSolutionKey(myInt, myInt2, myInt3, myInt4)

        
        'oAccuLicClientLib.GetHdwKey("")



        'ImageGear.Core.ImGearLicense.SetOEMLicenseKey("6KKL-7R3L-N86F-RK26-AK8A")

        igRecognition = New ImGearRecognition
        igtwain = New ImageGear.TWAIN.ImGearTWAIN
    End Sub

    Private Sub btnFormaPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormaPago.Click
        If ValidaDatos() Then

            oCliente = New ClientesSAP

            oCliente.Nombre = Me.ebApellidoPaterno.Text & "_" & Me.ebApellidoMaterno.Text & "_" & Me.ebNombre.Text
            oCliente.Domicilio = Me.ebDomicilio.Text.Trim
            oCliente.Colonia = Me.ebColonia.Text.Trim
            oCliente.Telefono = Me.ebTelefono.Text.Trim
            oCliente.Cp = Me.ebCP.Text.Trim
            oCliente.Sexo = Me.ebSexo.Text.Trim
            oCliente.Email = Me.ebEmail.Text.Trim
            oCliente.Fechanac = Me.msFechaNac.Text.Trim
            oCliente.Player = oAlmacenDes.ID 'Metenmos la tienda en #Player por que no se tiene un campo para este dato.
            oCliente.Ciudad = Me.ebCiudad.Text.Trim
            oCliente.Estado = Me.ebEstado.Text.Trim
            oCliente.claveelector = Me.ebClaveElector.Text.Trim


            oProcesosSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            strResult = oProcesosSAPMgr.Write_Clientes_PG(oCliente, dtdatos, dtdatos2, dtdatos3, codalmacen)

            If strResult = "R" Then
                MsgBox("¡Los datos se almacenaron correctamente!", MsgBoxStyle.Information, Me.Text)
                'Me.Close()
            ElseIf strResult = "D" Then
                MsgBox("¡El cliente ha sido actualizado!", MsgBoxStyle.Information, Me.Text)
            ElseIf strResult = "Y" Then
                MsgBox("¡Error en la grabación de la información de compra!", MsgBoxStyle.Information, Me.Text)
            ElseIf strResult = "X" Then
                MsgBox("¡Grabación de información de compra exitosa!", MsgBoxStyle.Information, Me.Text)
            End If
            Me.Close()
        End If
    End Sub

    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click
        Me.Close()
    End Sub

    Private Function ValidaDatos() As Boolean
        If Me.ebNombre.Text.Trim = String.Empty Then
            MessageBox.Show("Capture nombre de Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ebNombre.Focus()
            Return False

        ElseIf Me.ebApellidoPaterno.Text.Trim = String.Empty Then
            MessageBox.Show("Capture Apellido Paterno", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ebApellidoPaterno.Focus()
            Return False

        ElseIf Me.ebApellidoMaterno.Text.Trim = String.Empty Then
            MessageBox.Show("Capture Apellido Materno", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ebApellidoMaterno.Focus()
            Return False

        ElseIf Me.ebDomicilio.Text.Trim = String.Empty Then
            MessageBox.Show("Capture Domicilio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ebDomicilio.Focus()
            Return False

        ElseIf Me.ebColonia.Text.Trim = String.Empty Then
            MessageBox.Show("Capture Colonia", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ebColonia.Focus()
            Return False

        ElseIf Me.ebSexo.Text.Trim = String.Empty Then
            MessageBox.Show("Capture Sexo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ebSexo.Focus()
            Return False

        ElseIf Me.ebCiudad.Text.Trim = String.Empty Then
            MessageBox.Show("Capture Ciudad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ebCiudad.Focus()
            Return False

        ElseIf Me.ebEstado.Text.Trim = String.Empty Then
            MessageBox.Show("Capture Estado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ebEstado.Focus()
            Return False

        ElseIf Me.ebClaveElector.Text.Trim = String.Empty Then
            MessageBox.Show("Capture Clave de Elector", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ebClaveElector.Focus()
            Return False

        Else
            If Me.msFechaNac.Text.Trim = String.Empty Then
                MessageBox.Show("Capture Fecha de Nacimiento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.msFechaNac.Focus()
                Return False
            Else
                If Not IsDate(Me.msFechaNac.Text) Then
                    MessageBox.Show("Fecha de Nacimiento Incorrecta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.msFechaNac.Focus()
                    Return False
                Else
                    Return True
                End If
            End If
        End If
    End Function

    Private Sub frmClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub UiButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton3.Click
        ReDim nombre(3)
        ReDim dir(5)
        ReDim nac(3)

        ebNombre.Clear()
        ebApellidoPaterno.Clear()
        ebApellidoMaterno.Clear()
        ebDomicilio.Clear()
        ebColonia.Clear()
        ebCiudad.Clear()
        msFechaNac.Clear()
        ebEstado.Clear()
        ebCP.Clear()

        Dim cap, cap2, cap3, cap4, cap5, cap6 As ImGearCapOneValue
        Try
            igtwain.WindowHandle = Me.Handle
            igtwain.OpenSource("WIA-fi-60F")
            igtwain.UseUI = False
            cap = New ImGearCapOneValue(ImGearCapabilities.ICAP_XRESOLUTION)
            cap.Value = 600
            cap2 = New ImGearCapOneValue(ImGearCapabilities.ICAP_YRESOLUTION)
            cap2.Value = 600
            cap3 = New ImGearCapOneValue(ImGearCapabilities.CAP_DUPLEX)
            cap3.Value = False
            cap4 = New ImGearCapOneValue(ImGearCapabilities.ICAP_BITDEPTH)
            cap4.Value = 8
            cap5 = New ImGearCapOneValue(ImGearCapabilities.ICAP_PIXELTYPE)
            cap5.Value = ImGearPixelType.RGB
            cap6 = New ImGearCapOneValue(ImGearCapabilities.ICAP_PIXELFLAVOR)
            cap6.Value = ImGearPixelFlavor.VANILLA

            igtwain.SetCapability(cap, ImGearMessages.SET)
            igtwain.SetCapability(cap2, ImGearMessages.SET)
            igtwain.SetCapability(cap3, ImGearMessages.SET)
            igtwain.SetCapability(cap4, ImGearMessages.SET)
            igtwain.SetCapability(cap5, ImGearMessages.SET)
            igtwain.SetCapability(cap6, ImGearMessages.SET)

            igpage = Nothing
            igpage = igtwain.AcquireToPage()
            igtwain.CloseSource()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'OBTENER NOMBRE
        Try
            nombre = recnombre()
            ebNombre.Text = nombre(2)
            ebApellidoPaterno.Text = nombre(0)
            ebApellidoMaterno.Text = nombre(1)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

        'OBTENER DIRECCION
        Try
            dir = recdir()
            ebDomicilio.Text = dir(0)
            ebColonia.Text = dir(2)
            ebCP.Text = dir(1)
            ebCiudad.Text = dir(3)
            ebEstado.Text = dir(4)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

        'OBTENER FECHA NACIMIENTO Y CLAVE DE ELECTOR
        Try
            nac = recnac()
            msFechaNac.Text = nac(0)
            Me.ebClaveElector.Text = nac(1)
            'claveelector = nac(1)
            claveelector = Me.ebClaveElector.Text
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try


        'ANTERIOR CODIGO DE RECONOCIMIENTO

        'Dim nombreife(), dirife(), fechaife() As String
        'ReDim nombreife(3)
        'ReDim dirife(6)
        'ReDim fechaife(2) 'aqui viene la fecha y la clave de elector

        'ebNombre.Clear()
        'ebApellidoPaterno.Clear()
        'ebApellidoMaterno.Clear()
        'ebDomicilio.Clear()
        ''ebNumero.Clear()
        'ebColonia.Clear()
        'ebCP.Clear()
        'ebCiudad.Clear()
        'ebEstado.Clear()
        'msFechaNac.Clear()
        'ebTelefono.Clear()
        'ebEmail.Clear()

        'Try
        '    nombreife = oscanife.GetNombre
        '    ebApellidoPaterno.Text = nombreife(0).Trim
        '    ebApellidoMaterno.Text = nombreife(1).Substring(1, nombreife(1).Length - 1)
        '    ebApellidoMaterno.Text.Trim()
        '    ebNombre.Text = nombreife(2).Substring(1, nombreife(2).Length - 1)
        '    ebNombre.Text.Trim()
        'Catch ex As Exception
        'End Try

        'Try
        '    dirife = oscanife.GetDireccion
        '    ebDomicilio.Text = dirife(1) + " " + dirife(0)
        '    'ebNumero.Text = dirife(0)
        '    ebColonia.Text = dirife(3).Trim
        '    ebCP.Text = dirife(2).Trim
        '    ebCiudad.Text = dirife(4).Trim
        '    ebEstado.Text = dirife(5).Trim
        'Catch ex As Exception
        'End Try

        'Try
        '    fechaife = oscanife.GetFechNacimiento
        '    msFechaNac.Text = fechaife(0)
        '    claveelector = fechaife(1)
        '    MsgBox(claveelector)
        'Catch ex As Exception
        'End Try
    End Sub

    Public Function recnombre() As String()

        Dim v As String
        Dim r As String()
        ReDim r(3)

        Try
            igpage2 = igpage
            ImGearColorProfileSettings.CheckColorMismatch(igpage2)
            ImGearColorBookSettings.CheckForSpotColors(igpage2)
            igrecpage = igRecognition.ImportPage(igpage2)

            z = New ImGearRecZone(ImGearRecFillingMethod.DEFAULT, ImGearRecRecognitionModule.AUTO)
            z.Rect = New ImGearRectangle(0, 387, 710, 200)
            igrecpage.Zones.Add(z)

            igrecpage.RecognizeToMemory()
            igRecognition.OutputManager.CodePage = "Windows ANSI"
            igRecognition.OutputManager.Level = ImGearRecOutputLevel.DROPFORMAT
            igRecognition.OutputManager.Format = "Rec ASCII (StandardEx)"

            RDFilename = Path.GetTempFileName()
            igrecpage.WriteRecognitionData(RDFilename)
            igRecognition.OutputManager.WriteDocument(RDFilename, ".")

            v = igRecognition.OutputManager.OutputText()
            r = v.Split(Microsoft.VisualBasic.vbCrLf)
            r(0) = r(0).Trim()
            r(1) = r(1).Trim()
            r(2) = r(2).Trim()
            Return r

        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("El nombre no se escaneo correctamente")
        End Try
    End Function

    Public Function recdir() As String()

        Dim codpos As Integer
        Dim r, r2, cdedo As String()
        ReDim r(5), r2(5), cdedo(3)

        Try
            igpage2 = igpage
            ImGearColorProfileSettings.CheckColorMismatch(igpage2)
            ImGearColorBookSettings.CheckForSpotColors(igpage2)
            igrecpage = igRecognition.ImportPage(igpage2)

            z = New ImGearRecZone(ImGearRecFillingMethod.DEFAULT, ImGearRecRecognitionModule.AUTO)
            z.Rect = New ImGearRectangle(0, 633, 1100, 210)
            igrecpage.Zones.Add(z)

            igrecpage.RecognizeToMemory()
            igRecognition.OutputManager.CodePage = "Windows ANSI"
            igRecognition.OutputManager.Level = ImGearRecOutputLevel.DROPFORMAT
            igRecognition.OutputManager.Format = "Rec ASCII (StandardEx)"

            RDFilename = Path.GetTempFileName()
            igrecpage.WriteRecognitionData(RDFilename)
            igRecognition.OutputManager.WriteDocument(RDFilename, ".")

            v = igRecognition.OutputManager.OutputText()
            r = v.Split(Microsoft.VisualBasic.vbCrLf)
            r(0) = r(0).Trim()
            r(1) = r(1).Trim()
            r(2) = r(2).Trim()

            'obtener calle y num
            r2(0) = r(0)

            'obtener cod postal
            codpos = r(1).Length
            r2(1) = r(1).Substring(codpos - 5, 5)

            'obtener colonia
            r2(2) = r(1).Substring(0, codpos - 6)

            Try
                'separar ciudad y estado
                cdedo = r(2).Split(" ")

                'obtener ciudad
                r2(3) = cdedo(0)

                'obtener estado
                r2(4) = cdedo(1)
                r2(4) = r2(4).Replace(",", "")
                r2(4) = r2(4).Replace(".", "")

            Catch ex As Exception
            End Try

            Return r2

        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("La direccion no se escaneo correctamente")
        End Try
    End Function

    Public Function recnac() As String()

        Dim r As String()
        Dim anno, mes, dia, annoact, ce1, ce2, ce3 As String
        Dim anno2, annoact2 As Integer
        ReDim r(3)

        Try
            igpage2 = igpage
            ImGearColorProfileSettings.CheckColorMismatch(igpage2)
            ImGearColorBookSettings.CheckForSpotColors(igpage2)
            igrecpage = igRecognition.ImportPage(igpage2)

            z = New ImGearRecZone(ImGearRecFillingMethod.DEFAULT, ImGearRecRecognitionModule.AUTO)
            z.Rect = New ImGearRectangle(470, 912, 860, 70)
            igrecpage.Zones.Add(z)

            igrecpage.RecognizeToMemory()
            igRecognition.OutputManager.CodePage = "Windows ANSI"
            igRecognition.OutputManager.Level = ImGearRecOutputLevel.DROPFORMAT
            igRecognition.OutputManager.Format = "Rec ASCII (StandardEx)"

            RDFilename = Path.GetTempFileName()
            igrecpage.WriteRecognitionData(RDFilename)
            igRecognition.OutputManager.WriteDocument(RDFilename, ".")

            v = igRecognition.OutputManager.OutputText().Replace(Microsoft.VisualBasic.vbCrLf, " ")
            v = v.Replace(" ", "")

            anno = v.Substring(6, 2)
            mes = v.Substring(8, 2)
            dia = v.Substring(10, 2)
            ce1 = v.Substring(0, 6)
            ce2 = anno + mes + dia
            ce3 = v.Substring(12, 6)
            annoact = DateString.Substring(6, 4)

            Try
                anno2 = Int32.Parse(anno)
                annoact2 = Int32.Parse(annoact)

                'AGREGAR 99 ó 20 al año
                If (2000 + anno2) < annoact2 Then
                    If (annoact2 - (2000 + anno) < 17) Then
                        anno = "19" + anno
                    ElseIf (annoact - (1900 + anno) > 99) Then
                        anno = "20" + anno
                    End If
                Else
                    anno = "19" + anno
                End If
            Catch ex As Exception
                MsgBox("La fecha de nacimiento no se ha digitalizado correctamente, vuelva a escanear la credencial, o corrija manualmente.")
                anno = "00" + anno
            End Try

            r(0) = dia + "/" + mes + "/" + anno
            r(1) = ce1 + ce2 + ce3

            Return r

        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("La fecha de nacimiento no se escaneo correctamente")
        End Try
    End Function

    Private Sub ebNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ebNombre.KeyPress
        ' en la siguiente línea de código se comprueba si el caracter es dígito...
        If (Not e.KeyChar.IsLetter(e.KeyChar)) Then
            ' de igual forma se podría comprobar si es caracter: e.KeyChar.IsLetter
            ' si es un caracter minusculas: e.KeyChar.IsLower ...etc
            If Not (e.KeyChar = Convert.ToChar(Keys.Back)) Then
                e.Handled = True ' esto invalida la tecla pulsada
            End If
        End If
    End Sub

    Private Sub ebApellidoPaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ebApellidoPaterno.KeyPress
        If (Not e.KeyChar.IsLetter(e.KeyChar)) Then
            If Not (e.KeyChar = Convert.ToChar(Keys.Back)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ebApellidoMaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ebApellidoMaterno.KeyPress
        If (Not e.KeyChar.IsLetter(e.KeyChar)) Then
            If Not (e.KeyChar = Convert.ToChar(Keys.Back)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ebCiudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ebCiudad.KeyPress
        If (Not e.KeyChar.IsLetter(e.KeyChar)) Then
            If Not (e.KeyChar = Convert.ToChar(Keys.Back)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ebEstado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ebEstado.KeyPress
        If (Not e.KeyChar.IsLetter(e.KeyChar)) Then
            If Not (e.KeyChar = Convert.ToChar(Keys.Back)) Then
                e.Handled = True
            End If
        End If
    End Sub
End Class
