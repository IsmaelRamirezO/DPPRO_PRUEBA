'-------------------------------------------------------------------------
'                        Class ProcesosS2Credit                          
'-------------------------------------------------------------------------
' Descripción        : Clase para consumir servicios de S2Credit      
' Funcional          : Alberto Naranjo                                
' Programador        : Josué Nava                                     
' Fecha de Creación  : 28.01.2016 - 29.01.2016  
' ID CC              : N/A                                            
'-------------------------------------------------------------------------
' Descripción        : Implementación de Servicios de S2Credit en versión
'                      para Retail
' Funcional          : N/A                               
' Programador        : Josué Nava                                     
' Fecha de Creación  : 12.04.2016
' ID CC              : N/A                                            
'-------------------------------------------------------------------------
' Descripción        : Implementación de Servicios de S2Credit como
'                      validador en base a configuracion
' Funcional          : N/A                               
' Programador        : Josué Nava                                     
' Fecha de Creación  : 11.07.2016 - 
' ID CC              : N/A                                            
'-------------------------------------------------------------------------

Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports System.Reflection
Imports System.ComponentModel
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Linq.JArray

Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Public Class ProcesosS2Credit

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
        Me.URL = oConfigCierreFI.ServidorS2credit & ":" & oConfigCierreFI.PuertoS2Credit
        'Me.URL = strURL
        Me.Satelite = "DPPRO"

        'Inicializamos Objeto par ael manejo de Servicios REST
        Me.oRest = New ServiciosREST(Me.URL)

        'inicializamos cabecera de Transacciones
        Me.htParametros = New Hashtable

        Me.Metodo = "/pos/s2credit"
        Me.Type = "POST" 'Siempre sera POST

        Me.SerialID = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()

    End Sub

#End Region

#Region "Transacciones SAP Retail"

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

    Private Function DecodificarFirma(ByVal Firma As String) As Image
        '-----------------------------------------------------------------------------------
        ' JNAVA (08.07.2016): Funcion para decodificar la firma del distribuidor
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
    ' JNAVA (22.07.2016): Quita signos de puntuacion y caracteres especiales
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
    ' JNAVA (26.07.2016): Quita nullos retornados por los servicios
    '----------------------------------------------------------------------------------------------------------
    Private Function NoNulls(ByVal Objeto As Object) As String
        Dim Result As String = String.Empty
        If Not Objeto Is Nothing Then
            Result = Objeto.ToString
        End If
        Return Result
    End Function

#End Region

#Region "Servicios"

    Private Function CouponSearch(ByVal FolioDPVale As String) As Dictionary(Of String, Object)

        Dim Servicio As String = "coupon-search"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------
        ' Preparamos parametros para enviar json generico
        '------------------------------------------------------------
        oParams.Add("coupon", FolioDPVale)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return oRespuesta

    End Function

    Private Function Offers(ByVal PlazaID As String, ByVal Monto As Decimal, ByVal Fecha As Date) As DataTable

        Dim Servicio As String = "offers"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------
        ' JNAVA (26.07.2016): Preparamos parametros para enviar json generico
        '------------------------------------------------------------
        oParams.Add("id_branch", PlazaID)
        oParams.Add("amount", Monto)
        oParams.Add("date", Fecha.ToString("yyyy-MM-dd"))

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (26.07.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Dim promociones As DataTable = JsonConvert.DeserializeObject(Of DataTable)(oRespuesta("data").ToString())
        If Not promociones Is Nothing AndAlso promociones.Rows.Count > 0 Then
            Dim vistaPromociones As New DataView(promociones, "start_date <= #" & Fecha.ToString("yyyy-MM-dd") & "# and finish_date >= #" & Fecha.ToString("yyyy-MM-dd") & "# and min_amount <= " & Monto & " and max_amount >= " & Monto, "term desc", DataViewRowState.CurrentRows)
            Return vistaPromociones.ToTable()
        End If

        Return promociones

    End Function

    Private Function Insurance() As DataTable

        Dim Servicio As String = "insurance"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (03.08.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return JsonConvert.DeserializeObject(Of DataTable)(oRespuesta("data").ToString())

    End Function

    Private Function SearchCustomers(ByVal Valor As String) As List(Of Dictionary(Of String, Object))

        Dim Servicio As String = "search-customer"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------
        ' Preparamos parametros para enviar json generico
        '------------------------------------------------------------
        oParams.Add("data", Valor)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oRespuesta("results").ToString())

    End Function

    '-------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 15/03/2018: Validar si el cliente no ha llegado a su tope de credito
    '-------------------------------------------------------------------------------------------------------------------

    Public Function SearchCustomersWithAmount(ByVal Valor As String, Optional ByVal Monto As Decimal = 0) As Boolean

        Dim Servicio As String = "search-customer"
        Dim oParams As New Dictionary(Of String, Object)
        Dim valido As Boolean = True
        '------------------------------------------------------------
        ' Preparamos parametros para enviar json generico
        '------------------------------------------------------------        
        oParams.Add("data", Valor)
        If Monto <> 0 Then
            oParams.Add("monto_venta", Monto)
        End If
        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            If Monto <> 0 Then
                valido = False
                Dim ErrorMessage As New Dictionary(Of String, Object)
                Dim Mensaje As String = String.Empty
                ErrorMessage = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oRespuesta("ErrorMessage").ToString)
                If ErrorMessage.ContainsKey("Mensaje") Then
                    Mensaje = CStr(ErrorMessage("Mensaje")) & vbCrLf & "Tomar en cuenta el importe de seguro de vida"
                ElseIf ErrorMessage.ContainsKey("msn") Then
                    Mensaje = CStr(ErrorMessage("msn")) & vbCrLf & "Tomar en cuenta el importe de seguro de vida"
                End If
                MessageBox.Show(Mensaje, "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            oRespuesta = Nothing
            Exit Function
        End If
        Return valido
    End Function

    Private Function fortnights() As List(Of Dictionary(Of String, Object))

        Dim Servicio As String = "fortnights"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oRespuesta("data").ToString())

    End Function

    Private Function NewCoupon(ByVal FolioVale As String, ByVal FolioCliente As String, ByVal Monto As Decimal, ByVal EsFacturacion As Boolean) As Dictionary(Of String, Object)

        Dim Servicio As String = "new-coupon"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------
        ' Preparamos parametros para enviar json generico
        '------------------------------------------------------------
        oParams.Add("idCoupon", FolioVale)
        oParams.Add("idCustomer", FolioCliente)
        oParams.Add("amount", Monto.ToString("##,##0.00").Replace(",", ""))
        '------------------------------------------------------------
        ' JNAVA (01.08.2016): Valida si es de Facturacion o NC
        '------------------------------------------------------------
        If EsFacturacion Then
            oParams.Add("type", "1") 'Facturacion
        Else
            oParams.Add("type", "2") 'Devolucion (NC)
        End If

        '------------------------------------------------------------------
        ' Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If

        '------------------------------------------------------------------
        ' Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return oRespuesta

    End Function

    Private Function Devolution(ByVal FolioVale As String, ByVal DistribuidorID As String, ByVal Monto As Decimal) As Dictionary(Of String, Object)

        Dim Servicio As String = "devolution"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------
        ' Preparamos parametros para enviar json generico
        '------------------------------------------------------------
        oParams.Add("distributor_number", DistribuidorID)
        oParams.Add("id_coupon", FolioVale)
        oParams.Add("amount", Monto.ToString("##,##0.00").Replace(",", ""))

        '------------------------------------------------------------------
        ' Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        'If oRespuesta.ContainsKey("ErrorMessage") Then
        '    ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    oRespuesta = Nothing
        '    Exit Function
        'End If

        '------------------------------------------------------------------
        ' Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return oRespuesta

    End Function

    Private Function Sepomex(ByVal CodigoPostal As String) As DataTable
        Dim Servicio As String = "sepomex"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------
        ' Preparamos parametros para enviar json generico
        '------------------------------------------------------------
        oParams.Add("zipcode", CodigoPostal)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return JsonConvert.DeserializeObject(Of DataTable)(oRespuesta("data").ToString())

    End Function

    Private Function Branches() As DataTable

        Dim Servicio As String = "branches"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------------
        ' JNAVA (26.07.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (26.07.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (26.07.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return JsonConvert.DeserializeObject(Of DataTable)(oRespuesta("data").ToString())

    End Function

    Private Function Purchase(ByVal oVentaS2C As Dictionary(Of String, Object)) As Dictionary(Of String, Object)

        Dim Servicio As String = "purchase2"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------
        ' JNAVA (02.08.2016): Preparamos parametros para enviar json generico
        '------------------------------------------------------------
        With oVentaS2C
            oParams.Add("customer", oVentaS2C("customer"))
            oParams.Add("distributor", oVentaS2C("distributor"))
            oParams.Add("idCoupon", oVentaS2C("idCoupon"))
            oParams.Add("date", oVentaS2C("date"))
            oParams.Add("couponAmount", oVentaS2C("couponAmount"))
            oParams.Add("purchaseAmount", oVentaS2C("purchaseAmount"))
            oParams.Add("idBranch", oVentaS2C("idBranch"))
            oParams.Add("idStore", oVentaS2C("idStore"))
            oParams.Add("idInsurance", oVentaS2C("idInsurance"))
            oParams.Add("purchases", oVentaS2C("purchases"))
        End With

        '------------------------------------------------------------------
        ' JNAVA (02.08.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (02.08.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return oRespuesta

    End Function

    Private Function Stores(ByVal PlazaID As String) As DataTable

        Dim Servicio As String = "store"
        Dim oParams As New Dictionary(Of String, Object)
        oParams.Add("id_branch", PlazaID)

        '------------------------------------------------------------------
        ' JNAVA (04.08.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (04.08.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (04.08.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return JsonConvert.DeserializeObject(Of DataTable)(oRespuesta("data").ToString())

    End Function

    Private Function BeneficiaryChange(ByVal VentaID As String, ByVal ParentescoID As String, ByVal Nombre As String, ByVal SegundoNombre As String, ByVal ApellidoPaterno As String, ByVal ApellidoMaterno As String) As Dictionary(Of String, Object)

        Dim Servicio As String = "beneficiary-change"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------
        ' Preparamos parametros para enviar json generico
        '------------------------------------------------------------
        oParams.Add("id_relationship", ParentescoID)
        oParams.Add("id_purchase", VentaID)
        oParams.Add("name", Nombre.Trim)
        oParams.Add("middle_name", SegundoNombre.Trim)
        oParams.Add("last_name", ApellidoPaterno.TrimEnd)
        oParams.Add("second_last_name", ApellidoMaterno.TrimEnd)

        '------------------------------------------------------------------
        ' Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' Obtenemos Informacion recibida
        '------------------------------------------------------------------
        'If oRespuesta.ContainsKey("ErrorMessage") Then
        '    ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    oRespuesta = Nothing
        '    Exit Function
        'End If

        '------------------------------------------------------------------
        ' Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return oRespuesta

    End Function

    Private Function RelationShip() As DataTable

        Dim Servicio As String = "relationship"
        Dim oParams As New Dictionary(Of String, Object)
        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (03.08.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return JsonConvert.DeserializeObject(Of DataTable)(oRespuesta("data").ToString())

    End Function

#End Region

#Region "Venta DPVale"

    '-------------------------------------------------------------------------------
    ' JNAVA (07.07.2016): Valida el DPVale en S2 Credit
    '-------------------------------------------------------------------------------
    Public Function ValidaDPVale(ByVal cdpvale As cDPVale, ByRef FirmaDistribuidor As Image, ByRef NombreDistribuidor As String) As cDPVale

        Dim oDPValeS2C As New Dictionary(Of String, Object)

        Dim oDistribuidor, oPlaza, oCredito, oVale, purchases As New Dictionary(Of String, Object)
        Dim oListaSeguros As New List(Of Dictionary(Of String, Object))
        Dim oListaAmortizationPurchase As New List(Of Dictionary(Of String, Object))

        Try

            '-------------------------------------------------------------------------------
            ' Consumimos el servicio de S2Credit
            '-------------------------------------------------------------------------------
            oDPValeS2C = Me.CouponSearch(cdpvale.INUMVA)

            '-------------------------------------------------------------------------------
            '  Validamos respuesta
            '-------------------------------------------------------------------------------
            If Not oDPValeS2C Is Nothing Then

                '------------------------------------------------------------------------------
                ' JNAVA (26.07.2016): Obtenemos datos y validamos
                '------------------------------------------------------------------------------
                oDistribuidor = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("distributor").ToString())
                oPlaza = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("branch").ToString())
                oCredito = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("credit").ToString())
                oVale = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("coupon").ToString())
                '---------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA  03/08/2017: Se carga la informacion del monto del seguro de la venta
                '---------------------------------------------------------------------------------------------------------------------
                If NoNulls(oDPValeS2C("purchases")).Trim() <> "" Then
                    purchases = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("purchases").ToString())
                End If
                '--------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 15/07/2017: Carga  informacion del seguro
                '--------------------------------------------------------------------------------------------------------
                If NoNulls(oDPValeS2C("insurance")).Trim() <> "" Then
                    oListaSeguros = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oDPValeS2C("insurance").ToString())
                End If

                '--------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 14/11/2017: Carga información de amortizaciones de compra
                '--------------------------------------------------------------------------------------------------------
                If NoNulls(oDPValeS2C("amortizationsPurchase")).Trim() <> "" Then
                    oListaAmortizationPurchase = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oDPValeS2C("amortizationsPurchase").ToString())
                End If
                '-------------------------------------------------------------------------------------------
                ' DATOS DE DISTRIBUIDOR
                '-------------------------------------------------------------------------------------------
                ' JNAVA (26.07.2016): Obtemos el Nombre completo del Distribuidor
                '-------------------------------------------------------------------------------------------
                Dim Nombres, Apellidos As String
                Nombres = NoNulls(oDistribuidor("name")).TrimEnd & " " & NoNulls(oDistribuidor("middleName")).TrimEnd
                Apellidos = NoNulls(oDistribuidor("lastName")).TrimEnd & " " & NoNulls(oDistribuidor("secondLastName")).TrimEnd
                NombreDistribuidor = Nombres.TrimEnd & " " & Apellidos.TrimEnd

                '-------------------------------------------------------------------------------------------
                ' JNAVA (26.07.2016): Obtemos la Firma del Distribuidor
                '-------------------------------------------------------------------------------------------
                FirmaDistribuidor = DecodificarFirma(NoNulls(oDistribuidor("signature")))

                '-------------------------------------------------------------------------------------------
                ' JNAVA (01.08.2016): Obtemos el Estatus del Distribuidor
                '-------------------------------------------------------------------------------------------
                If CInt(NoNulls(oDistribuidor("status"))) = 1 Then

                    '-------------------------------------------------------------------------------------------
                    ' JNAVA (07.10.2016): Obtemos el Estatus del Credito
                    '-------------------------------------------------------------------------------------------
                    If CInt(NoNulls(oCredito("status"))) = 3 Then

                        '-------------------------------------------------------------------------------------------
                        ' JNAVA (07.10.2016): validamos la mora del Credito
                        '-------------------------------------------------------------------------------------------
                        If CInt(NoNulls(oCredito("currentMora"))) <= 0 Then
                            cdpvale.Congelado = String.Empty
                        Else
                            cdpvale.Congelado = "X" 'Deshabilitado
                        End If

                    Else
                        cdpvale.Congelado = "X" 'Deshabilitado
                    End If

                Else
                    cdpvale.Congelado = "X" 'Deshabilitado
                End If
                '-------------------------------------------------------------------------------------------

                '-------------------------------------------------------------------------------------------
                ' DATOS DE DPVALE
                '------------------------------------------------------------------------------
                Dim dtInfoDPVALE As New DataTable
                dtInfoDPVALE.Columns.Add("KUNNR") 'Distribuidor
                dtInfoDPVALE.Columns.Add("FECCR") 'Fecha de Creacion
                dtInfoDPVALE.Columns.Add("FECIN") 'Fecha de inicio
                dtInfoDPVALE.Columns.Add("CODCT") 'Cliente del Vale
                dtInfoDPVALE.Columns.Add("Monto") 'Monto del Vale
                dtInfoDPVALE.Columns.Add("Pares") 'Siempre 0
                dtInfoDPVALE.Columns.Add("REVAL")  'REvale Facturacion (X = Si, Vacio = No)
                dtInfoDPVALE.Columns.Add("ZREVAL2") 'REvale Facturacion (X = Si, Vacio = No)
                dtInfoDPVALE.Columns.Add("Orige") 'Vale Origen
                dtInfoDPVALE.Columns.Add("NUMDE") ' Quincenas (Vale Usado o Revale)
                dtInfoDPVALE.Columns.Add("LOANTERM")
                dtInfoDPVALE.Columns.Add("CUENTAMORTIZACIONES")
                dtInfoDPVALE.Columns.Add("MONTOAMORTIZACIONES")
                '------------------------------------------------------------------------------------
                ' JNAVA (02.08.2016): Agregamos datos de Vale origen para validar Promociones
                '------------------------------------------------------------------------------------
                dtInfoDPVALE.Columns.Add("ONUMDE") 'Quincenas de Vale Origen
                dtInfoDPVALE.Columns.Add("OFECCO") 'Fecha de Cobro Vale Origen
                dtInfoDPVALE.Columns.Add("INSURANCE") 'Monto del seguro
                dtInfoDPVALE.Columns.Add("AMOUNT") ' Monto quincenal
                dtInfoDPVALE.Columns.Add("DATESTART") 'Fecha Inicio de Pago
                dtInfoDPVALE.Columns.Add("DATEEND") 'Fecha Fin de Pago

                '------------------------------------------------------------------------------------
                'FLIZARRAGA 14/11/2017: Agregamos la fecha de primer pago
                '------------------------------------------------------------------------------------
                dtInfoDPVALE.Columns.Add("FECHAPRIMERPAGO", GetType(DateTime)) 'Fecha que empieza a pagar el vale

                dtInfoDPVALE.AcceptChanges()

                '------------------------------------------------------------------------------
                ' JNAVA (26.07.2016): Llenamos informacion del Vale
                '------------------------------------------------------------------------------
                Dim oRow As DataRow
                oRow = dtInfoDPVALE.NewRow
                oRow("KUNNR") = NoNulls(oDistribuidor("number"))
                If Not NoNulls(oVale("issuedDate")) Is String.Empty Then
                    oRow("FECCR") = Format(CDate(oVale("issuedDate").ToString), "yyyyMMdd")
                End If
                If Not NoNulls(oVale("expirationDate")) Is String.Empty Then
                    oRow("FECIN") = Format(CDate(oVale("expirationDate").ToString), "yyyyMMdd")
                End If
                oRow("CODCT") = NoNulls(oVale("idCustomer"))
                '--------------------------------------------------------------------------------------
                'FLIZARRAGA 18/08/2017: Cargamos el monto electronico
                '--------------------------------------------------------------------------------------
                If NoNulls(oVale("amount")) = String.Empty Then
                    oRow("Monto") = 0.0
                    cdpvale.MontoElectronico = 0.0
                Else
                    oRow("Monto") = CDec(NoNulls(oVale("amount").ToString))
                    cdpvale.MontoElectronico = CDec(NoNulls(oVale("amount").ToString))
                End If
                oRow("Pares") = 0
                oRow("NUMDE") = NoNulls(oVale("fortnight"))

                '------------------------------------------------------------------------------
                ' JNAVA (01.08.2016): Info Vale Padre (Original)
                '------------------------------------------------------------------------------
                If NoNulls(oDPValeS2C("parent")) <> String.Empty Then
                    Dim oParent As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("parent").ToString())
                    oRow("REVAL") = "X"
                    oRow("ZREVAL2") = String.Empty
                    oRow("Orige") = NoNulls(oParent("id")).PadLeft(10, "0")
                    '------------------------------------------------------------------------------------
                    ' JNAVA (02.08.2016): Agregamos datos de Vale origen para validar Promociones
                    '------------------------------------------------------------------------------------
                    oRow("ONUMDE") = NoNulls(oParent("fortnight")) 'Quincenas Vale Origen
                    Dim FECCO As String = NoNulls(oParent("exchangedDate")) 'Fecha de Cobro Vale Origen
                    If FECCO <> String.Empty Then
                        '-----------------------------------------------------------------------------------------------
                        ' JNAVA (02.10.2016): Si la fecha de cobro es menor a la fecha actual, ponemos la fecha actual
                        '-----------------------------------------------------------------------------------------------
                        If CDate(FECCO) < Date.Now Then
                            oRow("OFECCO") = Date.Now.ToShortDateString
                        Else
                            '-------------------------------------------------------------------------------------------
                            ' De lo contrario, ponemos la fehca de cobro del vale origen
                            '-------------------------------------------------------------------------------------------
                            oRow("OFECCO") = CDate(FECCO).ToShortDateString
                        End If
                    Else
                        oRow("OFECCO") = String.Empty
                    End If
                    oRow("CODCT") = NoNulls(oParent("idCustomer"))
                    '------------------------------------------------------------------------------------
                Else
                    oRow("REVAL") = String.Empty
                    oRow("ZREVAL2") = String.Empty
                    oRow("Orige") = String.Empty
                    '------------------------------------------------------------------------------------
                    ' JNAVA (02.08.2016): Agregamos datos de Vale origen para validar Promociones
                    '------------------------------------------------------------------------------------
                    oRow("ONUMDE") = String.Empty
                    oRow("OFECCO") = String.Empty
                    '------------------------------------------------------------------------------------
                End If
                '----------------------------------------------------------------------------------------
                'FLIZARRAGA 21/04/2017: Se agrega información de DPSeguro en caso de que cuente con uno
                '----------------------------------------------------------------------------------------
                Dim beneficiario As New Dictionary(Of String, Object)
                Dim amortizations As List(Of Dictionary(Of String, Object))
                For Each item As Dictionary(Of String, Object) In oListaSeguros
                    oRow("LOANTERM") = item("loan_term")
                    If NoNulls(item("amortizations")).Trim() <> String.Empty Then
                        amortizations = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(item("amortizations").ToString())
                        Dim inicio As Boolean = False
                        Dim suma As Decimal = 0
                        Dim cuentaAmortizaciones As Integer = 0
                        For Each itAmort As Dictionary(Of String, Object) In amortizations
                            If inicio = False Then
                                If CDec(itAmort("amount")) <> 0 Then
                                    oRow("DATESTART") = CDate(itAmort("date"))
                                    inicio = True
                                End If
                            End If
                            If CDec(itAmort("amount")) <> 0 Then
                                oRow("AMOUNT") = CDec(itAmort("amount"))
                                suma += CDec(itAmort("amount"))
                                cuentaAmortizaciones += 1
                            End If
                            oRow("DATEEND") = CDate(itAmort("date"))
                        Next
                        oRow("CUENTAMORTIZACIONES") = cuentaAmortizaciones
                        oRow("MONTOAMORTIZACIONES") = suma
                    End If
                Next
                If purchases.Count > 0 Then
                    If purchases.ContainsKey("0") Then
                        Dim objInsurance As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(purchases("0").ToString())
                        oRow("INSURANCE") = CDec(objInsurance("insurance"))
                    End If
                End If
                '------------------------------------------------------------------------------
                'FLIZARRAGA 14/11/2017: Se obtiene la fecha del primer pago del vale
                '------------------------------------------------------------------------------
                For Each Item As Dictionary(Of String, Object) In oListaAmortizationPurchase
                    If CInt(Item("number")) = 1 Then
                        oRow("FECHAPRIMERPAGO") = CDate(Item("date"))
                    End If
                Next

                '------------------------------------------------------------------------------
                ' Agregamos datos a detalle
                '------------------------------------------------------------------------------
                dtInfoDPVALE.Rows.Add(oRow)
                dtInfoDPVALE.AcceptChanges()
                cdpvale.InfoDPVALE = dtInfoDPVALE
                If oVale.ContainsKey("id_charge_type") Then
                    If NoNulls(oVale("id_charge_type")).Trim() <> "" Then
                        cdpvale.EsElectronico = True
                        If NoNulls(oVale("id_charge_type")).Trim() = "1" Then
                            cdpvale.EsCalzado = True
                        Else
                            cdpvale.EsCalzado = False
                        End If
                    Else
                        cdpvale.EsElectronico = False
                        cdpvale.EsCalzado = False
                    End If
                Else
                    cdpvale.EsElectronico = False
                    cdpvale.EsCalzado = False
                End If
                If IsNumeric(cdpvale.INUMVA) Then
                    cdpvale.EsElectronico = False
                Else
                    cdpvale.EsElectronico = True
                End If
                If oVale.ContainsKey("enable_offer") Then
                    cdpvale.PromocionValeElectronico = CInt(NoNulls(oVale("enable_offer")))
                End If
                '------------------------------------------------------------------------------
                ' JNAVA (01.08.2016): Revisamos si existe el vale (0 = NO existe, 1 = Si existe)
                '------------------------------------------------------------------------------
                If CInt(NoNulls(oDPValeS2C("status")).Trim) = 1 Then
                    '------------------------------------------------------------------------------
                    ' Si existe, seteamos el dato correspondientes
                    '------------------------------------------------------------------------------
                    cdpvale.EEXIST = "S"

                    '------------------------------------------------------------------------------
                    ' Validamos si el estatus del vale
                    '------------------------------------------------------------------------------
                    Select Case CInt(NoNulls(oVale("status")))
                        Case 3 'Entregado (Es el principal y único para poder comprar)
                            cdpvale.ESTATU = "A"
                        Case 4
                            cdpvale.ESTATU = "E"
                        Case 5 'Cancelado
                            cdpvale.ESTATU = "C"
                        Case 6 'Usado
                            cdpvale.ESTATU = "U"
                        Case Else 'Otro status
                            cdpvale.ESTATU = "O"
                    End Select

                Else
                    '------------------------------------------------------------------------------
                    ' Si NO existe, seteamos los datos correspondientes
                    '------------------------------------------------------------------------------
                    cdpvale.EEXIST = "N"
                    cdpvale.ESTATU = ""
                    cdpvale.Congelado = ""
                End If
                '------------------------------------------------------------------------------

                '------------------------------------------------------------------------------
                ' JNAVA (26.07.2016): LLenamos informacion de la plaza y credito
                '------------------------------------------------------------------------------
                cdpvale.EPLAZA = NoNulls(oPlaza("code")).Trim
                If Not oCredito("current") Is Nothing Then
                    cdpvale.LimiteCredito = CDec(oCredito("current").ToString)
                Else
                    cdpvale.LimiteCredito = 0.0
                End If

                '------------------------------------------------------------------------------
                ' JNAVA (1.11.2016): Obtenemos los saldos disponibles para CALZADO
                '------------------------------------------------------------------------------
                Dim oAvailable As Dictionary(Of String, Object)
                If Not oCredito("availables") Is Nothing Then
                    oAvailable = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oCredito("availables").ToString())
                    If NoNulls(oAvailable("1")) = String.Empty Then ' 1 - calzado, 2 - Financiero
                        cdpvale.LimiteCreditoPrestamo = 0.0
                    Else
                        cdpvale.LimiteCreditoPrestamo = CDec(oAvailable("1").ToString)
                    End If
                Else
                    cdpvale.LimiteCreditoPrestamo = 0.0
                End If
                '------------------------------------------------------------------------------
                '
                'cdpvale.FlagPrestamo = oDPValeS2C("EPRESTAMO").ToString

            End If



        Catch ex As Exception
            Throw ex
        End Try

        Return cdpvale

    End Function

    '-------------------------------------------------------------------------------
    ' JNAVA (13.07.2016): Realiza Venta en S2Credit
    '-------------------------------------------------------------------------------    
    Public Function RealizarVenta(ByVal arDatosDPVale() As String, ByVal oDPValeSAP As cDPValeSAP, ByVal SeguroID As String, ByRef strMensaje As String, ByRef MontoSeguro As Dictionary(Of String, Object)) As String

        Dim CostoSeguro As Decimal = Decimal.Zero
        Dim oVentaS2C As Dictionary(Of String, Object)
        Dim VentaID As String = String.Empty

        Dim oResVenta As Dictionary(Of String, Object)
        Dim oSeguro As Dictionary(Of String, Object)

        Try

            '-------------------------------------------------------------------------------
            ' JNAVA (02.08.2016): Preparamos datos para la venta
            '-------------------------------------------------------------------------------
            oVentaS2C = New Dictionary(Of String, Object)
            oVentaS2C("customer") = CInt(arDatosDPVale(0)) 'cliente
            oVentaS2C("distributor") = CInt(arDatosDPVale(2)) 'Distribuidor
            oVentaS2C("idCoupon") = oDPValeSAP.IDDPVale
            oVentaS2C("date") = Format(Date.Today, "yyyy-MM-dd")
            oVentaS2C("couponAmount") = oDPValeSAP.MONTODPVALE.ToString("##,##0.00").Replace(",", "")
            oVentaS2C("purchaseAmount") = oDPValeSAP.MontoUtilizado.ToString("##,##0.00").Replace(",", "")
            oVentaS2C("idBranch") = ObtenerPlazaID(oAppSAPConfig.Plaza.Trim)
            oVentaS2C("idStore") = ObtenerTiendaID(oAppSAPConfig.Plaza.Trim, "T" & oAppContext.ApplicationConfiguration.Almacen.Trim) 'Confirmar
            If oConfigCierreFI.GenerarSeguro Then
                oVentaS2C("idInsurance") = ObtenerSeguroPorID(SeguroID, CostoSeguro) 'El seguro por default es 1
            Else
                oVentaS2C("idInsurance") = ""
            End If

            '-------------------------------------------------------------------------------
            ' JNAVA (03.08.2016): Calculamos el cargo quincenal del seguro
            '-------------------------------------------------------------------------------
            CostoSeguro = CostoSeguro * oDPValeSAP.NUMDE

            '-------------------------------------------------------------------------------
            ' JNAVA (03.08.2016): Preparamos detalle
            '-------------------------------------------------------------------------------
            Dim oPurchases As New List(Of Dictionary(Of String, Object))
            Dim oPurchase As Dictionary(Of String, Object)
            oPurchase = New Dictionary(Of String, Object)
            oPurchase.Add("chargeType", "1") ' Tipo de cargo (Calzado)
            oPurchase.Add("period", oDPValeSAP.NUMDE) ' Quincenas
            oPurchase.Add("amount", oDPValeSAP.MontoUtilizado.ToString("##,##0.00").Replace(",", "")) 'Monto utilizado 
            oPurchase.Add("interest", "") 'Intereses vacio (Solo financiero)
            If oConfigCierreFI.GenerarSeguro Then
                oPurchase.Add("insurance", CostoSeguro.ToString("##,##0.00").Replace(",", "")) ' Cargo quincenal del seguro
            Else
                oPurchase.Add("insurance", "") ' Cargo quincenal del seguro
            End If
            oPurchase.Add("firstDueDate", oDPValeSAP.FechaCobro.ToString("yyyy-MM-dd")) 'Fecha de cobro
            '---------------------------------------------------------------------------------------------------------
            ' JNAVA (04.04.2017): Agregamos el ID de la Promocion
            '---------------------------------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 16/05/2017: Se envia vacio cuando la promocion es diferente a compre hoy y pague despues
            '---------------------------------------------------------------------------------------------------------
            If oDPValeSAP.PromocionID.Trim() <> "" Then
                If oDPValeSAP.FechaCobro.Date > DateTime.Now.Date Then
                    oPurchase.Add("idOffer", oDPValeSAP.PromocionID.Trim)
                Else
                    oPurchase.Add("idOffer", "")
                End If
            Else
                oPurchase.Add("idOffer", "")
            End If


            '---------------------------------------------------------------------------------------------------------
            oPurchases.Add(oPurchase)
            oVentaS2C.Add("purchases", oPurchases)

            '-------------------------------------------------------------------------------
            ' Realizamos la venta
            '-------------------------------------------------------------------------------
            oResVenta = Me.Purchase(oVentaS2C)

            '-------------------------------------------------------------------------------
            ' JNAVA (02.08.2016): Validamos el resultado la venta
            '-------------------------------------------------------------------------------
            If Not oResVenta Is Nothing Then
                If oResVenta.ContainsKey("ErrorMessage") Then
                    Dim ErrorMessage As New Dictionary(Of String, Object)
                    Dim Mensaje As String = String.Empty
                    ErrorMessage = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oResVenta("ErrorMessage").ToString)

                    If ErrorMessage.ContainsKey("Mensaje") Then
                        strMensaje = CStr(ErrorMessage("Mensaje"))
                    ElseIf ErrorMessage.ContainsKey("msn") Then
                        strMensaje = CStr(ErrorMessage("msn"))
                    End If
                Else
                    '-------------------------------------------------------------------------------
                    ' JNAVA (04.08.2016): Revisamos si genero seguro
                    '-------------------------------------------------------------------------------
                    If NoNulls(oResVenta("insurancePeriods")).Trim <> String.Empty Then
                        Dim oSeguros As List(Of Dictionary(Of String, Object)) = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oResVenta("insurancePeriods").ToString())
                        oSeguro = oSeguros.Item(0)
                        VentaID = NoNulls(oSeguro("id_purchase")).Trim
                        '-----------------------------------------------------------------------------------
                        ' FLIZARRAGA 14/07/2017: Obtenemos las quincenas y los pagos quincenales a realizar
                        '-----------------------------------------------------------------------------------
                        MontoSeguro("loan_term") = NoNulls(oSeguro("loan_term")).Trim()
                        If NoNulls(oSeguro("amortizations")).Trim() <> String.Empty Then
                            Dim oListaSeguros As New List(Of Dictionary(Of String, Object))
                            Dim Monto As Decimal = 0
                            oListaSeguros = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oSeguro("amortizations").ToString())
                            Dim inicio As Boolean = False
                            Dim cuentaAmortizaciones As Integer = 0
                            For Each item As Dictionary(Of String, Object) In oListaSeguros
                                If inicio = False Then
                                    If CDec(item("amount")) <> 0 Then
                                        MontoSeguro("datestart") = CDate(item("date"))
                                        inicio = True
                                    End If
                                End If
                                If CDec(item("amount")) <> 0 Then
                                    MontoSeguro("amount") = CDec(item("amount"))
                                    Monto += CDec(item("amount"))
                                    cuentaAmortizaciones += 1
                                End If
                                MontoSeguro("dateend") = CDate(item("date"))
                            Next
                            MontoSeguro("CuentaAmortizaciones") = cuentaAmortizaciones
                            MontoSeguro("MontoAmortizaciones") = Monto
                        End If
                    End If
                    '-----------------------------------------------------------------------------------
                    ' FLIZARRAGA 14/07/2017: Obtenemos el monto total del seguro
                    '-----------------------------------------------------------------------------------
                    If oResVenta.ContainsKey("insurance") Then
                        If NoNulls(oResVenta("insurance")).Trim() <> String.Empty Then
                            MontoSeguro("insurance") = CDec(oResVenta("insurance"))
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return VentaID

    End Function

#Region "Seguros"

    '-------------------------------------------------------------------------------
    ' JNAVA (04.08.2016): Realiza Venta en S2Credit
    '-------------------------------------------------------------------------------    
    Public Function GuardarBeneficiario(ByVal VentaId As String, ByVal DatosBeneficiario As Dictionary(Of String, Object), ByRef strError As String) As Boolean

        Dim bResp As Boolean = False
        Dim PrimerNombre As String = String.Empty
        Dim SegundoNombre As String = String.Empty
        Try

            '-------------------------------------------------------------------------------
            ' Guardamos el Beneficiario
            '-------------------------------------------------------------------------------
            Dim oRespuesta As Dictionary(Of String, Object)
            GetNombres(DatosBeneficiario("Nombres").ToString, PrimerNombre, SegundoNombre)
            oRespuesta = Me.BeneficiaryChange(VentaId, DatosBeneficiario("ParentescoID").ToString, PrimerNombre, SegundoNombre, DatosBeneficiario("ApellidoPaterno"), DatosBeneficiario("ApellidoMaterno").ToString)

            '-------------------------------------------------------------------------------
            ' Validamos el resultado 
            '-------------------------------------------------------------------------------
            If Not oRespuesta Is Nothing Then

                If Not oRespuesta.ContainsKey("ErrorMessage") Then

                    '-------------------------------------------------------------------------------
                    ' Validamos si guardo el beneficiario o no
                    '-------------------------------------------------------------------------------
                    If NoNulls(oRespuesta("status")).Trim <> 1 Then
                        strError = NoNulls(oRespuesta("msn")).TrimEnd
                    Else
                        strError = String.Empty
                        bResp = True
                    End If

                Else

                    Dim ErrorMessage As New Dictionary(Of String, Object)
                    ErrorMessage = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oRespuesta("ErrorMessage").ToString)
                    strError = NoNulls(ErrorMessage("msn")).TrimEnd

                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return bResp

    End Function

    '----------------------------------------------------------------------------------------------------------
    ' JNAVA (04.08.2016): Obtiene los nombres del cliente (si son mas de 1)
    '----------------------------------------------------------------------------------------------------------
    Private Sub GetNombres(ByVal NombreCompleto As String, ByRef Nombre1 As String, ByRef nombre2 As String)
        Dim Nombres() As String = NombreCompleto.Split(" ")
        If Nombres.Length > 1 Then
            Nombre1 = ""
            For Each Nombre As String In Nombres
                If Nombre1 = "" Then
                    Nombre1 = Nombre
                Else
                    nombre2 &= Nombre & " "
                End If
            Next
            nombre2 = nombre2.TrimEnd
        Else
            Nombre1 = NombreCompleto
            nombre2 = String.Empty
        End If
    End Sub

#End Region

    '-------------------------------------------------------------------------------
    ' JNAVA (05.08.2016): Obtenemos Beneficiario S2Credit por DPValeID
    '-------------------------------------------------------------------------------
    Public Function ObtenerBeneficiarioSeguro(ByVal DPValeID As String, ByRef FechaCobro As Date) As String

        Dim strBeneficiario As String = String.Empty

        Dim oDPValeS2C As Dictionary(Of String, Object)
        Dim oListaSeguros As List(Of Dictionary(Of String, Object))
        Dim oBeneficiario As Dictionary(Of String, Object)
        Dim oAmortizaciones As List(Of Dictionary(Of String, Object))

        Try

            '-------------------------------------------------------------------------------
            ' Consumimos el servicio de S2Credit
            '-------------------------------------------------------------------------------
            oDPValeS2C = Me.CouponSearch(DPValeID)

            '-------------------------------------------------------------------------------
            '  Validamos respuesta
            '-------------------------------------------------------------------------------
            If Not oDPValeS2C Is Nothing Then

                '------------------------------------------------------------------------------
                ' Obtenemos datos y validamos
                '------------------------------------------------------------------------------
                If NoNulls(oDPValeS2C("insurance")).Trim <> String.Empty Then

                    oListaSeguros = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oDPValeS2C("insurance").ToString())
                    For Each oSeguro As Dictionary(Of String, Object) In oListaSeguros

                        If NoNulls(oSeguro("beneficiary")).Trim <> String.Empty Then
                            oBeneficiario = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oSeguro("beneficiary").ToString())
                            strBeneficiario = NoNulls(oBeneficiario("name")).TrimEnd & ", " & ObtenerParentescoPorID(NoNulls(oBeneficiario("id_relationship")).Trim).TrimEnd & " - 100%"
                            Exit For
                        End If

                        '---------------------------------------------------------------------------------------------------------------------------------------
                        ' JNAVA (07.11.2016): Obtenemos tambien la fecha de cobro del vale para el seguro de vida
                        '---------------------------------------------------------------------------------------------------------------------------------------
                        If NoNulls(oSeguro("amortizations")).Trim <> String.Empty Then
                            oAmortizaciones = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oDPValeS2C("amortizations").ToString())
                            For Each oAmortizacion As Dictionary(Of String, Object) In oAmortizaciones
                                FechaCobro = CDate(NoNulls(oAmortizacion("date"))).ToShortDateString
                                Exit For
                            Next
                            Exit For
                        End If
                        '---------------------------------------------------------------------------------------------------------------------------------------

                    Next

                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return strBeneficiario

    End Function

    '-------------------------------------------------------------------------------
    ' JNAVA (15.09.2016): Realiza Venta de SH en S2Credit
    '-------------------------------------------------------------------------------    
    Public Function RealizarVentaSH(ByVal oDPValeSAP As VentasFacturaSAP, ByVal SeguroID As String, ByRef strMensaje As String, Optional ByRef MontoSeguro As Dictionary(Of String, Object) = Nothing) As String

        Dim CostoSeguro As Decimal = Decimal.Zero
        Dim oVentaS2C As Dictionary(Of String, Object)
        Dim VentaID As String = String.Empty

        Dim oResVenta As Dictionary(Of String, Object)
        Dim oSeguro As Dictionary(Of String, Object)

        Try

            '-------------------------------------------------------------------------------
            ' JNAVA (02.08.2016): Preparamos datos para la venta
            '-------------------------------------------------------------------------------
            oVentaS2C = New Dictionary(Of String, Object)
            oVentaS2C("customer") = CInt(oDPValeSAP.CodigoCliente) 'cliente
            oVentaS2C("distributor") = CInt(oDPValeSAP.ClienteDistribuidor) 'Distribuidor
            oVentaS2C("idCoupon") = oDPValeSAP.NumeroVale
            oVentaS2C("date") = Format(Date.Today, "yyyy-MM-dd")
            oVentaS2C("couponAmount") = oDPValeSAP.MontoDPVale.ToString("##,##0.00").Replace(",", "")
            oVentaS2C("purchaseAmount") = oDPValeSAP.MONTOUTILIZADO.ToString("##,##0.00").Replace(",", "")
            oVentaS2C("idBranch") = ObtenerPlazaID(oAppSAPConfig.Plaza.Trim)
            oVentaS2C("idStore") = ObtenerTiendaID(oAppSAPConfig.Plaza.Trim, "T" & oAppContext.ApplicationConfiguration.Almacen.Trim) 'Confirmar
            If oConfigCierreFI.GenerarSeguro Then
                oVentaS2C("idInsurance") = ObtenerSeguroPorID(SeguroID, CostoSeguro) 'El seguro por default es 1
            Else
                oVentaS2C("idInsurance") = ""
            End If

            '-------------------------------------------------------------------------------
            ' JNAVA (03.08.2016): Calculamos el cargo quincenal del seguro
            '-------------------------------------------------------------------------------
            CostoSeguro = CostoSeguro * oDPValeSAP.NUMDE

            '-------------------------------------------------------------------------------
            ' JNAVA (03.08.2016): Preparamos detalle
            '-------------------------------------------------------------------------------
            Dim oPurchases As New List(Of Dictionary(Of String, Object))
            Dim oPurchase As Dictionary(Of String, Object)
            oPurchase = New Dictionary(Of String, Object)
            oPurchase.Add("chargeType", "1") ' Tipo de cargo (Calzado)
            oPurchase.Add("period", oDPValeSAP.NUMDE) ' Quincenas
            oPurchase.Add("amount", oDPValeSAP.MONTOUTILIZADO.ToString("##,##0.00").Replace(",", "")) 'Monto utilizado 
            oPurchase.Add("interest", "") 'Intereses vacio (Solo financiero)
            If oConfigCierreFI.GenerarSeguro Then
                oPurchase.Add("insurance", CostoSeguro.ToString("##,##0.00").Replace(",", "")) ' Cargo quincenal del seguro
            Else
                oPurchase.Add("insurance", "") ' Cargo quincenal del seguro
            End If
            oPurchase.Add("firstDueDate", oDPValeSAP.FechaCobroDPVL.ToString("yyyy-MM-dd")) 'Fecha de cobro
            '---------------------------------------------------------------------------------------------------------
            ' JNAVA (04.04.2017): Agregamos el ID de la Promocion
            '---------------------------------------------------------------------------------------------------------
            If oDPValeSAP.PromocionID.Trim() <> "" Then
                If oDPValeSAP.FechaCobroDPVL.Date > DateTime.Now.Date Then
                    oPurchase.Add("idOffer", oDPValeSAP.PromocionID.Trim)
                Else
                    oPurchase.Add("idOffer", "")
                End If
            Else
                oPurchase.Add("idOffer", "")
            End If
            '---------------------------------------------------------------------------------------------------------
            oPurchases.Add(oPurchase)

            oVentaS2C.Add("purchases", oPurchases)

            '-------------------------------------------------------------------------------
            ' Realizamos la venta
            '-------------------------------------------------------------------------------
            oResVenta = Me.Purchase(oVentaS2C)

            '-------------------------------------------------------------------------------
            ' JNAVA (02.08.2016): Validamos el resultado la venta
            '-------------------------------------------------------------------------------
            If Not oResVenta Is Nothing Then
                If oResVenta.ContainsKey("ErrorMessage") Then
                    Dim ErrorMessage As New Dictionary(Of String, Object)
                    Dim Mensaje As String = String.Empty
                    ErrorMessage = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oResVenta("ErrorMessage").ToString)

                    If ErrorMessage.ContainsKey("Mensaje") Then
                        strMensaje = CStr(ErrorMessage("Mensaje"))
                    ElseIf ErrorMessage.ContainsKey("msn") Then
                        strMensaje = CStr(ErrorMessage("msn"))
                    End If
                Else
                    '-------------------------------------------------------------------------------
                    ' FLIZARRAGA 19/05/2017: Obtenemos los montos del seguro en dado caso que genere
                    '-------------------------------------------------------------------------------
                    If NoNulls(oResVenta("insurancePeriods")).Trim <> String.Empty Then
                        If MontoSeguro Is Nothing Then
                            MontoSeguro = New Dictionary(Of String, Object)
                        End If
                        Dim oSeguros As List(Of Dictionary(Of String, Object)) = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oResVenta("insurancePeriods").ToString())
                        oSeguro = oSeguros.Item(0)
                        VentaID = NoNulls(oSeguro("id_purchase")).Trim
                        MontoSeguro("loan_term") = NoNulls(oSeguro("loan_term")).Trim()
                        If NoNulls(oSeguro("amortizations")).Trim() <> String.Empty Then
                            Dim oListaSeguros As New List(Of Dictionary(Of String, Object))
                            Dim Monto As Decimal = 0
                            oListaSeguros = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oSeguro("amortizations").ToString())
                            Dim inicio As Boolean = False
                            Dim cuentaAmortizaciones As Integer = 0
                            For Each item As Dictionary(Of String, Object) In oListaSeguros
                                If inicio = False Then
                                    If CDec(item("amount")) <> 0 Then
                                        MontoSeguro("datestart") = CDate(item("date"))
                                        inicio = True
                                    End If
                                End If
                                If CDec(item("amount")) <> 0 Then
                                    MontoSeguro("amount") = CDec(item("amount"))
                                    Monto += CDec(item("amount"))
                                    cuentaAmortizaciones += 1
                                End If
                                MontoSeguro("dateend") = CDate(item("date"))
                            Next
                            MontoSeguro("CuentaAmortizaciones") = cuentaAmortizaciones
                            MontoSeguro("MontoAmortizaciones") = Monto
                        End If
                    End If
                    If oResVenta.ContainsKey("insurance") Then
                        If NoNulls(oResVenta("insurance")).Trim() <> String.Empty Then
                            MontoSeguro("insurance") = CDec(oResVenta("insurance"))
                        End If
                    End If

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return VentaID

    End Function


#End Region

#Region "Devoluciones"

    '------------------------------------------------------------------------------------------
    ' JNAVA (15.07.2016): Genera Revale en S2Credit
    '------------------------------------------------------------------------------------------
    Public Function GeneraReVale(ByVal DPValeID As String, ByVal ClienteDPVale As String, ByRef MontoDPVale As Decimal, ByRef strResult As String, Optional ByVal EsFacturacion As Boolean = False) As String

        Dim strRevale As String = String.Empty
        Try

            '------------------------------------------------------------------------------------------
            ' Generamos Revale a partir del Vale Original
            '------------------------------------------------------------------------------------------
            Dim oReValeS2C As Dictionary(Of String, Object)
            oReValeS2C = NewCoupon(DPValeID, ClienteDPVale, MontoDPVale, EsFacturacion)

            '------------------------------------------------------------------------------------------
            ' JNAVA (21.07.2016): Obtenemos datos
            '------------------------------------------------------------------------------------------
            If Not oReValeS2C Is Nothing Then
                Dim oVale As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oReValeS2C("coupon").ToString())
                '------------------------------------------------------------------------------------------
                ' JNAVA (21.07.2016): Validamos que el revale se haya creado para devolver resultados
                '------------------------------------------------------------------------------------------
                If oReValeS2C("status") = 1 Then
                    strResult = "S"
                    strRevale = oVale("id").ToString
                Else
                    EscribeLog("Status: " & oReValeS2C("status") & vbCrLf & "Mensaje: " & oReValeS2C("msn"), "El REVALE no se genero.")
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return strRevale

    End Function

    '-----------------------------------------------------
    ' JNAVA (18.07.2016): Genera Devolucion en S2Credit
    '-----------------------------------------------------
    Public Function GeneraDevolucion(ByVal DPValeID As String, ByVal DistribuidorID As String, ByVal MontoDPVale As Decimal) As String

        Dim strResult As String = String.Empty

        Try

            '-----------------------------------------------------
            ' Generamos Revale a partir del Vale Original
            '-----------------------------------------------------
            Dim oDevolucionS2C As Dictionary(Of String, Object)
            oDevolucionS2C = Devolution(DPValeID, DistribuidorID, MontoDPVale)

            If Not oDevolucionS2C Is Nothing Then

                '-----------------------------------------------------
                ' JNAVA (29.07.2016): Obtenemos resultado
                '-----------------------------------------------------
                If oDevolucionS2C.ContainsKey("ErrorMessage") Then
                    '-----------------------------------------------------
                    ' JNAVA (01.08.2016): Obtenemos resultado
                    '-----------------------------------------------------
                    Dim ErrorMessage As New Dictionary(Of String, Object)
                    ErrorMessage = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDevolucionS2C("ErrorMessage").ToString)
                    strResult = NoNulls(ErrorMessage("msn")).TrimEnd
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return strResult

    End Function

    '-----------------------------------------------------
    ' JNAVA (05.08.2016): Genera Devolucion en S2Credit
    '-----------------------------------------------------
    Public Function ValidaDevoluciones(ByVal DPValeID As String) As String

        Dim strDevoluciones As String = String.Empty

        Dim oDPValeS2C As Dictionary(Of String, Object)
        Dim oDevolutions As DataTable

        Try

            '-------------------------------------------------------------------------------
            ' Consumimos el servicio de S2Credit
            '-------------------------------------------------------------------------------
            oDPValeS2C = Me.CouponSearch(DPValeID)

            '-------------------------------------------------------------------------------
            '  Validamos respuesta
            '-------------------------------------------------------------------------------
            If Not oDPValeS2C Is Nothing Then

                '------------------------------------------------------------------------------
                ' Obtenemos datos y validamos
                '------------------------------------------------------------------------------
                If NoNulls(oDPValeS2C("devolutions")).Trim <> String.Empty Then

                    oDevolutions = JsonConvert.DeserializeObject(Of DataTable)(oDPValeS2C("devolutions").ToString())
                    strDevoluciones = String.Empty

                    For Each oRow As DataRow In oDevolutions.Rows
                        strDevoluciones &= " - Monto: " & NoNulls(oRow("amount")) & " - Fecha: " & CDate(NoNulls(oRow("date"))).ToShortDateString & vbCrLf
                    Next

                    strDevoluciones = strDevoluciones.TrimEnd

                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return strDevoluciones

    End Function

#End Region

#Region "Clientes"

    '-------------------------------------------------------------------
    ' JNAVA (11.07.2016):  Valida/Busca cliente en S2Credit por nombre
    '-------------------------------------------------------------------
    Public Function ObtenerCliente(ByVal NombreCliente As String, Optional GrupoCuentas As String = "") As DataTable

        Dim oClientes As List(Of Dictionary(Of String, Object)) 'DataTable
        Dim dtClientesS2Credit As New DataTable

        Try

            oClientes = SearchCustomers(NombreCliente)

            dtClientesS2Credit = New DataTable
            dtClientesS2Credit.Columns.Add("KUNNR")
            dtClientesS2Credit.Columns.Add("NAME1")
            dtClientesS2Credit.Columns.Add("NAME2")
            dtClientesS2Credit.Columns.Add("KTOKD")
            dtClientesS2Credit.AcceptChanges()

            If Not oClientes Is Nothing Then

                Dim oNewRow As DataRow
                Dim NombreCompleto As String = String.Empty
                Try
                    For Each oCliente As Dictionary(Of String, Object) In oClientes

                        '-----------------------------------------------------------------------
                        ' JNAVA (22.07.2016): Validamos Obtenemos el nombre completo
                        '-----------------------------------------------------------------------
                        oCliente("middleName") = NoNulls(oCliente("middleName"))
                        oCliente("secondLastName") = NoNulls(oCliente("secondLastName"))

                        NombreCompleto = oCliente("name").ToString.TrimEnd & " " & oCliente("middleName").ToString.TrimEnd
                        NombreCompleto = NombreCompleto.TrimEnd & " " & oCliente("lastName").ToString.TrimEnd & " " & oCliente("secondLastName").ToString.TrimEnd

                        '------------------------------------------
                        ' Obtenemos los demas dato
                        '------------------------------------------
                        oNewRow = dtClientesS2Credit.NewRow
                        oNewRow("KUNNR") = oCliente("id").ToString.PadLeft(10, "0")
                        oNewRow("NAME1") = NombreCompleto.TrimEnd
                        oNewRow("NAME2") = "" 'oRow("lastName").ToString & " " & oRow("secondLastName").ToString
                        oNewRow("KTOKD") = GrupoCuentas.Trim
                        dtClientesS2Credit.Rows.Add(oNewRow)

                    Next

                    dtClientesS2Credit.AcceptChanges()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                

            End If

            Return dtClientesS2Credit

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '------------------------------------------------------------------------------------
    ' JNAVA (07.07.2016):  Valida/Busca cliente en S2Credit por ID
    '------------------------------------------------------------------------------------
    Public Function ObtenerClientePorID(ByVal ClienteID As String, Optional ByRef ValidacionCliente As Hashtable = Nothing) As ClientesSAP

        Try

            Dim oClientes As New List(Of Dictionary(Of String, Object))
            Dim oClienteSAP As New ClientesSAP

            '------------------------------------------------------------------------------------
            ' Buscamos al cliente
            '------------------------------------------------------------------------------------
            oClientes = SearchCustomers(ClienteID.TrimStart("0"))
            If Not oClientes Is Nothing Then

                For Each oCliente As Dictionary(Of String, Object) In oClientes

                    '-------------------------------------------------------------------------------
                    ' JNAVA(20.07.2016): Obtenemos los datos del Cliente
                    '-------------------------------------------------------------------------------
                    With oClienteSAP

                        .Clienteid = oCliente("id").ToString.PadLeft(10, "0")

                        '-----------------------------------------------------------------------
                        ' JNAVA (22.07.2016): Validamos Obtenemos el nombre completo
                        '-----------------------------------------------------------------------
                        oCliente("middleName") = NoNulls(oCliente("middleName"))
                        oCliente("secondLastName") = NoNulls(oCliente("secondLastName"))

                        .Nombre = oCliente("name").ToString.ToUpper.TrimEnd & " " & oCliente("middleName").ToString.ToUpper.TrimEnd
                        .Apellidos = oCliente("lastName").ToString.ToUpper.TrimEnd & " " & oCliente("secondLastName").ToString.ToUpper.TrimEnd

                        '-------------------------------------------------------------------------------
                        ' JNAVA (22.07.2016): Obtenemos Sexo del cliente
                        '-------------------------------------------------------------------------------
                        Select Case CInt(oCliente("gender"))
                            Case 1
                                .Sexo = "M"
                            Case Else
                                .Sexo = "F"
                        End Select

                        '-------------------------------------------------------------------------------
                        ' MLVARGAS (03.10.2019): Validar que la sección de address traiga información
                        '-------------------------------------------------------------------------------
                        If oCliente.ContainsKey("address") Then
                            If oCliente("address").ToString.Length > 10 Then

                                '-------------------------------------------------------------------------------
                                ' JNAVA (22.07.2016): Obtenemos la direccion del cliente
                                '-------------------------------------------------------------------------------
                                Dim oDireccion As New Dictionary(Of String, Object)
                                oDireccion = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oCliente("address").ToString)

                                .Domicilio = oDireccion("street").ToString.ToUpper
                                .NumeroExterior = NoNulls(oDireccion("house_number"))
                                .NumeroInterior = NoNulls(oDireccion("apartment_number"))
                                .Colonia = NoNulls(oDireccion("neighborhood")).ToUpper
                                .Cp = NoNulls(oDireccion("zipcode")).ToUpper
                                '-------------------------------------------------------------------------------
                                ' JNAVA (18.01.2017): Se cambio de ciudad a municipio
                                '-------------------------------------------------------------------------------
                                If Not oDireccion("settlement") Is Nothing Then
                                    .Ciudad = QuitarSignos(oDireccion("settlement").ToString.ToUpper)
                                Else
                                    .Ciudad = ""
                                End If
                                '-------------------------------------------------------------------------------
                                Dim estado As String = NoNulls(oDireccion("state"))
                                .Estado = BuscaEstado(estado.ToUpper, String.Empty)

                                oDireccion = Nothing
                                '-------------------------------------------------------------------------------
                            Else
                                .Domicilio = ""
                                .NumeroExterior = ""
                                .NumeroInterior = ""
                                .Colonia = ""
                                .Cp = ""
                                .Ciudad = ""
                                .Estado = ""
                                '-------------------------------------------------------------------------------                                
                            End If
                        End If

                        
                        '-------------------------------------------------------------------------------
                        ' JNAVA (22.07.2016): Obtenemos el telefono del cliente
                        '-------------------------------------------------------------------------------
                        Dim oTelefonos As New List(Of Dictionary(Of String, Object))
                        oTelefonos = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oCliente("phones").ToString())
                        For Each oTelefono As Dictionary(Of String, Object) In oTelefonos
                            If oTelefono("current").ToString = "1" Then
                                .Telefono = oTelefono("number").ToString.ToUpper
                                Exit For
                            End If
                        Next

                        '-------------------------------------------------------------------------------
                        ' JNAVA (22.07.2016): Obtenemos el estado civil del cliente
                        '-------------------------------------------------------------------------------
                        Select Case CInt(oCliente("maritalStatus"))
                            Case 1
                                .Estadocivil = "SOLTERO(A)"
                            Case Else
                                .Estadocivil = "CASADO(A)"
                        End Select

                        '-------------------------------------------------------------------------------
                        ' JNAVA (20.07.2016): Obtenemos la fecha de nacimiento del cliente
                        '-------------------------------------------------------------------------------
                        If oCliente("birthdate") Is Nothing Then
                            .Fechanac = Now.Date.ToShortDateString
                        Else
                            .Fechanac = CDate(oCliente("birthdate").ToString)
                        End If

                        '-------------------------------------------------------------------------------
                        ' JNAVA (20.07.2016): Obtenemos el mail del cliente
                        '-------------------------------------------------------------------------------
                        .Email = NoNulls(oCliente("email")).ToUpper

                        '-------------------------------------------------------------------------------
                        ' JNAVA (22.07.2016): obtenemos la fecha de creacion del cliente
                        '-------------------------------------------------------------------------------
                        If oCliente("registerDate") Is Nothing Then
                            .Fecha = Now.Date.ToShortDateString
                        Else
                            .Fecha = CDate(oCliente("registerDate").ToString)
                        End If

                        '-------------------------------------------------------------------------------
                        ' JNAVA (22.07.2016): obtenemos la RFC de creacion del cliente
                        '-------------------------------------------------------------------------------
                        .RFC = NoNulls(oCliente("rfc")).ToUpper

                        .TipoVenta = "V"

                        .ClaveAnterior = String.Empty
                        .Codalmacen = String.Empty
                        .CodPlaza = String.Empty
                        .Usuario = String.Empty
                        .Player = String.Empty
                        .Status = CInt(oCliente("status"))
                        .Statusregistro = True

                    End With

            	Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            	oSAPMgr.Write_Clientes(oClienteSAP)
            	oSAPMgr = Nothing

            	Exit For

                Next
            Else
            	oClienteSAP = Nothing
            End If

            Return oClienteSAP

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '------------------------------------------------------------------------------------
    ' JNAVA (22.07.2016):  Obtiene el Codigo del Estado o la descripcion
    '------------------------------------------------------------------------------------
    Private Function BuscaEstado(ByVal NombreEstado As String, ByVal CodEstado As String) As String

        Dim dtEstados As DataTable
        Dim oClienteMgr As New ClientesManager(oAppContext, oAppSAPConfig)
        Dim Respuesta As String = String.Empty

        '------------------------------------------------------------------------------------
        ' Obtenemos todos los estados
        '------------------------------------------------------------------------------------
        dtEstados = oClienteMgr.GetAllStates(False)

        '------------------------------------------------------------------------------------
        ' Verificamos si buscaremos por Codigo Estado o Descripcion
        '------------------------------------------------------------------------------------
        Dim CampoBuscar As String, CampoRespuesta As String, Valor As String
        If CodEstado Is String.Empty Then
            CampoBuscar = "Descripcion"
            Valor = QuitarSignos(NombreEstado)
            CampoRespuesta = "CodEstado"
        Else
            CampoBuscar = "CodEstado"
            Valor = CodEstado
            CampoRespuesta = "Descripcion"
        End If

        '------------------------------------------------------------------------------------
        ' Hacemos la busqueda
        '------------------------------------------------------------------------------------
        For Each oRow As DataRow In dtEstados.Rows
            If oRow(CampoBuscar) = Valor.TrimEnd Then
                Respuesta = oRow(CampoRespuesta).ToString
                Exit For
            End If
        Next

        Return Respuesta

    End Function

    '------------------------------------------------------------------------------------
    ' JNAVA (29.07.2016):  Valida si el clietne esta congelado o adeuda un vale
    '------------------------------------------------------------------------------------
    Public Function ValidaCliente(ByVal ClienteID As String, Optional ByRef Adeuda As Boolean = False) As String
        Dim strMensaje As String = String.Empty
        Dim oClientes As New List(Of Dictionary(Of String, Object))

        Try
            '------------------------------------------------------------------------------------
            ' Buscamos al cliente
            '------------------------------------------------------------------------------------
            oClientes = SearchCustomers(CInt(ClienteID))
            If Not oClientes Is Nothing Then
                Dim strAdeuda As String = String.Empty
                For Each oCliente As Dictionary(Of String, Object) In oClientes
                    Adeuda = CBool(NoNulls(oCliente("hasLoan")).Trim)
                    If NoNulls(oCliente("status")).Trim <> "1" Then
                        strMensaje = "Cliente congelado"
                    End If
                    Exit For
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return strMensaje

    End Function

    '------------------------------------------------------------------------------------
    ' MLVARGAS (14.12.2020):  Obtener el saldo disponible del cliente
    '------------------------------------------------------------------------------------
    Public Function ObtenerDisponibleCliente(ByVal ClienteID As String, ByRef Limite As Boolean) As Decimal
        Dim oClientes As New List(Of Dictionary(Of String, Object))
        Dim saldo As Decimal = 0

        Limite = False
        Try
            '------------------------------------------------------------------------------------
            ' Buscamos al cliente
            '------------------------------------------------------------------------------------
            oClientes = SearchCustomers(CInt(ClienteID))
            If Not oClientes Is Nothing Then
                For Each oCliente As Dictionary(Of String, Object) In oClientes
                    If Not oCliente("customer_limit") Is Nothing Then
                        saldo = CDec(NoNulls(oCliente("customer_available")).Trim)
                        Limite = True
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return saldo
    End Function

    '---------------------------------------------------------------------------------------------------
    ' MLVARGAS (14.12.2020) Obtener el saldo disponible de coupon-search
    '---------------------------------------------------------------------------------------------------
    Public Function ObtenerSaldoDisponible(ByVal DPVale As String) As Double
        Dim oDPValeS2C As Dictionary(Of String, Object)
        Dim oListaCredit As Dictionary(Of String, Object)
        Dim oAvailables As Dictionary(Of String, Object)
        Dim total As Double = 0

        Try
            '-------------------------------------------------------------------------------
            ' Consumimos el servicio de S2Credit
            '-------------------------------------------------------------------------------
            oDPValeS2C = Me.CouponSearch(DPVale)
            '-------------------------------------------------------------------------------
            '  Validamos respuesta
            '-------------------------------------------------------------------------------
            If Not oDPValeS2C Is Nothing Then
                If NoNulls(oDPValeS2C("credit")).Trim <> String.Empty Then

                    oListaCredit = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("credit").ToString)
                    If NoNulls(oListaCredit("availables")).Trim <> String.Empty Then
                        oAvailables = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oListaCredit("availables").ToString())
                        total = oAvailables("2")
                    End If

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return total

    End Function


#End Region

#Region "Consultas a Catalogos"

    '----------------------------------------------------------------------------------------------------------
    ' JNAVA (22.07.2016): Buscamos el CP para obtener las direcciones en S2Credit
    '----------------------------------------------------------------------------------------------------------
    Public Function ConsultarCodigoPostal(ByVal CodigoPostal As String) As DataTable

        Dim oCodigoPostal As New DataTable
        Dim oDatosCP As New Dictionary(Of String, Object) 'ArraySepomex

        '-----------------------------------------------------
        ' Obtenemos los datos del CP en S2Credit
        '-----------------------------------------------------
        oCodigoPostal = Sepomex(CodigoPostal.Trim)

        If Not oCodigoPostal Is Nothing AndAlso oCodigoPostal.Rows.Count > 0 Then

            '---------------------------------------------------------
            ' Si se obtuvo informacion, comparamos con lo capturado
            '---------------------------------------------------------
            For Each oSepomex As DataRow In oCodigoPostal.Rows
                oSepomex("state") = QuitarSignos(oSepomex("state").ToString()).ToUpper
                oSepomex("city") = QuitarSignos(oSepomex("city").ToString()).ToUpper
                oSepomex("settlement") = QuitarSignos(oSepomex("settlement").ToString()).ToUpper
                oSepomex("neighborhood") = QuitarSignos(oSepomex("neighborhood").ToString()).ToUpper
            Next

        End If

        Return oCodigoPostal

    End Function

    '-----------------------------------------------------
    ' JNAVA (26.07.2016): Obtener Promociones para Venta 
    '-----------------------------------------------------
    Public Function ObtenerPromociones(ByVal plaza As String, ByVal fecha As Date, ByVal monto As Decimal, ByVal strVale As String, _
                                       ByRef FechaCobro As Date, ByRef dtDetalle As DataTable) As Integer

        Dim intQuincenas As Integer
        Try

            '----------------------------------------------------------------------------------------------------------
            ' Preparamos datos para obtener las promociones
            '----------------------------------------------------------------------------------------------------------
            Dim PlazaID As String = String.Empty
            PlazaID = ObtenerPlazaID(oAppSAPConfig.Plaza)

            '----------------------------------------------------------------------------------------------------------
            ' JNAVA (28.07.2016): Validamos DPVale para saber si es Revale y asi obtener las promociones del original
            '----------------------------------------------------------------------------------------------------------
            If strVale.Trim <> String.Empty Then
                Dim oDPV As New cDPVale
                oDPV.INUMVA = strVale.PadLeft(10, "0")
                oDPV = Me.ValidaDPVale(oDPV, Nothing, String.Empty)

                '----------------------------------------------------------------------------------------------------------
                ' JNAVA (02.08.2016): 
                '----------------------------------------------------------------------------------------------------------
                If oDPV.InfoDPVALE.Rows(0).Item("Orige") <> String.Empty Then
                    intQuincenas = CInt(oDPV.InfoDPVALE.Rows(0).Item("ONUMDE"))
                    FechaCobro = CDate(oDPV.InfoDPVALE.Rows(0).Item("OFECCO"))
                    Return intQuincenas
                    Exit Function
                End If

            End If
            '----------------------------------------------------------------------------------------------------------

            '----------------------------------------------------------------------------------------------------------
            ' Obtener las promociones
            '----------------------------------------------------------------------------------------------------------
            Dim oPromociones As DataTable
            oPromociones = Offers(PlazaID, monto, fecha)

            '----------------------------------------------------------------------------------------------------------
            ' Validamos resultados
            '----------------------------------------------------------------------------------------------------------
            If Not oPromociones Is Nothing AndAlso oPromociones.Rows.Count > 0 Then

                '----------------------------------------------------------------------------------------------------------
                ' JNAVA (28.07.2016): Obtenemos la promocion por default (la de mayor quincenas)
                '----------------------------------------------------------------------------------------------------------
                oPromociones.DefaultView.Sort = "term ASC"
                intQuincenas = CInt(NoNulls(oPromociones.DefaultView(0).Item("term")))
                Dim FECCO As Date = CDate(NoNulls(oPromociones.DefaultView(0).Item("promo_date")))
                If Not (FECCO > Date.Now) Then
                    FechaCobro = Date.Today.Date
                End If

                '----------------------------------------------------------------------------------------------------------
                ' JNAVA (27.07.2016): Creamos la tabla con el detalle
                '----------------------------------------------------------------------------------------------------------
                Dim dtPeriodos As New DataTable
                dtPeriodos.Columns.Add("NUMDE")
                dtPeriodos.Columns.Add("FECCO")
                '----------------------------------------------------------------------------------------------------------
                ' JNAVA (04.04.2017): ID de la Promoción
                '----------------------------------------------------------------------------------------------------------
                dtPeriodos.Columns.Add("PromocionID")
                '----------------------------------------------------------------------------------------------------------
                dtPeriodos.AcceptChanges()

                Dim oNewRow As DataRow
                For Each oRowPeriodo As DataRow In oPromociones.Rows

                    '------------------------------------------------------------------------------
                    ' JNAVA (27.07.2016): Llenamos informacion con todas las promociones que hay
                    '------------------------------------------------------------------------------
                    oNewRow = dtPeriodos.NewRow
                    oNewRow("NUMDE") = NoNulls(oRowPeriodo("term"))

                    '----------------------------------------------------------------------------------------------------------
                    ' JNAVA (28.07.2016): Obtenemos la fecha de cobro
                    '----------------------------------------------------------------------------------------------------------
                    Dim strFecha As String = NoNulls(oRowPeriodo("promo_date"))
                    If Not (CDate(strFecha) > Date.Now) Then
                        oNewRow("FECCO") = String.Empty.PadLeft(8, "0")
                    Else
                        oNewRow("FECCO") = CDate(strFecha).ToString("yyyyMMdd")
                    End If

                    '----------------------------------------------------------------------------------------------------------
                    ' JNAVA (04.04.2017): Agregamos ID de la Promoción
                    '----------------------------------------------------------------------------------------------------------
                    oNewRow("PromocionID") = NoNulls(oRowPeriodo("id_offer"))
                    '----------------------------------------------------------------------------------------------------------

                    dtPeriodos.Rows.Add(oNewRow)
                    dtPeriodos.AcceptChanges()

                Next

                '------------------------------------------------------------------------------
                ' JNAVA (27.07.2016): Seteamos tabla de talle con todas las promociones
                '------------------------------------------------------------------------------
                dtDetalle = dtPeriodos.Copy
                dtDetalle.AcceptChanges()

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return intQuincenas

    End Function

    '----------------------------------------------------------------------------------------------------------
    ' JNAVA (26.07.2016): Buscamos el id de la Plaza para enviarlas en la Venta
    '----------------------------------------------------------------------------------------------------------
    Public Function ObtenerPlazaID(ByVal Plaza As String) As String

        Dim PlazaID As String = String.Empty
        Dim oDatosPlaza As DataTable

        '-----------------------------------------------------
        ' Obtenemos los datos de la plaza en S2Credit
        '-----------------------------------------------------
        oDatosPlaza = Branches()

        If Not oDatosPlaza Is Nothing AndAlso oDatosPlaza.Rows.Count > 0 Then

            '---------------------------------------------------------
            ' Si se obtuvo informacion, comparamos con lo capturado
            '---------------------------------------------------------
            For Each oPlaza As DataRow In oDatosPlaza.Rows
                If Plaza.Trim = oPlaza("code").ToString.Trim Then
                    PlazaID = oPlaza("id").ToString
                    Exit For
                End If
            Next

        End If

        Return PlazaID.Trim

    End Function

    '-----------------------------------------------------
    ' JNAVA (27.07.2016): Obtener Promociones para Venta 
    '-----------------------------------------------------
    Private Function ObtenerPromocionID(ByVal Quincenas As String, ByVal Plaza As String, ByVal Monto As Decimal, ByVal Fecha As Date) As String

        Dim PromocionID As String = String.Empty

        Try

            '----------------------------------------------------------------------------------------------------------
            ' Preparamos datos para obtener las promociones
            '----------------------------------------------------------------------------------------------------------
            Dim PlazaID As String = String.Empty
            PlazaID = ObtenerPlazaID(Plaza)

            '----------------------------------------------------------------------------------------------------------
            ' Obtener las promociones
            '----------------------------------------------------------------------------------------------------------
            Dim oPromociones As DataTable
            oPromociones = Offers(PlazaID, Monto, Fecha.ToString("yyyy-MM-dd"))

            '----------------------------------------------------------------------------------------------------------
            ' Validamos resultados
            '----------------------------------------------------------------------------------------------------------
            If Not oPromociones Is Nothing AndAlso oPromociones.Rows.Count > 0 Then

                '----------------------------------------------------------------------------------------------------------
                '  Obtenemos el registro del periodo en que entra segun los datos establecidos
                '----------------------------------------------------------------------------------------------------------
                Dim oEnPeriodo As New DataView(oPromociones, "term = '" & Quincenas.Trim & "'", "", DataViewRowState.CurrentRows)
                If oEnPeriodo.Count > 0 Then
                    PromocionID = NoNulls(oEnPeriodo("id_offer")).ToString
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return PromocionID

    End Function

    '-----------------------------------------------------
    ' JNAVA (03.08.2016): Obtener ID de seguro y detalle
    '-----------------------------------------------------
    Public Function ObtenerSeguroPorID(ByVal ID As String, Optional ByRef CostoSeguro As Decimal = 0, Optional ByRef DatosAseguradora As DataRow = Nothing) As String

        Dim SeguroID As String = String.Empty
        Dim oDatosSeguro As DataTable

        '-----------------------------------------------------
        ' Obtenemos los datos de la plaza en S2Credit
        '-----------------------------------------------------
        oDatosSeguro = Insurance()

        If Not oDatosSeguro Is Nothing AndAlso oDatosSeguro.Rows.Count > 0 Then

            '---------------------------------------------------------
            ' Si se obtuvo informacion, comparamos con lo capturado
            '---------------------------------------------------------
            For Each oAseguradora As DataRow In oDatosSeguro.Rows
                If ID = oAseguradora("id_insurance").ToString.Trim Then
                    SeguroID = NoNulls(oAseguradora("id_insurance")).Trim
                    CostoSeguro = CDec(NoNulls(oAseguradora("rate")).Trim)
                    DatosAseguradora = oAseguradora
                    Exit For
                End If
            Next

        End If

        Return SeguroID

    End Function

    '-----------------------------------------------------
    ' JNAVA (04.08.2016): Obtener ID de Tienda
    '-----------------------------------------------------
    Private Function ObtenerTiendaID(ByVal Plaza As String, ByVal Sucursal As String) As String

        Dim TiendaID, PlazaID As String
        Dim oDatosTiendas As DataTable

        '-----------------------------------------------------
        ' Obtenemos el Id de la Plaza
        '-----------------------------------------------------
        PlazaID = ObtenerPlazaID(Plaza)

        '-----------------------------------------------------
        ' Obtenemos los datos de la sucursal segun la plaza
        '-----------------------------------------------------
        oDatosTiendas = Stores(PlazaID)

        If Not oDatosTiendas Is Nothing AndAlso oDatosTiendas.Rows.Count > 0 Then

            '---------------------------------------------------------
            ' Si se obtuvo informacion, comparamos con lo capturado
            '---------------------------------------------------------
            For Each oTienda As DataRow In oDatosTiendas.Rows
                If Sucursal.Trim = NoNulls(oTienda("code")).Trim Then
                    TiendaID = NoNulls(oTienda("id")).Trim
                    Exit For
                End If
            Next

        End If

        Return TiendaID

    End Function

    '-----------------------------------------------------
    ' JNAVA (04.08.2016): Obtener ID de Tienda
    '-----------------------------------------------------
    Public Function ObtenerParentescos() As DataTable

        '-----------------------------------------------------
        ' Obtenemos los datos 
        '-----------------------------------------------------
        Dim oDatos As DataTable
        oDatos = RelationShip()

        '-----------------------------------------------------
        ' Regresamos el resultado
        '-----------------------------------------------------
        Return oDatos

    End Function


    '-----------------------------------------------------
    ' JNAVA (05.08.2016): Obtener ID de Tienda
    '-----------------------------------------------------
    Function ObtenerParentescoPorID(ByVal ParentescoID As String) As String

        Dim strParentesco As String = String.Empty

        '-----------------------------------------------------
        ' Obtenemos los datos 
        '-----------------------------------------------------
        Dim oDatos As DataTable
        oDatos = RelationShip()

        '-----------------------------------------------------
        ' Validamos el resultado para obtener Parentesco
        '-----------------------------------------------------
        If oDatos Is Nothing And oDatos.Rows.Count > 0 Then
            For Each oParentesco As DataRow In oDatos.Rows
                If NoNulls(oParentesco("id")).Trim = ParentescoID.Trim Then
                    strParentesco = NoNulls(oParentesco("value")).Trim
                    Exit For
                End If
            Next
        End If

        '-----------------------------------------------------
        ' Regresamos el resultado
        '-----------------------------------------------------
        Return strParentesco

    End Function

#End Region

End Class
