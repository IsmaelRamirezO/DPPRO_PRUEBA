Imports System
Imports System.Data
Imports System.Data.SqlClient

Friend Class CatalogoCiudadesDataGateway

    Private oParent As CatalogoCiudadesManager
    Private m_strConnectionString As String

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoCiudadesManager)

        oParent = Parent
        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    End Sub

#End Region

#Region "Methods"

    Public Sub Insert(ByVal Ciudad As Ciudad)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCiudadesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCiudad", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodEstado", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPlaza", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RANGO1", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RANGO2", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RANGO3", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RANGO4", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert
                .Parameters("@CodCiudad").Value = Ciudad.CodCiudad
                .Parameters("@CodEstado").Value = Ciudad.CodEstado
                .Parameters("@Ciudad").Value = Ciudad.Ciudad
                .Parameters("@CodPlaza").Value = Ciudad.CodPlaza
                .Parameters("@RANGO1").Value = Ciudad.Rango1
                .Parameters("@RANGO2").Value = Ciudad.Rango2
                .Parameters("@RANGO3").Value = Ciudad.Rango3
                .Parameters("@RANGO4").Value = Ciudad.Rango4
                .Parameters("@Usuario").Value = Ciudad.Usuario
                .Parameters("@Fecha").Value = Ciudad.Fecha
                .Parameters("@StatusRegistro").Value = Ciudad.StatusRegistro

                .ExecuteNonQuery()

                Ciudad.SetUsuario("ASM")
                Ciudad.SetFecha(.Parameters("@Fecha").Value)

            End With

            Ciudad.ResetStateNew()
            Ciudad.ResetStateDirty()

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

    Public Sub Update(ByVal Ciudad As Ciudad)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCiudadesUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCiudad", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodEstado", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPlaza", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RANGO1", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RANGO2", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RANGO3", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RANGO4", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

        End With

        Try
            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@CodCiudad").Value = Ciudad.CodCiudad
                .Parameters("@CodEstado").Value = Ciudad.CodEstado
                .Parameters("@Ciudad").Value = Ciudad.Ciudad
                .Parameters("@CodPlaza").Value = Ciudad.CodPlaza
                .Parameters("@RANGO1").Value = Ciudad.Rango1
                .Parameters("@RANGO2").Value = Ciudad.Rango2
                .Parameters("@RANGO3").Value = Ciudad.Rango3
                .Parameters("@RANGO4").Value = Ciudad.Rango4
                .Parameters("@Usuario").Value = "KLO"
                .Parameters("@StatusRegistro").Value = Ciudad.StatusRegistro

                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values
                Ciudad.SetUsuario("KLO")
                Ciudad.SetFecha(.Parameters("@Fecha").Value)

            End With

            'Reset New State of Ciudad Object 
            Ciudad.ResetStateDirty()

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

    Public Sub Delete(ByVal ID As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCiudadesDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCiudad", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@CodCiudad").Value = ID

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

    Public Function [Select](ByVal ID As Integer, Optional ByVal Ciudad As Ciudad = Nothing) As Ciudad

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oCiudad As Ciudad

        If (Ciudad Is Nothing) Then

            oCiudad = oParent.Create

        Else

            oCiudad = Ciudad
            oCiudad.Clear()

        End If

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCiudadesSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCiudad", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodCiudad").Value = ID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oCiudad.CodCiudad = .GetInt32(0)
                        oCiudad.CodEstado = .GetInt32(1)
                        oCiudad.Ciudad = .GetString(2)
                        oCiudad.CodPlaza = .GetString(3)
                        'oCiudad.Rango1 = .GetString(4)
                        'oCiudad.Rango2 = .GetString(5)
                        'oCiudad.Rango3 = .GetString(6)
                        'oCiudad.Rango4 = .GetString(7)
                        oCiudad.SetUsuario(.GetString(8))
                        oCiudad.SetFecha(.GetDateTime(9))
                        oCiudad.StatusRegistro = .GetBoolean(10)

                        'Reset New State of Ciudad Object 
                        oCiudad.ResetStateNew()
                        oCiudad.ResetStateDirty()

                    End With

                Else
                    oCiudad = Nothing
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

        If (oCiudad Is Nothing) Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de la Ciudad no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oCiudad

    End Function

    Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaCiudades As SqlDataAdapter
        Dim dsCiudades As DataSet

        sccmdSelectAll = New SqlCommand
        scdaCiudades = New SqlDataAdapter
        dsCiudades = New DataSet("CatalogoCiudades")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCiudadesSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        End With

        scdaCiudades.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaCiudades.SelectCommand.Parameters("@OnlyEnabledRecords").Value = CType(EnabledRecordsOnly, Boolean)

            'Fill DataSet
            scdaCiudades.Fill(dsCiudades, "CatalogoCiudades")

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

        Return dsCiudades

    End Function

#End Region

End Class
