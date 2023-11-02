
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.Core


Public Class TodosArticulosDataGateway

    Private oApplicationContext As ApplicationContext


#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#End Region



#Region "Pubic Methods"

    Public Function TodosArticulosDetalleSel(ByVal datFechaInicio As Date, ByVal datFechaFin As Date) As DataTable

        Dim drRow As DataRow

        '1.- Extraer Articulos Con Movimientos.

        Dim dtArticulosMovimientos As DataTable = ArticulosMovimientosSel(datFechaInicio, datFechaFin)

        '2.- Extraer Existencia por Cada Artículo.
        For Each drRow In dtArticulosMovimientos.Rows

            drRow!Existencia = ExistenciaPorArticulo(CType(drRow!Codigo, String))

        Next


        Return dtArticulosMovimientos

    End Function


    Private Function ArticulosMovimientosSel(ByVal datFechaInicio As Date, ByVal datFechaFin As Date) _
                     As DataTable

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaCaja As SqlDataAdapter
        Dim dsCaja As DataSet

        sccmdSelectAll = New SqlCommand
        scdaCaja = New SqlDataAdapter
        dsCaja = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TodosArticulosReportSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicio", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))

            'Asignar Valores :
            '.Parameters("@FechaInicio").Value = DateAdd(DateInterval.Day, -1, datFechaInicio)
            '.Parameters("@FechaFin").Value = DateAdd(DateInterval.Day, 1, Date.Now)
            .Parameters("@FechaInicio").Value = Format(datFechaInicio, "Short Date")
            .Parameters("@FechaFin").Value = Format(datFechaFin, "Short Date")

        End With

        scdaCaja.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaCaja.Fill(dsCaja, "Movimientos")

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

        Return dsCaja.Tables("Movimientos")

    End Function


    Public Function ExistenciaPorArticulo(ByVal strCodArticulo As String) As Integer

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intExistenciaArticulo As Integer

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[TodosArticulosReportExistenciaporArticulo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalExistencia", System.Data.SqlDbType.Int))
            .Parameters("@TotalExistencia").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@CodAlmacen").Value = oApplicationContext.ApplicationConfiguration.Almacen


                'OutPut :
                .Parameters("@TotalExistencia").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        intExistenciaArticulo = .GetInt32(0)

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


        Return intExistenciaArticulo

    End Function

#End Region

End Class
