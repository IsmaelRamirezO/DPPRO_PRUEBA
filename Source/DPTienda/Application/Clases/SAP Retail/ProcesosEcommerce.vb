Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ProcesosEcommerce

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

        Me.Metodo = "/ecommerce_api"
        Me.Type = "POST"

        Me.SerialID = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()

    End Sub

#End Region

#Region "Transacciones Ecommerce"

    Private Function ExecuteService(ByVal store As String, ByVal orden As String, Optional ByVal Name As String = "", Optional ByVal oServicio As Object = Nothing) As Dictionary(Of String, Object)
        Dim strJSON As String = ""
        Dim URL_REST As String
        Dim strRespuesta As String = ""
        Dim result As Dictionary(Of String, Object)

        'Definimos URL del Servicio REST
        URL_REST = URL & Me.Metodo & "/" & Name
        'Console.WriteLine(URL_REST)
        'Seteamos parametros de cabecera
        'Me.htParametros("Satelite") = Me.Satelite
        'Me.htParametros("Tipo") = "S"
        If store <> String.Empty And orden <> String.Empty Then
            Me.htParametros("order") = orden
            Me.htParametros("store") = store
        End If
        
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

    Public Function CreateItemsOrden(ByVal ResponseEcomm As Dictionary(Of String, Object)) As IList(Of Object)
        Dim oRespuesta As New Dictionary(Of String, Object)
        Dim items As IList(Of Object) = New List(Of Object)
        Dim primerObj As Boolean = True
        For Each product As Object In ResponseEcomm("DatosOrden")
            Dim monto As Decimal = CDec(product("orderItemPrice")) + CDec(product("shippingCharge"))
            'Dim strItem As String = "{orderitem:'" & CStr(product("orderItemId")) & "',Sku:'" & CStr(product("partNumber")) & "',totalProductPrice:'" & CStr(monto) & "'}"
            'If primerObj Then

            'End If

            Dim oItem As New Dictionary(Of String, Object)

            oItem("orderitem") = CStr(product("orderItemId"))
            oItem("Sku") = CStr(product("partNumber"))
            oItem("totalProductPrice") = CStr(monto)

            items.Add(oItem)
        Next
        Return items
    End Function

#End Region

#Region "Servicios"

    Public Function EstatusOrden(ByVal store As String, ByVal orden As String) As Dictionary(Of String, Object)
        Dim Servicio As String = "EstatusOrden"
        Dim oParams As New Dictionary(Of String, Object)

        oParams.Add("store", store)
        oParams.Add("order", orden)
        Dim oRespuesta As Dictionary(Of String, Object)
        Me.oRest.Type = "GET" 'EL TIPO (QUE SI NO VENIA ESPECIFICADO) ES GET
        oRespuesta = Me.ExecuteService(store, orden, Servicio, oParams)
        If oRespuesta.ContainsKey("ErrorMessage") Then
            oRespuesta = Nothing
            Exit Function
        End If

        Return oRespuesta
    End Function


    Public Function ActualizaEstatusOrden(ByVal tipopago As String, ByVal orden As String, ByVal usuario As String, ByVal codVendedor As String, ByVal vale As String, ByVal total As Decimal, ByVal ResponseEcomm As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
        Dim Servicio As String = "ActualizarOrden"
        Dim oParams As New Dictionary(Of String, Object)

        oParams.Add("orden", orden)
        oParams.Add("usuario", usuario)
        oParams.Add("codVendedor", codVendedor)
        oParams.Add("vale", vale)
        oParams.Add("totalPago", CStr(total))
        oParams.Add("concepto", CStr(tipopago))
        oParams.Add("articulos", CreateItemsOrden(ResponseEcomm))
        Dim oRespuesta As Dictionary(Of String, Object)
        Me.oRest.Type = "POST"
        oRespuesta = Me.ExecuteService("", "", Servicio, oParams)
        'If oRespuesta.ContainsKey("ErrorMessage") Then
        ' oRespuesta = Nothing
        'Exit Function
        'End If
        Return oRespuesta
    End Function

#End Region

End Class
