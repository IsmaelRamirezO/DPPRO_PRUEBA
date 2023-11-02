Public Class FrmNumReferencia
    Inherits System.Windows.Forms.Form
    Private strTienda As String
    Private Fecha As Date

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal strTien As String, ByVal fec As Date)
        MyBase.New()
        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        strTienda = strTien
        Fecha = fec


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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiBtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents LblNumRef As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNumReferencia))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.LblNumRef = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UiBtnOk = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.LblNumRef)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.UiBtnOk)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(456, 272)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'LblNumRef
        '
        Me.LblNumRef.AutoSize = True
        Me.LblNumRef.BackColor = System.Drawing.Color.Transparent
        Me.LblNumRef.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumRef.ForeColor = System.Drawing.Color.Red
        Me.LblNumRef.Location = New System.Drawing.Point(73, 136)
        Me.LblNumRef.Name = "LblNumRef"
        Me.LblNumRef.Size = New System.Drawing.Size(0, 57)
        Me.LblNumRef.TabIndex = 6
        Me.LblNumRef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(145, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "EN FICHA DE DEPOSITO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(71, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(284, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "FAVOR DE ANOTAR NUMERO DE REFERENCIA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UiBtnOk
        '
        Me.UiBtnOk.Icon = CType(resources.GetObject("UiBtnOk.Icon"), System.Drawing.Icon)
        Me.UiBtnOk.Location = New System.Drawing.Point(148, 224)
        Me.UiBtnOk.Name = "UiBtnOk"
        Me.UiBtnOk.Size = New System.Drawing.Size(160, 32)
        Me.UiBtnOk.TabIndex = 3
        Me.UiBtnOk.Text = "&Aceptar"
        Me.UiBtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'FrmNumReferencia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 266)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(464, 304)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(464, 304)
        Me.Name = "FrmNumReferencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Numero de Referencia"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub UiBtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBtnOk.Click
        Me.Close()
    End Sub

    Private Sub FrmNumReferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------Numero de Referencia---------------
        Dim numref As New NumeroReferencia.cNumReferencia
        LblNumRef.Text = numref.getNumReferencia(strTienda.PadLeft(4, "0"), CStr(Format(Fecha.Date, "ddMMyyyy")))
        '------------------------------------------------------

    End Sub
End Class
