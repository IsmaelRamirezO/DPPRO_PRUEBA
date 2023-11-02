Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports System.Reflection
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.Core
Imports Newtonsoft.Json.Linq

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
    Private oApplicationContext As ApplicationContext
    Private oConfigSaveArchivos As SaveConfigArchivos
    Private oSapConfig As SAPApplicationConfig
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

    Public Sub New(ByVal metodo As String, ByVal type As String, ByVal oConfig As SaveConfigArchivos, ByVal oAppContext As ApplicationContext, ByVal oSapConfig As SAPApplicationConfig)

        'Inicializamos URL Base
        Me.oConfigSaveArchivos = oConfig
        Me.oApplicationContext = oAppContext
        Me.oSapConfig = oSapConfig
        Me.URL = oConfigSaveArchivos.ServidorREST & ":" & oConfigSaveArchivos.PuertoREST
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

        'Definimos URL del Servicio REST
        URL_REST = URL & Me.Metodo

        'Seteamos parametros de cabecera
        'Me.htParametros.Add("fecha", Date.Today.Year & "-" & Date.Today.Month & "-" & Date.Today.Day)
        'Me.htParametros.Add("hora", Now.Hour & ":" & Now.Minute & ":" & Now.Second)
        Me.htParametros("Satelite") = Me.Satelite
        Me.htParametros("Tipo") = "S"
        If htParametros.ContainsKey("SerialID") = False Then
            htParametros("SerialID") = oApplicationContext.ApplicationConfiguration.Almacen & oApplicationContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
        End If

        Try
            'Serializamos datos de usuario a JSON
            If Not oServicio Is Nothing Then
                strJSON = CreateObjectPost(Name, oServicio)
            End If
            'strJSON = Me.oRest.SerializarJSON(oServicio)

            'Obtenemos respuesta del servicio REST
            strRespuesta = Me.oRest.ConsumeREST(URL_REST, Me.htParametros, strJSON)

            'deserializamos JSON
            result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(strRespuesta)
            If result.ContainsKey("ErrorMessage") Then
                'EscribeLog(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), CStr(result("ErrorMessage")("SerialID")) & CStr(result("ErrorMessage")("Codigo")) & " " & CStr(result("ErrorMessage")("Fecha")))
                'MessageBox.Show(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Throw New ApplicationException(CStr(result("ErrorMessage")("Mensaje")) & vbCrLf & CStr(result("ErrorMessage")("Detalle")))
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New ApplicationException(ex.Message, ex)
        End Try

        'Devolvemos informacion
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

    Public Function ListToDataTable(ByVal array As JArray, Optional ByVal name As String = "") As DataTable
        Dim dt As New DataTable
        dt = JsonConvert.DeserializeObject(Of DataTable)(array.ToString())
        dt.TableName = name
        Return dt
    End Function

#End Region

#Region "Ventas"

    Public Function SapZbapisd17_dev_ventas_Dpvl(ByRef pNotaCredito As NotaCredito, ByRef oAbonoCreditoDirecto As AbonoCreditoDirectoTienda.AbonoCreditoDirectoManager, ByVal FolioPedido As String, ByVal decDevDPVL As Decimal) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        Dim datosdet As New List(Of Dictionary(Of String, Object))
        Dim strCodCaja As String
        Try
            params("CLASEPEDIDO") = "ZDEV" '& Mid(pNotaCredito.AlmacenID, 2, 2) & "3"
            params("OFICINAVTA") = "T" & pNotaCredito.AlmacenID
            params("I_AGENTE") = pNotaCredito.PlayerID
            If oApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                params("I_WERKS") = "T053"
            Else
                params("I_WERKS") = "T" & pNotaCredito.AlmacenID
            End If
            params("I_CREDITO") = "N"
            If pNotaCredito.ClienteID.PadLeft(10, "0") = "10000000".PadLeft(10, "0") Then
                params("I_KUNNR") = ""
            End If
            params("I_ZONAVTA") = "EFEC"
            params("I_MODE") = "N"
            Dim i As Integer = 0
            For Each row As DataRow In pNotaCredito.Detalle.Tables(0).Rows
                Dim item As New Dictionary(Of String, Object)
                i += i
                item("FOLIO") = i
                item("MATNR") = row("CodArticulo")
                item("CANTIDAD") = row("Cantidad")
                If IsNumeric(row("Numero")) Then
                    item("TALLA") = Format(CDec(row("Numero")), "##.0")
                Else
                    item("TALLA") = row("Numero")
                End If
                datosdet.Add(item)
                strCodCaja = row!CodCaja
                params("I_FACTURA") = CStr(row("FolioReferencia")).PadLeft(10, "0")
            Next
            If FolioPedido.Trim <> "" Then
                params("I_FACTURA") = pNotaCredito.FIDOCUMENT.Trim()
            Else
                params("I_FACTURA") = oAbonoCreditoDirecto.GetSelectFolioFacturaSDSAP(CStr(params("I_FACTURA")), strCodCaja)
            End If
            params("I_MONDPVL") = decDevDPVL.ToString("##,##0.00").Replace(",", "")
            params("I_Fecha") = Format(pNotaCredito.Fecha, "dd/MM/yyyy")
            params("I_KEYPRO") = "T" & oApplicationContext.ApplicationConfiguration.Almacen & _
                oApplicationContext.ApplicationConfiguration.NoCaja & CStr(oAbonoCreditoDirecto.GetSelectNCByCaja(strCodCaja))
            If FolioPedido.Trim() <> "" Then
                params("I_FOLIOPEDIDO") = FolioPedido.Trim
            End If
            If CStr(params("I_FACTURA")) = "" Then
                pNotaCredito.SALESDOCUMENT = String.Empty
                pNotaCredito.FIDOCUMENT = String.Empty
            End If
            params("DATOSDET") = datosdet
            result = ExecuteService("ZBAPISD17_DEV_VENTAS_DPVL", params)
            If result.ContainsKey("SapZbapisd17DevVentasDpvl") Then
                Dim dtReturn As DataTable = ListToDataTable(result("SapZbapisd17DevVentasDpvl")("SapReturn"), "SapReturn")
                Dim err As String = ""
                For Each row As DataRow In dtReturn.Rows
                    If dtReturn.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row!TYPE) = "E" Then
                                err &= CStr(row!MESSAGE)
                            End If
                        End If
                    End If   
                Next
                If err <> "" Then
                    Throw New ApplicationException(err)
                End If
            End If
            pNotaCredito.SALESDOCUMENT = CStr(result("SapZbapisd17DevVentasDpvl")("SALESDOCUMENT"))
            pNotaCredito.FIDOCUMENT = CStr(result("SapZbapisd17DevVentasDpvl")("FIDOCUMENT"))
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return result
    End Function
#End Region


#Region "Utilerias"

    Public Function SapMssGetSyDateTime() As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Return ExecuteService("ZMSS_GET_SY_DATE_TIME", result)
    End Function

#End Region

End Class
