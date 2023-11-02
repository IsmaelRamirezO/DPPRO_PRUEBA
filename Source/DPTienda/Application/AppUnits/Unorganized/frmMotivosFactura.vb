Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class frmMotivosFactura
    Inherits System.Windows.Forms.Form

    Private m_strTienda As String

    Private m_strTalla As String

    Private m_strArticulo As String

    Private m_datMotivos As DataTable

    Public Tipo As String = ""

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
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ebMotivo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMotivosFactura))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebMotivo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.ebMotivo)
        Me.ExplorerBar1.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.ContainerHeight = 100
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Motivo de la Captura Manual"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(472, 149)
        Me.ExplorerBar1.TabIndex = 2
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebMotivo
        '
        Me.ebMotivo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMotivo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMotivo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.ebMotivo.DesignTimeLayout = GridEXLayout1
        Me.ebMotivo.Location = New System.Drawing.Point(88, 49)
        Me.ebMotivo.MaxLength = 150
        Me.ebMotivo.Name = "ebMotivo"
        Me.ebMotivo.Size = New System.Drawing.Size(344, 20)
        Me.ebMotivo.TabIndex = 0
        Me.ebMotivo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(176, 88)
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
        Me.Label6.Size = New System.Drawing.Size(56, 23)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Motivo:"
        '
        'frmMotivosFactura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(472, 149)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmMotivosFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Motivos de Captura Manual"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propiedades"
    Public Property Motivos() As DataTable
        Get
            Return m_datMotivos
        End Get
        Set(ByVal Value As DataTable)
            m_datMotivos = Value
        End Set
    End Property

    Public Property Articulo() As String
        Get
            Return m_strArticulo
        End Get
        Set(ByVal Value As String)
            m_strArticulo = Value
        End Set
    End Property

    Public Property Talla() As String
        Get
            Return m_strTalla
        End Get
        Set(ByVal Value As String)
            m_strTalla = Value
        End Set
    End Property
    Public Property Tienda() As String
        Get
            Return m_strTienda
        End Get
        Set(ByVal Value As String)
            m_strTienda = Value
        End Set
    End Property
#End Region

    Private Sub frmMotivosFactura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cargar los motivos en el Combo
        Cargar()
        ebMotivo.Focus()
        If ebMotivo.Focused = False Then
            ebMotivo.Focus()
            ebMotivo.SelectAll()
        End If
    End Sub

    'Private Sub Cargar()
    '    Dim oFacturaMgr As New FacturaManager(oAppContext)
    '    Dim dsMotivos As DataSet
    '    dsMotivos = New DataSet
    '    dsMotivos = oFacturaMgr.Getmotivos()
    '    Me.ebMotivo.DataSource = dsMotivos
    '    Me.ebMotivo.DataMember = dsMotivos.Tables(0).TableName
    '    Me.ebMotivo.DisplayMember = "Descripcion"
    '    Me.ebMotivo.ValueMember = "IdMotivos"

    'End Sub

    Private Sub Cargar()
        Dim oFacturaMgr As New FacturaManager(oAppContext)
        Dim dsMotivos As DataSet

        Select Case Tipo.Trim.ToUpper
            Case "Faltantes".ToUpper
                Me.ebMotivo.DataSource = Motivos
                Me.ExplorerBar1.Groups(0).Text = "Selecciona el motivo de aplicación de faltantes"
                Me.Text = "Selección de motivos"
            Case Else
                dsMotivos = New DataSet
                dsMotivos = oFacturaMgr.Getmotivos()
                Me.ebMotivo.DataSource = dsMotivos
                Me.ebMotivo.DataMember = dsMotivos.Tables(0).TableName
        End Select
        Me.ebMotivo.DisplayMember = "Descripcion"
        Me.ebMotivo.ValueMember = "IdMotivos"
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim strMsg As String = ""

        Select Case Tipo.Trim.ToUpper
            Case "Faltantes".ToUpper
                If Me.ebMotivo.Text = "" OrElse Me.ebMotivo.Value <= 0 Then
                    strMsg = "Seleccione un motivo por el cuál aplicó un traspaso de entrada con faltantes"
                    MsgBox(strMsg, MsgBoxStyle.Exclamation, Me.Text)
                End If

                If strMsg.Trim <> "" Then Exit Sub

                Me.DialogResult = DialogResult.OK

            Case Else
                If Me.ebMotivo.Text = String.Empty OrElse Me.ebMotivo.Value = Nothing Then
                    strMsg = "¡Seleccione un motivo de captura manual!"
                    MsgBox(strMsg, MsgBoxStyle.Exclamation, Me.Text)
                End If
                'If Me.ebMotivo.Value = Nothing Then
                '    MsgBox("¡Seleccione un motivo de captura manual!", MsgBoxStyle.Information, Me.Text)
                '    Exit Sub
                'End If

                If strMsg.Trim <> "" Then Exit Sub

                Dim oview As New DataView(m_datMotivos, "Articulo = '" & Articulo & "' and Talla = '" & Talla & "'", "Articulo", DataViewRowState.CurrentRows)
                If oview.Count > 0 Then
                    For Each orow As DataRowView In oview
                        orow("IdMotivo") = Me.ebMotivo.Value
                    Next

                    m_datMotivos.AcceptChanges()
                Else
                    Dim oDatarow As DataRow = m_datMotivos.NewRow

                    oDatarow("Tienda") = Tienda
                    oDatarow("Articulo") = Articulo
                    'oDatarow("Talla") = Talla
                    oDatarow("IdMotivo") = Me.ebMotivo.Value
                    oDatarow("Fecha") = Now.Date.ToShortDateString

                    m_datMotivos.Rows.Add(oDatarow)
                    m_datMotivos.AcceptChanges()

                End If

                Me.Close()
        End Select

    End Sub

    Private Sub ebMotivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebMotivo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class
