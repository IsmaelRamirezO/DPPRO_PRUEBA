
Public Class FrmClientesFiltroSAP
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents rbApellidoPaterno As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbNombre As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbApellidoMaterno As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents ebCriterio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ubAceptar As Janus.Windows.EditControls.UIButton
    'Friend WithEvents Plaza As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientesFiltroSAP))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ubAceptar = New Janus.Windows.EditControls.UIButton()
        Me.ebCriterio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.rbApellidoMaterno = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbNombre = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbApellidoPaterno = New Janus.Windows.EditControls.UIRadioButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.ubAceptar)
        Me.ExplorerBar1.Controls.Add(Me.ebCriterio)
        Me.ExplorerBar1.Controls.Add(Me.rbApellidoMaterno)
        Me.ExplorerBar1.Controls.Add(Me.rbNombre)
        Me.ExplorerBar1.Controls.Add(Me.rbApellidoPaterno)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Paso 1.- Seleccione Criterio para Filtrar:"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(-2, -3)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(451, 219)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "Seleccione Criterio para Filtrar:"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ubAceptar
        '
        Me.ubAceptar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubAceptar.Image = CType(resources.GetObject("ubAceptar.Image"), System.Drawing.Image)
        Me.ubAceptar.Location = New System.Drawing.Point(287, 120)
        Me.ubAceptar.Name = "ubAceptar"
        Me.ubAceptar.Size = New System.Drawing.Size(128, 24)
        Me.ubAceptar.TabIndex = 5
        Me.ubAceptar.Text = "&Buscar"
        Me.ubAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebCriterio
        '
        Me.ebCriterio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCriterio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCriterio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCriterio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCriterio.Location = New System.Drawing.Point(24, 72)
        Me.ebCriterio.Name = "ebCriterio"
        Me.ebCriterio.Size = New System.Drawing.Size(392, 22)
        Me.ebCriterio.TabIndex = 3
        Me.ebCriterio.Text = "Introduzca la palabra a buscar aquí..."
        Me.ebCriterio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCriterio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'rbApellidoMaterno
        '
        Me.rbApellidoMaterno.BackColor = System.Drawing.Color.Transparent
        Me.rbApellidoMaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbApellidoMaterno.Location = New System.Drawing.Point(272, 40)
        Me.rbApellidoMaterno.Name = "rbApellidoMaterno"
        Me.rbApellidoMaterno.Size = New System.Drawing.Size(136, 24)
        Me.rbApellidoMaterno.TabIndex = 2
        Me.rbApellidoMaterno.Text = "Apellido Materno"
        Me.rbApellidoMaterno.Visible = False
        Me.rbApellidoMaterno.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbNombre
        '
        Me.rbNombre.BackColor = System.Drawing.Color.Transparent
        Me.rbNombre.Checked = True
        Me.rbNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNombre.Location = New System.Drawing.Point(24, 40)
        Me.rbNombre.Name = "rbNombre"
        Me.rbNombre.Size = New System.Drawing.Size(80, 24)
        Me.rbNombre.TabIndex = 0
        Me.rbNombre.TabStop = True
        Me.rbNombre.Text = "Nombre"
        Me.rbNombre.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbApellidoPaterno
        '
        Me.rbApellidoPaterno.BackColor = System.Drawing.Color.Transparent
        Me.rbApellidoPaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbApellidoPaterno.Location = New System.Drawing.Point(120, 40)
        Me.rbApellidoPaterno.Name = "rbApellidoPaterno"
        Me.rbApellidoPaterno.Size = New System.Drawing.Size(136, 24)
        Me.rbApellidoPaterno.TabIndex = 1
        Me.rbApellidoPaterno.Text = "Apellido"
        Me.rbApellidoPaterno.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'FrmClientesFiltroSAP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 158)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(464, 232)
        Me.MinimizeBox = False
        Me.Name = "FrmClientesFiltroSAP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtro para la Busqueda de Clientes"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



#Region "Member Variables"


#End Region



#Region "Properties"

    Private strCriterio As String
    Private m_Tipo As Integer
    Private m_TipoVenta As String

    Public Property Criterio() As String
        Get
            Return strCriterio
        End Get
        Set(ByVal Value As String)
            strCriterio = Value
        End Set
    End Property

    Public Property Tipo As Integer
        Get
            Return m_Tipo
        End Get
        Set(value As Integer)
            m_Tipo = value
        End Set
    End Property

    Public Property TipoVenta As String
        Get
            Return m_TipoVenta
        End Get
        Set(value As String)
            m_TipoVenta = value
        End Set
    End Property

#End Region



#Region "Private Methods"

    Private Sub Sm_Initialize()

        Criterio = String.Empty

    End Sub


    Private Function Fm_bolTxtValidar() As Boolean

        If (ebCriterio.Text = "Introduzca la palabra a buscar aquí...") Then

            MsgBox("Por Favor Introduzca una palabra para buscar", MsgBoxStyle.Exclamation, "DPTienda")
            ebCriterio.Focus()

            Exit Function

        End If


        Return True

    End Function


    Private Sub Sm_SelFilter()

        If (Fm_bolTxtValidar() = False) Then

            Exit Sub

        End If


        If (rbNombre.Checked = True) Then

            strCriterio = ebCriterio.Text.Trim
            m_Tipo = 1

        End If


        If (rbApellidoPaterno.Checked = True) Then

            strCriterio = ebCriterio.Text.Trim
            m_Tipo = 2

        End If


        If (rbApellidoMaterno.Checked = True) Then

            strCriterio = ebCriterio.Text.Trim
            m_Tipo = 3

        End If


        Me.DialogResult = DialogResult.OK

    End Sub

#End Region



#Region "Public Methods [Events]"

    Private Sub FrmClientesFiltroSAP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Initialize()

    End Sub



    Private Sub FrmClientesFiltroSAP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")


            Case Keys.Escape

                Me.Close()

        End Select

    End Sub



    Private Sub ubAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubAceptar.Click

        If Me.ebCriterio.Text.Trim <> String.Empty Then

            Sm_SelFilter()

        Else

            MessageBox.Show("No puede ir vacio", "Falta Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.ebCriterio.Focus()

        End If

    End Sub


    Private Sub rbNombre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbNombre.Click

        ebCriterio.Focus()

    End Sub



    Private Sub rbApellidoPaterno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbApellidoPaterno.Click

        ebCriterio.Focus()

    End Sub



    Private Sub rbApellidoMaterno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbApellidoMaterno.Click

        ebCriterio.Focus()

    End Sub

#End Region

End Class
