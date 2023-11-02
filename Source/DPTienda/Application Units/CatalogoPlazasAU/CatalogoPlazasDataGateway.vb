Imports System
Imports System.Data
Imports System.Data.SqlClient

Friend Class CatalogoPlazasDataGateway

    Private oParent As CatalogoPlazasManager
    Private m_strConnectionString As String

#Region "Constructors"

    Public Sub New(ByVal Parent As CatalogoPlazasManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    End Sub

#End Region

#Region "Methods"

    Public Function [Select](ByVal ID As String, Optional ByVal Plaza As Plaza = Nothing) As Plaza

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oPlaza As Plaza

        If (Plaza Is Nothing) Then

            oPlaza = oParent.Create

        Else

            oPlaza = Plaza
            oPlaza.Clear()

        End If

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoPlazasSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPlaza", System.Data.SqlDbType.VarChar, 3))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodPlaza").Value = ID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oPlaza.CodPlaza = .GetString(0)
                        oPlaza.Descripcion = .GetString(1)
                        oPlaza.SetUsuario(.GetString(2))
                        oPlaza.SetFecha(.GetDateTime(3))
                        oPlaza.StatusRegistro = .GetBoolean(4)

                        'Reset New State of Plaza Object 
                        oPlaza.ResetStateNew()
                        oPlaza.ResetStateDirty()

                    End With

                Else
                    oPlaza = Nothing
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

        If (oPlaza Is Nothing) Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de la Plaza no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oPlaza

    End Function

    Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPlazas As SqlDataAdapter
        Dim dsPlazas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPlazas = New SqlDataAdapter
        dsPlazas = New DataSet("CatalogoPlazas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[CatalogoPlazasSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        End With

        scdaPlazas.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaPlazas.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            'Fill DataSet
            scdaPlazas.Fill(dsPlazas, "CatalogoPlazas")

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

        Return dsPlazas

    End Function

#End Region

End Class
