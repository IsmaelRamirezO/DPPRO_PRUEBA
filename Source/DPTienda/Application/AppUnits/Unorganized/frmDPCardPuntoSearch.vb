Public Class frmDPCardPuntoSearch
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
    Friend WithEvents explorerSeach As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblApellidoPaterno As System.Windows.Forms.Label
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnSearch As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtPaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents gridTarjetas As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDPCardPuntoSearch))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.explorerSeach = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.gridTarjetas = New Janus.Windows.GridEX.GridEX()
        Me.txtTelefono = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnSearch = New Janus.Windows.EditControls.UIButton()
        Me.txtPaterno = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.lblApellidoPaterno = New System.Windows.Forms.Label()
        CType(Me.explorerSeach, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerSeach.SuspendLayout()
        CType(Me.gridTarjetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'explorerSeach
        '
        Me.explorerSeach.Controls.Add(Me.btnCancelar)
        Me.explorerSeach.Controls.Add(Me.btnAceptar)
        Me.explorerSeach.Controls.Add(Me.gridTarjetas)
        Me.explorerSeach.Controls.Add(Me.txtTelefono)
        Me.explorerSeach.Controls.Add(Me.btnSearch)
        Me.explorerSeach.Controls.Add(Me.txtPaterno)
        Me.explorerSeach.Controls.Add(Me.lblTelefono)
        Me.explorerSeach.Controls.Add(Me.lblApellidoPaterno)
        Me.explorerSeach.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "grpSearch"
        ExplorerBarGroup1.Text = "Busqueda por apellido paterno y telefono"
        Me.explorerSeach.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerSeach.Location = New System.Drawing.Point(0, 0)
        Me.explorerSeach.Name = "explorerSeach"
        Me.explorerSeach.Size = New System.Drawing.Size(392, 326)
        Me.explorerSeach.TabIndex = 0
        Me.explorerSeach.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(304, 296)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 24)
        Me.btnCancelar.TabIndex = 248
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.Location = New System.Drawing.Point(224, 296)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 24)
        Me.btnAceptar.TabIndex = 247
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'gridTarjetas
        '
        Me.gridTarjetas.AllowCardSizing = False
        Me.gridTarjetas.AllowColumnDrag = False
        Me.gridTarjetas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridTarjetas.DesignTimeLayout = GridEXLayout1
        Me.gridTarjetas.GroupByBoxVisible = False
        Me.gridTarjetas.Location = New System.Drawing.Point(8, 96)
        Me.gridTarjetas.Name = "gridTarjetas"
        Me.gridTarjetas.Size = New System.Drawing.Size(368, 192)
        Me.gridTarjetas.TabIndex = 246
        Me.gridTarjetas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtTelefono
        '
        Me.txtTelefono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTelefono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTelefono.BackColor = System.Drawing.SystemColors.Info
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(136, 69)
        Me.txtTelefono.MaxLength = 4
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(56, 21)
        Me.txtTelefono.TabIndex = 244
        Me.txtTelefono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtTelefono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(192, 69)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(32, 21)
        Me.btnSearch.TabIndex = 245
        Me.btnSearch.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtPaterno
        '
        Me.txtPaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPaterno.BackColor = System.Drawing.SystemColors.Info
        Me.txtPaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaterno.Location = New System.Drawing.Point(136, 45)
        Me.txtPaterno.Name = "txtPaterno"
        Me.txtPaterno.Size = New System.Drawing.Size(200, 21)
        Me.txtPaterno.TabIndex = 243
        Me.txtPaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.BackColor = System.Drawing.Color.Transparent
        Me.lblTelefono.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono.Location = New System.Drawing.Point(8, 69)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(68, 16)
        Me.lblTelefono.TabIndex = 242
        Me.lblTelefono.Text = "Telefono:"
        '
        'lblApellidoPaterno
        '
        Me.lblApellidoPaterno.AutoSize = True
        Me.lblApellidoPaterno.BackColor = System.Drawing.Color.Transparent
        Me.lblApellidoPaterno.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApellidoPaterno.Location = New System.Drawing.Point(8, 45)
        Me.lblApellidoPaterno.Name = "lblApellidoPaterno"
        Me.lblApellidoPaterno.Size = New System.Drawing.Size(120, 16)
        Me.lblApellidoPaterno.TabIndex = 224
        Me.lblApellidoPaterno.Text = "Apellido Paterno:"
        '
        'frmDPCardPuntoSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(392, 326)
        Me.Controls.Add(Me.explorerSeach)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDPCardPuntoSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda DPCard Puntos"
        CType(Me.explorerSeach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerSeach.ResumeLayout(False)
        Me.explorerSeach.PerformLayout()
        CType(Me.gridTarjetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private m_dtTarjetas As DataTable
    Private m_CardId As String
    Private accion As Boolean = False
#End Region

#Region "Propiedades"

    Public Property Tarjetas() As DataTable
        Get
            Return m_dtTarjetas
        End Get
        Set(ByVal Value As DataTable)
            m_dtTarjetas = Value
        End Set
    End Property

    Public Property CardId() As String
        Get
            Return m_CardId
        End Get
        Set(ByVal Value As String)
            m_CardId = Value
        End Set
    End Property

#End Region

#Region "Metodos"

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2015: Inicializa el grid con el schema de los datos a obtener
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub Inicializar()
        Me.Tarjetas = New DataTable
        Me.Tarjetas.Columns.Add("CardId", GetType(String))
        Me.Tarjetas.Columns.Add("Name", GetType(String))
        Me.Tarjetas.AcceptChanges()

        Me.gridTarjetas.DataSource = Me.Tarjetas

    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2015: Busqueda de tarjetas por medio del nombre y los ultimos digitos del telefono
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub SearchCards()
        Try
            If Me.txtPaterno.Text.Trim <> "" AndAlso Me.txtTelefono.Text <> "" Then
                Dim ws As New WSBroker("WS_BLUE", True)
                Dim resultado As New Hashtable
                Dim params As New Hashtable
                Dim processMgr As New DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU.ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim fecha As DateTime = processMgr.MSS_GET_SY_DATE_TIME()

                '-----------------------------------------------------------------------------
                'JNAVA (08.12.2015): Correccion de Almacen (storeID)
                '-----------------------------------------------------------------------------
                params("storeid") = oAppContext.ApplicationConfiguration.Almacen
                'params("storeid") = "004"
                '-----------------------------------------------------------------------------
                params("transDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                params("lastName") = Me.txtPaterno.Text.Trim()
                params("phone") = Me.txtTelefono.Text.Trim()
                resultado = ws.FindCardByPOSArray(params)
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("FindUserPOSResult") = True Then
                        PrintHashtable(resultado)
                        Me.Tarjetas = CType(resultado("FindUserPOSResult"), DataTable)
                        Me.gridTarjetas.DataSource = Nothing
                        Me.gridTarjetas.DataSource = Me.Tarjetas
                        accion = False
                    Else
                        PrintHashtable(resultado)
                        Me.Tarjetas.Rows.Clear()
                        Dim row As DataRow = Me.Tarjetas.NewRow()
                        row("CardId") = CStr(resultado("CardID"))
                        row("Name") = CStr(resultado("NombreCompleto"))
                        Me.Tarjetas.Rows.Add(row)
                        Me.gridTarjetas.DataSource = Nothing
                        Me.gridTarjetas.DataSource = Me.Tarjetas
                        accion = False
                        'MessageBox.Show(CStr(resultado("ErrorMessage")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("No se encontraron datos con la busqueda", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Debe de capturar todos los datos obligatorios", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al busqueda de tarjetas")
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2015: Selecciona la tarjeta que pertenece al cliente.
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub SelectCardGrid(ByVal row As Janus.Windows.GridEX.GridEXRow)
        Dim fila As DataRowView = CType(row.DataRow, DataRowView)
        Me.CardId = CStr(fila!CardId).Remove(0, 1)
        accion = True
        Me.DialogResult = DialogResult.OK
        Me.Dispose()
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 07/05/2014: Imprime el resultado del response
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintHashtable(ByVal result As Hashtable)
        For Each str As String In result.Keys
            Console.WriteLine(str & ": " & CStr(result(str)))
        Next
    End Sub

#End Region

#Region "Eventos Form"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchCards()
    End Sub

    Private Sub txtTelefono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTelefono.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchCards()
        End If
    End Sub

    Private Sub gridTarjetas_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles gridTarjetas.RowDoubleClick
        If Not e.Row Is Nothing Then
            SelectCardGrid(e.Row)
        End If
    End Sub

    Private Sub frmDPCardPuntoSearch_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If accion = False Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        accion = False
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not Me.gridTarjetas.GetRow() Is Nothing Then
            SelectCardGrid(Me.gridTarjetas.GetRow())
        End If
    End Sub

#End Region

End Class
