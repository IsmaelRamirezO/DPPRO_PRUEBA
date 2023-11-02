Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class SecurityHash

    Function Encrypt(ByVal strPlainText As String, ByVal strKey24 As String) As String

        Dim crp As New TripleDESCryptoServiceProvider
        Dim uEncode As New UnicodeEncoding
        Dim aEncode As New ASCIIEncoding

        Dim bytPlainText As Byte() = uEncode.GetBytes(strPlainText)

        Dim stmCipherText As New MemoryStream

        Dim slt(0) As Byte

        Dim pdb As New PasswordDeriveBytes(strKey24, slt)

        Dim bytDerivedKey() As Byte = pdb.GetBytes(24)

        crp.Key = bytDerivedKey

        crp.IV = pdb.GetBytes(8)

        Dim csEncrypted As New CryptoStream(stmCipherText, crp.CreateEncryptor, CryptoStreamMode.Write)

        csEncrypted.Write(bytPlainText, 0, bytPlainText.Length)

        csEncrypted.FlushFinalBlock()

        Return Convert.ToBase64String(stmCipherText.ToArray())

    End Function

    Function Decrypt(ByVal strCipherText As String, ByVal strKey24 As String) As String

        Dim crp As New TripleDESCryptoServiceProvider
        Dim uEncode As New UnicodeEncoding
        Dim aEncode As New ASCIIEncoding

        Dim bytCipherText() As Byte = Convert.FromBase64String(strCipherText)

        Dim stmPlainText As New MemoryStream

        Dim stmCipherText As New MemoryStream(bytCipherText)

        Dim slt(0) As Byte

        Dim pdb As New PasswordDeriveBytes(strKey24, slt)

        Dim bytDerivedKey() As Byte = pdb.GetBytes(24)

        crp.Key = bytDerivedKey

        crp.IV = pdb.GetBytes(8)

        Dim csDecrypted As New CryptoStream(stmCipherText, crp.CreateDecryptor, CryptoStreamMode.Read)

        Dim sw As New StreamWriter(stmPlainText)

        Dim sr As New StreamReader(csDecrypted)

        sw.Write(sr.ReadToEnd)

        sw.Flush()

        csDecrypted.Clear()

        crp.Clear()

        Return uEncode.GetString(stmPlainText.ToArray())

    End Function

    Function BuildKey24() As String

        Dim a1 As Integer = 1 * 1
        Dim a2 As Integer = 5 * 2
        Dim a3 As Integer = (6 * 3) + 1
        Dim a4 As Integer = ((6 * 3) * 5) - 17

        Dim keyOne As String = Trim(Str(0)) & Trim(Str(a1)) & Trim(Str(a2)) & Trim(Str(a3)) & Trim(Str(a4))

        Dim b1 As Integer = (1 * 1) + 2
        Dim b2 As Integer = ((1 * 2) * 2) + 1
        Dim b3 As Integer = (6 * 3) + 1
        Dim b4 As Integer = ((6 * 3) * 5) - 14

        Dim keyTwo As String = Trim(Str(0)) & Trim(Str(b1)) & Trim(Str(0)) & Trim(Str(b2)) & Trim(Str(b3)) & Trim(Str(b4))

        Return Trim(keyOne + keyTwo)

    End Function

    Public Function EncriptarCML(ByVal strContenido As String) As String
        Try
            If Not strContenido Is Nothing Then
                Return Encrypt(strContenido, BuildKey24)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DesEncriptarCML(ByVal strContenido As String) As String

        Try
            If Not strContenido Is Nothing Then
                Return Decrypt(strContenido, BuildKey24)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
