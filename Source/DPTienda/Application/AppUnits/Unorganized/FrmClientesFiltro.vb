
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoPlazas


Public Class FrmClientesFiltro
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
    Friend WithEvents cmPlaza As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    'Friend WithEvents Plaza As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientesFiltro))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ubAceptar = New Janus.Windows.EditControls.UIButton()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmPlaza = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebCriterio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.rbApellidoMaterno = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbNombre = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbApellidoPaterno = New Janus.Windows.EditControls.UIRadioButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.ubAceptar)
        Me.ExplorerBar1.Controls.Add(Me.ExplorerBar2)
        Me.ExplorerBar1.Controls.Add(Me.ebCriterio)
        Me.ExplorerBar1.Controls.Add(Me.rbApellidoMaterno)
        Me.ExplorerBar1.Controls.Add(Me.rbNombre)
        Me.ExplorerBar1.Controls.Add(Me.rbApellidoPaterno)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Paso 1.- Seleccione Criterio para Filtrar:"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar1.Location = New System.Drawing.Point(-2, -3)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(466, 219)
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
        'ExplorerBar2
        '
        Me.ExplorerBar2.BlendColor = System.Drawing.Color.Transparent
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.Label1)
        Me.ExplorerBar2.Controls.Add(Me.cmPlaza)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.StateStyles.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Text = "Paso 2.- Seleccione la Plaza donde se hara la Busqueda:"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar2.Location = New System.Drawing.Point(-2, 112)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(464, 344)
        Me.ExplorerBar2.TabIndex = 6
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.Visible = False
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(32, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Plaza:"
        '
        'cmPlaza
        '
        Me.cmPlaza.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmPlaza.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmPlaza.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmPlaza.DesignTimeLayout = GridEXLayout1
        Me.cmPlaza.DisplayMember = "Descripcion"
        Me.cmPlaza.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmPlaza.Location = New System.Drawing.Point(88, 51)
        Me.cmPlaza.Name = "cmPlaza"
        Me.cmPlaza.Size = New System.Drawing.Size(192, 22)
        Me.cmPlaza.TabIndex = 4
        Me.cmPlaza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmPlaza.ValueMember = "CodPlaza"
        Me.cmPlaza.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
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
        'FrmClientesFiltro
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 158)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(464, 232)
        Me.MinimizeBox = False
        Me.Name = "FrmClientesFiltro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtro para la Busqueda de Clientes"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



#Region "Member Variables"

    Private oCatalogoPlazaMgr As New CatalogoPlazasManager(oAppContext)

    Private dsPlazas As DataSet

    'Private oPlaza As Plaza

#End Region



#Region "Properties"

    Private strCodPlaza As String

    Public Property Plaza() As String
        Get
            Return strCodPlaza
        End Get
        Set(ByVal Value As String)
            strCodPlaza = Value
        End Set
    End Property


    Private strSelCriterio As String

    Public Property SelCriterio() As String
        Get
            Return strSelCriterio
        End Get
        Set(ByVal Value As String)
            strSelCriterio = Value
        End Set
    End Property


    Private strCriterio As String

    Public Property Criterio() As String
        Get
            Return strCriterio
        End Get
        Set(ByVal Value As String)
            strCriterio = Value
        End Set
    End Property

#End Region



#Region "Private Methods"

    Private Sub Sm_Initialize()

        'strSelCriterio = "N"

        strCodPlaza = String.Empty
        strSelCriterio = String.Empty
        strCriterio = String.Empty

        Sm_FillcbPlaza()

        cmPlaza.Value = "MZT"

    End Sub



    Private Sub Sm_Finalize()

        dsPlazas.Dispose()
        dsPlazas = Nothing

    End Sub



    Private Sub Sm_FillcbPlaza()

        dsPlazas = oCatalogoPlazaMgr.GetAll(False)

        cmPlaza.SetDataBinding(dsPlazas, "CatalogoPlazas")

    End Sub



    Private Function Fm_bolTxtValidar() As Boolean

        If (ebCriterio.Text = "Introduzca la palabra a buscar aquí...") Then

            MsgBox("Por Favor Introduzca una palabra para buscar", MsgBoxStyle.Exclamation, "DPTienda")
            ebCriterio.Focus()

            Exit Function

        End If


        If (cmPlaza.Value = String.Empty) Then

            MsgBox("No se ha seleccionado una Plaza.", MsgBoxStyle.Exclamation, "DPTienda")
            cmPlaza.Focus()

            Exit Function

        End If


        Return True

    End Function


    Private Sub Sm_SelFilter()

        If (Fm_bolTxtValidar() = False) Then

            Exit Sub

        End If


        If (rbNombre.Checked = True) Then

            strSelCriterio = "N"
            strCriterio = ebCriterio.Text.Trim

        End If


        If (rbApellidoPaterno.Checked = True) Then

            strSelCriterio = "P"
            strCriterio = ebCriterio.Text.Trim

        End If


        If (rbApellidoMaterno.Checked = True) Then

            strSelCriterio = "M"
            strCriterio = ebCriterio.Text.Trim

        End If


        'If (rbPlaza.Checked = True) Then

        strCodPlaza = cmPlaza.Value

        'End If


        Me.DialogResult = DialogResult.OK

    End Sub

#End Region



#Region "Public Methods [Events]"

    Private Sub FrmClientesFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Initialize()

    End Sub



    Private Sub FrmClientesFiltro_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_Finalize()

    End Sub



    Private Sub FrmClientesFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")


            Case Keys.Escape

                Me.Close()

        End Select

    End Sub



    Private Sub ubAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubAceptar.Click

        Sm_SelFilter()

    End Sub



    Private Sub ebCriterio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCriterio.Validating

        'If (ebCriterio.Text.Trim = String.Empty) Then

        '    MsgBox("No ha sido indicado el Filtro de la Busqueda.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebCriterio.Focus()

        '    e.Cancel = True

        'End If

    End Sub



    Private Sub cmPlaza_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmPlaza.Validating

        If (cmPlaza.Value = String.Empty) Then

            MsgBox("No se ha seleccionado una Plaza.", MsgBoxStyle.Exclamation, "DPTienda")
            cmPlaza.Focus()

            e.Cancel = True

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
