Imports DPSoft.Framework
Imports DPSoft.Framework.ApplicationContext
Imports DPSoft.Framework.Configuration
Imports DPSoft.Framework.Data
Imports DPSoft.Framework.ExceptionReporting
Imports System.IO

Module MainModule

    Public strConnectionString As String = ""
    Public strRutaActualizacion As String = ""
    Public strUser As String = ""
    Public strPassword As String = ""
    Public strDatabase As String = ""
    Public strAlmacen As String = ""
    Public strCodCaja As String = ""
    Public strServer As String = ""
    Public oSecurity As SecurityHash

    <STAThread()> _
    Public Sub Main()

        'oAppContext = New DPValeFinanciero.Core.ApplicationContext(Application.StartupPath & "\DPValeFinanciero.exe.cml")

        '<Agregar Handler de excepciones no controladas>
        AddHandler Application.ThreadException, AddressOf OnThreadException
        '</Agregar Handler de excepciones no controladas>

LoadSettings:
        Try

            LeerArchivosConfig()

        Catch oException As ConfigurationFileNotFoundException

            'MessageBox.Show("La aplicación no ha sido configurada.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'oAppContext.ShowSettingsEditor()

            'GoTo LoadSettings
            EscribeLog(oException.ToString, "ConfigurationFileNotFoundException")

            Exit Sub

        Catch oException As ConfigurationLoadFileException

            'oAppContext.ExceptionReporting.HandleException(oException)
            EscribeLog(oException.ToString, "ConfigurationLoadFileException")
            Exit Sub

        Catch oException As Exception

            'oAppContext.ExceptionReporting.HandleException(oException)
            EscribeLog(oException.ToString, "Error Cargando Config")
            Exit Sub

        End Try

        Dim frmMain As New frmLiveUpdate

        Try
            
            Application.Run(frmMain)

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error General Aplicacion")
        End Try

    End Sub

    Public Sub OnThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)

        'oAppContext.ExceptionReporting.HandleException(e.Exception)

    End Sub

    Private Sub EncriptarCML(ByVal RutaArchivo As String)
        Dim strCont As String = ""
        Dim StreamR As StreamReader
        Dim StreamW As StreamWriter
        Dim oSecurity As SecurityHash
        oSecurity = New SecurityHash

        If File.Exists(RutaArchivo) Then

            StreamR = New StreamReader(RutaArchivo, System.Text.Encoding.Default)
            strCont = StreamR.ReadToEnd
            StreamR.Close()

            Try
                strCont = oSecurity.EncriptarCML(strCont)
            Catch ex As Exception

            End Try

            StreamW = New StreamWriter(RutaArchivo, False)
            StreamW.Write(strCont)
            StreamW.Close()

            StreamR = Nothing
            StreamW = Nothing

        End If
    End Sub

    Private Sub LeerArchivosConfig()

        Dim Linea As String = ""
        Dim Campo As String = ""
        Dim oStreamR As StreamReader
        Dim oStreamW As StreamWriter
        Dim strConfig As String = ""
        Dim bolBand As Boolean = False
        Dim RutaTemp As String = Application.StartupPath & "\temp.txt"
        Dim Ruta As String = Application.StartupPath & "\configCierre.cml"
        Dim strContenido As String = ""
        Dim strServerLocal As String = ""
        Dim strDatabaseLocal As String = ""
        Dim strUserLocal As String = ""
        Dim strPasswordLocal As String = ""

        oSecurity = New SecurityHash

LeeArchivo:
        oStreamR = New StreamReader(Ruta)

        strConfig = oStreamR.ReadToEnd
        oStreamR.Close()
        oStreamR = Nothing

        Try
            strConfig = oSecurity.DesEncriptarCML(strConfig)
        Catch ex As Exception
            EncriptarCML(Ruta)
            GoTo LeeArchivo
        End Try

        strContenido &= strConfig

        If bolBand = False Then
            bolBand = True
            Ruta = Application.StartupPath & "\DPTienda.exe.cml"
            GoTo LeeArchivo
        End If

        oStreamW = New StreamWriter(RutaTemp)
        oStreamW.Write(strContenido)
        oStreamW.Close()
        oStreamW = Nothing

        oStreamR = New StreamReader(RutaTemp)

        Linea = oStreamR.ReadLine

        Do

            Campo = Linea.Substring(0, InStr(Linea, ">"))
            Select Case Campo.Trim.ToUpper
                Case "<RUTAACTUALIZACION>"
                    strRutaActualizacion = Linea.Substring(InStr(Linea, ">"), InStr(InStr(Linea, "<") + 1, Linea, "<") - InStr(Linea, ">") - 1).Trim
                Case "<SERVERHUELLAS>"
                    strServerLocal = Linea.Substring(InStr(Linea, ">"), InStr(InStr(Linea, "<") + 1, Linea, "<") - InStr(Linea, ">") - 1).Trim
                Case "<BASEDATOSHUELLAS>"
                    strDatabaselocal = Linea.Substring(InStr(Linea, ">"), InStr(InStr(Linea, "<") + 1, Linea, "<") - InStr(Linea, ">") - 1).Trim
                Case "<USERHUELLAS>"
                    strUserLocal = Linea.Substring(InStr(Linea, ">"), InStr(InStr(Linea, "<") + 1, Linea, "<") - InStr(Linea, ">") - 1).Trim
                Case "<PASSHUELLAS>"
                    strPasswordlocal = Linea.Substring(InStr(Linea, ">"), InStr(InStr(Linea, "<") + 1, Linea, "<") - InStr(Linea, ">") - 1).Trim
                Case "<ALMACEN>"
                    strAlmacen = Linea.Substring(InStr(Linea, ">"), InStr(InStr(Linea, "<") + 1, Linea, "<") - InStr(Linea, ">") - 1).Trim
                Case "<NOCAJA>"
                    strCodCaja = Linea.Substring(InStr(Linea, ">"), InStr(InStr(Linea, "<") + 1, Linea, "<") - InStr(Linea, ">") - 1).Trim
                Case "<DataStorageConfiguration>".ToUpper
                    Linea = oStreamR.ReadLine
                    Linea = oStreamR.ReadLine
                    strServer = Linea.Substring(InStr(Linea, ">"), InStr(InStr(Linea, "<") + 1, Linea, "<") - InStr(Linea, ">") - 1).Trim
                    Linea = oStreamR.ReadLine
                    strDatabase = Linea.Substring(InStr(Linea, ">"), InStr(InStr(Linea, "<") + 1, Linea, "<") - InStr(Linea, ">") - 1).Trim
                    Linea = oStreamR.ReadLine
                    strUser = Linea.Substring(InStr(Linea, ">"), InStr(InStr(Linea, "<") + 1, Linea, "<") - InStr(Linea, ">") - 1).Trim
                    Linea = oStreamR.ReadLine
                    strPassword = Linea.Substring(InStr(Linea, ">"), InStr(InStr(Linea, "<") + 1, Linea, "<") - InStr(Linea, ">") - 1).Trim
            End Select

            Linea = oStreamR.ReadLine

        Loop While Not Linea Is Nothing

        strConnectionString = "Server=" & strServerLocal & ";Data Source=" & strServerLocal & ";Initial Catalog=" & strDatabaseLocal & ";User ID=" & _
                    strUserLocal & ";Password=" & strPasswordLocal & ";Application Name=;Connection Timeout=120;"

        If strRutaActualizacion.Trim = "" Then strRutaActualizacion = "C:\LiveUpdate"

        oStreamR.Close()
        oStreamR = Nothing

        File.Delete(RutaTemp)

    End Sub

    Public Sub EscribeLog(ByVal strError As String, ByVal Titulo As String)

        Dim StreamW As New StreamWriter(Application.StartupPath & "\ErrorLiveLogFile.txt", True)

        StreamW.WriteLine(Now.ToString & " --> " & Titulo.ToUpper & vbCrLf)
        StreamW.WriteLine("Detalle --> " & strError)
        StreamW.WriteLine("".PadLeft(100, "-"))

        StreamW.Close()

    End Sub

End Module
