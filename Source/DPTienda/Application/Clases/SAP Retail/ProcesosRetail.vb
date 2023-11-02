Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports System.Reflection

Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.ComponentModel
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Linq.JArray

Imports System.Threading

Imports System.Web.Mail
Imports System.Web.Util
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

'-------------------------------------------------------------------------------
'JNAVA (11.12.2015): Clase para el manejo de los Procesos de RETAIL
'-------------------------------------------------------------------------------
Public Class ProcesosRetail

#Region "Declaracion de Variables y Objetos"
    Private URL As String
    Private oRest As ServiciosREST
    Private htParametros As Hashtable
    Private Satelite As String
    Private m_Metodo As String
    Private m_Type As String

    '------------------------------------------------------------------------------------
    ' JNAVA (08.06.2016): Contador para saber si mandamos o no el correo de timeout
    '------------------------------------------------------------------------------------
    Private NombreTransaccion As String = String.Empty
    Private oThreadTimer As New Thread(AddressOf ThreadContar)
    Private bolDetenerTimer As Boolean = False
    Private ContadorTimer As Integer = 0

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

    'Public Sub New()

    '    'Inicializamos URL Base
    '    Me.URL = oConfigCierreFI.ServidorREST & ":" & oConfigCierreFI.PuertoREST
    '    'Me.URL = strURL

    '    Me.Satelite = "DPPRO"

    '    'Inicializamos Objeto par ael manejo de Servicios REST
    '    Me.oRest = New ServiciosREST(Me.URL)

    '    'inicializamos cabecera de Transacciones
    '    Me.htParametros = New Hashtable

    '    Me.Metodo = "/pos/ventas"
    '    Me.Type = "POST"

    'End Sub

    Public Sub New(ByVal metodo As String, ByVal type As String)

        'Inicializamos URL Base
        Me.URL = oConfigCierreFI.ServidorREST & ":" & oConfigCierreFI.PuertoREST
        'Me.URL = strURL

        Me.Satelite = "DPPRO"

        'Inicializamos Objeto par ael manejo de Servicios REST
        Me.oRest = New ServiciosREST(Me.URL)

        'inicializamos cabecera de Transacciones
        Me.htParametros = New Hashtable

        Me.Metodo = metodo
        Me.Type = type

    End Sub

#End Region

#Region "Transacciones SAP Retail"

    ' Ejecuta la transaccion en base al JSON que se envia
    'Public Function EjecutarServicio(ByVal oServicio As Object, ByVal oRespuesta As Object) As Object

    '    Dim strMetodo As String = "/pos/ventas"
    '    Dim strJSON As String
    '    Dim URL_REST As String
    '    Dim strRespuesta As String


    '    'Definimos URL del Servicio REST
    '    URL_REST = URL & Me.Metodo

    '    'Seteamos parametros de cabecera
    '    Me.htParametros.Add("fecha", Date.Today.Year & "-" & Date.Today.Month & "-" & Date.Today.Day)
    '    Me.htParametros.Add("hora", Now.Hour & ":" & Now.Minute & ":" & Now.Second)
    '    Me.htParametros.Add("satelite", Me.Satelite)

    '    'Serializamos datos de usuario a JSON
    '    If Not oServicio Is Nothing Then
    '        strJSON = Me.oRest.SerializarJSON(oServicio)
    '    End If

    '    'Obtenemos respuesta del servicio REST
    '    strRespuesta = Me.oRest.ConsumeREST(URL_REST, Me.htParametros, strJSON)

    '    'deserializamos JSON
    '    oRespuesta = Me.oRest.DeserializarJSON(oRespuesta, strRespuesta)

    '    'Devolvemos informacion
    '    Return oRespuesta

    'End Function

    Public Function ExecuteService(Optional ByVal Name As String = "", Optional ByVal oServicio As Object = Nothing) As Dictionary(Of String, Object)

        'Dim strMetodo As String = "/pos/ventas"
        Dim strJSON As String = ""
        Dim URL_REST As String
        Dim strRespuesta As String
        Dim result As Dictionary(Of String, Object)
        Dim resultado As Dictionary(Of String, Dictionary(Of String, JArray))

        '--------------------------------------------------------------------------------------------------
        ' JNAVA (08.06.2016): Obtenemos el Nombre de la transaccion para enviar correo de timeout.
        '--------------------------------------------------------------------------------------------------
        NombreTransaccion = Name
        '--------------------------------------------------------------------------------------------------

        'Definimos URL del Servicio REST
        URL_REST = URL & Me.Metodo

        'Seteamos parametros de cabecera
        'Me.htParametros.Add("fecha", Date.Today.Year & "-" & Date.Today.Month & "-" & Date.Today.Day)
        'Me.htParametros.Add("hora", Now.Hour & ":" & Now.Minute & ":" & Now.Second)
        Me.htParametros("Satelite") = Me.Satelite
        Me.htParametros("Tipo") = "S"
        'If htParametros.ContainsKey("SerialID") = False Then
        '    htParametros("SerialID") = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
        'End If

        '------------------------------------------------------------------------------
        'JNAVA (03.06.2016): PArametro Inicia Transaccion DPPRO BUS
        '------------------------------------------------------------------------------
        Dim FechaInicio As DateTime
        Dim FechaFin As DateTime
        Dim Intervalo As Long
        '-----------------------------------------------------------------------------

        Try
            'Serializamos datos de usuario a JSON
            If Not oServicio Is Nothing Then
                strJSON = CreateObjectPost(Name, oServicio)
            End If
            'strJSON = Me.oRest.SerializarJSON(oServicio)

            '------------------------------------------------------------------------------
            ' JNAVA (03.06.2016): Setemos inicio de Transaccion DPPRO con BUS
            '------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarLogTransacciones Then
                FechaInicio = Date.Now
                EscribeLogTransacciones(True, FechaInicio, Name, Me.htParametros("SerialID"))
            End If
            '------------------------------------------------------------------------------

            '------------------------------------------------------------------------------------
            ' JNAVA (08.06.2016): Contador para saber si mandamos o no el correo de timeout
            '------------------------------------------------------------------------------------
            If oConfigCierreFI.EnviarCorreoLentitud Then
                Me.oThreadTimer.Start()
            End If
            '------------------------------------------------------------------------------------

            'Obtenemos respuesta del servicio REST
            strRespuesta = Me.oRest.ConsumeREST(URL_REST, Me.htParametros, strJSON)
            'MsgBox("JSON: " & Name & ": " & strRespuesta, MsgBoxStyle.OkCancel, "Json de Respuesta")
            'EscribeLog("JSON: " & strRespuesta, "Json")
            '------------------------------------------------------------------------------
            ' JNAVA (03.06.2016): Finaliza Transaccion y escribe Log BUS DPPRO
            '------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarLogTransacciones Then
                FechaFin = Date.Now
                Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                EscribeLogTransacciones(False, FechaFin, Name, Me.htParametros("SerialID"), "Transacción finalizada sin errores.", Intervalo)
            End If
            '------------------------------------------------------------------------------

            'deserializamos JSON
            result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(strRespuesta)
        Catch ex As Exception

            '------------------------------------------------------------------------------
            'JNAVA (03.06.2016): Finaliza Transaccion BUS DPPRO con error y escribe log
            '------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarLogTransacciones Then
                FechaFin = Date.Now
                Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                EscribeLogTransacciones(False, FechaFin, Name, Me.htParametros("SerialID"), ex.Message, Intervalo)
            End If
            '------------------------------------------------------------------------------
            Dim errors() As String = ex.Message.Split(New Char() {"|"}, StringSplitOptions.RemoveEmptyEntries)
            If errors.Length > 0 Then
                MessageBox.Show(errors(0), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If IsNumeric(errors(1)) AndAlso CInt(errors(1)) = 504 Then
                    Throw New ApplicationException(errors(1))
                End If
            End If
            'Throw New ApplicationException(ex.Message, ex)

        Finally
            '------------------------------------------------------------------------------------
            ' JNAVA (08.06.2016): Contador para saber si mandamos o no el correo de timeout
            '------------------------------------------------------------------------------------
            If oConfigCierreFI.EnviarCorreoLentitud Then
                Me.NombreTransaccion = String.Empty
                Me.bolDetenerTimer = True
            End If
            '------------------------------------------------------------------------------------
        End Try
        If result.ContainsKey("ErrorMessage") Then
            EscribeLog(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), CStr(result("ErrorMessage")("SerialID")) & CStr(result("ErrorMessage")("Codigo")) & " " & CStr(result("ErrorMessage")("Fecha")))
            'MessageBox.Show(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New ApplicationException(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")))
        End If
        'Devolvemos informacion
        Return result

    End Function


    Public Function CreaObjeto(ByVal param As Dictionary(Of String, Object)) As String
        Dim conversion As New Dictionary(Of String, Object)
        Dim parametro As New Dictionary(Of String, Object)
        For Each row As String In param.Keys
            parametro(row) = param(row)
        Next
        Return JsonConvert.SerializeObject(parametro)
    End Function

    Public Function ExecuteSAPService(ByVal Name As String, Optional ByVal oServicio As Object = Nothing) As Dictionary(Of String, Object)
        Dim strJSON As String = ""
        Dim URL_REST As String
        Dim strRespuesta As String
        Dim result As Dictionary(Of String, Object)
        Dim resultado As Dictionary(Of String, Dictionary(Of String, JArray))

        '--------------------------------------------------------------------------------------------------
        ' JNAVA (08.06.2016): Obtenemos el Nombre de la transaccion para enviar correo de timeout.
        '--------------------------------------------------------------------------------------------------
        NombreTransaccion = Name
        '--------------------------------------------------------------------------------------------------

        'Definimos URL del Servicio REST
        URL_REST = URL & Me.Metodo & "/" & Name


        '------------------------------------------------------------------------------
        'JNAVA (03.06.2016): PArametro Inicia Transaccion DPPRO BUS
        '------------------------------------------------------------------------------
        Dim FechaInicio As DateTime
        Dim FechaFin As DateTime
        Dim Intervalo As Long
        '-----------------------------------------------------------------------------

        Try
            'Serializamos datos de usuario a JSON
            If Not oServicio Is Nothing Then
                strJSON = CreaObjeto(oServicio)
            End If
            'strJSON = Me.oRest.SerializarJSON(oServicio)

            '------------------------------------------------------------------------------
            ' JNAVA (03.06.2016): Setemos inicio de Transaccion DPPRO con BUS
            '------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarLogTransacciones Then
                FechaInicio = Date.Now
                EscribeLogTransacciones(True, FechaInicio, Name, Me.htParametros("SerialID"))
            End If
            '------------------------------------------------------------------------------

            '------------------------------------------------------------------------------------
            ' JNAVA (08.06.2016): Contador para saber si mandamos o no el correo de timeout
            '------------------------------------------------------------------------------------
            If oConfigCierreFI.EnviarCorreoLentitud Then
                Me.oThreadTimer.Start()
            End If
            '------------------------------------------------------------------------------------

            'Obtenemos respuesta del servicio REST
            strRespuesta = Me.oRest.ConsumeREST(URL_REST, Me.htParametros, strJSON)
            'MsgBox("JSON: " & Name & ": " & strRespuesta, MsgBoxStyle.OkCancel, "Json de Respuesta")
            'EscribeLog("JSON: " & strRespuesta, "Json")
            '------------------------------------------------------------------------------
            ' JNAVA (03.06.2016): Finaliza Transaccion y escribe Log BUS DPPRO
            '------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarLogTransacciones Then
                FechaFin = Date.Now
                Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                EscribeLogTransacciones(False, FechaFin, Name, Me.htParametros("SerialID"), "Transacción finalizada sin errores.", Intervalo)
            End If
            '------------------------------------------------------------------------------

            'deserializamos JSON
            result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(strRespuesta)
        Catch ex As Exception

            '------------------------------------------------------------------------------
            'JNAVA (03.06.2016): Finaliza Transaccion BUS DPPRO con error y escribe log
            '------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarLogTransacciones Then
                FechaFin = Date.Now
                Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                EscribeLogTransacciones(False, FechaFin, Name, Me.htParametros("SerialID"), ex.Message, Intervalo)
            End If
            '------------------------------------------------------------------------------
            Dim errors() As String = ex.Message.Split(New Char() {"|"}, StringSplitOptions.RemoveEmptyEntries)
            If errors.Length > 0 Then
                MessageBox.Show(errors(0), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If IsNumeric(errors(1)) AndAlso CInt(errors(1)) = 504 Then
                    Throw New ApplicationException(errors(1))
                End If
            End If
            'Throw New ApplicationException(ex.Message, ex)

        Finally
            '------------------------------------------------------------------------------------
            ' JNAVA (08.06.2016): Contador para saber si mandamos o no el correo de timeout
            '------------------------------------------------------------------------------------
            If oConfigCierreFI.EnviarCorreoLentitud Then
                Me.NombreTransaccion = String.Empty
                Me.bolDetenerTimer = True
            End If
            '------------------------------------------------------------------------------------
        End Try
        If result.ContainsKey("ErrorMessage") Then
            EscribeLog(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), CStr(result("ErrorMessage")("SerialID")) & CStr(result("ErrorMessage")("Codigo")) & " " & CStr(result("ErrorMessage")("Fecha")))
            'MessageBox.Show(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New ApplicationException(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")))
        End If
        'Devolvemos informacion
        Return result

    End Function


    Public Function ExecuteService2(ByVal htParams As Hashtable) As String    'Dictionary(Of String, Object)
        Dim strJSON As String = ""
        Dim URL_REST As String
        Dim strRespuesta As String
        Dim result As Dictionary(Of String, Object)
        Dim oSapMgr As ProcesoSAPManager
        Dim strMessage As String = String.Empty
        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        URL = oSapMgr.SAPApplicationConfig.ServerCAR & ":" & oSapMgr.SAPApplicationConfig.PuertoCAR

        'Definimos URL del Servicio REST
        URL_REST = URL & Me.Metodo

        Try

            'Obtenemos respuesta del servicio REST
            strRespuesta = Me.oRest.ConsumeRESTCAR(URL_REST, htParams, "GET", oSapMgr.SAPApplicationConfig.UserCAR, oSapMgr.SAPApplicationConfig.PwdCAR, strMessage)


            'deserializamos JSON'
            'If strRespuesta.Length > 0 Then
            '    result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(strRespuesta)
            'End If

        Catch ex As Exception
            Dim errors() As String = ex.Message.Split(New Char() {"|"}, StringSplitOptions.RemoveEmptyEntries)

            If strMessage.IndexOf("400") > 0 Then
                MessageBox.Show("No se encontró información para el o los productos seleccionados", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If errors.Length > 0 Then
                    MessageBox.Show(errors(0), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Try
        If Not result Is Nothing Then
            If result.ContainsKey("ErrorMessage") Then
                EscribeLog(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), CStr(result("ErrorMessage")("SerialID")) & CStr(result("ErrorMessage")("Codigo")) & " " & CStr(result("ErrorMessage")("Fecha")))
                'MessageBox.Show(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Throw New ApplicationException(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")))
            End If
            'Devolvemos informacion
        End If
        Return strRespuesta

    End Function


    Public Function SapZFmProducAclaracion(ByVal dtParametros As Dictionary(Of String, Object)) As DataTable
        Dim result As New Dictionary(Of String, Object)
        Dim dtReturn As DataTable

        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteSAPService("SapZFmProducAclaracion", dtParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            Exit Function
        End If

        If oRespuesta.ContainsKey("SapPeMatreserv") Then
            dtReturn = ListToDataTable(oRespuesta("SapPeMatreserv"))

        End If

        Return dtReturn

    End Function


    Public Function SapZFmCommx008DescargaUnica(ByVal dtParametros As Dictionary(Of String, Object)) As DataTable
        Dim result As New Dictionary(Of String, Object)
        Dim dtReturn As DataTable

        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteSAPService("SapZFmCommx008DescargaUnica", dtParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            Exit Function
        End If

        If oRespuesta.ContainsKey("SapPtDescargaOut") Then
            dtReturn = ListToDataTable(oRespuesta("SapPtDescargaOut"))
        End If

        Return dtReturn

    End Function




    Public Function ExecuteExternalService(ByVal Name As String, Optional ByVal oServicio As Object = Nothing) As Dictionary(Of String, Object)
        Dim strJSON As String = ""
        Dim URL_REST As String
        Dim strRespuesta As String
        Dim result As Dictionary(Of String, Object)
        Dim resultado As Dictionary(Of String, Dictionary(Of String, JArray))

        '--------------------------------------------------------------------------------------------------
        ' JNAVA (08.06.2016): Obtenemos el Nombre de la transaccion para enviar correo de timeout.
        '--------------------------------------------------------------------------------------------------
        NombreTransaccion = Name
        '--------------------------------------------------------------------------------------------------

        'Definimos URL del Servicio REST
        URL_REST = Me.Metodo & "/" & Name


        '------------------------------------------------------------------------------
        'JNAVA (03.06.2016): PArametro Inicia Transaccion DPPRO BUS
        '------------------------------------------------------------------------------
        Dim FechaInicio As DateTime
        Dim FechaFin As DateTime
        Dim Intervalo As Long
        '-----------------------------------------------------------------------------

        Try
            'Serializamos datos de usuario a JSON
            If Not oServicio Is Nothing Then
                strJSON = CreaObjeto(oServicio)
            End If
            'strJSON = Me.oRest.SerializarJSON(oServicio)

            '------------------------------------------------------------------------------
            ' JNAVA (03.06.2016): Setemos inicio de Transaccion DPPRO con BUS
            '------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarLogTransacciones Then
                FechaInicio = Date.Now
                EscribeLogTransacciones(True, FechaInicio, Name, Me.htParametros("SerialID"))
            End If
            '------------------------------------------------------------------------------

            '------------------------------------------------------------------------------------
            ' JNAVA (08.06.2016): Contador para saber si mandamos o no el correo de timeout
            '------------------------------------------------------------------------------------
            If oConfigCierreFI.EnviarCorreoLentitud Then
                Me.oThreadTimer.Start()
            End If
            '------------------------------------------------------------------------------------

            'Obtenemos respuesta del servicio REST
            strRespuesta = Me.oRest.ConsumeREST(URL_REST, Me.htParametros, strJSON)
            'MsgBox("JSON: " & Name & ": " & strRespuesta, MsgBoxStyle.OkCancel, "Json de Respuesta")
            'EscribeLog("JSON: " & strRespuesta, "Json")
            '------------------------------------------------------------------------------
            ' JNAVA (03.06.2016): Finaliza Transaccion y escribe Log BUS DPPRO
            '------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarLogTransacciones Then
                FechaFin = Date.Now
                Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                EscribeLogTransacciones(False, FechaFin, Name, Me.htParametros("SerialID"), "Transacción finalizada sin errores.", Intervalo)
            End If
            '------------------------------------------------------------------------------

            'deserializamos JSON
            result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(strRespuesta)
        Catch ex As Exception

            '------------------------------------------------------------------------------
            'JNAVA (03.06.2016): Finaliza Transaccion BUS DPPRO con error y escribe log
            '------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarLogTransacciones Then
                FechaFin = Date.Now
                Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                EscribeLogTransacciones(False, FechaFin, Name, Me.htParametros("SerialID"), ex.Message, Intervalo)
            End If
            '------------------------------------------------------------------------------
            Dim errors() As String = ex.Message.Split(New Char() {"|"}, StringSplitOptions.RemoveEmptyEntries)
            If errors.Length > 0 Then
                MessageBox.Show(errors(0), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If IsNumeric(errors(1)) AndAlso CInt(errors(1)) = 504 Then
                    Throw New ApplicationException(errors(1))
                End If
            End If
            'Throw New ApplicationException(ex.Message, ex)

        Finally
            '------------------------------------------------------------------------------------
            ' JNAVA (08.06.2016): Contador para saber si mandamos o no el correo de timeout
            '------------------------------------------------------------------------------------
            If oConfigCierreFI.EnviarCorreoLentitud Then
                Me.NombreTransaccion = String.Empty
                Me.bolDetenerTimer = True
            End If
            '------------------------------------------------------------------------------------
        End Try
        If result.ContainsKey("ErrorMessage") Then
            EscribeLog(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), CStr(result("ErrorMessage")("SerialID")) & CStr(result("ErrorMessage")("Codigo")) & " " & CStr(result("ErrorMessage")("Fecha")))
            'MessageBox.Show(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New ApplicationException(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")))
        End If
        'Devolvemos informacion
        Return result

    End Function


    Public Function GetJSONTable(json As JObject) As DataTable
        ' Dim json As JObject = JObject.Parse(strJson)
        Dim trgArray = New JArray()

        For Each row As Newtonsoft.Json.Linq.JToken In json("results")

            Dim cleanRow = New JObject()
            For Each column As JProperty In row

                If TypeOf column.Value Is JValue Then
                    cleanRow.Add(column.Name, column.Value)
                End If
            Next
            trgArray.Add(cleanRow)
        Next
        Return JsonConvert.DeserializeObject(Of DataTable)(trgArray.ToString())

    End Function



    Public Function ExecuteService(ByVal htParams As Hashtable, Optional message As Boolean = True) As Dictionary(Of String, Object)
        Dim strJSON As String = ""
        Dim URL_REST As String
        Dim strRespuesta As String
        Dim result As Dictionary(Of String, Object)
        Dim oSapMgr As ProcesoSAPManager
        Dim strMessage As String = String.Empty
        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        URL = oSapMgr.SAPApplicationConfig.ServerCAR & ":" & oSapMgr.SAPApplicationConfig.PuertoCAR

        'Definimos URL del Servicio REST
        URL_REST = URL & Me.Metodo

        Try

            'Obtenemos respuesta del servicio REST
            strRespuesta = Me.oRest.ConsumeRESTCAR(URL_REST, htParams, "GET", oSapMgr.SAPApplicationConfig.UserCAR, oSapMgr.SAPApplicationConfig.PwdCAR, strMessage)

            'deserializamos JSON'
            If strRespuesta.Length > 0 Then
                result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(strRespuesta)
            End If

        Catch ex As Exception
            Dim errors() As String = ex.Message.Split(New Char() {"|"}, StringSplitOptions.RemoveEmptyEntries)

            If message Then
                If strMessage.IndexOf("400") > 0 Then
                    MessageBox.Show("El servicio de CAR no detecto existencias para el o productos seleccionados", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If errors.Length > 0 Then
                        MessageBox.Show(errors(0), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                EscribeLog(errors(0), "El servicio de CAR no detecto existencias para el o productos seleccionados")
            End If
        End Try
        If Not result Is Nothing Then
            If result.ContainsKey("ErrorMessage") Then
                EscribeLog(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), CStr(result("ErrorMessage")("SerialID")) & CStr(result("ErrorMessage")("Codigo")) & " " & CStr(result("ErrorMessage")("Fecha")))
                'MessageBox.Show(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Throw New ApplicationException(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")))
            End If
            'Devolvemos informacion
        End If
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


                    'Dim cadena As String = CStr(rfc(strRfc))
                    'lst = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(rfc(strRfc))
                    result(strRfc) = lst
                Else
                    result(strRfc) = rfc(strRfc)
                End If
            Next
        Next
        Return result
    End Function

#End Region


#Region "Cancelación de Factura"

    Public Function SapZbapisd29Cancelacion(ByVal factura As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim name As String = ""
        Dim valores As New Dictionary(Of String, Object)
        Parametros("FacturaID") = CStr(factura("FacturaID"))
        Parametros("FolioSAP") = CStr(factura("FolioSAP"))
        Parametros("CodVendedor") = CStr(factura("CodVendedor"))
        Parametros("CodAlmacen") = CStr(factura("CodAlmacen"))
        Parametros("Fidocument") = CStr(factura("Fidocument"))
        Parametros("SalesDocument") = CStr(factura("SalesDocument"))
        If oAppSAPConfig.DPValeSAP AndAlso CStr(factura("Fidocument")) = "" AndAlso CStr(factura("SalesDocument")) = "" Then
            valores("CLASEPEDIDO") = "Z" & Mid(oAppContext.ApplicationConfiguration.Almacen, 2, 2)
            valores("I_FACTURA") = CStr(factura("FolioSAP"))
            valores("I_MODE") = "N"
            valores("I_AGENTE") = CStr(factura("CodVendedor"))
            valores("I_WERKS") = IIf(CStr(factura("CodAlmacen")) = "053", "T053", "T" & CStr(factura("CodAlmacen")))
            name = "ZBAPI_D29_CANCELACION_DPVL"
        Else
            valores("CLASEPEDIDO") = "Z" & Mid(oAppContext.ApplicationConfiguration.Almacen, 2, 2) & "2"
            valores("I_FACTURA") = CStr(factura("FolioSAP"))
            valores("I_MODE") = "N"
            valores("I_AGENTE") = CStr(factura("CodVendedor"))
            name = "ZBAPIS_D29_CANCELACION_FACT_AUTO"
        End If
        result = ExecuteService(name, valores)
        If CStr(result("FIDOCUMENT")) = "" OrElse CStr(result("SALESDOCUMENT")) = "" OrElse CStr(result("FIDOCUMENT")) = "0" OrElse CStr(result("SALESDOCUMENT")) = "0" Then
            If oAppSAPConfig.DPValeSAP AndAlso oConfigCierreFI.MiniPrinter = True Then
                Dim strError As String = ""
                For Each msg As String In result("SapReturn")
                    strError &= Microsoft.VisualBasic.vbCrLf & msg
                Next
                MsgBox(strError, MsgBoxStyle.Information, "Error")
            End If
        End If
        Return result
    End Function

    Public Function SapZbapisd29Cancelacion(ByVal FacturaID As Integer, ByVal FolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, _
                                          ByVal dpvale As Boolean, Optional ByVal strFIDOCUMENT As String = "", Optional ByRef strSALESDOCUMENT As String = "", _
                                         Optional ByVal FolioFISAP As String = "") As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        Dim name As String
        Try
            If oAppSAPConfig.DPValeSAP AndAlso dpvale Then
                params("CLASEPEDIDO") = "ZDEV"
                params("I_FACTURA") = FolioSAP
                params("I_AGENTE") = CodVendedor
                params("I_MODE") = "N"
                params("I_WERKS") = IIf(CodAlmacen = "053", "T053", "T" & CodAlmacen)
                Me.Metodo = "/pos/facturacion"
                If FolioFISAP <> "" Then
                    params("I_FACT_SH") = FolioFISAP
                End If
                name = "ZBAPISD29_CANCELACION_DPVL_AUT"
                result = ExecuteService(name, params)
                strSALESDOCUMENT = CStr(result("SapZbapisd29CancelacionDpvlAut")("SALESDOCUMENT"))
            Else
                params("CLASEPEDIDO") = "ZDEV"
                params("I_FACTURA") = FolioSAP
                params("I_MODE") = "N"
                params("I_AGENTE") = CodVendedor
                If FolioFISAP <> "" Then
                    params("I_FACT_SH") = FolioFISAP
                End If
                name = "ZBAPISD29_CANCELACIONFACT_AUTO"
                Me.Metodo = "/pos/facturacion"
                result = ExecuteService(name, params)
                strSALESDOCUMENT = result("SapZbapisd29CancelacionfactAuto")("SALESDOCUMENT")
            End If

        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return result
    End Function

    Public Function SapZbapisd29Cancelacion(ByVal FolioSAP As String, ByVal CodVendedor As String, FolioFISAP As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        Dim name As String
        Try
            params("CLASEPEDIDO") = "ZDEV"
            params("I_FACTURA") = FolioSAP
            params("I_AGENTE") = CodVendedor
            params("I_MODE") = "N"
            params("I_WERKS") = "T" & oAppContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0")

            Me.Metodo = "/pos/facturacion"

            If FolioFISAP <> "" Then
                params("I_FACT_SH") = FolioFISAP
            End If
            name = "ZBAPISD29_CANCELACION_DPVL_AUT"
            result = ExecuteService(name, params)
            Dim res As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result("SapZbapisd29CancelacionDpvlAut").ToString())
            If res.ContainsKey("SALESDOCUMENT") Then
                result("SALESDOCUMENT") = CStr(res("SALESDOCUMENT"))
            Else
                result("SALESDOCUMENT") = ""
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return result
    End Function

    Public Function SapZsdCancelarPedido(ByVal e_mensaje As String, ByVal e_proceso As String, ByVal lstVales As List(Of Dictionary(Of String, Object))) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        params("E_MENSAJE") = e_mensaje
        params("E_PROCESO") = e_proceso
        params("T_PEDIDOS") = lstVales
        result = ExecuteService("ZSD_CANCELAR_PEDIDO", params)
        Return result
    End Function

    Public Function SapZsdValidaPedidos(ByVal FechaCierre As DateTime) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        params("I_VKBUR") = "T" & oAppContext.ApplicationConfiguration.Almacen
        params("I_ERDAT") = FechaCierre.ToString("yyyyMMdd")
        result = ExecuteService("ZSD_VALIDA_PEDIDOS", params)
        Return result
    End Function

#End Region

#Region "Conversion"

    Public Function CreateObjectPost(ByVal rfc As String, ByVal param As Dictionary(Of String, Object)) As String
        Dim conversion As New Dictionary(Of String, Object)
        Dim tablas As New List(Of Dictionary(Of String, Object))
        Dim tables As New Dictionary(Of String, Object)
        'Dim tableArray As New List(Of Dictionary(Of String, Object))
        Dim parametro As New Dictionary(Of String, Object)
        Dim dicRfc As New Dictionary(Of String, Object)
        rfc = FormatNameTabla(rfc)
        For Each row As String In param.Keys
            If TypeOf param(row) Is List(Of Dictionary(Of String, Object)) Then
                'Dim name As New Dictionary(Of String, Object)
                'name(FormatNameTabla(row)) = param(row)
                'tablas.Add(name)
                tables(FormatNameTabla(row)) = param(row)
            Else
                parametro(row) = param(row)
            End If
        Next
        dicRfc("Parametros") = parametro
        dicRfc("Tablas") = tables
        conversion(rfc) = dicRfc
        'conversion("Tablas") = tablas
        Return JsonConvert.SerializeObject(conversion)
    End Function



    Private Function FormatNameTabla(ByVal name As String) As String
        Dim value As String
        name = name.ToLower()
        Dim splits() As String = Split(name, "_")
        value = "Sap"
        For Each Str As String In splits
            value &= Str.Substring(0, 1).ToUpper() & Str.Substring(1, Str.Length - 1)
        Next
        Return value
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


    'Public Function ListToDataTable(Of T)(ByVal data As IList(Of T)) As DataTable
    '    Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
    '    Dim table As New DataTable()
    '    For Each prop As PropertyDescriptor In properties
    '        table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
    '    Next
    '    For Each item As T In data
    '        Dim row As DataRow = table.NewRow()
    '        For Each prop As PropertyDescriptor In properties
    '            row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
    '        Next
    '        table.Rows.Add(row)
    '    Next
    '    Return table

    'End Function

    Public Function ListToDataTable(ByVal array As JArray, Optional ByVal name As String = "") As DataTable
        Dim dt As New DataTable
        dt = JsonConvert.DeserializeObject(Of DataTable)(array.ToString())
        dt.TableName = name
        Return dt
    End Function

#End Region

#Region "Si Hay"
    Public Function SapZshReembolso(ByVal datos As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        result = ExecuteService("ZSH_REEMBOLSO", datos)
        Return result
    End Function

    Public Function SapZshReembolso(ByVal FolioPedido As String, ByVal Cliente As String, ByVal Almacen As String, ByVal ImporteValeCaja As Decimal, _
                                  ByVal ImporteEfectivo As Decimal, ByVal Division As String, ByVal Tipo As String, ByVal strCentro As String, _
                                  Optional ByVal ActualizarSiHay As String = "", Optional ByRef FolioSapFactura As String = "", _
                                  Optional ByVal decDPVale As Decimal = Decimal.Zero, Optional ByVal bRevale As Boolean = False) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        Dim numref As New NumeroReferencia.cNumReferencia
        Dim strNumRef As String = numref.getNumReferencia(oAppContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(Now.Date.Date, "ddMMyyyy")))
        Try
            params("I_TIPO") = Tipo
            params("I_PEDIDO") = FolioPedido
            params("I_FACTURA") = FolioSapFactura.Trim().PadLeft(10, "0")
            params("I_CENTRO") = strCentro
            params("I_KUNNR") = Cliente
            params("I_IMPORTE_EFECTIVO") = ImporteEfectivo.ToString("##,##0.00").Replace(",", "")
            params("I_IMPORTE_VALECJA") = ImporteValeCaja.ToString("##,##0.00").Replace(",", "")
            params("I_IMPORTE_DPVL") = decDPVale.ToString("##,##0.00").Replace(",", "")
            params("I_REVALE") = IIf(bRevale, "X", "")
            'params("I_GSBER") = Division
            params("I_TIENDA") = "T" & Almacen
            params("I_REFERENCIA") = strNumRef
            params("I_MODO") = "N"
            params("I_ACTUALIZASH") = ActualizarSiHay
            result = ExecuteService("ZSH_REEMBOLSO", params)
            result("MENSAJE") = ""
            If result.ContainsKey("SapZshReembolso") Then
                Dim dtReturn As DataTable = ListToDataTable(result("SapZshReembolso")("SapTReturn"), "SapTReturn")
                Dim strError As String = ""
                For Each row As DataRow In dtReturn.Rows
                    If dtReturn.Columns.Contains("TYPE") = True Then
                        If CStr(row!TYPE) = "E" Then
                            strError &= CStr(row!MESSAGE)
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    result("MENSAJE") = strError
                    Return result
                End If
            End If
            Dim resultado As Dictionary(Of String, Object)
            resultado = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result("SapZshReembolso").ToString())
            If resultado.ContainsKey("E_BELNR_EFECTIVO") Then
                result("E_BELNR_EFECTIVO") = CStr(resultado("E_BELNR_EFECTIVO"))
            Else
                result("E_BELNR_EFECTIVO") = 0
            End If
            If resultado.ContainsKey("E_BELNR_VALECJA") Then
                result("E_BELNR_VALECJA") = CStr(resultado("E_BELNR_VALECJA"))
            Else
                result("E_BELNR_VALECJA") = 0
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error en reembolso")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return result
    End Function

    Public Function SapZshCalculoReembolsos(ByVal strFolioPedido As String, Optional ByVal IncluirFacturado As String = "") As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        'params("I_PEDIDO") = strFolioPedido
        params("I_REFERENCIA") = strFolioPedido
        params("I_FACTURADO") = IncluirFacturado
        Me.htParametros("SerialID") = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
        result = ExecuteService("ZSH_CALCULO_REEMBOLSOS", params)
        Return result
    End Function

    Public Function SapZshCierre(ByVal FechaCierre As Date, ByVal strCentro As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        Dim strResult As String = ""
        params("CENTRO") = strCentro
        params("FECHA") = Format(FechaCierre, "yyyyMMdd")
        result = ExecuteService("ZSH_CIERRE", params)
        If result.ContainsKey("SapZshCierre") Then
            Dim res As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result("SapZshCierre").ToString())
            If res.ContainsKey("E_Error") Then
                result("E_Error") = res("E_Error")
            Else
                result("E_Error") = ""
            End If
            Dim sapcierre As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result("SapZshCierre").ToString())
            If sapcierre.ContainsKey("E_ERROR") Then
                Dim strMsg As String = ""
                Dim dtReturn As DataTable = ListToDataTable(result("SapTReturn"), "SapTReturn")
                For Each row As DataRow In dtReturn.Rows
                    strMsg &= CStr(row("Message"))
                Next
                result("E_Error") = strMsg
            End If
        End If
        Return result
    End Function

    Public Function SapZshCompensar(ByVal param As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        result = ExecuteService("ZSH_COMPENSAR", params)
        Return result
    End Function

    Public Function SapZshRegistrarLog(ByVal params As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        result = ExecuteService("ZSH_REGISTRAR_LOG", params)
        Return result
    End Function

    Public Function SapZshCrearSolicitud(ByVal params As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        result = ExecuteService("ZSH_CREAR_SOLICITUD", params)
        Return result
    End Function


#End Region

#Region "Descargas"

    Public Function GetFileStr64(ByVal htParams As Hashtable, Optional message As Boolean = True) As DataTable
        Dim dtReturn As DataTable
        Dim oRespuesta As Dictionary(Of String, Object)

        oRespuesta = Me.ExecuteService(htParams, message)

        If oRespuesta Is Nothing Then
            Exit Function
        End If

        Dim respuesta As Newtonsoft.Json.Linq.JObject

        If oRespuesta.ContainsKey("d") Then
            respuesta = oRespuesta("d")
            dtReturn = GetJSONTable(respuesta)
        End If

        Return dtReturn

    End Function


#End Region

#Region "SAP CAR"
    Public Function SapCarInventario(ByVal htParams As Hashtable, Optional message As Boolean = True) As DataTable
        Dim dtReturn As DataTable
        Dim oRespuesta As Dictionary(Of String, Object)

        oRespuesta = Me.ExecuteService(htParams, message)

        If oRespuesta Is Nothing Then
            Exit Function
        End If

        'dtReturn = Tabulate(oRespuesta)

        Dim respuesta As Newtonsoft.Json.Linq.JObject

        If oRespuesta.ContainsKey("d") Then
            respuesta = oRespuesta("d")
            dtReturn = GetJSONTable(respuesta)
        End If

        Return dtReturn
    End Function



    Public Function BuscarVenta(ByVal htParams As Hashtable) As Factura

        Dim dtReturn As DataTable
        Dim strRespuesta As String
        Dim dt As DataTable
        Dim oFacturaMgr As FacturaManager
        Dim oFactura As Factura


        strRespuesta = Me.ExecuteService2(htParams)  'TEMPORAL AL JUNTAR VERSIONES DEJAR UN SOLO MÉTODO

        If Not strRespuesta Is Nothing Then
            If strRespuesta.Length > 0 Then
                'Quitar los corchetes para poder obtener los datos
                Dim cadena As String = strRespuesta.Substring(1, strRespuesta.Length - 2)
                Dim codAlmacen As String = String.Empty
                Dim oRespuesta As Root = JsonConvert.DeserializeObject(Of Root)(cadena)
                Dim strFechaTemp As String = String.Empty
                'Objeto Factura
                oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
                oFactura = oFacturaMgr.Create

                If Not oRespuesta Is Nothing Then
                    If Not oRespuesta.codAlmacen Is Nothing Then
                        codAlmacen = oRespuesta.codAlmacen.Substring(1)
                    End If
                    oFactura.CodAlmacen = codAlmacen
                    oFactura.ClienteId = oRespuesta.clienteId
                    oFactura.CodCaja = "01"
                    oFactura.CodTipoVenta = oFacturaMgr.GetCodTipoVta(oRespuesta.codTipoVta)
                    oFactura.CodVendedor = oRespuesta.codVendedor
                    strFechaTemp = oRespuesta.fecha
                    If strFechaTemp.Length > 0 AndAlso strFechaTemp <> "00000000" Then
                        oFactura.Fecha = Convert.ToDateTime(strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4))
                    End If
                    oFactura.SubTotal = oRespuesta.total - oRespuesta.impuesto
                    oFactura.Total = oRespuesta.total
                    oFactura.Referencia = oRespuesta.referencia
                    oFactura.IVA = oRespuesta.impuesto
                    oFactura.DescTotal = oRespuesta.descTotal * (1 + oAppContext.ApplicationConfiguration.IVA)
                    oFactura.PedidoID = oRespuesta.idPedido
                    ' oFactura.Sector = oRespuesta.sector
                    ' oFactura.Canal = oRespuesta.canal


                    If oRespuesta.posiciones.Count > 0 Then
                        Dim dtDetalle As New DataTable
                        Dim dr As DataRow
                        dtDetalle.Columns.Add(New DataColumn("FacturaID", GetType(Integer)))
                        dtDetalle.Columns.Add(New DataColumn("CodArtProv", GetType(String)))
                        dtDetalle.Columns.Add(New DataColumn("Posicion", GetType(String)))
                        dtDetalle.Columns.Add(New DataColumn("CodArticulo", GetType(String)))
                        dtDetalle.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                        dtDetalle.Columns.Add(New DataColumn("Numero", GetType(String)))
                        dtDetalle.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                        dtDetalle.Columns.Add(New DataColumn("Devuelto", GetType(Integer)))
                        dtDetalle.Columns.Add(New DataColumn("PrecioOferta", GetType(Decimal)))
                        dtDetalle.Columns.Add(New DataColumn("CostoUnit", GetType(Decimal)))
                        dtDetalle.Columns.Add(New DataColumn("Total", GetType(Decimal)))
                        dtDetalle.Columns.Add(New DataColumn("CantDescuentoSistema", GetType(Decimal)))
                        dtDetalle.Columns.Add(New DataColumn("Descuento", GetType(Decimal)))
                        dtDetalle.Columns.Add(New DataColumn("NumeroSerie", GetType(String)))
                        dtDetalle.Columns.Add(New DataColumn("CodTipoDescuento", GetType(String)))
                        dtDetalle.Columns.Add(New DataColumn("IMEI", GetType(String)))
                        dtDetalle.Columns.Add(New DataColumn("DescuentoSistema", GetType(Decimal)))
                        dtDetalle.Columns.Add(New DataColumn("Impuesto", GetType(Decimal)))
                        dtDetalle.Columns.Add(New DataColumn("NumFactura", GetType(String)))

                        For Each posicion As Posicione In oRespuesta.posiciones
                            Dim dcto1 As Decimal = 0
                            Dim dcto2 As Decimal = 0
                            dr = dtDetalle.NewRow
                            dr("FacturaID") = 0
                            dr("CodArtProv") = posicion.articulo
                            dr("Posicion") = posicion.posicion & "0"
                            dr("CodArticulo") = posicion.articulo
                            dr("Descripcion") = posicion.descripcion
                            dr("NumFactura") = posicion.numFactura
                            dr("Numero") = posicion.numero
                            dr("Cantidad") = posicion.cantidad
                            dr("Devuelto") = posicion.devuelto
                            dr("PrecioOferta") = posicion.precioUnit
                            dr("CostoUnit") = posicion.precioUnit
                            dr("Total") = posicion.subtotal
                            dr("Impuesto") = posicion.impuesto
                            dr("CantDescuentoSistema") = 0.0
                            dr("DescuentoSistema") = 0
                            dr("Descuento") = 0
                            If posicion.descuentosOut.Count > 0 Then
                                For Each dcto As DescuentosOut In posicion.descuentosOut
                                    Dim divisor As Decimal = posicion.subtotal
                                    Dim dividendo As Decimal = dcto.descuento
                                    If dcto.codTipoDescuento.ToUpper = "ZDP1" Then
                                        dr("CantDescuentoSistema") = dcto.descuento
                                        dr("DescuentoSistema") = Math.Round((dividendo / divisor) * 100)  'porcentaje
                                        dcto1 = dcto.descuento
                                    Else
                                        dr("CodTipoDescuento") = dcto.codTipoDescuento.ToUpper
                                        dr("Descuento") = Math.Round((dividendo / divisor) * 100)  'porcentaje
                                        dcto2 = dcto.descuento
                                    End If
                                Next
                                If dcto1 > 0 And dcto2 > 0 Then
                                    Dim importe As Decimal = posicion.subtotal - dcto1
                                    dr("Descuento") = Math.Round((dcto2 / importe) * 100) 'porcentaje
                                End If
                            End If
                            dr("NumeroSerie") = String.Empty
                            dr("IMEI") = String.Empty
                            dtDetalle.Rows.Add(dr)
                        Next

                        oFactura.Detalle.Tables.Add(dtDetalle)

                        If oRespuesta.mediosPago.Count > 0 Then
                            Dim dtPagos As New DataTable
                            Dim drPago As DataRow
                            dtPagos.Columns.Add(New DataColumn("FacturaId", GetType(Integer)))
                            dtPagos.Columns.Add(New DataColumn("CodFormasPago", GetType(String)))
                            dtPagos.Columns.Add(New DataColumn("DPValeId", GetType(String)))
                            dtPagos.Columns.Add(New DataColumn("CodBanco", GetType(String)))
                            dtPagos.Columns.Add(New DataColumn("CodTipoTarjeta", GetType(String)))
                            dtPagos.Columns.Add(New DataColumn("NumeroTarjeta", GetType(String)))
                            dtPagos.Columns.Add(New DataColumn("NumeroAutorizacion", GetType(String)))
                            dtPagos.Columns.Add(New DataColumn("NoAfiliacion", GetType(String)))
                            dtPagos.Columns.Add(New DataColumn("Id_Num_Promo", GetType(Integer)))
                            dtPagos.Columns.Add(New DataColumn("MontoPago", GetType(Decimal)))

                            For Each medios As MediosPago In oRespuesta.mediosPago
                                drPago = dtPagos.NewRow
                                drPago("FacturaID") = 0
                                drPago("CodFormasPago") = medios.codFormaPago
                                drPago("DPValeId") = medios.dpValeId
                                If medios.codFormaPago = "DPVL" AndAlso medios.dpValeId.Trim = "" Then
                                    If oRespuesta.referencia.IndexOf("-") > 0 Then
                                        Dim vale As String = oRespuesta.referencia.Substring(oRespuesta.referencia.IndexOf("-") + 1)
                                        drPago("DPValeId") = vale
                                    End If
                                End If
                                drPago("CodBanco") = medios.codBanco
                                drPago("CodTipoTarjeta") = medios.codTipoTarjeta
                                drPago("NumeroTarjeta") = medios.noTarjeta
                                drPago("NumeroAutorizacion") = medios.noAutorizacion
                                drPago("NoAfiliacion") = medios.noAfiliacion
                                If medios.idNumPromo.Trim = "" Then
                                    drPago("Id_Num_Promo") = 0
                                Else
                                    drPago("Id_Num_Promo") = medios.idNumPromo
                                End If
                                drPago("MontoPago") = medios.monto
                                dtPagos.Rows.Add(drPago)
                            Next

                            oFactura.FormasPago.Tables.Add(dtPagos)

                        End If

                    End If

                    If oRespuesta.mediosPagoDev.Count > 0 Then
                        Dim dtCancelado As New DataTable
                        Dim drCancel As DataRow
                        Dim dtMontos As New DataTable

                        dtCancelado.Columns.Add(New DataColumn("FormaPago", GetType(String)))
                        dtCancelado.Columns.Add(New DataColumn("MontoCancelado", GetType(Decimal)))

                        For Each medio As MediosPagoDev In oRespuesta.mediosPagoDev
                            AgregarMonto(dtCancelado, medio.formaPago, medio.montoCancelado)
                            'drCancel = dtCancelado.NewRow
                            'drCancel("FormaPago") = medio.formaPago
                            'drCancel("MontoCancelado") = medio.montoCancelado
                            'dtCancelado.Rows.Add(drCancel)
                        Next

                        oFactura.FormasPago.Tables.Add(dtCancelado)
                    End If
                End If
            End If
        End If
        Return oFactura
    End Function

    Private Sub AgregarMonto(ByRef dtMontos As DataTable, ByVal medio As String, ByVal importe As Decimal)
        Dim encontrado As Boolean = False
        For Each oRow As DataRow In dtMontos.Rows
            If oRow!FormaPago = medio Then
                oRow!MontoCancelado += importe
                encontrado = True
                Exit For
            End If
        Next

        If Not encontrado Then
            Dim row As DataRow = dtMontos.NewRow()
            row("FormaPago") = medio
            row("MontoCancelado") = importe
            dtMontos.Rows.Add(row)
        End If

    End Sub



#End Region

#Region "Ventas"


    Public Function GetTallas(ByVal dParametros As Dictionary(Of String, Object), Optional ByVal bMensaje As Boolean = True) As DataTable

        Dim VentaID As String = ""
        Dim Message As String = ""
        Dim result As New Dictionary(Of String, Object)
        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteExternalService("index.php", dParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            Exit Function
        End If

        Dim dtReturn As DataTable
        If oRespuesta.ContainsKey("materiales") Then
            dtReturn = ListToDataTable(oRespuesta("materiales"), "Materiales")
        End If

        Return dtReturn


    End Function




    Public Function SapZfmcomAclaracion(ByVal dParametros As Dictionary(Of String, Object)) As DataTable 'As Dictionary(Of String, Object)

        Dim result As New Dictionary(Of String, Object)
        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteSAPService("SapZfmcomAclaracion", dParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            Exit Function
        End If

        Dim dtReturn As DataTable
        If oRespuesta.ContainsKey("SapPtOutputData") Then
            dtReturn = ListToDataTable(oRespuesta("SapPtOutputData"), "SapReturn")
        End If

        Return dtReturn

    End Function


    Public Function SapZsdProcesoventa(ByVal dParametros As Dictionary(Of String, Object), Optional ByVal bMensaje As Boolean = True) As Dictionary(Of String, Object)

        Dim VentaID As String = ""
        Dim Message As String = ""
        Dim result As New Dictionary(Of String, Object)
        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZSD_PROCESOVENTA", dParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If
        If oRespuesta.ContainsKey("SapZsdProcesoventa") Then
            Dim msg As String = ""
            Dim dtReturn As DataTable = ListToDataTable(oRespuesta("SapZsdProcesoventa")("SapReturn"), "SapReturn")
            For Each row As DataRow In dtReturn.Rows
                If dtReturn.Columns.Contains("TYPE") = True Then
                    If row.IsNull("TYPE") = False Then
                        If CStr(row!TYPE) = "E" Then
                            msg &= CStr(row!MESSAGE)
                        End If
                    End If

                End If
            Next
            If msg <> "" Then
                EscribeLog(msg, "ZSD_PROCESOVENTA")
                Throw New ApplicationException(msg)
            End If
            result("FolioSAP") = CStr(oRespuesta("SapZsdProcesoventa")("O_FACTURA"))
            result("DocFi") = CStr(oRespuesta("SapZsdProcesoventa")("O_DOCFI"))
            result("Mensaje") = CStr(oRespuesta("SapZsdProcesoventa")("MENSAJE"))
            result("ZRECH") = CStr(oRespuesta("SapZsdProcesoventa")("O_ZRECH"))
            result("FolioRevale") = CStr(oRespuesta("SapZsdProcesoventa")("O_REVALE"))
            result("FormasPagoDPVale") = ListToDataTable(oRespuesta("SapZsdProcesoventa")("SapTFormasPago"), "SapFormasPago")
            Message = oRespuesta("SapZsdProcesoventa")("MENSAJE")
        Else
            Message = CStr(oRespuesta("Message"))
        End If

        If Message Is Nothing Then Message = ""
        'VentaID = oRespuesta("SerialID").ToString

        If Message.Trim <> "" AndAlso bMensaje = True Then
            MessageBox.Show("La venta ha sido guardada correctamente en SAP.", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return result

    End Function

    Public Function SapZshFacturacion(ByVal params As Dictionary(Of String, Object), ByRef dtErrores As DataTable) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim success As Boolean = True
        result = ExecuteService("ZSH_FACTURACION", params)
        If result.ContainsKey("SapZshFacturacion") Then
            Dim msg As String = ""
            Dim dtReturn As DataTable = ListToDataTable(result("SapZshFacturacion")("SapTReturn"), "SapTReturn")
            For Each row As DataRow In dtReturn.Rows
                If dtReturn.Columns.Contains("TYPE") Then
                    If row.IsNull("TYPE") = False Then
                        If CStr(row!TYPE) = "E" Then
                            Dim oRow As DataRow = dtErrores.NewRow
                            oRow!MESSAGE = row!MESSAGE
                            msg &= CStr(row!MESSAGE)
                            success = False
                            dtErrores.Rows.Add(oRow)
                        End If
                    End If
                End If

            Next
            If msg <> "" Then
                EscribeLog(msg, "ZSH_FACTURACION")
                '  Throw New ApplicationException(msg)
            End If
            result("ZshFacturacion") = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result("SapZshFacturacion").ToString())
        End If
        result("Success") = success
        Return result
    End Function

    Public Function SapZcupInfocupon(ByVal Parametros As Dictionary(Of String, Object)) As Object

        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZCUP_INFO_CUPON", Parametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If
        oRespuesta("T_FORMASPAGO") = ListToDataTable(oRespuesta("SapZcupInfoCupon")("SapTFormaspago"))
        oRespuesta("E_ZCUPONES") = ListToDataTable(oRespuesta("SapZcupInfoCupon")("SapEZcupones"))
        Return oRespuesta
    End Function

    Public Function SapZbapiValidaDpvale(ByVal datos As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        result = ExecuteService("ZBAPI_VALIDA_DPVALE", datos)
        Return result
    End Function

    Public Function SapZdpproClienteDev(ByVal FolioFI As String, Optional ByVal PedidoFolioSAP As String = "") As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        If PedidoFolioSAP.Trim() <> "" Then
            params("I_PEDIDO") = PedidoFolioSAP
        Else
            params("I_DEVFI") = FolioFI
        End If
        result = ExecuteService("ZDPPRO_CLIENTE_DEV", params)
        Dim dic As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result("SapZdpproClienteDev").ToString())
        Return dic
    End Function

    Public Function SapZRevivirvaledescto(ByVal FolioSAP As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        params("FOLIOSD") = FolioSAP
        result = ExecuteService("ZREVIVIRVALEDESCTO", params)
        Return result
    End Function

    Public Function SapZbapisd17DevVentasDpvl(ByVal params As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        result = ExecuteService("ZBAPISD17_DEV_VENTAS_DPVL", params)
        Return result
    End Function

    Public Function SapZrfcInsetaDatosPromo(ByVal LADA As String, ByVal NumCel As String, ByVal FormaPago As String, ByVal CodCliente As String, _
                                            ByVal Email As String, ByVal FolioSAP As String, ByVal KeyDPPRO As String) As String
        Dim Parametros As New Dictionary(Of String, Object)
        With Parametros
            .Add("I_NUMCEL", NumCel.Trim)
            .Add("I_ZONAVENTA", FormaPago.ToUpper.Trim)
            .Add("I_KUNNR", CodCliente.Trim.PadLeft(10, "0"))
            .Add("I_LADA", LADA.Trim)
            .Add("I_Email", Email.Trim)
            .Add("I_Factura", FolioSAP.Trim)
            .Add("I_Keydppro", KeyDPPRO)
        End With

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZRFC_INSERTA_DATOS_PROMO", Parametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        Dim strMsg As String = ""
        Dim strRes As String
        strRes = oRespuesta("SapZrfcInsetaDatosPromo")("E_RESULT").ToString
        strMsg = oRespuesta("SapZrfcInsetaDatosPromo")("E_MENSAJE").ToString

        If strRes.Trim.ToUpper <> "Y" Then
            MsgBox(strMsg.Trim, MsgBoxStyle.Exclamation, "Error Guardar Celular")
        End If

        Return strRes

    End Function

    Public Function SapZcsAlgoritmoPromos(ByVal dtMateriales As DataTable, ByVal TipoVenta As String, ByVal Fecha As Date, ByRef htTotales As Hashtable, _
                                          ByVal Almacen As String, ByRef dtMatDesc As DataTable, ByRef dtPromos As DataTable, ByRef dtCrossSelling As DataTable)

        Dim Parametros As New Dictionary(Of String, Object)
        With Parametros

            ' ------------------------------------------------------------------
            ' Llenamos datos de los materiales
            '------------------------------------------------------------------
            Dim oMATERIALES As New List(Of Dictionary(Of String, Object))
            For Each oRow As DataRow In dtMateriales.Rows
                Dim oMATERIAL As New Dictionary(Of String, Object)
                With oMATERIAL
                    .Add("MATERIAL", oRow!Codigo)
                    .Add("TALLA", oRow!Talla)
                    .Add("CANTIDAD", oRow!Cantidad)
                End With
                oMATERIALES.Add(oMATERIAL)
            Next
            .Add("T_MATERIALES", oMATERIALES)

            ' ------------------------------------------------------------------
            ' Llenamos rango de tipo de Venta
            '------------------------------------------------------------------
            Dim oTTVENTA As New List(Of Dictionary(Of String, Object))
            Dim oTVENTA As New Dictionary(Of String, Object)
            With oTVENTA
                .Add("SIGN", "")
                .Add("OPTION", "")
                .Add("LOW", TipoVenta)
                .Add("HIGH", "")
            End With
            oTTVENTA.Add(oTVENTA)
            .Add("T_TVENTA", oTTVENTA)

            'Parametros Generales
            .Add("I_VKBUR", "T" & Almacen.Trim)
            .Add("I_FECHA", Format(Fecha, "yyyyMMdd"))
            .Add("I_CANAL", "T1")

        End With

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZCS_ALGORITMO_PROMOS", Parametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

    End Function

    Public Function SapZdpvlRegistrarRechazo(ByVal NumVale As String, ByVal ClaveMotivo As String, ByVal Plaza As String, ByVal TipoVenta As String) As String

        Dim Result As String

        Dim oParametros As New Dictionary(Of String, Object)
        With oParametros
            .Add("I_NUMVA", CStr(NumVale).PadLeft(10, "0"))
            .Add("I_OFVTA", Plaza)
            .Add("I_MOTIVO", ClaveMotivo)
            .Add("I_TIPO", TipoVenta)
        End With

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZDPVL_REGISTRAR_RECHAZO", oParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        Dim MensajeError, strMsg As String

        Dim obj As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oRespuesta("SapZdpvlRegistrarRechazo").ToString())
        If obj.ContainsKey("E_RESULTADO") = True Then
            Result = oRespuesta("SapZdpvlRegistrarRechazo")("E_RESULTADO").ToString
            MensajeError = oRespuesta("SapZdpvlRegistrarRechazo")("E_MENSAJE").ToString
            strMsg = "Ocurrió un error al intentar registrar los datos: " & MensajeError & ""

            If Result.Trim.ToUpper = "X" Then
                MsgBox(strMsg, MsgBoxStyle.Exclamation, "Error al registrar el motivo del rechazo en SAP")
            End If
        End If


    End Function

    Public Sub ValidaValeEmpleadoSAP(ByVal strVale As String, ByRef strStatusVale As String, ByRef strPorcentaje As String)

        Dim oParametros As New Dictionary(Of String, Object)
        With oParametros
            .Add("NUMVA", strVale.PadLeft(10, "0"))
        End With

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZBAPI_CONSULTAVALEDESCTO", oParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim STATU, PORCENTAJE As String
        STATU = oRespuesta("ZbapiConsultavaledescto")("STATU")
        PORCENTAJE = oRespuesta("ZbapiConsultavaledescto")("PORCENTAJE")

        If STATU = String.Empty Then
            MsgBox("Error al Procesar VALE en SAP. Notificar al Administrador del Sistema.") ' & bolStatus)
            'Throw New ApplicationException("Error al Procesar VALE en SAP. Notificar al Administrador del Sistema.")
        Else

            strStatusVale = STATU
            strPorcentaje = PORCENTAJE

        End If

    End Sub

    Public Function SapZbapiConsultaDescto(ByVal ValeE As ValeEmpleado) As ValeEmpleado
        Dim parameters As New Dictionary(Of String, Object)
        Dim result As Dictionary(Of String, Object)
        parameters("FOLIO") = ValeE.Folio.ToString.PadLeft(5, "0")
        parameters("SERIE") = ValeE.Serie.ToUpper
        result = ExecuteService("ZBAPI_CONSULTAVALEDESCTO", parameters)
        ValeE.Status = CStr(result("SapZbapiConsultavaledescto")("STATU"))
        ValeE.Descuento = CDec(result("SapZbapiConsultavaledescto")("PORCENTAJE")) / 100
        If CStr(result("SapZbapiConsultavaledescto")("REVALE")) = "X" Then
            ValeE.EsRevale = True
        Else
            ValeE.EsRevale = False
        End If
        Return ValeE
    End Function

    Public Function ZbapiObtenerClientes(ByVal strPalabraFind As String, ByVal Tipo As Integer, ByVal TipoCliente As Integer, ByVal cteFinal As String) As DataTable

        'Dim Result As String
        Dim dtResultado As DataTable

        Dim oParametros As New Dictionary(Of String, Object)
        With oParametros
            .Add("I_NOMBRE1", strPalabraFind)
            .Add("I_ID", Tipo)
            .Add("I_TIPO_CLIENTE", TipoCliente)
            .Add("I_TIPO_CLIENTE_FINAL", cteFinal)
        End With

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZBAPI_OBTENER_CLIENTES", oParametros)

        '------------------------------------------------------------------
        ' JNAVA (30.12.2015): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (30.12.2015): Convertimos a tabla y lo retornamos
        '------------------------------------------------------------------
        dtResultado = Me.ListToDataTable(oRespuesta("SapZbapiObtenerClientes")("SapTzcompradores"))
        dtResultado = ValidarColumna("NAME1", dtResultado)
        dtResultado = ValidarColumna("NAME2", dtResultado)
        dtResultado = ValidarColumna("NAME3", dtResultado)
        dtResultado = ValidarColumna("TIPO_CLIENTE", dtResultado)
        dtResultado = ValidarColumna("KUNNR", dtResultado)
        Return dtResultado

    End Function

    Public Function ZdptGuardarVentasElec(ByVal TablaElectronicos As DataTable) As String

        Dim Result As String
        Dim oRespuesta As Dictionary(Of String, Object)
        Dim oFormasPago As New List(Of Dictionary(Of String, Object))
        Dim oParametros As New Dictionary(Of String, Object)
        Dim ErrorSAP As String = String.Empty
        Dim oElectronicos As New List(Of Dictionary(Of String, Object))
        For Each oRow As DataRow In TablaElectronicos.Rows
            '------------------------------------------------------------------
            ' Seteamos datos del detalle
            '------------------------------------------------------------------
            Dim oElect As New Dictionary(Of String, Object)
            With oElect
                .Add("MATERIAL", CStr(oRow!Material).Trim)
                .Add("NUMSERIE", CStr(oRow!NumSerie).Trim)
                .Add("IMEI", CStr(oRow!IMEI).Trim)
                .Add("FACTURA", CStr(oRow!IMEI).Trim)
                .Add("DPVALE", CStr(oRow!Factura).Trim)
                .Add("FPAGO", CStr(oRow!FormaPago).Trim)
            End With
            oElectronicos.Add(oElect)
            oRespuesta = Me.ExecuteService("ZDPT_GUARDAR_VENTAS_ELEC ", oParametros)
        Next

        '------------------------------------------------------------------
        ' Metemos los datos al detalle del objeto para serializarlo a JSON
        '------------------------------------------------------------------
        oParametros.Add("T_ELECTRONICOS", oElectronicos)

        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        oRespuesta = Me.ExecuteService("ZDPT_GUARDAR_VENTAS_ELEC", oParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If
        ErrorSAP = oRespuesta("ZdptGuardarVentasElec")("E_ERROR").ToString

        Return ErrorSAP

    End Function

    Public Function ZGenerarValeCaja(ByVal strCliente As String, ByVal strImporte As String, _
    ByVal strDivision As String, ByVal strAlmacen As String, ByVal strFIDOCUMENT As String, ByVal MotivoPedido As String) As String

        'Dim Result As String

        Dim oParametros As New Dictionary(Of String, Object)
        With oParametros
            .Add("I_KUNNR", strCliente)
            .Add("I_IMPORTE", strImporte)
            .Add("I_MODO", "N")
            '.Add("I_GSBER", strDivision)
            .Add("I_TIENDA", "2" & strAlmacen)
            .Add("I_FDEVOLUCION", strFIDOCUMENT)
            .Add("I_MOT_PED", MotivoPedido)
        End With

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZGENERAR_VALE_CAJA", oParametros)

        '------------------------------------------------------------------
        ' JNAVA (30.12.2015): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        Return oRespuesta("SapZGenerarValeCaja")("E_BELNR").ToString

    End Function

    Public Function SapZcsPromoVigentes(ByVal Fecha As Date, ByVal Almacen As String, Optional ByRef dtVigencias As DataTable = Nothing) As DataTable

        Dim dtResult As DataTable

        Dim oParametros As New Dictionary(Of String, Object)
        With oParametros
            .Add("I_VKBUR", Almacen.Trim)
            .Add("I_FECHA", Format(Fecha, "yyyyMMdd"))
        End With

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZCS_PROMO_VIGENTES", oParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If
        dtResult = ListToDataTable(oRespuesta("SapZcsPromoVigentes")("SapTeFpago"), "SapTeFpago") 'func.Tables("TE_FPAGO").ToADOTable
        If Not dtVigencias Is Nothing Then dtVigencias = New DataTable
        dtVigencias = ListToDataTable(oRespuesta("SapZcsPromoVigentes")("SapTeVigcab"), "SapTeVigcab") 'func.Tables("TE_VIGCAB").ToADOTable

        Return dtResult

    End Function

    Public Function SapZdpvlGetMotivosRechazos() As DataTable
        Dim oParametros As New Dictionary(Of String, Object)
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZDPVL_GET_MOTIVOSRECHAZOS", oParametros)
        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If
        Return ListToDataTable(oRespuesta("SapZdpvlGetMotivosrechazos")("SapTMotivo"), "SapTMotivo")
    End Function

    Public Function SapZpolDatosEnvio(ByVal Pedido As String, ByVal Centro As String, ByRef dtDatosG As DataTable) As DataTable
        Dim dtDatosEnvio As DataTable

        Dim oParametros As New Dictionary(Of String, Object)
        With oParametros
            .Add("I_PEDIDO", Pedido.Trim.PadLeft(10, "0"))
            .Add("I_CESUM", Centro.Trim)
        End With


        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZPOL_DATOS_ENVIO", oParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        dtDatosG = New DataTable("DatosGenerales")
        With dtDatosG
            .Columns.Add("Tipo", GetType(String))
            .Columns.Add("Local", GetType(String))
            .Columns.Add("FacturaSAP", GetType(String))
            .Columns.Add("TrasladoSAP", GetType(String))
            .AcceptChanges()
        End With

        Dim oRow As DataRow = dtDatosG.NewRow
        With oRow
            !Tipo = oRespuesta("SapZpolDatosEnvio")("E_TIPO").ToString()
            !Local = oRespuesta("SapZpolDatosEnvio")("E_LOCAL").ToString()
            !FacturaSAP = oRespuesta("SapZpolDatosEnvio")("E_FACTURA").ToString()
            !TrasladoSAP = oRespuesta("SapZpolDatosEnvio")("E_TRASLADO").ToString()
        End With
        dtDatosG.Rows.Add(oRow)

        Dim Direccion As Dictionary(Of String, Object) = oRespuesta("SapZpolDatosEnvio")("DIRECCION")
        dtDatosEnvio = New DataTable("DatosEnvio")
        With dtDatosEnvio
            .Columns.Add("Nombre", GetType(String))
            .Columns.Add("Domicilio", GetType(String))
            .Columns.Add("Ciudad", GetType(String))
            .Columns.Add("Estado", GetType(String))
            .Columns.Add("RFC", GetType(String))
            .Columns.Add("Telefono", GetType(String))
            .Columns.Add("CP", GetType(String))
            .AcceptChanges()
        End With

        oRow = dtDatosEnvio.NewRow
        With oRow
            !Nombre = Direccion("NAME1") & " " & Direccion("NAME2") & " " & Direccion("NAME3")
            !Domicilio = Direccion("STREET") & Direccion("HOUSE_NUM1") & Direccion("CITY2")
            !Ciudad = Direccion("CITY1")
            !Estado = Direccion("REGION")
            !RFC = Direccion("NAME4")
            !CP = Direccion("POST_CODE1")
            !Telefono = ""
        End With
        dtDatosEnvio.Rows.Add(oRow)

        Return dtDatosEnvio

    End Function

#End Region

#Region "Cupones"

    Public Function SapZCupCancelacion(ByVal FolioCupon As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        Try
            params("I_FOLIO_CUP") = FolioCupon
            result = ExecuteService("ZCUP_CANCELACION", params)
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al Procesar Cancelación en SAP")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return result
    End Function

    Public Function SapZcupUtilCupon(ByVal params As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        result = ExecuteService("ZCUP_UTIL_CUPON", params)
        Return result
    End Function

    Public Function SapZcupDevYRecupon(ByRef oReCupon As CuponDescuento, ByVal FolioSAP As String, ByRef FolioCupon As String, ByVal Descuento As Decimal, ByVal Minimo As Decimal) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        Dim Status As String = ""
        Dim FechaVig As String = ""
        params("I_FOLIO_CUP") = FolioCupon
        params("I_DOCUMENTO_DEV") = FolioSAP
        params("I_SUCURSAL_DEV") = "T" & oAppContext.ApplicationConfiguration.Almacen
        params("I_IMP_RECUP") = Descuento.ToString("##,##0.00").Replace(",", "")
        params("I_IMP_DEV") = Minimo.ToString("##,##0.00").Replace(",", "")
        result = ExecuteService("ZCUP_DEV_Y_RECUPON", params)
        If result.Count > 0 Then
            Status = CStr(result("SapZcupDevYRecupon")("E_RESULTADO"))
            If CInt(Status) = 1 Then
                oReCupon = New CuponDescuento
                With oReCupon
                    .Folio = CStr(result("SapZcupDevYRecupon")("E_FOLIO_RECUP")).ToUpper().Trim()
                    .Descripcion = CStr(result("SapZcupDevYRecupon")("E_DESCRIPCION"))
                    FechaVig = CStr(result("SapZcupDevYRecupon")("E_FECHA_FIN"))
                    .FechaVigencia = CDate(FechaVig.Substring(8, 2) & "/" & FechaVig.Substring(5, 2) & "/" & FechaVig.Substring(0, 4))
                    .Minimo = CStr(result("SapZcupDevYRecupon")("E_MINIMO"))
                    .LimiteDescuento = CStr(result("SapZcupDevYRecupon")("E_LIMITE_DESCTO"))
                End With
            End If
        End If
        Return result
    End Function

    Public Function SapZcupRecuponUtilizable(ByVal params As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        result = ExecuteService("ZCUP_RECUPON_UTILIZABLE", params)
        Return result
    End Function

    Public Function SapZcupUtilCupon(ByVal Folio As String, ByVal TipoVenta As String, ByVal FolioSap As String, ByVal pagos As DataTable)
        Dim result As New Dictionary(Of String, Object)
        Dim param As New Dictionary(Of String, Object)
        Dim Lista As New List(Of Dictionary(Of String, Object))
        param("I_FOLIO") = Folio
        param("I_TIPO_VENTA") = TipoVenta.Trim()
        param("I_FECHA") = Format(Today, "yyyyMMdd")
        param("I_DOCTO_VTA") = FolioSap
        param("I_OFNA_VTA") = "T" & oAppContext.ApplicationConfiguration.Almacen
        If Not pagos Is Nothing Then
            For Each row As DataRow In pagos.Rows
                Dim item As New Dictionary(Of String, Object)
                item("FORMA_PAGO") = CStr(row!FORMA_PAGO)
                Lista.Add(item)
            Next
            param("T_FORMASPAGO") = Lista
        End If
        result = ExecuteService("ZCUP_UTIL_CUPON", param)
        Return result
    End Function

    Public Function ZbapiGetClienteByrfc(ByVal strRFC As String) As DataTable

        Dim Result As String
        Dim dtResultado As DataTable

        Dim oParametros As New Dictionary(Of String, Object)
        With oParametros
            .Add("I_RFC", strRFC.Trim)
        End With

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZBAPI_SELECTCLIENTEBYRFC", oParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        '------------------------------------------------------------------------
        ' JNAVA (30.12.2015): Convertimos info recibida a tabla y la retornamos
        '------------------------------------------------------------------------
        dtResultado = Me.ListToDataTable(oRespuesta("SapZbapiSelectclientebyrfc")("SapDatoscliente"), "SapDatosClientes")

        Return dtResultado

    End Function

#End Region

#Region "Utilerias"

    Public Function SapMssGetSyDateTime() As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Return ExecuteService("MSS_GET_SY_DATE_TIME", result)
    End Function

#End Region

#Region "Descargas"

    Public Function SapZrfcDescargaDatosTiendas(ByVal Name As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Return ExecuteService("ZRFC_DESCARGA_DATOS_TIENDAS", result)
    End Function

#End Region

#Region "DIPS"

    Public Function SapZbapiSelectDips(ByVal strCliente As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        params("FOLIOCLIENTE") = strCliente
        result = ExecuteService("ZBAPI_SELECT_DIPS", params)
        Return result
    End Function

    Public Function SapZBapiActualizaDips(ByVal strCliente As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        params("FOLIOCLIENTE") = strCliente
        result = ExecuteService("ZBAPI_ACTUALIZA_DIPS", params)
        Return result
    End Function

#End Region

#Region "Contabilidad"

    Public Function ZpolRegistroPago(ByVal oCabecera As Hashtable, ByVal dtDetalle As DataTable, ByVal strCentro As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        Dim cabecera As New Dictionary(Of String, Object)
        Dim lstDetalle As New List(Of Dictionary(Of String, Object))
        Dim strErrorMsg As String = ""
        With oCabecera
            cabecera("ORDEN") = !NoOrden
            cabecera("CANAL") = !Canal
            cabecera("PEDIDO") = !Pedido
            cabecera("REFERENCIA") = !Referencia
            cabecera("TOTAL") = !Importe
            cabecera("CENTRO") = strCentro
            cabecera("STATUS") = !Status
            cabecera("USUARIO_SAP") = ""
            cabecera("VENDEDOR") = !Vendedor
            cabecera("FECHA") = Format(Now, "yyyyMMdd")
            cabecera("HORA") = Format(Now, "hhmmss")
            cabecera("WAERK") = !Moneda
            If oCabecera.ContainsKey("Tipo") = True Then
                cabecera("Tipo") = !Tipo
            End If
        End With
        For Each oRow As DataRow In dtDetalle.Rows
            Dim item As New Dictionary(Of String, Object)
            item("ORDEN") = CStr(oRow!NoOrden).Trim
            item("REFERENCIA") = CStr(oRow!Referencia).Trim 'JNAVA (19.02.2015): Se agrego Referencia
            item("FORMA_PAGO") = CStr(oRow!FormaPago).Trim
            item("IMPORTE") = CStr(oRow!Importe).Trim
            item("PARCIALIDADES") = ""
            item("NUM_APROB") = CStr(oRow!NoAutorizacion).Trim
            lstDetalle.Add(item)
        Next
        params("I_CABECERA") = cabecera
        params("T_DETALLE") = lstDetalle
        result = ExecuteService("ZPOL_REGISTRO_PAGO", params)
        strErrorMsg = CStr(result("ZpolRegistroPago")("E_ERROR"))
        If strErrorMsg.Trim = "" Then
            result("SapZcupDevYRecupon")("E_ERROR") = True
        Else
            result("SapZcupDevYRecupon")("E_ERROR") = False
        End If
        result("SapZcupDevYRecupon")("E_ERRORMSG") = strErrorMsg
        Return result
    End Function

    Public Function SapZSerialsReferencias(ByVal Fecha As DateTime) As Boolean
        Dim oFacturaMgr As New DportenisPro.DPTienda.ApplicationUnits.Facturas.FacturaManager(oAppContext, oConfigCierreFI)
        Dim dtSerial As DataTable = oFacturaMgr.GetSerialsByDate(Fecha)
        Dim result As New List(Of Dictionary(Of String, Object))
        Dim URL_REST As String
        Dim lstSerial As New List(Of Dictionary(Of String, Object))
        Dim jsonSerial As String = "", strRespuesta As String
        Dim dtSeriales As New DataTable
        URL_REST = URL & Me.Metodo
        Dim item As Dictionary(Of String, Object) = Nothing
        For Each row As DataRow In dtSerial.Rows
            If CStr(row("SerialId")) <> "" Then
                item = New Dictionary(Of String, Object)
                item("SerialID") = row("SerialId")
                lstSerial.Add(item)
            End If
        Next
        jsonSerial = JsonConvert.SerializeObject(lstSerial)
        strRespuesta = Me.oRest.ConsumeREST(URL_REST, Me.htParametros, jsonSerial)

        'Deserializamos JSON
        result = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(strRespuesta)
        Dim strFolio As String = ""
        Dim lstFolio() As String
        Dim res As Boolean = True
        Dim lstFacturas As New List(Of Dictionary(Of String, Object))
        Dim datos As New Dictionary(Of String, Object)
        For Each row As Dictionary(Of String, Object) In result
            If row.ContainsKey("Estatus") Then
                If CStr(row("Estatus")) = "F" AndAlso CStr(row("Folio")).Trim() <> "" Then
                    datos = GetValuesFolios(CStr(row("Folio")), CStr(row("SerialID")))
                    lstFacturas.Add(datos)
                Else
                    res = False
                End If
            End If
        Next
        If res Then
            Dim view As DataView = Nothing
            For Each dic As Dictionary(Of String, Object) In lstFacturas
                view = New DataView(dtSerial)
                view.RowFilter = "SerialId='" & CStr(dic("SerialId")) & "'"
                If view.Count > 0 Then
                    If CInt(view(0)!FacturaId) <> 0 Then
                        If CStr(dic("O_FACTURA")) = "0" Then
                            MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & "Algunas facturas no fueron guardadas en SAP ", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            res = False
                        End If
                    ElseIf CInt(view(0)!ContradoId) <> 0 Then
                        If CStr(dic("O_DOCFI")) = "0" Then
                            MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & "Algunos Apartados no fueron guardados en SAP", "Dportenis Retail", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            res = False
                        End If
                    ElseIf CInt(view(0)!PedidoId) <> 0 Then
                        If CStr(dic("O_PEDIDO_VENTA")) = "0" Then
                            MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & "Algunos Pedidos no fueron guardados en SAP", "Dportenis Retail", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            res = False
                        End If
                    End If
                End If
            Next
        Else
            Return res
        End If
        Return res
    End Function

    Private Function GetValuesFolios(ByVal folio As String, ByVal nameSerial As String) As Dictionary(Of String, Object)
        Dim values As New Dictionary(Of String, Object)
        values("SerialId") = nameSerial
        Dim lstFolios() As String
        Dim params() As String
        lstFolios = folio.Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries)
        If lstFolios.Length > 0 Then
            For Each fol As String In lstFolios
                params = fol.Trim().Split(New Char() {":"}, StringSplitOptions.RemoveEmptyEntries)
                If params.Length > 1 Then
                    values(params(0)) = params(1)
                Else
                    values(params(0)) = 0
                End If
            Next
        End If
        Return values
    End Function

#End Region

#Region "Inventarios"

    Public Function SapZdpproCentronuevo() As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        Try
            result = ExecuteService("ZDPPRO_CENTRONUEVO", params)
            If CStr(result("SapZdpproCentronuevo")("E_RESULTADO")).Trim() = "1" Then
                result("SapZdpproCentronuevo")("RESULT") = True
            Else
                result("SapZdpproCentronuevo")("RESULT") = False
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return result
    End Function

    Public Function SapZbapimm12Bloquedematerial(ByVal params As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        result = ExecuteService("ZBAPIMM12_BLOQUEDEMATERIAL", params)
        Return result
    End Function
#End Region

#Region "Empleados"
    Public Function ZbapiQuemaVALEmpleado(ByVal Folio As String, ByVal Serie As String, ByVal Referencia As String) As String
        'Dim Result As String
        Dim Status As String

        Dim oParametros As New Dictionary(Of String, Object)
        With oParametros
            .Add("FOLIO", Folio.PadLeft(5, "0"))
            .Add("SERIE", Serie)
            .Add("FOLIOSD", Referencia)
        End With

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZBAPI_QUEMARVALEDESCTO", oParametros)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (30.12.2015): Retornamos informacion recibida
        '------------------------------------------------------------------
        Status = oRespuesta("SapZbapiQuemarvaledescto")("STATU").ToString
        Return Status

    End Function
#End Region

#Region "Facturas"

    Public Function ZrfcdpvlFacturasXVALE(ByRef Fecha As Date) As DataTable

        'Dim Result As String
        Dim dtResultado As DataTable
        Dim oParametros As New Dictionary(Of String, Object)
        With oParametros
            '------------------------------------------------------------------
            ' JNAVA (30.12.2015): Seteamos parametro y dato de Oficina de Venta
            '------------------------------------------------------------------
            .Add("I_OFVTA", "T" & oAppContext.ApplicationConfiguration.Almacen)
            '------------------------------------------------------------------
            .Add("I_FECHADIA", Format(Fecha, "yyyyMMdd"))
        End With

        '------------------------------------------------------------------------
        ' JNAVA (30.12.2015): Ejecutamos Servicio de la BAPI SAP correspondiente
        '------------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService("ZRFCDPVL_FACTURAS_X_VALE", oParametros)

        '------------------------------------------------------------------
        ' JNAVA (30.12.2015): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            'MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        '-----------------------------------------------------------------------------
        ' JNAVA (30.12.2015): Convertimos parametro de respuesta a tabla y retornamos
        '-----------------------------------------------------------------------------
        dtResultado = Me.ListToDataTable(oRespuesta("SapZrfcdpvlFacturasXVale")("SapTVales"))
        Return dtResultado

    End Function

#End Region

#Region "Ecommerce"

    Public Function GenerarGuiaDHL(ByVal OficinaVta As String, ByVal paqueteria As String, ByVal pedido As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        params("I_OFICINAVENTAS") = OficinaVta
        params("I_PAQUETERIA") = paqueteria
        params("I_PEDIDO") = pedido
        result = ExecuteService("DHL", params)
        Return result
    End Function

#End Region

#Region "TimeOuts"

    '-------------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (08.06.2016): Hilo para definir si tarda demasiado una transaccion y validar si se envia correo
    '-------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub ThreadContar()
        Me.ContadorTimer = 0
        While Me.bolDetenerTimer = False
            If Me.ContadorTimer > oConfigCierreFI.LimiteTiempoLentitud Then
                Me.EnviarCorreosLentitud(Me.NombreTransaccion, Me.htParametros("SerialID"))
                Me.ContadorTimer = 0
                Me.bolDetenerTimer = True
                Exit While
            End If
            Me.oThreadTimer.Sleep(1000)
            Me.ContadorTimer += 1
        End While
        Me.ContadorTimer = 0
        Me.bolDetenerTimer = True
    End Sub

    '-------------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 29/01/2018: Envio de correos por problemas de timeout (mas de 2 minutos) Actualización de servidor de correo.
    '-------------------------------------------------------------------------------------------------------------------------------------------
    Public Sub EnviarCorreosLentitud(ByVal NombreTransaccion As String, ByVal SerialID As String)
        Dim objSmtpServer As SmtpMail
        Dim SmtpClient As New System.Net.Mail.SmtpClient
        Dim Credencial As New System.Net.NetworkCredential(oConfigCierreFI.CuentaCorreo, oConfigCierreFI.PasswordCorreo)
        Dim message As New System.Net.Mail.MailMessage()
        Dim Mail As New System.Net.Mail.MailAddress(oConfigCierreFI.CuentaCorreo)
        Dim Body As String = "", strSubject As String = "", strMail As String = ""

        SmtpClient.Host = oConfigCierreFI.ServidorSMTP
        SmtpClient.Port = oConfigCierreFI.PuertoSMTP
        SmtpClient.UseDefaultCredentials = False
        SmtpClient.Credentials = Credencial
        SmtpClient.EnableSsl = True

        message.From = Mail
        message.IsBodyHtml = False
        message.BodyEncoding = System.Text.Encoding.UTF8

        '------------------------------------------------------------------------------------------------------------------------------
        ' Agregamos los correos de los encargador de recibir la notificación
        '------------------------------------------------------------------------------------------------------------------------------
        strSubject = "Conexión DPPRO-BUS lenta en la Sucursal " & oAppContext.ApplicationConfiguration.Almacen
        Body = "Se está presentando lentitud de conexión entre el DPPRO y los servicios del BUS:" & vbCrLf & vbCrLf & _
                  "Fecha: " & Date.Now & vbCrLf & _
                  "Sucursal: " & oAppContext.ApplicationConfiguration.Almacen & vbCrLf & _
                  "Caja: " & oAppContext.ApplicationConfiguration.NoCaja & vbCrLf & _
                  "Proceso: " & NombreTransaccion & "  " & SerialID & vbCrLf & _
                  "Límite de Tiempo Excedido: " & oConfigCierreFI.LimiteTiempoLentitud & " Seg."
        '------------------------------------------------------------------------------------------------------------------------------
        ' Agregamos los correos de los encargador de recibir la notificación
        '------------------------------------------------------------------------------------------------------------------------------
        For Each strMail In oConfigCierreFI.MailLentitud
            If Not strMail Is Nothing AndAlso strMail.Trim <> "" Then
                message.To.Add(strMail)
            End If
        Next
        message.Subject = strSubject
        message.Body = Body
        Try
            SmtpClient.Send(message)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al enviar los Correos de Lentitud DPPRO-BUS.")
        End Try
    End Sub

#End Region

    Private Function GetJSONDate(respuesta As JObject) As DataTable
        Throw New NotImplementedException
    End Function

End Class
