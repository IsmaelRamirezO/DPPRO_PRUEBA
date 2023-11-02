Imports System.IO
Public Class Properties

    Private m_Properties As New Hashtable
    Private sr As StreamReader

    Public Sub New(ByVal ruta As String)
        sr = New StreamReader(ruta)
        Load()
    End Sub

    Private Sub Add(ByVal key As String, ByVal value As String)
        m_Properties.Add(key, value)
    End Sub

    Private Sub Load()

        Dim line As String
        Dim key As String
        Dim value As String
        Dim strSplit() As String
        If sr Is Nothing Then
            Exit Sub
        End If
        Do While sr.Peek <> -1
            line = sr.ReadLine
            If Not line Is Nothing AndAlso line.Length > 0 AndAlso line.Trim() <> "" AndAlso line.StartsWith("#") = False Then
                strSplit = line.Split("=")
                If strSplit.Length > 1 Then
                    key = strSplit(0)
                    value = strSplit(1)
                    Add(key, value)
                End If
            End If

        Loop
        sr.Close()
    End Sub

    Public Function GetProperty(ByVal key As String)

        Return m_Properties.Item(key)

    End Function

    Public Function GetProperty(ByVal key As String, ByVal defValue As String) As String

        Dim value As String = GetProperty(key)
        If value = Nothing Then
            value = defValue
        End If

        Return value

    End Function

End Class
