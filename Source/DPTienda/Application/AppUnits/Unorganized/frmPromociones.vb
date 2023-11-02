Public Class frmPromociones
    Inherits System.Windows.Forms.Form

    Private m_strSkip As String = """"

    Private m_strPlazo As String = """"

    Dim strPromo As String
    Dim strPromoArray() As String

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal strCadenaPromocion As String)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        strPromo = strCadenaPromocion
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
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ebPromocion As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.ebPromocion = New Janus.Windows.EditControls.UIComboBox()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.ebPromocion)
        Me.ExplorerBar1.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.ContainerHeight = 100
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "SELECCIONE LA PROMOCIÓN DESEADA"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(498, 144)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(272, 88)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(128, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebPromocion
        '
        Me.ebPromocion.Location = New System.Drawing.Point(120, 48)
        Me.ebPromocion.Name = "ebPromocion"
        Me.ebPromocion.Size = New System.Drawing.Size(352, 20)
        Me.ebPromocion.TabIndex = 0
        Me.ebPromocion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(104, 88)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(128, 32)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 23)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Promoción:"
        '
        'frmPromociones
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(498, 144)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.Name = "frmPromociones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccion de Promoción"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propiedades"
    Public Property Plazo() As String
        Get
            Return m_strPlazo
        End Get
        Set(ByVal Value As String)
            m_strPlazo = Value
        End Set
    End Property

    Public Property Skip() As String
        Get
            Return m_strSkip
        End Get
        Set(ByVal Value As String)
            m_strSkip = Value
        End Set
    End Property

#End Region

    Private Sub ebPromocion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim intIndex As Integer
        If Me.ebPromocion.Text = String.Empty Then
            MsgBox("¡Seleccione una promoción!", MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If

        intIndex = ebPromocion.SelectedIndex
        Me.Plazo = Mid(strPromoArray(intIndex), 1, 2)
        Me.Skip = Mid(strPromoArray(intIndex), 3, 2)

        Me.Close()
    End Sub

    Private Sub frmPromociones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strPromoArray = strPromo.Split("|")
        For Each strDato As String In strPromoArray
            ebPromocion.Items.Add(Mid(strDato, 5))
        Next
    End Sub
End Class
