Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class frmValeEmpleado
    Inherits System.Windows.Forms.Form

    Dim oSAPMgr As ProcesoSAPManager
    Dim ValeE As ValeEmpleado
    Dim oFacturaMgr As FacturaManager

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oFacturaMgr = New FacturaManager(oAppContext)
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebSerie As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nebNoFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents rbValeEmpleado As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbAutorizacion As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents nebDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.nebDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.ebSerie = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.nebNoFolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.rbValeEmpleado = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbAutorizacion = New Janus.Windows.EditControls.UIRadioButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.nebDescuento)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.ebSerie)
        Me.ExplorerBar1.Controls.Add(Me.nebNoFolio)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar1.Controls.Add(Me.rbValeEmpleado)
        Me.ExplorerBar1.Controls.Add(Me.rbAutorizacion)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Arial", 9.75!)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Vale de Empleado"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(314, 184)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'nebDescuento
        '
        Me.nebDescuento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDescuento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDescuento.BackColor = System.Drawing.Color.LemonChiffon
        Me.nebDescuento.ControlStyle.ControlColor = System.Drawing.SystemColors.Window
        Me.nebDescuento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDescuento.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent
        Me.nebDescuento.Location = New System.Drawing.Point(168, 104)
        Me.nebDescuento.MaxLength = 8
        Me.nebDescuento.Name = "nebDescuento"
        Me.nebDescuento.ReadOnly = True
        Me.nebDescuento.Size = New System.Drawing.Size(128, 22)
        Me.nebDescuento.TabIndex = 4
        Me.nebDescuento.Text = "0.00 %"
        Me.nebDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nebDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = "0"
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Descuento:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(200, 144)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(96, 32)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebSerie
        '
        Me.ebSerie.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSerie.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebSerie.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSerie.Location = New System.Drawing.Point(168, 72)
        Me.ebSerie.MaxLength = 2
        Me.ebSerie.Multiline = True
        Me.ebSerie.Name = "ebSerie"
        Me.ebSerie.Size = New System.Drawing.Size(128, 22)
        Me.ebSerie.TabIndex = 3
        Me.ebSerie.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSerie.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nebNoFolio
        '
        Me.nebNoFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebNoFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebNoFolio.ControlStyle.ControlColor = System.Drawing.SystemColors.Window
        Me.nebNoFolio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebNoFolio.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebNoFolio.Location = New System.Drawing.Point(168, 40)
        Me.nebNoFolio.MaxLength = 8
        Me.nebNoFolio.Name = "nebNoFolio"
        Me.nebNoFolio.Size = New System.Drawing.Size(128, 22)
        Me.nebNoFolio.TabIndex = 2
        Me.nebNoFolio.Text = "0"
        Me.nebNoFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nebNoFolio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebNoFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = "0"
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "No. Folio:"
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = "0"
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Serie:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(16, 144)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(96, 32)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbValeEmpleado
        '
        Me.rbValeEmpleado.BackColor = System.Drawing.Color.Transparent
        Me.rbValeEmpleado.Checked = True
        Me.rbValeEmpleado.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbValeEmpleado.Location = New System.Drawing.Point(16, 40)
        Me.rbValeEmpleado.Name = "rbValeEmpleado"
        Me.rbValeEmpleado.Size = New System.Drawing.Size(120, 23)
        Me.rbValeEmpleado.TabIndex = 0
        Me.rbValeEmpleado.TabStop = True
        Me.rbValeEmpleado.Text = "Vale Empleado"
        Me.rbValeEmpleado.Visible = False
        Me.rbValeEmpleado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'rbAutorizacion
        '
        Me.rbAutorizacion.BackColor = System.Drawing.Color.Transparent
        Me.rbAutorizacion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAutorizacion.Location = New System.Drawing.Point(168, 40)
        Me.rbAutorizacion.Name = "rbAutorizacion"
        Me.rbAutorizacion.Size = New System.Drawing.Size(152, 23)
        Me.rbAutorizacion.TabIndex = 1
        Me.rbAutorizacion.Text = "Por Autorización"
        Me.rbAutorizacion.Visible = False
        Me.rbAutorizacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'frmValeEmpleado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(314, 184)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmValeEmpleado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Valida Descuento"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propiedades"

    Public Property ValeEmpleado() As ValeEmpleado
        Get
            Return ValeE
        End Get
        Set(ByVal Value As ValeEmpleado)
            ValeE = Value
        End Set
    End Property

#End Region

    Private Sub ModificaCampos()

        If Me.rbAutorizacion.Checked = True Then
            Me.nebNoFolio.ReadOnly = True
            Me.ebSerie.ReadOnly = True
            Me.nebDescuento.ReadOnly = False
            Me.nebNoFolio.BackColor = Color.LemonChiffon
            Me.ebSerie.BackColor = Color.LemonChiffon
            Me.nebDescuento.BackColor = Color.White
            Me.nebNoFolio.Value = 0
            Me.ebSerie.Text = ""
            Me.nebDescuento.Focus()
        Else
            Me.nebNoFolio.ReadOnly = False
            Me.ebSerie.ReadOnly = False
            Me.nebDescuento.ReadOnly = True
            Me.nebNoFolio.BackColor = Color.White
            Me.ebSerie.BackColor = Color.White
            Me.nebDescuento.Value = 0
            Me.nebDescuento.BackColor = Color.LemonChiffon
            Me.nebDescuento.Value = 0
            Me.nebNoFolio.Focus()
        End If

    End Sub

    Private Function ValidaCampos() As Boolean

        If Me.rbValeEmpleado.Checked Then
            If Me.nebNoFolio.Value <= 0 Then
                MessageBox.Show("El folio del vale es incorrecto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.nebNoFolio.Focus()
                Return False
            ElseIf Me.ebSerie.Text = "" Then
                MessageBox.Show("Es necesario especificar la serie.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebSerie.Focus()
                Return False
            End If
            Return True
        ElseIf Me.nebDescuento.Value <= 0 Then
            MessageBox.Show("Es necesario especificar el porcentaje de descuento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebDescuento.Focus()
            Return False
        ElseIf Me.nebDescuento.Value > 40 Then
            MessageBox.Show("El descuento debe ser menor o igual al 40%.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebDescuento.Focus()
            Return False
        Else
            Return True
        End If

    End Function

    Private Function ValidaValeEmpleado() As Boolean

        If Me.nebNoFolio.Value > 0 AndAlso Me.ebSerie.Text <> "" Then

            ValeE = New ValeEmpleado
            ValeE.Folio = Me.nebNoFolio.Value
            ValeE.Serie = Me.ebSerie.Text
            Dim proceso As New ProcesosRetail("/pos/empleados", "POST")
            ValeE = proceso.SapZbapiConsultaDescto(ValeE)
            'ValeE = oSAPMgr.ZBAPI_VALIDA_VALE_EMPLEADO(ValeE)

            Dim Usado As Boolean = False
            Dim Referencia As String = ""

            Usado = oFacturaMgr.EstaValeEmpleadoUsado(ValeE.Folio, ValeE.Serie, Referencia)

            'If Not Usado AndAlso ValeE.Status = "0" Then
            If Usado AndAlso ValeE.Status <> "1" Then
                proceso = New ProcesosRetail("/pos/empleados", "POST")
                proceso.ZbapiQuemaVALEmpleado(ValeE.Folio, ValeE.Serie, Referencia)
                'oSAPMgr.ZBAPI_QUEMA_VALE_EMPLEADO(ValeE.Folio, ValeE.Serie, FolioSAP)
            End If

            If ValeE.Status = "0" Then
                Me.nebDescuento.Value = ValeE.Descuento
                Return True
            ElseIf ValeE.Status = "2" Then
                MessageBox.Show("El vale especificado ha sido eliminado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.nebNoFolio.Focus()
                Return False
            ElseIf ValeE.Status = "3" Then
                MessageBox.Show("El vale especificado no existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.nebNoFolio.Focus()
                Return False
            ElseIf ValeE.Status = "1" Then
                MessageBox.Show("El vale ya ha sido utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.nebNoFolio.Focus()
                Return False
            ElseIf ValeE.Status = "4" Then
                MessageBox.Show("El vale ya ha expirado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.nebNoFolio.Focus()
                Return False
            End If

        End If

    End Function

    Private Sub rbAutorizacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAutorizacion.CheckedChanged, rbValeEmpleado.CheckedChanged

        ModificaCampos()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Me.DialogResult = DialogResult.Cancel

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If ValidaCampos() AndAlso (Me.rbAutorizacion.Checked OrElse (Me.rbValeEmpleado.Checked AndAlso ValidaValeEmpleado())) Then

            Me.DialogResult = DialogResult.OK
            Me.Close()

        End If

    End Sub

    Private Sub frmValeEmpleado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.rbValeEmpleado.Checked = True

    End Sub

    Private Sub nebNoFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nebNoFolio.KeyDown, ebSerie.KeyDown, nebDescuento.KeyDown

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub ebSerie_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebSerie.Validating

        ValidaValeEmpleado()

    End Sub

End Class
