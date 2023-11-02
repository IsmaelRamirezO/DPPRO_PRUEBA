Public Class frmMensajeSeleccionTraspaso
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbLista As System.Windows.Forms.ListBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents pbTipoMsj As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMensajeSeleccionTraspaso))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.pbTipoMsj = New System.Windows.Forms.PictureBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.lbLista = New System.Windows.Forms.ListBox()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.pbTipoMsj, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.pbTipoMsj)
        Me.ExplorerBar1.Controls.Add(Me.lblMsg)
        Me.ExplorerBar1.Controls.Add(Me.lbLista)
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(298, 264)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'pbTipoMsj
        '
        Me.pbTipoMsj.BackColor = System.Drawing.Color.Transparent
        Me.pbTipoMsj.Image = CType(resources.GetObject("pbTipoMsj.Image"), System.Drawing.Image)
        Me.pbTipoMsj.Location = New System.Drawing.Point(16, 24)
        Me.pbTipoMsj.Name = "pbTipoMsj"
        Me.pbTipoMsj.Size = New System.Drawing.Size(60, 60)
        Me.pbTipoMsj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbTipoMsj.TabIndex = 53
        Me.pbTipoMsj.TabStop = False
        '
        'lblMsg
        '
        Me.lblMsg.BackColor = System.Drawing.Color.Transparent
        Me.lblMsg.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(88, 8)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(192, 88)
        Me.lblMsg.TabIndex = 52
        Me.lblMsg.Text = "Mensaje"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLista
        '
        Me.lbLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbLista.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLista.ItemHeight = 16
        Me.lbLista.Location = New System.Drawing.Point(16, 104)
        Me.lbLista.Name = "lbLista"
        Me.lbLista.Size = New System.Drawing.Size(264, 98)
        Me.lbLista.TabIndex = 51
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Window
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Icon = CType(resources.GetObject("btnCancelar.Icon"), System.Drawing.Icon)
        Me.btnCancelar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnCancelar.Location = New System.Drawing.Point(168, 216)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(112, 32)
        Me.btnCancelar.TabIndex = 50
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Window
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Icon = CType(resources.GetObject("btnAceptar.Icon"), System.Drawing.Icon)
        Me.btnAceptar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnAceptar.Location = New System.Drawing.Point(16, 216)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(120, 32)
        Me.btnAceptar.TabIndex = 49
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmMensajeSeleccionTraspaso
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(298, 264)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMensajeSeleccionTraspaso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMensajeSeleccionTraspaso"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.pbTipoMsj, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA 17.06.2014: Carga de Traspaso de Entrada desde Lectora.
    '                  Formulario que sirve para mostrar una lista de Traspasos de Entrada para seleccionar uno.
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public hLista As Hashtable
    Public index As Integer = 0
    Public bCancel As Boolean = False
    Public isTraspaso As Boolean = False

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If isTraspaso Then index = lbLista.SelectedIndex()
        Me.Close()
    End Sub

    Private Sub frmMensajeSeleccionTraspaso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 0 To hLista.Count - 1
            lbLista.Items.Add(hLista(i))
        Next
        lbLista.Update()

        If isTraspaso Then
            lbLista.SelectedIndex = 0
        Else
            Me.btnAceptar.Location = New Point(89, 216)
            btnCancelar.Visible = False
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MessageBox.Show("El proceso de carga de Traspasos de Entrada desde la lectora esta en curso. Si lo cancela, ningún Traspaso sera cargado." & vbCrLf & "¿Seguro que desea cancelar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
            bCancel = True
            Me.Close()
        End If
    End Sub
End Class
