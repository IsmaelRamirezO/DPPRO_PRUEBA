
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.Core


Public Class HistoricoApartadosDataGateway

    Private oApplicationContext As ApplicationContext


#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#End Region



#Region "Pubic Methods"

    Public Sub TotalExistenciasApartados(ByVal strCodArticulo As String, ByRef IntTotalExistencias As Integer, _
                                         ByRef intTotalApartados As Integer)

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[HistoricoApartadosReportTotalExistenciasApartados]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalExistencias", System.Data.SqlDbType.Int))
            .Parameters("@TotalExistencias").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalApartados", System.Data.SqlDbType.Int))
            .Parameters("@TotalApartados").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = strCodArticulo

                'OutPut :
                .Parameters("@TotalExistencias").Value = 0
                .Parameters("@TotalApartados").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        IntTotalExistencias = .GetInt32(0)

                        intTotalApartados = .GetInt32(1)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

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

    End Sub


    Public Function HistoricoApartadosDetalleSel(ByVal strCodArticulo As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAdapter As SqlDataAdapter
        Dim dsDataset As DataSet

        sccmdSelectAll = New SqlCommand
        scdaAdapter = New SqlDataAdapter
        dsDataset = New DataSet("CatalogoCajas")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[HistoricoApartadosDetalleSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))

        End With

        scdaAdapter.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaAdapter.SelectCommand.Parameters("@CodArticulo").Value = strCodArticulo

            'Fill DataSet
            scdaAdapter.Fill(dsDataset, "Apartados")

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

        Return dsDataset.Tables("Apartados")

    End Function


    Public Function TotalArticulos(ByVal strCodArticulo As String) As Integer

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                        GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intTotalArticulos As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[HistoricoApartadosReportTotalArticulos]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalArticulos", System.Data.SqlDbType.Int))
            .Parameters("@TotalArticulos").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = strCodArticulo

                'OutPut :
                .Parameters("@TotalArticulos").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        intTotalArticulos = .GetInt32(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

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

        Return intTotalArticulos

    End Function

#End Region

End Class
