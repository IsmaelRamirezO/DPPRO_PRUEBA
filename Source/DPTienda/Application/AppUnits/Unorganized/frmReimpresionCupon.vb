Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Public Class frmReimpresionCupon
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
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebPlayerCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPlayerNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ebNotaCredito As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReimpresionCupon))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.ebNotaCredito = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebPlayerCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPlayerNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.btnImprimir)
        Me.explorerBar1.Controls.Add(Me.ebNotaCredito)
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Controls.Add(Me.ebPlayerCod)
        Me.explorerBar1.Controls.Add(Me.ebPlayerNombre)
        Me.explorerBar1.Controls.Add(Me.Label9)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(344, 134)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(8, 88)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(328, 32)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.Text = "Imprimir ReCupón"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNotaCredito
        '
        Me.ebNotaCredito.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNotaCredito.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNotaCredito.ButtonImage = CType(resources.GetObject("ebNotaCredito.ButtonImage"), System.Drawing.Image)
        Me.ebNotaCredito.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebNotaCredito.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNotaCredito.Location = New System.Drawing.Point(72, 24)
        Me.ebNotaCredito.Name = "ebNotaCredito"
        Me.ebNotaCredito.Size = New System.Drawing.Size(144, 22)
        Me.ebNotaCredito.TabIndex = 0
        Me.ebNotaCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNotaCredito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Folio NC."
        '
        'ebPlayerCod
        '
        Me.ebPlayerCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerCod.ButtonImage = CType(resources.GetObject("ebPlayerCod.ButtonImage"), System.Drawing.Image)
        Me.ebPlayerCod.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebPlayerCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayerCod.Location = New System.Drawing.Point(72, 56)
        Me.ebPlayerCod.MaxLength = 12
        Me.ebPlayerCod.Name = "ebPlayerCod"
        Me.ebPlayerCod.Size = New System.Drawing.Size(88, 22)
        Me.ebPlayerCod.TabIndex = 1
        Me.ebPlayerCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPlayerNombre
        '
        Me.ebPlayerNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerNombre.BackColor = System.Drawing.SystemColors.Info
        Me.ebPlayerNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayerNombre.Location = New System.Drawing.Point(168, 56)
        Me.ebPlayerNombre.Name = "ebPlayerNombre"
        Me.ebPlayerNombre.ReadOnly = True
        Me.ebPlayerNombre.Size = New System.Drawing.Size(168, 22)
        Me.ebPlayerNombre.TabIndex = 16
        Me.ebPlayerNombre.TabStop = False
        Me.ebPlayerNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(8, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Realizado:"
        '
        'frmReimpresionCupon
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(344, 134)
        Me.Controls.Add(Me.explorerBar1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmReimpresionCupon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reimpresión de Cupón"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Globales"

    Private oPlayer As Vendedor
    Private oCatalogoPlayersMgr As CatalogoVendedoresManager
    Private oNotaCredito As NotaCredito
    Private oNotasCreditoMgr As NotasCreditoManager
    Private oFacturasMgr As FacturaManager
    Private oSAPMgr As ProcesoSAPManager
    Private oCatalogoClientesMgr As ClientesManager

#End Region

#Region "Metodos"

    Private Sub Inicializar()

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oCatalogoPlayersMgr = New CatalogoVendedoresManager(oAppContext)
        oNotasCreditoMgr = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        oFacturasMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        oCatalogoClientesMgr = New ClientesManager(oAppContext, oAppSAPConfig)

    End Sub


    Private Sub Sm_BuscarPlayers(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New CatalogoVendedoresOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            oPlayer = Nothing
            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                oPlayer = oCatalogoPlayersMgr.Load(oOpenRecordDlg.Record.Item("CodVendedor"))

                ebPlayerCod.Text = oPlayer.ID
                ebPlayerNombre.Text = oPlayer.Nombre

                Me.btnImprimir.Focus()

            Else

                Me.ebPlayerCod.Focus()

            End If

        Else

            oPlayer = Nothing
            If Me.ebPlayerCod.Text.Trim <> "" Then
                oPlayer = oCatalogoPlayersMgr.Load(ebPlayerCod.Text.Trim)

                If (oPlayer Is Nothing) Then

                    MessageBox.Show("El Codigo de vendedor especificado no existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    ebPlayerCod.Text = String.Empty
                    ebPlayerNombre.Text = String.Empty

                    ebPlayerCod.Focus()

                Else

                    ebPlayerCod.Text = oPlayer.ID
                    ebPlayerNombre.Text = oPlayer.Nombre

                    Me.btnImprimir.Focus()

                End If

            Else

                Me.ebPlayerNombre.Text = ""

            End If

        End If

    End Sub

    Private Sub Sm_BuscarNotaCredito(ByVal bMostrar As Boolean)

        Dim oOpenRecordDlg As New OpenRecordDialog

        oOpenRecordDlg.CurrentView = New NotaCreditoOpenRecordDialogView

        oNotaCredito = Nothing

        If bMostrar Then

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                oNotaCredito = oNotasCreditoMgr.Load(oOpenRecordDlg.Record.Item("NotaCreditoID"))

            End If

        ElseIf Me.ebNotaCredito.Text.Trim <> "" Then

            oNotaCredito = oNotasCreditoMgr.Load(Me.ebNotaCredito.Text.Trim)

        Else

            oNotaCredito = Nothing

        End If

        If Not oNotaCredito Is Nothing Then

            Me.ebNotaCredito.Text = oNotaCredito.SALESDOCUMENT

        ElseIf Me.ebNotaCredito.Text.Trim <> "" Then

            MessageBox.Show("El Folio especificado no existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebNotaCredito.Text = ""
            Me.ebNotaCredito.Focus()

        End If

    End Sub

    Private Sub ReimprimirCupon()

        Dim strFolio As String = ""
        Dim oRpt As rptReCupon
        Dim oReCupon As CuponDescuento
        Dim oCliente As ClienteAlterno
        Dim strFirma As String = ""
        Dim bReimpreso As Boolean = False
        Dim strError As String = ""

        strFolio = oFacturasMgr.GetReCuponDescuento(oNotaCredito.ID)
        oReCupon = oSAPMgr.ZCUP_INFO_CUPON(strFolio, oNotaCredito.TipoVentaID, strError)
        bReimpreso = oFacturasMgr.EstaReimpresoReCuponDescuento(strFolio)
        If strError.Trim = "" AndAlso Not oReCupon Is Nothing Then
            If bReimpreso = False Then
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") Then
                    oFacturasMgr.ActualizaStatusRecupon(oReCupon.Folio, oPlayer.ID, oPlayer.Nombre)
                    If CLng(oNotaCredito.ClienteID) <> 1 AndAlso CLng(oNotaCredito.ClienteID) <> 99999 Then
                        oCatalogoClientesMgr.Load(oNotaCredito.ClienteID, oCliente, oNotaCredito.TipoVentaID)
                        If Not oCliente Is Nothing Then strFirma = oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno & " " & oCliente.Nombre
                    End If
                    oRpt = New rptReCupon(oReCupon.Folio, oReCupon.Minimo, oReCupon.Descuento, oReCupon.FechaVigencia, strFirma)
                    oRpt.Document.Name = "ReCupon de Descuento"
                    oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oRpt.Run()
                    oRpt.Document.Print(False, False)
                    MessageBox.Show("El Recupon se ha impreso correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Es necesario la clave del manager para reimprimir el Recupon.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                oAppContext.Security.CloseImpersonatedSession()
            Else
                MessageBox.Show("El Recupon de esta Nota de Credito ya ha sido reimpreso anteriormente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebNotaCredito.Focus()
            End If
        Else
            If strError.Trim = "" Then strError = "El Folio de la Nota de Credito especificada no genero un Recupon."
            MessageBox.Show(strError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebNotaCredito.Focus()
        End If

    End Sub

#End Region

    Private Sub ebPlayerCod_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebPlayerCod.ButtonClick
        Sm_BuscarPlayers(True)
    End Sub

    Private Sub ebPlayerCod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebPlayerCod.Validating
        Sm_BuscarPlayers(False)
    End Sub

    Private Sub ebNotaCredito_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebNotaCredito.ButtonClick
        Sm_BuscarNotaCredito(True)
    End Sub

    Private Sub ebNotaCredito_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNotaCredito.Validating
        Sm_BuscarNotaCredito(False)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        If oNotaCredito Is Nothing Then
            MessageBox.Show("Es necesario especificar el Folio SAP de la Nota de Credito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebNotaCredito.Focus()
        ElseIf oPlayer Is Nothing Then
            MessageBox.Show("Es necesario especificar el codigo del vendedor que requiere reimprimir el ReCupon.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebPlayerCod.Focus()
        Else
            ReimprimirCupon()
        End If

    End Sub

    Private Sub frmReimpresionCupon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class
