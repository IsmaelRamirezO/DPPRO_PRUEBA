<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagoEcommMenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.webApiEcomm = New EO.WinForm.WebControl()
        Me.WebView1 = New EO.WebBrowser.WebView()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.webticket = New EO.WinForm.WebControl()
        Me.WebView2 = New EO.WebBrowser.WebView()
        Me.WebControl1 = New EO.WinForm.WebControl()
        Me.SuspendLayout()
        '
        'webApiEcomm
        '
        Me.webApiEcomm.BackColor = System.Drawing.Color.White
        Me.webApiEcomm.Location = New System.Drawing.Point(2, 2)
        Me.webApiEcomm.Name = "webApiEcomm"
        Me.webApiEcomm.Size = New System.Drawing.Size(979, 604)
        Me.webApiEcomm.TabIndex = 0
        Me.webApiEcomm.Text = "WebControl1"
        Me.webApiEcomm.WebView = Me.WebView1
        '
        'WebView1
        '
        Me.WebView1.InputMsgFilter = Nothing
        Me.WebView1.ObjectForScripting = Nothing
        Me.WebView1.Title = Nothing
        '
        'UiButton1
        '
        Me.UiButton1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.UiButton1.Location = New System.Drawing.Point(885, 612)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(84, 23)
        Me.UiButton1.TabIndex = 1
        Me.UiButton1.Text = "Cancelar"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'webticket
        '
        Me.webticket.BackColor = System.Drawing.Color.White
        Me.webticket.Location = New System.Drawing.Point(12, 579)
        Me.webticket.Name = "webticket"
        Me.webticket.Size = New System.Drawing.Size(535, 27)
        Me.webticket.TabIndex = 3
        Me.webticket.Text = "WebControl1"
        Me.webticket.WebView = Me.WebView2
        '
        'WebView2
        '
        Me.WebView2.InputMsgFilter = Nothing
        Me.WebView2.ObjectForScripting = Nothing
        Me.WebView2.Title = Nothing
        '
        'WebControl1
        '
        Me.WebControl1.BackColor = System.Drawing.Color.White
        Me.WebControl1.Location = New System.Drawing.Point(1, 20)
        Me.WebControl1.Name = "WebControl1"
        Me.WebControl1.Size = New System.Drawing.Size(979, 95)
        Me.WebControl1.TabIndex = 4
        Me.WebControl1.Text = "WebControl1"
        '
        'frmPagoEcommMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 645)
        Me.Controls.Add(Me.webApiEcomm)
        Me.Controls.Add(Me.UiButton1)
        Me.Controls.Add(Me.webticket)
        Me.Controls.Add(Me.WebControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "frmPagoEcommMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DPVale"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents webApiEcomm As EO.WinForm.WebControl
    Friend WithEvents WebView1 As EO.WebBrowser.WebView
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents webticket As EO.WinForm.WebControl
    Friend WithEvents WebView2 As EO.WebBrowser.WebView
    Friend WithEvents WebControl1 As EO.WinForm.WebControl
End Class
