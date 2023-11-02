Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ProcesosToka

#Region "Declaracion de variables y objetos"
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

        Me.Satelite = "DPVAIO"

        'Inicializamos Objeto para el manejo de Servicios REST
        Me.oRest = New ServiciosREST(Me.URL)

        'inicializamos cabecera de Transacciones
        Me.htParametros = New Hashtable

        Me.Metodo = "/servicios/toka"
        Me.Type = "POST"

        Me.SerialID = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()

    End Sub

#End Region

#Region "Transacciones Toka"

    Private Function ExecuteService(Optional ByVal Name As String = "", Optional ByVal oServicio As Object = Nothing) As Dictionary(Of String, Object)
        Dim strJSON As String = ""
        Dim URL_REST As String
        Dim strRespuesta As String = ""
        Dim result As Dictionary(Of String, Object)

        'Definimos URL del Servicio REST
        URL_REST = URL & Me.Metodo & "/" & Name
        'Console.WriteLine(URL_REST)
        'Seteamos parametros de cabecera
        Me.htParametros("Satelite") = Me.Satelite
        Me.htParametros("Tipo") = "S"

        Try
            If Not oServicio Is Nothing Then
                strJSON = CreateObjectPost(oServicio)
            End If
            Console.WriteLine(strJSON)
            'Obtenemos respuesta del servicio REST
            strRespuesta = Me.oRest.ConsumeREST(URL_REST, Me.htParametros, strJSON)
            Console.WriteLine(strRespuesta)
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
                EscribeLog(Mensaje, "Ocurrio un error en Servicio Toka.")
                TransaccionLogToka("Error: " & Mensaje)
            End If

        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

        Return result
    End Function

#End Region

#Region "Conversion"

    Public Function CreateObjectPost(ByVal param As Dictionary(Of String, Object)) As String
        Dim conversion As New Dictionary(Of String, Object)
        Dim parametro As New Dictionary(Of String, Object)
        For Each row As String In param.Keys
            parametro(row) = param(row)
        Next
        Return JsonConvert.SerializeObject(parametro)
    End Function

#End Region

#Region "Servicios"

    Public Function Asignar(ByVal Tarjeta As String, ByVal Nombre As String, ByVal ApellidoP As String, ByVal ApellidoM As String, ByVal Id As String) As Dictionary(Of String, Object)
        Dim Servicio As String = "AsignarTarjeta"
        Dim oParams As New Dictionary(Of String, Object)

        oParams.Add("Tarjeta", Tarjeta)
        oParams.Add("Nombre", Nombre)
        oParams.Add("Paterno", ApellidoP)
        oParams.Add("Materno", ApellidoM)
        oParams.Add("ID", Id)

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)
        If oRespuesta.ContainsKey("ErrorMessage") Then
            oRespuesta = Nothing
            Exit Function
        End If

        Return oRespuesta
    End Function

    Public Function consultarMovimiento(ByVal Tarjeta As String, ByVal fechaInicio As String, ByVal fechaFin As String) As Dictionary(Of String, Object)
        Dim Servicio As String = "consultaMovimientos"
        Dim oParams As New Dictionary(Of String, Object)

        oParams.Add("Tarjeta", Tarjeta)
        oParams.Add("fechaInicio", fechaInicio)
        oParams.Add("fechaFin", fechaFin)

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)
        If oRespuesta.ContainsKey("ErrorMessage") Then
            oRespuesta = Nothing
            Exit Function
        End If

        Return oRespuesta
    End Function

    Public Function consultaSaldo(ByVal Tarjeta As String) As Dictionary(Of String, Object)
        Dim Servicio As String = "consultaSaldo"
        Dim oParams As New Dictionary(Of String, Object)

        oParams.Add("Tarjeta", Tarjeta)

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)
        If oRespuesta.ContainsKey("ErrorMessage") Then
            oRespuesta = Nothing
            Exit Function
        End If
        Return oRespuesta
    End Function

    Public Function Decrementar(ByVal Tarjeta As String, ByVal Monto As Integer) As Dictionary(Of String, Object)
        Dim Servicio As String = "decrementar"
        Dim oParams As New Dictionary(Of String, Object)

        oParams.Add("Tarjeta", Tarjeta)
        oParams.Add("Monto", Monto.ToString("##,##0.00").Replace(",", ""))

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)
        If oRespuesta.ContainsKey("ErrorMessage") Then
            oRespuesta = Nothing
            Exit Function
        End If
        Return oRespuesta
    End Function

    Public Function Dispersar(ByVal Tarjeta As String, ByVal Monto As Integer) As Dictionary(Of String, Object)
        Dim Servicio As String = "dispersar"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------------------
        ' JNAVA (30.03.2017): Se suma la comisión del banco al monto
        '------------------------------------------------------------------------
        Monto = Monto + oConfigCierreFI.ComisionBancoToka

        oParams.Add("Tarjeta", Tarjeta)
        oParams.Add("Monto", Monto.ToString("##,##0.00").Replace(",", ""))

        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)
        If oRespuesta.ContainsKey("ErrorMessage") Then
            oRespuesta = Nothing
            Exit Function
        End If
        Return oRespuesta
    End Function

#End Region

End Class
