Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Public Class frmModificarBeneficiario
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblNumeroVale As System.Windows.Forms.Label
    Friend WithEvents txtNumeroVale As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNombreBeneficiario As System.Windows.Forms.Label
    Friend WithEvents txtNombreBeneficiario As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents cmbMotivo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblCodPlayer As System.Windows.Forms.Label
    Friend WithEvents txtCodPlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtPlayer As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModificarBeneficiario))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.txtPlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtCodPlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCodPlayer = New System.Windows.Forms.Label()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.cmbMotivo = New Janus.Windows.EditControls.UIComboBox()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.txtNombreBeneficiario = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNombreBeneficiario = New System.Windows.Forms.Label()
        Me.txtNumeroVale = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNumeroVale = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.txtPlayer)
        Me.ExplorerBar1.Controls.Add(Me.txtCodPlayer)
        Me.ExplorerBar1.Controls.Add(Me.lblCodPlayer)
        Me.ExplorerBar1.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.cmbMotivo)
        Me.ExplorerBar1.Controls.Add(Me.lblMotivo)
        Me.ExplorerBar1.Controls.Add(Me.txtNombreBeneficiario)
        Me.ExplorerBar1.Controls.Add(Me.lblNombreBeneficiario)
        Me.ExplorerBar1.Controls.Add(Me.txtNumeroVale)
        Me.ExplorerBar1.Controls.Add(Me.lblNumeroVale)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(258, 200)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'txtPlayer
        '
        Me.txtPlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPlayer.BackColor = System.Drawing.Color.Ivory
        Me.txtPlayer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtPlayer.Location = New System.Drawing.Point(96, 64)
        Me.txtPlayer.Name = "txtPlayer"
        Me.txtPlayer.Size = New System.Drawing.Size(152, 22)
        Me.txtPlayer.TabIndex = 3
        Me.txtPlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtCodPlayer
        '
        Me.txtCodPlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCodPlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCodPlayer.BackColor = System.Drawing.Color.Ivory
        Me.txtCodPlayer.ButtonImage = CType(resources.GetObject("txtCodPlayer.ButtonImage"), System.Drawing.Image)
        Me.txtCodPlayer.ButtonImageSize = New System.Drawing.Size(16, 16)
        Me.txtCodPlayer.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtCodPlayer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodPlayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.3!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodPlayer.Location = New System.Drawing.Point(9, 64)
        Me.txtCodPlayer.MaxLength = 35
        Me.txtCodPlayer.Name = "txtCodPlayer"
        Me.txtCodPlayer.Size = New System.Drawing.Size(87, 22)
        Me.txtCodPlayer.TabIndex = 2
        Me.txtCodPlayer.TabStop = False
        Me.txtCodPlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCodPlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCodPlayer
        '
        Me.lblCodPlayer.AutoSize = True
        Me.lblCodPlayer.BackColor = System.Drawing.Color.Transparent
        Me.lblCodPlayer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodPlayer.Location = New System.Drawing.Point(8, 48)
        Me.lblCodPlayer.Name = "lblCodPlayer"
        Me.lblCodPlayer.Size = New System.Drawing.Size(72, 14)
        Me.lblCodPlayer.TabIndex = 95
        Me.lblCodPlayer.Text = "Cod Player"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(176, 168)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 94
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(96, 168)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 93
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cmbMotivo
        '
        Me.cmbMotivo.Location = New System.Drawing.Point(56, 136)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(192, 20)
        Me.cmbMotivo.TabIndex = 5
        Me.cmbMotivo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.BackColor = System.Drawing.Color.Transparent
        Me.lblMotivo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMotivo.Location = New System.Drawing.Point(8, 136)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(50, 14)
        Me.lblMotivo.TabIndex = 91
        Me.lblMotivo.Text = "Motivo"
        '
        'txtNombreBeneficiario
        '
        Me.txtNombreBeneficiario.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNombreBeneficiario.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNombreBeneficiario.BackColor = System.Drawing.Color.Ivory
        Me.txtNombreBeneficiario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtNombreBeneficiario.Location = New System.Drawing.Point(8, 104)
        Me.txtNombreBeneficiario.Name = "txtNombreBeneficiario"
        Me.txtNombreBeneficiario.Size = New System.Drawing.Size(240, 22)
        Me.txtNombreBeneficiario.TabIndex = 4
        Me.txtNombreBeneficiario.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNombreBeneficiario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNombreBeneficiario
        '
        Me.lblNombreBeneficiario.AutoSize = True
        Me.lblNombreBeneficiario.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreBeneficiario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreBeneficiario.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNombreBeneficiario.Location = New System.Drawing.Point(8, 88)
        Me.lblNombreBeneficiario.Name = "lblNombreBeneficiario"
        Me.lblNombreBeneficiario.Size = New System.Drawing.Size(128, 14)
        Me.lblNombreBeneficiario.TabIndex = 78
        Me.lblNombreBeneficiario.Text = "Nombre beneficiario"
        '
        'txtNumeroVale
        '
        Me.txtNumeroVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNumeroVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNumeroVale.BackColor = System.Drawing.Color.Ivory
        Me.txtNumeroVale.ButtonImage = CType(resources.GetObject("txtNumeroVale.ButtonImage"), System.Drawing.Image)
        Me.txtNumeroVale.ButtonImageSize = New System.Drawing.Size(16, 16)
        Me.txtNumeroVale.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtNumeroVale.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroVale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.3!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroVale.Location = New System.Drawing.Point(8, 24)
        Me.txtNumeroVale.MaxLength = 35
        Me.txtNumeroVale.Name = "txtNumeroVale"
        Me.txtNumeroVale.Size = New System.Drawing.Size(240, 22)
        Me.txtNumeroVale.TabIndex = 1
        Me.txtNumeroVale.TabStop = False
        Me.txtNumeroVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNumeroVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNumeroVale
        '
        Me.lblNumeroVale.AutoSize = True
        Me.lblNumeroVale.BackColor = System.Drawing.Color.Transparent
        Me.lblNumeroVale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroVale.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNumeroVale.Location = New System.Drawing.Point(8, 8)
        Me.lblNumeroVale.Name = "lblNumeroVale"
        Me.lblNumeroVale.Size = New System.Drawing.Size(106, 14)
        Me.lblNumeroVale.TabIndex = 76
        Me.lblNumeroVale.Text = "Número de Vale "
        '
        'frmModificarBeneficiario
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(258, 200)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmModificarBeneficiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Beneficiarios"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
    Dim oDPVale As cDPVale
#End Region

#Region "Eventos"
    Private Sub frmModificarBeneficiario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadComboMotivos()
        Me.txtNumeroVale.Focus()
    End Sub

    Private Sub txtNumeroVale_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroVale.ButtonClick
        ValidarDPVale()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show("¿Está seguro que estos datos son correctos?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ModificarBeneficiario()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MessageBox.Show("Esta Seguro que desea cancelar", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Dispose()
        End If
    End Sub

    Private Sub txtCodPlayer_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodPlayer.ButtonClick
        LoadSearchFormPlayer()
    End Sub

    Private Sub txtCodPlayer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodPlayer.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadPlayer(Me.txtCodPlayer.Text.Trim())
        End If
    End Sub

    Private Sub txtNumeroVale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroVale.KeyDown
        If e.KeyCode = Keys.Enter Then
            ValidarDPVale()
        End If
    End Sub

    Private Sub txtNumeroVale_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumeroVale.Validating
        If txtNumeroVale.Text.Trim() <> "" Then
            ValidarDPVale()
        End If
    End Sub
#End Region

#Region "Metodos"
    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 13/10/2015: Carga los motivos de modificación por el cual se cambio el beneficiario
    '--------------------------------------------------------------------------------------------------------------------------
    Private Sub LoadComboMotivos()
        Dim motivos As New MotivoBeneficiario
        Me.cmbMotivo.DisplayMember = "Motivo"
        Me.cmbMotivo.ValueMember = "Motivo"
        Me.cmbMotivo.DataSource = motivos.MotivosBeneficiarios
        Me.cmbMotivo.Refresh()
        Me.txtNumeroVale.Focus()
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 13/10/2015: Modifica el beneficiario por el correcto
    '--------------------------------------------------------------------------------------------------------------------------
    Private Sub ModificarBeneficiario()
        If txtNumeroVale.Text.Trim() <> "" AndAlso txtNombreBeneficiario.Text.Trim() <> "" AndAlso cmbMotivo.Text.Trim() <> "" Then
            Dim facturamgr As New FacturaManager(oAppContext, oConfigCierreFI)
            facturamgr.ModificarBeneficiario(txtNumeroVale.Text.Trim(), txtNombreBeneficiario.Text.Trim(), oAppContext.Security.CurrentUser.ID, cmbMotivo.Text.Trim())
            ImprimirTicketSeguro()
            MessageBox.Show("Se guardo el beneficiario correctamente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Dispose()
            'If MessageBox.Show("¿Desea modificar el Beneficiario en otro vale?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            '    Me.Dispose()
            'Else
            '    NewChange()
            'End If
        Else
            MessageBox.Show("Falta información para capturar", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 13/10/2015: Muestra una lista de los players para poder seleccionar
    '---------------------------------------------------------------------------------------------------------------------------
    Private Sub LoadSearchFormPlayer()
        Dim oVendedorMrg As New CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As Vendedor = oVendedorMrg.Create()
        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

        oOpenRecordDialogView.ShowDialog()

        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then
            oVendedor.ClearFields()
            oVendedorMrg.LoadInto(oOpenRecordDialogView.Record.Item("CodVendedor"), oVendedor)
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 18.02.2016: Ya no se necesita validar si el vendedor esta asignado a alguna oficina de venta
            '------------------------------------------------------------------------------------------------------------------------------------
            'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)
            'Select Case strRes
            '    Case "0"
            '        MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Facturación ")
            '        oOpenRecordDialogView.Dispose()
            '        oOpenRecordDialogView = Nothing
            '        Exit Sub
            '    Case "2"
            '        MessageBox.Show("El Vendedor " & oVendedor.ID & " no está asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        oOpenRecordDialogView.Dispose()
            '        oOpenRecordDialogView = Nothing
            '        Exit Sub
            '    Case "1"
            If oOpenRecordDialogView.pbNombre <> String.Empty Then
                txtCodPlayer.Text = oOpenRecordDialogView.pbCodigo
                txtPlayer.Text = oOpenRecordDialogView.pbNombre
            Else
                txtCodPlayer.Text = oOpenRecordDialogView.Record.Item("CodVendedor")
                txtPlayer.Text = oOpenRecordDialogView.Record.Item("Nombre")
            End If
            Me.txtNombreBeneficiario.Focus()
            'End Select

        End If

        oOpenRecordDialogView.Dispose()

        oOpenRecordDialogView = Nothing

    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 12/10/2015: Valida que el vale tenga seguro de vida
    '---------------------------------------------------------------------------------------------------------------------------
    Private Sub ValidarDPVale()
        If txtNumeroVale.Text.Trim() <> "" Then
            txtNumeroVale.Text = txtNumeroVale.Text.PadLeft(10, "0")
            oDPVale = New cDPVale
            Dim impSeg As Decimal = 0, beneficiario As String = ""
            oDPVale.INUMVA = txtNumeroVale.Text.Trim()
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

            If Not oDPVale Is Nothing AndAlso oDPVale.EEXIST = "S" Then
                If Not oDPVale.InfoDPVALE Is Nothing AndAlso oDPVale.InfoDPVALE.Rows.Count > 0 Then
                    For Each row As DataRow In oDPVale.InfoDPVALE.Rows
                        impSeg = CDec(row("ZIMPSEG"))
                    Next
                End If
                If impSeg > 0 Then
                    Dim facturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
                    Dim dtSeguroVida As DataTable = facturaMgr.GetSeguroDPValeByDPValeID(oDPVale.INUMVA)
                    If dtSeguroVida.Rows.Count > 0 Then
                        For Each row As DataRow In dtSeguroVida.Rows
                            If row.IsNull("BeneficiarioMod") = True Then
                                Me.txtNombreBeneficiario.Text = CStr(row("Beneficiario"))
                            Else
                                MessageBox.Show("El beneficiario ya fue modificado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                                'Me.txtNombreBeneficiario.Text = CStr(row("BeneficiarioMod"))
                            End If
                        Next
                    End If
                    Me.txtCodPlayer.Focus()
                Else
                    MessageBox.Show("El vale seleccionado no maneja seguro de vida", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtCodPlayer.Focus()
                End If
            Else
                MessageBox.Show("No existe el número de Vale", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

        End If
    End Sub

    '-------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 13/10/2015: Impresión del Ticket del seguro
    '-------------------------------------------------------------------------------------------------------------------------
    Public Sub ImprimirTicketSeguro()

        Try

            Dim EsReImpresion As Boolean = False

ReImprimir:
            '-----------------------------------------------------------------------------------
            ' Ticket del seguro
            '-----------------------------------------------------------------------------------
            Dim DatosTicketSeguro As New Hashtable
            Dim fechaStr As String = CStr(oDPVale.InfoDPVALE.Rows(0)!FECCO)
            Dim fecha As Date = Mid(fechaStr, 7, 2) & "/" & Mid(fechaStr, 5, 2) & "/" & Mid(fechaStr, 1, 4)
            DatosTicketSeguro = PrepararDatosTicket(CStr(oDPVale.InfoDPVALE.Rows(0)!CODCT), CStr(oDPVale.InfoDPVALE.Rows(0)!NUMDE), fecha, "DPVL")
            Dim oARReporte As New rptTicketSeguro(DatosTicketSeguro)
            oARReporte.Document.Name = "Ticket Seguro"

            If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

                oARReporte.PageSettings.PaperHeight = 7
                oARReporte.PageSettings.PaperWidth = 14
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
                oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

            End If

            oARReporte.Run()

            'Dim oReportViewer As New ReportViewerForm
            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

            '-----------------------------------------------------------------------------------
            ' Imprimimos ticket del seguro
            '-----------------------------------------------------------------------------------
            Try
                oARReporte.Document.Print(False, False)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            '-----------------------------------------------------------------------------------
            ' ReImprimimos ticket del seguro
            '-----------------------------------------------------------------------------------
            If Not EsReImpresion Then
                EsReImpresion = True
                GoTo ReImprimir
            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el ticket de seguro de vida DPVale.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "-Error al imprimir el ticket de seguro de vida DPVale-")
        End Try


    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/10/2015: Prepara la información de para imprimir el Ticket del Seguro de Vida
    '---------------------------------------------------------------------------------------------------------------------------
    Public Function PrepararDatosTicket(ByVal CodClienteDPVL As String, ByVal NumQuincenasDPVL As String, ByVal FechaCobroDPVL As Date, ByVal CodTipoVenta As String) As Hashtable

        Dim htDatosTicket As New Hashtable
        Dim dtFinanciamiento As DataTable
        Dim Plaza As String
        Dim CatalogoMgr As New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim ClienteMgr As New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        Dim oCliente As ClienteAlterno = ClienteMgr.CreateAlterno()
        Dim ImporteSeguro As Decimal = 0
        Dim almacen As almacen = CatalogoMgr.Create()
        CatalogoMgr.LoadInto(oAppContext.ApplicationConfiguration.Almacen, almacen)

        '-----------------------------------------------------------------------------
        ' Obtenemos los datos de la plaza
        '-----------------------------------------------------------------------------
        'Plaza = GetPlaza()
        Plaza = oAppSAPConfig.Plaza.Trim
        htDatosTicket("Plaza") = Plaza
        htDatosTicket("Ciudad") = almacen.Descripcion
        htDatosTicket("Direccion") = almacen.DireccionCalle & " " & almacen.DireccionNumExt & " " & almacen.DireccionCP
        htDatosTicket("Caja") = oAppContext.ApplicationConfiguration.NoCaja
        'htDatosTicket("Fecha") = ""
        'htDatosTicket("Hora") = ""

        '-----------------------------------------------------------------------------
        ' Preparamos datos del Financiamiento
        '-----------------------------------------------------------------------------
        Dim Aseguradora As String
        Dim Aseguradora2 As String
        Dim ImpSeg As Decimal
        Dim ImppSeg As Decimal
        Dim NoPoliza As String
        Dim maiseg As String
        Dim seg As String, folseg As String = ""

        '-----------------------------------------------------------------------------
        ' JNAVA (09.06.2015): Division de Plaza
        '-----------------------------------------------------------------------------
        Dim DIVP As String = ""

        '-----------------------------------------------------------------------------
        ' Obtenemos los datos del Financiamiento
        '-----------------------------------------------------------------------------
        dtFinanciamiento = FacturaMgr.GetDatosFinanciamiento(Plaza)
        If dtFinanciamiento Is Nothing OrElse dtFinanciamiento.Rows.Count <= 0 Then
            htDatosTicket = Nothing
            ImporteSeguro = 0
            GoTo Salir
        End If

        '-----------------------------------------------------------------------------
        ' Sacamos los datos del Financiamiento
        '-----------------------------------------------------------------------------
        For Each oRow As DataRow In dtFinanciamiento.Rows
            Aseguradora = oRow!Aseguradora
            Aseguradora2 = oRow!Aseguradora2
            ImpSeg = oRow!ImpSeg
            ImppSeg = oRow!ImppSeg
            NoPoliza = oRow!NoPoliza
            maiseg = CStr(oRow!maiseg).Trim
            seg = CStr(oRow!seg).Trim
            folseg = CStr(oRow!folseg).Trim
            DIVP = CStr(oRow!DIVP).Trim
        Next

        '-----------------------------------------------------------------------------
        ' Comenzamos a setear datos de Financiamiento
        '-----------------------------------------------------------------------------
        htDatosTicket("Aseguradora") = Aseguradora

        '-----------------------------------------------------------------------------
        ' Obtenemos los datos del Canjeante
        '-----------------------------------------------------------------------------
        oCliente.Clear()
        ClienteMgr.Load(CodClienteDPVL, oCliente, CodTipoVenta)

        '-----------------------------------------------------------------------------
        ' Seteamos datos del cliente
        '-----------------------------------------------------------------------------
        htDatosTicket("NoCanjeante") = CStr(oCliente.CodigoCliente).PadLeft(10, "0")
        htDatosTicket("Canjeante") = oCliente.NombreCompleto
        htDatosTicket("RFC") = oCliente.RFC
        htDatosTicket("Sexo") = IIf(oCliente.Sexo = "F", "Femenino", "Masculino")

        '-----------------------------------------------------------------------------
        ' Seteamos datos de Financiamiento
        '-----------------------------------------------------------------------------
        ImporteSeguro = ImpSeg
        htDatosTicket("ImporteFin") = Format((NumQuincenasDPVL * ImpSeg), "c")
        htDatosTicket("MontoSeguro") = Format(ImppSeg, "c")
        htDatosTicket("folseg") = folseg

        htDatosTicket("Vigencia") = FechaCobroDPVL.AddMonths(NumQuincenasDPVL / 2)
        htDatosTicket("NoPoliza") = NoPoliza
        htDatosTicket("Beneficiarios") = Me.txtNombreBeneficiario.Text.Trim()

        htDatosTicket("DireccionFinanciador") = maiseg
        htDatosTicket("TelefonoFinanciador") = seg
        htDatosTicket("TelefonoInformacion") = seg

        htDatosTicket("Aseguradora2") = Aseguradora2

Salir:
        Return htDatosTicket

    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/10/2015: Carga el player por medio de su código
    '---------------------------------------------------------------------------------------------------------------------------
    Private Sub LoadPlayer(ByVal CodPlayer As String)
        Dim VendedorMgr As New CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As Vendedor = VendedorMgr.Create()
        oVendedor.ClearFields()
        VendedorMgr.LoadInto(CodPlayer, oVendedor)
        If oVendedor.ID <> String.Empty Then
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 18.02.2016: Ya no se necesita validar si el vendedor esta asignado a alguna oficina de venta
            '------------------------------------------------------------------------------------------------------------------------------------
            'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)
            'Select Case strRes
            '    Case "0"
            '        MessageBox.Show("Código de Vendedor no existe", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Me.txtCodPlayer.Text = ""
            '        Me.txtPlayer.Text = ""
            '        Me.txtCodPlayer.Focus()
            '    Case "2"
            '        MessageBox.Show("El Vendedor " & oVendedor.ID & " no está asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        oVendedor.ClearFields()
            '        Me.txtCodPlayer.Text = ""
            '        Me.txtPlayer.Text = ""
            '        Me.txtCodPlayer.Focus()
            '    Case Else
            Me.txtCodPlayer.Text = oVendedor.ID
            Me.txtPlayer.Text = oVendedor.Nombre
            Me.txtNombreBeneficiario.Focus()
            'End Select
        End If
    End Sub

    Private Sub NewChange()
        Me.txtNumeroVale.Text = ""
        Me.txtCodPlayer.Text = ""
        Me.txtPlayer.Text = ""
        Me.txtNombreBeneficiario.Text = ""
        Me.cmbMotivo.SelectedItem = Nothing
        Me.oDPVale = Nothing
        Me.txtNumeroVale.Focus()
    End Sub
#End Region
End Class
