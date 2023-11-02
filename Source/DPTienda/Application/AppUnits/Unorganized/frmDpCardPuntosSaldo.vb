Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports Pinpad
Imports System.Collections.Generic

Public Class frmDpCardPuntosSaldo
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
    Friend WithEvents btnLeerDPCard As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebNumDPCard As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblValidaDPCard As System.Windows.Forms.Label
    Friend WithEvents lblMensajeExpiracion As System.Windows.Forms.Label
    Friend WithEvents btnImprimirSaldo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSearch As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDpCardPuntosSaldo))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnSearch = New Janus.Windows.EditControls.UIButton()
        Me.btnImprimirSaldo = New Janus.Windows.EditControls.UIButton()
        Me.lblValidaDPCard = New System.Windows.Forms.Label()
        Me.lblMensajeExpiracion = New System.Windows.Forms.Label()
        Me.btnLeerDPCard = New Janus.Windows.EditControls.UIButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ebNumDPCard = New Janus.Windows.GridEX.EditControls.EditBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnSearch)
        Me.ExplorerBar1.Controls.Add(Me.btnImprimirSaldo)
        Me.ExplorerBar1.Controls.Add(Me.lblValidaDPCard)
        Me.ExplorerBar1.Controls.Add(Me.lblMensajeExpiracion)
        Me.ExplorerBar1.Controls.Add(Me.btnLeerDPCard)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.ebNumDPCard)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Key = "grpDpCardSaldo"
        ExplorerBarGroup1.Text = "DPCard Puntos"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(426, 142)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(368, 40)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(40, 22)
        Me.btnSearch.TabIndex = 242
        Me.btnSearch.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnImprimirSaldo
        '
        Me.btnImprimirSaldo.Enabled = False
        Me.btnImprimirSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirSaldo.Image = CType(resources.GetObject("btnImprimirSaldo.Image"), System.Drawing.Image)
        Me.btnImprimirSaldo.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImprimirSaldo.Location = New System.Drawing.Point(133, 96)
        Me.btnImprimirSaldo.Name = "btnImprimirSaldo"
        Me.btnImprimirSaldo.Size = New System.Drawing.Size(160, 40)
        Me.btnImprimirSaldo.TabIndex = 241
        Me.btnImprimirSaldo.Text = "Imprimir Saldo"
        Me.btnImprimirSaldo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblValidaDPCard
        '
        Me.lblValidaDPCard.AutoSize = True
        Me.lblValidaDPCard.BackColor = System.Drawing.Color.Transparent
        Me.lblValidaDPCard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidaDPCard.ForeColor = System.Drawing.Color.Red
        Me.lblValidaDPCard.Location = New System.Drawing.Point(85, 72)
        Me.lblValidaDPCard.Name = "lblValidaDPCard"
        Me.lblValidaDPCard.Size = New System.Drawing.Size(256, 16)
        Me.lblValidaDPCard.TabIndex = 239
        Me.lblValidaDPCard.Text = "Validando Tarjeta. Favor de Esperar ..."
        Me.lblValidaDPCard.Visible = False
        '
        'lblMensajeExpiracion
        '
        Me.lblMensajeExpiracion.BackColor = System.Drawing.Color.Transparent
        Me.lblMensajeExpiracion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeExpiracion.Location = New System.Drawing.Point(37, 64)
        Me.lblMensajeExpiracion.Name = "lblMensajeExpiracion"
        Me.lblMensajeExpiracion.Size = New System.Drawing.Size(352, 24)
        Me.lblMensajeExpiracion.TabIndex = 240
        Me.lblMensajeExpiracion.Text = "Mensaje descriptivo del vencimiento de la dpcard para el cajero"
        '
        'btnLeerDPCard
        '
        Me.btnLeerDPCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerDPCard.Icon = CType(resources.GetObject("btnLeerDPCard.Icon"), System.Drawing.Icon)
        Me.btnLeerDPCard.Location = New System.Drawing.Point(328, 40)
        Me.btnLeerDPCard.Name = "btnLeerDPCard"
        Me.btnLeerDPCard.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerDPCard.TabIndex = 236
        Me.btnLeerDPCard.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 16)
        Me.Label16.TabIndex = 234
        Me.Label16.Text = "No. de Tarjeta:"
        '
        'ebNumDPCard
        '
        Me.ebNumDPCard.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumDPCard.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumDPCard.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumDPCard.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumDPCard.Location = New System.Drawing.Point(136, 40)
        Me.ebNumDPCard.Name = "ebNumDPCard"
        Me.ebNumDPCard.Size = New System.Drawing.Size(192, 22)
        Me.ebNumDPCard.TabIndex = 235
        Me.ebNumDPCard.TabStop = False
        Me.ebNumDPCard.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumDPCard.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmDpCardPuntosSaldo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(426, 142)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDpCardPuntosSaldo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saldo DPCard Puntos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '------------------------------------
    'Aqui meteremos los datos del saldo
    '------------------------------------
    Dim NombreTarjeta As String = String.Empty
    Private Resultado As Hashtable
    Private Provider As Integer
    Private Deslizada As Boolean = False
    '-----------------------------------------------------------------------------------------
    'FLIZARRAGA 14/09/2017: Se agrega la lista de errores de la pinpad
    '-----------------------------------------------------------------------------------------
    Private ListaErroresBanamex As New List(Of String)() From {"02", "06", "08", "10", "11", "16", "17", "40", "79"}
    'Dim deslizada As Boolean = False

#Region "Metodos y Funciones"

    Private Sub ValidaDPCard()

        Dim bResp As Boolean = True
        Me.lblValidaDPCard.Visible = True
        Application.DoEvents()
        'ASANCHEZ declaro la variable de tipo_ que se usa cuando es
        Dim tipo_ As String = String.Empty
        Try
            '---------------------------
            'Validamos el DP Card
            '---------------------------
            '------------------------------------------------------------------------------------
            'FLIZARRAGA 16/05/2017: Validacion de Luhn para corroborar si la tarjeta es correcta
            '------------------------------------------------------------------------------------
            'If ValidacionLuhn(Me.ebNumDPCard.Text.Trim()) Then
            If Me.ebNumDPCard.Text.Trim <> String.Empty Then

                '------------------------------
                ' Limpiamos datos
                '------------------------------
                Me.Resultado = Nothing
                Me.lblMensajeExpiracion.Text = ""

                '------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 20/02/2014: Carga el WebService de Status para saber el historial crediticio
                '------------------------------------------------------------------------------------------------------------------
                Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim fecha As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
                Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
                '----------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 24/08/2016: Validamos Proveedor de puntos
                '----------------------------------------------------------------------------------------------------------------------
                If ebNumDPCard.Text.Trim().Length = 16 Or ebNumDPCard.Text.Trim().Length = 13 Then
                    If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                        Dim bin As Integer = CInt(ebNumDPCard.Text.Substring(0, 6))
                        If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                            Me.Provider = Proveedor.KARUM
                        Else
                            Me.Provider = Proveedor.BLUE
                        End If
                    Else
                        'Saca el tipo de bin que estara consultando
                        If ebNumDPCard.Text.Trim().Length = 13 Then
                            tipo_ = "CFB"
                        Else
                            tipo_ = consulta_bin_tipo_blue(ebNumDPCard.Text.Trim())
                        End If

                    End If
                Else
                    Me.Provider = Proveedor.KARUM
                    ebNumDPCard.Text = ebNumDPCard.Text.PadLeft(16, "0")
                End If

                'ASANCHEZ validamos si trae un providen si no trae entonces que consulte a los nuevos servicios de blue
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    Dim AccountStatus = New Hashtable
                    AccountStatus("cardId") = Me.ebNumDPCard.Text.Trim()
                    AccountStatus("transactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                    AccountStatus("ticketid") = ""

                    '-------------------------------------
                    'FLIZARRAGA 24/08/2016: Validamos que proveedor de Puntos es para poder asignar los valores a parametros de Webservices
                    '----------------------------------------------------------------------------------------------------------------------
                    If Me.Provider = Proveedor.BLUE Then
                        AccountStatus("storeid") = oAppContext.ApplicationConfiguration.Almacen
                        AccountStatus("referenceId3") = ""
                        AccountStatus("referenceId4") = ""

                    Else
                        AccountStatus("storeid") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                        AccountStatus("referenceId3") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                        AccountStatus("referenceId4") = oConfigCierreFI.ConsecutivoPuntosPOS
                        If Deslizada = True Then
                            AccountStatus("tipo") = "00"
                        Else
                            AccountStatus("tipo") = "01"
                        End If
                    End If

                    'AccountStatus("storeid") = "004"
                    '-----------------------------------------------------------------------------

                    AccountStatus("cashierCode") = oAppContext.Security.CurrentUser.ID
                    AccountStatus("cashierName") = oAppContext.Security.CurrentUser.Name.Trim
                    AccountStatus("supervisorCode") = oAppContext.Security.CurrentUser.ID
                    AccountStatus("supervisorName") = oAppContext.Security.CurrentUser.Name.Trim
                    AccountStatus("sellerCode") = oAppContext.Security.CurrentUser.ID
                    AccountStatus("sellerName") = oAppContext.Security.CurrentUser.Name.Trim

                    '-----------------------------------------------------------------------------
                    'JNAVA (23.03.2015): Especificamos si fue deslizada o Digitada
                    '-----------------------------------------------------------------------------
                    'If deslizada = True Then
                    'AccountStatus("Tipo") = "00"
                    'Else
                    'AccountStatus("Tipo") = "01"
                    'End If

                    Dim ws As New WSBroker("WS_BLUE", True)
                    Resultado = ws.GetBalance(AccountStatus)
                    'If Me.Provider = Proveedor.KARUM Then
                    '    ActualizarConsecutivoPuntosPOS()
                    'End If
                    If Resultado.Count > 0 Then
                        If Resultado.ContainsKey("ResultId") = True Then
                            If CInt(Resultado("ResultId")) < 0 Then
                                bResp = False
                                MessageBox.Show(CStr(Resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Else
                                PrintHashtable(Resultado)
                                'Resultado("NoTarjeta") = Me.ebNumDPCard.Text.Trim()
                                '----------------------------------------------------------------------------------------------
                                'JNAVA (13.03.2015): Si la tarjeta no fue digitada, ponemos el nombre completo
                                '----------------------------------------------------------------------------------------------
                                'If Me.NombreTarjeta <> String.Empty Then
                                'Resultado("TarjetaHabiente") = Me.NombreTarjeta
                                'End If

                                '----------------------------------------------------------------------------------------------
                                'JNAVA (08.04.2015): Agregamos el consecutivo POS para mostrarlo en el Saldo
                                '----------------------------------------------------------------------------------------------
                                'Resultado("ConsecutivoPOS") = CStr(oConfigCierreFI.ConsecutivoPOS - 1).PadLeft(4, "0")
                                If Me.Provider = Proveedor.BLUE Then
                                    Me.lblMensajeExpiracion.Text = CStr(Resultado("ExpireStatusDescriptionSeller")).Trim
                                Else
                                    Resultado("NoTarjeta") = CStr(AccountStatus("cardId"))
                                    Resultado("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME()
                                    Resultado("IDTienda") = oConfigCierreFI.IDTienda.PadLeft(5, "0")
                                    Resultado("TarjetaHabiente") = Me.NombreTarjeta

                                End If
                                Me.btnImprimirSaldo.Enabled = True
                                Me.btnImprimirSaldo.Focus()
                            End If
                        End If
                    Else
                        bResp = False
                        MessageBox.Show("No se pudo verificar el Saldo de la tarjeta DPCard con el Centro de Crédito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    'ASANCHEZ 29/03/2021 empiezo armar la nueva petición de blue
                    If tipo_.Trim() = "DB" Then
                        Me.Provider = Proveedor.BLUE
                        Dim AccountStatus = New Hashtable
                        AccountStatus("cardId") = Me.ebNumDPCard.Text.Trim()
                        AccountStatus("transactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                        AccountStatus("ticketid") = ""
                        AccountStatus("storeid") = oAppContext.ApplicationConfiguration.Almacen
                        AccountStatus("referenceId3") = ""
                        AccountStatus("referenceId4") = ""
                        AccountStatus("cashierCode") = oAppContext.Security.CurrentUser.ID
                        AccountStatus("cashierName") = oAppContext.Security.CurrentUser.Name.Trim
                        AccountStatus("supervisorCode") = oAppContext.Security.CurrentUser.ID
                        AccountStatus("supervisorName") = oAppContext.Security.CurrentUser.Name.Trim
                        AccountStatus("sellerCode") = oAppContext.Security.CurrentUser.ID
                        AccountStatus("sellerName") = oAppContext.Security.CurrentUser.Name.Trim
                        Dim ws As New WSBroker("WS_BLUE", True)
                        Resultado = ws.GetBalance(AccountStatus)
                        If Resultado.Count > 0 Then
                            If Resultado.ContainsKey("ResultId") = True Then
                                If CInt(Resultado("ResultId")) < 0 Then
                                    bResp = False
                                    MessageBox.Show(CStr(Resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Else
                                    PrintHashtable(Resultado)
                                    If Me.Provider = Proveedor.BLUE Then
                                        Me.lblMensajeExpiracion.Text = CStr(Resultado("ExpireStatusDescriptionSeller")).Trim
                                    Else
                                        Resultado("NoTarjeta") = CStr(AccountStatus("cardId"))
                                        Resultado("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME()
                                        Resultado("IDTienda") = oConfigCierreFI.IDTienda.PadLeft(5, "0")
                                        Resultado("TarjetaHabiente") = Me.NombreTarjeta

                                    End If
                                    Me.btnImprimirSaldo.Enabled = True
                                    Me.btnImprimirSaldo.Focus()
                                End If
                            End If
                        Else
                            bResp = False
                            MessageBox.Show("No se pudo verificar el Saldo de la tarjeta DPCard con el Centro de Crédito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        Dim oBluegetBalance As Dictionary(Of String, Object)
                        oBluegetBalance = New Dictionary(Of String, Object)
                        oBluegetBalance.Add("cardId", Me.ebNumDPCard.Text.Trim())
                        'oBluegetBalance.Add("cardId", Me.ebNumDPCard.Text.Trim())
                        oBluegetBalance.Add("transactionDate", fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss"))
                        oBluegetBalance.Add("ticketId", "")
                        oBluegetBalance.Add("storeId", oAppContext.ApplicationConfiguration.Almacen)
                        oBluegetBalance.Add("referenceId3", "")
                        oBluegetBalance.Add("referenceId4", "")
                        oBluegetBalance.Add("cashierCode", oAppContext.Security.CurrentUser.ID)
                        oBluegetBalance.Add("supervisorCod", oAppContext.Security.CurrentUser.Name.Trim)
                        oBluegetBalance.Add("supervisorName", oAppContext.Security.CurrentUser.ID)
                        oBluegetBalance.Add("sellerCode", oAppContext.Security.CurrentUser.ID)
                        oBluegetBalance.Add("sellerName", oAppContext.Security.CurrentUser.Name.Trim)
                        Dim ws As New WSBroker("blue_api_s1", "GetBalance")
                        Dim rs_ As Dictionary(Of String, Object)
                        Resultado = ws.nuevos_servicios_blue(oBluegetBalance)
                        If Resultado.Count = 0 Then
                            bResp = False
                            MessageBox.Show("No se pudo verificar el Saldo de la tarjeta DPCard con el Centro de Crédito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            If CInt(Resultado("ResultID")) > 0 Then
                                If Resultado.ContainsKey("CardID") = True Then
                                    If Resultado("CardID") = "" Then
                                        Resultado("CardID") = Me.ebNumDPCard.Text.Trim()
                                    End If
                                    Resultado("NoTarjeta") = CStr(Me.ebNumDPCard.Text.Trim())
                                    Resultado("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME()
                                    Resultado("IDTienda") = oAppContext.ApplicationConfiguration.Almacen
                                End If
                                Me.btnImprimirSaldo.Enabled = True
                                Me.btnImprimirSaldo.Focus()
                            Else
                                bResp = False
                                MessageBox.Show(CStr(Resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If

                        End If
                    End If
                End If
            Else
                bResp = False
                MessageBox.Show("Debe cargar los datos de la tarjeta DPCard.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            If bResp = False Then Me.Limpiar()
            'End If
        Catch ex As Exception
            MessageBox.Show("Error al validar el DP Card.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "Error al validar el DP Card")
            Limpiar()
        Finally
            Me.lblValidaDPCard.Visible = False
            Application.DoEvents()
        End Try

    End Sub

    Private Sub ImprimirSaldo()

        Try

            If Not Resultado Is Nothing AndAlso Resultado.Count > 0 Then
                If Resultado.ContainsKey("ResultId") = True Then
                    If CInt(Resultado("ResultId")) > 0 Then
                        Dim oARReporte As Object

                        If Me.Provider = Proveedor.BLUE Then
                            oARReporte = New rptSaldoDPCardPuntos(Resultado)
                        Else
                            oARReporte = New rptSaldoDPCardPuntosKarum(Resultado)
                        End If


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
                Else
                    If oConfigCierreFI.ServiciosBlueBonificacion = "True" Then
                        Dim tipo_ As String = String.Empty
                        tipo_ = consulta_bin_tipo_blue(ebNumDPCard.Text.Trim())
                        Dim oARReporte As Object
                        If tipo_.Trim() = "DB" Then
                            oARReporte = New rptSaldoDPCardPuntos(Resultado)
                        Else
                            oARReporte = New rptSaldoDPCardPuntosKarum(Resultado)
                        End If
                        If Resultado.ContainsKey("ResultID") = True Then
                            If CInt(Resultado("ResultID")) > 0 Then

                                'oARReporte = New rptSaldoDPCardPuntos(Resultado)

                                oARReporte.Document.Name = "Saldo DPCard"

                                If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

                                    oARReporte.PageSettings.PaperHeight = 7
                                    oARReporte.PageSettings.PaperWidth = 14
                                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
                                    oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
                                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                                End If

                                oARReporte.Run()
                                Try
                                    oARReporte.Document.Print(False, False)
                                Catch ex As Exception
                                    MsgBox(ex.ToString)
                                End Try
                            Else
                                MessageBox.Show("No se pudo verificar el número de DPCard. Favor de Verificar con el centro de Credito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        End If

                    End If
                End If
            Else
                MessageBox.Show("No se han cargado los datos del DP Card. Favor de verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el Saldo de DP Card.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "-Error al imprimir el Saldo de DP Card..-")
        End Try

    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 07/05/2014: Imprime el resultado del response
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintHashtable(ByVal result As Hashtable)
        For Each str As String In result.Keys
            Console.WriteLine(str & ": " & CStr(result(str)))
        Next
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
        Me.lblMensajeExpiracion.Text = ""

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
                Dim code As String = pinpad.LeerTarjeta(CDec(1).ToString("##,##0.00").Replace(",", ""), "0.00", "0", "00")
                'Dim code As String = pinpad.LeerTarjeta(CDec(EBPago.Value).ToString("##,##0.00").Replace(",", ""), "0.00", "0", "00")
                If ListaErroresBanamex.Contains(code.Trim()) = False Then
                    'Dim Name As String = pinpad.getAppLabel()
                    Dim Name As String = pinpad.getName(code)
                    bin = pinpad.getCardNumber(code)
                    Deslizada = True
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
                    ValidaDPCard()
                Else
                    MessageBox.Show("Hubo un error al lecturar la tarjeta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '----------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 21/02/2017: Enviamos mensaje de transacción exitosa a la pinpad
                    '----------------------------------------------------------------------------------------------------------------
                    If code.Trim() = "10" Or code.Trim() = "40" Then
                        pinpad.Respuesta("0", "", "")
                    End If
                    pinpad.ClosePort()
                    pinpad.sp.Dispose()
                End If
            Else
                Dim oOtrosPagos As New OtrosPagos
                oOtrosPagos.LeerDatosDPCard(Me.ebNumDPCard.Text, Me.NombreTarjeta)

                '--------------------------------------------------------------
                'JNAVA (14.04.2015): Especificamos que fue deslizada
                '--------------------------------------------------------------
                Deslizada = True

                '-------------------------------------------
                ' Validamos DP Card
                '-------------------------------------------
                ValidaDPCard()
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo leer la Tarjeta DP Card Puntos. Surgio un error", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "No se pudo leer la Tarjeta DP Card Puntos")
        End Try

    End Sub

    Private Sub ebNumDPCard_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumDPCard.Validating
        'Me.NombreTarjeta = String.Empty

        'deslizada = False

        ValidaDPCard()
    End Sub

    Private Sub ebNumDPCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumDPCard.KeyDown
        'deslizada = False

        Select Case e.KeyCode
            Case Keys.Enter
                Deslizada = False
                Me.btnLeerDPCard.Focus()
        End Select

    End Sub

    Private Sub frmSaldoDPCard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblMensajeExpiracion.Text = ""
    End Sub

    Private Sub btnImprimirSaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirSaldo.Click
        ImprimirSaldo()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim frmSearch As New frmDPCardPuntoSearch
        frmSearch.ShowDialog()
        If frmSearch.DialogResult = DialogResult.OK Then
            Me.ebNumDPCard.Text = frmSearch.CardId
            ValidaDPCard()
            Me.btnImprimirSaldo.Focus()
        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/05/2017: Validar que solo sean números
    '--------------------------------------------------------------------------------------------------------------------------

    Private Sub ebNumDPCard_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ebNumDPCard.KeyPress
        ValidarNumeros(e)
    End Sub

#End Region

End Class
