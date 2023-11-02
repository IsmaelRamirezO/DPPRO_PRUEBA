Imports System.Data.SqlClient

Public Class CatalogoPromocionesDataGateway

    Private oParent As CatalogoPromocionesManager
    Private m_strConnectionStringServer As String

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoPromocionesManager)

        oParent = Parent

        m_strConnectionStringServer = "data source = " & oParent.ConfigCierreFI.ServerEhub & "; initial catalog = " & _
                                      oParent.ConfigCierreFI.BaseDatosEhub & "; user id = " & Parent.ConfigCierreFI.UserEhub & "; password = " & _
                                      oParent.ConfigCierreFI.PassEhub()
    End Sub

#End Region


#Region "Methods"

    Public Sub InsertPromocion(ByVal oPromo As Promocion)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[PromocionesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.SmallInt, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 40))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Promocion", System.Data.SqlDbType.SmallInt, 2))
            .Parameters.Add(New SqlParameter("@Abrev", SqlDbType.VarChar, 15))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@ID").Value = oPromo.ID
                .Parameters("@Descripcion").Value = oPromo.Descripcion
                .Parameters("@Promocion").Value = oPromo.Promocion
                .Parameters("@Abrev").Value = oPromo.AbrevPromo

                'Execute Command
                .ExecuteNonQuery()

            End With

            'Reset New State of Linea Object 
            oPromo.ResetFlagNew()
            oPromo.ResetFlagDirty()

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

    Public Sub InsertEmisor(ByVal oEmisor As Emisor)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[EmisoresIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.SmallInt, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 70))
            .Parameters.Add(New SqlParameter("@Abrev", SqlDbType.VarChar, 20))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@ID").Value = oEmisor.ID
                .Parameters("@Descripcion").Value = oEmisor.Descripcion
                .Parameters("@Abrev").Value = oEmisor.Abrevacion

                'Execute Command
                .ExecuteNonQuery()

            End With

            'Reset New State of Linea Object 
            oEmisor.ResetFlagNew()
            oEmisor.ResetFlagDirty()

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

    Public Sub InsertAfiliacion(ByVal oAfil As Afiliacion)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[AfiliacionesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDEmisor", System.Data.SqlDbType.SmallInt, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDPromo", System.Data.SqlDbType.SmallInt, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NoAfil", System.Data.SqlDbType.Decimal, 9))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@IDEmisor").Value = oAfil.IDEmisor
                .Parameters("@IDPromo").Value = oAfil.IDPromo
                .Parameters("@NoAfil").Value = oAfil.NoAfiliacion

                'Execute Command
                .ExecuteNonQuery()

            End With

            'Reset New State of Linea Object 
            oAfil.ResetFlagNew()
            oAfil.ResetFlagDirty()

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

    Public Sub InsertPromoBin(ByVal oPromoBin As PromoBin)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[PromoBinIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bin", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDPromo", System.Data.SqlDbType.SmallInt, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ImpMin", System.Data.SqlDbType.Decimal, 9))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ImpMax", System.Data.SqlDbType.Decimal, 9))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Bin").Value = oPromoBin.Bin
                .Parameters("@IDPromo").Value = oPromoBin.IDPromo
                .Parameters("@ImpMin").Value = oPromoBin.ImporteMinimo
                .Parameters("@ImpMax").Value = oPromoBin.ImporteMaximo

                'Execute Command
                .ExecuteNonQuery()

            End With

            'Reset New State of Linea Object 
            oPromoBin.ResetFlagNew()
            oPromoBin.ResetFlagDirty()

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

    'Public Sub Update(ByVal oPromo As Promocion)

    '    Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
    '                                             DataStorageConfiguration.GetConnectionString)

    '    Dim sccmdUpdate As SqlCommand
    '    sccmdUpdate = New SqlCommand

    '    With sccmdUpdate

    '        .Connection = sccnnConnection

    '        .CommandText = "[CatalogoPromocionesUpd]"
    '        .CommandType = System.Data.CommandType.StoredProcedure


    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 100))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Promocion", System.Data.SqlDbType.Int, 4))

    '    End With

    '    Try

    '        sccnnConnection.Open()

    '        With sccmdUpdate
    '            'Assign Parameters Values
    '            .Parameters("@ID").Value = oPromo.ID
    '            .Parameters("@Descripcion").Value = oPromo.Descripcion
    '            .Parameters("@Promocion").Value = oPromo.Promocion

    '            'Execute Command
    '            .ExecuteNonQuery()

    '        End With

    '        'Reset New State of Linea Object 
    '        'Linea.ResetStateNew()
    '        oPromo.ResetFlagDirty()

    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

    '    End Try

    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing

    'End Sub

    'Public Sub Delete(ByVal ID As Integer)

    '    Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
    '                                             DataStorageConfiguration.GetConnectionString)

    '    Dim sccmdDelete As SqlCommand
    '    sccmdDelete = New SqlCommand

    '    With sccmdDelete

    '        .Connection = sccnnConnection
    '        .CommandText = "[CatalogoPromocionesDel]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CodBanco", System.Data.DataRowVersion.Original, Nothing))

    '    End With

    '    Try

    '        sccnnConnection.Open()

    '        With sccmdDelete
    '            'Assign Parameters Values
    '            .Parameters("@ID").Value = ID

    '            'Execute Command
    '            .ExecuteNonQuery()

    '        End With

    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser eliminado debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser eliminado debido a un error de aplicación.", ex)

    '    End Try


    '    sccmdDelete.Dispose()
    '    sccmdDelete = Nothing

    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing

    'End Sub

    Public Sub DeleteAllPromociones()

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[PromocionesDelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values

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

            Throw New ApplicationException("Los registros no pudieron ser eliminados debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser eliminados debido a un error de aplicación.", ex)

        End Try


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub DeleteAllEmisores()

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[EmisoresDelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values

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

            Throw New ApplicationException("Los registros no pudieron ser eliminados debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser eliminados debido a un error de aplicación.", ex)

        End Try


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    'Public Sub DeleteAllUN()

    '    Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
    '                                             DataStorageConfiguration.GetConnectionString)

    '    Dim sccmdDelete As SqlCommand
    '    sccmdDelete = New SqlCommand

    '    With sccmdDelete

    '        .Connection = sccnnConnection
    '        .CommandText = "[UNDelAll]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '    End With

    '    Try

    '        sccnnConnection.Open()

    '        With sccmdDelete
    '            'Assign Parameters Values

    '            'Execute Command
    '            .ExecuteNonQuery()

    '        End With

    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("Los registros no pudieron ser eliminados debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("Los registros no pudieron ser eliminados debido a un error de aplicación.", ex)

    '    End Try


    '    sccmdDelete.Dispose()
    '    sccmdDelete = Nothing

    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing

    'End Sub

    Public Sub DeleteAllAfiliaciones()

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[AfiliacionesDelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values

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

            Throw New ApplicationException("Los registros no pudieron ser eliminados debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser eliminados debido a un error de aplicación.", ex)

        End Try


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub DeleteAllPromoBin()

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[PromoBinDelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values

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

            Throw New ApplicationException("Los registros no pudieron ser eliminados debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser eliminados debido a un error de aplicación.", ex)

        End Try


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    'Public Function SelectByID(ByVal ID As Integer) As Promocion

    '    Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
    '                                             GetConnectionString)

    '    Dim sccmdSelect As SqlCommand
    '    Dim scdrReader As SqlDataReader
    '    Dim oPromo As Promocion

    '    oPromo = oParent.Create

    '    sccmdSelect = New SqlCommand

    '    With sccmdSelect

    '        .Connection = sccnnConnection

    '        .CommandText = "[CatalogoPromocionesSel]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4))

    '    End With

    '    Try

    '        sccnnConnection.Open()

    '        With sccmdSelect
    '            'Assign Parameters Values
    '            .Parameters("@ID").Value = ID

    '            'Execute Command
    '            scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

    '            'Assign Other Values
    '            scdrReader.Read()

    '            If (scdrReader.HasRows) Then

    '                With scdrReader

    '                    oPromo.ID = .GetInt32(0)
    '                    oPromo.Promocion = .GetInt32(1)
    '                    oPromo.Descripcion = .GetString(2).ToUpper

    '                    'Reset New State of Linea Object 
    '                    oPromo.ResetFlagNew()
    '                    oPromo.ResetFlagDirty()

    '                End With

    '            Else
    '                oPromo = Nothing
    '            End If

    '            scdrReader.Close()
    '        End With

    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

    '    End Try

    '    If (oPromo Is Nothing) Then
    '        Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de la Promoción no existe.")
    '    End If

    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing

    '    Return oPromo

    'End Function

    'Public Function SelectAll() As DataSet

    '    Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
    '                                             GetConnectionString)

    '    Dim sccmdSelectAll As SqlCommand
    '    Dim scdaPromo As SqlDataAdapter
    '    Dim dsPromo As DataSet

    '    sccmdSelectAll = New SqlCommand
    '    scdaPromo = New SqlDataAdapter
    '    dsPromo = New DataSet("CatalogoPromociones")

    '    With sccmdSelectAll

    '        .Connection = sccnnConnection

    '        .CommandText = "[CatalogoPromocionesSelAll]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

    '    End With

    '    scdaPromo.SelectCommand = sccmdSelectAll

    '    Try

    '        sccnnConnection.Open()

    '        'Fill DataSet
    '        scdaPromo.Fill(dsPromo, "CatalogoPromociones")

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

    '    Return dsPromo

    'End Function

    Public Function SelectAllPromocionesFromServer() As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringServer)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPromo As SqlDataAdapter
        Dim dsPromo As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPromo = New SqlDataAdapter
        dsPromo = New DataSet("Promociones")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[PromocionesSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        scdaPromo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaPromo.Fill(dsPromo, "Promociones")

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

    Public Function SelectAllPromoBinFromServer() As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringServer)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPromo As SqlDataAdapter
        Dim dsPromo As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPromo = New SqlDataAdapter
        dsPromo = New DataSet("Promociones")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[PromoBinSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        scdaPromo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaPromo.Fill(dsPromo, "Promociones")

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

    Public Function SelectAllEmisoresFromServer() As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringServer)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPromo As SqlDataAdapter
        Dim dsPromo As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPromo = New SqlDataAdapter
        dsPromo = New DataSet("Emisores")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[EmisoresSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        scdaPromo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaPromo.Fill(dsPromo, "Emisores")

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

    'Public Function SelectAllUNFromServer() As DataTable

    '    Dim sccnnConnection As New SqlConnection(m_strConnectionStringServer)

    '    Dim sccmdSelectAll As SqlCommand
    '    Dim scdaPromo As SqlDataAdapter
    '    Dim dsPromo As DataSet

    '    sccmdSelectAll = New SqlCommand
    '    scdaPromo = New SqlDataAdapter
    '    dsPromo = New DataSet("UnidadesNegocio")

    '    With sccmdSelectAll

    '        .Connection = sccnnConnection

    '        .CommandText = "[UNSelAll]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '    End With

    '    scdaPromo.SelectCommand = sccmdSelectAll

    '    Try

    '        sccnnConnection.Open()

    '        'Fill DataSet
    '        scdaPromo.Fill(dsPromo, "UnidadesNegocio")

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

    '    Return dsPromo.Tables(0)

    'End Function

    Public Function SelectAllAfiliacionesFromServer() As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringServer)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPromo As SqlDataAdapter
        Dim dsPromo As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPromo = New SqlDataAdapter
        dsPromo = New DataSet("Afiliaciones")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AfiliacionesSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.SmallInt, 2))

            .Parameters("@CodAlmacen").Value = CInt(oParent.ApplicationContext.ApplicationConfiguration.Almacen)

        End With

        scdaPromo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaPromo.Fill(dsPromo, "Afiliaciones")

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

    Public Function SelectAllByBin(ByVal bin As Integer, ByVal importe As Decimal) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPromo As SqlDataAdapter
        Dim dsPromo As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPromo = New SqlDataAdapter
        dsPromo = New DataSet("BancoPromocion")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoPromocionesSelByBin]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bin", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New SqlParameter("@Importe", SqlDbType.Decimal, 9))

            .Parameters("@Bin").Value = bin
            .Parameters("@Importe").Value = importe

        End With

        scdaPromo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaPromo.Fill(dsPromo, "BancoPromocion")

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

End Class
