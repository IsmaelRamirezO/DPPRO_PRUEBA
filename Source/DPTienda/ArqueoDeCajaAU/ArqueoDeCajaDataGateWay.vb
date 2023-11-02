Imports System.Data.SqlClient

Public Class ArqueoDeCajaDataGateWay
    Private oParent As ArqueoDeCajaManager

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As ArqueoDeCajaManager)
        oParent = Parent
    End Sub


#End Region

    Public Function FechaServer() As Date

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaExtraerFechaSERVER]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaSERVER", System.Data.SqlDbType.DateTime))
            .Parameters("@FechaSERVER").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@FechaSERVER").Value = Date.Now

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        FechaServer = IIf(IsDBNull(.GetDateTime(0)), 0, .GetDateTime(.GetOrdinal("FechaSERVER")))

                    End With

                Else

                    FechaServer = Now.Date

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


        Return FechaServer

    End Function

    Public Function IngresosEfectivoDia(ByVal Fecha As Date, ByVal CodCaja As String, ByVal CodAlmacen As String) As Decimal

        Try
            Dim Efectivo As Decimal
            Efectivo = IngresosFacturaEfectivoDia(Fecha, CodCaja, CodAlmacen)
            Efectivo += IngresosPedidoEfectivoDia(Fecha, CodCaja, CodAlmacen)
            Efectivo += IngresosAbonosApartadosEfectivoDia(Fecha, CodCaja, CodAlmacen)
            Efectivo += IngresosAbonosCDTDia(Fecha, CodCaja, CodAlmacen)
            'Efectivo -= DevolucionEfectivoDia(Fecha, CodCaja, CodAlmacen)
            Efectivo -= DevolucionFacturaEfectivo(Fecha)


            Return Efectivo


        Catch ex As Exception

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try


    End Function
    Public Function IngresosEfectivoDiaREP(ByVal Fecha As Date, ByVal CodAlmacen As String) As Decimal

        Try
            Dim Efectivo As Decimal
            Efectivo = IngresosFacturaEfectivoDiaREP(Fecha, CodAlmacen)
            Efectivo += IngresosPedidoEfectivoDia(Fecha, "", CodAlmacen)
            Efectivo += IngresosAbonosApartadosEfectivoDiaREP(Fecha, CodAlmacen)
            Efectivo += IngresosAbonosCDTDiaREP(Fecha, CodAlmacen)
            Efectivo -= DevolucionEfectivoDiaREP(Fecha, CodAlmacen)

            Return Efectivo


        Catch ex As Exception

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try


    End Function

    Public Function DevolucionFacturaEfectivo(ByVal Fecha As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[GetDevolucionEfectivo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Fecha

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'IngresosFacturaEfectivoDia = .GetDecimal(.GetOrdinal("TotalFacturaE"))
                        DevolucionFacturaEfectivo = IIf(IsDBNull(.GetDecimal(0)), 0, .GetDecimal(.GetOrdinal("DevEfectivo")))

                    End With

                Else

                    DevolucionFacturaEfectivo = 0.0

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


        Return DevolucionFacturaEfectivo

    End Function

    Public Function IngresosFacturaEfectivoDia(ByVal Fecha As Date, ByVal CodCaja As String, ByVal CodAlmacen As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[FacturaEfectivo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))


        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Fecha
                .Parameters("@CodCaja").Value = CodCaja
                .Parameters("@CodAlmacen").Value = CodAlmacen

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'IngresosFacturaEfectivoDia = .GetDecimal(.GetOrdinal("TotalFacturaE"))
                        IngresosFacturaEfectivoDia = IIf(IsDBNull(.GetDecimal(0)), 0, .GetDecimal(.GetOrdinal("TotalFacturaE")))

                    End With

                Else

                    IngresosFacturaEfectivoDia = 0.0

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


        Return IngresosFacturaEfectivoDia

    End Function
    Public Function IngresosFacturaEfectivoDiaREP(ByVal Fecha As Date, ByVal CodAlmacen As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[FacturaEfectivoREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))


        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Fecha
                .Parameters("@CodAlmacen").Value = CodAlmacen

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'IngresosFacturaEfectivoDia = .GetDecimal(.GetOrdinal("TotalFacturaE"))
                        If .IsDBNull(.GetOrdinal("TotalFacturaE")) Then
                            IngresosFacturaEfectivoDiaREP = 0
                        Else
                            IngresosFacturaEfectivoDiaREP = .GetDecimal(.GetOrdinal("TotalFacturaE"))
                        End If
                        'IngresosFacturaEfectivoDiaREP = IIf(IsDBNull(.GetDecimal(0)), 0, .GetDecimal(.GetOrdinal("TotalFacturaE")))

                    End With

                Else

                    IngresosFacturaEfectivoDiaREP = 0.0

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


        Return IngresosFacturaEfectivoDiaREP

    End Function

    Public Function DevolucionEfectivoDia(ByVal Fecha As Date, ByVal CodCaja As String, ByVal CodAlmacen As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[DevolucionEfectivoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Fecha
                .Parameters("@CodCaja").Value = CodCaja
                .Parameters("@CodAlmacen").Value = CodAlmacen

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        DevolucionEfectivoDia = IIf(IsDBNull(.GetDecimal(0)), 0, .GetDecimal(.GetOrdinal("TotalDevolucionEfectivo")))

                    End With

                Else

                    DevolucionEfectivoDia = 0.0

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


        Return DevolucionEfectivoDia

    End Function
    Public Function DevolucionEfectivoDiaREP(ByVal Fecha As Date, ByVal CodAlmacen As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[DevolucionEfectivoSelREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Fecha
                .Parameters("@CodAlmacen").Value = CodAlmacen

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        DevolucionEfectivoDiaREP = IIf(IsDBNull(.GetDecimal(0)), 0, .GetDecimal(.GetOrdinal("TotalDevolucionEfectivo")))

                    End With

                Else

                    DevolucionEfectivoDiaREP = 0.0

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


        Return DevolucionEfectivoDiaREP

    End Function

    Public Function IngresosAbonosApartadosEfectivoDia(ByVal Fecha As Date, ByVal CodCaja As String, ByVal CodAlmacen As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[AbonosApartadosEfectivo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))


        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Fecha
                .Parameters("@CodCaja").Value = CodCaja
                .Parameters("@CodAlmacen").Value = CodAlmacen

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'IngresosAbonosApartadosEfectivoDia = .GetDecimal(.GetOrdinal("TotalAbonoApartadoE"))
                        IngresosAbonosApartadosEfectivoDia = IIf(IsDBNull(.GetDecimal(0)), 0, .GetDecimal(.GetOrdinal("TotalAbonoApartadoE")))


                    End With

                Else

                    IngresosAbonosApartadosEfectivoDia = 0.0

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


        Return IngresosAbonosApartadosEfectivoDia

    End Function
    Public Function IngresosAbonosApartadosEfectivoDiaREP(ByVal Fecha As Date, ByVal CodAlmacen As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[AbonosApartadosEfectivoREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))


        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Fecha
                .Parameters("@CodAlmacen").Value = CodAlmacen

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'IngresosAbonosApartadosEfectivoDia = .GetDecimal(.GetOrdinal("TotalAbonoApartadoE"))
                        IngresosAbonosApartadosEfectivoDiaREP = IIf(IsDBNull(.GetDecimal(0)), 0, .GetDecimal(.GetOrdinal("TotalAbonoApartadoE")))


                    End With

                Else

                    IngresosAbonosApartadosEfectivoDiaREP = 0.0

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


        Return IngresosAbonosApartadosEfectivoDiaREP

    End Function
    Public Function Insert(ByVal pArqueoDeCaja As ArqueoDeCaja) As ArqueoDeCaja

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ArqueoCajaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, "Folio"))
            .Parameters("@Folio").Direction = ParameterDirection.Output
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sucursal", System.Data.SqlDbType.VarChar, 3, "Sucursal"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Caja", System.Data.SqlDbType.VarChar, 2, "Caja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Administrativo", System.Data.SqlDbType.VarChar, 5, "Administrativo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Responsable", System.Data.SqlDbType.VarChar, 5, "Responsable"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IngresosDia", System.Data.SqlDbType.Decimal, 9, "IngresosDia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IngresosDiaAnterior", System.Data.SqlDbType.Decimal, 9, "IngresosDiaAnterior"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FondoCaja", System.Data.SqlDbType.Decimal, 9, "FondoCaja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.VarChar, 200, "Observaciones"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))



        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Sucursal").Value = pArqueoDeCaja.Sucursal
                .Parameters("@Caja").Value = pArqueoDeCaja.Caja
                .Parameters("@Administrativo").Value = pArqueoDeCaja.Administrativo
                .Parameters("@Responsable").Value = pArqueoDeCaja.Responsable
                .Parameters("@IngresosDia").Value = pArqueoDeCaja.IngresosDia
                .Parameters("@IngresosDiaAnterior").Value = pArqueoDeCaja.IngresosDiaAnterioro
                .Parameters("@FondoCaja").Value = pArqueoDeCaja.FondoCaja
                .Parameters("@Observaciones").Value = pArqueoDeCaja.Observaciones
                .Parameters("@Fecha").Value = pArqueoDeCaja.Fecha
                .Parameters("@StatusRegistro").Value = pArqueoDeCaja.StatusRegistro

                'Execute Command
                .ExecuteNonQuery()

                pArqueoDeCaja.Folio = .Parameters("@Folio").Value

                'Assign Other Values

            End With

            'Reset New State of Linea Object 

            pArqueoDeCaja.ResetFlagNew()
            pArqueoDeCaja.ResetFlagDirty()

            ''''''Ingresos en Efectivo

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[IngresosEnEfectivoDelDiaIns]"
                .CommandType = System.Data.CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, "Folio"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Denominacion", System.Data.SqlDbType.Decimal, 9, "Denominacion"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.TinyInt, 1, "Cantidad"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Decimal, 9, "Total"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))

                Dim custDV As DataView = New DataView(pArqueoDeCaja.Ingresos.Tables("Denominaciones"), _
                                                     "Cantidad > 0", _
                                                     "Denominacion", _
                                                     DataViewRowState.CurrentRows)


                For Each row As DataRow In custDV.Table.Rows

                    .Parameters("@Folio").Value = pArqueoDeCaja.Folio
                    .Parameters("@Denominacion").Value = row("Denominacion")
                    .Parameters("@Cantidad").Value = row("Cantidad")
                    .Parameters("@Total").Value = row("Total")
                    .Parameters("@Fecha").Value = pArqueoDeCaja.Fecha
                    .Parameters("@StatusRegistro").Value = pArqueoDeCaja.StatusRegistro

                    'Execute Command
                    .ExecuteNonQuery()

                Next




            End With

            ''''''Fondo de Caja

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[FondoCajaIns]"
                .CommandType = System.Data.CommandType.StoredProcedure

                Dim custDV As DataView = New DataView(pArqueoDeCaja.Ingresos.Tables("Denominaciones2"), _
                                                     "Cantidad > 0", _
                                                     "Denominacion", _
                                                     DataViewRowState.CurrentRows)


                For Each row As DataRow In custDV.Table.Rows

                    .Parameters("@Folio").Value = pArqueoDeCaja.Folio
                    .Parameters("@Denominacion").Value = row("Denominacion")
                    .Parameters("@Cantidad").Value = row("Cantidad")
                    .Parameters("@Total").Value = row("Total")
                    .Parameters("@Fecha").Value = pArqueoDeCaja.Fecha
                    .Parameters("@StatusRegistro").Value = pArqueoDeCaja.StatusRegistro

                    'Execute Command
                    .ExecuteNonQuery()

                Next




            End With

            ''''''Ingresos en Efectivo del dia anterior

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[IngresosEnEfectivoDiaAnteriorIns]"
                .CommandType = System.Data.CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, "Folio"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Banco", System.Data.SqlDbType.VarChar, 4, "Banco"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ficha", System.Data.SqlDbType.VarChar, 10, "Ficha"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Decimal, 9, "Importe"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))

                Dim custDV As DataView = New DataView(pArqueoDeCaja.Ingresos.Tables("IngresoAnterior"), _
                                                     "Importe > 0", _
                                                     "Banco", _
                                                     DataViewRowState.CurrentRows)


                For Each row As DataRow In custDV.Table.Rows

                    .Parameters("@Folio").Value = pArqueoDeCaja.Folio
                    .Parameters("@Banco").Value = row("Banco")
                    .Parameters("@Ficha").Value = row("Ficha")
                    .Parameters("@Importe").Value = row("Importe")
                    .Parameters("@Fecha").Value = pArqueoDeCaja.Fecha
                    .Parameters("@StatusRegistro").Value = pArqueoDeCaja.StatusRegistro

                    'Execute Command
                    .ExecuteNonQuery()

                Next




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

        Return pArqueoDeCaja

    End Function

    Public Function SelectByID(ByVal ID As Int32) As ArqueoDeCaja

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oArqueoCaja As ArqueoDeCaja

        oArqueoCaja = oParent.Create
        oArqueoCaja.Folio = 0

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ArqueoCajaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@Folio").Value = ID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oArqueoCaja.Folio = .GetInt32(.GetOrdinal("Folio"))
                        oArqueoCaja.Administrativo = .GetString(.GetOrdinal("Administrativo"))
                        oArqueoCaja.Responsable = .GetString(.GetOrdinal("Responsable"))
                        oArqueoCaja.Caja = .GetString(.GetOrdinal("Caja"))
                        oArqueoCaja.Sucursal = .GetString(.GetOrdinal("Sucursal"))
                        oArqueoCaja.Fecha = .GetDateTime(.GetOrdinal("Fecha"))
                        oArqueoCaja.StatusRegistro = .GetBoolean(.GetOrdinal("StatusRegistro"))
                        oArqueoCaja.IngresosDia = .GetDecimal(.GetOrdinal("IngresosDia"))
                        oArqueoCaja.IngresosDiaAnterioro = .GetDecimal(.GetOrdinal("IngresosDiaAnterior"))
                        oArqueoCaja.FondoCaja = .GetDecimal(.GetOrdinal("FondoCaja"))
                        oArqueoCaja.Observaciones = .GetString(.GetOrdinal("Observaciones"))
                        oArqueoCaja.Ingresos = SelectDetalle(oArqueoCaja.Folio).Copy

                        'Reset New State of Linea Object 
                        oArqueoCaja.ResetFlagNew()
                        oArqueoCaja.ResetFlagDirty()

                    End With

                Else
                    oArqueoCaja = Nothing
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

        If (oArqueoCaja Is Nothing) Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de Banco no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oArqueoCaja

    End Function

    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaBanco As SqlDataAdapter
        Dim dsArqueoCaja As DataSet

        sccmdSelectAll = New SqlCommand
        scdaBanco = New SqlDataAdapter
        dsArqueoCaja = New DataSet("ArqueoCaja")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[ArqueoCajaSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
        End With

        scdaBanco.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaBanco.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            'Fill DataSet
            scdaBanco.Fill(dsArqueoCaja, "ArqueoCaja")

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

        Return dsArqueoCaja

    End Function

    Public Function SelectDetalle(ByVal Folio As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaBanco As SqlDataAdapter
        Dim dsIngresos As DataSet

        sccmdSelectAll = New SqlCommand
        scdaBanco = New SqlDataAdapter
        dsIngresos = New DataSet("Ingresos")

        With sccmdSelectAll

            .Connection = sccnnConnection


            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))
        End With

        scdaBanco.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaBanco.SelectCommand.Parameters("@Folio").Value = Folio

            'Fill DataSet
            sccmdSelectAll.CommandText = "[IngresosEnEfectivoDelDiaSel]"
            scdaBanco.Fill(dsIngresos, "Denominaciones")

            sccmdSelectAll.CommandText = "[IngresosEnEfectivoDelDiaAnteriorSel]"
            scdaBanco.Fill(dsIngresos, "IngresoAnterior")

            sccmdSelectAll.CommandText = "[FondoCajaSel]"
            scdaBanco.Fill(dsIngresos, "Denominaciones2")

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

        Return dsIngresos

    End Function

    Public Function InsertCajaChica(ByVal pArqueoDeCaja As ArqueoDeCaja) As ArqueoDeCaja

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim myTrans As SqlTransaction



        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ArqueoCajaChicaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, "Folio"))
            .Parameters("@Folio").Direction = ParameterDirection.Output
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sucursal", System.Data.SqlDbType.VarChar, 3, "Sucursal"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Caja", System.Data.SqlDbType.VarChar, 2, "Caja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Administrativo", System.Data.SqlDbType.VarChar, 5, "Administrativo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Responsable", System.Data.SqlDbType.VarChar, 5, "Responsable"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CajaChica", System.Data.SqlDbType.Decimal, 9, "FondoCaja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.VarChar, 200, "Observaciones"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))



        End With

        Try

            sccnnConnection.Open()
            myTrans = sccnnConnection.BeginTransaction()
            sccmdInsert.Transaction = myTrans

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Sucursal").Value = pArqueoDeCaja.Sucursal
                .Parameters("@Caja").Value = pArqueoDeCaja.Caja
                .Parameters("@Administrativo").Value = pArqueoDeCaja.Administrativo
                .Parameters("@Responsable").Value = pArqueoDeCaja.Responsable
                .Parameters("@CajaChica").Value = pArqueoDeCaja.FondoCaja
                .Parameters("@Observaciones").Value = pArqueoDeCaja.Observaciones
                .Parameters("@Fecha").Value = pArqueoDeCaja.Fecha
                .Parameters("@StatusRegistro").Value = pArqueoDeCaja.StatusRegistro

                'Execute Command
                .ExecuteNonQuery()

                pArqueoDeCaja.Folio = .Parameters("@Folio").Value

                'Assign Other Values

            End With

            'Reset New State of Linea Object 

            pArqueoDeCaja.ResetFlagNew()
            pArqueoDeCaja.ResetFlagDirty()

            ''''''Ingresos en Efectivo

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[IngresosEnEfectivoDelDiaCajaChicaIns]"
                .CommandType = System.Data.CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, "Folio"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Denominacion", System.Data.SqlDbType.Decimal, 9, "Denominacion"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.TinyInt, 1, "Cantidad"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Decimal, 9, "Total"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))

                Dim custDV As DataView = New DataView(pArqueoDeCaja.Ingresos.Tables("Denominaciones"), _
                                                     "Cantidad > 0", _
                                                     "Denominacion", _
                                                     DataViewRowState.CurrentRows)


                For Each row As DataRow In custDV.Table.Rows

                    .Parameters("@Folio").Value = pArqueoDeCaja.Folio
                    .Parameters("@Denominacion").Value = row("Denominacion")
                    .Parameters("@Cantidad").Value = row("Cantidad")
                    .Parameters("@Total").Value = row("Total")
                    .Parameters("@Fecha").Value = pArqueoDeCaja.Fecha
                    .Parameters("@StatusRegistro").Value = pArqueoDeCaja.StatusRegistro

                    'Execute Command
                    .ExecuteNonQuery()

                Next




            End With


            ''''''Ingresos en Efectivo del dia anterior

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[DocumentosArqueoCajaChicaIns]"
                .CommandType = System.Data.CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, "Folio"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDocumento", System.Data.SqlDbType.DateTime, 8, "FechaDocumento"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Concepto", System.Data.SqlDbType.VarChar, 50, "Concepto"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Decimal, 9, "Importe"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))

                Dim custDV As DataView = New DataView(pArqueoDeCaja.Ingresos.Tables("Documentos"), _
                                                     "Importe > 0", _
                                                     "Fecha", _
                                                     DataViewRowState.CurrentRows)


                For Each row As DataRow In custDV.Table.Rows

                    .Parameters("@Folio").Value = pArqueoDeCaja.Folio
                    .Parameters("@FechaDocumento").Value = row("Fecha")
                    .Parameters("@Concepto").Value = row("Concepto")
                    .Parameters("@Importe").Value = row("Importe")
                    .Parameters("@Fecha").Value = pArqueoDeCaja.Fecha
                    .Parameters("@StatusRegistro").Value = pArqueoDeCaja.StatusRegistro

                    'Execute Command
                    .ExecuteNonQuery()

                Next




            End With

            myTrans.Commit()
            sccnnConnection.Close()


        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)
            myTrans.Rollback()

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)
            myTrans.Rollback()

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return pArqueoDeCaja

    End Function

    Public Function SelectCajaChicaAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaBanco As SqlDataAdapter
        Dim dsArqueoCaja As DataSet

        sccmdSelectAll = New SqlCommand
        scdaBanco = New SqlDataAdapter
        dsArqueoCaja = New DataSet("ArqueoCajaChica")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[ArqueoCajaChicaSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
        End With

        scdaBanco.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaBanco.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            'Fill DataSet
            scdaBanco.Fill(dsArqueoCaja, "ArqueoCajaChica")

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

        Return dsArqueoCaja

    End Function

    Public Function SelectCajaChicaByID(ByVal ID As Int32) As ArqueoDeCaja

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oArqueoCaja As ArqueoDeCaja

        oArqueoCaja = oParent.Create
        oArqueoCaja.Folio = 0

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ArqueoCajaChicaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@Folio").Value = ID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oArqueoCaja.Folio = .GetInt32(.GetOrdinal("Folio"))
                        oArqueoCaja.Administrativo = .GetString(.GetOrdinal("Administrativo"))
                        oArqueoCaja.Responsable = .GetString(.GetOrdinal("Responsable"))
                        oArqueoCaja.Caja = .GetString(.GetOrdinal("Caja"))
                        oArqueoCaja.Sucursal = .GetString(.GetOrdinal("Sucursal"))
                        oArqueoCaja.Fecha = .GetDateTime(.GetOrdinal("Fecha"))
                        oArqueoCaja.StatusRegistro = .GetBoolean(.GetOrdinal("StatusRegistro"))
                        oArqueoCaja.FondoCaja = .GetDecimal(.GetOrdinal("CajaChica"))
                        oArqueoCaja.Observaciones = .GetString(.GetOrdinal("Observaciones"))
                        oArqueoCaja.Ingresos = SelectCajaChicaDetalle(oArqueoCaja.Folio).Copy

                        'Reset New State of Linea Object 
                        oArqueoCaja.ResetFlagNew()
                        oArqueoCaja.ResetFlagDirty()

                    End With

                Else
                    oArqueoCaja = Nothing
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

        If (oArqueoCaja Is Nothing) Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de Banco no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oArqueoCaja

    End Function

    Public Function SelectCajaChicaDetalle(ByVal Folio As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaBanco As SqlDataAdapter
        Dim dsIngresos As DataSet

        sccmdSelectAll = New SqlCommand
        scdaBanco = New SqlDataAdapter
        dsIngresos = New DataSet("Ingresos")

        With sccmdSelectAll

            .Connection = sccnnConnection


            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))
        End With

        scdaBanco.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaBanco.SelectCommand.Parameters("@Folio").Value = Folio

            'Fill DataSet
            sccmdSelectAll.CommandText = "[IngresosEnEfectivoDelDiaCajaChicaSel]"
            scdaBanco.Fill(dsIngresos, "Denominaciones")

            sccmdSelectAll.CommandText = "[DocumentosArqueoCajaChicaSel]"
            scdaBanco.Fill(dsIngresos, "Documentos")


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

        Return dsIngresos

    End Function

    'Ya no va a servir Borrar ya que se termine
    Private Function AbonosCreditoEfectivo(ByVal Fecha As Date, ByVal Caja As String, ByVal CodAlmacen As String) As Decimal
        Try

            'Dim wsAbonosEfectivo As New wsAbonosEnEfectivo.AbonosCreditoEfectivo

            'If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then
            '    wsAbonosEfectivo.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") _
            '            & "/" & wsAbonosEfectivo.strURL.TrimStart("/")
            'End If


            'Return wsAbonosEfectivo.AbonosEnEfectivo(Fecha, Caja, CodAlmacen)




        Catch ex As Exception

            Throw New ApplicationException(ex.Message, ex)

        End Try


    End Function

    Public Function SelectFolioArqueo(ByVal TipoArqueo As Integer) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim oResult As Integer

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ArqueoCajaFolioSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoArqueo", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))
            .Parameters("@Folio").Direction = ParameterDirection.Output

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@TipoArqueo").Value = TipoArqueo
                .Parameters("@Folio").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader
                        oResult = .GetInt32(.GetOrdinal("FolioArqueo"))
                    End With

                Else
                    oResult = 1
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

        Return oResult

    End Function


    Public Function IngresosAbonosCDTDia(ByVal Fecha As Date, ByVal CodCaja As String, ByVal CodAlmacen As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim decEfect As Decimal = 0

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[AbonoCDTEfectivo]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Fecha").Value = Format(Fecha, "Short Date")
                .Parameters("@CodCaja").Value = CodCaja
                .Parameters("@CodAlmacen").Value = CodAlmacen

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        decEfect = .GetDecimal(0)

                    End With

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


        Return decEfect

    End Function
    Public Function IngresosAbonosCDTDiaREP(ByVal Fecha As Date, ByVal CodAlmacen As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim decEfect As Decimal = 0

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[AbonoCDTEfectivoREP]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Fecha").Value = Format(Fecha, "Short Date")
                .Parameters("@CodAlmacen").Value = CodAlmacen

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        decEfect = .GetDecimal(0)

                    End With

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


        Return decEfect

    End Function

#Region "Facturacion SiHay"

    Public Function IngresosPedidoEfectivoDia(ByVal Fecha As Date, ByVal CodCaja As String, ByVal CodAlmacen As String) As Decimal
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("PedidoEfectivo", conexion)
        Dim cantidad As Decimal = 0
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Fecha", Fecha)
            command.Parameters.Add("@CodCaja", CodCaja)
            command.Parameters.Add("@CodAlmacen", CodAlmacen)
            cantidad = CDec(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch oSqlException As SqlException

            If (conexion.State <> ConnectionState.Closed) Then
                Try
                    conexion.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (conexion.State <> ConnectionState.Closed) Then
                Try
                    conexion.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try
        Return cantidad
    End Function

#End Region

End Class
