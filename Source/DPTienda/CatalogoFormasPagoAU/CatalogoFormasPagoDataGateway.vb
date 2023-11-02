Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class CatalogoFormasPagoDataGateway

    Private oParent As CatalogoFormasPagoManager
    Private m_strConnectionString As String
    Private m_strConnectionStringEcomm As String



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoFormasPagoManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString
        m_strConnectionStringEcomm = ""
        If Not oParent.ConfigCierreFI Is Nothing Then
            '--------------------------------------------------------
            'JNAVA (16.04.2019): ConnectionString de BD DatosEcomm
            '--------------------------------------------------------
            m_strConnectionStringEcomm = "Data Source=" & oParent.ConfigCierreFI.ServerDatosEcomm & "; Initial Catalog=" & _
                                        oParent.ConfigCierreFI.BaseDatosDatosEcomm & "; User Id=" & _
                                        oParent.ConfigCierreFI.UserDatosEcomm & " ;Password=" & _
                                        oParent.ConfigCierreFI.PasswordDatosEcomm & ";TimeOut=120;"

        End If
    End Sub

#End Region


#Region "Methods"

    Public Sub Insert(ByVal pFormaPago As FormaPago)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CatalogoFormasPagoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 1, "CodFormasPago"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.VarChar, 1, "CodTipoVenta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 30, "Descripcion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodFormasPago").Value = pFormaPago.ID.ToUpper
                .Parameters("@CodTipoVenta").Value = pFormaPago.VentaID.ToUpper
                .Parameters("@Descripcion").Value = pFormaPago.Descripcion.ToUpper

                .Parameters("@Usuario").Value = pFormaPago.Usuario.ToUpper
                .Parameters("@Fecha").Value = pFormaPago.Fecha
                .Parameters("@StatusRegistro").Value = pFormaPago.Status

                'Execute Command
                .ExecuteNonQuery()


                'Assign Other Values
                'pCaja.SetRecordCreatedBy("ASM")
                'pcaja.SetRecordCreatedOn(.Parameters("@Fecha").Value)
            End With

            'Reset New State of Linea Object 
            pFormaPago.ResetFlagNew()
            pFormaPago.ResetFlagDirty()

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



    Public Sub Update(ByVal pFormaPago As FormaPago)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[CatalogoFormasPagoUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 1, "CodFormasPago"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.VarChar, 1, "CodTipoVenta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 30, "Descripcion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@CodFormasPago").Value = pFormaPago.ID.ToUpper
                .Parameters("@CodTipoVenta").Value = pFormaPago.VentaID.ToUpper()
                .Parameters("@Descripcion").Value = pFormaPago.Descripcion.ToUpper
                .Parameters("@Usuario").Value = pFormaPago.Usuario.ToUpper
                .Parameters("@StatusRegistro").Value = pFormaPago.Status

                .Parameters("@Fecha").Value = pFormaPago.Fecha

                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values
                'Linea.SetRecordCreatedBy("KLO")
                'Linea.SetRecordCreatedOn(.Parameters("@Fecha").Value)

            End With

            'Reset New State of Linea Object 
            'Linea.ResetStateNew()
            pFormaPago.ResetFlagDirty()

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub



    Public Sub Delete(ByVal ID As String, ByVal VentaID As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[CatalogoFormasPagoDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 1, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CodFormasPago", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.VarChar, 1, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CodTipoVenta", System.Data.DataRowVersion.Original, Nothing))
        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@CodFormasPago").Value = ID
                .Parameters("@CodTipoVenta").Value = VentaID

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

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub



    Public Function SelectByID(ByVal ID As String, ByVal VentaID As String, ByVal Flag As String) As FormaPago

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oFormaPago As FormaPago

        oFormaPago = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect


            '.CommandText = "[CatalogoFormasPagoSel]"
            '.CommandType = System.Data.CommandType.StoredProcedure
            '.Connection = Me.SqlConnection1
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 2))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.VarChar, 2))


            .Connection = sccnnConnection

            .CommandText = "[CatalogoFormasPagoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.VarChar, 2))
        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodFormasPago").Value = ID
                .Parameters("@CodTipoVenta").Value = VentaID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oFormaPago.ID = .GetString(0).ToUpper
                        oFormaPago.VentaID = .GetString(1).ToUpper
                        oFormaPago.Descripcion = .GetString(2).ToUpper
                        'oCaja.Fecha = .GetDateTime(2)
                        'oCaja.Usuario = .GetString(3)
                        'oCaja.Status = .GetBoolean(4)


                        'Reset New State of Linea Object 
                        oFormaPago.ResetFlagNew()
                        oFormaPago.ResetFlagDirty()

                    End With

                Else
                    oFormaPago = Nothing
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

        If (oFormaPago Is Nothing) And Flag = "" Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de línea no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oFormaPago

    End Function

    Public Function SelectNumTarjetaDia(ByVal NumTarjeta As String) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        'Dim scdrReader As SqlDataReader
        Dim bolRes As Boolean

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoFormasPagoSelTarjetaHoy]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumTarjeta", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New SqlParameter("@Usada", SqlDbType.Bit, 1, "FueUsada"))
            .Parameters("@Usada").Direction = ParameterDirection.Output

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@NumTarjeta").Value = NumTarjeta

                'Execute Command
                .ExecuteNonQuery()

                bolRes = .Parameters("@Usada").Value

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

        Return bolRes

    End Function


    Public Function SelectAll(ByVal TipoVentaID As String, ByVal bExcluir As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFormasPago As SqlDataAdapter
        Dim dsFormasPago As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFormasPago = New SqlDataAdapter
        dsFormasPago = New DataSet("CatalogoFormasPago")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoFormasPagoTipoVentaSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Excluir", System.Data.SqlDbType.Bit, 1))

        End With

        scdaFormasPago.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaFormasPago.SelectCommand.Parameters("@CodTipoVenta").Value = TipoVentaID
            scdaFormasPago.SelectCommand.Parameters("@Excluir").Value = bExcluir

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
    'Public Function SelectAll(ByVal VentaID As String) As DataSet

    '    Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
    '                                             GetConnectionString)

    '    Dim sccmdSelectAll As SqlCommand
    '    Dim scdaFormasPago As SqlDataAdapter
    '    Dim dsFormasPago As DataSet

    '    sccmdSelectAll = New SqlCommand
    '    scdaFormasPago = New SqlDataAdapter
    '    dsFormasPago = New DataSet("CatalogoFormasPago")

    '    With sccmdSelectAll

    '        .Connection = sccnnConnection

    '        .CommandText = "[CatalogoFormasPagoSelAll]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

    '    End With

    '    scdaFormasPago.SelectCommand = sccmdSelectAll

    '    Try

    '        sccnnConnection.Open()

    '        scdaFormasPago.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

    '        'Fill DataSet
    '        scdaFormasPago.Fill(dsFormasPago, "CatalogoFormasPago")

    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

    '    End Try

    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing

    '    Return dsFormasPago

    'End Function

#End Region

#Region "Friend Funtion"
    Friend Function LoadAllFormasPago(ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoFormasPagoSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
            '.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
            .Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

        End With

        Dim oFormasPagoAdapter As SqlDataAdapter
        oFormasPagoAdapter = New SqlDataAdapter
        oFormasPagoAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFormasPagoAdapter.Fill(oResult, "CatalogoFormasPago")

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
#End Region

#Region "Venta Asistida"
    Public Function GetTiposPagosEcommerce() As DataTable
        Dim dtPagosEcommerce As New DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetTiposPagosEcommerce", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtPagosEcommerce)
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
        Return dtPagosEcommerce
    End Function
#End Region

#Region "Carga de Tipo de Pago Ecomm"
    Public Function GetTiposPagosEcommerceByAlmacen() As DataTable
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringEcomm)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("GetTiposPagos")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[GetTiposPagosEcommByAlmacen]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 4, "Almacen"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            sccmdSelectAll.Parameters("@Almacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "TiposPagos")

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

    Public Function GetFormasPagosEcommerceByAlmacen() As DataTable
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringEcomm)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("GetFormasPagos")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[GetFormasPagosEcommByAlmacen]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 4, "Almacen"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            sccmdSelectAll.Parameters("@Almacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "FormasPagos")

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
#End Region

#Region "Carga de número de tienda de Tipo de Pago Ecomm por id"
    Public Function GetNumTiendaTiposPagosEcommById(ByVal id As Integer) As String
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringEcomm)

        Dim sccmdSelect As SqlCommand = New SqlCommand
        Dim scdrReader As SqlDataReader
        Dim NumTienda As String = ""


        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[GetNumTiendaTiposPagosEcommById]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id"))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Id").Value = id

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        NumTienda = .GetString(0)

                    End With

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

        Return NumTienda
    End Function

    Public Function GetNotaTicketTiposPagosEcommById(ByVal id As Integer) As String
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringEcomm)

        Dim sccmdSelect As SqlCommand = New SqlCommand
        Dim scdrReader As SqlDataReader
        Dim Notaticket As String = ""


        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[GetNotaTicketTiposPagosEcommById]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id"))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Id").Value = id

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        Notaticket = .GetString(0)

                    End With

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

        Return Notaticket
    End Function

    Public Function GetMontoTotalPagoEcommerceByDate(ByVal fecha As DateTime) As Decimal
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand = New SqlCommand
        Dim scdrReader As SqlDataReader
        Dim monto As Decimal = 0


        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[GetTotalFormasPagoEcommerce]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FormaPago", System.Data.SqlDbType.Int))
        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@FechaInicial").Value = Format(fecha, "Short Date")
                .Parameters("@FechaFinal").Value = Format(fecha, "Short Date")
                .Parameters("@FormaPago").Value = 3

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        monto = .GetDecimal(0)

                    End With

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

        Return monto
    End Function
#End Region
#Region "Carga de configuración ecommerce"
    Public Function GetConfigEcommerce() As ConfigEcomm
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringEcomm)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oDPValeF As ConfigEcomm

        oDPValeF = oParent.CreateConfig()

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[GetConfigEcomm]"
            .CommandType = CommandType.StoredProcedure

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        oDPValeF.ID = .GetInt32(0)
                        oDPValeF.Plataforma = .GetString(1)
                        oDPValeF.Tienda = .GetString(2)
                        oDPValeF.Nombre = .GetString(3)
                        oDPValeF.CalleNum = .GetString(4)
                        oDPValeF.Colonia = .GetString(5)
                        oDPValeF.CP = .GetString(6)
                        oDPValeF.Telefono = .GetString(7)
                        oDPValeF.Ciudad = .GetString(8)
                        oDPValeF.Estado = .GetString(9)
                        'oDPValeF.Dias = .GetInt32(10)
                        oDPValeF.EstatusP = .GetString(11)
                        oDPValeF.EstatusC = .GetString(12)
                        oDPValeF.Correo = .GetString(13)
                    End With

                Else

                    oDPValeF = Nothing

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

        Return oDPValeF
    End Function

    Public Function GetDetallePagosEcommerceByDate(ByVal fecha As DateTime) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringEcomm)
        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("PagosEcomm")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[GetDetallePagosEcommerceByDate]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@Fecha").Value = Format(fecha, "Short Date")

            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "PagosEcomm")

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
#End Region

End Class
