'-------------------------------------------------------------------------
'                        Class ProcesosS2Credit                          
'-------------------------------------------------------------------------
' Descripción        : Implementación de Servicios de S2Credit como
'                      validador en base a configuracion
' Funcional          : N/A                               
' Programador        : Josué Nava                                     
' Fecha de Creación  : 02.08.2016
' ID CC              : N/A                                            
'-------------------------------------------------------------------------

Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports System.Reflection
Imports System.ComponentModel
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Linq.JArray
Imports System.IO

Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class ProcesosS2Credit

#Region "Declaracion de Variables y Objetos"
    Private URL As String
    Private oRest As ServiciosREST
    Private htParametros As Hashtable
    Private Satelite As String
    Private m_Metodo As String
    Private m_Type As String
    Private SerialID As String

    Private oParent As CierreDiaManager
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

    Public Sub New(ByVal Parent As CierreDiaManager)

        '
        oParent = Parent

        'Inicializamos URL Base
        Me.URL = oParent.ConfigSaveArchivos.ServidorREST & ":" & oParent.ConfigSaveArchivos.PuertoREST
        'Me.URL = strURL

        Me.Satelite = "DPPRO"

        'Inicializamos Objeto par ael manejo de Servicios REST
        Me.oRest = New ServiciosREST(Me.URL)

        'inicializamos cabecera de Transacciones
        Me.htParametros = New Hashtable

        Me.Metodo = "/pos/s2credit"
        Me.Type = "POST" 'Siempre sera POST

        Me.SerialID = oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()

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

    '----------------------------------------------------------------------------------------------------------
    ' JNAVA (02.08.2016): Escribe en ErrorLogFile
    '----------------------------------------------------------------------------------------------------------
    Private Sub EscribeLog(ByVal strError As String, ByVal Titulo As String)

        Dim StreamW As New StreamWriter(AppDomain.CurrentDomain.BaseDirectory & "\ErrorLogFile.txt", True) 'Application.StartupPath & "\ErrorLogFile.txt", True)

        StreamW.WriteLine(Now.ToString & " --> " & Titulo.ToUpper & vbCrLf)
        StreamW.WriteLine("Detalle --> " & strError)
        StreamW.WriteLine("".PadLeft(250, "-"))

        StreamW.Close()

    End Sub


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

#End Region

#Region "Venta DPVale"

    '-------------------------------------------------------------------------------
    ' JNAVA (02.08.2016): Valida el DPVale en S2 Credit
    '-------------------------------------------------------------------------------
    Public Function ValidaDPVale(ByVal cdpvale As cDPVale) As cDPVale

        Dim oDPValeS2C As Dictionary(Of String, Object)

        Dim oDistribuidor, oPlaza, oCredito, oVale As Dictionary(Of String, Object)

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
                ' Obtenemos datos y validamos
                '------------------------------------------------------------------------------
                oDistribuidor = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("distributor").ToString())
                oPlaza = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("branch").ToString())
                oCredito = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("credit").ToString())
                oVale = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("coupon").ToString())

                '-------------------------------------------------------------------------------------------
                ' Obtemos el Estatus del Distribuidor
                '-------------------------------------------------------------------------------------------
                If CInt(NoNulls(oDistribuidor("status"))) = 1 Then 'Habilitado
                    cdpvale.Congelado = String.Empty
                Else 'Deshabilitado
                    cdpvale.Congelado = "X"
                End If

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
                dtInfoDPVALE.Columns.Add("ONUMDE") 'Quincenas de Vale Origen
                dtInfoDPVALE.Columns.Add("OFECCO") 'Fecha de Cobro Vale Origen
                dtInfoDPVALE.AcceptChanges()

                '------------------------------------------------------------------------------
                ' Llenamos informacion del Vale
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
                If NoNulls(oVale("amount")) = String.Empty Then
                    oRow("Monto") = 0.0
                Else
                    oRow("Monto") = CDec(NoNulls(oVale("amount").ToString))
                End If
                oRow("Pares") = 0

                '------------------------------------------------------------------------------
                ' Info Vale Padre (Original)
                '------------------------------------------------------------------------------
                If NoNulls(oDPValeS2C("parent")) <> String.Empty Then
                    Dim oParent As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oDPValeS2C("parent").ToString())
                    oRow("REVAL") = "X"
                    oRow("ZREVAL2") = String.Empty
                    oRow("Orige") = NoNulls(oParent("id")).PadLeft(10, "0")
                    oRow("ONUMDE") = NoNulls(oParent("fortnight")) 'Quincenas Vale Origen
                    Dim FECCO As String = NoNulls(oParent("exchangedDate")) 'Fecha de Cobro Vale Origen
                    If FECCO <> String.Empty Then
                        oRow("OFECCO") = CDate(FECCO).ToShortDateString
                    Else
                        oRow("OFECCO") = String.Empty
                    End If
                Else
                    oRow("REVAL") = String.Empty
                    oRow("ZREVAL2") = String.Empty
                    oRow("Orige") = String.Empty
                    oRow("ONUMDE") = String.Empty
                    oRow("OFECCO") = String.Empty
                End If

                '------------------------------------------------------------------------------
                ' Agregamos datos a detalle
                '------------------------------------------------------------------------------
                dtInfoDPVALE.Rows.Add(oRow)
                dtInfoDPVALE.AcceptChanges()
                cdpvale.InfoDPVALE = dtInfoDPVALE

                '------------------------------------------------------------------------------
                ' Revisamos si existe el vale (0 = NO existe, 1 = Si existe)
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
                ' LLenamos informacion de la plaza y credito
                '------------------------------------------------------------------------------
                cdpvale.EPLAZA = NoNulls(oPlaza("code")).Trim
                If Not oCredito("current") Is Nothing Then
                    cdpvale.LimiteCredito = CDec(oCredito("current").ToString)
                Else
                    cdpvale.LimiteCredito = 0.0
                End If
                If Not oCredito("available") Is Nothing Then
                    cdpvale.LimiteCreditoPrestamo = CDec(oCredito("available").ToString)
                Else
                    cdpvale.LimiteCreditoPrestamo = 0.0
                End If

                'cdpvale.FlagPrestamo = oDPValeS2C("EPRESTAMO").ToString

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return cdpvale

    End Function

#End Region

End Class
