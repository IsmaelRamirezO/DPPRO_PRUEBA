Imports System.Text
Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Xml
Imports System.Xml.Linq
Imports System.Runtime.Serialization

'-------------------------------------------------------------------------------
'JNAVA (30.11.2015): Clase para el manejo de servicios REST
'-------------------------------------------------------------------------------
Public Class ServiciosREST

#Region "Variables"
    Private URL As String
    Private m_Type As String
#End Region

#Region "Propiedades"
    Public Property Type As String
        Get
            Return m_Type
        End Get
        Set(value As String)
            m_Type = value
        End Set
    End Property
#End Region

#Region "Constructores"

    Public Sub New(ByVal URLBase As String)
        Me.URL = URLBase
        Me.Type = "POST"
    End Sub

#End Region

#Region "Manejo de Servicios REST"

    Public Function ConsumeREST(ByVal Url As String, ByVal Parametros As Hashtable, Optional ByVal JSON As String = "") As String
        Dim ParamConcatenados As String
        Dim UrlParam As String
        Dim oRequest As HttpWebRequest
        Dim oStream As Stream
        Dim oResponse As HttpWebResponse
        Dim oReader As StreamReader
        Dim strResponse As String

        Try

            'Concatenamos los parametros
            ParamConcatenados = ConcatenarParametros(Parametros)
            UrlParam = Url & "?" & ParamConcatenados

            'Codificamos JSON
            Dim data() As Byte

            'Instanciamos Objeto y seteamos parametros necesarios para consumir correctamente el REST
            oRequest = TryCast(WebRequest.Create(UrlParam), HttpWebRequest)
            oRequest.Timeout = -1
            oRequest.Method = Me.Type

            Select Case Me.Type
                Case "POST"
                    data = UTF8Encoding.UTF8.GetBytes(JSON)
                    oRequest.ContentLength = data.Length
                    oRequest.ContentType = "application/json; charset=utf-8"
                    oStream = oRequest.GetRequestStream
                    oStream.Write(data, 0, data.Length)
                Case "PUT"
                    data = UTF8Encoding.UTF8.GetBytes(JSON)
                    oRequest.ContentLength = data.Length
                    oRequest.ContentType = "application/json; charset=utf-8"
                    oStream = oRequest.GetRequestStream
                    oStream.Write(data, 0, data.Length)
                Case "GET"
                    oRequest.ContentType = "application/x-www-form-urlencoded"
                    oStream = oRequest.GetRequestStream  
                Case "DELETE"
                    oRequest.ContentType = "application/x-www-form-urlencoded"
                    oStream = oRequest.GetRequestStream
            End Select

            'Obtenemos Respuesta
            oResponse = TryCast(oRequest.GetResponse(), HttpWebResponse)
            oReader = New StreamReader(oResponse.GetResponseStream())
            strResponse = oReader.ReadToEnd()
            oStream.Close()
            oReader.Close()
            Return strResponse
        Catch ex As System.Web.HttpException
            If ex.ErrorCode = 404 Then
                Throw New Exception(Convert.ToString("Not found remote service ") & Url)
            Else
                Throw ex
            End If
        End Try
    End Function

    Private Function ConcatenarParametros(ByVal Parametros As Hashtable) As String

        Dim strReturn As String = String.Empty
        Dim PrimerParam As Boolean = True
        Dim ParamConcatenados As StringBuilder = Nothing

        If Not Parametros Is Nothing Then

            'Contruimos el objeto para concatenar los parametros (Nombre y Valor)
            ParamConcatenados = New StringBuilder()

            Dim ParamValue As String
            For Each NombreParam As String In Parametros.Keys

                'Obtenemos el valor del parametro
                ParamValue = String.Empty
                ParamValue = Parametros(NombreParam).ToString

                'Si  no es el primer parametro agregamos el signo & necesario para el REST
                If Not PrimerParam Then ParamConcatenados.Append("&")

                'Concatenamos
                ParamConcatenados.Append(NombreParam & "=" & HttpUtility.UrlEncode(ParamValue))
                PrimerParam = False

            Next

        End If

        'Obtenemos los parametros concatenados
        If Not ParamConcatenados Is Nothing Then strReturn = ParamConcatenados.ToString

        Return strReturn

    End Function

    Public Function SerializarJSON(ByVal Objeto As Object) As String
        Dim strReturn As String = ""
        Dim Serializador As New Json.DataContractJsonSerializer(Objeto.GetType)
        Dim ms As New System.IO.MemoryStream

        'Serializamos
        Serializador.WriteObject(ms, Objeto)

        'Convertimos el JSON a String
        strReturn = System.Text.Encoding.UTF8.GetString(ms.ToArray)

        Return strReturn

    End Function

    'Public Function DeserializarJSON(ByVal Objeto As Object, ByVal strJSON As String) As Object
    'Dim dsReturn As DataSet
    'Dim XML As XElement
    'Dim XMLReader As StringReader
    'Dim dsXML As DataSet

    ''Preparamos datos de respuesta
    'Using Reader As XmlDictionaryReader = Json.JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(strJSON), XmlDictionaryReaderQuotas.Max)

    '    'Convertimos a XML
    '    Xml = XElement.Load(Reader)
    '    XmlReader = New StringReader(Xml.ToString())

    '    ''Mostramos el XML con formato
    '    EscribeLog(PrettyXML(Xml.ToString()), "XML de Response Venta en SAP Retail")
    '    'TextBox2.Text = PrettyXML(XML.ToString())

    '    'Creamos el DataSet con los datos del XML
    '    dsXML = New DataSet
    '    dsXML.ReadXml(XmlReader)
    '    dsReturn = dsXML
    'End Using
    'Return dsReturn

    'End Function

    Public Function DeserializarJSON(ByVal Objeto As Object, ByVal strJSON As String) As Object
        'Dim obj As Object = Activator.CreateInstance(Of Object)()
        Dim ms As New MemoryStream(Encoding.Unicode.GetBytes(strJSON))
        Dim serializer As New System.Runtime.Serialization.Json.DataContractJsonSerializer(Objeto.GetType)
        Objeto = DirectCast(serializer.ReadObject(ms), Object)
        ms.Close()
        ms.Dispose()
        Return Objeto
    End Function

    Private Function PrettyXML(XMLString As String) As String
        Dim sWriter As New StringWriter()
        Dim xmlWriter As New XmlTextWriter(sWriter)
        xmlWriter.Formatting = Formatting.Indented
        xmlWriter.Indentation = 4
        Dim xmlDoc As New XmlDocument
        xmlDoc.LoadXml(XMLString)
        xmlDoc.Save(xmlWriter)
        Return sWriter.ToString()
    End Function

#End Region

End Class





