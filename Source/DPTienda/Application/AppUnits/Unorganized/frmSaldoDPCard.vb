Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports Pinpad
Imports System.Collections.Generic
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class frmSaldoDPCard
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
    Friend WithEvents exFondo As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnLeerDPCard As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebNumDPCard As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblValidaDPCard As System.Windows.Forms.Label
    Friend WithEvents btnImprimirSaldo As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaldoDPCard))
        Me.exFondo = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblValidaDPCard = New System.Windows.Forms.Label()
        Me.btnImprimirSaldo = New Janus.Windows.EditControls.UIButton()
        Me.btnLeerDPCard = New Janus.Windows.EditControls.UIButton()
        Me.ebNumDPCard = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        CType(Me.exFondo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exFondo.SuspendLayout()
        Me.SuspendLayout()
        '
        'exFondo
        '
        Me.exFondo.Controls.Add(Me.lblValidaDPCard)
        Me.exFondo.Controls.Add(Me.btnImprimirSaldo)
        Me.exFondo.Controls.Add(Me.btnLeerDPCard)
        Me.exFondo.Controls.Add(Me.ebNumDPCard)
        Me.exFondo.Controls.Add(Me.Label16)
        Me.exFondo.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Club DP"
        Me.exFondo.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.exFondo.Location = New System.Drawing.Point(0, 0)
        Me.exFondo.Name = "exFondo"
        Me.exFondo.Size = New System.Drawing.Size(378, 144)
        Me.exFondo.TabIndex = 0
        Me.exFondo.Text = "ExplorerBar1"
        Me.exFondo.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblValidaDPCard
        '
        Me.lblValidaDPCard.AutoSize = True
        Me.lblValidaDPCard.BackColor = System.Drawing.Color.Transparent
        Me.lblValidaDPCard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidaDPCard.ForeColor = System.Drawing.Color.Red
        Me.lblValidaDPCard.Location = New System.Drawing.Point(56, 72)
        Me.lblValidaDPCard.Name = "lblValidaDPCard"
        Me.lblValidaDPCard.Size = New System.Drawing.Size(256, 16)
        Me.lblValidaDPCard.TabIndex = 231
        Me.lblValidaDPCard.Text = "Validando Tarjeta. Favor de Esperar ..."
        Me.lblValidaDPCard.Visible = False
        '
        'btnImprimirSaldo
        '
        Me.btnImprimirSaldo.Enabled = False
        Me.btnImprimirSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirSaldo.Image = CType(resources.GetObject("btnImprimirSaldo.Image"), System.Drawing.Image)
        Me.btnImprimirSaldo.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImprimirSaldo.Location = New System.Drawing.Point(112, 96)
        Me.btnImprimirSaldo.Name = "btnImprimirSaldo"
        Me.btnImprimirSaldo.Size = New System.Drawing.Size(160, 40)
        Me.btnImprimirSaldo.TabIndex = 234
        Me.btnImprimirSaldo.Text = "Imprimir Saldo"
        Me.btnImprimirSaldo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnLeerDPCard
        '
        Me.btnLeerDPCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerDPCard.Icon = CType(resources.GetObject("btnLeerDPCard.Icon"), System.Drawing.Icon)
        Me.btnLeerDPCard.Location = New System.Drawing.Point(325, 40)
        Me.btnLeerDPCard.Name = "btnLeerDPCard"
        Me.btnLeerDPCard.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerDPCard.TabIndex = 233
        Me.btnLeerDPCard.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNumDPCard
        '
        Me.ebNumDPCard.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumDPCard.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumDPCard.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumDPCard.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumDPCard.Location = New System.Drawing.Point(133, 40)
        Me.ebNumDPCard.Name = "ebNumDPCard"
        Me.ebNumDPCard.Size = New System.Drawing.Size(192, 22)
        Me.ebNumDPCard.TabIndex = 232
        Me.ebNumDPCard.TabStop = False
        Me.ebNumDPCard.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumDPCard.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 16)
        Me.Label16.TabIndex = 230
        Me.Label16.Text = "No. de Tarjeta:"
        '
        'frmSaldoDPCard
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(378, 144)
        Me.Controls.Add(Me.exFondo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmSaldoDPCard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Saldo Club DP"
        CType(Me.exFondo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exFondo.ResumeLayout(False)
        Me.exFondo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '------------------------------------
    'Aqui meteremos los datos del saldo
    '------------------------------------
    Dim NombreTarjeta As String = String.Empty
    Private Resultado As Hashtable
    Dim deslizada As Boolean = False

#Region "Metodos y Funciones"

    Private Function ValidaDPCard() As Boolean

        Dim bResp As Boolean = True
        Me.lblValidaDPCard.Visible = True
        Application.DoEvents()
        Try
            '---------------------------
            'Validamos el DP Card
            '---------------------------
            '------------------------------------------------------------------------------------
            'FLIZARRAGA 16/05/2017: Validacion de Luhn para corroborar si la tarjeta es correcta
            '------------------------------------------------------------------------------------
            If Me.ebNumDPCard.Text.Trim <> String.Empty Then
                If ValidacionLuhn(Me.ebNumDPCard.Text.Trim()) Then
                    '------------------------------
                    ' Limpiamos datos
                    '------------------------------
                    Me.Resultado = Nothing

                    '------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 20/02/2014: Carga el WebService de Status para saber el historial crediticio
                    '------------------------------------------------------------------------------------------------------------------
                    Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

                    Dim AccountStatus = New Hashtable
                    AccountStatus("NoTarjeta") = Me.ebNumDPCard.Text.Trim()
                    AccountStatus("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME().ToString("yyyyMMddHHmmss")
                    AccountStatus("ConsecutivoPOS") = oConfigCierreFI.ConsecutivoPOS
                    AccountStatus("IDPOS") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    'param("IDTienda") = "D3" & oAppContext.ApplicationConfiguration.Almacen.PadLeft(5, "0")
                    AccountStatus("IDTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                    'AccountStatus("Tipo") = "28"

                    '-----------------------------------------------------------------------------
                    'JNAVA (23.03.2015): Especificamos si fue deslizada o Digitada
                    '-----------------------------------------------------------------------------
                    If deslizada = True Then
                        AccountStatus("Tipo") = "00"
                    Else
                        AccountStatus("Tipo") = "01"
                    End If

                    Dim ws As New WSBroker("WS_KARUM", True)
                    Resultado = ws.AccountStatus(AccountStatus)
                    If Resultado.Count > 0 Then
                        If Resultado.ContainsKey("Success") = True Then
                            If CBool(Resultado("Success")) = False Then
                                bResp = False
                                MessageBox.Show(CStr(Resultado("Mensaje")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Else

                                '----------------------------------------------------------------------------------------------
                                'JNAVA (01.06.2015): Mandamos el ID de la tienda (KArum)
                                '----------------------------------------------------------------------------------------------
                                Resultado("IDTienda") = oConfigCierreFI.IDTienda.PadLeft(5, "0")

                                Resultado("NoTarjeta") = Me.ebNumDPCard.Text.Trim()

                                '----------------------------------------------------------------------------------------------
                                'JNAVA (13.03.2015): Si la tarjeta no fue digitada, ponemos el nombre completo
                                '----------------------------------------------------------------------------------------------
                                If Me.NombreTarjeta <> String.Empty Then
                                    Resultado("TarjetaHabiente") = Me.NombreTarjeta
                                End If
                            End If
                        End If
                    Else
                        bResp = False
                        MessageBox.Show("No se pudo verificar el Saldo de la tarjeta DPCard con el Centro de Crédito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If


                End If
            Else
                bResp = False
                MessageBox.Show("Debe cargar los datos de la tarjeta DPCard.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return bResp

        Catch ex As Exception
            MessageBox.Show("Error al validar el DP Card.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "Error al validar el DP Card")
            Limpiar()
        Finally
            Me.lblValidaDPCard.Visible = False
            Application.DoEvents()
        End Try

    End Function

    Private Sub ImprimirSaldo()

        Try

            If Not Resultado Is Nothing AndAlso Resultado.Count > 0 Then
                '------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 20/02/2015: Modifique el reporte para adaptarlo al objeto Hashable donde viene el historial crediticio
                '------------------------------------------------------------------------------------------------------------------
                If Resultado.ContainsKey("Success") = True Then
                    If CBool(Resultado("Success")) = True Then
                        Dim proceso As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                        Resultado("Fecha") = proceso.MSS_GET_SY_DATE_TIME()
                        Dim oARReporte As New rptSaldoDPCard(Resultado)
                        oARReporte.Document.Name = "Saldo DPCard"

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

                        Try
                            oARReporte.Document.Print(False, False)
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try

                    Else
                        MessageBox.Show("No se pudo verificar el número de DPCard. Favor de Verificar con el centro de Credito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            Else
                MessageBox.Show("No se han cargado los datos del DP Card. Favor de verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el Saldo de DP Card.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            EscribeLog(ex.ToString, "-Error al imprimir el Saldo de DP Card..-")
        End Try


    End Sub

    Private Sub Limpiar()

        '------------------------------
        ' Limpiamos datos
        '------------------------------
        Me.Resultado = Nothing

        Me.lblValidaDPCard.Visible = False
        Me.ebNumDPCard.Text = ""
        Me.NombreTarjeta = String.Empty
        Me.btnImprimirSaldo.Enabled = False

    End Sub

#End Region


#Region "Eventos"

    Private Sub btnLeerDPCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerDPCard.Click
        Try
            '-------------------------------------------
            ' Leemos datos de DP Card con la Pinpad
            '-------------------------------------------
            '--------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 21/02/2017: Se valida si son pagos banamex para lecturarlos por su pinpad si no la de Bancomer
            '--------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.PagosBanamex = True Then
                Dim pinpad As New Pinpad.Pinpad()
                Dim bin As String = ""
                'Dim code As String = pinpad.LeerTarjeta("1.00".Replace(",", ""), "0.00", "0", "00")
                Dim code As String = pinpad.LeerTarjeta(CDec(1).ToString("##,##0.00").Replace(",", ""), "0.00", "0", "00")
                If code.Trim() <> "10" AndAlso code.Trim() <> "40" Then
                    Dim Name As String = pinpad.getAppLabel()
                    bin = pinpad.getCardNumber(code)
                    deslizada = True
                    Me.NombreTarjeta = Name
                    Me.ebNumDPCard.Text = bin
                    '----------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 21/02/2017: Enviamos mensaje de transacción exitosa a la pinpad
                    '----------------------------------------------------------------------------------------------------------------
                    pinpad.Respuesta("0", "", "")
                    pinpad.ClosePort()
                    pinpad.sp.Dispose()
                    '-------------------------------------------
                    ' Validamos DP Card
                    '-------------------------------------------
                    If ValidaDPCard() Then
                        Me.btnImprimirSaldo.Enabled = True
                    Else
                        Me.Limpiar()
                    End If
                Else
                    MessageBox.Show("Hubo un error al lecturar la tarjeta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '----------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 21/02/2017: Enviamos mensaje de transacción exitosa a la pinpad
                    '----------------------------------------------------------------------------------------------------------------
                    pinpad.Respuesta("0", "", "")
                    pinpad.ClosePort()
                    pinpad.sp.Dispose()
                End If
            Else
                Dim oOtrosPagos As New OtrosPagos
                oOtrosPagos.LeerDatosDPCard(Me.ebNumDPCard.Text, Me.NombreTarjeta)

                '--------------------------------------------------------------
                'JNAVA (26.03.2015): Especificamos que fue deslizada
                '--------------------------------------------------------------
                deslizada = True

                '-------------------------------------------
                ' Validamos DP Card
                '-------------------------------------------
                If ValidaDPCard() Then
                    Me.btnImprimirSaldo.Enabled = True
                Else
                    Me.Limpiar()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo leer la Tarjeta DP Card. Surgio un error", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "No se pudo leer la Tarjeta DP Card")
        End Try

    End Sub

    Private Sub ebNumDPCard_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumDPCard.Validating
        'Me.NombreTarjeta = String.Empty

        ''--------------------------------------------------------------
        ''JNAVA (26.03.2015): Especificamos que fue deslizada
        ''--------------------------------------------------------------
        'deslizada = False

        'If ValidaDPCard() Then
        '    Me.btnImprimirSaldo.Enabled = True
        'Else
        '    Me.Limpiar()
        'End If
    End Sub

    Private Sub btnImprimirSaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirSaldo.Click
        ImprimirSaldo()
    End Sub

    Private Sub ebNumDPCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumDPCard.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                '--------------------------------------------------------------
                'JNAVA (26.03.2015): Especificamos que no fue deslizada
                '--------------------------------------------------------------
                deslizada = False

                If ValidaDPCard() = True Then
                    Me.btnImprimirSaldo.Enabled = True
                Else
                    Me.Limpiar()
                End If
            Catch ex As Exception
                MessageBox.Show("No se pudo leer la Tarjeta DP Card. Surgio un error", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                EscribeLog(ex.ToString, "No se pudo leer la Tarjeta DP Card")
            End Try

        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/05/2017: Validar que solo sean números
    '--------------------------------------------------------------------------------------------------------------------------

    Private Sub ebNumDPCard_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ebNumDPCard.KeyPress
        ValidarNumeros(e)
    End Sub

#End Region

    
End Class
