Option Explicit On 

Imports System.Data.SqlClient


Public Class AbonosApartadosDataGateWay

    Private oParent As AbonosApartadosManager




#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As AbonosApartadosManager)

        oParent = Parent

    End Sub

#End Region



#Region "Methods"

    Public Sub Insert(ByVal pAbonosApartados As AbonosApartados)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[AbonosApartadosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoApartadoID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAbono", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormaPago", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoTarjeta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroTarjeta", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroAutorizacion", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ComisionBancaria", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IngresoComision", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVAComision", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Abono", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoActual", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoNuevo", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClaCob", System.Data.SqlDbType.VarChar, 9))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoMov", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Id_Num_Promo", System.Data.SqlDbType.SmallInt, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPValeID", System.Data.SqlDbType.VarChar, 10))

            .Parameters.Add(New SqlParameter("@Ticket", SqlDbType.Int, 4))
            .Parameters.Add(New SqlParameter("@NoAfil", SqlDbType.VarChar, 10))


        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@AbonoApartadoID").Value = pAbonosApartados.ID
                .Parameters("@CodAlmacen").Value = pAbonosApartados.CodAlmacen
                .Parameters("@CodCaja").Value = pAbonosApartados.CodCaja
                .Parameters("@ApartadoID").Value = pAbonosApartados.ApartadoID
                .Parameters("@ClienteID").Value = pAbonosApartados.ClienteID
                .Parameters("@FolioAbono").Value = pAbonosApartados.FolioAbono
                .Parameters("@CodVendedor").Value = pAbonosApartados.CodVendedor.ToUpper
                .Parameters("@CodFormaPago").Value = pAbonosApartados.CodFormaPago.ToUpper
                .Parameters("@CodTipoTarjeta").Value = pAbonosApartados.TipoTarjeta
                .Parameters("@CodBanco").Value = pAbonosApartados.CodBanco.ToUpper
                .Parameters("@NumeroTarjeta").Value = pAbonosApartados.NumeroTarjeta
                .Parameters("@NumeroAutorizacion").Value = pAbonosApartados.NumeroAutorizacion
                .Parameters("@ComisionBancaria").Value = pAbonosApartados.ComisionBancaria
                .Parameters("@IngresoComision").Value = pAbonosApartados.IngresoComision
                .Parameters("@IVAComision").Value = pAbonosApartados.IvaComision
                .Parameters("@Abono").Value = pAbonosApartados.Abono
                .Parameters("@SaldoActual").Value = pAbonosApartados.SaldoActual
                .Parameters("@SaldoNuevo").Value = pAbonosApartados.SaldoNuevo
                .Parameters("@Usuario").Value = pAbonosApartados.Usuario.ToUpper
                .Parameters("@Fecha").Value = pAbonosApartados.Fecha
                .Parameters("@StatusRegistro").Value = pAbonosApartados.Status
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@ClaCob").Value = pAbonosApartados.ClaCobr
                .Parameters("@TipoMov").Value = pAbonosApartados.TipoMov
                .Parameters("@Ticket").Value = pAbonosApartados.Ticket
                .Parameters("@NoAfil").Value = pAbonosApartados.NumAfiliacion
                .Parameters("@Id_Num_Promo").Value = pAbonosApartados.Promocion
                .Parameters("@DPValeID").Value = pAbonosApartados.DPValeID

                'Execute Command
                .ExecuteNonQuery()

            End With

            'Reset New State of Linea Object 
            pAbonosApartados.ResetFlagNew()
            pAbonosApartados.ResetFlagDirty()

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

    Public Sub UpdateAbonosApartadosDocFi(ByVal intAbono As Integer, ByVal strDocFi As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[AbonosApartadosDocFiUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAbono", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocFi", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FolioAbono").Value = intAbono
                .Parameters("@DocFi").Value = strDocFi

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

    Public Function SelectByID(ByVal FolioAbono As Integer) As AbonosApartados

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oAbonosApartados As AbonosApartados

        oAbonosApartados = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[AbonosApartadosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAbono", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FolioAbono").Value = FolioAbono

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'oAbonosApartados.ID = .GetInt32(.GetOrdinal("AbonoApartadoID"))
                        If (.IsDBNull(.GetOrdinal("AbonoApartadoID")) = False) Then
                            oAbonosApartados.ID = .GetInt32(.GetOrdinal("AbonoApartadoID"))
                        Else
                            oAbonosApartados.ID = 0
                        End If


                        'oAbonosApartados.CodAlmacen = .GetString(.GetOrdinal("CodAlmacen"))
                        If (.IsDBNull(.GetOrdinal("CodAlmacen")) = False) Then
                            oAbonosApartados.CodAlmacen = .GetString(.GetOrdinal("CodAlmacen"))
                        Else
                            oAbonosApartados.CodAlmacen = String.Empty
                        End If


                        'oAbonosApartados.CodCaja = .GetString(.GetOrdinal("CodCaja"))
                        If (.IsDBNull(.GetOrdinal("CodCaja")) = False) Then
                            oAbonosApartados.CodCaja = .GetString(.GetOrdinal("CodCaja"))
                        Else
                            oAbonosApartados.CodCaja = String.Empty
                        End If


                        'oAbonosApartados.ApartadoID = .GetInt32(.GetOrdinal("ApartadoId"))
                        If (.IsDBNull(.GetOrdinal("ApartadoId")) = False) Then
                            oAbonosApartados.ApartadoID = .GetInt32(.GetOrdinal("ApartadoId"))
                        Else
                            oAbonosApartados.ApartadoID = 0
                        End If


                        'oAbonosApartados.FolioApartado = .GetInt32(.GetOrdinal("FolioApartado"))
                        If (.IsDBNull(.GetOrdinal("FolioApartado")) = False) Then
                            oAbonosApartados.FolioApartado = .GetInt32(.GetOrdinal("FolioApartado"))
                        Else
                            oAbonosApartados.FolioApartado = 0
                        End If


                        'oAbonosApartados.FolioAbono = .GetInt32(.GetOrdinal("FolioAbono"))
                        If (.IsDBNull(.GetOrdinal("FolioAbono")) = False) Then
                            oAbonosApartados.FolioAbono = .GetInt32(.GetOrdinal("FolioAbono"))
                        Else
                            oAbonosApartados.FolioAbono = 0
                        End If

                        'oAbonosApartados.Ticket = .GetInt32(.GetOrdinal("Ticket"))
                        If (.IsDBNull(.GetOrdinal("Ticket")) = False) Then
                            oAbonosApartados.Ticket = .GetInt32(.GetOrdinal("Ticket"))
                        Else
                            oAbonosApartados.Ticket = 0
                        End If

                        'oAbonosApartados.ClienteID = .GetInt32(.GetOrdinal("ClienteID"))
                        If (.IsDBNull(.GetOrdinal("ClienteID")) = False) Then
                            oAbonosApartados.ClienteID = .GetString(.GetOrdinal("ClienteID"))
                        Else
                            oAbonosApartados.ClienteID = 0
                        End If

                        If (.IsDBNull(.GetOrdinal("NoAfiliacion")) = False) Then
                            oAbonosApartados.NumAfiliacion = .GetString(.GetOrdinal("NoAfiliacion"))
                        Else
                            oAbonosApartados.NumAfiliacion = ""
                        End If

                        'oAbonosApartados.CodVendedor = .GetString(.GetOrdinal("CodVendedor"))
                        If (.IsDBNull(.GetOrdinal("CodVendedor")) = False) Then
                            oAbonosApartados.CodVendedor = .GetString(.GetOrdinal("CodVendedor"))
                        Else
                            oAbonosApartados.CodVendedor = String.Empty
                        End If


                        'oAbonosApartados.CodFormaPago = .GetString(.GetOrdinal("CodFormaPago"))
                        If (.IsDBNull(.GetOrdinal("CodFormaPago")) = False) Then
                            oAbonosApartados.CodFormaPago = .GetString(.GetOrdinal("CodFormaPago"))
                        Else
                            oAbonosApartados.CodFormaPago = String.Empty
                        End If


                        'oAbonosApartados.TipoTarjeta = .GetString(.GetOrdinal("CodTipoTarjeta"))
                        If (.IsDBNull(.GetOrdinal("CodTipoTarjeta")) = False) Then
                            oAbonosApartados.TipoTarjeta = .GetString(.GetOrdinal("CodTipoTarjeta"))
                        Else
                            oAbonosApartados.TipoTarjeta = String.Empty
                        End If


                        'oAbonosApartados.CodBanco = .GetString(.GetOrdinal("CodBanco"))
                        If (.IsDBNull(.GetOrdinal("CodBanco")) = False) Then
                            oAbonosApartados.CodBanco = .GetString(.GetOrdinal("CodBanco"))
                        Else
                            oAbonosApartados.CodBanco = String.Empty
                        End If


                        'oAbonosApartados.NumeroTarjeta = .GetString(.GetOrdinal("NumeroTarjeta"))
                        If (.IsDBNull(.GetOrdinal("NumeroTarjeta")) = False) Then
                            oAbonosApartados.NumeroTarjeta = .GetString(.GetOrdinal("NumeroTarjeta"))
                        Else
                            oAbonosApartados.NumeroTarjeta = String.Empty
                        End If


                        'oAbonosApartados.NumeroAutorizacion = .GetString(.GetOrdinal("NumeroAutorizacion"))
                        If (.IsDBNull(.GetOrdinal("NumeroAutorizacion")) = False) Then
                            oAbonosApartados.NumeroAutorizacion = .GetString(.GetOrdinal("NumeroAutorizacion"))
                        Else
                            oAbonosApartados.NumeroAutorizacion = String.Empty
                        End If


                        'oAbonosApartados.ComisionBancaria = .GetDecimal(.GetOrdinal("ComisionBancaria"))
                        If (.IsDBNull(.GetOrdinal("ComisionBancaria")) = False) Then
                            oAbonosApartados.ComisionBancaria = .GetDecimal(.GetOrdinal("ComisionBancaria"))
                        Else
                            oAbonosApartados.ComisionBancaria = 0.0
                        End If


                        'oAbonosApartados.IngresoComision = .GetDecimal(.GetOrdinal("IngresoComision"))
                        If (.IsDBNull(.GetOrdinal("IngresoComision")) = False) Then
                            oAbonosApartados.IngresoComision = .GetDecimal(.GetOrdinal("IngresoComision"))
                        Else
                            oAbonosApartados.IngresoComision = 0.0
                        End If


                        'oAbonosApartados.IvaComision = .GetDecimal(.GetOrdinal("IVAComision"))
                        If (.IsDBNull(.GetOrdinal("IVAComision")) = False) Then
                            oAbonosApartados.IvaComision = .GetDecimal(.GetOrdinal("IVAComision"))
                        Else
                            oAbonosApartados.IvaComision = 0.0
                        End If


                        'oAbonosApartados.Abono = .GetDecimal(.GetOrdinal("Abono"))
                        If (.IsDBNull(.GetOrdinal("Abono")) = False) Then
                            oAbonosApartados.Abono = .GetDecimal(.GetOrdinal("Abono"))
                        Else
                            oAbonosApartados.Abono = 0.0
                        End If


                        'oAbonosApartados.SaldoActual = .GetDecimal(.GetOrdinal("SaldoActual"))
                        If (.IsDBNull(.GetOrdinal("SaldoActual")) = False) Then
                            oAbonosApartados.SaldoActual = .GetDecimal(.GetOrdinal("SaldoActual"))
                        Else
                            oAbonosApartados.SaldoActual = 0.0
                        End If


                        'oAbonosApartados.SaldoNuevo = .GetDecimal(.GetOrdinal("SaldoNuevo"))
                        If (.IsDBNull(.GetOrdinal("SaldoNuevo")) = False) Then
                            oAbonosApartados.SaldoNuevo = .GetDecimal(.GetOrdinal("SaldoNuevo"))
                        Else
                            oAbonosApartados.SaldoNuevo = 0.0
                        End If


                        'oAbonosApartados.Usuario = .GetString(.GetOrdinal("Usuario"))
                        If (.IsDBNull(.GetOrdinal("Usuario")) = False) Then
                            oAbonosApartados.Usuario = .GetString(.GetOrdinal("Usuario"))
                        Else
                            oAbonosApartados.Usuario = String.Empty
                        End If


                        'oAbonosApartados.Fecha = .GetDateTime(.GetOrdinal("Fecha"))
                        If (.IsDBNull(.GetOrdinal("Fecha")) = False) Then
                            oAbonosApartados.Fecha = .GetDateTime(.GetOrdinal("Fecha"))
                        Else
                            oAbonosApartados.Fecha = Date.Now
                            'oAbonosApartados.Fecha = String.Empty
                        End If


                        'oAbonosApartados.Status = .GetBoolean(.GetOrdinal("StatusRegistro"))
                        If (.IsDBNull(.GetOrdinal("StatusRegistro")) = False) Then
                            oAbonosApartados.Status = .GetBoolean(.GetOrdinal("StatusRegistro"))
                        Else
                            oAbonosApartados.Status = False
                        End If

                        'oAbonosApartados.DocFi = .GetString(.GetOrdinal("DocFi"))
                        If (.IsDBNull(.GetOrdinal("DocFi")) = False) Then
                            oAbonosApartados.Docfi = .GetString(.GetOrdinal("DocFi"))
                        Else
                            oAbonosApartados.Docfi = String.Empty
                        End If

                        'oAbonosApartados.ClaCobr = .GetString(.GetOrdinal("ClaCobr"))
                        If (.IsDBNull(.GetOrdinal("ClaCobr")) = False) Then
                            oAbonosApartados.ClaCobr = .GetString(.GetOrdinal("ClaCobr"))
                        Else
                            oAbonosApartados.ClaCobr = String.Empty
                        End If

                        If (.IsDBNull(.GetOrdinal("Id_Num_Promo")) = False) Then
                            oAbonosApartados.Promocion = .GetInt32(.GetOrdinal("Id_Num_Promo"))
                        Else
                            oAbonosApartados.Promocion = 0
                        End If


                        If (.IsDBNull(.GetOrdinal("DPValeID")) = False) Then
                            oAbonosApartados.DPValeID = .GetString(.GetOrdinal("DPValeID"))
                        Else
                            oAbonosApartados.DPValeID = String.Empty
                        End If


                        'Reset New State of Linea Object 
                        oAbonosApartados.ResetFlagNew()
                        oAbonosApartados.ResetFlagDirty()

                    End With

                Else
                    oAbonosApartados = Nothing
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

        'If (oAbonosApartados Is Nothing) Then
        'Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de Abono no existe.")
        'End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oAbonosApartados

    End Function

    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAbonosApartados As SqlDataAdapter
        Dim dsAbonosApartados As DataSet

        sccmdSelectAll = New SqlCommand
        scdaAbonosApartados = New SqlDataAdapter
        dsAbonosApartados = New DataSet("AbonosApartados")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AbonosApartadosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
        End With

        scdaAbonosApartados.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaAbonosApartados.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            'Fill DataSet
            scdaAbonosApartados.Fill(dsAbonosApartados, "AbonosApartados")

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

        Return dsAbonosApartados

    End Function

    Public Function SelectByApartadoID(ByVal ApartadoID As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAbonosApartados As SqlDataAdapter
        Dim dsAbonosApartados As DataSet

        sccmdSelectAll = New SqlCommand
        scdaAbonosApartados = New SqlDataAdapter
        dsAbonosApartados = New DataSet("AbonosApartados")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AbonosApartadosSelApartadoID]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int, 4))
        End With

        scdaAbonosApartados.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaAbonosApartados.SelectCommand.Parameters("@ApartadoID").Value = ApartadoID

            'Fill DataSet
            scdaAbonosApartados.Fill(dsAbonosApartados, "AbonosApartados")

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

        Return dsAbonosApartados

    End Function

    Public Function AbonosApartadosFolios() As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim decRetornarValor As Integer



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[AbonosApartadosFolios]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            'OutPut :
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAbono", System.Data.SqlDbType.Int))
            .Parameters("@FolioAbono").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        decRetornarValor = .GetInt32(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    Return 0

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

        Return decRetornarValor

    End Function


    Public Function SelectByDate(ByVal Fecha As DateTime) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAbonosApartados As SqlDataAdapter
        Dim dsAbonosApartados As DataSet

        sccmdSelectAll = New SqlCommand
        scdaAbonosApartados = New SqlDataAdapter
        dsAbonosApartados = New DataSet("AbonosApartadosSelByDate")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AbonosApartadosSelByDate]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
        End With

        scdaAbonosApartados.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaAbonosApartados.SelectCommand.Parameters("@Fecha").Value = Fecha

            'Fill DataSet
            scdaAbonosApartados.Fill(dsAbonosApartados, "AbonosApartados")

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

        Return dsAbonosApartados

    End Function


    Public Function SelectAbonosDPCardByDate(ByVal Fecha As DateTime) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAbonosApartados As SqlDataAdapter
        Dim dsAbonosApartados As DataSet

        sccmdSelectAll = New SqlCommand
        scdaAbonosApartados = New SqlDataAdapter
        dsAbonosApartados = New DataSet("AbonosDPCard")

        With sccmdSelectAll
            .Connection = sccnnConnection
            .CommandText = "[AbonosDPCardSelByDate]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
        End With

        scdaAbonosApartados.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaAbonosApartados.SelectCommand.Parameters("@Fecha").Value = Fecha

            'Fill DataSet
            scdaAbonosApartados.Fill(dsAbonosApartados, "AbonosDPCard")

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

        Return dsAbonosApartados.Tables(0)

    End Function

    Public Sub CtaMayorSel(ByVal Tienda As String, ByVal ClaCobr As String, ByRef CuentaMayor As String, ByRef GSBER As String, ByRef Werks As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdrCtaMayor As SqlDataReader

        sccmdSelectAll = New SqlCommand

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CtaMayorSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@tienda", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@clacobr", System.Data.SqlDbType.VarChar, 9))

            .Parameters("@tienda").Value = Tienda.TrimEnd
            .Parameters("@clacobr").Value = ClaCobr.TrimEnd
        End With


        Try

            sccnnConnection.Open()

            With sccmdSelectAll

                scdrCtaMayor = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Fill DataSet
                scdrCtaMayor.Read()

                If (scdrCtaMayor.HasRows) And (IsDBNull(scdrCtaMayor.Item(0)) <> True) Then

                    With scdrCtaMayor

                        CuentaMayor = .GetString(0)
                        GSBER = .GetString(1)
                        Werks = .GetString(2)

                    End With

                Else

                    scdrCtaMayor.Close()
                    sccnnConnection.Close()


                End If

            End With



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


    End Sub

    Public Function SelectNombreTienda(ByVal strTipoPago As String, ByVal strCentro As String) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)


        Dim strResult As String
        Dim sccmdSelectAll As SqlCommand
        sccmdSelectAll = New SqlCommand


        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[ZPP_COBRANZASSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPCLAVE", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Clacobr", System.Data.SqlDbType.VarChar, 9))

            .Parameters("@DPCLAVE").Value = strCentro
            .Parameters("@Clacobr").Value = strTipoPago

        End With


        Try

            sccnnConnection.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdSelectAll.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetString(0)
                End With
                scsdrReader.Close()

            Else

                strResult = String.Empty

            End If


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

        Return strResult

    End Function

    Public Function SelectDivision(ByVal strTipoPago As String, ByVal strCentro As String) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)


        Dim strResult As String
        Dim sccmdSelectAll As SqlCommand
        sccmdSelectAll = New SqlCommand


        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[ZPP_COBRANZASSelGSBER]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPCLAVE", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Clacobr", System.Data.SqlDbType.VarChar, 9))

            .Parameters("@DPCLAVE").Value = strCentro
            .Parameters("@Clacobr").Value = strTipoPago

        End With


        Try

            sccnnConnection.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdSelectAll.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetString(0)
                End With
                scsdrReader.Close()

            Else

                strResult = String.Empty

            End If


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

        Return strResult

    End Function


#End Region

    Public Function SelectByDateRerpote(ByVal FechaDe As DateTime, ByVal FechaAl As DateTime, ByVal CodCaja As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAbonosApartados As SqlDataAdapter
        Dim dsAbonosApartados As DataSet

        sccmdSelectAll = New SqlCommand
        scdaAbonosApartados = New SqlDataAdapter
        dsAbonosApartados = New DataSet("AbonosApartados")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AbonosApartadosSelReporte]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDe", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaAl", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
        End With

        scdaAbonosApartados.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaAbonosApartados.SelectCommand.Parameters("@FechaDe").Value = FechaDe
            scdaAbonosApartados.SelectCommand.Parameters("@FechaAl").Value = FechaAl
            scdaAbonosApartados.SelectCommand.Parameters("@CodCaja").Value = CodCaja

            'Fill DataSet
            scdaAbonosApartados.Fill(dsAbonosApartados, "AbonosApartados")

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

        Return dsAbonosApartados

    End Function

    Public Function SelectByDateCancelados(ByVal FechaDe As DateTime, ByVal FechaAl As DateTime, ByVal CodCaja As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAbonosApartados As SqlDataAdapter
        Dim dsAbonosApartados As DataSet

        sccmdSelectAll = New SqlCommand
        scdaAbonosApartados = New SqlDataAdapter
        dsAbonosApartados = New DataSet("AbonosApartados")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AbonosApartadosSelCancelados]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDe", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaAl", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
        End With

        scdaAbonosApartados.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaAbonosApartados.SelectCommand.Parameters("@FechaDe").Value = FechaDe
            scdaAbonosApartados.SelectCommand.Parameters("@FechaAl").Value = FechaAl
            scdaAbonosApartados.SelectCommand.Parameters("@CodCaja").Value = CodCaja

            'Fill DataSet
            scdaAbonosApartados.Fill(dsAbonosApartados, "AbonosApartados")

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

        Return dsAbonosApartados

    End Function

End Class
