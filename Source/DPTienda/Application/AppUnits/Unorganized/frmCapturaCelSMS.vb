Imports System.Text.RegularExpressions

Public Class frmCapturaCelSMS
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Inicializar()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents nebLada As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nebNumCel As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebEmail As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaCelSMS))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebEmail = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.nebNumCel = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nebLada = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.ebEmail)
        Me.explorerBar1.Controls.Add(Me.Label2)
        Me.explorerBar1.Controls.Add(Me.btnCancelar)
        Me.explorerBar1.Controls.Add(Me.btnAceptar)
        Me.explorerBar1.Controls.Add(Me.nebNumCel)
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Controls.Add(Me.nebLada)
        Me.explorerBar1.Controls.Add(Me.Label3)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(298, 136)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebEmail
        '
        Me.ebEmail.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEmail.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEmail.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEmail.Location = New System.Drawing.Point(48, 56)
        Me.ebEmail.Name = "ebEmail"
        Me.ebEmail.Size = New System.Drawing.Size(240, 22)
        Me.ebEmail.TabIndex = 2
        Me.ebEmail.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEmail.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = "0"
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Email"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(160, 96)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(128, 32)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Icon = CType(resources.GetObject("btnAceptar.Icon"), System.Drawing.Icon)
        Me.btnAceptar.Location = New System.Drawing.Point(8, 96)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(128, 32)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'nebNumCel
        '
        Me.nebNumCel.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebNumCel.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebNumCel.ControlStyle.ControlColor = System.Drawing.SystemColors.Window
        Me.nebNumCel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebNumCel.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebNumCel.Location = New System.Drawing.Point(152, 16)
        Me.nebNumCel.MaxLength = 8
        Me.nebNumCel.Name = "nebNumCel"
        Me.nebNumCel.Size = New System.Drawing.Size(136, 22)
        Me.nebNumCel.TabIndex = 1
        Me.nebNumCel.Text = "1523695"
        Me.nebNumCel.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebNumCel.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebNumCel.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = "0"
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Número"
        '
        'nebLada
        '
        Me.nebLada.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebLada.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebLada.ControlStyle.ControlColor = System.Drawing.SystemColors.Window
        Me.nebLada.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebLada.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebLada.Location = New System.Drawing.Point(48, 16)
        Me.nebLada.MaxLength = 3
        Me.nebLada.Name = "nebLada"
        Me.nebLada.Size = New System.Drawing.Size(40, 22)
        Me.nebLada.TabIndex = 0
        Me.nebLada.Text = "669"
        Me.nebLada.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nebLada.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebLada.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = "0"
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "LADA"
        '
        'frmCapturaCelSMS
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(298, 136)
        Me.ControlBox = False
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaCelSMS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura Teléfono Celular"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.explorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Inicializar()
        Me.nebLada.Value = 0
        Me.nebNumCel.Value = 0
        Me.ebEmail.Text = ""
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Me.nebNumCel.Value > 0 AndAlso Me.nebLada.Value <= 0 Then
            MessageBox.Show("Es necesario indicar la clave LADA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebLada.Focus()
        ElseIf Me.ebEmail.Text.Trim = "" AndAlso Me.nebNumCel.Value <= 0 Then
            MessageBox.Show("Es necesario indicar algun dato", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebNumCel.Focus()
        ElseIf Me.nebNumCel.Value > 0 AndAlso Me.nebLada.Text.Trim.Length < 2 Then
            MessageBox.Show("Clave LADA Incorrecta. Verifique", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebLada.Focus()
        ElseIf Me.nebNumCel.Value > 0 AndAlso Me.nebNumCel.Text.Trim.Length < 7 Then
            MessageBox.Show("Número Celular Incorrecto. Verifique", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebNumCel.Focus()
        Else
            Me.DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub frmCapturaCelSMS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub ebEmail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebEmail.Validating
        If Me.ebEmail.Text.Trim <> "" Then
            If ValidaEmail(Me.ebEmail.Text.Trim) = False Then
                MessageBox.Show("El Correo es invalido, favor de verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Function ValidaEmail(ByVal strEmail As String) As Boolean

        Return Regex.IsMatch(strEmail.Trim, "^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" & _
                 "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")

    End Function

    Private Sub frmCapturaCelSMS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If oConfigCierreFI.PedirDatosPromoComienzo Then Me.Text = "Captura Datos de Clientes"

    End Sub

    Private Sub frmCapturaCelSMS_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Me.DialogResult = DialogResult.Cancel AndAlso MessageBox.Show("¿Estas seguro que deseas cancelar la captura de los datos del cliente?", _
        "Promoción SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            e.Cancel = True
        End If

    End Sub

End Class
