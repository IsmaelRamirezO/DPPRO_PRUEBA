Imports DportenisPro.DPTienda.ApplicationUnits.InicioDia

Public Class frmRenuevaPassword
    Inherits System.Windows.Forms.Form

    Dim oInicioMgr As InicioDiaManager
    Dim oEncrypt As SecurityHash

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oInicioMgr = New InicioDiaManager(oAppContext)
        oEncrypt = New SecurityHash
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
    Friend WithEvents ebPass1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ebPass2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRenuevaPassword))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.ebPass2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebPass1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.btnAceptar)
        Me.explorerBar1.Controls.Add(Me.ebPass2)
        Me.explorerBar1.Controls.Add(Me.Label2)
        Me.explorerBar1.Controls.Add(Me.ebPass1)
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(354, 144)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Icon = CType(resources.GetObject("btnAceptar.Icon"), System.Drawing.Icon)
        Me.btnAceptar.Location = New System.Drawing.Point(16, 80)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(320, 56)
        Me.btnAceptar.TabIndex = 213
        Me.btnAceptar.Text = "Guardar Nueva Contraseña"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebPass2
        '
        Me.ebPass2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPass2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPass2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPass2.Location = New System.Drawing.Point(152, 48)
        Me.ebPass2.Name = "ebPass2"
        Me.ebPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebPass2.Size = New System.Drawing.Size(184, 23)
        Me.ebPass2.TabIndex = 211
        Me.ebPass2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebPass2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 16)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = "Confirmar Contraseña"
        '
        'ebPass1
        '
        Me.ebPass1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPass1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPass1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPass1.Location = New System.Drawing.Point(152, 16)
        Me.ebPass1.Name = "ebPass1"
        Me.ebPass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebPass1.Size = New System.Drawing.Size(184, 23)
        Me.ebPass1.TabIndex = 209
        Me.ebPass1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebPass1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "Nueva Contraseña"
        '
        'frmRenuevaPassword
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(354, 144)
        Me.ControlBox = False
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRenuevaPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Renovar Contraseña"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.explorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Function ValidaHistorialPassword() As Boolean

        Dim bRes As Boolean = True
        Dim dtHistPwd As DataTable
        Dim oRow As DataRow, pwd As String = ""

        dtHistPwd = oInicioMgr.GetHistorialUserPasswords(oAppContext.Security.CurrentUser.ID)

        For Each oRow In dtHistPwd.Rows
            pwd = oEncrypt.DesEncriptarCML(CStr(oRow!SessionPassword).Trim)
            If pwd.Trim = Me.ebPass1.Text.Trim Then
                bRes = False
                Exit For
            End If
        Next

        Return bRes

    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim strMsg As String = "", strPass As String = ""

        If oInicioMgr.ValidaPassword(Me.ebPass1.Text, strMsg) = False OrElse ValidaHistorialPassword() = False Then
            MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebPass1.Focus()
        ElseIf Me.ebPass1.Text.Trim <> Me.ebPass2.Text.Trim Then
            MessageBox.Show("La nueva contraseña no coincide con la confirmación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebPass2.Focus()
        Else
            strPass = oEncrypt.EncriptarCML(Me.ebPass1.Text.Trim)

            oInicioMgr.RenuevaPassword(strPass, oAppContext.Security.CurrentUser.ID)

            MessageBox.Show("Su nueva contraseña se ha guardado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub frmRenuevaPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select

    End Sub

    Private Sub ebPass1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebPass1.GotFocus
        Me.ebPass1.SelectAll()
    End Sub

    Private Sub ebPass2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebPass2.GotFocus
        Me.ebPass2.SelectAll()
    End Sub
End Class
