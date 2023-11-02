Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class CatalogoEstadosDataGateway

    Private oParent As CatalogoEstadosManager
    Private m_strConnectionString As String

#Region "Constructors"

    Public Sub New(ByVal Parent As CatalogoEstadosManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    End Sub

#End Region

#Region "Methods"

    Public Sub Insert(ByVal Estado As Estado)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CatalogoEstadosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodEstado", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Abrevia", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodEstado").Value = Estado.CodEstado
                .Parameters("@Descripcion").Value = Estado.Descripcion
                .Parameters("@Abrevia").Value = Estado.Abrevia
                .Parameters("@Usuario").Value = Estado.Usuario
                .Parameters("@Fecha").Value = Estado.Fecha
                .Parameters("@StatusRegistro").Value = Estado.StatusRegistro

                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values
                Estado.SetUsuario("ASM")
                Estado.SetFecha(.Parameters("@Fecha").Value)
            End With

            'Reset New State of Estado Object 
            Estado.ResetStateNew()
            Estado.ResetStateDirty()

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

    Public Sub Update(ByVal Estado As Estado)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[CatalogoEstadosUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodEstado", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Abrevia", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@CodEstado").Value = Estado.CodEstado
                .Parameters("@Descripcion").Value = Estado.Descripcion
                .Parameters("@Abrevia").Value = Estado.Abrevia
                .Parameters("@Usuario").Value = "KLO"
                .Parameters("@StatusRegistro").Value = Estado.StatusRegistro

                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values
                Estado.SetUsuario("KLO")
                Estado.SetFecha(.Parameters("@Fecha").Value)

            End With

            'Reset New State of Estado Object 
            Estado.ResetStateDirty()

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

            .CommandText = "[CatalogoEstadosDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodEstado", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@CodEstado").Value = ID

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

    Public Function [Select](ByVal ID As Integer, Optional ByVal Estado As Estado = Nothing) As Estado

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oEstado As Estado

        If (Estado Is Nothing) Then

            oEstado = oParent.Create

        Else

            oEstado = Estado
            oEstado.Clear()

        End If

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoEstadosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodEstado", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodEstado").Value = ID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oEstado.CodEstado = .GetInt32(0)
                        oEstado.Descripcion = .GetString(1)
                        oEstado.Abrevia = .GetString(2)
                        oEstado.SetUsuario(.GetString(3))
                        oEstado.SetFecha(.GetDateTime(4))
                        oEstado.StatusRegistro = .GetBoolean(5)

                        'Reset New State of Estado Object 
                        oEstado.ResetStateNew()
                        oEstado.ResetStateDirty()

                    End With

                Else
                    MsgBox("No existe el código de estado.", MsgBoxStyle.Information, "Catalogo Estados")
                    oEstado = Nothing
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

        If (oEstado Is Nothing) Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID del Estado no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oEstado

    End Function

    Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaEstados As SqlDataAdapter
        Dim dsEstados As DataSet

        sccmdSelectAll = New SqlCommand
        scdaEstados = New SqlDataAdapter
        dsEstados = New DataSet("CatalogoEstados")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoEstadosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        End With

        scdaEstados.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaEstados.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            'Fill DataSet
            scdaEstados.Fill(dsEstados, "CatalogoEstados")

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

        Return dsEstados

    End Function

#End Region

End Class
