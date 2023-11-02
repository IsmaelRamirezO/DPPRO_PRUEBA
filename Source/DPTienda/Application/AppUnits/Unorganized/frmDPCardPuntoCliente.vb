Public Class frmDPCardPuntoCliente
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents explorer As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblApellidoPaterno As System.Windows.Forms.Label
    Friend WithEvents txtNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtPaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDPCardPuntoCliente))
        Me.explorer = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.txtTelefono = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.txtPaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblApellidoPaterno = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        CType(Me.explorer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorer.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorer
        '
        Me.explorer.Controls.Add(Me.txtTelefono)
        Me.explorer.Controls.Add(Me.lblTelefono)
        Me.explorer.Controls.Add(Me.btnCancelar)
        Me.explorer.Controls.Add(Me.btnAceptar)
        Me.explorer.Controls.Add(Me.txtPaterno)
        Me.explorer.Controls.Add(Me.txtNombre)
        Me.explorer.Controls.Add(Me.lblApellidoPaterno)
        Me.explorer.Controls.Add(Me.lblNombre)
        Me.explorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorer.Location = New System.Drawing.Point(0, 0)
        Me.explorer.Name = "explorer"
        Me.explorer.Size = New System.Drawing.Size(338, 120)
        Me.explorer.TabIndex = 0
        Me.explorer.Text = "ExplorerBar1"
        Me.explorer.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'txtTelefono
        '
        Me.txtTelefono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTelefono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTelefono.BackColor = System.Drawing.SystemColors.Info
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(128, 56)
        Me.txtTelefono.MaxLength = 10
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(200, 21)
        Me.txtTelefono.TabIndex = 3
        Me.txtTelefono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtTelefono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.BackColor = System.Drawing.Color.Transparent
        Me.lblTelefono.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono.Location = New System.Drawing.Point(9, 56)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(68, 16)
        Me.lblTelefono.TabIndex = 241
        Me.lblTelefono.Text = "Telefono:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(256, 88)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 24)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.Location = New System.Drawing.Point(176, 88)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 24)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtPaterno
        '
        Me.txtPaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPaterno.BackColor = System.Drawing.SystemColors.Info
        Me.txtPaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaterno.Location = New System.Drawing.Point(128, 32)
        Me.txtPaterno.Name = "txtPaterno"
        Me.txtPaterno.Size = New System.Drawing.Size(200, 21)
        Me.txtPaterno.TabIndex = 2
        Me.txtPaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtNombre
        '
        Me.txtNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(128, 8)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(200, 21)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblApellidoPaterno
        '
        Me.lblApellidoPaterno.AutoSize = True
        Me.lblApellidoPaterno.BackColor = System.Drawing.Color.Transparent
        Me.lblApellidoPaterno.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApellidoPaterno.Location = New System.Drawing.Point(8, 32)
        Me.lblApellidoPaterno.Name = "lblApellidoPaterno"
        Me.lblApellidoPaterno.Size = New System.Drawing.Size(120, 16)
        Me.lblApellidoPaterno.TabIndex = 223
        Me.lblApellidoPaterno.Text = "Apellido Paterno:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(8, 8)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(62, 16)
        Me.lblNombre.TabIndex = 222
        Me.lblNombre.Text = "Nombre:"
        '
        'frmDPCardPuntoCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(338, 120)
        Me.Controls.Add(Me.explorer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDPCardPuntoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Información de Cliente DPCard Puntos"
        CType(Me.explorer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorer.ResumeLayout(False)
        Me.explorer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private m_nombre As String
    Private m_ApePaterno As String
    Private m_telefono As String
    Private accion As Boolean = False
#End Region

#Region "Propiedades"

    Public Property Nombre() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal Value As String)
            m_nombre = Value
        End Set
    End Property

    Public Property ApePaterno() As String
        Get
            Return m_ApePaterno
        End Get
        Set(ByVal Value As String)
            m_ApePaterno = Value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal Value As String)
            m_telefono = Value
        End Set
    End Property

#End Region

#Region "Eventos Form"

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        SaveCliente()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If accion = False Then
            Me.DialogResult = DialogResult.Cancel
            Me.Dispose()
        End If
    End Sub

    Private Sub frmDPCardPuntoCliente_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If accion = False Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        ValidarNumeros(e)
    End Sub

#End Region

#Region "Metodos"

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Captura el nombre y apellido paterno del cliente DPCard Puntos
    '----------------------------------------------------------------------------------------------------------------------------
    Private Sub SaveCliente()
        If txtNombre.Text.Trim() <> "" AndAlso txtPaterno.Text.Trim() <> "" AndAlso txtTelefono.Text.Trim() <> "" Then
            If txtTelefono.Text.Length = 10 Then
                Me.Nombre = txtNombre.Text.Trim()
                Me.ApePaterno = txtPaterno.Text.Trim()
                Me.Telefono = txtTelefono.Text.Trim()
                Me.accion = True
                Me.DialogResult = DialogResult.OK
            Else
                MessageBox.Show("El número telefonico debe ser igual a diez digitos", "DPPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            
        Else
            MessageBox.Show("Debe capturar el nombre, apellido y telefono del cliente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
#End Region

    
End Class
