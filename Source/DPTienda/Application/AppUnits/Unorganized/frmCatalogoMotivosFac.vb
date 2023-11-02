Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class frmCatalogoMotivosFac
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
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebStatus As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebDesFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebfecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoMotivosFac))
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.btnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.ebStatus = New Janus.Windows.EditControls.UIComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebfecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ebDesFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiButton1
        '
        Me.UiButton1.BackColor = System.Drawing.SystemColors.Window
        Me.UiButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton1.Location = New System.Drawing.Point(304, 104)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(120, 32)
        Me.UiButton1.TabIndex = 7
        Me.UiButton1.Text = "&Salir"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Window
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(168, 104)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(128, 32)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebStatus
        '
        Me.ebStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebStatus.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "ACTIVO"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "INACTIVO"
        Me.ebStatus.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2})
        Me.ebStatus.Location = New System.Drawing.Point(168, 152)
        Me.ebStatus.Name = "ebStatus"
        Me.ebStatus.Size = New System.Drawing.Size(128, 22)
        Me.ebStatus.TabIndex = 4
        Me.ebStatus.Visible = False
        Me.ebStatus.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(48, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 23)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Fecha de registro:"
        '
        'ebDescripcion
        '
        Me.ebDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescripcion.Location = New System.Drawing.Point(168, 40)
        Me.ebDescripcion.MaxLength = 150
        Me.ebDescripcion.Name = "ebDescripcion"
        Me.ebDescripcion.Size = New System.Drawing.Size(264, 22)
        Me.ebDescripcion.TabIndex = 3
        Me.ebDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(48, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Status:"
        Me.Label6.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descripción:"
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.ebfecha)
        Me.ExplorerBar1.Controls.Add(Me.ebDesFecha)
        Me.ExplorerBar1.Controls.Add(Me.UiButton1)
        Me.ExplorerBar1.Controls.Add(Me.btnGuardar)
        Me.ExplorerBar1.Controls.Add(Me.ebStatus)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.ebDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.ContainerHeight = 100
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales "
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(456, 149)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebfecha
        '
        Me.ebfecha.DateFormat = Janus.Windows.CalendarCombo.DateFormat.[Long]
        '
        '
        '
        Me.ebfecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebfecha.Location = New System.Drawing.Point(168, 72)
        Me.ebfecha.Name = "ebfecha"
        Me.ebfecha.ReadOnly = True
        Me.ebfecha.ShowDropDown = False
        Me.ebfecha.Size = New System.Drawing.Size(264, 20)
        Me.ebfecha.TabIndex = 5
        Me.ebfecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ebDesFecha
        '
        Me.ebDesFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDesFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDesFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDesFecha.Enabled = False
        Me.ebDesFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDesFecha.Location = New System.Drawing.Point(16, 200)
        Me.ebDesFecha.MaxLength = 50
        Me.ebDesFecha.Name = "ebDesFecha"
        Me.ebDesFecha.ReadOnly = True
        Me.ebDesFecha.Size = New System.Drawing.Size(264, 22)
        Me.ebDesFecha.TabIndex = 8
        Me.ebDesFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDesFecha.Visible = False
        Me.ebDesFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmCatalogoMotivosFac
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(456, 149)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoMotivosFac"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogo Motivos Captura Manual"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oFacturaMGR As FacturaManager

#Region "Funciones"
    Public Function valida() As Boolean
        valida = False
        If Me.ebDescripcion.Text = "" Then
            MsgBox("¡La descripción es necesaria!", MsgBoxStyle.Information, Me.Text)
            Me.ebDescripcion.Focus()
            Exit Function
        End If
        'If Me.ebStatus.Text = "" Then
        '    MsgBox("¡El Status es necesario!", MsgBoxStyle.Information, Me.Text)
        '    Me.ebStatus.Focus()
        '    Exit Function
        'End If
        valida = True
    End Function

#End Region

#Region "Eventos Privados"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If valida() Then
            Dim shrtStatus As Short
            oFacturaMGR = New FacturaManager(oAppContext)
            'If Me.ebStatus.Text = "ACTIVO" Then
            '    shrtStatus = 1
            'Else
            '    shrtStatus = 0
            'End If
            shrtStatus = 1
            If oFacturaMGR.SaveCatalogoMotivo(Me.ebDescripcion.Text, shrtStatus, Me.ebfecha.Value) Then
                MsgBox("!Se registró satisfactoriamente¡", MsgBoxStyle.Information, "Catalogo Motivos Captura Manual")
                Me.ebDescripcion.Text = ""
                Me.ebDescripcion.Focus()
            End If
        End If
    End Sub

    Private Sub frmCatalogoMotivosFac_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.ebStatus.SelectedIndex = 0
        Me.ebfecha.Value = Now.Date.ToShortDateString
        'Me.ebDesFecha.Text = Format(Now.Date, "dddd") & ", " & Now.Day & " de " & Format(Now.Date, "MMMM") & " de " & Now.Year
    End Sub

    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click
        Me.Close()
    End Sub

    Private Sub frmCatalogoMotivosFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

    
    
    
   
End Class
