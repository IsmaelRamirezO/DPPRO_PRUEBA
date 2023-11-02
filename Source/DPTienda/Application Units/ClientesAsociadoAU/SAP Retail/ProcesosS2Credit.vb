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
' Fecha de Creación  : 11.07.2016
' ID CC              : N/A                                            
'-------------------------------------------------------------------------

Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports System.Reflection
Imports System.ComponentModel
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Linq.JArray
Imports System.Drawing
Imports System.IO

Imports System.Text.RegularExpressions

Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports System.Windows.Forms

Public Class ProcesosS2Credit

#Region "Declaracion de Variables y Objetos"
    Private URL As String
    Private oRest As ServiciosREST
    Private htParametros As Hashtable
    Private Satelite As String
    Private m_Metodo As String
    Private m_Type As String

    Private oParent As ClientesManager
    Public oSecurity As SecurityHash

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

    Public Sub New(ByVal Parent As ClientesManager)

        '
        oParent = Parent

        '--------------------------------------------------------------------------------------
        ' JNAVA (10.08.2016): Se obtiene la configuracion del servidor de servicios REST
        '--------------------------------------------------------------------------------------
        Dim ServidorREST As String = String.Empty
        Dim PuertoREST As Long = 0
        CargarConfigREST(ServidorREST, PuertoREST)

        'Inicializamos URL Base
        Me.URL = ServidorREST & ":" & PuertoREST
        '--------------------------------------------------------------------------------------

        Me.Satelite = "DPPRO"

        'Inicializamos Objeto par ael manejo de Servicios REST
        Me.oRest = New ServiciosREST(Me.URL)

        'inicializamos cabecera de Transacciones
        Me.htParametros = New Hashtable

        Me.Metodo = "/pos/s2credit"
        Me.Type = "POST" 'Siempre sera POST

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
                result = Nothing
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
    ' JNAVA (12.07.2016): Escribe en ErrorLogFile
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

    Private Function CreateObjectPost(ByVal rfc As String, ByVal param As Dictionary(Of String, Object)) As String
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

    Public Function DecodificarFirma(ByVal Firma As String) As Image
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
    ' JNAVA (12.07.2016): Quita signos de puntuacion y caracteres especiales
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
    ' JNAVA (13.07.2016): Quita foramto a telefono
    '----------------------------------------------------------------------------------------------------------
    Private Function QuitarFormatoTelefono(ByVal Telefono As String) As String
        Dim oRegex As New Regex("[^\d]")
        Telefono = oRegex.Replace(Telefono, "")
        Return Telefono
    End Function

    '----------------------------------------------------------------------------------------------------------
    ' JNAVA (26.07.2016): Quita nullos retornados por los servicios
    '----------------------------------------------------------------------------------------------------------
    Private Function NoNulls(ByVal Objeto As Object) As Object
        Dim Result As String = String.Empty
        If Not Objeto Is Nothing Then
            Result = Objeto.ToString
        End If
        Return Result
    End Function

#End Region

#Region "Servicios"

    Private Function SaveCustomers(ByVal DatosCliente As Dictionary(Of String, Object)) As Dictionary(Of String, Object)

        Dim Servicio As String = "save-customer"
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------
        ' Preparamos parametros para enviar json generico
        '------------------------------------------------------------
        With DatosCliente
            oParams.Add("id_customer", DatosCliente("id_customer"))
            oParams.Add("name", DatosCliente("name"))
            oParams.Add("middle_name", DatosCliente("middle_name"))
            oParams.Add("last_name", DatosCliente("last_name"))
            oParams.Add("second_last_name", DatosCliente("second_last_name"))
            oParams.Add("birthdate", DatosCliente("birthdate")) '1987-03-16"
            oParams.Add("marital_status", DatosCliente("marital_status"))
            oParams.Add("gender", DatosCliente("gender"))
            oParams.Add("email", DatosCliente("email"))
            oParams.Add("rfc", DatosCliente("rfc"))
            oParams.Add("curp", DatosCliente("curp"))
            oParams.Add("id_identification", DatosCliente("id_identification"))
            oParams.Add("identification_value", DatosCliente("identification_value"))

            '------------------------------------------------------------------
            ' JNAVA (16.03.2016): Llenamos datos de los Direcciones 
            '------------------------------------------------------------------
            Dim oAddressCollection As New List(Of Dictionary(Of String, Object))
            oAddressCollection.Add(DatosCliente("addressCollection"))

            '------------------------------------------------------------------
            ' JNAVA (16.03.2016): Llenamos datos de los Numeros telefonicos 
            '------------------------------------------------------------------
            Dim oPhoneNumberCollection As New List(Of Dictionary(Of String, Object))
            oPhoneNumberCollection.Add(DatosCliente("phoneNumberCollection"))

            '------------------------------------------------------------------
            ' JNAVA (16.03.2016): Metemos los datos al detalle del objeto para serializarlo a JSON
            '------------------------------------------------------------------
            oParams.Add("addressCollection", oAddressCollection)
            oParams.Add("phoneNumberCollection", oPhoneNumberCollection)

        End With

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        oRespuesta = Me.ExecuteService(Servicio, oParams)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta Is Nothing Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oRespuesta("customer").ToString()) 'oRespuesta

    End Function

    Private Function Sepomex(ByVal CodigoPostal As String) As List(Of Dictionary(Of String, Object))
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
        If oRespuesta Is Nothing Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Retornamos informacion recibida
        '-----------------------------------------------------------------
        Return JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(oRespuesta("data").ToString())

    End Function

#End Region

#Region "Clientes"

    '-----------------------------------------------------
    ' JNAVA (12.07.2016): Alta cliente en S2Credit
    '-----------------------------------------------------
    Public Function SaveCliente(ByVal oCliente As ClienteAlterno, Optional ByVal EsDPVale As Boolean = False) As String

        Dim oClientesS2C As New Dictionary(Of String, Object)
        Dim oInfoClienteS2C As Dictionary(Of String, Object)
        Dim IDEstado As String = String.Empty

        Dim ID As String
        Dim strResult As String = String.Empty

        Try

            Dim name As String = ""
            Dim middle_name As String = ""

            '------------------------------------------------------------------------------------
            ' Validamos el ID del cliente para saber si es Alta o Modificacion
            '------------------------------------------------------------------------------------
            If oCliente.CodigoAlterno.Trim("0").Trim = String.Empty OrElse oCliente.CodigoAlterno.Trim = String.Empty Then
                ID = "0"
            Else
                ID = oCliente.CodigoAlterno
            End If

            '-----------------------------------------------------
            ' Llenamos datos del Cliente
            '-----------------------------------------------------
            oClientesS2C("id_customer") = CInt(ID)

            GetNombres(oCliente.Nombre.TrimEnd, name, middle_name)
            oClientesS2C("name") = name.TrimEnd
            oClientesS2C("middle_name") = middle_name.TrimEnd
            oClientesS2C("last_name") = oCliente.ApellidoPaterno.TrimEnd
            oClientesS2C("second_last_name") = oCliente.ApellidoMaterno.TrimEnd
            oClientesS2C("birthdate") = Format(oCliente.FechaNacimiento, "yyyy-MM-dd")

            If oCliente.EstadoCivil = "CASADO(A)" Then
                oClientesS2C("marital_status") = 2
            Else
                oClientesS2C("marital_status") = 1
            End If

            If oCliente.Sexo = "M" Then
                oClientesS2C("gender") = 1
            Else
                oClientesS2C("gender") = 2
            End If

            oClientesS2C("email") = oCliente.EMail
            oClientesS2C("rfc") = oCliente.RFC.Replace("-", "").Trim

            '------------------------------------------------------------
            ' Generamos la CURP del cliente en base a sus datos
            '------------------------------------------------------------
            IDEstado = BuscaEstado(oCliente.Estado)
            oClientesS2C("curp") = "" 'GenerarCURP(name, middle_name, oCliente.ApellidoPaterno, oCliente.ApellidoMaterno, oCliente.Sexo, oCliente.FechaNacimiento, IDEstado)
            oClientesS2C("id_identification") = 1
            oClientesS2C("identification_value") = "X"

            '------------------------------------------------------------
            ' Preparamos la direccion
            '------------------------------------------------------------
            Dim oAddress As New Dictionary(Of String, Object)
            oAddress("street") = oCliente.Direccion
            oAddress("houseNumber") = oCliente.NumExt
            oAddress("apartmentNumber") = oCliente.NumInt

            '------------------------------------
            ' Obtenemos datos desde S2Credit
            '------------------------------------
            Dim oSepomex As New Dictionary(Of String, Object)
            oSepomex = ObtenerDireccionByCodigoPostal(oCliente.CP.Trim, oCliente.Colonia)
            oAddress("zipcode") = oSepomex("zipcode")
            oAddress("state") = oSepomex("state")
            oAddress("city") = oSepomex("city")
            oAddress("settlement") = oSepomex("settlement")
            oAddress("neighborhood") = oSepomex("neighborhood")
            oClientesS2C("addressCollection") = oAddress

            '------------------------------------------------------------
            ' Preparamos del telefono
            '------------------------------------------------------------
            Dim oPhone As New Dictionary(Of String, Object)
            oPhone("number") = QuitarFormatoTelefono(oCliente.Telefono)
            oPhone("type") = 1
            oClientesS2C("phoneNumberCollection") = oPhone

            '-----------------------------------------------------
            ' Ejecutamos Servicio
            '-----------------------------------------------------
            oInfoClienteS2C = Nothing
            oInfoClienteS2C = SaveCustomers(oClientesS2C)

            If Not oInfoClienteS2C Is Nothing Then
                strResult = oInfoClienteS2C("id_customer").ToString
                If strResult.Trim("0") = String.Empty Then
                    strResult = String.Empty
                    MsgBox("Ocurrio un error al Crear el Cliente en S2Credit.", MsgBoxStyle.Exclamation, "Dportenis PRO")
                End If
            Else
                strResult = String.Empty
                MsgBox("Ocurrio un error al Crear el Cliente en S2Credit.", MsgBoxStyle.Exclamation, "Dportenis PRO")
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return strResult.PadLeft(10, "0").Trim

    End Function

    '----------------------------------------------------------------------------------------------------------
    ' JNAVA (12.07.2016): Genera CURP del cliente en base a Nombre, Edad, Sexo, Fecha de Nacimiento y Estado
    '----------------------------------------------------------------------------------------------------------
    Private Function GenerarCURP(ByVal Nombre As String, ByVal Nombre2 As String, ByVal ApellidoP As String, ByVal ApellidoM As String, _
                             ByVal Sexo As String, ByVal FechaNacimiento As DateTime, _
                             ByVal IDEstado As Integer) As String

        Dim curp As String
        Dim caracter1 As String
        Dim caracter2 As String
        Dim caracter3 As String
        Dim caracter4 As String
        Dim caracter5 As String
        Dim caracter6 As String
        Dim caracter7 As String
        Dim caracter8 As String
        Dim caracter9 As String
        Dim caracter10 As String
        Dim caracter11 As String
        Dim caracter12 As String
        Dim caracter13 As String
        Dim caracter14 As String
        Dim caracter15 As String
        Dim caracter16 As String
        Dim caracter17 As String
        Dim caracter18 As String

        If FechaNacimiento.Year <= Now.Year Then
            If FechaNacimiento.Year >= 1900 Then
                Dim value As String = Convert.ToString(ApellidoP.Chars(0))
                If ApellidoP.Chars(0) <> "Ñ"c Then
                    caracter1 = Convert.ToString(value)
                Else
                    caracter1 = "X"
                End If
                Dim i As Integer
                For i = 1 To ApellidoP.Length - 1
                    If ApellidoP.Chars(i) = "A"c OrElse ApellidoP.Chars(i) = "E"c OrElse ApellidoP.Chars(i) = "I"c OrElse ApellidoP.Chars(i) = "O"c OrElse ApellidoP.Chars(i) = "U"c Then
                        caracter2 = Convert.ToString(ApellidoP.Chars(i))
                        Exit For
                    End If
                    If ApellidoP.Length - 1 = i Then
                        caracter2 = "X"
                        Exit For
                    End If
                Next
                If ApellidoM <> "" AndAlso ApellidoM.Chars(0) <> "Ñ"c Then
                    Dim value2 As String = Convert.ToString(ApellidoM.Chars(0))
                    caracter3 = Convert.ToString(value2)
                Else
                    caracter3 = "X"
                End If
                If (Nombre.Chars(0) = "M"c AndAlso Nombre.Chars(1) = "A"c AndAlso Nombre.Chars(2) = "R"c AndAlso Nombre.Chars(3) = "I"c AndAlso Nombre.Chars(4) = "A"c) OrElse (Nombre.Chars(0) = "J"c AndAlso Nombre.Chars(1) = "O"c AndAlso Nombre.Chars(2) = "S"c AndAlso Nombre.Chars(3) = "E"c AndAlso Nombre2 <> "") Then
                    If Nombre2.Chars(0) <> "Ñ"c Then
                        Dim value3 As String = Convert.ToString(Nombre2.Chars(0))
                        caracter4 = Convert.ToString(value3)
                    Else
                        caracter4 = "X"
                    End If
                ElseIf Nombre.Chars(0) <> "Ñ"c Then
                    Dim value3 As String = Convert.ToString(Nombre.Chars(0))
                    caracter4 = Convert.ToString(value3)
                Else
                    caracter4 = "X"
                End If
                Dim value4 As String = Convert.ToString(FechaNacimiento.Year.ToString.Chars(2))
                caracter5 = Convert.ToString(value4)
                Dim value5 As String = Convert.ToString(FechaNacimiento.Year.ToString.Chars(3))
                caracter6 = Convert.ToString(value5)
                If FechaNacimiento.Year > 1999 Then
                    caracter17 = "A"
                Else
                    caracter17 = "0"
                End If
                For j As Integer = 0 To 12 'Meses
                    If CInt(FechaNacimiento.Month - 1) = j Then
                        If j > 8 Then
                            caracter7 = "1"
                            caracter8 = Convert.ToString(j - 9)
                        Else
                            caracter7 = "0"
                            caracter8 = Convert.ToString(j + 1)
                        End If
                    End If
                Next
                For k As Integer = 0 To 30 'Dias
                    If CInt(FechaNacimiento.Day - 1) = k Then
                        If k < 9 Then
                            caracter9 = "0"
                            caracter10 = Convert.ToString(k + 1)
                        End If
                        If k > 8 AndAlso k < 19 Then
                            caracter9 = "1"
                            caracter10 = Convert.ToString(k - 9)
                        End If
                        If k > 18 AndAlso k < 29 Then
                            caracter9 = "2"
                            caracter10 = Convert.ToString(k - 19)
                        End If
                        If k > 28 Then
                            caracter9 = "3"
                            caracter10 = Convert.ToString(k - 29)
                        End If
                    End If
                Next
                If Sexo = "M" Then
                    caracter11 = "H"
                Else
                    caracter11 = "M"
                End If

                Select Case IDEstado
                    Case 1
                        caracter12 = "A"
                        caracter13 = "S"

                    Case 2
                        caracter12 = "B"
                        caracter13 = "C"

                    Case 3
                        caracter12 = "B"
                        caracter13 = "S"

                    Case 4
                        caracter12 = "C"
                        caracter13 = "C"

                    Case 5
                        caracter12 = "C"
                        caracter13 = "L"

                    Case 6
                        caracter12 = "C"
                        caracter13 = "M"

                    Case 7
                        caracter12 = "C"
                        caracter13 = "S"

                    Case 8
                        caracter12 = "C"
                        caracter13 = "H"

                    Case 9
                        caracter12 = "D"
                        caracter13 = "F"

                    Case 10
                        caracter12 = "D"
                        caracter13 = "G"

                    Case 11
                        caracter12 = "G"
                        caracter13 = "T"

                    Case 11
                        caracter12 = "G"
                        caracter13 = "R"

                    Case 13
                        caracter12 = "H"
                        caracter13 = "G"

                    Case 14
                        caracter12 = "J"
                        caracter13 = "C"

                    Case 15
                        caracter12 = "M"
                        caracter13 = "C"

                    Case 16
                        caracter12 = "M"
                        caracter13 = "N"

                    Case 17
                        caracter12 = "M"
                        caracter13 = "S"

                    Case 18
                        caracter12 = "N"
                        caracter13 = "T"

                    Case 19
                        caracter12 = "N"
                        caracter13 = "L"

                    Case 20
                        caracter12 = "O"
                        caracter13 = "C"

                    Case 21
                        caracter12 = "P"
                        caracter13 = "L"

                    Case 22
                        caracter12 = "Q"
                        caracter13 = "T"

                    Case 23
                        caracter12 = "Q"
                        caracter13 = "R"

                    Case 24
                        caracter12 = "S"
                        caracter13 = "P"

                    Case 25
                        caracter12 = "S"
                        caracter13 = "L"

                    Case 26
                        caracter12 = "S"
                        caracter13 = "R"

                    Case 27
                        caracter12 = "T"
                        caracter13 = "C"

                    Case 28
                        caracter12 = "T"
                        caracter13 = "S"

                    Case 29
                        caracter12 = "T"
                        caracter13 = "L"

                    Case 30
                        caracter12 = "V"
                        caracter13 = "Z"

                    Case 31
                        caracter12 = "Y"
                        caracter13 = "N"

                    Case 32
                        caracter12 = "Z"
                        caracter13 = "S"

                    Case Else
                        caracter12 = "N"
                        caracter13 = "E"
                End Select

                For i = 1 To ApellidoP.Length - 1
                    If ApellidoP.Chars(i) = "A"c OrElse ApellidoP.Chars(i) = "E"c OrElse ApellidoP.Chars(i) = "I"c OrElse ApellidoP.Chars(i) = "O"c OrElse ApellidoP.Chars(i) = "U"c Then
                        If ApellidoP.Length - 1 = i Then
                            caracter14 = "X"
                            Exit For
                        End If
                    Else
                        If ApellidoP.Chars(i) <> "Ñ"c Then
                            caracter14 = Convert.ToString(ApellidoP.Chars(i))
                            Exit For
                        End If
                        If ApellidoP.Chars(i) = "Ñ"c Then
                            caracter14 = "X"
                            Exit For
                        End If
                    End If
                Next
                If ApellidoM <> "" Then
                    For i = 1 To ApellidoM.Length - 1
                        If ApellidoM.Chars(i) = "A"c OrElse ApellidoM.Chars(i) = "E"c OrElse ApellidoM.Chars(i) = "I"c OrElse ApellidoM.Chars(i) = "O"c OrElse ApellidoM.Chars(i) = "U"c Then
                            If ApellidoM.Length - 1 = i Then
                                caracter15 = "X"
                                Exit For
                            End If
                        Else
                            If ApellidoM.Chars(i) <> "Ñ"c Then
                                caracter15 = Convert.ToString(ApellidoM.Chars(i))
                                Exit For
                            End If
                            If ApellidoM.Chars(i) = "Ñ"c Then
                                caracter15 = "X"
                                Exit For
                            End If
                        End If
                    Next
                Else
                    caracter15 = "X"
                End If
                i = 1
                While i < Nombre.Length
                    If Nombre.Chars(i) = "A"c OrElse Nombre.Chars(i) = "E"c OrElse Nombre.Chars(i) = "I"c OrElse Nombre.Chars(i) = "O"c OrElse Nombre.Chars(i) = "U"c Then
                        If Nombre.Length - 1 = i Then
                            caracter16 = "X"
                            Exit While
                        End If
                        i += 1
                    Else
                        If Nombre.Chars(i) <> "Ñ"c Then
                            caracter16 = Convert.ToString(Nombre.Chars(i))
                            Exit While
                        End If
                        caracter16 = "X"
                        Exit While
                    End If
                End While
                Dim array As Char() = New Char() {Convert.ToChar(caracter1), Convert.ToChar(caracter2), Convert.ToChar(caracter3), Convert.ToChar(caracter4), Convert.ToChar(caracter5), Convert.ToChar(caracter6), _
                 Convert.ToChar(caracter7), Convert.ToChar(caracter8), Convert.ToChar(caracter9), Convert.ToChar(caracter10), Convert.ToChar(caracter11), Convert.ToChar(caracter12), _
                 Convert.ToChar(caracter13), Convert.ToChar(caracter14), Convert.ToChar(caracter15), Convert.ToChar(caracter16), Convert.ToChar(caracter17)}
                Dim array2 As Integer() = New Integer(16) {}
                Dim array3 As Integer() = array2
                For l As Integer = 0 To 16
                    If array(l) = "0"c Then
                        array3(l) = 0
                    End If
                    If array(l) = "1"c Then
                        array3(l) = 1
                    End If
                    If array(l) = "2"c Then
                        array3(l) = 2
                    End If
                    If array(l) = "3"c Then
                        array3(l) = 3
                    End If
                    If array(l) = "4"c Then
                        array3(l) = 4
                    End If
                    If array(l) = "5"c Then
                        array3(l) = 5
                    End If
                    If array(l) = "6"c Then
                        array3(l) = 6
                    End If
                    If array(l) = "7"c Then
                        array3(l) = 7
                    End If
                    If array(l) = "8"c Then
                        array3(l) = 8
                    End If
                    If array(l) = "9"c Then
                        array3(l) = 9
                    End If
                    If array(l) = "A"c Then
                        array3(l) = 10
                    End If
                    If array(l) = "B"c Then
                        array3(l) = 11
                    End If
                    If array(l) = "C"c Then
                        array3(l) = 12
                    End If
                    If array(l) = "D"c Then
                        array3(l) = 13
                    End If
                    If array(l) = "E"c Then
                        array3(l) = 14
                    End If
                    If array(l) = "F"c Then
                        array3(l) = 15
                    End If
                    If array(l) = "G"c Then
                        array3(l) = 16
                    End If
                    If array(l) = "H"c Then
                        array3(l) = 17
                    End If
                    If array(l) = "I"c Then
                        array3(l) = 18
                    End If
                    If array(l) = "J"c Then
                        array3(l) = 19
                    End If
                    If array(l) = "K"c Then
                        array3(l) = 20
                    End If
                    If array(l) = "L"c Then
                        array3(l) = 21
                    End If
                    If array(l) = "M"c Then
                        array3(l) = 22
                    End If
                    If array(l) = "N"c Then
                        array3(l) = 23
                    End If
                    If array(l) = "Ñ"c Then
                        array3(l) = 24
                    End If
                    If array(l) = "O"c Then
                        array3(l) = 25
                    End If
                    If array(l) = "P"c Then
                        array3(l) = 26
                    End If
                    If array(l) = "Q"c Then
                        array3(l) = 27
                    End If
                    If array(l) = "R"c Then
                        array3(l) = 28
                    End If
                    If array(l) = "S"c Then
                        array3(l) = 29
                    End If
                    If array(l) = "T"c Then
                        array3(l) = 30
                    End If
                    If array(l) = "U"c Then
                        array3(l) = 31
                    End If
                    If array(l) = "V"c Then
                        array3(l) = 32
                    End If
                    If array(l) = "W"c Then
                        array3(l) = 33
                    End If
                    If array(l) = "X"c Then
                        array3(l) = 34
                    End If
                    If array(l) = "Y"c Then
                        array3(l) = 35
                    End If
                    If array(l) = "Z"c Then
                        array3(l) = 36
                    End If
                Next
                array3(0) = array3(0) * 18
                array3(1) = array3(1) * 17
                array3(2) = array3(2) * 16
                array3(3) = array3(3) * 15
                array3(4) = array3(4) * 14
                array3(5) = array3(5) * 13
                array3(6) = array3(6) * 12
                array3(7) = array3(7) * 11
                array3(8) = array3(8) * 10
                array3(9) = array3(9) * 9
                array3(10) = array3(10) * 8
                array3(11) = array3(11) * 7
                array3(12) = array3(12) * 6
                array3(13) = array3(13) * 5
                array3(14) = array3(14) * 4
                array3(15) = array3(15) * 3
                array3(16) = array3(16) * 2
                Dim num2 As Integer = array3(0) + array3(1) + array3(2) + array3(3) + array3(4) + array3(5) + array3(6) + array3(7) + array3(8) + array3(9) + array3(10) + array3(11) + array3(12) + array3(13) + array3(14) + array3(15) + array3(16)
                num2 = num2 Mod 10
                If num2 = 0 Then
                    caracter18 = "0"
                Else
                    num2 = 10 - num2
                End If
                caracter18 = Convert.ToString(num2)

                curp = String.Concat(New String() {caracter1, caracter2, caracter3, caracter4, caracter5, caracter6, _
                 caracter7, caracter8, caracter9, caracter10, caracter11, caracter12, _
                 caracter13, caracter14, caracter15, caracter16, caracter17, caracter18})

            End If
        End If
        Return curp
    End Function

    '----------------------------------------------------------------------------------------------------------
    ' JNAVA (12.07.2016): Busca el Codigo del Estado para el CURP
    '----------------------------------------------------------------------------------------------------------
    Private Function BuscaEstado(ByVal CodEstado As String) As String
        Dim i As Integer
        Dim dtEstados As DataTable = oParent.GetAllStates(False)
        For i = 0 To (dtEstados.Rows.Count - 1)
            If dtEstados.Rows(i).Item("CodEstado") = CodEstado Then
                Return dtEstados.Rows(i).Item("EstadoID")
            End If
        Next
        Return -1
    End Function

    '----------------------------------------------------------------------------------------------------------
    ' JNAVA (12.07.2016): Obtiene los nombres del cliente (si son mas de 1)
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
            nombre2 = ""
        End If
    End Sub

#End Region

#Region "Catalogos"

    '----------------------------------------------------------------------------------------------------------
    ' JNAVA (12.07.2016): Buscamos el CP para obtener direccion en S2Credit
    '----------------------------------------------------------------------------------------------------------
    Private Function ObtenerDireccionByCodigoPostal(ByVal CodigoPostal As String, ByVal Colonia As String) As Dictionary(Of String, Object)

        Dim oCodigoPostalS2C As New List(Of Dictionary(Of String, Object)) 'InfoCodigoPostalS2Credit
        Dim oDatosCP As New Dictionary(Of String, Object) 'ArraySepomex

        '-----------------------------------------------------
        ' Obtenemos los datos del CP en S2Credit
        '-----------------------------------------------------
        oCodigoPostalS2C = Sepomex(CodigoPostal.Trim)
        If Not oCodigoPostalS2C Is Nothing Then

            '---------------------------------------------------------
            ' Si se obtuvo informacion, comparamos con lo capturado
            '---------------------------------------------------------
            Dim strNeighborhood As String = String.Empty
            For Each oSepomex As Dictionary(Of String, Object) In oCodigoPostalS2C

                strNeighborhood = oSepomex("neighborhood").ToString

                '---------------------------------------------------------------------------------
                ' JNAVA 26.04.2016): quitamos signos de puntuacion a las colonias 
                '---------------------------------------------------------------------------------
                strNeighborhood = QuitarSignos(strNeighborhood).ToUpper
                Colonia = QuitarSignos(Colonia).ToUpper

                '-----------------------------------------------------
                ' Comparamos la por palabra de la colonia
                '-----------------------------------------------------
                Dim strArray() As String = Colonia.Split(" ")
                If strArray.Length > 1 Then
                    For Each Palabra As String In strArray
                        '-----------------------------------------------------
                        ' Si hay coicidencia, regresamos los datos de S2Credit
                        '-----------------------------------------------------
                        'If oS2Credit.BuscarPalabraEnCadena(Palabra.ToUpper.Trim, oSepomex("neighborhood").ToString.ToUpper) Then
                        If strNeighborhood.Contains(Palabra.ToUpper.Trim) Then
                            oDatosCP = oSepomex
                            GoTo Terminar
                        End If
                    Next
                Else
                    '-----------------------------------------------------
                    ' Si hay coicidencia, regresamos los datos de S2Credit
                    '-----------------------------------------------------
                    'If oS2Credit.BuscarPalabraEnCadena(Colonia.ToUpper.Trim, oSepomex("neighborhood").ToString.ToUpper) Then
                    If strNeighborhood.Contains(Colonia.ToUpper.Trim) Then
                        oDatosCP = oSepomex
                        GoTo Terminar
                    End If
                End If
            Next
            '------------------------------------------------------------------
            ' Si no hay coicidencia, regresamos el primer registro de S2Credit
            '------------------------------------------------------------------
            If oDatosCP.Count <= 0 Then
                oDatosCP = oCodigoPostalS2C.Item(0)
            End If
        Else
            '------------------------------------------------------------------------
            ' Si no hay informacion del CP en S2Credit, regresamos los datos vacios
            '------------------------------------------------------------------------
            oDatosCP("zipcode") = ""
            oDatosCP("state") = ""
            oDatosCP("city") = ""
            oDatosCP("settlement") = ""
            oDatosCP("neighborhood") = ""
        End If

Terminar:

        Return oDatosCP

    End Function

#End Region

#Region "Configuracion Cierre FI"

    Private Sub CargarConfigREST(ByRef Servidor As String, ByRef Puerto As Long)

        Dim oConfigCierreFI As New SaveConfigArchivos
        Dim strConfigurationFile As String = Application.StartupPath & "\configCierre.cml"

        oSecurity = New SecurityHash

        DesencriptarCML(strConfigurationFile)
        CorrigeXML(strConfigurationFile)

        If File.Exists(strConfigurationFile) Then
            Dim oReader As New SaveConfigArchivosReader(strConfigurationFile)
            oConfigCierreFI = oReader.LoadSettings
            oReader = Nothing
            Servidor = oConfigCierreFI.ServidorREST
            Puerto = oConfigCierreFI.PuertoREST
        End If

        oConfigCierreFI = Nothing

    End Sub

    Private Sub DesencriptarCML(ByVal RutaArchivo As String)

        Dim strCont As String = ""
        Dim StreamR As StreamReader
        Dim StreamW As StreamWriter

        If File.Exists(RutaArchivo) Then

Desencriptar:

            StreamR = New StreamReader(RutaArchivo, System.Text.Encoding.Default)
            strCont = StreamR.ReadToEnd
            StreamR.Close()

            Try
                strCont = oSecurity.DesEncriptarCML(strCont)
            Catch ex As Exception
                EncriptarCML(RutaArchivo)
                GoTo Desencriptar
            End Try

            StreamW = New StreamWriter(RutaArchivo, False)
            StreamW.Write(strCont)
            StreamW.Close()

        End If

    End Sub

    Private Sub EncriptarCML(ByVal RutaArchivo As String)

        Dim strCont As String = ""
        Dim StreamR As StreamReader
        Dim StreamW As StreamWriter

        If File.Exists(RutaArchivo) Then

            StreamR = New StreamReader(RutaArchivo, System.Text.Encoding.Default)
            strCont = StreamR.ReadToEnd
            StreamR.Close()

            Try
                strCont = oSecurity.EncriptarCML(strCont)
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error al encriptar el archivo.", "Consultor Saldo DPVale", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try

            StreamW = New StreamWriter(RutaArchivo, False)
            StreamW.Write(strCont)
            StreamW.Close()

        End If

    End Sub

    Private Sub CorrigeXML(ByVal strRuta As String)
        If Not IO.File.Exists(strRuta) Then
            Exit Sub
        End If
        Dim txtbx As New TextBox
        Dim sr As StreamReader = New StreamReader(strRuta)
        txtbx.Text = sr.ReadToEnd()
        sr.Close()
        If txtbx.Text.IndexOf("ConfigSaveArchivos") <> -1 Then
            txtbx.Text = txtbx.Text.Replace("ConfigSaveArchivos", "SaveConfigArchivos")
            Dim fSave As New StreamWriter(strRuta)
            fSave.WriteLine(txtbx.Text)
            fSave.Flush()
            fSave.Close()
        End If
    End Sub


#End Region



End Class
