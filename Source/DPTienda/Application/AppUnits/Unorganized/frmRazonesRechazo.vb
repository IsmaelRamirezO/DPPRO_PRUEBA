Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class frmRazonesRechazo
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Inicializar()
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
    Friend WithEvents cmbRazones As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblRazon As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebTexto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRazonesRechazo))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.ebTexto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.cmbRazones = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblRazon = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel1)
        Me.ExplorerBar1.Controls.Add(Me.ebTexto)
        Me.ExplorerBar1.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar1.Controls.Add(Me.cmbRazones)
        Me.ExplorerBar1.Controls.Add(Me.lblRazon)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(490, 168)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Icon = CType(resources.GetObject("btnCancelar.Icon"), System.Drawing.Icon)
        Me.btnCancelar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnCancelar.Location = New System.Drawing.Point(264, 112)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(216, 40)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(8, 8)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(384, 16)
        Me.lblLabel1.TabIndex = 4
        Me.lblLabel1.Text = "Seleccione una razón por la que no se registró al cliente"
        '
        'ebTexto
        '
        Me.ebTexto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTexto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTexto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTexto.Location = New System.Drawing.Point(344, 72)
        Me.ebTexto.Name = "ebTexto"
        Me.ebTexto.Size = New System.Drawing.Size(136, 23)
        Me.ebTexto.TabIndex = 2
        Me.ebTexto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTexto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnAceptar.Location = New System.Drawing.Point(8, 112)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(216, 40)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cmbRazones
        '
        Me.cmbRazones.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbRazones.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbRazones.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbRazones.DesignTimeLayout = GridEXLayout1
        Me.cmbRazones.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRazones.Location = New System.Drawing.Point(8, 32)
        Me.cmbRazones.Name = "cmbRazones"
        Me.cmbRazones.Size = New System.Drawing.Size(472, 23)
        Me.cmbRazones.TabIndex = 1
        Me.cmbRazones.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbRazones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblRazon
        '
        Me.lblRazon.BackColor = System.Drawing.Color.Transparent
        Me.lblRazon.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazon.Location = New System.Drawing.Point(8, 72)
        Me.lblRazon.Name = "lblRazon"
        Me.lblRazon.Size = New System.Drawing.Size(384, 32)
        Me.lblRazon.TabIndex = 2
        Me.lblRazon.Text = "Teclea el siguiente texto para continuar ""SIN REGISTRO"""
        '
        'frmRazonesRechazo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(490, 168)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmRazonesRechazo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Razones de Rechazo"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oFacturasMgr As FacturaManager
    Public ModuloOrigen As String = ""

    Private Sub Inicializar()

        oFacturasMgr = New FacturaManager(oAppContext, oConfigCierreFI)

    End Sub

    Private Sub LlenarComboRazones()

        Dim bRes As Boolean = False
        Dim dtTemp As DataTable

        dtTemp = oFacturasMgr.GetRazonesRechazo(bRes, ModuloOrigen)

        'Dim dtTemp As DataTable = oRepMgr.GetOficinasVtas
        'Dim oRow As DataRow = dtTemp.NewRow

        'oRow!OficinaVtas = ""
        'oRow!Descripcion = "TODAS"
        'dtTemp.Rows.Add(oRow)
        'dtTemp.AcceptChanges()
        If bRes Then
            With Me.cmbRazones
                .DataSource = dtTemp
                .DropDownList.Columns.Add("Cod")
                .DropDownList.Columns.Add("Descripcion")
                .DropDownList.Columns("Cod").DataMember = "RazonRechazoID"
                .DropDownList.Columns("Cod").Width = 50
                .DropDownList.Columns("Descripcion").DataMember = "Razon"
                .DropDownList.Columns("Descripcion").Width = 450
                .DropDownList.Columns("Cod").Visible = False
                .DisplayMember = "Razon"
                .ValueMember = "RazonRechazoID"
                .Refresh()
            End With
        End If

        dtTemp = Nothing

    End Sub

    Private Sub frmRazonesRechazo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarComboRazones()
    End Sub

    Private Sub ebTexto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTexto.Validating
        If Me.ebTexto.Text.Trim <> "" Then
            If Me.ebTexto.Text <> "Sin Registro".ToUpper Then
                MessageBox.Show("Verifique el texto escrito, no coincide", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebTexto.Focus()
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.cmbRazones.Text.Trim = "" Then
            MessageBox.Show("Es necesario seleccionar una razon de rechazo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbRazones.Focus()
        ElseIf Me.ebTexto.Text.Trim = "" Then
            MessageBox.Show("Es necesario teclear el Texto especificado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebTexto.Focus()
        Else
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub frmRazonesRechazo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class
