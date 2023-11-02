Imports MSXML2
Imports System.IO
Imports System.Net
Imports System.Text

Public Class WSMATRICES


#Region "Variables"
    Private URL As String
    Private Puerto As String
    Private Method As String
    Private CallMethod As String
    Private request As String
#End Region

#Region "Constructores"

    Public Sub New(ByVal Metodo As String)
        Me.URL = oConfigCierreFI.ServerBrokerNew
        Me.Puerto = oConfigCierreFI.PuertoBrokerNew
        Me.Method = Metodo
        Me.CallMethod = Me.URL & ":" & Me.Puerto & "/" & Me.Method & "?wsdl"
        Me.request = ""
    End Sub

#End Region

#Region "Metodos de Webservices"
    Public Function Valida_Rfc(ByVal rfc As String) As Boolean
        Dim dsResultado As New DataSet
        Dim accept As Boolean = False
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_MATRICES"">"
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:Z_MF_COMMX1008_DUPLIC_CLNT>"
        Me.request &= "<I_STCD1>" & rfc & "</I_STCD1>"
        Me.request &= "<E_MESSAGE></E_MESSAGE>"
        Me.request &= "<E_MSGTY></E_MSGTY>"
        Me.request &= "</ws:Z_MF_COMMX1008_DUPLIC_CLNT>"
        Me.request &= "</soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'No existen los datos del cliente
        If Not dsResultado Is Nothing Then
            If dsResultado.Tables.Contains("Z_MF_COMMX1008_DUPLIC_CLNTResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("Z_MF_COMMX1008_DUPLIC_CLNTResponse")
                Dim row As DataRow = table.Rows(0)
                If (row("E_MESSAGE") = "RFC ya existe, corroborar datos") Then
                    accept = True
                End If
                'Console.WriteLine(row("E_MESSAGE"))
            End If
        End If
        Return accept
    End Function


    Private Function ConsumeXML(ByVal URL As String, ByVal strSoapEnvelope As String) As DataSet
        Dim oRequest As HttpWebRequest
        Dim oStream As Stream
        Dim oResponse As HttpWebResponse
        Dim oReader As StreamReader
        Dim strResponse As String
        Dim dsXML As New DataSet
        Try
            Dim data() As Byte
            'Instanciamos Objeto y seteamos parametros necesarios para consumir correctamente el REST
            oRequest = TryCast(WebRequest.Create(URL), HttpWebRequest)
            oRequest.Timeout = -1
            oRequest.Method = "POST"
            data = UTF8Encoding.UTF8.GetBytes(strSoapEnvelope)
            oRequest.ContentLength = data.Length
            oRequest.ContentType = "text/xml; charset=utf-8"
            oRequest.Accept = "text/xml; charset=utf-8"
            oStream = oRequest.GetRequestStream
            oStream.Write(data, 0, data.Length)
            'Obtenemos Respuesta
            oResponse = TryCast(oRequest.GetResponse(), HttpWebResponse)
            oReader = New StreamReader(oResponse.GetResponseStream())
            strResponse = oReader.ReadToEnd()
            oStream.Close()
            oReader.Close()
            Dim XMLReader As New StringReader(strResponse)
            dsXML.ReadXml(XMLReader)
        Catch web As System.Web.HttpException
            If web.ErrorCode = 404 Then
                Throw New Exception(Convert.ToString("WebService no encontrado") & URL)
            Else
                Throw web
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dsXML
    End Function
#End Region
End Class
