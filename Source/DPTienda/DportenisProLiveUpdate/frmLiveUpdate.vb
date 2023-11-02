Imports System.IO

Public Class frmLiveUpdate
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
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents pgStatus As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents lblActualiza As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.pgStatus = New Janus.Windows.EditControls.UIProgressBar
        Me.lblActualiza = New System.Windows.Forms.Label
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.lblActualiza)
        Me.explorerBar1.Controls.Add(Me.pgStatus)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(394, 72)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'pgStatus
        '
        Me.pgStatus.Location = New System.Drawing.Point(16, 40)
        Me.pgStatus.Name = "pgStatus"
        Me.pgStatus.ShowPercentage = True
        Me.pgStatus.Size = New System.Drawing.Size(360, 23)
        Me.pgStatus.TabIndex = 1
        Me.pgStatus.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'lblActualiza
        '
        Me.lblActualiza.BackColor = System.Drawing.Color.Transparent
        Me.lblActualiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActualiza.Location = New System.Drawing.Point(16, 16)
        Me.lblActualiza.Name = "lblActualiza"
        Me.lblActualiza.Size = New System.Drawing.Size(136, 16)
        Me.lblActualiza.TabIndex = 2
        Me.lblActualiza.Text = "Actualizando..."
        '
        'frmLiveUpdate
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(394, 72)
        Me.ControlBox = False
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmLiveUpdate"
        Me.Text = "Actualiza Versión"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CopiaArchivo()

        Dim oFile As FileInfo
        Dim oFileNew As FileInfo
        Dim Tam As Long
        Dim TamNew As Long

        oFile = New FileInfo("C:\test.rar")
        Tam = oFile.Length

        Me.pgStatus.Maximum = Tam
        Me.pgStatus.Minimum = 0

        Application.DoEvents()
        File.Copy("C:\test.rar", "C:\test2.rar")

        oFileNew = New FileInfo("C:\test2.rar")
        TamNew = oFileNew.Length

        Do While Tam - TamNew < Tam

            Me.pgStatus.Value = TamNew
            Application.DoEvents()

        Loop

        MsgBox("Copiado")

    End Sub

End Class
