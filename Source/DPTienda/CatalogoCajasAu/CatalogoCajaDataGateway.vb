
Option Explicit On 

Imports System.Data.SqlClient


Public Class CatalogoCajaDataGateway

    Private oParent As CatalogoCajaManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoCajaManager)

        oParent = Parent

    End Sub

#End Region



#Region "Methods"

    Public Sub Insert(ByVal pCaja As Caja)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCajasIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2, "CodCaja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 30, "Descripcion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4, "FolioFactura"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Int, 4, "FolioApartado"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioNotaCredito", System.Data.SqlDbType.Int, 4, "FolioNotaCredito"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAbono", System.Data.SqlDbType.Int, 4, "FolioAbono"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))



        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodCaja").Value = pCaja.ID.ToUpper
                .Parameters("@Descripcion").Value = pCaja.Descripcion.ToUpper
                .Parameters("@FolioFactura").Value = pCaja.FolioFactura
                .Parameters("@FolioApartado").Value = pCaja.FolioApartado
                .Parameters("@FolioNotaCredito").Value = pCaja.FolioNotaCredito
                .Parameters("@FolioAbono").Value = pCaja.FolioAbono
                .Parameters("@Usuario").Value = pCaja.Usuario.ToUpper
                .Parameters("@Fecha").Value = pCaja.Fecha
                .Parameters("@StatusRegistro").Value = pCaja.Status

                'Execute Command
                .ExecuteNonQuery()


                'Assign Other Values
                'pCaja.SetRecordCreatedBy("ASM")
                'pcaja.SetRecordCreatedOn(.Parameters("@Fecha").Value)
            End With

            'Reset New State of Linea Object 
            pCaja.ResetFlagNew()
            pCaja.ResetFlagDirty()

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



    Public Sub Update(ByVal pCaja As Caja)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCajasUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2, "CodCaja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 30, "Descripcion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4, "FolioFactura"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Int, 4, "FolioApartado"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioNotaCredito", System.Data.SqlDbType.Int, 4, "FolioNotaCredito"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAbono", System.Data.SqlDbType.Int, 4, "FolioAbono"))
           




        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@CodCaja").Value = pCaja.ID.ToUpper
                .Parameters("@Descripcion").Value = pCaja.Descripcion.ToUpper
                .Parameters("@FolioFactura").Value = pCaja.FolioFactura
                .Parameters("@FolioApartado").Value = pCaja.FolioApartado
                .Parameters("@FolioNotaCredito").Value = pCaja.FolioNotaCredito
                .Parameters("@FolioAbono").Value = pCaja.FolioAbono
                .Parameters("@Usuario").Value = pCaja.Usuario.ToUpper
                .Parameters("@StatusRegistro").Value = pCaja.Status

                .Parameters("@Fecha").Value = pCaja.Fecha

                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values
                'Linea.SetRecordCreatedBy("KLO")
                'Linea.SetRecordCreatedOn(.Parameters("@Fecha").Value)

            End With

            'Reset New State of Linea Object 
            'Linea.ResetStateNew()
            pCaja.ResetFlagDirty()

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



    Public Sub Delete(ByVal ID As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[CatalogoCajasDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CodCaja", System.Data.DataRowVersion.Original, Nothing))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@CodCaja").Value = ID

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


    Public Sub UpdateIP(ByVal ID As String, ByVal IP As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[CatalogoCajasUpdIP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CodCaja", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IP", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IP", System.Data.DataRowVersion.Original, Nothing))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@CodCaja").Value = ID
                .Parameters("@IP").Value = IP

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


        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    
    Public Function SelectByID(ByVal ID As String) As Caja

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oCaja As Caja

        oCaja = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCajasSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodCaja").Value = ID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oCaja.ID = .GetString(0).ToUpper
                        oCaja.Descripcion = .GetString(1).ToUpper
                        oCaja.FolioFactura = .GetInt32(2)
                        oCaja.FolioApartado = .GetInt32(3)
                        oCaja.FolioNotaCredito = .GetInt32(4)
                        oCaja.FolioAbono = .GetInt32(5)
                        'oCaja.Fecha = .GetDateTime(2)
                        'oCaja.Usuario = .GetString(3)
                        'oCaja.Status = .GetBoolean(4)
                        oCaja.IP = .GetString(9).ToUpper


                        'Reset New State of Linea Object 
                        oCaja.ResetFlagNew()
                        oCaja.ResetFlagDirty()

                    End With

                Else
                    oCaja = Nothing
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

        If (oCaja Is Nothing) Then
            'Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de línea no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oCaja

    End Function



    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaCaja As SqlDataAdapter
        Dim dsCaja As DataSet

        sccmdSelectAll = New SqlCommand
        scdaCaja = New SqlDataAdapter
        dsCaja = New DataSet("CatalogoCajas")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCajasSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        End With

        scdaCaja.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaCaja.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            'Fill DataSet
            scdaCaja.Fill(dsCaja, "CatalogoCajas")

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

        Return dsCaja

    End Function

#End Region

End Class
