Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Public Class frmAutorizacionFacilito

    Inherits System.Windows.Forms.Form

    Dim strNumeroAutorizacion As String
    Dim strClienteId As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal oNumAutoriza As String)
        MyBase.New()

        strNumeroAutorizacion = oNumAutoriza

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
    Friend WithEvents explorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel3 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel5 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtNumeroAutorizacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtApellidos As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutorizacionFacilito))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.txtApellidos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel3 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.explorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.txtNumeroAutorizacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel5 = New System.Windows.Forms.Label()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.explorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar2.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.txtApellidos)
        Me.explorerBar1.Controls.Add(Me.txtNombre)
        Me.explorerBar1.Controls.Add(Me.txtCodigo)
        Me.explorerBar1.Controls.Add(Me.lblLabel3)
        Me.explorerBar1.Controls.Add(Me.lblLabel2)
        Me.explorerBar1.Controls.Add(Me.lblLabel1)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos del Cliente"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(-8, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(488, 176)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'txtApellidos
        '
        Me.txtApellidos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtApellidos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtApellidos.BackColor = System.Drawing.SystemColors.Info
        Me.txtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellidos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApellidos.Location = New System.Drawing.Point(88, 96)
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.ReadOnly = True
        Me.txtApellidos.Size = New System.Drawing.Size(272, 22)
        Me.txtApellidos.TabIndex = 8
        Me.txtApellidos.TabStop = False
        Me.txtApellidos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtApellidos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtNombre
        '
        Me.txtNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(88, 65)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(272, 22)
        Me.txtNombre.TabIndex = 7
        Me.txtNombre.TabStop = False
        Me.txtNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtCodigo
        '
        Me.txtCodigo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCodigo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(88, 36)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(152, 22)
        Me.txtCodigo.TabIndex = 6
        Me.txtCodigo.TabStop = False
        Me.txtCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel3
        '
        Me.lblLabel3.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel3.Location = New System.Drawing.Point(32, 100)
        Me.lblLabel3.Name = "lblLabel3"
        Me.lblLabel3.Size = New System.Drawing.Size(112, 23)
        Me.lblLabel3.TabIndex = 4
        Me.lblLabel3.Text = "Apellidos"
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.Location = New System.Drawing.Point(32, 69)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(64, 23)
        Me.lblLabel2.TabIndex = 3
        Me.lblLabel2.Text = "Nombre"
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(32, 40)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(64, 23)
        Me.lblLabel1.TabIndex = 2
        Me.lblLabel1.Text = "Código"
        '
        'explorerBar2
        '
        Me.explorerBar2.Controls.Add(Me.txtNumeroAutorizacion)
        Me.explorerBar2.Controls.Add(Me.lblLabel5)
        Me.explorerBar2.Controls.Add(Me.btnCancelar)
        Me.explorerBar2.Controls.Add(Me.btnAceptar)
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Expanded = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Autorización"
        Me.explorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.explorerBar2.Location = New System.Drawing.Point(-8, 136)
        Me.explorerBar2.Name = "explorerBar2"
        Me.explorerBar2.Size = New System.Drawing.Size(488, 158)
        Me.explorerBar2.TabIndex = 1
        Me.explorerBar2.Text = "ExplorerBar1"
        Me.explorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'txtNumeroAutorizacion
        '
        Me.txtNumeroAutorizacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNumeroAutorizacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNumeroAutorizacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroAutorizacion.Location = New System.Drawing.Point(88, 40)
        Me.txtNumeroAutorizacion.MaxLength = 30
        Me.txtNumeroAutorizacion.Name = "txtNumeroAutorizacion"
        Me.txtNumeroAutorizacion.Size = New System.Drawing.Size(272, 22)
        Me.txtNumeroAutorizacion.TabIndex = 0
        Me.txtNumeroAutorizacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNumeroAutorizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel5.Location = New System.Drawing.Point(27, 44)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(64, 23)
        Me.lblLabel5.TabIndex = 3
        Me.lblLabel5.Text = "Número :"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(240, 96)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(115, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(88, 96)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(123, 32)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmAutorizacionFacilito
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(370, 285)
        Me.Controls.Add(Me.explorerBar2)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutorizacionFacilito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Venta FACILITO"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.explorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAutorizacionFacilito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape

                Me.DialogResult = DialogResult.Cancel

            Case Keys.Enter

                SendKeys.Send("{TAB}")

        End Select

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Me.DialogResult = DialogResult.Cancel

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If txtNumeroAutorizacion.Text = String.Empty Then

            MsgBox("Ingrese Numero de Autorización Facilito. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
            txtNumeroAutorizacion.Focus()

        Else

            Me.DialogResult = DialogResult.OK

        End If

    End Sub

    Public Sub ShowMeByFactura(ByVal intClienteID As Integer)

        strClienteId = CStr(intClienteID).PadLeft(10, "0")

        Me.ShowDialog()

    End Sub

    Private Sub frmAutorizacionFacilito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oClienteMgr As ClientesManager
        Dim oClienteFacilito As ClienteAlterno

        oClienteMgr = New ClientesManager(oAppContext)
        oClienteFacilito = oClienteMgr.CreateAlterno
        oClienteFacilito.Clear()

        oClienteMgr.Load(strClienteId, oClienteFacilito, "O")

        With oClienteFacilito
            txtCodigo.Text = .CodigoAlterno
            txtNombre.Text = .Nombre
            txtApellidos.Text = .ApellidoPaterno.Trim & " " & .ApellidoMaterno.Trim
            txtNumeroAutorizacion.Text = strNumeroAutorizacion
        End With

        oClienteFacilito = Nothing
        oClienteMgr = Nothing

    End Sub

End Class
