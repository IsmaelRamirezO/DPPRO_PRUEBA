Imports System.Net.Sockets
Imports System.Text
Imports System
Imports Microsoft.Win32

Public Class clsCampos
    Public Id As System.Int16
    Public Length As System.Int16
    Public fmt As System.String
    Public Header As System.Int16
    Public Description As System.String
End Class
Public Class clsReasonCode
    Public Id As System.String
    Public Description As System.String
End Class
Public Class clsResultados
    Public Id As System.Int16
    Public Descripcion As System.String
    Public Valor As System.String
End Class
Public Class POSeHub
    Public vIso As New Collection
    Private vSession As Short
    Private mFolio As Integer

    Private i As Integer
    Private mTranType As String
    Private mLenStr As Object
    Private mLen As Short
    Private StrSql As String
    Private mRet As New Collection

    Private mStrOutput As String
    Private mProductIndicator As String
    Private mReleaseNumber As String
    Private mMsgStatus As String
    Private mOriginatorCode As String
    Private mResponderCode As String    

    Public Sub New()
        Call InitIso()
    End Sub
    Public Function PagoTarjeta(ByVal Sucursal As Int32, ByVal Caja As Int32, ByVal Cajero As String, ByVal Operacion As String, ByVal pPOSEntry As String, ByVal pTrack2 As String, ByVal Importe As Double, ByVal Ticket As String, ByRef pRespose As String, ByRef Auth As String, ByVal CardSN As String, ByVal DatosEMV As String, Optional ByVal Plazo As String = "", Optional ByVal Desface As String = "", Optional ByVal CVV2 As String = "", Optional ByVal Reverso As Boolean = False) As String
        '****************************************************************************
        'Mensaje200: TRANSACCION DE SERVICIO (PAGO O COMPRA)
        '****************************************************************************
        '     Header -> "ISO0250000500200"
        '     Bitmap -> "3238C40128A1809E"
        '****************************************************************************

        ' Construye mensaje 200
        Dim y As Object
        Dim mRet As Object
        Dim mRetNo As String
        Dim mInput As String
        Dim transact As String
        Dim mTimer As Double
        Dim mValor As String
        Dim StrSql As String
        Dim mResultado As String
        Dim mConnectionTimeout As Double
        Dim mTranType As String
        Dim mLenStr As String
        Dim mLen As Short
        Dim mDescOper As String
        Dim mRetrieval As String   'esta en este solemente
        Dim pRetrieval As String
        Dim pConsecutivo As Long
        Dim m43 As String
        Dim i As Integer
        Dim pPlan As String
        '--------------------------------------------------------------------------
        'Base 24 Header
        '--------------------------------------------------------------------------
        Dim mProductIndicator As New VB6.FixedLengthString(2)
        Dim mReleaseNumber As New VB6.FixedLengthString(2)
        Dim mMsgStatus As New VB6.FixedLengthString(3)
        Dim mOriginatorCode As New VB6.FixedLengthString(1)
        Dim mResponderCode As New VB6.FixedLengthString(1)
        '--------------------------------------------------------------------------
        Dim mReturn As String

        On Error Resume Next
        'm43 = Format$(Sucursal, "0000") & "-" & Format$(Caja, "000") & "-" & Format$(Cajero, "000000") & "-" & Ticket
        '-----------------------------------------------------------------------------------------------------------------------------------
        'Modificacion por el cambio de los codigos de vendedores a alfanumericos
        '-----------------------------------------------------------------------------------------------------------------------------------
        m43 = Format$(Sucursal, "0000") & "-" & Format$(Caja, "000") & "-" & Cajero.Trim.PadLeft(6, "0") & "-" & Ticket
        construyeIso(3, Operacion, "Operacion")
        construyeIso(4, VB6.Format(Importe, "000000000.00"), "Amount")
        construyeIso(7, VB6.Format(Now, "mmddhhnnss"), "Transmition Date")
        construyeIso(12, VB6.Format(Now, "hhnnss"), "Time Local Transaction")
        construyeIso(13, VB6.Format(Now, "mmdd"), "Date Local Transaction")
        construyeIso(17, VB6.Format(Now, "mmdd"), "Date Captured")
        construyeIso(22, pPOSEntry, "Entry Mode")
        construyeIso(35, pTrack2, "Track 2 Data")
        construyeIso(43, m43, "Información de Comercio")
        pPlan = Plazo & Desface
        construyeIso(61, pPlan, "Plan")
        construyeIso(63, CVV2, "CVV2")

        'If CInt(pPOSEntry) = 51 Then
        '    construyeIso(23, CardSN, "Card Sequence Number")
        '    If Operacion.Trim <> "010000" Then
        '        construyeIso(55, DatosEMV, "EMV Full Grade")
        '    End If
        'End If

        mValor = ConstruyeMascara("0200", vIso)
        vOut = ""
        'If CInt(pPOSEntry.Trim) = 51 Then
        '    mValor = "INS" & mValor
        'End If

        vOut = Envia(mValor, Operacion.Trim, Reverso)
        If Len(vOut) <= 0 Then
            PagoTarjeta = "Tiempo de Respuesta Excedido" & vbCrLf & "Revise Operación" & vbCrLf
            Exit Function
        End If
        Select Case Operacion
            Case "000000" : mDescOper = "COMPRA"
            Case "010000" : mDescOper = "PAGO"
            Case "000001" : mDescOper = "CONSULTA DE PROMOCIONES"
            Case "000002" : mDescOper = "REVERSO POR FALLA EN EMV"
            Case "000003" : mDescOper = "CTE FREC CONSULTA"
            Case "000004" : mDescOper = "CTE FREC MOVIMIENTO"
            Case "000005" : mDescOper = "CONSULTA CIA CELULAR"
            Case "000006" : mDescOper = "CONSULTA PLAN CELULAR"
            Case "000007" : mDescOper = "VENTA TA CELULAR"
            Case "000008" : mDescOper = "TARJETA REGALO SOLICITUD VENTA"
            Case "000009" : mDescOper = "TARJETA REGALO CONSULTA"
            Case "000010" : mDescOper = "TARJETA REGALO MOVIMIENTO"
            Case "000011" : mDescOper = "BONOS"
        End Select

        mValor = vOut
        mLenStr = Left(mValor, InStr(mValor, "ISO") - 1)
        mValor = Right(mValor, Len(mValor) - InStr(mValor, "ISO") + 1)
        mTranType = Left(mValor, 3)
        mValor = Right(mValor, Len(mValor) - 3)
        If mTranType <> "ISO" Then
            PagoTarjeta = "No es un mensaje ISO válido" & Microsoft.VisualBasic.vbCrLf
            Exit Function
        End If
        '--------------------------------------------------------------------------
        'Base 24 Header
        '--------------------------------------------------------------------------
        mProductIndicator.Value = Left(mValor, 2)
        mValor = Right(mValor, Len(mValor) - 2)
        mReleaseNumber.Value = Left(mValor, 2)
        mValor = Right(mValor, Len(mValor) - 2)
        mMsgStatus.Value = Left(mValor, 3)
        mValor = Right(mValor, Len(mValor) - 3)
        mOriginatorCode.Value = Left(mValor, 1)
        mValor = Right(mValor, Len(mValor) - 1)
        mResponderCode.Value = Left(mValor, 1)
        mValor = Right(mValor, Len(mValor) - 1)
        '--------------------------------------------------------------------------
        'Transacciones
        '--------------------------------------------------------------------------
        mTranType = Left(mValor, 4)
        mValor = Right(mValor, Len(mValor) - 4)
        '--------------------------------------------------------------------------
        'Primary Bitmap
        '--------------------------------------------------------------------------
        StrSql = Left(mValor, 16)
        mValor = Right(mValor, Len(mValor) - 16)
        '--------------------------------------------------------------------------
        'Decode and Process Return Message
        '--------------------------------------------------------------------------
        Mascara(StrSql, mRet, mValor)

        Select Case mTranType
            Case "0210" : mStrOutput = mStrOutput & "TRANSACCION PROCESADA" & vbCrLf
            Case "9200" : mStrOutput = mStrOutput & "TRANSACCION RECHAZADA: EL AUTORIZADOR NO PUEDE PROCESAR SU PETICION" & vbCrLf
            Case Else : mStrOutput = mStrOutput & "TRANSACCION RECHAZADA: ERROR EN EL FORMATO DEL MENSAJE" & vbCrLf
        End Select
        pRespose = mRet("39").Valor
        If CShort(mRet("39").Valor) <> 0 Then
            mStrOutput = mStrOutput & "RECHAZADO" & vbCrLf & IsoReason(CStr(CShort(mRet("39").Valor)))
        Else
            mStrOutput = mStrOutput & "PROCESO COMPLETO" & vbCrLf
            Auth = mRet("38").valor
        End If
        mStrOutput = mStrOutput & "Transaccion --> " & mTranType & vbCrLf
        For Each y In mRet
            mStrOutput = mStrOutput & y.Id & "====> " & y.Valor & vbCrLf
        Next y
        PagoTarjeta = mStrOutput
    End Function

    Public Function MSGISO800(ByVal Sucursal As Int32, ByVal Caja As Int32, ByVal Cajero As Int32, ByRef pConsecutivo As Integer, ByRef Operacion As String) As String
        '****************************************************************************
        'MSGISO800: Transaccion de Control
        '****************************************************************************
        '     Utiliza los Campos 7  --> Fecha de Transmision
        '                        11 --> Consecutivo
        '                        70 --> Tipo de Operación
        '     Valores de la Variable Operacion:
        '                         1:   Logon
        '                         2:   Logoff
        '                         201: CutOver (Notificación de Desconexión)
        '                         301: Echo
        '     Header -> "ISO0250000400800"
        '     Ejemplos => "ISO025000040080082200000000000000400000000000000DATOS"
        '     "ISO0250000400800822000000000000004000000000000000904172916000001001"
        '****************************************************************************
        Dim mConnectionTimeout As Double
        Dim mTranType As String
        Dim mLenStr As String
        Dim mLen As Short
        Dim mStrOutput As String
        Dim mValor As String
        Dim y As Object
        Dim i As Integer
        '--------------------------------------------------------------------------
        'Base 24 Header
        '--------------------------------------------------------------------------
        Dim mProductIndicator As New VB6.FixedLengthString(2)
        Dim mReleaseNumber As New VB6.FixedLengthString(2)
        Dim mMsgStatus As New VB6.FixedLengthString(3)
        Dim mOriginatorCode As New VB6.FixedLengthString(1)
        Dim mResponderCode As New VB6.FixedLengthString(1)
        '--------------------------------------------------------------------------
        Dim mRet As Object
        Dim mReturn As String
        Dim StrSql As String
        Dim mRetrieval As String
        Dim mPuertoPinPad As Boolean = False 'Se utiliza para saber si la transaccion se envia al puerto del pin pad o al server

        On Error Resume Next
        mTranType = "0800"

        Select Case CShort(Operacion)
            Case 1 : mStrOutput = "LOGON"
            Case 2 : mStrOutput = "LOGOFF"
            Case 201 : mStrOutput = "CUTOVER"
            Case 301 : mStrOutput = "ECHO"
        End Select
        mRetrieval = pConsecutivo
        construyeIso(7, VB6.Format(Now, "mmddhhnnss"), "Transmition Date")
        construyeIso(11, CStr(pConsecutivo), "Sistem Trace Audit Number")
        construyeIso(37, mRetrieval, "Retrieval Reference Number")
        construyeIso(70, Operacion, "Information Code")
        mValor = ConstruyeMascara("0800", vIso)

        Err.Clear()
        mPuertoPinPad = IIf(Operacion.Trim.ToUpper = "000000", True, False)
        vOut = Envia(mValor, mPuertoPinPad)
        If Err.Number <> 0 Then
            MSGISO800 = Err.Description
            Exit Function
        End If
        mValor = ""
        If vOut = "" Then
            MSGISO800 = "Tiempo de Respuesta Excedido" & vbCrLf & "Revise Operación"
            Exit Function
        End If
        mValor = vOut
        mLenStr = Left(mValor, InStr(mValor, "ISO") - 1)
        mValor = Right(mValor, Len(mValor) - InStr(mValor, "ISO") + 1)
        mTranType = Left(mValor, 3)
        mValor = Right(mValor, Len(mValor) - 3)
        If mTranType <> "ISO" Then
            MSGISO800 = "No es un mensaje ISO válido"
            Exit Function
        End If
        '--------------------------------------------------------------------------
        'Base 24 Header
        '--------------------------------------------------------------------------
        mProductIndicator.Value = Left(mValor, 2)
        mValor = Right(mValor, Len(mValor) - 2)
        mReleaseNumber.Value = Left(mValor, 2)
        mValor = Right(mValor, Len(mValor) - 2)
        mMsgStatus.Value = Left(mValor, 3)
        mValor = Right(mValor, Len(mValor) - 3)
        mOriginatorCode.Value = Left(mValor, 1)
        mValor = Right(mValor, Len(mValor) - 1)
        mResponderCode.Value = Left(mValor, 1)
        mValor = Right(mValor, Len(mValor) - 1)
        '--------------------------------------------------------------------------
        'Transacciones
        '--------------------------------------------------------------------------
        mTranType = Left(mValor, 4)
        mValor = Right(mValor, Len(mValor) - 4)
        If mTranType <> "0810" Then
            mStrOutput = mStrOutput & "ERROR EN EL MENSAJE" & vbCrLf
            MSGISO800 = mStrOutput
            Exit Function
        End If
        '--------------------------------------------------------------------------
        'Primary Bitmap
        '--------------------------------------------------------------------------
        StrSql = Left(mValor, 16)
        mValor = Right(mValor, Len(mValor) - 16)
        '--------------------------------------------------------------------------
        'Decode and Process Return Message
        '--------------------------------------------------------------------------
        Mascara(StrSql, mRet, mValor)
        If CShort(mRet("39").Valor) <> 0 Then
            mStrOutput = mStrOutput & " RECHAZADO"
        Else
            mStrOutput = mStrOutput & " PROCESO COMPLETO"
        End If
        MSGISO800 = mStrOutput
    End Function

    Private Sub GeneraSalida(ByRef pEntrada As String, ByRef pSalida As String, ByRef pResultado As String)
        Dim mEntrada As String
        Dim mRet As Integer
        Dim mResultado As String

        On Error Resume Next
        pEntrada = "ISO0250000500200" & pEntrada
        pEntrada = Chr((Len(pEntrada) + 1) \ 256) & Chr((Len(pEntrada)) Mod 256) & pEntrada
        pSalida = pEntrada
    End Sub


    Public Function construyeIso(ByRef pId As Short, ByRef pValorEnt As String, ByRef pDesc As String) As Object
        Dim mTipo As String
        Dim mlong As Short
        Dim mPref As Short
        Dim mPrefVal As String
        Dim mOut As String
        Dim mOutput As New clsResultados

        On Error Resume Next
        mTipo = Iso(pId).fmt
        mlong = Iso(pId).Length
        mPref = Iso(pId).Header
        Select Case mTipo
            Case "N"
                While InStr(pValorEnt, ".") > 0
                    pValorEnt = Left(pValorEnt, InStr(pValorEnt, ".") - 1) & Right(pValorEnt, Len(pValorEnt) - InStr(pValorEnt, "."))
                End While
                If mPref <> 0 Then
                    mPrefVal = CStr(Len(pValorEnt))
                    mOut = New String("0", mPref - Len(mPrefVal)) & mPrefVal & pValorEnt
                Else
                    mOut = New String("0", mlong - Len(pValorEnt)) & pValorEnt
                End If
            Case "ANS", "AN", "A", "Z"
                If mPref <> 0 Then
                    mPrefVal = CStr(Len(pValorEnt))
                    mOut = New String("0", mPref - Len(mPrefVal)) & mPrefVal & pValorEnt
                Else
                    mOut = pValorEnt & Space(mlong - Len(pValorEnt))
                End If
        End Select
        vIso.Remove(CStr(pId))
        Err.Clear()
        mOutput.Id = pId
        mOutput.Descripcion = pDesc
        mOutput.Valor = mOut
        vIso.Add(mOutput, CStr(pId))
        mOutput = Nothing
        construyeIso = mOut
    End Function

    Private Function Envia(ByVal msg As String, ByVal mOperacion As String, Optional ByVal Reverso As Boolean = False) As String
        Dim tcpClient As New System.Net.Sockets.TcpClient
        Dim mHost As String
        Dim mPort As Long
        Dim regVersion As RegistryKey
        Dim keyValue As String
        Dim valXEnviar As String
        Dim filler As String

        On Error Resume Next
        regVersion = Registry.LocalMachine.OpenSubKey(APPKEY, False)
        Select Case mOperacion
            Case "000000"
                mHost = regVersion.GetValue("EMVEnabled", "")
                mPort = regVersion.GetValue("EMVService", "")
            Case "000001"
                mHost = regVersion.GetValue("Host", "")
                mPort = regVersion.GetValue("SwitchPort", "")
            Case Else
                mHost = regVersion.GetValue("Host", "")
                mPort = regVersion.GetValue("RemotePort", "")
        End Select
        tcpClient.Connect(mHost, mPort)
        Dim networkStream As networkStream = tcpClient.GetStream()
        filler = Space(Len(msg) + 2)

        If networkStream.CanWrite And networkStream.CanRead Then
            Dim sendRealBytes As [Byte]() = Encoding.ASCII.GetBytes(filler)
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(msg)
            If Len(msg) < 256 Then
                sendRealBytes(0) = 0
            Else
                sendRealBytes(0) = (Len(msg) + 1) \ 256
            End If
            sendRealBytes(1) = (Len(msg)) Mod 256
            For i = 0 To sendBytes.Length
                sendRealBytes(i + 2) = sendBytes(i)
            Next
            networkStream.Write(sendRealBytes, 0, sendRealBytes.Length)
            If Reverso Then Return ""
            Dim bytes(tcpClient.ReceiveBufferSize) As Byte
            networkStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))
            filler = Space(bytes.Length)
            Err.Clear()
            Dim RealBytes As [Byte]() = Encoding.ASCII.GetBytes(filler)
            For i = 0 To bytes.Length - 3
                RealBytes(i) = bytes(i + 2)
            Next
            Dim returndata As String = Encoding.ASCII.GetString(RealBytes)
            Envia = Trim(returndata)
        Else
            If Not networkStream.CanRead Then
                Envia = ""
                tcpClient.Close()
            Else
                If Not networkStream.CanWrite Then
                    Envia = ""
                    tcpClient.Close()
                End If
            End If
        End If
    End Function
End Class
