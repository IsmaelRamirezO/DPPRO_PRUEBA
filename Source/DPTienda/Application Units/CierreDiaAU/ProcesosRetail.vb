Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports System.Reflection
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
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

        'Definimos URL del Servicio REST
        URL_REST = URL & Me.Metodo

        'Seteamos parametros de cabecera
        Me.htParametros.Add("fecha", Date.Today.Year & "-" & Date.Today.Month & "-" & Date.Today.Day)
        Me.htParametros.Add("hora", Now.Hour & ":" & Now.Minute & ":" & Now.Second)
        Me.htParametros.Add("satelite", Me.Satelite)

        'Serializamos datos de usuario a JSON
        If Not oServicio Is Nothing Then
            strJSON = CreateObjectPost(Name, oServicio)
        End If
        'strJSON = Me.oRest.SerializarJSON(oServicio)

        'Obtenemos respuesta del servicio REST
        strRespuesta = Me.oRest.ConsumeREST(URL_REST, Me.htParametros, strJSON)

        'deserializamos JSON
        result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(strRespuesta)
        'oRespuesta = Me.oRest.DeserializarJSON(oRespuesta, strRespuesta)

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

#End Region

#Region "Ventas"

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
            MsgBox("La venta ha sido guardada correctamente en SAP.", MsgBoxStyle.Information, "Facturación")
        End If

        Return result

    End Function

    Public Function SapZRevivirvaledescto(ByVal FolioSAP As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        params("FOLIOSD") = FolioSAP
        result = ExecuteService("ZREVIVIRVALEDESCTO", params)
        Return result
    End Function

#End Region

#Region "Cancelacion de Facturas"

    Public Function SapZbapisd29Cancelacion(ByVal FacturaID As Integer, ByVal FolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, _
                                         Optional ByVal strFIDOCUMENT As String = "", Optional ByVal strSALESDOCUMENT As String = "", _
                                         Optional ByVal FolioFISAP As String = "") As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        Dim name As String
        Try
            If oSapConfig.DPValeSAP AndAlso strFIDOCUMENT = "" AndAlso strSALESDOCUMENT = "" Then
                params("CLASEPEDIDO") = FacturaID
                params("I_FACTURA") = FolioSAP
                params("I_AGENTE") = CodVendedor
                params("I_MODE") = "N"
                params("I_WERKS") = IIf(CodAlmacen = "053", "T053", "T" & CodAlmacen)
                name = "ZBAPI_D29_CANCELACION_DPVL"
            Else
                params("CLASEPEDIDO") = "Z" & Mid(oApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "2"
                params("I_FACTURA") = FolioSAP
                params("I_MODE") = "N"
                params("I_AGENTE") = CodVendedor
                name = "ZBAPIS_D29_CANCELACION_FACT_AUTO"
            End If
            result = ExecuteService(name, params)
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return result
    End Function

#End Region

#Region "Si Hay"

    Public Function SapZshCompensar(ByVal strCentro As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        Dim strResult As String = ""
        params("CENTRO") = strCentro
        result = ExecuteService("ZSH_COMPENSAR", params)
        Dim sapcierre As Dictionary(Of String, JArray) = JsonConvert.DeserializeObject(Of Dictionary(Of String, JArray))(result("SapZshCompensar").ToString())
        If sapcierre.ContainsKey("SapTReturn") Then
            Dim strMsg As String = ""
            Dim dtReturn As DataTable = ListToDataTable(sapcierre("SapTReturn"), "SapTReturn")
            For Each row As DataRow In dtReturn.Rows
                strMsg &= CStr(row("Message")) & " "
            Next
            result("E_Error") = strMsg
        Else
            result("E_Error") = ""
        End If
        Return result
    End Function

#End Region

#Region "Conversion"
    Public Function ListToDataTable(ByVal array As JArray, Optional ByVal name As String = "") As DataTable
        Dim dt As New DataTable
        dt = JsonConvert.DeserializeObject(Of DataTable)(array.ToString())
        dt.TableName = name
        Return dt
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
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return result
    End Function

    Public Function SapZcupUtilCupon(ByVal Folio As String, ByVal TipoVenta As String, ByVal FolioSap As String, ByVal pagos As DataTable) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim param As New Dictionary(Of String, Object)
        Dim Lista As New List(Of Dictionary(Of String, Object))
        param("I_FOLIO") = Folio
        param("I_TIPO_VENTA") = TipoVenta.Trim()
        param("I_FECHA") = Format(Today, "yyyyMMdd")
        param("I_DOCTO_VTA") = FolioSap
        param("I_OFNA_VTA") = "T" & oApplicationContext.ApplicationConfiguration.Almacen
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

    Public Function SapZcupRecuponUtilizable(ByVal FolioCupon As String, ByVal FolioSAP As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        params("I_FOLIO_RECUP") = FolioCupon.Trim().ToUpper()
        params("I_DOCUMENTO_DEV") = FolioSAP.Trim()
        result = ExecuteService("ZCUP_RECUPON_UTILIZABLE", params)
        Return result
    End Function

#End Region

#Region "Utilerias"

    Public Function SapMssGetSyDateTime() As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Return ExecuteService("MSS_GET_SY_DATE_TIME", result)
    End Function

#End Region

End Class
