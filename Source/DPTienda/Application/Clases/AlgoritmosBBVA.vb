Public Class AlgoritmosBBVA

    Public Function GetReferenciaAlg10(ByVal NumRef As String, ByVal Fecha As DateTime, ByVal Importe As String) As String

        Dim dia As Integer, mes As Integer, anio As Integer, iFecha As Integer
        Dim sRefFinal As String = ""

        Try
            dia = Fecha.Day - 1
            mes = (Fecha.Month - 1) * 31
            anio = (Fecha.Year - 1988) * 372
            iFecha = anio + mes + dia

            'Dim importe As String = "1556.32"
            Dim iLen As Integer, iVal As Integer, iValTot As Integer, iCont As Integer, i As Integer
            Dim sVal As String, iRes2 As Integer

            iLen = Importe.Trim.Length - 1
            iVal = 0
            iValTot = 0
            iCont = 0

            For i = 0 To iLen
                sVal = Importe.Trim.Substring(iLen - i, 1)
                If sVal <> "," AndAlso sVal <> "." Then
                    iCont += 1
                    Select Case iCont
                        Case 1
                            iVal = CInt(sVal.Trim) * 7
                            iValTot += iVal
                        Case 2
                            iVal = CInt(sVal.Trim) * 3
                            iValTot += iVal
                        Case 3
                            iVal = CInt(sVal.Trim) * 1
                            iValTot += iVal
                            iCont = 0
                    End Select
                End If
            Next
            iRes2 = iValTot Mod 10

            Dim sRefCon As String, sImporte As String, iRes3 As Integer

            sRefCon = NumRef & iFecha & iRes2 & "2"

            iLen = sRefCon.Trim.Length - 1
            iVal = 0
            iValTot = 0
            iCont = 0

            For i = 0 To iLen
                sVal = sRefCon.Trim.Substring(iLen - i, 1)
                If sVal <> "," AndAlso sVal <> "." Then
                    iCont += 1
                    Select Case iCont
                        Case 1
                            iVal = CInt(sVal.Trim) * 11
                            iValTot += iVal
                        Case 2
                            iVal = CInt(sVal.Trim) * 13
                            iValTot += iVal
                        Case 3
                            iVal = CInt(sVal.Trim) * 17
                            iValTot += iVal
                        Case 4
                            iVal = CInt(sVal.Trim) * 19
                            iValTot += iVal
                        Case 5
                            iVal = CInt(sVal.Trim) * 23
                            iValTot += iVal
                            iCont = 0
                    End Select
                End If
            Next
            iRes3 = (iValTot Mod 97) + 1

            sRefFinal = NumRef & iFecha & iRes2 & "2" & iRes3
        Catch ex As Exception
            EscribeLog(ex.ToString, "Ocurrio un error al generar la referencia con el algoritmo 10 de Bancomer")
            sRefFinal = ""
        End Try

        Return sRefFinal

    End Function

End Class
