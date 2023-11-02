Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.Collections.Generic


Public Class FacturaDataGateway

    Private oParent As FacturaManager
    Private m_strConnectionString As String
    Private m_strConnectionStringAfil As String
    Private m_strConnectionStringFP As String = ""

    '--------------------------------------------------------
    'JNAVA (03.02.2015): Configuracion Servidor DPCARD
    '--------------------------------------------------------
    Private m_strConnectionStringDPC As String = ""

    '--------------------------------------------------------
    'JNAVA (06.02.2015): Configuracion Servidor DPCARD
    '--------------------------------------------------------
    Private m_strConnectionStringSeguros As String = ""

    '--------------------------------------------------------
    'JNAVA (10.02.2015): Configuracion Servidor DPVFinanciero
    '--------------------------------------------------------
    Private m_strConnectionStringDPVF As String = ""

    'ASANCHEZ (30-03-2021): Configuracion Servidor Blue
    '--------------------------------------------------------
    Private m_strConnectionStringBlue As String = ""
#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As FacturaManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

        If Not oParent.ConfigCierreFI Is Nothing Then

            m_strConnectionStringAfil = "data source = " & oParent.ConfigCierreFI.ServerEhub & "; initial catalog = " & _
                                        oParent.ConfigCierreFI.BaseDatosEhub & "; user id = " & Parent.ConfigCierreFI.UserEhub & "; password = " & _
                                        oParent.ConfigCierreFI.PassEhub

            m_strConnectionStringFP = "data source = " & oParent.ConfigCierreFI.ServerHuellas & "; initial catalog = " & _
                                        oParent.ConfigCierreFI.BaseDatosHuellas & "; user id = " & Parent.ConfigCierreFI.UserHuellas & "; password = " & _
                                        oParent.ConfigCierreFI.PassHuellas

            '--------------------------------------------------------
            'JNAVA (03.02.2015): ConnectionString de Servidor DPCARD
            '--------------------------------------------------------
            m_strConnectionStringDPC = "Data Source=" & oParent.ConfigCierreFI.ServerDPCard & "; Initial Catalog=" & _
                                        oParent.ConfigCierreFI.BaseDatosDPCard & "; User Id=" & oParent.ConfigCierreFI.UserDPCard & " ;Password=" & _
                                        oParent.ConfigCierreFI.PasswordDPCard & ";TimeOut=120;"

            '--------------------------------------------------------
            'JNAVA (06.02.2015): ConnectionString de Servidor DPVale TODO
            '--------------------------------------------------------
            m_strConnectionStringSeguros = "Data Source=" & oParent.ConfigCierreFI.ServerDPValeAIO & "; Initial Catalog=" & _
                                        oParent.ConfigCierreFI.BaseDatosDPValeAIO & "; User Id=" & _
                                        oParent.ConfigCierreFI.UserDPValeAIO & " ;Password=" & _
                                        oParent.ConfigCierreFI.PasswordDPValeAIO & ";TimeOut=120;"

            '--------------------------------------------------------
            'JNAVA (10.02.2015): ConnectionString de Servidor DPVF
            '--------------------------------------------------------
            m_strConnectionStringDPVF = "Data Source=" & oParent.ConfigCierreFI.ServerDPVF & "; Initial Catalog=" & _
                                        oParent.ConfigCierreFI.BaseDatosDPVF & "; User Id=" & _
                                        oParent.ConfigCierreFI.UserDPVF & " ;Password=" & _
                                        oParent.ConfigCierreFI.PasswordDPVF & ";TimeOut=120;"
            '--------------------------------------------------------
            'ASANCHEZ (30.03.2021): ConnectionString de Servidor BLUE
            '--------------------------------------------------------
            m_strConnectionStringBlue = "Data Source=" & oParent.ConfigCierreFI.ServerBlue & "; Initial Catalog=" & _
                                        oParent.ConfigCierreFI.BaseDatosDBlue & "; User Id=" & _
                                        oParent.ConfigCierreFI.UserBlue & " ;Password=" & _
                                        oParent.ConfigCierreFI.PassBlue & ";TimeOut=120;"

        End If

    End Sub

#End Region

#Region "Methods"

    Public Function SelectConfigFromServer() As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringFP)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ConfiguracionesSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim.ToUpper
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja.Trim.ToUpper

        End With

        Dim oConfigAdapter As New SqlDataAdapter
        oConfigAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oConfigAdapter.Fill(oResult, "Config")

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

        Return oResult.Tables(0)

    End Function

    Public Function SelectCodigosBajaCalidad(ByVal FolioFactura As Integer, ByVal CodCaja As String, ByVal TipoDoc As String) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CodigosBajaCalidadSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoDoc", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@FolioFactura").Value = FolioFactura
            .Parameters("@CodCaja").Value = CodCaja.Trim
            .Parameters("@TipoDoc").Value = TipoDoc.Trim

        End With

        Dim oConfigAdapter As New SqlDataAdapter
        oConfigAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oConfigAdapter.Fill(oResult, "Codigos")

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

        Return oResult.Tables(0)

    End Function


    Public Function SelectArticulosAclaracion(ByVal CodArticulo As String) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ArtAclaracionSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@CodArticulo").Value = CodArticulo

        End With

        Dim oConfigAdapter As New SqlDataAdapter
        oConfigAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oConfigAdapter.Fill(oResult, "Codigos")

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

        Return oResult.Tables(0)

    End Function


    Public Function TieneJerarquiaDescuentoAdicional(ByVal DescuentoAdicionalID As Integer, ByVal Fecha As DateTime, ByVal TipoVenta As String) As Boolean
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("TienePaqueteIDDescuentoAdicional", conexion)
        Dim tienePaquete As Boolean = False
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@DescuentoAdicionalID", DescuentoAdicionalID)
            command.Parameters.Add("@Fecha", Fecha)
            command.Parameters.Add("@TipoVenta", TipoVenta)
            tienePaquete = CBool(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(sql.ToString, "Error al lecturar el registro en SQL", sql)
            Throw New ApplicationException("Error al lecturar el registro en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(ex.ToString(), "Error en la aplicación", ex)
            Throw New ApplicationException("Error en la aplicación", ex)
        End Try
        Return tienePaquete
    End Function

    Public Function GetJerarquiaDescuentoAdicional(ByVal DescuentoAdicionalID As Integer) As String
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetPaqueteIDDescuentoAdicional", conexion)
        Dim jerarquia As String = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@DescuentoAdicionalID", DescuentoAdicionalID)
            jerarquia = CStr(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(sql.ToString(), "Error al leer el registro en la base de datos ", sql)
            Throw New ApplicationException("Error al leer el registro en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(ex.ToString(), "Error en los datos en la aplicación", ex)
            Throw New ApplicationException("Error en los datos en la aplicación", ex)
        End Try
        Return jerarquia
    End Function

    Public Function GetDescuentoAdicionalIDByCodigo(ByVal codigo As String, ByVal jerarquia As String, ByVal Fecha As DateTime, ByVal TipoVenta As String) As Boolean
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetDescuentoAdicionalIDByCodigo", conexion)
        Dim valido As Boolean
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodArticulo", codigo)
            command.Parameters.Add("@Jerarquia", jerarquia)
            command.Parameters.Add("@Fecha", Fecha)
            command.Parameters.Add("@TipoVenta", TipoVenta)
            valido = CBool(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(sql.ToString(), "Error en la base de datos al lecturar", sql)
            Throw New ApplicationException("Error en la base de datos al lecturar", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(ex.ToString(), "Error en la aplicación", ex)
            Throw New ApplicationException("Error en la aplicación", ex)
        End Try
        Return valido
    End Function

    Public Function InsertConfigInServer(ByVal Parametro As String, ByVal Valor As String, ByVal Tipo As Integer, ByVal bolPass As Boolean, ByVal Actualizar As Boolean) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringFP)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim strError As String = ""

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ConfiguracionesInsTemp]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4, "CodAlmacen"))
            .Parameters.Add(New SqlParameter("@CodCaja", SqlDbType.VarChar, 3, "CodCaja"))
            .Parameters.Add(New SqlParameter("@Parametro", SqlDbType.VarChar, 50, "Parametro"))
            .Parameters.Add(New SqlParameter("@Valor", SqlDbType.VarChar, 255, "Valor"))
            .Parameters.Add(New SqlParameter("@Tipo", SqlDbType.Int, 4, "Tipo"))
            .Parameters.Add(New SqlParameter("@Pass", SqlDbType.Bit, 1, "Es Password"))
            .Parameters.Add(New SqlParameter("@Actualizar", SqlDbType.Bit, 1, "Actualizar"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                If Parametro Is Nothing Then Parametro = ""
                .Parameters("@Parametro").Value = Parametro.Trim
                If Valor Is Nothing Then Valor = ""
                .Parameters("@Valor").Value = Valor.Trim
                .Parameters("@Tipo").Value = Tipo
                .Parameters("@Pass").Value = bolPass
                .Parameters("@Actualizar").Value = Actualizar

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

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)
            strError = "El registro no pudo ser insertado debido a un error de base de datos." & vbCrLf & oSqlException.ToString

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)
            strError = "El registro no pudo ser insertado debido a un error de aplicación." & vbCrLf & ex.ToString

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strError

    End Function

    Public Sub UpdateFolioSAP(ByVal oFactura As Factura)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "UPDATE Factura SET FolioSAP='" & oFactura.FolioSAP & "', FolioFISAP='" & oFactura.FolioFISAP & "' WHERE FacturaID = " & oFactura.FacturaID & ""
            .CommandType = System.Data.CommandType.Text

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate

                'Ejecutamos Comando
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing



    End Sub

    Public Sub UpdateStatusCuponDescuento(ByVal Usado As Boolean, ByVal FolioCupon As String, ByVal FacturaID As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[CuponesUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Folio", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@Usado", SqlDbType.Bit, 1))
            .Parameters.Add(New SqlParameter("@FacturaID", SqlDbType.Int, 4))

            .Parameters("@Folio").Value = FolioCupon.Trim.ToUpper
            .Parameters("@Usado").Value = Usado
            .Parameters("@FacturaID").Value = FacturaID

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate

                'Ejecutamos Comando
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub UpdateStatusReCuponDescuento(ByVal FolioCupon As String, ByVal CodVendedor As String, ByVal User As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[ReCuponesUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@FolioCupon", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@CodVendedor", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@User", SqlDbType.VarChar, 50))

            .Parameters("@FolioCupon").Value = FolioCupon.Trim.ToUpper
            .Parameters("@CodVendedor").Value = CodVendedor.Trim
            .Parameters("@User").Value = User.Trim

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate

                'Ejecutamos Comando
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub UpdateStatusEnvioServerPG(ByVal FolioSAP As String, ByVal Tipo As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[FacturaUpdEnvioServerPG]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@FolioSAP", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@Tipo", SqlDbType.Int, 4))

            .Parameters("@FolioSAP").Value = FolioSAP.Trim
            .Parameters("@Tipo").Value = Tipo

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate

                'Ejecutamos Comando
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            'Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            'Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub FolioNotaVentaManualUpd(ByVal FolioNotaVentaManual As Integer)
        Dim cnnstring As New SqlConnection(m_strConnectionString)
        Dim cmdFolioUpd As SqlCommand

        cmdFolioUpd = New SqlCommand

        With cmdFolioUpd
            .Connection = cnnstring
            .CommandText = "FolioNotaVentaUpdate"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioNotaVentaMan", System.Data.SqlDbType.Int, 8))
        End With

        Try

            cnnstring.Open()

            With cmdFolioUpd
                'Assign Parameters Values
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@FolioNotaVentaMan").Value = FolioNotaVentaManual

                'Execute Command
                .ExecuteNonQuery()


            End With

            cnnstring.Close()

        Catch oSqlException As SqlException

            If (cnnstring.State <> ConnectionState.Closed) Then
                Try
                    cnnstring.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (cnnstring.State <> ConnectionState.Closed) Then
                Try
                    cnnstring.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        cnnstring.Dispose()
        cnnstring = Nothing
    End Sub
    Public Sub Insert(ByVal oFactura As Factura)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[FacturaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "FacturaID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3, "CodAlmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2, "CodCaja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4, "FolioFactura"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int, 4, "ApartadoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int, 4, "NotaCreditoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 3, "Status"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.VarChar, 1, "CodTipoVenta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10, "ClienteID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 12, "CodVendedor"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescTotal", System.Data.SqlDbType.Money, 4, "DescTotal"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SubTotal", System.Data.SqlDbType.Money, 4, "SubTotal"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Money, 4, "IVA"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Money, 4, "Total"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Impresa", System.Data.SqlDbType.Bit, 1, "Impresa"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroFacilito", System.Data.SqlDbType.VarChar, 30, "NumeroFacilito"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 30, "FolioSAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFISAP", System.Data.SqlDbType.VarChar, 30, "FolioFISAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPesos", System.Data.SqlDbType.Money, 4, "DPesos"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Saldo", System.Data.SqlDbType.Money, 4, "Saldo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioVentaManual", System.Data.SqlDbType.Int, 4, "FolioVentaManual"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClientePGID", System.Data.SqlDbType.Int, 4, "Cliente PG Id"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Razon", System.Data.SqlDbType.VarChar, 250, "Razon del Rechazo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RazonID", System.Data.SqlDbType.Int, 4, "ID Razon del Rechazo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EnvioServerPG", System.Data.SqlDbType.Bit, 1, "Enviado al server"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EnvioServerPGCan", System.Data.SqlDbType.Bit, 1, "Enviado al server Cancelacion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 20, "Referencia"))
        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = 0
                .Parameters("@CodAlmacen").Value = oFactura.CodAlmacen
                .Parameters("@CodCaja").Value = oFactura.CodCaja
                .Parameters("@FolioFactura").Value = oFactura.FolioFactura
                .Parameters("@ApartadoID").Value = oFactura.ApartadoID
                .Parameters("@NotaCreditoID").Value = oFactura.NotaCreditoID
                .Parameters("@Status").Value = "GRA"
                .Parameters("@CodTipoVenta").Value = oFactura.CodTipoVenta
                .Parameters("@ClienteID").Value = CStr(oFactura.ClienteId).PadLeft(10, "0")
                .Parameters("@CodVendedor").Value = oFactura.CodVendedor
                .Parameters("@DescTotal").Value = oFactura.DescTotal
                .Parameters("@SubTotal").Value = oFactura.SubTotal
                .Parameters("@IVA").Value = oFactura.IVA
                .Parameters("@Total").Value = oFactura.Total
                .Parameters("@Impresa").Value = oFactura.Impresa
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.SessionLoginName
                '.Parameters("@Fecha").Value = Date.Today
                .Parameters("@Fecha").Value = oFactura.Fecha
                .Parameters("@StatusRegistro").Value = 1
                .Parameters("@NumeroFacilito").Value = oFactura.NumeroFacilito
                .Parameters("@FolioSAP").Value = oFactura.FolioSAP
                .Parameters("@FolioFISAP").Value = oFactura.FolioFISAP
                .Parameters("@DPesos").Value = oFactura.DPesos
                .Parameters("@Saldo").Value = oFactura.Saldo
                .Parameters("@FolioVentaManual").Value = oFactura.FolioNotaVentaManual
                .Parameters("@ClientePGID").Value = oFactura.ClientPGID
                .Parameters("@Razon").Value = oFactura.RazonRechazo
                .Parameters("@RazonID").Value = oFactura.RazonRechazoID
                .Parameters("@EnvioServerPG").Value = IIf(oParent.ConfigCierreFI.UsarHuellas, 0, 1)
                .Parameters("@EnvioServerPGCan").Value = IIf(oParent.ConfigCierreFI.UsarHuellas, 0, 1)
                .Parameters("@Referencia").Value = oFactura.Referencia
                'Execute Command
                .ExecuteNonQuery()

                oFactura.FacturaID = .Parameters("@FacturaID").Value
                oFactura.Fecha = .Parameters("@Fecha").Value

            End With
            'Cambiamos el Status del Folio de la nota de Venta a 1
            If oFactura.FolioNotaVentaManual <> 0 Then
                Dim FolioNtaVenta As Integer = oFactura.FolioNotaVentaManual
                FolioNotaVentaManualUpd(FolioNtaVenta)
            End If
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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub InsertVtaManual(ByVal oFactura As Factura)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[FacturaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "FacturaID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3, "CodAlmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2, "CodCaja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4, "FolioFactura"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int, 4, "ApartadoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int, 4, "NotaCreditoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 3, "Status"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.VarChar, 1, "CodTipoVenta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10, "ClienteID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 3, "CodVendedor"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescTotal", System.Data.SqlDbType.Money, 4, "DescTotal"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SubTotal", System.Data.SqlDbType.Money, 4, "SubTotal"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Money, 4, "IVA"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Money, 4, "Total"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Impresa", System.Data.SqlDbType.Bit, 1, "Impresa"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroFacilito", System.Data.SqlDbType.VarChar, 30, "NumeroFacilito"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 30, "FolioSAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFISAP", System.Data.SqlDbType.VarChar, 30, "FolioFISAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPesos", System.Data.SqlDbType.Money, 4, "DPesos"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Saldo", System.Data.SqlDbType.Money, 4, "Saldo"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = 0
                .Parameters("@CodAlmacen").Value = oFactura.CodAlmacen
                .Parameters("@CodCaja").Value = oFactura.CodCaja
                .Parameters("@FolioFactura").Value = oFactura.FolioFactura
                .Parameters("@ApartadoID").Value = oFactura.ApartadoID
                .Parameters("@NotaCreditoID").Value = oFactura.NotaCreditoID
                .Parameters("@Status").Value = "GRA"
                .Parameters("@CodTipoVenta").Value = oFactura.CodTipoVenta
                .Parameters("@ClienteID").Value = CStr(oFactura.ClienteId).PadLeft(10, "0")
                .Parameters("@CodVendedor").Value = oFactura.CodVendedor
                .Parameters("@DescTotal").Value = oFactura.DescTotal
                .Parameters("@SubTotal").Value = oFactura.SubTotal
                .Parameters("@IVA").Value = oFactura.IVA
                .Parameters("@Total").Value = oFactura.Total
                .Parameters("@Impresa").Value = oFactura.Impresa
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.SessionLoginName
                .Parameters("@Fecha").Value = Date.Today
                .Parameters("@StatusRegistro").Value = 1
                .Parameters("@NumeroFacilito").Value = oFactura.NumeroFacilito
                .Parameters("@FolioSAP").Value = oFactura.FolioSAP
                .Parameters("@FolioFISAP").Value = oFactura.FolioFISAP
                .Parameters("@DPesos").Value = oFactura.DPesos
                .Parameters("@Saldo").Value = oFactura.Saldo

                'Execute Command
                .ExecuteNonQuery()

                oFactura.FacturaID = .Parameters("@FacturaID").Value
                oFactura.Fecha = .Parameters("@Fecha").Value

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub InsertCodigoBajaCalidad(ByVal Codigo As String, ByVal Talla As String, ByVal Cantidad As Integer, ByVal Motivo As String, ByVal FolioFactura As Integer, _
    ByVal CodCaja As String, ByVal TipoDoc As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CodigosBajaCalidadIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Motivo", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoDoc", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@Codigo").Value = Codigo.Trim
            .Parameters("@Talla").Value = Talla.Trim
            .Parameters("@Cantidad").Value = Cantidad
            .Parameters("@Motivo").Value = Motivo.Trim
            .Parameters("@FolioFactura").Value = FolioFactura
            .Parameters("@CodCaja").Value = CodCaja.Trim
            .Parameters("@TipoDoc").Value = TipoDoc.Trim

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    Public Sub DesmarcaBajaCalidad(ByVal dtArticulos As DataTable)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection

            .CommandText = "[BajaCalidadDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Motivo", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDMotivo", System.Data.SqlDbType.VarChar, 2))

        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert

                For Each oRow As DataRow In dtArticulos.Rows

                    .Parameters("@Codigo").Value = oRow!Material
                    .Parameters("@Cantidad").Value = oRow!Cantidad
                    .Parameters("@Motivo").Value = oRow!Motivo
                    .Parameters("@IDMotivo").Value = oRow!DesMarcadoID
                    'Execute Command
                    .ExecuteNonQuery()
                Next

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    Public Sub InsertBajaCalidad(ByVal dtArticulos As DataTable)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand


        With sccmdInsert
            .Connection = sccnnConnection

            .CommandText = "[BajaCalidadIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Motivo", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDMotivo", System.Data.SqlDbType.VarChar, 2))

        End With


        Try
            sccnnConnection.Open()

            With sccmdInsert

                For Each oRow As DataRow In dtArticulos.Rows

                    .Parameters("@Codigo").Value = oRow!Material
                    .Parameters("@Talla").Value = oRow!Talla
                    .Parameters("@Cantidad").Value = oRow!Cantidad
                    .Parameters("@Motivo").Value = oRow!Motivo
                    .Parameters("@IDMotivo").Value = oRow!MarcadoID

                    'Execute Command
                    .ExecuteNonQuery()
                Next

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    Public Function BajaCalidadSel() As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[BajaCalidadSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()
            oResult = New DataSet
            oFacturaAdapter.Fill(oResult, "TPRODUCTO")

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

        Return oResult.Tables(0)

    End Function
   

    Public Sub DeleteCodigosBajaCalidad(ByVal FolioFactura As Integer, ByVal CodCaja As String, ByVal TipoDoc As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CodigosBajaCalidadDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoDoc", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@FolioFactura").Value = FolioFactura
            .Parameters("@CodCaja").Value = CodCaja.Trim
            .Parameters("@TipoDoc").Value = TipoDoc.Trim

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub InsertVtasTACR(ByVal dtVtasTACR As DataTable, ByVal Fecha As Date)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringAfil)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[VtasTACRInsFromTienda]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4, "CodAlmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 3, "CodBanco"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ImpSeisM", System.Data.SqlDbType.Money, 8, "ImporteSeisMeses"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ImpDoceM", System.Data.SqlDbType.Money, 8, "ImporteDoceMeses"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                For Each oRow As DataRow In dtVtasTACR.Rows
                    'Assign Parameters Values
                    .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    .Parameters("@CodBanco").Value = oRow!CodBanco
                    .Parameters("@ImpSeisM").Value = oRow!ImporteSeisMeses
                    .Parameters("@ImpDoceM").Value = oRow!ImporteDoceMeses
                    .Parameters("@Fecha").Value = Fecha

                    'Execute Command
                    .ExecuteNonQuery()
                Next

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub InsertVtasTotales(ByVal dtVtasTotales As DataTable, ByVal Fecha As Date)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringAfil)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[VtasTotalesInsFromTienda]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EFEC", System.Data.SqlDbType.Money, 8, "Efectivo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TACR", System.Data.SqlDbType.Money, 8, "Tarjeta Credito"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TADB", System.Data.SqlDbType.Money, 8, "Tarjeta Debito"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPVL", System.Data.SqlDbType.Money, 8, "DPVale"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@VCJA", System.Data.SqlDbType.Money, 8, "Vale Caja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FONA", System.Data.SqlDbType.Money, 8, "Fonacot"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FACI", System.Data.SqlDbType.Money, 8, "Facilito"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.VarChar, 3, "CodAlmacen"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                For Each oRow As DataRow In dtVtasTotales.Rows
                    'Assign Parameters Values
                    .Parameters("@EFEC").Value = oRow!EFEC
                    .Parameters("@TACR").Value = oRow!TACR
                    .Parameters("@TADB").Value = oRow!TADB
                    .Parameters("@DPVL").Value = oRow!DPVL
                    .Parameters("@VCJA").Value = oRow!VCJA
                    .Parameters("@FONA").Value = oRow!FONA
                    .Parameters("@FACI").Value = oRow!FACI
                    .Parameters("@Fecha").Value = Fecha
                    .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen

                    'Execute Command
                    .ExecuteNonQuery()
                Next

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub InsertFormasPagoInServer(ByVal dtFormasPago As DataTable)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringFP)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[FacturasFormasPagoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10, "FolioSAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPValeID", System.Data.SqlDbType.Int, 4, "DPValeID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4, "CodFormasPago"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4, "CodBanco"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoTarjeta", System.Data.SqlDbType.VarChar, 2, "CodTipoTarjeta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroTarjeta", System.Data.SqlDbType.VarChar, 20, "NumeroTarjeta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroAutorizacion", System.Data.SqlDbType.VarChar, 20, "NumeroAutorizacion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoPago", System.Data.SqlDbType.Money, 4, "MontoPago"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NoAfiliacion", System.Data.SqlDbType.VarChar, 10, "Afiliacion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Id_Num_Promo", System.Data.SqlDbType.SmallInt, 2, "Promocion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                For Each oRow As DataRow In dtFormasPago.Rows
                    'Assign Parameters Values
                    .Parameters("@FolioSAP").Value = oRow!FolioSAP
                    .Parameters("@DPValeID").Value = oRow!DPValeID
                    .Parameters("@CodFormasPago").Value = oRow!CodFormasPago
                    .Parameters("@CodBanco").Value = oRow!CodBanco
                    .Parameters("@CodTipoTarjeta").Value = oRow!CodTipoTarjeta
                    .Parameters("@NumeroTarjeta").Value = oRow!NumeroTarjeta
                    .Parameters("@NumeroAutorizacion").Value = oRow!NumeroAutorizacion
                    .Parameters("@MontoPago").Value = oRow!MontoPago
                    .Parameters("@Usuario").Value = oRow!Usuario
                    .Parameters("@NoAfiliacion").Value = oRow!NoAfiliacion
                    .Parameters("@Id_Num_Promo").Value = oRow!Id_Num_Promo
                    .Parameters("@Fecha").Value = oRow!Fecha

                    'Execute Command
                    .ExecuteNonQuery()
                Next

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub InsertUsersInServer(ByVal dsSource As DataSet)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringFP)
        Dim oRow As DataRow, intID As Integer = 0, dvDetalle As DataView
        Dim oRowV As DataRowView

        Dim sccmdInsert As SqlCommand, sccmdInsertDetalle As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "DPPROUsersInsert"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@UserID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New SqlParameter("@Name", System.Data.SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@OrganizationDepartment", System.Data.SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@OrganizationPosition", System.Data.SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@PhoneOffice", System.Data.SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@PhoneMobile", System.Data.SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@PhonePager", System.Data.SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@PhoneHome", System.Data.SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@EmailAddress", SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@AddressStreet", SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@AddressHousingDevelopment", SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@AddressCity", SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@AddressState", SqlDbType.VarChar, 100))
            .Parameters.Add(New SqlParameter("@AddressPostalCode", SqlDbType.VarChar, 50))
            .Parameters.Add(New SqlParameter("@SessionLoginName", SqlDbType.VarChar, 20))
            .Parameters.Add(New SqlParameter("@SessionPassword", SqlDbType.VarChar, 255))
            .Parameters.Add(New SqlParameter("@SessionPasswordExpires", SqlDbType.Bit, 1))
            .Parameters.Add(New SqlParameter("@SessionPasswordExpiresOn", SqlDbType.SmallDateTime, 8))
            .Parameters.Add(New SqlParameter("@SessionEnabled", SqlDbType.Bit, 1))
            .Parameters.Add(New SqlParameter("@SessionRole", SqlDbType.Int, 4))
            .Parameters.Add(New SqlParameter("@Notes", SqlDbType.Text, 16))
            .Parameters.Add(New SqlParameter("@Sucursal", SqlDbType.VarChar, 5))

            .Parameters("@UserID").Direction = ParameterDirection.InputOutput
        End With

        sccmdInsertDetalle = New SqlCommand

        sccmdInsertDetalle.Connection = sccnnConnection
        sccmdInsertDetalle.CommandText = "DPPROUserPermissionsInsert"
        sccmdInsertDetalle.CommandType = System.Data.CommandType.StoredProcedure

        sccmdInsertDetalle.Parameters.Add(New SqlParameter("@UserID", System.Data.SqlDbType.Int, 4))
        sccmdInsertDetalle.Parameters.Add(New SqlParameter("@Feature", System.Data.SqlDbType.VarChar, 255))
        sccmdInsertDetalle.Parameters.Add(New SqlParameter("@FeatureOperation", System.Data.SqlDbType.VarChar, 255))
        sccmdInsertDetalle.Parameters.Add(New SqlParameter("@Authorized", System.Data.SqlDbType.Bit, 1))

        Try

            sccnnConnection.Open()

            With sccmdInsert

                For Each oRow In dsSource.Tables(0).Rows
                    'Assign Parameters Values
                    .Parameters("@UserID").Value = oRow!UserID
                    .Parameters("@Name").Value = oRow!Name
                    .Parameters("@OrganizationDepartment").Value = oRow!OrganizationDepartment
                    .Parameters("@OrganizationPosition").Value = oRow!OrganizationPosition
                    .Parameters("@PhoneOffice").Value = oRow!PhoneOffice
                    .Parameters("@PhoneMobile").Value = oRow!PhoneMobile
                    .Parameters("@PhonePager").Value = oRow!PhonePager
                    .Parameters("@PhoneHome").Value = oRow!PhoneHome
                    .Parameters("@EmailAddress").Value = oRow!EmailAddress
                    .Parameters("@AddressStreet").Value = oRow!AddressStreet
                    .Parameters("@AddressHousingDevelopment").Value = oRow!AddressHousingDevelopment
                    .Parameters("@AddressCity").Value = oRow!AddressCity
                    .Parameters("@AddressState").Value = oRow!AddressState
                    .Parameters("@AddressPostalCode").Value = oRow!AddressPostalCode
                    .Parameters("@SessionLoginName").Value = oRow!SessionLoginName
                    .Parameters("@SessionPassword").Value = oRow!SessionPassword
                    .Parameters("@SessionPasswordExpires").Value = oRow!SessionPasswordExpires
                    .Parameters("@SessionPasswordExpiresOn").Value = oRow!SessionPasswordExpiresOn
                    .Parameters("@SessionEnabled").Value = oRow!SessionEnabled
                    .Parameters("@SessionRole").Value = oRow!SessionRole
                    .Parameters("@Notes").Value = oRow!Notes
                    .Parameters("@Sucursal").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen

                    'Execute Command
                    .ExecuteNonQuery()

                    intID = .Parameters("@UserID").Value

                    dvDetalle = New DataView(dsSource.Tables(1), "UserID = " & oRow!UserID, "", DataViewRowState.CurrentRows)

                    If dvDetalle.Count > 0 Then

                        For Each oRowV In dvDetalle
                            sccmdInsertDetalle.Parameters("@UserID").Value = intID
                            sccmdInsertDetalle.Parameters("@Feature").Value = oRowV!Feature
                            sccmdInsertDetalle.Parameters("@FeatureOperation").Value = oRowV!FeatureOperation
                            sccmdInsertDetalle.Parameters("@Authorized").Value = oRowV!Authorized

                            sccmdInsertDetalle.ExecuteNonQuery()
                        Next

                    End If

                Next

            End With

            sccnnConnection.Close()

            'Roles de usuario
            sccmdInsert = New SqlCommand

            sccmdInsertDetalle = New SqlCommand

            With sccmdInsert

                .Connection = sccnnConnection
                .CommandText = "DPPRORolesInsert"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New SqlParameter("@RoleID", System.Data.SqlDbType.Int, 4))
                .Parameters.Add(New SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50))
                .Parameters.Add(New SqlParameter("@Description", System.Data.SqlDbType.VarChar, 100))
                .Parameters.Add(New SqlParameter("@Enabled", System.Data.SqlDbType.Bit, 1))
                .Parameters.Add(New SqlParameter("@Notes", System.Data.SqlDbType.Text, 16))
                .Parameters.Add(New SqlParameter("@Sucursal", System.Data.SqlDbType.VarChar, 5))

                .Parameters("@RoleID").Direction = ParameterDirection.InputOutput

                With sccmdInsertDetalle
                    .Connection = sccnnConnection
                    .CommandText = "DPPRORolePermissionsInsert"
                    .CommandType = System.Data.CommandType.StoredProcedure

                    .Parameters.Add(New SqlParameter("@RoleID", System.Data.SqlDbType.Int, 4))
                    .Parameters.Add(New SqlParameter("@Feature", System.Data.SqlDbType.VarChar, 255))
                    .Parameters.Add(New SqlParameter("@FeatureOperation", System.Data.SqlDbType.VarChar, 255))
                    .Parameters.Add(New SqlParameter("@Authorized", System.Data.SqlDbType.Bit, 1))
                End With

                sccnnConnection.Open()

                For Each oRow In dsSource.Tables(2).Rows
                    'Assign Parameters Values
                    .Parameters("@RoleID").Value = oRow!RoleID
                    .Parameters("@Name").Value = oRow!Name
                    .Parameters("@Description").Value = oRow!Description
                    .Parameters("@Enabled").Value = oRow!Enabled
                    .Parameters("@Notes").Value = oRow!Notes
                    .Parameters("@Sucursal").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen

                    'Execute Command
                    .ExecuteNonQuery()

                    intID = .Parameters("@RoleID").Value

                    'Detalle de los roles
                    dvDetalle = New DataView(dsSource.Tables(3), "RoleID = " & oRow!RoleID, "", DataViewRowState.CurrentRows)

                    If dvDetalle.Count > 0 Then

                        For Each oRowV In dvDetalle
                            sccmdInsertDetalle.Parameters("@RoleID").Value = intID
                            sccmdInsertDetalle.Parameters("@Feature").Value = oRowV!Feature
                            sccmdInsertDetalle.Parameters("@FeatureOperation").Value = oRowV!FeatureOperation
                            sccmdInsertDetalle.Parameters("@Authorized").Value = oRowV!Authorized

                            sccmdInsertDetalle.ExecuteNonQuery()
                        Next

                    End If
                Next

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    Public Sub InsertValeEmpleado(ByVal Folio As Integer, ByVal Serie As String, ByVal FacturaID As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ValeEmpleadoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4, "FacturaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, "Folio Vale"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Serie", System.Data.SqlDbType.VarChar, 3, "Serie"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@FacturaID").Value = FacturaID
                .Parameters("@Folio").Value = Folio
                .Parameters("@Serie").Value = Serie

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    '----------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/07/2017: Inserta el vale de empleado que se uso en el pedido
    '----------------------------------------------------------------------------------------------------------------------

    Public Sub InsertValeEmpleadoPedido(ByVal Folio As Integer, ByVal Serie As String, ByVal PedidoId As Integer)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ValeEmpleadoPedidoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PedidoID", System.Data.SqlDbType.Int, 4, "PedidoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, "Folio Vale"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Serie", System.Data.SqlDbType.VarChar, 3, "Serie"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@PedidoID").Value = PedidoId
                .Parameters("@Folio").Value = Folio
                .Parameters("@Serie").Value = Serie

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
    End Sub

    Public Sub InsertCuponDescuento(ByVal Folio As String, ByVal FacturaID As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CuponesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4, "FacturaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 10, "Folio Cupon"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@FacturaID").Value = FacturaID
                .Parameters("@Folio").Value = Folio.Trim.ToUpper

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub InsertReCuponDescuento(ByVal Folio As String, ByVal FolioPadre As String, ByVal NotaCreditoID As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ReCuponesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int, 4, "NotaCreditoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 10, "Folio Cupon"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioPadre", System.Data.SqlDbType.VarChar, 10, "Folio Cupon Origen"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@NotaCreditoID").Value = NotaCreditoID
                .Parameters("@Folio").Value = IIf(IsNumeric(Folio.Trim), Folio.Trim.PadLeft(10, "0"), Folio.Trim.ToUpper)
                .Parameters("@FolioPadre").Value = IIf(IsNumeric(FolioPadre.Trim), FolioPadre.Trim.PadLeft(10, "0"), FolioPadre.Trim.ToUpper)

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub InsertTarjetaRechazada(ByVal NoTarjeta As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringAfil)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TarjetasBloqueadasInsFromTienda]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NoTarjeta", System.Data.SqlDbType.VarChar, 20, "NumeroTarjeta"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@NoTarjeta").Value = NoTarjeta

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function SelectCodUPC(ByVal srtArticulo As String, ByVal strTalla As String) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand
        Dim strDescrip As String

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CodUPCSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 5))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = srtArticulo
                .Parameters("@Talla").Value = strTalla

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        strDescrip = .GetString(0)

                        .Close()

                    End With
                Else
                    strDescrip = String.Empty
                End If

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strDescrip

    End Function

    Public Function SelectAfiliacion(ByVal Promo As Integer, ByVal IDEmisor As Integer) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand
        Dim strAfiliacion As String

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[FacturaSelAfiliacion]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPromo", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New SqlParameter("@CodBanco", SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodPromo").Value = Promo
                .Parameters("@CodBanco").Value = IDEmisor

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        strAfiliacion = CStr(.GetDecimal(0))

                        .Close()

                    End With
                Else
                    strAfiliacion = String.Empty
                End If

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strAfiliacion

    End Function

    Public Function SelectDpValeId(ByVal intFacturaId As Integer, ByVal intPedidoID As Integer) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand
        Dim strDPVALEID As String

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[FacturaDPVALEIDSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PedidoID", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FolioFactura").Value = intFacturaId
                .Parameters("@PedidoID").Value = intPedidoID


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        strDPVALEID = .GetString(0)

                        .Close()

                    End With
                Else
                    strDPVALEID = ""
                End If

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strDPVALEID

    End Function

    Public Function SelectConector(ByVal NoTarjeta As String, ByVal Promo As Integer) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringAfil)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand
        Dim IdConector As Integer

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "eHubChkBanco_sUP"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cuenta", System.Data.SqlDbType.VarChar, 16, "Numero Tarjeta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IdSuc", SqlDbType.SmallInt, 2, "CodAlmacen"))
            .Parameters.Add(New SqlParameter("@Plazo", SqlDbType.SmallInt, 2, "Promocion"))
            '.Parameters.Add(New SqlParameter("@Debug", SqlDbType.SmallInt, 2, "Debug"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@Cuenta").Value = NoTarjeta.Trim
                .Parameters("@IdSuc").Value = CInt(oParent.ApplicationContext.ApplicationConfiguration.Almacen)
                .Parameters("@Plazo").Value = Promo
                '.Parameters("@Debug").Value = ""

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        IdConector = CInt(.Item(.GetOrdinal("Conector")))

                        .Close()

                    End With
                Else
                    IdConector = 1
                End If

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Select Case IdConector
            Case 1
                Return "Banamex"
            Case 2
                Return "Bancomer"
        End Select

    End Function

    Public Function SelectDescuentoAdicional(ByVal CodArticulo As String) As Decimal

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand
        Dim DescPorc As Decimal = 0

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "DescuentoAdicionalSelByArticulo"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = CodArticulo.ToUpper.Trim

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        DescPorc = CDec(.Item(.GetOrdinal("Descuento")))

                        .Close()

                    End With
                Else
                    DescPorc = 0
                End If

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return DescPorc

    End Function

    Public Function SelectDescuentoAdicionalPorMarca(ByVal CodMarca As String) As Decimal

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand
        Dim DescPorc As Decimal = 0

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "DescuentoAdicionalSelByMarca"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodMarca").Value = CodMarca.ToUpper.Trim

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        DescPorc = CDec(.Item(.GetOrdinal("Descuento")))

                        .Close()

                    End With
                Else
                    DescPorc = 0
                End If

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return DescPorc

    End Function

    Public Function SelectPromoDosPorUnoYMedio(ByVal CodMarca As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand
        Dim IsPromoVig As Boolean = False

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "DescuentoAdicionalSelPromoByMarca"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 20, "CodMarca"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodMarca").Value = CodMarca.ToUpper.Trim

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        IsPromoVig = True

                        .Close()

                    End With
                Else
                    IsPromoVig = False
                End If

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return IsPromoVig

    End Function

    Public Function LoadFormaPago(ByVal FacturaId As Integer) As DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("SELECT CodFormasPago As FORMA_PAGO FROM FacturasFormasPago WHERE FacturaID=@FacturaID", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim dtFormasPago As New DataTable
        Try
            conexion.Open()
            command.Parameters.Add("@FacturaID", FacturaId)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtFormasPago)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'MsgBox("Los registros no pudieron ser leidos debido a un error de base de datos.", MsgBoxStyle.Information, "Dportenis PRO")
            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'MsgBox("Los registros no pudieron ser leidos debido a un error de aplicación", MsgBoxStyle.Information, "Dportenis PRO")
            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación", ex)
        End Try
        Return dtFormasPago
    End Function

    Public Function SelectMaterialEnDpakete(ByVal CodArticulo As String) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[DescuentoAdicionalDpaketeSelByArticulo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@CodArticulo").Value = CodArticulo

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "Dpaketes")

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

        Return oResult.Tables(0)

    End Function

    Public Function SelectFormasPagoByPromo(ByVal PromoID As Integer) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[DescuentosFormasPagoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescuentoID", System.Data.SqlDbType.Int, 4))
            .Parameters("@DescuentoID").Value = PromoID

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "DescuentoFormasPago")

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

        Return oResult.Tables(0)

    End Function

    Public Function SelectFormasPagoByFolioDpakete(ByVal Folio As String) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[DescuentoAdicionalDpaketeFormasPagoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@Folio").Value = Folio.Trim.PadLeft(10, "0")

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "DescuentoFormasPago")

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

        Return oResult.Tables(0)

    End Function

    Public Function SelectFormasPagoByPromoFijo(ByVal PromoID As Integer) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[DescuentosFijosFormasPagoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescFijoID", System.Data.SqlDbType.Int, 4))
            .Parameters("@DescFijoID").Value = PromoID

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "DescuentoFormasPago")

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

        Return oResult.Tables(0)

    End Function

    Public Function SelectDetalleDpakete(ByVal Folio As String) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[DescuentoAdicionalDpaketeSelDetalle]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@Folio").Value = Folio

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "DpaketeDetalle")

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

        Return oResult.Tables(0)

    End Function

    Public Function SelectDescuentoPermitidoByTipoVenta(ByVal Codigo As String, ByVal TipoVenta As String, ByVal TipoPromo As String, _
    ByRef PromoID As Integer) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand
        Dim IsDescPerm As Boolean = False

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "DescuentoAdicionalSelTipoVenta"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20, "Codigo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoPromo", System.Data.SqlDbType.VarChar, 5, "Tipo Promocion"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@Codigo").Value = Codigo.Trim
                .Parameters("@TipoPromo").Value = TipoPromo

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                PromoID = 0

                If (scdrReader.HasRows) Then

                    With scdrReader

                        Select Case TipoVenta
                            Case "P"
                                IsDescPerm = .GetBoolean(.GetOrdinal("P"))
                            Case "I"
                                IsDescPerm = .GetBoolean(.GetOrdinal("I"))
                            Case "V"
                                IsDescPerm = .GetBoolean(.GetOrdinal("V"))
                            Case "O"
                                IsDescPerm = .GetBoolean(.GetOrdinal("O"))
                            Case "F"
                                IsDescPerm = .GetBoolean(.GetOrdinal("F"))
                            Case "K"
                                IsDescPerm = .GetBoolean(.GetOrdinal("K"))
                            Case "D"
                                IsDescPerm = .GetBoolean(.GetOrdinal("D"))
                            Case "S"
                                IsDescPerm = .GetBoolean(.GetOrdinal("S"))
                            Case "E"
                                IsDescPerm = .GetBoolean(.GetOrdinal("E"))

                        End Select

                        If IsDescPerm Then PromoID = .GetInt32(.GetOrdinal("IDDescuentosAdicionales"))

                        .Close()

                    End With
                Else
                    IsDescPerm = False
                End If

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return IsDescPerm

    End Function

    Public Function SelectFIDEVByValeCajaId(ByVal intValeCajaId As Integer) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand
        Dim strDPVALEID As String

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[FIDEVByValeCajaIdSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeCajaId", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@ValeCajaId").Value = intValeCajaId


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        strDPVALEID = .GetString(0)

                        .Close()

                    End With
                Else
                    strDPVALEID = ""
                End If

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            MsgBox("El registro no pudo ser leido debido a un error de base de datos.", MsgBoxStyle.Information, "DPTIENDA")

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            MsgBox("El registro no pudo ser leido debido a un error de aplicación.", MsgBoxStyle.Information, "DPTIENDA")

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strDPVALEID

    End Function

    Public Sub InsertMotivo(ByVal strFacturaID As Integer, ByVal strTienda As String, ByVal strArticulo As String, _
    ByVal strTalla As String, ByVal intIdMotivo As Integer, ByVal strTipoMovto As String)

        Dim strCodUPC As String = String.Empty
        strCodUPC = SelectCodUPC(strArticulo, strTalla)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[MotivosFacIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tienda", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Articulo", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IdMotivo", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoMovto", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUpc", System.Data.SqlDbType.VarChar, 18))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = strFacturaID
                .Parameters("@Tienda").Value = strTienda
                .Parameters("@Articulo").Value = strArticulo
                .Parameters("@Talla").Value = strTalla
                .Parameters("@IdMotivo").Value = intIdMotivo
                .Parameters("@Fecha").Value = Now.Date.ToShortDateString
                .Parameters("@TipoMovto").Value = strTipoMovto
                .Parameters("@CodUpc").Value = strCodUPC

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function InsertCatalogoMotivo(ByVal strdescripcion As String, ByVal shrtStatus As Short, ByVal datFecha As Date) As Boolean
        InsertCatalogoMotivo = False
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CatalogoMotivosFacIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 150))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Descripcion").Value = strdescripcion
                .Parameters("@Status").Value = shrtStatus
                .Parameters("@Fecha").Value = datFecha

                'Execute Command
                .ExecuteNonQuery()


            End With

            sccnnConnection.Close()
            InsertCatalogoMotivo = True


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

        Return InsertCatalogoMotivo

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Function


    Public Sub [SelectByFolio](ByVal FolioFactura As Integer, ByVal CodCaja As String, ByVal Factura As Factura)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaFolioCajaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters("@FolioFactura").Value = FolioFactura
            .Parameters("@CodCaja").Value = CodCaja

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        Factura.FacturaID = .GetInt32(0)
                        Factura.CodAlmacen = .GetString(1)
                        Factura.CodCaja = .GetString(2)
                        Factura.FolioFactura = .GetInt32(3)
                        Factura.ApartadoID = .GetInt32(4)
                        Factura.NotaCreditoID = .GetInt32(5)
                        Factura.StatusFactura = .GetString(6)
                        Factura.CodTipoVenta = .GetString(7)
                        Factura.ClienteId = CInt(.GetString(8))
                        Factura.CodVendedor = .GetString(9)
                        Factura.DescTotal = .GetDecimal(10)
                        Factura.SubTotal = .GetDecimal(11)
                        Factura.IVA = .GetDecimal(12)
                        Factura.Total = .GetDecimal(13)
                        Factura.Impresa = .GetBoolean(14)
                        Factura.Usuario = .GetString(15)
                        Factura.Fecha = .GetDateTime(16)
                        Factura.StatusRegistro = .GetBoolean(17)
                        Factura.NumeroFacilito = .GetString(18)
                        Factura.FolioSAP = .GetString(19)
                        Factura.FolioFISAP = .GetString(20)
                        Factura.DPesos = .GetDecimal(21)
                        Factura.FolioSAP = .GetString(.GetOrdinal("FolioSAP"))
                        Factura.Saldo = .GetDecimal(.GetOrdinal("Saldo"))
                        Factura.PedidoID = .GetInt32(23)
                        Factura.Referencia = CStr(scdrReader("Referencia"))
                        '-------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 21/04/2015: Carga el Número de DPCard Puntos que se realizo en el canje de puntos.
                        '-------------------------------------------------------------------------------------------------------
                        Factura.NoDPCardPuntos = CStr(scdrReader("NoDPCardPuntos"))
                        Factura.CodDPCardPunto = CStr(scdrReader("CodDPCardPunto"))

                        'Actualizamos Status del Objeto
                        Factura.ResetFlagNew()
                        Factura.ResetFlagDirty()

                    End With

                End If

                scdrReader.Close()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    ''' <summary>
    ''' Función para obtener los datos de una factura en base a al valor de la columna Referencia
    ''' </summary>
    ''' <param name="ReferenciaFactura">Referencia a buscar</param>
    ''' <param name="CodCaja">Código de caja</param>
    ''' <param name="Factura">Datos de la factura resultado</param>
    ''' <remarks></remarks>
    Public Sub SelectByReferencia(ByVal ReferenciaFactura As String, ByVal CodCaja As String, ByVal Factura As Factura)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaReferenciaCajaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReferenciaFactura", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters("@ReferenciaFactura").Value = ReferenciaFactura
            .Parameters("@CodCaja").Value = CodCaja

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        Factura.FacturaID = .GetInt32(0)
                        Factura.CodAlmacen = .GetString(1)
                        Factura.CodCaja = .GetString(2)
                        Factura.FolioFactura = .GetInt32(3)
                        Factura.ApartadoID = .GetInt32(4)
                        Factura.NotaCreditoID = .GetInt32(5)
                        Factura.StatusFactura = .GetString(6)
                        Factura.CodTipoVenta = .GetString(7)
                        Factura.ClienteId = CInt(.GetString(8))
                        Factura.CodVendedor = .GetString(9)
                        Factura.DescTotal = .GetDecimal(10)
                        Factura.SubTotal = .GetDecimal(11)
                        Factura.IVA = .GetDecimal(12)
                        Factura.Total = .GetDecimal(13)
                        Factura.Impresa = .GetBoolean(14)
                        Factura.Usuario = .GetString(15)
                        Factura.Fecha = .GetDateTime(16)
                        Factura.StatusRegistro = .GetBoolean(17)
                        Factura.NumeroFacilito = .GetString(18)
                        Factura.FolioSAP = .GetString(19)
                        Factura.FolioFISAP = .GetString(20)
                        Factura.DPesos = .GetDecimal(21)
                        Factura.FolioSAP = .GetString(.GetOrdinal("FolioSAP"))
                        Factura.Saldo = .GetDecimal(.GetOrdinal("Saldo"))
                        Factura.PedidoID = .GetInt32(23)
                        Factura.Referencia = CStr(scdrReader("Referencia"))
                        Factura.NoDPCardPuntos = CStr(scdrReader("NoDPCardPuntos"))
                        Factura.CodDPCardPunto = CStr(scdrReader("CodDPCardPunto"))

                        'Actualizamos Status del Objeto
                        Factura.ResetFlagNew()
                        Factura.ResetFlagDirty()

                    End With

                End If

                scdrReader.Close()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function SelectDescuentoFijoByClienteDIP(ByVal CodCliente As String, ByRef htDatosDesc As Hashtable) As Boolean 'ByRef Desc As Decimal, ByRef PromoID As Integer) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim band As Boolean = False

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[DescuentoAdicionalFijoSelByCliente]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCliente", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@CodCliente").Value = CodCliente

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    If htDatosDesc Is Nothing Then htDatosDesc = New Hashtable

                    With scdrReader

                        'Desc = .GetDecimal(.GetOrdinal("Descuento"))
                        'PromoID = .GetInt32(.GetOrdinal("DescFijoID"))
                        htDatosDesc("DescFijo") = .GetDecimal(.GetOrdinal("Descuento"))
                        htDatosDesc("PromoID") = .GetInt32(.GetOrdinal("DescFijoID"))
                        htDatosDesc("DipCorp") = .GetBoolean(.GetOrdinal("DipCorp"))
                        If .IsDBNull(.GetOrdinal("Fecha")) = False Then
                            htDatosDesc("Fecha") = .GetDateTime(.GetOrdinal("Fecha"))
                        Else
                            htDatosDesc("Fecha") = Now
                        End If

                    End With
                    band = True

                Else

                    band = False

                End If

                scdrReader.Close()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return band

    End Function

    Public Function SelectTarjetaRechazada(ByVal NoTarjeta As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringAfil)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim Result As Boolean

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[TarjetasBloqueadasSelByNumCuenta]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NoTarjeta", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@NoTarjeta").Value = NoTarjeta

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    Result = True

                Else

                    Result = False

                End If

                scdrReader.Close()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return Result

    End Function

    Public Function SelectValidaTipoVentaCliente(ByVal CodCliente As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim Result As String = ""

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaValidaTipoVentaCliente]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCliente", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@CodCliente").Value = CodCliente

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    Result = scdrReader.GetString(0).Trim.ToUpper

                End If

                scdrReader.Close()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return Result

    End Function

    Public Function GetMontoPago(ByVal FacturaID As Integer, ByVal DPVale As Boolean) As Double
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim dTotal As Double

        sccmdSelect = New SqlCommand

        If DPVale Then
            With sccmdSelect
                .Connection = sccnnConnection
                .CommandText = "select isnull(sum(montopago) - sum(montocancelado), 0) as total From FacturasFormasPago where facturaId = @FacturaID and CodFormasPago = 'DPVL'"
                .Parameters.Add("@FacturaID", SqlDbType.Int)
                .Parameters("@FacturaID").Value = FacturaID
                .CommandType = System.Data.CommandType.Text
            End With
        Else
            With sccmdSelect
                .Connection = sccnnConnection
                .CommandText = "select isnull(sum(montopago) - sum(montocancelado), 0) as total From FacturasFormasPago where facturaId = @FacturaID and CodFormasPago <> 'DPVL'"
                .Parameters.Add("@FacturaID", SqlDbType.Int)
                .Parameters("@FacturaID").Value = FacturaID
                .CommandType = System.Data.CommandType.Text
            End With

        End If

        Try
            sccnnConnection.Open()
            With sccmdSelect
                scdReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
                scdReader.Read()
                If scdReader.HasRows Then
                    dTotal = scdReader("Total")
                    scdReader.Close()
                Else
                    dTotal = 0
                End If

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return dTotal


    End Function

    Public Sub [Select](ByVal FacturaID As Integer, ByRef Factura As Factura)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))
            .Parameters("@FacturaID").Value = FacturaID

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        Factura.FacturaID = .GetInt32(0)
                        Factura.CodAlmacen = .GetString(1)
                        Factura.CodCaja = .GetString(2)
                        Factura.FolioFactura = .GetInt32(3)
                        Factura.ApartadoID = .GetInt32(4)
                        Factura.NotaCreditoID = .GetInt32(5)
                        Factura.StatusFactura = .GetString(6)
                        Factura.CodTipoVenta = .GetString(7)
                        Factura.ClienteId = CInt(.GetString(8))
                        Factura.CodVendedor = .GetString(9)
                        Factura.DescTotal = .GetDecimal(10)
                        Factura.SubTotal = .GetDecimal(11)
                        Factura.IVA = .GetDecimal(12)
                        Factura.Total = .GetDecimal(13)
                        Factura.Impresa = .GetBoolean(14)
                        Factura.Usuario = .GetString(15)
                        Factura.Fecha = .GetDateTime(16)
                        Factura.StatusRegistro = .GetBoolean(17)
                        Factura.NumeroFacilito = .GetString(18)
                        Factura.FolioSAP = .GetString(.GetOrdinal("FolioSAP"))
                        Factura.FolioFISAP = .GetString(.GetOrdinal("FolioFISAP"))
                        Factura.DPesos = .GetDecimal(.GetOrdinal("DPesos"))
                        Factura.Saldo = .GetDecimal(.GetOrdinal("Saldo"))
                        Factura.ClientPGID = .GetInt32(.GetOrdinal("ClientePGID"))

                        Factura.FCancelacionSD = .GetString(.GetOrdinal("FCFolioSAP"))
                        Factura.FCancelacionFI = .GetString(.GetOrdinal("FCFolioFISAP"))
                        '-------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 21/04/2015: Datos para conocer el Número de tarjetas que se realizo en el canje de productos
                        '-------------------------------------------------------------------------------------------------------
                        Factura.NoDPCardPuntos = CStr(scdrReader("NoDPCardPuntos"))
                        Factura.CodDPCardPunto = CStr(scdrReader("CodDPCardPunto"))
                        '-------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 20/01/2016: Carga la Referencia para el SAP Retail
                        '-------------------------------------------------------------------------------------------------------
                        Factura.Referencia = CStr(scdrReader("Referencia"))
                        If IsDBNull(scdrReader("PedidoID")) = False Then
                            Factura.PedidoID = CInt(scdrReader("PedidoID"))
                        Else
                            Factura.PedidoID = 0
                        End If
                        'Actualizamos Status del Objeto
                        Factura.ResetFlagNew()
                        Factura.ResetFlagDirty()

                    End With

                End If

                scdrReader.Close()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub [Select](ByVal FolioSAP As String, ByRef Factura As Factura)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaSelByFolioSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@FolioSAP").Value = FolioSAP.Trim

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        Factura.FacturaID = .GetInt32(0)
                        Factura.CodAlmacen = .GetString(1)
                        Factura.CodCaja = .GetString(2)
                        Factura.FolioFactura = .GetInt32(3)
                        Factura.ApartadoID = .GetInt32(4)
                        Factura.NotaCreditoID = .GetInt32(5)
                        Factura.StatusFactura = .GetString(6)
                        Factura.CodTipoVenta = .GetString(7)
                        Factura.ClienteId = CInt(.GetString(8))
                        Factura.CodVendedor = .GetString(9)
                        Factura.DescTotal = .GetDecimal(10)
                        Factura.SubTotal = .GetDecimal(11)
                        Factura.IVA = .GetDecimal(12)
                        Factura.Total = .GetDecimal(13)
                        Factura.Impresa = .GetBoolean(14)
                        Factura.Usuario = .GetString(15)
                        Factura.Fecha = .GetDateTime(16)
                        Factura.StatusRegistro = .GetBoolean(17)
                        Factura.NumeroFacilito = .GetString(18)
                        Factura.FolioSAP = .GetString(.GetOrdinal("FolioSAP"))
                        Factura.FolioFISAP = .GetString(.GetOrdinal("FolioFISAP"))
                        Factura.DPesos = .GetDecimal(.GetOrdinal("DPesos"))
                        Factura.Saldo = .GetDecimal(.GetOrdinal("Saldo"))
                        Factura.FCancelacionSD = .GetString(.GetOrdinal("FCFolioSAP"))
                        Factura.FCancelacionFI = .GetString(.GetOrdinal("FCFolioFISAP"))
                        Factura.ClientPGID = .GetInt32(.GetOrdinal("ClientePGID"))
                        Factura.RazonRechazo = .GetString(.GetOrdinal("RazonRechazo"))
                        If IsDBNull(.GetInt32(.GetOrdinal("PedidoID"))) = False Then Factura.PedidoID = .GetInt32(.GetOrdinal("PedidoID"))
                        '--------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 21/04/2015: No. de tarjeta DPCard Puntos cuando se realiza canje de puntos
                        '--------------------------------------------------------------------------------------------------------
                        Factura.NoDPCardPuntos = CStr(scdrReader("NoDPCardPuntos"))
                        Factura.CodDPCardPunto = CStr(scdrReader("CodDPCardPunto"))

                        'Actualizamos Status del Objeto
                        Factura.ResetFlagNew()
                        Factura.ResetFlagDirty()

                    End With

                End If

                scdrReader.Close()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function MotivosFacSel() As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand
        Dim oResult As DataSet

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[MotivosFacSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            Dim oFacturaAdapter As SqlDataAdapter
            oFacturaAdapter = New SqlDataAdapter
            oFacturaAdapter.SelectCommand = sccmdSelect

            oFacturaAdapter.Fill(oResult)

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("Los motivos de captura manual no pueden ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("Los motivos de captura manual no pueden ser leidos debido a un error de aplicación.", ex)

        End Try

        Return oResult

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Function

    Public Function GetNumeroFacilito(ByVal intFolioID As Integer) As String


        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[SelNumFacilito]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioID", System.Data.SqlDbType.Int, 4))


        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FolioID").Value = intFolioID

                Dim scdrReader As SqlDataReader
                'Execute Reader
                scdrReader = .ExecuteReader
                scdrReader.Read()
                If scdrReader.HasRows Then
                    Return scdrReader.GetString(scdrReader.GetOrdinal("NumeroFacilito")).Trim
                Else
                    Return ""
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

        End Try

        ' Return ""



    End Function

    Public Function SelectVentasPGSinEnviar(ByVal Tipo As Integer) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaSelFaltaEnvioPG]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Tipo", SqlDbType.Int, 4, "Tipo: 1 Facturas 2 Cancelaciones"))

            .Parameters("@Tipo").Value = Tipo
        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "FacturasPGSinEnviar")

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

    Public Function SelectRazonesRechazo(ByRef bResult As Boolean, ByVal Modulo As String) As DataTable

        Dim oCon As New SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdSelAll As SqlClient.SqlCommand
        Dim scdsRazones As DataSet
        Dim scdaRazones As SqlClient.SqlDataAdapter

        sccmdSelAll = New SqlClient.SqlCommand
        scdsRazones = New DataSet("RazonesRechazo")
        scdaRazones = New SqlClient.SqlDataAdapter

        bResult = False

        With sccmdSelAll

            .Connection = oCon
            .CommandText = "[CatalogoRazonesSelAll]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Modulo", SqlDbType.VarChar, 2))

            .Parameters("@Modulo").Value = Modulo.ToUpper.Trim

        End With

        scdaRazones.SelectCommand = sccmdSelAll

        Try

            oCon.Open()

            scdaRazones.Fill(scdsRazones, "RazonesRechazo")

            oCon.Close()

            bResult = True

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            'MsgBox(exSQL)

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return scdsRazones.Tables(0)

    End Function

    Public Function [Select](ByVal EnabledRecordsOnly As Boolean, ByVal CodCaja As String) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaCAJASelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EnabledRecordsOnly", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters("@EnabledRecordsOnly").Value = EnabledRecordsOnly
            .Parameters("@CodCaja").Value = CodCaja

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "Facturas")

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

    Public Function [SelectFacturasCDT](ByVal ClienteID As String, ByVal band As Boolean) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            If band Then
                .CommandText = "[FacturaClienteIDSelAllCDT]"
            Else
                .CommandText = "[FacturaClienteIDSelAllCDTExcell]"
            End If

            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteId", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@ClienteId").Value = ClienteID

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "Facturas")

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

    Public Function SelectMotivosFac(ByVal datFechaIni As Date, ByVal datFechaFin As Date, ByVal strTipoMovto As String) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CatalogoMotivosFacSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoMovto", System.Data.SqlDbType.VarChar, 5))
            .Parameters("@FechaIni").Value = datFechaIni
            .Parameters("@FechaFin").Value = datFechaFin
            .Parameters("@TipoMovto").Value = strTipoMovto

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult)

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

    Public Function SelectFolioCaja(ByVal FolioSAP As String) As DataSet
        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaFolioCajaGet]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@Referencia").Value = FolioSAP

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "FolioCaja")

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

    Public Function [SelectFacturaClienteID](ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, Optional ByVal ClienteID As String = "", Optional ByVal CodTipoVenta As String = "")

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaClienteIDSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteId", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.VarChar, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicio", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))

            If ClienteID <> String.Empty Then
                ClienteID = ClienteID.PadLeft(10, "0")
            End If
            .Parameters("@ClienteId").Value = ClienteID
            .Parameters("@CodTipoVenta").Value = CodTipoVenta
            .Parameters("@FechaInicio").Value = Format(FechaInicio, "Short Date")
            .Parameters("@FechaFin").Value = Format(FechaFin, "Short Date")

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "Facturas")

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

    Public Function [SelectFacturasEdoCuentaCDTAll](ByVal ClienteID As String) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturasEdoCuentaCDTAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteId", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@ClienteId").Value = ClienteID

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "Facturas")

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

    Public Function [SelectFacturaEdoCuentaCDT](ByVal FolioFactura As Integer) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaEdoCuentaCDT]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
            .Parameters("@FolioFactura").Value = FolioFactura

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "Facturas")

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

    Public Function SelectTipoCliente(ByVal TipoVenta As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim strCliente As String = ""
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoTipoVentaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.Char, 1))

            'Assign Parameters Values
            .Parameters("@CodTipoVenta").Value = TipoVenta

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then
                    strCliente = scdReader("TipoCliente")
                Else
                    strCliente = ""

                End If
                scdReader = Nothing
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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return strCliente.Trim.ToUpper

    End Function

    Public Function SelectTipoVenta(ByVal CodMotivo As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim strTipo As String = ""
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoTipoVentaSelCodigo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMotPedido", System.Data.SqlDbType.VarChar, 3))

            'Assign Parameters Values
            .Parameters("@CodMotPedido").Value = CodMotivo

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    With scdReader
                        strTipo = .GetString(.GetOrdinal("CodTipoVenta")).Trim.ToUpper
                    End With

                End If
                scdReader = Nothing
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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return strTipo.Trim.ToUpper
    End Function



    Public Function GetDctoByIdAndProduct(ByVal FacturaID As Integer, ByVal CodProducto As String) As Decimal
        Dim oResult As Decimal
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ConsultaDctoProdFacturaCorrida]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))

            'Assign Parameters Values
            .Parameters("@CodArticulo").Value = CodProducto.PadLeft(18, "0")
            .Parameters("@FacturaID").Value = FacturaID

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then
                    oResult = CDec(scdReader("Descuento"))
                Else
                    oResult = 0
                End If
                scdReader = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return oResult
    End Function

    Public Function [SelectDetalle](ByVal FacturaID As Integer) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaCorridaDetalleSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))
            .Parameters("@FacturaID").Value = FacturaID

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "FacturaDetalle")

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

    Public Function SelectVtasTACR(ByVal Fecha As Date) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturasFormasPagoSelVtasTACR]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime, 8, "Fecha"))
            .Parameters("@Fecha").Value = Fecha

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "FacturaVtasTACR")

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

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Public Function SelectFormasPagoDia(ByVal Fecha As Date) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturasFormasPagoSelByFecha]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime, 8, "Fecha"))
            .Parameters("@Fecha").Value = Fecha
        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "FacturasFormasPago")

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult.Tables(0)

    End Function

    Public Function SelectPromoPago(ByVal Ticket As Integer, ByVal Fecha As Date, ByVal Adquiriente As String) As Integer

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringAfil)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim Promo As Integer
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[VentasTACRSelPromo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ticket", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Adquiriente", System.Data.SqlDbType.VarChar, 2))

            'Assign Parameters Values
            .Parameters("@Ticket").Value = Ticket
            .Parameters("@Fecha").Value = Fecha
            .Parameters("@Adquiriente").Value = Adquiriente

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    Promo = scdReader.GetInt32(0)

                Else

                    Promo = 0

                End If

                scdReader = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return Promo

    End Function

    Public Function SelectVtasTotales(ByVal Fecha As Date) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturasFormasPagoSelVtasTotales]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime, 8, "Fecha"))
            .Parameters("@Fecha").Value = Fecha

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "FacturasVtasTotales")

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

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Public Sub SelectExistencia(ByVal CodArticulo As String, ByVal CodAlmacen As String, ByVal strTalla As String, ByVal oFactura As Factura, ByVal CodElectronico As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ConsultaExistenciasSel]" '"[ConsultaExistenciaTallaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))

            'Assign Parameters Values
            .Parameters("@CodArticulo").Value = CodArticulo.PadLeft(18, "0")
            .Parameters("@CodAlmacen").Value = CodAlmacen
            '.Parameters("@Numero").Value = strTalla

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    '---------------------------------------------------------------------------------------------------------------
                    ' JNAVA (29.04.2016): Validamos si es de consignacion (electronico) o no para obtener el libre para factura
                    '--------------------------------------------------------------------------------------------------------------
                    Dim Libre As Decimal = Decimal.Zero
                    If CodElectronico.Trim <> "0" Then
                        Libre = CDec(scdReader("Consignacion")) + CDec(scdReader("Libre"))
                    Else
                        Libre = CDec(scdReader("Libre"))
                    End If

                    oFactura.FacturaArticuloExistencia = Libre 'CDec(scdReader("Libre"))
                    '---------------------------------------------------------------------------------------------------------------
                    oFactura.ExistenciaApartado = CDec(scdReader("Apartados"))

                Else

                    oFactura.FacturaArticuloExistencia = 0
                    oFactura.ExistenciaApartado = 0

                End If

                scdReader = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    Public Function getTotalRegistros(ByVal CodArticulo As String) As Integer

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim Total As Integer = 0

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[GetTotalArticulosExistencias]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))


            'Assign Parameters Values
            .Parameters("@CodArticulo").Value = CodArticulo


        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then
                    With scdReader
                        Total = scdReader.GetInt32(scdReader.GetOrdinal("Total"))
                    End With
                End If

                scdReader = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return Total

    End Function

    Public Function SelectValeEmpleado(ByVal FacturaID As Integer) As ValeEmpleado

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim oValeE As ValeEmpleado
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ValeEmpleadoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))

            'Assign Parameters Values
            .Parameters("@FacturaID").Value = FacturaID

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    With scdReader
                        oValeE = New ValeEmpleado
                        oValeE.Folio = .GetInt32(.GetOrdinal("Folio"))
                        oValeE.Serie = .GetString(.GetOrdinal("Serie"))
                    End With

                Else

                    oValeE = Nothing

                End If

                scdReader = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return oValeE

    End Function

    Public Function SelectValeEmpleadoByPedido(ByVal PedidoId As Integer) As ValeEmpleado
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim oValeE As ValeEmpleado
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ValeEmpleadoSelByPedido]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PedidoId", System.Data.SqlDbType.Int, 4))

            'Assign Parameters Values
            .Parameters("@PedidoId").Value = PedidoId

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    With scdReader
                        oValeE = New ValeEmpleado
                        oValeE.Folio = .GetInt32(.GetOrdinal("Folio"))
                        oValeE.Serie = .GetString(.GetOrdinal("Serie"))
                    End With

                Else

                    oValeE = Nothing

                End If

                scdReader = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return oValeE
    End Function

    Public Function SelectValeEmpleadoByFolio(ByVal Folio As String, ByVal Serie As String, ByRef referencia As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim Result As Boolean
        Dim FacturaID As Integer = 0
        Dim oFacturaTemp As Factura

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ValeEmpleadoSelByFolio]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Serie", System.Data.SqlDbType.VarChar, 2))

            'Assign Parameters Values
            .Parameters("@Folio").Value = Folio.PadLeft(5, "0")
            .Parameters("@Serie").Value = Serie

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    FacturaID = scdReader.GetInt32(0)
                    Result = True
                Else

                    Result = False

                End If

                scdReader = Nothing

            End With

            sccnnConnection.Close()

            oFacturaTemp = oParent.Create()
            Me.Select(FacturaID, oFacturaTemp)
            'FolioSAP = oFacturaTemp.FolioSAP
            'Cambio para  el SAP Retail
            referencia = oFacturaTemp.Referencia
            oFacturaTemp = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return Result

    End Function

    Public Function SelectFolioReCuponDescuento(ByVal NotaCreditoID As Integer) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim strFolio As String = ""
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ReCuponesSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int, 4))

            'Assign Parameters Values
            .Parameters("@NotaCreditoID").Value = NotaCreditoID

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    With scdReader
                        strFolio = .GetString(.GetOrdinal("Folio")).Trim.ToUpper
                    End With

                Else

                    strFolio = ""

                End If

                scdReader = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return strFolio.Trim.ToUpper

    End Function

    Public Function SelectReCuponDescuentoByFolio(ByVal Folio As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim bResult As Boolean = False
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ReCuponesSelByFolio]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 10))

            'Assign Parameters Values
            .Parameters("@Folio").Value = Folio

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    With scdReader
                        bResult = .GetBoolean(.GetOrdinal("Reimpreso"))
                    End With

                Else

                    bResult = False

                End If

                scdReader = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return bResult

    End Function

    Public Sub ActualizarFolioCupon(ByVal FacturaID As Integer, ByVal folio As String)
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("UPDATE Cupones SET Folio=@Folio WHERE FacturaID=@FacturaID", conexion)
        Try
            With command
                command.Parameters.Add("@Folio", folio)
                command.Parameters.Add("@FacturaID", FacturaID)
            End With
            conexion.Open()
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)
        End Try
    End Sub

    Public Function SelectFolioCuponDescuento(ByVal FacturaID As Integer) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim strFolio As String = ""
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CuponesSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))

            'Assign Parameters Values
            .Parameters("@FacturaID").Value = FacturaID

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    With scdReader
                        strFolio = .GetString(.GetOrdinal("Folio")).Trim.ToUpper
                    End With

                Else

                    strFolio = ""

                End If

                scdReader = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return strFolio.Trim.ToUpper

    End Function

    Public Function SelectCuponDescuentoByFolio(ByVal Folio As String, ByRef FolioSAP As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        Dim Result As Boolean
        Dim FacturaID As Integer = 0
        Dim oFacturaTemp As Factura

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CuponesSelByFolio]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 10))

            'Assign Parameters Values
            .Parameters("@Folio").Value = IIf(IsNumeric(Folio.Trim) = True, Folio.Trim.PadLeft(10, "0"), Folio.Trim.ToUpper)

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    FacturaID = scdReader.GetInt32(scdReader.GetOrdinal("FacturaID"))
                    Result = True
                Else

                    Result = False

                End If

                scdReader = Nothing

            End With

            sccnnConnection.Close()

            oFacturaTemp = oParent.Create()
            Me.Select(FacturaID, oFacturaTemp)
            FolioSAP = oFacturaTemp.FolioSAP
            oFacturaTemp = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return Result

    End Function

    Public Sub SelectTallas(ByVal CodCorrida As String, ByVal oFactura As Factura)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCorridasSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCorrida", System.Data.SqlDbType.VarChar, 25, "CodCorrida"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCorrida").Value = CodCorrida

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    oFactura.FacturaArticuloTallaDel = scdReader.GetDecimal(2)
                    oFactura.FacturaArticuloTallaAl = scdReader.GetDecimal(3)

                Else

                    oFactura.FacturaArticuloTallaDel = 0
                    oFactura.FacturaArticuloTallaAl = 0

                End If

                scdReader = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function SelectTallasCorrida(ByVal CodCorrida As String) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCorridasTallasSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCorrida", System.Data.SqlDbType.VarChar, 3, "CodCorrida"))
            .Parameters("@CodCorrida").Value = CodCorrida

        End With

        Dim oCorridasTallasAdapter As SqlDataAdapter
        oCorridasTallasAdapter = New SqlDataAdapter
        oCorridasTallasAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oCorridasTallasAdapter.Fill(oResult, "Tallas")

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

    Public Function SelectUPC(ByVal CodUPC As String) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoUPCSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUPC", System.Data.SqlDbType.VarChar, 20, "CodUPC"))
            .Parameters("@CodUPC").Value = CodUPC.PadLeft(18, "0")

        End With

        Dim oUPCAdapter As SqlDataAdapter
        oUPCAdapter = New SqlDataAdapter
        oUPCAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oUPCAdapter.Fill(oResult, "UPC")

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

        Return oResult.Tables(0)

    End Function

    Public Function [SelectFacturaToReport](ByVal FacturaID As Integer) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaToReport]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))
            .Parameters("@FacturaID").Value = FacturaID

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "FacturaToReport")

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

    Public Sub UpdateApartadoAsEntregado(ByVal oApartadoID As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "UPDATE Apartados SET Entregada='S' WHERE ApartadoID = " & oApartadoID & ""
            .CommandType = System.Data.CommandType.Text

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate

                'Ejecutamos Comando
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub UpdatePlayer(ByVal oFactura As Factura)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[FacturaUpdPlayer]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 10, "CodVendedor"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = oFactura.FacturaID
                .Parameters("@CodVendedor").Value = oFactura.CodVendedor
                .Parameters("@Fecha").Value = Now.Date

                'Execute Command
                .ExecuteNonQuery()
                oFactura.Fecha = .Parameters("@Fecha").Value

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub UpdateSaldo(ByVal oFactura As Factura)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[FacturaUpdSaldo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Saldo", System.Data.SqlDbType.Money, 4, "Saldo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = oFactura.FacturaID
                .Parameters("@Saldo").Value = oFactura.Saldo
                .Parameters("@Fecha").Value = Now.Date

                'Execute Command
                .ExecuteNonQuery()
                oFactura.Fecha = .Parameters("@Fecha").Value

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function SelectByDateDescuentosOtorgados(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDescuentosOtorgados As SqlDataAdapter
        Dim dsDescuentosOtorgados As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDescuentosOtorgados = New SqlDataAdapter
        dsDescuentosOtorgados = New DataSet("Facturas")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[RptDescuentosOtorgados]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8))
        End With

        scdaDescuentosOtorgados.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaDescuentosOtorgados.SelectCommand.Parameters("@FechaIni").Value = FechaIni
            scdaDescuentosOtorgados.SelectCommand.Parameters("@FechaFin").Value = FechaFin

            'Fill DataSet
            scdaDescuentosOtorgados.Fill(dsDescuentosOtorgados, "Facturas")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsDescuentosOtorgados

    End Function

    Public Function SelectFacturasLiquidadas(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFacturas As SqlDataAdapter
        Dim dsLiquidadas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFacturas = New SqlDataAdapter
        dsLiquidadas = New DataSet("Liquidadas")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[FacturasLiquidadasSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Desde", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Hasta", System.Data.SqlDbType.DateTime, 8))
        End With

        scdaFacturas.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaFacturas.SelectCommand.Parameters("@Desde").Value = FechaIni
            scdaFacturas.SelectCommand.Parameters("@Hasta").Value = FechaFin

            'Fill DataSet
            scdaFacturas.Fill(dsLiquidadas, "Liquidadas")

            sccnnConnection.Close()

            If dsLiquidadas.Tables(0).Rows.Count > 0 Then
                dsLiquidadas = FormatearFacturasLiquidadas(dsLiquidadas)
            End If

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsLiquidadas

    End Function

    Private Function FormatearFacturasLiquidadas(ByVal ds As DataSet) As DataSet

        Dim dtFormated As DataTable
        Dim dsFormated As DataSet = New DataSet
        Dim dCol As DataColumn
        Dim oRow As DataRow
        Dim oRowNew As DataRow

        'Clonamos la estructura de la tabla original
        dtFormated = ds.Tables(0).Clone()

        'Agregamos columna para relacion de abonos
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "Abonos"
        dCol.Caption = "Abonos"
        dCol.DefaultValue = ""
        dtFormated.Columns.Add(dCol)

        'Iniciamos el formateo
        Dim intFolioFactura As Integer = 0
        Dim vCaja As String = String.Empty
        For Each oRow In ds.Tables(0).Rows

            If oRow!FolioFactura <> intFolioFactura Or oRow!CodCaja <> vCaja Then

                If intFolioFactura <> 0 Then
                    dtFormated.Rows.Add(oRowNew)
                End If

                oRowNew = dtFormated.NewRow
                oRowNew!FolioFactura = oRow!FolioFactura
                oRowNew!CodCaja = oRow!CodCaja
                oRowNew!Total = oRow!Total
                oRowNew!FolioApartado = oRow!FolioApartado
                oRowNew!FolioAbono = 0
                oRowNew!CodVendedor = oRow!CodVendedor
                oRowNew!Fecha = oRow!Fecha
                oRowNew!CodFormasPago = oRow!CodFormasPago
                oRowNew!Abonos = CStr(oRow!FolioAbono)

                intFolioFactura = oRow!FolioFactura
                vCaja = oRow!CodCaja

            Else

                oRowNew!Abonos = Trim(oRowNew!Abonos) & ", " & CStr(oRow!FolioAbono)

            End If

        Next
        dtFormated.Rows.Add(oRowNew)

        'Agregamos la tabla clonada al dataset
        dsFormated.Tables.Add(dtFormated)

        Return dsFormated

    End Function

    Friend Sub SelectCondicionVenta(ByVal oCondicionVenta As CondicionesVtaSAP)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CondicionesVentaFacturaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVtas", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Jerarquia", System.Data.SqlDbType.VarChar, 18))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CondMat", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CondPrec", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Material", System.Data.SqlDbType.VarChar, 18))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ListPrec", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@OficinaVtas").Value = oCondicionVenta.OficinaVtas
            .Parameters("@Jerarquia").Value = oCondicionVenta.Jerarquia
            .Parameters("@CondMat").Value = oCondicionVenta.CondMat
            .Parameters("@CondPrec").Value = oCondicionVenta.CondPrec
            .Parameters("@Material").Value = oCondicionVenta.Material
            .Parameters("@ListPrec").Value = oCondicionVenta.ListPrec

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'Actualizamos Status del Objeto
                        oCondicionVenta.Condicion = .GetString(0)
                        oCondicionVenta.OrgVtas = .GetString(1)
                        oCondicionVenta.CanalDist = .GetString(2)
                        oCondicionVenta.Jerarquia = .GetString(3)
                        oCondicionVenta.CondMat = .GetString(4)
                        oCondicionVenta.CondPrec = .GetString(5)
                        oCondicionVenta.Material = .GetString(6)
                        oCondicionVenta.OficinaVtas = .GetString(7)
                        oCondicionVenta.ListPrec = .GetString(8)
                        oCondicionVenta.FechaIni = .GetDateTime(9)
                        oCondicionVenta.FechaFin = .GetDateTime(10)
                        oCondicionVenta.DescPorcentaje = .GetDecimal(11)
                        oCondicionVenta.Descmonto = .GetDecimal(12)

                    End With

                Else

                    oCondicionVenta.Clear()

                End If

                scdrReader.Close()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function SelectDateServer() As DateTime

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringFP)

        Dim sccmdSelect As New SqlCommand
        Dim scdrReader As SqlDataReader

        Dim FechaServer As DateTime

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[GetDateServer]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPromo", System.Data.SqlDbType.Int, 4))
            '.Parameters.Add(New SqlParameter("@CodBanco", SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        FechaServer = .GetDateTime(.GetOrdinal("Fecha"))

                        .Close()

                    End With
                Else
                    FechaServer = Now
                End If

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return FechaServer

    End Function


    Public Function SelectMotivos() As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPC)
        Dim sccmdSelectAll As SqlCommand
        Dim scdaMotivos As SqlDataAdapter
        Dim dsMotivos As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMotivos = New SqlDataAdapter
        dsMotivos = New DataSet("MotivosCaptura")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[GetMotivos]"
            .CommandType = System.Data.CommandType.StoredProcedure
        End With

        scdaMotivos.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaMotivos.Fill(dsMotivos, "MotivosCaptura")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsMotivos.Tables(0)

    End Function


    Public Function InsTransaccionSinTarjeta(ByVal tienda As String, ByVal caja As String, _
                                        ByVal accountNumber As String, ByVal numtarjeta As String, ByVal monto As Decimal, _
                                        ByVal transactionType As String, ByVal estatus As String, ByVal nombrecliente As String, _
                                        ByVal motivo As String, ByVal empleadoGenero As String, ByVal empleadoAutorizo As String) As Integer



        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPC)
        Dim sccmdInsert As SqlCommand
        Dim iResult As Integer = 0
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection
            .CommandText = "[InsertTransaccionesSinTarjetas]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Id", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tienda", System.Data.SqlDbType.VarChar, 5, "Tienda"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Caja", System.Data.SqlDbType.VarChar, 5, "Caja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AccountNumber", System.Data.SqlDbType.VarChar, 15, "AccountNumber"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumTarjeta", System.Data.SqlDbType.VarChar, 50, "NumTarjeta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Monto", System.Data.SqlDbType.Decimal, 15, "Monto"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TransactionType", System.Data.SqlDbType.VarChar, 15, "TransactionType"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estatus", System.Data.SqlDbType.VarChar, 30, "Estatus"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreCliente", System.Data.SqlDbType.VarChar, 40, "NombreCliente"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MotivoTransaccion", System.Data.SqlDbType.VarChar, 50, "MotivoTransaccion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmpleadoGenero", System.Data.SqlDbType.VarChar, 50, "EmpleadoGenero"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmpleadoAutorizo", System.Data.SqlDbType.VarChar, 50, "EmpleadoAutorizo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Validacion", System.Data.SqlDbType.Bit, 1, "Validacion"))
        End With

        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values                
                .Parameters("@Id").Value = 0
                .Parameters("@Tienda").Value = tienda
                .Parameters("@Caja").Value = caja
                .Parameters("@AccountNumber").Value = accountNumber
                .Parameters("@NumTarjeta").Value = numtarjeta
                .Parameters("@Monto").Value = monto
                .Parameters("@TransactionType").Value = transactionType
                .Parameters("@Estatus").Value = estatus
                .Parameters("@NombreCliente").Value = nombrecliente
                .Parameters("@MotivoTransaccion").Value = motivo
                .Parameters("@EmpleadoGenero").Value = empleadoGenero
                .Parameters("@EmpleadoAutorizo").Value = empleadoAutorizo
                .Parameters("@Validacion").Value = 0

                'Execute Command
                .ExecuteNonQuery()

                iResult = .Parameters("@Id").Value
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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return iResult
    End Function


    'vargas
    '------------------------------------------------------------------------------------------
    ' MLVARGAS 28/02/2020: Funcion para actualizar el estatus de la Transacción sin tarjeta
    '-------------------------------------------------------------------------------------------
    Public Sub UpdTransaccionesSinTarjeta(ByVal id As Integer, ByVal status As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPC)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand
        Dim Result As String = ""

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[UpdateTransaccionesSinTarjeta]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "ID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 30, "Status"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@Id").Value = id
                .Parameters("@Status").Value = status

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

            Result = oSqlException.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Result = ex.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
    End Sub



    Public Function SelectUsersRoles() As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[UsersRolesSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EnabledRecordsOnly", System.Data.SqlDbType.Bit, 1))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            '.Parameters("@EnabledRecordsOnly").Value = EnabledRecordsOnly
            '.Parameters("@CodCaja").Value = CodCaja

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "UsersRoles")

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

#Region "Notas venta Manual"
    Public Function CargarFolioNext() As Integer
        Dim cnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdGetLimite As SqlCommand
        Dim drGetLimite As SqlDataReader
        Dim LimiteInferior As Integer

        cmdGetLimite = New SqlCommand


        With cmdGetLimite
            .Connection = cnnString
            .CommandText = "FolioNotaVentaToFact"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            'Asignacion de valores
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
        End With

        Try
            cnnString.Open()
            drGetLimite = cmdGetLimite.ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
            drGetLimite.Read()
            If (drGetLimite.HasRows) Then
                LimiteInferior = CInt(drGetLimite("FolioVentaManual"))
            Else
                drGetLimite.Close()
                cnnString.Close()
                LimiteInferior = 0
            End If

        Catch oSqlException As SqlException
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)
        End Try

        cnnString.Dispose()
        cnnString = Nothing

        Return LimiteInferior


    End Function
#End Region

#End Region

#Region "Revale"

    Public Function [VentasDPValeDelDia](ByVal Fecha As DateTime) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[VentasDPValeDelDia]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@Fecha").Value = Fecha.ToShortDateString

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "VentasDPVale")

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

    Public Function VtasCompreLineaPagueTiendaDia(ByVal Fecha As DateTime) As DataSet
        Dim dtReporte As New DataSet()
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("PagosEcommerceDPVale", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            command.Parameters.AddWithValue("@Fecha", Fecha)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtReporte, "VentasDPVale")
            command.Dispose()
            conexion.Close()
        Catch Sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(Sql.Message, Sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtReporte
    End Function


#End Region

#Region "Facturacion SiHay"

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Función para insertar los datos de la Factura para la Facturación SiHay
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Sub InsertSH(ByVal oFactura As Factura)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[FacturaInsPedido]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "FacturaID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3, "CodAlmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2, "CodCaja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4, "FolioFactura"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int, 4, "ApartadoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int, 4, "NotaCreditoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 3, "Status"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.VarChar, 1, "CodTipoVenta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10, "ClienteID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 12, "CodVendedor"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescTotal", System.Data.SqlDbType.Money, 4, "DescTotal"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SubTotal", System.Data.SqlDbType.Money, 4, "SubTotal"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Money, 4, "IVA"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Money, 4, "Total"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Impresa", System.Data.SqlDbType.Bit, 1, "Impresa"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroFacilito", System.Data.SqlDbType.VarChar, 30, "NumeroFacilito"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 30, "FolioSAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFISAP", System.Data.SqlDbType.VarChar, 30, "FolioFISAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPesos", System.Data.SqlDbType.Money, 4, "DPesos"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Saldo", System.Data.SqlDbType.Money, 4, "Saldo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioVentaManual", System.Data.SqlDbType.Int, 4, "FolioVentaManual"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClientePGID", System.Data.SqlDbType.Int, 4, "Cliente PG Id"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Razon", System.Data.SqlDbType.VarChar, 250, "Razon del Rechazo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RazonID", System.Data.SqlDbType.Int, 4, "ID Razon del Rechazo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EnvioServerPG", System.Data.SqlDbType.Bit, 1, "Enviado al server"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EnvioServerPGCan", System.Data.SqlDbType.Bit, 1, "Enviado al server Cancelacion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PedidoID", System.Data.SqlDbType.Int, 4, "PedidoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 20, "Referencia"))
        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = 0
                .Parameters("@CodAlmacen").Value = oFactura.CodAlmacen
                .Parameters("@CodCaja").Value = oFactura.CodCaja
                .Parameters("@FolioFactura").Value = oFactura.FolioFactura
                .Parameters("@ApartadoID").Value = oFactura.ApartadoID
                .Parameters("@NotaCreditoID").Value = oFactura.NotaCreditoID
                .Parameters("@Status").Value = "GRA"
                .Parameters("@CodTipoVenta").Value = oFactura.CodTipoVenta
                .Parameters("@ClienteID").Value = CStr(oFactura.ClienteId).PadLeft(10, "0")
                .Parameters("@CodVendedor").Value = oFactura.CodVendedor
                .Parameters("@DescTotal").Value = oFactura.DescTotal
                .Parameters("@SubTotal").Value = oFactura.SubTotal
                .Parameters("@IVA").Value = oFactura.IVA
                .Parameters("@Total").Value = oFactura.Total
                .Parameters("@Impresa").Value = oFactura.Impresa
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.SessionLoginName
                '.Parameters("@Fecha").Value = Date.Today
                .Parameters("@Fecha").Value = oFactura.Fecha
                .Parameters("@StatusRegistro").Value = 1
                .Parameters("@NumeroFacilito").Value = oFactura.NumeroFacilito
                .Parameters("@FolioSAP").Value = oFactura.FolioSAP
                .Parameters("@FolioFISAP").Value = oFactura.FolioFISAP
                .Parameters("@DPesos").Value = oFactura.DPesos
                .Parameters("@Saldo").Value = oFactura.Saldo
                .Parameters("@FolioVentaManual").Value = oFactura.FolioNotaVentaManual
                .Parameters("@ClientePGID").Value = oFactura.ClientPGID
                .Parameters("@Razon").Value = oFactura.RazonRechazo
                .Parameters("@RazonID").Value = oFactura.RazonRechazoID
                .Parameters("@EnvioServerPG").Value = IIf(oParent.ConfigCierreFI.UsarHuellas, 0, 1)
                .Parameters("@EnvioServerPGCan").Value = IIf(oParent.ConfigCierreFI.UsarHuellas, 0, 1)
                .Parameters("@PedidoID").Value = oFactura.PedidoID
                .Parameters("@Referencia").Value = oFactura.Referencia
                'Execute Command
                .ExecuteNonQuery()

                oFactura.FacturaID = .Parameters("@FacturaID").Value
                oFactura.Fecha = .Parameters("@Fecha").Value

            End With
            'Cambiamos el Status del Folio de la nota de Venta a 1
            If oFactura.FolioNotaVentaManual <> 0 Then
                Dim FolioNtaVenta As Integer = oFactura.FolioNotaVentaManual
                FolioNotaVentaManualUpd(FolioNtaVenta)
            End If
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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub ActualizarFolioCuponPedido(ByVal PedidoID As Integer, ByVal Folio As String)
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("ActualizarFolioCuponPedido", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoID", PedidoID)
            command.Parameters.Add("@Folio", Folio)
            command.ExecuteScalar()
            command.Dispose()
            conexion.Close()
        Catch oSqlException As SqlException

            If (conexion.State <> ConnectionState.Closed) Then
                Try
                    conexion.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (conexion.State <> ConnectionState.Closed) Then
                Try
                    conexion.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)
        End Try
    End Sub

    Public Function GetAllFacturaPedido(ByVal EnabledRecordsOnly As Boolean, ByVal CodCaja As String) As DataSet
        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturasCajasPedidos]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EnabledRecordsOnly", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters("@EnabledRecordsOnly").Value = EnabledRecordsOnly
            .Parameters("@CodCaja").Value = CodCaja

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "Facturas")

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

#End Region

#Region "Venta de Electronicos"

    Public Function [VentasElectronicosDelDia](ByVal Fecha As DateTime) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[VentasElectronicosDelDia]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@Fecha").Value = Fecha.ToShortDateString

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "VentasElectronicos")

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

#End Region

#Region "DP Card"

    Public Function GetPromocionesDPCardByBIN(ByVal bin As Integer, ByVal importe As Decimal, ByVal TipoVenta As String) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPC)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPromo As SqlDataAdapter
        Dim dsPromo As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPromo = New SqlDataAdapter
        dsPromo = New DataSet("Promocion")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoPromocionesSelByBinDPCard]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bin", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New SqlParameter("@Importe", SqlDbType.Decimal, 9))
            .Parameters.Add(New SqlParameter("@TipoVenta", SqlDbType.VarChar, 3))

            .Parameters("@Bin").Value = bin
            .Parameters("@Importe").Value = importe
            .Parameters("@tipoVenta").Value = TipoVenta

        End With

        scdaPromo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaPromo.Fill(dsPromo, "Promocion")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsPromo.Tables(0)

    End Function

#End Region

#Region "Seguros de Vida DPVale"

    '--------------------------------------------------------
    'JNAVA (06.02.2015): Graba el seguro de vida en DPValeTodo
    '--------------------------------------------------------
    Public Function GrabarSeguroDPVale(ByVal FolioDPVale As String, ByVal Beneficiario As String, ByVal Usuario As String) As Boolean

        Dim bResp As Boolean = False
        Dim SegCalzadoID As Integer = 0

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringSeguros)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[SegCalzadoSave]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SegCalzadoID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "SegCalzadoID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioDPVale", System.Data.SqlDbType.VarChar, 10, "FolioDPVale"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Beneficiario", System.Data.SqlDbType.VarChar, 60, "Beneficiario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@SegCalzadoID").Value = 0
                .Parameters("@FolioDPVale").Value = FolioDPVale
                .Parameters("@Beneficiario").Value = Beneficiario
                .Parameters("@Fecha").Value = Date.Now
                .Parameters("@Usuario").Value = Usuario

                'Execute Command
                .ExecuteNonQuery()

                SegCalzadoID = .Parameters("@SegCalzadoID").Value

            End With

            If SegCalzadoID <> 0 Then
                bResp = True
            End If

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return bResp

    End Function

    '--------------------------------------------------------
    'JNAVA (10.02.2015): Obtiene datos del Servidor DPVFinanciero
    '--------------------------------------------------------
    Public Function GetDatosFinanciamiento(ByVal Plaza As String) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPromo As SqlDataAdapter
        Dim dsPromo As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPromo = New SqlDataAdapter
        dsPromo = New DataSet("Financiamiento")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[GetFinanciamiento]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Plaza", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@Tipo", SqlDbType.VarChar, 1))

            .Parameters("@Plaza").Value = Plaza
            .Parameters("@Tipo").Value = "2"

        End With

        scdaPromo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaPromo.Fill(dsPromo, "Financiamiento")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsPromo.Tables(0)

    End Function

    '--------------------------------------------------------
    'JNAVA (10.02.2015): Obtiene datos del Seguro por el DPValeID
    '--------------------------------------------------------
    Public Function GetSeguroDPValeByDPValeID(ByVal DPValeID As String) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringSeguros)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPromo As SqlDataAdapter
        Dim dsPromo As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPromo = New SqlDataAdapter
        dsPromo = New DataSet("Seguro")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[SegCalzadoSelByFolioDPVale]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@FolioDPVale", SqlDbType.VarChar, 10))

            .Parameters("@FolioDPVale").Value = DPValeID
        End With

        scdaPromo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaPromo.Fill(dsPromo, "Seguro")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsPromo.Tables(0)

    End Function

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 13/10/2015: Modificar el beneficiario del seguro de vida
    '--------------------------------------------------------------------------------------------------------------------------

    Public Function ModificarBeneficiario(ByVal FolioDPVale As String, ByVal beneficiario As String, ByVal usuariomod As String, ByVal motivo As String) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(m_strConnectionStringSeguros)

        Dim command As New SqlCommand("ModificarBeneficiario", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@FolioDPVale", FolioDPVale)
            command.Parameters.Add("@Beneficiario", beneficiario)
            command.Parameters.Add("@UsuarioMod", usuariomod)
            command.Parameters.Add("@Motivo", motivo)
            command.ExecuteNonQuery()
            valido = True
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    '---------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/08/2018: Obtiene el aviso de DPVale por  medio del tipo
    '---------------------------------------------------------------------------------------------------------------
    Public Function GetDPValeAviso(ByVal Tipo As String) As String
        Dim texto As String = ""
        Dim conexion As New SqlConnection(m_strConnectionStringSeguros)
        Dim command As New SqlCommand("GetAvisoPoliza", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Tipo", Tipo)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    texto = CStr(reader("Nota"))
                End While
            End If
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return texto
    End Function

#End Region

#Region "DPCard Puntos"

    '-------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/04/2015: Actualizamos el No. de Tarjeta de DPCard Puntos en la factura en que caso que sea canje
    '-------------------------------------------------------------------------------------------------------------------------

    Public Sub ActualizaNoDPCardPuntos(ByVal FacturaId As Integer, ByVal datos As Hashtable)
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("ActualizaFacturaDPCardPuntos", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@FacturaID", FacturaId)
            command.Parameters.AddWithValue("@NoTarjeta", CStr(datos("NoTarjeta")))
            command.Parameters.AddWithValue("@CodDPCardPunto", CStr(datos("CodDPCardPunto")))
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Public Function IsDPCardPuntosKarum(ByVal bin As Integer) As Boolean
        Dim valido As Boolean = False
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPC)

        Dim sccmdSelectAll As New SqlCommand("ValidaBin", sccnnConnection)
        Dim count As Integer = 0


        With sccmdSelectAll

            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bin", System.Data.SqlDbType.Int, 4))

            .Parameters("@Bin").Value = bin


        End With

        Try

            sccnnConnection.Open()

            count = CInt(sccmdSelectAll.ExecuteScalar())
            If count > 0 Then
                valido = True
            End If
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing


        Return valido
    End Function
    'ASANCHEZ 29/03/2021 Busca los bines de Karum y blue
    Public Function IsDPCardPuntosBlue_Karum(ByVal bin As Integer) As DataTable
        Dim conexion As New SqlConnection(m_strConnectionStringBlue)
        Dim command As New SqlCommand("ValidaBin", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim dtSerials As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@bin", bin)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtSerials)
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtSerials
    End Function


    Public Function SelectAllFormasPagoNoAcumula() As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringBlue)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFormasPago As SqlDataAdapter
        Dim dsFormasPago As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFormasPago = New SqlDataAdapter
        dsFormasPago = New DataSet("CatalogoFormasPago")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[FormasPagoNoAcumulanSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))


        End With

        scdaFormasPago.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()


            'Fill DataSet
            scdaFormasPago.Fill(dsFormasPago, "CatalogoFormasPago")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsFormasPago


    End Function


    Public Function insertAutLealtad(ByVal tienda As String, ByVal caja As String, ByVal usuario As String,
                                     ByVal numTarjeta As String, ByVal importe As Decimal, Optional ByVal bonificacion As Boolean = False, Optional ByVal canje As Boolean = False, Optional ByVal autorizado As Boolean = False) As Integer

        Dim autID As Integer = 0

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPC)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[InsertAutLealtad]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@fecha", System.Data.SqlDbType.DateTime, 8, "fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@tienda", System.Data.SqlDbType.VarChar, 50, "tienda"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@caja", System.Data.SqlDbType.VarChar, 50, "caja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@usuario", System.Data.SqlDbType.VarChar, 50, "usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@numTarjeta", System.Data.SqlDbType.VarChar, 50, "numTarjeta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@importe", System.Data.SqlDbType.Decimal, 9, "importe"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@bonificacion", System.Data.SqlDbType.Bit, 1, "bonificacion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@canje", System.Data.SqlDbType.Bit, 1, "canje"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@autID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "autID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@autorizado", SqlDbType.Bit, 1, "autorizado"))

        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values

                .Parameters("@fecha").Value = Date.Now
                .Parameters("@tienda").Value = tienda
                .Parameters("@caja").Value = caja
                .Parameters("@usuario").Value = usuario
                .Parameters("@numTarjeta").Value = numTarjeta
                .Parameters("@importe").Value = importe
                .Parameters("@bonificacion").Value = bonificacion
                .Parameters("@canje").Value = canje
                .Parameters("@autID").Value = 0
                .Parameters("@autorizado").Value = autorizado

                'Execute Command
                .ExecuteNonQuery()

                autID = .Parameters("@autID").Value

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return autID

    End Function

    Public Function GetTransaccionesDPCard(ByVal numTarjeta As String, ByVal fechaIn As DateTime, ByVal fechaFn As DateTime,
                                        ByVal opcion As Integer) As Integer

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPC)

        Dim sccmdSelectAll As New SqlCommand("GetTransaccionesHeaderLoyalty", sccnnConnection)
        Dim count As Integer = 0


        With sccmdSelectAll

            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@numTarjeta", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@fechaIn", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@fechaFn", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@option", System.Data.SqlDbType.Int, 4))

            .Parameters("@numTarjeta").Value = numTarjeta
            .Parameters("@fechaIn").Value = fechaIn
            .Parameters("@fechaFn").Value = fechaFn
            .Parameters("@option").Value = opcion


        End With

        Try

            sccnnConnection.Open()

            count = CInt(sccmdSelectAll.ExecuteScalar())
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing


        Return count
    End Function
    'Trae las transacciónes de blue clientes final del día
    Public Function GetTransaccionesDPCard_BlueFinal(ByVal numTarjeta As String, ByVal fechaIn As DateTime, ByVal fechaFn As DateTime,
                                        ByVal opcion As Integer) As Integer

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringBlue)

        Dim sccmdSelectAll As New SqlCommand("GetTransaccionesHeaderLoyalty", sccnnConnection)
        Dim count As Integer = 0


        With sccmdSelectAll

            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@numTarjeta", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@fechaIn", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@fechaFn", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@option", System.Data.SqlDbType.Int, 4))

            .Parameters("@numTarjeta").Value = numTarjeta
            .Parameters("@fechaIn").Value = fechaIn
            .Parameters("@fechaFn").Value = fechaFn
            .Parameters("@option").Value = opcion


        End With

        Try

            sccnnConnection.Open()

            count = CInt(sccmdSelectAll.ExecuteScalar())
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing


        Return count
    End Function

#End Region

#Region "MQTT Agente"

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 09/11/2015: Obtiene el siguiente folio de MQTT
    '---------------------------------------------------------------------------------------------------------------------------

    Public Function NextFolioFactura(ByVal CodCaja As String) As String
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("NextFolioMQTT", conexion)
        Dim folio As String = ""
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodCaja", CodCaja)
            folio = CStr(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return folio
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 09/11/2015: Actualiza el folio MQTT
    '---------------------------------------------------------------------------------------------------------------------------

    Public Sub UpdateFolioMQTT(ByVal CodCaja As String, ByVal Folio As Int64)
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("UpdateFolioMQTT", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodCaja", CodCaja)
            command.Parameters.AddWithValue("@Folio", Folio)
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

#End Region

#Region "Retail"

    Public Function SaveSerial(ByVal SerialId As String, ByVal Enviado As String, ByVal Usuario As String, Optional ByVal FacturaId As Integer = 0, Optional ByVal ContratoId As Integer = 0, Optional ByVal PedidoId As Integer = 0) As Boolean
        Dim result As Boolean = False
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("SaveSerial", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@SerialId", SerialId)
            command.Parameters.AddWithValue("@FacturaId", FacturaId)
            command.Parameters.AddWithValue("@ContratoId", ContratoId)
            command.Parameters.AddWithValue("@PedidoId", PedidoId)
            command.Parameters.AddWithValue("@Enviado", Enviado)
            command.Parameters.AddWithValue("@Usuario", Usuario)
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
            result = True
        Catch Sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(Sql.Message, Sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return result
    End Function

    Public Function GetSerialsByDate(ByVal fecha As DateTime) As DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetSerialsByDate", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim dtSerials As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Fecha", fecha)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtSerials)
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtSerials
    End Function

    Public Function GetSerialByFacturaId(ByVal FacturaId As Integer) As String
        Dim serialId As String = ""
        Dim oConexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetSerialByFacturaId", oConexion)
        Dim reader As SqlDataReader = Nothing
        Try
            oConexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@FacturaId", FacturaId)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    serialId = CStr(reader("SerialId"))
                End While
            End If
        Catch sql As SqlException
            If oConexion.State <> ConnectionState.Closed Then
                oConexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If oConexion.State <> ConnectionState.Closed Then
                oConexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return serialId
    End Function

    Public Sub GetExistenciaCodProveedor(ByVal CodArticulo As String, ByVal CodAlmacen As String, ByVal strTalla As String, ByVal oFactura As Factura, ByRef oArticulo As CatalogoArticulos.Articulo, Optional ByRef cuenta As Integer = 0)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[GetExistenciaCodProveedor]" '"[ConsultaExistenciaTallaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPadre", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 10))

            'Assign Parameters Values
            .Parameters("@CodPadre").Value = CodArticulo
            .Parameters("@CodAlmacen").Value = CodAlmacen
            .Parameters("@Talla").Value = strTalla
            'If IsNumeric(strTalla) Then
            '    .Parameters("@Talla").Value = Format(CDec(strTalla), "##.0")
            'Else
            '    .Parameters("@Talla").Value = strTalla
            'End If

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()
                If scdReader.HasRows Then
                    Dim oArticuloMgr As New CatalogoArticulos.CatalogoArticuloManager(Me.oParent.ApplicationContext)
                    oArticulo.ClearFields()
                    oArticuloMgr.LoadInto(CStr(scdReader("CodArticulo")), oArticulo)
                    '---------------------------------------------------------------------------------------------------------------
                    ' JNAVA (29.04.2016): Validamos si es de consignacion (electronico) o no para obtener el libre para factura
                    '--------------------------------------------------------------------------------------------------------------
                    Dim Libre As Decimal = Decimal.Zero
                    If oArticulo.CodElectronico.Trim <> "0" Then
                        Libre = CDec(scdReader("Consignacion")) + CDec(scdReader("Libre"))
                    Else
                        Libre = CDec(scdReader("Libre"))
                    End If
                    cuenta = CInt(scdReader("Cuenta"))
                    oFactura.FacturaArticuloExistencia = Libre 'CDec(scdReader("Libre"))
                    '---------------------------------------------------------------------------------------------------------------
                    oFactura.ExistenciaApartado = CDec(scdReader("Apartados"))

                Else

                    oFactura.FacturaArticuloExistencia = 0
                    oFactura.ExistenciaApartado = 0

                End If

                scdReader = Nothing

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/09/2016: Valida que la referencia no se duplique
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function ValidarReferencia(ByVal referencia As String) As String
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("ValidaReferencia", conexion)
        Dim valido As Boolean = False
        Dim count As Integer = 0
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Referencia", referencia)
            count = CInt(command.ExecuteScalar())
            If count > 0 Then
                valido = True
            End If
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/09/2016: Guarda información del Vale
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Function SaveDetalleDPVale(ByVal InfoVale As Dictionary(Of String, Object)) As Boolean
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("InsertarDetalleDPvale", conexion)
        Dim valido As Boolean = False
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@DetalleDPValeId", 0)
            command.Parameters.AddWithValue("@FormaPagoID", CInt(InfoVale("FORMAPAGOID")))
            command.Parameters.AddWithValue("@Numde", CInt(InfoVale("NUMDE")))
            command.Parameters.AddWithValue("@Distribuidor", CStr(InfoVale("DISTRIB")))
            command.Parameters.AddWithValue("@Ctefinal", CStr(InfoVale("CTEDIST")))
            command.Parameters.AddWithValue("@ParesPza", CInt(InfoVale("PARES_PZAS")))
            command.Parameters.AddWithValue("@MontoUtilizado", CDec(InfoVale("MONTO_UTILIZADO")))
            command.Parameters.AddWithValue("@MontoDPVale", CDec(InfoVale("MONTODPVALE")))
            command.Parameters.AddWithValue("@Fecco", CDate(InfoVale("FECCO")))
            command.Parameters.AddWithValue("@Revale", CBool(InfoVale("REVALE")))
            command.Parameters.AddWithValue("@RParesPza", CInt(InfoVale("RPARES_PZAS")))
            command.Parameters.AddWithValue("@RMontoDPVale", CDec(InfoVale("RMONTODPVALE")))
            command.Parameters.AddWithValue("@Zseg", CInt(InfoVale("ZSEG")))
            command.Parameters.AddWithValue("@Impseg", CDec(InfoVale("IMPSEG")))
            command.Parameters.AddWithValue("@Folseg", CInt(InfoVale("FOLSEG")))
            command.Parameters.AddWithValue("@Div", CStr(InfoVale("DIV")))
            command.Parameters.AddWithValue("@DPValeID", CStr(InfoVale("NUMVA")))
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 28/09/2016: Obtenemos el detalle de la información del DPVale
    '------------------------------------------------------------------------------------------------------------------------------------
    Public Function GetInfoDetalleDPValeByFormaPago(ByVal FormaPagoId As Integer) As Dictionary(Of String, Object)
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetDetalleDPValeByFormaPagoId", conexion)
        Dim reader As SqlDataReader = Nothing
        Dim result As New Dictionary(Of String, Object)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@FormaPagoID", FormaPagoId)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    result("DetalleDPValeId") = CInt(reader("DetalleDPValeId"))
                    result("FormaPagoID") = CInt(reader("FormaPagoID"))
                    result("Numde") = CInt(reader("Numde"))
                    result("Distribuidor") = CStr(reader("Distribuidor"))
                    result("Ctefinal") = CStr(reader("Ctefinal"))
                    result("ParesPza") = CInt(reader("ParesPza"))
                    result("MontoUtilizado") = CDec(reader("MontoUtilizado"))
                    result("MontoDPVale") = CDec(reader("MontoDPVale"))
                    result("Fecco") = CDate(reader("Fecco"))
                    result("Revale") = CBool(reader("Revale"))
                    result("RParesPza") = CInt(reader("RParesPza"))
                    result("RMontoDPVale") = CDec(reader("RMontoDPVale"))
                    result("Zseg") = CInt(reader("Zseg"))
                    result("Impseg") = CDec(reader("Impseg"))
                    result("Folseg") = CInt(reader("Folseg"))
                    result("Div") = CStr(reader("Div"))
                    result("DPValeID") = CInt(reader("DPValeID"))
                End While
            End If
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return result
    End Function

    '------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 28/09/2016: Obtenemos los colores que por código proveedor y tallas
    '------------------------------------------------------------------------------------------------------------------------------
    Public Function GetItemsColor(ByVal item As String, ByVal talla As String) As DataTable
        Dim items As New DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetItemsColors", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodPadre", item)
            command.Parameters.AddWithValue("@Talla", talla)
            command.Parameters.AddWithValue("@CodAlmacen", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(items)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return items
    End Function

    Public Function ObtenerReferenciaByFacturaID(ByVal FacturaID As String) As String
        Dim Referencia As String = String.Empty
        Dim oConexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetReferenciaByFacturaID", oConexion)
        Dim reader As SqlDataReader = Nothing
        Try
            oConexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@FacturaID", CInt(FacturaID))
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    Referencia = CStr(reader("Referencia"))
                End While
            End If
        Catch sql As SqlException
            If oConexion.State <> ConnectionState.Closed Then
                oConexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If oConexion.State <> ConnectionState.Closed Then
                oConexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return Referencia
    End Function

#End Region

#Region "CargaNotasCredito"
    ''' <summary>
    ''' Función para retornar todos los registros previamente cargados de notas de crédito masivo
    ''' </summary>
    ''' <returns>Lista de registros de notas de crédito</returns>
    ''' <remarks></remarks>
    Public Function SelectFacturasNotasCreditoMasivo() As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaNotasCreditoMasivoSelect]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4))

            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim.ToUpper

        End With

        Dim oConfigAdapter As New SqlDataAdapter
        oConfigAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oConfigAdapter.Fill(oResult)

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

        Return oResult.Tables(0)

    End Function

    Public Function InsertaFacturasNotasCreditoMasivo(ByVal Registro As String, ByVal Estatus As Integer) As Boolean
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("FacturaNotasCreditoMasivoInsert", conexion)
        Dim valido As Boolean = False
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4))
            command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Registro", System.Data.SqlDbType.VarChar, -1))
            command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estatus", System.Data.SqlDbType.Int, 4))

            command.Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim.ToUpper
            command.Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.SessionLoginName.Trim
            command.Parameters("@Registro").Value = Registro
            command.Parameters("@Estatus").Value = Estatus

            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

#End Region

#Region "Pagos Banamex"

    Public Function GetPromocionesBanamex() As DataTable
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringAfil)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPromo As SqlDataAdapter

        sccmdSelectAll = New SqlCommand
        scdaPromo = New SqlDataAdapter
        Dim dtPromociones As New DataTable

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[GetPromocionesBanamex]"
            .CommandType = System.Data.CommandType.StoredProcedure


        End With

        scdaPromo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaPromo.Fill(dtPromociones)
            sccmdSelectAll.Dispose()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtPromociones
    End Function

#End Region

#Region "Cambio de talla"

    Public Function GetExistenciasCambioTalla(ByVal CodAlmacen As String, ByVal CodArticulo As String, ByVal Color As String) As DataTable
        Dim dtExistencias As New DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetExistenciasCambioTalla", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
            command.Parameters.AddWithValue("@CodArticulo", CodArticulo)
            command.Parameters.AddWithValue("@Color", Color)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtExistencias)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtExistencias
    End Function

    Public Function GetDetalleCorridaCambioTalla(ByVal FacturaId As Integer) As DataTable
        Dim dtDetalle As New DataTable()
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetDetalleCorridaCambioTalla", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@FacturaId", FacturaId)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtDetalle)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtDetalle
    End Function

    Public Function GetDetallePermitidoNotaCredito(ByVal CodArticulo As String, ByVal Referencia As String) As DataTable
        Dim dtDetalle As New DataTable()
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetDetallePermitidoNotaCredito", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            command.Parameters.AddWithValue("@CodArticulo", CodArticulo)
            command.Parameters.AddWithValue("@Referencia", Referencia)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtDetalle)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtDetalle
    End Function

#End Region

#Region "Microcreditos"

    Public Function GetPlazos(ByVal CodAlmacen As String, ByVal Fecha As DateTime) As DataTable
        Dim dtPlazos As New DataTable
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("GetPlazosByTienda", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Tienda", CodAlmacen)
            command.Parameters.AddWithValue("@Fecha", Fecha)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtPlazos)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtPlazos
    End Function

#Region "Servicios Financieros"

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/10/2017: Funcion para obtener Bancos de Servicios Financieros
    '--------------------------------------------------------------------------------
    Public Function GetServiciosFinancieros(ByVal Todos As Boolean) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("GetServiciosFinancieros")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[CatalogoServiciosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Todos", System.Data.SqlDbType.Bit, 1, "Todos"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            sccmdSelectAll.Parameters("@Todos").Value = Todos

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "ServiciosFinancieros")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsDPVF.Tables(0)
    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener Bancos de Servicios Financieros
    '--------------------------------------------------------------------------------
    Public Function GetBancos() As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("Bancos")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[CatalogoBancosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "Bancos")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsDPVF.Tables(0)
    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener las compañia cel de Servicios Financieros
    '--------------------------------------------------------------------------------
    Public Function GetCompañiaCelular() As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("CompañiaCelular")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[CatalogoCompañiaCelularSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "Bancos")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsDPVF.Tables(0)
    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener las compañia cel de Servicios Financieros
    '--------------------------------------------------------------------------------
    Public Function UpdateGenerado(ByVal ID As Integer, ByVal SecFile As Integer) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand
        Dim Result As String = ""

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[DatosArchivosDPVFMarcaPrestamo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, "ID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SecFile", System.Data.SqlDbType.Int, 4, "SecFile"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@ID").Value = ID
                .Parameters("@SecFile").Value = SecFile

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

            Result = oSqlException.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Result = ex.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return Result

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el catalogo de dias inhabiles
    '--------------------------------------------------------------------------------
    Public Function GetCatalogoDiasInhabiles(ByVal Fecha As DateTime) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("CatalogoDiasInhabiles")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoDiasInhabilesSelByFecha]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime, 8, "Fecha Inicio"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@Fecha").Value = Fecha.ToShortDateString

            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "CatalogoDiasInhabiles")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsDPVF.Tables(0)

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el Servicio por su ID
    '--------------------------------------------------------------------------------
    Public Function GetServiciosFinancierosByID(ByVal ID As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn As String

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CatalogoServiciosSelByServicioID]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioID", System.Data.SqlDbType.VarChar, 2, "ServicioID"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@ServicioID").Value = ID

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(2), String.Empty, .GetString(2))

                    End With

                Else

                    strReturn = String.Empty

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener la fecha completa del servidor
    '--------------------------------------------------------------------------------
    Public Function GetFechaServidor() As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn As String

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[FechaServidorSel]"
            .CommandType = CommandType.StoredProcedure

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect


                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(0), String.Empty, .GetSqlDateTime(0).ToString)

                    End With

                Else

                    strReturn = String.Empty

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para Activar o desactivar Servicios financieros
    '--------------------------------------------------------------------------------
    Public Function UpdateServicioActivo(ByVal ServicioID As String, ByVal Activo As Boolean, ByVal Usuario As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand
        Dim Result As String = ""

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[CatalogoServiciosUpdActivo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioID", System.Data.SqlDbType.VarChar, 2, "ServicioID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Activo", System.Data.SqlDbType.Bit, 1, "Activo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 30, "Usuario"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@ServicioID").Value = ServicioID
                .Parameters("@Activo").Value = Activo
                .Parameters("@Usuario").Value = Usuario

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

            Result = oSqlException.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Result = ex.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return Result

    End Function


    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el id_prosa de CatalogoBines
    '--------------------------------------------------------------------------------
    Public Function GetBines(ByVal Bin As String, ByVal Tipo As String, ByVal Activo As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn As String

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CatalogoBinesSelBanco]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bin", System.Data.SqlDbType.VarChar, 20, "Bin"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.VarChar, 1, "Tipo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Activo", System.Data.SqlDbType.Bit, 1, "Activo"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Bin").Value = Bin
                .Parameters("@Tipo").Value = Tipo
                .Parameters("@Activo").Value = Activo

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(0), String.Empty, .GetString(0))

                    End With

                Else

                    strReturn = String.Empty

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el id_prosa de CatalogoBines
    '--------------------------------------------------------------------------------
    Public Function GetBinTransfer(ByVal Bin As String, ByVal Tipo As String, ByVal Activo As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CatalogoBinesSelTransfer]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bin", System.Data.SqlDbType.VarChar, 20, "Bin"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.VarChar, 1, "Tipo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Activo", System.Data.SqlDbType.Bit, 1, "Activo"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Bin").Value = Bin
                .Parameters("@Tipo").Value = Tipo
                .Parameters("@Activo").Value = Activo

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(0), False, .GetBoolean(0))

                    End With

                Else

                    strReturn = False

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para comparar el id_prosa con el código
    '--------------------------------------------------------------------------------
    Public Function GetCodigo(ByVal Codigo As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn As String

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[DatosArchivosDPVFSelCodigo]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 4, "Codigo"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Codigo").Value = Codigo

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(0), String.Empty, .GetString(0))

                    End With

                Else

                    strReturn = String.Empty

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strReturn

    End Function

    '---------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/07/2017: Selecciona la fecha mediante el servicio
    '---------------------------------------------------------------------------------------------------
    Public Function SelectFecha(ByVal ServicioId As Integer, ByVal NoCuenta As String, ByVal Celular As String, ByVal NumeroTarjeta As String, ByVal Clabe As String) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("DatosArchivosDPVF")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DatosArchivosDPVFSelFecha]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@ServicioId", SqlDbType.Int, 4, "Servicio"))
            .Parameters.Add(New SqlParameter("@NoCuenta", SqlDbType.VarChar, 20, "NoCuenta"))
            .Parameters.Add(New SqlParameter("@Celular", SqlDbType.VarChar, 10, "Celular"))
            .Parameters.Add(New SqlParameter("@NumeroTarjeta", SqlDbType.VarChar, 20, "NumeroTarjeta"))
            .Parameters.Add(New SqlParameter("@Clabe", SqlDbType.VarChar, 20, "Clabe"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@ServicioId").Value = ServicioId
                .Parameters("@NoCuenta").Value = NoCuenta
                .Parameters("@Celular").Value = Celular
                .Parameters("@NumeroTarjeta").Value = NumeroTarjeta
                .Parameters("@Clabe").Value = Clabe


            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "DatosArchivosDPVF")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsDPVF

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el ESTATUS por su ID
    '--------------------------------------------------------------------------------
    Public Function GetServiciosFinancierosByID_Act(ByVal ID As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn As Boolean

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CatalogoServiciosSelByServicioID]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioID", System.Data.SqlDbType.VarChar, 2, "ServicioID"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@ServicioID").Value = ID

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(7), False, .GetBoolean(7))
                        'strReturn = IIf(.IsDBNull(2), False, .GetString(2))


                    End With

                Else

                    strReturn = String.Empty

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el Servicio por su ID
    '--------------------------------------------------------------------------------
    Public Function GetFechaDispersion(ByVal ServicioID As String, ByVal FechaDipersion As Date, ByRef dtHorarios As DataTable) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As New SqlCommand
        Dim scdaDPVF As New SqlDataAdapter
        Dim dsDPVF As New DataSet("Horarios")

        Dim strReturn As String = String.Empty

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[GetFechaDispersion]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioId", System.Data.SqlDbType.VarChar, 2, "ServicioId"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@ServicioId").Value = ServicioID
                .Parameters("@Fecha").Value = FechaDipersion

            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "Horarios")

            If dsDPVF Is Nothing Then
                dtHorarios = Nothing
                strReturn = String.Empty
            Else
                If dsDPVF.Tables.Count > 1 Then
                    strReturn = dsDPVF.Tables(0).Rows(0).Item(0).ToString 'Regresamos Fecha Dispersion
                    dtHorarios = dsDPVF.Tables(1) 'Regresamos horarios del servicio
                Else
                    dtHorarios = Nothing
                    strReturn = String.Empty
                End If
            End If

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Guardar Vales a Confirmar de S2Credit por error
    '--------------------------------------------------------------------------------
    Public Sub ConfirmacionS2Credit(ByVal DPVale As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[Pte_ConfirmacS2Ins]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPVale", System.Data.SqlDbType.VarChar, 10, "DPVale"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@DPVale").Value = DPVale

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

        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


#End Region

#Region "Dispersión Expres"

    '----------------------------------------------------------------------------------------------------
    ' JNAVA (22.06.2017): Funcion que valida si el cliente cuenta con un prestamo anterior
    '----------------------------------------------------------------------------------------------------
    Public Function getPrestamoAnterior(ByVal NombreCliente As String, ByVal ServicioID As String, ByVal Valor As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim bResult As Boolean
        Dim ReturnValue As New SqlParameter

        sccmdSelect = New SqlCommand

        With sccmdSelect

            ReturnValue.Direction = Data.ParameterDirection.ReturnValue
            ReturnValue.ParameterName = "ReturnValue"

            .Connection = sccnnConnection
            .CommandText = "[getPrestamoAnterior]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(ReturnValue)
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreCliente", System.Data.SqlDbType.VarChar, 55, "NombreCliente"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioID", System.Data.SqlDbType.VarChar, 2, "ServicioID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Valor", System.Data.SqlDbType.VarChar, 20, "Valor"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@NombreCliente").Value = NombreCliente
                .Parameters("@ServicioID").Value = ServicioID.Trim
                .Parameters("@Valor").Value = Valor

                .ExecuteNonQuery()

                bResult = CBool(.Parameters("ReturnValue").Value)

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return bResult

    End Function

    '--------------------------------------------------------------------------------
    ' JNAVA (23.06.2017): Funcion para obtener los mensajes de la dispersion expres
    '--------------------------------------------------------------------------------
    Public Function GetMensajesCredExpres(ByVal TipoMensaje As Integer) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("MensajesCredExpres")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[getMensajesCredExpres]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.Int, 4, "Tipo"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            sccmdSelectAll.Parameters("@Tipo").Value = TipoMensaje

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "MensajesCredExpres")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsDPVF.Tables(0)
    End Function

    '--------------------------------------------------------------------------------
    ' JNAVA (11.09.2017): Funcion para la fecha de dispersion express
    '--------------------------------------------------------------------------------
    Public Function GetFechaDispersionExpres(ByVal ServicioID As String, ByVal FechaDipersion As Date, ByRef dtHorarios As DataTable) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As New SqlCommand
        Dim scdaDPVF As New SqlDataAdapter
        Dim dsDPVF As New DataSet("Horarios")

        Dim strReturn As String = String.Empty

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[GetFechaDispersionExp]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioId", System.Data.SqlDbType.VarChar, 2, "ServicioId"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@ServicioId").Value = ServicioID
                .Parameters("@Fecha").Value = FechaDipersion

            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "Horarios")

            If dsDPVF Is Nothing Then
                dtHorarios = Nothing
                strReturn = String.Empty
            Else
                If dsDPVF.Tables.Count > 1 Then
                    strReturn = dsDPVF.Tables(0).Rows(0).Item(0).ToString 'Regresamos Fecha Dispersion
                    dtHorarios = dsDPVF.Tables(1) 'Regresamos horarios del servicio
                Else
                    dtHorarios = Nothing
                    strReturn = String.Empty
                End If
            End If

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strReturn

    End Function

#End Region

#End Region

#Region "Devolucion Tarjetas Banamex"

    Public Function GetPedidosFormasPagoBanamex(ByVal CodAlmacen As String, ByVal Tipo As String) As DataTable
        Dim dtDevoluciones As New DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetFacturaPedidoFormasPago", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
            command.Parameters.AddWithValue("@Tipo", Tipo)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtDevoluciones)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtDevoluciones
    End Function

    Public Function GetDevolucionTarjetaById(ByVal DevolucionTarjetaId As Integer) As DevolucionTarjeta
        Dim devolucion As New DevolucionTarjeta(oParent)
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetDevolucionTarjetaById", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@DevolucionTarjetaId", DevolucionTarjetaId)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    devolucion.DevolucionTarjetaId = CInt(reader("DevolucionTarjetaId"))
                    devolucion.NotaCreditoID = CInt(reader("NotaCreditoID"))
                    devolucion.FormaPagoID = CInt(reader("FormaPagoID"))
                    devolucion.CodAlmacen = CStr(reader("CodAlmacen"))
                    devolucion.CodCaja = CStr(reader("CodCaja"))
                    devolucion.CodTipoVenta = CStr(reader("CodTipoVenta"))
                    devolucion.CodFormasPago = CStr(reader("CodFormasPago"))
                    devolucion.CodTipoTarjeta = CStr(reader("CodTipoTarjeta"))
                    devolucion.CodVendedor = CStr(reader("CodVendedor"))
                    devolucion.CodBanco = CStr(reader("CodBanco"))
                    devolucion.NumeroTarjeta = CStr(reader("NumeroTarjeta"))
                    devolucion.NumeroAutorizacion = CStr(reader("NumeroAutorizacion"))
                    devolucion.MontoPago = CDec(reader("MontoPago"))
                    devolucion.Fecha = CDate(reader("Fecha"))
                    devolucion.Referencia = CStr(reader("Referencia"))
                    devolucion.FacturaId = CInt(reader("FacturaId"))
                    devolucion.PedidoId = CInt(reader("PedidoId"))
                    devolucion.Compensado = CBool(reader("Compensado"))
                End While
            End If
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return devolucion
    End Function

    Public Function SaveDevolucionTarjeta(ByVal Devolucion As DevolucionTarjeta) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("SaveDevolucionTarjeta", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            Dim parameter As New SqlParameter("@DevolucionTarjetaId", SqlDbType.Int)
            parameter.Direction = ParameterDirection.InputOutput
            parameter.Value = Devolucion.DevolucionTarjetaId
            command.Parameters.Add(parameter)
            command.Parameters.AddWithValue("@NotaCreditoID", Devolucion.NotaCreditoID)
            command.Parameters.AddWithValue("@FormaPagoID", Devolucion.FormaPagoID)
            command.Parameters.AddWithValue("@CodAlmacen", Devolucion.CodAlmacen)
            command.Parameters.AddWithValue("@CodCaja", Devolucion.CodCaja)
            command.Parameters.AddWithValue("@CodTipoVenta", Devolucion.CodTipoVenta)
            command.Parameters.AddWithValue("@CodFormasPago", Devolucion.CodFormasPago)
            command.Parameters.AddWithValue("@CodTipoTarjeta", Devolucion.CodTipoTarjeta)
            command.Parameters.AddWithValue("@CodVendedor", Devolucion.CodVendedor)
            command.Parameters.AddWithValue("@CodBanco", Devolucion.CodBanco)
            command.Parameters.AddWithValue("@NumeroTarjeta", Devolucion.NumeroTarjeta)
            command.Parameters.AddWithValue("@NumeroAutorizacion", Devolucion.NumeroAutorizacion)
            command.Parameters.AddWithValue("@NoAfiliacion", Devolucion.NoAfiliacion)
            command.Parameters.AddWithValue("@MontoPago", Devolucion.MontoPago)
            command.Parameters.AddWithValue("@Fecha", Devolucion.Fecha)
            command.Parameters.AddWithValue("@Referencia", Devolucion.Referencia)
            command.Parameters.AddWithValue("@FacturaId", Devolucion.FacturaId)
            command.Parameters.AddWithValue("@PedidoId", Devolucion.PedidoId)
            command.Parameters.AddWithValue("@Compensado", Devolucion.Compensado)
            command.ExecuteNonQuery()
            If Devolucion.DevolucionTarjetaId = 0 Then
                Devolucion.DevolucionTarjetaId = parameter.Value
            End If
            command.Dispose()
            conexion.Close()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    Public Function GetNotasCreditoByFactura(ByVal Referencia As String) As DataTable
        Dim dtNotasCredito As New DataTable()
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetNotasCreditoByFactura", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Referencia", Referencia)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtNotasCredito)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtNotasCredito
    End Function

#End Region

#Region "Correccion Ventas incompletas"

    Public Function ValidarFacturaExitosa(ByVal Referencia As String) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("ValidaFacturaByReferencia", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Referencia", Referencia)
            valido = CBool(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    Public Function ValidaPedidoExitoso(ByVal Referencia As String) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("ValidaPedidoByReferencia", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Referencia", Referencia)
            valido = CBool(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

#End Region

End Class
