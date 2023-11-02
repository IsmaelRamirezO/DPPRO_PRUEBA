Public Class frmSplash
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.lblVersion.Text = "Versión " & strVersionSuc
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
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblTexto As System.Windows.Forms.Label
    Friend WithEvents pbAvance As Janus.Windows.EditControls.UIProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.pbAvance = New Janus.Windows.EditControls.UIProgressBar()
        Me.lblTexto = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BackgroundImage = CType(resources.GetObject("explorerBar1.BackgroundImage"), System.Drawing.Image)
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.pbAvance)
        Me.explorerBar1.Controls.Add(Me.lblTexto)
        Me.explorerBar1.Controls.Add(Me.lblVersion)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.ItemsStateStyles.HotFormatStyle.FontUnderline = Janus.Windows.ExplorerBar.TriState.[True]
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(496, 278)
        Me.explorerBar1.TabIndex = 4
        Me.explorerBar1.Text = "ExplorerBar1"
        '
        'pbAvance
        '
        Me.pbAvance.BorderStyle = Janus.Windows.UI.BorderStyle.None
        Me.pbAvance.Location = New System.Drawing.Point(42, 159)
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue
        Me.pbAvance.ProgressFormatStyle.BackColor = System.Drawing.Color.Transparent
        Me.pbAvance.Size = New System.Drawing.Size(413, 12)
        Me.pbAvance.TabIndex = 7
        Me.pbAvance.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010
        '
        'lblTexto
        '
        Me.lblTexto.BackColor = System.Drawing.Color.Transparent
        Me.lblTexto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto.ForeColor = System.Drawing.SystemColors.Window
        Me.lblTexto.Location = New System.Drawing.Point(39, 174)
        Me.lblTexto.Name = "lblTexto"
        Me.lblTexto.Size = New System.Drawing.Size(416, 24)
        Me.lblTexto.TabIndex = 6
        Me.lblTexto.Text = "Cargando Configuración..."
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.Window
        Me.lblVersion.Location = New System.Drawing.Point(12, 245)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(472, 24)
        Me.lblVersion.TabIndex = 5
        Me.lblVersion.Text = "Versión 20130701"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSplash
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 278)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSplash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSplash"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub pbFondo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles explorerBar1.Click
        Me.Close()
    End Sub

End Class
