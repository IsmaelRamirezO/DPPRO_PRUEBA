Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports System.Text.RegularExpressions

Imports System.Collections.Generic
Imports System.IO

Public Class ClientesDataGateWay
    Private oParent As ClientesManager
    Private m_strConnectionString As String
    Private m_strConnectionStringServer As String = ""
    Private m_strConnectionStringServerEmails As String = ""
    Private oSapCentro As ProcesoSAPManager
    Private oSAPMgr As ProcesoSAPManager

    Dim oS2Credit As ProcesosS2Credit

    Public Sub New(ByVal Parent As ClientesManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString
        oSapCentro = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)
        If Not oParent.ConfigCierreFI Is Nothing Then

            m_strConnectionStringServer = "data source = " & oParent.ConfigCierreFI.ServerHuellas & "; initial catalog = " & _
                                        oParent.ConfigCierreFI.BaseDatosHuellas & "; user id = " & Parent.ConfigCierreFI.UserHuellas & "; password = " & _
                                        oParent.ConfigCierreFI.PassHuellas

            m_strConnectionStringServerEmails = "data source = " & oParent.ConfigCierreFI.ServerEmails & "; initial catalog = " & _
                                        oParent.ConfigCierreFI.BaseDatosEmails & "; user id = " & Parent.ConfigCierreFI.UserEmails & "; password = " & _
                                        oParent.ConfigCierreFI.PasswordEmails
        End If
        oSAPMgr = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)

        '----------------------------------------------------------------------
        ' JNAVA (21.07.2016): Inicialimos Objeto de S2Credit
        '----------------------------------------------------------------------
        oS2Credit = New ProcesosS2Credit(oParent)

    End Sub

    Private Function GetPlaza() As String
        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oParent.ApplicationContext)
        oAlmacen = oAlmacenMgr.Load(oParent.ApplicationContext.ApplicationConfiguration.Almacen)
        If Not oAlmacen Is Nothing Then
            If oAlmacen.ID > 0 Then
                Return oAlmacen.PlazaID
            Else
                Return "MZT"
            End If
        End If

    End Function

    Public Function Insert(ByVal oCliente As ClienteAlterno, Optional ByVal EsDPVale As Boolean = False) As Boolean


        If Not EsDPVale Then
            'Insertar en SAP el Cliente siempre y cuando no sea PG
            If oCliente.TipoVenta.Trim <> "P" Then
                If InsertSap(oCliente) = 0 Then
                    Return False
                End If
            End If
        End If

        ''--------------------------------------------------------------------------------------------
        '' JNAVA (16.04.2016): Validamos si existe cliente en AFS para actualizarlo o crearlo
        ''--------------------------------------------------------------------------------------------
        'If Not ClienteAFS(oCliente, EsDPVale) Then
        '    If EsDPVale Then
        '        Return False
        '    End If
        'End If

        '-------------------------------------------------------------------------------------------------
        ' JNAVA (12.07.2016): Valida DPVale en S2Credit si esta activo como validador
        '-------------------------------------------------------------------------------------------------
        If oParent.ConfigCierreFI.AplicarS2Credit Then
            '-------------------------------------------------------------------------------------------------
            ' Guardamos el cliente en S2Credit
            '-------------------------------------------------------------------------------------------------
            If EsDPVale Then
                oCliente.CodigoAlterno = oS2Credit.SaveCliente(oCliente)
                If oCliente.CodigoAlterno Is Nothing OrElse oCliente.CodigoAlterno.Trim = "".PadLeft(10, "0") Then
                    Return False
                End If
            End If
        Else
            '--------------------------------------------------------------------------------------------
            ' JNAVA (16.04.2016): Validamos si existe cliente en AFS para actualizarlo o crearlo
            '--------------------------------------------------------------------------------------------
            If Not ClienteAFS(oCliente, EsDPVale) Then
                If EsDPVale Then
                    Return False
                End If
            End If
        End If
        '-------------------------------------------------------------------------------------------------

        'If oCliente.TipoVenta = "V" AndAlso (Not oParent.SAPApplicationConfig.DPValeSAP) Then

        '    Dim oClienteWS As Clientes
        '    oClienteWS = oParent.Create()

        '    With oClienteWS

        '        .ApellidoMaterno = oCliente.ApellidoMaterno
        '        .ApellidoPaterno = oCliente.ApellidoPaterno
        '        'If oCliente.RFCMoral <> String.Empty Then
        '        '.CedulaFiscal = oCliente.RFCMoral   'Persona Moral
        '        'Else
        '        .CedulaFiscal = oCliente.RFC        'Persona Fisica
        '        'End If
        '        .Ciudad = oCliente.Ciudad
        '        .CodAlmacen = oParent.ApplicationContext.ApplicationConfiguration.Almacen
        '        .CodPlaza = GetPlaza()
        '        .Colonia = oCliente.Colonia
        '        .CP = oCliente.CP.PadLeft(5, "0")
        '        .CreditoDPValeID = 0
        '        .Domicilio = oCliente.Direccion
        '        .Email = oCliente.EMail
        '        .Estado = oCliente.Estado
        '        .EstadoCivil = oCliente.EstadoCivil
        '        .FechaNac = oCliente.FechaNacimiento
        '        .Nombre = oCliente.Nombre
        '        .Sexo = oCliente.Sexo
        '        .Telefono = oCliente.Telefono
        '        .SetFlagNew()
        '        .RecordCreatedBy = oCliente.CodPlayer

        '    End With
        '    oCliente.CodigoClienteDPVALE = oParent.Save(oClienteWS)
        'End If


        'If oCliente.GrupoDeCuentas = "D019" Then

        'Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        'Dim sccmdInsert As SqlCommand
        'sccmdInsert = New SqlCommand

        'With sccmdInsert

        '    .Connection = sccnnConnection

        '    .CommandText = "[ClientesIns]"
        '    .CommandType = System.Data.CommandType.StoredProcedure

        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodigoCliente", System.Data.SqlDbType.VarChar, 15, "CodigoCliente"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 30, "Nombre"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Apellido", System.Data.SqlDbType.VarChar, 60, "Apellido"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sexo", System.Data.SqlDbType.VarChar, 1, "Sexo"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EstadoCivil", System.Data.SqlDbType.VarChar, 12, "EstadoCivil"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Direccion", System.Data.SqlDbType.VarChar, 50, "Direccion"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 50, "Estado"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 50, "Ciudad"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Colonia", System.Data.SqlDbType.VarChar, 50, "Colonia"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CP", System.Data.SqlDbType.Char, 5, "CP"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.VarChar, 30, "Telefono"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaNacimiento", System.Data.SqlDbType.DateTime, 8, "FechaNacimiento"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EMail", System.Data.SqlDbType.VarChar, 50, "EMail"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4, "CodAlmacen"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPlaza", System.Data.SqlDbType.VarChar, 3, "CodPlaza"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RFC", System.Data.SqlDbType.VarChar, 15, "RFC"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 50, "TipoVenta"))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Player", System.Data.SqlDbType.VarChar, 4, "Player"))

        'End With

        'Try

        '    sccnnConnection.Open()

        '    With sccmdInsert
        '        'Assign Parameters Values
        '        .Parameters("@CodigoCliente").Value = oCliente.CodigoAlterno
        '        .Parameters("@Nombre").Value = oCliente.Nombre
        '        .Parameters("@Apellido").Value = oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
        '        .Parameters("@Sexo").Value = oCliente.Sexo
        '        .Parameters("@EstadoCivil").Value = oCliente.EstadoCivil
        '        .Parameters("@Direccion").Value = oCliente.Direccion
        '        .Parameters("@Estado").Value = oCliente.Estado
        '        .Parameters("@Ciudad").Value = oCliente.Ciudad
        '        .Parameters("@Colonia").Value = oCliente.Colonia
        '        .Parameters("@CP").Value = oCliente.CP.PadLeft(5, "0")
        '        .Parameters("@Telefono").Value = oCliente.Telefono
        '        .Parameters("@FechaNacimiento").Value = Format(oCliente.FechaNacimiento, "dd/MM/yyyy")
        '        .Parameters("@EMail").Value = oCliente.EMail
        '        .Parameters("@CodAlmacen").Value = Me.oSapCentro.Read_Centros
        '        .Parameters("@CodPlaza").Value = oCliente.CodPlaza
        '        'If oCliente.RFCMoral <> String.Empty Then
        '        '.Parameters("@RFC").Value = oCliente.RFCMoral    'Persona Moral
        '        'Else
        '        .Parameters("@RFC").Value = oCliente.RFC         'Persona Fisica
        '        'End If
        '        .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.ID
        '        .Parameters("@StatusRegistro").Value = oCliente.RecordEnabled
        '        .Parameters("@TipoVenta").Value = oCliente.TipoVenta
        '        .Parameters("@Player").Value = oCliente.CodPlayer

        '        'Execute Command
        '        .ExecuteNonQuery()

        '        'Assign Other Values
        '        oCliente.CodigoCliente = .Parameters("@CodigoCliente").Value
        '        oCliente.RecordCreatedBy = oParent.ApplicationContext.Security.CurrentUser.ID
        '        oCliente.RecordCreatedOn = .Parameters("@Fecha").Value
        '    End With

        '    'Reset New State of Uso Object 
        '    oCliente.ResetFlagNew()
        '    oCliente.SetFlagDirty()

        '    sccnnConnection.Close()

        'Catch oSqlException As SqlException

        '    If (sccnnConnection.State <> ConnectionState.Closed) Then
        '        Try
        '            sccnnConnection.Close()
        '        Catch
        '        End Try
        '    End If

        '    Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        'Catch ex As Exception

        '    If (sccnnConnection.State <> ConnectionState.Closed) Then
        '        Try
        '            sccnnConnection.Close()
        '        Catch
        '        End Try
        '    End If

        '    Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        'End Try

        'ElseIf oCliente.TipoVenta.Trim = "P" Then

        'Dim strValor As String = ""

        'Try
        '    'strValor = Me.SelectConfig("GuardarServer").Trim
        '    'If strValor.Trim = "" Then strValor = "SI"

        '    'If strValor.Trim = "SI" Then Me.InsertClientePGInServer(oCliente)

        '    Me.InsertClientePGInServer(oCliente)
        'Catch ex As Exception
        'End Try

        'Me.InsertClientePG(oCliente)

        'Else

        Dim oClienteSAP As New ClientesSAP

        oClienteSAP.Apellidos = oCliente.ApellidoPaterno & "_" & oCliente.ApellidoMaterno
        oClienteSAP.Ciudad = oCliente.Ciudad
        oClienteSAP.Clienteid = oCliente.CodigoAlterno
        oClienteSAP.Codalmacen = Me.oSapCentro.Read_Centros
        oClienteSAP.CodPlaza = oCliente.CodPlaza
        oClienteSAP.Colonia = oCliente.Colonia
        oClienteSAP.Cp = oCliente.CP.PadLeft(5, "0")
        oClienteSAP.Domicilio = oCliente.Direccion
        oClienteSAP.Email = oCliente.EMail
        oClienteSAP.Estado = oCliente.Estado
        oClienteSAP.Estadocivil = oCliente.EstadoCivil
        oClienteSAP.Fecha = oCliente.RecordCreatedOn
        oClienteSAP.Fechanac = oCliente.FechaNacimiento
        oClienteSAP.Nombre = oCliente.Nombre
        oClienteSAP.Sexo = oCliente.Sexo
        oClienteSAP.Statusregistro = oCliente.RecordEnabled
        oClienteSAP.Telefono = oCliente.Telefono
        oClienteSAP.Usuario = ""
        oClienteSAP.Player = oCliente.CodPlayer
        'If oCliente.RFCMoral <> String.Empty Then
        'oClienteSAP.RFC = oCliente.RFCMoral 'Persona Moral
        'Else
        oClienteSAP.RFC = oCliente.RFC.ToUpper 'Persona Fisica
        'End If
        oClienteSAP.TipoVenta = oCliente.TipoVenta


        Me.oSapCentro.Write_Clientes(oClienteSAP)

        'End If

        Return True

    End Function

    'Public Function InsertClientePG(ByVal oCliente As ClienteAlterno) As Integer

    '    Dim sccnnConnection As New SqlConnection(m_strConnectionString)

    '    Dim sccmdInsert As SqlCommand
    '    sccmdInsert = New SqlCommand

    '    With sccmdInsert

    '        .Connection = sccnnConnection

    '        .CommandText = "[ClientesPGIns]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.Int, 4, "Codigo"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 50, "Nombre"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApellidoP", System.Data.SqlDbType.VarChar, 50, "Apellido Paterno"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApellidoM", System.Data.SqlDbType.VarChar, 50, "Apellido Materno"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sexo", System.Data.SqlDbType.VarChar, 1, "Sexo"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EstadoCivil", System.Data.SqlDbType.VarChar, 20, "EstadoCivil"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Direccion", System.Data.SqlDbType.VarChar, 50, "Direccion"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 50, "Estado"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 50, "Ciudad"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Colonia", System.Data.SqlDbType.VarChar, 50, "Colonia"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CP", System.Data.SqlDbType.Char, 6, "CP"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.VarChar, 30, "Telefono"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaNac", System.Data.SqlDbType.DateTime, 8, "FechaNacimiento"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar, 50, "EMail"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Centro", System.Data.SqlDbType.VarChar, 4, "CentroSAP"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVta", System.Data.SqlDbType.VarChar, 4, "Oficina Venta"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RFC", System.Data.SqlDbType.VarChar, 20, "RFC"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Player", System.Data.SqlDbType.VarChar, 8, "Player"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumExt", System.Data.SqlDbType.VarChar, 10, "Numero Exterior"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumInt", System.Data.SqlDbType.VarChar, 10, "Numero Interior"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RazonNoEmail", System.Data.SqlDbType.VarChar, 250, "Razon No Email"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RazonRechazoID", System.Data.SqlDbType.Int, 4, "Razon de Rechazo ID"))
    '    End With

    '    Try

    '        sccnnConnection.Open()

    '        With sccmdInsert
    '            'Assign Parameters Values
    '            .Parameters("@ClienteID").Value = oCliente.CodigoCliente
    '            .Parameters("@Nombre").Value = oCliente.Nombre
    '            .Parameters("@ApellidoP").Value = oCliente.ApellidoPaterno
    '            .Parameters("@ApellidoM").Value = oCliente.ApellidoMaterno
    '            .Parameters("@Sexo").Value = oCliente.Sexo
    '            .Parameters("@EstadoCivil").Value = oCliente.EstadoCivil
    '            .Parameters("@Direccion").Value = oCliente.Direccion
    '            .Parameters("@Estado").Value = oCliente.Estado
    '            .Parameters("@Ciudad").Value = oCliente.Ciudad
    '            .Parameters("@Colonia").Value = oCliente.Colonia
    '            .Parameters("@CP").Value = oCliente.CP.PadLeft(5, "0")
    '            .Parameters("@Telefono").Value = oCliente.Telefono.Trim.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")
    '            .Parameters("@FechaNac").Value = Format(oCliente.FechaNacimiento, "dd/MM/yyyy")
    '            .Parameters("@Email").Value = oCliente.EMail
    '            .Parameters("@Centro").Value = Me.oSapCentro.Read_Centros
    '            .Parameters("@OficinaVta").Value = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen 'oCliente.CodPlaza
    '            .Parameters("@RFC").Value = oCliente.RFC.Trim.Replace("-", "")
    '            .Parameters("@Player").Value = oCliente.CodPlayer
    '            .Parameters("@StatusRegistro").Value = oCliente.RecordEnabled
    '            .Parameters("@Fecha").Value = oCliente.RecordCreatedOn
    '            .Parameters("@NumExt").Value = oCliente.NumExt.Trim
    '            .Parameters("@NumInt").Value = oCliente.NumInt.Trim
    '            .Parameters("@RazonNoEmail").Value = oCliente.RazonNoEmail.Trim
    '            .Parameters("@RazonRechazoID").Value = oCliente.RazonRechazoID

    '            'Execute Command
    '            .ExecuteNonQuery()

    '            'Assign Other Values
    '            'oCliente.CodigoCliente = .Parameters("@CodigoCliente").Value
    '            oCliente.RecordCreatedBy = oParent.ApplicationContext.Security.CurrentUser.ID
    '            'oCliente.RecordCreatedOn = .Parameters("@Fecha").Value
    '        End With

    '        'Reset New State of Uso Object 
    '        oCliente.ResetFlagNew()
    '        oCliente.SetFlagDirty()

    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

    '    End Try

    'End Function

    'Public Function InsertClientePGInServer(ByVal oCliente As ClienteAlterno) As Integer

    '    Dim sccnnConnection As New SqlConnection(m_strConnectionStringServer)

    '    Dim sccmdInsert As SqlCommand
    '    sccmdInsert = New SqlCommand

    '    With sccmdInsert

    '        .Connection = sccnnConnection

    '        .CommandText = "[ClientesPGIns]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.Int, 4, "Codigo"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 50, "Nombre"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApellidoP", System.Data.SqlDbType.VarChar, 50, "Apellido Paterno"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApellidoM", System.Data.SqlDbType.VarChar, 50, "Apellido Materno"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sexo", System.Data.SqlDbType.VarChar, 1, "Sexo"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EstadoCivil", System.Data.SqlDbType.VarChar, 20, "EstadoCivil"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Direccion", System.Data.SqlDbType.VarChar, 50, "Direccion"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 50, "Estado"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 50, "Ciudad"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Colonia", System.Data.SqlDbType.VarChar, 50, "Colonia"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CP", System.Data.SqlDbType.Char, 6, "CP"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.VarChar, 30, "Telefono"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaNac", System.Data.SqlDbType.DateTime, 8, "FechaNacimiento"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar, 50, "EMail"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Centro", System.Data.SqlDbType.VarChar, 4, "CentroSAP"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVta", System.Data.SqlDbType.VarChar, 4, "Oficina Venta"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RFC", System.Data.SqlDbType.VarChar, 20, "RFC"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Player", System.Data.SqlDbType.VarChar, 8, "Player"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumExt", System.Data.SqlDbType.VarChar, 10, "Numero Exterior"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumInt", System.Data.SqlDbType.VarChar, 10, "Numero Interior"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RazonNoEmail", System.Data.SqlDbType.VarChar, 250, "Razon No Email"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RazonRechazoID", System.Data.SqlDbType.Int, 4, "Razon de Rechazo ID"))

    '        .Parameters("@ClienteID").Direction = ParameterDirection.InputOutput
    '        .Parameters("@Fecha").Direction = ParameterDirection.Output

    '    End With

    '    Try

    '        sccnnConnection.Open()

    '        With sccmdInsert
    '            'Assign Parameters Values
    '            .Parameters("@ClienteID").Value = oCliente.CodigoCliente
    '            .Parameters("@Nombre").Value = oCliente.Nombre
    '            .Parameters("@ApellidoP").Value = oCliente.ApellidoPaterno
    '            .Parameters("@ApellidoM").Value = oCliente.ApellidoMaterno
    '            .Parameters("@Sexo").Value = oCliente.Sexo
    '            .Parameters("@EstadoCivil").Value = oCliente.EstadoCivil
    '            .Parameters("@Direccion").Value = oCliente.Direccion
    '            .Parameters("@Estado").Value = oCliente.Estado
    '            .Parameters("@Ciudad").Value = oCliente.Ciudad
    '            .Parameters("@Colonia").Value = oCliente.Colonia
    '            .Parameters("@CP").Value = oCliente.CP.PadLeft(5, "0")
    '            .Parameters("@Telefono").Value = oCliente.Telefono.Trim.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")
    '            .Parameters("@FechaNac").Value = Format(oCliente.FechaNacimiento, "dd/MM/yyyy")
    '            .Parameters("@Email").Value = oCliente.EMail
    '            .Parameters("@Centro").Value = Me.oSapCentro.Read_Centros
    '            .Parameters("@OficinaVta").Value = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen 'oCliente.CodPlaza
    '            .Parameters("@RFC").Value = oCliente.RFC.Replace("-", "").Trim
    '            .Parameters("@Player").Value = oCliente.CodPlayer
    '            .Parameters("@StatusRegistro").Value = oCliente.RecordEnabled
    '            .Parameters("@NumExt").Value = oCliente.NumExt.Trim
    '            .Parameters("@NumInt").Value = oCliente.NumInt.Trim
    '            .Parameters("@RazonNoEmail").Value = oCliente.RazonNoEmail.Trim
    '            .Parameters("@RazonRechazoID").Value = oCliente.RazonRechazoID

    '            'Execute Command
    '            .ExecuteNonQuery()

    '            'Assign Other Values
    '            oCliente.CodigoCliente = .Parameters("@ClienteID").Value
    '            oCliente.CodigoAlterno = .Parameters("@ClienteID").Value
    '            oCliente.RecordCreatedBy = oParent.ApplicationContext.Security.CurrentUser.ID
    '            oCliente.RecordCreatedOn = .Parameters("@Fecha").Value
    '        End With

    '        'Reset New State of Uso Object 
    '        oCliente.ResetFlagNew()
    '        oCliente.SetFlagDirty()

    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

    '    End Try

    'End Function

    Public Function InsertEmailClienteInServer(ByVal ClienteID As String, ByVal Email As String, ByRef strError As String) As Integer

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringServerEmails)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim intID As Integer = 0

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[EmailsClientesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10, "ClienteID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar, 100, "Email"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Canal", System.Data.SqlDbType.VarChar, 10, "Canal"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmailID", System.Data.SqlDbType.Int, 4, "UserID"))

            .Parameters("@EmailID").Direction = ParameterDirection.Output

            'Assign Parameters Values
            .Parameters("@ClienteID").Value = ClienteID.Trim
            .Parameters("@Email").Value = Email.Trim
            .Parameters("@Canal").Value = "T1"
        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values
                intID = .Parameters("@EmailID").Value
            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            strError = oSqlException.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            strError = ex.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        Return intID

    End Function

    '    Private Function InsertSap(ByVal oCliente As ClienteAlterno) As Integer

    '        Dim intResult As Integer

    '        Try

    '            Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '            Dim objFunc As SAPFunctionsOCX.Function
    '            Dim bResultado As Boolean

    '            ''Variables SAP
    '            Dim VKORG As SAPFunctionsOCX.Parameter '	Organización de ventas
    '            Dim VTWEG As SAPFunctionsOCX.Parameter '	Canal de distribución
    '            Dim SPART As SAPFunctionsOCX.Parameter '	Sector
    '            Dim NAME1 As SAPFunctionsOCX.Parameter '	Nombre 1
    '            Dim STRAS As SAPFunctionsOCX.Parameter '	Calle y nº
    '            Dim PSTLZ As SAPFunctionsOCX.Parameter '	Código postal
    '            Dim ORT01 As SAPFunctionsOCX.Parameter '	Población
    '            Dim LAND1 As SAPFunctionsOCX.Parameter '	Clave de país
    '            Dim REGIO As SAPFunctionsOCX.Parameter '	Región (Estado federal, "land", provincia, condado)
    '            Dim TELF1 As SAPFunctionsOCX.Parameter '	1º número de teléfono
    '            Dim TELF2 As SAPFunctionsOCX.Parameter '	2º número de teléfono
    '            Dim STCD1 As SAPFunctionsOCX.Parameter '	Número de identificación fiscal 1
    '            Dim AKONT As SAPFunctionsOCX.Parameter '	Cuenta asociada en la contabilidad principal
    '            Dim ZTERM As SAPFunctionsOCX.Parameter '	Clave de condiciones de pago
    '            Dim BZIRK As SAPFunctionsOCX.Parameter '	Zona de ventas
    '            Dim VKBUR As SAPFunctionsOCX.Parameter '	Oficina de ventas
    '            Dim VKGRP As SAPFunctionsOCX.Parameter '	Grupo de vendedores
    '            Dim WAERS As SAPFunctionsOCX.Parameter '	Moneda
    '            Dim VERSG As SAPFunctionsOCX.Parameter '	Grupo de estadísticas cliente
    '            Dim VSBED As SAPFunctionsOCX.Parameter '	Condición de expedición
    '            Dim VWERK As SAPFunctionsOCX.Parameter '	Centro suministrador (propio o externo)
    '            Dim TAXKD As SAPFunctionsOCX.Parameter '	Clasificación fiscal para el deudor
    '            Dim KTOKD As SAPFunctionsOCX.Parameter '	Grupo de ctas.deudor
    '            Dim ORT02 As SAPFunctionsOCX.Parameter '	Distrito
    '            Dim KNURL As SAPFunctionsOCX.Parameter '	Uniform resource locator
    '            Dim KDGRP As SAPFunctionsOCX.Parameter '	Grupo de clientes
    '            Dim KONDA As SAPFunctionsOCX.Parameter '	Grupo de precios - Cliente
    '            Dim PLTYP As SAPFunctionsOCX.Parameter '	Tipo de lista de precios
    '            Dim LPRIO As SAPFunctionsOCX.Parameter '	Prioridad de entrega
    '            Dim KZAZU As SAPFunctionsOCX.Parameter '	Indicador de agrupamiento de pedidos
    '            Dim ANTLF As SAPFunctionsOCX.Parameter '	Cantidad máxima de entregas parciales permitidas p/posición
    '            Dim KTGRD As SAPFunctionsOCX.Parameter '	Grupo de imputación para cliente
    '            Dim KUNNR As SAPFunctionsOCX.Parameter '    No. de Cliente
    '            Dim PRFRE As SAPFunctionsOCX.Parameter '    Indicador relevante para determinación de precios
    '            Dim I_SORTL As SAPFunctionsOCX.Parameter '    Indicador de Busqueda Rapida
    '            Dim ANRED As SAPFunctionsOCX.Parameter      'Tratamiento
    '            Dim TELX1 As SAPFunctionsOCX.Parameter      'Numero de Telex
    '            Dim EDOCIV As SAPFunctionsOCX.Parameter     'Estado civil
    '            Dim RAZONNOEMAIL As SAPFunctionsOCX.Parameter     'Razon de No Captura de EMail
    '            Dim NUMEXT As SAPFunctionsOCX.Parameter 'Numero Exterior
    '            Dim NUMINT As SAPFunctionsOCX.Parameter 'Numero Interior
    '            Dim RESULT As SAPFunctionsOCX.Parameter '   Indica el resultado de la ejecución de la BAPI

    '            Dim oRETURN As Object '     Parámetro de retorno
    '            Dim MESSTAB As Object '     Acumular mensajes en sistema SAP
    '            ''Fin Declaracion Variables SAB

    '            With objR3.Connection
    '                .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '                .GroupName = oParent.SAPApplicationConfig.GroupName
    '                .System = oParent.SAPApplicationConfig.System
    '                .Client = oParent.SAPApplicationConfig.Client
    '                .User = oParent.SAPApplicationConfig.User
    '                .Password = oParent.SAPApplicationConfig.Password
    '                .language = oParent.SAPApplicationConfig.Language
    '                .SystemNumber = oParent.SAPApplicationConfig.System
    '            End With

    '            If objR3.Connection.logon(0, True) <> True Then
    '                Throw New ApplicationException("No se pudo establecer la coneccion con el Servidor SAP")
    '                Exit Function
    '            End If

    '            objFunc = objR3.Add("ZBAPISD26_ALTACLIENT")

    '            'Exportacion de Valores
    '            VKORG = objFunc.Exports("VKORG")  '	Organización de ventas
    '            VTWEG = objFunc.Exports("VTWEG")  '	Canal de distribución
    '            SPART = objFunc.Exports("SPART")  '	Sector
    '            NAME1 = objFunc.Exports("NAME1")  '	Nombre 1
    '            STRAS = objFunc.Exports("STRAS")  '	Calle y nº
    '            PSTLZ = objFunc.Exports("PSTLZ")  '	Código postal
    '            ORT01 = objFunc.Exports("ORT01")  '	Población
    '            LAND1 = objFunc.Exports("LAND1")  '	Clave de país
    '            REGIO = objFunc.Exports("REGIO")  '	Región (Estado federal, "land", provincia, condado)
    '            TELF1 = objFunc.Exports("TELF1")  '	1º número de teléfono
    '            TELF2 = objFunc.Exports("TELF2")  '	2º número de teléfono
    '            STCD1 = objFunc.Exports("STCD1")  '	Número de identificación fiscal 1
    '            AKONT = objFunc.Exports("AKONT")  '	Cuenta asociada en la contabilidad principal
    '            ZTERM = objFunc.Exports("ZTERM")  '	Clave de condiciones de pago
    '            BZIRK = objFunc.Exports("BZIRK")  '	Zona de ventas
    '            VKBUR = objFunc.Exports("VKBUR")  '	Oficina de ventas
    '            VKGRP = objFunc.Exports("VKGRP")  '	Grupo de vendedores
    '            WAERS = objFunc.Exports("WAERS")  '	Moneda
    '            VERSG = objFunc.Exports("VERSG")  '	Grupo de estadísticas cliente
    '            VSBED = objFunc.Exports("VSBED")  '	Condición de expedición
    '            VWERK = objFunc.Exports("VWERK")  '	Centro suministrador (propio o externo)
    '            TAXKD = objFunc.Exports("TAXKD")  '	Clasificación fiscal para el deudor
    '            KTOKD = objFunc.Exports("KTOKD")  '	Grupo de ctas.deudor
    '            ORT02 = objFunc.Exports("ORT02")  '	Distrito
    '            KNURL = objFunc.Exports("KNURL")  '	Uniform resource locator
    '            KDGRP = objFunc.Exports("KDGRP")  '	Grupo de clientes
    '            KONDA = objFunc.Exports("KONDA")  '	Grupo de precios - Cliente
    '            PLTYP = objFunc.Exports("PLTYP")  '	Tipo de lista de precios
    '            LPRIO = objFunc.Exports("LPRIO")  '	Prioridad de entrega
    '            KZAZU = objFunc.Exports("KZAZU")  '	Indicador de agrupamiento de pedidos
    '            ANTLF = objFunc.Exports("ANTLF")  '	Cantidad máxima de entregas parciales permitidas p/posición
    '            KTGRD = objFunc.Exports("KTGRD")  '	Grupo de imputación para cliente
    '            PRFRE = objFunc.Exports("PRFRE")  ' Indicador relevante para determinación de precios
    '            I_SORTL = objFunc.Exports("I_SORTL") ' Indicador de Busqueda Rapida
    '            ANRED = objFunc.Exports("ANRED") ' Tratamiento
    '            TELX1 = objFunc.Exports("TELX1") ' Numero de Telex
    '            EDOCIV = objFunc.Exports("EDOCIV") 'Estado Civil
    '            RAZONNOEMAIL = objFunc.Exports("RAZONNOEMAIL")     'Razon de No Captura de EMail
    '            NUMEXT = objFunc.Exports("NUMEXT") 'Numero Exterior
    '            NUMINT = objFunc.Exports("NUMINT") 'Numero Interior
    '            'Fin Exportaion de Valores

    '            'Importaciones
    '            KUNNR = objFunc.Imports("KUNNR")
    '            RESULT = objFunc.Imports("RESULT") 'Resultado de la ejecucion de la BAPI
    '            'oRETURN = objFunc.Imports("RETURN")
    '            'Fin Importaciones

    '            'Tables
    '            MESSTAB = objFunc.Tables("MESSTAB")
    '            oRETURN = objFunc.Tables("RETURN")
    '            'Fin Tables

    '            'Asignacion de Valores
    '            VKORG.Value = oCliente.OrganizacionVentas               '	Organización de ventas
    '            VTWEG.Value = oCliente.CanalDistribucion                '	Canal de distribución
    '            SPART.Value = oCliente.Sector                           '	Sector
    '            If oCliente.EsEmpresa Then
    '                Dim strNombres() As String = oCliente.Nombre.Split(" ")
    '                Dim strApeP As String = ""
    '                Dim strApeM As String = ""
    '                Dim strNombre As String = ""
    '                Dim i As Integer = 0

    '                Select Case strNombres.Length
    '                    Case 1
    '                        strApeP = strNombres(0).Trim
    '                        strNombre = strApeP
    '                    Case 2
    '                        strApeP = strNombres(0).Trim
    '                        strApeM = strNombres(1).Trim
    '                        strNombre = strApeP & "_" & strApeM
    '                    Case Is >= 3
    '                        strApeP = strNombres(0).Trim
    '                        strApeM = strNombres(1).Trim
    '                        For i = 2 To strNombres.Length - 1
    '                            strNombre &= strNombres(i) & " "
    '                        Next
    '                        strNombre = strNombre.Trim
    '                        strNombre = strApeP & "_" & strApeM & "_" & strNombre
    '                End Select
    '                NAME1.Value = strNombre      '	Nombre 1
    '                'NAME1.Value = oCliente.Nombre.Trim      '	Nombre 1
    '            Else
    '                NAME1.Value = oCliente.ApellidoPaterno.Trim & "_" & oCliente.ApellidoMaterno.Trim & "_" & oCliente.Nombre.Trim      '	Nombre 1
    '            End If
    '            STRAS.Value = oCliente.Direccion.Trim                   '	Calle y nº
    '            PSTLZ.Value = oCliente.CP.PadLeft(5, "0")               '	Código postal
    '            ORT01.Value = oCliente.Ciudad.Trim                      '	Población
    '            LAND1.Value = oCliente.ClavePais                        '	Clave de país
    '            REGIO.Value = oCliente.Estado                           '	Región (Estado federal, "land", provincia, condado)
    '            TELF1.Value = oCliente.Telefono                         '	1º número de teléfono
    '            TELX1.Value = Format(oCliente.FechaNacimiento, "yyyyMMdd") '	Numero de Telex
    '            If oCliente.RFCMoral <> String.Empty Then
    '                STCD1.Value = oCliente.RFCMoral.Replace("-", "")             '	Número de identificación fiscal 1 Persona Moral
    '            Else
    '                STCD1.Value = oCliente.RFC.Replace("-", "")             '	Número de identificación fiscal 1 Persona Fisica
    '            End If
    '            AKONT.Value = oCliente.CuentaContabilidad               '	Cuenta asociada en la contabilidad principal
    '            ZTERM.Value = oCliente.ClaveCondicionesPago             '	Clave de condiciones de pago
    '            BZIRK.Value = oCliente.ZonaVentas                       '	Zona de ventas

    '            If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
    '                GoTo Cambio_053
    '                ' VKBUR.Value = "C053"  '	Oficina de ventas"
    '            Else
    'Cambio_053:
    '                VKBUR.Value = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen  '	Oficina de ventas
    '            End If


    '            VKGRP.Value = oCliente.CodPlayer                        '	Grupo de vendedores
    '            WAERS.Value = oCliente.Moneda                           '	Moneda
    '            VERSG.Value = oCliente.GrupoEstadistica                 '	Grupo de estadísticas cliente
    '            VSBED.Value = oCliente.CondicionExpedicion              '	Condición de expedición

    '            VWERK.Value = Me.oSapCentro.Read_Centros  '	Centro suministrador (propio o externo)


    '            TAXKD.Value = oCliente.ClasificacionFiscal              '	Clasificación fiscal para el deudor
    '            KTOKD.Value = oCliente.GrupoDeCuentas                   '	Grupo de ctas.deudor
    '            ORT02.Value = oCliente.Colonia                          '	Distrito &&&&&&&&
    '            KNURL.Value = oCliente.EMail.Trim                       '	Uniform resource locator
    '            KDGRP.Value = oCliente.GrupoCliente                     '	Grupo de clientes
    '            KONDA.Value = oCliente.GrupoPrecios                     '	Grupo de precios - Cliente
    '            PLTYP.Value = oCliente.TipoListaPrecios                 '	Tipo de lista de precios
    '            LPRIO.Value = oCliente.PrioridadEntrega                 '	Prioridad de entrega
    '            KZAZU.Value = oCliente.IndicadorAgrupamiento            '	Indicador de agrupamiento de pedidos
    '            ANTLF.Value = oCliente.MaxEntregasParciales             '	Cantidad máxima de entregas parciales permitidas p/posición
    '            If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
    '                'Cambio_053
    '                'KTGRD.Value = "03"      '	Grupo de imputación para cliente -- 03 = Venta Catalogo
    '                KTGRD.Value = "01"
    '            Else
    '                KTGRD.Value = oCliente.GrupoImputacion              '	Grupo de imputación para cliente
    '            End If

    '            PRFRE.Value = oCliente.IndicadorRelevante               '   Indicador relevante para determinación de precios
    '            I_SORTL.Value = oCliente.I_SORTL                        '   Indicador de Busqueda Rapida
    '            'ANRED.Value = IIf(oCliente.Sexo.Trim.ToUpper = "M", "Señor", "Señora")  '   Tratatmiento
    '            Select Case oCliente.Sexo.Trim.ToUpper
    '                Case "M"
    '                    ANRED.Value = "Señor"
    '                Case "F"
    '                    ANRED.Value = "Señora"
    '                Case "E"
    '                    ANRED.Value = "Empresa"
    '                Case Else
    '                    ANRED.Value = ""
    '            End Select
    '            EDOCIV.Value = oCliente.EstadoCivil.Trim
    '            RAZONNOEMAIL.Value = oCliente.RazonNoEmail.Trim
    '            NUMEXT.Value = oCliente.NumExt.Trim
    '            NUMINT.Value = oCliente.NumInt.Trim

    '            'Fin de Asignacion de Valores

    '            bResultado = objFunc.Call

    '            If KUNNR.Value = String.Empty Then
    '                'Throw New ApplicationException(oRETURN.Value("message"))
    'MostrarError:
    '                Dim iRen As Integer
    '                Dim strError As String
    '                strError = String.Empty
    '                For iRen = 1 To oRETURN.ROWCOUNT
    '                    strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(oRETURN(iRen, "message"))
    '                Next iRen

    '                MsgBox(strError, MsgBoxStyle.Exclamation, "Dportenis PRO")

    '                intResult = 0

    '            Else

    '                intResult = 1

    '                oCliente.CodigoAlterno = KUNNR.Value

    '                If RESULT.Value = "E" Then GoTo MostrarError

    '            End If

    '            objR3.Connection.LogOff()

    '        Catch ex As Exception
    '            Throw ex
    '        End Try

    '        Return intResult

    '    End Function

    Private Function InsertSap(ByVal oCliente As ClienteAlterno) As Integer
        '----------------------------------------------------------------------------------
        ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim intResult As Integer

        Dim strExist As String = String.Empty
        Dim dtReturn As New DataTable
        Dim dtMessTab As New DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD26_ALTACLIENT ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD26_ALTACLIENT")

                'Asignacion de Valores
                func.Exports("VKORG").ParamValue = oParent.ConfigCierreFI.OrganizacionCompra     '	Organización de ventas
                func.Exports("VTWEG").ParamValue = oParent.ConfigCierreFI.CanalDistribucion      '	Canal de distribución
                func.Exports("SPART").ParamValue = oParent.ConfigCierreFI.Sector                 '	Sector
                If oCliente.EsEmpresa Then
                    ' Dim strNombres() As String = oCliente.Nombre.Split(" ")
                    'Dim strApeP As String = ""
                    'Dim strApeM As String = ""
                    'Dim strNombre As String = ""
                    'Dim i As Integer = 0

                    'Select Case strNombres.Length
                    '    Case 1
                    '        strApeP = strNombres(0).Trim
                    '        strNombre = strApeP
                    '    Case 2
                    '        strApeP = strNombres(0).Trim
                    '        strApeM = strNombres(1).Trim
                    '        strNombre = strApeP & " " & strApeM
                    '    Case Is >= 3
                    '        strApeP = strNombres(0).Trim
                    '        strApeM = strNombres(1).Trim
                    '        For i = 2 To strNombres.Length - 1
                    '            strNombre &= strNombres(i) & " "
                    '        Next
                    '        strNombre = strNombre.Trim
                    '        strNombre = strNombre & strApeP & " " & strApeM
                    'End Select
                    func.Exports("NAME1").ParamValue = oCliente.Nombre.TrimEnd 'strNombre
                    func.Exports("NAME2").ParamValue = oCliente.ApellidoPaterno
                    'NAME1.Value = oCliente.Nombre.Trim      '	Nombre 1
                Else
                    func.Exports("NAME1").ParamValue = oCliente.Nombre
                    func.Exports("NAME2").ParamValue = oCliente.ApellidoPaterno
                    func.Exports("NAME3").ParamValue = oCliente.ApellidoMaterno
                End If
                func.Exports("STRAS").ParamValue = oCliente.Direccion.Trim                   '	Calle y nº
                func.Exports("PSTLZ").ParamValue = oCliente.CP.PadLeft(5, "0")               '	Código postal
                func.Exports("ORT01").ParamValue = oCliente.Ciudad.Trim                      '	Población
                func.Exports("LAND1").ParamValue = oCliente.ClavePais                        '	Clave de país
                func.Exports("REGIO").ParamValue = oCliente.Estado                           '	Región (Estado federal, "land", provincia, condado)
                func.Exports("TELF1").ParamValue = oCliente.Telefono                         '	1º número de teléfono
                func.Exports("TELX1").ParamValue = Format(oCliente.FechaNacimiento, "yyyyMMdd") '	Numero de Telex
                If oCliente.RFCMoral <> String.Empty Then
                    func.Exports("STCD1").ParamValue = oCliente.RFCMoral.Replace("-", "").ToUpper              '	Número de identificación fiscal 1 Persona Moral
                Else
                    func.Exports("STCD1").ParamValue = oCliente.RFC.Replace("-", "").ToUpper              '	Número de identificación fiscal 1 Persona Fisica
                End If
                func.Exports("AKONT").ParamValue = oCliente.CuentaContabilidad               '	Cuenta asociada en la contabilidad principal
                func.Exports("ZTERM").ParamValue = oCliente.ClaveCondicionesPago             '	Clave de condiciones de pago
                func.Exports("BZIRK").ParamValue = oCliente.ZonaVentas                       '	Zona de ventas

                '                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                '                    GoTo Cambio_053
                '                    ' VKBUR.Value = "C053"  '	Oficina de ventas"
                '                Else
                'Cambio_053:
                '                    func.Exports("VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen  '	Oficina de ventas
                '                End If

                func.Exports("VKGRP").ParamValue = oCliente.CodPlayer                        '	Grupo de vendedores
                func.Exports("WAERS").ParamValue = oCliente.Moneda                           '	Moneda
                func.Exports("VERSG").ParamValue = oCliente.GrupoEstadistica                 '	Grupo de estadísticas cliente
                func.Exports("VSBED").ParamValue = oCliente.CondicionExpedicion              '	Condición de expedición
                If oCliente.TipoVenta.Trim = "D" Or oCliente.TipoVenta.Trim = "DP" Then
                    func.Exports("VWERK").ParamValue = ""  '	Centro suministrador (propio o externo)
                    func.Exports("VKBUR").ParamValue = ""
                    func.Exports("FDGRV").ParamValue = "TC008"
                    func.Exports("TOGRU").ParamValue = "T001"
                    func.Exports("PLTYP").ParamValue = "01" 'oCliente.TipoListaPrecios
                    func.Exports("TIPO_CLIENTE").ParamValue = "DP"
                Else
                    func.Exports("VWERK").ParamValue = Me.oSapCentro.Read_Centros  '	Centro suministrador (propio o externo)
                    func.Exports("VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen  '	Oficina de ventas
                    func.Exports("TIPO_CLIENTE").ParamValue = oCliente.TipoVenta
                End If
                '	Tipo de lista de precios
                func.Exports("TAXKD").ParamValue = oCliente.ClasificacionFiscal              '	Clasificación fiscal para el deudor
                func.Exports("KTOKD").ParamValue = oCliente.GrupoDeCuentas                   '	Grupo de ctas.deudor
                func.Exports("ORT02").ParamValue = oCliente.Colonia                          '	Distrito &&&&&&&&
                func.Exports("EMAIL").ParamValue = oCliente.EMail.Trim                       '	Uniform resource locator
                func.Exports("KDGRP").ParamValue = oCliente.GrupoCliente                     '	Grupo de clientes
                func.Exports("KONDA").ParamValue = oCliente.GrupoPrecios                     '	Grupo de precios - Cliente
                func.Exports("LPRIO").ParamValue = oCliente.PrioridadEntrega                 '	Prioridad de entrega
                func.Exports("KZAZU").ParamValue = oCliente.IndicadorAgrupamiento            '	Indicador de agrupamiento de pedidos
                func.Exports("ANTLF").ParamValue = oCliente.MaxEntregasParciales             '	Cantidad máxima de entregas parciales permitidas p/posición
                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    'Cambio_053
                    'KTGRD.Value = "03"      '	Grupo de imputación para cliente -- 03 = Venta Catalogo
                    func.Exports("KTGRD").ParamValue = "01"
                Else
                    func.Exports("KTGRD").ParamValue = oCliente.GrupoImputacion              '	Grupo de imputación para cliente
                End If

                func.Exports("PRFRE").ParamValue = oCliente.IndicadorRelevante               '   Indicador relevante para determinación de precios
                func.Exports("I_SORTL").ParamValue = oCliente.I_SORTL                        '   Indicador de Busqueda Rapida
                'ANRED.Value = IIf(oCliente.Sexo.Trim.ToUpper = "M", "Señor", "Señora")  '   Tratatmiento
                func.Exports("ANRED").ParamValue = oCliente.Sexo.Trim().ToUpper()
                'Select Case oCliente.Sexo.Trim.ToUpper
                '    Case "M"
                '        func.Exports("ANRED").ParamValue = "Señor"
                '    Case "F"
                '        func.Exports("ANRED").ParamValue = "Señora"
                '    Case "E"
                '        func.Exports("ANRED").ParamValue = "Empresa"
                '    Case Else
                '        func.Exports("ANRED").ParamValue = ""
                'End Select
                func.Exports("EDOCIV").ParamValue = oCliente.EstadoCivil.Trim
                func.Exports("RAZONNOEMAIL").ParamValue = oCliente.RazonNoEmail.Trim
                func.Exports("NUMEXT").ParamValue = oCliente.NumExt.Trim
                func.Exports("NUMINT").ParamValue = oCliente.NumInt.Trim
                'Fin de Asignacion de Valores

                func.Execute()

                dtReturn = func.Tables("RETURN").ToADOTable()
                dtMessTab = func.Tables("MESSTAB").ToADOTable()

                If func.Imports("KUNNR").ToString.Trim = String.Empty Then
                    'Throw New ApplicationException(oRETURN.Value("message"))
MostrarError:
                    'Dim iRen As Integer
                    Dim strError As String
                    strError = String.Empty
                    For Each row As DataRow In dtReturn.Rows
                        strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(row("MESSAGE")) & vbCrLf
                    Next

                    MsgBox(strError, MsgBoxStyle.Exclamation, "Dportenis PRO")

                    intResult = 0

                Else

                    intResult = 1

                    oCliente.CodigoAlterno = func.Imports("KUNNR").ParamValue.ToString.Trim

                    If func.Imports("RESULT").ToString = "E" Then GoTo MostrarError

                End If

                R3.Close()

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return intResult

    End Function


    Public Function Update(ByVal oCliente As ClienteAlterno, Optional ByVal EsDPVale As Boolean = False) As Boolean

        If Not EsDPVale Then
            'SE ACTUALIZA EN SAP EL CLIENTE
            If oCliente.TipoVenta.Trim <> "P" Then
                'oSAPMgr.ZBAPI_ELIMINAEMAILS(oCliente.CodigoAlterno)
                If UpdateSap(oCliente) = 0 Then
                    If Not EsDPVale Then
                        Return False
                    End If
                End If
            End If
        End If

        ''--------------------------------------------------------------------------------------------
        '' JNAVA (16.04.2016): Validamos si existe cliente en AFS para actualizarlo o crearlo
        ''--------------------------------------------------------------------------------------------
        'If Not ClienteAFS(oCliente, EsDPVale) Then
        '    If EsDPVale Then
        '        Return False
        '    End If
        'End If

        '-------------------------------------------------------------------------------------------------
        ' JNAVA (12.07.2016): Valida DPVale en S2Credit si esta activo como validador
        '-------------------------------------------------------------------------------------------------
        If oParent.ConfigCierreFI.AplicarS2Credit Then
            '-------------------------------------------------------------------------------------------------
            ' Guardamos el cliente en S2Credit
            '-------------------------------------------------------------------------------------------------
            If EsDPVale Then
                oCliente.CodigoAlterno = oS2Credit.SaveCliente(oCliente)
                If oCliente.CodigoAlterno Is Nothing OrElse oCliente.CodigoAlterno.Trim = "".PadLeft(10, "0") Then
                    Return False
                End If
            End If
        Else
            '--------------------------------------------------------------------------------------------
            ' JNAVA (16.04.2016): Validamos si existe cliente en AFS para actualizarlo o crearlo
            '--------------------------------------------------------------------------------------------
            If Not ClienteAFS(oCliente, EsDPVale) Then
                If EsDPVale Then
                    Return False
                End If
            End If
        End If
        '-------------------------------------------------------------------------------------------------

        'If oCliente.GrupoDeCuentas = "D019" Then

        '    Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        '    Dim sccmdInsert As SqlCommand
        '    sccmdInsert = New SqlCommand

        '    With sccmdInsert

        '        .Connection = sccnnConnection

        '        .CommandText = "[ClientesUpd]"
        '        .CommandType = System.Data.CommandType.StoredProcedure

        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '        '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodigoCliente", System.Data.SqlDbType.Int, 4))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodigoAlterno", System.Data.SqlDbType.VarChar, 10, "CodAlterno"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 30, "Nombre"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Apellido", System.Data.SqlDbType.VarChar, 60, "Apellido"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sexo", System.Data.SqlDbType.VarChar, 1, "Sexo"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EstadoCivil", System.Data.SqlDbType.VarChar, 12, "EstadoCivil"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Direccion", System.Data.SqlDbType.VarChar, 50, "Direccion"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 50, "Estado"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 50, "Ciudad"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Colonia", System.Data.SqlDbType.VarChar, 50, "Colonia"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CP", System.Data.SqlDbType.Char, 5, "CP"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.VarChar, 30, "Telefono"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaNacimiento", System.Data.SqlDbType.DateTime, 8, "FechaNacimiento"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EMail", System.Data.SqlDbType.VarChar, 50, "EMail"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3, "CodAlmacen"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPlaza", System.Data.SqlDbType.VarChar, 3, "CodPlaza"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RFC", System.Data.SqlDbType.VarChar, 15, "RFC"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 50, "TipoVenta"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Player", System.Data.SqlDbType.VarChar, 5, "Player"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroExt", System.Data.SqlDbType.VarChar, 10, "NumeroExt"))
        '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroInt", System.Data.SqlDbType.VarChar, 10, "NumeroInt"))
        '    End With

        '    Try

        '        sccnnConnection.Open()

        '        With sccmdInsert
        '            'Assign Parameters Values
        '            '.Parameters("@CodigoCliente").Value = oCliente.CodigoCliente
        '            .Parameters("@CodigoAlterno").Value = oCliente.CodigoAlterno
        '            .Parameters("@Nombre").Value = oCliente.Nombre
        '            .Parameters("@Apellido").Value = oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
        '            .Parameters("@Sexo").Value = oCliente.Sexo
        '            .Parameters("@EstadoCivil").Value = oCliente.EstadoCivil
        '            .Parameters("@Direccion").Value = oCliente.Direccion
        '            .Parameters("@Estado").Value = oCliente.Estado
        '            .Parameters("@Ciudad").Value = oCliente.Ciudad
        '            .Parameters("@Colonia").Value = oCliente.Colonia
        '            .Parameters("@NumeroExt").Value = oCliente.NumExt
        '            .Parameters("@NumeroInt").Value = oCliente.NumInt
        '            .Parameters("@CP").Value = oCliente.CP.PadLeft(5, "0")
        '            .Parameters("@Telefono").Value = oCliente.Telefono
        '            .Parameters("@FechaNacimiento").Value = Format(oCliente.FechaNacimiento, "dd/MM/yyyy")
        '            .Parameters("@EMail").Value = oCliente.EMail
        '            .Parameters("@CodAlmacen").Value = Me.oSapCentro.Read_Centros
        '            .Parameters("@CodPlaza").Value = oCliente.CodPlaza
        '            'If oCliente.RFCMoral <> String.Empty Then
        '            '.Parameters("@RFC").Value = oCliente.RFCMoral 'Persona Moral
        '            'Else
        '            .Parameters("@RFC").Value = oCliente.RFC 'Persona Fisica
        '            'End If
        '            .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.ID
        '            .Parameters("@StatusRegistro").Value = oCliente.RecordEnabled
        '            .Parameters("@Player").Value = oCliente.CodPlayer
        '            .Parameters("@TipoVenta").Value = oCliente.TipoVenta
        '            .Parameters("@Fecha").Value = Now.ToShortDateString

        '            'Execute Command
        '            .ExecuteNonQuery()

        '            'Assign Other Values
        '            'oCliente.CodigoCliente = .Parameters("@CodigoCliente").Value
        '            oCliente.RecordCreatedBy = oParent.ApplicationContext.Security.CurrentUser.ID
        '            oCliente.RecordCreatedOn = .Parameters("@Fecha").Value
        '        End With

        '        'Reset New State of Uso Object 
        '        oCliente.ResetFlagNew()
        '        oCliente.SetFlagDirty()

        '        sccnnConnection.Close()

        '    Catch oSqlException As SqlException

        '        If (sccnnConnection.State <> ConnectionState.Closed) Then
        '            Try
        '                sccnnConnection.Close()
        '            Catch
        '            End Try
        '        End If

        '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        '    Catch ex As Exception

        '        If (sccnnConnection.State <> ConnectionState.Closed) Then
        '            Try
        '                sccnnConnection.Close()
        '            Catch
        '            End Try
        '        End If

        '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        '    End Try

        'ElseIf oCliente.TipoVenta.Trim = "P" Then

        '    Dim strValor As String = ""

        '    Try
        '        'strValor = Me.SelectConfig("GuardarServer").Trim
        '        'If strValor.Trim = "" Then strValor = "SI"

        '        'If strValor.Trim = "SI" Then Me.InsertClientePGInServer(oCliente)
        '        Me.InsertClientePGInServer(oCliente)
        '    Catch ex As Exception
        '    End Try

        '    Me.InsertClientePG(oCliente)

        'Else

        Dim oClienteSAP As New ClientesSAP

        oClienteSAP.Apellidos = oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
        oClienteSAP.Ciudad = oCliente.Ciudad
        oClienteSAP.Clienteid = oCliente.CodigoAlterno
        oClienteSAP.Codalmacen = Me.oSapCentro.Read_Centros
        oClienteSAP.CodPlaza = oCliente.CodPlaza
        oClienteSAP.Colonia = oCliente.Colonia
        oClienteSAP.Cp = oCliente.CP.PadLeft(5, "0")
        oClienteSAP.Domicilio = oCliente.Direccion
        oClienteSAP.Email = oCliente.EMail
        oClienteSAP.Estado = oCliente.Estado
        oClienteSAP.NumeroExterior = oCliente.NumExt
        oClienteSAP.NumeroInterior = oCliente.NumInt
        oClienteSAP.Estadocivil = oCliente.EstadoCivil
        oClienteSAP.Fecha = oCliente.RecordCreatedOn
        oClienteSAP.Fechanac = oCliente.FechaNacimiento
        oClienteSAP.Nombre = oCliente.Nombre
        oClienteSAP.Sexo = oCliente.Sexo
        oClienteSAP.Statusregistro = oCliente.RecordEnabled
        oClienteSAP.Telefono = oCliente.Telefono
        oClienteSAP.Usuario = ""
        oClienteSAP.Player = oCliente.CodPlayer
        'If oCliente.RFCMoral <> String.Empty Then
        'oClienteSAP.RFC = oCliente.RFCMoral 'Persona Moral
        'Else
        oClienteSAP.RFC = oCliente.RFC.ToUpper 'Persona Fisica
        'End If
        Me.oSapCentro.Write_Clientes(oClienteSAP)

        'End If

        Return True

    End Function


    Public Sub UpdateSAPX(ByVal strClienteID As String, ByVal strCalleNum As String, ByVal strCp As String, _
                                ByVal strPoblacion As String, ByVal strEstado As String, ByVal strTelefono As String, ByVal stremail As String _
                                , ByVal strColonia As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ClientesSAPUpdateX]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@clienteid", System.Data.SqlDbType.VarChar, 10, "clienteid"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@domicilio", System.Data.SqlDbType.VarChar, 50, "domicilio"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 50, "Estado"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 50, "Ciudad"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Colonia", System.Data.SqlDbType.VarChar, 50, "Colonia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CP", System.Data.SqlDbType.Char, 5, "CP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.VarChar, 30, "Telefono"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EMail", System.Data.SqlDbType.VarChar, 50, "EMail"))
        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@clienteid").Value = strClienteID
                .Parameters("@domicilio").Value = strCalleNum
                .Parameters("@Estado").Value = strEstado
                .Parameters("@Ciudad").Value = strPoblacion
                .Parameters("@Colonia").Value = strColonia
                .Parameters("@CP").Value = strCp.PadLeft(5, "0")
                .Parameters("@Telefono").Value = strTelefono
                .Parameters("@EMail").Value = stremail
                'Execute Command
                .ExecuteNonQuery()
            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

    End Sub

    Public Function ActualizaClientes(ByVal strClienteID As String, ByVal strCalleNum As String, ByVal strCp As String, _
 ByVal strPoblacion As String, ByVal strEstado As String, ByVal strTelefono As String, ByVal stremail As String _
 , ByVal strColonia As String) As String


        Return oSapCentro.ActualizaClientes(strClienteID, strCalleNum, strCp, strPoblacion, strEstado, strTelefono, stremail, strColonia)


    End Function

    '    Private Function UpdateSap(ByVal oCliente As ClienteAlterno) As Integer

    '        Dim intResult As Integer

    '        Try

    '            Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '            Dim objFunc As SAPFunctionsOCX.Function
    '            Dim bResultado As Boolean

    '            ''Variables SAP
    '            Dim KUNNR As SAPFunctionsOCX.Parameter '	Nº de cliente 1 X
    '            Dim NAME1 As SAPFunctionsOCX.Parameter '	Nombre 1 X
    '            Dim STRAS As SAPFunctionsOCX.Parameter '	Calle y nº X
    '            Dim PSTLZ As SAPFunctionsOCX.Parameter '	Código postal X
    '            Dim ORT01 As SAPFunctionsOCX.Parameter '	Población  X
    '            Dim LAND1 As SAPFunctionsOCX.Parameter '	'MX'	Clave de país X
    '            Dim REGIO As SAPFunctionsOCX.Parameter '	'SIN'	Región (Estado federal, "land", provincia, condado)X
    '            Dim TELF1 As SAPFunctionsOCX.Parameter '	1º número de teléfono X
    '            Dim TELF2 As SAPFunctionsOCX.Parameter '	2º número de teléfono X
    '            Dim STCD1 As SAPFunctionsOCX.Parameter '	Número de identificación fiscal 1 X
    '            Dim AKONT As SAPFunctionsOCX.Parameter '	Cuenta asociada en la contabilidad principal X
    '            Dim ZTERM As SAPFunctionsOCX.Parameter '	Clave de condiciones de pago X
    '            Dim BZIRK As SAPFunctionsOCX.Parameter '	Zona de ventas X 
    '            Dim VKBUR As SAPFunctionsOCX.Parameter '	Oficina de ventas X
    '            Dim VKGRP As SAPFunctionsOCX.Parameter '	Grupo de vendedores X
    '            Dim WAERS As SAPFunctionsOCX.Parameter '	Moneda X
    '            Dim VERSG As SAPFunctionsOCX.Parameter '	Grupo de estadísticas cliente X
    '            Dim VSBED As SAPFunctionsOCX.Parameter '	Condición de expedición X
    '            Dim VWERK As SAPFunctionsOCX.Parameter '	Centro suministrador (propio o externo) X
    '            Dim TAXKD As SAPFunctionsOCX.Parameter '	Clasificación fiscal para el deudor X
    '            Dim VKORG As SAPFunctionsOCX.Parameter '	'CDPT'	Organización de ventas X
    '            Dim VTWEG As SAPFunctionsOCX.Parameter '	'T1'	Canal de distribución X
    '            Dim SPART As SAPFunctionsOCX.Parameter '	'VG'	Sector X
    '            Dim ORT02 As SAPFunctionsOCX.Parameter '	Distrito X
    '            Dim KNURL As SAPFunctionsOCX.Parameter '	Uniform resource locator X
    '            Dim KDGRP As SAPFunctionsOCX.Parameter '	Grupo de clientes X
    '            Dim KONDA As SAPFunctionsOCX.Parameter '	Grupo de precios - Cliente X
    '            Dim PLTYP As SAPFunctionsOCX.Parameter '	Tipo de lista de precios X
    '            Dim LPRIO As SAPFunctionsOCX.Parameter '	Prioridad de entrega X
    '            Dim KZAZU As SAPFunctionsOCX.Parameter '	Indicador de agrupamiento de pedidos X
    '            Dim ANTLF As SAPFunctionsOCX.Parameter '	Cantidad máxima de entregas parciales permitidas p/posición X
    '            Dim KTGRD As SAPFunctionsOCX.Parameter '	Grupo de imputación para cliente X
    '            Dim BUKRS As SAPFunctionsOCX.Parameter '	'CDPT'	Sociedad #########
    '            Dim ANRED As SAPFunctionsOCX.Parameter '	Tratamiento ######
    '            Dim FDGRV As SAPFunctionsOCX.Parameter '	Grupo de tesorería ######
    '            Dim ALTKN As SAPFunctionsOCX.Parameter '	Número de registro maestro anterior #####
    '            Dim WITHT As SAPFunctionsOCX.Parameter '	Indicador para tipo de retenciones #######
    '            Dim PARVW As SAPFunctionsOCX.Parameter '	Función de interlocutor ######
    '            Dim PRFRE As SAPFunctionsOCX.Parameter '	'X'	Indicador relevante para determinación de precios X
    '            Dim RESULT As SAPFunctionsOCX.Parameter '   Indica el resultado de la ejecución de la BAPI
    '            Dim TELX1 As SAPFunctionsOCX.Parameter '    Numero de Telex
    '            Dim EDOCIV As SAPFunctionsOCX.Parameter '   Estado civil
    '            Dim RAZONNOEMAIL As SAPFunctionsOCX.Parameter     'Razon de No Captura de EMail
    '            Dim NUMEXT As SAPFunctionsOCX.Parameter 'Numero Exterior
    '            Dim NUMINT As SAPFunctionsOCX.Parameter 'Numero Interior

    '            Dim oRETURN As Object '     Parámetro de retorno
    '            Dim MESSTAB As Object '     Acumular mensajes en sistema SAP
    '            ''Fin Declaracion Variables SAB


    '            With objR3.Connection
    '                .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '                .GroupName = oParent.SAPApplicationConfig.GroupName
    '                .System = oParent.SAPApplicationConfig.System
    '                .Client = oParent.SAPApplicationConfig.Client
    '                .User = oParent.SAPApplicationConfig.User
    '                .Password = oParent.SAPApplicationConfig.Password
    '                .language = oParent.SAPApplicationConfig.Language
    '                .SystemNumber = oParent.SAPApplicationConfig.System
    '            End With

    '            If objR3.Connection.logon(0, True) <> True Then
    '                Throw New ApplicationException("No se pudo establecer la coneccion con el Servidor SAP")
    '                Exit Function
    '            End If

    '            objFunc = objR3.Add("ZBAPISD26_MODIFCLIENT")

    '            'Exportacion de Valores
    '            VKORG = objFunc.Exports("VKORG")  '	Organización de ventas
    '            VTWEG = objFunc.Exports("VTWEG")  '	Canal de distribución
    '            SPART = objFunc.Exports("SPART")  '	Sector
    '            NAME1 = objFunc.Exports("NAME1")  '	Nombre 1
    '            STRAS = objFunc.Exports("STRAS")  '	Calle y nº
    '            PSTLZ = objFunc.Exports("PSTLZ")  '	Código postal
    '            ORT01 = objFunc.Exports("ORT01")  '	Población
    '            LAND1 = objFunc.Exports("LAND1")  '	Clave de país
    '            REGIO = objFunc.Exports("REGIO")  '	Región (Estado federal, "land", provincia, condado)
    '            TELF1 = objFunc.Exports("TELF1")  '	1º número de teléfono
    '            TELF2 = objFunc.Exports("TELF2")  '	2º número de teléfono
    '            STCD1 = objFunc.Exports("STCD1")  '	Número de identificación fiscal 1
    '            AKONT = objFunc.Exports("AKONT")  '	Cuenta asociada en la contabilidad principal
    '            ZTERM = objFunc.Exports("ZTERM")  '	Clave de condiciones de pago
    '            BZIRK = objFunc.Exports("BZIRK")  '	Zona de ventas
    '            VKBUR = objFunc.Exports("VKBUR")  '	Oficina de ventas
    '            VKGRP = objFunc.Exports("VKGRP")  '	Grupo de vendedores
    '            WAERS = objFunc.Exports("WAERS")  '	Moneda
    '            VERSG = objFunc.Exports("VERSG")  '	Grupo de estadísticas cliente
    '            VSBED = objFunc.Exports("VSBED")  '	Condición de expedición
    '            VWERK = objFunc.Exports("VWERK")  '	Centro suministrador (propio o externo)
    '            TAXKD = objFunc.Exports("TAXKD")  '	Clasificación fiscal para el deudor
    '            ORT02 = objFunc.Exports("ORT02")  '	Distrito
    '            KNURL = objFunc.Exports("KNURL")  '	Uniform resource locator
    '            KDGRP = objFunc.Exports("KDGRP")  '	Grupo de clientes
    '            KONDA = objFunc.Exports("KONDA")  '	Grupo de precios - Cliente
    '            PLTYP = objFunc.Exports("PLTYP")  '	Tipo de lista de precios
    '            LPRIO = objFunc.Exports("LPRIO")  '	Prioridad de entrega
    '            KZAZU = objFunc.Exports("KZAZU")  '	Indicador de agrupamiento de pedidos
    '            ANTLF = objFunc.Exports("ANTLF")  '	Cantidad máxima de entregas parciales permitidas p/posición
    '            KTGRD = objFunc.Exports("KTGRD")  '	Grupo de imputación para cliente
    '            PRFRE = objFunc.Exports("PRFRE")  ' Indicador relevante para determinación de precios
    '            KUNNR = objFunc.Exports("KUNNR")

    '            KTGRD = objFunc.Exports("KTGRD")  ' Grupo de imputación para cliente
    '            BUKRS = objFunc.Exports("BUKRS")  ' Sociedad
    '            ANRED = objFunc.Exports("ANRED")  ' Tratamiento
    '            FDGRV = objFunc.Exports("FDGRV")  ' Grupo de Tesoreria  
    '            ALTKN = objFunc.Exports("ALTKN")  ' Número de registro maestro anterior
    '            WITHT = objFunc.Exports("WITHT")  ' Indicador para tipo de retenciones
    '            PARVW = objFunc.Exports("PARVW")
    '            TELX1 = objFunc.Exports("TELX1")  ' Numero de Telex
    '            EDOCIV = objFunc.Exports("EDOCIV")  ' Estado Civil
    '            RAZONNOEMAIL = objFunc.Exports("RAZONNOEMAIL")  ' Razon de No Captura de Email
    '            NUMEXT = objFunc.Exports("NUMEXT") 'Numero Exterior
    '            NUMINT = objFunc.Exports("NUMINT") 'Numero Interior

    '            'Fin Exportaion de Valores

    '            'Importaciones
    '            RESULT = objFunc.Imports("RESULT")
    '            'oRETURN = objFunc.Imports("RETURN")
    '            'Fin Importaciones

    '            'Tables
    '            MESSTAB = objFunc.Tables("MESSTAB")
    '            oRETURN = objFunc.Tables("RETURN")
    '            'Fin Tables

    '            'Asignacion de Valores
    '            KUNNR.Value = oCliente.CodigoAlterno
    '            VKORG.Value = oCliente.OrganizacionVentas               '	Organización de ventas
    '            VTWEG.Value = oCliente.CanalDistribucion                '	Canal de distribución
    '            SPART.Value = oCliente.Sector                           '	Sector
    '            If oCliente.EsEmpresa Then
    '                Dim strNombres() As String = oCliente.Nombre.Split(" ")
    '                Dim strApeP As String = ""
    '                Dim strApeM As String = ""
    '                Dim strNombre As String = ""
    '                Dim i As Integer = 0

    '                Select Case strNombres.Length
    '                    Case 1
    '                        strApeP = strNombres(0).Trim
    '                        strNombre = strApeP
    '                    Case 2
    '                        strApeP = strNombres(0).Trim
    '                        strApeM = strNombres(1).Trim
    '                        strNombre = strApeP & "_" & strApeM
    '                    Case Is >= 3
    '                        strApeP = strNombres(0).Trim
    '                        strApeM = strNombres(1).Trim
    '                        For i = 2 To strNombres.Length - 1
    '                            strNombre &= strNombres(i) & " "
    '                        Next
    '                        strNombre = strNombre.Trim
    '                        strNombre = strApeP & "_" & strApeM & "_" & strNombre
    '                End Select
    '                NAME1.Value = strNombre      '	Nombre 1
    '                'NAME1.Value = oCliente.Nombre.Trim      '	Nombre 1
    '            Else
    '                NAME1.Value = oCliente.ApellidoPaterno.Trim & "_" & oCliente.ApellidoMaterno.Trim & "_" & oCliente.Nombre.Trim      '	Nombre 1
    '            End If
    '            'NAME1.Value = oCliente.ApellidoPaterno & "_" & oCliente.ApellidoMaterno & "_" & oCliente.Nombre.Trim   '	Nombre 1
    '            STRAS.Value = oCliente.Direccion.Trim                         '	Calle y nº
    '            PSTLZ.Value = oCliente.CP.PadLeft(5, "0")               '	Código postal
    '            ORT01.Value = oCliente.Ciudad.Trim                      '	Población
    '            LAND1.Value = oCliente.ClavePais                        '	Clave de país
    '            REGIO.Value = oCliente.Estado                           '	Región (Estado federal, "land", provincia, condado)
    '            TELF1.Value = oCliente.Telefono                         '	1º número de teléfono
    '            TELX1.Value = Format(oCliente.FechaNacimiento, "yyyyMMdd") ' Numero de telex
    '            If oCliente.RFCMoral <> String.Empty Then
    '                STCD1.Value = oCliente.RFCMoral.Replace("-", "")             '	Número de identificación fiscal 1 Persona Moral
    '            Else
    '                STCD1.Value = oCliente.RFC.Replace("-", "")             '	Número de identificación fiscal 1 Persona Fisica
    '            End If
    '            ''  STCD1.Value = oCliente.RFC.Replace("-", "")             '	Número de identificación fiscal 1
    '            AKONT.Value = oCliente.CuentaContabilidad               '	Cuenta asociada en la contabilidad principal
    '            ZTERM.Value = oCliente.ClaveCondicionesPago             '	Clave de condiciones de pago
    '            BZIRK.Value = oCliente.ZonaVentas            '	Zona de ventas

    '            If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
    '                GoTo Cambio_053
    '                'VKBUR.Value = "C053"
    '            Else
    'Cambio_053:
    '                VKBUR.Value = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen  '	Oficina de ventas
    '            End If


    '            VKGRP.Value = oCliente.CodPlayer                        '	Grupo de vendedores
    '            WAERS.Value = oCliente.Moneda                           '	Moneda
    '            VERSG.Value = oCliente.GrupoEstadistica                 '	Grupo de estadísticas cliente
    '            VSBED.Value = oCliente.CondicionExpedicion              '	Condición de expedición
    '            VWERK.Value = Me.oSapCentro.Read_Centros                '	Centro suministrador (propio o externo)
    '            TAXKD.Value = oCliente.ClasificacionFiscal              '	Clasificación fiscal para el deudor
    '            ORT02.Value = oCliente.Colonia                          '	Distrito &&&&&&&&
    '            KNURL.Value = oCliente.EMail.Trim                       '	Uniform resource locator
    '            KDGRP.Value = oCliente.GrupoCliente                     '	Grupo de clientes
    '            KONDA.Value = oCliente.GrupoPrecios                     '	Grupo de precios - Cliente
    '            PLTYP.Value = oCliente.TipoListaPrecios                 '	Tipo de lista de precios
    '            LPRIO.Value = oCliente.PrioridadEntrega                 '	Prioridad de entrega
    '            KZAZU.Value = oCliente.IndicadorAgrupamiento            '	Indicador de agrupamiento de pedidos
    '            ANTLF.Value = oCliente.MaxEntregasParciales             '	Cantidad máxima de entregas parciales permitidas p/posición
    '            If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
    '                'Cambio_053
    '                'KTGRD.Value = "03"
    '                KTGRD.Value = "01"
    '            Else
    '                KTGRD.Value = oCliente.GrupoImputacion                  '	Grupo de imputación para cliente
    '            End If

    '            PRFRE.Value = oCliente.IndicadorRelevante               '   Indicador relevante para determinación de precios
    '            BUKRS.Value = oCliente.OrganizacionVentas   ' Sociedad

    '            'ANRED.Value = IIf(oCliente.Sexo.Trim.ToUpper = "M", "Señor", "Señora") ' Tratamiento
    '            Select Case oCliente.Sexo.Trim.ToUpper
    '                Case "M"
    '                    ANRED.Value = "Señor"
    '                Case "F"
    '                    ANRED.Value = "Señora"
    '                Case "E"
    '                    ANRED.Value = "Empresa"
    '                Case Else
    '                    ANRED.Value = ""
    '            End Select
    '            EDOCIV.Value = oCliente.EstadoCivil.Trim
    '            RAZONNOEMAIL.Value = oCliente.RazonNoEmail.Trim
    '            NUMEXT.Value = oCliente.NumExt
    '            NUMINT.Value = oCliente.NumInt
    '            FDGRV.Value = "Z3"  ' Grupo de Tesoreria  
    '            ALTKN.Value = ""  ' Número de registro maestro anterior
    '            WITHT.Value = ""  ' Indicador para tipo de retenciones
    '            PARVW.Value = ""
    '            'Fin de Asignacion de Valores

    '            bResultado = objFunc.Call

    '            'If oRETURN.Value("type") = "E" Then
    '            If RESULT.Value = "E" Then
    '                'Throw New ApplicationException(oRETURN.Value("message"))
    '                Dim iRen As Integer
    '                Dim strError As String
    '                strError = String.Empty
    '                For iRen = 1 To oRETURN.ROWCOUNT
    '                    strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(oRETURN(iRen, "message"))
    '                Next iRen

    '                MsgBox(strError, MsgBoxStyle.Exclamation, "Dportenis PRO")

    '                intResult = 0

    '            Else

    '                intResult = 1

    '                oCliente.CodigoAlterno = KUNNR.Value

    '            End If

    '            objR3.Connection.LogOff()


    '        Catch ex As Exception
    '            Throw ex
    '        End Try

    '        Return intResult

    '    End Function

    Private Function UpdateSap(ByVal oCliente As ClienteAlterno) As Integer
        '----------------------------------------------------------------------------------
        ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim intResult As Integer

        Dim strExist As String = String.Empty
        Dim dtReturn As New DataTable
        Dim dtMessTab As New DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD26_MODIFCLIENT ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD26_MODIFCLIENT")

                'Asignacion de Valores
                func.Exports("KUNNR").ParamValue = oCliente.CodigoAlterno
                func.Exports("VKORG").ParamValue = oParent.ConfigCierreFI.OrganizacionCompra               '	Organización de ventas
                func.Exports("VTWEG").ParamValue = oParent.ConfigCierreFI.CanalDistribucion               '	Canal de distribución
                func.Exports("SPART").ParamValue = oParent.ConfigCierreFI.Sector                           '	Sector
                If oCliente.EsEmpresa Then
                    'Dim strNombres() As String = oCliente.Nombre.Split(" ")
                    'Dim strApeP As String = ""
                    'Dim strApeM As String = ""
                    'Dim strNombre As String = ""
                    'Dim i As Integer = 0

                    'Select Case strNombres.Length
                    '    Case 1
                    '        strApeP = strNombres(0).Trim
                    '        strNombre = strApeP
                    '    Case 2
                    '        strApeP = strNombres(0).Trim
                    '        strApeM = strNombres(1).Trim
                    '        strNombre = strApeP & " " & strApeM
                    '    Case Is >= 3
                    '        strApeP = strNombres(0).Trim
                    '        strApeM = strNombres(1).Trim
                    '        For i = 2 To strNombres.Length - 1
                    '            strNombre &= strNombres(i) & " "
                    '        Next
                    '        strNombre = strNombre.Trim
                    '        strNombre = strNombre & " " & strApeP & " " & strApeM
                    'End Select
                    func.Exports("NAME1").ParamValue = oCliente.Nombre.TrimEnd 'strNombre      '	Nombre 1
                    func.Exports("NAME2").ParamValue = oCliente.ApellidoPaterno.TrimEnd
                    'NAME1.Value = oCliente.Nombre.Trim      '	Nombre 1
                Else
                    func.Exports("NAME1").ParamValue = oCliente.Nombre
                    func.Exports("NAME2").ParamValue = oCliente.ApellidoPaterno
                    func.Exports("NAME3").ParamValue = oCliente.ApellidoMaterno
                End If
                'NAME1.Value = oCliente.ApellidoPaterno & "_" & oCliente.ApellidoMaterno & "_" & oCliente.Nombre.Trim   '	Nombre 1
                func.Exports("STRAS").ParamValue = oCliente.Direccion.Trim                      '	Calle y nº
                func.Exports("PSTLZ").ParamValue = oCliente.CP.PadLeft(5, "0")                  '	Código postal
                func.Exports("ORT01").ParamValue = oCliente.Ciudad.Trim                         '	Población
                func.Exports("LAND1").ParamValue = oCliente.ClavePais                           '	Clave de país
                func.Exports("REGIO").ParamValue = oCliente.Estado                              '	Región (Estado federal, "land", provincia, condado)
                func.Exports("TELF1").ParamValue = oCliente.Telefono                            '	1º número de teléfono
                func.Exports("TELX1").ParamValue = Format(oCliente.FechaNacimiento, "yyyyMMdd") ' Numero de telex
                If oCliente.RFCMoral <> String.Empty Then
                    func.Exports("STCD1").ParamValue = oCliente.RFCMoral.Replace("-", "").ToUpper             '	Número de identificación fiscal 1 Persona Moral
                Else
                    func.Exports("STCD1").ParamValue = oCliente.RFC.Replace("-", "").ToUpper '	Número de identificación fiscal 1 Persona Fisica
                End If
                ''  STCD1.Value = oCliente.RFC.Replace("-", "")                              '	Número de identificación fiscal 1
                func.Exports("AKONT").ParamValue = oCliente.CuentaContabilidad               '	Cuenta asociada en la contabilidad principal
                func.Exports("ZTERM").ParamValue = oCliente.ClaveCondicionesPago             '	Clave de condiciones de pago
                func.Exports("BZIRK").ParamValue = oCliente.ZonaVentas                       '	Zona de ventas
                'func.Exports("TIPO_CLIENTE").ParamValue = oCliente.TipoVenta

                '                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                '                    GoTo Cambio_053
                '                    'VKBUR.Value = "C053"
                '                Else
                'Cambio_053:
                '                    func.Exports("VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen  '	Oficina de ventas
                '                End If

                If oCliente.TipoVenta.Trim = "DP" Then
                    func.Exports("VWERK").ParamValue = ""  '	Centro suministrador (propio o externo)
                    func.Exports("VKBUR").ParamValue = ""
                    func.Exports("FDGRV").ParamValue = "TC008"
                    ' func.Exports("TOGRU").ParamValue = "T001"
                    func.Exports("PLTYP").ParamValue = "01" 'oCliente.TipoListaPrecios
                    func.Exports("TIPO_CLIENTE").ParamValue = "DP"
                Else
                    func.Exports("VWERK").ParamValue = Me.oSapCentro.Read_Centros  '	Centro suministrador (propio o externo)
                    func.Exports("VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen  '	Oficina de ventas
                    'func.Exports("PLTYP").ParamValue = oCliente.TipoListaPrecios                 '	Tipo de lista de precios
                    func.Exports("TIPO_CLIENTE").ParamValue = oCliente.TipoVenta '	Tipo de lista de precios
                End If

                func.Exports("VKGRP").ParamValue = oCliente.CodPlayer                        '	Grupo de vendedores
                func.Exports("WAERS").ParamValue = oCliente.Moneda                           '	Moneda
                func.Exports("VERSG").ParamValue = oCliente.GrupoEstadistica                 '	Grupo de estadísticas cliente
                func.Exports("VSBED").ParamValue = oCliente.CondicionExpedicion              '	Condición de expedición
                'func.Exports("VWERK").ParamValue = Me.oSapCentro.Read_Centros                '	Centro suministrador (propio o externo)
                func.Exports("TAXKD").ParamValue = oCliente.ClasificacionFiscal              '	Clasificación fiscal para el deudor
                func.Exports("ORT02").ParamValue = oCliente.Colonia                          '	Distrito &&&&&&&&
                func.Exports("EMAIL").ParamValue = oCliente.EMail.Trim                       '	Uniform resource locator
                func.Exports("KDGRP").ParamValue = oCliente.GrupoCliente                     '	Grupo de clientes
                func.Exports("KONDA").ParamValue = oCliente.GrupoPrecios                     '	Grupo de precios - Cliente
                'func.Exports("PLTYP").ParamValue = oCliente.TipoListaPrecios                 '	Tipo de lista de precios
                func.Exports("LPRIO").ParamValue = oCliente.PrioridadEntrega                 '	Prioridad de entrega
                func.Exports("KZAZU").ParamValue = oCliente.IndicadorAgrupamiento            '	Indicador de agrupamiento de pedidos
                func.Exports("ANTLF").ParamValue = oCliente.MaxEntregasParciales             '	Cantidad máxima de entregas parciales permitidas p/posición
                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    'Cambio_053
                    'KTGRD.Value = "03"
                    func.Exports("KTGRD").ParamValue = "01"
                Else
                    func.Exports("KTGRD").ParamValue = oCliente.GrupoImputacion              '	Grupo de imputación para cliente
                End If

                func.Exports("PRFRE").ParamValue = oCliente.IndicadorRelevante               '   Indicador relevante para determinación de precios
                func.Exports("BUKRS").ParamValue = oCliente.OrganizacionVentas               ' Sociedad

                'ANRED.Value = IIf(oCliente.Sexo.Trim.ToUpper = "M", "Señor", "Señora") ' Tratamiento
                func.Exports("ANRED").ParamValue = oCliente.Sexo
                'Select Case oCliente.Sexo.Trim.ToUpper
                '    Case "M"
                '        func.Exports("ANRED").ParamValue = "Señor"
                '    Case "F"
                '        func.Exports("ANRED").ParamValue = "Señora"
                '    Case "E"
                '        func.Exports("ANRED").ParamValue = "Empresa"
                '    Case Else
                '        func.Exports("ANRED").ParamValue = ""
                'End Select
                func.Exports("EDOCIV").ParamValue = oCliente.EstadoCivil.Trim
                func.Exports("RAZONNOEMAIL").ParamValue = oCliente.RazonNoEmail.Trim
                func.Exports("NUMEXT").ParamValue = oCliente.NumExt
                func.Exports("NUMINT").ParamValue = oCliente.NumInt
                'func.Exports("FDGRV").ParamValue = "Z3"  ' Grupo de Tesoreria  
                func.Exports("ALTKN").ParamValue = ""  ' Número de registro maestro anterior
                func.Exports("WITHT").ParamValue = ""  ' Indicador para tipo de retenciones
                func.Exports("PARVW").ParamValue = ""
                'Fin de Asignacion de Valores

                func.Execute()

                dtReturn = func.Tables("RETURN").ToADOTable()
                dtMessTab = func.Tables("MESSTAB").ToADOTable()

                If func.Imports("RESULT").ToString = "E" Then
                    'Throw New ApplicationException(oRETURN.Value("message"))
                    Dim strError As String
                    strError = String.Empty
                    For Each row As DataRow In dtReturn.Rows
                        strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(row("MESSAGE")) & vbCrLf
                    Next

                    MsgBox(strError, MsgBoxStyle.Exclamation, "Dportenis PRO")

                    intResult = 0

                Else

                    intResult = 1

                    oCliente.CodigoAlterno = func.Exports("KUNNR").ParamValue.ToString

                End If

                R3.Close()

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return intResult

    End Function

    'Public Function VerificarCodigo(ByVal strCodigo As String) As Boolean
    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function
    '        Dim objPar1 As SAPFunctionsOCX.Parameter 'Primer P
    '        Dim objReturn As Object
    '        Dim objExist As Object
    '        Dim objKUNNR As Object
    '        Dim bResultado As Boolean

    '        'objR3 = CreateObject("SAP.Functions")

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With


    '        If objR3.Connection.logon(0, True) <> True Then
    '            Exit Function
    '        End If

    '        objFunc = objR3.Add("ZBAPISD26_EXISTCLIENT")
    '        objPar1 = objFunc.Exports("NAME1")

    '        objReturn = objFunc.Imports("RETURN")
    '        objExist = objFunc.Imports("EXIST")
    '        objKUNNR = objFunc.Imports("KUNNR")

    '        objPar1.Value = "CLIENTE DATOS GENERALES"


    '        bResultado = objFunc.Call

    '        If Not bResultado Then
    '            MsgBox(objFunc.Exception)
    '        End If
    '        objR3.Connection.LogOff()

    '        If objExist.Value = "N" Then
    '            MsgBox(objReturn.Value("message"))
    '        ElseIf objExist.Value = "C" Then
    '            MsgBox(objReturn.Value("message"))
    '        Else
    '            MsgBox("El # de cliente es " & objKUNNR.Value)
    '        End If


    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try

    'End Function

    Public Function VerificarCodigo(ByVal strCodigo As String) As Boolean

        '----------------------------------------------------------------------------------
        ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------

        Dim bResultado As Boolean

        Dim strExist As String = String.Empty
        Dim dtReturn As New DataTable
        Dim strKUNNR As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD26_EXISTCLIENT ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD26_EXISTCLIENT")

                func.Exports("NAME1").ParamValue = "CLIENTE DATOS GENERALES"

                func.Execute()

                dtReturn = func.Tables("RETURN").ToADOTable()
                strExist = func.Imports("EXIST").ToString
                strKUNNR = func.Imports("KUNNR").ToString

                R3.Close()

                'If Not bResultado Then
                '    MsgBox(objFunc.Exception)
                'End If

                Dim mensaje As String = ""
                If strExist = "N" Or strExist = "C" Then
                    For Each row As DataRow In dtReturn.Rows
                        mensaje &= CStr(row("MESSAGE")) & vbCrLf
                    Next
                Else
                    mensaje = "El # de cliente es " & strKUNNR
                End If

                MsgBox(mensaje)

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function SelectByFiltro(ByVal strSelCriterio As String, ByVal strCriterio As String, ByVal GrupoDeCuentas As String) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ClientesSellQuickSearchSomeFields]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Criterio", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SelCriterio", System.Data.SqlDbType.Char, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@GrupoDeCuentas", System.Data.SqlDbType.VarChar, 5))
            .Parameters("@SelCriterio").Value = strSelCriterio
            .Parameters("@Criterio").Value = strCriterio
            .Parameters("@GrupoDeCuentas").Value = GrupoDeCuentas

        End With

        Dim oEstadosAdapter As SqlDataAdapter
        oEstadosAdapter = New SqlDataAdapter
        oEstadosAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oEstadosAdapter.Fill(oResult, "Clientes")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Friend Function SelectByFiltroPG(ByVal strCriterio As String) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim dtClientesPG As DataTable

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ClientesPGSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Criterio", System.Data.SqlDbType.VarChar, 150))
            .Parameters("@Criterio").Value = strCriterio

        End With

        Dim oClientesAdapter As SqlDataAdapter
        oClientesAdapter = New SqlDataAdapter
        oClientesAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oClientesAdapter.Fill(oResult, "ClientesPG")

            dtClientesPG = oResult.Tables(0).Copy

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtClientesPG

    End Function

    Friend Function SelectByFiltroPGFromServer(ByVal strCriterio As String) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringServer)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim dtClientesPG As DataTable

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ClientesPGSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Criterio", System.Data.SqlDbType.VarChar, 150))
            .Parameters("@Criterio").Value = strCriterio

        End With

        Dim oClientesAdapter As SqlDataAdapter
        oClientesAdapter = New SqlDataAdapter
        oClientesAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oClientesAdapter.Fill(oResult, "ClientesPG")
            If oResult.Tables("ClientesPG").Columns.Contains("NAME3") = False Then
                oResult.Tables("ClientesPG").Columns.Add("NAME3", GetType(String))
            End If
            If oResult.Tables("ClientesPG").Columns.Contains("TIPO_CLIENTE") = False Then
                oResult.Tables("ClientesPG").Columns.Add("TIPO_CLIENTE", GetType(String))
            End If
            dtClientesPG = oResult.Tables(0).Copy

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtClientesPG

    End Function

    Public Function SelectByID(ByVal ID As String, ByRef pResultadoCE As ClienteAlterno, ByVal strTipoVenta As String) As ClienteAlterno

        'If pResultadoCE.GrupoDeCuentas = "D019" Then
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand


        With sccmdSelect


            .Connection = sccnnConnection

            .CommandText = "[ClientesSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodigoAlterno", System.Data.SqlDbType.VarChar, 10))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@GrupoDeCuentas", System.Data.SqlDbType.VarChar, 5))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodigoAlterno").Value = ID
                '.Parameters("@GrupoDeCuentas").Value = strTipoVenta
                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then
                    Dim digitregex As Regex = New Regex("(?<digit>[A-Z]|[a-z])")

                    If pResultadoCE Is Nothing Then
                        pResultadoCE = oParent.CreateAlterno
                    End If
                    pResultadoCE.GenerateRFC = False
                    With scdrReader
                        'Se cambio por que te regresa un String
                        'pResultadoCE.CodigoCliente = .GetInt32(.GetOrdinal("clienteid"))
                        pResultadoCE.CodigoAlterno = .GetString(.GetOrdinal("clienteid"))
                        pResultadoCE.CodAlmacen = digitregex.Replace(.GetString(.GetOrdinal("codalmacen")), "").Trim
                        pResultadoCE.CodPlaza = .GetString(.GetOrdinal("codplaza"))
                        pResultadoCE.Nombre = .GetString(.GetOrdinal("nombre"))
                        pResultadoCE.Direccion = .GetString(.GetOrdinal("domicilio"))
                        pResultadoCE.Colonia = .GetString(.GetOrdinal("colonia"))
                        pResultadoCE.Ciudad = .GetString(.GetOrdinal("ciudad"))
                        pResultadoCE.Estado = .GetString(.GetOrdinal("estado"))
                        pResultadoCE.CP = .GetString(.GetOrdinal("cp"))
                        pResultadoCE.Telefono = .GetString(.GetOrdinal("telefono"))
                        pResultadoCE.FechaNacimiento = .GetDateTime(.GetOrdinal("fechanac"))
                        pResultadoCE.EstadoCivil = .GetString(.GetOrdinal("estadocivil"))
                        pResultadoCE.Sexo = .GetString(.GetOrdinal("sexo"))
                        pResultadoCE.EMail = .GetString(.GetOrdinal("email"))
                        pResultadoCE.RFC = .GetString(.GetOrdinal("RFC"))
                        'If InStr(1, .GetString(.GetOrdinal("RFC")), "-", CompareMethod.Text) = 4 Then
                        pResultadoCE.RFCMoral = .GetString(.GetOrdinal("RFC"))
                        'Else
                        '    pResultadoCE.RFCMoral = String.Empty
                        'End If
                        'pResultadoCE.Fiscal = .GetBoolean(.GetOrdinal("Fiscal"))
                        pResultadoCE.RecordCreatedBy = .GetString(.GetOrdinal("usuario"))
                        pResultadoCE.RecordCreatedOn = .GetDateTime(.GetOrdinal("fecha"))
                        pResultadoCE.RecordEnabled = .GetBoolean(.GetOrdinal("statusregistro"))
                        pResultadoCE.TipoVenta = .GetString(.GetOrdinal("TipoVenta"))
                        'pResultadoCE.CodPlayer = .GetString(.GetOrdinal("Player"))
                        pResultadoCE.NumExt = .GetString(.GetOrdinal("NumeroExt"))
                        pResultadoCE.NumInt = .GetString(.GetOrdinal("NumeroInt"))


                        If pResultadoCE.Sexo.Trim.ToUpper <> "E" Then

                            Dim apellido() As String = Split(.GetString(.GetOrdinal("Apellidos")), " ")

                            If apellido.Length = 2 Then
                                pResultadoCE.ApellidoPaterno = apellido(0)
                                pResultadoCE.ApellidoMaterno = apellido(1)
                            ElseIf apellido.Length = 1 Then
                                pResultadoCE.ApellidoPaterno = apellido(0)
                                pResultadoCE.ApellidoMaterno = ""
                            ElseIf apellido.Length > 2 Then
                                pResultadoCE.ApellidoPaterno = apellido(0)
                                pResultadoCE.ApellidoMaterno = ""
                                For i As Integer = 1 To apellido.Length - 1
                                    pResultadoCE.ApellidoMaterno += apellido(i) & " "
                                Next
                            Else
                                pResultadoCE.ApellidoPaterno = ""
                                pResultadoCE.ApellidoMaterno = ""
                            End If

                        Else
                            '------------------------------------------------------------------------------------------------
                            ' JNAVA (13.02.2017): Obtenemos de los apellidos el nombre completo de la empresa
                            '------------------------------------------------------------------------------------------------
                            pResultadoCE.ApellidoPaterno = .GetString(.GetOrdinal("Apellidos"))
                            pResultadoCE.ApellidoMaterno = ""
                            '------------------------------------------------------------------------------------------------
                        End If


                        'Reset New State of ResultadoConsultaExistencias Object 
                        pResultadoCE.ResetFlagNew()
                        pResultadoCE.SetFlagDirty()

                    End With

                Else
                    'pResultadoCE = Nothing
                End If

                scdrReader.Close()
            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        'If (pResultadoCE Is Nothing) Then
        'Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de Uso no existe.")
        'End If

        Return pResultadoCE
        'End If


    End Function

    Public Function SelectClienteByRFC(ByVal RFC As String) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringServer)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ClientesPGSelByRFC]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@RFC", SqlDbType.VarChar, 20, "RFC"))

            .Parameters("@RFC").Value = RFC
        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "ClientePG")

            sccnnConnection.Close()

        Catch ex As Exception

            'Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult.Tables(0)

    End Function

    Public Function SelectConfig(ByVal param As String) As String

        Dim oCon As New System.Data.SqlClient.SqlConnection(m_strConnectionStringServer)
        Dim sccmdSelect As System.Data.SqlClient.SqlCommand
        Dim scdrSelect As System.Data.SqlClient.SqlDataReader
        Dim strValor As String = ""

        sccmdSelect = New System.Data.SqlClient.SqlCommand

        With sccmdSelect

            .Connection = oCon
            .CommandText = "[ConfigSel]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@param", System.Data.SqlDbType.VarChar, 50, "parametro"))

        End With

        Try

            oCon.Open()

            With sccmdSelect

                .Parameters("@param").Value = param.Trim

                scdrSelect = .ExecuteReader(CommandBehavior.SingleRow And CommandBehavior.SingleResult)

                scdrSelect.Read()

                If scdrSelect.HasRows = True Then

                    With scdrSelect

                        strValor = .GetString(.GetOrdinal("valor")).ToUpper

                    End With

                Else

                    strValor = ""

                End If

            End With

            oCon.Close()

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            'Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            'Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return strValor.Trim

    End Function

    Public Function SelectEmail(ByVal Email As String, ByVal UserID As Integer, ByRef strError As String) As Boolean

        Dim oCon As New System.Data.SqlClient.SqlConnection(m_strConnectionStringServerEmails)
        Dim sccmdSelect As System.Data.SqlClient.SqlCommand
        Dim scdrSelect As System.Data.SqlClient.SqlDataReader
        Dim bRes As Boolean = False

        sccmdSelect = New System.Data.SqlClient.SqlCommand

        With sccmdSelect

            .Connection = oCon
            .CommandText = "[EmailsClientesSel]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar, 100, "Email"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmailID", System.Data.SqlDbType.Int, 4, "Email ID"))

            .Parameters("@Email").Value = Email.Trim
            .Parameters("@EmailID").Value = UserID

        End With

        Try

            oCon.Open()

            With sccmdSelect

                scdrSelect = .ExecuteReader(CommandBehavior.SingleRow And CommandBehavior.SingleResult)

                scdrSelect.Read()

                If scdrSelect.HasRows = True Then

                    bRes = True

                Else

                    bRes = False

                End If

            End With

            oCon.Close()

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            strError = exSQL.ToString

            'Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            strError = ex.ToString

            'Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return bRes

    End Function

    Public Function SelectByIDPG(ByVal ID As Integer, ByRef pResultadoCE As ClienteAlterno) As ClienteAlterno

        'If pResultadoCE.GrupoDeCuentas = "D019" Then
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand


        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ClientesPGSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@clienteid", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@clienteid").Value = ID
                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If pResultadoCE Is Nothing Then pResultadoCE = oParent.CreateAlterno

                If (scdrReader.HasRows) Then
                    Dim digitregex As Regex = New Regex("(?<digit>[A-Z]|[a-z])")

                    'pResultadoCE.GenerateRFC = False
                    With scdrReader
                        'Se cambio por que te regresa un String
                        pResultadoCE.CodigoCliente = .GetInt32(.GetOrdinal("ClienteID"))
                        pResultadoCE.CodigoAlterno = CStr(.GetInt32(.GetOrdinal("ClienteID"))).PadLeft(10, "0")
                        pResultadoCE.CodAlmacen = digitregex.Replace(.GetString(.GetOrdinal("Centro")), "").Trim
                        pResultadoCE.CodPlaza = .GetString(.GetOrdinal("OficinaVta"))
                        pResultadoCE.Nombre = .GetString(.GetOrdinal("Nombre"))
                        pResultadoCE.Direccion = .GetString(.GetOrdinal("Domicilio"))
                        pResultadoCE.Colonia = .GetString(.GetOrdinal("Colonia"))
                        pResultadoCE.Ciudad = .GetString(.GetOrdinal("Ciudad"))
                        pResultadoCE.Estado = .GetString(.GetOrdinal("Estado"))
                        pResultadoCE.CP = .GetString(.GetOrdinal("CP"))
                        pResultadoCE.Telefono = .GetString(.GetOrdinal("Telefono"))
                        pResultadoCE.FechaNacimiento = .GetDateTime(.GetOrdinal("FechaNac"))
                        pResultadoCE.EstadoCivil = .GetString(.GetOrdinal("EstadoCivil"))
                        pResultadoCE.Sexo = .GetString(.GetOrdinal("Sexo"))
                        pResultadoCE.EMail = .GetString(.GetOrdinal("Email"))
                        pResultadoCE.RFC = .GetString(.GetOrdinal("RFC"))
                        'If InStr(1, .GetString(.GetOrdinal("RFC")), "-", CompareMethod.Text) = 4 Then
                        pResultadoCE.RFCMoral = .GetString(.GetOrdinal("RFC"))
                        'Else
                        '    pResultadoCE.RFCMoral = String.Empty
                        'End If
                        'pResultadoCE.Fiscal = .GetBoolean(.GetOrdinal("Fiscal"))
                        pResultadoCE.RecordCreatedBy = .GetString(.GetOrdinal("UsuarioID"))
                        pResultadoCE.RecordCreatedOn = .GetDateTime(.GetOrdinal("Fecha"))
                        pResultadoCE.RecordEnabled = .GetBoolean(.GetOrdinal("StatusRegistro"))
                        'pResultadoCE.TipoVenta = .GetString(.GetOrdinal("TipoVenta"))
                        pResultadoCE.CodPlayer = .GetString(.GetOrdinal("UsuarioID"))
                        pResultadoCE.ApellidoPaterno = .GetString(.GetOrdinal("ApellidoPaterno"))
                        pResultadoCE.ApellidoMaterno = .GetString(.GetOrdinal("ApellidoMaterno"))
                        pResultadoCE.NumExt = .GetString(.GetOrdinal("NumExt"))
                        pResultadoCE.NumInt = .GetString(.GetOrdinal("NumInt"))
                        pResultadoCE.RazonNoEmail = .GetString(.GetOrdinal("RazonNoEmail"))
                        pResultadoCE.RazonRechazoID = .GetInt32(.GetOrdinal("RazonRechazoID"))

                        'Reset New State of ResultadoConsultaExistencias Object 
                        pResultadoCE.ResetFlagNew()
                        pResultadoCE.SetFlagDirty()

                    End With

                Else
                    '    pResultadoCE = Nothing
                End If

                scdrReader.Close()
            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        Return pResultadoCE

    End Function

    Public Function SelectByIDPGFromServer(ByVal ID As Integer, ByRef pResultadoCE As ClienteAlterno) As ClienteAlterno

        'If pResultadoCE.GrupoDeCuentas = "D019" Then
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringServer)
        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand


        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ClientesPGSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@clienteid", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@clienteid").Value = ID
                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If pResultadoCE Is Nothing Then pResultadoCE = oParent.CreateAlterno

                If (scdrReader.HasRows) Then
                    Dim digitregex As Regex = New Regex("(?<digit>[A-Z]|[a-z])")

                    'pResultadoCE.GenerateRFC = False
                    With scdrReader
                        'Se cambio por que te regresa un String
                        pResultadoCE.CodigoCliente = .GetInt32(.GetOrdinal("ClienteID"))
                        pResultadoCE.CodigoAlterno = CStr(.GetInt32(.GetOrdinal("ClienteID"))).PadLeft(10, "0")
                        pResultadoCE.CodAlmacen = digitregex.Replace(.GetString(.GetOrdinal("Centro")), "").Trim
                        pResultadoCE.CodPlaza = .GetString(.GetOrdinal("OficinaVta"))
                        pResultadoCE.Nombre = .GetString(.GetOrdinal("Nombre"))
                        pResultadoCE.Direccion = .GetString(.GetOrdinal("Domicilio"))
                        pResultadoCE.Colonia = .GetString(.GetOrdinal("Colonia"))
                        pResultadoCE.Ciudad = .GetString(.GetOrdinal("Ciudad"))
                        pResultadoCE.Estado = .GetString(.GetOrdinal("Estado"))
                        pResultadoCE.CP = .GetString(.GetOrdinal("CP"))
                        pResultadoCE.Telefono = .GetString(.GetOrdinal("Telefono"))
                        pResultadoCE.FechaNacimiento = .GetDateTime(.GetOrdinal("FechaNac"))
                        pResultadoCE.EstadoCivil = .GetString(.GetOrdinal("EstadoCivil"))
                        pResultadoCE.Sexo = .GetString(.GetOrdinal("Sexo"))
                        pResultadoCE.EMail = .GetString(.GetOrdinal("Email"))
                        pResultadoCE.RFC = .GetString(.GetOrdinal("RFC"))
                        'If InStr(1, .GetString(.GetOrdinal("RFC")), "-", CompareMethod.Text) = 4 Then
                        pResultadoCE.RFCMoral = .GetString(.GetOrdinal("RFC"))
                        'Else
                        '    pResultadoCE.RFCMoral = String.Empty
                        'End If
                        'pResultadoCE.Fiscal = .GetBoolean(.GetOrdinal("Fiscal"))
                        pResultadoCE.RecordCreatedBy = .GetString(.GetOrdinal("UsuarioID"))
                        pResultadoCE.RecordCreatedOn = .GetDateTime(.GetOrdinal("Fecha"))
                        pResultadoCE.RecordEnabled = .GetBoolean(.GetOrdinal("StatusRegistro"))
                        'pResultadoCE.TipoVenta = .GetString(.GetOrdinal("TipoVenta"))
                        pResultadoCE.CodPlayer = .GetString(.GetOrdinal("UsuarioID"))
                        pResultadoCE.ApellidoPaterno = .GetString(.GetOrdinal("ApellidoPaterno"))
                        pResultadoCE.ApellidoMaterno = .GetString(.GetOrdinal("ApellidoMaterno"))
                        pResultadoCE.NumExt = .GetString(.GetOrdinal("NumExt"))
                        pResultadoCE.NumInt = .GetString(.GetOrdinal("NumInt"))
                        pResultadoCE.RazonNoEmail = .GetString(.GetOrdinal("RazonNoEmail"))
                        pResultadoCE.RazonRechazoID = .GetInt32(.GetOrdinal("RazonRechazoID"))

                        'Reset New State of ResultadoConsultaExistencias Object 
                        pResultadoCE.ResetFlagNew()
                        pResultadoCE.SetFlagDirty()

                    End With

                Else
                    '    pResultadoCE = Nothing
                End If

                scdrReader.Close()
            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        Return pResultadoCE

    End Function

    Public Function GetRFC(ByVal oCliente As ClienteAlterno) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim strRFC As String = ""
        Dim strNombre As String = ""
        Dim strApeP As String = ""
        Dim strApeM As String = ""

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[SP_CALCULA_RFC]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RFC_OUT", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Output))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NOMBRES_AUX", System.Data.SqlDbType.VarChar, 100))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@APATERNO_AUX", System.Data.SqlDbType.VarChar, 100))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AMATERNO_AUX", System.Data.SqlDbType.VarChar, 100))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FECHANACIMIENTO", System.Data.SqlDbType.DateTime, 100))

        End With

        Try

            If oCliente.EsEmpresa Then
                Dim strNombres() As String = oCliente.Nombre.Split(" ")
                Dim i As Integer = 0

                Select Case strNombres.Length
                    Case 1
                        strApeP = strNombres(0).Trim
                    Case 2
                        strApeP = strNombres(0).Trim
                        strApeM = strNombres(1).Trim
                    Case Is >= 3
                        strApeP = strNombres(0).Trim
                        strApeM = strNombres(1).Trim
                        For i = 2 To strNombres.Length - 1
                            strNombre &= strNombres(i) & " "
                        Next
                        strNombre = strNombre.Trim
                End Select
            Else
                strNombre = oCliente.Nombre
                strApeP = oCliente.ApellidoPaterno
                strApeM = oCliente.ApellidoMaterno
            End If

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@RFC_OUT").Value = ""
                .Parameters("@NOMBRES_AUX").Value = strNombre 'oCliente.Nombre
                .Parameters("@APATERNO_AUX").Value = strApeP 'oCliente.ApellidoPaterno
                .Parameters("@AMATERNO_AUX").Value = strApeM 'oCliente.ApellidoMaterno
                .Parameters("@FECHANACIMIENTO").Value = Format(oCliente.FechaNacimiento, "dd/MM/yyyy")

                Dim scdrReader As SqlDataReader
                'Execute Reader
                scdrReader = .ExecuteReader
                scdrReader.Read()
                If scdrReader.HasRows Then
                    strRFC = scdrReader.GetString(scdrReader.GetOrdinal("RFC")).Trim
                Else
                    strRFC = ""
                End If
                'Assign Other Values

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        Finally
            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If
        End Try

        sccnnConnection.Dispose()

        Return strRFC

    End Function


    Public Function GetTipoVenta(ByVal IDCliente As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdSelect As New SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strResult As String = ""

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ClientesGetTipoVenta]"

            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@IDCliente", System.Data.SqlDbType.VarChar, 10, "IDCliente"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@IDCliente").Value = IDCliente

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        If IsDBNull(.GetString(0)) Then
                            strResult = "C"
                        Else
                            strResult = .GetString(0).ToUpper
                        End If

                    End With

                End If

            End With

            sccnnConnection.Close()

        Catch exSQL As SqlException

            If sccnnConnection.State <> ConnectionState.Closed Then

                sccnnConnection.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos", exSQL)

        Catch ex As Exception

            If sccnnConnection.State = ConnectionState.Closed Then

                sccnnConnection.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación", ex)

        End Try

        Return strResult

    End Function

#Region " Proyecto SiHay "

    '-------------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (10/05/2013) - Funcion que agrega los registros en tabla ConcretarCitaSH
    '-------------------------------------------------------------------------------------------------------------------------------------
    Public Sub InsertConcretarCitaSH(ByVal FolioPedido As String, ByVal FechaCita As Date)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ConcretarCitaSHIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioPedido", System.Data.SqlDbType.VarChar, 30, "FolioPedido"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaCita", System.Data.SqlDbType.DateTime, 8, "FechaCita"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@FolioPedido").Value = FolioPedido.Trim
                .Parameters("@FechaCita").Value = FechaCita.ToShortDateString
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.SessionLoginName

                'Execute Command
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw oSqlException

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw ex

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

#End Region

#Region "DPVale AFS"
    '--------------------------------------------------------------------
    ' JNAVA (15.04.2016): Funciones de DPVale Apuntando a AFS
    '--------------------------------------------------------------------

    Private Function InsertDPValeSap(ByVal oCliente As ClienteAlterno) As Integer

        Dim intResult As Integer

        Dim strExist As String = String.Empty
        Dim dtReturn As New DataTable
        Dim dtMessTab As New DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD26_ALTACLIENT ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD26_ALTACLIENT")

                'Asignacion de Valores
                func.Exports("VKORG").ParamValue = oCliente.OrganizacionVentas     '	Organización de ventas
                func.Exports("VTWEG").ParamValue = oCliente.CanalDistribucion      '	Canal de distribución
                func.Exports("SPART").ParamValue = oCliente.Sector                 '	Sector
                If oCliente.EsEmpresa Then
                    Dim strNombres() As String = oCliente.Nombre.Split(" ")
                    Dim strApeP As String = ""
                    Dim strApeM As String = ""
                    Dim strNombre As String = ""
                    Dim i As Integer = 0

                    Select Case strNombres.Length
                        Case 1
                            strApeP = strNombres(0).Trim
                            strNombre = strApeP
                        Case 2
                            strApeP = strNombres(0).Trim
                            strApeM = strNombres(1).Trim
                            strNombre = strApeP & "_" & strApeM
                        Case Is >= 3
                            strApeP = strNombres(0).Trim
                            strApeM = strNombres(1).Trim
                            For i = 2 To strNombres.Length - 1
                                strNombre &= strNombres(i) & " "
                            Next
                            strNombre = strNombre.Trim
                            strNombre = strApeP & "_" & strApeM & "_" & strNombre
                    End Select
                    func.Exports("NAME1").ParamValue = strNombre        '	Nombre 1
                    'NAME1.Value = oCliente.Nombre.Trim      '	Nombre 1
                Else
                    func.Exports("NAME1").ParamValue = oCliente.ApellidoPaterno.Trim & "_" & oCliente.ApellidoMaterno.Trim & "_" & oCliente.Nombre.Trim      '	Nombre 1
                End If
                func.Exports("STRAS").ParamValue = oCliente.Direccion.Trim                   '	Calle y nº
                func.Exports("PSTLZ").ParamValue = oCliente.CP.PadLeft(5, "0")               '	Código postal
                func.Exports("ORT01").ParamValue = oCliente.Ciudad.Trim                      '	Población
                func.Exports("LAND1").ParamValue = oCliente.ClavePais                        '	Clave de país
                func.Exports("REGIO").ParamValue = oCliente.Estado                           '	Región (Estado federal, "land", provincia, condado)
                func.Exports("TELF1").ParamValue = oCliente.Telefono                         '	1º número de teléfono
                func.Exports("TELX1").ParamValue = Format(oCliente.FechaNacimiento, "yyyyMMdd") '	Numero de Telex
                If oCliente.RFCMoral <> String.Empty Then
                    func.Exports("STCD1").ParamValue = oCliente.RFCMoral.Replace("-", "")             '	Número de identificación fiscal 1 Persona Moral
                Else
                    func.Exports("STCD1").ParamValue = oCliente.RFC.Replace("-", "")             '	Número de identificación fiscal 1 Persona Fisica
                End If
                func.Exports("AKONT").ParamValue = oCliente.CuentaContabilidad               '	Cuenta asociada en la contabilidad principal
                func.Exports("ZTERM").ParamValue = oCliente.ClaveCondicionesPago             '	Clave de condiciones de pago
                func.Exports("BZIRK").ParamValue = "DPVL" 'oCliente.ZonaVentas                       '	Zona de ventas

                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    GoTo Cambio_053
                    ' VKBUR.Value = "C053"  '	Oficina de ventas"
                Else
Cambio_053:
                    func.Exports("VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen  '	Oficina de ventas
                End If

                func.Exports("VKGRP").ParamValue = "619" 'oCliente.CodPlayer                        '	Grupo de vendedores
                func.Exports("WAERS").ParamValue = oCliente.Moneda                           '	Moneda
                func.Exports("VERSG").ParamValue = oCliente.GrupoEstadistica                 '	Grupo de estadísticas cliente
                func.Exports("VSBED").ParamValue = oCliente.CondicionExpedicion              '	Condición de expedición

                Dim CentroFI As String
                Me.oSapCentro.Read_Centros("", CentroFI)

                func.Exports("VWERK").ParamValue = CentroFI                                  '	Centro suministrador (propio o externo)
                func.Exports("TAXKD").ParamValue = "1" 'oCliente.ClasificacionFiscal              '	Clasificación fiscal para el deudor
                func.Exports("KTOKD").ParamValue = "D005" 'oCliente.GrupoDeCuentas           '	Grupo de ctas.deudor
                func.Exports("ORT02").ParamValue = oCliente.Colonia                          '	Distrito &&&&&&&&
                func.Exports("KNURL").ParamValue = oCliente.EMail.Trim                       '	Uniform resource locator
                func.Exports("KDGRP").ParamValue = "03" 'oCliente.GrupoCliente                     '	Grupo de clientes
                func.Exports("KONDA").ParamValue = "03" 'oCliente.GrupoPrecios                     '	Grupo de precios - Cliente
                func.Exports("PLTYP").ParamValue = "Z1" 'oCliente.TipoListaPrecios                 '	Tipo de lista de precios
                func.Exports("LPRIO").ParamValue = oCliente.PrioridadEntrega                 '	Prioridad de entrega
                func.Exports("KZAZU").ParamValue = oCliente.IndicadorAgrupamiento            '	Indicador de agrupamiento de pedidos
                func.Exports("ANTLF").ParamValue = oCliente.MaxEntregasParciales             '	Cantidad máxima de entregas parciales permitidas p/posición
                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    'Cambio_053
                    'KTGRD.Value = "03"      '	Grupo de imputación para cliente -- 03 = Venta Catalogo
                    func.Exports("KTGRD").ParamValue = "01"
                Else
                    func.Exports("KTGRD").ParamValue = oCliente.GrupoImputacion              '	Grupo de imputación para cliente
                End If

                func.Exports("PRFRE").ParamValue = oCliente.IndicadorRelevante               '   Indicador relevante para determinación de precios
                func.Exports("I_SORTL").ParamValue = oCliente.I_SORTL                        '   Indicador de Busqueda Rapida
                'ANRED.Value = IIf(oCliente.Sexo.Trim.ToUpper = "M", "Señor", "Señora")  '   Tratatmiento
                Select Case oCliente.Sexo.Trim.ToUpper
                    Case "M"
                        func.Exports("ANRED").ParamValue = "Señor"
                    Case "F"
                        func.Exports("ANRED").ParamValue = "Señora"
                    Case "E"
                        func.Exports("ANRED").ParamValue = "Empresa"
                    Case Else
                        func.Exports("ANRED").ParamValue = ""
                End Select
                func.Exports("EDOCIV").ParamValue = oCliente.EstadoCivil.Trim
                func.Exports("RAZONNOEMAIL").ParamValue = oCliente.RazonNoEmail.Trim
                func.Exports("NUMEXT").ParamValue = oCliente.NumExt.Trim
                func.Exports("NUMINT").ParamValue = oCliente.NumInt.Trim
                'Fin de Asignacion de Valores

                func.Execute()

                dtReturn = func.Tables("RETURN").ToADOTable()
                dtMessTab = func.Tables("MESSTAB").ToADOTable()

                If func.Imports("KUNNR").ToString.Trim = String.Empty Then
                    'Throw New ApplicationException(oRETURN.Value("message"))
MostrarError:
                    'Dim iRen As Integer
                    Dim strError As String
                    strError = String.Empty
                    For Each row As DataRow In dtReturn.Rows
                        strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(row("MESSAGE")) & vbCrLf
                    Next

                    MsgBox(strError, MsgBoxStyle.Exclamation, "Dportenis PRO")

                    intResult = 0

                Else

                    intResult = 1

                    oCliente.CodigoAlterno = func.Imports("KUNNR").ParamValue.ToString.Trim

                    If func.Imports("RESULT").ToString.Trim = "E" Then GoTo MostrarError

                End If

                R3.Close()

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return intResult

    End Function

    Private Function UpdateDPValeSap(ByVal oCliente As ClienteAlterno) As Integer
        '----------------------------------------------------------------------------------
        ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim intResult As Integer

        Dim strExist As String = String.Empty
        Dim dtReturn As New DataTable
        Dim dtMessTab As New DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD26_MODIFCLIENT ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD26_MODIFCLIENT")

                'Asignacion de Valores
                func.Exports("KUNNR").ParamValue = oCliente.CodigoAlterno
                func.Exports("VKORG").ParamValue = oCliente.OrganizacionVentas               '	Organización de ventas
                func.Exports("VTWEG").ParamValue = oCliente.CanalDistribucion                '	Canal de distribución
                func.Exports("SPART").ParamValue = oCliente.Sector                           '	Sector
                If oCliente.EsEmpresa Then
                    Dim strNombres() As String = oCliente.Nombre.Split(" ")
                    Dim strApeP As String = ""
                    Dim strApeM As String = ""
                    Dim strNombre As String = ""
                    Dim i As Integer = 0

                    Select Case strNombres.Length
                        Case 1
                            strApeP = strNombres(0).Trim
                            strNombre = strApeP
                        Case 2
                            strApeP = strNombres(0).Trim
                            strApeM = strNombres(1).Trim
                            strNombre = strApeP & "_" & strApeM
                        Case Is >= 3
                            strApeP = strNombres(0).Trim
                            strApeM = strNombres(1).Trim
                            For i = 2 To strNombres.Length - 1
                                strNombre &= strNombres(i) & " "
                            Next
                            strNombre = strNombre.Trim
                            strNombre = strApeP & "_" & strApeM & "_" & strNombre
                    End Select
                    func.Exports("NAME1").ParamValue = strNombre      '	Nombre 1
                    'NAME1.Value = oCliente.Nombre.Trim      '	Nombre 1
                Else
                    func.Exports("NAME1").ParamValue = oCliente.ApellidoPaterno.Trim & "_" & oCliente.ApellidoMaterno.Trim & "_" & oCliente.Nombre.Trim      '	Nombre 1
                End If
                'NAME1.Value = oCliente.ApellidoPaterno & "_" & oCliente.ApellidoMaterno & "_" & oCliente.Nombre.Trim   '	Nombre 1
                func.Exports("STRAS").ParamValue = oCliente.Direccion.Trim                      '	Calle y nº
                func.Exports("PSTLZ").ParamValue = oCliente.CP.PadLeft(5, "0")                  '	Código postal
                func.Exports("ORT01").ParamValue = oCliente.Ciudad.Trim                         '	Población
                func.Exports("LAND1").ParamValue = oCliente.ClavePais                           '	Clave de país
                func.Exports("REGIO").ParamValue = oCliente.Estado                              '	Región (Estado federal, "land", provincia, condado)
                func.Exports("TELF1").ParamValue = oCliente.Telefono                            '	1º número de teléfono
                func.Exports("TELX1").ParamValue = Format(oCliente.FechaNacimiento, "yyyyMMdd") ' Numero de telex
                If oCliente.RFCMoral <> String.Empty Then
                    func.Exports("STCD1").ParamValue = oCliente.RFCMoral.Replace("-", "")             '	Número de identificación fiscal 1 Persona Moral
                Else
                    func.Exports("STCD1").ParamValue = oCliente.RFC.Replace("-", "")             '	Número de identificación fiscal 1 Persona Fisica
                End If
                ''  STCD1.Value = oCliente.RFC.Replace("-", "")                              '	Número de identificación fiscal 1
                func.Exports("AKONT").ParamValue = oCliente.CuentaContabilidad               '	Cuenta asociada en la contabilidad principal
                func.Exports("ZTERM").ParamValue = oCliente.ClaveCondicionesPago             '	Clave de condiciones de pago
                func.Exports("BZIRK").ParamValue = "DPVL" 'oCliente.ZonaVentas                       '	Zona de ventas

                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    GoTo Cambio_053
                    'VKBUR.Value = "C053"
                Else
Cambio_053:
                    func.Exports("VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen  '	Oficina de ventas
                End If

                func.Exports("VKGRP").ParamValue = "619" 'oCliente.CodPlayer                        '	Grupo de vendedores
                func.Exports("WAERS").ParamValue = oCliente.Moneda                           '	Moneda
                func.Exports("VERSG").ParamValue = oCliente.GrupoEstadistica                 '	Grupo de estadísticas cliente
                func.Exports("VSBED").ParamValue = oCliente.CondicionExpedicion              '	Condición de expedición

                Dim CentroFI As String
                Me.oSapCentro.Read_Centros("", CentroFI)
                func.Exports("VWERK").ParamValue = CentroFI                                 '	Centro suministrador (propio o externo)
                func.Exports("TAXKD").ParamValue = "1" 'oCliente.ClasificacionFiscal              '	Clasificación fiscal para el deudor
                func.Exports("ORT02").ParamValue = oCliente.Colonia                          '	Distrito &&&&&&&&
                func.Exports("KNURL").ParamValue = oCliente.EMail.Trim                       '	Uniform resource locator
                func.Exports("KDGRP").ParamValue = "03" 'oCliente.GrupoCliente                     '	Grupo de clientes
                func.Exports("KONDA").ParamValue = "03" 'oCliente.GrupoPrecios                     '	Grupo de precios - Cliente
                func.Exports("PLTYP").ParamValue = "Z1" 'oCliente.TipoListaPrecios                 '	Tipo de lista de precios
                func.Exports("LPRIO").ParamValue = oCliente.PrioridadEntrega                 '	Prioridad de entrega
                func.Exports("KZAZU").ParamValue = oCliente.IndicadorAgrupamiento            '	Indicador de agrupamiento de pedidos
                func.Exports("ANTLF").ParamValue = oCliente.MaxEntregasParciales             '	Cantidad máxima de entregas parciales permitidas p/posición
                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    'Cambio_053
                    'KTGRD.Value = "03"
                    func.Exports("KTGRD").ParamValue = "01"
                Else
                    func.Exports("KTGRD").ParamValue = oCliente.GrupoImputacion              '	Grupo de imputación para cliente
                End If

                func.Exports("PRFRE").ParamValue = oCliente.IndicadorRelevante               '   Indicador relevante para determinación de precios
                func.Exports("BUKRS").ParamValue = oCliente.OrganizacionVentas               ' Sociedad

                'ANRED.Value = IIf(oCliente.Sexo.Trim.ToUpper = "M", "Señor", "Señora") ' Tratamiento
                Select Case oCliente.Sexo.Trim.ToUpper
                    Case "M"
                        func.Exports("ANRED").ParamValue = "Señor"
                    Case "F"
                        func.Exports("ANRED").ParamValue = "Señora"
                    Case "E"
                        func.Exports("ANRED").ParamValue = "Empresa"
                    Case Else
                        func.Exports("ANRED").ParamValue = ""
                End Select
                func.Exports("EDOCIV").ParamValue = oCliente.EstadoCivil.Trim
                func.Exports("RAZONNOEMAIL").ParamValue = oCliente.RazonNoEmail.Trim
                func.Exports("NUMEXT").ParamValue = oCliente.NumExt
                func.Exports("NUMINT").ParamValue = oCliente.NumInt
                func.Exports("FDGRV").ParamValue = "Z3"  ' Grupo de Tesoreria  
                func.Exports("ALTKN").ParamValue = ""  ' Número de registro maestro anterior
                func.Exports("WITHT").ParamValue = ""  ' Indicador para tipo de retenciones
                func.Exports("PARVW").ParamValue = ""
                'Fin de Asignacion de Valores

                func.Execute()

                dtReturn = func.Tables("RETURN").ToADOTable()
                dtMessTab = func.Tables("MESSTAB").ToADOTable()

                If func.Imports("RESULT").ToString = "E" Then
                    'Throw New ApplicationException(oRETURN.Value("message"))
                    Dim strError As String
                    strError = String.Empty
                    For Each row As DataRow In dtReturn.Rows
                        strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(row("MESSAGE")) & vbCrLf
                    Next

                    MsgBox(strError, MsgBoxStyle.Exclamation, "Dportenis PRO")

                    intResult = 0

                Else

                    intResult = 1

                    oCliente.CodigoAlterno = func.Exports("KUNNR").ParamValue.ToString.Trim 'func.Imports("KUNNR").ParamValue.ToString

                End If

                R3.Close()

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return intResult

    End Function

    Private Function ClienteAFS(ByVal Cliente As ClienteAlterno, ByVal EsDPVale As Boolean) As Boolean
        If Not EsDPVale Then
            Return True
        End If
        If Cliente.TipoVenta.Trim <> "D" Then
            Dim CodigoRetail As String = Cliente.CodigoAlterno.Trim
            Dim oClienteAFS As ClienteAlterno = Cliente
            Try
                If ExisteClienteAFS(Cliente.ApellidoPaterno & "_" & Cliente.ApellidoMaterno & "_" & Cliente.Nombre, oClienteAFS.CodigoAlterno) Then
                    If UpdateDPValeSap(oClienteAFS) = 0 Then
                        Return False
                    End If
                Else
                    If InsertDPValeSap(oClienteAFS) = 0 Then
                        Return False
                    End If
                End If
                If Not EsDPVale Then
                    Cliente.CodigoAlterno = CodigoRetail.Trim
                End If
            Catch ex As Exception
                If EsDPVale Then
                    MsgBox("Ocurrio un error al Guardar el Cliente." & vbCrLf & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation)
                    Return False
                End If
            End Try
        End If
        Return True
    End Function

    Private Function ExisteClienteAFS(ByVal NombreCompleto As String, ByRef KUNNR As String) As Boolean
        Dim Existe As Boolean
        Dim dtClienteAFS As DataTable
        dtClienteAFS = oSAPMgr.ZBAPI_OBTENER_CLIENTES_DPVALE(NombreCompleto)
        If dtClienteAFS.Rows.Count > 0 Then
            KUNNR = dtClienteAFS.Rows(0).Item("KUNNR")
            Existe = True
        Else
            KUNNR = ""
            Existe = False
        End If
        Return Existe
    End Function
 
#End Region

#Region "S2Credit"

    '    '-----------------------------------------------------
    '    ' JNAVA (12.07.2016): Alta cliente en S2Credit
    '    '-----------------------------------------------------
    '    Private Function SaveClienteS2Credit(ByVal oCliente As ClienteAlterno, Optional ByVal EsDPVale As Boolean = False) As String

    '        Dim oS2Credit As New ProcesosS2Credit(oParent)
    '        Dim oClientesS2C As New Dictionary(Of String, Object)
    '        Dim oInfoClienteS2C As Dictionary(Of String, Object)
    '        Dim IDEstado As String = String.Empty

    '        Dim ID As String
    '        Dim strResult As String = String.Empty

    '        Try

    '            Dim name As String = ""
    '            Dim middle_name As String = ""

    '            '------------------------------------------------------------------------------------
    '            ' Validamos el ID del cliente para saber si es Alta o Modificacion
    '            '------------------------------------------------------------------------------------
    '            If oCliente.CodigoAlterno.Trim("0").Trim = String.Empty OrElse oCliente.CodigoAlterno.Trim = String.Empty Then
    '                ID = "0"
    '            Else
    '                ID = oCliente.CodigoAlterno
    '            End If

    '            '-----------------------------------------------------
    '            ' Llenamos datos del Cliente
    '            '-----------------------------------------------------
    '            oClientesS2C("id_customer") = CInt(ID)

    '            GetNombres(oCliente.NombreCompleto.TrimEnd, name, middle_name)
    '            oClientesS2C("name") = name
    '            oClientesS2C("middle_name") = middle_name
    '            oClientesS2C("last_name") = oCliente.ApellidoPaterno
    '            oClientesS2C("second_last_name") = oCliente.ApellidoMaterno
    '            oClientesS2C("birthdate") = Format(oCliente.FechaNacimiento, "yyyy-MM-dd")

    '            If oCliente.EstadoCivil = "CASADO(A)" Then
    '                oClientesS2C("marital_status") = 2
    '            Else
    '                oClientesS2C("marital_status") = 1
    '            End If

    '            If oCliente.Sexo = "M" Then
    '                oClientesS2C("gender") = 1
    '            Else
    '                oClientesS2C("gender") = 2
    '            End If

    '            oClientesS2C("email") = oCliente.EMail
    '            oClientesS2C("rfc") = oCliente.RFC.Trim

    '            '------------------------------------------------------------
    '            ' Generamos la CURP del cliente en base a sus datos
    '            '------------------------------------------------------------
    '            IDEstado = BuscaEstado(oCliente.Estado)
    '            oClientesS2C("curp") = GenerarCURP(name, middle_name, oCliente.ApellidoPaterno, oCliente.ApellidoMaterno, oCliente.Sexo, oCliente.FechaNacimiento, IDEstado)
    '            oClientesS2C("id_identification") = 1
    '            oClientesS2C("identification_value") = "X"

    '            '------------------------------------------------------------
    '            ' Preparamos la direccion
    '            '------------------------------------------------------------
    '            Dim oAddress As New Dictionary(Of String, Object)
    '            oAddress("street") = oCliente.Direccion
    '            oAddress("houseNumber") = oCliente.NumExt
    '            oAddress("apartmentNumber") = oCliente.NumInt

    '            '------------------------------------
    '            ' Obtenemos datos desde S2Credit
    '            '------------------------------------
    '            Dim oSepomex As New Dictionary(Of String, Object)
    '            oSepomex = ObtenerDireccionByCodigoPostal(oCliente.CP.Trim, oCliente.Colonia)
    '            oAddress("zipcode") = oSepomex("zipcode")
    '            oAddress("state") = oSepomex("state")
    '            oAddress("city") = oSepomex("city")
    '            oAddress("settlement") = oSepomex("settlement")
    '            oAddress("neighborhood") = oSepomex("neighborhood")
    '            oClientesS2C("addressCollection") = oAddress

    '            '------------------------------------------------------------
    '            ' Preparamos del telefono
    '            '------------------------------------------------------------
    '            Dim oPhone As New Dictionary(Of String, Object)
    '            oPhone("number") = QuitarFormatoTelefono(oCliente.Telefono)
    '            oPhone("type") = 1
    '            oClientesS2C("phoneNumberCollection") = oPhone

    '            '-----------------------------------------------------
    '            ' Ejecutamos Servicio
    '            '-----------------------------------------------------
    '            oInfoClienteS2C = Nothing
    '            oInfoClienteS2C = oS2Credit.SaveCustomers(oClientesS2C)

    '            If Not oInfoClienteS2C Is Nothing Then
    '                strResult = oInfoClienteS2C("id_customer").ToString
    '            End If

    '            Return strResult

    '        Catch ex As Exception
    '            If EsDPVale Then
    '                Throw ex
    '            End If
    '            EscribeLog(ex.Message, "Error al Crear Cliente en S2Credit")
    '        End Try

    '    End Function

    '    '----------------------------------------------------------------------------------------------------------
    '    ' JNAVA (12.07.2016): Buscamos el CP para obtener direccion en S2Credit
    '    '----------------------------------------------------------------------------------------------------------
    '    Private Function ObtenerDireccionByCodigoPostal(ByVal CodigoPostal As String, ByVal Colonia As String) As Dictionary(Of String, Object)

    '        Dim oS2Credit As New ProcesosS2Credit(oParent)
    '        Dim oCodigoPostalS2C As New List(Of Dictionary(Of String, Object)) 'InfoCodigoPostalS2Credit
    '        Dim oDatosCP As New Dictionary(Of String, Object) 'ArraySepomex

    '        '-----------------------------------------------------
    '        ' Obtenemos los datos del CP en S2Credit
    '        '-----------------------------------------------------
    '        oCodigoPostalS2C = oS2Credit.Sepomex(CodigoPostal.Trim)
    '        If Not oCodigoPostalS2C Is Nothing Then

    '            '---------------------------------------------------------
    '            ' Si se obtuvo informacion, comparamos con lo capturado
    '            '---------------------------------------------------------
    '            Dim strNeighborhood As String = String.Empty
    '            For Each oSepomex As Dictionary(Of String, Object) In oCodigoPostalS2C

    '                strNeighborhood = oSepomex("neighborhood").ToString

    '                '---------------------------------------------------------------------------------
    '                ' JNAVA 26.04.2016): quitamos signos de puntuacion a las colonias 
    '                '---------------------------------------------------------------------------------
    '                strNeighborhood = QuitarSignos(strNeighborhood).ToUpper
    '                Colonia = QuitarSignos(Colonia).ToUpper

    '                '-----------------------------------------------------
    '                ' Comparamos la por palabra de la colonia
    '                '-----------------------------------------------------
    '                Dim strArray() As String = Colonia.Split(" ")
    '                If strArray.Length > 1 Then
    '                    For Each Palabra As String In strArray
    '                        '-----------------------------------------------------
    '                        ' Si hay coicidencia, regresamos los datos de S2Credit
    '                        '-----------------------------------------------------
    '                        'If oS2Credit.BuscarPalabraEnCadena(Palabra.ToUpper.Trim, oSepomex("neighborhood").ToString.ToUpper) Then
    '                        If strNeighborhood.Contains(Palabra.ToUpper.Trim) Then
    '                            oDatosCP = oSepomex
    '                            GoTo Terminar
    '                        End If
    '                    Next
    '                Else
    '                    '-----------------------------------------------------
    '                    ' Si hay coicidencia, regresamos los datos de S2Credit
    '                    '-----------------------------------------------------
    '                    'If oS2Credit.BuscarPalabraEnCadena(Colonia.ToUpper.Trim, oSepomex("neighborhood").ToString.ToUpper) Then
    '                    If strNeighborhood.Contains(Colonia.ToUpper.Trim) Then
    '                        oDatosCP = oSepomex
    '                        GoTo Terminar
    '                    End If
    '                End If
    '            Next
    '            '------------------------------------------------------------------
    '            ' Si no hay coicidencia, regresamos el primer registro de S2Credit
    '            '------------------------------------------------------------------
    '            If oDatosCP.Count <= 0 Then
    '                oDatosCP = oCodigoPostalS2C.Item(0)
    '            End If
    '        Else
    '            '------------------------------------------------------------------------
    '            ' Si no hay informacion del CP en S2Credit, regresamos los datos vacios
    '            '------------------------------------------------------------------------
    '            oDatosCP("zipcode") = ""
    '            oDatosCP("state") = ""
    '            oDatosCP("city") = ""
    '            oDatosCP("settlement") = ""
    '            oDatosCP("neighborhood") = ""
    '        End If

    'Terminar:

    '        Return oDatosCP

    '    End Function

    '    '----------------------------------------------------------------------------------------------------------
    '    ' JNAVA (12.07.2016): Obtiene los nombres del cliente (si son mas de 1)
    '    '----------------------------------------------------------------------------------------------------------
    '    Private Sub GetNombres(ByVal NombreCompleto As String, ByRef Nombre1 As String, ByRef nombre2 As String)
    '        Dim Nombres() As String = NombreCompleto.Split(" ")
    '        If Nombres.Length > 1 Then
    '            Nombre1 = ""
    '            For Each Nombre As String In Nombres
    '                If Nombre1 = "" Then
    '                    Nombre1 = Nombre
    '                Else
    '                    nombre2 &= Nombre & " "
    '                End If
    '            Next
    '            nombre2 = nombre2.TrimEnd
    '        Else
    '            Nombre1 = NombreCompleto
    '            nombre2 = ""
    '        End If
    '    End Sub

    '    '----------------------------------------------------------------------------------------------------------
    '    ' JNAVA (12.07.2016): Genera CURP del cliente en base a Nombre, Edad, Sexo, Fecha de Nacimiento y Estado
    '    '----------------------------------------------------------------------------------------------------------
    '    Private Function GenerarCURP(ByVal Nombre As String, ByVal Nombre2 As String, ByVal ApellidoP As String, ByVal ApellidoM As String, _
    '                             ByVal Sexo As String, ByVal FechaNacimiento As DateTime, _
    '                             ByVal IDEstado As Integer) As String

    '        Dim curp As String
    '        Dim caracter1 As String
    '        Dim caracter2 As String
    '        Dim caracter3 As String
    '        Dim caracter4 As String
    '        Dim caracter5 As String
    '        Dim caracter6 As String
    '        Dim caracter7 As String
    '        Dim caracter8 As String
    '        Dim caracter9 As String
    '        Dim caracter10 As String
    '        Dim caracter11 As String
    '        Dim caracter12 As String
    '        Dim caracter13 As String
    '        Dim caracter14 As String
    '        Dim caracter15 As String
    '        Dim caracter16 As String
    '        Dim caracter17 As String
    '        Dim caracter18 As String

    '        'Dim Año As String = FechaNacimiento.Year
    '        'Dim mes As String = FechaNacimiento.Month
    '        'Dim dia As String = FechaNacimiento.Day

    '        If FechaNacimiento.Year <= Now.Year Then
    '            If FechaNacimiento.Year >= 1900 Then
    '                Dim value As String = Convert.ToString(ApellidoP.Chars(0))
    '                If ApellidoP.Chars(0) <> "Ñ"c Then
    '                    caracter1 = Convert.ToString(value)
    '                Else
    '                    caracter1 = "X"
    '                End If
    '                Dim i As Integer
    '                For i = 1 To ApellidoP.Length - 1
    '                    If ApellidoP.Chars(i) = "A"c OrElse ApellidoP.Chars(i) = "E"c OrElse ApellidoP.Chars(i) = "I"c OrElse ApellidoP.Chars(i) = "O"c OrElse ApellidoP.Chars(i) = "U"c Then
    '                        caracter2 = Convert.ToString(ApellidoP.Chars(i))
    '                        Exit For
    '                    End If
    '                    If ApellidoP.Length - 1 = i Then
    '                        caracter2 = "X"
    '                        Exit For
    '                    End If
    '                Next
    '                If ApellidoM <> "" AndAlso ApellidoM.Chars(0) <> "Ñ"c Then
    '                    Dim value2 As String = Convert.ToString(ApellidoM.Chars(0))
    '                    caracter3 = Convert.ToString(value2)
    '                Else
    '                    caracter3 = "X"
    '                End If
    '                If (Nombre.Chars(0) = "M"c AndAlso Nombre.Chars(1) = "A"c AndAlso Nombre.Chars(2) = "R"c AndAlso Nombre.Chars(3) = "I"c AndAlso Nombre.Chars(4) = "A"c) OrElse (Nombre.Chars(0) = "J"c AndAlso Nombre.Chars(1) = "O"c AndAlso Nombre.Chars(2) = "S"c AndAlso Nombre.Chars(3) = "E"c AndAlso Nombre2 <> "") Then
    '                    If Nombre2.Chars(0) <> "Ñ"c Then
    '                        Dim value3 As String = Convert.ToString(Nombre2.Chars(0))
    '                        caracter4 = Convert.ToString(value3)
    '                    Else
    '                        caracter4 = "X"
    '                    End If
    '                ElseIf Nombre.Chars(0) <> "Ñ"c Then
    '                    Dim value3 As String = Convert.ToString(Nombre.Chars(0))
    '                    caracter4 = Convert.ToString(value3)
    '                Else
    '                    caracter4 = "X"
    '                End If
    '                Dim value4 As String = Convert.ToString(FechaNacimiento.Year.ToString.Chars(2))
    '                caracter5 = Convert.ToString(value4)
    '                Dim value5 As String = Convert.ToString(FechaNacimiento.Year.ToString.Chars(3))
    '                caracter6 = Convert.ToString(value5)
    '                If FechaNacimiento.Year > 1999 Then
    '                    caracter17 = "A"
    '                Else
    '                    caracter17 = "0"
    '                End If
    '                For j As Integer = 0 To 12 'Meses
    '                    If CInt(FechaNacimiento.Month - 1) = j Then
    '                        If j > 8 Then
    '                            caracter7 = "1"
    '                            caracter8 = Convert.ToString(j - 9)
    '                        Else
    '                            caracter7 = "0"
    '                            caracter8 = Convert.ToString(j + 1)
    '                        End If
    '                    End If
    '                Next
    '                For k As Integer = 0 To 30 'Dias
    '                    If CInt(FechaNacimiento.Day - 1) = k Then
    '                        If k < 9 Then
    '                            caracter9 = "0"
    '                            caracter10 = Convert.ToString(k + 1)
    '                        End If
    '                        If k > 8 AndAlso k < 19 Then
    '                            caracter9 = "1"
    '                            caracter10 = Convert.ToString(k - 9)
    '                        End If
    '                        If k > 18 AndAlso k < 29 Then
    '                            caracter9 = "2"
    '                            caracter10 = Convert.ToString(k - 19)
    '                        End If
    '                        If k > 28 Then
    '                            caracter9 = "3"
    '                            caracter10 = Convert.ToString(k - 29)
    '                        End If
    '                    End If
    '                Next
    '                If Sexo = "M" Then
    '                    caracter11 = "H"
    '                Else
    '                    caracter11 = "M"
    '                End If

    '                Select Case IDEstado
    '                    Case 1
    '                        caracter12 = "A"
    '                        caracter13 = "S"

    '                    Case 2
    '                        caracter12 = "B"
    '                        caracter13 = "C"

    '                    Case 3
    '                        caracter12 = "B"
    '                        caracter13 = "S"

    '                    Case 4
    '                        caracter12 = "C"
    '                        caracter13 = "C"

    '                    Case 5
    '                        caracter12 = "C"
    '                        caracter13 = "L"

    '                    Case 6
    '                        caracter12 = "C"
    '                        caracter13 = "M"

    '                    Case 7
    '                        caracter12 = "C"
    '                        caracter13 = "S"

    '                    Case 8
    '                        caracter12 = "C"
    '                        caracter13 = "H"

    '                    Case 9
    '                        caracter12 = "D"
    '                        caracter13 = "F"

    '                    Case 10
    '                        caracter12 = "D"
    '                        caracter13 = "G"

    '                    Case 11
    '                        caracter12 = "G"
    '                        caracter13 = "T"

    '                    Case 11
    '                        caracter12 = "G"
    '                        caracter13 = "R"

    '                    Case 13
    '                        caracter12 = "H"
    '                        caracter13 = "G"

    '                    Case 14
    '                        caracter12 = "J"
    '                        caracter13 = "C"

    '                    Case 15
    '                        caracter12 = "M"
    '                        caracter13 = "C"

    '                    Case 16
    '                        caracter12 = "M"
    '                        caracter13 = "N"

    '                    Case 17
    '                        caracter12 = "M"
    '                        caracter13 = "S"

    '                    Case 18
    '                        caracter12 = "N"
    '                        caracter13 = "T"

    '                    Case 19
    '                        caracter12 = "N"
    '                        caracter13 = "L"

    '                    Case 20
    '                        caracter12 = "O"
    '                        caracter13 = "C"

    '                    Case 21
    '                        caracter12 = "P"
    '                        caracter13 = "L"

    '                    Case 22
    '                        caracter12 = "Q"
    '                        caracter13 = "T"

    '                    Case 23
    '                        caracter12 = "Q"
    '                        caracter13 = "R"

    '                    Case 24
    '                        caracter12 = "S"
    '                        caracter13 = "P"

    '                    Case 25
    '                        caracter12 = "S"
    '                        caracter13 = "L"

    '                    Case 26
    '                        caracter12 = "S"
    '                        caracter13 = "R"

    '                    Case 27
    '                        caracter12 = "T"
    '                        caracter13 = "C"

    '                    Case 28
    '                        caracter12 = "T"
    '                        caracter13 = "S"

    '                    Case 29
    '                        caracter12 = "T"
    '                        caracter13 = "L"

    '                    Case 30
    '                        caracter12 = "V"
    '                        caracter13 = "Z"

    '                    Case 31
    '                        caracter12 = "Y"
    '                        caracter13 = "N"

    '                    Case 32
    '                        caracter12 = "Z"
    '                        caracter13 = "S"

    '                    Case Else
    '                        caracter12 = "N"
    '                        caracter13 = "E"
    '                End Select

    '                For i = 1 To ApellidoP.Length - 1
    '                    If ApellidoP.Chars(i) = "A"c OrElse ApellidoP.Chars(i) = "E"c OrElse ApellidoP.Chars(i) = "I"c OrElse ApellidoP.Chars(i) = "O"c OrElse ApellidoP.Chars(i) = "U"c Then
    '                        If ApellidoP.Length - 1 = i Then
    '                            caracter14 = "X"
    '                            Exit For
    '                        End If
    '                    Else
    '                        If ApellidoP.Chars(i) <> "Ñ"c Then
    '                            caracter14 = Convert.ToString(ApellidoP.Chars(i))
    '                            Exit For
    '                        End If
    '                        If ApellidoP.Chars(i) = "Ñ"c Then
    '                            caracter14 = "X"
    '                            Exit For
    '                        End If
    '                    End If
    '                Next
    '                If ApellidoM <> "" Then
    '                    For i = 1 To ApellidoM.Length - 1
    '                        If ApellidoM.Chars(i) = "A"c OrElse ApellidoM.Chars(i) = "E"c OrElse ApellidoM.Chars(i) = "I"c OrElse ApellidoM.Chars(i) = "O"c OrElse ApellidoM.Chars(i) = "U"c Then
    '                            If ApellidoM.Length - 1 = i Then
    '                                caracter15 = "X"
    '                                Exit For
    '                            End If
    '                        Else
    '                            If ApellidoM.Chars(i) <> "Ñ"c Then
    '                                caracter15 = Convert.ToString(ApellidoM.Chars(i))
    '                                Exit For
    '                            End If
    '                            If ApellidoM.Chars(i) = "Ñ"c Then
    '                                caracter15 = "X"
    '                                Exit For
    '                            End If
    '                        End If
    '                    Next
    '                Else
    '                    caracter15 = "X"
    '                End If
    '                i = 1
    '                While i < Nombre.Length
    '                    If Nombre.Chars(i) = "A"c OrElse Nombre.Chars(i) = "E"c OrElse Nombre.Chars(i) = "I"c OrElse Nombre.Chars(i) = "O"c OrElse Nombre.Chars(i) = "U"c Then
    '                        If Nombre.Length - 1 = i Then
    '                            caracter16 = "X"
    '                            Exit While
    '                        End If
    '                        i += 1
    '                    Else
    '                        If Nombre.Chars(i) <> "Ñ"c Then
    '                            caracter16 = Convert.ToString(Nombre.Chars(i))
    '                            Exit While
    '                        End If
    '                        caracter16 = "X"
    '                        Exit While
    '                    End If
    '                End While
    '                Dim array As Char() = New Char() {Convert.ToChar(caracter1), Convert.ToChar(caracter2), Convert.ToChar(caracter3), Convert.ToChar(caracter4), Convert.ToChar(caracter5), Convert.ToChar(caracter6), _
    '                 Convert.ToChar(caracter7), Convert.ToChar(caracter8), Convert.ToChar(caracter9), Convert.ToChar(caracter10), Convert.ToChar(caracter11), Convert.ToChar(caracter12), _
    '                 Convert.ToChar(caracter13), Convert.ToChar(caracter14), Convert.ToChar(caracter15), Convert.ToChar(caracter16), Convert.ToChar(caracter17)}
    '                Dim array2 As Integer() = New Integer(16) {}
    '                Dim array3 As Integer() = array2
    '                For l As Integer = 0 To 16
    '                    If array(l) = "0"c Then
    '                        array3(l) = 0
    '                    End If
    '                    If array(l) = "1"c Then
    '                        array3(l) = 1
    '                    End If
    '                    If array(l) = "2"c Then
    '                        array3(l) = 2
    '                    End If
    '                    If array(l) = "3"c Then
    '                        array3(l) = 3
    '                    End If
    '                    If array(l) = "4"c Then
    '                        array3(l) = 4
    '                    End If
    '                    If array(l) = "5"c Then
    '                        array3(l) = 5
    '                    End If
    '                    If array(l) = "6"c Then
    '                        array3(l) = 6
    '                    End If
    '                    If array(l) = "7"c Then
    '                        array3(l) = 7
    '                    End If
    '                    If array(l) = "8"c Then
    '                        array3(l) = 8
    '                    End If
    '                    If array(l) = "9"c Then
    '                        array3(l) = 9
    '                    End If
    '                    If array(l) = "A"c Then
    '                        array3(l) = 10
    '                    End If
    '                    If array(l) = "B"c Then
    '                        array3(l) = 11
    '                    End If
    '                    If array(l) = "C"c Then
    '                        array3(l) = 12
    '                    End If
    '                    If array(l) = "D"c Then
    '                        array3(l) = 13
    '                    End If
    '                    If array(l) = "E"c Then
    '                        array3(l) = 14
    '                    End If
    '                    If array(l) = "F"c Then
    '                        array3(l) = 15
    '                    End If
    '                    If array(l) = "G"c Then
    '                        array3(l) = 16
    '                    End If
    '                    If array(l) = "H"c Then
    '                        array3(l) = 17
    '                    End If
    '                    If array(l) = "I"c Then
    '                        array3(l) = 18
    '                    End If
    '                    If array(l) = "J"c Then
    '                        array3(l) = 19
    '                    End If
    '                    If array(l) = "K"c Then
    '                        array3(l) = 20
    '                    End If
    '                    If array(l) = "L"c Then
    '                        array3(l) = 21
    '                    End If
    '                    If array(l) = "M"c Then
    '                        array3(l) = 22
    '                    End If
    '                    If array(l) = "N"c Then
    '                        array3(l) = 23
    '                    End If
    '                    If array(l) = "Ñ"c Then
    '                        array3(l) = 24
    '                    End If
    '                    If array(l) = "O"c Then
    '                        array3(l) = 25
    '                    End If
    '                    If array(l) = "P"c Then
    '                        array3(l) = 26
    '                    End If
    '                    If array(l) = "Q"c Then
    '                        array3(l) = 27
    '                    End If
    '                    If array(l) = "R"c Then
    '                        array3(l) = 28
    '                    End If
    '                    If array(l) = "S"c Then
    '                        array3(l) = 29
    '                    End If
    '                    If array(l) = "T"c Then
    '                        array3(l) = 30
    '                    End If
    '                    If array(l) = "U"c Then
    '                        array3(l) = 31
    '                    End If
    '                    If array(l) = "V"c Then
    '                        array3(l) = 32
    '                    End If
    '                    If array(l) = "W"c Then
    '                        array3(l) = 33
    '                    End If
    '                    If array(l) = "X"c Then
    '                        array3(l) = 34
    '                    End If
    '                    If array(l) = "Y"c Then
    '                        array3(l) = 35
    '                    End If
    '                    If array(l) = "Z"c Then
    '                        array3(l) = 36
    '                    End If
    '                Next
    '                array3(0) = array3(0) * 18
    '                array3(1) = array3(1) * 17
    '                array3(2) = array3(2) * 16
    '                array3(3) = array3(3) * 15
    '                array3(4) = array3(4) * 14
    '                array3(5) = array3(5) * 13
    '                array3(6) = array3(6) * 12
    '                array3(7) = array3(7) * 11
    '                array3(8) = array3(8) * 10
    '                array3(9) = array3(9) * 9
    '                array3(10) = array3(10) * 8
    '                array3(11) = array3(11) * 7
    '                array3(12) = array3(12) * 6
    '                array3(13) = array3(13) * 5
    '                array3(14) = array3(14) * 4
    '                array3(15) = array3(15) * 3
    '                array3(16) = array3(16) * 2
    '                Dim num2 As Integer = array3(0) + array3(1) + array3(2) + array3(3) + array3(4) + array3(5) + array3(6) + array3(7) + array3(8) + array3(9) + array3(10) + array3(11) + array3(12) + array3(13) + array3(14) + array3(15) + array3(16)
    '                num2 = num2 Mod 10
    '                If num2 = 0 Then
    '                    caracter18 = "0"
    '                Else
    '                    num2 = 10 - num2
    '                End If
    '                caracter18 = Convert.ToString(num2)

    '                curp = String.Concat(New String() {caracter1, caracter2, caracter3, caracter4, caracter5, caracter6, _
    '                 caracter7, caracter8, caracter9, caracter10, caracter11, caracter12, _
    '                 caracter13, caracter14, caracter15, caracter16, caracter17, caracter18})

    '            End If
    '        End If
    '        Return curp
    '    End Function

    '    '----------------------------------------------------------------------------------------------------------
    '    ' JNAVA (12.07.2016): Quita signos de puntuacion y caracteres especiales
    '    '----------------------------------------------------------------------------------------------------------
    '    Private Function QuitarSignos(ByVal texto As String) As String
    '        Dim consignos As String = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ"
    '        Dim sinsignos As String = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC"
    '        For v As Integer = 0 To sinsignos.Length - 1
    '            Dim i As String = consignos.Substring(v, 1)
    '            Dim j As String = sinsignos.Substring(v, 1)
    '            texto = texto.Replace(i, j)
    '        Next
    '        Return texto
    '    End Function

    '----------------------------------------------------------------------------------------------------------
    ' JNAVA (12.07.2016): Busca el Codigo del Estado para el CURP
    '----------------------------------------------------------------------------------------------------------
    'Private Function BuscaEstado(ByVal CodEstado As String) As String

    '    Dim i As Integer
    '    Dim dtEstados As DataTable = oParent.GetAllStates(False)

    '    For i = 0 To (dtEstados.Rows.Count - 1)

    '        If dtEstados.Rows(i).Item("CodEstado") = CodEstado Then

    '            Return dtEstados.Rows(i).Item("EstadoID")

    '        End If

    '    Next

    '    Return -1

    'End Function

    ''----------------------------------------------------------------------------------------------------------
    '' JNAVA (13.07.2016): Quita foramto a telefono
    ''----------------------------------------------------------------------------------------------------------
    'Private Function QuitarFormatoTelefono(ByVal Telefono As String) As String
    '    Dim oRegex As New Regex("[^\d]")
    '    Telefono = oRegex.Replace(Telefono, "")
    '    Return Telefono
    'End Function

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

End Class
