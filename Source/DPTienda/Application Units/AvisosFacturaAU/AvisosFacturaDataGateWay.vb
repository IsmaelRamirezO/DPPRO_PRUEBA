
Option Explicit On 

Imports System.Data.SqlClient


Public Class AvisosFacturaDataGateWay

    Private oParent As AvisosFacturaManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As AvisosFacturaManager)

        oParent = Parent

    End Sub

#End Region



#Region "Methods"

    Public Sub Insert(ByVal pAvisosFactura As AvisosFactura)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[AvisosFacturaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumNota", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nota", System.Data.SqlDbType.VarChar, 150))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Disponible", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))
        End With

        Try

            sccnnConnection.Open()

            
                With sccmdInsert
                    'Assign Parameters Values
                    .Parameters("@NumNota").Value = pAvisosFactura.ID.ToUpper
                    .Parameters("@Modulo").Value = pAvisosFactura.Modulo.ToUpper
                    .Parameters("@Nota").Value = pAvisosFactura.Nota.ToUpper
                    .Parameters("@Disponible").Value = pAvisosFactura.Disponible
                    .Parameters("@Usuario").Value = pAvisosFactura.Usuario.ToUpper
                    .Parameters("@Fecha").Value = pAvisosFactura.Fecha
                    .Parameters("@StatusRegistro").Value = pAvisosFactura.Status

                    'Execute Command
                    .ExecuteNonQuery()

            End With

            'Reset New State of Linea Object 
            pAvisosFactura.ResetFlagNew()
            pAvisosFactura.ResetFlagDirty()

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

    Public Function SelectByID(ByVal Modulo As String) As AvisosFactura

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oAvisosFactura As AvisosFactura

        oAvisosFactura = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[AvisosFacturaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 30))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@Modulo").Value = Modulo

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oAvisosFactura.ID = .GetInt32(0)

                        'Reset New State of Linea Object 
                        oAvisosFactura.ResetFlagNew()
                        oAvisosFactura.ResetFlagDirty()

                    End With

                    'Else
                    'oCaja = Nothing
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

        If (oAvisosFactura Is Nothing) Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de línea no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oAvisosFactura

    End Function


    Public Function SelectAll(ByVal Modulo As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAvisosFactura As SqlDataAdapter
        Dim dsAvisosFactura As DataSet

        sccmdSelectAll = New SqlCommand
        scdaAvisosFactura = New SqlDataAdapter
        dsAvisosFactura = New DataSet("AvisosFactura")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AvisosFacturaSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 30))

        End With

        scdaAvisosFactura.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaAvisosFactura.SelectCommand.Parameters("@Modulo").Value = Modulo

            'Fill DataSet
            scdaAvisosFactura.Fill(dsAvisosFactura, "AvisosFactura")

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

        Return dsAvisosFactura

    End Function

    Public Sub Delete(ByVal Modulo As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[AvisosFacturaDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 30))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@Modulo").Value = Modulo

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

    Public Function SelectEnabled(ByVal Modulo As String, ByVal Disponible As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAvisosFactura As SqlDataAdapter
        Dim dsAvisosFactura As DataSet

        sccmdSelectAll = New SqlCommand
        scdaAvisosFactura = New SqlDataAdapter
        dsAvisosFactura = New DataSet("AvisosFactura")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AvisosFacturaSelEnabled]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Disponible", System.Data.SqlDbType.Bit))
        End With

        scdaAvisosFactura.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaAvisosFactura.SelectCommand.Parameters("@Modulo").Value = Modulo
            scdaAvisosFactura.SelectCommand.Parameters("@Disponible").Value = Disponible

            'Fill DataSet
            scdaAvisosFactura.Fill(dsAvisosFactura, "AvisosFactura")

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

        Return dsAvisosFactura

    End Function

#End Region


End Class
