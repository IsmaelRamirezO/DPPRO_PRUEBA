Imports System.IO
Imports System.Diagnostics
Imports ICSharpCode.SharpZipLib.Zip
Imports System.ServiceProcess

Public Class frmLiveUpdate
    Inherits System.Windows.Forms.Form

    Dim oLiveUpdMgr As LiveUpdateManager
    Dim so_Info As OperatingSystem

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
    Friend WithEvents timer1 As System.Timers.Timer
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents pgStatus As Janus.Windows.EditControls.UIProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLiveUpdate))
        Me.timer1 = New System.Timers.Timer()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblArchivo = New System.Windows.Forms.Label()
        Me.pgStatus = New Janus.Windows.EditControls.UIProgressBar()
        CType(Me.timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'timer1
        '
        Me.timer1.Enabled = True
        Me.timer1.Interval = 1000.0R
        Me.timer1.SynchronizingObject = Me
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.lblArchivo)
        Me.explorerBar1.Controls.Add(Me.pgStatus)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(394, 72)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblArchivo
        '
        Me.lblArchivo.BackColor = System.Drawing.Color.Transparent
        Me.lblArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchivo.Location = New System.Drawing.Point(10, 8)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(270, 16)
        Me.lblArchivo.TabIndex = 7
        Me.lblArchivo.Text = "Label1"
        '
        'pgStatus
        '
        Me.pgStatus.Location = New System.Drawing.Point(10, 32)
        Me.pgStatus.Name = "pgStatus"
        Me.pgStatus.ShowPercentage = True
        Me.pgStatus.Size = New System.Drawing.Size(374, 23)
        Me.pgStatus.TabIndex = 4
        Me.pgStatus.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmLiveUpdate
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(394, 72)
        Me.ControlBox = False
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLiveUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizando Versión DportenisPro"
        Me.TopMost = True
        CType(Me.timer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "ZIP"

    Public Sub Descomprimir(ByVal directorio As String, _
                                Optional ByVal zipFic As String = "", _
                                Optional ByVal eliminar As Boolean = False, _
                                Optional ByVal renombrar As Boolean = False)
        ' descomprimir el contenido de zipFic en el directorio indicado.
        ' si zipFic no tiene la extensión .zip, se entenderá que es un directorio y
        ' se procesará el primer fichero .zip de ese directorio.
        ' si eliminar es True se eliminará ese fichero zip después de descomprimirlo.
        ' si renombrar es True se añadirá al final .descomprimido
        If Not zipFic.ToLower.EndsWith(".zip") Then
            zipFic = Directory.GetFiles(zipFic, "*.zip")(0)
        End If
        ' si no se ha indicado el directorio, usar el actual
        If directorio = "" Then directorio = "."
        '
        Dim z As New ZipInputStream(File.OpenRead(zipFic))
        Dim theEntry As ZipEntry
        '
        Do
            theEntry = z.GetNextEntry()
            If Not theEntry Is Nothing Then
                'Dim fileName As String = directorio & "\" & Path.GetFileName(theEntry.Name)
                Dim fileName As String = directorio & "\" & theEntry.Name
                '
                ' dará error si no existe el path
                Dim streamWriter As FileStream
                Try
                    If Not theEntry.IsDirectory Then
                        streamWriter = File.Create(fileName)
                    Else
                        If Not Directory.Exists(fileName) Then Directory.CreateDirectory(fileName)
                    End If
                Catch ex As DirectoryNotFoundException
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName))
                    streamWriter = File.Create(fileName)
                End Try
                '
                If Not theEntry.IsDirectory Then
                    Dim size As Integer
                    Dim data(2048) As Byte
                    Do
                        size = z.Read(data, 0, data.Length)
                        If (size > 0) Then
                            streamWriter.Write(data, 0, size)
                        Else
                            Exit Do
                        End If
                    Loop
                    streamWriter.Close()
                End If
            Else
                Exit Do
            End If
        Loop
        z.Close()
        '
        ' cuando se hayan extraído los ficheros, renombrarlo
        If renombrar Then
            File.Copy(zipFic, zipFic & ".descomprimido")
        End If
        If eliminar Then
            File.Delete(zipFic)
        End If
    End Sub

#End Region

#Region "API"

    Private PROGRESS_CANCEL As Integer = 0

    Private Delegate Function CopyProgressRoutine(ByVal totalFileSize As Int64, ByVal totalBytesTransferred As Int64, ByVal streamSize As Int64, ByVal streamBytesTransferred As Int64, ByVal dwStreamNumber As Int32, ByVal dwCallbackReason As Int32, ByVal hSourceFile As Int32, ByVal hDestinationFile As Int32, ByVal lpData As Int32) As Int32

    Private Declare Auto Function CopyFileEx Lib "kernel32.dll" (ByVal lpExistingFileName As String, ByVal lpNewFileName As String, ByVal lpProgressRoutine As CopyProgressRoutine, ByVal lpData As Int32, ByVal lpBool As Int32, ByVal dwCopyFlags As Int32) As Int32

    Private Function CopyProgress(ByVal totalFileSize As Int64, ByVal totalBytesTransferred As Int64, ByVal streamSize As Int64, ByVal streamBytesTransferred As Int64, ByVal dwStreamNumber As Int32, ByVal dwCallbackReason As Int32, ByVal hSourceFile As Int32, ByVal hDestinationFile As Int32, ByVal lpData As Int32) As Int32

        Me.pgStatus.Value = Convert.ToInt32(totalBytesTransferred / totalFileSize * 100)

        Application.DoEvents()

        Return PROGRESS_CANCEL

    End Function


#End Region

#Region "Metodos"

    Private Sub ActualizarVersion()

        Dim UltimaV As Long

        Try
1:          If TieneUltimaVersion(UltimaV, "UV", "Version") = False Then

                Dim result As Integer
2:              Dim CPR As New CopyProgressRoutine(AddressOf CopyProgress)
                Dim oFile As FileInfo
                Dim strRutaArchivos As String = ""
                Dim strRutaArchivoZip As String = ""

3:              strRutaArchivos = strRutaActualizacion & "\Archivos"

                'If Not Directory.Exists(strRutaArchivos) Then Directory.CreateDirectory(strRutaArchivos)
                'strRutaArchivoZip = strRutaActualizacion & "\DPPROv" & UltimaV & ".zip"
                'Me.lblArchivo.Text = "Descomprimiendo Archivo Actualizacion"
                'Descomprimir(strRutaArchivos, strRutaArchivoZip)

4:              If CopiarArchivos(strRutaArchivos, UltimaV) Then
5:                  Me.lblArchivo.Text = "Ejecutando SP de la version"
6:                  Application.DoEvents()
7:                  EjecutaSP(strRutaArchivos & "\SP\", "SP_" & CStr(UltimaV) & ".sql")
8:                  EliminarArchivos(strRutaArchivos)
9:                  Me.lblArchivo.Text = "Actualizacion Terminada"
                    Try
10:                     Process.Start(Application.StartupPath & "\DPTienda.exe")
                    Catch ex As Exception
                        EscribeLog(ex.ToString, "Error al ejecutar DPTienda")
                    End Try
                Else
                    MessageBox.Show("Ocurrio un error al actualizar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Close()

            Else
                MessageBox.Show("Ya cuenta con la última versión del sistema.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al actualizar la version del DportenisPRO: Linea " & Err.Erl)
        End Try

    End Sub

    Private Function GetSQLService() As Boolean

        Dim mySC As New ServiceController("MSSQLSERVER")
        Dim status As String = ""
        Dim bFound As Boolean = False
        'Buscamos que el servicio MSSQLSERVER se este ejecutando para ejecutar el SP de la version
        Try
            status = mySC.Status.ToString
            bFound = True
        Catch ex As Exception
            EscribeLog(ex.ToString, "Ocurrio un error al revisar el servicio de SQL Server MSSQLSERVER")
        End Try
        'Si no fue encontrado buscamos el servicio con el nombre de SQLEXPRESS2012
        If bFound = False Then
            Try
                mySC = New ServiceController("SQLEXPRESS2012")
                status = mySC.Status.ToString
                bFound = True
            Catch ex As Exception
                EscribeLog(ex.ToString, "Ocurrio un error al revisar el servicio de SQL Server SQLEXPRESS2012")
            End Try
        End If
        'Si no fue encontrado buscamos el servicio con el nombre de SQLEXPRESS
        If bFound = False Then
            Try
                mySC = New ServiceController("SQLEXPRESS")
                status = mySC.Status.ToString
                bFound = True
            Catch ex As Exception
                EscribeLog(ex.ToString, "Ocurrio un error al revisar el servicio de SQL Server SQLEXPRESS")
            End Try
        End If
        'Si no encontramos el servicio con ninguno de los nombres anteriores entonces no está corriendo
        If bFound = False Then EscribeLog("No se encontro el servicio de SQL Server Instalado en esta PC", "No se encontro el servicio de SQL Server")

        Return bFound

    End Function

    Private Sub EjecutaSP(ByVal RutaScript As String, ByVal NombreScript As String)

        Dim UltimaV As Long

        Try
1:          If TieneUltimaVersion(UltimaV, "UV", "SP") = False Then
2:              If Directory.Exists(RutaScript) AndAlso File.Exists(RutaScript & NombreScript) Then

                    '3:                  Dim RutaSQL As String = "C:\Archivos de programa\Microsoft SQL Server\80\Tools\Binn\isqlw.exe"
                    '--------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 11.09.2014: Revisamos si tiene instalado SQL Server para saber si le ejecutamos o no el script de la version
                    '--------------------------------------------------------------------------------------------------------------------------
                    '4:                  If File.Exists(RutaSQL) Then
                    '--------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 14.07.2015: Comentamos este IF por lo pronto para buscar otra forma de saber si tiene instalado el SQL Sever o no
                    '--------------------------------------------------------------------------------------------------------------------------
                    '4:                  If GetSQLService() Then

                    '5: Process.Start(RutaSQL, "-E -U " & strUser & " -P " & strPassword & " -d " & strDatabase & " -i " & RutaScript & NombreScript & " -o " & RutaScript & "result.sql")


                    '6:                      Dim oProcesos() As Process
                    '                        Dim HoraIni As DateTime = Now

                    '                        Do
                    '7:                          oProcesos = Process.GetProcessesByName("isqlw")
                    '8:                          If oProcesos.Length <= 0 OrElse Now.Subtract(HoraIni).Seconds >= 30 Then Exit Do
                    '9:                          Threading.Thread.Sleep(500)
                    '                        Loop

                    '9:                      Application.DoEvents()
                    '10:                     If File.Exists(RutaScript & "\result.sql") Then oLiveUpdMgr.ActualizaVersionSuc(strAlmacen, strCodCaja, UltimaV, "SP") 'Exit Do

                    'UpdateScript(RutaScript)
                    '--------------------------------------------------------------------------------------------------------------------
                    'Obtenemos el contenido del archivo y ejecutamos las sentencias SQL
                    '--------------------------------------------------------------------------------------------------------------------
5:                  Dim oReader As New StreamReader(RutaScript & NombreScript)
                    Dim strQuery As String = ""
                    Dim bRes As Boolean = False

6:                  strQuery = oReader.ReadToEnd.Trim
                    'strQuery = File.ReadAllText(RutaScript & NombreScript)
7:                  bRes = oLiveUpdMgr.EjecutaSPVersion(strQuery)

8:                  oReader.Close()
9:                  oReader = Nothing

                    '--------------------------------------------------------------------------------------------------------------------
                    'Validamos si se ejecutó correctamente el SP en cuyo caso actualizamos la tabla de versiones sucursal
                    '--------------------------------------------------------------------------------------------------------------------
10:                 If bRes Then oLiveUpdMgr.ActualizaVersionSuc(strAlmacen, strCodCaja, UltimaV, "SP")

                    '--------------------------------------------------------------------------------------------------------------------
                    'Validamos si se ejecutó correctamente el SP en cuyo caso actualizamos la tabla de versiones sucursal
                    '--------------------------------------------------------------------------------------------------------------------
                    '10:                     If ValidarEjecucionSP(RutaScript) Then oLiveUpdMgr.ActualizaVersionSuc(strAlmacen, strCodCaja, UltimaV, "SP") 'Exit Do

                End If
            End If
            '            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error Ejecutando SP: Linea " & Err.Erl)
            MessageBox.Show("Ocurrio un error al ejecutar el SP de la version", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Function UpdateScript(ByVal RutaScript As String) As Boolean
        Try
            Dim proceso As New Process
            If Environment.OSVersion.Version.Major = 5 Then
                If Environment.OSVersion.Version.Minor = 1 Then
                    'XP
                    proceso.StartInfo.FileName = "OSQL -S .\ -U sa -P sa -i " & RutaScript
                ElseIf Environment.OSVersion.Version.Minor = 2 Then
                    'Server 2003.  XP 64-bit will also fall in here.
                    proceso.StartInfo.FileName = "OSQL -S .\ -U sa -P sa -i " & RutaScript
                End If
            ElseIf Environment.OSVersion.Version.Major >= 6 Then
                'Vista on up
                proceso.StartInfo.FileName = "sqlcmd -S (local) -i " & RutaScript
            End If
            proceso.StartInfo.CreateNoWindow = True
            proceso.StartInfo.UseShellExecute = False
            proceso.Start()
            proceso.WaitForExit()
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al actualizar el script de base de datos")
        End Try
        
    End Function

    'Private Function EjecutarSPVersion(ByVal rutaSP As String) As Boolean

    '    Dim oReader As New StreamReader(rutaSP)
    '    Dim strQuery As String = ""
    '    Dim bRes As Boolean = False

    '    strQuery = oReader.ReadToEnd.Trim

    '    bRes = oLiveUpdMgr.EjecutaSPVersion(strQuery)

    '    oReader.Close()
    '    oReader = Nothing

    '    Return bRes

    'End Function

    Private Function ValidarEjecucionSP(ByVal RutaScript As String) As Boolean

        Try
            Dim bRes As Boolean = False
            Dim oReader As StreamReader
            Dim RutaResult As String = RutaScript & "result.sql"

1:          If File.Exists(RutaResult) = False Then
2:              bRes = False
            Else
3:              oReader = New StreamReader(RutaResult)
4:              If InStr(oReader.ReadToEnd.Trim, "EJECUCION CORRECTA") > 0 Then
                    bRes = True
                Else
                    bRes = False
                End If
6:              oReader.Close()
7:              oReader = Nothing
            End If

            Return bRes
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al validar archivo de resultados del SP. Linea " & Err.Erl)
        End Try

    End Function

    Private Sub EliminarArchivos(ByVal Ruta As String)

        Dim RutaSP As String = Ruta & "\SP"
        Dim Archivos() As String

        Try
1:          If Directory.Exists(RutaSP) Then
2:              Archivos = Directory.GetFiles(RutaSP)

3:              If Not Archivos Is Nothing AndAlso Archivos.Length > 0 Then
4:                  For Each str As String In Archivos
                        Try
5:                          File.Delete(str)
                        Catch ex As Exception
6:                          EscribeLog(ex.ToString, "Error Eliminando Archivo En SP: " & str)
                        End Try
                    Next
                End If
            End If

7:          Archivos = Nothing

8:          Archivos = Directory.GetFiles(Ruta)

9:          If Not Archivos Is Nothing AndAlso Archivos.Length > 0 Then
10:             For Each str2 As String In Archivos
                    Try
11:                     File.Delete(str2)
                    Catch ex As Exception
12:                     EscribeLog(ex.ToString, "Error Eliminando Archivo: " & str2)
                    End Try
                Next
            End If

13:         If Directory.Exists(RutaSP) Then Directory.Delete(RutaSP)
14:         System.Threading.Thread.Sleep(3000)
15:         Application.DoEvents()
16:         Directory.Delete(Ruta)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error Eliminando Archivos: Linea " & Err.Erl)
        End Try

    End Sub

    Private Function CopiarArchivos(ByVal Ruta As String, ByVal UltimaV As Long) As Boolean

        Dim bolResult As Boolean = True

        Try
            Dim oProcesos() As Process
1:          Dim Archivos() As String = Directory.GetFiles(Ruta)
2:          Dim oFile As FileInfo
3:          Dim result As Integer
4:          Dim CPR As New CopyProgressRoutine(AddressOf CopyProgress)
            Dim cont As Integer = 0
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'No aseguramos que el no este corriendo el proceso del DPTienda antes de empezar a copiar los archivos
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            '            Do
            '5:              oProcesos = Process.GetProcessesByName("DPTienda")
            '6:              If oProcesos.Length <= 0 Then
            '                    Exit Do
            '7:              ElseIf cont = 5 Then
            '8:                  For Each p As Process In oProcesos
            '9:                      p.Kill()
            '                    Next
            '10:                 Application.DoEvents()
            '                Else
            '11:                 cont += 1
            '                End If
            '            Loop
            Me.Cursor = Cursors.WaitCursor
            System.Threading.Thread.Sleep(30000)
            Me.Cursor = Cursors.Default
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Empezamos con el proceso dd copiado
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
12:         If Archivos.Length > 0 Then
13:             Me.pgStatus.Maximum = Archivos.Length
14:             Me.pgStatus.Minimum = 0
15:             For Each str As String In Archivos
16:                 oFile = New FileInfo(str)
17:                 If oFile.Name.Trim.ToUpper <> "LiveUpdate.exe".ToUpper Then
18:                     Me.lblArchivo.Text = "Copiando... " & oFile.Name
                        Application.DoEvents()
19:                     'result = CopyFileEx(str, Application.StartupPath & "\" & oFile.Name, CPR, 0, 0, 0)
                        Try
20:                         File.Copy(str, Application.StartupPath & "\" & oFile.Name, True)
                        Catch ex As Exception
21:                         EscribeLog(ex.ToString, "Error al actualizar el archivo " & oFile.Name)
22:                         bolResult = False
                        End Try
23:                     If bolResult = False Then Exit Try
                        'If result = 0 Then
                        '    EscribeLog(Err.Description, "Error al actualizar el archivo " & oFile.Name)
                        '    bolResult = False
                        '    Exit Try
                        'End If
                        'File.Copy(str, Application.StartupPath & "\" & oFile.Name, True)
                    End If
24:                 Me.pgStatus.Value += 1
                Next
            End If
25:         oLiveUpdMgr.ActualizaVersionSuc(strAlmacen, strCodCaja, UltimaV, "Version")
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error Proceso Copiado: Linea " & Err.Erl)
            bolResult = False
        End Try

        Return bolResult

    End Function

    Private Function TieneUltimaVersion(ByRef UltimaV As Long, ByVal Sistema As String, ByVal Version As String) As Boolean

        Dim VersionSuc As Long

        UltimaV = oLiveUpdMgr.GetUltimaVersion(Sistema, strAlmacen)
        VersionSuc = oLiveUpdMgr.GetVersionSucursal(strAlmacen, strCodCaja, Version)

        If UltimaV > VersionSuc Then
            Return False
        Else
            Return True
        End If

    End Function

#End Region

#Region "Eventos"

    Private Sub frmLiveUpdate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.lblArchivo.Text = ""
        oLiveUpdMgr = New LiveUpdateManager(strConnectionString) 'oAppContext)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.pgStatus.Value = 0
        PROGRESS_CANCEL = 1

    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        PROGRESS_CANCEL = 0
        'CopiaArchivo()
        'Me.btnActualizar.Enabled = True
        'Me.btnCancelar.Enabled = True

    End Sub

    Private Sub timer1_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timer1.Elapsed

        Me.timer1.Enabled = False
        Application.DoEvents()
        ActualizarVersion()

    End Sub

#End Region


End Class
