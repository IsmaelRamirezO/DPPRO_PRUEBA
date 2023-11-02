Imports System.Xml
Imports System.IO

Public Class MQTTXMLRFC
    Private NameBapi As String
    Private m_Parameters As Hashtable
    Private m_Tables As ArrayList
    Private Result As Hashtable
    Private XMLStringOut As String
    Private XMLStringIn As String
    Private m_Exports As Hashtable
    Private m_Err As String
    Private m_TimeRequest As Decimal
    Private m_Folio As String
    Private m_Almacen As String
    Private m_CodCaja As String
    Private m_RutaProperties As String
    Private m_properties As Properties
    Private m_NameFileXML As String
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

#Region "Constructores"
    Public Sub New(ByVal NameBapi As String)
        Me.NameBapi = NameBapi
        Me.m_Parameters = New Hashtable
        Me.m_Tables = New ArrayList
    End Sub

    Public Sub New(ByVal NameBapi As String, ByVal Parameters As Hashtable)
        Me.NameBapi = NameBapi
        Me.m_Parameters = Parameters
        Me.m_Tables = New ArrayList
    End Sub

    Public Sub New(ByVal NameBapi As String, ByVal Parameters As Hashtable, ByVal Tables As ArrayList)
        Me.NameBapi = NameBapi
        Me.m_Parameters = Parameters
        Me.m_Tables = Tables
    End Sub
#End Region

#Region "Propiedades"
    Public Property Parameters() As Hashtable
        Get
            Return m_Parameters
        End Get
        Set(ByVal Value As Hashtable)
            m_Parameters = Value
        End Set
    End Property

    Public Property Tables() As ArrayList
        Get
            Return m_Tables
        End Get
        Set(ByVal Value As ArrayList)
            m_Tables = Value
        End Set
    End Property

    Public ReadOnly Property Exports() As Hashtable
        Get
            Return m_Exports
        End Get
    End Property

    Public Property Err() As String
        Get
            Return m_Err
        End Get
        Set(ByVal Value As String)
            m_Err = Value
        End Set
    End Property

    Public Property TimeRequest() As Decimal
        Get
            Return m_TimeRequest
        End Get
        Set(ByVal Value As Decimal)
            m_TimeRequest = Value
        End Set
    End Property

    Public Property Folio() As String
        Get
            Return m_Folio
        End Get
        Set(ByVal Value As String)
            m_Folio = Value
        End Set
    End Property

    Public Property Almacen() As String
        Get
            Return m_Almacen
        End Get
        Set(ByVal Value As String)
            m_Almacen = Value
        End Set
    End Property

    Public Property CodCaja() As String
        Get
            Return m_CodCaja
        End Get
        Set(ByVal Value As String)
            m_CodCaja = Value
        End Set
    End Property

    Public Property RutaProperties() As String
        Get
            Return m_RutaProperties
        End Get
        Set(ByVal Value As String)
            m_RutaProperties = Value
            If Value <> "" Then
                Properties = New Properties(Value)
            End If
        End Set
    End Property

    Public Property Properties() As properties
        Get
            Return m_properties
        End Get
        Set(ByVal Value As properties)
            m_properties = Value
        End Set
    End Property

    Public Property NameFileXML() As String
        Get
            Return m_NameFileXML
        End Get
        Set(ByVal Value As String)
            m_NameFileXML = Value
        End Set
    End Property

#End Region

#Region "Metodos"

    Public Sub SetParameters(ByVal Parameters As Hashtable)
        Me.Parameters = Parameters
    End Sub


    Public Function Execute() As Boolean
        Dim valido As Boolean = False
        Dim xml As String = "<" & NameBapi.ToUpper() & ">" & vbCrLf
        For Each key As String In Parameters.Keys
            xml &= "<" & key.ToUpper() & ">" & Parameters(key) & "</" & key.ToUpper() & ">" & vbCrLf
        Next
        If Not Tables Is Nothing AndAlso Tables.Count > 0 Then
            xml &= "<TABLES>" & vbCrLf
            For Each table As DataTable In Tables.ToArray()
                xml &= "<" & table.TableName.ToUpper() & ">" & vbCrLf
                For Each row As DataRow In table.Rows
                    xml &= "<" & table.TableName.ToUpper() & "ROW>" & vbCrLf
                    For Each column As DataColumn In table.Columns
                        xml &= "<" & column.ColumnName.ToUpper() & ">" & CStr(row(column.ColumnName)) & "</" & column.ColumnName.ToUpper() & ">" & vbCrLf
                    Next
                    xml &= "</" & table.TableName.ToUpper() & "ROW>" & vbCrLf
                Next
                xml &= "</" & table.TableName.ToUpper() & ">" & vbCrLf
            Next
            xml &= "</TABLES>" & vbCrLf
        End If
        xml &= "</" & NameBapi.ToUpper() & ">"
        Me.XMLStringOut = xml
        RunMQTT(xml)
        Me.XMLStringIn = ReadXML()
        ProcessResults()
        If Me.Exports.ContainsKey("Error") = False Then
            valido = True
        End If
        Return valido
    End Function

    Private Function RunMQTT(ByVal xml As String) As Boolean
        Dim valido As Boolean = False
        Dim inicio As Long, fin As Long
        Try
            WriteXML(xml)
            inicio = DateTime.Now.Ticks
            Dim proceso As New Process
            Dim Exe As String = Environment.CurrentDirectory
            'reemplaza el .exe por .jar
            Exe &= "\AgenteMQTT.jar"
            Dim rutaPrograma As String = CStr(Me.Properties.GetProperty("Program"))

            proceso.StartInfo.WorkingDirectory = Environment.CurrentDirectory
            'proceso.StartInfo.FileName = "AgenteMQTT.jar"
            'proceso.StartInfo.UseShellExecute = False
            'proceso.StartInfo.CreateNoWindow = True

            'proceso.StartInfo.FileName = rutaPrograma
            proceso.StartInfo.FileName = "Agente.jar"
            proceso.StartInfo.Arguments = ""

            'proceso.StartInfo = info
Iniciar:

            Dim proc() As Process = Process.GetProcessesByName("javaw")
            For Each programa As Process In proc
                programa.Kill()
            Next
            ClearMemory()
            If File.Exists(Environment.CurrentDirectory & "/" & "Agente.jar") Then
                proceso.Start()
            Else
                GoTo Iniciar
            End If
            proceso.WaitForExit()
            fin = DateTime.Now.Ticks
            Me.TimeRequest = (fin - inicio) / TimeSpan.TicksPerMillisecond
            WriteTime(Me.NameBapi, CStr(Me.TimeRequest))
            EscribeLog(Environment.CurrentDirectory, "Ruta de programa")
            EscribeLog(rutaPrograma, "Nombre Programa")
            'EscribeLog(Me.NameBapi & " Milisegundos: " & CStr(Me.TimeRequest), Me.NameBapi)
            Console.WriteLine("Milisegundos: " & CStr(Me.TimeRequest))
            valido = True
        Catch ex As Exception
            valido = False
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    Private Sub WriteXML(ByVal xml As String)
        Try
            Dim ruta As String = Properties.GetProperty("FileInput")
            Me.NameFileXML = Me.Folio.PadLeft(10, "0") & "_" & Date.Now.ToString("dd-MM-yyyy-HH-mm-ss") & "_T" & Me.Almacen & "CJ" & Me.CodCaja & "_" & Me.NameBapi & ".xml"
            Dim NameXMLIn As String = ruta & "\" & Me.NameFileXML
            Dim file As New FileStream(NameXMLIn, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
            Dim writer As New StreamWriter(file)
            writer.WriteLine(xml)
            writer.Close()
            file.Close()
            'If System.IO.File.Exists(NameXMLIn) Then
            '    System.IO.File.Delete(NameXMLIn)
            'End If
        Catch ex As IOException
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Function ReadXML() As String
        Dim xml As String
        Dim reader As StreamReader = Nothing
        Try
            Dim ruta As String = Me.Properties.GetProperty("FileOutputCorrect")
            Dim rutaErr As String = Me.Properties.GetProperty("FileOutputError")
            ruta &= "\" & Me.NameFileXML
            If File.Exists(ruta) Then
                reader = New StreamReader(ruta)
                xml = reader.ReadToEnd()
                reader.Close()
                Return xml
            Else
                Dim err As String
                rutaErr &= "\" & Me.NameFileXML
                If File.Exists(rutaErr) Then
                    reader = New StreamReader(rutaErr)
                    err = reader.ReadToEnd()
                    reader.Close()
                    Me.Err = err
                    Throw New ApplicationException(err)
                Else
                    Me.Err = "No existe el archivo de error"
                    Throw New ApplicationException(Me.Err)
                End If
            End If
        Catch ex As IOException
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Function


    Private Sub ProcessResults()
        Dim dsResult As New DataSet
        Dim compare As String = "SAP" & Me.NameBapi.ToUpper()
        compare = compare.Replace("_", "")
        Dim name As String
        Dim exports As New Hashtable
        Dim tables As New ArrayList
        Dim valor As String
        Dim ruta As String = CStr(Me.Properties.GetProperty("FileOutputCorrect"))
        ruta &= "\" & Me.NameFileXML
        If File.Exists(ruta) Then
            If ValidarXML(ruta, exports) = True Then
                dsResult.ReadXml(ruta)
                For Each tabla As DataTable In dsResult.Tables
                    name = tabla.TableName.ToUpper()
                    If compare = name Then
                        For Each row As DataRow In tabla.Rows
                            For Each column As DataColumn In tabla.Columns
                                exports(column.ColumnName.ToUpper()) = row(column.ColumnName)
                            Next
                        Next
                    Else
                        exports(tabla.TableName.ToUpper()) = tabla
                    End If
                Next
            End If
        End If
        Me.m_Exports = exports
    End Sub

    Private Function ValidarXML(ByVal ruta As String, ByRef export As Hashtable) As Boolean
        Dim valido As Boolean = True
        Dim xmldoc As New XmlDocument
        Dim nodeList As XmlNodeList
        Dim root As XmlNode, node As XmlNode
        xmldoc.Load(ruta)
        If xmldoc.HasChildNodes Then
            nodeList = xmldoc.ChildNodes
            root = nodeList(0)
            If root.Name = "Error" Then
                valido = False
                export(root.Name) = root.InnerText
            End If
        End If
        Return valido
    End Function

    Public Function GetExportValue(ByVal name As String) As String
        Dim result As String = ""
        If Me.Exports.ContainsKey(name) Then
            result = CStr(Me.Exports(name))
        End If
        Return result
    End Function

    Private Sub EscribeLog(ByVal strError As String, ByVal Titulo As String)

        Dim StreamW As New System.IO.StreamWriter(Environment.CurrentDirectory & "\ErrorLogFile.txt", True)

        StreamW.WriteLine(Now.ToString & " --> " & Titulo.ToUpper & vbCrLf)
        StreamW.WriteLine("Detalle --> " & strError)
        StreamW.WriteLine("".PadLeft(250, "-"))

        StreamW.Close()

    End Sub

    Private Sub WriteTime(ByVal NameBapi As String, ByVal Time As String)
        Dim StreamW As New System.IO.StreamWriter(Environment.CurrentDirectory & "\MQTTTime.txt", True)
        StreamW.WriteLine(NameBapi & vbTab & Time)
        StreamW.Close()
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 06/01/2016: Funcion de liberacion de memoria
    '--------------------------------------------------------------------------------------------------------------------------------------
    Public Sub ClearMemory()
        Try
            Dim Mem As Process
            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)
        Catch ex As Exception
            'Control de errores
        End Try

    End Sub

#End Region

End Class