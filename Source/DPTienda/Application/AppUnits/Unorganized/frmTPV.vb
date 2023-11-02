Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores

Public Class frmTPV

    Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
    Dim oCatalogoBancoMgr As New CatalogoBancosManager(oAppContext)
    Dim dsBanco As DataSet
    Dim oVendedor As Vendedor
    Dim oVendedoresMgr As New CatalogoVendedoresManager(oAppContext)

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        oVendedor = oVendedoresMgr.Create
        FillBancos()
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLeerTarjeta_Click(sender As System.Object, e As System.EventArgs) Handles btnLeerTarjeta.Click
        Me.btnLeerTarjeta.Enabled = False
        AutorizarCargoTarjeta()
        Me.btnLeerTarjeta.Enabled = True
    End Sub

    Private Sub FillBancos()

        dsBanco = oCatalogoBancoMgr.GetAll(False)
        ebCodBanco.DataSource = dsBanco.Tables(0)
        ebCodBanco.DropDownList.Columns.Add("Cod. Banco")
        ebCodBanco.DropDownList.Columns.Add("Descripcion")
        ebCodBanco.DropDownList.Columns("Cod. Banco").DataMember = "CodBanco"
        ebCodBanco.DropDownList.Columns("Descripcion").DataMember = "Descripcion"
        ebCodBanco.DropDownList.Columns("Cod. Banco").Width = 50
        ebCodBanco.DropDownList.Columns("Descripcion").Width = 150
        ebCodBanco.DisplayMember = "CodBanco"
        ebCodBanco.ValueMember = "CodBanco"
        ebCodBanco.Refresh()

    End Sub

    Private Function AutorizarCargoTarjeta() As Boolean

        Dim Band As Boolean = True
        Dim oApp As Process
        Dim oProcesos() As Process
        Dim pagoTarj As Decimal = 0
        Dim x As New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
        Dim mSalida As String = ""
        Dim mPOSEntry As String = ""       '22        
        Dim mTrack2 As String = ""        '35        
        Dim mRespose As String = ""        '61
        Dim mHTerm As String = ""
        Dim mHCajero As String = ""
        Dim mHTienda As String = ""
        Dim mHTicket As String = ""
        Dim mHMeses As String = ""
        Dim mHSkip As String = ""
        Dim mHFijo As String = ""
        Dim mAutorizacion As String = ""
        Dim Mensaje As String = ""
        Dim Mensaje46 As String = ""
        Dim mRespcode As String = ""
        Dim mDummy As String = ""
        Dim mOperacion As String = ""
        Dim mAfiliacion As String = ""
        Dim mCVV2 As String = ""
        Dim mRespuesta As String = ""
        Dim mComentario As String = ""
        Dim strNombre As String = ""
        Dim strCriptograma As String = ""
        Dim strCardSN As String = ""
        Dim strEmisor As String = ""

        pagoTarj = CDec(EBPago.Value)

        Dim strVencimiento As String = ""
        Dim strPromocion As String = ""
        Dim strNum As String = "" '(ebNumTarj.Text).Replace(";", "")

        'If Me.EBPago.Value > oConfigCierreFI.MontoMaxTarjetas Then
        '    oAppContext.Security.CloseImpersonatedSession()
        '    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
        '        MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Me.ebNumTarj.Text = ""
        '        Band = False
        '        GoTo Final
        '    Else
        '        oAppContext.Security.CloseImpersonatedSession()
        '    End If
        '    'ElseIf oCatFormaPago.TarjetaUsadaHoy(strNum) OrElse BuscaTarjeta(strNum) = True Then
        '    '    oAppContext.Security.CloseImpersonatedSession()
        '    '    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
        '    '        If mPOSEntry.Trim = "051" Then
        '    '            Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
        '    '        End If
        '    '        MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    '        Me.ebNumTarj.Text = strNum
        '    '        Band = False
        '    '        GoTo Final
        '    '    Else
        '    '        oAppContext.Security.CloseImpersonatedSession()
        '    '    End If
        'End If

        'INICIO Consulta de promociones
        'Dim strProSkip, strProMeses As String
        'mTrack2 = (ebNumTarj.Text).Replace(";", "")
        'mTrack2 = (mTrack2).Replace("?", "")
        mHTienda = oAppContext.ApplicationConfiguration.Almacen
        mHTerm = oAppContext.ApplicationConfiguration.NoCaja
        mHCajero = Me.ebCodVendedor.Text.Trim

        'mSalida = x.PagoTarjeta(mHTienda, mHTerm, mHCajero, "000001", mPOSEntry, mTrack2, _
        'CDbl(EBPago.Text), mHTicket, mComentario, mRespuesta, _
        'strCardSN, "", mHMeses, mHSkip, mCVV2)

        'strProMeses = ""
        'strProSkip = ""

        'mDummy = mSalida
        'Do While Len(mDummy) > 0
        '    mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
        '    mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
        '    If InStr(mRespose, "39==") > 0 Then
        '        mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
        '    End If
        '    If InStr(mRespose, "43==") > 0 Then
        '        Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
        '        If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
        '    End If
        '    If InStr(mRespose, "46==") > 0 Then
        '        Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
        '    End If

        'Loop
        'Mensaje46 = "0100Normal              |06006 Meses Sin Intereses|120012 Meses Sin Intereses|"
        'mRespcode = "00"
        'If mRespcode = "00" And InStr(Mensaje46, "|") > 0 Then
        '    'Mando llamar la pantalla para seleccionar la promocion del pago
        '    Dim ofrm As New frmPromociones(Mensaje46)
        '    If ofrm.ShowDialog() = DialogResult.OK Then
        '        strProMeses = ofrm.Plazo
        '        strProSkip = ofrm.Skip
        '        strPromocion = ofrm.ebPromocion.Text
        '        intPromo = CInt(strProMeses)
        '    Else
        '        Me.ebNumTarj.Text = ""
        '        Me.txtCVV2.Text = ""
        '        Me.txtCVV2.Focus()

        '        Band = False
        '        GoTo Final
        '        'Exit Function
        '    End If
        'End If
        'FIN Consulta de promociones

        'Limpiamos las variables que pudieron ser afectadas en la consulta de promociones
        Dim mFirma As String = ""
        Dim mLote As String = ""
        Dim mSubtechTermID As String = ""
        Dim mTrace As String = ""


        x = New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
        mRespcode = ""
        Mensaje = ""
        Mensaje46 = ""

        On Error Resume Next

        'mHRecordType = 2
        'mPOSEntry = Datos(3) & "1"
        'mTrack2 = (ebNumTarj.Text).Replace(";", "")
        'mTrack2 = (mTrack2).Replace("?", "")
        'ebNumTarj.Text = strNum

        'El ticket debe de variar, ver de donde se va a sacar el consecutivo
        mHTicket = oAppSAPConfig.Ticket

        mSalida = ""
        mDummy = ""
        mOperacion = "000000"
        mHMeses = ""
        mHSkip = ""
        mCVV2 = ""

        'Select Case CInt(mHRecordType)
        '    Case 1 'mHCVV2 = "    " 'Consulta Planes
        '        mCVV2 = "    "
        '        mOperacion = "000001"
        '    Case 2 : mOperacion = "000000" 'CreditAuth
        '        mHMeses = strProMeses
        '        mHSkip = strProSkip
        '        'mHCVV2 = txtCVV2.Text
        '        mCVV2 = Trim(txtCVV2.Text)
        '        'Case 3 : mOperacion = "000003" 'ConsCteFrec
        '        'Case 4 : mOperacion = "000004" 'ActCteFrec
        '        '    mCarPun = txtCargoPun.Text
        '        '    mCrePun = txtAbonoPun.Text
        '        '    mCarDin = txtCargoDin.Text
        '        '    mCreDin = txtAbonoDin.Text
        '        '    mAmount = mCarPun & "|" & mCrePun & "|" & mCarDin & "|" & mCreDin
        '        'Case 5 : mOperacion = "000005" 'CatalogoCiaCelular
        '        'Case 6 : mOperacion = "000006" 'PlanCelular
        '        'Case 7 : mOperacion = "000007" 'VentaTACelular
        '        '    mHMeses = txtSkip.Text
        '        '    mHSkip = txtMeses.Text
        '        'Case 8 : mOperacion = "000008" 'PeticionVenta
        '        'Case 9 : mOperacion = "000009" 'ConsultaSaldo
        '        'Case 10 : mOperacion = "000010" 'ActTarjetaRegalo
        '        '    mHCargo = txtCargoDin.Text
        '        '    mHCredito = txtAbonoDin.Text
        '        '    If mHCredito > 0 Then
        '        '        mAmount = mHCredito
        '        '        mOperacion = "000110"
        '        '    Else
        '        '        mAmount = mHCargo
        '        '    End If
        '        'Case 11 : mOperacion = "000011" 'ConsultaBono
        'End Select

        'mPOSEntry = ""
        mTrack2 = ""
        strCardSN = ""
        oProcesos = Process.GetProcessesByName("eHubEMV")
        If oProcesos.Length < 1 Then
            Process.Start(Application.StartupPath & "\eHubEMV.exe")
        End If
        Console.WriteLine("Tienda: " & mHTienda)
        Console.WriteLine("HTerm: " & mHTerm)
        Console.WriteLine("Cajero: " & mHCajero)
        Console.WriteLine("POSEntry: " & mPOSEntry)
        Console.WriteLine("Track2: " & mTrack2)
        Console.WriteLine("Pago: " & EBPago.Text)
        Console.WriteLine("HTicket: " & mHTicket)
        Console.WriteLine("Comentario: " & mComentario)
        Console.WriteLine("Respuesta: " & mRespuesta)
        Console.WriteLine("CardSN: " & strCardSN)
        Console.WriteLine("mHMeses: " & mHMeses)
        Console.WriteLine("mHSkip: " & mHSkip)
        Console.WriteLine("mCVV2: " & mCVV2)
        mSalida = x.PagoTarjeta(mHTienda, mHTerm, mHCajero, "000000", mPOSEntry, mTrack2, _
                                CDbl(EBPago.Text), mHTicket, mComentario, mRespuesta, strCardSN, _
                                "", mHMeses, mHSkip, mCVV2)
        mHTicket = ""
        mDummy = mSalida
        Debug.Write(mSalida & vbCrLf & "".PadLeft(50, "_"))
        Do While Len(mDummy) > 0
            mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
            mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
            If InStr(mRespose, "22==") > 0 Then
                mPOSEntry = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
            End If
            If InStr(mRespose, "35==") > 0 Then
                mTrack2 = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
            End If
            If InStr(mRespose, "38==") > 0 Then
                mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
            End If
            If InStr(mRespose, "39==") > 0 Then
                mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
            End If
            If InStr(mRespose, "43==") > 0 Then
                Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
            End If
            If InStr(mRespose, "46==") > 0 Then
                Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                Mensaje46 = Replace(Mensaje46, "|", vbCrLf)
            End If
            If InStr(mRespose, "48==") > 0 Then
                mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
            End If
            If InStr(mRespose, "61==") > 0 Then
                mFirma = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
            End If
            If InStr(mRespose, "62==") > 0 Then
                mSubtechTermID = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
            End If
            If InStr(mRespose, "63==") > 0 Then
                mLote = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
            End If
            If InStr(mRespose, "64==") > 0 Then
                mTrace = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
            End If
            If InStr(mRespose, "65==") > 0 Then
                mHTicket = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
            End If
        Loop

        ''''I. Actualizamos Ticket.
        Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
        Dim oSApReader As New SapConfigReader(strConfigurationFile)
        oAppSAPConfig.Ticket = oAppSAPConfig.Ticket + 1
        oSApReader.SaveSettings(oAppSAPConfig)
        ''''F. Actualizamos Ticket.
        Dim intPromo As Integer = 0

        If mRespcode.Trim = "00" AndAlso mAutorizacion.Trim <> "" AndAlso mAfiliacion.Trim <> "" Then

            Dim strTrack2() As String = mTrack2.Split("=")

            Me.ebNumTarj.Text = strTrack2(0).Replace(";", "")
            strNum = Me.ebNumTarj.Text.Trim
            strVencimiento = strTrack2(1).Substring(2, 2) & "/" & strTrack2(1).Substring(0, 2)
            If mPOSEntry.Trim = "051" Then
                Dim strMsgs() As String = Mensaje46.Split(",")
                strCriptograma = strMsgs(strMsgs.Length - 1).Trim
                If InStr(strCriptograma, "ARQC") <= 0 Then strCriptograma = ""
            End If

            If InStr(Mensaje46, "3 MESES") > 0 Then
                strPromocion = "3 Meses Sin Intereses"
                intPromo = 3
            ElseIf InStr(Mensaje46, "6 MESES") > 0 Then
                strPromocion = "6 Meses Sin Intereses"
                intPromo = 6
            ElseIf InStr(Mensaje46, "9 MESES") > 0 Then
                strPromocion = "9 Meses Sin Intereses"
                intPromo = 9
            ElseIf InStr(Mensaje46, "12 MESES") > 0 Then
                strPromocion = "12 Meses Sin Intereses"
                intPromo = 12
            ElseIf InStr(Mensaje46, "15 MESES") > 0 Then
                strPromocion = "15 Meses Sin Intereses"
                intPromo = 15
            ElseIf InStr(Mensaje46, "18 MESES") > 0 Then
                strPromocion = "18 Meses Sin Intereses"
                intPromo = 18
            Else
                strPromocion = "Normal"
                intPromo = 1
            End If

            Mensaje = ""
            Mensaje = oFacturaMgr.BancoAutorizador(Me.ebNumTarj.Text, intPromo).ToUpper

            strEmisor = EBBanco.Text

            If InStr(Mensaje, "BANAMEX") > 0 Then
                ebCodBanco.Text = "T3"
                ebCodBanco.Value = "T3"
                EBBanco.Text = "BANAMEX"
            ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
                ebCodBanco.Text = "T1"
                ebCodBanco.Value = "T1"
                EBBanco.Text = "BANCOMER"
            ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
                ebCodBanco.Text = "T2"
                ebCodBanco.Value = "T2"
                EBBanco.Text = "SANTANDER"
            End If

            ' Me.ebTipoTarjeta.Value = "TE"

            'Transaccion Exitosa
            Me.ebAutorizacion.Text = mAutorizacion
            'Me.strNoAfiliacion = mAfiliacion

            'bolCargoEHub = True
            MsgBox("Transacción Exitosa" & Microsoft.VisualBasic.vbCrLf & "Preparar Miniprinter", MsgBoxStyle.Information, "Dportenis PRO")

            Dim bolReimpresion As Boolean = False
            Dim oReportV As ReportViewerForm
Reimprimir:
            Select Case ebCodBanco.Text

                Case "T3"
Imprime_Banamex:
                    ''Original Banco
                    Dim oARReporte As New rptTicketBANAMEX(pagoTarj, strNum, strVencimiento, _
                                                           mAutorizacion, strPromocion, "VENTA", _
                                                           strNombre, Me.ebCodVendedor.Text.Trim, _
                                                           mAfiliacion, strEmisor, "ORIGINAL BANCO", _
                                                           mFirma, strCriptograma, True, mHTicket, mLote, _
                                                           mTrace, mSubtechTermID)
                    oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oARReporte.Run()
                    oARReporte.Document.Print(False, False)

                    ''Copia Cliente
                    Dim oARReporteC As New rptTicketBANAMEX(pagoTarj, strNum, strVencimiento, _
                                                            mAutorizacion, strPromocion, "VENTA", _
                                                            strNombre, Me.ebCodVendedor.Text.Trim, _
                                                            mAfiliacion, strEmisor, "COPIA CLIENTE", _
                                                            mFirma, strCriptograma, True, mHTicket, mLote, _
                                                           mTrace, mSubtechTermID)
                    oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                    oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oARReporteC.Run()
                    oARReporteC.Document.Print(False, False)

                    oReportV = New ReportViewerForm
                    oReportV.Report = oARReporte
                    oReportV.Show()

                    oReportV = New ReportViewerForm
                    oReportV.Report = oARReporteC
                    oReportV.Show()

                Case "T1"

                    Dim oARReporte As New rptTicketBancomer(pagoTarj, strNum, strVencimiento, _
                                                            mAutorizacion, strPromocion, "VENTA", _
                                                            strNombre, Me.ebCodVendedor.Text.Trim, _
                                                            mAfiliacion, EBBanco.Text, "ORIGINAL BANCO", _
                                                            mPOSEntry, True, True, strCriptograma, _
                                                            mFirma)
                    oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oARReporte.Run()
                    oARReporte.Document.Print(False, False)

                    'Copia Cliente
                    Dim oARReporteC As New rptTicketBancomer(pagoTarj, strNum, strVencimiento, _
                                                            mAutorizacion, strPromocion, "VENTA", _
                                                            strNombre, Me.ebCodVendedor.Text.Trim, _
                                                            mAfiliacion, EBBanco.Text, "COPIA CLIENTE", _
                                                            mPOSEntry, True, True, strCriptograma, _
                                                            mFirma)
                    oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                    oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oARReporteC.Run()
                    oARReporteC.Document.Print(False, False)

                    oReportV = New ReportViewerForm
                    oReportV.Report = oARReporte
                    oReportV.Show()

                    oReportV = New ReportViewerForm
                    oReportV.Report = oARReporteC
                    oReportV.Show()

                Case Else

                    GoTo Imprime_Banamex

            End Select

            If bolReimpresion = False Then
                If MessageBox.Show("¿Desea reimprimir los vouchers?", "Dportenis Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    bolReimpresion = True
                    GoTo Reimprimir
                End If
            End If

            ' Me.uitnAgregar.Focus()
            ' Me.uitnAgregar.PerformClick()

        ElseIf mRespcode = "06" Then

            MessageBox.Show("El tiempo de espera para deslizar / insertar la tarjeta ha terminado." & vbCrLf & _
                            "Por favor, Intente de nuevo.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Band = False
            GoTo Final

        ElseIf mRespcode.Trim = "95" Then

            'Transaccion Cancelada
            Band = False
            Me.btnLeerTarjeta.Focus()
            GoTo Final

        Else
            'Transaccion Rechazada

            Band = False

            If Trim(mRespcode) <> "00" Then
                Dim Motivo As String = ""

                Motivo = Mensaje46

                Select Case mRespcode.Trim
                    'Case "01"
                    '    Motivo = "Promocion Invalida o Monto inferior al minimo permitido.".ToUpper
                    '    Mensaje46 = "Promocion invalida o monto inferior al minimo permitido.".ToUpper
                    'Case "05"
                    '    Motivo = "CVV2 Requerido".ToUpper
                    Case "04", "14", "41", "43", "142"
                        oFacturaMgr.SaveTarjetaRechazada(Me.ebNumTarj.Text.Trim)
                        Motivo = "La tarjeta ha sido rechazada.".ToUpper
                    Case "45"
                        Motivo = "Promocion Invalida.".ToUpper
                    Case "46"
                        Motivo = "Monto Inferior al mínimo permitido para las promociones."
                    Case "48"
                        Motivo = "CVV2 Requerido".ToUpper
                    Case "49"
                        Motivo = "CVV2 Incorrecto.".ToUpper
                    Case "91", "70"
                        Motivo = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
                        Mensaje46 = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
                End Select

                'MessageBox.Show("Transacción Rechazada." & vbCrLf & Motivo & vbCrLf & _
                '       mSalida, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If Motivo.Trim <> "" Then Motivo = vbCrLf & vbCrLf & Motivo
                If Mensaje46.Trim <> "" Then Mensaje46 = vbCrLf & vbCrLf & Mensaje46
                'MessageBox.Show("Transacción Rechazada.".ToUpper & Mensaje46.ToUpper _
                ', "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                MessageBox.Show("Transacción Rechazada.".ToUpper & Motivo.ToUpper _
                , "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ElseIf Trim(mAutorizacion) = "" AndAlso Trim(mAfiliacion) = "" Then

                MsgBox("Transacción Rechazada. No se regresaron el número de afiliación ni el número" & _
                       " de autorización." & Microsoft.VisualBasic.vbCrLf & mSalida, _
                       MsgBoxStyle.Exclamation, "DPTienda")

            ElseIf Trim(mAutorizacion) = "" Then

                MsgBox("Transacción Rechazada. No se regresó el número de autorización." & _
                       Microsoft.VisualBasic.vbCrLf & mSalida, _
                       MsgBoxStyle.Exclamation, "DPTienda")

            ElseIf Trim(mAfiliacion) = "" Then

                MsgBox("Transacción Rechazada. No se regresó el número de afiliación." & _
                       Microsoft.VisualBasic.vbCrLf & mSalida, _
                       MsgBoxStyle.Exclamation, "DPTienda")

            End If

            Me.ebNumTarj.Text = ""
            'Me.txtCVV2.Text = ""
            'Me.txtCVV2.Focus()
            Me.btnLeerTarjeta.Focus()

        End If

Final:
        Return Band

    End Function

    Private Sub LoadSearchFormPlayer()

        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

        oOpenRecordDialogView.ShowDialog()

        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then
            If oOpenRecordDialogView.Record.Item("CodVendedor") Is Nothing Then
                Exit Sub
            End If
            oVendedor.ClearFields()
            oVendedoresMgr.LoadInto(oOpenRecordDialogView.Record.Item("CodVendedor"), oVendedor)
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 18.02.2016: Ya no se necesita validar si el vendedor esta asignado a alguna oficina de venta
            '------------------------------------------------------------------------------------------------------------------------------------
            'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)
            'Select Case strRes
            '    Case "0"
            '        MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación ")
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
                ebCodVendedor.Text = oOpenRecordDialogView.pbCodigo
                ebPlayerDescripcion.Text = oOpenRecordDialogView.pbNombre

            Else
                ebCodVendedor.Text = oOpenRecordDialogView.Record.Item("CodVendedor")
                ebPlayerDescripcion.Text = oOpenRecordDialogView.Record.Item("Nombre")
            End If
            'End Select


        End If

        oOpenRecordDialogView.Dispose()

        oOpenRecordDialogView = Nothing

    End Sub

    Private Sub ebCodVendedor_ButtonClick(sender As Object, e As System.EventArgs) Handles ebCodVendedor.ButtonClick
        LoadSearchFormPlayer()
    End Sub

    Private Sub ebCodVendedor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ebCodVendedor.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchFormPlayer()
            ebCodVendedor.Focus()
            ebCodVendedor.SelectAll()

        End If

        'If e.KeyCode = Keys.Enter Then

        '    SendKeys.Send("{TAB}")

        'End If
    End Sub

    Private Sub ebCodVendedor_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodVendedor.Validating

        If oConfigCierreFI.ShowManagerPC AndAlso ebCodVendedor.Text.Trim = "" Then

            ebCodVendedor.Focus()
            Return

        End If

        If ebCodVendedor.Text.Trim <> "" Then 'AndAlso ebCodVendedor.Text.Trim <> oFactura.CodVendedor.Trim Then

            oVendedor.ClearFields()

            oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then
                '------------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 18.02.2016: Ya no se necesita validar si el vendedor esta asignado a alguna oficina de venta
                '------------------------------------------------------------------------------------------------------------------------------------
                'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)

                'If strRes.Trim = "0" Then
                '    GoTo NoExiste
                'ElseIf strRes.Trim = "2" Then
                '    MessageBox.Show("El Vendedor " & oVendedor.ID & " no está asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    oVendedor.ClearFields()
                '    Me.ebPlayerDescripcion.Text = ""
                '    e.Cancel = True
                'Else
                ebPlayerDescripcion.Text = oVendedor.Nombre
                ebCodVendedor.Text = oVendedor.ID
                '----------------------------------------------------------------------------------------------------------------------
                'Empezamos a correr el cronómetro
                '----------------------------------------------------------------------------------------------------------------------
                'If Me.ebTipoVenta.Value <> "" AndAlso oConfigCierreFI.ShowManagerPC Then EjecutarCronometro(True)
                'End If
            Else
NoExiste:
                MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación ")

                ebCodVendedor.Text = "" 'oFactura.CodVendedor
                oVendedor.ClearFields()
                Me.ebPlayerDescripcion.Text = ""
                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub ebCodBanco_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodBanco.Validating

        If ebCodBanco.Value <> "" Then

            Dim drView As DataRowView
            drView = ebCodBanco.SelectedItem

            EBBanco.Text = drView.Item(1)

            drView = Nothing

        Else

            EBBanco.Text = ""

        End If

    End Sub

    Private Sub frmTPV_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class