Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoPromocionesAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores

Imports System.Data.SqlClient

Public Class frmCancPagoTarjeta


    'Catalogo Promociones
    Dim oCatalogoPromoMgr As CatalogoPromocionesManager
    Dim dtPromociones As New DataTable
    Dim Datos() As String

    Dim oFacturaMgr As FacturaManager
    Dim bolCargoeHub As Boolean

    Dim oVendedor As Vendedor
    Dim oVendedoresMgr As New CatalogoVendedoresManager(oAppContext)

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        'Catalogo Promociones
        oCatalogoPromoMgr = New CatalogoPromocionesManager(oAppContext, oConfigCierreFI)
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        oVendedor = oVendedoresMgr.Create
        FillBancoPromociones()
    End Sub

    Private Sub FillBancoPromociones()

        'dtPromociones = oCatalogoPromoMgr.GetAllByBin(Bin, Importe)
        dtPromociones = New DataTable()
        dtPromociones.Columns.Add("CodPromo", GetType(Integer))
        dtPromociones.Columns.Add("Descripcion", GetType(String))
        dtPromociones.AcceptChanges()
        Dim row As DataRow = dtPromociones.NewRow()
        row("CodPromo") = 1
        row("Descripcion") = "Normal"
        dtPromociones.Rows.Add(row)
        row = dtPromociones.NewRow()
        row("CodPromo") = 3
        row("Descripcion") = "3 Meses Sin Intereses"
        dtPromociones.Rows.Add(row)
        row = dtPromociones.NewRow()
        row("CodPromo") = 6
        row("Descripcion") = "6 Meses Sin Intereses"
        dtPromociones.Rows.Add(row)
        row = dtPromociones.NewRow()
        row("CodPromo") = 9
        row("Descripcion") = "9 Meses Sin Intereses"
        dtPromociones.Rows.Add(row)
        row = dtPromociones.NewRow()
        row("CodPromo") = 12
        row("Descripcion") = "12 Meses Sin Intereses"
        dtPromociones.Rows.Add(row)
        row = dtPromociones.NewRow()
        row("CodPromo") = 13
        row("Descripcion") = "13 Meses Sin Intereses"
        dtPromociones.Rows.Add(row)
        row = dtPromociones.NewRow()
        row("CodPromo") = 18
        row("Descripcion") = "18 Meses Sin Intereses"
        dtPromociones.Rows.Add(row)
        Me.cmbPromocion.DataSource = dtPromociones
        'Me.cmbPromocion.DropDownList.Columns.Add("CodPromo")
        'Me.cmbPromocion.DropDownList.Columns.Add("Descripcion")
        'Me.cmbPromocion.DropDownList.Columns("CodPromo").Width = 50
        Me.cmbPromocion.DropDownList.Columns("Descripcion").Width = 150
        Me.cmbPromocion.DisplayMember = "Descripcion"
        Me.cmbPromocion.ValueMember = "CodPromo"
        Me.cmbPromocion.DropDownList.Columns("CodPromo").Visible = False
        Me.cmbPromocion.Refresh()

    End Sub

    Public Function LeerTarjeta(ByRef NumTarjeta As String) As Boolean

        Dim Band As Boolean = True
        Dim oApp As Process
        Dim oProcesos() As Process
        'Dim pagoTarj As Decimal = 0

        Dim Ruta As String = "C:\LecturaTarjeta.txt"
        'Dim strPosEntry As String = ""

        oProcesos = Process.GetProcessesByName("eHubEMV")
        For Each oApp In oProcesos
            oApp.CloseMainWindow()
            oApp.WaitForExit()
        Next

        Shell(Application.StartupPath & "\PinPadNurit293.exe /A", AppWinStyle.NormalFocus, True)

        If File.Exists(Ruta) Then
            Datos = LeerArchivoTarjeta(Ruta)
            File.Delete(Ruta)
        Else
            Band = False
            GoTo salir
        End If

        Dim strTrack() As String

        NumTarjeta = Datos(0)
        'Me.mPosEntryM = CInt(Datos(3) & "1")
        'Me.strCriptogramaM = Datos(5)
        'Nombre = Datos(6)
        'Nombre = Datos(1)

        'strPosEntry = CStr(mPosEntryM).Trim.PadLeft(3, "0")

        strTrack = NumTarjeta.Split("=")
        NumTarjeta = strTrack(0)
        'Vencimiento = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)

Salir:
        Return Band

    End Function

    Private Function LeerArchivoTarjeta(ByVal Ruta As String) As String()

        Dim oStreamR As StreamReader
        Dim strContenido() As String

        oStreamR = New StreamReader(Ruta, System.Text.Encoding.ASCII)

        strContenido = oStreamR.ReadToEnd.Split("|")

        oStreamR.Close()

        Return strContenido

    End Function

    Private Sub AutorizarCargoTarjeta(ByVal Datos() As String)

        Dim Ruta As String = "C:\LecturaTarjeta.txt"
        Dim strDatosEMV As String = ""


        If File.Exists(Ruta) Then File.Delete(Ruta)

        Dim oApp As Process
        Dim oProcesos() As Process
        oProcesos = Process.GetProcessesByName("eHubEMV")
        For Each oApp In oProcesos
            oApp.CloseMainWindow()
            oApp.WaitForExit()
        Next

        Shell(Application.StartupPath & "\PinPadNurit293.exe /A", AppWinStyle.NormalFocus, True)

        If File.Exists(Ruta) Then
            Datos = LeerArchivoTarjeta(Ruta)
            File.Delete(Ruta)
        Else
            Me.ebNumTarj.Text = ""
            Exit Sub
        End If


        Dim x As New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub

        Dim i As Long
        Dim mSalida As String
        Dim mAmount As Double           '4    
        Dim mPOSEntry As String         '22        
        Dim mTrack2 As String           '35        
        Dim mRespose As String          '61

        Dim mE2 As String
        Dim mHRecordType As String
        Dim mHTerm As String
        Dim mHCajero As String
        Dim mHTienda As String
        Dim mHTicket As String
        Dim mHTrack2 As String
        Dim mHImporte As String
        Dim mHMeses As String
        Dim mHSkip As String
        Dim mHCVV2 As String
        Dim mHCargo As String
        Dim mHCredito As String
        Dim mHFijo As String
        Dim mCard As String
        Dim mAutorizacion As String
        Dim Mensaje As String
        Dim Mensaje46 As String
        Dim mRespcode As String
        Dim mFile As Integer

        Dim mDummy As String
        Dim mCarPun As String
        Dim mCrePun As String
        Dim mCarDin As String
        Dim mCreDin As String
        Dim mNumCia As String
        Dim mNumPlan As String = "00"
        Dim mOperacion As String
        Dim mAfiliacion As String
        Dim mCVV2 As String = Trim(Me.txtCVV2.Text)
        Dim mRespuesta As String
        Dim mComentario As String
        Dim strNombre As String
        Dim strCriptograma As String = ""
        Dim strCardSN As String = ""
        Dim mFirma As String = ""
        Dim mEmisor As String = ""
        Dim mLote As String = ""
        Dim mSubtechTermID As String = ""
        Dim mTrace As String = ""
        Dim mTrnID As String = ""

        Me.ebNumTarj.Text = Datos(0)
        strNombre = Datos(1)
        strCardSN = Datos(4)
        strCriptograma = Datos(5)
        mFirma = Datos(6)

        Dim intPosition As Integer = 0
        Dim strVencimiento As String = ""
        Dim strPromocion As String = ""
        Dim strNum As String = (ebNumTarj.Text).Replace(";", "")
        intPosition = InStr(strNum, "=")
        strVencimiento = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)
        strNum = Mid(strNum, 1, intPosition - 1)
        mPOSEntry = Datos(3) & "1"

        mTrack2 = (ebNumTarj.Text).Replace(";", "")
        mTrack2 = (mTrack2).Replace("?", "")
        If mTrack2.Length > 37 Then mTrack2 = mTrack2.Substring(0, 37)

        '81:     Dim dvTarjeta As New DataView(dsFormasPago.Tables(0), "NumeroTarjeta ='" & strNum & "'", "DPValeID", DataViewRowState.CurrentRows)
        ebNumTarj.Text = strNum
        If ValidaCampos() Then

            Dim Ticket As String = GetTicketFromSQL()

            mCVV2 = ebNumAut.Text 'dvTarjeta(0)("NumeroAutorizacion")
            mHTicket = oAppSAPConfig.Ticket & "|" & Ticket 'dvTarjeta(0)("DPValeID")
            mNumPlan = cmbPromocion.Value 'dvTarjeta(0)("id_num_promo")
            mNumPlan = mNumPlan.PadLeft(2, "0")

            mHTienda = oAppContext.ApplicationConfiguration.Almacen
            mHTerm = oAppContext.ApplicationConfiguration.NoCaja
            Dim codVendedor As String = ebCodVendedor.Text.Trim().Substring(ebCodVendedor.Text.Trim().Length - 6, 6)

            mSalida = x.PagoTarjeta( _
                        oAppContext.ApplicationConfiguration.Almacen, _
                        oAppContext.ApplicationConfiguration.NoCaja, _
                        codVendedor, _
                        "010000", mPOSEntry, mTrack2, _
                        CDbl(ebMontoPago.Value), _
                        mHTicket, _
                        mComentario, _
                        mRespuesta, _
                        strCardSN, _
                        strDatosEMV, _
                        mNumPlan, _
                        "00", _
                        mCVV2)

86:         mHTicket = ""
87:         mDummy = mSalida
88:         Do While Len(mDummy) > 0
89:             mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
90:             mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
91:             If InStr(mRespose, "11==") > 0 Then
92:                 mHTicket = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                End If
93:             If InStr(mRespose, "38==") > 0 Then
94:                 mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
95:             End If
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
                    mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim 'Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)).Substring(0, 10)
                End If
                If InStr(mRespose, "61==") > 0 Then
                    mSubtechTermID = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                End If
                If InStr(mRespose, "62==") > 0 Then
                    mLote = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                End If
                If InStr(mRespose, "63==") > 0 Then
                    mTrace = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                End If
                If InStr(mRespose, "64==") > 0 Then
                    mTrnID = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                End If
            Loop

            ''''I. Actualizamos Ticket.
            Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
            Dim oSApReader As New SapConfigReader(strConfigurationFile)
            oAppSAPConfig.Ticket = oAppSAPConfig.Ticket + 1
            oSApReader.SaveSettings(oAppSAPConfig)
            ''''F. Actualizamos Ticket.

            If mRespcode = "00" AndAlso mAfiliacion.Trim <> "" Then 'AndAlso Trim(mAutorizacion) <> "" Then

                Dim intPromo As Integer = 1

                If InStr(mSalida, "6 MESES") > 0 Then
                    strPromocion = "6 Meses Sin Intereses"
                    intPromo = 6
                ElseIf InStr(mSalida, "3 MESES") > 0 Then
                    strPromocion = "3 Meses Sin Intereses"
                    intPromo = 3
                ElseIf InStr(mSalida, "9 MESES") > 0 Then
                    strPromocion = "9 Meses Sin Intereses"
                    intPromo = 9
                ElseIf InStr(mSalida, "12 MESES") > 0 Then
                    strPromocion = "12 Meses Sin Intereses"
                    intPromo = 12
                ElseIf InStr(mSalida, "18 MESES") > 0 Then
                    strPromocion = "18 Meses Sin Intereses"
                    intPromo = 18
                Else
                    strPromocion = "Normal"
                    intPromo = 1
                End If

                Dim strBanco As String = ""

                Mensaje = ""
                Mensaje = oFacturaMgr.BancoAutorizador(Me.ebNumTarj.Text, intPromo).ToUpper
                'Mensaje = UCase(Mensaje)
                If InStr(Mensaje, "BANAMEX") > 0 Then
                    strBanco = "BANAMEX"
                ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
                    strBanco = "BANCOMER"
                ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
                    strBanco = "SANTANDER"
                End If

                'Transaccion Exitosa

                MsgBox("Transacción Exitosa." & vbCrLf & "Preparar Miniprinter.", MsgBoxStyle.Information, "DPTienda")

                Dim bolReimprimir As Boolean = False
                Dim oReportView As ReportViewerForm

Reimprimir:

                Select Case strBanco

                    Case "BANAMEX"
Imprime_Banamex:
                        If InStr(mFirma, "TEL:") > 0 Then mFirma = mFirma.Substring(0, InStr(mFirma, "TEL:") - 1)
                        mFirma = mFirma & "".PadLeft(44, " ")
                        mFirma = mFirma & "".PadLeft(44, " ")
                        mFirma = mFirma & mSubtechTermID.Trim & "  "
                        mFirma = mFirma & mLote.PadLeft(6, "0") & "  "
                        mFirma = mFirma & CLng(mTrnID)

                        'Original Banco
                        Dim oARReporte As New rptTicketBANAMEX(CDbl(ebMontoPago.Value), strNum, _
                                                               strVencimiento, mAutorizacion, _
                                                               strPromocion, "CANCELACION", strNombre, _
                                                               ebCodVendedor.Text, mAfiliacion, strBanco, _
                                                               "ORIGINAL BANCO", mFirma, strCriptograma, True, _
                                                                mHTicket, mLote, mTrace, mSubtechTermID)
                        oARReporte.Document.Name = "Cancelación Tarjeta de Crédito"
                        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                        oARReporte.Run()
                        oARReporte.Document.Print(False, False)

                        'COPIA CLIENTE
                        Dim oARReporteC As New rptTicketBANAMEX(CDbl(ebMontoPago.Value), strNum, _
                                                                strVencimiento, mAutorizacion, _
                                                                strPromocion, "CANCELACION", strNombre, _
                                                                ebCodVendedor.Text, mAfiliacion, strBanco, _
                                                                "COPIA CLIENTE", mFirma, strCriptograma, True, _
                                                                mHTicket, mLote, mTrace, mSubtechTermID)
                        oARReporteC.Document.Name = "Cancelación Tarjeta de Crédito"
                        oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                        oARReporteC.Run()
                        oARReporteC.Document.Print(False, False)

                        oReportView = New ReportViewerForm
                        oReportView.Report = oARReporte
                        oReportView.Show()

                        oReportView = New ReportViewerForm
                        oReportView.Report = oARReporteC
                        oReportView.Show()

                    Case "BANCOMER"

                        'Original Banco
                        Dim oARReporte As New rptTicketBancomer(CDbl(ebMontoPago.Value), strNum, strVencimiento, _
                                                                ebNumAut.Text, strPromocion, "CANCELACION", _
                                                                strNombre, ebCodVendedor.Text, mAfiliacion, strBanco, "ORIGINAL BANCO", _
                                                                mPOSEntry, True, True, strCriptograma, mFirma)
                        oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                        oARReporte.Run()
                        oARReporte.Document.Print(False, False)

                        'Copia Cliente
                        Dim oARReporteC As New rptTicketBancomer(CDbl(ebMontoPago.Value), strNum, strVencimiento, _
                                                                 ebNumAut.Text, strPromocion, "CANCELACION", _
                                                                 strNombre, ebCodVendedor.Text, mAfiliacion, strBanco, "COPIA CLIENTE", _
                                                                 mPOSEntry, True, True, strCriptograma, mFirma)
                        oARReporteC.Document.Name = "Cancelación Tarjeta de Crédito"
                        oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                        oARReporteC.Run()
                        oARReporteC.Document.Print(False, False)

                        oReportView = New ReportViewerForm
                        oReportView.Report = oARReporte
                        oReportView.Show()

                        oReportView = New ReportViewerForm
                        oReportView.Report = oARReporteC
                        oReportView.Show()

                    Case Else

                        GoTo Imprime_Banamex

                End Select

                If bolReimprimir = False Then
                    If MessageBox.Show("¿Desea reimprimir los vouchers?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        bolReimprimir = True
                        GoTo Reimprimir
                    End If
                End If

                Me.ebNumTarj.Text = ""
                Me.txtCVV2.Text = ""
                Me.txtCVV2.Focus()

                If ValidaCampos() Then
                    bolCargoeHub = False
                    Me.DialogResult = DialogResult.OK
                Else
                    bolCargoeHub = True
                End If

            Else
                'Transaccion Rechazada

                'MsgBox("Transacción Rechazada", MsgBoxStyle.Information, "DPTienda")

                If Trim(mRespcode) <> "00" Then

                    MsgBox("Transacción Rechazada." & Microsoft.VisualBasic.vbCrLf & _
                    mSalida, MsgBoxStyle.Exclamation, "DPTienda")

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
                Me.txtCVV2.Text = ""
                Me.txtCVV2.Focus()

            End If

        Else
            MessageBox.Show("No se han ingresado todos los datos. Verifique", "Validar Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebNumTarj.Text = ""
            Me.txtCVV2.Text = ""
            Me.txtCVV2.Focus()
        End If

        If mPOSEntry.Trim = "051" Then
            Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
        End If

    End Sub

    Private Function ValidaCampos() As Boolean

        Dim bolResp As Boolean = True

        If ebNumAut.Text.Trim = "" Then
            bolResp = False
            'ElseIf ebNumTarj.Text.Trim = "" Then
            '    bolResp = False
        ElseIf ebMontoPago.Value <= 0 Then
            bolResp = False
            'ElseIf cmbPromocion.Text.Trim = "" Then
            '    bolResp = False
        ElseIf ebCodVendedor.Text.Trim = "" Then
            bolResp = False
        ElseIf ebAfiliacion.Text.Trim = "" Then
            bolResp = False
        End If

        Return bolResp

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

    Private Function GetTicketFromSQL() As String

        Dim strConnectionString As String = "data source = " & oConfigCierreFI.ServerEhub & "; initial catalog = " & _
                                            oConfigCierreFI.BaseDatosEhub & "; user id = " & oConfigCierreFI.UserEhub & "; password = " & _
                                            oConfigCierreFI.PassEhub

        Dim sccnnConnection As New SqlConnection(strConnectionString)
        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oTicket As String

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "SELECT      Ticket " & _
                           "    FROM MOV_BANCOMER " & _
                           "    WHERE   Afiliacion = " & ebAfiliacion.Text.Trim & _
                           "            AND NUM_CUENTA = " & ebNumTarj.Text.Trim & _
                           "            AND REF_AUTORIZADOR = '" & ebNumAut.Text.Trim & "'"
            '"            AND Importe = " & ebMontoPago.Value & _

            .CommandType = System.Data.CommandType.Text

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader
                        oTicket = .GetString(0).ToUpper
                    End With

                Else
                    oTicket = String.Empty
                End If

                scdrReader.Close()
            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        If (oTicket Is String.Empty) Then
            MessageBox.Show("No se encontró el Ticket Bancario correspondiente a los datos ingresados.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oTicket

    End Function

    Private Sub FillDPCardPromociones(ByVal Bin As Integer, ByVal Importe As Decimal)
        Dim dtPromociones As DataTable
        Dim oFacturaMgr As New DportenisPro.DPTienda.ApplicationUnits.Facturas.FacturaManager(oAppContext, oConfigCierreFI)

        dtPromociones = oFacturaMgr.GetPromocionesDPCardByBIN(Bin, Importe, "P")

        Me.cmbPromocion.DataSource = dtPromociones
        Me.cmbPromocion.DropDownList.Columns("CodPromo").DataMember = "Promocion"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").DataMember = "Descripcion"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").Width = 150

        Me.cmbPromocion.DisplayMember = "Descripcion"
        Me.cmbPromocion.ValueMember = "Promocion"
        Me.cmbPromocion.DropDownList.Columns("CodPromo").Visible = False
        Me.cmbPromocion.Refresh()
        Me.cmbPromocion.Enabled = True
    End Sub

#Region "Eventos"

    'Private Sub btnLeerTarjeta_Click(sender As System.Object, e As System.EventArgs)

    '    Me.btnLeerTarjeta.Enabled = False
    '    Me.ebNumTarj.Text = ""
    '    Me.LeerTarjeta(ebNumTarj.Text)
    '    Me.btnLeerTarjeta.Enabled = True

    'End Sub

    Private Sub ebMontoPago_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ebMontoPago.Validating
        
    End Sub

    Private Sub btnCancelarPago_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarPago.Click

        If ValidaCampos() Then
            AutorizarCargoTarjeta(Datos)
        Else
            MessageBox.Show("No se han cargado los datos necesarios. Favor de verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

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

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub ebCodVendedor_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodVendedor.Validating

        If oConfigCierreFI.ShowManagerPC AndAlso ebCodVendedor.Text.Trim = "" Then

            ebCodVendedor.Focus()
            Return

        End If

        If ebCodVendedor.Text.Trim <> "" Then

            oVendedor.ClearFields()

            oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then

                ebPlayerDescripcion.Text = oVendedor.Nombre
                ebCodVendedor.Text = oVendedor.ID

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


#End Region

End Class