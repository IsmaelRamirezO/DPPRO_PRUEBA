Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmCapturarMotivos
    Inherits System.Windows.Forms.Form

    Private oSAPMgr As ProcesoSAPManager
    Private oDPVale As cDPVale
    Private bSalir As Boolean = False
    Private strTipoVenta As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal CodDPVale As String, ByVal TipoVenta As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.ebCodDPvale.Text = CodDPVale
        strTipoVenta = TipoVenta
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
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
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebCodDPvale As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblCodDPvale As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents mnuGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblTotalAsignados As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbMotivos As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebPlaza As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturarMotivos))
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebPlaza = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblTotalAsignados = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ebCodDPvale = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblCodDPvale = New System.Windows.Forms.Label()
        Me.cmbMotivos = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.mnuGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("mnuGuardar")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.mnuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("mnuSalir")
        Me.mnuGuardar = New Janus.Windows.UI.CommandBars.UICommand("mnuGuardar")
        Me.mnuSalir = New Janus.Windows.UI.CommandBars.UICommand("mnuSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.Controls.Add(Me.ebPlaza)
        Me.ExplorerBar2.Controls.Add(Me.Label2)
        Me.ExplorerBar2.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar2.Controls.Add(Me.ebCodDPvale)
        Me.ExplorerBar2.Controls.Add(Me.lblCodDPvale)
        Me.ExplorerBar2.Controls.Add(Me.cmbMotivos)
        Me.ExplorerBar2.Controls.Add(Me.Label3)
        Me.ExplorerBar2.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Key = "Group2"
        ExplorerBarGroup3.Text = " Datos Generales"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar2.GroupSeparation = 30
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 32)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(474, 164)
        Me.ExplorerBar2.TabIndex = 73
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebPlaza
        '
        Me.ebPlaza.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlaza.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlaza.BackColor = System.Drawing.SystemColors.Info
        Me.ebPlaza.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.ebPlaza.Location = New System.Drawing.Point(128, 69)
        Me.ebPlaza.Name = "ebPlaza"
        Me.ebPlaza.ReadOnly = True
        Me.ebPlaza.Size = New System.Drawing.Size(96, 23)
        Me.ebPlaza.TabIndex = 105
        Me.ebPlaza.TabStop = False
        Me.ebPlaza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebPlaza.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 16)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Plaza:"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarBackground
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.lblTotalAsignados)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 144)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(474, 20)
        Me.UiGroupBox1.TabIndex = 103
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'lblTotalAsignados
        '
        Me.lblTotalAsignados.AutoSize = True
        Me.lblTotalAsignados.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalAsignados.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAsignados.ForeColor = System.Drawing.Color.Black
        Me.lblTotalAsignados.Location = New System.Drawing.Point(40, 2)
        Me.lblTotalAsignados.Name = "lblTotalAsignados"
        Me.lblTotalAsignados.Size = New System.Drawing.Size(202, 16)
        Me.lblTotalAsignados.TabIndex = 35
        Me.lblTotalAsignados.Text = "Guardar el Motivo de Rechazo"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(16, 2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 16)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "F1"
        '
        'ebCodDPvale
        '
        Me.ebCodDPvale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodDPvale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodDPvale.BackColor = System.Drawing.SystemColors.Info
        Me.ebCodDPvale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodDPvale.FormatString = "0000000000"
        Me.ebCodDPvale.Location = New System.Drawing.Point(128, 40)
        Me.ebCodDPvale.MaxLength = 10
        Me.ebCodDPvale.Name = "ebCodDPvale"
        Me.ebCodDPvale.ReadOnly = True
        Me.ebCodDPvale.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ebCodDPvale.Size = New System.Drawing.Size(96, 22)
        Me.ebCodDPvale.TabIndex = 0
        Me.ebCodDPvale.Text = "0000000000"
        Me.ebCodDPvale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodDPvale.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebCodDPvale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCodDPvale
        '
        Me.lblCodDPvale.AutoSize = True
        Me.lblCodDPvale.BackColor = System.Drawing.Color.Transparent
        Me.lblCodDPvale.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodDPvale.Location = New System.Drawing.Point(22, 42)
        Me.lblCodDPvale.Name = "lblCodDPvale"
        Me.lblCodDPvale.Size = New System.Drawing.Size(111, 16)
        Me.lblCodDPvale.TabIndex = 98
        Me.lblCodDPvale.Text = "Código del Vale:"
        '
        'cmbMotivos
        '
        Me.cmbMotivos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbMotivos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbMotivos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbMotivos.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        Me.cmbMotivos.Cursor = System.Windows.Forms.Cursors.Hand
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.cmbMotivos.DesignTimeLayout = GridEXLayout3
        Me.cmbMotivos.DisplayMember = "DDTEXT"
        Me.cmbMotivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMotivos.Location = New System.Drawing.Point(129, 101)
        Me.cmbMotivos.Name = "cmbMotivos"
        Me.cmbMotivos.Size = New System.Drawing.Size(336, 26)
        Me.cmbMotivos.TabIndex = 1
        Me.cmbMotivos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMotivos.ValueMember = "DOMVALUE_L"
        Me.cmbMotivos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Motivos:"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.AllowMerge = False
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.mnuGuardar, Me.mnuSalir})
        Me.UiCommandManager1.ContainerControl = Me
        Me.UiCommandManager1.Id = New System.Guid("bfefeeab-6fba-45a2-b5f6-1f7079f5b076")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.LockCommandBars = True
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.ShowQuickCustomizeMenu = False
        Me.UiCommandManager1.ShowShortcutInToolTips = True
        Me.UiCommandManager1.SmallImageSize = New System.Drawing.Size(24, 24)
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        Me.UiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.mnuGuardar1, Me.Separator1, Me.mnuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(178, 32)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'mnuGuardar1
        '
        Me.mnuGuardar1.Key = "mnuGuardar"
        Me.mnuGuardar1.Name = "mnuGuardar1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        Me.Separator1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'mnuSalir1
        '
        Me.mnuSalir1.Key = "mnuSalir"
        Me.mnuSalir1.Name = "mnuSalir1"
        Me.mnuSalir1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'mnuGuardar
        '
        Me.mnuGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.mnuGuardar.Icon = CType(resources.GetObject("mnuGuardar.Icon"), System.Drawing.Icon)
        Me.mnuGuardar.Key = "mnuGuardar"
        Me.mnuGuardar.Name = "mnuGuardar"
        Me.mnuGuardar.Text = "Guardar Motivo de Rechazo"
        Me.mnuGuardar.ToolTipText = "Guardar Motivo de Rechazo"
        '
        'mnuSalir
        '
        Me.mnuSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.mnuSalir.Icon = CType(resources.GetObject("mnuSalir.Icon"), System.Drawing.Icon)
        Me.mnuSalir.Key = "mnuSalir"
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.ToolTipText = "Salir"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(474, 32)
        '
        'frmCapturarMotivos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(474, 196)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(480, 224)
        Me.MinimumSize = New System.Drawing.Size(480, 224)
        Me.Name = "frmCapturarMotivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de Motivos de Rechazos"
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ExplorerBar2.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key
            Case "mnuGuardar"
                Registrar()
                'Case "mnuSalir"
                '    bSalir = True
                '    Me.Close()
        End Select
    End Sub

#Region "Metodos"

    Private Sub Nuevo()
        ebCodDPvale.Value = 0
        cmbMotivos.Text = ""
        bSalir = False
        ebCodDPvale.Focus()
    End Sub

    Private Sub Registrar()
        If Validar() Then

            '--------------------------------------------------------------------------------
            'JNAVA (28.12.2015): Implementacion de Servicios REST para SAP Retail
            '--------------------------------------------------------------------------------
            If Trim(oSAPMgr.ZDPVL_REGISTRAR_RECHAZO(ebCodDPvale.Value, cmbMotivos.Value, ebPlaza.Text, strTipoVenta)) = String.Empty Then
                'Dim oRetail As New ProcesosRetail("/pos/ventas", "POST")
                'If Trim(oRetail.SapZdpvlRegistrarRechazo(ebCodDPvale.Value, cmbMotivos.Value, ebPlaza.Text, strTipoVenta)) = String.Empty Then
                MsgBox("Los datos del motivo del rechazo fueron guardados correctamente", MsgBoxStyle.Information, "Validación")
                bSalir = True
                Me.DialogResult = DialogResult.OK
            Else
                Nuevo()
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        Validar = False

        'If ebCodDPvale.Value = 0 Then
        '    MsgBox("Debes capturar el código del vale.", MsgBoxStyle.Exclamation, "Validación")
        '    ebCodDPvale.Focus()
        '    Exit Function
        'End If

        If cmbMotivos.Text = String.Empty Then
            MsgBox("Debes de seleccionar un motivo.", MsgBoxStyle.Exclamation, "Validación")
            cmbMotivos.Focus()
            Exit Function
        End If
        Validar = True
    End Function

    Private Sub Mostrar()
        '------------------------------------------------------------------
        ' JNAVA (29.12.2015): Adaptamos para ejecutar desde SAP Retail
        '------------------------------------------------------------------
        Dim oRetail As New ProcesosRetail("/pos/ventas", "POST")
        'cmbMotivos.DataSource = oSAPMgr.ZDPVL_GET_MOTIVOSRECHAZOS()
        cmbMotivos.DataSource = oRetail.SapZdpvlGetMotivosRechazos()
        '------------------------------------------------------------------
        ebPlaza.Text = oAppSAPConfig.Plaza
    End Sub

    Private Sub MuestraDatosDistribuidor()

        If ebCodDPvale.Value = 0 Then
            MessageBox.Show("Es necesario especificar un folio de DPVale.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Nuevo()
            Exit Sub
        End If

        oDPVale = New cDPVale

        oDPVale.INUMVA = ebCodDPvale.Value
        oDPVale.I_RUTA = "X"

        '----------------------------------------------------------------------------------------
        ' JNAVA (18.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
        '----------------------------------------------------------------------------------------
        Dim oS2Credit As New ProcesosS2Credit
        'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

        '----------------------------------------------------------------------------------------
        ' JNAVA (18.07.2016): Valida DPVale
        '----------------------------------------------------------------------------------------
        Dim FirmaDistribuidor As Image = Nothing
        Dim NombreDistribuidor As String = String.Empty
        If oConfigCierreFI.AplicarS2Credit Then
            oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistribuidor, NombreDistribuidor)
        Else
            oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
        End If
        '----------------------------------------------------------------------------------------

        Dim oRow As DataRow

        If oDPVale.InfoDPVALE.Rows.Count <> 0 Then
            cmbMotivos.Focus()
        Else
            MessageBox.Show("El código de dpvale especificado no existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Nuevo()
        End If
        oDPVale = Nothing
    End Sub

#End Region

#Region "Eventos"

    Private Sub frmCapturarMotivos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.F1
                Registrar()
        End Select
    End Sub

    Private Sub frmCapturarMotivos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Mostrar()
        MuestraDatosDistribuidor()
    End Sub

    Private Sub frmCapturarMotivos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bSalir = False Then
            e.Cancel() = True
        End If
    End Sub

#End Region

End Class