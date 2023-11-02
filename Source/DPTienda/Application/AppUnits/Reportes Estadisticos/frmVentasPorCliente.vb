Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports Microsoft.VisualBasic
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmVentasPorCliente
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
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkTodos As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebClienteNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Calendar1 As Janus.Windows.Schedule.Calendar
    Friend WithEvents gboxCliente As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ebTipoVenta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ccmbFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ccmbFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents dgFacturas As Janus.Windows.GridEX.GridEX
    Friend WithEvents gpdVentasCliente As Janus.Windows.GridEX.GridEXPrintDocument
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents ebClienteID As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentasPorCliente))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Calendar1 = New Janus.Windows.Schedule.Calendar()
        Me.dgFacturas = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ccmbFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ccmbFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ebTipoVenta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.chkTodos = New Janus.Windows.EditControls.UICheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gboxCliente = New Janus.Windows.EditControls.UIGroupBox()
        Me.ebClienteID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebClienteNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gpdVentasCliente = New Janus.Windows.GridEX.GridEXPrintDocument()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.Calendar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gboxCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Calendar1)
        Me.ExplorerBar1.Controls.Add(Me.dgFacturas)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.gboxCliente)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(936, 430)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(112, 400)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 23)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "F5"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(136, 400)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 23)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Imprimir"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Calendar1
        '
        Me.Calendar1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Calendar1.Enabled = False
        Me.Calendar1.FirstMonth = New Date(2006, 3, 1, 0, 0, 0, 0)
        Me.Calendar1.Location = New System.Drawing.Point(736, 8)
        Me.Calendar1.Name = "Calendar1"
        Me.Calendar1.Size = New System.Drawing.Size(166, 144)
        Me.Calendar1.TabIndex = 4
        Me.Calendar1.VisualStyle = Janus.Windows.Schedule.VisualStyle.Office2010
        '
        'dgFacturas
        '
        Me.dgFacturas.AllowColumnDrag = False
        Me.dgFacturas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgFacturas.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgFacturas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.dgFacturas.BackColor = System.Drawing.Color.White
        Me.dgFacturas.ColumnAutoResize = True
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.dgFacturas.DesignTimeLayout = GridEXLayout1
        Me.dgFacturas.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.dgFacturas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dgFacturas.GridLineColor = System.Drawing.Color.Black
        Me.dgFacturas.GridLines = Janus.Windows.GridEX.GridLines.Vertical
        Me.dgFacturas.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgFacturas.GroupByBoxVisible = False
        Me.dgFacturas.GroupRowFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.dgFacturas.Location = New System.Drawing.Point(16, 168)
        Me.dgFacturas.Name = "dgFacturas"
        Me.dgFacturas.Size = New System.Drawing.Size(904, 224)
        Me.dgFacturas.TabIndex = 3
        Me.dgFacturas.TreeLineColor = System.Drawing.Color.Black
        Me.dgFacturas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.ccmbFechaFin)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.ccmbFechaInicio)
        Me.UiGroupBox1.Controls.Add(Me.ebTipoVenta)
        Me.UiGroupBox1.Controls.Add(Me.chkTodos)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(336, 144)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.Text = "Opciones de Reporte"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(172, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 23)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Al:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ccmbFechaFin
        '
        '
        '
        '
        Me.ccmbFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccmbFechaFin.Location = New System.Drawing.Point(204, 72)
        Me.ccmbFechaFin.Name = "ccmbFechaFin"
        Me.ccmbFechaFin.Size = New System.Drawing.Size(120, 22)
        Me.ccmbFechaFin.TabIndex = 69
        Me.ccmbFechaFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 23)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "De:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ccmbFechaInicio
        '
        '
        '
        '
        Me.ccmbFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccmbFechaInicio.Location = New System.Drawing.Point(44, 72)
        Me.ccmbFechaInicio.Name = "ccmbFechaInicio"
        Me.ccmbFechaInicio.Size = New System.Drawing.Size(120, 22)
        Me.ccmbFechaInicio.TabIndex = 67
        Me.ccmbFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ebTipoVenta
        '
        Me.ebTipoVenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.ebTipoVenta.DesignTimeLayout = GridEXLayout2
        Me.ebTipoVenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTipoVenta.Location = New System.Drawing.Point(120, 32)
        Me.ebTipoVenta.Name = "ebTipoVenta"
        Me.ebTipoVenta.Size = New System.Drawing.Size(168, 22)
        Me.ebTipoVenta.TabIndex = 66
        Me.ebTipoVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTipoVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'chkTodos
        '
        Me.chkTodos.Checked = True
        Me.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodos.Location = New System.Drawing.Point(104, 104)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(144, 23)
        Me.chkTodos.TabIndex = 2
        Me.chkTodos.Text = "Todos los Clientes"
        Me.chkTodos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(40, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo Venta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gboxCliente
        '
        Me.gboxCliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gboxCliente.BackColor = System.Drawing.Color.Transparent
        Me.gboxCliente.Controls.Add(Me.ebClienteID)
        Me.gboxCliente.Controls.Add(Me.ebClienteNombre)
        Me.gboxCliente.Controls.Add(Me.Label2)
        Me.gboxCliente.Location = New System.Drawing.Point(368, 8)
        Me.gboxCliente.Name = "gboxCliente"
        Me.gboxCliente.Size = New System.Drawing.Size(0, 144)
        Me.gboxCliente.TabIndex = 2
        Me.gboxCliente.Text = "Clientes"
        Me.gboxCliente.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'ebClienteID
        '
        Me.ebClienteID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteID.ButtonImage = CType(resources.GetObject("ebClienteID.ButtonImage"), System.Drawing.Image)
        Me.ebClienteID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebClienteID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteID.Location = New System.Drawing.Point(64, 40)
        Me.ebClienteID.MaxLength = 10
        Me.ebClienteID.Name = "ebClienteID"
        Me.ebClienteID.Size = New System.Drawing.Size(136, 22)
        Me.ebClienteID.TabIndex = 15
        Me.ebClienteID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebClienteNombre
        '
        Me.ebClienteNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteNombre.BackColor = System.Drawing.Color.Ivory
        Me.ebClienteNombre.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebClienteNombre.Location = New System.Drawing.Point(16, 72)
        Me.ebClienteNombre.Name = "ebClienteNombre"
        Me.ebClienteNombre.Size = New System.Drawing.Size(328, 22)
        Me.ebClienteNombre.TabIndex = 2
        Me.ebClienteNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Cliente"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(16, 400)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 23)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "F2"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(40, 400)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 23)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Generar"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gpdVentasCliente
        '
        Me.gpdVentasCliente.DocumentName = "Reporte de Ventas"
        Me.gpdVentasCliente.ExpandFarColumn = False
        Me.gpdVentasCliente.FitColumns = Janus.Windows.GridEX.FitColumnsMode.Zooming
        Me.gpdVentasCliente.GridEX = Me.dgFacturas
        Me.gpdVentasCliente.PageFooterFormatStyle.BackColor = System.Drawing.Color.White
        Me.gpdVentasCliente.PageFooterFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpdVentasCliente.PageFooterFormatStyle.ForeColor = System.Drawing.Color.Black
        Me.gpdVentasCliente.PageHeaderFormatStyle.BackColor = System.Drawing.Color.White
        Me.gpdVentasCliente.PageHeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpdVentasCliente.PageHeaderFormatStyle.ForeColor = System.Drawing.Color.Black
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Detalle..."
        '
        'frmVentasPorCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(936, 430)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.Name = "frmVentasPorCliente"
        Me.Text = "Ventas Por Cliente..."
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.Calendar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.gboxCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxCliente.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Dim dsResult As DataSet
    Dim bolConsulting As Boolean
#End Region

#Region "Private Methods"

    Private Sub FillTipoVenta()

        Dim oTipoVentaMgr As New TiposVentaManager(oAppContext)
        Dim dsTipoVenta As DataSet
        dsTipoVenta = oTipoVentaMgr.Load()

        Dim oNewRow As DataRow = dsTipoVenta.Tables(0).NewRow
        oNewRow("CodTipoVenta") = ""
        oNewRow("Descripcion") = "Todas"
        dsTipoVenta.Tables(0).Rows.Add(oNewRow)

        ebTipoVenta.SetDataBinding(dsTipoVenta, dsTipoVenta.Tables(0).TableName)
        ebTipoVenta.DisplayMember = "Descripcion"
        ebTipoVenta.ValueMember = "CodTipoVenta"
        ebTipoVenta.Value = ""
        oTipoVentaMgr.Dispose()

    End Sub

    Private Sub LoadSearchFormCliente()

        Dim oClienteMgr As New ClientesManager(oAppContext, oAppSAPConfig)
        Dim oCliente As ClienteAlterno

        Dim oOpenRecordDlg As OpenRecordDialogClientes

        Dim strTipoVenta As String = Me.ebTipoVenta.Value
        oCliente = oClienteMgr.CreateAlterno
        oCliente.TipoVenta = strTipoVenta
        oOpenRecordDlg = New OpenRecordDialogClientes
        oOpenRecordDlg.GrupoDeCuentas = oCliente.TipoVenta
        oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oCliente.Clear()

            Try

                Dim intClienteID As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    intClienteID = oOpenRecordDlg.Record.Item("CodigoAlterno")

                Else

                    intClienteID = CType(oOpenRecordDlg.pbCodigo, String)

                End If

                oClienteMgr.Load(intClienteID, oCliente, strTipoVenta)

                Me.bolConsulting = True
                Me.ebClienteID.Text = intClienteID
                Me.ebClienteNombre.Text = oCliente.NombreCompleto


            Catch ex As Exception

                Throw ex
            Finally

                Me.bolConsulting = False

            End Try

        End If

    End Sub

    Private Sub Valida()

        Dim oClienteMgr As New ClientesManager(oAppContext, oAppSAPConfig)
        Dim oCliente As ClienteAlterno
        oCliente = oClienteMgr.CreateAlterno


        Dim strCodCliente As String
        strCodCliente = CStr(ebClienteID.Text).PadLeft(10, "0")

        oCliente.Clear()
        oClienteMgr.Load(strCodCliente, oCliente, Me.ebTipoVenta.Value)
        If (oCliente Is Nothing) Or (oCliente.CodigoAlterno = String.Empty) Or (Not IsNumeric(oCliente.CodigoAlterno)) Then
            MsgBox("Cliente " & strCodCliente & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
            Me.ebClienteNombre.Text = String.Empty
            ebClienteID.Focus()
        Else
            Me.ebClienteNombre.Text = oCliente.NombreCompleto
        End If

    End Sub

#End Region

#Region "Eventos Formulario y Controles"

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        If Not Me.chkTodos.Checked Then
            Dim I As Integer
            For I = 0 To 350 Step 5
                gboxCliente.Size = New Size(I, 144)
                System.Threading.Thread.Sleep(5)
                gboxCliente.Refresh()
            Next
        Else

            Me.ebClienteID.Text = String.Empty
            Me.ebClienteNombre.Text = String.Empty
            gboxCliente.Size = New Size(0, 144)
            Me.Refresh()

        End If
    End Sub

    Private Sub frmVentasPorCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillTipoVenta()
    End Sub

    Private Sub frmVentasPorCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                'Generar

                If Not Me.chkTodos.Checked Then
                    If Me.ebClienteNombre.Text = String.Empty Then
                        MessageBox.Show("Seleccione Cliente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.ebClienteID.Focus()
                        Exit Sub
                    End If
                End If

                Dim oFacturaManager As New FacturaManager(oAppContext)


                If Me.ebClienteID.Text.PadLeft(10, "0") = oAppContext.ApplicationConfiguration.Almacen.PadLeft(10, "0") Then
                    dsResult = oFacturaManager.SelectFacturaClienteID(ccmbFechaInicio.Value, ccmbFechaFin.Value, "0000000001", Me.ebTipoVenta.Value)
                Else
                    dsResult = oFacturaManager.SelectFacturaClienteID(ccmbFechaInicio.Value, ccmbFechaFin.Value, Me.ebClienteID.Text, Me.ebTipoVenta.Value)
                End If

                If dsResult.Tables("Facturas").Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron Facturas con los datos proporcionados", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ebTipoVenta.Focus()
                End If


                'Dim dvFechaAutoF As New DataView(dsResult.Tables(0), "Fecha >='" & oConfigCierreFI.FechaAutoF & "'", "FolioFactura", DataViewRowState.CurrentRows)
                'For Each oView As DataRowView In dvFechaAutoF
                '    oView.Row.Item(1) = 0
                'Next
                'dsResult.Tables(0).AcceptChanges()

                Me.dgFacturas.SetDataBinding(dsResult, "Facturas")

            Case Keys.F4

                If Me.dsResult Is Nothing OrElse Me.dsResult.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("Presione F2 para generar el reporte", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ebTipoVenta.Focus()
                    Exit Sub
                End If

                Dim strEncabezado As String

                strEncabezado = vbCrLf & "Reporte de Ventas por Cliente"
                strEncabezado &= vbCrLf & " Sucursal .- " & oAppContext.ApplicationConfiguration.Almacen
                strEncabezado &= vbCrLf & " De .- " & Me.ccmbFechaInicio.Value & " Al " & Me.ccmbFechaFin.Value

                If Not Me.chkTodos.Checked Then
                    strEncabezado &= vbCrLf & " Cliente .- " & Me.ebClienteID.Text.PadLeft(10, "0") & " " & Me.ebClienteNombre.Text
                End If

                Me.gpdVentasCliente.PageFooterLeft = " Fecha.- " & Now.Date.ToShortDateString
                Me.gpdVentasCliente.PageHeaderCenter = strEncabezado


                Me.gpdVentasCliente.PrepareDocument()
                Me.gpdVentasCliente.Print()

            Case Keys.F5

                If Me.dsResult Is Nothing OrElse Me.dsResult.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("Presione F2 para generar el reporte", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ebTipoVenta.Focus()
                    Exit Sub
                End If

                Dim Cliente As String
                Dim Almacen As String

                If Me.chkTodos.Checked Then
                    Cliente = " Todos "
                Else
                    Cliente = Me.ebClienteID.Text & " " & Me.ebClienteNombre.Text
                End If

                Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
                Dim oAlmacen As Almacen

                oAlmacen = oAlmacenMgr.Create
                oAlmacen = oAlmacenMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

                If oAlmacen Is Nothing Then
                    Almacen = oAppContext.ApplicationConfiguration.Almacen
                Else
                    Almacen = oAlmacen.ID & " " & oAlmacen.Descripcion
                End If


                Dim oARReporte As New rptVentasPorCliente(dsResult, Me.ccmbFechaInicio.Value, Me.ccmbFechaFin.Value, Me.ebTipoVenta.Text, Almacen, Cliente)
                oARReporte.Run()

                Dim oReportView As New ReportViewerForm
                oReportView.Report = oARReporte
                oReportView.Show()

                Try

                    'Imprimir Directo :
                    'oARReporte.Document.Print(False, False)

                Catch ex As Exception

                    Throw New ApplicationException("Se produjó un error. El Reporte Cierre de Dia Notas de Crédito no pudo ser impreso.", ex)

                End Try

                oARReporte = Nothing



            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Sub ebClienteID_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebClienteID.ButtonClick
        LoadSearchFormCliente()
    End Sub

    Private Sub ebClienteID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebClienteID.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchFormCliente()

        ElseIf e.KeyCode = Keys.Enter Then
            If Not (ebClienteID.Text = String.Empty) Then
                Valida()
            End If

        End If
    End Sub

    Private Sub ebClienteID_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebClienteID.Validating
        If Not (ebClienteID.Text = String.Empty) Then
            Valida()
        Else
            ebClienteID.Text = ""

        End If
    End Sub

    Private Sub ebClienteID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebClienteID.TextChanged

        If Not bolConsulting Then
            Me.ebClienteNombre.Text = String.Empty
            Me.dsResult.Clear()
        End If


    End Sub


#End Region



   
End Class
