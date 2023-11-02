Imports Microsoft.Win32
Module ModIso8583
    Public Structure SECURITY_ATTRIBUTES
        Dim nLength As Integer
        Dim lpSecurityDescriptor As Integer
        Dim bInheritHandle As Integer
    End Structure

    Structure vInfoHeader
        Dim NoTransaccion As Integer
        Dim Version As Integer
        Dim Cnsc As Integer
        Dim Uid As Short
        Dim Paso As Short
        Dim Caja As Short
        Dim Sucursal As Short
        Dim TranCount As Integer
        Dim TranError As Integer
        Dim DateRef As Double
        Dim Header As String
        Dim Entrada As String
    End Structure

    Public Const APPNAME As String = "eHub Client (Depilite)"
    Public Const APPKEY As String = "Software\BARTeC\eHub"
    Public Const gIsoKey As String = APPKEY
    Public Const FORMAT_ONLINE As Short = 3010
    Public Const FORMAT_ISO As Short = 3020
    Public Const FORMAT_ISO2 As Short = 3021
    Public Const FORMAT_NOK As Short = 3030
    Public Const INVALID_TX As Short = 3040

    Public Const STX As Short = 2
    Public Const ETX As Short = 3
    Public Iso As Collection
    Public IsoReason As Collection
    Public vOut As String
    Public vConnect As Boolean
    Public Sub Mascara(ByVal pMascara As String, ByRef oValores As Object, Optional ByRef pData As String = "")
        Dim i As Short
        Dim mDimension(128) As Boolean
        Dim mChar As Byte
        Dim mDummy As String
        Dim mRet As New Collection
        Dim mMaxFields As Short
        Dim mX As clsResultados

        On Error Resume Next
        For i = 1 To 16
            mDummy = Mid(pMascara, i, 1)
            Select Case UCase(mDummy)
                Case "A"
                    mDummy = 10
                Case "B"
                    mDummy = 11
                Case "C"
                    mDummy = 12
                Case "D"
                    mDummy = 13
                Case "E"
                    mDummy = 14
                Case "F"
                    mDummy = 15
            End Select
            mChar = CByte(mDummy)
            If (mChar And &H8S) = &H8S Then mDimension((i - 1) * 4 + 1) = True Else mDimension((i - 1) * 4 + 1) = False
            If (mChar And &H4S) = &H4S Then mDimension((i - 1) * 4 + 2) = True Else mDimension((i - 1) * 4 + 2) = False
            If (mChar And &H2S) = &H2S Then mDimension((i - 1) * 4 + 3) = True Else mDimension((i - 1) * 4 + 3) = False
            If (mChar And &H1S) = &H1S Then mDimension((i - 1) * 4 + 4) = True Else mDimension((i - 1) * 4 + 4) = False
        Next i
        If mDimension(1) Then
            mMaxFields = 128
            pMascara = Left(pData, 16)
            For i = 1 To 16
                mDummy = Mid(pMascara, i, 1)
                Select Case UCase(mDummy)
                    Case "A"
                        mDummy = 10
                    Case "B"
                        mDummy = 11
                    Case "C"
                        mDummy = 12
                    Case "D"
                        mDummy = 13
                    Case "E"
                        mDummy = 14
                    Case "F"
                        mDummy = 15
                End Select
                mChar = CByte(mDummy)
                If (mChar And &H8S) = &H8S Then mDimension(((16 + i) - 1) * 4 + 1) = True Else mDimension(((16 + i) - 1) * 4 + 1) = False
                If (mChar And &H4S) = &H4S Then mDimension(((16 + i) - 1) * 4 + 2) = True Else mDimension(((16 + i) - 1) * 4 + 2) = False
                If (mChar And &H2S) = &H2S Then mDimension(((16 + i) - 1) * 4 + 3) = True Else mDimension(((16 + i) - 1) * 4 + 3) = False
                If (mChar And &H1S) = &H1S Then mDimension(((16 + i) - 1) * 4 + 4) = True Else mDimension(((16 + i) - 1) * 4 + 4) = False
            Next i
        Else
            mMaxFields = 64
        End If

        For i = 1 To mMaxFields
            If mDimension(i) Then
                mX = New clsResultados
                mX.Id = i
                mX.Descripcion = Iso.Item(CStr(i)).Description
                mX.Valor = RetrieveIso(i, pData)
                mRet.Add(mX, CStr(i))
                mX = Nothing
            End If
        Next i
        oValores = mRet
    End Sub

    Public Function MascaraConstruct(ByVal pMascara As String, ByRef oValores As Object, Optional ByRef pData As String = "") As Object
        Dim i As Short
        Dim mDimension(128) As Boolean
        Dim mChar As Byte
        Dim mDummy As String
        Dim mRet As New Collection
        Dim mMaxFields As Short

        On Error Resume Next
        For i = 1 To 16
            mDummy = Mid(pMascara, i, 1)
            Select Case UCase(mDummy)
                Case "A"
                    mDummy = 10
                Case "B"
                    mDummy = 11
                Case "C"
                    mDummy = 12
                Case "D"
                    mDummy = 13
                Case "E"
                    mDummy = 14
                Case "F"
                    mDummy = 15
            End Select
            mChar = CByte(mDummy)
            If (mChar And &H8S) = &H8S Then mDimension((i - 1) * 4 + 1) = True Else mDimension((i - 1) * 4 + 1) = False
            If (mChar And &H4S) = &H4S Then mDimension((i - 1) * 4 + 2) = True Else mDimension((i - 1) * 4 + 2) = False
            If (mChar And &H2S) = &H2S Then mDimension((i - 1) * 4 + 3) = True Else mDimension((i - 1) * 4 + 3) = False
            If (mChar And &H1S) = &H1S Then mDimension((i - 1) * 4 + 4) = True Else mDimension((i - 1) * 4 + 4) = False
        Next i
        If mDimension(1) Then
            mMaxFields = 128
            pMascara = Left(pData, 16)
            For i = 1 To 16
                mDummy = Mid(pMascara, i, 1)
                Select Case UCase(mDummy)
                    Case "A"
                        mDummy = 10
                    Case "B"
                        mDummy = 11
                    Case "C"
                        mDummy = 12
                    Case "D"
                        mDummy = 13
                    Case "E"
                        mDummy = 14
                    Case "F"
                        mDummy = 15
                End Select
                mChar = CByte(mDummy)
                If (mChar And &H8S) = &H8S Then mDimension(((16 + i) - 1) * 4 + 1) = True Else mDimension(((16 + i) - 1) * 4 + 1) = False
                If (mChar And &H4S) = &H4S Then mDimension(((16 + i) - 1) * 4 + 2) = True Else mDimension(((16 + i) - 1) * 4 + 2) = False
                If (mChar And &H2S) = &H2S Then mDimension(((16 + i) - 1) * 4 + 3) = True Else mDimension(((16 + i) - 1) * 4 + 3) = False
                If (mChar And &H1S) = &H1S Then mDimension(((16 + i) - 1) * 4 + 4) = True Else mDimension(((16 + i) - 1) * 4 + 4) = False
            Next i
        Else
            mMaxFields = 64
        End If
        Dim mX As New clsResultados
        For i = 1 To mMaxFields
            If mDimension(i) Then
                mX.Id = i
                mX.Descripcion = Iso.Item(CStr(i)).Description
                mX.Valor = RetrieveIsoCompleto(i, pData)
                mRet.Add(mX, CStr(i))
                mX = Nothing
            End If
        Next i
        MascaraConstruct = 0
        oValores = mRet
    End Function

    Public Function ConstruyeMascara(ByRef pTransact As String, ByRef pInputCollection As Collection) As String
        Dim i As Short
        Dim mDummy As String
        Dim mOut As String
        Dim pMascara As String
        Dim y As clsResultados
        Dim mSec As Boolean
        Dim maxFields As Short
        Dim mIdent As Integer
        Dim mProductIndicator As New VB6.FixedLengthString(2)
        Dim mReleaseNumber As New VB6.FixedLengthString(2)
        Dim mMsgStatus As New VB6.FixedLengthString(3)
        Dim mOriginatorCode As New VB6.FixedLengthString(1)
        Dim mResponderCode As New VB6.FixedLengthString(1)
        Dim regVersion As RegistryKey

        On Error Resume Next
        mOut = ""
        pMascara = ""
        mSec = False
        For Each y In pInputCollection
            If y.Id > i Then i = y.Id
        Next y
        Dim yy As New clsResultados
        If i > 64 Then
            mSec = True
            pInputCollection.Remove("1")
            yy.Id = 1
            yy.Descripcion = "Bitmap Secundario"
            yy.Valor = ""
            pInputCollection.Add(yy, "1")
            yy = Nothing
        End If
        Err.Clear()
        If mSec Then maxFields = 128 Else maxFields = 64
        For i = 1 To maxFields
            mIdent = pInputCollection.Item(CStr(i)).Id
            If Err.Number <> 0 Then
                mDummy = mDummy & "0"
            Else
                mDummy = mDummy & "1"
                mOut = mOut & pInputCollection.Item(CStr(i)).Valor
            End If
            Err.Clear()
            If i Mod 4 = 0 Then
                Select Case mDummy
                    Case "0000" : pMascara = pMascara & "0"
                    Case "0001" : pMascara = pMascara & "1"
                    Case "0010" : pMascara = pMascara & "2"
                    Case "0011" : pMascara = pMascara & "3"
                    Case "0100" : pMascara = pMascara & "4"
                    Case "0101" : pMascara = pMascara & "5"
                    Case "0110" : pMascara = pMascara & "6"
                    Case "0111" : pMascara = pMascara & "7"
                    Case "1000" : pMascara = pMascara & "8"
                    Case "1001" : pMascara = pMascara & "9"
                    Case "1010" : pMascara = pMascara & "A"
                    Case "1011" : pMascara = pMascara & "B"
                    Case "1100" : pMascara = pMascara & "C"
                    Case "1101" : pMascara = pMascara & "D"
                    Case "1110" : pMascara = pMascara & "E"
                    Case "1111" : pMascara = pMascara & "F"
                End Select
                mDummy = ""
            End If
        Next


        regVersion = Registry.LocalMachine.OpenSubKey(gIsoKey, False)
        mProductIndicator.Value = regVersion.GetValue("ProductIndicator", "02")
        mReleaseNumber.Value = regVersion.GetValue("ReleaseNumber", "50")
        mMsgStatus.Value = regVersion.GetValue("MsgStatus", "000")
        mOriginatorCode.Value = regVersion.GetValue("OriginatorCode", "4")
        mResponderCode.Value = regVersion.GetValue("ResponderCode", "0")
        pMascara = pTransact & pMascara
        pMascara = mResponderCode.Value & pMascara
        pMascara = mOriginatorCode.Value & pMascara
        pMascara = mMsgStatus.Value & pMascara
        pMascara = mReleaseNumber.Value & pMascara
        pMascara = mProductIndicator.Value & pMascara
        pMascara = "ISO" & pMascara
        pMascara = pMascara & mOut        
        'Return pMascara
        ConstruyeMascara = pMascara
    End Function

    Public Function Centra(ByRef pString As String) As String
        Dim mPaso As String

        On Error Resume Next
        mPaso = mPaso & Space((40 - Len(pString)) \ 2) & pString & vbCrLf
        Centra = mPaso
    End Function

    Public Function RetrieveIso(ByRef pId As Short, ByRef pValorEnt As String) As Object
        Dim mTipo As String
        Dim mlong As Short
        Dim mPref As Short
        Dim mPrefVal As Integer

        On Error Resume Next
        mTipo = Iso.Item(pId).fmt
        mlong = Iso.Item(pId).Length
        mPref = Iso.Item(pId).Header

        If mPref <> 0 Then
            mPrefVal = CInt(Mid(pValorEnt, 1, mPref))
            pValorEnt = Right(pValorEnt, Len(pValorEnt) - mPref)
            RetrieveIso = Mid(pValorEnt, 1, mPrefVal)
            pValorEnt = Right(pValorEnt, Len(pValorEnt) - mPrefVal)
        Else
            RetrieveIso = Mid(pValorEnt, 1, mlong)
            pValorEnt = Right(pValorEnt, Len(pValorEnt) - mlong)
        End If
    End Function
    Public Function RetrieveIsoCompleto(ByRef pId As Short, ByRef pValorEnt As String) As String
        Dim mTipo As String
        Dim mlong As Short
        Dim mPref As Short
        Dim mPrefVal As String

        On Error Resume Next
        mTipo = Iso.Item(pId).fmt
        mlong = Iso.Item(pId).Length
        mPref = Iso.Item(pId).Header

        If mPref <> 0 Then
            mPrefVal = Mid(pValorEnt, 1, mPref)
            pValorEnt = Right(pValorEnt, Len(pValorEnt) - mPref)
            RetrieveIsoCompleto = mPrefVal & Mid(pValorEnt, 1, CInt(mPrefVal))
            pValorEnt = Right(pValorEnt, Len(pValorEnt) - CDbl(mPrefVal))
        Else
            RetrieveIsoCompleto = Mid(pValorEnt, 1, mlong)
            pValorEnt = Right(pValorEnt, Len(pValorEnt) - mlong)
        End If
    End Function
    Public Sub InitIso()
        On Error Resume Next
        If Iso.Count() >= 128 Then
            If Err.Number <> 0 Then
                Iso = New Collection
                IsoReason = New Collection
                Err.Clear()
            Else
                Exit Sub
            End If
        End If
        On Error GoTo Fin

            CargaIso200(1, 16, "AN", 0, "BitMap Secundario")
            CargaIso200(2, 19, "N", 2, "Primary Account Number(Tarjeta Digitada)")
            CargaIso200(3, 6, "N", 0, "Processing Code")
            CargaIso200(4, 12, "N", 0, "Transaction Amount")
            CargaIso200(5, 12, "N", 0, "")
            CargaIso200(6, 12, "N", 0, "")
            CargaIso200(7, 10, "N", 0, "Transmission Date and Time")
            CargaIso200(8, 8, "N", 0, "")
            CargaIso200(9, 8, "N", 0, "")
            CargaIso200(10, 8, "N", 0, "")
            CargaIso200(11, 6, "N", 0, "Systems Trace Audit Number")
            CargaIso200(12, 6, "N", 0, "Local Transaction Time")
            CargaIso200(13, 4, "N", 0, "Local Transaction Date")
            CargaIso200(14, 4, "N", 0, "")
            CargaIso200(15, 4, "N", 0, "")
            CargaIso200(16, 4, "N", 0, "")
            CargaIso200(17, 4, "N", 0, "Capture Date")
            CargaIso200(18, 4, "N", 0, "")
            CargaIso200(19, 3, "N", 0, "")
            CargaIso200(20, 3, "N", 0, "")
            CargaIso200(21, 3, "N", 0, "")
            CargaIso200(22, 3, "N", 0, "Point of Service Entry mode")
        CargaIso200(23, 3, "N", 0, "Card Sequence Number")
            CargaIso200(24, 3, "N", 0, "Network International ID")
            CargaIso200(25, 2, "N", 0, "Point Of Service Condition Code")
            CargaIso200(26, 2, "N", 0, "")
            CargaIso200(27, 1, "N", 0, "")
            CargaIso200(28, 8, "N", 0, "")
            CargaIso200(29, 8, "N", 0, "")
            CargaIso200(30, 8, "N", 0, "")
            CargaIso200(31, 8, "N", 0, "")
            CargaIso200(32, 11, "N", 2, "Aquiring Institution Identification Code")
            CargaIso200(33, 11, "N", 2, "")
            CargaIso200(34, 28, "N", 2, "")
            CargaIso200(35, 37, "Z", 2, "Track 2 Data")
            CargaIso200(36, 104, "N", 3, "")
            CargaIso200(37, 12, "AN", 0, "Retrieval reference number")
            CargaIso200(38, 6, "AN", 0, "Numero de autorizacion")
            CargaIso200(39, 2, "AN", 0, "Codigo de Autorizacion")
            CargaIso200(40, 3, "N", 0, "")
            CargaIso200(41, 16, "ANS", 0, "Card acceptor terminal identification")
            CargaIso200(42, 15, "ANS", 0, "Card acceptor ID")
            CargaIso200(43, 40, "ANS", 0, "")
            CargaIso200(44, 25, "N", 2, "")
            CargaIso200(45, 76, "N", 2, "")
            CargaIso200(46, 999, "N", 3, "")
            CargaIso200(47, 999, "N", 3, "")
            CargaIso200(48, 999, "N", 3, "Additional Data Base-24 pos Retailer data")
            CargaIso200(49, 3, "N", 0, "Transaction Currency Code")
            CargaIso200(50, 3, "N", 0, "")
            CargaIso200(51, 3, "N", 0, "")
            CargaIso200(52, 16, "N", 0, "PIN")
            CargaIso200(53, 18, "N", 0, "")
            CargaIso200(54, 120, "N", 3, "")
        CargaIso200(55, 999, "ANS", 3, "EMV Full Grade")
            CargaIso200(56, 999, "N", 3, "")
            CargaIso200(57, 999, "N", 3, "")
            CargaIso200(58, 999, "N", 3, "")
            CargaIso200(59, 999, "N", 3, "")
            CargaIso200(60, 7, "ANS", 3, "Base-24 T")
            CargaIso200(61, 999, "ANS", 3, "")
            CargaIso200(62, 999, "ANS", 3, "")
            CargaIso200(63, 999, "ANS", 3, "")
            CargaIso200(64, 16, "N", 0, "")
            CargaIso200(65, 16, "N", 0, "")
            CargaIso200(66, 1, "N", 0, "")
            CargaIso200(67, 2, "N", 0, "")
            CargaIso200(68, 3, "N", 0, "")
            CargaIso200(69, 3, "N", 0, "")
            CargaIso200(70, 3, "N", 0, "")
            CargaIso200(71, 4, "N", 0, "")
            CargaIso200(72, 4, "N", 0, "")
            CargaIso200(73, 6, "N", 0, "")
            CargaIso200(74, 10, "N", 0, "")
            CargaIso200(75, 10, "N", 0, "")
            CargaIso200(76, 10, "N", 0, "")
            CargaIso200(77, 10, "N", 0, "")
            CargaIso200(78, 10, "N", 0, "")
            CargaIso200(79, 10, "N", 0, "")
            CargaIso200(80, 10, "N", 0, "")
            CargaIso200(81, 10, "N", 0, "")
            CargaIso200(82, 12, "N", 0, "")
            CargaIso200(83, 12, "N", 0, "")
            CargaIso200(84, 12, "N", 0, "")
            CargaIso200(85, 12, "N", 0, "")
            CargaIso200(86, 16, "N", 0, "Amount Credits")
            CargaIso200(87, 16, "N", 0, "Reversal Amount Credits")
            CargaIso200(88, 16, "N", 0, "Amount Debits")
            CargaIso200(89, 16, "N", 0, "Reversal Amount Debits")
            CargaIso200(90, 42, "N", 0, "Original Data Elements")
            CargaIso200(91, 1, "N", 0, "")
            CargaIso200(92, 2, "N", 0, "")
            CargaIso200(93, 5, "N", 0, "")
            CargaIso200(94, 7, "N", 0, "")
            CargaIso200(95, 42, "N", 0, "Replacement Amounts")
            CargaIso200(96, 8, "N", 0, "")
            CargaIso200(97, 17, "AN", 0, "")
            CargaIso200(98, 25, "N", 0, "")
            CargaIso200(99, 11, "N", 2, "")
            CargaIso200(100, 11, "N", 2, "Receiving Institution Identification Code")
            CargaIso200(101, 2, "N", 2, "")
            CargaIso200(102, 28, "N", 2, "")
            CargaIso200(103, 28, "N", 2, "")
            CargaIso200(104, 100, "N", 2, "")
            CargaIso200(105, 999, "N", 3, "")
            CargaIso200(106, 999, "N", 3, "")
            CargaIso200(107, 999, "N", 3, "")
            CargaIso200(108, 999, "N", 3, "")
            CargaIso200(109, 999, "N", 3, "")
            CargaIso200(110, 999, "N", 3, "Reserved ISO Descarga de archivo negativo")
            CargaIso200(111, 999, "N", 3, "Reserved ISO Descarga de archivo negativo")
            CargaIso200(112, 999, "N", 3, "")
            CargaIso200(113, 999, "N", 3, "")
            CargaIso200(114, 999, "N", 3, "")
            CargaIso200(115, 999, "N", 3, "")
            CargaIso200(116, 999, "N", 3, "")
            CargaIso200(117, 999, "N", 3, "")
            CargaIso200(118, 999, "N", 3, "")
            CargaIso200(119, 999, "N", 3, "")
            CargaIso200(120, 999, "N", 3, "Base24-pos Terminal Address-Branch")
            CargaIso200(121, 999, "N", 3, "Base24-pos Auth Indicators-Crt Authorization Data")
            CargaIso200(122, 999, "N", 2, "")
            CargaIso200(123, 999, "N", 3, "")
            CargaIso200(124, 255, "N", 3, "Base24-pos Batch and Shift Data/Settlement Record 2")
            CargaIso200(125, 50, "N", 3, "Base24-pos Settlement Data/Settlement Record 3")
            CargaIso200(126, 41, "N", 3, "")
            CargaIso200(127, 999, "N", 3, "")
            CargaIso200(128, 16, "N", 0, "")

            'Rasones de Rechazo
            LoadReason("00", "Aprobada")
            LoadReason("01", "Refiera al Emisor de la Tarjeta")
            LoadReason("02", "Llame al Emisor o referir")
            LoadReason("03", "Comercio Inválido")
            LoadReason("04", "Retener Tarjeta")
            LoadReason("05", "Rechazada")
            LoadReason("06", "Error")
            LoadReason("07", "Retener Tarjeta")
            LoadReason("08", "Aprobada con identificación")
            LoadReason("09", "Transacción en progreso")
            LoadReason("10", "Aprobada para cantidad parcial")
            LoadReason("11", "Aprobada VIP")
            LoadReason("12", "Transacción inválida")
            LoadReason("13", "Cantidad Inválida")
            LoadReason("14", "Número de Tarjeta Inválida")
            LoadReason("15", "Emisor no existe")
            LoadReason("16", "Aprobada (no soportada)")
            LoadReason("17", "Cancelación del Cliente")
            LoadReason("18", "Disputa del Cliente")
            LoadReason("19", "Re- intente de nuevo Transacción")
            LoadReason("20", "Respuesta Inválida")
            LoadReason("21", "Acción no tomada")
            LoadReason("22", "Sospecha de mal funcionamiento")
            LoadReason("23", "Transacción no aceptada")
            LoadReason("24", "Respuesta mantenimiento de archivo")
            LoadReason("25", "Respuesta mantenimiento de archivo")
            LoadReason("26", "Respuesta mantenimiento de archivo")
            LoadReason("27", "Respuesta mantenimiento de archivo")
            LoadReason("28", "Respuesta mantenimiento de archivo")
            LoadReason("29", "Respuesta mantenimiento de archivo")
            LoadReason("30", "Error de formato")
            LoadReason("31", "Banco no soportado")
            LoadReason("32", "Parcialmente completada")
            LoadReason("33", "Retener tarjeta expirada")
            LoadReason("34", "Sospecha de fraude, retener")
            LoadReason("35", "Tarjeta capturada, retener")
            LoadReason("36", "Tarjeta restringida, retener")
            LoadReason("37", "Llame a seguridad adquirente, retener")
            LoadReason("38", "Intentos de Pin excedidos")
            LoadReason("39", "No es cuenta de crédito")
            LoadReason("40", "Función requerida no soportada")
            LoadReason("41", "Tarjeta pérdida, retener")
            LoadReason("42", "No es cuenta universal")
            LoadReason("43", "Tarjeta robada, retener")
            LoadReason("44", "No es cuenta de inversión")
            LoadReason("45", "Uso reservado Visa")
            LoadReason("46", "Uso reservado Visa")
            LoadReason("47", "Uso reservado Visa")
            LoadReason("48", "Uso reservado Visa")
            LoadReason("49", "Uso reservado Visa")
            LoadReason("50", "Uso reservado Visa")
            LoadReason("51", "Fondos insuficientes")
            LoadReason("52", "No es cuenta de cheques")
            LoadReason("53", "No es cuenta de ahorros")
            LoadReason("54", "Tarjeta expirada o vencida")
            LoadReason("55", "Pin incorrecto")
            LoadReason("56", "Tarjeta no registrada")
            LoadReason("57", "Transacción no permitida")
            LoadReason("58", "Transacción no permitida para terminal")
            LoadReason("59", "Sospecha de fraude")
            LoadReason("60", "Negocio llame al Adquirente")
            LoadReason("61", "La cantidad excede al límite de retiro")
            LoadReason("62", "Tarjeta restringida")
            LoadReason("63", "Violación de seguridad")
            LoadReason("64", "Cantidad original incorrecta")
            LoadReason("65", "Excede el límite de frecuencia de retiro")
            LoadReason("66", "Negocio llame a seguridad Adquirente")
            LoadReason("67", "Retenga tarjeta")
            LoadReason("68", "Respuesta recibida tarde")
            LoadReason("69", "Uso reservado ISO")
            LoadReason("70", "Sin Conexion al Host de Respuesta")
            LoadReason("71", "Uso reservado ISO")
            LoadReason("72", "Uso reservado ISO")
            LoadReason("73", "Uso reservado ISO")
            LoadReason("74", "Uso reservado ISO")
            LoadReason("75", "Número de intentos de pin excedidos")
            LoadReason("76", "Cuenta ineligible")
            LoadReason("77", "Emisor de la tarjeta y propietario de terminal no comparten")
            LoadReason("78", "Contacte al Emisor de Tarjeta")
            LoadReason("79", "Transacción aprobada dentro de ventana")
            LoadReason("80", "Transacción aprobarada fuera de ventana")
            LoadReason("81", "Transacción de balance aprobada en cualquier momento")
            LoadReason("82", "Reverso y ajuste privado")
            LoadReason("83", "Reverso y ajuste privado")
            LoadReason("84", "Reverso y ajuste privado")
            LoadReason("85", "Reverso y ajuste privado")
            LoadReason("86", "No hay información de movs. para cta.")
            LoadReason("87", "No hay información de movs. disponible")
            LoadReason("88", "Error de sistema")
            LoadReason("89", "Problema en BD")
            LoadReason("90", "Cut off en progreso")
            LoadReason("91", "Sin Conexion al Autorizador")
            LoadReason("92", "Ruta no encontrada")
            LoadReason("93", "Transacción no puede ser completada")
            LoadReason("94", "Transmisión duplicada")
            LoadReason("95", "Error de conciliación")
            LoadReason("96", "Mal funcionamiento del sistema")
            LoadReason("N1", "Longitud inválida del PAN")
            LoadReason("N2", "Fecha de posteo inválida")
            LoadReason("N3", "Máx reversos en linea alcanzado")
            LoadReason("N4", "Máx reversos fuera de linea alcanzado")
            LoadReason("N5", "Crédito excede el máximo permitido")
            LoadReason("N6", "Devolución excede el máximo permitido")
            LoadReason("N7", "Se encuentra en archivo negativo")
            LoadReason("N8", "Excede limite de piso ")
            LoadReason("N9", "Excede número de devol permitido")
            LoadReason("O0", "Fecha invalidaC")
            LoadReason("O1", "Problema en archivo negativo")
            LoadReason("O2", "Disposición menor al minimo permitido")
            LoadReason("O3", "Retener tarjeta")
            LoadReason("O4", "Problemas en BD")
            LoadReason("O5", "NIP requerido")
            LoadReason("O6", "Validación de digito incorrecta")
            LoadReason("O8", "Problemas  con el PBF")
            LoadReason("P0", "Problemas archivo CAF"" ")
            LoadReason("P1", "Limite diario excedido")
            LoadReason("P2", "Problemas archivo CAPF")
            LoadReason("P3", "Disposición menor al limite permiido")
            LoadReason("P4", "Número de veces usada excedido")
            LoadReason("P5", "Delincuente")
            LoadReason("P6", "Problema en BD")
            LoadReason("P7", "Disposición menor al limite permiido")
            LoadReason("P8", "Tarjeta administrativa requerida")
            LoadReason("P9", "Introduzca un monto menor")
            LoadReason("Q0", "Fecha inválida")
            LoadReason("Q1", "Fecha de expiración inválida")
            LoadReason("Q2", "Código de transacción inválido")
            LoadReason("Q3", "Disposición menor al limite permiido")
            LoadReason("Q4", "Número de veces usada excedido")
            LoadReason("Q5", "Delincuente")
            LoadReason("Q6", "Problema en BD")
            LoadReason("Q7", "Monto excedido")
            Exit Sub
Fin:
            MsgBox("No se pudo inicializar la Clase")
    End Sub
    Private Sub CargaIso200(ByRef pId As Short, ByRef pLong As Short, ByRef pFormat As String, ByRef pHeader As Short, ByRef pDescription As String)
        Dim x As New clsCampos
        On Error GoTo fin

        x.Id = pId
        x.Length = pLong
        x.fmt = pFormat
        x.Header = pHeader
        x.Description = pDescription
        Iso.Add(x, CStr(pId))
        Exit Sub
Fin:
        MsgBox("Error Cargando Formato de Mensaje (" & pId & ")" & vbCrLf & Err.Description)
    End Sub
    Private Sub LoadReason(ByRef pId As String, ByRef pDescription As String)
        Dim x As New clsReasonCode
        On Error GoTo fin

        x.Id = pId
        x.Description = pDescription
        IsoReason.Add(x, pId)
        Exit Sub
Fin:        
        MsgBox("Error Cargando Razones (" & pId & ")" & vbCrLf & Err.Description)
    End Sub

    Public Sub GrabaLog(ByRef pMsg As String)
        FileOpen(1, "c:\" & "SateliteLog.txt", OpenMode.Append)
        PrintLine(1, VB6.Format(Now, "DD/MM/YYYY") & " " & VB6.Format(Now, "HH:MM") & vbTab & pMsg)
        FileClose(1)
    End Sub

    Public Sub GrabaLog2(ByRef pMsg As String)
        FileOpen(2, "c:\" & "MsgRecibido.txt", OpenMode.Append)
        PrintLine(2, VB6.Format(Now, "DD/MM/YYYY") & " " & VB6.Format(Now, "HH:MM") & vbTab & pMsg)
        FileClose(2)
    End Sub

End Module
