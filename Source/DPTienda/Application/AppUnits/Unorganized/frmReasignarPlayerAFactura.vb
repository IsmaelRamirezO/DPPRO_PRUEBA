Option Explicit On 
Option Strict On


Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas

Public Class frmReasignarPlayerAFactura
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CalendarCombo1 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebResponsableName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebResponsableID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPlayerName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNuevoPlayerID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPlayerID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents nbFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebNuevoPlayerNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnGuadar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbCodCaja As Janus.Windows.EditControls.UIComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReasignarPlayerAFactura))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cmbCodCaja = New Janus.Windows.EditControls.UIComboBox()
        Me.btnGuadar = New Janus.Windows.EditControls.UIButton()
        Me.ebNuevoPlayerNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.nbFolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.CalendarCombo1 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ebPlayerName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebResponsableName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNuevoPlayerID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebResponsableID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ebPlayerID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.cmbCodCaja)
        Me.ExplorerBar1.Controls.Add(Me.btnGuadar)
        Me.ExplorerBar1.Controls.Add(Me.ebNuevoPlayerNombre)
        Me.ExplorerBar1.Controls.Add(Me.nbFolio)
        Me.ExplorerBar1.Controls.Add(Me.CalendarCombo1)
        Me.ExplorerBar1.Controls.Add(Me.ebPlayerName)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsableName)
        Me.ExplorerBar1.Controls.Add(Me.ebNuevoPlayerID)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsableID)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.ebPlayerID)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Reasignar Player"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(368, 205)
        Me.ExplorerBar1.TabIndex = 9
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cmbCodCaja
        '
        Me.cmbCodCaja.Location = New System.Drawing.Point(136, 48)
        Me.cmbCodCaja.Name = "cmbCodCaja"
        Me.cmbCodCaja.Size = New System.Drawing.Size(72, 23)
        Me.cmbCodCaja.TabIndex = 12
        Me.cmbCodCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnGuadar
        '
        Me.btnGuadar.Location = New System.Drawing.Point(232, 176)
        Me.btnGuadar.Name = "btnGuadar"
        Me.btnGuadar.Size = New System.Drawing.Size(120, 23)
        Me.btnGuadar.TabIndex = 9
        Me.btnGuadar.Text = "Guardar"
        Me.btnGuadar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNuevoPlayerNombre
        '
        Me.ebNuevoPlayerNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNuevoPlayerNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNuevoPlayerNombre.BackColor = System.Drawing.Color.Ivory
        Me.ebNuevoPlayerNombre.Enabled = False
        Me.ebNuevoPlayerNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNuevoPlayerNombre.Location = New System.Drawing.Point(216, 120)
        Me.ebNuevoPlayerNombre.Name = "ebNuevoPlayerNombre"
        Me.ebNuevoPlayerNombre.ReadOnly = True
        Me.ebNuevoPlayerNombre.Size = New System.Drawing.Size(136, 22)
        Me.ebNuevoPlayerNombre.TabIndex = 6
        Me.ebNuevoPlayerNombre.TabStop = False
        Me.ebNuevoPlayerNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNuevoPlayerNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbFolio
        '
        Me.nbFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFolio.ButtonImage = CType(resources.GetObject("nbFolio.ButtonImage"), System.Drawing.Image)
        Me.nbFolio.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.nbFolio.Location = New System.Drawing.Point(136, 72)
        Me.nbFolio.Name = "nbFolio"
        Me.nbFolio.Size = New System.Drawing.Size(72, 23)
        Me.nbFolio.TabIndex = 2
        Me.nbFolio.Text = "0"
        Me.nbFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFolio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'CalendarCombo1
        '
        '
        '
        '
        Me.CalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.CalendarCombo1.Location = New System.Drawing.Point(240, 48)
        Me.CalendarCombo1.Name = "CalendarCombo1"
        Me.CalendarCombo1.ReadOnly = True
        Me.CalendarCombo1.ShowDropDown = False
        Me.CalendarCombo1.Size = New System.Drawing.Size(112, 23)
        Me.CalendarCombo1.TabIndex = 10
        Me.CalendarCombo1.TabStop = False
        Me.CalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ebPlayerName
        '
        Me.ebPlayerName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerName.BackColor = System.Drawing.Color.Ivory
        Me.ebPlayerName.Enabled = False
        Me.ebPlayerName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayerName.Location = New System.Drawing.Point(216, 96)
        Me.ebPlayerName.Name = "ebPlayerName"
        Me.ebPlayerName.ReadOnly = True
        Me.ebPlayerName.Size = New System.Drawing.Size(136, 22)
        Me.ebPlayerName.TabIndex = 4
        Me.ebPlayerName.TabStop = False
        Me.ebPlayerName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebResponsableName
        '
        Me.ebResponsableName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsableName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsableName.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsableName.Enabled = False
        Me.ebResponsableName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebResponsableName.Location = New System.Drawing.Point(216, 144)
        Me.ebResponsableName.Name = "ebResponsableName"
        Me.ebResponsableName.ReadOnly = True
        Me.ebResponsableName.Size = New System.Drawing.Size(136, 22)
        Me.ebResponsableName.TabIndex = 8
        Me.ebResponsableName.TabStop = False
        Me.ebResponsableName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNuevoPlayerID
        '
        Me.ebNuevoPlayerID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNuevoPlayerID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNuevoPlayerID.ButtonImage = CType(resources.GetObject("ebNuevoPlayerID.ButtonImage"), System.Drawing.Image)
        Me.ebNuevoPlayerID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebNuevoPlayerID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNuevoPlayerID.Location = New System.Drawing.Point(136, 120)
        Me.ebNuevoPlayerID.Name = "ebNuevoPlayerID"
        Me.ebNuevoPlayerID.Size = New System.Drawing.Size(72, 22)
        Me.ebNuevoPlayerID.TabIndex = 5
        Me.ebNuevoPlayerID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNuevoPlayerID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebResponsableID
        '
        Me.ebResponsableID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsableID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsableID.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsableID.Enabled = False
        Me.ebResponsableID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebResponsableID.Location = New System.Drawing.Point(136, 144)
        Me.ebResponsableID.Name = "ebResponsableID"
        Me.ebResponsableID.ReadOnly = True
        Me.ebResponsableID.Size = New System.Drawing.Size(72, 22)
        Me.ebResponsableID.TabIndex = 7
        Me.ebResponsableID.TabStop = False
        Me.ebResponsableID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Responsable.:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Nuevo Player.:"
        '
        'ebPlayerID
        '
        Me.ebPlayerID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerID.BackColor = System.Drawing.Color.Ivory
        Me.ebPlayerID.Enabled = False
        Me.ebPlayerID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayerID.Location = New System.Drawing.Point(136, 96)
        Me.ebPlayerID.Name = "ebPlayerID"
        Me.ebPlayerID.ReadOnly = True
        Me.ebPlayerID.Size = New System.Drawing.Size(72, 22)
        Me.ebPlayerID.TabIndex = 3
        Me.ebPlayerID.TabStop = False
        Me.ebPlayerID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Player.:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "No. Caja.:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Folio.:"
        '
        'frmReasignarPlayerAFactura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(368, 205)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.Name = "frmReasignarPlayerAFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reasignar Factura."
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

    Private bolContraseña As Boolean

    Private oVendedor As Vendedor
    Private oVendedoresMgr As CatalogoVendedoresManager

    Private oFactura As Factura
    Private oFacturaMgr As FacturaManager

    Private oCierreDiaMgr As CierreDiaManager

    Private boolValidating As Boolean = False

    Private oCajasMgr As CatalogoCajaManager

#End Region

    Private Sub frmReasignarPlayerAFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oPassword As New frmPasswordGenerico

        'If Not oPassword.ShowDialog() = DialogResult.OK Then
        '    Me.Close()
        'End If


        'oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
        'oVendedor = oVendedoresMgr.Create
        'ovendedor ovendedoresmgr.Load (
        'oVendedor = oPassword.oVendedor
        'oPassword.Dispose()

        'Me.ebResponsableID.Text = oVendedor.ID
        'Me.ebResponsableName.Text = oVendedor.Nombre

        Me.ebResponsableID.Text = oAppContext.Security.CurrentUser.SessionLoginName
        Me.ebResponsableName.Text = oAppContext.Security.CurrentUser.Name

        sm_Nuevo()

        oFacturaMgr = New FacturaManager(oAppContext)
        oFactura = oFacturaMgr.Create

        oCierreDiaMgr = New CierreDiaManager(oAppContext, oAppSAPConfig)


        Dim dsCaja As New DataSet
        oCajasMgr = New CatalogoCajaManager(oAppContext)

        dsCaja = oCajasMgr.GetAll(False)

        Me.cmbCodCaja.DataSource = dsCaja
        Me.cmbCodCaja.DataMember = "CatalogoCajas"
        Me.cmbCodCaja.DisplayMember = "CodCaja"
        Me.cmbCodCaja.ValueMember = "CodCaja"

        Me.cmbCodCaja.SelectedValue = oAppContext.ApplicationConfiguration.NoCaja

    End Sub

    Private Sub LoadSearchFormFactura(Optional ByVal EnabledRecordOnly As Boolean = False)

        If EnabledRecordOnly = True Or CInt(Me.nbFolio.Value) = 0 Then


            Dim oOpenRecordDlg As New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New FacturaCajaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                oFactura.ClearFields()

                oFacturaMgr.LoadInto(CInt(oOpenRecordDlg.Record.Item("FacturaID")), oFactura)

                If oFactura.FacturaID = 0 Then

                    MessageBox.Show("Folio Factura no Existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.nbFolio.Focus()

                Else

                    If oFactura.Fecha = CalendarCombo1.Value Then
                        Me.nbFolio.Value = oFactura.FolioFactura

                        oVendedor.ClearFields()

                        oVendedoresMgr.LoadInto(oFactura.CodVendedor, oVendedor)

                        If oVendedor.ID <> String.Empty Then

                            Me.ebPlayerID.Text = oVendedor.ID
                            Me.ebPlayerName.Text = oVendedor.Nombre

                        Else

                            MessageBox.Show("El player de la factura no se encuentra en el católogo players", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.ebPlayerID.Text = oFactura.CodVendedor

                        End If
                    Else

                        MessageBox.Show("Solo puede modificar facturas del día", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Me.nbFolio.Focus()

                    End If

                End If

            End If

        Else

            oFactura.ClearFields()

            oFacturaMgr.Load(CInt(Me.nbFolio.Value), CStr(cmbCodCaja.SelectedValue), oFactura)

            If oFactura.FacturaID = 0 Then

                MessageBox.Show("Folio Factura no Existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.nbFolio.Focus()

            Else

                If oFactura.Fecha = CalendarCombo1.Value Then
                    Me.nbFolio.Value = oFactura.FolioFactura

                    If (oVendedoresMgr Is Nothing) Then
                        oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
                    End If

                    If (oVendedor Is Nothing) Then
                        oVendedor = oVendedoresMgr.Create
                    End If

                    oVendedor.ClearFields()


                    oVendedoresMgr.LoadInto(oFactura.CodVendedor, oVendedor)

                    If oVendedor.ID <> String.Empty Then

                        Me.ebPlayerID.Text = oVendedor.ID
                        Me.ebPlayerName.Text = oVendedor.Nombre

                    Else

                        MessageBox.Show("El player de la factura no se encuentra en el católogo players", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.ebPlayerID.Text = oFactura.CodVendedor

                    End If
                Else

                    MessageBox.Show("Solo puede modificar facturas del día", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.nbFolio.Focus()

                End If

            End If

        End If
    End Sub


    Private Sub nbFolio_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbFolio.ButtonClick
        LoadSearchFormFactura(True)
    End Sub

    Private Sub nbFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nbFolio.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchFormFactura(True)

        ElseIf e.KeyCode = Keys.Enter Then

            LoadSearchFormFactura()

        End If
    End Sub


    Private Sub Sm_Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (Me.ebNuevoPlayerID.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoVendedoresOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oVendedor = Nothing
                oVendedor = oVendedoresMgr.Load(CStr(oOpenRecordDlg.Record.Item("CodVendedor")))

                Me.ebNuevoPlayerID.Text = oVendedor.ID
                Me.ebNuevoPlayerNombre.Text = oVendedor.Nombre

            Else

                Me.ebNuevoPlayerID.Text = String.Empty
                Me.ebNuevoPlayerNombre.Text = String.Empty


            End If



        Else

            On Error Resume Next

            oVendedor = Nothing
            oVendedor = oVendedoresMgr.Load(Me.ebNuevoPlayerID.Text)

            If oVendedor.IsDirty Then
                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ebNuevoPlayerID.Focus()
            Else
                Me.ebNuevoPlayerID.Text = oVendedor.ID
                Me.ebNuevoPlayerNombre.Text = oVendedor.Nombre

            End If

        End If


    End Sub

    Private Sub ebNuevoPlayerID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebNuevoPlayerID.ButtonClick

        Sm_Buscar(True)

    End Sub

    Private Sub ebNuevoPlayerID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNuevoPlayerID.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_Buscar(True)

        ElseIf e.KeyCode = Keys.Enter Then

            Sm_Buscar()

        End If

    End Sub

    Private Sub btnGuadar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuadar.Click

        Try

            oVendedor = Nothing
            oVendedor = oVendedoresMgr.Load(Me.ebNuevoPlayerID.Text)

            If oVendedor.IsDirty Then

                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ebNuevoPlayerID.Focus()
                Me.ebNuevoPlayerID.Text = String.Empty
                Me.ebNuevoPlayerNombre.Text = String.Empty

                Exit Sub

            Else

                Me.ebNuevoPlayerID.Text = oVendedor.ID
                Me.ebNuevoPlayerNombre.Text = oVendedor.Nombre

            End If


            If CInt(Me.oFactura.FacturaID) = 0 Then

                MessageBox.Show("Falta folio factura", "DPTienda", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                Exit Sub

            ElseIf Me.ebNuevoPlayerID.Text = String.Empty Or Me.ebNuevoPlayerNombre.Text = String.Empty Then

                MessageBox.Show("Falta nuevo player", "DPTienda", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                Exit Sub

            ElseIf Not oCierreDiaMgr.ValidarCierreDia(oFactura.Fecha) Then


                MessageBox.Show("No se puede reasignar el player a esta Factura", "DPTienda", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                Exit Sub


            ElseIf MessageBox.Show("Se encuentra seguro de actualizar la información", "DPTienda", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then

                Exit Sub

            End If


            oFactura.CodVendedor = Me.ebNuevoPlayerID.Text
            oFacturaMgr.UpdatePlayer(oFactura)


            MessageBox.Show("Los datos se actualizaron con éxito", "DPTienda", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            sm_Nuevo()

        Catch ex As Exception


        End Try


    End Sub

    Private Sub frmReasignarPlayerAFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        boolValidating = True

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub sm_Nuevo()

        Me.nbFolio.Value = 0
        cmbCodCaja.SelectedValue = oAppContext.ApplicationConfiguration.NoCaja
        Me.ebPlayerID.Text = String.Empty
        Me.ebPlayerName.Text = String.Empty
        Me.ebNuevoPlayerID.Text = String.Empty
        Me.ebNuevoPlayerNombre.Text = String.Empty
        Me.cmbCodCaja.Focus()
        boolValidating = False

    End Sub



    Private Sub nbFolio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nbFolio.Validating

        If boolValidating Then
            If CInt(oFactura.FacturaID) = 0 Then

                MessageBox.Show("Seleccione Factura", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True

            End If
        End If

    End Sub

    Private Sub ebNuevoPlayerID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNuevoPlayerID.Validating

        If boolValidating Then

            If Me.ebNuevoPlayerID.Text = String.Empty Then

                MessageBox.Show("Falta Nuevo Player", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True

            End If

        End If

    End Sub
End Class
