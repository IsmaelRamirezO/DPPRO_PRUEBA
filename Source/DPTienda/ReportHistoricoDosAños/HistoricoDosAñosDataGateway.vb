
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.Core


Public Class HistoricoDosAñosDataGateway

    Private oApplicationContext As ApplicationContext


#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#End Region



#Region "Pubic Methods"

    Public Sub TotalSaldos(ByVal strCodArticulo As String, ByRef IntSaldoInicial As Integer, _
                           ByRef intSaldoFinal As Integer)

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim datFechaDosAños As Date
        Dim datFechaUnAño As Date
        Dim intDosAños As Integer
        Dim intUnAño As Integer

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[HistoricoDosAñosSaldos]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDosAños", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaUnAño", System.Data.SqlDbType.Int))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoInicial", System.Data.SqlDbType.Int))
            .Parameters("@SaldoInicial").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoFinal", System.Data.SqlDbType.Int))
            .Parameters("@SaldoFinal").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@CodAlmacen").Value = oApplicationContext.ApplicationConfiguration.Almacen

                datFechaDosAños = DateAdd(DateInterval.Year, -2, Date.Now)
                .Parameters("@FechaDosAños").Value = DatePart(DateInterval.Year, datFechaDosAños)

                datFechaUnAño = DateAdd(DateInterval.Year, -1, Date.Now)
                .Parameters("@FechaUnAño").Value = DatePart(DateInterval.Year, datFechaUnAño)


                'OutPut :
                .Parameters("@SaldoInicial").Value = 0
                .Parameters("@SaldoFinal").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        IntSaldoInicial = .GetInt32(0)

                        intSaldoFinal = .GetInt32(1)

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


    Public Function HistoricoDosAñosDetalleSel(ByVal strCodArticulo As String) As DataTable

        Dim dtMovimientos As DataTable = MovimientosSel(strCodArticulo)
        Dim dtMovimientosHistoricos As DataTable = MovimientosHistoricoSel(strCodArticulo)

        Dim drRow As DataRow
        Dim drNewRow As DataRow


        '1.- Extraer Registros Movimientos y MovimientosHistorico.

        '2.- Unificar Tablas en dtMovimientos.

        'For Each drRow In dtMovimientosHistoricos.Rows

        '    drNewRow = Nothing

        '    drNewRow = dtMovimientos.NewRow

        '    With drNewRow
        '        !Origen = drRow!Origen
        '        !Referencia = drRow!Referencia
        '        !Fecha = drRow!Fecha
        '        !Descripcion = drRow!Descripcion
        '        !Entrada = drRow!Entrada
        '        !Salida = drRow!Salida
        '        !Saldo = drRow!Saldo
        '    End With

        '    dtMovimientos.Rows.Add(drNewRow)

        'Next

        'dtMovimientos.DefaultView.Sort = "Fecha"

        'If (dtMovimientos.Rows.Count = 0) Then
        '    GoTo SaltoLinea
        'End If


        For Each drRow In dtMovimientos.Rows

            drNewRow = Nothing

            drNewRow = dtMovimientosHistoricos.NewRow

            With drNewRow
                !Origen = drRow!Origen
                !Referencia = drRow!Referencia
                !Fecha = drRow!Fecha
                !Descripcion = drRow!Descripcion
                !Entrada = drRow!Entrada
                !Salida = drRow!Salida
                !Saldo = drRow!Saldo
            End With

            dtMovimientosHistoricos.Rows.Add(drNewRow)

        Next


        If (dtMovimientosHistoricos.Rows.Count = 0) Then
            GoTo SaltoLinea
        End If


        '3.- Actualizar Campo Saldo.

        'Dim intSaldo As Integer

        'If (dtMovimientos.DefaultView.Item(0)!Entrada > 0) And (dtMovimientos.DefaultView.Item(0)!Salida = 0) Then
        '    intSaldo = dtMovimientos.DefaultView.Item(0)!Entrada
        'ElseIf (dtMovimientos.DefaultView.Item(0)!Salida > 0) And (dtMovimientos.DefaultView.Item(0)!Entrada = 0) Then
        '    intSaldo = dtMovimientos.DefaultView.Item(0)!Salida * (-1)
        'End If
        'dtMovimientos.DefaultView.Item(0)!Saldo = intSaldo


        'Dim intRow As Integer
        ''Apartir del Segundo Registro.
        'For intRow = 1 To (dtMovimientos.Rows.Count - 1)
        '    'Aumenta Saldo.
        '    If (dtMovimientos.DefaultView.Item(intRow)!Entrada > 0) And (dtMovimientos.DefaultView.Item(intRow)!Salida = 0) Then
        '        intSaldo += dtMovimientos.DefaultView.Item(intRow)!Entrada

        '        'Disminuye Saldo.
        '    ElseIf (dtMovimientos.DefaultView.Item(intRow)!Salida > 0) And (dtMovimientos.DefaultView.Item(intRow)!Entrada = 0) Then
        '        intSaldo -= dtMovimientos.DefaultView.Item(intRow)!Salida
        '    End If
        '    dtMovimientos.DefaultView.Item(intRow)!Saldo = intSaldo
        'Next

        Dim intSaldo As Integer

        If (dtMovimientosHistoricos.DefaultView.Item(0)!Entrada > 0) And (dtMovimientosHistoricos.DefaultView.Item(0)!Salida = 0) Then
            intSaldo = dtMovimientosHistoricos.DefaultView.Item(0)!Entrada
        ElseIf (dtMovimientosHistoricos.DefaultView.Item(0)!Salida > 0) And (dtMovimientosHistoricos.DefaultView.Item(0)!Entrada = 0) Then
            intSaldo = dtMovimientosHistoricos.DefaultView.Item(0)!Salida * (-1)
        End If
        dtMovimientosHistoricos.DefaultView.Item(0)!Saldo = intSaldo


        Dim intRow As Integer
        'Apartir del Segundo Registro.
        For intRow = 1 To (dtMovimientosHistoricos.Rows.Count - 1)
            'Aumenta Saldo.
            If (dtMovimientosHistoricos.DefaultView.Item(intRow)!Entrada > 0) And (dtMovimientosHistoricos.DefaultView.Item(intRow)!Salida = 0) Then
                intSaldo += dtMovimientos.DefaultView.Item(intRow)!Entrada

                'Disminuye Saldo.
            ElseIf (dtMovimientosHistoricos.DefaultView.Item(intRow)!Salida > 0) And (dtMovimientosHistoricos.DefaultView.Item(intRow)!Entrada = 0) Then
                intSaldo -= dtMovimientosHistoricos.DefaultView.Item(intRow)!Salida
            End If
            dtMovimientosHistoricos.DefaultView.Item(intRow)!Saldo = intSaldo
        Next


SaltoLinea:

        'Return dtMovimientos
        Return dtMovimientosHistoricos

    End Function


    Private Function MovimientosSel(ByVal strCodArticulo As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaCaja As SqlDataAdapter
        Dim dsCaja As DataSet
        Dim datFechaInicio As Date

        sccmdSelectAll = New SqlCommand
        scdaCaja = New SqlDataAdapter
        dsCaja = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[HistoricoDosAñosDetalleSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicio", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))

            'Asignar Valores :
            .Parameters("@CodArticulo").Value = strCodArticulo

            datFechaInicio = DateAdd(DateInterval.Year, -2, Date.Now)
            .Parameters("@FechaInicio").Value = DateAdd(DateInterval.Day, -1, datFechaInicio)

            .Parameters("@FechaFin").Value = DateAdd(DateInterval.Day, 1, Date.Now)

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


    Private Function MovimientosHistoricoSel(ByVal strCodArticulo As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaCaja As SqlDataAdapter
        Dim dsCaja As DataSet
        Dim datFechaInicio As Date
        Dim intAño As Integer

        sccmdSelectAll = New SqlCommand
        scdaCaja = New SqlDataAdapter
        dsCaja = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[HistoricoDosAñosDetalleHistoricoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicio", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))

            'Asignar Valores :
            .Parameters("@CodArticulo").Value = strCodArticulo

            datFechaInicio = DateAdd(DateInterval.Year, -2, Date.Now)
            '.Parameters("@FechaInicio").Value = DateAdd(DateInterval.Day, -1, datFechaInicio)
            intAño = DatePart(DateInterval.Year, datFechaInicio)
            .Parameters("@FechaInicio").Value = "01/01/" & intAño

            .Parameters("@FechaFin").Value = DateAdd(DateInterval.Day, 1, Date.Now)

        End With

        scdaCaja.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaCaja.Fill(dsCaja, "MovimientosHistorico")

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

        Return dsCaja.Tables("MovimientosHistorico")

    End Function

#End Region

End Class
