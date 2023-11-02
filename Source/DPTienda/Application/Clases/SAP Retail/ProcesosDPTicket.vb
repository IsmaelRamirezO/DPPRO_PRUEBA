Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports System.Reflection
Imports System.ComponentModel
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Linq.JArray

Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Public Class ProcesosDPTicket

#Region "Declaracion de Variables y Objetos"
    Private URL As String
    Private oRest As ServiciosREST
    Private htParametros As Hashtable
    Private Satelite As String
    Private m_Metodo As String
    Private m_Type As String
    Private SerialID As String
#End Region

#Region "Propiedades"

    Public Property Metodo As String
        Get
            Return m_Metodo
        End Get
        Set(value As String)
            m_Metodo = value
        End Set
    End Property

    Public Property Type As String
        Get
            Return m_Type
        End Get
        Set(value As String)
            m_Type = value
        End Set
    End Property

    Public Property Parametros As Hashtable
        Get
            Return Me.htParametros
        End Get
        Set(value As Hashtable)
            Me.htParametros = value
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New()

        'Inicializamos URL Base
        Me.URL = oConfigCierreFI.ServidorREST & ":" & oConfigCierreFI.PuertoREST
        'Me.URL = strURL

        Me.Satelite = "DPVAIO"

        'Inicializamos Objeto par ael manejo de Servicios REST
        Me.oRest = New ServiciosREST(Me.URL)

        'inicializamos cabecera de Transacciones
        Me.htParametros = New Hashtable

        Me.Metodo = "/pos/tickets"
        Me.Type = "POST" 'Siempre sera POST


    End Sub

#End Region

#Region "Transacciones DPTicket"

    Private Function ExecuteService(Optional ByVal Name As String = "", Optional ByVal oServicio As Object = Nothing) As Dictionary(Of String, Object)

        Dim strJSON As String = ""
        Dim URL_REST As String
        Dim strRespuesta As String
        Dim result As Dictionary(Of String, Object)

        'Definimos URL del Servicio REST
        URL_REST = URL & Me.Metodo

        'Seteamos parametros de cabecera
        Me.htParametros("Satelite") = Me.Satelite
        Me.htParametros("Tipo") = "S"
        'If htParametros.ContainsKey("SerialID") = False Then
        '    htParametros("SerialID") = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
        'End If

        Try
            'Serializamos datos de usuario a JSON
            If Not oServicio Is Nothing Then
                strJSON = CreateObjectPost(Name, oServicio)
            End If

            'Obtenemos respuesta del servicio REST
            strRespuesta = Me.oRest.ConsumeREST(URL_REST, Me.htParametros, strJSON)

            'deserializamos JSON
            result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(strRespuesta)
            If result.ContainsKey("ErrorMessage") Then
                Dim ErrorMessage As New Dictionary(Of String, Object)
                Dim Mensaje As String = String.Empty
                ErrorMessage = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result("ErrorMessage").ToString)

                If ErrorMessage.ContainsKey("Mensaje") Then
                    Mensaje = "Servicio: " & Name & " Codigo: " & CStr(ErrorMessage("Codigo")) & vbCrLf & CStr(ErrorMessage("Mensaje"))
                ElseIf ErrorMessage.ContainsKey("msn") Then
                    Mensaje = "Servicio: " & Name & " " & Date.Now.ToShortDateString & ": " & vbCrLf & CStr(ErrorMessage("msn"))
                End If
                EscribeLog(Mensaje, "Ocurrio un error en S2Credit.")
                'MessageBox.Show("Ocurrio un error en S2Credit:" & vbCrLf & CStr(result("ErrorMessage")("msn")) & _
                '                vbCrLf & "Favor de reportar a Soporte.", "DPVale AIO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'result = Nothing
            End If

        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

        'Devolvemos informacion
        Return result

    End Function

    Private Function ParseToDictionary(ByVal lista As Dictionary(Of String, Dictionary(Of String, JArray))) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim rfc As Dictionary(Of String, JArray)
        Dim format As String
        For Each Str As String In lista.Keys
            rfc = CType(lista(Str), Dictionary(Of String, JArray))
            For Each strRfc As String In rfc.Keys
                format = strRfc.ToUpper()
                If format.StartsWith("SAP") Then
                    Dim lst As List(Of String)
                    Dim array As JArray = rfc(strRfc)
                    result(strRfc) = lst
                Else
                    result(strRfc) = rfc(strRfc)
                End If
            Next
        Next
        Return result
    End Function

#End Region

#Region "Conversion"

    Public Function CreateObjectPost(ByVal rfc As String, ByVal param As Dictionary(Of String, Object)) As String
        Dim conversion As New Dictionary(Of String, Object)
        Dim tablas As New List(Of Dictionary(Of String, Object))
        Dim tables As New Dictionary(Of String, Object)
        Dim parametro As New Dictionary(Of String, Object)
        Dim dicRfc As New Dictionary(Of String, Object)
        For Each row As String In param.Keys
            'If TypeOf param(row) Is List(Of Dictionary(Of String, Object)) Then
            '    tables(row) = param(row)
            'Else
            '    parametro(row) = param(row)
            'End If
            parametro(row) = param(row)
        Next
        'dicRfc("Parametros") = parametro
        'dicRfc("Tablas") = tables
        'conversion(rfc) = dicRfc
        conversion(rfc) = parametro
        Return JsonConvert.SerializeObject(conversion)
    End Function

    Private Function ValidarColumna(ByVal ColumnName As String, ByVal Table As DataTable) As DataTable
        Dim dt As DataTable = Table.Copy
        If Not dt.Columns.Contains(ColumnName) Then
            dt.Columns.Add(ColumnName)
            For Each oRow As DataRow In dt.Rows
                oRow(ColumnName) = ""
            Next
            dt.AcceptChanges()
        End If
        Return dt
    End Function

    Private Function ListToDataTable(ByVal array As JArray, Optional ByVal name As String = "") As DataTable
        Dim dt As New DataTable
        dt = JsonConvert.DeserializeObject(Of DataTable)(array.ToString())
        dt.TableName = name
        Return dt
    End Function

    Private Function DecodificarImagen(ByVal Firma As String) As Image
        '-----------------------------------------------------------------------------------
        ' FLIZARRAGA 08/05/2017: Funcion para decodificar la firma del distribuidor
        '-----------------------------------------------------------------------------------
        ' Preparamos la firma y obtenemos los datos 
        '-----------------------------------------------------------------------------------
        Dim img As System.Drawing.Image
        Dim MS As System.IO.MemoryStream = New System.IO.MemoryStream
        If Not Firma Is String.Empty Then
            Dim b64 As String = Firma.Replace(" ", "+")
            Dim b() As Byte

            '-----------------------------------------------------------------------------------
            ' Convertirmos la codificacion de base64 a imagen
            '-----------------------------------------------------------------------------------
            b = Convert.FromBase64String(b64)
            MS = New System.IO.MemoryStream(b)

            '-----------------------------------------------------------------------------------
            ' Creamos la imagen
            '-----------------------------------------------------------------------------------
            img = System.Drawing.Image.FromStream(MS)
        End If
        Return img
    End Function

    '----------------------------------------------------------------------------------------------------------
    '  FLIZARRAGA 08/05/2017: Quita signos de puntuacion y caracteres especiales
    '----------------------------------------------------------------------------------------------------------
    Private Function QuitarSignos(ByVal texto As String) As String
        Dim consignos As String = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ"
        Dim sinsignos As String = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC"
        For v As Integer = 0 To sinsignos.Length - 1
            Dim i As String = consignos.Substring(v, 1)
            Dim j As String = sinsignos.Substring(v, 1)
            texto = texto.Replace(i, j)
        Next
        Return texto
    End Function

    '----------------------------------------------------------------------------------------------------------
    ' FLIZARRAGA 08/05/2017: Quita nullos retornados por los servicios
    '----------------------------------------------------------------------------------------------------------
    Private Function NoNulls(ByVal Objeto As Object) As String
        Dim Result As String = String.Empty
        If Not Objeto Is Nothing Then
            Result = Objeto.ToString.Replace("[", "").Replace("]", "")
        End If
        Return Result
    End Function

#End Region

#Region "Metodos de servicios de RestService"

    Public Function GetDPTicket(ByVal xml As String) As Dictionary(Of String, Object)
        Dim Servicio As String = "tickets"
        Dim oParams As New Dictionary(Of String, Object)
        oParams("xml") = xml
        '------------------------------------------------------------------
        ' FLIZARRAGA 08/05/2017: Ejecutamos la transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        '  FLIZARRAGA 08/05/2017: Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If
        Dim reply As New Dictionary(Of String, Object)
        If oRespuesta.Count > 0 Then
            reply = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oRespuesta("results").ToString())
        End If
        '------------------------------------------------------------------
        ' FLIZARRAGA 08/05/2017: Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return reply

    End Function

#End Region
End Class
