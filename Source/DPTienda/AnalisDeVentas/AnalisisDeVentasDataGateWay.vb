Option Explicit On 

Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores

Public Class AnalisisDeVentasDataGateWay

    Private oParent As AnalisisDeVentasMgr

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As AnalisisDeVentasMgr)

        oParent = Parent

    End Sub

#End Region

    Public Function GetVentasAsociadosDPVale(ByVal TipoVenta As String, ByVal FechaDe As Date, ByVal FechaHasta As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaVentasDpVale As SqlDataAdapter
        Dim dsVentas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaVentasDpVale = New SqlDataAdapter
        dsVentas = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection

            If TipoVenta.Equals("T") Then

                .CommandText = "[VentasPlayerAll]"

            ElseIf TipoVenta.Equals("TC") Then

                .CommandText = "[VentasPlayerALLCredito]"

            Else

                .CommandText = "[VentasPlayerEspecifico]"

            End If

            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            If (Not TipoVenta.Equals("T")) And (Not TipoVenta.Equals("TC")) Then

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 20))

            End If

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDe", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaHasta", System.Data.SqlDbType.DateTime, 8))

        End With

        scdaVentasDpVale.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            If (Not TipoVenta.Equals("T")) And (Not TipoVenta.Equals("TC")) Then

                scdaVentasDpVale.SelectCommand.Parameters("@TipoVenta").Value = TipoVenta

            End If

            scdaVentasDpVale.SelectCommand.Parameters("@FechaDe").Value = FechaDe
            scdaVentasDpVale.SelectCommand.Parameters("@FechaHasta").Value = FechaHasta

            'Fill DataSet
            scdaVentasDpVale.Fill(dsVentas, "VentasPlayer")

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

        Return dsVentas

    End Function

    Public Function ObtenerAnalisisVtasMarcaLineaFamilia(ByVal Marca As String, ByVal Linea As String, ByVal Familia As String, ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMarcas As SqlDataAdapter
        Dim dsMarcas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMarcas = New SqlDataAdapter
        dsMarcas = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AnalisisVentaMarcaLineaFamilia]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Marca", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Linea", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Familia", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

        End With

        scdaMarcas.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaMarcas.SelectCommand

                .Parameters("@Marca").Value = Marca
                .Parameters("@Linea").Value = Linea
                .Parameters("@Familia").Value = Familia
                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor
                .Parameters("@IVA").Value = oParent.ApplicationContext.ApplicationConfiguration.IVA

            End With

            'Fill DataSet
            scdaMarcas.Fill(dsMarcas, "Factura")

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

        Return dsMarcas.Tables("Factura")

    End Function

    Public Function ObtenerAnalisisVtasFamiliaMarca(ByVal Familia As String, ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMarcas As SqlDataAdapter
        Dim dsMarcas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMarcas = New SqlDataAdapter
        dsMarcas = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AnalisisVentaFamiliaMarca]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Familia", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

        End With

        scdaMarcas.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaMarcas.SelectCommand

                .Parameters("@Familia").Value = Familia
                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor
                .Parameters("@IVA").Value = oParent.ApplicationContext.ApplicationConfiguration.IVA

            End With

            'Fill DataSet
            scdaMarcas.Fill(dsMarcas, "Factura")

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

        Return dsMarcas.Tables("Factura")

    End Function

    Public Function ObtenerAnalisisVtasLineaFamilia(ByVal Linea As String, ByVal Familia As String, ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMarcas As SqlDataAdapter
        Dim dsMarcas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMarcas = New SqlDataAdapter
        dsMarcas = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AnalisisVentaLineaFamilia]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Linea", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Familia", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

        End With

        scdaMarcas.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaMarcas.SelectCommand

                .Parameters("@Linea").Value = Linea
                .Parameters("@Familia").Value = Familia
                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor
                .Parameters("@IVA").Value = oParent.ApplicationContext.ApplicationConfiguration.IVA

            End With

            'Fill DataSet
            scdaMarcas.Fill(dsMarcas, "Factura")

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

        Return dsMarcas.Tables("Factura")

    End Function

    Public Function ObtenerAnalisisVtasCodigo(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMarcas As SqlDataAdapter
        Dim dsMarcas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMarcas = New SqlDataAdapter
        dsMarcas = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AnalisisVentaCodigo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

        End With

        scdaMarcas.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaMarcas.SelectCommand

                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor
                .Parameters("@IVA").Value = oParent.ApplicationContext.ApplicationConfiguration.IVA

            End With

            'Fill DataSet
            scdaMarcas.Fill(dsMarcas, "Factura")

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

        Return dsMarcas.Tables("Factura")

    End Function

    Public Function ObtenerAnalisisVtasPlayers(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPlayers As SqlDataAdapter
        Dim dsPlayers As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPlayers = New SqlDataAdapter
        dsPlayers = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandTimeout = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.ConnectionTimeout
            .CommandText = "[AnalisisVentaPlayer]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))

        End With

        scdaPlayers.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaPlayers.SelectCommand

                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor

            End With

            'Fill DataSet
            scdaPlayers.Fill(dsPlayers, "Factura")

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

        Return dsPlayers.Tables("Factura")

    End Function

    Public Function ObtenerAnalisisVtasMarcas(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMarcas As SqlDataAdapter
        Dim dsMarcas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMarcas = New SqlDataAdapter
        dsMarcas = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AnalisisVentaMarca]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

        End With

        scdaMarcas.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaMarcas.SelectCommand

                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor
                .Parameters("@IVA").Value = oParent.ApplicationContext.ApplicationConfiguration.IVA

            End With

            'Fill DataSet
            scdaMarcas.Fill(dsMarcas, "Factura")

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

        Return dsMarcas.Tables("Factura")

    End Function

    Public Function ObtenerAnalisisVtasLineas(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMarcas As SqlDataAdapter
        Dim dsMarcas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMarcas = New SqlDataAdapter
        dsMarcas = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AnalisisVentaLinea]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

        End With

        scdaMarcas.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaMarcas.SelectCommand

                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor
                .Parameters("@IVA").Value = oParent.ApplicationContext.ApplicationConfiguration.IVA

            End With

            'Fill DataSet
            scdaMarcas.Fill(dsMarcas, "Factura")

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

        Return dsMarcas.Tables("Factura")

    End Function

    Public Function ObtenerAnalisisVtasFamilias(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMarcas As SqlDataAdapter
        Dim dsMarcas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMarcas = New SqlDataAdapter
        dsMarcas = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AnalisisVentaFamilia]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

        End With

        scdaMarcas.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaMarcas.SelectCommand

                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor
                .Parameters("@IVA").Value = oParent.ApplicationContext.ApplicationConfiguration.IVA

            End With

            'Fill DataSet
            scdaMarcas.Fill(dsMarcas, "Factura")

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

        Return dsMarcas.Tables("Factura")

    End Function

    Public Function ObtenerAnalisisVtasSucursal(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPlayers As SqlDataAdapter
        Dim dsPlayers As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPlayers = New SqlDataAdapter
        dsPlayers = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AnalisisVentaSucursal]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))

        End With

        scdaPlayers.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaPlayers.SelectCommand

                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor

            End With

            'Fill DataSet
            scdaPlayers.Fill(dsPlayers, "Factura")

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

        Return dsPlayers.Tables("Factura")

    End Function

    Public Function ObtenerAnalisisVtasCategorias(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMarcas As SqlDataAdapter
        Dim dsMarcas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMarcas = New SqlDataAdapter
        dsMarcas = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AnalisisVentaCategorias]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

        End With

        scdaMarcas.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaMarcas.SelectCommand

                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor
                .Parameters("@IVA").Value = oParent.ApplicationContext.ApplicationConfiguration.IVA

            End With

            'Fill DataSet
            scdaMarcas.Fill(dsMarcas, "Factura")

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

        Return dsMarcas.Tables("Factura")

    End Function

    Public Function ObtenerAnalisisVtasporDia(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMarcas As SqlDataAdapter
        Dim dsMarcas As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMarcas = New SqlDataAdapter
        dsMarcas = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AnalisisVentaporDia]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))

        End With

        scdaMarcas.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaMarcas.SelectCommand

                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor

            End With

            'Fill DataSet
            scdaMarcas.Fill(dsMarcas, "Factura")

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

        Return dsMarcas.Tables("Factura")

    End Function

    Public Function [VentasPromedioPorHora](ByVal FechaDel As DateTime, ByVal FechaAl As DateTime, ByVal CodCaja As String) As DataSet

        Dim oResult As DataSet

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoMarcasSel As SqlCommand
        sccmdCatalogoMarcasSel = New SqlCommand

        With sccmdCatalogoMarcasSel
            .CommandText = "[VentasPromedioPorHora]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDel", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaAl", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@FechaDel").Value = Format(FechaDel, "dd/MM/yyyy HH:mm:ss")
            .Parameters("@FechaAl").Value = Format(FechaAl, "dd/MM/yyyy HH:mm:ss")
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodCaja").Value = CodCaja

        End With

        Dim scdaAlmacenesAdapter As SqlDataAdapter
        scdaAlmacenesAdapter = New SqlDataAdapter

        scdaAlmacenesAdapter.SelectCommand = sccmdCatalogoMarcasSel


        Try

            sccnnDPTienda.Open()

            oResult = New DataSet

            scdaAlmacenesAdapter.Fill(oResult, "CatalogoMarcas")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoMarcasSel.Dispose()
        sccmdCatalogoMarcasSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult


    End Function

    Public Function [VentasTotalesPorHora](ByVal FechaDel As DateTime, ByVal FechaAl As DateTime, ByVal CodCaja As String) As DataSet

        Dim oResult As DataSet

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoMarcasSel As SqlCommand
        sccmdCatalogoMarcasSel = New SqlCommand

        With sccmdCatalogoMarcasSel
            .CommandText = "[VentasTotalesPorHora]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDel", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaAl", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

            .Parameters("@FechaDel").Value = Format(FechaDel, "dd/MM/yyyy HH:mm:ss")
            .Parameters("@FechaAl").Value = Format(FechaAl, "dd/MM/yyyy HH:mm:ss")
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodCaja").Value = CodCaja
            .Parameters("@IVA").Value = oParent.ApplicationContext.ApplicationConfiguration.IVA

        End With

        Dim scdaAlmacenesAdapter As SqlDataAdapter
        scdaAlmacenesAdapter = New SqlDataAdapter

        scdaAlmacenesAdapter.SelectCommand = sccmdCatalogoMarcasSel


        Try

            sccnnDPTienda.Open()

            oResult = New DataSet

            scdaAlmacenesAdapter.Fill(oResult, "CatalogoMarcas")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoMarcasSel.Dispose()
        sccmdCatalogoMarcasSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult


    End Function

    Public Function SelectFolioSAP(ByVal codCaja As String, ByVal FolioFactura As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFSAP As SqlDataAdapter
        Dim dsFSAP As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFSAP = New SqlDataAdapter
        dsFSAP = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[FacturaFolioSAPGET]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

        End With

        scdaFSAP.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaFSAP.SelectCommand.Parameters("@FolioFactura").Value = FolioFactura
            scdaFSAP.SelectCommand.Parameters("@CodCaja").Value = codCaja

            'Fill DataSet
            scdaFSAP.Fill(dsFSAP)

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

        Return dsFSAP

    End Function

    Public Function [VentasDetallePorHora](ByVal FechaDel As DateTime, ByVal FechaAl As DateTime, ByVal CodCaja As String) As DataSet

        Dim oResult As DataSet

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoMarcasSel As SqlCommand
        sccmdCatalogoMarcasSel = New SqlCommand

        With sccmdCatalogoMarcasSel
            .CommandText = "[VentasDetallePorHora]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDel", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaAl", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

            .Parameters("@FechaDel").Value = Format(FechaDel, "dd/MM/yyyy HH:mm:ss")
            .Parameters("@FechaAl").Value = Format(FechaAl, "dd/MM/yyyy HH:mm:ss")
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodCaja").Value = CodCaja
            .Parameters("@IVA").Value = oParent.ApplicationContext.ApplicationConfiguration.IVA

        End With

        Dim scdaAlmacenesAdapter As SqlDataAdapter
        scdaAlmacenesAdapter = New SqlDataAdapter

        scdaAlmacenesAdapter.SelectCommand = sccmdCatalogoMarcasSel


        Try

            sccnnDPTienda.Open()

            oResult = New DataSet

            scdaAlmacenesAdapter.Fill(oResult, "CatalogoMarcas")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoMarcasSel.Dispose()
        sccmdCatalogoMarcasSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult


    End Function

#Region "Comparativo"

    Public Function ObtenerAnalisisVtasComparativo(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaComparativo As SqlDataAdapter
        Dim dsComparativo As DataSet
        Dim oResult As DataTable

        sccmdSelectAll = New SqlCommand
        scdaComparativo = New SqlDataAdapter
        dsComparativo = New DataSet("Comparativo")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AnalisisVentaComparativo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrdenarPor", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

        End With

        scdaComparativo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaComparativo.SelectCommand

                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@FechaIni").Value = datFROM
                .Parameters("@FechaFin").Value = datTO
                .Parameters("@OrdenarPor").Value = OrdenarPor
                .Parameters("@IVA").Value = oParent.ApplicationContext.ApplicationConfiguration.IVA

            End With

            'Fill DataSet
            scdaComparativo.Fill(dsComparativo)

            oResult = FormatearComparativo(dsComparativo)

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

        Return oResult

    End Function

    Private Function FormatearComparativo(ByVal ds As DataSet) As DataTable

        Dim dtResult As DataTable
        Dim oRowDB As DataRow, oRowResult As DataRow, oRow As DataRow
        Dim decTotalImporteNeto As Decimal = 0
        Dim strCodVendedor As String = String.Empty


        dtResult = CreateStructureComparativo()

        If Not ds Is Nothing Then

            If ds.Tables(0).Rows.Count > 0 Then

                '''Leemos informacion de la consulta SQL
                For Each oRowDB In ds.Tables(0).Rows

                    If oRowDB!CodVendedor <> strCodVendedor Then

                        If strCodVendedor <> String.Empty Then
                            dtResult.Rows.Add(oRowResult)
                        End If

                        strCodVendedor = oRowDB!CodVendedor

                        '''Llenamos tabla resultado con datos leidos
                        oRowResult = dtResult.NewRow
                        oRowResult!Codigo = oRowDB!CodVendedor
                        oRowResult!Nombre = oRowDB!Nombre

                        Select Case UCase(oRowDB!Tipo)
                            Case "T"    'Tenis
                                oRowResult!Tenis = oRowResult!Tenis + oRowDB!Cantidad
                                oRowResult!ImporteTenis = oRowResult!ImporteTenis + oRowDB!Total
                            Case "02"    'Textil
                                oRowResult!Textil = oRowResult!Textil + oRowDB!Cantidad
                                oRowResult!ImporteTextil = oRowResult!ImporteTextil + oRowDB!Total
                            Case "03"    'Accesorio
                                oRowResult!Accesorio = oRowResult!Accesorio + oRowDB!Cantidad
                                oRowResult!ImporteAccesorio = oRowResult!ImporteAccesorio + oRowDB!Total
                            Case "01"    'Calzado
                                oRowResult!Calzado = oRowResult!Calzado + oRowDB!Cantidad
                                oRowResult!ImporteCalzado = oRowResult!ImporteCalzado + oRowDB!Total
                            Case "S"    'SAndalias
                                oRowResult!Sandalias = oRowResult!Sandalias + oRowDB!Cantidad
                                oRowResult!ImporteSandalias = oRowResult!ImporteSandalias + oRowDB!Total
                        End Select
                        oRowResult!Piezas = oRowResult!Tenis + oRowResult!Textil + oRowResult!Accesorio + oRowResult!Calzado + oRowResult!Sandalias
                        oRowResult!ImporteNeto = oRowResult!ImporteTenis + oRowResult!ImporteTextil + oRowResult!ImporteAccesorio + oRowResult!ImporteCalzado + oRowResult!ImporteSandalias

                    Else

                        '''Llenamos tabla resultado con datos leidos
                        Select Case UCase(oRowDB!Tipo)
                            Case "T"    'Tenis
                                oRowResult!Tenis = oRowResult!Tenis + oRowDB!Cantidad
                                oRowResult!ImporteTenis = oRowResult!ImporteTenis + oRowDB!Total
                            Case "02"    'Textil
                                oRowResult!Textil = oRowResult!Textil + oRowDB!Cantidad
                                oRowResult!ImporteTextil = oRowResult!ImporteTextil + oRowDB!Total
                            Case "03"    'Accesorio
                                oRowResult!Accesorio = oRowResult!Accesorio + oRowDB!Cantidad
                                oRowResult!ImporteAccesorio = oRowResult!ImporteAccesorio + oRowDB!Total
                            Case "01"    'Calzado
                                oRowResult!Calzado = oRowResult!Calzado + oRowDB!Cantidad
                                oRowResult!ImporteCalzado = oRowResult!ImporteCalzado + oRowDB!Total
                            Case "S"    'SAndalias
                                oRowResult!Sandalias = oRowResult!Sandalias + oRowDB!Cantidad
                                oRowResult!ImporteSandalias = oRowResult!ImporteSandalias + oRowDB!Total
                        End Select
                        oRowResult!Piezas = oRowResult!Tenis + oRowResult!Textil + oRowResult!Accesorio + oRowResult!Calzado + oRowResult!Sandalias
                        oRowResult!ImporteNeto = oRowResult!ImporteTenis + oRowResult!ImporteTextil + oRowResult!ImporteAccesorio + oRowResult!ImporteCalzado + oRowResult!ImporteSandalias
                    End If

                Next

                oRowResult!Piezas = oRowResult!Tenis + oRowResult!Textil + oRowResult!Accesorio + oRowResult!Calzado + oRowResult!Sandalias
                oRowResult!ImporteNeto = oRowResult!ImporteTenis + oRowResult!ImporteTextil + oRowResult!ImporteAccesorio + oRowResult!ImporteCalzado + oRowResult!ImporteSandalias
                dtResult.Rows.Add(oRowResult)

                dtResult.AcceptChanges()

                oRowDB = Nothing
                oRowResult = Nothing
                Dim tIndice As Decimal = 0

                decTotalImporteNeto = dtResult.Compute("SUM(ImporteNeto)", "")
                '''Definimos el porcentaje
                For Each oRow In dtResult.Rows
                    If decTotalImporteNeto > 0 Then
                        oRow!Indicador = Decimal.Round((oRow!ImporteNeto * 100) / decTotalImporteNeto, 2)
                    Else
                        oRow!Indicador = Decimal.Round((oRow!ImporteNeto * 100), 2)
                    End If
                    tIndice = tIndice + oRow!Indicador
                Next

                If tIndice < 100 Then
                    oRow!Indicador = oRow!Indicador + (100 - tIndice)
                ElseIf tIndice > 100 Then
                    oRow!Indicador = oRow!Indicador - (tIndice - 100)
                End If

                oRow = Nothing

            End If

        End If

        Return dtResult

    End Function

    Private Function CreateStructureComparativo() As DataTable

        Dim dtTemp As New DataTable

        Dim dCol As DataColumn

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "Codigo"
        dCol.DefaultValue = "NN"
        dtTemp.Columns.Add(dCol)

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "Nombre"
        dCol.DefaultValue = "NN"
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "Tenis"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "ImporteTenis"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "Textil"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "ImporteTextil"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "Accesorio"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "ImporteAccesorio"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "Calzado"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "ImporteCalzado"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "Sandalias"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "ImporteSandalias"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "Piezas"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "ImporteNeto"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "Indicador"
        dCol.DefaultValue = 0
        dtTemp.Columns.Add(dCol)

        Return dtTemp

    End Function

#End Region

End Class
